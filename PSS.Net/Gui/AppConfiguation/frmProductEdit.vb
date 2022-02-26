Imports PSS.Data

Public Class frmProductEdit
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
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents txtProdId As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtDesc As System.Windows.Forms.TextBox
	Friend WithEvents cbInactive As System.Windows.Forms.CheckBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.txtProdId = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtDesc = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cbInactive = New System.Windows.Forms.CheckBox()
		Me.SuspendLayout()
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(264, 192)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(88, 32)
		Me.btnSave.TabIndex = 25
		Me.btnSave.Text = "Save"
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(136, 192)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(88, 32)
		Me.btnCancel.TabIndex = 24
		Me.btnCancel.Text = "Cancel"
		'
		'txtProdId
		'
		Me.txtProdId.Location = New System.Drawing.Point(144, 64)
		Me.txtProdId.Name = "txtProdId"
		Me.txtProdId.ReadOnly = True
		Me.txtProdId.Size = New System.Drawing.Size(64, 20)
		Me.txtProdId.TabIndex = 19
		Me.txtProdId.Text = ""
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(32, 64)
		Me.Label4.Name = "Label4"
		Me.Label4.TabIndex = 18
		Me.Label4.Text = "Product ID:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
		Me.Label3.Location = New System.Drawing.Point(8, 8)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(344, 32)
		Me.Label3.TabIndex = 17
		Me.Label3.Text = "Product Edit Screen"
		'
		'txtDesc
		'
		Me.txtDesc.Location = New System.Drawing.Point(144, 104)
		Me.txtDesc.Name = "txtDesc"
		Me.txtDesc.Size = New System.Drawing.Size(208, 20)
		Me.txtDesc.TabIndex = 16
		Me.txtDesc.Text = ""
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(32, 104)
		Me.Label2.Name = "Label2"
		Me.Label2.TabIndex = 15
		Me.Label2.Text = "Description:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cbInactive
		'
		Me.cbInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.cbInactive.Location = New System.Drawing.Point(72, 144)
		Me.cbInactive.Name = "cbInactive"
		Me.cbInactive.Size = New System.Drawing.Size(96, 24)
		Me.cbInactive.TabIndex = 26
		Me.cbInactive.Text = "Inactive"
		'
		'frmProductEdit
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(448, 246)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbInactive, Me.btnSave, Me.btnCancel, Me.txtProdId, Me.Label4, Me.Label3, Me.txtDesc, Me.Label2})
		Me.Name = "frmProductEdit"
		Me.Text = "Product Edit"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private _obj As BOL.lproduct
	Public Sub New(ByVal id As Integer)
		MyBase.New()
		InitializeComponent()
		If id > 0 Then
			_obj = New BOL.lproduct(id)
		Else
			_obj = New BOL.lproduct()
		End If
	End Sub
	Private Sub frmProdositionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		PopulateTheForm()
	End Sub
	Private Sub PopulateTheForm()
		txtProdId.Text = _obj.Prod_ID.ToString()
		txtDesc.Text = _obj.Prod_Desc
		cbInactive.Checked = _obj.Prod_Inactive
	End Sub
	Private Sub UpdateTheObject()
		_obj.Prod_Desc = txtDesc.Text
		_obj.Prod_Inactive = cbInactive.Checked
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
	Private Sub frmProdositionEdit_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		_obj = Nothing
	End Sub
End Class
