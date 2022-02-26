

Public Class frmDeviceActivity
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
	Friend WithEvents txtSN As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents dgOccurances As System.Windows.Forms.DataGrid
	Friend WithEvents dgActivity As System.Windows.Forms.DataGrid
	Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.txtSN = New System.Windows.Forms.TextBox()
		Me.dgOccurances = New System.Windows.Forms.DataGrid()
		Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
		Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.dgActivity = New System.Windows.Forms.DataGrid()
		Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
		Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
		CType(Me.dgOccurances, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgActivity, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'txtSN
		'
		Me.txtSN.BackColor = System.Drawing.Color.Yellow
		Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSN.Location = New System.Drawing.Point(152, 24)
		Me.txtSN.Name = "txtSN"
		Me.txtSN.Size = New System.Drawing.Size(264, 23)
		Me.txtSN.TabIndex = 1
		Me.txtSN.Text = ""
		'
		'dgOccurances
		'
		Me.dgOccurances.CaptionText = "Devices with this Serial Number"
		Me.dgOccurances.DataMember = ""
		Me.dgOccurances.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.dgOccurances.Location = New System.Drawing.Point(16, 64)
		Me.dgOccurances.Name = "dgOccurances"
		Me.dgOccurances.ReadOnly = True
		Me.dgOccurances.Size = New System.Drawing.Size(752, 136)
		Me.dgOccurances.TabIndex = 2
		Me.dgOccurances.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
		'
		'DataGridTableStyle2
		'
		Me.DataGridTableStyle2.DataGrid = Me.dgOccurances
		Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21})
		Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGridTableStyle2.MappingName = ""
		'
		'DataGridTextBoxColumn9
		'
		Me.DataGridTextBoxColumn9.Format = ""
		Me.DataGridTextBoxColumn9.FormatInfo = Nothing
		Me.DataGridTextBoxColumn9.HeaderText = "Device ID"
		Me.DataGridTextBoxColumn9.MappingName = "device_id"
		Me.DataGridTextBoxColumn9.Width = 75
		'
		'DataGridTextBoxColumn10
		'
		Me.DataGridTextBoxColumn10.Format = ""
		Me.DataGridTextBoxColumn10.FormatInfo = Nothing
		Me.DataGridTextBoxColumn10.HeaderText = "Serial Number"
		Me.DataGridTextBoxColumn10.MappingName = "device_sn"
		Me.DataGridTextBoxColumn10.Width = 75
		'
		'DataGridTextBoxColumn11
		'
		Me.DataGridTextBoxColumn11.Format = ""
		Me.DataGridTextBoxColumn11.FormatInfo = Nothing
		Me.DataGridTextBoxColumn11.HeaderText = "Model"
		Me.DataGridTextBoxColumn11.MappingName = "Model"
		Me.DataGridTextBoxColumn11.Width = 75
		'
		'DataGridTextBoxColumn12
		'
		Me.DataGridTextBoxColumn12.Format = ""
		Me.DataGridTextBoxColumn12.FormatInfo = Nothing
		Me.DataGridTextBoxColumn12.HeaderText = "Received"
		Me.DataGridTextBoxColumn12.MappingName = "Received"
		Me.DataGridTextBoxColumn12.Width = 75
		'
		'DataGridTextBoxColumn13
		'
		Me.DataGridTextBoxColumn13.Format = ""
		Me.DataGridTextBoxColumn13.FormatInfo = Nothing
		Me.DataGridTextBoxColumn13.HeaderText = "Billed"
		Me.DataGridTextBoxColumn13.MappingName = "Billed"
		Me.DataGridTextBoxColumn13.Width = 75
		'
		'DataGridTextBoxColumn14
		'
		Me.DataGridTextBoxColumn14.Format = ""
		Me.DataGridTextBoxColumn14.FormatInfo = Nothing
		Me.DataGridTextBoxColumn14.HeaderText = "Date Shipped"
		Me.DataGridTextBoxColumn14.MappingName = "device_dateship"
		Me.DataGridTextBoxColumn14.Width = 75
		'
		'DataGridTextBoxColumn15
		'
		Me.DataGridTextBoxColumn15.Format = ""
		Me.DataGridTextBoxColumn15.FormatInfo = Nothing
		Me.DataGridTextBoxColumn15.HeaderText = "Produced"
		Me.DataGridTextBoxColumn15.MappingName = "Produced"
		Me.DataGridTextBoxColumn15.Width = 75
		'
		'DataGridTextBoxColumn16
		'
		Me.DataGridTextBoxColumn16.Format = ""
		Me.DataGridTextBoxColumn16.FormatInfo = Nothing
		Me.DataGridTextBoxColumn16.HeaderText = "Invoiced"
		Me.DataGridTextBoxColumn16.MappingName = "Invoiced"
		Me.DataGridTextBoxColumn16.Width = 75
		'
		'DataGridTextBoxColumn17
		'
		Me.DataGridTextBoxColumn17.Format = ""
		Me.DataGridTextBoxColumn17.FormatInfo = Nothing
		Me.DataGridTextBoxColumn17.HeaderText = "Pallet"
		Me.DataGridTextBoxColumn17.MappingName = "pallet"
		Me.DataGridTextBoxColumn17.Width = 75
		'
		'DataGridTextBoxColumn18
		'
		Me.DataGridTextBoxColumn18.Format = ""
		Me.DataGridTextBoxColumn18.FormatInfo = Nothing
		Me.DataGridTextBoxColumn18.HeaderText = "Pallet Closed"
		Me.DataGridTextBoxColumn18.MappingName = "Pallet_Closed_Date"
		Me.DataGridTextBoxColumn18.Width = 75
		'
		'DataGridTextBoxColumn19
		'
		Me.DataGridTextBoxColumn19.Format = ""
		Me.DataGridTextBoxColumn19.FormatInfo = Nothing
		Me.DataGridTextBoxColumn19.HeaderText = "Customer"
		Me.DataGridTextBoxColumn19.MappingName = "Customer"
		Me.DataGridTextBoxColumn19.Width = 75
		'
		'DataGridTextBoxColumn20
		'
		Me.DataGridTextBoxColumn20.Format = ""
		Me.DataGridTextBoxColumn20.FormatInfo = Nothing
		Me.DataGridTextBoxColumn20.HeaderText = "WIP Owner"
		Me.DataGridTextBoxColumn20.MappingName = "wip_owner"
		Me.DataGridTextBoxColumn20.Width = 75
		'
		'DataGridTextBoxColumn21
		'
		Me.DataGridTextBoxColumn21.Format = ""
		Me.DataGridTextBoxColumn21.FormatInfo = Nothing
		Me.DataGridTextBoxColumn21.HeaderText = "Customer Work Order #"
		Me.DataGridTextBoxColumn21.MappingName = "cust_work_order"
		Me.DataGridTextBoxColumn21.Width = 75
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(16, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(128, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Device Serial Number:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'dgActivity
		'
		Me.dgActivity.CaptionText = "Activity for the selected device"
		Me.dgActivity.DataMember = ""
		Me.dgActivity.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.dgActivity.Location = New System.Drawing.Point(16, 208)
		Me.dgActivity.Name = "dgActivity"
		Me.dgActivity.ReadOnly = True
		Me.dgActivity.Size = New System.Drawing.Size(752, 240)
		Me.dgActivity.TabIndex = 3
		Me.dgActivity.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
		'
		'DataGridTableStyle1
		'
		Me.DataGridTableStyle1.DataGrid = Me.dgActivity
		Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
		Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGridTableStyle1.MappingName = ""
		'
		'DataGridTextBoxColumn1
		'
		Me.DataGridTextBoxColumn1.Format = ""
		Me.DataGridTextBoxColumn1.FormatInfo = Nothing
		Me.DataGridTextBoxColumn1.HeaderText = "ID"
		Me.DataGridTextBoxColumn1.MappingName = "dwsj_id"
		Me.DataGridTextBoxColumn1.Width = 75
		'
		'DataGridTextBoxColumn2
		'
		Me.DataGridTextBoxColumn2.Format = ""
		Me.DataGridTextBoxColumn2.FormatInfo = Nothing
		Me.DataGridTextBoxColumn2.HeaderText = "Device ID"
		Me.DataGridTextBoxColumn2.MappingName = "device_id"
		Me.DataGridTextBoxColumn2.Width = 75
		'
		'DataGridTextBoxColumn3
		'
		Me.DataGridTextBoxColumn3.Format = ""
		Me.DataGridTextBoxColumn3.FormatInfo = Nothing
		Me.DataGridTextBoxColumn3.HeaderText = "Workstation"
		Me.DataGridTextBoxColumn3.MappingName = "ws_na"
		Me.DataGridTextBoxColumn3.Width = 75
		'
		'DataGridTextBoxColumn4
		'
		Me.DataGridTextBoxColumn4.Format = ""
		Me.DataGridTextBoxColumn4.FormatInfo = Nothing
		Me.DataGridTextBoxColumn4.HeaderText = "Workstation Sub-Location"
		Me.DataGridTextBoxColumn4.MappingName = "wssl_na"
		Me.DataGridTextBoxColumn4.Width = 75
		'
		'DataGridTextBoxColumn5
		'
		Me.DataGridTextBoxColumn5.Format = ""
		Me.DataGridTextBoxColumn5.FormatInfo = Nothing
		Me.DataGridTextBoxColumn5.HeaderText = "User Name"
		Me.DataGridTextBoxColumn5.MappingName = "user_na"
		Me.DataGridTextBoxColumn5.Width = 75
		'
		'DataGridTextBoxColumn6
		'
		Me.DataGridTextBoxColumn6.Format = ""
		Me.DataGridTextBoxColumn6.FormatInfo = Nothing
		Me.DataGridTextBoxColumn6.HeaderText = "Computer"
		Me.DataGridTextBoxColumn6.MappingName = "cmp_na"
		Me.DataGridTextBoxColumn6.Width = 75
		'
		'DataGridTextBoxColumn7
		'
		Me.DataGridTextBoxColumn7.Format = ""
		Me.DataGridTextBoxColumn7.FormatInfo = Nothing
		Me.DataGridTextBoxColumn7.HeaderText = "Process Name"
		Me.DataGridTextBoxColumn7.MappingName = "prc_na"
		Me.DataGridTextBoxColumn7.Width = 75
		'
		'DataGridTextBoxColumn8
		'
		Me.DataGridTextBoxColumn8.Format = ""
		Me.DataGridTextBoxColumn8.FormatInfo = Nothing
		Me.DataGridTextBoxColumn8.HeaderText = "Date and Time"
		Me.DataGridTextBoxColumn8.MappingName = "crt_dt"
		Me.DataGridTextBoxColumn8.Width = 75
		'
		'frmDeviceActivity
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(784, 462)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgActivity, Me.Label1, Me.dgOccurances, Me.txtSN})
		Me.Name = "frmDeviceActivity"
		Me.Text = "Device Activity"
		CType(Me.dgOccurances, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgActivity, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region "FORM EVENTS"

	Private Sub frmDeviceActivity_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		txtSN.Focus()
	End Sub

#End Region
#Region "CONTROL EVENTS"

	Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
		If e.KeyCode = Keys.Enter Then
			Dim _dc As New Data.BOL.tDeviceCollectionBySN(txtSN.Text)
			dgOccurances.DataSource = _dc.deviceDataTable
			dgActivity.DataSource = Nothing
			If dgOccurances.BindingContext(dgOccurances.DataSource).Count > 0 Then
				dgOccurances.Select(0)
				dgOccurances_MouseUp(Nothing, Nothing)
			End If
		End If
	End Sub
	Private Sub dgOccurances_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgOccurances.MouseUp
		Dim _device_id As Integer
		_device_id = dgOccurances.Item(Me.dgOccurances.CurrentRowIndex, 0)
		Dim _dwjc As New Data.BOL.tdevice_workstation_journalCollection(_device_id)
		dgActivity.DataSource = _dwjc.tdevice_workstation_journalDataTable
	End Sub

#End Region

End Class
