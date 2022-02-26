Imports PSS.Data
Namespace Gui
	Public Class frmAmsWhToPreEvalTransfer
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
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents lblLastStatus As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.txtSn = New System.Windows.Forms.TextBox()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.lblLastStatus = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(40, 32)
			Me.Label1.Name = "Label1"
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Serial Number:"
			'
			'txtSn
			'
			Me.txtSn.BackColor = System.Drawing.Color.Yellow
			Me.txtSn.Location = New System.Drawing.Point(160, 32)
			Me.txtSn.Name = "txtSn"
			Me.txtSn.Size = New System.Drawing.Size(208, 20)
			Me.txtSn.TabIndex = 1
			Me.txtSn.Text = ""
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(96, 168)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(440, 72)
			Me.lblMsg.TabIndex = 2
			Me.lblMsg.Text = "Message to the user."
			'
			'lblLastStatus
			'
			Me.lblLastStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLastStatus.ForeColor = System.Drawing.Color.Blue
			Me.lblLastStatus.Location = New System.Drawing.Point(344, 80)
			Me.lblLastStatus.Name = "lblLastStatus"
			Me.lblLastStatus.Size = New System.Drawing.Size(352, 56)
			Me.lblLastStatus.TabIndex = 3
			Me.lblLastStatus.Text = "Last Device Message"
			'
			'Label2
			'
			Me.Label2.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.Label2.Location = New System.Drawing.Point(24, 336)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(672, 48)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "This screen is used to transfer Messaging devices from the Warehouse to Pre-Eval." & _
			"  All you have to do is scan the device and the transfer will be made as long as" & _
			" the device was previously recorded in the system and is currently stored in the" & _
			" Warehouse."
			'
			'frmAmsWhToPreEvalTransfer
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(712, 390)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.lblLastStatus, Me.lblMsg, Me.txtSn, Me.Label1})
			Me.Name = "frmAmsWhToPreEvalTransfer"
			Me.Text = "AMS Warehouse to Pre-Eval Transfer"
			Me.ResumeLayout(False)

		End Sub

#End Region
		' CREATED BY: DAVID BRADLEY 03/16/2017
		' This screen is used to transfer Messaging devices from the 
		' Warehouse to Pre-Eval.  All you have to do is scan the device 
		' and the transfer will be made as long as the device was 
		' previously recorded in the system and is currently stored in 
		' the Warehouse.
#Region "DECLARATIONS"
		Private _md_id As Integer = 0
		Private _device_id As Integer = 0
#End Region
#Region "FORM EVENTS"
		Private Sub frmAmsWhToPreEvalTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			ClearAll()
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub txtSn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSn.KeyDown
			ClearUserMsg()
			If e.KeyCode = Keys.Enter Then
				ClearLastDeviceMsg()
				' VALIDATE.
				If ValidateLocation() Then
					' TRANSFER.
					If Transfer() Then
						' ON SUCCESS.
						PostLastDeviceMsg(txtSn.Text & " has been transfered to Pre-Eval.")
						ClearSN()
						txtSn.Focus()
					Else
						' ON FAILURE
						PostUserMsg("Transfer Failed to Complete.")
						txtSn.SelectAll()
					End If
				Else
					' ON DEVICE NOT VALID.
					PostUserMsg("Validation failed due to the device not being in the system or being stored in a location other than WH.")
					txtSn.SelectAll()
				End If
			End If
		End Sub
#End Region
#Region "METHODS"
		Private Function ValidateLocation() As Boolean
			Dim _retVal As Boolean = False
			Dim _sn As String = txtSn.Text
			' CHECK TO MAKE SURE THE DEVICE EXISTS IN THE WAREHOUSE.
			Dim _d As New BOL.tDevice(_sn, False)
			If _d.Device_ID > 0 Then
				' SET _device_id VARIABLE.
				_device_id = _d.Device_ID
				Dim _md As New BOL.tMessData(_device_id)
				If _md.MD_ID > 0 Then
					If _md.wipowner_id = 201 Then
						' SET _md_id VARIABLE.
						_md_id = _md.MD_ID
						_retVal = True
					End If
				End If
				_md = Nothing
			End If
			_d = Nothing
			Return _retVal
		End Function
		Private Function Transfer() As Boolean
			Dim _retVal As Boolean = False
			Dim _md As New BOL.tMessData(_device_id)
			Try
				If _md.MD_ID > 0 Then
					' TRANSFER THE DEVICE TO PRE-EVAL.
					_md.wipowner_id = 202
					_md.EvalFlag = 1
					_md.ApplyChanges()
					_retVal = True
					Return _retVal
				Else
					Throw New Exception("Device could not be transfered due to missing data.")
				End If
			Catch ex As Exception
				_retVal = False
				Throw New Exception("Device could not be transfered.")
			Finally
				_md = Nothing
			End Try
			Return _retVal
		End Function
		Private Sub ClearAll()
			' CLEAR EVERYTHING.
			ClearSN()
			ClearLastDeviceMsg()
			ClearUserMsg()
			txtSn.Focus()
		End Sub
		Private Sub PostLastDeviceMsg(ByVal msg)
			' POST LAST DEVICE STATUS MESSAGE.
			lblLastStatus.Text = msg
		End Sub
		Private Sub ClearLastDeviceMsg()
			' CLEAR LAST DEVICE STATUS MESSAGE.
			lblLastStatus.Text = ""
		End Sub
		Private Sub PostUserMsg(ByVal msg As String)
			' POST MESSAGE TO THE USER.
			lblMsg.Text = msg
		End Sub
		Private Sub ClearUserMsg()
			' CLEAR MESSAGE TO THE USER.
			lblMsg.Text = ""
		End Sub
		Private Sub ClearSN()
			' CLEAR VARIABLES AND CONTROLS.
			_device_id = 0
			_md_id = 0
			txtSn.Text = ""
		End Sub
#End Region
	End Class
End Namespace
