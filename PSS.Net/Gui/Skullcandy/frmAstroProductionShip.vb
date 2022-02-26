Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAstroProductionShip
        Inherits System.Windows.Forms.Form
        Private Const _iPalletShipType As Integer = 0

        Private _iMenuCustID As Integer
        Private _iMenuLocID As Integer
        Private _objSkullcandyRec As SkullcandyRec
        Private _booLoadData As Boolean = False
        Private _dsBundlesModels As New DataSet()
        Private _iShipBoxBundleLimit As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCustID
            _iMenuLocID = iLocID
            'Me._objSkullcandy = New Skullcandy()
            Me._objSkullcandyRec = New SkullcandyRec()
            Me.lblTitle.Text = strScreenName
            Me._iShipBoxBundleLimit = Skullcandy.ASTRO_ShipBoxBundleLimit
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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnDeletePallet As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlShipType As System.Windows.Forms.Panel
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents btnCreatePalletID As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents txtOverPackName As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveAllBoxes As System.Windows.Forms.Button
        Friend WithEvents btnRemoveBox As System.Windows.Forms.Button
        Friend WithEvents lstOverPackNames As System.Windows.Forms.ListBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblDevCnt As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblPalletName As System.Windows.Forms.Label
        Friend WithEvents lblBoxCount As System.Windows.Forms.Label
        Friend WithEvents cboBundle As C1.Win.C1List.C1Combo
        Friend WithEvents btnReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents btnRefreshList As System.Windows.Forms.Button
        Friend WithEvents btnReplacePalletWithOverPackAndDeletePallet As System.Windows.Forms.Button
        Friend WithEvents btnClosePallet As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAstroProductionShip))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnReplacePalletWithOverPackAndDeletePallet = New System.Windows.Forms.Button()
            Me.btnRefreshList = New System.Windows.Forms.Button()
            Me.btnDeletePallet = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReprintPalletLabel = New System.Windows.Forms.Button()
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.cboBundle = New C1.Win.C1List.C1Combo()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.btnCreatePalletID = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.lblDevCnt = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtOverPackName = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnClosePallet = New System.Windows.Forms.Button()
            Me.btnRemoveAllBoxes = New System.Windows.Forms.Button()
            Me.btnRemoveBox = New System.Windows.Forms.Button()
            Me.lstOverPackNames = New System.Windows.Forms.ListBox()
            Me.lblBoxCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblPalletName = New System.Windows.Forms.Label()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboBundle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelPallet.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(296, 24)
            Me.lblTitle.TabIndex = 95
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReplacePalletWithOverPackAndDeletePallet, Me.btnRefreshList, Me.btnDeletePallet, Me.dbgPallets, Me.btnReprintPalletLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(16, 136)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(421, 344)
            Me.PanelPalletList.TabIndex = 121
            '
            'btnReplacePalletWithOverPackAndDeletePallet
            '
            Me.btnReplacePalletWithOverPackAndDeletePallet.BackColor = System.Drawing.Color.DarkOrange
            Me.btnReplacePalletWithOverPackAndDeletePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReplacePalletWithOverPackAndDeletePallet.ForeColor = System.Drawing.Color.Black
            Me.btnReplacePalletWithOverPackAndDeletePallet.Location = New System.Drawing.Point(240, 288)
            Me.btnReplacePalletWithOverPackAndDeletePallet.Name = "btnReplacePalletWithOverPackAndDeletePallet"
            Me.btnReplacePalletWithOverPackAndDeletePallet.Size = New System.Drawing.Size(168, 40)
            Me.btnReplacePalletWithOverPackAndDeletePallet.TabIndex = 5
            Me.btnReplacePalletWithOverPackAndDeletePallet.Text = "Replace Pallet With Over Pack And Delete Pallet"
            '
            'btnRefreshList
            '
            Me.btnRefreshList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRefreshList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshList.ForeColor = System.Drawing.Color.Black
            Me.btnRefreshList.Location = New System.Drawing.Point(8, 240)
            Me.btnRefreshList.Name = "btnRefreshList"
            Me.btnRefreshList.Size = New System.Drawing.Size(168, 31)
            Me.btnRefreshList.TabIndex = 4
            Me.btnRefreshList.Text = "REFRESH LIST"
            '
            'btnDeletePallet
            '
            Me.btnDeletePallet.BackColor = System.Drawing.Color.Red
            Me.btnDeletePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeletePallet.ForeColor = System.Drawing.Color.White
            Me.btnDeletePallet.Location = New System.Drawing.Point(240, 240)
            Me.btnDeletePallet.Name = "btnDeletePallet"
            Me.btnDeletePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeletePallet.Size = New System.Drawing.Size(168, 32)
            Me.btnDeletePallet.TabIndex = 2
            Me.btnDeletePallet.Text = "DELETE EMPTY PALLET"
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowFilter = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowSort = False
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.AlternatingRows = True
            Me.dbgPallets.CaptionHeight = 19
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(8, 9)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(400, 223)
            Me.dbgPallets.TabIndex = 0
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
            "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
            "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
            "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
            "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
            "zing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""" & _
            "17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Heigh" & _
            "t>219</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""" & _
            "Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarSty" & _
            "le parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" />" & _
            "<GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
            "le2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle par" & _
            "ent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordS" & _
            "electorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selec" & _
            "ted"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 396, 2" & _
            "19</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.W" & _
            "in.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><" & _
            "Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Styl" & _
            "e parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style" & _
            " parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSt" & _
            "yles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><D" & _
            "efaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 396, 219</ClientArea>" & _
            "<PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" m" & _
            "e=""Style17"" /></Blob>"
            '
            'btnReprintPalletLabel
            '
            Me.btnReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintPalletLabel.Location = New System.Drawing.Point(8, 288)
            Me.btnReprintPalletLabel.Name = "btnReprintPalletLabel"
            Me.btnReprintPalletLabel.Size = New System.Drawing.Size(168, 31)
            Me.btnReprintPalletLabel.TabIndex = 3
            Me.btnReprintPalletLabel.Text = "REPRINT PALLET LABEL"
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBundle, Me.Button5, Me.btnCreatePalletID, Me.Label1})
            Me.pnlShipType.Location = New System.Drawing.Point(16, 32)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(421, 104)
            Me.pnlShipType.TabIndex = 120
            '
            'cboBundle
            '
            Me.cboBundle.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBundle.Caption = ""
            Me.cboBundle.CaptionHeight = 17
            Me.cboBundle.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBundle.ColumnCaptionHeight = 17
            Me.cboBundle.ColumnFooterHeight = 17
            Me.cboBundle.ContentHeight = 15
            Me.cboBundle.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBundle.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBundle.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBundle.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBundle.EditorHeight = 15
            Me.cboBundle.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboBundle.ItemHeight = 15
            Me.cboBundle.Location = New System.Drawing.Point(128, 6)
            Me.cboBundle.MatchEntryTimeout = CType(2000, Long)
            Me.cboBundle.MaxDropDownItems = CType(5, Short)
            Me.cboBundle.MaxLength = 32767
            Me.cboBundle.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBundle.Name = "cboBundle"
            Me.cboBundle.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBundle.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBundle.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBundle.Size = New System.Drawing.Size(240, 21)
            Me.cboBundle.TabIndex = 0
            Me.cboBundle.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Button5
            '
            Me.Button5.BackColor = System.Drawing.Color.Black
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(985, 274)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(410, 409)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'btnCreatePalletID
            '
            Me.btnCreatePalletID.BackColor = System.Drawing.Color.Green
            Me.btnCreatePalletID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreatePalletID.ForeColor = System.Drawing.Color.White
            Me.btnCreatePalletID.Location = New System.Drawing.Point(128, 60)
            Me.btnCreatePalletID.Name = "btnCreatePalletID"
            Me.btnCreatePalletID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreatePalletID.Size = New System.Drawing.Size(240, 32)
            Me.btnCreatePalletID.TabIndex = 3
            Me.btnCreatePalletID.Text = "CREATE PALLET ID"
            Me.btnCreatePalletID.Visible = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 21)
            Me.Label1.TabIndex = 85
            Me.Label1.Text = "Bundle:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDevCnt, Me.Label5, Me.txtOverPackName, Me.Label10, Me.btnClosePallet, Me.btnRemoveAllBoxes, Me.btnRemoveBox, Me.lstOverPackNames, Me.lblBoxCount, Me.Label3, Me.lblPalletName})
            Me.panelPallet.Location = New System.Drawing.Point(437, 32)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(400, 448)
            Me.panelPallet.TabIndex = 122
            Me.panelPallet.Visible = False
            '
            'lblDevCnt
            '
            Me.lblDevCnt.BackColor = System.Drawing.Color.Black
            Me.lblDevCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDevCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblDevCnt.Location = New System.Drawing.Point(304, 136)
            Me.lblDevCnt.Name = "lblDevCnt"
            Me.lblDevCnt.Size = New System.Drawing.Size(80, 43)
            Me.lblDevCnt.TabIndex = 102
            Me.lblDevCnt.Text = "0"
            Me.lblDevCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(296, 120)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 16)
            Me.Label5.TabIndex = 101
            Me.Label5.Text = "Device Count"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtOverPackName
            '
            Me.txtOverPackName.Location = New System.Drawing.Point(8, 64)
            Me.txtOverPackName.Name = "txtOverPackName"
            Me.txtOverPackName.Size = New System.Drawing.Size(176, 20)
            Me.txtOverPackName.TabIndex = 0
            Me.txtOverPackName.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 48)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Box Name :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnClosePallet
            '
            Me.btnClosePallet.BackColor = System.Drawing.Color.Green
            Me.btnClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClosePallet.ForeColor = System.Drawing.Color.White
            Me.btnClosePallet.Location = New System.Drawing.Point(200, 392)
            Me.btnClosePallet.Name = "btnClosePallet"
            Me.btnClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClosePallet.Size = New System.Drawing.Size(152, 30)
            Me.btnClosePallet.TabIndex = 2
            Me.btnClosePallet.Text = "CLOSE PALLET"
            '
            'btnRemoveAllBoxes
            '
            Me.btnRemoveAllBoxes.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllBoxes.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllBoxes.Location = New System.Drawing.Point(200, 264)
            Me.btnRemoveAllBoxes.Name = "btnRemoveAllBoxes"
            Me.btnRemoveAllBoxes.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllBoxes.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveAllBoxes.TabIndex = 4
            Me.btnRemoveAllBoxes.Text = "REMOVE ALL BOXES"
            '
            'btnRemoveBox
            '
            Me.btnRemoveBox.BackColor = System.Drawing.Color.Red
            Me.btnRemoveBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveBox.ForeColor = System.Drawing.Color.White
            Me.btnRemoveBox.Location = New System.Drawing.Point(200, 208)
            Me.btnRemoveBox.Name = "btnRemoveBox"
            Me.btnRemoveBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveBox.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveBox.TabIndex = 3
            Me.btnRemoveBox.Text = "REMOVE BOX"
            '
            'lstOverPackNames
            '
            Me.lstOverPackNames.Location = New System.Drawing.Point(8, 88)
            Me.lstOverPackNames.Name = "lstOverPackNames"
            Me.lstOverPackNames.Size = New System.Drawing.Size(176, 342)
            Me.lstOverPackNames.TabIndex = 1
            '
            'lblBoxCount
            '
            Me.lblBoxCount.BackColor = System.Drawing.Color.Black
            Me.lblBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxCount.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxCount.Location = New System.Drawing.Point(200, 136)
            Me.lblBoxCount.Name = "lblBoxCount"
            Me.lblBoxCount.Size = New System.Drawing.Size(80, 43)
            Me.lblBoxCount.TabIndex = 97
            Me.lblBoxCount.Text = "0"
            Me.lblBoxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(192, 120)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Box Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletName
            '
            Me.lblPalletName.BackColor = System.Drawing.Color.Black
            Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletName.Location = New System.Drawing.Point(8, 7)
            Me.lblPalletName.Name = "lblPalletName"
            Me.lblPalletName.Size = New System.Drawing.Size(384, 33)
            Me.lblPalletName.TabIndex = 98
            Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmAstroProductionShip
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(856, 510)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.pnlShipType, Me.panelPallet, Me.lblTitle})
            Me.Name = "frmAstroProductionShip"
            Me.Text = "frmAstroProductionShip"
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboBundle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelPallet.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************************************************************************************
        Private Sub frmAstroProductionShip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                '**************************************************
                'USE TO FIX OLD DATA... SHOULD ALWAY INVISIBLE
                '**************************************************
                If Core.ApplicationUser.GetPermission("SkAstro-ReplPalletWithOverPck") > 0 Then Me.btnReplacePalletWithOverPackAndDeletePallet.Visible = True Else Me.btnReplacePalletWithOverPackAndDeletePallet.Visible = False
                '**************************************************

                PSS.Core.Highlight.SetHighLight(Me)

                LoadBundleModelData()

                'Populate bundle, load openbox
                If Me._dsBundlesModels.Tables("BundleData").Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboBundle, Me._dsBundlesModels.Tables("BundleData"), "BundleName", "BundleID")
                    Me.cboBundle.SelectedIndex = 0

                    LoadOpenPallet()
                End If

                Me.panelPallet.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmAstroProductionShip_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub LoadBundleModelData()
            Dim ds As DataSet
            Try
                ds = Me._objSkullcandyRec.GetBundlesAndModelsData(Me._iMenuCustID)
                If ds.Tables.Count > 0 Then
                    If ds.Tables("BundleData").Rows.Count > 0 And ds.Tables("ModelData").Rows.Count > 0 Then
                        Try 'remove tables before add
                            Me._dsBundlesModels.Tables.Remove("BundleData") : Me._dsBundlesModels.Tables.Remove("ModelData")
                        Catch
                        End Try
                        Me._dsBundlesModels.Tables.Add(ds.Tables("BundleData").Copy)
                        Me._dsBundlesModels.Tables.Add(ds.Tables("ModelData").Copy)

                    Else
                        MessageBox.Show("No bundle data or no model data. See IT.", "LoadBundleModelData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Dim objCtrl As Control
                        For Each objCtrl In Me.Controls
                            objCtrl.Enabled = False
                        Next
                    End If
                Else
                    MessageBox.Show("No bundle data and model data. See IT.", "LoadBundleModelData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Dim objCtrl As Control
                    For Each objCtrl In Me.Controls
                        objCtrl.Enabled = False
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadBundleModelData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDS(ds)
            End Try

        End Sub

        '**************************************************************************************************************************************************
        Private Sub LoadOpenPallet(Optional ByVal iPalletID As Integer = 0)
            Dim dtBoxPalletNames As DataTable
            Dim row, drNewRow As DataRow
            Dim iModel_ID As Integer = 0, i As Integer

            Try
                If Not Me.cboBundle.SelectedValue > 0 Then
                    MessageBox.Show("Select a bundle.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Found model ID
                For Each row In Me._dsBundlesModels.Tables("ModelData").Rows
                    If row("BundleID") = Me.cboBundle.SelectedValue Then
                        iModel_ID = row("Model_ID")
                        Exit For 'get model id for the first one, then exit 
                    End If
                Next
                If Not iModel_ID > 0 Then
                    MessageBox.Show("No Model ID.", " btnCreateBoxPalletName_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                dtBoxPalletNames = Me._objSkullcandyRec.Astro_ProdShip_OpenBoxPallet(Me._iMenuLocID, iModel_ID)
                With Me.dbgPallets
                    .DataSource = dtBoxPalletNames.DefaultView
                    .Splits(0).DisplayColumns("Pallett_ID").Visible = False
                    .Splits(0).DisplayColumns("Pallet_SkuLen").Visible = False
                    .Splits(0).DisplayColumns("Pallet Name").Width = 210
                    .Splits(0).DisplayColumns("Bundle").Width = 110

                    For i = 0 To .RowCount - 1
                        If .Columns("Pallett_ID").CellValue(i) = iPalletID Then
                            Exit Sub
                        End If
                        .MoveNext()
                    Next i
                End With

                If dtBoxPalletNames.Rows.Count = 0 Then
                    Me.btnCreatePalletID.Visible = True
                Else
                    Me.btnCreatePalletID.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " LoadOpenPallet", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtBoxPalletNames)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub RefreshOverPackList(ByVal iPalletID As Integer)
            Dim dt As DataTable

            Try
                If Me.dbgPallets.Row < 0 Then
                    Exit Sub
                ElseIf iPalletID = 0 Then
                    MessageBox.Show("Please select pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dt = Me._objSkullcandyRec.Astro_ProdShip_GetMasterPackBoxes(iPalletID)
                    With Me.lstOverPackNames
                        .DataSource = dt.DefaultView
                        .DisplayMember = "OverPack_Name"
                        .ValueMember = "OverPack_ID"
                    End With

                    Me.lblBoxCount.Text = dt.Rows.Count
                    If IsDBNull(dt.Compute("Sum(Qty)", "")) Then Me.lblDevCnt.Text = "0" Else Me.lblDevCnt.Text = dt.Compute("Sum(Qty)", "")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadPalletData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub txtOverPackName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOverPackName.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso txtOverPackName.Text.Trim.Length > 0 Then
                    Me.ProcessOverPack()
                End If 'Key up and input length > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : txtOverPackName.SelectAll() : txtOverPackName.Focus()
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub ProcessOverPack()
            Dim dt As DataTable
            Dim strBundle As String = ""
            Dim i As Integer

            Try
                'Check a box selected
                If Me.lblPalletName.Tag = 0 OrElse Me.lblPalletName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please select a pallet.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                ElseIf Me.cboBundle.SelectedValue = 0 OrElse Me.cboBundle.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please select model.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                ElseIf Me.lstOverPackNames.DataSource.Table.Select("OverPack_Name = '" & Me.txtOverPackName.Text.ToUpper & "'").length > 0 Then
                    MessageBox.Show("Box is already listed.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                Else
                    strBundle = Me.dbgPallets.Columns("Bundle").Value.ToString
                    dt = Me._objSkullcandyRec.Astro_GetDeviceInOverPack(Me._iMenuCustID, Me._iMenuLocID, Me.txtOverPackName.Text)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Box does not exist.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                    ElseIf dt.Select("Closed = 0 ").Length > 0 Then
                        MessageBox.Show("Box is open.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                    ElseIf dt.Select("Bundle <> '" & strBundle & "'").Length > 0 Then
                        MessageBox.Show("Wrong model.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                    ElseIf dt.Select("DevicePalletID > 0 ").Length > 0 OrElse dt.Select("Pallett_ID > 0 ").Length > 0 Then
                        MessageBox.Show("Box belongs to a pallet.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                    ElseIf dt.Select("Device_DateShip = ''").Length > 0 Then
                        MessageBox.Show("Some units in box does not have production ship date. Please contact IT.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                    Else
                        i = Me._objSkullcandyRec.Astro_ProdShip_AssignOverPackToPallet(Me._iMenuLocID, CInt(Me.lblPalletName.Tag), dt.Rows(0)("OverPack_ID"))
                        If i > 0 Then
                            Me.txtOverPackName.Text = ""
                            Me.RefreshOverPackList(CInt(Me.lblPalletName.Tag))
                        Else
                            MessageBox.Show("System has failed to assign pallet to box.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtOverPackName.SelectAll() : Me.txtOverPackName.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboBundle_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBundle.SelectedValueChanged
            Try
                ClearPalletPanel()
                Me.btnCreatePalletID.Visible = False
                LoadOpenPallet()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboBundle_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosePallet.Click
            'Ship the box, close it, and print labels
            Dim dt As DataTable
            Dim i As Integer = 0, iPalletID As Integer = 0, iPalletQty As Integer = 0
            Dim objGamestopOpt As PSS.Data.Buisness.GameStopOpt

            Try
                If Me.lstOverPackNames.Items.Count = 0 OrElse Me.lblPalletName.Text.Trim.Length = 0 Then Exit Sub

                If MessageBox.Show("Do you want to ship it now?", "Information", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then Exit Sub

                Me.Cursor = Cursors.WaitCursor

                dt = Data.Production.Shipping.GetPalletInfoByName(Me.lblPalletName.Text.Trim, Me._iMenuCustID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet '" & Me.lblPalletName.Text.Trim & "' does not exist.", "Information", MessageBoxButtons.OK)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Pallet '" & Me.lblPalletName.Text.Trim & "' existed more than one. Please contact IT.", "Information", MessageBoxButtons.OK)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Pallet '" & Me.lblPalletName.Text.Trim & "' has been shipped. Please refresh your screen.", "Information", MessageBoxButtons.OK)
                Else
                    iPalletID = CInt(dt.Rows(0)("Pallett_ID"))
                    iPalletQty = Generic.GetPalletQty(iPalletID)
                    If iPalletQty = 0 Then Throw New Exception("Pallet is empty.")

                    i = Me._objSkullcandyRec.Astro_ProdShip_ClosePallet(iPalletID, iPalletQty, Core.ApplicationUser.IDShift)

                    If i > 0 Then
                        'Print pallet label
                        objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                        dt = objGamestopOpt.GetShipPalletData(Me.lblPalletName.Text.Trim, iPalletQty, Me.cboBundle.Text, "", New String() {"Shipper:", "", "Approval:"})
                        objGamestopOpt.PrintPalletLabel(dt, 2)
                        'Clear up
                        ClearPalletPanel()
                        Me.LoadOpenPallet()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
                Generic.DisposeDT(dt) : objGamestopOpt = Nothing
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ClearPalletPanel()
            Try
                Me.txtOverPackName.Text = ""
                Me.lblPalletName.Text = "" : Me.lblPalletName.Tag = 0
                Me.lblDevCnt.Text = "0" : Me.lblDevCnt.Text = "0"
                Me.lstOverPackNames.DataSource = Nothing : Me.lstOverPackNames.Items.Clear() : Me.lstOverPackNames.Refresh()
                Me.panelPallet.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearPalletPanel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCreatePalletID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreatePalletID.Click
            Dim iPalletID As Integer, iModel_ID As Integer
            Dim row As DataRow, drNewRow As DataRow

            Try
                If Not Me.cboBundle.SelectedValue > 0 Then
                    MessageBox.Show("Select a bundle.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Found model ID
                For Each row In Me._dsBundlesModels.Tables("ModelData").Rows
                    If row("BundleID") = Me.cboBundle.SelectedValue Then
                        iModel_ID = row("Model_ID")
                        Exit For 'get model id for the first one, then exit 
                    End If
                Next
                If Not iModel_ID > 0 Then
                    MessageBox.Show("No Model ID.", " btnCreateBoxPalletName_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                iPalletID = Me._objSkullcandyRec.Astro_ProdShip_CreatePallet(Me._iMenuCustID, Me._iMenuLocID, iModel_ID, Me.cboBundle.Text, _iPalletShipType)
                If iPalletID = 0 Then Throw New Exception("System has failed to create pallet.")
                Me.LoadOpenPallet(iPalletID)
                Me.ProcessPalletSelection()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCreateBoxPalletName_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
            Try
                Me.ProcessPalletSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub ProcessPalletSelection()
            Dim strShipType As String = ""
            Dim i As Integer = 0
            Dim booFound As Boolean = False

            Try
                ClearPalletPanel()
                Me.panelPallet.Visible = True
                Me.btnCreatePalletID.Visible = False

                If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                    Me.panelPallet.Visible = False
                    Exit Sub
                ElseIf Me.dbgPallets.Columns("Pallet Name").Value.ToString.Trim = "" Then
                    Exit Sub
                End If

                Me.lblPalletName.Text = Me.dbgPallets.Columns("Pallet Name").Value.ToString
                Me.lblPalletName.Tag = Me.dbgPallets.Columns("Pallett_ID").Value.ToString

                Me.RefreshOverPackList(CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                '*******************************************
                Me.txtOverPackName.Focus()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub btnDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletePallet.Click
            Dim i As Integer = 0

            Try
                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to delete selected Box?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                    MessageBox.Show("Box has been deleted.")

                    Me.LoadOpenPallet()
                    ClearPalletPanel()
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub btnReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPalletLabel.Click
            Dim strPalletName As String = ""
            Dim dt, dtShipPalletRpt As DataTable
            Dim objGamestopOpt As PSS.Data.Buisness.GameStopOpt

            Try
                strPalletName = InputBox("Enter Pallet Name.", "Reprint Pallet Label")
                If strPalletName.Trim.Length = 0 Then Exit Sub

                Cursor.Current = Cursors.WaitCursor

                dt = Me._objSkullcandyRec.Astro_GetPalletInfoByName(strPalletName, Me._iMenuCustID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet Name was not defined in system.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Pallet Name existed more than one in the system. Please contact IT.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Pallet is open.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                    MessageBox.Show("Pallet is empty.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                    dtShipPalletRpt = objGamestopOpt.GetShipPalletData(strPalletName, dt.Rows(0)("Pallett_QTY"), dt.Rows(0)("Bundle"), "", New String() {"Shipper:", "", "Approval:"})
                    objGamestopOpt.PrintPalletLabel(dtShipPalletRpt, 1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Pallet Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub btnRefreshList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshList.Click
            Try
                ClearPalletPanel()
                Me.btnCreatePalletID.Visible = False
                Me.LoadOpenPallet()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefreshList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub btnRemoveBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBox.Click
            Dim iOverPackID As Integer
            Dim strOverPackName As String = ""

            Try
                strOverPackName = InputBox("Enter box name:").Trim.ToUpper
                If strOverPackName.Length = 0 Then
                    Exit Sub
                ElseIf Me.lblPalletName.Tag = 0 Then
                    MessageBox.Show("Please select pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstOverPackNames.Items.Count = 0 Then
                    MessageBox.Show("List is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me.lstOverPackNames.DataSource.Table.Select("OverPack_Name = '" & strOverPackName & "'").Length = 0 Then
                        MessageBox.Show("Box is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        iOverPackID = Me.lstOverPackNames.DataSource.Table.Select("OverPack_Name = '" & strOverPackName & "'")(0)("OverPack_ID")
                        Me._objSkullcandyRec.Astro_ProdShip_RemoveOverPackFrPallet(Me._iMenuLocID, iOverPackID)
                        Me.RefreshOverPackList(CInt(Me.lblPalletName.Tag))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRemoveBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub btnRemoveAllBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllBoxes.Click
            Try
                If Me.lblPalletName.Tag = 0 Then
                    MessageBox.Show("Please select pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstOverPackNames.Items.Count = 0 Then
                    MessageBox.Show("List is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to remove all boxes in selected pallet?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me._objSkullcandyRec.Astro_ProdShip_RemoveAllOverPacksFrPallet(Me._iMenuLocID, CInt(Me.lblPalletName.Tag))
                    Me.RefreshOverPackList(CInt(Me.lblPalletName.Tag))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRemoveBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************************************************************
        Private Sub btnCreateOverPackByPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplacePalletWithOverPackAndDeletePallet.Click
            Dim strPalletName As String = ""
            Dim dt As DataTable

            Try
                strPalletName = InputBox("Enter Pallet Name:").Trim

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                Me._objSkullcandyRec.Astro_ProdShip_CreateOverPackByPalletAndDeletePallet(Me._iMenuCustID, strPalletName, Core.ApplicationUser.IDuser)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateOverPackByPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************************************************************


    End Class
End Namespace
