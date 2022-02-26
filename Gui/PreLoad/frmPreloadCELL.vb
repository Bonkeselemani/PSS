Public Class frmPreloadCELL
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents lblRMA As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpRMA As System.Windows.Forms.TabPage
    Friend WithEvents tpDevice As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCarrier As System.Windows.Forms.Label
    Friend WithEvents lblShipTo As System.Windows.Forms.Label
    Friend WithEvents cboCarrier As System.Windows.Forms.ComboBox
    Friend WithEvents cboShipTo As System.Windows.Forms.ComboBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents lblPrl As System.Windows.Forms.Label
    Friend WithEvents lblIp As System.Windows.Forms.Label
    Friend WithEvents lblRAqty As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtPrl As System.Windows.Forms.TextBox
    Friend WithEvents txtIp As System.Windows.Forms.TextBox
    Friend WithEvents txtRAqty As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents btnRMAupdate As System.Windows.Forms.Button
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblAPC As System.Windows.Forms.Label
    Friend WithEvents lblINIMEI As System.Windows.Forms.Label
    Friend WithEvents lblINCourTrack As System.Windows.Forms.Label
    Friend WithEvents lblAirCarrCode As System.Windows.Forms.Label
    Friend WithEvents lblTransactionCode As System.Windows.Forms.Label
    Friend WithEvents lblTransceiverCode As System.Windows.Forms.Label
    Friend WithEvents lblCarrModelCode As System.Windows.Forms.Label
    Friend WithEvents lblMinNumber As System.Windows.Forms.Label
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents lblComplaint As System.Windows.Forms.Label
    Friend WithEvents lblReturnCode As System.Windows.Forms.Label
    Friend WithEvents cboAPC As System.Windows.Forms.ComboBox
    Friend WithEvents txtINIMEI As System.Windows.Forms.TextBox
    Friend WithEvents txtINCourTrack As System.Windows.Forms.TextBox
    Friend WithEvents cboAirCarrCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboTransactionCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboModel As System.Windows.Forms.ComboBox
    Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblManufacturer As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblRMA = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpRMA = New System.Windows.Forms.TabPage()
        Me.txtDocDate = New System.Windows.Forms.TextBox()
        Me.lblDocDate = New System.Windows.Forms.Label()
        Me.btnRMAupdate = New System.Windows.Forms.Button()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.txtRAqty = New System.Windows.Forms.TextBox()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.txtPrl = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblRAqty = New System.Windows.Forms.Label()
        Me.lblIp = New System.Windows.Forms.Label()
        Me.lblPrl = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboShipTo = New System.Windows.Forms.ComboBox()
        Me.cboCarrier = New System.Windows.Forms.ComboBox()
        Me.lblShipTo = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.cboModel = New System.Windows.Forms.ComboBox()
        Me.cboManufacturer = New System.Windows.Forms.ComboBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.tpDevice = New System.Windows.Forms.TabPage()
        Me.cboTransactionCode = New System.Windows.Forms.ComboBox()
        Me.cboAirCarrCode = New System.Windows.Forms.ComboBox()
        Me.txtINCourTrack = New System.Windows.Forms.TextBox()
        Me.txtINIMEI = New System.Windows.Forms.TextBox()
        Me.cboAPC = New System.Windows.Forms.ComboBox()
        Me.lblReturnCode = New System.Windows.Forms.Label()
        Me.lblComplaint = New System.Windows.Forms.Label()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.lblMinNumber = New System.Windows.Forms.Label()
        Me.lblCarrModelCode = New System.Windows.Forms.Label()
        Me.lblTransceiverCode = New System.Windows.Forms.Label()
        Me.lblTransactionCode = New System.Windows.Forms.Label()
        Me.lblAirCarrCode = New System.Windows.Forms.Label()
        Me.lblINCourTrack = New System.Windows.Forms.Label()
        Me.lblINIMEI = New System.Windows.Forms.Label()
        Me.lblAPC = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tpRMA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpDevice.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(16, 13)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
        Me.lblCustomer.TabIndex = 0
        Me.lblCustomer.Text = "Customer:"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRMA
        '
        Me.lblRMA.Location = New System.Drawing.Point(296, 13)
        Me.lblRMA.Name = "lblRMA"
        Me.lblRMA.Size = New System.Drawing.Size(56, 16)
        Me.lblRMA.TabIndex = 1
        Me.lblRMA.Text = "RMA:"
        Me.lblRMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustomer
        '
        Me.cboCustomer.Location = New System.Drawing.Point(72, 8)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cboCustomer.TabIndex = 2
        '
        'txtRMA
        '
        Me.txtRMA.Location = New System.Drawing.Point(352, 9)
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(152, 20)
        Me.txtRMA.TabIndex = 3
        Me.txtRMA.Text = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpRMA, Me.tpDevice})
        Me.TabControl1.Location = New System.Drawing.Point(16, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(712, 424)
        Me.TabControl1.TabIndex = 4
        '
        'tpRMA
        '
        Me.tpRMA.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDocDate, Me.lblDocDate, Me.btnRMAupdate, Me.txtSKU, Me.lblSKU, Me.txtRAqty, Me.txtIp, Me.txtPrl, Me.txtQty, Me.lblRAqty, Me.lblIp, Me.lblPrl, Me.lblQty, Me.GroupBox1, Me.lblManufacturer, Me.cboModel, Me.cboManufacturer, Me.lblModel})
        Me.tpRMA.Location = New System.Drawing.Point(4, 22)
        Me.tpRMA.Name = "tpRMA"
        Me.tpRMA.Size = New System.Drawing.Size(704, 398)
        Me.tpRMA.TabIndex = 0
        Me.tpRMA.Text = "RMA Specific"
        '
        'txtDocDate
        '
        Me.txtDocDate.Location = New System.Drawing.Point(144, 208)
        Me.txtDocDate.Name = "txtDocDate"
        Me.txtDocDate.TabIndex = 18
        Me.txtDocDate.Text = ""
        '
        'lblDocDate
        '
        Me.lblDocDate.Location = New System.Drawing.Point(88, 212)
        Me.lblDocDate.Name = "lblDocDate"
        Me.lblDocDate.Size = New System.Drawing.Size(56, 16)
        Me.lblDocDate.TabIndex = 17
        Me.lblDocDate.Text = "Doc Date:"
        Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRMAupdate
        '
        Me.btnRMAupdate.Location = New System.Drawing.Point(144, 344)
        Me.btnRMAupdate.Name = "btnRMAupdate"
        Me.btnRMAupdate.Size = New System.Drawing.Size(216, 32)
        Me.btnRMAupdate.TabIndex = 16
        Me.btnRMAupdate.Text = "UPDATE"
        '
        'txtSKU
        '
        Me.txtSKU.Location = New System.Drawing.Point(144, 304)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.TabIndex = 15
        Me.txtSKU.Text = ""
        '
        'lblSKU
        '
        Me.lblSKU.Location = New System.Drawing.Point(112, 304)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(32, 16)
        Me.lblSKU.TabIndex = 14
        Me.lblSKU.Text = "SKU:"
        Me.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRAqty
        '
        Me.txtRAqty.Location = New System.Drawing.Point(144, 184)
        Me.txtRAqty.Name = "txtRAqty"
        Me.txtRAqty.TabIndex = 9
        Me.txtRAqty.Text = ""
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(144, 160)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.TabIndex = 8
        Me.txtIp.Text = ""
        '
        'txtPrl
        '
        Me.txtPrl.Location = New System.Drawing.Point(144, 136)
        Me.txtPrl.Name = "txtPrl"
        Me.txtPrl.TabIndex = 7
        Me.txtPrl.Text = ""
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(144, 112)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.TabIndex = 6
        Me.txtQty.Text = ""
        '
        'lblRAqty
        '
        Me.lblRAqty.Location = New System.Drawing.Point(88, 188)
        Me.lblRAqty.Name = "lblRAqty"
        Me.lblRAqty.Size = New System.Drawing.Size(56, 16)
        Me.lblRAqty.TabIndex = 5
        Me.lblRAqty.Text = "RA QTY:"
        Me.lblRAqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIp
        '
        Me.lblIp.Location = New System.Drawing.Point(88, 164)
        Me.lblIp.Name = "lblIp"
        Me.lblIp.Size = New System.Drawing.Size(56, 16)
        Me.lblIp.TabIndex = 4
        Me.lblIp.Text = "IP:"
        Me.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrl
        '
        Me.lblPrl.Location = New System.Drawing.Point(88, 140)
        Me.lblPrl.Name = "lblPrl"
        Me.lblPrl.Size = New System.Drawing.Size(56, 16)
        Me.lblPrl.TabIndex = 3
        Me.lblPrl.Text = "PRL:"
        Me.lblPrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQty
        '
        Me.lblQty.Location = New System.Drawing.Point(88, 116)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(56, 16)
        Me.lblQty.TabIndex = 2
        Me.lblQty.Text = "QTY:"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboShipTo, Me.cboCarrier, Me.lblShipTo, Me.lblCarrier})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 80)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Motorola NSC Specific"
        '
        'cboShipTo
        '
        Me.cboShipTo.Location = New System.Drawing.Point(128, 48)
        Me.cboShipTo.Name = "cboShipTo"
        Me.cboShipTo.Size = New System.Drawing.Size(216, 21)
        Me.cboShipTo.TabIndex = 3
        '
        'cboCarrier
        '
        Me.cboCarrier.Location = New System.Drawing.Point(128, 16)
        Me.cboCarrier.Name = "cboCarrier"
        Me.cboCarrier.Size = New System.Drawing.Size(216, 21)
        Me.cboCarrier.TabIndex = 2
        '
        'lblShipTo
        '
        Me.lblShipTo.Location = New System.Drawing.Point(80, 48)
        Me.lblShipTo.Name = "lblShipTo"
        Me.lblShipTo.Size = New System.Drawing.Size(48, 16)
        Me.lblShipTo.TabIndex = 1
        Me.lblShipTo.Text = "Ship To:"
        Me.lblShipTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCarrier
        '
        Me.lblCarrier.Location = New System.Drawing.Point(80, 24)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(48, 16)
        Me.lblCarrier.TabIndex = 0
        Me.lblCarrier.Text = "Carrier:"
        Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblManufacturer
        '
        Me.lblManufacturer.Location = New System.Drawing.Point(64, 240)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(80, 16)
        Me.lblManufacturer.TabIndex = 14
        Me.lblManufacturer.Text = "Manufacturer:"
        Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboModel
        '
        Me.cboModel.Location = New System.Drawing.Point(144, 256)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(216, 21)
        Me.cboModel.TabIndex = 17
        '
        'cboManufacturer
        '
        Me.cboManufacturer.Location = New System.Drawing.Point(144, 232)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(216, 21)
        Me.cboManufacturer.TabIndex = 16
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(72, 264)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(72, 16)
        Me.lblModel.TabIndex = 15
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpDevice
        '
        Me.tpDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTransactionCode, Me.cboAirCarrCode, Me.txtINCourTrack, Me.txtINIMEI, Me.cboAPC, Me.lblReturnCode, Me.lblComplaint, Me.lblProductCode, Me.lblMinNumber, Me.lblCarrModelCode, Me.lblTransceiverCode, Me.lblTransactionCode, Me.lblAirCarrCode, Me.lblINCourTrack, Me.lblINIMEI, Me.lblAPC})
        Me.tpDevice.Location = New System.Drawing.Point(4, 22)
        Me.tpDevice.Name = "tpDevice"
        Me.tpDevice.Size = New System.Drawing.Size(704, 398)
        Me.tpDevice.TabIndex = 1
        Me.tpDevice.Text = "Device Specific"
        '
        'cboTransactionCode
        '
        Me.cboTransactionCode.Location = New System.Drawing.Point(208, 136)
        Me.cboTransactionCode.Name = "cboTransactionCode"
        Me.cboTransactionCode.Size = New System.Drawing.Size(144, 21)
        Me.cboTransactionCode.TabIndex = 15
        '
        'cboAirCarrCode
        '
        Me.cboAirCarrCode.Location = New System.Drawing.Point(208, 112)
        Me.cboAirCarrCode.Name = "cboAirCarrCode"
        Me.cboAirCarrCode.Size = New System.Drawing.Size(144, 21)
        Me.cboAirCarrCode.TabIndex = 14
        '
        'txtINCourTrack
        '
        Me.txtINCourTrack.Location = New System.Drawing.Point(208, 88)
        Me.txtINCourTrack.Name = "txtINCourTrack"
        Me.txtINCourTrack.Size = New System.Drawing.Size(144, 20)
        Me.txtINCourTrack.TabIndex = 13
        Me.txtINCourTrack.Text = ""
        '
        'txtINIMEI
        '
        Me.txtINIMEI.Location = New System.Drawing.Point(208, 64)
        Me.txtINIMEI.Name = "txtINIMEI"
        Me.txtINIMEI.Size = New System.Drawing.Size(144, 20)
        Me.txtINIMEI.TabIndex = 12
        Me.txtINIMEI.Text = ""
        '
        'cboAPC
        '
        Me.cboAPC.Location = New System.Drawing.Point(208, 40)
        Me.cboAPC.Name = "cboAPC"
        Me.cboAPC.Size = New System.Drawing.Size(144, 21)
        Me.cboAPC.TabIndex = 11
        '
        'lblReturnCode
        '
        Me.lblReturnCode.Location = New System.Drawing.Point(80, 280)
        Me.lblReturnCode.Name = "lblReturnCode"
        Me.lblReturnCode.Size = New System.Drawing.Size(120, 16)
        Me.lblReturnCode.TabIndex = 10
        Me.lblReturnCode.Text = "Return Code:"
        Me.lblReturnCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComplaint
        '
        Me.lblComplaint.Location = New System.Drawing.Point(80, 256)
        Me.lblComplaint.Name = "lblComplaint"
        Me.lblComplaint.Size = New System.Drawing.Size(120, 16)
        Me.lblComplaint.TabIndex = 9
        Me.lblComplaint.Text = "Complaint:"
        Me.lblComplaint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductCode
        '
        Me.lblProductCode.Location = New System.Drawing.Point(80, 232)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(120, 16)
        Me.lblProductCode.TabIndex = 8
        Me.lblProductCode.Text = "Product Code:"
        Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMinNumber
        '
        Me.lblMinNumber.Location = New System.Drawing.Point(80, 208)
        Me.lblMinNumber.Name = "lblMinNumber"
        Me.lblMinNumber.Size = New System.Drawing.Size(120, 16)
        Me.lblMinNumber.TabIndex = 7
        Me.lblMinNumber.Text = "MIN Number:"
        Me.lblMinNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCarrModelCode
        '
        Me.lblCarrModelCode.Location = New System.Drawing.Point(80, 184)
        Me.lblCarrModelCode.Name = "lblCarrModelCode"
        Me.lblCarrModelCode.Size = New System.Drawing.Size(120, 16)
        Me.lblCarrModelCode.TabIndex = 6
        Me.lblCarrModelCode.Text = "Carrier Model Code:"
        Me.lblCarrModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransceiverCode
        '
        Me.lblTransceiverCode.Location = New System.Drawing.Point(80, 160)
        Me.lblTransceiverCode.Name = "lblTransceiverCode"
        Me.lblTransceiverCode.Size = New System.Drawing.Size(120, 16)
        Me.lblTransceiverCode.TabIndex = 5
        Me.lblTransceiverCode.Text = "Transceiver Code:"
        Me.lblTransceiverCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransactionCode
        '
        Me.lblTransactionCode.Location = New System.Drawing.Point(80, 136)
        Me.lblTransactionCode.Name = "lblTransactionCode"
        Me.lblTransactionCode.Size = New System.Drawing.Size(120, 16)
        Me.lblTransactionCode.TabIndex = 4
        Me.lblTransactionCode.Text = "Transaction Code:"
        Me.lblTransactionCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAirCarrCode
        '
        Me.lblAirCarrCode.Location = New System.Drawing.Point(80, 112)
        Me.lblAirCarrCode.Name = "lblAirCarrCode"
        Me.lblAirCarrCode.Size = New System.Drawing.Size(120, 16)
        Me.lblAirCarrCode.TabIndex = 3
        Me.lblAirCarrCode.Text = "AirTime Carrier Code:"
        Me.lblAirCarrCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblINCourTrack
        '
        Me.lblINCourTrack.Location = New System.Drawing.Point(80, 88)
        Me.lblINCourTrack.Name = "lblINCourTrack"
        Me.lblINCourTrack.Size = New System.Drawing.Size(120, 16)
        Me.lblINCourTrack.TabIndex = 2
        Me.lblINCourTrack.Text = "Courier Tracking IN:"
        Me.lblINCourTrack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblINIMEI
        '
        Me.lblINIMEI.Location = New System.Drawing.Point(80, 64)
        Me.lblINIMEI.Name = "lblINIMEI"
        Me.lblINIMEI.Size = New System.Drawing.Size(120, 16)
        Me.lblINIMEI.TabIndex = 1
        Me.lblINIMEI.Text = "Incoming IMEI:"
        Me.lblINIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAPC
        '
        Me.lblAPC.Location = New System.Drawing.Point(80, 40)
        Me.lblAPC.Name = "lblAPC"
        Me.lblAPC.Size = New System.Drawing.Size(120, 16)
        Me.lblAPC.TabIndex = 0
        Me.lblAPC.Text = "APC:"
        Me.lblAPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPreloadCELL
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(790, 501)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.txtRMA, Me.cboCustomer, Me.lblRMA, Me.lblCustomer})
        Me.Name = "frmPreloadCELL"
        Me.Text = "Pre Load Cellular"
        Me.TabControl1.ResumeLayout(False)
        Me.tpRMA.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tpDevice.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub lblPrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPrl.Click

    End Sub
    Private Sub tpRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpRMA.Click

    End Sub
    Private Sub lblRAqty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRAqty.Click

    End Sub
    Private Sub lblIp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIp.Click

    End Sub
    Private Sub lblQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblQty.Click

    End Sub

    Private Sub frmPreloadCELL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
