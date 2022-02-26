Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Document
    Public Class frmDocMapFileLoc
        Inherits System.Windows.Forms.Form

        Private _objDocMap As PSS.Data.Buisness.Document.DocumentMap
        Private _iDocMapID As Integer = 0
        Private _strFilePath As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objDocMap = New PSS.Data.Buisness.Document.DocumentMap()
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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnMap As System.Windows.Forms.Button
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnBrowseDocLoc As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents dbgExistingDocMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtFileName As System.Windows.Forms.TextBox
        Friend WithEvents txtPath As System.Windows.Forms.TextBox
        Friend WithEvents txtDocName As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboDept As C1.Win.C1List.C1Combo
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents txtStation As System.Windows.Forms.TextBox
        Friend WithEvents btnDisable As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDocMapFileLoc))
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnDisable = New System.Windows.Forms.Button()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDocName = New System.Windows.Forms.TextBox()
            Me.txtStation = New System.Windows.Forms.TextBox()
            Me.txtFileName = New System.Windows.Forms.TextBox()
            Me.txtPath = New System.Windows.Forms.TextBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnBrowseDocLoc = New System.Windows.Forms.Button()
            Me.cboDept = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnMap = New System.Windows.Forms.Button()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.dbgExistingDocMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboDept, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgExistingDocMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDisable, Me.btnCopySelectedRows, Me.btnCopyAll, Me.Label2, Me.txtDocName, Me.txtStation, Me.txtFileName, Me.txtPath, Me.btnClear, Me.btnUpdate, Me.btnBrowseDocLoc, Me.cboDept, Me.Label4, Me.btnMap, Me.cboModel, Me.Label1, Me.Label3})
            Me.GroupBox1.Location = New System.Drawing.Point(9, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(300, 528)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            '
            'btnDisable
            '
            Me.btnDisable.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
            Me.btnDisable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDisable.ForeColor = System.Drawing.Color.White
            Me.btnDisable.Location = New System.Drawing.Point(18, 336)
            Me.btnDisable.Name = "btnDisable"
            Me.btnDisable.Size = New System.Drawing.Size(264, 29)
            Me.btnDisable.TabIndex = 103
            Me.btnDisable.Text = "Disable"
            Me.btnDisable.Visible = False
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.White
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(144, 464)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(136, 24)
            Me.btnCopySelectedRows.TabIndex = 102
            Me.btnCopySelectedRows.Text = "Copy Selected Row"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.White
            Me.btnCopyAll.Location = New System.Drawing.Point(24, 464)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(86, 24)
            Me.btnCopyAll.TabIndex = 101
            Me.btnCopyAll.Text = "Copy All"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 136)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(122, 16)
            Me.Label2.TabIndex = 100
            Me.Label2.Text = "Document Name :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDocName
            '
            Me.txtDocName.Location = New System.Drawing.Point(8, 152)
            Me.txtDocName.Name = "txtDocName"
            Me.txtDocName.Size = New System.Drawing.Size(271, 20)
            Me.txtDocName.TabIndex = 99
            Me.txtDocName.Text = ""
            '
            'txtStation
            '
            Me.txtStation.Location = New System.Drawing.Point(8, 66)
            Me.txtStation.Name = "txtStation"
            Me.txtStation.Size = New System.Drawing.Size(271, 20)
            Me.txtStation.TabIndex = 2
            Me.txtStation.Text = ""
            '
            'txtFileName
            '
            Me.txtFileName.Location = New System.Drawing.Point(9, 256)
            Me.txtFileName.Name = "txtFileName"
            Me.txtFileName.Size = New System.Drawing.Size(271, 20)
            Me.txtFileName.TabIndex = 98
            Me.txtFileName.Text = ""
            '
            'txtPath
            '
            Me.txtPath.Location = New System.Drawing.Point(9, 224)
            Me.txtPath.Name = "txtPath"
            Me.txtPath.Size = New System.Drawing.Size(271, 20)
            Me.txtPath.TabIndex = 97
            Me.txtPath.Text = ""
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(16, 424)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(264, 24)
            Me.btnClear.TabIndex = 7
            Me.btnClear.Text = "Clear"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.White
            Me.btnUpdate.Location = New System.Drawing.Point(16, 376)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(264, 29)
            Me.btnUpdate.TabIndex = 6
            Me.btnUpdate.Text = "Update"
            Me.btnUpdate.Visible = False
            '
            'btnBrowseDocLoc
            '
            Me.btnBrowseDocLoc.BackColor = System.Drawing.Color.DarkOliveGreen
            Me.btnBrowseDocLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBrowseDocLoc.ForeColor = System.Drawing.Color.White
            Me.btnBrowseDocLoc.Location = New System.Drawing.Point(9, 184)
            Me.btnBrowseDocLoc.Name = "btnBrowseDocLoc"
            Me.btnBrowseDocLoc.Size = New System.Drawing.Size(271, 27)
            Me.btnBrowseDocLoc.TabIndex = 4
            Me.btnBrowseDocLoc.Text = "Brownse Doc Location"
            '
            'cboDept
            '
            Me.cboDept.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDept.AutoCompletion = True
            Me.cboDept.AutoDropDown = True
            Me.cboDept.AutoSelect = True
            Me.cboDept.Caption = ""
            Me.cboDept.CaptionHeight = 17
            Me.cboDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDept.ColumnCaptionHeight = 17
            Me.cboDept.ColumnFooterHeight = 17
            Me.cboDept.ColumnHeaders = False
            Me.cboDept.ContentHeight = 15
            Me.cboDept.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDept.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDept.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDept.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDept.EditorHeight = 15
            Me.cboDept.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboDept.ItemHeight = 15
            Me.cboDept.Location = New System.Drawing.Point(9, 28)
            Me.cboDept.MatchEntryTimeout = CType(2000, Long)
            Me.cboDept.MaxDropDownItems = CType(10, Short)
            Me.cboDept.MaxLength = 32767
            Me.cboDept.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDept.Name = "cboDept"
            Me.cboDept.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDept.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDept.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDept.Size = New System.Drawing.Size(271, 21)
            Me.cboDept.TabIndex = 1
            Me.cboDept.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(9, 11)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 92
            Me.Label4.Text = "Department :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnMap
            '
            Me.btnMap.BackColor = System.Drawing.Color.Green
            Me.btnMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMap.ForeColor = System.Drawing.Color.White
            Me.btnMap.Location = New System.Drawing.Point(18, 290)
            Me.btnMap.Name = "btnMap"
            Me.btnMap.Size = New System.Drawing.Size(262, 30)
            Me.btnMap.TabIndex = 5
            Me.btnMap.Text = "Map"
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ColumnHeaders = False
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(9, 106)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(271, 21)
            Me.cboModel.TabIndex = 3
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(9, 90)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(122, 16)
            Me.Label1.TabIndex = 87
            Me.Label1.Text = "Model/General :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(2, 50)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(66, 19)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "Station :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgExistingDocMap
            '
            Me.dbgExistingDocMap.AllowUpdate = False
            Me.dbgExistingDocMap.AlternatingRows = True
            Me.dbgExistingDocMap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgExistingDocMap.FilterBar = True
            Me.dbgExistingDocMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgExistingDocMap.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgExistingDocMap.Location = New System.Drawing.Point(318, 9)
            Me.dbgExistingDocMap.Name = "dbgExistingDocMap"
            Me.dbgExistingDocMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgExistingDocMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgExistingDocMap.PreviewInfo.ZoomFactor = 75
            Me.dbgExistingDocMap.Size = New System.Drawing.Size(442, 519)
            Me.dbgExistingDocMap.TabIndex = 10
            Me.dbgExistingDocMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>5" & _
            "15</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 438, 515<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 438, 515</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmDocMapFileLoc
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(776, 550)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgExistingDocMap, Me.GroupBox1})
            Me.Name = "frmDocMapFileLoc"
            Me.Text = "frmDocMapFileLoc"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboDept, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgExistingDocMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************
        Private Sub frmDocMapFileLoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                dt = Me._objDocMap.GetDepartment()
                Misc.PopulateC1DropDownList(Me.cboDept, dt, "DepartmentDesc", "DepartmentID")
                Me.cboDept.SelectedValue = 585

                Generic.DisposeDT(dt)
                dt = Me._objDocMap.GetModelGeneral(True, )
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_desc", "Model_id")
                Me.cboModel.SelectedValue = 0

                Me.cboDept.Focus()
                Me.txtFileName.ReadOnly = True
                Me.txtPath.ReadOnly = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmPIPModelUPH_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub

        '****************************************************************
        Private Sub btnMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMap.Click
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                If ValidatetoUpdate() = 1 Then
                    dt = Me._objDocMap.GetDeptDoc(Me.cboDept.SelectedValue)
                    For Each R1 In dt.Rows
                        If (R1("Department Desc") = Me.cboDept.Text AndAlso R1("Station Type") = Me.txtStation.Text AndAlso R1("Model/General") = Me.cboModel.Text _
                        AndAlso R1("Document Name") = Me.txtDocName.Text AndAlso R1("Directory Path") = Me.txtPath.Text AndAlso R1("File Name") = Me.txtFileName.Text) Then
                            Throw New Exception("This entry's already existed, can only be updated.")
                        End If
                    Next R1

                    If MessageBox.Show("Are you sure you want to add?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    i = Me._objDocMap.InsertintoDocMap(PSS.Core.ApplicationUser.IDuser, Me.cboDept.SelectedValue, _
                                                       Me.cboModel.Text, Me.txtDocName.Text, _strFilePath, _
                                                       Me.txtFileName.Text, Me.txtStation.Text)

                    If i = 1 Then
                        MessageBox.Show("Inserted was successfully.")
                        Clear()
                    Else
                        MessageBox.Show("Inserted was failed. Please contact IT.")
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '****************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim i As Integer = 0
            Dim j As Integer = 0
            Try

                If MessageBox.Show("Are you sure you want to update?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
                If ValidatetoUpdate() = 1 Then
                    If Me.dbgExistingDocMap.Columns("Directory Path").Text = Me.txtPath.Text And Me.dbgExistingDocMap.Columns("File Name").Text = Me.txtFileName.Text Then
                        'Throw New Exception("Directory Path and File Name are the same as previous; no update was made.")
                    End If

                    If (_iDocMapID > 0) Then
                        i = Me._objDocMap.UpdateDocMap(_iDocMapID, Me.cboDept.SelectedValue, Me.txtPath.Text.Replace("\", "\\"), _
                        Me.txtFileName.Text, Me.txtDocName.Text, PSS.Core.ApplicationUser.IDuser, _
                                 Me.cboModel.Text, Me.txtStation.Text)
                        If i = 1 Then
                            MessageBox.Show("Updated was successfully.")
                            Clear()
                        Else
                            MessageBox.Show("Updated was failed, Please contact IT.")
                        End If
                    Else
                        MessageBox.Show("Document ID is zero. Please contact IT.")
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '****************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Clear()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '********************************************************************
        Private Sub Clear()
            Me.btnUpdate.Visible = False
            Me.btnDisable.Visible = False
            Me.txtFileName.Text = ""
            Me.txtPath.Text = ""
            Me.txtStation.Text = ""
            Me.txtDocName.Text = ""
            Me.cboModel.SelectedValue = 0
            Me.dbgExistingDocMap.ClearFields()
            Me.cboModel.Enabled = True
            Me.cboDept.Enabled = True
            Me.txtStation.Enabled = True
            Me.txtDocName.Enabled = True
            Me.btnMap.Enabled = True
            Me.cboDept.Focus()
            Me.cboDept.SelectAll()
            Me._strFilePath = ""
            Me._iDocMapID = 0
        End Sub

        '********************************************************************
        Private Sub cboDept_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDept.Leave
            Try
                Me.PopulateDeptDocDBG()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboGroups_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Public Sub PopulateDeptDocDBG()
            Dim dt As DataTable
            Try
                Me.dbgExistingDocMap.DataSource = Nothing
                If Me.cboDept.SelectedValue > 0 Then
                    dt = Me._objDocMap.GetDeptDoc(Me.cboDept.SelectedValue)
                    With Me.dbgExistingDocMap
                        .DataSource = dt.DefaultView
                        SetGridGroupModelProperties()
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateDeptDocDBG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Sub SetGridGroupModelProperties()
            Dim iNumOfColumns As Integer = Me.dbgExistingDocMap.Columns.Count
            Dim i As Integer

            With Me.dbgExistingDocMap
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
                .Splits(0).DisplayColumns(5).HeadingStyle.ForeColor = .ForeColor.Black

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Body Forecolor
                .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(4).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(5).Style.ForeColor = .ForeColor.Black

                'Set Column Widths
                .Splits(0).DisplayColumns("Department Desc").Width = 150
                .Splits(0).DisplayColumns("Station Type").Width = 100
                .Splits(0).DisplayColumns("Model/General").Width = 70
                .Splits(0).DisplayColumns("Document Name").Width = 200
                .Splits(0).DisplayColumns("Directory Path").Width = 120
                .Splits(0).DisplayColumns("File Name").Width = 150

                .Splits(0).DisplayColumns("DMID").Visible = False

                .AlternatingRows = True
            End With
        End Sub

        '********************************************************************
        Private Sub dbgExistingDocMap_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgExistingDocMap.DoubleClick
            Dim j As Integer = 0
            Try

                Me.cboDept.Text = Me.dbgExistingDocMap.Columns("Department Desc").Value.ToString
                Me.txtStation.Text = Me.dbgExistingDocMap.Columns("Station Type").Value.ToString
                Me.cboModel.Text = Me.dbgExistingDocMap.Columns("Model/General").Value.ToString
                Me.txtDocName.Text = Me.dbgExistingDocMap.Columns("Document Name").Value.ToString
                Me.txtPath.Text = Me.dbgExistingDocMap.Columns("Directory Path").Value.ToString
                Me.txtFileName.Text = Me.dbgExistingDocMap.Columns("File Name").Value.ToString

                j = ValidatetoUpdate()
                If j = 1 Then
                    _iDocMapID = CInt(Me.dbgExistingDocMap.Columns("DMID").Value.ToString)
                    Me.btnMap.Enabled = False
                    Me.btnUpdate.Visible = True
                    Me.btnDisable.Visible = True
                    Me.cboModel.Enabled = True ' 3/21/2011 Hung change to Enable= True for Model,Station & DocName
                    Me.cboDept.Enabled = False
                    Me.txtStation.Enabled = True
                    Me.txtDocName.Enabled = True
                    Me.txtPath.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgExistingDocMap_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        '********************************************************************
        Private Function ValidatetoUpdate() As Integer
            Try
                If Me.cboDept.SelectedValue < 1 Then
                    MessageBox.Show("Department is missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboDept.Focus()
                    Exit Function

                    'ElseIf Trim(Me.TextBox1.Text) = "" Then
                    '    MessageBox.Show("Station is missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Me.TextBox1.Focus()
                    '    Exit Function
                ElseIf Trim(Me.txtDocName.Text) = "" Then
                    MessageBox.Show("Document Name is missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtStation.Focus()
                    Exit Function
                ElseIf Trim(Me.txtPath.Text) = "" Then
                    MessageBox.Show("Directory path is missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtStation.Focus()
                    Exit Function
                End If

                Return 1
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ValidatetoUpdate", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '********************************************************************
        Private Sub btnBrowseDocLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBrowseDocLoc.Click
            Dim iPos, iOth As Integer
            Dim strFilePath As String = ""
            Dim strFileName As String = ""

            Try
                Me.OpenFileDialog1.FilterIndex = 1
                Me.OpenFileDialog1.ShowDialog()
                strFilePath = Trim(Me.OpenFileDialog1.FileName)
                iPos = strFilePath.LastIndexOfAny("\")
                iPos += 1
                strFileName = strFilePath.Substring(iPos, (Len(strFilePath) - iPos))
                'strFileName = strFileName.Substring(0, strFileName.LastIndexOfAny("."))
                strFilePath = strFilePath.Substring(0, iPos - 1)
                _strFilePath = strFilePath.Replace("\", "\\")
                If strFilePath.Trim.Length = 0 Or strFileName.Trim.Length = 0 Then
                    Exit Sub
                End If

                Me.txtFileName.Text = strFileName
                Me.txtPath.Text = strFilePath
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnBrowseData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub KeyUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModel.KeyUp, txtDocName.KeyUp, cboDept.KeyUp, txtStation.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Select Case sender.Name
                        Case "C1Combo1"
                            If Me.cboDept.SelectedValue > 0 Then
                                Me.PopulateDeptDocDBG()
                                Me.txtStation.Focus()
                            Else
                                Me.cboDept.Focus() : End If

                        Case "txtStation"
                            If Me.txtStation.Text <> "" Then
                                Me.cboModel.Focus()
                            Else
                                Me.txtStation.Focus() : End If

                        Case "cboModel"
                            Me.txtDocName.Focus()

                        Case "txtDocName"
                            If Me.txtDocName.Text <> "" Then
                                Me.btnBrowseDocLoc.Focus()
                            Else
                                Me.txtDocName.Focus()
                            End If
                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************
        Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
            Dim strData As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim strHeader As String = ""
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                If Me.dbgExistingDocMap.RowCount > 0 And Me.dbgExistingDocMap.Columns.Count > 0 Then
                    'loop through each row
                    For iRow = 0 To Me.dbgExistingDocMap.RowCount - 1
                        'loop through each column
                        For Each col In Me.dbgExistingDocMap.Columns
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If

                            'Data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)

                    ''print data
                    'Me._objSPPLF.CreateExelReportToPrint(strData, Chr(65 + Me.grdWaitingShipment.Columns.Count - 1) & Me.grdWaitingShipment.RowCount + 1)
                    'MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("No data.", "Copy All", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************
        Private Sub btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedRows.Click
            Dim strData As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim strHeader As String = ""

            Try
                If Me.dbgExistingDocMap.SelectedRows.Count > 0 And Me.dbgExistingDocMap.SelectedCols.Count Then
                    'loop through each selected row
                    For Each iRow In Me.dbgExistingDocMap.SelectedRows

                        'loop through each selected column
                        For Each col In Me.dbgExistingDocMap.SelectedCols
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)

                    'print data
                    'Me._objSPPLF.CreateExelReportToPrint(strData, Chr(65 + Me.grdWaitingShipment.SelectedCols.Count - 1) & Me.grdWaitingShipment.SelectedRows.Count + 1)
                    'MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Please select a range of cells to copy.", "Copy Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCopySelectedRows_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************


        Private Sub btnDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisable.Click
            Dim i As Integer = 0
            Try

                If MessageBox.Show("Are you sure you want to disable this document?", "Disable Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
                If ValidatetoUpdate() = 1 Then

                    If (_iDocMapID > 0) Then

                        If Me._objDocMap.DisableDocMap(_iDocMapID, PSS.Core.ApplicationUser.IDuser) = 1 Then
                            MessageBox.Show(txtDocName.Text & " has been disabled.")
                            Clear()
                        Else
                            MessageBox.Show("Disable was failed, Please contact IT.")
                        End If
                    Else
                        MessageBox.Show("Document ID is zero. Please contact IT.")
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDisable_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try
        End Sub

        Private Sub dbgExistingDocMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgExistingDocMap.Click

        End Sub
    End Class
End Namespace