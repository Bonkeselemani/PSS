Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports EncDec

Public Class CrystalReports
    Public Enum Report_Call
        CELL_LINE_PRODUCTION = 1
        CELL_PRODUCTION_SUMMARY
        PRODUCTION_RECEIVED_QTY_BY_CUST
        RECEIVING_EMPLOYEE_COUNT
        SHIPPING_COUNT_DAILY
        SHIPPING_COUNT_DAILY_EXTENDED_DETAIL
        SHIPPING_EMPLOYEE_COUNT
        RECEIVING_COUNT_DAILY
        RECEIVING_COUNT_DAILY_EXTENDED_DETAIL
        RECEIVING_COUNT_MONTHLY_EXTENDED_DETAIL
        AMERICAN_MESSAGING_STAGED_BUT_NOT_RECEIVED
        AMERICAN_MESSAGING_WIP
        BILL_EMPLOYEE_COUNT
        ADMIN_BILLED_NOT_SHIPPED
        ADMIN_CUSTOMER_LOCATIONS
        ADMIN_WIP
        ADMIN_WIP_DETAIL
        ADMIN_REVENUE_SUMMARY
        ADMIN_REVENUE_DETAIL
        SHIPPING_SHIPPED_DEVICE_QTY_BY_SHIP_TYPE
        SHIPPING_GAMESTOP_DEVICES_NOT_SHIPPED
        INVENTORY_SCRAP_QUANTITY
        ADMIN_REVENUE_AUP_BY_CUSTOMER_AND_MODEL
        TECHNICIAN_FAILURE_RATE
        RECEIVING_DETAIL
        CELL_SHIPPED_PALLETS
        SHIPPING_ATCLE_PASS_FAIL
        ADMIN_REVENUE_DETAIL_BRIGHTPOINT_AB
        ADMIN_REVENUE_SUMMARY_BRIGHTPOINT_AB
        AMERICAN_MESSAGING_SHIP_DEMAND
        ADMIN_REVENUE_AUP_DAILY_PRODUCTION
        ADMIN_REVENUE_DAILY_PRODUCTION
        MESSAGING_PRODUCT_WIP
        ADMIN_REVENUE_SUMMARY_SPECIAL_PROJECTS
        ADMIN_REVENUE_DETAIL_SPECIAL_PROJECTS
        ADMIN_RAUPLOAD_RECEIVED_REPORT
    End Enum

    'Private Const _sngGuitarHeroCharge As Single = 3.1

    Private _objDataProc As DBQuery.DataProc
    Private _datStart, _datEnd As Date
    Private _strReportTitle As String
    Private _rc As Report_Call
    Private _iCustomerID, _iRowID, _iSubRowID, _iColumnID As Integer
    Private _iProductIDs(), _iLocationIDs(), _iCustomerIDs() As Integer
    Private _bUseStartDate As Boolean = True
    Private _bUseEndDate As Boolean = True
    Private _bUseAllCustomers As Boolean = True
    Private _bUseAllLocations As Boolean = True
    Private _strSubRptNames() As String = {"", "", ""}
    Private _dtWIPCutoffDate As DateTime = Now
    Private _iDaysInWIP As Integer = 0
    Private _strGSLotNumberPattern As String = ""
    Private _strGSModels() As String
    Private _bIncludeBrightpoint As Boolean = False
    Private _bAllProducts As Boolean = True
    Private _bTracfoneOnly As Boolean = False
    Private _bTFTriageOnly As Boolean = False
    Private _bWFMOnly As Boolean = False
    Private _bStanleyOnly As Boolean = False
    Private _bPantechProductsOnly As Boolean = False
    Private _bTMIOnly As Boolean = False
    Private _bSkullcandyOnly As Boolean = False
    Private _booAutoBill As Boolean = False

#Region "Properties"
    Public WriteOnly Property AutoBillFlag() As Boolean
        Set(ByVal Value As Boolean)
            _booAutoBill = Value
        End Set
    End Property
#End Region

    Public Sub New(ByVal strReportTitle As String, ByVal rc As Report_Call)
        Me._strReportTitle = strReportTitle
        Me._rc = rc

        Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        'Me._objDataProc = ReplicationConnection.GetReplicationConnection()
    End Sub

    Public Sub SetDates(ByVal bUseStartDate As Boolean, ByVal datStart As Date, ByVal bUseEndDate As Boolean, ByVal datEnd As Date)
        Me._bUseStartDate = bUseStartDate
        Me._datStart = datStart
        Me._bUseEndDate = bUseEndDate
        Me._datEnd = datEnd
    End Sub

    Public Function GetReportData() As DataSet
        Try
            Return GetReportData(New Boolean() {False, False, False, False, False, False})
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetReportData(ByVal bUseParams As Boolean()) As DataSet
        Const strToDaysStart As String = "1899-12-30"
        Dim strSQL, strSQLRec, strSQLTri, strGroup, strProdIDs, strLocationIDs, strCustIDs, strGSModels, strDeviceIDsIn As String
        Dim strSubRptSQL() As String = {"", "", ""}
        Dim dtSubRpt() As DataTable = {New DataTable(""), New DataTable(""), New DataTable("")}
        Dim strSubRptTableName() As String = {"", "", ""}
        Dim strDateClause As String = ""
        Dim strDateTriage As String = ""
        Dim strDateRange As String = ""
        Dim dt, dtRec, dtTri As DataTable
        Dim ds As DataSet
        Dim strTableName As String = ""
        Dim i, iTempDeviceID As Integer
        Dim dtDisplayedWIPCutoffDate As DateTime
        Dim bUseBillCodeJoins As Boolean
        Dim dtTemp, dtInitial As DataTable
        Dim drTemp, drInitial, drNew, drTempArr(), drCurrent As DataRow
        Dim strTempModelDesc, strTempFreq As String
        Dim iReceived, iLabeled, iShipped As Integer
        Dim strTMI_ProdDesc As String = "" ', TMI_strSQL As String = ""
        Dim bFoundDesktop As Boolean = False, bFoundLaptop As Boolean = False
        Try
            ds = New DataSet("Report Data")

            If bUseParams(0) Then
                If (Me._bUseStartDate And IsNothing(Me._datStart)) Or (Me._bUseEndDate And IsNothing(Me._datEnd)) Then
                    Me._objDataProc.DisplayMessage("The date range hasn't been set properly.", 3, False)

                    Exit Function
                End If
            End If

            Select Case Me._rc
                Case Report_Call.CELL_LINE_PRODUCTION
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.DP_Date", strDateRange)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "G.Group_Desc AS GroupDesc, E.Line_Number AS LineNumber, F.User_FullName AS UserFullName, " & Environment.NewLine
                    strSQL &= "(CASE WHEN C.Pallet_ShipType = 0 THEN 'Refurbished' WHEN C.Pallet_ShipType = 1 THEN 'RUR' ELSE 'RTM' END) AS ShipType, " & Environment.NewLine
                    strSQL &= "D.Model_Desc AS ModelDesc, COUNT(D.Model_ID) AS ModelCount, A.DP_Date AS DataDate " & Environment.NewLine
                    strSQL &= "FROM tdailyproduction A " & Environment.NewLine
                    strSQL &= "INNER JOIN tdevice B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tpallett C ON C.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel D ON D.Model_ID = B.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lline E ON E.Line_ID = A.Line_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN security.tusers F ON F.User_ID = A.User_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lgroups G ON G.Group_ID = A.Group_ID " & Environment.NewLine
                    strSQL &= "WHERE C.Pallet_ShipType IN (0, 1, 9) " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY G.Group_ID, E.Line_ID, F.User_ID, C.Pallet_ShipType, D.Model_ID, A.DP_Date " & Environment.NewLine
                    strSQL &= "ORDER BY G.Group_Desc, E.Line_Number, F.User_FullName, ShipType, D.Model_Desc, A.DP_Date"

                    strTableName = "Cell Line Production Data"

                Case Report_Call.CELL_PRODUCTION_SUMMARY
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.DP_Date", strDateRange, 1)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "G.Group_Desc AS GroupDesc, L.Cust_Name1 AS CustName, CONCAT('Shift ', M.Shift_Number) AS ShiftDesc, D.Model_Desc AS ModelDesc, (CASE WHEN N.Pallet_ShipType = 0 THEN 'Refurbished' WHEN N.Pallet_ShipType = 1 OR N.Pallet_ShipType = 9 THEN 'RUR/RTM' ELSE 'None' END) AS BillCodeDesc, COUNT(D.Model_ID) AS ModelCount, A.DP_Date AS DataDate " & Environment.NewLine
                    strSQL &= "FROM tdailyproduction A " & Environment.NewLine
                    strSQL &= "INNER JOIN tdevice B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel D ON D.Model_ID = B.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN security.tusers F ON F.User_ID = A.User_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lgroups G ON G.Group_ID = A.Group_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN security.tusers J ON J.User_ID = A.User_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation K ON K.Loc_ID = B.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer L ON L.Cust_ID = K.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tshift M ON M.Shift_ID = F.Shift_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tpallett N ON N.Pallett_ID = B.Pallett_ID " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "WHERE " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY GroupDesc, CustName, ShiftDesc, ModelDesc, (CASE WHEN N.Pallet_ShipType = 0 THEN 0 WHEN N.Pallet_ShipType = 1 OR N.Pallet_ShipType = 9 THEN 1 ELSE 2 END), DataDate " & Environment.NewLine
                    strSQL &= "ORDER BY GroupDesc, CustName, ShiftDesc, ModelDesc, (CASE WHEN N.Pallet_ShipType = 0 THEN 0 WHEN N.Pallet_ShipType = 1 OR N.Pallet_ShipType = 9 THEN 1 ELSE 2 END), DataDate"

                    strTableName = "Cell Production Summary Data"

                Case Report_Call.PRODUCTION_RECEIVED_QTY_BY_CUST
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_RecWorkDate", strDateRange)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "F.Cust_Name1 AS CustName, G.WHP_Lot AS LotNumber, C.Model_Desc AS ModelDesc, COUNT(A.Device_ID) AS ModelCount " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tworkorder D ON D.WO_ID = A.WO_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation E ON E.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer F ON F.Cust_ID = E.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN twarehousepallet G ON G.WHPallet_Number = D.WO_RecPalletName " & Environment.NewLine
                    strSQL &= "WHERE " & strDateClause & " " & Environment.NewLine

                    If Not Me._bUseAllCustomers Then
                        strSQL &= "AND F.Cust_ID IN ("

                        strCustIDs = ""

                        For i = 0 To Me._iCustomerIDs.Length - 1
                            If Me._iCustomerIDs(i) > 0 Then
                                If strCustIDs.Length > 0 Then strCustIDs &= ", "

                                strCustIDs &= Me._iCustomerIDs(i).ToString
                            End If
                        Next

                        strSQL &= strCustIDs & ") " & Environment.NewLine
                    End If

                    strSQL &= "GROUP BY F.Cust_Name1, G.WHP_Lot, C.Model_Desc " & Environment.NewLine
                    strSQL &= "ORDER BY CustName, LotNumber, ModelDesc"

                    strTableName = "Production Received Quantity by Customer Data"

                Case Report_Call.RECEIVING_EMPLOYEE_COUNT
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 1)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "D.Prod_Desc AS ProdDesc, C.Tray_RecUser AS TrayRecUser, COUNT(B.Model_ID) AS ModelCount, A.Device_DateRec AS DeviceDateRec " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN ttray C ON C.Tray_ID = A.Tray_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct D ON D.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "WHERE D.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY D.Prod_Desc, C.Tray_RecUser, A.Device_DateRec " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, TrayRecUser, DeviceDateRec"

                    strTableName = "Receiving Employee Count Data"

                Case Report_Call.SHIPPING_COUNT_DAILY
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateShip", strDateRange, 2)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "C.Prod_Desc AS ProdDesc, CONCAT('Shift ', E.Shift_Number) AS ShiftDesc, "

                    Select Case Me._iRowID
                        Case 0
                            strSQL &= "I.PCo_Name AS RowValue, "
                            strGroup = "I.PCo_ID, "

                        Case 1
                            strSQL &= "H.Cust_Name1 AS RowValue, "
                            strGroup = "H.Cust_ID, "

                        Case 2
                            strSQL &= "D.Loc_Name AS RowValue, "
                            strGroup = "D.Loc_ID, "

                        Case 3
                            strSQL &= "B.Model_Desc AS RowValue, "
                            strGroup = "B.Model_ID, "

                        Case 4
                            strSQL &= "G.rptgrp_desc AS RowValue, "
                            strGroup = "G.RptGrp_ID, "
                    End Select

                    strSQL &= "COUNT(A.Device_ID) AS ModelCount, A.Device_DateShip AS DevShipWorkDate " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct C ON C.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation D ON D.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tshift E ON E.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                    strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lrptgrp G ON G.RptGrp_ID = B.RptGrp_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer H ON H.Cust_ID = D.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco I ON I.PCo_ID = H.PCo_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                    strSQL &= "WHERE C.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY C.Prod_ID, E.Shift_ID, " & strGroup & "A.Device_DateShip " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, ShiftDesc, RowValue, DevShipWorkDate"

                    strTableName = "Shipping Count Daily Data"

                Case Report_Call.SHIPPING_COUNT_DAILY_EXTENDED_DETAIL
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateShip", strDateRange, 2)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "C.Prod_Desc AS ProdDesc, J.Group_Desc AS GroupDesc, CONCAT('Shift ', E.Shift_Number) AS ShiftDesc, " & Environment.NewLine

                    Select Case Me._iRowID
                        Case 0
                            strSQL &= "I.PCo_Name AS RowValue, "
                            strGroup = "I.PCo_ID, "

                        Case 1
                            strSQL &= "H.Cust_Name1 AS RowValue, "
                            strGroup = "H.Cust_ID, "

                        Case 2
                            strSQL &= "D.Loc_Name AS RowValue, "
                            strGroup = "D.Loc_ID, "
                    End Select

                    Select Case Me._iSubRowID
                        Case 0
                            strSQL &= "G.rptgrp_desc AS SubRowValue, "
                            strGroup &= "G.RptGrp_ID, "
                            bUseBillCodeJoins = False

                        Case 1
                            strSQL &= "B.Model_Desc AS SubRowValue, "
                            strGroup &= "B.Model_ID, "
                            bUseBillCodeJoins = False

                        Case 2
                            strSQL &= "L.BillCode_Desc AS SubRowValue, "
                            strGroup &= "L.BillCode_ID, "
                            bUseBillCodeJoins = True

                        Case 3
                            strSQL &= "B.Model_Desc AS RowValue, "
                            strGroup = "B.Model_ID, "
                            bUseBillCodeJoins = False
                    End Select

                    strSQL &= "COUNT(A.Device_ID) AS ModelCount, A.Device_DateShip AS DevShipWorkDate " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct C ON C.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation D ON D.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tshift E ON E.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                    strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lrptgrp G ON G.RptGrp_ID = B.RptGrp_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer H ON H.Cust_ID = D.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco I ON I.PCo_ID = H.PCo_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine

                    If bUseBillCodeJoins Then
                        strSQL &= "INNER JOIN tdevicebill K ON K.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes L ON L.BillCode_ID = K.BillCode_ID " & Environment.NewLine
                    End If

                    strSQL &= "WHERE C.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If Not Me._bUseAllLocations Then
                        strSQL &= "AND D.Loc_ID IN ("
                        strLocationIDs = ""

                        For i = 0 To Me._iLocationIDs.Length - 1
                            If Me._iLocationIDs(i) > 0 Then
                                If strLocationIDs.Length > 0 Then strLocationIDs &= ", "

                                strLocationIDs &= Me._iLocationIDs(i).ToString
                            End If
                        Next

                        strSQL &= strLocationIDs & ") " & Environment.NewLine
                    End If

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY C.Prod_ID, J.Group_ID, E.Shift_ID, " & strGroup & "A.Device_DateShip " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, GroupDesc, ShiftDesc, RowValue, SubRowValue, DevShipWorkDate"

                    strTableName = "Shipping Count Daily Extended Detail Data"

                Case Report_Call.SHIPPING_EMPLOYEE_COUNT
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateShip", strDateRange, 2)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "C.Prod_Desc AS ProdDesc, D.Ship_User AS ShipUser, COUNT(A.Device_ID) AS ModelCount, TO_DAYS(DATE_FORMAT(A.Device_DateShip, '%Y-%m-%d')) - TO_DAYS('" & strToDaysStart & "') AS DevShipDate " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct C ON C.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tship D ON D.Ship_ID = A.Ship_ID " & Environment.NewLine
                    strSQL &= "WHERE C.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY C.Prod_ID, D.Ship_User, TO_DAYS(DATE_FORMAT(A.Device_DateShip, '%Y-%m-%d')) - TO_DAYS('" & strToDaysStart & "') " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, ShipUser, DevShipDate"

                    strTableName = "Shipping Employee Count Data"

                Case Report_Call.RECEIVING_COUNT_DAILY
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 2)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "C.Prod_Desc AS ProdDesc, " & Environment.NewLine

                    Select Case Me._iRowID
                        Case 0
                            strSQL &= "I.PCo_Name AS RowValue, "
                            strGroup = "I.PCo_ID, "

                        Case 1
                            strSQL &= "H.Cust_Name1 AS RowValue, "
                            strGroup = "H.Cust_ID, "

                        Case 2
                            strSQL &= "D.Loc_Name AS RowValue, "
                            strGroup = "D.Loc_ID, "

                        Case 3
                            strSQL &= "B.Model_Desc AS RowValue, "
                            strGroup = "B.Model_ID, "

                        Case 4
                            strSQL &= "G.rptgrp_desc AS RowValue, "
                            strGroup = "G.RptGrp_ID, "
                    End Select

                    strSQL &= "COUNT(A.Device_ID) AS ModelCount, DATE_FORMAT(A.Device_DateRec, '%d/%c/%Y (%a)') AS DevRecDate " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct C ON C.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation D ON D.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lrptgrp G ON G.RptGrp_ID = B.RptGrp_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer H ON H.Cust_ID = D.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco I ON I.PCo_ID = H.PCo_ID " & Environment.NewLine
                    strSQL &= "WHERE C.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY C.Prod_ID, " & strGroup & "DATE_FORMAT(A.Device_DateRec, '%d/%c/%Y (%a)') " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, RowValue, DevRecDate"

                    strTableName = "Receiving Count Daily Data"

                Case Report_Call.RECEIVING_COUNT_DAILY_EXTENDED_DETAIL
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 1)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "C.Prod_Desc AS ProdDesc, " & Environment.NewLine

                    Select Case Me._iRowID
                        Case 0
                            strSQL &= "I.PCo_Name AS RowValue, "
                            strGroup = "I.PCo_ID, "

                        Case 1
                            strSQL &= "H.Cust_Name1 AS RowValue, "
                            strGroup = "H.Cust_ID, "

                        Case 2
                            strSQL &= "D.Loc_Name AS RowValue, "
                            strGroup = "D.Loc_ID, "
                    End Select

                    Select Case Me._iSubRowID
                        Case 0
                            strSQL &= "G.rptgrp_desc AS SubRowValue, "
                            strGroup &= "G.RptGrp_ID, "

                        Case 1
                            strSQL &= "B.Model_Desc AS SubRowValue, "
                            strGroup &= "B.Model_ID, "
                    End Select

                    strSQL &= "COUNT(A.Device_ID) AS ModelCount, TO_DAYS(DATE_FORMAT(A.Device_DateRec, '%Y-%m-%d')) - TO_DAYS('" & strToDaysStart & "') AS DevRecDate " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct C ON C.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation D ON D.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lrptgrp G ON G.RptGrp_ID = B.RptGrp_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer H ON H.Cust_ID = D.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco I ON I.PCo_ID = H.PCo_ID " & Environment.NewLine
                    strSQL &= "WHERE C.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If Not Me._bUseAllLocations Then
                        strSQL &= "AND D.Loc_ID IN ("
                        strLocationIDs = ""

                        For i = 0 To Me._iLocationIDs.Length - 1
                            If Me._iLocationIDs(i) > 0 Then
                                If strLocationIDs.Length > 0 Then strLocationIDs &= ", "

                                strLocationIDs &= Me._iLocationIDs(i).ToString
                            End If
                        Next

                        strSQL &= strLocationIDs & ") " & Environment.NewLine
                    End If

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY C.Prod_ID, " & strGroup & "TO_DAYS(DATE_FORMAT(A.Device_DateRec, '%Y-%m-%d')) - TO_DAYS('" & strToDaysStart & "') " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, RowValue, SubRowValue, DevRecDate"

                    strTableName = "Receiving Count Daily Extended Detail Data"

                Case Report_Call.RECEIVING_COUNT_MONTHLY_EXTENDED_DETAIL
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 0, True)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "C.Prod_Desc AS ProdDesc, " & Environment.NewLine

                    Select Case Me._iRowID
                        Case 0
                            strSQL &= "I.PCo_Name AS RowValue, "
                            strGroup = "I.PCo_ID, "

                        Case 1
                            strSQL &= "H.Cust_Name1 AS RowValue, "
                            strGroup = "H.Cust_ID, "

                        Case 2
                            strSQL &= "D.Loc_Name AS RowValue, "
                            strGroup = "D.Loc_ID, "
                    End Select

                    Select Case Me._iSubRowID
                        Case 0
                            strSQL &= "G.rptgrp_desc AS SubRowValue, "
                            strGroup &= "G.RptGrp_ID, "

                        Case 1
                            strSQL &= "B.Model_Desc AS SubRowValue, "
                            strGroup &= "B.Model_ID, "
                    End Select

                    strSQL &= "COUNT(A.Device_ID) AS ModelCount, DATE_FORMAT(A.Device_DateRec, '%b, %Y') AS DevRecDate " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct C ON C.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation D ON D.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lrptgrp G ON G.RptGrp_ID = B.RptGrp_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer H ON H.Cust_ID = D.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco I ON I.PCo_ID = H.PCo_ID " & Environment.NewLine
                    strSQL &= "WHERE C.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    strSQL &= "AND D.Loc_ID IN ("
                    strLocationIDs = ""

                    For i = 0 To Me._iLocationIDs.Length - 1
                        If Me._iLocationIDs(i) > 0 Then
                            If strLocationIDs.Length > 0 Then strLocationIDs &= ", "

                            strLocationIDs &= Me._iLocationIDs(i).ToString
                        End If
                    Next

                    strSQL &= strLocationIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY C.Prod_ID, " & strGroup & "YEAR(A.Device_DateRec), MONTH(A.Device_DateRec) " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, RowValue, SubRowValue, YEAR(A.Device_DateRec), MONTH(A.Device_DateRec)"

                    strTableName = "Receiving Count Daily Extended Detail Data"

                Case Report_Call.AMERICAN_MESSAGING_STAGED_BUT_NOT_RECEIVED
                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, " & Environment.NewLine
                    strSQL &= "A.Device_Model AS DeviceModel, C.Model_Desc AS ModelDesc, COUNT(C.Model_ID) AS ModelCount " & Environment.NewLine
                    strSQL &= "FROM tverdata A " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustmodel_pssmodel_map B ON A.Device_Model = B.cust_model_desc " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel C ON B.model_id = C.Model_ID " & Environment.NewLine
                    strSQL &= "WHERE A.NewLoadFlag = 1 " & Environment.NewLine
                    strSQL &= "AND A.RcvdFlag = 0 " & Environment.NewLine
                    strSQL &= "GROUP BY A.Device_Model, C.Model_Desc " & Environment.NewLine
                    strSQL &= "ORDER BY A.Device_Model, C.Model_Desc"

                    strSubRptSQL(0) = "SELECT ( CASE WHEN A.Device_Model IS NULL OR LENGTH(TRIM(A.Device_Model)) = 0 THEN '** No Description' ELSE A.Device_Model END) AS DeviceModel, COUNT(A.Device_Model) AS ModelCount " & Environment.NewLine
                    strSubRptSQL(0) &= "FROM tverdata A " & Environment.NewLine
                    strSubRptSQL(0) &= "LEFT OUTER JOIN tcustmodel_pssmodel_map B ON A.Device_Model = B.cust_model_desc " & Environment.NewLine
                    strSubRptSQL(0) &= "WHERE A.NewLoadFlag = 1 " & Environment.NewLine
                    strSubRptSQL(0) &= "AND A.RcvdFlag = 0 " & Environment.NewLine
                    strSubRptSQL(0) &= "AND B.cust_model_desc IS NULL " & Environment.NewLine
                    strSubRptSQL(0) &= "GROUP BY ( CASE WHEN A.Device_Model IS NULL OR LENGTH(TRIM(A.Device_Model)) = 0 THEN '** No Description' ELSE A.Device_Model END) " & Environment.NewLine
                    strSubRptSQL(0) &= "ORDER BY DeviceModel"

                    strTableName = "American Messaging Staged But Not Received Data"
                    strSubRptTableName(0) = "American Messaging Staged But Not Mapped Data"
                    Me._strSubRptNames(0) = "American Messaging Staged But Not Mapped Push"

                Case Report_Call.AMERICAN_MESSAGING_WIP
                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, " & Environment.NewLine
                    strSQL &= "COUNT(tverdata.Trans_ID) AS StagedCount " & Environment.NewLine
                    strSQL &= "FROM tverdata " & Environment.NewLine
                    strSQL &= "WHERE tverdata.RcvdFlag = 0 " & Environment.NewLine
                    strSQL &= "AND tverdata.NewLoadFlag = 1"

                    strSubRptSQL(0) = "SELECT C.Model_Desc AS ModelDesc, COUNT(C.Model_Desc) AS ModelDescCount " & Environment.NewLine
                    strSubRptSQL(0) &= "FROM tdevice A " & Environment.NewLine
                    strSubRptSQL(0) &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSubRptSQL(0) &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                    strSubRptSQL(0) &= "WHERE A.Device_DateBill IS NULL " & Environment.NewLine
                    strSubRptSQL(0) &= "AND B.Cust_ID = 14 " & Environment.NewLine
                    strSubRptSQL(0) &= "GROUP BY C.Model_Desc " & Environment.NewLine
                    strSubRptSQL(0) &= "ORDER BY ModelDesc"

                    strSubRptSQL(1) = "SELECT C.Model_Desc AS ModelDesc, COUNT(C.Model_Desc) AS ModelDescCount " & Environment.NewLine
                    strSubRptSQL(1) &= "FROM tdevice A " & Environment.NewLine
                    strSubRptSQL(1) &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSubRptSQL(1) &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                    strSubRptSQL(1) &= "WHERE A.Device_DateShip IS NULL " & Environment.NewLine
                    strSubRptSQL(1) &= "AND A.Device_DateBill IS NOT NULL " & Environment.NewLine
                    strSubRptSQL(1) &= "AND B.Cust_ID = 14 " & Environment.NewLine
                    strSubRptSQL(1) &= "GROUP BY C.Model_Desc " & Environment.NewLine
                    strSubRptSQL(1) &= "ORDER BY ModelDesc"

                    strTableName = "American Messaging WIP Data"
                    strSubRptTableName(0) = "American Messaging WIP Not Billed Data"
                    Me._strSubRptNames(0) = "American Messaging WIP Not Billed Push"
                    strSubRptTableName(1) = "American Messaging WIP Not Shipped Data"
                    Me._strSubRptNames(1) = "American Messaging WIP Not Shipped Push"

                Case Report_Call.BILL_EMPLOYEE_COUNT
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateBill", strDateRange, 1)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "D.Prod_Desc AS ProdDesc, C.Tray_BillUser AS TrayBillUser, COUNT(B.Model_ID) AS ModelCount, DATE_FORMAT(A.Device_DateBill, '%Y-%m-%d') AS DeviceDateBill " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN ttray C ON C.Tray_ID = A.Tray_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct D ON D.Prod_ID = B.Prod_ID " & Environment.NewLine
                    strSQL &= "WHERE D.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "GROUP BY D.Prod_Desc, C.Tray_BillUser, DATE_FORMAT(A.Device_DateBill, '%Y-%m-%d') " & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, TrayBillUser, DeviceDateBill"

                    strTableName = "Bill Employee Count Data"

                Case Report_Call.ADMIN_BILLED_NOT_SHIPPED
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateBill", strDateRange, 1)

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL &= "D.Cust_Name1 AS CustName, A.Device_SN AS DeviceSN, IFNULL(A.Device_OldSN, '') AS DeviceOldSN, E.Prod_Desc AS 'Type', DATE_FORMAT(A.Device_DateBill, '%b %e, %Y (%a)') AS DeviceDateBill " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tworkorder C ON C.WO_ID = A.WO_ID AND C.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = B.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct E ON E.Prod_ID = C.Prod_ID " & Environment.NewLine
                    strSQL &= "WHERE A.Device_DateShip Is NULL " & Environment.NewLine
                    strSQL &= "AND E.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If strDateClause.Length > 0 Then strSQL &= "AND " & strDateClause & " " & Environment.NewLine

                    strSQL &= "ORDER BY 'Type', CustName, DATE_FORMAT(A.Device_DateBill, '%Y-%m-%d'), DeviceSN"

                    strTableName = "Admin Billed Not Shipped Data"

                Case Report_Call.ADMIN_CUSTOMER_LOCATIONS
                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, " & Environment.NewLine
                    strSQL &= "IFNULL(B.Loc_Contact, '') AS Contact, " & Environment.NewLine
                    strSQL &= "CONCAT(B.Loc_Phone, ' (O)', (CASE WHEN B.Loc_Fax IS NULL OR LENGTH(TRIM(B.Loc_Fax)) = 0 THEN '' ELSE CONCAT(CHAR(13), CHAR(10), B.Loc_Fax, ' (FAX)') END)) AS Phones, " & Environment.NewLine
                    strSQL &= "A.Cust_Name1 AS CustName, IFNULL(B.Loc_Name, '') AS LocName, " & Environment.NewLine
                    strSQL &= "CONCAT(B.Loc_Address1, CHAR(13), CHAR(10), B.Loc_City, ', ', C.State_Short, ' ', B.Loc_Zip) AS Address, " & Environment.NewLine
                    strSQL &= "D.Cntry_Name AS Country " & Environment.NewLine
                    strSQL &= "FROM tcustomer A " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation B ON B.Cust_ID = A.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lstate C ON C.State_ID = B.State_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lcountry D ON D.Cntry_ID = B.Cntry_ID " & Environment.NewLine
                    strSQL &= "ORDER BY A.Cust_Name1, B.Loc_Name " & Environment.NewLine

                    strTableName = "Admin Customer Locations Address Data"

                Case Report_Call.ADMIN_WIP
                    dtDisplayedWIPCutoffDate = Me._dtWIPCutoffDate
                    'CheckWIPCutoffDate()

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, " & Environment.NewLine
                    strSQL &= "D.Prod_Desc AS ProdDesc, " & Environment.NewLine

                    Select Case Me._iRowID
                        Case 0
                            strSQL &= "G.PCo_Name AS RowValue, 'Company' as RowName, "
                            strGroup = "G.PCo_ID, "

                        Case 1
                            strSQL &= "F.Cust_Name1 AS RowValue, 'Customer' as RowName, "
                            strGroup = "F.Cust_ID, "

                        Case 2
                            strSQL &= "B.Loc_Name AS RowValue, 'Location' as RowName, "
                            strGroup = "B.Loc_ID, "
                    End Select

                    Select Case Me._iColumnID
                        Case 0
                            strSQL &= "C.Model_Desc AS ColumnValue, 'Model' AS ColumnName, "
                            strGroup &= "C.Model_ID "

                        Case 1
                            strSQL &= "E.rptgrp_desc AS ColumnValue, 'Report Group' AS ColumnName, "
                            strGroup &= "E.RptGrp_ID "
                    End Select

                    strSQL &= Me._iDaysInWIP.ToString & " AS DaysInWIP, '" & Format(dtDisplayedWIPCutoffDate, "ddd, MMM d, yyyy") & "' AS WIPCutoffDate, COUNT(A.Device_ID) AS ModelCount " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct D ON D.Prod_ID = C.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lrptgrp E ON E.RptGrp_ID = C.RptGrp_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer F ON F.Cust_ID = B.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco G ON G.PCo_ID = F.PCo_ID " & Environment.NewLine
                    strSQL &= "WHERE ((A.Device_DateShip IS NULL OR A.Device_DateShip > '" & Format(Me._dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "') " & Environment.NewLine
                    strSQL &= "AND A.Device_DateRec <= '" & Format(Me._dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "') " & Environment.NewLine
                    'strSQL &= "WHERE ((A.Device_DateShip IS NULL OR A.Device_DateShip > '" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "') " & Environment.NewLine
                    'strSQL &= "AND A.Device_DateRec <= '" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "') " & Environment.NewLine
                    'strSQL &= "AND (A.Device_DateRec <= '" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "' AND TO_DAYS('" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "') - TO_DAYS(A.Device_DateRec) >= " & Me._iDaysInWIP.ToString & ")) " & Environment.NewLine
                    strSQL &= "AND D.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If Not Me._bUseAllCustomers Then
                        strSQL &= "AND F.Cust_ID IN ("

                        strCustIDs = ""

                        For i = 0 To Me._iCustomerIDs.Length - 1
                            If Me._iCustomerIDs(i) > 0 Then
                                If strCustIDs.Length > 0 Then strCustIDs &= ", "

                                strCustIDs &= Me._iCustomerIDs(i).ToString
                            End If
                        Next

                        strSQL &= strCustIDs & ") " & Environment.NewLine
                    End If

                    strSQL &= "GROUP BY D.Prod_Desc, " & strGroup & Environment.NewLine
                    strSQL &= "ORDER BY ProdDesc, RowValue, ColumnValue"

                    strTableName = "Admin WIP Data"

                Case Report_Call.ADMIN_WIP_DETAIL
                    dtDisplayedWIPCutoffDate = Me._dtWIPCutoffDate
                    CheckWIPCutoffDate()

                    strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, " & Environment.NewLine
                    strSQL &= "D.Prod_Desc AS ProdDesc, G.PCo_Name AS CompanyName, B.Loc_Name AS CompanyID, E.WO_CustWO AS WorkOrder, CAST(A.Tray_ID AS CHAR) AS TrayID, C.Model_Desc AS ModelDesc, A.Device_SN AS DeviceSN, " & Environment.NewLine
                    strSQL &= "IFNULL(A.Device_OldSN, '') AS DeviceOldSN, (CASE WHEN A.Loc_ID = 2640 THEN '2440' ELSE '' END) AS RANumber, (CASE WHEN A.Device_DateRec IS NULL THEN '' ELSE DATE_FORMAT(A.Device_DateRec, '%a, %b %d, %Y') END) AS DeviceRecDate, (CASE WHEN A.Device_DateBill IS NULL THEN 'No Bill Date' ELSE DATE_FORMAT(A.Device_DateBill, '%a, %b %d, %Y') END) AS DeviceDateBill, " & Environment.NewLine
                    strSQL &= Me._iDaysInWIP.ToString & " AS DaysInWIP, '" & Format(dtDisplayedWIPCutoffDate, "ddd, MMM d, yyyy") & "' AS WIPCutoffDate, TO_DAYS('" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd") & "') - TO_DAYS(A.Device_DateRec) AS DeviceDaysInWIP" & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lproduct D ON D.Prod_ID = C.Prod_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tworkorder E ON E.WO_ID = A.WO_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer F ON F.Cust_ID = B.Cust_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lparentco G ON G.PCo_ID = F.PCo_ID " & Environment.NewLine
                    strSQL &= "WHERE ((A.Device_DateShip IS NULL OR A.Device_DateShip > '" & Format(Me._dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "') " & Environment.NewLine
                    strSQL &= "AND A.Device_DateRec <= '" & Format(Me._dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "') " & Environment.NewLine
                    'strSQL &= "WHERE ((A.Device_ShipWorkDate IS NULL OR A.Device_ShipWorkDate > '" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd") & "') " & Environment.NewLine
                    'strSQL &= "AND A.Device_DateRec <= '" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "') " & Environment.NewLine
                    'strSQL &= "AND (A.Device_DateRec <= '" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "' AND TO_DAYS('" & Format(Me._dtWIPCutoffDate, "yyyy-MM-dd 23:59:59") & "') - TO_DAYS(A.Device_DateRec) >= " & Me._iDaysInWIP.ToString & ")) " & Environment.NewLine
                    strSQL &= "AND D.Prod_ID IN ("

                    strProdIDs = ""

                    For i = 0 To Me._iProductIDs.Length - 1
                        If Me._iProductIDs(i) > 0 Then
                            If strProdIDs.Length > 0 Then strProdIDs &= ", "

                            strProdIDs &= Me._iProductIDs(i).ToString
                        End If
                    Next

                    strSQL &= strProdIDs & ") " & Environment.NewLine

                    If Not Me._bUseAllCustomers Then
                        strSQL &= "AND F.Cust_ID IN ("

                        strCustIDs = ""

                        For i = 0 To Me._iCustomerIDs.Length - 1
                            If Me._iCustomerIDs(i) > 0 Then
                                If strCustIDs.Length > 0 Then strCustIDs &= ", "

                                strCustIDs &= Me._iCustomerIDs(i).ToString
                            End If
                        Next

                        strSQL &= strCustIDs & ") " & Environment.NewLine
                    End If

                    strSQL &= "ORDER BY ProdDesc, CompanyName, WorkOrder"

                    strTableName = "Admin WIP Detail Data"

                Case Report_Call.ADMIN_REVENUE_SUMMARY
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)

                    If Me._bTracfoneOnly Then
                        strSQL = "SELECT "
                        If Me._booAutoBill Then
                            strSQL &= "'" & Me._strReportTitle & " AB ' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        Else
                            strSQL &= "'" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        End If
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "IF(UPPER(TRIM(E.PCo_Name)) = 'CELLSTAR', 'Brightpoint', E.PCo_Name) AS CompanyName " & Environment.NewLine
                        If Me._booAutoBill Then
                            strSQL &= ", G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID" & Environment.NewLine
                            strSQL &= ", G.DBill_InvoiceAmt AS BillInvoiceAmt" & Environment.NewLine
                            strSQL &= ", A.Device_LaborCharge_AutoBilled AS DeviceLaborChg " & Environment.NewLine
                        Else
                            strSQL &= ", IF(G.Billcode_ID in ( 154, 1869, 2510 ) , 0, G.DBill_AvgCost) AS BillAvgCost, K.BillType_ID AS BillTypeID" & Environment.NewLine
                            strSQL &= ", IF(G.Billcode_ID in ( 154, 1869, 2510 ) , 0, G.DBill_InvoiceAmt) AS BillInvoiceAmt" & Environment.NewLine
                            strSQL &= ", A.Device_LaborCharge AS DeviceLaborChg " & Environment.NewLine
                        End If
                        strSQL &= ", A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty" & Environment.NewLine
                        strSQL &= ", A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice" & Environment.NewLine
                        strSQL &= ", K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID" & Environment.NewLine
                        strSQL &= ", J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, G.Fail_ID AS FailID" & Environment.NewLine
                        strSQL &= ", IFNULL(N.Wrty_Labor, 0) AS WrtyLabor, IFNULL(N.Wrty_PartCost, 0) AS WrtyPartCost" & Environment.NewLine
                        strSQL &= ", IFNULL(N.WrtyClaimableFlg, 0) AS WarrantyClaimable " & Environment.NewLine
                        strSQL &= ", IF(K.BillCode_Rule = 0, A.Device_LaborCharge, 0 ) as RefLabor " & Environment.NewLine
                        strSQL &= ", A.Device_Qty" & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods " & Environment.NewLine
                        If Me._booAutoBill Then
                            strSQL &= ", A.Device_PartCharge_AutoBilled AS Device_PartCharge" & Environment.NewLine
                        Else
                            strSQL &= ", A.Device_PartCharge" & Environment.NewLine
                        End If

                        strSQL &= ", A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg , IF( Pallet_ShipType = 0 and N.WrtyStatus_ByWHRecDate = 1, 1, 0) as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        If Me._booAutoBill Then
                            strSQL &= "INNER JOIN tdevicebill_Special G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        Else
                            strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        End If
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = F.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN production.tpallett P ON A.Pallett_ID = P.Pallett_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND I.Prod_ID = 2 AND A.Loc_ID = " & Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine

                    ElseIf Me._bTFTriageOnly Then
                        MessageBox.Show("Not able to get Summary Report at this time. Please contact IT.")
                        '    If bUseParams(0) Then strDateClause = Me.TFTriageDateStrings("B.Device_DateRec", strDateRange) 'may want to change this later

                        '    strSQL = "SELECT D.Model_Desc AS 'Model', Count(B.Device_Qty) AS 'Receiving Qty', CONCAT('$', FORMAT(1.75*Count(B.Device_Qty), 2)) AS 'Receiving Charge' " & Environment.NewLine
                        '    strSQL &= ", COUNT(B.Device_Qty) AS 'Triage Qty', CONCAT('$', FORMAT(1.75*Count(B.Device_Qty), 2)) AS 'Triage Charge' " & Environment.NewLine
                        '    strSQL &= ", CONCAT('$', FORMAT(1.75*Count(B.Device_Qty) + 1.75*Count(B.Device_Qty), 2)) AS 'Total Charge' " & Environment.NewLine
                        '    strSQL &= "FROM production.tdevice_triaged_data A " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tcellopt C ON A.Device_ID=C.Device_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tmodel D ON A.Triaged_Model_ID=D.Model_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tmodel E ON B.Model_ID=E.Model_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tdispositions F ON A.Disp_ID=F.Disp_ID " & Environment.NewLine
                        '    strSQL &= "WHERE Triage_Completed=1 AND D.Model_Desc like '%X' AND " & strDateClause & Environment.NewLine
                        '    strSQL &= "GROUP BY B.Model_ID " & Environment.NewLine
                        '    strSQL &= "UNION ALL " & Environment.NewLine
                        '    strSQL &= "SELECT 'Total', SUM(B.Device_Qty) AS 'Receiving Qty', CONCAT('$', FORMAT(1.75*Count(B.Device_Qty), 2)) AS 'Receiving Charge' " & Environment.NewLine
                        '    strSQL &= ", Count(B.Device_Qty) AS 'Triage Qty', CONCAT('$', FORMAT(1.75*Count(B.Device_Qty), 2)) AS 'Triage Charge' " & Environment.NewLine
                        '    strSQL &= ", CONCAT('$', FORMAT(1.75*Count(B.Device_Qty) + 1.75*Count(B.Device_Qty), 2)) AS 'Total Charge' " & Environment.NewLine
                        '    strSQL &= "FROM production.tdevice_triaged_data A " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tcellopt C ON A.Device_ID=C.Device_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tmodel D ON A.Triaged_Model_ID=D.Model_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tmodel E ON B.Model_ID=E.Model_ID " & Environment.NewLine
                        '    strSQL &= "INNER JOIN production.tdispositions F ON A.Disp_ID=F.Disp_ID " & Environment.NewLine
                        '    strSQL &= "WHERE Triage_Completed=1 AND D.Model_Desc like '%X' AND " & strDateClause & Environment.NewLine

                    ElseIf Me._bWFMOnly Then
                        Dim WFM_NTF_strDateClause As String = Me.SetupDateStrings("G.Date_Rec", strDateRange, 2)
                        'Dim WFM_Triage_strDateClause As String = Me.SetupDateStrings("wb.crt_ts", strDateRange, 2)
                        Dim WFM_Triage_strDateClause As String = Me.SetupDateStrings("G.Date_Rec", strDateRange, 2)

                        'NTF revenue----------------------------------------------------------------------------------------------------
                        strSQL = "SELECT "
                        If Me._booAutoBill Then
                            strSQL &= "'" & Me._strReportTitle & " AB ' AS ReportTitle" & Environment.NewLine
                        Else
                            strSQL &= "'" & Me._strReportTitle & "' AS ReportTitle" & Environment.NewLine
                        End If

                        strSQL &= ", '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        'strSQL = "SELECT 'Admin Revenue Detail TracFone' AS ReportTitle" & Environment.NewLine
                        'strSQL &= " , 'Feb 13, 2017 - Feb 17, 2017' AS DateRange," & Environment.NewLine
                        strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_AvgCost,0) AS 'BillAvgCost', K.BillType_ID AS BillTypeID" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS 'BillInvoiceAmt'" & Environment.NewLine
                        strSQL &= " , IF(G.billcode_ID=507,G.DBill_InvoiceAmt,0) as 'TriageLaborChg'" & Environment.NewLine
                        strSQL &= " , IF(G.billcode_ID=541 or G.billcode_ID=4227,G.DBill_InvoiceAmt,0) as 'NTFLaborChg'" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS DeviceLaborChg" & Environment.NewLine
                        strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty" & Environment.NewLine
                        strSQL &= " , A.Device_ManufWrty AS DeviceManufWrty, 0 AS ASCBillPrice" & Environment.NewLine
                        strSQL &= " , K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                        strSQL &= " , 120 AS GroupID, 'WFM (TF)' AS GroupDesc, 1 AS ShiftNumber" & Environment.NewLine
                        strSQL &= " , M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, G.Fail_ID AS FailID" & Environment.NewLine
                        strSQL &= " , IFNULL(N.Wrty_Labor, 0) AS WrtyLabor, IFNULL(N.Wrty_PartCost, 0) AS WrtyPartCost" & Environment.NewLine
                        strSQL &= " , IFNULL(N.WrtyClaimableFlg, 0) AS WarrantyClaimable" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_StdCost, 0) AS StandardCost" & Environment.NewLine
                        strSQL &= " , IF(G.DBill_InvoiceAmt is null, 0, G.DBill_InvoiceAmt) AS InvoiceAmount" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_AvgCost, 0 ) AS AverageCost" & Environment.NewLine
                        strSQL &= " , A.Device_Qty" & Environment.NewLine
                        strSQL &= " , A.Device_FinishedGoods" & Environment.NewLine
                        strSQL &= " , A.Device_PartCharge" & Environment.NewLine
                        strSQL &= " , A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg" & Environment.NewLine
                        strSQL &= " , IF(N.WrtyStatus_ByWHRecDate = 1, 1, 0) as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                        strSQL &= " ,A.Device_ID,A.Device_SN,P.Pallett_ID,P.Pallett_Name,P.pallet_qc_passed,G.BillCode_ID" & Environment.NewLine
                        strSQL &= " FROM tdevice A" & Environment.NewLine
                        strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = I.Prod_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tpallett P ON P.pallett_ID = A.Pallett_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tCellOpt COP ON COP.Device_ID = A.Device_ID" & Environment.NewLine
                        strSQL &= "WHERE " & WFM_NTF_strDateClause & Environment.NewLine
                        'strSQL &= " WHERE  G.Date_Rec BETWEEN '2017-02-28' AND '2017-03-01'" & Environment.NewLine
                        strSQL &= " AND I.Prod_ID = 2 AND A.Loc_ID = 3402" & Environment.NewLine
                        'strSQL &= " AND P.pallet_qc_passed=1 AND COP.Workstation='WH-FLOOR'" & Environment.NewLine - changed by ACOLBURN 6/28/2017
                        strSQL &= " AND P.pallet_qc_passed=1 AND COP.Workstation IN ('WH-FLOOR','INTRANSIT')" & Environment.NewLine
                        strSQL &= " AND P.Disp_ID=5 AND G.billcode_ID in (507,541,4227)" & Environment.NewLine

                        'Triage (SOF,COS, FUN) Revnue
                        strSQL &= "UNION ALL SELECT "
                        If Me._booAutoBill Then
                            strSQL &= "'" & Me._strReportTitle & " AB ' AS ReportTitle" & Environment.NewLine
                        Else
                            strSQL &= "'" & Me._strReportTitle & "' AS ReportTitle" & Environment.NewLine
                        End If
                        'strSQL = "SELECT 'Admin Revenue Detail TracFone' AS ReportTitle" & Environment.NewLine
                        'strSQL &= " , 'Feb 13, 2017 - Feb 17, 2017' AS DateRange," & Environment.NewLine
                        strSQL &= ", '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_AvgCost,0) AS 'BillAvgCost', K.BillType_ID AS BillTypeID" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS 'BillInvoiceAmt'" & Environment.NewLine
                        strSQL &= " , IF(G.billcode_ID=507,G.DBill_InvoiceAmt,0) as 'TriageLaborChg'" & Environment.NewLine
                        strSQL &= " , 0 as 'NTFLaborChg'" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS DeviceLaborChg" & Environment.NewLine
                        strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty" & Environment.NewLine
                        strSQL &= " , A.Device_ManufWrty AS DeviceManufWrty, 0 AS ASCBillPrice" & Environment.NewLine
                        strSQL &= " , K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                        strSQL &= " , 120 AS GroupID, 'WFM (TF)' AS GroupDesc, 1 AS ShiftNumber" & Environment.NewLine
                        strSQL &= " , M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, G.Fail_ID AS FailID" & Environment.NewLine
                        strSQL &= " , IFNULL(N.Wrty_Labor, 0) AS WrtyLabor, IFNULL(N.Wrty_PartCost, 0) AS WrtyPartCost" & Environment.NewLine
                        strSQL &= " , IFNULL(N.WrtyClaimableFlg, 0) AS WarrantyClaimable" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_StdCost, 0) AS StandardCost" & Environment.NewLine
                        strSQL &= " , IF(G.DBill_InvoiceAmt is null, 0, G.DBill_InvoiceAmt) AS InvoiceAmount" & Environment.NewLine
                        strSQL &= " , IFNULL(G.DBill_AvgCost, 0 ) AS AverageCost" & Environment.NewLine
                        strSQL &= " , A.Device_Qty" & Environment.NewLine
                        strSQL &= " , A.Device_FinishedGoods" & Environment.NewLine
                        strSQL &= " , A.Device_PartCharge" & Environment.NewLine
                        strSQL &= " , A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg" & Environment.NewLine
                        strSQL &= " , IF(N.WrtyStatus_ByWHRecDate = 1, 1, 0) as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                        strSQL &= " ,A.Device_ID,A.Device_SN,wb.whb_id AS 'Pallett_ID',wb.box_na AS 'Pallett_Name', 0 as 'pallet_qc_passed',G.BillCode_ID" & Environment.NewLine
                        strSQL &= " FROM tdevice A" & Environment.NewLine
                        strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = I.Prod_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN warehouse.wh_box wb on N.whb_id = wb.whb_id" & Environment.NewLine
                        strSQL &= "WHERE " & WFM_Triage_strDateClause & Environment.NewLine
                        'strSQL &= " WHERE wb.crt_ts BETWEEN '2017-03-01 00:00:00' AND '2017-03-01 23:59:59'" & Environment.NewLine
                        strSQL &= " AND I.Prod_ID = 2 AND A.Loc_ID = 3402" & Environment.NewLine
                        strSQL &= " AND wb.Disp_ID in (2,3,4) AND G.billcode_ID in (507)" & Environment.NewLine

                    ElseIf Me._bPantechProductsOnly Then
                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "IF(UPPER(TRIM(E.PCo_Name)) = 'CELLSTAR', 'Brightpoint', E.PCo_Name) AS CompanyName, " & Environment.NewLine
                        strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, G.Fail_ID AS FailID, IFNULL(A.Device_LaborCharge, 0) AS WrtyLabor, 0 AS WrtyPartCost, A.Device_ManufWrty AS WarrantyClaimable " & Environment.NewLine
                        strSQL &= ", IF(K.BillCode_Rule = 0, A.Device_LaborCharge, 0 ) AS RefLabor " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = F.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN production.pantechasn N ON N.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                    ElseIf Me._bTMIOnly Then
                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "E.PCo_Name AS CompanyName, " & Environment.NewLine
                        strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, A.Device_PartCharge as BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND D.Cust_ID = " & Buisness.TMI.CUSTOMERID & Environment.NewLine
                    ElseIf Me._bSkullcandyOnly Then
                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "E.PCo_Name AS CompanyName," & Environment.NewLine
                        strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= " FROM tdevice A" & Environment.NewLine
                        strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                        strSQL &= " LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship" & Environment.NewLine
                        strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                        strSQL &= " WHERE " & strDateClause & Environment.NewLine
                        strSQL &= " AND D.Cust_ID =" & Buisness.Skullcandy.CUSTOMERID & " And F.EndUser = 0 " & Environment.NewLine
                        'strSQL &= " ORDER BY I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID" & Environment.NewLine
                    Else
                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "IF(UPPER(TRIM(E.PCo_Name)) = 'CELLSTAR', 'Brightpoint',IF(D.Cust_ID in (2599,2601,2602,2603,2604,2605,2606,2626,2627),D.Cust_Name1, E.PCo_Name)) AS CompanyName," & Environment.NewLine
                        'strSQL &= "IF(UPPER(TRIM(E.PCo_Name)) = 'CELLSTAR', 'Brightpoint', E.PCo_Name) AS CompanyName, " & Environment.NewLine
                        strSQL &= "G.DBill_InvoiceAmt  AS BillAvgCost, K.BillType_ID AS BillTypeID,G.DBill_AvgCost  AS BillInvoiceAmt, IF(D.Cust_ID=2623,4.50 , A.Device_LaborCharge) AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                        'No need this, after we added TMI Only option
                        'strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, if(J.Group_ID=102,A.Device_PartCharge,G.DBill_InvoiceAmt) as BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "LEFT JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND I.Prod_ID IN ("

                        strProdIDs = String.Empty

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "
                                strProdIDs &= Me._iProductIDs(i).ToString
                                'No need this, after we added TMI Only option
                                'If Me._iProductIDs(i) = 24 Then
                                '    bFoundDesktop = True
                                'ElseIf Me._iProductIDs(i) = 33 Then
                                '    bFoundLaptop = True
                                'End If
                            End If
                        Next
                        strSQL &= strProdIDs & ") " & Environment.NewLine
                        'No need this, after we added TMI Only option
                        'If bFoundDesktop And bFoundLaptop Then
                        '    strTMI_ProdDesc = "'Desktop','Laptop'"
                        'ElseIf bFoundDesktop Then
                        '    strTMI_ProdDesc = "'Desktop'"
                        'ElseIf bFoundLaptop Then
                        '    strTMI_ProdDesc = "'Laptop'"
                        'End If
                    End If

                    If Me._bAllProducts Then
                        strSQL &= "AND D.Cust_ID NOT IN (1381,2258,2519,2552) AND O.manuf_id != 64 " & Environment.NewLine 'Exclude CellStar/Brightpoint/TMI
                    ElseIf Me._bStanleyOnly Then
                        strSQL &= "AND D.Cust_ID = 1381 " & Environment.NewLine
                    ElseIf Me._bPantechProductsOnly Then
                        strSQL &= "AND O.manuf_id = 64 " & Environment.NewLine
                        'ElseIf Me._bTMIOnly Then
                        '    strSQL &= "AND D.Cust_ID = 2519 " & Environment.NewLine
                        'ElseIf Me._bSkullcandyOnly Then
                        '    strSQL &= "AND D.Cust_ID = 2552 " & Environment.NewLine
                    End If

                    If Me._bAllProducts And Not Me._bIncludeBrightpoint Then
                        strSQL &= "AND D.Cust_ID <> 2113  " & Environment.NewLine 'Exclude CellStar/Brightpoint
                    End If

                    If Me._bPantechProductsOnly Then
                        strSQL &= "ORDER BY A.Device_ManufWrty DESC, I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                    Else
                        'No need this, after we added TMI Only option
                        'If strTMI_ProdDesc.Length > 0 Then
                        '    Dim TMI_strDateClause As String = Me.SetupDateStrings("URP_ChargedDate", strDateRange, 0)
                        '    strSQL &= " UNION ALL " & Environment.NewLine
                        '    strSQL &= " SELECT  '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        '    strSQL &= "EW_ID as DeviceID,Type as ProdDesc,'TMI Solutions' as CompanyName,'' as BillAvgCost,'' as BillTypeID," & Environment.NewLine
                        '    strSQL &= "'' as BillInvoiceAmt,URP_Charge as DeviceLaborChg,'' as DeviceReject,'' as DevicePSSWrty,'' as DeviceManufWrty,'' as ASCBillPrice," & Environment.NewLine
                        '    strSQL &= "'' as BillCodeRule,'' as BillCodeID,102 as GroupID,'TMI' as GroupDesc, 99 as ShiftNumber,'' as FailID," & Environment.NewLine
                        '    strSQL &= "'' as WrtyLabor,'' as WrtyPartCost,'' as WarrantyClaimable, 1 as Device_Qty,'' as Device_FinishedGoods," & Environment.NewLine
                        '    strSQL &= "'' as Device_PartCharge,'' as Device_ManufWrtyPartCharge,'' as Device_ManufWrtyLaborCharge, 0.0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        '    strSQL &= " FROM(ExtendedWarranty)" & Environment.NewLine
                        '    strSQL &= " WHERE S_ID=8 AND Cust_ID=2519 and upper(Type) in (" & strTMI_ProdDesc & ")" & Environment.NewLine
                        '    strSQL &= " AND " & TMI_strDateClause & Environment.NewLine
                        '    strSQL &= "ORDER BY ProdDesc,GroupID,ShiftNumber,DeviceID,BillCodeRule,BillCodeID "
                        'Else
                        '    strSQL &= "ORDER BY I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                        'End If
                        If Me._bTMIOnly Then
                            Dim TMI_strDateClause As String = Me.SetupDateStrings("URP_ChargedDate", strDateRange, 0)
                            strSQL &= " UNION ALL " & Environment.NewLine
                            strSQL &= " SELECT  '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= "EW_ID as DeviceID,Type as ProdDesc,'TMI Solutions' as CompanyName,'' as BillAvgCost,'' as BillTypeID," & Environment.NewLine
                            strSQL &= "'' as BillInvoiceAmt,URP_Charge as DeviceLaborChg,'' as DeviceReject,'' as DevicePSSWrty,'' as DeviceManufWrty,'' as ASCBillPrice," & Environment.NewLine
                            strSQL &= "'' as BillCodeRule,'' as BillCodeID,102 as GroupID,'TMI' as GroupDesc, 99 as ShiftNumber,'' as FailID," & Environment.NewLine
                            strSQL &= "'' as WrtyLabor,'' as WrtyPartCost,'' as WarrantyClaimable, 1 as Device_Qty,'' as Device_FinishedGoods," & Environment.NewLine
                            strSQL &= "'' as Device_PartCharge,'' as Device_ManufWrtyPartCharge,'' as Device_ManufWrtyLaborCharge, 0.0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                            strSQL &= " FROM ExtendedWarranty" & Environment.NewLine
                            strSQL &= " WHERE S_ID=8 AND Cust_ID=2519" & Environment.NewLine
                            strSQL &= " AND " & TMI_strDateClause & Environment.NewLine
                            strSQL &= " ORDER BY ProdDesc,GroupID,ShiftNumber,DeviceID,BillCodeRule,BillCodeID "
                        ElseIf Me._bSkullcandyOnly Then
                            Dim Skullcandy_strDateClause As String = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 2)
                            strSQL &= " UNION ALL " & Environment.NewLine
                            strSQL &= " SELECT  '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= "A.device_ID,K.Prod_Desc,L.Cust_Name1 AS CompanyName," & Environment.NewLine
                            strSQL &= "0 AS BillAvgCost,0 AS BillTypeID, 0 AS BillInvoiceAmt," & Environment.NewLine
                            strSQL &= "0.99 AS DeviceLaborChg, 0 AS DeviceReject,0 AS DevicePSSWrty," & Environment.NewLine
                            strSQL &= "0 AS DeviceManufWrty,0 AS ASCBillPrice, 0 AS BillCodeRule," & Environment.NewLine
                            strSQL &= "0 AS BillCodeID, M.Group_ID AS GroupID, M.Group_Desc AS GroupDesc, 99 AS ShiftNumber," & Environment.NewLine
                            strSQL &= "0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable," & Environment.NewLine
                            strSQL &= "A.Device_Qty, A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel B ON A.model_ID = B.model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tasndata C ON A.device_ID = C.device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation D ON A.Loc_ID = D.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder E ON A.WO_ID = E.WO_ID" & Environment.NewLine
                            strSQL &= " LEFT JOIN tcustmodel_pssmodel_map F ON B.model_ID = F.Model_ID AND F.Cust_ID = " & Buisness.Skullcandy.CUSTOMERID & Environment.NewLine
                            strSQL &= " LEFT JOIN cogs.modelfamilies G ON F.ModelFamiliesID = G.ModelFamiliesID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct K ON K.Prod_ID = B.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer L ON L.Cust_ID =D.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups M ON M.Group_ID = E.Group_ID" & Environment.NewLine
                            strSQL &= " WHERE D.Cust_ID = " & Buisness.Skullcandy.CUSTOMERID & " And E.EndUser = 1" & Environment.NewLine
                            strSQL &= " AND " & Skullcandy_strDateClause & Environment.NewLine
                            strSQL &= " ORDER BY ProdDesc,GroupID,ShiftNumber,DeviceID,BillCodeRule,BillCodeID "
                        ElseIf Me._bWFMOnly Then
                            strSQL &= " ORDER BY ProdDesc, GroupID, CompanyName,ShiftNumber, ReportGroupDesc, Device_ID, BillCodeRule, BillCode_ID "
                            'ElseIf Me._bTFTriageOnly Then
                            'Do Nothing
                        Else
                            strSQL &= " ORDER BY I.Prod_Desc, J.Group_ID, IF(D.Cust_ID in (2599,2601,2602,2603,2604,2605,2606,2626,2627),D.Cust_Name1, E.PCo_Name), H.Shift_Number, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                        End If

                        If strProdIDs = 69 Then 'NI only
                            Dim strDateTimeRange As String
                            strDateTimeRange = "BETWEEN '" & Format(Me._datStart, "yyyy-MM-dd") & " 00:00:00" & "' AND '" & Format(Me._datEnd, "yyyy-MM-dd") & " 23:59:59" & "'"

                            'Repairs
                            strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName, G.DBill_AvgCost AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , A.Device_Qty, A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE A.Device_ShipWorkDate " & strDateTimeRange & Environment.NewLine
                            strSQL &= " AND I.Prod_ID IN (" & strProdIDs & ")" & Environment.NewLine
                            strSQL &= " AND D.Cust_ID NOT IN (1381, 2258, 2519) AND O.manuf_id <> 64" & Environment.NewLine
                            strSQL &= " AND D.Cust_ID <> 2113" & Environment.NewLine

                            strSQL &= " Union All " & Environment.NewLine

                            'Triage, Test, Sort
                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, B.inv_amt AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 95 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , A.Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill_pre_repair B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = B.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE B.Date_rec " & strDateTimeRange & Environment.NewLine
                            strSQL &= " AND B.Cust_ID =2531" & Environment.NewLine

                            strSQL &= " Union All " & Environment.NewLine

                            'Call Tag Mailing
                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.EW_ID AS DeviceID, 'DJ Equipment' AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, A.LabelCharge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , 0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 96 AS ShiftNumber, 90 AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , IF(TRIM(L.NI_Prod_Desc)='' or L.NI_Prod_Desc is null,'Not Defined',L.NI_Prod_Desc) AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , 1 AS Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , 0 AS DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM extendedwarranty A" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = 3332" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON A.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                            strSQL &= " LEFT JOIN ni_products L ON A.Prod_code=L.NI_prod_ID" & Environment.NewLine
                            strSQL &= " WHERE A.CUST_ID=2531 AND A.BillCode_ID>0" & Environment.NewLine
                            strSQL &= " AND TrackCreatedDateTime  " & strDateTimeRange & Environment.NewLine

                            strSQL &= " Union All " & Environment.NewLine

                            'Receiving
                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " B.WI_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, B.Labor_Charge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , 0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 97 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , 1 AS Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , 0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM warehouse.warehouse_receipt A" & Environment.NewLine
                            strSQL &= " INNER JOIN warehouse.warehouse_items B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = 3332" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON B.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel O ON O.Model_ID = B.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE A.Cust_ID=2531 AND B.DevConditionID <> 3857" & Environment.NewLine
                            strSQL &= " AND B.Date_Received  " & strDateTimeRange & Environment.NewLine

                            'Pack and Ship
                            strSQL &= " Union All " & Environment.NewLine

                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.SOHeaderID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, A.OrderShipmentCharge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , 0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 98 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , 1 AS Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , 0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM saleorders.SOheader A" & Environment.NewLine
                            strSQL &= " INNER JOIN saleorders.SODetails B ON A.SOHeaderID=B.SOHeaderID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = 3332" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WorkOrderID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON A.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel O ON O.Model_ID = B.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE A.CUST_ID=2531 AND A.InvalidOrder=0" & Environment.NewLine
                            strSQL &= " AND A.ShipDate " & strDateTimeRange & Environment.NewLine


                            strSQL &= "ORDER BY ProdDesc, GroupID, CompanyName, ShiftNumber, ReportGroupDesc, DeviceID, BillCodeRule DESC, BillCodeID;"
                        End If
                    End If

                    strTableName = "Admin Revenue Summary Data"

                Case Report_Call.ADMIN_REVENUE_DETAIL
                    If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)

                    If Me._bTracfoneOnly Then
                        strSQL = "SELECT "
                        If Me._booAutoBill Then
                            strSQL &= "'" & Me._strReportTitle & " AB ' AS ReportTitle" & Environment.NewLine
                        Else
                            strSQL &= "'" & Me._strReportTitle & "' AS ReportTitle" & Environment.NewLine
                        End If
                        strSQL &= ", '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName" & Environment.NewLine
                        strSQL &= ", IF(G.Billcode_ID in ( 154, 1869, 2510 ) , 0, G.DBill_AvgCost) AS BillAvgCost, K.BillType_ID AS BillTypeID" & Environment.NewLine
                        strSQL &= ", IF(G.Billcode_ID in ( 154, 1869, 2510 ) , 0, G.DBill_InvoiceAmt) AS BillInvoiceAmt" & Environment.NewLine
                        If Me._booAutoBill Then
                            strSQL &= ", A.Device_LaborCharge_AutoBilled AS DeviceLaborChg" & Environment.NewLine
                        Else
                            strSQL &= ", A.Device_LaborCharge AS DeviceLaborChg" & Environment.NewLine
                        End If
                        strSQL &= ", A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty" & Environment.NewLine
                        strSQL &= ", A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice" & Environment.NewLine
                        strSQL &= ", K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                        strSQL &= ", J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber" & Environment.NewLine
                        strSQL &= ", M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, G.Fail_ID AS FailID" & Environment.NewLine
                        strSQL &= ", IFNULL(N.Wrty_Labor, 0) AS WrtyLabor, IFNULL(N.Wrty_PartCost, 0) AS WrtyPartCost" & Environment.NewLine
                        strSQL &= ", IFNULL(N.WrtyClaimableFlg, 0) AS WarrantyClaimable" & Environment.NewLine
                        strSQL &= ", IFNULL(G.DBill_StdCost, 0) AS StandardCost" & Environment.NewLine
                        strSQL &= ", IF(G.DBill_InvoiceAmt is null or G.Billcode_ID IN ( 154, 1869, 2510 ), 0, G.DBill_InvoiceAmt) AS InvoiceAmount" & Environment.NewLine
                        strSQL &= ", IFNULL(G.DBill_AvgCost, 0) AS AverageCost " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods" & Environment.NewLine
                        If Me._booAutoBill Then
                            strSQL &= ", A.Device_PartCharge_AutoBilled AS Device_PartCharge" & Environment.NewLine
                        Else
                            strSQL &= ", A.Device_PartCharge" & Environment.NewLine
                        End If

                        strSQL &= ", A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, IF( Pallet_ShipType = 0 and N.WrtyStatus_ByWHRecDate = 1, 1, 0) as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        If Me._booAutoBill Then
                            strSQL &= "INNER JOIN tdevicebill_Special G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        Else
                            strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        End If
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = F.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tpallett P ON A.Pallett_ID = P.Pallett_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND I.Prod_ID = 2 AND A.Loc_ID = " & Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine

                    ElseIf Me._bTFTriageOnly Then
                        If bUseParams(0) Then strDateClause = Me.TFTriageDateStrings("C.Date_Rec", strDateRange) 'may want to change this later
                        'If bUseParams(0) Then strDateTriage = Me.TFTriageDateStrings("B.Triage_DateTime", strDateRange)

                        strSQL = "SELECT D.Model_Desc As 'Model', 0 AS 'Receiving Qty', 0.00 AS 'Receiving Charge', 0 AS 'Triage Qty', 0.00 AS 'Triage Charge', D.Model_ID AS 'Model_ID'" & Environment.NewLine
                        strSQL &= "FROM tdevice A" & Environment.NewLine
                        strSQL &= "LEFT JOIN production.tdevice_triaged_data B ON A.device_ID = B.device_ID" & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill_additional C ON A.device_ID = C.device_ID" & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel D ON D.model_ID = A.Model_ID" & Environment.NewLine
                        strSQL &= "WHERE C.BillCode_ID in (4333,4334,4335,4336)AND " & strDateClause & Environment.NewLine
                        strSQL &= "GROUP BY D.Model_ID;" & Environment.NewLine

                        strSQLRec = "SELECT D.Model_Desc As 'Model', IF (C.BillCode_ID = 4333, Count(C.Device_ID),0) AS 'Receiving Qty'," & Environment.NewLine
                        strSQLRec &= "IF (C.BillCode_ID = 4333, C.DBill_InvoiceAmt*COUNT(C.Device_ID),0) AS 'Receiving Charge'," & Environment.NewLine
                        strSQLRec &= "D.Model_ID AS 'Model_ID'" & Environment.NewLine
                        strSQLRec &= "FROM tdevice A" & Environment.NewLine
                        strSQLRec &= "LEFT JOIN production.tdevice_triaged_data B ON A.device_ID = B.device_ID" & Environment.NewLine
                        strSQLRec &= "INNER JOIN tdevicebill_additional C ON A.device_ID = C.device_ID" & Environment.NewLine
                        strSQLRec &= "INNER JOIN production.tmodel D ON D.model_ID = A.Model_ID" & Environment.NewLine
                        strSQLRec &= "WHERE C.BillCode_ID = 4333 AND " & strDateClause & Environment.NewLine
                        strSQLRec &= "GROUP BY D.Model_ID;" & Environment.NewLine

                        strSQLTri = "SELECT D.Model_Desc As 'Model'," & Environment.NewLine
                        strSQLTri &= "IF (C.BillCode_ID IN (4334,4335,4336), COUNT(C.Device_ID),0) AS 'Triage Qty'," & Environment.NewLine
                        strSQLTri &= "IF (C.BillCode_ID IN (4334,4335,4336), FORMAT(C.DBill_InvoiceAmt*COUNT(C.Device_ID),2),0) AS 'Triage Charge'," & Environment.NewLine
                        strSQLTri &= "D.Model_ID AS 'Model_ID'" & Environment.NewLine
                        strSQLTri &= "FROM tdevice A" & Environment.NewLine
                        strSQLTri &= "LEFT JOIN production.tdevice_triaged_data B ON A.device_ID = B.device_ID" & Environment.NewLine
                        strSQLTri &= "INNER JOIN tdevicebill_additional C ON A.device_ID = C.device_ID" & Environment.NewLine
                        strSQLTri &= "INNER JOIN production.tmodel D ON D.model_ID = A.model_ID" & Environment.NewLine
                        strSQLTri &= "INNER JOIN edi.titem E ON E.device_ID = A.device_ID" & Environment.NewLine
                        strSQLTri &= "INNER JOIN edi.twarehousebox F ON F.wb_id = E.wb_id" & Environment.NewLine
                        strSQLTri &= "WHERE C.BillCode_ID in (4334,4335,4336) AND Closed = 1 AND " & strDateClause & Environment.NewLine
                        strSQLTri &= "GROUP BY D.Model_ID;" & Environment.NewLine

                        ElseIf Me._bWFMOnly Then
                            Dim WFM_NTF_strDateClause As String = Me.SetupDateStrings("G.Date_Rec", strDateRange, 2)
                            'Dim WFM_Triage_strDateClause As String = Me.SetupDateStrings("wb.crt_ts", strDateRange, 2)
                            Dim WFM_Triage_strDateClause As String = Me.SetupDateStrings("G.Date_Rec", strDateRange, 2)

                            'NTF revenue----------------------------------------------------------------------------------------------------
                            strSQL = "SELECT "
                            If Me._booAutoBill Then
                                strSQL &= "'" & Me._strReportTitle & " AB ' AS ReportTitle" & Environment.NewLine
                            Else
                                strSQL &= "'" & Me._strReportTitle & "' AS ReportTitle" & Environment.NewLine
                            End If

                            strSQL &= ", '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            'strSQL = "SELECT 'Admin Revenue Detail TracFone' AS ReportTitle" & Environment.NewLine
                            'strSQL &= " , 'Feb 13, 2017 - Feb 17, 2017' AS DateRange," & Environment.NewLine
                            strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_AvgCost,0) AS 'BillAvgCost', K.BillType_ID AS BillTypeID" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS 'BillInvoiceAmt'" & Environment.NewLine
                            strSQL &= " , IF(G.billcode_ID=507,G.DBill_InvoiceAmt,0) as 'TriageLaborChg'" & Environment.NewLine
                            strSQL &= " , IF(G.billcode_ID=541 or G.billcode_ID=4227,G.DBill_InvoiceAmt,0) as 'NTFLaborChg'" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty" & Environment.NewLine
                            strSQL &= " , A.Device_ManufWrty AS DeviceManufWrty, 0 AS ASCBillPrice" & Environment.NewLine
                            strSQL &= " , K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , 120 AS GroupID, 'WFM (TF)' AS GroupDesc, 1 AS ShiftNumber" & Environment.NewLine
                            strSQL &= " , M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, G.Fail_ID AS FailID" & Environment.NewLine
                            strSQL &= " , IFNULL(N.Wrty_Labor, 0) AS WrtyLabor, IFNULL(N.Wrty_PartCost, 0) AS WrtyPartCost" & Environment.NewLine
                            strSQL &= " , IFNULL(N.WrtyClaimableFlg, 0) AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_StdCost, 0) AS StandardCost" & Environment.NewLine
                            strSQL &= " , IF(G.DBill_InvoiceAmt is null, 0, G.DBill_InvoiceAmt) AS InvoiceAmount" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_AvgCost, 0 ) AS AverageCost" & Environment.NewLine
                            strSQL &= " , A.Device_Qty" & Environment.NewLine
                            strSQL &= " , A.Device_FinishedGoods" & Environment.NewLine
                            strSQL &= " , A.Device_PartCharge" & Environment.NewLine
                            strSQL &= " , A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg" & Environment.NewLine
                            strSQL &= " , IF(N.WrtyStatus_ByWHRecDate = 1, 1, 0) as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " ,A.Device_ID,A.Device_SN,P.Pallett_ID,P.Pallett_Name,P.pallet_qc_passed,G.BillCode_ID" & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = I.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tpallett P ON P.pallett_ID = A.Pallett_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tCellOpt COP ON COP.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= "WHERE " & WFM_NTF_strDateClause & Environment.NewLine
                            'strSQL &= " WHERE  G.Date_Rec BETWEEN '2017-02-28' AND '2017-03-01'" & Environment.NewLine
                            strSQL &= " AND I.Prod_ID = 2 AND A.Loc_ID = 3402" & Environment.NewLine
                            'strSQL &= " AND P.pallet_qc_passed=1 AND COP.Workstation='WH-FLOOR'" & Environment.NewLine - changed by ACOLBURN 6/28/2017
                            strSQL &= " AND P.pallet_qc_passed=1 AND COP.Workstation IN ('WH-FLOOR','INTRANSIT')" & Environment.NewLine
                            strSQL &= " AND P.Disp_ID=5 AND G.billcode_ID in (507,541,4227)" & Environment.NewLine

                            'Triage (SOF,COS, FUN) Revnue
                            strSQL &= "UNION ALL SELECT "
                            If Me._booAutoBill Then
                                strSQL &= "'" & Me._strReportTitle & " AB ' AS ReportTitle" & Environment.NewLine
                            Else
                                strSQL &= "'" & Me._strReportTitle & "' AS ReportTitle" & Environment.NewLine
                            End If
                            'strSQL = "SELECT 'Admin Revenue Detail TracFone' AS ReportTitle" & Environment.NewLine
                            'strSQL &= " , 'Feb 13, 2017 - Feb 17, 2017' AS DateRange," & Environment.NewLine
                            strSQL &= ", '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_AvgCost,0) AS 'BillAvgCost', K.BillType_ID AS BillTypeID" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS 'BillInvoiceAmt'" & Environment.NewLine
                            strSQL &= " , IF(G.billcode_ID=507,G.DBill_InvoiceAmt,0) as 'TriageLaborChg'" & Environment.NewLine
                            strSQL &= " , 0 as 'NTFLaborChg'" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_InvoiceAmt,0) AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty" & Environment.NewLine
                            strSQL &= " , A.Device_ManufWrty AS DeviceManufWrty, 0 AS ASCBillPrice" & Environment.NewLine
                            strSQL &= " , K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , 120 AS GroupID, 'WFM (TF)' AS GroupDesc, 1 AS ShiftNumber" & Environment.NewLine
                            strSQL &= " , M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, G.Fail_ID AS FailID" & Environment.NewLine
                            strSQL &= " , IFNULL(N.Wrty_Labor, 0) AS WrtyLabor, IFNULL(N.Wrty_PartCost, 0) AS WrtyPartCost" & Environment.NewLine
                            strSQL &= " , IFNULL(N.WrtyClaimableFlg, 0) AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_StdCost, 0) AS StandardCost" & Environment.NewLine
                            strSQL &= " , IF(G.DBill_InvoiceAmt is null, 0, G.DBill_InvoiceAmt) AS InvoiceAmount" & Environment.NewLine
                            strSQL &= " , IFNULL(G.DBill_AvgCost, 0 ) AS AverageCost" & Environment.NewLine
                            strSQL &= " , A.Device_Qty" & Environment.NewLine
                            strSQL &= " , A.Device_FinishedGoods" & Environment.NewLine
                            strSQL &= " , A.Device_PartCharge" & Environment.NewLine
                            strSQL &= " , A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg" & Environment.NewLine
                            strSQL &= " , IF(N.WrtyStatus_ByWHRecDate = 1, 1, 0) as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " ,A.Device_ID,A.Device_SN,wb.whb_id AS 'Pallett_ID',wb.box_na AS 'Pallett_Name', 0 as 'pallet_qc_passed',G.BillCode_ID" & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = I.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN warehouse.wh_box wb on N.whb_id = wb.whb_id" & Environment.NewLine
                            strSQL &= "WHERE " & WFM_Triage_strDateClause & Environment.NewLine
                            'strSQL &= " WHERE wb.crt_ts BETWEEN '2017-03-01 00:00:00' AND '2017-03-01 23:59:59'" & Environment.NewLine
                            strSQL &= " AND I.Prod_ID = 2 AND A.Loc_ID = 3402" & Environment.NewLine
                            strSQL &= " AND wb.Disp_ID in (2,3,4) AND G.billcode_ID in (507)" & Environment.NewLine

                        ElseIf Me._bTMIOnly Then
                            strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName, G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, A.Device_PartCharge AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                            strSQL &= ", A.Device_Qty " & Environment.NewLine
                            strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                            strSQL &= "FROM tdevice A " & Environment.NewLine
                            strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                            strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                            strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID " & Environment.NewLine
                            strSQL &= "WHERE " & strDateClause & Environment.NewLine
                            strSQL &= "AND D.Cust_ID = " & Buisness.TMI.CUSTOMERID & Environment.NewLine
                        ElseIf Me._bSkullcandyOnly Then
                            strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                            strSQL &= "E.PCo_Name AS CompanyName," & Environment.NewLine
                            strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber,M.RptGrp_ID AS ReportGroupID,  O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                            strSQL &= ", A.Device_Qty " & Environment.NewLine
                            strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE " & strDateClause & Environment.NewLine
                            strSQL &= " AND D.Cust_ID =" & Buisness.Skullcandy.CUSTOMERID & " And F.EndUser = 0 " & Environment.NewLine

                        ElseIf Me._bPantechProductsOnly Then
                            strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName, G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, G.Fail_ID AS FailID, IFNULL(A.Device_LaborCharge, 0) AS WrtyLabor, 0 AS WrtyPartCost, A.Device_ManufWrty AS WarrantyClaimable, IFNULL(G.DBill_StdCost, 0) AS StandardCost, IFNULL(G.DBill_InvoiceAmt, 0) AS InvoiceAmount, IFNULL(G.DBill_AvgCost, 0) AS AverageCost " & Environment.NewLine
                            strSQL &= ", A.Device_Qty " & Environment.NewLine
                            strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                            strSQL &= "FROM tdevice A " & Environment.NewLine
                            strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                            strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                            strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = F.Prod_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN production.pantechasn N ON N.Device_ID = A.Device_ID " & Environment.NewLine

                            strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        Else
                            strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, IF(D.Cust_ID in (2599,2601,2602,2603,2604,2605,2606,2626,2627 ),D.Cust_Name1, E.PCo_Name) AS CompanyName, G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt,IF(D.Cust_ID=2623,4.50 , A.Device_LaborCharge) AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID, O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable " & Environment.NewLine
                            'strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName, G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID, M.RptGrp_Desc AS ReportGroupDesc " & Environment.NewLine
                            strSQL &= ", A.Device_Qty " & Environment.NewLine
                            strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                            strSQL &= "FROM tdevice A " & Environment.NewLine
                            strSQL &= "INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID " & Environment.NewLine
                            strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                            strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                            strSQL &= "INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID " & Environment.NewLine
                            strSQL &= "WHERE " & strDateClause & Environment.NewLine
                            strSQL &= "AND I.Prod_ID IN ("

                            strProdIDs = ""

                            For i = 0 To Me._iProductIDs.Length - 1
                                If Me._iProductIDs(i) > 0 Then
                                    If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                    strProdIDs &= Me._iProductIDs(i).ToString
                                End If
                            Next

                            strSQL &= strProdIDs & ") " & Environment.NewLine
                        End If

                        If Me._bAllProducts Then
                            strSQL &= "AND D.Cust_ID NOT IN (1381, 2258, 2519) AND O.manuf_id <> 64 " & Environment.NewLine 'Exclude CellStar/Brightpoint /TMI
                        ElseIf Me._bStanleyOnly Then
                            strSQL &= "AND D.Cust_ID = 1381 " & Environment.NewLine
                        ElseIf Me._bTMIOnly Then
                            strSQL &= "AND D.Cust_ID = 2519 " & Environment.NewLine
                        ElseIf Me._bPantechProductsOnly Then
                            strSQL &= "AND O.manuf_id = 64 " & Environment.NewLine
                        End If

                        If Me._bAllProducts And Not Me._bIncludeBrightpoint Then
                            strSQL &= "AND D.Cust_ID <> 2113 " & Environment.NewLine 'Exclude CellStar/Brightpoint
                        End If


                        If Me._bPantechProductsOnly Then
                            strSQL &= "ORDER BY A.Device_ManufWrty DESC, I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, O.Model_Desc, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                        Else
                            If Me._bTMIOnly Then
                                Dim TMI_strDateClause As String = Me.SetupDateStrings("URP_ChargedDate", strDateRange, 0)
                                strSQL &= " UNION ALL " & Environment.NewLine
                                strSQL &= " SELECT  '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                                strSQL &= "EW_ID as DeviceID,Type as ProdDesc,'TMI Solutions' as CompanyName,'' as BillAvgCost,'' as BillTypeID," & Environment.NewLine
                                strSQL &= "'' as BillInvoiceAmt,URP_Charge as DeviceLaborChg,'' as DeviceReject,'' as DevicePSSWrty,'' as DeviceManufWrty,'' as ASCBillPrice," & Environment.NewLine
                                strSQL &= "'' as BillCodeRule,'' as BillCodeID,102 as GroupID,'TMI' as GroupDesc, 99 as ShiftNumber,0 as ReportGroupID, concat(Brand,' ', Model)  AS ReportGroupDesc,'' as FailID," & Environment.NewLine
                                strSQL &= "'' as WrtyLabor,'' as WrtyPartCost,'' as WarrantyClaimable, 1 as Device_Qty,'' as Device_FinishedGoods," & Environment.NewLine
                                strSQL &= "'' as Device_PartCharge,'' as Device_ManufWrtyPartCharge,'' as Device_ManufWrtyLaborCharge, 0.0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                                strSQL &= " FROM(ExtendedWarranty)" & Environment.NewLine
                                strSQL &= " WHERE S_ID=8 AND Cust_ID=2519" & Environment.NewLine
                                strSQL &= " AND " & TMI_strDateClause & Environment.NewLine
                                strSQL &= "ORDER BY ProdDesc,GroupID,ShiftNumber,DeviceID,BillCodeRule,BillCodeID "
                            ElseIf Me._bSkullcandyOnly Then
                                Dim Skullcandy_strDateClause As String = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 2)
                                strSQL &= " UNION ALL " & Environment.NewLine
                                strSQL &= " SELECT  '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                                strSQL &= "A.device_ID,K.Prod_Desc,L.Cust_Name1 AS CompanyName," & Environment.NewLine
                                strSQL &= "0 AS BillAvgCost,0 AS BillTypeID, 0 AS BillInvoiceAmt," & Environment.NewLine
                                strSQL &= "0.99 AS DeviceLaborChg, 0 AS DeviceReject,0 AS DevicePSSWrty," & Environment.NewLine
                                strSQL &= "0 AS DeviceManufWrty,0 AS ASCBillPrice, 0 AS BillCodeRule," & Environment.NewLine
                                strSQL &= "0 AS BillCodeID, M.Group_ID AS GroupID, M.Group_Desc AS GroupDesc, 99 AS ShiftNumber," & Environment.NewLine
                                strSQL &= "N.RptGrp_ID AS ReportGroupID, B.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable," & Environment.NewLine
                                strSQL &= "A.Device_Qty, A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                                strSQL &= " FROM tdevice A" & Environment.NewLine
                                strSQL &= " INNER JOIN tmodel B ON A.model_ID = B.model_ID" & Environment.NewLine
                                strSQL &= " INNER JOIN tasndata C ON A.device_ID = C.device_ID" & Environment.NewLine
                                strSQL &= " INNER JOIN tlocation D ON A.Loc_ID = D.Loc_ID" & Environment.NewLine
                                strSQL &= " INNER JOIN tworkorder E ON A.WO_ID = E.WO_ID" & Environment.NewLine
                                strSQL &= " LEFT JOIN tcustmodel_pssmodel_map F ON B.model_ID = F.Model_ID AND F.Cust_ID = " & Buisness.Skullcandy.CUSTOMERID & Environment.NewLine
                                strSQL &= " LEFT JOIN cogs.modelfamilies G ON F.ModelFamiliesID = G.ModelFamiliesID" & Environment.NewLine
                                strSQL &= " INNER JOIN lproduct K ON K.Prod_ID = B.Prod_ID" & Environment.NewLine
                                strSQL &= " INNER JOIN tcustomer L ON L.Cust_ID =D.Cust_ID" & Environment.NewLine
                                strSQL &= " INNER JOIN lgroups M ON M.Group_ID = E.Group_ID" & Environment.NewLine
                                strSQL &= " INNER JOIN lrptgrp N ON N.RptGrp_ID = B.RptGrp_ID" & Environment.NewLine
                                strSQL &= " WHERE D.Cust_ID = " & Buisness.Skullcandy.CUSTOMERID & " And E.EndUser = 1" & Environment.NewLine
                                strSQL &= " AND " & Skullcandy_strDateClause & Environment.NewLine
                                strSQL &= " ORDER BY ProdDesc,GroupID,ShiftNumber,DeviceID,BillCodeRule,BillCodeID "
                            ElseIf Me._bWFMOnly Then
                                strSQL &= " ORDER BY ProdDesc, GroupID, if(D.Cust_ID=2599,D.Cust_Name1, E.PCo_Name),ShiftNumber, ReportGroupDesc, Device_ID, BillCodeRule, BillCode_ID "
                            ElseIf Me._bTFTriageOnly Then
                                'Do Nothing
                            Else
                            strSQL &= " ORDER BY I.Prod_Desc, J.Group_ID, IF(D.Cust_ID in (2599,2601,2602,2603,2604,2605,2606,2626,2627 ),D.Cust_Name1, E.PCo_Name), H.Shift_Number, O.Model_Desc, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                            End If
                            'strSQL &= "ORDER BY I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, O.Model_Desc, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                        End If


                        If strProdIDs = 69 Then 'NI only
                            Dim strDateTimeRange As String
                            strDateTimeRange = "BETWEEN '" & Format(Me._datStart, "yyyy-MM-dd") & " 00:00:00" & "' AND '" & Format(Me._datEnd, "yyyy-MM-dd") & " 23:59:59" & "'"

                            'Repairs
                            strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName, G.DBill_AvgCost AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , A.Device_Qty, A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN production.tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE A.Device_ShipWorkDate " & strDateTimeRange & Environment.NewLine
                            strSQL &= " AND I.Prod_ID IN (" & strProdIDs & ")" & Environment.NewLine
                            strSQL &= " AND D.Cust_ID NOT IN (1381, 2258, 2519) AND O.manuf_id <> 64" & Environment.NewLine
                            strSQL &= " AND D.Cust_ID <> 2113" & Environment.NewLine

                            strSQL &= " Union All " & Environment.NewLine

                            'Triage, Test, Sort
                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, B.inv_amt AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 95 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , A.Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM tdevice A" & Environment.NewLine
                            strSQL &= " INNER JOIN tdevicebill_pre_repair B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON K.BillCode_ID = B.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel O ON O.Model_ID = A.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE B.Date_rec " & strDateTimeRange & Environment.NewLine
                            strSQL &= " AND B.Cust_ID =2531" & Environment.NewLine

                            strSQL &= " Union All " & Environment.NewLine

                            'Call Tag Mailing
                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.EW_ID AS DeviceID, 'DJ Equipment' AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, A.LabelCharge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , 0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 96 AS ShiftNumber, 90 AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , IF(TRIM(L.NI_Prod_Desc)='' or L.NI_Prod_Desc is null,'Not Defined',L.NI_Prod_Desc) AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , 1 AS Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , 0 AS DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM extendedwarranty A" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = 3332" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON A.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                            strSQL &= " LEFT JOIN ni_products L ON A.Prod_code=L.NI_prod_ID" & Environment.NewLine
                            strSQL &= " WHERE A.CUST_ID=2531 AND A.BillCode_ID>0" & Environment.NewLine
                            strSQL &= " AND TrackCreatedDateTime  " & strDateTimeRange & Environment.NewLine

                            strSQL &= " Union All " & Environment.NewLine

                            'Receiving
                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " B.WI_ID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, B.Labor_Charge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , 0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 97 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , 1 AS Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , 0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM warehouse.warehouse_receipt A" & Environment.NewLine
                            strSQL &= " INNER JOIN warehouse.warehouse_items B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = 3332" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON B.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel O ON O.Model_ID = B.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE A.Cust_ID=2531 AND B.DevConditionID <> 3857" & Environment.NewLine
                            strSQL &= " AND B.Date_Received  " & strDateTimeRange & Environment.NewLine

                            'Pack and Ship
                            strSQL &= " Union All " & Environment.NewLine

                            strSQL &= "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                            strSQL &= " A.SOHeaderID AS DeviceID, I.Prod_Desc AS ProdDesc, E.PCo_Name AS CompanyName,0 AS BillAvgCost" & Environment.NewLine
                            strSQL &= " , K.BillType_ID AS BillTypeID, 0.0 AS BillInvoiceAmt, A.OrderShipmentCharge AS DeviceLaborChg" & Environment.NewLine
                            strSQL &= " , 0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty" & Environment.NewLine
                            strSQL &= " , 0 ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID" & Environment.NewLine
                            strSQL &= " , J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 98 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID" & Environment.NewLine
                            strSQL &= " , O.Model_Desc AS ReportGroupDesc, 0 AS FailID, 0 AS WrtyLabor, 0 AS WrtyPartCost, 0 AS WarrantyClaimable" & Environment.NewLine
                            strSQL &= " , 1 AS Device_Qty, 0 AS Device_FinishedGoods, 0 AS Device_PartCharge, 0 AS Device_ManufWrtyPartCharge, 0 AS Device_ManufWrtyLaborCharge" & Environment.NewLine
                            strSQL &= " , 0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit" & Environment.NewLine
                            strSQL &= " FROM saleorders.SOheader A" & Environment.NewLine
                            strSQL &= " INNER JOIN saleorders.SODetails B ON A.SOHeaderID=B.SOHeaderID" & Environment.NewLine
                            strSQL &= " INNER JOIN tlocation C ON C.Loc_ID = 3332" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tworkorder F ON F.WO_ID = A.WorkOrderID" & Environment.NewLine
                            strSQL &= " INNER JOIN lproduct I ON I.Prod_ID = O.Prod_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lgroups J ON J.Group_ID = F.Group_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lbillcodes K ON A.BillCode_ID = K.BillCode_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN tmodel O ON O.Model_ID = B.Model_ID" & Environment.NewLine
                            strSQL &= " INNER JOIN lrptgrp M ON M.RptGrp_ID = O.RptGrp_ID" & Environment.NewLine
                            strSQL &= " WHERE A.CUST_ID=2531 AND A.InvalidOrder=0" & Environment.NewLine
                            strSQL &= " AND A.ShipDate " & strDateTimeRange & Environment.NewLine


                            strSQL &= "ORDER BY ProdDesc, GroupID, CompanyName, ShiftNumber, ReportGroupDesc, DeviceID, BillCodeRule DESC, BillCodeID;"
                        End If

                        strTableName = "Admin Revenue Detail Data"

                Case Report_Call.SHIPPING_SHIPPED_DEVICE_QTY_BY_SHIP_TYPE
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("B.Pallett_ShipDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "E.Cust_Name1 AS CustName, G.Shift_Number AS ShiftNumber, F.Model_Desc AS ModelDesc, " & Environment.NewLine
                        strSQL &= "(CASE WHEN B.Pallet_ShipType = 0 THEN 'Refurbished' WHEN B.Pallet_ShipType = 1 THEN 'RUR' WHEN B.Pallet_ShipType = 8 THEN 'Scrap' WHEN B.Pallet_ShipType = 9 THEN (CASE WHEN UPPER(E.Cust_Name1) = 'GAMESTOP' THEN 'Incomplete' ELSE 'RTM' END) END) AS ShipType, " & Environment.NewLine
                        strSQL &= "IFNULL(D.WHP_Lot, '') AS WHPLot, COUNT(A.Device_ID) AS DeviceCount  " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tpallett B ON B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder C ON C.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN twarehousepallet D ON D.WHPallet_Number = C.WO_RecPalletName " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer E ON E.Cust_ID = B.Cust_ID AND E.Cust_ID = D.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel F ON F.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift G ON G.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine

                        If Not Me._bUseAllCustomers Then
                            strSQL &= "AND E.Cust_ID IN ("

                            strCustIDs = ""

                            For i = 0 To Me._iCustomerIDs.Length - 1
                                If Me._iCustomerIDs(i) > 0 Then
                                    If strCustIDs.Length > 0 Then strCustIDs &= ", "

                                    strCustIDs &= Me._iCustomerIDs(i).ToString
                                End If
                            Next

                            strSQL &= strCustIDs & ") " & Environment.NewLine
                        End If

                        strSQL &= "GROUP BY E.Cust_Name1, G.Shift_Number, F.Model_Desc, (CASE WHEN B.Pallet_ShipType = 0 THEN 'Refurbished' WHEN B.Pallet_ShipType = 1 THEN 'RUR' WHEN B.Pallet_ShipType = 8 THEN 'Scrap' WHEN B.Pallet_ShipType = 9 THEN (CASE WHEN UPPER(E.Cust_Name1) = 'GAMESTOP' THEN 'Incomplete' ELSE 'RTM' END) END), IFNULL(D.WHP_Lot, '') " & Environment.NewLine
                        strSQL &= "ORDER BY CustName, ShiftNumber, ModelDesc, WHP_Lot, ShipType"

                        strTableName = "Shipping Shipped Device Qty by Ship Type Data"

                Case Report_Call.SHIPPING_GAMESTOP_DEVICES_NOT_SHIPPED
                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, " & Environment.NewLine
                        strSQL &= "C.WO_RecPalletName AS RecPalletName, A.Device_SN AS DeviceSN, D.Model_Desc AS ModelDesc, IFNULL(B.Pallett_Name, '') AS PalletName " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "LEFT JOIN tpallett B ON B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder C ON C.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel D ON D.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "WHERE UPPER(D.Model_Desc) IN ("

                        strGSModels = ""

                        For i = 0 To Me._strGSModels.Length - 1
                            If Not IsNothing(Me._strGSModels(i)) Then
                                If Me._strGSModels(i).Length > 0 Then
                                    If strGSModels.Length > 0 Then strGSModels &= ", "

                                    strGSModels &= "'" & Me._strGSModels(i).ToUpper & "'"
                                End If
                            End If
                        Next

                        strSQL &= strGSModels & ") " & Environment.NewLine

                        If Me._strGSLotNumberPattern.Length > 0 Then strSQL &= "AND C.WO_RecPalletName LIKE '" & Me._strGSLotNumberPattern & "%'  " & Environment.NewLine

                        strSQL &= "AND A.Device_DateShip IS NULL " & Environment.NewLine
                        strSQL &= "ORDER BY D.Model_Desc, B.Pallett_Name DESC, C.WO_RecPalletName DESC"

                        strTableName = "GameStop Devices Not Shipped Data"

                Case Report_Call.INVENTORY_SCRAP_QUANTITY
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("DATE_FORMAT(C.EntryDate, '%Y-%m-%d')", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "DATE_FORMAT(C.EntryDate, '%Y-%m-%d') AS EntryDate, A.PSPrice_Number AS PSPriceNumber, C.tscrap_qty AS ScrapQty, A.PSPrice_Desc AS PSPriceDesc " & Environment.NewLine
                        strSQL &= "FROM lpsprice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tpsmap B ON B.PSPrice_ID = A.PSPrice_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tscrap C ON C.PSMap_ID = B.PSMap_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND C.tscrap_qty > 0 " & Environment.NewLine
                        strSQL &= "ORDER BY EntryDate, PSPriceNumber"

                        strTableName = "Inventory Scrap Quantity Data"

                Case Report_Call.ADMIN_REVENUE_AUP_BY_CUSTOMER_AND_MODEL
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "G.Prod_Desc AS ProdDesc, I.Group_Desc AS GroupDesc, C.Shift_Number AS ShiftNumber, J.Cust_ID AS CustID, J.Cust_Name1 AS Customer, B.Model_Desc AS ModelDesc, A.Device_ID AS DeviceID, IFNULL(H.BillCode_ID, 0) AS BillCodeID, " & Environment.NewLine
                        strSQL &= "H.BillCode_Rule AS BillCodeRule, IFNULL(D.DBill_InvoiceAmt, 0) AS BillInvoiceAmt, IFNULL(D.DBill_AvgCost, 0) AS BillAvgCost, H.BillType_ID AS BillTypeID " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift C ON C.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill D ON D.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation E ON E.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct G ON G.Prod_ID = F.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes H ON H.BillCode_ID = D.BillCode_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups I ON I.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer J ON J.Cust_ID = E.Cust_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & " " & Environment.NewLine
                        strSQL &= "AND G.Prod_ID IN ("

                        strProdIDs = ""

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                strProdIDs &= Me._iProductIDs(i).ToString
                            End If
                        Next

                        strSQL &= strProdIDs & ") " & Environment.NewLine

                        'strSQL &= "GROUP BY G.Prod_Desc, I.Group_ID, C.Shift_Number, J.Cust_ID, B.Model_ID, A.Device_ID " & Environment.NewLine
                        strSQL &= "ORDER BY G.Prod_Desc, I.Group_Desc, C.Shift_Number, J.Cust_Name1, B.Model_Desc, A.Device_ID, H.BillCode_Rule DESC, H.BillType_ID DESC, H.BillCode_ID"

                        strTableName = "Admin Revenue AUP by Customer and Model Data"

                Case Report_Call.TECHNICIAN_FAILURE_RATE
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.QC_WorkDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.QCResult_ID AS QCResultID, B.user_fullname AS UserName, A.Device_ID AS DeviceID, " & Environment.NewLine
                        strSQL &= "C.Shift_Number AS ShiftNumber, B.tech_id AS TechID " & Environment.NewLine
                        strSQL &= "FROM tqc A " & Environment.NewLine
                        strSQL &= "INNER JOIN security.tusers B ON B.User_ID = A.Tech_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift C ON C.Shift_ID = B.Shift_ID " & Environment.NewLine
                        strSQL &= "WHERE A.QC_Iteration = 1 " & Environment.NewLine
                        strSQL &= "AND " & strDateClause & " " & Environment.NewLine
                        strSQL &= "ORDER BY B.user_fullname, A.Device_ID"

                        strTableName = "Technician Failure Rate Data"

                Case Report_Call.RECEIVING_DETAIL
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_DateRec", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "G.Prod_Desc AS ProdDesc, B.Loc_Name AS LocName, F.PCo_Name AS CompanyName, D.WO_CustWO AS CustomerWO, A.Tray_ID AS TrayID, C.Model_Desc AS ModelDesc, " & Environment.NewLine
                        strSQL &= "A.Device_SN AS DeviceSN, IFNULL(A.Device_OldSN, '') AS DeviceOldSN, DATE_FORMAT(A.Device_DateRec, '%a, %b %e, %Y') AS DeviceDateRec, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, F.PCo_ID AS CompanyID " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder D ON D.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer E ON E.Cust_ID = B.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco F ON F.PCo_ID = E.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct G ON G.Prod_ID = C.Prod_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine

                        If Not Me._bUseAllCustomers Then
                            strSQL &= "AND E.Cust_ID IN ("

                            strCustIDs = ""

                            For i = 0 To Me._iCustomerIDs.Length - 1
                                If Me._iCustomerIDs(i) > 0 Then
                                    If strCustIDs.Length > 0 Then strCustIDs &= ", "

                                    strCustIDs &= Me._iCustomerIDs(i).ToString
                                End If
                            Next

                            strSQL &= strCustIDs & ") " & Environment.NewLine
                        End If

                        strSQL &= "AND G.Prod_ID IN ("

                        strProdIDs = ""

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                strProdIDs &= Me._iProductIDs(i).ToString
                            End If
                        Next

                        strSQL &= strProdIDs & ") " & Environment.NewLine

                        strSQL &= "ORDER BY G.Prod_Desc, F.PCo_Name, D.WO_CustWO, C.Model_Desc"

                        strTableName = "Receiving Detail Data"

                Case Report_Call.CELL_SHIPPED_PALLETS
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("B.Pallett_ShipDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "D.Cust_Name1 AS Customer, B.Pallett_Name AS PalletName, DATE_FORMAT(B.Pallett_ShipDate, '%a, %b %e, %Y') AS PalletShipDate, " & Environment.NewLine
                        strSQL &= "(CASE WHEN B.Pallet_ShipType = 0 THEN 'Refurbished' WHEN B.Pallet_ShipType = 1 THEN 'RUR' WHEN B.Pallet_ShipType = 8 THEN 'Scrap' WHEN B.Pallet_ShipType = 9 THEN 'RTM' ELSE '' END) AS PalletType, " & Environment.NewLine
                        strSQL &= "C.Model_Desc AS ModelDesc, COUNT(A.Device_ID) AS DeviceCount " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tpallett B ON B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = B.Cust_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & " " & Environment.NewLine
                        strSQL &= "AND C.Prod_ID = 2 " & Environment.NewLine
                        strSQL &= "GROUP BY B.Pallett_ID " & Environment.NewLine
                        strSQL &= "ORDER BY D.Cust_Name1, B.Pallett_Name"

                        strTableName = "Cell Shipped Pallets Data"

                Case Report_Call.SHIPPING_ATCLE_PASS_FAIL
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)
                        strDeviceIDsIn = ""

                        'First, get devices that are in tpretest_data
                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, C.Model_Desc AS ModelDesc, B.Pallet_ShipType AS PalletShipType, " & Environment.NewLine
                        strSQL &= "MAX(D.tpretest_id) AS MaxPreTestID, " & Environment.NewLine
                        'strSQL &= "D.PTFunc AS PreTestFunc, "
                        strSQL &= "IF(B.Pallet_ShipType = 9 AND D.PTFunc = 0 AND D.PTFlash = 0 AND D.PTRF = 0, 1, D.PTFunc) AS PreTestFunc, "
                        strSQL &= "D.PTFlash AS PreTestFlash, "
                        'strSQL &= "IF(B.Pallet_ShipType = 9 AND D.PTFunc <= 1 AND D.PTFlash <= 1 AND D.PTRF <= 1, 3, D.PTFlash) AS PreTestFlash, "
                        strSQL &= "D.PTRF AS PreTestRF, D.PTTF AS PreTestPFCode, D.tpretest_id AS PreTestID" & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tpallett B ON B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tpretest_data D ON D.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND A.Loc_ID = 2540 " & Environment.NewLine
                        strSQL &= "AND B.Pallet_ShipType IN (0, 1, 9) " & Environment.NewLine
                        strSQL &= "GROUP BY C.Model_ID, A.Device_ID, D.tpretest_id " & Environment.NewLine
                        strSQL &= "ORDER BY ModelDesc, DeviceID, PreTestID DESC"

                        dtTemp = Me._objDataProc.GetDataTable(strSQL)

                        If Not IsNothing(dtTemp) Then
                            dt = CreateATCLEPassFailTable(strTableName)
                            iTempDeviceID = 0

                            For Each drTemp In dtTemp.Rows
                                If drTemp("DeviceID") <> iTempDeviceID Then
                                    If strDeviceIDsIn.Length > 0 Then
                                        strDeviceIDsIn &= ", "
                                    End If

                                    strDeviceIDsIn &= drTemp("DeviceID").ToString

                                    drNew = dt.NewRow

                                    drNew("ReportTitle") = drTemp("ReportTitle")
                                    drNew("DateRange") = drTemp("DateRange")
                                    drNew("DeviceID") = drTemp("DeviceID")
                                    drNew("ModelDesc") = drTemp("ModelDesc")
                                    drNew("PalletShipType") = drTemp("PalletShipType")
                                    drNew("PreTestID") = drTemp("MaxPreTestID")
                                    drNew("PreTestFunc") = drTemp("PreTestFunc")
                                    drNew("PreTestFlash") = drTemp("PreTestFlash")
                                    drNew("PreTestRF") = drTemp("PreTestRF")
                                    drNew("PreTestPFCode") = drTemp("PreTestPFCode")

                                    dt.Rows.Add(drNew)
                                    iTempDeviceID = drTemp("DeviceID")
                                End If
                            Next

                            ds.Tables.Add(dt)
                        End If

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, C.Model_Desc AS ModelDesc, B.Pallet_ShipType AS PalletShipType, " & Environment.NewLine
                        strSQL &= "0 AS MaxPreTestID, " & Environment.NewLine
                        strSQL &= "0 AS PreTestFunc, " & Environment.NewLine
                        strSQL &= "IF( B.Pallet_ShipType = 9, 1, 0) AS PreTestFlash, "
                        strSQL &= "0 AS PreTestRF, " & Environment.NewLine
                        strSQL &= "(CASE WHEN B.Pallet_ShipType = 0 THEN 2515 WHEN B.Pallet_ShipType = 1 THEN 2520 ELSE 2517 END) AS PreTestPFCode, " & Environment.NewLine
                        strSQL &= "0 AS PreTestID" & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tpallett B ON B.Pallett_ID = A.Pallett_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND A.Loc_ID = 2540 " & Environment.NewLine
                        strSQL &= "AND B.Pallet_ShipType IN (0, 1, 9) " & Environment.NewLine

                        If strDeviceIDsIn.Length > 0 Then
                            strSQL &= "AND A.Device_ID NOT IN (" & strDeviceIDsIn & ") " & Environment.NewLine
                        End If

                        strSQL &= "GROUP BY C.Model_ID, A.Device_ID " & Environment.NewLine
                        strSQL &= "ORDER BY ModelDesc, DeviceID"

                        dtTemp = Me._objDataProc.GetDataTable(strSQL)

                        If Not IsNothing(dtTemp) Then
                            If IsNothing(dt) Then dt = CreateATCLEPassFailTable(strTableName)
                            iTempDeviceID = 0

                            For Each drTemp In dtTemp.Rows
                                If drTemp("DeviceID") <> iTempDeviceID Then
                                    drNew = dt.NewRow

                                    drNew("ReportTitle") = drTemp("ReportTitle")
                                    drNew("DateRange") = drTemp("DateRange")
                                    drNew("DeviceID") = drTemp("DeviceID")
                                    drNew("ModelDesc") = drTemp("ModelDesc")
                                    drNew("PalletShipType") = drTemp("PalletShipType")
                                    drNew("PreTestID") = drTemp("MaxPreTestID")
                                    drNew("PreTestFunc") = drTemp("PreTestFunc")
                                    drNew("PreTestFlash") = drTemp("PreTestFlash")
                                    drNew("PreTestRF") = drTemp("PreTestRF")
                                    drNew("PreTestPFCode") = drTemp("PreTestPFCode")

                                    dt.Rows.Add(drNew)

                                    iTempDeviceID = drTemp("DeviceID")
                                End If
                            Next

                            If ds.Tables.Count = 0 Then ds.Tables.Add(dt)
                        End If

                        strTableName = "ATCLE Pass-Fail Data"

                Case Report_Call.ADMIN_REVENUE_DETAIL_BRIGHTPOINT_AB
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "IF(UPPER(TRIM(E.PCo_Name)) = 'CELLSTAR', 'Brightpoint', E.PCo_Name) AS CompanyName, " & Environment.NewLine
                        strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge_Autobilled AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber, M.RptGrp_ID AS ReportGroupID, M.RptGrp_Desc AS ReportGroupDesc " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill_563 G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = F.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel L ON L.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lrptgrp M ON M.RptGrp_ID = L.RptGrp_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND D.Cust_ID = 2113 " & Environment.NewLine
                        strSQL &= "ORDER BY I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, M.RptGrp_Desc, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"

                        strTableName = "Admin Revenue Detail Brightpoint Data"

                Case Report_Call.ADMIN_REVENUE_SUMMARY_BRIGHTPOINT_AB
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, " & Environment.NewLine
                        strSQL &= "IF(UPPER(TRIM(E.PCo_Name)) = 'CELLSTAR', 'Brightpoint', E.PCo_Name) AS CompanyName, " & Environment.NewLine
                        strSQL &= "G.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, G.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge_Autobilled AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, H.Shift_Number AS ShiftNumber " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer D ON D.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco E ON E.PCo_ID = D.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder F ON F.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill_563 G ON G.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tshift H ON H.Shift_ID = A.Shift_ID_Ship " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = F.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups J ON J.Group_ID = F.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = G.BillCode_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND D.Cust_ID = 2113 " & Environment.NewLine
                        strSQL &= "ORDER BY I.Prod_Desc, J.Group_ID, E.PCo_Name, H.Shift_Number, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"

                        strTableName = "Admin Revenue Summary Brightpoint Data"

                Case Report_Call.AMERICAN_MESSAGING_SHIP_DEMAND
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Device_ShipWorkDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "B.Model_Desc AS ModelDesc, D.Freq_Number AS FreqNumber,  COUNT(*) AS DeviceCount " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmessdata C ON A.Device_ID = C.device_id " & Environment.NewLine
                        strSQL &= "INNER JOIN lfrequency D ON C.freq_id = D.freq_id " & Environment.NewLine
                        strSQL &= "WHERE A.Loc_ID = 19 " & Environment.NewLine
                        strSQL &= "AND " & strDateClause & Environment.NewLine
                        strSQL &= "AND A.Ship_ID <> 9999919 " & Environment.NewLine 'No DBR, NER, etc.
                        strSQL &= "GROUP BY B.Model_Desc, D.Freq_Number " & Environment.NewLine
                        strSQL &= "ORDER BY B.Model_Desc, D.Freq_Number"

                        strTableName = "American Messaging Ship Demand Data"

                Case Report_Call.ADMIN_REVENUE_AUP_DAILY_PRODUCTION
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("F.DP_Date", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "H.Prod_Desc AS ProdDesc, I.Group_Desc AS GroupDesc, B.Model_Desc AS ModelDesc, G.Cust_Name1 AS Customer, A.Device_ID AS DeviceID, J.BillCode_ID AS BillCodeID, J.BillCode_Rule AS BillCodeRule, D.DBill_InvoiceAmt AS BillInvoiceAmt, "
                        strSQL &= "D.DBill_AvgCost AS BillAvgCost, J.BillType_ID AS BillTypeID " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel B ON B.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill D ON D.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder E ON E.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdailyproduction F ON F.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer G ON G.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct H ON H.Prod_ID = E.Prod_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lgroups I ON I.Group_ID = E.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes J ON J.BillCode_ID = D.BillCode_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND H.Prod_ID IN ("

                        strProdIDs = ""

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                strProdIDs &= Me._iProductIDs(i).ToString
                            End If
                        Next

                        strSQL &= strProdIDs & ") " & Environment.NewLine

                        strSQL &= "ORDER BY H.Prod_Desc, I.Group_Desc, G.Cust_Name1, B.Model_Desc, A.Device_ID, J.BillCode_Rule DESC, J.BillType_ID DESC, J.BillCode_ID"

                        strTableName = "Admin Revenue-AUP Daily Production Data"

                Case Report_Call.ADMIN_REVENUE_DAILY_PRODUCTION
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("F.DP_Date", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "A.Device_ID AS DeviceID, I.Prod_Desc AS ProdDesc, H.PCo_Name AS CompanyName, E.DBill_AvgCost AS BillAvgCost, K.BillType_ID AS BillTypeID, E.DBill_InvoiceAmt AS BillInvoiceAmt, A.Device_LaborCharge AS DeviceLaborChg, A.Device_Reject AS DeviceReject, A.Device_PSSWrty AS DevicePSSWrty, A.Device_ManufWrty AS DeviceManufWrty, " & Environment.NewLine
                        strSQL &= "IFNULL(B.ASCBill_Price, 0) AS ASCBillPrice, K.BillCode_Rule AS BillCodeRule, K.BillCode_ID AS BillCodeID, L.Model_Desc AS ModelDesc " & Environment.NewLine
                        'strSQL &= "B.ASCBill_Price, A.Device_DateShip, K.BillCode_Rule, K.BillCode_ID, J.Group_ID, J.Group_Desc " & Environment.NewLine
                        strSQL &= ", A.Device_Qty " & Environment.NewLine
                        strSQL &= ", A.Device_FinishedGoods, A.Device_PartCharge, A.Device_ManufWrtyPartCharge, A.Device_ManufWrtyLaborCharge, A.Device_PartCharge as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                        strSQL &= "FROM tdevice A " & Environment.NewLine
                        strSQL &= "LEFT JOIN tascbill B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation C ON C.Loc_ID = A.Loc_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tworkorder D ON D.WO_ID = A.WO_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevicebill E ON E.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tdailyproduction F ON F.Device_ID = A.Device_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer G ON G.Cust_ID = C.Cust_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lparentco H ON H.PCo_ID = G.PCo_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lproduct I ON I.Prod_ID = D.Prod_ID " & Environment.NewLine
                        'strSQL &= "INNER JOIN lgroups J ON J.Group_ID = D.Group_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN lbillcodes K ON K.BillCode_ID = E.BillCode_ID " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel L ON L.Model_ID = A.Model_ID " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND I.Prod_ID IN ("

                        strProdIDs = ""

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                strProdIDs &= Me._iProductIDs(i).ToString
                            End If
                        Next

                        strSQL &= strProdIDs & ") " & Environment.NewLine

                        strSQL &= "ORDER BY I.Prod_Desc, L.Model_Desc, H.PCo_Name, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"
                        'strSQL &= "ORDER BY I.Prod_Desc, J.Group_ID, H.PCo_Name, A.Device_ID, K.BillCode_Rule DESC, K.BillCode_ID"

                        strTableName = "Admin Revenue Daily Production Data"

                Case Report_Call.MESSAGING_PRODUCT_WIP
                        'Daily demand
                        strSQL = "SELECT B.model_desc, C.freq_number, A.Tier, A.DailyDemand, 0 AS Received, 0 AS Labeled, 0 AS Shipped, 1 AS Counted " & Environment.NewLine
                        strSQL &= "FROM tMsgGoals A " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel B ON B.model_id = A.ModelID " & Environment.NewLine
                        strSQL &= "INNER JOIN lfrequency C ON C.freq_id = A.FreqID " & Environment.NewLine
                        strSQL &= "WHERE A.Tier IN (1, 2, 3) " & Environment.NewLine
                        strSQL &= "ORDER BY A.Tier, B.model_desc, C.freq_number " & Environment.NewLine

                        dtInitial = Me._objDataProc.GetDataTable(strSQL)
                        'strSQL &= "UNION " & Environment.NewLine

                        'Received
                        strSQL = "SELECT C.model_desc, IFNULL(D.freq_number, '') AS freq_number, 0 AS Tier, 0 AS DailyDemand, COUNT(*) AS Received, 0 AS Labeled, 0 AS Shipped, 0 AS Counted " & Environment.NewLine
                        strSQL &= "FROM tmessdata A " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevice B ON B.device_id = A.device_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.model_id = B.model_id " & Environment.NewLine
                        strSQL &= "LEFT JOIN lfrequency D ON D.freq_id = A.freq_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation F ON F.loc_id = B.loc_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer G ON G.cust_id = F.cust_id " & Environment.NewLine
                        strSQL &= "WHERE G.cust_id = 14 " & Environment.NewLine ' American Messaging only
                        strSQL &= "AND A.label_userid IS NULL " & Environment.NewLine
                        strSQL &= "AND B.Device_DateShip IS NULL " & Environment.NewLine
                        strSQL &= "GROUP BY C.model_desc, D.freq_number " & Environment.NewLine
                        strSQL &= "UNION " & Environment.NewLine

                        'Labeled
                        strSQL &= "SELECT C.model_desc, IFNULL(D.freq_number, '') AS freq_number, 0 AS Tier, 0 AS DailyDemand, 0 AS Received, COUNT(*) AS Labeled, 0 AS Shipped, 0 AS Counted " & Environment.NewLine
                        strSQL &= "FROM tmessdata A " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevice B ON B.device_id = A.device_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.model_id = B.model_id " & Environment.NewLine
                        strSQL &= "LEFT JOIN lfrequency D ON D.freq_id = A.freq_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation F ON F.loc_id = B.loc_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer G ON G.cust_id = F.cust_id " & Environment.NewLine
                        strSQL &= "WHERE G.cust_id = 14 " & Environment.NewLine ' American Messaging only
                        strSQL &= "AND A.label_userid IS NOT NULL " & Environment.NewLine
                        strSQL &= "AND B.Device_DateShip IS NULL " & Environment.NewLine
                        strSQL &= "GROUP BY C.model_desc, D.freq_number " & Environment.NewLine
                        strSQL &= "UNION " & Environment.NewLine

                        'Shipped
                        strSQL &= "SELECT C.model_desc, IFNULL(D.freq_number, '') AS freq_number, 0 AS Tier, 0 AS DailyDemand, 0 AS Received, 0 AS Labeled, COUNT(*) AS Shipped, 0 AS Counted " & Environment.NewLine
                        strSQL &= "FROM tmessdata A " & Environment.NewLine
                        strSQL &= "INNER JOIN tdevice B ON B.device_id = A.device_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tmodel C ON C.model_id = B.model_id " & Environment.NewLine
                        strSQL &= "LEFT JOIN lfrequency D ON D.freq_id = A.freq_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tlocation F ON F.loc_id = B.loc_id " & Environment.NewLine
                        strSQL &= "INNER JOIN tcustomer G ON G.cust_id = F.cust_id " & Environment.NewLine
                        strSQL &= "WHERE G.cust_id = 14 " & Environment.NewLine ' American Messaging only
                        strSQL &= "AND A.label_userid IS NOT NULL " & Environment.NewLine
                        strSQL &= "AND B.Device_DateShip = " & String.Format("'{0:yyyy}-{0:MM}-{0:dd}' ", Now) & Environment.NewLine
                        strSQL &= "GROUP BY C.model_desc, D.freq_number"

                        dtTemp = Me._objDataProc.GetDataTable(strSQL)

                        For Each drInitial In dtInitial.Rows
                            iReceived = 0
                            iLabeled = 0
                            iShipped = 0
                            drTempArr = dtTemp.Select("model_desc = '" & drInitial("model_desc") & "' AND freq_number = '" & drInitial("freq_number") & "'")

                            If drTempArr.Length > 0 Then
                                For i = 0 To drTempArr.Length - 1
                                    iReceived += drTempArr(i)("Received")
                                    iLabeled += drTempArr(i)("Labeled")
                                    iShipped += drTempArr(i)("Shipped")
                                    drTempArr(i)("Counted") = 1

                                    drTempArr(i).AcceptChanges()
                                Next i
                            End If

                            drInitial("Received") = iReceived
                            drInitial("Labeled") = iLabeled
                            drInitial("Shipped") = iShipped

                            drInitial.AcceptChanges()
                        Next drInitial

                        strTableName = "Messaging Product WIP Data"
                        dt = CreateMessagingWIPProductTable(strTableName)

                        For Each drInitial In dtInitial.Rows
                            drNew = dt.NewRow

                            drNew("ReportTitle") = Me._strReportTitle
                            drNew("Tier") = drInitial("Tier")
                            drNew("ModelDesc") = IIf(IsDBNull(drInitial("model_desc")) Or drInitial("model_desc").ToString.Trim.Length = 0, "-- No Model --", drInitial("model_desc"))
                            drNew("Frequency") = IIf(IsDBNull(drInitial("freq_number")) Or drInitial("freq_number").ToString.Trim.Length = 0, "-- No Freq --", drInitial("freq_number"))
                            drNew("DailyDemand") = drInitial("DailyDemand")
                            drNew("Received") = drInitial("Received")
                            drNew("Labeled") = drInitial("Labeled")
                            drNew("Shipped") = drInitial("Shipped")

                            dt.Rows.Add(drNew)
                        Next drInitial

                        strTempModelDesc = ""
                        strTempFreq = ""
                        drTempArr = dtTemp.Select("Counted = 0", "model_desc ASC, freq_number ASC")

                        If drTempArr.Length > 0 Then
                            For i = 0 To drTempArr.Length - 1
                                If strTempModelDesc <> drTempArr(i)("model_desc") Or strTempFreq <> drTempArr(i)("freq_number") Then
                                    drNew = dt.NewRow

                                    drNew("ReportTitle") = Me._strReportTitle
                                    drNew("Tier") = 4
                                    drNew("ModelDesc") = IIf(IsDBNull(drTempArr(i)("model_desc")) Or drTempArr(i)("model_desc").ToString.Trim.Length = 0, "-- No Model --", drTempArr(i)("model_desc"))
                                    drNew("Frequency") = IIf(IsDBNull(drTempArr(i)("freq_number")) Or drTempArr(i)("freq_number").ToString.Trim.Length = 0, "-- No Freq --", drTempArr(i)("freq_number"))
                                    drNew("DailyDemand") = 0
                                    drNew("Received") = 0
                                    drNew("Labeled") = 0
                                    drNew("Shipped") = 0

                                    dt.Rows.Add(drNew)
                                    drCurrent = dt.Rows(dt.Rows.Count - 1)
                                Else
                                    drCurrent("Received") += drTempArr(i)("Received")
                                    drCurrent("Labeled") += drTempArr(i)("Labeled")
                                    drCurrent("Shipped") += drTempArr(i)("Shipped")

                                    drCurrent.AcceptChanges()
                                End If
                            Next i
                        End If

                        ds.Tables.Add(dt)

                Case Report_Call.ADMIN_REVENUE_SUMMARY_SPECIAL_PROJECTS
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Pallett_ShipDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "'Gaming Devices' AS ProdDesc, 'Gamestop' AS 'Group', 'Gamestop' AS CompanyName, B.model_desc AS ModelDesc, A.pallett_id AS PallettID, A.pallett_qty AS Quantity " & Environment.NewLine
                        strSQL &= ", (A.Pallett_QTY * C.sp_laborprice) AS LaborCharge " & Environment.NewLine
                        strSQL &= ", A.Pallet_ShipType AS ShipType, 0 AS CostAmount, 0 AS PartsSvcCharge" & Environment.NewLine
                        strSQL &= "FROM production.tpallett A" & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel B ON B.model_id = A.model_id" & Environment.NewLine
                        strSQL &= "LEFT OUTER JOIN tspecialproject_laborprice C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                        strSQL &= "AND A.Cust_ID = C.Cust_ID AND A.Pallet_ShipType = C.BillCode_Rule " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND A.SpecialInvProject = 1 " & Environment.NewLine
                        'strSQL &= "AND UPPER(B.model_desc) LIKE 'GUITAR%'" & Environment.NewLine
                        strSQL &= "AND B.Prod_ID IN ("

                        strProdIDs = ""

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                strProdIDs &= Me._iProductIDs(i).ToString
                            End If
                        Next

                        strSQL &= strProdIDs & ") " & Environment.NewLine
                        strSQL &= "ORDER BY ModelDesc, PallettID, ShipType"

                        strTableName = "Admin Revenue Summary Special Projects Data"

                Case Report_Call.ADMIN_REVENUE_DETAIL_SPECIAL_PROJECTS
                        If bUseParams(0) Then strDateClause = Me.SetupDateStrings("A.Pallett_ShipDate", strDateRange, 0)

                        strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                        strSQL &= "'Gaming Devices' AS ProdDesc, 'Gamestop' AS 'Group', 'Gamestop' AS CompanyName, B.model_desc AS ModelDesc, A.pallett_id AS PallettID, A.pallett_qty AS Quantity " & Environment.NewLine
                        strSQL &= ", ( A.Pallett_QTY * C.sp_laborprice) AS LaborCharge " & Environment.NewLine
                        strSQL &= ", A.Pallet_ShipType AS ShipType, 0 AS CostAmount, 0 AS PartsSvcCharge" & Environment.NewLine
                        strSQL &= "FROM production.tpallett A" & Environment.NewLine
                        strSQL &= "INNER JOIN production.tmodel B ON B.model_id = A.model_id" & Environment.NewLine
                        strSQL &= "LEFT OUTER JOIN tspecialproject_laborprice C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                        strSQL &= "AND A.Cust_ID = C.Cust_ID AND A.Pallet_ShipType = C.BillCode_Rule " & Environment.NewLine
                        strSQL &= "WHERE " & strDateClause & Environment.NewLine
                        strSQL &= "AND A.SpecialInvProject = 1 " & Environment.NewLine
                        'strSQL &= "AND UPPER(B.model_desc) LIKE 'GUITAR%'" & Environment.NewLine
                        strSQL &= "AND B.Prod_ID IN ("

                        strProdIDs = ""

                        For i = 0 To Me._iProductIDs.Length - 1
                            If Me._iProductIDs(i) > 0 Then
                                If strProdIDs.Length > 0 Then strProdIDs &= ", "

                                strProdIDs &= Me._iProductIDs(i).ToString
                            End If
                        Next

                        strSQL &= strProdIDs & ") " & Environment.NewLine
                        strSQL &= "ORDER BY ModelDesc, PallettID, ShipType"

                        strTableName = "Admin Revenue Detail Special Projects Data"
            End Select

            If IsNothing(dt) Then
                dt = Me._objDataProc.GetDataTable(strSQL)

                If Me._bTFTriageOnly Then

                    If IsNothing(dtRec) Then
                        dtRec = Me._objDataProc.GetDataTable(strSQLRec)
                    End If

                    If IsNothing(dtTri) Then
                        dtTri = Me._objDataProc.GetDataTable(strSQLTri)
                    End If

                    'update master table
                    Dim intModelID As Integer

                    Dim intIndex As Integer
                    Dim intRecIndex As Integer
                    Dim intTriageIndex As Integer
                    Dim row As DataRow
                    Dim rowRec As DataRow
                    Dim rowTri As DataRow


                    'Always start at 0
                    intIndex = 0


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'This is the big loop going through all of the master table records getting the model ID to compare to the Triage and Rec tables
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For Each row In dt.Rows

                        'Get the model ID
                        intModelID = row("Model_ID")


                        'Start the loop w/ index = 0 every time
                        intRecIndex = 0

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'Inner Loop 1 through Receive table looking for master model ID
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        For Each rowRec In dtRec.Rows

                            'Did we get a match?
                            If dtRec.Rows(intRecIndex)("Model_ID") = intModelID Then

                                'Set the rec value in the master table to the rec value in the received data table
                                dt.Rows(intIndex)("Receiving Qty") = dtRec.Rows(intRecIndex)("Receiving Qty")
                                dt.Rows(intIndex)("Receiving Charge") = dtRec.Rows(intRecIndex)("Receiving Charge")

                            End If

                            'increment the rec index
                            intRecIndex = intRecIndex + 1

                        Next rowRec



                        'Start the loop w/ index = 0 every time
                        intTriageIndex = 0

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'Inner Loop 2 through Triage table looking for master model ID
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        For Each rowTri In dtTri.Rows

                            'Did we get a match?
                            If dtTri.Rows(intTriageIndex)("Model_ID") = intModelID Then

                                'Set the rec value in the master table to the rec value in the received data table
                                dt.Rows(intIndex)("Triage Qty") = dtTri.Rows(intTriageIndex)("Triage Qty")
                                dt.Rows(intIndex)("Triage Charge") = dtTri.Rows(intTriageIndex)("Triage Charge")

                            End If

                            'increment the triage index
                            intTriageIndex = intTriageIndex + 1

                        Next rowTri

                        'increment the master index
                        intIndex = intIndex + 1
                    Next row

                    If dt.Columns.Contains("Model_ID") Then
                        dt.Columns.Remove(dt.Columns("Model_ID"))
                    End If

                End If

                ''**************************************
                ''Add special project pallet to report
                ''**************************************
                'If Me._rc = Report_Call.ADMIN_REVENUE_SUMMARY Or Me._rc = Report_Call.ADMIN_REVENUE_DETAIL Then
                '    Me.AddSpecialProjDevices(dt, strProdIDs, strDateClause, strDateRange, strProdIDs)
                'End If
                ''**************************************
                If Me._rc = Report_Call.ADMIN_REVENUE_DETAIL_SPECIAL_PROJECTS Or Me._rc = Report_Call.ADMIN_REVENUE_DETAIL_SPECIAL_PROJECTS Then
                    If dt.Select("LaborCharge is null").Length > 0 Then
                        Throw New Exception("Labor price is missing for some model. Please contact IT.")
                    End If
                End If
            End If

            If Not IsNothing(dt) Then
                '**************************************
                'Separate Battery cover charge for TF
                '**************************************
                If Me._bTracfoneOnly AndAlso dt.Rows.Count > 0 Then Me.SeparateBatteryCover(dt)
                '**************************************

                'ZF: Gave up this --------------------------------------------------------------------------
                'For TMI URP (Non-return kit charge), Laptop or desktop, if any ----------------------------
                ' AddTMI_URP_Charges(bUseParams, dt)
                '-------------------------------------------------------------------------------------------

                If dt.Rows.Count = 0 Then
                    Me._objDataProc.DisplayMessage("No data returned for the selected criteria.", 3, False)
                Else


                    Dim iTempvalue As Integer
                    Dim dTempSumkitting As Decimal
                    Dim dtRow As DataRow
                    Dim j As Integer = 0
                    Dim iArrayList As New ArrayList()
                    For Each dtRow In dt.Rows
                        If Not iArrayList.Contains(dt.Rows.Item(j).Item("deviceid")) Then
                            'Did we get a match?
                            If dt.Rows(j)("GroupID") = 134 Then

                                dTempSumkitting = getSUMKitting(dt.Rows.Item(j).Item("deviceid"))
                                Dim IntTemsAmount As Integer
                                IntTemsAmount = dt.Rows.Item(j).Item("BillInvoiceAmt")
                                dt.Rows(j)("BillInvoiceAmt") = IntTemsAmount + dTempSumkitting
                                iArrayList.Add(dt.Rows.Item(j).Item("deviceid"))
                            End If
                        End If
                        'increment the triage index
                        j = j + 1

                    Next dtRow

                    dt.TableName = strTableName
                    ds.Tables.Add(dt)

                    For i = 0 To strSubRptSQL.Length - 1
                        If strSubRptSQL(i).Length > 0 Then
                            dtSubRpt(i) = Me._objDataProc.GetDataTable(strSubRptSQL(i))
                            dtSubRpt(i).TableName = strSubRptTableName(i)
                            ds.Tables.Add(dtSubRpt(i))
                        Else
                            Exit For
                        End If
                    Next
                End If
            End If

            Return ds
        Catch ex As Exception
            Me._objDataProc.DisplayMessage(ex.Message)
        Finally
            drInitial = Nothing
            drNew = Nothing
            drTemp = Nothing
            drTempArr = Nothing

            'If Not IsNothing(ds) Then
            '    ds.Clear()
            '    ds.Tables.Clear()
            '    ds = Nothing
            'End If

            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If

            If Not IsNothing(dtInitial) Then
                dtInitial.Dispose()
                dtInitial = Nothing
            End If

            If Not IsNothing(dtTemp) Then
                dtTemp.Dispose()
                dtTemp = Nothing
            End If
        End Try
    End Function


    '*********************************************************************************
    Public Function GetFulfillmentReportData(ByVal bUseParams As Boolean()) As DataSet
        Dim strSQL, strProdIDs As String
        Dim strDateClause As String = ""
        Dim strDateRange As String = ""
        Dim dt, dtProds As DataTable
        Dim ds As DataSet
        Dim R1, drArr() As DataRow
        Dim i As Integer

        Try
            ds = New DataSet("Report Data")

            If bUseParams(0) Then
                If (Me._bUseStartDate And IsNothing(Me._datStart)) Or (Me._bUseEndDate And IsNothing(Me._datEnd)) Then
                    Me._objDataProc.DisplayMessage("The date range hasn't been set properly.", 3, False)

                    Exit Function
                End If
            End If

            '************************************
            strProdIDs = ""
            For i = 0 To Me._iProductIDs.Length - 1
                If Me._iProductIDs(i) > 0 Then
                    If strProdIDs.Length > 0 Then strProdIDs &= ", "

                    strProdIDs &= Me._iProductIDs(i).ToString
                End If
            Next i
            dtProds = Me.GetProducts(strProdIDs)
            '************************************

            Select Case Me._rc
                Case Report_Call.ADMIN_REVENUE_SUMMARY
                    strDateClause = Me.SetupDateStrings("C.ShipDateTime", strDateRange, 2)
                    'Sale order
                    strSQL = "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", lproduct_Prod_ID, '' as Product, 0 as LineNo, ServiceTypesID as ServiceTypeID  , Description as ServiceTypeDesc " & Environment.NewLine
                    strSQL &= ", CompanyName, count(*) as Quantity, D.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", Sum(LaborCharge) as TotalLabor" & Environment.NewLine
                    strSQL &= ",sum(SupplyCharge) as TotalSupply, SUM(if(A.CompanyID = 1, C.ShipmentCost, 0 )) as 'TotalShipmentCost'" & Environment.NewLine
                    strSQL &= "FROM company A" & Environment.NewLine
                    strSQL &= "INNER JOIN soheader B On A.Companyid = B.Companyid" & Environment.NewLine
                    strSQL &= "INNER JOIN packingslipsheader C ON B.SOheaderid = C.SOHeaderID" & Environment.NewLine
                    strSQL &= "INNER JOIN servicetypes D ON ServiceTypesID = 2 " & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " )" & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine
                    strSQL &= "GROUP BY CompanyName, ServiceTypeID" & Environment.NewLine

                    'Return Order : Only apply to Intelliguard
                    strDateClause = Me.SetupDateStrings("B.ReceiveDateTime", strDateRange, 2)
                    strSQL &= "UNION" & Environment.NewLine
                    strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", lproduct_Prod_ID, '' as Product, 0 as LineNo, ServiceTypesID as ServiceTypeID  , Description as ServiceTypeDesc " & Environment.NewLine
                    strSQL &= ", CompanyName, count(*) as Quantity, C.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", Sum(LaborCost) as 'TotalLabor', 0 as 'TotalSupply', 0 as 'TotalShipmentCost'" & Environment.NewLine
                    strSQL &= "FROM company A" & Environment.NewLine
                    strSQL &= "INNER JOIN returnitemheader B ON A.companyid = B.companyid" & Environment.NewLine
                    strSQL &= "INNER JOIN servicetypes C ON ServiceTypesID = 3" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " ) AND A.CompanyID = 2" & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine
                    strSQL &= "GROUP BY CompanyName, ServiceTypeID" & Environment.NewLine

                    'New Receive (Inventory) : Only apply to Intelliguard
                    strDateClause = Me.SetupDateStrings("C.LoadDate", strDateRange, 2)
                    strSQL &= "UNION" & Environment.NewLine
                    strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", lproduct_Prod_ID, '' as Product, 0 as LineNo, D.ServiceTypesID as ServiceTypeID  , Description as ServiceTypeDesc " & Environment.NewLine
                    strSQL &= ", CompanyName, sum(if(Quantity < 0 , -1, if(Quantity > 0, 1, 0) ) ) as Quantity, D.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", sum(LaborCost) as LaborCharge, 0 as 'Supply', 0 as 'TotalShipmentCost'" & Environment.NewLine
                    strSQL &= "FROM company A " & Environment.NewLine
                    strSQL &= "INNER JOIN poreceiptheader B ON A.companyid = B.companyid" & Environment.NewLine
                    strSQL &= "INNER JOIN poreceiptdetails C ON B.POReceiptheaderID= C.POReceiptheaderID" & Environment.NewLine
                    strSQL &= "INNER JOIN servicetypes D ON ServiceTypesID = 1" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " ) AND A.CompanyID = 2 " & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine
                    strSQL &= "GROUP BY CompanyName, ServiceTypeID " & Environment.NewLine

                    'Other service type (ex: physical inventory, facility charge...)
                    strDateClause = Me.SetupDateStrings("B.InputDate", strDateRange, 2)
                    strSQL &= "UNION" & Environment.NewLine
                    strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", lproduct_Prod_ID, '' as Product, 0 as LineNo, C.ServiceTypesID as ServiceTypeID  , Description as ServiceTypeDesc " & Environment.NewLine
                    strSQL &= ", CompanyName, Sum(B.Quantity) as 'Quantity', C.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", Sum(B.TotalCost) as 'LaborCharge' , 0 as 'TotalSupply', 0 as 'TotalShipmentCost'" & Environment.NewLine
                    strSQL &= "FROM Company A" & Environment.NewLine
                    strSQL &= "INNER JOIN salesorders.servicetransactions B ON A.CompanyID = B.CompanyID" & Environment.NewLine
                    strSQL &= "INNER JOIN salesorders.servicetypes C ON B.ServiceTypesID = C.ServiceTypesID" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " )" & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine
                    strSQL &= "GROUP BY CompanyName, ServiceTypeID " & Environment.NewLine
                    dt = Connection5.GetDataTable(strSQL)
                    dt.TableName = "Admin Revenue Fulfillment"

                    For Each R1 In dtProds.Rows
                        drArr = dt.Select("lproduct_Prod_ID = " & R1("Prod_ID"))
                        For i = 0 To drArr.Length - 1
                            drArr(i).BeginEdit() : drArr(i)("Product") = R1("Prod_Desc") : drArr(i).EndEdit()
                        Next i
                    Next R1

                    dt.Columns.Remove("lproduct_Prod_ID") : dt.AcceptChanges()
                    If dt.Rows.Count > 0 Then ds.Tables.Add(dt)

                Case Report_Call.ADMIN_REVENUE_DETAIL
                    strDateClause = Me.SetupDateStrings("C.ShipDateTime", strDateRange, 2)
                    'Sale order
                    strSQL = "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", A.lproduct_Prod_ID, '' as Product" & Environment.NewLine
                    strSQL &= ", A.CompanyName, F.ServiceTypesID as ServiceTypeID, F.Description as ServiceTypeDesc" & Environment.NewLine
                    strSQL &= ", B.CustomerOrderNumber as 'CustomerOrderNo', C.PackingSlipsHeaderID as PackingNo" & Environment.NewLine
                    strSQL &= ", E.LineItemNumber as 'LineNo', E.SKU, convert( D.ShipQuantity, SIGNED INTEGER) as Quantity, F.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", IF(A.CompanyID = 1, D.ItemLaborCost, IF(E.LineItemNumber = 1, C.LaborCharge, 0 ) ) as TotalLabor" & Environment.NewLine
                    strSQL &= ", IF(E.LineItemNumber = 1, C.SupplyCharge, 0) as TotalSupply" & Environment.NewLine
                    strSQL &= ", IF(E.LineItemNumber = 1, C.ShipmentCost, 0)	as TotalShipmentCost" & Environment.NewLine
                    strSQL &= "FROM company A" & Environment.NewLine
                    strSQL &= "INNER JOIN soheader B On A.Companyid = B.Companyid" & Environment.NewLine
                    strSQL &= "INNER JOIN packingslipsheader C ON B.SOheaderid = C.SOHeaderID" & Environment.NewLine
                    strSQL &= "INNER JOIN packingslipsdetails D ON C.packingslipsheaderid = D.packingslipsheaderid" & Environment.NewLine
                    strSQL &= "INNER JOIN sodetails E ON D.SODetailsid = E.SODetailsID" & Environment.NewLine
                    strSQL &= "INNER JOIN servicetypes F ON F.ServiceTypesID = 2" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " )" & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine

                    'Return Order : Only apply to Intelliguard
                    strDateClause = Me.SetupDateStrings("B.ReceiveDateTime", strDateRange, 2)
                    strSQL &= "UNION" & Environment.NewLine
                    strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", A.lproduct_Prod_ID, '' as Product" & Environment.NewLine
                    strSQL &= ", A.CompanyName, C.ServiceTypesID as ServiceTypeID, C.Description as ServiceTypeDesc" & Environment.NewLine
                    strSQL &= ", '' as 'CustomerOrderNo', '' as PackingNo" & Environment.NewLine
                    strSQL &= ", 0 as 'LineNo', '' as SKU, 1 as Quantity, C.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", B.LaborCost as TotalLabor" & Environment.NewLine
                    strSQL &= ", 0 as TotalSupply" & Environment.NewLine
                    strSQL &= ", 0	as TotalShipmentCost " & Environment.NewLine
                    strSQL &= "FROM company A" & Environment.NewLine
                    strSQL &= "INNER JOIN returnitemheader B ON A.companyid = B.companyid" & Environment.NewLine
                    strSQL &= "INNER JOIN servicetypes C ON ServiceTypesID = 3" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " ) AND A.CompanyID = 2 " & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine

                    'New Receive (Inventory) : Only apply to Intelliguard
                    strDateClause = Me.SetupDateStrings("C.LoadDate", strDateRange, 2)
                    strSQL &= "UNION" & Environment.NewLine
                    strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", A.lproduct_Prod_ID, '' as Product" & Environment.NewLine
                    strSQL &= ", A.CompanyName, D.ServiceTypesID as ServiceTypeID, D.Description as ServiceTypeDesc" & Environment.NewLine
                    strSQL &= ", B.PONumber as 'CustomerOrderNo', '' as PackingNo" & Environment.NewLine
                    strSQL &= ", C.LineItemNumber as 'LineNo', E.NavItemID as SKU" & Environment.NewLine
                    strSQL &= ", IF (C.Quantity > 0, 1, -1) as Quantity, D.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", C.LaborCost as TotalLabor" & Environment.NewLine
                    strSQL &= ", 0 as TotalSupply" & Environment.NewLine
                    strSQL &= ", 0	as TotalShipmentCost " & Environment.NewLine
                    strSQL &= "FROM company A" & Environment.NewLine
                    strSQL &= "INNER JOIN poreceiptheader B ON A.companyid = B.companyid" & Environment.NewLine
                    strSQL &= "INNER JOIN poreceiptdetails C ON B.POReceiptheaderID= C.POReceiptheaderID" & Environment.NewLine
                    strSQL &= "INNER JOIN servicetypes D ON ServiceTypesID = 1" & Environment.NewLine
                    strSQL &= "INNER JOIN items E ON C.ItemsID = E.ItemsID" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " ) AND A.CompanyID = 2 AND C.Quantity <> 0 " & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine

                    'Other service type (ex: physical inventory, facility charge...)
                    strDateClause = Me.SetupDateStrings("B.InputDate", strDateRange, 2)
                    strSQL &= "UNION" & Environment.NewLine
                    strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
                    strSQL &= ", A.lproduct_Prod_ID, '' as Product" & Environment.NewLine
                    strSQL &= ", A.CompanyName, C.ServiceTypesID as ServiceTypeID, C.Description as ServiceTypeDesc" & Environment.NewLine
                    strSQL &= ", '' as 'CustomerOrderNo', '' as PackingNo" & Environment.NewLine
                    strSQL &= ", 0 as 'LineNo', '' as SKU" & Environment.NewLine
                    strSQL &= ", B.Quantity as Quantity, C.UnitOfMeasure as Measurement" & Environment.NewLine
                    strSQL &= ", B.TotalCost as TotalLabor" & Environment.NewLine
                    strSQL &= ", 0 as TotalSupply" & Environment.NewLine
                    strSQL &= ", 0	as TotalShipmentCost " & Environment.NewLine
                    strSQL &= "FROM Company A" & Environment.NewLine
                    strSQL &= "INNER JOIN salesorders.servicetransactions B ON A.CompanyID = B.CompanyID" & Environment.NewLine
                    strSQL &= "INNER JOIN salesorders.servicetypes C ON B.ServiceTypesID = C.ServiceTypesID" & Environment.NewLine
                    strSQL &= "WHERE lproduct_Prod_ID IN ( " & strProdIDs & " ) " & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine
                    dt = Connection5.GetDataTable(strSQL)
                    dt.TableName = "Admin Revenue Detail Fulfillment"

                    For Each R1 In dtProds.Rows
                        drArr = dt.Select("lproduct_Prod_ID = " & R1("Prod_ID"))
                        For i = 0 To drArr.Length - 1
                            drArr(i).BeginEdit() : drArr(i)("Product") = R1("Prod_Desc") : drArr(i).EndEdit()
                        Next i
                    Next R1

                    dt.Columns.Remove("lproduct_Prod_ID") : dt.AcceptChanges()
                    If dt.Rows.Count > 0 Then ds.Tables.Add(dt)
            End Select

            Return ds
        Catch ex As Exception
            Me._objDataProc.DisplayMessage(ex.Message)
        Finally
            If Not IsNothing(ds) Then
                ds.Dispose()
                ds = Nothing
            End If
            Buisness.Generic.DisposeDT(dt)
            Buisness.Generic.DisposeDT(dtProds)
            drArr = Nothing : R1 = Nothing
        End Try
    End Function

    '*********************************************************************************
    Public Function GetWarehouseRevenueReportData(ByVal bUseParams As Boolean()) As DataSet
        Dim strSQL, strProdIDs, strTableName As String
        Dim strDateClause As String = ""
        Dim strDateRange As String = ""
        Dim dt, dtProds As DataTable
        Dim ds As DataSet
        Dim i As Integer

        Try
            ds = New DataSet("Report Data")

            If bUseParams(0) Then
                If (Me._bUseStartDate And IsNothing(Me._datStart)) Or (Me._bUseEndDate And IsNothing(Me._datEnd)) Then
                    Me._objDataProc.DisplayMessage("The date range hasn't been set properly.", 3, False)

                    Exit Function
                End If
            End If

            '************************************
            strProdIDs = ""
            For i = 0 To Me._iProductIDs.Length - 1
                If Me._iProductIDs(i) > 0 Then
                    If strProdIDs.Length > 0 Then strProdIDs &= ", "

                    strProdIDs &= Me._iProductIDs(i).ToString
                End If
            Next i
            dtProds = Me.GetProducts(strProdIDs)
            '************************************
            strDateClause = Me.SetupDateStrings("A.Date_Received", strDateRange, 2)
            '************************************
            strSQL = "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
            strSQL &= ",E.PCo_Name AS CompanyName,H.Dcode_LDesc as Management" & Environment.NewLine
            strSQL &= ",G.Prod_Desc AS ProdDesc,F.Model_Desc as Model" & Environment.NewLine
            strSQL &= ",A.Serial,A.Labor_Charge as LaborCharge, A.Date_Received as DateReceive, 1 as Qty" & Environment.NewLine
            strSQL &= ", 'Device' as 'UnitOfMeasure' " & Environment.NewLine
            strSQL &= "FROM warehouse.warehouse_items A" & Environment.NewLine
            strSQL &= "INNER JOIN warehouse.warehouse_receipt B on B.WR_ID=A.WR_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.tlocation C ON C.Loc_ID = B.Loc_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.tcustomer D ON D.Cust_ID = C.Cust_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.tmodel F ON F.Model_ID = A.Model_ID" & Environment.NewLine
            strSQL &= "INNER JOIN lproduct G ON G.Prod_ID = F.Prod_ID" & Environment.NewLine
            strSQL &= "INNER JOIN lcodesdetail H on H.Dcode_id=A.Management_Type_ID" & Environment.NewLine
            strSQL &= "WHERE G.Prod_ID IN ( " & strProdIDs & " )" & Environment.NewLine
            strSQL &= "AND " & strDateClause & Environment.NewLine
            strSQL &= "UNION ALL " & Environment.NewLine
            strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
            strSQL &= ",E.PCo_Name AS CompanyName, A.WHCType_Desc as Management" & Environment.NewLine
            strSQL &= ",G.Prod_Desc AS ProdDesc, '' as Model" & Environment.NewLine
            strSQL &= ",'' as Serial, Sum(A.WHC_TotalCharge) as LaborCharge, A.WHC_Date as DateReceive, sum(A.WHC_Qty) as Qty" & Environment.NewLine
            strSQL &= ", A.WHCType_UnitMeasurement as 'UnitOfMeasure' " & Environment.NewLine
            strSQL &= "FROM warehouse.whcharge A" & Environment.NewLine
            strSQL &= "INNER JOIN production.tcustomer D ON D.Cust_ID = A.Cust_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.tcusttoprice F ON F.Cust_ID = D.Cust_ID" & Environment.NewLine
            strSQL &= "INNER JOIN lproduct G ON G.Prod_ID = F.Prod_ID" & Environment.NewLine
            strSQL &= "WHERE G.Prod_ID IN ( " & strProdIDs & " )" & Environment.NewLine
            strSQL &= "AND A.WHC_Date between '" & Me._datStart.ToString("yyyy-MM-dd") & " 00:00:00' AND '" & Me._datEnd.ToString("yyyy-MM-dd") & " 23:59:59'" & Environment.NewLine
            strSQL &= "Group By A.WHCType_Desc " & Environment.NewLine
            strSQL &= "UNION ALL " & Environment.NewLine
            strSQL &= "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
            strSQL &= ",E.PCo_Name AS CompanyName, 'Order Fulfillment' as Management" & Environment.NewLine
            strSQL &= ",G.Prod_Desc AS ProdDesc, '' as Model" & Environment.NewLine
            strSQL &= ",'' as Serial, A.LaborCharge as LaborCharge, A.ShipDate as DateReceive, 1 as Qty" & Environment.NewLine
            strSQL &= ", 'Order' as 'UnitOfMeasure' " & Environment.NewLine
            strSQL &= "FROM saleorders.SOHeader A" & Environment.NewLine
            strSQL &= "INNER JOIN production.tcustomer D ON D.Cust_ID = A.Cust_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.lparentco E ON E.PCo_ID = D.PCo_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.tcusttoprice F ON F.Cust_ID = D.Cust_ID" & Environment.NewLine
            strSQL &= "INNER JOIN lproduct G ON G.Prod_ID = F.Prod_ID" & Environment.NewLine
            strSQL &= "WHERE G.Prod_ID IN ( " & strProdIDs & " )" & Environment.NewLine
            strSQL &= "AND A.ShipDate between '" & Me._datStart.ToString("yyyy-MM-dd") & " 00:00:00' AND '" & Me._datEnd.ToString("yyyy-MM-dd") & " 23:59:59'" & Environment.NewLine
            strSQL &= "Order By ProdDesc,Management,CompanyName,Model,Serial " & Environment.NewLine

            Select Case Me._rc
                Case Report_Call.ADMIN_REVENUE_SUMMARY
                    strTableName = "Admin Revenue Summary Warehouse"
                Case Report_Call.ADMIN_REVENUE_DETAIL
                    strTableName = "Admin Revenue Detail Warehouse"
            End Select
            dt = Me._objDataProc.GetDataTable(strSQL)
            dt.TableName = strTableName
            If dt.Rows.Count > 0 Then ds.Tables.Add(dt)
            Return ds
        Catch ex As Exception
            Me._objDataProc.DisplayMessage(ex.Message)
        Finally
            If Not IsNothing(ds) Then
                ds.Dispose()
                ds = Nothing
            End If
            Buisness.Generic.DisposeDT(dt)
            Buisness.Generic.DisposeDT(dtProds)
        End Try
    End Function

    '*********************************************************************************
    Public Function GetStanleyReportData(ByVal bUseParams As Boolean()) As DataSet
        Dim strSQL As String
        Dim strDateClause As String = ""
        Dim strDateRange As String = ""
        Dim dt As DataTable
        Dim ds As DataSet

        Try
            ds = New DataSet("Report Data")

            If bUseParams(0) Then
                If (Me._bUseStartDate And IsNothing(Me._datStart)) Or (Me._bUseEndDate And IsNothing(Me._datEnd)) Then
                    Me._objDataProc.DisplayMessage("The date range hasn't been set properly.", 3, False)
                    Exit Function
                End If
            End If

            strDateClause = Me.SetupDateStrings("A.PostingDate", strDateRange, 0)
            strSQL = "SELECT '" & Me._strReportTitle & "' as ReportTitle, '" & strDateRange & "' as DateRange" & Environment.NewLine
            strSQL &= ", A.BillToName, B.DocumentNo, B.LineNo, B.Quantity, B.UnitPrice, B.PartNo, B.PartDescription" & Environment.NewLine
            strSQL &= ", C.Amount as AdministrativeFee" & Environment.NewLine
            strSQL &= "from navision.salesshipmentheader A " & Environment.NewLine
            strSQL &= "INNER JOIN navision.salesshipmentline B ON A.No = B.DocumentNo" & Environment.NewLine
            strSQL &= "INNER JOIN salesorders.servicecharges C ON C.ServiceTypesID = 11" & Environment.NewLine
            strSQL &= "WHERE " & strDateClause & Environment.NewLine

            dt = Connection5.GetDataTable(strSQL)
            dt.TableName = "Stanley Revenue"
            If dt.Rows.Count > 0 Then ds.Tables.Add(dt)

            Return ds
        Catch ex As Exception
            Me._objDataProc.DisplayMessage(ex.Message)
        Finally
            If Not IsNothing(ds) Then
                ds.Dispose()
                ds = Nothing
            End If
            Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    '*********************************************************************************
    Public Sub AddSpecialProjDevices(ByRef dt As DataTable, _
                                     ByVal strProdIDs As String, _
                                     ByVal strDateClause As String, _
                                     ByVal strDateRange As String)
        Dim strSql As String = ""
        Dim dtSP As DataTable

        Try
            strSql = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
            strSql &= "0 AS DeviceID, E.Prod_Desc AS ProdDesc, D.PCo_Name AS CompanyName, " & Environment.NewLine
            strSql &= "0 AS BillAvgCost, 1 AS BillTypeID, 0 AS BillInvoiceAmt, sp_laborprice AS DeviceLaborChg, " & Environment.NewLine
            strSql &= "0 AS DeviceReject, 0 AS DevicePSSWrty, 0 AS DeviceManufWrty, " & Environment.NewLine
            strSql &= "0 AS ASCBillPrice, A.Pallet_ShipType AS BillCodeRule, 0 AS BillCodeID, J.Group_ID AS GroupID, J.Group_Desc AS GroupDesc, 1 AS ShiftNumber, M.RptGrp_ID AS ReportGroupID, L.Model_Desc AS ReportGroupDesc " & Environment.NewLine
            ' strSql = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
            strSql &= "'Gaming Devices' AS ProdDesc, 'Gamestop' AS 'Group', 'Gamestop' AS CompanyName, B.model_desc AS ModelDesc, A.pallett_id AS PallettID, A.pallett_qty AS Quantity " & Environment.NewLine
            strSql &= ", ( A.Pallett_QTY * C.sp_laborprice) AS LaborCharge " & Environment.NewLine
            strSql &= ", A.Pallet_ShipType AS ShipType, 0 AS CostAmount, 0 AS PartsSvcCharge" & Environment.NewLine
            strSql &= "FROM production.tpallett A" & Environment.NewLine
            strSql &= "INNER JOIN production.tmodel B ON B.model_id = A.model_id" & Environment.NewLine
            strSql &= "INNER JOIN production.tcustomer C ON A.Cust_ID = C.Cust_ID " & Environment.NewLine
            strSql &= "INNER JOIN production.lparentco D ON C.PCo_ID = D.PCo_ID " & Environment.NewLine
            strSql &= "INNER JOIN production.lproduct E ON B.Prod_ID = E.Prod_ID " & Environment.NewLine
            strSql &= "INNER JOIN production.tspecialproject_laborprice F ON A.Cust_ID = F.Cust_ID AND A.Model_ID = F.Model_ID AND A.Pallet_ShipType = F.BillCode_Rule " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN production.tspecialproject_laborprice G ON A.Model_ID = G.Model_ID " & Environment.NewLine
            strSql &= "AND A.Cust_ID = G.Cust_ID AND A.Pallet_ShipType = G.BillCode_Rule " & Environment.NewLine
            strSql &= "WHERE " & strDateClause & Environment.NewLine
            strSql &= "AND tpallett.SpecialInvProject = 1 " & Environment.NewLine
            strSql &= "AND B.Prod_ID IN ("
            strSql &= strProdIDs & ") " & Environment.NewLine

            strSql &= "ORDER BY ModelDesc, PallettID, ShipType"

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtSP) Then
                dtSP.Dispose()
                dtSP = Nothing
            End If
        End Try
    End Sub

    Private Function CreateATCLEPassFailTable(ByVal strTableName As String) As DataTable
        Dim dt As DataTable

        Try
            dt = New DataTable(strTableName)

            dt.Columns.Add(New DataColumn("ReportTitle", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("DateRange", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("DeviceID", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("ModelDesc", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("PalletShipType", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("PreTestID", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("PreTestFunc", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("PreTestFlash", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("PreTestRF", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("PreTestPFCode", System.Type.GetType("System.Int32")))

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Function

    Private Sub CheckWIPCutoffDate()
        Try
            'if the WIP cutoff date is a Saturday or Sunday, move it back to the previous Friday
            If Me._dtWIPCutoffDate.DayOfWeek = DayOfWeek.Saturday Then
                Me._dtWIPCutoffDate = Me._dtWIPCutoffDate.AddDays(-1)
            ElseIf Me._dtWIPCutoffDate.DayOfWeek = DayOfWeek.Sunday Then
                Me._dtWIPCutoffDate = Me._dtWIPCutoffDate.AddDays(-2)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetSubReportNames() As String()
        Return Me._strSubRptNames
    End Function

    'Public Sub SetUseParams(ByVal bSetUseParams As Boolean())
    '    Dim i As Integer

    '    Try
    '        For i = 0 To bSetUseParams.Length - 1
    '            Me._bUseParams(i) = bSetUseParams(i)
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Public Sub SetUseParams(ByVal bSetUseParam As Boolean, ByVal iIndex As Integer)
    '    Dim i As Integer

    '    Try
    '        If iIndex >= 0 And iIndex <= Me._bUseParams.Length - 1 Then Me._bUseParams(iIndex) = bSetUseParam
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Function GetCustomers(ByVal bGetMainCustomers As Boolean) As DataTable
        Dim strSQL As String

        Try
            strSQL = "SELECT DISTINCT A.Cust_ID, A.Cust_Name1" & Environment.NewLine
            strSQL &= "FROM production.tcustomer A" & Environment.NewLine
            strSQL &= "INNER JOIN production.lgroups B ON A.Cust_ID = B.Cust_ID" & Environment.NewLine

            If bGetMainCustomers Then strSQL &= "WHERE UPPER(Cust_Name1) IN ('ATCLE - AWS', 'BRIGHTPOINT', 'GAMESTOP')" & Environment.NewLine

            strSQL &= IIf(bGetMainCustomers, "AND", "WHERE") & " B.MasterGroup = 1 AND A.Cust_Inactive = 0" & Environment.NewLine

            strSQL &= "ORDER BY A.Cust_Name1"

            Return Me._objDataProc.GetDataTable(strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCellularCustomers() As DataTable
        Dim strSQL As String

        Try
            strSQL = "SELECT A.Cust_ID, A.Cust_Name1 " & Environment.NewLine
            strSQL &= "FROM tcustomer A" & Environment.NewLine
            strSQL &= "INNER JOIN tcusttoprice B ON A.cust_id = B.cust_id" & Environment.NewLine
            strSQL &= "INNER JOIN lproduct C ON B.prod_id = C.prod_id" & Environment.NewLine
            strSQL &= "WHERE C.prod_id = 2 AND A.Cust_Name2 IS NULL AND A.Cust_InvoiceDetail = 1 AND A.Pay_ID = 1" & Environment.NewLine
            strSQL &= "ORDER BY A.Cust_Name1"

            Return Me._objDataProc.GetDataTable(strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**********************************************************************
    Private Function GetProducts(ByVal strProdIDs As String) As DataTable
        Dim strSQL As String = ""

        Try
            strSQL = "SELECT Prod_ID, Prod_Desc " & Environment.NewLine
            strSQL &= "FROM lproduct " & Environment.NewLine
            strSQL &= "WHERE prod_Inactive = 0 AND Prod_ID IN ( " & strProdIDs & ")" & Environment.NewLine
            strSQL &= "ORDER BY Prod_Desc"

            Return Me._objDataProc.GetDataTable(strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**********************************************************************
    Public Function GetProducts(Optional ByVal booFulfillmentProd As Boolean = False) As DataTable
        Dim strSQL, strFulfillmentProdIDs As String
        Dim dt, dtFulfillmentProdIDs As DataTable
        Dim R1 As DataRow

        Try
            strSQL = "" : strFulfillmentProdIDs = ""

            If booFulfillmentProd Then
                strSQL = "select DISTINCT lproduct_Prod_ID from company; " & Environment.NewLine
                dtFulfillmentProdIDs = Connection5.GetDataTable(strSQL)

                For Each R1 In dtFulfillmentProdIDs.Rows
                    If strFulfillmentProdIDs.Trim.Length > 0 Then strFulfillmentProdIDs &= ", "
                    strFulfillmentProdIDs &= R1("lproduct_Prod_ID").ToString
                Next R1
                'Hung Nguyen 04/04/2011
                'Trim the last comma and space
                Dim i As Integer = strFulfillmentProdIDs.LastIndexOf(",")
                strFulfillmentProdIDs = strFulfillmentProdIDs.Substring(0, i)

                If strFulfillmentProdIDs.Trim.Length > 0 Then
                    strSQL = "SELECT Prod_ID, Prod_Desc " & Environment.NewLine
                    strSQL &= "FROM lproduct " & Environment.NewLine
                    strSQL &= "WHERE prod_Inactive = 0 " & Environment.NewLine
                    strSQL &= "AND Prod_ID IN ( " & strFulfillmentProdIDs & " ) " & Environment.NewLine
                    strSQL &= "ORDER BY Prod_Desc"
                    dt = Me._objDataProc.GetDataTable(strSQL)
                End If
            Else
                strSQL = "SELECT Prod_ID, Prod_Desc " & Environment.NewLine
                strSQL &= "FROM lproduct " & Environment.NewLine
                strSQL &= "WHERE prod_Inactive = 0 " & Environment.NewLine
                strSQL &= "ORDER BY Prod_Desc"

                dt = Me._objDataProc.GetDataTable(strSQL)
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            Buisness.Generic.DisposeDT(dt)
            Buisness.Generic.DisposeDT(dtFulfillmentProdIDs)
        End Try
    End Function

    '**********************************************************************
    ' Added by XM on 11/16/2011
    'Public Function GetProductsByDate(ByVal StartDt As String, ByVal EndDt As String) As DataTable
    Public Function GetProductsByDate() As DataTable
        Dim strSQL As String
        Dim dt As DataTable
        Dim R1 As DataRow

        Dim strDateClause As String = ""
        Dim strDateClauseTriage As String = ""
        Dim strDateClauseNTF As String = ""
        Dim strDateRange As String = ""

        Try
            '************************************
            strDateClause = Me.SetupDateStrings("t.Device_DateShip", strDateRange, 2)
            strDateClauseNTF = Me.SetupDateStrings("G.Date_Rec", strDateRange, 2)
            ' strDateClauseTriage = Me.SetupDateStrings("wb.crt_ts", strDateRange, 2)
            strDateClauseTriage = Me.SetupDateStrings("G.Date_Rec", strDateRange, 2)
            '************************************

            'strSQL = "SELECT DISTINCT l.Prod_ID, l.Prod_Desc " & Environment.NewLine
            'strSQL &= "FROM tdevice t " & Environment.NewLine
            'strSQL &= "INNER JOIN tmodel m ON m.Model_ID = t.Model_ID " & Environment.NewLine
            'strSQL &= "INNER JOIN lproduct l on l.Prod_ID = m.Prod_ID " & Environment.NewLine
            'strSQL &= "WHERE prod_Inactive = 0 " & Environment.NewLine
            'strSQL &= "AND " & strDateClause & Environment.NewLine
            'strSQL &= "ORDER BY l.Prod_Desc"

            strSQL = "SELECT Distinct l.Prod_ID, l.Prod_Desc" & Environment.NewLine
            strSQL &= " FROM tdevice A" & Environment.NewLine
            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
            strSQL &= " INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID" & Environment.NewLine
            strSQL &= " INNER JOIN lproduct l ON l.Prod_ID = l.Prod_ID" & Environment.NewLine
            strSQL &= " INNER JOIN tpallett P ON P.pallett_ID = A.Pallett_ID" & Environment.NewLine
            strSQL &= " INNER JOIN tCellOpt COP ON COP.Device_ID = A.Device_ID" & Environment.NewLine
            strSQL &= " WHERE " & strDateClauseNTF & Environment.NewLine  'G.Date_Rec BETWEEN '2017-03-02 00:00:00' AND '2017-03-03 23:59:59'" & Environment.NewLine
            strSQL &= " AND l.Prod_ID = 2 AND A.Loc_ID = 3402" & Environment.NewLine
            strSQL &= " AND P.pallet_qc_passed=1 AND COP.Workstation IN ('WH-FLOOR','INTRANSIT')" & Environment.NewLine
            strSQL &= " AND P.Disp_ID=5 AND G.billcode_ID in (507,541,4227)" & Environment.NewLine
            strSQL &= " UNION " & Environment.NewLine
            strSQL &= " SELECT Distinct l.Prod_ID, l.Prod_Desc" & Environment.NewLine
            strSQL &= " FROM tdevice A" & Environment.NewLine
            strSQL &= " INNER JOIN tdevicebill G ON G.Device_ID = A.Device_ID" & Environment.NewLine
            strSQL &= " INNER JOIN edi.titem N ON N.Device_ID = A.Device_ID" & Environment.NewLine
            strSQL &= " INNER JOIN lproduct l ON l.Prod_ID = l.Prod_ID" & Environment.NewLine
            strSQL &= " INNER JOIN warehouse.wh_box wb on N.whb_id = wb.whb_id" & Environment.NewLine
            strSQL &= " WHERE " & strDateClauseTriage & Environment.NewLine 'wb.crt_ts BETWEEN '2017-03-02 00:00:00' AND '2017-03-03 23:59:59'" & Environment.NewLine
            strSQL &= " AND l.Prod_ID = 2 AND A.Loc_ID = 3402" & Environment.NewLine
            strSQL &= " AND wb.Disp_ID in (2,3,4) AND G.billcode_ID in (507)" & Environment.NewLine
            strSQL &= " UNION " & Environment.NewLine
            strSQL &= "SELECT DISTINCT l.Prod_ID, l.Prod_Desc " & Environment.NewLine
            strSQL &= "FROM tdevice t " & Environment.NewLine
            strSQL &= "INNER JOIN tmodel m ON m.Model_ID = t.Model_ID " & Environment.NewLine
            strSQL &= "INNER JOIN lproduct l on l.Prod_ID = m.Prod_ID " & Environment.NewLine
            strSQL &= "WHERE prod_Inactive = 0 " & Environment.NewLine
            strSQL &= "AND " & strDateClause & Environment.NewLine
            strSQL &= "ORDER BY l.Prod_Desc"

            dt = Me._objDataProc.GetDataTable(strSQL)

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            'R1 = Nothing
            Buisness.Generic.DisposeDT(dt)
            'Buisness.Generic.DisposeDT(dtFulfillmentProdIDs)
        End Try
    End Function

    '**********************************************************************
    Public Function GetWarehouseProducts() As DataTable
        Dim strSQL As String
        Dim dt As DataTable

        Try
            strSQL = ""

            strSQL = "Select Distinct p.Prod_ID, p.Prod_Desc" & Environment.NewLine
            strSQL &= "FROM warehouse.warehouse_items w" & Environment.NewLine
            strSQL &= "left join tmodel m on m.model_id=w.model_id" & Environment.NewLine
            strSQL &= "left join lproduct p on p.prod_id=m.prod_id" & Environment.NewLine
            strSQL &= "WHERE p.prod_Inactive = 0" & Environment.NewLine
            strSQL &= "ORDER BY p.Prod_Desc;"
            dt = Me._objDataProc.GetDataTable(strSQL)

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            Buisness.Generic.DisposeDT(dt)
        End Try
    End Function
    '**********************************************************************

    Public Function GetLocations() As DataTable
        Dim strSQL As String

        Try
            'strSQL = "SELECT Loc_ID, Loc_Name " & Environment.NewLine
            'strSQL &= "FROM tlocation " & Environment.NewLine
            'strSQL &= "WHERE Loc_Name IS NOT NULL " & Environment.NewLine
            'strSQL &= "ORDER BY Loc_Name"
            strSQL = "SELECT DISTINCT A.Loc_ID, A.Loc_Name " & Environment.NewLine
            strSQL &= "FROM tlocation A " & Environment.NewLine
            strSQL &= "INNER JOIN tdevice B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
            strSQL &= "WHERE A.Loc_Name IS NOT NULL " & Environment.NewLine
            strSQL &= "ORDER BY A.Loc_Name"

            Return Me._objDataProc.GetDataTable(strSQL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SetupDateStrings(ByVal strDateField As String, ByRef strDateRange As String, Optional ByVal iTimeFieldIndex As Short = 0, Optional ByVal bIsMonthly As Boolean = False) As String
        Dim strRet As String = ""
        Dim strStartDate, strEndDate As String

        Try
            If bIsMonthly Then
                If Me._datStart.Day > 1 Then Me._datStart = Me._datStart.AddDays(1 - Me._datStart.Day)

                If Me._datEnd.Month = Me._datStart.Month And Me._datEnd.Year = Me._datStart.Year Then
                    If Me._datStart.Month < 12 Then
                        Me._datEnd = New DateTime(Me._datStart.Year, Me._datStart.Month + 1, 1)
                    Else
                        Me._datEnd = New DateTime(Me._datStart.Year + 1, 1, 1)
                    End If
                ElseIf Me._datEnd.Day > 1 Then ' Move to first of next month
                    Me._datEnd = Me._datEnd.AddDays((Me._datEnd.DaysInMonth(Me._datEnd.Year, Me._datEnd.Month) - Me._datEnd.Day) + 1)
                End If

                'If Me._datEnd.Day < Me._datEnd.DaysInMonth(Me._datEnd.Year, Me._datEnd.Month) Then Me._datEnd = Me._datEnd.AddDays(Me._datEnd.DaysInMonth(Me._datEnd.Year, Me._datEnd.Month) - Me._datEnd.Day)
            End If

            Select Case iTimeFieldIndex
                Case 0 ' No time
                    strStartDate = Format(Me._datStart, "yyyy-MM-dd")
                    strEndDate = Format(Me._datEnd, "yyyy-MM-dd")

                Case 1 ' Account for shift start and end times
                    strStartDate = Format(Me._datStart, "yyyy-MM-dd") & " 06:00:00"
                    strEndDate = Format(DateAdd(DateInterval.Day, 1, Me._datEnd), "yyyy-MM-dd") & " 04:30:00"

                Case 2 ' Account for start/end dates start/end times, respectively
                    strStartDate = Format(Me._datStart, "yyyy-MM-dd") & " 00:00:00"
                    strEndDate = Format(Me._datEnd, "yyyy-MM-dd") & " 23:59:59"
            End Select

            If Me._bUseStartDate And Me._bUseEndDate Then
                If bIsMonthly Then
                    strDateRange = String.Format("{0} - {1}", Format(Me._datStart, "MMM d, yyyy"), Format(Me._datEnd.AddDays(-1), "MMM d, yyyy"))
                Else
                    strDateRange = String.Format("{0} - {1}", Format(Me._datStart, "MMM d, yyyy"), Format(Me._datEnd, "MMM d, yyyy"))
                End If

                strRet = strDateField & " BETWEEN '" & strStartDate & "' AND '" & strEndDate & "'"
            ElseIf Me._bUseStartDate Then
                strDateRange = String.Format("{0} and Thereafter", Format(Me._datStart, "MMM d, yyyy"))
                strRet = strDateField & " >= '" & strStartDate & "'"
            ElseIf Me._bUseEndDate Then
                If bIsMonthly Then
                    strDateRange = String.Format("Up to {0}", Format(Me._datEnd.AddDays(-1), "MMM d, yyyy"))
                Else
                    strDateRange = String.Format("Up to {0}", Format(Me._datEnd, "MMM d, yyyy"))
                End If

                strRet = strDateField & " <= '" & strEndDate & "'"
            End If

            Return strRet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function TFTriageDateStrings(ByVal strDateField As String, ByRef strDateRange As String) As String
        Dim strRet As String = ""
        Dim strStartDate, strEndDate As String

        Try
            strStartDate = Format(Me._datStart, "yyyy-MM-dd") & " 00:00:00"
            strEndDate = Format(Me._datEnd, "yyyy-MM-dd") & " 23:59:59"

            strRet = strDateField & " BETWEEN '" & strStartDate & "' AND '" & strEndDate & "'"
            Return strRet
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackIndex As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
        Me._objDataProc.DisplayMessage(strMsg, iStackIndex, bIsErrMsg)
    End Sub

    Public Sub SetProductIDs(ByVal iProdIDs As Integer())
        Dim i As Integer

        Try
            If IsNothing(Me._iProductIDs) Then
                Me._iProductIDs = New Integer(iProdIDs.Length) {}
            Else
                ReDim Me._iProductIDs(iProdIDs.Length)
            End If

            System.Array.Copy(iProdIDs, Me._iProductIDs, iProdIDs.Length)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetLocationIDs(ByVal iLocIDs As Integer())
        Dim i As Integer

        Try
            If IsNothing(Me._iLocationIDs) Then
                Me._iLocationIDs = New Integer(iLocIDs.Length) {}
            Else
                ReDim Me._iLocationIDs(iLocIDs.Length)
            End If

            System.Array.Copy(iLocIDs, Me._iLocationIDs, iLocIDs.Length)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetCustomerIDs(ByVal iCustIDs As Integer())
        Dim i As Integer

        Try
            If IsNothing(Me._iCustomerIDs) Then
                Me._iCustomerIDs = New Integer(iCustIDs.Length) {}
            Else
                ReDim Me._iCustomerIDs(iCustIDs.Length)
            End If

            System.Array.Copy(iCustIDs, Me._iCustomerIDs, iCustIDs.Length)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetGSModels(ByVal strGSModels As String())
        Dim i As Integer

        Try
            If IsNothing(Me._strGSModels) Then
                Me._strGSModels = New String(strGSModels.Length) {}
            Else
                ReDim Me._strGSModels(strGSModels.Length)
            End If

            System.Array.Copy(strGSModels, Me._strGSModels, strGSModels.Length)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Property CustomerID()
        Get
            Return Me._iCustomerID
        End Get
        Set(ByVal Value)
            Me._iCustomerID = Value
        End Set
    End Property

    Public Property RowID()
        Get
            Return Me._iRowID
        End Get
        Set(ByVal Value)
            Me._iRowID = Value
        End Set
    End Property

    Public Property SubRowID()
        Get
            Return Me._iSubRowID
        End Get
        Set(ByVal Value)
            Me._iSubRowID = Value
        End Set
    End Property

    Public Property ColumnID()
        Get
            Return Me._iColumnID
        End Get
        Set(ByVal Value)
            Me._iColumnID = Value
        End Set
    End Property

    Public Property UseAllCustomers()
        Get
            Return Me._bUseAllCustomers
        End Get
        Set(ByVal Value)
            Me._bUseAllCustomers = Value
        End Set
    End Property

    Public Property WIPCutoffDate()
        Get
            Return Me._dtWIPCutoffDate
        End Get
        Set(ByVal Value)
            Me._dtWIPCutoffDate = Value
        End Set
    End Property

    Public Property DaysInWIP()
        Get
            Return Me._iDaysInWIP
        End Get
        Set(ByVal Value)
            Me._iDaysInWIP = Value
        End Set
    End Property

    Public Property GSLotNumberPattern()
        Get
            Return Me._strGSLotNumberPattern
        End Get
        Set(ByVal Value)
            Me._strGSLotNumberPattern = Value
        End Set
    End Property

    Public Property UseAllLocations()
        Get
            Return Me._bUseAllLocations
        End Get
        Set(ByVal Value)
            Me._bUseAllLocations = Value
        End Set
    End Property

    Public Property IncludeBrightpoint()
        Get
            Return Me._bIncludeBrightpoint
        End Get
        Set(ByVal Value)
            Me._bIncludeBrightpoint = Value
        End Set
    End Property

    Public Property TracfoneOnly()
        Get
            Return Me._bTracfoneOnly
        End Get
        Set(ByVal Value)
            Me._bTracfoneOnly = Value
        End Set
    End Property

    Public Property TFTriageOnly()
        Get
            Return Me._bTFTriageOnly
        End Get
        Set(ByVal Value)
            Me._bTFTriageOnly = Value
        End Set
    End Property

    Public Property WFMOnly()
        Get
            Return Me._bWFMOnly
        End Get
        Set(ByVal Value)
            Me._bWFMOnly = Value
        End Set
    End Property

    Public ReadOnly Property ReportCall()
        Get
            Return Me._rc
        End Get
    End Property

    Public Property StanleyOnly()
        Get
            Return Me._bStanleyOnly
        End Get
        Set(ByVal Value)
            Me._bStanleyOnly = Value
        End Set
    End Property

    Public Property PantechProductsOnly()
        Get
            Return Me._bPantechProductsOnly
        End Get
        Set(ByVal Value)
            Me._bPantechProductsOnly = Value
        End Set
    End Property

    Public Property TMIOnly()
        Get
            Return Me._bTMIOnly
        End Get
        Set(ByVal Value)
            Me._bTMIOnly = Value
        End Set
    End Property

    Public Property SkullcandyOnly()
        Get
            Return Me._bSkullcandyOnly
        End Get
        Set(ByVal Value)
            Me._bSkullcandyOnly = Value
        End Set
    End Property

    Public Property AllProducts()
        Get
            Return Me._bAllProducts
        End Get
        Set(ByVal Value)
            Me._bAllProducts = Value
        End Set
    End Property

    Public Shared Sub FormatCRDateTimeTextBoxes(ByVal objRpt As ReportDocument, _
        Optional ByVal strFontName As String = "Arial", Optional ByVal iFontSize As Integer = 8, Optional ByVal fs As System.Drawing.FontStyle = System.Drawing.FontStyle.Regular)
        Dim i As Integer
        Dim bFound As Boolean() = {False, False}
        Dim objPrintDate, objPrintTime As TextObject

        For i = 0 To objRpt.ReportDefinition.ReportObjects.Count - 1
            If objRpt.ReportDefinition.ReportObjects.Item(i).Name = "PrintDate" Then
                objPrintDate = CType(objRpt.ReportDefinition.ReportObjects.Item("PrintDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
                FormatCRTextBox(objRpt, objPrintDate, strFontName, iFontSize, fs)
                bFound(0) = True
            End If

            If objRpt.ReportDefinition.ReportObjects.Item(i).Name = "PrintTime" Then
                objPrintTime = CType(objRpt.ReportDefinition.ReportObjects.Item("PrintTime"), CrystalDecisions.CrystalReports.Engine.TextObject)
                FormatCRTextBox(objRpt, objPrintTime, strFontName, iFontSize, fs)
                bFound(1) = True
            End If

            If bFound(0) And bFound(1) Then Exit For
        Next
    End Sub

    Private Shared Sub FormatCRTextBox(ByVal objRpt As ReportDocument, ByRef objFormat As TextObject, _
        ByVal strFontName As String, ByVal iFontSize As Integer, ByVal fs As System.Drawing.FontStyle)
        Dim strFormat As String = ""

        Try
            objFormat.ApplyFont(New System.Drawing.Font(strFontName, iFontSize, fs, System.Drawing.GraphicsUnit.Point))

            If objFormat.Name.ToUpper.IndexOf("PRINTDATE") > -1 Then
                strFormat = ConfigFile.GetCRPrintDateFormat()
            ElseIf objFormat.Name.ToUpper.IndexOf("PRINTTIME") > -1 Then
                strFormat = ConfigFile.GetCRPrintTimeFormat()
            End If

            objFormat.Text = Format(Now(), strFormat)
            objFormat.ObjectFormat.HorizontalAlignment = CrystalDecisions.[Shared].Alignment.RightAlign
            objFormat.ObjectFormat.EnableCanGrow = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CreateMessagingWIPProductTable(ByVal strTableName As String) As DataTable
        Dim dt As DataTable

        Try
            dt = New DataTable(strTableName)

            dt.Columns.Add(New DataColumn("ReportTitle", GetType(System.String)))
            dt.Columns.Add(New DataColumn("Tier", GetType(System.Int32)))
            dt.Columns.Add(New DataColumn("ModelDesc", GetType(System.String)))
            dt.Columns.Add(New DataColumn("Frequency", GetType(System.String)))
            dt.Columns.Add(New DataColumn("DailyDemand", GetType(System.Int32)))
            dt.Columns.Add(New DataColumn("Received", GetType(System.Int32)))
            dt.Columns.Add(New DataColumn("Labeled", GetType(System.Int32)))
            dt.Columns.Add(New DataColumn("Shipped", GetType(System.Int32)))

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Function

    Public Property ReportTitle()
        Get
            ReportTitle = Me._strReportTitle
        End Get
        Set(ByVal Value)
            Me._strReportTitle = Value
        End Set
    End Property

    Private Sub AddTMI_URP_Charges(ByVal bUseParams As Boolean(), ByRef dt As DataTable)
        'ZF: Gave up this. The sort doesn't work well-------------------------
        'Dim tmpDT As DataTable
        'Dim row As DataRow
        'Dim tmpS As String = ""
        'Dim strDesktop As String = "DESKTOP", strLapTop As String = "LAPTOP"
        'Dim strComputerTypes As String = ""

        'For Each row In dt.Rows
        '    tmpS = row.Item("ProdDesc")
        '    If row.Item("GroupID") = 102 And tmpS.Trim.ToUpper = strDesktop Then 'GroupID=102 is TMI 
        '        strComputerTypes = "'" & strDesktop & "'"
        '        Exit For
        '    End If
        'Next
        'For Each row In dt.Rows
        '    tmpS = row.Item("ProdDesc")
        '    If row.Item("GroupID") = 102 And tmpS.Trim.ToUpper = strLapTop Then 'GroupID=102 is TMI 
        '        If strComputerTypes.Length > 0 Then
        '            strComputerTypes += ",'" & strLapTop & "'"
        '        Else
        '            strComputerTypes = "'" & strLapTop & "'"
        '        End If
        '        Exit For
        '    End If
        'Next

        'If strComputerTypes.Length > 0 Then
        '    tmpDT = GetTMI_URP_Charges(bUseParams, strComputerTypes)
        '    ' Dim iDevice_ID As Integer

        '    For Each row In tmpDT.Rows
        '        Dim dtNewRow As DataRow
        '        ' iDevice_ID += 1
        '        dtNewRow = dt.NewRow()

        '        dtNewRow.Item("ReportTitle") = row.Item("ReportTitle")
        '        dtNewRow.Item("DateRange") = row.Item("DateRange")
        '        'dtNewRow.Item("DeviceID") = iDevice_ID
        '        dtNewRow.Item("ProdDesc") = UCase(row.Item("ProdDesc"))
        '        dtNewRow.Item("CompanyName") = row.Item("CompanyName")
        '        dtNewRow.Item("BillAvgCost") = 0
        '        dtNewRow.Item("BillTypeID") = 0
        '        dtNewRow.Item("BillInvoiceAmt") = 0
        '        dtNewRow.Item("DeviceLaborChg") = row.Item("DeviceLaborChg")
        '        dtNewRow.Item("GroupID") = row.Item("GroupID")
        '        dtNewRow.Item("GroupDesc") = row.Item("GroupDesc")
        '        dtNewRow.Item("ShiftNumber") = row.Item("ShiftNumber")
        '        dtNewRow.Item("Device_Qty") = row.Item("Device_Qty")
        '        dt.Rows.Add(dtNewRow)
        '    Next
        'End If

        ''If tmpDT.Rows.Count > 0 Then
        '    'Dim v As DataView = dt.DefaultView, vDT As DataTable
        '    'v.Sort = "ProdDesc" ',GroupID,CompanyName,ShiftNumber"
        '    'vDT = v.Table
        '    'dt = vDT
        '    ' dt.Select(Nothing, "ProdDesc,GroupID,CompanyName", DataViewRowState.CurrentRows)
        '    ' dt.AcceptChanges()

        '    ' dt.DefaultView.Sort = "ProdDesc"
        '    ' dt.AcceptChanges()

        '    'Dim rowView As DataRowView, newRow As DataRow
        '    'vDT = dt.Clone 'Copy - structure and data rows, Clone - data structure and no data rows

        '    'For Each rowView In v
        '    '    newRow = rowView.Row
        '    '    vDT.Rows.Add(newRow)
        '    'Next
        '    'dt = vDT
        '    '  End If

        'tmpDT = Nothing

    End Sub

    Public Function GetTMI_URP_Charges(ByVal bUseParams As Boolean(), ByVal strComputerProdTypes As String) As DataTable

        'ZF: This is for debug
        Dim dt As DataTable = Nothing
        Dim strSQL As String
        Dim strDateClause As String = ""
        Dim strDateRange As String = ""

        Select Case Me._rc
            Case Report_Call.ADMIN_REVENUE_SUMMARY
                If bUseParams(0) Then
                    strDateClause = Me.SetupDateStrings("URP_ChargedDate", strDateRange, 0)
                    strSQL = "SELECT  '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL += "EW_ID as DeviceID,Type as ProdDesc,'TMI Solutions' as CompanyName,'' as BillAvgCost,'' as BillTypeID," & Environment.NewLine
                    strSQL += "'' as BillInvoiceAmt,URP_Charge as DeviceLaborChg,'' as DeviceReject,'' as DevicePSSWrty,'' as DeviceManufWrty,'' as ASCBillPrice," & Environment.NewLine
                    strSQL += "'' as BillCodeRule,'' as BillCodeID,102 as GroupID,'TMI' as GroupDesc, 99 as ShiftNumber,'' as FailID," & Environment.NewLine
                    strSQL += "'' as WrtyLabor,'' as WrtyPartCost,'' as WarrantyClaimable, 1 as Device_Qty,'' as Device_FinishedGoods," & Environment.NewLine
                    strSQL += "'' as Device_PartCharge,'' as Device_ManufWrtyPartCharge,'' as Device_ManufWrtyLaborCharge, 0.0 as DevicePartChg, 0 as ManufWrtyByWHRecDateRefUnit " & Environment.NewLine
                    strSQL += " FROM ExtendedWarranty " & Environment.NewLine
                    strSQL += " WHERE S_ID=8 AND Cust_ID=2519 and upper(Type) in (" & strComputerProdTypes & ")" & Environment.NewLine
                    strSQL += " AND " & strDateClause & Environment.NewLine 'URP_ChargedDate BETWEEN '2012-09-02 00:00:00' AND '2012-09-30 23:59:59'" & Environment.NewLine
                    strSQL += " ORDER BY LoadedDateTime;"

                    dt = Me._objDataProc.GetDataTable(strSQL)
                End If

            Case Else
        End Select
        Return dt
    End Function

    '**************************************************************************************
    Private Sub SeparateBatteryCover(ByRef dt As DataTable)
        Dim strSql, strDateRange As String
        Dim dbBatCovChargeInPer, dbBatCovChargeOutPer, dbBatCovCostInPer, dbBatCovCostOutPer As Double
        Dim iBatCovQtyInPer, iBatCovQtyOutPer As Integer
        Dim dtInPeriod, dtOutPeriod As DataTable

        Try
            dbBatCovChargeInPer = 0 : dbBatCovChargeOutPer = 0 : dbBatCovCostInPer = 0 : dbBatCovCostOutPer = 0
            iBatCovQtyInPer = 0 : iBatCovQtyOutPer = 0

            If _booAutoBill = False Then
                strDateRange = "'" & Me._datStart.ToString("yyyy-MM-dd") & "' AND '" & Me._datEnd.ToString("yyyy-MM-dd") & "'"
                strSql = "SELECT SUM(dbill_invoiceamt) AS 'BatteryCharge', sum(dbill_AvgCost) as 'BatteryCost'" & Environment.NewLine
                strSql &= ", count(*) as 'BatteryQty'" & Environment.NewLine
                strSql &= "FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_ID" & Environment.NewLine
                strSql &= "WHERE loc_id = " & Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine
                strSql &= "AND tdevicebill.billcode_ID in ( 154, 1869, 2510 ) " & Environment.NewLine
                strSql &= "AND date_rec between " & strDateRange & Environment.NewLine
                strSql &= "AND device_shipworkdate between " & strDateRange
                dtInPeriod = Me._objDataProc.GetDataTable(strSql)
                strSql = "SELECT SUM(dbill_invoiceamt) AS 'BatteryCharge', sum(dbill_AvgCost) as 'BatteryCost'" & Environment.NewLine
                strSql &= ", count(*) as 'BatteryQty' " & Environment.NewLine
                strSql &= "FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_ID" & Environment.NewLine
                strSql &= "WHERE loc_id =  " & Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine
                strSql &= "AND tdevicebill.billcode_ID in ( 154, 1869, 2510 ) " & Environment.NewLine
                strSql &= "AND date_rec between " & strDateRange & Environment.NewLine
                strSql &= "AND device_shipworkdate NOT between " & strDateRange
                dtOutPeriod = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 AndAlso (dtInPeriod.Rows.Count > 0 OrElse dtOutPeriod.Rows.Count > 0) Then
                    Dim drNewRow As DataRow : Dim i As Integer
                    drNewRow = dt.NewRow
                    drNewRow("ReportTitle") = Me._strReportTitle
                    dt.Rows.Add(drNewRow) : dt.AcceptChanges()
                End If

                If dtInPeriod.Rows.Count > 0 Then
                    If Not IsDBNull(dtInPeriod.Rows(0)("BatteryCharge")) Then dbBatCovChargeInPer = Convert.ToDouble(dtInPeriod.Rows(0)("BatteryCharge"))
                    If Not IsDBNull(dtInPeriod.Rows(0)("BatteryCost")) Then dbBatCovCostInPer = Convert.ToDouble(dtInPeriod.Rows(0)("BatteryCost"))
                    If Not IsDBNull(dtInPeriod.Rows(0)("BatteryQty")) Then iBatCovQtyInPer = Convert.ToInt32(dtInPeriod.Rows(0)("BatteryQty"))
                End If
                If dtOutPeriod.Rows.Count > 0 Then
                    If Not IsDBNull(dtOutPeriod.Rows(0)("BatteryCharge")) Then dbBatCovChargeOutPer = Convert.ToDouble(dtOutPeriod.Rows(0)("BatteryCharge"))
                    If Not IsDBNull(dtOutPeriod.Rows(0)("BatteryCost")) Then dbBatCovCostOutPer = Convert.ToDouble(dtOutPeriod.Rows(0)("BatteryCost"))
                    If Not IsDBNull(dtOutPeriod.Rows(0)("BatteryQty")) Then iBatCovQtyOutPer = Convert.ToInt32(dtOutPeriod.Rows(0)("BatteryQty"))
                End If
            End If

            Buisness.Generic.AddNewColumnToDataTable(dt, "BatteryChargeInPeriod", "System.Double", dbBatCovChargeInPer.ToString)
            Buisness.Generic.AddNewColumnToDataTable(dt, "BatteryCostInPeriod", "System.Double", dbBatCovCostInPer.ToString)
            Buisness.Generic.AddNewColumnToDataTable(dt, "BatteryQtyInPeriod", "System.Int32", iBatCovQtyInPer.ToString)

            Buisness.Generic.AddNewColumnToDataTable(dt, "BatteryChargeOutPeriod", "System.Double", dbBatCovChargeOutPer.ToString)
            Buisness.Generic.AddNewColumnToDataTable(dt, "BatteryCostOutPeriod", "System.Double", dbBatCovCostOutPer.ToString)
            Buisness.Generic.AddNewColumnToDataTable(dt, "BatteryQtyOutPeriod", "System.Int32", iBatCovQtyOutPer.ToString)
            dt.AcceptChanges()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '**************************************************************************************
    Private Function getSUMKitting(ByVal iDeviceId As Integer) As Decimal
        Dim dt As New DataTable()
        Dim strSql As String
        strSql = String.Empty
        strSql = " SELECT COALESCE(SUM(COALESCE(PsPrice_StndCost, 0)), 0)as total " & vbCrLf
        strSql &= "FROM tdevice_kittingbill E  "
        strSql &= "INNER JOIN production.lpsprice D ON  D.PSPrice_Id=E.PSPrice_Id " & vbCrLf
        strSql &= "WHERE device_id = " & iDeviceId

        dt = _objDataProc.GetDataTable(strSql)

        If Not IsDBNull(dt.Rows(0)("total")) Then
            Return (dt.Rows(0)("total"))
        Else
            Return 0
        End If
    End Function

    Public Function GetTestData()
        Dim strSQL As String
        Dim dt As DataTable
        Dim ds As DataSet
        Dim strTableName As String = ""
        Try
            ds = New DataSet("Report Data")
            strSQL = "select cust_ID,loc_ID,claimno from extendedwarranty limit 1000 " & Environment.NewLine
            strTableName = "Test"
            dt = Me._objDataProc.GetDataTable(strSQL)
            dt.TableName = strTableName
            ds.Tables.Add(dt)
            Return ds
        Catch ex As Exception
            Me._objDataProc.DisplayMessage(ex.Message)
        End Try
    End Function

    'Public Function GetCrystalReportData(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "")

    '    Dim strTableName As String = ""
    '    Dim dt As DataTable
    '    Dim strSql As String
    '    Dim dtSummary As DataTable
    '    Dim ds As New DataSet()
    '    Dim objExcelRpt As ExcelReports
    '    Dim Locid As String
    '    Dim strTempQuery As String
    '    Dim strCol As String
    '    Try
    '        If iReportType = 1 Then
    '            strCol = "SerialNo as SN"
    '        Else
    '            strCol = "IF(Device_sn IS NULL ,SerialNo,Device_sn)as SN , SerialNO AS 'Original IMEI'"
    '        End If

    '        strSql = "SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date',CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer'," & strCol & " ,ClaimNo AS 'RA_Number',Item_SKU AS 'Model'" & Environment.NewLine
    '        strSql &= " , IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'RA_Date',A.Account AS 'OEM_Account'" & Environment.NewLine
    '        strSql &= " ,ShipTo_Name AS 'Customer_Name',IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y/%m/%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier_Date'" & Environment.NewLine
    '        strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Date',Customer_Work_Number AS 'Cust_WO'" & Environment.NewLine
    '        strSql &= ",  IF( A.Account  ='569955' ,'Warranty Exchange', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Return_Type' " & Environment.NewLine
    '        If iReportType <> 1 Then
    '            strSql &= " ,IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y')))  AS 'Received Date',  IF( E.device_laborLevel  =0 , 'NTF', IF( E.device_laborLevel  =1  ,'Refurbished',  IF( E.device_laborLevel  = 2  ,'Repaired ',IF(E.device_laborLevel  = 4454  ,'RUR ','' ) ) ) ) as 'Return_Reason',Item_Desc as 'Cricket Claimed Handset Description'" & Environment.NewLine
    '        End If
    '        strSql &= "  ,Item_Desc" & Environment.NewLine
    '        strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%m/%d/%Y'))) AS 'To_RA_Date'" & Environment.NewLine
    '        strSql &= " ,Pass_Cos,Pass_Fun,Pass_Flash,Pass_RF,Failure_Reason,MCE_Failure_Reason,Kit_Complete" & Environment.NewLine
    '        strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%m/%d/%Y'))) AS 'POP_Date'" & Environment.NewLine
    '        strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%m/%d/%Y'))) AS 'POR_Date'" & Environment.NewLine
    '        strSql &= " , IF(Activation_Date IS NULL,'', IF(DATE_FORMAT(Activation_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Activation_Date,'%m/%d/%Y'))) AS 'Activation_Date'     ,OEM_RA,IMM_Order,IMM_Shipped_SKU" & Environment.NewLine

    '        strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
    '        strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
    '        strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
    '        strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
    '        Select Case iReportType

    '            Case 1 'RA_uploaded
    '                If iOption = 1 Then
    '                    strSql &= " WHERE SerialNo IN ( " & strImei & " ) and A.sourcefile not like '%REF%'" & Environment.NewLine
    '                Else
    '                    strSql &= " WHERE A.sourcefile not like '%REF%'  AND A.Cust_ID=" & iCust_ID & " AND LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine
    '                End If

    '            Case 2 'Received_Report
    '                strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
    '                If iOption = 1 Then
    '                    strSql &= " WHERE device_SN IN ( " & strImei & " ) AND A.sourcefile not like '%REF%' Group BY E.device_id " & Environment.NewLine
    '                Else
    '                    strSql &= " WHERE A.cust_ID=" & iCust_ID & "  AND A.sourcefile not like '%REF%'   AND E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' Group BY E.device_id" & Environment.NewLine
    '                End If
    '            Case Else
    '                Return 0
    '        End Select
    '        strTableName = "Test"
    '        dt = Me._objDataProc.GetDataTable(strSql)
    '        dt.TableName = strTableName
    '        ds.Tables.Add(dt)
    '        Return ds

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function GetCrystalReportData(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer

        Dim strTableName As String = ""
        Dim dt As DataTable
        Dim strSql As String
        Dim dtSummary As DataTable
        Dim ds As New DataSet()
        Dim objExcelRpt As ExcelReports
        Dim Locid As String
        Dim strTempQuery As String
        Dim strCol As String
        Try
            If iReportType = 1 Then
                strCol = "SerialNo as SN"
            Else
                strCol = "IF(Device_sn IS NULL ,SerialNo,Device_sn)as SN , SerialNO AS 'Original IMEI'"
            End If

            strSql = "SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date',CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer'," & strCol & " ,ClaimNo AS 'RA_Number',Item_SKU AS 'Model'" & Environment.NewLine
            strSql &= " , IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'RA_Date',A.Account AS 'OEM_Account'" & Environment.NewLine
            If iReportType = 2 Then
                strSql &= " ,ShipTo_Name AS 'Customer_Name'" & Environment.NewLine
            End If
            strSql &= " ,IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y/%m/%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier_Date'" & Environment.NewLine
            strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Date',Customer_Work_Number AS 'Cust_WO'" & Environment.NewLine
            strSql &= ",  IF( A.Account  ='569955' ,'Warranty Exchange', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Return_Type' " & Environment.NewLine
            If iReportType <> 1 Then
                strSql &= " ,IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y')))  AS 'Received Date',  IF( E.device_laborLevel  =0 , 'NTF', IF( E.device_laborLevel  =1  ,'Refurbished',  IF( E.device_laborLevel  = 2  ,'Repaired ',IF(E.device_laborLevel  = 4454  ,'RUR ','' ) ) ) ) as 'Return_Reason',Item_Desc as 'Cricket Claimed Handset Description'" & Environment.NewLine
            End If
            strSql &= "  ,Item_Desc" & Environment.NewLine
            strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%m/%d/%Y'))) AS 'To_RA_Date'" & Environment.NewLine
            strSql &= " ,Pass_Cos,Pass_Fun,Pass_Flash,Pass_RF,Failure_Reason,MCE_Failure_Reason,Kit_Complete" & Environment.NewLine
            strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%m/%d/%Y'))) AS 'POP_Date'" & Environment.NewLine
            strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%m/%d/%Y'))) AS 'POR_Date'" & Environment.NewLine
            strSql &= " , IF(Activation_Date IS NULL,'', IF(DATE_FORMAT(Activation_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Activation_Date,'%m/%d/%Y'))) AS 'Activation_Date'     ,OEM_RA,IMM_Order,IMM_Shipped_SKU" & Environment.NewLine
            strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile,in_pallet_id as 'Pallett IN'" & Environment.NewLine
            strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
            strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
            strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
            strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
            Select Case iReportType

                Case 1 'RA_uploaded
                    If iOption = 1 Then
                        strSql &= " WHERE SerialNo IN ( " & strImei & " ) and A.sourcefile not like '%REF%'" & Environment.NewLine
                    Else
                        strSql &= " WHERE A.sourcefile not like '%REF%'  AND A.Cust_ID=" & iCust_ID & " AND LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine
                    End If

                Case 2 'Received_Report
                    strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
                    If iOption = 1 Then
                        strSql &= " WHERE device_SN IN ( " & strImei & " ) AND A.sourcefile not like '%REF%' Group BY E.device_id " & Environment.NewLine
                    Else
                        strSql &= " WHERE A.cust_ID=" & iCust_ID & "  AND A.sourcefile not like '%REF%'   AND E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' Group BY E.device_id" & Environment.NewLine
                    End If
                Case Else
                    Return 0
            End Select
            dtSummary = Me._objDataProc.GetDataTable(strSql)
            dtSummary.TableName = strRptName
            ds.Tables.Add(dtSummary)
            objExcelRpt = New ExcelReports(False)
            objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "F", "J", "M", "X", "Y", "W", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AK"})
            Return dtSummary.Rows.Count

        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
End Class
