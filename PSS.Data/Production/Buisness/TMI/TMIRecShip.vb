Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class TMIRecShip

        Private _objDataProc As DBQuery.DataProc
        Public Const _PSSI_ShippingMargin As Double = 0.08 'i.e., 8%
        Public Const _PSSI_ShippingSurcharge As Double = 8

        Public Enum FreightageResultException As Integer 'Result exception code 
            Not_Found_Effective_Date = -9001
            No_Available_Zone = -9002
            Invalid_Zone = -9003
            Invalid_Input_Zip_Code = -9004
            Invalid_Destination_Zip_Code = -9005
            Not_Found_Zone = -9006
            Duplicated_Zipcode_Found = -9007
            Not_Found_Freight_Rate = -9008
            Freight_Rate_Is_Null = -9009
        End Enum

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

#Region "Receiving"
        '***************************************************************************************************
        Public Function GetOpenRecWorkOrder(ByVal iLocID As Integer) As DataTable
            Dim objTMI As New TMI()
            Dim strSql As String = ""
            Dim dt, dtPrevRepDev As DataTable
            Dim drLastClaimNo() As DataRow
            Dim i, iPrevRepWOID As Integer

            Try
                strSql = "SELECT tworkorder.WO_ID, ClaimNo as 'Claim #', Cust2PSSI_TrackNo as TrackNo, Type, Brand as 'Manufacture', Model" & Environment.NewLine
                strSql &= ", ShipTo_name as 'Name', Address1, City, State_Long as 'State', ZipCode, Tel, Email" & Environment.NewLine
                strSql &= ", tmodel.Model_ID, lproduct.Prod_ID, lmanuf.Manuf_ID" & Environment.NewLine
                strSql &= ", IF(extendedwarranty.SerialNo is null , '', extendedwarranty.SerialNo) as 'EDI S/N'" & Environment.NewLine
                strSql &= ", IF( extendedwarranty.LastClaimNo is null, '', extendedwarranty.LastClaimNo) as LastClaimNo " & Environment.NewLine
                strSql &= ", '' as 'Prev Rep S/N', '' as 'Prev Rep Manuf S/N', '' as 'PrevRepDeviceID', '' as 'Prev Rep Receipt Date', '' as 'Prev Rep Ship Date' " & Environment.NewLine
                strSql &= ", '' as 'Prev Rep Model', 0 as PrevRepModelID, '' as 'Prev Rep Manufacture', 0 as PrevRepManufID, '' as 'Prev Rep Product Type', 0 as PrevRepProdID " & Environment.NewLine
                strSql &= ", tworkorder.WO_Quantity as Qty" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty On tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate On extendedwarranty.State_ID = lstate.State_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lmanuf ON extendedwarranty.Brand = lmanuf.Manuf_Desc" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lproduct ON extendedwarranty.Type = lproduct.Prod_Desc" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON extendedwarranty.Model = tmodel.model_Desc AND lproduct.Prod_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " AND WO_Closed = 0 and InvalidOrder = 0 AND tworkorder.WO_Shipped = 0 " & Environment.NewLine
                strSql &= "Group by tworkorder.WO_ID, ClaimNo "
                dt = Me._objDataProc.GetDataTable(strSql)

                drLastClaimNo = dt.Select("LastClaimNo <> ''")
                For i = 0 To drLastClaimNo.Length - 1
                    iPrevRepWOID = objTMI.GetWOID(drLastClaimNo(i)("LastClaimNo"))
                    If iPrevRepWOID > 0 Then
                        dtPrevRepDev = objTMI.GetDeviceSNsInWO(iPrevRepWOID)
                        If dtPrevRepDev.Rows.Count > 0 Then
                            drLastClaimNo(i).BeginEdit()
                            drLastClaimNo(i)("Prev Rep S/N") = dtPrevRepDev.Rows(0)("PSS S/N")
                            drLastClaimNo(i)("Prev Rep Manuf S/N") = dtPrevRepDev.Rows(0)("Manuf_SN")
                            drLastClaimNo(i)("PrevRepDeviceID") = dtPrevRepDev.Rows(0)("Device_ID")
                            drLastClaimNo(i)("Prev Rep Receipt Date") = dtPrevRepDev.Rows(0)("Device_DateRec")
                            'If IsDBNull(dtPrevRepDev.Rows(0)("Device_DateShip")) = True Then Throw New Exception("This device S/N """ & dtPrevRepDev.Rows(0)("PSS S/N") & """ still open in previous claim # """ & drLastClaimNo(i)("LastClaimNo") & """ is empty. Please contact your suppervisor.")
                            drLastClaimNo(i)("Prev Rep Ship Date") = dtPrevRepDev.Rows(0)("Device_DateShip")
                            drLastClaimNo(i)("Prev Rep Model") = dtPrevRepDev.Rows(0)("Model")
                            drLastClaimNo(i)("PrevRepModelID") = dtPrevRepDev.Rows(0)("Model_ID")
                            drLastClaimNo(i)("Prev Rep Manufacture") = dtPrevRepDev.Rows(0)("Manufacture")
                            drLastClaimNo(i)("PrevRepManufID") = dtPrevRepDev.Rows(0)("Manuf_ID")
                            drLastClaimNo(i)("Prev Rep Product Type") = dtPrevRepDev.Rows(0)("Product Type")
                            drLastClaimNo(i)("PrevRepProdID") = dtPrevRepDev.Rows(0)("Prod_ID")

                            drLastClaimNo(i).EndEdit()
                        Else
                            'Throw New Exception("Previous claim # """ & drLastClaimNo(i)("LastClaimNo") & """ is empty. Please contact your suppervisor.")
                        End If
                    Else
                        'Throw New Exception("Can't define PSS work order for previous claim # """ & drLastClaimNo(i)("LastClaimNo") & """. Please contact your suppervisor.")
                    End If
                Next i

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function ReceiveDeviceIntoWIP(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iModelID As Integer, _
                                             ByVal strManufSN As String, ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                             ByVal strUserName As String, ByVal iCCID As Integer, ByVal strWorkStation As String, _
                                             ByVal strPSSSN As String, ByVal iPSSWrty As Integer) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim iDeviceID, iCnt, i, iWipOwner, iManufWrty As Integer
            Dim strWrkDate, strMechanicalSN As String
            Dim objCreatePSSISNs As New CreatePSSISNs()

            Try
                iDeviceID = 0 : iCnt = 0 : i = 0 : iWipOwner = 1 : iManufWrty = 0
                : strMechanicalSN = ""
                strWrkDate = Generic.GetWorkDate(iShiftID)

                '********************************************
                'CREATE PSSI SERIAL
                '********************************************
                If strPSSSN.Trim.Length = 0 Then

                    If objCreatePSSISNs.IsLocked() Then Throw New Exception("Table was lock by another user. Please try again.")
                    objCreatePSSISNs.Lock(strUserName)

                    strPSSSN = objCreatePSSISNs.GetMostRecentlyCreatedSN()
                    If strPSSSN = "N/A" Then
                        strPSSSN = "P" & Convert.ToDateTime(strWrkDate).ToString("yyMMdd") & "001"
                    Else
                        strPSSSN = Microsoft.VisualBasic.Left(strPSSSN, strPSSSN.Length - 3) & (Convert.ToInt16(Microsoft.VisualBasic.Right(strPSSSN, 3)) + 1).ToString("000")
                    End If

                    objCreatePSSISNs.SaveSN(strPSSSN, iUserID)

                    objCreatePSSISNs.Unlock()
                End If
                '********************************************

                If strPSSSN.Trim.Length = 0 Then Throw New Exception("System has failed to create serial number (SN is blank).")

                objRec = New PSS.Data.Production.Receiving()

                'Create device
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strPSSSN, strWrkDate, iCnt, iTrayID, TMI.LOCID, iWOID, iModelID, iShiftID, iPSSWrty, iManufWrty, , iCCID, )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                'Create cellopt 
                If strMechanicalSN.Trim.Length = 0 Then strMechanicalSN = "NULL" 'DEFAULT VALUE
                i = objRec.InsertIntoTCellopt(iDeviceID, strMechanicalSN, , , , , , , , , , , , , , , strWorkStation, , iWipOwner, strManufSN)
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                Label_ReceiveBoxLabel(iDeviceID, 3) '2)

                Return iDeviceID

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
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

        '***************************************************************************************************
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
                '******************************
                'construct pallet name
                '******************************
                strDate = Generic.GetMySqlDateTime("%y%m%d")

                strPalletName = "TMI" + strDate & "N" & iWOID

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

        '*******************************************************************************************************************
        Public Function CloseAndShipBox(ByVal iPalletID As Integer, ByVal iWOID As Integer, _
                                        ByVal iShiftID As Integer, ByVal iBoxQty As Integer, _
                                        ByVal strNextStation As String, ByRef objShip As Production.Shipping, _
                                        ByVal iShipCarrierID As Integer, ByVal strTrackingNo As String) As Integer
            ', _
            '                                  ByVal iWeight As Integer, ByVal iFreightage As Double) As Integer
            Const iTMIStatusID As Integer = 7
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
                Dim strServiceBillcode, strTMIStatusDesc, strRepStatusCode As String
                Dim objSyxShip As New TMIRecShip()
                strServiceBillcode = "" : strTMIStatusDesc = "" : strRepStatusCode = ""
                strTMIStatusDesc = objSyxShip.GetTMIStatusDesc(iTMIStatusID)
                If strTMIStatusDesc.Trim.Length = 0 Then strTMIStatusDesc = "Shipped"

                strSql = "SELECT if (Billcode_Desc is null, '', Billcode_Desc) as ServiceCode, RepStatusCode" & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.billcode_ID AND BillType_ID = 1" & Environment.NewLine
                strSql &= "INNER JOIN tmi_repairstatuscode ON tdevicebill.billcode_ID = tmi_repairstatuscode.billcode_ID" & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Repair status code is missing. Please contact IT.")
                Else
                    strServiceBillcode = dt.Rows(0)("ServiceCode")
                    strRepStatusCode = dt.Rows(0)("RepStatusCode")
                End If
                If strServiceBillcode.Trim.Length > 0 Then strTMIStatusDesc = strServiceBillcode & " - " & strServiceBillcode
                objSyxShip = Nothing
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

                If objShip.GetReadyToShipCountByWO(iWOID) = 0 Then
                    strSql = "UPDATE tworkorder SET WO_Shipped = 1, WO_DateShip = '" & strWorkdate & "' WHERE WO_ID = " & iWOID & Environment.NewLine & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then Throw New Exception("System has failed to update shipping information in RMA.")
                End If

                strSql = "UPDATE extendedwarranty " & Environment.NewLine
                strSql &= " SET Final_SC_ID = " & iShipCarrierID & ", Final_PSSI2Cust_TrackNo = '" & strTrackingNo & "'" & Environment.NewLine
                strSql &= ", RepairStatusCode = '" & strRepStatusCode & "', PSSI_CurrentStatus = '" & strTMIStatusDesc & "' , S_ID = " & iTMIStatusID & Environment.NewLine
                'strSql &= ",Final_PSSI2Cust_ShipmentWeight=" & iWeight & ",Final_PSSI2Cust_ShipmentCost=" & iFreightage & Environment.NewLine
                strSql &= " WHERE WO_ID = " & iWOID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to update tracking information.")
                '******************************

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Sub PrintManifestLabel(ByVal iPalletID As Integer)
            Const strReportName As String = "TMI Shipping Manifest Push.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tworkorder.WO_CustWO as RMA, tworkorder.WO_ID, concat('*',tworkorder.WO_ID,'*') as WOIDBarcode " & Environment.NewLine
                strSql &= ", tpallett.Pallett_Name, tpallett.Pallett_ID, tdevice.Ship_ID " & Environment.NewLine
                strSql &= ", concat('*',tdevice.Ship_ID,'*') as ShipIDBarcode " & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as Model, tdevice.Device_sn as IMEI, Device_ManufWrty" & Environment.NewLine
                strSql &= ", Max(BillCode_Rule) as RepairStatus, 1 as ApprovedToRepair " & Environment.NewLine
                strSql &= ", IF(Device_ManufWrty = 1, 'IW', 'OW') as  WarrantyStatus" & Environment.NewLine
                strSql &= ", 0 as ShipTo_ID , extendedwarranty.ShipTo_Name as ToName" & Environment.NewLine
                strSql &= ", extendedwarranty.Address1 as ToAddress1" & Environment.NewLine
                strSql &= ", if(extendedwarranty.Address2 is null, '', extendedwarranty.Address2 ) as ToAddress2" & Environment.NewLine
                strSql &= ", extendedwarranty.City as ToCity" & Environment.NewLine
                strSql &= ", State_Short as ToState" & Environment.NewLine
                strSql &= ", extendedwarranty.ZipCode as ToZIP" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty ON tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON extendedwarranty.State_Id = lstate.State_Id" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID ;"
                dt = Me._objDataProc.GetDataTable(strSql)

                TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Public Function GetDataTableForPrintRepairLetter(ByVal iPalletID As Integer) As DataTable
            Const strReportName As String = "TMI Shipping Manifest Push.rpt"
            Dim strSql As String = ""

            Try
                strSql = "Select extendedwarranty.TMIServiceClient,extendedwarranty.ClaimNo, extendedwarranty.Shipto_Name," & Environment.NewLine
                strSql &= "tDevice.Device_ID,tDevice.device_SN,tDevice.WO_ID,tPallett.Pallett_ID,tPallett.Pallett_Name" & Environment.NewLine
                strSql &= " From tDevice" & Environment.NewLine
                strSql &= " Inner Join extendedwarranty On tDevice.WO_ID=extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= " Inner Join tPallett On tDevice.Pallett_ID=tPallett.Pallett_ID" & Environment.NewLine
                strSql &= " Where tPallett.Pallett_ID=" & iPalletID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Sub PrintTMIRepairLetter(ByVal strReportName As String)

            Try
                TracFone.clsMisc.PrintPlainCrystalReport(strReportName, 1, )
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************************
        Public Function UpdateExcptRepPartCharge(ByVal iDeviceID As Integer, ByVal decMarkup As Decimal, ByVal booCheckTechHrAndEstPartCost As Boolean) As Integer
            Dim strSql As String = ""
            Dim dbTotalPartCharge As Double = 0
            Dim dbTotalEstimatePartCharge As Double = 0
            Dim i As Integer = 0
            Dim dbTechRate As Double = 0
            Dim dbTechHrs As Double = 0
            Dim dt, dtTotalPartCharge As DataTable

            Try
                strSql = "SELECT PricePerHour FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN techprice ON tlocation.Cust_ID = techprice.Cust_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                dbTechRate = Me._objDataProc.GetDoubleValue(strSql)

                strSql = "SELECT Device_Laborcharge, extendedwarranty.* FROM tdevice INNER JOIN extendedwarranty ON tdevice.WO_ID = extendedwarranty.WO_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                dt = Me._objDataProc.GetDataTable(strSql)
                If booCheckTechHrAndEstPartCost Then
                    If dt.Rows.Count = 0 OrElse Convert.ToInt16(dt.Rows(0)("EstimatedTechHrs")) = 0 Then
                        Throw New Exception("Tech hour is missing.")
                    ElseIf Convert.ToDecimal(dt.Rows(0)("EstimatedPartCost")) = 0 Then
                        Throw New Exception("Estimated part cost is missing.")
                    End If
                End If

                If Not IsDBNull(dt.Rows(0)("EstimatedTechHrs")) Then dbTechHrs = Convert.ToDouble(dt.Rows(0)("EstimatedTechHrs"))

                'REMOVE MARKUP ON PART ESTIMATE COST. REQUESTED BY STEVE MULL 01/31/2013
                'If Not IsDBNull(dt.Rows(0)("EstimatedPartCost")) Then dbTotalEstimatePartCharge = Convert.ToDouble(dt.Rows(0)("EstimatedPartCost")) * (1 + decMarkup)
                If Not IsDBNull(dt.Rows(0)("EstimatedPartCost")) Then dbTotalEstimatePartCharge = Convert.ToDouble(dt.Rows(0)("EstimatedPartCost"))

                strSql = "UPDATE tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "SET DBill_InvoiceAmt = (" & (1 + decMarkup) & " * DBill_StdCost) " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND BillType_ID IN ( 2, 3 ) "
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "SELECT SUM( DBill_InvoiceAmt) as TotalPartCharge " & Environment.NewLine
                strSql &= "FROM tdevicebill WHERE tdevicebill.Device_ID = " & iDeviceID
                dtTotalPartCharge = Me._objDataProc.GetDataTable(strSql)
                If dtTotalPartCharge.Rows.Count > 0 AndAlso Not IsDBNull(dtTotalPartCharge.Rows(0)("TotalPartCharge")) Then dbTotalPartCharge = Convert.ToDouble(dtTotalPartCharge.Rows(0)("TotalPartCharge"))

                'Override total part charge with estimate part cost plus mark up
                If dbTotalEstimatePartCharge > dbTotalPartCharge Then dbTotalPartCharge = dbTotalEstimatePartCharge

                strSql = "UPDATE tdevice set Device_PartCharge = " & dbTotalPartCharge & Environment.NewLine
                strSql &= ", Device_Laborcharge = (Device_Laborcharge + " & (dbTechRate * dbTechHrs) & ") " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function UpdatePartChargeToZero(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE tdevice SET Device_PartCharge = 0 " & Environment.NewLine
                strSql &= "WHERE tdevice.device_ID = " & iDeviceID
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to reset part charge.")

                strSql = "UPDATE tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "SET DBill_InvoiceAmt = 0 " & Environment.NewLine
                strSql &= "WHERE tdevicebill.device_ID = " & iDeviceID & " AND BillType_ID IN ( 2, 3 ) "
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to reset part charge.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function UpdateTMIOrderCurrentStatus(ByVal iWOID As Integer, ByVal strStatus As String, _
                                                    ByVal booUpdateQuoteSubmittedDate As Boolean, ByVal iStatusID As Integer, _
                                                    ByVal strRepairStatusCode As String, ByVal dbTechHour As Double, _
                                                    ByVal dbEstimatedPrice As Double) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE extendedwarranty SET S_ID = " & iStatusID & ", PSSI_CurrentStatus = '" & strStatus & "' " & Environment.NewLine
                If booUpdateQuoteSubmittedDate = True Then strSql &= ", QuoteSubmittedDate = now(), EstimatedTechHrs = " & dbTechHour & ", EstimatedPrice = " & dbEstimatedPrice & Environment.NewLine
                If strRepairStatusCode.Trim.Length > 0 Then strSql &= ", RepairStatusCode = '" & strRepairStatusCode & "' "
                strSql &= "WHERE WO_ID = " & iWOID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetPartAccessoryBillcode(ByVal iProdID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lbillcodes WHERE Device_ID = " & iProdID & " AND BillType_ID IN ( 2, 3 )"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
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

            Try
                strSql = "SELECT count(*) as cnt FROM ttestdata WHERE Test_ID = 7 AND Device_ID = " & iDeviceID & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Shared Function GetTMIStatusDesc(ByVal iStatusID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT Description FROM tmi_Status WHERE S_ID = " & iStatusID & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        ''***************************************************************************************************
        'Public Function GetTMIRepStatusCode(ByVal iWOID As Integer) As String
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT RepStatusCode FROM tdevice " & Environment.NewLine
        '        strSql &= "INNER JOIN tdevicebill On tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
        '        strSql &= "INNER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN tmi_repairstatuscode ON tdevicebill.Billcode_ID = tmi_repairstatuscode.Billcode_ID " & Environment.NewLine
        '        strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
        '        Return Me._objDataProc.GetSingletonString(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '***************************************************************************************************
        Public Function GetQuoteSubmittedDate(ByVal iWOID As Integer) As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT IF(QuoteSubmittedDate is null, '', QuoteSubmittedDate) as QuoteSubmittedDate FROM extendedwarranty WHERE WO_ID = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetMaxAvailableFreightBoxWeight() As Integer
            Dim strSql As String = ""
            Dim db As DataTable

            Try
                strSql = "select max(weight) from lshipfedexrate;" & Environment.NewLine
                db = Me._objDataProc.GetDataTable(strSql)
                If db.Rows.Count > 0 Then
                    Return db.Rows(0).Item(0)
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetTMIZipCode(ByVal iWOID As Integer) As String
            Dim strSql As String = ""
            Dim db As DataTable

            Try
                strSql = "select EW_ID,Cust_ID,ClaimNo,WO_ID,ShipTo_Name,left(zipCode,5) as ZipCode" & Environment.NewLine
                strSql &= " from extendedwarranty where Cust_ID=2519 and WO_ID=" & iWOID & ";" & Environment.NewLine
                db = Me._objDataProc.GetDataTable(strSql)
                If db.Rows.Count > 0 Then
                    Return db.Rows(0).Item("ZipCode")
                Else
                    Return ""
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************************************************************
        Public Function GetTMICarrierID(ByVal iWOID As Integer) As String
            Dim strSql As String = ""
            Dim db As DataTable

            Try
                strSql = "select EW_ID,Cust_ID,ClaimNo,WO_ID,ShipTo_Name,SC_ID" & Environment.NewLine
                strSql &= " from extendedwarranty where Cust_ID=2519 and WO_ID=" & iWOID & ";" & Environment.NewLine
                db = Me._objDataProc.GetDataTable(strSql)
                If db.Rows.Count > 0 Then
                    Return db.Rows(0).Item("SC_ID")
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************************************************************
        Public Function UpdateTMIReceivedWeightFreightage(ByVal iWOID As Integer, ByVal iWeight As Integer, ByVal iFreightage As Double) As String
            Dim strSql As String = ""
            Dim db As DataTable

            Try
                strSql = "Update extendedwarranty " & Environment.NewLine
                strSql &= " set Cust2PSSI_ShipmentWeight=" & iWeight & "," & Environment.NewLine
                strSql &= " Cust2PSSI_ShipmentCost=" & iFreightage & Environment.NewLine
                strSql &= " where Cust_ID=2519 and WO_ID=" & iWOID & ";" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************************************************************
        'Public Function UpdateTMIShippedWeightFreightage(ByVal iWOID As Integer, ByVal iWeight As Integer, ByVal iFreightage As Double) As String
        '    Dim strSql As String = ""
        '    Dim db As DataTable

        '    Try
        '        strSql = "Update extendedwarranty " & Environment.NewLine
        '        strSql &= " set Final_PSSI2Cust_ShipmentWeight=" & iWeight & "," & iFreightage & Environment.NewLine
        '        strSql &= " Final_PSSI2Cust_ShipmentCost=" & iFreightage & Environment.NewLine
        '        strSql &= " where Cust_ID=2519 and WO_ID=" & iWOID & ";" & Environment.NewLine
        '        Return Me._objDataProc.ExecuteNonQuery(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '***************************************************************************************************
        Public Function GetTMIGroundZoneNumber(ByVal strZipCode As String) As Integer
            Dim strSql As String = ""
            Dim db As DataTable
            Dim tmpZone As String = "", iZone As Integer

            Try
                If Not (strZipCode.Trim.Length = 3 Or strZipCode.Trim.Length = 5) Then
                    Return FreightageResultException.Invalid_Input_Zip_Code
                End If

                strSql = "select lshipfedexzoneready.id,lshipfedexzone.fz_ID,lshipfedexzone.DestinationZip as OriginalDestinationZip,lshipfedexzoneready.DestinationZip," & Environment.NewLine
                strSql &= "lshipfedexzone.GroundZone,lshipfedexzone.Region,lshipfedexzone.Description,lshipfedexzone.Effectivedate from  lshipfedexzoneready" & Environment.NewLine
                strSql &= "inner join lshipfedexzone on lshipfedexzone.fz_ID= lshipfedexzoneready.FZ_ID" & Environment.NewLine
                strSql &= " Where lshipfedexzoneready.DestinationZip='" & strZipCode.Trim & "' or  lshipfedexzoneready.DestinationZip='" & strZipCode.Trim.Substring(0, 3) & "';"

                db = Me._objDataProc.GetDataTable(strSql)

                If db.Rows.Count > 0 Then
                    If db.Rows.Count > 1 Then
                        Return FreightageResultException.Duplicated_Zipcode_Found
                    Else
                        tmpZone = db.Rows(0).Item("GroundZone").ToString.Trim
                        If tmpZone = "NA" Then
                            Return FreightageResultException.No_Available_Zone
                        ElseIf tmpZone = "" Then
                            Return FreightageResultException.Not_Found_Zone
                        Else
                            If IsNumeric(tmpZone) Then
                                iZone = tmpZone
                                Return iZone
                            Else
                                Return FreightageResultException.Invalid_Zone
                            End If
                        End If
                    End If
                Else
                    Return FreightageResultException.Not_Found_Zone

                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function EnumValue2NameString(ByVal iEnum As Integer) As String
            Dim tmpStr As String
            Try
                tmpStr = [Enum].GetName(GetType(FreightageResultException), iEnum)
                If tmpStr.Length > 0 Then
                    Return tmpStr.Replace("_", " ")
                Else
                    Return "Error with FreightageResultException"
                End If
            Catch ex As Exception
                Return "Error with FreightageResultException: " & ex.Message
            End Try
        End Function

        '***************************************************************************************************
        Public Function getTMIGroundRate(ByVal iWeight As Integer, ByVal iZone As Integer, ByVal iSCID As Integer) As Double
            Dim strSQL As String
            Dim dTB As New DataTable(), dTB2 As New DataTable(), row As DataRow
            Dim myConnStr As String
            Dim schemaNameStr As String = "production"
            Dim tmpStr As String
            Dim resultFreightRate As Double = 0, tmpR As Double = 0

            Try
                strSQL = "desc lshipfedexrate;"
                dTB = Me._objDataProc.GetDataTable(strSQL)

                If dTB.Rows.Count > 0 Then
                    For Each row In dTB.Rows
                        tmpStr = row.Item("field")
                        If tmpStr = "Zone" & iZone.ToString Then
                            strSQL = "Select FR_ID," & tmpStr & " from lshipfedexrate " & Environment.NewLine
                            strSQL &= " where Weight=" & iWeight & " and SC_ID=" & iSCID & ";" & Environment.NewLine

                            dTB2 = Me._objDataProc.GetDataTable(strSQL)
                            '  MessageBox.Show(dTB2.Rows(0).Item("FR_ID") & "  " & dTB2.Rows(0).Item(tmpStr))
                            If IsNumeric(dTB2.Rows(0).Item(tmpStr)) Then
                                tmpR = dTB2.Rows(0).Item(tmpStr)
                                'resultFreightRate = (1 + Me._PSSI_ShippingMargin) * tmpR 'Freightage + 8% margin
                                'Return Math.Round(resultFreightRate, 2)
                                resultFreightRate = tmpR
                                Return resultFreightRate
                            Else
                                Return FreightageResultException.Freight_Rate_Is_Null
                            End If
                        End If
                    Next
                End If

                Return FreightageResultException.Not_Found_Freight_Rate

            Catch ex As Exception
                Throw ex
            Finally
                dTB = Nothing : dTB2 = Nothing
            End Try
        End Function

        '***************************************************************************************************
        Public Function UpdateTMIEstimatedPartCost(ByVal iWOID As Integer, ByVal dbPartCost As Double) As Integer
            Dim strSql As String = "'"
            Try
                strSql = "UPDATE production.extendedwarranty " & Environment.NewLine
                strSql &= "SET EstimatedPartCost = " & dbPartCost & ", EstimatedPartCost_Date = now() " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************

    End Class

End Namespace