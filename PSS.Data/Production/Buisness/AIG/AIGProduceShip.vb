Option Explicit On 
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class AIGProduceShip

        Private _objDataProc As DBQuery.DataProc
        Public Shared _strRequiredBillcodes() = New String() {"Exception Repairs", "Depot Repaired", "PSS Warranty No Fault Found", "Repaired PSS Warranty", "Exception Repairs Quote Rejected", "BER", "CANCEL"}

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

        '***************************************************************************************************
        Public Function CreateBoxID(ByVal iCustID As Integer, _
                             ByVal iLocID As Integer, _
                             ByVal iWOID As Integer) As Integer
            Dim strSql, strDate, strPalletName As String
            Dim iPalletID As Integer = 0
            Dim dt As DataTable

            Try
                strSql = "" : strDate = "" : strPalletName = ""

                'construct pallet name
                strDate = Generic.GetMySqlDateTime("%y%m%d")
                strPalletName = "AIG" + strDate & "N" & iWOID

                'check for duplicate pallet
                strSql = "Select * From tpallett where WO_ID = " & iWOID & " AND Pallet_Invalid = 0 AND Pallett_ShipDate is null "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    iPalletID = PSS.Data.Production.Shipping.CreatePallet(iCustID, iLocID, 0, iWOID, strPalletName, 0, "", 0, 0, 0)
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Multiple box existed for this RMA. Please contact IT.")
                ElseIf PSS.Data.Buisness.Generic.IsPalletClosed(dt.Rows(0)("Pallett_ID")) = True Then
                    Throw New Exception("Box had been closed by another machine. Please refresh your screen.")
                Else
                    iPalletID = dt.Rows(0)("Pallett_ID")
                End If
                '******************************

                Return iPalletID
            Catch ex As Exception
                Throw New Exception("Buisness.TMI.RecShip.CreateBoxID: " & ex.Message)
            End Try
        End Function

        '***************************************************************************************************
        Public Function IsDeviceHasServiceBillcode(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as cnt FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND BillType_ID = 1 "
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function IsDeviceHasTechCompletedRecord(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = " SELECT *" & Environment.NewLine
                strSql &= " FROM tCellOpt WHERE Device_ID=" & iDeviceID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("SN_Discp_Flag") = 1 And dt.Rows(0).Item("SN_Discp_AV_ID") = 2 Then 'SN discrepancy device and rejected. no need tech performance
                        Return True
                    End If
                End If

                ' strSql = "SELECT count(*) as cnt FROM ttestdata WHERE Test_ID = 7 AND Device_ID = " & iDeviceID & Environment.NewLine
                strSql = "SELECT count(*) as cnt FROM technotes WHERE Device_ID = " & iDeviceID & Environment.NewLine

                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetBilledData(ByVal Device As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt " & Environment.NewLine
                strSql &= ", tdevicebill.Device_ID, tdevicebill.BillCode_ID, tdevicebill.Fail_ID" & Environment.NewLine
                strSql &= ", tdevicebill.Repair_ID, tdevicebill.Comp_ID, tdevicebill.User_ID, tdevicebill.Part_Number " & Environment.NewLine
                strSql &= ", lbillcodes.BillType_ID, lbillcodes.BillCode_Rule, lbillcodes.Billcode_Desc, ReplPartSN  " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & Device & ";"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************
        Public Shared Function IsDeviceHasMainService(ByVal dtBilledBillCode As DataTable) As Boolean
            Dim booReturnVal As Boolean = False
            Dim i As Integer

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If dtBilledBillCode.Select("Billcode_Desc = '" & _strRequiredBillcodes(i) & "'").Length > 0 Then
                        booReturnVal = True : Exit For
                    End If
                Next i

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function

        '*************************************************************************************************************
        Public Shared Function IsMainService(ByVal strBillcodeDesc As String) As Boolean
            Dim i As Integer
            Dim booReturnVal As Boolean = False

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If strBillcodeDesc = _strRequiredBillcodes(i) Then
                        booReturnVal = True : Exit For
                    End If
                Next i

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetShipCarriers() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT SC_ID,SC_Desc" & Environment.NewLine
                strSql &= " FROM lshipcarrier " & Environment.NewLine
                strSql &= " WHERE  SC_Active=1" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetShipDaysAll(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = " SELECT 1 RowID,a.ShipDays,b.State_Short as State,b.State_Long as StateFull,e.cntry_Name as Country," & Environment.NewLine
                strSql &= "c.sc_desc as Carrier,a.Comment,d.Cust_name1 as Customer,a.ShipDay_ID,b.State_ID,c.SC_ID,e.cntry_ID,d.cust_ID " & Environment.NewLine
                strSql &= " FROM lpssishipdays a" & Environment.NewLine
                strSql &= " inner join lstate b on a.state_id=b.state_id and a.Cust_Id=" & iCust_ID & Environment.NewLine
                strSql &= " inner join lshipcarrier c on a.sc_id=c.sc_id" & Environment.NewLine
                strSql &= " inner join tcustomer d on a.cust_id=d.cust_id" & Environment.NewLine
                strSql &= " inner join lcountry e on b.fk_cntry_id=e.cntry_id" & Environment.NewLine
                strSql &= " order by a.shipdays;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************
        Public Function GetCountryAll() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select Cntry_ID,Cntry_Name from lcountry;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function



        '******************************************************************
        Public Function GetStates(ByVal iCntry_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select State_ID, State_long as StateFull " & Environment.NewLine
                strSql &= " from lstate where fk_Cntry_ID=" & iCntry_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************
        Public Function GetStates_Filtered(ByVal iCntry_ID As Integer, ByVal strFilteredStateIDs As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "select State_ID, State_long as StateFull " & Environment.NewLine
                If strFilteredStateIDs.Trim.Length > 0 Then
                    strSql &= " from lstate where fk_Cntry_ID=" & iCntry_ID & Environment.NewLine
                    strSql &= " and State_ID not in (" & strFilteredStateIDs & ");" & Environment.NewLine
                Else
                    strSql &= " from lstate where fk_Cntry_ID=" & iCntry_ID & Environment.NewLine
                End If

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function InsertPssiToStateShipDays(ByVal iCust_ID As Integer, _
                                                  ByVal iState_ID As Integer, _
                                                  ByVal iCarrier_ID As Integer, _
                                                  ByVal iShipDays As Integer, _
                                                  ByVal strComment As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "insert into production.lpssishipdays " & Environment.NewLine
                strSql &= " (Cust_ID,State_ID,SC_ID,ShipDays,Comment)" & Environment.NewLine
                strSql &= " Values (" & iCust_ID & "," & iState_ID & "," & iCarrier_ID & "," & iShipDays & ",'" & strComment.Replace("'", "''") & "')"

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function PssiToStateShipDays_Duplicate(ByVal iCust_ID As Integer, _
                                                      ByVal iState_ID As Integer, _
                                                      ByVal iCarrier_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                strSql = "select * from production.lpssishipdays " & Environment.NewLine
                strSql &= " where Cust_ID=" & iCust_ID & " and State_ID=" & iState_ID & " and SC_ID=" & iCarrier_ID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then 'found
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function UpdatePssiToStateShipDays(ByVal iShipDay_ID As Integer, _
                                                  ByVal iShipDays As Integer, _
                                                  ByVal strComment As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "update production.lpssishipdays " & Environment.NewLine
                strSql &= " set ShipDays=" & iShipDays & ",Comment='" & strComment.Replace("'", "''") & "'" & Environment.NewLine
                strSql &= " Where ShipDay_ID=" & iShipDay_ID

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetDevicesByPallettID(ByVal iPallett_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tDevice WHERE Pallett_ID=" & iPallett_ID
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function GetDevicesByPallettName(ByVal iLoc_ID As Integer, ByVal strPallett_Name As String) As DataTable
        '    Dim strSql As String = ""
        '    Dim dt As DataTable, row As DataRow
        '    Dim iPallett_ID As Integer = 0

        '    Try
        '        strSql = "SELECT * FROM tPallett WHERE Loc_ID=" & iLoc_ID & " AND Pallett_Name='" & strPallett_Name & "'"
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        For Each row In dt.Rows 'should be one row
        '            iPallett_ID = CInt(row("Pallett_ID"))
        '            Exit For
        '        Next

        '        strSql = "SELECT * FROM tDevice WHERE Pallett_ID=" & iPallett_ID
        '        Return Me._objDataProc.GetDataTable(strSql)

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************
        Public Function GetServiceWOData(ByVal iCust_ID As Integer, ByVal iDevice_ID As Integer) As DataSet
            'Data are designed for printing a Service Work Order Letter
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim ds As New DataSet()
            Dim strDtName1 As String = "MasterData"
            Dim strDtName2 As String = "TechDiagnosis"
            Dim strDtName3 As String = "TechComments"

            Try
                '1. Master Data
                strSql = "SELECT DATE_FORMAT(A.LoadedDateTime,'%m/%d/%Y') AS 'DateOrderReceived',DATE_FORMAT( B.Device_DateRec,'%m/%d/%Y') AS 'DateProdRec'" & Environment.NewLine
                strSql &= ",DATE_FORMAT(B.Device_DateBill,'%m/%d/%Y') AS 'DatePartOrdered',DATE_FORMAT( B.Device_DateShip,'%m/%d/%Y') AS 'DateComplete'" & Environment.NewLine
                strSql &= ",A.ShipTO_Name AS 'CUSTName',CONCAT(IF(LENGTH(TRIM(A.Address1))>0,A.Address1,''),IF(LENGTH(TRIM(A.Address2))>0,CONCAT(', ', A.Address2),'')" & Environment.NewLine
                strSql &= ",CONCAT(', ',A.City), CONCAT(', ',A.State_ShortName), CONCAT(' ',A.ZipCode)) AS 'CustAddress'"
                strSql &= ",A.Tel AS 'Phone1','' AS 'Phone2',A.Brand AS 'ProdMake',A.Model AS 'ProdModel',B.Device_SN AS 'ProdSN'" & Environment.NewLine
                strSql &= ",'' AS CustProblem1,'' AS CustProblem2,'' AS RequiredEstYN,DATE_FORMAT(B.Device_DateBill,'%m/%d/%Y') AS DateEstimated" & Environment.NewLine
                strSql &= ",IF(B.Device_LaborCharge IS Null,0,B.Device_LaborCharge) AS Labor1,0 AS Labor2,'' AS Labor3" & Environment.NewLine
                strSql &= ",IF(B.Device_PartCharge IS Null,0,B.Device_PartCharge) AS Parts1,0 AS Parts2,'' AS Parts3" & Environment.NewLine
                strSql &= ",IF(B.Device_LaborCharge IS Null AND B.Device_PartCharge IS Null,0,B.Device_LaborCharge+B.Device_PartCharge) AS Total1" & Environment.NewLine
                strSql &= ",0 AS Total2,'' AS Total3,'' AS DateApproved,'' AS TechDiagnosis1,'' AS TechDiagnosis2" & Environment.NewLine
                strSql &= ",'' AS ServicePerformed1,'' AS ServicePerformed2,'' AS PartReplaced,'' AS Comments1,'' AS Comments2,0 AS Other1" & Environment.NewLine
                strSql &= ",'' AS Other2,0.00 AS Other3,'' AS Other4,'' AS Other5,A.EW_ID,B.Device_ID,C.DBill_ID,D.BIllCode_ID,E.BillType_ID" & Environment.NewLine
                strSql &= ",C.Part_Number,D.BillCode_desc,E.BillType_LDesc,A.ClaimNo,B.Device_SN,A.EstimatedPartCost,DATE_FORMAT(A.EstimatedPartCost_Date,'%m/%d/%Y') AS EstimatedPartCost_Date" & Environment.NewLine
                strSql &= ",IF(A.DefectType1 IS NULL,'',A.DefectType1) AS DefectType1,IF(A.DefectType2 IS NULL,'',A.DefectType2) AS DefectType2,IF(ErrDesc_ItemSku IS NULL,'',A.ErrDesc_ItemSku) AS ErrDesc_ItemSku" & Environment.NewLine
                strSql &= " FROM ExtendedWarranty A" & Environment.NewLine
                strSql &= " INNER JOIN tDevice B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN tDeviceBill C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN lBillcodes D ON C.BillCode_ID=D.BillCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lBillType E ON  D.BillType_ID=E.BillType_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND B.Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = strDtName1 : ds.Tables.Add(dt.Copy)

                '2. Technician Diagnosis Data
                strSql = " SELECT A.DCode_ID,B.DCode_SDesc,B.DCode_LDesc,C.MCode_ID,MCode_Desc" & Environment.NewLine
                strSql &= " FROM tTechFailureResult A" & Environment.NewLine
                strSql &= " INNER JOIN lCodesDetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN lCodesMaster C ON B.Mcode_ID=C.Mcode_ID" & Environment.NewLine
                strSql &= " WHERE Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = strDtName2 : ds.Tables.Add(dt.Copy)

                '3. Tech Notes Data
                strSql = "SELECT Notes FROM TechNotes WHERE Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = strDtName3 : ds.Tables.Add(dt.Copy)

                Return ds

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsCorrectChargeForRejectedSNDiscrepancyDevice(ByVal iDevice_ID As Integer, ByVal iCancelBillCode_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1, dt2 As DataTable
            Dim bRes As Boolean = True

            Try

                strSql = " SELECT *" & Environment.NewLine
                strSql &= " FROM tCellOpt WHERE Device_ID=" & iDevice_ID
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0).Item("SN_Discp_Flag") = 1 And dt1.Rows(0).Item("SN_Discp_AV_ID") = 2 Then 'SN discrepancy device and rejected
                        strSql = " SELECT * FROM tDeviceBill WHERE Device_ID=" & iDevice_ID
                        dt2 = Me._objDataProc.GetDataTable(strSql)
                        If Not dt2.Rows(0).Item("BillCode_ID") = iCancelBillCode_ID Then 'Not charged correctly
                            bRes = False
                        End If
                    End If
                End If

                Return bRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
    End Class
End Namespace
