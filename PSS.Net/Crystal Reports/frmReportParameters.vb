Imports PSS.Misc


Public Class frmReportParameters
    Inherits System.Windows.Forms.Form

    Private _objCrystalReports As PSS.Data.CrystalReports
    Private _strReportTitle As String
    Private _bUseParams() As Boolean = {False, False, False, False, False, False, False, False, False, False}
    Private _objWorkbook As Excel.Workbook
    Private _xlRC As Data.ExcelReports.Excel_Report_Call


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strReportTitlePlusParam As String, ByVal rc As Data.CrystalReports.Report_Call)
        MyBase.New() ' Must be first statement

        Dim bGetMainCustomers As Boolean = True

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If strReportTitlePlusParam.IndexOf("Parameters") > -1 Then
            Me._strReportTitle = strReportTitlePlusParam.Substring(0, strReportTitlePlusParam.IndexOf("Parameters")).Trim
        Else
            Me._strReportTitle = strReportTitlePlusParam
        End If

        Me._objCrystalReports = New PSS.Data.CrystalReports(Me._strReportTitle, rc)

        Select Case rc
            Case Data.CrystalReports.Report_Call.CELL_LINE_PRODUCTION
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.CELL_PRODUCTION_SUMMARY
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.PRODUCTION_RECEIVED_QTY_BY_CUST
                Me._bUseParams(0) = True
                Me._bUseParams(1) = True

            Case Data.CrystalReports.Report_Call.RECEIVING_EMPLOYEE_COUNT
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.SHIPPING_COUNT_DAILY
                Me._bUseParams(0) = True
                Me._bUseParams(2) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.SHIPPING_COUNT_DAILY_EXTENDED_DETAIL
                Me._bUseParams(0) = True
                Me._bUseParams(2) = True
                Me._bUseParams(3) = True
                Me._bUseParams(4) = True

                Me._bUseParams(5) = True
            Case Data.CrystalReports.Report_Call.SHIPPING_EMPLOYEE_COUNT
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.RECEIVING_COUNT_DAILY
                Me._bUseParams(0) = True
                Me._bUseParams(2) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.RECEIVING_COUNT_DAILY_EXTENDED_DETAIL
                Me._bUseParams(0) = True
                Me._bUseParams(2) = True
                Me._bUseParams(3) = True
                Me._bUseParams(4) = True
                Me._bUseParams(5) = True

            Case Data.CrystalReports.Report_Call.RECEIVING_COUNT_MONTHLY_EXTENDED_DETAIL
                Me._bUseParams(0) = True
                Me._bUseParams(2) = True
                Me._bUseParams(3) = True
                Me._bUseParams(4) = True
                Me._bUseParams(5) = True

            Case Data.CrystalReports.Report_Call.AMERICAN_MESSAGING_WIP
                ' Handled directly from MainMenu since no input parameters are necessary.

            Case Data.CrystalReports.Report_Call.AMERICAN_MESSAGING_STAGED_BUT_NOT_RECEIVED
                ' Handled directly from MainMenu since no input parameters are necessary.

            Case Data.CrystalReports.Report_Call.BILL_EMPLOYEE_COUNT
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.ADMIN_BILLED_NOT_SHIPPED
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.ADMIN_CUSTOMER_LOCATIONS
                ' Handled directly from MainMenu since no input parameters are necessary.

            Case Data.CrystalReports.Report_Call.ADMIN_WIP
                bGetMainCustomers = False
                Me._bUseParams(1) = True
                Me._bUseParams(2) = True
                Me._bUseParams(4) = True
                Me._bUseParams(6) = True
                Me._bUseParams(7) = True

            Case Data.CrystalReports.Report_Call.ADMIN_WIP_DETAIL
                bGetMainCustomers = False
                Me._bUseParams(1) = True
                Me._bUseParams(4) = True
                Me._bUseParams(7) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_SUMMARY
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True
                Me._bUseParams(9) = True
                Me.rbtnWFMOnly.Visible = False

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_DETAIL
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True
                Me._bUseParams(9) = True
                Me.rbtnWFMOnly.Visible = False

            Case Data.CrystalReports.Report_Call.SHIPPING_SHIPPED_DEVICE_QTY_BY_SHIP_TYPE
                Me._bUseParams(0) = True
                Me._bUseParams(1) = True

            Case Data.CrystalReports.Report_Call.SHIPPING_GAMESTOP_DEVICES_NOT_SHIPPED
                Me._bUseParams(8) = True

            Case Data.CrystalReports.Report_Call.INVENTORY_SCRAP_QUANTITY
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_AUP_BY_CUSTOMER_AND_MODEL
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.TECHNICIAN_FAILURE_RATE
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.RECEIVING_DETAIL
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True
                Me._bUseParams(5) = True

            Case Data.CrystalReports.Report_Call.CELL_SHIPPED_PALLETS
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.SHIPPING_ATCLE_PASS_FAIL
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_DETAIL_BRIGHTPOINT_AB
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_SUMMARY_BRIGHTPOINT_AB
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.AMERICAN_MESSAGING_SHIP_DEMAND
                Me._bUseParams(0) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_AUP_DAILY_PRODUCTION
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_DAILY_PRODUCTION
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.MESSAGING_PRODUCT_WIP
                ' Handled directly from MainMenu since no input parameters are necessary.

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_SUMMARY_SPECIAL_PROJECTS
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True

            Case Data.CrystalReports.Report_Call.ADMIN_REVENUE_DETAIL_SPECIAL_PROJECTS
                Me._bUseParams(0) = True
                Me._bUseParams(4) = True
        End Select

        If Me._bUseParams(0) Then
            Me.grpDateRange.Enabled = True
            Me.chkUseStartDate.Checked = True
            Me.lblStartDate.Enabled = True
            Me.dtpStartDate.Enabled = True
            Me.chkUseEndDate.Checked = True
            Me.lblEndDate.Enabled = True
            Me.dtpEndDate.Enabled = True
        Else
            Me.grpDateRange.Enabled = False
        End If

        Me.lstCustomers.DataSource = Nothing

        If Me._bUseParams(1) Then
            LoadCustomerList(bGetMainCustomers)
            Me.grpCustomers.Enabled = True

            If bGetMainCustomers Then
                Me.chkUseAllCustomers.Enabled = False
                Me.chkUseAllCustomers.Visible = False
                Me.chkUseAllCustomers.CheckState = CheckState.Unchecked ' In order to pass only selected customer to report data query
                Me.grpCustomers.Text = "Select a Customer"
                Me.lstCustomers.Left = 16
                If Me.lstCustomers.Items.Count > 0 Then Me.lstCustomers.SelectedIndex = 0
                Me.lstCustomers.SelectionMode = SelectionMode.One
                Me.grpCustomers.Width = Me.grpRows.Width
                Me.chkUseAllCustomers.CheckState = CheckState.Unchecked
            Else
                Me.chkUseAllCustomers.Enabled = True
                Me.chkUseAllCustomers.Visible = True
                Me.grpCustomers.Text = "Select Customer(s)"
                Me.grpCustomers.Width = Me.chkUseAllCustomers.Left + Me.chkUseAllCustomers.Width + 5 + Me.lstCustomers.Width + 16
                Me.lstCustomers.Left = Me.grpCustomers.Width - (Me.lstCustomers.Width + 16)
                If Me.lstCustomers.Items.Count > 0 Then Me.lstCustomers.SelectedIndex = 0
                Me.lstCustomers.SelectionMode = SelectionMode.MultiExtended
                Me.chkUseAllCustomers.CheckState = CheckState.Checked
                chkUseAllCustomers_CheckedChanged(Me, Nothing)
            End If
        Else
            Me.grpCustomers.Enabled = False
        End If

        Me.lstRows.DataSource = Nothing

        If Me._bUseParams(2) Then
            LoadRowList(rc)
            Me.grpRows.Enabled = True
        Else
            Me.grpRows.Enabled = False
        End If

        Me.lstSubRows.DataSource = Nothing

        If Me._bUseParams(3) Then
            LoadSubRowList(rc)
            Me.grpSubRows.Enabled = True
        Else
            Me.grpSubRows.Enabled = False
        End If

        Me.lstProducts.DataSource = Nothing

        If Me._bUseParams(4) Then
            LoadProductList()
            Me.grpProducts.Enabled = True
        Else
            Me.grpProducts.Enabled = False
        End If

        Me.lstLocations.DataSource = Nothing

        If Me._bUseParams(5) Then
            LoadLocationsList()
            Me.grpLocations.Enabled = True
            Me.chkUseAllLocation.Checked = True
            Me.lstLocations.Enabled = False
            Me.lstLocations.SelectedIndex = -1
        Else
            Me.grpLocations.Enabled = False
        End If

        Me.lstColumns.DataSource = Nothing

        If Me._bUseParams(6) Then
            LoadColumnList()
            Me.grpColumns.Enabled = True
        Else
            Me.grpColumns.Enabled = False
        End If

        If Me._bUseParams(7) Then
            Me.grpWIPSpecificData.Enabled = True
            Me.nupDaysInWIP.Text = "0"
        Else
            Me.grpWIPSpecificData.Enabled = False
            Me.nupDaysInWIP.Text = "0"
        End If

        Me.lstGSModelDesc.DataSource = Nothing
        Me.txtGSLotNumber.Text = ""

        If Me._bUseParams(8) Then
            LoadGSModelDescList()
            Me.grpGSData.Enabled = True
            Me.lblGSLotNumber.Enabled = True
            Me.lblGSModelDesc.Enabled = True
            Me.txtGSLotNumber.Enabled = True
            Me.lstGSModelDesc.Enabled = True
            Me.txtGSLotNumber.Focus()
        Else
            Me.grpGSData.Enabled = False
            Me.lblGSLotNumber.Enabled = False
            Me.lblGSModelDesc.Enabled = False
            Me.txtGSLotNumber.Enabled = False
            Me.lstGSModelDesc.Enabled = False
        End If

        Me.grpIncludeBrightpoint.Enabled = False
        Me.chkIncludeBrightpoint.Checked = False

        If Me._bUseParams(9) Then
            Me.grpIncludeBrightpoint.Visible = True
        Else
            Me.grpIncludeBrightpoint.Visible = False
        End If

        ArrangeControls()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ArrangeControls()
        Dim i As Integer = -1
        Dim iIndex As Integer = -1
        Dim iTop As Integer = 10
        Dim iLeft As Integer = 10
        Dim iHeight As Integer
        Dim en As IEnumerator
        Dim grpParams() As System.Windows.Forms.GroupBox = {Me.grpDateRange, Me.grpCustomers, Me.grpRows, _
            Me.grpSubRows, Me.grpProducts, Me.grpLocations, Me.grpColumns, Me.grpWIPSpecificData, Me.grpGSData, _
            Me.grpIncludeBrightpoint}
        Dim iHeightArray() As Integer = {0, 0}
        Dim j As Integer = 0
        Dim iGrpMax = 0

        Try
            en = grpParams.GetEnumerator

            While en.MoveNext
                i += 1

                If Me._bUseParams(i) Then
                    grpParams(i).Top = iTop
                    grpParams(i).Left = iLeft
                    iIndex += 1

                    If iIndex Mod 2 = 1 Then
                        j += 1
                        iHeightArray(j) = grpParams(i).Height
                        iLeft = 10
                        iTop += Math.Max(iHeightArray(0), iHeightArray(1)) + 5
                        j = 0
                    Else
                        iHeightArray(j) = grpParams(i).Height
                        iLeft += grpParams(i).Width + 5
                    End If

                    iHeight = Math.Max(iHeightArray(0), iHeightArray(1))
                    iGrpMax += 1
                    grpParams(i).Visible = True
                Else
                    grpParams(i).Visible = False
                End If
            End While

            If iGrpMax < 3 Then
                iTop += iHeight + 5
                Me.btnRunReport.Left = Me.Left + (Me.Width - Me.btnRunReport.Width) / 2
                Me.btnRunReport.Top = iTop
            Else
                'Hung Nguyen 11/04/2011 Let the run Button resides at Top-Right corner
                'for smaller monitor to see in case too many group show up.
                Me.btnRunReport.Top = Me.Top + 10
                Me.btnRunReport.Left = Me.Left + (Me.Width - (Me.btnRunReport.Width + 20))
            End If

        Catch ex As Exception
            Me._objCrystalReports.DisplayMessage(ex.Message)
        End Try
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grpDateRange As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents grpCustomers As System.Windows.Forms.GroupBox
    Friend WithEvents lstCustomers As System.Windows.Forms.ListBox
    Friend WithEvents grpRows As System.Windows.Forms.GroupBox
    Friend WithEvents lstRows As System.Windows.Forms.ListBox
    Friend WithEvents grpProducts As System.Windows.Forms.GroupBox
    Friend WithEvents lstProducts As System.Windows.Forms.ListBox
    Friend WithEvents grpSubRows As System.Windows.Forms.GroupBox
    Friend WithEvents lstSubRows As System.Windows.Forms.ListBox
    Friend WithEvents grpLocations As System.Windows.Forms.GroupBox
    Friend WithEvents lstLocations As System.Windows.Forms.ListBox
    Friend WithEvents chkUseAllLocation As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseStartDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseEndDate As System.Windows.Forms.CheckBox
    Friend WithEvents grpColumns As System.Windows.Forms.GroupBox
    Friend WithEvents lstColumns As System.Windows.Forms.ListBox
    Friend WithEvents grpWIPSpecificData As System.Windows.Forms.GroupBox
    Friend WithEvents dtpWIPCutoffDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblWIPCutoffDate As System.Windows.Forms.Label
    Friend WithEvents lblDaysInWIP As System.Windows.Forms.Label
    Friend WithEvents nupDaysInWIP As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkUseAllCustomers As System.Windows.Forms.CheckBox
    Friend WithEvents grpGSData As System.Windows.Forms.GroupBox
    Friend WithEvents lstGSModelDesc As System.Windows.Forms.ListBox
    Friend WithEvents lblGSLotNumber As System.Windows.Forms.Label
    Friend WithEvents lblGSModelDesc As System.Windows.Forms.Label
    Friend WithEvents txtGSLotNumber As System.Windows.Forms.TextBox
    Friend WithEvents grpIncludeBrightpoint As System.Windows.Forms.GroupBox
    Friend WithEvents chkIncludeBrightpoint As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnFulfilment As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnProd As System.Windows.Forms.RadioButton
    Friend WithEvents grpProductionFulfillment As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTracfoneOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnStanleyOnly As System.Windows.Forms.RadioButton
    Friend WithEvents grpProductsCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnPantechProductsOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnWarehouse As System.Windows.Forms.RadioButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents rbtnTMIOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSkullcandyOnly As System.Windows.Forms.RadioButton
    Friend WithEvents chkAuToBill As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnWFMOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTFTriage As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpDateRange = New System.Windows.Forms.GroupBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.chkUseEndDate = New System.Windows.Forms.CheckBox()
        Me.chkUseStartDate = New System.Windows.Forms.CheckBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.grpCustomers = New System.Windows.Forms.GroupBox()
        Me.chkUseAllCustomers = New System.Windows.Forms.CheckBox()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.grpRows = New System.Windows.Forms.GroupBox()
        Me.lstRows = New System.Windows.Forms.ListBox()
        Me.grpProducts = New System.Windows.Forms.GroupBox()
        Me.grpProductsCustomer = New System.Windows.Forms.GroupBox()
        Me.rbtnTFTriage = New System.Windows.Forms.RadioButton()
        Me.rbtnWFMOnly = New System.Windows.Forms.RadioButton()
        Me.chkAuToBill = New System.Windows.Forms.CheckBox()
        Me.rbtnSkullcandyOnly = New System.Windows.Forms.RadioButton()
        Me.rbtnTMIOnly = New System.Windows.Forms.RadioButton()
        Me.rbtnPantechProductsOnly = New System.Windows.Forms.RadioButton()
        Me.rbtnStanleyOnly = New System.Windows.Forms.RadioButton()
        Me.rbtnTracfoneOnly = New System.Windows.Forms.RadioButton()
        Me.rbtnAll = New System.Windows.Forms.RadioButton()
        Me.grpProductionFulfillment = New System.Windows.Forms.GroupBox()
        Me.rbtnFulfilment = New System.Windows.Forms.RadioButton()
        Me.rbtnProd = New System.Windows.Forms.RadioButton()
        Me.rbtnWarehouse = New System.Windows.Forms.RadioButton()
        Me.lstProducts = New System.Windows.Forms.ListBox()
        Me.grpSubRows = New System.Windows.Forms.GroupBox()
        Me.lstSubRows = New System.Windows.Forms.ListBox()
        Me.grpLocations = New System.Windows.Forms.GroupBox()
        Me.chkUseAllLocation = New System.Windows.Forms.CheckBox()
        Me.lstLocations = New System.Windows.Forms.ListBox()
        Me.grpColumns = New System.Windows.Forms.GroupBox()
        Me.lstColumns = New System.Windows.Forms.ListBox()
        Me.grpWIPSpecificData = New System.Windows.Forms.GroupBox()
        Me.nupDaysInWIP = New System.Windows.Forms.NumericUpDown()
        Me.lblDaysInWIP = New System.Windows.Forms.Label()
        Me.lblWIPCutoffDate = New System.Windows.Forms.Label()
        Me.dtpWIPCutoffDate = New System.Windows.Forms.DateTimePicker()
        Me.grpGSData = New System.Windows.Forms.GroupBox()
        Me.txtGSLotNumber = New System.Windows.Forms.TextBox()
        Me.lblGSModelDesc = New System.Windows.Forms.Label()
        Me.lblGSLotNumber = New System.Windows.Forms.Label()
        Me.lstGSModelDesc = New System.Windows.Forms.ListBox()
        Me.grpIncludeBrightpoint = New System.Windows.Forms.GroupBox()
        Me.chkIncludeBrightpoint = New System.Windows.Forms.CheckBox()
        Me.grpDateRange.SuspendLayout()
        Me.grpCustomers.SuspendLayout()
        Me.grpRows.SuspendLayout()
        Me.grpProducts.SuspendLayout()
        Me.grpProductsCustomer.SuspendLayout()
        Me.grpProductionFulfillment.SuspendLayout()
        Me.grpSubRows.SuspendLayout()
        Me.grpLocations.SuspendLayout()
        Me.grpColumns.SuspendLayout()
        Me.grpWIPSpecificData.SuspendLayout()
        CType(Me.nupDaysInWIP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGSData.SuspendLayout()
        Me.grpIncludeBrightpoint.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDateRange
        '
        Me.grpDateRange.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.lblStartDate, Me.chkUseEndDate, Me.chkUseStartDate, Me.dtpEndDate, Me.dtpStartDate})
        Me.grpDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDateRange.Location = New System.Drawing.Point(8, 8)
        Me.grpDateRange.Name = "grpDateRange"
        Me.grpDateRange.Size = New System.Drawing.Size(304, 88)
        Me.grpDateRange.TabIndex = 0
        Me.grpDateRange.TabStop = False
        Me.grpDateRange.Text = "Date Range"
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(304, 64)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(5, 23)
        Me.lblEndDate.TabIndex = 7
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(304, 24)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(5, 23)
        Me.lblStartDate.TabIndex = 6
        '
        'chkUseEndDate
        '
        Me.chkUseEndDate.Location = New System.Drawing.Point(16, 56)
        Me.chkUseEndDate.Name = "chkUseEndDate"
        Me.chkUseEndDate.Size = New System.Drawing.Size(96, 24)
        Me.chkUseEndDate.TabIndex = 5
        Me.chkUseEndDate.Text = "Use end date"
        '
        'chkUseStartDate
        '
        Me.chkUseStartDate.Location = New System.Drawing.Point(16, 24)
        Me.chkUseStartDate.Name = "chkUseStartDate"
        Me.chkUseStartDate.Size = New System.Drawing.Size(96, 24)
        Me.chkUseStartDate.TabIndex = 4
        Me.chkUseStartDate.Text = "Use start date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "ddd, MMMM d, yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(120, 56)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpEndDate.TabIndex = 2
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "ddd, MMMM d, yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(120, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpStartDate.TabIndex = 0
        '
        'btnRunReport
        '
        Me.btnRunReport.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(736, 16)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(104, 32)
        Me.btnRunReport.TabIndex = 1
        Me.btnRunReport.Text = "Run Report"
        '
        'grpCustomers
        '
        Me.grpCustomers.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkUseAllCustomers, Me.lstCustomers})
        Me.grpCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustomers.Location = New System.Drawing.Point(392, 8)
        Me.grpCustomers.Name = "grpCustomers"
        Me.grpCustomers.Size = New System.Drawing.Size(336, 104)
        Me.grpCustomers.TabIndex = 2
        Me.grpCustomers.TabStop = False
        Me.grpCustomers.Text = "Select Customer(s)"
        '
        'chkUseAllCustomers
        '
        Me.chkUseAllCustomers.Location = New System.Drawing.Point(16, 24)
        Me.chkUseAllCustomers.Name = "chkUseAllCustomers"
        Me.chkUseAllCustomers.Size = New System.Drawing.Size(120, 24)
        Me.chkUseAllCustomers.TabIndex = 1
        Me.chkUseAllCustomers.Text = "Use all customers"
        '
        'lstCustomers
        '
        Me.lstCustomers.Location = New System.Drawing.Point(144, 24)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(184, 69)
        Me.lstCustomers.TabIndex = 0
        '
        'grpRows
        '
        Me.grpRows.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRows})
        Me.grpRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRows.Location = New System.Drawing.Point(8, 112)
        Me.grpRows.Name = "grpRows"
        Me.grpRows.Size = New System.Drawing.Size(248, 104)
        Me.grpRows.TabIndex = 3
        Me.grpRows.TabStop = False
        Me.grpRows.Text = "Select a Row"
        '
        'lstRows
        '
        Me.lstRows.Location = New System.Drawing.Point(16, 24)
        Me.lstRows.Name = "lstRows"
        Me.lstRows.Size = New System.Drawing.Size(216, 69)
        Me.lstRows.TabIndex = 0
        '
        'grpProducts
        '
        Me.grpProducts.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpProductsCustomer, Me.grpProductionFulfillment, Me.lstProducts})
        Me.grpProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpProducts.Location = New System.Drawing.Point(8, 232)
        Me.grpProducts.Name = "grpProducts"
        Me.grpProducts.Size = New System.Drawing.Size(384, 320)
        Me.grpProducts.TabIndex = 4
        Me.grpProducts.TabStop = False
        Me.grpProducts.Text = "Select Product(s)"
        '
        'grpProductsCustomer
        '
        Me.grpProductsCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnTFTriage, Me.rbtnWFMOnly, Me.chkAuToBill, Me.rbtnSkullcandyOnly, Me.rbtnTMIOnly, Me.rbtnPantechProductsOnly, Me.rbtnStanleyOnly, Me.rbtnTracfoneOnly, Me.rbtnAll})
        Me.grpProductsCustomer.Location = New System.Drawing.Point(8, 128)
        Me.grpProductsCustomer.Name = "grpProductsCustomer"
        Me.grpProductsCustomer.Size = New System.Drawing.Size(192, 184)
        Me.grpProductsCustomer.TabIndex = 17
        Me.grpProductsCustomer.TabStop = False
        Me.grpProductsCustomer.Text = "Customer"
        '
        'rbtnTFTriage
        '
        Me.rbtnTFTriage.ForeColor = System.Drawing.Color.White
        Me.rbtnTFTriage.Location = New System.Drawing.Point(16, 64)
        Me.rbtnTFTriage.Name = "rbtnTFTriage"
        Me.rbtnTFTriage.Size = New System.Drawing.Size(128, 16)
        Me.rbtnTFTriage.TabIndex = 23
        Me.rbtnTFTriage.Text = "Tracfone Triage"
        '
        'rbtnWFMOnly
        '
        Me.rbtnWFMOnly.Enabled = False
        Me.rbtnWFMOnly.ForeColor = System.Drawing.Color.White
        Me.rbtnWFMOnly.Location = New System.Drawing.Point(16, 184)
        Me.rbtnWFMOnly.Name = "rbtnWFMOnly"
        Me.rbtnWFMOnly.Size = New System.Drawing.Size(96, 16)
        Me.rbtnWFMOnly.TabIndex = 22
        Me.rbtnWFMOnly.Text = "WFM (TF)"
        '
        'chkAuToBill
        '
        Me.chkAuToBill.ForeColor = System.Drawing.Color.Red
        Me.chkAuToBill.Location = New System.Drawing.Point(144, 40)
        Me.chkAuToBill.Name = "chkAuToBill"
        Me.chkAuToBill.Size = New System.Drawing.Size(40, 24)
        Me.chkAuToBill.TabIndex = 21
        Me.chkAuToBill.Text = "SB"
        Me.chkAuToBill.Visible = False
        '
        'rbtnSkullcandyOnly
        '
        Me.rbtnSkullcandyOnly.ForeColor = System.Drawing.Color.White
        Me.rbtnSkullcandyOnly.Location = New System.Drawing.Point(16, 136)
        Me.rbtnSkullcandyOnly.Name = "rbtnSkullcandyOnly"
        Me.rbtnSkullcandyOnly.Size = New System.Drawing.Size(120, 16)
        Me.rbtnSkullcandyOnly.TabIndex = 20
        Me.rbtnSkullcandyOnly.Text = "Skullcandy Only"
        '
        'rbtnTMIOnly
        '
        Me.rbtnTMIOnly.ForeColor = System.Drawing.Color.White
        Me.rbtnTMIOnly.Location = New System.Drawing.Point(16, 112)
        Me.rbtnTMIOnly.Name = "rbtnTMIOnly"
        Me.rbtnTMIOnly.Size = New System.Drawing.Size(104, 16)
        Me.rbtnTMIOnly.TabIndex = 19
        Me.rbtnTMIOnly.Text = "TMI Only"
        '
        'rbtnPantechProductsOnly
        '
        Me.rbtnPantechProductsOnly.ForeColor = System.Drawing.Color.White
        Me.rbtnPantechProductsOnly.Location = New System.Drawing.Point(16, 160)
        Me.rbtnPantechProductsOnly.Name = "rbtnPantechProductsOnly"
        Me.rbtnPantechProductsOnly.Size = New System.Drawing.Size(104, 16)
        Me.rbtnPantechProductsOnly.TabIndex = 18
        Me.rbtnPantechProductsOnly.Text = "Pantech Only"
        Me.rbtnPantechProductsOnly.Visible = False
        '
        'rbtnStanleyOnly
        '
        Me.rbtnStanleyOnly.ForeColor = System.Drawing.Color.White
        Me.rbtnStanleyOnly.Location = New System.Drawing.Point(16, 88)
        Me.rbtnStanleyOnly.Name = "rbtnStanleyOnly"
        Me.rbtnStanleyOnly.Size = New System.Drawing.Size(104, 16)
        Me.rbtnStanleyOnly.TabIndex = 17
        Me.rbtnStanleyOnly.Text = "Stanley Only"
        '
        'rbtnTracfoneOnly
        '
        Me.rbtnTracfoneOnly.ForeColor = System.Drawing.Color.White
        Me.rbtnTracfoneOnly.Location = New System.Drawing.Point(16, 40)
        Me.rbtnTracfoneOnly.Name = "rbtnTracfoneOnly"
        Me.rbtnTracfoneOnly.Size = New System.Drawing.Size(120, 16)
        Me.rbtnTracfoneOnly.TabIndex = 16
        Me.rbtnTracfoneOnly.Text = "Tracfone Regular"
        '
        'rbtnAll
        '
        Me.rbtnAll.Checked = True
        Me.rbtnAll.ForeColor = System.Drawing.Color.White
        Me.rbtnAll.Location = New System.Drawing.Point(16, 16)
        Me.rbtnAll.Name = "rbtnAll"
        Me.rbtnAll.Size = New System.Drawing.Size(136, 16)
        Me.rbtnAll.TabIndex = 15
        Me.rbtnAll.TabStop = True
        Me.rbtnAll.Text = "All (Except Following)"
        '
        'grpProductionFulfillment
        '
        Me.grpProductionFulfillment.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnFulfilment, Me.rbtnProd, Me.rbtnWarehouse})
        Me.grpProductionFulfillment.Location = New System.Drawing.Point(8, 16)
        Me.grpProductionFulfillment.Name = "grpProductionFulfillment"
        Me.grpProductionFulfillment.Size = New System.Drawing.Size(192, 96)
        Me.grpProductionFulfillment.TabIndex = 16
        Me.grpProductionFulfillment.TabStop = False
        Me.grpProductionFulfillment.Text = "Production/Fulfillment"
        '
        'rbtnFulfilment
        '
        Me.rbtnFulfilment.ForeColor = System.Drawing.Color.White
        Me.rbtnFulfilment.Location = New System.Drawing.Point(12, 40)
        Me.rbtnFulfilment.Name = "rbtnFulfilment"
        Me.rbtnFulfilment.Size = New System.Drawing.Size(104, 16)
        Me.rbtnFulfilment.TabIndex = 15
        Me.rbtnFulfilment.Text = "Fulfillment"
        Me.rbtnFulfilment.Visible = False
        '
        'rbtnProd
        '
        Me.rbtnProd.Checked = True
        Me.rbtnProd.ForeColor = System.Drawing.Color.White
        Me.rbtnProd.Location = New System.Drawing.Point(12, 16)
        Me.rbtnProd.Name = "rbtnProd"
        Me.rbtnProd.Size = New System.Drawing.Size(104, 16)
        Me.rbtnProd.TabIndex = 14
        Me.rbtnProd.TabStop = True
        Me.rbtnProd.Text = "Production"
        '
        'rbtnWarehouse
        '
        Me.rbtnWarehouse.ForeColor = System.Drawing.Color.White
        Me.rbtnWarehouse.Location = New System.Drawing.Point(12, 64)
        Me.rbtnWarehouse.Name = "rbtnWarehouse"
        Me.rbtnWarehouse.Size = New System.Drawing.Size(104, 16)
        Me.rbtnWarehouse.TabIndex = 16
        Me.rbtnWarehouse.Text = "Warehouse"
        '
        'lstProducts
        '
        Me.lstProducts.IntegralHeight = False
        Me.lstProducts.Location = New System.Drawing.Point(208, 16)
        Me.lstProducts.Name = "lstProducts"
        Me.lstProducts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstProducts.Size = New System.Drawing.Size(160, 296)
        Me.lstProducts.TabIndex = 0
        '
        'grpSubRows
        '
        Me.grpSubRows.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstSubRows})
        Me.grpSubRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSubRows.Location = New System.Drawing.Point(408, 128)
        Me.grpSubRows.Name = "grpSubRows"
        Me.grpSubRows.Size = New System.Drawing.Size(248, 104)
        Me.grpSubRows.TabIndex = 5
        Me.grpSubRows.TabStop = False
        Me.grpSubRows.Text = "Select a Subrow"
        '
        'lstSubRows
        '
        Me.lstSubRows.Location = New System.Drawing.Point(16, 24)
        Me.lstSubRows.Name = "lstSubRows"
        Me.lstSubRows.Size = New System.Drawing.Size(216, 69)
        Me.lstSubRows.TabIndex = 0
        '
        'grpLocations
        '
        Me.grpLocations.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkUseAllLocation, Me.lstLocations})
        Me.grpLocations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLocations.Location = New System.Drawing.Point(416, 272)
        Me.grpLocations.Name = "grpLocations"
        Me.grpLocations.Size = New System.Drawing.Size(376, 104)
        Me.grpLocations.TabIndex = 6
        Me.grpLocations.TabStop = False
        Me.grpLocations.Text = "Select Location(s)"
        '
        'chkUseAllLocation
        '
        Me.chkUseAllLocation.Location = New System.Drawing.Point(16, 24)
        Me.chkUseAllLocation.Name = "chkUseAllLocation"
        Me.chkUseAllLocation.Size = New System.Drawing.Size(120, 24)
        Me.chkUseAllLocation.TabIndex = 2
        Me.chkUseAllLocation.Text = "Use all locations"
        '
        'lstLocations
        '
        Me.lstLocations.Location = New System.Drawing.Point(144, 24)
        Me.lstLocations.Name = "lstLocations"
        Me.lstLocations.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstLocations.Size = New System.Drawing.Size(216, 69)
        Me.lstLocations.TabIndex = 1
        '
        'grpColumns
        '
        Me.grpColumns.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstColumns})
        Me.grpColumns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpColumns.Location = New System.Drawing.Point(8, 560)
        Me.grpColumns.Name = "grpColumns"
        Me.grpColumns.Size = New System.Drawing.Size(248, 104)
        Me.grpColumns.TabIndex = 7
        Me.grpColumns.TabStop = False
        Me.grpColumns.Text = "Select a Column"
        '
        'lstColumns
        '
        Me.lstColumns.Location = New System.Drawing.Point(16, 24)
        Me.lstColumns.Name = "lstColumns"
        Me.lstColumns.Size = New System.Drawing.Size(216, 69)
        Me.lstColumns.TabIndex = 0
        '
        'grpWIPSpecificData
        '
        Me.grpWIPSpecificData.Controls.AddRange(New System.Windows.Forms.Control() {Me.nupDaysInWIP, Me.lblDaysInWIP, Me.lblWIPCutoffDate, Me.dtpWIPCutoffDate})
        Me.grpWIPSpecificData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpWIPSpecificData.Location = New System.Drawing.Point(416, 400)
        Me.grpWIPSpecificData.Name = "grpWIPSpecificData"
        Me.grpWIPSpecificData.Size = New System.Drawing.Size(376, 104)
        Me.grpWIPSpecificData.TabIndex = 9
        Me.grpWIPSpecificData.TabStop = False
        Me.grpWIPSpecificData.Text = "WIP-Specific Data"
        '
        'nupDaysInWIP
        '
        Me.nupDaysInWIP.Location = New System.Drawing.Point(128, 64)
        Me.nupDaysInWIP.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nupDaysInWIP.Name = "nupDaysInWIP"
        Me.nupDaysInWIP.Size = New System.Drawing.Size(64, 20)
        Me.nupDaysInWIP.TabIndex = 5
        '
        'lblDaysInWIP
        '
        Me.lblDaysInWIP.Location = New System.Drawing.Point(16, 64)
        Me.lblDaysInWIP.Name = "lblDaysInWIP"
        Me.lblDaysInWIP.Size = New System.Drawing.Size(100, 20)
        Me.lblDaysInWIP.TabIndex = 3
        Me.lblDaysInWIP.Text = "Days in WIP:"
        Me.lblDaysInWIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWIPCutoffDate
        '
        Me.lblWIPCutoffDate.Location = New System.Drawing.Point(16, 24)
        Me.lblWIPCutoffDate.Name = "lblWIPCutoffDate"
        Me.lblWIPCutoffDate.Size = New System.Drawing.Size(100, 20)
        Me.lblWIPCutoffDate.TabIndex = 2
        Me.lblWIPCutoffDate.Text = "WIP Cutoff Date:"
        Me.lblWIPCutoffDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpWIPCutoffDate
        '
        Me.dtpWIPCutoffDate.CustomFormat = "ddd, MMMM d, yyyy"
        Me.dtpWIPCutoffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWIPCutoffDate.Location = New System.Drawing.Point(128, 24)
        Me.dtpWIPCutoffDate.Name = "dtpWIPCutoffDate"
        Me.dtpWIPCutoffDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpWIPCutoffDate.TabIndex = 1
        '
        'grpGSData
        '
        Me.grpGSData.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtGSLotNumber, Me.lblGSModelDesc, Me.lblGSLotNumber, Me.lstGSModelDesc})
        Me.grpGSData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpGSData.Location = New System.Drawing.Point(8, 680)
        Me.grpGSData.Name = "grpGSData"
        Me.grpGSData.Size = New System.Drawing.Size(376, 136)
        Me.grpGSData.TabIndex = 10
        Me.grpGSData.TabStop = False
        Me.grpGSData.Text = "Select GameStop Devices Data"
        '
        'txtGSLotNumber
        '
        Me.txtGSLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGSLotNumber.Location = New System.Drawing.Point(144, 24)
        Me.txtGSLotNumber.Name = "txtGSLotNumber"
        Me.txtGSLotNumber.Size = New System.Drawing.Size(216, 20)
        Me.txtGSLotNumber.TabIndex = 3
        Me.txtGSLotNumber.Text = ""
        '
        'lblGSModelDesc
        '
        Me.lblGSModelDesc.Location = New System.Drawing.Point(16, 56)
        Me.lblGSModelDesc.Name = "lblGSModelDesc"
        Me.lblGSModelDesc.Size = New System.Drawing.Size(80, 23)
        Me.lblGSModelDesc.TabIndex = 2
        Me.lblGSModelDesc.Text = "Model(s):"
        '
        'lblGSLotNumber
        '
        Me.lblGSLotNumber.Location = New System.Drawing.Point(16, 24)
        Me.lblGSLotNumber.Name = "lblGSLotNumber"
        Me.lblGSLotNumber.Size = New System.Drawing.Size(120, 16)
        Me.lblGSLotNumber.TabIndex = 1
        Me.lblGSLotNumber.Text = "Lot Number Pattern:"
        Me.lblGSLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstGSModelDesc
        '
        Me.lstGSModelDesc.Location = New System.Drawing.Point(144, 56)
        Me.lstGSModelDesc.Name = "lstGSModelDesc"
        Me.lstGSModelDesc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstGSModelDesc.Size = New System.Drawing.Size(216, 69)
        Me.lstGSModelDesc.TabIndex = 0
        '
        'grpIncludeBrightpoint
        '
        Me.grpIncludeBrightpoint.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkIncludeBrightpoint})
        Me.grpIncludeBrightpoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpIncludeBrightpoint.Location = New System.Drawing.Point(424, 536)
        Me.grpIncludeBrightpoint.Name = "grpIncludeBrightpoint"
        Me.grpIncludeBrightpoint.Size = New System.Drawing.Size(248, 64)
        Me.grpIncludeBrightpoint.TabIndex = 11
        Me.grpIncludeBrightpoint.TabStop = False
        Me.grpIncludeBrightpoint.Text = "Brightpoint Data"
        '
        'chkIncludeBrightpoint
        '
        Me.chkIncludeBrightpoint.Location = New System.Drawing.Point(16, 24)
        Me.chkIncludeBrightpoint.Name = "chkIncludeBrightpoint"
        Me.chkIncludeBrightpoint.Size = New System.Drawing.Size(176, 24)
        Me.chkIncludeBrightpoint.TabIndex = 0
        Me.chkIncludeBrightpoint.Text = "Include Brightpoint Data"
        '
        'frmReportParameters
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(912, 753)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpIncludeBrightpoint, Me.grpGSData, Me.grpWIPSpecificData, Me.grpColumns, Me.grpLocations, Me.grpSubRows, Me.grpProducts, Me.grpRows, Me.grpCustomers, Me.grpDateRange, Me.btnRunReport})
        Me.Name = "frmReportParameters"
        Me.Text = "Report Parameters"
        Me.grpDateRange.ResumeLayout(False)
        Me.grpCustomers.ResumeLayout(False)
        Me.grpRows.ResumeLayout(False)
        Me.grpProducts.ResumeLayout(False)
        Me.grpProductsCustomer.ResumeLayout(False)
        Me.grpProductionFulfillment.ResumeLayout(False)
        Me.grpSubRows.ResumeLayout(False)
        Me.grpLocations.ResumeLayout(False)
        Me.grpColumns.ResumeLayout(False)
        Me.grpWIPSpecificData.ResumeLayout(False)
        CType(Me.nupDaysInWIP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGSData.ResumeLayout(False)
        Me.grpIncludeBrightpoint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click
        Dim strStartDate, strEndDate, strReportNAme, rptDateRange As String
        Dim ds As DataSet
        Dim dt As DataTable
        Dim win As Crownwood.Magic.Controls.TabPage
        Dim i, iProdIDs(), iLocIDs(), iCustIDs(), iIndex As Integer
        Dim strSubRptNames() As String = {"", "", ""}
        Dim strGSModelDescs() As String
        Dim xlReport As Data.ExcelReports

        Try
            If Me.grpDateRange.Enabled And (Me.dtpEndDate.Value.Date < Me.dtpStartDate.Value.Date) Then
                MsgBox("The end date cannot precede the start date.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly Or MsgBoxStyle.DefaultButton1, "Input Data Error")

                Exit Sub
            ElseIf Me.grpRows.Enabled And Me.grpSubRows.Enabled Then
                If Me.lstRows.Items(Me.lstRows.SelectedIndex)(1).ToString.ToUpper = "MODEL" And Me.lstSubRows.Items(Me.lstSubRows.SelectedIndex)(1).ToString.ToUpper = "MODEL" Then
                    MsgBox("You cannot select 'Model' for both row and subrow.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly Or MsgBoxStyle.DefaultButton1, "Input Data Error")

                    Exit Sub
                End If
            End If

            Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

            _objCrystalReports.AutoBillFlag = Me.chkAuToBill.Checked

            'Check to see if an Admin Revenue (Summary/Detail) report is being produced and, if so, check for product cellular and customer tracfone
            'If Me._strReportTitle.ToLower.IndexOf("admin revenue summary") > -1 Or Me._strReportTitle.ToLower.IndexOf("admin revenue detail") > -1 Then
            '    If Me.lstProducts.Items(Me.lstProducts.SelectedIndex)(0) = 2 And Me.lstCustomers.Items(Me.lstCustomers.SelectedIndex)(0) = 2258 Then
            '        If Me._strReportTitle.ToLower.IndexOf("tracfone") = -1 Then Me._strReportTitle &= " TracFone"
            '    Else
            '        If Me._strReportTitle.ToLower.IndexOf("tracfone") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("tracfone")).Trim
            '    End If

            '    Me._objCrystalReports.ReportTitle = Me._strReportTitle
            'End If

            If Not CheckOpenTabs(Me._strReportTitle & " Report") Then
                If Me._bUseParams(0) Then Me._objCrystalReports.SetDates(Me.chkUseStartDate.Checked, Me.dtpStartDate.Value, Me.chkUseEndDate.Checked, Me.dtpEndDate.Value)

                If Me._bUseParams(1) Then
                    If Me.chkUseAllCustomers.Checked Then
                        Me._objCrystalReports.UseAllCustomers = True
                    Else
                        Me._objCrystalReports.UseAllCustomers = False

                        iCustIDs = New Integer(Me.lstCustomers.SelectedItems.Count - 1) {}

                        iIndex = -1

                        For i = 0 To Me.lstCustomers.SelectedIndices.Count - 1
                            iIndex += 1
                            iCustIDs(iIndex) = Me.lstCustomers.Items(Me.lstCustomers.SelectedIndices(i))(0)
                        Next

                        Me._objCrystalReports.SetCustomerIDs(iCustIDs)
                    End If
                End If

                If Me._bUseParams(2) Then Me._objCrystalReports.RowID = Me.lstRows.SelectedValue
                If Me._bUseParams(3) Then Me._objCrystalReports.SubRowID = Me.lstSubRows.SelectedValue

                If Me._bUseParams(4) Then
                    Me._objCrystalReports.AllProducts = False
                    Me._objCrystalReports.TracfoneOnly = False
                    Me._objCrystalReports.StanleyOnly = False
                    Me._objCrystalReports.PantechProductsOnly = False
                    Me._objCrystalReports.TMIOnly = False
                    Me._objCrystalReports.SkullcandyOnly = False
                    Me._objCrystalReports.WFMOnly = False

                    If Me._strReportTitle.ToLower.IndexOf("tracfone") > -1 Then Me._strReportTitle = Me._strReportTitle.Replace(" TracFone", "")
                    If Me._strReportTitle.ToLower.IndexOf("stanley") > -1 Then Me._strReportTitle = Me._strReportTitle.Replace(" Stanley", "")
                    If Me._strReportTitle.ToLower.IndexOf("pantech products") > -1 Then Me._strReportTitle = Me._strReportTitle.Replace(" Pantech Products", "")
                    If Me._strReportTitle.ToLower.IndexOf("tmi") > -1 Then Me._strReportTitle = Me._strReportTitle.Replace(" TMI", "")
                    If Me._strReportTitle.ToLower.IndexOf("skullcandy") > -1 Then Me._strReportTitle = Me._strReportTitle.Replace(" Skullcandy", "")
                    If Me._strReportTitle.ToLower.IndexOf("WFM") > -1 Then Me._strReportTitle = Me._strReportTitle.Replace(" WFM", "")

                    If Me.rbtnFulfilment.Checked Then
                        Me._objCrystalReports.AllProducts = True
                        iProdIDs = New Integer(Me.lstProducts.SelectedItems.Count - 1) {}

                        iIndex = -1

                        For i = 0 To Me.lstProducts.SelectedIndices.Count - 1
                            iIndex += 1
                            iProdIDs(iIndex) = Me.lstProducts.Items(Me.lstProducts.SelectedIndices(i))(0)
                        Next

                        Me._objCrystalReports.SetProductIDs(iProdIDs)
                    ElseIf Me.rbtnTracfoneOnly.Checked Then
                        Me._objCrystalReports.TracfoneOnly = True
                        If Me._strReportTitle.ToLower.IndexOf("tracfone") = -1 Then Me._strReportTitle &= " TracFone"
                        Me._objCrystalReports.TracfoneOnly = True
                    ElseIf Me.rbtnTFTriage.Checked Then
                        If Me._strReportTitle.ToLower.IndexOf("tf triage") = -1 Then Me._strReportTitle &= " TF Triage"
                        Me._objCrystalReports.TFTriageOnly = True
                    ElseIf Me.rbtnStanleyOnly.Checked Then
                        Me._objCrystalReports.StanleyOnly = True
                        If Me._strReportTitle.ToLower.IndexOf("stanley") = -1 Then Me._strReportTitle &= " Stanley"
                    ElseIf Me.rbtnTMIOnly.Checked Then
                        Me._objCrystalReports.TMIOnly = True
                        If Me._strReportTitle.ToLower.IndexOf("tmi") = -1 Then Me._strReportTitle &= " TMI"
                    ElseIf Me.rbtnSkullcandyOnly.Checked Then
                        Me._objCrystalReports.SkullcandyOnly = True
                        If Me._strReportTitle.ToLower.IndexOf("skullcandy") = -1 Then Me._strReportTitle &= " Skullcandy"
                    ElseIf Me.rbtnPantechProductsOnly.Checked Then
                        Me._objCrystalReports.PantechProductsOnly = True
                        If Me._strReportTitle.ToLower.IndexOf("pantech products") = -1 Then Me._strReportTitle &= " Pantech Products"
                    ElseIf Me.rbtnWFMOnly.Checked Then
                        Me._objCrystalReports.WFMOnly = True
                        If Me._strReportTitle.ToLower.IndexOf("wfm") = -1 Then Me._strReportTitle &= " WFM"
                    Else
                        Me._objCrystalReports.AllProducts = True
                        iProdIDs = New Integer(Me.lstProducts.SelectedItems.Count - 1) {}

                        iIndex = -1

                        For i = 0 To Me.lstProducts.SelectedIndices.Count - 1
                            iIndex += 1
                            iProdIDs(iIndex) = Me.lstProducts.Items(Me.lstProducts.SelectedIndices(i))(0)
                        Next

                        Me._objCrystalReports.SetProductIDs(iProdIDs)
                        If Me._strReportTitle.ToLower.IndexOf("tracfone") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("tracfone")).Trim
                        If Me._strReportTitle.ToLower.IndexOf("stanley") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("stanley")).Trim
                        If Me._strReportTitle.ToLower.IndexOf("pantech products") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("pantech products")).Trim
                        If Me._strReportTitle.ToLower.IndexOf("tmi") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("tmi")).Trim
                        If Me._strReportTitle.ToLower.IndexOf("skullcandy") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("skullcandy")).Trim
                        If Me._strReportTitle.ToLower.IndexOf("wfm") > -1 Then Me._strReportTitle = Me._strReportTitle.Substring(0, Me._strReportTitle.ToLower.IndexOf("WFM")).Trim

                    End If
                End If

                If Me._bUseParams(5) Then
                    If Me.chkUseAllLocation.Checked Then
                        Me._objCrystalReports.UseAllLocations = True
                    Else
                        Me._objCrystalReports.UseAllLocations = False

                        iLocIDs = New Integer(Me.lstLocations.SelectedItems.Count - 1) {}

                        iIndex = -1

                        For i = 0 To Me.lstLocations.SelectedIndices.Count - 1
                            iIndex += 1
                            iLocIDs(iIndex) = Me.lstLocations.Items(Me.lstLocations.SelectedIndices(i))(0)
                        Next

                        Me._objCrystalReports.SetLocationIDs(iLocIDs)
                    End If
                End If

                If Me._bUseParams(6) Then Me._objCrystalReports.ColumnID = Me.lstColumns.SelectedValue

                If Me._bUseParams(7) Then
                    Me._objCrystalReports.WIPCutoffDate = Me.dtpWIPCutoffDate.Value
                    Me._objCrystalReports.DaysInWIP = Me.nupDaysInWIP.Text
                End If

                If Me._bUseParams(8) Then
                    Me._objCrystalReports.GSLotNumberPattern = Me.txtGSLotNumber.Text.Trim

                    strGSModelDescs = New String(Me.lstGSModelDesc.SelectedItems.Count - 1) {}

                    iIndex = -1

                    For i = 0 To Me.lstGSModelDesc.SelectedIndices.Count - 1
                        iIndex += 1
                        strGSModelDescs(iIndex) = Me.lstGSModelDesc.Items(Me.lstGSModelDesc.SelectedIndices(i))(0)
                    Next

                    Me._objCrystalReports.SetGSModels(strGSModelDescs)
                End If

                If Me._bUseParams(9) Then
                    If Me.chkIncludeBrightpoint.Checked Then
                        Me._objCrystalReports.IncludeBrightpoint = True
                    Else
                        Me._objCrystalReports.IncludeBrightpoint = False
                    End If
                End If

                If Me.rbtnFulfilment.Checked Then
                    strReportNAme = Me._strReportTitle & " Fulfillment Push.rpt"
                    _objCrystalReports.ReportTitle = Me._strReportTitle & " Fulfillment"
                    ds = Me._objCrystalReports.GetFulfillmentReportData(Me._bUseParams)
                    If ds.Tables.Count = 0 Then
                        MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf Me.rbtnWarehouse.Checked = True Then
                    strReportNAme = Me._strReportTitle & " Warehouse Push.rpt"
                    _objCrystalReports.ReportTitle = Me._strReportTitle & " Warehouse"
                    ds = Me._objCrystalReports.GetWarehouseRevenueReportData(Me._bUseParams)
                    If ds.Tables.Count = 0 Then
                        MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf Me.rbtnStanleyOnly.Checked = True Then
                    strReportNAme = Me._strReportTitle & " Push.rpt"
                    _objCrystalReports.ReportTitle = Me._strReportTitle
                    ds = Me._objCrystalReports.GetStanleyReportData(Me._bUseParams)
                    If ds.Tables.Count = 0 Then
                        MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf Me.rbtnAll.Checked AndAlso iProdIDs(0) = 69 Then 'NI
                    strReportNAme = Me._strReportTitle & " NI Push.rpt"
                    _objCrystalReports.ReportTitle = Me._strReportTitle
                    ds = Me._objCrystalReports.GetReportData(Me._bUseParams)
                ElseIf Me.rbtnTFTriage.Checked Then 'TracFone Triage
                    If Not Me._strReportTitle = "Admin Revenue Summary TF Triage" Then
                        strReportNAme = Me._strReportTitle
                        _objCrystalReports.ReportTitle = Me._strReportTitle
                        ds = Me._objCrystalReports.GetReportData(Me._bUseParams)
                    Else
                        MessageBox.Show("Not able to run Summary Report at this time. Please contact IT.")
                    End If
                Else
                    strReportNAme = Me._strReportTitle & " Push.rpt"
                    'strReportNAme = "Admin Revenue Summary TracFone Push 20141203.rpt"
                    _objCrystalReports.ReportTitle = Me._strReportTitle
                    ds = Me._objCrystalReports.GetReportData(Me._bUseParams)
                End If


                If (ds.Tables.Count > 0) Then
                    If (ds.Tables(0).Rows.Count > 0) Then
                        If rbtnTFTriage.Checked Then
                            dt = ds.Tables(0)

                            xlReport = New Data.ExcelReports(True)

                            Select Case Me._xlRC
                                Case Data.ExcelReports.Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES
                                    strStartDate = Me.dtpStartDate.Value.Date
                                    strEndDate = Me.dtpEndDate.Value.Date
                                    xlReport.StartDate = strStartDate
                                    xlReport.EndDate = strEndDate
                                    rptDateRange = strStartDate & " - " & strEndDate
                                    xlReport.RunTFTriageReport(Data.ExcelReports.Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES, dt, rptDateRange)
                            End Select

                        Else
                            win = New Crownwood.Magic.Controls.TabPage(Me._strReportTitle & " Report", New RptViewer(strReportNAme, ds, Me._objCrystalReports.GetSubReportNames()))

                            Gui.MainWin.MainWin.wrkArea.TabPages.Add(win)
                            win.Selected = True
                        End If
                    End If

                    'ZF Debug----------------------------------------------------------
                    'Dim dTB2 As DataTable
                    'dTB2 = Me._objCrystalReports.GetTMI_URP_Charges(Me._bUseParams, "'Desktop','Laptop'")
                    'Dim myForm As New frmDataView(Me._strReportTitle & " Report", ds.Tables("Admin Revenue Summary Data"), dTB2)
                    'myForm.Show()
                End If
            End If

            Me._objCrystalReports.IncludeBrightpoint = False
            _objCrystalReports.AutoBillFlag = False
        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Public Sub frmReportParameters_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ArrangeControls()
    End Sub

    Private Sub LoadCustomerList(ByVal bGetMainCustomers As Boolean)
        Dim dt As DataTable

        Try
            dt = Me._objCrystalReports.GetCustomers(bGetMainCustomers)

            If Not IsNothing(dt) Then
                Me.lstCustomers.DataSource = dt
                Me.lstCustomers.DisplayMember = dt.Columns(1).ColumnName
                Me.lstCustomers.ValueMember = dt.Columns(0).ColumnName

                If Me.lstCustomers.Items.Count > 0 Then Me.lstCustomers.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadRowList(ByVal rc As Data.CrystalReports.Report_Call)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim strRowTypes() As String = {"Company", "Customer", "Location", "Model", "Report Group"}
        Dim bDisplayRowCase() As Boolean = {True, True, True, True, True}

        Try
            Select Case rc
                Case Data.CrystalReports.Report_Call.SHIPPING_COUNT_DAILY_EXTENDED_DETAIL
                    bDisplayRowCase(3) = False
                    bDisplayRowCase(4) = False

                Case Data.CrystalReports.Report_Call.RECEIVING_COUNT_DAILY_EXTENDED_DETAIL
                    bDisplayRowCase(3) = False
                    bDisplayRowCase(4) = False

                Case Data.CrystalReports.Report_Call.RECEIVING_COUNT_MONTHLY_EXTENDED_DETAIL
                    bDisplayRowCase(3) = False
                    bDisplayRowCase(4) = False

                Case Data.CrystalReports.Report_Call.ADMIN_WIP
                    bDisplayRowCase(3) = False
                    bDisplayRowCase(4) = False
            End Select

            dt = CreateRowTable()

            If Not IsNothing(dt) Then
                For i = 0 To strRowTypes.Length - 1
                    If bDisplayRowCase(i) Then
                        dr = dt.NewRow

                        dr("Row Index") = i
                        dr("Row Name") = strRowTypes(i)

                        dt.Rows.Add(dr)
                    End If
                Next

                Me.lstRows.DataSource = dt
                Me.lstRows.DisplayMember = dt.Columns(1).ColumnName
                Me.lstRows.ValueMember = dt.Columns(0).ColumnName

                If Me.lstRows.Items.Count > 0 Then Me.lstRows.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr = Nothing
        End Try
    End Sub

    Private Sub LoadSubRowList(ByVal rc As Data.CrystalReports.Report_Call)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim strSubRowTypes() As String = {"Report Group", "Model", "Parts"}
        Dim bSubRowCaseArr = New Boolean() {True, True, True}

        Try
            If rc = Data.CrystalReports.Report_Call.RECEIVING_COUNT_DAILY_EXTENDED_DETAIL Or rc = Data.CrystalReports.Report_Call.RECEIVING_COUNT_MONTHLY_EXTENDED_DETAIL Then
                bSubRowCaseArr(2) = False
            End If

            dt = CreateRowTable()

            If Not IsNothing(dt) Then
                For i = 0 To strSubRowTypes.Length - 1
                    If bSubRowCaseArr(i) Then
                        dr = dt.NewRow

                        dr("Row Index") = i
                        dr("Row Name") = strSubRowTypes(i)

                        dt.Rows.Add(dr)
                    End If
                Next

                Me.lstSubRows.DataSource = dt
                Me.lstSubRows.DisplayMember = dt.Columns(1).ColumnName
                Me.lstSubRows.ValueMember = dt.Columns(0).ColumnName

                If Me.lstSubRows.Items.Count > 0 Then Me.lstSubRows.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dr = Nothing
        End Try
    End Sub

    Private Function CreateRowTable() As DataTable
        Dim dt As DataTable

        Try
            dt = New DataTable("Rows Data")

            dt.Columns.Add(New DataColumn("Row Index", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("Row Name", System.Type.GetType("System.String")))

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

    Private Sub LoadProductList()
        Dim dt As DataTable

        Try
            If IsNothing(_objCrystalReports) Then Exit Sub

            Me.lstProducts.DataSource = Nothing

            If Me.rbtnFulfilment.Checked = True Then
                dt = Me._objCrystalReports.GetProducts(True)
            ElseIf Me.rbtnWarehouse.Checked = True Then
                dt = Me._objCrystalReports.GetWarehouseProducts
                'Added by XM on 11/18/2011
            ElseIf Me._strReportTitle = "Admin Revenue Detail" Or Me._strReportTitle = "Admin Revenue Summary" Then
                Me._objCrystalReports.SetDates(Me.chkUseStartDate.Checked, Me.dtpStartDate.Value, Me.chkUseEndDate.Checked, Me.dtpEndDate.Value)
                dt = Me._objCrystalReports.GetProductsByDate
            Else
                dt = Me._objCrystalReports.GetProducts
            End If

            If Not IsNothing(dt) Then
                Me.lstProducts.DataSource = dt.DefaultView
                Me.lstProducts.DisplayMember = dt.Columns(1).ColumnName
                Me.lstProducts.ValueMember = dt.Columns(0).ColumnName

                'If Me.lstProducts.Items.Count > 0 Then
                '    If Me.lstProducts.Items(0)("Prod_ID") = 2 Then 'If the first item is "Cellular" then select the second b/c the customer group won't display in the beginning
                '        Me.lstProducts.SelectedIndex = 1
                '    Else
                '        Me.lstProducts.SelectedIndex = 0
                '    End If
                'End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    Private Sub LoadLocationsList()
        Dim dt As DataTable

        Try
            dt = Me._objCrystalReports.GetLocations

            If Not IsNothing(dt) Then
                Me.lstLocations.DataSource = dt.DefaultView
                Me.lstLocations.DisplayMember = dt.Columns(1).ColumnName
                Me.lstLocations.ValueMember = dt.Columns(0).ColumnName

                If Me.lstLocations.Items.Count > 0 Then Me.lstLocations.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    Public Sub chkUseAllLocations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseAllLocation.CheckedChanged
        If Me.chkUseAllLocation.Checked Then
            Me.lstLocations.Enabled = False
            Me.lstLocations.SelectedIndex = -1
        Else
            Me.lstLocations.Enabled = True
            Me.lstLocations.SelectedIndex = 0
        End If
    End Sub

    Public Sub chkUseStartDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseStartDate.CheckedChanged
        If Me.chkUseStartDate.Checked Then
            Me.lblStartDate.Enabled = True
            Me.dtpStartDate.Enabled = True
        Else
            Me.lblStartDate.Enabled = False
            Me.dtpStartDate.Enabled = False
        End If
    End Sub

    Public Sub chkUseEndDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseEndDate.CheckedChanged
        If Me.chkUseEndDate.Checked Then
            Me.lblEndDate.Enabled = True
            Me.dtpEndDate.Enabled = True
        Else
            Me.lblEndDate.Enabled = False
            Me.dtpEndDate.Enabled = False
        End If
    End Sub

    Private Sub LoadColumnList()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim strColumns() As String = {"Model", "Report Group"}

        Try
            dt = CreateColumnTable()

            For i = 0 To strColumns.Length - 1
                dr = dt.NewRow

                dr("Column Index") = i
                dr("Column Name") = strColumns(i)

                dt.Rows.Add(dr)
            Next

            Me.lstColumns.DataSource = dt
            Me.lstColumns.DisplayMember = dt.Columns(1).ColumnName
            Me.lstColumns.ValueMember = dt.Columns(0).ColumnName

            If Me.lstColumns.Items.Count > 0 Then Me.lstColumns.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            dr = Nothing
        End Try
    End Sub

    Private Function CreateColumnTable() As DataTable
        Dim dt As DataTable

        Try
            dt = New DataTable("Columns Data")

            dt.Columns.Add(New DataColumn("Column Index", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("Column Name", System.Type.GetType("System.String")))

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

    Private Sub LoadGSModelDescList()
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim strModelDescs() As String = {"XBox", "GameCube", "PSP"}

        Try
            dt = CreateGSModelTable()

            For i = 0 To strModelDescs.Length - 1
                dr = dt.NewRow

                'dr("Column Index") = i
                dr("GS Model Name") = strModelDescs(i)

                dt.Rows.Add(dr)
            Next

            Me.lstGSModelDesc.DataSource = dt
            Me.lstGSModelDesc.DisplayMember = dt.Columns(0).ColumnName
            Me.lstGSModelDesc.ValueMember = dt.Columns(0).ColumnName

            If Me.lstGSModelDesc.Items.Count > 0 Then Me.lstGSModelDesc.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            dr = Nothing
        End Try
    End Sub

    Private Function CreateGSModelTable() As DataTable
        Dim dt As DataTable

        Try
            dt = New DataTable("GS Model Desc Data")

            'dt.Columns.Add(New DataColumn("GS Model Index", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("GS Model Name", System.Type.GetType("System.String")))

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

    Private Sub chkUseAllCustomers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseAllCustomers.CheckedChanged
        If Me.grpCustomers.Enabled Then
            If Me.chkUseAllCustomers.Checked Then
                Me.lstCustomers.Enabled = False
            Else
                Me.lstCustomers.Enabled = True
            End If
        End If
    End Sub

    Private Sub frmReportParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.rbtnAll.Checked = True
            If Me._strReportTitle = "Admin Revenue Detail" Or Me._strReportTitle = "Admin Revenue Summary" Then

            Else
                Me.rbtnWarehouse.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstProducts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstProducts.SelectedIndexChanged
        Dim i As Integer
        Dim bAllowBPSelection As Boolean ', bCellularSelected As Boolean

        Try
            bAllowBPSelection = False
            'bCellularSelected = False

            For i = 0 To sender.SelectedItems.Count - 1
                If sender.SelectedItems(i)("Prod_Desc").ToString.ToUpper = "CELLULAR" Then
                    'bCellularSelected = True
                    If Me.grpIncludeBrightpoint.Visible Then
                        bAllowBPSelection = True

                        Exit For
                    End If
                End If
            Next i

            Me.grpIncludeBrightpoint.Enabled = bAllowBPSelection
            'If bAllowBPSelection Then
            '    Me.grpIncludeBrightpoint.Enabled = True
            'Else
            '    Me.grpIncludeBrightpoint.Enabled = False
            'End If

            'If bCellularSelected Then
            '    'Enable single customer selection
            '    GetCellularCustomers()
            '    Me.chkUseAllCustomers.Enabled = False
            '    Me.chkUseAllCustomers.Visible = False
            '    Me.chkUseAllCustomers.CheckState = CheckState.Unchecked ' In order to pass only selected customer to report data query
            '    Me.grpCustomers.Left = Me.grpIncludeBrightpoint.Left + Me.grpIncludeBrightpoint.Width + 20
            '    Me.grpCustomers.Top = Me.grpIncludeBrightpoint.Top
            '    Me.grpCustomers.Text = "Select a Customer"
            '    Me.grpCustomers.Width = Me.grpRows.Width
            '    Me.lstCustomers.Left = Me.grpCustomers.Width - (Me.lstCustomers.Width + 16)
            '    If Me.lstCustomers.Items.Count > 0 Then Me.lstCustomers.SelectedIndex = 0
            '    Me.lstCustomers.SelectionMode = SelectionMode.One
            '    Me.grpCustomers.Visible = True
            '    Me.grpCustomers.Enabled = True
            'Else
            '    Me.chkUseAllCustomers.Enabled = False
            '    Me.grpCustomers.Visible = False
            '    Me.grpCustomers.Enabled = False
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetCellularCustomers()
        Dim dt As DataTable = Nothing

        Try
            Me.lstCustomers.DataSource = Nothing

            dt = Me._objCrystalReports.GetCellularCustomers()

            If Not IsNothing(dt) Then
                Me.lstCustomers.DataSource = dt.DefaultView
                Me.lstCustomers.DisplayMember = dt.Columns(1).ColumnName
                Me.lstCustomers.ValueMember = dt.Columns(0).ColumnName
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged
        Try
            If Me.lstCustomers.SelectionMode = SelectionMode.One And Me.lstCustomers.SelectedIndex > -1 And Me.lstProducts.Visible And Me.lstProducts.SelectedIndex > -1 Then Me._objCrystalReports.CustomerID = Me.lstCustomers.SelectedItem(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub chkTracfoneOnly_chkStanley_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTracfoneOnly.CheckedChanged, chkStanley.CheckedChanged
    '    Try
    '        If Me.chkStanley.Checked = True Or Me.chkTracfoneOnly.Checked = True Then Me.lstProducts.Visible = False Else Me.lstProducts.Visible = True

    '        If sender.Name = "chkTracfoneOnly" Then
    '            If Me.chkTracfoneOnly.Checked = True Then Me.chkStanley.Checked = False
    '        ElseIf sender.Name = "chkStanley" Then
    '            If Me.chkStanley.Checked = True Then Me.chkTracfoneOnly.Checked = False
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    '*************************************************************************************
    Private Sub rbtnFulfilment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnFulfilment.CheckedChanged
        Try
            Me.grpProductsCustomer.Enabled = Not Me.rbtnFulfilment.Checked

            If Me.rbtnFulfilment.Checked = True Then
                LoadProductList()

                Me.lstProducts.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnFulfilment_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*************************************************************************************
    Private Sub rbtnProd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProd.CheckedChanged
        Try
            Me.grpProductsCustomer.Enabled = Me.rbtnProd.Checked

            If Me.rbtnProd.Checked = True Then
                LoadProductList()

                Me.lstProducts.Enabled = (Me.rbtnAll.Checked And Me.rbtnProd.Checked) Or Me.rbtnFulfilment.Checked
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnProd_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    '*************************************************************************************

    Private Sub rbtnWarehouse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnWarehouse.CheckedChanged
        Try
            Me.grpProductsCustomer.Enabled = Me.rbtnWarehouse.Checked

            If Me.rbtnWarehouse.Checked = True Then
                LoadProductList()
                Me.grpProductsCustomer.Enabled = False
                Me.rbtnAll.Checked = True
                Me.lstProducts.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnWarehouse_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*************************************************************************************

    Private Sub EnableProductsList()
        Try
            Me.lstProducts.Enabled = Me.rbtnAll.Checked

            If Not Me.rbtnAll.Checked Then Me.lstProducts.ClearSelected()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub rbtnAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnAll.CheckedChanged
        Try
            EnableProductsList()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnAll_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub rbtnTracfoneOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnTracfoneOnly.CheckedChanged
        Try
            EnableProductsList()
            If Me.rbtnTracfoneOnly.Checked = True Then
                Me.chkAuToBill.Visible = False
            Else
                Me.chkAuToBill.Visible = False
                Me.chkAuToBill.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnTracfoneOnly_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub rbtnStanleyOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnStanleyOnly.CheckedChanged
        Try
            EnableProductsList()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnStanleyOnly_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Private Sub rbtnPantechProductsOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnPantechProductsOnly.CheckedChanged
        Try
            EnableProductsList()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rbtnPantechProductsOnly_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    'Added by XM On 11/18/2011
    Private Sub dtpStartDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        Try
            If rbtnTFTriage.Checked = False Then
                Me.Cursor = Cursors.WaitCursor
                LoadProductList()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dtpStartDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    'Added by XM On 11/18/2011
    Private Sub dtpEndDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        Try
            If rbtnTFTriage.Checked = False Then
                Me.Cursor = Cursors.WaitCursor
                LoadProductList()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dtpEndDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    Public Sub New()

    End Sub

 End Class
