Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSIMInventoryReports
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
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents btnPrint As System.Windows.Forms.Button
	Friend WithEvents rbAll As System.Windows.Forms.RadioButton
	Friend WithEvents rbNonKitted As System.Windows.Forms.RadioButton
	Friend WithEvents rbKitted As System.Windows.Forms.RadioButton
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.rbAll = New System.Windows.Forms.RadioButton()
		Me.rbNonKitted = New System.Windows.Forms.RadioButton()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.rbKitted = New System.Windows.Forms.RadioButton()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 327)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(496, 24)
		Me.Label3.TabIndex = 38
		Me.Label3.Text = "This screen is used to print SIM Inventory Reports"
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.Blue
		Me.Label4.Location = New System.Drawing.Point(28, 7)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(400, 40)
		Me.Label4.TabIndex = 37
		Me.Label4.Text = "SIM Inventory Reports"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbAll, Me.rbNonKitted, Me.Label6, Me.rbKitted})
		Me.GroupBox1.Location = New System.Drawing.Point(24, 71)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(464, 160)
		Me.GroupBox1.TabIndex = 39
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Report Type"
		'
		'rbAll
		'
		Me.rbAll.Location = New System.Drawing.Point(24, 112)
		Me.rbAll.Name = "rbAll"
		Me.rbAll.Size = New System.Drawing.Size(216, 24)
		Me.rbAll.TabIndex = 32
		Me.rbAll.Text = "Both Kitted and Non-Kitted Inventory"
		'
		'rbNonKitted
		'
		Me.rbNonKitted.Location = New System.Drawing.Point(24, 72)
		Me.rbNonKitted.Name = "rbNonKitted"
		Me.rbNonKitted.Size = New System.Drawing.Size(184, 24)
		Me.rbNonKitted.TabIndex = 31
		Me.rbNonKitted.Text = "Non-Kitted Inventory"
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Blue
		Me.Label6.Location = New System.Drawing.Point(112, -54)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(224, 44)
		Me.Label6.TabIndex = 29
		Me.Label6.Text = "Please enter the date range of orders received to be viewed."
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'rbKitted
		'
		Me.rbKitted.Checked = True
		Me.rbKitted.Location = New System.Drawing.Point(24, 32)
		Me.rbKitted.Name = "rbKitted"
		Me.rbKitted.TabIndex = 0
		Me.rbKitted.TabStop = True
		Me.rbKitted.Text = "Kitted Inventory"
		'
		'btnPrint
		'
		Me.btnPrint.Location = New System.Drawing.Point(400, 263)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(88, 32)
		Me.btnPrint.TabIndex = 36
		Me.btnPrint.Text = "Print"
		'
		'frmSIMInventoryReports
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(520, 358)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.Label4, Me.GroupBox1, Me.btnPrint})
		Me.Name = "frmSIMInventoryReports"
		Me.Text = "SIM Inventory Reports"
		Me.GroupBox1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
		Me.Cursor = Cursors.WaitCursor
		If rbKitted.Checked Then
			KittedReport()
		ElseIf rbNonKitted.Checked Then
			NonKittedReport()
		ElseIf rbAll.Checked Then
			AllInventoryReport()
		End If
		Me.Cursor = Cursors.Default
	End Sub

	Private Sub KittedReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM Rejected Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetKittedItemsBySku()
		dt.TableName = "TNSimInventory.ttx"
		If dt.Rows.Count > 0 Then
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow Kitted Inventory")
		Else
			MessageBox.Show("No Kitted Inventory found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

	Private Sub NonKittedReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM Rejected Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetNonKittedBySku()
		dt.TableName = "TNSimInventory.ttx"
		If dt.Rows.Count > 0 Then
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow Non-Kitted Inventory")
		Else
			MessageBox.Show("No Non-Kitted Inventory found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

	Private Sub AllInventoryReport()
		Dim _objDataProc As DBQuery.DataProc
		Dim dt As New DataTable()
		Dim objRpt As New ReportDocument()
		Dim strRptPath As String = PSS.Data.ConfigFile.GetBaseReportPath
		Dim strRptName As String = "TextNow SIM Rejected Orders.rpt"
		Dim _dp As New Data.BLL.TNSIMMiscDataProvider(PSS.Core.ApplicationUser.IDuser)
		Dim win As Crownwood.Magic.Controls.TabPage
		Dim params As String() = {True, True, True}
		dt = _dp.GetAllInventoryBySku()
		dt.TableName = "TNSimInventory.ttx"
		If dt.Rows.Count > 0 Then
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleXlAndOpen(dt, "TextNow Kitted and Non-Kitted Inventory")
		Else
			MessageBox.Show("No Inventory found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		_dp = Nothing
	End Sub

End Class
