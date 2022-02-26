Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMobilio_PutAwayTote
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objMPutAway As Mobilio_PutAway_FinishedGoods
        Private _iToteID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objMPutAway = New Mobilio_PutAway_FinishedGoods()
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
        Friend WithEvents btnClearAll As System.Windows.Forms.Button
        Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents tpSortPutAwayItem As System.Windows.Forms.TabPage
        Friend WithEvents tpReadyToSortTotes As System.Windows.Forms.TabPage
        Friend WithEvents btnRTS_Refresh As System.Windows.Forms.Button
        Friend WithEvents chkCreateMasterPack As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cboReprintTypes As System.Windows.Forms.ComboBox
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents btnSortPutWay As System.Windows.Forms.Button
        Friend WithEvents txtReprintValue As System.Windows.Forms.TextBox
        Friend WithEvents lblReprintType As System.Windows.Forms.Label
        Friend WithEvents dbgRTS_Totes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblToteQty As System.Windows.Forms.Label
        Friend WithEvents dbgItemsInTote As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGetData As System.Windows.Forms.Button
        Friend WithEvents lblBoxPrinter As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMobilio_PutAwayTote))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpSortPutAwayItem = New System.Windows.Forms.TabPage()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblBoxPrinter = New System.Windows.Forms.Label()
            Me.btnSortPutWay = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.lblReprintType = New System.Windows.Forms.Label()
            Me.txtReprintValue = New System.Windows.Forms.TextBox()
            Me.cboReprintTypes = New System.Windows.Forms.ComboBox()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.chkCreateMasterPack = New System.Windows.Forms.CheckBox()
            Me.btnGetData = New System.Windows.Forms.Button()
            Me.lblToteQty = New System.Windows.Forms.Label()
            Me.btnClearAll = New System.Windows.Forms.Button()
            Me.txtDeviceID = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dbgItemsInTote = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.tpReadyToSortTotes = New System.Windows.Forms.TabPage()
            Me.btnRTS_Refresh = New System.Windows.Forms.Button()
            Me.dbgRTS_Totes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1.SuspendLayout()
            Me.tpSortPutAwayItem.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dbgItemsInTote, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpReadyToSortTotes.SuspendLayout()
            CType(Me.dbgRTS_Totes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpSortPutAwayItem, Me.tpReadyToSortTotes})
            Me.TabControl1.Location = New System.Drawing.Point(16, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(808, 504)
            Me.TabControl1.TabIndex = 114
            '
            'tpSortPutAwayItem
            '
            Me.tpSortPutAwayItem.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpSortPutAwayItem.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblBoxPrinter, Me.btnSortPutWay, Me.GroupBox1, Me.chkCreateMasterPack, Me.btnGetData, Me.lblToteQty, Me.btnClearAll, Me.txtDeviceID, Me.Label5, Me.dbgItemsInTote, Me.Label8})
            Me.tpSortPutAwayItem.Location = New System.Drawing.Point(4, 22)
            Me.tpSortPutAwayItem.Name = "tpSortPutAwayItem"
            Me.tpSortPutAwayItem.Size = New System.Drawing.Size(800, 478)
            Me.tpSortPutAwayItem.TabIndex = 0
            Me.tpSortPutAwayItem.Text = "Sort Put Away Items"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(0, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 21)
            Me.Label1.TabIndex = 105
            Me.Label1.Text = "Box Printer Name: "
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxPrinter
            '
            Me.lblBoxPrinter.BackColor = System.Drawing.Color.White
            Me.lblBoxPrinter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxPrinter.ForeColor = System.Drawing.Color.Black
            Me.lblBoxPrinter.Location = New System.Drawing.Point(120, 8)
            Me.lblBoxPrinter.Name = "lblBoxPrinter"
            Me.lblBoxPrinter.Size = New System.Drawing.Size(216, 21)
            Me.lblBoxPrinter.TabIndex = 104
            Me.lblBoxPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnSortPutWay
            '
            Me.btnSortPutWay.BackColor = System.Drawing.Color.DarkGreen
            Me.btnSortPutWay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSortPutWay.ForeColor = System.Drawing.Color.White
            Me.btnSortPutWay.Location = New System.Drawing.Point(120, 112)
            Me.btnSortPutWay.Name = "btnSortPutWay"
            Me.btnSortPutWay.Size = New System.Drawing.Size(216, 21)
            Me.btnSortPutWay.TabIndex = 103
            Me.btnSortPutWay.TabStop = False
            Me.btnSortPutWay.Text = "Sort Put Way Items in Tote"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblReprintType, Me.txtReprintValue, Me.cboReprintTypes, Me.btnReprint})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(424, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(360, 112)
            Me.GroupBox1.TabIndex = 102
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Reprint"
            '
            'lblReprintType
            '
            Me.lblReprintType.BackColor = System.Drawing.Color.Transparent
            Me.lblReprintType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReprintType.ForeColor = System.Drawing.Color.Black
            Me.lblReprintType.Location = New System.Drawing.Point(16, 56)
            Me.lblReprintType.Name = "lblReprintType"
            Me.lblReprintType.Size = New System.Drawing.Size(328, 16)
            Me.lblReprintType.TabIndex = 86
            Me.lblReprintType.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtReprintValue
            '
            Me.txtReprintValue.BackColor = System.Drawing.Color.White
            Me.txtReprintValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtReprintValue.Location = New System.Drawing.Point(16, 72)
            Me.txtReprintValue.MaxLength = 25
            Me.txtReprintValue.Name = "txtReprintValue"
            Me.txtReprintValue.Size = New System.Drawing.Size(216, 21)
            Me.txtReprintValue.TabIndex = 1
            Me.txtReprintValue.Text = ""
            '
            'cboReprintTypes
            '
            Me.cboReprintTypes.Items.AddRange(New Object() {"Master Pack Box Label", "Master Pack Manifiest", "Tote Manifest"})
            Me.cboReprintTypes.Location = New System.Drawing.Point(16, 24)
            Me.cboReprintTypes.Name = "cboReprintTypes"
            Me.cboReprintTypes.Size = New System.Drawing.Size(328, 21)
            Me.cboReprintTypes.TabIndex = 0
            '
            'btnReprint
            '
            Me.btnReprint.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.White
            Me.btnReprint.Location = New System.Drawing.Point(248, 72)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(96, 23)
            Me.btnReprint.TabIndex = 2
            Me.btnReprint.Text = "Go"
            '
            'chkCreateMasterPack
            '
            Me.chkCreateMasterPack.Enabled = False
            Me.chkCreateMasterPack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCreateMasterPack.ForeColor = System.Drawing.Color.Black
            Me.chkCreateMasterPack.Location = New System.Drawing.Point(192, 80)
            Me.chkCreateMasterPack.Name = "chkCreateMasterPack"
            Me.chkCreateMasterPack.Size = New System.Drawing.Size(144, 13)
            Me.chkCreateMasterPack.TabIndex = 98
            Me.chkCreateMasterPack.TabStop = False
            Me.chkCreateMasterPack.Text = "Create Master Pack"
            '
            'btnGetData
            '
            Me.btnGetData.BackColor = System.Drawing.Color.DarkGreen
            Me.btnGetData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetData.ForeColor = System.Drawing.Color.White
            Me.btnGetData.Location = New System.Drawing.Point(344, 40)
            Me.btnGetData.Name = "btnGetData"
            Me.btnGetData.Size = New System.Drawing.Size(72, 21)
            Me.btnGetData.TabIndex = 7
            Me.btnGetData.TabStop = False
            Me.btnGetData.Text = "Get Data"
            '
            'lblToteQty
            '
            Me.lblToteQty.BackColor = System.Drawing.Color.White
            Me.lblToteQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblToteQty.ForeColor = System.Drawing.Color.Black
            Me.lblToteQty.Location = New System.Drawing.Point(120, 72)
            Me.lblToteQty.Name = "lblToteQty"
            Me.lblToteQty.Size = New System.Drawing.Size(56, 21)
            Me.lblToteQty.TabIndex = 97
            Me.lblToteQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnClearAll
            '
            Me.btnClearAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClearAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAll.ForeColor = System.Drawing.Color.White
            Me.btnClearAll.Location = New System.Drawing.Point(344, 72)
            Me.btnClearAll.Name = "btnClearAll"
            Me.btnClearAll.Size = New System.Drawing.Size(72, 23)
            Me.btnClearAll.TabIndex = 8
            Me.btnClearAll.TabStop = False
            Me.btnClearAll.Text = "Clear All"
            '
            'txtDeviceID
            '
            Me.txtDeviceID.BackColor = System.Drawing.Color.White
            Me.txtDeviceID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceID.Location = New System.Drawing.Point(120, 40)
            Me.txtDeviceID.MaxLength = 25
            Me.txtDeviceID.Name = "txtDeviceID"
            Me.txtDeviceID.Size = New System.Drawing.Size(216, 21)
            Me.txtDeviceID.TabIndex = 0
            Me.txtDeviceID.Text = ""
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(32, 40)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(80, 21)
            Me.Label5.TabIndex = 85
            Me.Label5.Text = "Device ID:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgItemsInTote
            '
            Me.dbgItemsInTote.AllowUpdate = False
            Me.dbgItemsInTote.AlternatingRows = True
            Me.dbgItemsInTote.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgItemsInTote.FilterBar = True
            Me.dbgItemsInTote.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgItemsInTote.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgItemsInTote.Location = New System.Drawing.Point(8, 144)
            Me.dbgItemsInTote.Name = "dbgItemsInTote"
            Me.dbgItemsInTote.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgItemsInTote.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgItemsInTote.PreviewInfo.ZoomFactor = 75
            Me.dbgItemsInTote.Size = New System.Drawing.Size(776, 304)
            Me.dbgItemsInTote.TabIndex = 8
            Me.dbgItemsInTote.TabStop = False
            Me.dbgItemsInTote.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "00</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 772, 300<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 772, 300</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(48, 72)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 21)
            Me.Label8.TabIndex = 96
            Me.Label8.Text = "Tote Qty : "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tpReadyToSortTotes
            '
            Me.tpReadyToSortTotes.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpReadyToSortTotes.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRTS_Refresh, Me.dbgRTS_Totes})
            Me.tpReadyToSortTotes.Location = New System.Drawing.Point(4, 22)
            Me.tpReadyToSortTotes.Name = "tpReadyToSortTotes"
            Me.tpReadyToSortTotes.Size = New System.Drawing.Size(800, 478)
            Me.tpReadyToSortTotes.TabIndex = 1
            Me.tpReadyToSortTotes.Text = "Ready To Sort Totes"
            Me.tpReadyToSortTotes.Visible = False
            '
            'btnRTS_Refresh
            '
            Me.btnRTS_Refresh.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRTS_Refresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRTS_Refresh.ForeColor = System.Drawing.Color.White
            Me.btnRTS_Refresh.Location = New System.Drawing.Point(8, 16)
            Me.btnRTS_Refresh.Name = "btnRTS_Refresh"
            Me.btnRTS_Refresh.Size = New System.Drawing.Size(128, 23)
            Me.btnRTS_Refresh.TabIndex = 114
            Me.btnRTS_Refresh.Text = "Refresh List"
            '
            'dbgRTS_Totes
            '
            Me.dbgRTS_Totes.AllowUpdate = False
            Me.dbgRTS_Totes.AlternatingRows = True
            Me.dbgRTS_Totes.FilterBar = True
            Me.dbgRTS_Totes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRTS_Totes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgRTS_Totes.Location = New System.Drawing.Point(8, 64)
            Me.dbgRTS_Totes.Name = "dbgRTS_Totes"
            Me.dbgRTS_Totes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRTS_Totes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRTS_Totes.PreviewInfo.ZoomFactor = 75
            Me.dbgRTS_Totes.Size = New System.Drawing.Size(720, 344)
            Me.dbgRTS_Totes.TabIndex = 5
            Me.dbgRTS_Totes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "40</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 716, 340<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 716, 340</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmMobilio_PutAwayTote
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(840, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmMobilio_PutAwayTote"
            Me.Text = "frmMobilio_PutAwayTote"
            Me.TabControl1.ResumeLayout(False)
            Me.tpSortPutAwayItem.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dbgItemsInTote, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpReadyToSortTotes.ResumeLayout(False)
            CType(Me.dbgRTS_Totes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "To Be Sort Totes"

        '***********************************************************************************************************************************
        Private Sub tpReadyToSortTotes_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpReadyToSortTotes.VisibleChanged
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If tpReadyToSortTotes.Visible = True Then LoadOpenToSortTotes()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpOpenTotes_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnRTS_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRTS_Refresh.Click
            Try
                LoadOpenToSortTotes()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRTS_Refresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadOpenToSortTotes()
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dt = Me._objMPutAway.GetOpenToSortTotes()
                With Me.dbgRTS_Totes
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                End With
            Catch ex As Exception
                Throw ex
            Finally
                dbgc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************

#End Region

        '***********************************************************************************************************************************
        Private Sub frmMobilio_PutAwayTote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                '*******************************
                'WILL REMOVE THIS IN FUTURE
                '*******************************
                Me.chkCreateMasterPack.Checked = True
                '*******************************

                Me.lblBoxPrinter.Text = Generic.GetPrinterName("MOBILIO_MASTER_PACK")

                Me.txtDeviceID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnR_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
            Try
                If Me.txtDeviceID.Text.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    ProcessDeviceID()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnR_GetData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub txtDeviceID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceID.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtDeviceID.Text.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor : ProcessDeviceID()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtDeviceID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Function ProcessDeviceID() As Boolean
            Dim booRetVal As Boolean = False
            Dim dt As DataTable
            Dim i As Integer = 0, iToteID As Integer
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim objRec As New MobilioRec()

            Try
                Me.dbgItemsInTote.DataSource = Nothing

                dt = Me._objMPutAway.GetDeviceByDeviceID(Me.txtDeviceID.Text)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Device ID does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate device ID. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf IsDBNull(dt.Rows(0)("ReceivedDate")) Then
                    MessageBox.Show("Device has not been through item receive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("mb_Tote_ID")) = 0 Then
                    MessageBox.Show("Device does not belong to any tote.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("mb_MP_ID")) > 0 Then
                    MessageBox.Show("Device has master pack. Can't process here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("PutAway_Location").ToString.Trim.Length > 0 Then
                    MessageBox.Show("Device has put away location. Can't process here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ShippedDate")) Then
                    MessageBox.Show("Device has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iToteID = dt.Rows(0)("mb_Tote_ID")
                    dt = objRec.GetToteInfo(iToteID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Tote ID is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate tote. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf CInt(dt.Rows(0)("Closed")) = 0 Then
                        MessageBox.Show("Tote is not closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("CompletedSortDate")) Then
                        MessageBox.Show("Tote is already sorted to put away location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        booRetVal = True : Me.txtDeviceID.Enabled = False
                        Me._iToteID = iToteID
                        dt = Me._objMPutAway.GetItemsInTote(iToteID)
                        With Me.dbgItemsInTote
                            .DataSource = dt.DefaultView()
                            For Each dbgc In .Splits(0).DisplayColumns
                                dbgc.Locked = True
                                dbgc.AutoSize()
                            Next dbgc

                            For i = 0 To .Columns.Count - 1
                                Select Case .Columns(i).Caption
                                    Case "mb_MP_ID", "mb_OrderID_Outbound", "ShippedDate", "action_id", "response_action_id", "discrepancyflag"
                                        .Splits(0).DisplayColumns(i).Visible = False
                                End Select
                            Next i
                        End With

                        Me.lblToteQty.Text = dt.Rows.Count
                    End If
                End If

                Return booRetVal
            Catch ex As Exception
                Throw ex
            Finally
                dbgc = Nothing : Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub btnSortPutWay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSortPutWay.Click
            Dim i As Integer = 0
            Dim strPutAwayLoc As String = "A"

            Try
                If ProcessDeviceID() = False Then
                    Exit Sub
                ElseIf _iToteID = 0 Then
                    MessageBox.Show("Can't define tote id.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lblBoxPrinter.Text.Trim.Length = 0 Then
                    MessageBox.Show("Printer name for box label does not existed in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    '1: Run billing function
                    If Me.RunBilling(_iToteID) = False Then Exit Sub

                    '2: Save data
                    i = Me._objMPutAway.SortCompleted(strPutAwayLoc, Me._iToteID, CInt(Me.lblToteQty.Text), Core.ApplicationUser.IDuser, Me.chkCreateMasterPack.Checked, Me.lblBoxPrinter.Text.Trim)
                    If i > 0 Then
                        Me.btnClearAll_Click(Nothing, Nothing)
                    Else
                        MessageBox.Show("System has failed to save sort data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSortPutWay_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Public Function RunBilling(ByVal iToteID As Integer) As Boolean
            Dim dtFees, dtItems As DataTable
            Dim R1, drFee As DataRow
            Dim strNeededFeeIDs As String = ""
            Dim booRetVal As Boolean = False
            Dim i As Integer = 0
            
            Try
                dtFees = Me._objMPutAway.GetServiceFees()
                dtItems = Me._objMPutAway.GetItemsInTote(iToteID)

                If dtItems.Rows.Count = 0 Then
                    MessageBox.Show("Tote is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtItems.Select("mb_MP_ID > 0").Length > 0 Then
                    MessageBox.Show(dtItems.Select("mb_MP_ID > 0").Length & " items in tote have master pack id. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtItems.Select("mb_OrderID_Outbound > 0").Length > 0 Then
                    MessageBox.Show(dtItems.Select("mb_MP_ID > 0").Length & " items in tote have outbound order. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtItems.Select("Disposition = 'hold' ").Length > 0 Then
                    MessageBox.Show(dtItems.Select("Disposition = 'hold'").Length & " items are on hold. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtFees.Rows.Count = 0 Then
                    MessageBox.Show("No service fee available. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    For Each R1 In dtItems.Rows
                        Select Case R1("Disposition").ToString.ToLower
                            Case "process", "return"
                                '1: Receive/Audit RMA
                                If dtFees.Select("fee_desc = 'Receive/Audit RMA'").Length = 0 Then Throw New Exception("Service 'Receive/Audit RMA' is missing.")
                                drFee = dtFees.Select("fee_desc = 'Receive/Audit RMA'")(0)
                                If AddServiceFee(drFee, CInt(R1("Device ID")), strNeededFeeIDs) = False Then Exit Function

                                '2: Triage and Wipe
                                If R1("Disposition").ToString.ToLower = "process" Then
                                    If dtFees.Select("fee_desc = 'Triage and Wipe'").Length = 0 Then Throw New Exception("Service 'Triage and Wipe' is missing.")
                                    drFee = dtFees.Select("fee_desc = 'Triage and Wipe'")(0)
                                    If AddServiceFee(drFee, CInt(R1("Device ID")), strNeededFeeIDs) = False Then Exit Function
                                End If

                                '3: Discrepancy Processing
                                If CInt(R1("discrepancyflag")) = 1 OrElse CInt(R1("discrepancyflag")) > 0 Then
                                    If dtFees.Select("fee_desc = 'Discrepancy Processing'").Length = 0 Then Throw New Exception("Service 'Discrepancy Processing' is missing.")
                                    drFee = dtFees.Select("fee_desc = 'Discrepancy Processing'")(0)
                                    If AddServiceFee(drFee, CInt(R1("Device ID")), strNeededFeeIDs) = False Then Exit Function
                                End If

                                '4: Remove unwanted services
                                i = Me._objMPutAway.RemoveUnWantedServiceFees(CInt(R1("Device ID")), strNeededFeeIDs)

                                booRetVal = True
                            Case Else
                                Throw New Exception("System can't define service billing for disposition '" & R1("Disposition").ToString & "' on device id " & R1("Device ID").ToString)
                        End Select
                    Next R1
                End If

                Return booRetVal
            Catch ex As Exception
                Throw New Exception("RunBilling(): " & ex.Message)
            Finally
                Generic.DisposeDT(dtFees) : Generic.DisposeDT(dtItems)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Shared Function AddServiceFee(ByVal drFee As DataRow, ByVal imb_DeviceID As Integer, ByRef strNeededFeeIDs As String) As Boolean
            Dim iFeeID As Integer = 0, i As Integer = 0
            Dim dbFeePrice As Double = 0
            Dim objMPutAway As New Mobilio_PutAway_FinishedGoods()

            Try
                AddServiceFee = False
                iFeeID = drFee("mb_fee_id") : dbFeePrice = drFee("fee_price")

                If objMPutAway.IsServiceFeeExisted(imb_DeviceID, iFeeID) = False Then
                    i = objMPutAway.AddServiceFee(imb_DeviceID, iFeeID, dbFeePrice, Core.ApplicationUser.IDuser)
                    If i = 0 Then Throw New Exception("System has failed to add '" & drFee("fee_desc").ToString & "'.")
                End If

                If strNeededFeeIDs.Trim.Length > 0 Then strNeededFeeIDs &= ", "
                strNeededFeeIDs &= iFeeID

                AddServiceFee = True
            Catch ex As Exception
                Throw New Exception("frmMobilio_PutAwayTote.AddServiceFee(): " & ex.Message)
            Finally
                objMPutAway = Nothing
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
            Try
                Me.txtDeviceID.Text = "" : Me.txtDeviceID.Enabled = True
                Me.lblToteQty.Text = ""
                ''*******************************
                ''WILL UNCOMMENT THIS IN FUTURE
                ''*******************************
                ' Me.chkCreateMasterPack.Checked = False
                ''*******************************
                Me.dbgItemsInTote.DataSource = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClearAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub cboReprintTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReprintTypes.SelectedIndexChanged
            Try
                Me.txtReprintValue.Text = ""
                Select Case Me.cboReprintTypes.Text
                    Case "Master Pack Box Label", "Master Pack Manifiest"
                        Me.lblReprintType.Text = "Master Pack ID"
                    Case "Tote Manifest"
                        Me.lblReprintType.Text = "Tote ID"
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReprintTypes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            Dim iInputVal As Integer

            Try
                If Me.cboReprintTypes.SelectedValue < 0 Then
                    Exit Sub
                ElseIf Me.txtReprintValue.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter " & Me.lblReprintType.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtReprintValue.SelectAll() : Me.txtReprintValue.Focus()
                Else
                    iInputVal = CInt(Me.txtReprintValue.Text)

                    Select Case Me.cboReprintTypes.Text
                        Case "Master Pack Box Label"
                            If Me.lblBoxPrinter.Text.Trim.Length = 0 Then Throw New Exception("Printer name for box label does not existed in database.")
                            Me._objMPutAway.PrintMasterPackBoxLabel(iInputVal, Me.lblBoxPrinter.Text.Trim)
                        Case "Master Pack Manifiest"
                            Me._objMPutAway.PrintMasterPackManifest(iInputVal)
                        Case "Tote Manifest"
                            Me._objMPutAway.PrintToteManifest(iInputVal)
                    End Select

                    Me.txtReprintValue.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReprintTypes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '***********************************************************************************************************************************


    End Class
End Namespace