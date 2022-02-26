Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmSCandyPalletRec
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer
        Private _objSkullcandy As Skullcandy
        Private _objSkullcandyRec As SkullcandyRec
        Private _dtPeriod1 As Integer = 7 '7 days
        Private _dtPeriod2 As Integer = 0 'current day

        Private _dbgRecData As C1.Win.C1TrueDBGrid.C1TrueDBGrid

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCustID
            Me._objSkullcandy = New Skullcandy()
            Me._objSkullcandyRec = New SkullcandyRec()
            Me.lblTitle.Text = strScreenName

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
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents btnClosePallet As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents grpBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblModels As System.Windows.Forms.Label
        Friend WithEvents lblWorkOrder As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents cboPalletName As C1.Win.C1List.C1Combo
        Friend WithEvents btnCreatePallet As System.Windows.Forms.Button
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents txtTotalQty As System.Windows.Forms.TextBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnDeleteRow As System.Windows.Forms.Button
        Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
        Friend WithEvents pnlReprintPallet As System.Windows.Forms.Panel
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnGetPalletNames As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReprintPallet As System.Windows.Forms.Button
        Friend WithEvents btnPrintSelectedPallet As System.Windows.Forms.Button
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents btnAddRetailer As System.Windows.Forms.Button
        Friend WithEvents lblRetailer As System.Windows.Forms.Label
        Friend WithEvents cboRetailer As C1.Win.C1List.C1Combo
        Friend WithEvents btnRetailerInactive As System.Windows.Forms.Button
        Friend WithEvents dtpStartDate2 As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate2 As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents pnlDataView As System.Windows.Forms.Panel
        Friend WithEvents lblRMA As System.Windows.Forms.Label
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSCandyPalletRec))
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.btnClosePallet = New System.Windows.Forms.Button()
            Me.btnDeleteRow = New System.Windows.Forms.Button()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.txtTotalQty = New System.Windows.Forms.TextBox()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.grpBox1 = New System.Windows.Forms.GroupBox()
            Me.lblRetailer = New System.Windows.Forms.Label()
            Me.cboRetailer = New C1.Win.C1List.C1Combo()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblModels = New System.Windows.Forms.Label()
            Me.lblWorkOrder = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.cboPalletName = New C1.Win.C1List.C1Combo()
            Me.btnCreatePallet = New System.Windows.Forms.Button()
            Me.btnRetailerInactive = New System.Windows.Forms.Button()
            Me.btnAddRetailer = New System.Windows.Forms.Button()
            Me.chkPrint = New System.Windows.Forms.CheckBox()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.btnReprintPallet = New System.Windows.Forms.Button()
            Me.pnlReprintPallet = New System.Windows.Forms.Panel()
            Me.btnPrintSelectedPallet = New System.Windows.Forms.Button()
            Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnGetPalletNames = New System.Windows.Forms.Button()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.dtpStartDate2 = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dtpEndDate2 = New System.Windows.Forms.DateTimePicker()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.pnlDataView = New System.Windows.Forms.Panel()
            Me.lblRMA = New System.Windows.Forms.Label()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpBox1.SuspendLayout()
            CType(Me.cboRetailer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPalletName, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlReprintPallet.SuspendLayout()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDataView.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.AutoCompletion = True
            Me.cboCustomer.AutoDropDown = True
            Me.cboCustomer.AutoSelect = True
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ColumnHeaders = False
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(128, 40)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(272, 21)
            Me.cboCustomer.TabIndex = 2
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'tdgData1
            '
            Me.tdgData1.AllowColMove = False
            Me.tdgData1.AllowColSelect = False
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.White
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.Caption = "List of Received Items"
            Me.tdgData1.CaptionHeight = 15
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(16, 56)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(456, 376)
            Me.tdgData1.TabIndex = 7
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;ForeColor:OliveDrab;BackColor:Gainsboro;}Style1{}Normal{Fo" & _
            "nt:Microsoft Sans Serif, 9pt;}HighlightRow{ForeColor:HighlightText;BackColor:Hig" & _
            "hlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap" & _
            ":True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVer" & _
            "t:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</D" & _
            "ata></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowCo" & _
            "lSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>359</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 15, 454, 359</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 454, 374</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(56, 44)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(63, 23)
            Me.lblCustomer.TabIndex = 85
            Me.lblCustomer.Text = "Customer"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnClosePallet
            '
            Me.btnClosePallet.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClosePallet.ForeColor = System.Drawing.Color.Red
            Me.btnClosePallet.Location = New System.Drawing.Point(344, 256)
            Me.btnClosePallet.Name = "btnClosePallet"
            Me.btnClosePallet.Size = New System.Drawing.Size(56, 24)
            Me.btnClosePallet.TabIndex = 8
            Me.btnClosePallet.Text = "Close Pallet"
            '
            'btnDeleteRow
            '
            Me.btnDeleteRow.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnDeleteRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteRow.ForeColor = System.Drawing.Color.White
            Me.btnDeleteRow.Location = New System.Drawing.Point(16, 8)
            Me.btnDeleteRow.Name = "btnDeleteRow"
            Me.btnDeleteRow.Size = New System.Drawing.Size(72, 24)
            Me.btnDeleteRow.TabIndex = 11
            Me.btnDeleteRow.Text = "Remove"
            '
            'lblTotalQty
            '
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.Location = New System.Drawing.Point(336, 40)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(48, 16)
            Me.lblTotalQty.TabIndex = 90
            Me.lblTotalQty.Text = "Total:"
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTotalQty
            '
            Me.txtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTotalQty.Location = New System.Drawing.Point(392, 32)
            Me.txtTotalQty.Name = "txtTotalQty"
            Me.txtTotalQty.Size = New System.Drawing.Size(80, 26)
            Me.txtTotalQty.TabIndex = 89
            Me.txtTotalQty.Text = "0"
            Me.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(16, 32)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(72, 24)
            Me.btnRefresh.TabIndex = 10
            Me.btnRefresh.Text = "Refresh"
            '
            'grpBox1
            '
            Me.grpBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRetailer, Me.cboRetailer, Me.btnSave, Me.Label2, Me.lblModels, Me.lblWorkOrder, Me.txtQty, Me.cboModel, Me.cboPalletName, Me.btnCreatePallet, Me.btnRetailerInactive, Me.btnAddRetailer, Me.chkPrint})
            Me.grpBox1.Location = New System.Drawing.Point(16, 96)
            Me.grpBox1.Name = "grpBox1"
            Me.grpBox1.Size = New System.Drawing.Size(392, 144)
            Me.grpBox1.TabIndex = 92
            Me.grpBox1.TabStop = False
            '
            'lblRetailer
            '
            Me.lblRetailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRetailer.Location = New System.Drawing.Point(8, 16)
            Me.lblRetailer.Name = "lblRetailer"
            Me.lblRetailer.Size = New System.Drawing.Size(56, 24)
            Me.lblRetailer.TabIndex = 97
            Me.lblRetailer.Text = "Retailer"
            Me.lblRetailer.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboRetailer
            '
            Me.cboRetailer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRetailer.AutoCompletion = True
            Me.cboRetailer.AutoDropDown = True
            Me.cboRetailer.AutoSelect = True
            Me.cboRetailer.Caption = ""
            Me.cboRetailer.CaptionHeight = 17
            Me.cboRetailer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRetailer.ColumnCaptionHeight = 17
            Me.cboRetailer.ColumnFooterHeight = 17
            Me.cboRetailer.ColumnHeaders = False
            Me.cboRetailer.ContentHeight = 15
            Me.cboRetailer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRetailer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRetailer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRetailer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRetailer.EditorHeight = 15
            Me.cboRetailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRetailer.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboRetailer.ItemHeight = 15
            Me.cboRetailer.Location = New System.Drawing.Point(72, 16)
            Me.cboRetailer.MatchEntryTimeout = CType(2000, Long)
            Me.cboRetailer.MaxDropDownItems = CType(10, Short)
            Me.cboRetailer.MaxLength = 32767
            Me.cboRetailer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRetailer.Name = "cboRetailer"
            Me.cboRetailer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRetailer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRetailer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRetailer.Size = New System.Drawing.Size(200, 21)
            Me.cboRetailer.TabIndex = 96
            Me.cboRetailer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(256, 104)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(72, 32)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "Save"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(16, 80)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 24)
            Me.Label2.TabIndex = 95
            Me.Label2.Text = "Quantity"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblModels
            '
            Me.lblModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModels.Location = New System.Drawing.Point(24, 48)
            Me.lblModels.Name = "lblModels"
            Me.lblModels.Size = New System.Drawing.Size(40, 24)
            Me.lblModels.TabIndex = 94
            Me.lblModels.Text = "Model"
            Me.lblModels.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblWorkOrder
            '
            Me.lblWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkOrder.Location = New System.Drawing.Point(352, 80)
            Me.lblWorkOrder.Name = "lblWorkOrder"
            Me.lblWorkOrder.Size = New System.Drawing.Size(32, 16)
            Me.lblWorkOrder.TabIndex = 93
            Me.lblWorkOrder.Text = "Pallet Name"
            Me.lblWorkOrder.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtQty
            '
            Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.Location = New System.Drawing.Point(72, 80)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(72, 22)
            Me.txtQty.TabIndex = 6
            Me.txtQty.Text = "0"
            Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
            Me.cboModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(72, 48)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(200, 21)
            Me.cboModel.TabIndex = 5
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
            'cboPalletName
            '
            Me.cboPalletName.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPalletName.AutoCompletion = True
            Me.cboPalletName.AutoDropDown = True
            Me.cboPalletName.AutoSelect = True
            Me.cboPalletName.Caption = ""
            Me.cboPalletName.CaptionHeight = 17
            Me.cboPalletName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPalletName.ColumnCaptionHeight = 17
            Me.cboPalletName.ColumnFooterHeight = 17
            Me.cboPalletName.ColumnHeaders = False
            Me.cboPalletName.ContentHeight = 15
            Me.cboPalletName.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPalletName.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPalletName.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPalletName.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPalletName.EditorHeight = 15
            Me.cboPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPalletName.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboPalletName.ItemHeight = 15
            Me.cboPalletName.Location = New System.Drawing.Point(352, 48)
            Me.cboPalletName.MatchEntryTimeout = CType(2000, Long)
            Me.cboPalletName.MaxDropDownItems = CType(10, Short)
            Me.cboPalletName.MaxLength = 32767
            Me.cboPalletName.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPalletName.Name = "cboPalletName"
            Me.cboPalletName.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPalletName.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPalletName.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPalletName.Size = New System.Drawing.Size(32, 21)
            Me.cboPalletName.TabIndex = 4
            Me.cboPalletName.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnCreatePallet
            '
            Me.btnCreatePallet.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnCreatePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreatePallet.ForeColor = System.Drawing.Color.White
            Me.btnCreatePallet.Location = New System.Drawing.Point(344, 112)
            Me.btnCreatePallet.Name = "btnCreatePallet"
            Me.btnCreatePallet.Size = New System.Drawing.Size(32, 16)
            Me.btnCreatePallet.TabIndex = 3
            Me.btnCreatePallet.Text = "Create a pallet"
            '
            'btnRetailerInactive
            '
            Me.btnRetailerInactive.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnRetailerInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRetailerInactive.ForeColor = System.Drawing.Color.Aqua
            Me.btnRetailerInactive.Location = New System.Drawing.Point(280, 16)
            Me.btnRetailerInactive.Name = "btnRetailerInactive"
            Me.btnRetailerInactive.Size = New System.Drawing.Size(56, 24)
            Me.btnRetailerInactive.TabIndex = 97
            Me.btnRetailerInactive.Text = "Inactive"
            '
            'btnAddRetailer
            '
            Me.btnAddRetailer.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnAddRetailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddRetailer.ForeColor = System.Drawing.Color.Aquamarine
            Me.btnAddRetailer.Location = New System.Drawing.Point(344, 16)
            Me.btnAddRetailer.Name = "btnAddRetailer"
            Me.btnAddRetailer.Size = New System.Drawing.Size(40, 24)
            Me.btnAddRetailer.TabIndex = 96
            Me.btnAddRetailer.Text = "Add"
            '
            'chkPrint
            '
            Me.chkPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrint.ForeColor = System.Drawing.Color.MidnightBlue
            Me.chkPrint.Location = New System.Drawing.Point(184, 80)
            Me.chkPrint.Name = "chkPrint"
            Me.chkPrint.Size = New System.Drawing.Size(96, 24)
            Me.chkPrint.TabIndex = 94
            Me.chkPrint.Text = "Print Label"
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(408, 24)
            Me.lblTitle.TabIndex = 93
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnReprintPallet
            '
            Me.btnReprintPallet.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.btnReprintPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPallet.ForeColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPallet.Location = New System.Drawing.Point(16, 248)
            Me.btnReprintPallet.Name = "btnReprintPallet"
            Me.btnReprintPallet.Size = New System.Drawing.Size(128, 32)
            Me.btnReprintPallet.TabIndex = 9
            Me.btnReprintPallet.Text = "Reprint Label"
            '
            'pnlReprintPallet
            '
            Me.pnlReprintPallet.BackColor = System.Drawing.Color.Cornsilk
            Me.pnlReprintPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlReprintPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintSelectedPallet, Me.tdgData2, Me.btnClose, Me.btnGetPalletNames, Me.dtpEndDate, Me.dtpStartDate, Me.Label5, Me.Label9})
            Me.pnlReprintPallet.Location = New System.Drawing.Point(16, 296)
            Me.pnlReprintPallet.Name = "pnlReprintPallet"
            Me.pnlReprintPallet.Size = New System.Drawing.Size(408, 152)
            Me.pnlReprintPallet.TabIndex = 96
            '
            'btnPrintSelectedPallet
            '
            Me.btnPrintSelectedPallet.BackColor = System.Drawing.Color.NavajoWhite
            Me.btnPrintSelectedPallet.ForeColor = System.Drawing.Color.Green
            Me.btnPrintSelectedPallet.Location = New System.Drawing.Point(296, 8)
            Me.btnPrintSelectedPallet.Name = "btnPrintSelectedPallet"
            Me.btnPrintSelectedPallet.Size = New System.Drawing.Size(50, 32)
            Me.btnPrintSelectedPallet.TabIndex = 103
            Me.btnPrintSelectedPallet.Text = "Print"
            '
            'tdgData2
            '
            Me.tdgData2.AllowColMove = False
            Me.tdgData2.AllowColSelect = False
            Me.tdgData2.AllowUpdate = False
            Me.tdgData2.AlternatingRows = True
            Me.tdgData2.BackColor = System.Drawing.Color.White
            Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData2.Caption = "List of Closed Pallets"
            Me.tdgData2.CaptionHeight = 15
            Me.tdgData2.FetchRowStyles = True
            Me.tdgData2.FilterBar = True
            Me.tdgData2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.tdgData2.Location = New System.Drawing.Point(8, 72)
            Me.tdgData2.Name = "tdgData2"
            Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData2.PreviewInfo.ZoomFactor = 75
            Me.tdgData2.RowHeight = 15
            Me.tdgData2.Size = New System.Drawing.Size(384, 64)
            Me.tdgData2.TabIndex = 102
            Me.tdgData2.Text = "C1TrueDBGrid1"
            Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;ForeColor:OliveDrab;BackColor:Gainsboro;}Style9{}Normal{Fo" & _
            "nt:Microsoft Sans Serif, 9pt;}HighlightRow{ForeColor:HighlightText;BackColor:Hig" & _
            "hlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap" & _
            ":True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor" & _
            ":Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</D" & _
            "ata></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowCo" & _
            "lSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>47</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 15, 382, 47</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 382, 62</ClientArea><PrintPageHeaderStyle parent=""""" & _
            " me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.Color.NavajoWhite
            Me.btnClose.Location = New System.Drawing.Point(352, 8)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(48, 32)
            Me.btnClose.TabIndex = 101
            Me.btnClose.Text = "Close"
            '
            'btnGetPalletNames
            '
            Me.btnGetPalletNames.BackColor = System.Drawing.Color.NavajoWhite
            Me.btnGetPalletNames.Location = New System.Drawing.Point(208, 8)
            Me.btnGetPalletNames.Name = "btnGetPalletNames"
            Me.btnGetPalletNames.Size = New System.Drawing.Size(80, 32)
            Me.btnGetPalletNames.TabIndex = 100
            Me.btnGetPalletNames.Text = "Retrieve Data"
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 40)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpEndDate.TabIndex = 97
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(8, 40)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpStartDate.TabIndex = 96
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label5.Location = New System.Drawing.Point(8, 16)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 98
            Me.Label5.Text = "Start"
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label9.Location = New System.Drawing.Point(112, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 16)
            Me.Label9.TabIndex = 99
            Me.Label9.Text = "End"
            '
            'dtpStartDate2
            '
            Me.dtpStartDate2.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate2.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate2.Location = New System.Drawing.Point(96, 32)
            Me.dtpStartDate2.Name = "dtpStartDate2"
            Me.dtpStartDate2.Size = New System.Drawing.Size(104, 21)
            Me.dtpStartDate2.TabIndex = 99
            Me.dtpStartDate2.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label1.Location = New System.Drawing.Point(96, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 16)
            Me.Label1.TabIndex = 100
            Me.Label1.Text = "Start"
            '
            'dtpEndDate2
            '
            Me.dtpEndDate2.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate2.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate2.Location = New System.Drawing.Point(208, 32)
            Me.dtpEndDate2.Name = "dtpEndDate2"
            Me.dtpEndDate2.Size = New System.Drawing.Size(104, 21)
            Me.dtpEndDate2.TabIndex = 101
            Me.dtpEndDate2.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
            Me.Label3.Location = New System.Drawing.Point(208, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 16)
            Me.Label3.TabIndex = 102
            Me.Label3.Text = "End"
            '
            'pnlDataView
            '
            Me.pnlDataView.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpStartDate2, Me.txtTotalQty, Me.btnDeleteRow, Me.btnRefresh, Me.dtpEndDate2, Me.tdgData1, Me.lblTotalQty, Me.Label1, Me.Label3})
            Me.pnlDataView.Location = New System.Drawing.Point(416, 8)
            Me.pnlDataView.Name = "pnlDataView"
            Me.pnlDataView.Size = New System.Drawing.Size(480, 440)
            Me.pnlDataView.TabIndex = 103
            '
            'lblRMA
            '
            Me.lblRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMA.Location = New System.Drawing.Point(56, 72)
            Me.lblRMA.Name = "lblRMA"
            Me.lblRMA.Size = New System.Drawing.Size(64, 16)
            Me.lblRMA.TabIndex = 104
            Me.lblRMA.Text = "RMA/RA#"
            Me.lblRMA.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtRMA
            '
            Me.txtRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRMA.Location = New System.Drawing.Point(128, 64)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(264, 22)
            Me.txtRMA.TabIndex = 105
            Me.txtRMA.Text = ""
            '
            'frmSCandyPalletRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(4, 11)
            Me.BackColor = System.Drawing.Color.OldLace
            Me.ClientSize = New System.Drawing.Size(896, 494)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRMA, Me.lblRMA, Me.pnlDataView, Me.pnlReprintPallet, Me.btnClosePallet, Me.btnReprintPallet, Me.lblTitle, Me.lblCustomer, Me.cboCustomer, Me.grpBox1})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmSCandyPalletRec"
            Me.Text = "Pallet Receiving"
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpBox1.ResumeLayout(False)
            CType(Me.cboRetailer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPalletName, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlReprintPallet.ResumeLayout(False)
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDataView.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmSCandyPalletRec_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.pnlReprintPallet.Visible = False

                dt = _objSkullcandy.GetCustomer(_iMenuCustID)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_name1", "cust_ID")
                    Me.cboCustomer.SelectedValue = Me._iMenuCustID
                    Me.cboCustomer.Enabled = False
                    ' Me.cboCustomer.ReadOnly = True
                Else
                    Dim objCtrl As Control
                    For Each objCtrl In Me.Controls
                        objCtrl.Enabled = False
                    Next
                    MessageBox.Show("No customer!") : Exit Sub
                End If

                Me.txtTotalQty.ReadOnly = True
                Me.chkPrint.Checked = True
                'PopulateOpenPalletNameWO(0)
                With Me
                    .btnCreatePallet.Visible = False : .lblWorkOrder.Visible = False
                    .cboPalletName.Visible = False : .btnSave.Visible = False
                    '.btnRefresh.Visible = False : .btnDeleteRow.Visible = False
                    '.lblTotalQty.Visible = False : .txtTotalQty.Visible = False
                    '.tdgData1.Visible = False
                    .btnClosePallet.Visible = False
                End With

                Me.dtpStartDate.Value = Format(DateAdd(DateInterval.Day, -_dtPeriod1, Now), "yyyy-MM-dd")
                Me.dtpEndDate.Value = Format(Now, "yyyy-MM-dd")
                Me.dtpStartDate2.Value = Format(DateAdd(DateInterval.Day, -_dtPeriod2, Now), "yyyy-MM-dd")
                Me.dtpEndDate2.Value = Format(Now, "yyyy-MM-dd")

                'Load
                PopulateRetailerNames()
                PopulateModels()
                BindPalletDetailedData()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePallet.Click
            Dim strDateTime As String
            Dim DTime As Date
            Dim strPalletWOName As String
            Dim iWO_ID As Integer = 0
            Dim dt As DataTable

            'Try
            '    If IsDate(Generic.MySQLServerDateTime) Then
            '        DTime = Generic.MySQLServerDateTime
            '        strDateTime = Format(DTime, "yyyy-MM-dd HH:mm:ss")
            '        strPalletWOName = Me._objSkullcandy.PalletWO_Prefix & Format(DTime, "yyMMdd") & "N" & Format(DTime, "HHmmss")
            '    Else
            '        strPalletWOName = Me._objSkullcandy.PalletWO_Prefix & Format(Now, "yyMMdd") & "N" & Format(Now, "HHmmss")
            '    End If

            '    dt = Me._objSkullcandyRec.GetPalletWorkOrderData(Me._objSkullcandy.LOCID, strPalletWOName)

            '    If dt.Rows.Count > 0 Then
            '        MessageBox.Show("Pallet '" & strPalletWOName & " already exists. Can not create it.", "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Exit Sub
            '    End If

            '    btnCreatePallet.Enabled = False
            '    iWO_ID = Me._objSkullcandyRec.CreatePalletWO(Me._objSkullcandy.LOCID, Me._objSkullcandy.PRODID, Me._objSkullcandy.GROUPID, strDateTime, strPalletWOName)
            '    If Not iWO_ID > 0 Then
            '        MessageBox.Show("Failed to create.", "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Else
            '        PopulateOpenPalletNameWO(iWO_ID)
            '    End If

            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, " btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    btnCreatePallet.Enabled = True
            'End Try
        End Sub

        '******************************************************************
        Private Sub PopulateOpenPalletNameWO(ByVal iSelectedVal As Integer)
            Dim dt As DataTable
            Try
                Me.cboPalletName.Text = ""

                dt = Me._objSkullcandyRec.GetOpenPalletWOData(Me._objSkullcandy.LOCID, Me._objSkullcandy.PalletWO_Prefix)

                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboPalletName, dt, "WO_CustWO", "WO_ID")

                    If iSelectedVal > 0 Then
                        Me.cboPalletName.SelectedValue = iSelectedVal
                    Else
                        Me.cboPalletName.SelectedIndex = 0
                    End If

                Else
                    Me.cboPalletName.DataSource = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateOpenPalletNameWO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateRetailerNames()
            Dim dt As DataTable
            Try
                Me.cboRetailer.Text = ""

                dt = Me._objSkullcandyRec.GetRetailerNames

                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboRetailer, dt, "RetailerName", "WOR_ID")
                    Me.cboRetailer.SelectedIndex = 0
                Else
                    Me.cboRetailer.DataSource = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateRetailerNames", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '******************************************************************
        Private Sub PopulateModels()
            Dim dt As DataTable
            Dim strModelInclude As String

            Try
                strModelInclude = "'" & Me._objSkullcandy.ModelPrefixString.A50.ToString() & "','" & _
                                        Me._objSkullcandy.ModelPrefixString.A42.ToString() & "'"

                dt = Me._objSkullcandyRec.GetModelsData(Me._iMenuCustID, strModelInclude)

                If dt.Rows.Count > 0 Then
                    'Misc.PopulateC1DropDownList(Me.cboModel, dt, "ModelFullDesc", "Model_ID")
                    Misc.PopulateC1DropDownList(Me.cboModel, dt, "cust_IncomingSku", "Model_ID")
                    Me.cboModel.SelectedIndex = 0
                Else
                    Me.cboModel.DataSource = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
            Dim allowed As String = "0123456789"
            Dim curchar As Integer = Asc(e.KeyChar)

            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                e.Handled = True
            End If
        End Sub

        '******************************************************************
        Private Sub txtQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyUp

            Try
                If IsNumeric(Me.txtQty.Text) Then
                    Dim iNum As Integer = Me.txtQty.Text
                    If iNum > 0 Then
                        Me.txtQty.Text = iNum
                    Else
                        'MessageBox.Show("Please enter a valid quantity.", "txtQty_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtQty.Focus() : Me.txtQty.SelectAll() : Exit Sub
                    End If
                Else
                    'MessageBox.Show("Please enter a valid quantity.", "txtQty_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtQty.Focus() : Me.txtQty.SelectAll() : Exit Sub
                End If
                If e.KeyCode = Keys.Enter AndAlso txtQty.Text.Trim.Length > 0 Then
                    SaveData()
                End If

                '    If e.KeyCode = Keys.Enter AndAlso txtSN.Text.Trim.Length > 0 Then
                '        If Me.chkRMA.Checked Then Me.txtRMA.Text = Me.txtSN.Text
                '        Me.ProcessSN()
                '    End If 'Key up and input length > 0
                'Catch ex As Exception
                '    MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Me.Enabled = True : txtSN.SelectAll() : txtSN.Focus()
                'Finally
                '    Me.Enabled = True : Cursor.Current = Cursors.Default
                'End Try

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub SaveData()
            Dim dt As DataTable
            Dim iModel_ID As Integer = 0
            Dim iWO_ID As Integer = 0, iWOR_ID As Integer = 0
            Dim iQty As Integer = 0
            Dim strErrMsg As String = "", strPalletWOName As String = "", strRMA As String = ""
            Dim DTime As DateTime, strDateTime As String = ""
            Dim strItemDesc As String = "", strRetailer As String

            Try
                Me.Cursor = Cursors.WaitCursor ' hourglass
                Me.grpBox1.Enabled = False

                'If Not Me.cboPalletName.SelectedValue > 0 Then
                '    MessageBox.Show("Please select a pallet name.", "SaveData(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Exit Sub
                'End If
                If Not Me.cboRetailer.SelectedValue > 0 Then
                    MessageBox.Show("Please select a retailer.", "SaveData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not Me.cboModel.SelectedValue > 0 Then
                    MessageBox.Show("Please select a model.", "SaveData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Not txtQty.Text.Trim.Length > 0 Then
                    'MessageBox.Show("Enter a valid quantity.", "SaveData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtQty.Focus() : Me.txtQty.SelectAll() : Exit Sub
                End If
                If Not txtRMA.Text.Trim.Length > 0 Then
                    MessageBox.Show("Enter a valid RMA/RA #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.Focus() : Me.txtRMA.SelectAll() : Exit Sub
                End If
                If Not IsNumeric(txtQty.Text) Then
                    'MessageBox.Show("Enter a valid quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtQty.Focus() : Me.txtQty.SelectAll() : Exit Sub
                Else
                    iQty = Me.txtQty.Text
                    If Not iQty > 0 Then
                        'MessageBox.Show("Enter a valid quantity.", "SaveData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtQty.Focus() : Me.txtQty.SelectAll() : Exit Sub
                    End If
                End If

                'Pallet WorkOrder data
                If IsDate(Generic.MySQLServerDateTime) Then
                    DTime = Generic.MySQLServerDateTime
                    strDateTime = Format(DTime, "yyyy-MM-dd HH:mm:ss")
                    strPalletWOName = Me._objSkullcandy.PalletWO_Prefix & Format(DTime, "yyMMdd") & "N" & Format(DTime, "HHmmss") & Format(Now, "fff")
                Else
                    strPalletWOName = Me._objSkullcandy.PalletWO_Prefix & Format(Now, "yyMMdd") & "N" & Format(Now, "HHmmssfff")
                End If
                dt = Me._objSkullcandyRec.GetPalletWorkOrderData(Me._objSkullcandy.LOCID, strPalletWOName)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Pallet '" & strPalletWOName & " already exists. Can not create it.", "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                iQty = Me.txtQty.Text
                strRMA = Me.txtRMA.Text
                iWO_ID = Me._objSkullcandyRec.CreatePalletWO(Me._objSkullcandy.ASTRO_LOCID, Me._objSkullcandy.PRODID, _
                                                         Me._objSkullcandy.GROUPID, iQty, strDateTime, strPalletWOName)
                If Not iWO_ID > 0 Then
                    MessageBox.Show("Failed to create.", "btnCreatePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'WorkOrderLine data
                iWOR_ID = Me.cboRetailer.SelectedValue
                strItemDesc = Me.cboModel.DataSource.Table.select("Model_ID= " & Me.cboModel.SelectedValue)(0)("cust_IncomingSku")
                iModel_ID = Me.cboModel.SelectedValue

                'If Me._objSkullcandyRec.IsPalletWOClosed(iWO_ID) Then
                '    MessageBox.Show("Pallet '" & Me.cboPalletName.DataSource.Table.select("WO_ID = " & Me.cboPalletName.SelectedValue)(0)("WO_CustWO") & "' is closed! " & Environment.NewLine & "Can't save!", "SaveData(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'Else
                Me._objSkullcandyRec.InsertUpdatePalletReceivingData(strRMA, iModel_ID, iWO_ID, iQty, iWOR_ID, _
                                                                 strItemDesc, strPalletWOName, strErrMsg)

                If strErrMsg.Trim.Length > 0 Then 'failed
                    MessageBox.Show(strErrMsg, "SaveData(", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else 'sucessed

                    'Create TrayID which is used in receiving
                    Dim objRec As New PSS.Data.Production.Receiving()
                    Dim iTrayID As Integer = 0
                    iTrayID = objRec.GetTrayID(iWO_ID)
                    If iTrayID = 0 Then iTrayID = objRec.InsertIntoTtray(PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, iWO_ID, )

                    'Print
                    If Me.chkPrint.Checked Then 'Print
                        Dim objSkullcandyPrint As SkullcandyPrint
                        objSkullcandyPrint = New SkullcandyPrint()
                        strRetailer = Me.cboRetailer.DataSource.Table.select("WOR_ID= " & Me.cboRetailer.SelectedValue)(0)("RetailerName")
                        objSkullcandyPrint.Print_ReceivingPalletReport(strPalletWOName, strItemDesc, strRetailer, iQty, 1)
                    End If

                    BindPalletDetailedData()

                    Me.txtQty.Text = 0 : iQty = 0


                End If
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SaveData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default ' default
                Me.grpBox1.Enabled = True
            End Try
        End Sub

        '******************************************************************
        Private Sub BindPalletDetailedData()
            Dim dt As DataTable
            Dim strDateStart As String
            Dim strDateEnd As String

            Try
                'If Not Me.cboPalletName.SelectedValue > 0 Then
                '    Me.tdgData1.DataSource = Nothing : Me.txtTotalQty.Text = 0 : Exit Sub
                'End If

                If Me.dtpStartDate2.Value > Me.dtpEndDate2.Value Then
                    strDateEnd = Me.dtpStartDate2.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                    strDateStart = Me.dtpEndDate2.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Else
                    strDateStart = Me.dtpStartDate2.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                    strDateEnd = Me.dtpEndDate2.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                End If

                'dt = Me._objSkullcandyRec.GetPalletWO_DetailedData(Me._iMenuCustID, Me.cboPalletName.SelectedValue)
                dt = Me._objSkullcandyRec.GetPalletWO_DetailedData(Me._objSkullcandy.ASTRO_LOCID, strDateStart, strDateEnd)

                If dt.Rows.Count > 0 Then
                    Me.tdgData1.DataSource = dt
                    Me.txtTotalQty.Text = dt.Compute("SUM(Qty)", "").ToString
                    'Me.tdgData1.Splits(0).DisplayColumns("ModelDesc").Width = 200
                    'Me.tdgData1.Splits(0).DisplayColumns("Qty").Width = 50
                    'Me.tdgData1.Splits(0).DisplayColumns("PalletName").Width = 150
                    'Me.tdgData1.Splits(0).DisplayColumns("LineNo").Width = 40
                    Me.tdgData1.Splits(0).DisplayColumns("RMA/RA #").Width = 100
                    Me.tdgData1.Splits(0).DisplayColumns("Retailer").Width = 60
                    Me.tdgData1.Splits(0).DisplayColumns("Model").Width = 40
                    Me.tdgData1.Splits(0).DisplayColumns("Qty").Width = 40
                    Me.tdgData1.Splits(0).DisplayColumns("ModelDesc").Width = 80
                    Me.tdgData1.Splits(0).DisplayColumns("ItemDesc").Width = 80
                    Me.tdgData1.Splits(0).DisplayColumns("WorkOrder").Width = 200
                    Me.tdgData1.Splits(0).DisplayColumns("WO_ID").Width = 0
                    Me.tdgData1.Splits(0).DisplayColumns("WOR_ID").Width = 0
                    Me.tdgData1.Splits(0).DisplayColumns("WOL_ID").Width = 0
                Else
                    Me.tdgData1.DataSource = Nothing : Me.txtTotalQty.Text = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindPalletDetailedData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboPalletName_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPalletName.SelectedValueChanged
            BindPalletDetailedData()
        End Sub

        '******************************************************************
        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            BindPalletDetailedData()
        End Sub

        '******************************************************************
        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            SaveData()
        End Sub

        '******************************************************************
        Private Sub btnDeleteRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteRow.Click
            Dim i As Integer = 0, iRow As Integer
            Dim strMsg As String = ""

            Try
                If Me.tdgData1.RowCount > 0 Then
                    If Me.tdgData1.SelectedRows.Count > 0 Then
                        If Me.tdgData1.SelectedRows.Count > 1 Then
                            strMsg = "Are you sure you want to remove these " & Me.tdgData1.SelectedRows.Count & " selected rows?"
                        Else
                            strMsg = "Are you sure you want to remove this 1 selected row?"
                        End If
                        If MessageBox.Show(strMsg, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Exit Sub
                        Else
                            For Each iRow In Me.tdgData1.SelectedRows
                                i = Me._objSkullcandyRec.DeletePalletWO_DetailedData(CInt(Me.tdgData1.Columns("WOL_ID").CellValue(iRow)), _
                                                                                     CInt(Me.tdgData1.Columns("WO_ID").CellValue(iRow)))
                            Next
                            BindPalletDetailedData()
                        End If
                    Else
                        MessageBox.Show("Please select a row to remove.", "btnDeleteRow_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPNDeleteRow_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnClosePallet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClosePallet.Click
            'Dim objSkullcandyPrint As SkullcandyPrint
            'Dim j As Integer = 0

            'Try
            '    BindPalletDetailedData() 'refresh
            '    If Me.tdgData1.RowCount > 0 Then

            '        If Me.chkPrint.Checked Then 'Print
            '            objSkullcandyPrint = New SkullcandyPrint()
            '            objSkullcandyPrint.Print_ReceivingPalletReport(Me.tdgData1.DataSource, 1)
            '        End If

            '        'Close it
            '        j = Me._objSkullcandyRec.UpdatePalletWO_ClosePallet(Me.cboPalletName.SelectedValue, Me.txtTotalQty.Text)
            '        If j > 0 Then
            '            PopulateOpenPalletNameWO(0)
            '            BindPalletDetailedData()
            '        Else
            '            MessageBox.Show("Failed to close!", "btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        End If

            '    Else
            '        MessageBox.Show("Empty Pallet. Nothing to close!", "btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, " btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        End Sub

        '******************************************************************
        Private Sub btnReprintPallet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintPallet.Click
            Try
                With Me
                    .grpBox1.Visible = False
                    '.chkPrint.Visible = False
                    '.btnClosePallet.Visible = False
                    .btnReprintPallet.Visible = False
                    '.btnDeleteRow.Visible = False
                    '.btnRefresh.Visible = False
                    '.tdgData1.Visible = False
                    '.txtTotalQty.Visible = False
                    '.lblTotalQty.Visible = False
                    .pnlDataView.Visible = False

                    .pnlReprintPallet.Top = .grpBox1.Top
                    .pnlReprintPallet.Height = .Height - .grpBox1.Top
                    .tdgData2.Height = .pnlReprintPallet.Height - .tdgData2.Top
                    .pnlReprintPallet.Visible = True
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnReprintPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Try
                With Me
                    .pnlReprintPallet.Visible = False

                    .grpBox1.Visible = True
                    '.chkPrint.Visible = True
                    '.btnClosePallet.Visible = True
                    .btnReprintPallet.Visible = True
                    '.btnDeleteRow.Visible = True
                    '.btnRefresh.Visible = True
                    '.tdgData1.Visible = True
                    '.txtTotalQty.Visible = True
                    '.lblTotalQty.Visible = True

                    .pnlDataView.Visible = True
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnGetPalletNames_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetPalletNames.Click
            Dim strDateEnd As String = "", strDateStart As String = ""
            Dim dt As DataTable

            Try
                If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                    strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                    strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Else
                    strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                    strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd") & " 23:59:59"
                End If

                'dt = Me._objSkullcandyRec.GetPalletWO_ClosedPalletNames(Me._objSkullcandy.LOCID, strDateStart, strDateEnd, Me._objSkullcandy.PalletWO_Prefix)

                dt = Me._objSkullcandyRec.GetPalletWO_DetailedData(Me._objSkullcandy.ASTRO_LOCID, strDateStart, strDateEnd, 1)

                If dt.Rows.Count > 0 Then
                    Me.tdgData2.DataSource = dt
                    'Me.tdgData2.Splits(0).DisplayColumns("PalletName").Width = 320
                    'Me.tdgData2.Splits(0).DisplayColumns("WO_ID").Width = 0
                    Me.tdgData2.Splits(0).DisplayColumns("Retailer").Width = 60
                    Me.tdgData2.Splits(0).DisplayColumns("Model").Width = 40
                    Me.tdgData2.Splits(0).DisplayColumns("Qty").Width = 40
                    Me.tdgData2.Splits(0).DisplayColumns("ModelDesc").Width = 80
                    Me.tdgData2.Splits(0).DisplayColumns("ItemDesc").Width = 80
                    Me.tdgData2.Splits(0).DisplayColumns("WorkOrder").Width = 200
                    Me.tdgData2.Splits(0).DisplayColumns("WO_ID").Width = 0
                    Me.tdgData2.Splits(0).DisplayColumns("WOR_ID").Width = 0
                    Me.tdgData2.Splits(0).DisplayColumns("WOL_ID").Width = 0
                Else
                    Me.tdgData2.DataSource = Nothing
                    MessageBox.Show("Can't find closed pallet.", " btnGetPalletNames_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGetPalletNames_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnPrintSelectedPallet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintSelectedPallet.Click
            Dim iRow As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim dt As DataTable

            Try
                If Not Me.tdgData2.RowCount > 0 Then Exit Sub

                If Me.tdgData2.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgData2.SelectedRows
                        'iWO_ID = CInt(Me.tdgData2.Columns("WO_ID").CellValue(iRow))
                        ' dt = Me._objSkullcandyRec.GetPalletWO_DetailedData(Me._iMenuCustID, iWO_ID)
                        'If dt.Rows.Count > 0 Then
                        Dim objSkullcandyPrint As New SkullcandyPrint()
                        ' objSkullcandyPrint.Print_ReceivingPalletReport(dt, 1)
                        objSkullcandyPrint.Print_ReceivingPalletReport(Me.tdgData2.Columns("WorkOrder").CellValue(iRow), _
                                                                       Me.tdgData2.Columns("ItemDesc").CellValue(iRow), _
                                                                       Me.tdgData2.Columns("Retailer").CellValue(iRow), _
                                                                       CInt(Me.tdgData2.Columns("Qty").CellValue(iRow)), 1)
                        ' Else
                        '   MessageBox.Show("No data for this pallet '" & Me.tdgData2.Columns("PalletName").CellValue(iRow) & ".", "btnPrintSelectedPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If
                    Next
                Else
                    MessageBox.Show("Please select pallet.", "btnPrintSelectedPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrintSelectedPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnAddRetailer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRetailer.Click
            Dim strRN As String = ""
            Dim i As Integer = 0

            Try
                'Ask for input
                strRN = InputBox("Enter a retailer name:", "Retailer").Trim
                If strRN.Trim.Length > 0 Then
                    i = Me._objSkullcandyRec.AddRetailerName(strRN)
                    PopulateRetailerNames()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddRetailer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnRetailerInactive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetailerInactive.Click
            Dim strRN As String = ""
            Dim iWOR_ID As Integer = 0

            Try
                If Not Me.cboRetailer.SelectedValue > 0 Then Exit Sub

                If MessageBox.Show("Do you want to change '" & Me.cboRetailer.DataSource.Table.select("WOR_ID= " & Me.cboRetailer.SelectedValue)(0)("Retailername") & _
                                   "' to be inactive?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    iWOR_ID = Me.cboRetailer.SelectedValue
                    Me._objSkullcandyRec.ChangeRetailerToInactive(iWOR_ID)
                    PopulateRetailerNames()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRetailerInactive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me._dbgRecData)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me._dbgRecData)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuPrintAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim dt As DataTable
            Dim objSkullcandyPrint As SkullcandyPrint

            Try
                dt = Misc.CopyAllDataOfVisibleCols(Me._dbgRecData)
                objSkullcandyPrint = New SkullcandyPrint()
                objSkullcandyPrint.Print_SKAstroWHReceivingReport(dt, 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "MenuPrintAllData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuPrintSelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim dt As DataTable
            Dim objSkullcandyPrint As SkullcandyPrint

            Try
                dt = Misc.CopySelectedDataOfVisibleCols(Me._dbgRecData)
                objSkullcandyPrint = New SkullcandyPrint()
                objSkullcandyPrint.Print_SKAstroWHReceivingReport(dt, 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuPrintSelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************
        Private Sub tdgData1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData1.MouseDown, tdgData2.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                'Select grid source
                'If sender.name = "tdgData1" Then
                '    Me._dbgRecData = Me.tdgData1
                'ElseIf sender.name = "tdgData2" Then
                '    Me._dbgRecData = Me.tdgData2
                'End If
                Me._dbgRecData = dbg

                'Event handle
                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()
                    Dim objPrintAll As New MenuItem()
                    Dim objPrintSelected As New MenuItem()


                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"
                    objPrintAll.Text = "Print all"
                    objPrintSelected.Text = "Print selected rows"

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)
                    ctmCopyData.MenuItems.Add("-")
                    ctmCopyData.MenuItems.Add(objPrintAll)
                    ctmCopyData.MenuItems.Add(objPrintSelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    RemoveHandler objPrintAll.Click, AddressOf CMenuPrintAllData
                    AddHandler objPrintAll.Click, AddressOf CMenuPrintAllData
                    RemoveHandler objPrintSelected.Click, AddressOf CMenuPrintSelectedData
                    AddHandler objPrintSelected.Click, AddressOf CMenuPrintSelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " tdgData1_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************


        Private Sub TextRMA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRMA.TextChanged

        End Sub

        Private Sub tdgData1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdgData1.Click

        End Sub
    End Class

End Namespace
