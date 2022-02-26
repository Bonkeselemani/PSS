Imports PSS.Data
Namespace GUI
	Public Class frmWFMSetDeviceBackToTriage
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
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents txtSn As System.Windows.Forms.TextBox
		Friend WithEvents lblTriageMsg As System.Windows.Forms.Label
		Friend WithEvents lblWHBoxMsg As System.Windows.Forms.Label
		Friend WithEvents lblPalletMsg As System.Windows.Forms.Label
		Friend WithEvents lblAQLMsg As System.Windows.Forms.Label
		Friend WithEvents lblBillingMsg As System.Windows.Forms.Label
		Friend WithEvents btnMove As System.Windows.Forms.Button
		Friend WithEvents lblBillingAmt As System.Windows.Forms.Label
		Friend WithEvents lblAQLResult As System.Windows.Forms.Label
		Friend WithEvents lblPalletNa As System.Windows.Forms.Label
		Friend WithEvents lblWHBoxNa As System.Windows.Forms.Label
		Friend WithEvents lblTriageDisp As System.Windows.Forms.Label
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents lblDeviceId As System.Windows.Forms.Label
		Friend WithEvents lblDeviceMsg As System.Windows.Forms.Label
		Friend WithEvents btnClose As System.Windows.Forms.Button
		Friend WithEvents lblLocationMsg As System.Windows.Forms.Label
		Friend WithEvents lblLoc As System.Windows.Forms.Label
		Friend WithEvents btnClear As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.txtSn = New System.Windows.Forms.TextBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblTriageMsg = New System.Windows.Forms.Label()
			Me.lblWHBoxMsg = New System.Windows.Forms.Label()
			Me.lblPalletMsg = New System.Windows.Forms.Label()
			Me.lblAQLMsg = New System.Windows.Forms.Label()
			Me.lblBillingMsg = New System.Windows.Forms.Label()
			Me.btnMove = New System.Windows.Forms.Button()
			Me.lblBillingAmt = New System.Windows.Forms.Label()
			Me.lblAQLResult = New System.Windows.Forms.Label()
			Me.lblPalletNa = New System.Windows.Forms.Label()
			Me.lblWHBoxNa = New System.Windows.Forms.Label()
			Me.lblTriageDisp = New System.Windows.Forms.Label()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.lblDeviceId = New System.Windows.Forms.Label()
			Me.lblDeviceMsg = New System.Windows.Forms.Label()
			Me.btnClose = New System.Windows.Forms.Button()
			Me.lblLoc = New System.Windows.Forms.Label()
			Me.lblLocationMsg = New System.Windows.Forms.Label()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			'
			'txtSn
			'
			Me.txtSn.BackColor = System.Drawing.Color.Yellow
			Me.txtSn.Location = New System.Drawing.Point(128, 24)
			Me.txtSn.Name = "txtSn"
			Me.txtSn.Size = New System.Drawing.Size(232, 20)
			Me.txtSn.TabIndex = 1
			Me.txtSn.Text = ""
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(24, 24)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(80, 23)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Serial Number:"
			'
			'lblTriageMsg
			'
			Me.lblTriageMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblTriageMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblTriageMsg.ForeColor = System.Drawing.Color.Black
			Me.lblTriageMsg.Location = New System.Drawing.Point(128, 88)
			Me.lblTriageMsg.Name = "lblTriageMsg"
			Me.lblTriageMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblTriageMsg.TabIndex = 5
			Me.lblTriageMsg.Text = "Existing Triage record found"
			Me.lblTriageMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblWHBoxMsg
			'
			Me.lblWHBoxMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblWHBoxMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWHBoxMsg.ForeColor = System.Drawing.Color.Black
			Me.lblWHBoxMsg.Location = New System.Drawing.Point(128, 112)
			Me.lblWHBoxMsg.Name = "lblWHBoxMsg"
			Me.lblWHBoxMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblWHBoxMsg.TabIndex = 7
			Me.lblWHBoxMsg.Text = "Existing WH box found"
			Me.lblWHBoxMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblPalletMsg
			'
			Me.lblPalletMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblPalletMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblPalletMsg.ForeColor = System.Drawing.Color.Black
			Me.lblPalletMsg.Location = New System.Drawing.Point(128, 136)
			Me.lblPalletMsg.Name = "lblPalletMsg"
			Me.lblPalletMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblPalletMsg.TabIndex = 9
			Me.lblPalletMsg.Text = "Existing Pallet found"
			Me.lblPalletMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblAQLMsg
			'
			Me.lblAQLMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblAQLMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblAQLMsg.ForeColor = System.Drawing.Color.Black
			Me.lblAQLMsg.Location = New System.Drawing.Point(128, 160)
			Me.lblAQLMsg.Name = "lblAQLMsg"
			Me.lblAQLMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblAQLMsg.TabIndex = 11
			Me.lblAQLMsg.Text = "Existing AQL record found"
			Me.lblAQLMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblBillingMsg
			'
			Me.lblBillingMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblBillingMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBillingMsg.ForeColor = System.Drawing.Color.Black
			Me.lblBillingMsg.Location = New System.Drawing.Point(128, 184)
			Me.lblBillingMsg.Name = "lblBillingMsg"
			Me.lblBillingMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblBillingMsg.TabIndex = 13
			Me.lblBillingMsg.Text = "Existing Billing record(s) found"
			Me.lblBillingMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'btnMove
			'
			Me.btnMove.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
			Me.btnMove.Location = New System.Drawing.Point(112, 288)
			Me.btnMove.Name = "btnMove"
			Me.btnMove.Size = New System.Drawing.Size(216, 40)
			Me.btnMove.TabIndex = 18
			Me.btnMove.Text = "Remove activity for the device and move it back to Triage"
			'
			'lblBillingAmt
			'
			Me.lblBillingAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblBillingAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBillingAmt.ForeColor = System.Drawing.Color.Black
			Me.lblBillingAmt.Location = New System.Drawing.Point(328, 184)
			Me.lblBillingAmt.Name = "lblBillingAmt"
			Me.lblBillingAmt.Size = New System.Drawing.Size(136, 23)
			Me.lblBillingAmt.TabIndex = 14
			Me.lblBillingAmt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblAQLResult
			'
			Me.lblAQLResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblAQLResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblAQLResult.ForeColor = System.Drawing.Color.Black
			Me.lblAQLResult.Location = New System.Drawing.Point(328, 160)
			Me.lblAQLResult.Name = "lblAQLResult"
			Me.lblAQLResult.Size = New System.Drawing.Size(136, 23)
			Me.lblAQLResult.TabIndex = 12
			Me.lblAQLResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblPalletNa
			'
			Me.lblPalletNa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblPalletNa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblPalletNa.ForeColor = System.Drawing.Color.Black
			Me.lblPalletNa.Location = New System.Drawing.Point(328, 136)
			Me.lblPalletNa.Name = "lblPalletNa"
			Me.lblPalletNa.Size = New System.Drawing.Size(136, 23)
			Me.lblPalletNa.TabIndex = 10
			Me.lblPalletNa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblWHBoxNa
			'
			Me.lblWHBoxNa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblWHBoxNa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWHBoxNa.ForeColor = System.Drawing.Color.Black
			Me.lblWHBoxNa.Location = New System.Drawing.Point(328, 112)
			Me.lblWHBoxNa.Name = "lblWHBoxNa"
			Me.lblWHBoxNa.Size = New System.Drawing.Size(136, 23)
			Me.lblWHBoxNa.TabIndex = 8
			Me.lblWHBoxNa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblTriageDisp
			'
			Me.lblTriageDisp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblTriageDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblTriageDisp.ForeColor = System.Drawing.Color.Black
			Me.lblTriageDisp.Location = New System.Drawing.Point(328, 88)
			Me.lblTriageDisp.Name = "lblTriageDisp"
			Me.lblTriageDisp.Size = New System.Drawing.Size(136, 23)
			Me.lblTriageDisp.TabIndex = 6
			Me.lblTriageDisp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(56, 240)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(480, 40)
			Me.lblMsg.TabIndex = 17
			Me.lblMsg.Text = "Message to the user"
			'
			'lblDeviceId
			'
			Me.lblDeviceId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblDeviceId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDeviceId.ForeColor = System.Drawing.Color.Black
			Me.lblDeviceId.Location = New System.Drawing.Point(328, 64)
			Me.lblDeviceId.Name = "lblDeviceId"
			Me.lblDeviceId.Size = New System.Drawing.Size(136, 23)
			Me.lblDeviceId.TabIndex = 4
			Me.lblDeviceId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblDeviceMsg
			'
			Me.lblDeviceMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblDeviceMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDeviceMsg.ForeColor = System.Drawing.Color.Black
			Me.lblDeviceMsg.Location = New System.Drawing.Point(128, 64)
			Me.lblDeviceMsg.Name = "lblDeviceMsg"
			Me.lblDeviceMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblDeviceMsg.TabIndex = 3
			Me.lblDeviceMsg.Text = "Existing Device record found"
			Me.lblDeviceMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'btnClose
			'
			Me.btnClose.Location = New System.Drawing.Point(392, 288)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New System.Drawing.Size(96, 40)
			Me.btnClose.TabIndex = 19
			Me.btnClose.Text = "Close"
			'
			'lblLoc
			'
			Me.lblLoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLoc.ForeColor = System.Drawing.Color.Black
			Me.lblLoc.Location = New System.Drawing.Point(328, 208)
			Me.lblLoc.Name = "lblLoc"
			Me.lblLoc.Size = New System.Drawing.Size(136, 23)
			Me.lblLoc.TabIndex = 16
			Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblLocationMsg
			'
			Me.lblLocationMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblLocationMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLocationMsg.ForeColor = System.Drawing.Color.Black
			Me.lblLocationMsg.Location = New System.Drawing.Point(128, 208)
			Me.lblLocationMsg.Name = "lblLocationMsg"
			Me.lblLocationMsg.Size = New System.Drawing.Size(192, 23)
			Me.lblLocationMsg.TabIndex = 15
			Me.lblLocationMsg.Text = "Existing Location record found"
			Me.lblLocationMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'btnClear
			'
			Me.btnClear.Location = New System.Drawing.Point(392, 24)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(72, 24)
			Me.btnClear.TabIndex = 2
			Me.btnClear.Text = "Clear"
			'
			'frmWFMSetDeviceBackToTriage
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
			Me.ClientSize = New System.Drawing.Size(560, 344)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.lblLoc, Me.lblLocationMsg, Me.btnClose, Me.lblDeviceId, Me.lblDeviceMsg, Me.lblMsg, Me.lblBillingAmt, Me.lblAQLResult, Me.lblPalletNa, Me.lblWHBoxNa, Me.lblTriageDisp, Me.btnMove, Me.lblBillingMsg, Me.lblAQLMsg, Me.lblPalletMsg, Me.lblWHBoxMsg, Me.lblTriageMsg, Me.Label1, Me.txtSn})
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "frmWFMSetDeviceBackToTriage"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "WFM  Move Device Back To Triage"
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
		Private _device_id As Integer = 0
		Private _device_found As Boolean = False
		Private _triage_found As Boolean = False
		Private _whbox_found As Boolean = False
		Private _pallet_found As Boolean = False
		Private _aql_found As Boolean = False
		Private _billing_found As Boolean = False
		Private _loc_found As Boolean = False
#End Region
#Region "FORM EVENTS"
		Private Sub frmWFMSetDeviceBackToTriage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' ON FORM OPEN.
			ClearAll()
			EnableControls()
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub txtSn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSn.KeyDown
			' HANDLES EVENT TO START THE SEARCH PROCESS IF ENTER KEY IS PRESSED.
			If e.KeyCode = Keys.Enter Then
				Try
					If txtSn.Text = "" Then Exit Sub
					Dim _sn As String = txtSn.Text
					Me.Cursor = Cursors.WaitCursor
					Search(_sn)
				Catch ex As Exception
					MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Finally
					Me.Cursor = Cursors.Default
				End Try
			End If
		End Sub
		Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
			' HANDLES EVENT TO START THE MOVE TO TRIAGE PROCESS IF VALID.
			Dim _msg As String = "Would you like to proceed and move this device back to Triage?"
			Dim _sn As String = txtSn.Text
			If lblLoc.Text = "TRIAGE" Then
				MessageBox.Show("This device is already in Triage.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			Else
				If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
					Try
						Me.Cursor = Cursors.WaitCursor
						MoveToTriage()
						ClearAll()
						txtSn.Text = _sn
						Search(_sn)
						txtSn.Focus()
					Catch ex As Exception
						MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Finally
						Me.Cursor = Cursors.Default
					End Try
				End If
			End If
		End Sub
		Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
			Me.Close()
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			ClearAll()
			EnableControls()
		End Sub
#End Region
#Region "METHODS"
		Private Sub EnableControls()
			' ENABLES OR DISABLES ALL CONTROLS AS NEEDED.
			btnMove.Enabled = _device_found
		End Sub
		Private Sub ClearAll()
			' CLEARS ALL CONTROLS AND VARIABLES.
			ClearResults()
			ClearSN()
			ClearMsg()
		End Sub
		Private Sub ClearResults()
			' CLEAR VARIABLES.
			_device_id = 0
			_device_found = False
			_triage_found = False
			_whbox_found = False
			_pallet_found = False
			_aql_found = False
			_billing_found = False
			' CLEAR CONTROLS.
			lblDeviceMsg.Text = ""
			lblTriageMsg.Text = ""
			lblWHBoxMsg.Text = ""
			lblPalletMsg.Text = ""
			lblAQLMsg.Text = ""
			lblBillingMsg.Text = ""
			lblLocationMsg.Text = ""
			lblDeviceId.Text = ""
			lblTriageDisp.Text = ""
			lblWHBoxNa.Text = ""
			lblPalletNa.Text = ""
			lblAQLResult.Text = ""
			lblBillingAmt.Text = ""
			lblLoc.Text = ""
		End Sub
		Private Sub ClearSN()
			' CLEARS THE SERIAL NUMBER.
			txtSn.Text = ""
		End Sub
		Private Sub Search(ByVal sn As String)
			' PERFORMS A SEARCH BASED ON THE SERIAL NUMBER.
			Dim _sn As String = sn
			Dim _triage_disp As String = ""
			Dim _whb_na As String = ""
			Dim _pallet_na As String = ""
			Dim _aql_result As String = ""
			Dim _billing_amt As Decimal = 0.0
			Dim _loc As String = ""
			ClearResults()
			' DOES DEVICE EXISTS
			_device_id = GetDeviceID(_sn)
			If _device_id > 0 Then
				_device_found = True
				lblDeviceMsg.Text = IIf(_device_found, "Device record found", "")
				lblDeviceId.Text = _device_id.ToString()
				' DOES TRIAGE EXISTS.
				_triage_disp = GetTriageDisp(_device_id)
				_triage_found = (_triage_disp <> "")
				lblTriageMsg.Text = IIf(_triage_found, "Triage record found", "")
				lblTriageDisp.Text = _triage_disp
				' DOES WH BOX OR PALLET EXISTS.
				Dim _whd As New BLL.WFMDevice()
				Dim _dt As New DataTable()
				_dt = _whd.GetDeviceInfo(_sn)
				If _dt.Rows.Count > 0 Then
					_whb_na = _dt.Rows(0)("box_na").ToString()
					_whbox_found = (_whb_na <> "")
					lblWHBoxMsg.Text = IIf(_whbox_found, "WH Box found", "")
					lblWHBoxNa.Text = _whb_na
					'
					_pallet_na = _dt.Rows(0)("pallett_name").ToString()
					_pallet_found = (_pallet_na <> "")
					lblPalletMsg.Text = IIf(_pallet_found, "Pallet found", "")
					lblPalletNa.Text = _pallet_na
					'
					_loc = _dt.Rows(0)("workstation").ToString
					_loc_found = _loc <> ""
					lblLocationMsg.Text = IIf(_loc_found, "Location found", "")
					lblLoc.Text = _loc
				End If
				_whd = Nothing
				_dt = Nothing
				' DOES AQL EXISTS.
				_aql_result = GetAQLResult(_device_id)
				_aql_found = (_aql_result.ToString() <> "")
				lblAQLMsg.Text = IIf(_aql_found, "AQL record found", "")
				lblAQLResult.Text = _aql_result
				' DOES BILLING EXISTS.
				Dim _billing As New BOL.tDeviceBillShared()
				_billing_amt = _billing.GetInvAmtForDevice(_device_id)
				_billing_found = (_billing_amt <> 0)
				lblBillingMsg.Text = IIf(_billing_found, "Billing record(s) found", "")
				lblBillingAmt.Text = IIf(_billing_amt > 0, _billing_amt.ToString, "")
				_billing = Nothing
				EnableControls()
			Else
				EnableControls()
				Throw New Exception("The serial number was not found for the WFM customer.")
			End If
		End Sub
		Private Sub PostMsg(ByVal msg As String)
			' POST A MESSAGE TO THE USER.
			lblMsg.Text = msg
		End Sub
		Private Sub ClearMsg()
			' CLEARS THE MESSAGE TO THE USER.
			lblMsg.Text = ""
		End Sub
		Private Sub MoveToTriage()
			' GET THE DEVICE RECORD.
			Dim _d As New BOL.tDevice(_device_id)
			Dim _itm As New BOL.titem(_device_id)
			Dim _pallet_id As Integer = 0
			Dim _pallet_qty As Integer
			' REMOVE BILLING.
			If _billing_found Then
				Dim _blng As New BLL.WFMBilling(PSS.Core.ApplicationUser.IDuser)
				_blng.RemoveBillingFromDevice(_device_id)
				_blng = Nothing
				' REMOVES THE LABOR CHARGE FROM TDEVICE.
				_d.Device_LaborCharge = 0
			End If
			' REMOVE DEVICE FROM PALLET.
			If _pallet_found Then
				_pallet_id = _d.Pallett_ID
				_d.Pallett_ID = 0
				Dim _p As New BOL.tpallet(_pallet_id)
				_p.Pallett_QTY = _p.Pallett_QTY - 1
				_pallet_qty = _p.Pallett_QTY
				_p.ApplyChanges()
				_p = Nothing
			End If
			' REMOVE WH BOX.
			If _whbox_found Then
				Dim _whb_id As Integer = _itm.whb_id
				_itm.whb_id = 0
				Dim _wb As New BOL.wh_box(_whb_id)
				_wb.quantity = _wb.quantity - 1
				If _wb.quantity < 1 Then
					_wb.MarkForDeletion()
				End If
				_wb.ApplyChanges()
				_wb = Nothing
			End If
			' REMOVE TRIAGE.
			If _triage_found Then
				Dim _trg As New BOL.tdevice_triage(_device_id)
				_trg.MarkForDeletion()
				_trg.ApplyChanges()
			End If
			' UPDATE WORKSTATION.
			Dim _co As New BOL.tcellopt(_device_id)
			_co.WorkStation = "TRIAGE"
			_co.Cellopt_WIPOwner = 0
			_co.WorkStationEntryDt = Date.Now
			_co.ApplyChanges()
			_co = Nothing
			' APPLY CHANGES TO THE TDEVICE RECORD.
			_d.ApplyChanges()
			_itm.ApplyChanges()
			_d = Nothing
			_itm = Nothing
			' REMOVE THE PALLET IF THE PALLET QTY IS 0.
			If _pallet_id AndAlso _pallet_qty < 1 Then
				Dim _misc As New Buisness.Misc()
				_misc.DeletePallet(_pallet_id)
				_misc = Nothing
			End If
		End Sub
		Private Function GetDeviceID(ByVal sn As String) As Integer
			' RETURNS THE DEVICE_ID ASSOCIATED TO THE SERIAL NUMBER AND LOCATION ID.
			Dim _device_id As Integer = 0
			Dim _dev As New BOL.tDevice(sn, 3402)
			_device_id = _dev.Device_ID
			_dev = Nothing
			Return _device_id
		End Function
		Private Function GetTriageDisp(ByVal device_id As Integer) As String
			' RETURNS THE DISPOSITION CODE FOR THE DEVICE'S DISPOSITION.
			Dim _disp As String = ""
			Dim _trg As New BOL.tdevice_triage(device_id)
			Select Case _trg.disp_id
				Case 0 : _disp = ""
				Case 2 : _disp = "SOF"
				Case 3 : _disp = "FUN"
				Case 4 : _disp = "COS"
				Case 5 : _disp = "NTF"
			End Select
			_trg = Nothing
			Return _disp
		End Function
		Private Function GetAQLResult(ByVal device_id As Integer) As String
			' RETURNS THE AQL RESULT FOR THE DEVICE.
			Dim _retVal As String = ""
			Dim _aql As New BOL.tqcDeviceQcCollection(device_id, 4)
			If _aql.tqcDataTable.Rows.Count > 0 Then
				_retVal = _aql.tqcDataTable.Rows(0)("qcresult").ToString()
			End If
			_aql = Nothing
			Return _retVal
		End Function
#End Region
	End Class
End Namespace
