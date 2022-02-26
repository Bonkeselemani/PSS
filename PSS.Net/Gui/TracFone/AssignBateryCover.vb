Option Explicit On 
Imports PSS.Data.Buisness
Namespace Gui.TracFone
    Public Class AssignBateryCover
        Inherits System.Windows.Forms.Form
#Region "DECLARATIONS"
        Private iNewBatCoverBillcodeID As Integer = 154
        Private iUsedBatCoverBillcodeID As Integer = 1869
        Private iRVBatCoverBillcodeID As Integer = 2510
        Private _strScreenName As String = ""
        Private _objTFMisc As Data.Buisness.TracFone.clsMisc
        'Private _strThisWeekDateStart, _strThisWeekDateEnd As String
        Private _iPalletID As Integer = 0
#End Region
#Region "Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objTFMisc = New Data.Buisness.TracFone.clsMisc()
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
        Friend WithEvents tcMain As System.Windows.Forms.TabControl
        Friend WithEvents tpHistories As System.Windows.Forms.TabPage
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnAddBattery As System.Windows.Forms.Button
        Friend WithEvents txtShipBoxName As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnPrintAllBoxes As System.Windows.Forms.Button
        Friend WithEvents btnPrintSelectedBox As System.Windows.Forms.Button
        Friend WithEvents btnPrintPartSummary As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents dgHistData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGetData As System.Windows.Forms.Button
        Friend WithEvents tpAssignBatteries As System.Windows.Forms.TabPage
        Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dgBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRefreshdatagrid As System.Windows.Forms.Button
        Friend WithEvents dgPartsSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtAddUseQty As System.Windows.Forms.TextBox
        Friend WithEvents txtAddNewQty As System.Windows.Forms.TextBox
        Friend WithEvents lblUsePartMap As System.Windows.Forms.Label
        Friend WithEvents lblNewPartMap As System.Windows.Forms.Label
        Friend WithEvents lblBilledNew As System.Windows.Forms.Label
        Friend WithEvents lblBilledUse As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtAddRVQty As System.Windows.Forms.TextBox
        Friend WithEvents lblRVPartMap As System.Windows.Forms.Label
        Friend WithEvents lblBilledRV As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents lblOpenQty As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents cbHasBC As System.Windows.Forms.CheckBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssignBateryCover))
            Me.tcMain = New System.Windows.Forms.TabControl()
            Me.tpAssignBatteries = New System.Windows.Forms.TabPage()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cbHasBC = New System.Windows.Forms.CheckBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.lblOpenQty = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.lblUsePartMap = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblNewPartMap = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblRVPartMap = New System.Windows.Forms.Label()
            Me.lblBilledRV = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblBilledNew = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblBilledUse = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtAddRVQty = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtAddUseQty = New System.Windows.Forms.TextBox()
            Me.txtAddNewQty = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnRefreshdatagrid = New System.Windows.Forms.Button()
            Me.dgBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnPrintPartSummary = New System.Windows.Forms.Button()
            Me.btnPrintSelectedBox = New System.Windows.Forms.Button()
            Me.btnPrintAllBoxes = New System.Windows.Forms.Button()
            Me.dgPartsSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAddBattery = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtShipBoxName = New System.Windows.Forms.TextBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.tpHistories = New System.Windows.Forms.TabPage()
            Me.btnGetData = New System.Windows.Forms.Button()
            Me.dgHistData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
            Me.tcMain.SuspendLayout()
            Me.tpAssignBatteries.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dgBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgPartsSummary, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpHistories.SuspendLayout()
            CType(Me.dgHistData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcMain
            '
            Me.tcMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpAssignBatteries, Me.tpHistories})
            Me.tcMain.Location = New System.Drawing.Point(4, 8)
            Me.tcMain.Name = "tcMain"
            Me.tcMain.SelectedIndex = 0
            Me.tcMain.Size = New System.Drawing.Size(868, 528)
            Me.tcMain.TabIndex = 0
            Me.tcMain.TabStop = False
            '
            'tpAssignBatteries
            '
            Me.tpAssignBatteries.BackColor = System.Drawing.Color.SteelBlue
            Me.tpAssignBatteries.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSearch, Me.Panel1, Me.GroupBox1, Me.btnRefreshdatagrid, Me.dgBoxes, Me.btnPrintPartSummary, Me.btnPrintSelectedBox, Me.btnPrintAllBoxes, Me.dgPartsSummary, Me.btnAddBattery, Me.Label1, Me.txtShipBoxName, Me.btnClear})
            Me.tpAssignBatteries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tpAssignBatteries.Location = New System.Drawing.Point(4, 22)
            Me.tpAssignBatteries.Name = "tpAssignBatteries"
            Me.tpAssignBatteries.Size = New System.Drawing.Size(860, 502)
            Me.tpAssignBatteries.TabIndex = 0
            Me.tpAssignBatteries.Text = "Assigning Batteries"
            '
            'btnSearch
            '
            Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
            Me.btnSearch.Location = New System.Drawing.Point(240, 8)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(56, 24)
            Me.btnSearch.TabIndex = 12
            Me.btnSearch.TabStop = False
            Me.btnSearch.Text = "Search"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(169, Byte), CType(220, Byte), CType(250, Byte))
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbHasBC, Me.Label14, Me.Label13, Me.lblBoxQty, Me.lblOpenQty, Me.Label16, Me.lblUsePartMap, Me.Label11, Me.lblNewPartMap, Me.Label10, Me.lblRVPartMap, Me.lblBilledRV, Me.Label4, Me.lblBilledNew, Me.Label9, Me.lblBilledUse, Me.Label12, Me.Label2})
            Me.Panel1.Location = New System.Drawing.Point(3, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(357, 136)
            Me.Panel1.TabIndex = 3
            '
            'cbHasBC
            '
            Me.cbHasBC.BackColor = System.Drawing.Color.Transparent
            Me.cbHasBC.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.cbHasBC.Enabled = False
            Me.cbHasBC.Location = New System.Drawing.Point(168, 106)
            Me.cbHasBC.Name = "cbHasBC"
            Me.cbHasBC.Size = New System.Drawing.Size(16, 14)
            Me.cbHasBC.TabIndex = 17
            Me.cbHasBC.TabStop = False
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Black
            Me.Label14.Location = New System.Drawing.Point(16, 106)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(144, 16)
            Me.Label14.TabIndex = 16
            Me.Label14.Text = "Battery Cover Required:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.Location = New System.Drawing.Point(8, 82)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(80, 24)
            Me.Label13.TabIndex = 12
            Me.Label13.Text = "Box Qty:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.SystemColors.Control
            Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblBoxQty.Location = New System.Drawing.Point(96, 82)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(40, 18)
            Me.lblBoxQty.TabIndex = 13
            Me.lblBoxQty.Text = "0"
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOpenQty
            '
            Me.lblOpenQty.BackColor = System.Drawing.SystemColors.Control
            Me.lblOpenQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblOpenQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOpenQty.ForeColor = System.Drawing.Color.Black
            Me.lblOpenQty.Location = New System.Drawing.Point(296, 82)
            Me.lblOpenQty.Name = "lblOpenQty"
            Me.lblOpenQty.Size = New System.Drawing.Size(40, 20)
            Me.lblOpenQty.TabIndex = 15
            Me.lblOpenQty.Text = "0"
            Me.lblOpenQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Black
            Me.Label16.Location = New System.Drawing.Point(223, 82)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(64, 18)
            Me.Label16.TabIndex = 14
            Me.Label16.Text = "Open Qty:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUsePartMap
            '
            Me.lblUsePartMap.BackColor = System.Drawing.SystemColors.Control
            Me.lblUsePartMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblUsePartMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUsePartMap.ForeColor = System.Drawing.Color.Black
            Me.lblUsePartMap.Location = New System.Drawing.Point(96, 34)
            Me.lblUsePartMap.Name = "lblUsePartMap"
            Me.lblUsePartMap.Size = New System.Drawing.Size(120, 20)
            Me.lblUsePartMap.TabIndex = 5
            Me.lblUsePartMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(8, 34)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 24)
            Me.Label11.TabIndex = 4
            Me.Label11.Text = "Use Part #:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNewPartMap
            '
            Me.lblNewPartMap.BackColor = System.Drawing.SystemColors.Control
            Me.lblNewPartMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblNewPartMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNewPartMap.ForeColor = System.Drawing.Color.Black
            Me.lblNewPartMap.Location = New System.Drawing.Point(96, 10)
            Me.lblNewPartMap.Name = "lblNewPartMap"
            Me.lblNewPartMap.Size = New System.Drawing.Size(120, 20)
            Me.lblNewPartMap.TabIndex = 1
            Me.lblNewPartMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(8, 10)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 24)
            Me.Label10.TabIndex = 0
            Me.Label10.Text = "New Part #:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRVPartMap
            '
            Me.lblRVPartMap.BackColor = System.Drawing.SystemColors.Control
            Me.lblRVPartMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRVPartMap.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRVPartMap.ForeColor = System.Drawing.Color.Black
            Me.lblRVPartMap.Location = New System.Drawing.Point(96, 58)
            Me.lblRVPartMap.Name = "lblRVPartMap"
            Me.lblRVPartMap.Size = New System.Drawing.Size(120, 18)
            Me.lblRVPartMap.TabIndex = 9
            Me.lblRVPartMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBilledRV
            '
            Me.lblBilledRV.BackColor = System.Drawing.SystemColors.Control
            Me.lblBilledRV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBilledRV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBilledRV.ForeColor = System.Drawing.Color.Black
            Me.lblBilledRV.Location = New System.Drawing.Point(296, 58)
            Me.lblBilledRV.Name = "lblBilledRV"
            Me.lblBilledRV.Size = New System.Drawing.Size(40, 20)
            Me.lblBilledRV.TabIndex = 11
            Me.lblBilledRV.Text = "0"
            Me.lblBilledRV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(223, 58)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(64, 18)
            Me.Label4.TabIndex = 10
            Me.Label4.Text = "R.V. Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBilledNew
            '
            Me.lblBilledNew.BackColor = System.Drawing.SystemColors.Control
            Me.lblBilledNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBilledNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBilledNew.ForeColor = System.Drawing.Color.Black
            Me.lblBilledNew.Location = New System.Drawing.Point(296, 10)
            Me.lblBilledNew.Name = "lblBilledNew"
            Me.lblBilledNew.Size = New System.Drawing.Size(40, 20)
            Me.lblBilledNew.TabIndex = 3
            Me.lblBilledNew.Text = "0"
            Me.lblBilledNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(223, 10)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(64, 16)
            Me.Label9.TabIndex = 2
            Me.Label9.Text = "New Qty:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBilledUse
            '
            Me.lblBilledUse.BackColor = System.Drawing.SystemColors.Control
            Me.lblBilledUse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBilledUse.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBilledUse.ForeColor = System.Drawing.Color.Black
            Me.lblBilledUse.Location = New System.Drawing.Point(296, 34)
            Me.lblBilledUse.Name = "lblBilledUse"
            Me.lblBilledUse.Size = New System.Drawing.Size(40, 20)
            Me.lblBilledUse.TabIndex = 7
            Me.lblBilledUse.Text = "0"
            Me.lblBilledUse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(223, 34)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(64, 16)
            Me.Label12.TabIndex = 6
            Me.Label12.Text = "Use Qty:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(8, 58)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 24)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "R.V. Part #:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.txtAddRVQty, Me.Label5, Me.txtAddUseQty, Me.txtAddNewQty, Me.Label3})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(0, 184)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(360, 44)
            Me.GroupBox1.TabIndex = 4
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Adding Quantity"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(16, 18)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(40, 17)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "R.V.:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAddRVQty
            '
            Me.txtAddRVQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddRVQty.Location = New System.Drawing.Point(64, 16)
            Me.txtAddRVQty.Name = "txtAddRVQty"
            Me.txtAddRVQty.Size = New System.Drawing.Size(40, 22)
            Me.txtAddRVQty.TabIndex = 1
            Me.txtAddRVQty.TabStop = False
            Me.txtAddRVQty.Text = "0"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(136, 18)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(40, 17)
            Me.Label5.TabIndex = 2
            Me.Label5.Text = "New:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAddUseQty
            '
            Me.txtAddUseQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddUseQty.Location = New System.Drawing.Point(296, 16)
            Me.txtAddUseQty.Name = "txtAddUseQty"
            Me.txtAddUseQty.Size = New System.Drawing.Size(40, 22)
            Me.txtAddUseQty.TabIndex = 5
            Me.txtAddUseQty.Text = "0"
            '
            'txtAddNewQty
            '
            Me.txtAddNewQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddNewQty.Location = New System.Drawing.Point(184, 16)
            Me.txtAddNewQty.Name = "txtAddNewQty"
            Me.txtAddNewQty.Size = New System.Drawing.Size(40, 22)
            Me.txtAddNewQty.TabIndex = 3
            Me.txtAddNewQty.Text = "0"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(248, 18)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 17)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Used:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRefreshdatagrid
            '
            Me.btnRefreshdatagrid.BackColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnRefreshdatagrid.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshdatagrid.ForeColor = System.Drawing.Color.White
            Me.btnRefreshdatagrid.Location = New System.Drawing.Point(328, 472)
            Me.btnRefreshdatagrid.Name = "btnRefreshdatagrid"
            Me.btnRefreshdatagrid.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshdatagrid.TabIndex = 9
            Me.btnRefreshdatagrid.TabStop = False
            Me.btnRefreshdatagrid.Text = "Refresh Lists"
            '
            'dgBoxes
            '
            Me.dgBoxes.AllowColMove = False
            Me.dgBoxes.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgBoxes.AllowUpdate = False
            Me.dgBoxes.AllowUpdateOnBlur = False
            Me.dgBoxes.AlternatingRows = True
            Me.dgBoxes.CaptionHeight = 19
            Me.dgBoxes.CollapseColor = System.Drawing.Color.White
            Me.dgBoxes.ExpandColor = System.Drawing.Color.White
            Me.dgBoxes.FilterBar = True
            Me.dgBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgBoxes.ForeColor = System.Drawing.Color.White
            Me.dgBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgBoxes.Location = New System.Drawing.Point(8, 240)
            Me.dgBoxes.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.dgBoxes.Name = "dgBoxes"
            Me.dgBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgBoxes.PreviewInfo.ZoomFactor = 75
            Me.dgBoxes.RowHeight = 20
            Me.dgBoxes.Size = New System.Drawing.Size(840, 224)
            Me.dgBoxes.TabIndex = 7
            Me.dgBoxes.TabStop = False
            Me.dgBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;}Caption{AlignHorz:Center;ForeColor:" & _
            "MidnightBlue;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackC" & _
            "olor:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style12{}OddRow{Font:Tahoma, 8.25pt;ForeColor:Bl" & _
            "ack;BackColor:LightBlue;}RecordSelector{AlignImage:Center;ForeColor:White;}Style" & _
            "13{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:Center;AlignVert" & _
            ":Center;Border:Raised,,1, 1, 1, 1;ForeColor:DarkBlue;BackColor:LightSteelBlue;}S" & _
            "tyle8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}Styl" & _
            "e1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" " & _
            "Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
            "mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>220</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 836, 220</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 836, 220</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnPrintPartSummary
            '
            Me.btnPrintPartSummary.BackColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnPrintPartSummary.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintPartSummary.ForeColor = System.Drawing.Color.White
            Me.btnPrintPartSummary.Location = New System.Drawing.Point(8, 472)
            Me.btnPrintPartSummary.Name = "btnPrintPartSummary"
            Me.btnPrintPartSummary.Size = New System.Drawing.Size(216, 23)
            Me.btnPrintPartSummary.TabIndex = 8
            Me.btnPrintPartSummary.TabStop = False
            Me.btnPrintPartSummary.Text = "Print Parts Summary Report"
            '
            'btnPrintSelectedBox
            '
            Me.btnPrintSelectedBox.BackColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnPrintSelectedBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintSelectedBox.ForeColor = System.Drawing.Color.White
            Me.btnPrintSelectedBox.Location = New System.Drawing.Point(504, 472)
            Me.btnPrintSelectedBox.Name = "btnPrintSelectedBox"
            Me.btnPrintSelectedBox.Size = New System.Drawing.Size(152, 23)
            Me.btnPrintSelectedBox.TabIndex = 10
            Me.btnPrintSelectedBox.TabStop = False
            Me.btnPrintSelectedBox.Text = "Print Selected Boxes"
            '
            'btnPrintAllBoxes
            '
            Me.btnPrintAllBoxes.BackColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnPrintAllBoxes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintAllBoxes.ForeColor = System.Drawing.Color.White
            Me.btnPrintAllBoxes.Location = New System.Drawing.Point(720, 472)
            Me.btnPrintAllBoxes.Name = "btnPrintAllBoxes"
            Me.btnPrintAllBoxes.Size = New System.Drawing.Size(136, 23)
            Me.btnPrintAllBoxes.TabIndex = 11
            Me.btnPrintAllBoxes.TabStop = False
            Me.btnPrintAllBoxes.Text = "Print All Boxes"
            '
            'dgPartsSummary
            '
            Me.dgPartsSummary.AllowColMove = False
            Me.dgPartsSummary.AllowFilter = False
            Me.dgPartsSummary.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgPartsSummary.AllowUpdate = False
            Me.dgPartsSummary.AllowUpdateOnBlur = False
            Me.dgPartsSummary.AlternatingRows = True
            Me.dgPartsSummary.Caption = "Parts Summary"
            Me.dgPartsSummary.CaptionHeight = 19
            Me.dgPartsSummary.CollapseColor = System.Drawing.Color.White
            Me.dgPartsSummary.ExpandColor = System.Drawing.Color.White
            Me.dgPartsSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgPartsSummary.ForeColor = System.Drawing.Color.White
            Me.dgPartsSummary.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPartsSummary.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgPartsSummary.Location = New System.Drawing.Point(368, 8)
            Me.dgPartsSummary.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dgPartsSummary.Name = "dgPartsSummary"
            Me.dgPartsSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPartsSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPartsSummary.PreviewInfo.ZoomFactor = 75
            Me.dgPartsSummary.RowHeight = 20
            Me.dgPartsSummary.Size = New System.Drawing.Size(480, 168)
            Me.dgPartsSummary.TabIndex = 6
            Me.dgPartsSummary.TabStop = False
            Me.dgPartsSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:Lavender;}Selected{ForeColor:HighlightText;BackColor:Highli" & _
            "ght;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{}Foot" & _
            "er{}Caption{AlignHorz:Center;ForeColor:Black;}Style9{}Normal{Font:Microsoft Sans" & _
            " Serif, 8.25pt, style=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:Ce" & _
            "nter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{" & _
            "Font:Tahoma, 8.25pt;ForeColor:Black;BackColor:LightSteelBlue;}RecordSelector{Ali" & _
            "gnImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans S" & _
            "erif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, " & _
            "1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}Style10{AlignHorz:Near;}S" & _
            "tyle11{}Style14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1TrueDBGrid.MergeView AllowColMove=""False"" Name="""" AllowRowSizing=""None"" Al" & _
            "ternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFoote" & _
            "rHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelW" & _
            "idth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>145</Height>" & _
            "<CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""St" & _
            "yle5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Fil" & _
            "terBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle pa" & _
            "rent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLi" & _
            "ghtRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive""" & _
            " me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle p" & _
            "arent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style" & _
            "6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 19, 476, 145</ClientRec" & _
            "t><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGr" & _
            "id.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=" & _
            """Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Hea" & _
            "ding"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Norm" & _
            "al"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" " & _
            "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
            " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Norm" & _
            "al"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSpl" & _
            "its>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelW" & _
            "idth>17</DefaultRecSelWidth><ClientArea>0, 0, 476, 164</ClientArea><PrintPageHea" & _
            "derStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /" & _
            "></Blob>"
            '
            'btnAddBattery
            '
            Me.btnAddBattery.BackColor = System.Drawing.Color.Green
            Me.btnAddBattery.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddBattery.ForeColor = System.Drawing.Color.White
            Me.btnAddBattery.Location = New System.Drawing.Point(400, 184)
            Me.btnAddBattery.Name = "btnAddBattery"
            Me.btnAddBattery.Size = New System.Drawing.Size(272, 48)
            Me.btnAddBattery.TabIndex = 5
            Me.btnAddBattery.Text = "ASSIGN BATTERY COVER TO BOX and MOVE TO WH-RB"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Location = New System.Drawing.Point(0, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Box Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShipBoxName
            '
            Me.txtShipBoxName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipBoxName.Location = New System.Drawing.Point(80, 8)
            Me.txtShipBoxName.Name = "txtShipBoxName"
            Me.txtShipBoxName.Size = New System.Drawing.Size(152, 21)
            Me.txtShipBoxName.TabIndex = 1
            Me.txtShipBoxName.Text = ""
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.SystemColors.Control
            Me.btnClear.Location = New System.Drawing.Point(304, 8)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(56, 24)
            Me.btnClear.TabIndex = 2
            Me.btnClear.TabStop = False
            Me.btnClear.Text = "Clear"
            '
            'tpHistories
            '
            Me.tpHistories.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpHistories.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGetData, Me.dgHistData, Me.Label8, Me.Label7, Me.dtpDateEnd, Me.dtpDateStart})
            Me.tpHistories.Location = New System.Drawing.Point(4, 22)
            Me.tpHistories.Name = "tpHistories"
            Me.tpHistories.Size = New System.Drawing.Size(860, 502)
            Me.tpHistories.TabIndex = 1
            Me.tpHistories.Text = "History Data"
            '
            'btnGetData
            '
            Me.btnGetData.BackColor = System.Drawing.Color.SlateGray
            Me.btnGetData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetData.ForeColor = System.Drawing.Color.White
            Me.btnGetData.Location = New System.Drawing.Point(520, 10)
            Me.btnGetData.Name = "btnGetData"
            Me.btnGetData.Size = New System.Drawing.Size(80, 23)
            Me.btnGetData.TabIndex = 2
            Me.btnGetData.Text = "Get Data"
            '
            'dgHistData
            '
            Me.dgHistData.AllowColMove = False
            Me.dgHistData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgHistData.AllowUpdate = False
            Me.dgHistData.AllowUpdateOnBlur = False
            Me.dgHistData.AlternatingRows = True
            Me.dgHistData.CaptionHeight = 19
            Me.dgHistData.CollapseColor = System.Drawing.Color.White
            Me.dgHistData.ExpandColor = System.Drawing.Color.White
            Me.dgHistData.FilterBar = True
            Me.dgHistData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgHistData.ForeColor = System.Drawing.Color.White
            Me.dgHistData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgHistData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dgHistData.Location = New System.Drawing.Point(5, 48)
            Me.dgHistData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dgHistData.Name = "dgHistData"
            Me.dgHistData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgHistData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgHistData.PreviewInfo.ZoomFactor = 75
            Me.dgHistData.RowHeight = 20
            Me.dgHistData.Size = New System.Drawing.Size(848, 432)
            Me.dgHistData.TabIndex = 12
            Me.dgHistData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;ForeColor:White;}Caption{AlignHorz:C" & _
            "enter;ForeColor:MidnightBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, " & _
            "style=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Font:Tahoma, 8.2" & _
            "5pt;ForeColor:Black;BackColor:LightBlue;}RecordSelector{ForeColor:White;AlignIma" & _
            "ge:Center;}Style15{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:" & _
            "Center;BackColor:LightSlateGray;Border:Raised,,1, 1, 1, 1;ForeColor:White;AlignV" & _
            "ert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}" & _
            "Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeig" & _
            "ht=""28"" AllowColMove=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""" & _
            "True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Filter" & _
            "Bar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWid" & _
            "th=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>428</Height><C" & _
            "aptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Styl" & _
            "e5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filte" & _
            "rBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle pare" & _
            "nt=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLigh" & _
            "tRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" m" & _
            "e=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle par" & _
            "ent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6""" & _
            " /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 844, 428</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 844, 428</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></" & _
            "Blob>"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(320, 15)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(72, 16)
            Me.Label8.TabIndex = 3
            Me.Label8.Text = "Date End:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(8, 15)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(192, 16)
            Me.Label7.TabIndex = 2
            Me.Label7.Text = "Box Completed Date Start:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpDateEnd
            '
            Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDateEnd.Location = New System.Drawing.Point(392, 13)
            Me.dtpDateEnd.Name = "dtpDateEnd"
            Me.dtpDateEnd.Size = New System.Drawing.Size(104, 20)
            Me.dtpDateEnd.TabIndex = 1
            '
            'dtpDateStart
            '
            Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDateStart.Location = New System.Drawing.Point(200, 13)
            Me.dtpDateStart.Name = "dtpDateStart"
            Me.dtpDateStart.Size = New System.Drawing.Size(96, 20)
            Me.dtpDateStart.TabIndex = 0
            '
            'AssignBateryCover
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(880, 557)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcMain})
            Me.Name = "AssignBateryCover"
            Me.Text = "Assigning Batery Cover"
            Me.tcMain.ResumeLayout(False)
            Me.tpAssignBatteries.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dgBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgPartsSummary, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpHistories.ResumeLayout(False)
            CType(Me.dgHistData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "FORM EVENTS"

        Private Sub AssignBateryCover_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' SET VALUES UPON LOAD.
                Me.btnAddBattery.Text = "ASSIGN BATTERY COVER TO BOX" & Environment.NewLine & " and MOVE TO WH-RB"
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False
                Me.dtpDateStart.Value = Now()
                Me.dtpDateEnd.Value = Now()
                ' POPULATE THE GRIDS AND COMBOS.
                Me.PopulateOpenBatteryCoverQtyByBoxes()
                Me.PopulatePartsSummary()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AssignBateryCover_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtShipBoxName.Focus()
            End Try
        End Sub

#End Region
#Region "CONTROL EVENTS"
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            ' Resets the form back to it's original state.
            ClearAssignBCControls(True)
            SetAssignButtonLabel()
            txtShipBoxName.Focus()
        End Sub
        Private Sub dgBoxes_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dgBoxes.AfterFilter
            Dim i As Integer = 0
            Dim iBoxTotalQty As Integer = 0
            Dim iNewBatCoverTotalQty As Integer = 0
            Dim iUseBatCoverTotalQty As Integer = 0
            Dim iOpenQty As Integer = 0
            Dim iRVBatCoverTotalQty As Integer = 0
            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                With Me.dgBoxes
                    For i = 0 To .RowCount - 1
                        iBoxTotalQty += CInt(.Columns("Box Qty").CellValue(i))
                        iNewBatCoverTotalQty += CInt(.Columns("New Qty").CellValue(i))
                        iUseBatCoverTotalQty += CInt(.Columns("Use Qty").CellValue(i))
                        iRVBatCoverTotalQty += CInt(.Columns("RV Qty").CellValue(i))
                        iOpenQty += CInt(.Columns("Open Qty").CellValue(i))
                    Next i
                    .Columns("Box Qty").FooterText = Format(iBoxTotalQty, "#,##0").ToString
                    .Columns("New Qty").FooterText = Format(iNewBatCoverTotalQty, "#,##0").ToString
                    .Columns("Use Qty").FooterText = Format(iUseBatCoverTotalQty, "#,##0").ToString
                    .Columns("RV Qty").FooterText = Format(iUseBatCoverTotalQty, "#,##0").ToString
                    .Columns("Open Qty").FooterText = Format(iOpenQty, "#,##0").ToString
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dgBoxes_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub txtShipBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipBoxName.KeyUp
            ' DO A FEW TEST FIRST.
            If e.KeyCode = Keys.Enter Then
                SearchForBox()
            End If
        End Sub
        Private Sub btnPrintPartSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPartSummary.Click
            Const strReportName As String = "TracFone  Battery Cover Qty By Part Push.rpt"
            Dim dt As DataTable

            Try
                dt = Me.dgPartsSummary.DataSource.Table

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    Me._objTFMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrintPartSummary_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub btnPrintSelectedBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSelectedBox.Click
            Const strReportName As String = "TracFone Battery Cover Qty By Box Push.rpt"
            Dim dt, dtSelectedRow As DataTable
            Dim R1 As DataRow
            Dim i, j As Integer

            Try
                If Me.dgBoxes.SelectedRows.Count = 0 Then
                    MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = Me.dgBoxes.DataSource.Table
                    dtSelectedRow = New DataTable()
                    dtSelectedRow = dt.Clone

                    For i = 0 To Me.dgBoxes.SelectedRows.Count - 1
                        R1 = dtSelectedRow.NewRow

                        For j = 0 To Me.dgBoxes.Columns.Count - 1
                            R1(j) = Me.dgBoxes.Columns(j).CellValue(i)
                        Next j

                        dtSelectedRow.Rows.Add(R1)
                        R1 = Nothing
                    Next i

                    Me._objTFMisc.PrintCrystalReportLabel(dtSelectedRow, strReportName, 1, )
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrintPartSummary_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                dt = Nothing
                Generic.DisposeDT(dtSelectedRow)
            End Try
        End Sub
        Private Sub btnPrintAllBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAllBoxes.Click
            Const strReportName As String = "TracFone Battery Cover Qty By Box Push.rpt"
            Dim dt As DataTable

            Try
                dt = Me.dgBoxes.DataSource.Table

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    Me._objTFMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrintPartSummary_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub btnRefreshdatagrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshdatagrid.Click
            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                Me.PopulateOpenBatteryCoverQtyByBoxes()
                Me.PopulatePartsSummary()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Refresh Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                Me.dgHistData.DataSource = Nothing

                If DateDiff(DateInterval.Day, Me.dtpDateStart.Value, Me.dtpDateEnd.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "btnGetData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = _objTFMisc.GetBilledBatteryCoverQtyBoxes(Me.dtpDateStart.Value.ToString("yyyy-MM-dd"), Me.dtpDateEnd.Value.ToString("yyyy-MM-dd"))
                    With Me.dgHistData
                        .DataSource = dt.DefaultView
                        .Splits(0).DisplayColumns("Box").Width = 160
                        .Splits(0).DisplayColumns("Produced Date").Width = 90
                        .Splits(0).DisplayColumns("New Part #").Width = 120
                        .Splits(0).DisplayColumns("Use Part #").Width = 120
                        .Splits(0).DisplayColumns("Box Qty").Width = 50
                        .Splits(0).DisplayColumns("New Qty").Width = 55
                        .Splits(0).DisplayColumns("Use Qty").Width = 50
                        .Splits(0).DisplayColumns("RV Qty").Width = 50
                        .Splits(0).DisplayColumns("Open Qty").Width = 58
                        .Splits(0).DisplayColumns("Packing Slip ID").Width = 95

                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                            If .Columns(i).Caption.EndsWith("Qty") Then .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Next i

                        .Splits(0).DisplayColumns("Produced Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns("Packing Slip ID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                        .ColumnFooters = True
                        .Columns("Use Part #").FooterText = "TOTAL"
                        If Not IsDBNull(dt.Compute("Sum([Box Qty])", "")) Then .Columns("Box Qty").FooterText = Format(dt.Compute("Sum([Box Qty])", ""), "#,##0").ToString Else .Columns("Box Qty").FooterText = Format(0, "#,##0")
                        If Not IsDBNull(dt.Compute("Sum([New Qty])", "")) Then .Columns("New Qty").FooterText = Format(dt.Compute("Sum([New Qty])", ""), "#,##0").ToString Else .Columns("New Qty").FooterText = Format(0, "#,##0")
                        If Not IsDBNull(dt.Compute("Sum([Use Qty])", "")) Then .Columns("Use Qty").FooterText = Format(dt.Compute("Sum([Use Qty])", ""), "#,##0").ToString Else .Columns("Use Qty").FooterText = Format(0, "#,##0")
                        If Not IsDBNull(dt.Compute("Sum([RV Qty])", "")) Then .Columns("RV Qty").FooterText = Format(dt.Compute("Sum([RV Qty])", ""), "#,##0").ToString Else .Columns("RV Qty").FooterText = Format(0, "#,##0")
                        If Not IsDBNull(dt.Compute("Sum([Open Qty])", "")) Then .Columns("Open Qty").FooterText = Format(dt.Compute("Sum([Open Qty])", ""), "#,##0").ToString Else .Columns("Open Qty").FooterText = Format(0, "#,##0")
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AssignBateryCover_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub dgHistData_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dgHistData.AfterFilter
            Dim i, iBoxTotalQty, iNewBatCoverTotalQty, iUseBatCoverTotalQty, iOpenQty, iRVBatCoverTotalQty As Integer

            Try
                i = 0 : iBoxTotalQty = 0 : iNewBatCoverTotalQty = 0 : iUseBatCoverTotalQty = 0 : iOpenQty = 0

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.dgHistData

                    For i = 0 To .RowCount - 1
                        iBoxTotalQty += CInt(.Columns("Box Qty").CellValue(i))
                        iNewBatCoverTotalQty += CInt(.Columns("New Qty").CellValue(i))
                        iUseBatCoverTotalQty += CInt(.Columns("Use Qty").CellValue(i))
                        iRVBatCoverTotalQty += CInt(.Columns("RV Qty").CellValue(i))
                        iOpenQty += CInt(.Columns("Open Qty").CellValue(i))
                    Next i

                    .Columns("Box Qty").FooterText = Format(iBoxTotalQty, "#,##0").ToString
                    .Columns("New Qty").FooterText = Format(iNewBatCoverTotalQty, "#,##0").ToString
                    .Columns("Use Qty").FooterText = Format(iUseBatCoverTotalQty, "#,##0").ToString
                    .Columns("RV Qty").FooterText = Format(iUseBatCoverTotalQty, "#,##0").ToString
                    .Columns("Open Qty").FooterText = Format(iOpenQty, "#,##0").ToString
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dgHistData_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub dgPartsSummary_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgPartsSummary.MouseDown, dgBoxes.MouseDown, dgHistData.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all grid data to the clipboard."
                    objCopySelected.Text = "Copy selected rows to the clipboard."

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    If sender.name = "dgPartsSummary" Then
                        RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData_PartsSummary
                        AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData_PartsSummary
                        RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_PartsSummary
                        AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_PartsSummary
                    ElseIf sender.name = "dgBoxes" Then
                        RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData_Boxes
                        AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData_Boxes
                        RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_Boxes
                        AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_Boxes
                    ElseIf sender.name = "dgHistData" Then
                        RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData_HistData
                        AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData_HistData
                        RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_HistData
                        AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData_HistData
                    End If

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgs_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub txtAddQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddNewQty.KeyPress
            Try
                If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtAddQty_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnAddBattery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBattery.Click
            Dim dteToday As DateTime = Nothing
            Dim _boxname As String = txtShipBoxName.Text
            Dim _modelHasBC As Boolean = True
            Dim _bcAssigned As Boolean = False
            Dim _movedToWHRB As Boolean = False
            Dim iInvoiceYrMonth As Integer
            Dim i As Integer
            Try
                ' INITIALIZE.
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                iInvoiceYrMonth = 0
                dteToday = CDate(Data.Buisness.Generic.MySQLServerDateTime(1))
                iInvoiceYrMonth = CInt(dteToday.Year & dteToday.Month.ToString("00"))

                ' VALIDATE PALLET ID.
                If Me._iPalletID = 0 Then
                    MessageBox.Show("System can't define Box ID. Please re-enter Box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ClearAssignBCControls(True)
                    Me.Enabled = True
                    Me.txtShipBoxName.SelectAll()
                    Me.txtShipBoxName.Focus()
                    Return
                End If

                ' SEE IF THE MODEL REQUIRES A BC.
                _modelHasBC = IsBCRequired()

                ' BATTERY COVER MODEL BILLING.
                If _modelHasBC Then
                    _bcAssigned = BillForBatteryCovers(iInvoiceYrMonth)
                End If
                ' MOVE THE BOX TO WH-RB.
                _movedToWHRB = MoveBoxToWH_RB()

            Catch ex As Exception
                MessageBox.Show(ex.Message & "   Failed to move to WH_RB after battery cover assigned. See IT.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

            Try
                ' CLEAN UP THE SCREEN AND REFRESH THE DATA.
                ClearAssignBCControls(False)
                Me.PopulateOpenBatteryCoverQtyByBoxes()
                Me.PopulatePartsSummary()
                Me.Enabled = True
                Me.txtShipBoxName.Focus()

                ' NOTIFY THE USER OF THE CHANGES THAT TOOK PLACE.
                Dim _msg As String = "Box " & _boxname & " has been processed." & vbCrLf & vbCrLf
                If _bcAssigned Then
                    _msg &= "Battery Covers assigned" & vbCrLf
                    txtShipBoxName.Text = ""
                End If
                If _movedToWHRB Then
                    _msg &= "Box moved to WH-RB"
                    txtShipBoxName.Text = ""
                End If
                If Not _bcAssigned And Not _movedToWHRB Then
                    _msg = "ATTENTION: The assign battery cover and move to WH-RB process Failed."
                End If
                MessageBox.Show(_msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddBattery_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try

        End Sub
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            SearchForBox()
        End Sub
#End Region
#Region "METHODS"
        Private Sub PopulateOpenBatteryCoverQtyByBoxes()
            Dim dt As DataTable
            Dim _dt2 As DataTable
            Dim i As Integer
            Try
                Me.dgBoxes.DataSource = Nothing
                ' GET THE DATA.                
                dt = Me._objTFMisc.GetOpenQtyOfBatteryCoverByBox()
                '' REMOVE ITEMS THAT DO NOT REQUIRE BATTERY COVERS AND THAT 
                '' HAVE ALREADY PROCESS THROUGH THIS SCREEN.
                '_dt2 = Me._objTFMisc.GetWSJ_for_nbcr_in_whrb()
                'Dim _dr2 As DataRow
                'For Each _dr2 In _dt2.Rows
                '    Dim _dr1 As DataRow
                '    For Each _dr1 In dt.Rows
                '        If _dr2("Pallett_ID") = _dr1("Pallett_ID") Then
                '            _dr1.Delete()
                '        End If
                '    Next
                '    dt.AcceptChanges()
                'Next
                ' CONTINUE WITH EXISTING CODE.
                With Me.dgBoxes
                    .DataSource = dt.DefaultView

                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        If .Columns(i).Caption.EndsWith("Qty") Then
                            .Splits(0).DisplayColumns(i).Width = 40
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        End If
                    Next i
                    .Splits(0).DisplayColumns("Box").Width = 140
                    .Splits(0).DisplayColumns("Produced Date").Width = 60
                    .Splits(0).DisplayColumns("New Part #").Width = 75
                    .Splits(0).DisplayColumns("Use Part #").Width = 80
                    .Splits(0).DisplayColumns("RV Part #").Width = 80
                    .Splits(0).DisplayColumns("Produced Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns("New/Use/RV Part").Visible = False
                    .Splits(0).DisplayColumns("Pallett_ID").Visible = False
                    .ColumnFooters = True
                    .Columns("Use Part #").FooterText = "TOTAL"
                    If Not IsDBNull(dt.Compute("Sum([Box Qty])", "")) Then .Columns("Box Qty").FooterText = Format(dt.Compute("Sum([Box Qty])", ""), "#,##0").ToString Else .Columns("Box Qty").FooterText = Format(0, "#,##0")
                    If Not IsDBNull(dt.Compute("Sum([New Qty])", "")) Then .Columns("New Qty").FooterText = Format(dt.Compute("Sum([New Qty])", ""), "#,##0").ToString Else .Columns("New Qty").FooterText = Format(0, "#,##0")
                    If Not IsDBNull(dt.Compute("Sum([Use Qty])", "")) Then .Columns("Use Qty").FooterText = Format(dt.Compute("Sum([Use Qty])", ""), "#,##0").ToString Else .Columns("Use Qty").FooterText = Format(0, "#,##0")
                    If Not IsDBNull(dt.Compute("Sum([RV Qty])", "")) Then .Columns("RV Qty").FooterText = Format(dt.Compute("Sum([RV Qty])", ""), "#,##0").ToString Else .Columns("RV Qty").FooterText = Format(0, "#,##0")
                    If Not IsDBNull(dt.Compute("Sum([Open Qty])", "")) Then .Columns("Open Qty").FooterText = Format(dt.Compute("Sum([Open Qty])", ""), "#,##0").ToString Else .Columns("Open Qty").FooterText = Format(0, "#,##0")
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub PopulatePartsSummary()
            Dim dt, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim i As Integer
            Try
                Me.dgPartsSummary.DataSource = Nothing

                If IsNothing(Me.dgBoxes.DataSource) Then Exit Sub

                dt2 = Me.dgBoxes.DataSource.Table
                dt = New DataTable()
                dt = dt2.Clone

                dt.Columns.Remove("Produced Date") : dt.Columns.Remove("Box")
                dt.Columns.Remove("New/Use/RV Part") : dt.Columns.Remove("Pallett_ID")
                dt.AcceptChanges()

                For Each R1 In dt2.Rows
                    If dt.Select("[New Part #] = '" & R1("New Part #") & "'").Length = 0 Then
                        R2 = dt.NewRow
                        R2("New Part #") = R1("New Part #")
                        R2("Use Part #") = R1("Use Part #")
                        R2("RV Part #") = R1("RV Part #")
                        R2("Box Qty") = R1("Box Qty")
                        R2("New Qty") = R1("New Qty")
                        R2("Use Qty") = R1("Use Qty")
                        R2("RV Qty") = R1("RV Qty")
                        R2("Open Qty") = R1("Open Qty")
                        dt.Rows.Add(R2) : dt.AcceptChanges()
                    Else
                        R2 = dt.Select("[New Part #] = '" & R1("New Part #") & "'")(0)
                        R2.BeginEdit()
                        'R2("Use Part #") = R1("Use Part #")
                        R2("Box Qty") = CInt(R2("Box Qty")) + CInt(R1("Box Qty"))
                        R2("New Qty") = CInt(R2("New Qty")) + CInt(R1("New Qty"))
                        R2("Use Qty") = CInt(R2("Use Qty")) + CInt(R1("Use Qty"))
                        R2("RV Qty") = CInt(R2("RV Qty")) + CInt(R1("RV Qty"))
                        R2("Open Qty") = CInt(R2("Open Qty")) + CInt(R1("Open Qty"))
                        R2.EndEdit()
                    End If
                Next R1

                With Me.dgPartsSummary
                    .DataSource = dt.DefaultView

                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next i

                    .Splits(0).DisplayColumns("New Qty").Visible = False
                    .Splits(0).DisplayColumns("Use Qty").Visible = False
                    .Splits(0).DisplayColumns("Box Qty").Visible = False
                    .Splits(0).DisplayColumns("RV Qty").Visible = False

                    .Splits(0).DisplayColumns("New Part #").Width = 85
                    .Splits(0).DisplayColumns("Use Part #").Width = 85
                    .Splits(0).DisplayColumns("Open Qty").Width = 55
                    .Splits(0).DisplayColumns("RV Qty").Width = 55

                    .Splits(0).DisplayColumns("Open Qty").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                End With
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : R2 = Nothing
                dt2 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Function ValidateBoxCriteria(ByVal dtData As DataTable) As Boolean
            Dim bReturnVal As Boolean = False
            Try
                If dtData.Rows.Count = 0 Then
                    MessageBox.Show("Box name does not exist for Tracfone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                ElseIf dtData.Rows.Count <> 1 Then
                    MessageBox.Show("Duplicate record return. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                ElseIf dtData.Select("Pallett_ShipDate is null").Length > 0 Then
                    MessageBox.Show("Box has not produced.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                ElseIf dtData.Select("pkslip_ID > 0").Length > 0 Then
                    MessageBox.Show("Box has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                ElseIf cbHasBC.Checked AndAlso dtData.Select("[has bc] = 1 AND [New Part #] = ''").Length > 0 Then
                    MessageBox.Show("New battery cover is not mapped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                ElseIf cbHasBC.Checked AndAlso Me.txtAddUseQty.Text.Trim.Length > 0 AndAlso Me.txtAddUseQty.Text <> "0" AndAlso dtData.Select("[Use Part #] = ''").Length > 0 Then
                    MessageBox.Show("Use battery cover is not mapped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf cbHasBC.Checked AndAlso Me.txtAddRVQty.Text.Trim.Length > 0 AndAlso Me.txtAddRVQty.Text <> "0" AndAlso dtData.Select("[RV Part #] = ''").Length > 0 Then
                    MessageBox.Show("RV battery cover is not mapped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                ElseIf dtData.Select("Pallet_ShipType > 0 ").Length > 0 Then
                    MessageBox.Show("This is not a finished good box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                Else
                    bReturnVal = True
                End If
                Return bReturnVal
            Catch ex As Exception
                Throw ex
                Generic.DisposeDT(dtData)
            End Try
        End Function
        Protected Sub ClearAssignBCControls(ByVal IncludeBoxName As Boolean)
            ' CLEAR FIELDS ASSOCIATED TO THE ASSIGN BATTERY COVER PROCESS.
            Me._iPalletID = 0
            Me.lblBoxQty.Text = "0"
            Me.lblOpenQty.Text = "0"
            Me.lblBilledNew.Text = "0"
            Me.lblBilledUse.Text = "0"
            Me.lblBilledRV.Text = "0"
            Me.lblNewPartMap.Text = ""
            Me.lblUsePartMap.Text = ""
            Me.txtAddNewQty.Text = "0"
            Me.txtAddUseQty.Text = "0"
            Me.txtAddRVQty.Text = "0"
            If IncludeBoxName Then
                Me.txtShipBoxName.Text = ""
                Me.cbHasBC.Checked = True
            End If
        End Sub
        Protected Sub ClearControlsIfInvalid()
            Me._iPalletID = 0
            Me.lblBoxQty.Text = "0"
            Me.lblOpenQty.Text = "0"
            Me.lblBilledNew.Text = "0"
            Me.lblBilledUse.Text = "0"
            Me.lblBilledRV.Text = "0"
            Me.lblNewPartMap.Text = ""
            Me.lblUsePartMap.Text = ""
            Me.lblRVPartMap.Text = ""
        End Sub
        Private Sub CMenuCopyAllData_PartsSummary(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgPartsSummary)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub CMenuCopySelectedData_PartsSummary(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgPartsSummary)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub CMenuCopyAllData_Boxes(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgBoxes)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub CMenuCopySelectedData_Boxes(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgBoxes)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub CMenuCopyAllData_HistData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgHistData)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub CMenuCopySelectedData_HistData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgHistData)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub SetAssignButtonLabel()
            If Not cbHasBC.Checked Then
                Me.btnAddBattery.Text = "MOVE TO WH-RB"
            Else
                Me.btnAddBattery.Text = "ASSIGN BATTERY COVER TO BOX and MOVE TO WH-RB"
            End If
        End Sub
        Private Sub EnableControls()
            txtAddNewQty.Enabled = cbHasBC.Checked
            txtAddUseQty.Enabled = cbHasBC.Checked
            txtAddRVQty.Enabled = cbHasBC.Checked
        End Sub
        Protected Function IsBCRequired()
            ' SEE IF THE MODEL REQUIRES A BC.
            Dim _mdlID As Integer
            Dim _gp As New Data.Buisness.GenericProcess.clsGenericProcess()
            _mdlID = _gp.GetModelIdOfPallet(Me._iPalletID)
            Dim _mdl As New Data.Model(_mdlID)
            Return _mdl.Has_BC
        End Function
        Protected Sub SearchForBox()
            Dim dt As DataTable

            If Me.txtShipBoxName.Text.Trim.Length = 0 Then Exit Sub
            Try
                ClearAssignBCControls(False)
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                dt = Me._objTFMisc.GetOpenAndBilledBatteryCoverQtyInBox(Me.txtShipBoxName.Text.Trim)

                ' EXIT IF THE BOX IS NOT FOUND.
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("The entered Box Number cannot be found.  Please try again.", "Box not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtShipBoxName.Text = ""
                    Exit Sub
                End If

                ' POPULATE AND ENABLE INITIAL CONTROLS.
                Me.cbHasBC.Checked = (dt.Rows(0)("Has BC") = 1)
                SetAssignButtonLabel()
                EnableControls()

                ' VALIDATE THE BOX CRITERIA.
                If Not Me.ValidateBoxCriteria(dt) Then
                    ClearControlsIfInvalid()
                    Me.Enabled = True
                    Me.txtShipBoxName.SelectAll()
                    Me.txtShipBoxName.Focus()
                    Exit Sub
                End If

                ' POPULATE THE REST OF THE CONTROLS.
                If cbHasBC.Checked Then
                    Me._iPalletID = dt.Rows(0)("Pallett_ID")
                    Me.lblBoxQty.Text = dt.Rows(0)("Box Qty")
                    Me.lblOpenQty.Text = CInt(dt.Rows(0)("Box Qty")) - (CInt(dt.Rows(0)("Billed New Qty")) + CInt(dt.Rows(0)("Billed Use Qty")) + CInt(dt.Rows(0)("Billed RV Qty")))
                    Me.lblNewPartMap.Text = dt.Rows(0)("New Part #")
                    Me.lblUsePartMap.Text = dt.Rows(0)("Use Part #")
                    Me.lblRVPartMap.Text = dt.Rows(0)("RV Part #")
                    Me.lblBilledNew.Text = dt.Rows(0)("Billed New Qty")
                    Me.lblBilledUse.Text = dt.Rows(0)("Billed Use Qty")
                    Me.lblBilledRV.Text = dt.Rows(0)("Billed RV Qty")
                    'set default value for adding new qty with open qty
                    Me.txtAddNewQty.Text = Me.lblOpenQty.Text
                    If CInt(Me.lblOpenQty.Text) = 0 Then
                        MessageBox.Show("No open quantiy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me._iPalletID = 0
                        Me.lblBoxQty.Text = "0"
                        Me.lblOpenQty.Text = "0"
                        Me.lblBilledNew.Text = "0"
                        Me.lblBilledUse.Text = "0"
                        Me.lblBilledRV.Text = "0"
                        Me.lblNewPartMap.Text = ""
                        Me.lblUsePartMap.Text = ""
                        Me.lblRVPartMap.Text = ""
                        Me.Enabled = True
                        Me.txtShipBoxName.Focus()
                        Me.txtShipBoxName.SelectAll()
                        Exit Sub
                    Else
                        Me.Enabled = True
                        txtAddNewQty.SelectAll()
                        txtAddNewQty.Focus()
                    End If
                Else
                    Me._iPalletID = dt.Rows(0)("Pallett_ID")
                    Me.lblBoxQty.Text = dt.Rows(0)("Box Qty")
                    Me.lblOpenQty.Text = 0
                    Me.Enabled = True
                    btnAddBattery.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtShipBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not Me.Enabled Then
                    Me.Enabled = True
                End If
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Protected Function MoveBoxToWH_RB() As Boolean
            Dim dtBoxData2 As DataTable
            Dim strNextStation As String = ""
            Dim strWH_RBStageName As String = "To WH-RB"
            Dim _movedToWHRB As Boolean
            Dim i As Integer

            ' MOVE TO NEXT STAGE WH-RB.

            dtBoxData2 = Me._objTFMisc.GetShipBoxStationCount(Me.txtShipBoxName.Text.Trim)

            If dtBoxData2.Rows.Count = 0 Then
                MessageBox.Show("This Box ID does not exist after battery cover assigned. See IT.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf dtBoxData2.Rows.Count > 1 Then
                MessageBox.Show("Box has multiple workstation after battery cover assigned.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf dtBoxData2.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                MessageBox.Show("This Box does not belong to any workstation after battery cover assigned.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(strWH_RBStageName, dtBoxData2.Rows(0)("WorkStation").ToString.Trim, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                _movedToWHRB = False
            ElseIf Not Me._iPalletID = dtBoxData2.Rows(0)("Pallett_ID") Then
                MessageBox.Show("Pallet ID does not match after battery cover assigned.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ElseIf IsDBNull(dtBoxData2.Rows(0)("Pallett_ShipDate")) Then
                MessageBox.Show("This Box has not completed at production line after battery cover assigned.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                strNextStation = Generic.GetNextWorkStationInWFP(strWH_RBStageName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                If strNextStation.Trim.Length = 0 Then
                    MessageBox.Show("Workstation is missing in work flow after battery cover assigned. See IT.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    i = Me._objTFMisc.PushShipBoxToNextStation(Me._iPalletID, strNextStation, Core.ApplicationUser.IDuser, strWH_RBStageName, Me.Name)
                    If Not i > 0 Then
                        MessageBox.Show("Failed to move to WH_RB after battery cover assigned. See IT.", "Move to WH-RB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        _movedToWHRB = True
                    End If
                End If
            End If
            Return _movedToWHRB
        End Function
        Protected Function BillForBatteryCovers(ByVal iInvoiceYrMonth As Integer) As Boolean
            Dim dtBoxData As DataTable
            Dim dtDeviceIDs As DataTable
            Dim objDevice As Rules.Device
            Dim iBilledCnt As Integer
            Dim i As Integer
            Dim R1 As DataRow
            Dim _bcAssigned As Boolean
            Try
                If Me.txtAddNewQty.Text.Trim.Length = 0 Then Me.txtAddNewQty.Text = "0"
                If Me.txtAddUseQty.Text.Trim.Length = 0 Then Me.txtAddUseQty.Text = "0"
                If Me.txtAddRVQty.Text.Trim.Length = 0 Then Me.txtAddRVQty.Text = "0"

                ' HAS BATTERY COVER QTYs BEEN ENTERED.
                If txtAddNewQty.Text.Trim = "0" AndAlso txtAddUseQty.Text.Trim = "0" AndAlso txtAddRVQty.Text.Trim = "0" Then
                    MessageBox.Show("Please enter battery cover quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ClearAssignBCControls(False)
                    Me.Enabled = True
                    Me.txtAddNewQty.SelectAll()
                    Me.txtAddNewQty.Focus()
                    Return False
                End If

                ' GET OPEN AND BILLED BATTERY COVER QTY IN BOX.
                dtBoxData = Me._objTFMisc.GetOpenAndBilledBatteryCoverQtyInBox(Me.txtShipBoxName.Text.Trim)

                ' VALIDATE BOX CRITERIA FOR MODELS WITH BATTERY COVERS.
                If Me.ValidateBoxCriteria(dtBoxData) = True Then
                    dtDeviceIDs = Me._objTFMisc.GetNoneBatteryBilledDeviceID(Me._iPalletID)
                    If Me.lblOpenQty.Text.Trim.Length = 0 Then
                        MessageBox.Show("Available quantity to add is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    ElseIf Me.txtAddNewQty.Text.Trim = "0" AndAlso Me.txtAddUseQty.Text.Trim = "0" AndAlso Me.txtAddRVQty.Text.Trim = "0" Then
                        MessageBox.Show("Please enter battery cover quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True
                        Me.txtAddNewQty.SelectAll()
                        Me.txtAddNewQty.Focus()
                        Exit Function
                    ElseIf CInt(Me.lblOpenQty.Text) < (CInt(Me.txtAddNewQty.Text) + CInt(Me.txtAddUseQty.Text) + CInt(Me.txtAddRVQty.Text)) Then
                        MessageBox.Show("You have exceeded the open quantity " & Me.lblOpenQty.Text & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True
                        Me.txtAddNewQty.SelectAll()
                        Me.txtAddNewQty.Focus()
                        Exit Function
                    ElseIf dtDeviceIDs.Rows.Count < CInt(Me.lblOpenQty.Text) Or dtDeviceIDs.Rows.Count < (CInt(Me.txtAddNewQty.Text) + CInt(Me.txtAddUseQty.Text)) Then
                        MessageBox.Show("You have exceeded the open quantity " & Me.lblOpenQty.Text & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True
                        Me.txtAddNewQty.SelectAll()
                        Me.txtAddNewQty.Focus()
                        Exit Function
                    End If
                Else
                    ClearAssignBCControls(False)
                    Return False
                End If

                ' APPLY BILLING FOR THE NEW BATTERY COVERS IF NEEDED.
                If CInt(Me.txtAddNewQty.Text) > 0 Then
                    For i = 0 To dtDeviceIDs.Rows.Count - 1
                        If iBilledCnt >= CInt(Me.txtAddNewQty.Text) Then Exit For
                        R1 = dtDeviceIDs.Rows(i)
                        If Generic.IsBillcodeMapped(R1("Model_ID"), iNewBatCoverBillcodeID) = 0 Then Throw New Exception("New battery cover does not map. Please contact Material department.")
                        If Generic.IsBillcodeExisted(R1("Device_ID"), iNewBatCoverBillcodeID) = False Then
                            objDevice = New Rules.Device(R1("Device_ID"))
                            objDevice.AddPart(iNewBatCoverBillcodeID)
                            objDevice.Update(iInvoiceYrMonth)
                            _bcAssigned = True
                            iBilledCnt += 1
                        End If
                    Next i
                End If

                ' APPLY BILLING FOR THE USED BATTERY COVERS IF NEEDED.
                iBilledCnt = 0
                If CInt(Me.txtAddUseQty.Text) > 0 Then
                    For i = i To dtDeviceIDs.Rows.Count - 1
                        If iBilledCnt >= CInt(Me.txtAddUseQty.Text) Then Exit For
                        R1 = dtDeviceIDs.Rows(i)
                        If Generic.IsBillcodeMapped(R1("Model_ID"), iUsedBatCoverBillcodeID) = 0 Then Throw New Exception("Use battery cover does not map. Please contact Material department.")
                        If Generic.IsBillcodeExisted(R1("Device_ID"), iUsedBatCoverBillcodeID) = False Then
                            objDevice = New Rules.Device(R1("Device_ID"))
                            objDevice.AddPart(iUsedBatCoverBillcodeID)
                            objDevice.Update(iInvoiceYrMonth)
                            _bcAssigned = True
                            iBilledCnt += 1
                        End If
                    Next i
                End If

                ' APPLY BILLING FOR THE RV BATTERY COVERS IF NEEDED.
                iBilledCnt = 0
                If CInt(Me.txtAddRVQty.Text) > 0 Then
                    For i = i To dtDeviceIDs.Rows.Count - 1
                        If iBilledCnt >= CInt(Me.txtAddRVQty.Text) Then Exit For

                        R1 = dtDeviceIDs.Rows(i)
                        If Generic.IsBillcodeMapped(R1("Model_ID"), iRVBatCoverBillcodeID) = 0 Then Throw New Exception("RV battery cover does not map. Please contact Material department.")
                        If Generic.IsBillcodeExisted(R1("Device_ID"), iRVBatCoverBillcodeID) = False Then
                            objDevice = New Rules.Device(R1("Device_ID"))
                            objDevice.AddPart(iRVBatCoverBillcodeID)
                            objDevice.Update(iInvoiceYrMonth)
                            _bcAssigned = True
                            iBilledCnt += 1
                        End If
                    Next i
                End If
                Return _bcAssigned

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddBattery_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
            End Try
        End Function
#End Region
    End Class
End Namespace
