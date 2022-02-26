Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global
Imports C1.Win.C1TrueDBGrid
Imports System.IO

Public Class frmSensusBuildShipPallet
    Inherits System.Windows.Forms.Form

    Private _objSensus As Sensus
    Private _strLineID As String = ""
    Private _booRefreshSNList As Boolean = True
    Private _iSelectedPartNoForWorkingPallet As Integer = 0
    Private _strSelectedPartNoForWorkingPallet As String = ""
    ' Private _SelectedModelForWorkingPallet As Integer = 0 'no need this in fact.

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSensus = New Sensus()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objSensus = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents dbgOpenPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnShipPallet As System.Windows.Forms.Button
    Friend WithEvents btnRemoveUnitFrPallet As System.Windows.Forms.Button
    Friend WithEvents btnDeleteEmptyPallet As System.Windows.Forms.Button
    Friend WithEvents btnReOpenPallet As System.Windows.Forms.Button
    Friend WithEvents dbgRRInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnPrintPalletDetailRpt As System.Windows.Forms.Button
    Friend WithEvents btnReprintPalletLabel As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents lblBoxName As System.Windows.Forms.Label
    Friend WithEvents pnlShipType As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblScreenName As System.Windows.Forms.Label
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents pnlPallets As System.Windows.Forms.Panel
    Friend WithEvents pnlSNs As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpBuildPallet As System.Windows.Forms.TabPage
    Friend WithEvents tpRecAndBuildPallet As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRMANo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tpSearchRecUnit As System.Windows.Forms.TabPage
    Friend WithEvents cboPartNo As C1.Win.C1List.C1Combo
    Friend WithEvents lstRecSN As System.Windows.Forms.ListBox
    Friend WithEvents txtRecSN As System.Windows.Forms.TextBox
    Friend WithEvents cboShipLocation As C1.Win.C1List.C1Combo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlPalletNameQty As System.Windows.Forms.Panel
    Friend WithEvents chkDispose As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSearchCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSearchVal As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dbgSearchData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSensusBuildShipPallet))
        Me.dbgOpenPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.btnShipPallet = New System.Windows.Forms.Button()
        Me.btnRemoveUnitFrPallet = New System.Windows.Forms.Button()
        Me.btnDeleteEmptyPallet = New System.Windows.Forms.Button()
        Me.btnReOpenPallet = New System.Windows.Forms.Button()
        Me.dbgRRInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnPrintPalletDetailRpt = New System.Windows.Forms.Button()
        Me.pnlPallets = New System.Windows.Forms.Panel()
        Me.btnReprintPalletLabel = New System.Windows.Forms.Button()
        Me.pnlSNs = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lblBoxName = New System.Windows.Forms.Label()
        Me.pnlShipType = New System.Windows.Forms.Panel()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpBuildPallet = New System.Windows.Forms.TabPage()
        Me.tpRecAndBuildPallet = New System.Windows.Forms.TabPage()
        Me.chkDispose = New System.Windows.Forms.CheckBox()
        Me.cboShipLocation = New C1.Win.C1List.C1Combo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRecSN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstRecSN = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRMANo = New System.Windows.Forms.TextBox()
        Me.cboPartNo = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpSearchRecUnit = New System.Windows.Forms.TabPage()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
        Me.txtSearchVal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dbgSearchData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlPalletNameQty = New System.Windows.Forms.Panel()
        CType(Me.dbgOpenPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgRRInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPallets.SuspendLayout()
        Me.pnlSNs.SuspendLayout()
        Me.pnlShipType.SuspendLayout()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpBuildPallet.SuspendLayout()
        Me.tpRecAndBuildPallet.SuspendLayout()
        CType(Me.cboShipLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPartNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSearchRecUnit.SuspendLayout()
        CType(Me.dbgSearchData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPalletNameQty.SuspendLayout()
        Me.SuspendLayout()
        '
        'dbgOpenPallets
        '
        Me.dbgOpenPallets.AllowColMove = False
        Me.dbgOpenPallets.AllowColSelect = False
        Me.dbgOpenPallets.AllowFilter = False
        Me.dbgOpenPallets.AllowSort = False
        Me.dbgOpenPallets.AllowUpdate = False
        Me.dbgOpenPallets.AllowUpdateOnBlur = False
        Me.dbgOpenPallets.AlternatingRows = True
        Me.dbgOpenPallets.CollapseColor = System.Drawing.Color.White
        Me.dbgOpenPallets.ExpandColor = System.Drawing.Color.White
        Me.dbgOpenPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgOpenPallets.ForeColor = System.Drawing.Color.Black
        Me.dbgOpenPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgOpenPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgOpenPallets.Location = New System.Drawing.Point(128, 8)
        Me.dbgOpenPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgOpenPallets.Name = "dbgOpenPallets"
        Me.dbgOpenPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgOpenPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgOpenPallets.PreviewInfo.ZoomFactor = 75
        Me.dbgOpenPallets.RowHeight = 30
        Me.dbgOpenPallets.Size = New System.Drawing.Size(376, 168)
        Me.dbgOpenPallets.TabIndex = 3
        Me.dbgOpenPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 12pt, style=Bold;BackColor:Black;}Selected{ForeColor:HighlightText;BackColor:O" & _
        "range;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{}Fo" & _
        "oter{}Caption{AlignHorz:Center;ForeColor:White;}Style9{}Normal{Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:" & _
        "Center;}HighlightRow{ForeColor:HighlightText;BackColor:Yellow;}Style12{}OddRow{F" & _
        "ont:Microsoft Sans Serif, 12pt, style=Bold;BackColor:DarkSlateBlue;}RecordSelect" & _
        "or{AlignImage:Center;ForeColor:White;BackColor:Control;}Style13{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
        "er;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{A" & _
        "lignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}Style1{}</Data></Sty" & _
        "les><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""" & _
        "False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight" & _
        "=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidt" & _
        "h=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><He" & _
        "ight>164</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle paren" & _
        "t=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBar" & _
        "Style parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3""" & _
        " /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""" & _
        "Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle " & _
        "parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Reco" & _
        "rdSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Se" & _
        "lected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 372" & _
        ", 164</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C" & _
        "1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" " & _
        "/><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><S" & _
        "tyle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><St" & _
        "yle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style " & _
        "parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style" & _
        " parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><St" & _
        "yle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Name" & _
        "dStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout" & _
        "><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 372, 164</ClientAr" & _
        "ea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent=""" & _
        """ me=""Style17"" /></Blob>"
        '
        'txtSN
        '
        Me.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN.Location = New System.Drawing.Point(8, 24)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(160, 20)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'lblLocation
        '
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 69.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.White
        Me.lblLocation.Location = New System.Drawing.Point(176, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(664, 104)
        Me.lblLocation.TabIndex = 5
        Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnShipPallet
        '
        Me.btnShipPallet.BackColor = System.Drawing.Color.Green
        Me.btnShipPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShipPallet.ForeColor = System.Drawing.Color.White
        Me.btnShipPallet.Location = New System.Drawing.Point(176, 232)
        Me.btnShipPallet.Name = "btnShipPallet"
        Me.btnShipPallet.Size = New System.Drawing.Size(112, 37)
        Me.btnShipPallet.TabIndex = 3
        Me.btnShipPallet.Text = "CLOSE && SHIP PALLET"
        '
        'btnRemoveUnitFrPallet
        '
        Me.btnRemoveUnitFrPallet.BackColor = System.Drawing.Color.Red
        Me.btnRemoveUnitFrPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveUnitFrPallet.ForeColor = System.Drawing.Color.White
        Me.btnRemoveUnitFrPallet.Location = New System.Drawing.Point(184, 56)
        Me.btnRemoveUnitFrPallet.Name = "btnRemoveUnitFrPallet"
        Me.btnRemoveUnitFrPallet.Size = New System.Drawing.Size(104, 32)
        Me.btnRemoveUnitFrPallet.TabIndex = 4
        Me.btnRemoveUnitFrPallet.Text = "REMOVE ONE SN"
        '
        'btnDeleteEmptyPallet
        '
        Me.btnDeleteEmptyPallet.BackColor = System.Drawing.Color.Red
        Me.btnDeleteEmptyPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteEmptyPallet.ForeColor = System.Drawing.Color.White
        Me.btnDeleteEmptyPallet.Location = New System.Drawing.Point(8, 56)
        Me.btnDeleteEmptyPallet.Name = "btnDeleteEmptyPallet"
        Me.btnDeleteEmptyPallet.Size = New System.Drawing.Size(112, 32)
        Me.btnDeleteEmptyPallet.TabIndex = 6
        Me.btnDeleteEmptyPallet.Text = "DELETE EMPTY PALLET"
        Me.btnDeleteEmptyPallet.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnReOpenPallet
        '
        Me.btnReOpenPallet.BackColor = System.Drawing.Color.Red
        Me.btnReOpenPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReOpenPallet.ForeColor = System.Drawing.Color.White
        Me.btnReOpenPallet.Location = New System.Drawing.Point(8, 8)
        Me.btnReOpenPallet.Name = "btnReOpenPallet"
        Me.btnReOpenPallet.Size = New System.Drawing.Size(112, 32)
        Me.btnReOpenPallet.TabIndex = 5
        Me.btnReOpenPallet.Text = "RE-OPEN PALLET"
        '
        'dbgRRInfo
        '
        Me.dbgRRInfo.AllowColMove = False
        Me.dbgRRInfo.AllowColSelect = False
        Me.dbgRRInfo.AllowFilter = False
        Me.dbgRRInfo.AllowSort = False
        Me.dbgRRInfo.AllowUpdate = False
        Me.dbgRRInfo.AllowUpdateOnBlur = False
        Me.dbgRRInfo.AlternatingRows = True
        Me.dbgRRInfo.CollapseColor = System.Drawing.Color.White
        Me.dbgRRInfo.ExpandColor = System.Drawing.Color.White
        Me.dbgRRInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgRRInfo.ForeColor = System.Drawing.Color.White
        Me.dbgRRInfo.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgRRInfo.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.dbgRRInfo.Location = New System.Drawing.Point(8, 187)
        Me.dbgRRInfo.Name = "dbgRRInfo"
        Me.dbgRRInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgRRInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgRRInfo.PreviewInfo.ZoomFactor = 75
        Me.dbgRRInfo.RowHeight = 17
        Me.dbgRRInfo.Size = New System.Drawing.Size(496, 232)
        Me.dbgRRInfo.TabIndex = 4
        Me.dbgRRInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 9.75pt, style=Bold;ForeColor:Black;BackColor:LightSteelBlue;}Selected{ForeColo" & _
        "r:Black;BackColor:Teal;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCapti" & _
        "on;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:White;}Style1{}Normal{" & _
        "Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Center;ForeColor:White;B" & _
        "ackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Yellow;}" & _
        "Style14{}OddRow{Font:Microsoft Sans Serif, 9.75pt, style=Bold;BackColor:SteelBlu" & _
        "e;}RecordSelector{ForeColor:White;AlignImage:Center;}Style15{}Heading{Wrap:True;" & _
        "Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control" & _
        ";Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{Alig" & _
        "nHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles" & _
        "><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""Fal" & _
        "se"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
        "7"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""" & _
        "17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Heigh" & _
        "t>228</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""" & _
        "Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarSty" & _
        "le parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" />" & _
        "<GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
        "le2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle par" & _
        "ent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordS" & _
        "electorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selec" & _
        "ted"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 492, 2" & _
        "28</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.W" & _
        "in.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><" & _
        "Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Styl" & _
        "e parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style" & _
        " parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSt" & _
        "yles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><D" & _
        "efaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 492, 228</ClientArea>" & _
        "<PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" m" & _
        "e=""Style17"" /></Blob>"
        '
        'btnPrintPalletDetailRpt
        '
        Me.btnPrintPalletDetailRpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPrintPalletDetailRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintPalletDetailRpt.ForeColor = System.Drawing.Color.Black
        Me.btnPrintPalletDetailRpt.Location = New System.Drawing.Point(8, 104)
        Me.btnPrintPalletDetailRpt.Name = "btnPrintPalletDetailRpt"
        Me.btnPrintPalletDetailRpt.Size = New System.Drawing.Size(112, 32)
        Me.btnPrintPalletDetailRpt.TabIndex = 1
        Me.btnPrintPalletDetailRpt.Text = "Print Pallet Detail Report"
        '
        'pnlPallets
        '
        Me.pnlPallets.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlPallets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPallets.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReprintPalletLabel, Me.btnPrintPalletDetailRpt, Me.btnReOpenPallet, Me.btnDeleteEmptyPallet, Me.dbgOpenPallets, Me.dbgRRInfo})
        Me.pnlPallets.Location = New System.Drawing.Point(2, 128)
        Me.pnlPallets.Name = "pnlPallets"
        Me.pnlPallets.Size = New System.Drawing.Size(510, 440)
        Me.pnlPallets.TabIndex = 2
        '
        'btnReprintPalletLabel
        '
        Me.btnReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.btnReprintPalletLabel.Location = New System.Drawing.Point(8, 144)
        Me.btnReprintPalletLabel.Name = "btnReprintPalletLabel"
        Me.btnReprintPalletLabel.Size = New System.Drawing.Size(112, 32)
        Me.btnReprintPalletLabel.TabIndex = 2
        Me.btnReprintPalletLabel.Text = "Reprint Pallet Label"
        '
        'pnlSNs
        '
        Me.pnlSNs.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlSNs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSNs.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.btnRemoveAllSNs, Me.lstDevices, Me.txtSN, Me.btnRemoveUnitFrPallet, Me.btnShipPallet})
        Me.pnlSNs.Location = New System.Drawing.Point(2, 0)
        Me.pnlSNs.Name = "pnlSNs"
        Me.pnlSNs.Size = New System.Drawing.Size(310, 400)
        Me.pnlSNs.TabIndex = 120
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Serial Number:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRemoveAllSNs
        '
        Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
        Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
        Me.btnRemoveAllSNs.Location = New System.Drawing.Point(184, 104)
        Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
        Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveAllSNs.Size = New System.Drawing.Size(104, 30)
        Me.btnRemoveAllSNs.TabIndex = 4
        Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(8, 48)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(160, 342)
        Me.lstDevices.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(256, 6)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(64, 32)
        Me.lblCount.TabIndex = 97
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBoxName
        '
        Me.lblBoxName.BackColor = System.Drawing.Color.Black
        Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
        Me.lblBoxName.Location = New System.Drawing.Point(2, 5)
        Me.lblBoxName.Name = "lblBoxName"
        Me.lblBoxName.Size = New System.Drawing.Size(246, 33)
        Me.lblBoxName.TabIndex = 98
        Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlShipType
        '
        Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModels, Me.Label4})
        Me.pnlShipType.Location = New System.Drawing.Point(2, 80)
        Me.pnlShipType.Name = "pnlShipType"
        Me.pnlShipType.Size = New System.Drawing.Size(510, 48)
        Me.pnlShipType.TabIndex = 121
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
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(72, 8)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(416, 21)
        Me.cboModels.TabIndex = 0
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Model:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblScreenName
        '
        Me.lblScreenName.BackColor = System.Drawing.Color.Black
        Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
        Me.lblScreenName.Location = New System.Drawing.Point(2, 0)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(174, 80)
        Me.lblScreenName.TabIndex = 122
        Me.lblScreenName.Text = "SENSUS BUILD SHIP PALLET"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpBuildPallet, Me.tpRecAndBuildPallet, Me.tpSearchRecUnit})
        Me.TabControl1.Location = New System.Drawing.Point(512, 128)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(328, 440)
        Me.TabControl1.TabIndex = 123
        '
        'tpBuildPallet
        '
        Me.tpBuildPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpBuildPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlSNs})
        Me.tpBuildPallet.Location = New System.Drawing.Point(4, 22)
        Me.tpBuildPallet.Name = "tpBuildPallet"
        Me.tpBuildPallet.Size = New System.Drawing.Size(320, 414)
        Me.tpBuildPallet.TabIndex = 0
        Me.tpBuildPallet.Text = "Build Pallet"
        '
        'tpRecAndBuildPallet
        '
        Me.tpRecAndBuildPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.tpRecAndBuildPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkDispose, Me.cboShipLocation, Me.Label3, Me.txtRecSN, Me.Label5, Me.lstRecSN, Me.Label2, Me.txtRMANo, Me.cboPartNo, Me.Label1})
        Me.tpRecAndBuildPallet.Location = New System.Drawing.Point(4, 22)
        Me.tpRecAndBuildPallet.Name = "tpRecAndBuildPallet"
        Me.tpRecAndBuildPallet.Size = New System.Drawing.Size(320, 414)
        Me.tpRecAndBuildPallet.TabIndex = 1
        Me.tpRecAndBuildPallet.Text = "Rec & Build Pallet"
        '
        'chkDispose
        '
        Me.chkDispose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDispose.ForeColor = System.Drawing.Color.White
        Me.chkDispose.Location = New System.Drawing.Point(112, 65)
        Me.chkDispose.Name = "chkDispose"
        Me.chkDispose.TabIndex = 3
        Me.chkDispose.Text = "Dispose ?"
        '
        'cboShipLocation
        '
        Me.cboShipLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboShipLocation.Caption = ""
        Me.cboShipLocation.CaptionHeight = 17
        Me.cboShipLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboShipLocation.ColumnCaptionHeight = 17
        Me.cboShipLocation.ColumnFooterHeight = 17
        Me.cboShipLocation.ContentHeight = 15
        Me.cboShipLocation.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboShipLocation.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboShipLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboShipLocation.EditorHeight = 15
        Me.cboShipLocation.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboShipLocation.ItemHeight = 15
        Me.cboShipLocation.Location = New System.Drawing.Point(112, 94)
        Me.cboShipLocation.MatchEntryTimeout = CType(2000, Long)
        Me.cboShipLocation.MaxDropDownItems = CType(5, Short)
        Me.cboShipLocation.MaxLength = 32767
        Me.cboShipLocation.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboShipLocation.Name = "cboShipLocation"
        Me.cboShipLocation.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboShipLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboShipLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboShipLocation.Size = New System.Drawing.Size(176, 21)
        Me.cboShipLocation.TabIndex = 4
        Me.cboShipLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
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
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-16, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 15)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Ship Location:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecSN
        '
        Me.txtRecSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecSN.Location = New System.Drawing.Point(112, 128)
        Me.txtRecSN.Name = "txtRecSN"
        Me.txtRecSN.Size = New System.Drawing.Size(176, 20)
        Me.txtRecSN.TabIndex = 5
        Me.txtRecSN.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(8, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Serial Number:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstRecSN
        '
        Me.lstRecSN.Location = New System.Drawing.Point(112, 152)
        Me.lstRecSN.Name = "lstRecSN"
        Me.lstRecSN.Size = New System.Drawing.Size(176, 212)
        Me.lstRecSN.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(48, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "RMA #:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRMANo
        '
        Me.txtRMANo.Location = New System.Drawing.Point(112, 38)
        Me.txtRMANo.Name = "txtRMANo"
        Me.txtRMANo.Size = New System.Drawing.Size(176, 20)
        Me.txtRMANo.TabIndex = 2
        Me.txtRMANo.Text = ""
        '
        'cboPartNo
        '
        Me.cboPartNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboPartNo.Caption = ""
        Me.cboPartNo.CaptionHeight = 17
        Me.cboPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPartNo.ColumnCaptionHeight = 17
        Me.cboPartNo.ColumnFooterHeight = 17
        Me.cboPartNo.ContentHeight = 15
        Me.cboPartNo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPartNo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPartNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPartNo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPartNo.EditorHeight = 15
        Me.cboPartNo.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.cboPartNo.ItemHeight = 15
        Me.cboPartNo.Location = New System.Drawing.Point(112, 8)
        Me.cboPartNo.MatchEntryTimeout = CType(2000, Long)
        Me.cboPartNo.MaxDropDownItems = CType(5, Short)
        Me.cboPartNo.MaxLength = 32767
        Me.cboPartNo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPartNo.Name = "cboPartNo"
        Me.cboPartNo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPartNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPartNo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPartNo.Size = New System.Drawing.Size(176, 21)
        Me.cboPartNo.TabIndex = 1
        Me.cboPartNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(48, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Part #:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpSearchRecUnit
        '
        Me.tpSearchRecUnit.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSearch, Me.dtpDateEnd, Me.dtpDateStart, Me.txtSearchVal, Me.Label7, Me.cboSearchCriteria, Me.Label6, Me.dbgSearchData})
        Me.tpSearchRecUnit.Location = New System.Drawing.Point(4, 22)
        Me.tpSearchRecUnit.Name = "tpSearchRecUnit"
        Me.tpSearchRecUnit.Size = New System.Drawing.Size(320, 414)
        Me.tpSearchRecUnit.TabIndex = 2
        Me.tpSearchRecUnit.Text = "Search Received Units"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(264, 33)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(48, 17)
        Me.btnSearch.TabIndex = 91
        Me.btnSearch.Text = "Search"
        Me.btnSearch.Visible = False
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDateEnd.Location = New System.Drawing.Point(176, 32)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(80, 18)
        Me.dtpDateEnd.TabIndex = 90
        Me.dtpDateEnd.Visible = False
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDateStart.Location = New System.Drawing.Point(80, 32)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(80, 18)
        Me.dtpDateStart.TabIndex = 89
        Me.dtpDateStart.Visible = False
        '
        'txtSearchVal
        '
        Me.txtSearchVal.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchVal.Location = New System.Drawing.Point(80, 33)
        Me.txtSearchVal.Name = "txtSearchVal"
        Me.txtSearchVal.Size = New System.Drawing.Size(176, 18)
        Me.txtSearchVal.TabIndex = 2
        Me.txtSearchVal.Text = ""
        Me.txtSearchVal.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(-16, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Search Value:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSearchCriteria
        '
        Me.cboSearchCriteria.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSearchCriteria.Items.AddRange(New Object() {"Pallet Name", "Receive Date", "RMA", "RR Number", "Serial Number"})
        Me.cboSearchCriteria.Location = New System.Drawing.Point(80, 6)
        Me.cboSearchCriteria.Name = "cboSearchCriteria"
        Me.cboSearchCriteria.Size = New System.Drawing.Size(176, 19)
        Me.cboSearchCriteria.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(-8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Search By:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dbgSearchData
        '
        Me.dbgSearchData.AllowColMove = False
        Me.dbgSearchData.AllowColSelect = False
        Me.dbgSearchData.AllowSort = False
        Me.dbgSearchData.AllowUpdate = False
        Me.dbgSearchData.AllowUpdateOnBlur = False
        Me.dbgSearchData.AlternatingRows = True
        Me.dbgSearchData.CollapseColor = System.Drawing.Color.White
        Me.dbgSearchData.ExpandColor = System.Drawing.Color.White
        Me.dbgSearchData.FilterBar = True
        Me.dbgSearchData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgSearchData.ForeColor = System.Drawing.Color.White
        Me.dbgSearchData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgSearchData.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.dbgSearchData.Location = New System.Drawing.Point(8, 64)
        Me.dbgSearchData.Name = "dbgSearchData"
        Me.dbgSearchData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgSearchData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgSearchData.PreviewInfo.ZoomFactor = 75
        Me.dbgSearchData.RowHeight = 17
        Me.dbgSearchData.Size = New System.Drawing.Size(304, 336)
        Me.dbgSearchData.TabIndex = 3
        Me.dbgSearchData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 6.75pt, style=Bold;ForeColor:Black;BackColor:LightSteelBlue;}Selected{ForeColo" & _
        "r:Black;BackColor:Teal;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCapti" & _
        "on;}FilterBar{Font:Tahoma, 6.75pt, style=Bold;ForeColor:Black;BackColor:Transpar" & _
        "ent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;}Style9{}Normal{Font:Micro" & _
        "soft Sans Serif, 8.25pt, style=Bold;BackColor:LightSteelBlue;ForeColor:White;Ali" & _
        "gnVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Yellow;}Style12{}O" & _
        "ddRow{Font:Microsoft Sans Serif, 6.75pt, style=Bold;BackColor:SteelBlue;}RecordS" & _
        "elector{AlignImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Micro" & _
        "soft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Rai" & _
        "sed,,1, 1, 1, 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near" & _
        ";}Style11{}Style14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><" & _
        "C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name=""" & _
        """ AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnF" & _
        "ooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelector" & _
        "Width=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""" & _
        "><Height>332</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle p" & _
        "arent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filte" & _
        "rBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Sty" & _
        "le3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" " & _
        "me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveSt" & _
        "yle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><" & _
        "RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent" & _
        "=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0," & _
        " 300, 332</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle" & _
        "></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Norm" & _
        "al"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" " & _
        "/><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /" & _
        "><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><St" & _
        "yle parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><S" & _
        "tyle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /" & _
        "><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></" & _
        "NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</La" & _
        "yout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 300, 332</Clie" & _
        "ntArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle pare" & _
        "nt="""" me=""Style17"" /></Blob>"
        '
        'pnlPalletNameQty
        '
        Me.pnlPalletNameQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPalletNameQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBoxName, Me.lblCount})
        Me.pnlPalletNameQty.Location = New System.Drawing.Point(512, 80)
        Me.pnlPalletNameQty.Name = "pnlPalletNameQty"
        Me.pnlPalletNameQty.Size = New System.Drawing.Size(328, 48)
        Me.pnlPalletNameQty.TabIndex = 124
        '
        'frmSensusBuildShipPallet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(842, 581)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlPalletNameQty, Me.TabControl1, Me.lblScreenName, Me.pnlShipType, Me.pnlPallets, Me.lblLocation})
        Me.Name = "frmSensusBuildShipPallet"
        Me.Text = "frmSensusBuildShipPallet"
        CType(Me.dbgOpenPallets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgRRInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPallets.ResumeLayout(False)
        Me.pnlSNs.ResumeLayout(False)
        Me.pnlShipType.ResumeLayout(False)
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpBuildPallet.ResumeLayout(False)
        Me.tpRecAndBuildPallet.ResumeLayout(False)
        CType(Me.cboShipLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPartNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSearchRecUnit.ResumeLayout(False)
        CType(Me.dbgSearchData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPalletNameQty.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*****************************************************************************
    Private Sub frmSensusBuildShipPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable

        Try
            CheckIfMachineTiedToLine()

            PSS.Core.Highlight.SetHighLight(Me)

            dt = Me._objSensus.GetSensusModelList(True)
            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
            Me.cboModels.SelectedValue = 0

            'Get Sensus Part list
            dt = _objSensus.GetSensusPartNoList(True)
            Misc.PopulateC1DropDownList(Me.cboPartNo, dt, "ShortDesc", "sensusPartNoID")
            Me.cboPartNo.SelectedValue = 0

            'Get Sensus Part list
            dt = _objSensus.GetShipToLocation(True)
            Misc.PopulateC1DropDownList(Me.cboShipLocation, dt, "ShortName", "SensusLocationID")
            Me.cboShipLocation.SelectedValue = 0

            'Me.PopulateOpenPallet("SS" + Me._strLineID)

            Me.cboModels.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmSensusBuildShipPallet_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*****************************************************************************
    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim iGroup_ID As Integer = 0

        Try
            objMisc = New PSS.Data.Buisness.Misc()
            dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            For Each R1 In dt1.Rows
                'strGroup = Trim(R1("Group_Desc"))
                'iLine_ID = R1("Line_ID")
                'strLineNum = R1("Line_Number")
                'iLineSide_ID = R1("LineSide_ID")
                'strLineSide = Trim(R1("LineSide_Desc"))
                'strBin = Trim(R1("WC_Location"))
                'iWCLocation_ID = R1("WCLocation_ID")
                iGroup_ID = R1("Group_ID")
                _strLineID = Format(CInt(R1("Line_ID")), "00")
            Next R1

            If iGroup_ID <> Sensus.SENSUS_GROUP_ID Then
                MessageBox.Show("This computer does not map to the right group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
            End If

            If _strLineID = "" Then
                MessageBox.Show("This computer does not map to any line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
            End If

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            objMisc = Nothing
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Function

    '*****************************************************************************
    Private Sub cboModels_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.Enter
        Try
            ClearCtrlsAndVars()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboModels_Enter", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub ClearCtrlsAndVars()
        Try
            Me.lblLocation.BackColor = Color.SteelBlue
            Me.lblLocation.Text = ""
            Me.dbgOpenPallets.DataSource = Nothing
            Me.dbgRRInfo.DataSource = Nothing
            Me.dbgRRInfo.Caption = ""
            Me.txtSN.Text = ""
            Me.lblCount.Text = "0"
            Me.lblBoxName.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.lstDevices.Items.Clear()
            Me.lstDevices.Refresh()
            Me.lstRecSN.DataSource = Nothing
            Me.lstRecSN.Items.Clear()
            Me.lstRecSN.Refresh()
            Me.txtRecSN.Text = ""
            Me._iSelectedPartNoForWorkingPallet = 0
            Me._strSelectedPartNoForWorkingPallet = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ClearCtrlsAndVars", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub cboModels_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.SelectedValueChanged
        Dim strPalletPrefix As String = ""
        Try
            'Clear SN List
            Me.txtSN.Text = ""
            Me.lblCount.Text = "0"
            Me.lstDevices.DataSource = Nothing

            If Me.cboModels.SelectedValue > 0 Then
                If IsDBNull(Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku")) Then Throw New Exception("Model Sku is missing. Please contact IT.")
                strPalletPrefix = "SS" + Me._strLineID + Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku")
                Me.PopulateOpenPallet(strPalletPrefix, )
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboModels_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub cboModels_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModels.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Me.cboModels.SelectedValue > 0 Then
                If Me.dbgOpenPallets.RowCount > 0 Then
                    Me.RefreshSNList(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                    Me.PopulateRRByPallet(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                End If
                Me.txtSN.Focus()
            End If
        End If
    End Sub

    '*****************************************************************************
    Private Sub PopulateOpenPallet(ByVal strPalletPrefix As String, _
                                   Optional ByVal iPalletID As Integer = 0)
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim c1Style As C1.Win.C1TrueDBGrid.Style
        Dim strRegVal As String = ""

        Try
            '**********************************
            'Reset SN list and RR grid
            '**********************************
            Me.dbgRRInfo.DataSource = Nothing
            Me.txtSN.Text = ""
            Me.lblCount.Text = "0"
            Me.lstDevices.DataSource = Nothing
            '**********************************

            dt = Me._objSensus.GetOpenPalletByLine(strPalletPrefix, Me.cboModels.SelectedValue)

            With Me.dbgOpenPallets
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Styles.Clear()

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = AlignVertEnum.Center

                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = AlignVertEnum.Center
                Next i

                .Splits(0).DisplayColumns("Pallett_ID").Visible = False
                .Splits(0).DisplayColumns("pkslip_ID").Visible = False
                .Splits(0).DisplayColumns("Qty").Visible = False
                .Splits(0).DisplayColumns("Model_ID").Visible = False
                .Splits(0).DisplayColumns("Pallet Name").Width = 180
                .Splits(0).DisplayColumns("Location").Width = 145

                .AlternatingRows = True
                .FilterBar = False
                .AllowFilter = False

                If iPalletID > 0 Then
                    Me._booRefreshSNList = False
                    .MoveFirst()
                    For i = 0 To .RowCount - 1
                        If .Columns("Pallett_ID").CellValue(i) = iPalletID Then Exit For Else .MoveNext()
                    Next i

                    Me._booRefreshSNList = True
                    Me.RefreshSNList(iPalletID, .Columns("Pallet Name").Value.ToString.Trim)
                End If

                'c1Style = New C1.Win.C1TrueDBGrid.Style()
                'c1Style.BackColor = Color.Purple
                'c1Style.ForeColor = Color.White
                'strRegVal = .Columns("Pallet Name").CellValue(.Row)
                '.AddRegexCellStyle(CellStyleFlag.AllCells, c1Style, strRegVal)
            End With

        Catch ex As Exception
            Me._booRefreshSNList = True
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub RefreshSNList(ByVal iPalletID As Integer, _
                              ByVal strPalletName As String)
        Dim dt1 As DataTable
        Dim objMisc As PSS.Data.Buisness.Misc

        Try
            If Me._booRefreshSNList = False Then Exit Sub
            '************************
            'Validations
            If iPalletID = 0 Then
                Throw New Exception("Box is not selected.")
            ElseIf strPalletName.Trim = "" Then
                Throw New Exception("Box is not selected.")
            End If

            '*******************************************
            'Get all devices add put them in them in list box for a pallet
            objMisc = New PSS.Data.Buisness.Misc()
            dt1 = objMisc.GetAllSNsForPallet(iPalletID)
            If Me.tpBuildPallet.Visible = True Then
                Me.lstDevices.DataSource = dt1.DefaultView
                Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString

                Me.lstRecSN.DataSource = Nothing
                Me.lstRecSN.Refresh()
            ElseIf Me.tpRecAndBuildPallet.Visible = True Then
                Me.lstRecSN.DataSource = dt1.DefaultView
                Me.lstRecSN.ValueMember = dt1.Columns("device_id").ToString
                Me.lstRecSN.DisplayMember = dt1.Columns("device_sn").ToString

                Me.lstDevices.DataSource = Nothing
                Me.lstDevices.Refresh()
            End If

            Me.lblBoxName.Text = strPalletName
            Me.lblCount.Text = dt1.Rows.Count
            Me.txtSN.Text = ""
            Me.lblLocation.BackColor = Color.Purple
            Me.lblLocation.Text = Me.dbgOpenPallets.Columns("Location").CellValue(Me.dbgOpenPallets.Row)
            '*******************************************
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub txtSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then Exit Sub

                If Me.AssignSNToPallet(Me.txtSN.Text.Trim) = True Then
                    Me.txtSN.Text = ""
                Else
                    Me.txtSN.SelectAll()
                End If

                Me.txtSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtSN.SelectAll()
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Function AssignSNToPallet(ByVal strSN As String) As Boolean
        Const iMeterDispositionBillcodeID As Integer = 1575
        Const iMeterScrapBillcodeID As Integer = 1706
        Dim dt As DataTable
        Dim iPalletID As Integer = 0
        Dim i As Integer = 0
        Dim objDevice As PSS.Rules.Device
        Dim booIsExistedInTdevicebill As Boolean = False
        Dim booElegibleToAdd As Boolean = False
        Dim iPalletQty As Integer = 0
        Dim strPalletName As String = ""
        Dim booReturnVal As Boolean = False

        Try
            Me.lblLocation.Text = ""
            Me.lblLocation.BackColor = Color.SteelBlue

            If strSN.Trim.Length = 0 Then Exit Function
            If Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModels.SelectAll()
                Me.cboModels.Focus()
                Exit Function
            ElseIf IsDBNull(Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku")) Then
                MessageBox.Show("Model Sku is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            dt = Me._objSensus.GetSensusDeviceInWip(strSN.Trim)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("Device_ID")) Then
                    MessageBox.Show("System failed to create device ID. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Device_ID") = 0 Then
                    MessageBox.Show("System failed to create device ID. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) Then
                    MessageBox.Show("This unit has already assigned to a pallet """ + dt.Rows(0)("Pallett_Name").ToString + """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 AndAlso dt.Select("Device_DateShip is null").Length > 1 Then
                    MessageBox.Show("S/N existed more than one with open ship date. Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("DeviceModelID") <> Me.cboModels.SelectedValue Then
                    MessageBox.Show("S/N has different model with selected model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf IsDBNull(dt.Rows(0)("sd_DateShipped")) Then
                    MessageBox.Show("S/N has not moved to CEM.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '****************************
                    'Get Pallet ID
                    '****************************
                    For i = 0 To Me.dbgOpenPallets.RowCount - 1
                        If Me.dbgOpenPallets.Columns("Model_ID").CellValue(i).ToString.ToUpper = Me.cboModels.SelectedValue AndAlso Me.dbgOpenPallets.Columns("Location").CellValue(i).ToString.ToUpper = dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper Then
                            iPalletID = Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(i)
                            iPalletQty = Me.dbgOpenPallets.Columns("Qty").CellValue(i)
                            strPalletName = Me.dbgOpenPallets.Columns("Pallet Name").CellValue(i)
                            Exit For
                        End If
                    Next i

                    '****************************
                    'check Pallet Qty limitation
                    '****************************
                    If dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper <> "PSS" AndAlso dt.Rows(0)("DeviceModelID") <> 1210 AndAlso iPalletQty >= Sensus.PALLET_LIMIT Then
                        MessageBox.Show("You have reach the limit (" & Sensus.PALLET_LIMIT & ") of pallet '" & strPalletName & "'. Please close it.", "Pallet Limitation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    '****************************
                    'Create Pallet if not exist 
                    '****************************
                    If iPalletID = 0 Then
                        iPalletID = Me._objSensus.CreateShipPallet("SS" + Me._strLineID + Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku"), dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper, Me.cboModels.SelectedValue, ApplicationUser.IDuser, strPalletName)
                        Me.PopulateOpenPallet("SS" + Me._strLineID + Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku"), iPalletID)
                    End If
                    If iPalletID = 0 Then Throw New Exception("System has failed to create new pallet.")

                    '************************************************************
                    'check if unit and its RR eligble to be on current open pallet
                    '************************************************************
                    If dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper = "PSS" Or dt.Rows(0)("DeviceModelID") = 1210 Then booElegibleToAdd = True Else booElegibleToAdd = Me._objSensus.IsSNEligibleForAddToPallet(iPalletID, dt.Rows(0)("sd_RR_Num"), strPalletName, dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper)
                    If booElegibleToAdd = False Then Exit Function

                    '****************************
                    'Bill Meter Dispostion service
                    '****************************
                    objDevice = New PSS.Rules.Device(dt.Rows(0)("Device_ID"))
                    If Generic.IsBillcodeExisted(dt.Rows(0)("Device_ID"), iMeterDispositionBillcodeID) = False Then objDevice.AddPart(iMeterDispositionBillcodeID)
                    If dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper = "PSS" AndAlso Generic.IsBillcodeExisted(dt.Rows(0)("Device_ID"), iMeterDispositionBillcodeID) = False Then objDevice.AddPart(iMeterDispositionBillcodeID)
                    objDevice.Update()

                    '***************************************
                    'Assign unit to pallet and select pallet
                    '***************************************
                    i = 0
                    i = Me._objSensus.AssignUnitToPallet(iPalletID, dt.Rows(0)("Device_ID"), ApplicationUser.IDuser)
                    If i = 0 Then Throw New Exception("System failed to assign pallet.")

                    If Me.dbgOpenPallets.RowCount = 0 Then
                        Me.PopulateOpenPallet("SS" + Me._strLineID + Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku"), iPalletID)
                    Else
                        Me._booRefreshSNList = False
                        Me.dbgOpenPallets.MoveFirst()
                        For i = 0 To Me.dbgOpenPallets.RowCount - 1
                            If Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(i) = iPalletID Then Exit For Else Me.dbgOpenPallets.MoveNext()
                        Next i
                        Me._booRefreshSNList = True
                    End If

                    '****************************
                    'refresh data
                    '****************************
                    Me.RefreshSNList(iPalletID, strPalletName)
                    Me.dbgRRInfo.DataSource = Nothing

                    Me.lblLocation.BackColor = Color.Purple
                    Me.lblLocation.Text = dt.Rows(0)("ShipLoc").ToString.Trim.ToUpper

                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    '****************************

                    booReturnVal = True
                End If
            Else
                MessageBox.Show("Serial number does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Me._booRefreshSNList = True
            MessageBox.Show(ex.ToString, "Assign SN To Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try

        Return booReturnVal
    End Function

    '*****************************************************************************
    Private Sub btnShipPallet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShipPallet.Click
        Dim i As Integer = 0
        Dim iPalletID As Integer = 0
        Dim strPalletName As String = ""
        Dim strLocation As String = ""
        Dim dt As DataTable

        Try
            If Me.dbgOpenPallets.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select only one pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dbgOpenPallets.SelectedRows.Count > 1 Then
                MessageBox.Show("Please select only one pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf IsDBNull(Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku")) Then
                MessageBox.Show("Model Sku is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                iPalletID = Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row)
                strPalletName = Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row)
                strLocation = Me.dbgOpenPallets.Columns("Location").CellValue(Me.dbgOpenPallets.Row)

                If iPalletID = 0 Then
                    MessageBox.Show("Can't define pallet ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf MessageBox.Show("Are you sure you want to close the selected pallett (" & strPalletName.ToUpper & ") ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                ElseIf Me.cboModels.SelectedValue <> 1210 AndAlso strLocation.Trim.ToUpper <> "PSS" AndAlso Me._objSensus.IsEligibleToCloseAndShip(iPalletID, strLocation) = False Then
                    Exit Sub
                Else

                    dt = Me._objSensus.GetModelInPallet(iPalletID)
                    If dt.Select("Model_ID <> " & Me.cboModels.SelectedValue).Length > 0 Then
                        MessageBox.Show("Pallet has device of different model(" & dt.Select("Model_ID <> " & Me.cboModels.SelectedValue)(0)("Model_Desc") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    'Me._objSensus.CloseAndShipPallet(iPalletID, strPalletName, _
                    '                                 Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_desc"), _
                    '                                                                      strLocation, ApplicationUser.IDShift, ApplicationUser.IDuser)
                    Me._objSensus.CloseAndShipPallet(iPalletID, strPalletName, Me._strSelectedPartNoForWorkingPallet, _
                                                      strLocation, ApplicationUser.IDShift, ApplicationUser.IDuser)


                    '*********************************
                    'reset controls adn refresh data
                    '*********************************
                    Me.lblLocation.Text = ""
                    Me.lblCount.Text = "0"
                    With Me.lstDevices
                        .DataSource = Nothing
                        .Items.Clear()
                        .Refresh()
                    End With
                    With Me.dbgRRInfo
                        .DataSource = Nothing
                        .Caption = ""
                        .CaptionStyle.BackColor = Color.LightGray
                    End With
                    Me.PopulateOpenPallet("SS" + Me._strLineID + Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("Model_MotoSku"))

                    '*********************************
                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.ToString, "btnShipPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnDeleteEmptyPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteEmptyPallet.Click
        Dim i As Integer = 0
        Dim iPalletID As Integer = 0

        Try
            If Me.dbgOpenPallets.SelectedRows.Count = 0 Then Exit Sub

            If Me.dbgOpenPallets.SelectedRows.Count > 1 Then
                MessageBox.Show("Please select only one pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                For Each i In Me.dbgOpenPallets.SelectedRows
                    If Me.dbgOpenPallets.Columns("Qty").CellValue(i) > 0 Then
                        MessageBox.Show("Pallet is not empty.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    ElseIf Me._objSensus.GetPalletQty(Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(i)) > 0 Then
                        MessageBox.Show("Pallet is not empty.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    ElseIf Not IsDBNull(Me.dbgOpenPallets.Columns("pkslip_ID").CellValue(i)) Then
                        MessageBox.Show("Pallet was assgined to a packing list. Please contact IT.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                Next i

                If MessageBox.Show("Are you sure you want to delete selected pallet(" & Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row).ToString.ToUpper & ")?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

                i = 0
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objSensus.DeleteEmptyPallet(Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), ApplicationUser.IDuser)

                If File.Exists(Me._objSensus.SHIP_MANIFEST_LOC & Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row)) Then File.Move(Me._objSensus.SHIP_MANIFEST_LOC & Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row), Me._objSensus.SHIP_MANIFEST_LOC & "DeletedPallet\" & Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))

                Me.PopulateOpenPallet("SS" + Me._strLineID)

                Cursor.Current = Cursors.Default
                Me.Enabled = True

                If i > 0 Then MessageBox.Show("Completed.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
            Me.Enabled = True
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnReOpenPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenPallet.Click
        Dim strPalletName As String = ""
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim iPalletID As Integer = 0

        Try
            strPalletName = InputBox("Enter Pallet Name:").Trim

            If strPalletName.Trim.Length = 0 Then Exit Sub

            If strPalletName.Trim.ToUpper.StartsWith("SS" & Me._strLineID) = False Then MessageBox.Show("Pallet does not belong to your line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub

            dt = Me._objSensus.GetSensusPalletInfoByName(strPalletName)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pallet Name does not exist in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Pallet Name existed more than one in system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                MessageBox.Show("Pallet has already assigned to a packing list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallet_Invalid") > 0 Then
                MessageBox.Show("Pallet was deleted by " & dt.Rows(0)("Delete User").ToString.ToUpper & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallet_SkuLen").ToString.Trim.ToUpper <> "PSS" AndAlso Me._objSensus.GetPalletQty(dt.Rows(0)("Pallett_ID")) >= Sensus.PALLET_LIMIT Then
                MessageBox.Show("Pallet is already reach limit(" & Sensus.PALLET_LIMIT & ").", "Information", MessageBoxButtons.OK)
            ElseIf Me._objSensus.GetOpenPalletCount(dt.Rows(0)("Model_ID"), dt.Rows(0)("Pallet_SkuLen")) > 0 Then
                MessageBox.Show("There is a pallet currently open. Please close it first.", "Information", MessageBoxButtons.OK)
            ElseIf Me._objSensus.GetInvoiceCount(dt.Rows(0)("Pallett_ID")) > 0 Then
                MessageBox.Show("Pallet is already invoiced.", "Information", MessageBoxButtons.OK)
            Else
                ''For i = 0 To Me.dbgOpenPallets.RowCount - 1
                ''    If Me.dbgOpenPallets.Columns("Location").CellValue(i).ToString.ToUpper = dt.Rows(0)("Pallet_SkuLen").ToString.ToUpper Then
                ''        MessageBox.Show("There is a " & Me.dbgOpenPallets.Columns("Location").CellValue(i).ToString.ToUpper & " pallet currently open. Please close it first.", "Information", MessageBoxButtons.OK)
                ''        Exit Sub
                ''    End If
                ''Next i

                If MessageBox.Show("Are you sure you want to re-open pallet(" & strPalletName & ")?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

                i = 0
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objSensus.ReOpenPallet(dt.Rows(0)("Pallett_ID"))

                If Me.cboModels.SelectedValue > 0 Then Me.PopulateOpenPallet("SS" + Me._strLineID)

                Me.Enabled = True
                Cursor.Current = Cursors.Default

                If i > 0 Then MessageBox.Show("Completed.")
            End If

        Catch ex As Exception
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub PopulateRRByPallet(ByVal iPalletID As Integer, ByVal strPalletName As String)
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            With Me.dbgRRInfo
                .Caption = ""
                .CaptionStyle.BackColor = Color.SteelBlue
                .DataSource = Nothing
                .ColumnFooters = False
                .Visible = True

                If strPalletName.Trim.Length = 0 Then Exit Sub

                dt = Me._objSensus.GetRRQtyOfPallet(iPalletID)

                If dt.Rows.Count > 0 Then

                    .DataSource = dt.DefaultView

                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = AlignVertEnum.Center

                        .Splits(0).DisplayColumns(i).Style.VerticalAlignment = AlignVertEnum.Center
                    Next i

                    .Splits(0).DisplayColumns("sd_loc").Visible = False
                    .Splits(0).DisplayColumns("RR#").Width = 150
                    .Splits(0).DisplayColumns("On Pallet Qty").Width = 80
                    .Splits(0).DisplayColumns("RR Qty").Width = 60
                    .Splits(0).DisplayColumns("Open Qty").Width = 60
                    .Splits(0).DisplayColumns("On Pallet Qty").Style.HorizontalAlignment = AlignHorzEnum.Far
                    .Splits(0).DisplayColumns("RR Qty").Style.HorizontalAlignment = AlignHorzEnum.Far
                    .Splits(0).DisplayColumns("Open Qty").Style.HorizontalAlignment = AlignHorzEnum.Far

                    .AlternatingRows = True
                    .FilterBar = False
                    .AllowFilter = False

                    .Caption = strPalletName
                    .CaptionStyle.ForeColor = Color.White
                    .CaptionStyle.BackColor = Color.Purple

                    'Total
                    .ColumnFooters = True
                    .FooterStyle.BackColor = Color.Black
                    .FooterStyle.ForeColor = Color.Lime
                    .Splits(0).FooterStyle.HorizontalAlignment = AlignHorzEnum.Far
                    .Columns("RR#").FooterText = "Total"
                    .Columns("On Pallet Qty").FooterText = dt.Compute("Sum([On Pallet Qty])", "").ToString
                    .Columns("RR Qty").FooterText = dt.Compute("Sum([RR Qty])", "").ToString
                    .Columns("Open Qty").FooterText = dt.Compute("Sum([Open Qty])", "").ToString
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnPrintPalletDetailRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPalletDetailRpt.Click
        Dim strPalletName As String = ""
        Try
            strPalletName = InputBox("Enter Pallet Name:", "Pallet Name").Trim
            If strPalletName.Trim.Length = 0 Then MessageBox.Show("You must enter pallet name to print pallet detail report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            Me._objSensus.PrintSensusPalletDetailRpt(strPalletName.Trim.ToUpper)

            Me.Enabled = True
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPalletLabel.Click
        Dim strPalletName As String = ""
        Dim dt As DataTable
        Try
            strPalletName = InputBox("Enter Pallet Name:", "Pallet Name").Trim
            If strPalletName.Trim.Length = 0 Then MessageBox.Show("You must enter pallet name to print pallet detail report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub

            dt = Me._objSensus.GetSensusPalletInfoByName(strPalletName)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pallet Name does not exist in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Pallet Name existed more than one in system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallet_Invalid") > 0 Then
                MessageBox.Show("Pallet was deleted by " & dt.Rows(0)("Delete User").ToString.ToUpper & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                MessageBox.Show("Pallet is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                Me._objSensus.PrintSensusPalletLabel(strPalletName.Trim.ToUpper, dt.Rows(0)("Pallett_QTY"), dt.Rows(0)("Pallet_SkuLen"), dt.Rows(0)("Model_Desc"), 1)

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub dbgOpenPallets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgOpenPallets.DoubleClick
        Dim dt As DataTable
        Dim objFrmDisplayData As frmDisplayData
        Try
            If Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row) > 0 Then
                dt = Me._objSensus.GetPalletDetails(Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row))
                objFrmDisplayData = New frmDisplayData(dt)
                objFrmDisplayData.Show()
            Else
                MessageBox.Show("Can not define Pallet ID.", "Information", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgOpenPallets_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub dbgRRInfo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgRRInfo.DoubleClick
        Dim dt As DataTable
        Dim objFrmDisplayData As frmDisplayData
        Try
            If Me.dbgRRInfo.Columns("RR#").CellValue(Me.dbgRRInfo.Row).ToString.Trim.Length > 0 Then

                dt = Me._objSensus.GetRRDetails(Me.dbgRRInfo.Columns("RR#").CellValue(Me.dbgRRInfo.Row).ToString.Trim)
                objFrmDisplayData = New frmDisplayData(dt)
                objFrmDisplayData.Show()
            Else
                MessageBox.Show("Can not define RR#.", "Information", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgRRInfo_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub dbgOpenPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgOpenPallets.RowColChange
        Dim i As Integer
        Dim c1Style As C1.Win.C1TrueDBGrid.Style
        Dim strRegVal As String = ""

        Try
            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            If Me.dbgOpenPallets.RowCount > 0 AndAlso Me.dbgOpenPallets.Columns.Count > 0 AndAlso Me._booRefreshSNList = True Then
                '********************************
                'Populate RRs quantity
                '********************************
                Me.PopulateRRByPallet(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                Me.RefreshSNList(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                '***************************************
                'change background color of current row
                '***************************************
                Me.dbgOpenPallets.ClearRegexCellStyle(CellStyleFlag.AllCells)
                c1Style = New C1.Win.C1TrueDBGrid.Style()
                c1Style.BackColor = Color.Purple
                c1Style.ForeColor = Color.White
                strRegVal = Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row)
                Me.dbgOpenPallets.AddRegexCellStyle(CellStyleFlag.AllCells, c1Style, strRegVal)
                '***************************************
            End If

            Me.Enabled = True
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnRemoveUnitFrPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveUnitFrPallet.Click
        Dim i As Integer = 0
        Dim strSN As String = ""
        Dim dt As DataTable
        Dim iPalletID As Integer = 0
        Dim strPalletName As String = ""

        Try
            If Me.dbgOpenPallets.RowCount = 0 Then Exit Sub

            strSN = InputBox("Enter S/N:", "Information").Trim
            If strSN.Trim.Length = 0 Then Exit Sub

            dt = Me._objSensus.GetSensusDeviceLatestRecord(strSN)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("S/N either does not exist in the system.", "Information", MessageBoxButtons.OK)
            ElseIf IsDBNull(dt.Rows(0)("Pallett_ID")) Then
                MessageBox.Show("S/N does not belong to any pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallett_ID") = 0 Then
                MessageBox.Show("S/N does not belong to any pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Not IsDBNull(dt.Rows(0)("Device_DateShip")) Then
                MessageBox.Show("S/N was completed and shipped by the line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Model_ID") <> Me.cboModels.SelectedValue Then
                MessageBox.Show("Model of S/N is different from selected model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '************************************
                'Search for pallett on on list
                '************************************
                Me._booRefreshSNList = False
                Me.dbgOpenPallets.MoveFirst()
                For i = 0 To Me.dbgOpenPallets.RowCount - 1
                    If Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(i) = dt.Rows(0)("Pallett_ID") Then
                        iPalletID = Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(i)
                        strPalletName = Me.dbgOpenPallets.Columns("Pallet Name").CellValue(i)
                        Exit For
                    Else
                        Me.dbgOpenPallets.MoveNext()
                    End If
                Next i
                Me._booRefreshSNList = True
                '************************************

                If iPalletID = 0 Then
                    MessageBox.Show("S/N does not belong to any listed pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = 0
                    i = Me._objSensus.RemoveUnitFrPallet(dt.Rows(0)("Device_ID"), iPalletID)
                    Me.PopulateRRByPallet(iPalletID, strPalletName)
                    Me.RefreshSNList(iPalletID, strPalletName)
                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
        Dim i As Integer = 0
        Dim strSN As String = ""
        Dim dt As DataTable

        Try
            If Me.dbgOpenPallets.RowCount = 0 Then Exit Sub
            If Me.lstDevices.Items.Count = 0 Then
                MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf IsDBNull(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row)) OrElse dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row) = 0 Then
                MessageBox.Show("System can not define pallet. Please select one pallet to empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf MessageBox.Show("Are you sure you want to empty this pallet """ & Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row) & """?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            Else
                dt = Me._objSensus.GetSensusPalletInfoByName(dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet does not exist in the system or belongs to a different customer.", "Information", MessageBoxButtons.OK)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Pallet has been completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                    MessageBox.Show("Pallet has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) AndAlso dt.Rows(0)("pkslip_ID") > 0 Then
                    MessageBox.Show("Pallet has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Pallet_Invalid") = 1 Then
                    MessageBox.Show("Pallet had been deleted by " & dt.Rows(0)("Delete User") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    i = Me._objSensus.EmptyPallet(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row))
                    Me.PopulateRRByPallet(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                    Me.RefreshSNList(dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.ToString, "btnRemoveUnitFrpallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
            Me.txtSN.Focus()
        End Try
    End Sub

    '*****************************************************************************
    Private Sub chkDispose_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDispose.CheckedChanged
        Try
            If Me.chkDispose.Checked = True Then
                If Me.cboShipLocation.DataSource.Table.Select("ShortName = 'PSS'").Length > 0 Then
                    Me.cboShipLocation.SelectedValue = Me.cboShipLocation.DataSource.Table.Select("ShortName = 'PSS'")(0)("SensusLocationID")
                Else
                    Me.cboShipLocation.SelectedValue = 0
                End If
            ElseIf Me.cboModels.SelectedValue = 1210 Then 'Water meter
                If Me.cboShipLocation.DataSource.Table.Select("ShortName = 'FLEXTRONICS'").Length > 0 Then
                    Me.cboShipLocation.SelectedValue = Me.cboShipLocation.DataSource.Table.Select("ShortName = 'FLEXTRONICS'")(0)("SensusLocationID")
                Else
                    Me.cboShipLocation.SelectedValue = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "rbtnDispose_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub txtRecSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecSN.KeyUp
        Dim dt As DataTable
        Dim iDeviceID As Integer = 0
        Dim iMeterType As Integer = 0

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtRecSN.Text.Trim.Length = 0 Then Exit Sub

                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtRecSN.Text = ""
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                ElseIf Me.cboPartNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select Part #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtRecSN.Text = ""
                    Me.cboPartNo.SelectAll() : Me.cboPartNo.Focus()
                ElseIf Me.cboShipLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship to location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtRecSN.Text = ""
                    Me.cboShipLocation.SelectAll() : Me.cboShipLocation.Focus()
                ElseIf Me.txtRMANo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please select ship to location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtRecSN.Text = ""
                    Me.txtRMANo.SelectAll() : Me.txtRMANo.Focus()

                Else
                    If Me.lstRecSN.Items.Count > 0 Then
                        'If Not Me._SelectedModelForWorkingPallet = Me.cboModels.SelectedValue Then
                        '    MessageBox.Show("The device to add has a different model for the working pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                        '    Exit Sub
                        'End If
                        If Not Me._iSelectedPartNoForWorkingPallet = Me.cboPartNo.SelectedValue Then
                            MessageBox.Show("The device to add has a different part number for the working pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.cboPartNo.SelectAll() : Me.cboPartNo.Focus()
                            Exit Sub
                        End If
                    Else
                        'Me._SelectedModelForWorkingPallet = Me.cboModels.SelectedValue
                        Me._iSelectedPartNoForWorkingPallet = Me.cboPartNo.SelectedValue
                        Me._strSelectedPartNoForWorkingPallet = Me.cboPartNo.DataSource.Table.Select("sensusPartNoID = " & Me.cboPartNo.SelectedValue)(0)("ShortDesc")
                    End If


                    dt = Me._objSensus.GetSensusDeviceInWip(Me.txtRecSN.Text.Trim)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("Device's already existed under RMA '" + dt.Rows(0)("sd_RMA_Num ") + "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtRecSN.SelectAll() : Me.txtRecSN.Focus()
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        iMeterType = Convert.ToInt16(Me.cboModels.DataSource.Table.Select("Model_id = " & Me.cboModels.SelectedValue)(0)("MeterType"))
                        iDeviceID = Me._objSensus.ReceivedNoFileUnit(Me.cboModels.SelectedValue, Me.txtRecSN.Text.Trim, Me.txtRMANo.Text.Trim, _
                                                                     Me.cboPartNo.Text.Trim, Me.cboShipLocation.Text.Trim, _
                                                                     PSS.Core.ApplicationUser.Workdate, PSS.Core.ApplicationUser.IDShift, _
                                                                     iMeterType, Me.chkDispose.Checked)
                        If Me.AssignSNToPallet(Me.txtRecSN.Text.Trim) Then
                            Me.Enabled = True : Me.txtRecSN.Text = "" : Me.txtRecSN.Focus()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "txtRecSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*****************************************************************************
    Private Sub tpBuildPallet_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpBuildPallet.VisibleChanged
        Try
            If Me.tpBuildPallet.Visible = True Then
                If Me.dbgOpenPallets.RowCount > 0 AndAlso Me.dbgOpenPallets.Columns.Count > 0 Then
                    If Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row) > 0 Then Me.RefreshSNList(Me.dbgOpenPallets.Columns("Pallett_ID").CellValue(Me.dbgOpenPallets.Row), Me.dbgOpenPallets.Columns("Pallet Name").CellValue(Me.dbgOpenPallets.Row))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "tpBuildPallet_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub txtSearchVal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchVal.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.ProcessSearch()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "txtSearchVal_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub cboSearchCriteria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchCriteria.SelectedIndexChanged

        Try
            If Me.cboSearchCriteria.SelectedIndex = 1 Then
                Me.dtpDateStart.Visible = True
                Me.dtpDateEnd.Visible = True

                Me.txtSearchVal.Visible = False

                Me.dtpDateStart.Focus()
            Else
                Me.dtpDateStart.Visible = False
                Me.dtpDateEnd.Visible = False

                Me.txtSearchVal.Visible = True

                Me.txtSearchVal.Focus()
            End If

            Me.btnSearch.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "cboSearchCriteria_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub ProcessSearch()
        Dim dt As DataTable
        Dim strCriteria As String = ""

        Try
            Me.dbgSearchData.DataSource = Nothing

            If Me.cboSearchCriteria.SelectedIndex <> 1 AndAlso Me.txtSearchVal.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me.cboSearchCriteria.SelectedIndex = 1 AndAlso DateDiff(DateInterval.Day, Me.dtpDateStart.Value, Me.dtpDateEnd.Value) < 0 Then
                MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Select Case Me.cboSearchCriteria.SelectedIndex
                    Case 0 'Pallet Name
                        strCriteria = "tpallett.Pallett_Name = '" & Me.txtSearchVal.Text.Trim & "'"
                    Case 1 'Receive Date
                        strCriteria = "tdevice.Device_RecWorkDate between '" & Me.dtpDateStart.Value.ToString("yyyy-MM-dd") & "' AND '" & Me.dtpDateEnd.Value.ToString("yyyy-MM-dd") & "'"
                    Case 2 'RMA
                        strCriteria = "tsensusdata.sd_RMA_Num = '" & Me.txtSearchVal.Text.Trim & "'"
                    Case 3 'RR Number
                        strCriteria = "tsensusdata.sd_RR_Num = '" & Me.txtSearchVal.Text.Trim & "'"
                    Case 4 'Serial Number
                        strCriteria = "tsensusdata.sd_SN = '" & Me.txtSearchVal.Text.Trim & "'"
                    Case Else
                        Exit Sub
                End Select

                dt = Me._objSensus.GetSearchData(strCriteria)
                Me.dbgSearchData.DataSource = dt.DefaultView
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "ProcessSearch", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ProcessSearch()
    End Sub

    '*****************************************************************************

    Private Sub cboPartNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNo.TextChanged

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lstRecSN.Items.Add(Me.txtRecSN.Text)



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lstRecSN.Items.Clear()
    End Sub


End Class
