Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataGrid


Public Class frmOpenLineQueue
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
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents dgOpenLineQueue As System.Windows.Forms.DataGrid
	Friend WithEvents btnRefresh As System.Windows.Forms.Button
	Friend WithEvents dgSNRecords As System.Windows.Forms.DataGrid
	Friend WithEvents btnStartOver As System.Windows.Forms.Button
	Friend WithEvents btnUpdateExisting As System.Windows.Forms.Button
	Friend WithEvents btnRemoveOLs As System.Windows.Forms.Button
	Friend WithEvents pnlEditButtons As System.Windows.Forms.Panel
	Friend WithEvents lblQueueRowCount As System.Windows.Forms.Label
	Friend WithEvents txtSN As System.Windows.Forms.TextBox
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents btnRemove As System.Windows.Forms.Button
	Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOpenLineQueue))
		Me.dgOpenLineQueue = New System.Windows.Forms.DataGrid()
		Me.lblQueueRowCount = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.btnRefresh = New System.Windows.Forms.Button()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.dgSNRecords = New System.Windows.Forms.DataGrid()
		Me.pnlEditButtons = New System.Windows.Forms.Panel()
		Me.btnStartOver = New System.Windows.Forms.Button()
		Me.btnUpdateExisting = New System.Windows.Forms.Button()
		Me.btnRemoveOLs = New System.Windows.Forms.Button()
		Me.btnRemove = New System.Windows.Forms.Button()
		Me.txtSN = New System.Windows.Forms.TextBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
		Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
		CType(Me.dgOpenLineQueue, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgSNRecords, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlEditButtons.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.SuspendLayout()
		'
		'dgOpenLineQueue
		'
		Me.dgOpenLineQueue.AllowNavigation = False
		Me.dgOpenLineQueue.AlternatingBackColor = System.Drawing.Color.PowderBlue
		Me.dgOpenLineQueue.DataMember = ""
		Me.dgOpenLineQueue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgOpenLineQueue.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgOpenLineQueue.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.dgOpenLineQueue.Location = New System.Drawing.Point(8, 40)
		Me.dgOpenLineQueue.Name = "dgOpenLineQueue"
		Me.dgOpenLineQueue.PreferredColumnWidth = 125
		Me.dgOpenLineQueue.ReadOnly = True
		Me.dgOpenLineQueue.Size = New System.Drawing.Size(264, 232)
		Me.dgOpenLineQueue.TabIndex = 2
		Me.dgOpenLineQueue.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
		'
		'lblQueueRowCount
		'
		Me.lblQueueRowCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblQueueRowCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblQueueRowCount.ForeColor = System.Drawing.Color.Blue
		Me.lblQueueRowCount.Location = New System.Drawing.Point(128, 16)
		Me.lblQueueRowCount.Name = "lblQueueRowCount"
		Me.lblQueueRowCount.Size = New System.Drawing.Size(72, 48)
		Me.lblQueueRowCount.TabIndex = 4
		Me.lblQueueRowCount.Text = "0"
		Me.lblQueueRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Blue
		Me.Label6.Location = New System.Drawing.Point(16, 16)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(96, 56)
		Me.Label6.TabIndex = 0
		Me.Label6.Text = "Records In Queue:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnRefresh
		'
		Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Bitmap)
		Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnRefresh.Location = New System.Drawing.Point(216, 16)
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(48, 48)
		Me.btnRefresh.TabIndex = 2
		Me.btnRefresh.Text = "Refresh List"
		Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(8, 8)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(840, 16)
		Me.Label7.TabIndex = 0
		Me.Label7.Text = "Enter a Serial Number or Click a row from the list on the left to allocate how it" & _
		" should be processed."
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'dgSNRecords
		'
		Me.dgSNRecords.AllowNavigation = False
		Me.dgSNRecords.AlternatingBackColor = System.Drawing.Color.PowderBlue
		Me.dgSNRecords.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.dgSNRecords.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
		Me.dgSNRecords.CaptionText = "Existing Activity Records for the Device"
		Me.dgSNRecords.DataMember = ""
		Me.dgSNRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgSNRecords.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dgSNRecords.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.dgSNRecords.Location = New System.Drawing.Point(288, 40)
		Me.dgSNRecords.Name = "dgSNRecords"
		Me.dgSNRecords.PreferredColumnWidth = 125
		Me.dgSNRecords.ReadOnly = True
		Me.dgSNRecords.Size = New System.Drawing.Size(560, 264)
		Me.dgSNRecords.TabIndex = 3
		'
		'pnlEditButtons
		'
		Me.pnlEditButtons.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnStartOver, Me.btnUpdateExisting, Me.btnRemoveOLs})
		Me.pnlEditButtons.Location = New System.Drawing.Point(288, 8)
		Me.pnlEditButtons.Name = "pnlEditButtons"
		Me.pnlEditButtons.Size = New System.Drawing.Size(568, 64)
		Me.pnlEditButtons.TabIndex = 3
		'
		'btnStartOver
		'
		Me.btnStartOver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnStartOver.Image = CType(resources.GetObject("btnStartOver.Image"), System.Drawing.Bitmap)
		Me.btnStartOver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnStartOver.Location = New System.Drawing.Point(384, 8)
		Me.btnStartOver.Name = "btnStartOver"
		Me.btnStartOver.Size = New System.Drawing.Size(176, 48)
		Me.btnStartOver.TabIndex = 3
		Me.btnStartOver.Text = "Start Over"
		'
		'btnUpdateExisting
		'
		Me.btnUpdateExisting.BackColor = System.Drawing.Color.FromArgb(CType(188, Byte), CType(209, Byte), CType(248, Byte))
		Me.btnUpdateExisting.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnUpdateExisting.Location = New System.Drawing.Point(200, 8)
		Me.btnUpdateExisting.Name = "btnUpdateExisting"
		Me.btnUpdateExisting.Size = New System.Drawing.Size(176, 48)
		Me.btnUpdateExisting.TabIndex = 1
		Me.btnUpdateExisting.Text = "Update Existing Record's  Receipt Date"
		'
		'btnRemoveOLs
		'
		Me.btnRemoveOLs.BackColor = System.Drawing.Color.FromArgb(CType(124, Byte), CType(235, Byte), CType(213, Byte))
		Me.btnRemoveOLs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRemoveOLs.Location = New System.Drawing.Point(8, 8)
		Me.btnRemoveOLs.Name = "btnRemoveOLs"
		Me.btnRemoveOLs.Size = New System.Drawing.Size(182, 48)
		Me.btnRemoveOLs.TabIndex = 0
		Me.btnRemoveOLs.Text = "Remove Open Lines"
		'
		'btnRemove
		'
		Me.btnRemove.BackColor = System.Drawing.SystemColors.Control
		Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRemove.Location = New System.Drawing.Point(8, 280)
		Me.btnRemove.Name = "btnRemove"
		Me.btnRemove.Size = New System.Drawing.Size(264, 24)
		Me.btnRemove.TabIndex = 2
		Me.btnRemove.Text = "Remove Device From Queue"
		'
		'txtSN
		'
		Me.txtSN.BackColor = System.Drawing.Color.Yellow
		Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSN.Location = New System.Drawing.Point(8, 40)
		Me.txtSN.Name = "txtSN"
		Me.txtSN.Size = New System.Drawing.Size(264, 23)
		Me.txtSN.TabIndex = 1
		Me.txtSN.Text = ""
		'
		'Panel1
		'
		Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnRefresh, Me.lblQueueRowCount, Me.pnlEditButtons, Me.Label6})
		Me.Panel1.Location = New System.Drawing.Point(0, 328)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(880, 104)
		Me.Panel1.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(0, 80)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(872, 16)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "   This screen is used to correct issues related to devices that cannot be receiv" & _
		"ed due to Open Line(s)."
		'
		'Panel2
		'
		Me.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSN, Me.Label7, Me.dgOpenLineQueue, Me.dgSNRecords, Me.btnRemove})
		Me.Panel2.Location = New System.Drawing.Point(0, 8)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(864, 312)
		Me.Panel2.TabIndex = 0
		'
		'DataGridTableStyle1
		'
		Me.DataGridTableStyle1.DataGrid = Me.dgOpenLineQueue
		Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2})
		Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGridTableStyle1.MappingName = ""
		'
		'DataGridTextBoxColumn1
		'
		Me.DataGridTextBoxColumn1.Format = ""
		Me.DataGridTextBoxColumn1.FormatInfo = Nothing
		Me.DataGridTextBoxColumn1.HeaderText = "Serial Number"
		Me.DataGridTextBoxColumn1.MappingName = "device_sn"
		Me.DataGridTextBoxColumn1.Width = 125
		'
		'DataGridTextBoxColumn2
		'
		Me.DataGridTextBoxColumn2.Format = ""
		Me.DataGridTextBoxColumn2.FormatInfo = Nothing
		Me.DataGridTextBoxColumn2.HeaderText = "Date Added"
		Me.DataGridTextBoxColumn2.MappingName = "crt_dt"
		Me.DataGridTextBoxColumn2.Width = 125
		'
		'frmOpenLineQueue
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(872, 438)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Panel1})
		Me.MinimumSize = New System.Drawing.Size(880, 472)
		Me.Name = "frmOpenLineQueue"
		Me.Text = "Messaging Open Line Queue"
		CType(Me.dgOpenLineQueue, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgSNRecords, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlEditButtons.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region "DELCARATIONS"

	Dim _obj As New PSS.Data.Buisness.MsgOpenLinesQueueCollection()
	Dim _sn As String = ""

#End Region
#Region "CONSTRUCTORS"

#End Region
#Region "FORM EVENTS"

	Private Sub frmOpenLineQueue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		PopulateOpenLinesGrid()
		EnableControls()
		'Me.SuspendLayout()
		''Me.ParentForm.WindowState = FormWindowState.Minimized
		''Me.ParentForm.WindowState = FormWindowState.Maximized
		'Me.WindowState = FormWindowState.Minimized
		'Me.WindowState = FormWindowState.Maximized
		'Me.ResumeLayout(True)
	End Sub

#End Region
#Region "CONTROL EVENTS"

	Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
		ClearSN()
		PopulateOpenLinesGrid()
	End Sub
	Private Sub btnRemoveOLs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOLs.Click
		Dim _dlg As New DialogResult()
		_dlg = MessageBox.Show("Would you like to remove all open lines for this device?", _
		 Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		If _dlg = DialogResult.Yes Then
			RemoveOpenLines(_sn)
			ClearSN()
			PopulateOpenLinesGrid()
			MessageBox.Show("This device can now be received." & vbCrLf & vbCrLf & "Please place the device into the Receiving Box.", _
			 Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub
	Private Sub btnUpdateExisting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateExisting.Click
		Dim _dlg As New DialogResult()
		_dlg = MessageBox.Show("Would you like to update receipt date of the open line record for this device? " & vbCrLf & vbCrLf & _
		 "Please note if there are more than one open lines for this device only one will be updated and the others will be removed.", _
		 Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		If _dlg = DialogResult.Yes Then
			UpdateLastOpenLine(_sn)
			ClearSN()
			PopulateOpenLinesGrid()
		End If
	End Sub
	Private Sub btnStartOver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartOver.Click
		ClearSN()
	End Sub
	Private Sub dgOpenLineQueue_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgOpenLineQueue.MouseUp
		Try
			_sn = Me.dgOpenLineQueue.Item(Me.dgOpenLineQueue.CurrentRowIndex, 0)
			SelectSN(_sn)
		Catch
		End Try
	End Sub
	Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
		EnableControls()
		If txtSN.Text.Length = 0 Then Exit Sub
		If e.KeyCode = Keys.Enter Then
			If DoesSNExistInList(txtSN.Text) Then
				_sn = txtSN.Text
				PopulateDeviceRecGrid(_sn)
				EnableControls()
			Else
				MessageBox.Show("The entered Serial Number was not found in the list below.")
				txtSN.Text = ""
				_sn = ""
				ClearSN()
				EnableControls()
			End If
		End If
	End Sub
	Private Sub frmOpenLineQueue_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
		Me.ResumeLayout(True)
	End Sub
	Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
		Dim _dlg As New DialogResult()
		_dlg = MessageBox.Show("Would you like to remove this device from the Queue?", _
		   Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		If _dlg = DialogResult.Yes Then
			RemoveFromQueue(_sn)
			ClearSN()
			PopulateOpenLinesGrid()
		End If
	End Sub

#End Region
#Region "PROPERTIES"

	Public Property SerialNumber() As String
		Get
			Return _sn
		End Get
		Set(ByVal Value As String)
			_sn = Value
		End Set
	End Property

#End Region
#Region "METHODS"

	Private Sub PopulateOpenLinesGrid()
		_obj = New PSS.Data.Buisness.MsgOpenLinesQueueCollection()
		Dim _dt As New DataTable()
		_dt = _obj.MsgOpenLinesQueueDataTable
		dgOpenLineQueue.DataSource = _dt
		Me.lblQueueRowCount.Text = GetQueueRowCount()
	End Sub
	Private Sub PopulateDeviceRecGrid(ByVal SerialNumber As String)
		Dim _dt As New DataTable()
		_dt = New PSS.Data.BOL.tDeviceCollectionBySN(SerialNumber).deviceDataTable
		dgSNRecords.DataSource = _dt
	End Sub
	Private Sub EnableControls()
		Dim rowCount As Integer = 0
		rowCount = GetRowCount()
		pnlEditButtons.Enabled = IIf(rowCount = 0, False, True)
		' TODO: FINISH THIS.
		btnRemove.Enabled = (_sn.Length > 0)
	End Sub
	Private Sub SelectSN(ByVal sn As String)
		PopulateDeviceRecGrid(sn)
		EnableControls()
	End Sub
	Private Sub ClearSN()
		txtSN.Text = ""
		_sn = ""
		dgSNRecords.DataSource = Nothing
		EnableControls()
	End Sub
	Private Sub RemoveFromQueue(ByVal device_sn As String)
		Dim _olq As New Data.Buisness.MsgOpenLinesQueue(device_sn)
		_olq.Delete()
		_olq = Nothing
		EnableControls()
	End Sub
	Private Sub RemoveOpenLines(ByVal sn As String)
		If sn = "" Then Exit Sub
		Dim _deviceColl As New Data.BOL.tDeviceCollectionBySN(sn)
		Dim _billColl As Data.BOL.tDeviceBillCollection
		Dim _messdata As Data.BOL.tMessData
		Dim _olq As Data.Buisness.MsgOpenLinesQueue
		Dim dr As DataRow
		For Each dr In _deviceColl.deviceDataTable.Rows
			Dim _device_id As Integer = dr("device_id")
			If dr("device_dateship").ToString() = "" Then
				_billColl = New Data.BOL.tDeviceBillCollection(_device_id)
				_billColl.RemoveAllBillingForDeviceID(_device_id)
				_messdata = New Data.BOL.tMessData(_device_id)
				_messdata.Delete()
				Dim _device As New Data.BOL.tDevice(_device_id)
				_device.Delete()
				_billColl = Nothing
				_messdata = Nothing
			End If
		Next
		RemoveFromQueue(sn)
		EnableControls()
	End Sub
	Private Sub UpdateLastOpenLine(ByVal sn As String)
		If sn = "" Then Exit Sub
		Dim _deviceColl As New Data.BOL.tDeviceCollectionBySN(sn)
		Dim _billColl As Data.BOL.tDeviceBillCollection
		Dim _messdata As Data.BOL.tMessData
		Dim _olq As Data.Buisness.MsgOpenLinesQueue
		Dim dr As DataRow
		Dim _updated As Boolean = False
		For Each dr In _deviceColl.deviceDataTable.Rows
			Dim _device_id As Integer = dr("device_id")
			If dr("device_dateship").ToString() = "" Then
				If Not _updated Then
					Dim _device As New Data.BOL.tDevice(_device_id)
					_device.Device_DateRec = Format(Date.Now.Date(), "yyyy-MM-dd")
					_device.ApplyChanges()
					_messdata = New Data.BOL.tMessData(_device_id)
					_messdata.wipowner_id = 202
					_messdata.wipowner_EntryDt = Format(Date.Now.Date(), "yyyy-MM-dd")
					_messdata.ApplyChanges()
					_updated = True
				Else
					_billColl = New Data.BOL.tDeviceBillCollection(_device_id)
					_billColl.RemoveAllBillingForDeviceID(_device_id)
					_messdata = New Data.BOL.tMessData(_device_id)
					_messdata.Delete()
					Dim _device As New Data.BOL.tDevice(_device_id)
					_device.Delete()
				End If
			End If
			_billColl = Nothing
			_messdata = Nothing
		Next
		If Not _updated Then
			MessageBox.Show("*** ATTENTION ***" & vbCrLf & vbCrLf & _
			"This device had no open lines to update and should be able to be received.  Please place this device in the box to go to Receiving.", _
			Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			MessageBox.Show("Update complete and this device can now be sent to Pre-Eval." & vbCrLf & vbCrLf & "Please place the device into the box to go to Pre-Eval.", _
			 Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
		RemoveFromQueue(sn)
		EnableControls()
	End Sub
	Private Function GetQueueRowCount() As Integer
		Dim rowCount As Integer = 0
		Try
			rowCount = dgSNRecords.BindingContext(dgOpenLineQueue.DataSource).Count()
			Return rowCount
		Catch ex As Exception
			Return 0
		End Try
	End Function
	Private Function GetRowCount() As Integer
		Dim rowCount As Integer = 0
		Try
			rowCount = dgSNRecords.BindingContext(dgSNRecords.DataSource).Count()
			Return rowCount
		Catch ex As Exception
			Return 0
		End Try
	End Function
	Private Function DoesSNExistInList(ByVal device_sn As String)
		Dim _results As Boolean = False
		Dim _qRowCount As Integer = GetQueueRowCount()
		Dim i As Integer
		For i = 0 To _qRowCount - 1
			If device_sn = _obj.MsgOpenLinesQueueDataTable.Rows(i)("device_sn").ToString() Then
				_results = True
				Exit For
			End If
		Next
		Return _results
	End Function

#End Region

End Class
