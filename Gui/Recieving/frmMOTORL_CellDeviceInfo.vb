Imports PSS.Core
Imports PSS.Data


Namespace Gui.Receiving

    Public Class frmMOTORL_CellDeviceInfo
        Inherits System.Windows.Forms.Form

        Public tmpCellCustomer, tmpCellDateCode, tmpCellPOP, tmpCellProdCode, tmpCellMSN, tmpCellModel As String
        Private arrCustomerReason(10000, 2) As String

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
        Friend WithEvents lblCustomerName As System.Windows.Forms.Label
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents cboDateCode As System.Windows.Forms.ComboBox
        Friend WithEvents lblPOP As System.Windows.Forms.Label
        Friend WithEvents txtPOP As System.Windows.Forms.TextBox
        Friend WithEvents grpMotorola As System.Windows.Forms.GroupBox
        Friend WithEvents lblMSN As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents txtMSN As System.Windows.Forms.TextBox
        Friend WithEvents txtModel As System.Windows.Forms.TextBox
        Friend WithEvents lblProductCode As System.Windows.Forms.Label
        Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents lblPOPexplain As System.Windows.Forms.Label
        Friend WithEvents lblExp As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents txtWarrantyClaimNum As System.Windows.Forms.TextBox
        Friend WithEvents txtRMANum As System.Windows.Forms.TextBox
        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dteExpShipDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtIncomingIMEI As System.Windows.Forms.TextBox
        Friend WithEvents txtPicassoNum As System.Windows.Forms.TextBox
        Friend WithEvents txtCarModelCode As System.Windows.Forms.TextBox
        Friend WithEvents txtTransCode As System.Windows.Forms.TextBox
        Friend WithEvents txtProd_APCCode As System.Windows.Forms.TextBox
        Friend WithEvents cboTransCode As System.Windows.Forms.ComboBox
        Friend WithEvents cboAirCarrCode As System.Windows.Forms.ComboBox
        Friend WithEvents txtCustRef As System.Windows.Forms.TextBox
        Friend WithEvents txtCourierTrackIN As System.Windows.Forms.TextBox
        Friend WithEvents lblWarrantyClaimNumber As System.Windows.Forms.Label
        Friend WithEvents lblRMANumber As System.Windows.Forms.Label
        Friend WithEvents lblExpectedShipTime As System.Windows.Forms.Label
        Friend WithEvents lblExpectedShipDate As System.Windows.Forms.Label
        Friend WithEvents lblIncomingIMEI As System.Windows.Forms.Label
        Friend WithEvents lblPicassoNumber As System.Windows.Forms.Label
        Friend WithEvents lblCarrierModelCode As System.Windows.Forms.Label
        Friend WithEvents lblTransceiverCode As System.Windows.Forms.Label
        Friend WithEvents lblProductAPCCode As System.Windows.Forms.Label
        Friend WithEvents lblTransactionCode As System.Windows.Forms.Label
        Friend WithEvents lblAirtimeCarrierCode As System.Windows.Forms.Label
        Friend WithEvents lblCustomerReference As System.Windows.Forms.Label
        Friend WithEvents lblCourierTrackingIn As System.Windows.Forms.Label
        Friend WithEvents lblAPCDetail As System.Windows.Forms.Label
        Friend WithEvents txtCarrModelCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCarrModelCode As System.Windows.Forms.Label
        Friend WithEvents txtMIN As System.Windows.Forms.TextBox
        Friend WithEvents lblMIN As System.Windows.Forms.Label
        Friend WithEvents lblCustomerReason As System.Windows.Forms.Label
        Friend WithEvents cboCustomerReason As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblCustomerReasonNameString As System.Windows.Forms.Label
        Friend WithEvents cboProd_APCCode As System.Windows.Forms.ComboBox
        Friend WithEvents lblPOPformat As System.Windows.Forms.Label
        Friend WithEvents lblMotorola As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblCustomerName = New System.Windows.Forms.Label()
            Me.txtCustomerName = New System.Windows.Forms.TextBox()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.cboDateCode = New System.Windows.Forms.ComboBox()
            Me.lblPOP = New System.Windows.Forms.Label()
            Me.txtPOP = New System.Windows.Forms.TextBox()
            Me.grpMotorola = New System.Windows.Forms.GroupBox()
            Me.lblCustomerReasonNameString = New System.Windows.Forms.Label()
            Me.cboCustomerReason = New PSS.Gui.Controls.ComboBox()
            Me.lblCustomerReason = New System.Windows.Forms.Label()
            Me.txtMIN = New System.Windows.Forms.TextBox()
            Me.lblMIN = New System.Windows.Forms.Label()
            Me.txtCarrModelCode = New System.Windows.Forms.TextBox()
            Me.lblCarrModelCode = New System.Windows.Forms.Label()
            Me.lblAPCDetail = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.txtWarrantyClaimNum = New System.Windows.Forms.TextBox()
            Me.txtRMANum = New System.Windows.Forms.TextBox()
            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
            Me.dteExpShipDate = New System.Windows.Forms.DateTimePicker()
            Me.txtIncomingIMEI = New System.Windows.Forms.TextBox()
            Me.txtPicassoNum = New System.Windows.Forms.TextBox()
            Me.txtCarModelCode = New System.Windows.Forms.TextBox()
            Me.txtTransCode = New System.Windows.Forms.TextBox()
            Me.txtProd_APCCode = New System.Windows.Forms.TextBox()
            Me.cboTransCode = New System.Windows.Forms.ComboBox()
            Me.cboAirCarrCode = New System.Windows.Forms.ComboBox()
            Me.txtCustRef = New System.Windows.Forms.TextBox()
            Me.txtCourierTrackIN = New System.Windows.Forms.TextBox()
            Me.lblWarrantyClaimNumber = New System.Windows.Forms.Label()
            Me.lblRMANumber = New System.Windows.Forms.Label()
            Me.lblExpectedShipTime = New System.Windows.Forms.Label()
            Me.lblExpectedShipDate = New System.Windows.Forms.Label()
            Me.lblIncomingIMEI = New System.Windows.Forms.Label()
            Me.lblPicassoNumber = New System.Windows.Forms.Label()
            Me.lblCarrierModelCode = New System.Windows.Forms.Label()
            Me.lblTransceiverCode = New System.Windows.Forms.Label()
            Me.lblProductAPCCode = New System.Windows.Forms.Label()
            Me.lblTransactionCode = New System.Windows.Forms.Label()
            Me.lblAirtimeCarrierCode = New System.Windows.Forms.Label()
            Me.lblCustomerReference = New System.Windows.Forms.Label()
            Me.lblCourierTrackingIn = New System.Windows.Forms.Label()
            Me.txtModel = New System.Windows.Forms.TextBox()
            Me.txtMSN = New System.Windows.Forms.TextBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblMSN = New System.Windows.Forms.Label()
            Me.txtProductCode = New System.Windows.Forms.TextBox()
            Me.lblProductCode = New System.Windows.Forms.Label()
            Me.cboProd_APCCode = New System.Windows.Forms.ComboBox()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.lblPOPexplain = New System.Windows.Forms.Label()
            Me.lblExp = New System.Windows.Forms.Label()
            Me.lblPOPformat = New System.Windows.Forms.Label()
            Me.lblMotorola = New System.Windows.Forms.Label()
            Me.grpMotorola.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCustomerName
            '
            Me.lblCustomerName.Location = New System.Drawing.Point(16, 16)
            Me.lblCustomerName.Name = "lblCustomerName"
            Me.lblCustomerName.Size = New System.Drawing.Size(96, 16)
            Me.lblCustomerName.TabIndex = 0
            Me.lblCustomerName.Text = "Customer Name:"
            '
            'txtCustomerName
            '
            Me.txtCustomerName.Location = New System.Drawing.Point(112, 16)
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.Size = New System.Drawing.Size(152, 20)
            Me.txtCustomerName.TabIndex = 0
            Me.txtCustomerName.Text = ""
            '
            'lblDateCode
            '
            Me.lblDateCode.Location = New System.Drawing.Point(48, 40)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(64, 16)
            Me.lblDateCode.TabIndex = 2
            Me.lblDateCode.Text = "Date Code"
            '
            'cboDateCode
            '
            Me.cboDateCode.Location = New System.Drawing.Point(112, 40)
            Me.cboDateCode.Name = "cboDateCode"
            Me.cboDateCode.Size = New System.Drawing.Size(80, 21)
            Me.cboDateCode.TabIndex = 1
            '
            'lblPOP
            '
            Me.lblPOP.Location = New System.Drawing.Point(8, 168)
            Me.lblPOP.Name = "lblPOP"
            Me.lblPOP.Size = New System.Drawing.Size(100, 16)
            Me.lblPOP.TabIndex = 6
            Me.lblPOP.Text = "Proof of Purchase:"
            '
            'txtPOP
            '
            Me.txtPOP.Location = New System.Drawing.Point(112, 168)
            Me.txtPOP.Name = "txtPOP"
            Me.txtPOP.Size = New System.Drawing.Size(152, 20)
            Me.txtPOP.TabIndex = 2
            Me.txtPOP.Text = ""
            '
            'grpMotorola
            '
            Me.grpMotorola.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCustomerReasonNameString, Me.cboCustomerReason, Me.lblCustomerReason, Me.txtMIN, Me.lblMIN, Me.txtCarrModelCode, Me.lblCarrModelCode, Me.lblAPCDetail, Me.btnCancel, Me.btnSave, Me.txtWarrantyClaimNum, Me.txtRMANum, Me.DateTimePicker1, Me.dteExpShipDate, Me.txtIncomingIMEI, Me.txtPicassoNum, Me.txtCarModelCode, Me.txtTransCode, Me.txtProd_APCCode, Me.cboTransCode, Me.cboAirCarrCode, Me.txtCustRef, Me.txtCourierTrackIN, Me.lblWarrantyClaimNumber, Me.lblRMANumber, Me.lblExpectedShipTime, Me.lblExpectedShipDate, Me.lblIncomingIMEI, Me.lblPicassoNumber, Me.lblCarrierModelCode, Me.lblTransceiverCode, Me.lblProductAPCCode, Me.lblTransactionCode, Me.lblAirtimeCarrierCode, Me.lblCustomerReference, Me.lblCourierTrackingIn, Me.txtModel, Me.txtMSN, Me.lblModel, Me.lblMSN, Me.txtProductCode, Me.lblProductCode, Me.cboProd_APCCode})
            Me.grpMotorola.Location = New System.Drawing.Point(288, 8)
            Me.grpMotorola.Name = "grpMotorola"
            Me.grpMotorola.Size = New System.Drawing.Size(456, 376)
            Me.grpMotorola.TabIndex = 98
            Me.grpMotorola.TabStop = False
            Me.grpMotorola.Text = "Motorola"
            '
            'lblCustomerReasonNameString
            '
            Me.lblCustomerReasonNameString.Location = New System.Drawing.Point(320, 272)
            Me.lblCustomerReasonNameString.Name = "lblCustomerReasonNameString"
            Me.lblCustomerReasonNameString.Size = New System.Drawing.Size(32, 16)
            Me.lblCustomerReasonNameString.TabIndex = 72
            '
            'cboCustomerReason
            '
            Me.cboCustomerReason.Location = New System.Drawing.Point(160, 272)
            Me.cboCustomerReason.Name = "cboCustomerReason"
            Me.cboCustomerReason.Size = New System.Drawing.Size(152, 21)
            Me.cboCustomerReason.TabIndex = 14
            '
            'lblCustomerReason
            '
            Me.lblCustomerReason.Location = New System.Drawing.Point(64, 272)
            Me.lblCustomerReason.Name = "lblCustomerReason"
            Me.lblCustomerReason.Size = New System.Drawing.Size(100, 16)
            Me.lblCustomerReason.TabIndex = 70
            Me.lblCustomerReason.Text = "Complaint:"
            Me.lblCustomerReason.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtMIN
            '
            Me.txtMIN.Location = New System.Drawing.Point(160, 224)
            Me.txtMIN.Name = "txtMIN"
            Me.txtMIN.TabIndex = 12
            Me.txtMIN.Text = ""
            '
            'lblMIN
            '
            Me.lblMIN.Location = New System.Drawing.Point(24, 224)
            Me.lblMIN.Name = "lblMIN"
            Me.lblMIN.Size = New System.Drawing.Size(136, 16)
            Me.lblMIN.TabIndex = 69
            Me.lblMIN.Text = "MIN Number:"
            Me.lblMIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCarrModelCode
            '
            Me.txtCarrModelCode.Location = New System.Drawing.Point(160, 200)
            Me.txtCarrModelCode.Name = "txtCarrModelCode"
            Me.txtCarrModelCode.TabIndex = 11
            Me.txtCarrModelCode.Text = ""
            '
            'lblCarrModelCode
            '
            Me.lblCarrModelCode.Location = New System.Drawing.Point(24, 200)
            Me.lblCarrModelCode.Name = "lblCarrModelCode"
            Me.lblCarrModelCode.Size = New System.Drawing.Size(136, 16)
            Me.lblCarrModelCode.TabIndex = 67
            Me.lblCarrModelCode.Text = "Carrier Model Code:"
            Me.lblCarrModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAPCDetail
            '
            Me.lblAPCDetail.Location = New System.Drawing.Point(288, 32)
            Me.lblAPCDetail.Name = "lblAPCDetail"
            Me.lblAPCDetail.Size = New System.Drawing.Size(152, 16)
            Me.lblAPCDetail.TabIndex = 65
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(368, 344)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 16
            Me.btnCancel.Text = "&Cancel"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(256, 344)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(104, 23)
            Me.btnSave.TabIndex = 15
            Me.btnSave.Text = "&Save and Sumbit"
            '
            'txtWarrantyClaimNum
            '
            Me.txtWarrantyClaimNum.Location = New System.Drawing.Point(328, 72)
            Me.txtWarrantyClaimNum.Name = "txtWarrantyClaimNum"
            Me.txtWarrantyClaimNum.TabIndex = 15
            Me.txtWarrantyClaimNum.TabStop = False
            Me.txtWarrantyClaimNum.Text = ""
            Me.txtWarrantyClaimNum.Visible = False
            '
            'txtRMANum
            '
            Me.txtRMANum.Location = New System.Drawing.Point(416, 480)
            Me.txtRMANum.Name = "txtRMANum"
            Me.txtRMANum.Size = New System.Drawing.Size(24, 20)
            Me.txtRMANum.TabIndex = 64
            Me.txtRMANum.Text = ""
            Me.txtRMANum.Visible = False
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.DateTimePicker1.Location = New System.Drawing.Point(416, 456)
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.Size = New System.Drawing.Size(24, 20)
            Me.DateTimePicker1.TabIndex = 62
            Me.DateTimePicker1.Visible = False
            '
            'dteExpShipDate
            '
            Me.dteExpShipDate.Location = New System.Drawing.Point(416, 432)
            Me.dteExpShipDate.Name = "dteExpShipDate"
            Me.dteExpShipDate.Size = New System.Drawing.Size(24, 20)
            Me.dteExpShipDate.TabIndex = 60
            Me.dteExpShipDate.Visible = False
            '
            'txtIncomingIMEI
            '
            Me.txtIncomingIMEI.Location = New System.Drawing.Point(160, 56)
            Me.txtIncomingIMEI.Name = "txtIncomingIMEI"
            Me.txtIncomingIMEI.TabIndex = 5
            Me.txtIncomingIMEI.Text = ""
            '
            'txtPicassoNum
            '
            Me.txtPicassoNum.Location = New System.Drawing.Point(248, 480)
            Me.txtPicassoNum.Name = "txtPicassoNum"
            Me.txtPicassoNum.Size = New System.Drawing.Size(24, 20)
            Me.txtPicassoNum.TabIndex = 57
            Me.txtPicassoNum.Text = ""
            Me.txtPicassoNum.Visible = False
            '
            'txtCarModelCode
            '
            Me.txtCarModelCode.Location = New System.Drawing.Point(248, 456)
            Me.txtCarModelCode.Name = "txtCarModelCode"
            Me.txtCarModelCode.Size = New System.Drawing.Size(24, 20)
            Me.txtCarModelCode.TabIndex = 56
            Me.txtCarModelCode.Text = ""
            Me.txtCarModelCode.Visible = False
            '
            'txtTransCode
            '
            Me.txtTransCode.Location = New System.Drawing.Point(160, 176)
            Me.txtTransCode.Name = "txtTransCode"
            Me.txtTransCode.TabIndex = 10
            Me.txtTransCode.Text = ""
            '
            'txtProd_APCCode
            '
            Me.txtProd_APCCode.Location = New System.Drawing.Point(232, 32)
            Me.txtProd_APCCode.Name = "txtProd_APCCode"
            Me.txtProd_APCCode.Size = New System.Drawing.Size(40, 20)
            Me.txtProd_APCCode.TabIndex = 7
            Me.txtProd_APCCode.Text = ""
            Me.txtProd_APCCode.Visible = False
            '
            'cboTransCode
            '
            Me.cboTransCode.Location = New System.Drawing.Point(160, 152)
            Me.cboTransCode.Name = "cboTransCode"
            Me.cboTransCode.Size = New System.Drawing.Size(152, 21)
            Me.cboTransCode.TabIndex = 9
            '
            'cboAirCarrCode
            '
            Me.cboAirCarrCode.Location = New System.Drawing.Point(160, 128)
            Me.cboAirCarrCode.Name = "cboAirCarrCode"
            Me.cboAirCarrCode.Size = New System.Drawing.Size(152, 21)
            Me.cboAirCarrCode.TabIndex = 8
            '
            'txtCustRef
            '
            Me.txtCustRef.Location = New System.Drawing.Point(248, 432)
            Me.txtCustRef.Name = "txtCustRef"
            Me.txtCustRef.Size = New System.Drawing.Size(24, 20)
            Me.txtCustRef.TabIndex = 50
            Me.txtCustRef.Text = ""
            Me.txtCustRef.Visible = False
            '
            'txtCourierTrackIN
            '
            Me.txtCourierTrackIN.Location = New System.Drawing.Point(160, 104)
            Me.txtCourierTrackIN.Name = "txtCourierTrackIN"
            Me.txtCourierTrackIN.TabIndex = 7
            Me.txtCourierTrackIN.Text = ""
            '
            'lblWarrantyClaimNumber
            '
            Me.lblWarrantyClaimNumber.Location = New System.Drawing.Point(296, 56)
            Me.lblWarrantyClaimNumber.Name = "lblWarrantyClaimNumber"
            Me.lblWarrantyClaimNumber.Size = New System.Drawing.Size(136, 16)
            Me.lblWarrantyClaimNumber.TabIndex = 48
            Me.lblWarrantyClaimNumber.Text = "Warranty Claim Number:"
            Me.lblWarrantyClaimNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblWarrantyClaimNumber.Visible = False
            '
            'lblRMANumber
            '
            Me.lblRMANumber.Location = New System.Drawing.Point(280, 480)
            Me.lblRMANumber.Name = "lblRMANumber"
            Me.lblRMANumber.Size = New System.Drawing.Size(136, 16)
            Me.lblRMANumber.TabIndex = 47
            Me.lblRMANumber.Text = "RMA Number:"
            Me.lblRMANumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblRMANumber.Visible = False
            '
            'lblExpectedShipTime
            '
            Me.lblExpectedShipTime.Location = New System.Drawing.Point(280, 456)
            Me.lblExpectedShipTime.Name = "lblExpectedShipTime"
            Me.lblExpectedShipTime.Size = New System.Drawing.Size(136, 16)
            Me.lblExpectedShipTime.TabIndex = 46
            Me.lblExpectedShipTime.Text = "Expected Ship Time:"
            Me.lblExpectedShipTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblExpectedShipTime.Visible = False
            '
            'lblExpectedShipDate
            '
            Me.lblExpectedShipDate.Location = New System.Drawing.Point(280, 432)
            Me.lblExpectedShipDate.Name = "lblExpectedShipDate"
            Me.lblExpectedShipDate.Size = New System.Drawing.Size(136, 16)
            Me.lblExpectedShipDate.TabIndex = 45
            Me.lblExpectedShipDate.Text = "Expected Ship Date:"
            Me.lblExpectedShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblExpectedShipDate.Visible = False
            '
            'lblIncomingIMEI
            '
            Me.lblIncomingIMEI.Location = New System.Drawing.Point(24, 56)
            Me.lblIncomingIMEI.Name = "lblIncomingIMEI"
            Me.lblIncomingIMEI.Size = New System.Drawing.Size(136, 16)
            Me.lblIncomingIMEI.TabIndex = 44
            Me.lblIncomingIMEI.Text = "Incoming IMEI:"
            Me.lblIncomingIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPicassoNumber
            '
            Me.lblPicassoNumber.Location = New System.Drawing.Point(144, 480)
            Me.lblPicassoNumber.Name = "lblPicassoNumber"
            Me.lblPicassoNumber.Size = New System.Drawing.Size(104, 16)
            Me.lblPicassoNumber.TabIndex = 43
            Me.lblPicassoNumber.Text = "Picasso Number:"
            Me.lblPicassoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPicassoNumber.Visible = False
            '
            'lblCarrierModelCode
            '
            Me.lblCarrierModelCode.Location = New System.Drawing.Point(112, 456)
            Me.lblCarrierModelCode.Name = "lblCarrierModelCode"
            Me.lblCarrierModelCode.Size = New System.Drawing.Size(136, 16)
            Me.lblCarrierModelCode.TabIndex = 42
            Me.lblCarrierModelCode.Text = "Carrier Model Code:"
            Me.lblCarrierModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCarrierModelCode.Visible = False
            '
            'lblTransceiverCode
            '
            Me.lblTransceiverCode.Location = New System.Drawing.Point(24, 176)
            Me.lblTransceiverCode.Name = "lblTransceiverCode"
            Me.lblTransceiverCode.Size = New System.Drawing.Size(136, 16)
            Me.lblTransceiverCode.TabIndex = 41
            Me.lblTransceiverCode.Text = "Transceiver Code:"
            Me.lblTransceiverCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProductAPCCode
            '
            Me.lblProductAPCCode.Location = New System.Drawing.Point(24, 32)
            Me.lblProductAPCCode.Name = "lblProductAPCCode"
            Me.lblProductAPCCode.Size = New System.Drawing.Size(136, 16)
            Me.lblProductAPCCode.TabIndex = 40
            Me.lblProductAPCCode.Text = "Product/ APC Code:"
            Me.lblProductAPCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTransactionCode
            '
            Me.lblTransactionCode.Location = New System.Drawing.Point(24, 152)
            Me.lblTransactionCode.Name = "lblTransactionCode"
            Me.lblTransactionCode.Size = New System.Drawing.Size(136, 16)
            Me.lblTransactionCode.TabIndex = 39
            Me.lblTransactionCode.Text = "Transaction Code:"
            Me.lblTransactionCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAirtimeCarrierCode
            '
            Me.lblAirtimeCarrierCode.Location = New System.Drawing.Point(24, 128)
            Me.lblAirtimeCarrierCode.Name = "lblAirtimeCarrierCode"
            Me.lblAirtimeCarrierCode.Size = New System.Drawing.Size(136, 18)
            Me.lblAirtimeCarrierCode.TabIndex = 38
            Me.lblAirtimeCarrierCode.Text = "Airtime Carrier Code:"
            Me.lblAirtimeCarrierCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomerReference
            '
            Me.lblCustomerReference.Location = New System.Drawing.Point(136, 432)
            Me.lblCustomerReference.Name = "lblCustomerReference"
            Me.lblCustomerReference.Size = New System.Drawing.Size(112, 16)
            Me.lblCustomerReference.TabIndex = 37
            Me.lblCustomerReference.Text = "Customer Reference:"
            Me.lblCustomerReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblCustomerReference.Visible = False
            '
            'lblCourierTrackingIn
            '
            Me.lblCourierTrackingIn.Location = New System.Drawing.Point(24, 104)
            Me.lblCourierTrackingIn.Name = "lblCourierTrackingIn"
            Me.lblCourierTrackingIn.Size = New System.Drawing.Size(136, 16)
            Me.lblCourierTrackingIn.TabIndex = 36
            Me.lblCourierTrackingIn.Text = "Courier Tracking IN:"
            Me.lblCourierTrackingIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtModel
            '
            Me.txtModel.Location = New System.Drawing.Point(160, 80)
            Me.txtModel.Name = "txtModel"
            Me.txtModel.TabIndex = 6
            Me.txtModel.Text = ""
            '
            'txtMSN
            '
            Me.txtMSN.Location = New System.Drawing.Point(328, 96)
            Me.txtMSN.Name = "txtMSN"
            Me.txtMSN.TabIndex = 9
            Me.txtMSN.TabStop = False
            Me.txtMSN.Text = ""
            Me.txtMSN.Visible = False
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(24, 80)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(136, 16)
            Me.lblModel.TabIndex = 11
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMSN
            '
            Me.lblMSN.Location = New System.Drawing.Point(296, 96)
            Me.lblMSN.Name = "lblMSN"
            Me.lblMSN.Size = New System.Drawing.Size(32, 16)
            Me.lblMSN.TabIndex = 10
            Me.lblMSN.Text = "MSN:"
            Me.lblMSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblMSN.Visible = False
            '
            'txtProductCode
            '
            Me.txtProductCode.Location = New System.Drawing.Point(160, 248)
            Me.txtProductCode.Name = "txtProductCode"
            Me.txtProductCode.Size = New System.Drawing.Size(56, 20)
            Me.txtProductCode.TabIndex = 13
            Me.txtProductCode.Text = ""
            '
            'lblProductCode
            '
            Me.lblProductCode.Location = New System.Drawing.Point(80, 248)
            Me.lblProductCode.Name = "lblProductCode"
            Me.lblProductCode.Size = New System.Drawing.Size(80, 16)
            Me.lblProductCode.TabIndex = 11
            Me.lblProductCode.Text = "Product Code:"
            Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProd_APCCode
            '
            Me.cboProd_APCCode.Location = New System.Drawing.Point(160, 32)
            Me.cboProd_APCCode.Name = "cboProd_APCCode"
            Me.cboProd_APCCode.Size = New System.Drawing.Size(64, 21)
            Me.cboProd_APCCode.TabIndex = 4
            '
            'btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(120, 368)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(160, 23)
            Me.btnAdd.TabIndex = 10
            Me.btnAdd.TabStop = False
            Me.btnAdd.Text = "Submit"
            Me.btnAdd.Visible = False
            '
            'lblPOPexplain
            '
            Me.lblPOPexplain.ForeColor = System.Drawing.Color.Blue
            Me.lblPOPexplain.Location = New System.Drawing.Point(16, 80)
            Me.lblPOPexplain.Name = "lblPOPexplain"
            Me.lblPOPexplain.Size = New System.Drawing.Size(264, 48)
            Me.lblPOPexplain.TabIndex = 11
            Me.lblPOPexplain.Text = "Date code fall out of warranty. Please enter a proof of purchase date so that war" & _
            "ranty status may be determined."
            Me.lblPOPexplain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblExp
            '
            Me.lblExp.Location = New System.Drawing.Point(200, 48)
            Me.lblExp.Name = "lblExp"
            Me.lblExp.Size = New System.Drawing.Size(72, 16)
            Me.lblExp.TabIndex = 12
            '
            'lblPOPformat
            '
            Me.lblPOPformat.Location = New System.Drawing.Point(112, 152)
            Me.lblPOPformat.Name = "lblPOPformat"
            Me.lblPOPformat.Size = New System.Drawing.Size(100, 16)
            Me.lblPOPformat.TabIndex = 13
            Me.lblPOPformat.Text = "(yyyy-mm-dd)"
            '
            'lblMotorola
            '
            Me.lblMotorola.Font = New System.Drawing.Font("Verdana", 20.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMotorola.ForeColor = System.Drawing.Color.Blue
            Me.lblMotorola.Location = New System.Drawing.Point(40, 224)
            Me.lblMotorola.Name = "lblMotorola"
            Me.lblMotorola.Size = New System.Drawing.Size(200, 32)
            Me.lblMotorola.TabIndex = 99
            Me.lblMotorola.Text = "MOTOROLA"
            '
            'frmMOTORL_CellDeviceInfo
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(754, 399)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMotorola, Me.lblPOPformat, Me.lblExp, Me.lblPOPexplain, Me.btnAdd, Me.txtPOP, Me.lblPOP, Me.cboDateCode, Me.lblDateCode, Me.txtCustomerName, Me.lblCustomerName, Me.grpMotorola})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmMOTORL_CellDeviceInfo"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "frmCellDeviceInfo"
            Me.grpMotorola.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '    Dim cn As New OleDbConnection(ProductionConnString)
        Public ManufIDint As Integer
        Public ManufName, ManufFlag, ManufID, ModelID, valCustomerName, valDateCode, valPOP As String
        Public valProductCode, valMSN, valModel, valWrty As String
        Public arrDateCode(5000, 2) As String
        Public arrTransaction(1000, 1) As String
        Public arrAPC(1000, 3) As String
        Public arrCarrier(1000, 1) As String
        Public woCustWO As String

        'These are used to get data from the Receiving Screen
        Public Shared cellAddressID As String
        Public Shared cellCounter As Integer
        Public Shared cellDeviceSN As String
        Public Shared cellVALtray As Int32
        Public Shared cellVALworkorder As Int32
        Public Shared cellVALmodel As Int32
        Public Shared cellVALlaborcharge As Int32
        Public Shared cellCHKdbr As CheckBox
        Public Shared cellLBLdateval As String
        Public Shared cellVALwrty As Integer
        Public Shared cellVALoldSN As String
        Public Shared cellPSSwarranty As Boolean
        Public Shared deviceSN As String
        Public Shared vMWrty As Integer
        Private cellType As String
        Private txtAPCType As String
        Private txtDateCodeType As String
        Private valCSNdecimal As String

        Private Sub frmCellDeviceInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'cellAddressID = ""
            'cellCounter = 0
            'cellDeviceSN = ""
            'cellVALtray = 0
            'cellVALworkorder = 0
            'cellVALmodel = 0
            'cellVALlaborcharge = 0
            'cellCHKdbr.Checked = False
            'cellLBLdateval = ""
            'cellVALwrty = 0
            'cellVALoldSN = ""
            'cellPSSwarranty = 0
            cellType = "CSN"
            valWrty = False
            PopulateDateCode()

            If Len(ManufFlag) < 1 Then
                DisplayPOP()
                HideDateCode()
            End If
            'DisplayGroup()
            '//New September 5
            'HideGroup()
            '//End New September 5
            Highlight.SetHighLight(Me)
            'MotorolaGroupHide()
            PopulateTransaction()
            PopulateCarrier()
            PopulateDateCode()
            PopulateComplaints()
            PopulateAPC()

            Dim xCount As Integer = 0
            If ManufName = "Motorola" Then

                '//NEW CODE January 14, 2004
                If Len(Trim(frmMOTORL_Receiving.coDeviceSN)) < 1 Or Len(Trim(ModelID)) < 1 Then
                    'MsgBox("The system can not determine the values for APC and Date Code, please enter them manually.", MsgBoxStyle.OKOnly)
                End If

                'Get APC code from passed in Model ID
                Dim txtAPCCode As String
                'Dim txtAPCType As String

                If Len(Trim(ModelID)) > 0 Then
                    Dim tModel As New PSS.Data.Production.tmodel()
                    Dim drModel As DataRow = tModel.GetRowByModel(ModelID)
                    Dim txtDcode As Int32 = drModel("DCode_ID")
                    If txtDcode > 0 Then

                        Dim tCode As New PSS.Data.Production.lcodesdetail()
                        Dim drCode As DataRow = tCode.GetRowByDCode(txtDcode)
                        txtAPCCode = drCode("DCode_SDesc")
                        txtAPCType = drCode("DCode_L2Desc")
                        tModel = Nothing
                        tCode = Nothing



                    End If
                End If
                'Verify APC Code exists and is in combobox


APCcode:
                If Len(Trim(txtAPCCode)) > 0 Then
                    Dim blnAPC As Boolean = False
                    For xCount = 0 To cboProd_APCCode.Items.Count - 1
                        If cboProd_APCCode.Items(xCount) = txtAPCCode Then
                            blnAPC = True
                            Exit For
                        End If
                    Next
                    If blnAPC = False Then
                        MsgBox("The APC Code is invalid, please enter manually.", MsgBoxStyle.OKOnly)
                        txtAPCCode = InputBox("Enter APC Code", "APC Code")
                        If Len(Trim(txtAPCCode)) > 0 Then GoTo APCcode
                    Else
                        'Set APC code in combobox
                        cboProd_APCCode.Text = txtAPCCode
                        txtProd_APCCode.Text = txtAPCCode
                    End If
                End If

                'Determine date code format
                If txtAPCType = "GSM/PCS" Then
                    txtDateCodeType = "GSM"
                Else
                    txtDateCodeType = "CSN"
                End If
                'Get Date Code
                Dim txtDateCode As String = ""
                If txtDateCodeType = "CSN" Then
                    If Len(Trim(frmMOTORL_Receiving.coDeviceSN)) > 7 Then
                        txtDateCode = Mid$(Trim(frmMOTORL_Receiving.coDeviceSN), 9, 3)
                        'Make hex code conversion here
                        Dim valHex As String = Mid$(Trim(frmMOTORL_Receiving.coDeviceSN), 1, 8)
                        Dim vals1 As String = Mid$(Trim(frmMOTORL_Receiving.coDeviceSN), 1, 2)
                        Dim vals2 As String = Mid$(Trim(frmMOTORL_Receiving.coDeviceSN), 3, 6)

                        Dim valDec1 As System.UInt32
                        valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
                        Dim valDec2 As System.UInt32
                        valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

                        Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
                        Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
                        valCSNdecimal = v1 & v2
                    End If
                ElseIf txtDateCodeType = "GSM" Then
                    If Len(Trim(frmMOTORL_Receiving.coDeviceSN)) > 5 Then
                        txtDateCode = Mid$(Trim(frmMOTORL_Receiving.coDeviceSN), 5, 2) & "J"
                    End If
                End If
                'Assign Date Code to combobox
                'Verify Date Code exists and is in combobox

                If txtDateCodeType = "GSM" Then
                    'txtIncomingIMEI.Focus()
                Else
                    lblIncomingIMEI.Visible = False
                    txtIncomingIMEI.Visible = False
                    'txtMSN.Focus()
                End If

DateCode:
                If Len(Trim(txtDateCode)) > 0 Then
                    Dim blnDC As Boolean = False
                    For xCount = 0 To cboDateCode.Items.Count - 1
                        If cboDateCode.Items(xCount) = txtDateCode Then
                            blnDC = True
                            Exit For
                        End If
                    Next

                    If blnDC = False Then
                        'MsgBox("The Date Code is invalid, please enter manually.", MsgBoxStyle.OKOnly)
                        'txtDateCode = InputBox("Enter Date Code", "Date Code")
                        'If Len(Trim(txtDateCode)) > 0 Then GoTo datecode
                    Else
                        'Set Date code in combobox
                        cboDateCode.Text = txtDateCode
                    End If
                End If

                '/These are hard coded values -START
                'cboProd_APCCode.Text = "C62"
                'txtCourierTrackIN.Text = "Roadrunner"
                'txtTransCode.Text = ""
                'txtCarrModelCode.Text = ""
                'txtMIN.Text = ""
                'cboAirCarrCode.Text = "Qwest"
                'cboTransCode.Text = "Refurbish and Repair"
                'cboCustomerReason.Text = "No Complaint Given"
                btnSave.Focus()
                '/These are hard coded values -END
                '//NEW CODE January 14, 2004

                lblProductCode.Visible = False
                txtProductCode.Visible = False

                If Trim(UCase(woCustWO)) = "120EVZWPSSI5.14.04" Then
                    txtCourierTrackIN.Text = "EGL"
                    txtTransCode.Text = ""
                    txtCarrModelCode.Text = ""
                    txtMIN.Text = ""
                    cboAirCarrCode.Text = "Verizon Wireless"
                    cboTransCode.Text = "Refurbish and Repair"
                    cboCustomerReason.Text = "No Complaint Given"
                End If

                If Trim(UCase(woCustWO)) = "120EQWESTPSSI5.14.04" Then
                    txtCourierTrackIN.Text = "EGL"
                    txtTransCode.Text = ""
                    txtCarrModelCode.Text = ""
                    txtMIN.Text = ""
                    cboAirCarrCode.Text = "Qwest"
                    cboTransCode.Text = "Refurbish and Repair"
                    cboCustomerReason.Text = "No Complaint Given"
                End If

                If Trim(UCase(woCustWO)) = "V60PNSCVZWPSSI5.14.04" Then
                    txtCourierTrackIN.Text = "EGL"
                    txtTransCode.Text = ""
                    txtCarrModelCode.Text = ""
                    txtMIN.Text = ""
                    cboAirCarrCode.Text = "Verizon Wireless"
                    cboTransCode.Text = "Refurbish and Repair"
                    cboCustomerReason.Text = "No Complaint Given"
                End If

                ''//This is new September 11, 2003
                'Dim txtAPC As String
                'Dim txtDC As String
                'If Len(Trim(deviceSN)) < 15 Then
                ''//Device is CDMA/TDMA
                'txtAPC = InputBox("Enter APC code for this device.", "APC")

                'txtProd_APCCode.Text = txtAPC

                'If Len(txtAPC) < 11 Then
                ''//Can not get date code invalid
                ''MsgBox("Can not determine date code value, field is too short")
                'txtDC = ""
                'Else
                'txtDC = Mid$(txtAPC, 9, 3)
                'Me.cboDateCode.Text = txtDC
                'Me.txtProd_APCCode.Text = txtAPC
                'Me.txtProd_APCCode.Enabled = False

                ''//test to see if date code is out of warranty if so then...
                'txtPOP.Enabled = True
                'txtPOP.Focus()
                'txtProd_APCCode.Enabled = False
                'cboDateCode.Enabled = False
                'End If
                'Else
                ''//Device is GSM
                'Dim txtMSN As String
                ''txtMSN = InputBox("Enter MSN code for this device.", "MSN")
                ''txtMSN.text = txtMSN

                'If Len(Trim(txtMSN)) < 7 Then
                ''//Can not get date code invalid
                'MsgBox("Can not determine date code value, field is too short")
                'txtDC = ""
                'Else
                'txtDC = Mid$(txtMSN, 5, 2)
                'Me.cboDateCode.Text = txtDC
                'cboDateCode.Enabled = False
                'End If
                txtPOP.Enabled = True
                txtPOP.Focus()
                'End If

            ElseIf ManufName = "Nokia" Then
                lblDateCode.Visible = True
                cboDateCode.Visible = True
            ElseIf ManufName = "Sony/Ericsson" Then
                lblDateCode.Visible = True
                cboDateCode.Visible = True
            Else
                lblDateCode.Visible = True
                cboDateCode.Visible = True
            End If

            'Dim txtCSN As String
            'txtCSN = InputBox("Enter CSN Value for this device.", "CSN")
            'frmMOTORL_Receiving.vcCSN = txtCSN
            ''//Place new code in here to determine date code and such....

            grpMotorola.Visible = True


        End Sub

        Private Sub HideDateCode()

            'This will hide all the controls relating to the Date Code.

            cboDateCode.Visible = False
            lblDateCode.Visible = False
            lblPOPexplain.Visible = False

        End Sub

        Public Sub HideInitElements()

            'This sub is defined as Public because it needs to be called from the parent.
            'This section hides all the initial elements on the form. 
            'These elements are only displayed is certain criteria is met.

            lblPOP.Visible = False
            lblPOPformat.Visible = False
            txtPOP.Visible = False
            lblPOPexplain.Visible = False

            grpMotorola.Visible = False
            'grpNokia.Visible = False

        End Sub

        Private Sub PopulateDateCode()

            'This will generate the data for the cboDateCode control.
            'It will also create a two dimensional array that holds the date codes
            'and expiration dates

            Dim xCount As Integer = 0
            Dim addCount As Integer = 0

            Dim tblManufWrty As New PSS.Data.Production.lmanufwrty()
            'Dim dsManufWrty As DataSet = tblManufWrty.GetData
            Dim dsManufWrty As DataTable = tblManufWrty.getDateCodeListByDeviceType(ManufIDint, 2)

            Dim rManufWrty As DataRow


            For xCount = 0 To dsManufWrty.Rows.Count - 1
                rManufWrty = dsManufWrty.Rows(xCount)
                If rManufWrty("Manuf_ID") = ManufIDint Then
                    If rManufWrty("Prod_ID") = 2 Then
                        'Add to date code combo box
                        cboDateCode.Items.Add(rManufWrty("ManufWrty_Code"))
                        arrDateCode(addCount, 0) = rManufWrty("ManufWrty_Code")
                        If IsDBNull(rManufWrty("ManufWrty_Exp")) = False Then
                            arrDateCode(addCount, 1) = rManufWrty("ManufWrty_Exp")
                        End If
                        arrDateCode(addCount, 2) = rManufWrty("ManufWrty_ID")
                        addCount += 1
                    End If
                End If
            Next

            'Craig Haney
            dsManufWrty.Dispose()
            dsManufWrty = Nothing
            'Craig Haney

            '        cn.Open()
            'Dim cmd As New OleDbCommand("Select Distinct Serial_Check, Expiration FROM LT_WARRANTY_NEW Where Manufacturer = '" & ManufFlag & "'", cn)
            'Dim dr As OleDbDataReader = cmd.ExecuteReader

            'xCount = 0

            'Do While dr.Read
            'cboDateCode.Items.Add(dr("Serial_Check"))

            'arrDateCode(xCount, 0) = dr("Serial_Check")
            'arrDateCode(xCount, 1) = dr("Expiration")
            'xCount += 1
            'Loop


            'dr.Close()
            'cn.Close()

        End Sub

        Private Sub DisplayGroup()

            'This will display all the controls relating to the Nokia and Motorola groups.

            HideGroup()

            grpMotorola.Visible = True
            'If ManufFlag = "M" Then grpMotorola.Visible = True
            'If ManufFlag = "N" Then grpNokia.Visible = True
            'If ManufFlag = "N" Then grpMotorola.Visible = True


            If ManufFlag = "M" Then
                grpMotorola.Text = "Motorola"
                lblProductCode.Visible = False
                txtProductCode.Visible = False
            End If


            If ManufFlag = "N" Then
                grpMotorola.Text = "Nokia"
                txtProd_APCCode.Visible = False
                lblProductAPCCode.Visible = False
                txtIncomingIMEI.Visible = True
                lblIncomingIMEI.Visible = True
                'txtMSN.Visible = True
                'lblMSN.Visible = True
                txtModel.Visible = False
                lblModel.Visible = False
                txtCourierTrackIN.Visible = True
                lblCourierTrackingIn.Visible = True
                cboAirCarrCode.Visible = True
                lblAirtimeCarrierCode.Visible = True
                cboTransCode.Visible = False
                lblTransactionCode.Visible = False
                txtTransCode.Visible = False
                lblTransceiverCode.Visible = False
                txtCarrModelCode.Visible = False
                lblCarrModelCode.Visible = False
                txtMIN.Visible = True
                lblMIN.Visible = True
                txtProductCode.Visible = True
                lblProductCode.Visible = True
            End If

            If ManufFlag = "S" Then
                grpMotorola.Text = "Sony / Ericsson"
                txtProd_APCCode.Visible = False
                lblProductAPCCode.Visible = False
                txtIncomingIMEI.Visible = True
                lblIncomingIMEI.Visible = True
                'txtMSN.Visible = True
                'lblMSN.Visible = True
                txtModel.Visible = False
                lblModel.Visible = False
                txtCourierTrackIN.Visible = True
                lblCourierTrackingIn.Visible = True
                cboAirCarrCode.Visible = True
                lblAirtimeCarrierCode.Visible = True
                cboTransCode.Visible = False
                lblTransactionCode.Visible = False
                txtTransCode.Visible = True
                lblTransceiverCode.Visible = True
                txtCarrModelCode.Visible = False
                lblCarrModelCode.Visible = False
                txtMIN.Visible = True
                lblMIN.Visible = True
                txtProductCode.Visible = False
                lblProductCode.Visible = False
            End If

            If ManufFlag = "" Then
                grpMotorola.Text = "Generic"
                txtProd_APCCode.Visible = False
                lblProductAPCCode.Visible = False
                txtIncomingIMEI.Visible = True
                lblIncomingIMEI.Visible = True
                'txtMSN.Visible = True
                'lblMSN.Visible = True
                txtModel.Visible = False
                lblModel.Visible = False
                txtCourierTrackIN.Visible = True
                lblCourierTrackingIn.Visible = True
                cboAirCarrCode.Visible = True
                lblAirtimeCarrierCode.Visible = True
                cboTransCode.Visible = False
                lblTransactionCode.Visible = False
                txtTransCode.Visible = False
                lblTransceiverCode.Visible = False
                txtCarrModelCode.Visible = False
                lblCarrModelCode.Visible = False
                txtMIN.Visible = True
                lblMIN.Visible = True
                txtProductCode.Visible = False
                lblProductCode.Visible = False
            End If


        End Sub

        Private Sub HideGroup()

            'This will hide all the controls relating to the Nokia and Motorola groups.

            grpMotorola.Visible = False
            'grpNokia.Visible = False

        End Sub

        Private Sub DisplayPOP()

            'This will display all the controls relating to the proof of purchase input.

            lblPOP.Visible = True
            lblPOPformat.Visible = True
            lblPOPexplain.Visible = True
            txtPOP.Visible = True
            txtPOP.Focus()

        End Sub

        Private Sub HidePOP()

            'This will hide all the controls relating to the proof of purchase input.

            lblPOP.Visible = False
            lblPOPformat.Visible = False
            lblPOPexplain.Visible = False
            txtPOP.Visible = False

        End Sub

        Private Sub cboDateCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

            '            Dim blnWrty As Boolean

            '            HideGroup()
            '            HidePOP()

            '            blnWrty = GetWarrantyStatus()
            '            If blnWrty = True Then
            '                DisplayGroup()
            '            Else
            '                DisplayPOP()
            '            End If

        End Sub

        Private Function GetWarrantyStatus() As Boolean

            'This will determine if the date code is valid for warranty status.

            HidePOP()

            Dim xCount As Integer
            Dim dteExp As Date

            GetWarrantyStatus = False


            For xCount = 0 To cboDateCode.Items.Count - 1
                If Trim(arrDateCode(xCount, 0).ToString) = Trim(cboDateCode.Text) Then
                    dteExp = arrDateCode(xCount, 1)
                    lblExp.Text = dteExp
                    'Check value of dteExp to see if in warranty
                    If dteExp > Now Or dteExp = Now Then
                        GetWarrantyStatus = True
                        valWrty = True
                        Exit For
                    ElseIf dteExp < Now Then
                        GetWarrantyStatus = False
                        valWrty = False
                        Exit For
                    End If
                End If
            Next

            If Len(dteExp) < 1 Then
                MsgBox("An error has occured while determining warranty status.", MsgBoxStyle.OKOnly)
            End If

        End Function

        Private Function VerifyPOP() As Boolean

            'This will determine if the proof of purchase falls within a 1 year 
            'time from from todays date.

            HideGroup()

            If Len(txtPOP.Text) < 1 Then
                VerifyPOP = False
            ElseIf IsDate(txtPOP.Text) = False Then
                'Value is not a valid date
                VerifyPOP = False
            Else
                'Validate value
                Dim newExp As Date

                newExp = DateAdd(DateInterval.Year, 1, CDate(txtPOP.Text))

                If newExp > Now Or newExp = Now Then
                    VerifyPOP = True
                    valWrty = True
                    DisplayGroup()
                Else
                    VerifyPOP = False
                    valWrty = False
                    DisplayGroup()
                End If
            End If

        End Function

        Private Sub txtPOP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOP.Leave

            valPOP = ""

            Dim verPOP As Boolean

            If UCase(Trim(txtPOP.Text)) = "VOID" Then
                verPOP = True
            Else
                verPOP = VerifyPOP()
            End If

            If verPOP = True Then
                'Set value of txtPOP to public variable
                valPOP = txtPOP.Text
            Else
                txtPOP.Text = ""
            End If
            If ManufFlag = "M" Then
                grpMotorola.Visible = True

                If txtDateCodeType = "GSM" Then
                    Me.lblIncomingIMEI.Visible = True
                    Me.txtIncomingIMEI.Visible = True
                    txtIncomingIMEI.Text = frmMOTORL_Receiving.coDeviceSN
                Else
                    Me.lblIncomingIMEI.Visible = False
                    Me.txtIncomingIMEI.Visible = False
                End If
                'lblMSN.Visible = False
                'txtMSN.Visible = False
                'lblModel.Visible = False
                'txtModel.Visible = False
                'lblProductCode.Visible = False
                'txtProductCode.Visible = False
                'txtProd_APCCode.Focus()
                Me.lblProductAPCCode.Visible = True
                'txtProd_APCCode.Visible = True
                'Me.lblIncomingIMEI.Visible = True
                'txtIncomingIMEI.Visible = True
                'NEW CDH December 17 2003
                'NEW CDH December 17 2003
                'Me.lblMSN.Visible = True
                'txtMSN.Visible = True
                Me.lblMSN.Visible = False
                txtMSN.Visible = False
                Me.lblModel.Visible = True
                txtModel.Visible = True
                Me.lblCourierTrackingIn.Visible = True
                txtCourierTrackIN.Visible = True
                Me.lblAirtimeCarrierCode.Visible = True
                cboAirCarrCode.Visible = True
                Me.lblTransactionCode.Visible = True
                cboTransCode.Visible = True
                Me.lblTransceiverCode.Visible = True
                txtTransCode.Visible = True
                Me.lblCarrModelCode.Visible = True
                txtCarrModelCode.Visible = True
                Me.lblMIN.Visible = True
                txtMIN.Visible = True
                Me.lblProductCode.Visible = False
                txtProductCode.Visible = False
                txtProd_APCCode.Focus()

            ElseIf ManufFlag = "N" Then
                grpMotorola.Visible = True
                grpMotorola.Text = "Nokia"
                'lblProductCode.Visible = True
                'txtProductCode.Visible = True
                'lblTransceiverCode.Visible = True
                'txtTransCode.Visible = True
                'lblIncomingIMEI.Visible = False
                'txtIncomingIMEI.Visible = False
                'txtIncomingIMEI.Focus()
                'lblMSN.Visible = False
                'txtMSN.Visible = False
                'lblProductAPCCode.Visible = False
                'txtProd_APCCode.Visible = False
                'lblTransactionCode.Visible = False
                'cboTransCode.Visible = False
                'lblTransceiverCode.Visible = False
                'txtTransCode.Visible = False
                'txtModel.Focus()

                Me.lblProductAPCCode.Visible = False
                txtProd_APCCode.Visible = False
                Me.lblIncomingIMEI.Visible = False
                txtIncomingIMEI.Visible = False
                Me.lblMSN.Visible = False
                txtMSN.Visible = False
                Me.lblModel.Visible = True
                txtModel.Visible = True
                Me.lblCourierTrackingIn.Visible = True
                txtCourierTrackIN.Visible = True
                Me.lblAirtimeCarrierCode.Visible = True
                cboAirCarrCode.Visible = True
                Me.lblTransactionCode.Visible = False
                cboTransCode.Visible = False
                Me.lblTransceiverCode.Visible = False
                txtTransCode.Visible = False
                Me.lblCarrModelCode.Visible = True
                txtCarrModelCode.Visible = True
                Me.lblMIN.Visible = True
                txtMIN.Visible = True
                Me.lblProductCode.Visible = True
                txtProductCode.Visible = True
                txtModel.Focus()


            ElseIf ManufFlag = "S" Then
                grpMotorola.Visible = True
                grpMotorola.Text = "Sony/Ericsson"

                Me.lblProductAPCCode.Visible = False
                txtProd_APCCode.Visible = False
                Me.lblIncomingIMEI.Visible = False
                txtIncomingIMEI.Visible = False
                'Me.lblMSN.Visible = True
                'txtMSN.Visible = True
                Me.lblMSN.Visible = False
                txtMSN.Visible = False
                Me.lblModel.Visible = True
                txtModel.Visible = True
                Me.lblCourierTrackingIn.Visible = True
                txtCourierTrackIN.Visible = True
                Me.lblAirtimeCarrierCode.Visible = True
                cboAirCarrCode.Visible = True
                Me.lblTransactionCode.Visible = False
                cboTransCode.Visible = False
                Me.lblTransceiverCode.Visible = True
                txtTransCode.Visible = True
                Me.lblCarrModelCode.Visible = True
                txtCarrModelCode.Visible = True
                Me.lblMIN.Visible = True
                txtMIN.Visible = True
                Me.lblProductCode.Visible = False
                txtProductCode.Visible = False
                txtMSN.Focus()

            Else
                'MsgBox("The proof of purchase value you entered is not valid. Please try again", MsgBoxStyle.OKOnly, "Error")
                'txtPOP.Focus()
                grpMotorola.Visible = True
                grpMotorola.Text = "Generic"

                Me.lblProductAPCCode.Visible = False
                txtProd_APCCode.Visible = False
                Me.lblIncomingIMEI.Visible = False
                txtIncomingIMEI.Visible = False
                'Me.lblMSN.Visible = True
                'txtMSN.Visible = True
                Me.lblMSN.Visible = False
                txtMSN.Visible = False
                Me.lblModel.Visible = True
                txtModel.Visible = True
                Me.lblCourierTrackingIn.Visible = True
                txtCourierTrackIN.Visible = True
                Me.lblAirtimeCarrierCode.Visible = True
                cboAirCarrCode.Visible = True
                Me.lblTransactionCode.Visible = False
                cboTransCode.Visible = False
                Me.lblTransceiverCode.Visible = True
                txtTransCode.Visible = True
                Me.lblCarrModelCode.Visible = True
                txtCarrModelCode.Visible = True
                Me.lblMIN.Visible = True
                txtMIN.Visible = True
                Me.lblProductCode.Visible = False
                txtProductCode.Visible = False
                txtMSN.Focus()

            End If


        End Sub

        Private Sub txtPOP_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOP.Enter

            'HideGroup()
            If Len(txtCustomerName.Text) < 1 Then
                txtCustomerName.Focus()
            End If

        End Sub

        Private Sub cboDateCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDateCode.Enter

            If Len(txtCustomerName.Text) < 1 Then
                txtCustomerName.Focus()
                Exit Sub
            End If

            cboDateCode.DroppedDown = True

        End Sub

        Private Sub txtCustomerName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerName.Leave

            'Set value of txtCustomerName to public variable
            valCustomerName = txtCustomerName.Text

        End Sub

        Private Sub cboDateCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDateCode.Leave

            Dim blnWrty As Boolean
            vMWrty = 0
            'HideGroup()
            HidePOP()

            blnWrty = GetWarrantyStatus()
            If blnWrty = True Then


                'cdh new December 5, 2003
                If ManufFlag = "M" Then
                    grpMotorola.Visible = True


                    If txtDateCodeType = "GSM" Then
                        Me.lblIncomingIMEI.Visible = True
                        Me.txtIncomingIMEI.Visible = True
                    Else
                        Me.lblIncomingIMEI.Visible = False
                        Me.txtIncomingIMEI.Visible = False
                    End If

                    Me.lblProductAPCCode.Visible = True
                    'txtProd_APCCode.Visible = True
                    'Me.lblIncomingIMEI.Visible = True
                    'txtIncomingIMEI.Visible = True
                    'Me.lblMSN.Visible = True
                    'txtMSN.Visible = True
                    Me.lblModel.Visible = True
                    txtModel.Visible = True
                    Me.lblCourierTrackingIn.Visible = True
                    txtCourierTrackIN.Visible = True
                    Me.lblAirtimeCarrierCode.Visible = True
                    cboAirCarrCode.Visible = True
                    Me.lblTransactionCode.Visible = True
                    cboTransCode.Visible = True
                    Me.lblTransceiverCode.Visible = True
                    txtTransCode.Visible = True
                    Me.lblCarrModelCode.Visible = True
                    txtCarrModelCode.Visible = True
                    Me.lblMIN.Visible = True
                    txtMIN.Visible = True
                    Me.lblProductCode.Visible = False
                    txtProductCode.Visible = False
                    txtProd_APCCode.Focus()
                ElseIf ManufFlag = "N" Then
                    grpMotorola.Visible = True
                    grpMotorola.Text = "Nokia"
                    Me.lblProductAPCCode.Visible = False
                    txtProd_APCCode.Visible = False
                    Me.lblIncomingIMEI.Visible = False
                    txtIncomingIMEI.Visible = False
                    Me.lblMSN.Visible = False
                    txtMSN.Visible = False
                    Me.lblModel.Visible = True
                    txtModel.Visible = True
                    Me.lblCourierTrackingIn.Visible = True
                    txtCourierTrackIN.Visible = True
                    Me.lblAirtimeCarrierCode.Visible = True
                    cboAirCarrCode.Visible = True
                    Me.lblTransactionCode.Visible = False
                    cboTransCode.Visible = False
                    Me.lblTransceiverCode.Visible = False
                    txtTransCode.Visible = False
                    Me.lblCarrModelCode.Visible = True
                    txtCarrModelCode.Visible = True
                    Me.lblMIN.Visible = True
                    txtMIN.Visible = True
                    Me.lblProductCode.Visible = True
                    txtProductCode.Visible = True
                    txtModel.Focus()
                ElseIf ManufFlag = "S" Then
                    grpMotorola.Visible = True
                    grpMotorola.Text = "Sony/Ericsson"
                    Me.lblProductAPCCode.Visible = False
                    txtProd_APCCode.Visible = False
                    Me.lblIncomingIMEI.Visible = False
                    txtIncomingIMEI.Visible = False
                    'Me.lblMSN.Visible = True
                    'txtMSN.Visible = True
                    Me.lblModel.Visible = True
                    txtModel.Visible = True
                    Me.lblCourierTrackingIn.Visible = True
                    txtCourierTrackIN.Visible = True
                    Me.lblAirtimeCarrierCode.Visible = True
                    cboAirCarrCode.Visible = True
                    Me.lblTransactionCode.Visible = False
                    cboTransCode.Visible = False
                    Me.lblTransceiverCode.Visible = True
                    txtTransCode.Visible = True
                    Me.lblCarrModelCode.Visible = True
                    txtCarrModelCode.Visible = True
                    Me.lblMIN.Visible = True
                    txtMIN.Visible = True
                    Me.lblProductCode.Visible = False
                    txtProductCode.Visible = False
                    txtMSN.Focus()
                Else
                    'MsgBox("The proof of purchase value you entered is not valid. Please try again", MsgBoxStyle.OKOnly, "Error")
                    'txtPOP.Focus()
                    grpMotorola.Visible = True
                    grpMotorola.Text = "Generic"
                    Me.lblProductAPCCode.Visible = False
                    txtProd_APCCode.Visible = False
                    Me.lblIncomingIMEI.Visible = False
                    txtIncomingIMEI.Visible = False
                    'Me.lblMSN.Visible = True
                    'txtMSN.Visible = True
                    Me.lblModel.Visible = True
                    txtModel.Visible = True
                    Me.lblCourierTrackingIn.Visible = True
                    txtCourierTrackIN.Visible = True
                    Me.lblAirtimeCarrierCode.Visible = True
                    cboAirCarrCode.Visible = True
                    Me.lblTransactionCode.Visible = False
                    cboTransCode.Visible = False
                    Me.lblTransceiverCode.Visible = True
                    txtTransCode.Visible = True
                    Me.lblCarrModelCode.Visible = True
                    txtCarrModelCode.Visible = True
                    Me.lblMIN.Visible = True
                    txtMIN.Visible = True
                    Me.lblProductCode.Visible = False
                    txtProductCode.Visible = False
                    txtMSN.Focus()
                End If
                vMWrty = 1
                'DisplayGroup()
                'txtIncomingIMEI.Focus()
            Else
                DisplayPOP()
                txtPOP.Focus()
            End If

            'Set value of cboDateCode to public variable
            valDateCode = cboDateCode.Text

        End Sub

        Private Sub txtProductCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductCode.Leave

            'Set value of txtProductCode to public variable
            valProductCode = txtProductCode.Text

        End Sub

        Private Sub txtMSN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMSN.Leave

            'Set value of txtMSN to public variable
            valMSN = txtMSN.Text

        End Sub

        Private Sub txtModel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtModel.Leave

            'Set value of txtModel to public variable
            valModel = txtModel.Text

        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click


            'get data to resubmit
            Dim errMsg As String = ""



            'Determine necessary fields for resubmit
            If Len(valCustomerName) < 1 Then 'empty value
                errMsg += "Customer Name is not entered." & vbCrLf
            End If

            If cboDateCode.Visible = True Then
                '                If Len(valDateCode) < 1 Then 'empty value
                '                errMsg += "Date Code is not selected." & vbCrLf
                '            End If
            End If

            If valWrty = True Then

                If ManufFlag = "M" Then 'Motorola
                    If Len(valMSN) < 1 Then 'empty value
                        '                       errMsg += "MSN is not entered." & vbCrLf
                    End If
                    If Len(valModel) < 1 Then 'empty value
                        '                      errMsg += "Model is not entered." & vbCrLf
                    End If
                End If


                If ManufFlag = "N" Then 'Nokia
                    If Len(valProductCode) < 1 Then 'empty value
                        '                      errMsg += "Product Code is not entered." & vbCrLf
                    End If
                End If

            End If

            If Len(errMsg) > 0 Then
                MsgBox("The following errors have occurred: " & vbCrLf & errMsg, MsgBoxStyle.OKOnly, "Error")
                txtCustomerName.Focus()
                Exit Sub
            End If

            'Update entry to the database and exit form.
            'This section is yet to be done.
            tmpCellCustomer = ""
            tmpCellDateCode = ""
            tmpCellPOP = ""
            tmpCellProdCode = ""
            tmpCellMSN = ""
            tmpCellModel = ""

            frmMOTORL_Receiving.cellValCustomer = txtCustomerName.Text
            frmMOTORL_Receiving.cellValDateCode = cboDateCode.Text
            frmMOTORL_Receiving.cellValPOP = txtPOP.Text
            frmMOTORL_Receiving.cellValProdCode = txtProductCode.Text
            frmMOTORL_Receiving.cellValMSN = txtMSN.Text
            frmMOTORL_Receiving.cellValModel = txtModel.Text

            'Unload the form and return to parent.
            'frmMOTORL_Receiving.txtCell.Focus()
            frmMOTORL_Receiving.waitStateVAL = 1
            Me.Close()

        End Sub

        Private Sub btnAdd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Enter

            If grpMotorola.Visible = True Then
                If Len(txtMSN.Text) < 1 Then
                    txtMSN.Focus()
                End If
            End If

            'If grpNokia.Visible = True Then
            '    If Len(txtProductCode.Text) < 1 Then
            'txtProductCode.Focus()
            '    End If
            'End If

        End Sub


        Private Sub frmCellDeviceInfo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

            If frmMOTORL_Receiving.waitStateVAL = 0 Then
                frmMOTORL_Receiving.waitStateVAL = 2
            End If

        End Sub


        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            Dim xcount As Integer = 0

            '//Get Airtime value
            For xcount = 0 To UBound(arrCarrier)
                If Trim(arrCarrier(xcount, 1)) = Trim(cboAirCarrCode.Text) Then
                    frmMOTORL_Receiving.vcAirCarrCode = arrCarrier(xcount, 0)
                    Exit For
                End If
            Next

            '//Get Transaction value
            For xcount = 0 To UBound(arrTransaction)
                If Trim(arrTransaction(xcount, 1)) = Trim(cboTransCode.Text) Then
                    frmMOTORL_Receiving.vcTransactionCode = arrTransaction(xcount, 0)
                    Exit For
                End If
            Next

            '//Get APC value
            For xcount = 0 To UBound(arrAPC)
                If Trim(arrAPC(xcount, 0)) = Trim(cboProd_APCCode.Text) Then
                    frmMOTORL_Receiving.vcAPCcode = arrAPC(xcount, 3)
                    Exit For
                End If
            Next

            '// BEGIN This has been modified as of January 6, 2004 so that if the field is visible then it becomes required.

            Dim errMsg As String = ""

            If ManufFlag = "M" Then
                '//Verify all required fields have values
                If txtCourierTrackIN.Visible = True Then
                    If Len(Trim(txtCourierTrackIN.Text)) < 1 Then errMsg += "Courier Track IN is not defined." & vbCrLf
                End If
                If cboAirCarrCode.Visible = True Then
                    If Len(Trim(cboAirCarrCode.Text)) < 1 Then errMsg += "AirTime Carrier Code is not defined." & vbCrLf
                End If
                If cboTransCode.Visible = True Then
                    If Len(Trim(cboTransCode.Text)) < 1 Then errMsg += "Transaction Code is not defined." & vbCrLf
                End If

                'If Len(Trim(txtProd_APCCode.Text)) < 1 Then errMsg += "Product/ APC Code is not defined." & vbCrLf
                If txtTransCode.Visible = True Then
                    If Len(Trim(txtTransCode.Text)) < 1 Then errMsg += "Transceiver Code is not defined." & vbCrLf
                End If
                If txtIncomingIMEI.Visible = True Then
                    If Len(Trim(txtIncomingIMEI.Text)) < 1 And Len(Trim(txtMSN.Text)) < 1 Then errMsg += "Incoming IMEI or MSN is not defined." & vbCrLf
                End If
                'If Len(Trim(txtWarrantyClaimNum.Text)) < 1 Then errMsg += "Warranty Claim Number is not defined." & vbCrLf

                If Len(Trim(errMsg)) > 0 Then
                    errMsg += "Please fill in all required fields before continuing."
                    MsgBox(errMsg, MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If
            End If

            '// END This has been modified as of January 6, 2004 so that if the field is visible then it becomes required.


            '//Assign values to variables on main receiving form
            frmMOTORL_Receiving.vcDateCode = cboDateCode.Text
            frmMOTORL_Receiving.vcCourierTrackIN = txtCourierTrackIN.Text
            'frmMOTORL_Receiving.vcAPCcode = txtProd_APCCode.Text
            frmMOTORL_Receiving.vcTranceiverCode = txtTransCode.Text
            frmMOTORL_Receiving.vcIncomingIMEI = txtIncomingIMEI.Text
            frmMOTORL_Receiving.vcWrtyClaimNum = txtWarrantyClaimNum.Text

            'If Len(Trim(cboAirCarrCode.Text)) > 0 Then frmMOTORL_Receiving.vcAirCarrCode = cboAirCarrCode.Text
            If Len(Trim(txtCarrModelCode.Text)) > 0 Then frmMOTORL_Receiving.vcCarrModelCode = txtCarrModelCode.Text
            If Len(Trim(txtMIN.Text)) > 0 Then frmMOTORL_Receiving.vcMIN = txtMIN.Text
            'If Len(Trim(cboDateCode.Text)) > 0 Then frmMOTORL_Receiving.vcDateCode = cboDateCode.Text
            If vMWrty = 1 Then
                frmMOTORL_Receiving.vcDateCodeVM = "1"
            Else
                frmMOTORL_Receiving.vcDateCodeVM = "0"
            End If
            If Len(Trim(txtCustomerName.Text)) > 0 Then frmMOTORL_Receiving.vcCustomerName = txtCustomerName.Text
            If Len(Trim(txtModel.Text)) > 0 Then frmMOTORL_Receiving.vcModel = txtModel.Text
            If Len(Trim(txtPOP.Text)) > 0 Then frmMOTORL_Receiving.vcPOP = txtPOP.Text
            If Len(Trim(txtMSN.Text)) > 0 Then frmMOTORL_Receiving.vcMSN = txtMSN.Text
            If Len(Trim(txtProductCode.Text)) > 0 Then frmMOTORL_Receiving.vcProductCode = txtProductCode.Text
            If Len(Trim(lblCustomerReasonNameString.Text)) > 0 Then frmMOTORL_Receiving.vcComplaint = lblCustomerReasonNameString.Text
            If Len(Trim(valCSNdecimal)) > 0 Then frmMOTORL_Receiving.vcDecimal = valCSNdecimal
            'from button sumbit

            'Determine necessary fields for resubmit
            If Len(valCustomerName) < 1 Then 'empty value
                errMsg += "Customer Name is not entered." & vbCrLf
            End If

            If valWrty = True Then

                If ManufFlag = "M" Then 'Motorola
                    If Len(valMSN) < 1 Then 'empty value
                        '                       errMsg += "MSN is not entered." & vbCrLf
                    End If
                    If Len(valModel) < 1 Then 'empty value
                        '                      errMsg += "Model is not entered." & vbCrLf
                    End If
                End If


                If ManufFlag = "N" Then 'Nokia
                    If Len(valProductCode) < 1 Then 'empty value
                        '                      errMsg += "Product Code is not entered." & vbCrLf
                    End If
                End If

            End If

            If Len(errMsg) > 0 Then
                'MsgBox("The following errors have occurred: " & vbCrLf & errMsg, MsgBoxStyle.OKOnly, "Error")
                'txtCustomerName.Focus()
                'Exit Sub
            End If

            'Update entry to the database and exit form.
            'This section is yet to be done.
            tmpCellCustomer = ""
            tmpCellDateCode = ""
            tmpCellPOP = ""
            tmpCellProdCode = ""
            tmpCellMSN = ""
            tmpCellModel = ""

            frmMOTORL_Receiving.cellValCustomer = txtCustomerName.Text
            frmMOTORL_Receiving.cellValDateCode = cboDateCode.Text
            frmMOTORL_Receiving.cellValPOP = txtPOP.Text
            frmMOTORL_Receiving.cellValProdCode = txtProductCode.Text
            frmMOTORL_Receiving.cellValMSN = txtMSN.Text
            frmMOTORL_Receiving.cellValModel = txtModel.Text

            '//NEW
            If txtDateCodeType = "GSM" Then
                frmMOTORL_Receiving.cellValMSN = frmMOTORL_Receiving.coDeviceSN
                frmMOTORL_Receiving.vcMSN = frmMOTORL_Receiving.coDeviceSN
            ElseIf txtDateCodeType = "CSN" Then
                frmMOTORL_Receiving.vcCSN = frmMOTORL_Receiving.coDeviceSN
            End If
            '//NEW

            'Unload the form and return to parent.
            'frmMOTORL_Receiving.txtCell.Focus()
            frmMOTORL_Receiving.waitStateVAL = 1

            'Craig Haney
            arrDateCode = Nothing
            arrTransaction = Nothing
            arrAPC = Nothing
            arrCarrier = Nothing
            'Craig Haney

            Me.Close()

        End Sub

        Private Sub PopulateTransaction()

            'This will generate the data for the cboComplaint control.
            'It will also create a two dimensional array that holds the Complaint IDs
            'and Names
            Dim xCount As Integer = 0
            Dim tblJoins As New PSS.Data.Production.Joins()
            Dim dtTransaction As DataTable
            dtTransaction = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='transaction' and lcodesdetail.manuf_id=1 and lcodesdetail.prod_id=2")
            Dim r As DataRow

            For xCount = 0 To dtTransaction.Rows.Count - 1
                r = dtTransaction.Rows(xCount)
                Me.cboTransCode.Items.Add(Trim(r("Dcode_LDesc")))
                arrTransaction(xCount, 0) = r("Dcode_ID")
                If Not IsDBNull(r("Dcode_LDesc")) Then
                    arrTransaction(xCount, 1) = Trim(r("Dcode_LDesc"))
                End If
            Next

            dtTransaction.Dispose()
            dtTransaction = Nothing
            tblJoins = Nothing

        End Sub

        Private Sub PopulateCarrier()

            'This will generate the data for the cboComplaint control.
            'It will also create a two dimensional array that holds the Complaint IDs
            'and Names
            Dim xCount As Integer = 0
            Dim tblJoins As New PSS.Data.Production.Joins()
            Dim dtCarrier As DataTable
            dtCarrier = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='carrier' and lcodesdetail.manuf_id=1 and lcodesdetail.prod_id=2")
            Dim r As DataRow

            For xCount = 0 To dtCarrier.Rows.Count - 1
                r = dtCarrier.Rows(xCount)
                Me.cboAirCarrCode.Items.Add(Trim(r("Dcode_LDesc")))
                arrCarrier(xCount, 0) = r("Dcode_ID")
                If IsDBNull(r("Dcode_LDesc")) = False Then
                    arrCarrier(xCount, 1) = Trim(r("Dcode_LDesc"))
                End If
            Next

            dtCarrier.Dispose()
            dtCarrier = Nothing
            tblJoins = Nothing

        End Sub

        Private Sub PopulateAPC()

            'This will generate the data for the cboComplaint control.
            'It will also create a two dimensional array that holds the Complaint IDs
            'and Names
            Dim xCount As Integer = 0
            Dim tblJoins As New PSS.Data.Production.Joins()
            Dim dtAPC As DataTable
            dtAPC = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='APC' and lcodesdetail.manuf_id=1 and lcodesdetail.prod_id=2")
            Dim r As DataRow

            Try
                cboProd_APCCode.Items.Clear()
            Catch ex As Exception
            End Try

            For xCount = 0 To dtAPC.Rows.Count - 1
                r = dtAPC.Rows(xCount)
                Me.cboProd_APCCode.Items.Add(Trim(r("Dcode_SDesc")))
                arrAPC(xCount, 0) = r("Dcode_SDesc")
                If Not IsDBNull(r("Dcode_LDesc")) Then
                    arrAPC(xCount, 1) = Trim(r("Dcode_LDesc"))
                    'cboProd_APCCode.Items.Add(Trim(r("Dcode_LDesc")))
                End If
                If Not IsDBNull(r("Dcode_L2Desc")) Then
                    arrAPC(xCount, 2) = Trim(r("Dcode_L2Desc"))
                End If
                If Not IsDBNull(r("Dcode_ID")) Then
                    arrAPC(xCount, 3) = Trim(r("Dcode_ID"))
                End If
            Next

            dtAPC.Dispose()
            dtAPC = Nothing
            tblJoins = Nothing

        End Sub

        Private Sub MotorolaGroupHide()
            lblMSN.Visible = False
            txtMSN.Visible = False
            lblModel.Visible = False
            txtModel.Visible = False
            lblCourierTrackingIn.Visible = False
            txtCourierTrackIN.Visible = False
            lblAirtimeCarrierCode.Visible = False
            cboAirCarrCode.Visible = False
            lblTransactionCode.Visible = False
            cboTransCode.Visible = False
            lblTransceiverCode.Visible = False
            txtTransCode.Visible = False
            lblIncomingIMEI.Visible = False
            txtIncomingIMEI.Visible = False
            lblProductCode.Visible = False
            txtProductCode.Visible = False
            'lblWarrantyClaimNumber.Visible = False
            'txtWarrantyClaimNum.Visible = False
        End Sub

        Private Sub MotorolaGroupShow()
            'lblMSN.Visible = True
            'txtMSN.Visible = True
            lblModel.Visible = True
            txtModel.Visible = True
            lblCourierTrackingIn.Visible = True
            txtCourierTrackIN.Visible = True
            lblAirtimeCarrierCode.Visible = True
            cboAirCarrCode.Visible = True
            lblTransactionCode.Visible = True
            cboTransCode.Visible = True
            lblTransceiverCode.Visible = True
            txtTransCode.Visible = True
            lblIncomingIMEI.Visible = True
            txtIncomingIMEI.Visible = True
            lblProductCode.Visible = False
            txtProductCode.Visible = False
            'lblWarrantyClaimNumber.Visible = True
            'txtWarrantyClaimNum.Visible = True
        End Sub

        Private Sub txtProd_APCCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProd_APCCode.Leave

            'cellType = ""

            txtProd_APCCode.Text = UCase(txtProd_APCCode.Text)

            PopulateAPC()
            Dim xCount As Integer = 0
            For xCount = 0 To UBound(arrAPC) - 1
                If Trim(arrAPC(xCount, 1)) = Trim(txtProd_APCCode.Text) Then
                    lblAPCDetail.Text = arrAPC(xCount, 1)
                    If Trim(arrAPC(xCount, 2)) = "GSM/PCS" Then
                        cellType = "IMEI"
                    Else
                        cellType = "CSN"
                    End If
                End If
            Next

            '//Determine if value is IMEI or MSN/ESN
            MotorolaGroupShow()
            If cellType = "IMEI" Then
                'lblMSN.Visible = False
                'txtMSN.Visible = False
                'lblIncomingIMEI.Top = 80
                'lblIncomingIMEI.Left = 24
                'txtIncomingIMEI.Top = 80
                'txtIncomingIMEI.Left = 160
                txtIncomingIMEI.Focus()
            Else
                lblIncomingIMEI.Visible = False
                txtIncomingIMEI.Visible = False
                'lblMSN.Top = 80
                'lblMSN.Left = 24
                'txtMSN.Top = 80
                'txtMSN.Left = 160
                txtMSN.Focus()
            End If


        End Sub


        Private Sub txtCustomerName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerName.KeyDown

            If e.KeyValue = 13 Then
                If cboDateCode.Visible = True Then cboDateCode.Focus()
                If txtPOP.Visible = True Then txtPOP.Focus()
                If txtProd_APCCode.Visible = True Then txtProd_APCCode.Focus()
                If txtIncomingIMEI.Visible = True Then txtIncomingIMEI.Focus()
                If txtMSN.Visible = True Then txtMSN.Focus()
                If txtModel.Visible = True Then txtModel.Focus()
                If txtCourierTrackIN.Visible = True Then txtCourierTrackIN.Focus()
                If cboAirCarrCode.Visible = True Then cboAirCarrCode.Focus()
                If cboTransCode.Visible = True Then cboTransCode.Focus()
                If txtTransCode.Visible = True Then txtTransCode.Focus()
                If txtCarrModelCode.Visible = True Then txtCarrModelCode.Focus()
                If txtMIN.Visible = True Then txtMIN.Focus()
                If txtProductCode.Visible = True Then txtProductCode.Focus()
            End If

        End Sub

        Private Sub cboDateCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDateCode.SelectedIndexChanged

        End Sub

        Private Sub cboDateCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDateCode.KeyDown

            If e.KeyValue = 13 Then
                If txtPOP.Visible = True Then
                    txtPOP.Focus()
                    Exit Sub
                    'cdh new December 5, 2003
                End If
                If txtProd_APCCode.Visible = True Then
                    txtProd_APCCode.Focus()
                    Exit Sub
                End If
                If txtIncomingIMEI.Visible = True Then
                    txtIncomingIMEI.Focus()
                    Exit Sub
                End If
                If txtMSN.Visible = True Then
                    txtMSN.Focus()
                    Exit Sub
                End If
                If txtModel.Visible = True Then
                    txtModel.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboAirCarrCode.Visible = True Then
                    cboAirCarrCode.Focus()
                    Exit Sub
                End If
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub


        Private Sub txtPOP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPOP.KeyDown

            ' If e.KeyValue = 13 Then
            '     If txtProd_APCCode.Visible = True Then
            '         txtProd_APCCode.Focus()
            '         Exit Sub
            '     End If
            '     If txtIncomingIMEI.Visible = True Then
            '         txtIncomingIMEI.Focus()
            '         Exit Sub
            '     End If
            '     If txtMSN.Visible = True Then
            '         txtMSN.Focus()
            '         Exit Sub
            '     End If
            '     If txtModel.Visible = True Then
            '         txtModel.Focus()
            '         Exit Sub
            '     End If
            '     If txtCourierTrackIN.Visible = True Then
            '         txtCourierTrackIN.Focus()
            '         Exit Sub
            '     End If
            '     If cboAirCarrCode.Visible = True Then
            '         cboAirCarrCode.Focus()
            '         Exit Sub
            '     End If
            '     If cboTransCode.Visible = True Then
            '         cboTransCode.Focus()
            '         Exit Sub
            '     End If
            '     If txtTransCode.Visible = True Then
            '         txtTransCode.Focus()
            '         Exit Sub
            '     End If
            '     If txtCarrModelCode.Visible = True Then
            '        txtCarrModelCode.Focus()
            '        Exit Sub
            '   End If
            '   If txtMIN.Visible = True Then
            '       txtMIN.Focus()
            '       Exit Sub
            '   End If
            '   If txtProductCode.Visible = True Then
            '       txtProductCode.Focus()
            '       Exit Sub
            '   End If
            '   If btnSave.Visible = True Then
            '       btnSave.Focus()
            '       Exit Sub
            '    End If
            'End If

        End Sub

        Private Sub txtProd_APCCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProd_APCCode.KeyDown

            If e.KeyValue = 13 Then
                If txtIncomingIMEI.Visible = True Then
                    txtIncomingIMEI.Focus()
                    Exit Sub
                End If
                If txtMSN.Visible = True Then
                    txtMSN.Focus()
                    Exit Sub
                End If
                If txtModel.Visible = True Then
                    txtModel.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboAirCarrCode.Visible = True Then
                    cboAirCarrCode.Focus()
                    Exit Sub
                End If
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtIncomingIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIncomingIMEI.KeyDown

            If e.KeyValue = 13 Then
                If txtMSN.Visible = True Then
                    txtMSN.Focus()
                    Exit Sub
                End If
                If txtModel.Visible = True Then
                    txtModel.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboAirCarrCode.Visible = True Then
                    cboAirCarrCode.Focus()
                    Exit Sub
                End If
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtMSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMSN.KeyDown

            If e.KeyValue = 13 Then
                If txtModel.Visible = True Then
                    txtModel.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboAirCarrCode.Visible = True Then
                    cboAirCarrCode.Focus()
                    Exit Sub
                End If
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtModel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModel.KeyDown

            If e.KeyValue = 13 Then
                If txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboAirCarrCode.Visible = True Then
                    cboAirCarrCode.Focus()
                    Exit Sub
                End If
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtCourierTrackIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCourierTrackIN.KeyDown

            If e.KeyValue = 13 Then
                If cboAirCarrCode.Visible = True Then
                    cboAirCarrCode.Focus()
                    Exit Sub
                End If
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub cboAirCarrCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAirCarrCode.KeyDown

            If e.KeyValue = 13 Then
                If cboTransCode.Visible = True Then
                    cboTransCode.Focus()
                    Exit Sub
                End If
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub cboTransCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTransCode.KeyDown

            If e.KeyValue = 13 Then
                If txtTransCode.Visible = True Then
                    txtTransCode.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtTransCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransCode.KeyDown

            If e.KeyValue = 13 Then
                If txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtCarrModelCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarrModelCode.KeyDown

            If e.KeyValue = 13 Then
                If txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub txtMIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMIN.KeyDown

            If e.KeyValue = 13 Then
                If txtProductCode.Visible = True Then
                    txtProductCode.Focus()
                    Exit Sub
                End If
                If cboCustomerReason.Visible = True Then
                    cboCustomerReason.Focus()
                    Exit Sub
                End If
                If btnSave.Visible = True Then
                    btnSave.Focus()
                    Exit Sub
                End If
            End If

        End Sub


        Private Sub txtProductCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductCode.KeyDown

            If e.KeyValue = 13 Then
                cboCustomerReason.Focus()
            End If

        End Sub

        Private Sub cboAirCarrCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAirCarrCode.SelectedIndexChanged

        End Sub

        Private Sub cboAirCarrCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAirCarrCode.Enter

            cboAirCarrCode.DroppedDown = True

        End Sub

        Private Sub cboTransCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTransCode.SelectedIndexChanged

        End Sub

        Private Sub cboTransCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTransCode.Enter

            cboTransCode.DroppedDown = True

        End Sub

        Private Sub cboDateCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDateCode.KeyUp


        End Sub

        Private Sub txtPOP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPOP.TextChanged

        End Sub

        Private Sub txtCarrModelCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCarrModelCode.TextChanged

        End Sub

        Private Sub grpMotorola_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpMotorola.Enter

        End Sub

        Private Sub txtModel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModel.TextChanged

        End Sub

        Private Sub PopulateComplaints()

            'This will generate the data for the cboComplaint control.
            'It will also create a two dimensional array that holds the Complaint IDs
            'and Names
            Dim xCount As Integer = 0
            Dim tblJoins As New PSS.Data.Production.Joins()
            Dim dtComplaint As DataTable
            dtComplaint = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='complaint' and lcodesdetail.manuf_id=" & ManufIDint & " and lcodesdetail.prod_id=2 ORDER BY DCode_LDesc")
            Dim r As DataRow

            Try
                cboCustomerReason.Items.Clear()
            Catch ex As Exception
            End Try

            For xCount = 0 To dtComplaint.Rows.Count - 1
                r = dtComplaint.Rows(xCount)
                Me.cboCustomerReason.Items.Add(Trim(r("Dcode_LDesc")))
                arrCustomerReason(xCount, 0) = r("Dcode_ID")
                If Not IsDBNull(r("Dcode_LDesc")) Then
                    arrCustomerReason(xCount, 1) = Trim(r("Dcode_LDesc"))
                End If
            Next

            dtComplaint.Dispose()
            dtComplaint = Nothing
            tblJoins = Nothing

        End Sub


        Private Sub cboCustomerReason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerReason.SelectedIndexChanged

            Dim customerreasonVal As Long = GetCustomerReasonID()
            lblCustomerReasonNameString.Text = customerreasonVal

        End Sub

        Private Function GetCustomerReasonID() As Long

            Dim xCount As Integer

            GetCustomerReasonID = 0

            Try

                For xCount = 0 To UBound(arrCustomerReason) - 1 'cboCustomerReason.Items.Count - 1
                    If arrCustomerReason(xCount, 1).ToString = cboCustomerReason.Text Then
                        GetCustomerReasonID = arrCustomerReason(xCount, 0)
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try

        End Function



        Private Sub txtProductCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductCode.TextChanged

        End Sub

        Private Sub cboCustomerReason_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomerReason.KeyUp

            If e.KeyValue = 13 Then
                btnSave.Focus()
            End If

        End Sub

        Private Sub txtIncomingIMEI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncomingIMEI.TextChanged

        End Sub

        Private Sub txtMSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMSN.TextChanged

        End Sub

        Private Sub cboProd_APCCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProd_APCCode.SelectedIndexChanged

            lblAPCDetail.Text = ""

            Dim cellType As String = ""

            txtProd_APCCode.Text = UCase(txtProd_APCCode.Text)

            'PopulateAPC()
            Dim xCount As Integer = 0
            For xCount = 0 To UBound(arrAPC) - 1
                If Trim(arrAPC(xCount, 1)) = Trim(txtProd_APCCode.Text) Then
                    lblAPCDetail.Text = arrAPC(xCount, 1)
                    If Trim(arrAPC(xCount, 2)) = "GSM/PCS" Then
                        cellType = "IMEI"
                    Else
                        cellType = "CSN"
                    End If
                End If
            Next

        End Sub

        Private Overloads Sub txtProd_APCCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProd_APCCode.TextChanged

        End Sub

        Private Sub cboProd_APCCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProd_APCCode.Leave

            Dim cellType As String = ""

            txtProd_APCCode.Text = UCase(txtProd_APCCode.Text)

            PopulateAPC()
            Dim xCount As Integer = 0
            For xCount = 0 To UBound(arrAPC) - 1
                If Trim(arrAPC(xCount, 1)) = Trim(txtProd_APCCode.Text) Then
                    lblAPCDetail.Text = arrAPC(xCount, 1)
                    If Trim(arrAPC(xCount, 2)) = "GSM/PCS" Then
                        cellType = "IMEI"
                    Else
                        cellType = "CSN"
                    End If
                End If
            Next

            '//Determine if value is IMEI or MSN/ESN
            MotorolaGroupShow()
            If txtDateCodeType = "GSM" Then
                'lblMSN.Visible = False
                'txtMSN.Visible = False
                'lblIncomingIMEI.Top = 80
                'lblIncomingIMEI.Left = 24
                'txtIncomingIMEI.Top = 80
                'txtIncomingIMEI.Left = 160
                txtIncomingIMEI.Focus()
            Else
                lblIncomingIMEI.Visible = False
                txtIncomingIMEI.Visible = False
                'lblMSN.Top = 80
                'lblMSN.Left = 24
                'txtMSN.Top = 80
                'txtMSN.Left = 160
                txtMSN.Focus()
            End If

        End Sub

        Private Sub txtCustomerName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerName.Enter

            '/These are hard coded values -START
            System.Windows.Forms.Application.DoEvents()
            txtTransCode.Focus()
            'btnSave.Focus()
            '/These are hard coded values -END

        End Sub

        Private Sub txtCustomerName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerName.TextChanged


        End Sub

    End Class

End Namespace
