'Imports PSS.Core
'Imports PSS.Data

'Namespace Gui.Receiving

'    Public Class frmCellDeviceInfoMotorola
'        Inherits System.Windows.Forms.Form

'#Region " Windows Form Designer generated code "

'        Public Sub New()
'            MyBase.New()

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
'        Friend WithEvents lblCourierTrackingIn As System.Windows.Forms.Label
'        Friend WithEvents lblCustomerReference As System.Windows.Forms.Label
'        Friend WithEvents lblAirtimeCarrierCode As System.Windows.Forms.Label
'        Friend WithEvents lblTransactionCode As System.Windows.Forms.Label
'        Friend WithEvents lblProductAPCCode As System.Windows.Forms.Label
'        Friend WithEvents lblTransceiverCode As System.Windows.Forms.Label
'        Friend WithEvents lblCarrierModelCode As System.Windows.Forms.Label
'        Friend WithEvents lblPicassoNumber As System.Windows.Forms.Label
'        Friend WithEvents lblIncomingIMEI As System.Windows.Forms.Label
'        Friend WithEvents lblExpectedShipDate As System.Windows.Forms.Label
'        Friend WithEvents lblExpectedShipTime As System.Windows.Forms.Label
'        Friend WithEvents lblRMANumber As System.Windows.Forms.Label
'        Friend WithEvents lblWarrantyClaimNumber As System.Windows.Forms.Label
'        Friend WithEvents txtCourierTrackIN As System.Windows.Forms.TextBox
'        Friend WithEvents txtCustRef As System.Windows.Forms.TextBox
'        Friend WithEvents cboAirCarrCode As System.Windows.Forms.ComboBox
'        Friend WithEvents cboTransCode As System.Windows.Forms.ComboBox
'        Friend WithEvents txtProd_APCCode As System.Windows.Forms.TextBox
'        Friend WithEvents txtTransCode As System.Windows.Forms.TextBox
'        Friend WithEvents Label2 As System.Windows.Forms.Label
'        Friend WithEvents txtCarModelCode As System.Windows.Forms.TextBox
'        Friend WithEvents txtPicassoNum As System.Windows.Forms.TextBox
'        Friend WithEvents txtIncomingIMEI As System.Windows.Forms.TextBox
'        Friend WithEvents Label3 As System.Windows.Forms.Label
'        Friend WithEvents dteExpShipDate As System.Windows.Forms.DateTimePicker
'        Friend WithEvents Label4 As System.Windows.Forms.Label
'        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
'        Friend WithEvents Label5 As System.Windows.Forms.Label
'        Friend WithEvents txtRMANum As System.Windows.Forms.TextBox
'        Friend WithEvents Label6 As System.Windows.Forms.Label
'        Friend WithEvents txtWarrantyClaimNum As System.Windows.Forms.TextBox
'        Friend WithEvents Label7 As System.Windows.Forms.Label
'        Friend WithEvents btnSave As System.Windows.Forms.Button
'        Friend WithEvents btnCancel As System.Windows.Forms.Button
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.lblCourierTrackingIn = New System.Windows.Forms.Label()
'            Me.lblCustomerReference = New System.Windows.Forms.Label()
'            Me.lblAirtimeCarrierCode = New System.Windows.Forms.Label()
'            Me.lblTransactionCode = New System.Windows.Forms.Label()
'            Me.lblProductAPCCode = New System.Windows.Forms.Label()
'            Me.lblTransceiverCode = New System.Windows.Forms.Label()
'            Me.lblCarrierModelCode = New System.Windows.Forms.Label()
'            Me.lblPicassoNumber = New System.Windows.Forms.Label()
'            Me.lblIncomingIMEI = New System.Windows.Forms.Label()
'            Me.lblExpectedShipDate = New System.Windows.Forms.Label()
'            Me.lblExpectedShipTime = New System.Windows.Forms.Label()
'            Me.lblRMANumber = New System.Windows.Forms.Label()
'            Me.lblWarrantyClaimNumber = New System.Windows.Forms.Label()
'            Me.txtCourierTrackIN = New System.Windows.Forms.TextBox()
'            Me.txtCustRef = New System.Windows.Forms.TextBox()
'            Me.cboAirCarrCode = New System.Windows.Forms.ComboBox()
'            Me.cboTransCode = New System.Windows.Forms.ComboBox()
'            Me.txtProd_APCCode = New System.Windows.Forms.TextBox()
'            Me.txtTransCode = New System.Windows.Forms.TextBox()
'            Me.Label2 = New System.Windows.Forms.Label()
'            Me.txtCarModelCode = New System.Windows.Forms.TextBox()
'            Me.txtPicassoNum = New System.Windows.Forms.TextBox()
'            Me.txtIncomingIMEI = New System.Windows.Forms.TextBox()
'            Me.Label3 = New System.Windows.Forms.Label()
'            Me.dteExpShipDate = New System.Windows.Forms.DateTimePicker()
'            Me.Label4 = New System.Windows.Forms.Label()
'            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
'            Me.Label5 = New System.Windows.Forms.Label()
'            Me.txtRMANum = New System.Windows.Forms.TextBox()
'            Me.Label6 = New System.Windows.Forms.Label()
'            Me.txtWarrantyClaimNum = New System.Windows.Forms.TextBox()
'            Me.Label7 = New System.Windows.Forms.Label()
'            Me.btnSave = New System.Windows.Forms.Button()
'            Me.btnCancel = New System.Windows.Forms.Button()
'            Me.SuspendLayout()
'            '
'            'lblCourierTrackingIn
'            '
'            Me.lblCourierTrackingIn.Location = New System.Drawing.Point(56, 24)
'            Me.lblCourierTrackingIn.Name = "lblCourierTrackingIn"
'            Me.lblCourierTrackingIn.Size = New System.Drawing.Size(136, 16)
'            Me.lblCourierTrackingIn.TabIndex = 0
'            Me.lblCourierTrackingIn.Text = "Courier Tracking IN:"
'            Me.lblCourierTrackingIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblCustomerReference
'            '
'            Me.lblCustomerReference.Location = New System.Drawing.Point(56, 48)
'            Me.lblCustomerReference.Name = "lblCustomerReference"
'            Me.lblCustomerReference.Size = New System.Drawing.Size(136, 16)
'            Me.lblCustomerReference.TabIndex = 2
'            Me.lblCustomerReference.Text = "Customer Reference:"
'            Me.lblCustomerReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblAirtimeCarrierCode
'            '
'            Me.lblAirtimeCarrierCode.Location = New System.Drawing.Point(56, 72)
'            Me.lblAirtimeCarrierCode.Name = "lblAirtimeCarrierCode"
'            Me.lblAirtimeCarrierCode.Size = New System.Drawing.Size(136, 18)
'            Me.lblAirtimeCarrierCode.TabIndex = 3
'            Me.lblAirtimeCarrierCode.Text = "Airtime Carrier Code:"
'            Me.lblAirtimeCarrierCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblTransactionCode
'            '
'            Me.lblTransactionCode.Location = New System.Drawing.Point(56, 96)
'            Me.lblTransactionCode.Name = "lblTransactionCode"
'            Me.lblTransactionCode.Size = New System.Drawing.Size(136, 16)
'            Me.lblTransactionCode.TabIndex = 4
'            Me.lblTransactionCode.Text = "Transaction Code:"
'            Me.lblTransactionCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblProductAPCCode
'            '
'            Me.lblProductAPCCode.Location = New System.Drawing.Point(56, 120)
'            Me.lblProductAPCCode.Name = "lblProductAPCCode"
'            Me.lblProductAPCCode.Size = New System.Drawing.Size(136, 16)
'            Me.lblProductAPCCode.TabIndex = 5
'            Me.lblProductAPCCode.Text = "Product/ APC Code:"
'            Me.lblProductAPCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblTransceiverCode
'            '
'            Me.lblTransceiverCode.Location = New System.Drawing.Point(56, 144)
'            Me.lblTransceiverCode.Name = "lblTransceiverCode"
'            Me.lblTransceiverCode.Size = New System.Drawing.Size(136, 16)
'            Me.lblTransceiverCode.TabIndex = 6
'            Me.lblTransceiverCode.Text = "Transceiver Code:"
'            Me.lblTransceiverCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblCarrierModelCode
'            '
'            Me.lblCarrierModelCode.Location = New System.Drawing.Point(56, 168)
'            Me.lblCarrierModelCode.Name = "lblCarrierModelCode"
'            Me.lblCarrierModelCode.Size = New System.Drawing.Size(136, 16)
'            Me.lblCarrierModelCode.TabIndex = 7
'            Me.lblCarrierModelCode.Text = "Carrier Model Code:"
'            Me.lblCarrierModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblPicassoNumber
'            '
'            Me.lblPicassoNumber.Location = New System.Drawing.Point(16, 192)
'            Me.lblPicassoNumber.Name = "lblPicassoNumber"
'            Me.lblPicassoNumber.Size = New System.Drawing.Size(176, 16)
'            Me.lblPicassoNumber.TabIndex = 8
'            Me.lblPicassoNumber.Text = "Picasso Number/ Factory Code:"
'            Me.lblPicassoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblIncomingIMEI
'            '
'            Me.lblIncomingIMEI.Location = New System.Drawing.Point(56, 216)
'            Me.lblIncomingIMEI.Name = "lblIncomingIMEI"
'            Me.lblIncomingIMEI.Size = New System.Drawing.Size(136, 16)
'            Me.lblIncomingIMEI.TabIndex = 9
'            Me.lblIncomingIMEI.Text = "Incoming IMEI:"
'            Me.lblIncomingIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblExpectedShipDate
'            '
'            Me.lblExpectedShipDate.Location = New System.Drawing.Point(56, 240)
'            Me.lblExpectedShipDate.Name = "lblExpectedShipDate"
'            Me.lblExpectedShipDate.Size = New System.Drawing.Size(136, 16)
'            Me.lblExpectedShipDate.TabIndex = 10
'            Me.lblExpectedShipDate.Text = "Expected Ship Date:"
'            Me.lblExpectedShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblExpectedShipTime
'            '
'            Me.lblExpectedShipTime.Location = New System.Drawing.Point(56, 264)
'            Me.lblExpectedShipTime.Name = "lblExpectedShipTime"
'            Me.lblExpectedShipTime.Size = New System.Drawing.Size(136, 16)
'            Me.lblExpectedShipTime.TabIndex = 11
'            Me.lblExpectedShipTime.Text = "Expected Ship Time:"
'            Me.lblExpectedShipTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblRMANumber
'            '
'            Me.lblRMANumber.Location = New System.Drawing.Point(56, 288)
'            Me.lblRMANumber.Name = "lblRMANumber"
'            Me.lblRMANumber.Size = New System.Drawing.Size(136, 16)
'            Me.lblRMANumber.TabIndex = 12
'            Me.lblRMANumber.Text = "RMA Number:"
'            Me.lblRMANumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblWarrantyClaimNumber
'            '
'            Me.lblWarrantyClaimNumber.Location = New System.Drawing.Point(56, 312)
'            Me.lblWarrantyClaimNumber.Name = "lblWarrantyClaimNumber"
'            Me.lblWarrantyClaimNumber.Size = New System.Drawing.Size(136, 16)
'            Me.lblWarrantyClaimNumber.TabIndex = 13
'            Me.lblWarrantyClaimNumber.Text = "Warranty Claim Number:"
'            Me.lblWarrantyClaimNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtCourierTrackIN
'            '
'            Me.txtCourierTrackIN.Location = New System.Drawing.Point(192, 24)
'            Me.txtCourierTrackIN.Name = "txtCourierTrackIN"
'            Me.txtCourierTrackIN.TabIndex = 14
'            Me.txtCourierTrackIN.Text = ""
'            '
'            'txtCustRef
'            '
'            Me.txtCustRef.Location = New System.Drawing.Point(192, 48)
'            Me.txtCustRef.Name = "txtCustRef"
'            Me.txtCustRef.TabIndex = 15
'            Me.txtCustRef.Text = ""
'            '
'            'cboAirCarrCode
'            '
'            Me.cboAirCarrCode.Location = New System.Drawing.Point(192, 72)
'            Me.cboAirCarrCode.Name = "cboAirCarrCode"
'            Me.cboAirCarrCode.Size = New System.Drawing.Size(152, 21)
'            Me.cboAirCarrCode.TabIndex = 16
'            '
'            'cboTransCode
'            '
'            Me.cboTransCode.Location = New System.Drawing.Point(192, 96)
'            Me.cboTransCode.Name = "cboTransCode"
'            Me.cboTransCode.Size = New System.Drawing.Size(152, 21)
'            Me.cboTransCode.TabIndex = 17
'            '
'            'txtProd_APCCode
'            '
'            Me.txtProd_APCCode.Location = New System.Drawing.Point(192, 120)
'            Me.txtProd_APCCode.Name = "txtProd_APCCode"
'            Me.txtProd_APCCode.TabIndex = 18
'            Me.txtProd_APCCode.Text = ""
'            '
'            'txtTransCode
'            '
'            Me.txtTransCode.Location = New System.Drawing.Point(192, 144)
'            Me.txtTransCode.Name = "txtTransCode"
'            Me.txtTransCode.TabIndex = 20
'            Me.txtTransCode.Text = ""
'            '
'            'Label2
'            '
'            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label2.Location = New System.Drawing.Point(296, 144)
'            Me.Label2.Name = "Label2"
'            Me.Label2.Size = New System.Drawing.Size(40, 16)
'            Me.Label2.TabIndex = 21
'            Me.Label2.Text = "(scan)"
'            '
'            'txtCarModelCode
'            '
'            Me.txtCarModelCode.Location = New System.Drawing.Point(192, 168)
'            Me.txtCarModelCode.Name = "txtCarModelCode"
'            Me.txtCarModelCode.TabIndex = 22
'            Me.txtCarModelCode.Text = ""
'            '
'            'txtPicassoNum
'            '
'            Me.txtPicassoNum.Location = New System.Drawing.Point(192, 192)
'            Me.txtPicassoNum.Name = "txtPicassoNum"
'            Me.txtPicassoNum.TabIndex = 23
'            Me.txtPicassoNum.Text = ""
'            '
'            'txtIncomingIMEI
'            '
'            Me.txtIncomingIMEI.Location = New System.Drawing.Point(192, 216)
'            Me.txtIncomingIMEI.Name = "txtIncomingIMEI"
'            Me.txtIncomingIMEI.TabIndex = 24
'            Me.txtIncomingIMEI.Text = ""
'            '
'            'Label3
'            '
'            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label3.Location = New System.Drawing.Point(296, 224)
'            Me.Label3.Name = "Label3"
'            Me.Label3.Size = New System.Drawing.Size(184, 16)
'            Me.Label3.TabIndex = 25
'            Me.Label3.Text = "(only visible if GSM phone from APC Code)"
'            '
'            'dteExpShipDate
'            '
'            Me.dteExpShipDate.Location = New System.Drawing.Point(192, 240)
'            Me.dteExpShipDate.Name = "dteExpShipDate"
'            Me.dteExpShipDate.TabIndex = 26
'            '
'            'Label4
'            '
'            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label4.Location = New System.Drawing.Point(400, 240)
'            Me.Label4.Name = "Label4"
'            Me.Label4.Size = New System.Drawing.Size(40, 16)
'            Me.Label4.TabIndex = 27
'            Me.Label4.Text = "(blank)"
'            '
'            'DateTimePicker1
'            '
'            Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
'            Me.DateTimePicker1.Location = New System.Drawing.Point(192, 264)
'            Me.DateTimePicker1.Name = "DateTimePicker1"
'            Me.DateTimePicker1.TabIndex = 28
'            '
'            'Label5
'            '
'            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label5.Location = New System.Drawing.Point(400, 264)
'            Me.Label5.Name = "Label5"
'            Me.Label5.Size = New System.Drawing.Size(40, 16)
'            Me.Label5.TabIndex = 29
'            Me.Label5.Text = "(blank)"
'            '
'            'txtRMANum
'            '
'            Me.txtRMANum.Location = New System.Drawing.Point(192, 288)
'            Me.txtRMANum.Name = "txtRMANum"
'            Me.txtRMANum.TabIndex = 30
'            Me.txtRMANum.Text = ""
'            '
'            'Label6
'            '
'            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label6.Location = New System.Drawing.Point(296, 288)
'            Me.Label6.Name = "Label6"
'            Me.Label6.Size = New System.Drawing.Size(40, 16)
'            Me.Label6.TabIndex = 31
'            Me.Label6.Text = "(blank)"
'            '
'            'txtWarrantyClaimNum
'            '
'            Me.txtWarrantyClaimNum.Location = New System.Drawing.Point(192, 312)
'            Me.txtWarrantyClaimNum.Name = "txtWarrantyClaimNum"
'            Me.txtWarrantyClaimNum.TabIndex = 32
'            Me.txtWarrantyClaimNum.Text = ""
'            '
'            'Label7
'            '
'            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label7.Location = New System.Drawing.Point(296, 200)
'            Me.Label7.Name = "Label7"
'            Me.Label7.Size = New System.Drawing.Size(56, 16)
'            Me.Label7.TabIndex = 33
'            Me.Label7.Text = "(not visible)"
'            '
'            'btnSave
'            '
'            Me.btnSave.Location = New System.Drawing.Point(320, 336)
'            Me.btnSave.Name = "btnSave"
'            Me.btnSave.TabIndex = 34
'            Me.btnSave.Text = "&Save"
'            '
'            'btnCancel
'            '
'            Me.btnCancel.Location = New System.Drawing.Point(400, 336)
'            Me.btnCancel.Name = "btnCancel"
'            Me.btnCancel.TabIndex = 35
'            Me.btnCancel.Text = "&Cancel"
'            '
'            'frmCellDeviceInfoMotorola
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.ClientSize = New System.Drawing.Size(480, 365)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnSave, Me.Label7, Me.txtWarrantyClaimNum, Me.Label6, Me.txtRMANum, Me.Label5, Me.DateTimePicker1, Me.Label4, Me.dteExpShipDate, Me.Label3, Me.txtIncomingIMEI, Me.txtPicassoNum, Me.txtCarModelCode, Me.Label2, Me.txtTransCode, Me.txtProd_APCCode, Me.cboTransCode, Me.cboAirCarrCode, Me.txtCustRef, Me.txtCourierTrackIN, Me.lblWarrantyClaimNumber, Me.lblRMANumber, Me.lblExpectedShipTime, Me.lblExpectedShipDate, Me.lblIncomingIMEI, Me.lblPicassoNumber, Me.lblCarrierModelCode, Me.lblTransceiverCode, Me.lblProductAPCCode, Me.lblTransactionCode, Me.lblAirtimeCarrierCode, Me.lblCustomerReference, Me.lblCourierTrackingIn})
'            Me.Name = "frmCellDeviceInfoMotorola"
'            Me.Text = "Motorla Specific Data"
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Private Sub frmCellDeviceInfoMotorola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'        End Sub

'        Private Sub txtCourierTrackIN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCourierTrackIN.Leave

'            '//Sets the default value of USPS if nothing defined
'            If Len(Trim(txtCourierTrackIN.Text)) = 0 Then
'                txtCourierTrackIN.Text = "USPS"
'            End If

'        End Sub

'        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

'            Me.Dispose()
'            Me.Close()

'        End Sub

'        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

'        End Sub
'    End Class

'End Namespace
