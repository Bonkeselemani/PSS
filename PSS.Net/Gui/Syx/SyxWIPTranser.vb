Option Explicit On 

Namespace Gui
    Public Class SyxWIPTranser
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strMenuCustName As String = ""
        Private _objSyxWip As New PSS.Data.Buisness.SyxWip()
        Private _booLoadDataToCombo As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iMenuCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iMenuCustID
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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpManageSubWipLocation As System.Windows.Forms.TabPage
        Friend WithEvents tpWipTransfer As System.Windows.Forms.TabPage
        Friend WithEvents pnManageSubWipLoc As System.Windows.Forms.Panel
        Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
        Friend WithEvents txtWipSubLocDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtWipSubLoc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboWipLoc As C1.Win.C1List.C1Combo
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cboToLoc As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnTransfer As System.Windows.Forms.Button
        Friend WithEvents dgSubLoc As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents chkActive As System.Windows.Forms.CheckBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblCurrentLoc As System.Windows.Forms.Label
        Friend WithEvents lblCurrentSubLoc As System.Windows.Forms.Label
        Friend WithEvents cboToSubLoc As C1.Win.C1List.C1Combo
        Friend WithEvents btnRefreshWip As System.Windows.Forms.Button
        Friend WithEvents txtToDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents btnTransfToClear As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblNeedPart As System.Windows.Forms.Label
        Friend WithEvents lblNeedAccessory As System.Windows.Forms.Label
        Friend WithEvents lblNeedImage As System.Windows.Forms.Label
        Friend WithEvents lblToSubLocDesc As System.Windows.Forms.Label
        Friend WithEvents dgTotalWip As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents lblTriageResult As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxWIPTranser))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpManageSubWipLocation = New System.Windows.Forms.TabPage()
            Me.pnManageSubWipLoc = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnAddUpdate = New System.Windows.Forms.Button()
            Me.chkActive = New System.Windows.Forms.CheckBox()
            Me.txtWipSubLocDesc = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtWipSubLoc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboWipLoc = New C1.Win.C1List.C1Combo()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dgSubLoc = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpWipTransfer = New System.Windows.Forms.TabPage()
            Me.lblToSubLocDesc = New System.Windows.Forms.Label()
            Me.lblNeedImage = New System.Windows.Forms.Label()
            Me.lblNeedAccessory = New System.Windows.Forms.Label()
            Me.lblNeedPart = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.btnTransfToClear = New System.Windows.Forms.Button()
            Me.btnRefreshWip = New System.Windows.Forms.Button()
            Me.dgTotalWip = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCurrentSubLoc = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblCurrentLoc = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtToDeviceSN = New System.Windows.Forms.TextBox()
            Me.btnTransfer = New System.Windows.Forms.Button()
            Me.cboToSubLoc = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboToLoc = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.lblTriageResult = New System.Windows.Forms.Label()
            Me.TabControl1.SuspendLayout()
            Me.tpManageSubWipLocation.SuspendLayout()
            Me.pnManageSubWipLoc.SuspendLayout()
            CType(Me.cboWipLoc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgSubLoc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpWipTransfer.SuspendLayout()
            CType(Me.dgTotalWip, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboToSubLoc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboToLoc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpManageSubWipLocation, Me.tpWipTransfer})
            Me.TabControl1.Location = New System.Drawing.Point(16, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(800, 528)
            Me.TabControl1.TabIndex = 0
            '
            'tpManageSubWipLocation
            '
            Me.tpManageSubWipLocation.BackColor = System.Drawing.Color.SteelBlue
            Me.tpManageSubWipLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnManageSubWipLoc, Me.dgSubLoc})
            Me.tpManageSubWipLocation.Location = New System.Drawing.Point(4, 22)
            Me.tpManageSubWipLocation.Name = "tpManageSubWipLocation"
            Me.tpManageSubWipLocation.Size = New System.Drawing.Size(792, 502)
            Me.tpManageSubWipLocation.TabIndex = 0
            Me.tpManageSubWipLocation.Text = "Manage Sub Location"
            '
            'pnManageSubWipLoc
            '
            Me.pnManageSubWipLoc.BackColor = System.Drawing.Color.SteelBlue
            Me.pnManageSubWipLoc.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnAddUpdate, Me.chkActive, Me.txtWipSubLocDesc, Me.Label2, Me.txtWipSubLoc, Me.Label1, Me.cboWipLoc, Me.Label8})
            Me.pnManageSubWipLoc.Location = New System.Drawing.Point(24, 328)
            Me.pnManageSubWipLoc.Name = "pnManageSubWipLoc"
            Me.pnManageSubWipLoc.Size = New System.Drawing.Size(752, 136)
            Me.pnManageSubWipLoc.TabIndex = 1
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.Black
            Me.btnClear.Location = New System.Drawing.Point(664, 104)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 23)
            Me.btnClear.TabIndex = 6
            Me.btnClear.Text = "Clear"
            '
            'btnAddUpdate
            '
            Me.btnAddUpdate.BackColor = System.Drawing.Color.Green
            Me.btnAddUpdate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddUpdate.ForeColor = System.Drawing.Color.White
            Me.btnAddUpdate.Location = New System.Drawing.Point(536, 104)
            Me.btnAddUpdate.Name = "btnAddUpdate"
            Me.btnAddUpdate.Size = New System.Drawing.Size(96, 23)
            Me.btnAddUpdate.TabIndex = 5
            Me.btnAddUpdate.Text = "Add/Update"
            '
            'chkActive
            '
            Me.chkActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkActive.ForeColor = System.Drawing.Color.White
            Me.chkActive.Location = New System.Drawing.Point(16, 104)
            Me.chkActive.Name = "chkActive"
            Me.chkActive.TabIndex = 4
            Me.chkActive.Text = "Active ?"
            '
            'txtWipSubLocDesc
            '
            Me.txtWipSubLocDesc.Location = New System.Drawing.Point(8, 72)
            Me.txtWipSubLocDesc.MaxLength = 85
            Me.txtWipSubLocDesc.Name = "txtWipSubLocDesc"
            Me.txtWipSubLocDesc.Size = New System.Drawing.Size(719, 20)
            Me.txtWipSubLocDesc.TabIndex = 3
            Me.txtWipSubLocDesc.Text = ""
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(220, 16)
            Me.Label2.TabIndex = 184
            Me.Label2.Text = "Wip Sub Location Descriptin:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWipSubLoc
            '
            Me.txtWipSubLoc.Location = New System.Drawing.Point(392, 24)
            Me.txtWipSubLoc.MaxLength = 35
            Me.txtWipSubLoc.Name = "txtWipSubLoc"
            Me.txtWipSubLoc.Size = New System.Drawing.Size(336, 20)
            Me.txtWipSubLoc.TabIndex = 2
            Me.txtWipSubLoc.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(392, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(220, 16)
            Me.Label1.TabIndex = 182
            Me.Label1.Text = "Wip Sub Location :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboWipLoc
            '
            Me.cboWipLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWipLoc.Caption = ""
            Me.cboWipLoc.CaptionHeight = 17
            Me.cboWipLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWipLoc.ColumnCaptionHeight = 17
            Me.cboWipLoc.ColumnFooterHeight = 17
            Me.cboWipLoc.ContentHeight = 15
            Me.cboWipLoc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWipLoc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWipLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWipLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWipLoc.EditorHeight = 15
            Me.cboWipLoc.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboWipLoc.ItemHeight = 15
            Me.cboWipLoc.Location = New System.Drawing.Point(8, 24)
            Me.cboWipLoc.MatchEntryTimeout = CType(2000, Long)
            Me.cboWipLoc.MaxDropDownItems = CType(5, Short)
            Me.cboWipLoc.MaxLength = 32767
            Me.cboWipLoc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWipLoc.Name = "cboWipLoc"
            Me.cboWipLoc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWipLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWipLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWipLoc.Size = New System.Drawing.Size(280, 21)
            Me.cboWipLoc.TabIndex = 1
            Me.cboWipLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(8, 8)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(96, 16)
            Me.Label8.TabIndex = 180
            Me.Label8.Text = "Wip Location :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dgSubLoc
            '
            Me.dgSubLoc.AllowUpdate = False
            Me.dgSubLoc.AlternatingRows = True
            Me.dgSubLoc.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgSubLoc.FilterBar = True
            Me.dgSubLoc.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgSubLoc.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgSubLoc.Location = New System.Drawing.Point(24, 8)
            Me.dgSubLoc.Name = "dgSubLoc"
            Me.dgSubLoc.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgSubLoc.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgSubLoc.PreviewInfo.ZoomFactor = 75
            Me.dgSubLoc.Size = New System.Drawing.Size(728, 320)
            Me.dgSubLoc.TabIndex = 2
            Me.dgSubLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "16</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 724, 316<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 724, 316</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'tpWipTransfer
            '
            Me.tpWipTransfer.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpWipTransfer.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTriageResult, Me.Label12, Me.lblToSubLocDesc, Me.lblNeedImage, Me.lblNeedAccessory, Me.lblNeedPart, Me.Label11, Me.Label9, Me.Label7, Me.btnTransfToClear, Me.btnRefreshWip, Me.dgTotalWip, Me.lblCurrentSubLoc, Me.Label10, Me.lblCurrentLoc, Me.Label6, Me.txtToDeviceSN, Me.btnTransfer, Me.cboToSubLoc, Me.Label5, Me.Label4, Me.cboToLoc, Me.Label3})
            Me.tpWipTransfer.Location = New System.Drawing.Point(4, 22)
            Me.tpWipTransfer.Name = "tpWipTransfer"
            Me.tpWipTransfer.Size = New System.Drawing.Size(792, 502)
            Me.tpWipTransfer.TabIndex = 1
            Me.tpWipTransfer.Text = "Transfer"
            '
            'lblToSubLocDesc
            '
            Me.lblToSubLocDesc.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblToSubLocDesc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblToSubLocDesc.ForeColor = System.Drawing.Color.Black
            Me.lblToSubLocDesc.Location = New System.Drawing.Point(16, 112)
            Me.lblToSubLocDesc.Name = "lblToSubLocDesc"
            Me.lblToSubLocDesc.Size = New System.Drawing.Size(280, 56)
            Me.lblToSubLocDesc.TabIndex = 198
            Me.lblToSubLocDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblNeedImage
            '
            Me.lblNeedImage.BackColor = System.Drawing.Color.White
            Me.lblNeedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblNeedImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNeedImage.ForeColor = System.Drawing.Color.Black
            Me.lblNeedImage.Location = New System.Drawing.Point(264, 312)
            Me.lblNeedImage.Name = "lblNeedImage"
            Me.lblNeedImage.Size = New System.Drawing.Size(32, 20)
            Me.lblNeedImage.TabIndex = 197
            Me.lblNeedImage.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblNeedAccessory
            '
            Me.lblNeedAccessory.BackColor = System.Drawing.Color.White
            Me.lblNeedAccessory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblNeedAccessory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNeedAccessory.ForeColor = System.Drawing.Color.Black
            Me.lblNeedAccessory.Location = New System.Drawing.Point(120, 344)
            Me.lblNeedAccessory.Name = "lblNeedAccessory"
            Me.lblNeedAccessory.Size = New System.Drawing.Size(32, 20)
            Me.lblNeedAccessory.TabIndex = 196
            Me.lblNeedAccessory.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblNeedPart
            '
            Me.lblNeedPart.BackColor = System.Drawing.Color.White
            Me.lblNeedPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblNeedPart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNeedPart.ForeColor = System.Drawing.Color.Black
            Me.lblNeedPart.Location = New System.Drawing.Point(120, 312)
            Me.lblNeedPart.Name = "lblNeedPart"
            Me.lblNeedPart.Size = New System.Drawing.Size(32, 20)
            Me.lblNeedPart.TabIndex = 195
            Me.lblNeedPart.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(184, 315)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(88, 16)
            Me.Label11.TabIndex = 194
            Me.Label11.Text = "Need Image :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(16, 344)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(112, 16)
            Me.Label9.TabIndex = 193
            Me.Label9.Text = "Need Accessory :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(16, 312)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(104, 16)
            Me.Label7.TabIndex = 192
            Me.Label7.Text = "Need Part(s) :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnTransfToClear
            '
            Me.btnTransfToClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnTransfToClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnTransfToClear.ForeColor = System.Drawing.Color.Black
            Me.btnTransfToClear.Location = New System.Drawing.Point(208, 416)
            Me.btnTransfToClear.Name = "btnTransfToClear"
            Me.btnTransfToClear.Size = New System.Drawing.Size(88, 23)
            Me.btnTransfToClear.TabIndex = 5
            Me.btnTransfToClear.Text = "Clear"
            '
            'btnRefreshWip
            '
            Me.btnRefreshWip.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshWip.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshWip.ForeColor = System.Drawing.Color.Black
            Me.btnRefreshWip.Location = New System.Drawing.Point(16, 456)
            Me.btnRefreshWip.Name = "btnRefreshWip"
            Me.btnRefreshWip.Size = New System.Drawing.Size(280, 23)
            Me.btnRefreshWip.TabIndex = 6
            Me.btnRefreshWip.Text = "Refresh Data Grid"
            '
            'dgTotalWip
            '
            Me.dgTotalWip.AllowUpdate = False
            Me.dgTotalWip.AlternatingRows = True
            Me.dgTotalWip.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgTotalWip.FilterBar = True
            Me.dgTotalWip.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgTotalWip.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dgTotalWip.Location = New System.Drawing.Point(328, 32)
            Me.dgTotalWip.Name = "dgTotalWip"
            Me.dgTotalWip.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgTotalWip.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgTotalWip.PreviewInfo.ZoomFactor = 75
            Me.dgTotalWip.Size = New System.Drawing.Size(448, 448)
            Me.dgTotalWip.TabIndex = 191
            Me.dgTotalWip.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "44</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 444, 444<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 444, 444</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'lblCurrentSubLoc
            '
            Me.lblCurrentSubLoc.BackColor = System.Drawing.Color.White
            Me.lblCurrentSubLoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCurrentSubLoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentSubLoc.ForeColor = System.Drawing.Color.Black
            Me.lblCurrentSubLoc.Location = New System.Drawing.Point(16, 280)
            Me.lblCurrentSubLoc.Name = "lblCurrentSubLoc"
            Me.lblCurrentSubLoc.Size = New System.Drawing.Size(280, 20)
            Me.lblCurrentSubLoc.TabIndex = 190
            Me.lblCurrentSubLoc.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(16, 264)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(136, 16)
            Me.Label10.TabIndex = 189
            Me.Label10.Text = "Current Sub Location :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblCurrentLoc
            '
            Me.lblCurrentLoc.BackColor = System.Drawing.Color.White
            Me.lblCurrentLoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCurrentLoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentLoc.ForeColor = System.Drawing.Color.Black
            Me.lblCurrentLoc.Location = New System.Drawing.Point(16, 240)
            Me.lblCurrentLoc.Name = "lblCurrentLoc"
            Me.lblCurrentLoc.Size = New System.Drawing.Size(280, 20)
            Me.lblCurrentLoc.TabIndex = 188
            Me.lblCurrentLoc.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(16, 176)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(112, 16)
            Me.Label6.TabIndex = 187
            Me.Label6.Text = "S/N :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtToDeviceSN
            '
            Me.txtToDeviceSN.Location = New System.Drawing.Point(16, 192)
            Me.txtToDeviceSN.MaxLength = 35
            Me.txtToDeviceSN.Name = "txtToDeviceSN"
            Me.txtToDeviceSN.Size = New System.Drawing.Size(280, 20)
            Me.txtToDeviceSN.TabIndex = 3
            Me.txtToDeviceSN.Text = ""
            '
            'btnTransfer
            '
            Me.btnTransfer.BackColor = System.Drawing.Color.Green
            Me.btnTransfer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnTransfer.ForeColor = System.Drawing.Color.White
            Me.btnTransfer.Location = New System.Drawing.Point(16, 416)
            Me.btnTransfer.Name = "btnTransfer"
            Me.btnTransfer.Size = New System.Drawing.Size(104, 23)
            Me.btnTransfer.TabIndex = 4
            Me.btnTransfer.Text = "Transfer"
            '
            'cboToSubLoc
            '
            Me.cboToSubLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboToSubLoc.Caption = ""
            Me.cboToSubLoc.CaptionHeight = 17
            Me.cboToSubLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboToSubLoc.ColumnCaptionHeight = 17
            Me.cboToSubLoc.ColumnFooterHeight = 17
            Me.cboToSubLoc.ContentHeight = 15
            Me.cboToSubLoc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboToSubLoc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboToSubLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboToSubLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboToSubLoc.EditorHeight = 15
            Me.cboToSubLoc.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboToSubLoc.ItemHeight = 15
            Me.cboToSubLoc.Location = New System.Drawing.Point(16, 80)
            Me.cboToSubLoc.MatchEntryTimeout = CType(2000, Long)
            Me.cboToSubLoc.MaxDropDownItems = CType(5, Short)
            Me.cboToSubLoc.MaxLength = 32767
            Me.cboToSubLoc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboToSubLoc.Name = "cboToSubLoc"
            Me.cboToSubLoc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboToSubLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboToSubLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboToSubLoc.Size = New System.Drawing.Size(280, 21)
            Me.cboToSubLoc.TabIndex = 2
            Me.cboToSubLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(16, 64)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(144, 16)
            Me.Label5.TabIndex = 185
            Me.Label5.Text = "To Sub Location :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(16, 224)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 183
            Me.Label4.Text = "Current Location :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboToLoc
            '
            Me.cboToLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboToLoc.Caption = ""
            Me.cboToLoc.CaptionHeight = 17
            Me.cboToLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboToLoc.ColumnCaptionHeight = 17
            Me.cboToLoc.ColumnFooterHeight = 17
            Me.cboToLoc.ContentHeight = 15
            Me.cboToLoc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboToLoc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboToLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboToLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboToLoc.EditorHeight = 15
            Me.cboToLoc.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboToLoc.ItemHeight = 15
            Me.cboToLoc.Location = New System.Drawing.Point(16, 32)
            Me.cboToLoc.MatchEntryTimeout = CType(2000, Long)
            Me.cboToLoc.MaxDropDownItems = CType(5, Short)
            Me.cboToLoc.MaxLength = 32767
            Me.cboToLoc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboToLoc.Name = "cboToLoc"
            Me.cboToLoc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboToLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboToLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboToLoc.Size = New System.Drawing.Size(280, 21)
            Me.cboToLoc.TabIndex = 1
            Me.cboToLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(16, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 182
            Me.Label3.Text = "To Location :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(176, 344)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(88, 16)
            Me.Label12.TabIndex = 199
            Me.Label12.Text = "Triage Result :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblTriageResult
            '
            Me.lblTriageResult.BackColor = System.Drawing.Color.White
            Me.lblTriageResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTriageResult.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTriageResult.ForeColor = System.Drawing.Color.Black
            Me.lblTriageResult.Location = New System.Drawing.Point(264, 344)
            Me.lblTriageResult.Name = "lblTriageResult"
            Me.lblTriageResult.Size = New System.Drawing.Size(32, 20)
            Me.lblTriageResult.TabIndex = 200
            Me.lblTriageResult.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'SyxWIPTranser
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(832, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "SyxWIPTranser"
            Me.Text = "WIP Transer"
            Me.TabControl1.ResumeLayout(False)
            Me.tpManageSubWipLocation.ResumeLayout(False)
            Me.pnManageSubWipLoc.ResumeLayout(False)
            CType(Me.cboWipLoc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgSubLoc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpWipTransfer.ResumeLayout(False)
            CType(Me.dgTotalWip, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboToSubLoc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboToLoc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Manage Sub Location"
        '*************************************************************************************************************************
        Private Sub SyxWIPTranser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If _iMenuCustID > 0 Then _strMenuCustName = _objSyxWip.GetCustName(_iMenuCustID)

                LoadWIPMainAndSubLocMap()
                LoadMainLocation()
                LoadTransfToWipLocation()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SyxWIPTranser_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Public Sub LoadWIPMainAndSubLocMap()
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                dt = Me._objSyxWip.GetWipSubLocationMap(Me._iMenuCustID)

                'If Me._iMenuCustID > 0 Then
                '    'WIL_ID, WIL_SDesc, WIL_LDesc, WIL_Active, 2485Active, Workstation

                '    For i = 0 To dt.Columns.Count - 1
                '        If dt.Columns(i).Caption.Trim.ToLower = Me._iMenuCustID.ToString & "active" Then
                '            dt.Columns.Add(New DataColumn("Visible to " & Me._strMenuCustName & "?", System.Type.GetType("System.String")))
                '            For Each R1 In dt.Rows
                '                R1.BeginEdit()
                '                If R1(Me._iMenuCustID.ToString & "active") = 1 Then R1("Visible to " & Me._strMenuCustName & "?") = "Yes" Else R1("Visible to " & Me._strMenuCustName & "?") = "No"
                '                R1.EndEdit()
                '            Next R1
                '            dt.AcceptChanges()
                '            Exit For
                '        End If
                '    Next i
                'End If

                With Me.dgSubLoc
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For i = 0 To dt.Columns.Count - 1
                        If dt.Columns(i).Caption.Trim.ToLower.StartsWith("wil_") OrElse dt.Columns(i).Caption.Trim.ToLower = "cust_id" OrElse dt.Columns(i).Caption.Trim.ToLower = "workstation" Then
                            .Splits(0).DisplayColumns(i).Visible = False
                        Else
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        End If
                    Next i

                    .Splits(0).DisplayColumns("Location Description").Width = 280
                    .Splits(0).DisplayColumns("Location").Width = 150
                    .Splits(0).DisplayColumns("Wip Sub Location").Width = 120
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadSubLocation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************************
        Public Function LoadMainLocation()
            Dim dt As DataTable

            Try
                dt = Me._objSyxWip.GetWIPLocation(Me._iMenuCustID)
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                'WRB_ID, WorkFlowStation
                Misc.PopulateC1DropDownList(Me.cboWipLoc, dt, "WorkFlowStation", "WRB_ID")
                Me.cboToLoc.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadMainLocation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************************
        Private Sub dgSubLoc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSubLoc.DoubleClick
            Try
                With Me.dgSubLoc
                    If .Columns.Count > 0 AndAlso .RowCount > 0 Then
                        If Convert.ToInt32(.Columns("WIL_ID").CellValue(.Row)) Then
                            If Me.cboWipLoc.DataSource.Table.Select("WorkFlowStation = '" & .Columns("Location").CellValue(.Row) & "'").Length > 0 Then
                                Me.cboWipLoc.SelectedValue = Me.cboWipLoc.DataSource.Table.Select("WorkFlowStation = '" & .Columns("Location").CellValue(.Row) & "'")(0)("WRB_ID")
                            End If
                            Me.txtWipSubLoc.Text = .Columns("Wip Sub Location").CellValue(.Row)
                            Me.txtWipSubLocDesc.Text = .Columns("Location Description").CellValue(.Row)
                            If .Columns("WIL_Active").CellValue(.Row).ToString.Trim = "1" Then Me.chkActive.Checked = True Else Me.chkActive.Checked = False
                        End If
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dgSubLoc_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.Enabled = True
                Me.cboWipLoc.SelectedValue = 0
                Me.txtWipSubLoc.Text = ""
                Me.txtWipSubLocDesc.Text = ""
                Me.chkActive.Checked = True
                Me.cboWipLoc.SelectAll() : Me.cboWipLoc.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
            Dim i, iActive, iCntDevInWip As Integer
            Dim dt As DataTable

            Try
                'Validate user input
                If Me.cboWipLoc.SelectedValue = 0 Then
                    MessageBox.Show("Please select wip location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboWipLoc.SelectAll() : Me.cboWipLoc.Focus() : Exit Sub
                ElseIf Me.txtWipSubLoc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter wip sub location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtWipSubLoc.SelectAll() : Me.txtWipSubLoc.Focus() : Exit Sub
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If Me.chkActive.Checked Then iActive = 1 Else iActive = 0

                dt = Me._objSyxWip.GetWipMainAndSubLocMap(Me._iMenuCustID, Me.txtWipSubLoc.Text.Trim)
                If dt.Rows.Count > 0 Then
                    iCntDevInWip = Me._objSyxWip.GetTotalDevCntInWip(Me._iMenuCustID, Me.cboWipLoc.Text.Trim, Me.txtWipSubLoc.Text.Trim)
                    If iCntDevInWip > 0 AndAlso (Me.cboWipLoc.Text.Trim.ToLower <> dt.Rows(0)("Workstation").ToString.Trim.ToLower OrElse Me.txtWipSubLoc.Text.Trim.ToLower <> dt.Rows(0)("WIL_SDesc").ToString.Trim.ToLower) Then
                        MessageBox.Show("Please move " & iCntDevInWip & " device(s) under location " & dt.Rows(0)("Workstation").ToString.Trim & "-" & Me.txtWipSubLoc.Text & " before perform update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = Me._objSyxWip.UpdateWipMainAndSubLocMap(dt.Rows(0)("WIL_ID"), Me._iMenuCustID, Me.cboWipLoc.Text.Trim, Me.txtWipSubLoc.Text.Trim.Replace("'", ""), Me.txtWipSubLocDesc.Text.Trim.Replace("'", ""), iActive)
                    End If
                Else
                    i = Me._objSyxWip.MapWipMainAndSubLoc(Me._iMenuCustID, Me.cboWipLoc.Text.Trim, Me.txtWipSubLoc.Text.Trim.Replace("'", ""), Me.txtWipSubLocDesc.Text.Trim.Replace("'", ""), iActive)
                End If

                If i > 0 Then
                    Me.LoadWIPMainAndSubLocMap()
                    btnClear_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************************
#End Region

        '*************************************************************************************************************************
        Public Function LoadTransfToWipLocation()
            Dim dt As DataTable

            Try
                _booLoadDataToCombo = True
                dt = Me._objSyxWip.GetTranferToWIPLocation(Me._iMenuCustID)
                dt.LoadDataRow(New Object() {"0", "--SELECT--", "", "", "0"}, False)
                'wfp_id, wfp_ScreenName, wfp_FrStation, wfp_ToStation, HasSubLoc
                Misc.PopulateC1DropDownList(Me.cboToLoc, dt, "wfp_ScreenName", "wfp_id")
                Me.cboToLoc.SelectedValue = 0
                _booLoadDataToCombo = False

                If PSS.Core.Global.ApplicationUser.GetPermission("SyxManageWipSubLoc") > 0 Then Me.pnManageSubWipLoc.Visible = True Else Me.pnManageSubWipLoc.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadMainLocation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt) : _booLoadDataToCombo = False
            End Try
        End Function

        '*************************************************************************************************************************
        Private Sub cboToLoc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboToLoc.SelectedValueChanged
            Try
                If _booLoadDataToCombo = True Then Exit Sub
                If Me.cboToLoc.SelectedValue > 0 AndAlso Me.cboToLoc.DataSource.Table.select("wfp_id = " & Me.cboToLoc.SelectedValue & " AND HasSubLoc = 1").length > 0 Then
                    Me.LoadTransferToWipSubLocation(Me.cboToLoc.DataSource.Table.select("wfp_id = " & Me.cboToLoc.SelectedValue)(0)("wfp_ToStation"))
                Else
                    Me.cboToSubLoc.DataSource = Nothing
                    Me.cboToSubLoc.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboToLoc_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Public Function LoadTransferToWipSubLocation(ByVal strMainLoc As String)
            Dim dt As DataTable

            Try
                dt = Me._objSyxWip.GetTranferToWIPSubLocation(Me._iMenuCustID, strMainLoc)
                dt.LoadDataRow(New Object() {"0", "--SELECT--", ""}, False)
                'WIL_ID, WIL_SDesc, WIL_LDesc
                Misc.PopulateC1DropDownList(Me.cboToSubLoc, dt, "WIL_SDesc", "WIL_ID")
                Me.cboToSubLoc.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadTransferToWipSubLocation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************************
        Private Sub txtToDeviceSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtToDeviceSN.KeyUp
            Dim dt As DataTable
            Dim iDeviceID As Integer

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtToDeviceSN.Text.Trim.Length > 0 Then
                    dt = Me._objSyxWip.GetDeviceInWipWithWorkstationLocation(Me._iMenuCustID, Me.txtToDeviceSN.Text.Trim)
                    ' dtPretest = Me._objSyxWip.GetPretestData(Me._iMenuCustID, Me.txtToDeviceSN.Text.Trim)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate record. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso dt.Rows(0)("Pallett_ID") > 0 Then
                        MessageBox.Show("Device have already assigned to a ship pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        'Device_ID, Workstation, WIL_ID, tdevice.Pallett_ID, WIL_SDesc, WIL_LDesc
                        Me.lblCurrentLoc.Text = dt.Rows(0)("Workstation")
                        Me.lblCurrentSubLoc.Text = dt.Rows(0)("WIL_SDesc")
                        iDeviceID = dt.Rows(0)("Device_ID")

                        '*************************************************
                        dt = Me._objSyxWip.GetSelectedAWAP(iDeviceID)

                        Me.lblNeedAccessory.Text = "N" : Me.lblNeedImage.Text = "N" : Me.lblNeedPart.Text = "N" : Me.lblTriageResult.Text = ""
                        If dt.Rows.Count > 0 Then
                            'BillCode_ID, Billcode_Desc, Part_Number, BillType_ID, sum(Trans_Amount) as Trans_Amount
                            If dt.Select("BillType_ID = 2 AND Billcode_Desc <> 'image' AND Consumed = 0").Length > 0 Then Me.lblNeedPart.Text = "Y" Else Me.lblNeedPart.Text = "N"
                            If dt.Select("BillType_ID = 3 AND Billcode_Desc <> 'image' AND Consumed = 0").Length > 0 Then Me.lblNeedAccessory.Text = "Y" Else Me.lblNeedAccessory.Text = "N"
                            If dt.Select("Billcode_Desc = 'image' AND Consumed = 0").Length > 0 Then Me.lblNeedImage.Text = "Y" Else Me.lblNeedImage.Text = "N"
                        End If

                        Dim strPretestResult As String = Me._objSyxWip.GetPretestResult(iDeviceID)
                        If strPretestResult.Trim.Length > 0 Then Me.lblTriageResult.Text = Microsoft.VisualBasic.Left(strPretestResult, 1)
                        '*************************************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadTransferToWipSubLocation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************************
        Private Sub btnTransfToClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfToClear.Click
            Try
                If Not IsNothing(Me.cboToSubLoc.DataSource) Then Me.cboToSubLoc.SelectedValue = 0
                Me.lblCurrentLoc.Text = ""
                Me.lblCurrentSubLoc.Text = ""
                Me.txtToDeviceSN.Text = ""
                Me.lblNeedAccessory.Text = "" : Me.lblNeedImage.Text = "" : Me.lblNeedPart.Text = ""
                If Not IsNothing(sender) Then
                    Me.cboToSubLoc.SelectAll() : Me.cboToSubLoc.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnTransfToClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
            Dim dt As DataTable
            Dim strAcceptLocs, strToLoc As String
            Dim booAllowToMove, booSetLeftImageHoldDate As Boolean
            Dim i, iWIL_ID As Integer

            Try
                booAllowToMove = False : booSetLeftImageHoldDate = False

                If Me.cboToLoc.SelectedValue = 0 Then
                    MessageBox.Show("Please select transfer to location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboToLoc.DataSource.Table.Select("wfp_id = " & Me.cboToLoc.SelectedValue)(0)("HasSubLoc").ToString = "1" AndAlso (IsNothing(Me.cboToSubLoc.DataSource) OrElse Me.cboToSubLoc.SelectedValue = 0) Then
                    MessageBox.Show("Please select transfer to sub location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dt = Me._objSyxWip.GetDeviceInWipWithWorkstationLocation(Me._iMenuCustID, Me.txtToDeviceSN.Text.Trim)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate record. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso dt.Rows(0)("Pallett_ID") > 0 Then
                        MessageBox.Show("Device have already assigned to a ship pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        strToLoc = Me.cboToLoc.DataSource.Table.Select("wfp_id = " & Me.cboToLoc.SelectedValue)(0)("wfp_ToStation").ToString
                        strAcceptLocs = Me.cboToLoc.DataSource.Table.Select("wfp_id = " & Me.cboToLoc.SelectedValue)(0)("wfp_FrStation").ToString.Trim

                        booAllowToMove = ValidateAcceptedLoc(strAcceptLocs, dt.Rows(0)("Workstation").ToString.Trim.ToLower)

                        If booAllowToMove = False Then
                            MessageBox.Show("Not allow unit from location """ & dt.Rows(0)("Workstation") & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf strToLoc.Trim.Length = 0 Then
                            MessageBox.Show("Next location is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            '***********************************
                            'Add model to Image Library
                            '***********************************
                            If strToLoc.Trim.ToUpper = "WAITING FQA" AndAlso dt.Rows(0)("Workstation").ToString.Trim.ToUpper = "IMAGE HOLD" Then
                                Me._objSyxWip.AddRemoveModelToImageLibrary(dt.Rows(0)("Model_Desc"), PSS.Core.ApplicationUser.IDuser, 1)
                                booSetLeftImageHoldDate = True
                            End If
                            '***********************************

                            If Me.cboToLoc.DataSource.Table.Select("wfp_id = " & Me.cboToLoc.SelectedValue)(0)("HasSubLoc").ToString = "1" Then iWIL_ID = Me.cboToSubLoc.SelectedValue
                            i = 0 : Dim strStatus As String = "" 'strToLoc
                            i = Me._objSyxWip.SetWipNextLoc(dt.Rows(0)("Device_ID"), strToLoc, iWIL_ID, strStatus, booSetLeftImageHoldDate, Core.ApplicationUser.IDuser, "Syx Wip Transfer", Me.Name)

                            If i > 0 Then
                                Me.btnTransfToClear_Click(Nothing, Nothing) : Me.cboToSubLoc.SelectAll() : Me.cboToSubLoc.Focus()
                            End If
                            '***********************************
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnTransfer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Private Function ValidateAcceptedLoc(ByVal strAcceptLocs As String, ByVal strCurrentLoc As String) As Boolean
            Dim i As Integer = 0
            Dim booAllowToMove As Boolean = False

            Try
                If strAcceptLocs.Length > 0 Then
                    Dim strArrAcceptLocs() As String = strAcceptLocs.Split("|")
                    For i = 0 To strArrAcceptLocs.Length - 1
                        If strArrAcceptLocs(i).Trim.Length > 0 AndAlso strArrAcceptLocs(i).Trim.ToLower = strCurrentLoc.Trim.ToLower Then
                            booAllowToMove = True : Exit For
                        End If
                    Next i
                Else
                    booAllowToMove = True
                End If

                Return booAllowToMove
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Private Sub btnRefreshWip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshWip.Click
            Try
                Me.LoadWip()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshWip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************************************************************************
        Private Sub LoadWip()
            Dim dt As DataTable
            Dim objWipRpt As New PSS.Data.Buisness.SyxReports()

            Try
                dt = objWipRpt.GetTotalWip(Me._iMenuCustID, , )
                With Me.dgTotalWip
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("PSSI SN").Frozen = True
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                objWipRpt = Nothing
            End Try
        End Sub

        '*************************************************************************************************************************


    End Class
End Namespace