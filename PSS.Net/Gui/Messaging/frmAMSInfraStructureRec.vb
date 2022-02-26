Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmAMSInfraStructureRec
    Inherits System.Windows.Forms.Form

    Private _objAMSInfraStructure As AMSInfraStructure
    Private _iLocID As Integer = 0
    Private _iWOID As Integer = 0
    Private _iTrayID As Integer = 0
    Private _iCameWithFile As Integer = 0
    Private _booDiscrepancy As Boolean
    Private _iMenuCustID As Integer = 0
    Private _strTabPageTitle As String
    Private _iDefaultDataDays As Integer = 30

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String, ByVal iCustID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _strTabPageTitle = strTabPageTitle
        _iMenuCustID = iCustID
        _objAMSInfraStructure = New AMSInfraStructure()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objAMSInfraStructure = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTask As System.Windows.Forms.Label
    Friend WithEvents dbgDiscUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCloseWO As System.Windows.Forms.Button
    Friend WithEvents pnlDiscrep As System.Windows.Forms.Panel
    Friend WithEvents lblDuplicateSN As System.Windows.Forms.Label
    Friend WithEvents lblMissingSN As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnViewDiscUnits As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents lblScanQtyVal As System.Windows.Forms.Label
    Friend WithEvents lblFileQtyVal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFileQtyLabel As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblManufSN As System.Windows.Forms.Label
    Friend WithEvents txtManufSN As System.Windows.Forms.TextBox
    Friend WithEvents chkManufSN As System.Windows.Forms.CheckBox
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dbgRecData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnViewRecvdUnits As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAMSInfraStructureRec))
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.dbgDiscUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCloseWO = New System.Windows.Forms.Button()
        Me.pnlDiscrep = New System.Windows.Forms.Panel()
        Me.lblDuplicateSN = New System.Windows.Forms.Label()
        Me.lblMissingSN = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnViewDiscUnits = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.lblScanQtyVal = New System.Windows.Forms.Label()
        Me.lblFileQtyVal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFileQtyLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblLoc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblManufSN = New System.Windows.Forms.Label()
        Me.txtManufSN = New System.Windows.Forms.TextBox()
        Me.chkManufSN = New System.Windows.Forms.CheckBox()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlData = New System.Windows.Forms.Panel()
        Me.dbgRecData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnViewRecvdUnits = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dbgDiscUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDiscrep.SuspendLayout()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlData.SuspendLayout()
        CType(Me.dbgRecData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRMA
        '
        Me.txtRMA.Location = New System.Drawing.Point(108, 32)
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(256, 20)
        Me.txtRMA.TabIndex = 38
        Me.txtRMA.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "RMA/WO: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTask
        '
        Me.lblTask.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(488, 24)
        Me.lblTask.TabIndex = 66
        Me.lblTask.Text = "Task Label"
        '
        'dbgDiscUnits
        '
        Me.dbgDiscUnits.AllowUpdate = False
        Me.dbgDiscUnits.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgDiscUnits.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgDiscUnits.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgDiscUnits.Location = New System.Drawing.Point(612, 16)
        Me.dbgDiscUnits.Name = "dbgDiscUnits"
        Me.dbgDiscUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgDiscUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgDiscUnits.PreviewInfo.ZoomFactor = 75
        Me.dbgDiscUnits.Size = New System.Drawing.Size(280, 168)
        Me.dbgDiscUnits.TabIndex = 64
        Me.dbgDiscUnits.Text = "C1TrueDBGrid1"
        Me.dbgDiscUnits.Visible = False
        Me.dbgDiscUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
        "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
        "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
        "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
        "=""1""><Height>164</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
        "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
        "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
        """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
        "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
        "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
        " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
        "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
        ", 0, 276, 164</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
        "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
        "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
        "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
        "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
        "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
        "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
        "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
        "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
        "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 276, 164</" & _
        "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
        "parent="""" me=""Style15"" /></Blob>"
        '
        'btnCloseWO
        '
        Me.btnCloseWO.BackColor = System.Drawing.Color.Green
        Me.btnCloseWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseWO.ForeColor = System.Drawing.Color.White
        Me.btnCloseWO.Location = New System.Drawing.Point(376, 152)
        Me.btnCloseWO.Name = "btnCloseWO"
        Me.btnCloseWO.Size = New System.Drawing.Size(72, 20)
        Me.btnCloseWO.TabIndex = 63
        Me.btnCloseWO.Text = "Close WO"
        '
        'pnlDiscrep
        '
        Me.pnlDiscrep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDiscrep.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDuplicateSN, Me.lblMissingSN, Me.Label13, Me.Label14})
        Me.pnlDiscrep.Location = New System.Drawing.Point(380, 88)
        Me.pnlDiscrep.Name = "pnlDiscrep"
        Me.pnlDiscrep.Size = New System.Drawing.Size(224, 56)
        Me.pnlDiscrep.TabIndex = 62
        Me.pnlDiscrep.Visible = False
        '
        'lblDuplicateSN
        '
        Me.lblDuplicateSN.ForeColor = System.Drawing.Color.Blue
        Me.lblDuplicateSN.Location = New System.Drawing.Point(152, 32)
        Me.lblDuplicateSN.Name = "lblDuplicateSN"
        Me.lblDuplicateSN.Size = New System.Drawing.Size(48, 16)
        Me.lblDuplicateSN.TabIndex = 18
        Me.lblDuplicateSN.Text = "0"
        Me.lblDuplicateSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMissingSN
        '
        Me.lblMissingSN.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingSN.Location = New System.Drawing.Point(152, 8)
        Me.lblMissingSN.Name = "lblMissingSN"
        Me.lblMissingSN.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingSN.TabIndex = 17
        Me.lblMissingSN.Text = "0"
        Me.lblMissingSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(24, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Duplicate S/N:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(24, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Missing S/N:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SlateGray
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(472, 152)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(40, 32)
        Me.btnClear.TabIndex = 61
        Me.btnClear.Text = "Clear"
        '
        'btnViewDiscUnits
        '
        Me.btnViewDiscUnits.BackColor = System.Drawing.Color.SteelBlue
        Me.btnViewDiscUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewDiscUnits.ForeColor = System.Drawing.Color.White
        Me.btnViewDiscUnits.Location = New System.Drawing.Point(640, 192)
        Me.btnViewDiscUnits.Name = "btnViewDiscUnits"
        Me.btnViewDiscUnits.Size = New System.Drawing.Size(144, 20)
        Me.btnViewDiscUnits.TabIndex = 45
        Me.btnViewDiscUnits.Text = "View Discrepancy Units"
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.Green
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.White
        Me.btnGo.Location = New System.Drawing.Point(280, 184)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(80, 24)
        Me.btnGo.TabIndex = 44
        Me.btnGo.Text = "Save"
        '
        'lblScanQtyVal
        '
        Me.lblScanQtyVal.BackColor = System.Drawing.Color.SteelBlue
        Me.lblScanQtyVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanQtyVal.ForeColor = System.Drawing.Color.White
        Me.lblScanQtyVal.Location = New System.Drawing.Point(524, 64)
        Me.lblScanQtyVal.Name = "lblScanQtyVal"
        Me.lblScanQtyVal.Size = New System.Drawing.Size(80, 24)
        Me.lblScanQtyVal.TabIndex = 59
        Me.lblScanQtyVal.Text = "0"
        Me.lblScanQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFileQtyVal
        '
        Me.lblFileQtyVal.BackColor = System.Drawing.Color.SteelBlue
        Me.lblFileQtyVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileQtyVal.ForeColor = System.Drawing.Color.White
        Me.lblFileQtyVal.Location = New System.Drawing.Point(524, 40)
        Me.lblFileQtyVal.Name = "lblFileQtyVal"
        Me.lblFileQtyVal.Size = New System.Drawing.Size(80, 24)
        Me.lblFileQtyVal.TabIndex = 58
        Me.lblFileQtyVal.Text = "0"
        Me.lblFileQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(380, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 24)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Received Qty:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFileQtyLabel
        '
        Me.lblFileQtyLabel.BackColor = System.Drawing.Color.SteelBlue
        Me.lblFileQtyLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileQtyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileQtyLabel.ForeColor = System.Drawing.Color.White
        Me.lblFileQtyLabel.Location = New System.Drawing.Point(380, 40)
        Me.lblFileQtyLabel.Name = "lblFileQtyLabel"
        Me.lblFileQtyLabel.Size = New System.Drawing.Size(144, 24)
        Me.lblFileQtyLabel.TabIndex = 56
        Me.lblFileQtyLabel.Text = "File Qty:"
        Me.lblFileQtyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "S/N: "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(108, 184)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(168, 20)
        Me.txtSN.TabIndex = 44
        Me.txtSN.Text = ""
        '
        'lblPO
        '
        Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPO.ForeColor = System.Drawing.Color.Blue
        Me.lblPO.Location = New System.Drawing.Point(108, 88)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(256, 16)
        Me.lblPO.TabIndex = 52
        Me.lblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "PO#:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLoc
        '
        Me.lblLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoc.ForeColor = System.Drawing.Color.Blue
        Me.lblLoc.Location = New System.Drawing.Point(108, 56)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(256, 17)
        Me.lblLoc.TabIndex = 50
        Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Cust-Loc:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblManufSN
        '
        Me.lblManufSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManufSN.Location = New System.Drawing.Point(32, 160)
        Me.lblManufSN.Name = "lblManufSN"
        Me.lblManufSN.Size = New System.Drawing.Size(72, 16)
        Me.lblManufSN.TabIndex = 68
        Me.lblManufSN.Text = "Manuf SN : "
        Me.lblManufSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtManufSN
        '
        Me.txtManufSN.Location = New System.Drawing.Point(108, 160)
        Me.txtManufSN.Name = "txtManufSN"
        Me.txtManufSN.Size = New System.Drawing.Size(252, 20)
        Me.txtManufSN.TabIndex = 43
        Me.txtManufSN.Text = ""
        '
        'chkManufSN
        '
        Me.chkManufSN.Location = New System.Drawing.Point(108, 144)
        Me.chkManufSN.Name = "chkManufSN"
        Me.chkManufSN.Size = New System.Drawing.Size(84, 16)
        Me.chkManufSN.TabIndex = 42
        Me.chkManufSN.Text = "Create SN"
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(108, 112)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(256, 21)
        Me.cboModels.TabIndex = 39
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Model:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlData
        '
        Me.pnlData.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.dbgRecData, Me.dtpEndDate, Me.dtpStartDate, Me.btnViewRecvdUnits, Me.Label5, Me.Label9})
        Me.pnlData.Location = New System.Drawing.Point(8, 240)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(888, 320)
        Me.pnlData.TabIndex = 74
        '
        'dbgRecData
        '
        Me.dbgRecData.AllowUpdate = False
        Me.dbgRecData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgRecData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgRecData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.dbgRecData.Location = New System.Drawing.Point(8, 32)
        Me.dbgRecData.Name = "dbgRecData"
        Me.dbgRecData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgRecData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgRecData.PreviewInfo.ZoomFactor = 75
        Me.dbgRecData.Size = New System.Drawing.Size(888, 320)
        Me.dbgRecData.TabIndex = 74
        Me.dbgRecData.Text = "C1TrueDBGrid1"
        Me.dbgRecData.Visible = False
        Me.dbgRecData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
        "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
        "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
        "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
        "=""1""><Height>316</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
        "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
        "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
        """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
        "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
        "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
        " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
        "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
        ", 0, 884, 316</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
        "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
        "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
        "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
        "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
        "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
        "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
        "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
        "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
        "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 884, 316</" & _
        "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
        "parent="""" me=""Style15"" /></Blob>"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(480, 16)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpEndDate.TabIndex = 78
        Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(360, 16)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpStartDate.TabIndex = 77
        Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(250, 16)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Mouse Down to Export/Print Data"
        '
        'btnViewRecvdUnits
        '
        Me.btnViewRecvdUnits.BackColor = System.Drawing.Color.SteelBlue
        Me.btnViewRecvdUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewRecvdUnits.ForeColor = System.Drawing.Color.White
        Me.btnViewRecvdUnits.Location = New System.Drawing.Point(272, 8)
        Me.btnViewRecvdUnits.Name = "btnViewRecvdUnits"
        Me.btnViewRecvdUnits.Size = New System.Drawing.Size(80, 24)
        Me.btnViewRecvdUnits.TabIndex = 75
        Me.btnViewRecvdUnits.Text = "Refresh"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(360, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Start"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(480, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "End"
        '
        'frmAMSInfraStructureRec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(904, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlData, Me.chkManufSN, Me.lblManufSN, Me.txtManufSN, Me.txtRMA, Me.Label3, Me.lblTask, Me.dbgDiscUnits, Me.btnCloseWO, Me.pnlDiscrep, Me.btnClear, Me.btnViewDiscUnits, Me.btnGo, Me.lblScanQtyVal, Me.lblFileQtyVal, Me.Label8, Me.lblFileQtyLabel, Me.Label7, Me.txtSN, Me.cboModels, Me.Label1, Me.lblPO, Me.Label6, Me.lblLoc, Me.Label2})
        Me.Name = "frmAMSInfraStructureRec"
        Me.Text = "frmAMSInfraStructureRec"
        CType(Me.dbgDiscUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDiscrep.ResumeLayout(False)
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlData.ResumeLayout(False)
        CType(Me.dbgRecData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    Private Sub frmAMSInfraStructureRec_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.btnClear.Visible = False : Me.btnCloseWO.Visible = False
            Me.pnlData.Visible = False

            Me.btnViewDiscUnits.Visible = False ' : Me.btnViewRecvdUnits.Visible = False

            Me.chkManufSN.Checked = True : Me.chkManufSN.Checked = False

            Me.lblTask.Text = _strTabPageTitle
            Me.lblTask.Width = Me.Width

            Me.dtpStartDate.Value = Format(DateAdd(DateInterval.Day, -Me._iDefaultDataDays, Now), "yyyy-MM-dd")
            Me.dtpEndDate.Value = Format(Now, "yyyy-MM-dd")

            'Tom Brown requested WO as "AMSINE", never close it
            Me.txtRMA.Text = "AMSINE"

            Me.txtRMA.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub ClearContrlsAndVars()
        Me.txtRMA.Enabled = True
        Me.txtRMA.Text = ""
        Me.lblLoc.Text = ""
        Me.lblPO.Text = "N/A"
        Me.cboModels.Text = ""
        Me.cboModels.DataSource = Nothing
        Me.txtSN.Text = ""
        Me.lblFileQtyVal.Text = 0
        Me.lblScanQtyVal.Text = 0
        Me.dbgRecData.DataSource = Nothing
        Me.dbgRecData.Visible = False
        Me.pnlDiscrep.Visible = False
        Me.lblDuplicateSN.Text = "0"
        Me.lblMissingSN.Text = "0"
        Me.dbgDiscUnits.DataSource = Nothing
        Me.dbgDiscUnits.Visible = False
        Me.txtManufSN.Text = ""

        'Global Varialble
        Me._iLocID = 0
        Me._iTrayID = 0
        Me._iWOID = 0
        Me._iCameWithFile = 0
        Me._booDiscrepancy = False
    End Sub

    '********************************************************************
    Private Sub txtRMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRMA.KeyPress
        If e.KeyChar.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    '********************************************************************
    Private Sub txtRMA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRMA.KeyUp
        Dim dt, dtModels, dtFileData As DataTable
        Dim strRMA As String = ""
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtRMA.Text.Trim.Length = 0 Then Exit Sub

                strRMA = Me.txtRMA.Text.Trim.ToString

                '************************************
                'clear controls and global variables
                '************************************
                Me.ClearContrlsAndVars()
                Me.pnlDiscrep.Visible = False
                Me.lblDuplicateSN.Text = "0"
                Me.lblMissingSN.Text = "0"
                '************************************
                Me.txtRMA.Text = strRMA
                'MessageBox.Show("_iMenuCustID=" & _iMenuCustID & "   strRMA=" & strRMA)
                dt = Me._objAMSInfraStructure.GetRMA_WO(_iMenuCustID, strRMA)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("RMA/WO does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll()
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Found duplicate RMA/WO in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll()
                ElseIf dt.Rows(0)("WO_Closed") = 1 Then
                    MessageBox.Show("RMA/WO is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll()
                Else
                    _iTrayID = Generic.GetTrayID(dt.Rows(0)("WO_ID"))
                    If Me._iTrayID = 0 Then
                        MessageBox.Show("Tray ID is missing for this RMA. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtRMA.SelectAll()
                    Else
                        Me.txtRMA.Enabled = False
                        Me.lblLoc.Text = dt.Rows(0)("Cust_Name1") & "-" & dt.Rows(0)("Loc_Name")
                        If IsDBNull(dt.Rows(0)("PO_ID")) OrElse dt.Rows(0)("PO_ID") = 0 Then Me.lblPO.Text = "N/A" Else Me.lblPO.Text = dt.Rows(0)("PO_ID")
                        Me.lblFileQtyVal.Text = dt.Rows(0)("WO_Quantity")
                        'Me.lblScanQtyVal.Text = Generic.GetRecQty(dt.Rows(0)("WO_ID"))
                        Me.lblScanQtyVal.Text = Generic.GetRecQty(dt.Rows(0)("WO_ID"))
                        Me._iLocID = dt.Rows(0)("Loc_ID")
                        Me._iWOID = dt.Rows(0)("WO_ID")
                        Me._iCameWithFile = dt.Rows(0)("WO_CameWithFile")

                        'populate data
                        Me.PopulateRecData()

                        'Populate AMS infrastructure models
                        dtModels = Me._objAMSInfraStructure.GetAMSINE_Models(Me._objAMSInfraStructure.AMSInfraStructure_REPORTGROUP_GROUPID)
                        Misc.PopulateC1DropDownList(Me.cboModels, dtModels, "Model_desc", "Model_id")
                        Me.cboModels.SelectedValue = 0
                        Me.cboModels.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtRMA_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dtFileData)
        End Try
    End Sub

    '***************************************************************
    Private Sub PopulateRecData()
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim styYes As C1.Win.C1TrueDBGrid.Style
        Dim fntYes As Font
        Dim drArrDiscUnit() As DataRow
        Dim strDateEnd As String = "", strDateStart As String = ""

        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
            Else
                strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
            End If

            dt = Me._objAMSInfraStructure.GetDevRcvdByWO(Me._iWOID, Me.txtRMA.Text.Trim, strDateStart, strDateEnd)

            With Me.dbgRecData
                .DataSource = dt.DefaultView
                .Visible = True
                .AllowFilter = True
                .FilterBar = True


                styYes = New C1.Win.C1TrueDBGrid.Style()
                fntYes = New Font(styYes.Font, FontStyle.Bold)
                styYes.Font = fntYes
                styYes.ForeColor = Color.Red
                .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "YES")

                For i = 0 To dt.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                    .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                    'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                    If dt.Columns(i).Caption = "SN" Then
                        .Splits(0).DisplayColumns(i).Frozen = True
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    ElseIf dt.Columns(i).Caption = "Rcvg Date" Then
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        'ElseIf dt.Columns(i).Caption = "Capcode" Then
                        '    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    ElseIf dt.Columns(i).Caption = "Baud Rate" Then
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    Else
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End If

                    If dt.Columns(i).Caption = "SN" Or dt.Columns(i).Caption = "Manuf SN" Then
                        .Splits(0).DisplayColumns(i).Width = 120
                    Else
                        .Splits(0).DisplayColumns(i).Width = 75
                    End If

                    Me.pnlData.Visible = True
                    'If dt.Columns(i).Caption = "No SN" Or dt.Columns(i).Caption = "Dupl SN" Or dt.Columns(i).Caption = "No Baud" Or dt.Columns(i).Caption = "Dupl Cap" Or dt.Columns(i).Caption = "No Freq" Then
                    '    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "YES")
                    'End If
                Next i

                If Me._iCameWithFile = 1 Then
                    '***********************************
                    'Discrepancy 
                    '***********************************
                    Me.pnlDiscrep.Visible = True
                    Me.lblDuplicateSN.Text = dt.Select("[Dupl SN] = 'YES'").Length
                    Me.lblMissingSN.Text = dt.Select("[No SN] = 'YES'").Length

                    drArrDiscUnit = dt.Select("[Dupl SN] = 'YES' OR [No SN] = 'YES' OR [No Baud] = 'YES' OR [No Cap] = 'YES' OR [No Freq] = 'YES' ", "")

                    For i = 0 To drArrDiscUnit.Length - 1
                        .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, drArrDiscUnit(i)("SN"))
                    Next i
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************
    Private Sub chkManufSN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkManufSN.CheckedChanged
        Try
            Me.chkManufSN.Visible = True

            With Me.chkManufSN
                If .Checked Then
                    .ForeColor = Color.Blue
                    Me.lblManufSN.Visible = True
                    Me.txtManufSN.Visible = True
                    Me.txtManufSN.Focus()
                    Me.txtSN.ReadOnly = True
                Else
                    .ForeColor = Color.Black
                    Me.txtManufSN.Text = ""
                    Me.lblManufSN.Visible = False
                    Me.txtManufSN.Visible = False
                    Me.txtSN.ReadOnly = False
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chkManufSN_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    '********************************************************************
    Private Sub txtManufSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtManufSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.ProcessSN()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtManufSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessSN()
        Dim i As Integer = 0
        Dim dtFileData As DataTable
        Dim R1 As DataRow
        ' Dim iSDID As Integer = 0
        Dim strPreSN As String = "", strDate As String = Format(Now, "MMddyy")
        Dim strNo As String = ""
        Dim strErrMsg As String = ""

        Try
            If Me.txtRMA.Text.Trim.Length = 0 Or Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO and press enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                Exit Sub
            End If

            If IsNothing(Me.cboModels.DataSource) = True OrElse Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select a model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModels.Focus() : Exit Sub
            End If

            If Me.chkManufSN.Checked Then
                If Me.txtManufSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter a manufacture SN", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                    Exit Sub
                End If
                strPreSN = Me.cboModels.DataSource.Table.Select("Model_ID =" & Me.cboModels.SelectedValue)(0)("Model_MotoSku")
                strNo = Me._objAMSInfraStructure.GetLastSerialNumber(Me._iLocID, strPreSN, Format(Now, "yyyy-MM-dd"))
                Me.txtSN.Text = strPreSN.Trim & strDate & strNo

            End If

            If Me.txtSN.Text.Trim.Length = 0 Then
                If Me.chkManufSN.Checked Then
                    MessageBox.Show("No SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Please enter a SN and press enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If
            Else
                ''******************************
                ''Get File data and check for discrepancy
                ''******************************
                'If Me._iCameWithFile = 1 Then
                '    dtFileData = Me._objSkyTel.GetFileData(Me.txtRMA.Text.Trim, Me.txtSN.Text.Trim)

                '    If dtFileData.Rows.Count = 0 Then
                '        MessageBox.Show("S/N is not listed in the file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Me.txtSN.SelectAll()
                '        Me.txtSN.Focus()
                '        Exit Sub
                '    ElseIf dtFileData.Rows(0)("sd_BlankSN") > 0 Or dtFileData.Rows(0)("sd_DuplSN") > 0 Or dtFileData.Rows(0)("sd_NoBaud") > 0 Or dtFileData.Rows(0)("sd_NoCapcode") > 0 Or dtFileData.Rows(0)("sd_NoFreq") > 0 Then
                '        MessageBox.Show("S/N is an discrepancy. You are not allow to receive any discrepant units.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Me.txtSN.SelectAll()
                '        Me.txtSN.Focus()
                '        Exit Sub
                '    ElseIf Not IsDBNull(dtFileData.Rows(0)("Device_ID")) AndAlso dtFileData.Rows(0)("Device_ID") > 0 Then
                '        MessageBox.Show("S/N has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Me.txtSN.SelectAll()
                '        Me.txtSN.Focus()
                '        Exit Sub
                '    Else
                '        Me.cboBauds.SelectedValue = dtFileData.Rows(0)("baud_id")
                '        Me.cboFreqs.SelectedValue = dtFileData.Rows(0)("freq_id")
                '        Me.txtCap.Text = dtFileData.Rows(0)("sd_CapCode")
                '        iSDID = dtFileData.Rows(0)("sd_id")
                '        Application.DoEvents()
                '    End If
                'End If
                ''******************************


                '**************************
                'check duplicate (open WIP)
                '**************************
                If Generic.IsSNInWIP(_iMenuCustID, Me.txtSN.Text.Trim.ToUpper) = True Then
                    MessageBox.Show("S/N is existed in WIP." & Environment.NewLine & "S/N format can only be leter or number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll()
                    Me.txtSN.Focus()
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = 0 : strErrMsg = ""
                i = Me._objAMSInfraStructure.ReceiveDevice(Me._iLocID, Me.txtRMA.Text.Trim.ToUpper, Me._iWOID, Me._iTrayID, _
                                                           Me.cboModels.SelectedValue, Me.txtManufSN.Text.Trim, _
                                                        Me.txtSN.Text.Trim.ToUpper, PSS.Core.ApplicationUser.IDShift, _
                                                           PSS.Core.ApplicationUser.IDuser, strErrMsg)

                If i > 0 And strErrMsg.Trim.Length = 0 Then
                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    Me.lblScanQtyVal.Text = Generic.GetRecQty(Me._iWOID)
                    Me.txtSN.Text = "" : Me.txtManufSN.Text = ""
                    If Me.chkManufSN.Checked Then
                        Me.txtManufSN.Focus()
                    Else
                        Me.txtSN.Focus()
                    End If
                Else
                    MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If Me.chkManufSN.Checked Then
                        Me.txtManufSN.Focus()
                    Else
                        Me.txtSN.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            If Me._iCameWithFile = 1 Then Me.txtSN.Text = ""
            Throw ex
        Finally
            Generic.DisposeDT(dtFileData)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            Me.ProcessSN()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
        Dim i As Integer = 0
        Dim dtWo As DataTable

        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.Focus()
            Else
                If CInt(Me.lblFileQtyVal.Text) <> CInt(Me.lblScanQtyVal.Text) Then
                    If MessageBox.Show("There is discrepancy in quantity(" & Me.lblFileQtyLabel.Text & " vs " & Me.lblScanQtyVal.Text & "). Would you like to proceed?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Me.txtSN.Focus()
                        Exit Sub
                    End If
                End If

                dtWo = Me._objAMSInfraStructure.GetRMA_WO(_iMenuCustID, Me.txtRMA.Text.Trim)

                If MessageBox.Show("Are you sure you want to close this WO?", "Informtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

                i = Generic.CloseWO(Me._iWOID)
                Me.ClearContrlsAndVars()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dtWo)
            Me.txtRMA.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            Me.ClearContrlsAndVars()
            Me.txtRMA.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '********************************************************************
    Private Sub btnViewRecvdUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRecvdUnits.Click
        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.Focus()
            Else
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                Me.PopulateRecData()
                Application.DoEvents()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnViewRecvdUnits_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub dbgRecData_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgRecData.MouseDown
        Try
            Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

            If dbg.RowCount = 0 Then Return

            If e.Button = MouseButtons.Right Then
                Dim ctmCopyData As New ContextMenu()
                Dim objCopyAll As New MenuItem()
                Dim objCopySelected As New MenuItem()
                Dim objPrintAll As New MenuItem()
                Dim objPrintSelected As New MenuItem()


                objCopyAll.Text = "Copy all"
                objCopySelected.Text = "Copy selected rows"
                objPrintAll.Text = "Print all"
                objPrintSelected.Text = "Print selected rows"

                ctmCopyData.MenuItems.Add(objCopyAll)
                ctmCopyData.MenuItems.Add(objCopySelected)
                ctmCopyData.MenuItems.Add("-")
                ctmCopyData.MenuItems.Add(objPrintAll)
                ctmCopyData.MenuItems.Add(objPrintSelected)

                RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                RemoveHandler objPrintAll.Click, AddressOf CMenuPrintAllData
                AddHandler objPrintAll.Click, AddressOf CMenuPrintAllData
                RemoveHandler objPrintSelected.Click, AddressOf CMenuPrintSelectedData
                AddHandler objPrintSelected.Click, AddressOf CMenuPrintSelectedData

                dbg.ContextMenu = ctmCopyData
                dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, " dbgRecData_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Misc.CopyAllData(Me.dbgRecData)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Misc.CopySelectedRowsData(Me.dbgRecData)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub CMenuPrintAllData(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As DataTable
        Try
            dt = Misc.CopyAllDataOfVisibleCols(Me.dbgRecData)
            'Me.dbgDiscUnits.DataSource = dt
            'Me.dbgDiscUnits.Visible = True
            If dt.Rows.Count > 0 Then
                Me._objAMSInfraStructure.Print_ReceivingDataReport(txtRMA.Text, dt, 1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "MenuPrintAllData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub CMenuPrintSelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dt As DataTable
        Try
            dt = Misc.CopySelectedDataOfVisibleCols(Me.dbgRecData)
            'Me.dbgDiscUnits.DataSource = dt
            'Me.dbgDiscUnits.Visible = True
            If dt.Rows.Count > 0 Then
                Me._objAMSInfraStructure.Print_ReceivingDataReport(txtRMA.Text, dt, 1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CMenuPrintSelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    '********************************************************************

    Private Sub txtRMA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRMA.TextChanged

    End Sub
End Class
