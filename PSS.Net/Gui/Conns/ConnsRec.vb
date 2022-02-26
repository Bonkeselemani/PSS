Option Explicit On 

Namespace Gui
    Public Class ConnsRec
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
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
        Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
        Friend WithEvents tpProdReceiving As System.Windows.Forms.TabPage
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents lblPSSProdType As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents btnRefreshModelList As System.Windows.Forms.Button
        Friend WithEvents btnRefreshPallet As System.Windows.Forms.Button
        Friend WithEvents lblModelReceived As System.Windows.Forms.Label
        Friend WithEvents Label_ModelReceived As System.Windows.Forms.Label
        Friend WithEvents lblModelQty As System.Windows.Forms.Label
        Friend WithEvents Label_ModelQty As System.Windows.Forms.Label
        Friend WithEvents lblPalletReceived As System.Windows.Forms.Label
        Friend WithEvents Label_PalletReceived As System.Windows.Forms.Label
        Friend WithEvents lblPalletQty As System.Windows.Forms.Label
        Friend WithEvents Label_PalletQty As System.Windows.Forms.Label
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents cboOpenWOrders As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents pnlNewModel As System.Windows.Forms.Panel
        Friend WithEvents cboProducts As C1.Win.C1List.C1Combo
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents txtNewModel As System.Windows.Forms.TextBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents cboManufs As C1.Win.C1List.C1Combo
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents btnReprintSNLabel As System.Windows.Forms.Button
        Friend WithEvents cboCostCenters As C1.Win.C1List.C1Combo
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents lblWOQty As System.Windows.Forms.Label
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents txtRecComments As System.Windows.Forms.TextBox
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents tpReceivedData As System.Windows.Forms.TabPage
        Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRefreshRecData As System.Windows.Forms.Button
        Friend WithEvents tpChangeMfgSerial As System.Windows.Forms.TabPage
        Friend WithEvents lblOldMfgSerial As System.Windows.Forms.Label
        Friend WithEvents Label_OldMfgSerial As System.Windows.Forms.Label
        Friend WithEvents Label_PSSSerialNumber As System.Windows.Forms.Label
        Friend WithEvents txtPSSSerial As System.Windows.Forms.TextBox
        Friend WithEvents btnChangeMfgSerial As System.Windows.Forms.Button
        Friend WithEvents Label_NewMfgSerial As System.Windows.Forms.Label
        Friend WithEvents txtNewMfgSerial As System.Windows.Forms.TextBox
        Friend WithEvents gbReturnUnit As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConnsRec))
            Me.btnReOpenWO = New System.Windows.Forms.Button()
            Me.tpProdReceiving = New System.Windows.Forms.TabPage()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.lblPSSProdType = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
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
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.cboOpenWOrders = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.pnlNewModel = New System.Windows.Forms.Panel()
            Me.cboProducts = New C1.Win.C1List.C1Combo()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.txtNewModel = New System.Windows.Forms.TextBox()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.cboManufs = New C1.Win.C1List.C1Combo()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.btnReprintSNLabel = New System.Windows.Forms.Button()
            Me.cboCostCenters = New C1.Win.C1List.C1Combo()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.lblWOQty = New System.Windows.Forms.Label()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.txtRecComments = New System.Windows.Forms.TextBox()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.tpReceivedData = New System.Windows.Forms.TabPage()
            Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefreshRecData = New System.Windows.Forms.Button()
            Me.tpChangeMfgSerial = New System.Windows.Forms.TabPage()
            Me.lblOldMfgSerial = New System.Windows.Forms.Label()
            Me.Label_OldMfgSerial = New System.Windows.Forms.Label()
            Me.Label_PSSSerialNumber = New System.Windows.Forms.Label()
            Me.txtPSSSerial = New System.Windows.Forms.TextBox()
            Me.btnChangeMfgSerial = New System.Windows.Forms.Button()
            Me.Label_NewMfgSerial = New System.Windows.Forms.Label()
            Me.txtNewMfgSerial = New System.Windows.Forms.TextBox()
            Me.gbReturnUnit = New System.Windows.Forms.GroupBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            CType(Me.cboOpenWOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.pnlNewModel.SuspendLayout()
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboManufs, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCostCenters, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpReceivedData.SuspendLayout()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpChangeMfgSerial.SuspendLayout()
            Me.gbReturnUnit.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnReOpenWO
            '
            Me.btnReOpenWO.BackColor = System.Drawing.Color.Navy
            Me.btnReOpenWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
            Me.btnReOpenWO.Location = New System.Drawing.Point(464, 20)
            Me.btnReOpenWO.Name = "btnReOpenWO"
            Me.btnReOpenWO.Size = New System.Drawing.Size(152, 24)
            Me.btnReOpenWO.TabIndex = 4
            Me.btnReOpenWO.Text = "Re-Open Work Order"
            '
            'tpProdReceiving
            '
            Me.tpProdReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpProdReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpProdReceiving.Name = "tpProdReceiving"
            Me.tpProdReceiving.Size = New System.Drawing.Size(760, 462)
            Me.tpProdReceiving.TabIndex = 0
            Me.tpProdReceiving.Text = "Production Receiving"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(96, 389)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(248, 16)
            Me.lblModel.TabIndex = 199
            Me.lblModel.Text = "Product Type :"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblModel.Visible = False
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(-16, 389)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(104, 16)
            Me.Label17.TabIndex = 198
            Me.Label17.Text = "Model :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label17.Visible = False
            '
            'lblManuf
            '
            Me.lblManuf.BackColor = System.Drawing.Color.White
            Me.lblManuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManuf.ForeColor = System.Drawing.Color.Black
            Me.lblManuf.Location = New System.Drawing.Point(96, 365)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(248, 16)
            Me.lblManuf.TabIndex = 197
            Me.lblManuf.Text = "Product Type :"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblManuf.Visible = False
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(-16, 365)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(104, 16)
            Me.Label16.TabIndex = 196
            Me.Label16.Text = "Manufacture :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label16.Visible = False
            '
            'lblPSSProdType
            '
            Me.lblPSSProdType.BackColor = System.Drawing.Color.White
            Me.lblPSSProdType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPSSProdType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSProdType.ForeColor = System.Drawing.Color.Black
            Me.lblPSSProdType.Location = New System.Drawing.Point(96, 341)
            Me.lblPSSProdType.Name = "lblPSSProdType"
            Me.lblPSSProdType.Size = New System.Drawing.Size(248, 16)
            Me.lblPSSProdType.TabIndex = 195
            Me.lblPSSProdType.Text = "Product Type :"
            Me.lblPSSProdType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPSSProdType.Visible = False
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(-16, 341)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(104, 16)
            Me.Label14.TabIndex = 194
            Me.Label14.Text = "Product Type :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label14.Visible = False
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(-16, 313)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(104, 16)
            Me.Label13.TabIndex = 193
            Me.Label13.Text = "PSS S/N :"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label13.Visible = False
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(96, 313)
            Me.TextBox1.MaxLength = 30
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(248, 20)
            Me.TextBox1.TabIndex = 7
            Me.TextBox1.Text = ""
            Me.TextBox1.Visible = False
            '
            'btnRefreshModelList
            '
            Me.btnRefreshModelList.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnRefreshModelList.Location = New System.Drawing.Point(344, 72)
            Me.btnRefreshModelList.Name = "btnRefreshModelList"
            Me.btnRefreshModelList.Size = New System.Drawing.Size(56, 23)
            Me.btnRefreshModelList.TabIndex = 191
            Me.btnRefreshModelList.Text = "Refresh"
            '
            'btnRefreshPallet
            '
            Me.btnRefreshPallet.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnRefreshPallet.Location = New System.Drawing.Point(344, 40)
            Me.btnRefreshPallet.Name = "btnRefreshPallet"
            Me.btnRefreshPallet.Size = New System.Drawing.Size(56, 23)
            Me.btnRefreshPallet.TabIndex = 11
            Me.btnRefreshPallet.Text = "Refresh"
            '
            'lblModelReceived
            '
            Me.lblModelReceived.BackColor = System.Drawing.Color.Black
            Me.lblModelReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblModelReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelReceived.ForeColor = System.Drawing.Color.Lime
            Me.lblModelReceived.Location = New System.Drawing.Point(568, 208)
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
            Me.Label_ModelReceived.Location = New System.Drawing.Point(552, 192)
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
            Me.lblModelQty.Location = New System.Drawing.Point(416, 208)
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
            Me.Label_ModelQty.Location = New System.Drawing.Point(416, 192)
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
            Me.lblPalletReceived.Location = New System.Drawing.Point(568, 120)
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
            Me.Label_PalletReceived.Location = New System.Drawing.Point(560, 104)
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
            Me.lblPalletQty.Location = New System.Drawing.Point(416, 120)
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
            Me.Label_PalletQty.Location = New System.Drawing.Point(416, 104)
            Me.Label_PalletQty.Name = "Label_PalletQty"
            Me.Label_PalletQty.Size = New System.Drawing.Size(104, 16)
            Me.Label_PalletQty.TabIndex = 183
            Me.Label_PalletQty.Text = "Pallet Qty"
            Me.Label_PalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.Navy
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(320, 20)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(128, 24)
            Me.btnCloseWO.TabIndex = 90
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
            Me.cboOpenWOrders.Location = New System.Drawing.Point(16, 22)
            Me.cboOpenWOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenWOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenWOrders.MaxLength = 32767
            Me.cboOpenWOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenWOrders.Name = "cboOpenWOrders"
            Me.cboOpenWOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenWOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenWOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenWOrders.Size = New System.Drawing.Size(280, 21)
            Me.cboOpenWOrders.TabIndex = 89
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
            Me.Label5.Location = New System.Drawing.Point(16, -2)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(168, 21)
            Me.Label5.TabIndex = 91
            Me.Label5.Text = "Open Work Order # "
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.tpReceivedData, Me.tpChangeMfgSerial})
            Me.TabControl1.Location = New System.Drawing.Point(16, 48)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(736, 488)
            Me.TabControl1.TabIndex = 92
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbReturnUnit, Me.Button1, Me.Label9, Me.Label10, Me.Label11, Me.Label12, Me.pnlNewModel, Me.btnReprintSNLabel, Me.cboCostCenters, Me.Label25, Me.lblWOQty, Me.Label26, Me.Label27, Me.txtRecComments, Me.Label28, Me.cboModels, Me.Label29, Me.lblScanQty, Me.Label30, Me.txtSN})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(728, 462)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Production Receiving"
            '
            'Button1
            '
            Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.Button1.Location = New System.Drawing.Point(344, 32)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(56, 23)
            Me.Button1.TabIndex = 191
            Me.Button1.Text = "Refresh"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Black
            Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Lime
            Me.Label9.Location = New System.Drawing.Point(568, 96)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(104, 32)
            Me.Label9.TabIndex = 190
            Me.Label9.Text = "0"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(552, 80)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(136, 16)
            Me.Label10.TabIndex = 189
            Me.Label10.Text = "Model Received Qty"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Black
            Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Lime
            Me.Label11.Location = New System.Drawing.Point(416, 96)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(104, 32)
            Me.Label11.TabIndex = 188
            Me.Label11.Text = "0"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(416, 80)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(104, 16)
            Me.Label12.TabIndex = 187
            Me.Label12.Text = "Model Qty"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnlNewModel
            '
            Me.pnlNewModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlNewModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProducts, Me.Label21, Me.txtNewModel, Me.Label22, Me.cboManufs, Me.Label23})
            Me.pnlNewModel.Location = New System.Drawing.Point(-8, 56)
            Me.pnlNewModel.Name = "pnlNewModel"
            Me.pnlNewModel.Size = New System.Drawing.Size(360, 104)
            Me.pnlNewModel.TabIndex = 4
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
            Me.cboProducts.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboProducts.ItemHeight = 15
            Me.cboProducts.Location = New System.Drawing.Point(104, 8)
            Me.cboProducts.MatchEntryTimeout = CType(2000, Long)
            Me.cboProducts.MaxDropDownItems = CType(15, Short)
            Me.cboProducts.MaxLength = 32767
            Me.cboProducts.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProducts.Name = "cboProducts"
            Me.cboProducts.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProducts.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProducts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProducts.Size = New System.Drawing.Size(248, 21)
            Me.cboProducts.TabIndex = 1
            Me.cboProducts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label21
            '
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.White
            Me.Label21.Location = New System.Drawing.Point(24, 72)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(72, 16)
            Me.Label21.TabIndex = 172
            Me.Label21.Text = "New Model :"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNewModel
            '
            Me.txtNewModel.Location = New System.Drawing.Point(104, 72)
            Me.txtNewModel.MaxLength = 30
            Me.txtNewModel.Name = "txtNewModel"
            Me.txtNewModel.Size = New System.Drawing.Size(248, 20)
            Me.txtNewModel.TabIndex = 3
            Me.txtNewModel.Text = ""
            '
            'Label22
            '
            Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.White
            Me.Label22.Location = New System.Drawing.Point(-8, 8)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(104, 16)
            Me.Label22.TabIndex = 181
            Me.Label22.Text = "Product Type :"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboManufs.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboManufs.ItemHeight = 15
            Me.cboManufs.Location = New System.Drawing.Point(104, 40)
            Me.cboManufs.MatchEntryTimeout = CType(2000, Long)
            Me.cboManufs.MaxDropDownItems = CType(5, Short)
            Me.cboManufs.MaxLength = 32767
            Me.cboManufs.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManufs.Name = "cboManufs"
            Me.cboManufs.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManufs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManufs.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManufs.Size = New System.Drawing.Size(248, 21)
            Me.cboManufs.TabIndex = 2
            Me.cboManufs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label23
            '
            Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.White
            Me.Label23.Location = New System.Drawing.Point(-8, 40)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(104, 16)
            Me.Label23.TabIndex = 168
            Me.Label23.Text = "Manufacture :"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnReprintSNLabel
            '
            Me.btnReprintSNLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintSNLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintSNLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintSNLabel.Location = New System.Drawing.Point(488, 344)
            Me.btnReprintSNLabel.Name = "btnReprintSNLabel"
            Me.btnReprintSNLabel.Size = New System.Drawing.Size(128, 24)
            Me.btnReprintSNLabel.TabIndex = 10
            Me.btnReprintSNLabel.Text = "Reprint S/N Label"
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
            Me.cboCostCenters.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
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
            'Label25
            '
            Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label25.ForeColor = System.Drawing.Color.White
            Me.Label25.Location = New System.Drawing.Point(-16, 8)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(104, 16)
            Me.Label25.TabIndex = 176
            Me.Label25.Text = "Cost Center :"
            Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWOQty
            '
            Me.lblWOQty.BackColor = System.Drawing.Color.Black
            Me.lblWOQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblWOQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWOQty.ForeColor = System.Drawing.Color.Lime
            Me.lblWOQty.Location = New System.Drawing.Point(416, 32)
            Me.lblWOQty.Name = "lblWOQty"
            Me.lblWOQty.Size = New System.Drawing.Size(104, 32)
            Me.lblWOQty.TabIndex = 175
            Me.lblWOQty.Text = "0"
            Me.lblWOQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label26
            '
            Me.Label26.BackColor = System.Drawing.Color.Transparent
            Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.White
            Me.Label26.Location = New System.Drawing.Point(416, 16)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(104, 16)
            Me.Label26.TabIndex = 174
            Me.Label26.Text = "Work Order Qty"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label27
            '
            Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.White
            Me.Label27.Location = New System.Drawing.Point(-16, 168)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(104, 16)
            Me.Label27.TabIndex = 173
            Me.Label27.Text = "Comments :"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRecComments
            '
            Me.txtRecComments.Location = New System.Drawing.Point(96, 168)
            Me.txtRecComments.MaxLength = 100
            Me.txtRecComments.Multiline = True
            Me.txtRecComments.Name = "txtRecComments"
            Me.txtRecComments.Size = New System.Drawing.Size(248, 56)
            Me.txtRecComments.TabIndex = 5
            Me.txtRecComments.Text = ""
            '
            'Label28
            '
            Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label28.ForeColor = System.Drawing.Color.White
            Me.Label28.Location = New System.Drawing.Point(-16, 368)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(104, 16)
            Me.Label28.TabIndex = 171
            Me.Label28.Text = "Manuf S/N :"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(96, 32)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(248, 21)
            Me.cboModels.TabIndex = 4
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label29
            '
            Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label29.ForeColor = System.Drawing.Color.White
            Me.Label29.Location = New System.Drawing.Point(-16, 32)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(104, 16)
            Me.Label29.TabIndex = 170
            Me.Label29.Text = "Model :"
            Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
            Me.lblScanQty.Location = New System.Drawing.Point(568, 32)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(104, 32)
            Me.lblScanQty.TabIndex = 105
            Me.lblScanQty.Text = "0"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label30
            '
            Me.Label30.BackColor = System.Drawing.Color.Transparent
            Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label30.ForeColor = System.Drawing.Color.White
            Me.Label30.Location = New System.Drawing.Point(568, 16)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(96, 16)
            Me.Label30.TabIndex = 104
            Me.Label30.Text = "Qty by User"
            Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(96, 368)
            Me.txtSN.MaxLength = 30
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(248, 20)
            Me.txtSN.TabIndex = 8
            Me.txtSN.Text = ""
            '
            'tpReceivedData
            '
            Me.tpReceivedData.BackColor = System.Drawing.Color.SteelBlue
            Me.tpReceivedData.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgRecUnits, Me.btnRefreshRecData})
            Me.tpReceivedData.Location = New System.Drawing.Point(4, 22)
            Me.tpReceivedData.Name = "tpReceivedData"
            Me.tpReceivedData.Size = New System.Drawing.Size(728, 462)
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
            Me.dbgRecUnits.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dbgRecUnits.Location = New System.Drawing.Point(8, 48)
            Me.dbgRecUnits.Name = "dbgRecUnits"
            Me.dbgRecUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgRecUnits.Size = New System.Drawing.Size(704, 312)
            Me.dbgRecUnits.TabIndex = 103
            Me.dbgRecUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "08</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 700, 308<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 700, 308</ClientArea><Pr" & _
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
            'tpChangeMfgSerial
            '
            Me.tpChangeMfgSerial.BackColor = System.Drawing.Color.SteelBlue
            Me.tpChangeMfgSerial.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblOldMfgSerial, Me.Label_OldMfgSerial, Me.Label_PSSSerialNumber, Me.txtPSSSerial, Me.btnChangeMfgSerial, Me.Label_NewMfgSerial, Me.txtNewMfgSerial})
            Me.tpChangeMfgSerial.Location = New System.Drawing.Point(4, 22)
            Me.tpChangeMfgSerial.Name = "tpChangeMfgSerial"
            Me.tpChangeMfgSerial.Size = New System.Drawing.Size(728, 462)
            Me.tpChangeMfgSerial.TabIndex = 3
            Me.tpChangeMfgSerial.Text = "Change Mfg. Serial"
            Me.tpChangeMfgSerial.Visible = False
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
            'gbReturnUnit
            '
            Me.gbReturnUnit.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.TextBox2, Me.Label6, Me.Label7, Me.Label8})
            Me.gbReturnUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbReturnUnit.ForeColor = System.Drawing.Color.White
            Me.gbReturnUnit.Location = New System.Drawing.Point(-8, 240)
            Me.gbReturnUnit.Name = "gbReturnUnit"
            Me.gbReturnUnit.Size = New System.Drawing.Size(360, 112)
            Me.gbReturnUnit.TabIndex = 192
            Me.gbReturnUnit.TabStop = False
            Me.gbReturnUnit.Text = "Return Unit"
            Me.gbReturnUnit.Visible = False
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 16)
            Me.Label1.TabIndex = 196
            Me.Label1.Text = "Manufacture :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(104, 88)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(248, 16)
            Me.Label2.TabIndex = 199
            Me.Label2.Text = "Product Type :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.White
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(104, 40)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(248, 16)
            Me.Label3.TabIndex = 195
            Me.Label3.Text = "Product Type :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 88)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 16)
            Me.Label4.TabIndex = 198
            Me.Label4.Text = "Model :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(104, 16)
            Me.TextBox2.MaxLength = 30
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(248, 20)
            Me.TextBox2.TabIndex = 7
            Me.TextBox2.Text = ""
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(8, 40)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(88, 16)
            Me.Label6.TabIndex = 194
            Me.Label6.Text = "Product Type :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.White
            Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(104, 64)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(248, 16)
            Me.Label7.TabIndex = 197
            Me.Label7.Text = "Product Type :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(8, 16)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(88, 16)
            Me.Label8.TabIndex = 193
            Me.Label8.Text = "PSS S/N :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ConnsRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(776, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.btnCloseWO, Me.cboOpenWOrders, Me.Label5, Me.btnReOpenWO})
            Me.Name = "ConnsRec"
            Me.Text = "ConnsRec"
            CType(Me.cboOpenWOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.pnlNewModel.ResumeLayout(False)
            CType(Me.cboProducts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboManufs, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCostCenters, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpReceivedData.ResumeLayout(False)
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpChangeMfgSerial.ResumeLayout(False)
            Me.gbReturnUnit.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace