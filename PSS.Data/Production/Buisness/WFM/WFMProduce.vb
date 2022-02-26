Option Explicit On 

Imports System.Text

Namespace Buisness
    Public Class WFMProduce
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region
#Region "NTF Produce"
        '*********************************************************************************************************
        Public Function GetDeviceNTFDataByBoxName(ByVal iLoc_ID As Integer, ByVal strBoxName As String) As DataTable
            Dim strSql As String = ""
            Dim dt, dtBill As DataTable
            Dim row As DataRow


            Try
                'strSql = "SELECT  wb.whb_id,d.device_id, d.Device_SN, d.device_daterec, m.Model_Desc" & Environment.NewLine
                'strSql &= " , wb.box_na, wb.quantity, co.workstation, co.workstationentrydt,wb.disp_id" & Environment.NewLine
                'strSql &= " , d.device_datebill, d.device_dateship,'No' as 'HasBillcode'" & Environment.NewLine
                'strSql &= " FROM edi.titem itm inner join tdevice d on itm.Device_ID = d.device_id" & Environment.NewLine
                'strSql &= " inner join warehouse.wh_box wb on itm.whb_id = wb.whb_id" & Environment.NewLine
                'strSql &= " inner join tmodel m on d.model_id = m.model_id" & Environment.NewLine
                'strSql &= " inner join tcellopt co on d.device_id = co.device_id" & Environment.NewLine
                'strSql &= " WHERE d.Loc_ID = " & iLoc_ID & " AND wb.box_na='" & strBoxName.Replace("'", "''") & "';" & Environment.NewLine
                strSql = "SELECT p.Pallett_ID,d.device_id, d.Device_SN, d.device_daterec, m.Model_Desc" & Environment.NewLine
                strSql &= " , p.Pallett_Name as 'box_na', p.pallett_Qty as 'quantity',p.pallet_qc_passed,co.Cellopt_WIPOwner" & Environment.NewLine
                strSql &= " ,co.workstation, co.workstationentrydt,p.disp_id,d.Model_ID,pos.disp_cd as 'Disposition',pos.disp_na as 'Disposition_Desc'" & Environment.NewLine
                strSql &= " , d.device_datebill, d.device_dateship,'No' as 'HasBillcode'" & Environment.NewLine
                strSql &= " FROM edi.titem itm" & Environment.NewLine
                strSql &= " inner join tdevice d on itm.Device_ID = d.device_id" & Environment.NewLine
                strSql &= " inner join tpallett p on d.pallett_ID = p.pallett_ID" & Environment.NewLine
                strSql &= " inner join tmodel m on d.model_id = m.model_id" & Environment.NewLine
                strSql &= " inner join tcellopt co on d.device_id = co.device_id" & Environment.NewLine
                strSql &= " inner join tdispositions pos on p.disp_id =pos.disp_id" & Environment.NewLine
                strSql &= " WHERE d.Loc_ID = 3402 AND p.disp_ID=5 AND p.Pallett_Name='" & strBoxName.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    strSql = "Select * from tdevicebill where device_ID =" & row("device_id")
                    dtBill = Me._objDataProc.GetDataTable(strSql)
                    If dtBill.Rows.Count > 0 Then
                        row.BeginEdit() : row("HasBillcode") = "Yes" : row.AcceptChanges()
                    End If
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateWorkStation(ByVal iDevice_ID As Integer, ByVal iWipOwnerID As Integer, _
                                          ByVal strWorkstation As String, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Try
                '.Cellopt_WIPOwner,A.Cellopt_WIPEntryDt,A.Cellopt_WIPOwnerOld,A.WorkStation,A.WorkStation
                strSql = "UPDATE tCellopt SET Cellopt_WIPOwnerOld=Cellopt_WIPOwner,Cellopt_WIPOwner=" & iWipOwnerID & ",workstation='" & strWorkstation & "'" & Environment.NewLine
                strSql &= ",Cellopt_WIPEntryDt='" & strDateTime & "',WorkStationEntryDt='" & strDateTime & "'" & Environment.NewLine
                strSql &= " WHERE device_id = " & iDevice_ID & ";" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub PalletShippedUpdate(ByVal pallet_id As Integer)
            Dim strSql As String = ""
            Dim _now As DateTime = Date.Now
            Try
                ' UPDATE THE PALLET TABLE.
                strSql = "UPDATE tpallett SET " & Environment.NewLine
                strSql &= "pallett_shipdate = " & Buisness.Generic.ConvertToMySQLDateOrNullString(_now)
                strSql &= " WHERE pallett_id = " & pallet_id.ToString() & ";"
                _objDataProc.ExecuteNonQuery(strSql)
                ' UPDATE THE DEVICE TABLE.

                strSql = "UPDATE tdevice SET " & Environment.NewLine
                strSql &= "device_dateship = " & Buisness.Generic.ConvertToMySQLDateOrNullString(_now)
                strSql &= ",device_shipworkdate = " & Buisness.Generic.ConvertToMySQLDateOrNullString(Date.Now.Date)
                strSql &= " WHERE pallett_id = " & pallet_id.ToString() & ";"
                _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub AddCarrierUnlockCharge(ByVal vLaborCharge As Single, ByVal iDevice_ID As Integer, _
                                          ByVal iBillCode_ID As Integer, ByVal iUser_ID As Integer, _
                                          ByVal strDate As String, ByVal bFromTFProcess As Boolean)
            Dim strSql As String = ""
            Dim _now As DateTime = Date.Now
            Dim dt As DataTable
            Dim vSum As Single = 0.0

            Try

                'add tdevicebill
                strSql = " Insert Into tdevicebill (DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, Device_ID,"
                strSql &= "BillCode_ID, Part_Number, Fail_ID, Repair_ID, Comp_ID, User_ID, Date_Rec, ReplPartSN)"
                strSql &= " Values (0.00,0.00,0.00," & vLaborCharge & "," & iDevice_ID & ","
                strSql &= iBillCode_ID & ",'S0',0,0,null," & iUser_ID & ",'" & strDate & "','');"
                _objDataProc.ExecuteNonQuery(strSql)

                If bFromTFProcess Then
                    strSql = "update tdevice set device_laborcharge = device_laborcharge + " & vLaborCharge & " where device_ID=" & iDevice_ID & ";"
                    _objDataProc.ExecuteNonQuery(strSql)
                Else
                    'tdevice.device_laborcharge total
                    strSql = "select sum(DBill_InvoiceAmt) from tdevicebill where device_id=" & iDevice_ID & ";"
                    dt = _objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 0 Then
                        vSum = dt.Rows(0).Item(0)
                        strSql = "update tdevice set device_laborcharge = " & vSum & " where device_ID=" & iDevice_ID & ";"
                        _objDataProc.ExecuteNonQuery(strSql)
                    End If
                End If

                dt = Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Public Function IsExistCarrierUnlockCharge(ByVal iDevice_ID As Integer, ByVal iBillCode_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRes As Boolean = False

            Try

                strSql = "select * from tdevicebill where device_ID = " & iDevice_ID & " and billcode_ID = " & iBillCode_ID & ";"
                dt = _objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    bRes = True
                End If
                dt = Nothing

                Return bRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getCarrierUnlockCharge() As DataTable
            Dim strSql As String = ""

            Try

                strSql = "Select A.tcab_ID,A.BillCode_ID,tcab_Amount,B.BillCode_Desc,A.Cust_ID from  tcustaggregatebilling A" & Environment.NewLine
                strSql &= " Inner Join lbillcodes B On A.Billcode_Id=B.Billcode_ID" & Environment.NewLine
                strSql &= " Where A.Billcode_ID =4227;" & Environment.NewLine

                Return _objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getWFMCarrierUnlockModels(Optional ByRef strWFMModelIDs = "") As ArrayList
            Dim strSql As String = "", strS As String = ""
            Dim arrList As New ArrayList()
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try

                strSql = "SELECT * FROM exceptioncriteria WHERE TRIM(Description) ='WFM_CARRIER_UNLOCK_CHARGE' AND ACTIVE=1;"

                dt = _objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows 'one row
                    strS = row("ModelIDs")
                    strWFMModelIDs = strS
                    Dim items() As String = strS.Trim.Split(","c)
                    For i = 0 To items.Length - 1
                        If IsNumeric(items(i)) Then arrList.Add(items(i))
                    Next
                    Exit For
                Next
                Return arrList

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getCarrierUnlockModelsOfTFDeviceTransferredFromWFM(Optional ByRef strWFMModelIDs As String = "", _
                                                                           Optional ByRef strTFModelIDs As String = "") As ArrayList
            Dim strSql As String = "", strS As String = ""
            Dim arrList As New ArrayList()
            Dim dt As DataTable
            Dim row As DataRow

            Try

                strSql = "SELECT * FROM exceptioncriteria WHERE TRIM(Description) ='WFM_CARRIER_UNLOCK_CHARGE' AND ACTIVE=1;"
                dt = _objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If Not dt.Rows(0).IsNull("ModelIDs") AndAlso Trim(dt.Rows(0).Item("ModelIDs")).ToString.Length > 0 Then
                        strWFMModelIDs = Trim(dt.Rows(0).Item("ModelIDs")).ToString
                    End If
                End If

                If strWFMModelIDs.Trim.Length > 0 Then
                    strSql = "SELECT A.*,D.Disp_CD,B.Model_Desc as 'WFM Model_Desc',C.Model_desc as 'TF Model_desc'" & Environment.NewLine
                    strSql &= " FROM edi.twfm_tf_model_map A" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel B ON A.WFM_Model_ID=B.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel C ON A.TF_Model_ID=C.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdispositions D ON A.WFM_Disp_ID=D.Disp_ID" & Environment.NewLine
                    strSql &= " WHERE WFM_Model_ID IN (" & strWFMModelIDs.Trim & ");" & Environment.NewLine
                    dt = _objDataProc.GetDataTable(strSql)

                    For Each row In dt.Rows
                        strS = Trim(row("TF_Model_ID"))
                        If Not arrList.Contains(strS) Then
                            arrList.Add(strS)
                            If strTFModelIDs.Trim.Length = 0 Then
                                strTFModelIDs = strS
                            Else
                                strTFModelIDs &= "," & strS
                            End If
                        End If
                    Next
                End If

                Return arrList

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsCarrierUnlockModelOfTFDeviceTransferredFromWFM(ByVal strSN As String, _
                                                                         ByVal strWFM_ModelIDs As String, _
                                                                         ByVal strTF_ModelIDs As String) As Boolean
            Dim strSql As String = "", strS As String = ""
            Dim arrList As New ArrayList()
            Dim dtWFM, dtTF As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim bRes As Boolean = False

            Try

                strSql = "SELECT A.device_id,A.Device_SN,A.Model_ID,A.Loc_ID" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem B ON A.Device_ID= B.Device_ID" & Environment.NewLine
                strSql &= " WHERE A.Model_ID IN (" & strWFM_ModelIDs & ") AND LOC_ID=" & PSS.Data.Buisness.WFM.LOC_ID & Environment.NewLine
                strSql &= " AND A.Device_SN ='" & strSN.Replace("'", "''") & "';" & Environment.NewLine
                dtWFM = _objDataProc.GetDataTable(strSql)

                strSql = "SELECT A.device_id,A.Device_SN,A.Model_ID,A.Loc_ID " & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN edi.titem B ON A.Device_ID= B.Device_ID" & Environment.NewLine
                strSql &= " WHERE A.Model_ID IN (" & strTF_ModelIDs & ") AND LOC_ID=" & PSS.Data.Buisness.WFM.TF_LOC_ID & Environment.NewLine
                strSql &= " AND A.Device_SN ='" & strSN.Replace("'", "''") & "';" & Environment.NewLine
                dtTF = _objDataProc.GetDataTable(strSql)

                If dtWFM.Rows.Count = 1 AndAlso dtTF.Rows.Count = 1 Then
                    bRes = True
                End If

                Return bRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region
#Region "Shipment and Split Box"
        Public Function getNTFPallettDevices(ByVal strPallettName As String, ByVal iCust_ID As Integer, ByRef iPallett_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'strSql = "select B.Pallett_ID,A.Pallett_name,B.Device_Sn,B.device_ID,B.device_dateship, A.Pallett_ShipDate,B.device_laborcharge,C.Workstation" & Environment.NewLine
                strSql = "select B.device_ID,B.Device_Sn,B.Pallett_ID" & Environment.NewLine
                strSql &= " from tpallett A" & Environment.NewLine
                strSql &= " inner join tdevice B  on A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " inner join tcellopt C on B.device_ID=C.device_ID" & Environment.NewLine
                strSql &= " where A.Cust_ID=" & iCust_ID & " and A.Disp_ID=5 and C.Workstation='WH-Floor'" & Environment.NewLine
                strSql &= " and A.Pallett_ShipDate is not null and B.device_dateShip is not null" & Environment.NewLine
                strSql &= " and A.pallett_Name='" & strPallettName.Replace("'", "''") & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iPallett_ID = dt.Rows(0).Item("Pallett_ID")
                    dt.Columns.Remove("Pallett_ID")
                Else
                    iPallett_ID = 0
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsCorrectPalletFormat(ByVal strPalletName As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow

            Try
                strSql = "select '" & strPalletName & "' as 'pallett_Name', POSITION('OW' IN  '" & strPalletName & "') as 'Pos', length('" & strPalletName & "') as 'L'" & Environment.NewLine
                strSql &= " , Substring('" & strPalletName & "',POSITION('OW' IN '" & strPalletName & "')+2,length('" & strPalletName & "')-POSITION('OW' IN  '" & strPalletName & "')) as 'N'" & Environment.NewLine
                strSql &= " ;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If row.IsNull("n") OrElse Trim(row("N")).Length = 0 Then
                            Return False
                        ElseIf Not IsNumeric(Trim(row("N"))) Then
                            Return False
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If

                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function getPalletNamePart(ByVal strPalletName As String, ByRef PalletNamePart2 As String) As String
            Try
                Dim V()
                V = Microsoft.VisualBasic.Split(strPalletName, "OW")
                If V.Length = 2 Then
                    PalletNamePart2 = V(1)
                    Return V(0) & "OW"
                End If
                Return ""
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getNewPalletName(ByVal strOldPalletPart1 As String, ByVal strOldPalletPart2 As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim L As Integer = strOldPalletPart2.Trim.Length

            Try
                strSql = "select max(Substring(pallett_name,POSITION('OW' IN  pallett_Name)+2,length(trim(pallett_Name))-POSITION('OW' IN  pallett_Name))) as 'N'" & Environment.NewLine
                strSql &= " from tpallett where pallett_name like '" & strOldPalletPart1 & "%';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then 'should be 1
                    For Each row In dt.Rows
                        If row.IsNull("N") OrElse Trim(row("N")).Length = 0 Then
                            Return ""
                        ElseIf IsNumeric(Trim(row("N"))) AndAlso L > 0 Then
                            Dim v As Integer = row("N")
                            v += 1
                            Dim strS As String = v.ToString.Trim
                            Dim pad As Char = "0"c
                            If strS.Length <= L Then
                                Return strOldPalletPart1 & strS.PadLeft(L, pad)
                            End If
                            Return ""
                        End If
                    Next
                Else
                    Return ""
                End If

                Return ""
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateNewPallet(ByVal iOldPalletID As Integer, ByVal strNewPalletName As String, ByVal iNewPalletQty As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "Insert into tpallett (Pallett_Name,Pallett_ShipDate,Pallett_BulkShipped,Pallett_ReadyToShipFlg,Pallet_ShipType,Pallet_SkuLen,Pallet_Invalid,Pallet_InvalidUsrID,AWPFlag,WO_ID" & Environment.NewLine
                strSql &= " ,Model_ID,Cust_ID,pallet_TimeStamp,DOBFlg,Pallett_SendDt,Pallett_MaxQty,Pallett_QTY,Pallet_Weight,UnitMeasurementCode,Order_SeqNo,Pallet_SeqNo,pkslip_ID,Loc_ID" & Environment.NewLine
                strSql &= " ,SpecialInvProject,PalletType_ID,AQL_QCResult_ID,AQL_Lot_ID,WHLocation,disp_id,pallet_qc_passed)" & Environment.NewLine
                strSql &= "   select '" & strNewPalletName & "' AS 'Pallett_Name',Pallett_ShipDate,Pallett_BulkShipped,Pallett_ReadyToShipFlg,Pallet_ShipType,Pallet_SkuLen,Pallet_Invalid,Pallet_InvalidUsrID,AWPFlag,WO_ID" & Environment.NewLine
                strSql &= " ,Model_ID,Cust_ID,pallet_TimeStamp,DOBFlg,Pallett_SendDt,Pallett_MaxQty," & iNewPalletQty & "  as Pallett_QTY,Pallet_Weight,UnitMeasurementCode,Order_SeqNo,Pallet_SeqNo,pkslip_ID,Loc_ID" & Environment.NewLine
                strSql &= " ,SpecialInvProject,PalletType_ID,AQL_QCResult_ID,AQL_Lot_ID,WHLocation,disp_id,pallet_qc_passed" & Environment.NewLine
                strSql &= "  from tpallett where pallett_ID=" & iOldPalletID & ";" & Environment.NewLine

                Return Me._objDataProc.idTransaction(strSql, "tpallett")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPalletDevicesByPalletID(ByVal iPallett_ID As Integer) As DataTable
            Dim strSql As String = ""
            'Dim dt As DataTable
            Try

                strSql = "select A.Device_ID,A.Device_SN,B.Pallett_ID,B.Pallett_Name,B.pallett_qty,C.Model_ID,C.Model_Desc,B.disp_id,D.disp_cd as 'Disp_Desc'" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " Inner join tpallett B On A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " Inner join tmodel C On A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " inner join production.tdispositions D ON B.disp_id=D.disp_id" & Environment.NewLine
                strSql &= " Where B.pallett_ID =" & iPallett_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPalletDevicesByPalletName(ByVal strPallettName As String, ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            'Dim dt As DataTable
            Try
                strSql = "select A.Device_ID,A.Device_SN,B.Pallett_ID,B.Pallett_Name,B.pallett_qty,C.Model_ID,C.Model_Desc,B.disp_id,D.disp_cd as 'Disp_Desc'" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " Inner join tpallett B On A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " Inner join tmodel C On A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " inner join production.tdispositions D ON B.disp_id=D.disp_id" & Environment.NewLine
                strSql &= " Where B.Cust_ID=" & iCust_ID & " and B.Pallett_Name ='" & strPallettName.Replace("'", "''") & "' ;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPalletDevicesBySN(ByVal strSN As String, ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iPallett_ID As Integer = 0

            Try

                strSql = "select A.Device_ID,A.Device_SN,B.Pallett_ID,B.Pallett_Name,B.pallett_qty,C.Model_ID,C.Model_Desc,B.disp_id,D.disp_cd as 'Disp_Desc'" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " Inner join tpallett B On A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " Inner join tmodel C On A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " inner join production.tdispositions D ON B.disp_id=D.disp_id" & Environment.NewLine
                strSql &= " Where B.Cust_ID=" & iCust_ID & " and A.Device_SN ='" & strSN.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iPallett_ID = dt.Rows(0).Item("Pallett_ID")

                    strSql = "select A.Device_ID,A.Device_SN,B.Pallett_ID,B.Pallett_Name,B.pallett_qty,C.Model_ID,C.Model_Desc,B.disp_id,D.disp_cd as 'Disp_Desc'" & Environment.NewLine
                    strSql &= " from tdevice A" & Environment.NewLine
                    strSql &= " Inner join tpallett B On A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                    strSql &= " Inner join tmodel C On A.Model_ID=C.Model_ID" & Environment.NewLine
                    strSql &= " inner join production.tdispositions D ON B.disp_id=D.disp_id" & Environment.NewLine
                    strSql &= " Where B.pallett_ID =" & iPallett_ID & ";" & Environment.NewLine

                    dt = Me._objDataProc.GetDataTable(strSql)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region
    End Class
End Namespace
