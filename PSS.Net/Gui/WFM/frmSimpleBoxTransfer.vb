Imports PSS.Data
Namespace Gui.WFMTracfone
	Public Class frmSimpleBoxTransfer
		Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

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
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents lblToLoc As System.Windows.Forms.Label
		Friend WithEvents txt_box_na As System.Windows.Forms.TextBox
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents lblQty As System.Windows.Forms.Label
		Friend WithEvents lblModel As System.Windows.Forms.Label
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents btnTransfer As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.lblToLoc = New System.Windows.Forms.Label()
			Me.txt_box_na = New System.Windows.Forms.TextBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblQty = New System.Windows.Forms.Label()
			Me.lblModel = New System.Windows.Forms.Label()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.btnTransfer = New System.Windows.Forms.Button()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			'
			'lblToLoc
			'
			Me.lblToLoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblToLoc.ForeColor = System.Drawing.Color.RoyalBlue
			Me.lblToLoc.Location = New System.Drawing.Point(16, 8)
			Me.lblToLoc.Name = "lblToLoc"
			Me.lblToLoc.Size = New System.Drawing.Size(360, 24)
			Me.lblToLoc.TabIndex = 10
			'
			'txt_box_na
			'
			Me.txt_box_na.Location = New System.Drawing.Point(96, 56)
			Me.txt_box_na.Name = "txt_box_na"
			Me.txt_box_na.Size = New System.Drawing.Size(248, 20)
			Me.txt_box_na.TabIndex = 11
			Me.txt_box_na.Text = ""
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(24, 56)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(56, 23)
			Me.Label1.TabIndex = 12
			Me.Label1.Text = "Box ID:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'lblQty
			'
			Me.lblQty.BackColor = System.Drawing.Color.Gainsboro
			Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblQty.Location = New System.Drawing.Point(96, 96)
			Me.lblQty.Name = "lblQty"
			Me.lblQty.TabIndex = 13
			Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblModel
			'
			Me.lblModel.BackColor = System.Drawing.Color.Gainsboro
			Me.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblModel.Location = New System.Drawing.Point(96, 136)
			Me.lblModel.Name = "lblModel"
			Me.lblModel.Size = New System.Drawing.Size(248, 23)
			Me.lblModel.TabIndex = 14
			Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label4
			'
			Me.Label4.Location = New System.Drawing.Point(24, 96)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(56, 23)
			Me.Label4.TabIndex = 15
			Me.Label4.Text = "Qty:"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'Label5
			'
			Me.Label5.Location = New System.Drawing.Point(24, 136)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(56, 23)
			Me.Label5.TabIndex = 16
			Me.Label5.Text = "Model:"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'btnClear
			'
			Me.btnClear.Location = New System.Drawing.Point(136, 192)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(88, 23)
			Me.btnClear.TabIndex = 17
			Me.btnClear.Text = "Clear"
			'
			'btnTransfer
			'
			Me.btnTransfer.Location = New System.Drawing.Point(256, 192)
			Me.btnTransfer.Name = "btnTransfer"
			Me.btnTransfer.Size = New System.Drawing.Size(88, 23)
			Me.btnTransfer.TabIndex = 18
			Me.btnTransfer.Text = "Transfer"
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(16, 168)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(368, 16)
			Me.lblMsg.TabIndex = 19
			'
			'frmSimpleBoxTransfer
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(392, 238)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMsg, Me.btnTransfer, Me.btnClear, Me.Label5, Me.Label4, Me.lblModel, Me.lblQty, Me.Label1, Me.txt_box_na, Me.lblToLoc})
			Me.Name = "frmSimpleBoxTransfer"
			Me.Text = "WFM Simple Box Tranfer"
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
		Private _cust_id As Integer = 0
		Private _prod_id As Integer = 0
		Private _disp_id As Integer = 0
		Private _cpl_id As Integer = 0
		Private _cpl_id_to As Integer = 0
		Private _fromLoc As String = ""
		Private _toLoc As String = ""
		Private _user_id As Integer = 0
#End Region
#Region "CONTRUCTORS"
		Public Sub New(ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal disp_id As String, ByVal cpl_id As Integer, ByVal cpl_id_to As Integer)
			MyBase.New()
			InitializeComponent()
			_cust_id = cust_id
			_prod_id = prod_id
			_cpl_id = cpl_id
			_cpl_id_to = cpl_id_to
		End Sub
#End Region
#Region "FORM EVENTS"
		Private Sub frmWhToStaging_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			_user_id = PSS.Core.ApplicationUser.IDuser
			_fromLoc = GetLocation(_cpl_id)
			_toLoc = GetLocation(_cpl_id_to)
			lblToLoc.Text = "Transfer Box to " & _toLoc
			EnableControls()
			txt_box_na.Focus()
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub txt_box_na_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_box_na.KeyDown
			If e.KeyValue = Keys.Enter Then
				GetAndValidateBox(txt_box_na.Text)
			End If
		End Sub
		Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
			TransferBox(txt_box_na.Text)
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			ClearTheScreen()
		End Sub
#End Region
#Region "METHODS"
		Private Function GetLocation(ByVal cpl_id) As String
			Dim _retVal As String = ""
			Dim _fl As New BOL.tcustomer_prod_locations(cpl_id)
			_retVal = _fl.loc_na
			_fl = Nothing
			Return _retVal
		End Function
		Private Sub EnableControls()

		End Sub
		Private Sub GetAndValidateBox(ByVal box_na As String)
			Dim _boxRo As New BOL.wh_box_readonly(box_na)
			Dim _box_id As Integer = 0
			Dim _model_id As String
			_box_id = _boxRo.whb_id
			_model_id = _boxRo.model_id
			lblQty.Text = _boxRo.quantity
			lblModel.Text = _boxRo.model_desc
			_boxRo = Nothing
			If _box_id > 0 Then
				Dim _whb As New BLL.WHBoxMovement(_box_id, _cust_id, _prod_id, _disp_id, _cpl_id, _cpl_id_to, _user_id)
				lblMsg.Text = _whb.ValidateBoxTransfer()
				_whb = Nothing
			End If
		End Sub
		Private Sub TransferBox(ByVal box_na As String)
			Dim _boxRo As New BOL.wh_box_readonly(box_na)
			Dim _box_id As Integer = 0
			Dim _model_id As String
			_box_id = _boxRo.whb_id
			_model_id = _boxRo.model_id
			lblQty.Text = _boxRo.quantity
			lblModel.Text = _boxRo.model_desc
			_boxRo = Nothing
			If _box_id > 0 Then
				Dim _whb As New BLL.WHBoxMovement(_box_id, _cust_id, _prod_id, _disp_id, _cpl_id, _cpl_id_to, _user_id)
				If Not _whb.PerformTransfer() Then
					MessageBox.Show("Box did not transfer.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
				Else
					MessageBox.Show("Box transfer was successful.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
					ClearTheScreen()
				End If
				_whb = Nothing
			End If
		End Sub
		Private Sub ClearTheScreen()
			txt_box_na.Text = ""
			lblQty.Text = ""
			lblModel.Text = ""
			lblMsg.Text = ""
			txt_box_na.Focus()
		End Sub
#End Region
	End Class
End Namespace
