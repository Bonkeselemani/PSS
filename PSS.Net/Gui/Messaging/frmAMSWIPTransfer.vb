Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAMSWIPTransfer
        Inherits System.Windows.Forms.Form

        Private Const _iMaxPreCellSubLoc As Integer = 225
        Private _objMessaging As PSS.Data.Buisness.Messaging
        Private _dtDevices_Ready As New DataTable()
        Private _booLoadCtrl As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objMessaging = New PSS.Data.Buisness.Messaging()
            _dtDevices_Ready = Nothing

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
        Friend WithEvents cboLoc As C1.Win.C1List.C1Combo
        Friend WithEvents cboSubLoc As C1.Win.C1List.C1Combo
        Friend WithEvents lblLoc As System.Windows.Forms.Label
        Friend WithEvents lblSubLoc As System.Windows.Forms.Label
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents dbgDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblRecNum As System.Windows.Forms.Label
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
		Friend WithEvents lblWipLoc As System.Windows.Forms.Label
		Friend WithEvents chkNoMixFreq As System.Windows.Forms.CheckBox
        Friend WithEvents lblFreqInSubLoc As System.Windows.Forms.Label
        Friend WithEvents lblDevFreq As System.Windows.Forms.Label
        Friend WithEvents rbtnTrayID As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnSN As System.Windows.Forms.RadioButton
        Friend WithEvents txtInputVal As System.Windows.Forms.TextBox
        Friend WithEvents pnlInputVal As System.Windows.Forms.Panel
        Friend WithEvents pnlSNs As System.Windows.Forms.Panel
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblSubLocQty As System.Windows.Forms.Label
		Friend WithEvents Panel1 As System.Windows.Forms.Panel
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAMSWIPTransfer))
			Me.cboLoc = New C1.Win.C1List.C1Combo()
			Me.cboSubLoc = New C1.Win.C1List.C1Combo()
			Me.txtInputVal = New System.Windows.Forms.TextBox()
			Me.lblLoc = New System.Windows.Forms.Label()
			Me.lblSubLoc = New System.Windows.Forms.Label()
			Me.btnComplete = New System.Windows.Forms.Button()
			Me.dbgDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.lblRecNum = New System.Windows.Forms.Label()
			Me.btnRemoveOne = New System.Windows.Forms.Button()
			Me.btnRemoveAll = New System.Windows.Forms.Button()
			Me.lblSubLocQty = New System.Windows.Forms.Label()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.pnlSNs = New System.Windows.Forms.Panel()
			Me.pnlInputVal = New System.Windows.Forms.Panel()
			Me.lblWipLoc = New System.Windows.Forms.Label()
			Me.lblDevFreq = New System.Windows.Forms.Label()
			Me.rbtnSN = New System.Windows.Forms.RadioButton()
			Me.rbtnTrayID = New System.Windows.Forms.RadioButton()
			Me.lblFreqInSubLoc = New System.Windows.Forms.Label()
			Me.chkNoMixFreq = New System.Windows.Forms.CheckBox()
			Me.Panel1 = New System.Windows.Forms.Panel()
			Me.GroupBox1 = New System.Windows.Forms.GroupBox()
			CType(Me.cboLoc, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboSubLoc, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dbgDevices, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlSNs.SuspendLayout()
			Me.pnlInputVal.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.SuspendLayout()
			'
			'cboLoc
			'
			Me.cboLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboLoc.AutoCompletion = True
			Me.cboLoc.AutoDropDown = True
			Me.cboLoc.AutoSelect = True
			Me.cboLoc.Caption = ""
			Me.cboLoc.CaptionHeight = 17
			Me.cboLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboLoc.ColumnCaptionHeight = 17
			Me.cboLoc.ColumnFooterHeight = 17
			Me.cboLoc.ColumnHeaders = False
			Me.cboLoc.ContentHeight = 15
			Me.cboLoc.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboLoc.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboLoc.EditorHeight = 15
			Me.cboLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboLoc.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboLoc.ItemHeight = 15
			Me.cboLoc.Location = New System.Drawing.Point(96, 8)
			Me.cboLoc.MatchEntryTimeout = CType(2000, Long)
			Me.cboLoc.MaxDropDownItems = CType(10, Short)
			Me.cboLoc.MaxLength = 32767
			Me.cboLoc.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboLoc.Name = "cboLoc"
			Me.cboLoc.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboLoc.Size = New System.Drawing.Size(208, 21)
			Me.cboLoc.TabIndex = 1
			Me.cboLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'cboSubLoc
			'
			Me.cboSubLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboSubLoc.AutoCompletion = True
			Me.cboSubLoc.AutoDropDown = True
			Me.cboSubLoc.AutoSelect = True
			Me.cboSubLoc.Caption = ""
			Me.cboSubLoc.CaptionHeight = 17
			Me.cboSubLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboSubLoc.ColumnCaptionHeight = 17
			Me.cboSubLoc.ColumnFooterHeight = 17
			Me.cboSubLoc.ColumnHeaders = False
			Me.cboSubLoc.ContentHeight = 15
			Me.cboSubLoc.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboSubLoc.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboSubLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboSubLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboSubLoc.EditorHeight = 15
			Me.cboSubLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboSubLoc.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboSubLoc.ItemHeight = 15
			Me.cboSubLoc.Location = New System.Drawing.Point(96, 40)
			Me.cboSubLoc.MatchEntryTimeout = CType(2000, Long)
			Me.cboSubLoc.MaxDropDownItems = CType(10, Short)
			Me.cboSubLoc.MaxLength = 32767
			Me.cboSubLoc.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboSubLoc.Name = "cboSubLoc"
			Me.cboSubLoc.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboSubLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboSubLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboSubLoc.Size = New System.Drawing.Size(208, 21)
			Me.cboSubLoc.TabIndex = 4
			Me.cboSubLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'txtInputVal
			'
			Me.txtInputVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtInputVal.Location = New System.Drawing.Point(8, 18)
			Me.txtInputVal.Name = "txtInputVal"
			Me.txtInputVal.Size = New System.Drawing.Size(200, 22)
			Me.txtInputVal.TabIndex = 0
			Me.txtInputVal.Text = ""
			'
			'lblLoc
			'
			Me.lblLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLoc.Location = New System.Drawing.Point(16, 8)
			Me.lblLoc.Name = "lblLoc"
			Me.lblLoc.Size = New System.Drawing.Size(72, 24)
			Me.lblLoc.TabIndex = 0
			Me.lblLoc.Text = "Location:"
			Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'lblSubLoc
			'
			Me.lblSubLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblSubLoc.Location = New System.Drawing.Point(8, 40)
			Me.lblSubLoc.Name = "lblSubLoc"
			Me.lblSubLoc.Size = New System.Drawing.Size(80, 16)
			Me.lblSubLoc.TabIndex = 3
			Me.lblSubLoc.Text = "Sub-Location:"
			Me.lblSubLoc.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'btnComplete
			'
			Me.btnComplete.BackColor = System.Drawing.Color.IndianRed
			Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnComplete.ForeColor = System.Drawing.Color.Black
			Me.btnComplete.Location = New System.Drawing.Point(576, 184)
			Me.btnComplete.Name = "btnComplete"
			Me.btnComplete.Size = New System.Drawing.Size(176, 32)
			Me.btnComplete.TabIndex = 3
			Me.btnComplete.Text = "Transfer"
			'
			'dbgDevices
			'
			Me.dbgDevices.AllowColMove = False
			Me.dbgDevices.AllowColSelect = False
			Me.dbgDevices.AllowFilter = False
			Me.dbgDevices.AllowSort = False
			Me.dbgDevices.AllowUpdate = False
			Me.dbgDevices.AlternatingRows = True
			Me.dbgDevices.BackColor = System.Drawing.Color.White
			Me.dbgDevices.CaptionHeight = 0
			Me.dbgDevices.FilterBar = True
			Me.dbgDevices.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgDevices.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.dbgDevices.Location = New System.Drawing.Point(8, 8)
			Me.dbgDevices.Name = "dbgDevices"
			Me.dbgDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgDevices.PreviewInfo.ZoomFactor = 75
			Me.dbgDevices.Size = New System.Drawing.Size(744, 168)
			Me.dbgDevices.TabIndex = 0
			Me.dbgDevices.TabStop = False
			Me.dbgDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
			"r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
			"}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
			"lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
			"}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
			"InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:Lavender;}Headi" & _
			"ng{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;Ba" & _
			"ckColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeCol" & _
			"or:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlD" & _
			"ark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}St" & _
			"yle2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False" & _
			""" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" C" & _
			"olumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""D" & _
			"ottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGrou" & _
			"p=""1"" HorizontalScrollGroup=""1""><Height>164</Height><CaptionStyle parent=""Style2" & _
			""" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent" & _
			"=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foot" & _
			"erStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" />" & _
			"<HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highligh" & _
			"tRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle " & _
			"parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""S" & _
			"tyle11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" " & _
			"me=""Style1"" /><ClientRect>0, 0, 740, 164</ClientRect><BorderSide>0</BorderSide><" & _
			"BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedS" & _
			"tyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Styl" & _
			"e parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style p" & _
			"arent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pa" & _
			"rent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pa" & _
			"rent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=" & _
			"""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style p" & _
			"arent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits" & _
			">1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><" & _
			"ClientArea>0, 0, 740, 164</ClientArea><PrintPageHeaderStyle parent="""" me=""Style2" & _
			"0"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
			'
			'lblRecNum
			'
			Me.lblRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblRecNum.ForeColor = System.Drawing.Color.DarkRed
			Me.lblRecNum.Location = New System.Drawing.Point(560, 128)
			Me.lblRecNum.Name = "lblRecNum"
			Me.lblRecNum.Size = New System.Drawing.Size(168, 24)
			Me.lblRecNum.TabIndex = 11
			Me.lblRecNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnRemoveOne
			'
			Me.btnRemoveOne.BackColor = System.Drawing.SystemColors.Control
			Me.btnRemoveOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnRemoveOne.ForeColor = System.Drawing.Color.Black
			Me.btnRemoveOne.Location = New System.Drawing.Point(8, 184)
			Me.btnRemoveOne.Name = "btnRemoveOne"
			Me.btnRemoveOne.Size = New System.Drawing.Size(176, 32)
			Me.btnRemoveOne.TabIndex = 1
			Me.btnRemoveOne.Text = "Remove One"
			'
			'btnRemoveAll
			'
			Me.btnRemoveAll.BackColor = System.Drawing.SystemColors.Control
			Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnRemoveAll.ForeColor = System.Drawing.Color.Black
			Me.btnRemoveAll.Location = New System.Drawing.Point(216, 184)
			Me.btnRemoveAll.Name = "btnRemoveAll"
			Me.btnRemoveAll.Size = New System.Drawing.Size(176, 32)
			Me.btnRemoveAll.TabIndex = 2
			Me.btnRemoveAll.Text = "Remove All"
			'
			'lblSubLocQty
			'
			Me.lblSubLocQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblSubLocQty.ForeColor = System.Drawing.Color.DarkRed
			Me.lblSubLocQty.Location = New System.Drawing.Point(416, 40)
			Me.lblSubLocQty.Name = "lblSubLocQty"
			Me.lblSubLocQty.Size = New System.Drawing.Size(112, 24)
			Me.lblSubLocQty.TabIndex = 6
			Me.lblSubLocQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnClear
			'
			Me.btnClear.BackColor = System.Drawing.SystemColors.Control
			Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClear.Location = New System.Drawing.Point(544, 88)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(64, 24)
			Me.btnClear.TabIndex = 10
			Me.btnClear.Text = "Clear"
			'
			'pnlSNs
			'
			Me.pnlSNs.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemoveAll, Me.dbgDevices, Me.btnRemoveOne, Me.btnComplete})
			Me.pnlSNs.Location = New System.Drawing.Point(0, 192)
			Me.pnlSNs.Name = "pnlSNs"
			Me.pnlSNs.Size = New System.Drawing.Size(760, 224)
			Me.pnlSNs.TabIndex = 1
			Me.pnlSNs.Visible = False
			'
			'pnlInputVal
			'
			Me.pnlInputVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.pnlInputVal.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWipLoc, Me.txtInputVal, Me.lblDevFreq})
			Me.pnlInputVal.Location = New System.Drawing.Point(104, 16)
			Me.pnlInputVal.Name = "pnlInputVal"
			Me.pnlInputVal.Size = New System.Drawing.Size(416, 64)
			Me.pnlInputVal.TabIndex = 9
			Me.pnlInputVal.Visible = False
			'
			'lblWipLoc
			'
			Me.lblWipLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWipLoc.ForeColor = System.Drawing.Color.DarkRed
			Me.lblWipLoc.Location = New System.Drawing.Point(224, 8)
			Me.lblWipLoc.Name = "lblWipLoc"
			Me.lblWipLoc.Size = New System.Drawing.Size(184, 24)
			Me.lblWipLoc.TabIndex = 1
			Me.lblWipLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblDevFreq
			'
			Me.lblDevFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDevFreq.ForeColor = System.Drawing.Color.DarkRed
			Me.lblDevFreq.Location = New System.Drawing.Point(224, 32)
			Me.lblDevFreq.Name = "lblDevFreq"
			Me.lblDevFreq.Size = New System.Drawing.Size(184, 24)
			Me.lblDevFreq.TabIndex = 2
			Me.lblDevFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'rbtnSN
			'
			Me.rbtnSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtnSN.Location = New System.Drawing.Point(8, 24)
			Me.rbtnSN.Name = "rbtnSN"
			Me.rbtnSN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Me.rbtnSN.Size = New System.Drawing.Size(80, 24)
			Me.rbtnSN.TabIndex = 7
			Me.rbtnSN.Text = "SN"
			'
			'rbtnTrayID
			'
			Me.rbtnTrayID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtnTrayID.Location = New System.Drawing.Point(8, 48)
			Me.rbtnTrayID.Name = "rbtnTrayID"
			Me.rbtnTrayID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
			Me.rbtnTrayID.Size = New System.Drawing.Size(80, 24)
			Me.rbtnTrayID.TabIndex = 8
			Me.rbtnTrayID.Text = "Tray ID"
			'
			'lblFreqInSubLoc
			'
			Me.lblFreqInSubLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblFreqInSubLoc.ForeColor = System.Drawing.Color.DarkRed
			Me.lblFreqInSubLoc.Location = New System.Drawing.Point(320, 40)
			Me.lblFreqInSubLoc.Name = "lblFreqInSubLoc"
			Me.lblFreqInSubLoc.Size = New System.Drawing.Size(72, 24)
			Me.lblFreqInSubLoc.TabIndex = 5
			Me.lblFreqInSubLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'chkNoMixFreq
			'
			Me.chkNoMixFreq.Enabled = False
			Me.chkNoMixFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.chkNoMixFreq.Location = New System.Drawing.Point(320, 8)
			Me.chkNoMixFreq.Name = "chkNoMixFreq"
			Me.chkNoMixFreq.Size = New System.Drawing.Size(208, 24)
			Me.chkNoMixFreq.TabIndex = 2
			Me.chkNoMixFreq.Text = "No Mix Frequency"
			'
			'Panel1
			'
			Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(226, Byte), CType(226, Byte), CType(226, Byte))
			Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFreqInSubLoc, Me.lblSubLocQty, Me.lblRecNum, Me.btnClear, Me.chkNoMixFreq, Me.cboLoc, Me.cboSubLoc, Me.lblLoc, Me.lblSubLoc, Me.GroupBox1})
			Me.Panel1.Location = New System.Drawing.Point(8, 8)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New System.Drawing.Size(744, 184)
			Me.Panel1.TabIndex = 0
			'
			'GroupBox1
			'
			Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnSN, Me.rbtnTrayID, Me.pnlInputVal})
			Me.GroupBox1.Location = New System.Drawing.Point(8, 72)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New System.Drawing.Size(528, 88)
			Me.GroupBox1.TabIndex = 12
			Me.GroupBox1.TabStop = False
			'
			'frmAMSWIPTransfer
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(760, 414)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.pnlSNs})
			Me.Name = "frmAMSWIPTransfer"
			Me.Text = "Messaging WIP Transfer"
			CType(Me.cboLoc, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboSubLoc, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dbgDevices, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlSNs.ResumeLayout(False)
			Me.pnlInputVal.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

		Private Sub frmAMSWIPTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim dt As DataTable
			Dim strExcldWipOwnerIDs As String = "1, 4, 5, 7, 12 "

			Try
				dt = ModManuf.GetExceptionCriteria("AMS_WIP_TRANSF_EXCLUDE_WIPOWNERIDS")
				If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Generic")) AndAlso dt.Rows(0)("Generic").ToString.Trim.Length > 0 Then strExcldWipOwnerIDs = dt.Rows(0)("Generic")
				Generic.DisposeDT(dt)

				dt = Me._objMessaging.getMessagingWIPOwnerData("1, 4, 5, 7, 12 ", "AMS_WipFlow", True)
				Misc.PopulateC1DropDownList(Me.cboLoc, dt, "wipowner_desc", "wipowner_id")
				Me.cboLoc.SelectedValue = 0
			Catch ex As Exception
				MessageBox.Show(ex.Message, "frmAMSWIPTransfer_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		Private Sub cboLoc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoc.SelectedValueChanged, cboSubLoc.SelectedValueChanged
			Dim dt As DataTable

			Try
				If sender.name = "cboLoc" Then
					If _booLoadCtrl = True Then Exit Sub

					If Not IsNothing(Me.cboLoc.DataSource) AndAlso Me.cboLoc.SelectedValue > 0 Then
						Me.cboSubLoc.DataSource = Nothing
						If Me.cboLoc.SelectedValue = 3 Then						 'In-Cell
							_booLoadCtrl = True
							dt = Me._objMessaging.getMessagingCostCenterData(True)
							Misc.PopulateC1DropDownList(Me.cboSubLoc, dt, "cc_desc", "cc_id")
						Else
							_booLoadCtrl = True
							dt = Me._objMessaging.getMessagingWIPOwnerSubLocationData(Me.cboLoc.SelectedValue, True)
							Misc.PopulateC1DropDownList(Me.cboSubLoc, dt, "wipownersubloc_desc", "wipownersubloc_id")
						End If

						If Me.cboLoc.SelectedValue = 2 Then Me.chkNoMixFreq.Enabled = True Else Me.chkNoMixFreq.Enabled = False

						Me.cboSubLoc.SelectedValue = 0
						If dt.Rows.Count > 1 Then Me.cboSubLoc.Enabled = True Else Me.cboSubLoc.Enabled = False
					End If
				ElseIf sender.name = "cboSubLoc" Then
					If _booLoadCtrl = True Then Exit Sub
					Me.lblFreqInSubLoc.Text = "" : Me.lblSubLocQty.Text = ""
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, " cboLoc_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Finally
				Generic.DisposeDT(dt)
				_booLoadCtrl = False
			End Try
		End Sub

		Private Sub cboSubLoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLoc.KeyUp, cboSubLoc.KeyUp
			Dim dt As DataTable

			Try
				If e.KeyCode = Keys.Enter Then
					If sender.name = "cboLoc" Then
						If Me.cboSubLoc.Enabled = True Then
							Me.cboSubLoc.SelectAll() : Me.cboSubLoc.Focus()
						Else
							If Not IsNothing(Me.cboLoc.DataSource) AndAlso Not IsNothing(Me.cboSubLoc.DataSource) Then
								Me.lblSubLocQty.Text = "Qty: " & Me._objMessaging.GetTmessWipLocCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
							End If
						End If
					ElseIf sender.name = "cboSubLoc" Then
						Me.lblFreqInSubLoc.Text = "" : Me.lblSubLocQty.Text = ""

						If Not IsNothing(Me.cboLoc.DataSource) AndAlso Not IsNothing(Me.cboSubLoc.DataSource) Then
							Me.lblSubLocQty.Text = "Qty: " & Me._objMessaging.GetTmessWipLocCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
						End If

						If Not IsNothing(Me.cboLoc.DataSource) AndAlso Me.cboLoc.SelectedValue > 0 AndAlso Not IsNothing(Me.cboSubLoc.DataSource) AndAlso Me.cboSubLoc.SelectedValue > 0 And Me.chkNoMixFreq.Checked Then
							dt = Me._objMessaging.GetTmessWipLocFreqCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
							If dt.Rows.Count > 1 Then
								MessageBox.Show("This location has more than one frequency. Can't select no mix frequency option.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Else
								Me.lblFreqInSubLoc.Text = dt.Rows(0)("freq_Number")
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "cboSubLoc_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		Private Sub txtSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInputVal.KeyUp
			Try
				If e.KeyCode = Keys.Enter AndAlso Me.txtInputVal.Text.Trim.Length > 0 Then
					If Me.rbtnSN.Checked Then
						Me.ProcessDevSN()
					ElseIf Me.rbtnTrayID.Checked Then
						Me.ProcessTray()
					Else
						Throw New Exception("System can't define input type.")
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub ProcessDevSN()
			Dim i As Integer = 0, iSubLocCnt As Integer = 0
			Dim strSN As String = Me.txtInputVal.Text.Trim.ToUpper
			Dim dtDevice, dtWipLocFeqCnt As DataTable
            Dim objExcelRpt As New PSS.Data.Buisness.MessReports()
            Dim objMess As New PSS.Data.Buisness.Messaging()
            Dim strCustIDs As String = "", strCustIDs_Other As String = ""
            Dim arrLstCustIDs As New ArrayList()

			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				Me.lblWipLoc.Text = "" : lblDevFreq.Text = ""

				'Validation 1
				If strSN.Length = 0 Then
					MessageBox.Show("No SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
				ElseIf Not Me.cboLoc.SelectedValue > 0 Then
					MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
				End If

                'Get Messaging Custoners for WIP data
                strCustIDs = objExcelRpt.GetAMSMessCustIDs()
                'Get other messging customers
                strCustIDs_Other = objMess.getOtherCustomers(arrLstCustIDs)

                'add Contact Wireless, A-1 Wireless Comunications, ATS
				If strCustIDs.Trim.Length > 0 Then
                    strCustIDs &= "," & SkyTel.ContactWireless_CUSTOMER_ID.ToString & "," & SkyTel.A1WirelessComm_CUSTOMER_ID.ToString & "," & SkyTel.ATS_CUSTOMER_ID
                    If strCustIDs_Other.Trim.Length > 0 Then strCustIDs &= "," & strCustIDs_Other
                Else
                    strCustIDs = SkyTel.ContactWireless_CUSTOMER_ID.ToString & "," & SkyTel.A1WirelessComm_CUSTOMER_ID.ToString & "," & SkyTel.ATS_CUSTOMER_ID
                    If strCustIDs_Other.Trim.Length > 0 Then strCustIDs &= strCustIDs_Other
                End If

                'Get WIP Data
                dtDevice = Me._objMessaging.getMessagingWIP_BySN(strCustIDs, strSN)

                'Validation 2
                If dtDevice.Rows.Count = 0 Then
                    MessageBox.Show("The device '" & strSN & "' is not in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()
                ElseIf dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("Duplicated device '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()
                Else    '=1
                    If Not dtDevice.Rows(0).Item("MD_ID") > 0 Then
                        MessageBox.Show("Invalid MD_ID in tMessData.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
                    ElseIf dtDevice.Rows(0).Item("wipowner_id") = 7 OrElse dtDevice.Rows(0).Item("wipowner_id") = 5 Then
                        MessageBox.Show("This device is in " & dtDevice.Rows(0).Item("wipowner_desc") & ". Can't process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
                    ElseIf dtDevice.Rows(0).Item("wipowner_id") = Me.cboLoc.SelectedValue AndAlso dtDevice.Rows(0).Item("wipownersubloc_id") = Me.cboSubLoc.SelectedValue Then
                        MessageBox.Show("This device has the same location and sublocation. No need to process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
                    ElseIf Not IsDBNull(dtDevice.Rows(0).Item("Pallett_ID")) AndAlso CInt(dtDevice.Rows(0).Item("Pallett_ID")) > 0 Then
                        MessageBox.Show("This device has assigned to a shipping box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
                    End If



                    Me.lblWipLoc.Text = dtDevice.Rows(0)("WIP Loc")
                    If lblWipLoc.Text = "In-Cell" Then
                        Me.lblWipLoc.Text &= "  " & dtDevice.Rows(0)("Cost Center")
                    Else
                        Me.lblWipLoc.Text &= "  " & dtDevice.Rows(0)("WIP Sub Loc")
                    End If


                    'If dtDevice.Rows(0)("WIP Sub Loc").ToString.Trim.Length > 0 Then
                    '	Me.lblWipLoc.Text &= " : " & dtDevice.Rows(0)("WIP Sub Loc").ToString
                    'End If


                    lblDevFreq.Text = dtDevice.Rows(0)("freq_Number")

                    '*************************************
                    'Check max limit of Pre-Cell sub location
                    '*************************************
                    If Me.cboLoc.SelectedValue = 2 AndAlso Me.cboSubLoc.SelectedValue > 0 Then
                        iSubLocCnt = Me._objMessaging.GetTmessWipLocCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
                        Me.lblSubLocQty.Text = "Qty: " & iSubLocCnt
                        If (iSubLocCnt + Me.dbgDevices.RowCount + dtDevice.Rows.Count) >= Me._iMaxPreCellSubLoc Then
                            MessageBox.Show("You have reached the maxium quantity of " & _iMaxPreCellSubLoc & " in sublocation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
                        End If
                    End If
                    '*************************************
                    'Check for mix frequency
                    '*************************************
                    If Me.chkNoMixFreq.Checked Then
                        If Me.dbgDevices.RowCount > 0 AndAlso CInt(Me.dbgDevices.Columns("Freq_ID").CellValue(0)) <> CInt(dtDevice.Rows(0)("Freq_ID")) Then
                            Throw New Exception("Frequency does not match. List contain frequency " & Me.dbgDevices.Columns("freq_Number").CellValue(0).ToString & " and device has frequency " & dtDevice.Rows(0)("freq_Number") & ".")
                        Else
                            dtWipLocFeqCnt = Me._objMessaging.GetTmessWipLocFreqCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
                            If dtWipLocFeqCnt.Rows.Count > 1 Then
                                Throw New Exception("This location has more than one frequency. Can't select no mix frequency option.")
                            ElseIf dtWipLocFeqCnt.Rows.Count = 1 AndAlso dtWipLocFeqCnt.Rows(0)("Freq_ID") <> dtDevice.Rows(0)("Freq_ID") Then
                                Throw New Exception("Frequency does not match. Loc has frequency " & dtDevice.Rows(0)("freq_Number").ToString & " and device has frequency " & dtWipLocFeqCnt.Rows(0)("freq_Number") & ".")
                            End If
                        End If
                    End If
                    '*************************************

                    If Me.dbgDevices.RowCount = 0 Then
                        Me._dtDevices_Ready = dtDevice
                    Else
                        Me._dtDevices_Ready = Me.dbgDevices.DataSource
                        If _dtDevices_Ready.Select("Device_SN = '" & strSN & "'").Length > 0 Then
                            MessageBox.Show("Device '" & strSN & "' is already in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
                        Else
                            Me._dtDevices_Ready.ImportRow(dtDevice.Rows(0))
                        End If
                    End If

                    With Me.dbgDevices
                        .DataSource = Me._dtDevices_Ready
                        Me.lblRecNum.Text = "Number of Devices: " & Me._dtDevices_Ready.Rows.Count.ToString

                        .Splits(0).DisplayColumns("Freq_ID").Visible = False

                        .Splits(0).DisplayColumns("Device_SN").Width = 200
                    End With

                    Me.txtInputVal.Text = ""
                End If

            Catch ex As Exception
				MessageBox.Show(ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Me.Enabled = True : Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Cursor.Current = Cursors.Default
                objExcelRpt = Nothing : objMess = Nothing
			End Try
		End Sub

		Private Sub ProcessTray()
			Dim i As Integer = 0, iSubLocCnt As Integer = 0, iTrayID As Integer = 0
			Dim dtDevice, dtWipLocFeqCnt As DataTable
			Dim objExcelRpt As New PSS.Data.Buisness.MessReports()
			Dim strCustIDs, strDevice_IDs As String
			Dim R1 As DataRow

			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				Me.lblWipLoc.Text = "" : lblDevFreq.Text = ""

				iTrayID = CInt(Me.txtInputVal.Text.Trim.ToUpper)

				'Validation 1
				If iTrayID = 0 Then
					MessageBox.Show("No input data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
				ElseIf Not Me.cboLoc.SelectedValue > 0 Then
					MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.cboLoc.SelectAll() : Me.cboLoc.Focus() : Exit Sub
				End If

				'Get WIP data
				strCustIDs = objExcelRpt.GetAMSMessCustIDs()
				dtDevice = Me._objMessaging.getMessagingWIP_ByTrayID(strCustIDs, iTrayID)

				'Validation 2
				If dtDevice.Rows.Count = 0 Then
					MessageBox.Show("Tray is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()
				Else				'=1
					If dtDevice.Select("wipowner_id = 7").Length > 0 Then
						MessageBox.Show("This tray has unit in " & dtDevice.Select("wipowner_id = 7")(0)("wipowner_desc") & ". Can't process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
					ElseIf dtDevice.Select("wipowner_id = 5").Length > 0 Then
						MessageBox.Show("This tray has unit in " & dtDevice.Select("wipowner_id = 5")(0)("wipowner_desc") & ". Can't process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						'ElseIf dtDevice.Rows(0).Item("wipowner_id") = Me.cboLoc.SelectedValue AndAlso dtDevice.Rows(0).Item("wipownersubloc_id") = Me.cboSubLoc.SelectedValue Then
						'    MessageBox.Show("This device has the same location and sublocation. No need to process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						'    Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
					ElseIf dtDevice.Select("Pallett_ID > 0 ").Length > 0 Then
						MessageBox.Show("This tray has device(s) with shipping box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
					ElseIf Me.chkNoMixFreq.Checked = True AndAlso dtDevice.Select("Freq_ID <> " & dtDevice.Rows(0)("Freq_ID")).Length > 0 Then
						MessageBox.Show("This tray has multiple frequency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
					ElseIf dtDevice.Select("device_DateShip is not null ").Length > 0 Then
						MessageBox.Show("This tray has shipped units.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
					End If

					Me.lblWipLoc.Text = ""
					If Me.chkNoMixFreq.Checked = True Then lblDevFreq.Text = dtDevice.Rows(0)("freq_Number")

					'*************************************
					'Check max limit of Pre-Cell sub location
					'*************************************
					If Me.cboLoc.SelectedValue = 2 AndAlso Me.cboSubLoc.SelectedValue > 0 Then
						iSubLocCnt = Me._objMessaging.GetTmessWipLocCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
						If (iSubLocCnt + dtDevice.Rows.Count) >= Me._iMaxPreCellSubLoc Then
							MessageBox.Show("You have reached the maxium quantity of " & _iMaxPreCellSubLoc & " in sublocation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
						End If
					End If
					'*************************************
					'Check for mix frequency
					'*************************************
					If Me.chkNoMixFreq.Checked Then
						dtWipLocFeqCnt = Me._objMessaging.GetTmessWipLocFreqCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
						If dtWipLocFeqCnt.Rows.Count > 1 Then
							Throw New Exception("This location has more than one frequency. Can't select no mix frequency option.")
						ElseIf dtWipLocFeqCnt.Rows.Count = 1 AndAlso dtWipLocFeqCnt.Rows(0)("Freq_ID") <> dtDevice.Rows(0)("Freq_ID") Then
							Throw New Exception("Frequency does not match. Loc has frequency " & dtWipLocFeqCnt.Rows(0)("freq_Number").ToString & " and device has frequency " & dtDevice.Rows(0)("freq_Number") & ".")
						End If
					End If
					'*************************************
					'Build device id list
					'*************************************
					strDevice_IDs = ""
					For Each R1 In dtDevice.Rows
						If strDevice_IDs.Trim.Length > 0 Then strDevice_IDs &= ", "
						strDevice_IDs &= R1("Device_ID").ToString
					Next R1

					'***********************************
					'Confirm message
					'***********************************
					If MessageBox.Show("Are you sure you want to move " & dtDevice.Rows.Count & " to selected location?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
					'***********************************
					'Process data
					'***********************************
					Dim strFailedMsg As String = ""
					Dim iWIPowner_ID As Integer = Me.cboLoc.SelectedValue					'WIP Location
					Dim iWIPownersubloc_ID As Integer = 0
					If Me.cboLoc.SelectedValue = 3 Then					  'In-Cell
						Dim iCC_ID As Integer = Me.cboSubLoc.SelectedValue						 'Cost Center

						i = Generic.SetTmessdataWipOwnerdataForDevices(strDevice_IDs, iWIPowner_ID, iWIPownersubloc_ID, 0)						 'Update tMessData
						If Not i > 0 Then strFailedMsg = IIf(strFailedMsg.Trim.Length = 0, " Failed to update tMessData.", strFailedMsg & Environment.NewLine & " Failed to update tMessData.")

						i = Me._objMessaging.UpdateMessagingDeviceCostCenter(strDevice_IDs, iCC_ID)						 'Update tDevice
						If Not i > 0 Then strFailedMsg = IIf(strFailedMsg.Trim.Length = 0, " Failed to update tDevice.", strFailedMsg & Environment.NewLine & " Failed to update tDevice.")
					Else
						iWIPownersubloc_ID = Me.cboSubLoc.SelectedValue						  'WIP SubLocation
						i = Generic.SetTmessdataWipOwnerdataForDevices(strDevice_IDs, iWIPowner_ID, iWIPownersubloc_ID, 0)						 'Update tMessData
						If Not i > 0 Then strFailedMsg = IIf(strFailedMsg.Trim.Length = 0, " Failed to update tMessData.", strFailedMsg & Environment.NewLine & " Failed to update tMessData.")
					End If

					If strFailedMsg.Trim.Length > 0 Then
						MessageBox.Show(strFailedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						MessageBox.Show("Successed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.None)
						Me.lblRecNum.Text = ""
						Me.dbgDevices.DataSource = Nothing
						Me._dtDevices_Ready = Nothing
						Me.lblWipLoc.Text = "" : Me.lblDevFreq.Text = ""
						If Not IsNothing(Me.cboLoc.DataSource) AndAlso Not IsNothing(Me.cboSubLoc.DataSource) Then
							Me.lblSubLocQty.Text = "Qty: " & Me._objMessaging.GetTmessWipLocCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
						End If
					End If
					'***********************************

					Me.txtInputVal.Text = ""
				End If

			Catch ex As Exception
				MessageBox.Show(ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Me.Enabled = True : Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Cursor.Current = Cursors.Default
				objExcelRpt = Nothing
			End Try
		End Sub

		Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
			Dim iTray_ID, iWIPowner_ID, iWIPownersubloc_ID As Integer, iSubLocCnt As Integer = 0
			Dim iCC_ID As Integer
			Dim iDevice_ID As Integer, i As Integer, iRow As Integer
			Dim strDevice_IDs As String = ""
			Dim dtDevices, dtWipLocFeqCnt As DataTable
			Dim row As DataRow
			Dim strMissingDevices As String = ""
			Dim bHasFound As Boolean = False
			Dim strFailedMsg As String = ""
			Dim arrlst As New ArrayList()

			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

				'Confirm message
				Dim strMsg As String = "Transfer devices to " & Me.cboLoc.SelectedText & _
				   IIf(cboSubLoc.SelectedValue > 0, " - " & Me.cboSubLoc.SelectedText, "") & " ?"

				'Validate 1
				If Not Me.cboLoc.SelectedValue > 0 Then
					MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf Me.dbgDevices.RowCount = 0 Then
					MessageBox.Show("No devices in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				Else
					'Build Device IDs list
					For iRow = 0 To Me.dbgDevices.RowCount - 1
						iDevice_ID = Me.dbgDevices.Columns("Device_ID").CellText(iRow)
						If Not iDevice_ID > 0 Then
							MessageBox.Show("Device '" & Me.dbgDevices.Columns("Device_SN").CellText(iRow) & "' has invalid device_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Exit Sub
						Else
							If strDevice_IDs.Trim.Length = 0 Then
								strDevice_IDs = iDevice_ID
							Else
								strDevice_IDs &= "," & iDevice_ID
							End If
						End If

						'Get distinct Freq_ID in the list
						If arrlst.IndexOf(Me.dbgDevices.Columns("Freq_ID").CellText(iRow)) < 0 Then arrlst.Add(Me.dbgDevices.Columns("Freq_ID").CellText(iRow))
					Next iRow

					dtDevices = Me._objMessaging.getMessagingWIP_ByDeviceIDs(strDevice_IDs)

					'Validate 2
					If Not dtDevices.Rows.Count > 0 Then
						MessageBox.Show("Can't found any WIP data for all devices in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf dtDevices.Select("Pallett_ID > 0 ").Length > 0 Then
						MessageBox.Show("Some devices have assigned to a shipping box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
					ElseIf Not dtDevices.Rows.Count = Me.dbgDevices.RowCount Then
						For iRow = 0 To Me.dbgDevices.RowCount - 1						 'check mising
							bHasFound = False
							For Each row In dtDevices.Rows
								If CInt(Me.dbgDevices.Columns("Device_ID").CellText(iRow)) = CInt(row("Device_ID")) Then
									bHasFound = True : Exit For
								End If
							Next
							If Not bHasFound Then
								If strMissingDevices.Trim.Length = 0 Then
									strMissingDevices = Me.dbgDevices.Columns("Device_SN").CellText(iRow)
								Else
									strMissingDevices &= ", " & Me.dbgDevices.Columns("Device_SN").CellText(iRow)
								End If
							End If
						Next
						MessageBox.Show("Number of WIP devices in database is not equal to number of WIP devices in the list." & Environment.NewLine & _
						  "Following device(s) can be found in database: " & Environment.NewLine & strMissingDevices, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Exit Sub
					Else
						strMissingDevices = ""
						For Each row In dtDevices.Rows
							If CInt(row("wipowner_id")) = 7 Then
								If strMissingDevices.Trim.Length = 0 Then
									strMissingDevices = row("Device_SN")
								Else
									strMissingDevices &= ", " & row("Device_SN")
								End If
							End If
						Next
						If strMissingDevices.Trim.Length > 0 Then
							MessageBox.Show("The device(s) in WIP Owner 7 (In-Transit): " & strMissingDevices, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Exit Sub
						End If
					End If

					'*************************************
					'Check max limit of sub location
					'*************************************
					If Me.cboSubLoc.SelectedValue > 0 Then
						iSubLocCnt = Me._objMessaging.GetTmessWipLocCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
						If (iSubLocCnt + Me.dbgDevices.RowCount) > Me._iMaxPreCellSubLoc Then
							MessageBox.Show("You have reached the maxium quantity of " & _iMaxPreCellSubLoc & " in sublocation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus() : Exit Sub
						End If
					End If

					If Me.chkNoMixFreq.Checked Then
						If arrlst.Count > 1 Then Throw New Exception("Multiple frequency in the list.")

						dtWipLocFeqCnt = Me._objMessaging.GetTmessWipLocFreqCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
						If dtWipLocFeqCnt.Rows.Count > 1 Then
							Throw New Exception("This location has more than one frequency. Can't select no mix frequency option.")
						ElseIf dtWipLocFeqCnt.Rows.Count = 1 AndAlso dtWipLocFeqCnt.Rows(0)("Freq_ID") <> arrlst.Item(0) Then
							Throw New Exception("Frequency does not match. Loc has frequency " & arrlst.Item(0).ToString & " and device has frequency " & dtWipLocFeqCnt.Rows(0)("freq_Number") & ".")
						End If
					End If

					'READY TO PROCESS.
					Dim _wipowner_id As Integer = Me.cboLoc.SelectedValue
					Dim _wipownersubloc_id As Integer = 0
					Dim _cc_id As Integer = 0
					Dim _dr As DataRow
					If _wipowner_id = 3 Then				' In-Cell
						_cc_id = cboSubLoc.SelectedValue
					Else
						_wipownersubloc_id = cboSubLoc.SelectedValue
					End If

					' MOVE THE DEVICES AND ADD THE DEVICE JOURNAL ENTRY.
					For Each _dr In dtDevices.Rows
						Try
							Data.BLL.MsgDeviceMovement.MoveDeviceToWIPOwner(_dr("device_id"), _wipowner_id, _wipownersubloc_id, _cc_id, "MSG WIP Transfer", Core.ApplicationUser.User)
						Catch ex As Exception
							Throw ex
						End Try
					Next

					RemoveDeviceFromList()
					MessageBox.Show("Transfer Completed!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If

			Catch ex As Exception
				MessageBox.Show(ex.Message, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dtDevices) : Generic.DisposeDT(dtWipLocFeqCnt)
				Me.Enabled = True
				Me.txtInputVal.SelectAll()
				Me.txtInputVal.Focus()
				Cursor.Current = Cursors.Default
			End Try
		End Sub

		Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
			Dim strSN As String = ""
			Dim R1 As DataRow

			Try
				Me.lblWipLoc.Text = ""
				Me._dtDevices_Ready = dbgDevices.DataSource
				If IsNothing(Me._dtDevices_Ready) OrElse Me._dtDevices_Ready.Rows.Count = 0 Then Throw New Exception("List is empty.")

				strSN = InputBox("Enter SN:").Trim.ToUpper
				If strSN.Trim.Length = 0 Then Exit Sub

				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

				If _dtDevices_Ready.Select("Device_SN = '" & strSN & "'").Length = 0 Then Throw New Exception("SN is not on the list.")

				R1 = _dtDevices_Ready.Select("Device_SN = '" & strSN & "'")(0)
				_dtDevices_Ready.Rows.Remove(R1) : _dtDevices_Ready.AcceptChanges()

				With Me.dbgDevices
					.DataSource = Me._dtDevices_Ready
					Me.lblRecNum.Text = "Number of Devices: " & Me._dtDevices_Ready.Rows.Count.ToString

					.Splits(0).DisplayColumns("Freq_ID").Visible = False

					.Splits(0).DisplayColumns("Device_SN").Width = 200
				End With

				If Me.dbgDevices.RowCount = 0 Then
					Me.lblWipLoc.Text = "" : Me.lblDevFreq.Text = ""
					Me.rbtnSN.Enabled = True : Me.rbtnTrayID.Enabled = True
				End If

				Me.Enabled = True : Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "btnRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub

		Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
			Try
				Me.lblWipLoc.Text = ""
				If MessageBox.Show("Are you sure you want to remove all SNs in the list?", _
				 "Information", MessageBoxButtons.YesNo, _
				 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = _
				 DialogResult.No Then
					Exit Sub
				End If
				Me.Enabled = False
				Cursor.Current = Cursors.WaitCursor
			Catch ex As Exception
				MessageBox.Show(ex.Message, "btnRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Me.Enabled = True
				Cursor.Current = Cursors.Default
			End Try
		End Sub

		Private Sub chkNoMixFreq_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNoMixFreq.CheckedChanged
			Dim dtWipLocFeqCnt As DataTable
			Try
				Me.lblFreqInSubLoc.Text = ""

				If Me.chkNoMixFreq.Checked AndAlso Me.cboLoc.SelectedValue > 0 AndAlso Me.cboSubLoc.SelectedValue > 0 Then
					dtWipLocFeqCnt = Me._objMessaging.GetTmessWipLocFreqCount(Me.cboLoc.SelectedValue, Me.cboSubLoc.SelectedValue)
					If dtWipLocFeqCnt.Rows.Count > 1 Then
						Throw New Exception("This location has more than one frequency. Can't select no mix frequency option.")
					Else
						Me.lblFreqInSubLoc.Text = dtWipLocFeqCnt.Rows(0)("freq_Number")
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "chkNoMixFreq_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub rbtnSN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnSN.CheckedChanged, rbtnTrayID.CheckedChanged
			Try
				Me.dbgDevices.DataSource = Nothing
				Me._dtDevices_Ready = Nothing
				Me.lblRecNum.Text = ""
				Me.lblWipLoc.Text = "" : Me.lblDevFreq.Text = ""
				If rbtnSN.Checked = False AndAlso Me.rbtnTrayID.Checked = False Then
					Me.rbtnSN.Enabled = True : Me.rbtnTrayID.Enabled = True
				Else
					Me.rbtnSN.Enabled = False : Me.rbtnTrayID.Enabled = False
				End If

				Me.pnlInputVal.Visible = True
				Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()

				If Me.rbtnSN.Checked = True Then Me.pnlSNs.Visible = True Else Me.pnlSNs.Visible = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "rbtnSN_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				If Me.rbtnSN.Checked = True OrElse Me.rbtnTrayID.Checked = True Then
					Me.txtInputVal.SelectAll() : Me.txtInputVal.Focus()
				End If
			End Try
		End Sub

		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			Try
				If Me.dbgDevices.RowCount > 0 AndAlso _
				 MessageBox.Show("Are you sure you want to clear " & Me.dbgDevices.RowCount & " unit(s) in the list?", _
				 "Information", _
				 MessageBoxButtons.YesNo, _
				 MessageBoxIcon.Question, _
				 MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				End If

				Me.Enabled = False
				Cursor.Current = Cursors.WaitCursor
				Me.dbgDevices.DataSource = Nothing
				Me._dtDevices_Ready = Nothing
				Me.lblRecNum.Text = ""
				Me.lblWipLoc.Text = ""
				Me.lblDevFreq.Text = ""
				Me.rbtnSN.Enabled = True
				Me.rbtnTrayID.Enabled = True
				Me.rbtnSN.Checked = False
				Me.rbtnTrayID.Checked = False
				Me.pnlInputVal.Visible = False
				Me.pnlSNs.Visible = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True
				Cursor.Current = Cursors.Default
				Me.txtInputVal.SelectAll()
				Me.txtInputVal.Focus()
			End Try
		End Sub

		Private Sub RemoveDeviceFromList()
			Me.dbgDevices.DataSource = Nothing
			Me._dtDevices_Ready = Nothing
			Me.lblRecNum.Text = ""
			Me.lblWipLoc.Text = ""
			Me.lblDevFreq.Text = ""
			Me.rbtnSN.Enabled = True
			Me.rbtnTrayID.Enabled = True
			Me.Enabled = True
			Me.txtInputVal.SelectAll()
			Me.txtInputVal.Focus()
		End Sub

	End Class

End Namespace
