Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui

    Public Class ManageModelStatus
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _iCustMasterCodeID As Integer = 0
        Private _iProdID As Integer = 0
        Private _booUserCustPssModelMap As Boolean = False
        Private _objModel As Data.Buisness.ModManuf

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal iMasterCode As Integer, _
                       Optional ByVal iProdID As Integer = 0, _
                       Optional ByVal booUseCustPssModelMap As Boolean = False)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _iCustMasterCodeID = iMasterCode
            _iProdID = iProdID
            _booUserCustPssModelMap = booUseCustPssModelMap

            _objModel = New Data.Buisness.ModManuf()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
            _objModel = Nothing
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents tcModelClassification As System.Windows.Forms.TabControl
        Friend WithEvents tpModelClassification As System.Windows.Forms.TabPage
        Friend WithEvents tpClassification As System.Windows.Forms.TabPage
        Friend WithEvents cboCustClassification As C1.Win.C1List.C1Combo
		Friend WithEvents btnSaveModelClassification As System.Windows.Forms.Button
		Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents dtpEffectiveDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnClearModelClassification As System.Windows.Forms.Button
        Friend WithEvents dbgModelClassification As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents btnSaveCustClassification As System.Windows.Forms.Button
		Friend WithEvents dbgCustClassification As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents gbCustClassification As System.Windows.Forms.GroupBox
        Friend WithEvents gbPssStatus As System.Windows.Forms.GroupBox
        Friend WithEvents btnClearCustClassification As System.Windows.Forms.Button
        Friend WithEvents btnSavePssStatus As System.Windows.Forms.Button
        Friend WithEvents txtPssNewStatus As System.Windows.Forms.TextBox
        Friend WithEvents btnClearPssStatus As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents chkPssStatusInactive As System.Windows.Forms.CheckBox
        Friend WithEvents dbgPssStatus As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtPssStatus As System.Windows.Forms.TextBox
        Friend WithEvents txtCustNewClassification As System.Windows.Forms.TextBox
        Friend WithEvents txtCustClassification As System.Windows.Forms.TextBox
        Friend WithEvents chkCustClassificationInative As System.Windows.Forms.CheckBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cbHas_BC As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ManageModelStatus))
			Me.tcModelClassification = New System.Windows.Forms.TabControl()
			Me.tpModelClassification = New System.Windows.Forms.TabPage()
			Me.cbHas_BC = New System.Windows.Forms.CheckBox()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.btnClearModelClassification = New System.Windows.Forms.Button()
			Me.Label10 = New System.Windows.Forms.Label()
			Me.dtpEffectiveDate = New System.Windows.Forms.DateTimePicker()
			Me.btnSaveModelClassification = New System.Windows.Forms.Button()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.cboCustClassification = New C1.Win.C1List.C1Combo()
			Me.Label9 = New System.Windows.Forms.Label()
			Me.cboModels = New C1.Win.C1List.C1Combo()
			Me.dbgModelClassification = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.tpClassification = New System.Windows.Forms.TabPage()
			Me.gbCustClassification = New System.Windows.Forms.GroupBox()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.txtCustNewClassification = New System.Windows.Forms.TextBox()
			Me.btnSaveCustClassification = New System.Windows.Forms.Button()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.txtCustClassification = New System.Windows.Forms.TextBox()
			Me.chkCustClassificationInative = New System.Windows.Forms.CheckBox()
			Me.btnClearCustClassification = New System.Windows.Forms.Button()
			Me.dbgCustClassification = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.gbPssStatus = New System.Windows.Forms.GroupBox()
			Me.dbgPssStatus = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.chkPssStatusInactive = New System.Windows.Forms.CheckBox()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.txtPssStatus = New System.Windows.Forms.TextBox()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.btnClearPssStatus = New System.Windows.Forms.Button()
			Me.btnSavePssStatus = New System.Windows.Forms.Button()
			Me.txtPssNewStatus = New System.Windows.Forms.TextBox()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.cboCustomers = New C1.Win.C1List.C1Combo()
			Me.tcModelClassification.SuspendLayout()
			Me.tpModelClassification.SuspendLayout()
			CType(Me.cboCustClassification, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dbgModelClassification, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tpClassification.SuspendLayout()
			Me.gbCustClassification.SuspendLayout()
			CType(Me.dbgCustClassification, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.gbPssStatus.SuspendLayout()
			CType(Me.dbgPssStatus, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'tcModelClassification
			'
			Me.tcModelClassification.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.tcModelClassification.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpModelClassification, Me.tpClassification})
			Me.tcModelClassification.Location = New System.Drawing.Point(16, 48)
			Me.tcModelClassification.Name = "tcModelClassification"
			Me.tcModelClassification.SelectedIndex = 0
			Me.tcModelClassification.Size = New System.Drawing.Size(904, 536)
			Me.tcModelClassification.TabIndex = 0
			'
			'tpModelClassification
			'
			Me.tpModelClassification.BackColor = System.Drawing.Color.SteelBlue
			Me.tpModelClassification.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbHas_BC, Me.Label8, Me.btnClearModelClassification, Me.Label10, Me.dtpEffectiveDate, Me.btnSaveModelClassification, Me.Label1, Me.cboCustClassification, Me.Label9, Me.cboModels, Me.dbgModelClassification})
			Me.tpModelClassification.Location = New System.Drawing.Point(4, 22)
			Me.tpModelClassification.Name = "tpModelClassification"
			Me.tpModelClassification.Size = New System.Drawing.Size(896, 510)
			Me.tpModelClassification.TabIndex = 0
			Me.tpModelClassification.Text = "Model Classification"
			'
			'cbHas_BC
			'
			Me.cbHas_BC.Location = New System.Drawing.Point(200, 80)
			Me.cbHas_BC.Name = "cbHas_BC"
			Me.cbHas_BC.Size = New System.Drawing.Size(16, 24)
			Me.cbHas_BC.TabIndex = 9
			'
			'Label8
			'
			Me.Label8.BackColor = System.Drawing.Color.Transparent
			Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label8.ForeColor = System.Drawing.Color.White
			Me.Label8.Location = New System.Drawing.Point(16, 80)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(168, 16)
			Me.Label8.TabIndex = 8
			Me.Label8.Text = "Has Battery Cover:"
			Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnClearModelClassification
			'
			Me.btnClearModelClassification.BackColor = System.Drawing.Color.SteelBlue
			Me.btnClearModelClassification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClearModelClassification.ForeColor = System.Drawing.Color.White
			Me.btnClearModelClassification.Location = New System.Drawing.Point(784, 56)
			Me.btnClearModelClassification.Name = "btnClearModelClassification"
			Me.btnClearModelClassification.TabIndex = 11
			Me.btnClearModelClassification.Text = "Clear"
			'
			'Label10
			'
			Me.Label10.BackColor = System.Drawing.Color.Transparent
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label10.ForeColor = System.Drawing.Color.White
			Me.Label10.Location = New System.Drawing.Point(8, 48)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New System.Drawing.Size(176, 16)
			Me.Label10.TabIndex = 4
			Me.Label10.Text = "Effective Date :"
			Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'dtpEffectiveDate
			'
			Me.dtpEffectiveDate.Location = New System.Drawing.Point(192, 48)
			Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
			Me.dtpEffectiveDate.TabIndex = 5
			'
			'btnSaveModelClassification
			'
			Me.btnSaveModelClassification.BackColor = System.Drawing.Color.Green
			Me.btnSaveModelClassification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnSaveModelClassification.ForeColor = System.Drawing.Color.White
			Me.btnSaveModelClassification.Location = New System.Drawing.Point(784, 16)
			Me.btnSaveModelClassification.Name = "btnSaveModelClassification"
			Me.btnSaveModelClassification.TabIndex = 10
			Me.btnSaveModelClassification.Text = "Save"
			'
			'Label1
			'
			Me.Label1.BackColor = System.Drawing.Color.Transparent
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.White
			Me.Label1.Location = New System.Drawing.Point(432, 16)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(161, 16)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Customer Classification :"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboCustClassification
			'
			Me.cboCustClassification.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboCustClassification.AutoCompletion = True
			Me.cboCustClassification.AutoDropDown = True
			Me.cboCustClassification.AutoSelect = True
			Me.cboCustClassification.Caption = ""
			Me.cboCustClassification.CaptionHeight = 17
			Me.cboCustClassification.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboCustClassification.ColumnCaptionHeight = 17
			Me.cboCustClassification.ColumnFooterHeight = 17
			Me.cboCustClassification.ColumnHeaders = False
			Me.cboCustClassification.ContentHeight = 15
			Me.cboCustClassification.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboCustClassification.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboCustClassification.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboCustClassification.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboCustClassification.EditorHeight = 15
			Me.cboCustClassification.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboCustClassification.ItemHeight = 15
			Me.cboCustClassification.Location = New System.Drawing.Point(600, 16)
			Me.cboCustClassification.MatchEntryTimeout = CType(2000, Long)
			Me.cboCustClassification.MaxDropDownItems = CType(10, Short)
			Me.cboCustClassification.MaxLength = 32767
			Me.cboCustClassification.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboCustClassification.Name = "cboCustClassification"
			Me.cboCustClassification.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboCustClassification.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboCustClassification.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboCustClassification.Size = New System.Drawing.Size(136, 21)
			Me.cboCustClassification.TabIndex = 3
			Me.cboCustClassification.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
			"ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
			"}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
			"lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
			"kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
			"oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
			"dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
			", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
			"le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
			"ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
			"""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
			"6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
			"rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
			""" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
			"=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
			"ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
			"iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
			""" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
			"arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
			"ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
			"nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
			"Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
			"ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
			"""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
			"ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
			"ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
			"ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
			'
			'Label9
			'
			Me.Label9.BackColor = System.Drawing.Color.Transparent
			Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label9.ForeColor = System.Drawing.Color.White
			Me.Label9.Location = New System.Drawing.Point(16, 16)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New System.Drawing.Size(168, 16)
			Me.Label9.TabIndex = 0
			Me.Label9.Text = "Models :"
			Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboModels
			'
			Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboModels.AutoCompletion = True
			Me.cboModels.AutoDropDown = True
			Me.cboModels.AutoSelect = True
			Me.cboModels.Caption = ""
			Me.cboModels.CaptionHeight = 17
			Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboModels.ColumnCaptionHeight = 17
			Me.cboModels.ColumnFooterHeight = 17
			Me.cboModels.ColumnHeaders = False
			Me.cboModels.ContentHeight = 15
			Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboModels.EditorHeight = 15
			Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboModels.ItemHeight = 20
			Me.cboModels.Location = New System.Drawing.Point(192, 16)
			Me.cboModels.MatchEntryTimeout = CType(2000, Long)
			Me.cboModels.MaxDropDownItems = CType(10, Short)
			Me.cboModels.MaxLength = 32767
			Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboModels.Name = "cboModels"
			Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboModels.Size = New System.Drawing.Size(200, 21)
			Me.cboModels.TabIndex = 1
			Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
			"ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
			"}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
			"lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
			"kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
			"oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
			"Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
			"Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
			"ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
			"ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
			"""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
			"6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
			"rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
			""" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
			"=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
			"ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
			"iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
			""" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
			"arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
			"ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
			"nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
			"Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
			"ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
			"""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
			"ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
			"ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
			"ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
			'
			'dbgModelClassification
			'
			Me.dbgModelClassification.AllowSort = False
			Me.dbgModelClassification.AllowUpdate = False
			Me.dbgModelClassification.AlternatingRows = True
			Me.dbgModelClassification.FilterBar = True
			Me.dbgModelClassification.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgModelClassification.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.dbgModelClassification.Location = New System.Drawing.Point(0, 112)
			Me.dbgModelClassification.Name = "dbgModelClassification"
			Me.dbgModelClassification.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgModelClassification.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgModelClassification.PreviewInfo.ZoomFactor = 75
			Me.dbgModelClassification.Size = New System.Drawing.Size(896, 392)
			Me.dbgModelClassification.TabIndex = 12
			Me.dbgModelClassification.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
			"r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
			"}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
			"lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
			"}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
			"InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
			"ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
			";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
			"Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
			"olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
			"}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
			"ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
			"t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
			" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
			"88</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
			"tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
			"parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
			"oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
			""" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
			"=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
			"ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
			""" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 892, 388<" & _
			"/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
			"C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
			"le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
			"arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
			"rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
			"=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
			"t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
			"rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
			"s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
			"ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 892, 388</ClientArea><Pr" & _
			"intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
			"Style21"" /></Blob>"
			'
			'tpClassification
			'
			Me.tpClassification.BackColor = System.Drawing.Color.SteelBlue
			Me.tpClassification.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCustClassification, Me.gbPssStatus})
			Me.tpClassification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.tpClassification.ForeColor = System.Drawing.Color.White
			Me.tpClassification.Location = New System.Drawing.Point(4, 22)
			Me.tpClassification.Name = "tpClassification"
			Me.tpClassification.Size = New System.Drawing.Size(896, 510)
			Me.tpClassification.TabIndex = 1
			Me.tpClassification.Text = "Define Classification"
			'
			'gbCustClassification
			'
			Me.gbCustClassification.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.gbCustClassification.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.txtCustNewClassification, Me.btnSaveCustClassification, Me.Label7, Me.txtCustClassification, Me.chkCustClassificationInative, Me.btnClearCustClassification, Me.dbgCustClassification})
			Me.gbCustClassification.Location = New System.Drawing.Point(24, 16)
			Me.gbCustClassification.Name = "gbCustClassification"
			Me.gbCustClassification.Size = New System.Drawing.Size(400, 464)
			Me.gbCustClassification.TabIndex = 0
			Me.gbCustClassification.TabStop = False
			Me.gbCustClassification.Text = "Cust Classification"
			'
			'Label6
			'
			Me.Label6.BackColor = System.Drawing.Color.Transparent
			Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.ForeColor = System.Drawing.Color.White
			Me.Label6.Location = New System.Drawing.Point(14, 79)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(282, 16)
			Me.Label6.TabIndex = 124
			Me.Label6.Text = "New Description (Require only on update)"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'txtCustNewClassification
			'
			Me.txtCustNewClassification.Location = New System.Drawing.Point(18, 95)
			Me.txtCustNewClassification.Name = "txtCustNewClassification"
			Me.txtCustNewClassification.Size = New System.Drawing.Size(288, 21)
			Me.txtCustNewClassification.TabIndex = 1232
			Me.txtCustNewClassification.Text = ""
			'
			'btnSaveCustClassification
			'
			Me.btnSaveCustClassification.BackColor = System.Drawing.Color.Green
			Me.btnSaveCustClassification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnSaveCustClassification.ForeColor = System.Drawing.Color.White
			Me.btnSaveCustClassification.Location = New System.Drawing.Point(120, 128)
			Me.btnSaveCustClassification.Name = "btnSaveCustClassification"
			Me.btnSaveCustClassification.TabIndex = 4
			Me.btnSaveCustClassification.Text = "Save"
			'
			'Label7
			'
			Me.Label7.BackColor = System.Drawing.Color.Transparent
			Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.ForeColor = System.Drawing.Color.White
			Me.Label7.Location = New System.Drawing.Point(12, 24)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(160, 16)
			Me.Label7.TabIndex = 122
			Me.Label7.Text = "Description"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'txtCustClassification
			'
			Me.txtCustClassification.Location = New System.Drawing.Point(16, 40)
			Me.txtCustClassification.Name = "txtCustClassification"
			Me.txtCustClassification.Size = New System.Drawing.Size(288, 21)
			Me.txtCustClassification.TabIndex = 1
			Me.txtCustClassification.Text = ""
			'
			'chkCustClassificationInative
			'
			Me.chkCustClassificationInative.Location = New System.Drawing.Point(16, 128)
			Me.chkCustClassificationInative.Name = "chkCustClassificationInative"
			Me.chkCustClassificationInative.Size = New System.Drawing.Size(96, 24)
			Me.chkCustClassificationInative.TabIndex = 3
			Me.chkCustClassificationInative.Text = "In-Activate"
			'
			'btnClearCustClassification
			'
			Me.btnClearCustClassification.BackColor = System.Drawing.Color.DimGray
			Me.btnClearCustClassification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClearCustClassification.ForeColor = System.Drawing.Color.White
			Me.btnClearCustClassification.Location = New System.Drawing.Point(232, 128)
			Me.btnClearCustClassification.Name = "btnClearCustClassification"
			Me.btnClearCustClassification.TabIndex = 5
			Me.btnClearCustClassification.Text = "Clear"
			'
			'dbgCustClassification
			'
			Me.dbgCustClassification.AllowUpdate = False
			Me.dbgCustClassification.AlternatingRows = True
			Me.dbgCustClassification.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.dbgCustClassification.CaptionHeight = 17
			Me.dbgCustClassification.FilterBar = True
			Me.dbgCustClassification.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.dbgCustClassification.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgCustClassification.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
			Me.dbgCustClassification.Location = New System.Drawing.Point(16, 183)
			Me.dbgCustClassification.Name = "dbgCustClassification"
			Me.dbgCustClassification.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgCustClassification.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgCustClassification.PreviewInfo.ZoomFactor = 75
			Me.dbgCustClassification.RowHeight = 15
			Me.dbgCustClassification.Size = New System.Drawing.Size(368, 257)
			Me.dbgCustClassification.TabIndex = 6
			Me.dbgCustClassification.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
			"e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
			"9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
			"ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
			"BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
			"}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
			"olor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
			"ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
			"5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
			"roup{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Sty" & _
			"le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
			"iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
			"7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
			"rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
			"lGroup=""1""><Height>253</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
			"torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
			""" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
			"r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
			"""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
			"InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
			"tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
			"yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
			"Rect>0, 0, 364, 253</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</B" & _
			"orderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=""" & _
			""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me" & _
			"=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""I" & _
			"nactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edi" & _
			"tor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Eve" & _
			"nRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordS" & _
			"elector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""G" & _
			"roup"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layou" & _
			"t>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 364," & _
			" 253</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooter" & _
			"Style parent="""" me=""Style21"" /></Blob>"
			'
			'gbPssStatus
			'
			Me.gbPssStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.gbPssStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgPssStatus, Me.chkPssStatusInactive, Me.Label5, Me.txtPssStatus, Me.Label4, Me.btnClearPssStatus, Me.btnSavePssStatus, Me.txtPssNewStatus})
			Me.gbPssStatus.Location = New System.Drawing.Point(448, 16)
			Me.gbPssStatus.Name = "gbPssStatus"
			Me.gbPssStatus.Size = New System.Drawing.Size(432, 464)
			Me.gbPssStatus.TabIndex = 1
			Me.gbPssStatus.TabStop = False
			Me.gbPssStatus.Text = "Pss Status"
			'
			'dbgPssStatus
			'
			Me.dbgPssStatus.AllowUpdate = False
			Me.dbgPssStatus.AlternatingRows = True
			Me.dbgPssStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.dbgPssStatus.CaptionHeight = 17
			Me.dbgPssStatus.FilterBar = True
			Me.dbgPssStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.dbgPssStatus.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgPssStatus.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
			Me.dbgPssStatus.Location = New System.Drawing.Point(16, 175)
			Me.dbgPssStatus.Name = "dbgPssStatus"
			Me.dbgPssStatus.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgPssStatus.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgPssStatus.PreviewInfo.ZoomFactor = 75
			Me.dbgPssStatus.RowHeight = 15
			Me.dbgPssStatus.Size = New System.Drawing.Size(392, 265)
			Me.dbgPssStatus.TabIndex = 1376
			Me.dbgPssStatus.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
			"e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
			"9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
			"ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
			"BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
			"}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
			"olor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;F" & _
			"oreColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
			"5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
			"roup{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Sty" & _
			"le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
			"iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
			"7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
			"rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
			"lGroup=""1""><Height>261</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
			"torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
			""" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
			"r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
			"""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
			"InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
			"tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
			"yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
			"Rect>0, 0, 388, 261</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</B" & _
			"orderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=""" & _
			""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me" & _
			"=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""I" & _
			"nactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edi" & _
			"tor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Eve" & _
			"nRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordS" & _
			"elector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""G" & _
			"roup"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layou" & _
			"t>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 388," & _
			" 261</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooter" & _
			"Style parent="""" me=""Style21"" /></Blob>"
			'
			'chkPssStatusInactive
			'
			Me.chkPssStatusInactive.Location = New System.Drawing.Point(16, 128)
			Me.chkPssStatusInactive.Name = "chkPssStatusInactive"
			Me.chkPssStatusInactive.Size = New System.Drawing.Size(96, 24)
			Me.chkPssStatusInactive.TabIndex = 3
			Me.chkPssStatusInactive.Text = "In-Activate"
			'
			'Label5
			'
			Me.Label5.BackColor = System.Drawing.Color.Transparent
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.ForeColor = System.Drawing.Color.White
			Me.Label5.Location = New System.Drawing.Point(16, 24)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(160, 16)
			Me.Label5.TabIndex = 135
			Me.Label5.Text = "Description"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'txtPssStatus
			'
			Me.txtPssStatus.Location = New System.Drawing.Point(16, 40)
			Me.txtPssStatus.Name = "txtPssStatus"
			Me.txtPssStatus.Size = New System.Drawing.Size(288, 21)
			Me.txtPssStatus.TabIndex = 1
			Me.txtPssStatus.Text = ""
			'
			'Label4
			'
			Me.Label4.BackColor = System.Drawing.Color.Transparent
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.ForeColor = System.Drawing.Color.White
			Me.Label4.Location = New System.Drawing.Point(16, 74)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(304, 16)
			Me.Label4.TabIndex = 133
			Me.Label4.Text = "New Description (Require only on update)"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'btnClearPssStatus
			'
			Me.btnClearPssStatus.BackColor = System.Drawing.Color.DimGray
			Me.btnClearPssStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClearPssStatus.ForeColor = System.Drawing.Color.White
			Me.btnClearPssStatus.Location = New System.Drawing.Point(232, 128)
			Me.btnClearPssStatus.Name = "btnClearPssStatus"
			Me.btnClearPssStatus.TabIndex = 1325
			Me.btnClearPssStatus.Text = "Clear"
			'
			'btnSavePssStatus
			'
			Me.btnSavePssStatus.BackColor = System.Drawing.Color.Green
			Me.btnSavePssStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnSavePssStatus.ForeColor = System.Drawing.Color.White
			Me.btnSavePssStatus.Location = New System.Drawing.Point(128, 128)
			Me.btnSavePssStatus.Name = "btnSavePssStatus"
			Me.btnSavePssStatus.TabIndex = 4
			Me.btnSavePssStatus.Text = "Save"
			'
			'txtPssNewStatus
			'
			Me.txtPssNewStatus.Location = New System.Drawing.Point(16, 96)
			Me.txtPssNewStatus.Name = "txtPssNewStatus"
			Me.txtPssNewStatus.Size = New System.Drawing.Size(288, 21)
			Me.txtPssNewStatus.TabIndex = 2
			Me.txtPssNewStatus.Text = ""
			'
			'Label2
			'
			Me.Label2.BackColor = System.Drawing.Color.Transparent
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.White
			Me.Label2.Location = New System.Drawing.Point(16, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(88, 16)
			Me.Label2.TabIndex = 0
			Me.Label2.Text = "Customers :"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboCustomers
			'
			Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboCustomers.AutoCompletion = True
			Me.cboCustomers.AutoDropDown = True
			Me.cboCustomers.AutoSelect = True
			Me.cboCustomers.Caption = ""
			Me.cboCustomers.CaptionHeight = 17
			Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboCustomers.ColumnCaptionHeight = 17
			Me.cboCustomers.ColumnFooterHeight = 17
			Me.cboCustomers.ColumnHeaders = False
			Me.cboCustomers.ContentHeight = 15
			Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboCustomers.EditorHeight = 15
			Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
			Me.cboCustomers.ItemHeight = 20
			Me.cboCustomers.Location = New System.Drawing.Point(112, 8)
			Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
			Me.cboCustomers.MaxDropDownItems = CType(10, Short)
			Me.cboCustomers.MaxLength = 32767
			Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboCustomers.Name = "cboCustomers"
			Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboCustomers.Size = New System.Drawing.Size(328, 21)
			Me.cboCustomers.TabIndex = 1
			Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
			"ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
			"}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
			"lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
			"kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft " & _
			"Sans Serif, 10pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Styl" & _
			"e9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;A" & _
			"lignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contro" & _
			"l;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.List" & _
			"BoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptio" & _
			"nHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
			"up=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><W" & _
			"idth>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Caption" & _
			"Style parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /" & _
			"><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
			"11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
			"ghlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
			"Style parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector""" & _
			" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""No" & _
			"rmal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style par" & _
			"ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
			"g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
			"me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
			"=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" m" & _
			"e=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Captio" & _
			"n"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplit" & _
			"s><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
			'
			'ManageModelStatus
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(952, 622)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.cboCustomers, Me.tcModelClassification})
			Me.Name = "ManageModelStatus"
			Me.Text = "TFManageModelStatus"
			Me.tcModelClassification.ResumeLayout(False)
			Me.tpModelClassification.ResumeLayout(False)
			CType(Me.cboCustClassification, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dbgModelClassification, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tpClassification.ResumeLayout(False)
			Me.gbCustClassification.ResumeLayout(False)
			CType(Me.dbgCustClassification, System.ComponentModel.ISupportInitialize).EndInit()
			Me.gbPssStatus.ResumeLayout(False)
			CType(Me.dbgPssStatus, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "Form"
        '********************************************************************************************************
        Private Sub TFManageModelStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim iModelMapCustID As Integer = 0

            Try
                'HasBattery can be changed in the screen Inventory - Service Inventory
                'So we disable it in this screen
                Me.cbHas_BC.Visible = False : Me.Label8.Visible = False

                If Me._iMenuCustID = 0 Then
                    MessageBox.Show("Customer ID is missing.", "Information", MessageBoxButtons.OK)
                ElseIf Me._iCustMasterCodeID = 0 Then
                    MessageBox.Show("Master code ID is missing.", "Information", MessageBoxButtons.OK)
                Else
                    'Load customers
                    dt = Generic.GetCustomers(True, , )
                    Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomers.SelectedValue = _iMenuCustID
                    If _iMenuCustID > 0 Then Me.cboCustomers.Enabled = False

                    'Load Model
                    If _booUserCustPssModelMap = True Then iModelMapCustID = _iMenuCustID
                    dt = Nothing : dt = Generic.GetModels(True, Me._iProdID, , Me._iMenuCustID)
                    Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
                    Me.cboModels.SelectedValue = 0

                    'Load Customer Classification selection
                    LoadCustClassificationSelection()
                    LoadCustPssModelClassificationGrid()
                    LoadCustClassificationGrid()
                    LoadPssStatusGrid()
                    Me.dtpEffectiveDate.Value = Now()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadCustClassificationSelection()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If Not IsNothing(Me.cboCustClassification.DataSource) Then Me.cboCustClassification.DataSource = Nothing

                dt = Me._objModel.GetCustClassificationList(True, True, _iCustMasterCodeID.ToString)
                Misc.PopulateC1DropDownList(Me.cboCustClassification, dt, "Classification", "DCode_ID")
                Me.cboCustClassification.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadCustClassificationGrid()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                dt = Me._objModel.GetCustClassificationList(False, False, Me._iCustMasterCodeID.ToString)
                With Me.dbgCustClassification
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("MCode_ID").Visible = False
                    .Splits(0).DisplayColumns("DCode_ID").Visible = False
                    .Splits(0).DisplayColumns("Dcode_Inactive").Visible = False
                    .Splits(0).DisplayColumns("Classification").Width = 120
                    .Splits(0).DisplayColumns("User").Width = 120
                    .Splits(0).DisplayColumns("Active?").Width = 50
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

		Private Sub LoadPssStatusGrid()
			Dim dt As DataTable
			Dim i As Integer = 0

			Try
				dt = Me._objModel.GetMRPModelStatus(False, False)
				With Me.dbgPssStatus
					.DataSource = dt.DefaultView
					.Splits(0).DisplayColumns("ID").Visible = False
					.Splits(0).DisplayColumns("Active").Visible = False
					.Splits(0).DisplayColumns("Status").Width = 120
					.Splits(0).DisplayColumns("User").Width = 120
					.Splits(0).DisplayColumns("Active?").Width = 50
				End With
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'********************************************************************************************************
		Private Sub LoadCustPssModelClassificationGrid()
			Dim dt As DataTable
			Dim i As Integer = 0

			Try
				dt = Me._objModel.GetModelClassificationJournal(Me._iMenuCustID, False, )
				With Me.dbgModelClassification
					.DataSource = dt.DefaultView
					.Splits(0).DisplayColumns("CMC_ID").Visible = False
					.Splits(0).DisplayColumns("Model_ID").Visible = False
					.Splits(0).DisplayColumns("Cust_DCode_ID").Visible = False
					.Splits(0).DisplayColumns("MRP_Status_ID").Visible = False

					For i = 0 To dt.Columns.Count - 1
						.Splits(0).DisplayColumns(i).AutoSize()
					Next i
				End With
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'********************************************************************************************************
#End Region

#Region "Model Status"
        '********************************************************************************************************
        Private Sub btnSaveModelClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveModelClassification.Click
            Dim i As Integer = 0
            Dim strEffectiveDate, strErrMsg As String
            Try
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                ElseIf Me.cboCustClassification.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer classification.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustClassification.SelectAll() : Me.cboCustClassification.Focus()
				ElseIf MessageBox.Show("Are you sure you want to update above info?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				Else
					strEffectiveDate = Me.dtpEffectiveDate.Value.ToString("yyyy-MM-dd") : strErrMsg = ""
					Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
					i = Me._objModel.SaveCustModelClassification(Me.cboCustomers.SelectedValue, Me.cboModels.SelectedValue, Me.cboCustClassification.SelectedValue, Core.ApplicationUser.IDuser, strEffectiveDate, strErrMsg)
					If strErrMsg.Trim.Length > 0 Then
						MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf i = 0 Then
						MessageBox.Show("System has failed to save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						Me.LoadCustPssModelClassificationGrid()
						Me.cboCustClassification.SelectedValue = 0
						Me.Enabled = True : Me.cboModels.SelectedValue = 0 : Me.cboModels.SelectAll() : Me.cboModels.Focus()
					End If

					'UpdateModelClassifications()

				End If
			Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveModelClassification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnClearModelClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearModelClassification.Click
            Try
                Me.cboModels.SelectedValue = 0
				Me.cboCustClassification.SelectedValue = 0 : Me.dtpEffectiveDate.Value = Now()
                Me.Enabled = True : Me.cboModels.SelectedValue = 0 : Me.cboModels.SelectAll() : Me.cboModels.Focus()
                'Me.cbHas_BC.Checked = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearModelClassification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub dbgModelClassification_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgModelClassification.DoubleClick
            Try
                btnClearModelClassification_Click(Nothing, Nothing)
                If Me.dbgModelClassification.RowCount > 0 Then
                    If Convert.ToInt32(Me.dbgModelClassification.Columns("CMC_ID").CellValue(Me.dbgModelClassification.Row)) > 0 Then
                        Me.cboModels.SelectedValue = Convert.ToInt32(Me.dbgModelClassification.Columns("Model_ID").CellValue(Me.dbgModelClassification.Row))
                        Me.dtpEffectiveDate.Value = Convert.ToDateTime(Me.dbgModelClassification.Columns("Effective Date").CellValue(Me.dbgModelClassification.Row))
                        Me.cboCustClassification.SelectedValue = Convert.ToInt32(Me.dbgModelClassification.Columns("Cust_DCode_ID").CellValue(Me.dbgModelClassification.Row))
                        'Me.cbHas_BC.Checked = (Me.dbgModelClassification.Columns("Has_BC").CellValue(Me.dbgModelClassification.Row))
					End If
				End If
			Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgModelClassification_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub dbgModelClassification_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgModelClassification.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all to the clipboard."
                    objCopySelected.Text = "Copy selected rows to the clipboard."

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMain_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dbgModelClassification, True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyAllData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dbgModelClassification, True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************

#End Region

#Region "Status"

        '********************************************************************************************************
        Private Sub txts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPssNewStatus.KeyPress, txtCustClassification.KeyPress
            Try
                If Not e.KeyChar.IsLetterOrDigit(e.KeyChar) AndAlso e.KeyChar.ToString <> "-" AndAlso e.KeyChar.ToString <> " " AndAlso Not e.KeyChar.IsControl(e.KeyChar) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txts_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnAddClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCustClassification.Click
            Dim i, iInactive As Integer
            Dim strErrMsg As String = ""

            Try
                If Me.txtCustClassification.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter classification description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCustClassification.SelectAll() : Me.txtCustClassification.Focus()
                Else
                    i = 0 : iInactive = 0
                    If Me.chkCustClassificationInative.Checked = True Then iInactive = 1

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = Me._objModel.SaveCustClassification(Me._iCustMasterCodeID, Me.txtCustClassification.Text.Trim, Me.txtCustNewClassification.Text.Trim, iInactive, Core.ApplicationUser.IDuser, strErrMsg)
                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg, "Save Customer Classification", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtCustClassification.SelectAll() : Me.txtCustClassification.Focus()
                    ElseIf i = 0 Then
                        MessageBox.Show("System has failed to save customer classification.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtCustClassification.SelectAll() : Me.txtCustClassification.Focus()
                    Else
                        Me.txtCustClassification.Text = "" : Me.txtCustNewClassification.Text = ""
                        Me.LoadCustClassificationSelection() : Me.LoadCustClassificationGrid()
                        Me.LoadCustPssModelClassificationGrid()
                        Me.Enabled = True : Me.txtCustClassification.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddStatus_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnSavePssStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePssStatus.Click
            Dim i, iActive As Integer
            Dim strErrMsg As String = ""

            Try
                If Me.txtPssStatus.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    If Me.chkPssStatusInactive.Checked = True Then iActive = 0 Else iActive = 1

                    i = Me._objModel.SavePssStatus(Me.txtPssStatus.Text.Trim, Me.txtPssNewStatus.Text.Trim, iActive, Core.ApplicationUser.IDuser, strErrMsg)
                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg, "Save Pss Status", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf i = 0 Then
                        MessageBox.Show("System has failed to save pss status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
						Me.txtPssStatus.Text = ""
						Me.txtPssNewStatus.Text = ""
						Me.chkPssStatusInactive.Checked = False
						Me.LoadPssStatusGrid()
                        Me.LoadCustPssModelClassificationGrid()
						Me.Enabled = True
						Me.txtPssStatus.SelectAll()
						Me.txtPssStatus.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSavePssStatus_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub dbgCustClassification_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgCustClassification.DoubleClick
            Try
                btnClearCustClassification_Click(Nothing, Nothing)
                If Me.dbgCustClassification.RowCount > 0 Then
                    If Convert.ToInt32(Me.dbgCustClassification.Columns("DCode_ID").CellValue(Me.dbgCustClassification.Row)) > 0 Then
                        Me.txtCustClassification.Text = Me.dbgCustClassification.Columns("Classification").CellValue(Me.dbgCustClassification.Row).ToString
                        If Me.dbgCustClassification.Columns("Dcode_Inactive").CellValue(Me.dbgCustClassification.Row).ToString.Trim = "1" Then Me.chkCustClassificationInative.Checked = True Else Me.chkCustClassificationInative.Checked = False
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgCustClassification_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnClearCustClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCustClassification.Click
            Try
                Me.txtCustClassification.Text = "" : Me.txtCustNewClassification.Text = ""
                Me.chkCustClassificationInative.Checked = False : Me.txtCustClassification.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearEditClassification_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub dbgPssStatus_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPssStatus.DoubleClick
            Try
                btnClearPssStatus_Click(Nothing, Nothing)
                If Me.dbgPssStatus.RowCount > 0 Then
                    If Convert.ToInt32(Me.dbgPssStatus.Columns("ID").CellValue(Me.dbgPssStatus.Row)) > 0 Then
                        Me.txtPssStatus.Text = Me.dbgPssStatus.Columns("Status").CellValue(Me.dbgPssStatus.Row).ToString
                        If Me.dbgPssStatus.Columns("Active").CellValue(Me.dbgPssStatus.Row).ToString.Trim = "1" Then Me.chkPssStatusInactive.Checked = False Else Me.chkPssStatusInactive.Checked = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPssStatus_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnClearPssStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPssStatus.Click
            Try
                Me.txtPssStatus.Text = "" : Me.txtPssNewStatus.Text = ""
                Me.chkPssStatusInactive.Checked = False : Me.txtPssStatus.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearPssStatus_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************

#End Region

		'Private Sub UpdateModelClassifications()
		'	Shell("P:\Public\IT\StoredProcesses\ProcessCaller\ProcessCaller.exe", AppWinStyle.Hide)
		'End Sub

	End Class
End Namespace