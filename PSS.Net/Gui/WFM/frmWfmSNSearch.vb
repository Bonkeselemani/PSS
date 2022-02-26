
Namespace Gui.WFMTracfone

	Public Class frmWfmSNSearch
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
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents txtSN As System.Windows.Forms.TextBox
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents ts1 As System.Windows.Forms.DataGridTableStyle
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents txtBox As System.Windows.Forms.TextBox
		Friend WithEvents lblRecordCount As System.Windows.Forms.Label
		Friend WithEvents init_date_rec As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents init_pallet As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents init_carton As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents init_sku As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents device_id As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents sn As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents device_datarec As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents model_desc As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents box_na As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents quantity As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents bin_na As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents workstation As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents workstationsentrydt As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents device_dateship As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents box_loc_na As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents TriageBy As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents TrgCrtDt As System.Windows.Forms.DataGridTextBoxColumn
		Friend WithEvents disp_cd As System.Windows.Forms.DataGridTextBoxColumn
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.txtSN = New System.Windows.Forms.TextBox()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.DataGrid1 = New System.Windows.Forms.DataGrid()
			Me.ts1 = New System.Windows.Forms.DataGridTableStyle()
			Me.init_date_rec = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.init_pallet = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.init_carton = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.init_sku = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.device_id = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.sn = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.device_datarec = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.model_desc = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.box_na = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.box_loc_na = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.quantity = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.bin_na = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.workstation = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.workstationsentrydt = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.device_dateship = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.txtBox = New System.Windows.Forms.TextBox()
			Me.lblRecordCount = New System.Windows.Forms.Label()
			Me.disp_cd = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.TriageBy = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.TrgCrtDt = New System.Windows.Forms.DataGridTextBoxColumn()
			CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'Label2
			'
			Me.Label2.Location = New System.Drawing.Point(16, 16)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(184, 23)
			Me.Label2.TabIndex = 9
			Me.Label2.Text = "Serial Number"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'txtSN
			'
			Me.txtSN.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtSN.Location = New System.Drawing.Point(16, 40)
			Me.txtSN.Name = "txtSN"
			Me.txtSN.Size = New System.Drawing.Size(184, 23)
			Me.txtSN.TabIndex = 8
			Me.txtSN.Text = ""
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(24, 320)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(416, 24)
			Me.lblMsg.TabIndex = 10
			Me.lblMsg.Text = "Message to the user goes here."
			'
			'DataGrid1
			'
			Me.DataGrid1.CaptionText = "Instances of this device"
			Me.DataGrid1.DataMember = ""
			Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.DataGrid1.Location = New System.Drawing.Point(16, 80)
			Me.DataGrid1.Name = "DataGrid1"
			Me.DataGrid1.ReadOnly = True
			Me.DataGrid1.Size = New System.Drawing.Size(736, 224)
			Me.DataGrid1.TabIndex = 11
			Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.ts1})
			'
			'ts1
			'
			Me.ts1.DataGrid = Me.DataGrid1
			Me.ts1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.init_date_rec, Me.init_pallet, Me.init_carton, Me.init_sku, Me.device_id, Me.sn, Me.device_datarec, Me.model_desc, Me.box_na, Me.box_loc_na, Me.quantity, Me.TriageBy, Me.TrgCrtDt, Me.workstation, Me.disp_cd, Me.workstationsentrydt, Me.bin_na, Me.device_dateship})
			Me.ts1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.ts1.MappingName = ""
			'
			'init_date_rec
			'
			Me.init_date_rec.Format = ""
			Me.init_date_rec.FormatInfo = Nothing
			Me.init_date_rec.HeaderText = "Initial Date Received"
			Me.init_date_rec.MappingName = "init_date_rec"
			Me.init_date_rec.Width = 75
			'
			'init_pallet
			'
			Me.init_pallet.Format = ""
			Me.init_pallet.FormatInfo = Nothing
			Me.init_pallet.HeaderText = "Initial Pallet"
			Me.init_pallet.MappingName = "init_pallet"
			Me.init_pallet.Width = 75
			'
			'init_carton
			'
			Me.init_carton.Format = ""
			Me.init_carton.FormatInfo = Nothing
			Me.init_carton.HeaderText = "Initial Carton"
			Me.init_carton.MappingName = "init_carton"
			Me.init_carton.Width = 75
			'
			'init_sku
			'
			Me.init_sku.Format = ""
			Me.init_sku.FormatInfo = Nothing
			Me.init_sku.HeaderText = "Initial Sku"
			Me.init_sku.MappingName = "init_sku"
			Me.init_sku.Width = 75
			'
			'device_id
			'
			Me.device_id.Format = ""
			Me.device_id.FormatInfo = Nothing
			Me.device_id.HeaderText = "Device ID"
			Me.device_id.MappingName = "device_id"
			Me.device_id.Width = 75
			'
			'sn
			'
			Me.sn.Format = ""
			Me.sn.FormatInfo = Nothing
			Me.sn.HeaderText = "Serial Number"
			Me.sn.MappingName = "sn"
			Me.sn.Width = 75
			'
			'device_datarec
			'
			Me.device_datarec.Format = ""
			Me.device_datarec.FormatInfo = Nothing
			Me.device_datarec.HeaderText = "Date Received"
			Me.device_datarec.MappingName = "device_daterec"
			Me.device_datarec.Width = 75
			'
			'model_desc
			'
			Me.model_desc.Format = ""
			Me.model_desc.FormatInfo = Nothing
			Me.model_desc.HeaderText = "Model"
			Me.model_desc.MappingName = "model_desc"
			Me.model_desc.Width = 75
			'
			'box_na
			'
			Me.box_na.Format = ""
			Me.box_na.FormatInfo = Nothing
			Me.box_na.HeaderText = "Box"
			Me.box_na.MappingName = "box_na"
			Me.box_na.Width = 75
			'
			'box_loc_na
			'
			Me.box_loc_na.Format = ""
			Me.box_loc_na.FormatInfo = Nothing
			Me.box_loc_na.HeaderText = "Box Loc."
			Me.box_loc_na.MappingName = "box_loc_na"
			Me.box_loc_na.Width = 75
			'
			'quantity
			'
			Me.quantity.Format = ""
			Me.quantity.FormatInfo = Nothing
			Me.quantity.HeaderText = "Qty"
			Me.quantity.MappingName = "quantity"
			Me.quantity.Width = 45
			'
			'bin_na
			'
			Me.bin_na.Format = ""
			Me.bin_na.FormatInfo = Nothing
			Me.bin_na.HeaderText = "Bin"
			Me.bin_na.MappingName = "bin_na"
			Me.bin_na.Width = 55
			'
			'workstation
			'
			Me.workstation.Format = ""
			Me.workstation.FormatInfo = Nothing
			Me.workstation.HeaderText = "Workstation"
			Me.workstation.MappingName = "workstation"
			Me.workstation.Width = 75
			'
			'workstationsentrydt
			'
			Me.workstationsentrydt.Format = ""
			Me.workstationsentrydt.FormatInfo = Nothing
			Me.workstationsentrydt.HeaderText = "WS Entry Date"
			Me.workstationsentrydt.MappingName = "workstationentrydt"
			Me.workstationsentrydt.Width = 75
			'
			'device_dateship
			'
			Me.device_dateship.Format = ""
			Me.device_dateship.FormatInfo = Nothing
			Me.device_dateship.HeaderText = "Date Shipped"
			Me.device_dateship.MappingName = "device_dateship"
			Me.device_dateship.Width = 75
			'
			'btnClear
			'
			Me.btnClear.Location = New System.Drawing.Point(672, 40)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.TabIndex = 12
			Me.btnClear.Text = "Clear"
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(24, 360)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(728, 23)
			Me.Label1.TabIndex = 13
			Me.Label1.Text = "This screen is used to search for a device by serial number, box or both.  If the" & _
			" device has been received more than once a line will be displayed for each time " & _
			"it was received."
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label3
			'
			Me.Label3.Location = New System.Drawing.Point(200, 16)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(192, 23)
			Me.Label3.TabIndex = 15
			Me.Label3.Text = "Box"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'txtBox
			'
			Me.txtBox.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtBox.Location = New System.Drawing.Point(200, 40)
			Me.txtBox.Name = "txtBox"
			Me.txtBox.Size = New System.Drawing.Size(192, 23)
			Me.txtBox.TabIndex = 14
			Me.txtBox.Text = ""
			'
			'lblRecordCount
			'
			Me.lblRecordCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblRecordCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblRecordCount.Location = New System.Drawing.Point(504, 312)
			Me.lblRecordCount.Name = "lblRecordCount"
			Me.lblRecordCount.Size = New System.Drawing.Size(240, 23)
			Me.lblRecordCount.TabIndex = 16
			Me.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'disp_cd
			'
			Me.disp_cd.Format = ""
			Me.disp_cd.FormatInfo = Nothing
			Me.disp_cd.HeaderText = "Disposition"
			Me.disp_cd.MappingName = "disp_cd"
			Me.disp_cd.Width = 75
			'
			'TriageBy
			'
			Me.TriageBy.Format = ""
			Me.TriageBy.FormatInfo = Nothing
			Me.TriageBy.HeaderText = "Triaged By"
			Me.TriageBy.MappingName = "TriageBy"
			Me.TriageBy.Width = 75
			'
			'TrgCrtDt
			'
			Me.TrgCrtDt.Format = ""
			Me.TrgCrtDt.FormatInfo = Nothing
			Me.TrgCrtDt.HeaderText = "Triage Date"
			Me.TrgCrtDt.MappingName = "TrgCrtDt"
			Me.TrgCrtDt.Width = 75
			'
			'frmWfmSNSearch
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(768, 398)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecordCount, Me.Label3, Me.txtBox, Me.Label1, Me.btnClear, Me.DataGrid1, Me.Label2, Me.txtSN, Me.lblMsg})
			Me.Name = "frmWfmSNSearch"
			Me.Text = "WFM Serial Number Search"
			CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

		Private Sub frmTmoBoxing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' PROCESSES TO DO UPON LOADING THE FORM.
			ClearMsg()
			ClearRecordCount()
		End Sub
		Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
			If txtSN.Text = "" AndAlso txtBox.Text = "" Then Exit Sub
			Dim _dt As New DataTable()
			If e.KeyCode = Keys.Enter Then
				Dim _d As New Data.BLL.WFMDevice()
				_dt = _d.GetDeviceInfo(txtSN.Text, txtBox.Text)
				lblRecordCount.Text = "Record Count: " & _dt.Rows.Count.ToString
				DataGrid1.DataSource = _dt
			End If
		End Sub
		Private Sub txtBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBox.KeyUp
			If txtSN.Text = "" AndAlso txtBox.Text = "" Then Exit Sub
			Dim _dt As New DataTable()
			If e.KeyCode = Keys.Enter Then
				DataGrid1.DataSource = Nothing
				Dim _d As New Data.BLL.WFMDevice()
				_dt = _d.GetDeviceInfo(txtSN.Text, txtBox.Text)
				lblRecordCount.Text = "Record Count: " & _dt.Rows.Count.ToString
				DataGrid1.DataSource = _dt
			End If
		End Sub
		Private Sub PostMsg(ByVal text As String)
			' POST A MESSAGE TO THE USER.
			lblMsg.Text = text
			Me.Refresh()
		End Sub
		Private Sub ClearMsg()
			' CLEARS MESSAGES POSTED TO THE USER.
			lblMsg.Text = ""
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			Dim _msg As String = "Clear all search criteria?"
			If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				txtSN.Text = ""
				txtBox.Text = ""
				DataGrid1.DataSource = Nothing
				ClearRecordCount()
			End If
		End Sub
		Private Sub ClearRecordCount()
			lblRecordCount.Text = "Record Count: 0"
		End Sub

	End Class

End Namespace