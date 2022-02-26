Public Class frmMsgDbrNerRemoval
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
	Friend WithEvents lblMsg As System.Windows.Forms.Label
	Friend WithEvents txtSn As System.Windows.Forms.TextBox
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnRemove As System.Windows.Forms.Button
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents cboModel As System.Windows.Forms.ComboBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblMsg = New System.Windows.Forms.Label()
		Me.txtSn = New System.Windows.Forms.TextBox()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnRemove = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cboModel = New System.Windows.Forms.ComboBox()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(32, 56)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(96, 23)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "Serial Number:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblMsg
		'
		Me.lblMsg.BackColor = System.Drawing.Color.DarkGray
		Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMsg.Location = New System.Drawing.Point(144, 104)
		Me.lblMsg.Name = "lblMsg"
		Me.lblMsg.Size = New System.Drawing.Size(248, 23)
		Me.lblMsg.TabIndex = 2
		Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txtSn
		'
		Me.txtSn.BackColor = System.Drawing.Color.Yellow
		Me.txtSn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSn.Location = New System.Drawing.Point(144, 56)
		Me.txtSn.Name = "txtSn"
		Me.txtSn.Size = New System.Drawing.Size(248, 20)
		Me.txtSn.TabIndex = 1
		Me.txtSn.Text = ""
		'
		'btnCancel
		'
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.Location = New System.Drawing.Point(216, 152)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancel"
		'
		'btnRemove
		'
		Me.btnRemove.BackColor = System.Drawing.SystemColors.Control
		Me.btnRemove.Location = New System.Drawing.Point(320, 152)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.TabIndex = 4
		Me.btnRemove.Text = "Remove"
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(32, 16)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(96, 23)
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "Model:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cboModel
		'
		Me.cboModel.Location = New System.Drawing.Point(144, 16)
		Me.cboModel.Name = "cboModel"
		Me.cboModel.Size = New System.Drawing.Size(248, 21)
		Me.cboModel.TabIndex = 0
		'
		'frmMsgDbrNerRemoval
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.Color.LightSteelBlue
		Me.ClientSize = New System.Drawing.Size(440, 192)
		Me.ControlBox = False
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModel, Me.Label2, Me.btnRemove, Me.btnCancel, Me.txtSn, Me.lblMsg, Me.Label1})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmMsgDbrNerRemoval"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Messaging DBR/NER Removal"
		Me.ResumeLayout(False)

	End Sub

#End Region
#Region "DECLARATIONS"
	Private _username As String = ""
	Private _cmp_na As String = ""
	Private _devicecodeid As Integer = 0
#End Region
#Region "CONSTRUCTORS"

#End Region
#Region "FORM EVENTS"
	Private Sub frmMsgDbrNerRemoval_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		_username = PSS.Core.Global.ApplicationUser.User
		_cmp_na = Environment.MachineName
		LoadModelCombo()
		ClearAll()
		EnableControls()
	End Sub
#End Region
#Region "CONTROL EVENTS"
	Private Sub txtSn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSn.KeyDown
		If e.KeyCode = Keys.Enter Then
			DoDBRNerSearch()
		End If
	End Sub
	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub
	Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
		Dim _device_id As Integer = 0
		Try
			If MessageBox.Show("Proceed to remove the DBR/NER record from this device?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				' REMOVE THE DBR/NER RECORD.
				Dim _dcs As New Data.BOL.tdevicecodes(_devicecodeid)
				_device_id = _dcs.Device_ID
				_dcs.MarkDeleted()
				_dcs.ApplyChanges()
				_dcs = Nothing

				Dim _co As New Data.BOL.tcellopt(_device_id)
				Dim _ws As String = _co.WorkStation
				_co = Nothing

				' ADD THE DEVICE JOURNAL ENTRY.
				Dim _dwsj As New PSS.Data.BOL.tdevice_workstation_journal(_device_id, 1, "Pre-Eval", "", _username, _cmp_na, "DBR/NER Removed")
				_dwsj.ApplyChanges()

				' RESET THE SCREEN.
				ClearAll()
				' NOTIFY USER.
				MessageBox.Show("DBR/NER has been removed.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				Me.Close()
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub
	Private Sub cboModel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedIndexChanged
		txtSn.Text = ""
		txtSn.Focus()
		EnableControls()
	End Sub
#End Region
#Region "PROPERTIES"

#End Region
#Region "METHODS"
	Private Sub LoadModelCombo()
		Dim _dt As New DataTable()
		_dt = PSS.Data.Buisness.Generic.GetModels(True, 1, )
		_dt.DefaultView.RowFilter = "Model_desc <> 'Coaster'"
		cboModel.DataSource = _dt
		cboModel.ValueMember = "Model_id"
		cboModel.DisplayMember = "Model_desc"
	End Sub
	Private Sub DoDBRNerSearch()
		Dim _sn As String = txtSn.Text
		Dim _model_id As Integer = cboModel.SelectedValue
		Dim _dcid As Integer = 0
		Dim _amsr As New Data.BLL.AMSReceiving()
		Try
			If _sn = "" Or _model_id = 0 Then
				MessageBox.Show("You must select a model and enter a serial number.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
			_dcid = _amsr.GetDbrNerForSN(_sn, _model_id)
			If _dcid > 0 Then
				_devicecodeid = _dcid
				lblMsg.Text = "DBR/NER Record Found"
			Else
				lblMsg.Text = "Record Not Found"
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			_amsr = Nothing
			EnableControls()
		End Try
	End Sub
	Private Function HasDbrNerTransaction(ByVal sn As String, ByVal model_id As Integer) As Integer
		' DAVID BRADLEY - 03-10-2017
		' THIS FUNCTION WILL DETERMINE IF THERE ARE ANY DBR/NER RECORDS FOR THIS SERIAL NUMBER 
		' AND RETURN THE DEVICECODEID FOR THE RECORD.
		Dim _retVal As Integer = 0
		Dim _dm As New Data.BLL.AMSReceiving()
		_retVal = _dm.GetDbrNerForSN(sn, model_id)
		Return _retVal
	End Function
	Private Sub EnableControls()
		btnRemove.Enabled = (lblMsg.Text = "DBR/NER Record Found")
	End Sub
	Private Sub ClearAll()
		_devicecodeid = 0
		txtSn.Text = ""
		cboModel.SelectedIndex = 0
	End Sub
#End Region
End Class
