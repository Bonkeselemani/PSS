Option Explicit On 

Imports PSS.Data.Buisness
Imports CrystalDecisions.CrystalReports.Engine

Namespace Gui
    Public Class SyxRec
        Inherits System.Windows.Forms.Form

        Private _objSyxRec As PSS.Data.Buisness.SyxReceivingShipping
        Private _objProdRec As PSS.Data.Production.Receiving
        Private _booLoadData As Boolean = False
        Private _iTrayID As Integer = 0
        Private _iAddUpdPD_ID As Integer = 0
        Private _strScreenName As String = "RECEIVING"

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objSyxRec = New PSS.Data.Buisness.SyxReceivingShipping()
            _objProdRec = New PSS.Data.Production.Receiving()
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
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents cboOpenWOrders As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpProdReceiving As System.Windows.Forms.TabPage
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents tpReceivedData As System.Windows.Forms.TabPage
        Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRefreshRecData As System.Windows.Forms.Button
        Friend WithEvents cboManufs As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cboCostCenters As C1.Win.C1List.C1Combo
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtRecComments As System.Windows.Forms.TextBox
        Friend WithEvents lblWOQty As System.Windows.Forms.Label
        Friend WithEvents chkHasBox As System.Windows.Forms.CheckBox
        Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnReprintSNLabel As System.Windows.Forms.Button
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents cboProducts As C1.Win.C1List.C1Combo
        Friend WithEvents tpChangeMfgSerial As System.Windows.Forms.TabPage
        Friend WithEvents txtNewMfgSerial As System.Windows.Forms.TextBox
        Friend WithEvents Label_NewMfgSerial As System.Windows.Forms.Label
        Friend WithEvents btnChangeMfgSerial As System.Windows.Forms.Button
        Friend WithEvents btnClosePallet As System.Windows.Forms.Button
        Friend WithEvents btnReopenPallet As System.Windows.Forms.Button
        Friend WithEvents cboOpenPallets As C1.Win.C1List.C1Combo
        Friend WithEvents lblPalletQty As System.Windows.Forms.Label
        Friend WithEvents Label_PalletQty As System.Windows.Forms.Label
        Friend WithEvents lblPalletReceived As System.Windows.Forms.Label
        Friend WithEvents Label_PalletReceived As System.Windows.Forms.Label
        Friend WithEvents lblModelReceived As System.Windows.Forms.Label
        Friend WithEvents Label_ModelReceived As System.Windows.Forms.Label
        Friend WithEvents lblModelQty As System.Windows.Forms.Label
        Friend WithEvents Label_ModelQty As System.Windows.Forms.Label
        Friend WithEvents btnRefreshPallet As System.Windows.Forms.Button
        Friend WithEvents tpgPalletData As System.Windows.Forms.TabPage
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtPalletID As System.Windows.Forms.TextBox
        Friend WithEvents dgPalletData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label_PSSSerialNumber As System.Windows.Forms.Label
        Friend WithEvents txtPSSSerial As System.Windows.Forms.TextBox
        Friend WithEvents Label_OldMfgSerial As System.Windows.Forms.Label
        Friend WithEvents lblOldMfgSerial As System.Windows.Forms.Label
        Friend WithEvents pnlAdjDisInPallet As System.Windows.Forms.Panel
        Friend WithEvents Label_ItemValue As System.Windows.Forms.Label
        Friend WithEvents txtItemValue As System.Windows.Forms.TextBox
        Friend WithEvents Label_ItemQty As System.Windows.Forms.Label
        Friend WithEvents txtItemQty As System.Windows.Forms.TextBox
        Friend WithEvents Label_ItemDesc As System.Windows.Forms.Label
        Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label_ItemNumber As System.Windows.Forms.Label
        Friend WithEvents txtItemNumber As System.Windows.Forms.TextBox
        Friend WithEvents btnAddPalletItems As System.Windows.Forms.Button
        Friend WithEvents btnPDClear As System.Windows.Forms.Button
        Friend WithEvents btnRefreshModelList As System.Windows.Forms.Button
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents gbReturnUnit As System.Windows.Forms.GroupBox
        Friend WithEvents lblProdType As System.Windows.Forms.Label
        Friend WithEvents lblPrevRepModel As System.Windows.Forms.Label
        Friend WithEvents lblPrevRepProdType As System.Windows.Forms.Label
        Friend WithEvents txtPrevRepPSN As System.Windows.Forms.TextBox
        Friend WithEvents lblPrevRepManuf As System.Windows.Forms.Label
        Friend WithEvents btnRec As System.Windows.Forms.Button
        Friend WithEvents chkBoxDamaged As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxRec))
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.cboOpenWOrders = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpProdReceiving = New System.Windows.Forms.TabPage()
            Me.btnRec = New System.Windows.Forms.Button()
            Me.gbReturnUnit = New System.Windows.Forms.GroupBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.lblPrevRepModel = New System.Windows.Forms.Label()
            Me.lblPrevRepProdType = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.txtPrevRepPSN = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.lblPrevRepManuf = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.btnRefreshModelList = New System.Windows.Forms.Button()
            Me.btnRefreshPallet = New System.Windows.Forms.Button()
            Me.lblModelReceived = New System.Windows.Forms.Label()
            Me.Label_ModelReceived = New System.Windows.Forms.Label()
            Me.lblModelQty = New System.Windows.Forms.Label()
            Me.Label_ModelQty = New System.Windows.Forms.Label()
            Me.lblPalletReceived = New System.Windows.Forms.Label()
            Me.Label_PalletReceived = New System.Windows.Forms.Label()
            Me.lblPalletQty = New System.Windows.Forms.Label()
            Me.Label_PalletQty = New System.Windows.Forms.Label()
            Me.cboOpenPallets = New C1.Win.C1List.C1Combo()
            Me.btnReopenPallet = New System.Windows.Forms.Button()
            Me.btnReprintSNLabel = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.chkHasBox = New System.Windows.Forms.CheckBox()
            Me.cboCostCenters = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblWOQty = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtRecComments = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.btnClosePallet = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboProducts = New C1.Win.C1List.C1Combo()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.cboManufs = New C1.Win.C1List.C1Combo()
            Me.tpChangeMfgSerial = New System.Windows.Forms.TabPage()
            Me.lblOldMfgSerial = New System.Windows.Forms.Label()
            Me.Label_OldMfgSerial = New System.Windows.Forms.Label()
            Me.Label_PSSSerialNumber = New System.Windows.Forms.Label()
            Me.txtPSSSerial = New System.Windows.Forms.TextBox()
            Me.btnChangeMfgSerial = New System.Windows.Forms.Button()
            Me.Label_NewMfgSerial = New System.Windows.Forms.Label()
            Me.txtNewMfgSerial = New System.Windows.Forms.TextBox()
            Me.tpReceivedData = New System.Windows.Forms.TabPage()
            Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefreshRecData = New System.Windows.Forms.Button()
            Me.tpgPalletData = New System.Windows.Forms.TabPage()
            Me.pnlAdjDisInPallet = New System.Windows.Forms.Panel()
            Me.btnPDClear = New System.Windows.Forms.Button()
            Me.Label_ItemValue = New System.Windows.Forms.Label()
            Me.txtItemValue = New System.Windows.Forms.TextBox()
            Me.Label_ItemQty = New System.Windows.Forms.Label()
            Me.txtItemQty = New System.Windows.Forms.TextBox()
            Me.Label_ItemDesc = New System.Windows.Forms.Label()
            Me.txtItemDesc = New System.Windows.Forms.TextBox()
            Me.Label_ItemNumber = New System.Windows.Forms.Label()
            Me.txtItemNumber = New System.Windows.Forms.TextBox()
            Me.btnAddPalletItems = New System.Windows.Forms.Button()
            Me.dgPalletData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPalletID = New System.Windows.Forms.TextBox()
            Me.btnReOpenWO = New System.Windows.Forms.Button()
            Me.lblProdType = New System.Windows.Forms.Label()
            Me.chkBoxDamaged = New System.Windows.Forms.CheckBox()
            CType(Me.cboOpenWOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpProdReceiving.SuspendLayout()
            Me.gbReturnUnit.SuspendLayout()
            CType(Me.cboOpenPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCostCenters, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboManufs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpChangeMfgSerial.SuspendLayout()
            Me.tpReceivedData.SuspendLayout()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgPalletData.SuspendLayout()
            Me.pnlAdjDisInPallet.SuspendLayout()
            CType(Me.dgPalletData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.Navy
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(416, 88)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(128, 24)
            Me.btnCloseWO.TabIndex = 3
            Me.btnCloseWO.Text = "Close Work Order"
            '
            'cboOpenWOrders
            '
            Me.cboOpenWOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenWOrders.AutoCompletion = True
            Me.cboOpenWOrders.AutoDropDown = True
            Me.cboOpenWOrders.AutoSelect = True
            Me.cboOpenWOrders.Caption = ""
            Me.cboOpenWOrders.CaptionHeight = 17
            Me.cboOpenWOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenWOrders.ColumnCaptionHeight = 17
            Me.cboOpenWOrders.ColumnFooterHeight = 17
            Me.cboOpenWOrders.ColumnHeaders = False
            Me.cboOpenWOrders.ContentHeight = 15
            Me.cboOpenWOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenWOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenWOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenWOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenWOrders.EditorHeight = 15
            Me.cboOpenWOrders.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboOpenWOrders.ItemHeight = 15
            Me.cboOpenWOrders.Location = New System.Drawing.Point(16, 88)
            Me.cboOpenWOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenWOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenWOrders.MaxLength = 32767
            Me.cboOpenWOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenWOrders.Name = "cboOpenWOrders"
            Me.cboOpenWOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenWOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenWOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenWOrders.Size = New System.Drawing.Size(288, 21)
            Me.cboOpenWOrders.TabIndex = 1
            Me.cboOpenWOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(16, 72)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(168, 16)
            Me.Label5.TabIndex = 88
            Me.Label5.Text = "Open Work Order # "
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpProdReceiving, Me.tpChangeMfgSerial, Me.tpReceivedData, Me.tpgPalletData})
            Me.TabControl1.Location = New System.Drawing.Point(16, 120)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(792, 440)
            Me.TabControl1.TabIndex = 2
            '
            'tpProdReceiving
            '
            Me.tpProdReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpProdReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRec, Me.gbReturnUnit, Me.btnRefreshModelList, Me.btnRefreshPallet, Me.lblModelReceived, Me.Label_ModelReceived, Me.lblModelQty, Me.Label_ModelQty, Me.lblPalletReceived, Me.Label_PalletReceived, Me.lblPalletQty, Me.Label_PalletQty, Me.cboOpenPallets, Me.btnReopenPallet, Me.btnReprintSNLabel, Me.Label8, Me.chkHasBox, Me.cboCostCenters, Me.Label11, Me.lblWOQty, Me.Label9, Me.Label6, Me.txtRecComments, Me.Label4, Me.cboModels, Me.Label2, Me.lblScanQty, Me.Label7, Me.txtSN, Me.btnClosePallet, Me.Label1, Me.cboProducts, Me.Label12, Me.cboManufs})
            Me.tpProdReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpProdReceiving.Name = "tpProdReceiving"
            Me.tpProdReceiving.Size = New System.Drawing.Size(784, 414)
            Me.tpProdReceiving.TabIndex = 0
            Me.tpProdReceiving.Text = "Production Receiving"
            '
            'btnRec
            '
            Me.btnRec.BackColor = System.Drawing.Color.Blue
            Me.btnRec.ForeColor = System.Drawing.Color.White
            Me.btnRec.Location = New System.Drawing.Point(360, 376)
            Me.btnRec.Name = "btnRec"
            Me.btnRec.Size = New System.Drawing.Size(64, 23)
            Me.btnRec.TabIndex = 191
            Me.btnRec.Text = "Receive"
            '
            'gbReturnUnit
            '
            Me.gbReturnUnit.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkBoxDamaged, Me.Label16, Me.lblPrevRepModel, Me.lblPrevRepProdType, Me.Label17, Me.txtPrevRepPSN, Me.Label14, Me.lblPrevRepManuf, Me.Label13})
            Me.gbReturnUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbReturnUnit.ForeColor = System.Drawing.Color.White
            Me.gbReturnUnit.Location = New System.Drawing.Point(-8, 256)
            Me.gbReturnUnit.Name = "gbReturnUnit"
            Me.gbReturnUnit.Size = New System.Drawing.Size(472, 112)
            Me.gbReturnUnit.TabIndex = 8
            Me.gbReturnUnit.TabStop = False
            Me.gbReturnUnit.Text = "Return Unit"
            Me.gbReturnUnit.Visible = False
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(8, 64)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(88, 16)
            Me.Label16.TabIndex = 196
            Me.Label16.Text = "Manufacture :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrevRepModel
            '
            Me.lblPrevRepModel.BackColor = System.Drawing.Color.White
            Me.lblPrevRepModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPrevRepModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrevRepModel.ForeColor = System.Drawing.Color.Black
            Me.lblPrevRepModel.Location = New System.Drawing.Point(104, 88)
            Me.lblPrevRepModel.Name = "lblPrevRepModel"
            Me.lblPrevRepModel.Size = New System.Drawing.Size(248, 16)
            Me.lblPrevRepModel.TabIndex = 199
            Me.lblPrevRepModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPrevRepProdType
            '
            Me.lblPrevRepProdType.BackColor = System.Drawing.Color.White
            Me.lblPrevRepProdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPrevRepProdType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrevRepProdType.ForeColor = System.Drawing.Color.Black
            Me.lblPrevRepProdType.Location = New System.Drawing.Point(104, 40)
            Me.lblPrevRepProdType.Name = "lblPrevRepProdType"
            Me.lblPrevRepProdType.Size = New System.Drawing.Size(248, 16)
            Me.lblPrevRepProdType.TabIndex = 195
            Me.lblPrevRepProdType.Tag = "0"
            Me.lblPrevRepProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(8, 88)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(88, 16)
            Me.Label17.TabIndex = 198
            Me.Label17.Text = "Model :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPrevRepPSN
            '
            Me.txtPrevRepPSN.Location = New System.Drawing.Point(104, 16)
            Me.txtPrevRepPSN.MaxLength = 30
            Me.txtPrevRepPSN.Name = "txtPrevRepPSN"
            Me.txtPrevRepPSN.Size = New System.Drawing.Size(248, 20)
            Me.txtPrevRepPSN.TabIndex = 1
            Me.txtPrevRepPSN.Text = ""
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(8, 40)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(88, 16)
            Me.Label14.TabIndex = 194
            Me.Label14.Text = "Product Type :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPrevRepManuf
            '
            Me.lblPrevRepManuf.BackColor = System.Drawing.Color.White
            Me.lblPrevRepManuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPrevRepManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrevRepManuf.ForeColor = System.Drawing.Color.Black
            Me.lblPrevRepManuf.Location = New System.Drawing.Point(104, 64)
            Me.lblPrevRepManuf.Name = "lblPrevRepManuf"
            Me.lblPrevRepManuf.Size = New System.Drawing.Size(248, 16)
            Me.lblPrevRepManuf.TabIndex = 197
            Me.lblPrevRepManuf.Tag = "0"
            Me.lblPrevRepManuf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(8, 16)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(88, 16)
            Me.Label13.TabIndex = 193
            Me.Label13.Text = "PSS S/N :"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRefreshModelList
            '
            Me.btnRefreshModelList.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnRefreshModelList.Location = New System.Drawing.Point(344, 72)
            Me.btnRefreshModelList.Name = "btnRefreshModelList"
            Me.btnRefreshModelList.Size = New System.Drawing.Size(56, 23)
            Me.btnRefreshModelList.TabIndex = 11
            Me.btnRefreshModelList.Text = "Refresh"
            '
            'btnRefreshPallet
            '
            Me.btnRefreshPallet.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnRefreshPallet.Location = New System.Drawing.Point(344, 40)
            Me.btnRefreshPallet.Name = "btnRefreshPallet"
            Me.btnRefreshPallet.Size = New System.Drawing.Size(56, 23)
            Me.btnRefreshPallet.TabIndex = 10
            Me.btnRefreshPallet.Text = "Refresh"
            '
            'lblModelReceived
            '
            Me.lblModelReceived.BackColor = System.Drawing.Color.Black
            Me.lblModelReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblModelReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelReceived.ForeColor = System.Drawing.Color.Lime
            Me.lblModelReceived.Location = New System.Drawing.Point(656, 208)
            Me.lblModelReceived.Name = "lblModelReceived"
            Me.lblModelReceived.Size = New System.Drawing.Size(104, 32)
            Me.lblModelReceived.TabIndex = 190
            Me.lblModelReceived.Text = "0"
            Me.lblModelReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_ModelReceived
            '
            Me.Label_ModelReceived.BackColor = System.Drawing.Color.Transparent
            Me.Label_ModelReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ModelReceived.ForeColor = System.Drawing.Color.White
            Me.Label_ModelReceived.Location = New System.Drawing.Point(640, 192)
            Me.Label_ModelReceived.Name = "Label_ModelReceived"
            Me.Label_ModelReceived.Size = New System.Drawing.Size(136, 16)
            Me.Label_ModelReceived.TabIndex = 189
            Me.Label_ModelReceived.Text = "Model Received Qty"
            Me.Label_ModelReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblModelQty
            '
            Me.lblModelQty.BackColor = System.Drawing.Color.Black
            Me.lblModelQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblModelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelQty.ForeColor = System.Drawing.Color.Lime
            Me.lblModelQty.Location = New System.Drawing.Point(504, 208)
            Me.lblModelQty.Name = "lblModelQty"
            Me.lblModelQty.Size = New System.Drawing.Size(104, 32)
            Me.lblModelQty.TabIndex = 188
            Me.lblModelQty.Text = "0"
            Me.lblModelQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_ModelQty
            '
            Me.Label_ModelQty.BackColor = System.Drawing.Color.Transparent
            Me.Label_ModelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ModelQty.ForeColor = System.Drawing.Color.White
            Me.Label_ModelQty.Location = New System.Drawing.Point(504, 192)
            Me.Label_ModelQty.Name = "Label_ModelQty"
            Me.Label_ModelQty.Size = New System.Drawing.Size(104, 16)
            Me.Label_ModelQty.TabIndex = 187
            Me.Label_ModelQty.Text = "Model Qty"
            Me.Label_ModelQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletReceived
            '
            Me.lblPalletReceived.BackColor = System.Drawing.Color.Black
            Me.lblPalletReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletReceived.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletReceived.Location = New System.Drawing.Point(656, 120)
            Me.lblPalletReceived.Name = "lblPalletReceived"
            Me.lblPalletReceived.Size = New System.Drawing.Size(104, 32)
            Me.lblPalletReceived.TabIndex = 186
            Me.lblPalletReceived.Text = "0"
            Me.lblPalletReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_PalletReceived
            '
            Me.Label_PalletReceived.BackColor = System.Drawing.Color.Transparent
            Me.Label_PalletReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PalletReceived.ForeColor = System.Drawing.Color.White
            Me.Label_PalletReceived.Location = New System.Drawing.Point(648, 104)
            Me.Label_PalletReceived.Name = "Label_PalletReceived"
            Me.Label_PalletReceived.Size = New System.Drawing.Size(128, 16)
            Me.Label_PalletReceived.TabIndex = 185
            Me.Label_PalletReceived.Text = "Pallet Received Qty"
            Me.Label_PalletReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletQty
            '
            Me.lblPalletQty.BackColor = System.Drawing.Color.Black
            Me.lblPalletQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletQty.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletQty.Location = New System.Drawing.Point(504, 120)
            Me.lblPalletQty.Name = "lblPalletQty"
            Me.lblPalletQty.Size = New System.Drawing.Size(104, 32)
            Me.lblPalletQty.TabIndex = 184
            Me.lblPalletQty.Text = "0"
            Me.lblPalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_PalletQty
            '
            Me.Label_PalletQty.BackColor = System.Drawing.Color.Transparent
            Me.Label_PalletQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PalletQty.ForeColor = System.Drawing.Color.White
            Me.Label_PalletQty.Location = New System.Drawing.Point(504, 104)
            Me.Label_PalletQty.Name = "Label_PalletQty"
            Me.Label_PalletQty.Size = New System.Drawing.Size(104, 16)
            Me.Label_PalletQty.TabIndex = 183
            Me.Label_PalletQty.Text = "Pallet Qty"
            Me.Label_PalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboOpenPallets
            '
            Me.cboOpenPallets.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenPallets.Caption = ""
            Me.cboOpenPallets.CaptionHeight = 17
            Me.cboOpenPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenPallets.ColumnCaptionHeight = 17
            Me.cboOpenPallets.ColumnFooterHeight = 17
            Me.cboOpenPallets.ContentHeight = 15
            Me.cboOpenPallets.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenPallets.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenPallets.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenPallets.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenPallets.EditorHeight = 15
            Me.cboOpenPallets.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenPallets.ItemHeight = 15
            Me.cboOpenPallets.Location = New System.Drawing.Point(96, 40)
            Me.cboOpenPallets.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenPallets.MaxDropDownItems = CType(5, Short)
            Me.cboOpenPallets.MaxLength = 32767
            Me.cboOpenPallets.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenPallets.Name = "cboOpenPallets"
            Me.cboOpenPallets.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenPallets.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenPallets.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenPallets.Size = New System.Drawing.Size(248, 21)
            Me.cboOpenPallets.TabIndex = 2
            Me.cboOpenPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnReopenPallet
            '
            Me.btnReopenPallet.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.btnReopenPallet.Enabled = False
            Me.btnReopenPallet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenPallet.ForeColor = System.Drawing.Color.White
            Me.btnReopenPallet.Location = New System.Drawing.Point(640, 288)
            Me.btnReopenPallet.Name = "btnReopenPallet"
            Me.btnReopenPallet.Size = New System.Drawing.Size(128, 24)
            Me.btnReopenPallet.TabIndex = 13
            Me.btnReopenPallet.Text = "Re-Open Pallet"
            '
            'btnReprintSNLabel
            '
            Me.btnReprintSNLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintSNLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintSNLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintSNLabel.Location = New System.Drawing.Point(504, 344)
            Me.btnReprintSNLabel.Name = "btnReprintSNLabel"
            Me.btnReprintSNLabel.Size = New System.Drawing.Size(128, 24)
            Me.btnReprintSNLabel.TabIndex = 14
            Me.btnReprintSNLabel.Text = "Reprint S/N Label"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(-8, 40)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(96, 16)
            Me.Label8.TabIndex = 178
            Me.Label8.Text = "Pallet Name :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkHasBox
            '
            Me.chkHasBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkHasBox.ForeColor = System.Drawing.Color.White
            Me.chkHasBox.Location = New System.Drawing.Point(8, 232)
            Me.chkHasBox.Name = "chkHasBox"
            Me.chkHasBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkHasBox.Size = New System.Drawing.Size(104, 16)
            Me.chkHasBox.TabIndex = 7
            Me.chkHasBox.Text = "Has Box"
            '
            'cboCostCenters
            '
            Me.cboCostCenters.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCostCenters.Caption = ""
            Me.cboCostCenters.CaptionHeight = 17
            Me.cboCostCenters.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCostCenters.ColumnCaptionHeight = 17
            Me.cboCostCenters.ColumnFooterHeight = 17
            Me.cboCostCenters.ContentHeight = 15
            Me.cboCostCenters.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCostCenters.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCostCenters.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCostCenters.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCostCenters.EditorHeight = 15
            Me.cboCostCenters.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCostCenters.ItemHeight = 15
            Me.cboCostCenters.Location = New System.Drawing.Point(96, 8)
            Me.cboCostCenters.MatchEntryTimeout = CType(2000, Long)
            Me.cboCostCenters.MaxDropDownItems = CType(5, Short)
            Me.cboCostCenters.MaxLength = 32767
            Me.cboCostCenters.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCostCenters.Name = "cboCostCenters"
            Me.cboCostCenters.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCostCenters.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCostCenters.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCostCenters.Size = New System.Drawing.Size(248, 21)
            Me.cboCostCenters.TabIndex = 1
            Me.cboCostCenters.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(-16, 8)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(104, 16)
            Me.Label11.TabIndex = 176
            Me.Label11.Text = "Cost Center :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWOQty
            '
            Me.lblWOQty.BackColor = System.Drawing.Color.Black
            Me.lblWOQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblWOQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWOQty.ForeColor = System.Drawing.Color.Lime
            Me.lblWOQty.Location = New System.Drawing.Point(504, 32)
            Me.lblWOQty.Name = "lblWOQty"
            Me.lblWOQty.Size = New System.Drawing.Size(104, 32)
            Me.lblWOQty.TabIndex = 175
            Me.lblWOQty.Text = "0"
            Me.lblWOQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(504, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(104, 16)
            Me.Label9.TabIndex = 174
            Me.Label9.Text = "Work Order Qty"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(-16, 168)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(104, 16)
            Me.Label6.TabIndex = 173
            Me.Label6.Text = "Comments :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRecComments
            '
            Me.txtRecComments.Location = New System.Drawing.Point(96, 168)
            Me.txtRecComments.MaxLength = 100
            Me.txtRecComments.Multiline = True
            Me.txtRecComments.Name = "txtRecComments"
            Me.txtRecComments.Size = New System.Drawing.Size(248, 56)
            Me.txtRecComments.TabIndex = 6
            Me.txtRecComments.Text = ""
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(-16, 376)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(104, 16)
            Me.Label4.TabIndex = 171
            Me.Label4.Text = "Manuf S/N :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(96, 72)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(248, 21)
            Me.cboModels.TabIndex = 3
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(-16, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 16)
            Me.Label2.TabIndex = 170
            Me.Label2.Text = "Model :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
            Me.lblScanQty.Location = New System.Drawing.Point(656, 32)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(104, 32)
            Me.lblScanQty.TabIndex = 105
            Me.lblScanQty.Text = "0"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(656, 16)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(96, 16)
            Me.Label7.TabIndex = 104
            Me.Label7.Text = "Qty by User"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(96, 376)
            Me.txtSN.MaxLength = 30
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(248, 20)
            Me.txtSN.TabIndex = 9
            Me.txtSN.Text = ""
            '
            'btnClosePallet
            '
            Me.btnClosePallet.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.btnClosePallet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClosePallet.ForeColor = System.Drawing.Color.White
            Me.btnClosePallet.Location = New System.Drawing.Point(504, 288)
            Me.btnClosePallet.Name = "btnClosePallet"
            Me.btnClosePallet.Size = New System.Drawing.Size(88, 24)
            Me.btnClosePallet.TabIndex = 12
            Me.btnClosePallet.Text = "Close Pallet"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(-8, 136)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 168
            Me.Label1.Text = "Manufacture :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProducts
            '
            Me.cboProducts.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProducts.Caption = ""
            Me.cboProducts.CaptionHeight = 17
            Me.cboProducts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProducts.ColumnCaptionHeight = 17
            Me.cboProducts.ColumnFooterHeight = 17
            Me.cboProducts.ContentHeight = 15
            Me.cboProducts.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProducts.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProducts.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProducts.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProducts.EditorHeight = 15
            Me.cboProducts.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboProducts.ItemHeight = 15
            Me.cboProducts.Location = New System.Drawing.Point(96, 104)
            Me.cboProducts.MatchEntryTimeout = CType(2000, Long)
            Me.cboProducts.MaxDropDownItems = CType(15, Short)
            Me.cboProducts.MaxLength = 32767
            Me.cboProducts.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProducts.Name = "cboProducts"
            Me.cboProducts.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProducts.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProducts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProducts.Size = New System.Drawing.Size(248, 21)
            Me.cboProducts.TabIndex = 4
            Me.cboProducts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(-8, 104)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(104, 16)
            Me.Label12.TabIndex = 181
            Me.Label12.Text = "Product Type :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboManufs
            '
            Me.cboManufs.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboManufs.Caption = ""
            Me.cboManufs.CaptionHeight = 17
            Me.cboManufs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboManufs.ColumnCaptionHeight = 17
            Me.cboManufs.ColumnFooterHeight = 17
            Me.cboManufs.ContentHeight = 15
            Me.cboManufs.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboManufs.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboManufs.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManufs.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboManufs.EditorHeight = 15
            Me.cboManufs.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboManufs.ItemHeight = 15
            Me.cboManufs.Location = New System.Drawing.Point(96, 136)
            Me.cboManufs.MatchEntryTimeout = CType(2000, Long)
            Me.cboManufs.MaxDropDownItems = CType(5, Short)
            Me.cboManufs.MaxLength = 32767
            Me.cboManufs.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManufs.Name = "cboManufs"
            Me.cboManufs.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManufs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManufs.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManufs.Size = New System.Drawing.Size(248, 21)
            Me.cboManufs.TabIndex = 5
            Me.cboManufs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'tpChangeMfgSerial
            '
            Me.tpChangeMfgSerial.BackColor = System.Drawing.Color.SteelBlue
            Me.tpChangeMfgSerial.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblOldMfgSerial, Me.Label_OldMfgSerial, Me.Label_PSSSerialNumber, Me.txtPSSSerial, Me.btnChangeMfgSerial, Me.Label_NewMfgSerial, Me.txtNewMfgSerial})
            Me.tpChangeMfgSerial.Location = New System.Drawing.Point(4, 22)
            Me.tpChangeMfgSerial.Name = "tpChangeMfgSerial"
            Me.tpChangeMfgSerial.Size = New System.Drawing.Size(688, 414)
            Me.tpChangeMfgSerial.TabIndex = 3
            Me.tpChangeMfgSerial.Text = "Change Mfg. Serial"
            '
            'lblOldMfgSerial
            '
            Me.lblOldMfgSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOldMfgSerial.ForeColor = System.Drawing.Color.Lime
            Me.lblOldMfgSerial.Location = New System.Drawing.Point(152, 96)
            Me.lblOldMfgSerial.Name = "lblOldMfgSerial"
            Me.lblOldMfgSerial.Size = New System.Drawing.Size(248, 23)
            Me.lblOldMfgSerial.TabIndex = 184
            Me.lblOldMfgSerial.Visible = False
            '
            'Label_OldMfgSerial
            '
            Me.Label_OldMfgSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_OldMfgSerial.ForeColor = System.Drawing.Color.White
            Me.Label_OldMfgSerial.Location = New System.Drawing.Point(40, 96)
            Me.Label_OldMfgSerial.Name = "Label_OldMfgSerial"
            Me.Label_OldMfgSerial.Size = New System.Drawing.Size(104, 16)
            Me.Label_OldMfgSerial.TabIndex = 183
            Me.Label_OldMfgSerial.Text = "Old Mfg. Serial :"
            Me.Label_OldMfgSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label_OldMfgSerial.Visible = False
            '
            'Label_PSSSerialNumber
            '
            Me.Label_PSSSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PSSSerialNumber.ForeColor = System.Drawing.Color.White
            Me.Label_PSSSerialNumber.Location = New System.Drawing.Point(40, 48)
            Me.Label_PSSSerialNumber.Name = "Label_PSSSerialNumber"
            Me.Label_PSSSerialNumber.Size = New System.Drawing.Size(104, 16)
            Me.Label_PSSSerialNumber.TabIndex = 181
            Me.Label_PSSSerialNumber.Text = "PSS Serial :"
            Me.Label_PSSSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPSSSerial
            '
            Me.txtPSSSerial.Location = New System.Drawing.Point(152, 48)
            Me.txtPSSSerial.MaxLength = 30
            Me.txtPSSSerial.Name = "txtPSSSerial"
            Me.txtPSSSerial.Size = New System.Drawing.Size(248, 20)
            Me.txtPSSSerial.TabIndex = 180
            Me.txtPSSSerial.Text = ""
            '
            'btnChangeMfgSerial
            '
            Me.btnChangeMfgSerial.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.btnChangeMfgSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChangeMfgSerial.Location = New System.Drawing.Point(152, 184)
            Me.btnChangeMfgSerial.Name = "btnChangeMfgSerial"
            Me.btnChangeMfgSerial.Size = New System.Drawing.Size(248, 32)
            Me.btnChangeMfgSerial.TabIndex = 179
            Me.btnChangeMfgSerial.Text = "Update"
            '
            'Label_NewMfgSerial
            '
            Me.Label_NewMfgSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_NewMfgSerial.ForeColor = System.Drawing.Color.White
            Me.Label_NewMfgSerial.Location = New System.Drawing.Point(40, 144)
            Me.Label_NewMfgSerial.Name = "Label_NewMfgSerial"
            Me.Label_NewMfgSerial.Size = New System.Drawing.Size(104, 16)
            Me.Label_NewMfgSerial.TabIndex = 178
            Me.Label_NewMfgSerial.Text = "NEW Mfg. Serial :"
            Me.Label_NewMfgSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNewMfgSerial
            '
            Me.txtNewMfgSerial.Location = New System.Drawing.Point(152, 144)
            Me.txtNewMfgSerial.MaxLength = 30
            Me.txtNewMfgSerial.Name = "txtNewMfgSerial"
            Me.txtNewMfgSerial.Size = New System.Drawing.Size(248, 20)
            Me.txtNewMfgSerial.TabIndex = 10
            Me.txtNewMfgSerial.Text = ""
            '
            'tpReceivedData
            '
            Me.tpReceivedData.BackColor = System.Drawing.Color.SteelBlue
            Me.tpReceivedData.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgRecUnits, Me.btnRefreshRecData})
            Me.tpReceivedData.Location = New System.Drawing.Point(4, 22)
            Me.tpReceivedData.Name = "tpReceivedData"
            Me.tpReceivedData.Size = New System.Drawing.Size(688, 414)
            Me.tpReceivedData.TabIndex = 1
            Me.tpReceivedData.Text = "Received Data"
            Me.tpReceivedData.Visible = False
            '
            'dbgRecUnits
            '
            Me.dbgRecUnits.AllowUpdate = False
            Me.dbgRecUnits.AlternatingRows = True
            Me.dbgRecUnits.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgRecUnits.FilterBar = True
            Me.dbgRecUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecUnits.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.dbgRecUnits.Location = New System.Drawing.Point(8, 48)
            Me.dbgRecUnits.Name = "dbgRecUnits"
            Me.dbgRecUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgRecUnits.Size = New System.Drawing.Size(664, 312)
            Me.dbgRecUnits.TabIndex = 103
            Me.dbgRecUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "08</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 660, 308<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 660, 308</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnRefreshRecData
            '
            Me.btnRefreshRecData.BackColor = System.Drawing.Color.SlateGray
            Me.btnRefreshRecData.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshRecData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshRecData.Location = New System.Drawing.Point(8, 8)
            Me.btnRefreshRecData.Name = "btnRefreshRecData"
            Me.btnRefreshRecData.Size = New System.Drawing.Size(160, 24)
            Me.btnRefreshRecData.TabIndex = 106
            Me.btnRefreshRecData.Text = "Refresh Received Data"
            '
            'tpgPalletData
            '
            Me.tpgPalletData.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlAdjDisInPallet, Me.dgPalletData, Me.Label10, Me.txtPalletID})
            Me.tpgPalletData.Location = New System.Drawing.Point(4, 22)
            Me.tpgPalletData.Name = "tpgPalletData"
            Me.tpgPalletData.Size = New System.Drawing.Size(688, 414)
            Me.tpgPalletData.TabIndex = 4
            Me.tpgPalletData.Text = "Pallet Data"
            '
            'pnlAdjDisInPallet
            '
            Me.pnlAdjDisInPallet.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlAdjDisInPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPDClear, Me.Label_ItemValue, Me.txtItemValue, Me.Label_ItemQty, Me.txtItemQty, Me.Label_ItemDesc, Me.txtItemDesc, Me.Label_ItemNumber, Me.txtItemNumber, Me.btnAddPalletItems})
            Me.pnlAdjDisInPallet.Location = New System.Drawing.Point(424, 48)
            Me.pnlAdjDisInPallet.Name = "pnlAdjDisInPallet"
            Me.pnlAdjDisInPallet.Size = New System.Drawing.Size(248, 304)
            Me.pnlAdjDisInPallet.TabIndex = 2
            Me.pnlAdjDisInPallet.Visible = False
            '
            'btnPDClear
            '
            Me.btnPDClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPDClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPDClear.ForeColor = System.Drawing.Color.White
            Me.btnPDClear.Location = New System.Drawing.Point(152, 248)
            Me.btnPDClear.Name = "btnPDClear"
            Me.btnPDClear.Size = New System.Drawing.Size(75, 32)
            Me.btnPDClear.TabIndex = 205
            Me.btnPDClear.Text = "Clear"
            '
            'Label_ItemValue
            '
            Me.Label_ItemValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ItemValue.ForeColor = System.Drawing.Color.Black
            Me.Label_ItemValue.Location = New System.Drawing.Point(8, 192)
            Me.Label_ItemValue.Name = "Label_ItemValue"
            Me.Label_ItemValue.Size = New System.Drawing.Size(128, 16)
            Me.Label_ItemValue.TabIndex = 204
            Me.Label_ItemValue.Text = "Value $ /Unit :"
            Me.Label_ItemValue.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtItemValue
            '
            Me.txtItemValue.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtItemValue.Location = New System.Drawing.Point(8, 208)
            Me.txtItemValue.Name = "txtItemValue"
            Me.txtItemValue.Size = New System.Drawing.Size(224, 20)
            Me.txtItemValue.TabIndex = 4
            Me.txtItemValue.Text = ""
            '
            'Label_ItemQty
            '
            Me.Label_ItemQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ItemQty.ForeColor = System.Drawing.Color.Black
            Me.Label_ItemQty.Location = New System.Drawing.Point(8, 144)
            Me.Label_ItemQty.Name = "Label_ItemQty"
            Me.Label_ItemQty.Size = New System.Drawing.Size(128, 16)
            Me.Label_ItemQty.TabIndex = 200
            Me.Label_ItemQty.Text = "Quantity :"
            Me.Label_ItemQty.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtItemQty
            '
            Me.txtItemQty.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtItemQty.Location = New System.Drawing.Point(9, 160)
            Me.txtItemQty.Name = "txtItemQty"
            Me.txtItemQty.Size = New System.Drawing.Size(48, 20)
            Me.txtItemQty.TabIndex = 3
            Me.txtItemQty.Text = ""
            '
            'Label_ItemDesc
            '
            Me.Label_ItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ItemDesc.ForeColor = System.Drawing.Color.Black
            Me.Label_ItemDesc.Location = New System.Drawing.Point(8, 56)
            Me.Label_ItemDesc.Name = "Label_ItemDesc"
            Me.Label_ItemDesc.Size = New System.Drawing.Size(168, 16)
            Me.Label_ItemDesc.TabIndex = 198
            Me.Label_ItemDesc.Text = "Item / Model Description :"
            Me.Label_ItemDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtItemDesc
            '
            Me.txtItemDesc.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtItemDesc.Location = New System.Drawing.Point(8, 72)
            Me.txtItemDesc.Multiline = True
            Me.txtItemDesc.Name = "txtItemDesc"
            Me.txtItemDesc.Size = New System.Drawing.Size(224, 64)
            Me.txtItemDesc.TabIndex = 2
            Me.txtItemDesc.Text = ""
            '
            'Label_ItemNumber
            '
            Me.Label_ItemNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ItemNumber.ForeColor = System.Drawing.Color.Black
            Me.Label_ItemNumber.Location = New System.Drawing.Point(8, 8)
            Me.Label_ItemNumber.Name = "Label_ItemNumber"
            Me.Label_ItemNumber.Size = New System.Drawing.Size(128, 16)
            Me.Label_ItemNumber.TabIndex = 196
            Me.Label_ItemNumber.Text = "Item / Model :"
            Me.Label_ItemNumber.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtItemNumber
            '
            Me.txtItemNumber.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtItemNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtItemNumber.Location = New System.Drawing.Point(8, 24)
            Me.txtItemNumber.Name = "txtItemNumber"
            Me.txtItemNumber.Size = New System.Drawing.Size(224, 20)
            Me.txtItemNumber.TabIndex = 1
            Me.txtItemNumber.Text = ""
            '
            'btnAddPalletItems
            '
            Me.btnAddPalletItems.BackColor = System.Drawing.Color.Green
            Me.btnAddPalletItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddPalletItems.ForeColor = System.Drawing.Color.White
            Me.btnAddPalletItems.Location = New System.Drawing.Point(8, 248)
            Me.btnAddPalletItems.Name = "btnAddPalletItems"
            Me.btnAddPalletItems.Size = New System.Drawing.Size(120, 32)
            Me.btnAddPalletItems.TabIndex = 5
            Me.btnAddPalletItems.Text = "Add/Update Item"
            '
            'dgPalletData
            '
            Me.dgPalletData.AllowUpdate = False
            Me.dgPalletData.AlternatingRows = True
            Me.dgPalletData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgPalletData.FilterBar = True
            Me.dgPalletData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgPalletData.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.dgPalletData.Location = New System.Drawing.Point(24, 48)
            Me.dgPalletData.Name = "dgPalletData"
            Me.dgPalletData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgPalletData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgPalletData.PreviewInfo.ZoomFactor = 75
            Me.dgPalletData.Size = New System.Drawing.Size(376, 304)
            Me.dgPalletData.TabIndex = 175
            Me.dgPalletData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 372, 300<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 372, 300</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(16, 16)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(72, 16)
            Me.Label10.TabIndex = 174
            Me.Label10.Text = "Pallet :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPalletID
            '
            Me.txtPalletID.Location = New System.Drawing.Point(96, 16)
            Me.txtPalletID.MaxLength = 30
            Me.txtPalletID.Name = "txtPalletID"
            Me.txtPalletID.Size = New System.Drawing.Size(248, 20)
            Me.txtPalletID.TabIndex = 1
            Me.txtPalletID.Text = ""
            '
            'btnReOpenWO
            '
            Me.btnReOpenWO.BackColor = System.Drawing.Color.Navy
            Me.btnReOpenWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
            Me.btnReOpenWO.Location = New System.Drawing.Point(560, 88)
            Me.btnReOpenWO.Name = "btnReOpenWO"
            Me.btnReOpenWO.Size = New System.Drawing.Size(152, 24)
            Me.btnReOpenWO.TabIndex = 4
            Me.btnReOpenWO.Text = "Re-Open Work Order"
            '
            'lblProdType
            '
            Me.lblProdType.BackColor = System.Drawing.Color.DarkViolet
            Me.lblProdType.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdType.ForeColor = System.Drawing.Color.Lime
            Me.lblProdType.Location = New System.Drawing.Point(16, 0)
            Me.lblProdType.Name = "lblProdType"
            Me.lblProdType.Size = New System.Drawing.Size(696, 64)
            Me.lblProdType.TabIndex = 89
            Me.lblProdType.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'chkBoxDamaged
            '
            Me.chkBoxDamaged.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxDamaged.ForeColor = System.Drawing.Color.White
            Me.chkBoxDamaged.Location = New System.Drawing.Point(360, 88)
            Me.chkBoxDamaged.Name = "chkBoxDamaged"
            Me.chkBoxDamaged.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkBoxDamaged.Size = New System.Drawing.Size(104, 16)
            Me.chkBoxDamaged.TabIndex = 2
            Me.chkBoxDamaged.Text = "Box Damaged"
            '
            'SyxRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(832, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProdType, Me.btnReOpenWO, Me.TabControl1, Me.btnCloseWO, Me.cboOpenWOrders, Me.Label5})
            Me.Name = "SyxRec"
            Me.Text = "frmSyxRec"
            CType(Me.cboOpenWOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpProdReceiving.ResumeLayout(False)
            Me.gbReturnUnit.ResumeLayout(False)
            CType(Me.cboOpenPallets, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCostCenters, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboManufs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpChangeMfgSerial.ResumeLayout(False)
            Me.tpReceivedData.ResumeLayout(False)
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgPalletData.ResumeLayout(False)
            Me.pnlAdjDisInPallet.ResumeLayout(False)
            CType(Me.dgPalletData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************************************
        Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
            Dim R1 As DataRow
            Dim i, iRecUnitCnt As Integer

            Try
                If Me.cboOpenWOrders.SelectedValue = 0 Then Exit Sub

                R1 = Me._objProdRec.GetWorkorderInfo(Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex).ToString.Trim, , Syx.LOCID)
                i = 0 : iRecUnitCnt = 0

                If IsNothing(R1) Then
                    MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Closed") = 1 Then
                    MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Shipped") = 1 Then
                    MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(R1("WO_ID"))
                    If iRecUnitCnt = 0 Then
                        MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.CloseWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.ClearRMAControlsAndVars() : Me.LoadOpenWorkOrder()
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
                            MessageBox.Show("Work Order is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnReOpenWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenWO.Click
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strRMA As String = ""

            Try
                strRMA = InputBox("Enter Work Order #:").Trim.ToUpper
                If strRMA.Trim.Length > 0 Then
                    Me.ClearRMAControlsAndVars() : Me.cboOpenWOrders.SelectedValue = 0

                    R1 = Me._objProdRec.GetWorkorderInfo(strRMA, , PSS.Data.Buisness.Syx.LOCID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This Work Order # " & strRMA & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("WO_Closed") = 0 Then
                        MessageBox.Show("This Work Order # " & strRMA & " is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Not IsDBNull(R1("WO_DateShip")) AndAlso R1("WO_DateShip").ToString.Trim.Length > 0) OrElse R1("WO_Shipped") = 1 Then
                        MessageBox.Show("This Work Order # " & strRMA & " has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.ReOpenWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.LoadOpenWorkOrder() : Me.Enabled = True
                            Me.cboOpenWOrders.SelectedValue = Convert.ToInt32(R1("WO_ID"))
                            Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus() : Cursor.Current = Cursors.Default
                            MessageBox.Show("Work Order is now open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReOpenWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub frmSyxRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                If PSS.Core.ApplicationUser.GetPermission("SyxHandleRecDiscrepancy") > 0 Then
                    Me.pnlAdjDisInPallet.Visible = True
                End If

                PSS.Core.Highlight.SetHighLight(Me)

                Me._booLoadData = True
                dt = Generic.GetManufactures(True)
                Misc.PopulateC1DropDownList(Me.cboManufs, dt, "Manuf_Desc", "Manuf_ID")
                Me.cboManufs.SelectedValue = 0
                Me._booLoadData = True

                Generic.DisposeDT(dt)
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProducts, dt, "Prod_Desc", "Prod_ID")
                Me.cboProducts.SelectedValue = 0

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.LoadOpenPallets()
                Me.LoadOpenWorkOrder()
                Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "frmSyxRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadOpenWorkOrder()
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Me._objProdRec.GetOpenWorkordersList(Syx.LOCID, False)
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Misc.PopulateC1DropDownList(Me.cboOpenWOrders, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenWOrders.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                _booLoadData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub ClearRMAControlsAndVars()
            Try
                Me.lblWOQty.Text = ""
                Me.txtRecComments.Text = ""
                Me.txtSN.Text = ""
                Me._iTrayID = 0
                Me.dbgRecUnits.DataSource = Nothing
                Me.lblProdType.Text = ""

                Me.ClearPrevRepCtrls()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub cboOpenWOrders_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenWOrders.RowChange
            Dim dt As DataTable

            Try
                If Me._booLoadData = True Then Exit Sub

                Me.cboCostCenters.DataSource = Nothing
                Me.cboCostCenters.Text = ""
                If Me.cboOpenWOrders.SelectedValue > 0 Then
                    Me.LoadCostCenter(Me.cboOpenWOrders.Columns("Group_ID").CellValue(Me.cboOpenWOrders.SelectedIndex))

                    Me.lblWOQty.Text = Generic.GetRecQty(Me.cboOpenWOrders.SelectedValue)
                    Me.lblScanQty.Text = Me._objSyxRec.GetRecQtyByUser(Core.ApplicationUser.IDuser)
                    Me._iTrayID = Me._objProdRec.GetTrayID(Me.cboOpenWOrders.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenWOrders_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************

#Region "Production Receive Tab"
        '****************************************************************************************************
        Private Sub LoadCostCenter(ByVal iGroupID As Integer)
            Dim dt As DataTable

            Try
                'Populate cost center list
                dt = Me._objProdRec.GetCostCenterLists(True, iGroupID)
                Misc.PopulateC1DropDownList(Me.cboCostCenters, dt, "cc_desc", "cc_id")
                Me.cboCostCenters.SelectedValue = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadCostCenter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadModels()
            Dim dt As DataTable
            Dim strPalletName As String = ""

            Try
                If Not IsNothing(Me.cboOpenPallets.DataSource) AndAlso Me.cboOpenPallets.SelectedValue > 0 Then strPalletName = Me.cboOpenPallets.Columns("PalletID").CellValue(Me.cboOpenPallets.SelectedIndex)
                Me._booLoadData = True
                dt = Me._objSyxRec.GetModelListInRecPallet(True, strPalletName)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "PD_ID")
                Me._booLoadData = False : Me.Enabled = True

                Me.cboModels.SelectedValue = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadOpenPallets()
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Me._objSyxRec.GetOpenPallets(True)
                Misc.PopulateC1DropDownList(Me.cboOpenPallets, dt, "PalletID", "RP_ID")
                Me.cboOpenPallets.SelectedValue = 0
                Me.cboModels.DataSource = Nothing
                Me.cboModels.Text = ""

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadOpenPallets", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub cboOpenPallets_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpenPallets.RowChange

            Try
                If Me._booLoadData = True Then Exit Sub

                If cboOpenPallets.SelectedValue > 0 Then
                    Dim iAvailableItem, iReceivedItem As Integer
                    iAvailableItem = Me._objSyxRec.GetAvailableItemQty(cboOpenPallets.Text)
                    iReceivedItem = Me._objSyxRec.GetReceivedItemQty(cboOpenPallets.Text)
                    Me.lblPalletQty.Text = iAvailableItem
                    Me.lblPalletReceived.Text = iReceivedItem
                    Me.LoadModels()
                Else
                    Me.lblPalletQty.Text = "0"
                    Me.lblPalletReceived.Text = "0"
                End If
                Me.ClearPrevRepCtrls()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboModels_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub cboModels_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.RowChange
            Try
                If Me._booLoadData = True Then Exit Sub

                Me.ClearPrevRepCtrls()

                If Not IsNothing(Me.cboModels.DataSource) AndAlso Me.cboModels.SelectedValue > 0 Then
                    'Me.txtNewModel.Text = "" : Me.pnlNewModel.Visible = False

                    If cboOpenPallets.SelectedValue > 0 Then
                        Dim iAvailableItem, iReceivedItem As Integer
                        iAvailableItem = Me._objSyxRec.GetAvailableItemQty(cboOpenPallets.Text, Me.cboModels.Text)
                        iReceivedItem = Me._objSyxRec.GetReceivedItemQty(cboOpenPallets.Text, Me.cboModels.Text)
                        Me.lblModelQty.Text = iAvailableItem
                        Me.lblModelReceived.Text = iReceivedItem
                    Else
                        Me.lblModelQty.Text = "0"
                        Me.lblModelReceived.Text = "0"
                    End If

                    Me.cboProducts.SelectedValue = Convert.ToInt32(Me.cboModels.Columns("Prod_ID").CellValue(Me.cboModels.SelectedIndex).ToString)
                    If Me.cboProducts.SelectedValue > 0 Then
                        Me.cboProducts.Enabled = False
                        Me.lblProdType.Text = Me.cboProducts.Columns("Prod_Desc").CellValue(Me.cboProducts.SelectedIndex).ToString
                    Else
                        Me.cboProducts.Enabled = True
                    End If

                    Me.cboManufs.SelectedValue = Convert.ToInt32(Me.cboModels.Columns("Manuf_ID").CellValue(Me.cboModels.SelectedIndex).ToString)
                    If Me.cboManufs.SelectedValue > 0 Then Me.cboManufs.Enabled = False Else Me.cboManufs.Enabled = True

                    If Me.cboModels.DataSource.Table.Select("PD_ID = " & Me.cboModels.SelectedValue)(0)("Model_Desc").ToString.Trim.ToLower.EndsWith(" rf") Then Me.gbReturnUnit.Visible = True Else gbReturnUnit.Visible = False
                Else
                    'Me.pnlNewModel.Visible = True
                    Me.txtRecComments.Text = ""
                    Me.txtSN.Text = ""
                    Me.cboManufs.SelectedValue = 0
                    Me.cboProducts.SelectedValue = 0
                    gbReturnUnit.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboModels_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub cboProducts_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProducts.RowChange
            Try
                If Me._booLoadData = True Then Exit Sub

                If Not IsNothing(Me.cboProducts.DataSource) AndAlso Me.cboProducts.SelectedValue > 0 Then
                    Me.lblProdType.Text = Me.cboProducts.Columns("Prod_Desc").CellValue(Me.cboProducts.SelectedIndex).ToString
                Else
                    Me.lblProdType.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProducts", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub tpProdRectxts_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecComments.KeyUp, txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "txtNewModel" Then
                        Me.txtRecComments.SelectAll() : Me.txtRecComments.Focus()
                    ElseIf sender.name = "txtRecComments" Then
                        Me.chkHasBox.Focus()
                    ElseIf sender.name = "txtSN" AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                        Me.ProcessSN(Me.txtSN.Text.Trim.ToUpper)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpProdRectxts_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Function ProcessSN(ByVal strSN As String) As Boolean
            Const iScreenDCodeID As Integer = 3409
            Dim dt, dtManufSN, dtAccessories, dtAccessoriesList, dtPallet As DataTable
            Dim i, iHasBox, iProdID, iPD_ID, iModelID, iManufID As Integer
            Dim strModelDesc, strStatus, strWorkStation As String
            Dim objAccessoryWind As Gui.SyxCollectAccessories
            Dim booCancelCollectAccessories, booConfirmHasPSSSerialNo As Boolean
            Dim unitcost As Double = 0.0
            Dim iAvailableItem, iReceivedItem As Integer
            Dim booNewModel As Boolean = False
            Dim iBoxDamaged As Integer = 0

            Try
                booCancelCollectAccessories = False : booConfirmHasPSSSerialNo = False
                If Me.txtPrevRepPSN.Text.Trim.Length > 0 AndAlso Me.chkBoxDamaged.Checked = True Then iBoxDamaged = 1

                If PSS.Core.ApplicationUser.GetPermission("SyxRecNoSN") < 1 AndAlso strSN.Trim.ToLower = "noserialnumber" Then
                    MessageBox.Show("You don't have privilege to receive item without serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                End If

                strModelDesc = "" : strStatus = "" : strWorkStation = ""
                If Me.cboOpenWOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
                ElseIf IsNothing(Me.cboModels.DataSource) OrElse (Me.cboModels.SelectedValue = 0) Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                ElseIf Me.cboProducts.SelectedValue = 0 Then
                    MessageBox.Show("Please select product type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboProducts.SelectAll() : Me.cboProducts.Focus()
                ElseIf Me.cboManufs.SelectedValue = 0 Then
                    MessageBox.Show("Please select manufacture.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboManufs.SelectAll() : Me.cboManufs.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Can't define tray ID, please select work order again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
                ElseIf Me.cboOpenPallets.SelectedValue = 0 Then
                    MessageBox.Show("Please select pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenPallets.SelectAll() : Me.cboOpenPallets.Focus()
                Else
                    '*************************************************************************
                    If Me.gbReturnUnit.Visible = True AndAlso Me.txtPrevRepPSN.Text.Trim.Length = 0 Then
                        If MessageBox.Show("Do you want to continue with no previous repair PSS S/N?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            booConfirmHasPSSSerialNo = True
                        Else
                            Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus() : Exit Function
                        End If
                    End If

                    If Me.gbReturnUnit.Visible = True AndAlso Me.txtPrevRepPSN.Text.Trim.Length = 0 AndAlso booConfirmHasPSSSerialNo = False Then
                        MessageBox.Show("This is return unit. Must enter PSS S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus() : Exit Function
                    ElseIf Me.gbReturnUnit.Visible = True AndAlso Me.txtPrevRepPSN.Text.Trim.Length > 0 AndAlso Me.lblPrevRepProdType.Tag <> Me.cboProducts.SelectedValue Then
                        MessageBox.Show("Product type does not match between previous repair and current input.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus() : Exit Function
                    ElseIf Me.gbReturnUnit.Visible = True AndAlso Me.txtPrevRepPSN.Text.Trim.Length > 0 AndAlso Me.cboModels.Text.StartsWith(Me.lblPrevRepModel.Text) = False Then
                        MessageBox.Show("Model does not match between previous repair and current input.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus() : Exit Function
                    ElseIf Me.gbReturnUnit.Visible = True AndAlso Me.txtPrevRepPSN.Text.Trim.Length > 0 AndAlso Me.lblPrevRepManuf.Tag <> Me.cboManufs.SelectedValue Then
                        MessageBox.Show("Manufacture does not match between previous repair and current input.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus() : Exit Function
                    ElseIf Me.gbReturnUnit.Visible = True AndAlso Me.txtPrevRepPSN.Text.Trim.Length > 0 AndAlso Me.txtSN.Text.Trim.ToLower <> Me.txtSN.Tag.ToString.Trim.ToLower Then
                        If MessageBox.Show("Previous repair Manuf S/N is different with current input ( " & Me.txtSN.Tag.ToString.Trim.ToUpper & " vs " & Me.txtSN.Text.Trim.ToUpper & ") . Are you sure you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Function
                        End If
                    End If

                    '*************************************************************************

                    i = 0 : iHasBox = 0 : iProdID = 0
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    '*****************************************
                    'Get next workstation
                    '*****************************************
                    strWorkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, PSS.Data.Buisness.Syx.CUSTOMERID, , )
                    If strWorkStation.Trim.Length = 0 Then Throw New Exception("Wip bucket is missing.")
                    '*****************************************

                    strModelDesc = Me.cboModels.Columns("Model_Desc").CellValue(Me.cboModels.SelectedIndex).ToString
                    iModelID = Me.cboModels.Columns("Model_ID").CellValue(Me.cboModels.SelectedIndex).ToString
                    iProdID = Me.cboProducts.SelectedValue
                    iManufID = Me.cboManufs.SelectedValue

                    'Hung 11/21/2011 Made sure serial number is not re-enter
                    If strSN.Trim.ToLower <> "noserialnumber" Then
                        dtManufSN = Me._objSyxRec.GetSyxDeviceInfoByMfgSN(strSN, Me.cboManufs.SelectedValue)
                        If dtManufSN.Rows.Count > 0 Then
                            MessageBox.Show("This serial# " & strSN & " already entered in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                            Exit Function
                        End If
                    End If

                    'Hung 11/22/2011 validate pallet itemnumber
                    dtPallet = Me._objSyxRec.GetPalletItemNumber(strModelDesc)
                    If dtPallet.Rows.Count < 1 Then
                        MessageBox.Show("The Model# " & strModelDesc & " is not found in this pallet#" & cboOpenPallets.Text & ". Please select or re-enter model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If

                    'Hung 12/01/2011 Validate received quantity items
                    iAvailableItem = Me._objSyxRec.GetAvailableItemQty(Me.cboOpenPallets.Text, strModelDesc)
                    iReceivedItem = Me._objSyxRec.GetReceivedItemQty(Me.cboOpenPallets.Text, strModelDesc)
                    If iAvailableItem = 0 Then
                        MessageBox.Show("There is no item available for this Model# " & strModelDesc & " to be receive. Please select other model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    ElseIf iReceivedItem = iAvailableItem Then
                        MessageBox.Show(iReceivedItem & " item(s) already received for Model# " & strModelDesc & " in Pallet# " & Me.cboOpenPallets.Text & ". You can not receive more than " & iAvailableItem & " item(s). Please contact IT for more information.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If

                    'Hung 11/22/2011 Made sure pallet has not closed by another receiver
                    If Me._objSyxRec.IsPalletClosed(Me.cboOpenPallets.Text) Then
                        MessageBox.Show("The Pallet# " & Me.cboOpenPallets.Text & " has been close by another receiver. Please select re-enter another pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.LoadOpenPallets()
                        Exit Function
                    End If

                    'Hung 11/21/2011 Begin Insert New Model ; Model_Tier and Model_Flat = ProdGrp_ID
                    If iModelID = 0 Then
                        'Validate model to made sure it not created by another receiving screen
                        dt = Me._objSyxRec.GetModelInfo(strModelDesc)
                        If dt.Rows.Count > 0 Then
                            Me.LoadModels()
                            MessageBox.Show("This Model# " & strModelDesc & " in " & dt.Rows(0)("Prod_Desc") & " product and " & dt.Rows(0)("Manuf_Desc") & " manufaturer already existed in the system or just been created by someone else. Please select model in drop down list and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Function
                        End If
                        Dim ASCPrice_ID, Model_Tier, Model_Flat, ProdGrp_ID, RptGrp_ID As Integer
                        ASCPrice_ID = Me._objSyxRec.GetASCPrice_ID(Me.cboManufs.SelectedValue, iProdID, True)
                        ProdGrp_ID = Me._objSyxRec.GetProdGrp_ID(iProdID, strModelDesc, strModelDesc, True)
                        RptGrp_ID = Me._objSyxRec.GetRptGrp_ID(iProdID)
                        If RptGrp_ID < 1 Then
                            MessageBox.Show("Unable to define Report Group for product#" & Me.cboProducts.Text & ". Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Function
                        End If
                        Model_Tier = ProdGrp_ID : Model_Flat = ProdGrp_ID
                        iModelID = Me._objSyxRec.InsertModel(strModelDesc, Model_Tier, Model_Flat, ProdGrp_ID, ASCPrice_ID, RptGrp_ID, Me.cboManufs.SelectedValue, iProdID)
                    End If

                    If iModelID = 0 Then
                        MessageBox.Show("System unable to define model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboModels.SelectAll() : Me.cboModels.Focus() : Exit Function
                    End If
                    'End Insert new model 

                    'Hung 11/22/2011 validate palletdata and calculate unitcost
                    dtPallet = Me._objSyxRec.GetPalletDataInfo(Me.cboOpenPallets.Text, strModelDesc)
                    If dtPallet.Rows.Count < 1 Then
                        MessageBox.Show("The Model# " & strModelDesc & " is not found in Pallet: " & Me.cboOpenPallets.Text & " or pallet has not been loaded into the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    ElseIf dtPallet.Rows.Count > 1 Then
                        MessageBox.Show("Duplicated Model Found ! There are " & dtPallet.Rows.Count & " model# " & strModelDesc & " has been found in Pallet: " & Me.cboOpenPallets.Text & " .Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    Else
                        unitcost = dtPallet.Rows(0)("unitcost")
                        iPD_ID = dtPallet.Rows(0)("PD_ID")
                    End If

                    '//*************************************
                    '//GET CONFIRMATION ON UNDERVALUE ITEM
                    '//*************************************
                    Dim dbUnderValueCost As Double = Me._objSyxRec.GetUnderValueCost()
                    If dbUnderValueCost > 0 AndAlso unitcost <= dbUnderValueCost Then
                        MessageBox.Show("This item is UNDER COST. Please set them aside.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        strStatus = "Under Value"
                        strWorkStation = "UNDER VALUE"
                    End If
                    '//*************************************

                    If Me.chkHasBox.Checked = True Then iHasBox = 1

                    dt = Me._objSyxRec.GetSyxDeviceInfoInWIP(strSN, PSS.Data.Buisness.Syx.CUSTOMERID, PSS.Data.Buisness.Syx.LOCID, )
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("Device existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Else

                        '*******************************************
                        'COLLECT ACCESSORY
                        '*******************************************
                        dtAccessories = New DataTable()
                        If Me.cboModels.SelectedValue > 0 Then
                            'Check if accessories comes with this model
                            'if accessories comes with this model then open 
                            'the SyxCollectAccessories form 
                            dtAccessoriesList = Me._objSyxRec.GetModelAccessories(Me.cboModels.SelectedValue, "3")
                            If dtAccessoriesList.Rows.Count > 0 Then
                                objAccessoryWind = New Gui.SyxCollectAccessories(iScreenDCodeID, Me.cboModels.SelectedValue, 0)
                                objAccessoryWind.ShowDialog()
                                If objAccessoryWind._booCancel = True Then
                                    Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                                    Exit Function
                                Else
                                    dtAccessories = objAccessoryWind._dtSelectAccessories
                                    If dtAccessories.Rows.Count = 0 AndAlso MessageBox.Show("Are you sure you want to receive this device without any accessory?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                        Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                                        Exit Function
                                    End If
                                End If
                            End If
                        End If

                        '*******************************************
                        i = Me._objSyxRec.ReceiveSyxDevice(Me.cboOpenWOrders.SelectedValue, Me._iTrayID, Me.cboCostCenters.SelectedValue, Me.cboOpenPallets.Text.Trim.ToUpper, iManufID, iModelID, strModelDesc, Me.txtRecComments.Text.Trim, iHasBox, strSN, Core.ApplicationUser.IDShift, Core.ApplicationUser.IDuser, dtAccessories, unitcost, iScreenDCodeID, iProdID, iPD_ID, Core.ApplicationUser.NumberEmp, strStatus, strWorkStation, Me.txtPrevRepPSN.Text.Trim.ToUpper, iBoxDamaged)

                        If i > 0 Then
                            Me.lblWOQty.Text = Generic.GetRecQty(Me.cboOpenWOrders.SelectedValue)
                            Me.lblScanQty.Text = Me._objSyxRec.GetRecQtyByUser(Core.ApplicationUser.IDuser)
                            Me.lblModelQty.Text = iAvailableItem
                            Me.lblModelReceived.Text = iReceivedItem + 1
                            Me.lblPalletReceived.Text = Me._objSyxRec.GetReceivedItemQty(Me.cboOpenPallets.Text)
                            Me.txtRecComments.Text = "" : Me.txtSN.Text = "" : Me.txtSN.Tag = ""
                            Me.lblModelQty.Text = 0 : Me.lblModelReceived.Text = 0

                            Me.ClearPrevRepCtrls()

                            Me.LoadModels() : Me.cboModels.SelectAll() : Me.cboModels.Focus()
                        Else
                            Me.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        End If
                        '*******************************************
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtAccessories) : Generic.DisposeDT(dtManufSN) : Generic.DisposeDT(dtPallet)
                Generic.DisposeDT(dtAccessoriesList)
                If Not IsNothing(objAccessoryWind) Then
                    objAccessoryWind.Dispose() : objAccessoryWind = Nothing
                End If
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me._booLoadData = False
            End Try
        End Function

        '****************************************************************************************************
        Private Sub btnRefreshPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshPallet.Click
            LoadOpenPallets()
        End Sub

        '****************************************************************************************************
        Private Sub chkHasBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHasBox.CheckedChanged
            Me.txtSN.SelectAll() : Me.txtSN.Focus()
        End Sub

        '****************************************************************************************************
        Private Sub TpProdRectxts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecComments.KeyPress, txtSN.KeyPress
            If e.KeyChar.ToString.Equals("'") Then e.Handled = True
        End Sub

        '****************************************************************************************************
        Private Sub btnReprintSNLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintSNLabel.Click
            Dim strSN As String = ""
            Dim dt As DataTable

            Try
                strSN = InputBox("Enter S/N:", "Reprint S/N Label").Trim
                If strSN.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Me._objSyxRec.GetSyxDeviceInfoInWIP(strSN, Syx.CUSTOMERID, Syx.LOCID, False)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in WIP", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me._objSyxRec.Label_ReceiveBoxLabel(dt.Rows(0)("Device_ID"), 1)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintSNLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnRefreshModelList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshModelList.Click
            Try
                Me.LoadModels()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshModelList_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec.Click
            Try
                If Me.txtSN.Text.Trim.Length > 0 Then Me.ProcessSN(Me.txtSN.Text.Trim)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRec_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub txtPrevRepPSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrevRepPSN.KeyUp
            Dim dt As DataTable

            Try
                If (e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab) AndAlso Me.txtPrevRepPSN.Text.Trim.Length > 0 Then
                    dt = Me._objSyxRec.GetPrevRepData(Me.txtPrevRepPSN.Text.Trim, Syx.LOCID)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("PSS S/N """ & Me.txtPrevRepPSN.Text.Trim & """ does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus()
                    Else
                        If dt.Select("Device_Dateship = ''").Length > 0 Then
                            MessageBox.Show("PSS S/N """ & Me.txtPrevRepPSN.Text.Trim & """ is currently open in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Me.txtPrevRepPSN.SelectAll() : Me.txtPrevRepPSN.Focus()
                        Else
                            Me.lblPrevRepProdType.Text = dt.Rows(0)("Prod_Desc") : Me.lblPrevRepProdType.Tag = dt.Rows(0)("Prod_ID")
                            Me.lblPrevRepManuf.Text = dt.Rows(0)("Manuf_Desc") : Me.lblPrevRepManuf.Tag = dt.Rows(0)("Manuf_ID")
                            Me.lblPrevRepModel.Text = dt.Rows(0)("Model_Desc").ToString.Trim.ToLower
                            If Me.lblPrevRepModel.Text.EndsWith(" rf") Then Me.lblPrevRepModel.Text = Me.lblPrevRepModel.Text.Replace(" rf", "").ToUpper
                            Me.txtSN.Text = dt.Rows(0)("Manuf_SN") : Me.txtSN.Tag = dt.Rows(0)("Manuf_SN")
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPrevRepPSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub ClearPrevRepCtrls()
            Try
                Me.gbReturnUnit.Visible = False : Me.txtPrevRepPSN.Text = ""
                Me.lblPrevRepProdType.Text = "" : Me.lblPrevRepProdType.Tag = 0
                Me.lblPrevRepManuf.Text = "" : Me.lblPrevRepManuf.Tag = 0
                Me.lblPrevRepModel.Text = ""
                Me.txtSN.Text = "" : Me.txtSN.Tag = "" : chkBoxDamaged.Checked = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearPrevRepCtrls", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************

#End Region

#Region "Received Data Tab"
        '****************************************************************************************************
        Private Sub btnRefreshRecData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshRecData.Click
            Dim dt As DataTable
            Dim i As Integer

            Try
                If Me.cboOpenWOrders.SelectedValue > 0 Then
                    dt = Me._objSyxRec.GetSyxReceivedData(Me.cboOpenWOrders.SelectedValue)
                    With Me.dbgRecUnits
                        .DataSource = dt.DefaultView

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                            If dt.Columns(i).Caption = "Model" Or dt.Columns(i).Caption = "Cnt" OrElse dt.Columns(i).Caption.StartsWith("Rec") OrElse dt.Columns(i).Caption.StartsWith("SN") Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            Else
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            End If

                            If dt.Columns(i).Caption = "Model" Then
                                .Splits(0).DisplayColumns(i).Width = 170
                            ElseIf dt.Columns(i).Caption = "Cnt" Then
                                .Splits(0).DisplayColumns(i).Width = 50
                            Else
                                .Splits(0).DisplayColumns(i).Width = 120
                            End If
                        Next i
                    End With
                Else
                    Me.dbgRecUnits.DataSource = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshRecData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosePallet.Click
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strPalletID As String = ""

            Try
                strPalletID = InputBox("Enter Pallet Name:").Trim.ToUpper
                If strPalletID.Trim.Length > 0 Then

                    R1 = Me._objSyxRec.GetPalletInfo(strPalletID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This Pallet Name:" & strPalletID & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("Closed") = 1 Then
                        MessageBox.Show("This Pallet Name:" & strPalletID & " already closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor


                        'Hung 12/01/2011 Validate received quantity items
                        Dim iAvailableItem, iReceivedItem, itemNeededToReceive As Integer
                        iAvailableItem = Me._objSyxRec.GetAvailableItemQty(strPalletID)
                        iReceivedItem = Me._objSyxRec.GetReceivedItemQty(strPalletID)
                        itemNeededToReceive = iAvailableItem - iReceivedItem
                        If iReceivedItem < iAvailableItem Then
                            MessageBox.Show("There are " & itemNeededToReceive & " available item(s) needed to be receive in this Pallet# " & strPalletID & ". You can not close this pallet until all " & iAvailableItem & " item(s) received. Please contact IT for more information.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        Dim iDiscrepancyFlag As Integer = 0
                        If Me._objSyxRec.IsDiscrepancyPallet(strPalletID) = True Then iDiscrepancyFlag = 1
                        i = Me._objSyxRec.ClosePallet(strPalletID, Core.ApplicationUser.IDuser, iDiscrepancyFlag)
                        If i > 0 Then
                            Me.LoadOpenPallets()
                            MessageBox.Show("Pallet Name:" & strPalletID & " has been closed successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnReopenPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenPallet.Click
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strPalletID As String = ""

            Try
                strPalletID = InputBox("Enter Pallet Name:").Trim.ToUpper
                If strPalletID.Trim.Length > 0 Then

                    R1 = Me._objSyxRec.GetPalletInfo(strPalletID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This Pallet Name:" & strPalletID & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("Closed") = 0 Then
                        MessageBox.Show("This Pallet Name:" & strPalletID & " already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = Me._objSyxRec.ReOpenPallet(strPalletID, Core.ApplicationUser.IDuser)
                        If i > 0 Then
                            Me.LoadOpenPallets()
                            MessageBox.Show("Pallet Name:" & strPalletID & " has been Re-Open successfully and ready for use.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReopenPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '****************************************************************************************************

#End Region

#Region "Change Mfg. Serial Tab"
        '****************************************************************************************************
        Private Sub btnChangeMfgSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeMfgSerial.Click

            Dim i As Integer
            Dim dt As DataTable

            Try
                Label_OldMfgSerial.Visible = False : lblOldMfgSerial.Visible = False : Me.lblOldMfgSerial.Text = ""
                Me.txtPSSSerial.Text = Trim(Me.txtPSSSerial.Text.ToUpper)
                Me.txtNewMfgSerial.Text = Trim(Me.txtNewMfgSerial.Text.ToUpper)

                If Me.txtPSSSerial.Text.Length = 0 Then
                    MessageBox.Show("PSS serial number required....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPSSSerial.SelectAll() : Me.txtPSSSerial.Focus()
                ElseIf Me.txtNewMfgSerial.Text.Length = 0 Then
                    MessageBox.Show("New Mfg. serial number required....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtNewMfgSerial.SelectAll() : Me.txtNewMfgSerial.Focus()
                Else
                    Me.lblOldMfgSerial.Text = ""
                    'Check New MFG serial number
                    dt = Me._objSyxRec.GetSyxDeviceInfoByMfgSN(Me.txtNewMfgSerial.Text)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("The New Mfg. serial#" & Me.txtNewMfgSerial.Text & " already existed. Please re-enter new serial number....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtNewMfgSerial.SelectAll() : Me.txtNewMfgSerial.Focus()
                        Exit Sub
                    End If

                    'Check PSS Serial number
                    dt = Me._objSyxRec.GetSyxDeviceInfoByPSSSN(Me.txtPSSSerial.Text)

                    If dt.Rows.Count < 1 Then
                        MessageBox.Show("The PSS serial#" & Me.txtPSSSerial.Text & " is not found in the system or has been shipped....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPSSSerial.SelectAll() : Me.txtPSSSerial.Focus()
                        Exit Sub
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("There are more than one PSS serial#" & Me.txtPSSSerial.Text & " found in the system. Please contact IT Department immediately...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPSSSerial.SelectAll() : Me.txtPSSSerial.Focus()
                        Exit Sub
                    Else
                        Me.lblOldMfgSerial.Text = dt.Rows(0)("Manuf_SN")
                        Label_OldMfgSerial.Visible = True
                        lblOldMfgSerial.Visible = True
                    End If

                    'Check old and new MFG. Serial number
                    If Me.lblOldMfgSerial.Text = Me.txtNewMfgSerial.Text Then
                        MessageBox.Show("Old and New Mfg. serial number can't be the same....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtNewMfgSerial.SelectAll() : Me.txtNewMfgSerial.Focus()
                        Exit Sub
                    End If

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = Me._objSyxRec.UpdateMfgSerial(dt.Rows(0)("Device_ID"), Me.txtNewMfgSerial.Text)
                    If i > 0 Then
                        MessageBox.Show("New Mfg. serial#" & Me.txtNewMfgSerial.Text & " has been updated ....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPSSSerial.Text = ""
                        Me.txtPSSSerial.SelectAll() : Me.txtPSSSerial.Focus()
                    Else
                        MessageBox.Show("Unable to update the Mfg. serial number....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPSSSerial.SelectAll() : Me.txtPSSSerial.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnChangeMfgSerial_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '****************************************************************************************************

#End Region

#Region "Pallet Data"

        '****************************************************************************************************
        Private Sub txtPalletID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPalletID.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Me.btnPDClear_Click(Nothing, Nothing)
                    If Me.txtPalletID.Text.Trim.Length > 0 Then LoadPalletData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadPalletData()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objSyxRec.GetPalletDataInfo(Me.txtPalletID.Text.Trim, "")
                With Me.dgPalletData
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        If dt.Columns(i).Caption = "ItemNumber" Then
                            .Splits(0).DisplayColumns(i).Width = 90
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "ItemDescription" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        Else
                            .Splits(0).DisplayColumns(i).Width = 100
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        End If
                    Next i

                    .Splits(0).DisplayColumns("PD_ID").Visible = False
                    .Splits(0).DisplayColumns("ItemNumber").Frozen = True
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub dgPalletData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPalletData.DoubleClick
            Try
                btnPDClear_Click(Nothing, Nothing)

                If Me.dgPalletData.Columns.Count > 0 AndAlso Me.dgPalletData.RowCount > 0 AndAlso Me.dgPalletData.Columns("Closed?").CellValue(Me.dgPalletData.Row).ToString.ToLower = "no" Then

                    _iAddUpdPD_ID = Me.dgPalletData.Columns("PD_ID").CellValue(Me.dgPalletData.Row)
                    Me.txtItemNumber.Text = Me.dgPalletData.Columns("ItemNumber").CellValue(Me.dgPalletData.Row)
                    Me.txtItemDesc.Text = Me.dgPalletData.Columns("ItemDescription").CellValue(Me.dgPalletData.Row)
                    Me.txtItemQty.Text = Me.dgPalletData.Columns("OnHandQty").CellValue(Me.dgPalletData.Row)
                    Me.txtItemValue.Text = Me.dgPalletData.Columns("unitcost").CellValue(Me.dgPalletData.Row)

                    Me.txtItemNumber.Enabled = False
                    Me.txtItemDesc.Enabled = False
                    Me.txtItemValue.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnPDClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDClear.Click
            Try
                _iAddUpdPD_ID = 0
                Me.txtItemNumber.Enabled = True
                Me.txtItemDesc.Enabled = True
                Me.txtItemValue.Enabled = True

                Me.txtItemNumber.Text = ""
                Me.txtItemDesc.Text = ""
                Me.txtItemQty.Text = ""
                Me.txtItemValue.Text = ""
                Me.txtItemNumber.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub dgPalletData_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dgPalletData.RowColChange
            Try
                If Me.dgPalletData.RowCount > 0 AndAlso Me.dgPalletData.Columns.Count > 0 AndAlso Me.dgPalletData.Columns("ItemNumber").CellValue(Me.dgPalletData.Row).ToString.ToLower <> Me.txtItemNumber.Text.Trim.ToLower Then
                    btnPDClear_Click(Nothing, Nothing)
                Else
                    btnPDClear_Click(Nothing, Nothing)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnAddPalletItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPalletItems.Click
            Dim i As Integer
            Dim dt As DataTable

            Try
                'If Me._objSyx.IsItemNumberExisted(Me.cboOpenPalletItems.Text, Me.txtItemNumber.Text) = False Then
                '    i = Me._objSyx.InsertSyxrecpalletdata(Me.txtItemNumber.Text, Me.txtItemDesc.Text, Me.txtItemQty.Text, Me.txtItemValue.Text, Me.txtItemUPC.Text, Me.cboOpenPalletItems.Text, "Tools - Admin add item")
                '    If i > 0 Then
                '        MessageBox.Show("The item#: " & Me.txtItemNumber.Text & " has been added successful...." & Me.cboPalletModel.Text & "...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Me.btnPDClear(Nothing, Nothing)
                '        Me.txtItemNumber.Focus()
                '    End If
                'Else
                '    MessageBox.Show("The item#: " & Me.txtItemNumber.Text & " already existed in the pallet# " & Me.cboOpenPalletItems.Text & ". You can not add identical item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If
                If Me.txtPalletID.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletID.SelectAll() : Me.txtPalletID.Focus()
                ElseIf Me.txtItemNumber.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter item number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtItemNumber.SelectAll() : Me.txtItemNumber.Focus()
                ElseIf Me.txtItemDesc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter item description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtItemDesc.SelectAll() : Me.txtItemDesc.Focus()
                ElseIf Me.txtItemQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter item's quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtItemQty.SelectAll() : Me.txtItemQty.Focus()
                    'ElseIf Convert.ToInt32(Me.txtItemQty.Text) <= 0 Then
                    '    MessageBox.Show("Quantity must be greater than zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtItemQty.SelectAll() : Me.txtItemQty.Focus()
                ElseIf Convert.ToDouble(Me.txtItemValue.Text) <= 0 Then
                    MessageBox.Show("Value of item must be greater than zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtItemValue.SelectAll() : Me.txtItemValue.Focus()
                ElseIf Me._objSyxRec.IsPalletExisted(Me.txtPalletID.Text.Trim) = False Then
                    MessageBox.Show("Pallet does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dt = Me._objSyxRec.GetPalletDataInfo(Me.txtPalletID.Text.Trim, Me.txtItemNumber.Text)
                    If dt.Rows.Count > 0 Then
                        If Convert.ToInt32(Me.txtItemQty.Text) < dt.Rows(0)("Received Qty") Then
                            MessageBox.Show("New quantity must equal or greater than received quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtItemQty.SelectAll() : Me.txtItemQty.Focus() : Exit Sub
                        ElseIf dt.Rows(0)("Closed?").ToString.ToLower = "yes" Then
                            MessageBox.Show("Pallet has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtItemQty.SelectAll() : Me.txtItemQty.Focus() : Exit Sub
                        Else
                            i = Me._objSyxRec.UpdateOnhandqty(dt.Rows(0)("PD_ID"), dt.Rows(0)("OriginalOnHandQty"), Convert.ToInt32(Me.txtItemQty.Text), Convert.ToDouble(Me.txtItemValue.Text), dt.Rows(0)("InFile"), PSS.Core.ApplicationUser.IDuser)
                        End If
                    Else
                        i = Me._objSyxRec.AddPalletLineItem(Me.txtPalletID.Text.Trim.ToUpper, Me.txtItemNumber.Text.Trim.ToUpper, Me.txtItemDesc.Text.Trim, Convert.ToInt32(Me.txtItemQty.Text), Convert.ToDouble(Me.txtItemValue.Text), PSS.Core.ApplicationUser.IDuser)
                    End If

                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadPalletData() : Me.btnPDClear_Click(Nothing, Nothing) : Me.txtItemNumber.Focus()
                    Else
                        MessageBox.Show("No update occurs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub txtItemTextBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemNumber.KeyUp, txtItemDesc.KeyUp, txtItemQty.KeyUp, txtItemValue.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtItemNumber.Text.Trim.Length > 0 AndAlso sender.name = "txtItemNumber" Then
                    If Me.PopulateItemInformation(Me.txtItemNumber.Text.Trim.ToUpper) = True Then
                        Me.txtItemQty.Focus()
                    Else
                        Me.txtItemDesc.SelectAll() : Me.txtItemDesc.Focus()
                    End If
                ElseIf e.KeyCode = Keys.Enter AndAlso txtItemDesc.Text.Trim.Length > 0 AndAlso sender.name = "txtItemDesc" Then
                    Me.txtItemQty.SelectAll() : Me.txtItemQty.Focus()
                ElseIf e.KeyCode = Keys.Enter AndAlso txtItemQty.Text.Trim.Length > 0 AndAlso sender.name = "txtItemQty" Then
                    Me.txtItemValue.SelectAll() : Me.txtItemValue.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtItemTextBox_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Function PopulateItemInformation(ByVal strItemNumber As String) As Boolean
            Dim dt As DataTable

            Try
                dt = Me._objSyxRec.GetItemHistory(strItemNumber)
                If dt.Rows.Count > 0 AndAlso Convert.ToInt32(dt.Rows(0)("unitcost")) > 0 Then
                    Me.txtItemDesc.Text = dt.Rows(0)("ItemDescription") : Me.txtItemDesc.Enabled = False
                    Me.txtItemValue.Text = dt.Rows(0)("unitcost") : Me.txtItemValue.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateItemInformation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '****************************************************************************************************
        Private Sub txtItemNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemNumber.KeyPress, txtItemDesc.KeyPress, txtItemQty.KeyPress, txtItemValue.KeyPress
            Try
                If sender.name = "txtItemNumber" OrElse sender.name = "txtItemDesc" Then
                    If e.KeyChar.ToString = """" OrElse e.KeyChar.ToString = "'" OrElse e.KeyChar.ToString = "\" Then
                        e.Handled = True
                    End If
                ElseIf sender.name = "txtItemQty" Then
                    If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                        e.Handled = True
                    End If
                ElseIf sender.name = "txtItemValue" Then
                    If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) And e.KeyChar <> "." Then
                        e.Handled = True
                    ElseIf e.KeyChar = "." Then
                        Dim i As Integer = 0 : Dim iCnt As Integer = 0
                        For i = 0 To Me.txtItemValue.Text.Trim.Length - 1
                            If Me.txtItemValue.Text.Chars(i) = "." Then iCnt += 1
                            If iCnt >= 1 Then
                                e.Handled = True : Exit For
                            End If
                        Next i
                    End If
                End If 'each controls
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtItemTextBox_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************

#End Region

    End Class
End Namespace