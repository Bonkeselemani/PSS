Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports DBQuery.DataProc
Imports System.Windows.Forms

Namespace Buisness

    Public Class Pantech

        Private _objDataProc As DBQuery.DataProc
        Private strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
        Private strRptName As String = ""

#Region "Properties"
        '******************************************************************
        Public Shared ReadOnly Property Pantech_CUSTOMER_ID() As Integer
            Get
                Return 2453
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Pantech_LOC_ID() As Integer
            Get
                Return 3251
            End Get
        End Property
        '******************************************************************
       
        Public Shared ReadOnly Property Pantech_GROUPID() As Integer
            Get
                Return 92
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Pantech_SupportCCID() As Integer
            Get
                Return 68
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Pantech_PRODID() As Integer
            Get
                Return 2
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ManufID() As Integer
            Get
                Return 64
            End Get
        End Property
        '******************************************************************

#End Region

#Region "Constructor/Destructor"

        '*******************************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************************
#End Region

#Region "Receiving"

        '*******************************************************************************************************************
        Public Function CreateNewRMA(ByVal strRMANo As String, ByVal iShipToID As Integer, ByVal strCompany As String, _
                                     ByVal strFirstName As String, ByVal strLastName As String, _
                                      ByVal strAddress1 As String, ByVal strAddress2 As String, ByVal strCity As String, _
                                      ByVal iStatesID As Integer, ByVal strZipCode As String, ByVal iCountriesCodeID As Integer, _
                                      ByVal strPhoneNumber As String, ByVal strFaxNumber As String, ByVal strEmailAddress As String, _
                                      ByRef iTrayID As Integer, ByVal iUserID As Integer, ByVal strUserName As String) As Integer
            Dim strSql As String = ""
            Dim R1 As DataRow
            Dim objRec As PSS.Data.Production.Receiving
            Dim iWOID As Integer

            Try
                objRec = New PSS.Data.Production.Receiving()
                R1 = objRec.GetWorkorderInfo(strRMANo, , Me.Pantech_LOC_ID)
                If Not IsNothing(R1) Then
                    Throw New Exception("This RMA # is ready existed.")
                Else
                    iWOID = 0 : iTrayID = 0

                    If iShipToID = 0 Then
                        strCompany = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strFirstName).Replace("'", "")
                        strFirstName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strFirstName)
                        strLastName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strLastName)
                        strAddress1 = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strAddress1)
                        strAddress2 = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strAddress2)
                        strCity = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strCity)

                        'Create Shipto record
                        iShipToID = objRec.InsertIntoTShipTo(strCompany, strFirstName & " " & strLastName, strAddress1, strAddress2, strCity, iStatesID, strZipCode, iCountriesCodeID, strPhoneNumber, strFaxNumber, strEmailAddress, )
                        If iShipToID = 0 Then Throw New Exception("System has failed to create ship to address.")
                    End If

                    'Create WO 
                    iWOID = objRec.InsertIntoTworkorder(strRMANo, strRMANo, Me.Pantech_LOC_ID, Me.Pantech_PRODID, Me.Pantech_GROUPID, , iShipToID, , , , )
                    If iShipToID = 0 Then Throw New Exception("System has failed to create workorder.")

                    'Create tray 
                    iTrayID = objRec.InsertIntoTtray(iUserID, strUserName, iWOID, )
                    If iTrayID = 0 Then Throw New Exception("System has failed to create tray. Please contact IT.")

                    Return iWOID
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing : R1 = Nothing
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function ReceiveUnit(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iModelID As Integer, _
                                    ByVal strIMEI As String, ByVal strMechanicalSN As String, ByVal iUserID As Integer, ByVal iShiftID As Integer, _
                                    ByVal iManufWrty As Integer, ByVal iPASN_ID As Integer, ByVal strRMANo As String) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim objUWrtyPantech As UnderWarrantyNET1.Pantech
            Dim dt As DataTable
            Dim iDeviceID, iCnt, i, iWipOwner, iCalWrty As Integer
            Dim strWrkDate, strDateCode, strLastDateInWrty As String

            Try
                iDeviceID = 0 : iCnt = 0 : i = 0 : iWipOwner = 1
                strWrkDate = "" : strDateCode = ""
                strWrkDate = Generic.GetWorkDate(iShiftID)

                '***********************************************************************************
                'COMMENT THIS BECAUSE JIM DECIDE TO LET RECEIVER SELECT IW OR OW BASE ON THE FORM
                '*************************************************************
                'GET WARRANTY STATUS
                '*************************************************************
                If strMechanicalSN.Trim.Length > 4 Then
                    If strMechanicalSN.StartsWith("7") OrElse strMechanicalSN.StartsWith("8") OrElse strMechanicalSN.StartsWith("9") Then
                        'manufacture in 2008 or 2009
                        strDateCode = "0" & Microsoft.VisualBasic.Left(strMechanicalSN, 3)
                    Else
                        'manufacture after 2009
                        strDateCode = Microsoft.VisualBasic.Left(strMechanicalSN, 4)
                    End If

                    objUWrtyPantech = New UnderWarrantyNET1.Pantech(strDateCode, False, "")
                    Try
                        iCalWrty = 0 : iCalWrty = objUWrtyPantech.InWarranty()
                        strLastDateInWrty = objUWrtyPantech.GetLastDateInWarranty()
                        If iManufWrty <> iCalWrty Then
                            MessageBox.Show("S/N show " & IIf(iCalWrty = 1, "in warranty", "out of warranty") & ". Please verify your selection.", "Calculate Wrty Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return 0
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End If
                '''*************************************************************
                '''If iManufWrty = 0 Then iWipOwner = 6

                objRec = New PSS.Data.Production.Receiving()

                'Create device
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strIMEI, strWrkDate, iCnt, iTrayID, Me.Pantech_LOC_ID, iWOID, iModelID, iShiftID, , iManufWrty, , Me.Pantech_SupportCCID, )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                'Create cellopt 
                If strMechanicalSN.Trim.Length = 0 Then strMechanicalSN = "NULL" 'DEFAULT VALUE
                i = objRec.InsertIntoTCellopt(iDeviceID, strMechanicalSN, strIMEI, , , , strIMEI, , , strDateCode, , , , , , , , , iWipOwner)
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                'Update/insert pantechasn table
                i = UpdateInsertPantechASNTable(iPASN_ID, strIMEI, strRMANo, iDeviceID)
                If i = 0 Then Throw New Exception("System has failed to update pantechasn table.")

                Return iDeviceID

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing : Generic.DisposeDT(dt)
                objUWrtyPantech = Nothing
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetPantechASN(ByVal strRMANo As String, ByVal strIMEI As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM pantechasn WHERE RMA = '" & strRMANo & "' AND IMEI = '" & strIMEI & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdateInsertPantechASNTable(ByVal iPASN_ID As Integer, ByVal strIMEI As String, _
                                                    ByVal strRMANo As String, ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                If iPASN_ID > 0 Then
                    strSql = "UPDATE pantechasn SET Device_ID = " & iDeviceID & " WHERE PA_ID = " & iPASN_ID & Environment.NewLine
                Else
                    strSql = "INSERT INTO pantechasn ( " & Environment.NewLine
                    strSql &= " RMA " & Environment.NewLine
                    strSql &= ", IMEI " & Environment.NewLine
                    strSql &= ", Device_ID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strRMANo & "'" & Environment.NewLine
                    strSql &= ", '" & strIMEI & "'" & Environment.NewLine
                    strSql &= ", " & iDeviceID & Environment.NewLine
                    strSql &= ") ; " & Environment.NewLine
                End If
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdateCelloptSN(ByVal strSN As String, ByVal iDeviceID As Integer) As Integer
            Dim strSql, strDateCode As String
            Dim objUWrtyPantech As UnderWarrantyNET1.Pantech
            Dim iCalWrty As Integer = 0

            Try
                Try
                    strDateCode = Microsoft.VisualBasic.Left(strSN, 4)
                    objUWrtyPantech = New UnderWarrantyNET1.Pantech(strDateCode, False, "")
                    iCalWrty = 0 : iCalWrty = objUWrtyPantech.InWarranty()
                    If iCalWrty <> 1 Then
                        If MessageBox.Show("The S/N show this device is out of warranty but select in warranty. Would you like to continue with your selection?", "Date Code Cal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Return 0
                        End If
                    End If
                Catch ex As Exception
                End Try

                strSql = "update tcellopt set CellOpt_MSN = '" & strSN & "' where device_id = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objUWrtyPantech = Nothing
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetCelloptSN(ByVal iDeviceID As Integer) As String
            Dim strSql As String

            Try
                strSql = "select CellOpt_MSN from  tcellopt where device_id = " & iDeviceID
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
#End Region

#Region "Shipping"

        '*******************************************************************************************************************
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
                strDate = Generic.GetMySqlDateTime("%y%m%d%H%i%s")

                strPalletName = "PT" + strDate & "N" & iWOID

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
                Throw New Exception("Buisness.Pantech.ReceivingAndShipping.CreateBoxID: " & ex.Message)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function CloseAndShipBox(ByVal iPalletID As Integer, ByVal iWOID As Integer, _
                                        ByVal iShiftID As Integer, ByVal iBoxQty As Integer, _
                                        ByVal iShipToID As Integer, ByRef objShip As Production.Shipping) As Integer
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
                '****************************************************************************
                ''Step 2:: Create Overpack
                '****************************************************************************
                iOverpack_ID = objBulkship.CreateOverPack(strWorkdate)
                '****************************************************************************
                ''Step 3:: Create Masterpack
                '****************************************************************************
                iShip_ID = objBulkship.CreateMasterPack(iOverpack_ID, iPalletID, iProdID, iShipToID)
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
                strSql &= "WHERE tdevice.Pallett_ID = tpallett.Pallett_ID AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Pallett_ID = " & iPalletID & " AND tdevice.WO_ID = " & iWOID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to update shipping information.")

                If objShip.GetReadyToShipCountByWO(iWOID) = 0 Then
                    strSql = "UPDATE tworkorder SET WO_Shipped = 1, WO_DateShip = '" & strWorkdate & "' WHERE WO_ID = " & iWOID & Environment.NewLine & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then Throw New Exception("System has failed to update shipping information in RMA.")
                End If

                '******************************
                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Pantech.ReceivingAndShipping.CreateBoxID: " & ex.Message)
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtProdID)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Sub PrintManifestLabel(ByVal iPalletID As Integer)
            Const strReportName As String = "Pantech Shipping Manifest Push.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tworkorder.WO_CustWO as RMA, tworkorder.WO_ID, concat('*',tworkorder.WO_ID,'*') as WOIDBarcode " & Environment.NewLine
                strSql &= ", tpallett.Pallett_Name, tpallett.Pallett_ID, tdevice.Ship_ID " & Environment.NewLine
                strSql &= ", concat('*',tdevice.Ship_ID,'*') as ShipIDBarcode " & Environment.NewLine
                strSql &= ", tmodel.Model_Desc as Model, tdevice.Device_sn as IMEI, Device_ManufWrty" & Environment.NewLine
                strSql &= ", Max(BillCode_Rule) as RepairStatus, ApprovedToRepair " & Environment.NewLine
                strSql &= ", IF(Device_ManufWrty = 1, 'IW', 'OW') as  WarrantyStatus" & Environment.NewLine
                strSql &= ", tshipto.ShipTo_ID , ShipTo_Name as ToName, ShipTo_Address1 as ToAddress1, ShipTo_Address2 as ToAddress2" & Environment.NewLine
                strSql &= ", ShipTo_City as ToCity, State_Short as ToState, ShipTo_Zip as ToZIP" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_Id" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID ;"
                dt = Me._objDataProc.GetDataTable(strSql)

                TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************

#End Region

#Region "Customer Service"

        '*******************************************************************************************************************
        Public Function GetApprovedUnits(ByVal iLocID As Integer, ByVal strApprovedStartDate As String, ByVal strApprovedEndDate As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tworkorder.WO_CustWO as RMA, tmodel.Model_Desc as Model, tdevice.Device_sn as IMEI" & Environment.NewLine
                strSql &= ", IF(Device_ManufWrty = 1, 'Yes', 'No') as  'In Warranty?' " & Environment.NewLine
                strSql &= ", Device_Laborcharge as 'Labor Charge', sum(DBill_InvoiceAmt) as 'Part Charge' " & Environment.NewLine
                strSql &= ", ApprovedToRepairDate as 'Approved Date', User_FullName as 'Approved By'" & Environment.NewLine
                strSql &= ", if(Device_Invoice = 1, 'Yes', 'No') as 'Invoiced?' " & Environment.NewLine
                strSql &= ", ShipTo_Name as ToName, ShipTo_Address1 as ToAddress1, ShipTo_Address2 as ToAddress2 " & Environment.NewLine
                strSql &= ", ShipTo_City as ToCity, State_Short as ToState, ShipTo_Zip as ToZIP" & Environment.NewLine
                strSql &= "FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_Id" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN security.tusers ON pantechasn.ApprovedToRepairBy = security.tusers.user_id" & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & " AND Device_ManufWrty = 0 " & Environment.NewLine
                strSql &= "AND pantechasn.ApprovedToRepairDate Between '" & strApprovedStartDate & " 00:00:00' AND '" & strApprovedEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID " & Environment.NewLine
                strSql &= "ORDER BY RMA;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetHoldUnits(ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tworkorder.WO_CustWO as RMA, tmodel.Model_Desc as Model, tdevice.Device_sn as IMEI" & Environment.NewLine
                strSql &= ", IF(Device_ManufWrty = 1, 'Yes', 'No') as  'In Warranty?' " & Environment.NewLine
                strSql &= ", Device_Laborcharge as 'Labor Charge', sum(DBill_InvoiceAmt) as 'Part Charge'" & Environment.NewLine
                strSql &= ", ShipTo_Name as ToName, ShipTo_Address1 as ToAddress1, ShipTo_Address2 as ToAddress2 " & Environment.NewLine
                strSql &= ", ShipTo_City as ToCity, State_Short as ToState, ShipTo_Zip as ToZIP" & Environment.NewLine
                strSql &= "FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_Id" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & " AND Device_DateShip is null AND Device_ManufWrty = 0 " & Environment.NewLine
                strSql &= "AND pantechasn.ApprovedToRepairDate is null " & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID  " & Environment.NewLine
                strSql &= "ORDER BY RMA;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOWApprovedData(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT ApprovedToRepairDate, ApprovedToRepairBy, ApprovedToRepair " & Environment.NewLine
                strSql &= ", tcellopt.CellOpt_RefurbCompleteDt, tcellopt.CellOpt_RefurbCompleteUserID, tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                strSql &= "FROM pantechasn" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON pantechasn.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE pantechasn.Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetRepairConfirmationData(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Device_ID, tdevice.Device_DateBill, ApprovedToRepairDate, ApprovedToRepairBy, ApprovedToRepair " & Environment.NewLine
                strSql &= ", CellOpt_RefurbCompleteDt " & Environment.NewLine
                strSql &= "FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= "WHERE tdevice.WO_ID = " & iWOID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function SetApproveToRepairData(ByVal iDeviceID As Integer, ByVal iUpdateWOID As Integer, ByVal iUserID As Integer, ByVal iApprovedToRep As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE pantechasn, tdevice SET ApprovedToRepairDate = now(), ApprovedToRepairBy = " & iUserID & " , ApprovedToRepair = " & iApprovedToRep & " , Device_Invoice = 1" & Environment.NewLine
                strSql &= "WHERE pantechasn.Device_ID = tdevice.Device_ID "
                If iUpdateWOID > 0 Then strSql &= "AND tdevice.WO_ID = " & iUpdateWOID & " AND ApprovedToRepairDate is null " & Environment.NewLine Else strSql &= "AND tdevice.Device_ID  = " & iDeviceID

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function PrintInvoiceReceiptData(ByVal iWOID As Integer) As Integer
            Const strReportName As String = "Pantech Invoice Receipt Push.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT 'Pantech OW Invoice Receipt' AS 'ReportName'" & Environment.NewLine
                strSql &= ", if (BillType_ID = 1, '', BillCode_Desc) as BillCode_Desc " & Environment.NewLine
                strSql &= ", tdevice.Device_ID, Device_SN, Device_OldSN" & Environment.NewLine
                strSql &= ", Device_ManufWrty, Device_PSSWrty, Device_LaborCharge, tdevice.Ship_ID, tworkorder.WO_ID, WO_CustWO" & Environment.NewLine
                strSql &= ", DBill_InvoiceAmt, tdevicebill.BillCode_ID, BillCode_Rule, Model_Desc, ApprovedToRepair, RUR_ReturnToCust" & Environment.NewLine
                strSql &= ", tworkorder.PO_ID AS 'BillingPOID', tworkorder.ShipTo_ID, shipTo_Name as 'ToName', ShipTo_Address1 as 'ToAddress1'" & Environment.NewLine
                strSql &= ", ShipTo_Address2 AS 'ToAddress2', ShipTo_City AS ToCity, lstate.State_Short AS ToState, ShipTo_Zip AS ToZIP " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tworkorder.WO_ID = tdevice.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.Shipto_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_ID = lstate.State_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID, BillCode_Desc" & Environment.NewLine
                strSql &= "ORDER BY Device_SN;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetPantechWOInfo(ByVal strWONo As String, ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_CustWO = '" & strWONo & "' AND Loc_ID = " & iLocID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetWaitingToBeDockShipRMA(ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT tworkorder.WO_CustWO as RMA , Count(*) as Qty  " & Environment.NewLine
                strSql &= ", tpallett.Pallett_Name AS 'Box Name', WO_DateShip as 'Produced Date' " & Environment.NewLine
                strSql &= ", ShipTo_Name as ToName, ShipTo_Address1 as ToAddress1, ShipTo_Address2 as ToAddress2" & Environment.NewLine
                strSql &= ", ShipTo_City as ToCity, State_Short as ToState, ShipTo_Zip as ToZIP" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_Id" & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND tworkorder.WO_Shipped = 1 AND tworkorder.WO_DateShip is not null AND tship.TrackingNo is null " & Environment.NewLine
                strSql &= "GROUP BY tdevice.WO_ID, tdevice.Pallett_ID ;"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************

#End Region

#Region "Label"

        Public Function Label_GetDeviceInfo(ByVal strIMEI As String, _
                                                      ByVal iCustID As Integer) As DataTable

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '*******************************************************
                'Get Device_ID from tdevice table
                '*******************************************************

                strsql = "select a.device_id, a.model_id, b.Manuf_ID, label_model_numb, label_model_numb2, label_fcc " & Environment.NewLine
                strsql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                strsql &= ", cellopt_msn, cellopt_CSN, cellopt_sugin, cellopt_softverin" & Environment.NewLine
                strsql &= ", label_misc1 as SKU, label_misc2 as HW " & Environment.NewLine
                strsql &= "from tdevice a  " & Environment.NewLine
                strsql &= "inner join tmodel b on a.model_id = b.model_id " & Environment.NewLine
                strsql &= "left outer join llabel c on c.model_id = b.model_id " & Environment.NewLine
                strsql &= "inner join tlocation d on a.loc_id = d.loc_id " & Environment.NewLine
                strsql &= "left outer join tcellopt e ON a.Device_ID = e.Device_ID " & Environment.NewLine
                strsql &= "where device_sn = '" & strIMEI & "' " & Environment.NewLine
                strsql &= "AND Device_DateShip is null  " & Environment.NewLine
                strsql &= "AND d.Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "order by device_id desc;"

                dt1 = _objDataProc.GetDataTable(strsql)

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Function

        Public Function Label_GetManufCountry(ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lmanufcountry where mc_active = 1 ORDER BY mc_id;"
                dt = _objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function Label_PrintLabel(ByVal strModel As String, _
                                           ByVal strIMEI As String, _
                                           ByVal strFCC As String, _
                                           ByVal strSNMSN As String, _
                                           ByVal strESN As String, _
                                           ByVal strMadein As String, _
                                           Optional ByVal strProdCode As String = "", _
                                           Optional ByVal strSjug As String = "", _
                                           Optional ByVal strPno As String = "", _
                                           Optional ByVal strTFModel As String = "", _
                                           Optional ByVal strSW As String = "", _
                                           Optional ByVal strbtAddr As String = "", _
                                           Optional ByVal strHW As String = "", _
                                           Optional ByVal strN As String = "", _
                                           Optional ByVal strDate As String = "", _
                                           Optional ByVal strManufProdSN As String = "", _
                                           Optional ByVal strSeq As String = "") As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable
            Dim dt1 As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim R1 As DataRow

            Try

                strsql = "Select Label_Name from lcustmodlbl a " & Environment.NewLine
                strsql &= "Inner Join tdevice b on b.model_id = a.model_id " & Environment.NewLine
                strsql &= "where device_sn = '" & strIMEI & "'; "

                dt1 = _objDataProc.GetDataTable(strsql)
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Report Name could not be determined. Label for this Model and Customer may not be setup." & Environment.NewLine & "Please contact IT immediately for further assistance.")
                End If

                For Each R1 In dt1.Rows      'Take the first row and move on
                    strRptName = Trim(R1("Label_Name"))
                    Exit For
                Next R1

                strsql = "Select '" & strModel & "' AS Model_No, '" & strIMEI & "' AS IMEI, '" & strFCC & "' AS FCCID, " & Environment.NewLine
                strsql &= " '" & strSNMSN & "' AS SNMSN, '" & strESN & "' as ESN, '" & strMadein & "' AS Country_Manuf, '" & strProdCode & "' AS Prod_Code, '" & strSjug & "' AS SugNumber, " & Environment.NewLine
                strsql &= " '" & strIMEI & "' AS IMEIBar, '" & strSNMSN & "' AS SNMSNBar, '" & strPno & "' AS P_NoBar, " & Environment.NewLine
                strsql &= " '" & strPno & "' AS P_No, '" & strTFModel & "' AS TFModel_No, '" & strSW & "' AS SW_No, " & Environment.NewLine
                strsql &= " '" & strbtAddr & "' As BtAddr, '" & strDate & "' as Date, '" & strHW & "' As HW_REV, '" & strN & "' As N_No " & Environment.NewLine
                strsql &= ", '" & strManufProdSN & "' as 'ManufProdSN' " & Environment.NewLine
                strsql &= ", '" & strSeq & "' as 'SEQ' " & Environment.NewLine
                strsql &= "from tdevice limit 1;"

                objRpt = New ReportDocument()

                With objRpt
                    .Load(strRptPath & strRptName)
                    dt = _objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(1, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Public Function Label_UpdateSNMSN_Tcell(ByVal iDeviceID As Integer, _
                                         ByVal strSNMSN As String)

            Dim strSql As String = ""

            Try
                strSql = "UPDATE tcellopt " & Environment.NewLine
                strSql &= "SET cellopt_msn = '" & strSNMSN.ToUpper & "' " & Environment.NewLine
                strSql &= "WHERE tcellopt.device_id = " & iDeviceID & ";"
                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Admin"

        '*******************************************************************************************************************
        Public Function GetPantechCustomers(ByVal booAddSelectRow As Boolean) As DataTable

            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT tcustomer.Cust_ID, Concat(tcustomer.Cust_Name1, ' ', if(tcustomer.Cust_Name2 is null, '', tcustomer.Cust_Name2)) as Cust_Name1 " & Environment.NewLine
                strSql += "FROM tcustomer INNER JOIN tcusttoprice on tcustomer.cust_id = tcusttoprice.cust_id " & Environment.NewLine
                strSql += "INNER JOIN tlaborprc ON tcusttoprice.PrcGroup_ID = tlaborprc.PrcGroup_ID" & Environment.NewLine
                strSql += "INNER JOIN tmodel ON tlaborprc.ProdGrp_ID = tmodel.Model_Tier AND Manuf_ID = 64 " & Environment.NewLine
                strSql += "WHERE Cust_Inactive = 0 " & Environment.NewLine
                strSql += "order by cust_name1;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************

#End Region

#Region "OOW Override"

        '*******************************************************************************************************************
        Public Function GetPantechSNInfoInWIP(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.*, CellOpt_MSN  " & Environment.NewLine
                strSql += "FROM tdevice INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                'strSql += "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql += "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql += "WHERE Device_SN = '" & strSN & "' AND Device_DateShip is null AND Manuf_ID = 64 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdateWrtyStatus(ByVal iDeviceID As Integer, ByVal strCelloptMSN As String, ByVal iWrtyStatus As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tdevice, pantechasn " & Environment.NewLine
                If strCelloptMSN.Trim.Length > 0 Then strSql += ", tcellopt  " & Environment.NewLine
                strSql += "SET Device_ManufWrty = " & iWrtyStatus & Environment.NewLine
                strSql += ", OOWOverrideSetUpdDate = now(), OOWOverrideUpdUsr = " & iUserID & ", OOWOverrideFlag = 1" & Environment.NewLine
                If strCelloptMSN.Trim.Length > 0 Then strSql += ", CellOpt_MSN = '" & strCelloptMSN & "' " & Environment.NewLine
                strSql += "WHERE tdevice.Device_ID = pantechasn.Device_ID " & Environment.NewLine
                If strCelloptMSN.Trim.Length > 0 Then strSql += "AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql += "AND tdevice.Device_ID = " & iDeviceID & " AND Device_DateShip is null " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
#End Region

#Region "ChangeShipTypeTrackingNumber"
        Public Function GetShipTypes() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT ShipTypeID, ShipType" & Environment.NewLine
                strSQL &= "FROM production.shiptypes" & Environment.NewLine
                strSQL &= "UNION" & Environment.NewLine
                strSQL &= "SELECT 0 AS ShipTypeID, '--- SELECT ---' AS ShipType" & Environment.NewLine
                strSQL &= "FROM production.shiptypes" & Environment.NewLine
                strSQL &= "ORDER BY ShipType"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub UpdateShipTypeTrackingNumber(ByVal iShipIDs As Integer(), ByVal iShipTypeID As Integer, ByVal decShippingCost As Decimal, ByVal strTrackingNumber As String, ByVal iUserID As Integer)
            Dim strSQL As String

            Try
                Dim iCount As Integer = iShipIDs.Length
                Dim decIndividualShippingCost As Decimal = decShippingCost / Convert.ToDecimal(iCount)
                Dim iShipID As Integer

                For Each iShipID In iShipIDs
                    strSQL = "UPDATE production.tship" & Environment.NewLine
                    strSQL &= String.Format("SET TrackingNo = '{0}', ShipmentCost = {1:#0.00}, ShipTypeID = {2}, UpdateTrackingNumberUserID = {3}, UpdateTrackingNumberDate = NOW()", strTrackingNumber, decIndividualShippingCost, iShipTypeID, iUserID) & Environment.NewLine
                    strSQL &= String.Format("WHERE Ship_ID = {0}", iShipID)

                    Me._objDataProc.ExecuteNonQuery(strSQL)
                Next iShipID
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function IsValidShipID(ByVal iShipID As Integer) As Boolean
            Try
                Dim strSQL As String

                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tship" & Environment.NewLine
                strSQL &= String.Format("WHERE ship_id = {0}", iShipID)

                Return IIf(Me._objDataProc.GetIntValue(strSQL) > 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function HasTrackingNumber(ByVal iShipID As Integer) As Boolean
            Try
                Dim strSQL As String

                strSQL = "SELECT TrackingNo" & Environment.NewLine
                strSQL &= "FROM production.tship" & Environment.NewLine
                strSQL &= String.Format("WHERE ship_id = {0}", iShipID)

                Return IIf(Me._objDataProc.GetSingletonString(strSQL).Length > 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetCustomers() As DataTable
            Try
                Dim strSQL As String

                strSQL = "SELECT DISTINCT cust_id, cust_name1 AS Customer" & Environment.NewLine
                strSQL &= "FROM production.tcustomer" & Environment.NewLine
                strSQL &= "WHERE Cust_Inactive = 0 AND Cust_Name1 IS NOT NULL AND Cust_Name2 IS NULL" & Environment.NewLine
                strSQL &= "UNION" & Environment.NewLine
                strSQL &= "SELECT 0 AS cust_id, '--- SELECT ---' AS Customer" & Environment.NewLine
                strSQL &= "FROM production.tcustomer" & Environment.NewLine
                strSQL &= "ORDER BY Customer"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CheckShipIDToCustomerID(ByVal iShipID As Integer, ByVal iCustomerID As Integer) As Boolean
            Try
                Dim strSQL As String

                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSQL &= "INNER JOIN production.tship C ON A.Ship_ID = C.Ship_ID" & Environment.NewLine
                strSQL &= String.Format("WHERE C.Ship_ID = {0} AND B.Cust_ID = {1}", iShipID, iCustomerID)

                Return IIf(Me._objDataProc.GetIntValue(strSQL) > 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region 'ChangeShipTypeTrackingNumber


    End Class
End Namespace