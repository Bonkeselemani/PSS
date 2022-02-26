Option Explicit On 
Imports PSS.Data.Buisness
Imports PSS.Data.Buisness.Generic

Namespace Gui.PIP
    Public Class frmPIPModelUPH
        Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			_objCC = New IncentivePrg()
		End Sub

		'Form overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not (components Is Nothing) Then
					components.Dispose()
					_objCC = Nothing
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		Friend WithEvents cboGroups As C1.Win.C1List.C1Combo
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents cboWorkAreas As C1.Win.C1List.C1Combo
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents cboModels As C1.Win.C1List.C1Combo
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents txtTier1 As System.Windows.Forms.TextBox
		Friend WithEvents btnAdd As System.Windows.Forms.Button
		Friend WithEvents btnUpdate As System.Windows.Forms.Button
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents txtTier2 As System.Windows.Forms.TextBox
		Friend WithEvents dbgGroupModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
		Friend WithEvents btnCopyAll As System.Windows.Forms.Button
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents Label11 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents pnlUPH As System.Windows.Forms.Panel
		Friend WithEvents pnlDispUPH As System.Windows.Forms.Panel
		Friend WithEvents cbSplitByDisp As System.Windows.Forms.CheckBox
		Friend WithEvents txt_fun_tier1 As System.Windows.Forms.TextBox
		Friend WithEvents txt_sof_tier1 As System.Windows.Forms.TextBox
		Friend WithEvents txt_sof_tier2 As System.Windows.Forms.TextBox
		Friend WithEvents txt_cos_tier2 As System.Windows.Forms.TextBox
		Friend WithEvents txt_ntf_tier2 As System.Windows.Forms.TextBox
		Friend WithEvents txt_cos_tier1 As System.Windows.Forms.TextBox
		Friend WithEvents txt_ntf_tier1 As System.Windows.Forms.TextBox
		Friend WithEvents txt_fun_tier2 As System.Windows.Forms.TextBox
		Friend WithEvents Label6 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPIPModelUPH))
			Me.GroupBox1 = New System.Windows.Forms.GroupBox()
			Me.pnlDispUPH = New System.Windows.Forms.Panel()
			Me.Label9 = New System.Windows.Forms.Label()
			Me.txt_fun_tier1 = New System.Windows.Forms.TextBox()
			Me.txt_sof_tier1 = New System.Windows.Forms.TextBox()
			Me.Label11 = New System.Windows.Forms.Label()
			Me.txt_sof_tier2 = New System.Windows.Forms.TextBox()
			Me.txt_cos_tier2 = New System.Windows.Forms.TextBox()
			Me.txt_ntf_tier2 = New System.Windows.Forms.TextBox()
			Me.txt_cos_tier1 = New System.Windows.Forms.TextBox()
			Me.txt_ntf_tier1 = New System.Windows.Forms.TextBox()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.Label10 = New System.Windows.Forms.Label()
			Me.txt_fun_tier2 = New System.Windows.Forms.TextBox()
			Me.cbSplitByDisp = New System.Windows.Forms.CheckBox()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.btnUpdate = New System.Windows.Forms.Button()
			Me.btnAdd = New System.Windows.Forms.Button()
			Me.cboModels = New C1.Win.C1List.C1Combo()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.cboWorkAreas = New C1.Win.C1List.C1Combo()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.cboGroups = New C1.Win.C1List.C1Combo()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.btnCopySelectedRows = New System.Windows.Forms.Button()
			Me.btnCopyAll = New System.Windows.Forms.Button()
			Me.pnlUPH = New System.Windows.Forms.Panel()
			Me.txtTier1 = New System.Windows.Forms.TextBox()
			Me.txtTier2 = New System.Windows.Forms.TextBox()
			Me.dbgGroupModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.GroupBox1.SuspendLayout()
			Me.pnlDispUPH.SuspendLayout()
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboWorkAreas, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboGroups, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlUPH.SuspendLayout()
			CType(Me.dbgGroupModel, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'GroupBox1
			'
			Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDispUPH, Me.cbSplitByDisp, Me.Label6, Me.btnClear, Me.btnUpdate, Me.btnAdd, Me.cboModels, Me.Label2, Me.cboWorkAreas, Me.Label1, Me.cboGroups, Me.Label5, Me.Label3, Me.Label4, Me.btnCopySelectedRows, Me.btnCopyAll, Me.pnlUPH})
			Me.GroupBox1.Location = New System.Drawing.Point(9, 0)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New System.Drawing.Size(967, 152)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			'
			'pnlDispUPH
			'
			Me.pnlDispUPH.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.txt_fun_tier1, Me.txt_sof_tier1, Me.Label11, Me.txt_sof_tier2, Me.txt_cos_tier2, Me.txt_ntf_tier2, Me.txt_cos_tier1, Me.txt_ntf_tier1, Me.Label8, Me.Label10, Me.txt_fun_tier2})
			Me.pnlDispUPH.Location = New System.Drawing.Point(480, 32)
			Me.pnlDispUPH.Name = "pnlDispUPH"
			Me.pnlDispUPH.Size = New System.Drawing.Size(232, 96)
			Me.pnlDispUPH.TabIndex = 10
			'
			'Label9
			'
			Me.Label9.BackColor = System.Drawing.Color.Transparent
			Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label9.ForeColor = System.Drawing.Color.White
			Me.Label9.Location = New System.Drawing.Point(8, 24)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New System.Drawing.Size(72, 19)
			Me.Label9.TabIndex = 3
			Me.Label9.Text = "Functional"
			Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txt_fun_tier1
			'
			Me.txt_fun_tier1.Location = New System.Drawing.Point(88, 24)
			Me.txt_fun_tier1.MaxLength = 5
			Me.txt_fun_tier1.Name = "txt_fun_tier1"
			Me.txt_fun_tier1.Size = New System.Drawing.Size(56, 20)
			Me.txt_fun_tier1.TabIndex = 4
			Me.txt_fun_tier1.Text = ""
			Me.txt_fun_tier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txt_sof_tier1
			'
			Me.txt_sof_tier1.Location = New System.Drawing.Point(88, 0)
			Me.txt_sof_tier1.MaxLength = 5
			Me.txt_sof_tier1.Name = "txt_sof_tier1"
			Me.txt_sof_tier1.Size = New System.Drawing.Size(56, 20)
			Me.txt_sof_tier1.TabIndex = 1
			Me.txt_sof_tier1.Text = ""
			Me.txt_sof_tier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'Label11
			'
			Me.Label11.BackColor = System.Drawing.Color.Transparent
			Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label11.ForeColor = System.Drawing.Color.White
			Me.Label11.Location = New System.Drawing.Point(8, 72)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New System.Drawing.Size(72, 19)
			Me.Label11.TabIndex = 9
			Me.Label11.Text = "NTF"
			Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txt_sof_tier2
			'
			Me.txt_sof_tier2.Location = New System.Drawing.Point(168, 0)
			Me.txt_sof_tier2.MaxLength = 5
			Me.txt_sof_tier2.Name = "txt_sof_tier2"
			Me.txt_sof_tier2.Size = New System.Drawing.Size(56, 20)
			Me.txt_sof_tier2.TabIndex = 2
			Me.txt_sof_tier2.Text = ""
			Me.txt_sof_tier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txt_cos_tier2
			'
			Me.txt_cos_tier2.Location = New System.Drawing.Point(168, 48)
			Me.txt_cos_tier2.MaxLength = 5
			Me.txt_cos_tier2.Name = "txt_cos_tier2"
			Me.txt_cos_tier2.Size = New System.Drawing.Size(56, 20)
			Me.txt_cos_tier2.TabIndex = 8
			Me.txt_cos_tier2.Text = ""
			Me.txt_cos_tier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txt_ntf_tier2
			'
			Me.txt_ntf_tier2.Location = New System.Drawing.Point(168, 72)
			Me.txt_ntf_tier2.MaxLength = 5
			Me.txt_ntf_tier2.Name = "txt_ntf_tier2"
			Me.txt_ntf_tier2.Size = New System.Drawing.Size(56, 20)
			Me.txt_ntf_tier2.TabIndex = 11
			Me.txt_ntf_tier2.Text = ""
			Me.txt_ntf_tier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txt_cos_tier1
			'
			Me.txt_cos_tier1.Location = New System.Drawing.Point(88, 48)
			Me.txt_cos_tier1.MaxLength = 5
			Me.txt_cos_tier1.Name = "txt_cos_tier1"
			Me.txt_cos_tier1.Size = New System.Drawing.Size(56, 20)
			Me.txt_cos_tier1.TabIndex = 7
			Me.txt_cos_tier1.Text = ""
			Me.txt_cos_tier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txt_ntf_tier1
			'
			Me.txt_ntf_tier1.Location = New System.Drawing.Point(88, 72)
			Me.txt_ntf_tier1.MaxLength = 5
			Me.txt_ntf_tier1.Name = "txt_ntf_tier1"
			Me.txt_ntf_tier1.Size = New System.Drawing.Size(56, 20)
			Me.txt_ntf_tier1.TabIndex = 10
			Me.txt_ntf_tier1.Text = ""
			Me.txt_ntf_tier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'Label8
			'
			Me.Label8.BackColor = System.Drawing.Color.Transparent
			Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label8.ForeColor = System.Drawing.Color.White
			Me.Label8.Location = New System.Drawing.Point(8, 0)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(72, 19)
			Me.Label8.TabIndex = 0
			Me.Label8.Text = "Software:"
			Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'Label10
			'
			Me.Label10.BackColor = System.Drawing.Color.Transparent
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label10.ForeColor = System.Drawing.Color.White
			Me.Label10.Location = New System.Drawing.Point(8, 48)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New System.Drawing.Size(72, 19)
			Me.Label10.TabIndex = 6
			Me.Label10.Text = "Cosmetic"
			Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txt_fun_tier2
			'
			Me.txt_fun_tier2.Location = New System.Drawing.Point(168, 24)
			Me.txt_fun_tier2.MaxLength = 5
			Me.txt_fun_tier2.Name = "txt_fun_tier2"
			Me.txt_fun_tier2.Size = New System.Drawing.Size(56, 20)
			Me.txt_fun_tier2.TabIndex = 5
			Me.txt_fun_tier2.Text = ""
			Me.txt_fun_tier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'cbSplitByDisp
			'
			Me.cbSplitByDisp.CheckAlign = System.Drawing.ContentAlignment.TopLeft
			Me.cbSplitByDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cbSplitByDisp.ForeColor = System.Drawing.Color.White
			Me.cbSplitByDisp.Location = New System.Drawing.Point(408, 112)
			Me.cbSplitByDisp.Name = "cbSplitByDisp"
			Me.cbSplitByDisp.Size = New System.Drawing.Size(88, 32)
			Me.cbSplitByDisp.TabIndex = 6
			Me.cbSplitByDisp.Text = "Split by Disposition"
			Me.cbSplitByDisp.TextAlign = System.Drawing.ContentAlignment.TopLeft
			'
			'Label6
			'
			Me.Label6.BackColor = System.Drawing.Color.Transparent
			Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.ForeColor = System.Drawing.Color.White
			Me.Label6.Location = New System.Drawing.Point(720, 40)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(80, 64)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Tier 2 must be greater than Tier 1."
			'
			'btnClear
			'
			Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
			Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClear.ForeColor = System.Drawing.Color.White
			Me.btnClear.Location = New System.Drawing.Point(816, 88)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(112, 26)
			Me.btnClear.TabIndex = 15
			Me.btnClear.Text = "Clear"
			'
			'btnUpdate
			'
			Me.btnUpdate.BackColor = System.Drawing.Color.DarkSlateGray
			Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnUpdate.ForeColor = System.Drawing.Color.White
			Me.btnUpdate.Location = New System.Drawing.Point(816, 56)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New System.Drawing.Size(112, 27)
			Me.btnUpdate.TabIndex = 14
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.Visible = False
			'
			'btnAdd
			'
			Me.btnAdd.BackColor = System.Drawing.Color.Green
			Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnAdd.ForeColor = System.Drawing.Color.White
			Me.btnAdd.Location = New System.Drawing.Point(816, 24)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New System.Drawing.Size(112, 26)
			Me.btnAdd.TabIndex = 13
			Me.btnAdd.Text = "Add"
			Me.btnAdd.Visible = False
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
			Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboModels.ItemHeight = 15
			Me.cboModels.Location = New System.Drawing.Point(88, 104)
			Me.cboModels.MatchEntryTimeout = CType(2000, Long)
			Me.cboModels.MaxDropDownItems = CType(10, Short)
			Me.cboModels.MaxLength = 32767
			Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboModels.Name = "cboModels"
			Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboModels.Size = New System.Drawing.Size(304, 21)
			Me.cboModels.TabIndex = 5
			Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label2
			'
			Me.Label2.BackColor = System.Drawing.Color.Transparent
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.White
			Me.Label2.Location = New System.Drawing.Point(8, 104)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(80, 18)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "Model:"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboWorkAreas
			'
			Me.cboWorkAreas.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboWorkAreas.AutoCompletion = True
			Me.cboWorkAreas.AutoDropDown = True
			Me.cboWorkAreas.AutoSelect = True
			Me.cboWorkAreas.Caption = ""
			Me.cboWorkAreas.CaptionHeight = 17
			Me.cboWorkAreas.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboWorkAreas.ColumnCaptionHeight = 17
			Me.cboWorkAreas.ColumnFooterHeight = 17
			Me.cboWorkAreas.ColumnHeaders = False
			Me.cboWorkAreas.ContentHeight = 15
			Me.cboWorkAreas.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboWorkAreas.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboWorkAreas.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboWorkAreas.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboWorkAreas.EditorHeight = 15
			Me.cboWorkAreas.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboWorkAreas.ItemHeight = 15
			Me.cboWorkAreas.Location = New System.Drawing.Point(88, 64)
			Me.cboWorkAreas.MatchEntryTimeout = CType(2000, Long)
			Me.cboWorkAreas.MaxDropDownItems = CType(10, Short)
			Me.cboWorkAreas.MaxLength = 32767
			Me.cboWorkAreas.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboWorkAreas.Name = "cboWorkAreas"
			Me.cboWorkAreas.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboWorkAreas.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboWorkAreas.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboWorkAreas.Size = New System.Drawing.Size(304, 21)
			Me.cboWorkAreas.TabIndex = 3
			Me.cboWorkAreas.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label1
			'
			Me.Label1.BackColor = System.Drawing.Color.Transparent
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.White
			Me.Label1.Location = New System.Drawing.Point(8, 64)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(80, 19)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Work Area:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboGroups
			'
			Me.cboGroups.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboGroups.AutoCompletion = True
			Me.cboGroups.AutoDropDown = True
			Me.cboGroups.AutoSelect = True
			Me.cboGroups.Caption = ""
			Me.cboGroups.CaptionHeight = 17
			Me.cboGroups.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboGroups.ColumnCaptionHeight = 17
			Me.cboGroups.ColumnFooterHeight = 17
			Me.cboGroups.ColumnHeaders = False
			Me.cboGroups.ContentHeight = 15
			Me.cboGroups.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboGroups.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboGroups.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboGroups.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboGroups.EditorHeight = 15
			Me.cboGroups.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.cboGroups.ItemHeight = 15
			Me.cboGroups.Location = New System.Drawing.Point(88, 24)
			Me.cboGroups.MatchEntryTimeout = CType(2000, Long)
			Me.cboGroups.MaxDropDownItems = CType(10, Short)
			Me.cboGroups.MaxLength = 32767
			Me.cboGroups.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboGroups.Name = "cboGroups"
			Me.cboGroups.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboGroups.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboGroups.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboGroups.Size = New System.Drawing.Size(304, 21)
			Me.cboGroups.TabIndex = 1
			Me.cboGroups.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label5
			'
			Me.Label5.BackColor = System.Drawing.Color.Transparent
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.ForeColor = System.Drawing.Color.White
			Me.Label5.Location = New System.Drawing.Point(8, 24)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(80, 18)
			Me.Label5.TabIndex = 0
			Me.Label5.Text = "Group:"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'Label3
			'
			Me.Label3.BackColor = System.Drawing.Color.Transparent
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.ForeColor = System.Drawing.Color.White
			Me.Label3.Location = New System.Drawing.Point(560, 16)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(72, 16)
			Me.Label3.TabIndex = 10
			Me.Label3.Text = "Tier1 UPH"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label4
			'
			Me.Label4.BackColor = System.Drawing.Color.Transparent
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.ForeColor = System.Drawing.Color.White
			Me.Label4.Location = New System.Drawing.Point(640, 16)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(72, 16)
			Me.Label4.TabIndex = 11
			Me.Label4.Text = "Tier2 UPH"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnCopySelectedRows
			'
			Me.btnCopySelectedRows.BackColor = System.Drawing.SystemColors.Control
			Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Black
			Me.btnCopySelectedRows.Location = New System.Drawing.Point(832, 131)
			Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
			Me.btnCopySelectedRows.Size = New System.Drawing.Size(128, 16)
			Me.btnCopySelectedRows.TabIndex = 16
			Me.btnCopySelectedRows.TabStop = False
			Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
			'
			'btnCopyAll
			'
			Me.btnCopyAll.BackColor = System.Drawing.SystemColors.Control
			Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopyAll.ForeColor = System.Drawing.Color.Black
			Me.btnCopyAll.Location = New System.Drawing.Point(704, 131)
			Me.btnCopyAll.Name = "btnCopyAll"
			Me.btnCopyAll.Size = New System.Drawing.Size(112, 16)
			Me.btnCopyAll.TabIndex = 9
			Me.btnCopyAll.TabStop = False
			Me.btnCopyAll.Text = "Copy All Rows"
			'
			'pnlUPH
			'
			Me.pnlUPH.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTier1, Me.txtTier2})
			Me.pnlUPH.Location = New System.Drawing.Point(480, 32)
			Me.pnlUPH.Name = "pnlUPH"
			Me.pnlUPH.Size = New System.Drawing.Size(232, 24)
			Me.pnlUPH.TabIndex = 7
			'
			'txtTier1
			'
			Me.txtTier1.Location = New System.Drawing.Point(88, 0)
			Me.txtTier1.MaxLength = 5
			Me.txtTier1.Name = "txtTier1"
			Me.txtTier1.Size = New System.Drawing.Size(56, 20)
			Me.txtTier1.TabIndex = 0
			Me.txtTier1.Text = ""
			Me.txtTier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txtTier2
			'
			Me.txtTier2.Location = New System.Drawing.Point(168, 0)
			Me.txtTier2.MaxLength = 5
			Me.txtTier2.Name = "txtTier2"
			Me.txtTier2.Size = New System.Drawing.Size(56, 20)
			Me.txtTier2.TabIndex = 1
			Me.txtTier2.Text = ""
			Me.txtTier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'dbgGroupModel
			'
			Me.dbgGroupModel.AllowUpdate = False
			Me.dbgGroupModel.AlternatingRows = True
			Me.dbgGroupModel.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.dbgGroupModel.FilterBar = True
			Me.dbgGroupModel.GroupByCaption = "Drag a column header here to group by that column"
			Me.dbgGroupModel.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
			Me.dbgGroupModel.Location = New System.Drawing.Point(8, 160)
			Me.dbgGroupModel.Name = "dbgGroupModel"
			Me.dbgGroupModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.dbgGroupModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.dbgGroupModel.PreviewInfo.ZoomFactor = 75
			Me.dbgGroupModel.Size = New System.Drawing.Size(967, 416)
			Me.dbgGroupModel.TabIndex = 1
			Me.dbgGroupModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
			"}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarStyle=""Alway" & _
			"s"" VBarStyle=""Always"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
			"mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
			"edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
			"1"" HorizontalScrollGroup=""1""><Height>412</Height><CaptionStyle parent=""Style2"" m" & _
			"e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
			"venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
			"tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
			"adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
			"w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
			"ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
			"e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
			"""Style1"" /><ClientRect>0, 0, 963, 412</ClientRect><BorderSide>0</BorderSide><Bor" & _
			"derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
			"es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
			"arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
			"nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
			"t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
			"t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
			"ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
			"nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
			"/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
			"entArea>0, 0, 963, 412</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" " & _
			"/><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
			'
			'frmPIPModelUPH
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(992, 585)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgGroupModel, Me.GroupBox1})
			Me.Name = "frmPIPModelUPH"
			Me.Text = "Set UPH"
			Me.GroupBox1.ResumeLayout(False)
			Me.pnlDispUPH.ResumeLayout(False)
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboWorkAreas, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboGroups, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlUPH.ResumeLayout(False)
			CType(Me.dbgGroupModel, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
		Private _objCC As IncentivePrg
		Private GMID As Integer = 0
		Private _isNew = False
		Private _isUpdate = False

#End Region
#Region "FORM EVENTS"
		Private Sub frmPIPModelUPH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim dt As DataTable
			Try
				PSS.Core.Highlight.SetHighLight(Me)
				'POPULATE GROUPS
				dt = _objCC.GetMasterGroups(True)
				Misc.PopulateC1DropDownList(Me.cboGroups, dt, "Group_Desc", "Group_ID")
				Me.cboGroups.SelectedValue = 0
				Generic.DisposeDT(dt)
				'POPULATE WORK AREAS
				dt = _objCC.GetWorkAreas(True)
				Misc.PopulateC1DropDownList(Me.cboWorkAreas, dt, "wa_desc", "wa_id")
				Me.cboWorkAreas.SelectedValue = 0
				Generic.DisposeDT(dt)
				'POPULATE MODELS
				dt = Generic.GetModels(True, , )
				Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
				Me.cboModels.SelectedValue = 0
				EnableControls()
				Me.cboGroups.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "frmPIPModelUPH_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
			Dim i As Integer = 0
			Dim dt As DataTable
			Dim R1 As DataRow
			Try
				' VALIDATION.
				If Not ValidateDropDowns() Then
					MessageBox.Show("You must select a group, work area and model.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					cboGroups.Focus()
					Exit Sub
				End If
				If Not ValidateTiers() Then
					MessageBox.Show("Invalid Tier entries exists.  Tier 2 must be greater than Tier 1.  Please review them and try again.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					cboGroups.Focus()
					Exit Sub
				End If
				' IF BUTTON VISIBILITY IS WORKING CORRECTLY THE NEXT FOR LOOP IS NOT NEEDED. (DAVID BRADLEY)
				dt = Me._objCC.GetGroupModel(Me.cboGroups.SelectedValue)
				For Each R1 In dt.Rows
					If (R1("Group Desc.") = Me.cboGroups.Text AndAlso R1("Work Area") = Me.cboWorkAreas.Text AndAlso R1("Model Desc.") = Me.cboModels.Text) Then
						EnableControls()
						MessageBox.Show("This entry already exists, you must choose the record to be updated.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Exit Sub
					End If
				Next R1
				' PROCESSING.
				If MessageBox.Show("Are you sure you want to add?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
				ClearUnneededTiers()
				i = Me._objCC.InsertintoGroupModel( _
				 Me.cboGroups.SelectedValue, _
				 Me.cboWorkAreas.SelectedValue, _
				 Me.cboModels.SelectedValue, _
				 CDbl(Me.txtTier1.Text), _
				 CDbl(Me.txtTier2.Text), _
				 CDbl(Me.txt_sof_tier1.Text), _
				 CDbl(Me.txt_sof_tier2.Text), _
				 CDbl(Me.txt_fun_tier1.Text), _
				 CDbl(Me.txt_fun_tier2.Text), _
				 CDbl(Me.txt_cos_tier1.Text), _
				 CDbl(Me.txt_cos_tier2.Text), _
				 CDbl(Me.txt_ntf_tier1.Text), _
				 CDbl(Me.txt_ntf_tier2.Text), _
				 IIf(cbSplitByDisp.Checked, 1, 0))
				If i = 1 Then
					MessageBox.Show("Inserted was successfully.")
					Clear()
					EnableControls()
				Else
					MessageBox.Show("Inserted was failed, Please contact IT.")
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Finally
			End Try
		End Sub
		Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
			Dim i As Integer = 0
			Dim j As Integer = 0
			Try
				' VALIDATION.
				If Not ValidateDropDowns() Then
					MessageBox.Show("You must select a group, work area and model.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					cboGroups.Focus()
					Exit Sub
				End If
				If Not ValidateTiers() Then
					MessageBox.Show("Invalid Tier entries exists.  Tier 2 must be greater than Tier 1.  Please review them and try again.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					cboGroups.Focus()
					Exit Sub
				End If


				' PROCESSING.
				If MessageBox.Show("Are you sure you want to update?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
					Exit Sub
				End If
				ClearUnneededTiers()
				If _
				 Me.dbgGroupModel.Columns("Split By Disp").Value = IIf(cbSplitByDisp.Checked, 1, 0) And _
				 Me.dbgGroupModel.Columns("Tier 1").Value.ToString() = Me.txtTier1.Text And _
				 Me.dbgGroupModel.Columns("Tier 2").Value.ToString() = Me.txtTier2.Text And _
				 Me.dbgGroupModel.Columns("SOF Tier 1").Value.ToString() = Me.txt_sof_tier1.Text And _
				 Me.dbgGroupModel.Columns("SOF Tier 2").Value.ToString() = Me.txt_sof_tier2.Text And _
				 Me.dbgGroupModel.Columns("FUN Tier 1").Value.ToString() = Me.txt_fun_tier1.Text And _
				 Me.dbgGroupModel.Columns("FUN Tier 2").Value.ToString() = Me.txt_fun_tier2.Text And _
				 Me.dbgGroupModel.Columns("COS Tier 1").Value.ToString() = Me.txt_cos_tier1.Text And _
				 Me.dbgGroupModel.Columns("COS Tier 2").Value.ToString() = Me.txt_cos_tier2.Text And _
				 Me.dbgGroupModel.Columns("NTF Tier 1").Value.ToString() = Me.txt_ntf_tier1.Text And _
				 Me.dbgGroupModel.Columns("NTF Tier 2").Value.ToString() = Me.txt_ntf_tier2.Text Then
					Throw New Exception("Tiers have not changed; no update is neccessary.")
				End If
				' IF BUTTON VISIBILITY IS WORKING CORRECTLY THE NEXT IF STATEMENT IS NOT NEEDED. (DAVID BRADLEY)
				If (GMID > 0) Then
					' INSERT HISTORY RECORD.
					j = Me._objCC.InsertintoGroupModelHistory( _
					Me.cboGroups.SelectedValue, _
					Me.cboWorkAreas.SelectedValue, _
					Me.cboModels.SelectedValue, _
					ConvertToSomething(dbgGroupModel.Columns("Tier 1").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("Tier 2").Value, 0.0), _
					PSS.Core.ApplicationUser.IDuser, _
					IIf(cbSplitByDisp.Checked, 1, 0), _
					ConvertToSomething(dbgGroupModel.Columns("SOF Tier 1").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("SOF Tier 2").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("FUN Tier 1").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("FUN Tier 2").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("COS Tier 1").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("COS Tier 2").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("NTF Tier 1").Value, 0.0), _
					ConvertToSomething(dbgGroupModel.Columns("NTF Tier 2").Value, 0.0))
					If j = 1 Then
						' UPDATE THE RECORD WITH NEW VALUES.
						i = Me._objCC.UpdateGroupModel(GMID, _
						 CDbl(ConvertToSomething(txtTier1.Text, 0.0)), CDbl(ConvertToSomething(txtTier2.Text, 0.0)), _
						 CDbl(ConvertToSomething(txt_sof_tier1.Text, 0.0)), CDbl(ConvertToSomething(txt_sof_tier2.Text, 0.0)), _
						 CDbl(ConvertToSomething(txt_fun_tier1.Text, 0.0)), CDbl(ConvertToSomething(txt_fun_tier2.Text, 0.0)), _
						 CDbl(ConvertToSomething(txt_cos_tier1.Text, 0.0)), CDbl(ConvertToSomething(txt_cos_tier2.Text, 0.0)), _
						 CDbl(ConvertToSomething(txt_ntf_tier1.Text, 0.0)), CDbl(ConvertToSomething(txt_ntf_tier2.Text, 0.0)), _
						 IIf(cbSplitByDisp.Checked, 1, 0))
						If i = 1 Then
							MessageBox.Show("Update was successfully.")
							Clear()
							EnableControls()
							cboGroups.Focus()
						Else
							MessageBox.Show("Update has failed, Please contact IT.")
						End If
					Else
						MessageBox.Show("Inserted into history has failed, Please contact IT.")
					End If
				Else
					MessageBox.Show("A matching record was not found to update.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			' CLEAR BUTTON PROCESS.
			Try
				Clear()
				EnableControls()
				cboGroups.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub cboGroups_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroups.Leave
			' PROCESS WHEN GROUPS DROP DOWN HAS LOST FOCUS.
			Try
				PopulateGroupModelDBG()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboGroups_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub cboModels_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModels.Leave
			If Not _isUpdate AndAlso cboModels.SelectedIndex > 0 Then
				_isNew = True
			End If
			EnableControls()
		End Sub
		Private Sub dbgGroupModel_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgGroupModel.DoubleClick
			' PROCESS WHEN GRID ROW IS DOUBLE CLICKED.
			Try
				GMID = CInt(Me.dbgGroupModel.Columns("GMID").Value.ToString)
				_isUpdate = True
				_isNew = False
				Me.cboWorkAreas.Text = Me.dbgGroupModel.Columns("Work Area").Value.ToString
				Me.cboModels.Text = Me.dbgGroupModel.Columns("Model Desc.").Value.ToString
				Me.txtTier1.Text = Me.dbgGroupModel.Columns("Tier 1").Value.ToString
				Me.txtTier2.Text = Me.dbgGroupModel.Columns("Tier 2").Value.ToString
				Me.cbSplitByDisp.Checked = Me.dbgGroupModel.Columns("Split By Disp").Value > 0
				Me.txt_sof_tier1.Text = Me.dbgGroupModel.Columns("SOF Tier 1").Value.ToString
				Me.txt_sof_tier2.Text = Me.dbgGroupModel.Columns("SOF Tier 2").Value.ToString
				Me.txt_fun_tier1.Text = Me.dbgGroupModel.Columns("FUN Tier 1").Value.ToString
				Me.txt_fun_tier2.Text = Me.dbgGroupModel.Columns("FUN Tier 2").Value.ToString
				Me.txt_cos_tier1.Text = Me.dbgGroupModel.Columns("COS Tier 1").Value.ToString
				Me.txt_cos_tier2.Text = Me.dbgGroupModel.Columns("COS Tier 2").Value.ToString
				Me.txt_ntf_tier1.Text = Me.dbgGroupModel.Columns("NTF Tier 1").Value.ToString
				Me.txt_ntf_tier2.Text = Me.dbgGroupModel.Columns("NTF Tier 2").Value.ToString
				If cbSplitByDisp.Checked Then
					txt_sof_tier1.Focus()
				Else
					txtTier1.Focus()
				End If
				EnableControls()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "dbgGroupModel_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub txtTier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTier1.KeyDown

			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txtTier1.Text) > 0 Then
					Me.txtTier2.Focus()
				Else
					Me.txtTier1.Focus()
					MessageBox.Show("Tier 1 has to be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txtTier2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTier2.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txtTier2.Text) > 0 Then
					If _isNew Then
						btnAdd.Focus()
					Else
						btnUpdate.Focus()
					End If
				Else
					Me.txtTier2.Focus()
					MessageBox.Show("Tier 2 has to be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_sof_tier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_sof_tier1.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_sof_tier1.Text) > 0 Then
					txt_sof_tier2.Focus()
				Else
					Me.txt_sof_tier1.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_sof_tier2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_sof_tier2.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_sof_tier2.Text) > 0 Then
					txt_fun_tier1.Focus()
				Else
					Me.txt_sof_tier2.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_fun_tier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fun_tier1.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_fun_tier1.Text) > 0 Then
					txt_fun_tier2.Focus()
				Else
					Me.txt_fun_tier1.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_fun_tier2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fun_tier2.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_fun_tier2.Text) > 0 Then
					txt_cos_tier1.Focus()
				Else
					Me.txt_fun_tier2.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_cos_tier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cos_tier1.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_cos_tier1.Text) > 0 Then
					txt_cos_tier2.Focus()
				Else
					Me.txt_cos_tier1.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_cos_tier2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cos_tier2.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_cos_tier2.Text) > 0 Then
					txt_ntf_tier1.Focus()
				Else
					Me.txt_cos_tier2.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_ntf_tier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ntf_tier1.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_ntf_tier1.Text) > 0 Then
					txt_ntf_tier2.Focus()
				Else
					Me.txt_ntf_tier1.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub txt_ntf_tier2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ntf_tier2.KeyDown
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				If CDbl(Me.txt_ntf_tier2.Text) > 0 Then
					If _isNew Then
						btnAdd.Focus()
					Else
						btnUpdate.Focus()
					End If
				Else
					Me.txt_ntf_tier2.Focus()
					MessageBox.Show("Tier must be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
				EnableControls()
			End If
		End Sub
		Private Sub KeyUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
		 Handles cboGroups.KeyUp, cboWorkAreas.KeyUp, cboModels.KeyUp
			' THIS SHOULD BE BROKEN OUT TO EACH CONTROLS KEYUP OR EVEN KEY DOWN EVENT FOR BETTER HANDLING.
			Try
				If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
					Select Case sender.Name
						Case "cboGroups"
							If Me.cboGroups.SelectedValue > 0 Then
								Me.PopulateGroupModelDBG()
								Me.cboWorkAreas.Focus()
							Else
								Me.cboGroups.Focus()
							End If
						Case "cboWorkAreas"
							If Me.cboWorkAreas.SelectedValue > 0 Then
								Me.cboModels.Focus()
							Else
								Me.cboWorkAreas.Focus()
							End If
						Case "cboModels"
							If Me.cboModels.SelectedValue > 0 Then
								Me.txtTier1.Focus()
							Else
								Me.cboModels.Focus()
							End If
							'Case "txtTier1"
							'	If CDbl(Me.txtTier1.Text) > 0 Then
							'		Me.txtTier2.Focus()
							'	Else
							'		Me.txtTier1.Focus()
							'		MessageBox.Show("Tier 1 has to be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							'	End If
							'Case "txtTier2"
							'	If CDbl(Me.txtTier2.Text) > 0 Then
							'		If GMID = 0 Then
							'			Me.btnAdd.Visible = True
							'			Me.btnAdd.Focus()
							'		Else
							'			Me.btnUpdate.Focus()
							'		End If
							'	Else
							'		Me.txtTier2.Focus()
							'		MessageBox.Show("Tier 2 has to be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							'	End If
							'Case "txt_ntf_tier2"
							'	If _
							'	 CDbl(txt_sof_tier1.Text) > 0 AndAlso _
							'	 CDbl(txt_sof_tier2.Text) > 0 AndAlso _
							'	 CDbl(txt_fun_tier1.Text) > 0 AndAlso _
							'	 CDbl(txt_fun_tier2.Text) > 0 AndAlso _
							'	 CDbl(txt_cos_tier1.Text) > 0 AndAlso _
							'	 CDbl(txt_cos_tier2.Text) > 0 AndAlso _
							'	 CDbl(txt_ntf_tier1.Text) > 0 AndAlso _
							'	 CDbl(txt_ntf_tier2.Text) > 0 Then

							'If GMID = 0 Then
							'	Me.btnAdd.Visible = True
							'	Me.btnAdd.Focus()
							'Else
							'	Me.btnUpdate.Visible = True
							'	Me.btnUpdate.Focus()
							'End If
							'Else
							'	txt_sof_tier1.Focus()
							'	MessageBox.Show("All Tiers must be filled in with a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							'End If
					End Select
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub
		Private Sub txtTier1_txtTier2_KeyPress(ByVal sender As Object, _
		 ByVal e As System.Windows.Forms.KeyPressEventArgs) _
		 Handles _
		 txtTier1.KeyPress, _
		 txtTier2.KeyPress, _
		 txt_sof_tier1.KeyPress, _
		 txt_sof_tier2.KeyPress, _
		 txt_fun_tier1.KeyPress, _
		 txt_fun_tier2.KeyPress, _
		 txt_cos_tier1.KeyPress, _
		 txt_cos_tier2.KeyPress, _
		 txt_sof_tier1.KeyPress, _
		 txt_sof_tier2.KeyPress
			' USED TO HANDLE KEYPRESS FUCTIONALITY FOR TIERS.
			If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar) Or e.KeyChar = ".") Then
				e.Handled = True
			End If
			EnableControls()
		End Sub
		Private Sub btn_Copies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedRows.Click, btnCopyAll.Click
			' HANDLES THE COPY ALL PROCESS.
			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				If sender.name = "btnCopyAll" Then
					Misc.CopyAllData(Me.dbgGroupModel)
				ElseIf sender.name = "btnCopySelectedRows" Then
					Misc.CopySelectedRowsData(Me.dbgGroupModel)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub
		Private Sub cbSplitByDisp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSplitByDisp.CheckedChanged
			' HANDLES THE SELECTION OR DESELECTION OF SPLIT BY DISPOSITION.
			EnableControls()
		End Sub
#End Region
#Region "METHODS"
		Private Sub EnableControls()
			' ENABLES OR DISABLES CONTROLS BASED ON STATE.
			' ALSO USED FOR VISIBILITY.
			pnlUPH.Visible = Not cbSplitByDisp.Checked
			pnlDispUPH.Visible = cbSplitByDisp.Checked
			btnAdd.Visible = _isNew		  'AndAlso CInt(Me.dbgGroupModel.Columns("GMID").Value.ToString) > 0
			btnUpdate.Visible = _isUpdate AndAlso CInt(Me.dbgGroupModel.Columns("GMID").Value.ToString) > 0
			cboGroups.Enabled = Not (_isNew Or _isUpdate)
			cboWorkAreas.Enabled = Not (_isNew Or _isUpdate)
			cboModels.Enabled = Not (_isNew Or _isUpdate)
		End Sub
		Public Sub PopulateGroupModelDBG()
			' POPULATES THE GRID.
			Dim dt As DataTable
			Try
				Me.dbgGroupModel.DataSource = Nothing
				If Me.cboGroups.SelectedValue > 0 Then
					dt = Me._objCC.GetGroupModel(Me.cboGroups.SelectedValue)
					With Me.dbgGroupModel
						.DataSource = dt.DefaultView
						SetGridGroupModelProperties()
					End With
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "PopulateGroupModelDBG", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub
		Private Sub SetGridGroupModelProperties()
			' SETUP OF THE GRID.
			Dim iNumOfColumns As Integer = Me.dbgGroupModel.Columns.Count
			Dim i As Integer
			With Me.dbgGroupModel
				'Heading style (Horizontal Alignment to Center)
				For i = 0 To (iNumOfColumns - 1)
					.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
					.Splits(0).DisplayColumns(i).Visible = True
				Next
				'HEADER FORECOLOR
				.Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(4).HeadingStyle.ForeColor = .ForeColor.Black
				'SET INDIVIDUAL COLUMN DATA HORIZONTAL ALIGNMENT
				.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				'BODY FORECOLOR
				.Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black
				.Splits(0).DisplayColumns(4).Style.ForeColor = .ForeColor.Black
				'SET COLUMN WIDTHS
				.Splits(0).DisplayColumns("Group Desc.").Width = 200
				.Splits(0).DisplayColumns("Work Area").Width = 120
				.Splits(0).DisplayColumns("Model Desc.").Width = 200
				.Splits(0).DisplayColumns("Tier 1").Width = 70
				.Splits(0).DisplayColumns("Tier 2").Width = 70
				.Splits(0).DisplayColumns("GMID").Visible = False
				.AlternatingRows = True
			End With
		End Sub
		Private Function ValidateDropDowns() As Boolean
			' VALIDATION FOR DROP DOWN SELECTIONS.
			Dim _retVal As Boolean = False
			_retVal = (cboGroups.SelectedValue > 0 AndAlso _
			  cboWorkAreas.SelectedValue > 0 AndAlso _
			  cboModels.SelectedValue > 0)
			Return _retVal
		End Function
		Private Function ValidateTiers() As Boolean
			' VALIDATES ALL THE TIER AMOUNTS NEEDED ARE POPULATED.
			Dim _retVal As Boolean = False
			Dim _t1, _t2, _st1, _st2, _ft1, _ft2, _ct1, _ct2, _nt1, _nt2 As Double

			_t1 = CDbl(IIf(txtTier1.Text = "", 0.0, txtTier1.Text))
			_t2 = CDbl(IIf(txtTier2.Text = "", 0.0, txtTier2.Text))
			_st1 = CDbl(IIf(txt_sof_tier1.Text = "", 0.0, txt_sof_tier1.Text))
			_st2 = CDbl(IIf(txt_sof_tier2.Text = "", 0.0, txt_sof_tier2.Text))
			_ft1 = CDbl(IIf(txt_fun_tier1.Text = "", 0.0, txt_fun_tier1.Text))
			_ft2 = CDbl(IIf(txt_fun_tier2.Text = "", 0.0, txt_fun_tier2.Text))
			_ct1 = CDbl(IIf(txt_cos_tier1.Text = "", 0.0, txt_cos_tier1.Text))
			_ct2 = CDbl(IIf(txt_cos_tier2.Text = "", 0.0, txt_cos_tier2.Text))
			_nt1 = CDbl(IIf(txt_ntf_tier1.Text = "", 0.0, txt_ntf_tier1.Text))
			_nt2 = CDbl(IIf(txt_ntf_tier2.Text = "", 0.0, txt_ntf_tier2.Text))
			If cbSplitByDisp.Checked Then
				' BY MODEL AND DISPOISTION.
				If _
				 _st1 > 0 AndAlso _
				 _ft1 > 0 AndAlso _
				 _ct1 > 0 AndAlso _
				 _nt1 > 0 AndAlso _
				 _st2 > _st1 AndAlso _
				 _ft2 > _ft1 AndAlso _
				 _ct2 > _ct1 AndAlso _
				 _nt2 > _nt1 Then
					_retVal = True
				Else
					txt_sof_tier1.Focus()
					_retVal = False
				End If
			Else
				' BY MODEL ONLY.
				If _t1 > 0 AndAlso _t2 > _t1 Then
					_retVal = True
				Else
					_retVal = False
					txtTier1.Focus()
				End If
			End If
			Return _retVal
		End Function
		Private Sub Clear()
			' CLEARS ALL CONTROLS EXCEPT FOR THE GROUP SELECTION.
			Me.btnAdd.Visible = False
			Me.btnUpdate.Visible = False
			Me.cboGroups.Enabled = True
			Me.cboWorkAreas.Enabled = True
			Me.cboModels.Enabled = True
			Me.cboWorkAreas.SelectedValue = 0
			Me.cboModels.SelectedValue = 0
			Me.txtTier1.Text = ""
			Me.txtTier2.Text = ""
			cbSplitByDisp.Checked = False
			txt_sof_tier1.Text = ""
			txt_sof_tier2.Text = ""
			txt_fun_tier1.Text = ""
			txt_fun_tier2.Text = ""
			txt_cos_tier1.Text = ""
			txt_cos_tier2.Text = ""
			txt_ntf_tier1.Text = ""
			txt_ntf_tier2.Text = ""
			GMID = 0
			_isNew = False
			_isUpdate = False
			Me.dbgGroupModel.ClearFields()
			Me.cboGroups.Focus()
		End Sub
		Private Sub ClearUnneededTiers()
			If cbSplitByDisp.Checked Then
				txtTier1.Text = "0"
				txtTier2.Text = "0"
			Else
				txt_sof_tier1.Text = "0"
				txt_sof_tier2.Text = "0"
				txt_fun_tier1.Text = "0"
				txt_fun_tier2.Text = "0"
				txt_cos_tier1.Text = "0"
				txt_cos_tier2.Text = "0"
				txt_ntf_tier1.Text = "0"
				txt_ntf_tier2.Text = "0"
			End If
		End Sub
#End Region
	End Class
End Namespace