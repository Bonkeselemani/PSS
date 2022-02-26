'Imports CrystalDecisions.CrystalReports.Engine

'Namespace Gui.CustomerMaint

'    Public Class frmPreload_Workorder
'        Inherits System.Windows.Forms.Form

'        Private mCustID As Int32 = 0
'        Private mOnLoad As Integer
'        Private mModel As Int32
'        Private mManufacturer As Int32
'        Private mLocation As Int32
'        Private mCustomer As Int32
'        Private mProdID As Integer
'        Private dtGroup As DataTable
'        Private dtSKUlength As DataTable

'#Region " Windows Form Designer generated code "

'        Public Sub New(Optional ByVal vProdID As Integer = 2)
'            MyBase.New()

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call
'            mProdID = vProdID

'        End Sub

'        'Form overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents lblWorkorderNumber As System.Windows.Forms.Label
'        Friend WithEvents lblCustomer As System.Windows.Forms.Label
'        Friend WithEvents lblLocation As System.Windows.Forms.Label
'        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
'        Friend WithEvents lblModel As System.Windows.Forms.Label
'        Friend WithEvents btnSAVE As System.Windows.Forms.Button
'        Friend WithEvents txtWorkOrderNumber As System.Windows.Forms.TextBox
'        Friend WithEvents cboManufacturer As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboLocation As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
'        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
'        Friend WithEvents tbCustomer As System.Windows.Forms.TabPage
'        Friend WithEvents tbDevice As System.Windows.Forms.TabPage
'        Friend WithEvents txtPOP As System.Windows.Forms.TextBox
'        Friend WithEvents chkDateCode As System.Windows.Forms.CheckBox
'        Friend WithEvents chkPOP As System.Windows.Forms.CheckBox
'        Friend WithEvents txtDateCode As System.Windows.Forms.TextBox
'        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
'        Friend WithEvents txtFlexVer As System.Windows.Forms.TextBox
'        Friend WithEvents lblFlexVer As System.Windows.Forms.Label
'        Friend WithEvents txtSUG As System.Windows.Forms.TextBox
'        Friend WithEvents Label1 As System.Windows.Forms.Label
'        Friend WithEvents lbl20pct As System.Windows.Forms.Label
'        Friend WithEvents txt20pct As System.Windows.Forms.TextBox
'        Friend WithEvents txtIncIMEI As System.Windows.Forms.TextBox
'        Friend WithEvents chkIncIMEI As System.Windows.Forms.CheckBox
'        Friend WithEvents txtAirtime As System.Windows.Forms.TextBox
'        Friend WithEvents txtSoftVerOUT As System.Windows.Forms.TextBox
'        Friend WithEvents txtSoftVerIN As System.Windows.Forms.TextBox
'        Friend WithEvents lblAirtime As System.Windows.Forms.Label
'        Friend WithEvents lblSoftOUT As System.Windows.Forms.Label
'        Friend WithEvents lblSoftIN As System.Windows.Forms.Label
'        Friend WithEvents cboTransaction As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboComplaint As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboReturn As PSS.Gui.Controls.ComboBox
'        Friend WithEvents txtProduct As System.Windows.Forms.TextBox
'        Friend WithEvents txtMIN As System.Windows.Forms.TextBox
'        Friend WithEvents txtCarrierModel As System.Windows.Forms.TextBox
'        Friend WithEvents txtTransceiver As System.Windows.Forms.TextBox
'        Friend WithEvents txtCourierTrackIN As System.Windows.Forms.TextBox
'        Friend WithEvents chkCourierTrackIN As System.Windows.Forms.CheckBox
'        Friend WithEvents chkTransaction As System.Windows.Forms.CheckBox
'        Friend WithEvents chkReturn As System.Windows.Forms.CheckBox
'        Friend WithEvents chkMIN As System.Windows.Forms.CheckBox
'        Friend WithEvents chkComplaint As System.Windows.Forms.CheckBox
'        Friend WithEvents chkCarrierModel As System.Windows.Forms.CheckBox
'        Friend WithEvents chkTransceiver As System.Windows.Forms.CheckBox
'        Friend WithEvents chkProduct As System.Windows.Forms.CheckBox
'        Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
'        Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
'        Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
'        Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
'        Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
'        Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
'        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
'        Friend WithEvents txtAPC As System.Windows.Forms.TextBox
'        Friend WithEvents cboCarrier As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboShipTo As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboWarranty As PSS.Gui.Controls.ComboBox
'        Friend WithEvents txtMemo As System.Windows.Forms.TextBox
'        Friend WithEvents chkMemo As System.Windows.Forms.CheckBox
'        Friend WithEvents txtDockDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtSKU As System.Windows.Forms.TextBox
'        Friend WithEvents txtRAQuantity As System.Windows.Forms.TextBox
'        Friend WithEvents txtIP As System.Windows.Forms.TextBox
'        Friend WithEvents txtPRL As System.Windows.Forms.TextBox
'        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
'        Friend WithEvents chkCarrier As System.Windows.Forms.CheckBox
'        Friend WithEvents chkWarranty As System.Windows.Forms.CheckBox
'        Friend WithEvents chkPRL As System.Windows.Forms.CheckBox
'        Friend WithEvents chkIP As System.Windows.Forms.CheckBox
'        Friend WithEvents chkDockDate As System.Windows.Forms.CheckBox
'        Friend WithEvents chkQuantity As System.Windows.Forms.CheckBox
'        Friend WithEvents chkShipTo As System.Windows.Forms.CheckBox
'        Friend WithEvents chkSKU As System.Windows.Forms.CheckBox
'        Friend WithEvents chkRAQuantity As System.Windows.Forms.CheckBox
'        Friend WithEvents chkAPC As System.Windows.Forms.CheckBox
'        Friend WithEvents txtComment As System.Windows.Forms.TextBox
'        Friend WithEvents Label2 As System.Windows.Forms.Label
'        Friend WithEvents txtUPC As System.Windows.Forms.TextBox
'        Friend WithEvents chkPO As System.Windows.Forms.CheckBox
'        Friend WithEvents chkUPC As System.Windows.Forms.CheckBox
'        Friend WithEvents txtPOID As System.Windows.Forms.TextBox
'        Friend WithEvents txtDefaultSKU As System.Windows.Forms.TextBox
'        Friend WithEvents chkDefaultSKU As System.Windows.Forms.CheckBox
'        Friend WithEvents lblGroup As System.Windows.Forms.Label
'        Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
'        Friend WithEvents chkSkuLength As System.Windows.Forms.CheckBox
'        Friend WithEvents cboSkuLength As PSS.Gui.Controls.ComboBox
'        Friend WithEvents chkSVIN As System.Windows.Forms.CheckBox
'        Friend WithEvents chkAirtime As System.Windows.Forms.CheckBox
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.lblWorkorderNumber = New System.Windows.Forms.Label()
'            Me.txtWorkOrderNumber = New System.Windows.Forms.TextBox()
'            Me.lblCustomer = New System.Windows.Forms.Label()
'            Me.lblLocation = New System.Windows.Forms.Label()
'            Me.lblManufacturer = New System.Windows.Forms.Label()
'            Me.lblModel = New System.Windows.Forms.Label()
'            Me.btnSAVE = New System.Windows.Forms.Button()
'            Me.cboManufacturer = New PSS.Gui.Controls.ComboBox()
'            Me.cboModel = New PSS.Gui.Controls.ComboBox()
'            Me.cboLocation = New PSS.Gui.Controls.ComboBox()
'            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
'            Me.TabControl1 = New System.Windows.Forms.TabControl()
'            Me.tbCustomer = New System.Windows.Forms.TabPage()
'            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
'            Me.cboSkuLength = New PSS.Gui.Controls.ComboBox()
'            Me.chkSkuLength = New System.Windows.Forms.CheckBox()
'            Me.txtDefaultSKU = New System.Windows.Forms.TextBox()
'            Me.chkDefaultSKU = New System.Windows.Forms.CheckBox()
'            Me.txtPOID = New System.Windows.Forms.TextBox()
'            Me.txtUPC = New System.Windows.Forms.TextBox()
'            Me.chkPO = New System.Windows.Forms.CheckBox()
'            Me.chkUPC = New System.Windows.Forms.CheckBox()
'            Me.txtAPC = New System.Windows.Forms.TextBox()
'            Me.cboCarrier = New PSS.Gui.Controls.ComboBox()
'            Me.cboShipTo = New PSS.Gui.Controls.ComboBox()
'            Me.cboWarranty = New PSS.Gui.Controls.ComboBox()
'            Me.txtMemo = New System.Windows.Forms.TextBox()
'            Me.chkMemo = New System.Windows.Forms.CheckBox()
'            Me.txtDockDate = New System.Windows.Forms.TextBox()
'            Me.txtSKU = New System.Windows.Forms.TextBox()
'            Me.txtRAQuantity = New System.Windows.Forms.TextBox()
'            Me.txtIP = New System.Windows.Forms.TextBox()
'            Me.txtPRL = New System.Windows.Forms.TextBox()
'            Me.txtQuantity = New System.Windows.Forms.TextBox()
'            Me.chkCarrier = New System.Windows.Forms.CheckBox()
'            Me.chkWarranty = New System.Windows.Forms.CheckBox()
'            Me.chkPRL = New System.Windows.Forms.CheckBox()
'            Me.chkIP = New System.Windows.Forms.CheckBox()
'            Me.chkDockDate = New System.Windows.Forms.CheckBox()
'            Me.chkQuantity = New System.Windows.Forms.CheckBox()
'            Me.chkShipTo = New System.Windows.Forms.CheckBox()
'            Me.chkSKU = New System.Windows.Forms.CheckBox()
'            Me.chkRAQuantity = New System.Windows.Forms.CheckBox()
'            Me.chkAPC = New System.Windows.Forms.CheckBox()
'            Me.tbDevice = New System.Windows.Forms.TabPage()
'            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
'            Me.txtComment = New System.Windows.Forms.TextBox()
'            Me.Label2 = New System.Windows.Forms.Label()
'            Me.txtFlexVer = New System.Windows.Forms.TextBox()
'            Me.lblFlexVer = New System.Windows.Forms.Label()
'            Me.txtSUG = New System.Windows.Forms.TextBox()
'            Me.Label1 = New System.Windows.Forms.Label()
'            Me.lbl20pct = New System.Windows.Forms.Label()
'            Me.txt20pct = New System.Windows.Forms.TextBox()
'            Me.txtIncIMEI = New System.Windows.Forms.TextBox()
'            Me.chkIncIMEI = New System.Windows.Forms.CheckBox()
'            Me.txtAirtime = New System.Windows.Forms.TextBox()
'            Me.txtSoftVerOUT = New System.Windows.Forms.TextBox()
'            Me.txtSoftVerIN = New System.Windows.Forms.TextBox()
'            Me.lblAirtime = New System.Windows.Forms.Label()
'            Me.lblSoftOUT = New System.Windows.Forms.Label()
'            Me.lblSoftIN = New System.Windows.Forms.Label()
'            Me.cboTransaction = New PSS.Gui.Controls.ComboBox()
'            Me.cboComplaint = New PSS.Gui.Controls.ComboBox()
'            Me.cboReturn = New PSS.Gui.Controls.ComboBox()
'            Me.txtProduct = New System.Windows.Forms.TextBox()
'            Me.txtMIN = New System.Windows.Forms.TextBox()
'            Me.txtCarrierModel = New System.Windows.Forms.TextBox()
'            Me.txtTransceiver = New System.Windows.Forms.TextBox()
'            Me.txtCourierTrackIN = New System.Windows.Forms.TextBox()
'            Me.chkCourierTrackIN = New System.Windows.Forms.CheckBox()
'            Me.chkTransaction = New System.Windows.Forms.CheckBox()
'            Me.chkReturn = New System.Windows.Forms.CheckBox()
'            Me.chkMIN = New System.Windows.Forms.CheckBox()
'            Me.chkComplaint = New System.Windows.Forms.CheckBox()
'            Me.chkCarrierModel = New System.Windows.Forms.CheckBox()
'            Me.chkTransceiver = New System.Windows.Forms.CheckBox()
'            Me.chkProduct = New System.Windows.Forms.CheckBox()
'            Me.CheckBox2 = New System.Windows.Forms.CheckBox()
'            Me.CheckBox6 = New System.Windows.Forms.CheckBox()
'            Me.CheckBox7 = New System.Windows.Forms.CheckBox()
'            Me.CheckBox9 = New System.Windows.Forms.CheckBox()
'            Me.CheckBox10 = New System.Windows.Forms.CheckBox()
'            Me.CheckBox11 = New System.Windows.Forms.CheckBox()
'            Me.txtPOP = New System.Windows.Forms.TextBox()
'            Me.chkDateCode = New System.Windows.Forms.CheckBox()
'            Me.chkPOP = New System.Windows.Forms.CheckBox()
'            Me.txtDateCode = New System.Windows.Forms.TextBox()
'            Me.lblGroup = New System.Windows.Forms.Label()
'            Me.cboGroup = New System.Windows.Forms.ComboBox()
'            Me.chkSVIN = New System.Windows.Forms.CheckBox()
'            Me.chkAirtime = New System.Windows.Forms.CheckBox()
'            Me.TabControl1.SuspendLayout()
'            Me.tbCustomer.SuspendLayout()
'            Me.GroupBox2.SuspendLayout()
'            Me.tbDevice.SuspendLayout()
'            Me.GroupBox1.SuspendLayout()
'            Me.SuspendLayout()
'            '
'            'lblWorkorderNumber
'            '
'            Me.lblWorkorderNumber.Location = New System.Drawing.Point(8, 8)
'            Me.lblWorkorderNumber.Name = "lblWorkorderNumber"
'            Me.lblWorkorderNumber.Size = New System.Drawing.Size(72, 16)
'            Me.lblWorkorderNumber.TabIndex = 0
'            Me.lblWorkorderNumber.Text = "Workorder:"
'            Me.lblWorkorderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtWorkOrderNumber
'            '
'            Me.txtWorkOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtWorkOrderNumber.Location = New System.Drawing.Point(88, 8)
'            Me.txtWorkOrderNumber.Name = "txtWorkOrderNumber"
'            Me.txtWorkOrderNumber.TabIndex = 1
'            Me.txtWorkOrderNumber.Text = ""
'            '
'            'lblCustomer
'            '
'            Me.lblCustomer.Location = New System.Drawing.Point(192, 8)
'            Me.lblCustomer.Name = "lblCustomer"
'            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
'            Me.lblCustomer.TabIndex = 0
'            Me.lblCustomer.Text = "Customer:"
'            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblLocation
'            '
'            Me.lblLocation.Location = New System.Drawing.Point(488, 8)
'            Me.lblLocation.Name = "lblLocation"
'            Me.lblLocation.Size = New System.Drawing.Size(56, 16)
'            Me.lblLocation.TabIndex = 0
'            Me.lblLocation.Text = "Location:"
'            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblManufacturer
'            '
'            Me.lblManufacturer.Location = New System.Drawing.Point(40, 40)
'            Me.lblManufacturer.Name = "lblManufacturer"
'            Me.lblManufacturer.Size = New System.Drawing.Size(48, 16)
'            Me.lblManufacturer.TabIndex = 0
'            Me.lblManufacturer.Text = "Manuf:"
'            Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblModel
'            '
'            Me.lblModel.Location = New System.Drawing.Point(272, 40)
'            Me.lblModel.Name = "lblModel"
'            Me.lblModel.Size = New System.Drawing.Size(40, 16)
'            Me.lblModel.TabIndex = 0
'            Me.lblModel.Text = "Model:"
'            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'btnSAVE
'            '
'            Me.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.btnSAVE.Location = New System.Drawing.Point(24, 384)
'            Me.btnSAVE.Name = "btnSAVE"
'            Me.btnSAVE.Size = New System.Drawing.Size(656, 32)
'            Me.btnSAVE.TabIndex = 36
'            Me.btnSAVE.Text = "SAVE"
'            '
'            'cboManufacturer
'            '
'            Me.cboManufacturer.AutoComplete = True
'            Me.cboManufacturer.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboManufacturer.Location = New System.Drawing.Point(88, 40)
'            Me.cboManufacturer.Name = "cboManufacturer"
'            Me.cboManufacturer.Size = New System.Drawing.Size(176, 21)
'            Me.cboManufacturer.TabIndex = 4
'            '
'            'cboModel
'            '
'            Me.cboModel.AutoComplete = True
'            Me.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'            Me.cboModel.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboModel.Location = New System.Drawing.Point(320, 40)
'            Me.cboModel.Name = "cboModel"
'            Me.cboModel.Size = New System.Drawing.Size(168, 21)
'            Me.cboModel.TabIndex = 5
'            '
'            'cboLocation
'            '
'            Me.cboLocation.AutoComplete = True
'            Me.cboLocation.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboLocation.Location = New System.Drawing.Point(552, 8)
'            Me.cboLocation.Name = "cboLocation"
'            Me.cboLocation.Size = New System.Drawing.Size(112, 21)
'            Me.cboLocation.TabIndex = 3
'            '
'            'cboCustomer
'            '
'            Me.cboCustomer.AutoComplete = True
'            Me.cboCustomer.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboCustomer.Location = New System.Drawing.Point(256, 8)
'            Me.cboCustomer.Name = "cboCustomer"
'            Me.cboCustomer.Size = New System.Drawing.Size(232, 21)
'            Me.cboCustomer.TabIndex = 2
'            '
'            'TabControl1
'            '
'            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbCustomer, Me.tbDevice})
'            Me.TabControl1.Location = New System.Drawing.Point(24, 88)
'            Me.TabControl1.Name = "TabControl1"
'            Me.TabControl1.SelectedIndex = 0
'            Me.TabControl1.Size = New System.Drawing.Size(656, 288)
'            Me.TabControl1.TabIndex = 35
'            '
'            'tbCustomer
'            '
'            Me.tbCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2})
'            Me.tbCustomer.Location = New System.Drawing.Point(4, 22)
'            Me.tbCustomer.Name = "tbCustomer"
'            Me.tbCustomer.Size = New System.Drawing.Size(648, 262)
'            Me.tbCustomer.TabIndex = 0
'            Me.tbCustomer.Text = "Customer"
'            '
'            'GroupBox2
'            '
'            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSkuLength, Me.chkSkuLength, Me.txtDefaultSKU, Me.chkDefaultSKU, Me.txtPOID, Me.txtUPC, Me.chkPO, Me.chkUPC, Me.txtAPC, Me.cboCarrier, Me.cboShipTo, Me.cboWarranty, Me.txtMemo, Me.chkMemo, Me.txtDockDate, Me.txtSKU, Me.txtRAQuantity, Me.txtIP, Me.txtPRL, Me.txtQuantity, Me.chkCarrier, Me.chkWarranty, Me.chkPRL, Me.chkIP, Me.chkDockDate, Me.chkQuantity, Me.chkShipTo, Me.chkSKU, Me.chkRAQuantity, Me.chkAPC})
'            Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.GroupBox2.Location = New System.Drawing.Point(16, 16)
'            Me.GroupBox2.Name = "GroupBox2"
'            Me.GroupBox2.Size = New System.Drawing.Size(616, 240)
'            Me.GroupBox2.TabIndex = 7
'            Me.GroupBox2.TabStop = False
'            Me.GroupBox2.Text = "Customer Specific"
'            '
'            'cboSkuLength
'            '
'            Me.cboSkuLength.AutoComplete = True
'            Me.cboSkuLength.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboSkuLength.Location = New System.Drawing.Point(424, 208)
'            Me.cboSkuLength.Name = "cboSkuLength"
'            Me.cboSkuLength.Size = New System.Drawing.Size(100, 21)
'            Me.cboSkuLength.TabIndex = 21
'            '
'            'chkSkuLength
'            '
'            Me.chkSkuLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkSkuLength.Location = New System.Drawing.Point(312, 208)
'            Me.chkSkuLength.Name = "chkSkuLength"
'            Me.chkSkuLength.TabIndex = 60
'            Me.chkSkuLength.TabStop = False
'            Me.chkSkuLength.Text = "SKU Length"
'            '
'            'txtDefaultSKU
'            '
'            Me.txtDefaultSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtDefaultSKU.Location = New System.Drawing.Point(424, 184)
'            Me.txtDefaultSKU.Name = "txtDefaultSKU"
'            Me.txtDefaultSKU.TabIndex = 20
'            Me.txtDefaultSKU.Text = ""
'            '
'            'chkDefaultSKU
'            '
'            Me.chkDefaultSKU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkDefaultSKU.Location = New System.Drawing.Point(312, 184)
'            Me.chkDefaultSKU.Name = "chkDefaultSKU"
'            Me.chkDefaultSKU.TabIndex = 58
'            Me.chkDefaultSKU.TabStop = False
'            Me.chkDefaultSKU.Text = "Default SKU"
'            '
'            'txtPOID
'            '
'            Me.txtPOID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtPOID.Location = New System.Drawing.Point(424, 160)
'            Me.txtPOID.Name = "txtPOID"
'            Me.txtPOID.TabIndex = 19
'            Me.txtPOID.Text = ""
'            '
'            'txtUPC
'            '
'            Me.txtUPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtUPC.Location = New System.Drawing.Point(424, 136)
'            Me.txtUPC.Name = "txtUPC"
'            Me.txtUPC.Size = New System.Drawing.Size(176, 20)
'            Me.txtUPC.TabIndex = 18
'            Me.txtUPC.Text = ""
'            '
'            'chkPO
'            '
'            Me.chkPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkPO.Location = New System.Drawing.Point(312, 160)
'            Me.chkPO.Name = "chkPO"
'            Me.chkPO.TabIndex = 56
'            Me.chkPO.TabStop = False
'            Me.chkPO.Text = "PO Number"
'            '
'            'chkUPC
'            '
'            Me.chkUPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkUPC.Location = New System.Drawing.Point(312, 136)
'            Me.chkUPC.Name = "chkUPC"
'            Me.chkUPC.TabIndex = 57
'            Me.chkUPC.TabStop = False
'            Me.chkUPC.Text = "UPC Code"
'            '
'            'txtAPC
'            '
'            Me.txtAPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtAPC.Location = New System.Drawing.Point(424, 112)
'            Me.txtAPC.Name = "txtAPC"
'            Me.txtAPC.Size = New System.Drawing.Size(96, 20)
'            Me.txtAPC.TabIndex = 17
'            Me.txtAPC.Text = ""
'            '
'            'cboCarrier
'            '
'            Me.cboCarrier.AutoComplete = True
'            Me.cboCarrier.Location = New System.Drawing.Point(120, 16)
'            Me.cboCarrier.Name = "cboCarrier"
'            Me.cboCarrier.Size = New System.Drawing.Size(192, 21)
'            Me.cboCarrier.TabIndex = 7
'            '
'            'cboShipTo
'            '
'            Me.cboShipTo.AutoComplete = True
'            Me.cboShipTo.Location = New System.Drawing.Point(120, 40)
'            Me.cboShipTo.Name = "cboShipTo"
'            Me.cboShipTo.Size = New System.Drawing.Size(192, 21)
'            Me.cboShipTo.TabIndex = 8
'            '
'            'cboWarranty
'            '
'            Me.cboWarranty.AutoComplete = True
'            Me.cboWarranty.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboWarranty.Location = New System.Drawing.Point(120, 184)
'            Me.cboWarranty.Name = "cboWarranty"
'            Me.cboWarranty.Size = New System.Drawing.Size(100, 21)
'            Me.cboWarranty.TabIndex = 14
'            '
'            'txtMemo
'            '
'            Me.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtMemo.Location = New System.Drawing.Point(424, 16)
'            Me.txtMemo.Multiline = True
'            Me.txtMemo.Name = "txtMemo"
'            Me.txtMemo.Size = New System.Drawing.Size(176, 88)
'            Me.txtMemo.TabIndex = 16
'            Me.txtMemo.Text = ""
'            '
'            'chkMemo
'            '
'            Me.chkMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkMemo.Location = New System.Drawing.Point(312, 16)
'            Me.chkMemo.Name = "chkMemo"
'            Me.chkMemo.TabIndex = 15
'            Me.chkMemo.TabStop = False
'            Me.chkMemo.Text = "Memo"
'            '
'            'txtDockDate
'            '
'            Me.txtDockDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtDockDate.Location = New System.Drawing.Point(120, 208)
'            Me.txtDockDate.Name = "txtDockDate"
'            Me.txtDockDate.TabIndex = 15
'            Me.txtDockDate.Text = ""
'            '
'            'txtSKU
'            '
'            Me.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtSKU.Location = New System.Drawing.Point(120, 160)
'            Me.txtSKU.Name = "txtSKU"
'            Me.txtSKU.TabIndex = 13
'            Me.txtSKU.Text = ""
'            '
'            'txtRAQuantity
'            '
'            Me.txtRAQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtRAQuantity.Location = New System.Drawing.Point(120, 136)
'            Me.txtRAQuantity.Name = "txtRAQuantity"
'            Me.txtRAQuantity.TabIndex = 12
'            Me.txtRAQuantity.Text = ""
'            '
'            'txtIP
'            '
'            Me.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtIP.Location = New System.Drawing.Point(120, 112)
'            Me.txtIP.Name = "txtIP"
'            Me.txtIP.TabIndex = 11
'            Me.txtIP.Text = ""
'            '
'            'txtPRL
'            '
'            Me.txtPRL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtPRL.Location = New System.Drawing.Point(120, 88)
'            Me.txtPRL.Name = "txtPRL"
'            Me.txtPRL.TabIndex = 10
'            Me.txtPRL.Text = ""
'            '
'            'txtQuantity
'            '
'            Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtQuantity.Location = New System.Drawing.Point(120, 64)
'            Me.txtQuantity.Name = "txtQuantity"
'            Me.txtQuantity.TabIndex = 9
'            Me.txtQuantity.Text = ""
'            '
'            'chkCarrier
'            '
'            Me.chkCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkCarrier.Location = New System.Drawing.Point(8, 16)
'            Me.chkCarrier.Name = "chkCarrier"
'            Me.chkCarrier.TabIndex = 0
'            Me.chkCarrier.TabStop = False
'            Me.chkCarrier.Text = "Carrier"
'            '
'            'chkWarranty
'            '
'            Me.chkWarranty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkWarranty.Location = New System.Drawing.Point(8, 184)
'            Me.chkWarranty.Name = "chkWarranty"
'            Me.chkWarranty.TabIndex = 0
'            Me.chkWarranty.TabStop = False
'            Me.chkWarranty.Text = "Warranty"
'            '
'            'chkPRL
'            '
'            Me.chkPRL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkPRL.Location = New System.Drawing.Point(8, 88)
'            Me.chkPRL.Name = "chkPRL"
'            Me.chkPRL.TabIndex = 0
'            Me.chkPRL.TabStop = False
'            Me.chkPRL.Text = "PRL"
'            '
'            'chkIP
'            '
'            Me.chkIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkIP.Location = New System.Drawing.Point(8, 112)
'            Me.chkIP.Name = "chkIP"
'            Me.chkIP.TabIndex = 0
'            Me.chkIP.TabStop = False
'            Me.chkIP.Text = "IP"
'            '
'            'chkDockDate
'            '
'            Me.chkDockDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkDockDate.Location = New System.Drawing.Point(8, 208)
'            Me.chkDockDate.Name = "chkDockDate"
'            Me.chkDockDate.TabIndex = 0
'            Me.chkDockDate.TabStop = False
'            Me.chkDockDate.Text = "Dock Date"
'            '
'            'chkQuantity
'            '
'            Me.chkQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkQuantity.Location = New System.Drawing.Point(8, 64)
'            Me.chkQuantity.Name = "chkQuantity"
'            Me.chkQuantity.TabIndex = 0
'            Me.chkQuantity.TabStop = False
'            Me.chkQuantity.Text = "Quantity"
'            '
'            'chkShipTo
'            '
'            Me.chkShipTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkShipTo.Location = New System.Drawing.Point(8, 40)
'            Me.chkShipTo.Name = "chkShipTo"
'            Me.chkShipTo.TabIndex = 0
'            Me.chkShipTo.TabStop = False
'            Me.chkShipTo.Text = "Ship To"
'            '
'            'chkSKU
'            '
'            Me.chkSKU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkSKU.Location = New System.Drawing.Point(8, 160)
'            Me.chkSKU.Name = "chkSKU"
'            Me.chkSKU.TabIndex = 0
'            Me.chkSKU.TabStop = False
'            Me.chkSKU.Text = "SKU"
'            '
'            'chkRAQuantity
'            '
'            Me.chkRAQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkRAQuantity.Location = New System.Drawing.Point(8, 136)
'            Me.chkRAQuantity.Name = "chkRAQuantity"
'            Me.chkRAQuantity.TabIndex = 0
'            Me.chkRAQuantity.TabStop = False
'            Me.chkRAQuantity.Text = "RA Quantity"
'            '
'            'chkAPC
'            '
'            Me.chkAPC.Enabled = False
'            Me.chkAPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkAPC.Location = New System.Drawing.Point(312, 112)
'            Me.chkAPC.Name = "chkAPC"
'            Me.chkAPC.Size = New System.Drawing.Size(104, 16)
'            Me.chkAPC.TabIndex = 55
'            Me.chkAPC.TabStop = False
'            Me.chkAPC.Text = "APC Code OUT"
'            '
'            'tbDevice
'            '
'            Me.tbDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.txtPOP, Me.chkDateCode, Me.chkPOP, Me.txtDateCode})
'            Me.tbDevice.Location = New System.Drawing.Point(4, 22)
'            Me.tbDevice.Name = "tbDevice"
'            Me.tbDevice.Size = New System.Drawing.Size(648, 262)
'            Me.tbDevice.TabIndex = 1
'            Me.tbDevice.Text = "Device"
'            '
'            'GroupBox1
'            '
'            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAirtime, Me.chkSVIN, Me.txtComment, Me.Label2, Me.txtFlexVer, Me.lblFlexVer, Me.txtSUG, Me.Label1, Me.lbl20pct, Me.txt20pct, Me.txtIncIMEI, Me.chkIncIMEI, Me.txtAirtime, Me.txtSoftVerOUT, Me.txtSoftVerIN, Me.lblAirtime, Me.lblSoftOUT, Me.lblSoftIN, Me.cboTransaction, Me.cboComplaint, Me.cboReturn, Me.txtProduct, Me.txtMIN, Me.txtCarrierModel, Me.txtTransceiver, Me.txtCourierTrackIN, Me.chkCourierTrackIN, Me.chkTransaction, Me.chkReturn, Me.chkMIN, Me.chkComplaint, Me.chkCarrierModel, Me.chkTransceiver, Me.chkProduct, Me.CheckBox2, Me.CheckBox6, Me.CheckBox7, Me.CheckBox9, Me.CheckBox10, Me.CheckBox11})
'            Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
'            Me.GroupBox1.Name = "GroupBox1"
'            Me.GroupBox1.Size = New System.Drawing.Size(616, 240)
'            Me.GroupBox1.TabIndex = 39
'            Me.GroupBox1.TabStop = False
'            Me.GroupBox1.Text = "Device Specific"
'            '
'            'txtComment
'            '
'            Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtComment.Location = New System.Drawing.Point(472, 160)
'            Me.txtComment.Multiline = True
'            Me.txtComment.Name = "txtComment"
'            Me.txtComment.Size = New System.Drawing.Size(128, 72)
'            Me.txtComment.TabIndex = 35
'            Me.txtComment.Text = ""
'            '
'            'Label2
'            '
'            Me.Label2.Location = New System.Drawing.Point(344, 160)
'            Me.Label2.Name = "Label2"
'            Me.Label2.Size = New System.Drawing.Size(120, 16)
'            Me.Label2.TabIndex = 47
'            Me.Label2.Text = "Comment:"
'            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtFlexVer
'            '
'            Me.txtFlexVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtFlexVer.Location = New System.Drawing.Point(472, 136)
'            Me.txtFlexVer.Name = "txtFlexVer"
'            Me.txtFlexVer.Size = New System.Drawing.Size(128, 20)
'            Me.txtFlexVer.TabIndex = 34
'            Me.txtFlexVer.Text = ""
'            '
'            'lblFlexVer
'            '
'            Me.lblFlexVer.Location = New System.Drawing.Point(344, 136)
'            Me.lblFlexVer.Name = "lblFlexVer"
'            Me.lblFlexVer.Size = New System.Drawing.Size(120, 16)
'            Me.lblFlexVer.TabIndex = 45
'            Me.lblFlexVer.Text = "Flex Version:"
'            Me.lblFlexVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtSUG
'            '
'            Me.txtSUG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtSUG.Location = New System.Drawing.Point(472, 112)
'            Me.txtSUG.Name = "txtSUG"
'            Me.txtSUG.Size = New System.Drawing.Size(128, 20)
'            Me.txtSUG.TabIndex = 33
'            Me.txtSUG.Text = ""
'            '
'            'Label1
'            '
'            Me.Label1.Location = New System.Drawing.Point(344, 112)
'            Me.Label1.Name = "Label1"
'            Me.Label1.Size = New System.Drawing.Size(120, 16)
'            Me.Label1.TabIndex = 43
'            Me.Label1.Text = "SUG:"
'            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lbl20pct
'            '
'            Me.lbl20pct.Location = New System.Drawing.Point(344, 88)
'            Me.lbl20pct.Name = "lbl20pct"
'            Me.lbl20pct.Size = New System.Drawing.Size(120, 16)
'            Me.lbl20pct.TabIndex = 42
'            Me.lbl20pct.Text = "20% label:"
'            Me.lbl20pct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txt20pct
'            '
'            Me.txt20pct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txt20pct.Location = New System.Drawing.Point(472, 88)
'            Me.txt20pct.Name = "txt20pct"
'            Me.txt20pct.Size = New System.Drawing.Size(128, 20)
'            Me.txt20pct.TabIndex = 32
'            Me.txt20pct.Text = ""
'            '
'            'txtIncIMEI
'            '
'            Me.txtIncIMEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtIncIMEI.Location = New System.Drawing.Point(128, 16)
'            Me.txtIncIMEI.Name = "txtIncIMEI"
'            Me.txtIncIMEI.TabIndex = 20
'            Me.txtIncIMEI.Text = ""
'            '
'            'chkIncIMEI
'            '
'            Me.chkIncIMEI.Enabled = False
'            Me.chkIncIMEI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkIncIMEI.Location = New System.Drawing.Point(8, 16)
'            Me.chkIncIMEI.Name = "chkIncIMEI"
'            Me.chkIncIMEI.Size = New System.Drawing.Size(120, 24)
'            Me.chkIncIMEI.TabIndex = 41
'            Me.chkIncIMEI.TabStop = False
'            Me.chkIncIMEI.Text = "Incoming IMEI"
'            '
'            'txtAirtime
'            '
'            Me.txtAirtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtAirtime.Location = New System.Drawing.Point(472, 64)
'            Me.txtAirtime.Name = "txtAirtime"
'            Me.txtAirtime.Size = New System.Drawing.Size(64, 20)
'            Me.txtAirtime.TabIndex = 31
'            Me.txtAirtime.Text = ""
'            '
'            'txtSoftVerOUT
'            '
'            Me.txtSoftVerOUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtSoftVerOUT.Location = New System.Drawing.Point(472, 40)
'            Me.txtSoftVerOUT.Name = "txtSoftVerOUT"
'            Me.txtSoftVerOUT.Size = New System.Drawing.Size(128, 20)
'            Me.txtSoftVerOUT.TabIndex = 30
'            Me.txtSoftVerOUT.Text = ""
'            '
'            'txtSoftVerIN
'            '
'            Me.txtSoftVerIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtSoftVerIN.Location = New System.Drawing.Point(472, 16)
'            Me.txtSoftVerIN.Name = "txtSoftVerIN"
'            Me.txtSoftVerIN.Size = New System.Drawing.Size(128, 20)
'            Me.txtSoftVerIN.TabIndex = 29
'            Me.txtSoftVerIN.Text = ""
'            '
'            'lblAirtime
'            '
'            Me.lblAirtime.Location = New System.Drawing.Point(344, 64)
'            Me.lblAirtime.Name = "lblAirtime"
'            Me.lblAirtime.Size = New System.Drawing.Size(120, 16)
'            Me.lblAirtime.TabIndex = 30
'            Me.lblAirtime.Text = "Airtime:"
'            Me.lblAirtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblSoftOUT
'            '
'            Me.lblSoftOUT.Location = New System.Drawing.Point(344, 40)
'            Me.lblSoftOUT.Name = "lblSoftOUT"
'            Me.lblSoftOUT.Size = New System.Drawing.Size(120, 16)
'            Me.lblSoftOUT.TabIndex = 29
'            Me.lblSoftOUT.Text = "Software Version OUT:"
'            Me.lblSoftOUT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblSoftIN
'            '
'            Me.lblSoftIN.Location = New System.Drawing.Point(344, 16)
'            Me.lblSoftIN.Name = "lblSoftIN"
'            Me.lblSoftIN.Size = New System.Drawing.Size(120, 16)
'            Me.lblSoftIN.TabIndex = 28
'            Me.lblSoftIN.Text = "Software Version IN:"
'            Me.lblSoftIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'cboTransaction
'            '
'            Me.cboTransaction.AutoComplete = True
'            Me.cboTransaction.Location = New System.Drawing.Point(128, 64)
'            Me.cboTransaction.Name = "cboTransaction"
'            Me.cboTransaction.Size = New System.Drawing.Size(136, 21)
'            Me.cboTransaction.TabIndex = 22
'            '
'            'cboComplaint
'            '
'            Me.cboComplaint.AutoComplete = True
'            Me.cboComplaint.Location = New System.Drawing.Point(128, 184)
'            Me.cboComplaint.Name = "cboComplaint"
'            Me.cboComplaint.Size = New System.Drawing.Size(176, 21)
'            Me.cboComplaint.TabIndex = 27
'            '
'            'cboReturn
'            '
'            Me.cboReturn.AutoComplete = True
'            Me.cboReturn.Location = New System.Drawing.Point(128, 208)
'            Me.cboReturn.Name = "cboReturn"
'            Me.cboReturn.Size = New System.Drawing.Size(176, 21)
'            Me.cboReturn.TabIndex = 28
'            '
'            'txtProduct
'            '
'            Me.txtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtProduct.Location = New System.Drawing.Point(128, 160)
'            Me.txtProduct.Name = "txtProduct"
'            Me.txtProduct.TabIndex = 26
'            Me.txtProduct.Text = ""
'            '
'            'txtMIN
'            '
'            Me.txtMIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtMIN.Location = New System.Drawing.Point(128, 136)
'            Me.txtMIN.Name = "txtMIN"
'            Me.txtMIN.TabIndex = 25
'            Me.txtMIN.Text = ""
'            '
'            'txtCarrierModel
'            '
'            Me.txtCarrierModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtCarrierModel.Location = New System.Drawing.Point(128, 112)
'            Me.txtCarrierModel.Name = "txtCarrierModel"
'            Me.txtCarrierModel.TabIndex = 24
'            Me.txtCarrierModel.Text = ""
'            '
'            'txtTransceiver
'            '
'            Me.txtTransceiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtTransceiver.Location = New System.Drawing.Point(128, 88)
'            Me.txtTransceiver.Name = "txtTransceiver"
'            Me.txtTransceiver.TabIndex = 23
'            Me.txtTransceiver.Text = ""
'            '
'            'txtCourierTrackIN
'            '
'            Me.txtCourierTrackIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtCourierTrackIN.Location = New System.Drawing.Point(128, 40)
'            Me.txtCourierTrackIN.Name = "txtCourierTrackIN"
'            Me.txtCourierTrackIN.TabIndex = 21
'            Me.txtCourierTrackIN.Text = ""
'            '
'            'chkCourierTrackIN
'            '
'            Me.chkCourierTrackIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkCourierTrackIN.Location = New System.Drawing.Point(8, 40)
'            Me.chkCourierTrackIN.Name = "chkCourierTrackIN"
'            Me.chkCourierTrackIN.Size = New System.Drawing.Size(120, 24)
'            Me.chkCourierTrackIN.TabIndex = 0
'            Me.chkCourierTrackIN.TabStop = False
'            Me.chkCourierTrackIN.Text = "Courier Tracking IN"
'            '
'            'chkTransaction
'            '
'            Me.chkTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkTransaction.Location = New System.Drawing.Point(8, 64)
'            Me.chkTransaction.Name = "chkTransaction"
'            Me.chkTransaction.Size = New System.Drawing.Size(120, 24)
'            Me.chkTransaction.TabIndex = 0
'            Me.chkTransaction.TabStop = False
'            Me.chkTransaction.Text = "Transaction Code"
'            '
'            'chkReturn
'            '
'            Me.chkReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkReturn.Location = New System.Drawing.Point(8, 208)
'            Me.chkReturn.Name = "chkReturn"
'            Me.chkReturn.Size = New System.Drawing.Size(120, 24)
'            Me.chkReturn.TabIndex = 0
'            Me.chkReturn.TabStop = False
'            Me.chkReturn.Text = "Return Code"
'            '
'            'chkMIN
'            '
'            Me.chkMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkMIN.Location = New System.Drawing.Point(8, 136)
'            Me.chkMIN.Name = "chkMIN"
'            Me.chkMIN.Size = New System.Drawing.Size(120, 24)
'            Me.chkMIN.TabIndex = 0
'            Me.chkMIN.TabStop = False
'            Me.chkMIN.Text = "MIN Number"
'            '
'            'chkComplaint
'            '
'            Me.chkComplaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkComplaint.Location = New System.Drawing.Point(8, 184)
'            Me.chkComplaint.Name = "chkComplaint"
'            Me.chkComplaint.Size = New System.Drawing.Size(120, 24)
'            Me.chkComplaint.TabIndex = 0
'            Me.chkComplaint.TabStop = False
'            Me.chkComplaint.Text = "Complaint Code"
'            '
'            'chkCarrierModel
'            '
'            Me.chkCarrierModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkCarrierModel.Location = New System.Drawing.Point(8, 112)
'            Me.chkCarrierModel.Name = "chkCarrierModel"
'            Me.chkCarrierModel.Size = New System.Drawing.Size(120, 24)
'            Me.chkCarrierModel.TabIndex = 0
'            Me.chkCarrierModel.TabStop = False
'            Me.chkCarrierModel.Text = "Carrier Model Code"
'            '
'            'chkTransceiver
'            '
'            Me.chkTransceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkTransceiver.Location = New System.Drawing.Point(8, 88)
'            Me.chkTransceiver.Name = "chkTransceiver"
'            Me.chkTransceiver.Size = New System.Drawing.Size(120, 24)
'            Me.chkTransceiver.TabIndex = 0
'            Me.chkTransceiver.TabStop = False
'            Me.chkTransceiver.Text = "Transceiver Code"
'            '
'            'chkProduct
'            '
'            Me.chkProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkProduct.Location = New System.Drawing.Point(8, 160)
'            Me.chkProduct.Name = "chkProduct"
'            Me.chkProduct.Size = New System.Drawing.Size(120, 24)
'            Me.chkProduct.TabIndex = 0
'            Me.chkProduct.TabStop = False
'            Me.chkProduct.Text = "Product Code"
'            '
'            'CheckBox2
'            '
'            Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.CheckBox2.Location = New System.Drawing.Point(8, 200)
'            Me.CheckBox2.Name = "CheckBox2"
'            Me.CheckBox2.Size = New System.Drawing.Size(120, 24)
'            Me.CheckBox2.TabIndex = 0
'            Me.CheckBox2.TabStop = False
'            Me.CheckBox2.Text = "Return Code"
'            '
'            'CheckBox6
'            '
'            Me.CheckBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.CheckBox6.Location = New System.Drawing.Point(8, 128)
'            Me.CheckBox6.Name = "CheckBox6"
'            Me.CheckBox6.Size = New System.Drawing.Size(120, 24)
'            Me.CheckBox6.TabIndex = 0
'            Me.CheckBox6.TabStop = False
'            Me.CheckBox6.Text = "MIN Number"
'            '
'            'CheckBox7
'            '
'            Me.CheckBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.CheckBox7.Location = New System.Drawing.Point(8, 176)
'            Me.CheckBox7.Name = "CheckBox7"
'            Me.CheckBox7.Size = New System.Drawing.Size(120, 24)
'            Me.CheckBox7.TabIndex = 0
'            Me.CheckBox7.TabStop = False
'            Me.CheckBox7.Text = "Complaint Code"
'            '
'            'CheckBox9
'            '
'            Me.CheckBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.CheckBox9.Location = New System.Drawing.Point(8, 104)
'            Me.CheckBox9.Name = "CheckBox9"
'            Me.CheckBox9.Size = New System.Drawing.Size(120, 24)
'            Me.CheckBox9.TabIndex = 0
'            Me.CheckBox9.TabStop = False
'            Me.CheckBox9.Text = "Carrier Model Code"
'            '
'            'CheckBox10
'            '
'            Me.CheckBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.CheckBox10.Location = New System.Drawing.Point(8, 80)
'            Me.CheckBox10.Name = "CheckBox10"
'            Me.CheckBox10.Size = New System.Drawing.Size(120, 24)
'            Me.CheckBox10.TabIndex = 0
'            Me.CheckBox10.TabStop = False
'            Me.CheckBox10.Text = "Transceiver Code"
'            '
'            'CheckBox11
'            '
'            Me.CheckBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.CheckBox11.Location = New System.Drawing.Point(8, 152)
'            Me.CheckBox11.Name = "CheckBox11"
'            Me.CheckBox11.Size = New System.Drawing.Size(120, 24)
'            Me.CheckBox11.TabIndex = 0
'            Me.CheckBox11.TabStop = False
'            Me.CheckBox11.Text = "Product Code"
'            '
'            'txtPOP
'            '
'            Me.txtPOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtPOP.Enabled = False
'            Me.txtPOP.Location = New System.Drawing.Point(234, 175)
'            Me.txtPOP.Name = "txtPOP"
'            Me.txtPOP.TabIndex = 38
'            Me.txtPOP.Text = ""
'            '
'            'chkDateCode
'            '
'            Me.chkDateCode.Enabled = False
'            Me.chkDateCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkDateCode.Location = New System.Drawing.Point(90, 151)
'            Me.chkDateCode.Name = "chkDateCode"
'            Me.chkDateCode.Size = New System.Drawing.Size(136, 24)
'            Me.chkDateCode.TabIndex = 35
'            Me.chkDateCode.TabStop = False
'            Me.chkDateCode.Text = "Date Code"
'            '
'            'chkPOP
'            '
'            Me.chkPOP.Enabled = False
'            Me.chkPOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkPOP.Location = New System.Drawing.Point(90, 175)
'            Me.chkPOP.Name = "chkPOP"
'            Me.chkPOP.Size = New System.Drawing.Size(136, 24)
'            Me.chkPOP.TabIndex = 36
'            Me.chkPOP.TabStop = False
'            Me.chkPOP.Text = "Proof of Purchase"
'            '
'            'txtDateCode
'            '
'            Me.txtDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtDateCode.Enabled = False
'            Me.txtDateCode.Location = New System.Drawing.Point(234, 151)
'            Me.txtDateCode.Name = "txtDateCode"
'            Me.txtDateCode.TabIndex = 37
'            Me.txtDateCode.Text = ""
'            '
'            'lblGroup
'            '
'            Me.lblGroup.Location = New System.Drawing.Point(496, 40)
'            Me.lblGroup.Name = "lblGroup"
'            Me.lblGroup.Size = New System.Drawing.Size(40, 16)
'            Me.lblGroup.TabIndex = 126
'            Me.lblGroup.Text = "Group:"
'            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'cboGroup
'            '
'            Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'            Me.cboGroup.Items.AddRange(New Object() {"Flashing", "Level 1.5 Repair"})
'            Me.cboGroup.Location = New System.Drawing.Point(544, 40)
'            Me.cboGroup.Name = "cboGroup"
'            Me.cboGroup.Size = New System.Drawing.Size(120, 21)
'            Me.cboGroup.TabIndex = 6
'            '
'            'chkSVIN
'            '
'            Me.chkSVIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkSVIN.Location = New System.Drawing.Point(280, 16)
'            Me.chkSVIN.Name = "chkSVIN"
'            Me.chkSVIN.Size = New System.Drawing.Size(64, 16)
'            Me.chkSVIN.TabIndex = 58
'            Me.chkSVIN.TabStop = False
'            Me.chkSVIN.Text = "Soft IN"
'            '
'            'chkAirtime
'            '
'            Me.chkAirtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
'            Me.chkAirtime.Location = New System.Drawing.Point(280, 64)
'            Me.chkAirtime.Name = "chkAirtime"
'            Me.chkAirtime.Size = New System.Drawing.Size(56, 16)
'            Me.chkAirtime.TabIndex = 59
'            Me.chkAirtime.TabStop = False
'            Me.chkAirtime.Text = "Airtime"
'            '
'            'frmPreload_Workorder
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.ClientSize = New System.Drawing.Size(688, 421)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGroup, Me.cboGroup, Me.TabControl1, Me.cboManufacturer, Me.cboCustomer, Me.cboLocation, Me.cboModel, Me.btnSAVE, Me.lblModel, Me.lblManufacturer, Me.lblLocation, Me.lblCustomer, Me.txtWorkOrderNumber, Me.lblWorkorderNumber})
'            Me.Name = "frmPreload_Workorder"
'            Me.Text = "frmPreload_Workorder"
'            Me.TabControl1.ResumeLayout(False)
'            Me.tbCustomer.ResumeLayout(False)
'            Me.GroupBox2.ResumeLayout(False)
'            Me.tbDevice.ResumeLayout(False)
'            Me.GroupBox1.ResumeLayout(False)
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Private Sub frmPreload_Workorder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            'mOnLoad = 1
'            'PopulateCustomer()
'            'System.Windows.Forms.Application.DoEvents()
'            'cboCustomer.Text = ""
'            'populateManufacturers()
'            'mOnLoad = 0
'            txtWorkOrderNumber.Focus()
'            populateGroups()
'            populateSKULength()
'        End Sub


'        Private Sub populateSKULength()

'            Dim dtSource As PSS.Data.Production.Joins
'            Dim strSQL As String

'            strSQL = "SELECT * FROM tskudescription ORDER BY skudesc_Desc"

'            dtSKUlength = dtSource.OrderEntrySelect(strSQL)
'            cboSkuLength.DataSource = dtSKUlength
'            cboSkuLength.DisplayMember = dtSKUlength.Columns("skuDESC_Desc").ToString
'            cboSkuLength.ValueMember = dtSKUlength.Columns("skuDESC_ID").ToString
'            cboSkuLength.Text = ""
'            chkSkuLength.Checked = True
'        End Sub

'        Private Sub populateGroups()


'            Dim dtSource As PSS.Data.Production.Joins
'            Dim strSQL As String

'            strSQL = "SELECT * FROM lgroups ORDER BY Group_Desc"

'            dtGroup = dtSource.OrderEntrySelect(strSQL)
'            cboGroup.DataSource = dtGroup
'            cboGroup.DisplayMember = dtGroup.Columns("Group_Desc").ToString
'            cboGroup.ValueMember = dtGroup.Columns("Group_ID").ToString
'            cboGroup.Text = ""

'        End Sub



'        Private Sub txtWorkOrderNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWorkOrderNumber.KeyUp
'            If e.KeyCode = 13 Then 'ENTER key has been pressed
'                cboCustomer.Focus()
'            End If


'        End Sub

'        Private Sub PerformInitialLoads()
'            mOnLoad = 1
'            PopulateCustomer()
'            System.Windows.Forms.Application.DoEvents()
'            cboCustomer.Text = ""
'            populateManufacturers()
'            mOnLoad = 0
'            txtWorkOrderNumber.Focus()
'        End Sub



'        Private Sub PopulateCustomer()
'            Try
'                Dim tblCust As New PSS.Data.Production.tcustomer()
'                Dim dtCust As DataTable = tblCust.GetCustomersOrdered

'                cboCustomer.DataSource = dtCust
'                cboCustomer.DisplayMember = dtCust.Columns("Cust_Name1").ToString

'                cboCustomer.Text = ""
'            Catch ex As Exception
'            End Try
'        End Sub

'        Private Sub PopulateLocations(ByVal mCustomer As Int32)
'            Try
'                Dim tblLoc As New PSS.Data.Production.tlocation()
'                Dim dtLoc As DataTable = tblLoc.GetRowsByCustomerID(mCustomer)
'                cboLocation.DataSource = dtLoc
'                cboLocation.DisplayMember = dtLoc.Columns("Loc_Name").ToString
'                cboLocation.ValueMember = dtLoc.Columns("Loc_ID").ToString
'            Catch ex As Exception
'            End Try
'        End Sub

'        Private Sub populateManufacturers()
'            Try
'                Dim iManuf_id As Integer = 40 'Trimble
'                Dim tblManuf As New PSS.Data.Production.lmanuf()
'                'Dim dtManuf As DataTable = tblManuf.GetManufacturer
'                Dim dtManuf As DataTable = tblManuf.GetManufacturer(iManuf_id)
'                cboManufacturer.DataSource = dtManuf
'                cboManufacturer.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
'                cboManufacturer.ValueMember = dtManuf.Columns("Manuf_ID").ToString
'                cboManufacturer.Text = ""
'            Catch ex As Exception
'            End Try

'        End Sub

'        Private Sub populateModels()
'            Try
'                Dim tblModel As New PSS.Data.Production.tmodel()
'                'Dim dtModel As DataTable = tblModel.GetDataTableByManufCELL(cboManufacturer.SelectedValue)
'                Dim dtModel As DataTable = tblModel.GetDataTableByManufCELLNEW(cboManufacturer.SelectedValue, mProdID)
'                cboModel.DataSource = dtModel
'                cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
'                cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
'                cboModel.Text = ""
'            Catch ex As Exception
'            End Try
'        End Sub

'        Private Sub populateComplaints()
'            Try
'                Dim tblComplaints As New PSS.Data.Production.lcodesdetail()
'                Dim dtComplaint As DataTable = tblComplaints.GetCodesCELL(5, cboManufacturer.SelectedValue)
'                cboComplaint.DataSource = dtComplaint
'                cboComplaint.DisplayMember = dtComplaint.Columns("Dcode_ldesc").ToString
'                cboComplaint.SelectedValue = dtComplaint.Columns("Dcode_ID").ToString
'                cboComplaint.Text = ""
'            Catch ex As Exception
'            End Try
'        End Sub

'        Private Sub populateReturn()
'            Try
'                If mCustID = 1653 Or mCustID = 2019 Then
'                    Dim tblReturns As New PSS.Data.Production.lcodesdetail()
'                    Dim dtReturn As DataTable = tblReturns.GetCodesCELL(19, 0)
'                    cboReturn.DataSource = dtReturn
'                    cboReturn.DisplayMember = dtReturn.Columns("Dcode_ldesc").ToString
'                    cboReturn.SelectedValue = dtReturn.Columns("Dcode_ID").ToString
'                    cboReturn.Text = ""
'                Else
'                    cboReturn.DataSource = Nothing
'                    Dim tblReturns As New PSS.Data.Production.lcodesdetail()
'                    Dim dtReturn As DataTable = tblReturns.GetCodesCELL(19, 1)
'                    cboReturn.DataSource = dtReturn
'                    cboReturn.DisplayMember = dtReturn.Columns("Dcode_ldesc").ToString
'                    cboReturn.SelectedValue = dtReturn.Columns("Dcode_ID").ToString
'                    cboReturn.Text = ""
'                End If
'            Catch ex As Exception
'            End Try
'        End Sub

'        Private Sub getCustomerID()
'            If Len(Trim(cboCustomer.Text)) > 0 Then
'                '//Set value for mCustID
'                Dim gc As New PSS.Data.Production.tcustomer()
'                Dim rGC As DataRow = gc.GetRowByName(cboCustomer.Text)
'                mCustID = rGC("Cust_ID")
'                gc = Nothing
'            End If
'        End Sub


'        Private Sub txtWorkOrderNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWorkOrderNumber.Leave

'            If mOnLoad = 0 Then
'                If Len(Trim(txtWorkOrderNumber.Text)) < 1 Then
'                    MsgBox("Workorder number must be entered before continuing.", MsgBoxStyle.OKOnly)
'                    txtWorkOrderNumber.Focus()
'                Else
'                    'PerformInitialLoads()
'                    'System.Windows.Forms.Application.DoEvents()

'                    '//Verify value to database
'                    Dim tWO As New PSS.Data.Production.tworkorder()
'                    Dim dtwo As DataTable = tWO.GetCustWObyName(txtWorkOrderNumber.Text)
'                    Dim rWO As DataRow
'                    Dim tmpWO As Int32

'                    System.Windows.Forms.Application.DoEvents()
'                    If dtwo.Rows.Count > 0 Then
'                        If dtwo.Rows.Count > 1 Then
'                            MsgBox("Error contact IT", MsgBoxStyle.OKOnly)
'                            txtWorkOrderNumber.Focus()
'                            Exit Sub
'                        End If
'                        rWO = dtwo.Rows(0)
'                        tmpWO = rWO("WO_ID")
'                        mLocation = rWO("Loc_ID")

'                        If IsDBNull(rWO("WO_Memo")) = False Then
'                            txtMemo.Text = rWO("WO_Memo")
'                            chkMemo.Checked = True
'                        End If








'                        If IsDBNull(rWO("WO_Label20")) = False Then txt20pct.Text = rWO("WO_Label20")

'                        '//Load data to form
'                        '//Acquiring data
'                        Dim r As DataRow
'                        Dim tmpCustID As Int32
'                        '//Get data from tpreloadwo to get cust_id
'                        Dim tPLwo As New PSS.Data.Production.tpreloadwo()
'                        Dim dtPLWO As DataTable = tPLwo.GetWOpreloadWO(tmpWO)
'                        r = dtPLWO.Rows(0)
'                        tmpCustID = r("Cust_ID")
'                        Dim tPLcust As New PSS.Data.Production.tpreloadcust()
'                        Dim dtPLcust As DataTable = tPLcust.GetCustSelection(tmpCustID)
'                        Dim tPLwodata As New PSS.Data.Production.tpreloadwodata()
'                        Dim dtPLwodata As DataTable = tPLwodata.GetWOpreloaddata(tmpCustID, tmpWO)
'                        '//load data to form
'                        '//Load customer preload elements

'                        mCustID = tmpCustID

'                        loadCheckBoxesCustomer()
'                        'load extra elements from tpreloadwo
'                        r = dtPLWO.Rows(0)


'                        If chkSkuLength.Enabled = True Then
'                            If chkSkuLength.Checked = False Then
'                                If r("plwo_SKUlength") = 1 Then chkSkuLength.Checked = True
'                            End If
'                        End If

'                        If chkCarrier.Enabled = True Then
'                            If chkCarrier.Checked = False Then
'                                If r("plwo_Carrier") = 1 Then chkCarrier.Checked = True
'                            End If
'                        End If

'                        If chkShipTo.Enabled = True Then
'                            If chkShipTo.Checked = False Then
'                                If r("plwo_ShipTo") = 1 Then chkShipTo.Checked = True
'                            End If
'                        End If

'                        If chkQuantity.Enabled = True Then
'                            If chkQuantity.Checked = False Then
'                                If r("plwo_quantity") = 1 Then chkQuantity.Checked = True
'                            End If
'                        End If

'                        If chkPRL.Enabled = True Then
'                            If chkPRL.Checked = False Then
'                                If r("plwo_PRL") = 1 Then chkPRL.Checked = True
'                            End If
'                        End If

'                        If chkIP.Enabled = True Then
'                            If chkIP.Checked = False Then
'                                If r("plwo_IP") = 1 Then chkIP.Checked = True
'                            End If
'                        End If

'                        If chkRAQuantity.Enabled = True Then
'                            If chkRAQuantity.Checked = False Then
'                                If r("plwo_WOQuantity") = 1 Then chkRAQuantity.Checked = True
'                            End If
'                        End If

'                        If chkSKU.Enabled = True Then
'                            If chkSKU.Checked = False Then
'                                If r("plwo_SKU") = 1 Then chkSKU.Checked = True
'                            End If
'                        End If

'                        If chkDefaultSKU.Enabled = True Then
'                            If chkDefaultSKU.Checked = False Then
'                                If r("plwo_DefaultSKU") = 1 Then chkDefaultSKU.Checked = True
'                            End If
'                        End If

'                        If chkWarranty.Enabled = True Then
'                            If chkWarranty.Checked = False Then
'                                If r("plwo_Warranty") = 1 Then chkWarranty.Checked = True
'                            End If
'                        End If

'                        If chkDockDate.Enabled = True Then
'                            If chkDockDate.Checked = False Then
'                                If r("plwo_DockDate") = 1 Then chkDockDate.Checked = True
'                            End If
'                        End If

'                        If chkDateCode.Enabled = True Then
'                            If chkDateCode.Checked = False Then
'                                If r("plwo_DateCode") = 1 Then chkDateCode.Checked = True
'                            End If
'                        End If

'                        If chkPOP.Enabled = True Then
'                            If chkPOP.Checked = False Then
'                                If r("plwo_POP") = 1 Then chkPOP.Checked = True
'                            End If
'                        End If

'                        If chkAPC.Enabled = True Then
'                            If chkAPC.Checked = False Then
'                                If r("plwo_APC") = 1 Then chkAPC.Checked = True
'                            End If
'                        End If

'                        If chkIncIMEI.Enabled = True Then
'                            If chkIncIMEI.Checked = False Then
'                                If r("plwo_IncIMEI") = 1 Then chkIncIMEI.Checked = True
'                            End If
'                        End If

'                        If chkCourierTrackIN.Enabled = True Then
'                            If chkCourierTrackIN.Checked = False Then
'                                If r("plwo_CourierTrackIN") = 1 Then chkCourierTrackIN.Checked = True
'                            End If
'                        End If

'                        'If chkAirtimeCode.Enabled = True Then
'                        'If chkAirtimeCode.Checked = False Then
'                        '    If r("plwo_AirTimeCode") = 1 Then chkAirtimeCode.Checked = True
'                        'End If
'                        'End If

'                        If chkTransaction.Enabled = True Then
'                            If chkTransaction.Checked = False Then
'                                If r("plwo_Transaction") = 1 Then chkTransaction.Checked = True
'                            End If
'                        End If

'                        If chkTransceiver.Enabled = True Then
'                            If chkTransceiver.Checked = False Then
'                                If r("plwo_Transceiver") = 1 Then chkTransceiver.Checked = True
'                            End If
'                        End If

'                        If chkCarrierModel.Enabled = True Then
'                            If chkCarrierModel.Checked = False Then
'                                If r("plwo_CarrierCode") = 1 Then chkCarrierModel.Checked = True
'                            End If
'                        End If

'                        If chkMIN.Enabled = True Then
'                            If chkMIN.Checked = False Then
'                                If r("plwo_MIN") = 1 Then chkMIN.Checked = True
'                            End If
'                        End If

'                        If chkProduct.Enabled = True Then
'                            If chkProduct.Checked = False Then
'                                If r("plwo_Product") = 1 Then chkProduct.Checked = True
'                            End If
'                        End If

'                        If chkSVIN.Enabled = True Then
'                            If chkSVIN.Checked = False Then
'                                If r("plwo_SVIN") = 1 Then chkSVIN.Checked = True
'                            End If
'                        End If

'                        If chkAirtime.Enabled = True Then
'                            If chkAirtime.Checked = False Then
'                                If r("plwo_AirTime") = 1 Then chkAirtime.Checked = True
'                            End If
'                        End If

'                        If chkComplaint.Enabled = True Then
'                            If chkComplaint.Checked = False Then
'                                If r("plwo_Complaint") = 1 Then chkComplaint.Checked = True
'                            End If
'                        End If

'                        If chkReturn.Enabled = True Then
'                            If chkReturn.Checked = False Then
'                                If r("plwo_Return") = 1 Then chkReturn.Checked = True
'                            End If
'                        End If

'                        '//Get Workorder Data
'                        r = dtPLwodata.Rows(0)

'                        'get Manufacturer Data
'                        If Len(Trim(r("Manuf_ID"))) > 0 Then mManufacturer = r("Manuf_ID")

'                        Dim dtManuf As DataTable = PSS.Data.Production.lmanuf.GetManufacturer(mManufacturer)
'                        Dim rManuf As DataRow = dtManuf.Rows(0)

'                        'cboManufacturer.Text = rManuf("Manuf_Desc")
'                        cboManufacturer.Text = ""
'                        mManufacturer = rManuf("Manuf_ID")
'                        cboManufacturer.SelectedText = rManuf("Manuf_Desc")
'                        cboManufacturer.SelectedValue = rManuf("Manuf_ID")
'                        'cboManufacturer.Text = rManuf("Manuf_Desc")

'                        dtManuf.Dispose()
'                        dtManuf = Nothing

'                        'get Model Data
'                        If Len(Trim(r("Model_ID"))) > 0 Then mModel = r("Model_ID")
'                        'Dim rModel As DataRow = PSS.Data.Production.tmodel.GetRowByModel(mModel)
'                        'cboModel.Text = rModel("Model_Desc")

'                        '//Craig Haney Septermber 2, 2004
'                        populateModels()
'                        System.Windows.Forms.Application.DoEvents()
'                        cboModel.SelectedValue = mModel
'                        '//Craig Haney Septermber 2, 2004




'                        'get Location Data
'                        If Len(mLocation) > 0 Then
'                            Dim rLocation As DataRow = PSS.Data.Production.tlocation.GetRowByPK(mLocation)
'                            mCustomer = rLocation("Cust_ID")
'                            System.Windows.Forms.Application.DoEvents()
'                            PopulateLocations(mCustomer)
'                            System.Windows.Forms.Application.DoEvents()
'                            cboLocation.Text = rLocation("Loc_Name")
'                        End If

'                        cboLocation.Enabled = False

'                        'get Customer Data
'                        If Len(mCustomer) > 0 Then
'                            Dim rCustomer As DataRow = PSS.Data.Production.tcustomer.GetRowByPK(mCustomer)
'                            cboCustomer.Text = rCustomer("Cust_Name1")
'                        End If

'                        If Len(Trim(r("plwodata_carrier"))) > 0 Then
'                            Try
'                                Dim rCarrier As DataRow = PSS.Data.Production.lcodesdetail.GetvString(r("plwodata_carrier"))
'                                cboCarrier.Text = rCarrier("Dcode_LDesc")
'                            Catch EX As Exception
'                            End Try
'                        End If
'                        If IsDBNull(r("plwodata_shipto")) = False Then cboShipTo.Text = r("plwodata_shipto")
'                        If IsDBNull(r("plwodata_quantity")) = False Then txtQuantity.Text = r("plwodata_quantity")
'                        If IsDBNull(r("plwodata_PRL")) = False Then txtPRL.Text = r("plwodata_PRL")
'                        If IsDBNull(r("plwodata_IP")) = False Then txtIP.Text = r("plwodata_IP")
'                        If IsDBNull(r("plwodata_WOQuantity")) = False Then txtRAQuantity.Text = r("plwodata_WOQuantity")
'                        If IsDBNull(r("plwodata_SKU")) = False Then txtSKU.Text = r("plwodata_SKU")
'                        If IsDBNull(r("plwodata_DefaultSKU")) = False Then txtDefaultSKU.Text = r("plwodata_DefaultSKU")
'                        If IsDBNull(r("plwodata_Warranty")) = False Then
'                            If Trim(r("plwodata_Warranty")) = "E" Then cboWarranty.Text = "No Warranty"
'                            If Trim(r("plwodata_Warranty")) = "U" Then cboWarranty.Text = "90 Days"
'                            If Trim(r("plwodata_Warranty")) = "J" Then cboWarranty.Text = "1 Year"
'                        End If
'                        If IsDBNull(r("plwodata_DockDate")) = False Then
'                            txtDockDate.Text = Format(r("plwodata_DockDate"), "yyyy-MM-dd")
'                        End If
'                        If IsDBNull(r("plwodata_DateCode")) = False Then txtDateCode.Text = r("plwodata_DateCode")
'                        If IsDBNull(r("plwodata_POP")) = False Then txtPOP.Text = r("plwodata_POP")
'                        If IsDBNull(r("plwodata_APC")) = False Then txtAPC.Text = r("plwodata_APC")
'                        If IsDBNull(r("plwodata_IncIMEI")) = False Then txtIncIMEI.Text = r("plwodata_IncIMEI")
'                        If IsDBNull(r("plwodata_CourierTrackIN")) = False Then txtCourierTrackIN.Text = r("plwodata_CourierTrackIN")
'                        'If Len(Trim(r("plwodata_AirTimeCode"))) > 0 Then txtAirtimeCode.Text = r("plwodata_AirTimeCode")
'                        If IsDBNull(r("plwodata_Transaction")) = False Then cboTransaction.Text = r("plwodata_Transaction")
'                        If IsDBNull(r("plwodata_Transceiver")) = False Then txtTransceiver.Text = r("plwodata_Transceiver")
'                        If IsDBNull(r("plwodata_CarrierCode")) = False Then txtCarrierModel.Text = r("plwodata_CarrierCode")
'                        If IsDBNull(r("plwodata_MIN")) = False Then txtMIN.Text = r("plwodata_MIN")
'                        If IsDBNull(r("plwodata_Product")) = False Then txtProduct.Text = r("plwodata_Product")


'                        If IsDBNull(r("plwodata_AirTimeCode")) = False Then txtAirtime.Text = r("plwodata_AirTimeCode")
'                        If IsDBNull(r("plwodata_SoftVerIN")) = False Then txtSoftVerIN.Text = r("plwodata_SoftVerIN")
'                        If IsDBNull(r("plwodata_SoftVerOUT")) = False Then txtSoftVerOUT.Text = r("plwodata_SoftVerOUT")
'                        If IsDBNull(r("plwodata_Sug")) = False Then txtSUG.Text = r("plwodata_Sug")
'                        If IsDBNull(r("plwodata_FlexVer")) = False Then txtFlexVer.Text = r("plwodata_FlexVer")
'                        If IsDBNull(r("plwodata_comment")) = False Then txtComment.Text = r("plwodata_comment")

'                        If IsDBNull(r("plwodata_SKUlength")) = False Then cboSkuLength.SelectedValue = r("plwodata_SKUlength")


'                        If IsDBNull(r("plwodata_Complaint")) = False Then
'                            Try
'                                Dim rComplaint As DataRow = PSS.Data.Production.lcodesdetail.GetvString(r("plwodata_Complaint"))
'                                cboComplaint.Text = rComplaint("Dcode_LDesc")
'                            Catch EX As Exception
'                            End Try

'                        End If
'                        Try
'                            If IsDBNull(r("plwodata_Return")) = False Then
'                                Dim rReturn As DataRow = PSS.Data.Production.lcodesdetail.GetvString(r("plwodata_Return"))
'                                cboReturn.Text = rReturn("Dcode_LDesc")
'                            End If
'                        Catch ex As Exception
'                        End Try
'                        '//Disable elemnts after data is loaded
'                        txtWorkOrderNumber.Enabled = False
'                        cboCustomer.Enabled = False
'                        Exit Sub
'                    Else
'                        '//Accept Data
'                        txtWorkOrderNumber.Enabled = False
'                        cboCustomer.Focus()
'                        cboCustomer.BackColor = Color.Yellow
'                    End If
'                End If
'                PerformInitialLoads()
'                System.Windows.Forms.Application.DoEvents()
'            End If

'        End Sub

'        Private Sub loadCheckBoxesCustomer()
'            If mOnLoad = 0 Then
'                Dim tChk As New PSS.Data.Production.tpreloadcust()
'                Dim dtChk As DataTable = tChk.GetCustSelection(mCustID)
'                Dim xCount As Integer = 0
'                Dim r As DataRow

'                If dtChk.Rows.Count < 1 Then
'                    MsgBox("No template has been defined for this customer. Please define customer template before proceeding.", MsgBoxStyle.OKOnly)

'                End If

'                chkCarrier.Enabled = True
'                chkShipTo.Enabled = True
'                chkQuantity.Enabled = True
'                chkPRL.Enabled = True
'                chkIP.Enabled = True
'                chkRAQuantity.Enabled = True
'                chkSKU.Enabled = True
'                chkWarranty.Enabled = True
'                chkDockDate.Enabled = True
'                chkDateCode.Enabled = True
'                chkPOP.Enabled = True
'                chkAPC.Enabled = True
'                chkIncIMEI.Enabled = True
'                chkCourierTrackIN.Enabled = True
'                'chkAirtimeCode.Enabled = True
'                chkTransaction.Enabled = True
'                chkTransceiver.Enabled = True
'                chkCarrierModel.Enabled = True
'                chkMIN.Enabled = True
'                chkProduct.Enabled = True
'                chkComplaint.Enabled = True
'                chkReturn.Enabled = True

'                cboCarrier.BackColor = Color.White
'                cboShipTo.BackColor = Color.White
'                txtQuantity.BackColor = Color.White
'                txtPRL.BackColor = Color.White
'                txtIP.BackColor = Color.White
'                txtRAQuantity.BackColor = Color.White
'                txtSKU.BackColor = Color.White
'                cboWarranty.BackColor = Color.White
'                txtDockDate.BackColor = Color.White
'                txtDateCode.BackColor = Color.White
'                txtPOP.BackColor = Color.White
'                txtAPC.BackColor = Color.White
'                txtIncIMEI.BackColor = Color.White
'                txtCourierTrackIN.BackColor = Color.White
'                'txtAirtimeCode.BackColor = Color.White
'                cboTransaction.BackColor = Color.White
'                txtTransceiver.BackColor = Color.White
'                txtCarrierModel.BackColor = Color.White
'                txtMIN.BackColor = Color.White
'                txtProduct.BackColor = Color.White
'                cboComplaint.BackColor = Color.White
'                cboReturn.BackColor = Color.White

'                cboCarrier.ForeColor = Color.Black
'                cboShipTo.ForeColor = Color.Black
'                txtQuantity.ForeColor = Color.Black
'                txtPRL.ForeColor = Color.Black
'                txtIP.ForeColor = Color.Black
'                txtRAQuantity.ForeColor = Color.Black
'                txtSKU.ForeColor = Color.Black
'                cboWarranty.ForeColor = Color.Black
'                txtDockDate.ForeColor = Color.Black
'                txtDateCode.ForeColor = Color.Black
'                txtPOP.ForeColor = Color.Black
'                txtAPC.ForeColor = Color.Black
'                txtIncIMEI.ForeColor = Color.Black
'                txtCourierTrackIN.ForeColor = Color.Black
'                'txtAirtimeCode.ForeColor = Color.Black
'                cboTransaction.ForeColor = Color.Black
'                txtTransceiver.ForeColor = Color.Black
'                txtCarrierModel.ForeColor = Color.Black
'                txtMIN.ForeColor = Color.Black
'                txtProduct.ForeColor = Color.Black
'                cboComplaint.ForeColor = Color.Black
'                cboReturn.ForeColor = Color.Black

'                chkCarrier.Checked = False
'                chkShipTo.Checked = False
'                chkQuantity.Checked = False
'                chkPRL.Checked = False
'                chkIP.Checked = False
'                chkRAQuantity.Checked = False
'                chkSKU.Checked = False
'                chkWarranty.Checked = False
'                chkDockDate.Checked = False
'                chkDateCode.Checked = False
'                chkPOP.Checked = False
'                chkAPC.Checked = False
'                chkIncIMEI.Checked = False
'                chkCourierTrackIN.Checked = False
'                'chkAirtimeCode.Checked = False
'                chkTransaction.Checked = False
'                chkTransceiver.Checked = False
'                chkCarrierModel.Checked = False
'                chkMIN.Checked = False
'                chkProduct.Checked = False
'                chkComplaint.Checked = False
'                chkReturn.Checked = False

'                For xCount = 0 To dtChk.Rows.Count - 1
'                    r = dtChk.Rows(xCount)
'                    If r("plcust_Carrier") = 1 Then
'                        chkCarrier.Checked = True
'                        chkCarrier.Enabled = False
'                        cboCarrier.BackColor = Color.Yellow
'                        cboCarrier.ForeColor = Color.Red
'                    End If

'                    If r("plcust_ShipTo") = 1 Then
'                        chkShipTo.Checked = True
'                        chkShipTo.Enabled = False
'                        cboShipTo.BackColor = Color.Yellow
'                        cboShipTo.ForeColor = Color.Red
'                    End If

'                    If r("plcust_Quantity") = 1 Then
'                        chkQuantity.Checked = True
'                        chkQuantity.Enabled = False
'                        txtQuantity.BackColor = Color.Yellow
'                        txtQuantity.ForeColor = Color.Red
'                    End If

'                    If r("plcust_PRL") = 1 Then
'                        chkPRL.Checked = True
'                        chkPRL.Enabled = False
'                        txtPRL.BackColor = Color.Yellow
'                        txtPRL.ForeColor = Color.Red
'                    End If

'                    If r("plcust_IP") = 1 Then
'                        chkIP.Checked = True
'                        chkIP.Enabled = False
'                        txtIP.BackColor = Color.Yellow
'                        txtIP.ForeColor = Color.Red
'                    End If

'                    If r("plcust_WOQuantity") = 1 Then
'                        chkRAQuantity.Checked = True
'                        chkRAQuantity.Enabled = False
'                        txtRAQuantity.BackColor = Color.Yellow
'                        txtRAQuantity.ForeColor = Color.Red
'                    End If

'                    If r("plcust_SKU") = 1 Then
'                        chkSKU.Checked = True
'                        chkSKU.Enabled = False
'                        txtSKU.BackColor = Color.Yellow
'                        txtSKU.ForeColor = Color.Red
'                    End If

'                    If r("plcust_Warranty") = 1 Then
'                        chkWarranty.Checked = True
'                        chkWarranty.Enabled = False
'                        cboWarranty.BackColor = Color.Yellow
'                        cboWarranty.ForeColor = Color.Red
'                    End If

'                    If r("plcust_DockDate") = 1 Then
'                        chkDockDate.Checked = True
'                        chkDockDate.Enabled = False
'                        txtDockDate.BackColor = Color.Yellow
'                        txtDockDate.ForeColor = Color.Red
'                    End If

'                    If r("plcust_DateCode") = 1 Then
'                        chkDateCode.Checked = True
'                        chkDateCode.Enabled = False
'                        txtDateCode.BackColor = Color.Yellow
'                        txtDateCode.ForeColor = Color.Red
'                    End If

'                    If r("plcust_POP") = 1 Then
'                        chkPOP.Checked = True
'                        chkPOP.Enabled = False
'                        txtPOP.BackColor = Color.Yellow
'                        txtPOP.ForeColor = Color.Red
'                    End If

'                    If r("plcust_APC") = 1 Then
'                        chkAPC.Checked = True
'                        chkAPC.Enabled = False
'                        txtAPC.BackColor = Color.Yellow
'                        txtAPC.ForeColor = Color.Red
'                    End If

'                    If r("plcust_incIMEI") = 1 Then
'                        chkIncIMEI.Checked = True
'                        chkIncIMEI.Enabled = False
'                        txtIncIMEI.BackColor = Color.Yellow
'                        txtIncIMEI.ForeColor = Color.Red
'                    End If

'                    If r("plcust_CourierTrackIN") = 1 Then
'                        chkCourierTrackIN.Checked = True
'                        chkCourierTrackIN.Enabled = False
'                        txtCourierTrackIN.BackColor = Color.Yellow
'                        txtCourierTrackIN.ForeColor = Color.Red
'                    End If

'                    'If r("plcust_AirTimeCode") = 1 Then
'                    'chkAirtimeCode.Checked = True
'                    'chkAirtimeCode.Enabled = False
'                    'txtAirtimeCode.BackColor = Color.Yellow
'                    'txtAirtimeCode.ForeColor = Color.Red
'                    'End If

'                    If r("plcust_Transaction") = 1 Then
'                        chkTransaction.Checked = True
'                        chkTransaction.Enabled = False
'                        cboTransaction.BackColor = Color.Yellow
'                        cboTransaction.ForeColor = Color.Red
'                    End If

'                    If r("plcust_Transceiver") = 1 Then
'                        chkTransceiver.Checked = True
'                        chkTransceiver.Enabled = False
'                        txtTransceiver.BackColor = Color.Yellow
'                        txtTransceiver.ForeColor = Color.Red
'                    End If

'                    If r("plcust_CarrierCode") = 1 Then
'                        chkCarrierModel.Checked = True
'                        chkCarrierModel.Enabled = False
'                        txtCarrierModel.BackColor = Color.Yellow
'                        txtCarrierModel.ForeColor = Color.Red
'                    End If

'                    If r("plcust_MIN") = 1 Then
'                        chkMIN.Checked = True
'                        chkMIN.Enabled = False
'                        txtMIN.BackColor = Color.Yellow
'                        txtMIN.ForeColor = Color.Red
'                    End If

'                    If r("plcust_Product") = 1 Then
'                        chkProduct.Checked = True
'                        chkProduct.Enabled = False
'                        txtProduct.BackColor = Color.Yellow
'                        txtProduct.ForeColor = Color.Red
'                    End If

'                    If r("plcust_Complaint") = 1 Then
'                        chkComplaint.Checked = True
'                        chkComplaint.Enabled = False
'                        cboComplaint.BackColor = Color.Yellow
'                        cboComplaint.ForeColor = Color.Red
'                    End If

'                    If r("plcust_Return") = 1 Then
'                        chkReturn.Checked = True
'                        chkReturn.Enabled = False
'                        cboReturn.BackColor = Color.Yellow
'                        cboReturn.ForeColor = Color.Red
'                    End If
'                Next
'            End If

'        End Sub



'        Private Sub btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSAVE.Click

'            Dim strSQLwo As String = ""
'            Dim strSQLwoData As String = ""
'            Dim strSQLworkorder As String = ""
'            Dim strERROR As String = ""
'            Dim tmpWOID As Int32

'            cboCustomer.BackColor = Color.White

'            If Len(Trim(cboGroup.Text)) < 1 Then
'                MsgBox("Please select a group before continuing.", MsgBoxStyle.OKOnly, "ERROR")
'                Exit Sub
'            End If

'            If chkSkuLength.Checked = False Then
'                MsgBox("SKU length is a required field.", MsgBoxStyle.OKOnly, "ERROR")
'                Exit Sub
'            End If

'            If Len(Trim(cboSkuLength.Text)) < 1 Then
'                MsgBox("Please select a SKU length before continuing.", MsgBoxStyle.OKOnly, "ERROR")
'                Exit Sub
'            End If


'            If IsDBNull(txtQuantity.Text) = False Then
'                If IsDBNull(txtRAQuantity.Text) = False Then
'                    If Trim(txtQuantity.Text) <> Trim(txtRAQuantity.Text) Then
'                        Dim valDifference As String = InputBox("Quantity Discrepancy", "Data Needed")
'                        If Len(Trim(valDifference)) < 1 Then valDifference = "No Reason Given"
'                        strSQLworkorder += "WO_Discrepancy = '" & valDifference & "', "
'                    End If
'                End If
'            End If

'            '//Get Required Data
'            If cboManufacturer.SelectedValue > 0 Then strSQLwoData += "Manuf_ID = " & cboManufacturer.SelectedValue & ", "

'            If Len(Trim(cboModel.Text)) > 0 Then
'                Dim dtModel As DataTable = PSS.Data.Production.tmodel.GetDataTableByManufCELLNEW(cboManufacturer.SelectedValue, mProdID)
'                Dim r As DataRow
'                Dim xcount As Integer = 0
'                For xcount = 0 To dtModel.Rows.Count - 1
'                    r = dtModel.Rows(xcount)
'                    If Trim(r("Model_Desc")) = Trim(cboModel.Text) Then
'                        mModel = r("Model_ID")
'                        strSQLwoData += "Model_ID = " & mModel & ", "
'                        Exit For
'                    End If
'                Next
'            End If

'            '//This is for Motorola RL only
'            If cboLocation.SelectedValue = 2363 Then
'                '//Add SUG data for tworkorder
'                If Len(Trim(txtSKU.Text)) > 0 Then
'                    strSQLworkorder += "WO_Transceiver = '" & txtSKU.Text & "', "
'                End If
'            End If

'            If chkCarrier.Checked = True Then
'                If Len(Trim(cboCarrier.Text)) < 1 Then
'                    strSQLwoData += "plwodata_carrier = Null, "
'                Else
'                    Dim rCarrier As DataRow = PSS.Data.Production.lcodesdetail.GetvID(Trim(cboCarrier.Text), 1)
'                    If Len(Trim(rCarrier("Dcode_ID"))) = 0 Then
'                        strSQLwoData += "plwodata_carrier = NULL, "
'                    Else
'                        strSQLwoData += "plwodata_carrier =" & rCarrier("Dcode_ID") & ", "
'                    End If
'                End If
'                strSQLwo += "plwo_carrier = 1, "
'            Else
'                strSQLwo += "plwo_carrier = 0, "
'                strSQLwoData += "plwodata_carrier = '',"
'            End If



'            If chkShipTo.Checked = True Then
'                If Len(Trim(cboShipTo.Text)) < 1 Then
'                    strSQLwoData += "plwodata_shipto = NULL, "
'                Else
'                    strSQLworkorder += "shipto_id = " & cboCarrier.SelectedValue & ", "
'                    If Len(Trim(cboCarrier.SelectedValue)) = 0 Then
'                        strSQLwoData += "plwodata_shipto = NULL, "
'                    Else
'                        strSQLwoData += "plwodata_shipto ='" & cboShipTo.SelectedValue & "', "
'                    End If
'                End If
'                strSQLwo += "plwo_shipto = 1, "
'            Else
'                strSQLwo += "plwo_shipto = 0, "
'                strSQLwoData += "plwodata_shipto = '',"
'            End If


'            If chkQuantity.Checked = True Then
'                If Len(Trim(txtQuantity.Text)) < 1 Then
'                    strSQLwoData += "plwodata_quantity = 0, "
'                    strSQLworkorder += "WO_quantity = 0, "
'                Else
'                    If Len(Trim(txtQuantity.Text)) = 0 Then
'                        strSQLwoData += "plwodata_quantity = 0, "
'                        strSQLworkorder += "WO_quantity = 0, "
'                    Else
'                        strSQLwoData += "plwodata_quantity ='" & txtQuantity.Text & "', "
'                        strSQLworkorder += "WO_quantity ='" & txtQuantity.Text & "', "
'                    End If
'                End If
'                strSQLwo += "plwo_quantity = 1, "
'            Else
'                strSQLwo += "plwo_quantity = 0, "
'                strSQLwoData += "plwodata_quantity = '',"
'            End If


'            If chkPRL.Checked = True Then
'                If Len(Trim(txtPRL.Text)) < 1 Then
'                    strSQLwoData += "plwodata_prl = NULL, "
'                Else
'                    strSQLworkorder += "WO_PRL = '" & txtPRL.Text & "', "
'                    If Len(Trim(txtPRL.Text)) = 0 Then
'                        strSQLwoData += "plwodata_prl = NULL, "
'                    Else
'                        strSQLwoData += "plwodata_prl ='" & txtPRL.Text & "', "
'                    End If
'                End If
'                strSQLwo += "plwo_prl = 1, "
'            Else
'                strSQLwo += "plwo_prl = 0, "
'                strSQLwoData += "plwodata_prl = '',"
'            End If



'            If chkIP.Checked = True Then
'                If Len(Trim(txtIP.Text)) < 1 Then
'                    strSQLwoData += "plwodata_ip = NULL, "
'                Else
'                    If Len(Trim(txtIP.Text)) = 0 Then
'                        strSQLwoData += "plwodata_ip = NULL, "
'                    Else
'                        strSQLwoData += "plwodata_ip ='" & txtIP.Text & "', "
'                    End If
'                End If
'                strSQLworkorder += "WO_IP = '" & txtIP.Text & "', "
'                strSQLwo += "plwo_ip = 1, "
'            Else
'                strSQLwo += "plwo_ip = 0, "
'                strSQLwoData += "plwodata_ip = '',"
'            End If



'            If chkRAQuantity.Checked = True Then
'                If Len(Trim(txtRAQuantity.Text)) < 1 Then
'                    strSQLwoData += "plwodata_WOQuantity = 0, "
'                    strSQLworkorder += "WO_RAQnty = 0, "
'                Else
'                    strSQLwoData += "plwodata_WOQuantity ='" & txtRAQuantity.Text & "', "
'                    strSQLworkorder += "WO_RAQnty ='" & txtRAQuantity.Text & "', "
'                End If
'                strSQLwo += "plwo_WOQuantity = 1, "
'            Else
'                strSQLwo += "plwo_WOQuantity = 0, "
'                strSQLwoData += "plwodata_WOQuantity = '',"
'            End If



'            If chkSKU.Checked = True Then
'                If Len(Trim(txtSKU.Text)) < 1 Then
'                    strSQLwoData += "plwodata_sku = Null, "
'                Else
'                    strSQLwoData += "plwodata_sku ='" & txtSKU.Text & "', "

'                    '//INSERT DATA INTO TSKU
'                    Dim blnSKU As Boolean = PSS.Data.Production.tsku.GetRowBySKU(Trim(txtSKU.Text))
'                    If blnSKU = False Then '//Perform Insert
'                        Dim dtSKU As New PSS.Data.Production.tsku()
'                        Dim idSKU As Int32 = dtSKU.idTransaction("INSERT INTO tsku (Sku_Number, Cust_ID, Model_ID) VALUES ('" & txtSKU.Text & "', " & mCustID & ", " & mModel & ")")
'                    Else
'                        Dim rSku As DataRow = PSS.Data.Production.tsku.GetValSKU(Trim(txtSKU.Text))
'                        strSQLworkorder += "Sku_ID = " & rSku("Sku_ID") & ", "
'                    End If
'                End If
'                strSQLwo += "plwo_sku = 1, "
'            Else
'                strSQLwo += "plwo_sku = 0, "
'                strSQLwoData += "plwodata_sku = '',"
'            End If



'            If chkSkuLength.Checked = True Then
'                If Len(Trim(cboSkuLength.Text)) < 1 Then
'                    strSQLwoData += "plwodata_skulength = Null, "
'                Else
'                    strSQLwoData += "plwodata_skulength ='" & cboSkuLength.SelectedValue & "', "
'                End If
'                strSQLwo += "plwo_sku = 1, "
'            Else
'                strSQLwo += "plwo_sku = 0, "
'                strSQLwoData += "plwodata_skulength = 0,"
'            End If



'            If chkDefaultSKU.Checked = True Then
'                If Len(Trim(txtDefaultSKU.Text)) < 1 Then
'                    strSQLwoData += "plwodata_DefaultSku = Null, "
'                Else
'                    strSQLwoData += "plwodata_DefaultSku ='" & txtDefaultSKU.Text & "', "

'                    '//INSERT DATA INTO TSKU
'                    Dim blnSKU As Boolean = PSS.Data.Production.tsku.GetRowBySKU(Trim(txtDefaultSKU.Text))
'                    If blnSKU = False Then '//Perform Insert
'                        Dim dtSKU As New PSS.Data.Production.tsku()
'                        Dim idSKU As Int32 = dtSKU.idTransaction("INSERT INTO tsku (Sku_Number, Cust_ID, Model_ID) VALUES ('" & txtDefaultSKU.Text & "', " & mCustID & ", " & mModel & ")")
'                    Else
'                        Dim rSku As DataRow = PSS.Data.Production.tsku.GetValSKU(Trim(txtDefaultSKU.Text))
'                        strSQLworkorder += "Sku_ID = " & rSku("Sku_ID") & ", "
'                    End If
'                End If
'                strSQLwo += "plwo_DefaultSku = 1, "
'            Else
'                strSQLwo += "plwo_sku = 0, "
'                strSQLwoData += "plwodata_DefaultSku = '',"
'            End If

'            Try
'                If chkWarranty.Checked = True Then
'                    Dim vWrty As String
'                    If cboWarranty.Text = "No Warranty" Then
'                        vWrty = "E"
'                    ElseIf cboWarranty.Text = "90 Days" Then
'                        vWrty = "U"
'                    ElseIf cboWarranty.Text = "1 Year" Then
'                        vWrty = "J"
'                    Else
'                        vWrty = "E"
'                    End If

'                    If Len(Trim(cboWarranty.Text)) < 1 Then
'                        strSQLwoData += "plwodata_warranty = Null, "
'                    Else
'                        strSQLwoData += "plwodata_warranty ='" & vWrty & "', "
'                    End If
'                    strSQLworkorder += "WO_ExpCode = '" & vWrty & "', "
'                    strSQLwo += "plwo_warranty = 1, "
'                Else
'                    strSQLwo += "plwo_warranty = 0, "
'                    strSQLwoData += "plwodata_warranty = '',"
'                End If
'            Catch EX As Exception
'                strSQLwo += "plwo_warranty = 0, "
'                strSQLwoData += "plwodata_warranty = '',"
'            End Try



'            If chkDockDate.Checked = True Then
'                If Len(Trim(txtDockDate.Text)) < 1 Then
'                    strSQLwoData += "plwodata_dockdate = Null, "
'                Else
'                    strSQLwoData += "plwodata_dockdate ='" & txtDockDate.Text & "', "
'                End If
'                strSQLwo += "plwo_dockdate = 1, "
'            Else
'                strSQLwo += "plwo_dockdate = 0, "
'                strSQLwoData += "plwodata_dockdate = '',"
'            End If



'            If chkUPC.Checked = True Then
'                If Len(Trim(txtUPC.Text)) < 1 Then
'                    strSQLwoData += "plwodata_UPC = Null, "
'                Else
'                    strSQLwoData += "plwodata_UPC ='" & txtUPC.Text & "', "
'                End If
'                strSQLwo += "plwo_UPC = 1, "
'            Else
'                strSQLwo += "plwo_UPC = 0, "
'                strSQLwoData += "plwodata_UPC = '',"
'            End If

'            If chkPO.Checked = True Then
'                If Len(Trim(txtPOID.Text)) < 1 Then
'                    strSQLwoData += "PO_ID = Null, "
'                Else
'                    strSQLwoData += "PO_ID ='" & txtPOID.Text & "', "
'                    strSQLworkorder += "PO_ID = " & Trim(txtPOID.Text) & ", "  '//New CDH 2-3-2005
'                End If
'                strSQLwo += "plwo_PO = 1, "
'            Else
'                strSQLwo += "plwo_PO = 0, "
'                strSQLwoData += "plwodata_PO = '',"
'            End If


'            If chkDateCode.Checked = True Then
'                If Len(Trim(txtDateCode.Text)) < 1 Then
'                    strSQLwoData += "plwodata_datecode = Null, "
'                Else
'                    strSQLwoData += "plwodata_datecode ='" & txtDateCode.Text & "', "
'                End If
'                strSQLwo += "plwo_datecode = 1, "
'            Else
'                strSQLwo += "plwo_datecode = 0, "
'                strSQLwoData += "plwodata_datecode = '',"
'            End If


'            If chkPOP.Checked = True Then
'                If Len(Trim(txtPOP.Text)) < 1 Then
'                    strSQLwoData += "plwodata_POP = Null, "
'                Else
'                    strSQLwoData += "plwodata_POP ='" & txtPOP.Text & "', "
'                End If
'                strSQLwo += "plwo_POP = 1, "
'            Else
'                strSQLwo += "plwo_POP = 0, "
'                strSQLwoData += "plwodata_POP = Null,"
'            End If

'            If chkAPC.Checked = True Then
'                If Len(Trim(txtAPC.Text)) < 1 Then
'                    strSQLwoData += "plwodata_APC = Null, "
'                Else
'                    strSQLwoData += "plwodata_APC ='" & UCase(txtAPC.Text) & "', "
'                    strSQLworkorder += "WO_APC_OUT = '" & UCase(txtAPC.Text) & "', "
'                End If
'                strSQLwo += "plwo_APC = 1, "
'            Else
'                strSQLwo += "plwo_APC = 0, "
'                strSQLwoData += "plwodata_APC = '',"
'            End If

'            If chkIncIMEI.Checked = True Then
'                If Len(Trim(txtIncIMEI.Text)) < 1 Then
'                    strSQLwoData += "plwodata_incIMEI = Null, "
'                Else
'                    strSQLwoData += "plwodata_incIMEI ='" & txtIncIMEI.Text & "', "
'                End If
'                strSQLwo += "plwo_incIMEI = 1, "
'            Else
'                strSQLwo += "plwo_incIMEI = 0, "
'                strSQLwoData += "plwodata_incIMEI = '',"
'            End If



'            If chkCourierTrackIN.Checked = True Then
'                If Len(Trim(txtCourierTrackIN.Text)) < 1 Then
'                    strSQLwoData += "plwodata_CourierTrackIN = Null, "
'                Else
'                    strSQLwoData += "plwodata_CourierTrackIN ='" & txtCourierTrackIN.Text & "', "
'                End If
'                strSQLwo += "plwo_CourierTrackIN = 1, "
'            Else
'                strSQLwo += "plwo_CourierTrackIN = 0, "
'                strSQLwoData += "plwodata_CourierTrackIN = '',"
'            End If



'            If chkTransaction.Checked = True Then
'                If Len(Trim(cboTransaction.Text)) < 1 Then
'                    strSQLwoData += "plwodata_transaction = Null, "
'                Else
'                    strSQLwoData += "plwodata_transaction ='" & cboTransaction.Text & "', "
'                End If
'                strSQLwo += "plwo_transaction = 1, "
'            Else
'                strSQLwo += "plwo_transaction = 0, "
'                strSQLwoData += "plwodata_transaction = '',"
'            End If



'            If chkTransceiver.Checked = True Then
'                If Len(Trim(txtTransceiver.Text)) < 1 Then
'                    strSQLwoData += "plwodata_transceiver = Null, "
'                Else
'                    strSQLwoData += "plwodata_transceiver ='" & txtTransceiver.Text & "', "
'                End If
'                strSQLwo += "plwo_transceiver = 1, "
'            Else
'                strSQLwo += "plwo_transceiver = 0, "
'                strSQLwoData += "plwodata_transceiver = '',"
'            End If


'            If chkCarrierModel.Checked = True Then
'                If Len(Trim(txtCarrierModel.Text)) < 1 Then
'                    strERROR += "No Carrier Model Defined. " & vbCrLf
'                Else
'                    strSQLwo += "plwo_carriercode = 1, "
'                    strSQLwoData += "plwodata_carriercode ='" & txtCarrierModel.Text & "', "
'                End If
'            Else
'                If Len(Trim(txtCarrierModel.Text)) > 1 Then
'                    strERROR += "You have defined data for Carrier Model without selecting it." & vbCrLf
'                Else
'                    strSQLwo += "plwo_carriercode = 0, "
'                    strSQLwoData += "plwodata_carriercode = '',"
'                End If
'            End If

'            If chkMIN.Checked = True Then
'                If Len(Trim(txtMIN.Text)) < 1 Then
'                    strSQLwoData += "plwodata_MIN = Null, "
'                Else
'                    strSQLwoData += "plwodata_MIN ='" & txtMIN.Text & "', "
'                End If
'                strSQLwo += "plwo_MIN = 1, "
'            Else
'                strSQLwo += "plwo_MIN = 0, "
'                strSQLwoData += "plwodata_MIN = '',"
'            End If



'            If chkProduct.Checked = True Then
'                If Len(Trim(txtProduct.Text)) < 1 Then
'                    strSQLwoData += "plwodata_product = Null, "
'                Else
'                    strSQLwoData += "plwodata_product ='" & txtProduct.Text & "', "
'                End If
'                strSQLwo += "plwo_product = 1, "
'            Else
'                strSQLwo += "plwo_product = 0, "
'                strSQLwoData += "plwodata_product = '',"
'            End If



'            If chkComplaint.Checked = True Then
'                If Len(Trim(cboComplaint.Text)) < 1 Then
'                    strSQLwoData += "plwodata_complaint = Null, "
'                Else
'                    '//Get complaint ID
'                    Dim rComplaint As DataRow = PSS.Data.Production.lcodesdetail.GetvID(Trim(cboComplaint.Text), 5)
'                    strSQLwoData += "plwodata_complaint =" & rComplaint("Dcode_ID") & ", "
'                End If
'                strSQLwo += "plwo_complaint = 1, "
'            Else
'                strSQLwo += "plwo_complaint = 0, "
'                strSQLwoData += "plwodata_complaint = '',"
'            End If

'            If Len(Trim(txtComment.Text)) > 0 Then
'                strSQLwoData += "plwodata_comment = '" & Trim(txtComment.Text) & "', "
'            End If


'            If chkSVIN.Checked = True Then
'                If Len(Trim(txtSoftVerIN.Text)) < 1 Then
'                    strSQLwoData += "plwodata_SoftVerIN = Null, "
'                Else
'                    strSQLwoData += "plwodata_SoftVerIN ='" & txtSoftVerIN.Text & "', "
'                End If
'                strSQLwo += "plwo_SVIN = 1, "
'            Else
'                strSQLwo += "plwo_SVIN = 0, "
'                strSQLwoData += "plwodata_SoftVerIN = '',"
'            End If

'            'If Len(Trim(txtSoftVerIN.Text)) > 0 Then
'            'strSQLwoData += "plwodata_SoftVerIN = '" & Trim(txtSoftVerIN.Text) & "', "
'            'End If

'            If Len(Trim(txtSoftVerOUT.Text)) > 0 Then
'                strSQLwoData += "plwodata_SoftVerOUT = '" & Trim(txtSoftVerOUT.Text) & "', "
'            End If

'            If Len(Trim(txtFlexVer.Text)) > 0 Then
'                strSQLwoData += "plwodata_FlexVer = '" & Trim(txtFlexVer.Text) & "', "
'                strSQLworkorder += "WO_FlexVer = '" & Trim(txtFlexVer.Text) & "', "
'            End If

'            If chkAirtime.Checked = True Then
'                If Len(Trim(txtAirtime.Text)) < 1 Then
'                    strSQLwoData += "plwodata_AirTimeCode = Null, "
'                Else
'                    strSQLwoData += "plwodata_AirTimeCode ='" & txtAirtime.Text & "', "
'                End If
'                strSQLwo += "plwo_AirTime = 1, "
'            Else
'                strSQLwo += "plwo_AirTime = 0, "
'                strSQLwoData += "plwodata_AirTimeCode = '',"
'            End If

'            'If Len(Trim(txtAirtime.Text)) > 0 Then
'            'strSQLwoData += "plwodata_AirTimeCode = " & Trim(txtAirtime.Text) & ", "
'            'Else
'            'strSQLwoData += "plwodata_AirTimeCode = 0, "
'            'End If

'            If Len(Trim(txtSUG.Text)) > 0 Then
'                strSQLwoData += "plwodata_Sug = '" & Trim(txtSUG.Text) & "', "
'            Else
'                strSQLwoData += "plwodata_Sug = '', "
'            End If

'            If chkMemo.Checked = True Then
'                If Len(Trim(txtMemo.Text)) < 1 Then
'                    strSQLworkorder += "WO_Memo = Null, "
'                Else
'                    strSQLworkorder += "WO_Memo = '" & txtMemo.Text & "', "
'                End If
'            End If

'            If Len(Trim(txt20pct.Text)) > 0 Then
'                strSQLworkorder += "WO_Label20 = '" & txt20pct.Text & "', "
'            End If


'            If chkReturn.Checked = True Then
'                If Len(Trim(cboReturn.Text)) < 1 Then
'                    strSQLwoData += "plwodata_return = Null "
'                Else
'                    Dim rReturn As DataRow = PSS.Data.Production.lcodesdetail.GetvID(Trim(cboReturn.Text), 19)
'                    strSQLwoData += "plwodata_return =" & rReturn("Dcode_ID")
'                End If
'                strSQLwo += "plwo_return = 1 "
'            Else
'                strSQLwo += "plwo_return = 0 "
'                strSQLwoData += "plwodata_return = '' "
'            End If


'            If Len(Trim(strSQLworkorder)) > 0 Then
'                strSQLworkorder += "WO_Date = '" & PSS.Gui.Receiving.General.FormatDate(Now) & "', "
'                'strSQLworkorder += "Prod_ID = 2"
'                strSQLworkorder += "Prod_ID = " & mProdID
'            End If

'            Dim tmpplWO As Int32 = 0
'            Dim tmpplWOdata As Int32 = 0

'            Dim insplWO As New PSS.Data.Production.tpreloadwo()
'            Dim insplWOdata As New PSS.Data.Production.tpreloadwodata()

'            If Len(Trim(strERROR)) > 0 Then
'                MsgBox(strERROR, MsgBoxStyle.OKOnly, "ERROR")
'                btnSAVE.Focus()
'                Exit Sub
'            Else
'                '//Deletemine if this is an insert or update
'                Dim tWO As New PSS.Data.Production.tworkorder()
'                Dim dtWO As DataTable = tWO.GetCustWObyName(txtWorkOrderNumber.Text)
'                If dtWO.Rows.Count < 1 Then '//This is new - INSERT

'                    '//Perform insert of record
'                    '//Insert Workorder


'                    Dim vGroup As Integer = cboGroup.SelectedValue

'                    Dim insWO As New PSS.Data.Production.tworkorder()
'                    Dim itWO As Int32 = insWO.idTransaction("INSERT INTO tworkorder (WO_CustWO, Loc_ID, Group_ID, WO_SkuLength) VALUES ('" & Trim(txtWorkOrderNumber.Text) & "', " & cboLocation.SelectedValue & ", " & vGroup & ", " & cboSkuLength.SelectedValue & ")")
'                    tmpWOID = itWO

'                    Dim updWO As New PSS.Data.Production.Joins()
'                    Dim upWO As Boolean = updwo.OrderEntryUpdateDelete("UPDATE tworkorder SET " & strSQLworkorder & " WHERE wo_id = " & itWO)
'                    '//Insert tpreloadwo
'                    tmpplWO = insplWO.idTransaction("INSERT INTO tpreloadwo (Cust_ID, WO_ID) VALUES (" & mCustID & ", " & itWO & ")")
'                    tmpplWOdata = insplWOdata.idTransaction("INSERT INTO tpreloadwodata (Cust_ID, WO_ID) VALUES (" & mCustID & ", " & itWO & ")")
'                    '//Update tpreload
'                    If tmpplWO > 0 Then
'                        Dim blnUpdate As Boolean = updWO.OrderEntryUpdateDelete("UPDATE tpreloadwo SET " & strSQLwo & " WHERE plwo_id = " & tmpplWO)
'                        Dim blnUpdatedata As Boolean = updWO.OrderEntryUpdateDelete("UPDATE tpreloadwodata SET " & strSQLwoData & " WHERE plwodata_id = " & tmpplWOdata)
'                    End If
'                Else
'                    '//get the id from tworkorder and check the tpreloadwo table
'                    Dim rWO As DataRow = dtWO.Rows(0)
'                    tmpWOID = rWO("WO_ID")

'                    'Check preloadwo table for data
'                    Dim tplWO As New PSS.Data.Production.tpreloadwo()
'                    Dim tplWOdata As New PSS.Data.Production.tpreloadwodata()
'                    Dim dtplwo As DataTable = tplWO.GetWOpreload(mCustID, tmpWOID)
'                    Dim dtplwodata As DataTable = tplWOdata.GetWOpreloaddata(mCustID, tmpWOID)
'                    Dim rplwo, rplwodata As DataRow

'                    If dtplwodata.Rows.Count > 0 Then
'                        rplwodata = dtplwodata.Rows(0)
'                        tmpplWOdata = rplwodata("plwodata_id")
'                    End If

'                    If dtplwo.Rows.Count > 0 Then
'                        '//Get ID
'                        rplwo = dtplwo.Rows(0)
'                        tmpplWO = rplwo("plwo_id")
'                        '//Update tpreload
'                        If tmpplWO > 0 Then
'                            Dim updWO As New PSS.Data.Production.Joins()
'                            Dim blnUpdate As Boolean = updWO.OrderEntryUpdateDelete("UPDATE tpreloadwo SET " & strSQLwo & " WHERE plwo_id = " & tmpplWO)
'                            Dim blnUpdatedata As Boolean = updWO.OrderEntryUpdateDelete("UPDATE tpreloadwodata SET " & strSQLwoData & " WHERE plwodata_id = " & tmpplWOdata)
'                        End If
'                    End If
'                End If
'            End If


'            '//Print out report - START
'            Try
'                'Dim rptApp As New CRAXDRT.Application()
'                'Dim rpt As New CRAXDRT.Report()
'                Dim objRpt As ReportDocument

'                objRpt = New ReportDocument()

'                With objRpt
'                    .Load(PSS.Core.Global.ReportPath & "PreloadData.rpt")
'                    .RecordSelectionFormula = "{tpreloadwo.WO_ID} = " & tmpWOID
'                    .PrintToPrinter(1, True, 0, 0)
'                End With

'                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "PreloadData.rpt")
'                'rpt.RecordSelectionFormula = "{tpreloadwo.WO_ID} = " & tmpWOID
'                'rpt.PrintOut(False, 1)

'                'rpt = Nothing
'                'rptApp = Nothing

'            Catch exp As Exception
'                MsgBox(exp.ToString)
'                Cursor.Current = System.Windows.Forms.Cursors.Default
'            End Try
'            '//Print out report - END

'        End Sub


'        Private Sub PopulateCarrier()

'            Try
'                cboCarrier.Items.Clear()
'            Catch ex As Exception
'            End Try

'            Try
'                Dim xCount As Integer = 0
'                Dim tblJoins As New PSS.Data.Production.Joins()
'                Dim dtCarrier As DataTable
'                dtCarrier = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='carrier' and lcodesdetail.manuf_id=" & cboManufacturer.SelectedValue & " and lcodesdetail.prod_id=2 AND lcodesdetail.Dcode_Inactive = 0")
'                Me.cboCarrier.DataSource = dtCarrier
'                Me.cboCarrier.DisplayMember = dtCarrier.Columns("Dcode_Ldesc").ToString
'                Me.cboCarrier.SelectedValue = dtCarrier.Columns("Dcode_ID").ToString
'                cboCarrier.Text = ""
'            Catch ex As Exception
'            End Try

'        End Sub

'        Private Sub PopulateTransaction()

'            Try
'                cboTransaction.Items.Clear()
'            Catch ex As Exception
'            End Try

'            Try
'                Dim tblJoins As New PSS.Data.Production.Joins()
'                Dim dtTransaction As DataTable
'                dtTransaction = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='transaction' and lcodesdetail.manuf_id=" & cboManufacturer.SelectedValue & " and lcodesdetail.prod_id=2 AND lcodesdetail.Dcode_Inactive = 0")
'                cboTransaction.DataSource = dtTransaction
'                cboTransaction.DisplayMember = dtTransaction.Columns("Dcode_LDesc").ToString
'                cboTransaction.SelectedValue = dtTransaction.Columns("Dcode_ID").ToString
'                cboTransaction.Text = ""
'            Catch ex As Exception
'            End Try

'        End Sub

'        Private Sub cboManufacturer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedValueChanged
'            If mOnLoad = 0 Then
'                populateModels()
'                populateComplaints()
'                PopulateCarrier()
'                PopulateTransaction()
'            End If
'        End Sub

'        Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
'        End Sub

'        Private Sub cboCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Leave

'            If mOnLoad = 0 Then '//This section is from SelectedValueChanged
'                getCustomerID()
'                PopulateLocations(mCustID)
'                populateReturn()
'                loadCheckBoxesCustomer()
'            End If  '//End of SelectionValueChanged section

'            If mOnLoad = 0 Then
'                If Len(Trim(cboCustomer.Text)) > 0 Then
'                    cboCustomer.Enabled = False
'                End If
'            End If
'        End Sub


'        Private Function verifyPSSI_InternalSKU() As Boolean

'            '//Verify prefix is the same
'            Dim intSku As Integer = InStr(txtSKU.Text, "-")
'            Dim intDSku As Integer = InStr(txtDefaultSKU.Text, "-")
'            Dim tSKU, tDSKU As String
'            tSKU = UCase(Trim(Mid$(txtSKU.Text, intSku + 1, 10)))
'            tDSKU = UCase(Trim(Mid$(txtDefaultSKU.Text, intDSku + 1, 10)))
'            If tSKU <> tDSKU Then
'                MsgBox("The SKU and Default SKU must have the same prefix structure. Please correct and try again.", MsgBoxStyle.Exclamation, "ERROR")
'                Return False
'            End If

'            '//Verify first if U or N
'            If Len(Trim(txtSKU.Text)) > 0 Then
'                Dim mValue As String = UCase(Trim(txtSKU.Text))
'                '//Verify character after - is U or N
'                Dim intDash As Integer = InStr(mValue, "-")
'                Dim mCheckChar As String
'                If intDash > 0 Then
'                    mCheckChar = Trim(Mid$(mValue, intDash + 1, 10))
'                    If Len(Trim(mCheckChar)) = 1 Then
'                        '//Verify the value
'                        If mCheckChar = "U" Or mCheckChar = "N" Then
'                            Return True
'                        Else
'                            Return False
'                        End If
'                    Else
'                        Return False
'                    End If
'                Else
'                    Return False
'                End If



'            Else
'                Return False
'            End If
'        End Function



'        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

'        End Sub

'        Private Sub txtWorkOrderNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWorkOrderNumber.TextChanged

'        End Sub
'    End Class

'End Namespace
