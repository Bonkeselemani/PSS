'Imports CrystalDecisions.CrystalReports.Engine
'Imports PSS.Core
'Imports PSS.Data

'Namespace Gui.Receiving

'    Public Class frmMOTORL_Receiving
'        Inherits System.Windows.Forms.Form


'#Region " Windows Form Designer generated code "

'        Public Sub New()
'            MyBase.New()

'            'Dim frmSelRecType As New frmSelectRecType()
'            'frmSelRecType.ShowDialog()
'            Try
'                '    DeviceType = frmSelRecType.srcDevice.ToString()
'                '    RecType = frmSelRecType.srcRecType.ToString
'                '    frmSelRecType.Dispose()
'                DeviceType = 2
'                RecType = 1
'            Catch
'            End Try

'            If DeviceType = "2" And RecType = "4" Then
'                'WebUser = frmSelRecType.srcWebInput.ToString
'                'MsgBox("web user= " & WebUser)
'                'If WebUser < 1 Then
'                'frmSelRecType.Dispose()
'                'Me.Dispose()
'                'End If
'            End If

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call

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
'        Friend WithEvents lblCustomerID As System.Windows.Forms.Label
'        Friend WithEvents lblWorkOrderMemo As System.Windows.Forms.Label
'        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
'        Friend WithEvents grpWorkOrder As System.Windows.Forms.GroupBox
'        Friend WithEvents txtMemberNum As System.Windows.Forms.TextBox
'        Friend WithEvents lblMemberNum As System.Windows.Forms.Label
'        Friend WithEvents txtClaimNum As System.Windows.Forms.TextBox
'        Friend WithEvents lblClaimNum As System.Windows.Forms.Label
'        Friend WithEvents lblCustomWorkOrder As System.Windows.Forms.Label
'        Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
'        Friend WithEvents lblWorkOrder As System.Windows.Forms.Label
'        Friend WithEvents grpDevice As System.Windows.Forms.GroupBox
'        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
'        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
'        Friend WithEvents lblCustomerReason As System.Windows.Forms.Label
'        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
'        Friend WithEvents lblModel As System.Windows.Forms.Label
'        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
'        Friend WithEvents lblCustomer As System.Windows.Forms.Label
'        Friend WithEvents lblCustomerVAL As System.Windows.Forms.Label
'        Friend WithEvents lblAddress As System.Windows.Forms.Label
'        Friend WithEvents lblAddressVAL As System.Windows.Forms.Label
'        Friend WithEvents txtWorkOrderMemo As System.Windows.Forms.TextBox
'        Friend WithEvents lblTray As System.Windows.Forms.Label
'        Friend WithEvents lblTrayVAL As System.Windows.Forms.Label
'        Friend WithEvents lblDate As System.Windows.Forms.Label
'        Friend WithEvents lblDateVAL As System.Windows.Forms.Label
'        Friend WithEvents lblCount As System.Windows.Forms.Label
'        Friend WithEvents lblCountVAL As System.Windows.Forms.Label
'        Friend WithEvents lblCustomerNameString As System.Windows.Forms.Label
'        Friend WithEvents lblManufacturerNameString As System.Windows.Forms.Label
'        Friend WithEvents lblModelNameString As System.Windows.Forms.Label
'        Friend WithEvents chkDBR As System.Windows.Forms.CheckBox
'        Friend WithEvents grpCreditCard As System.Windows.Forms.GroupBox
'        Friend WithEvents Label3 As System.Windows.Forms.Label
'        Friend WithEvents cboCCType As System.Windows.Forms.ComboBox
'        Friend WithEvents txtCCNumber As System.Windows.Forms.TextBox
'        Friend WithEvents txtExpDate As System.Windows.Forms.TextBox
'        Friend WithEvents lblCustomerReasonNameString As System.Windows.Forms.Label
'        Friend WithEvents lblAddressID As System.Windows.Forms.Label
'        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
'        Friend WithEvents lblCountVAL1 As System.Windows.Forms.Label
'        Friend WithEvents lblCount1 As System.Windows.Forms.Label
'        Friend WithEvents Option1 As System.Windows.Forms.RadioButton
'        Friend WithEvents grpMemo As System.Windows.Forms.GroupBox
'        Friend WithEvents txtMemo As System.Windows.Forms.TextBox
'        Friend WithEvents lblTerms As System.Windows.Forms.Label
'        Friend WithEvents btnPrint As System.Windows.Forms.Button
'        Friend WithEvents cboAddress As System.Windows.Forms.ComboBox
'        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
'        Friend WithEvents cboCustID As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboManufID As PSS.Gui.Controls.ComboBox
'        Friend WithEvents cboModID As PSS.Gui.Controls.ComboBox
'        Friend WithEvents btnNewLocation As System.Windows.Forms.Button
'        Friend WithEvents btnCust As System.Windows.Forms.Button
'        Friend WithEvents btnReprint As System.Windows.Forms.Button
'        Friend WithEvents Button1 As System.Windows.Forms.Button
'        Friend WithEvents Label1 As System.Windows.Forms.Label
'        Public Shared WithEvents txtCell As System.Windows.Forms.TextBox
'        Friend WithEvents btnStaging As System.Windows.Forms.Button
'        Friend WithEvents cboCR As System.Windows.Forms.ComboBox
'        Friend WithEvents cboCustomerReason As PSS.Gui.Controls.ComboBox
'        Friend WithEvents lblMotorola As System.Windows.Forms.Label
'        Friend WithEvents Label2 As System.Windows.Forms.Label
'        Friend WithEvents Label4 As System.Windows.Forms.Label
'        Friend WithEvents Label5 As System.Windows.Forms.Label
'        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
'        Friend WithEvents txtPRL As System.Windows.Forms.TextBox
'        Friend WithEvents txtIP As System.Windows.Forms.TextBox
'        Friend WithEvents lblSKU As System.Windows.Forms.Label
'        Friend WithEvents txtSKU As System.Windows.Forms.TextBox
'        Friend WithEvents Label7 As System.Windows.Forms.Label
'        Friend WithEvents txtRAQty As System.Windows.Forms.TextBox
'        Friend WithEvents lblWrty As System.Windows.Forms.Label
'        Friend WithEvents cboWrty As PSS.Gui.Controls.ComboBox
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMOTORL_Receiving))
'            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
'            Me.lblCustomerID = New System.Windows.Forms.Label()
'            Me.lblWorkOrderMemo = New System.Windows.Forms.Label()
'            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
'            Me.grpWorkOrder = New System.Windows.Forms.GroupBox()
'            Me.txtRAQty = New System.Windows.Forms.TextBox()
'            Me.Label7 = New System.Windows.Forms.Label()
'            Me.txtIP = New System.Windows.Forms.TextBox()
'            Me.txtPRL = New System.Windows.Forms.TextBox()
'            Me.txtQuantity = New System.Windows.Forms.TextBox()
'            Me.Label5 = New System.Windows.Forms.Label()
'            Me.Label4 = New System.Windows.Forms.Label()
'            Me.Label2 = New System.Windows.Forms.Label()
'            Me.txtWorkOrder = New System.Windows.Forms.TextBox()
'            Me.lblWorkOrder = New System.Windows.Forms.Label()
'            Me.txtMemberNum = New System.Windows.Forms.TextBox()
'            Me.lblMemberNum = New System.Windows.Forms.Label()
'            Me.txtClaimNum = New System.Windows.Forms.TextBox()
'            Me.lblClaimNum = New System.Windows.Forms.Label()
'            Me.chkDBR = New System.Windows.Forms.CheckBox()
'            Me.lblCustomWorkOrder = New System.Windows.Forms.Label()
'            Me.grpDevice = New System.Windows.Forms.GroupBox()
'            Me.lblSKU = New System.Windows.Forms.Label()
'            Me.btnCust = New System.Windows.Forms.Button()
'            Me.btnNewLocation = New System.Windows.Forms.Button()
'            Me.cboModID = New PSS.Gui.Controls.ComboBox()
'            Me.cboManufID = New PSS.Gui.Controls.ComboBox()
'            Me.btnPrint = New System.Windows.Forms.Button()
'            Me.lblModelNameString = New System.Windows.Forms.Label()
'            Me.lblManufacturerNameString = New System.Windows.Forms.Label()
'            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
'            Me.lblDeviceSN = New System.Windows.Forms.Label()
'            Me.cboModel = New System.Windows.Forms.ComboBox()
'            Me.lblModel = New System.Windows.Forms.Label()
'            Me.lblManufacturer = New System.Windows.Forms.Label()
'            Me.txtSKU = New System.Windows.Forms.TextBox()
'            Me.btnReprint = New System.Windows.Forms.Button()
'            Me.Button1 = New System.Windows.Forms.Button()
'            Me.Label1 = New System.Windows.Forms.Label()
'            Me.cboCustomerReason = New PSS.Gui.Controls.ComboBox()
'            Me.lblCustomerReasonNameString = New System.Windows.Forms.Label()
'            Me.cboCR = New System.Windows.Forms.ComboBox()
'            Me.lblCustomerReason = New System.Windows.Forms.Label()
'            Me.lblCustomer = New System.Windows.Forms.Label()
'            Me.lblCustomerVAL = New System.Windows.Forms.Label()
'            Me.lblAddress = New System.Windows.Forms.Label()
'            Me.lblAddressVAL = New System.Windows.Forms.Label()
'            Me.txtWorkOrderMemo = New System.Windows.Forms.TextBox()
'            Me.lblTray = New System.Windows.Forms.Label()
'            Me.lblTrayVAL = New System.Windows.Forms.Label()
'            Me.lblDate = New System.Windows.Forms.Label()
'            Me.lblDateVAL = New System.Windows.Forms.Label()
'            Me.lblCount = New System.Windows.Forms.Label()
'            Me.lblCountVAL = New System.Windows.Forms.Label()
'            Me.Option1 = New System.Windows.Forms.RadioButton()
'            Me.lblCustomerNameString = New System.Windows.Forms.Label()
'            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
'            Me.grpCreditCard = New System.Windows.Forms.GroupBox()
'            Me.txtExpDate = New System.Windows.Forms.TextBox()
'            Me.txtCCNumber = New System.Windows.Forms.TextBox()
'            Me.cboCCType = New System.Windows.Forms.ComboBox()
'            Me.Label3 = New System.Windows.Forms.Label()
'            Me.lblAddressID = New System.Windows.Forms.Label()
'            Me.lblCountVAL1 = New System.Windows.Forms.Label()
'            Me.lblCount1 = New System.Windows.Forms.Label()
'            Me.grpMemo = New System.Windows.Forms.GroupBox()
'            Me.txtMemo = New System.Windows.Forms.TextBox()
'            Me.lblTerms = New System.Windows.Forms.Label()
'            Me.cboAddress = New System.Windows.Forms.ComboBox()
'            Me.txtLocation = New System.Windows.Forms.TextBox()
'            Me.cboCustID = New PSS.Gui.Controls.ComboBox()
'            Me.btnStaging = New System.Windows.Forms.Button()
'            Me.lblMotorola = New System.Windows.Forms.Label()
'            Me.lblWrty = New System.Windows.Forms.Label()
'            Me.cboWrty = New PSS.Gui.Controls.ComboBox()
'            Me.grpWorkOrder.SuspendLayout()
'            Me.grpDevice.SuspendLayout()
'            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
'            Me.grpCreditCard.SuspendLayout()
'            Me.grpMemo.SuspendLayout()
'            Me.SuspendLayout()
'            '
'            'lblCustomerID
'            '
'            Me.lblCustomerID.Location = New System.Drawing.Point(0, 8)
'            Me.lblCustomerID.Name = "lblCustomerID"
'            Me.lblCustomerID.Size = New System.Drawing.Size(80, 16)
'            Me.lblCustomerID.TabIndex = 0
'            Me.lblCustomerID.Text = "Customer ID:"
'            '
'            'lblWorkOrderMemo
'            '
'            Me.lblWorkOrderMemo.Location = New System.Drawing.Point(88, 80)
'            Me.lblWorkOrderMemo.Name = "lblWorkOrderMemo"
'            Me.lblWorkOrderMemo.Size = New System.Drawing.Size(104, 16)
'            Me.lblWorkOrderMemo.TabIndex = 2
'            Me.lblWorkOrderMemo.Text = "WorkOrder Memo"
'            Me.lblWorkOrderMemo.TextAlign = System.Drawing.ContentAlignment.BottomRight
'            '
'            'PictureBox1
'            '
'            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
'            Me.PictureBox1.Location = New System.Drawing.Point(200, 80)
'            Me.PictureBox1.Name = "PictureBox1"
'            Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
'            Me.PictureBox1.TabIndex = 3
'            Me.PictureBox1.TabStop = False
'            '
'            'grpWorkOrder
'            '
'            Me.grpWorkOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWrty, Me.txtRAQty, Me.Label7, Me.txtIP, Me.txtPRL, Me.txtQuantity, Me.Label5, Me.Label4, Me.Label2, Me.txtWorkOrder, Me.lblWorkOrder, Me.cboWrty})
'            Me.grpWorkOrder.Location = New System.Drawing.Point(24, 96)
'            Me.grpWorkOrder.Name = "grpWorkOrder"
'            Me.grpWorkOrder.Size = New System.Drawing.Size(184, 168)
'            Me.grpWorkOrder.TabIndex = 13
'            Me.grpWorkOrder.TabStop = False
'            '
'            'txtRAQty
'            '
'            Me.txtRAQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtRAQty.Location = New System.Drawing.Point(56, 120)
'            Me.txtRAQty.Name = "txtRAQty"
'            Me.txtRAQty.Size = New System.Drawing.Size(112, 21)
'            Me.txtRAQty.TabIndex = 7
'            Me.txtRAQty.Text = ""
'            Me.txtRAQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'            '
'            'Label7
'            '
'            Me.Label7.Location = New System.Drawing.Point(8, 120)
'            Me.Label7.Name = "Label7"
'            Me.Label7.Size = New System.Drawing.Size(48, 16)
'            Me.Label7.TabIndex = 18
'            Me.Label7.Text = "RA QTY"
'            '
'            'txtIP
'            '
'            Me.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtIP.Location = New System.Drawing.Point(56, 96)
'            Me.txtIP.Name = "txtIP"
'            Me.txtIP.Size = New System.Drawing.Size(112, 21)
'            Me.txtIP.TabIndex = 6
'            Me.txtIP.Text = ""
'            Me.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'            '
'            'txtPRL
'            '
'            Me.txtPRL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtPRL.Location = New System.Drawing.Point(56, 72)
'            Me.txtPRL.Name = "txtPRL"
'            Me.txtPRL.Size = New System.Drawing.Size(112, 21)
'            Me.txtPRL.TabIndex = 5
'            Me.txtPRL.Text = ""
'            Me.txtPRL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'            '
'            'txtQuantity
'            '
'            Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtQuantity.Location = New System.Drawing.Point(56, 48)
'            Me.txtQuantity.Name = "txtQuantity"
'            Me.txtQuantity.Size = New System.Drawing.Size(112, 21)
'            Me.txtQuantity.TabIndex = 4
'            Me.txtQuantity.Text = ""
'            Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'            '
'            'Label5
'            '
'            Me.Label5.Location = New System.Drawing.Point(24, 96)
'            Me.Label5.Name = "Label5"
'            Me.Label5.Size = New System.Drawing.Size(32, 16)
'            Me.Label5.TabIndex = 16
'            Me.Label5.Text = "IP"
'            '
'            'Label4
'            '
'            Me.Label4.Location = New System.Drawing.Point(24, 72)
'            Me.Label4.Name = "Label4"
'            Me.Label4.Size = New System.Drawing.Size(32, 16)
'            Me.Label4.TabIndex = 15
'            Me.Label4.Text = "PRL"
'            '
'            'Label2
'            '
'            Me.Label2.Location = New System.Drawing.Point(24, 48)
'            Me.Label2.Name = "Label2"
'            Me.Label2.Size = New System.Drawing.Size(32, 16)
'            Me.Label2.TabIndex = 14
'            Me.Label2.Text = "QTY"
'            '
'            'txtWorkOrder
'            '
'            Me.txtWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtWorkOrder.Location = New System.Drawing.Point(16, 24)
'            Me.txtWorkOrder.Name = "txtWorkOrder"
'            Me.txtWorkOrder.Size = New System.Drawing.Size(152, 21)
'            Me.txtWorkOrder.TabIndex = 3
'            Me.txtWorkOrder.Text = ""
'            Me.txtWorkOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'            '
'            'lblWorkOrder
'            '
'            Me.lblWorkOrder.Location = New System.Drawing.Point(16, 8)
'            Me.lblWorkOrder.Name = "lblWorkOrder"
'            Me.lblWorkOrder.Size = New System.Drawing.Size(80, 16)
'            Me.lblWorkOrder.TabIndex = 13
'            Me.lblWorkOrder.Text = "Cust Ref #"
'            '
'            'txtMemberNum
'            '
'            Me.txtMemberNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtMemberNum.Location = New System.Drawing.Point(8, 432)
'            Me.txtMemberNum.Name = "txtMemberNum"
'            Me.txtMemberNum.Size = New System.Drawing.Size(8, 21)
'            Me.txtMemberNum.TabIndex = 6
'            Me.txtMemberNum.Text = ""
'            '
'            'lblMemberNum
'            '
'            Me.lblMemberNum.Location = New System.Drawing.Point(8, 416)
'            Me.lblMemberNum.Name = "lblMemberNum"
'            Me.lblMemberNum.Size = New System.Drawing.Size(8, 16)
'            Me.lblMemberNum.TabIndex = 20
'            Me.lblMemberNum.Text = "Member #"
'            '
'            'txtClaimNum
'            '
'            Me.txtClaimNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtClaimNum.Location = New System.Drawing.Point(8, 392)
'            Me.txtClaimNum.Name = "txtClaimNum"
'            Me.txtClaimNum.Size = New System.Drawing.Size(8, 21)
'            Me.txtClaimNum.TabIndex = 5
'            Me.txtClaimNum.Text = ""
'            '
'            'lblClaimNum
'            '
'            Me.lblClaimNum.Location = New System.Drawing.Point(8, 376)
'            Me.lblClaimNum.Name = "lblClaimNum"
'            Me.lblClaimNum.Size = New System.Drawing.Size(8, 16)
'            Me.lblClaimNum.TabIndex = 18
'            Me.lblClaimNum.Text = "Claim #:"
'            '
'            'chkDBR
'            '
'            Me.chkDBR.Location = New System.Drawing.Point(8, 360)
'            Me.chkDBR.Name = "chkDBR"
'            Me.chkDBR.Size = New System.Drawing.Size(8, 16)
'            Me.chkDBR.TabIndex = 4
'            Me.chkDBR.Text = "DBR"
'            Me.chkDBR.Visible = False
'            '
'            'lblCustomWorkOrder
'            '
'            Me.lblCustomWorkOrder.Location = New System.Drawing.Point(8, 344)
'            Me.lblCustomWorkOrder.Name = "lblCustomWorkOrder"
'            Me.lblCustomWorkOrder.Size = New System.Drawing.Size(8, 8)
'            Me.lblCustomWorkOrder.TabIndex = 17
'            Me.lblCustomWorkOrder.Text = "Custom WorkOrder"
'            Me.lblCustomWorkOrder.Visible = False
'            '
'            'grpDevice
'            '
'            Me.grpDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSKU, Me.btnCust, Me.btnNewLocation, Me.cboModID, Me.cboManufID, Me.btnPrint, Me.lblModelNameString, Me.lblManufacturerNameString, Me.txtDeviceSN, Me.lblDeviceSN, Me.cboModel, Me.lblModel, Me.lblManufacturer, Me.txtSKU})
'            Me.grpDevice.Location = New System.Drawing.Point(24, 264)
'            Me.grpDevice.Name = "grpDevice"
'            Me.grpDevice.Size = New System.Drawing.Size(184, 240)
'            Me.grpDevice.TabIndex = 22
'            Me.grpDevice.TabStop = False
'            '
'            'lblSKU
'            '
'            Me.lblSKU.Location = New System.Drawing.Point(8, 96)
'            Me.lblSKU.Name = "lblSKU"
'            Me.lblSKU.Size = New System.Drawing.Size(100, 16)
'            Me.lblSKU.TabIndex = 52
'            Me.lblSKU.Text = "SKU"
'            '
'            'btnCust
'            '
'            Me.btnCust.Location = New System.Drawing.Point(96, 216)
'            Me.btnCust.Name = "btnCust"
'            Me.btnCust.Size = New System.Drawing.Size(80, 16)
'            Me.btnCust.TabIndex = 49
'            Me.btnCust.Text = "New C&ust"
'            '
'            'btnNewLocation
'            '
'            Me.btnNewLocation.Location = New System.Drawing.Point(8, 216)
'            Me.btnNewLocation.Name = "btnNewLocation"
'            Me.btnNewLocation.Size = New System.Drawing.Size(80, 16)
'            Me.btnNewLocation.TabIndex = 48
'            Me.btnNewLocation.Text = "New &Loc"
'            '
'            'cboModID
'            '
'            Me.cboModID.AutoComplete = True
'            Me.cboModID.Location = New System.Drawing.Point(8, 72)
'            Me.cboModID.Name = "cboModID"
'            Me.cboModID.Size = New System.Drawing.Size(168, 21)
'            Me.cboModID.TabIndex = 10
'            '
'            'cboManufID
'            '
'            Me.cboManufID.AutoComplete = True
'            Me.cboManufID.Location = New System.Drawing.Point(8, 32)
'            Me.cboManufID.Name = "cboManufID"
'            Me.cboManufID.Size = New System.Drawing.Size(168, 21)
'            Me.cboManufID.TabIndex = 9
'            '
'            'btnPrint
'            '
'            Me.btnPrint.Location = New System.Drawing.Point(8, 184)
'            Me.btnPrint.Name = "btnPrint"
'            Me.btnPrint.Size = New System.Drawing.Size(168, 24)
'            Me.btnPrint.TabIndex = 47
'            Me.btnPrint.Text = "Prin&t"
'            '
'            'lblModelNameString
'            '
'            Me.lblModelNameString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblModelNameString.Location = New System.Drawing.Point(136, 56)
'            Me.lblModelNameString.Name = "lblModelNameString"
'            Me.lblModelNameString.Size = New System.Drawing.Size(40, 16)
'            Me.lblModelNameString.TabIndex = 38
'            Me.lblModelNameString.Visible = False
'            '
'            'lblManufacturerNameString
'            '
'            Me.lblManufacturerNameString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblManufacturerNameString.Location = New System.Drawing.Point(136, 16)
'            Me.lblManufacturerNameString.Name = "lblManufacturerNameString"
'            Me.lblManufacturerNameString.Size = New System.Drawing.Size(40, 16)
'            Me.lblManufacturerNameString.TabIndex = 37
'            Me.lblManufacturerNameString.Visible = False
'            '
'            'txtDeviceSN
'            '
'            Me.txtDeviceSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtDeviceSN.Location = New System.Drawing.Point(8, 152)
'            Me.txtDeviceSN.Name = "txtDeviceSN"
'            Me.txtDeviceSN.Size = New System.Drawing.Size(168, 21)
'            Me.txtDeviceSN.TabIndex = 12
'            Me.txtDeviceSN.Text = ""
'            '
'            'lblDeviceSN
'            '
'            Me.lblDeviceSN.Location = New System.Drawing.Point(8, 136)
'            Me.lblDeviceSN.Name = "lblDeviceSN"
'            Me.lblDeviceSN.Size = New System.Drawing.Size(100, 16)
'            Me.lblDeviceSN.TabIndex = 28
'            Me.lblDeviceSN.Text = "Device SN"
'            '
'            'cboModel
'            '
'            Me.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'            Me.cboModel.Location = New System.Drawing.Point(8, 72)
'            Me.cboModel.Name = "cboModel"
'            Me.cboModel.Size = New System.Drawing.Size(144, 21)
'            Me.cboModel.TabIndex = 8
'            '
'            'lblModel
'            '
'            Me.lblModel.Location = New System.Drawing.Point(8, 56)
'            Me.lblModel.Name = "lblModel"
'            Me.lblModel.Size = New System.Drawing.Size(100, 16)
'            Me.lblModel.TabIndex = 24
'            Me.lblModel.Text = "Model"
'            '
'            'lblManufacturer
'            '
'            Me.lblManufacturer.Location = New System.Drawing.Point(8, 16)
'            Me.lblManufacturer.Name = "lblManufacturer"
'            Me.lblManufacturer.Size = New System.Drawing.Size(100, 16)
'            Me.lblManufacturer.TabIndex = 22
'            Me.lblManufacturer.Text = "Manufacturer"
'            '
'            'txtSKU
'            '
'            Me.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtSKU.Location = New System.Drawing.Point(8, 112)
'            Me.txtSKU.Name = "txtSKU"
'            Me.txtSKU.Size = New System.Drawing.Size(168, 21)
'            Me.txtSKU.TabIndex = 11
'            Me.txtSKU.Text = ""
'            Me.txtSKU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'            '
'            'btnReprint
'            '
'            Me.btnReprint.Location = New System.Drawing.Point(232, 464)
'            Me.btnReprint.Name = "btnReprint"
'            Me.btnReprint.Size = New System.Drawing.Size(72, 16)
'            Me.btnReprint.TabIndex = 50
'            Me.btnReprint.Text = "WKSHEET"
'            '
'            'Button1
'            '
'            Me.Button1.Location = New System.Drawing.Point(312, 464)
'            Me.Button1.Name = "Button1"
'            Me.Button1.Size = New System.Drawing.Size(80, 16)
'            Me.Button1.TabIndex = 51
'            Me.Button1.Text = "CHGE DEVC"
'            '
'            'Label1
'            '
'            Me.Label1.BackColor = System.Drawing.Color.SteelBlue
'            Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'            Me.Label1.Location = New System.Drawing.Point(224, 456)
'            Me.Label1.Name = "Label1"
'            Me.Label1.Size = New System.Drawing.Size(176, 32)
'            Me.Label1.TabIndex = 47
'            '
'            'cboCustomerReason
'            '
'            Me.cboCustomerReason.AutoComplete = True
'            Me.cboCustomerReason.Location = New System.Drawing.Point(0, 480)
'            Me.cboCustomerReason.Name = "cboCustomerReason"
'            Me.cboCustomerReason.Size = New System.Drawing.Size(32, 21)
'            Me.cboCustomerReason.TabIndex = 52
'            Me.cboCustomerReason.Visible = False
'            '
'            'lblCustomerReasonNameString
'            '
'            Me.lblCustomerReasonNameString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblCustomerReasonNameString.Location = New System.Drawing.Point(64, 480)
'            Me.lblCustomerReasonNameString.Name = "lblCustomerReasonNameString"
'            Me.lblCustomerReasonNameString.Size = New System.Drawing.Size(40, 16)
'            Me.lblCustomerReasonNameString.TabIndex = 39
'            Me.lblCustomerReasonNameString.Visible = False
'            '
'            'cboCR
'            '
'            Me.cboCR.Location = New System.Drawing.Point(32, 480)
'            Me.cboCR.Name = "cboCR"
'            Me.cboCR.Size = New System.Drawing.Size(40, 21)
'            Me.cboCR.TabIndex = 9
'            Me.cboCR.Visible = False
'            '
'            'lblCustomerReason
'            '
'            Me.lblCustomerReason.Location = New System.Drawing.Point(0, 472)
'            Me.lblCustomerReason.Name = "lblCustomerReason"
'            Me.lblCustomerReason.Size = New System.Drawing.Size(8, 16)
'            Me.lblCustomerReason.TabIndex = 26
'            Me.lblCustomerReason.Text = "Customer Reason"
'            Me.lblCustomerReason.Visible = False
'            '
'            'lblCustomer
'            '
'            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCustomer.Location = New System.Drawing.Point(248, 8)
'            Me.lblCustomer.Name = "lblCustomer"
'            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
'            Me.lblCustomer.TabIndex = 23
'            Me.lblCustomer.Text = "Customer"
'            '
'            'lblCustomerVAL
'            '
'            Me.lblCustomerVAL.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblCustomerVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblCustomerVAL.Location = New System.Drawing.Point(248, 24)
'            Me.lblCustomerVAL.Name = "lblCustomerVAL"
'            Me.lblCustomerVAL.Size = New System.Drawing.Size(210, 23)
'            Me.lblCustomerVAL.TabIndex = 24
'            '
'            'lblAddress
'            '
'            Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblAddress.Location = New System.Drawing.Point(32, 48)
'            Me.lblAddress.Name = "lblAddress"
'            Me.lblAddress.Size = New System.Drawing.Size(48, 16)
'            Me.lblAddress.TabIndex = 25
'            Me.lblAddress.Text = "Address"
'            '
'            'lblAddressVAL
'            '
'            Me.lblAddressVAL.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblAddressVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblAddressVAL.Location = New System.Drawing.Point(80, 48)
'            Me.lblAddressVAL.Name = "lblAddressVAL"
'            Me.lblAddressVAL.Size = New System.Drawing.Size(522, 24)
'            Me.lblAddressVAL.TabIndex = 26
'            '
'            'txtWorkOrderMemo
'            '
'            Me.txtWorkOrderMemo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.txtWorkOrderMemo.BackColor = System.Drawing.SystemColors.Window
'            Me.txtWorkOrderMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtWorkOrderMemo.Location = New System.Drawing.Point(224, 80)
'            Me.txtWorkOrderMemo.Name = "txtWorkOrderMemo"
'            Me.txtWorkOrderMemo.Size = New System.Drawing.Size(304, 21)
'            Me.txtWorkOrderMemo.TabIndex = 2
'            Me.txtWorkOrderMemo.TabStop = False
'            Me.txtWorkOrderMemo.Text = "Repair"
'            '
'            'lblTray
'            '
'            Me.lblTray.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblTray.Location = New System.Drawing.Point(466, 8)
'            Me.lblTray.Name = "lblTray"
'            Me.lblTray.Size = New System.Drawing.Size(32, 16)
'            Me.lblTray.TabIndex = 28
'            Me.lblTray.Text = "Tray"
'            '
'            'lblTrayVAL
'            '
'            Me.lblTrayVAL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblTrayVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblTrayVAL.Location = New System.Drawing.Point(466, 24)
'            Me.lblTrayVAL.Name = "lblTrayVAL"
'            Me.lblTrayVAL.Size = New System.Drawing.Size(88, 23)
'            Me.lblTrayVAL.TabIndex = 29
'            Me.lblTrayVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'lblDate
'            '
'            Me.lblDate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblDate.Location = New System.Drawing.Point(562, 8)
'            Me.lblDate.Name = "lblDate"
'            Me.lblDate.Size = New System.Drawing.Size(40, 16)
'            Me.lblDate.TabIndex = 30
'            Me.lblDate.Text = "Date"
'            '
'            'lblDateVAL
'            '
'            Me.lblDateVAL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblDateVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblDateVAL.Location = New System.Drawing.Point(562, 24)
'            Me.lblDateVAL.Name = "lblDateVAL"
'            Me.lblDateVAL.Size = New System.Drawing.Size(136, 23)
'            Me.lblDateVAL.TabIndex = 31
'            Me.lblDateVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'lblCount
'            '
'            Me.lblCount.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCount.Location = New System.Drawing.Point(706, 8)
'            Me.lblCount.Name = "lblCount"
'            Me.lblCount.Size = New System.Drawing.Size(40, 16)
'            Me.lblCount.TabIndex = 32
'            Me.lblCount.Text = "Count"
'            '
'            'lblCountVAL
'            '
'            Me.lblCountVAL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblCountVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblCountVAL.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCountVAL.Location = New System.Drawing.Point(706, 24)
'            Me.lblCountVAL.Name = "lblCountVAL"
'            Me.lblCountVAL.Size = New System.Drawing.Size(64, 32)
'            Me.lblCountVAL.TabIndex = 33
'            Me.lblCountVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'Option1
'            '
'            Me.Option1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.Option1.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Option1.Location = New System.Drawing.Point(610, 56)
'            Me.Option1.Name = "Option1"
'            Me.Option1.Size = New System.Drawing.Size(128, 16)
'            Me.Option1.TabIndex = 34
'            Me.Option1.Text = "Print Changed Device"
'            '
'            'lblCustomerNameString
'            '
'            Me.lblCustomerNameString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblCustomerNameString.Location = New System.Drawing.Point(200, 8)
'            Me.lblCustomerNameString.Name = "lblCustomerNameString"
'            Me.lblCustomerNameString.Size = New System.Drawing.Size(40, 16)
'            Me.lblCustomerNameString.TabIndex = 35
'            Me.lblCustomerNameString.Visible = False
'            '
'            'MainGrid
'            '
'            Me.MainGrid.AllowColMove = False
'            Me.MainGrid.AllowColSelect = False
'            Me.MainGrid.AllowDelete = True
'            Me.MainGrid.AllowFilter = False
'            Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
'            Me.MainGrid.AllowSort = False
'            Me.MainGrid.AllowUpdate = False
'            Me.MainGrid.AlternatingRows = True
'            Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'                        Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.MainGrid.CaptionHeight = 17
'            Me.MainGrid.CollapseColor = System.Drawing.Color.Black
'            Me.MainGrid.DataChanged = False
'            Me.MainGrid.BackColor = System.Drawing.Color.Empty
'            Me.MainGrid.ExpandColor = System.Drawing.Color.Black
'            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
'            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
'            Me.MainGrid.Location = New System.Drawing.Point(224, 120)
'            Me.MainGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
'            Me.MainGrid.Name = "MainGrid"
'            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
'            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
'            Me.MainGrid.PreviewInfo.ZoomFactor = 75
'            Me.MainGrid.PrintInfo.ShowOptionsDialog = False
'            Me.MainGrid.RecordSelectorWidth = 16
'            GridLines1.Color = System.Drawing.Color.DarkGray
'            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
'            Me.MainGrid.RowDivider = GridLines1
'            Me.MainGrid.RowHeight = 15
'            Me.MainGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
'            Me.MainGrid.ScrollTips = False
'            Me.MainGrid.Size = New System.Drawing.Size(546, 272)
'            Me.MainGrid.TabIndex = 36
'            Me.MainGrid.Text = "C1TrueDBGrid1"
'            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
'            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
'            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Ce" & _
'            "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive" & _
'            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
'            "tion{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style10{AlignHorz:Ne" & _
'            "ar;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}EvenRow{BackColor:" & _
'            "Aqua;}OddRow{}RecordSelector{AlignImage:Center;}Style8{}Style3{}Style2{}Group{Ba" & _
'            "ckColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style9{}</Data></S" & _
'            "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
'            "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
'            "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
'            "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
'            "ClientRect>0, 0, 544, 270</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
'            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
'            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
'            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
'            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
'            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
'            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
'            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
'            "nt=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles>" & _
'            "<Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pare" & _
'            "nt=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=" & _
'            """Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""" & _
'            "Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""" & _
'            "Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headi" & _
'            "ng"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=" & _
'            """Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</ho" & _
'            "rzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cl" & _
'            "ientArea>0, 0, 544, 270</ClientArea></Blob>"
'            '
'            'grpCreditCard
'            '
'            Me.grpCreditCard.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
'            Me.grpCreditCard.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtExpDate, Me.txtCCNumber, Me.cboCCType, Me.Label3})
'            Me.grpCreditCard.Location = New System.Drawing.Point(760, 392)
'            Me.grpCreditCard.Name = "grpCreditCard"
'            Me.grpCreditCard.Size = New System.Drawing.Size(8, 48)
'            Me.grpCreditCard.TabIndex = 37
'            Me.grpCreditCard.TabStop = False
'            '
'            'txtExpDate
'            '
'            Me.txtExpDate.Location = New System.Drawing.Point(376, 16)
'            Me.txtExpDate.Name = "txtExpDate"
'            Me.txtExpDate.Size = New System.Drawing.Size(64, 21)
'            Me.txtExpDate.TabIndex = 46
'            Me.txtExpDate.Text = ""
'            '
'            'txtCCNumber
'            '
'            Me.txtCCNumber.Location = New System.Drawing.Point(168, 16)
'            Me.txtCCNumber.Name = "txtCCNumber"
'            Me.txtCCNumber.Size = New System.Drawing.Size(136, 21)
'            Me.txtCCNumber.TabIndex = 45
'            Me.txtCCNumber.Text = ""
'            '
'            'cboCCType
'            '
'            Me.cboCCType.Location = New System.Drawing.Point(8, 16)
'            Me.cboCCType.Name = "cboCCType"
'            Me.cboCCType.Size = New System.Drawing.Size(152, 21)
'            Me.cboCCType.TabIndex = 44
'            '
'            'Label3
'            '
'            Me.Label3.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label3.Location = New System.Drawing.Point(312, 16)
'            Me.Label3.Name = "Label3"
'            Me.Label3.Size = New System.Drawing.Size(56, 16)
'            Me.Label3.TabIndex = 43
'            Me.Label3.Text = "Exp Date"
'            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblAddressID
'            '
'            Me.lblAddressID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblAddressID.Location = New System.Drawing.Point(32, 64)
'            Me.lblAddressID.Name = "lblAddressID"
'            Me.lblAddressID.Size = New System.Drawing.Size(40, 16)
'            Me.lblAddressID.TabIndex = 39
'            Me.lblAddressID.Visible = False
'            '
'            'lblCountVAL1
'            '
'            Me.lblCountVAL1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
'            Me.lblCountVAL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lblCountVAL1.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCountVAL1.Location = New System.Drawing.Point(224, 416)
'            Me.lblCountVAL1.Name = "lblCountVAL1"
'            Me.lblCountVAL1.Size = New System.Drawing.Size(64, 32)
'            Me.lblCountVAL1.TabIndex = 40
'            Me.lblCountVAL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'lblCount1
'            '
'            Me.lblCount1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
'            Me.lblCount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCount1.Location = New System.Drawing.Point(224, 400)
'            Me.lblCount1.Name = "lblCount1"
'            Me.lblCount1.Size = New System.Drawing.Size(40, 16)
'            Me.lblCount1.TabIndex = 41
'            Me.lblCount1.Text = "Count"
'            '
'            'grpMemo
'            '
'            Me.grpMemo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
'            Me.grpMemo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMemo})
'            Me.grpMemo.Location = New System.Drawing.Point(760, 440)
'            Me.grpMemo.Name = "grpMemo"
'            Me.grpMemo.Size = New System.Drawing.Size(8, 56)
'            Me.grpMemo.TabIndex = 44
'            Me.grpMemo.TabStop = False
'            Me.grpMemo.Text = "Memo"
'            '
'            'txtMemo
'            '
'            Me.txtMemo.Location = New System.Drawing.Point(8, 16)
'            Me.txtMemo.Multiline = True
'            Me.txtMemo.Name = "txtMemo"
'            Me.txtMemo.Size = New System.Drawing.Size(432, 32)
'            Me.txtMemo.TabIndex = 40
'            Me.txtMemo.Text = ""
'            '
'            'lblTerms
'            '
'            Me.lblTerms.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
'            Me.lblTerms.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblTerms.Location = New System.Drawing.Point(752, 408)
'            Me.lblTerms.Name = "lblTerms"
'            Me.lblTerms.Size = New System.Drawing.Size(8, 24)
'            Me.lblTerms.TabIndex = 45
'            Me.lblTerms.Text = "Credit Type: TERMS"
'            '
'            'cboAddress
'            '
'            Me.cboAddress.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.cboAddress.Location = New System.Drawing.Point(144, 48)
'            Me.cboAddress.Name = "cboAddress"
'            Me.cboAddress.Size = New System.Drawing.Size(458, 21)
'            Me.cboAddress.TabIndex = 46
'            '
'            'txtLocation
'            '
'            Me.txtLocation.Location = New System.Drawing.Point(80, 48)
'            Me.txtLocation.Name = "txtLocation"
'            Me.txtLocation.Size = New System.Drawing.Size(64, 21)
'            Me.txtLocation.TabIndex = 2
'            Me.txtLocation.Text = ""
'            '
'            'cboCustID
'            '
'            Me.cboCustID.AutoComplete = True
'            Me.cboCustID.Location = New System.Drawing.Point(8, 24)
'            Me.cboCustID.Name = "cboCustID"
'            Me.cboCustID.Size = New System.Drawing.Size(232, 21)
'            Me.cboCustID.TabIndex = 0
'            '
'            'btnStaging
'            '
'            Me.btnStaging.Location = New System.Drawing.Point(736, 408)
'            Me.btnStaging.Name = "btnStaging"
'            Me.btnStaging.Size = New System.Drawing.Size(8, 23)
'            Me.btnStaging.TabIndex = 47
'            Me.btnStaging.Text = "Staging"
'            Me.btnStaging.Visible = False
'            '
'            'lblMotorola
'            '
'            Me.lblMotorola.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblMotorola.Font = New System.Drawing.Font("Verdana", 20.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblMotorola.ForeColor = System.Drawing.Color.Blue
'            Me.lblMotorola.Location = New System.Drawing.Point(544, 80)
'            Me.lblMotorola.Name = "lblMotorola"
'            Me.lblMotorola.Size = New System.Drawing.Size(240, 32)
'            Me.lblMotorola.TabIndex = 48
'            Me.lblMotorola.Text = "MOTOROLA RL"
'            '
'            'lblWrty
'            '
'            Me.lblWrty.Location = New System.Drawing.Point(8, 144)
'            Me.lblWrty.Name = "lblWrty"
'            Me.lblWrty.Size = New System.Drawing.Size(48, 16)
'            Me.lblWrty.TabIndex = 19
'            Me.lblWrty.Text = "WRTY"
'            '
'            'cboWrty
'            '
'            Me.cboWrty.AutoComplete = True
'            Me.cboWrty.Items.AddRange(New Object() {"No Warranty", "90 Days", "1 Year"})
'            Me.cboWrty.Location = New System.Drawing.Point(56, 144)
'            Me.cboWrty.Name = "cboWrty"
'            Me.cboWrty.Size = New System.Drawing.Size(112, 21)
'            Me.cboWrty.TabIndex = 8
'            '
'            'frmMOTORL_Receiving
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
'            Me.ClientSize = New System.Drawing.Size(794, 503)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMotorola, Me.btnStaging, Me.cboCustID, Me.txtLocation, Me.cboAddress, Me.grpMemo, Me.lblCount1, Me.lblCountVAL1, Me.lblAddressID, Me.grpCreditCard, Me.MainGrid, Me.lblCustomerNameString, Me.Option1, Me.lblCountVAL, Me.lblCount, Me.lblDateVAL, Me.lblDate, Me.lblTrayVAL, Me.lblTray, Me.txtWorkOrderMemo, Me.lblAddressVAL, Me.lblAddress, Me.lblCustomerVAL, Me.lblCustomer, Me.grpWorkOrder, Me.PictureBox1, Me.lblWorkOrderMemo, Me.lblCustomerID, Me.grpDevice, Me.lblTerms, Me.chkDBR, Me.lblCustomWorkOrder, Me.lblClaimNum, Me.txtClaimNum, Me.lblMemberNum, Me.txtMemberNum, Me.lblCustomerReason, Me.cboCustomerReason, Me.cboCR, Me.lblCustomerReasonNameString, Me.btnReprint, Me.Button1, Me.Label1})
'            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
'            Me.Name = "frmMOTORL_Receiving"
'            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
'            Me.Text = "frmReceiving"
'            Me.grpWorkOrder.ResumeLayout(False)
'            Me.grpDevice.ResumeLayout(False)
'            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
'            Me.grpCreditCard.ResumeLayout(False)
'            Me.grpMemo.ResumeLayout(False)
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Private arrState(150, 1) As String
'        Private arrCountry(300, 1) As String
'        Private arrCustomers(10000, 6) As String
'        Private arrModels(10000, 1) As String
'        Private arrCustomerReason(10000, 2) As String
'        Private arrLocations(10000, 3) As String
'        Private arrManufacturers(1000, 1) As String
'        Private arrProdGrp(1000) As String
'        Private arrCCType(100, 1) As String
'        Private arrCustAddress(10000) As Integer

'        Public Shared intCounter As Integer
'        Public Shared waitStateVAL As Integer
'        Public Shared multiLoc As String

'        Private DeviceTypeFlg, RecTypeFlg, ProdID, CustPSSwrtyParts, CustPSSwrtyLabor, CustPSSwrtyRejectDays, CustPSSwrtyRejectTimes, CustPSSwrtyDaysInWrty, valLaborLevel As Integer
'        Private valCust, valLoc, valCC, VALworkorder, VALtray, VALdevice, VALmodel, VALmanufacturer, valPO, valPASS, valShipTo, valStage, valWEBuser As Int32
'        Private valMemo As String
'        Private vDiscrepancy As String

'        Private valLaborCharge As Double

'        Private blnCredit, VALverify, VALOption1, PSSwarranty, valDBR, blnWOtest As Boolean

'        Private Device_Type, RecUser, RecType, DeviceType, WebUser, VALmainGrid, VALwrty, valOLDSN As String
'        Public Shared cellValCustomer, cellValDateCode, cellValPOP, cellValProdCode, cellValMSN, cellValModel As String

'        Private POCustWO, POwrty As String

'        Private dtGridMain, dataGrid, dtReconcile As DataTable
'        Private valReconcile As Integer
'        Private valReconcileID As Int32
'        Private intSKU As Int32

'        Public Shared vcCourierTrackIN, vcAirCarrCode, vcTransactionCode, vcAPCcode, vcTranceiverCode, vcIncomingIMEI, vcWrtyClaimNum, vcCSN, vcMIN, vcCarrModelCode As String
'        Public Shared vcDateCode, vcCustomerName, vcModel, vcPOP, vcMSN, vcProductCode, vcDateCodeVM, vcComplaint, coDeviceSN, vcDecimal

'        Private Sub frmReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'            VALworkorder = 0
'            enableCreditCardInput()
'            ShowCCgrp()
'            cboAddress.Visible = False
'            txtLocation.Visible = False

'            '//Initial Variables Section - START
'            'Me.txtWorkOrder.Text = "120eQwstPSSI4.9.04"
'            'Me.txtQuantity.Text = "2145"
'            'Me.txtIP.Text = "0"
'            'Me.txtRAQty.Text = "2145"
'            'Me.txtSKU.Text = "SUG3284RA"
'            Me.cboWrty.Text = "1 year"
'            '//Initial Variables Section - END

'            defineDeviceTypes()

'            If Len(RecType) < 1 Then
'                Me.Close()
'                Me.Dispose()
'            Else
'                '//Initial loads for the form
'                Try
'                    releaseControls()
'                    PopulateCustomers()             '//Makes list of customers - cboCustomer
'                    PopulateManufacturers()         '//Makes list of Manufacturers - based on DeviceType
'                    PopulateCreditCardTypes()       '//Makes list of Credit Card Producers
'                    Highlight.SetHighLight(Me)      '//Highlights currently selected control
'                    HideClaimMember()               '//Hides the Claim and Member Fields
'                    InitializeCounter()             '//Sets the counter field to 0
'                    InitializeDate()                '//Get todays date in correct format
'                    AssignColumnHeaders2Grid()      '//Defines grid column headers
'                    AssignFrmCaption()              '//Assigns the correct name to the form header
'                    makeArrayState()
'                    makeArrayCountry()
'                    InitializePSSwrtyFields()
'                    blnWOtest = False

'                    Dim tmpUser As String = PSS.Core.Global.ApplicationUser.User
'                    RecUser = tmpUser
'                    valDBR = False

'                    'Procedure - if recovering an End User. Set the customer = the newly entered record.
'                    If RecType = "3" Then
'                        selectEndUser()
'                        GetCreditCardInformation()
'                    End If

'                    If RecType = "4" And DeviceType = "2" Then
'                        selectEndUser()
'                        GetCreditCardInformation()
'                    End If

'                    If RecType = 4 And DeviceType = "1" Then
'                        Dim xCount As Integer = 0
'                        Dim valCustName As String

'                        'Get customer name
'                        For xCount = 0 To UBound(arrCustomers)
'                            If arrCustomers(xCount, 0) = valCust Then valCustName = arrCustomers(xCount, 1)
'                        Next
'                        For xCount = 0 To cboCustID.Items.Count - 1
'                            If cboCustID.Items(xCount) = valCustName Then
'                                cboCustID.SelectedIndex = xCount
'                            End If
'                        Next

'                        cboCustomerIDChanged()
'                    End If

'                    If RecType = "5" Then
'                        '//Staging Receiving
'                        lblAddress.Visible = False
'                        lblAddressVAL.Visible = False
'                        txtLocation.Visible = False
'                        cboAddress.Visible = False
'                        lblWorkOrder.Visible = False
'                        txtWorkOrder.Visible = False
'                        lblCustomerReason.Visible = False
'                        cboCustomerReason.Visible = False
'                        txtLocation.Visible = False
'                        cboAddress.Visible = False
'                        HideCCgrp()
'                    End If

'                    cboCustID.Focus()
'                    Exit Sub

'                    MsgBox("You did not select a receive type/ device type to be received. Please close this page", MsgBoxStyle.OKOnly, "Error Opening Form")


'                Catch exp As Exception

'                    MsgBox(exp.ToString)

'                    MsgBox("An error occured while loading the form, please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
'                    Me.Close()
'                    Me.Dispose()
'                End Try
'            End If


'        End Sub

'        Private Sub defineDeviceTypes()

'            '//This section assigns the device type and receive type
'            '//based on values entered on frmSelectRecType

'            '//Section - Pagers

'            grpCreditCard.Visible = False

'            '//Select Firm or COAM or End User
'            If DeviceType = "1" Then 'Pagers
'                ProdID = 1
'                If RecType = "1" Then 'Firm
'                    HideCustomerReason()
'                    HideClaimMember()
'                    HideMemo()
'                End If
'                If RecType = "2" Then 'COAM
'                    HideCustomerReason()
'                    HideClaimMember()
'                    HideMemo()
'                    HideCCgrp()
'                End If
'                If RecType = "3" Then 'End User
'                    HideCustomerReason()
'                    HideClaimMember()
'                    HideMemo()
'                    Dim frmEndUser As New frmEndUserInput(1, 0)
'                    frmEndUser.ShowDialog()

'                    Try
'                        valCust = frmenduser.valCust
'                        valLoc = frmenduser.valLoc
'                        valCC = frmenduser.valCC
'                    Catch exp As Exception
'                        MsgBox("Data can not be retrieved from end user input screen. Please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
'                        Me.Close()
'                    End Try

'                    frmEndUser.Dispose()
'                    grpCreditCard.Visible = True
'                End If

'                If RecType = "3" And DeviceType = "2" Then 'End User
'                    HideCustomerReason()
'                    HideClaimMember()
'                    HideMemo()
'                    Dim frmEndUser As New frmEndUserInput(1, 0)
'                    frmEndUser.ShowDialog()

'                    Try
'                        valCust = frmenduser.valCust
'                        valLoc = frmenduser.valLoc
'                        valCC = frmenduser.valCC
'                    Catch exp As Exception
'                        MsgBox("Data can not be retrieved from end user input screen. Please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
'                        Me.Close()
'                    End Try

'                    frmEndUser.Dispose()
'                    grpCreditCard.Visible = True
'                End If

'                If RecType = "4" Then 'PO
'                    HideCustomerReason()
'                    HideClaimMember()
'                    HideMemo()
'                    'message box for input of po number
'                    Dim POID As Integer
'enterPO:
'                    POID = InputBox("Please enter or scan the PO Number:", "Enter PO Number")
'                    If IsNumeric(POID) = False Then
'                        MsgBox("Please enter a numberic value for the PO Number.", MsgBoxStyle.OKOnly)
'                        GoTo enterPO
'                    Else
'                        valPO = POID
'                    End If
'                    Dim tblPO As New PSS.Data.Production.tpurchaseorder()
'                    Dim dtPO As DataRow = tblPO.GetRowByPK(valPO)
'                    valLoc = dtPO("Loc_ID")

'                    '//New Code July 21, 2003 to determine if ship to exists for po
'                    If IsDBNull(dtPO("ShipTo_ID")) = False Then
'                        valShipTo = dtPO("ShipTo_ID")
'                    Else
'                        valShipTo = 0
'                    End If
'                    '//END


'                    Dim tblLoc As New PSS.Data.Production.tlocation()
'                    Dim dtLoc As DataRow = tblLoc.GetRowByPK(valLoc)
'                    valCust = dtLoc("Cust_ID")
'                    Dim tblWO As New PSS.Data.Production.tworkorder()
'                    Dim dtWO As DataRow = tblWO.GetRowByPO(valPO)
'                    VALworkorder = dtWO("Wo_ID")
'                    txtWorkOrder.Text = dtWO("WO_CustWO")
'                    POCustWO = dtWO("WO_CustWO")
'                    POwrty = MsgBox("Is this PO Type for FIRM?", MsgBoxStyle.YesNo, "Select Warranty Check Type")
'                    If POwrty = vbYes Then
'                        POwrty = "FIRM"
'                    Else
'                        POwrty = "COAMPLUS"
'                    End If

'                End If
'            End If


'            '//Section - Cellular
'            If DeviceType = "2" Then 'Cells
'                ProdID = 2
'                If RecType = "1" Then 'Firm
'                    'ShowCustomerReason()
'                    ShowClaimMember()
'                    HideMemo()
'                End If
'                If RecType = "2" Then 'COAM
'                    'ShowCustomerReason()
'                    ShowClaimMember()
'                    HideMemo()
'                    HideCCgrp()
'                End If
'                If RecType = "3" Then 'End User
'                    'ShowCustomerReason()
'                    ShowClaimMember()
'                    HideMemo()
'                    Dim frmEndUser As New frmEndUserInput(2, 0)
'                    frmEndUser.ShowDialog()
'                    valCust = frmenduser.valCust
'                    valLoc = frmenduser.valLoc
'                    valCC = frmenduser.valCC
'                    frmEndUser.Dispose()
'                    grpCreditCard.Visible = True
'                End If
'                If RecType = "4" Then 'Web User
'                    '                    ShowCustomerReason()
'                    '                    ShowClaimMember()
'                    '                    ShowMemo()
'                    'ShowCustomerReason()
'                    ShowClaimMember()
'                    HideMemo()
'                    Dim frmEndUser As New frmEndUserInput(2, 4)
'                    frmEndUser.ShowDialog()
'                    'valCust = frmenduser.valCust
'                    'valLoc = frmenduser.valLoc
'                    'valCC = frmenduser.valCC
'                    'frmEndUser.Dispose()
'                    grpCreditCard.Visible = True
'                    grpMemo.Visible = True

'                    Try
'                        valCust = frmenduser.valCust
'                        valLoc = frmenduser.valLoc
'                        valCC = frmenduser.valCC
'                        VALmanufacturer = frmenduser.valManuf
'                        VALmodel = frmenduser.valModel
'                        valMemo = frmenduser.valMemo
'                    Catch exp As Exception
'                        MsgBox("Data can not be retrieved from end user input screen. Please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
'                        Me.Close()
'                    End Try

'                    frmEndUser.Dispose()
'                    grpCreditCard.Visible = True


'                End If
'            End If




'        End Sub

'        Private Sub enableCreditCardInput()

'            '//Makes the fields available for input
'            '//They should be locked if the credit card value is assigned through the 
'            '//end user input form
'            cboCCType.Enabled = True
'            txtCCNumber.Enabled = True
'            txtExpDate.Enabled = True

'        End Sub

'        Private Sub selectEndUser()

'            '//If the user has been assigned through the end user input screen.
'            '//Then the value should be assigned directly.

'            Dim xCount As Integer = 0
'            Dim arrCount As Integer = UBound(arrCustomers, 1)
'            Dim arrManCount As Integer = UBound(arrManufacturers, 1)
'            Dim arrModelCount As Integer = UBound(arrModels, 1)

'            Try
'                If Len(valCust) > 0 Then

'                    For xCount = 0 To arrCount - 1
'                        If arrCustomers(xCount, 0) = valCust Then
'                            cboCustID.SelectedIndex = xCount

'                        End If
'                    Next
'                End If
'            Catch exp As Exception
'                MsgBox(exp.ToString)
'            End Try

'            If RecType = "4" And DeviceType = "2" Then
'                Try
'                    If Len(VALmanufacturer) > 0 Then

'                        For xCount = 0 To arrManCount - 1
'                            If Trim(arrManufacturers(xCount, 0)) = Trim(VALmanufacturer) Then
'                                Me.cboManufID.SelectedIndex = xCount

'                            End If
'                        Next
'                    End If
'                Catch exp As Exception
'                    MsgBox(exp.ToString)
'                End Try
'                Try
'                    If Len(VALmodel) > 0 Then

'                        For xCount = 0 To arrModelCount - 1
'                            If arrModels(xCount, 0) = VALmodel Then
'                                Me.cboModID.SelectedIndex = xCount
'                            End If
'                        Next
'                    End If
'                Catch exp As Exception
'                    MsgBox(exp.ToString)
'                End Try
'            End If
'            grpMemo.Visible = True
'            If IsDBNull(valMemo) = False Then txtMemo.Text = valMemo
'            grpCreditCard.Visible = True

'        End Sub

'        Private Sub InitializeDate()

'            lblDateVAL.Text = FormatDate(Now)

'        End Sub

'        Private Sub InitializeCounter()

'            '//Sets the counter value to 0
'            intCounter = 0
'            lblCountVAL.Text = intCounter
'            lblCountVAL1.Text = intCounter

'        End Sub

'        Private Sub AssignFrmCaption()

'            Try
'                Dim DeviceName As String

'                If DeviceType = 1 Then DeviceName = "Pager"
'                If DeviceType = 2 Then DeviceName = "Cell"

'                If RecType = 1 Then
'                    frmReceiving.ActiveForm.Text = "Receiving Firm Process: " & DeviceName
'                ElseIf RecType = 2 Then
'                    frmReceiving.ActiveForm.Text = "Receiving COAM Process: " & DeviceName
'                ElseIf RecType = 3 Then
'                    frmReceiving.ActiveForm.Text = "Receiving End User Process: " & DeviceName
'                ElseIf RecType = 4 Then
'                    frmReceiving.ActiveForm.Text = "Receiving Web User Process: " & DeviceName
'                End If
'            Catch ex As Exception
'            End Try

'        End Sub

'        Private Function verifyCustomerSelected() As Boolean

'            '//Re-align focus to Customer ID if the value has not been selected
'            verifyCustomerSelected = False

'            If Len(cboCustID.Text) < 1 Then
'                cboCustID.Focus()
'            Else
'                verifyCustomerSelected = True
'            End If

'        End Function

'        Private Function verifyManufacturerSelected() As Boolean

'            '//Re-align focus to Manufacturer ID if the value has not been selected
'            verifyManufacturerSelected = False

'            If Len(cboManufID.Text) < 1 Then
'                cboManufID.Focus()
'            ElseIf Len(lblManufacturerNameString.Text) < 1 Then
'                cboManufID.Focus()
'            Else
'                verifyManufacturerSelected = True
'            End If

'        End Function

'        Private Function verifyModelSelected() As Boolean

'            '//Re-align the focus to the Model ID if the value has not been selected
'            verifyModelSelected = False

'            If Len(cboModID.Text) < 1 Then
'                cboModID.Focus()
'            ElseIf Len(lblModelNameString.Text) < 1 Then
'                cboModID.Focus()
'            Else
'                verifyModelSelected = True
'            End If

'        End Function

'        Private Function verifyWorkOrderSelected() As Boolean

'            '//Re-align the focus to the WorkOrder if the value has not been defined
'            verifyWorkOrderSelected = False

'            If Len(txtWorkOrder.Text) < 1 Then
'                txtWorkOrder.Focus()
'            Else
'                verifyWorkOrderSelected = True
'            End If

'        End Function

'        Private Sub PopulateComplaintCodes()

'            '//Clear all fields before repopulating.
'            '//Keeps from duplicates being entered
'            Try
'                cboCustomerReason.Items.Clear()
'            Catch ex As Exception
'            End Try

'            cboCustomerReason.Text = ""
'            lblCustomerReasonNameString.Text = ""

'            Dim xCount As Integer = 0
'            Dim addCount As Integer = 0
'            Dim tblComplaint As New PSS.Data.Production.tcomplaint()
'            Dim dsComplaint As DataSet = tblComplaint.GetData
'            Dim rComplaint As DataRow
'            Try
'                For xCount = 0 To dsComplaint.Tables("tcomplaint").Rows.Count - 1
'                    rComplaint = dsComplaint.Tables("tcomplaint").Rows(xCount)
'                    '//Get complaints for the correct manufacturer and product. Complaint only exists currently for cellular devices
'                    If rComplaint("Manuf_ID") = Me.lblManufacturerNameString.Text Then
'                        If rComplaint("Prod_ID") = 2 Then
'                            cboCustomerReason.Items.Add(rComplaint("Comp_Desc"))
'                            arrCustomerReason(addCount, 0) = rComplaint("Comp_Desc")
'                            arrCustomerReason(addCount, 1) = rComplaint("Comp_Code")
'                            arrCustomerReason(addCount, 2) = rComplaint("Comp_ID")
'                            addCount += 1
'                        End If
'                    End If
'                Next
'            Catch ex As Exception
'            End Try

'            dsComplaint.Dispose()
'            dsComplaint = Nothing
'            tblComplaint = Nothing

'        End Sub

'        Private Sub PopulateCustomers()

'            'This will generate the data for the cboCustomerID control.
'            'It will also create a two dimensional array that holds the Customer IDs
'            'and Names
'            Dim xCount As Integer = 0
'            Dim arrCount As Integer = 0
'            Dim tblCustomer As New PSS.Data.Production.Joins()
'            Dim tblCustEU As New PSS.Data.Production.tcustomer()
'            Dim dtCust As DataTable
'            Dim r As DataRow

'            '//Defines different selection lists depending on RecType
'            If RecType = "1" Then 'FIRM
'                dtCust = tblCustomer.CustomerListPagerFirm(DeviceType)
'            End If
'            If RecType = "2" Then 'COAM
'                dtCust = tblCustomer.CustomerListPagerCOAM(DeviceType)
'            End If
'            If RecType = "3" Then 'EndUser
'                dtCust = tblCustomer.CustomerListPagerEndUser()
'                r = tblCustEU.GetRowByPK(valCust)
'            End If
'            If RecType = "4" And DeviceType = "2" Then 'EndUser
'                dtCust = tblCustomer.CustomerListPagerEndUser()
'                r = tblCustEU.GetRowByPK(valCust)
'            End If
'            If RecType = "4" And DeviceType = "1" Then 'PO
'                dtCust = tblCustomer.CustomerListPagerPO
'                '                r = tblCustEU.GetRowByPK(valCust)
'            End If
'            If RecType = "5" Then 'FIRM
'                dtCust = tblCustomer.CustomerListPagerFirm(DeviceType)
'            End If

'            If (RecType = "3" And Len(valCust) > 0) Or (RecType = "4" And DeviceType = "2" And Len(valCust) > 0) Then
'                arrCount = 0
'                For xCount = 0 To dtCust.Rows.Count - 1

'                    If r("Cust_ID") = valCust Then
'                        cboCustID.Items.Add(r("Cust_Name1") & " " & r("Cust_Name2"))

'                        arrCustomers(arrCount, 0) = r("Cust_ID")
'                        If Not IsDBNull(r("Cust_Name1")) Then
'                            arrCustomers(arrCount, 1) = r("Cust_Name1")
'                        End If
'                        If Not IsDBNull(r("Cust_Name2")) Then
'                            arrCustomers(arrCount, 2) = r("Cust_Name2")
'                        End If
'                        If Not IsDBNull(r("Cust_CrApproveRec")) Then
'                            arrCustomers(arrCount, 3) = r("Cust_CrApproveRec")
'                        End If
'                        If Not IsDBNull(r("Pay_ID")) Then
'                            arrCustomers(arrCount, 4) = r("Pay_ID")
'                        End If
'                        If Not IsDBNull(r("Cust_RecRcncl")) Then
'                            arrCustomers(arrCount, 5) = r("Cust_RecRcncl")
'                        End If
'                        If Not IsDBNull(r("Cust_Stage")) Then
'                            arrCustomers(arrCount, 6) = r("Cust_Stage")
'                        End If
'                        arrCount += 1
'                        Exit For
'                    End If

'                Next

'            Else

'                arrCount = 0
'                For xCount = 0 To dtCust.Rows.Count - 1
'                    r = dtCust.Rows(xCount)

'                    If r("PCo_ID") <> 349 And r("PCo_ID") <> 409 Then

'                        cboCustID.Items.Add(r("Cust_Name1"))

'                        If r("Cust_ID") = 1844 Then
'                            cboCustID.SelectedText = r("Cust_Name1")
'                        End If

'                        arrCustomers(arrCount, 0) = r("Cust_ID")
'                        If Not IsDBNull(r("Cust_Name1")) Then
'                            arrCustomers(arrCount, 1) = r("Cust_Name1")
'                        End If
'                        If Not IsDBNull(r("Cust_Name2")) Then
'                            arrCustomers(arrCount, 2) = r("Cust_Name2")
'                        End If
'                        If Not IsDBNull(r("Cust_CrApproveRec")) Then
'                            arrCustomers(arrCount, 3) = r("Cust_CrApproveRec")
'                        End If
'                        If Not IsDBNull(r("Pay_ID")) Then
'                            arrCustomers(arrCount, 4) = r("Pay_ID")
'                        End If
'                        If Not IsDBNull(r("Cust_RecRcncl")) Then
'                            arrCustomers(arrCount, 5) = r("Cust_RecRcncl")
'                        End If
'                        If Not IsDBNull(r("Cust_Stage")) Then
'                            arrCustomers(arrCount, 6) = r("Cust_Stage")
'                        End If
'                        arrCount += 1
'                    End If

'                Next

'            End If

'            dtCust.Dispose()
'            dtCust = Nothing
'            tblCustomer = Nothing
'            tblCustEU = Nothing

'        End Sub

'        Private Sub PopulateCreditCardTypes()

'            '//This is no longer used
'            'Get Credit Card Type Description
'            Dim xCount As Integer = 0
'            Dim tblCCtype As New PSS.Data.Production.lcctype()
'            Dim dsCCtype As DataSet = tblCCtype.GetData
'            Dim drCCtype As DataRow

'            For xCount = 0 To dsCCtype.Tables("lcctype").Rows.Count - 1
'                drCCtype = dsCCtype.Tables("lcctype").Rows(xCount)
'                cboCCType.Items.Add(drCCtype("CCType_Desc"))
'                arrCCType(xCount, 0) = drCCtype("CCType_ID")
'                arrCCType(xCount, 1) = drCCtype("CCType_Desc")
'            Next

'            dsCCtype.Dispose()
'            dsCCtype = Nothing
'            tblCCtype = Nothing

'        End Sub

'        Private Sub PopulateManufacturers()

'            'This will generate the data for the cboCustomerID control.
'            'It will also create a two dimensional array that holds the Customer IDs
'            'and Names
'            Dim xCount As Integer = 0
'            Dim tblJoins As New PSS.Data.Production.Joins()
'            Dim dtManuf As DataTable
'            dtManuf = tblJoins.ManufListByDeviceType(CInt(DeviceType))
'            Dim r As DataRow

'            For xCount = 0 To dtManuf.Rows.Count - 1
'                r = dtManuf.Rows(xCount)
'                cboManufID.Items.Add(Trim(r("Manuf_Desc")))
'                arrManufacturers(xCount, 0) = r("Manuf_ID")
'                If Not IsDBNull(r("Manuf_Desc")) Then
'                    arrManufacturers(xCount, 1) = Trim(r("Manuf_Desc"))
'                End If
'            Next

'            dtManuf.Dispose()
'            dtManuf = Nothing
'            tblJoins = Nothing

'        End Sub

'        Private Sub PopulateComplaints()

'            'This will generate the data for the cboComplaint control.
'            'It will also create a two dimensional array that holds the Complaint IDs
'            'and Names
'            Dim xCount As Integer = 0
'            Dim tblJoins As New PSS.Data.Production.Joins()
'            Dim dtComplaint As DataTable
'            dtComplaint = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='complaint' and lcodesdetail.manuf_id=" & lblManufacturerNameString.Text & " and lcodesdetail.prod_id=2 ORDER BY DCode_LDesc")
'            Dim r As DataRow


'            Try
'                cboCustomerReason.Items.Clear()
'            Catch ex As Exception
'            End Try

'            For xCount = 0 To dtComplaint.Rows.Count - 1
'                r = dtComplaint.Rows(xCount)
'                Me.cboCustomerReason.Items.Add(Trim(r("Dcode_LDesc")))
'                arrCustomerReason(xCount, 0) = r("Dcode_ID")
'                If Not IsDBNull(r("Dcode_LDesc")) Then
'                    arrCustomerReason(xCount, 1) = Trim(r("Dcode_LDesc"))
'                End If
'            Next

'            dtComplaint.Dispose()
'            dtComplaint = Nothing
'            tblJoins = Nothing

'        End Sub

'        Private Sub PopulateModels()

'            'This will generate the data for the cboCustomerID control.
'            'It will also create a two dimensional array that holds the Customer IDs
'            'and Names
'            Dim xCount As Integer = 0

'            cboModID.Items.Clear()
'            cboModID.Text = ""
'            lblModelNameString.Text = ""

'            Dim tblJoins As New PSS.Data.Production.Joins()
'            Dim dtModels As DataTable = tblJoins.ModelListByManufAndDeviceType(CInt(DeviceType), CInt(lblManufacturerNameString.Text))
'            Dim r As DataRow

'            For xCount = 0 To dtModels.Rows.Count - 1
'                r = dtModels.Rows(xCount)
'                cboModID.Items.Add(Trim(r("Model_Desc")))

'                arrModels(xCount, 0) = r("Model_ID")
'                If Not IsDBNull(r("Model_Desc")) Then
'                    arrModels(xCount, 1) = Trim(r("Model_Desc"))
'                End If

'            Next

'            dtModels.Dispose()
'            dtModels = Nothing
'            tblJoins = Nothing

'            'Get an array of prodGrps for Manufacturer
'            '            Dim tblProdGrp As New PSS.Data.Production.lprodgrp()
'            '            Dim dsProdGrp As DataSet = tblProdGrp.GetData
'            '            Dim rProdGrp As DataRow
'            '            Dim arrProdGrpID(100) As Integer
'            '            For xCount = 0 To dsProdGrp.Tables("lprodgrp").Rows.Count - 1
'            '                rProdGrp = dsProdGrp.Tables("lprodgrp").Rows(xCount)
'            '                If rProdGrp("Prod_ID") = 2 Then
'            '                    'Add record to array
'            '                    arrProdGrpID(arrCount) = rProdGrp("ProdGrp_ID")
'            '                    arrCount += 1
'            '                End If
'            '            Next

'            '            dsProdGrp = Nothing
'            '            tblProdGrp = Nothing

'            'Get models from tmodel where manufacturerID = caption and ProdGrpID is in array

'            'Clear the combo box
'            '           cboModID.Items.Clear()
'            '           cboModID.Text = ""
'            '           lblModelNameString.Text = ""

'            '          Dim manufID As Integer = Me.lblManufacturerNameString.Text
'            '          If Len(manufID) < 1 Then
'            '              'Throw error
'            '              Exit Sub
'            '          End If

'            '            Dim tblModel As New PSS.Data.Production.tmodel()
'            '            Dim dsModel As DataSet = tblModel.GetData
'            '            Dim rModel As DataRow
'            '            For xCount = 0 To dsModel.Tables("tmodel").Rows.Count - 1
'            '                rModel = dsModel.Tables("tmodel").Rows(xCount)
'            '                If rModel("manuf_id") = manufID Then
'            '                    For modelCount = 0 To arrCount
'            '                        If arrProdGrpID(modelCount) = rModel("ProdGrp_ID") Then
'            '                            'Add value to combo box.
'            '                            cboModID.Items.Add(rModel("Model_Desc"))
'            '
'            '                            arrModels(modelCount2, 0) = rModel("Model_ID")
'            '                            If Not IsDBNull(rModel("Model_Desc")) Then
'            '                                arrModels(modelCount2, 1) = rModel("Model_Desc")
'            '                            End If
'            '                            modelCount2 += 1
'            '                        End If
'            '                    Next
'            '                End If
'            '            Next

'            '            dsModel = Nothing
'            '            tblModel = Nothing

'        End Sub

'        Private Function GetCustomerReasonID() As Long

'            Dim xCount As Integer

'            GetCustomerReasonID = 0

'            Try

'                For xCount = 0 To UBound(arrCustomerReason) - 1 'cboCustomerReason.Items.Count - 1
'                    If arrCustomerReason(xCount, 1).ToString = cboCustomerReason.Text Then
'                        GetCustomerReasonID = arrCustomerReason(xCount, 0)
'                        Exit For
'                    End If
'                Next
'            Catch ex As Exception
'            End Try

'        End Function

'        Private Function GetManufactureID() As Long

'            Dim xCount As Integer = 0

'            GetManufactureID = 0

'            For xCount = 0 To cboManufID.Items.Count - 1
'                If arrManufacturers(xCount, 1).ToString = cboManufID.Text Then
'                    GetManufactureID = arrManufacturers(xCount, 0).ToString
'                End If
'            Next

'        End Function

'        Private Function GetModelID() As Long

'            Dim xCount As Integer

'            GetModelID = 0

'            For xCount = 0 To cboModID.Items.Count - 1
'                If arrModels(xCount, 1).ToString = cboModID.Text Then
'                    GetModelID = arrModels(xCount, 0).ToString
'                End If
'            Next

'        End Function

'        Private Function GetComplaintID() As Long

'            Dim xCount As Integer

'            GetComplaintID = 0

'            For xCount = 0 To cboCustomerReason.Items.Count - 1
'                If arrCustomerReason(xCount, 0).ToString = cboCustomerReason.Text Then
'                    GetComplaintID = arrCustomerReason(xCount, 2).ToString
'                End If
'            Next

'        End Function


'        Private Sub cboCustomerIDChanged()

'            txtLocation.Text = ""
'            cboAddress.Items.Clear()
'            cboAddress.Text = ""

'            cboCustID.DroppedDown = False
'            System.Windows.Forms.Application.DoEvents()

'            Dim xCount As Integer = 0

'            '//This is a reload of information for the customer 
'            '//if the operator chooses a different customer

'            'Fill in customer name

'            Dim strCustName As String = ""
'            '            If Len(arrCustomers(xCount, 1)) > 0 Then strCustName += arrCustomers(xCount, 1).ToString
'            '            If Len(arrCustomers(xCount, 2)) > 0 Then strCustName += ", " & arrCustomers(xCount, 2).ToString
'            '            Me.lblCustomerVAL.Text = strCustName

'            If RecType = "4" Then
'                For xCount = 0 To UBound(arrCustomers)
'                    If arrCustomers(xCount, 0) = valCust Then
'                        lblCustomerVAL.Text = arrCustomers(xCount, 1)
'                        Exit For
'                    End If
'                Next
'            Else
'                If Len(arrCustomers(xCount, 1)) > 0 Then strCustName += arrCustomers(cboCustID.SelectedIndex, 1).ToString
'                If Len(arrCustomers(xCount, 2)) > 0 Then strCustName += " " & arrCustomers(cboCustID.SelectedIndex, 2).ToString
'                Me.lblCustomerVAL.Text = strCustName
'            End If

'            cboCustID.DroppedDown = False
'            If RecType <> "5" Then
'                Me.getCustomerAddressInformation()
'            End If

'            If RecType = "3" Then
'                Me.GetCreditCardInformation()
'                grpCreditCard.Visible = True
'                cboCCType.Enabled = False
'                txtCCNumber.Enabled = False
'                txtExpDate.Enabled = False
'            End If

'            If RecType <> "3" Then
'                'Verify Credit Worthiness
'                Dim creditWorth As Boolean = VerifyCreditWorthiness()
'                If creditWorth = False Then cboCustID.Focus()
'            End If

'        End Sub

'        Private Sub cboManufacturer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboManufID.SelectedIndexChanged

'        End Sub

'        Private Sub cboModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectedIndexChanged
'        End Sub

'        Private Sub txtWorkOrder_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWorkOrder.Enter

'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            Dim verVal As Boolean
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub

'            If Len(lblAddressID.Text) < 1 Then
'                lblAddressID.Focus()
'                Exit Sub
'            End If

'            If DeviceType = "2" Then 'make customer workorder number
'                'Dim strWO As String = "CELL-" & Format(Now, "Mddyyyy-hhmmss")
'                'txtWorkOrder.Text = strWO
'            End If

'        End Sub

'        Private Sub cboCustomWorkOrder_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            Dim verVal As Boolean
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub

'        End Sub

'        Private Sub txtClaimNum_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClaimNum.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            verVal = verifyWorkOrderSelected()
'            If verVal = False Then Exit Sub

'        End Sub

'        Private Sub txtMemberNum_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberNum.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            verVal = verifyWorkOrderSelected()
'            If verVal = False Then Exit Sub

'        End Sub

'        Private Sub cboManufacturer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufID.Enter

'        End Sub

'        Private Sub cboModel_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.Enter

'        End Sub


'        Private Sub txtDeviceSN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeviceSN.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            '            verVal = verifyWorkOrderSelected()
'            '            If verVal = False Then Exit Sub
'            '//Verify that a manufacturer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Manufacturer field if needed
'            verVal = verifyManufacturerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a model is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Model field if needed
'            verVal = verifyModelSelected()
'            If verVal = False Then Exit Sub

'            'If DeviceType = "2" Then
'            '    cboCustomerReason.DroppedDown = True
'            'End If

'        End Sub

'        Private Sub txtDeviceSN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeviceSN.Leave

'            If Device_Type = "Cell" Then


'                If cboManufID.Text = "Nokia" Then
'                    Dim frmMoto As New frmCellDeviceInfo()
'                    frmMoto.ManufName = "Nokia"
'                    frmMoto.ManufFlag = "N"
'                    frmMoto.HideInitElements()
'                    frmMoto.ShowDialog()
'                ElseIf cboManufID.Text = "Motorola" Then
'                    Dim frmMoto As New frmCellDeviceInfo()
'                    frmMoto.ManufName = "Motorola"
'                    frmMoto.ManufFlag = "M"
'                    frmMoto.HideInitElements()
'                    frmMoto.ShowDialog()
'                ElseIf cboManufID.Text = "Sony" Then
'                    Dim frmMoto As New frmCellDeviceInfo()
'                    frmMoto.ManufName = "Sony"
'                    frmMoto.ManufFlag = "S"
'                    frmMoto.HideInitElements()
'                    frmMoto.ShowDialog()
'                Else
'                    Dim frmMoto As New frmCellDeviceInfo()
'                    frmMoto.ManufName = "Generic"
'                    frmMoto.ManufFlag = ""
'                    frmMoto.HideInitElements()
'                    frmMoto.ShowDialog()
'                End If

'            End If

'            'Data needs to be added to the grid at this point.

'        End Sub

'        Private Sub HideClaimMember()

'            '//This will hide all control elements for Claim and Member
'            '//Should be visible only under certain criteria
'            lblClaimNum.Visible = False
'            txtClaimNum.Visible = False
'            lblMemberNum.Visible = False
'            txtMemberNum.Visible = False

'        End Sub

'        Private Sub ShowClaimMember()

'            '//This will show all control elements for Claim and Member
'            '//Should be visible only under certain criteria
'            lblClaimNum.Visible = True
'            txtClaimNum.Visible = True
'            lblMemberNum.Visible = True
'            txtMemberNum.Visible = True

'        End Sub

'        Private Function VerifyCreditWorthiness() As Boolean

'            '//This method will examine the field Cust_CrApproveRec
'            '//If this value is set to 1 then the customer is credit worthy
'            Dim xCount As Integer

'            VerifyCreditWorthiness = False

'            '//If RecType is End User then do not examine Credit Worthiness.
'            '//Credit Card information should be included with customer input
'            If RecType = 3 Then
'                lblTerms.Visible = False
'                VerifyCreditWorthiness = True
'                Exit Function
'            End If


'            If RecType = "4" Then
'                VerifyCreditWorthiness = True
'                Exit Function
'            End If

'            Try
'                'Begin examination for credit worthiness
'                For xCount = 0 To cboCustID.Items.Count - 1
'                    If arrCustomers(xCount, 1).ToString = cboCustID.Text Then
'                        lblCustomerNameString.Text = arrCustomers(xCount, 0).ToString
'                        'Verify Credit Worthiness
'                        If arrCustomers(xCount, 3) = 1 Then
'                            VerifyCreditWorthiness = True

'                            '                            If arrCustomers(xCount, 4) = 2 Then
'                            '                                If RecType <> "2" Then
'                            '                                    'Get credit card information
'                            '                                    lblTerms.Visible = False
'                            '                                    grpCreditCard.Visible = True
'                            '                                    GetCreditCardInformation()
'                            '                                End If
'                            '                            ElseIf arrCustomers(xCount, 4) = 1 Then
'                            lblTerms.Visible = True
'                            grpCreditCard.Visible = False
'                            '                        End If

'                            Exit Function
'                        End If
'                    End If
'                Next

'            Catch exp As Exception
'                MsgBox(exp.ToString)

'            End Try

'            '//This is displayed if the field Cust_CrApproveRec is set to 0
'            MsgBox("The Customer Account is awaiting credit approval or has exceeded it's credit limit.  Call ext 235 for status on Credit.", MsgBoxStyle.OKOnly, "Credit Issue")
'            '//A new cstomer must be selected to continue
'            cboCustID.Focus()

'        End Function


'        Private Sub getCustomerAddressInformation()

'            cboCustID.DroppedDown = False
'            txtLocation.Visible = True

'            '//This will place the address of the customer in the form
'            Dim xCount As Integer = 0
'            Dim ycount As Integer = 0
'            Dim valCustID As String = Me.lblCustomerNameString.Text
'            Dim txtID, txtCustID, txtName, txtAdd1, txtAdd2, txtCity, txtZip, txtState, txtCountry, valMemo, txtLocName As String
'            Dim intState, intCountry As Long

'            'Get first wave of address
'            Dim txtAddLong As String

'            Dim tableTestLoc As New PSS.Data.Production.tlocation()

'            Dim dtLoc As DataTable

'            If RecType = "4" Then
'                dtLoc = tableTestLoc.GetRowByLocID(valLoc)
'            Else
'                dtLoc = tableTestLoc.GetRowsByCustomerID(valCust)
'            End If

'            For xCount = 0 To dtLoc.Rows.Count - 1

'            Next

'            If xCount > 1 Then

'                If DeviceType = "2" Then
'                    'POPULATE FORM frmCellLoc
'                    multiLoc = 0
'                    Dim xfrm As New frmCellLoc(valCustID)
'                    xfrm.ShowDialog()
'                End If

'                cboAddress.Items.Clear()

'                txtLocation.Visible = True
'                lblAddressVAL.Visible = False
'                cboAddress.Visible = True
'                '                cboAddress.Visible = False

'                'populate address choice list

'                Dim r As DataRow

'                For xCount = 0 To dtLoc.Rows.Count - 1
'                    r = dtLoc.Rows(xCount)

'                    txtID = r("Loc_ID")
'                    txtCustID = r("Cust_ID")
'                    txtLocName = r("Loc_Name")
'                    If IsDBNull(r("Loc_Name")) = False Then txtName = r("Loc_Name") & ": "
'                    If IsDBNull(r("Loc_Address1")) = False Then txtAdd1 = r("Loc_Address1") & ", "
'                    If IsDBNull(r("Loc_Address2")) = False Then txtAdd2 = r("Loc_Address2") & ", "
'                    If IsDBNull(r("Loc_City")) = False Then txtCity = r("Loc_City") & ", "
'                    If IsDBNull(r("State_ID")) = False Then txtState = GetStateName(r("State_ID")) & ", "
'                    If IsDBNull(r("Loc_Zip")) = False Then txtZip = r("Loc_Zip") & "   "
'                    If IsDBNull(r("Cntry_ID")) = False Then txtCountry = GetCountryName(r("Cntry_ID"))

'                    Dim strAddress As String
'                    strAddress = ""

'                    strAddress = String.Concat(txtName, txtAdd1, txtAdd2, txtCity, txtState, txtZip, txtCountry)

'                    '                    If Len(txtName) > 0 Then strAddress += txtName & ": "
'                    '                   If Len(txtAdd1) > 0 Then strAddress += txtAdd1 & ", "
'                    '                  If Len(txtAdd2) > 0 Then strAddress += txtAdd2 & ", "
'                    '                 If Len(txtCity) > 0 Then strAddress += txtCity & ", "
'                    '                If Len(txtState) > 0 Then strAddress += txtState & ", "
'                    '               If Len(txtZip) > 0 Then strAddress += txtZip & ", "
'                    '              If Len(txtCountry) > 0 Then strAddress += txtCountry

'                    If Len(strAddress) > 0 Then
'                        cboAddress.Items.Add(strAddress)
'                        arrLocations(xCount, 1) = txtAddLong
'                        arrLocations(xCount, 0) = txtID
'                        arrLocations(xCount, 2) = txtCustID
'                        arrLocations(xCount, 3) = txtLocName
'                    End If
'                Next

'                'cboAddress.Focus()
'                txtLocation.Focus()
'                '                cboAddress.DroppedDown = True

'                cboAddress.Enabled = False

'                '********************************************
'                '********************************************
'                '********************************************
'                '********************************************
'                'reset customer id here
'                '********************************************
'                '********************************************
'                '********************************************
'                '********************************************

'                If DeviceType = "2" Then
'                    If Len(multiLoc) > 1 Then
'                        txtLocation.Text = multiLoc

'                        If Len(txtLocation.Text) < 1 Then
'                            'cboAddress.Text = ""
'                            Me.cboCustID.Focus()
'                            Exit Sub
'                        End If

'                        Dim xVal As Integer

'                        For xCount = 0 To UBound(arrLocations)

'                            xVal = InStr(arrLocations(xCount, 3), txtLocation.Text, CompareMethod.Text)
'                            If xVal = 1 Then
'                                cboAddress.SelectedIndex = xCount
'                                cboAddress.DroppedDown = False
'                                Exit For
'                            End If

'                        Next
'                    End If
'                End If







'            Else

'                lblAddressVAL.Visible = True
'                cboAddress.Visible = False
'                txtLocation.Visible = False

'                Dim rSingle As DataRow

'                For xCount = 0 To dtLoc.Rows.Count - 1

'                    rSingle = dtLoc.Rows(xCount)
'                    'populate single record data into form

'                    If Not IsDBNull(rSingle("Loc_ID")) Then
'                        arrLocations(xCount, 0) = rSingle("Loc_ID")
'                    End If
'                    'Get data for address
'                    Dim locID As Integer = rSingle("Loc_ID")
'                    If Not IsDBNull(rSingle("Loc_Address1")) Then
'                        txtAdd1 = rSingle("Loc_Address1")
'                    End If
'                    If Not IsDBNull(rSingle("Loc_Address2")) Then
'                        txtAdd2 = rSingle("Loc_Address2")
'                    End If
'                    If Not IsDBNull(rSingle("Loc_City")) Then
'                        txtCity = rSingle("Loc_City")
'                    End If
'                    If Not IsDBNull(rSingle("Loc_Zip")) Then
'                        txtZip = rSingle("Loc_Zip")
'                    End If
'                    If Not IsDBNull(rSingle("State_ID")) Then
'                        intState = rSingle("State_ID")
'                    End If
'                    If Not IsDBNull(rSingle("Cntry_ID")) Then
'                        intCountry = rSingle("Cntry_ID")
'                    End If

'                    valMemo = ""
'                    If IsDBNull(rSingle("Loc_Memo")) = False Then
'                        valMemo = rSingle("Loc_Memo")
'                    End If

'                    '//This section will convert the State ID over to the Start Short Name
'                    If intState > 0 Then
'                        'Get State Name for Address
'                        Dim tblState As New PSS.Data.Production.lstate()
'                        Dim dsState As DataSet = tblState.GetData
'                        Dim rState As DataRow
'                        For ycount = 0 To dsState.Tables("lstate").Rows.Count - 1
'                            rState = dsState.Tables("lstate").Rows(ycount)
'                            If rState("State_ID") = intState Then
'                                txtState = rState("State_Short")
'                                Exit For
'                            End If
'                        Next
'                        dsstate.dispose()
'                        dsState = Nothing
'                        tblState = Nothing
'                    End If

'                    '//This section will convert the Country ID over to the Country Name
'                    If intCountry > 0 Then
'                        'Get State Name for Address
'                        Dim tblCountry As New PSS.Data.Production.lcountry()
'                        Dim dsCountry As DataSet = tblCountry.GetData
'                        Dim rCountry As DataRow
'                        For ycount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
'                            rCountry = dsCountry.Tables("lcountry").Rows(ycount)
'                            If rCountry("Cntry_ID") = intCountry Then
'                                txtCountry = rCountry("Cntry_Name")
'                                Exit For
'                            End If
'                        Next
'                        dscountry.dispose()
'                        dsCountry = Nothing
'                        tblCountry = Nothing
'                    End If

'                    'Make the string for combobox

'                    '//Concactenate the string for address information
'                    '//Testing to see if any fields are null before concactenating
'                    If Len(txtAdd1) > 0 Then txtAddLong += txtAdd1
'                    If Len(txtAdd2) > 0 Then txtAddLong += ", " & txtAdd2
'                    If Len(txtCity) > 0 Then txtAddLong += ", " & txtCity
'                    If Len(txtState) > 0 Then txtAddLong += ", " & txtState
'                    If Len(txtZip) > 0 Then txtAddLong += ", " & txtZip
'                    If Len(txtCountry) > 0 Then txtAddLong += ", " & txtCountry
'                    lblAddressVAL.Text = txtAddLong

'                    lblAddressID.Text = locID

'                    '//Get the memo field if not null
'                    If Not IsDBNull(valMemo) Then
'                        txtMemo.Text = valMemo
'                    End If
'                    arrLocations(xCount, 1) = txtAddLong

'                Next


'            End If


'            '            Dim tblLoc As New PSS.Data.Production.tlocation()
'            '            Dim dsLocat As DataSet = tblLoc.GetData


'            '           '            Dim tblLoc As New PSS.Data.Production.tlocation()
'            '           Dim dsLoca As DataTable = tblLoc.GetRowsByCustomerID(valCustID)
'            '           Dim r As DataRow
'            '           For xCount = 0 To dsLoca.Rows.Count - 1
'            '               xCount += 1
'            '           Next

'            '           If xCount > 1 Then
'            '               'Populate combo box of addresses
'            '               For xCount = 0 To dsLoca.Rows.Count - 1

'            '                   If Not IsDBNull(r("Loc_ID")) Then
'            '                       arrLocations(xCount, 0) = r("Loc_ID")
'            '                   End If
'            '                   'Get data for address
'            '                   If Not IsDBNull(r("Loc_Address1")) Then
'            '                       txtAdd1 = r("Loc_Address1")
'            '                   End If
'            '                   If Not IsDBNull(r("Loc_Address2")) Then
'            '                       txtAdd2 = r("Loc_Address2")
'            '                   End If
'            '                   If Not IsDBNull(r("Loc_City")) Then
'            '                       txtCity = r("Loc_City")
'            '                   End If
'            '                   If Not IsDBNull(r("Loc_Zip")) Then
'            '                       txtZip = r("Loc_Zip")
'            '                   End If
'            '                   If Not IsDBNull(r("State_ID")) Then
'            '                       intState = r("State_ID")
'            '                   End If
'            '                  If Not IsDBNull(r("Cntry_ID")) Then
'            '                      intCountry = r("Cntry_ID")
'            '                  End If

'            '                 '//This section will convert the State ID over to the Start Short Name
'            '                  If intState > 0 Then
'            '                      'Get State Name for Address
'            '                     Dim tblState As New PSS.Data.Production.lstate()
'            '                     Dim dsState As DataSet = tblState.GetData
'            '                     Dim rState As DataRow
'            '                     For ycount = 0 To dsState.Tables("lstate").Rows.Count - 1
'            '                         rState = dsState.Tables("lstate").Rows(ycount)
'            '                         If rState("State_ID") = intState Then
'            '                             txtState = rState("State_Short")
'            '                             Exit For
'            '                         End If
'            '                     Next
'            '                     dsState = Nothing
'            '                     tblState = Nothing
'            '                 End If

'            '                 '//This section will convert the Country ID over to the Country Name
'            '                 If intCountry > 0 Then
'            '                     'Get State Name for Address
'            '                     Dim tblCountry As New PSS.Data.Production.lcountry()
'            '                     Dim dsCountry As DataSet = tblCountry.GetData
'            '                     Dim rCountry As DataRow
'            '                     For ycount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
'            '                         rCountry = dsCountry.Tables("lcountry").Rows(ycount)
'            '                         If rCountry("Cntry_ID") = intCountry Then
'            '                             txtCountry = rCountry("Cntry_Name")
'            '                             Exit For
'            '                         End If
'            '                     Next
'            '                     dsCountry = Nothing
'            '                     tblCountry = Nothing
'            '                 End If

'            '                 'Make the string for combobox

'            '                    '//Concactenate the string for address information
'            '                    '//Testing to see if any fields are null before concactenating
'            '                    If Len(txtAdd1) > 0 Then txtAddLong += txtAdd1
'            '                    If Len(txtAdd2) > 0 Then txtAddLong += ", " & txtAdd2
'            '                    If Len(txtCity) > 0 Then txtAddLong += ", " & txtCity
'            '                    If Len(txtState) > 0 Then txtAddLong += ", " & txtState
'            '                    If Len(txtZip) > 0 Then txtAddLong += ", " & txtZip
'            '                    If Len(txtCountry) > 0 Then txtAddLong += ", " & txtCountry
'            '                    cboAddress.Items.Add(txtAddLong)
'            '                   arrLocations(xCount, 1) = txtAddLong
'            '               Next

'            '           Else


'            '            End If

'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************
'            '********************************************************************

'            Exit Sub

'            Dim tblLocation As New PSS.Data.Production.tlocation()
'            Dim dsLoc As DataSet = tblLocation.GetData
'            Dim rLoc As DataRow

'            For xCount = 0 To dsLoc.Tables("tlocation").Rows.Count - 1
'                rLoc = dsLoc.Tables("tlocation").Rows(xCount)
'                If rLoc("Cust_ID") = CInt(valCustID) Then

'                    If Not IsDBNull(rLoc("Loc_ID")) Then
'                        lblAddressID.Text = rLoc("Loc_ID")
'                    End If
'                    'Get data for address
'                    If Not IsDBNull(rLoc("Loc_Address1")) Then
'                        txtAdd1 = rLoc("Loc_Address1")
'                    End If
'                    If Not IsDBNull(rLoc("Loc_Address2")) Then
'                        txtAdd2 = rLoc("Loc_Address2")
'                    End If
'                    If Not IsDBNull(rLoc("Loc_City")) Then
'                        txtCity = rLoc("Loc_City")
'                    End If
'                    If Not IsDBNull(rLoc("Loc_Zip")) Then
'                        txtZip = rLoc("Loc_Zip")
'                    End If
'                    If Not IsDBNull(rLoc("State_ID")) Then
'                        intState = rLoc("State_ID")
'                    End If
'                    If Not IsDBNull(rLoc("Cntry_ID")) Then
'                        intCountry = rLoc("Cntry_ID")
'                    End If

'                    If RecType = "3" Then
'                        grpMemo.Visible = True
'                        If Not IsDBNull(rLoc("Loc_Memo")) Then
'                            valMemo = rLoc("Loc_Memo")
'                        End If
'                    End If

'                    Exit For
'                End If
'            Next

'            dsLoc.Dispose()
'            dsLoc = Nothing
'            tblLocation = Nothing

'            '//This section will convert the State ID over to the Start Short Name
'            If intState > 0 Then
'                'Get State Name for Address
'                Dim tblState As New PSS.Data.Production.lstate()
'                Dim dsState As DataSet = tblState.GetData
'                Dim rState As DataRow
'                For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
'                    rState = dsState.Tables("lstate").Rows(xCount)
'                    If rState("State_ID") = intState Then
'                        txtState = rState("State_Short")
'                        Exit For
'                    End If
'                Next
'                dsstate.dispose()
'                dsState = Nothing
'                tblState = Nothing
'            End If

'            '//This section will convert the Country ID over to the Country Name
'            If intCountry > 0 Then
'                'Get State Name for Address
'                Dim tblCountry As New PSS.Data.Production.lcountry()
'                Dim dsCountry As DataSet = tblCountry.GetData
'                Dim rCountry As DataRow
'                For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
'                    rCountry = dsCountry.Tables("lcountry").Rows(xCount)
'                    If rCountry("Cntry_ID") = intCountry Then
'                        txtCountry = rCountry("Cntry_Name")
'                        Exit For
'                    End If
'                Next
'                dscountry.dispose()
'                dsCountry = Nothing
'                tblCountry = Nothing
'            End If

'            '//Concactenate the string for address information
'            '//Testing to see if any fields are null before concactenating
'            '            Dim txtAddLong As String = ""
'            If Len(txtAdd1) > 0 Then txtAddLong += txtAdd1
'            If Len(txtAdd2) > 0 Then txtAddLong += ", " & txtAdd2
'            If Len(txtCity) > 0 Then txtAddLong += ", " & txtCity
'            If Len(txtState) > 0 Then txtAddLong += ", " & txtState
'            If Len(txtZip) > 0 Then txtAddLong += ", " & txtZip
'            If Len(txtCountry) > 0 Then txtAddLong += ", " & txtCountry
'            lblAddressVAL.Text = txtAddLong

'            '//Get the memo field if not null
'            If Not IsDBNull(valMemo) Then
'                txtMemo.Text = valMemo
'            End If

'            dtLoc.Dispose()
'            dtLoc = Nothing

'        End Sub

'        Private Sub GetCreditCardInformation()

'            '//This will place the credit card information of the customer in the form
'            '//Used for End User
'            Dim xCount As Integer = 0
'            Dim CCtype, arrccUB As Integer
'            Dim CCtypeName As String
'            Dim tblCreditCard As New PSS.Data.Production.Joins()
'            Dim dtCC As DataTable = tblCreditCard.GenericSelect("Select * FROM tcreditcard Where Cust_ID = " & valCust)
'            Dim rCC As DataRow = dtCC.Rows(0)

'            'GetData from tcreditcard
'            txtCCNumber.Text = rCC("CreditCard_Num")
'            txtExpDate.Text = rCC("CreditCard_ExpDate")
'            CCtype = rCC("CCardType_ID")

'            'Get Credit Card Type Description
'            arrccUB = UBound(arrCCType, 1)

'            For xCount = 0 To arrccUB
'                If arrCCType(xCount, 0) = CCtype Then
'                    cboCCType.Text = arrCCType(xCount, 1)
'                End If
'            Next

'            dtCC.Dispose()
'            dtCC = Nothing
'            tblCreditCard = Nothing

'        End Sub

'        Private Sub cboCustomerReason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCR.SelectedIndexChanged

'            Dim customerreasonVal As Long = GetCustomerReasonID()
'            lblCustomerReasonNameString.Text = customerreasonVal

'        End Sub

'        Private Sub determineWorkOrder()

'            txtWorkOrder.Text = UCase(txtWorkOrder.Text)
'            If Len(valPO) > 0 Then
'                If Trim(txtWorkOrder.Text) <> Trim(POCustWO) Then
'                    VALworkorder = Nothing
'                End If
'            End If

'            If Len(Trim(txtWorkOrder.Text)) < 1 Then
'                MsgBox("Please enter a workorder value.", MsgBoxStyle.OKOnly, "Enter Workorder")
'                txtWorkOrder.Focus()
'                Exit Sub
'            End If
'            If cboCustID.Enabled = True Then

'                If VALworkorder < 1 Then
'                    VALworkorder = WorkOrderExists(txtWorkOrder.Text)
'                End If

'                If VALworkorder > 0 Then
'                    Dim valAppend As String
'                    valAppend = MsgBox("The Workorder: " & txtWorkOrder.Text & " already exists. Do you want to append records to this workorder?", MsgBoxStyle.YesNo, "Append Records")
'                    Select Case valAppend
'                        Case 6  'vbYes
'                            '//Just continue as normal - presume a new table must be created
'                            '//Get the Manufacturer and Model
'                        Case 7  'vbNo
'                            MsgBox("You have decided not to append devices to this workorder. Please input a new workorder number.", MsgBoxStyle.OKOnly, "No Append")
'                            txtWorkOrder.Text = ""
'                            txtWorkOrder.Focus()
'                    End Select
'                End If
'            End If

'        End Sub



'        Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown

'            If e.KeyValue = 13 Then

'                If RecType = "5" Then
'                    Dim xCount As Integer
'                    Dim r As DataRow
'                    Dim tGetVal As New PSS.Data.Production.tstagedetail()
'                    Dim dtGetVals As DataTable = tGetVal.GetDeviceBySerial(Trim(txtDeviceSN.Text))
'                    For xcount = 0 To dtGetVals.Rows.Count - 1
'                        r = dtGetVals.Rows(xcount)
'                        valLoc = r("StageD_LocID")
'                        lblAddressID.Text = valLoc
'                        valCust = r("StageD_CustID")
'                        VALworkorder = r("StageD_WOID")
'                    Next

'                End If

'                If RecType <> "5" Then
'                    If Len(Trim(txtWorkOrder.Text)) < 1 Then
'                        determineWorkOrder()
'                        txtDeviceSN.Text = ""
'                        Exit Sub
'                    End If
'                End If

'                If RecType <> "5" Then
'                    If cboAddress.Text = "" And lblAddressVAL.Text = "" Then
'                        txtLocation.Focus()
'                        txtLocation.Text = ""
'                        Exit Sub
'                    End If
'                End If

'                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'                lockControls()

'                txtDeviceSN.Text = UCase(txtDeviceSN.Text) '//Uppercase value (standardize)

'                VALverify = verifyPagerSNlength(txtDeviceSN.Text) '//length must be 15 chars or less
'                If VALverify = False Then
'                    'Throw error
'                    MsgBox("The Device Serial Number is of a size not allowed. Please re-enter.")
'                    txtDeviceSN.Focus()
'                    Exit Sub
'                End If


'                '//NEW - Reconciliation on Receiving - START
'                If valReconcile = 1 Then
'                    'This customer must have match in database
'                    valReconcileID = 0
'                    Dim rRec As DataRow
'                    Dim xCount As Integer = 0
'                    Dim blnReconcile As Boolean = False
'                    For xCount = 0 To dtReconcile.Rows.Count - 1
'                        rRec = dtReconcile.Rows(xcount)
'                        If Trim(valCust) = Trim(rRec("rec_cust")) Then
'                            If Trim(UCase(txtWorkOrder.Text)) = Trim(UCase(rRec("rec_wo"))) Then
'                                If Trim(rRec("rec_serial")) = Trim(txtDeviceSN.Text) Then
'                                    blnReconcile = True
'                                    valReconcileID = rRec("rec_id")
'                                    Exit For
'                                End If
'                            End If
'                        End If
'                    Next
'                    For xCount = 0 To dtReconcile.Rows.Count - 1
'                        rRec = dtReconcile.Rows(xcount)
'                        If Trim(valCust) = Trim(rRec("rec_cust")) Then
'                            If Trim(txtWorkOrder.Text) = Trim(rRec("rec_wo")) Then
'                                If Trim(rRec("rec_cap")) = Trim(txtDeviceSN.Text) Then
'                                    blnReconcile = True
'                                    valReconcileID = rRec("rec_id")
'                                    Exit For
'                                End If
'                            End If
'                        End If
'                    Next

'                    If blnReconcile = False Then
'                        MsgBox("This item is not designated by its owner as a valid serial number type. It can not be received until corrected.", MsgBoxStyle.OKOnly, "ERROR")
'                        txtDeviceSN.Text = ""
'                        txtDeviceSN.Focus()
'                        Exit Sub
'                    End If

'                End If
'                '//NEW - Reconciliation on Receiving - END



'                'MsgBox(VALworkorder)
'                If RecType <> "5" Then

'                    If VALworkorder < 1 Then 'if PO then VALworkorder is already assigned
'                        VALworkorder = WorkOrderExists(txtWorkOrder.Text)
'                        If VALworkorder = 0 Then
'                            'Create a new workorder
'                            MainWin.StatusBar.SetStatusText("Inserting WorkOrder")
'                            VALworkorder = InsertWorkOrder()
'                            If VALworkorder = 0 Then
'                                'Throw error
'                                MsgBox("The system could not enter the new workorder.")
'                                Cursor.Current = System.Windows.Forms.Cursors.Default
'                                MainWin.StatusBar.SetStatusText("")
'                                Exit Sub
'                            End If
'                        End If
'                    End If

'                End If

'                If RecType = "5" Then
'                    '//verify serial number
'                    Dim dtStage As New PSS.Data.Production.tstagedetail()
'                    Dim rsStage As DataTable = dtStage.GetDeviceBySerialLoc(txtDeviceSN.Text, valLoc)

'                    If rsStage.Rows.Count < 1 Then
'                        MsgBox("Device has not been received for this location.", MsgBoxStyle.OKOnly, "ERROR")
'                        txtDeviceSN.Focus()
'                        Exit Sub
'                    End If
'                End If

'                valShipTo = 0  '//New July 11, 2003

'                If Len(lblTrayVAL.Text) < 1 Then
'                    'If valStage = 0 Then
'                    'Insert Tray
'                    MainWin.StatusBar.SetStatusText("Inserting Tray")
'                    '*******************TEST CDH
'                    VALtray = InsertTray(VALworkorder)
'                    '*******************TEST CDH
'                    dataGrid = CreateGridDT()
'                    MainGrid.DataSource = dataGrid
'                    'Else
'                    'VALtray = 0
'                    'If CInt(lblCountVAL1.Text) < 1 Then
'                    'dataGrid = CreateGridDT()
'                    'MainGrid.DataSource = dataGrid
'                    'End If
'                    'End If
'                End If
'                MainGrid.Refresh()

'                Dim blnVerify As Boolean
'                blnVerify = verifyDuplicateDevice(txtDeviceSN.Text, VALworkorder)
'                If blnVerify = False Then
'                    blnVerify = GetNewDeviceSNDuplicate()
'                    If blnVerify = False Then
'                        Cursor.Current = System.Windows.Forms.Cursors.Default
'                        MainWin.StatusBar.SetStatusText("")
'                        Exit Sub
'                    End If
'                End If

'                MainGrid.MoveLast()

'                If DeviceType = "1" Then
'                    'BEGIN//This next section is performed only for pagers **************************************
'                    'Add Device to tdevice

'                    If RecType = "4" Then
'                        If POwrty = "FIRM" Then GoTo PSSwrtyFIRM
'                        If POwrty = "COAMPLUS" Then GoTo PSSwrtyCOAMPLUS
'                    End If

'                    If RecType = "1" Then
'PSSwrtyFIRM:
'                        If VALmanufacturer = 1 Then
'                            MainWin.StatusBar.SetStatusText("Checking for Manufacturer Warranty")
'                            '//Check for motorola warranty

'                            '//This has been commented out because Motorola warranty should not be checked for group receiving
'                            '//Craig Haney February 4, 2004
'                            'Dim motoWrty As String
'                            'motoWrty = checkMotorolaWrty()
'                            'If motoWrty = "S" Then
'                            'VALwrty = "S"
'                            'Else
'                            VALwrty = ""
'                            'End If
'                            '//Craig Haney February 4, 2004
'                            '//End of commented section

'                        End If
'                    Else
'                        '//Diana puts in the value manually if COAM
'PSSwrtyCOAMPLUS:
'                        If RecType <> "5" Then
'                            VALwrty = InputBox("Please enter the OEM Warranty Status for this device: ", "OEM Warranty", )
'                            VALwrty = UCase(VALwrty)
'                            If VALwrty <> "S" And VALwrty <> "E" Or Len(VALwrty) < 1 Then
'                                VALwrty = ""
'                            End If
'                        End If

'                    End If

'                    '//PSS Warranty secition here
'                    Dim valDBR As Boolean = False
'                    Dim BillDeviceID As Int32
'                    Dim xCount As Integer = 0
'                    Dim pssDate As Date

'                    PopulatePSSwrtyFields(lblCustomerNameString.Text)
'                    Dim wrtyDays As Integer = -1 * CustPSSwrtyDaysInWrty
'                    pssDate = DateAdd(DateInterval.Day, wrtyDays, Now)

'                    Dim pssDateMonth As String
'                    Dim pssDateDay As String
'                    Dim pssDateYear As String
'                    Dim pssNewDate As String

'                    pssNewDate = DatePart(DateInterval.Year, pssDate) & "-" & DatePart(DateInterval.Month, pssDate) & "-" & DatePart(DateInterval.Day, pssDate)

'                    PSSwarranty = False

'                    MainWin.StatusBar.SetStatusText("Determining PSS Warranty")
'                    Try
'                        'If CustPSSwrtyParts = 1 And CustPSSwrtyLabor = 1 Then
'                        'Do not check for PSS Warranty - it does not apply
'                        'Else
'                        If valLoc = 0 Then
'                            If RecType <> "5" Then
'                                valLoc = lblAddressID.Text
'                                System.Windows.Forms.Application.DoEvents()
'                            End If

'                        End If



'                        Dim dtPSSwrty As DataTable
'                        '//This is new code June 4th 2003
'                        '//In this segment change the valLoc value to that of the parent company if rec type is end user
'                        If RecType = "3" Then
'                            dtPSSwrty = PSS.Data.Production.Joins.chkPSSwrtyEndUser(txtDeviceSN.Text, pssNewDate)
'                        End If
'                        '//End of new code June 4th 2003
'                        If RecType <> "3" Then
'                            If valCust = 1 Then
'                                dtPSSwrty = PSS.Data.Production.Joins.chkPSSwrtyMotorola(txtDeviceSN.Text, pssNewDate)
'                            Else
'                                dtPSSwrty = PSS.Data.Production.Joins.chkPSSwrty(txtDeviceSN.Text, valLoc, pssNewDate)
'                            End If
'                        End If

'                        Dim r As DataRow
'                        If dtPSSwrty.Rows(0)("repeat") <> False Then
'                            PSSwarranty = True

'                            For xCount = 0 To dtPSSwrty.Rows.Count - 1
'                                BillDeviceID = dtPSSwrty.Rows(0)("repeat")
'                                'Dim tblPSSwrtyBILL As New PSS.Data.Production.Joins()
'                                Dim dtPSSbill As DataTable = PSS.Data.Production.Joins.chkPSSwrtyBILL(BillDeviceID)

'                                If dtPSSbill.Rows.Count > 0 Then
'                                    PSSwarranty = False
'                                    valDBR = True
'                                    If RecType <> "2" Then
'                                        valDBR = True
'                                    Else
'                                        valDBR = True
'                                        PSSwarranty = False
'                                    End If
'                                    GoTo EndPSSwrty
'                                Else
'                                    PSSwarranty = True
'                                    valDBR = False
'                                End If

'                            Next

'                        Else
'                            'No previous record of device here
'                            'continue as normal
'                        End If

'                        'End If
'                    Catch exp As Exception
'                        'MsgBox(exp.ToString)
'                        PSSwarranty = False 'Can not be true there is no days in warranty range
'                    End Try

'                    '//Set if under PSS Warranty then do not display OEM warranty
'                    If PSSwarranty = True Then
'                        '//This is new September 11, 2003
'                        If VALwrty = "E" Then
'                            'Craig Haney 3-4-2004
'                            'PSSwarranty = False
'                            VALwrty = ""
'                            'Craig Haney 3-4-2004
'                        Else
'                            VALwrty = ""
'                        End If
'                        '//This is new September 11, 2003-END
'                        'VALwrty = "" 'Uncomment this is new code above is removed.
'                    End If

'EndPSSwrty:

'                    '//TEST This is new code to determine whether the same serial number
'                    'has been loaded on the same date
'                    Dim valDate As Date = Now
'                    Dim vMnth, vDay, vYear As String
'                    vMnth = DatePart(DateInterval.Month, valDate)
'                    vDay = DatePart(DateInterval.Day, valDate)
'                    If Len(vDay) < 2 Then vDay = "0" & vDay
'                    If Len(vMnth) < 2 Then vMnth = "0" & vMnth
'                    vYear = DatePart(DateInterval.Year, valDate)
'                    Dim valSubDate As String = vYear & "-" & vMnth & "-" & vDay

'                    Dim tstSameSN As DataTable
'                    tstSameSN = PSS.Data.Production.Joins.chkSameSNsameDay(txtDeviceSN.Text, valSubDate)
'                    If tstSameSN.Rows.Count > 0 Then
'                        '//Place msgbox here
'                        Dim tstR As DataRow
'                        Dim tstX As Integer = 0
'                        Dim tstResponse As String

'                        For tstX = 0 To tstSameSN.Rows.Count - 1
'                            tstR = tstSameSN.Rows(tstX)
'                            tstResponse = MsgBox("This device: " & txtDeviceSN.Text & " is already being used in workorder: " & tstR("WO_ID") & ". Do you want to continue to insert this device into this tray?", MsgBoxStyle.YesNo, "Decision")
'                            Select Case tstResponse
'                                Case vbYes
'                                    Exit For
'                                Case vbNo
'                                    txtDeviceSN.Text = ""
'                                    txtDeviceSN.Focus()
'                                    Exit Sub
'                            End Select
'                        Next
'                    End If
'                    '//END TEST

'                    tstSameSN.Dispose()
'                    tstSameSN = Nothing

'                    MainWin.StatusBar.SetStatusText("Inserting Device")
'                    VALdevice = InsertDevice()
'                    If VALdevice = 0 Then
'                        'Throw error
'                        MsgBox("The device could not be added to the system.")
'                        Cursor.Current = System.Windows.Forms.Cursors.Default
'                        MainWin.StatusBar.SetStatusText("")
'                        Exit Sub
'                    End If

'                    refreshTDBgrid()

'                    'Increment counter on page by 1
'                    intCounter += 1
'                    Me.lblCountVAL.Text = intCounter
'                    Me.lblCountVAL1.Text = intCounter

'                    'Clear the value from Device SN
'                    Me.txtDeviceSN.Text = ""
'                    Me.txtDeviceSN.Focus()
'                    Cursor.Current = System.Windows.Forms.Cursors.Default
'                    MainWin.StatusBar.SetStatusText("")
'                    Exit Sub
'                    'END//This next section is performed only for pagers ****************************************
'                End If

'                If DeviceType = "2" Then
'                    'BEGIN//This next section is only for cellular items ****************************************

'                    coDeviceSN = 0
'                    coDeviceSN = txtDeviceSN.Text

'                    Dim frmCellDevice As New frmCellDeviceInfo()

'                    Dim frmMoto As New frmMOTORL_CellDeviceInfo()

'                    frmMoto.ManufIDint = CInt(lblManufacturerNameString.Text)
'                    frmMoto.txtCustomerName.Text = cboCustID.Text
'                    frmMoto.txtModel.Text = cboModID.Text
'                    frmMoto.deviceSN = txtDeviceSN.Text
'                    frmMoto.ModelID = lblModelNameString.Text
'                    frmMoto.woCustWO = txtWorkOrder.Text

'                    waitStateVAL = 0
'                    If cboManufID.Text = "Nokia" Then
'                        frmMoto.ManufName = "Nokia"
'                        frmMoto.ManufFlag = "N"
'                        frmMoto.HideInitElements()
'                        frmMoto.ShowDialog()
'                        Do Until waitStateVAL > 0
'                        Loop
'                    ElseIf cboManufID.Text = "Motorola" Then
'                        frmMoto.ManufName = "Motorola"
'                        frmMoto.ManufFlag = "M"
'                        frmMoto.HideInitElements()
'                        frmMoto.ShowDialog()
'                        Do Until waitStateVAL > 0
'                        Loop
'                    ElseIf cboManufID.Text = "Sony/Ericsson" Then
'                        frmMoto.ManufName = "Sony/Ericsson"
'                        frmMoto.ManufFlag = "S"
'                        frmMoto.HideInitElements()
'                        frmMoto.ShowDialog()
'                        Do Until waitStateVAL > 0
'                        Loop
'                    Else
'                        frmMoto.ManufName = "Generic"
'                        frmMoto.ManufFlag = ""
'                        frmMoto.HideInitElements()
'                        frmMoto.ShowDialog()
'                        Do Until waitStateVAL > 0
'                        Loop
'                    End If

'                    'Craig Haney
'                    frmMoto.Dispose()
'                    frmMoto = Nothing
'                    'Craig Haney

'                    '//Values have been acquired

'                    If waitStateVAL = 2 Then
'                        If Len(Trim(vcCourierTrackIN)) < 1 Or Len(Trim(vcAirCarrCode)) < 1 Or Len(Trim(vcTransactionCode)) < 1 Or Len(Trim(vcAPCcode)) < 1 Or Len(Trim(vcTranceiverCode)) < 1 Then
'                            Dim vResponse As String = MsgBox("you have not included the correct data for this entry. This entry will be canceled.", MsgBoxStyle.OKOnly, "ERROR")
'                            txtDeviceSN.Focus()
'                            txtDeviceSN.Text = ""
'                        End If
'                        'MsgBox("Insert cancelled because options sheet not defined.", MsgBoxStyle.OKOnly, "ERROR")
'                        'txtDeviceSN.Text = ""
'                        'txtDeviceSN.Focus()
'                        'Exit Sub
'                    End If

'                    '//Pass Values to Form

'                    '                    InsertDeviceCellular()
'                    InsertDevice()

'                    'Add data to grid

'                    refreshTDBgrid()

'                    'Increment counter on page by 1
'                    intCounter += 1
'                    Me.lblCountVAL.Text = intCounter
'                    Me.lblCountVAL1.Text = intCounter

'                    'Clear the value from Device SN
'                    Me.txtDeviceSN.Text = ""
'                    Me.txtDeviceSN.Focus()
'                    Cursor.Current = System.Windows.Forms.Cursors.Default
'                    Exit Sub
'                    'END//This next section is only for cellular items ******************************************
'                End If
'            End If


'            MainWin.StatusBar.SetStatusText("")

'        End Sub

'        Private Function verifyPagerSNlength(ByVal valPagerSN As String) As Boolean

'            If Len(Trim(valPagerSN)) > 15 Or Len(Trim(valPagerSN)) < 1 Then
'                verifyPagerSNlength = False
'            Else
'                verifyPagerSNlength = True
'            End If

'        End Function

'        Private Function WorkOrderExists(ByVal valWorkOrder As String) As Int32

'            WorkOrderExists = 0

'            Dim xCount As Integer = 0
'            Dim tblJoin As New PSS.Data.Production.Joins()
'            Dim dtWO As DataTable = tblJoin.WOIDListByCustID(CInt(lblCustomerNameString.Text), txtWorkOrder.Text)
'            Dim r As DataRow

'            For xCount = 0 To dtWO.Rows.Count - 1
'                r = dtWO.Rows(xCount)
'                If r("WO_CustWO") = valWorkOrder Then
'                    If r("Loc_ID") = CInt(lblAddressID.Text) Then
'                        WorkOrderExists = r("WO_ID")
'                        Exit For
'                    End If
'                End If
'            Next

'            dtWO.Dispose()
'            dtWO = Nothing
'            tblJoin = Nothing

'        End Function

'        Private Function InsertWorkOrder() As Int32

'            InsertWorkOrder = 0

'            Dim vWrty As String
'            Try
'                If cboWrty.Text = "No Warranty" Then
'                    vWrty = "E"
'                ElseIf cboWrty.Text = "90 Days" Then
'                    vWrty = "U"
'                ElseIf cboWrty.Text = "1 Year" Then
'                    vWrty = "J"
'                Else
'                    vWrty = "E"
'                End If
'            Catch ex As Exception
'                vWrty = "E"
'            End Try

'            Dim newDate As String = FormatDate(Now)
'            Dim valMemo As String = ",'" & txtWorkOrderMemo.Text & "'"
'            Dim lblMemo As String = ", WO_Memo"

'            If Len(txtWorkOrderMemo.Text) < 1 Then lblMemo = ""
'            If Len(txtWorkOrderMemo.Text) < 1 Then valMemo = ""

'            'Dim strPO As String = ", " & valPO
'            Dim strPO As String = valPO
'            Dim lblPO As String = ", PO_ID"
'            If valPO < 1 Then strPO = "Null"
'            If valPO < 1 Then lblPO = ""


'            '/Craig Haney
'            '/Enter and input box to get the date dock value
'            Dim vDateDock As String
'DockDate:
'            vDateDock = InputBox("Enter the doc date for this RMA.", "Doc Date")
'            If IsDate(vDateDock) = True Then
'                '/Continue as normal
'                '/Convert to value for MySQL
'                vDateDock = PSS.Gui.Receiving.General.FormatDateShort(vDateDock)
'            Else
'                GoTo dockdate
'            End If
'            '/Craig Haney

'            Dim strShipTo As String = valShipTo

'            Try
'                If Len(Trim(valShipTo)) < 1 Then strShipTo = "Null"
'                If valShipTo < 1 Then strShipTo = "Null"
'            Catch exp As Exception
'                strShipTo = "Null"
'            End Try

'            Dim strSQL As String

'            If DeviceType = "1" Then
'                strSQL = "Insert into tworkorder (" & _
'                " WO_CustWO, WO_Date" & lblMemo & ", Loc_ID, Prod_ID, PO_ID, ShipTo_ID, WO_ExpCode) VALUES ('" & _
'                txtWorkOrder.Text & "', '" & _
'                newDate & "'" & _
'                valMemo & ", " & _
'                lblAddressID.Text & ", " & _
'                "1, " & _
'                strPO & ", " & _
'                strShipTo & ", '" & _
'                vWrty & "')"
'            ElseIf DeviceType = "2" Then
'                If Trim(Len(lblCustomerReasonNameString.Text)) < 1 Then lblCustomerReasonNameString.Text = 0
'                strSQL = "Insert into tworkorder (" & _
'                " WO_CustWO, WO_Date" & lblMemo & ", Loc_ID, Prod_ID, PO_ID, ShipTo_ID, Comp_ID, WO_Quantity, WO_PRL, WO_IP, WO_DateDock, WO_Discrepancy, WO_RAQnty, WO_ExpCode) VALUES ('" & _
'                txtWorkOrder.Text & "', '" & _
'                newDate & "'" & _
'                valMemo & ", " & _
'                lblAddressID.Text & ", " & _
'                "2, " & _
'                strPO & ", " & _
'                strShipTo & ", " & _
'                lblCustomerReasonNameString.Text & ", '" & _
'                txtQuantity.Text & "', '" & _
'                txtPRL.Text & "', '" & _
'                txtIP.Text & "', '" & _
'                vDateDock & "', '" & _
'                vDiscrepancy & "', '" & _
'                txtRAQty.Text & "', '" & _
'                vWrty & "')"
'            End If

'            '            Dim strSQL As String = "Insert into tworkorder (" & _
'            '            " WO_CustWO, WO_Date" & lblMemo & ", Loc_ID, Prod_ID" & lblPO & ") VALUES ('" & _
'            '            txtWorkOrder.Text & "', '" & _
'            '            newDate & "'" & _
'            '            valMemo & ", " & _
'            '            lblAddressID.Text & _
'            '            strPO & ", " & _
'            '            valPO & ")"

'            Dim tblWO As New PSS.Data.Production.tworkorder()
'            Dim woID As Int32 = tblWO.idTransaction(strSQL)

'            InsertWorkOrder = woID
'            tblWO = Nothing

'        End Function

'        Private Function InsertTray(ByVal valWO As Int32) As Int32

'            Dim strSQL As String = "Insert into ttray (" & _
'            " Tray_RecUser, WO_ID) VALUES ('" & _
'            RecUser & "', " & _
'            valWO & ")"

'            Dim tblTray As New PSS.Data.Production.ttray()
'            'Dim trayID As Int32 = tblTray.idTransaction(strSQL)
'            Dim trayID As Int32 = tblTray.idTransDev(strSQL)

'            InsertTray = trayID

'            Me.lblTrayVAL.Text = InsertTray

'            'Get PSS Warranty fields
'            PopulatePSSwrtyFields(lblCustomerNameString.Text)
'            'Get Labor Charge Value if chkdbr = true
'            If chkDBR.Checked = True Then
'                Dim tblCustMkp As New PSS.Data.Production.tcustmarkup()
'                Dim drCustMkp As DataRow = tblCustMkp.GetRowByPK(valCust)

'                If Not IsDBNull(drCustMkp("Markup_RUR")) Then
'                    valLaborCharge = drCustMkp("Markup_RUR")
'                Else
'                    valLaborCharge = 0
'                End If

'                tblTray = Nothing
'            End If

'            intSKU = SKUmake(txtSKU.Text, VALmodel, valCust)

'        End Function

'        Private Function InsertDevice() As Int32

'            '//Insert device into grid

'            valLoc = lblAddressID.Text

'            Dim dr1 As DataRow = dataGrid.NewRow

'            dr1("CountID") = intCounter + 1 'temporary not inserted into database
'            dr1("DeviceSN") = UCase(txtDeviceSN.Text)
'            If VALtray > 0 Then
'                dr1("DeviceTrayID") = VALtray
'            End If
'            dr1("DeviceWOID") = VALworkorder
'            dr1("DeviceModelID") = VALmodel
'            dr1("DeviceLocationID") = valLoc
'            dr1("DeviceLaborCharge") = valLaborCharge

'            '//Update this element and see if this fixes the problem with time.
'            '            dr1("DeviceDateEntered") = lblDateVAL.Text
'            dr1("DeviceDateEntered") = FormatDate(Now)
'            '//Update this element and see if this fixes the problem with time.

'            If chkDBR.Checked = True Then
'                dr1("DeviceDateBilled") = lblDateVAL.Text
'                dr1("DeviceDateShipped") = lblDateVAL.Text
'                dr1("DeviceLaborLevel") = 1
'                dr1("DeviceDBR") = 1
'            Else
'                dr1("DeviceDBR") = 0
'            End If

'            If Len(VALwrty) > 0 Then
'                dr1("DeviceManufWrty") = VALwrty
'            End If

'            Try
'                If vcDateCodeVM = "1" Then
'                    dr1("DeviceManufWrty") = "S"
'                End If
'            Catch ex As Exception
'            End Try

'            If Len(Trim(vcPOP)) > 1 Then
'                dr1("DeviceManufWrty") = "S"
'            End If

'            If Len(valOLDSN) > 0 Then
'                dr1("DeviceOldSN") = valOLDSN
'                valOLDSN = ""
'            End If

'            If PSSwarranty = True Then
'                dr1("DevicePSSwrty") = "Yes"
'            Else
'                dr1("DevicePSSwrty") = "-"
'            End If

'            dr1("ReconcileID") = valReconcileID

'            If DeviceType = "2" Then
'                If Len(Trim(vcDateCode)) > 0 Then dr1("DeviceDateCode") = vcDateCode
'                If Len(Trim(vcCustomerName)) > 0 Then dr1("DeviceCustFName") = vcCustomerName
'                If Len(Trim(vcModel)) > 0 Then dr1("DeviceModelNum") = vcModel
'                If Len(Trim(vcPOP)) > 0 Then dr1("DevicePOPDate") = vcPOP
'                If Len(Trim(vcMSN)) > 0 Then dr1("DeviceMSN") = vcMSN
'                If Len(Trim(vcProductCode)) > 0 Then dr1("DeviceProdCode") = vcProductCode
'                If Len(Trim(vcCourierTrackIN)) > 0 Then dr1("CourTrackIN") = vcCourierTrackIN
'                If Len(Trim(vcAirCarrCode)) > 0 Then dr1("AirTimeCarrierCode") = vcAirCarrCode
'                If Len(Trim(vcTransactionCode)) > 0 Then dr1("TransactionCode") = vcTransactionCode
'                If Len(Trim(vcAPCcode)) > 0 Then dr1("APCcode") = vcAPCcode
'                If Len(Trim(vcTranceiverCode)) > 0 Then dr1("TransceiverCode") = vcTranceiverCode
'                If Len(Trim(vcIncomingIMEI)) > 0 Then dr1("IncomingIMEI") = vcIncomingIMEI
'                If Len(Trim(vcWrtyClaimNum)) > 0 Then dr1("WrtyClaimNumber") = vcWrtyClaimNum
'                'If Len(Trim(lblCustomerReasonNameString.Text)) > 0 Then dr1("DeviceComplaint") = Trim(lblCustomerReasonNameString.Text)
'                If Len(Trim(vcComplaint)) > 0 Then dr1("DeviceComplaint") = vcComplaint
'                If Len(Trim(vcCSN)) > 0 Then dr1("CSNnumber") = Trim(vcCSN)
'                If Len(Trim(vcMIN)) > 0 Then dr1("DeviceMIN") = Trim(vcMIN)
'                If Len(Trim(vcCarrModelCode)) > 0 Then dr1("DeviceCarrModelCode") = Trim(vcCarrModelCode)
'                If Len(Trim(vcDecimal)) > 0 Then dr1("Decimal") = Trim(vcDecimal)
'                If Len(Trim(intSKU)) > 0 Then dr1("SKU") = Trim(intSKU)

'                '//Reset values once they have been assigned
'                vcDateCode = ""
'                vcCustomerName = ""
'                vcModel = ""
'                vcPOP = ""
'                vcMSN = ""
'                vcProductCode = ""
'                vcCourierTrackIN = ""
'                vcAirCarrCode = ""
'                vcTransactionCode = ""
'                vcAPCcode = ""
'                vcTranceiverCode = ""
'                vcIncomingIMEI = ""
'                vcWrtyClaimNum = ""
'                vcCSN = ""
'            End If

'            dataGrid.Rows.Add(dr1)

'            InsertDevice = 1

'        End Function


'        Private Sub InsertDeviceCellular()

'            '//Insert device into grid

'            valLoc = lblAddressID.Text

'            Dim dr1 As DataRow = dataGrid.NewRow

'            dr1("CountID") = intCounter + 1 'temporary not inserted into database
'            dr1("DeviceSN") = UCase(txtDeviceSN.Text)
'            dr1("DeviceTrayID") = VALtray
'            dr1("DeviceWOID") = VALworkorder
'            dr1("DeviceModelID") = VALmodel
'            dr1("DeviceLocationID") = valLoc
'            dr1("DeviceLaborCharge") = valLaborCharge
'            dr1("DeviceDateCode") = cellValDateCode
'            dr1("DeviceCustFName") = cellValCustomer
'            dr1("DeviceModelNum") = cellValModel
'            dr1("DevicePOPdate") = cellValPOP

'            '//Update this element and see if this fixes the problem with time.
'            '            dr1("DeviceDateEntered") = lblDateVAL.Text
'            dr1("DeviceDateEntered") = FormatDate(Now)
'            '//Update this element and see if this fixes the problem with time.

'            If chkDBR.Checked = True Then
'                dr1("DeviceDateBilled") = lblDateVAL.Text
'                dr1("DeviceDateShipped") = lblDateVAL.Text
'                dr1("DeviceLaborLevel") = 1
'                dr1("DeviceDBR") = 1
'            Else
'                dr1("DeviceDBR") = 0
'            End If

'            If Len(VALwrty) > 0 Then
'                dr1("DeviceManufWrty") = VALwrty
'            End If

'            If Len(valOLDSN) > 0 Then
'                dr1("DeviceOldSN") = valOLDSN
'                valOLDSN = ""
'            End If

'            If PSSwarranty = True Then
'                dr1("DevicePSSwrty") = "Yes"
'            Else
'                dr1("DevicePSSwrty") = "-"
'            End If

'            dataGrid.Rows.Add(dr1)


'        End Sub

'        Private Sub WriteGridData2DB()

'            '            Dim strSQL As String = "Insert into tdevice (" & _
'            '               " Device_SN, Device_DateRec, Tray_ID, Loc_ID, WO_ID, Model_ID) VALUES ('" & _
'            '               txtDeviceSN.Text & "', '" & _
'            '               FormatDate(Now) & "', " & _
'            '               VALtray & ", " & _
'            '               lblAddressID.Text & ", " & _
'            '               VALworkorder & ", " & _
'            '               lblModelNameString.Text & ")"

'            '            Dim tblDevice As New PSS.Data.Production.tdevice()
'            '            Dim DeviceID As Int32 = tblDevice.idTransaction(strSQL)

'            '            InsertDevice = DeviceID
'            '            tblDevice = Nothing


'        End Sub


'        Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

'        End Sub

'        Private Sub refreshTDBgrid()

'            MainGrid.MoveLast()
'            '            Dim tblDevice As New PSS.Data.Production.tdevice()
'            '            Dim dtDevice As DataTable = tblDevice.GetDataTableByTrayOrdered(VALtray)
'            '            MainGrid.DataSource = dtDevice.DefaultView
'            MainGrid.DataSource = dataGrid.DefaultView
'            '            AssignColumnHeaders2Grid()

'            '            dtDevice = Nothing

'        End Sub

'        Private Sub AssignColumnHeaders2Grid()

'            '            MainGrid.Columns(0).Caption = "ID"
'            '            MainGrid.Columns(1).Caption = "SN"
'            '            MainGrid.Columns(2).Caption = "Old SN"
'            '            MainGrid.Columns(3).Caption = "Date Rec"
'            '            MainGrid.Columns(4).Caption = "Date Billed"
'            '            MainGrid.Columns(5).Caption = "Date Shipped"
'            '            MainGrid.Columns(6).Caption = "Manuf Wrty"
'            '            MainGrid.Columns(7).Caption = "OEM Wrty"
'            '            MainGrid.Columns(8).Caption = "PSS Wrty"
'            '            MainGrid.Columns(9).Caption = "MSN Num"
'            '            MainGrid.Columns(10).Caption = "Date Code"
'            '            MainGrid.Columns(11).Caption = "Service Code"
'            '            MainGrid.Columns(12).Caption = "Product Code"
'            '            MainGrid.Columns(13).Caption = "First Name"
'            '            MainGrid.Columns(14).Caption = "Last Name"
'            '            MainGrid.Columns(15).Caption = "Tray"
'            '            MainGrid.Columns(16).Caption = "Work Order"
'            '            MainGrid.Columns(17).Caption = "Model"

'        End Sub

'        Public Sub showColumns2Grid()

'        End Sub

'        Private Function verifyDuplicateDevice(ByVal DeviceSn As String, ByVal valWO As Int32) As Boolean

'            verifyDuplicateDevice = True

'            Dim xCount As Integer
'            Dim dr As DataRow

'            For xCount = 0 To dataGrid.Rows.Count - 1
'                dr = dataGrid.Rows(xCount)
'                If dr("DeviceSN") = DeviceSn Then
'                    verifyDuplicateDevice = False
'                    Exit For
'                End If
'            Next

'            '//Needs to check the entire workorder for duplicate serial numbers
'            'Dim tblDupDev As New PSS.Data.Production.tdevice()
'            Dim dtDupDev As DataTable
'            dtDupDev = PSS.Data.Production.tdevice.GetDuplicateDeviceData(DeviceSn, valWO)
'            If dtDupDev.Rows.Count > 0 Then
'                verifyDuplicateDevice = False
'            End If

'            '            verifyDuplicateDevice = True

'            '            Dim xCount As Integer = 0

'            '            Dim tblDevice As New PSS.Data.Production.tdevice()
'            '            Dim dtDevice As DataTable = tblDevice.GetDataTableByTray(VALtray)
'            '            Dim drDevice As DataRow

'            '            For xCount = 0 To dtDevice.Rows.Count - 1
'            '                drDevice = dtDevice.Rows(xCount)
'            '                If drDevice("Device_SN") = DeviceSn Then
'            '                    verifyDuplicateDevice = False
'            '        dtDevice = Nothing
'            '        Exit Function
'            '    End If
'            'Next

'            dtDupDev.Dispose()
'            dtDupDev = Nothing

'            '            dtDevice = Nothing

'        End Function

'        Private Sub HideMemo()

'            grpMemo.Visible = False

'        End Sub

'        Private Sub ShowMemo()

'            grpMemo.Visible = True

'        End Sub

'        Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp

'            Try
'                VALmainGrid = MainGrid.Columns(1).Value
'            Catch exp As Exception
'            End Try

'        End Sub

'        Private Sub decrementCounter()

'            'Increment counter on page by 1
'            intCounter -= 1
'            Me.lblCountVAL.Text = intCounter
'            Me.lblCountVAL1.Text = intCounter

'        End Sub

'        Private Function deleteDevice(ByVal VALdeviceID As Int32) As Boolean

'            deleteDevice = False
'            Dim tblDevice As New PSS.Data.Production.tdevice()
'            deleteDevice = tblDevice.RemoveDataRowByDevice(VALdeviceID)

'            tblDevice = Nothing

'        End Function

'        Private Sub MainGrid_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MainGrid.BeforeDelete

'            '            Dim ConfDel As Integer = MsgBox("Confirm Delete of Device: Serial Number: " & MainGrid.Columns(1).Value, MsgBoxStyle.YesNo, "Confirm Delete?")
'            '            Select Case ConfDel
'            '                Case 6 'Yes
'            Dim delRecord As Boolean

'            '                    delRecord = deleteDevice(VALmainGrid)
'            '                    If delRecord = False Then
'            '                       'Throw error
'            '                      MsgBox("Record could not be deleted.")
'            '                     Exit Sub
'            '                End If
'            'MsgBox("Peform delete from VALmaingrid")
'            'decrement counters
'            decrementCounter()
'            '                Case 7 'No
'            '                   MsgBox("Device Serial Number: " & MainGrid.Columns(1).Value & ", will not be deleted.", MsgBoxStyle.OKOnly, "Delete Canceled")

'            '          End Select

'        End Sub

'        Private Sub MainGrid_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainGrid.AfterDelete

'            Dim xCount As Integer = 0
'            Dim dr As DataRow

'            For xCount = 0 To dataGrid.Rows.Count - 1
'                dr = dataGrid.Rows(xCount)
'                dr("CountID") = xCount + 1
'            Next

'            refreshTDBgrid()
'            '            MainGrid.MoveLast()
'            Me.txtDeviceSN.Focus()

'        End Sub

'        Private Sub Option1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Option1.CheckedChanged

'            If Option1.Checked = True Then VALOption1 = False

'        End Sub


'        Private Sub txtWorkOrder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWorkOrder.TextChanged

'            VALworkorder = 0

'        End Sub

'        Private Sub cboManufacturer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManufID.KeyDown

'        End Sub

'        Private Sub cboModel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModel.KeyDown
'        End Sub



'        Private Sub txtWorkOrder_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWorkOrder.Leave


'            If Trim(UCase(txtWorkOrder.Text)) = "120EVZWPSSI5.14.04" Then
'                txtQuantity.Text = 617
'                txtRAQty.Text = 617
'                txtPRL.Text = "50150"
'                txtIP.Text = "199.074.153.210"
'                txtSKU.Text = "SUG3283RA"
'            End If

'            If Trim(UCase(txtWorkOrder.Text)) = "120EQWESTPSSI5.14.04" Then
'                txtQuantity.Text = 1528
'                txtRAQty.Text = 1528
'                txtPRL.Text = "0"
'                txtIP.Text = "0"
'                txtSKU.Text = "SUG3284RA"
'            End If

'            If Trim(UCase(txtWorkOrder.Text)) = "V60PNSCVZWPSSI5.14.04" Then
'                txtQuantity.Text = 585
'                txtRAQty.Text = 500
'                txtPRL.Text = "50150"
'                txtIP.Text = "199.074.153.210"
'                txtSKU.Text = "SUG3472RA"
'            End If

'            If blnWOtest = False Then

'                If Len(Trim(txtWorkOrder.Text)) > 0 Then
'                    txtWorkOrder.Text = UCase(txtWorkOrder.Text)
'                    If Len(valPO) > 0 Then
'                        If Trim(txtWorkOrder.Text) <> Trim(POCustWO) Then
'                            VALworkorder = Nothing
'                        End If
'                    End If

'                    If Len(Trim(txtWorkOrder.Text)) < 1 Then
'                        MsgBox("Please enter a workorder value.", MsgBoxStyle.OKOnly, "Enter Workorder")
'                        txtWorkOrder.Focus()
'                        Exit Sub
'                    End If
'                    If cboCustID.Enabled = True Then

'                        If VALworkorder < 1 Then
'                            VALworkorder = WorkOrderExists(txtWorkOrder.Text)
'                        End If

'                        If VALworkorder > 0 Then
'                            Dim valAppend As String
'                            valAppend = MsgBox("The Workorder: " & txtWorkOrder.Text & " already exists. Do you want to append records to this workorder?", MsgBoxStyle.YesNo, "Append Records")
'                            Select Case valAppend
'                                Case 6  'vbYes
'                                    '//Just continue as normal - presume a new table must be created
'                                    '//Get the Manufacturer and Model
'                                Case 7  'vbNo
'                                    MsgBox("You have decided not to append devices to this workorder. Please input a new workorder number.", MsgBoxStyle.OKOnly, "No Append")
'                                    txtWorkOrder.Text = ""

'                                    txtWorkOrder.Focus()
'                            End Select
'                        End If
'                    End If

'                    If valReconcile = 1 Then
'                        createReconcileDT()
'                        If dtReconcile.Rows.Count < 1 Then
'                            MsgBox("This workorder does not exists in the reconciliation files. You can not receive any items for this customer with this workorder.", MsgBoxStyle.OKOnly, "RECON ERROR")
'                            txtWorkOrder.Focus()
'                            Exit Sub
'                        End If
'                    End If

'                    If Len(Trim(txtWorkOrder.Text)) > 0 Then txtQuantity.Focus()
'                    If Len(Trim(cboManufID.Text)) > 0 Then cboModID.Focus()
'                    If Len(Trim(cboModID.Text)) > 0 Then txtDeviceSN.Focus()
'                    blnWOtest = True
'                End If

'            End If

'        End Sub

'        Private Sub chkDBR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDBR.CheckedChanged

'            If chkDBR.Checked = True Then
'                valDBR = True
'                If CInt(lblCustomerNameString.Text) = 1 Then 'Metrocall
'                    'Flag as Metrocall DBR
'                End If
'            Else
'                valDBR = False
'            End If


'        End Sub

'        Private Sub HideCustomerReason()

'            lblCustomerReason.Visible = False
'            cboCustomerReason.Visible = False

'        End Sub

'        Private Sub ShowCustomerReason()

'            'lblCustomerReason.Visible = True
'            'cboCustomerReason.Visible = True
'            lblCustomerReason.Visible = False
'            cboCustomerReason.Visible = False

'        End Sub

'        Private Function CreateGridDT() As DataTable

'            Dim dtGrid As New DataTable("dtGridMain")

'            dtGrid.MinimumCapacity = 500
'            dtGrid.CaseSensitive = False

'            Dim dcDeviceID As New DataColumn("CountID")
'            dtGrid.Columns.Add(dcDeviceID)
'            Dim dcDeviceSN As New DataColumn("DeviceSN")
'            dtGrid.Columns.Add(dcDeviceSN)
'            Dim dcDeviceOLDsn As New DataColumn("DeviceOLDsn")
'            dtGrid.Columns.Add(dcDeviceOLDsn)
'            Dim dcDeviceModelType As New DataColumn("DeviceModelType")
'            dtGrid.Columns.Add(dcDeviceModelType)
'            Dim dcDeviceDateEntered As New DataColumn("DeviceDateEntered")
'            dtGrid.Columns.Add(dcDeviceDateEntered)
'            Dim dcDeviceDateBilled As New DataColumn("DeviceDateBilled")
'            dtGrid.Columns.Add(dcDeviceDateBilled)
'            Dim dcDeviceDateShipped As New DataColumn("DeviceDateShipped")
'            dtGrid.Columns.Add(dcDeviceDateShipped)
'            Dim dcDeviceManufWrty As New DataColumn("DeviceManufWrty")
'            dtGrid.Columns.Add(dcDeviceManufWrty)
'            Dim dcDeviceOEMWrty As New DataColumn("DeviceOEMWrty")
'            dtGrid.Columns.Add(dcDeviceOEMWrty)
'            Dim dcDevicePSSwrty As New DataColumn("DevicePSSwrty")
'            dtGrid.Columns.Add(dcDevicePSSwrty)
'            Dim dcDeviceCAPcode As New DataColumn("DeviceCAPcode")
'            dtGrid.Columns.Add(dcDeviceCAPcode)
'            Dim dcDeviceBAUD As New DataColumn("DeviceBAUD")
'            dtGrid.Columns.Add(dcDeviceBAUD)
'            Dim dcDeviceFrequency As New DataColumn("DeviceFrequency")
'            dtGrid.Columns.Add(dcDeviceFrequency)
'            Dim dcDeviceFOlot As New DataColumn("DeviceFOlot")
'            dtGrid.Columns.Add(dcDeviceFOlot)
'            Dim dcDeviceTrayID As New DataColumn("DeviceTrayID")
'            dtGrid.Columns.Add(dcDeviceTrayID)
'            Dim dcDeviceWOID As New DataColumn("DeviceWOID")
'            dtGrid.Columns.Add(dcDeviceWOID)
'            Dim dcDeviceModelID As New DataColumn("DeviceModelID")
'            dtGrid.Columns.Add(dcDeviceModelID)
'            Dim dcLocID As New DataColumn("DeviceLocationID")
'            dtGrid.Columns.Add(dcLocID)
'            Dim dcDBR As New DataColumn("DeviceDBR")
'            dtGrid.Columns.Add(dcDBR)
'            Dim dcLaborLevel As New DataColumn("DeviceLaborLevel")
'            dtGrid.Columns.Add(dcLaborLevel)
'            Dim dcLaborCharge As New DataColumn("DeviceLaborCharge")
'            dtGrid.Columns.Add(dcLaborCharge)
'            Dim dcReconcileID As New DataColumn("ReconcileID")
'            dtGrid.Columns.Add(dcReconcileID)
'            Dim dcSKU As New DataColumn("SKU")
'            dtGrid.Columns.Add(dcSKU)

'            If DeviceType = "2" Then
'                Dim dcCSN As New DataColumn("CSNnumber")
'                dtGrid.Columns.Add(dcCSN)
'                Dim dcCourTrackIN As New DataColumn("CourTrackIN")
'                dtGrid.Columns.Add(dcCourTrackIN)
'                Dim dcAirTimeCarrierCode As New DataColumn("AirTimeCarrierCode")
'                dtGrid.Columns.Add(dcAirTimeCarrierCode)
'                Dim dcTransactionCode As New DataColumn("TransactionCode")
'                dtGrid.Columns.Add(dcTransactionCode)
'                Dim dcAPCcode As New DataColumn("APCcode")
'                dtGrid.Columns.Add(dcAPCcode)
'                Dim dcTransceiverCode As New DataColumn("TransceiverCode")
'                dtGrid.Columns.Add(dcTransceiverCode)
'                Dim dcIncomingIMEI As New DataColumn("IncomingIMEI")
'                dtGrid.Columns.Add(dcIncomingIMEI)
'                Dim dcWrtyClaimNumber As New DataColumn("WrtyClaimNumber")
'                dtGrid.Columns.Add(dcWrtyClaimNumber)

'                Dim dcOEMwrty As New DataColumn("DeviceOEMwrty")
'                dtGrid.Columns.Add(dcOEMwrty)
'                Dim dcDateCode As New DataColumn("DeviceDateCode")
'                dtGrid.Columns.Add(dcDateCode)
'                Dim dcCustFName As New DataColumn("DeviceCustFName")
'                dtGrid.Columns.Add(dcCustFName)
'                Dim dcCustLName As New DataColumn("DeviceCustLName")
'                dtGrid.Columns.Add(dcCustLName)
'                Dim dcModelNum As New DataColumn("DeviceModelNum")
'                dtGrid.Columns.Add(dcModelNum)
'                Dim dcPOPdate As New DataColumn("DevicePOPdate")
'                dtGrid.Columns.Add(dcPOPdate)
'                Dim dcComplaint As New DataColumn("DeviceComplaint")
'                dtGrid.Columns.Add(dcComplaint)
'                Dim dcMIN As New DataColumn("DeviceMIN")
'                dtGrid.Columns.Add(dcMIN)
'                Dim dcCarrModelCode As New DataColumn("DeviceCarrModelCode")
'                dtGrid.Columns.Add(dcCarrModelCode)
'                Dim dcDecimal As New DataColumn("Decimal")
'                dtGrid.Columns.Add(dcDecimal)
'                Dim dcReturnCode As New DataColumn("ReturnCode")
'                dtGrid.Columns.Add(dcReturnCode)

'                'If cboManufID.Text = "Motorola" Then
'                Dim dcMSN As New DataColumn("DeviceMSN")
'                dtGrid.Columns.Add(dcMSN)
'                'End If

'                'If cboManufID.Text = "Nokia" Then
'                Dim dcProdCode As New DataColumn("DeviceProdCode")
'                dtGrid.Columns.Add(dcProdCode)
'                'End If

'            End If

'            CreateGridDT = dtGrid

'        End Function

'        Private Sub MainGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGrid.Click

'        End Sub

'        Private Sub lockControls()

'            cboCustID.Enabled = False
'            txtWorkOrder.ReadOnly = True
'            cboManufID.Enabled = False
'            cboModID.Enabled = False
'            cboAddress.Enabled = False

'        End Sub

'        Private Sub releaseControls()

'            cboCustID.Enabled = True
'            txtWorkOrder.ReadOnly = False
'            cboManufID.Enabled = True
'            cboModID.Enabled = True
'            '            cboAddress.Enabled = True

'        End Sub

'        Private Sub HideCCgrp()

'            grpCreditCard.Visible = False
'            lblTerms.Visible = True

'        End Sub

'        Private Sub ShowCCgrp()

'            grpCreditCard.Visible = True
'            lblTerms.Visible = False

'        End Sub

'        Private Function checkMotorolaWrty() As String

'            checkMotorolaWrty = "0"

'            Dim xCount As Integer = 0
'            Dim chkValue As String = Mid(Trim(txtDeviceSN.Text), 5, 2)
'            Dim tblManufWrty As New PSS.Data.Production.lmanufwrty()
'            Dim dtManufWrty As DataTable = tblManufWrty.GetManufWrtyData(chkValue, CInt(lblManufacturerNameString.Text))
'            Dim valDateCode As String
'            Dim valExpDate As Date

'            Dim dr As DataRow

'            For xCount = 0 To dtManufWrty.Rows.Count - 1
'                dr = dtManufWrty.Rows(xCount)
'                valDateCode = dr("ManufWrty_Code")
'                valExpDate = dr("ManufWrty_Exp")
'            Next

'            If valExpDate > Now Then
'                checkMotorolaWrty = "S"
'            Else
'                checkMotorolaWrty = "0"
'            End If

'            dtManufWrty.Dispose()
'            dtManufWrty = Nothing
'            tblManufWrty = Nothing

'        End Function

'        Private Function GetNewDeviceSNDuplicate() As Boolean


'            GetNewDeviceSNDuplicate = False

'            Dim dupDevice As String = ""
'            Dim msg As String
'            Dim title As String

'            msg = "This is a duplicate! This workorder already has a pager assigned to this number. " & Chr(13) _
'            & "You can not have duplicates for within a workorder. Please bag and tag and scan the new number for this pager." & Chr(13) _
'            & "Scan new serial number."
'            title = "Error Duplicate Device"
'            dupDevice = InputBox(msg, title)
'            If dupDevice = "" Then
'                txtDeviceSN.Text = ""
'                txtDeviceSN.Focus()
'                Exit Function
'            End If

'            msg = "A new Serial Number has been scanned for this pager. " _
'            & "Is this serial number - " & dupDevice & " - the correct replacement for this device [" & txtDeviceSN.Text & "]? " & Chr(13) _
'            & "Please select yes or no to continue."
'            title = "Question on Device"
'            Dim response As String
'            response = MsgBox(msg, MsgBoxStyle.YesNo, title)
'            If response = vbNo Then
'                txtDeviceSN.Text = ""
'                txtDeviceSN.Focus()
'            End If
'            If response = vbYes Then

'                '//NEW - Reconciliation on Receiving - START
'                If valReconcile = 1 Then
'                    'This customer must have match in database
'                    Dim rRec As DataRow
'                    Dim blnReconcile As Boolean = False
'                    Dim tmpCount As Integer = 0
'                    For tmpCount = 0 To dtReconcile.Rows.Count - 1
'                        rRec = dtReconcile.Rows(tmpCount)
'                        If Trim(valCust) = Trim(rRec("rec_cust")) Then
'                            If Trim(UCase(txtWorkOrder.Text)) = Trim(UCase(rRec("rec_wo"))) Then
'                                If Trim(rRec("rec_serial")) = Trim(dupDevice) Then
'                                    blnReconcile = True
'                                    valReconcileID = rRec("rec_id")
'                                    Exit For
'                                End If
'                            End If
'                        End If
'                    Next
'                    For tmpCount = 0 To dtReconcile.Rows.Count - 1
'                        rRec = dtReconcile.Rows(tmpCount)
'                        If Trim(valCust) = Trim(rRec("rec_cust")) Then
'                            If Trim(txtWorkOrder.Text) = Trim(rRec("rec_wo")) Then
'                                If Trim(rRec("rec_cap")) = Trim(txtDeviceSN.Text) Then
'                                    valReconcileID = rRec("rec_id")
'                                    blnReconcile = True
'                                    Exit For
'                                End If
'                            End If
'                        End If
'                    Next

'                    If blnReconcile = False Then
'                        MsgBox("This item is not designated by its owner as a valid serial number type. It can not be received until corrected.", MsgBoxStyle.OKOnly, "ERROR")
'                        txtDeviceSN.Text = ""
'                        txtDeviceSN.Focus()
'                        Exit Function
'                    End If

'                End If
'                '//NEW - Reconciliation on Receiving - END

'                Dim xCount As Integer
'                Dim dr As DataRow

'                For xCount = 0 To dataGrid.Rows.Count - 1

'                    Dim blnSecondChance As Boolean = Me.verifyDuplicateDevice(dupDevice, VALworkorder)
'                    If blnSecondChance = False Then
'                        MsgBox("Device could not be entered because the new value already exists for the tray. Exiting", MsgBoxStyle.OKOnly, "Can Not Add Device")
'                        Exit Function
'                    End If

'                    dr = dataGrid.Rows(xCount)
'                    If dr("DeviceSN") = dupDevice Then
'                    End If
'                Next

'                valOLDSN = txtDeviceSN.Text
'                txtDeviceSN.Text = dupDevice
'                GetNewDeviceSNDuplicate = True
'            End If

'        End Function

'        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click


'            Dim lstTech As New PSS.Data.Production.tusers()
'            Dim dtTech As DataTable = lstTech.GetCellTechList
'            Dim tmpUser, tmpEmployee As String
'            Dim tmpID, tmpShift As Integer

'            tmpUser = PSS.Core.Global.ApplicationUser.User
'            tmpID = 0
'            tmpShift = 0

'            Dim xCount As Integer
'            Dim r As DataRow

'            For xCount = 0 To dtTech.Rows.Count - 1
'                r = dtTech.Rows(xCount)
'                If tmpUser = r("user_fullname") Then
'                    tmpID = r("tech_id")
'                    tmpEmployee = r("EmployeeNo")
'                    tmpShift = r("Shift_ID")
'                    Exit For
'                End If
'            Next

'            dtTech = Nothing







'            btnPrint.Enabled = False

'            '//Update tworkorder if txtWorkOrderMemo.text is not null
'            If VALworkorder > 0 And Len(txtWorkOrderMemo.Text) > 0 Then
'                Dim strSQL As String = "UPDATE tworkorder set WO_Memo = '" & txtWorkOrderMemo.Text & "' WHERE WO_ID = " & VALworkorder

'                Dim tblUpdateString As New PSS.Data.Production.tworkorder()
'                Dim intUpd As Int32 = tblUpdateString.idTransaction(strSQL)
'            End If


'            Dim strReportLoc As String = PSS.Core.ReportPath
'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            '//Write records from grid to database
'            '            Dim tReceiving As New PSS.Data.Production.tdevice()
'            MainWin.StatusBar.SetStatusText("Writing Devices to the Database")

'            Dim tmpWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
'            If Len(Trim(tmpWorkDate)) < 1 Then
'                MsgBox("Your user configuration is incorrect/incomplete. Please contact your direct lead to resolve this problem. Your login will not function until this is resolved.", MsgBoxStyle.Critical, "User Setup Error")
'                End
'            End If

'            Dim blnRecDevice As Boolean '= tReceiving.ReceivingTransmitDeviceData(dataGrid)
'            blnRecDevice = PSS.Data.Production.tdevice.ReceivingTransmitDeviceData(dataGrid, DeviceType, RecType, tmpShift, tmpWorkDate)

'            If blnRecDevice = False Then
'                MsgBox("An error occurred while writing the devices to the database. No devices were entered.", MsgBoxStyle.OKOnly)
'                btnPrint.Enabled = True
'                Exit Sub
'            End If

'            valStage = 0

'            If valStage = 0 Then
'                '//Report to Print
'                MainWin.StatusBar.SetStatusText("Sending Worksheet to Printer")
'                Try
'                    'Dim rptApp As New CRAXDRT.Application()
'                    'Dim rpt As New CRAXDRT.Report()
'                    Dim objRpt As ReportDocument

'                    objRpt = New ReportDocument()

'                    With objRpt
'                        .Load(PSS.Core.Global.ReportPath & "Rec_Worksheet_Cell.rpt")
'                        .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(VALtray)
'                        .PrintToPrinter(2, True, 0, 0)
'                    End With

'                    'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet_Cell.rpt")
'                    ''rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet_TEST.rpt")
'                    'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(VALtray)
'                    'rpt.PrintOut(False, 2)

'                    'rpt = Nothing
'                    'rptApp = Nothing

'                Catch exp As Exception
'                    MsgBox(exp.ToString)
'                    Cursor.Current = System.Windows.Forms.Cursors.Default
'                End Try

'                '//Report to print if Print Changed Device is selected
'                Try
'                    If Option1.Checked = True Then                  'Print device change report
'                        MainWin.StatusBar.SetStatusText("Sending Device Change Report to Printer")

'                        Dim report2 As New Rec__DeviceChangeSample()
'                        report2.RecordSelectionFormula = "{tdevice.Tray_ID} = " & VALtray
'                        report2.Refresh()
'                        report2.PrintToPrinter(1, False, 0, 0)
'                        'report2 = Nothing

'                        'Craig Haney
'                        report2.Close()
'                        report2.Dispose()
'                        report2 = Nothing
'                        'Craig Haney

'                    End If
'                Catch exp As Exception
'                    MsgBox(exp.ToString)
'                    Cursor.Current = System.Windows.Forms.Cursors.Default
'                End Try

'            End If
'            releaseControls()

'            txtWorkOrder.Focus()
'            dataGrid.Clear()
'            'cboModID.Text = ""
'            'cboManufID.Text = ""
'            lblTrayVAL.Text = ""
'            intCounter = 0
'            Me.lblCountVAL.Text = 0
'            Me.lblCountVAL1.Text = 0
'            Option1.Checked = False

'            Cursor.Current = System.Windows.Forms.Cursors.Default
'            MainWin.StatusBar.SetStatusText("")

'            If RecType = "3" Then
'                EndUserNextRun()
'            End If

'            'cboCustID.Focus()

'            '//AT Carolyn Request
'            'cboModID.Focus()
'            'cboManufID.Focus()
'            '//AT Carolyn Request
'            txtDeviceSN.Focus()

'            btnPrint.Enabled = True

'        End Sub

'        Private Sub EndUserNextRun()

'            cboCustID.Items.Clear()
'            lblCustomerNameString.Text = ""

'            txtWorkOrder.Text = ""
'            txtLocation.Text = ""
'            cboAddress.Text = ""
'            lblAddressID.Text = ""
'            lblAddressVAL.Text = ""
'            lblCustomerVAL.Text = ""

'            Dim vProd As Integer = CInt(DeviceType)
'            Dim vRec As Integer = CInt(RecType)

'            Dim frmEndUser As New frmEndUserInput(vProd, vRec)
'            frmEndUser.ShowDialog()

'            Try
'                valCust = frmEndUser.valCust
'                valLoc = frmEndUser.valLoc
'                valCC = frmEndUser.valCC
'            Catch exp As Exception
'                Close()
'            End Try

'            Dim tblCustomer As New PSS.Data.Production.Joins()
'            Dim tblCustEU As New PSS.Data.Production.tcustomer()
'            Dim arrCount, xCount As Integer
'            Dim r As DataRow
'            Dim dtCust As DataTable
'            dtCust = tblCustomer.CustomerListPagerEndUser()
'            If valCust < 1 Then 'Nothing was returned from end user input screen
'                Close()
'                Exit Sub
'            End If
'            r = tblCustEU.GetRowByPK(valCust)
'            If RecType = "3" And Len(valCust) > 0 Then
'                arrCount = 0
'                For xCount = 0 To dtCust.Rows.Count - 1
'                    If r("Cust_ID") = valCust Then
'                        cboCustID.Items.Add(r("Cust_Name1") & " " & r("Cust_Name2"))
'                        arrCustomers(arrCount, 0) = r("Cust_ID")
'                        If Not IsDBNull(r("Cust_Name1")) Then
'                            arrCustomers(arrCount, 1) = r("Cust_Name1")
'                        End If
'                        If Not IsDBNull(r("Cust_Name2")) Then
'                            arrCustomers(arrCount, 2) = r("Cust_Name2")
'                        End If
'                        If Not IsDBNull(r("Cust_CrApproveRec")) Then
'                            arrCustomers(arrCount, 3) = r("Cust_CrApproveRec")
'                        End If
'                        If Not IsDBNull(r("Pay_ID")) Then
'                            arrCustomers(arrCount, 4) = r("Pay_ID")
'                        End If
'                        arrCount += 1
'                        Exit For
'                    End If
'                Next
'            Else
'                arrCount = 0
'                For xCount = 0 To dtCust.Rows.Count - 1
'                    r = dtCust.Rows(xCount)
'                    If r("PCo_ID") <> 349 And r("PCo_ID") <> 409 Then
'                        cboCustID.Items.Add(r("Cust_Name1"))
'                        arrCustomers(arrCount, 0) = r("Cust_ID")
'                        If Not IsDBNull(r("Cust_Name1")) Then
'                            arrCustomers(arrCount, 1) = r("Cust_Name1")
'                        End If
'                        If Not IsDBNull(r("Cust_Name2")) Then
'                            arrCustomers(arrCount, 2) = r("Cust_Name2")
'                        End If
'                        If Not IsDBNull(r("Cust_CrApproveRec")) Then
'                            arrCustomers(arrCount, 3) = r("Cust_CrApproveRec")
'                        End If
'                        If Not IsDBNull(r("Pay_ID")) Then
'                            arrCustomers(arrCount, 4) = r("Pay_ID")
'                        End If
'                        arrCount += 1
'                    End If
'                Next
'            End If

'            selectEndUser()
'            GetCreditCardInformation()
'            cboCustID.Focus()

'        End Sub


'        Private Function GetStateName(ByVal intState As Integer) As String

'            Dim yCount As Integer = 0

'            '//This section will convert the State ID over to the Start Short Name
'            If intState > 0 Then
'                'Get State Name for Address

'                For yCount = 0 To UBound(arrState)
'                    If arrState(yCount, 0) = intState Then
'                        GetStateName = arrState(yCount, 1)
'                        Exit For
'                    End If
'                Next

'            End If

'        End Function

'        Private Sub makeArrayState()

'            Dim yCount As Integer = 0

'            'Get State Name for Address
'            Dim tblState As New PSS.Data.Production.lstate()
'            Dim dsState As DataSet = tblState.GetData
'            Dim rState As DataRow
'            For yCount = 0 To dsState.Tables("lstate").Rows.Count - 1
'                rState = dsState.Tables("lstate").Rows(yCount)
'                arrState(yCount, 0) = rState("State_ID")
'                arrState(yCount, 1) = rState("State_Short")
'            Next
'            dsState = Nothing
'            tblState = Nothing

'        End Sub

'        Private Sub makeArrayCountry()

'            Dim yCount As Integer = 0
'            Dim tblCountry As New PSS.Data.Production.lcountry()
'            Dim dsCountry As DataSet = tblCountry.GetData
'            Dim rCountry As DataRow
'            For yCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
'                rCountry = dsCountry.Tables("lcountry").Rows(yCount)
'                arrCountry(yCount, 0) = rCountry("Cntry_ID")
'                arrCountry(yCount, 1) = rCountry("Cntry_Name")
'            Next
'            dsCountry = Nothing
'            tblCountry = Nothing

'        End Sub

'        Private Function GetCountryName(ByVal intCountry As Integer) As String

'            Dim yCount As Integer = 0

'            '//This section will convert the Country ID over to the Country Name
'            If intCountry > 0 Then
'                'Get State Name for Address
'                For yCount = 0 To UBound(arrCountry)
'                    If arrCountry(yCount, 0) = intCountry Then
'                        GetCountryName = arrCountry(yCount, 1)
'                        Exit For
'                    End If
'                Next
'            End If

'        End Function

'        Private Sub cboAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddress.SelectedIndexChanged
'            Try
'                valLoc = arrLocations(cboAddress.SelectedIndex, 0)
'                lblAddressID.Text = valLoc
'                '                txtLocation.Text = arrLocations(cboAddress.SelectedIndex, 3)

'            Catch
'            End Try

'        End Sub

'        Private Sub chkDBR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDBR.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            verVal = verifyWorkOrderSelected()
'            If verVal = False Then Exit Sub

'        End Sub

'        Private Sub lblModelNameString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblModelNameString.Click

'        End Sub

'        Private Sub cboAddress_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAddress.Leave

'            '            txtWorkOrder.Focus()

'        End Sub

'        Private Sub cboAddress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAddress.KeyDown

'            If e.KeyValue = 13 Then
'                txtWorkOrder.Focus()
'            End If

'        End Sub

'        Private Sub txtWorkOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWorkOrder.KeyDown

'            If e.KeyValue = 13 Then
'                txtQuantity.Focus()
'                'cboManufID.Focus()
'            End If

'        End Sub

'        Private Sub InitializePSSwrtyFields()

'            CustPSSwrtyParts = 0
'            CustPSSwrtyLabor = 0
'            CustPSSwrtyRejectDays = 0
'            CustPSSwrtyRejectTimes = 0
'            CustPSSwrtyDaysInWrty = 0

'        End Sub

'        Private Sub PopulatePSSwrtyFields(ByVal valCustID As Integer)

'            '//Assign values for PSS warranty selection
'            Dim xCount As Integer = 0
'            Dim tblCustomer As New PSS.Data.Production.tcustomer()
'            Dim drCustomer As DataRow = tblCustomer.GetRowByPK(valCustID)

'            Try
'                CustPSSwrtyRejectDays = drCustomer("Cust_RejectDays")
'            Catch exp As Exception
'                CustPSSwrtyRejectDays = 0
'            End Try

'            Try
'                CustPSSwrtyRejectTimes = drCustomer("Cust_RejectTimes")
'            Catch exp As Exception
'                CustPSSwrtyRejectTimes = 0
'            End Try


'            Try
'                Dim tblCustWrty As New PSS.Data.Production.tcustwrty()
'                Dim drCustWrty As DataRow = tblCustWrty.GetRowByCustID(valCustID)

'                CustPSSwrtyParts = drCustWrty("PSSwrtyParts_ID")
'                CustPSSwrtyLabor = drCustWrty("PSSwrtyLabor_ID")
'                CustPSSwrtyDaysInWrty = drCustWrty("CustWrty_DaysInWrty")

'                drCustWrty = Nothing
'                tblCustWrty = Nothing

'            Catch exp As Exception
'            End Try

'            drCustomer = Nothing
'            tblCustomer = Nothing

'        End Sub


'        Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged

'            blnWOtest = False

'        End Sub

'        Private Sub txtLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyDown

'            If e.KeyValue = 13 Then
'                txtWorkOrder.Focus()
'            End If

'        End Sub

'        Private Sub txtLocation_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyUp

'            If Len(txtLocation.Text) < 1 Then
'                'cboAddress.Text = ""
'                Exit Sub
'            End If

'            Dim xVal As Integer

'            Dim xCount As Integer
'            For xCount = 0 To UBound(arrLocations)

'                xVal = InStr(arrLocations(xCount, 3), txtLocation.Text, CompareMethod.Text)
'                If xVal = 1 Then
'                    cboAddress.SelectedIndex = xCount
'                    cboAddress.DroppedDown = False
'                    Exit For
'                End If

'            Next

'        End Sub

'        Private Sub txtLocation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocation.Leave

'            If Len(txtLocation.Text) < 1 Then
'                lblAddressID.Text = ""
'                cboAddress.Text = ""
'                Exit Sub
'            Else
'                txtLocation.Text = UCase(txtLocation.Text)
'            End If

'            txtWorkOrder.Focus()

'        End Sub





'        Private Sub cboManufacturer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManufID.KeyUp

'        End Sub

'        Private Sub cboManufacturer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufID.Leave

'        End Sub

'        Private Sub cboCustID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustID.SelectedIndexChanged

'            blnWOtest = False

'            If RecType <> "3" Then
'                grpCreditCard.Visible = False
'            Else
'                grpCreditCard.Visible = True
'            End If
'            lblTerms.Visible = False

'            If RecType = "4" Then
'                lblCustomerNameString.Text = valCust
'                cboCustomerIDChanged()
'                Exit Sub
'            End If

'            valReconcile = 0
'            valReconcileID = 0
'            valCust = arrCustomers(cboCustID.SelectedIndex, 0)
'            valReconcile = arrCustomers(cboCustID.SelectedIndex, 5)
'            valStage = arrCustomers(cboCustID.SelectedIndex, 6)

'            If Device_Type = "Cell" Then
'                If InStr(cboCustID.Text, "NCOA") = 1 Then 'sub in NCOA for Customer after testing
'                    ShowClaimMember()
'                Else
'                    HideClaimMember()
'                End If
'            End If

'            Dim xCount As Integer


'            Try
'                For xCount = 0 To cboCustID.Items.Count - 1

'                    If arrCustomers(xCount, 0).ToString = CStr(valCust) Then
'                        '//Select End User
'                        lblCustomerNameString.Text = CStr(valCust)
'                        'cboCustomerIDChanged()
'                        Exit For
'                    ElseIf arrCustomers(xCount, 1).ToString = cboCustID.Text Then
'                        '//Select Customer
'                        lblCustomerNameString.Text = arrCustomers(xCount, 0).ToString
'                        'cboCustomerIDChanged()
'                        Exit For
'                    End If
'                Next
'            Catch exp As Exception
'                MsgBox(exp.ToString)
'            End Try


'        End Sub

'        Private Sub cboCustID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustID.KeyDown

'            If e.KeyValue = 13 Then
'                If RecType <> "5" Then
'                    txtWorkOrder.Focus()
'                Else
'                    cboManufID.Focus()
'                End If
'            End If

'        End Sub

'        Private Sub cboCustID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustID.Leave

'            If Len(lblCustomerNameString.Text) < 1 Then
'                cboCustID.Focus()
'                Exit Sub
'            End If

'            Try
'                cboCustomerIDChanged()
'                '//Credit Worthiness is called once the field Customer has been left
'                '//You can not continue if Cust_CrApproveRec is set to 0
'                Dim creditWorth As Boolean = VerifyCreditWorthiness()
'                If creditWorth = False Then
'                    cboCustID.Focus() 'You can not continue if credit is not available.
'                ElseIf txtLocation.Visible = True Then
'                    txtLocation.Focus()
'                Else
'                    txtWorkOrder.Focus()
'                End If
'            Catch exp As Exception
'                cboCustID.Focus()
'            End Try

'        End Sub

'        Private Sub cboManufID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboManufID.SelectedIndexChanged

'            Dim manufVal As Long = GetManufactureID()

'            lblManufacturerNameString.Text = manufVal
'            VALmanufacturer = manufVal

'            'if manufval = "Motorola" then make MSN visible
'            'if manufval = "Nokia" then make Product code visible
'            '//Populate the models and complaint codes which belong to the selected manufacturer
'            PopulateModels()

'            'PopulateComplaints()

'        End Sub

'        Private Sub cboManufID_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufID.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            '            verVal = verifyWorkOrderSelected()
'            '            If verVal = False Then Exit Sub

'            cboManufID.DroppedDown = True

'        End Sub

'        Private Sub cboManufID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManufID.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(cboManufID.Text) < 1 Then
'                    cboManufID.Focus()
'                    Exit Sub
'                End If
'                cboModID.Focus()
'            End If

'        End Sub

'        Private Sub cboManufID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManufID.KeyUp

'            Dim xVal As Integer
'            Dim xCount As Integer

'            For xCount = 0 To UBound(arrManufacturers)
'                xVal = InStr(arrManufacturers(xCount, 1), cboManufID.Text, CompareMethod.Text)
'                If xVal = 1 Then
'                    Exit For
'                End If
'            Next

'        End Sub

'        Private Sub cboManufID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufID.Leave


'            Try
'                If Len(lblManufacturerNameString.Text) < 1 Then
'                    cboManufID.Focus()
'                    Exit Sub
'                End If

'            Catch exp As Exception
'                cboManufID.Focus()
'                Exit Sub
'            End Try

'            Try
'                PopulateModels()
'            Catch exp As Exception
'                cboManufID.Focus()
'                Exit Sub
'            End Try

'        End Sub

'        Private Sub cboModID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModID.SelectedIndexChanged

'            '//Assign new model ID to the form
'            Dim modelVal As Long = GetModelID()
'            lblModelNameString.Text = modelVal
'            VALmodel = modelVal


'        End Sub

'        Private Sub cboModID_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModID.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            '            verVal = verifyWorkOrderSelected()
'            '            If verVal = False Then Exit Sub
'            '//Verify that a manufacturer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Manufacturer field if needed
'            verVal = verifyManufacturerSelected()
'            If verVal = False Then Exit Sub

'            cboModID.DroppedDown = True

'        End Sub

'        Private Sub cboModID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModID.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(cboModID.Text) < 1 Then
'                    cboModID.Focus()
'                    Exit Sub
'                End If
'                'If DeviceType = "2" Then
'                '    cboCustomerReason.Focus()
'                'Else
'                'txtDeviceSN.Focus()
'                txtSKU.Focus()
'                'End If
'                VALmodel = CInt(lblModelNameString.Text)
'            End If

'        End Sub

'        Private Sub btnNewLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLocation.Click

'            Try
'                releaseControls()
'                txtLocation.Focus()
'                dataGrid.Clear()
'                cboModID.Text = ""
'                cboManufID.Text = ""
'                'txtWorkOrder.Text = ""
'                txtWorkOrderMemo.Text = "Repair"
'                lblTrayVAL.Text = ""
'                intCounter = 0
'                Me.lblCountVAL.Text = 0
'                Me.lblCountVAL1.Text = 0
'                txtLocation.Text = ""
'                cboAddress.Text = ""
'                VALworkorder = 0
'                Option1.Checked = False
'                txtSKU.Text = ""
'                txtQuantity.Text = ""
'                txtPRL.Text = ""
'                txtIP.Text = ""
'                cboWrty.Text = ""
'            Catch exp As Exception
'            End Try

'        End Sub

'        Private Sub btnCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCust.Click

'            releaseControls()
'            Try
'                cboCustID.Focus()
'                dataGrid.Clear()
'                cboModID.Text = ""
'                cboManufID.Text = ""
'                txtWorkOrder.Text = ""
'                txtWorkOrderMemo.Text = "Repair"
'                lblTrayVAL.Text = ""
'                intCounter = 0
'                Me.lblCountVAL.Text = 0
'                Me.lblCountVAL1.Text = 0
'                txtLocation.Text = ""
'                cboAddress.Text = ""
'                VALworkorder = 0
'                Option1.Checked = False
'                txtSKU.Text = ""
'                txtQuantity.Text = ""
'                txtPRL.Text = ""
'                txtIP.Text = ""
'                cboWrty.Text = ""
'            Catch exp As Exception
'            End Try

'        End Sub

'        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click

'            Dim strReportLoc As String = PSS.Core.ReportPath

'            Try
'                Dim TmptrayVal As Int32
'                TmptrayVal = InputBox("Enter tray value for reprint", "Reprint")

'                'Dim rptApp As New CRAXDRT.Application()
'                'Dim rpt As New CRAXDRT.Report()
'                Dim objRpt As ReportDocument

'                objRpt = New ReportDocument()

'                With objRpt
'                    .Load(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
'                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(TmptrayVal)
'                    .PrintToPrinter(2, True, 0, 0)
'                End With

'                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
'                ''rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet_TEST.rpt")
'                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(TmptrayVal)
'                'rpt.PrintOut(False, 2)
'                'rpt = Nothing
'                'rptApp = Nothing
'            Catch exp As Exception
'            End Try
'            Cursor.Current = System.Windows.Forms.Cursors.Default

'        End Sub

'        Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

'            Dim strReportLoc As String = PSS.Core.ReportPath

'            Try
'                Dim TmptrayVal As Int32
'                TmptrayVal = InputBox("Enter tray value for reprint Device Change Report", "Reprint")
'                Dim report2 As New Rec__DeviceChangeSample()
'                report2.RecordSelectionFormula = "{tdevice.Tray_ID} = " & TmptrayVal
'                report2.Refresh()
'                report2.PrintToPrinter(1, False, 0, 0)
'                report2 = Nothing

'            Catch exp As Exception
'            End Try
'            Cursor.Current = System.Windows.Forms.Cursors.Default

'        End Sub

'        Private Sub createReconcileDT()

'            Try
'                dtReconcile.Clear()
'            Catch exp As Exception
'            End Try

'            Dim dataReconcile As New PSS.Data.Production.lcustrec()
'            dtReconcile = dataReconcile.GetReconcileListByCustAndWO(valCust, Trim(txtWorkOrder.Text))

'        End Sub


'        Private Sub btnStaging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStaging.Click

'            Dim frmS As New Receiving.frmMCstaging()
'            frmS.ShowDialog()

'        End Sub

'        Private Sub cboCustomerReason_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            Dim customerreasonVal As Long = GetCustomerReasonID()
'            lblCustomerReasonNameString.Text = customerreasonVal

'        End Sub


'        Private Sub lblCustomerReasonNameString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCustomerReasonNameString.Click

'        End Sub

'        Private Sub cboCustomerReason_SelectedIndexChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerReason.SelectedIndexChanged

'            Dim customerreasonVal As Long = GetCustomerReasonID()
'            lblCustomerReasonNameString.Text = customerreasonVal

'        End Sub

'        Private Sub cboCustomerReason_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomerReason.KeyDown

'            If e.KeyValue = 13 Then
'                txtDeviceSN.Focus()
'            End If

'        End Sub

'        Private Sub cboCustomerReason_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerReason.Enter

'            Dim verVal As Boolean
'            '//Verify that a customer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Customer ID field if needed
'            verVal = verifyCustomerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a workorder is entered. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Workorder field if needed
'            verVal = verifyWorkOrderSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a manufacturer is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Manufacturer field if needed
'            verVal = verifyManufacturerSelected()
'            If verVal = False Then Exit Sub
'            '//Verify that a model is selected. the method verifyCustomerSelected will
'            '//automatically place the cursor in the Model field if needed
'            verVal = verifyModelSelected()
'            If verVal = False Then Exit Sub

'            cboCustomerReason.DroppedDown = True


'        End Sub


'        Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged

'        End Sub

'        Private Sub txtQuantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuantity.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(Trim(txtQuantity.Text)) < 1 Then
'                    txtQuantity.Focus()
'                    Exit Sub
'                End If
'                txtPRL.Focus()
'                'cboManufID.Focus()
'            End If

'        End Sub

'        Private Sub txtPRL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPRL.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(Trim(txtPRL.Text)) < 1 Then
'                    txtPRL.Focus()
'                    Exit Sub
'                End If
'                txtIP.Focus()
'                'cboManufID.Focus()
'            End If

'        End Sub

'        Private Sub txtIP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIP.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(Trim(txtIP.Text)) < 1 Then
'                    txtIP.Focus()
'                    Exit Sub
'                End If
'                txtRAQty.Focus()
'            End If

'        End Sub

'        Private Sub txtSKU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSKU.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(Trim(txtSKU.Text)) < 1 Then
'                    txtSKU.Focus()
'                    Exit Sub
'                End If
'                txtDeviceSN.Focus()
'            End If

'        End Sub

'        Private Sub txtSKU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSKU.TextChanged

'        End Sub

'        Private Sub txtSKU_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSKU.Leave

'        End Sub

'        Private Function SKUmake(ByVal SKUnumber As String, ByVal vModel As Int32, ByVal vCust As Int32) As Int32

'            Dim tVsku As New PSS.Data.Production.tsku()
'            Dim verSKU As Boolean = tVsku.GetRowBySKU(UCase(Trim(SKUnumber)))

'            If verSKU = False Then
'                'Insert record
'                Dim strSQL As String = "INSERT INTO tsku (Sku_Number, Model_ID, Cust_ID) VALUES ('" & UCase(Trim(SKUnumber)) & "', " & vModel & ", " & vCust & ")"
'                SKUmake = tVsku.idTransaction(strSQL)
'            Else

'                Dim vSku As DataRow = tVsku.GetValSKU(SKUnumber)
'                SKUmake = vSku("Sku_ID")
'            End If

'        End Function


'        Private Sub txtPRL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRL.TextChanged

'        End Sub

'        Private Sub txtPRL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRL.Enter

'            If Len(Trim(txtQuantity.Text)) < 1 Then
'                txtQuantity.Focus()
'            End If

'        End Sub

'        Private Sub txtIP_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIP.Enter

'            If Len(Trim(txtPRL.Text)) < 1 Then
'                txtPRL.Focus()
'            End If

'            If Len(Trim(txtQuantity.Text)) < 1 Then
'                txtQuantity.Focus()
'            End If

'        End Sub

'        Private Sub txtSKU_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSKU.Enter

'            If Len(Trim(txtIP.Text)) < 1 Then
'                txtIP.Focus()
'            End If

'            If Len(Trim(txtPRL.Text)) < 1 Then
'                txtPRL.Focus()
'            End If

'            If Len(Trim(txtQuantity.Text)) < 1 Then
'                txtQuantity.Focus()
'            End If

'        End Sub

'        Private Sub txtRAQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRAQty.TextChanged

'        End Sub

'        Private Sub txtRAQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRAQty.Leave

'            vDiscrepancy = ""
'            If CInt(Me.txtQuantity.Text) <> CInt(Me.txtRAQty.Text) Then
'                '//make input box to set discrepency values
'enterDiscrepancy:
'                vDiscrepancy = InputBox("Enter Discrepancy Description for this workorder", "Discrepancy Description")
'                If Len(Trim(vDiscrepancy)) < 1 Then GoTo enterDiscrepancy
'            End If

'        End Sub

'        Private Sub txtIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIP.TextChanged

'        End Sub

'        Private Sub txtRAQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRAQty.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(Trim(txtIP.Text)) < 1 Then
'                    txtRAQty.Focus()
'                    Exit Sub
'                End If
'                'cboManufID.Focus()
'                cboWrty.Focus()
'            End If

'        End Sub

'        Private Sub cboWrty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWrty.SelectedIndexChanged

'        End Sub

'        Private Sub cboWrty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboWrty.KeyDown

'            If e.KeyValue = 13 Then
'                If Len(Trim(cboWrty.Text)) < 1 Then
'                    cboWrty.Focus()
'                    Exit Sub
'                End If
'                cboManufID.Focus()
'            End If

'        End Sub
'    End Class

'End Namespace
