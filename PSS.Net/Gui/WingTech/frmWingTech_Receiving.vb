
Option Explicit On 
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WingTech
    Public Class frmWingTech_Receiving
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _iLoc_ID As Integer = 0
        Private _RecvDT As DataTable
        'Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _SeedStockRecvDT As DataTable
        Private _EndUserRecvDT As DataTable
        Private _iRecID As Integer = 0
        Private _iSeedStockRecID As Integer = 0
        Private _iEndUserRecID As Integer = 0
        Private _strRecvBoxName As String = ""
        Private _strSeedStockRecvBoxName As String = ""
        Private _strEndUserRecvBoxName As String = ""
        Private _iWB_ID As Integer = 0
        Private _iSeedStockWB_ID As Integer = 0
        Private _iEndUserWB_ID As Integer = 0
        Private _iSeedStockLoc_ID As Integer = 0
        Private _iEndUserLoc_ID As Integer = 0
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private _strRptName As String = ""
        Private _objWingTechReceving As PSS.Data.Buisness.WingTech.WingTech_Receiving
        Private _objWingTech As PSS.Data.Buisness.WingTech.WingTech
  
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objWingTechReceving = New PSS.Data.Buisness.WingTech.WingTech_Receiving()
            Me._objWingTech = New PSS.Data.Buisness.WingTech.WingTech()

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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblPSSModel As System.Windows.Forms.Label
        Friend WithEvents lbllblPSSModel As System.Windows.Forms.Label
        Friend WithEvents lblASN_In_Sku As System.Windows.Forms.Label
        Friend WithEvents cboASN_In_Sku As C1.Win.C1List.C1Combo
        Friend WithEvents tdgDeviceData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents txtMaxBoxQty As System.Windows.Forms.TextBox
        Friend WithEvents lblMaxBoxQty As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents txtReceivedQty As System.Windows.Forms.TextBox
        Friend WithEvents pnlReceived As System.Windows.Forms.Panel
        Friend WithEvents lblAccountDOA As System.Windows.Forms.Label
        Friend WithEvents lblRecCustLoc As System.Windows.Forms.Label
        Friend WithEvents lblRecModel As System.Windows.Forms.Label
        Friend WithEvents lblRecManufDate As System.Windows.Forms.Label
        Friend WithEvents lblRecSN As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents lblReceivedQty As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rbtByPoNumber As System.Windows.Forms.RadioButton
        Friend WithEvents rbtBySN As System.Windows.Forms.RadioButton
        Friend WithEvents rbtByBoxName As System.Windows.Forms.RadioButton
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents btnAddData As System.Windows.Forms.Button
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents lblSeedStockBoxName As System.Windows.Forms.Label
        Friend WithEvents lblSeedStockPSSModel As System.Windows.Forms.Label
        Friend WithEvents lbllblSeedStockPSSModel As System.Windows.Forms.Label
        Friend WithEvents lblSeedStockASN_In_Sku As System.Windows.Forms.Label
        Friend WithEvents cboSeedStockASN_In_Sku As C1.Win.C1List.C1Combo
        Friend WithEvents tdgSeedStockDeviceData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSeedStockCloseBox As System.Windows.Forms.Button
        Friend WithEvents txtSeedStockMaxBoxQty As System.Windows.Forms.TextBox
        Friend WithEvents lblSeedSTockMaxBoxQty As System.Windows.Forms.Label
        Friend WithEvents lblSeedStockSN As System.Windows.Forms.Label
        Friend WithEvents txtSeedStockSN As System.Windows.Forms.TextBox
        Friend WithEvents txtSeedStockReceivedQty As System.Windows.Forms.TextBox
        Friend WithEvents lblSeedStockLocation As System.Windows.Forms.Label
        Friend WithEvents cboSeedStockLocation As C1.Win.C1List.C1Combo
        Friend WithEvents lblSeedStockReceivedQty As System.Windows.Forms.Label
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents chkBoxByRMA As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents rbtBySNEndUser As System.Windows.Forms.RadioButton
        Friend WithEvents rbtByBoxNameEndUser As System.Windows.Forms.RadioButton
        Friend WithEvents btnReprintEndUserBoxLabel As System.Windows.Forms.Button
        Friend WithEvents lblEndUserBoxName As System.Windows.Forms.Label
        Friend WithEvents lblEndUserPSSModel As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboEndUserASN_In_Sku As C1.Win.C1List.C1Combo
        Friend WithEvents tdgEndUserDeviceData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnEndUserCloseBox As System.Windows.Forms.Button
        Friend WithEvents txtEndUserMaxBoxQty As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblEndUserSN As System.Windows.Forms.Label
        Friend WithEvents txtEndUserSN As System.Windows.Forms.TextBox
        Friend WithEvents txtEndUserReceivedQty As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboEndUserLocation As C1.Win.C1List.C1Combo
        Friend WithEvents Label8 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWingTech_Receiving))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lblPSSModel = New System.Windows.Forms.Label()
            Me.lbllblPSSModel = New System.Windows.Forms.Label()
            Me.lblASN_In_Sku = New System.Windows.Forms.Label()
            Me.cboASN_In_Sku = New C1.Win.C1List.C1Combo()
            Me.tdgDeviceData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.txtMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.lblMaxBoxQty = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.txtReceivedQty = New System.Windows.Forms.TextBox()
            Me.pnlReceived = New System.Windows.Forms.Panel()
            Me.lblAccountDOA = New System.Windows.Forms.Label()
            Me.lblRecCustLoc = New System.Windows.Forms.Label()
            Me.lblRecModel = New System.Windows.Forms.Label()
            Me.lblRecManufDate = New System.Windows.Forms.Label()
            Me.lblRecSN = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.lblReceivedQty = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rbtByPoNumber = New System.Windows.Forms.RadioButton()
            Me.rbtBySN = New System.Windows.Forms.RadioButton()
            Me.rbtByBoxName = New System.Windows.Forms.RadioButton()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.btnAddData = New System.Windows.Forms.Button()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.lblSeedStockBoxName = New System.Windows.Forms.Label()
            Me.lblSeedStockPSSModel = New System.Windows.Forms.Label()
            Me.lbllblSeedStockPSSModel = New System.Windows.Forms.Label()
            Me.lblSeedStockASN_In_Sku = New System.Windows.Forms.Label()
            Me.cboSeedStockASN_In_Sku = New C1.Win.C1List.C1Combo()
            Me.tdgSeedStockDeviceData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSeedStockCloseBox = New System.Windows.Forms.Button()
            Me.txtSeedStockMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.lblSeedSTockMaxBoxQty = New System.Windows.Forms.Label()
            Me.lblSeedStockSN = New System.Windows.Forms.Label()
            Me.txtSeedStockSN = New System.Windows.Forms.TextBox()
            Me.txtSeedStockReceivedQty = New System.Windows.Forms.TextBox()
            Me.lblSeedStockLocation = New System.Windows.Forms.Label()
            Me.cboSeedStockLocation = New C1.Win.C1List.C1Combo()
            Me.lblSeedStockReceivedQty = New System.Windows.Forms.Label()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.chkBoxByRMA = New System.Windows.Forms.CheckBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.rbtBySNEndUser = New System.Windows.Forms.RadioButton()
            Me.rbtByBoxNameEndUser = New System.Windows.Forms.RadioButton()
            Me.btnReprintEndUserBoxLabel = New System.Windows.Forms.Button()
            Me.lblEndUserBoxName = New System.Windows.Forms.Label()
            Me.lblEndUserPSSModel = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboEndUserASN_In_Sku = New C1.Win.C1List.C1Combo()
            Me.tdgEndUserDeviceData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnEndUserCloseBox = New System.Windows.Forms.Button()
            Me.txtEndUserMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblEndUserSN = New System.Windows.Forms.Label()
            Me.txtEndUserSN = New System.Windows.Forms.TextBox()
            Me.txtEndUserReceivedQty = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboEndUserLocation = New C1.Win.C1List.C1Combo()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.cboASN_In_Sku, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlReceived.SuspendLayout()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.cboSeedStockASN_In_Sku, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSeedStockDeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSeedStockLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.cboEndUserASN_In_Sku, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgEndUserDeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboEndUserLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Location = New System.Drawing.Point(16, 8)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.TabIndex = 172
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
            Me.TabControl1.Location = New System.Drawing.Point(8, 40)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(784, 464)
            Me.TabControl1.TabIndex = 171
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBoxName, Me.lblPSSModel, Me.lbllblPSSModel, Me.lblASN_In_Sku, Me.cboASN_In_Sku, Me.tdgDeviceData, Me.btnCloseBox, Me.txtMaxBoxQty, Me.lblMaxBoxQty, Me.lblSN, Me.txtSN, Me.txtReceivedQty, Me.pnlReceived, Me.lblLocation, Me.cboLocation, Me.lblReceivedQty, Me.GroupBox1})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(776, 438)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Bulk"
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblBoxName.Location = New System.Drawing.Point(496, 112)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(264, 21)
            Me.lblBoxName.TabIndex = 178
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPSSModel
            '
            Me.lblPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lblPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lblPSSModel.Location = New System.Drawing.Point(120, 80)
            Me.lblPSSModel.Name = "lblPSSModel"
            Me.lblPSSModel.Size = New System.Drawing.Size(232, 21)
            Me.lblPSSModel.TabIndex = 177
            Me.lblPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblPSSModel
            '
            Me.lbllblPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lbllblPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lbllblPSSModel.Location = New System.Drawing.Point(8, 80)
            Me.lbllblPSSModel.Name = "lbllblPSSModel"
            Me.lbllblPSSModel.Size = New System.Drawing.Size(112, 21)
            Me.lbllblPSSModel.TabIndex = 176
            Me.lbllblPSSModel.Text = "PSS Model:"
            Me.lbllblPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblASN_In_Sku
            '
            Me.lblASN_In_Sku.BackColor = System.Drawing.Color.Transparent
            Me.lblASN_In_Sku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblASN_In_Sku.ForeColor = System.Drawing.Color.Black
            Me.lblASN_In_Sku.Location = New System.Drawing.Point(0, 56)
            Me.lblASN_In_Sku.Name = "lblASN_In_Sku"
            Me.lblASN_In_Sku.Size = New System.Drawing.Size(112, 21)
            Me.lblASN_In_Sku.TabIndex = 175
            Me.lblASN_In_Sku.Text = "ASN-In-Sku:"
            Me.lblASN_In_Sku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboASN_In_Sku
            '
            Me.cboASN_In_Sku.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboASN_In_Sku.Caption = ""
            Me.cboASN_In_Sku.CaptionHeight = 17
            Me.cboASN_In_Sku.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboASN_In_Sku.ColumnCaptionHeight = 17
            Me.cboASN_In_Sku.ColumnFooterHeight = 17
            Me.cboASN_In_Sku.ContentHeight = 15
            Me.cboASN_In_Sku.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboASN_In_Sku.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboASN_In_Sku.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboASN_In_Sku.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboASN_In_Sku.EditorHeight = 15
            Me.cboASN_In_Sku.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboASN_In_Sku.ItemHeight = 15
            Me.cboASN_In_Sku.Location = New System.Drawing.Point(120, 56)
            Me.cboASN_In_Sku.MatchEntryTimeout = CType(2000, Long)
            Me.cboASN_In_Sku.MaxDropDownItems = CType(5, Short)
            Me.cboASN_In_Sku.MaxLength = 32767
            Me.cboASN_In_Sku.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboASN_In_Sku.Name = "cboASN_In_Sku"
            Me.cboASN_In_Sku.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboASN_In_Sku.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboASN_In_Sku.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboASN_In_Sku.Size = New System.Drawing.Size(240, 21)
            Me.cboASN_In_Sku.TabIndex = 174
            Me.cboASN_In_Sku.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'tdgDeviceData
            '
            Me.tdgDeviceData.AllowColMove = False
            Me.tdgDeviceData.AllowColSelect = False
            Me.tdgDeviceData.AllowFilter = False
            Me.tdgDeviceData.AllowSort = False
            Me.tdgDeviceData.AllowUpdate = False
            Me.tdgDeviceData.AlternatingRows = True
            Me.tdgDeviceData.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tdgDeviceData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgDeviceData.FetchRowStyles = True
            Me.tdgDeviceData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgDeviceData.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDeviceData.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgDeviceData.Location = New System.Drawing.Point(16, 144)
            Me.tdgDeviceData.Name = "tdgDeviceData"
            Me.tdgDeviceData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDeviceData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDeviceData.PreviewInfo.ZoomFactor = 75
            Me.tdgDeviceData.Size = New System.Drawing.Size(560, 272)
            Me.tdgDeviceData.TabIndex = 173
            Me.tdgDeviceData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyle" & _
            "s=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>270</Height><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 558, 270</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 558, 270</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
            "ob>"
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.Location = New System.Drawing.Point(584, 144)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.Size = New System.Drawing.Size(168, 40)
            Me.btnCloseBox.TabIndex = 169
            Me.btnCloseBox.Text = "Close Box (Bulk)"
            '
            'txtMaxBoxQty
            '
            Me.txtMaxBoxQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtMaxBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMaxBoxQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtMaxBoxQty.Location = New System.Drawing.Point(496, 14)
            Me.txtMaxBoxQty.Name = "txtMaxBoxQty"
            Me.txtMaxBoxQty.ReadOnly = True
            Me.txtMaxBoxQty.Size = New System.Drawing.Size(80, 30)
            Me.txtMaxBoxQty.TabIndex = 167
            Me.txtMaxBoxQty.Text = "0"
            Me.txtMaxBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblMaxBoxQty
            '
            Me.lblMaxBoxQty.BackColor = System.Drawing.Color.Transparent
            Me.lblMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMaxBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblMaxBoxQty.Location = New System.Drawing.Point(376, 16)
            Me.lblMaxBoxQty.Name = "lblMaxBoxQty"
            Me.lblMaxBoxQty.Size = New System.Drawing.Size(120, 21)
            Me.lblMaxBoxQty.TabIndex = 168
            Me.lblMaxBoxQty.Text = "Max Qty:"
            Me.lblMaxBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Black
            Me.lblSN.Location = New System.Drawing.Point(40, 112)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(80, 21)
            Me.lblSN.TabIndex = 161
            Me.lblSN.Text = "SN (IMEI):"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSN.Location = New System.Drawing.Point(120, 112)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(232, 22)
            Me.txtSN.TabIndex = 160
            Me.txtSN.Text = ""
            '
            'txtReceivedQty
            '
            Me.txtReceivedQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReceivedQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtReceivedQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtReceivedQty.Location = New System.Drawing.Point(496, 56)
            Me.txtReceivedQty.Name = "txtReceivedQty"
            Me.txtReceivedQty.ReadOnly = True
            Me.txtReceivedQty.Size = New System.Drawing.Size(80, 30)
            Me.txtReceivedQty.TabIndex = 162
            Me.txtReceivedQty.Text = "0"
            Me.txtReceivedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'pnlReceived
            '
            Me.pnlReceived.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAccountDOA, Me.lblRecCustLoc, Me.lblRecModel, Me.lblRecManufDate, Me.lblRecSN, Me.lblStatus})
            Me.pnlReceived.Location = New System.Drawing.Point(680, 16)
            Me.pnlReceived.Name = "pnlReceived"
            Me.pnlReceived.Size = New System.Drawing.Size(56, 32)
            Me.pnlReceived.TabIndex = 164
            '
            'lblAccountDOA
            '
            Me.lblAccountDOA.BackColor = System.Drawing.Color.Transparent
            Me.lblAccountDOA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccountDOA.ForeColor = System.Drawing.Color.DimGray
            Me.lblAccountDOA.Location = New System.Drawing.Point(72, 112)
            Me.lblAccountDOA.Name = "lblAccountDOA"
            Me.lblAccountDOA.Size = New System.Drawing.Size(240, 21)
            Me.lblAccountDOA.TabIndex = 167
            Me.lblAccountDOA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecCustLoc
            '
            Me.lblRecCustLoc.BackColor = System.Drawing.Color.Transparent
            Me.lblRecCustLoc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecCustLoc.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecCustLoc.Location = New System.Drawing.Point(72, 86)
            Me.lblRecCustLoc.Name = "lblRecCustLoc"
            Me.lblRecCustLoc.Size = New System.Drawing.Size(240, 21)
            Me.lblRecCustLoc.TabIndex = 166
            Me.lblRecCustLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecModel
            '
            Me.lblRecModel.BackColor = System.Drawing.Color.Transparent
            Me.lblRecModel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecModel.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecModel.Location = New System.Drawing.Point(72, 68)
            Me.lblRecModel.Name = "lblRecModel"
            Me.lblRecModel.Size = New System.Drawing.Size(240, 21)
            Me.lblRecModel.TabIndex = 165
            Me.lblRecModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecManufDate
            '
            Me.lblRecManufDate.BackColor = System.Drawing.Color.Transparent
            Me.lblRecManufDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecManufDate.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecManufDate.Location = New System.Drawing.Point(72, 50)
            Me.lblRecManufDate.Name = "lblRecManufDate"
            Me.lblRecManufDate.Size = New System.Drawing.Size(232, 21)
            Me.lblRecManufDate.TabIndex = 164
            Me.lblRecManufDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecSN
            '
            Me.lblRecSN.BackColor = System.Drawing.Color.Transparent
            Me.lblRecSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecSN.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecSN.Location = New System.Drawing.Point(72, 32)
            Me.lblRecSN.Name = "lblRecSN"
            Me.lblRecSN.Size = New System.Drawing.Size(240, 21)
            Me.lblRecSN.TabIndex = 163
            Me.lblRecSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(56, 8)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(240, 21)
            Me.lblStatus.TabIndex = 162
            Me.lblStatus.Text = "Received Result:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(40, 24)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 166
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(120, 24)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 165
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblReceivedQty
            '
            Me.lblReceivedQty.BackColor = System.Drawing.Color.Transparent
            Me.lblReceivedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReceivedQty.ForeColor = System.Drawing.Color.Black
            Me.lblReceivedQty.Location = New System.Drawing.Point(376, 56)
            Me.lblReceivedQty.Name = "lblReceivedQty"
            Me.lblReceivedQty.Size = New System.Drawing.Size(120, 21)
            Me.lblReceivedQty.TabIndex = 163
            Me.lblReceivedQty.Text = "Received Qty:"
            Me.lblReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.LightGray
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtByPoNumber, Me.rbtBySN, Me.rbtByBoxName, Me.btnReprintBoxLabel})
            Me.GroupBox1.Location = New System.Drawing.Point(584, 192)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(184, 136)
            Me.GroupBox1.TabIndex = 183
            Me.GroupBox1.TabStop = False
            '
            'rbtByPoNumber
            '
            Me.rbtByPoNumber.Location = New System.Drawing.Point(12, 104)
            Me.rbtByPoNumber.Name = "rbtByPoNumber"
            Me.rbtByPoNumber.Size = New System.Drawing.Size(152, 24)
            Me.rbtByPoNumber.TabIndex = 185
            Me.rbtByPoNumber.Text = "By PO Number"
            '
            'rbtBySN
            '
            Me.rbtBySN.Location = New System.Drawing.Point(12, 80)
            Me.rbtBySN.Name = "rbtBySN"
            Me.rbtBySN.Size = New System.Drawing.Size(152, 24)
            Me.rbtBySN.TabIndex = 184
            Me.rbtBySN.Text = "By SN (IMEI)"
            '
            'rbtByBoxName
            '
            Me.rbtByBoxName.Location = New System.Drawing.Point(12, 56)
            Me.rbtByBoxName.Name = "rbtByBoxName"
            Me.rbtByBoxName.Size = New System.Drawing.Size(152, 24)
            Me.rbtByBoxName.TabIndex = 183
            Me.rbtByBoxName.Text = "By Box Name"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(4, 8)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(168, 40)
            Me.btnReprintBoxLabel.TabIndex = 180
            Me.btnReprintBoxLabel.Text = "Reprint Box Label"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.Lavender
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddData, Me.TextBox2, Me.TextBox1, Me.lblSeedStockBoxName, Me.lblSeedStockPSSModel, Me.lbllblSeedStockPSSModel, Me.lblSeedStockASN_In_Sku, Me.cboSeedStockASN_In_Sku, Me.tdgSeedStockDeviceData, Me.btnSeedStockCloseBox, Me.txtSeedStockMaxBoxQty, Me.lblSeedSTockMaxBoxQty, Me.lblSeedStockSN, Me.txtSeedStockSN, Me.txtSeedStockReceivedQty, Me.lblSeedStockLocation, Me.cboSeedStockLocation, Me.lblSeedStockReceivedQty})
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(776, 438)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Seedstock"
            Me.TabPage2.Visible = False
            '
            'btnAddData
            '
            Me.btnAddData.Location = New System.Drawing.Point(632, 48)
            Me.btnAddData.Name = "btnAddData"
            Me.btnAddData.Size = New System.Drawing.Size(104, 40)
            Me.btnAddData.TabIndex = 196
            Me.btnAddData.Text = "Add Data"
            Me.btnAddData.Visible = False
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(688, 24)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(40, 20)
            Me.TextBox2.TabIndex = 195
            Me.TextBox2.Text = "0"
            Me.TextBox2.Visible = False
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(632, 24)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(40, 20)
            Me.TextBox1.TabIndex = 194
            Me.TextBox1.Text = "1"
            Me.TextBox1.Visible = False
            '
            'lblSeedStockBoxName
            '
            Me.lblSeedStockBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedStockBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblSeedStockBoxName.Location = New System.Drawing.Point(504, 112)
            Me.lblSeedStockBoxName.Name = "lblSeedStockBoxName"
            Me.lblSeedStockBoxName.Size = New System.Drawing.Size(264, 21)
            Me.lblSeedStockBoxName.TabIndex = 193
            Me.lblSeedStockBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSeedStockPSSModel
            '
            Me.lblSeedStockPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedStockPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lblSeedStockPSSModel.Location = New System.Drawing.Point(128, 80)
            Me.lblSeedStockPSSModel.Name = "lblSeedStockPSSModel"
            Me.lblSeedStockPSSModel.Size = New System.Drawing.Size(232, 21)
            Me.lblSeedStockPSSModel.TabIndex = 192
            Me.lblSeedStockPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblSeedStockPSSModel
            '
            Me.lbllblSeedStockPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lbllblSeedStockPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblSeedStockPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lbllblSeedStockPSSModel.Location = New System.Drawing.Point(16, 80)
            Me.lbllblSeedStockPSSModel.Name = "lbllblSeedStockPSSModel"
            Me.lbllblSeedStockPSSModel.Size = New System.Drawing.Size(112, 21)
            Me.lbllblSeedStockPSSModel.TabIndex = 191
            Me.lbllblSeedStockPSSModel.Text = "PSS Model:"
            Me.lbllblSeedStockPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSeedStockASN_In_Sku
            '
            Me.lblSeedStockASN_In_Sku.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedStockASN_In_Sku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockASN_In_Sku.ForeColor = System.Drawing.Color.Black
            Me.lblSeedStockASN_In_Sku.Location = New System.Drawing.Point(8, 56)
            Me.lblSeedStockASN_In_Sku.Name = "lblSeedStockASN_In_Sku"
            Me.lblSeedStockASN_In_Sku.Size = New System.Drawing.Size(112, 21)
            Me.lblSeedStockASN_In_Sku.TabIndex = 190
            Me.lblSeedStockASN_In_Sku.Text = "ASN-In-Sku:"
            Me.lblSeedStockASN_In_Sku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboSeedStockASN_In_Sku
            '
            Me.cboSeedStockASN_In_Sku.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSeedStockASN_In_Sku.Caption = ""
            Me.cboSeedStockASN_In_Sku.CaptionHeight = 17
            Me.cboSeedStockASN_In_Sku.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSeedStockASN_In_Sku.ColumnCaptionHeight = 17
            Me.cboSeedStockASN_In_Sku.ColumnFooterHeight = 17
            Me.cboSeedStockASN_In_Sku.ContentHeight = 15
            Me.cboSeedStockASN_In_Sku.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSeedStockASN_In_Sku.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSeedStockASN_In_Sku.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSeedStockASN_In_Sku.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSeedStockASN_In_Sku.EditorHeight = 15
            Me.cboSeedStockASN_In_Sku.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboSeedStockASN_In_Sku.ItemHeight = 15
            Me.cboSeedStockASN_In_Sku.Location = New System.Drawing.Point(128, 56)
            Me.cboSeedStockASN_In_Sku.MatchEntryTimeout = CType(2000, Long)
            Me.cboSeedStockASN_In_Sku.MaxDropDownItems = CType(5, Short)
            Me.cboSeedStockASN_In_Sku.MaxLength = 32767
            Me.cboSeedStockASN_In_Sku.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSeedStockASN_In_Sku.Name = "cboSeedStockASN_In_Sku"
            Me.cboSeedStockASN_In_Sku.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSeedStockASN_In_Sku.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSeedStockASN_In_Sku.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSeedStockASN_In_Sku.Size = New System.Drawing.Size(240, 21)
            Me.cboSeedStockASN_In_Sku.TabIndex = 189
            Me.cboSeedStockASN_In_Sku.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'tdgSeedStockDeviceData
            '
            Me.tdgSeedStockDeviceData.AllowColMove = False
            Me.tdgSeedStockDeviceData.AllowColSelect = False
            Me.tdgSeedStockDeviceData.AllowFilter = False
            Me.tdgSeedStockDeviceData.AllowSort = False
            Me.tdgSeedStockDeviceData.AllowUpdate = False
            Me.tdgSeedStockDeviceData.AlternatingRows = True
            Me.tdgSeedStockDeviceData.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tdgSeedStockDeviceData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgSeedStockDeviceData.FetchRowStyles = True
            Me.tdgSeedStockDeviceData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSeedStockDeviceData.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSeedStockDeviceData.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgSeedStockDeviceData.Location = New System.Drawing.Point(24, 144)
            Me.tdgSeedStockDeviceData.Name = "tdgSeedStockDeviceData"
            Me.tdgSeedStockDeviceData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSeedStockDeviceData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSeedStockDeviceData.PreviewInfo.ZoomFactor = 75
            Me.tdgSeedStockDeviceData.Size = New System.Drawing.Size(560, 272)
            Me.tdgSeedStockDeviceData.TabIndex = 188
            Me.tdgSeedStockDeviceData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyle" & _
            "s=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>270</Height><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 558, 270</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 558, 270</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
            "ob>"
            '
            'btnSeedStockCloseBox
            '
            Me.btnSeedStockCloseBox.BackColor = System.Drawing.Color.SteelBlue
            Me.btnSeedStockCloseBox.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.btnSeedStockCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSeedStockCloseBox.Location = New System.Drawing.Point(592, 144)
            Me.btnSeedStockCloseBox.Name = "btnSeedStockCloseBox"
            Me.btnSeedStockCloseBox.Size = New System.Drawing.Size(176, 40)
            Me.btnSeedStockCloseBox.TabIndex = 187
            Me.btnSeedStockCloseBox.Text = "Close Box (SeedStock)"
            '
            'txtSeedStockMaxBoxQty
            '
            Me.txtSeedStockMaxBoxQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtSeedStockMaxBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSeedStockMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSeedStockMaxBoxQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtSeedStockMaxBoxQty.Location = New System.Drawing.Point(504, 16)
            Me.txtSeedStockMaxBoxQty.Name = "txtSeedStockMaxBoxQty"
            Me.txtSeedStockMaxBoxQty.ReadOnly = True
            Me.txtSeedStockMaxBoxQty.Size = New System.Drawing.Size(80, 30)
            Me.txtSeedStockMaxBoxQty.TabIndex = 185
            Me.txtSeedStockMaxBoxQty.Text = "0"
            Me.txtSeedStockMaxBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblSeedSTockMaxBoxQty
            '
            Me.lblSeedSTockMaxBoxQty.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedSTockMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedSTockMaxBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblSeedSTockMaxBoxQty.Location = New System.Drawing.Point(384, 16)
            Me.lblSeedSTockMaxBoxQty.Name = "lblSeedSTockMaxBoxQty"
            Me.lblSeedSTockMaxBoxQty.Size = New System.Drawing.Size(120, 21)
            Me.lblSeedSTockMaxBoxQty.TabIndex = 186
            Me.lblSeedSTockMaxBoxQty.Text = "Max Qty:"
            Me.lblSeedSTockMaxBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSeedStockSN
            '
            Me.lblSeedStockSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedStockSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockSN.ForeColor = System.Drawing.Color.Black
            Me.lblSeedStockSN.Location = New System.Drawing.Point(48, 112)
            Me.lblSeedStockSN.Name = "lblSeedStockSN"
            Me.lblSeedStockSN.Size = New System.Drawing.Size(80, 21)
            Me.lblSeedStockSN.TabIndex = 180
            Me.lblSeedStockSN.Text = "SN (IMEI):"
            Me.lblSeedStockSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSeedStockSN
            '
            Me.txtSeedStockSN.BackColor = System.Drawing.Color.White
            Me.txtSeedStockSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSeedStockSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSeedStockSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSeedStockSN.Location = New System.Drawing.Point(128, 112)
            Me.txtSeedStockSN.Name = "txtSeedStockSN"
            Me.txtSeedStockSN.Size = New System.Drawing.Size(232, 22)
            Me.txtSeedStockSN.TabIndex = 179
            Me.txtSeedStockSN.Text = ""
            '
            'txtSeedStockReceivedQty
            '
            Me.txtSeedStockReceivedQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtSeedStockReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSeedStockReceivedQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSeedStockReceivedQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtSeedStockReceivedQty.Location = New System.Drawing.Point(504, 56)
            Me.txtSeedStockReceivedQty.Name = "txtSeedStockReceivedQty"
            Me.txtSeedStockReceivedQty.ReadOnly = True
            Me.txtSeedStockReceivedQty.Size = New System.Drawing.Size(80, 30)
            Me.txtSeedStockReceivedQty.TabIndex = 181
            Me.txtSeedStockReceivedQty.Text = "0"
            Me.txtSeedStockReceivedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblSeedStockLocation
            '
            Me.lblSeedStockLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedStockLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockLocation.ForeColor = System.Drawing.Color.Black
            Me.lblSeedStockLocation.Location = New System.Drawing.Point(48, 24)
            Me.lblSeedStockLocation.Name = "lblSeedStockLocation"
            Me.lblSeedStockLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblSeedStockLocation.TabIndex = 184
            Me.lblSeedStockLocation.Text = "Location:"
            Me.lblSeedStockLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboSeedStockLocation
            '
            Me.cboSeedStockLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSeedStockLocation.Caption = ""
            Me.cboSeedStockLocation.CaptionHeight = 17
            Me.cboSeedStockLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSeedStockLocation.ColumnCaptionHeight = 17
            Me.cboSeedStockLocation.ColumnFooterHeight = 17
            Me.cboSeedStockLocation.ContentHeight = 15
            Me.cboSeedStockLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSeedStockLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSeedStockLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSeedStockLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSeedStockLocation.EditorHeight = 15
            Me.cboSeedStockLocation.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboSeedStockLocation.ItemHeight = 15
            Me.cboSeedStockLocation.Location = New System.Drawing.Point(128, 24)
            Me.cboSeedStockLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboSeedStockLocation.MaxDropDownItems = CType(5, Short)
            Me.cboSeedStockLocation.MaxLength = 32767
            Me.cboSeedStockLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSeedStockLocation.Name = "cboSeedStockLocation"
            Me.cboSeedStockLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSeedStockLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSeedStockLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSeedStockLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboSeedStockLocation.TabIndex = 183
            Me.cboSeedStockLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblSeedStockReceivedQty
            '
            Me.lblSeedStockReceivedQty.BackColor = System.Drawing.Color.Transparent
            Me.lblSeedStockReceivedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSeedStockReceivedQty.ForeColor = System.Drawing.Color.Black
            Me.lblSeedStockReceivedQty.Location = New System.Drawing.Point(384, 56)
            Me.lblSeedStockReceivedQty.Name = "lblSeedStockReceivedQty"
            Me.lblSeedStockReceivedQty.Size = New System.Drawing.Size(120, 21)
            Me.lblSeedStockReceivedQty.TabIndex = 182
            Me.lblSeedStockReceivedQty.Text = "Received Qty:"
            Me.lblSeedStockReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TabPage3
            '
            Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkBoxByRMA, Me.GroupBox2, Me.lblEndUserBoxName, Me.lblEndUserPSSModel, Me.Label3, Me.Label4, Me.cboEndUserASN_In_Sku, Me.tdgEndUserDeviceData, Me.btnEndUserCloseBox, Me.txtEndUserMaxBoxQty, Me.Label5, Me.lblEndUserSN, Me.txtEndUserSN, Me.txtEndUserReceivedQty, Me.Label7, Me.cboEndUserLocation, Me.Label8})
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(776, 438)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "EndUser"
            Me.TabPage3.Visible = False
            '
            'chkBoxByRMA
            '
            Me.chkBoxByRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxByRMA.Location = New System.Drawing.Point(368, 112)
            Me.chkBoxByRMA.Name = "chkBoxByRMA"
            Me.chkBoxByRMA.Size = New System.Drawing.Size(128, 24)
            Me.chkBoxByRMA.TabIndex = 210
            Me.chkBoxByRMA.Text = "Input RMA No"
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.Color.LightGray
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtBySNEndUser, Me.rbtByBoxNameEndUser, Me.btnReprintEndUserBoxLabel})
            Me.GroupBox2.Location = New System.Drawing.Point(590, 192)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(184, 112)
            Me.GroupBox2.TabIndex = 209
            Me.GroupBox2.TabStop = False
            '
            'rbtBySNEndUser
            '
            Me.rbtBySNEndUser.Location = New System.Drawing.Point(12, 80)
            Me.rbtBySNEndUser.Name = "rbtBySNEndUser"
            Me.rbtBySNEndUser.Size = New System.Drawing.Size(152, 24)
            Me.rbtBySNEndUser.TabIndex = 184
            Me.rbtBySNEndUser.Text = "By SN (IMEI)"
            '
            'rbtByBoxNameEndUser
            '
            Me.rbtByBoxNameEndUser.Location = New System.Drawing.Point(12, 56)
            Me.rbtByBoxNameEndUser.Name = "rbtByBoxNameEndUser"
            Me.rbtByBoxNameEndUser.Size = New System.Drawing.Size(152, 24)
            Me.rbtByBoxNameEndUser.TabIndex = 183
            Me.rbtByBoxNameEndUser.Text = "By Box Name"
            '
            'btnReprintEndUserBoxLabel
            '
            Me.btnReprintEndUserBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintEndUserBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintEndUserBoxLabel.Location = New System.Drawing.Point(4, 8)
            Me.btnReprintEndUserBoxLabel.Name = "btnReprintEndUserBoxLabel"
            Me.btnReprintEndUserBoxLabel.Size = New System.Drawing.Size(168, 40)
            Me.btnReprintEndUserBoxLabel.TabIndex = 180
            Me.btnReprintEndUserBoxLabel.Text = "Reprint Box Label"
            '
            'lblEndUserBoxName
            '
            Me.lblEndUserBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblEndUserBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndUserBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblEndUserBoxName.Location = New System.Drawing.Point(512, 112)
            Me.lblEndUserBoxName.Name = "lblEndUserBoxName"
            Me.lblEndUserBoxName.Size = New System.Drawing.Size(256, 21)
            Me.lblEndUserBoxName.TabIndex = 208
            Me.lblEndUserBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblEndUserPSSModel
            '
            Me.lblEndUserPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lblEndUserPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndUserPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lblEndUserPSSModel.Location = New System.Drawing.Point(128, 80)
            Me.lblEndUserPSSModel.Name = "lblEndUserPSSModel"
            Me.lblEndUserPSSModel.Size = New System.Drawing.Size(232, 21)
            Me.lblEndUserPSSModel.TabIndex = 207
            Me.lblEndUserPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(16, 80)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(104, 21)
            Me.Label3.TabIndex = 206
            Me.Label3.Text = "PSS Model:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(8, 56)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(104, 21)
            Me.Label4.TabIndex = 205
            Me.Label4.Text = "ASN-In-Sku:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboEndUserASN_In_Sku
            '
            Me.cboEndUserASN_In_Sku.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboEndUserASN_In_Sku.Caption = ""
            Me.cboEndUserASN_In_Sku.CaptionHeight = 17
            Me.cboEndUserASN_In_Sku.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboEndUserASN_In_Sku.ColumnCaptionHeight = 17
            Me.cboEndUserASN_In_Sku.ColumnFooterHeight = 17
            Me.cboEndUserASN_In_Sku.ContentHeight = 15
            Me.cboEndUserASN_In_Sku.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboEndUserASN_In_Sku.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboEndUserASN_In_Sku.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEndUserASN_In_Sku.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboEndUserASN_In_Sku.EditorHeight = 15
            Me.cboEndUserASN_In_Sku.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboEndUserASN_In_Sku.ItemHeight = 15
            Me.cboEndUserASN_In_Sku.Location = New System.Drawing.Point(128, 56)
            Me.cboEndUserASN_In_Sku.MatchEntryTimeout = CType(2000, Long)
            Me.cboEndUserASN_In_Sku.MaxDropDownItems = CType(5, Short)
            Me.cboEndUserASN_In_Sku.MaxLength = 32767
            Me.cboEndUserASN_In_Sku.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboEndUserASN_In_Sku.Name = "cboEndUserASN_In_Sku"
            Me.cboEndUserASN_In_Sku.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboEndUserASN_In_Sku.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboEndUserASN_In_Sku.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboEndUserASN_In_Sku.Size = New System.Drawing.Size(240, 21)
            Me.cboEndUserASN_In_Sku.TabIndex = 204
            Me.cboEndUserASN_In_Sku.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'tdgEndUserDeviceData
            '
            Me.tdgEndUserDeviceData.AllowColMove = False
            Me.tdgEndUserDeviceData.AllowColSelect = False
            Me.tdgEndUserDeviceData.AllowFilter = False
            Me.tdgEndUserDeviceData.AllowSort = False
            Me.tdgEndUserDeviceData.AllowUpdate = False
            Me.tdgEndUserDeviceData.AlternatingRows = True
            Me.tdgEndUserDeviceData.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tdgEndUserDeviceData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgEndUserDeviceData.FetchRowStyles = True
            Me.tdgEndUserDeviceData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgEndUserDeviceData.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgEndUserDeviceData.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.tdgEndUserDeviceData.Location = New System.Drawing.Point(24, 144)
            Me.tdgEndUserDeviceData.Name = "tdgEndUserDeviceData"
            Me.tdgEndUserDeviceData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgEndUserDeviceData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgEndUserDeviceData.PreviewInfo.ZoomFactor = 75
            Me.tdgEndUserDeviceData.Size = New System.Drawing.Size(560, 288)
            Me.tdgEndUserDeviceData.TabIndex = 203
            Me.tdgEndUserDeviceData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyle" & _
            "s=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>286</Height><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 558, 286</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 558, 286</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
            "ob>"
            '
            'btnEndUserCloseBox
            '
            Me.btnEndUserCloseBox.BackColor = System.Drawing.Color.CadetBlue
            Me.btnEndUserCloseBox.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.btnEndUserCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEndUserCloseBox.Location = New System.Drawing.Point(592, 144)
            Me.btnEndUserCloseBox.Name = "btnEndUserCloseBox"
            Me.btnEndUserCloseBox.Size = New System.Drawing.Size(176, 40)
            Me.btnEndUserCloseBox.TabIndex = 202
            Me.btnEndUserCloseBox.Text = "Close Box (End User)"
            '
            'txtEndUserMaxBoxQty
            '
            Me.txtEndUserMaxBoxQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtEndUserMaxBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEndUserMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEndUserMaxBoxQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtEndUserMaxBoxQty.Location = New System.Drawing.Point(504, 8)
            Me.txtEndUserMaxBoxQty.Name = "txtEndUserMaxBoxQty"
            Me.txtEndUserMaxBoxQty.ReadOnly = True
            Me.txtEndUserMaxBoxQty.Size = New System.Drawing.Size(80, 30)
            Me.txtEndUserMaxBoxQty.TabIndex = 200
            Me.txtEndUserMaxBoxQty.Text = "0"
            Me.txtEndUserMaxBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(384, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 21)
            Me.Label5.TabIndex = 201
            Me.Label5.Text = "Max Qty:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblEndUserSN
            '
            Me.lblEndUserSN.BackColor = System.Drawing.Color.Transparent
            Me.lblEndUserSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndUserSN.ForeColor = System.Drawing.Color.Black
            Me.lblEndUserSN.Location = New System.Drawing.Point(48, 112)
            Me.lblEndUserSN.Name = "lblEndUserSN"
            Me.lblEndUserSN.Size = New System.Drawing.Size(80, 21)
            Me.lblEndUserSN.TabIndex = 195
            Me.lblEndUserSN.Text = "SN (IMEI):"
            Me.lblEndUserSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEndUserSN
            '
            Me.txtEndUserSN.BackColor = System.Drawing.Color.White
            Me.txtEndUserSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEndUserSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEndUserSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtEndUserSN.Location = New System.Drawing.Point(128, 112)
            Me.txtEndUserSN.Name = "txtEndUserSN"
            Me.txtEndUserSN.Size = New System.Drawing.Size(232, 22)
            Me.txtEndUserSN.TabIndex = 194
            Me.txtEndUserSN.Text = ""
            '
            'txtEndUserReceivedQty
            '
            Me.txtEndUserReceivedQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtEndUserReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEndUserReceivedQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEndUserReceivedQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtEndUserReceivedQty.Location = New System.Drawing.Point(504, 40)
            Me.txtEndUserReceivedQty.Name = "txtEndUserReceivedQty"
            Me.txtEndUserReceivedQty.ReadOnly = True
            Me.txtEndUserReceivedQty.Size = New System.Drawing.Size(80, 30)
            Me.txtEndUserReceivedQty.TabIndex = 196
            Me.txtEndUserReceivedQty.Text = "0"
            Me.txtEndUserReceivedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(48, 27)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(72, 21)
            Me.Label7.TabIndex = 199
            Me.Label7.Text = "Location:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboEndUserLocation
            '
            Me.cboEndUserLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboEndUserLocation.Caption = ""
            Me.cboEndUserLocation.CaptionHeight = 17
            Me.cboEndUserLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboEndUserLocation.ColumnCaptionHeight = 17
            Me.cboEndUserLocation.ColumnFooterHeight = 17
            Me.cboEndUserLocation.ContentHeight = 15
            Me.cboEndUserLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboEndUserLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboEndUserLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEndUserLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboEndUserLocation.EditorHeight = 15
            Me.cboEndUserLocation.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.cboEndUserLocation.ItemHeight = 15
            Me.cboEndUserLocation.Location = New System.Drawing.Point(128, 27)
            Me.cboEndUserLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboEndUserLocation.MaxDropDownItems = CType(5, Short)
            Me.cboEndUserLocation.MaxLength = 32767
            Me.cboEndUserLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboEndUserLocation.Name = "cboEndUserLocation"
            Me.cboEndUserLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboEndUserLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboEndUserLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboEndUserLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboEndUserLocation.TabIndex = 198
            Me.cboEndUserLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(384, 40)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(120, 21)
            Me.Label8.TabIndex = 197
            Me.Label8.Text = "Received Qty:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmWingTech_Receiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(800, 510)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.TabControl1})
            Me.Name = "frmWingTech_Receiving"
            Me.Text = "frmWingTech_Receiving"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.cboASN_In_Sku, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlReceived.ResumeLayout(False)
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            CType(Me.cboSeedStockASN_In_Sku, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSeedStockDeviceData, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSeedStockLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage3.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.cboEndUserASN_In_Sku, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgEndUserDeviceData, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboEndUserLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWingTech_Receiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strCustLoc As String = ""
            Dim dtLoc, dtLoc_SeedStock, dtLoc_EndUser As DataTable
            Dim iLoc_ID As Integer = 0
            Dim dtModel As DataTable
            Dim dtDOA As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

                'strCustLoc = Me._objWiKo_Receiving.getCustomerLocation(Me._iCust_ID, Me._iLoc_ID)
                Me.lblTitle.Text = Me._strScreenName
                Me.rbtByBoxName.Checked = True
                Me.rbtByBoxNameEndUser.Checked = True
                Me.chkBoxByRMA.Checked = False

                'initialoze recv datatable columns
                Me._RecvDT = Me._objWingTechReceving.GetRecvTableDef
                Me._SeedStockRecvDT = Me._objWingTechReceving.GetSeedStockRecvTableDef
                Me._EndUserRecvDT = Me._objWingTechReceving.GetEndUserRecvTableDef

                'Location
                dtLoc = Me._objWingTechReceving.GetWingTechLocations(Me._iCust_ID, True)
                dtLoc_SeedStock = dtLoc.Copy
                dtLoc_EndUser = dtLoc.Copy

                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                If dtLoc.Rows.Count = 2 Then
                    iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
                    Me.cboLocation.SelectedValue = iLoc_ID
                Else
                    Me.cboLocation.SelectedValue = 0
                End If

                Misc.PopulateC1DropDownList(Me.cboSeedStockLocation, dtLoc_SeedStock, "Loc_Name", "Loc_ID")
                If dtLoc_SeedStock.Rows.Count = 2 Then
                    iLoc_ID = dtLoc_SeedStock.Rows(0).Item("Loc_ID")
                    Me.cboSeedStockLocation.SelectedValue = iLoc_ID
                Else
                    Me.cboSeedStockLocation.SelectedValue = 0
                End If

                Misc.PopulateC1DropDownList(Me.cboEndUserLocation, dtLoc_EndUser, "Loc_Name", "Loc_ID")
                If dtLoc_EndUser.Rows.Count = 2 Then
                    iLoc_ID = dtLoc_EndUser.Rows(0).Item("Loc_ID")
                    Me.cboEndUserLocation.SelectedValue = iLoc_ID
                Else
                    Me.cboEndUserLocation.SelectedValue = 0
                End If
                TabControl1.TabPages.Remove(TabPage3)
            

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            End Try
        End Sub

        Private Sub btnEndUserCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndUserCloseBox.Click
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0, j As Integer = 0
            Dim strWHLocation As String = ""
            Dim strOSD As String = ""
            Dim strASN_Category As String = "EndUser"
            Dim iASN_OrderType_ID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeEndUser_ID

            Try
                If Not Me._EndUserRecvDT.Rows.Count > 0 Then Exit Sub

                Me.txtEndUserReceivedQty.Text = Me._EndUserRecvDT.Rows.Count
                If Convert.ToInt32(Me.txtEndUserReceivedQty.Text) > Convert.ToInt32(Me.txtEndUserMaxBoxQty.Text) Then
                    MessageBox.Show("Received qty in the box is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close box
                    i = Me._objWingTechReceving.ColseWarehouseBox(Me._iEndUserWB_ID, Me._EndUserRecvDT.Rows.Count, strBoxStage)

                    If i > 0 Then
                        'print Label
                        Me._objWingTechReceving.PrintReceivedBoxLabel(iASN_OrderType_ID, Me._strEndUserRecvBoxName, Me._EndUserRecvDT.Rows.Count, Me._EndUserRecvDT.Rows(0).Item("SKU"), Me._EndUserRecvDT.Rows(0).Item("PSS_Model"), _
                                                 "", "", "", strWHLocation, strOSD, Me._EndUserRecvDT.Rows(0).Item("Customer"), strASN_Category)
                    Else
                        MessageBox.Show("Failed to Close the box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'reset
                    Me.tdgEndUserDeviceData.DataSource = Nothing : Me._EndUserRecvDT.Rows.Clear()
                    'initialoze recv datatable columns
                    Me.cboEndUserASN_In_Sku.Enabled = True
                    Me._EndUserRecvDT = Me._objWingTechReceving.GetEndUserRecvTableDef
                    Me._iEndUserRecID = 0 : Me._iEndUserWB_ID = 0 : Me._strEndUserRecvBoxName = "" : Me.txtEndUserReceivedQty.Text = 0 : Me.lblEndUserBoxName.Text = ""
                    Me.txtEndUserSN.Text = "" : Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnEndUserRecv_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnAddData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddData.Click
            Dim ArrLstSNs As New ArrayList()
            Dim ArrLstDateCodes As New ArrayList()
            Dim i As Integer = 0

            Dim iL As Integer = Convert.ToInt32(Me.TextBox1.Text)
            Dim iC As Integer = 0

            Try
                If Not ArrLstSNs.Count > 0 Then

                    ArrLstSNs.Add("864559041349044")
                    ArrLstSNs.Add("864559041205139")
                    ArrLstSNs.Add("864559041345596")
                    ArrLstSNs.Add("860006040712263")
                    ArrLstSNs.Add("860006044283725")
                    ArrLstSNs.Add("860006044901276")
                    ArrLstSNs.Add("860006042125696")
                    ArrLstSNs.Add("860006041490745")
                    ArrLstSNs.Add("860006044234256")
                    ArrLstSNs.Add("860006044057871")
                    ArrLstSNs.Add("860006044047815")
                    ArrLstSNs.Add("860006040726750")
                    ArrLstSNs.Add("860006040329803")
                    ArrLstSNs.Add("860006041597044")
                    ArrLstSNs.Add("860006044835300")
                    ArrLstSNs.Add("860006040667004")
                    ArrLstSNs.Add("860006044269575")
                    ArrLstSNs.Add("860006042946067")
                    ArrLstSNs.Add("860006044006407")
                    ArrLstSNs.Add("860006041747623")
                    ArrLstSNs.Add("860006041367661")
                    ArrLstSNs.Add("860006044795306")

                End If

                Me.txtSeedStockSN.Text = ArrLstSNs(iL - 1)
                'Me.txtManufDate_Seed.Text = ArrLstDateCodes(iL - 1)

                Me.TextBox1.Text = iL + 1
                Me.TextBox2.Text = ArrLstSNs.Count

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            'Dim strAnswer As String
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0
            Dim strWHLocation As String = ""
            Dim strOSD As String = ""
            Dim strASN_Category As String = "Bulk"
            Dim iASN_OrderType_ID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeBulk_ID

            Try
                If Not Me._RecvDT.Rows.Count > 0 Then Exit Sub

                Me.txtReceivedQty.Text = Me._RecvDT.Rows.Count
                'Me.txtMaxBoxQty.Text = "5"      ' xxxxxxxxxxxxx Hard coded by neethi have to remove after testing (05-27-2021)
                If Convert.ToInt32(Me.txtReceivedQty.Text) > Convert.ToInt32(Me.txtMaxBoxQty.Text) Then
                    MessageBox.Show("Received qty is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close box
                    i = Me._objWingTechReceving.ColseWarehouseBox(Me._iWB_ID, Me._RecvDT.Rows.Count, strBoxStage)

                    If i > 0 Then
                        'print Label
                        Me._objWingTechReceving.PrintReceivedBoxLabel(iASN_OrderType_ID, Me._strRecvBoxName, Me._RecvDT.Rows.Count, Me._RecvDT.Rows(0).Item("SKU"), Me._RecvDT.Rows(0).Item("PSS_Model"), _
                                                Me._RecvDT.Rows(0).Item("PlantID"), Me._RecvDT.Rows(0).Item("RepairProgramType"), Me._RecvDT.Rows(0).Item("PO_Number"), _
                                                strWHLocation, strOSD, Me._RecvDT.Rows(0).Item("Customer"), strASN_Category)
                    Else
                        MessageBox.Show("Failed to Close the box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'reset
                    Me.tdgDeviceData.DataSource = Nothing : Me._RecvDT.Rows.Clear()
                    'initialoze recv datatable columns
                    Me._RecvDT = Me._objWingTechReceving.GetRecvTableDef
                    Me._iRecID = 0 : Me._iWB_ID = 0 : Me._strRecvBoxName = "" : Me.txtReceivedQty.Text = 0 : Me.lblBoxName.Text = ""
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnEndUserCloseBox_AllowReceivingMixedSKUsInBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnEndUserCloseBox.Click
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0, j As Integer = 0
            Dim strWHLocation As String = ""
            Dim strOSD As String = ""
            Dim strASN_Category As String = "EndUser"
            Dim iASN_OrderType_ID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeEndUser_ID
            Dim arrLstSKUs As New ArrayList()
            Dim arrLstModels As New ArrayList()
            Dim row As DataRow
            Dim strMultipleSKUs As String = "", strMultipleModels As String = ""

            Try
                If Not Me._EndUserRecvDT.Rows.Count > 0 Then Exit Sub

                Me.txtEndUserReceivedQty.Text = Me._EndUserRecvDT.Rows.Count
                If Convert.ToInt32(Me.txtEndUserReceivedQty.Text) > Convert.ToInt32(Me.txtEndUserMaxBoxQty.Text) Then
                    MessageBox.Show("Received qty in the box is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close box
                    i = Me._objWingTechReceving.ColseWarehouseBox(Me._iEndUserWB_ID, Me._EndUserRecvDT.Rows.Count, strBoxStage)

                    If i > 0 Then
                        For Each row In Me._EndUserRecvDT.Rows 'the multiple SKUs are allowed to receive for End User
                            If Not arrLstSKUs.Contains(row("SKU")) Then
                                arrLstSKUs.Add(row("SKU")) : arrLstModels.Add(row("PSS_Model"))
                            End If
                        Next
                        If arrLstSKUs.Count = 1 Then
                            strMultipleSKUs = "SKU: " & arrLstSKUs(0) : strMultipleModels = "PSS Model: " & arrLstModels(0)
                        ElseIf arrLstSKUs.Count > 1 Then
                            For j = 0 To arrLstSKUs.Count - 1
                                If j = 0 Then strMultipleSKUs = "SKU: " & Environment.NewLine : strMultipleModels = "PSS Model: " & Environment.NewLine
                                If j <= 3 Then strMultipleSKUs &= ", " & arrLstSKUs(j) : strMultipleModels &= ", " & arrLstModels(j)
                                If j = 3 Then strMultipleSKUs &= ", ..." : strMultipleModels &= ", ..." 'Only keep 3 SKUs, if more than 3, the rest as ...
                            Next
                        End If
                        'print Label
                        Me._objWingTechReceving.PrintReceivedBoxLabel(iASN_OrderType_ID, Me._strEndUserRecvBoxName, Me._EndUserRecvDT.Rows.Count, strMultipleSKUs, strMultipleModels, _
                                                "", "", "", strWHLocation, strOSD, Me._EndUserRecvDT.Rows(0).Item("Customer"), strASN_Category)
                    Else
                        MessageBox.Show("Failed to Close the box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'reset
                    Me.tdgEndUserDeviceData.DataSource = Nothing : Me._EndUserRecvDT.Rows.Clear()
                    'initialoze recv datatable columns
                    Me._EndUserRecvDT = Me._objWingTechReceving.GetEndUserRecvTableDef
                    Me._iEndUserRecID = 0 : Me._iEndUserWB_ID = 0 : Me._strEndUserRecvBoxName = "" : Me.txtEndUserReceivedQty.Text = 0 : Me.lblEndUserBoxName.Text = ""
                    Me.txtEndUserSN.Text = "" : Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnEndUserRecv_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim strInput As String = ""
            Dim dt, dtSN, dtPO As DataTable
            Dim iLoc_ID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_CP1_Loc_ID
            Dim iBoxQty As Integer = 0
            Dim arrLstBoxes As New ArrayList(), arrlstRecvDates As New ArrayList()
            Dim row As DataRow
            Dim strMsg As String = ""
            Dim i As Integer = 0

            'Customer, Loc, wb_ID, BoxName, Closed, Model_ID, WarrantyFlag, RepairProgramType, Recv_Qty, Model_Desc
            ', item_Sku, PoNumber, SerialNo, Device_ID, PlantID, WHLocation, ASN_Category, OSD, Cust_ID, Loc_ID, BulkOrderType_ID, Device_DateRec
            Try
                If Me.rbtByBoxName.Checked Then 'BY BOX NAME -1-------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a box name:", "Box Name").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid box name.")
                    dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, strInput, 1)
                    If dt.Rows.Count > 0 Then
                        iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                        If iBoxQty = dt.Rows.Count Then
                            'print Label
                            Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                           iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                           dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                           dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                        Else
                            MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Me.rbtBySN.Checked Then 'BY SN (IMEI) -2------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a SN (IMEI):", "SN (IMEI)").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid SN (IMEI).")
                    dtSN = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, strInput, 2) 'get data for the SN
                    If dtSN.Rows.Count > 0 Then
                        For Each row In dtSN.Rows
                            If Not arrLstBoxes.Contains(row("BoxName")) Then
                                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                            End If
                        Next
                        If arrLstBoxes.Count = 1 Then 'one box
                            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, arrLstBoxes(0), 1) 'get box data  
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                            For i = 0 To arrLstBoxes.Count - 1
                                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", recved " & arrlstRecvDates(i) & Environment.NewLine
                            Next
                            strInput = InputBox(strMsg, "Input").Trim
                            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                            i = Convert.ToInt32(strInput)
                            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, selectedBoxName, 1)  'get box data
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else 'nothing 
                            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box for the SN (IMEI) " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Me.rbtByPoNumber.Checked Then 'BY PO Number -3------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a PO number:", "PO").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid PO number.")
                    dtPO = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, strInput, 3)
                    If dtPO.Rows.Count > 0 Then
                        For Each row In dtPO.Rows
                            If Not arrLstBoxes.Contains(row("BoxName")) Then
                                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                            End If
                        Next
                        If arrLstBoxes.Count = 1 Then 'one box
                            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, arrLstBoxes(0), 1) 'get box data  
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                            For i = 0 To arrLstBoxes.Count - 1
                                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", rcved " & arrlstRecvDates(i) & Environment.NewLine
                            Next
                            strInput = InputBox(strMsg, "Input").Trim
                            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                            i = Convert.ToInt32(strInput)
                            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, selectedBoxName, 1)  'get box data
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else 'nothing 
                            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box for the PO " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprinterBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnReprintEndUserBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintEndUserBoxLabel.Click
            Dim strInput As String = ""
            Dim dt, dtSN, dtPO As DataTable
            Dim iLoc_ID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_CP1_Loc_ID
            Dim iBoxQty As Integer = 0
            Dim arrLstBoxes As New ArrayList(), arrlstRecvDates As New ArrayList()
            Dim row As DataRow
            Dim strMsg As String = ""
            Dim i As Integer = 0

            'Customer, Loc, wb_ID, BoxName, Closed, Model_ID, WarrantyFlag, RepairProgramType, Recv_Qty, Model_Desc
            ', item_Sku, PoNumber, SerialNo, Device_ID, PlantID, WHLocation, ASN_Category, OSD, Cust_ID, Loc_ID, BulkOrderType_ID, Device_DateRec
            Try
                If Me.rbtByBoxName.Checked Then 'BY BOX NAME -1-------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a box name:", "Box Name").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid box name.")
                    dt = Me._objWingTechReceving.getReceivedEndUserBoxData(Me._iCust_ID, iLoc_ID, strInput, 1)
                    If dt.Rows.Count > 0 Then
                        iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                        If iBoxQty = dt.Rows.Count Then
                            'print Label
                            Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                           iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                           dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                           dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                        Else
                            MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Me.rbtBySN.Checked Then 'BY SN (IMEI) -2------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a SN (IMEI):", "SN (IMEI)").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid SN (IMEI).")
                    dtSN = Me._objWingTechReceving.getReceivedEndUserBoxData(Me._iCust_ID, iLoc_ID, strInput, 2) 'get data for the SN
                    If dtSN.Rows.Count > 0 Then
                        For Each row In dtSN.Rows
                            If Not arrLstBoxes.Contains(row("BoxName")) Then
                                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                            End If
                        Next
                        If arrLstBoxes.Count = 1 Then 'one box
                            dt = Me._objWingTechReceving.getReceivedEndUserBoxData(Me._iCust_ID, iLoc_ID, arrLstBoxes(0), 1) 'get box data  
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                            For i = 0 To arrLstBoxes.Count - 1
                                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", recved " & arrlstRecvDates(i) & Environment.NewLine
                            Next
                            strInput = InputBox(strMsg, "Input").Trim
                            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                            i = Convert.ToInt32(strInput)
                            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, selectedBoxName, 1)  'get box data
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else 'nothing 
                            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box for the SN (IMEI) " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    'ElseIf Me.rbtByPoNumber.Checked Then 'BY PO Number -3------------------------------------------------------------------------------------------------------
                    '    strInput = InputBox("Enter a PO number:", "PO").Trim
                    '    If strInput = "" Then Throw New Exception("Please enter a valid PO number.")
                    '    dtPO = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, strInput, 3)
                    '    If dtPO.Rows.Count > 0 Then
                    '        For Each row In dtPO.Rows
                    '            If Not arrLstBoxes.Contains(row("BoxName")) Then
                    '                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                    '            End If
                    '        Next
                    '        If arrLstBoxes.Count = 1 Then 'one box
                    '            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, arrLstBoxes(0), 1) 'get box data  
                    '            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                    '            If iBoxQty = dt.Rows.Count Then
                    '                'print Label
                    '                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                    '                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                    '                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                    '                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                    '            Else
                    '                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '            End If
                    '        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                    '            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                    '            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                    '            For i = 0 To arrLstBoxes.Count - 1
                    '                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", rcved " & arrlstRecvDates(i) & Environment.NewLine
                    '            Next
                    '            strInput = InputBox(strMsg, "Input").Trim
                    '            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                    '            i = Convert.ToInt32(strInput)
                    '            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                    '            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                    '            dt = Me._objWingTechReceving.getReceivedBulkBoxData(Me._iCust_ID, iLoc_ID, selectedBoxName, 1)  'get box data
                    '            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                    '            If iBoxQty = dt.Rows.Count Then
                    '                'print Label
                    '                Me._objWingTechReceving.PrintReceivedBoxLabel(Convert.ToInt32(dt.Rows(0).Item("BulkOrderType_ID")), dt.Rows(0).Item("BoxName"), _
                    '                                                               iBoxQty, dt.Rows(0).Item("item_Sku"), dt.Rows(0).Item("Model_Desc"), _
                    '                                                               dt.Rows(0).Item("PlantID"), dt.Rows(0).Item("RepairProgramType"), dt.Rows(0).Item("PoNumber"), _
                    '                                                               dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("OSD"), dt.Rows(0).Item("Customer"), dt.Rows(0).Item("ASN_Category"))
                    '            Else
                    '                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '            End If
                    '        Else 'nothing 
                    '            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        End If
                    '    Else
                    '        MessageBox.Show("Can't find the box for the PO " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintEndUserBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnSeedStockCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeedStockCloseBox.Click
            'Dim strAnswer As String
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0
            Dim strWHLocation As String = ""
            Dim strOSD As String = ""
            Dim strASN_Category As String = "Seedstock"
            Dim iASN_OrderType_ID As Integer = PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeSeedStock_ID

            Try
                If Not Me._SeedStockRecvDT.Rows.Count > 0 Then Exit Sub

                Me.txtSeedStockReceivedQty.Text = Me._SeedStockRecvDT.Rows.Count
                If Convert.ToInt32(Me.txtSeedStockReceivedQty.Text) > Convert.ToInt32(Me.txtSeedStockMaxBoxQty.Text) Then
                    MessageBox.Show("Received qty is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close box
                    i = Me._objWingTechReceving.ColseWarehouseBox(Me._iSeedStockWB_ID, Me._SeedStockRecvDT.Rows.Count, strBoxStage)

                    If i > 0 Then
                        'print Label
                        Me._objWingTechReceving.PrintReceivedBoxLabel(iASN_OrderType_ID, Me._strSeedStockRecvBoxName, Me._SeedStockRecvDT.Rows.Count, Me._SeedStockRecvDT.Rows(0).Item("SKU"), Me._SeedStockRecvDT.Rows(0).Item("PSS_Model"), _
                                                "", "", "", strWHLocation, strOSD, Me._SeedStockRecvDT.Rows(0).Item("Customer"), strASN_Category)
                    Else
                        MessageBox.Show("Failed to Close the box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'reset
                    Me.tdgSeedStockDeviceData.DataSource = Nothing : Me._SeedStockRecvDT.Rows.Clear()
                    'initialoze recv datatable columns
                    Me._SeedStockRecvDT = Me._objWingTechReceving.GetSeedStockRecvTableDef
                    Me._iSeedStockRecID = 0 : Me._iSeedStockWB_ID = 0 : Me._strSeedStockRecvBoxName = "" : Me.txtSeedStockReceivedQty.Text = 0 : Me.lblSeedStockBoxName.Text = ""
                    Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSeedStockCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub cboASN_In_Sku_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASN_In_Sku.SelectedValueChanged
            Try

                If Me.cboASN_In_Sku.SelectedValue > 0 Then
                    Me.lblPSSModel.Text = Me.cboASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboASN_In_Sku.SelectedValue)(0)("Model_Desc")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboASN_In_Sku_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub
        Private Sub cboEndUserASN_In_Sku_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEndUserASN_In_Sku.SelectedValueChanged
            Try

                If Me.cboEndUserASN_In_Sku.SelectedValue > 0 Then
                    Me.lblEndUserPSSModel.Text = Me.cboEndUserASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboEndUserASN_In_Sku.SelectedValue)(0)("Model_Desc")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboEndUserASN_In_Sku_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub
        Private Sub cboEndUserLocation_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEndUserLocation.SelectedValueChanged
            Dim dtModel As DataTable

            Try

                If Me.cboEndUserLocation.SelectedValue > 0 Then
                    dtModel = Me._objWingTechReceving.getModelData(PSS.Data.Buisness.WingTech.WingTech.WingTech_Product_ID, Me._iCust_ID, Me.cboEndUserLocation.SelectedValue)

                    Misc.PopulateC1DropDownList(Me.cboEndUserASN_In_Sku, dtModel, "ASN_IN_SKU", "Model_ID")
                    'Me.cboEndUserASN_In_Sku.SelectedIndex = 0
                Else
                    MessageBox.Show("Please selet a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboEndUserLocation_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub
        Private Sub cboLocation_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedValueChanged
            Dim dtModel As DataTable

            Try

                If Me.cboLocation.SelectedValue > 0 Then
                    dtModel = Me._objWingTechReceving.getModelData(PSS.Data.Buisness.WingTech.WingTech.WingTech_Product_ID, Me._iCust_ID, Me.cboLocation.SelectedValue)

                    Misc.PopulateC1DropDownList(Me.cboASN_In_Sku, dtModel, "ASN_IN_SKU", "Model_ID")
                    'Me.cboASN_In_Sku.SelectedIndex = 0
                Else
                    MessageBox.Show("Please selet a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboLocation_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub
        Private Sub cboSeedStockASN_In_Sku_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSeedStockASN_In_Sku.SelectedValueChanged
            Try

                If Me.cboSeedStockASN_In_Sku.SelectedValue > 0 Then
                    Me.lblSeedStockPSSModel.Text = Me.cboSeedStockASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboSeedStockASN_In_Sku.SelectedValue)(0)("Model_Desc")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboSeedStockASN_In_Sku_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub
        Private Sub cboSeedstockLocation_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSeedStockLocation.SelectedValueChanged
            Dim dtModel As DataTable

            Try

                If Me.cboSeedStockLocation.SelectedValue > 0 Then
                    dtModel = Me._objWingTechReceving.getModelData(PSS.Data.Buisness.WingTech.WingTech.WingTech_Product_ID, Me._iCust_ID, Me.cboSeedStockLocation.SelectedValue)

                    Misc.PopulateC1DropDownList(Me.cboSeedStockASN_In_Sku, dtModel, "ASN_IN_SKU", "Model_ID")
                    'Me.cboASN_In_Sku.SelectedIndex = 0
                Else
                    MessageBox.Show("Please selet a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboSeedStockLocation_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub
        Private Sub chkBoxByRMA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxByRMA.CheckedChanged
            Try
                If Me.chkBoxByRMA.Checked Then
                    Me.lblEndUserSN.Text = "RMA No:"
                    Me.chkBoxByRMA.ForeColor = Color.Blue
                Else
                    Me.lblEndUserSN.Text = "SN (IMEI):"
                    Me.chkBoxByRMA.ForeColor = Color.Black
                End If

                Me.txtEndUserSN.Text = "" : Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkBoxByRMA_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function GoEndUserValidation(ByVal RecvDT As DataTable, ByVal strSN As String, ByVal iMaxQty As Integer) As String

            Dim RetMsg As String = ""
            Dim row As DataRow
            Dim foundRow() As DataRow

            Try
                strSN = strSN.Replace("'", "''") ': strSku = strSku.Replace("'", "''")

                If RecvDT.Rows.Count = iMaxQty Then RetMsg &= "Box is full (max qty=" & iMaxQty.ToString & "), can't receive more." & Environment.NewLine

                'RecID, SN, SKU, PSS_Model, Customer, Loc, wb_id
                foundRow = RecvDT.Select("SN='" & strSN & "'")
                If foundRow.Length > 0 Then RetMsg &= "Device '" & strSN & "' already received." & Environment.NewLine

                'foundRow = RecvDT.Select("SKU='" & strSku & "'")  
                'If foundRow.Length = 0 Then RetMsg &= "Not the same Sku." & Environment.NewLine

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetMsg = ex.ToString
            End Try

            Return RetMsg

        End Function
        Private Function GoSeedStockValidation(ByVal RecvDT As DataTable, ByVal strSN As String, ByVal strSku As String, _
                                            ByVal iMaxQty As Integer) As String

            Dim RetMsg As String = ""
            Dim row As DataRow
            Dim foundRow() As DataRow

            Try
                strSN = strSN.Replace("'", "''") : strSku = strSku.Replace("'", "''")

                If RecvDT.Rows.Count = iMaxQty Then RetMsg &= "Box is full (max qty=" & iMaxQty.ToString & "), can't receive more." & Environment.NewLine

                'RecID, SN, SKU, PSS_Model, Customer, Loc, wb_id
                foundRow = RecvDT.Select("SN='" & strSN & "'")
                If foundRow.Length > 0 Then RetMsg &= "Device '" & strSN & "' already received." & Environment.NewLine

                foundRow = RecvDT.Select("SKU='" & strSku & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same Sku." & Environment.NewLine

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetMsg = ex.ToString
            End Try

            Return RetMsg

        End Function
        Private Function GoValidation(ByVal RecvDT As DataTable, ByVal strSN As String, ByVal strSku As String, _
                                     ByVal strRepairProgramType As String, ByVal strPlantID As String, _
                                     ByVal strPoNumber As String, ByVal iMaxQty As Integer) As String

            Dim RetMsg As String = ""
            Dim row As DataRow
            Dim foundRow() As DataRow

            Try
                strSN = strSN.Replace("'", "''") : strSku = strSku.Replace("'", "''") : strRepairProgramType = strRepairProgramType.Replace("'", "''")
                strPlantID = strPlantID.Replace("'", "''") : strPoNumber = strPoNumber.Replace("'", "''")

                If RecvDT.Rows.Count = iMaxQty Then RetMsg &= "Box is full (max qty=" & iMaxQty.ToString & "), can't receive more." & Environment.NewLine

                'RecID, SN, SKU, PSS_Model, PlantID, RepairProgramType, FaultCodeDefinition, PO_Number, Customer, Loc, wb_id
                foundRow = RecvDT.Select("SN='" & strSN & "'")
                If foundRow.Length > 0 Then RetMsg &= "Device '" & strSN & "' already received." & Environment.NewLine

                foundRow = RecvDT.Select("SKU='" & strSku & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same Sku." & Environment.NewLine

                foundRow = RecvDT.Select("PlantID='" & strPlantID & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same PlantID." & Environment.NewLine

                foundRow = RecvDT.Select("RepairProgramType='" & strRepairProgramType & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same RepairProgramType." & Environment.NewLine

                foundRow = RecvDT.Select("PO_Number='" & strPoNumber & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same PoNumber." & Environment.NewLine

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetMsg = ex.ToString
            End Try

            Return RetMsg

        End Function
        Private Function IsReceivedUnshipped(ByVal iLoc_ID As Integer, ByVal strSN As String) As Boolean
            Dim dt As DataTable

            Try
                dt = Me._objWingTechReceving.getReceivedUnshipped(iLoc_ID, strSN)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsReceivedUnshipped", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function
        Private Function IsSkuAndPssiModelMatched(ByVal dt As DataTable, ByRef iModel_ID As Integer, ByRef strASN_IN_SKU As String, ByRef strModel_Desc As String) As Boolean
            Dim row As DataRow
            Dim bRet As Boolean = False
            'Model_ID,E.ASN_IN_SKU,E.Model_Desc 
            Try
                For Each row In dt.Rows 'should be 1 record 
                    If Not row.IsNull("Model_ID") AndAlso Convert.ToString(row("Model_ID")).Length > 0 _
                      AndAlso Not row.IsNull("ASN_IN_SKU") AndAlso Convert.ToString(row("ASN_IN_SKU")).Length > 0 _
                      AndAlso Not row.IsNull("Item_SKU") AndAlso Convert.ToString(row("Item_SKU")).Length > 0 _
                      AndAlso Not row.IsNull("Model_Desc") AndAlso Convert.ToString(row("Model_Desc")).Length > 0 Then 'E.ASN_IN_SKU,E.Model_Desc,E.Model_MotoSku
                        iModel_ID = Convert.ToInt32(row("Model_ID"))
                        strASN_IN_SKU = Convert.ToString(row("ASN_IN_SKU"))
                        strModel_Desc = Convert.ToString(row("Model_Desc"))
                        bRet = True
                    End If
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsSkuAndPssiModelMatched", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Return bRet

        End Function
        Private Function IsValidWarranty(ByVal dt As DataTable, ByRef iWrtyFlag As Integer, ByRef strWrty_Desc As String) As Boolean
            Dim row As DataRow
            Dim bRet As Boolean = False

            '1= In Warranty, IW; 0 = Out of Warranty, OW
            Try
                For Each row In dt.Rows
                    If Not row.IsNull("Warranty_Desc") AndAlso (Convert.ToString(row("Warranty_Desc")).Trim.ToUpper = "In Warranty".ToUpper OrElse Convert.ToString(row("Warranty_Desc")).Trim.ToUpper = "IW".ToUpper) Then
                        iWrtyFlag = 1
                        strWrty_Desc = Convert.ToString(row("Warranty_Desc")).Trim.ToUpper
                        bRet = True
                    ElseIf Not row.IsNull("Warranty_Desc") AndAlso (Convert.ToString(row("Warranty_Desc")).Trim.ToUpper = "Out of Warranty".ToUpper OrElse Convert.ToString(row("Warranty_Desc")).Trim.ToUpper = "OW".ToUpper) Then
                        iWrtyFlag = 0
                        strWrty_Desc = Convert.ToString(row("Warranty_Desc")).Trim.ToUpper
                        bRet = True
                    End If
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsValidWarranty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Return bRet

        End Function
        Private Sub ProcessEndUserSN()
            Dim strSN As String = ""
            Dim strManufDate As String = ""
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strModel_Desc As String = ""
            Dim strASN_IN_SKU As String = ""
            Dim strASN_IN_ITEM_SKU As String = ""
            Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            ' Dim iProd_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_Product_ID
            Dim strRepairProgramType As String = ""
            Dim rowNew As DataRow
            Dim row As DataRow
            Dim iMaxQty As Integer = Me._objWingTech.getMaxReceivingBoxQty()

            Dim strCustLoc As String = ""
            Dim iWrtyFlag As Integer = 0
            Dim strWrty_Desc As String = ""
            Dim strPlantID As String = ""
            Dim strPoNumber As String = ""

            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            ' Dim strWiKoCustName As String = ""
            'Dim strAccountDOA As String = ""
            'Dim strAccountDOA_Code As String = ""

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "WingTech EndUser Receiving"

            Try
                Me.Cursor = Cursors.WaitCursor

                strSN = Me.txtEndUserSN.Text.Trim


                Me._iEndUserLoc_ID = Me.cboEndUserLocation.SelectedValue
                iModel_ID = Me.cboEndUserASN_In_Sku.SelectedValue

                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iEndUserLoc_ID > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not iModel_ID > 0 Then
                    MessageBox.Show("Please select a Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iEndUserLoc_ID, strSN) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.lblEndUserPSSModel.Text = Me.cboEndUserASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboEndUserASN_In_Sku.SelectedValue)(0)("Model_Desc") Then
                    MessageBox.Show("Mismatched PSS Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Me.chkBoxByRMA.Checked Then
                        dt = Me._objWingTechReceving.getEndUserReceivingData(Me._iCust_ID, Me._iEndUserLoc_ID, _
                                                                              PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeEndUser_ID, strSN, 2)
                    Else
                        dt = Me._objWingTechReceving.getEndUserReceivingData(Me._iCust_ID, Me._iEndUserLoc_ID, _
                                                                              PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeEndUser_ID, strSN, 1)
                    End If

                    'start to 
                    If dt.Rows.Count = 0 AndAlso Me.chkBoxByRMA.Checked Then
                        MessageBox.Show("Can't find the RMA Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count = 0 AndAlso Not Me.chkBoxByRMA.Checked Then
                        MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate EndUser RMA Records (SN or RMA).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else '=1

                        strModel_Desc = Me.lblEndUserPSSModel.Text.Trim
                        strASN_IN_SKU = Me.cboEndUserASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboEndUserASN_In_Sku.SelectedValue)(0)("ASN_IN_SKU")
                        If Not dt.Rows(0).IsNull("Item_Sku") Then strASN_IN_ITEM_SKU = dt.Rows(0).Item("Item_Sku")
                        If Me.chkBoxByRMA.Checked Then strSN = dt.Rows(0).Item("SN")

                        If Not strASN_IN_SKU.Trim.ToUpper = strASN_IN_ITEM_SKU.Trim.ToUpper Then 'Sku
                            MessageBox.Show("Invalid inbound RMA Item_Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            '  ElseIf Not IsSkuAndPssiModelMatched(dt, iModel_ID, strASN_IN_SKU, strModel_Desc) Then
                            '      MessageBox.Show("Not defined SKU and PSSI Model or invalid ASN SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            'ElseIf Not IsValidWarranty(dt, iWrtyFlag, strWrty_Desc) Then
                            '    MessageBox.Show("Invalid warranty or warranty is not defined (valid warranty of ASN data must be 'IN WARRANTY' or 'IW','OUT OF WARRANTY' or 'OW'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("Cust2PSSI_TrackNo") OrElse Convert.ToString(dt.Rows(0).Item("Cust2PSSI_TrackNo")).Trim.Length = 0 Then
                            MessageBox.Show("ASN data has no shipping track number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("RMA_Ship_Date_Text") OrElse Convert.ToString(dt.Rows(0).Item("RMA_Ship_Date_Text")).Trim.Length = 0 _
                                OrElse Not IsDate(Convert.ToString(dt.Rows(0).Item("RMA_Ship_Date_Text"))) Then
                            MessageBox.Show("RMA data has no valid shipped date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("Customer_Name") OrElse Convert.ToString(dt.Rows(0).Item("Customer_Name")).Trim.Length = 0 Then
                            MessageBox.Show("RMA data has no end-user name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("Full_Address") OrElse Convert.ToString(dt.Rows(0).Item("Full_Address")).Trim.Length = 0 Then
                            MessageBox.Show("RMA data has no end-user address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            iWO_ID = Convert.ToInt32(dt.Rows(0).Item("WO_ID"))
                            iEW_ID = Convert.ToInt32(dt.Rows(0).Item("EW_ID"))
                            strCustLoc = Convert.ToString(dt.Rows(0).Item("Customer"))

                            iTray_ID = Me._objWingTechReceving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                            If Not iWO_ID > 0 Then
                                MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Not iTray_ID > 0 Then
                                MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else 'Ready to receive 
                                iWrtyFlag = 1 'EndUser devices are end user's claim which must be IN WARRANTY, so =1

                                'Create WH box at start-------------------------------
                                If Me._EndUserRecvDT.Rows.Count = 0 Then 'first device
                                    Me._iEndUserWB_ID = 0 : Me._iEndUserRecID = 0
                                    Me._strEndUserRecvBoxName = Me._objWingTechReceving.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, Me._iEndUserWB_ID)
                                    Me.lblEndUserBoxName.Text = Me._strEndUserRecvBoxName
                                    Me.txtEndUserMaxBoxQty.Text = iMaxQty.ToString
                                Else 'validate with recev data
                                    Dim strValidatedMsg As String = Me.GoEndUserValidation(Me._EndUserRecvDT, strSN, iMaxQty).Trim
                                    If strValidatedMsg.Length > 0 Then
                                        MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()
                                        Exit Sub
                                    End If
                                End If

                                'receiving now------------------------
                                bReceived = Me._objWingTechReceving.ReceiveDataIntoSystem(Me._iEndUserLoc_ID, iWO_ID, iModel_ID, strSN, strManufDate, strDateTime, _
                                                                                           strWorkDate, iEW_ID, iShift_ID, iTray_ID, Me._iEndUserWB_ID, iWrtyFlag)
                                If bReceived Then
                                    'Update received dt
                                    'RecID, SN, SKU, PSS_Model, End_User, Address, Customer, Loc, Wrty, WrtyFlag, Model_ID, wb_id
                                    Me._iEndUserRecID += 1
                                    rowNew = Me._EndUserRecvDT.NewRow
                                    rowNew("RecID") = Me._iEndUserRecID : rowNew("SN") = strSN : rowNew("SKU") = strASN_IN_SKU : rowNew("PSS_Model") = strModel_Desc
                                    rowNew("End_User") = dt.Rows(0).Item("Customer_Name") : rowNew("Address") = dt.Rows(0).Item("Full_Address")
                                    rowNew("Customer") = dt.Rows(0).Item("Customer") : rowNew("Loc") = dt.Rows(0).Item("Loc")
                                    rowNew("Wrty") = strWrty_Desc : rowNew("WrtyFlag") = iWrtyFlag : rowNew("Model_ID") = iModel_ID
                                    rowNew("wb_id") = Me._iEndUserWB_ID

                                    Me._EndUserRecvDT.Rows.Add(rowNew)

                                    'Bind received data
                                    With Me.tdgEndUserDeviceData
                                        .DataSource = Me._EndUserRecvDT.DefaultView

                                        For Each dbgc In .Splits(0).DisplayColumns
                                            dbgc.Locked = True
                                            dbgc.AutoSize()
                                        Next dbgc
                                        '.Splits(0).DisplayColumns("Sku").Width = 80
                                    End With
                                    Me.txtEndUserReceivedQty.Text = Me._EndUserRecvDT.Rows.Count

                                    Me.cboEndUserASN_In_Sku.Enabled = False
                                    Me.txtEndUserSN.Text = "" : Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()
                                Else
                                    MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessEndUserSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                dt = Nothing : dtModel = Nothing
            End Try
        End Sub
        Private Sub ProcessEndUserSN_AllowReceivingMixedSKUsInBox()
            Dim strSN As String = ""
            Dim strManufDate As String = ""
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strModel_Desc As String = ""
            Dim strASN_IN_SKU As String = ""
            Dim strASN_IN_ITEM_SKU As String = ""
            Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            ' Dim iProd_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_Product_ID
            Dim strRepairProgramType As String = ""
            Dim rowNew As DataRow
            Dim row As DataRow
            Dim iMaxQty As Integer = Me._objWingTech.getMaxReceivingBoxQty

            Dim strCustLoc As String = ""
            Dim iWrtyFlag As Integer = 0
            Dim strWrty_Desc As String = ""
            Dim strPlantID As String = ""
            Dim strPoNumber As String = ""

            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            ' Dim strWiKoCustName As String = ""
            'Dim strAccountDOA As String = ""
            'Dim strAccountDOA_Code As String = ""

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "WingTech EndUser Receiving"

            Try
                Me.Cursor = Cursors.WaitCursor
                strSN = Me.txtEndUserSN.Text.Trim

                Me._iEndUserLoc_ID = Me.cboEndUserLocation.SelectedValue

                ' iModel_ID = Me.cboEndUserASN_In_Sku.SelectedValue

                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iEndUserLoc_ID > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'ElseIf Not iModel_ID > 0 Then
                    '    MessageBox.Show("Please select a Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iEndUserLoc_ID, strSN) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'ElseIf Not Me.lblSeedStockPSSModel.Text = Me.cboSeedStockASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboSeedStockASN_In_Sku.SelectedValue)(0)("Model_Desc") Then
                    '    MessageBox.Show("Mismatched PSS Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    'dt = Me._objWingTechReceving.getEndUserReceivingData(Me._iCust_ID, Me._iEndUserLoc_ID, PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeEndUser_ID, strSN)

                    'start to 
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else '=1
                        'strModel_Desc = Me.lblSeedStockPSSModel.Text.Trim
                        'strASN_IN_SKU = Me.cboSeedStockASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboSeedStockASN_In_Sku.SelectedValue)(0)("ASN_IN_SKU")
                        'If Not dt.Rows(0).IsNull("Item_Sku") Then strASN_IN_ITEM_SKU = dt.Rows(0).Item("Item_Sku")
                        'If Not strASN_IN_SKU.Trim.ToUpper = strASN_IN_ITEM_SKU.Trim.ToUpper Then 'Sku
                        '    MessageBox.Show("Invalid inbound Item_Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) 
                        If Not IsSkuAndPssiModelMatched(dt, iModel_ID, strASN_IN_SKU, strModel_Desc) Then
                            MessageBox.Show("Not defined SKU and PSSI Model or invalid ASN SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Not IsValidWarranty(dt, iWrtyFlag, strWrty_Desc) Then
                            MessageBox.Show("Invalid warranty or warranty is not defined (valid warranty of ASN data must be 'IN WARRANTY' or 'IW','OUT OF WARRANTY' or 'OW'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("Cust2PSSI_TrackNo") OrElse Convert.ToString(dt.Rows(0).Item("Cust2PSSI_TrackNo")).Trim.Length = 0 Then
                            MessageBox.Show("ASN data has no shipping track number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("RMA_Ship_Date_Text") OrElse Convert.ToString(dt.Rows(0).Item("RMA_Ship_Date_Text")).Trim.Length = 0 _
                                OrElse Not IsDate(Convert.ToString(dt.Rows(0).Item("RMA_Ship_Date_Text"))) Then
                            MessageBox.Show("ASN data has no valid shipped date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("Customer_Name") OrElse Convert.ToString(dt.Rows(0).Item("Customer_Name")).Trim.Length = 0 Then
                            MessageBox.Show("ASN data has no end-user name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf dt.Rows(0).IsNull("Full_Address") OrElse Convert.ToString(dt.Rows(0).Item("Full_Address")).Trim.Length = 0 Then
                            MessageBox.Show("ASN data has no end-user address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            iWO_ID = Convert.ToInt32(dt.Rows(0).Item("WO_ID"))
                            iEW_ID = Convert.ToInt32(dt.Rows(0).Item("EW_ID"))
                            strCustLoc = Convert.ToString(dt.Rows(0).Item("Customer"))

                            iTray_ID = Me._objWingTechReceving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                            If Not iWO_ID > 0 Then
                                MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Not iTray_ID > 0 Then
                                MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else 'Ready to receive 

                                'Create WH box at start-------------------------------
                                If Me._EndUserRecvDT.Rows.Count = 0 Then 'first device
                                    Me._iEndUserWB_ID = 0 : Me._iEndUserRecID = 0
                                    Me._strEndUserRecvBoxName = Me._objWingTechReceving.CreateWarehouseBoxName(0, iWrtyFlag, Me._iEndUserWB_ID) 'allowmixed model in a box, so use 0  for iModel_ID
                                    Me.lblEndUserBoxName.Text = Me._strEndUserRecvBoxName
                                    Me.txtEndUserMaxBoxQty.Text = iMaxQty.ToString
                                Else 'validate with recev data
                                    Dim strValidatedMsg As String = Me.GoEndUserValidation(Me._EndUserRecvDT, strSN, iMaxQty).Trim
                                    If strValidatedMsg.Length > 0 Then
                                        MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()
                                        Exit Sub
                                    End If
                                End If

                                'receiving now------------------------
                                bReceived = Me._objWingTechReceving.ReceiveDataIntoSystem(Me._iEndUserLoc_ID, iWO_ID, iModel_ID, strSN, strManufDate, strDateTime, _
                                                                                           strWorkDate, iEW_ID, iShift_ID, iTray_ID, Me._iEndUserWB_ID, iWrtyFlag)
                                If bReceived Then
                                    'Update received dt
                                    'RecID, SN, SKU, PSS_Model, End_User, Address, Customer, Loc, Wrty, WrtyFlag, Model_ID, wb_id
                                    Me._iEndUserRecID += 1
                                    rowNew = Me._EndUserRecvDT.NewRow
                                    rowNew("RecID") = Me._iEndUserRecID : rowNew("SN") = strSN : rowNew("SKU") = strASN_IN_SKU : rowNew("PSS_Model") = strModel_Desc
                                    rowNew("End_User") = dt.Rows(0).Item("Customer_Name") : rowNew("Address") = dt.Rows(0).Item("Full_Address")
                                    rowNew("Customer") = dt.Rows(0).Item("Customer") : rowNew("Loc") = dt.Rows(0).Item("Loc")
                                    rowNew("Wrty") = strWrty_Desc : rowNew("WrtyFlag") = iWrtyFlag : rowNew("Model_ID") = iModel_ID
                                    rowNew("wb_id") = Me._iEndUserWB_ID

                                    Me._EndUserRecvDT.Rows.Add(rowNew)

                                    'Bind received data
                                    With Me.tdgEndUserDeviceData
                                        .DataSource = Me._EndUserRecvDT.DefaultView

                                        For Each dbgc In .Splits(0).DisplayColumns
                                            dbgc.Locked = True
                                            dbgc.AutoSize()
                                        Next dbgc
                                        '.Splits(0).DisplayColumns("Sku").Width = 80
                                    End With
                                    Me.txtEndUserReceivedQty.Text = Me._EndUserRecvDT.Rows.Count

                                    Me.txtEndUserSN.Text = "" : Me.txtEndUserSN.SelectAll() : Me.txtEndUserSN.Focus()
                                Else
                                    MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessEndUserSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                dt = Nothing : dtModel = Nothing
            End Try
        End Sub
        Private Sub ProcessSeedStockSN()
            Dim strSN As String = ""
            Dim strManufDate As String = ""
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strModel_Desc As String = ""
            Dim strASN_IN_SKU As String = ""
            Dim strASN_IN_ITEM_SKU As String = ""
            Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            ' Dim iProd_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_Product_ID
            Dim strRepairProgramType As String = ""
            Dim rowNew As DataRow
            Dim row As DataRow
            Dim iMaxQty As Integer = Me._objWingTech.getMaxReceivingBoxQty

            Dim strCustLoc As String = ""
            Dim iWrtyFlag As Integer = 0
            Dim strPlantID As String = ""
            Dim strPoNumber As String = ""

            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            ' Dim strWiKoCustName As String = ""
            'Dim strAccountDOA As String = ""
            'Dim strAccountDOA_Code As String = ""

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "WingTech SeedStock Receiving"

            Try
                Me.Cursor = Cursors.WaitCursor
                strSN = Me.txtSeedStockSN.Text.Trim

                Me._iSeedStockLoc_ID = Me.cboSeedStockLocation.SelectedValue
                iModel_ID = Me.cboSeedStockASN_In_Sku.SelectedValue

                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iSeedStockLoc_ID > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not iModel_ID > 0 Then
                    MessageBox.Show("Please select a Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iSeedStockLoc_ID, strSN) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.lblSeedStockPSSModel.Text = Me.cboSeedStockASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboSeedStockASN_In_Sku.SelectedValue)(0)("Model_Desc") Then
                    MessageBox.Show("Mismatched PSS Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    dt = Me._objWingTechReceving.getSeedStockReceivingData(Me._iCust_ID, Me._iSeedStockLoc_ID, PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeSeedStock_ID, strSN)

                    'start to 
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else '=1

                        strModel_Desc = Me.lblSeedStockPSSModel.Text.Trim
                        strASN_IN_SKU = Me.cboSeedStockASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboSeedStockASN_In_Sku.SelectedValue)(0)("ASN_IN_SKU")
                        If Not dt.Rows(0).IsNull("Item_Sku") Then strASN_IN_ITEM_SKU = dt.Rows(0).Item("Item_Sku")

                        If Not strASN_IN_SKU.Trim.ToUpper = strASN_IN_ITEM_SKU.Trim.ToUpper Then 'Sku
                            MessageBox.Show("Invalid inbound Item_Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            iWO_ID = Convert.ToInt32(dt.Rows(0).Item("WO_ID"))
                            iEW_ID = Convert.ToInt32(dt.Rows(0).Item("EW_ID"))
                            strCustLoc = Convert.ToString(dt.Rows(0).Item("Customer"))

                            iTray_ID = Me._objWingTechReceving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                            If Not iWO_ID > 0 Then
                                MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Not iTray_ID > 0 Then
                                MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else 'Ready to receive 
                                iWrtyFlag = 1 'Seedstock devices are new, so =1

                                'Create WH box at start-------------------------------
                                If Me._SeedStockRecvDT.Rows.Count = 0 Then 'first device
                                    Me._iSeedStockWB_ID = 0 : Me._iSeedStockRecID = 0
                                    Me._strSeedStockRecvBoxName = Me._objWingTechReceving.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, Me._iSeedStockWB_ID)
                                    Me.lblSeedStockBoxName.Text = Me._strSeedStockRecvBoxName
                                    Me.txtSeedStockMaxBoxQty.Text = iMaxQty.ToString
                                Else 'validate with recev data
                                    Dim strValidatedMsg As String = Me.GoSeedStockValidation(Me._SeedStockRecvDT, strSN, strASN_IN_ITEM_SKU, iMaxQty).Trim
                                    If strValidatedMsg.Length > 0 Then
                                        MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus()
                                        Exit Sub
                                    End If
                                End If

                                'receiving now------------------------
                                bReceived = Me._objWingTechReceving.ReceiveDataIntoSystem(Me._iSeedStockLoc_ID, iWO_ID, iModel_ID, strSN, strManufDate, strDateTime, _
                                                                                           strWorkDate, iEW_ID, iShift_ID, iTray_ID, Me._iSeedStockWB_ID, iWrtyFlag)
                                If bReceived Then
                                    'Update received dt
                                    'RecID, SN, SKU, PSS_Model, Customer, Loc, wb_id
                                    Me._iSeedStockRecID += 1
                                    rowNew = Me._SeedStockRecvDT.NewRow
                                    rowNew("RecID") = Me._iSeedStockRecID : rowNew("SN") = strSN : rowNew("SKU") = strASN_IN_SKU : rowNew("PSS_Model") = strModel_Desc
                                    rowNew("Customer") = dt.Rows(0).Item("Customer")
                                    rowNew("Loc") = dt.Rows(0).Item("Loc") : rowNew("wb_id") = Me._iSeedStockWB_ID
                                    Me._SeedStockRecvDT.Rows.Add(rowNew)

                                    'Bind received data
                                    With Me.tdgSeedStockDeviceData
                                        .DataSource = Me._SeedStockRecvDT.DefaultView

                                        For Each dbgc In .Splits(0).DisplayColumns
                                            dbgc.Locked = True
                                            dbgc.AutoSize()
                                        Next dbgc
                                        '.Splits(0).DisplayColumns("Sku").Width = 80
                                    End With
                                    Me.txtSeedStockReceivedQty.Text = Me._SeedStockRecvDT.Rows.Count

                                    Me.txtSeedStockSN.Text = "" : Me.txtSeedStockSN.SelectAll() : Me.txtSeedStockSN.Focus()
                                Else
                                    MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSeedStockSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                dt = Nothing : dtModel = Nothing
            End Try
        End Sub
        Private Sub ProcessSN()
            Dim strSN As String = ""
            Dim strManufDate As String = ""
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strModel_Desc As String = ""
            Dim strASN_IN_SKU As String = ""
            Dim strASN_IN_ITEM_SKU As String = ""
            Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            ' Dim iProd_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_Product_ID
            Dim strRepairProgramType As String = ""
            Dim rowNew As DataRow
            Dim row As DataRow
            Dim iMaxQty As Integer = Me._objWingTech.getMaxReceivingBoxQty

            Dim strCustLoc As String = ""
            Dim iWrtyFlag As Integer = 0
            Dim strPlantID As String = ""
            Dim strPoNumber As String = ""

            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            ' Dim strWiKoCustName As String = ""
            'Dim strAccountDOA As String = ""
            'Dim strAccountDOA_Code As String = ""

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "WingTech Receiving"

            Try
                Me.Cursor = Cursors.WaitCursor
                strSN = Me.txtSN.Text.Trim ': strManufDate = Me.txtManufDate.Text.Trim

                Me._iLoc_ID = Me.cboLocation.SelectedValue
                iModel_ID = Me.cboASN_In_Sku.SelectedValue

                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iLoc_ID > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not iModel_ID > 0 Then
                    MessageBox.Show("Please select a Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iLoc_ID, strSN) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSN.SelectAll()
                ElseIf Not Me.lblPSSModel.Text = Me.cboASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboASN_In_Sku.SelectedValue)(0)("Model_Desc") Then
                    MessageBox.Show("Mismatched PSS Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    dt = Me._objWingTechReceving.getReceivingData(Me._iCust_ID, Me._iLoc_ID, PSS.Data.Buisness.WingTech.WingTech.WingTech_OrderTypeBulk_ID, strSN)

                    'start to 
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else '=1

                        strModel_Desc = Me.lblPSSModel.Text.Trim
                        strASN_IN_SKU = Me.cboASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboASN_In_Sku.SelectedValue)(0)("ASN_IN_SKU")
                        If Not dt.Rows(0).IsNull("Item_Sku") Then strASN_IN_ITEM_SKU = dt.Rows(0).Item("Item_Sku")
                        If Not dt.Rows(0).IsNull("RepairProgramType") Then strRepairProgramType = dt.Rows(0).Item("RepairProgramType")
                        If Not dt.Rows(0).IsNull("PlantID") Then strPlantID = dt.Rows(0).Item("PlantID")
                        If Not dt.Rows(0).IsNull("PoNumber") Then strPoNumber = dt.Rows(0).Item("PoNumber")

                        If Not strASN_IN_SKU.Trim.ToUpper = strASN_IN_ITEM_SKU.Trim.ToUpper Then 'Sku
                            MessageBox.Show("Invalid inbound Item_Sku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Not PSS.Data.Buisness.WingTech.WingTech.WingTech_RepairProgramType.Contains(strRepairProgramType.Trim.ToUpper) Then 'RepairProgramType
                            MessageBox.Show("Invalid RepairProgramType.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf strPlantID.Trim.Length = 0 Then 'PlantID
                            MessageBox.Show("No Plant ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf strPoNumber.Trim.Length = 0 Then 'Po Number
                            MessageBox.Show("No PO number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            iWO_ID = Convert.ToInt32(dt.Rows(0).Item("WO_ID"))
                            iEW_ID = Convert.ToInt32(dt.Rows(0).Item("EW_ID"))
                            strCustLoc = Convert.ToString(dt.Rows(0).Item("Customer"))

                            iTray_ID = Me._objWingTechReceving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                            If Not iWO_ID > 0 Then
                                MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Not iTray_ID > 0 Then
                                MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else 'Ready to receive 
                                If strRepairProgramType.Trim.ToUpper = "OUT OF WARRANTY" Then
                                    iWrtyFlag = 0
                                ElseIf strRepairProgramType.Trim.ToUpper = "IN WARRANTY" Then
                                    iWrtyFlag = 1
                                ElseIf strRepairProgramType.Trim.ToUpper = "DOA" Then
                                    iWrtyFlag = 2
                                End If

                                'Create WH box at start-------------------------------
                                If Me._RecvDT.Rows.Count = 0 Then 'first device
                                    Me._iWB_ID = 0 : Me._iRecID = 0
                                    Me._strRecvBoxName = Me._objWingTechReceving.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, Me._iWB_ID)
                                    Me.lblBoxName.Text = Me._strRecvBoxName
                                    Me.txtMaxBoxQty.Text = iMaxQty.ToString
                                Else 'validate with recev data
                                    Dim strValidatedMsg As String = Me.GoValidation(Me._RecvDT, strSN, strASN_IN_ITEM_SKU, strRepairProgramType, strPlantID, strPoNumber, iMaxQty).Trim
                                    If strValidatedMsg.Length > 0 Then
                                        MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                                        Me.txtSN.Text = String.Empty
                                        Me.txtSN.Focus()
                                        Exit Sub
                                    End If
                                End If

                                'receiving now------------------------
                                bReceived = Me._objWingTechReceving.ReceiveDataIntoSystem(Me._iLoc_ID, iWO_ID, iModel_ID, strSN, strManufDate, strDateTime, _
                                                                                           strWorkDate, iEW_ID, iShift_ID, iTray_ID, Me._iWB_ID, iWrtyFlag)
                                If bReceived Then
                                    'Update received dt
                                    'RecID, SN, SKU, PSS_Model, PlantID, RepairProgramType, FaultCodeDefinition, PO_Number, Customer, Loc, wb_id
                                    Me._iRecID += 1
                                    rowNew = Me._RecvDT.NewRow
                                    rowNew("RecID") = Me._iRecID : rowNew("SN") = strSN : rowNew("SKU") = strASN_IN_SKU : rowNew("PSS_Model") = strModel_Desc
                                    rowNew("PlantID") = strPlantID : rowNew("RepairProgramType") = strRepairProgramType : rowNew("FaultCodeDefinition") = dt.Rows(0).Item("FaultCodeDefinition")
                                    rowNew("PO_Number") = dt.Rows(0).Item("PoNumber") : rowNew("Customer") = dt.Rows(0).Item("Customer")
                                    rowNew("Loc") = dt.Rows(0).Item("Loc") : rowNew("wb_id") = Me._iWB_ID
                                    Me._RecvDT.Rows.Add(rowNew)

                                    'Bind received data
                                    With Me.tdgDeviceData
                                        .DataSource = Me._RecvDT.DefaultView

                                        For Each dbgc In .Splits(0).DisplayColumns
                                            dbgc.Locked = True
                                            dbgc.AutoSize()
                                        Next dbgc
                                        ' .Splits(0).DisplayColumns("Sku").Width = 80
                                    End With
                                    Me.txtReceivedQty.Text = Me._RecvDT.Rows.Count

                                    Me.txtSN.Text = String.Empty
                                    Me.txtSN.Focus()
                                Else
                                    MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                    End If
                    txtSN.SelectAll()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                dt = Nothing : dtModel = Nothing
            End Try
        End Sub
#Region "Tab ControlDrawItem and selected"
        '***************************************************************************************************************
        Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
            Try
                Dim g As Graphics = e.Graphics
                Dim tp As TabPage = TabControl1.TabPages(e.Index)
                Dim br As Brush
                Dim sf As New StringFormat()
                Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
                Dim xFont As Font
                sf.Alignment = StringAlignment.Center
                Dim strTitle As String = tp.Text
                'If the current index is the Selected Index, change the color
                If TabControl1.SelectedIndex = e.Index Then
                    'this is the background color of the tabpage
                    'you could make this a stndard color for the selected page
                    br = New SolidBrush(tp.BackColor)
                    'this is the background color of the tab page
                    g.FillRectangle(br, e.Bounds)
                    'this is the background color of the tab page
                    'you could make this a stndard color for the selected page
                    br = New SolidBrush(tp.ForeColor)
                    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                    xFont = New Font(TabControl1.Font, FontStyle.Bold)
                    g.DrawString(strTitle, xFont, br, r, sf)
                Else
                    'these are the standard colors for the unselected tab pages
                    br = New SolidBrush(Color.WhiteSmoke)
                    g.FillRectangle(br, e.Bounds)
                    br = New SolidBrush(Color.Black)
                    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                    xFont = New Font(TabControl1.Font, FontStyle.Regular)
                    g.DrawString(strTitle, xFont, br, r, sf)
                End If
            Catch ex As Exception
            End Try
        End Sub

        'Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        '    If TabControl1.SelectedTab Is Me.tabPrekit Then
        '        If Me.txtPrekitCardSN.Enabled AndAlso Me.txtPrekitInsertPN.Text.Trim.Length = 0 Then
        '            Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
        '            Me.txtPrekitInsertPN.Enabled = False
        '        End If
        '    ElseIf TabControl1.SelectedTab Is Me.tabOrder Then
        '        If Me.txtSIMCardSN.Enabled AndAlso Me.txtInsertPartNo.Text.Trim.Length = 0 Then
        '            Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
        '            Me.txtInsertPartNo.Enabled = False
        '        End If
        '    End If
        'End Sub
#End Region
        Private Sub txtEndUserSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEndUserSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtEndUserSN.Text.Trim.Length > 0 Then
                        Me.ProcessEndUserSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtEndUserSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub txtSeedStockSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSeedStockSN.KeyUp
            Try

                If e.KeyCode = Keys.Enter Then
                    If Me.txtSeedStockSN.Text.Trim.Length > 0 Then
                        Me.ProcessSeedStockSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSeedStockSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try

                If e.KeyCode = Keys.Enter Then
                    'If Me.txtSN.Text.Trim.Length > 0 OrElse Me.txtManufDate.Text.Trim.Length > 0 Then
                    '    Me.pnlReceived.Visible = False
                    'End If
                    'If Me.txtManufDate.Text.Trim.Length > 0 AndAlso Not Me.txtSN.Text.Trim.Length > 0 Then
                    '    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    'ElseIf Not Me.txtManufDate.Text.Trim.Length > 0 AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                    '    Me.txtManufDate.Text = "" : Me.txtManufDate.SelectAll() : Me.txtManufDate.Focus()
                    'End If

                    If Me.txtSN.Text.Trim.Length > 0 Then ' AndAlso Me.txtManufDate.Text.Trim.Length > 0 Then
                        Me.ProcessSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

    End Class
End Namespace
