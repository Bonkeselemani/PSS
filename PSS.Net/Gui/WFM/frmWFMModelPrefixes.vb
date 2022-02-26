Namespace Gui.WFMTracfone

	Public Class frmWFMModelPrefixes
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
		Friend WithEvents pnlHeader As System.Windows.Forms.Panel
		Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
		Friend WithEvents btnRemove As System.Windows.Forms.Button
		Friend WithEvents dgPrefixes As System.Windows.Forms.DataGrid
		Friend WithEvents cboModel As System.Windows.Forms.ComboBox
		Friend WithEvents pnlFooter As System.Windows.Forms.Panel
		Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
		Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents btnAdd As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.cboCustomer = New System.Windows.Forms.ComboBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.btnAdd = New System.Windows.Forms.Button()
			Me.btnRemove = New System.Windows.Forms.Button()
			Me.dgPrefixes = New System.Windows.Forms.DataGrid()
			Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
			Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.cboModel = New System.Windows.Forms.ComboBox()
			Me.pnlHeader = New System.Windows.Forms.Panel()
			Me.pnlFooter = New System.Windows.Forms.Panel()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.Label10 = New System.Windows.Forms.Label()
			CType(Me.dgPrefixes, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlHeader.SuspendLayout()
			Me.pnlFooter.SuspendLayout()
			Me.SuspendLayout()
			'
			'cboCustomer
			'
			Me.cboCustomer.DisplayMember = "cust_name1"
			Me.cboCustomer.Enabled = False
			Me.cboCustomer.Location = New System.Drawing.Point(128, 24)
			Me.cboCustomer.MaxDropDownItems = 20
			Me.cboCustomer.Name = "cboCustomer"
			Me.cboCustomer.Size = New System.Drawing.Size(272, 21)
			Me.cboCustomer.TabIndex = 0
			Me.cboCustomer.ValueMember = "cust_id"
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(16, 24)
			Me.Label1.Name = "Label1"
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Customer:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'btnAdd
			'
			Me.btnAdd.Location = New System.Drawing.Point(232, 208)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New System.Drawing.Size(176, 24)
			Me.btnAdd.TabIndex = 3
			Me.btnAdd.Text = "Add Prefix"
			'
			'btnRemove
			'
			Me.btnRemove.Location = New System.Drawing.Point(232, 264)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New System.Drawing.Size(176, 23)
			Me.btnRemove.TabIndex = 4
			Me.btnRemove.Text = "Remove Prefix"
			'
			'dgPrefixes
			'
			Me.dgPrefixes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.dgPrefixes.CaptionText = "Prefixes"
			Me.dgPrefixes.DataMember = ""
			Me.dgPrefixes.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgPrefixes.Location = New System.Drawing.Point(440, 88)
			Me.dgPrefixes.Name = "dgPrefixes"
			Me.dgPrefixes.ReadOnly = True
			Me.dgPrefixes.Size = New System.Drawing.Size(200, 344)
			Me.dgPrefixes.TabIndex = 5
			Me.dgPrefixes.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
			'
			'DataGridTableStyle1
			'
			Me.DataGridTableStyle1.DataGrid = Me.dgPrefixes
			Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3})
			Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.DataGridTableStyle1.MappingName = ""
			'
			'DataGridTextBoxColumn1
			'
			Me.DataGridTextBoxColumn1.Format = ""
			Me.DataGridTextBoxColumn1.FormatInfo = Nothing
			Me.DataGridTextBoxColumn1.MappingName = "mcp_id"
			Me.DataGridTextBoxColumn1.Width = 0
			'
			'DataGridTextBoxColumn2
			'
			Me.DataGridTextBoxColumn2.Format = ""
			Me.DataGridTextBoxColumn2.FormatInfo = Nothing
			Me.DataGridTextBoxColumn2.MappingName = "model_id"
			Me.DataGridTextBoxColumn2.Width = 0
			'
			'DataGridTextBoxColumn3
			'
			Me.DataGridTextBoxColumn3.Format = ""
			Me.DataGridTextBoxColumn3.FormatInfo = Nothing
			Me.DataGridTextBoxColumn3.HeaderText = "Prefix"
			Me.DataGridTextBoxColumn3.MappingName = "Prefix"
			Me.DataGridTextBoxColumn3.Width = 225
			'
			'Label2
			'
			Me.Label2.Location = New System.Drawing.Point(80, 88)
			Me.Label2.Name = "Label2"
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Model:"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'cboModel
			'
			Me.cboModel.Location = New System.Drawing.Point(200, 88)
			Me.cboModel.MaxLength = 15
			Me.cboModel.Name = "cboModel"
			Me.cboModel.Size = New System.Drawing.Size(208, 21)
			Me.cboModel.TabIndex = 6
			'
			'pnlHeader
			'
			Me.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.pnlHeader.BackColor = System.Drawing.Color.Silver
			Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.pnlHeader.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomer, Me.Label1})
			Me.pnlHeader.Location = New System.Drawing.Point(8, 8)
			Me.pnlHeader.Name = "pnlHeader"
			Me.pnlHeader.Size = New System.Drawing.Size(704, 64)
			Me.pnlHeader.TabIndex = 8
			'
			'pnlFooter
			'
			Me.pnlFooter.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
			Me.pnlFooter.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3})
			Me.pnlFooter.Location = New System.Drawing.Point(8, 440)
			Me.pnlFooter.Name = "pnlFooter"
			Me.pnlFooter.Size = New System.Drawing.Size(704, 40)
			Me.pnlFooter.TabIndex = 9
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.Location = New System.Drawing.Point(8, 8)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(688, 24)
			Me.Label3.TabIndex = 9
			Me.Label3.Text = "This screen is used to add valid prefixes for defined models that can be validate" & _
			"d in the receiving process.  This feature is not in use for all lines of busines" & _
			"s."
			'
			'Label10
			'
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label10.ForeColor = System.Drawing.Color.Blue
			Me.Label10.Location = New System.Drawing.Point(88, 136)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New System.Drawing.Size(320, 40)
			Me.Label10.TabIndex = 22
			Me.Label10.Text = "Please select a Model to configure valid prefix options."
			'
			'frmWFMModelPrefixes
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(720, 486)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.pnlFooter, Me.pnlHeader, Me.Label2, Me.cboModel, Me.dgPrefixes, Me.btnRemove, Me.btnAdd})
			Me.Name = "frmWFMModelPrefixes"
			Me.Text = "WFM Model Prefix Configurations"
			CType(Me.dgPrefixes, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlHeader.ResumeLayout(False)
			Me.pnlFooter.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"

		Private _cust_id As Integer = 0
		Private _model_id As Integer = 0
		Private _prefix As String = ""
		Private _loading As Boolean = True

#End Region
#Region "CONSTRUCTORS"

		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

#End Region
#Region "FORM EVENTS"

		Private Sub frmWFMModelPrefixes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			_cust_id = 2597
			Dim _hold_cust_id As Integer = _cust_id
			Try
				PopulateCustomerCombo()
				If _hold_cust_id > 0 Then
					cboCustomer.SelectedValue = _hold_cust_id
					_cust_id = _hold_cust_id
					PopulateModelCombo()
					EnableControls()
				End If
			Catch ex As Exception
				Throw New Exception("Unable to load the " & Me.Name & " form." & _
				 vbCrLf & vbCrLf & ex.Message)
			End Try
		End Sub

#End Region
#Region "CONTROL EVENTS"

		Private Sub cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
			_cust_id = cboCustomer.SelectedValue
			EnableControls()
		End Sub
		Private Sub cboModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectedIndexChanged
			_model_id = cboModel.SelectedValue
			PopulatePrefixData()
			EnableControls()
		End Sub
		Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
			Dim _msg As String = "Please enter the prefix you would like to add for this Model."
			Dim _prefix As String
			Try
				_prefix = InputBox(_msg, Me.Text)
				' ADD PREFIX.
				AddPrefix(_model_id, _prefix)
				MessageBox.Show(_prefix & " has been added as a valid prefix for Model " & cboModel.Text & ".")
				PopulatePrefixData()
				EnableControls()
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
		Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
			Dim _mcp_id As Integer
			Dim _msg As String = "Please enter the prefix you would like to remove from this Model."
			Dim _prefix As String
			_prefix = InputBox(_msg, Me.Text)
			_mcp_id = FindPrefixID(_prefix)
			If _mcp_id > 0 Then
				' REMOVE PREFIX.
				RemovePrefix(_mcp_id)
				MessageBox.Show(_prefix & " has been removed from Model " & cboModel.Text & ".")
				PopulatePrefixData()
				EnableControls()
			Else
				MessageBox.Show("The entered prefix was not found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Sub

#End Region
#Region "METHODS"

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
			cboCustomer.DataSource = _dt
			cboCustomer.ValueMember = "Cust_ID"
			cboCustomer.DisplayMember = "Cust_Name1"
			cboCustomer.Refresh()
			'_col = Nothing
		End Sub
		Private Sub PopulateModelCombo()
			'If (_cust_id < 1 OrElse _loading) Then
			'	Exit Sub
			'End If
			' POPULATES THE MODEL COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _mdl As New Data.BOL.tmodelCollection(_cust_id)
			cboModel.ValueMember = "model_id"
			cboModel.DisplayMember = "model_desc"
			_dt = _mdl.tmodelDataTable.Copy
			_nr = _dt.NewRow()
			_nr(0) = 0
			_nr(1) = "-- Select --"
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			cboModel.DataSource = _dt
			cboModel.Refresh()
			_mdl = Nothing
		End Sub
		Private Sub PopulatePrefixData()
			' POPULATES THE HIDDEN PREFIX LISTBOX.
			dgPrefixes.DataSource = Nothing
			Dim _msnp As New Data.BOL.tmodel_sn_prefixesCollection(cboModel.SelectedValue)
			dgPrefixes.DataMember = "msnp_id"
			dgPrefixes.DataSource = _msnp.tmodel_sn_prefixesDataTable.Copy
			_msnp = Nothing
		End Sub
		Private Sub EnableControls()
			btnAdd.Enabled = cboModel.SelectedValue > 0
			btnRemove.Enabled = cboModel.SelectedValue > 0
		End Sub
		Private Sub AddPrefix(ByVal model_id As Integer, ByVal prefix As String)
			Dim _prefix As New Data.BOL.tmodel_sn_prefixes()
			_prefix.model_id = model_id
			_prefix.prefix = prefix
			_prefix.ApplyChanges()
		End Sub
		Private Sub RemovePrefix(ByVal mcp_id As Integer)
			Dim _prefix As New Data.BOL.tmodel_sn_prefixes(mcp_id)
			_prefix.MarkDeleted()
			_prefix.ApplyChanges()
		End Sub
		Private Function FindPrefixID(ByVal prefix As String) As Integer
			Dim _retval As Integer = 0
			Dim row As DataRow
			For Each row In dgPrefixes.DataSource.Rows
				If row(2).ToString() = prefix Then
					_retval = row(0)
				End If
			Next
			Return _retval
		End Function

#End Region

	End Class

End Namespace