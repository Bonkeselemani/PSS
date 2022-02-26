Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAstroBuildOverPack
        Inherits System.Windows.Forms.Form
        Private Const _iPalletShipType As Integer = 0

        Private _iMenuCustID As Integer
        Private _objSkullcandy As Skullcandy
        Private _objSkullcandyRec As SkullcandyRec
        Private _ObjSkullcandyPrint As SkullcandyPrint
        Private _dsBundlesModels As New DataSet()
        Private _iShipBoxBundleLimit As Integer
        Private _strColPrefix As String = Skullcandy.ASTRO_ShipColPreFix
        Private _bFirstStart As Boolean = True

        Private _strSN1 As String = "", _strSN2 As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCustID
            Me._objSkullcandy = New Skullcandy()
            Me._objSkullcandyRec = New SkullcandyRec()
            Me._ObjSkullcandyPrint = New SkullcandyPrint()
            Me.lblTitle.Text = strScreenName
            Me._iShipBoxBundleLimit = Me._objSkullcandy.ASTRO_ShipBoxBundleLimit
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
        Friend WithEvents pnlDeviceSN As System.Windows.Forms.Panel
        Friend WithEvents grpBoxQty As System.Windows.Forms.GroupBox
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents grpPrintOption As System.Windows.Forms.GroupBox
        Friend WithEvents chkPrintPalletLabel As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintSNLabel As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintBoxLabel As System.Windows.Forms.CheckBox
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents chkPrintSNsFulfilled As System.Windows.Forms.CheckBox
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents btnStartBox As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents lblBundle As System.Windows.Forms.Label
        Friend WithEvents btnRePrintLabels As System.Windows.Forms.Button
        Friend WithEvents lblBox As System.Windows.Forms.Label
        Friend WithEvents cboBundle As C1.Win.C1List.C1Combo
        Friend WithEvents btnCreateBoxName As System.Windows.Forms.Button
        Friend WithEvents lstBoxName As System.Windows.Forms.ListBox
        Friend WithEvents btnCloseShipBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintSN As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAstroBuildOverPack))
            Me.pnlDeviceSN = New System.Windows.Forms.Panel()
            Me.grpBoxQty = New System.Windows.Forms.GroupBox()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.grpPrintOption = New System.Windows.Forms.GroupBox()
            Me.chkPrintPalletLabel = New System.Windows.Forms.CheckBox()
            Me.chkPrintSNLabel = New System.Windows.Forms.CheckBox()
            Me.chkPrintBoxLabel = New System.Windows.Forms.CheckBox()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCloseShipBox = New System.Windows.Forms.Button()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.chkPrintSNsFulfilled = New System.Windows.Forms.CheckBox()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.btnStartBox = New System.Windows.Forms.Button()
            Me.btnCreateBoxName = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.lblBundle = New System.Windows.Forms.Label()
            Me.btnRePrintLabels = New System.Windows.Forms.Button()
            Me.lblBox = New System.Windows.Forms.Label()
            Me.lstBoxName = New System.Windows.Forms.ListBox()
            Me.cboBundle = New C1.Win.C1List.C1Combo()
            Me.btnReprintSN = New System.Windows.Forms.Button()
            Me.pnlDeviceSN.SuspendLayout()
            Me.grpBoxQty.SuspendLayout()
            Me.grpPrintOption.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboBundle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlDeviceSN
            '
            Me.pnlDeviceSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpBoxQty, Me.lblSN, Me.grpPrintOption, Me.txtSN, Me.tdgData1, Me.btnCloseShipBox, Me.btnRemove, Me.chkPrintSNsFulfilled, Me.btnReprintSN})
            Me.pnlDeviceSN.Location = New System.Drawing.Point(40, 200)
            Me.pnlDeviceSN.Name = "pnlDeviceSN"
            Me.pnlDeviceSN.Size = New System.Drawing.Size(664, 336)
            Me.pnlDeviceSN.TabIndex = 127
            '
            'grpBoxQty
            '
            Me.grpBoxQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblQty})
            Me.grpBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpBoxQty.ForeColor = System.Drawing.Color.White
            Me.grpBoxQty.Location = New System.Drawing.Point(408, 56)
            Me.grpBoxQty.Name = "grpBoxQty"
            Me.grpBoxQty.Size = New System.Drawing.Size(192, 56)
            Me.grpBoxQty.TabIndex = 111
            Me.grpBoxQty.TabStop = False
            Me.grpBoxQty.Text = "Box Qty"
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.Black
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Lime
            Me.lblQty.Location = New System.Drawing.Point(32, 16)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(128, 32)
            Me.lblQty.TabIndex = 110
            Me.lblQty.Text = "0"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.White
            Me.lblSN.Location = New System.Drawing.Point(16, 16)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(32, 16)
            Me.lblSN.TabIndex = 98
            Me.lblSN.Text = "SN: "
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grpPrintOption
            '
            Me.grpPrintOption.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrintPalletLabel, Me.chkPrintSNLabel, Me.chkPrintBoxLabel})
            Me.grpPrintOption.Location = New System.Drawing.Point(408, 120)
            Me.grpPrintOption.Name = "grpPrintOption"
            Me.grpPrintOption.Size = New System.Drawing.Size(192, 96)
            Me.grpPrintOption.TabIndex = 113
            Me.grpPrintOption.TabStop = False
            '
            'chkPrintPalletLabel
            '
            Me.chkPrintPalletLabel.BackColor = System.Drawing.Color.Transparent
            Me.chkPrintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintPalletLabel.ForeColor = System.Drawing.Color.White
            Me.chkPrintPalletLabel.Location = New System.Drawing.Point(16, 40)
            Me.chkPrintPalletLabel.Name = "chkPrintPalletLabel"
            Me.chkPrintPalletLabel.Size = New System.Drawing.Size(160, 24)
            Me.chkPrintPalletLabel.TabIndex = 4
            Me.chkPrintPalletLabel.Text = "Print Box Name Label"
            '
            'chkPrintSNLabel
            '
            Me.chkPrintSNLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintSNLabel.ForeColor = System.Drawing.Color.White
            Me.chkPrintSNLabel.Location = New System.Drawing.Point(16, 64)
            Me.chkPrintSNLabel.Name = "chkPrintSNLabel"
            Me.chkPrintSNLabel.Size = New System.Drawing.Size(160, 24)
            Me.chkPrintSNLabel.TabIndex = 1
            Me.chkPrintSNLabel.Text = "Print Bundle(SN) Label"
            '
            'chkPrintBoxLabel
            '
            Me.chkPrintBoxLabel.BackColor = System.Drawing.Color.Transparent
            Me.chkPrintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.chkPrintBoxLabel.Location = New System.Drawing.Point(16, 16)
            Me.chkPrintBoxLabel.Name = "chkPrintBoxLabel"
            Me.chkPrintBoxLabel.Size = New System.Drawing.Size(160, 24)
            Me.chkPrintBoxLabel.TabIndex = 0
            Me.chkPrintBoxLabel.Text = "Print Masterpack Label"
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(48, 16)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(256, 23)
            Me.txtSN.TabIndex = 97
            Me.txtSN.Text = ""
            '
            'tdgData1
            '
            Me.tdgData1.AllowColMove = False
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowDelete = True
            Me.tdgData1.AllowFilter = False
            Me.tdgData1.AllowSort = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(16, 48)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.RowSubDividerColor = System.Drawing.Color.Silver
            Me.tdgData1.Size = New System.Drawing.Size(376, 232)
            Me.tdgData1.TabIndex = 96
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;ForeColor:DarkGoldenrod;}Style9{}Normal{Font:Microsoft San" & _
            "s Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style" & _
            "12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVe" & _
            "rt:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Sty" & _
            "le8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles>" & _
            "<Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""Fals" & _
            "e"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" F" & _
            "etchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" De" & _
            "fRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>230<" & _
            "/Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor" & _
            """ me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle par" & _
            "ent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Group" & _
            "Style parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /" & _
            "><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""I" & _
            "nactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelecto" & _
            "rStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" m" & _
            "e=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 374, 230</Cl" & _
            "ientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1T" & _
            "rueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style " & _
            "parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pare" & _
            "nt=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style paren" & _
            "t=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""N" & _
            "ormal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""" & _
            "Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style paren" & _
            "t=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Default" & _
            "RecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 374, 230</ClientArea><Print" & _
            "PageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Sty" & _
            "le15"" /></Blob>"
            '
            'btnCloseShipBox
            '
            Me.btnCloseShipBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseShipBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseShipBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseShipBox.Location = New System.Drawing.Point(408, 232)
            Me.btnCloseShipBox.Name = "btnCloseShipBox"
            Me.btnCloseShipBox.Size = New System.Drawing.Size(192, 48)
            Me.btnCloseShipBox.TabIndex = 99
            Me.btnCloseShipBox.Text = "Close && Ship Box"
            '
            'btnRemove
            '
            Me.btnRemove.BackColor = System.Drawing.Color.Red
            Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemove.ForeColor = System.Drawing.Color.White
            Me.btnRemove.Location = New System.Drawing.Point(408, 16)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(192, 24)
            Me.btnRemove.TabIndex = 100
            Me.btnRemove.Text = "Remove Bundle"
            '
            'chkPrintSNsFulfilled
            '
            Me.chkPrintSNsFulfilled.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintSNsFulfilled.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.chkPrintSNsFulfilled.Location = New System.Drawing.Point(336, 35)
            Me.chkPrintSNsFulfilled.Name = "chkPrintSNsFulfilled"
            Me.chkPrintSNsFulfilled.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkPrintSNsFulfilled.Size = New System.Drawing.Size(56, 16)
            Me.chkPrintSNsFulfilled.TabIndex = 114
            Me.chkPrintSNsFulfilled.Text = "Print"
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.White
            Me.lblTitle.Location = New System.Drawing.Point(32, 16)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(296, 24)
            Me.lblTitle.TabIndex = 121
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnStartBox
            '
            Me.btnStartBox.BackColor = System.Drawing.Color.Green
            Me.btnStartBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnStartBox.ForeColor = System.Drawing.Color.White
            Me.btnStartBox.Location = New System.Drawing.Point(96, 152)
            Me.btnStartBox.Name = "btnStartBox"
            Me.btnStartBox.Size = New System.Drawing.Size(232, 32)
            Me.btnStartBox.TabIndex = 129
            Me.btnStartBox.Text = "Start"
            '
            'btnCreateBoxName
            '
            Me.btnCreateBoxName.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxName.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxName.Location = New System.Drawing.Point(344, 88)
            Me.btnCreateBoxName.Name = "btnCreateBoxName"
            Me.btnCreateBoxName.Size = New System.Drawing.Size(96, 32)
            Me.btnCreateBoxName.TabIndex = 125
            Me.btnCreateBoxName.Text = "Create Box"
            '
            'btnReset
            '
            Me.btnReset.BackColor = System.Drawing.Color.Green
            Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReset.ForeColor = System.Drawing.Color.White
            Me.btnReset.Location = New System.Drawing.Point(344, 48)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(96, 32)
            Me.btnReset.TabIndex = 124
            Me.btnReset.Text = "Reset"
            '
            'lblBundle
            '
            Me.lblBundle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBundle.ForeColor = System.Drawing.Color.White
            Me.lblBundle.Location = New System.Drawing.Point(32, 50)
            Me.lblBundle.Name = "lblBundle"
            Me.lblBundle.Size = New System.Drawing.Size(56, 16)
            Me.lblBundle.TabIndex = 123
            Me.lblBundle.Text = "Bundle: "
            Me.lblBundle.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'btnRePrintLabels
            '
            Me.btnRePrintLabels.BackColor = System.Drawing.Color.Green
            Me.btnRePrintLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRePrintLabels.ForeColor = System.Drawing.Color.White
            Me.btnRePrintLabels.Location = New System.Drawing.Point(336, 152)
            Me.btnRePrintLabels.Name = "btnRePrintLabels"
            Me.btnRePrintLabels.Size = New System.Drawing.Size(104, 32)
            Me.btnRePrintLabels.TabIndex = 130
            Me.btnRePrintLabels.Text = "Reprint Labels"
            '
            'lblBox
            '
            Me.lblBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBox.ForeColor = System.Drawing.Color.White
            Me.lblBox.Location = New System.Drawing.Point(32, 80)
            Me.lblBox.Name = "lblBox"
            Me.lblBox.Size = New System.Drawing.Size(53, 16)
            Me.lblBox.TabIndex = 126
            Me.lblBox.Text = "Box:"
            Me.lblBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lstBoxName
            '
            Me.lstBoxName.BackColor = System.Drawing.Color.OldLace
            Me.lstBoxName.Location = New System.Drawing.Point(96, 80)
            Me.lstBoxName.Name = "lstBoxName"
            Me.lstBoxName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
            Me.lstBoxName.Size = New System.Drawing.Size(232, 69)
            Me.lstBoxName.TabIndex = 128
            '
            'cboBundle
            '
            Me.cboBundle.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBundle.AutoCompletion = True
            Me.cboBundle.AutoDropDown = True
            Me.cboBundle.AutoSelect = True
            Me.cboBundle.Caption = ""
            Me.cboBundle.CaptionHeight = 17
            Me.cboBundle.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBundle.ColumnCaptionHeight = 17
            Me.cboBundle.ColumnFooterHeight = 17
            Me.cboBundle.ColumnHeaders = False
            Me.cboBundle.ContentHeight = 15
            Me.cboBundle.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBundle.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBundle.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBundle.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBundle.EditorHeight = 15
            Me.cboBundle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBundle.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboBundle.ItemHeight = 15
            Me.cboBundle.Location = New System.Drawing.Point(96, 48)
            Me.cboBundle.MatchEntryTimeout = CType(2000, Long)
            Me.cboBundle.MaxDropDownItems = CType(10, Short)
            Me.cboBundle.MaxLength = 32767
            Me.cboBundle.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBundle.Name = "cboBundle"
            Me.cboBundle.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBundle.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBundle.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBundle.Size = New System.Drawing.Size(232, 21)
            Me.cboBundle.TabIndex = 122
            Me.cboBundle.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnReprintSN
            '
            Me.btnReprintSN.BackColor = System.Drawing.Color.DarkOliveGreen
            Me.btnReprintSN.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnReprintSN.Location = New System.Drawing.Point(16, 280)
            Me.btnReprintSN.Name = "btnReprintSN"
            Me.btnReprintSN.Size = New System.Drawing.Size(200, 24)
            Me.btnReprintSN.TabIndex = 131
            Me.btnReprintSN.Text = "Reprint SN Label in Current Box"
            '
            'frmAstroBuildOverPack
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(840, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDeviceSN, Me.lblTitle, Me.btnStartBox, Me.btnCreateBoxName, Me.btnReset, Me.lblBundle, Me.btnRePrintLabels, Me.lblBox, Me.lstBoxName, Me.cboBundle})
            Me.Name = "frmAstroBuildOverPack"
            Me.Text = "frmAstroBuildOverPack"
            Me.pnlDeviceSN.ResumeLayout(False)
            Me.grpBoxQty.ResumeLayout(False)
            Me.grpPrintOption.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboBundle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmAstroBuildOverPack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                LoadBundleModelData()

                'Populate bundle, load openbox
                If Me._dsBundlesModels.Tables("BundleData").Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboBundle, Me._dsBundlesModels.Tables("BundleData"), "BundleName", "BundleID")
                    Me.cboBundle.SelectedIndex = 0

                    LoadOpenBoxes()
                    CreateShipBundleTable()
                End If
                Me.chkPrintBoxLabel.Checked = True : Me.chkPrintPalletLabel.Checked = True
                Me.chkPrintSNsFulfilled.Checked = True : Me.chkPrintSNLabel.Checked = False

                Me.pnlDeviceSN.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmAstroBuildOverPack_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._bFirstStart = False
            End Try
        End Sub

        '***************************************************************************************
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

        '*********************************************************************************************
        Private Sub LoadOpenBoxes()
            Dim dtBoxNames, dt As DataTable, row, drNewRow As DataRow
            Dim iModel_ID As Integer = 0, i As Integer = 0

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

                dtBoxNames = Me._objSkullcandyRec.Astro_GetOpenOverPacks(Me._objSkullcandy.ASTRO_CUSTOMERID, Me._objSkullcandy.ASTRO_LOCID, _iPalletShipType, Me.cboBundle.Text)

                Me.lstBoxName.DataSource = Nothing : Me.lstBoxName.Items.Clear() : Me.lstBoxName.Refresh()
                With Me.lstBoxName
                    .DataSource = dtBoxNames.DefaultView
                    .DisplayMember = "OverPack_Name"
                    .ValueMember = "OverPack_ID"
                    .Refresh()
                    .ClearSelected()
                    If .Items.Count > 0 Then
                        Me.btnCreateBoxName.Enabled = False
                    Else
                        Me.btnCreateBoxName.Enabled = True
                    End If
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " LoadOpenBoxPallet", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtBoxNames)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub LoadBoxSavedDeviceData(ByVal iOverPackID As Integer)
            Dim dtDevices As DataTable, dtCountInBundle As DataTable
            Dim dtOK As DataTable
            Dim row As DataRow, newRow As DataRow
            Dim iBundleCount As Integer = 0, iShip_ID As Integer = 0
            Dim strS As String = "", strSN As String = ""
            Dim strColName As String = ""

            Try
                If IsNothing(Me.tdgData1.DataSource) Then
                    CreateShipBundleTable()
                Else
                    Me.tdgData1.DataSource = Nothing : Me.tdgData1.Refresh()
                    CreateShipBundleTable()
                End If
                dtOK = Me.tdgData1.DataSource

                dtDevices = Me._objSkullcandyRec.Astro_ProdShip_GetBoxDevices(Me._objSkullcandy.ASTRO_LOCID, iOverPackID, dtCountInBundle)

                If dtCountInBundle.Rows.Count > 0 AndAlso dtDevices.Rows.Count > 0 Then 'Has data
                    iBundleCount = Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount")
                    For Each row In dtCountInBundle.Rows 'valid device count in bundle
                        If row("CountInBundle") <> iBundleCount Then
                            MessageBox.Show("Corrupted device data in the box. Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    Next
                    For Each row In dtDevices.Rows 'valid device shipped in bundle
                        If row.IsNull("Device_DateShip") Then
                            'ok
                        Else
                            strS = row("Device_DateShip")
                            If strS.Trim.Length > 0 Then
                                MessageBox.Show("Corrupted device data in the box (Some device(s) shipped). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        End If
                        If row.IsNull("Ship_ID") Then 'Validate Ship_ID
                            MessageBox.Show("Corrupted device data in the box (some device ha no ship_ID). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf Not CInt(row("Ship_ID")) > 0 Then
                            MessageBox.Show("Corrupted device data in the box (some device ha no ship_ID). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    Next
                    For Each row In dtCountInBundle.Rows 'Load it now bundle by bundle, i.e., ship_ID by ship_ID
                        iShip_ID = row("Ship_ID")
                        Dim filteredDT As DataTable, foundRows As DataRow()
                        Dim Rep_Expression As String = "[Ship_ID] = " & iShip_ID
                        Dim fRow As DataRow
                        Dim strOID As String
                        foundRows = dtDevices.Select(Rep_Expression)
                        filteredDT = dtDevices.Clone
                        For Each fRow In foundRows
                            filteredDT.ImportRow(fRow)
                        Next
                        If filteredDT.Rows.Count = iBundleCount Then
                            For Each fRow In filteredDT.Rows
                                strSN = fRow("Device_SN")
                                If IsValidSN(strSN, Me.cboBundle.SelectedValue, strColName) Then
                                    If dtOK.Rows.Count = 0 Then 'first row
                                        newRow = dtOK.NewRow
                                        newRow(strColName) = strSN
                                        strOID = strColName.Replace(Me._strColPrefix, "")
                                        If Not strOID.Trim.Length > 0 Then
                                            MessageBox.Show("Corrupted device data in the box (invalid column name). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            Exit Sub
                                        End If
                                        newRow("DeviceID_" & strOID) = fRow("Device_ID")
                                        newRow("ModelID_" & strOID) = fRow("Model_ID")
                                        newRow("WOID_" & strOID) = fRow("WO_ID")
                                        dtOK.Rows.Add(newRow)
                                    Else
                                        Dim iUnfilledRow As Integer, strUnfilledCol As String
                                        GetUnfilledCell(iUnfilledRow, strUnfilledCol)   'check for unfilled cell
                                        If iUnfilledRow > 0 AndAlso strUnfilledCol.Trim.Length > 0 Then
                                            If Not strColName = strUnfilledCol Then
                                                MessageBox.Show("'" & Me.txtSN.Text & "' is not a vaid unit to fill bundle " & iUnfilledRow & " and column " & strUnfilledCol & " (" & _
                                                                Me._dsBundlesModels.Tables("ModelData").Select("BundleID= " & Me.cboBundle.SelectedValue & " AND ColName='" & strUnfilledCol & "'")(0)("Model_Desc") & ")", _
                                                                "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                                Exit Sub
                                            Else
                                                strOID = strColName.Replace(Me._strColPrefix, "")
                                                If Not strOID.Trim.Length > 0 Then
                                                    MessageBox.Show("Corrupted device data in the box (invalid column name). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                                    Exit Sub
                                                End If
                                                dtOK.Rows(iUnfilledRow - 1).BeginEdit()
                                                dtOK.Rows(iUnfilledRow - 1).Item(strUnfilledCol) = strSN  'table.Rows(0).BeginEdit()      table.Rows(0)(0) = 100
                                                dtOK.Rows(iUnfilledRow - 1).Item("DeviceID_" & strOID) = fRow("Device_ID")
                                                dtOK.Rows(iUnfilledRow - 1).Item("ModelID_" & strOID) = fRow("Model_ID")
                                                dtOK.Rows(iUnfilledRow - 1).Item("WOID_" & strOID) = fRow("WO_ID")
                                                dtOK.Rows(iUnfilledRow - 1).AcceptChanges()
                                            End If
                                        Else
                                            newRow = dtOK.NewRow
                                            newRow(strColName) = strSN
                                            strOID = strColName.Replace(Me._strColPrefix, "")
                                            If Not strOID.Trim.Length > 0 Then
                                                MessageBox.Show("Corrupted device data in the box (invalid column name). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                                Exit Sub
                                            End If
                                            newRow("DeviceID_" & strOID) = fRow("Device_ID")
                                            newRow("ModelID_" & strOID) = fRow("Model_ID")
                                            newRow("WOID_" & strOID) = fRow("WO_ID")
                                            dtOK.Rows.Add(newRow)
                                        End If
                                    End If
                                    Me.tdgData1.Refresh()
                                Else
                                    MessageBox.Show("Corrupted device data in the box (invalid SN in a bundle). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                            Next
                        Else
                            MessageBox.Show("Corrupted device data in the box (No enough devices in a bundle). Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        Generic.DisposeDT(filteredDT) : foundRows = Nothing
                    Next

                ElseIf dtCountInBundle.Rows.Count > 0 AndAlso Not dtDevices.Rows.Count > 0 Then
                    MessageBox.Show("Corrupted device data in the box. Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not dtCountInBundle.Rows.Count > 0 AndAlso dtDevices.Rows.Count > 0 Then
                    MessageBox.Show("Corrupted device data in the box. Failed to load! See IT.", "LoadBoxSavedDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Me.lblQty.Text = Me.tdgData1.RowCount : Me.pnlDeviceSN.Enabled = True
                Me.cboBundle.Enabled = False : Me.lstBoxName.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadBoxDeviceData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso txtSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If 'Key up and input length > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : txtSN.SelectAll() : txtSN.Focus()
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ProcessSN()
            Dim dt As DataTable, dtDevice As DataTable, tmpDT As DataTable
            Dim strSN As String = "", strArrLstSN As New ArrayList()
            Dim strColName As String
            Dim strColName_DeviceID As String, strColName_ModelID As String, strColName_WOID As String
            Dim Row, R1 As DataRow
            Dim iUnfilledRow As Integer = 0, strUnfilledCol As String = ""
            Dim iDevice_ID As Integer = 0, iModel_ID As Integer = 0, iWO_ID As Integer = 0, iShip_ID As Integer = 0
            Dim iMaxBillRule As Integer
            Dim strDateTime As String, strErrMsg As String = ""
            Dim DTime As Date, iOverPackID As Integer = 0, iBundleCount As Integer = 0, i As Integer
            Dim iDeviceSeqCnt As Integer, strArrLstDeviceIDs As New ArrayList()
            Dim iQtyBefore As Integer = 0, iQtyAfter As Integer = 0

            Try
                'Check a box selected
                If Not Me.lstBoxName.SelectedValue > 0 Then
                    MessageBox.Show("Please select a box.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Check if ShipBundle Table created
                If IsNothing(Me.tdgData1.DataSource) Then
                    MessageBox.Show("No ship bundle table. See IT", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Check for duplicate
                dt = Me.tdgData1.DataSource
                For i = 0 To dt.Columns.Count - 1
                    If dt.Columns(i).Caption.StartsWith("SN_") = True AndAlso dt.Select(dt.Columns(i).Caption & " = '" & Me.txtSN.Text.Trim.ToUpper & "'").Length > 0 Then
                        MessageBox.Show("SN is listed.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Next i

                'Validate Box input
                If Not Me.cboBundle.SelectedValue > 0 Then
                    MessageBox.Show("Select a bundle.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Not Me.txtSN.Text.Trim.Length > 0 Then
                    MessageBox.Show("Scan/Enter a SN.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.lblQty.Text >= Me._iShipBoxBundleLimit Then
                    MessageBox.Show("Can't add. Box is full.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Text = "" : Me.txtSN.Focus() : Exit Sub
                End If

                ' Me.cboBundle.SelectedValue ' Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleID")
                strSN = Me.txtSN.Text.Trim.ToUpper : strArrLstSN.Add(strSN) : Me.cboBundle.Enabled = False
                If IsValidSN(strSN, Me.cboBundle.SelectedValue, strColName) Then
                    'Validate SN in WIP
                    dtDevice = Me._objSkullcandyRec.Astro_ProdShip_WIPData(Me._objSkullcandy.ASTRO_LOCID, strSN)
                    If Not dtDevice.Rows.Count > 0 Then
                        MessageBox.Show("SN '" & strSN & "' is not in WIP.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus() : Exit Sub
                    ElseIf dtDevice.Rows.Count > 1 Then
                        MessageBox.Show("Two or more '" & strSN & "' is found in WIP.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus() : Exit Sub
                    End If

                    'Check model
                    If Me._objSkullcandyRec.Astro_GetCustomerModelNumberByDevice(CInt(dtDevice.Rows(0).Item("Device_ID"))).ToString.ToLower <> Me.cboBundle.Text.Trim.ToLower Then
                        Throw New Exception("Wrong model.")
                    End If

                    'Get required data
                    iDevice_ID = dtDevice.Rows(0).Item("Device_ID")
                    iModel_ID = dtDevice.Rows(0).Item("Model_ID")
                    iWO_ID = dtDevice.Rows(0).Item("WO_ID")

                    'Validate in Billing
                    If Not Me._objSkullcandyRec.Astro_ProdShip_DeviceBilled(Me._objSkullcandy.ASTRO_LOCID, iDevice_ID) Then
                        MessageBox.Show("The device has not been billed yet.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus() : Exit Sub
                    End If

                    'Validate in QC
                    iMaxBillRule = Generic.GetMaxBillRule(iDevice_ID)
                    If iMaxBillRule = 0 Then '0 is normal repair
                        If Generic.IsValidQCResults(iDevice_ID, 1, "Functional", False, True) = False Then
                            Exit Sub : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        End If
                    Else 'Scrap or others
                        MessageBox.Show("Device is a scrap or abnormal repair.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus() : Exit Sub
                    End If

                    'Form dynamic column names
                    strColName_DeviceID = "DeviceID_" & strColName.Replace(Me._strColPrefix, "")
                    strColName_ModelID = "ModelID_" & strColName.Replace(Me._strColPrefix, "")
                    strColName_WOID = "WOID_" & strColName.Replace(Me._strColPrefix, "")

                    'Add device data
                    iQtyBefore = CInt(Me.lblQty.Text)
                    tmpDT = dt.Clone

                    If dt.Rows.Count = 0 Then
                        Row = dt.NewRow
                        Row(strColName) = strSN
                        Row(strColName_DeviceID) = iDevice_ID
                        Row(strColName_ModelID) = iModel_ID
                        Row(strColName_WOID) = iWO_ID
                        dt.Rows.Add(Row) 'Add
                        tmpDT.ImportRow(Row) 'import this row
                        Me.tdgData1.DataSource = dt
                        Me._strSN1 = strSN
                    Else
                        GetUnfilledCell(iUnfilledRow, strUnfilledCol)  'check for unfilled cell
                        If iUnfilledRow > 0 AndAlso strUnfilledCol.Trim.Length > 0 Then
                            If Not strColName = strUnfilledCol Then
                                MessageBox.Show("'" & Me.txtSN.Text & "' is not a vaid unit to fill bundle " & iUnfilledRow & " and column " & strUnfilledCol & " (" & _
                                                Me._dsBundlesModels.Tables("ModelData").Select("BundleID= " & Me.cboBundle.SelectedValue & " AND ColName='" & strUnfilledCol & "'")(0)("Model_Desc") & ")", _
                                                "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.Text = "" : Me.txtSN.Focus()
                            Else
                                strColName_DeviceID = "DeviceID_" & strUnfilledCol.Replace(Me._strColPrefix, "")
                                strColName_ModelID = "ModelID_" & strUnfilledCol.Replace(Me._strColPrefix, "")
                                strColName_WOID = "WOID_" & strUnfilledCol.Replace(Me._strColPrefix, "")
                                dt.Rows(iUnfilledRow - 1).BeginEdit()
                                dt.Rows(iUnfilledRow - 1).Item(strUnfilledCol) = strSN  'table.Rows(0).BeginEdit()      table.Rows(0)(0) = 100
                                dt.Rows(iUnfilledRow - 1).Item(strColName_DeviceID) = iDevice_ID
                                dt.Rows(iUnfilledRow - 1).Item(strColName_ModelID) = iModel_ID
                                dt.Rows(iUnfilledRow - 1).Item(strColName_WOID) = iWO_ID
                                dt.Rows(iUnfilledRow - 1).AcceptChanges()
                                Me.tdgData1.DataSource = dt
                                tmpDT.ImportRow(dt.Rows(iUnfilledRow - 1)) 'import this row
                            End If
                            Me._strSN2 = strSN
                        Else
                            Row = dt.NewRow
                            Row(strColName) = strSN
                            Row(strColName_DeviceID) = iDevice_ID
                            Row(strColName_ModelID) = iModel_ID
                            Row(strColName_WOID) = iWO_ID
                            dt.Rows.Add(Row) 'add
                            tmpDT.ImportRow(Row) 'import this row
                            Me.tdgData1.DataSource = dt
                            Me._strSN1 = strSN
                        End If
                    End If

                    Me.ComputeBoxFulfilledBundleNumber()

                    'Check the bundle is fulfilled---------------------------------------------------------------------------------------------
                    iQtyAfter = CInt(Me.lblQty.Text)
                    If iQtyAfter > iQtyBefore Then 'Bundle is fulfilled now, so update it
                        iBundleCount = Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount")
                        strArrLstDeviceIDs.Clear()
                        For i = 1 To iBundleCount 'each SN
                            iDevice_ID = tmpDT.Rows(0).Item("DeviceID_" & i.ToString)
                            strArrLstDeviceIDs.Add(iDevice_ID)
                        Next

                        'Get current Date time
                        If IsDate(Generic.MySQLServerDateTime) Then
                            DTime = Generic.MySQLServerDateTime
                            strDateTime = Format(DTime, "yyyy-MM-dd HH:mm:ss")
                        Else
                            strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        End If

                        'Update devices of the bundle in database
                        iDeviceSeqCnt = iDevice_ID = tmpDT.Rows(0).Item("ID")
                        iOverPackID = Me.lstBoxName.SelectedValue
                        If Not iOverPackID > 0 Then
                            MessageBox.Show("Invalid Overpack ID.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                        iShip_ID = Me._objSkullcandyRec.Astro_ProdShip_CreateShipID(PSS.Core.ApplicationUser.User, strDateTime, Me._objSkullcandy.PRODID, iOverPackID)
                        If Not iShip_ID > 0 Then
                            MessageBox.Show("Invalid Ship ID.", "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        Me._objSkullcandyRec.Astro_ProdShip_UpdateDevice(strArrLstDeviceIDs, iShip_ID, iDeviceSeqCnt, 5, "PRODUCTION COMPLETED", strErrMsg)
                        If strErrMsg.Trim.Length > 0 Then
                            MessageBox.Show("Failed to  update. See IT." & Environment.NewLine & strErrMsg, "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        'Print bundle SNs label after a bundle fulfilled
                        If Me.chkPrintSNsFulfilled.Checked Then
                            Me._ObjSkullcandyPrint.Print_AstroShipBoxSNLabel(Me._strSN1, Me._strSN2, 1)
                        End If
                        strArrLstSN.Clear()
                    End If
                    '------------------------------------------------------------------------------------------------------------------------

                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                Else
                    MessageBox.Show("Not a valid SN.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                End If

                Me.ComputeBoxFulfilledBundleNumber()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(tmpDT)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub GetUnfilledCell(ByRef iRowPosNo As Integer, ByRef strCol As String)
            Dim i, iRow, iBundleCount As Integer
            Dim strColName As String = "", strS As String = ""

            Try
                iBundleCount = Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount")
                iRowPosNo = 0 : strCol = ""
                For iRow = 0 To Me.tdgData1.RowCount - 1
                    For i = 1 To iBundleCount
                        strColName = Me._strColPrefix & i.ToString
                        If IsDBNull(Me.tdgData1.Columns(strColName).CellText(iRow)) Then  ' Not work if using: IsDBNull or IsNothing(Me.tdgData1.Columns(strColName).CellValue(iRow)) Then
                            iRowPosNo = iRow + 1 : strCol = strColName
                            Exit Sub
                        Else
                            strS = Me.tdgData1.Columns(strColName).CellText(iRow) 'Me.tdgData1.Columns(strColName).CellValue(iRow)
                            If Not strS.Trim.Length > 0 Then 'found nothing
                                iRowPosNo = iRow + 1 : strCol = strColName
                                Exit Sub
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GetUnfilledCell", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ComputeBoxFulfilledBundleNumber()
            Dim dt As DataTable, row As DataRow
            Dim iColNum, i

            Dim strColName, strS As String

            Try
                iColNum = Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount")
                dt = Me.tdgData1.DataSource

                For i = 1 To iColNum
                    strColName = Me._strColPrefix & i.ToString
                    For Each row In dt.Rows
                        If row.IsNull(strColName) Then 'not fulfilled, so not compute
                            Exit Sub
                        Else
                            strS = row(strColName)
                            If Not strS.Trim.Length > 0 Then
                                Exit Sub
                            End If
                        End If
                    Next
                Next

                Me.lblQty.Text = Me.tdgData1.RowCount

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ComputeBoxFulfilledBundleNumber", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Function DeviceBundleTableDefinition() As DataTable
            'Dynamimcally create table definiion
            Dim dt As New DataTable()
            Dim iMaxBundleNo As Integer, i As Integer = 0
            Dim row As DataRow

            Try
                iMaxBundleNo = Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount")

                dt.Columns.Add("ID", GetType(Integer)) 'seq no = ship bundle seq no
                For i = 1 To iMaxBundleNo
                    dt.Columns.Add(Me._strColPrefix & i.ToString, GetType(String))    'Serial No
                Next
                For i = 1 To iMaxBundleNo
                    dt.Columns.Add("ModelID_" & i.ToString, GetType(Integer))  'Model ID
                    dt.Columns.Add("DeviceID_" & i.ToString, GetType(Integer))  'Device ID
                    dt.Columns.Add("WOID_" & i.ToString, GetType(Integer))  'WO ID
                Next
                dt.Columns("ID").AutoIncrement = True
                dt.Columns("ID").AutoIncrementSeed = 1
                dt.Columns("ID").AutoIncrementStep = 1

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Private Sub CreateShipBundleTable()
            Dim idx As Integer = 0
            Dim dt As DataTable = DeviceBundleTableDefinition()
            Try
                If Not Me.cboBundle.SelectedValue > 0 Then Exit Sub

                Me.tdgData1.DataSource = dt
                Me.tdgData1.Splits(0).DisplayColumns("ID").Width = 20 'ID is index 0
                For idx = 1 To Me.tdgData1.Columns.Count - 1
                    If idx <= Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount") Then 'SN cols
                        Me.tdgData1.Splits(0).DisplayColumns(idx).Width = 150
                    Else 'Other cols, hide them
                        Me.tdgData1.Splits(0).DisplayColumns(idx).Width = 0
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateShipBundleTable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Try
                If MessageBox.Show("Do you want to reset?", "Information", MessageBoxButtons.YesNo, _
                                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    ResetControls()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReset_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ResetControls()
            Try
                Me.cboBundle.Enabled = True : Me.lstBoxName.Enabled = True
                Me.tdgData1.DataSource = Nothing : Me.lblQty.Text = 0
                LoadOpenBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ResetControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Function IsValidSN(ByVal strSN As String, ByVal iBundleID As Integer, ByRef strColName As String) As Boolean
            Dim dt As DataTable
            Dim row As DataRow
            Dim iLen As Integer = 0, iTotalLen As Integer = 0, i As Integer = 0
            Dim strS As String = "", strS2 As String = ""

            Try

                dt = Me._dsBundlesModels.Tables("ModelData")

                'Check null prefix
                i = 0
                For Each row In dt.Rows
                    If row("BundleID") = iBundleID Then
                        strS = row("Model_MotoSku")
                        If i = 0 Then
                            iTotalLen = strS.Trim.Length
                        Else
                            If iTotalLen <= strS.Trim.Length Then
                                iTotalLen = strS.Trim.Length
                            End If
                        End If
                        i += 1
                    End If
                Next

                If Not iTotalLen > 0 Then 'if no Model_MotoSku, i.e., no serial prefix in the bundle
                    Return False
                Else
                    i = 0 : strS = ""
                    For Each row In dt.Rows 'Check same length of prefix
                        If row("BundleID") = iBundleID Then
                            strS = row("Model_MotoSku")
                            If i = 0 Then
                                iLen = strS.Trim.Length
                            Else
                                If iLen <> strS.Trim.Length Then 'not same length
                                    Return False
                                End If
                            End If
                        End If
                    Next

                    'Check duplicate prefix
                    i = 0 : strS = "" : strS2 = ""
                    For Each row In dt.Rows 'Check same length of prefix
                        If row("BundleID") = iBundleID Then
                            If i = 0 Then
                                strS = row("Model_MotoSku")
                                strS = strS.Trim
                            Else
                                strS2 = row("Model_MotoSku")
                                strS2 = strS2.Trim
                                If strS.ToUpper = strS2.ToUpper Then 'Duplicate
                                    Return False
                                End If
                            End If
                        End If
                    Next

                    'Found it
                    i = 0 : strS = "" : strS2 = ""
                    For Each row In dt.Rows
                        If row("BundleID") = iBundleID Then
                            i += 1
                            strS = row("Model_MotoSku")
                            iLen = strS.Trim.Length
                            If strSN.Trim.Length < iLen Then 'No enough
                                Return False
                            Else
                                If strSN.Trim.Substring(0, iLen).ToUpper = strS.Trim.ToUpper Then
                                    strColName = Me._strColPrefix & i.ToString : Return True
                                End If
                            End If
                        End If
                    Next
                End If

                Return False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReset_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '***************************************************************************************
        Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            'Select a row, delete it
            Dim iRow, iBundleCount, iDevice_ID, i, j As Integer
            Dim dt As DataTable
            Dim row As DataRow
            Dim strArrLstDeviceIDs As New ArrayList()
            Dim strCol As String
            Dim strErrMsg As String = ""

            Try
                If Me.tdgData1.RowCount > 0 Then
                    If Me.tdgData1.SelectedRows.Count > 0 Then
                        If Me.tdgData1.SelectedRows.Count > 1 Then
                            MessageBox.Show("Please select a row to remove.", "btnDeleteRow_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If MessageBox.Show("Are you sure you want to remove this selected row?", "Information", MessageBoxButtons.YesNo, _
                                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                For Each iRow In Me.tdgData1.SelectedRows 'should be 1 row
                                    dt = Me.tdgData1.DataSource
                                    'MessageBox.Show("irow=" & iRow & "  " & dt.Rows.Count)

                                    'Update tdevice table for this bundle --------------------------------------------------------------
                                    iBundleCount = Me.cboBundle.DataSource.Table.select("BundleID= " & Me.cboBundle.SelectedValue)(0)("BundleCount")
                                    strArrLstDeviceIDs.Clear()
                                    For i = 1 To iBundleCount 'each SN
                                        strCol = "DeviceID_" & i.ToString
                                        If Not dt.Rows(iRow).IsNull(strCol) Then
                                            If CInt(dt.Rows(iRow).Item(strCol)) > 0 Then
                                                iDevice_ID = CInt(dt.Rows(iRow).Item(strCol))
                                                strArrLstDeviceIDs.Add(iDevice_ID)
                                            End If
                                        End If
                                    Next
                                    j = Me._objSkullcandyRec.Astro_ProdShip_UndoUpdateDevice(strArrLstDeviceIDs, strErrMsg)

                                    If Not strErrMsg.Trim.Length > 0 Then
                                        'Delete this bundle from the tdgData1 box----------------------------------------------------------
                                        'Just refresh box
                                        Me.LoadBoxSavedDeviceData(Me.lstBoxName.SelectedValue)

                                        'dt.Rows(iRow).Delete() : dt.AcceptChanges()
                                        'i = 0
                                        'For Each row In dt.Rows 'recreate ID after deleted
                                        '    i += 1
                                        '    row("ID") = i
                                        'Next
                                        'dt.AcceptChanges()
                                        'Me.tdgData1.Refresh()
                                        '' Me.tdgData1.DataSource = dt
                                        'Me.lblQty.Text = Me.tdgData1.RowCount
                                    Else
                                        MessageBox.Show(strErrMsg, "btnDeleteRow_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    End If

                                    Me.ComputeBoxFulfilledBundleNumber()
                                    Exit For
                                Next
                            End If
                        End If
                    Else
                        MessageBox.Show("Please select a row to remove.", "btnDeleteRow_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboBundle_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBundle.SelectedValueChanged
            Try
                If Me._bFirstStart Then Exit Sub
                LoadOpenBoxes()
                CreateShipBundleTable()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboBundle_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseShipBox.Click
            'Ship the box, close it, and print labels
            Dim dt As DataTable, tmpDT As DataTable
            Dim row As DataRow, col As DataColumn
            Dim strColName As String = "", strInvalidMsg As String = "", strS As String = "", strOverPackName As String = "", strErrMsg As String = ""
            Dim i As Integer = 0, iOverPackID As Integer = 0, iBundleCount As Integer = 0
            Dim strLabelProd, strLabelProdDesc, strLabelMasterCode As String
            Dim objProdShip As Data.Production.Shipping

            Try
                If IsNothing(Me.tdgData1.DataSource) Then Exit Sub
                dt = Me.tdgData1.DataSource
                If Not dt.Rows.Count > 0 Then Exit Sub

                If MessageBox.Show("Do you want to close the box now?", "Information", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then Exit Sub

                'Validate qty
                If Not dt.Rows.Count = CInt(Me.lblQty.Text) Then
                    MessageBox.Show("Qty is not equal to bundles in the box.", "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Check any unfilled cells or invalid numbers
                For Each col In dt.Columns
                    i = 0 : strColName = col.ColumnName
                    If col.DataType Is GetType(String) Then
                        For Each row In dt.Rows
                            i += 1
                            If row.IsNull(strColName) Then
                                strInvalidMsg &= "Bundle " & i.ToString & " " & strColName & Environment.NewLine
                            Else
                                strS = row(strColName)
                                If strS.Trim.Length = 0 Then
                                    strInvalidMsg &= "Bundle " & i.ToString & " " & strColName & Environment.NewLine
                                End If
                            End If
                        Next
                    ElseIf col.DataType Is GetType(Integer) Then
                        For Each row In dt.Rows
                            i += 1
                            If row.IsNull(strColName) Then
                                strInvalidMsg &= "Bundle " & i.ToString & " " & strColName & Environment.NewLine
                            Else
                                strS = row(strColName)
                                If Not CInt(row(strColName)) > 0 Then
                                    strInvalidMsg &= "Bundle " & i.ToString & " " & strColName & Environment.NewLine
                                End If
                            End If
                        Next
                    End If
                Next
                If strInvalidMsg.Trim.Length > 0 Then
                    MessageBox.Show("Unfilled or invalid data in following cell(s):" & Environment.NewLine & strInvalidMsg.Trim, "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False : Me.Cursor = Cursors.WaitCursor

                iOverPackID = Me.lstBoxName.SelectedValue
                '*************************************************
                'Bill Services
                '*************************************************
                If Me.BillServiceBillcodes(iOverPackID) = False Then Exit Sub
                '*************************************************

                'prepare extra data
                iBundleCount = Me.cboBundle.DataSource.Table.select("BundleID = " & Me.cboBundle.SelectedValue)(0)("BundleCount")

                i = Me._objSkullcandyRec.Astro_CloseAndShipOverPack(Me._iMenuCustID, iOverPackID, Core.ApplicationUser.IDShift, Me._iPalletShipType)

                strOverPackName = Me.lstBoxName.DataSource.Table.select("OverPack_ID = " & Me.lstBoxName.SelectedValue)(0)("OverPack_Name")
                'Print labels 
                If Me.chkPrintBoxLabel.Checked Then 'Box label (1" X 2")
                    tmpDT = Me._dsBundlesModels.Tables("ModelData").Copy
                    For Each row In tmpDT.Rows
                        If row("BundleID") = Me.cboBundle.SelectedValue Then
                            strLabelProd = row("Cust_Model_Desc")
                            strLabelProdDesc = row("Cust_IncomingDesc")
                            strLabelMasterCode = row("Cust_OutGoingDesc")
                            Me._ObjSkullcandyPrint.Print_AstroShipBoxMasterLabel(strLabelProd, strLabelProdDesc, strLabelMasterCode, _
                                                                                 strOverPackName, CInt(Me.lblQty.Text), 1)
                            Exit For
                        End If
                    Next
                    tmpDT = Nothing
                End If
                If Me.chkPrintPalletLabel.Checked Then 'Pallet Box Name label (1" X 2")
                    Me._ObjSkullcandyPrint.Print_AstroShipBoxLabel(strOverPackName, 1)
                End If
                If Me.chkPrintSNLabel.Checked Then 'Bundle label (1" X 2")
                    If iBundleCount > 2 Then 'Need to modify Crystal Report in order to print more than 2 SNs
                        MessageBox.Show("SN label can't be printed. See IT.", "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    For Each row In dt.Rows
                        Me._ObjSkullcandyPrint.Print_AstroShipBoxSNLabel(row(Me._strColPrefix & 1.ToString), row(Me._strColPrefix & 2.ToString), 1)
                    Next
                End If

                'Clear up
                ResetControls()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objProdShip = Nothing
                Generic.DisposeDT(dt) : Generic.DisposeDT(tmpDT)
                Me.Enabled = True : Me.Cursor = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCreateBoxName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxName.Click
            Dim iModel_ID As Integer = 0, iOverPackID As Integer
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

                'Ccreate Box pallet name
                iOverPackID = Me._objSkullcandyRec.Astro_CreateSkAstroOverPack(Skullcandy.ASTRO_CUSTOMERID, Skullcandy.ASTRO_LOCID, iModel_ID, Me._iPalletShipType, Me.cboBundle.Text)
                If Not iOverPackID > 0 Then
                    MessageBox.Show("Invalid Box ID.", " btnCreateBoxPalletName_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.LoadOpenBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateBoxName_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnStartBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartBox.Click
            Dim iMasterPackID As Integer = 0

            Try
                If Not Me.cboBundle.SelectedValue > 0 Then
                    MessageBox.Show("Please select a bundle.", "btnCreateBoxPalletName_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not Me.lstBoxName.SelectedValue > 0 Then
                    MessageBox.Show("Please select a box.", "btnCreateBoxPalletName_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                iMasterPackID = Me.lstBoxName.SelectedValue

                Me.LoadBoxSavedDeviceData(iMasterPackID)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lbtnStartBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Function BillServiceBillcodes(ByVal iOverPackID As Integer) As Boolean
            Dim bReturnVal As Boolean = False
            Dim dtDeviceIDs, dtModelIDs, dtReqServices, dtDevicesWithMasterPack, dtBilled As DataTable
            Dim R1, R2 As DataRow
            Dim objProdShipping As Data.Production.Shipping
            Dim ds As DataSet
            Dim objDevice As Rules.Device
            Dim i As Integer
            Dim strDateCodeStatus As String = ""
            Dim bRep As Boolean = False

            Try
                dtModelIDs = Me._objSkullcandyRec.Astro_GetModelIDsInOverPack(iOverPackID)
                objProdShipping = New Data.Production.Shipping()
                dtDeviceIDs = objProdShipping.GetDeviceSNsInOverPack(iOverPackID)

                If dtModelIDs.Rows.Count = 0 Then
                    MessageBox.Show("System can't find any model for this Box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtDeviceIDs.Rows.Count = 0 Then
                    MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    ds = New DataSet()
                    For Each R1 In dtModelIDs.Rows
                        'Get Service 
                        dtReqServices = Me._objSkullcandyRec.GetReqServiceBillcodes("ASTRO_SHIP_SERVICE_BILLCODES_" & R1("Model_ID"))
                        If dtReqServices.Rows.Count = 0 Then
                            MessageBox.Show("No billcode set up for model ID " & R1("Model_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Function
                        End If

                        'Check if model has sevice billcode map
                        If Me.HasServiceBillcodeMap(R1("Model_ID"), dtReqServices) = False Then Exit Function

                        dtReqServices.TableName = R1("Model_ID")
                        ds.Tables.Add(dtReqServices) : ds.AcceptChanges()
                    Next R1

                    'Check if any device is scrap
                    For Each R1 In dtDeviceIDs.Rows
                        If Data.Buisness.Generic.GetMaxBillRule(R1("Device_ID")) <> 0 Then
                            MessageBox.Show("Device serial # '" & R1("Device_SN") & "' is not a finished good unit. Please remove it from the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Function
                        End If
                    Next R1

                    'Bill service billcodes
                    For Each R1 In dtDeviceIDs.Rows
                        strDateCodeStatus = Me._objSkullcandy.Astro_GetModelRepairType(R1("Device_SN")).ToUpper
                        If strDateCodeStatus = "REPAIR" Then bRep = True
                        objDevice = New Rules.Device(R1("Device_ID"))

                        'Remove un-wanted service
                        dtBilled = Data.Buisness.DeviceBilling.GetBilledData(R1("Device_ID"))
                        For Each R2 In dtBilled.Rows
                            If ds.Tables(R1("Model_ID").ToString).Select("Billcode_ID = " & R2("BillCode_ID")).Length > 0 Then
                                'service in required list - keep it
                            ElseIf bRep = True AndAlso Convert.ToInt32(R2("BillCode_ID")) = Data.Buisness.Skullcandy.AstroServiceBillcode.Repair Then
                                'Date Code status need repair - Keep repair service
                            ElseIf Convert.ToInt32(R2("BillCode_ID")) = Data.Buisness.Skullcandy.AstroServiceBillcode.Masterpack Then
                                'Clean up Master pack later
                            Else
                                objDevice.DeletePart(R2("BillCode_ID"))
                            End If
                        Next R2

                        If bRep AndAlso Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), Data.Buisness.Skullcandy.AstroServiceBillcode.Repair) = False Then
                            objDevice.AddPart(Me._objSkullcandy.AstroServiceBillcode.Repair)
                        End If

                        For Each R2 In ds.Tables(R1("Model_ID").ToString).Rows
                            If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), R2("Billcode_ID")) = False Then objDevice.AddPart(R2("Billcode_ID"))
                        Next R2

                        objDevice.Update() : objDevice.Dispose() : objDevice = Nothing : strDateCodeStatus = "" : bRep = False
                    Next R1

                    'Get Masterpack service
                    dtDevicesWithMasterPack = Me._objSkullcandyRec.Astro_GetDeviceBillByOverPackAndBillcode(iOverPackID, Data.Buisness.Skullcandy.AstroServiceBillcode.Masterpack)
                    If dtDevicesWithMasterPack.Rows.Count = 0 Then
                        objDevice = New Rules.Device(dtDeviceIDs.Rows(0)("Device_ID"))
                        objDevice.AddPart(Data.Buisness.Skullcandy.AstroServiceBillcode.Masterpack)
                        objDevice.Update() : objDevice.Dispose() : objDevice = Nothing
                    ElseIf dtDevicesWithMasterPack.Rows.Count = 1 Then
                        'do nothing - box already has masterpack billcode
                    Else ' more than one masterpack therefore remove the extra
                        For i = 1 To dtDevicesWithMasterPack.Rows.Count - 1
                            objDevice = New Rules.Device(dtDevicesWithMasterPack.Rows(i)("Device_ID"))
                            objDevice.DeletePart(Data.Buisness.Skullcandy.AstroServiceBillcode.Masterpack)
                            objDevice.Update() : objDevice.Dispose() : objDevice = Nothing
                        Next i
                    End If

                    bReturnVal = True
                End If

                Return bReturnVal
            Catch ex As Exception
                BillServiceBillcodes = False
                MessageBox.Show(ex.ToString, "BillServiceBillcodes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objProdShipping = Nothing
                Data.Buisness.Generic.DisposeDT(dtModelIDs) : Data.Buisness.Generic.DisposeDT(dtDeviceIDs) : Data.Buisness.Generic.DisposeDT(dtReqServices)
                Data.Buisness.Generic.DisposeDS(ds)
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
            End Try
        End Function

        '***************************************************************************************
        Private Function HasServiceBillcodeMap(ByVal iModelID As Integer, ByVal dtReqServices As DataTable) As Boolean
            Dim booReturnVal As Boolean = True
            Dim R1 As DataRow

            Try
                For Each R1 In dtReqServices.Rows
                    If Generic.IsBillcodeMapped(iModelID, CInt(R1("Billcode_ID"))) = 0 Then
                        MessageBox.Show(R1("Billcode_Desc").ToString & " billcode is not map. Please contact Material.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    End If
                Next R1

                Return booReturnVal
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "HasServiceBillcodeMap", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Data.Buisness.Generic.DisposeDT(dtReqServices)
            End Try
        End Function

        '***************************************************************************************
        Private Sub btnRePrintLabels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRePrintLabels.Click
            Try
                Dim fm As New Gui.frmAstroReprint(Me._iMenuCustID, "Reprint Astro Production Shipment Labels")
                fm.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRePrintLabels_Clickp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReprintSN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintSN.Click
            Dim iRow As Integer
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim strSN1 As String = "", strSN2 As String = ""
            Try
                If Me.tdgData1.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgData1.SelectedRows
                        strSN1 = Me.tdgData1.Columns("SN_1").CellText(iRow)
                        strSN2 = Me.tdgData1.Columns("SN_2").CellText(iRow)
                        Me._ObjSkullcandyPrint.Print_AstroShipBoxSNLabel(strSN1, strSN2, 1)
                    Next
                Else
                    MessageBox.Show("You must select row(s) to re-print SN label(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************

    End Class
End Namespace