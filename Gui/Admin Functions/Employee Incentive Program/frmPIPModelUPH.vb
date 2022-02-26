Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.PIP
    Public Class frmPIPModelUPH
        Inherits System.Windows.Forms.Form

        Private _objCC As IncentivePrg
        Private GMID As Integer = 0
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
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtTier1 As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents txtTier2 As System.Windows.Forms.TextBox
        Friend WithEvents dbgGroupModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPIPModelUPH))
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.txtTier2 = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtTier1 = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboWorkAreas = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboGroups = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dbgGroupModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboWorkAreas, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboGroups, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgGroupModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnUpdate, Me.btnAdd, Me.txtTier2, Me.Label4, Me.txtTier1, Me.Label3, Me.cboModels, Me.Label2, Me.cboWorkAreas, Me.Label1, Me.cboGroups, Me.Label5})
            Me.GroupBox1.Location = New System.Drawing.Point(10, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(942, 138)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(829, 99)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(96, 28)
            Me.btnClear.TabIndex = 8
            Me.btnClear.Text = "Clear"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.White
            Me.btnUpdate.Location = New System.Drawing.Point(829, 59)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(96, 29)
            Me.btnUpdate.TabIndex = 7
            Me.btnUpdate.Text = "Update"
            Me.btnUpdate.Visible = False
            '
            'btnAdd
            '
            Me.btnAdd.BackColor = System.Drawing.Color.Green
            Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdd.ForeColor = System.Drawing.Color.White
            Me.btnAdd.Location = New System.Drawing.Point(829, 20)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(96, 28)
            Me.btnAdd.TabIndex = 6
            Me.btnAdd.Text = "Add"
            Me.btnAdd.Visible = False
            '
            'txtTier2
            '
            Me.txtTier2.Location = New System.Drawing.Point(614, 99)
            Me.txtTier2.MaxLength = 5
            Me.txtTier2.Name = "txtTier2"
            Me.txtTier2.Size = New System.Drawing.Size(195, 22)
            Me.txtTier2.TabIndex = 5
            Me.txtTier2.Text = ""
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(492, 99)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 19)
            Me.Label4.TabIndex = 92
            Me.Label4.Text = "Tier2 UPH:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTier1
            '
            Me.txtTier1.Location = New System.Drawing.Point(614, 59)
            Me.txtTier1.MaxLength = 5
            Me.txtTier1.Name = "txtTier1"
            Me.txtTier1.Size = New System.Drawing.Size(192, 22)
            Me.txtTier1.TabIndex = 4
            Me.txtTier1.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(492, 59)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 20)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Tier1 UPH:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModels.ContentHeight = 18
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 18
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(123, 99)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(348, 24)
            Me.cboModels.TabIndex = 3
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
            "ultRecSelWidth>20</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(20, 99)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(103, 19)
            Me.Label2.TabIndex = 91
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
            Me.cboWorkAreas.ContentHeight = 18
            Me.cboWorkAreas.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWorkAreas.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWorkAreas.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWorkAreas.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWorkAreas.EditorHeight = 18
            Me.cboWorkAreas.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboWorkAreas.ItemHeight = 15
            Me.cboWorkAreas.Location = New System.Drawing.Point(123, 59)
            Me.cboWorkAreas.MatchEntryTimeout = CType(2000, Long)
            Me.cboWorkAreas.MaxDropDownItems = CType(10, Short)
            Me.cboWorkAreas.MaxLength = 32767
            Me.cboWorkAreas.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWorkAreas.Name = "cboWorkAreas"
            Me.cboWorkAreas.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWorkAreas.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWorkAreas.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWorkAreas.Size = New System.Drawing.Size(348, 24)
            Me.cboWorkAreas.TabIndex = 2
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
            "ultRecSelWidth>20</DefaultRecSelWidth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(20, 59)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(103, 20)
            Me.Label1.TabIndex = 89
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
            Me.cboGroups.ContentHeight = 18
            Me.cboGroups.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboGroups.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboGroups.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboGroups.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboGroups.EditorHeight = 18
            Me.cboGroups.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboGroups.ItemHeight = 15
            Me.cboGroups.Location = New System.Drawing.Point(123, 20)
            Me.cboGroups.MatchEntryTimeout = CType(2000, Long)
            Me.cboGroups.MaxDropDownItems = CType(10, Short)
            Me.cboGroups.MaxLength = 32767
            Me.cboGroups.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboGroups.Name = "cboGroups"
            Me.cboGroups.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboGroups.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboGroups.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboGroups.Size = New System.Drawing.Size(686, 24)
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
            "ultRecSelWidth>20</DefaultRecSelWidth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(20, 20)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(103, 19)
            Me.Label5.TabIndex = 87
            Me.Label5.Text = "Group:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.dbgGroupModel.Location = New System.Drawing.Point(10, 138)
            Me.dbgGroupModel.Name = "dbgGroupModel"
            Me.dbgGroupModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgGroupModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgGroupModel.PreviewInfo.ZoomFactor = 75
            Me.dbgGroupModel.Size = New System.Drawing.Size(942, 464)
            Me.dbgGroupModel.TabIndex = 9
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
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""25"" " & _
            "Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
            "olumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSe" & _
            "lectorWidth=""20"" DefRecSelWidth=""20"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><Height>460</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
            "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
            "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
            ">0, 0, 938, 460</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Borde" & _
            "rStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me" & _
            "=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Fo" & _
            "oter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inact" & _
            "ive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor""" & _
            " /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow" & _
            """ /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelec" & _
            "tor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group" & _
            """ /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>No" & _
            "ne</Layout><DefaultRecSelWidth>20</DefaultRecSelWidth><ClientArea>0, 0, 938, 460" & _
            "</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyl" & _
            "e parent="""" me=""Style21"" /></Blob>"
            '
            'frmPIPModelUPH
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(962, 618)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgGroupModel, Me.GroupBox1})
            Me.Name = "frmPIPModelUPH"
            Me.Text = "frmPIPModelUPH"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboWorkAreas, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboGroups, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgGroupModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmPIPModelUPH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                'Populate Groups
                dt = _objCC.GetMasterGroups(True)
                Misc.PopulateC1DropDownList(Me.cboGroups, dt, "Group_Desc", "Group_ID")
                Me.cboGroups.SelectedValue = 0
                Generic.DisposeDT(dt)

                'Populate Work Areas
                dt = _objCC.GetWorkAreas(True)
                Misc.PopulateC1DropDownList(Me.cboWorkAreas, dt, "wa_desc", "wa_id")
                Me.cboWorkAreas.SelectedValue = 0
                Generic.DisposeDT(dt)

                'Populate Models
                dt = Generic.GetModels(True, , )
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
                Me.cboModels.SelectedValue = 0

                Me.cboGroups.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmPIPModelUPH_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub


        '******************************************************************
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                If Me.txtTier1.Text.Trim.Length = 0 Then
                    MessageBox.Show("Tier one can't be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtTier1.Text.Trim.Length = 0 Then
                    MessageBox.Show("Tier two can't be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If ValidatetoUpdate() = 1 Then
                        dt = Me._objCC.GetGroupModel(Me.cboGroups.SelectedValue)
                        For Each R1 In dt.Rows
                            If (R1("Group Desc.") = Me.cboGroups.Text AndAlso R1("Work Area") = Me.cboWorkAreas.Text AndAlso R1("Model Desc.") = Me.cboModels.Text) Then
                                Throw New Exception("This entry's already existed, can only be updated.")
                            End If
                        Next R1

                        If MessageBox.Show("Are you sure you want to add?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                        i = Me._objCC.InsertintoGroupModel(Me.cboGroups.SelectedValue, Me.cboWorkAreas.SelectedValue, Me.cboModels.SelectedValue, _
                        CDbl(Me.txtTier1.Text), CDbl(Me.txtTier2.Text))
                        If i = 1 Then
                            MessageBox.Show("Inserted was successfully.")
                            Clear()
                        Else
                            MessageBox.Show("Inserted was failed, Please contact IT.")
                        End If

                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '******************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim i As Integer = 0
            Dim j As Integer = 0
            Try
                If MessageBox.Show("Are you sure you want to update?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
                If ValidatetoUpdate() = 1 Then
                    If CDbl(Me.dbgGroupModel.Columns("Tier 1").Value) = CDbl(Me.txtTier1.Text) And CDbl(Me.dbgGroupModel.Columns("Tier 2").Value) = CDbl(Me.txtTier2.Text) Then
                        Throw New Exception("Tier 1 and 2 are the same as previous; no update was made.")
                    End If

                    If (GMID > 0) Then
                        j = Me._objCC.InsertintoGroupModelHistory(Me.cboGroups.SelectedValue, Me.cboWorkAreas.SelectedValue, Me.cboModels.SelectedValue, _
                        Me.dbgGroupModel.Columns("Tier 1").Value.ToString, Me.dbgGroupModel.Columns("Tier 2").Value.ToString, PSS.Core.ApplicationUser.IDuser)
                        If j = 1 Then
                            i = Me._objCC.UpdateGroupModel(GMID, CDbl(Me.txtTier1.Text), CDbl(Me.txtTier2.Text))
                            If i = 1 Then
                                MessageBox.Show("Updated was successfully.")
                                Clear()
                            Else
                                MessageBox.Show("Updated was failed, Please contact IT.")
                            End If
                        Else
                            MessageBox.Show("Inserted into history was failed, Please contact IT.")
                        End If
                    Else
                        MessageBox.Show("Please contact IT.")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '******************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Clear()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '******************************************************************
        Private Sub cboGroups_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroups.Leave
            Try
                Me.PopulateGroupModelDBG()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboGroups_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************
        Private Sub SetGridGroupModelProperties()
            Dim iNumOfColumns As Integer = Me.dbgGroupModel.Columns.Count
            Dim i As Integer

            With Me.dbgGroupModel
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Visible = True
                Next
                'header forecolor
                .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(4).HeadingStyle.ForeColor = .ForeColor.Black

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Body Forecolor
                .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(4).Style.ForeColor = .ForeColor.Black

                'Set Column Widths
                .Splits(0).DisplayColumns("Group Desc.").Width = 200
                .Splits(0).DisplayColumns("Work Area").Width = 120
                .Splits(0).DisplayColumns("Model Desc.").Width = 200
                .Splits(0).DisplayColumns("Tier 1").Width = 70
                .Splits(0).DisplayColumns("Tier 2").Width = 70

                .Splits(0).DisplayColumns("GMID").Visible = False

                .AlternatingRows = True

            End With
        End Sub

        '********************************************************************
        Private Sub dbgGroupModel_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgGroupModel.DoubleClick
            Dim j As Integer = 0
            Try
                Me.btnAdd.Visible = False
                Me.cboWorkAreas.Text = Me.dbgGroupModel.Columns("Work Area").Value.ToString
                Me.cboModels.Text = Me.dbgGroupModel.Columns("Model Desc.").Value.ToString
                Me.txtTier1.Text = Me.dbgGroupModel.Columns("Tier 1").Value.ToString
                Me.txtTier2.Text = Me.dbgGroupModel.Columns("Tier 2").Value.ToString

                j = ValidatetoUpdate()
                If j = 1 Then
                    GMID = CInt(Me.dbgGroupModel.Columns("GMID").Value.ToString)
                    Me.btnUpdate.Visible = True
                    Me.cboGroups.Enabled = False
                    Me.cboWorkAreas.Enabled = False
                    Me.cboModels.Enabled = False
                    Me.txtTier1.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgGroupModel_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub

        '********************************************************************
        Private Function ValidatetoUpdate() As Integer
            Try
                If Me.cboGroups.SelectedValue < 1 Then
                    Throw New Exception("Group is missing.")
                End If
                If Me.cboWorkAreas.SelectedValue < 1 Then
                    Throw New Exception("Work area is missing.")
                End If
                If Me.cboModels.SelectedValue < 1 Then
                    Throw New Exception("Model is missing.")
                End If
                If Trim(Me.txtTier1.Text) = "" Or CDbl(Me.txtTier1.Text) <= 0 Then
                    Throw New Exception("Tier 1 is missing, equals or less than 0")
                End If
                If Trim(Me.txtTier2.Text) = "" Or CDbl(Me.txtTier2.Text) <= 0 Then
                    Throw New Exception("Tier 2 is missing, equals or less than 0")
                End If
                Return 1
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ValidatetoUpdate", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '********************************************************************
        Private Sub Clear()
            Me.btnAdd.Visible = False
            Me.btnUpdate.Visible = False
            Me.cboGroups.Enabled = True
            Me.cboWorkAreas.Enabled = True
            Me.cboModels.Enabled = True
            'Me.cboGroups.SelectedValue = 0
            Me.cboWorkAreas.SelectedValue = 0
            Me.cboModels.SelectedValue = 0
            Me.txtTier1.Text = ""
            Me.txtTier2.Text = ""
            Me.cboGroups.Focus()
            GMID = 0
            Me.dbgGroupModel.ClearFields()
        End Sub

        '********************************************************************
        Public Sub PopulateGroupModelDBG()
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

        '********************************************************************
        Private Sub KeyUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGroups.KeyUp, cboWorkAreas.KeyUp, cboModels.KeyUp, txtTier1.KeyUp, txtTier2.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Select Case sender.Name
                        Case "cboGroups"
                            If Me.cboGroups.SelectedValue > 0 Then
                                Me.PopulateGroupModelDBG()
                                Me.cboWorkAreas.Focus()
                            Else
                                Me.cboGroups.Focus() : End If

                        Case "cboWorkAreas"
                            If Me.cboWorkAreas.SelectedValue > 0 Then
                                Me.cboModels.Focus()
                            Else
                                Me.cboWorkAreas.Focus() : End If

                        Case "cboModels"
                            If Me.cboModels.SelectedValue > 0 Then
                                Me.txtTier1.Focus()
                            Else
                                Me.cboModels.Focus() : End If

                        Case "txtTier1"
                            If CDbl(Me.txtTier1.Text) > 0 Then
                                Me.txtTier2.Focus()
                            Else
                                Me.txtTier1.Focus()
                                MessageBox.Show("Tier 1 has to be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                        Case "txtTier2"
                            If CDbl(Me.txtTier2.Text) > 0 Then
                                If GMID = 0 Then
                                    Me.btnAdd.Visible = True
                                    Me.btnAdd.Focus()
                                Else
                                    Me.btnUpdate.Focus()
                                End If
                            Else
                                Me.txtTier2.Focus()
                                MessageBox.Show("Tier 2 has to be a positive number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************
        Private Sub txtTier1_txtTier2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTier1.KeyPress, txtTier2.KeyPress
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End Sub

        '********************************************************************

    End Class
End Namespace