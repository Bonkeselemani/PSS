Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSIMOrderReports
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New(ByVal iCust_ID As Integer)
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
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents dtp_end_date As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtp_start_date As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents gbReportType As System.Windows.Forms.GroupBox
	Friend WithEvents rbRejected As System.Windows.Forms.RadioButton
	Friend WithEvents rbFilled As System.Windows.Forms.RadioButton
	Friend WithEvents rbOpen As System.Windows.Forms.RadioButton
	Friend WithEvents rbAll As System.Windows.Forms.RadioButton
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents btnPrint As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.dtp_end_date = New System.Windows.Forms.DateTimePicker()
		Me.dtp_start_date = New System.Windows.Forms.DateTimePicker()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.gbReportType = New System.Windows.Forms.GroupBox()
		Me.rbRejected = New System.Windows.Forms.RadioButton()
		Me.rbFilled = New System.Windows.Forms.RadioButton()
		Me.rbOpen = New System.Windows.Forms.RadioButton()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.rbAll = New System.Windows.Forms.RadioButton()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.gbReportType.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnPrint
		'
		Me.btnPrint.Location = New System.Drawing.Point(408, 304)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(88, 32)
		Me.btnPrint.TabIndex = 27
		Me.btnPrint.Text = "Print"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(32, 152)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(80, 23)
		Me.Label2.TabIndex = 26
		Me.Label2.Text = "Ending Date:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(32, 112)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(80, 23)
		Me.Label1.TabIndex = 25
		Me.Label1.Text = "Starting Date:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'dtp_end_date
		'
		Me.dtp_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short
		Me.dtp_end_date.Location = New System.Drawing.Point(128, 152)
		Me.dtp_end_date.Name = "dtp_end_date"
		Me.dtp_end_date.Size = New System.Drawing.Size(104, 20)
		Me.dtp_end_date.TabIndex = 24
		'
		'dtp_start_date
		'
		Me.dtp_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short
		Me.dtp_start_date.Location = New System.Drawing.Point(128, 112)
		Me.dtp_start_date.Name = "dtp_start_date"
		Me.dtp_start_date.Size = New System.Drawing.Size(104, 20)
		Me.dtp_start_date.TabIndex = 23
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.Blue
		Me.Label4.Location = New System.Drawing.Point(16, 16)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(512, 48)
		Me.Label4.TabIndex = 29
		Me.Label4.Text = "Please enter the date range to be used for the report.  All reports will be based" & _
		" on the date the Order was received except for the Filled Order report will base" & _
		"d on the Ship Date."
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'gbReportType
		'
		Me.gbReportType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbRejected, Me.rbFilled, Me.rbOpen, Me.Label6, Me.rbAll})
		Me.gbReportType.Location = New System.Drawing.Point(264, 104)
		Me.gbReportType.Name = "gbReportType"
		Me.gbReportType.Size = New System.Drawing.Size(232, 176)
		Me.gbReportType.TabIndex = 31
		Me.gbReportType.TabStop = False
		Me.gbReportType.Text = "Report Type"
		'
		'rbRejected
		'
		Me.rbRejected.Location = New System.Drawing.Point(24, 96)
		Me.rbRejected.Name = "rbRejected"
		Me.rbRejected.Size = New System.Drawing.Size(184, 24)
		Me.rbRejected.TabIndex = 33
		Me.rbRejected.Text = "Rejected Orders"
		'
		'rbFilled
		'
		Me.rbFilled.Location = New System.Drawing.Point(24, 128)
		Me.rbFilled.Name = "rbFilled"
		Me.rbFilled.Size = New System.Drawing.Size(184, 24)
		Me.rbFilled.TabIndex = 32
		Me.rbFilled.Text = "Filled Orders (By Ship Date)"
		'
		'rbOpen
		'
		Me.rbOpen.Location = New System.Drawing.Point(24, 64)
		Me.rbOpen.Name = "rbOpen"
		Me.rbOpen.Size = New System.Drawing.Size(184, 24)
		Me.rbOpen.TabIndex = 31
		Me.rbOpen.Text = "Open Orders"
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Blue
		Me.Label6.Location = New System.Drawing.Point(112, -54)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(224, 43)
		Me.Label6.TabIndex = 29
		Me.Label6.Text = "Please enter the date range of orders received to be viewed."
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbAll
		'
		Me.rbAll.Checked = True
		Me.rbAll.Location = New System.Drawing.Point(24, 32)
		Me.rbAll.Name = "rbAll"
		Me.rbAll.Size = New System.Drawing.Size(184, 24)
		Me.rbAll.TabIndex = 0
		Me.rbAll.TabStop = True
		Me.rbAll.Text = "All Received"
		'
		'frmSIMOrderReports
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(544, 358)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbReportType, Me.Label4, Me.btnPrint, Me.Label2, Me.Label1, Me.dtp_end_date, Me.dtp_start_date})
		Me.Name = "frmSIMOrderReports"
		Me.Text = "SIM Order Reports"
		Me.gbReportType.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
		Me.Cursor = Cursors.WaitCursor
		If rbAll.Checked Then
			AllReport()
		ElseIf rbOpen.Checked Then
			OpenReport()
		ElseIf rbRejected.Checked Then
			RejectedReport()
		ElseIf rbFilled.Checked Then
			FilledReport()
		End If
		Me.Cursor = Cursors.Default
	End Sub

	Private Sub AllReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim ds As New DataSet()
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM All Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetAllOrders(dtp_start_date.Text, dtp_end_date.Text)
		dt.TableName = "TNSimFilledOrders"
		If dt.Rows.Count > 0 Then
			ds.Tables.Add(dt)
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow SIM Orders")
			'Misc.OpenWin("TextNow SIM Orders.rpt", win, New RptViewer("TextNow SIM Orders.rpt", ds, params))
		Else
			MessageBox.Show("No Order(s) found for this date range.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

	Private Sub OpenReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim ds As New DataSet()
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM Open Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetOpenOrders(dtp_start_date.Value, dtp_end_date.Value)
		dt.TableName = "TNSimOpenOrders"
		If dt.Rows.Count > 0 Then
			ds.Tables.Add(dt)
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow SIM Open Orders")
			'Misc.OpenWin("TextNow SIM Open Orders.rpt", win, New RptViewer("TextNow SIM Open Orders.rpt", ds, params))
		Else
			MessageBox.Show("No Open Order(s) found for this date range.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

	Private Sub RejectedReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim ds As New DataSet()
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM Rejected Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetRejectedOrders(dtp_start_date.Value, dtp_end_date.Value)
		dt.TableName = "TNSimRejectedOrders"
		If dt.Rows.Count > 0 Then
			ds.Tables.Add(dt)
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow SIM Rejected Orders")
			'Misc.OpenWin("TextNow SIM Rejected Orders.rpt", win, New RptViewer("TextNow SIM Rejected Orders.rpt", ds, params))
		Else
			MessageBox.Show("No Rejected Order(s) found for this date range.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

	Private Sub FilledReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim ds As New DataSet()
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM Rejected Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetFilledOrders(dtp_start_date.Value, dtp_end_date.Value)
		dt.TableName = "TNSimFilledOrders"
		If dt.Rows.Count > 0 Then
			ds.Tables.Add(dt)
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow SIM Orders")
			'Misc.OpenWin("TextNow SIM Filled Orders.rpt", win, New RptViewer("TextNow SIM Filled Orders.rpt", ds, params))
		Else
			MessageBox.Show("No Filled Order(s) found for this date range.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

End Class
