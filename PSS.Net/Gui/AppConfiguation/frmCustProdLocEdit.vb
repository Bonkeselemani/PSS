Imports PSS.Data
Public Class frmCustProdLocEdit
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
	Friend WithEvents txtCrtTs As System.Windows.Forms.TextBox
	Friend WithEvents txtCrtBy As System.Windows.Forms.TextBox
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents txtCplId As System.Windows.Forms.TextBox
	Friend WithEvents txtLocation As System.Windows.Forms.TextBox
	Friend WithEvents cboCust As System.Windows.Forms.ComboBox
	Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
	Friend WithEvents cbAllowBin As System.Windows.Forms.CheckBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtCplId = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtCrtTs = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtCrtBy = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.txtLocation = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.cboCust = New System.Windows.Forms.ComboBox()
		Me.cboProduct = New System.Windows.Forms.ComboBox()
		Me.cbAllowBin = New System.Windows.Forms.CheckBox()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(40, 96)
		Me.Label1.Name = "Label1"
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Customer:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(40, 128)
		Me.Label2.Name = "Label2"
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "Product:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
		Me.Label3.Location = New System.Drawing.Point(40, 8)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(432, 32)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Customer Product Location Edit Screen"
		'
		'txtCplId
		'
		Me.txtCplId.Location = New System.Drawing.Point(152, 64)
		Me.txtCplId.Name = "txtCplId"
		Me.txtCplId.ReadOnly = True
		Me.txtCplId.Size = New System.Drawing.Size(64, 20)
		Me.txtCplId.TabIndex = 2
		Me.txtCplId.Text = ""
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(40, 64)
		Me.Label4.Name = "Label4"
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "ID:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtCrtTs
		'
		Me.txtCrtTs.Location = New System.Drawing.Point(152, 192)
		Me.txtCrtTs.Name = "txtCrtTs"
		Me.txtCrtTs.ReadOnly = True
		Me.txtCrtTs.Size = New System.Drawing.Size(208, 20)
		Me.txtCrtTs.TabIndex = 10
		Me.txtCrtTs.Text = ""
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(40, 192)
		Me.Label5.Name = "Label5"
		Me.Label5.TabIndex = 9
		Me.Label5.Text = "Created:"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtCrtBy
		'
		Me.txtCrtBy.Location = New System.Drawing.Point(152, 224)
		Me.txtCrtBy.Name = "txtCrtBy"
		Me.txtCrtBy.ReadOnly = True
		Me.txtCrtBy.Size = New System.Drawing.Size(208, 20)
		Me.txtCrtBy.TabIndex = 12
		Me.txtCrtBy.Text = ""
		'
		'Label6
		'
		Me.Label6.Location = New System.Drawing.Point(40, 224)
		Me.Label6.Name = "Label6"
		Me.Label6.TabIndex = 11
		Me.Label6.Text = "Created By:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnCancel
		'
		Me.btnCancel.Location = New System.Drawing.Point(232, 280)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(88, 32)
		Me.btnCancel.TabIndex = 14
		Me.btnCancel.Text = "Cancel"
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(360, 280)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(88, 32)
		Me.btnSave.TabIndex = 15
		Me.btnSave.Text = "Save"
		'
		'txtLocation
		'
		Me.txtLocation.Location = New System.Drawing.Point(152, 160)
		Me.txtLocation.Name = "txtLocation"
		Me.txtLocation.Size = New System.Drawing.Size(208, 20)
		Me.txtLocation.TabIndex = 8
		Me.txtLocation.Text = ""
		'
		'Label7
		'
		Me.Label7.Location = New System.Drawing.Point(40, 160)
		Me.Label7.Name = "Label7"
		Me.Label7.TabIndex = 7
		Me.Label7.Text = "Location:"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'cboCust
		'
		Me.cboCust.Location = New System.Drawing.Point(152, 96)
		Me.cboCust.Name = "cboCust"
		Me.cboCust.Size = New System.Drawing.Size(208, 21)
		Me.cboCust.TabIndex = 4
		'
		'cboProduct
		'
		Me.cboProduct.Location = New System.Drawing.Point(152, 128)
		Me.cboProduct.Name = "cboProduct"
		Me.cboProduct.Size = New System.Drawing.Size(208, 21)
		Me.cboProduct.TabIndex = 6
		'
		'cbAllowBin
		'
		Me.cbAllowBin.Location = New System.Drawing.Point(248, 64)
		Me.cbAllowBin.Name = "cbAllowBin"
		Me.cbAllowBin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
		Me.cbAllowBin.Size = New System.Drawing.Size(144, 16)
		Me.cbAllowBin.TabIndex = 13
		Me.cbAllowBin.Text = "Allow Bin Assignment"
		Me.cbAllowBin.TextAlign = System.Drawing.ContentAlignment.BottomLeft
		'
		'frmCustProdLocEdit
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(498, 344)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbAllowBin, Me.cboProduct, Me.cboCust, Me.txtLocation, Me.Label7, Me.btnSave, Me.btnCancel, Me.txtCrtBy, Me.Label6, Me.txtCrtTs, Me.Label5, Me.txtCplId, Me.Label4, Me.Label3, Me.Label2, Me.Label1})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Name = "frmCustProdLocEdit"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Customer Product Location Edit Screen"
		Me.ResumeLayout(False)

	End Sub

#End Region
#Region "DECLARATIONS"
	Private _obj As BOL.tcustomer_prod_locations
#End Region
#Region "CONSTRUCTORS"
	Public Sub New(ByVal id As Integer)
		MyBase.New()
		InitializeComponent()
		If id > 0 Then
			_obj = New BOL.tcustomer_prod_locations(id)
		Else
			_obj = New BOL.tcustomer_prod_locations()
		End If
	End Sub
#End Region
#Region "FORM EVENTS"
	Private Sub frmDispositionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		PopulateCustomerCombo()
		PopulateProductCombo()
		PopulateTheForm()
	End Sub
	Private Sub frmDispositionEdit_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		_obj = Nothing
	End Sub
#End Region
#Region "CONTROL EVENTS"
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
#End Region
#Region "METHODS"
	Private Sub PopulateTheForm()
		txtCplId.Text = _obj.cpl_id
		cboCust.SelectedValue = _obj.cust_id
		cboProduct.SelectedValue = _obj.prod_id
		txtLocation.Text = _obj.loc_na
		txtCrtTs.Text = _obj.crt_ts.ToString()
		txtCrtBy.Text = _obj.crt_user_id.ToString()
		cbAllowBin.Checked = _obj.allow_bin
	End Sub
	Private Sub UpdateTheObject()
		_obj.allow_bin = cbAllowBin.Checked
		_obj.loc_na = txtLocation.Text
		_obj.ApplyChanges()
		Me.Close()
	End Sub
	Private Sub SaveRecord()
		UpdateTheObject()
		_obj.ApplyChanges()
	End Sub
	Private Sub PopulateCustomerCombo()
		' POPULATES THE CUSTOMER COMBO BOX.
		Dim _dt As New DataTable()
		Dim _nr As DataRow
		Dim _col As New Data.BOL.tcustomerCollection()
		_dt = _col.tcustomerDataTable.Copy
		_nr = _dt.NewRow()
		_nr(0) = 0
		_nr(1) = "-- Select --"
		_dt.Rows.InsertAt(_nr, 0)
		_dt.AcceptChanges()
		cboCust.DataSource = _dt
		cboCust.ValueMember = "Cust_ID"
		cboCust.DisplayMember = "Cust_Name1"
		cboCust.Refresh()
		_col = Nothing
	End Sub
	Private Sub PopulateProductCombo()
		' POPULATES THE CUSTOMER COMBO BOX.
		Dim _dt As New DataTable()
		Dim _nr As DataRow
		Dim _col As New Data.BOL.lproductCollection()
		_dt = _col.lproductDataTable.Copy
		_nr = _dt.NewRow()
		_nr(0) = 0
		_nr(1) = "-- Select --"
		_dt.Rows.InsertAt(_nr, 0)
		_dt.AcceptChanges()
		cboProduct.DataSource = _dt
		cboProduct.ValueMember = "Prod_ID"
		cboProduct.DisplayMember = "Prod_Desc"
		cboProduct.Refresh()
		_col = Nothing
	End Sub
#End Region
End Class
