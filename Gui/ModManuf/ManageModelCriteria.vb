Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui

    Public Class ManageModelCriteria
        Inherits System.Windows.Forms.Form

        Private _objModManuf As ModManuf
        Private _iMenuCustID As Integer = 0
        Private _iMenuProdID As Integer = 0
        Private _iMenuManufID As Integer = 0
        Private _booLoadData As Boolean = False
        Private _booEOL As Boolean = False
        Private _booRecycle As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, _
                       Optional ByVal iManufID As Integer = 0, _
                       Optional ByVal iProdID As Integer = 0, _
                       Optional ByVal booEOL As Boolean = False, _
                       Optional ByVal booRecycle As Boolean = False)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objModManuf = New ModManuf()

            _iMenuCustID = iCustID
            _iMenuProdID = iProdID
            _iMenuManufID = iManufID
            _booEOL = booEOL
            _booRecycle = booRecycle
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
        Friend WithEvents gbAddModel As System.Windows.Forms.GroupBox
        Friend WithEvents btnAddModel As System.Windows.Forms.Button
        Friend WithEvents dbgNewModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents gbSetModelCriteria As System.Windows.Forms.GroupBox
        Friend WithEvents btnRefreshList As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents rbtnEOLNo As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnEOLYes As System.Windows.Forms.RadioButton
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents gbRecycle As System.Windows.Forms.GroupBox
        Friend WithEvents rbtnRecycleNo As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnRecycleYes As System.Windows.Forms.RadioButton
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents cboProducts As C1.Win.C1List.C1Combo
        Friend WithEvents btnEOL As System.Windows.Forms.Button
        Friend WithEvents btnRecycle As System.Windows.Forms.Button
        Friend WithEvents gbUpdate As System.Windows.Forms.GroupBox
        Friend WithEvents btnActive As System.Windows.Forms.Button
        Friend WithEvents btnNoneRecycle As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboManuf As C1.Win.C1List.C1Combo
        Friend WithEvents dbgModelCriteria As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ManageModelCriteria))
            Me.gbAddModel = New System.Windows.Forms.GroupBox()
            Me.btnAddModel = New System.Windows.Forms.Button()
            Me.dbgNewModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.gbSetModelCriteria = New System.Windows.Forms.GroupBox()
            Me.rbtnEOLNo = New System.Windows.Forms.RadioButton()
            Me.rbtnEOLYes = New System.Windows.Forms.RadioButton()
            Me.gbRecycle = New System.Windows.Forms.GroupBox()
            Me.rbtnRecycleNo = New System.Windows.Forms.RadioButton()
            Me.rbtnRecycleYes = New System.Windows.Forms.RadioButton()
            Me.btnEOL = New System.Windows.Forms.Button()
            Me.dbgModelCriteria = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefreshList = New System.Windows.Forms.Button()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnRecycle = New System.Windows.Forms.Button()
            Me.cboProducts = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.gbUpdate = New System.Windows.Forms.GroupBox()
            Me.btnNoneRecycle = New System.Windows.Forms.Button()
            Me.btnActive = New System.Windows.Forms.Button()
            Me.cboManuf = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.gbAddModel.SuspendLayout()
            CType(Me.dbgNewModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbSetModelCriteria.SuspendLayout()
            Me.gbRecycle.SuspendLayout()
            CType(Me.dbgModelCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbUpdate.SuspendLayout()
            CType(Me.cboManuf, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'gbAddModel
            '
            Me.gbAddModel.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbAddModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddModel, Me.dbgNewModel, Me.gbSetModelCriteria, Me.gbRecycle})
            Me.gbAddModel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbAddModel.ForeColor = System.Drawing.Color.White
            Me.gbAddModel.Location = New System.Drawing.Point(416, 48)
            Me.gbAddModel.Name = "gbAddModel"
            Me.gbAddModel.Size = New System.Drawing.Size(344, 496)
            Me.gbAddModel.TabIndex = 7
            Me.gbAddModel.TabStop = False
            Me.gbAddModel.Text = "Add Model(s)"
            '
            'btnAddModel
            '
            Me.btnAddModel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnAddModel.BackColor = System.Drawing.Color.Green
            Me.btnAddModel.Location = New System.Drawing.Point(32, 448)
            Me.btnAddModel.Name = "btnAddModel"
            Me.btnAddModel.Size = New System.Drawing.Size(248, 32)
            Me.btnAddModel.TabIndex = 3
            Me.btnAddModel.Text = "Add Selected Model(s)"
            '
            'dbgNewModel
            '
            Me.dbgNewModel.AllowUpdate = False
            Me.dbgNewModel.AlternatingRows = True
            Me.dbgNewModel.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgNewModel.CaptionHeight = 17
            Me.dbgNewModel.FilterBar = True
            Me.dbgNewModel.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgNewModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgNewModel.Location = New System.Drawing.Point(8, 96)
            Me.dbgNewModel.Name = "dbgNewModel"
            Me.dbgNewModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgNewModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgNewModel.PreviewInfo.ZoomFactor = 75
            Me.dbgNewModel.RowHeight = 15
            Me.dbgNewModel.Size = New System.Drawing.Size(328, 336)
            Me.dbgNewModel.TabIndex = 2
            Me.dbgNewModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 9pt, style=Bold;BackColor" & _
            ":SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style1" & _
            "8{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{" & _
            "}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:Highl" & _
            "ightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{" & _
            "}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Even" & _
            "Row{BackColor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1," & _
            " 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans S" & _
            "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
            "Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}St" & _
            "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
            "der"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>332</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 0, 324, 332</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
            "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 324, 332</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintP" & _
            "ageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'gbSetModelCriteria
            '
            Me.gbSetModelCriteria.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbSetModelCriteria.BackColor = System.Drawing.Color.SteelBlue
            Me.gbSetModelCriteria.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnEOLNo, Me.rbtnEOLYes})
            Me.gbSetModelCriteria.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbSetModelCriteria.ForeColor = System.Drawing.Color.White
            Me.gbSetModelCriteria.Location = New System.Drawing.Point(16, 32)
            Me.gbSetModelCriteria.Name = "gbSetModelCriteria"
            Me.gbSetModelCriteria.Size = New System.Drawing.Size(128, 48)
            Me.gbSetModelCriteria.TabIndex = 0
            Me.gbSetModelCriteria.TabStop = False
            Me.gbSetModelCriteria.Text = "EOL ??"
            '
            'rbtnEOLNo
            '
            Me.rbtnEOLNo.Location = New System.Drawing.Point(64, 16)
            Me.rbtnEOLNo.Name = "rbtnEOLNo"
            Me.rbtnEOLNo.Size = New System.Drawing.Size(40, 24)
            Me.rbtnEOLNo.TabIndex = 1
            Me.rbtnEOLNo.Text = "No"
            '
            'rbtnEOLYes
            '
            Me.rbtnEOLYes.Location = New System.Drawing.Point(8, 16)
            Me.rbtnEOLYes.Name = "rbtnEOLYes"
            Me.rbtnEOLYes.Size = New System.Drawing.Size(48, 24)
            Me.rbtnEOLYes.TabIndex = 0
            Me.rbtnEOLYes.Text = "Yes"
            '
            'gbRecycle
            '
            Me.gbRecycle.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbRecycle.BackColor = System.Drawing.Color.SteelBlue
            Me.gbRecycle.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnRecycleNo, Me.rbtnRecycleYes})
            Me.gbRecycle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbRecycle.ForeColor = System.Drawing.Color.White
            Me.gbRecycle.Location = New System.Drawing.Point(224, 32)
            Me.gbRecycle.Name = "gbRecycle"
            Me.gbRecycle.Size = New System.Drawing.Size(112, 48)
            Me.gbRecycle.TabIndex = 1
            Me.gbRecycle.TabStop = False
            Me.gbRecycle.Text = "Recycle ??"
            '
            'rbtnRecycleNo
            '
            Me.rbtnRecycleNo.Location = New System.Drawing.Point(64, 16)
            Me.rbtnRecycleNo.Name = "rbtnRecycleNo"
            Me.rbtnRecycleNo.Size = New System.Drawing.Size(40, 24)
            Me.rbtnRecycleNo.TabIndex = 1
            Me.rbtnRecycleNo.Text = "No"
            '
            'rbtnRecycleYes
            '
            Me.rbtnRecycleYes.Location = New System.Drawing.Point(8, 16)
            Me.rbtnRecycleYes.Name = "rbtnRecycleYes"
            Me.rbtnRecycleYes.Size = New System.Drawing.Size(48, 24)
            Me.rbtnRecycleYes.TabIndex = 0
            Me.rbtnRecycleYes.Text = "Yes"
            '
            'btnEOL
            '
            Me.btnEOL.Location = New System.Drawing.Point(8, 24)
            Me.btnEOL.Name = "btnEOL"
            Me.btnEOL.Size = New System.Drawing.Size(64, 24)
            Me.btnEOL.TabIndex = 0
            Me.btnEOL.Text = "EOL"
            '
            'dbgModelCriteria
            '
            Me.dbgModelCriteria.AllowUpdate = False
            Me.dbgModelCriteria.AlternatingRows = True
            Me.dbgModelCriteria.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgModelCriteria.FilterBar = True
            Me.dbgModelCriteria.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgModelCriteria.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgModelCriteria.Location = New System.Drawing.Point(16, 56)
            Me.dbgModelCriteria.Name = "dbgModelCriteria"
            Me.dbgModelCriteria.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgModelCriteria.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgModelCriteria.PreviewInfo.ZoomFactor = 75
            Me.dbgModelCriteria.Size = New System.Drawing.Size(392, 400)
            Me.dbgModelCriteria.TabIndex = 4
            Me.dbgModelCriteria.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "96</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 388, 396<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 388, 396</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnRefreshList
            '
            Me.btnRefreshList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshList.ForeColor = System.Drawing.Color.White
            Me.btnRefreshList.Location = New System.Drawing.Point(648, 16)
            Me.btnRefreshList.Name = "btnRefreshList"
            Me.btnRefreshList.Size = New System.Drawing.Size(112, 24)
            Me.btnRefreshList.TabIndex = 3
            Me.btnRefreshList.Text = "Refresh List"
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
            Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(16, 16)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(10, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(200, 21)
            Me.cboCustomers.TabIndex = 1
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 2)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 231
            Me.Label3.Text = "Customer :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnRecycle
            '
            Me.btnRecycle.BackColor = System.Drawing.Color.Yellow
            Me.btnRecycle.ForeColor = System.Drawing.Color.Black
            Me.btnRecycle.Location = New System.Drawing.Point(192, 24)
            Me.btnRecycle.Name = "btnRecycle"
            Me.btnRecycle.Size = New System.Drawing.Size(72, 24)
            Me.btnRecycle.TabIndex = 2
            Me.btnRecycle.Text = "Recycle"
            '
            'cboProducts
            '
            Me.cboProducts.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProducts.AutoCompletion = True
            Me.cboProducts.AutoDropDown = True
            Me.cboProducts.AutoSelect = True
            Me.cboProducts.Caption = ""
            Me.cboProducts.CaptionHeight = 17
            Me.cboProducts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProducts.ColumnCaptionHeight = 17
            Me.cboProducts.ColumnFooterHeight = 17
            Me.cboProducts.ColumnHeaders = False
            Me.cboProducts.ContentHeight = 15
            Me.cboProducts.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProducts.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProducts.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProducts.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProducts.EditorHeight = 15
            Me.cboProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProducts.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboProducts.ItemHeight = 15
            Me.cboProducts.Location = New System.Drawing.Point(240, 16)
            Me.cboProducts.MatchEntryTimeout = CType(2000, Long)
            Me.cboProducts.MaxDropDownItems = CType(10, Short)
            Me.cboProducts.MaxLength = 32767
            Me.cboProducts.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProducts.Name = "cboProducts"
            Me.cboProducts.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProducts.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProducts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProducts.Size = New System.Drawing.Size(184, 21)
            Me.cboProducts.TabIndex = 2
            Me.cboProducts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(240, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 234
            Me.Label1.Text = "Product :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'gbUpdate
            '
            Me.gbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbUpdate.BackColor = System.Drawing.Color.SteelBlue
            Me.gbUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnNoneRecycle, Me.btnActive, Me.btnEOL, Me.btnRecycle})
            Me.gbUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbUpdate.ForeColor = System.Drawing.Color.White
            Me.gbUpdate.Location = New System.Drawing.Point(16, 472)
            Me.gbUpdate.Name = "gbUpdate"
            Me.gbUpdate.Size = New System.Drawing.Size(392, 72)
            Me.gbUpdate.TabIndex = 5
            Me.gbUpdate.TabStop = False
            Me.gbUpdate.Text = "Set Selected Row(s) To"
            '
            'btnNoneRecycle
            '
            Me.btnNoneRecycle.Location = New System.Drawing.Point(288, 24)
            Me.btnNoneRecycle.Name = "btnNoneRecycle"
            Me.btnNoneRecycle.Size = New System.Drawing.Size(96, 24)
            Me.btnNoneRecycle.TabIndex = 3
            Me.btnNoneRecycle.Text = "No Recycle"
            '
            'btnActive
            '
            Me.btnActive.BackColor = System.Drawing.Color.Green
            Me.btnActive.Location = New System.Drawing.Point(96, 24)
            Me.btnActive.Name = "btnActive"
            Me.btnActive.Size = New System.Drawing.Size(72, 24)
            Me.btnActive.TabIndex = 1
            Me.btnActive.Text = "Active"
            '
            'cboManuf
            '
            Me.cboManuf.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboManuf.AutoCompletion = True
            Me.cboManuf.AutoDropDown = True
            Me.cboManuf.AutoSelect = True
            Me.cboManuf.Caption = ""
            Me.cboManuf.CaptionHeight = 17
            Me.cboManuf.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboManuf.ColumnCaptionHeight = 17
            Me.cboManuf.ColumnFooterHeight = 17
            Me.cboManuf.ColumnHeaders = False
            Me.cboManuf.ContentHeight = 15
            Me.cboManuf.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboManuf.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboManuf.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManuf.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboManuf.EditorHeight = 15
            Me.cboManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManuf.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboManuf.ItemHeight = 15
            Me.cboManuf.Location = New System.Drawing.Point(448, 16)
            Me.cboManuf.MatchEntryTimeout = CType(2000, Long)
            Me.cboManuf.MaxDropDownItems = CType(10, Short)
            Me.cboManuf.MaxLength = 32767
            Me.cboManuf.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManuf.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManuf.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManuf.Size = New System.Drawing.Size(184, 21)
            Me.cboManuf.TabIndex = 235
            Me.cboManuf.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(448, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 16)
            Me.Label2.TabIndex = 236
            Me.Label2.Text = "Manufacture :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'ManageModelCriteria
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(768, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboManuf, Me.Label2, Me.gbUpdate, Me.cboProducts, Me.Label1, Me.cboCustomers, Me.Label3, Me.btnRefreshList, Me.gbAddModel, Me.dbgModelCriteria})
            Me.Name = "ManageModelCriteria"
            Me.Text = "ManageModelCriteria"
            Me.gbAddModel.ResumeLayout(False)
            CType(Me.dbgNewModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbSetModelCriteria.ResumeLayout(False)
            Me.gbRecycle.ResumeLayout(False)
            CType(Me.dbgModelCriteria, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbUpdate.ResumeLayout(False)
            CType(Me.cboManuf, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*****************************************************************************
        Private Sub ManageModelCriteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me.rbtnEOLYes.Checked = Me._booEOL
                Me.rbtnRecycleYes.Checked = Me._booRecycle

                _booLoadData = True
                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                If Me._iMenuCustID > 0 Then
                    Me.cboCustomers.SelectedValue = _iMenuCustID
                    Me.cboCustomers.Enabled = False
                End If

                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProducts, dt, "Prod_Desc", "Prod_ID")
                If Me._iMenuProdID > 0 Then
                    Me.cboProducts.SelectedValue = _iMenuProdID
                    Me.cboProducts.Enabled = False
                End If

                dt = Generic.GetManufactures(True)
                Misc.PopulateC1DropDownList(Me.cboManuf, dt, "Manuf_Desc", "Manuf_ID")
                If Me._iMenuManufID > 0 Then
                    Me.cboManuf.SelectedValue = _iMenuManufID
                    If Me._iMenuManufID > 0 Then Me.cboManuf.Enabled = False
                End If

                If Me.cboCustomers.SelectedValue > 0 Then
                    Me.LoadNewModelList(Me._iMenuCustID, Me._iMenuProdID, Me._iMenuManufID)
                    LoadModelCriteria(_iMenuCustID, _iMenuProdID, _iMenuManufID)
                End If

                '*********************************
                'Set Special permissions
                '*********************************
                If PSS.Core.ApplicationUser.GetPermission("ManageModelCriteria") > 0 Then
                    Me.gbAddModel.Visible = True
                    Me.gbSetModelCriteria.Visible = True
                Else
                    Me.gbAddModel.Visible = False
                    Me.gbSetModelCriteria.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                _booLoadData = False
            End Try
        End Sub

        '******************************************************************************
        Private Sub LoadModelCriteria(ByVal iCustID As Integer, ByVal iProdID As Integer, ByVal iManufID As Integer)
            Dim dt As DataTable

            Try
                dt = _objModManuf.GetModelCriteria(iCustID, iManufID, iProdID)
                With Me.dbgModelCriteria
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Model_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    .Splits(0).DisplayColumns("Manuf_ID").Visible = False
                    .Splits(0).DisplayColumns("ModelCriteria_ID").Visible = False
                    .Splits(0).DisplayColumns("Model").Width = 150
                    .Splits(0).DisplayColumns("Product").Width = 120
                    .Splits(0).DisplayColumns("Manuf").Width = 130
                    .Splits(0).DisplayColumns("EOL?").Width = 30
                    .Splits(0).DisplayColumns("Recycle?").Width = 50
                    .Splits(0).DisplayColumns("Update By").Width = 150
                    .Splits(0).DisplayColumns("Update Date").Width = 60
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************
        Private Sub LoadNewModelList(ByVal iCustID As Integer, ByVal iProdID As Integer, ByVal iManufID As Integer)
            Dim dt As DataTable

            Try
                dt = _objModManuf.GetMissingModelCriteria(iManufID, iProdID)
                With Me.dbgNewModel
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Model_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    .Splits(0).DisplayColumns("Manuf_ID").Visible = False
                    .Splits(0).DisplayColumns("Model").Width = 150
                    .Splits(0).DisplayColumns("Product").Width = 120
                    .Splits(0).DisplayColumns("Manuf").Width = 130
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cbos_ValueMemberChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.ValueMemberChanged, cboProducts.ValueMemberChanged, cboManuf.ValueMemberChanged
            Try
                If Me._booLoadData = True Then Exit Sub
                Me.dbgModelCriteria.DataSource = Nothing
                Me.dbgNewModel.DataSource = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & "_ValueMemberChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnAddModel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddModel.Click
            Dim iRow, iModelID, iEOL, iRecycle, i As Integer

            Try
                If Me.dbgNewModel.SelectedRows.Count > 0 Then
                    If Me.rbtnEOLYes.Checked = False AndAlso Me.rbtnEOLNo.Checked = False Then
                        MessageBox.Show("Please select End Of Line status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf Me.rbtnRecycleYes.Checked = False AndAlso Me.rbtnRecycleNo.Checked = False Then
                        MessageBox.Show("Please select Recycle status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    'loop through each selected row
                    For Each iRow In Me.dbgNewModel.SelectedRows
                        iModelID = Me.dbgNewModel.Columns("Model_ID").CellValue(iRow)
                        If Me.rbtnEOLYes.Checked = True Then iEOL = 1 Else iEOL = 0
                        If Me.rbtnRecycleYes.Checked = True Then iRecycle = 1 Else iRecycle = 0

                        i += Me._objModManuf.AddModelcriteria(Me.cboCustomers.SelectedValue, iModelID, iEOL, iRecycle, PSS.Core.ApplicationUser.IDuser)
                    Next iRow

                    LoadModelCriteria(Me.cboCustomers.SelectedValue, Me.cboProducts.SelectedValue, Me.cboManuf.SelectedValue)
                    LoadNewModelList(Me.cboCustomers.SelectedValue, Me.cboProducts.SelectedValue, Me.cboManuf.SelectedValue)
                Else
                    MessageBox.Show("Please select rows to update.", "Selected Row Required ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddModel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnUpdateModelCriteria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEOL.Click, btnActive.Click, btnRecycle.Click, btnNoneRecycle.Click
            Dim iRow, i, iValue, iModelCriteriaID As Integer
            Dim strModelCriteriaIDs As String = ""

            Try
                If Me.dbgModelCriteria.SelectedRows.Count > 0 Then
                    'loop through each selected row
                    For Each iRow In Me.dbgModelCriteria.SelectedRows
                        If strModelCriteriaIDs.Trim.Length > 0 Then strModelCriteriaIDs &= ", "
                        strModelCriteriaIDs &= Me.dbgModelCriteria.Columns("ModelCriteria_ID").CellValue(iRow)
                    Next iRow

                    If strModelCriteriaIDs.Trim.Length > 0 Then
                        If sender.name = "btnEOL" OrElse sender.name = "btnActive" Then
                            If sender.name = "btnEOL" Then iValue = 1 Else iValue = 0
                            i += Me._objModManuf.SetTmodelcriteriaEndOfLife(strModelCriteriaIDs, iValue, PSS.Core.ApplicationUser.IDuser)
                        ElseIf sender.name = "btnRecycle" OrElse sender.name = "btnNoneRecycle" Then
                            If sender.name = "btnRecycle" Then iValue = 1 Else iValue = 0
                            i += Me._objModManuf.SetTmodelcriteriaRecycle(strModelCriteriaIDs, iValue, PSS.Core.ApplicationUser.IDuser)
                        End If

                        If MessageBox.Show("Do you want to refresh the list.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            LoadModelCriteria(Me.cboCustomers.SelectedValue, Me.cboProducts.SelectedValue, Me.cboManuf.SelectedValue)
                        End If
                    End If
                Else
                    MessageBox.Show("Please select rows to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub dbgModelCriteria_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgModelCriteria.MouseDown
            Try
                If Me.dbgModelCriteria.RowCount > 0 AndAlso e.Button = MouseButtons.Right Then
                    Dim cmiCopyAll As New MenuItem("Copy All")
                    Dim cmiCopySelItem As New MenuItem("Copy Selected Row(s)")
                    Dim cmContextMenu As New ContextMenu()
                    cmContextMenu.MenuItems.Add(cmiCopyAll)
                    cmContextMenu.MenuItems.Add(cmiCopySelItem)

                    RemoveHandler cmiCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler cmiCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler cmiCopySelItem.Click, AddressOf CMenuCopySelectedData
                    AddHandler cmiCopySelItem.Click, AddressOf CMenuCopySelectedData

                    dbgModelCriteria.ContextMenu = cmContextMenu
                    dbgModelCriteria.ContextMenu.Show(dbgModelCriteria, New Point(e.X, e.Y))

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgModelCriteria_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dbgModelCriteria)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dbgModelCriteria)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*****************************************************************************

    End Class
End Namespace