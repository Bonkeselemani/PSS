'Namespace BaseClasses
'    'The base class for billing.  This class is abstract and cannot be instantiated.

'    Public MustInherit Class BillingBase
'        Private Const _strAllBillCodesTable = "All Bill Codes Data"
'        Private Const _strBilledCodesTable = "Billed Codes Data"
'        Private Const _strDeviceDetailsTable = "Device Details Data"

'        Private Const _iDBRBillCode = 25
'        Private Const _iNERBillCode = 89

'        Private _objDataProc As DBQuery.DataProc
'        Private _iCustomerID As Integer = 0
'        Private _iDeviceID As Integer = 0
'        Private _dsDeviceData As DataSet

'        Public Sub New(ByVal iCustID As Integer, ByVal iDeviceID As Integer)
'            Try
'                Me._iCustomerID = iCustID
'                Me._iDeviceID = iDeviceID

'                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'                Me._dsDeviceData = New DataSet("Device Data")

'                GetAllBillCodes()
'                GetDeviceDetailsData()
'                GetBilledCodes()
'            Catch ex As Exception
'                MsgBox(ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in BillingBase")
'            End Try
'        End Sub

'        Protected Overrides Sub Finalize()
'            Me._objDataProc = Nothing

'            MyBase.Finalize()
'        End Sub

'#Region "Overridable Methods"
'        Public Overridable Sub AddPart(ByVal iDeviceID As Integer, ByVal iBillCode As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String)
'            'Method for adding a part to a device.
'        End Sub

'        Public Overridable Sub Update(ByVal iDeviceID As Integer)
'            'Method for updating a device's parts and labor charges.
'        End Sub
'#End Region 'Overridable Methods

'#Region "NonOverridable Methods"

'        Private Sub GetDeviceDetailsData()
'            Dim strSQL As String = ""
'            Dim dt As DataTable

'            Try
'                strSQL &= "SELECT tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_Invoice IS NULL, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_ManufWrty IS NULL, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_PSSWrty IS NULL, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_Reject IS NULL, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_LaborLevel IS NULL, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Device_LaborCharge IS NULL, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
'                strSQL &= "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & Environment.NewLine
'                strSQL &= "IF(tdevice.Ship_ID IS NULL, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
'                strSQL &= "tdevice.Model_ID, " & Environment.NewLine
'                strSQL &= "IF(tdevice.WebInfo_ID IS NULL, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
'                strSQL &= "IF(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
'                strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
'                strSQL &= "tmodel.Prod_ID, " & Environment.NewLine
'                strSQL &= "IF(tworkorder.PO_ID IS NULL, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
'                strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
'                strSQL &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_Name1," & Environment.NewLine
'                strSQL &= "tcustomer.Cust_Name2," & Environment.NewLine
'                strSQL &= "tlocation.Loc_Name," & Environment.NewLine
'                strSQL &= "tcustomer.Pay_ID, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
'                strSQL &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
'                strSQL &= "IF(tcustomer.Cust_Name2 IS NULL, 0, 1) AS EndUser, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
'                strSQL &= "lpricinggroup.PrcType_ID,  tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip, " & Environment.NewLine
'                strSQL &= "tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
'                strSQL &= "FROM tmodel " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine
'                strSQL &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
'                strSQL &= "WHERE tdevice.Device_ID = " & Me._iDeviceID.ToString & " " & Environment.NewLine
'                strSQL &= "AND tdevice.Device_DateShip IS NULL " & Environment.NewLine
'                strSQL &= "AND tcustwrty.Prod_ID = tmodel.Prod_ID"

'                dt = Me.DataProc.GetDataTable(strSQL)

'                If Not IsNothing(dt) Then
'                    dt.TableName = Me._strDeviceDetailsTable
'                    Me._dsDeviceData.Tables.Add(dt)
'                End If
'            Catch ex As Exception
'                Throw ex
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        'The following sub should probably be elsewhere, since it retrieves general data not directly related ot an individual device.
'        Private Sub GetAllBillCodes()
'            'Gets all possible bill codes for a device.
'            'Product IDs (see query):
'            '    1 = Messaging
'            '    2 = Cellular
'            '    5 = GameStop
'            '    6 = GPS
'            Dim strSQL As String
'            Dim dt As DataTable

'            Try
'                strSQL = "SELECT C.BillCode_ID, C.BillCode_Desc " & Environment.NewLine
'                strSQL &= "FROM tdevice A " & Environment.NewLine
'                strSQL &= "INNER JOIN tmodel B ON B.Model_Id = A.Model_ID " & Environment.NewLine
'                strSQL &= "INNER JOIN lbillcodes C ON C.Device_ID = B.Prod_ID " & Environment.NewLine 'Device ID here corresponds to product ID
'                strSQL &= "WHERE A.Device_ID = " & Me._iDeviceID.ToString & " " & Environment.NewLine
'                strSQL &= "AND C.BillCode_ID > 0 " & Environment.NewLine
'                strSQL &= "ORDER BY C.BillCode_ID"

'                dt = Me._objDataProc.GetDataTable(strSQL)

'                If Not IsNothing(dt) Then
'                    dt.TableName = Me._strAllBillCodesTable
'                    Me._dsDeviceData.Tables.Add(dt)
'                End If
'            Catch ex As Exception
'                Throw ex
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub GetBilledCodes()
'            'Get codes already billed to a device.
'            Dim strSQL As String
'            Dim dt As DataTable
'            Dim dr As DataRow

'            Try
'                If Me._dsDeviceData.Tables.IndexOf(Me._strBilledCodesTable) > -1 Then Me._dsDeviceData.Tables(Me._strBilledCodesTable).Clear()

'                strSQL = "SELECT DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, BillCode_ID, Fail_ID, Repair_ID, User_ID " & Environment.NewLine
'                strSQL &= "FROM tdevicebill " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString & " " & Environment.NewLine
'                strSQL &= "ORDER BY BillCode_ID"

'                dt = Me._objDataProc.GetDataTable(strSQL)

'                If IsNothing(dt) Then dt = CreateBilledCodesTable() ' Create the table w/o rows

'                dt.TableName = Me._strBilledCodesTable

'                If Me._dsDeviceData.Tables.IndexOf(Me._strBilledCodesTable) = -1 Then
'                    Me._dsDeviceData.Tables.Add(dt)
'                Else
'                    For Each dr In dt.Rows
'                        Me._dsDeviceData.Tables(Me._strBilledCodesTable).ImportRow(dr)
'                    Next dr
'                End If
'            Catch ex As Exception
'                Throw ex
'            Finally
'                dr = Nothing

'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Sub

'        Private Function CreateBilledCodesTable() As DataTable
'            Dim dt As DataTable

'            Try
'                dt = New DataTable()

'                dt.Columns.Add(New DataColumn("DBill_AvgCost", System.Type.GetType("System.Decimal")))
'                dt.Columns.Add(New DataColumn("DBill_StdCost", System.Type.GetType("System.Decimal")))
'                dt.Columns.Add(New DataColumn("DBill_InvoiceAmt", System.Type.GetType("System.Decimal")))
'                dt.Columns.Add(New DataColumn("BillCode_ID", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Fail_ID", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("Repair_ID", System.Type.GetType("System.Int32")))
'                dt.Columns.Add(New DataColumn("User_ID", System.Type.GetType("System.Int32")))

'                Return dt
'            Catch ex As Exception
'                Throw ex
'            Finally
'                If Not IsNothing(dt) Then
'                    dt.Dispose()
'                    dt = Nothing
'                End If
'            End Try
'        End Function

'        Private Function GetLaborLevel(Optional ByVal iNewBillCodeID As Integer = -1) As Integer
'            'iNewBillCodeID is the bill code for a new part being added to the device.
'            Dim iLaborLevel As Integer = 0
'            Dim strSQL As String
'            Dim dtBillable As DataTable
'            Dim strBillCodeIDIn As String
'            Dim dr As DataRow
'            Dim iModelID As Integer

'            Try
'                If (IsNothing(Me._dsDeviceData.Tables(Me._strBilledCodesTable)) Or Me._dsDeviceData.Tables(Me._strBilledCodesTable).Rows.Count = 0) And iNewBillCodeID = -1 Then
'                    Me._objDataProc.DisplayMessage("Neither bill codes values for parts already belonging to this device nor has a new part been added to this device.   The labor level can't be determined.")

'                    Return iLaborLevel '= 0
'                End If

'                strBillCodeIDIn = ""

'                For Each dr In Me._dsDeviceData.Tables(Me._strBilledCodesTable).Rows
'                    If strBillCodeIDIn.Length > 0 Then strBillCodeIDIn &= ", "

'                    strBillCodeIDIn &= dr("BillCode_ID").ToString
'                Next

'                If iNewBillCodeID > -1 Then
'                    If strBillCodeIDIn.Length > 0 Then strBillCodeIDIn &= ", "

'                    strBillCodeIDIn &= iNewBillCodeID.ToString
'                End If

'                If strBillCodeIDIn.Length > 0 Then
'                    strSQL = "SELECT Model_ID " & Environment.NewLine
'                    strSQL &= "FROM tdevice " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                    iModelID = Me._objDataProc.GetIntValue(strSQL)

'                    strSQL = "SELECT MAX(LaborLevel) " & Environment.NewLine
'                    strSQL &= "FROM tpsmap " & Environment.NewLine
'                    strSQL &= "WHERE BillCode_ID IN (" & strBillCodeIDIn & ") " & Environment.NewLine
'                    strSQL &= "AND Model_ID = " & iModelID.ToString

'                    iLaborLevel = Me._objDataProc.GetIntValue(strSQL)
'                End If

'                Return iLaborLevel
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        Public Sub PartTransaction(ByVal iProdID As Integer, ByVal iBillCodeID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String, ByVal bAddPart As Boolean)
'            Dim strSQL As String = ""
'            Dim iTransAmount As Integer
'            Dim iCC_ID As Integer = PSS.Data.Buisness.Generic.GetMachineCostCenterID
'            Dim iLastBillCCID As Integer = 0

'            Try
'                '*******************************
'                'Get Cost Center ID
'                '*******************************
'                iCC_ID = PSS.Data.Buisness.Generic.GetMachineCostCenterID
'                If iCC_ID = 31 Or iCC_ID = 0 Then     'Special Cost Center use by supervisors and leaders
'                    'Use device's cost center instead of machine's cost center
'                    iCC_ID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(Me._iDeviceID)
'                End If
'                '*******************************

'                If bAddPart Then
'                    iTransAmount = 1
'                Else
'                    iTransAmount = -1

'                    '*******************************
'                    ''Added on 06/11/2009
'                    ''For unbill unit, use CC ID where the part get bill
'                    '*******************************
'                    iLastBillCCID = PSS.Data.Buisness.Generic.GetLastBillCCID(Me._iDeviceID, iBillCodeID)
'                    If iLastBillCCID > 0 Then iCC_ID = iLastBillCCID
'                    '*******************************
'                End If

'                strSQL &= "INSERT INTO tparttransaction (Prod_ID, Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo, Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server, cc_id) " & Environment.NewLine
'                strSQL &= "VALUES (" & iProdID & ", " & Me._iDeviceID.ToString & ", " & iBillCodeID.ToString & ", " & iUserID.ToString & ", '" & strDateRec & "', " & iEmployeeNum.ToString & "," & iTransAmount.ToString & ", " & iShiftID.ToString & ", '" & strWorkDate & "', '" & strMachineName & "', 1, '" & strServerDate & "', " & iCC_ID & ")"

'                Me._objDataProc.ExecuteNonQuery(strSQL)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'        Public Function IsValidDeviceBillCode(ByVal iDeviceID As Integer, ByVal iBillCodeID As Integer) As Boolean
'            Dim bIsValidDeviceBillCode As Boolean = False
'            Dim strSQL As String
'            Dim iModelID As Integer = 0
'            Dim iCnt As Integer

'            Try
'                strSQL = "SELECT A.model_id " & Environment.NewLine
'                strSQL &= "FROM tmodel A " & Environment.NewLine
'                strSQL &= "INNER JOIN tdevice B ON B.model_id = A.model_id " & Environment.NewLine
'                strSQL &= "WHERE B.device_id = " & iDeviceID.ToString

'                iModelID = Me._objDataProc.GetIntValue(strSQL)

'                If iModelID > 0 Then
'                    strSQL = "SELECT COUNT(*) " & Environment.NewLine
'                    strSQL &= "FROM tpsmap " & Environment.NewLine
'                    strSQL &= "WHERE model_id = " & iModelID.ToString & " " & Environment.NewLine
'                    strSQL &= "AND billcode_id = " & iBillCodeID.ToString

'                    iCnt = Me._objDataProc.GetIntValue(strSQL)

'                    If iCnt > 0 Then bIsValidDeviceBillCode = True
'                End If

'                Return bIsValidDeviceBillCode
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function

'        Public Sub DeletePart(ByVal iProdID As Integer, ByVal iBillCodeID As Integer, ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String)
'            Dim strSQL As String = ""

'            Try
'                strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString & " AND BillCode_ID = " & iBillCodeID.ToString

'                If Me.DataProc.ExecuteNonQuery(strSQL) > 0 Then
'                    PartTransaction(iProdID, iBillCodeID, iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate, False)
'                    DBRNERDelete(iBillCodeID)
'                    GetBilledCodes()
'                End If
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'        Public Sub DeleteAllParts(ByVal iUserID As Integer, ByVal strDateRec As String, ByVal iEmployeeNum As Integer, ByVal iShiftID As Integer, ByVal strWorkDate As String, ByVal strMachineName As String, ByVal strServerDate As String)
'            Dim strSQL As String = ""
'            'Dim drParts, drDevice As DataRow
'            'Dim iIndex, iCode As Integer
'            Dim dr() As DataRow

'            Try
'                strSQL &= "DELETE FROM tdevicebill " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                If Me.DataProc.ExecuteNonQuery(strSQL) > 0 Then
'                    dr = Me._dsDeviceData.Tables(Me._strBilledCodesTable).Select("BillCode_ID = " & Me._iDBRBillCode.ToString & " OR BillCode_ID = " & Me._iNERBillCode.ToString)

'                    If dr.Length > 0 Then DBRNERDelete(dr(0)("BillCode_ID"))

'                    GetBilledCodes()

'                    'strSQL = "UPDATE tdevice " & Environment.NewLine
'                    'strSQL &= "SET Device_DateBill = NULL, Device_LaborCharge = 0, Device_LaborLevel = 0 " & Environment.NewLine
'                    'strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString

'                    'Me.DataProc.ExecuteNonQuery(strSQL)

'                    'If Me.DataProc.ExecuteNonQuery(strSQL) > 0 Then 
'                    'If Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("Device_ID = " & iDeviceID.ToString & " AND (Code = 25 OR Code = 89)").Length > 0 Then
'                    '    dr = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Select("Device_ID = " & iDeviceID.ToString & " AND (Code = 25 OR Code = 89)")

'                    '    DBRNERDelete(iDeviceID, dr(0)("Code"))
'                    'End If

'                    'For iIndex = 0 To Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows.Count - 1
'                    '    drDevice = Me._dsDeviceTrayByID.Tables(Me._strDeviceTableName).Rows(iIndex)

'                    '    If drDevice("Device_ID") = iDeviceID Then
'                    '        drDevice.BeginEdit()
'                    '        drDevice("Bill Date") = DBNull.Value
'                    '        drDevice.EndEdit()
'                    '        drDevice.AcceptChanges()
'                    '    End If
'                    'Next
'                    'End If

'                    'For iIndex = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows.Count - 1 To 0 Step -1
'                    '    drParts = Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows(iIndex)

'                    '    If drParts("Device_ID") = iDeviceID Then
'                    '        PartTransaction(iDeviceID, drParts("Code"), iUserID, strDateRec, iEmployeeNum, iShiftID, strWorkDate, strMachineName, strServerDate, False)

'                    '        Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).Rows(iIndex).Delete()
'                    '    End If
'                    'Next

'                    'Me._dsDeviceTrayByID.Tables(Me._strTrayTableName).AcceptChanges()
'                End If
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'        Private Sub DBRNERAdd(ByVal iBillCodeID As Integer)
'            Dim strSQL As String
'            Dim strDate As String

'            Try
'                If iBillCodeID = Me._iDBRBillCode Or iBillCodeID = Me._iNERBillCode Then 'Add DBR/NER
'                    strDate = PSS.Data.Buisness.Generic.MySQLServerDateTime(1)

'                    strSQL = "UPDATE tdevice " & Environment.NewLine
'                    strSQL &= "SET Device_DateShip = '" & strDate & "', Device_ShipWorkDate = '" & Format(CDate(strDate), "yyyy-MM-dd") & "', ship_id = 9999919, Shift_ID_Ship = 1 " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                    Me._objDataProc.ExecuteNonQuery(strSQL)
'                End If
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'        Private Sub DBRNERDelete(ByVal iBillCodeID As Integer)
'            Dim strSQL As String

'            Try
'                If iBillCodeID = Me._iDBRBillCode Or iBillCodeID = Me._iNERBillCode Then 'Drop DBR/NER
'                    strSQL = "UPDATE tdevice " & Environment.NewLine
'                    strSQL &= "SET Device_DateShip = NULL, Device_ShipWorkDate = NULL, ship_id = NULL, Shift_ID_Ship = 0 " & Environment.NewLine
'                    strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                    Me.DataProc.ExecuteNonQuery(strSQL)

'                    strSQL = "DELETE FROM tdevicecodes " & Environment.NewLine
'                    strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString

'                    Me.DataProc.ExecuteNonQuery(strSQL)
'                End If
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'        Private Sub UpdateDeviceLaborData(Optional ByVal iBillCode As Integer = -1)
'            Dim drPricingType(), drLaborPrc As DataRow
'            Dim iPricingType, iProductGroupID, iProdID, iPrcGroupID, iLaborLvlID, iDeviceManufWrty, iPSSWrtyLaborID As Integer
'            Dim dblRegPrice, dblWrtyPrice, dblDeviceLaborCharge As Double
'            Dim bIsWarrantied As Boolean = False
'            Dim strSQL As String
'            Dim dblDBRNERCharge As Double = 0

'            Try
'                iLaborLvlID = GetLaborLevel(iBillCode)

'                If iBillCode = Me._iDBRBillCode Or iBillCode = Me._iNERBillCode Then 'DBR/NER
'                    strSQL = "SELECT MarkUp_RUR, MarkUp_NER " & Environment.NewLine
'                    strSQL &= "FROM tcustmarkup " & Environment.NewLine
'                    strSQL &= "WHERE Cust_ID = " & Me._iCustomerID.ToString

'                    drLaborPrc = Me._objDataProc.GetDataRow(strSQL)

'                    If Not IsNothing(drLaborPrc) Then
'                        If iBillCode = Me._iDBRBillCode Then
'                            dblDBRNERCharge = drLaborPrc("MarkUp_RUR")
'                        Else
'                            dblDBRNERCharge = drLaborPrc("MarkUp_NER")
'                        End If
'                    End If

'                    strSQL = "UPDATE tdevice " & Environment.NewLine
'                    strSQL &= "SET Device_LaborCharge = " & dblDBRNERCharge.ToString & ", Device_LaborLevel = " & iLaborLvlID.ToString & " " & Environment.NewLine
'                    strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString

'                    Me._objDataProc.ExecuteNonQuery(strSQL)
'                Else
'                    ' Check to see if model pricing is flat or tiered.
'                    drPricingType = Me._dsDeviceData.Tables(Me._strDeviceDetailsTable).Select("device_id = " & Me._iDeviceID.ToString)

'                    If drPricingType.Length > 0 Then
'                        iPricingType = drPricingType(0)("PrcType_ID")
'                        iProductGroupID = drPricingType(0)("ProductGroup")
'                        iProdID = drPricingType(0)("Prod_ID")

'                        strSQL = "SELECT PrcGroup_ID " & Environment.NewLine
'                        strSQL &= "FROM tcusttoprice " & Environment.NewLine
'                        strSQL &= "WHERE Cust_ID = " & Me._iCustomerID.ToString & " " & Environment.NewLine
'                        strSQL &= "AND Prod_ID = " & iProdID.ToString

'                        iPrcGroupID = Me._objDataProc.GetIntValue(strSQL)

'                        If iPricingType = 1 Then ' Tiered 
'                            strSQL = "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
'                            strSQL &= "FROM tlaborprc " & Environment.NewLine
'                            strSQL &= "WHERE PrcGroup_ID = " & iPrcGroupID.ToString & " " & Environment.NewLine
'                            strSQL &= "AND LaborLvl_ID = " & iLaborLvlID.ToString & " " & Environment.NewLine
'                            strSQL &= "AND ProdGrp_ID = " & iProductGroupID

'                        Else ' Flat
'                            strSQL = "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
'                            strSQL &= "FROM tlaborprc " & Environment.NewLine
'                            strSQL &= "WHERE PrcGroup_ID = " & iPrcGroupID.ToString & " " & Environment.NewLine
'                            strSQL &= "AND LaborLvl_ID = 0 " & Environment.NewLine
'                            strSQL &= "AND ProdGrp_ID = " & iProductGroupID
'                        End If

'                        drLaborPrc = Me._objDataProc.GetDataRow(strSQL)

'                        If Not IsNothing(drLaborPrc) Then
'                            dblRegPrice = drLaborPrc("LaborPrc_RegPrc")
'                            dblWrtyPrice = drLaborPrc("LaborPrc_WrtyPrc")

'                            strSQL = "SELECT Device_ManufWrty " & Environment.NewLine
'                            strSQL &= "FROM tdevice " & Environment.NewLine
'                            strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString

'                            iDeviceManufWrty = Me._objDataProc.GetIntValue(strSQL)

'                            If iDeviceManufWrty = 1 Then
'                                bIsWarrantied = True

'                                strSQL = "SELECT PSSWrtyLabor_ID " & Environment.NewLine
'                                strSQL &= "FROM tcustwrty " & Environment.NewLine
'                                strSQL &= "WHERE Prod_ID = " & iProdID.ToString & " " & Environment.NewLine
'                                strSQL &= "AND Cust_ID = " & Me._iCustomerID.ToString

'                                iPSSWrtyLaborID = Me._objDataProc.GetIntValue(strSQL)

'                                If iPSSWrtyLaborID = 1 Then
'                                    dblDeviceLaborCharge = dblRegPrice
'                                Else
'                                    dblDeviceLaborCharge = dblWrtyPrice
'                                End If
'                            Else
'                                dblDeviceLaborCharge = dblRegPrice
'                            End If

'                            strSQL = "UPDATE tdevice " & Environment.NewLine
'                            strSQL &= "SET Device_LaborCharge = " & dblDeviceLaborCharge.ToString & ", Device_LaborLevel = " & iLaborLvlID.ToString & " " & Environment.NewLine
'                            strSQL &= "WHERE device_id = " & Me._iDeviceID.ToString

'                            Me._objDataProc.ExecuteNonQuery(strSQL)
'                        Else
'                            Me._objDataProc.DisplayMessage("There is not enough information to bill this device (" & Me._iDeviceID.ToString & "). " & vbCrLf & _
'                                                            "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
'                                                            "Please CONTACT CUSTOMER SERVICE.", False)

'                            Exit Sub
'                        End If
'                    End If
'                End If
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'        Private Function GetPartsCharge(ByVal iBillCode As Integer) As Double
'            Dim dblDevicePartCharge As Double = 0
'            Dim dr() As DataRow
'            Dim iWrtyPartsID, iModelID, iPSPriceID As Integer
'            Dim strSQL, strDevicePartCharge As String

'            Try
'                strSQL = "SELECT Model_ID " & Environment.NewLine
'                strSQL &= "FROM tdevice " & Environment.NewLine
'                strSQL &= "WHERE Device_ID = " & Me._iDeviceID.ToString

'                iModelID = Me._objDataProc.GetIntValue(strSQL)

'                If iModelID > 0 Then
'                    strSQL = "SELECT psprice_id " & Environment.NewLine
'                    strSQL &= "FROM tpsmap " & Environment.NewLine
'                    strSQL &= "WHERE Model_ID = " & iModelID.ToString & " " & Environment.NewLine
'                    strSQL &= "AND BillCode_ID = " & iBillCode.ToString

'                    iPSPriceID = Me._objDataProc.GetIntValue(strSQL)

'                    If iPSPriceID > 0 Then
'                        strSQL = "SELECT PSPrice_StndCost "
'                        strSQL &= "FROM lpsprice "
'                        strSQL &= "WHERE PSPrice_ID = " & iPSPriceID.ToString

'                        strDevicePartCharge = Me._objDataProc.GetSingletonString(strSQL)

'                        If strDevicePartCharge.Length > 0 Then dblDevicePartCharge = CDbl(strDevicePartCharge)

'                        dr = Me._dsDeviceData.Tables(Me._strDeviceDetailsTable).Select("Device_ID = " & Me._iDeviceID.ToString)

'                        If dr.Length > 0 Then
'                            If Not IsDBNull(dr(0)("PSSWrtyParts_ID")) Then
'                                iWrtyPartsID = dr(0)("PSSWrtyParts_ID")

'                                If iWrtyPartsID = 1 Or iWrtyPartsID = 3 Then
'                                    If Not IsDBNull(dr(0)("Cust_Markup")) Then dblDevicePartCharge *= (1 + dr(0)("Cust_Markup"))
'                                End If
'                            End If
'                        End If
'                    End If
'                End If

'                Return dblDevicePartCharge
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function
'#End Region 'NonOverridable Methods

'#Region "Billing Properties"
'        Public ReadOnly Property DataProc()
'            Get
'                Return Me._objDataProc
'            End Get
'        End Property

'        Public ReadOnly Property CustomerID()
'            Get
'                Return Me._iCustomerID
'            End Get
'        End Property

'        Public ReadOnly Property DeviceID()
'            Get
'                Return Me._iDeviceID
'            End Get
'        End Property

'        Public ReadOnly Property DeviceDetails()
'            Get
'                If Me._dsDeviceData.Tables.IndexOf(Me._strDeviceDetailsTable) > -1 Then
'                    Return Me._dsDeviceData.Tables(Me._strDeviceDetailsTable)
'                Else
'                    Return Nothing
'                End If
'            End Get
'        End Property

'        Public ReadOnly Property BilledCodes()
'            Get
'                If Me._dsDeviceData.Tables.IndexOf(Me._strBilledCodesTable) > -1 Then
'                    Return Me._dsDeviceData.Tables(Me._strBilledCodesTable)
'                Else
'                    Return Nothing
'                End If
'            End Get
'        End Property

'        Public ReadOnly Property AllBillCodes()
'            Get
'                If Me._dsDeviceData.Tables.IndexOf(Me._strAllBillCodesTable) > -1 Then
'                    Return Me._dsDeviceData.Tables(Me._strAllBillCodesTable)
'                Else
'                    Return Nothing
'                End If
'            End Get
'        End Property
'#End Region 'Billing Properties
'    End Class
'End Namespace
