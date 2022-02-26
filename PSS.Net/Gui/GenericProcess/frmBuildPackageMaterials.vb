Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Namespace Gui.GenericProcess
    Public Class frmBuildPackageMaterials
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer
        Private _iMenuManufID As Integer
        Private _iUserID As Integer = Core.ApplicationUser.IDuser
        Private _dtModels As DataTable
        Private _dtParts As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer, ByVal iManufID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strScreenName = strScreenName
            Me._iMenuCustID = iCustID
            Me._iMenuManufID = iManufID

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
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents lblPart As System.Windows.Forms.Label
        Friend WithEvents cboPart As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents tdgModelPart As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblRecNum1 As System.Windows.Forms.Label
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuildPackageMaterials))
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.lblPart = New System.Windows.Forms.Label()
            Me.cboPart = New C1.Win.C1List.C1Combo()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.tdgModelPart = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblRecNum1 = New System.Windows.Forms.Label()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.btnRemove = New System.Windows.Forms.Button()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPart, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgModelPart, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(0, 24)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(136, 16)
            Me.lblModel.TabIndex = 129
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(0, 40)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(320, 21)
            Me.cboModel.TabIndex = 3
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
            "tyle9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.L" & _
            "istBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScroll" & _
            "Group=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar" & _
            "><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capt" & _
            "ionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=" & _
            """Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style " & _
            "parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Hea" & _
            "ding"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headin" & _
            "g"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal""" & _
            " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
            """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>" & _
            ""
            '
            'lblPart
            '
            Me.lblPart.BackColor = System.Drawing.Color.Transparent
            Me.lblPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPart.ForeColor = System.Drawing.Color.Black
            Me.lblPart.Location = New System.Drawing.Point(328, 24)
            Me.lblPart.Name = "lblPart"
            Me.lblPart.Size = New System.Drawing.Size(136, 16)
            Me.lblPart.TabIndex = 131
            Me.lblPart.Text = "Part:"
            Me.lblPart.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboPart
            '
            Me.cboPart.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPart.Caption = ""
            Me.cboPart.CaptionHeight = 17
            Me.cboPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPart.ColumnCaptionHeight = 17
            Me.cboPart.ColumnFooterHeight = 17
            Me.cboPart.ContentHeight = 15
            Me.cboPart.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPart.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPart.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPart.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPart.EditorHeight = 15
            Me.cboPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPart.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboPart.ItemHeight = 15
            Me.cboPart.Location = New System.Drawing.Point(328, 40)
            Me.cboPart.MatchEntryTimeout = CType(2000, Long)
            Me.cboPart.MaxDropDownItems = CType(5, Short)
            Me.cboPart.MaxLength = 32767
            Me.cboPart.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPart.Name = "cboPart"
            Me.cboPart.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPart.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPart.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPart.Size = New System.Drawing.Size(320, 21)
            Me.cboPart.TabIndex = 4
            Me.cboPart.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
            "tyle1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Con" & _
            "trol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}S" & _
            "tyle10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.L" & _
            "istBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScroll" & _
            "Group=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar" & _
            "><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capt" & _
            "ionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=" & _
            """Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style " & _
            "parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Hea" & _
            "ding"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headin" & _
            "g"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal""" & _
            " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
            """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>" & _
            ""
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(320, 21)
            Me.cboCustomer.TabIndex = 2
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
            "tyle1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Con" & _
            "trol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}S" & _
            "tyle10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.L" & _
            "istBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScroll" & _
            "Group=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar" & _
            "><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capt" & _
            "ionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=" & _
            """Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style " & _
            "parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Hea" & _
            "ding"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headin" & _
            "g"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal""" & _
            " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
            """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Cap" & _
            "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
            "lits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>" & _
            ""
            '
            'txtQty
            '
            Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.Location = New System.Drawing.Point(0, 88)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(72, 22)
            Me.txtQty.TabIndex = 5
            Me.txtQty.Text = "1"
            Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.Transparent
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Black
            Me.lblQty.Location = New System.Drawing.Point(0, 72)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(72, 16)
            Me.lblQty.TabIndex = 135
            Me.lblQty.Text = "Quantity:"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnSave
            '
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.Navy
            Me.btnSave.Location = New System.Drawing.Point(80, 72)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(128, 40)
            Me.btnSave.TabIndex = 6
            Me.btnSave.Text = "Save"
            '
            'tdgModelPart
            '
            Me.tdgModelPart.AllowUpdate = False
            Me.tdgModelPart.AlternatingRows = True
            Me.tdgModelPart.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.tdgModelPart.FilterBar = True
            Me.tdgModelPart.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgModelPart.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgModelPart.Location = New System.Drawing.Point(8, 160)
            Me.tdgModelPart.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdgModelPart.Name = "tdgModelPart"
            Me.tdgModelPart.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgModelPart.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgModelPart.PreviewInfo.ZoomFactor = 75
            Me.tdgModelPart.Size = New System.Drawing.Size(656, 440)
            Me.tdgModelPart.TabIndex = 136
            Me.tdgModelPart.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:Lavender;}S" & _
            "tyle13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Recor" & _
            "dSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:AntiqueWhite;}Heading" & _
            "{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;Back" & _
            "Color:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor" & _
            ":Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDar" & _
            "k;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Styl" & _
            "e2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRo" & _
            "wStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17" & _
            """ FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefR" & _
            "ecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>436</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 652, 436</Clie" & _
            "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
            "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
            "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
            "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
            """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
            "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
            "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
            """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
            "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
            "cSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 652, 436</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "21"" /></Blob>"
            '
            'lblRecNum1
            '
            Me.lblRecNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum1.ForeColor = System.Drawing.Color.Green
            Me.lblRecNum1.Location = New System.Drawing.Point(8, 144)
            Me.lblRecNum1.Name = "lblRecNum1"
            Me.lblRecNum1.Size = New System.Drawing.Size(376, 16)
            Me.lblRecNum1.TabIndex = 137
            Me.lblRecNum1.Text = "Rec Count: 0"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopyAll.Location = New System.Drawing.Point(560, 136)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll.TabIndex = 138
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'btnRefresh
            '
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.Navy
            Me.btnRefresh.Location = New System.Drawing.Point(360, 136)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(96, 24)
            Me.btnRefresh.TabIndex = 139
            Me.btnRefresh.Text = "Refresh"
            '
            'btnRemove
            '
            Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemove.ForeColor = System.Drawing.Color.Crimson
            Me.btnRemove.Location = New System.Drawing.Point(464, 136)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(80, 24)
            Me.btnRemove.TabIndex = 140
            Me.btnRemove.Text = "Remove"
            '
            'frmBuildPackageMaterials
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.SystemColors.ControlLight
            Me.ClientSize = New System.Drawing.Size(672, 622)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemove, Me.btnRefresh, Me.btnCopyAll, Me.lblRecNum1, Me.tdgModelPart, Me.btnSave, Me.lblQty, Me.txtQty, Me.cboCustomer, Me.lblPart, Me.cboPart, Me.lblModel, Me.cboModel})
            Me.Name = "frmBuildPackageMaterials"
            Me.Text = "frmBuildPackageMaterials"
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPart, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgModelPart, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub frmBuildPackageMaterials_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.tdgModelPart.FetchRowStyles = True  'for fetchrowevent to fire

                If Me._iMenuCustID > 0 AndAlso Me._iMenuManufID > 0 Then
                    dt = Generic.GetCustomers(True, )
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomer.SelectedValue = Me._iMenuCustID
                    If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

                    PopulateModels()
                    PopulatePartDesc()
                    RefreshModelPartData()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateModels()
            Dim dt As DataTable
            Dim row As DataRow
            Try
                dt = Generic.GetModelsByManufID(True, Me._iMenuManufID)
                Me._dtModels = dt.Clone
                For Each row In dt.Rows
                    If row("model_ID") > 0 Then Me._dtModels.ImportRow(row)
                Next
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0
                'MessageBox.Show("dt=" & dt.Rows.Count & "    dtModels=" & Me._dtModels.Rows.Count)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulatePartDesc()
            Dim dt As DataTable
            Dim row As DataRow

            Try
                dt = Generic.GetAllPartNumberDesc(True)
                Me._dtParts = dt.Clone
                For Each row In dt.Rows
                    If row("PSPrice_ID") > 0 Then Me._dtParts.ImportRow(row)
                Next
                Misc.PopulateC1DropDownList(Me.cboPart, dt, "PSPrice_Desc", "PSPrice_ID")
                Me.cboPart.SelectedValue = 0
                ' MessageBox.Show("dt=" & dt.Rows.Count & "    dtParts=" & Me._dtParts.Rows.Count)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub txtQty_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.Enter
            Try
                txtQty.SelectAll()
            Catch ex As Exception
            End Try

        End Sub

        '***************************************************************************************
        Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
            Try
                Dim allowed As String = "0123456789"
                Dim curchar As Integer = Asc(e.KeyChar)

                If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try

        End Sub

        '***************************************************************************************
        Private Sub txtQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyUp
            Try
                If IsNumeric(Me.txtQty.Text) Then
                    Dim iNum As Integer = Me.txtQty.Text
                    If iNum > 0 Then
                        Me.txtQty.Text = iNum
                    Else
                        Me.txtQty.Text = 0
                    End If
                Else
                    Me.txtQty.Text = 0
                End If
            Catch ex As Exception
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim iQty As Integer = 0
            Dim strErrMsg As String = ""
            Dim strDTime As String

            Try
                If Not Me.cboModel.SelectedValue > 0 Then
                    MessageBox.Show("Please select a model.", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not Me.cboPart.SelectedValue > 0 Then
                    MessageBox.Show("Please select a part.", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not Me.txtQty.Text.Trim.Length > 0 Then
                    MessageBox.Show("Please enter a quantity.", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsNumeric(Me.txtQty.Text) Then
                    MessageBox.Show("Please enter a valid quantity.", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtQty.Focus()
                Else
                    iQty = Me.txtQty.Text
                    If Not iQty >= 0 Then
                        MessageBox.Show("Please enter a positive quantity.", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtQty.Focus() : Exit Sub
                    End If

                    'Ready to save
                    strDTime = Generic.MySQLServerDateTime(1)
                    Generic.SavePackageMaterialsData(Me._iMenuCustID, Me.cboModel.SelectedValue, Me.cboPart.SelectedValue, _
                                                     iQty, strDTime, Me._iUserID, strErrMsg)
                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        MessageBox.Show("Successfully saved!", "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cboPart.SelectedValue = 0
                        Me.txtQty.Text = 1
                        Me.RefreshModelPartData()
                    End If
                End If

            Catch ex As Exception
            End Try
        End Sub

        '***************************************************************************************
        Private Sub RefreshModelPartData()
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim row, rowNew As DataRow
            Dim arrModelIDs As New ArrayList()
            Dim filteredRows() As DataRow

            Try
                Me.tdgModelPart.DataSource = Nothing
                dt = Generic.GetModelPartData(Me._iMenuCustID)
                For Each row In dt.Rows
                    If Not arrModelIDs.Contains(row("Model_ID")) Then
                        arrModelIDs.Add(row("Model_ID"))
                    End If
                Next
                For Each row In Me._dtModels.Rows
                    If Not arrModelIDs.Contains(row("Model_ID")) Then
                        rowNew = dt.NewRow
                        rowNew("Model") = row("Model_desc")
                        rowNew("Model_ID") = row("Model_ID")
                        rowNew("Status") = 1
                        rowNew("Qty") = 0
                        rowNew("PSPrice_ID") = 0
                        rowNew("Status_Desc") = "Not Mapped"
                        dt.Rows.Add(rowNew)
                    End If
                Next
                If dt.Rows.Count > 0 Then
                    With Me.tdgModelPart
                        .DataSource = dt.DefaultView
                        For i = 0 To .Columns.Count - 1 'Me.tdgModelCriteria.Splits(0).Rows.Count - 1
                            'Me.tdgModelCriteria.Splits(0).Rows(i).AutoSize()
                            '.Splits(0).DisplayColumns("Active").FetchStyle = True 'for fetchcellevent to fire

                            .Splits(0).DisplayColumns(i).AutoSize()
                            '.Splits(0).DisplayColumns("Active").Width = 100
                            '.Splits(0).DisplayColumns("Active").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            '.Splits(0).DisplayColumns("Active").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            '.Splits(0).DisplayColumns("Key Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            '.Splits(0).DisplayColumns("Key Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            '.Splits(0).DisplayColumns("Active").HeadingStyle.ForeColor = Color.MediumBlue
                            ''.Splits(0).DisplayColumns("Active").Style.ForeColor = Color.MediumBlue
                            '.Splits(0).DisplayColumns("Model").HeadingStyle.ForeColor = Color.Black
                            '.Splits(0).DisplayColumns("Model").Style.ForeColor = Color.Black
                            '.Splits(0).DisplayColumns("Key Model").Style.ForeColor = Color.DimGray
                            '.Splits(0).DisplayColumns("User").Style.ForeColor = Color.DarkGray
                            '.Splits(0).DisplayColumns("Rec_Date").Style.ForeColor = Color.DarkGray
                            '.Splits(0).DisplayColumns("Product").Style.ForeColor = Color.DarkGray
                            'Dim fntFont As Font
                            'fntFont = New Font("Microsoft Sans Serif", .Splits(0).DisplayColumns.Item("Active").Style.Font.Size, FontStyle.Bold)
                            '.Splits(0).DisplayColumns.Item("Active").Style.Font = fntFont
                            '.Splits(0).DisplayColumns.Item("Active").HeadingStyle.Font = fntFont
                            .Splits(0).DisplayColumns("Qty").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                            .Splits(0).DisplayColumns("Qty").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                            .Splits(0).DisplayColumns("Std. Cost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                            .Splits(0).DisplayColumns("Std. Cost").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                            If i < 3 Then
                                .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.MediumBlue
                                .Splits(0).DisplayColumns(i).Style.ForeColor = Color.MediumBlue
                            Else
                                .Splits(0).DisplayColumns(i).Style.ForeColor = Color.DarkGray
                            End If
                            ' If i > 6 Then .Splits(0).DisplayColumns(i).Visible = False ' .Splits(0).DisplayColumns("Model_ID").Visible = False
                        Next
                    End With

                    filteredRows = dt.Select("Status=0")

                    Me.lblRecNum1.Text = "Rec Count: " & dt.Rows.Count & " (Mapped: " & filteredRows.Length & _
                                         ". Not Mapped: " & dt.Rows.Count - filteredRows.Length & ")"

                    If Me.tdgModelPart.SelectedRows.Count = 0 Then
                        Me.cboModel.SelectedValue = 0
                        Me.cboPart.SelectedValue = 0
                        Me.txtQty.Text = 1
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RefreshModelPartData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub tdgModelPart_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgModelPart.FetchRowStyle
            Dim iStatus As String
            Try
                iStatus = Me.tdgModelPart.Columns("Status").CellText(e.Row)
                Select Case iStatus
                    Case 1
                        e.CellStyle.ForeColor = Color.Red
                        'Case 2
                        ' e.CellStyle.ForeColor = Color.Black
                        'Case Else
                        '       e.CellStyle.BackColor = Color.Pink
                End Select

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgData1_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            RefreshModelPartData()
        End Sub

        '***************************************************************************************
        Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                'If sender.name = "btnCopyAll" Then
                Misc.CopyAllData(Me.tdgModelPart)
                'ElseIf sender.name = "btnCopySelectedRows" Then
                '    Misc.CopySelectedRowsData(Me.tdgModelCriteria)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub tdgModelPart_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdgModelPart.SelChange
            Dim row As DataRow
            Dim iRow As Integer
            Dim iModel_ID As Integer = 0
            Dim iPSPrice_ID As Integer = 0
            Try
                If Me.tdgModelPart.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgModelPart.SelectedRows
                        iModel_ID = CInt(Me.tdgModelPart.Columns("Model_ID").CellText(iRow))
                        iPSPrice_ID = CInt(Me.tdgModelPart.Columns("PSPrice_ID").CellText(iRow))
                        Me.cboModel.SelectedValue = iModel_ID
                        Me.cboPart.SelectedValue = iPSPrice_ID
                        Me.txtQty.Text = IIf(Me.tdgModelPart.Columns("Status").CellText(iRow) > 0, 1, CInt(Me.tdgModelPart.Columns("Qty").CellText(iRow)))
                        'MessageBox.Show("model_ID=" & iModel_ID)
                    Next

                    'Else
                    ' MessageBox.Show("Please select a row or rows in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                ' MessageBox.Show(ex.ToString(), "tdgModelPart_SelChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            Dim iRow, i As Integer
            Dim iPu_ID As Integer = 0
            Dim strMsg As String = ""

            Try

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Me.tdgModelPart.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgModelPart.SelectedRows
                        If Me.tdgModelPart.Columns("Status").CellValue(iRow) = 0 Then
                            'If strMsg.Trim.Length = 0 Then
                            strMsg = "Do you want to remove it?" & Environment.NewLine
                            strMsg &= Me.tdgModelPart.Columns("Model").CellValue(iRow) & " <---> " & Me.tdgModelPart.Columns("Part (Box)").CellValue(iRow)
                            ' Else
                            '    strMsg &= Environment.NewLine & Me.tdbgProductModelMap.Columns("NI_Prod_Desc").CellValue(iRow) & " - " & Me.tdbgProductModelMap.Columns("Model").CellValue(iRow)
                            'End If
                            Dim result As Integer = MessageBox.Show(strMsg, "Selection", MessageBoxButtons.YesNo)
                            If result = DialogResult.Yes Then
                                iPu_ID = Me.tdgModelPart.Columns("PU_ID").CellValue(iRow)
                                i = Generic.DeleteModelPartData(iPu_ID)
                                Me.cboModel.SelectedValue = 0
                                Me.cboPart.SelectedValue = 0
                            End If
                        End If
                        Exit For
                    Next
                    Me.RefreshModelPartData()
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
    End Class

End Namespace