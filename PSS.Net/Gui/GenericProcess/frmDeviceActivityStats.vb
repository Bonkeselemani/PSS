Public Class frmDeviceActivityStats
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
	Friend WithEvents dtpWorkDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents cboLOB As System.Windows.Forms.ComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
	Friend WithEvents btnSearch As System.Windows.Forms.Button
	Friend WithEvents ts1 As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid

	Friend WithEvents dgDetails As System.Windows.Forms.DataGrid
	Friend WithEvents ts2 As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.dtpWorkDate = New System.Windows.Forms.DateTimePicker()
		Me.cboLOB = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.DataGrid1 = New System.Windows.Forms.DataGrid()
		Me.ts1 = New System.Windows.Forms.DataGridTableStyle()
		Me.DataGrid2 = New System.Windows.Forms.DataGrid()
		Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.dgDetails = New System.Windows.Forms.DataGrid()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.ts2 = New System.Windows.Forms.DataGridTableStyle()
		Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'dtpWorkDate
		'
		Me.dtpWorkDate.Location = New System.Drawing.Point(440, 8)
		Me.dtpWorkDate.Name = "dtpWorkDate"
		Me.dtpWorkDate.TabIndex = 3
		'
		'cboLOB
		'
		Me.cboLOB.Location = New System.Drawing.Point(120, 8)
		Me.cboLOB.Name = "cboLOB"
		Me.cboLOB.Size = New System.Drawing.Size(192, 21)
		Me.cboLOB.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(8, 8)
		Me.Label1.Name = "Label1"
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Line of Business:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(344, 8)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(80, 23)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Date of work:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'DataGrid1
		'
		Me.DataGrid1.CaptionBackColor = System.Drawing.Color.CornflowerBlue
		Me.DataGrid1.CaptionText = "Total Counts"
		Me.DataGrid1.DataMember = ""
		Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid1.Location = New System.Drawing.Point(8, 40)
		Me.DataGrid1.Name = "DataGrid1"
		Me.DataGrid1.PreferredRowHeight = 25
		Me.DataGrid1.ReadOnly = True
		Me.DataGrid1.Size = New System.Drawing.Size(768, 224)
		Me.DataGrid1.TabIndex = 5
		Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.ts1})
		'
		'ts1
		'
		Me.ts1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(208, Byte), CType(223, Byte), CType(251, Byte))
		Me.ts1.DataGrid = Me.DataGrid1
		Me.ts1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
		Me.ts1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.ts1.MappingName = ""
		Me.ts1.PreferredRowHeight = 25
		'
		'DataGrid2
		'
		Me.DataGrid2.CaptionBackColor = System.Drawing.Color.CornflowerBlue
		Me.DataGrid2.CaptionText = "Details"
		Me.DataGrid2.DataMember = ""
		Me.DataGrid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid2.Location = New System.Drawing.Point(8, 272)
		Me.DataGrid2.Name = "DataGrid2"
		Me.DataGrid2.PreferredRowHeight = 25
		Me.DataGrid2.ReadOnly = True
		Me.DataGrid2.Size = New System.Drawing.Size(768, 184)
		Me.DataGrid2.TabIndex = 6
		Me.DataGrid2.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.ts1})
		'
		'DataGridTextBoxColumn1
		'
		Me.DataGridTextBoxColumn1.Format = ""
		Me.DataGridTextBoxColumn1.FormatInfo = Nothing
		Me.DataGridTextBoxColumn1.HeaderText = "Technician"
		Me.DataGridTextBoxColumn1.MappingName = "user_na"
		Me.DataGridTextBoxColumn1.Width = 125
		'
		'DataGridTextBoxColumn2
		'
		Me.DataGridTextBoxColumn2.Format = ""
		Me.DataGridTextBoxColumn2.FormatInfo = Nothing
		Me.DataGridTextBoxColumn2.HeaderText = "Process / Screen"
		Me.DataGridTextBoxColumn2.MappingName = "prc_na"
		Me.DataGridTextBoxColumn2.Width = 250
		'
		'DataGridTextBoxColumn3
		'
		Me.DataGridTextBoxColumn3.Format = ""
		Me.DataGridTextBoxColumn3.FormatInfo = Nothing
		Me.DataGridTextBoxColumn3.HeaderText = "Workstation"
		Me.DataGridTextBoxColumn3.MappingName = "ws_na"
		Me.DataGridTextBoxColumn3.Width = 200
		'
		'DataGridTextBoxColumn4
		'
		Me.DataGridTextBoxColumn4.Format = ""
		Me.DataGridTextBoxColumn4.FormatInfo = Nothing
		Me.DataGridTextBoxColumn4.HeaderText = "Count"
		Me.DataGridTextBoxColumn4.MappingName = "cnt"
		Me.DataGridTextBoxColumn4.Width = 75
		'
		'dgDetails
		'
		Me.dgDetails.CaptionBackColor = System.Drawing.Color.CornflowerBlue
		Me.dgDetails.CaptionText = "Details"
		Me.dgDetails.DataMember = ""
		Me.dgDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.dgDetails.Location = New System.Drawing.Point(8, 272)
		Me.dgDetails.Name = "dgDetails"
		Me.dgDetails.PreferredRowHeight = 25
		Me.dgDetails.ReadOnly = True
		Me.dgDetails.Size = New System.Drawing.Size(768, 184)
		Me.dgDetails.TabIndex = 6
		Me.dgDetails.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.ts2})
		'
		'btnSearch
		'
		Me.btnSearch.Location = New System.Drawing.Point(664, 8)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(112, 23)
		Me.btnSearch.TabIndex = 4
		Me.btnSearch.Text = "Search"
		'
		'ts2
		'
		Me.ts2.DataGrid = Me.dgDetails
		Me.ts2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14})
		Me.ts2.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.ts2.MappingName = ""
		'
		'DataGridTextBoxColumn5
		'
		Me.DataGridTextBoxColumn5.Format = ""
		Me.DataGridTextBoxColumn5.FormatInfo = Nothing
		Me.DataGridTextBoxColumn5.HeaderText = "Journal ID"
		Me.DataGridTextBoxColumn5.MappingName = "dwsj_id"
		Me.DataGridTextBoxColumn5.Width = 0
		'
		'DataGridTextBoxColumn6
		'
		Me.DataGridTextBoxColumn6.Format = ""
		Me.DataGridTextBoxColumn6.FormatInfo = Nothing
		Me.DataGridTextBoxColumn6.HeaderText = "Device ID"
		Me.DataGridTextBoxColumn6.MappingName = "device_id"
		Me.DataGridTextBoxColumn6.Width = 0
		'
		'DataGridTextBoxColumn7
		'
		Me.DataGridTextBoxColumn7.Format = ""
		Me.DataGridTextBoxColumn7.FormatInfo = Nothing
		Me.DataGridTextBoxColumn7.HeaderText = "Serial Number"
		Me.DataGridTextBoxColumn7.MappingName = "device_sn"
		Me.DataGridTextBoxColumn7.Width = 115
		'
		'DataGridTextBoxColumn8
		'
		Me.DataGridTextBoxColumn8.Format = ""
		Me.DataGridTextBoxColumn8.FormatInfo = Nothing
		Me.DataGridTextBoxColumn8.HeaderText = "Product Type ID"
		Me.DataGridTextBoxColumn8.MappingName = "pt_id"
		Me.DataGridTextBoxColumn8.Width = 0
		'
		'DataGridTextBoxColumn9
		'
		Me.DataGridTextBoxColumn9.Format = ""
		Me.DataGridTextBoxColumn9.FormatInfo = Nothing
		Me.DataGridTextBoxColumn9.HeaderText = "Workstation"
		Me.DataGridTextBoxColumn9.MappingName = "ws_na"
		'
		'DataGridTextBoxColumn10
		'
		Me.DataGridTextBoxColumn10.Format = ""
		Me.DataGridTextBoxColumn10.FormatInfo = Nothing
		Me.DataGridTextBoxColumn10.HeaderText = "Workstation Sub Loc."
		Me.DataGridTextBoxColumn10.MappingName = "wssl_na"
		Me.DataGridTextBoxColumn10.Width = 75
		'
		'DataGridTextBoxColumn11
		'
		Me.DataGridTextBoxColumn11.Format = ""
		Me.DataGridTextBoxColumn11.FormatInfo = Nothing
		Me.DataGridTextBoxColumn11.HeaderText = "User"
		Me.DataGridTextBoxColumn11.MappingName = "user_na"
		Me.DataGridTextBoxColumn11.Width = 75
		'
		'DataGridTextBoxColumn12
		'
		Me.DataGridTextBoxColumn12.Format = ""
		Me.DataGridTextBoxColumn12.FormatInfo = Nothing
		Me.DataGridTextBoxColumn12.HeaderText = "Computer"
		Me.DataGridTextBoxColumn12.MappingName = "cmp_na"
		Me.DataGridTextBoxColumn12.Width = 75
		'
		'DataGridTextBoxColumn13
		'
		Me.DataGridTextBoxColumn13.Format = ""
		Me.DataGridTextBoxColumn13.FormatInfo = Nothing
		Me.DataGridTextBoxColumn13.HeaderText = "Process Name"
		Me.DataGridTextBoxColumn13.MappingName = "prc_na"
		Me.DataGridTextBoxColumn13.Width = 125
		'
		'DataGridTextBoxColumn14
		'
		Me.DataGridTextBoxColumn14.Format = ""
		Me.DataGridTextBoxColumn14.FormatInfo = Nothing
		Me.DataGridTextBoxColumn14.HeaderText = "Create Date"
		Me.DataGridTextBoxColumn14.MappingName = "crt_dt"
		Me.DataGridTextBoxColumn14.Width = 115
		'
		'DataGridTextBoxColumn15
		'
		Me.DataGridTextBoxColumn15.Format = ""
		Me.DataGridTextBoxColumn15.FormatInfo = Nothing
		Me.DataGridTextBoxColumn15.HeaderText = "Product Type"
		Me.DataGridTextBoxColumn15.MappingName = "prod_desc"
		'
		'DataGridTextBoxColumn16
		'
		Me.DataGridTextBoxColumn16.Format = ""
		Me.DataGridTextBoxColumn16.FormatInfo = Nothing
		Me.DataGridTextBoxColumn16.HeaderText = "Model"
		Me.DataGridTextBoxColumn16.MappingName = "model_desc"
		Me.DataGridTextBoxColumn16.Width = 115
		'
		'frmDeviceActivityStats
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(784, 462)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgDetails, Me.btnSearch, Me.DataGrid1, Me.Label2, Me.Label1, Me.cboLOB, Me.dtpWorkDate})
		Me.Name = "frmDeviceActivityStats"
		Me.Text = "Device Journal Statistics"
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgDetails, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region "DECLARATIONS"



#End Region

#Region "FORM EVENTS"

	Private Sub frmDeviceActivityStats_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		dtpWorkDate.Value = Date.Now()
		PopulateLOB()
		cboLOB.SelectedValue = 1
		cboLOB.Focus()
	End Sub

#End Region

#Region "CONTROL EVENTS"

#End Region

#Region "METHODS"

	Private Sub PopulateLOB()
		Dim _ptCol As New Data.BOL.lproducttypeCollection()
		Dim dt As New DataTable()
		dt = _ptCol.lproducttypeDataTable
		cboLOB.DisplayMember = "pt_na"
		cboLOB.ValueMember = "pt_id"
		cboLOB.DataSource = dt
	End Sub

	Private Sub Search()
		Dim _daCol As New Data.BOL.tdevice_activity_statsCollection(cboLOB.SelectedValue, dtpWorkDate.Value.ToString("yyyy-MM-dd"))
		Dim dt As New DataTable()
		Clear()
		dt = _daCol.tdevice_workstation_journalDataTable
		_daCol = Nothing
		DataGrid1.DataSource = dt
		'If DataGrid1.TableStyles Is Nothing Then
		'	DataGrid1.TableStyles.Add(ts1)
		'End If
	End Sub

	Private Sub Clear()
		DataGrid1.DataSource = Nothing
	End Sub

#End Region

	Private Sub cboLOB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLOB.SelectedIndexChanged
		DataGrid1.DataSource = Nothing
	End Sub

	Private Sub dtpWorkDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpWorkDate.ValueChanged
		DataGrid1.DataSource = Nothing
	End Sub

	Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
		Try
			Search()
		Catch ex As Exception
			MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
		Dim _dt As New DataTable()
		Dim _user_na As String = ""
		Dim _prc_na As String = ""
		Dim _ws_na As String = ""
		Try
			_user_na = DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 0)
			_prc_na = DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 1)
			_ws_na = DataGrid1.Item(Me.DataGrid1.CurrentRowIndex, 2)
			Dim _dwjc As New Data.BOL.tdevice_activity_stats_detailCollection(cboLOB.SelectedValue, dtpWorkDate.Value.ToString("yyyy-MM-dd"), _user_na, _prc_na, _ws_na)
			_dt = _dwjc.tdevice_workstation_journalDataTable
			_dwjc = Nothing
			dgDetails.DataSource = _dt
			If dgDetails.TableStyles Is Nothing Then
				dgDetails.TableStyles.Add(ts2)
			End If
		Catch
		End Try
	End Sub
End Class
