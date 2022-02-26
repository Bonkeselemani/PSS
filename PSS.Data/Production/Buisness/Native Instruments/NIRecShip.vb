Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class NIRecShip
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

            Try
                strSql = "SELECT count(*) as cnt FROM ttestdata WHERE Test_ID = 7 AND Device_ID = " & iDeviceID & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function IsDeviceShipped(ByVal iDeviceID As Integer, ByVal iPalletID As Integer, ByVal bRepairedGood As Boolean) As Boolean
            Dim strSql As String = "", tmpStr As String = ""
            Dim dt As DataTable
            Dim isShipped1 As Boolean = False, isShipped2 As Boolean = False


            Try

                If bRepairedGood Then
                    strSql = "select device_dateship from tdevice WHERE Device_ID =" & iDeviceID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then
                        If IsDBNull(dt.Rows(0).Item(0)) Then
                            isShipped1 = False
                        Else
                            tmpStr = dt.Rows(0).Item(0)
                            If tmpStr.Trim.Length > 0 Then
                                isShipped1 = True
                            End If
                        End If
                    End If

                    If isShipped1 Then Return True Else Return False

                    'strSql = "select Pallett_ShipDate from tpallett WHERE Pallett_ID=" & iPalletID & ";"
                    'dt = Me._objDataProc.GetDataTable(strSql)

                    'If dt.Rows.Count > 0 Then
                    '    tmpStr = dt.Rows(0).Item(0)
                    '    If tmpStr.Trim.Length > 0 Then
                    '        isShipped2 = True
                    '    End If
                    'End If

                    'If isShipped1 And isShipped2 Then Return True Else Return False

                Else
                    strSql = "select device_dateship from tdevice WHERE Device_ID =" & iDeviceID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If IsDBNull(dt.Rows(0).Item(0)) Then
                        isShipped1 = False
                    Else
                        tmpStr = dt.Rows(0).Item(0)
                        If tmpStr.Trim.Length > 0 Then
                            isShipped1 = True
                        End If
                    End If

                    If isShipped1 Then Return True Else Return False
                End If

                Return False


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function CreateBoxID(ByVal iCustID As Integer, _
                             ByVal iLocID As Integer, _
                             ByVal iWOID As Integer) As Integer
            Dim strSql, strDate, strPalletName As String
            Dim iPalletID As Integer = 0
            Dim dt As DataTable

            Try
                strSql = "" : strDate = "" : strPalletName = ""
                '******************************
                'construct pallet name
                '******************************
                strDate = Generic.GetMySqlDateTime("%y%m%d")

                strPalletName = "NI" + strDate & "R" & iWOID 'R =Repaired

                '******************************
                'check for duplicate pallet
                '******************************
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

        '********************************************************************************
        Public Function Label_ReceiveBoxLabel(ByVal DeviceID As Integer, _
                                              ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                'strsql = "Select tmodel.Model_Desc AS Model" & Environment.NewLine
                'strsql &= ", tcellopt.Manuf_SN AS Serial" & Environment.NewLine
                'strsql &= ", tdevice.Device_ID AS DeviceID" & Environment.NewLine
                'strsql &= ", Device_SN AS PSSSN" & Environment.NewLine
                'strsql &= ", '' AS RecPalletName" & Environment.NewLine
                'strsql &= "From tdevice INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                'strsql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                'strsql &= "WHERE tdevice.Device_ID = " & DeviceID
                strsql = "Select tmodel.Model_Desc AS Model" & Environment.NewLine
                strsql &= ", tcellopt.Manuf_SN AS Serial" & Environment.NewLine
                strsql &= ", tdevice.Device_ID AS DeviceID" & Environment.NewLine
                strsql &= ", Device_SN AS PSSSN" & Environment.NewLine
                strsql &= ", extendedwarranty.claimno AS RecPalletName" & Environment.NewLine
                strsql &= " From tdevice INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strsql &= " LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= " INNER JOIN extendedwarranty on extendedwarranty.wo_id=tdevice.wo_id " & Environment.NewLine
                strsql &= "WHERE tdevice.Device_ID = " & DeviceID

                dt = Me._objDataProc.GetDataTable(strsql)
                objRpt = New ReportDocument()

                With objRpt
                    '.Load(PSS.Data.ConfigFile.GetBaseReportPath & "Syx_Receive_Box_Label.rpt")
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "TMI_Receive_Box_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function NIRepairType4DeviceID(ByVal iDeviceID As Integer) As String
            Dim strsql As String = ""
            Dim tmpStr As String = ""
            Dim dt As DataTable

            Try

                strsql = "select a.device_ID,a.Device_SN,b.claimNO,b.RepairType from tdevice a" & Environment.NewLine
                strsql &= " inner join Extendedwarranty b on a.WO_ID=b.WO_ID" & Environment.NewLine
                strsql &= " where a.device_ID=" & iDeviceID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                If dt.Rows.Count > 0 Then
                    tmpStr = dt.Rows(0).Item("RepairType")
                End If

                Return tmpStr

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function NICosmeticGrade4DeviceID(ByVal iDeviceID As Integer) As String
            Dim strsql As String = ""
            Dim tmpStr As String = ""
            Dim dt As DataTable

            Try
                strsql = "SELECT Dcode_Sdesc,DCode_LDesc FROM tcellopt" & Environment.NewLine
                strsql &= " INNER JOIN lcodesdetail ON tcellopt.OutBoundCosmGradeID = lcodesdetail.Dcode_ID" & Environment.NewLine
                strsql &= " WHERE Device_ID =" & iDeviceID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                If dt.Rows.Count > 0 Then
                    tmpStr = dt.Rows(0).Item("Dcode_Sdesc")
                End If

                Return tmpStr

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function
        '********************************************************************************
        Public Function NIModelData4DeviceID(ByVal iDeviceID As Integer) As DataTable
            Dim strsql As String = ""
            Dim tmpStr As String = ""

            Try

                strsql = "select tdevice.Device_SN, tmodel.model_desc,tdevice.model_ID, tdevice.device_DateShip from tdevice" & Environment.NewLine
                strsql &= " inner join tmodel  on tmodel.model_ID=tdevice.model_ID" & Environment.NewLine
                strsql &= " where device_ID=" & iDeviceID

                Return Me._objDataProc.GetDataTable(strsql)


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function NIGetPalletData(ByVal strPallet As String, ByVal iCustID As Integer) As DataTable
            Dim strsql As String = ""
            Try

                strsql = "select * from tPallett" & Environment.NewLine
                strsql &= " where Pallett_Name='" & strPallet & "' and Cust_ID=" & iCustID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strsql)

            Catch ex As Exception
                Throw ex
            Finally
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetNIStatusDesc(ByVal iStatusID As Integer) As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT Description FROM NI_Status WHERE S_ID = " & iStatusID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*******************************************************************************************************************
        Public Function CloseAndShipBox(ByVal iPalletID As Integer, ByVal iWOID As Integer, _
                                        ByVal iShiftID As Integer, ByVal iBoxQty As Integer, _
                                        ByVal strNextStation As String, ByRef objShip As Production.Shipping, _
                                        ByVal iShipCarrierID As Integer, ByVal strTrackingNo As String, _
                                        ByVal booCloseWO As Boolean) As Integer

            Const iNIStatusID As Integer = 7
            Dim strSql, strWorkdate As String
            Dim dt, dtProdID As DataTable
            Dim objBulkship As BulkShipping
            Dim iOverpack_ID, iShip_ID, i, iProdID As Integer

            Try
                strSql = "" : strWorkdate = "" : iOverpack_ID = 0 : iShip_ID = 0
                '***************************************************
                'Define work date
                '***************************************************
                If iShiftID = 0 Then Throw New Exception("System can't define shift ID.")
                strWorkdate = Generic.GetWorkDate(iShiftID)
                If strWorkdate.Trim.Length = 0 Then Throw New Exception("System can't define work date.")
                '***************************************************
                objBulkship = New BulkShipping()
                objBulkship.iPallet_ID = iPalletID
                objBulkship.iShipType = 0
                dtProdID = objBulkship.GetProdIDInPallet(iPalletID)
                If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0

                '*********************************************************
                Dim strServiceBillcode, strNIStatusDesc, strRepStatusCode As String
                Dim objNiShip As New NIRecShip()
                strServiceBillcode = "" : strNIStatusDesc = "" : strRepStatusCode = ""
                strNIStatusDesc = objNiShip.GetNIStatusDesc(iNIStatusID)
                If strNIStatusDesc.Trim.Length = 0 Then strNIStatusDesc = "Shipped"

                'strSql = "SELECT if (Billcode_Desc is null, '', Billcode_Desc) as ServiceCode, RepStatusCode" & Environment.NewLine
                'strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.billcode_ID AND BillType_ID = 1" & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN tmi_repairstatuscode ON tdevicebill.billcode_ID = tmi_repairstatuscode.billcode_ID" & Environment.NewLine
                'strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine

                strSql = "SELECT if (Billcode_Desc is null, '', Billcode_Desc) as ServiceCode" & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.billcode_ID AND BillType_ID = 1" & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("System can't define service billcode.")
                    'ElseIf IsDBNull(dt.Rows(0)("RepStatusCode")) Then
                    '    Throw New Exception("Repair status code is missing. Please contact IT.")
                Else
                    strServiceBillcode = dt.Rows(0)("ServiceCode")
                    'strRepStatusCode = dt.Rows(0)("RepStatusCode")
                    strRepStatusCode = ""
                End If
                If strServiceBillcode.Trim.Length > 0 Then strNIStatusDesc = strServiceBillcode & " - " & strServiceBillcode
                objNiShip = Nothing

                '****************************************************************************
                ''Step 2:: Create Overpack
                '****************************************************************************
                iOverpack_ID = objBulkship.CreateOverPack(strWorkdate)
                '****************************************************************************
                ''Step 3:: Create Masterpack
                '****************************************************************************
                iShip_ID = objBulkship.CreateMasterPack(iOverpack_ID, iPalletID, iProdID, )
                '****************************************************************************
                strSql = "UPDATE tdevice, tpallett, tcellopt " & Environment.NewLine
                strSql &= "SET "
                strSql &= " Ship_ID = " & iShip_ID & Environment.NewLine
                strSql &= ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                strSql &= ", Device_SendClaim = 0 " & Environment.NewLine
                strSql &= ", Device_DateShip = now() " & Environment.NewLine
                strSql &= ", Device_ShipWorkDate = '" & strWorkdate & "' " & Environment.NewLine
                strSql &= ", Pallett_ShipDate = '" & strWorkdate & "' " & Environment.NewLine
                strSql &= ", Pallett_ReadyToShipFlg = 1, Pallett_BulkShipped = 1 " & Environment.NewLine
                strSql &= ", Pallett_QTY = " & iBoxQty & " " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner = 7 " & Environment.NewLine
                strSql &= ", Cellopt_WIPEntryDt  = now() " & Environment.NewLine
                If strNextStation.Trim.Length > 0 Then strSql &= ", tcellopt.WorkStation = '" & strNextStation & "', tcellopt.WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = tpallett.Pallett_ID AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Pallett_ID = " & iPalletID & " AND tdevice.WO_ID = " & iWOID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to update shipping information.")

                If objShip.GetReadyToShipCountByWO(iWOID) = 0 AndAlso booCloseWO Then
                    strSql = "UPDATE tworkorder SET WO_Shipped = 1, WO_DateShip = '" & strWorkdate & "' WHERE WO_ID = " & iWOID & Environment.NewLine & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then Throw New Exception("System has failed to update shipping information in RMA.")
                End If

                strSql = "UPDATE extendedwarranty " & Environment.NewLine
                strSql &= " SET Final_SC_ID = " & iShipCarrierID & ", Final_PSSI2Cust_TrackNo = '" & strTrackingNo & "'" & Environment.NewLine
                strSql &= ", RepairStatusCode = '" & strRepStatusCode & "', PSSI_CurrentStatus = '" & strNIStatusDesc & "' , S_ID = " & iNIStatusID & Environment.NewLine
                'strSql &= ",Final_PSSI2Cust_ShipmentWeight=" & iWeight & ",Final_PSSI2Cust_ShipmentCost=" & iFreightage & Environment.NewLine
                strSql &= " WHERE WO_ID = " & iWOID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to update tracking information.")
                '******************************
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtProdID)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function CloseAndShipBox_Refurb(ByVal iPalletID As Integer, ByVal iWOID As Integer, _
                                        ByVal iDeviceID As Integer, _
                                        ByVal iShiftID As Integer, ByVal iBoxQty As Integer, _
                                        ByVal strNextStation As String, ByRef objShip As Production.Shipping, _
                                        ByVal iShipCarrierID As Integer, ByVal strTrackingNo As String, _
                                        ByVal booCloseWO As Boolean) As Integer

            Const iNIStatusID As Integer = 7
            Dim strSql, strWorkdate As String
            Dim dt, dtProdID, dtTmp As DataTable
            Dim objBulkship As BulkShipping
            Dim iOverpack_ID, iShip_ID, i, iProdID As Integer

            Try
                strSql = "" : strWorkdate = "" : iOverpack_ID = 0 : iShip_ID = 0
               
                '***************************************************
                'Define work date
                '***************************************************
                If iShiftID = 0 Then Throw New Exception("System can't define shift ID.")
                strWorkdate = Generic.GetWorkDate(iShiftID)
                If strWorkdate.Trim.Length = 0 Then Throw New Exception("System can't define work date.")
                '***************************************************

                objBulkship = New BulkShipping()
                objBulkship.iPallet_ID = iPalletID
                objBulkship.iShipType = 0
                dtProdID = objBulkship.GetProdIDInPallet(iPalletID)
                If dtProdID.Rows.Count = 1 Then iProdID = CInt(dtProdID.Rows(0)("Prod_ID")) Else iProdID = 0

                '*********************************************************
                Dim strServiceBillcode, strNIStatusDesc, strRepStatusCode As String
                Dim objNiShip As New NIRecShip()
                strServiceBillcode = "" : strNIStatusDesc = "" : strRepStatusCode = ""
                strNIStatusDesc = objNiShip.GetNIStatusDesc(iNIStatusID)
                If strNIStatusDesc.Trim.Length = 0 Then strNIStatusDesc = "Shipped"

                strSql = "SELECT if (Billcode_Desc is null, '', Billcode_Desc) as ServiceCode" & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.billcode_ID AND BillType_ID = 1" & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("System can't define service billcode.")
                    'ElseIf IsDBNull(dt.Rows(0)("RepStatusCode")) Then
                    '    Throw New Exception("Repair status code is missing. Please contact IT.")
                Else
                    strServiceBillcode = dt.Rows(0)("ServiceCode")
                    'strRepStatusCode = dt.Rows(0)("RepStatusCode")
                    strRepStatusCode = ""
                End If
                If strServiceBillcode.Trim.Length > 0 Then strNIStatusDesc = strServiceBillcode & " - " & strServiceBillcode
                objNiShip = Nothing

                '****************************************************************************
                ''Step 2:: Create Overpack
                '****************************************************************************
                iOverpack_ID = 243488
                '****************************************************************************
                ''Step 3:: Create Masterpack
                '****************************************************************************
                iShip_ID = 735077
                '****************************************************************************

                'Update tDevice
                strSql = "UPDATE tdevice " & Environment.NewLine
                strSql &= "SET "
                strSql &= " Ship_ID = " & iShip_ID & Environment.NewLine
                strSql &= ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                strSql &= ", Device_SendClaim = 0 " & Environment.NewLine
                strSql &= ", Device_DateShip = now() " & Environment.NewLine
                strSql &= ", Device_ShipWorkDate = '" & strWorkdate & "' " & Environment.NewLine
                strSql &= " WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to update shipping information on tDevice.")

                'Update tCellOpt
                strSql = "UPDATE  tcellopt " & Environment.NewLine
                strSql &= "SET "
                strSql &= " Cellopt_WIPOwnerOld = Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner = 7 " & Environment.NewLine
                strSql &= ", Cellopt_WIPEntryDt  = now() " & Environment.NewLine
                If strNextStation.Trim.Length > 0 Then strSql &= ", tcellopt.WorkStation = '" & strNextStation & "', tcellopt.WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= " WHERE Device_ID = " & iDeviceID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to update shipping information on tCellOpt.")

                'Update tWorkorder if need
                If objShip.GetReadyToShipCountByWO(iWOID) = 0 AndAlso booCloseWO = True Then
                    strSql = "UPDATE tworkorder SET WO_Shipped = 1, WO_DateShip = '" & strWorkdate & "' WHERE WO_ID = " & iWOID & Environment.NewLine & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then Throw New Exception("System has failed to update shipping information in RMA.")
                End If

                'Status if Reclaimation
                strSql = "select lBillCodes.BillCode_ID,lBillCodes.BillCode_Desc from tdevicebill inner join lBillCodes on tdevicebill.billcode_ID=lBillCodes.billcode_ID" & Environment.NewLine
                strSql &= " where tdevicebill.device_ID= " & iDeviceID & " and lBillCodes.billcode_ID=" & Data.Buisness.NI.RECLAIM_BILLCODE & ";"
                dtTmp = Me._objDataProc.GetDataTable(strSql)
                If dtTmp.Rows.Count = 1 Then strNIStatusDesc = "BER - " & dtTmp.Rows(0).Item("BillCode_Desc")

                'Update extendedwarranty 
                strSql = "UPDATE extendedwarranty " & Environment.NewLine
                strSql &= " SET Final_SC_ID = " & iShipCarrierID & ", Final_PSSI2Cust_TrackNo = '" & strTrackingNo & "'" & Environment.NewLine
                strSql &= ", RepairStatusCode = '" & strRepStatusCode & "', PSSI_CurrentStatus = '" & strNIStatusDesc & "' , S_ID = " & iNIStatusID & Environment.NewLine
                strSql &= " WHERE WO_ID = " & iWOID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to update tracking information.")
                '******************************
                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function PrintShippingBoxLabel(ByVal iDeviceID As Integer, _
                                             ByVal strCosmeticGrade As String, ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable
            Dim strModel, strSN, StrProductionDate As String, productionDate As Date

            Try
                'Use Syx_Receive_Box SQL in Crystal Report template. Columns: Model, Serial, DeviceID, PSSSN,RecPalletName
                'Label actutal needs Model, Serial, PSSSN (CosmeticGrade), RecPalletName (ProductionDate) 

                dt = NIModelData4DeviceID(iDeviceID)
                strModel = dt.Rows(0).Item("model_desc") : strSN = dt.Rows(0).Item("Device_SN")
                StrProductionDate = dt.Rows(0).Item("device_DateShip")
                If Not StrProductionDate.Length > 0 Then
                    StrProductionDate = Format(Now, "MM-dd-yyyy")
                ElseIf IsDate(StrProductionDate) Then
                    productionDate = StrProductionDate
                    StrProductionDate = Format(productionDate, "MM-dd-yyyy")
                Else
                    StrProductionDate = Format(Now, "MM-dd-yyyy")
                End If

                strsql = "SELECT '" & strModel & "' as Model, '" & strSN & "' AS Serial" & Environment.NewLine
                strsql &= ", " & iDeviceID & " AS DeviceID " & Environment.NewLine
                strsql &= ", '" & strCosmeticGrade & "' as PSSSN" & Environment.NewLine
                strsql &= ", '" & StrProductionDate & "' as  RecPalletName" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strsql)
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "NI_Ship_Box_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function NICosmeticCodeData4Grade(ByVal strCosmeticGrade As String) As DataTable
            Dim strsql As String = ""
            Dim tmpStr As String = ""

            Try
                strsql = " select DCode_ID,DCode_SDesc,DCode_Ldesc,DCode_L2Desc from production.lcodesdetail where mcode_id in ( 54, 55 )" & Environment.NewLine
                strsql &= " and DCode_SDesc = '" & strCosmeticGrade & "';"

                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetAllSNsForPallet(ByVal iPalletID As Integer, ByVal iDeviceID As Integer) As DataTable
            Try
                Dim strSQL As String = ""
                strSQL = "Select Device_ID, Device_SN, Loc_ID from tdevice where pallett_id = " & iPalletID.ToString & " and device_ID=" & iDeviceID


                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function NICloseSO_SendSparePart(ByVal iCustID As Integer, ByVal iSOHeaderID As Integer, _
                                ByVal iUserID As Integer, ByVal strShipCarrier As String, _
                                ByVal strTrackNo As String, ByVal decShippingCost As Decimal, ByVal iBillCode_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer, j As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strOrderNumber As String = ""

            Try
                'Ship qty in detail
                'Not correct: strSql = "SELECT A.SODetailsID, count(*) as FilledQty " & Environment.NewLine
                strSql = "SELECT A.SODetailsID, Quantity as FilledQty " & Environment.NewLine
                strSql &= "FROM saleorders.sodetails A " & Environment.NewLine
                strSql &= "WHERE A.SOHeaderID = " & iSOHeaderID & Environment.NewLine
                strSql &= "GROUP BY A.SODetailsID"
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    strSql = "UPDATE saleorders.sodetails " & Environment.NewLine
                    strSql &= "SET ShipQuantity = " & R1("FilledQty").ToString & Environment.NewLine
                    strSql &= "WHERE SODetailsID = " & R1("SODetailsID").ToString & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                strSql = "UPDATE saleorders.soheader " & Environment.NewLine
                strSql &= "SET ShipDate = now(), ShipUserID = " & iUserID & Environment.NewLine
                strSql &= ", ShipCarrier = '" & strShipCarrier & "', OutboundTrackingNumber = '" & strTrackNo & "', OrderShipmentCharge = " & decShippingCost & Environment.NewLine
                strSql &= ",BillCode_ID=" & iBillCode_ID & Environment.NewLine
                'strSql &= ", LaborCharge = " & dbLaborCharge & Environment.NewLine
                strSql &= "WHERE CUST_ID = " & iCustID & " And ShipDate Is null And InvalidOrder = 0 AND OrderStatusID = 1 " & Environment.NewLine
                strSql &= "AND SOHeaderID = " & iSOHeaderID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'Try to update table ExtendedWarranty, not very important, just change Status = 7 which means "Shipped"
                strSql = "SELECT CustomerOrderNumber from saleorders.soheader WHERE SOHeaderID = " & iSOHeaderID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strOrderNumber = dt.Rows(0).Item("CustomerOrderNumber")
                    strSql = "UPDATE ExtendedWarranty SET S_ID=7 WHERE ClaimNo='" & strOrderNumber & "' AND Cust_ID=" & iCustID
                    j = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                'error handler
                If i = 0 Then Throw New Exception("System has failed to close the order.")

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function


        '********************************************************************************
        Public Function getNICosmeticGrade_ToChange(ByVal iCust_ID As Integer, ByVal strSN As String, Optional ByVal bRefurbOnly As Boolean = False) As DataTable
            Dim strSQL As String = ""

            Try
                'strsql = "select C.NI_DataSwitch,A.device_ID,D.Device_ID as 'tDevice_ID',D.Device_SN,D.Device_DateShip,C.RepairType,A.Serial,E.Manuf_SN,A.DevConditionID,I.DCode_Ldesc as 'DevCondition'" & Environment.NewLine
                'strSQL &= " ,A.CosmGradeID,F.CosmGradeID as 'SODetails_CosmGradeID',E.InBoundCosmGrade,E.OutBoundCosmGradeID,H.DCode_Ldesc as 'OutBoundCosmGrade',A.SODetailsID,A.Model_ID,D.Model_ID as 'tModel_ID',A.SoftkeyCode" & Environment.NewLine
                'strSQL &= " ,B.WR_Name,B.Closed,B.Cust_ID,B.Loc_ID,B.RMA,B.WO_ID,C.WO_ID as 'EXTWRTY_WO_ID',D.Pallett_ID,A.WI_ID,A.WB_ID,A.WR_ID,E.WorkStation,E.CellOpt_TechAssigned,G.Pallett_Name" & Environment.NewLine
                'strsql &= " from warehouse.warehouse_Items A" & Environment.NewLine
                'strsql &= " Inner join warehouse.warehouse_Receipt B on A.WR_ID=B.WR_ID" & Environment.NewLine
                'strsql &= " left Join extendedwarranty C on B.WO_ID=C.WO_ID" & Environment.NewLine
                'strsql &= " left join tdevice D on A.Device_ID=D.Device_ID" & Environment.NewLine
                'strsql &= " left join tcellopt E on A.Device_ID=E.Device_ID and A.Device_ID=D.Device_ID" & Environment.NewLine
                'strsql &= " left join saleorders.SODetails F on A.SODetailsID=F.SODetailsID" & Environment.NewLine
                'strsql &= " left join tpallett G on D.pallett_ID=G.pallett_ID" & Environment.NewLine
                'strsql &= " left join lcodesdetail H on E.OutBoundCosmGradeID=H.Dcode_ID" & Environment.NewLine
                'strsql &= " left join lcodesdetail I on A.DevConditionID=I.Dcode_ID" & Environment.NewLine
                'strsql &= " where B.Cust_ID=" & iCust_ID & " and (D.Device_DateShip is null or length(trim(D.Device_DateShip))=0)" & Environment.NewLine
                'strsql &= " and E.OutBoundCosmGradeID>0 and D.Device_SN='" & strSN.Replace("'", "''") & "';" & Environment.NewLine

                strSQL = "select A.device_ID,A.Serial,A.DevConditionID,C.DCode_Ldesc as 'DevCondition'" & Environment.NewLine
                strSQL &= ",A.CosmGradeID,D.DCode_Ldesc as 'CosmGrade',A.SODetailsID,A.Model_ID" & Environment.NewLine
                strSQL &= ",B.WR_Name,B.Closed,B.Cust_ID,B.Loc_ID,B.RMA,B.WO_ID,A.WI_ID,A.WB_ID,A.WR_ID" & Environment.NewLine
                strSQL &= " from warehouse.warehouse_Items A" & Environment.NewLine
                strSQL &= " Inner join warehouse.warehouse_Receipt B on A.WR_ID=B.WR_ID" & Environment.NewLine
                strSQL &= " left join lcodesdetail C on A.DevConditionID=C.Dcode_ID" & Environment.NewLine
                strSQL &= " left join lcodesdetail D on A.CosmGradeID=D.Dcode_ID"
                strSQL &= " where B.Cust_ID = " & iCust_ID & " and A.Serial='" & strSN.Replace("'", "''") & "'" & Environment.NewLine

                If bRefurbOnly Then strSQL &= " and A.DevConditionID = 3857" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '********************************************************************************
        Public Function getNICosmeticGrade_SalesOrder(ByVal iCust_ID As Integer, ByVal iSODetailID As Integer) As DataTable
            Dim strSQL As String = ""

            Try

                strSQL = "select A.SOHeaderID,B.SODetailsID,A.ShipDate" & Environment.NewLine
                strSQL &= ",A.InvalidOrder,A.OrderStatusID,A.Cust_ID,A.PONumber,A.WorkOrderID as 'WO_ID'" & Environment.NewLine
                strSQL &= ",B.Quantity,B.ProductName,B.Model_ID,B.DevConditionID,B.CosmGradeID" & Environment.NewLine
                strSQL &= " from saleorders.soheader A" & Environment.NewLine
                strSQL &= " inner join saleorders.SODetails  B on A.SoHeaderID=B.SOHeaderID" & Environment.NewLine
                strSQL &= " where A.Cust_ID= " & iCust_ID & " and A.ShipDate is not null and A.InvalidOrder =0 and A.OrderStatusID=1 and B.SODetailsID=" & iSODetailID & ";" & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function getNIDevice_BySN(ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSQL As String = ""

            Try

                strSQL = "select * from tdevice where Loc_ID=" & iLoc_ID & " and Device_SN='" & strSN.Replace("'", "''") & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function getWarehouseRepairedData(ByVal iCust_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSQL As String = ""

            Try
                strSQL = "select A.*,B.Cust_ID,B.Loc_ID,B.RMA,B.WO_ID from warehouse.warehouse_items A" & Environment.NewLine
                strSQL &= " Inner join  warehouse.warehouse_receipt B on A.WR_ID=B.WR_ID" & Environment.NewLine
                strSQL &= "  where B.Cust_ID=" & iCust_ID & " And A.serial ='" & strSN.Replace("'", "''") & "' and A.DevConditionID=3857;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************
        Public Function getNIDeviceCellOpt(ByVal iDevice_ID As Integer) As DataTable
            Dim strSQL As String = ""

            Try

                strSQL = "select A.CellOpt_ID,A.WorkStation,A.InBoundCosmGrade,A.OutBoundCosmGradeID,B.DCode_Ldesc as 'OutBoundCosmGrade'" & Environment.NewLine
                strSQL &= " from tCellOpt A left join lcodesdetail B on A.OutBoundCosmGradeID=B.Dcode_ID where A.Device_ID=" & iDevice_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function UpdateNICosmeticGrade(ByVal iDevice_ID As Integer, ByVal iCosmGrade_ID As Integer, ByVal iWI_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0
            Try
                strsql = "Update tcellopt set OutBoundCosmGradeID=" & iCosmGrade_ID & " Where Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strsql)
                strsql = "Update warehouse.warehouse_Items set CosmGradeID =" & iCosmGrade_ID & " Where WI_ID=" & iWI_ID & ";" & Environment.NewLine
                i += Me._objDataProc.ExecuteNonQuery(strsql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
