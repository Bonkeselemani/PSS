Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Namespace Gui.Ziosk
	Public Class frmCreateWO
		Inherits System.Windows.Forms.Form

		Private _iMenuCustID As Integer = 0
		Private _iMenuProductGroupID As Integer = 0
		Private _iMenuProdID As Integer = 0
		Private _objCreateRMA As CreateRMA

#Region " Windows Form Designer generated code "

		Public Sub New(Optional ByVal iCustID As Integer = 0, Optional ByVal iProdID As Integer = 0, Optional ByVal iProdGroupID As Integer = 0)
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			_iMenuCustID = iCustID
			_iMenuProdID = iProdID
			_iMenuProductGroupID = iProdGroupID

			_objCreateRMA = New CreateRMA()
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
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents cboPO As C1.Win.C1List.C1Combo
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
		Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		Friend WithEvents rdbtnFileNo As System.Windows.Forms.RadioButton
		Friend WithEvents rdbtnFileYes As System.Windows.Forms.RadioButton
		Friend WithEvents btnCreate As System.Windows.Forms.Button
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents txtRMA As System.Windows.Forms.TextBox
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents btnBrowseData As System.Windows.Forms.Button
		Friend WithEvents dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents dbgOpenWO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents cboProdID As C1.Win.C1List.C1Combo
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents cboGroupID As C1.Win.C1List.C1Combo
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents txtWOMemo As System.Windows.Forms.TextBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCreateWO))
			Me.Label5 = New System.Windows.Forms.Label()
			Me.cboPO = New C1.Win.C1List.C1Combo()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.cboLocations = New C1.Win.C1List.C1Combo()
			Me.cboCustomers = New C1.Win.C1List.C1Combo()
			Me.GroupBox1 = New System.Windows.Forms.GroupBox()
			Me.btnBrowseData = New System.Windows.Forms.Button()
			Me.rdbtnFileNo = New System.Windows.Forms.RadioButton()
			Me.rdbtnFileYes = New System.Windows.Forms.RadioButton()
			Me.btnCreate = New System.Windows.Forms.Button()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.txtRMA = New System.Windows.Forms.TextBox()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.dbgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.dbgOpenWO = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.cboProdID = New C1.Win.C1List.C1Combo()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.cboGroupID = New C1.Win.C1List.C1Combo()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.txtWOMemo = New System.Windows.Forms.TextBox()
			CType(Me.cboPO, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dbgData, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dbgOpenWO, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboProdID, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboGroupID, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'Label5
			'
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
			Me.Label5.Location = New System.Drawing.Point(363, 136)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(64, 16)
			Me.Label5.TabIndex = 20
			Me.Label5.Text = "(Optional)"
			'
			'cboPO
			'
			Me.cboPO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboPO.Caption = ""
			Me.cboPO.CaptionHeight = 17
			Me.cboPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboPO.ColumnCaptionHeight = 17
			Me.cboPO.ColumnFooterHeight = 17
			Me.cboPO.ContentHeight = 15
			Me.cboPO.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboPO.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboPO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboPO.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboPO.EditorHeight = 15
			Me.cboPO.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboPO.ItemHeight = 15
			Me.cboPO.Location = New System.Drawing.Point(112, 136)
			Me.cboPO.MatchEntryTimeout = CType(2000, Long)
			Me.cboPO.MaxDropDownItems = CType(5, Short)
			Me.cboPO.MaxLength = 32767
			Me.cboPO.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboPO.Name = "cboPO"
			Me.cboPO.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboPO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboPO.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboPO.Size = New System.Drawing.Size(248, 21)
			Me.cboPO.TabIndex = 5
			Me.cboPO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.ForeColor = System.Drawing.Color.White
			Me.Label4.Location = New System.Drawing.Point(8, 136)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(96, 16)
			Me.Label4.TabIndex = 19
			Me.Label4.Text = "PO #:"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboLocations
			'
			Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboLocations.Caption = ""
			Me.cboLocations.CaptionHeight = 17
			Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboLocations.ColumnCaptionHeight = 17
			Me.cboLocations.ColumnFooterHeight = 17
			Me.cboLocations.ContentHeight = 15
			Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboLocations.EditorHeight = 15
			Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboLocations.ItemHeight = 15
			Me.cboLocations.Location = New System.Drawing.Point(112, 72)
			Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
			Me.cboLocations.MaxDropDownItems = CType(5, Short)
			Me.cboLocations.MaxLength = 32767
			Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboLocations.Name = "cboLocations"
			Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboLocations.Size = New System.Drawing.Size(248, 21)
			Me.cboLocations.TabIndex = 3
			Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'cboCustomers
			'
			Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboCustomers.Caption = ""
			Me.cboCustomers.CaptionHeight = 17
			Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboCustomers.ColumnCaptionHeight = 17
			Me.cboCustomers.ColumnFooterHeight = 17
			Me.cboCustomers.ContentHeight = 15
			Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboCustomers.EditorHeight = 15
			Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.cboCustomers.ItemHeight = 15
			Me.cboCustomers.Location = New System.Drawing.Point(112, 40)
			Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
			Me.cboCustomers.MaxDropDownItems = CType(5, Short)
			Me.cboCustomers.MaxLength = 32767
			Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboCustomers.Name = "cboCustomers"
			Me.cboCustomers.ReadOnly = True
			Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboCustomers.Size = New System.Drawing.Size(248, 21)
			Me.cboCustomers.TabIndex = 2
			Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'GroupBox1
			'
			Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBrowseData, Me.rdbtnFileNo, Me.rdbtnFileYes})
			Me.GroupBox1.Enabled = False
			Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.GroupBox1.ForeColor = System.Drawing.Color.White
			Me.GroupBox1.Location = New System.Drawing.Point(8, 232)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New System.Drawing.Size(248, 48)
			Me.GroupBox1.TabIndex = 8
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Came With Data File?"
			'
			'btnBrowseData
			'
			Me.btnBrowseData.BackColor = System.Drawing.Color.DarkSlateGray
			Me.btnBrowseData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnBrowseData.ForeColor = System.Drawing.Color.White
			Me.btnBrowseData.Location = New System.Drawing.Point(68, 21)
			Me.btnBrowseData.Name = "btnBrowseData"
			Me.btnBrowseData.Size = New System.Drawing.Size(80, 19)
			Me.btnBrowseData.TabIndex = 2
			Me.btnBrowseData.Text = "Browse Data"
			Me.btnBrowseData.Visible = False
			'
			'rdbtnFileNo
			'
			Me.rdbtnFileNo.Checked = True
			Me.rdbtnFileNo.Location = New System.Drawing.Point(189, 24)
			Me.rdbtnFileNo.Name = "rdbtnFileNo"
			Me.rdbtnFileNo.Size = New System.Drawing.Size(43, 16)
			Me.rdbtnFileNo.TabIndex = 1
			Me.rdbtnFileNo.TabStop = True
			Me.rdbtnFileNo.Text = "NO"
			'
			'rdbtnFileYes
			'
			Me.rdbtnFileYes.Location = New System.Drawing.Point(16, 24)
			Me.rdbtnFileYes.Name = "rdbtnFileYes"
			Me.rdbtnFileYes.Size = New System.Drawing.Size(48, 16)
			Me.rdbtnFileYes.TabIndex = 0
			Me.rdbtnFileYes.Text = "YES"
			'
			'btnCreate
			'
			Me.btnCreate.BackColor = System.Drawing.Color.Green
			Me.btnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCreate.ForeColor = System.Drawing.Color.White
			Me.btnCreate.Location = New System.Drawing.Point(264, 240)
			Me.btnCreate.Name = "btnCreate"
			Me.btnCreate.Size = New System.Drawing.Size(152, 40)
			Me.btnCreate.TabIndex = 9
			Me.btnCreate.Text = "CREATE WORK ORDER"
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.ForeColor = System.Drawing.Color.White
			Me.Label3.Location = New System.Drawing.Point(8, 200)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(96, 16)
			Me.Label3.TabIndex = 15
			Me.Label3.Text = "RMA/WO: "
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtRMA
			'
			Me.txtRMA.Location = New System.Drawing.Point(112, 200)
			Me.txtRMA.Name = "txtRMA"
			Me.txtRMA.Size = New System.Drawing.Size(312, 20)
			Me.txtRMA.TabIndex = 7
			Me.txtRMA.Text = ""
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.White
			Me.Label2.Location = New System.Drawing.Point(8, 72)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(96, 16)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "Location:"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.White
			Me.Label1.Location = New System.Drawing.Point(8, 40)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(96, 16)
			Me.Label1.TabIndex = 10
			Me.Label1.Text = "Customer:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'dbgData
			'
			Me.dbgData.AlternatingRows = True
			Me.dbgData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.dbgData.Caption = "ASN Data"
			Me.dbgData.FilterBar = True
			Me.dbgData.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgData.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
			Me.dbgData.Location = New System.Drawing.Point(432, 8)
			Me.dbgData.Name = "dbgData"
			Me.dbgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgData.PreviewInfo.ZoomFactor = 75
			Me.dbgData.Size = New System.Drawing.Size(512, 472)
			Me.dbgData.TabIndex = 21
			Me.dbgData.Text = "C1TrueDBGrid1"
			Me.dbgData.Visible = False
			Me.dbgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:White;BackColor" & _
			":CadetBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inacti" & _
			"ve{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}C" & _
			"aption{AlignHorz:Center;ForeColor:White;BackColor:CadetBlue;}Style9{}Normal{Font" & _
			":Microsoft Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;" & _
			"BackColor:Highlight;}Style14{}OddRow{ForeColor:White;BackColor:SteelBlue;}Record" & _
			"Selector{AlignImage:Center;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:R" & _
			"aised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{Align" & _
			"Horz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1" & _
			"TrueDBGrid.MergeView HBarHeight=""12"" Name="""" AlternatingRowStyle=""True"" CaptionH" & _
			"eight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Mar" & _
			"queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
			"alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>451</Height><CaptionStyle pa" & _
			"rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
			"Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
			"e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
			"""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
			"nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
			"OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
			"ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
			"nt=""Normal"" me=""Style1"" /><ClientRect>0, 17, 508, 451</ClientRect><BorderSide>0<" & _
			"/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></S" & _
			"plits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Hea" & _
			"ding"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Captio" & _
			"n"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected" & _
			""" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow" & _
			""" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><" & _
			"Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBa" & _
			"r"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplit" & _
			"s><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Default" & _
			"RecSelWidth><ClientArea>0, 0, 508, 468</ClientArea><PrintPageHeaderStyle parent=" & _
			""""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
			'
			'dbgOpenWO
			'
			Me.dbgOpenWO.AlternatingRows = True
			Me.dbgOpenWO.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.dbgOpenWO.Caption = "Open Work Order"
			Me.dbgOpenWO.FilterBar = True
			Me.dbgOpenWO.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgOpenWO.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
			Me.dbgOpenWO.Location = New System.Drawing.Point(8, 288)
			Me.dbgOpenWO.Name = "dbgOpenWO"
			Me.dbgOpenWO.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgOpenWO.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgOpenWO.PreviewInfo.ZoomFactor = 75
			Me.dbgOpenWO.Size = New System.Drawing.Size(408, 192)
			Me.dbgOpenWO.TabIndex = 22
			Me.dbgOpenWO.Text = "C1TrueDBGrid1"
			Me.dbgOpenWO.Visible = False
			Me.dbgOpenWO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:White;BackColor" & _
			":SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inacti" & _
			"ve{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}C" & _
			"aption{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style" & _
			"=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow" & _
			"{ForeColor:White;BackColor:SlateGray;}RecordSelector{AlignImage:Center;}Style13{" & _
			"}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Control" & _
			"Text;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15" & _
			"{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""12""" & _
			" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
			"ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
			"electorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
			"oup=""1""><Height>171</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Editor" & _
			"Style parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /" & _
			"><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" " & _
			"me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""He" & _
			"ading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Ina" & _
			"ctiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Styl" & _
			"e9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle" & _
			" parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRec" & _
			"t>0, 17, 404, 171</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bor" & _
			"derStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" " & _
			"me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""" & _
			"Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Ina" & _
			"ctive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edito" & _
			"r"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenR" & _
			"ow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSel" & _
			"ector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Gro" & _
			"up"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>" & _
			"None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 404, 1" & _
			"88</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterSt" & _
			"yle parent="""" me=""Style15"" /></Blob>"
			'
			'cboProdID
			'
			Me.cboProdID.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboProdID.Caption = ""
			Me.cboProdID.CaptionHeight = 17
			Me.cboProdID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboProdID.ColumnCaptionHeight = 17
			Me.cboProdID.ColumnFooterHeight = 17
			Me.cboProdID.ContentHeight = 15
			Me.cboProdID.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboProdID.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboProdID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboProdID.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboProdID.EditorHeight = 15
			Me.cboProdID.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
			Me.cboProdID.ItemHeight = 15
			Me.cboProdID.Location = New System.Drawing.Point(112, 8)
			Me.cboProdID.MatchEntryTimeout = CType(2000, Long)
			Me.cboProdID.MaxDropDownItems = CType(5, Short)
			Me.cboProdID.MaxLength = 32767
			Me.cboProdID.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboProdID.Name = "cboProdID"
			Me.cboProdID.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboProdID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboProdID.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboProdID.Size = New System.Drawing.Size(248, 21)
			Me.cboProdID.TabIndex = 1
			Me.cboProdID.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label6
			'
			Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.ForeColor = System.Drawing.Color.White
			Me.Label6.Location = New System.Drawing.Point(0, 8)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(104, 16)
			Me.Label6.TabIndex = 24
			Me.Label6.Text = "Product Type:"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboGroupID
			'
			Me.cboGroupID.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboGroupID.Caption = ""
			Me.cboGroupID.CaptionHeight = 17
			Me.cboGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboGroupID.ColumnCaptionHeight = 17
			Me.cboGroupID.ColumnFooterHeight = 17
			Me.cboGroupID.ContentHeight = 15
			Me.cboGroupID.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboGroupID.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboGroupID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboGroupID.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboGroupID.EditorHeight = 15
			Me.cboGroupID.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
			Me.cboGroupID.ItemHeight = 15
			Me.cboGroupID.Location = New System.Drawing.Point(112, 104)
			Me.cboGroupID.MatchEntryTimeout = CType(2000, Long)
			Me.cboGroupID.MaxDropDownItems = CType(5, Short)
			Me.cboGroupID.MaxLength = 32767
			Me.cboGroupID.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboGroupID.Name = "cboGroupID"
			Me.cboGroupID.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboGroupID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboGroupID.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboGroupID.Size = New System.Drawing.Size(248, 21)
			Me.cboGroupID.TabIndex = 4
			Me.cboGroupID.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label7
			'
			Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.ForeColor = System.Drawing.Color.White
			Me.Label7.Location = New System.Drawing.Point(0, 104)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(104, 16)
			Me.Label7.TabIndex = 26
			Me.Label7.Text = "Production Group:"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'Label8
			'
			Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label8.ForeColor = System.Drawing.Color.White
			Me.Label8.Location = New System.Drawing.Point(8, 168)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(96, 15)
			Me.Label8.TabIndex = 28
			Me.Label8.Text = "RMA/WO Memo: "
			Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtWOMemo
			'
			Me.txtWOMemo.Location = New System.Drawing.Point(112, 168)
			Me.txtWOMemo.Name = "txtWOMemo"
			Me.txtWOMemo.Size = New System.Drawing.Size(312, 20)
			Me.txtWOMemo.TabIndex = 6
			Me.txtWOMemo.Text = ""
			'
			'frmCreateWO
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(960, 509)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.txtWOMemo, Me.cboGroupID, Me.Label7, Me.cboProdID, Me.Label6, Me.dbgOpenWO, Me.dbgData, Me.Label5, Me.cboPO, Me.Label4, Me.cboLocations, Me.cboCustomers, Me.GroupBox1, Me.btnCreate, Me.Label3, Me.txtRMA, Me.Label2, Me.Label1})
			Me.Name = "frmCreateWO"
			Me.Text = "Ziosk - Create Work Order"
			CType(Me.cboPO, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			CType(Me.dbgData, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dbgOpenWO, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboProdID, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboGroupID, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

		'********************************************************************************
		Private Sub frmGPCreateWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim dt As DataTable

			Try
				'Populate product type
				dt = Generic.GetProducts(True)
				Misc.PopulateC1DropDownList(Me.cboProdID, dt, "Prod_Desc", "Prod_ID")
				If _iMenuProdID > 0 Then
					Me.cboProdID.SelectedValue = _iMenuProdID : Me.cboProdID.Enabled = False
				Else
					Me.cboProdID.SelectedValue = 0
				End If

				'Populate Customer
				If _iMenuCustID > 0 Then
					dt = Generic.GetCustomers(True, )
					Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
					Me.cboCustomers.SelectedValue = _iMenuCustID
					Me.cboCustomers.Enabled = False

					'Populate Location
					Generic.DisposeDT(dt)
					dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
					Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
					If dt.Rows.Count = 2 Then
						Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
						Me.cboLocations.Enabled = False

						'Populate PO
						Generic.DisposeDT(dt)
						dt = Generic.GetPOs(True, Me.cboLocations.SelectedValue)
						Misc.PopulateC1DropDownList(Me.cboPO, dt, "PO_Desc", "PO_ID")
						Me.cboPO.SelectedValue = 0
					End If
				End If

				'Populate production Group
				Generic.DisposeDT(dt)
				dt = Generic.GetMasterGroupsList(True, )
				Misc.PopulateC1DropDownList(Me.cboGroupID, dt, "Group_Desc", "Group_ID")
				If _iMenuProductGroupID > 0 Then
					Me.cboGroupID.SelectedValue = _iMenuProductGroupID : Me.cboGroupID.Enabled = False
				ElseIf _iMenuCustID > 0 AndAlso dt.Select("Cust_ID = " & _iMenuCustID).Length > 0 Then
					Me.cboGroupID.SelectedValue = dt.Select("Cust_ID = " & _iMenuCustID)(0)("Group_ID")
				Else
					Me.cboGroupID.SelectedValue = 0
				End If

				Me.cboProdID.Focus()

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'********************************************************************************
		Private Sub LoadOpenRMA(ByVal iLocID As Integer, ByVal iProdID As Integer)
			Dim dt As DataTable
			Dim i As Integer = 0

			Try
				dt = Me._objCreateRMA.GetOpenRMA(iLocID, iProdID)
				With Me.dbgOpenWO
					.DataSource = Nothing
					.DataSource = dt.DefaultView

					For i = 0 To dt.Columns.Count - 1
						.Splits(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
						If dt.Columns(i).Caption.EndsWith("Qty") Then .Splits(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
					Next i

					.Splits(0).DisplayColumns("RMA/WO").Width = 100
					.Splits(0).DisplayColumns("RMA Date").Width = 90
					.Splits(0).DisplayColumns("File Qty").Width = 80
					.Splits(0).DisplayColumns("Receipt Qty").Width = 80
					.Splits(0).DisplayColumns("PO ID").Width = 60
					.Splits(0).DisplayColumns("Assign To Group").Width = 130
					.Splits(0).DisplayColumns("ASN File?").Width = 80

				End With

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'********************************************************************************
		Private Sub cboProdID_cboCustomers_cboLocations_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProdID.Enter, cboCustomers.Enter, cboLocations.Enter
			Try
				Me.txtRMA.Text = ""
				Me.txtWOMemo.Text = ""

				If Not IsNothing(Me.cboGroupID.DataSource) Then Me.cboGroupID.SelectedValue = 0

				If sender.name = "cboProdID" Then
					If Me._iMenuCustID > 0 Then
						If Me.cboLocations.Enabled = True Then If Not IsNothing(Me.cboPO) Then Me.cboPO.DataSource = Nothing
					Else
						If Not IsNothing(Me.cboCustomers.DataSource) Then
							Me.cboCustomers.DataSource = Nothing
							Me.cboCustomers.Text = ""
						End If
						If Not IsNothing(Me.cboLocations.DataSource) Then
							Me.cboLocations.DataSource = Nothing
							Me.cboLocations.Text = ""
						End If
						If Not IsNothing(Me.cboPO.DataSource) Then
							Me.cboPO.DataSource = Nothing
							Me.cboPO.Text = ""
						End If
					End If
					Me.cboProdID.SelectAll()
				ElseIf sender.name = "cboCustomers" Then
					If Not IsNothing(Me.cboLocations.DataSource) Then
						Me.cboLocations.DataSource = Nothing
						Me.cboLocations.Text = ""
					End If
					If Not IsNothing(Me.cboPO.DataSource) Then
						Me.cboPO.DataSource = Nothing
						Me.cboPO.Text = ""
					End If
					Me.cboCustomers.SelectAll()
				ElseIf sender.name = "cboLocations" Then
					If Not IsNothing(Me.cboPO.DataSource) Then
						Me.cboPO.DataSource = Nothing
						Me.cboPO.Text = ""
					End If
					Me.cboLocations.SelectAll()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "EnterEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'********************************************************************************
		Private Sub cboProdID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProdID.KeyUp
			Dim dt As DataTable

			Try
				If e.KeyCode = Keys.Enter Then
					If Me.cboProdID.SelectedValue > 0 Then
						If Me._iMenuCustID = 0 Then
							dt = Generic.GetCustomers(True, Me.cboProdID.SelectedValue)
							Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
							Me.cboCustomers.SelectedValue = 0
							Me.cboCustomers.SelectAll()
							Me.cboCustomers.Focus()
						Else
							If Me.cboLocations.Enabled = False Then
								If Not IsNothing(Me.cboPO.DataSource) Then Me.cboPO.DataSource = Nothing
								Me.cboLocations.SelectAll()
								Me.cboLocations.Focus()
							Else
								Me.cboGroupID.SelectAll()
								Me.cboGroupID.Focus()
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboProdID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'********************************************************************************
		Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
			Dim dtLoc, dtPO As DataTable
			Try
				If e.KeyCode = Keys.Enter Then
					If Me.cboProdID.SelectedValue > 0 AndAlso Me.cboCustomers.SelectedValue > 0 Then
						dtLoc = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
						Misc.PopulateC1DropDownList(Me.cboLocations, dtLoc, "Loc_Name", "Loc_ID")
						If dtLoc.Rows.Count = 2 Then
							Me.cboLocations.SelectedValue = dtLoc.Rows(0)("Loc_ID")

							'**********************************
							'Populate PO
							'**********************************
							dtPO = Generic.GetPOs(True, Me.cboLocations.SelectedValue)
							Misc.PopulateC1DropDownList(Me.cboPO, dtPO, "PO_Desc", "PO_ID")
							Me.cboPO.SelectedValue = 0
							Me.cboGroupID.SelectAll()
							Me.cboGroupID.Focus()
							'**********************************
						Else
							Me.cboLocations.SelectedValue = 0
							Me.cboLocations.Focus()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dtLoc)
				Generic.DisposeDT(dtPO)
			End Try
		End Sub

		'********************************************************************************
		Private Sub cboLocations_cboGroupID_cboPO_txtWOMemo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocations.KeyUp, cboGroupID.KeyUp, cboPO.KeyUp, txtWOMemo.KeyUp
			Dim dt As DataTable
			Try
				If e.KeyCode = Keys.Enter Then
					If sender.name = "cboLocations" Then
						If Me.cboProdID.SelectedValue = 0 Then
							MessageBox.Show("Please select Product Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Me.cboProdID.Focus()
						ElseIf Me.cboLocations.SelectedValue > 0 Then
							Me.LoadOpenRMA(Me.cboLocations.SelectedValue, Me.cboProdID.SelectedValue)
							dt = Generic.GetPOs(True, Me.cboLocations.SelectedValue)
							Misc.PopulateC1DropDownList(Me.cboLocations, dt, "PO_Desc", "PO_ID")
							Me.cboPO.SelectedValue = 0
							Me.cboGroupID.SelectAll()
							Me.cboGroupID.Focus()
						End If
					ElseIf sender.name = "cboGroupID" Then
						Me.cboGroupID.SelectAll()
						Me.cboPO.Focus()
					ElseIf sender.name = "cboPO" Then
						Me.txtWOMemo.SelectAll()
						Me.txtWOMemo.Focus()
					ElseIf sender.name = "txtWOMemo" Then
						Me.txtRMA.SelectAll()
						Me.txtRMA.Focus()
					ElseIf sender.name = "txtRMA" And Me.txtRMA.Text.Trim.Length > 0 Then
						If Me.cboLocations.SelectedValue = 0 Then
							MessageBox.Show("Please select Location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Me.cboLocations.SelectAll()
							Me.cboLocations.Focus()
						Else
							dt = Me._objCreateRMA.GetRMA(Me.txtRMA.Text.Trim, Me.cboLocations.SelectedValue)
							If dt.Rows.Count > 0 Then
								MessageBox.Show("RMA is already existed for selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Me.txtRMA.SelectAll()
							End If
						End If						 'Location must be selected
					End If				   'Controls name
				End If				 'Enter Key pressed
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'********************************************************************************
		Private Sub rdbtnFileYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbtnFileYes.CheckedChanged
			Try
				Me.dbgData.DataSource = Nothing
				If Me.rdbtnFileYes.Checked = True Then
					Me.btnBrowseData.Visible = True
				Else
					Me.btnBrowseData.Visible = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "rdbtnFileYes_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'********************************************************************************
		'NEED TO COMEBACK LATER
		Private Sub btnBrowseData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseData.Click
			Try
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBrowseData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'********************************************************************************
		Private Sub txtRMA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRMA.KeyUp
			Try
				If e.KeyCode = Keys.Enter Then Me.ProcessWO()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtRMA_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'********************************************************************************
		Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
			Try
				Me.ProcessWO()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnCreate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'********************************************************************************
		Private Function ProcessWO() As Boolean
			Dim iCameWithFile As Integer = 0
			Dim i As Integer = 0

			Try
				If Me.cboProdID.SelectedValue = 0 Then
					MessageBox.Show("Please select product type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.cboProdID.SelectAll()
					Me.cboProdID.Focus()
				ElseIf Me.cboCustomers.SelectedValue = 0 Then
					MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.cboCustomers.SelectAll()
					Me.cboCustomers.Focus()
				ElseIf Me.cboLocations.SelectedValue = 0 Then
					MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.cboLocations.SelectAll()
					Me.cboLocations.Focus()
				ElseIf Me.txtRMA.Text.Trim.Length = 0 Then
					MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtRMA.SelectAll()
					Me.txtRMA.Focus()
				ElseIf _objCreateRMA.GetRMA(Me.txtRMA.Text.Trim, Me.cboLocations.SelectedValue).Rows.Count > 0 Then
					MessageBox.Show("RMA/WO existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtRMA.SelectAll()
					Me.txtRMA.Focus()
				Else
					Me.Enabled = False
					Cursor.Current = Cursors.WaitCursor

					If Me.rdbtnFileYes.Checked = True Then iCameWithFile = 1

					i = _objCreateRMA.CreateNewRMA(Me.cboLocations.SelectedValue, Me.txtRMA.Text.Trim, Me.cboPO.SelectedValue, iCameWithFile, Me.cboProdID.SelectedValue, Me.cboGroupID.SelectedValue, ApplicationUser.User, ApplicationUser.IDuser, )

					If i > 0 Then
						MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						Me.Enabled = True
						Me.txtRMA.Text = ""
						Me.txtRMA.Focus()
					End If
				End If				'Validation
			Catch ex As Exception
				Throw ex
			Finally
				Me.Enabled = True
				Cursor.Current = Cursors.Default
			End Try
		End Function

		'********************************************************************************

	End Class
End Namespace