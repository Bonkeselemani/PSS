'Imports CrystalDecisions.CrystalReports.Engine
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data.Production
'Imports System.Windows.Forms

'Namespace Buisness

'    Public Class MessagingBilling
'        Private _objMisc As Production.Misc
'        Private _objTray As Tray = Nothing

'        Public Sub New(ByVal iDeviceID As Integer, ByVal iTechID As Integer, ByVal strIDShift As String, _
'            ByVal strWorkDate As String, ByVal strReportPath As String, ByVal strUserFullName As String, ByVal strFormattedDate As String)
'            Me._objMisc = New Production.Misc()
'            Me._objTray = New Tray(iTechID, Me._objMisc)
'        End Sub

'        Public Sub New()
'            Me._objMisc = New Production.Misc()
'            Me._objTray = New Tray(0, Me._objMisc)
'        End Sub

'#Region "Tray Calls"
'        Public Function GetDeviceTableName()
'            Return Me._objTray.DeviceTableName
'        End Function

'        Public Function GetTrayTableName()
'            Return Me._objTray.TrayTableName
'        End Function

'        Public Function GetMiscTableName()
'            Return Me._objTray.MiscTableName
'        End Function

'        Public Sub SetupTrayDataSet(ByVal strTrayID As String, ByVal drSetup As DataRow)
'            Me._objTray.SetupTrayDataByID(strTrayID, drSetup)
'        End Sub

'        Public Function GetDeviceTrayData() As DataTable
'            Return Me._objTray.GetDeviceTrayData()
'        End Function

'        Public Function GetAllTrayData() As DataSet
'            Return Me._objTray.GetAllTrayData()
'        End Function

'        Public Sub AddPart(ByVal iDeviceID As Integer, ByVal iBillCode As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String)
'            Me._objTray.AddPart(iDeviceID, iBillCode, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate)
'        End Sub

'        'Public Sub SetDeviceID(ByVal iDeviceID)
'        '    Me._objTray.DeviceID = iDeviceID
'        'End Sub

'        Public Function DeletePart(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String) As DataSet
'            Return Me._objTray.DeletePart(iDeviceID, iBillCodeID, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate)
'        End Function

'        Public Function DeleteAllParts(ByVal iDeviceID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String) As DataSet
'            Return Me._objTray.DeleteAllParts(iDeviceID, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate)
'        End Function

'        Public Sub Print(ByVal strTray As String, ByVal strReportPath As String)
'            Me._objTray.Print(strTray, strReportPath)
'        End Sub

'        Public Sub Print(ByVal iDeviceID As Integer, ByVal strReportPath As String)
'            Me._objTray.Print(iDeviceID, strReportPath)
'        End Sub

'        Public Sub UpdateDevice(ByVal iDeviceID As Integer)
'            Me._objTray.Update(iDeviceID)
'        End Sub

'        Public Function GetCustomerID(ByVal iDeviceID As Integer) As Integer
'            Return Me._objTray.GetCustomerID(iDeviceID)
'        End Function

'        Public Function IsEndUser() As Boolean
'            Return Me._objTray.EndUser
'        End Function

'        Public Function UpdateFinalBillingUserID(ByVal iDeviceID As Integer, ByVal iBillerID As Integer) As Integer
'            Return Me._objTray.UpdateFinalBillingUserID(iDeviceID, iBillerID)
'        End Function
'#End Region

'#Region "Device Calls"
'        'Public Sub SetupDevice(ByVal dtDeviceSetupData As DataTable)
'        '    If Not IsNothing(Me._objDevice) Then
'        '        Me._objDevice.Dispose()
'        '        Me._objDevice = Nothing
'        '    End If

'        '    Me._objDevice = New Device(dtDeviceSetupData, Me._objMisc)
'        'End Sub

'        'Public Function GetDeviceID() As Integer
'        '    Return Me._objDevice.DeviceID
'        'End Function

'        'Public Function GetDeviceIDFromSN(ByVal strSN As String) As Integer
'        '    Dim strSQL As String
'        '    Dim strResult As String = ""
'        '    Dim iDeviceID As Integer = 0
'        '    Dim sf As New StackFrame(0)

'        '    Try
'        '        strSQL = "SELECT Device_ID " & Environment.NewLine
'        '        strSQL &= "FROM tdevice " & Environment.NewLine
'        '        strSQL &= "WHERE Device_SN = '" & strSN & "'"

'        '        strResult = Me._objMisc.GetSingletonString(strSQL)

'        '        If strResult.Length > 0 Then iDeviceID = CInt(strResult)

'        '        Return iDeviceID
'        '    Catch ex As Exception
'        '        Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'        '    End Try
'        'End Function

'        ''Public Sub AddPart(ByVal iBillCode As Integer)
'        ''    Me._objDevice.AddPart(iBillCode)
'        ''End Sub

'        ''Public Sub DeletePart(ByVal iBillCodeID As Integer, ByRef dsTray As DataSet)
'        ''    Me._objDevice.DeletePart(iBillCodeID, dsTray)
'        ''End Sub

'        ''Public Sub DeleteAllParts(ByRef dsTray As DataSet)
'        ''    Me._objDevice.DeleteAllParts(dsTray)
'        ''End Sub

'        ''Public Sub UpdateDevice()
'        ''    Me._objDevice.Update()
'        ''End Sub

'        ''Public Sub Print(ByVal iTray As Integer)
'        ''    Me._objDevice.Print(iTray)
'        ''End Sub

'        ''Public Sub Print()
'        ''    Me._objDevice.Print()
'        ''End Sub

'        ''Public Sub DisposeDevice()
'        ''    Me._objDevice.Dispose()
'        ''    Me._objDevice = Nothing
'        ''End Sub
'#End Region

'        Public Function VerifyCreditCardUser(ByVal strTrayText As String) As Boolean
'            Dim bVerifyCreditCardUser As Boolean = True
'            Dim strSQL As String
'            Dim strPayID As String
'            Dim strPWAuth As String
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL = "SELECT C.Pay_ID AS Pay_ID " & Environment.NewLine
'                strSQL &= "FROM tdevice A " & Environment.NewLine
'                strSQL &= "INNER JOIN tlocation B ON B.loc_id = A.loc_id " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustomer C ON C.cust_id = B.cust_id " & Environment.NewLine
'                strSQL &= "WHERE A.tray_id = " & strTrayText.Trim

'                strPayID = Me._objMisc.GetSingletonString(strSQL)

'                If strPayID.Length > 0 Then
'                    If CInt(strPayID) = 2 Then
'                        strPWAuth = InputBox("Please enter Credit Card Password Authentication:", "Password")
'                        strPWAuth = strPWAuth.Trim.ToUpper

'                        If strPWAuth <> "AE4V3" Then
'                            bVerifyCreditCardUser = False
'                            MsgBox("You do not have permission to bill a Credit Card Customer. Please forward this to Crystal Few.", MsgBoxStyle.Critical)
'                        End If
'                    End If
'                End If

'                Return bVerifyCreditCardUser
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function

'        Public Sub DisplayMessage(ByVal objMethod As System.Reflection.MethodBase, ByVal strMsg As String, Optional ByVal bIsErrMsg As Boolean = True)
'            Me._objMisc.DisplayMessage(objMethod, strMsg, bIsErrMsg)
'        End Sub

'#Region "Tray Class"
'        Private Class Tray
'            Private Const _strDeviceTrayDataSetName = "Devices and Parts Data"
'            Private Const _strOtherDataSetName = "Other Data"
'            Private Const _strDeviceTableName = "Device Data"
'            Private Const _strTrayTableName = "Tray Data"
'            Private Const _strBilledTableName = "Billed Data"
'            Private Const _strDeviceDetailsTableName = "Device Details Data"
'            Private Const _strLaborTableName = "Labor Data"
'            Private Const _strBillableTableName = "Billable Data"
'            Private Const _strExceptionCodeTableName = "Exception Code Data"
'            Private Const _strExceptionBillItemsTableName = "Exception Bill Items Data"
'            Private Const _strLookupCodesTableName = "Lookup Codes Data"
'            Private Const _strMiscTableName = "Miscellaneous Data"
'            Private Const _strBooleanTableName = "Boolean Data"
'            Private Const _strLaborPricingTableName = "Labor Pricing Data"
'            Private Const _strBillCodesTableName = "Bill Codes Data"

'            Private Enum BooleanFields
'                IS_DBR = 1
'                IS_NTF = 2
'                IS_NO_PARTS = 3
'                IS_WARRANTY = 4
'            End Enum

'            'drBool("IsDBR") = False
'            'drBool("IsNTF") = False
'            'drBool("IsNoParts") = False
'            'drBool("IsWrnty") = False
'            Private _objMisc As Production.Misc
'            Private _dsDeviceTrayByID As New DataSet(Me._strDeviceTrayDataSetName)
'            Private _dsOtherData As New DataSet(Me._strOtherDataSetName)
'            'Private _iTechID As Integer = 0
'            Private _drSetup As DataRow = Nothing
'            Private _bCreditUser As Boolean = False
'            Private _iCustID As Integer = 0
'            Private _strCustomerName As String = ""

'            Public Sub New(ByVal iTechID As Integer, ByVal objMisc As Production.Misc)
'                'Me._iTechID = iTechID
'                Me._objMisc = objMisc
'            End Sub

'            Public Sub SetupTrayDataByID(ByVal strTrayID As String, ByVal drSetup As DataRow)
'                Dim strSQL As String
'                Dim sf As New StackFrame(0)
'                Dim dtDevices As DataTable = Nothing
'                'Dim dtParts As DataTable = Nothing
'                'Dim drl As DataRelation = Nothing
'                Dim dtMisc As DataTable = Nothing
'                Dim iCount As Integer = 0
'                Dim dr As DataRow = Nothing

'                Try
'                    If Not IsNothing(drSetup) Then Me._drSetup = drSetup
'                    ClearDataSet(Me._dsDeviceTrayByID)
'                    ClearDataSet(Me._dsOtherData)
'                    'Me._dsDeviceTrayByID = New DataSet(Me._strDeviceTrayDataSetName)
'                    'Me._dsOtherData = New DataSet(Me._strOtherDataSetName)

'                    strSQL = "SELECT A.device_cnt AS 'Count', A.device_sn AS Serial, A.device_oldsn AS 'Old Serial', A.device_datebill AS 'Bill Date', A.Device_ID AS Device_ID, C.Cust_Name1 AS Customer, C.Cust_ID, IFNULL(D.Final_Billing_UserID, 0) AS Final_Billing_UserID " & Environment.NewLine
'                    strSQL &= "FROM tdevice A" & Environment.NewLine
'                    strSQL &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustomer C ON C.Cust_ID = B.Cust_ID " & Environment.NewLine
'                    strSQL &= "LEFT JOIN tmessdata D ON D.Device_ID = A.Device_ID " & Environment.NewLine
'                    strSQL &= "WHERE A.Tray_ID = " & strTrayID & " AND A.Device_DateShip IS NULL"

'                    dtDevices = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dtDevices) Then
'                        If dtDevices.Rows.Count > 0 Then
'                            dtDevices.TableName = Me._strDeviceTableName
'                            Me._dsDeviceTrayByID.Tables.Add(dtDevices)

'                            GetTrayData(strTrayID)
'                            GetBilledData(strTrayID)
'                            GetDeviceDetailsData(strTrayID)
'                            GetLaborData()
'                            GetBillableData(strTrayID)
'                            GetExceptionCodeData()
'                            GetExceptionBillItems()
'                            GetLookupCodesData()
'                            GetBooleanData()
'                            GetMiscData()
'                            'GetPricingData()
'                            'GetBillCodesData()

'                            'strSQL = "SELECT C.BillCode_ID AS Code, C.BillCode_Desc AS 'Desc', A.Device_ID AS Device_ID " & Environment.NewLine ' Enclose Desc in single quotes or it will be mistaken for the abbreviation for 'Descending'.
'                            'strSQL &= "FROM tdevice A " & Environment.NewLine
'                            'strSQL &= "INNER JOIN tdevicebill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
'                            'strSQL &= "INNER JOIN lbillcodes C ON C.BillCode_ID = B.BillCode_ID " & Environment.NewLine
'                            'strSQL &= "WHERE A.Tray_ID = " & strTrayID & " AND A.Device_DateShip IS NULL " & Environment.NewLine
'                            'strSQL &= "ORDER BY A.Device_ID, C.BillCode_ID"

'                            'dtParts = Me._objMisc.GetDataTable(strSQL)

'                            'If Not IsNothing(dtParts) Then
'                            '    If dtParts.Rows.Count > 0 Then
'                            '        dtParts.TableName = Me._strTrayTableName
'                            '        Me._dsDeviceTrayByID.Tables.Add(dtParts)

'                            '        drl = New DataRelation("Devices to Parts", Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Columns("Device_ID"), _
'                            '            Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Columns("Device_ID"))

'                            '        Me._dsDeviceTrayByID.Relations.Add(drl)
'                            '    End If
'                            'End If
'                        End If

'                        iCount = dtDevices.Rows.Count
'                    End If

'                    dtMisc = New DataTable(Me._strMiscTableName)
'                    dtMisc.Columns.Add("Count", System.Type.GetType("System.Int32"))
'                    dr = dtMisc.NewRow
'                    dr("Count") = iCount
'                    dtMisc.Rows.Add(dr)
'                    Me._dsDeviceTrayByID.Tables.Add(dtMisc)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    dr = Nothing

'                    If Not IsNothing(dtDevices) Then
'                        dtDevices.Dispose()
'                        dtDevices = Nothing
'                    End If

'                    'If Not IsNothing(dtParts) Then
'                    '    dtParts.Dispose()
'                    '    dtParts = Nothing
'                    'End If

'                    If Not IsNothing(dtMisc) Then
'                        dtMisc.Dispose()
'                        dtMisc = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetTrayData(ByVal strTrayID As String)
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim drl As DataRelation
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL = "SELECT C.BillCode_ID AS Code, C.BillCode_Desc AS 'Desc', A.Device_ID AS Device_ID " & Environment.NewLine ' Enclose Desc in single quotes or it will be mistaken for the abbreviation for 'Descending'.
'                    strSQL &= "FROM tdevice A " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevicebill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN lbillcodes C ON C.BillCode_ID = B.BillCode_ID " & Environment.NewLine
'                    strSQL &= "WHERE A.Tray_ID = " & strTrayID & " AND A.Device_DateShip IS NULL " & Environment.NewLine
'                    strSQL &= "ORDER BY A.Device_ID, C.BillCode_ID"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If IsNothing(dt) Then CreateTrayTable()

'                    If Not IsNothing(dt) Then
'                        'If dt.Rows.Count > 0 Then
'                        dt.TableName = Me._strTrayTableName
'                        Me._dsDeviceTrayByID.Tables.Add(dt)

'                        drl = New DataRelation("Devices to Parts", Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Columns("Device_ID"), _
'                            Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Columns("Device_ID"))

'                        Me._dsDeviceTrayByID.Relations.Add(drl)
'                        'End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Function CreateTrayTable() As DataTable
'                Dim dt As DataTable

'                Try
'                    dt = New DataTable()

'                    dt.Columns.Add(New DataColumn("Code", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("Desc", System.Type.GetType("System.String")))
'                    dt.Columns.Add(New DataColumn("Device_ID", System.Type.GetType("System.Int32")))

'                    Return dt
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Function

'            Private Sub GetBilledData(ByVal strTrayID As String)
'                Dim strSQL As String = ""
'                Dim dt As DataTable

'                Try
'                    strSQL = "SELECT A.DBill_AvgCost, A.DBill_StdCost, A.DBill_InvoiceAmt, A.device_id, A.BillCode_ID, A.Fail_ID, A.Repair_ID, A.User_ID " & Environment.NewLine
'                    strSQL &= "FROM tdevicebill A " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice B ON B.device_id = A.device_id " & Environment.NewLine
'                    strSQL &= "WHERE B.Tray_ID = " & strTrayID & " AND B.Device_DateShip IS NULL" & Environment.NewLine
'                    strSQL &= "ORDER BY A.device_id, A.BillCode_ID"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If IsNothing(dt) Then dt = CreateBilledTable() ' Create the table w/o rows

'                    dt.TableName = Me._strBilledTableName
'                    Me._dsOtherData.Tables.Add(dt)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Function CreateBilledTable() As DataTable
'                Dim dt As DataTable

'                Try
'                    dt = New DataTable()

'                    dt.Columns.Add(New DataColumn("DBill_AvgCost", System.Type.GetType("System.Decimal")))
'                    dt.Columns.Add(New DataColumn("DBill_StdCost", System.Type.GetType("System.Decimal")))
'                    dt.Columns.Add(New DataColumn("DBill_InvoiceAmt", System.Type.GetType("System.Decimal")))
'                    dt.Columns.Add(New DataColumn("device_id", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("BillCode_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("Fail_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("Repair_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("User_ID", System.Type.GetType("System.Int32")))

'                    Return dt
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Function

'            Private Sub GetDeviceDetailsData(ByVal strTrayID As String)
'                Dim strSQL As String = ""
'                Dim dt As DataTable = Nothing

'                Try
'                    strSQL &= "SELECT tdevice.device_id, tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
'                    strSQL &= "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
'                    strSQL &= "tdevice.Model_ID, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
'                    strSQL &= "IF(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
'                    strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
'                    strSQL &= "tmodel.Prod_ID, " & Environment.NewLine
'                    strSQL &= "IF(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
'                    strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
'                    strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_Name1," & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_Name2," & Environment.NewLine
'                    strSQL &= "tlocation.Loc_Name," & Environment.NewLine
'                    strSQL &= "tcustomer.Pay_ID, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
'                    strSQL &= "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
'                    strSQL &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
'                    strSQL &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
'                    strSQL &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
'                    strSQL &= "lpricinggroup.PrcType_ID,  tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_ID, tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
'                    strSQL &= "FROM tmodel " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine
'                    strSQL &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
'                    strSQL &= "WHERE tdevice.Tray_ID = " & strTrayID & " " & Environment.NewLine
'                    strSQL &= "AND tdevice.Device_DateShip IS NULL " & Environment.NewLine
'                    'strSQL &= "AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
'                    'strSQL &= "AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                    strSQL &= "AND tcustwrty.Prod_ID = tmodel.Prod_ID " & Environment.NewLine
'                    strSQL &= "ORDER BY tdevice.device_id"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strDeviceDetailsTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetLaborData()
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc, LaborLvl_ID, PrcGroup_ID, ProdGrp_ID " & Environment.NewLine
'                    strSQL &= "FROM tlaborprc " & Environment.NewLine
'                    strSQL &= "ORDER BY PrcGroup_ID, ProdGrp_ID"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strLaborTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetBillableData(ByVal strTrayID As String)
'                Dim strSQL As String
'                Dim dt As DataTable

'                Try
'                    strSQL = "SELECT tdevice.device_id, lbillcodes.BillCode_ID, LaborLvl_ID, PSPrice_AvgCost, " & Environment.NewLine
'                    strSQL &= "PSPrice_StndCost, BillCode_Rule, BillType_ID, Fail_ID, Repair_ID, " & Environment.NewLine
'                    strSQL &= "tmodel.ASCPrice_ID, lascprice.ASCPrice_Price, tmodel.Manuf_ID, tmodel.Prod_ID  " & Environment.NewLine
'                    strSQL &= "FROM (((tpsmap INNER JOIN lbillcodes ON tpsmap.BillCode_ID = lbillcodes.BillCode_ID) " & Environment.NewLine
'                    strSQL &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID) " & Environment.NewLine
'                    strSQL &= "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID) " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
'                    strSQL &= "WHERE tdevice.tray_id = " & strTrayID

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If IsNothing(dt) Then dt = CreateBillableTable() ' Create the table w/o rows

'                    dt.TableName = Me._strBillableTableName
'                    Me._dsOtherData.Tables.Add(dt)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Function CreateBillableTable() As DataTable
'                Dim dt As DataTable

'                Try
'                    dt = New DataTable()

'                    dt.Columns.Add(New DataColumn("device_id", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("BillCode_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("LaborLvl_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("PSPrice_AvgCost", System.Type.GetType("System.Decimal")))
'                    dt.Columns.Add(New DataColumn("PSPrice_StndCost", System.Type.GetType("System.Decimal")))
'                    dt.Columns.Add(New DataColumn("BillCode_Rule", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("BillType_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("Fail_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("Repair_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("ASCPrice_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("ASCPrice_Price", System.Type.GetType("System.Decimal")))
'                    dt.Columns.Add(New DataColumn("Manuf_ID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("Prod_ID", System.Type.GetType("System.Int32")))

'                    Return dt
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Function

'            Public Sub GetExceptionCodeData()
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL = "SELECT BillExcptType_ID, BillCode_ID, ProdGrp_ID, PrcGroup_ID " & Environment.NewLine
'                    strSQL &= "FROM tbillexcpt " & Environment.NewLine
'                    strSQL &= "ORDER BY BillCode_ID"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strExceptionCodeTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetExceptionBillItems()
'                Dim strSQL As String
'                Dim dt As DataTable
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL = "SELECT ExceptItem_ID, Cust_ID, WO_ID, Model_ID, BillCode_ID, Price_Amount " & Environment.NewLine
'                    strSQL &= "FROM texceptionbillitems"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strExceptionBillItemsTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetLookupCodesData()
'                Dim strSQL As String
'                Dim dt As DataTable

'                Try
'                    strSQL = "SELECT * " & Environment.NewLine
'                    strSQL &= "FROM lcodesdetail " & Environment.NewLine
'                    strSQL &= "WHERE Dcode_Inactive = 0"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strLookupCodesTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetBooleanData()
'                Dim dt As New DataTable()
'                Dim dr, drBool As DataRow
'                Dim iLength As Integer = 0

'                Try
'                    dt.Columns.Add(New DataColumn("DeviceID", System.Type.GetType("System.Int32")))
'                    dt.Columns.Add(New DataColumn("IsDBR", System.Type.GetType("System.Boolean")))
'                    dt.Columns.Add(New DataColumn("IsNTF", System.Type.GetType("System.Boolean")))
'                    dt.Columns.Add(New DataColumn("IsNoParts", System.Type.GetType("System.Boolean")))
'                    dt.Columns.Add(New DataColumn("IsWrnty", System.Type.GetType("System.Boolean")))

'                    iLength = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows.Count

'                    If iLength > 0 Then
'                        For Each dr In Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows
'                            drBool = dt.NewRow

'                            drBool("DeviceID") = dr("Device_ID")
'                            drBool("IsDBR") = False
'                            drBool("IsNTF") = False
'                            drBool("IsNoParts") = False
'                            drBool("IsWrnty") = False

'                            dt.Rows.Add(drBool)
'                        Next

'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strBooleanTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing
'                    drBool = Nothing

'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetPricingData()
'                Dim strSQL As String
'                Dim arrlstCustIDs As New ArrayList()
'                Dim strCustIDIn As String = ""
'                Dim iCustID, i As Integer
'                Dim dr As DataRow
'                Dim dt As DataTable

'                Try
'                    ' Get distinct customer IDs
'                    For Each dr In Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows
'                        iCustID = dr("Cust_ID")

'                        If arrlstCustIDs.IndexOf(iCustID) = -1 Then arrlstCustIDs.Add(iCustID)
'                    Next

'                    If arrlstCustIDs.Count > 0 Then
'                        For i = 0 To arrlstCustIDs.Count - 1
'                            If strCustIDIn.Length > 0 Then strCustIDIn &= ", "

'                            strCustIDIn &= arrlstCustIDs.Item(i).ToString
'                        Next

'                        strSQL = "SELECT C.Cust_ID, A.PrcGroup_ID, A.ProdGroup_ID, A.LaborLvl_ID, A.LaborPrc_RegPrc, A.LaborPrc_WrtyPrc " & Environment.NewLine
'                        strSQL &= "FROM tlaborprc A " & Environment.NewLine
'                        strSQL &= "INNER JOIN lpricinggroup B ON B.PrcGroup_ID = A.PrcGroup_ID AND B.ProdGroup_ID = A.ProdGroup_ID " & Environment.NewLine
'                        strSQL &= "INNER JOIN tcusttoprice C ON C.PrcGroup_ID = B.PrcGroup_ID AND C.Prod_ID = B.Prod_ID " & Environment.NewLine
'                        strSQL &= "WHERE C.Prod_ID = 1 " & Environment.NewLine ' Messaging
'                        strSQL &= " AND C.Cust_ID IN (" & strCustIDIn & ") " & Environment.NewLine
'                        strSQL &= "ORDER BY C.Cust_ID, A.PrcGroup_ID, A.ProdGroup_ID, A.LaborLvl_ID"

'                        dt = Me._objMisc.GetDataTable(strSQL)

'                        If Not IsNothing(dt) Then
'                            If dt.Rows.Count > 0 Then
'                                dt.TableName = Me._strLaborPricingTableName
'                                Me._dsOtherData.Tables.Add(dt)
'                            End If
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub GetBillCodesData()
'                Dim strSQL As String
'                Dim dt As DataTable

'                Try
'                    strSQL = "SELECT * " & Environment.NewLine
'                    strSQL &= "FROM lcodesdetail " & Environment.NewLine
'                    strSQL &= "WHERE Dcode_Inactive = 0"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            dt.TableName = Me._strLookupCodesTableName
'                            Me._dsOtherData.Tables.Add(dt)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub GetMiscData()
'                Dim dr, drBool() As DataRow

'                Try
'                    If Not IsNothing(Me._dsDeviceTrayByID.Tables(Me._strTrayTableName)) Then
'                        If Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows.Count > 0 Then
'                            For Each dr In Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows
'                                drBool = Me._dsOtherData.Tables(Me._strBooleanTableName).Select("DeviceID = " & dr("Device_ID").ToString)

'                                If drBool.Length > 0 Then
'                                    drBool(0).BeginEdit()

'                                    ' Code = BillCode_ID
'                                    If CheckPartRule(dr("Device_ID"), dr("Code")) = 1 Or CheckPartRule(dr("Device_ID"), dr("Code")) = 2 Then drBool(0)("IsDBR") = True
'                                    If dr("Code") = 0 Then drBool(0)("IsNoParts") = True

'                                    drBool(0).EndEdit()
'                                    drBool(0).AcceptChanges()
'                                End If
'                            Next
'                        End If
'                    End If

'                    If Not IsNothing(Me._dsOtherData.Tables(Me._strDeviceDetailsTableName)) Then
'                        If Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Rows.Count > 0 Then
'                            If Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Rows(0)("Pay_ID") = 2 Then Me._bCreditUser = True

'                            If Not Me._bCreditUser Then
'                                Me._strCustomerName = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Rows(0)("Loc_Name")
'                            Else
'                                Me._strCustomerName = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Rows(0)("Cust_Name1") & " " & Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Rows(0)("Cust_Name2")
'                            End If
'                        End If
'                    End If

'                    If Not IsNothing(Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName)) Then
'                        If Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows.Count > 0 Then Me._iCustID = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows(0)("Cust_ID")
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing
'                End Try
'            End Sub

'            Public Function GetDeviceTrayData() As DataTable
'                Return Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName)
'            End Function

'            Public Function GetAllTrayData() As DataSet
'                Return Me._dsDeviceTrayByID
'            End Function

'            Public Function GetCustomerID(ByVal iDeviceID As Integer)
'                Dim dr() As DataRow
'                Dim iRet As Integer = 0

'                Try
'                    dr = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Select("Device_ID = " & iDeviceID.ToString)

'                    If dr.Length > 0 Then iRet = dr(0)("Cust_ID")

'                    Return iRet
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            'strSQL &= "(Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo, Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server) " & Environment.NewLine
'            'strSQL &= "VALUES (" & _ID & ", " & iBillcode & ", " & iUserID & ", '" & dDateRec & "', " & iEmpNo & ", 1, " & iShift & ", '" & dWorkDate & "', '" & sMachine & "', 1, '" & PSS.Data.Buisness.Generic.MySQLServerDateTime(1) & "')"
'            Public Sub AddPart(ByVal iDeviceID As Integer, ByVal iBillCode As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String)
'                InternalAddPart(iDeviceID, iBillCode, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate)
'            End Sub

'            Public Sub AddPartCELL(ByVal iDeviceID As Integer, ByVal iBillCode As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String, ByVal iFailureCode As Integer, ByVal iMW As Integer)
'                Dim dr As DataRow

'                Try
'                    If iMW = 1 Then
'                        '//Invalidate Manufacturer Warranty for this device
'                        For Each dr In Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Rows
'                            If dr("device_id") = iDeviceID Then
'                                dr("Device_ManufWrty") = 0
'                                dr.AcceptChanges()

'                                Exit For
'                            End If
'                        Next
'                    End If

'                    InternalAddPart(iDeviceID, iBillCode, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate, iFailureCode)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub InternalAddPart(ByVal iDeviceID As Integer, ByVal iBillCode As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String, Optional ByVal iFailureCode As Integer = 0)
'                Dim strSQL As String
'                Dim drBillable As DataRow()
'                Dim dblPrice As Double = 0.0
'                'Dim cdCCust ' PSS.Data.Production.lcodesdetail
'                Dim drCCust(), drDevDetails(), drTempArray() As DataRow
'                'Dim dsExcept ' PSS.Data.Production.Joins
'                Dim dtTemp1, dtTemp2 As DataTable
'                Dim iCount1, iCount2 As Integer
'                Dim dblTempPrice As Double = 0
'                Dim drTemp1, drTemp2 As DataRow
'                Dim dblDefaultAmt As Double
'                Dim bDBR As Boolean = False
'                Dim bNoParts As Boolean = False
'                Dim bNTF As Boolean = False
'                Dim bFailureCode As Boolean = False
'                Dim iCheckPartRule As Integer
'                Dim iCustID As Integer = 0
'                Dim strFilter As String
'                Dim drBools(), drBool, drBillableUse, drBilled() As DataRow
'                Dim drNewTrayDevice As DataRow
'                Dim bFoundBillCodeData As Boolean
'                Dim dblBillInvoiceAmt As Double
'                Dim dtBilled As New DataTable("Device Billed Data")
'                Dim dc As DataColumn
'                Dim iCount As Integer
'                Dim sf As New StackFrame(0)

'                Try
'                    'If Me._dsOtherData.Tables(Me._strBooleanTableName).Rows.Count > 0 Then

'                    '    For Each dr In Me._dsOtherData.Tables(Me._strBooleanTableName).Rows
'                    '        If dr("DeviceID") = iDeviceID Then bFound = True : Exit For
'                    '    Next

'                    '    If bFound Then
'                    '        dr.BeginEdit()

'                    '        Select Case bl
'                    '            Case BooleanFields.IS_DBR
'                    '                dr("IsDBR") = bValue
'                    '            Case BooleanFields.IS_NTF
'                    '                dr("IsNTF") = bValue
'                    '            Case BooleanFields.IS_NO_PARTS
'                    '                dr("IsNoParts") = bValue
'                    '            Case BooleanFields.IS_WARRANTY
'                    '                dr("IsWrnty") = bValue
'                    '        End Select
'                    If Not IsNumeric(iBillCode) Then Exit Sub

'                    strFilter = "DeviceID = " & iDeviceID.ToString
'                    drBools = Me._dsOtherData.Tables(Me._strBooleanTableName).Select(strFilter)

'                    If drBools.Length > 0 Then drBool = drBools(0)

'                    iCheckPartRule = CheckPartRule(iDeviceID, iBillCode)

'                    drBool.BeginEdit()

'                    If iCheckPartRule = 1 Or iCheckPartRule = 2 Then
'                        drBool("IsDBR") = True
'                        bDBR = True
'                    End If

'                    If iCheckPartRule = 6 Then
'                        drBool("IsNTF") = True
'                        bNTF = True
'                    End If

'                    If iBillCode = 0 Then
'                        drBool("IsNoParts") = True
'                        bNoParts = True
'                    End If

'                    drBool.EndEdit()
'                    drBool.AcceptChanges()

'                    If bDBR Or bNoParts Then
'                        If Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("device_id = " & iDeviceID.ToString).Length > 0 Then Me._objMisc.DisplayMessage(sf.GetMethod, "If you wish to RUR/NER or NO PART this device first clear all other parts.", False) : Exit Sub
'                        'If Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows.Count > 1 Then Me._objMisc.DisplayMessage(sf.GetMethod, "If you wish to RUR/NER or NO PART this device first clear all other parts.", False) : Exit Sub
'                    End If

'                    If bDBR And Not (iBillCode = 25 Or iBillCode = 89) Then
'                        Me._objMisc.DisplayMessage(sf.GetMethod, "This device is RUR/NER.  Parts can't be added to an RUR/NER device.", False) : Exit Sub
'                    ElseIf bNTF Then
'                        Me._objMisc.DisplayMessage(sf.GetMethod, "This device is NTF.  Parts can't be added to an NTF device.", False) : Exit Sub
'                    ElseIf bNoParts Then
'                        Me._objMisc.DisplayMessage(sf.GetMethod, "This device has no parts.  You can't add parts to it.", False) : Exit Sub
'                    End If

'                    'dr = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("device_id = " & iDeviceID.ToString & " AND BillCode_ID = " & iBillCode.ToString)

'                    'If Me._dsOtherData.Tables(Me._strBillableTableName).Select("device_id = " & iDeviceID.ToString & " AND BillCode_ID = " & iBillCode.ToString).Length <> 1 Then _
'                    If Not IsValidDevice(iDeviceID, iBillCode) Then _
'                        Me._objMisc.DisplayMessage("This is not a valid part for this device.", False) : Exit Sub

'                    bFoundBillCodeData = False

'                    If Not IsNothing(Me._dsDeviceTrayByID.Tables(Me._strTrayTableName)) Then
'                        If Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("device_id = " & iDeviceID.ToString & " AND Code = " & iBillCode.ToString).Length > 0 Then _
'                            Me._objMisc.DisplayMessage("This part has already been added to this device.", False) : Exit Sub

'                        'dr = Me._dsDeviceTrayByID.Tables(Me._strBillableTableName).Select("device_id = " & iDeviceID.ToString & " AND BillCode_ID = " & iBillCode)

'                        drBillable = Me._dsOtherData.Tables(Me._strBillableTableName).Select("device_id = " & iDeviceID.ToString & " AND BillCode_ID = " & iBillCode.ToString)

'                        If drBillable.Length > 0 Then
'                            drBillableUse = drBillable(0)
'                            bFoundBillCodeData = True
'                        End If
'                    End If

'                    If Not bFoundBillCodeData Then
'                        drBillableUse = GetNewBillableData(iDeviceID, iBillCode)
'                        Me._dsOtherData.Tables(Me._strBillableTableName).ImportRow(drBillableUse)
'                    End If

'                    ' The following code block determines the Failure Code Value
'                    ' and will override the Manufacturer Warranty if Failure Code
'                    ' Dcode+ChrgCust is set to 1 (CELL ONLY)
'                    'bFailureCode = False
'                    'drCCust = Me._dsOtherData.Tables(Me._strLookupCodesTableName).Select("Dcode_ID = '" & iFailureCode.ToString)
'                    'cdCCust = New PSS.Data.Production.lcodesdetail()

'                    'If drCCust.Length > 0 Then ' Only one row
'                    '    If Not IsDBNull(drCCust(0)("Dcode_ChrgCust")) Then
'                    '        If drCCust(0)("Dcode_ChrgCust") = 1 Then bFailureCode = True
'                    '    End If
'                    'End If

'                    'If Not IsNothing(cdCCust) Then
'                    '    drCCust = cdCCust.GetChargeCust(vFailureCode)

'                    '    If Not IsNothing(drCCust) Then
'                    '        If Not IsDBNull(drCCust("Dcode_ChrgCust")) Then
'                    '            If drCCust("Dcode_ChrgCust") = 1 Then blnFailureCode = True
'                    '        End If
'                    '    End If
'                    'End If
'                    ' END

'                    drDevDetails = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Select("device_id = " & iDeviceID.ToString)

'                    If drDevDetails.Length > 0 Then ' Only one row
'                        If drDevDetails(0)("PO_ID") > 0 Then
'                            dblPrice = pCustomPrice(drDevDetails(0), drBillableUse)
'                        ElseIf drDevDetails(0)("Device_PSSWrty") > 0 Then
'                            dblPrice = pPSSPrice(drDevDetails(0), drBillableUse)
'                        ElseIf drDevDetails(0)("Device_ManufWrty") > 0 Then
'                            If bFailureCode = True Then
'                                dblPrice = pRegPrice(drDevDetails(0), drBillableUse)
'                            Else
'                                dblPrice = pManufPrice(drDevDetails(0), drBillableUse)
'                            End If
'                        Else
'                            dblPrice = pRegPrice(drDevDetails(0), drBillableUse)
'                        End If
'                    End If

'                    '//February 17, 2006
'                    '//This new section is to read the exception table and determine if there is an override price
'                    '//for a particular customer - model - billcode
'                    'dsExcept = New PSS.Data.Production.Joins()

'                    '//See if there is a exception record under this customer/workorder
'                    For Each drTemp1 In Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows ' Get customer ID
'                        If drTemp1("device_id") = iDeviceID Then
'                            iCustID = drTemp1("Cust_ID")

'                            Exit For
'                        End If
'                    Next

'                    strFilter = "Cust_ID = " & iCustID.ToString & " AND WO_ID = " & drDevDetails(0)("wo_id").ToString & " AND Model_ID = " & drDevDetails(0)("model_id").ToString & " AND BillCode_ID = " & iBillCode.ToString
'                    drTempArray = Me._dsOtherData.Tables(Me._strExceptionBillItemsTableName).Select(strFilter)

'                    If drTempArray.Length > 0 Then ' Should be only one row, if any
'                        dblTempPrice = drTempArray(0)("Price_Amount")
'                    Else
'                        strFilter = "Cust_ID = " & iCustID.ToString & " AND WO_ID = 0  AND Model_ID = " & drDevDetails(0)("model_id").ToString & " AND BillCode_ID = " & iBillCode.ToString
'                        drTempArray = Me._dsOtherData.Tables(Me._strExceptionBillItemsTableName).Select(strFilter)

'                        If drTempArray.Length > 0 Then dblTempPrice = drTempArray(0)("Price_Amount")
'                    End If

'                    DBRNERAdd(iDeviceID, iBillCode)

'                    'strSQL = "SELECT * " & Environment.NewLine
'                    'strSQL &= "FROM texceptionbillitems " & Environment.NewLine
'                    'strSQL &= "WHERE Cust_ID = " & iCustID.ToString & " " & Environment.NewLine
'                    'strSQL &= "AND WO_ID = " & drDevDetails(0)("wo_id").ToString & " " & Environment.NewLine
'                    'strSQL &= "AND Model_ID = " & drDevDetails(0)("model_id").ToString & " " & Environment.NewLine
'                    'strSQL &= "AND Billcode_ID = " & iBillCode.ToString

'                    'drTemp1 = Me._objMisc.GetDataRow(strSQL)

'                    'System.Windows.Forms.Application.DoEvents()

'                    'If Not IsNothing(drTemp1) Then
'                    '    dblTempPrice = drTemp1("Price_Amount")

'                    '    'If dtTemp1.Rows.Count > 0 Then
'                    '    '    '//Get value if billcode is listed
'                    '    '    For Each drTemp1 In dtTemp1.Rows
'                    '    '        If drTemp1("Billcode_ID") = iBillCode Then
'                    '    '            dTempPrice = drTemp1("Price_Amount")

'                    '    '            Exit For
'                    '    '        End If
'                    '    '    Next
'                    '    'For iCount = 0 To dtExcept.Rows.Count - 1
'                    '    '    dsR = dtExcept.Rows(iCount)
'                    '    '    If dsR("Billcode_ID") = iBillCode Then
'                    '    '        dTempPrice = dsR("Price_Amount")

'                    '    '        Exit For
'                    '    '    End If
'                    '    'Next
'                    'Else
'                    '    '//See if record exist for customer
'                    '    strSQL = "SELECT * " & Environment.NewLine
'                    '    strSQL &= "FROM texceptionbillitems " & Environment.NewLine
'                    '    strSQL &= "WHERE Cust_ID = " & iCustID.ToString & " " & Environment.NewLine
'                    '    strSQL &= "AND WO_ID = 0 " & Environment.NewLine
'                    '    strSQL &= "AND Model_ID = " & drDevDetails(0)("model_id").ToString & " " & Environment.NewLine
'                    '    strSQL &= "AND Billcode_ID = " & iBillCode.ToString

'                    '    drTemp1 = Me._objMisc.GetDataRow(strSQL)

'                    '    System.Windows.Forms.Application.DoEvents()

'                    '    If Not IsNothing(drTemp1) Then dblTempPrice = drTemp1("Price_Amount")

'                    'If dtTemp1.Rows.Count > 0 Then
'                    '    '//Get value if billcode is listed
'                    '    For Each drTemp1 In dtTemp1.Rows
'                    '        If drTemp1("Billcode_ID") = iBillCode Then
'                    '            dTempPrice = drTemp1("Price_Amount")

'                    '            Exit For
'                    '        End If
'                    '    Next
'                    'For iCount = 0 To dtExcept.Rows.Count - 1
'                    '    dsR = dtExcept.Rows(iCount)
'                    '    If dsR("Billcode_ID") = iBillCode Then
'                    '        dTempPrice = dsR("Price_Amount")

'                    '        Exit For
'                    '    End If
'                    'Next
'                    'End If

'                    drBilled = Me._dsOtherData.Tables(Me._strBilledTableName).Select("Device_ID = " & iDeviceID.ToString)

'                    For iCount = 0 To Me._dsOtherData.Tables(Me._strBilledTableName).Columns.Count - 1
'                        dc = New DataColumn(Me._dsOtherData.Tables(Me._strBilledTableName).Columns(iCount).ColumnName, Me._dsOtherData.Tables(Me._strBilledTableName).Columns(iCount).DataType)
'                        dtBilled.Columns.Add(dc)
'                    Next

'                    For iCount = 0 To drBilled.Length - 1
'                        dtBilled.ImportRow(drBilled(iCount))
'                    Next

'                    dblBillInvoiceAmt = UpdateDeviceLaborData(iDeviceID, dtBilled, iBillCode)

'                    If dblTempPrice > 0 Then dblPrice = dblTempPrice
'                    '//END OF NEW SECTION

'                    drTemp1 = Me._dsOtherData.Tables(Me._strBilledTableName).NewRow
'                    drTemp1("DBill_AvgCost") = drBillableUse("PSPrice_AvgCost")
'                    drTemp1("DBill_StdCost") = drBillableUse("PSPrice_StndCost")
'                    drTemp1("DBill_InvoiceAmt") = dblBillInvoiceAmt
'                    drTemp1("Device_ID") = iDeviceID
'                    drTemp1("BillCode_ID") = iBillCode
'                    drTemp1("Fail_ID") = drBillableUse("Fail_ID")
'                    drTemp1("Repair_ID") = drBillableUse("Repair_ID")
'                    'drTemp1("Comp_ID") = Comment
'                    drTemp1("User_ID") = 0 ' In case of problems with the following call

'                    If Not IsNothing(Me._drSetup) Then drTemp1("User_ID") = Me._drSetup("TechID")

'                    UpdateParts(drTemp1, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate)
'                    'Me._dsOtherData.Tables(Me._strBillableTableName).ImportRow(drTemp1)
'                    Me._dsOtherData.Tables(Me._strBilledTableName).ImportRow(drTemp1)

'                    drNewTrayDevice = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).NewRow

'                    drNewTrayDevice("Code") = iBillCode
'                    drNewTrayDevice("Desc") = GetBillCodeDesc(iBillCode)
'                    drNewTrayDevice("Device_ID") = iDeviceID

'                    Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows.Add(drNewTrayDevice)

'                    ''//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
'                    ''//START
'                    'If iCustID = 2069 Then
'                    '    '//Customer is AWS, Inc.
'                    '    If bDBR Then
'                    '        drTemp1 = Nothing

'                    '        If Not IsNothing(dtTemp1) Then
'                    '            dtTemp1.Dispose()
'                    '            dtTemp1 = Nothing
'                    '        End If

'                    '        '//Device is being DBR'd
'                    '        '//Determine percentage of dbr against total number in workorder
'                    '        'strFilter = "WO_ID = " & drDevDetails(0)("wo_id").ToString
'                    '        'drTempArray = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Select(strFilter)
'                    '        'iCount1 = drTempArray.Length

'                    '        strSQL = "SELECT COUNT(Device_ID) AS woTotal " & Environment.NewLine
'                    '        strSQL &= "FROM tdevice " & Environment.NewLine
'                    '        strSQL &= "WHERE WO_ID = " & drDevDetails(0)("wo_id").ToString & " " & Environment.NewLine
'                    '        strSQL &= "GROUP BY WO_ID"

'                    '        ''dtTemp1 = PSS.Data.Production.Joins.OrderEntrySelect("SELECT COUNT(Device_ID) as woTotal FROM tdevice WHERE WO_ID = " & Me._drDevice("wo_id") & " GROUP BY WO_ID")
'                    '        iCount1 = Me._objMisc.GetIntValue(strSQL)

'                    '        strSQL = "SELECT DISTINCT COUNT(tdevice.device_ID) AS dbrTotal " & Environment.NewLine
'                    '        strSQL &= "FROM tdevice " & Environment.NewLine
'                    '        strSQL &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
'                    '        strSQL &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
'                    '        strSQL &= "WHERE tdevice.wo_id = " & drDevDetails(0)("wo_id").ToString & " " & Environment.NewLine
'                    '        strSQL &= "AND lbillcodes.billcode_rule in (1, 2)"

'                    '        'dtTemp2 = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                    '        'drTemp2 = dtTemp2.Rows(0)
'                    '        iCount2 = Me._objMisc.GetIntValue(strSQL)

'                    '        If iCount2 > iCount1 * 0.2 Then
'                    '            '//Dbr margin has been exceeded
'                    '            If iDeviceID > 0 Then
'                    '                '//Update the laborlevel value
'                    'dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE")

'                    '                strSQL = "UPDATE tdevice " & Environment.NewLine
'                    '                strSQL &= "SET device_laborcharge = " & dblDefaultAmt & " " & Environment.NewLine
'                    '                strSQL &= "WHERE Device_ID = " & iDeviceID.ToString

'                    '                Me._objMisc.ExecuteNonQuery(strSQL)
'                    '                'PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
'                    '                System.Windows.Forms.Application.DoEvents()
'                    '            End If
'                    '        End If
'                    '    End If
'                    'End If
'                    ''//END

'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    drTemp1 = Nothing
'                    drTemp2 = Nothing

'                    If Not IsNothing(dtTemp1) Then
'                        dtTemp1.Dispose()
'                        dtTemp1 = Nothing
'                    End If

'                    If Not IsNothing(dtTemp2) Then
'                        dtTemp2.Dispose()
'                        dtTemp2 = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Function IsValidDevice(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer) As Boolean
'                Dim bIsValidDevice As Boolean = False
'                Dim strSQL As String
'                Dim iModelID As Integer = 0
'                Dim iCnt As Integer

'                Try
'                    strSQL = "SELECT A.model_id " & Environment.NewLine
'                    strSQL &= "FROM tmodel A " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice B ON B.model_id = A.model_id " & Environment.NewLine
'                    strSQL &= "WHERE B.device_id = " & iDeviceID.ToString

'                    iModelID = Me._objMisc.GetIntValue(strSQL)

'                    If iModelID > 0 Then
'                        strSQL = "SELECT COUNT(*) " & Environment.NewLine
'                        strSQL &= "FROM tpsmap " & Environment.NewLine
'                        strSQL &= "WHERE model_id = " & iModelID.ToString & " " & Environment.NewLine
'                        strSQL &= "AND billcode_id = " & iBillCodeID.ToString

'                        iCnt = Me._objMisc.GetIntValue(strSQL)

'                        If iCnt > 0 Then bIsValidDevice = True
'                    End If

'                    Return bIsValidDevice
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function GetBillCodeDesc(ByVal iBillCode As Integer) As String
'                Dim strSQL As String
'                Dim strRetCodeDesc As String = ""

'                Try
'                    strSQL = "SELECT BillCode_Desc " & Environment.NewLine
'                    strSQL &= "FROM lbillcodes " & Environment.NewLine
'                    strSQL &= "WHERE BillCode_ID = " & iBillCode.ToString

'                    strRetCodeDesc = Me._objMisc.GetSingletonString(strSQL)

'                    Return strRetCodeDesc
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function GetNewBillableData(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer) As DataRow
'                Dim strSQL As String
'                Dim iModelID As Integer = 0
'                Dim dr As DataRow

'                Try
'                    strSQL = "SELECT A.model_id " & Environment.NewLine
'                    strSQL &= "FROM tmodel A " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice B ON B.model_id = A.model_id " & Environment.NewLine
'                    strSQL &= "WHERE B.device_id = " & iDeviceID.ToString

'                    iModelID = Me._objMisc.GetIntValue(strSQL)

'                    If iModelID > 0 Then
'                        strSQL = "SELECT " & iDeviceID.ToString & " AS device_id, " & iBillCodeID.ToString & " AS BillCode_ID, LaborLvl_ID, C.PSPrice_AvgCost, " & Environment.NewLine
'                        strSQL &= "C.PSPrice_StndCost, B.BillCode_Rule, B.BillType_ID, B.Fail_ID, B.Repair_ID, " & Environment.NewLine
'                        strSQL &= "D.ASCPrice_ID, E.ASCPrice_Price, D.Manuf_ID, D.Prod_ID  " & Environment.NewLine
'                        strSQL &= "FROM tpsmap A "
'                        strSQL &= "INNER JOIN lbillcodes B ON B.BillCode_ID = A.BillCode_ID " & Environment.NewLine
'                        strSQL &= "INNER JOIN lpsprice C ON C.PSPrice_ID = A.PSPrice_ID " & Environment.NewLine
'                        strSQL &= "INNER JOIN tmodel D ON D.Model_ID = A.Model_ID " & Environment.NewLine
'                        strSQL &= "INNER JOIN lascprice E ON E.ASCPrice_ID = D.ASCPrice_ID " & Environment.NewLine
'                        strSQL &= "WHERE B.BillCode_ID = " & iBillCodeID.ToString & " " & Environment.NewLine
'                        strSQL &= "AND A.Model_ID = " & iModelID.ToString

'                        dr = Me._objMisc.GetDataRow(strSQL)
'                    End If

'                    Return dr
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing
'                End Try
'            End Function

'            Private Sub UpdateParts(ByVal drBillItem As DataRow, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String)
'                Dim strSQL As String
'                Dim iIndex As Integer
'                Dim drDevice As DataRow

'                Try
'                    strSQL = "INSERT INTO tdevicebill (DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, Device_ID, BillCode_ID, Fail_ID, Repair_ID, User_ID, Date_Rec) " & Environment.NewLine
'                    strSQL &= "VALUES ('" & drBillItem("DBill_AvgCost").ToString & "','" & drBillItem("DBill_StdCost").ToString & "','" & drBillItem("DBill_InvoiceAmt").ToString & "','" & drBillItem("Device_ID").ToString & "','" & _
'                                 drBillItem("BillCode_ID").ToString & "','" & drBillItem("Fail_ID").ToString & "','" & drBillItem("Repair_ID").ToString & "','" & drBillItem("User_ID").ToString & "','" & Format(Now, "yyyy-MM-dd") & "')"

'                    If Me._objMisc.ExecuteNonQuery(strSQL) > 0 Then
'                        PartTransaction(drBillItem("Device_ID"), drBillItem("BillCode_ID"), drBillItem("User_ID"), strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate, True)

'                        strSQL = "UPDATE tdevice " & Environment.NewLine
'                        strSQL &= "SET device_datebill = now() " & Environment.NewLine
'                        strSQL &= "WHERE device_id = " & drBillItem("Device_ID").ToString

'                        If Me._objMisc.ExecuteNonQuery(strSQL) > 0 Then
'                            For iIndex = 0 To Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows.Count - 1
'                                drDevice = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows(iIndex)

'                                If drDevice("Device_ID") = drBillItem("Device_ID") Then
'                                    drDevice.BeginEdit()
'                                    drDevice("Bill Date") = Format(Now(), "yyyy-MM-dd HH:mm:ss")
'                                    drDevice.EndEdit()
'                                    drDevice.AcceptChanges()
'                                End If
'                            Next
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Function CheckPartRule(ByVal iDeviceID As Integer, ByVal iBillCode As Integer) As Integer '1 = DBR, 2 = NER, 3 = PhysDam
'                Dim iRet As Integer = 0
'                Dim drPart As DataRow()

'                Try
'                    drPart = Me._dsOtherData.Tables(Me._strBillableTableName).Select("device_id = " & iDeviceID.ToString & " AND BillCode_ID = " & iBillCode.ToString)

'                    If Not IsNothing(drPart) Then
'                        If drPart.Length > 0 Then iRet = drPart(0)("BillCode_Rule")
'                    End If

'                    Return iRet
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Public Function DeletePart(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String) As DataSet
'                Dim strSQL As String = ""
'                Dim iQuerySuccessful As Integer = 0
'                Dim iIndex As Integer = -1
'                Dim dr As DataRow

'                Try
'                    strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & iDeviceID.ToString & " AND BillCode_ID = " & iBillCodeID.ToString

'                    iQuerySuccessful = Me._objMisc.ExecuteNonQuery(strSQL)

'                    If iQuerySuccessful > 0 Then
'                        PartTransaction(iDeviceID, iBillCodeID, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate, False)
'                        DBRNERDelete(iDeviceID, iBillCodeID)

'                        For Each dr In Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows
'                            iIndex += 1

'                            If dr("Device_ID") = iDeviceID And dr("Code") = iBillCodeID Then
'                                Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows(iIndex).Delete()
'                                Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).AcceptChanges()

'                                Exit For
'                            End If
'                        Next
'                    End If

'                    Return Me._dsDeviceTrayByID
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing
'                End Try
'            End Function

'            Public Function DeleteAllParts(ByVal iDeviceID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String) As DataSet
'                Dim strSQL As String = ""
'                Dim iQuerySuccessful As Integer = 0
'                Dim drParts, drDevice As DataRow
'                Dim iIndex, iCode As Integer
'                Dim dr() As DataRow

'                Try
'                    strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & iDeviceID.ToString

'                    iQuerySuccessful = Me._objMisc.ExecuteNonQuery(strSQL)

'                    If iQuerySuccessful > 0 Then
'                        strSQL = "UPDATE tdevice " & Environment.NewLine
'                        strSQL &= "SET Device_DateBill = NULL, Device_LaborCharge = 0, Device_LaborLevel = 0 " & Environment.NewLine
'                        strSQL &= "WHERE device_id = " & iDeviceID.ToString

'                        If Me._objMisc.ExecuteNonQuery(strSQL) > 0 Then
'                            If Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("Device_ID = " & iDeviceID.ToString & " AND (Code = 25 OR Code = 89)").Length > 0 Then
'                                dr = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("Device_ID = " & iDeviceID.ToString & " AND (Code = 25 OR Code = 89)")

'                                DBRNERDelete(iDeviceID, dr(0)("Code"))
'                            End If

'                            For iIndex = 0 To Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows.Count - 1
'                                drDevice = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows(iIndex)

'                                If drDevice("Device_ID") = iDeviceID Then
'                                    drDevice.BeginEdit()
'                                    drDevice("Bill Date") = DBNull.Value
'                                    drDevice.EndEdit()
'                                    drDevice.AcceptChanges()
'                                End If
'                            Next
'                        End If

'                        For iIndex = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows.Count - 1 To 0 Step -1
'                            drParts = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows(iIndex)

'                            If drParts("Device_ID") = iDeviceID Then
'                                PartTransaction(iDeviceID, drParts("Code"), iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate, False)

'                                Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows(iIndex).Delete()
'                            End If
'                        Next

'                        Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).AcceptChanges()
'                    End If

'                    Return Me._dsDeviceTrayByID
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Sub PartTransaction(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String, ByVal bAddPart As Boolean)
'                Dim strSQL As String = ""
'                Dim iTransAmount As Integer
'                Dim iCC_ID As Integer = 0

'                Try
'                    '*******************************
'                    'Get Cost Center ID
'                    '*******************************
'                    iCC_ID = Generic.GetMachineCostCenterID
'                    If iCC_ID = 31 Or iCC_ID = 0 Then     'Special Cost Center use by supervisors and leaders
'                        'Use device's cost center instead of machine's cost center
'                        iCC_ID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(iDeviceID)
'                    End If
'                    '*******************************

'                    If bAddPart Then
'                        iTransAmount = 1
'                    Else
'                        iTransAmount = -1
'                    End If

'                    strSQL &= "INSERT INTO tparttransaction (Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo, Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server, cc_id) " & Environment.NewLine
'                    strSQL &= "VALUES (" & iDeviceID.ToString & ", " & iBillCodeID.ToString & ", " & iUserID.ToString & ", '" & strDateRec & "', " & iEmployeeNum.ToString & "," & iTransAmount.ToString & ", " & iShiftID.ToString & ", '" & strWorkDate & "', '" & strMachineName & "', 1, '" & strServerDate & "', " & iCC_ID & ")"

'                    Me._objMisc.ExecuteNonQuery(strSQL)

'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub DBRNERDelete(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer)
'                Dim strSQL As String

'                Try
'                    If iBillCodeID = 25 Or iBillCodeID = 89 Then 'Drop DBR/NER
'                        strSQL = "UPDATE tdevice " & Environment.NewLine
'                        strSQL &= "SET Device_DateShip = NULL, Device_ShipWorkDate = NULL, ship_id = NULL, Shift_ID_Ship = 0 " & Environment.NewLine
'                        strSQL &= "WHERE Device_ID = " & iDeviceID.ToString

'                        Me._objMisc.ExecuteNonQuery(strSQL)

'                        strSQL = "DELETE FROM tdevicecodes " & Environment.NewLine
'                        strSQL &= "WHERE device_id = " & iDeviceID.ToString

'                        Me._objMisc.ExecuteNonQuery(strSQL)
'                    End If
'                Catch ex As Exception
'                    Throw ex
'                End Try
'            End Sub

'            Private Sub DBRNERAdd(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer)
'                Dim strSQL As String
'                Dim strDate As String

'                Try
'                    If iBillCodeID = 25 Or iBillCodeID = 89 Then 'Add DBR/NER
'                        strDate = PSS.Data.Buisness.Generic.MySQLServerDateTime(1)

'                        strSQL = "UPDATE tdevice " & Environment.NewLine
'                        strSQL &= "SET Device_DateShip = '" & strDate & "', Device_ShipWorkDate = '" & Format(CDate(strDate), "yyyy-MM-dd") & "', ship_id = 9999919, Shift_ID_Ship = 1 " & Environment.NewLine
'                        strSQL &= "WHERE Device_ID = " & iDeviceID.ToString

'                        Me._objMisc.ExecuteNonQuery(strSQL)
'                    End If
'                Catch ex As Exception
'                    Throw ex
'                End Try
'            End Sub

'            Public Sub Update(ByVal iDeviceID As Integer)
'                Dim dtValue, dtReplace, dtLL, dtCT, dtDBR, dtCheckAgg, dtAB, dtCheckAggCust As DataTable
'                Dim drValue, drInt, drNoPart, drLL, drCT, drDBR, drCheckAgg, drAB, drAB1, drPart, drCheckAggCust As DataRow
'                Dim drBilled, drLabor, drBillable As DataRow()
'                Dim sf As New StackFrame(0)
'                Dim dsAB As PSS.Data.production.Joins
'                Dim iRetInt, iRuleInt As Integer
'                Dim iCount As Integer = 0
'                Dim mRUR, mRTM As Double
'                Dim blnchargeNoPart As Boolean = True
'                Dim NoPartCount As Integer = 0
'                Dim strSQL As String
'                Dim strCheckField As String
'                Dim bExit As Boolean = False
'                Dim bSkipToAggBilling As Boolean = False
'                Dim iLL As Integer = 0
'                Dim iManufWrnty As Integer
'                Dim dABLabor As Double
'                Dim dblDefaultAmt As Double
'                Dim strFilter, strSort As String
'                Dim drTempArray() As DataRow
'                Dim drDevDetails As DataRow
'                Dim dtBillable As New DataTable("Device Billable Data")
'                Dim dtBilled As New DataTable("Device Billed Data")
'                Dim dc As DataColumn
'                Dim iCustID As Integer = 0
'                Dim dtDevDetails As New DataTable("Device Details Data")
'                Dim drPricingType As DataRow()
'                'Dim iPricingType, iProductGroupID, iProdID, iPrcGroupID, iLaborLvlID, iDeviceManufWrty, iPSSWrtyLaborID As Integer
'                Dim dblDeviceLaborCharge As Double
'                'Dim drLaborPrc As DataRow

'                Try
'                    drTempArray = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Select("device_id = " & iDeviceID.ToString)

'                    If drTempArray.Length = 0 Then Exit Sub

'                    drDevDetails = drTempArray(0)

'                    drTempArray = Me._dsOtherData.Tables(Me._strBillableTableName).Select("device_id = " & iDeviceID.ToString)

'                    If drTempArray.Length = 0 Then
'                        UpdatePrice(drDevDetails, Nothing, 0.0, drDevDetails("Device_PSSWrty"), drDevDetails("Device_ManufWrty"))

'                        Exit Sub
'                    Else
'                        For iCount = 0 To Me._dsOtherData.Tables(Me._strBillableTableName).Columns.Count - 1
'                            dc = New DataColumn(Me._dsOtherData.Tables(Me._strBillableTableName).Columns(iCount).ColumnName, Me._dsOtherData.Tables(Me._strBillableTableName).Columns(iCount).DataType)
'                            dtBillable.Columns.Add(dc)
'                        Next

'                        For iCount = 0 To drTempArray.Length - 1
'                            dtBillable.ImportRow(drTempArray(iCount))
'                        Next
'                    End If

'                    drBilled = Me._dsOtherData.Tables(Me._strBilledTableName).Select("Device_ID = " & iDeviceID.ToString)

'                    For iCount = 0 To Me._dsOtherData.Tables(Me._strBilledTableName).Columns.Count - 1
'                        dc = New DataColumn(Me._dsOtherData.Tables(Me._strBilledTableName).Columns(iCount).ColumnName, Me._dsOtherData.Tables(Me._strBilledTableName).Columns(iCount).DataType)
'                        dtBilled.Columns.Add(dc)
'                    Next

'                    For iCount = 0 To drBilled.Length - 1
'                        dtBilled.ImportRow(drBilled(iCount))
'                    Next

'                    drBillable = dtBillable.Select("Device_ID = " & iDeviceID.ToString & " AND LaborLvl_ID = " & GetLaborLevel(dtBilled, iDeviceID))

'                    If drBillable.Length = 0 Then
'                        drBillable = dtBillable.Select("Device_ID = " & iDeviceID.ToString & " AND LaborLvl_ID = 0")

'                        'If drBillable.Length = 0 Then
'                        '    Me._objMisc.DisplayMessage("There is not enough information to bill this messaging device (1). " & vbCrLf & _
'                        '                                    "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
'                        '                                    "Please CONTACT CUSTOMER SERVICE.", False)

'                        '    Exit Sub
'                        'End If
'                    End If

'                    dblDeviceLaborCharge = UpdateDeviceLaborData(iDeviceID, dtBilled)

'                    'strSQL &= "SELECT tdevice.device_id, tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
'                    'strSQL &= "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
'                    'strSQL &= "tdevice.Model_ID, " & Environment.NewLine
'                    'strSQL &= "IF(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
'                    'strSQL &= "IF(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
'                    'strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
'                    'strSQL &= "tmodel.Prod_ID, " & Environment.NewLine
'                    'strSQL &= "IF(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
'                    'strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
'                    'strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_Name1," & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_Name2," & Environment.NewLine
'                    'strSQL &= "tlocation.Loc_Name," & Environment.NewLine
'                    'strSQL &= "tcustomer.Pay_ID, " & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
'                    'strSQL &= "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
'                    'strSQL &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
'                    'strSQL &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
'                    'strSQL &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
'                    'strSQL &= "lpricinggroup.PrcType_ID,  tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip, " & Environment.NewLine
'                    'strSQL &= "tcustomer.Cust_ID, tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
'                    'strSQL &= "FROM tmodel " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                    'strSQL &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine
'                    'strSQL &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
'                    'strSQL &= "WHERE tdevice.Tray_ID = " & strTrayID & " " & Environment.NewLine
'                    'strSQL &= "AND tdevice.Device_DateShip IS NULL " & Environment.NewLine
'                    ''strSQL &= "AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
'                    ''strSQL &= "AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                    'strSQL &= "AND tcustwrty.Prod_ID = tmodel.Prod_ID " & Environment.NewLine
'                    'strSQL &= "ORDER BY tdevice.device_id"




'                    '//*************************************************************************************
'                    '//June 16, 2006
'                    '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
'                    '//Check to see if value is RTM or RUR
'                    'iRetInt = 0

'                    'If iCustID = 2019 Then '//ATCLE-AWS Customer
'                    '    'For Each drInt In dtBilled.Rows
'                    '    For Each drInt In dtBillable.Rows
'                    '        iRuleInt = CheckPartRule(iDeviceID, drInt("Billcode_ID"))

'                    '        If iRuleInt > iRetInt Then iRetInt = iRuleInt
'                    '    Next

'                    '    ' If no parts are used, then charge 6.85
'                    '    If iRuleInt < 1 Then
'                    '        'For NoPartCount = 0 To dtBilled.Rows.Count - 1
'                    '        '    drNoPart = dtBilled.Rows(NoPartCount)
'                    '        For NoPartCount = 0 To dtBillable.Rows.Count - 1
'                    '            drNoPart = dtBillable.Rows(NoPartCount)

'                    '            If drNoPart("Billcode_ID") <> 442 And drNoPart("Billcode_ID") <> 447 And drNoPart("Billcode_ID") <> 448 And drNoPart("Billcode_ID") <> 255 Then
'                    '                blnchargeNoPart = False

'                    '                Exit For
'                    '            End If
'                    '        Next

'                    '        System.Windows.Forms.Application.DoEvents()

'                    '        If blnchargeNoPart = True Then
'                    '            bSkipToAggBilling = True
'                    '            dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE_ATCLE_AWS")

'                    '            'UpdatePrice(dblDefaultAmt, False, drDevDetails("Device_ManufWrty"))

'                    '            If drDevDetails("PO_ID") < 1 Then Exit Sub
'                    '        End If
'                    '    End If

'                    '    If drDevDetails("PO_ID") > 0 Then
'                    '        bSkipToAggBilling = True
'                    '        strSQL = "SELECT * " & Environment.NewLine
'                    '        strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                    '        strSQL &= "WHERE PO_ID = " & drDevDetails("PO_ID")

'                    '        If iRetInt = 1 Or iRetInt = 2 Then ' Set labor to RUR
'                    '            strCheckField = "PO_RUR"
'                    '        ElseIf iRetInt = 9 Then ' Set labor to RTM
'                    '            strCheckField = "PO_RTM"
'                    '        End If
'                    '    Else ' Get values from tcustmarkup
'                    '        bSkipToAggBilling = True
'                    '        strSQL = "SELECT * " & Environment.NewLine
'                    '        strSQL &= "FROM tcustmarkup " & Environment.NewLine
'                    '        strSQL &= "WHERE Cust_ID = " & iCustID.ToString

'                    '        If iRetInt = 1 Or iRetInt = 2 Then ' Set labor to RUR
'                    '            strCheckField = "Markup_RUR"
'                    '        ElseIf iRetInt = 9 Then ' Set labor to RTM
'                    '            strCheckField = "Markup_RTM"
'                    '        End If
'                    '    End If ' Me._drDevice("PO_ID") > 0

'                    '    'If CheckValue(strSQL, strCheckField) Then Exit Sub
'                    'End If ' Me._iCustID = 2019
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    drValue = Nothing
'                    drInt = Nothing
'                    drNoPart = Nothing
'                    drLL = Nothing
'                    drCT = Nothing
'                    drDBR = Nothing
'                    drCheckAgg = Nothing
'                    drAB = Nothing
'                    drAB1 = Nothing
'                    drPart = Nothing
'                    drCheckAggCust = Nothing
'                    drBillable = Nothing
'                    'drBilled = Nothing
'                    drDevDetails = Nothing

'                    If Not IsNothing(dtValue) Then
'                        dtValue.Dispose()
'                        dtValue = Nothing
'                    End If

'                    If Not IsNothing(dtReplace) Then
'                        dtReplace.Dispose()
'                        dtReplace = Nothing
'                    End If

'                    If Not IsNothing(dtLL) Then
'                        dtLL.Dispose()
'                        dtLL = Nothing
'                    End If

'                    If Not IsNothing(dtCT) Then
'                        dtCT.Dispose()
'                        dtCT = Nothing
'                    End If

'                    If Not IsNothing(dtDBR) Then
'                        dtDBR.Dispose()
'                        dtDBR = Nothing
'                    End If

'                    If Not IsNothing(dtCheckAgg) Then
'                        dtCheckAgg.Dispose()
'                        dtCheckAgg = Nothing
'                    End If

'                    If Not IsNothing(dtAB) Then
'                        dtAB.Dispose()
'                        dtAB = Nothing
'                    End If

'                    If Not IsNothing(dtCheckAggCust) Then
'                        dtCheckAggCust.Dispose()
'                        dtCheckAggCust = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Function UpdateDeviceLaborData(ByVal iDeviceID As Integer, ByVal dtBilled As DataTable, Optional ByVal iBillCode As Integer = -1) As Double
'                Dim dblBillInvoiceAmt As Double = 0
'                Dim drPricingType(), drLaborPrc As DataRow
'                Dim iPricingType, iProductGroupID, iProdID, iCustID, iPrcGroupID, iLaborLvlID, iDeviceManufWrty, iPSSWrtyLaborID As Integer
'                Dim dblRegPrice, dblWrtyPrice, dblDeviceLaborCharge As Double
'                Dim bIsWarrantied As Boolean = False
'                Dim strSQL As String
'                Dim dblDBRNERCharge As Double = 0

'                Try
'                    iLaborLvlID = GetLaborLevel(dtBilled, iDeviceID, iBillCode)
'                    iCustID = Me.GetCustomerID(iDeviceID)

'                    If iBillCode = 25 Or iBillCode = 89 Then 'DBR/NER
'                        strSQL = "SELECT MarkUp_RUR, MarkUp_NER " & Environment.NewLine
'                        strSQL &= "FROM tcustmarkup " & Environment.NewLine
'                        strSQL &= "WHERE Cust_ID = " & iCustID.ToString

'                        drLaborPrc = Me._objMisc.GetDataRow(strSQL)

'                        If Not IsNothing(drLaborPrc) Then
'                            If iBillCode = 25 Then
'                                dblDBRNERCharge = drLaborPrc("MarkUp_RUR")
'                            Else
'                                dblDBRNERCharge = drLaborPrc("MarkUp_NER")
'                            End If
'                        End If

'                        strSQL = "UPDATE tdevice " & Environment.NewLine
'                        strSQL &= "SET Device_LaborCharge = " & dblDBRNERCharge.ToString & ", Device_LaborLevel = " & iLaborLvlID.ToString & " " & Environment.NewLine
'                        strSQL &= "WHERE device_id = " & iDeviceID.ToString

'                        Me._objMisc.ExecuteNonQuery(strSQL)
'                    Else
'                        ' Check to see if model pricing is flat or tiered.
'                        drPricingType = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Select("device_id = " & iDeviceID.ToString)

'                        If drPricingType.Length > 0 Then
'                            iPricingType = drPricingType(0)("PrcType_ID")
'                            iProductGroupID = drPricingType(0)("ProductGroup")
'                            iProdID = drPricingType(0)("Prod_ID")

'                            strSQL = "SELECT PrcGroup_ID " & Environment.NewLine
'                            strSQL &= "FROM tcusttoprice " & Environment.NewLine
'                            strSQL &= "WHERE Cust_ID = " & iCustID.ToString & " " & Environment.NewLine
'                            strSQL &= "AND Prod_ID = " & iProdID.ToString

'                            iPrcGroupID = Me._objMisc.GetIntValue(strSQL)

'                            If iPricingType = 1 Then ' Tiered 
'                                strSQL = "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
'                                strSQL &= "FROM tlaborprc " & Environment.NewLine
'                                strSQL &= "WHERE PrcGroup_ID = " & iPrcGroupID.ToString & " " & Environment.NewLine
'                                strSQL &= "AND LaborLvl_ID = " & iLaborLvlID.ToString & " " & Environment.NewLine
'                                strSQL &= "AND ProdGrp_ID = " & iProductGroupID

'                            Else ' Flat
'                                strSQL = "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
'                                strSQL &= "FROM tlaborprc " & Environment.NewLine
'                                strSQL &= "WHERE PrcGroup_ID = " & iPrcGroupID.ToString & " " & Environment.NewLine
'                                strSQL &= "AND LaborLvl_ID = 0 " & Environment.NewLine
'                                strSQL &= "AND ProdGrp_ID = " & iProductGroupID
'                            End If

'                            drLaborPrc = Me._objMisc.GetDataRow(strSQL)

'                            If Not IsNothing(drLaborPrc) Then
'                                dblRegPrice = drLaborPrc("LaborPrc_RegPrc")
'                                dblWrtyPrice = drLaborPrc("LaborPrc_WrtyPrc")

'                                strSQL = "SELECT Device_ManufWrty " & Environment.NewLine
'                                strSQL &= "FROM tdevice " & Environment.NewLine
'                                strSQL &= "WHERE device_id = " & iDeviceID.ToString

'                                iDeviceManufWrty = Me._objMisc.GetIntValue(strSQL)

'                                If iDeviceManufWrty = 1 Then
'                                    bIsWarrantied = True

'                                    strSQL = "SELECT PSSWrtyLabor_ID " & Environment.NewLine
'                                    strSQL &= "FROM tcustwrty " & Environment.NewLine
'                                    strSQL &= "WHERE Prod_ID = " & iProdID.ToString & " " & Environment.NewLine
'                                    strSQL &= "AND Cust_ID = " & iCustID.ToString

'                                    iPSSWrtyLaborID = Me._objMisc.GetIntValue(strSQL)

'                                    If iPSSWrtyLaborID = 1 Then
'                                        dblDeviceLaborCharge = dblRegPrice
'                                    Else
'                                        dblDeviceLaborCharge = dblWrtyPrice
'                                    End If
'                                Else
'                                    dblDeviceLaborCharge = dblRegPrice
'                                End If

'                                strSQL = "UPDATE tdevice " & Environment.NewLine
'                                strSQL &= "SET Device_LaborCharge = " & dblDeviceLaborCharge.ToString & ", Device_LaborLevel = " & iLaborLvlID.ToString & " " & Environment.NewLine
'                                strSQL &= "WHERE device_id = " & iDeviceID.ToString

'                                Me._objMisc.ExecuteNonQuery(strSQL)

'                                dblBillInvoiceAmt = GetPartsCharge(iDeviceID, bIsWarrantied, iBillCode)
'                            Else
'                                Me._objMisc.DisplayMessage("There is not enough information to bill this messaging device (2). " & vbCrLf & _
'                                                                "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
'                                                                "Please CONTACT CUSTOMER SERVICE.", False)

'                                Exit Function
'                            End If
'                        End If
'                    End If

'                    Return dblBillInvoiceAmt
'                Catch ex As Exception
'                    Throw ex
'                End Try
'            End Function

'            Private Function GetPartsCharge(ByVal iDeviceID As Integer, ByVal bIsWarrantied As Boolean, ByVal iBillCode As Integer) As Double
'                Dim dblDevicePartCharge As Double = 0
'                Dim dr() As DataRow
'                Dim iWrtyPartsID, iModelID, iPSPriceID As Integer
'                Dim strSQL, strDevicePartCharge As String

'                Try
'                    strSQL = "SELECT Model_ID " & Environment.NewLine
'                    strSQL &= "FROM tdevice " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & iDeviceID.ToString

'                    iModelID = Me._objMisc.GetIntValue(strSQL)

'                    If iModelID > 0 Then
'                        strSQL = "SELECT psprice_id " & Environment.NewLine
'                        strSQL &= "FROM tpsmap " & Environment.NewLine
'                        strSQL &= "WHERE Model_ID = " & iModelID.ToString & " " & Environment.NewLine
'                        strSQL &= "AND BillCode_ID = " & iBillCode.ToString

'                        iPSPriceID = Me._objMisc.GetIntValue(strSQL)

'                        If iPSPriceID > 0 Then
'                            strSQL = "SELECT PSPrice_StndCost "
'                            strSQL &= "FROM lpsprice "
'                            strSQL &= "WHERE PSPrice_ID = " & iPSPriceID.ToString

'                            strDevicePartCharge = Me._objMisc.GetSingletonString(strSQL)

'                            If strDevicePartCharge.Length > 0 Then dblDevicePartCharge = CDbl(strDevicePartCharge)

'                            'If bIsWarrantied Then
'                            dr = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Select("device_id = " & iDeviceID.ToString)

'                            If dr.Length > 0 Then
'                                If Not IsDBNull(dr(0)("PSSWrtyParts_ID")) Then
'                                    iWrtyPartsID = dr(0)("PSSWrtyParts_ID")

'                                    If iWrtyPartsID = 1 Or iWrtyPartsID = 3 Then
'                                        If Not IsDBNull(dr(0)("Cust_Markup")) Then dblDevicePartCharge *= (1 + dr(0)("Cust_Markup"))
'                                    End If
'                                End If
'                            End If
'                            'End If
'                        End If
'                    End If

'                    Return dblDevicePartCharge
'                Catch ex As Exception
'                    Throw ex
'                End Try
'            End Function

'            Private Sub UpdateBoolean(ByVal iDeviceID As Integer, ByVal bl As BooleanFields, ByVal bValue As Boolean)
'                Dim dr As DataRow = Nothing
'                Dim bFound As Boolean = False

'                Try
'                    If Me._dsOtherData.Tables(Me._strBooleanTableName).Rows.Count > 0 Then

'                        For Each dr In Me._dsOtherData.Tables(Me._strBooleanTableName).Rows
'                            If dr("DeviceID") = iDeviceID Then bFound = True : Exit For
'                        Next

'                        If bFound Then
'                            dr.BeginEdit()

'                            Select Case bl
'                                Case BooleanFields.IS_DBR
'                                    dr("IsDBR") = bValue
'                                Case BooleanFields.IS_NTF
'                                    dr("IsNTF") = bValue
'                                Case BooleanFields.IS_NO_PARTS
'                                    dr("IsNoParts") = bValue
'                                Case BooleanFields.IS_WARRANTY
'                                    dr("IsWrnty") = bValue
'                            End Select

'                            dr.AcceptChanges()
'                            dr.EndEdit()
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing
'                End Try
'            End Sub

'            Public Function UpdateFinalBillingUserID(ByVal iDeviceID As Integer, ByVal iBillerID As Integer) As Integer
'                Dim iRet As Integer = 0
'                Dim strSQL As String
'                Dim dr() As DataRow

'                Try
'                    strSQL = "UPDATE tmessdata " & Environment.NewLine
'                    strSQL &= "SET Final_Billing_UserID = " & iBillerID.ToString & " " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & iDeviceID.ToString

'                    iRet = Me._objMisc.ExecuteNonQuery(strSQL)

'                    If iRet > 0 Then
'                        If Not IsNothing(Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName)) Then
'                            If Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows.Count > 0 Then
'                                dr = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Select("Device_ID = " & iDeviceID.ToString)

'                                If dr.Length > 0 Then
'                                    dr(0).BeginEdit()
'                                    dr(0)("Final_Billing_UserID") = iBillerID
'                                    dr(0).EndEdit()
'                                    dr(0).AcceptChanges()
'                                End If
'                            End If
'                        End If
'                    End If

'                    Return iRet
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'#Region "Parts Calcs"
'            Private Function Price(ByVal dblCustMarkup As Double, ByVal objStandardPrice As Object, ByVal iType As Integer) As Double
'                Try
'                    If IsDBNull(objStandardPrice) Then
'                        Return 0.0
'                    ElseIf iType = 1 Then 'Service
'                        Return objStandardPrice
'                    Else 'Everything else
'                        Return Math.Round(objStandardPrice * (dblCustMarkup + 1), 2)
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function pCustomPrice(ByVal drDeviceDetails As DataRow, ByVal drBillable As DataRow) As Double
'                Try
'                    If drDeviceDetails("PlusParts") Then
'                        Return Price(drDeviceDetails("Cust_Markup"), drBillable("PSPrice_StndCost"), drBillable("BillType_ID"))
'                    Else
'                        Return 0
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function pPSSPrice(ByVal drDeviceDetails As DataRow, ByVal drBillable As DataRow) As Double
'                Try
'                    If drDeviceDetails("PSSWrtyParts_ID") = 1 Then
'                        Return pRegPrice(drDeviceDetails, drBillable)
'                    ElseIf drDeviceDetails("PSSWrtyParts_ID") = 2 Then
'                        Return 0
'                    ElseIf drDeviceDetails("PSSWrtyParts_ID") = 3 Then
'                        Return Price(drDeviceDetails("Cust_Markup"), drBillable("PSPrice_StndCost"), drBillable("BillType_ID"))
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function pManufPrice(ByVal drDeviceDetails As DataRow, ByVal drBillable As DataRow) As Double
'                Try
'                    If drBillable("BillCode_Rule") = 3 And drDeviceDetails("Device_ManufWrty") <> 2 Then
'                        If drDeviceDetails("Cust_RepairNonWrty") Then
'                            Return Price(drDeviceDetails("Cust_Markup"), drBillable("PSPrice_StndCost"), drBillable("BillType_ID"))
'                        Else
'                            Return 0
'                        End If
'                    Else
'                        If drDeviceDetails("Prod_ID") = 2 Then ' Cell device
'                            Return 0
'                        Else
'                            If drDeviceDetails("PlusParts") Then
'                                If drDeviceDetails("Device_ManufWrty") > 0 Then
'                                    Return 0
'                                Else
'                                    Return pRegPrice(drDeviceDetails, drBillable)
'                                End If
'                            Else
'                                Return 0
'                            End If
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function

'            Private Function pRegPrice(ByVal drDeviceDetails As DataRow, ByVal drBillable As DataRow) As Double
'                Dim strFilter As String
'                Dim dr() As DataRow
'                Dim iExPart As Integer = 0
'                Dim dRet As Double = 0

'                Try
'                    If drDeviceDetails("Cust_RepairNonWrty") = 1 Then
'                        If drDeviceDetails("PlusParts") = 0 Then
'                            strFilter = "BillCode_ID = " & drBillable("BillCode_ID").ToString & " AND ProdGrp_ID = " & drDeviceDetails("ProductGroup").ToString & _
'                                " AND PrcGroup_ID = " & drDeviceDetails("PricingGroup").ToString

'                            dr = Me._dsOtherData.Tables(Me._strExceptionCodeTableName).Select(strFilter)

'                            If dr.Length = 1 Then iExPart = dr(0)("BillExcptType_ID")

'                            If iExPart > 0 Then dRet = Price(drDeviceDetails("Cust_Markup"), drBillable("PSPrice_StndCost"), drBillable("BillType_ID"))
'                        Else
'                            dRet = Price(drDeviceDetails("Cust_Markup"), drBillable("PSPrice_StndCost"), drBillable("BillType_ID"))
'                        End If
'                    End If

'                    Return dRet
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Function
'#End Region

'#Region "Labor Calcs"
'            Private Sub UpdatePrice(ByVal drDeviceDetails As DataRow, ByVal drBilled As DataRow, ByVal dPrice As Double, ByVal bPSSWrty As Boolean, ByVal iManufWrty As Integer)
'                Dim iDeviceID As Integer
'                Dim bDBR As Boolean = False
'                Dim strFilter As String
'                Dim drBool() As DataRow
'                Dim bAutoShip As Boolean = False
'                Dim decServiceCharge As Decimal = 0.0

'                Try
'                    iDeviceID = drDeviceDetails("device_id")
'                    strFilter = "device_id = " & drDeviceDetails("device_id").ToString
'                    drBool = Me._dsOtherData.Tables(Me._strBooleanTableName).Select(strFilter)

'                    If drBool.Length > 0 Then bDBR = drBool(0)("IsDBR")

'                    If drDeviceDetails("Device_ManufWrty") > 0 Then iManufWrty = drDeviceDetails("Device_ManufWrty")
'                    If drDeviceDetails("Cust_AutoShip") = 1 And bDBR Then bAutoShip = True

'                    If IsNothing(drBilled) Then
'                        DeviceBilling.SetLaborData(iDeviceID, 0.0, bPSSWrty, iManufWrty, 0, "NULL", bAutoShip, drDeviceDetails("Loc_Id"), Me._drSetup("ShiftID"), Me._drSetup("WorkDate"))
'                    Else
'                        dPrice += decServiceCharge
'                        DeviceBilling.SetLaborData(Me._iDeviceID, dPrice, bPSSWrty, iManufWrty, Me._iLaborLevel, Me._strFormattedDate, bAutoShip, Me._drDevice("Loc_Id"), Me._strIDShift, Me._strWorkDate)
'                        DeviceBilling.SetLaborData(iDeviceID, dPrice, bPSSWrty, iManufWrty, drDeviceDetails("Device_LaborLevel"), Me._drSetup("FormattedDate"), bAutoShip, drDeviceDetails("Loc_Id"), Me._drSetup("ShiftID"), Me._drSetup("WorkDate"))
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub lCustomPrice(ByVal drDeviceDetails As DataRow, ByVal drBilled As DataRow, ByVal drLabor As DataRow)
'                Try
'                    If drDeviceDetails("PO_ChgWrty") And drDeviceDetails("Device_ManufWrty") > 0 Then
'                        UpdateBoolean(drDeviceDetails("device_id"), BooleanFields.IS_WARRANTY, True)
'                    End If

'                    'Since we  model our data the right way we can just call regular pricing.
'                    lRegPrice(drDeviceDetails, drBilled, drLabor)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub lPSSPrice(ByVal drDeviceDetails As DataRow, ByVal drBilled As DataRow, ByVal drLabor As DataRow)
'                Dim bDBR As Boolean = False
'                Dim bNTF As Boolean = False
'                Dim strFilter As String
'                Dim drBool() As DataRow

'                Try
'                    strFilter = "device_id = " & drDeviceDetails("device_id").ToString
'                    drBool = Me._dsOtherData.Tables(Me._strBooleanTableName).Select(strFilter)

'                    If drBool.Length > 0 Then
'                        bDBR = drBool(0)("IsDBR")
'                        bNTF = drBool(0)("IsNTF")
'                    End If

'                    If bDBR Then
'                        UpdatePrice(drDeviceDetails, drBilled, drDeviceDetails("RUR_Price"), False, 0)
'                    ElseIf bNTF Then
'                        UpdatePrice(drDeviceDetails, drBilled, drDeviceDetails("NTF_Price"), False, 0)
'                    Else
'                        If drDeviceDetails("PSSWrtyLabor_ID") = 1 Then
'                            lRegPrice(drDeviceDetails, drBilled, drLabor)
'                        ElseIf drDeviceDetails("PSSWrtyLabor_ID") = 2 Then
'                            UpdatePrice(drDeviceDetails, drBilled, 0, True, 0)
'                        ElseIf drDeviceDetails("PSSWrtyLabor_ID") = 4 Then
'                            If drDeviceDetails("Device_LaborLevel") < 3 Then
'                                lRegPrice(drDeviceDetails, drBilled, drLabor)
'                            Else
'                                UpdatePrice(drDeviceDetails, drBilled, 0, drDeviceDetails("Device_PSSWrty"), 0)
'                            End If
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub lManufPrice(ByVal drDeviceDetails As DataRow, ByVal drBilled As DataRow, ByVal drLabor As DataRow)
'                Dim iDeviceID As Integer
'                Dim bDBR As Boolean = False
'                Dim bNTF As Boolean = False
'                Dim strFilter As String
'                Dim drBool() As DataRow

'                Try
'                    iDeviceID = drDeviceDetails("device_id")
'                    strFilter = "device_id = " & iDeviceID.ToString
'                    drBool = Me._dsOtherData.Tables(Me._strBooleanTableName).Select(strFilter)

'                    If drBool.Length > 0 Then
'                        bDBR = drBool(0)("IsDBR")
'                        bNTF = drBool(0)("IsNTF")
'                    End If

'                    If bDBR Then
'                        UpdatePrice(drDeviceDetails, drBilled, drDeviceDetails("RUR_Price"), False, 0)
'                    ElseIf bNTF Then
'                        UpdatePrice(drDeviceDetails, drBilled, drDeviceDetails("NTF_Price"), False, 0)
'                    Else
'                        UpdateBoolean(iDeviceID, BooleanFields.IS_WARRANTY, True)
'                        UpdatePrice(drDeviceDetails, drBilled, drLabor("LaborPrc_WrtyPrc"), False, drDeviceDetails("Device_ManufWrty"))
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub lRegPrice(ByVal drDeviceDetails As DataRow, ByVal drBilled As DataRow, ByVal drLabor As DataRow)
'                Dim bDBR As Boolean = False
'                Dim bNTF As Boolean = False
'                Dim strFilter As String
'                Dim drBool() As DataRow

'                Try
'                    If drDeviceDetails("Cust_RepairNonWrty") Then
'                        strFilter = "device_id = " & drDeviceDetails("device_id").ToString
'                        drBool = Me._dsOtherData.Tables(Me._strBooleanTableName).Select(strFilter)

'                        If drBool.Length > 0 Then
'                            bDBR = drBool(0)("IsDBR")
'                            bNTF = drBool(0)("IsNTF")
'                        End If

'                        If bDBR Then
'                            UpdatePrice(drDeviceDetails, drBilled, drDeviceDetails("RUR_Price"), False, 0)
'                        ElseIf bNTF Then
'                            UpdatePrice(drDeviceDetails, drBilled, drDeviceDetails("NTF_Price"), False, 0)
'                        Else
'                            UpdatePrice(drDeviceDetails, drBilled, drLabor("LaborPrc_RegPrc"), False, 0)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Function GetLaborLevel(ByVal dtBilled As DataTable, ByVal iDeviceID As Integer, Optional ByVal iBillCode As Integer = -1) As Integer
'                Dim dr As DataRow
'                Dim iModelID As Integer
'                Dim iLaborLevel As Integer = 0
'                Dim strBillCodeIDIn, strSQL As String

'                Try
'                    strBillCodeIDIn = ""

'                    For Each dr In dtBilled.Rows
'                        If strBillCodeIDIn.Length > 0 Then strBillCodeIDIn &= ", "
'                        strBillCodeIDIn &= dr("BillCode_ID").ToString
'                    Next

'                    If iBillCode > -1 Then
'                        If strBillCodeIDIn.Length > 0 Then strBillCodeIDIn &= ", "
'                        strBillCodeIDIn &= iBillCode.ToString
'                    End If

'                    If strBillCodeIDIn.Length > 0 Then
'                        iModelID = Me._dsOtherData.Tables(Me._strDeviceDetailsTableName).Select("Device_ID = " & iDeviceID.ToString)(0)("Model_ID")

'                        strSQL = "SELECT MAX(LaborLvl_ID) " & Environment.NewLine
'                        strSQL &= "FROM tpsmap " & Environment.NewLine
'                        strSQL &= "WHERE BillCode_ID IN (" & strBillCodeIDIn & ") " & Environment.NewLine
'                        strSQL &= "AND Model_ID = " & iModelID.ToString

'                        iLaborLevel = Me._objMisc.GetIntValue(strSQL)
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                Finally
'                    dr = Nothing
'                End Try

'                Return iLaborLevel
'            End Function
'#End Region

'            Public Sub Print(ByVal strTray As String, ByVal strReportPath As String)
'                InternalPrint("{tdevice.Tray_ID} = " & strTray, strReportPath)
'            End Sub

'            Public Sub Print(ByVal iDeviceID As Integer, ByVal strReportPath As String)
'                InternalPrint("{tdevice.Device_ID} = " & iDeviceID.ToString, strReportPath)
'            End Sub

'            Private Sub InternalPrint(ByVal strSelectionFormula As String, ByVal strReportPath As String)
'                'Dim rptApp As New CRAXDRT.Application()
'                'Dim rpt As CRAXDRT.Report
'                'Dim sf As New StackFrame(0)
'                Dim objRpt As ReportDocument

'                Try
'                    objRpt = New ReportDocument()

'                    objRpt.Load(ConfigFile.GetBaseReportPath() & "Bill_CreditCard.rpt")
'                    objRpt.RecordSelectionFormula = strSelectionFormula
'                    'objRpt.SetDataSource(dt)
'                    objRpt.PrintToPrinter(2, True, 0, 0)
'                    'rpt = rptApp.OpenReport(strReportPath & "Bill_CreditCard.rpt")
'                    'rpt.RecordSelectionFormula = strSelectionFormula
'                    'rpt.PrintOut(False, 2)
'                    'rpt = Nothing
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Private Sub ClearDataSet(ByRef ds As DataSet)
'                Dim i, j As Integer
'                Dim sf As New StackFrame(0)

'                Try
'                    If Not IsNothing(ds) Then
'                        For i = 0 To ds.Relations.Count - 1
'                            ds.Relations.Remove(ds.Relations(i).RelationName)
'                        Next

'                        For i = ds.Tables.Count - 1 To 0 Step -1
'                            For j = 0 To ds.Tables(i).Constraints.Count - 1
'                                ds.Tables(i).Constraints.Remove(ds.Tables(i).Constraints(j).ConstraintName)
'                            Next
'                        Next

'                        For i = ds.Tables.Count - 1 To 0 Step -1
'                            ds.Tables(i).Clear()
'                            ds.Tables.Remove(ds.Tables(i).TableName)
'                        Next
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            'Public Property TechID()
'            '    Get
'            '        Return Me._iTechID
'            '    End Get
'            '    Set(ByVal Value)
'            '        Me._iTechID = Value
'            '    End Set
'            'End Property

'            Public ReadOnly Property DeviceTableName()
'                Get
'                    Return Me._strDeviceTableName
'                End Get
'            End Property

'            Public ReadOnly Property TrayTableName()
'                Get
'                    Return Me._strTrayTableName
'                End Get
'            End Property

'            Public ReadOnly Property MiscTableName()
'                Get
'                    Return Me._strMiscTableName
'                End Get
'            End Property

'            Public ReadOnly Property EndUser()
'                Get
'                    Return Me._bCreditUser
'                End Get
'            End Property
'        End Class
'#End Region

'#Region "Device"
'        Private Class Device
'            Inherits Object
'            Implements IDisposable

'            Private _objMisc As Production.Misc
'            '// Device ID
'            Private _iDeviceID As Integer = Nothing
'            '// Device Info
'            Private _drDevice As DataRow = Nothing
'            '// Parts already billed
'            Private WithEvents _dtParts As DataTable = Nothing
'            '// Labor information for billing
'            Private _dtLabor As DataTable = Nothing
'            '// Parts information for billing
'            Private _dtBillable As DataTable = Nothing
'            '// Our calculating Labor Level
'            Private _iLaborLevel As Integer = Nothing
'            '// Are we a dbr 
'            Private _bDBR As Boolean = False
'            '// Are we a ntf
'            Private _bNTF As Boolean = False
'            '// Are we a No Part
'            Private _bNoParts As Boolean = False
'            '// Will we submit a warranty claim
'            Private _bWrnty As Boolean = False
'            '// Store Customer Name for information
'            Private _strCust As String = Nothing
'            '// Tell us if we have an end user or not.
'            Private _bCreditUser As Boolean = False
'            '// Customer ID
'            Private _iCustID As Integer = 0
'            '// Technician ID
'            Private _iTechID As Integer = Nothing
'            '// ID shift
'            Dim _strIDShift As String = Nothing
'            '// Work date
'            Dim _strWorkDate As String = Nothing
'            '//  Report path
'            Dim _strReportPath As String = Nothing
'            '// Full user name
'            Dim _strUserFullName As String = Nothing
'            '//Current date formatted
'            Dim _strFormattedDate As String = Nothing

'            Private vFailureCode As Int32 = 0
'            Private vckManufWrty As Integer = 0
'            Private blnFailureCode As Boolean = False

'            Public Sub New(ByVal dtDeviceSetupData As DataTable, ByVal objMisc As Production.Misc)
'                Dim dr As DataRow

'                Try
'                    Me._objMisc = objMisc

'                    If dtDeviceSetupData.Rows.Count > 0 Then
'                        dr = dtDeviceSetupData.Rows(0)
'                        Me._iDeviceID = dr("DeviceID")
'                        Me._iTechID = dr("TechID")
'                        Me._strIDShift = dr("ShiftID")
'                        Me._strWorkDate = dr("WorkDate")
'                        Me._strReportPath = dr("ReportPath")
'                        Me._strUserFullName = dr("UserFullName")
'                        Me._strFormattedDate = dr("FormattedDate")

'                        GetData()
'                    End If
'                Catch ex As Exception
'                End Try
'            End Sub

'            Private Sub GetData()
'                Dim sf As New StackFrame(0)

'                Try
'                    GetBilledData()
'                    GetDeviceData()
'                    GetLaborData(Me._drDevice("PricingGroup"), Me._drDevice("ProductGroup"))
'                    GetPartData(Me._drDevice("Model_ID"))
'                    GetMiscData()
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub GetBilledData()
'                Dim strSQL As String = ""
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "SELECT DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, Device_ID, BillCode_ID, " & Environment.NewLine
'                    strSQL &= "Fail_ID, Repair_ID, User_ID " & Environment.NewLine
'                    strSQL &= "FROM tdevicebill " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & _iDeviceID.ToString

'                    Me._dtParts = Me._objMisc.GetDataTable(strSQL)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub GetDeviceData()
'                Dim strSQL As String = ""
'                Dim dt As DataTable = Nothing
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "SELECT tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
'                    strSQL &= "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & Environment.NewLine
'                    strSQL &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
'                    strSQL &= "tdevice.Model_ID, " & Environment.NewLine
'                    strSQL &= "If(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
'                    strSQL &= "If(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
'                    strSQL &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
'                    strSQL &= "tmodel.Prod_ID, " & Environment.NewLine
'                    strSQL &= "If(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
'                    strSQL &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
'                    strSQL &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_Name1," & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_Name2," & Environment.NewLine
'                    strSQL &= "tlocation.Loc_Name," & Environment.NewLine
'                    strSQL &= "tcustomer.Pay_ID, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
'                    strSQL &= "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
'                    strSQL &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
'                    strSQL &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
'                    strSQL &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
'                    strSQL &= "lpricinggroup.PrcType_ID,  tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip, " & Environment.NewLine
'                    strSQL &= "tcustomer.Cust_ID, tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
'                    strSQL &= "FROM tmodel " & Environment.NewLine
'                    strSQL &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
'                    strSQL &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine
'                    strSQL &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
'                    strSQL &= "WHERE(tdevice.Device_ID = " & Me._iDeviceID.ToString & " And tmodel.Prod_ID = tcustmarkup.Prod_ID) " & Environment.NewLine
'                    strSQL &= "AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                    strSQL &= "AND tcustwrty.Prod_ID = tmodel.Prod_ID;"

'                    dt = Me._objMisc.GetDataTable(strSQL)

'                    If Not IsNothing(dt) Then
'                        If dt.Rows.Count > 0 Then
'                            Me._drDevice = dt.Rows(0)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    If Not IsNothing(dt) Then
'                        dt.Dispose()
'                        dt = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Sub GetLaborData(ByVal iPriceGroup As Integer, ByVal iProductGroup As Integer)
'                Dim strSQL As String = ""
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc, LaborLvl_ID " & Environment.NewLine
'                    strSQL &= "FROM tlaborprc " & Environment.NewLine
'                    strSQL &= "WHERE PrcGroup_ID = " & iPriceGroup.ToString & " AND ProdGrp_ID = " & iProductGroup.ToString & ";"

'                    Me._dtLabor = Me._objMisc.GetDataTable(strSQL)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub GetPartData(ByVal iModelID As Integer)
'                Dim strSQL As String = ""
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "SELECT lbillcodes.BillCode_ID, LaborLvl_ID, PSPrice_AvgCost, " & Environment.NewLine
'                    strSQL &= "PSPrice_StndCost, BillCode_Rule, BillType_ID, Fail_ID, Repair_ID, " & Environment.NewLine
'                    strSQL &= "tmodel.ASCPrice_ID, lascprice.ASCPrice_Price, tmodel.Manuf_ID, tmodel.Prod_ID  " & Environment.NewLine
'                    strSQL &= "FROM (((tpsmap INNER JOIN lbillcodes ON tpsmap.BillCode_ID = lbillcodes.BillCode_ID) " & Environment.NewLine
'                    strSQL &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID) " & Environment.NewLine
'                    strSQL &= "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID) " & Environment.NewLine
'                    strSQL &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
'                    strSQL &= "WHERE tpsmap.Model_ID = " & iModelID.ToString

'                    Me._dtBillable = Me._objMisc.GetDataTable(strSQL)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Public Function GetExceptionCode(ByVal iBillCode As Integer, ByVal iProductGroup As Integer, ByVal iPriceGroup As Integer) As Integer
'                Dim strSQL As String = ""
'                Dim dt As DataTable = Nothing
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "SELECT BillExcptType_ID " & Environment.NewLine
'                    strSQL &= "FROM tbillexcpt " & Environment.NewLine
'                    strSQL &= "WHERE BillCode_ID = " & iBillCode.ToString & " " & Environment.NewLine
'                    strSQL &= "AND ProdGrp_ID = " & iProductGroup.ToString & " " & Environment.NewLine
'                    strSQL &= "AND PrcGroup_ID = " & iPriceGroup.ToString

'                    Return Me._objMisc.GetIntValue(strSQL)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function

'            Private Sub GetMiscData()
'                Dim dr As DataRow
'                Dim sf As New StackFrame(0)

'                Try
'                    Me._iLaborLevel = Me._drDevice("Device_LaborLevel")

'                    For Each dr In Me._dtParts.Rows
'                        If CheckPartRule(dr("BillCode_ID")) = 1 Or CheckPartRule(dr("BillCode_ID")) = 2 Then Me._bDBR = True
'                        If dr("BillCode_ID") = 0 Then Me._bNoParts = True

'                        If Me._bDBR And Me._bNoParts Then Exit For
'                    Next

'                    If Me._drDevice("Pay_ID") = 2 Then Me._bCreditUser = True

'                    If Not Me._bCreditUser Then
'                        Me._strCust = Me._drDevice("Loc_Name")
'                    Else
'                        Me._strCust = Me._drDevice("Cust_Name1") & " " & Me._drDevice("Cust_Name2")
'                    End If

'                    Me._iCustID = Me._drDevice("Cust_ID")
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)

'                    Me.Dispose()
'                Finally
'                    dr = Nothing
'                End Try
'            End Sub

'            Private Function CheckPartRule(ByVal iBillCode As Integer) As Integer '1 = DBR, 2 = NER, 3 = PhysDam
'                Dim drPart As DataRow()
'                Dim sf As New StackFrame(0)

'                Try
'                    drPart = Me._dtBillable.Select("BillCode_ID = " & iBillCode)

'                    If Not IsNothing(drPart) Then
'                        Return drPart(0)("BillCode_Rule")
'                    Else
'                        Return 0
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function

'            Public Sub Update()
'                Dim dtValue, dtReplace, dtLL, dtCT, dtDBR, dtCheckAgg, dtAB, dtCheckAggCust As DataTable
'                Dim drValue, drInt, drNoPart, drLL, drCT, drDBR, drCheckAgg, drAB, drAB1, drPart, drCheckAggCust As DataRow
'                Dim drPrice As DataRow()
'                Dim sf As New StackFrame(0)
'                Dim dsAB As PSS.Data.Production.Joins
'                Dim iRetInt, iRuleInt As Integer
'                Dim iCount As Integer = 0
'                Dim mRUR, mRTM As Double
'                Dim blnchargeNoPart As Boolean = True
'                Dim NoPartCount As Integer = 0
'                Dim strSQL As String
'                Dim strCheckField As String
'                Dim bExit As Boolean = False
'                Dim bSkipToAggBilling As Boolean = False
'                Dim iLL As Integer = 0
'                Dim iManufWrnty As Integer
'                Dim dABLabor As Double
'                Dim dblDefaultAmt As Double

'                Try
'                    If Me._dtParts.Rows.Count = 0 Then UpdatePrice(0.0, Me._drDevice("Device_PSSWrty"), Me._drDevice("Device_ManufWrty")) : Exit Sub

'                    drPrice = Me._dtLabor.Select("LaborLvl_ID = " & GetLaborLevel())

'                    If drPrice.Length <> 1 Then
'                        drPrice = Me._dtLabor.Select("LaborLvl_ID = 0")

'                        If drPrice.Length <> 1 Then
'                            Me._objMisc.DisplayMessage(sf.GetMethod, "There is not enough information to bill this device. " & vbCrLf & _
'                                                            "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
'                                                            "Please CONTACT CUSTOMER SERVICE.", False)

'                            Exit Sub
'                        End If
'                    End If

'                    '//*************************************************************************************
'                    '//June 16, 2006
'                    '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
'                    '//Check to see if value is RTM or RUR
'                    iRetInt = 0

'                    If Me._iCustID = 2019 Then '//ATCLE-AWS Customer
'                        For iCount = 0 To Me._dtParts.Rows.Count - 1
'                            drInt = Me._dtParts.Rows(iCount)
'                            iRuleInt = CheckPartRule(drInt("Billcode_ID"))
'                            If iRuleInt > iRetInt Then iRetInt = iRuleInt
'                        Next

'                        ' If no parts are used, then charge 6.85
'                        If iRuleInt < 1 Then
'                            For NoPartCount = 0 To Me._dtParts.Rows.Count - 1
'                                drNoPart = Me._dtParts.Rows(NoPartCount)

'                                If drNoPart("Billcode_ID") <> 442 And drNoPart("Billcode_ID") <> 447 And drNoPart("Billcode_ID") <> 448 And drNoPart("Billcode_ID") <> 255 Then
'                                    blnchargeNoPart = False

'                                    Exit For
'                                End If
'                            Next

'                            System.Windows.Forms.Application.DoEvents()

'                            If blnchargeNoPart = True Then
'                                bSkipToAggBilling = True
'                                dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE_ATCLE_AWS")

'                                UpdatePrice(dblDefaultAmt, False, Me._drDevice("Device_ManufWrty"))

'                                If Me._drDevice("PO_ID") < 1 Then Exit Sub
'                            End If
'                        End If

'                        If Me._drDevice("PO_ID") > 0 Then
'                            bSkipToAggBilling = True
'                            strSQL = "SELECT * " & Environment.NewLine
'                            strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                            strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                            If iRetInt = 1 Or iRetInt = 2 Then ' Set labor to RUR
'                                strCheckField = "PO_RUR"
'                            ElseIf iRetInt = 9 Then ' Set labor to RTM
'                                strCheckField = "PO_RTM"
'                            End If
'                        Else ' Get values from tcustmarkup
'                            bSkipToAggBilling = True
'                            strSQL = "SELECT * " & Environment.NewLine
'                            strSQL &= "FROM tcustmarkup " & Environment.NewLine
'                            strSQL &= "WHERE Cust_ID = " & Me._iCustID.ToString

'                            If iRetInt = 1 Or iRetInt = 2 Then ' Set labor to RUR
'                                strCheckField = "Markup_RUR"
'                            ElseIf iRetInt = 9 Then ' Set labor to RTM
'                                strCheckField = "Markup_RTM"
'                            End If
'                        End If ' Me._drDevice("PO_ID") > 0

'                        If CheckValue(strSQL, strCheckField) Then Exit Sub
'                    End If ' Me._iCustID = 2019

'                    '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
'                    '//June 16, 2006
'                    '//*************************************************************************************
'                    If Not bSkipToAggBilling Then
'                        dtReplace = PSS.Data.Production.Joins.ReplacePhone(Me._iDeviceID)

'                        If Me._drDevice("PO_ID") > 0 Then
'                            lCustomPrice(drPrice(0))
'                        ElseIf Me._drDevice("Device_PSSWrty") Then
'                            lPSSPrice(drPrice(0))
'                        ElseIf Me._drDevice("Device_ManufWrty") > 0 Then
'                            dtLL = PSS.Data.Production.Joins.MaxLaborLevel(Me._iDeviceID)

'                            If Not IsNothing(dtLL) Then
'                                If dtLL.Rows.Count > 0 Then
'                                    If Not IsDBNull(dtLL.Rows(0)) Then
'                                        drLL = dtLL.Rows(0)
'                                        iLL = drLL("LaborLevel")
'                                    End If
'                                End If
'                            End If

'                            Me._iLaborLevel = iLL

'                            If iLL > 0 Then
'                                lRegPrice(drPrice(0))
'                                iLL = 0
'                                iManufWrnty = 0
'                            Else
'                                lManufPrice(drPrice(0))
'                                iManufWrnty = Me._drDevice("Device_ManufWrty")
'                            End If

'                            If Not IsNothing(dtReplace) Then
'                                If dtReplace.Rows.Count > 0 Then UpdatePrice(dtReplace.Rows(0)("Markup_Replacement"), False, iManufWrnty)
'                            End If
'                        Else
'                            lRegPrice(drPrice(0))

'                            If Not IsNothing(dtReplace) Then
'                                If dtReplace.Rows.Count > 0 Then UpdatePrice(dtReplace.Rows(0)("Markup_Replacement"), False, 0)
'                            End If
'                        End If
'                    End If

'                    drPrice = Nothing

'                    If Me._bWrnty = True AndAlso PSS.Data.Buisness.Generic.GetDeviceCntInAscbill(_ID) = 0 Then ManufWrty()

'                    DeviceBilling.SetBiller(Me._strUserFullName, Me._drDevice("Tray_ID"))

'                    '//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
'                    '//START
'                    If Me._iCustID = 2069 Then '//Customer is AWS, Inc.
'                        If Me._bDBR = True Then
'                            '//Device is being DBR'd
'                            '//Determine percentage of dbr against total number in workorder
'                            strSQL = "SELECT COUNT(Device_ID) AS woTotal " & Environment.NewLine
'                            strSQL &= "FROM tdevice " & Environment.NewLine
'                            strSQL &= "WHERE WO_ID = " & Me._drDevice("wo_id") & " " & Environment.NewLine
'                            strSQL &= "GROUP BY WO_ID"

'                            dtCT = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                            If Not IsNothing(dtCT) Then
'                                If dtCT.Rows.Count > 0 Then
'                                    drCT = dtCT.Rows(0)

'                                    strSQL = "SELECT distinct COUNT(tdevice.device_ID) AS dbrTotal " & Environment.NewLine
'                                    strSQL &= "FROM tdevice " & Environment.NewLine
'                                    strSQL &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
'                                    strSQL &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
'                                    strSQL &= "WHERE tdevice.wo_id = " & Me._drDevice("WO_ID") & " AND lbillcodes.billcode_rule in (1, 2)"

'                                    dtDBR = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)

'                                    If Not IsNothing(dtDBR) Then
'                                        If dtDBR.Rows.Count > 0 Then
'                                            drDBR = dtDBR.Rows(0)

'                                            If CInt(drDBR("dbrTotal")) > CInt(drCT("woTotal")) * 0.2 Then
'                                                '//Dbr margin has been exceeded
'                                                If Me._iDeviceID > 0 Then
'                                                    '//Update the laborlevel value
'                                                    dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE")

'                                                    strSQL = "UPDATE tdevice " & Environment.NewLine
'                                                    strSQL &= "SET device_laborcharge =  " & dblDefaultAmt.ToString & " " & Environment.NewLine
'                                                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                                                    PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
'                                                    System.Windows.Forms.Application.DoEvents()
'                                                End If
'                                            End If
'                                        End If ' dtdbr.Rows.Count > 0
'                                    End If ' Not IsNothing(dtDBR)
'                                End If ' dtct.Rows.Count > 0
'                            End If ' Not IsNothing(dtCT)
'                        End If ' Me._booDBR = True
'                    End If ' Me._iCustID = 2069
'                    '//END

'AggBilling:
'                    '//This is to perform cumulative billing - January 27, 2006
'                    dABLabor = 0.0

'                    If Me._drDevice("PO_ID") > 0 Then
'                        strSQL = "SELECT * " & Environment.NewLine
'                        strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                        strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                        dtCheckAgg = dsAB.OrderEntrySelect(strSQL)

'                        If Not IsNothing(dtCheckAgg) Then
'                            If dtCheckAgg.Rows.Count > 0 Then
'                                drCheckAgg = dtCheckAgg.Rows(0)

'                                strSQL = "SELECT * " & Environment.NewLine
'                                strSQL &= "FROM tpoaggregatebilling " & Environment.NewLine
'                                strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                                dtAB = dsAB.OrderEntrySelect(strSQL)

'                                If Not IsNothing(dtAB) Then
'                                    If dtAB.Rows.Count > 0 Then
'                                        '//Iterate through billcodes to determine proper labor charge
'                                        dABLabor = 0.0

'                                        For Each drAB In Me._dtParts.Rows
'                                            For Each drAB1 In dtAB.Rows
'                                                If drAB("BillCode_ID") = drAB1("BillCode_ID") Then
'                                                    dABLabor += drAB1("tpab_Amount")

'                                                    If Me._iDeviceID > 0 And drAB("BillCode_ID") > 0 Then
'                                                        strSQL = "UPDATE tdevicebill " & Environment.NewLine
'                                                        strSQL &= "SET dbill_invoiceamt = 0.00 " & Environment.NewLine
'                                                        strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString & " AND billcode_ID = " & drAB("BillCode_ID")

'                                                        dsAB.OrderEntryUpdateDelete(strSQL)
'                                                    End If

'                                                    Exit For
'                                                End If
'                                            Next
'                                        Next

'                                        '//Now the total sum should be here
'                                        If drCheckAgg("PO_Aggregate") = 1 Then UpdatePrice(dABLabor, False, Me._drDevice("Device_ManufWrty"))
'                                    End If ' dtAB.Rows.Count > 0
'                                End If ' Not IsNothing(dtAB)
'                            End If ' dtCheckAgg.Rows.Count > 0
'                        End If ' Not IsNothing(dtCheckAgg)

'                        '//Check to see if value is RTM or RUR
'                        ''//Get maximum billcode rule
'                        iRetInt = 0

'                        For Each drPart In Me._dtParts.Rows
'                            iRuleInt = CheckPartRule(drPart("Billcode_ID"))

'                            If iRuleInt > iRetInt Then iRetInt = iRuleInt
'                        Next

'                        strSQL = "SELECT * " & Environment.NewLine
'                        strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                        strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                        If Not IsNothing(dtValue) Then dtValue.Dispose()
'                        dtValue = dsAB.OrderEntrySelect(strSQL)

'                        If Not IsNothing(dtValue) Then
'                            If dtValue.Rows.Count > 0 Then
'                                drValue = dtValue.Rows(0)

'                                If iRetInt = 1 Or iRetInt = 2 Then ' If iRetInt = 1 or 2 then set labor to RUR
'                                    If drValue("PO_RUR") > 0 Then UpdatePrice(drValue("PO_RUR"), False, Me._drDevice("Device_ManufWrty"))
'                                ElseIf iRetInt = 9 Then ' If iRetInt = 9 then set labor to RTM
'                                    If drValue("PO_RTM") > 0 Then UpdatePrice(drValue("PO_RTM"), False, Me._drDevice("Device_ManufWrty"))
'                                End If
'                            End If ' dtValue.Rows.Count > 0
'                        End If ' Not IsNothing(dtValue)
'                    Else
'                        strSQL = "SELECT * " & Environment.NewLine
'                        strSQL &= "FROM tcustomer " & Environment.NewLine
'                        strSQL &= "WHERE Cust_ID = " & Me._drDevice("Cust_ID")

'                        dtCheckAggCust = dsAB.OrderEntrySelect(strSQL)

'                        If Not IsNothing(dtCheckAggCust) Then
'                            If dtCheckAggCust.Rows.Count > 0 Then
'                                drCheckAggCust = dtCheckAggCust.Rows(0)

'                                strSQL = "SELECT * " & Environment.NewLine
'                                strSQL &= "FROM tcustaggregatebilling " & Environment.NewLine
'                                strSQL &= "WHERE Cust_ID = " & Me._drDevice("Cust_ID")

'                                If Not IsNothing(dtAB) Then dtAB.Dispose()
'                                dtAB = dsAB.OrderEntrySelect(strSQL)

'                                If Not IsNothing(dtAB) Then
'                                    If dtAB.Rows.Count > 0 Then
'                                        '//Iterate through billcodes to determine proper labor charge
'                                        dABLabor = 0.0
'                                        dblDefaultAmt = Me._objMisc.GetDefaultAmount("DBILL_INVOICE_AMT")

'                                        For Each drAB In Me._dtParts.Rows
'                                            For Each drAB1 In dtAB.Rows
'                                                If drAB("BillCode_ID") = drAB1("BillCode_ID") Then
'                                                    dABLabor += drAB1("tcab_Amount")

'                                                    If Me._iDeviceID > 0 And drAB("BillCode_ID") > 0 Then
'                                                        strSQL = "UPDATE tdevicebill "
'                                                        strSQL &= "SET dbill_invoiceamt = " & dblDefaultAmt.ToString & " "
'                                                        strSQL &= "WHERE device_id = " & Me._iDeviceID & " AND billcode_ID = " & drAB("BillCode_ID")

'                                                        dsAB.OrderEntryUpdateDelete(strSQL)
'                                                    End If

'                                                    Exit For
'                                                End If ' drAB("BillCode_ID") = drAB1("BillCode_ID")
'                                            Next ' drAB1 In dtAB.Rows
'                                        Next ' drAB In Me._dtParts.Rows

'                                        ' Now the total sum should be here
'                                        If drCheckAggCust("Cust_AggBilling") = 1 Then UpdatePrice(dABLabor, False, Me._drDevice("Device_ManufWrty"))
'                                    End If ' dtAB.Rows.Count > 0
'                                End If ' Not IsNothing(dtAB)
'                            End If ' dtCheckAggCust.Rows.Count > 0
'                        End If ' Not IsNothing(dtCheckAggCust)
'                    End If ' Me._drDevice("PO_ID") > 0

'                    ' This is to perform cumulative billing - January 27, 2006
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    drValue = Nothing
'                    drInt = Nothing
'                    drNoPart = Nothing
'                    drLL = Nothing
'                    drCT = Nothing
'                    drDBR = Nothing
'                    drCheckAgg = Nothing
'                    drAB = Nothing
'                    drAB1 = Nothing
'                    drPart = Nothing
'                    drCheckAggCust = Nothing
'                    drPrice = Nothing

'                    If Not IsNothing(dtValue) Then
'                        dtValue.Dispose()
'                        dtValue = Nothing
'                    End If

'                    If Not IsNothing(dtReplace) Then
'                        dtReplace.Dispose()
'                        dtReplace = Nothing
'                    End If

'                    If Not IsNothing(dtLL) Then
'                        dtLL.Dispose()
'                        dtLL = Nothing
'                    End If

'                    If Not IsNothing(dtCT) Then
'                        dtCT.Dispose()
'                        dtCT = Nothing
'                    End If

'                    If Not IsNothing(dtDBR) Then
'                        dtDBR.Dispose()
'                        dtDBR = Nothing
'                    End If

'                    If Not IsNothing(dtCheckAgg) Then
'                        dtCheckAgg.Dispose()
'                        dtCheckAgg = Nothing
'                    End If

'                    If Not IsNothing(dtAB) Then
'                        dtAB.Dispose()
'                        dtAB = Nothing
'                    End If

'                    If Not IsNothing(dtCheckAggCust) Then
'                        dtCheckAggCust.Dispose()
'                        dtCheckAggCust = Nothing
'                    End If
'                End Try
'            End Sub

'            Private Function CheckValue(ByVal strSQL As String, ByVal strCheckField As String) As Boolean
'                Dim bExitCalling As Boolean = False
'                Dim prj As PSS.Data.Production.Joins
'                Dim dtValue As DataTable
'                Dim drValue As DataRow
'                Dim dValue As Double
'                Dim sf As New StackFrame(0)

'                Try
'                    dtValue = prj.OrderEntrySelect(strSQL)

'                    If Not IsNothing(dtValue) Then
'                        If dtValue.Rows.Count > 0 Then
'                            drValue = dtValue.Rows(0)

'                            If Not IsDBNull(drValue(strCheckField)) Then
'                                dValue = drValue(strCheckField)

'                                If dValue > 0 Then
'                                    UpdatePrice(dValue, False, Me._drDevice("Device_ManufWrty"))

'                                    If Me._drDevice("PO_ID") < 1 Then bExitCalling = True
'                                End If
'                            End If
'                        End If
'                    End If

'                    Return bExitCalling
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    drValue = Nothing

'                    If Not IsNothing(dtValue) Then
'                        dtValue.Dispose()
'                        dtValue = Nothing
'                    End If
'                End Try
'            End Function

'            Private Function GetLaborLevel() As Integer
'                Dim dr1, drRptGrp As DataRow
'                Dim dr2 As DataRow() = Nothing
'                Dim dtRptGrp, dtLLO As DataTable
'                Dim strSQL As String
'                Dim sf As New StackFrame(0)

'                Try
'                    Me._iLaborLevel = 0

'                    For Each dr1 In Me._dtParts.Rows
'                        dr2 = Me._dtBillable.Select("BillCode_ID = " & dr1("BillCode_ID"))

'                        If CInt(dr2(0)("LaborLvl_ID")) > Me._iLaborLevel Then
'                            If Me._drDevice("Cust_ID") = 1 Then
'                                strSQL = "SELECT * " & Environment.NewLine
'                                strSQL &= "FROM tmodel " & Environment.NewLine
'                                strSQL &= "WHERE Model_ID = " & Me._drDevice("Model_ID")

'                                dtRptGrp = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                                drRptGrp = dtRptGrp.Rows(0)

'                                strSQL = "SELECT * " & Environment.NewLine
'                                strSQL &= "FROM tlaboroverrides " & Environment.NewLine
'                                strSQL &= "WHERE Cust_ID = " & Me._drDevice("Cust_ID") & " AND rptgrp_id = " & drRptGrp("rptgrp_id") & " AND billcode_id = " & dr1("billcode_ID")

'                                dtLLO = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)

'                                If dtLLO.Rows.Count > 0 Then
'                                    If Me._iLaborLevel > 2 Then
'                                    ElseIf Me._iLaborLevel < 2 Then
'                                        Me._iLaborLevel = 2
'                                    End If                                                  '
'                                Else
'                                    Me._iLaborLevel = CInt(dr2(0)("LaborLvl_ID"))
'                                End If
'                            Else
'                                Me._iLaborLevel = CInt(dr2(0)("LaborLvl_ID"))
'                            End If ' Me._drDevice("Cust_ID") = 1
'                        End If  ' CInt(dr2(0)("LaborLvl_ID")) > Me._iLaborLevel                                             
'                    Next

'                    Return Me._iLaborLevel
'                Catch ex As Exception
'                    If Not IsNothing(dr2) Then
'                        If Not IsDBNull(dr2(0)("LaborLvl_ID")) Then
'                            Me._iLaborLevel = CInt(dr2(0)("LaborLvl_ID"))
'                        End If
'                    End If

'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    dr1 = Nothing
'                    dr2 = Nothing
'                    drRptGrp = Nothing

'                    If Not IsNothing(dtRptGrp) Then
'                        dtRptGrp.Dispose()
'                        dtRptGrp = Nothing
'                    End If

'                    If Not IsNothing(dtLLO) Then
'                        dtLLO.Dispose()
'                        dtLLO = Nothing
'                    End If
'                End Try
'            End Function

'            Private Sub ManufWrty()
'                DeviceBilling.InsertWarranty(Me._iDeviceID, Me._dtBillable.Rows(0)("ASCPrice_Price"), Me._dtBillable.Rows(0)("ASCPrice_ID"), _
'                                                         Me._dtBillable.Rows(0)("Prod_ID"), Me._dtBillable.Rows(0)("Manuf_ID"))
'            End Sub

'#Region "Labor"
'            Private Sub UpdatePrice(ByVal dPrice As Double, ByVal bPSSWrty As Boolean, ByVal iManufWrty As Integer)
'                Dim bAutoShip As Boolean = False
'                Dim sf As New StackFrame(0)
'            Dim decServiceCharge As Decimal = 0.0

'                Try
'                    If Me._drDevice("Device_ManufWrty") > 0 Then iManufWrty = Me._drDevice("Device_ManufWrty")
'                    If Me._drDevice("Cust_AutoShip") = 1 And Me._bDBR = True Then bAutoShip = True

'                    If Me._dtParts.Rows.Count = 0 Then
'                        DeviceBilling.SetLaborData(Me._iDeviceID, 0.0, bPSSWrty, iManufWrty, 0, "NULL", bAutoShip, Me._drDevice("Loc_Id"), Me._strIDShift, Me._strWorkDate)
'                    Else
'                        dPrice += decServiceCharge
'                        DeviceBilling.SetLaborData(Me._iDeviceID, dPrice, bPSSWrty, iManufWrty, Me._iLaborLevel, Me._strFormattedDate, bAutoShip, Me._drDevice("Loc_Id"), Me._strIDShift, Me._strWorkDate)
'                        DeviceBilling.SetLaborData(Me._iDeviceID, dPrice, bPSSWrty, iManufWrty, Me._iLaborLevel, Me._strFormattedDate, bAutoShip, Me._drDevice("Loc_Id"), Me._strIDShift, Me._strWorkDate)
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub lCustomPrice(ByVal dr As DataRow)
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._drDevice("PO_ChgWrty") And Me._drDevice("Device_ManufWrty") > 0 Then
'                        Me._bWrnty = True
'                    End If

'                    'Since we  model our data the right way we can just call regular pricing.
'                    lRegPrice(dr)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub lPSSPrice(ByVal dr As DataRow)
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._bDBR Then
'                        UpdatePrice(Me._drDevice("RUR_Price"), False, 0)
'                    ElseIf Me._bNTF Then
'                        UpdatePrice(Me._drDevice("NTF_Price"), False, 0)
'                    Else
'                        If Me._drDevice("PSSWrtyLabor_ID") = 1 Then
'                            lRegPrice(dr)
'                        ElseIf Me._drDevice("PSSWrtyLabor_ID") = 2 Then
'                            UpdatePrice(0, True, 0)
'                        ElseIf Me._drDevice("PSSWrtyLabor_ID") = 4 Then
'                            If Me._iLaborLevel < 3 Then
'                                lRegPrice(dr)
'                            Else
'                                UpdatePrice(0, Me._drDevice("Device_PSSWrty"), 0)
'                            End If
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub lManufPrice(ByVal dr As DataRow)
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._bDBR Then
'                        UpdatePrice(Me._drDevice("RUR_Price"), False, 0)
'                    ElseIf Me._bNTF Then
'                        UpdatePrice(Me._drDevice("NTF_Price"), False, 0)
'                    Else
'                        Me._bWrnty = True
'                        UpdatePrice(dr("LaborPrc_WrtyPrc"), False, Me._drDevice("Device_ManufWrty"))
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub lRegPrice(ByVal dr As DataRow)
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._drDevice("Cust_RepairNonWrty") Then
'                        If Me._bDBR Then
'                            UpdatePrice(Me._drDevice("RUR_Price"), False, 0)
'                        ElseIf Me._bNTF Then
'                            UpdatePrice(Me._drDevice("NTF_Price"), False, 0)
'                        Else
'                            UpdatePrice(dr("LaborPrc_RegPrc"), False, 0)
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub
'#End Region

'#Region "Parts"
'            Private Function Price(ByVal objStandardPrice As Object, ByVal iType As Integer) As Double
'                Dim sf As New StackFrame(0)

'                Try
'                    If IsDBNull(objStandardPrice) Then
'                        Return 0.0
'                    ElseIf iType = 1 Then 'Service
'                        Return objStandardPrice
'                    Else 'Everything else
'                        Return Math.Round(objStandardPrice * (Me._drDevice("Cust_Markup") + 1), 2)
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function

'            Private Function pCustomPrice(ByVal dr As DataRow) As Double
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._drDevice("PlusParts") Then
'                        Return Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                    Else
'                        Return 0
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function

'            Private Function pPSSPrice(ByVal dr As DataRow) As Double
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._drDevice("PSSWrtyParts_ID") = 1 Then
'                        Return pRegPrice(dr)
'                    ElseIf Me._drDevice("PSSWrtyParts_ID") = 2 Then
'                        Return 0
'                    ElseIf Me._drDevice("PSSWrtyParts_ID") = 3 Then
'                        Return Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function

'            Private Function pManufPrice(ByVal dr As DataRow) As Double
'                Dim sf As New StackFrame(0)

'                Try
'                    If dr("BillCode_Rule") = 3 And Me._drDevice("Device_ManufWrty") <> 2 Then
'                        If Me._drDevice("Cust_RepairNonWrty") Then
'                            Return Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                        Else
'                            Return 0
'                        End If
'                    Else
'                        If Me._drDevice("Prod_ID") = 2 Then
'                            Return 0
'                        Else
'                            If Me._drDevice("PlusParts") Then
'                                If Me._drDevice("Device_ManufWrty") > 0 Then
'                                    Return 0
'                                Else
'                                    Return pRegPrice(dr)
'                                End If
'                            Else
'                                Return 0
'                            End If
'                        End If
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function

'            Private Function pRegPrice(ByVal dr As DataRow) As Double
'                Dim iExPart As Integer = 0
'                Dim dRet As Double = 0
'                Dim sf As New StackFrame(0)

'                Try
'                    If Me._drDevice("Cust_RepairNonWrty") Then
'                        If Me._drDevice("PlusParts") = False Then
'                            iExPart = DeviceBilling.GetExcepCode(dr("BillCode_ID"), Me._drDevice("PoductGroup"), Me._drDevice("PricingGroup"))(0)

'                            If iExPart <> 0 Then dRet = Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                        Else
'                            dRet = Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                        End If
'                    End If

'                    Return dRet
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Function
'#End Region

'            Public Sub AddPart(ByVal iBillCode As Integer, Optional ByVal iComment As Integer = 0)
'                InternalAddPart(iBillCode, iComment)
'            End Sub

'            Public Sub AddPartCELL(ByVal iBillCode As Integer, ByVal iFailureCode As Integer, ByVal iMW As Integer)
'                Dim sf As New StackFrame(0)

'                Try
'                    vFailureCode = 0
'                    vFailureCode = iFailureCode

'                    If iMW = 1 Then
'                        '//Invalidate Manufacturer Warranty
'                        Me._drDevice("Device_ManufWrty") = 0
'                    End If

'                    blnFailureCode = False
'                    InternalAddPart(iBillCode, 0)
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Private Sub InternalAddPart(ByVal iBillCode As Integer, ByVal iComment As Integer)
'                Dim strSQL As String
'                Dim dr As DataRow()
'                Dim dPrice As Double = 0.0
'                Dim cdCCust ' PSS.Data.Production.lcodesdetail
'                Dim drCCust As DataRow
'                Dim dsExcept ' PSS.Data.Production.Joins
'                Dim dtTemp1, dtTemp2 As DataTable
'                Dim iCount As Integer
'                Dim dTempPrice As Double = 0
'                Dim drTemp1, drTemp2 As DataRow
'                Dim sf As New StackFrame(0)
'                Dim dblDefaultAmt As Double

'                Try
'                    If Not IsNumeric(iBillCode) Then Exit Sub

'                    If CheckPartRule(iBillCode) = 1 Or CheckPartRule(iBillCode) = 2 Or iBillCode = 0 Then
'                        If Me._dtParts.Rows.Count > 1 Then Me._objMisc.DisplayMessage(sf.GetMethod, "If you wish to RUR/NER or NO PART this device first clear all other parts.", False) : Exit Sub
'                    End If

'                    If Me._bDBR Then Me._objMisc.DisplayMessage(sf.GetMethod, "This Device is a RUR/NER.  You CANNOT add parts to a RUR/NER.", False) : Exit Sub
'                    If Me._bNTF Then Me._objMisc.DisplayMessage(sf.GetMethod, "This Device is a NTF.  You CANNOT add parts to a NTF.", False) : Exit Sub
'                    If Me._bNoParts Then Me._objMisc.DisplayMessage(sf.GetMethod, "This Device has NO PARTS.  You CANNOT add parts to it.", False) : Exit Sub

'                    dr = Me._dtParts.Select("BillCode_ID = " & iBillCode)

'                    If dr.Length > 0 Then Me._objMisc.DisplayMessage(sf.GetMethod, "This part has ALREADY been added to this device.", False) : Exit Sub

'                    dr = Me._dtBillable.Select("BillCode_ID = " & iBillCode)

'                    If dr.Length <> 1 Then Me._objMisc.DisplayMessage(sf.GetMethod, "This part is NOT a valid part for this device.", False) : Exit Sub

'                    ' The following code block determines the Failure Code Value
'                    ' and will override the Manufacturer Warranty if Failure Code
'                    ' Dcode+ChrgCust is set to 1 (CELL ONLY)
'                    blnFailureCode = False
'                    cdCCust = New PSS.Data.Production.lcodesdetail()

'                    If Not IsNothing(cdCCust) Then
'                        drCCust = cdCCust.GetChargeCust(vFailureCode)

'                        If Not IsNothing(drCCust) Then
'                            If Not IsDBNull(drCCust("Dcode_ChrgCust")) Then
'                                If drCCust("Dcode_ChrgCust") = 1 Then blnFailureCode = True
'                            End If
'                        End If
'                    End If
'                    ' END

'                    If Me._drDevice("PO_ID") > 0 Then
'                        dPrice = pCustomPrice(dr(0))
'                    ElseIf Me._drDevice("Device_PSSWrty") Then
'                        dPrice = pPSSPrice(dr(0))
'                    ElseIf Me._drDevice("Device_ManufWrty") > 0 Then
'                        If blnFailureCode = True Then
'                            dPrice = pRegPrice(dr(0))
'                        Else
'                            dPrice = pManufPrice(dr(0))
'                        End If
'                    Else
'                        dPrice = pRegPrice(dr(0))
'                    End If

'                    If iBillCode = 0 Then Me._bNoParts = True
'                    If CheckPartRule(iBillCode) = 1 Or CheckPartRule(iBillCode) = 2 Then Me._bDBR = True
'                    If CheckPartRule(iBillCode) = 6 Then Me._bNTF = True

'                    '//February 17, 2006
'                    '//This new section is to read the exception table and determine if there is an override price
'                    '//for a particular customer - model - billcode
'                    dsExcept = New PSS.Data.Production.Joins()

'                    '//See if there is a exception record under this customer/workorder
'                    strSQL = "SELECT * " & Environment.NewLine
'                    strSQL &= "FROM texceptionbillitems " & Environment.NewLine
'                    strSQL &= "WHERE Cust_ID = " & Me._iCustID & " AND WO_ID = " & Me._drDevice("wo_id") & " AND Model_ID = " & Me._drDevice("model_id")

'                    dtTemp1 = dsExcept.OrderEntrySelect(strSQL)

'                    System.Windows.Forms.Application.DoEvents()

'                    If dtTemp1.Rows.Count > 0 Then
'                        '//Get value if billcode is listed
'                        For Each drTemp1 In dtTemp1.Rows
'                            If drTemp1("Billcode_ID") = iBillCode Then
'                                dTempPrice = drTemp1("Price_Amount")

'                                Exit For
'                            End If
'                        Next
'                        'For iCount = 0 To dtExcept.Rows.Count - 1
'                        '    dsR = dtExcept.Rows(iCount)
'                        '    If dsR("Billcode_ID") = iBillCode Then
'                        '        dTempPrice = dsR("Price_Amount")

'                        '        Exit For
'                        '    End If
'                        'Next
'                    Else
'                        '//See if record exist for customer
'                        strSQL = "SELECT * FROM texceptionbillitems " & Environment.NewLine
'                        strSQL &= "WHERE Cust_ID = " & Me._iCustID & " AND WO_ID = 0 AND Model_ID = " & Me._drDevice("model_id")

'                        dtTemp1 = dsExcept.OrderEntrySelect(strSQL)

'                        System.Windows.Forms.Application.DoEvents()

'                        If dtTemp1.Rows.Count > 0 Then
'                            '//Get value if billcode is listed
'                            For Each drTemp1 In dtTemp1.Rows
'                                If drTemp1("Billcode_ID") = iBillCode Then
'                                    dTempPrice = drTemp1("Price_Amount")

'                                    Exit For
'                                End If
'                            Next
'                            'For iCount = 0 To dtExcept.Rows.Count - 1
'                            '    dsR = dtExcept.Rows(iCount)
'                            '    If dsR("Billcode_ID") = iBillCode Then
'                            '        dTempPrice = dsR("Price_Amount")

'                            '        Exit For
'                            '    End If
'                            'Next
'                        End If
'                    End If

'                    If dTempPrice > 0 Then dPrice = dTempPrice
'                    '//END OF NEW SECTION

'                    drTemp1 = Me._dtParts.NewRow
'                    drTemp1("DBill_AvgCost") = dr(0)("PSPrice_AvgCost")
'                    drTemp1("DBill_StdCost") = dr(0)("PSPrice_StndCost")
'                    drTemp1("DBill_InvoiceAmt") = dPrice
'                    drTemp1("Device_ID") = Me._iDeviceID
'                    drTemp1("BillCode_ID") = iBillCode
'                    drTemp1("Fail_ID") = dr(0)("Fail_ID")
'                    drTemp1("Repair_ID") = dr(0)("Repair_ID")
'                    'drTemp1("Comp_ID") = Comment
'                    drTemp1("User_ID") = 0 ' In case of problems with the following call

'                    If Not IsNothing(Me._iTechID) Then
'                        drTemp1("User_ID") = Me._iTechID
'                    End If

'                    DeviceBilling.UpdateParts(Me._iDeviceID, drTemp1)
'                    Me._dtParts.Rows.Add(drTemp1)

'                    '//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
'                    '//START
'                    If Me._iCustID = 2069 Then
'                        '//Customer is AWS, Inc.
'                        If Me._bDBR Then
'                            drTemp1 = Nothing

'                            If Not IsNothing(dtTemp1) Then
'                                dtTemp1.Dispose()
'                                dtTemp1 = Nothing
'                            End If

'                            '//Device is being DBR'd
'                            '//Determine percentage of dbr against total number in workorder
'                            strSQL = "SELECT COUNT(Device_ID) AS woTotal " & Environment.NewLine
'                            strSQL &= "FROM tdevice " & Environment.NewLine
'                            strSQL &= "WHERE WO_ID = " & Me._drDevice("wo_id") & " " & Environment.NewLine
'                            strSQL &= "GROUP BY WO_ID"

'                            dtTemp1 = PSS.Data.Production.Joins.OrderEntrySelect("SELECT COUNT(Device_ID) as woTotal FROM tdevice WHERE WO_ID = " & Me._drDevice("wo_id") & " GROUP BY WO_ID")
'                            drTemp1 = dtTemp1.Rows(0)

'                            strSQL = "SELECT distinct COUNT(tdevice.device_ID) AS dbrTotal " & Environment.NewLine
'                            strSQL &= "FROM tdevice " & Environment.NewLine
'                            strSQL &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
'                            strSQL &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
'                            strSQL &= "WHERE tdevice.wo_id = " & Me._drDevice("WO_ID") & " AND lbillcodes.billcode_rule in (1,2)"

'                            dtTemp2 = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                            drTemp2 = dtTemp2.Rows(0)

'                            If CInt(drTemp2("dbrTotal")) > CInt(drTemp1("woTotal")) * 0.2 Then
'                                '//Dbr margin has been exceeded
'                                If Me._iDeviceID > 0 Then
'                                    '//Update the laborlevel value
'                                    dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE")

'                                    strSQL = "UPDATE tdevice " & Environment.NewLine
'                                    strSQL &= "SET device_laborcharge = " & dblDefaultAmt & " " & Environment.NewLine
'                                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID

'                                    PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
'                                    System.Windows.Forms.Application.DoEvents()
'                                End If
'                            End If
'                        End If
'                    End If
'                    '//END

'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    dr = Nothing
'                    drTemp1 = Nothing
'                    drTemp2 = Nothing

'                    If Not IsNothing(dtTemp1) Then
'                        dtTemp1.Dispose()
'                        dtTemp1 = Nothing
'                    End If

'                    If Not IsNothing(dtTemp2) Then
'                        dtTemp2.Dispose()
'                        dtTemp2 = Nothing
'                    End If
'                End Try
'            End Sub

'            Public Sub DeletePart(ByVal iBillCodeID As Integer, ByRef dsTray As DataSet)
'                Dim strSQL As String = ""
'                Dim sf As New StackFrame(0)
'                Dim iQuerySuccessful As Integer = 0
'                Dim iIndex As Integer = -1
'                Dim dr As DataRow

'                Try
'                    strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString & " AND BillCode_ID = " & iBillCodeID.ToString

'                    'iQuerySuccessful = Me._objMisc.ExecuteNonQuery(strSQL)
'                    iQuerySuccessful = 1

'                    If iQuerySuccessful > 0 Then
'                        For Each dr In dsTray.Tables("Parts").Rows
'                            iIndex += 1

'                            If dr("Device_ID") = Me._iDeviceID And dr("Code") = iBillCodeID Then
'                                dsTray.Tables("Parts").Rows(iIndex).Delete()
'                                dsTray.Tables("Parts").AcceptChanges()

'                                Exit For
'                            End If
'                        Next
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                Finally
'                    dr = Nothing
'                End Try
'            End Sub

'            Public Sub DeleteAllParts(ByRef dsTray As DataSet)
'                Dim strSQL As String = ""
'                Dim iQuerySuccessful As Integer = 0
'                Dim drParts As DataRow
'                Dim iIndex As Integer
'                Dim sf As New StackFrame(0)

'                Try
'                    strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                    'iQuerySuccessful = Me._objMisc.ExecuteNonQuery(strSQL)
'                    iQuerySuccessful = 1

'                    If iQuerySuccessful > 0 Then

'                        For iIndex = dsTray.Tables("Parts").Rows.Count - 1 To 0 Step -1
'                            drParts = dsTray.Tables("Parts").Rows(iIndex)

'                            If drParts("Device_ID") = Me._iDeviceID Then dsTray.Tables("Parts").Rows(iIndex).Delete()
'                        Next

'                        dsTray.Tables("Parts").AcceptChanges()
'                    End If
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'                End Try
'            End Sub

'            Public Sub Print(ByVal iTray As Integer)
'                InternalPrint("{tdevice.Tray_ID} = " & iTray)
'            End Sub

'            Public Sub Print()
'                InternalPrint("{tdevice.Device_ID} = " & Trim(Me._iDeviceID))
'            End Sub

'            Private Sub InternalPrint(ByVal strSelectionFormula As String)
'                'Dim rptApp As New CRAXDRT.Application()
'                'Dim rpt As CRAXDRT.Report
'                Dim objRpt As ReportDocument

'                Try
'                    objRpt = New ReportDocument()

'                    objRpt.Load(ConfigFile.GetBaseReportPath() & "Bill_CreditCard.rpt")
'                    objRpt.RecordSelectionFormula = strSelectionFormula
'                    objRpt.PrintToPrinter(2, True, 0, 0)
'                    'rpt = rptApp.OpenReport(Me._strReportPath & "Bill_CreditCard.rpt")
'                    'rpt.RecordSelectionFormula = strSelectionFormula
'                    'rpt.PrintOut(False, 2)
'                    'rpt = Nothing
'                Catch ex As Exception
'                    Me._objMisc.DisplayMessage(ex.Message)
'                End Try
'            End Sub

'            Public Sub Dispose() Implements IDisposable.Dispose
'                Me._drDevice = Nothing
'                Me._dtParts.Dispose()
'                Me._dtParts = Nothing
'                Me._dtLabor.Dispose()
'                Me._dtLabor = Nothing
'                Me._dtBillable.Dispose()
'                Me._dtBillable = Nothing
'                Me._iLaborLevel = Nothing
'                Me._bDBR = False
'                Me._bNoParts = False
'                Me._bWrnty = False
'                Me._strCust = Nothing
'                Me._bCreditUser = False
'            End Sub

'            Protected Overrides Sub Finalize()
'                Me._objMisc = Nothing
'                MyBase.Finalize()
'            End Sub

'#Region "Properties"
'            Public ReadOnly Property DefaultView() As DataView
'                Get
'                    Return Me._dtParts.DefaultView
'                End Get
'            End Property

'            Public ReadOnly Property Billed() As Boolean
'                Get
'                    If IsDate(_drDevice("Device_DateBill")) Then
'                        Return True
'                    Else
'                        Return False
'                    End If
'                End Get
'            End Property

'            Public ReadOnly Property DeviceID() As Integer
'                Get
'                    Return Me._iDeviceID
'                End Get
'            End Property

'            Public ReadOnly Property Parts() As DataTable
'                Get
'                    Return Me._dtParts
'                End Get
'            End Property

'            Public ReadOnly Property EndUser() As Boolean
'                Get
'                    Return Me._bCreditUser
'                End Get
'            End Property

'            Public ReadOnly Property Customer() As String
'                Get
'                    Return Me._strCust
'                End Get
'            End Property

'            Public ReadOnly Property CustID() As String
'                Get
'                    Return Me._iCustID
'                End Get
'            End Property
'#End Region
'        End Class
'#End Region
'    End Class

'    Public Class DeviceOld
'        ' Created by Yuri 22-Jun-2007.
'        Inherits Object
'        Implements IDisposable

'        Private _objMisc As Production.Misc
'        '// Device ID
'        Private _iDeviceID As Integer = Nothing
'        '// Device Info
'        Private _drDevice As DataRow = Nothing
'        '// Parts already billed
'        Private WithEvents _dtParts As DataTable = Nothing
'        '// Labor information for billing
'        Private _dtLabor As DataTable = Nothing
'        '// Parts information for billing
'        Private _dtBillable As DataTable = Nothing
'        '// Our calculating Labor Level
'        Private _iLaborLevel As Integer = Nothing
'        '// Are we a dbr 
'        Private _bDBR As Boolean = False
'        '// Are we a ntf
'        Private _booNTF As Boolean = False
'        '// Are we a No Part
'        Private _booNoParts As Boolean = False
'        '// Will we submit a warranty claim
'        Private _booWrnty As Boolean = False
'        '// Store Customer Name for information
'        Private _strCust As String = Nothing
'        '// Tell us if we have an end user or not.
'        Private _booCreditUser As Boolean = False
'        '// Customer ID
'        Private _iCustID As Integer = 0
'        '// Technician ID
'        Private _iTechID As Integer = Nothing
'        '// ID shift
'        Dim _strIDShift As String = Nothing
'        '// Work date
'        Dim _strWorkDate As String = Nothing
'        '//  Report path
'        Dim _strReportPath As String = Nothing
'        '// Full user name
'        Dim _strUserFullName As String = Nothing
'        '//Current date formatted
'        Dim _strFormattedDate As String = Nothing

'        Private vFailureCode As Int32 = 0
'        Private vckManufWrty As Integer = 0
'        Private blnFailureCode As Boolean = False

'        Public Sub New()
'            Me._objMisc = New Production.Misc()
'        End Sub

'        Public Sub New(ByVal iDeviceID As Integer, ByVal iTechID As Integer, ByVal strIDShift As String, _
'            ByVal strWorkDate As String, ByVal strReportPath As String, ByVal strUserFullName As String, ByVal strFormattedDate As String)
'            Me._iDeviceID = iDeviceID
'            Me._iTechID = iTechID
'            Me._strIDShift = strIDShift
'            Me._strWorkDate = strWorkDate
'            Me._strReportPath = strReportPath
'            Me._strUserFullName = strUserFullName
'            Me._strFormattedDate = strFormattedDate
'            Me._objMisc = New Production.Misc()

'            GetData()
'        End Sub

'        Private Sub GetData()
'            Dim sf As New StackFrame(0)

'            Try
'                GetBilledData()
'                GetDeviceData()
'                GetLaborData(Me._drDevice("PricingGroup"), Me._drDevice("PoductGroup"))
'                GetPartData(Me._drDevice("Model_ID"))
'                GetMiscData()
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub GetBilledData()
'            Dim strSQL As String = ""
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL &= "SELECT DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, Device_ID, BillCode_ID, " & Environment.NewLine
'                strSQL &= "Fail_ID, Repair_ID, User_ID " & Environment.NewLine
'                strSQL &= "FROM tdevicebill " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & _iDeviceID.ToString

'                Me._dtParts = Me._objMisc.GetDataTable(strSQL)
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub GetDeviceData()
'            Dim strSQL As String = ""
'            Dim dt As DataTable = Nothing
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL &= "SELECT tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
'                strSQL &= "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
'                strSQL &= "tdevice.Model_ID, " & Environment.NewLine
'                strSQL &= "If(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
'                strSQL &= "If(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS PoductGroup, " & Environment.NewLine
'                strSQL &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
'                strSQL &= "tmodel.Prod_ID, " & Environment.NewLine
'                strSQL &= "If(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
'                strSQL &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
'                strSQL &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_Name1," & Environment.NewLine
'                strSQL &= "tcustomer.Cust_Name2," & Environment.NewLine
'                strSQL &= "tlocation.Loc_Name," & Environment.NewLine
'                strSQL &= "tcustomer.Pay_ID, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
'                strSQL &= "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
'                strSQL &= "lpricinggroup.PrcType_ID,  tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_ID, tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
'                strSQL &= "FROM tmodel " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine
'                strSQL &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
'                strSQL &= "WHERE(tdevice.Device_ID = " & Me._iDeviceID.ToString & " And tmodel.Prod_ID = tcustmarkup.Prod_ID) " & Environment.NewLine
'                strSQL &= "AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                strSQL &= "AND tcustwrty.Prod_ID = tmodel.Prod_ID;"

'                dt = Me._objMisc.GetDataTable(strSQL)

'                If Not IsNothing(dt) Then
'                    If dt.Rows.Count > 0 Then
'                        Me._drDevice = dt.Rows(0)
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub GetLaborData(ByVal iPriceGroup As Integer, ByVal iProductGroup As Integer)
'            Dim strSQL As String = ""
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL &= "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc, LaborLvl_ID " & Environment.NewLine
'                strSQL &= "FROM tlaborprc " & Environment.NewLine
'                strSQL &= "WHERE PrcGroup_ID = " & iPriceGroup.ToString & " AND ProdGrp_ID = " & iProductGroup.ToString & ";"

'                Me._dtLabor = Me._objMisc.GetDataTable(strSQL)
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub GetPartData(ByVal iModelID As Integer)
'            Dim strSQL As String = ""
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL &= "SELECT lbillcodes.BillCode_ID, LaborLvl_ID, PSPrice_AvgCost, " & Environment.NewLine
'                strSQL &= "PSPrice_StndCost, BillCode_Rule, BillType_ID, Fail_ID, Repair_ID, " & Environment.NewLine
'                strSQL &= "tmodel.ASCPrice_ID, lascprice.ASCPrice_Price, tmodel.Manuf_ID, tmodel.Prod_ID  " & Environment.NewLine
'                strSQL &= "FROM (((tpsmap INNER JOIN lbillcodes ON tpsmap.BillCode_ID = lbillcodes.BillCode_ID) " & Environment.NewLine
'                strSQL &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID) " & Environment.NewLine
'                strSQL &= "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID) " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
'                strSQL &= "WHERE tpsmap.Model_ID = " & iModelID.ToString

'                Me._dtBillable = Me._objMisc.GetDataTable(strSQL)
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Public Function GetExceptionCode(ByVal iBillCode As Integer, ByVal iProductGroup As Integer, ByVal iPriceGroup As Integer) As DataRow
'            Dim strSQL As String = ""
'            Dim dt As DataTable = Nothing
'            Dim drExpCode As DataRow = Nothing
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL &= "SELECT BillExcptType_ID " & Environment.NewLine
'                strSQL &= "FROM tbillexcpt " & Environment.NewLine
'                strSQL &= "WHERE BillCode_ID = " & iBillCode.ToString & " " & Environment.NewLine
'                strSQL &= "AND ProdGrp_ID = " & iProductGroup.ToString & " " & Environment.NewLine
'                strSQL &= "AND PrcGroup_ID = " & iPriceGroup.ToString

'                dt = Me._objMisc.GetDataTable(strSQL)

'                If Not IsNothing(dt) Then
'                    If dt.Rows.Count > 0 Then
'                        drExpCode = dt.Rows(0)
'                    End If
'                End If

'                Return drExpCode
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                drExpCode = Nothing

'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Private Sub GetMiscData()
'            Dim dr As DataRow
'            Dim sf As New StackFrame(0)

'            Try
'                Me._iLaborLevel = Me._drDevice("Device_LaborLevel")

'                For Each dr In Me._dtParts.Rows
'                    If CheckPartRule(dr("BillCode_ID")) = 1 Or CheckPartRule(dr("BillCode_ID")) = 2 Then Me._bDBR = True
'                    If dr("BillCode_ID") = 0 Then Me._booNoParts = True

'                    If Me._bDBR And Me._booNoParts Then Exit For
'                Next

'                If Me._drDevice("Pay_ID") = 2 Then Me._booCreditUser = True

'                If Not Me._booCreditUser Then
'                    Me._strCust = Me._drDevice("Loc_Name")
'                Else
'                    Me._strCust = Me._drDevice("Cust_Name1") & " " & Me._drDevice("Cust_Name2")
'                End If

'                Me._iCustID = Me._drDevice("Cust_ID")
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)

'                Me.Dispose()
'            Finally
'                dr = Nothing
'            End Try
'        End Sub

'        'Public Function GetDeviceTrayByID(ByVal iTrayID As Int32) As DataTable
'        '    Dim strSQL As String = ""

'        '    Try
'        '        strSQL &= "SELECT device_id, device_cnt AS 'Cnt', device_sn, device_oldsn, device_datebill " & Environment.NewLine
'        '        strSQL &= "FROM tdevice " & Environment.NewLine
'        '        strSQL &= "WHERE Tray_ID = " & iTrayID & " AND tdevice.Device_DateShip IS NULL;"

'        '        Return Me._objMisc.GetDataTable(strSQL)
'        '    Catch ex As Exception
'        '        Throw ex
'        '    End Try
'        'End Function

'        Public Sub AddPart(ByVal iBillCode As Integer)
'            InternalAddPart(iBillCode, 0)
'        End Sub

'        Public Sub AddPart(ByVal iBillCode As Integer, ByVal iComment As Integer)
'            InternalAddPart(iBillCode, iComment)
'        End Sub

'        Public Sub AddPartCELL(ByVal iBillCode As Integer, ByVal iFailureCode As Integer, ByVal iMW As Integer)
'            Dim sf As New StackFrame(0)

'            Try
'                vFailureCode = 0
'                vFailureCode = iFailureCode

'                If iMW = 1 Then
'                    '//Invalidate Manufacturer Warranty
'                    Me._drDevice("Device_ManufWrty") = 0
'                End If

'                blnFailureCode = False
'                InternalAddPart(iBillCode, 0)
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub InternalAddPart(ByVal iBillCode As Integer, ByVal iComment As Integer)
'            Dim strSQL As String
'            Dim dr As DataRow()
'            Dim dPrice As Double = 0.0
'            Dim cdCCust ' PSS.Data.Production.lcodesdetail
'            Dim drCCust As DataRow
'            Dim dsExcept ' PSS.Data.Production.Joins
'            Dim dtTemp1, dtTemp2 As DataTable
'            Dim iCount As Integer
'            Dim dTempPrice As Double = 0
'            Dim drTemp1, drTemp2 As DataRow
'            Dim sf As New StackFrame(0)
'            Dim dblDefaultAmt As Double

'            Try
'                If Not IsNumeric(iBillCode) Then Exit Sub

'                If CheckPartRule(iBillCode) = 1 Or CheckPartRule(iBillCode) = 2 Or iBillCode = 0 Then
'                    If Me._dtParts.Rows.Count > 1 Then Me._objMisc.DisplayMessage(sf.GetMethod, "If you wish to RUR/NER or NO PART this device first clear all other parts.", False) : Exit Sub
'                End If

'                If Me._bDBR Then Me._objMisc.DisplayMessage(sf.GetMethod, "This Device is a RUR/NER.  You CANNOT add parts to a RUR/NER.", False) : Exit Sub
'                If Me._booNTF Then Me._objMisc.DisplayMessage(sf.GetMethod, "This Device is a NTF.  You CANNOT add parts to a NTF.", False) : Exit Sub
'                If Me._booNoParts Then Me._objMisc.DisplayMessage(sf.GetMethod, "This Device has NO PARTS.  You CANNOT add parts to it.", False) : Exit Sub

'                dr = Me._dtParts.Select("BillCode_ID = " & iBillCode)

'                If dr.Length > 0 Then Me._objMisc.DisplayMessage(sf.GetMethod, "This part has ALREADY been added to this device.", False) : Exit Sub

'                dr = Me._dtBillable.Select("BillCode_ID = " & iBillCode)

'                If dr.Length <> 1 Then Me._objMisc.DisplayMessage(sf.GetMethod, "This part is NOT a valid part for this device.", False) : Exit Sub

'                ' The following code block determines the Failure Code Value
'                ' and will override the Manufacturer Warranty if Failure Code
'                ' Dcode+ChrgCust is set to 1 (CELL ONLY)
'                blnFailureCode = False
'                cdCCust = New PSS.Data.Production.lcodesdetail()

'                If Not IsNothing(cdCCust) Then
'                    drCCust = cdCCust.GetChargeCust(vFailureCode)

'                    If Not IsNothing(drCCust) Then
'                        If Not IsDBNull(drCCust("Dcode_ChrgCust")) Then
'                            If drCCust("Dcode_ChrgCust") = 1 Then blnFailureCode = True
'                        End If
'                    End If
'                End If
'                ' END

'                If Me._drDevice("PO_ID") > 0 Then
'                    dPrice = pCustomPrice(dr(0))
'                ElseIf Me._drDevice("Device_PSSWrty") Then
'                    dPrice = pPSSPrice(dr(0))
'                ElseIf Me._drDevice("Device_ManufWrty") > 0 Then
'                    If blnFailureCode = True Then
'                        dPrice = pRegPrice(dr(0))
'                    Else
'                        dPrice = pManufPrice(dr(0))
'                    End If
'                Else
'                    dPrice = pRegPrice(dr(0))
'                End If

'                If iBillCode = 0 Then Me._booNoParts = True
'                If CheckPartRule(iBillCode) = 1 Or CheckPartRule(iBillCode) = 2 Then Me._bDBR = True
'                If CheckPartRule(iBillCode) = 6 Then Me._booNTF = True

'                '//February 17, 2006
'                '//This new section is to read the exception table and determine if there is an override price
'                '//for a particular customer - model - billcode
'                dsExcept = New PSS.Data.Production.Joins()

'                '//See if there is a exception record under this customer/workorder
'                strSQL = "SELECT * " & Environment.NewLine
'                strSQL &= "FROM texceptionbillitems " & Environment.NewLine
'                strSQL &= "WHERE Cust_ID = " & Me._iCustID & " AND WO_ID = " & Me._drDevice("wo_id") & " AND Model_ID = " & Me._drDevice("model_id")

'                dtTemp1 = dsExcept.OrderEntrySelect(strSQL)

'                System.Windows.Forms.Application.DoEvents()

'                If dtTemp1.Rows.Count > 0 Then
'                    '//Get value if billcode is listed
'                    For Each drTemp1 In dtTemp1.Rows
'                        If drTemp1("Billcode_ID") = iBillCode Then
'                            dTempPrice = drTemp1("Price_Amount")

'                            Exit For
'                        End If
'                    Next
'                    'For iCount = 0 To dtExcept.Rows.Count - 1
'                    '    dsR = dtExcept.Rows(iCount)
'                    '    If dsR("Billcode_ID") = iBillCode Then
'                    '        dTempPrice = dsR("Price_Amount")

'                    '        Exit For
'                    '    End If
'                    'Next
'                Else
'                    '//See if record exist for customer
'                    strSQL = "SELECT * FROM texceptionbillitems " & Environment.NewLine
'                    strSQL &= "WHERE Cust_ID = " & Me._iCustID & " AND WO_ID = 0 AND Model_ID = " & Me._drDevice("model_id")

'                    dtTemp1 = dsExcept.OrderEntrySelect(strSQL)

'                    System.Windows.Forms.Application.DoEvents()

'                    If dtTemp1.Rows.Count > 0 Then
'                        '//Get value if billcode is listed
'                        For Each drTemp1 In dtTemp1.Rows
'                            If drTemp1("Billcode_ID") = iBillCode Then
'                                dTempPrice = drTemp1("Price_Amount")

'                                Exit For
'                            End If
'                        Next
'                        'For iCount = 0 To dtExcept.Rows.Count - 1
'                        '    dsR = dtExcept.Rows(iCount)
'                        '    If dsR("Billcode_ID") = iBillCode Then
'                        '        dTempPrice = dsR("Price_Amount")

'                        '        Exit For
'                        '    End If
'                        'Next
'                    End If
'                End If

'                If dTempPrice > 0 Then dPrice = dTempPrice
'                '//END OF NEW SECTION

'                drTemp1 = Me._dtParts.NewRow
'                drTemp1("DBill_AvgCost") = dr(0)("PSPrice_AvgCost")
'                drTemp1("DBill_StdCost") = dr(0)("PSPrice_StndCost")
'                drTemp1("DBill_InvoiceAmt") = dPrice
'                drTemp1("Device_ID") = Me._iDeviceID
'                drTemp1("BillCode_ID") = iBillCode
'                drTemp1("Fail_ID") = dr(0)("Fail_ID")
'                drTemp1("Repair_ID") = dr(0)("Repair_ID")
'                'drTemp1("Comp_ID") = Comment
'                drTemp1("User_ID") = 0 ' In case of problems with the following call

'                If Not IsNothing(Me._iTechID) Then
'                    drTemp1("User_ID") = Me._iTechID
'                End If

'                DeviceBilling.UpdateParts(Me._iDeviceID, drTemp1)
'                Me._dtParts.Rows.Add(drTemp1)

'                '//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
'                '//START
'                If Me._iCustID = 2069 Then
'                    '//Customer is AWS, Inc.
'                    If Me._bDBR Then
'                        drTemp1 = Nothing

'                        If Not IsNothing(dtTemp1) Then
'                            dtTemp1.Dispose()
'                            dtTemp1 = Nothing
'                        End If

'                        '//Device is being DBR'd
'                        '//Determine percentage of dbr against total number in workorder
'                        strSQL = "SELECT COUNT(Device_ID) AS woTotal " & Environment.NewLine
'                        strSQL &= "FROM tdevice " & Environment.NewLine
'                        strSQL &= "WHERE WO_ID = " & Me._drDevice("wo_id") & " " & Environment.NewLine
'                        strSQL &= "GROUP BY WO_ID"

'                        dtTemp1 = PSS.Data.Production.Joins.OrderEntrySelect("SELECT COUNT(Device_ID) as woTotal FROM tdevice WHERE WO_ID = " & Me._drDevice("wo_id") & " GROUP BY WO_ID")
'                        drTemp1 = dtTemp1.Rows(0)

'                        strSQL = "SELECT distinct COUNT(tdevice.device_ID) AS dbrTotal " & Environment.NewLine
'                        strSQL &= "FROM tdevice " & Environment.NewLine
'                        strSQL &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
'                        strSQL &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
'                        strSQL &= "WHERE tdevice.wo_id = " & Me._drDevice("WO_ID") & " AND lbillcodes.billcode_rule in (1,2)"

'                        dtTemp2 = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                        drTemp2 = dtTemp2.Rows(0)

'                        If CInt(drTemp2("dbrTotal")) > CInt(drTemp1("woTotal")) * 0.2 Then
'                            '//Dbr margin has been exceeded
'                            If Me._iDeviceID > 0 Then
'                                '//Update the laborlevel value
'                                dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE")

'                                strSQL = "UPDATE tdevice " & Environment.NewLine
'                                strSQL &= "SET device_laborcharge = " & dblDefaultAmt & " " & Environment.NewLine
'                                strSQL &= "WHERE Device_ID = " & Me._iDeviceID

'                                PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
'                                System.Windows.Forms.Application.DoEvents()
'                            End If
'                        End If
'                    End If
'                End If
'                '//END

'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                dr = Nothing
'                drTemp1 = Nothing
'                drTemp2 = Nothing

'                If Not IsNothing(dtTemp1) Then
'                    dtTemp1.Dispose()
'                    dtTemp1 = Nothing
'                End If

'                If Not IsNothing(dtTemp2) Then
'                    dtTemp2.Dispose()
'                    dtTemp2 = Nothing
'                End If
'            End Try
'        End Sub

'        Public Sub DeletePart(ByVal iBillCodeID As Integer)
'            Dim strSQL As String = ""
'            Dim sf As New StackFrame(0)
'            Dim iQuerySuccessful As Integer = 0
'            Dim iIndex As Integer = -1
'            Dim dr As DataRow

'            Try
'                strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & _iDeviceID.ToString & " AND BillCode_ID = " & iBillCodeID.ToString

'                Me._objMisc._SQL = strSQL
'                iQuerySuccessful = Me._objMisc.ExecuteNonQuery()

'                If iQuerySuccessful > 0 Then
'                    For Each dr In Me._dtParts.Rows
'                        iIndex += 1

'                        If dr("BillCode_ID") = iBillCodeID Then
'                            Me._dtParts.Rows.RemoveAt(iIndex)

'                            Exit For
'                        End If
'                    Next
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                dr = Nothing
'            End Try
'        End Sub

'        Public Sub DeleteAllParts()
'            Dim strSQL As String = ""
'            Dim sf As New StackFrame(0)

'            Try
'                strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                Me._objMisc._SQL = strSQL

'                If Me._objMisc.ExecuteNonQuery() > 0 Then Me._dtParts.Rows.Clear()
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Function CheckPartRule(ByVal iBillCode As Integer) As Integer '1 = DBR, 2 = NER, 3 = PhysDam
'            Dim drPart As DataRow()
'            Dim sf As New StackFrame(0)

'            Try
'                drPart = Me._dtBillable.Select("BillCode_ID = " & iBillCode)

'                If Not IsNothing(drPart) Then
'                    Return drPart(0)("BillCode_Rule")
'                Else
'                    Return 0
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function

'        Public Sub Print(ByVal iTray As Integer)
'            InternalPrint("{tdevice.Tray_ID} = " & iTray)
'        End Sub

'        Public Sub Print()
'            InternalPrint("{tdevice.Device_ID} = " & Trim(_iDeviceID))
'        End Sub

'        Private Sub InternalPrint(ByVal strSelectionFormula As String)
'            'Dim rptApp As New CRAXDRT.Application()
'            'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(Me._strReportPath & "Bill_CreditCard.rpt")
'            Dim objRpt As ReportDocument

'            Try
'                objRpt = New ReportDocument()

'                With objRpt
'                    .Load(ConfigFile.GetBaseReportPath() & "Bill_CreditCard.rpt")
'                    .RecordSelectionFormula = strSelectionFormula
'                    .PrintToPrinter(2, True, 0, 0)
'                End With

'                'rpt.RecordSelectionFormula = strSelectionFormula
'                'rpt.PrintOut(False, 2)
'                'rpt = Nothing
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Public Sub Update()
'            Dim dtValue, dtReplace, dtLL, dtCT, dtDBR, dtCheckAgg, dtAB, dtCheckAggCust As DataTable
'            Dim drValue, drInt, drNoPart, drLL, drCT, drDBR, drCheckAgg, drAB, drAB1, drPart, drCheckAggCust As DataRow
'            Dim drPrice As DataRow()
'            Dim sf As New StackFrame(0)
'            Dim dsAB As PSS.Data.Production.Joins
'            Dim iRetInt, iRuleInt As Integer
'            Dim iCount As Integer = 0
'            Dim mRUR, mRTM As Double
'            Dim blnchargeNoPart As Boolean = True
'            Dim NoPartCount As Integer = 0
'            Dim strSQL As String
'            Dim strCheckField As String
'            Dim bExit As Boolean = False
'            Dim bSkipToAggBilling As Boolean = False
'            Dim iLL As Integer = 0
'            Dim iManufWrnty As Integer
'            Dim dABLabor As Double
'            Dim dblDefaultAmt As Double
'            Dim strFilter, strSort As String

'            Try
'                If Me._dtParts.Rows.Count = 0 Then UpdatePrice(0.0, Me._drDevice("Device_PSSWrty"), Me._drDevice("Device_ManufWrty")) : Exit Sub

'                drPrice = Me._dtLabor.Select("LaborLvl_ID = " & GetLaborLevel())

'                If drPrice.Length <> 1 Then
'                    drPrice = Me._dtLabor.Select("LaborLvl_ID = 0")

'                    If drPrice.Length <> 1 Then
'                        Me._objMisc.DisplayMessage(sf.GetMethod, "There is not enough information to bill this device. " & vbCrLf & _
'                                                        "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
'                                                        "Please CONTACT CUSTOMER SERVICE.", False)

'                        Exit Sub
'                    End If
'                End If

'                '//*************************************************************************************
'                '//June 16, 2006
'                '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
'                '//Check to see if value is RTM or RUR
'                iRetInt = 0

'                If Me._iCustID = 2019 Then '//ATCLE-AWS Customer
'                    For Each drInt In Me._dtParts.Rows
'                        iRuleInt = CheckPartRule(drInt("Billcode_ID"))

'                        If iRuleInt > iRetInt Then iRetInt = iRuleInt
'                    Next

'                    ' If no parts are used, then charge 6.85
'                    If iRuleInt < 1 Then
'                        For NoPartCount = 0 To Me._dtParts.Rows.Count - 1
'                            drNoPart = Me._dtParts.Rows(NoPartCount)

'                            If drNoPart("Billcode_ID") <> 442 And drNoPart("Billcode_ID") <> 447 And drNoPart("Billcode_ID") <> 448 And drNoPart("Billcode_ID") <> 255 Then
'                                blnchargeNoPart = False

'                                Exit For
'                            End If
'                        Next

'                        System.Windows.Forms.Application.DoEvents()

'                        If blnchargeNoPart = True Then
'                            bSkipToAggBilling = True
'                            dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE_ATCLE_AWS")

'                            UpdatePrice(dblDefaultAmt, False, Me._drDevice("Device_ManufWrty"))

'                            If Me._drDevice("PO_ID") < 1 Then Exit Sub
'                        End If
'                    End If

'                    If Me._drDevice("PO_ID") > 0 Then
'                        bSkipToAggBilling = True
'                        strSQL = "SELECT * " & Environment.NewLine
'                        strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                        strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                        If iRetInt = 1 Or iRetInt = 2 Then ' Set labor to RUR
'                            strCheckField = "PO_RUR"
'                        ElseIf iRetInt = 9 Then ' Set labor to RTM
'                            strCheckField = "PO_RTM"
'                        End If
'                    Else ' Get values from tcustmarkup
'                        bSkipToAggBilling = True
'                        strSQL = "SELECT * " & Environment.NewLine
'                        strSQL &= "FROM tcustmarkup " & Environment.NewLine
'                        strSQL &= "WHERE Cust_ID = " & Me._iCustID.ToString

'                        If iRetInt = 1 Or iRetInt = 2 Then ' Set labor to RUR
'                            strCheckField = "Markup_RUR"
'                        ElseIf iRetInt = 9 Then ' Set labor to RTM
'                            strCheckField = "Markup_RTM"
'                        End If
'                    End If ' Me._drDevice("PO_ID") > 0

'                    If CheckValue(strSQL, strCheckField) Then Exit Sub
'                End If ' Me._iCustID = 2019

'                '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
'                '//June 16, 2006
'                '//*************************************************************************************
'                If Not bSkipToAggBilling Then
'                    dtReplace = PSS.Data.Production.Joins.ReplacePhone(Me._iDeviceID)

'                    If Me._drDevice("PO_ID") > 0 Then
'                        lCustomPrice(drPrice(0))
'                    ElseIf Me._drDevice("Device_PSSWrty") Then
'                        lPSSPrice(drPrice(0))
'                    ElseIf Me._drDevice("Device_ManufWrty") > 0 Then
'                        dtLL = PSS.Data.Production.Joins.MaxLaborLevel(Me._iDeviceID)

'                        If Not IsNothing(dtLL) Then
'                            If dtLL.Rows.Count > 0 Then
'                                If Not IsDBNull(dtLL.Rows(0)) Then
'                                    drLL = dtLL.Rows(0)
'                                    iLL = drLL("LaborLevel")
'                                End If
'                            End If
'                        End If

'                        Me._iLaborLevel = iLL

'                        If iLL > 0 Then
'                            lRegPrice(drPrice(0))
'                            iLL = 0
'                            iManufWrnty = 0
'                        Else
'                            lManufPrice(drPrice(0))
'                            iManufWrnty = Me._drDevice("Device_ManufWrty")
'                        End If

'                        If Not IsNothing(dtReplace) Then
'                            If dtReplace.Rows.Count > 0 Then UpdatePrice(dtReplace.Rows(0)("Markup_Replacement"), False, iManufWrnty)
'                        End If
'                    Else
'                        lRegPrice(drPrice(0))

'                        If Not IsNothing(dtReplace) Then
'                            If dtReplace.Rows.Count > 0 Then UpdatePrice(dtReplace.Rows(0)("Markup_Replacement"), False, 0)
'                        End If
'                    End If
'                End If

'                drPrice = Nothing

'                If Me._booWrnty = True Then AndAlso PSS.Data.Buisness.Generic.GetDeviceCntInAscbill(_ID) = 0 ManufWrty()

'                DeviceBilling.SetBiller(Me._strUserFullName, Me._drDevice("Tray_ID"))

'                '//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
'                '//START
'                If Me._iCustID = 2069 Then '//Customer is AWS, Inc.
'                    If Me._bDBR = True Then
'                        '//Device is being DBR'd
'                        '//Determine percentage of dbr against total number in workorder
'                        strSQL = "SELECT COUNT(Device_ID) AS woTotal " & Environment.NewLine
'                        strSQL &= "FROM tdevice " & Environment.NewLine
'                        strSQL &= "WHERE WO_ID = " & Me._drDevice("wo_id") & " " & Environment.NewLine
'                        strSQL &= "GROUP BY WO_ID"

'                        dtCT = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                        If Not IsNothing(dtCT) Then
'                            If dtCT.Rows.Count > 0 Then
'                                drCT = dtCT.Rows(0)

'                                strSQL = "SELECT distinct COUNT(tdevice.device_ID) AS dbrTotal " & Environment.NewLine
'                                strSQL &= "FROM tdevice " & Environment.NewLine
'                                strSQL &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
'                                strSQL &= "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
'                                strSQL &= "WHERE tdevice.wo_id = " & Me._drDevice("WO_ID") & " AND lbillcodes.billcode_rule in (1, 2)"

'                                dtDBR = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)

'                                If Not IsNothing(dtDBR) Then
'                                    If dtDBR.Rows.Count > 0 Then
'                                        drDBR = dtDBR.Rows(0)

'                                        If CInt(drDBR("dbrTotal")) > CInt(drCT("woTotal")) * 0.2 Then
'                                            '//Dbr margin has been exceeded
'                                            If Me._iDeviceID > 0 Then
'                                                '//Update the laborlevel value
'                                                dblDefaultAmt = Me._objMisc.GetDefaultAmount("DEVICE_LABOR_CHARGE")

'                                                strSQL = "UPDATE tdevice " & Environment.NewLine
'                                                strSQL &= "SET device_laborcharge =  " & dblDefaultAmt.ToString & " " & Environment.NewLine
'                                                strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                                                PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
'                                                System.Windows.Forms.Application.DoEvents()
'                                            End If
'                                        End If
'                                    End If ' dtdbr.Rows.Count > 0
'                                End If ' Not IsNothing(dtDBR)
'                            End If ' dtct.Rows.Count > 0
'                        End If ' Not IsNothing(dtCT)
'                    End If ' Me._bDBR = True
'                End If ' Me._iCustID = 2069
'                '//END

'AggBilling:
'                '//This is to perform cumulative billing - January 27, 2006
'                dABLabor = 0.0

'                If Me._drDevice("PO_ID") > 0 Then
'                    strSQL = "SELECT * " & Environment.NewLine
'                    strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                    strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                    dtCheckAgg = dsAB.OrderEntrySelect(strSQL)

'                    If Not IsNothing(dtCheckAgg) Then
'                        If dtCheckAgg.Rows.Count > 0 Then
'                            drCheckAgg = dtCheckAgg.Rows(0)

'                            strSQL = "SELECT * " & Environment.NewLine
'                            strSQL &= "FROM tpoaggregatebilling " & Environment.NewLine
'                            strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                            dtAB = dsAB.OrderEntrySelect(strSQL)

'                            If Not IsNothing(dtAB) Then
'                                If dtAB.Rows.Count > 0 Then
'                                    '//Iterate through billcodes to determine proper labor charge
'                                    dABLabor = 0.0

'                                    For Each drAB In Me._dtParts.Rows
'                                        For Each drAB1 In dtAB.Rows
'                                            If drAB("BillCode_ID") = drAB1("BillCode_ID") Then
'                                                dABLabor += drAB1("tpab_Amount")

'                                                If Me._iDeviceID > 0 And drAB("BillCode_ID") > 0 Then
'                                                    strSQL = "UPDATE tdevicebill " & Environment.NewLine
'                                                    strSQL &= "SET dbill_invoiceamt = 0.00 " & Environment.NewLine
'                                                    strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString & " AND billcode_ID = " & drAB("BillCode_ID")

'                                                    dsAB.OrderEntryUpdateDelete(strSQL)
'                                                End If

'                                                Exit For
'                                            End If
'                                        Next
'                                    Next

'                                    '//Now the total sum should be here
'                                    If drCheckAgg("PO_Aggregate") = 1 Then UpdatePrice(dABLabor, False, Me._drDevice("Device_ManufWrty"))
'                                End If ' dtAB.Rows.Count > 0
'                            End If ' Not IsNothing(dtAB)
'                        End If ' dtCheckAgg.Rows.Count > 0
'                    End If ' Not IsNothing(dtCheckAgg)

'                    '//Check to see if value is RTM or RUR
'                    ''//Get maximum billcode rule
'                    iRetInt = 0

'                    For Each drPart In Me._dtParts.Rows
'                        iRuleInt = CheckPartRule(drPart("Billcode_ID"))

'                        If iRuleInt > iRetInt Then iRetInt = iRuleInt
'                    Next

'                    strSQL = "SELECT * " & Environment.NewLine
'                    strSQL &= "FROM tpurchaseorder " & Environment.NewLine
'                    strSQL &= "WHERE PO_ID = " & Me._drDevice("PO_ID")

'                    If Not IsNothing(dtValue) Then dtValue.Dispose()
'                    dtValue = dsAB.OrderEntrySelect(strSQL)

'                    If Not IsNothing(dtValue) Then
'                        If dtValue.Rows.Count > 0 Then
'                            drValue = dtValue.Rows(0)

'                            If iRetInt = 1 Or iRetInt = 2 Then ' If iRetInt = 1 or 2 then set labor to RUR
'                                If drValue("PO_RUR") > 0 Then UpdatePrice(drValue("PO_RUR"), False, Me._drDevice("Device_ManufWrty"))
'                            ElseIf iRetInt = 9 Then ' If iRetInt = 9 then set labor to RTM
'                                If drValue("PO_RTM") > 0 Then UpdatePrice(drValue("PO_RTM"), False, Me._drDevice("Device_ManufWrty"))
'                            End If
'                        End If ' dtValue.Rows.Count > 0
'                    End If ' Not IsNothing(dtValue)
'                Else
'                    strSQL = "SELECT * " & Environment.NewLine
'                    strSQL &= "FROM tcustomer " & Environment.NewLine
'                    strSQL &= "WHERE Cust_ID = " & Me._drDevice("Cust_ID")

'                    dtCheckAggCust = dsAB.OrderEntrySelect(strSQL)

'                    If Not IsNothing(dtCheckAggCust) Then
'                        If dtCheckAggCust.Rows.Count > 0 Then
'                            drCheckAggCust = dtCheckAggCust.Rows(0)

'                            strSQL = "SELECT * " & Environment.NewLine
'                            strSQL &= "FROM tcustaggregatebilling " & Environment.NewLine
'                            strSQL &= "WHERE Cust_ID = " & Me._drDevice("Cust_ID")

'                            If Not IsNothing(dtAB) Then dtAB.Dispose()
'                            dtAB = dsAB.OrderEntrySelect(strSQL)

'                            If Not IsNothing(dtAB) Then
'                                If dtAB.Rows.Count > 0 Then
'                                    '//Iterate through billcodes to determine proper labor charge
'                                    dABLabor = 0.0
'                                    dblDefaultAmt = Me._objMisc.GetDefaultAmount("DBILL_INVOICE_AMT")

'                                    For Each drAB In Me._dtParts.Rows
'                                        For Each drAB1 In dtAB.Rows
'                                            If drAB("BillCode_ID") = drAB1("BillCode_ID") Then
'                                                dABLabor += drAB1("tcab_Amount")

'                                                If Me._iDeviceID > 0 And drAB("BillCode_ID") > 0 Then
'                                                    strSQL = "UPDATE tdevicebill "
'                                                    strSQL &= "SET dbill_invoiceamt = " & dblDefaultAmt.ToString & " "
'                                                    strSQL &= "WHERE device_id = " & Me._iDeviceID & " AND billcode_ID = " & drAB("BillCode_ID")

'                                                    dsAB.OrderEntryUpdateDelete(strSQL)
'                                                End If

'                                                Exit For
'                                            End If ' drAB("BillCode_ID") = drAB1("BillCode_ID")
'                                        Next ' drAB1 In dtAB.Rows
'                                    Next ' drAB In Me._dtParts.Rows

'                                    ' Now the total sum should be here
'                                    If drCheckAggCust("Cust_AggBilling") = 1 Then UpdatePrice(dABLabor, False, Me._drDevice("Device_ManufWrty"))
'                                End If ' dtAB.Rows.Count > 0
'                            End If ' Not IsNothing(dtAB)
'                        End If ' dtCheckAggCust.Rows.Count > 0
'                    End If ' Not IsNothing(dtCheckAggCust)
'                End If ' Me._drDevice("PO_ID") > 0

'                ' This is to perform cumulative billing - January 27, 2006
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                drValue = Nothing
'                drInt = Nothing
'                drNoPart = Nothing
'                drLL = Nothing
'                drCT = Nothing
'                drDBR = Nothing
'                drCheckAgg = Nothing
'                drAB = Nothing
'                drAB1 = Nothing
'                drPart = Nothing
'                drCheckAggCust = Nothing
'                drPrice = Nothing

'                If Not IsNothing(dtValue) Then
'                    dtValue.Dispose()
'                    dtValue = Nothing
'                End If

'                If Not IsNothing(dtReplace) Then
'                    dtReplace.Dispose()
'                    dtReplace = Nothing
'                End If

'                If Not IsNothing(dtLL) Then
'                    dtLL.Dispose()
'                    dtLL = Nothing
'                End If

'                If Not IsNothing(dtCT) Then
'                    dtCT.Dispose()
'                    dtCT = Nothing
'                End If

'                If Not IsNothing(dtDBR) Then
'                    dtDBR.Dispose()
'                    dtDBR = Nothing
'                End If

'                If Not IsNothing(dtCheckAgg) Then
'                    dtCheckAgg.Dispose()
'                    dtCheckAgg = Nothing
'                End If

'                If Not IsNothing(dtAB) Then
'                    dtAB.Dispose()
'                    dtAB = Nothing
'                End If

'                If Not IsNothing(dtCheckAggCust) Then
'                    dtCheckAggCust.Dispose()
'                    dtCheckAggCust = Nothing
'                End If
'            End Try
'        End Sub

'        'Private Function GetDefaultAmount(ByVal strShortDesc As String) As Double
'        '    Dim dblDefaultAmount As Double = 0
'        '    Dim strAmt As String = ""
'        '    Dim strSQL As String
'        '    Dim sf As New StackFrame(0)

'        '    Try
'        '        If strShortDesc.Length > 0 Then
'        '            strSQL = "SELECT Value" & Environment.NewLine
'        '            strSQL &= "FROM lConstants " & Environment.NewLine
'        '            strSQL &= "WHERE UPPER(ShortDesc) = " & strShortDesc.Trim.ToUpper

'        '            strAmt = Me._objMisc.GetSingletonString(strSQL)

'        '            If strAmt.Length > 0 Then dblDefaultAmount = CDbl(strAmt)
'        '        End If

'        '        Return dblDefaultAmount
'        '    Catch ex As Exception
'        '        Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'        '    End Try
'        'End Function

'        Private Function CheckValue(ByVal strSQL As String, ByVal strCheckField As String) As Boolean
'            Dim bExitCalling As Boolean = False
'            Dim prj As PSS.Data.Production.Joins
'            Dim dtValue As DataTable
'            Dim drValue As DataRow
'            Dim dValue As Double
'            Dim sf As New StackFrame(0)

'            Try
'                dtValue = prj.OrderEntrySelect(strSql)

'                If Not IsNothing(dtValue) Then
'                    If dtValue.Rows.Count > 0 Then
'                        drValue = dtValue.Rows(0)

'                        If Not IsDBNull(drValue(strCheckField)) Then
'                            dValue = drValue(strCheckField)

'                            If dValue > 0 Then
'                                UpdatePrice(dValue, False, Me._drDevice("Device_ManufWrty"))

'                                If Me._drDevice("PO_ID") < 1 Then bExitCalling = True
'                            End If
'                        End If
'                    End If
'                End If

'                Return bExitCalling
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                drValue = Nothing

'                If Not IsNothing(dtValue) Then
'                    dtValue.Dispose()
'                    dtValue = Nothing
'                End If
'            End Try
'        End Function

'        Private Function GetLaborLevel() As Integer
'            Dim dr1, drRptGrp As DataRow
'            Dim dr2 As DataRow() = Nothing
'            Dim dtRptGrp, dtLLO As DataTable
'            Dim strSQL As String
'            Dim sf As New StackFrame(0)

'            Try
'                Me._iLaborLevel = 0

'                For Each dr1 In Me._dtParts.Rows
'                    dr2 = Me._dtBillable.Select("BillCode_ID = " & dr1("BillCode_ID"))

'                    If CInt(dr2(0)("LaborLvl_ID")) > Me._iLaborLevel Then
'                        If Me._drDevice("Cust_ID") = 1 Then
'                            strSQL = "SELECT * " & Environment.NewLine
'                            strSQL &= "FROM tmodel " & Environment.NewLine
'                            strSQL &= "WHERE Model_ID = " & Me._drDevice("Model_ID")

'                            dtRptGrp = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
'                            drRptGrp = dtRptGrp.Rows(0)

'                            strSQL = "SELECT * " & Environment.NewLine
'                            strSQL &= "FROM tlaboroverrides " & Environment.NewLine
'                            strSQL &= "WHERE Cust_ID = " & Me._drDevice("Cust_ID") & " AND rptgrp_id = " & drRptGrp("rptgrp_id") & " AND billcode_id = " & dr1("billcode_ID")

'                            dtLLO = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)

'                            If dtLLO.Rows.Count > 0 Then
'                                If Me._iLaborLevel > 2 Then
'                                ElseIf Me._iLaborLevel < 2 Then
'                                    Me._iLaborLevel = 2
'                                End If                                                  '
'                            Else
'                                Me._iLaborLevel = CInt(dr2(0)("LaborLvl_ID"))
'                            End If
'                        Else
'                            Me._iLaborLevel = CInt(dr2(0)("LaborLvl_ID"))
'                        End If ' Me._drDevice("Cust_ID") = 1
'                    End If  ' CInt(dr2(0)("LaborLvl_ID")) > Me._iLaborLevel                                             
'                Next

'                Return Me._iLaborLevel
'            Catch ex As Exception
'                If Not IsNothing(dr2) Then
'                    If Not IsDBNull(dr2(0)("LaborLvl_ID")) Then
'                        Me._iLaborLevel = CInt(dr2(0)("LaborLvl_ID"))
'                    End If
'                End If

'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            Finally
'                dr1 = Nothing
'                dr2 = Nothing
'                drRptGrp = Nothing

'                If Not IsNothing(dtRptGrp) Then
'                    dtRptGrp.Dispose()
'                    dtRptGrp = Nothing
'                End If

'                If Not IsNothing(dtLLO) Then
'                    dtLLO.Dispose()
'                    dtLLO = Nothing
'                End If
'            End Try
'        End Function

'        Private Sub ManufWrty()
'            DeviceBilling.InsertWarranty(Me._iDeviceID, Me._dtBillable.Rows(0)("ASCPrice_Price"), Me._dtBillable.Rows(0)("ASCPrice_ID"), _
'                                                     Me._dtBillable.Rows(0)("Prod_ID"), Me._dtBillable.Rows(0)("Manuf_ID"))
'        End Sub

'#Region "Parts"
'        Private Function Price(ByVal objStandardPrice As Object, ByVal iType As Integer) As Double
'            Dim sf As New StackFrame(0)

'            Try
'                If IsDBNull(objStandardPrice) Then
'                    Return 0.0
'                ElseIf iType = 1 Then 'Service
'                    Return objStandardPrice
'                Else 'Everything else
'                    Return Math.Round(objStandardPrice * (Me._drDevice("Cust_Markup") + 1), 2)
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function

'        Private Function pCustomPrice(ByVal dr As DataRow) As Double
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._drDevice("PlusParts") Then
'                    Return Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                Else
'                    Return 0
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function

'        Private Function pPSSPrice(ByVal dr As DataRow) As Double
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._drDevice("PSSWrtyParts_ID") = 1 Then
'                    Return pRegPrice(dr)
'                ElseIf Me._drDevice("PSSWrtyParts_ID") = 2 Then
'                    Return 0
'                ElseIf Me._drDevice("PSSWrtyParts_ID") = 3 Then
'                    Return Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function

'        Private Function pManufPrice(ByVal dr As DataRow) As Double
'            Dim sf As New StackFrame(0)

'            Try
'                If dr("BillCode_Rule") = 3 And Me._drDevice("Device_ManufWrty") <> 2 Then
'                    If Me._drDevice("Cust_RepairNonWrty") Then
'                        Return Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                    Else
'                        Return 0
'                    End If
'                Else
'                    If Me._drDevice("Prod_ID") = 2 Then
'                        Return 0
'                    Else
'                        If Me._drDevice("PlusParts") Then
'                            If Me._drDevice("Device_ManufWrty") > 0 Then
'                                Return 0
'                            Else
'                                Return pRegPrice(dr)
'                            End If
'                        Else
'                            Return 0
'                        End If
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function

'        Private Function pRegPrice(ByVal dr As DataRow) As Double
'            Dim iExPart As Integer = 0
'            Dim dRet As Double = 0
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._drDevice("Cust_RepairNonWrty") Then
'                    If Me._drDevice("PlusParts") = False Then
'                        iExPart = DeviceBilling.GetExcepCode(dr("BillCode_ID"), Me._drDevice("PoductGroup"), Me._drDevice("PricingGroup"))(0)

'                        If iExPart <> 0 Then dRet = Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                    Else
'                        dRet = Price(dr("PSPrice_StndCost"), dr("BillType_ID"))
'                    End If
'                End If

'                Return dRet
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Function
'#End Region

'#Region "Labor"
'        Private Sub UpdatePrice(ByVal dPrice As Double, ByVal bPSSWrty As Boolean, ByVal iManufWrty As Integer)
'            Dim bAutoShip As Boolean = False
'            Dim sf As New StackFrame(0)
'            Dim decServiceCharge As Decimal = 0.0

'            Try
'                If Me._drDevice("Device_ManufWrty") > 0 Then iManufWrty = Me._drDevice("Device_ManufWrty")
'                If Me._drDevice("Cust_AutoShip") = 1 And Me._bDBR = True Then bAutoShip = True

'                If Me._dtParts.Rows.Count = 0 Then
'                    DeviceBilling.SetLaborData(Me._iDeviceID, 0.0, bPSSWrty, iManufWrty, 0, "NULL", bAutoShip, Me._drDevice("Loc_Id"), Me._strIDShift, Me._strWorkDate)
'                Else
'                    decServiceCharge = DeviceBilling.GetServiceCharge(Me._iDeviceID, Me._iCustID)
'                    dPrice += decServiceCharge
'                    DeviceBilling.SetLaborData(Me._iDeviceID, dPrice, bPSSWrty, iManufWrty, Me._iLaborLevel, Me._strFormattedDate, bAutoShip, Me._drDevice("Loc_Id"), Me._strIDShift, Me._strWorkDate)
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub lCustomPrice(ByVal dr As DataRow)
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._drDevice("PO_ChgWrty") And Me._drDevice("Device_ManufWrty") > 0 Then
'                    Me._booWrnty = True
'                End If

'                'Since we  model our data the right way we can just call regular pricing.
'                lRegPrice(dr)
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub lPSSPrice(ByVal dr As DataRow)
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._bDBR Then
'                    UpdatePrice(Me._drDevice("RUR_Price"), False, 0)
'                ElseIf Me._booNTF Then
'                    UpdatePrice(Me._drDevice("NTF_Price"), False, 0)
'                Else
'                    If Me._drDevice("PSSWrtyLabor_ID") = 1 Then
'                        lRegPrice(dr)
'                    ElseIf Me._drDevice("PSSWrtyLabor_ID") = 2 Then
'                        UpdatePrice(0, True, 0)
'                    ElseIf Me._drDevice("PSSWrtyLabor_ID") = 4 Then
'                        If Me._iLaborLevel < 3 Then
'                            lRegPrice(dr)
'                        Else
'                            UpdatePrice(0, Me._drDevice("Device_PSSWrty"), 0)
'                        End If
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub lManufPrice(ByVal dr As DataRow)
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._bDBR Then
'                    UpdatePrice(Me._drDevice("RUR_Price"), False, 0)
'                ElseIf Me._booNTF Then
'                    UpdatePrice(Me._drDevice("NTF_Price"), False, 0)
'                Else
'                    Me._booWrnty = True
'                    UpdatePrice(dr("LaborPrc_WrtyPrc"), False, Me._drDevice("Device_ManufWrty"))
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub

'        Private Sub lRegPrice(ByVal dr As DataRow)
'            Dim sf As New StackFrame(0)

'            Try
'                If Me._drDevice("Cust_RepairNonWrty") Then
'                    If Me._bDBR Then
'                        UpdatePrice(Me._drDevice("RUR_Price"), False, 0)
'                    ElseIf Me._booNTF Then
'                        UpdatePrice(Me._drDevice("NTF_Price"), False, 0)
'                    Else
'                        UpdatePrice(dr("LaborPrc_RegPrc"), False, 0)
'                    End If
'                End If
'            Catch ex As Exception
'                Me._objMisc.DisplayMessage(sf.GetMethod, ex.Message)
'            End Try
'        End Sub
'#End Region

'        Public Sub Dispose() Implements IDisposable.Dispose
'            Me._drDevice = Nothing
'            Me._dtParts.Dispose()
'            Me._dtParts = Nothing
'            Me._dtLabor.Dispose()
'            Me._dtLabor = Nothing
'            Me._dtBillable.Dispose()
'            Me._dtBillable = Nothing
'            Me._iLaborLevel = Nothing
'            Me._bDBR = False
'            Me._booNoParts = False
'            Me._booWrnty = False
'            Me._strCust = Nothing
'            Me._booCreditUser = False
'        End Sub

'        Protected Overrides Sub Finalize()
'            Me._objMisc = Nothing
'            MyBase.Finalize()
'        End Sub
'        '***************************************************************************

'#Region "Properties"
'        Public ReadOnly Property DefaultView() As DataView
'            Get
'                Return Me._dtParts.DefaultView
'            End Get
'        End Property

'        Public ReadOnly Property Billed() As Boolean
'            Get
'                If IsDate(_drDevice("Device_DateBill")) Then
'                    Return True
'                Else
'                    Return False
'                End If
'            End Get
'        End Property

'        Public ReadOnly Property DeviceID() As Integer
'            Get
'                Return Me._iDeviceID
'            End Get
'        End Property

'        Public ReadOnly Property Parts() As DataTable
'            Get
'                Return Me._dtParts
'            End Get
'        End Property

'        Public ReadOnly Property EndUser() As Boolean
'            Get
'                Return Me._booCreditUser
'            End Get
'        End Property

'        Public ReadOnly Property Customer() As String
'            Get
'                Return Me._strCust
'            End Get
'        End Property

'        Public ReadOnly Property CustID() As String
'            Get
'                Return Me._iCustID
'            End Get
'        End Property

'#End Region

'    End Class
'End Namespace

