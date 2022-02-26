Imports PSS.Data

Public Class frmDispositionEdit
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
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents txtCd As System.Windows.Forms.TextBox
	Friend WithEvents txtNa As System.Windows.Forms.TextBox
	Friend WithEvents txtDispId As System.Windows.Forms.TextBox
	Friend WithEvents txtCrtTs As System.Windows.Forms.TextBox
	Friend WithEvents txtCrtBy As System.Windows.Forms.TextBox
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnSave As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtCd = New System.Windows.Forms.TextBox()
		Me.txtNa = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtDispId = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtCrtTs = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtCrtBy = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(64, 96)
		Me.Label1.Name = "Label1"
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Code:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtCd
		'
		Me.txtCd.Location = New System.Drawing.Point(176, 96)
		Me.txtCd.Name = "txtCd"
		Me.txtCd.Size = New System.Drawing.Size(64, 20)
		Me.txtCd.TabIndex = 1
		Me.txtCd.Text = ""
		'
		'txtNa
		'
		Me.txtNa.Location = New System.Drawing.Point(176, 128)
		Me.txtNa.Name = "txtNa"
		Me.txtNa.Size = New System.Drawing.Size(208, 20)
		Me.txtNa.TabIndex = 3
		Me.txtNa.Text = ""
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(64, 128)
		Me.Label2.Name = "Label2"
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Description:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
		Me.Label3.Location = New System.Drawing.Point(40, 8)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(344, 32)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Disposition Edit Screen"
		'
		'txtDispId
		'
		Me.txtDispId.Location = New System.Drawing.Point(176, 64)
		Me.txtDispId.Name = "txtDispId"
		Me.txtDispId.ReadOnly = True
		Me.txtDispId.Size = New System.Drawing.Size(64, 20)
		Me.txtDispId.TabIndex = 6
		Me.txtDispId.Text = ""
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(64, 64)
		Me.Label4.Name = "Label4"
		Me.Label4.TabIndex = 5
		Me.Label4.Text = "Disposition ID:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtCrtTs
		'
		Me.txtCrtTs.Location = New System.Drawing.Point(176, 160)
		Me.txtCrtTs.Name = "txtCrtTs"
		Me.txtCrtTs.ReadOnly = True
		Me.txtCrtTs.Size = New System.Drawing.Size(208, 20)
		Me.txtCrtTs.TabIndex = 8
		Me.txtCrtTs.Text = ""
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(64, 160)
		Me.Label5.Name = "Label5"
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "Created:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtCrtBy
		'
		Me.txtCrtBy.Location = New System.Drawing.Point(176, 192)
		Me.txtCrtBy.Name = "txtCrtBy"
		Me.txtCrtBy.ReadOnly = True
		Me.txtCrtBy.Size = New System.Drawing.Size(208, 20)
		Me.txtCrtBy.TabIndex = 10
		Me.txtCrtBy.Text = ""
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(64, 192)
		Me.Label6.Name = "Label6"
		Me.Label6.TabIndex = 9
		Me.Label6.Text = "Created By:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(168, 240)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(88, 32)
		Me.btnCancel.TabIndex = 11
		Me.btnCancel.Text = "Cancel"
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(296, 240)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(88, 32)
		Me.btnSave.TabIndex = 12
		Me.btnSave.Text = "Save"
		'
		'frmDispositionEdit
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(448, 302)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSave, Me.btnCancel, Me.txtCrtBy, Me.Label6, Me.txtCrtTs, Me.Label5, Me.txtDispId, Me.Label4, Me.Label3, Me.txtNa, Me.Label2, Me.txtCd, Me.Label1})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "frmDispositionEdit"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Dispostion Edit Screen"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private _obj As BOL.tdispositions

	Public Sub New(ByVal id As Integer)
		MyBase.New()
		InitializeComponent()
		If id > 0 Then
			_obj = New BOL.tdispositions(id)
		Else
			_obj = New BOL.tdispositions()
			_obj.crt_user_id = PSS.Core.ApplicationUser.IDuser
		End If
	End Sub

	Private Sub frmDispositionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		PopulateTheForm()
	End Sub

	Private Sub PopulateTheForm()
		txtDispId.Text = _obj.disp_id.ToString()
		txtCd.Text = _obj.disp_cd
		txtNa.Text = _obj.disp_na
		txtCrtTs.Text = _obj.crt_ts
		txtCrtBy.Text = _obj.crt_user_id.ToString()
	End Sub

	Private Sub UpdateTheObject()
		_obj.disp_cd = txtCd.Text
		_obj.disp_na = txtNa.Text
		_obj.ApplyChanges()
		Me.Close()
	End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		If MessageBox.Show("Cancel and close this screen?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Me.Close()
		End If
	End Sub

	Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
		If MessageBox.Show("Save this record and close this screen?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			SaveRecord()
			Me.Close()
		End If
	End Sub

	Private Sub SaveRecord()
		UpdateTheObject()
	End Sub

	Private Sub frmDispositionEdit_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		_obj = Nothing
	End Sub

End Class
