'Imports System
'Imports System.Data.OleDb
'Imports Microsoft.Data.Odbc
'Imports System.Runtime.InteropServices


'Namespace Gui.ReportViewer



'    Public Class frmExcelOutput
'        Inherits System.Windows.Forms.Form

'        Private _objExcelOutput As PSS.Data.Buisness.ExcelOutput

'#Region " Windows Form Designer generated code "

'        Public Sub New()
'            MyBase.New()

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call

'        End Sub

'        'Form overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents grpTechReport As System.Windows.Forms.GroupBox
'        Friend WithEvents btnTechReport As System.Windows.Forms.Button
'        Friend WithEvents lblDate As System.Windows.Forms.Label
'        Friend WithEvents txtDate As System.Windows.Forms.TextBox
'        Friend WithEvents Label1 As System.Windows.Forms.Label
'        Friend WithEvents grpAudit As System.Windows.Forms.GroupBox
'        Friend WithEvents btnAudit1 As System.Windows.Forms.Button
'        Friend WithEvents btnAudit2 As System.Windows.Forms.Button
'        Friend WithEvents btnAudit3 As System.Windows.Forms.Button
'        Friend WithEvents btnAudit4 As System.Windows.Forms.Button
'        Friend WithEvents Button1 As System.Windows.Forms.Button
'        Friend WithEvents Button3 As System.Windows.Forms.Button
'        Friend WithEvents grpAUPreport As System.Windows.Forms.GroupBox
'        Friend WithEvents lblEndDate As System.Windows.Forms.Label
'        Friend WithEvents lblStartDate As System.Windows.Forms.Label
'        Friend WithEvents ckModelALL As System.Windows.Forms.CheckBox
'        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
'        Friend WithEvents lblModel As System.Windows.Forms.Label
'        Friend WithEvents ckCompanyALL As System.Windows.Forms.CheckBox
'        Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
'        Friend WithEvents lblCompany As System.Windows.Forms.Label
'        Friend WithEvents calEnd As System.Windows.Forms.DateTimePicker
'        Friend WithEvents calStart As System.Windows.Forms.DateTimePicker
'        Friend WithEvents btnAUPreport As System.Windows.Forms.Button
'        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
'        Friend WithEvents Button2 As System.Windows.Forms.Button
'        Friend WithEvents btnATCLEdata As System.Windows.Forms.Button
'        Friend WithEvents Button4 As System.Windows.Forms.Button
'        Friend WithEvents btnPCDB As System.Windows.Forms.Button
'        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
'        Friend WithEvents Label2 As System.Windows.Forms.Label
'        Friend WithEvents Label3 As System.Windows.Forms.Label
'        Friend WithEvents dteEnd As System.Windows.Forms.DateTimePicker
'        Friend WithEvents dteStart As System.Windows.Forms.DateTimePicker
'        Friend WithEvents btnPartReport As System.Windows.Forms.Button
'        Friend WithEvents btnInvRptPart As System.Windows.Forms.Button
'        Friend WithEvents btnValueReport As System.Windows.Forms.Button
'        Friend WithEvents btnValueReportComplete As System.Windows.Forms.Button
'        Friend WithEvents btnItemReportComplete As System.Windows.Forms.Button
'        Friend WithEvents btnItemReport As System.Windows.Forms.Button
'        Friend WithEvents btnBounceReport As System.Windows.Forms.Button
'        Friend WithEvents btnTechnician As System.Windows.Forms.Button
'        Friend WithEvents Button5 As System.Windows.Forms.Button
'        Friend WithEvents Label4 As System.Windows.Forms.Label
'        Friend WithEvents txtGroup As System.Windows.Forms.TextBox
'        Friend WithEvents Button6 As System.Windows.Forms.Button
'        Friend WithEvents Button7 As System.Windows.Forms.Button
'        Friend WithEvents Button8 As System.Windows.Forms.Button
'        Friend WithEvents Button9 As System.Windows.Forms.Button
'        Friend WithEvents Button10 As System.Windows.Forms.Button
'        Friend WithEvents Button11 As System.Windows.Forms.Button
'        Friend WithEvents btnCSWIP As System.Windows.Forms.Button
'        Friend WithEvents grpProductivity As System.Windows.Forms.GroupBox
'        Friend WithEvents btnSUMmr As System.Windows.Forms.Button
'        Friend WithEvents btnEmployeeReport As System.Windows.Forms.Button
'        Friend WithEvents btnProdRpt1 As System.Windows.Forms.Button
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.grpTechReport = New System.Windows.Forms.GroupBox()
'            Me.Label1 = New System.Windows.Forms.Label()
'            Me.btnTechReport = New System.Windows.Forms.Button()
'            Me.lblDate = New System.Windows.Forms.Label()
'            Me.txtDate = New System.Windows.Forms.TextBox()
'            Me.grpAudit = New System.Windows.Forms.GroupBox()
'            Me.btnAudit4 = New System.Windows.Forms.Button()
'            Me.btnAudit3 = New System.Windows.Forms.Button()
'            Me.btnAudit2 = New System.Windows.Forms.Button()
'            Me.btnAudit1 = New System.Windows.Forms.Button()
'            Me.Button1 = New System.Windows.Forms.Button()
'            Me.Button3 = New System.Windows.Forms.Button()
'            Me.grpAUPreport = New System.Windows.Forms.GroupBox()
'            Me.btnPCDB = New System.Windows.Forms.Button()
'            Me.Button4 = New System.Windows.Forms.Button()
'            Me.lblEndDate = New System.Windows.Forms.Label()
'            Me.lblStartDate = New System.Windows.Forms.Label()
'            Me.ckModelALL = New System.Windows.Forms.CheckBox()
'            Me.cboModel = New System.Windows.Forms.ComboBox()
'            Me.lblModel = New System.Windows.Forms.Label()
'            Me.ckCompanyALL = New System.Windows.Forms.CheckBox()
'            Me.cboCompany = New System.Windows.Forms.ComboBox()
'            Me.lblCompany = New System.Windows.Forms.Label()
'            Me.calEnd = New System.Windows.Forms.DateTimePicker()
'            Me.calStart = New System.Windows.Forms.DateTimePicker()
'            Me.btnAUPreport = New System.Windows.Forms.Button()
'            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
'            Me.Button2 = New System.Windows.Forms.Button()
'            Me.btnATCLEdata = New System.Windows.Forms.Button()
'            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
'            Me.grpProductivity = New System.Windows.Forms.GroupBox()
'            Me.btnSUMmr = New System.Windows.Forms.Button()
'            Me.btnEmployeeReport = New System.Windows.Forms.Button()
'            Me.btnProdRpt1 = New System.Windows.Forms.Button()
'            Me.Button11 = New System.Windows.Forms.Button()
'            Me.txtGroup = New System.Windows.Forms.TextBox()
'            Me.Label4 = New System.Windows.Forms.Label()
'            Me.Button5 = New System.Windows.Forms.Button()
'            Me.btnItemReportComplete = New System.Windows.Forms.Button()
'            Me.btnValueReportComplete = New System.Windows.Forms.Button()
'            Me.Label2 = New System.Windows.Forms.Label()
'            Me.Label3 = New System.Windows.Forms.Label()
'            Me.dteEnd = New System.Windows.Forms.DateTimePicker()
'            Me.dteStart = New System.Windows.Forms.DateTimePicker()
'            Me.Button8 = New System.Windows.Forms.Button()
'            Me.Button7 = New System.Windows.Forms.Button()
'            Me.Button9 = New System.Windows.Forms.Button()
'            Me.btnItemReport = New System.Windows.Forms.Button()
'            Me.btnValueReport = New System.Windows.Forms.Button()
'            Me.btnInvRptPart = New System.Windows.Forms.Button()
'            Me.btnPartReport = New System.Windows.Forms.Button()
'            Me.btnTechnician = New System.Windows.Forms.Button()
'            Me.btnBounceReport = New System.Windows.Forms.Button()
'            Me.Button6 = New System.Windows.Forms.Button()
'            Me.Button10 = New System.Windows.Forms.Button()
'            Me.btnCSWIP = New System.Windows.Forms.Button()
'            Me.grpTechReport.SuspendLayout()
'            Me.grpAudit.SuspendLayout()
'            Me.grpAUPreport.SuspendLayout()
'            Me.GroupBox1.SuspendLayout()
'            Me.GroupBox2.SuspendLayout()
'            Me.grpProductivity.SuspendLayout()
'            Me.SuspendLayout()
'            '
'            'grpTechReport
'            '
'            Me.grpTechReport.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnTechReport, Me.lblDate, Me.txtDate})
'            Me.grpTechReport.Location = New System.Drawing.Point(528, 16)
'            Me.grpTechReport.Name = "grpTechReport"
'            Me.grpTechReport.Size = New System.Drawing.Size(256, 96)
'            Me.grpTechReport.TabIndex = 20
'            Me.grpTechReport.TabStop = False
'            Me.grpTechReport.Text = "Technician Usage Report"
'            '
'            'Label1
'            '
'            Me.Label1.Location = New System.Drawing.Point(160, 32)
'            Me.Label1.Name = "Label1"
'            Me.Label1.Size = New System.Drawing.Size(76, 16)
'            Me.Label1.TabIndex = 3
'            Me.Label1.Text = "(yyyy-mm-dd)"
'            '
'            'btnTechReport
'            '
'            Me.btnTechReport.Location = New System.Drawing.Point(8, 64)
'            Me.btnTechReport.Name = "btnTechReport"
'            Me.btnTechReport.Size = New System.Drawing.Size(240, 23)
'            Me.btnTechReport.TabIndex = 2
'            Me.btnTechReport.Text = "Technician Usage Report"
'            '
'            'lblDate
'            '
'            Me.lblDate.Location = New System.Drawing.Point(8, 32)
'            Me.lblDate.Name = "lblDate"
'            Me.lblDate.Size = New System.Drawing.Size(40, 16)
'            Me.lblDate.TabIndex = 1
'            Me.lblDate.Text = "Date:"
'            '
'            'txtDate
'            '
'            Me.txtDate.Location = New System.Drawing.Point(48, 32)
'            Me.txtDate.Name = "txtDate"
'            Me.txtDate.TabIndex = 0
'            Me.txtDate.Text = ""
'            '
'            'grpAudit
'            '
'            Me.grpAudit.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAudit4, Me.btnAudit3, Me.btnAudit2, Me.btnAudit1})
'            Me.grpAudit.Location = New System.Drawing.Point(8, 536)
'            Me.grpAudit.Name = "grpAudit"
'            Me.grpAudit.Size = New System.Drawing.Size(456, 16)
'            Me.grpAudit.TabIndex = 21
'            Me.grpAudit.TabStop = False
'            Me.grpAudit.Text = "Audit Reports"
'            Me.grpAudit.Visible = False
'            '
'            'btnAudit4
'            '
'            Me.btnAudit4.Location = New System.Drawing.Point(8, 56)
'            Me.btnAudit4.Name = "btnAudit4"
'            Me.btnAudit4.Size = New System.Drawing.Size(208, 23)
'            Me.btnAudit4.TabIndex = 10
'            Me.btnAudit4.Text = "Tray/Device Count WIP CELLULAR"
'            '
'            'btnAudit3
'            '
'            Me.btnAudit3.Location = New System.Drawing.Point(240, 56)
'            Me.btnAudit3.Name = "btnAudit3"
'            Me.btnAudit3.Size = New System.Drawing.Size(208, 23)
'            Me.btnAudit3.TabIndex = 9
'            Me.btnAudit3.Text = "Tray/Device Count WIP MESSAGING"
'            '
'            'btnAudit2
'            '
'            Me.btnAudit2.Location = New System.Drawing.Point(240, 24)
'            Me.btnAudit2.Name = "btnAudit2"
'            Me.btnAudit2.Size = New System.Drawing.Size(208, 23)
'            Me.btnAudit2.TabIndex = 8
'            Me.btnAudit2.Text = "WIP List MESSAGING"
'            '
'            'btnAudit1
'            '
'            Me.btnAudit1.Location = New System.Drawing.Point(8, 24)
'            Me.btnAudit1.Name = "btnAudit1"
'            Me.btnAudit1.Size = New System.Drawing.Size(208, 23)
'            Me.btnAudit1.TabIndex = 7
'            Me.btnAudit1.Text = "WIP List CELLULAR"
'            '
'            'Button1
'            '
'            Me.Button1.Location = New System.Drawing.Point(528, 480)
'            Me.Button1.Name = "Button1"
'            Me.Button1.Size = New System.Drawing.Size(88, 48)
'            Me.Button1.TabIndex = 4
'            Me.Button1.Text = "Billed/ Issued Report"
'            Me.Button1.Visible = False
'            '
'            'Button3
'            '
'            Me.Button3.Location = New System.Drawing.Point(88, 480)
'            Me.Button3.Name = "Button3"
'            Me.Button3.Size = New System.Drawing.Size(136, 48)
'            Me.Button3.TabIndex = 23
'            Me.Button3.Text = "NEW Report - Billed/Issued based on new sum tables"
'            Me.Button3.Visible = False
'            '
'            'grpAUPreport
'            '
'            Me.grpAUPreport.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPCDB, Me.Button4, Me.lblEndDate, Me.lblStartDate, Me.ckModelALL, Me.cboModel, Me.lblModel, Me.ckCompanyALL, Me.cboCompany, Me.lblCompany, Me.calEnd, Me.calStart, Me.btnAUPreport})
'            Me.grpAUPreport.Location = New System.Drawing.Point(8, 16)
'            Me.grpAUPreport.Name = "grpAUPreport"
'            Me.grpAUPreport.Size = New System.Drawing.Size(512, 96)
'            Me.grpAUPreport.TabIndex = 35
'            Me.grpAUPreport.TabStop = False
'            Me.grpAUPreport.Text = "AUP Report"
'            '
'            'btnPCDB
'            '
'            Me.btnPCDB.Location = New System.Drawing.Point(296, 64)
'            Me.btnPCDB.Name = "btnPCDB"
'            Me.btnPCDB.Size = New System.Drawing.Size(208, 23)
'            Me.btnPCDB.TabIndex = 47
'            Me.btnPCDB.Text = "PART CONSUMPTION DATE BILLED"
'            '
'            'Button4
'            '
'            Me.Button4.Location = New System.Drawing.Point(104, 64)
'            Me.Button4.Name = "Button4"
'            Me.Button4.Size = New System.Drawing.Size(184, 23)
'            Me.Button4.TabIndex = 46
'            Me.Button4.Text = "PART CONSUMPTION REPORT"
'            '
'            'lblEndDate
'            '
'            Me.lblEndDate.Location = New System.Drawing.Point(8, 40)
'            Me.lblEndDate.Name = "lblEndDate"
'            Me.lblEndDate.Size = New System.Drawing.Size(64, 16)
'            Me.lblEndDate.TabIndex = 45
'            Me.lblEndDate.Text = "End Date:"
'            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblStartDate
'            '
'            Me.lblStartDate.Location = New System.Drawing.Point(8, 16)
'            Me.lblStartDate.Name = "lblStartDate"
'            Me.lblStartDate.Size = New System.Drawing.Size(64, 16)
'            Me.lblStartDate.TabIndex = 44
'            Me.lblStartDate.Text = "Start Date:"
'            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'ckModelALL
'            '
'            Me.ckModelALL.Location = New System.Drawing.Point(384, 40)
'            Me.ckModelALL.Name = "ckModelALL"
'            Me.ckModelALL.Size = New System.Drawing.Size(88, 16)
'            Me.ckModelALL.TabIndex = 43
'            Me.ckModelALL.Text = "ALL Models"
'            '
'            'cboModel
'            '
'            Me.cboModel.Location = New System.Drawing.Point(240, 40)
'            Me.cboModel.Name = "cboModel"
'            Me.cboModel.Size = New System.Drawing.Size(136, 21)
'            Me.cboModel.TabIndex = 42
'            '
'            'lblModel
'            '
'            Me.lblModel.Location = New System.Drawing.Point(176, 40)
'            Me.lblModel.Name = "lblModel"
'            Me.lblModel.Size = New System.Drawing.Size(64, 16)
'            Me.lblModel.TabIndex = 41
'            Me.lblModel.Text = "Model:"
'            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'ckCompanyALL
'            '
'            Me.ckCompanyALL.Location = New System.Drawing.Point(384, 16)
'            Me.ckCompanyALL.Name = "ckCompanyALL"
'            Me.ckCompanyALL.Size = New System.Drawing.Size(104, 16)
'            Me.ckCompanyALL.TabIndex = 40
'            Me.ckCompanyALL.Text = "ALL Companies"
'            '
'            'cboCompany
'            '
'            Me.cboCompany.Location = New System.Drawing.Point(240, 16)
'            Me.cboCompany.Name = "cboCompany"
'            Me.cboCompany.Size = New System.Drawing.Size(136, 21)
'            Me.cboCompany.TabIndex = 39
'            '
'            'lblCompany
'            '
'            Me.lblCompany.Location = New System.Drawing.Point(176, 16)
'            Me.lblCompany.Name = "lblCompany"
'            Me.lblCompany.Size = New System.Drawing.Size(64, 16)
'            Me.lblCompany.TabIndex = 38
'            Me.lblCompany.Text = "Company:"
'            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'calEnd
'            '
'            Me.calEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
'            Me.calEnd.Location = New System.Drawing.Point(72, 40)
'            Me.calEnd.Name = "calEnd"
'            Me.calEnd.Size = New System.Drawing.Size(96, 20)
'            Me.calEnd.TabIndex = 37
'            '
'            'calStart
'            '
'            Me.calStart.CustomFormat = ""
'            Me.calStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
'            Me.calStart.Location = New System.Drawing.Point(72, 16)
'            Me.calStart.Name = "calStart"
'            Me.calStart.Size = New System.Drawing.Size(96, 20)
'            Me.calStart.TabIndex = 36
'            '
'            'btnAUPreport
'            '
'            Me.btnAUPreport.Location = New System.Drawing.Point(8, 64)
'            Me.btnAUPreport.Name = "btnAUPreport"
'            Me.btnAUPreport.Size = New System.Drawing.Size(88, 23)
'            Me.btnAUPreport.TabIndex = 35
'            Me.btnAUPreport.Text = "AUP REPORT"
'            '
'            'GroupBox1
'            '
'            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2})
'            Me.GroupBox1.Location = New System.Drawing.Point(536, 264)
'            Me.GroupBox1.Name = "GroupBox1"
'            Me.GroupBox1.Size = New System.Drawing.Size(248, 80)
'            Me.GroupBox1.TabIndex = 36
'            Me.GroupBox1.TabStop = False
'            Me.GroupBox1.Text = "Billed/ Issued Report"
'            '
'            'Button2
'            '
'            Me.Button2.Location = New System.Drawing.Point(16, 24)
'            Me.Button2.Name = "Button2"
'            Me.Button2.Size = New System.Drawing.Size(216, 48)
'            Me.Button2.TabIndex = 23
'            Me.Button2.Text = "Billed/ Issued Report"
'            '
'            'btnATCLEdata
'            '
'            Me.btnATCLEdata.Location = New System.Drawing.Point(312, 416)
'            Me.btnATCLEdata.Name = "btnATCLEdata"
'            Me.btnATCLEdata.Size = New System.Drawing.Size(152, 32)
'            Me.btnATCLEdata.TabIndex = 37
'            Me.btnATCLEdata.Text = "ATCLE Daily Metrics"
'            Me.btnATCLEdata.Visible = False
'            '
'            'GroupBox2
'            '
'            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpProductivity, Me.Button11, Me.txtGroup, Me.Label4, Me.Button5, Me.btnItemReportComplete, Me.btnValueReportComplete, Me.Label2, Me.Label3, Me.dteEnd, Me.dteStart, Me.Button8})
'            Me.GroupBox2.Location = New System.Drawing.Point(8, 120)
'            Me.GroupBox2.Name = "GroupBox2"
'            Me.GroupBox2.Size = New System.Drawing.Size(520, 256)
'            Me.GroupBox2.TabIndex = 38
'            Me.GroupBox2.TabStop = False
'            Me.GroupBox2.Text = "Administrative Reports"
'            '
'            'grpProductivity
'            '
'            Me.grpProductivity.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSUMmr, Me.btnEmployeeReport, Me.btnProdRpt1})
'            Me.grpProductivity.Location = New System.Drawing.Point(48, 152)
'            Me.grpProductivity.Name = "grpProductivity"
'            Me.grpProductivity.Size = New System.Drawing.Size(440, 80)
'            Me.grpProductivity.TabIndex = 64
'            Me.grpProductivity.TabStop = False
'            Me.grpProductivity.Text = "Productivity Reports"
'            '
'            'btnSUMmr
'            '
'            Me.btnSUMmr.Location = New System.Drawing.Point(136, 24)
'            Me.btnSUMmr.Name = "btnSUMmr"
'            Me.btnSUMmr.Size = New System.Drawing.Size(144, 48)
'            Me.btnSUMmr.TabIndex = 63
'            Me.btnSUMmr.Text = "Summary Manager Report"
'            '
'            'btnEmployeeReport
'            '
'            Me.btnEmployeeReport.Location = New System.Drawing.Point(288, 24)
'            Me.btnEmployeeReport.Name = "btnEmployeeReport"
'            Me.btnEmployeeReport.Size = New System.Drawing.Size(136, 48)
'            Me.btnEmployeeReport.TabIndex = 62
'            Me.btnEmployeeReport.Text = "Employee Report"
'            '
'            'btnProdRpt1
'            '
'            Me.btnProdRpt1.Location = New System.Drawing.Point(8, 24)
'            Me.btnProdRpt1.Name = "btnProdRpt1"
'            Me.btnProdRpt1.Size = New System.Drawing.Size(120, 48)
'            Me.btnProdRpt1.TabIndex = 61
'            Me.btnProdRpt1.Text = "Detailed Manager Report"
'            '
'            'Button11
'            '
'            Me.Button11.Location = New System.Drawing.Point(328, 16)
'            Me.Button11.Name = "Button11"
'            Me.Button11.Size = New System.Drawing.Size(176, 56)
'            Me.Button11.TabIndex = 59
'            Me.Button11.Text = "NEW DATA (After 10/18/2006) Robert Cook report- Department/Employee Billing"
'            '
'            'txtGroup
'            '
'            Me.txtGroup.Location = New System.Drawing.Point(72, 72)
'            Me.txtGroup.Name = "txtGroup"
'            Me.txtGroup.Size = New System.Drawing.Size(56, 20)
'            Me.txtGroup.TabIndex = 58
'            Me.txtGroup.Text = ""
'            '
'            'Label4
'            '
'            Me.Label4.Location = New System.Drawing.Point(8, 72)
'            Me.Label4.Name = "Label4"
'            Me.Label4.Size = New System.Drawing.Size(56, 16)
'            Me.Label4.TabIndex = 57
'            Me.Label4.Text = "Group:"
'            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'Button5
'            '
'            Me.Button5.Location = New System.Drawing.Point(184, 96)
'            Me.Button5.Name = "Button5"
'            Me.Button5.Size = New System.Drawing.Size(136, 32)
'            Me.Button5.TabIndex = 56
'            Me.Button5.Text = "Tech Report NEW"
'            '
'            'btnItemReportComplete
'            '
'            Me.btnItemReportComplete.Location = New System.Drawing.Point(184, 56)
'            Me.btnItemReportComplete.Name = "btnItemReportComplete"
'            Me.btnItemReportComplete.Size = New System.Drawing.Size(136, 32)
'            Me.btnItemReportComplete.TabIndex = 54
'            Me.btnItemReportComplete.Text = "Item Report (complete)"
'            '
'            'btnValueReportComplete
'            '
'            Me.btnValueReportComplete.Location = New System.Drawing.Point(184, 16)
'            Me.btnValueReportComplete.Name = "btnValueReportComplete"
'            Me.btnValueReportComplete.Size = New System.Drawing.Size(136, 32)
'            Me.btnValueReportComplete.TabIndex = 53
'            Me.btnValueReportComplete.Text = "Value Report (complete)"
'            '
'            'Label2
'            '
'            Me.Label2.Location = New System.Drawing.Point(8, 40)
'            Me.Label2.Name = "Label2"
'            Me.Label2.Size = New System.Drawing.Size(64, 16)
'            Me.Label2.TabIndex = 49
'            Me.Label2.Text = "End Date:"
'            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'Label3
'            '
'            Me.Label3.Location = New System.Drawing.Point(8, 16)
'            Me.Label3.Name = "Label3"
'            Me.Label3.Size = New System.Drawing.Size(64, 16)
'            Me.Label3.TabIndex = 48
'            Me.Label3.Text = "Start Date:"
'            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'dteEnd
'            '
'            Me.dteEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
'            Me.dteEnd.Location = New System.Drawing.Point(72, 40)
'            Me.dteEnd.Name = "dteEnd"
'            Me.dteEnd.Size = New System.Drawing.Size(96, 20)
'            Me.dteEnd.TabIndex = 47
'            '
'            'dteStart
'            '
'            Me.dteStart.CustomFormat = ""
'            Me.dteStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
'            Me.dteStart.Location = New System.Drawing.Point(72, 16)
'            Me.dteStart.Name = "dteStart"
'            Me.dteStart.Size = New System.Drawing.Size(96, 20)
'            Me.dteStart.TabIndex = 46
'            '
'            'Button8
'            '
'            Me.Button8.Location = New System.Drawing.Point(328, 80)
'            Me.Button8.Name = "Button8"
'            Me.Button8.Size = New System.Drawing.Size(176, 48)
'            Me.Button8.TabIndex = 42
'            Me.Button8.Text = "NEW DATA (After 10/18/2006) Department/Employee Billing by Model"
'            '
'            'Button7
'            '
'            Me.Button7.Location = New System.Drawing.Point(464, 448)
'            Me.Button7.Name = "Button7"
'            Me.Button7.Size = New System.Drawing.Size(152, 32)
'            Me.Button7.TabIndex = 41
'            Me.Button7.Text = "Robert Cook report- Department/Employee Billing"
'            Me.Button7.Visible = False
'            '
'            'Button9
'            '
'            Me.Button9.Location = New System.Drawing.Point(312, 448)
'            Me.Button9.Name = "Button9"
'            Me.Button9.Size = New System.Drawing.Size(152, 32)
'            Me.Button9.TabIndex = 59
'            Me.Button9.Text = " Department/Triage Billing by Model"
'            Me.Button9.Visible = False
'            '
'            'btnItemReport
'            '
'            Me.btnItemReport.Location = New System.Drawing.Point(392, 480)
'            Me.btnItemReport.Name = "btnItemReport"
'            Me.btnItemReport.Size = New System.Drawing.Size(136, 48)
'            Me.btnItemReport.TabIndex = 55
'            Me.btnItemReport.Text = "Item Report (abridged)"
'            Me.btnItemReport.Visible = False
'            '
'            'btnValueReport
'            '
'            Me.btnValueReport.Location = New System.Drawing.Point(88, 448)
'            Me.btnValueReport.Name = "btnValueReport"
'            Me.btnValueReport.Size = New System.Drawing.Size(136, 32)
'            Me.btnValueReport.TabIndex = 52
'            Me.btnValueReport.Text = "Value Report (abridged)"
'            Me.btnValueReport.Visible = False
'            '
'            'btnInvRptPart
'            '
'            Me.btnInvRptPart.Location = New System.Drawing.Point(8, 480)
'            Me.btnInvRptPart.Name = "btnInvRptPart"
'            Me.btnInvRptPart.Size = New System.Drawing.Size(80, 48)
'            Me.btnInvRptPart.TabIndex = 51
'            Me.btnInvRptPart.Text = "Part Report"
'            Me.btnInvRptPart.Visible = False
'            '
'            'btnPartReport
'            '
'            Me.btnPartReport.Location = New System.Drawing.Point(312, 480)
'            Me.btnPartReport.Name = "btnPartReport"
'            Me.btnPartReport.Size = New System.Drawing.Size(80, 48)
'            Me.btnPartReport.TabIndex = 50
'            Me.btnPartReport.Text = "Value Report"
'            Me.btnPartReport.Visible = False
'            '
'            'btnTechnician
'            '
'            Me.btnTechnician.Location = New System.Drawing.Point(8, 448)
'            Me.btnTechnician.Name = "btnTechnician"
'            Me.btnTechnician.Size = New System.Drawing.Size(80, 32)
'            Me.btnTechnician.TabIndex = 40
'            Me.btnTechnician.Text = "Tech Report"
'            Me.btnTechnician.Visible = False
'            '
'            'btnBounceReport
'            '
'            Me.btnBounceReport.Location = New System.Drawing.Point(224, 448)
'            Me.btnBounceReport.Name = "btnBounceReport"
'            Me.btnBounceReport.Size = New System.Drawing.Size(88, 32)
'            Me.btnBounceReport.TabIndex = 39
'            Me.btnBounceReport.Text = "Bounce Report - 13 week"
'            Me.btnBounceReport.Visible = False
'            '
'            'Button6
'            '
'            Me.Button6.Location = New System.Drawing.Point(224, 480)
'            Me.Button6.Name = "Button6"
'            Me.Button6.Size = New System.Drawing.Size(88, 48)
'            Me.Button6.TabIndex = 40
'            Me.Button6.Text = "consolidation - SPECIAL"
'            Me.Button6.Visible = False
'            '
'            'Button10
'            '
'            Me.Button10.Location = New System.Drawing.Point(8, 416)
'            Me.Button10.Name = "Button10"
'            Me.Button10.Size = New System.Drawing.Size(304, 32)
'            Me.Button10.TabIndex = 60
'            Me.Button10.Text = "Robert Cook report- Department/Employee Billing Generation 2"
'            Me.Button10.Visible = False
'            '
'            'btnCSWIP
'            '
'            Me.btnCSWIP.Location = New System.Drawing.Point(536, 128)
'            Me.btnCSWIP.Name = "btnCSWIP"
'            Me.btnCSWIP.Size = New System.Drawing.Size(248, 128)
'            Me.btnCSWIP.TabIndex = 62
'            Me.btnCSWIP.Text = "WIP Report for Brightpoint Devices"
'            '
'            'frmExcelOutput
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.ClientSize = New System.Drawing.Size(792, 565)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCSWIP, Me.Button6, Me.btnBounceReport, Me.GroupBox2, Me.GroupBox1, Me.grpAUPreport, Me.Button3, Me.grpAudit, Me.grpTechReport, Me.Button1, Me.btnATCLEdata, Me.btnValueReport, Me.btnPartReport, Me.btnInvRptPart, Me.btnItemReport, Me.btnTechnician, Me.Button10, Me.Button9, Me.Button7})
'            Me.Name = "frmExcelOutput"
'            Me.Text = "frmExcelOutput"
'            Me.grpTechReport.ResumeLayout(False)
'            Me.grpAudit.ResumeLayout(False)
'            Me.grpAUPreport.ResumeLayout(False)
'            Me.GroupBox1.ResumeLayout(False)
'            Me.GroupBox2.ResumeLayout(False)
'            Me.grpProductivity.ResumeLayout(False)
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Private Sub frmExcelOutput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            Dim ds As PSS.Data.Production.Joins
'            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tcustomer where Cust_Name2 is null ORDER BY Cust_Name1")

'            Me._objExcelOutput = New PSS.Data.Buisness.ExcelOutput()

'            cboCompany.DataSource = dt
'            cboCompany.DisplayMember = dt.Columns("Cust_Name1").ToString
'            cboCompany.ValueMember = dt.Columns("Cust_ID").ToString

'            Dim dtModel As DataTable = ds.OrderEntrySelect("SELECT * FROM tmodel ORDER BY Model_Desc")
'            cboModel.DataSource = dtModel
'            cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
'            cboModel.ValueMember = dtModel.Columns("Model_ID").ToString

'            dtModel = Nothing
'            dt = Nothing
'            ds = Nothing

'        End Sub


'        Private Sub btnTechReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechReport.Click

'            Dim vTech As Integer = 0

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            Dim startDate As String = CDate(txtDate.Text) & " 00:00:00"
'            Dim endDate As String = DateAdd(DateInterval.Day, 1, CDate(txtDate.Text)) & " 03:10:00"


'            Dim strSQL, strSQL2 As String
'            strSQL = "SELECT security.tusers.tech_id, security.tusers.user_fullname, " & _
'            "lpsprice.psprice_number, count(lpsprice.psprice_number) as qty, " & _
'            "lpsprice.psprice_desc, tdevicebill.Dbill_AvgCost, " & _
'            "tdevicebill.Dbill_StdCost, tdevicebill.Dbill_invoiceamt " & _
'            "FROM " & _
'            "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            "inner join security.tusers on tdevicebill.user_id = " & _
'            "security.tusers.tech_id " & _
'            "WHERE tdevicebill.date_rec > '" & startDate & "' " & _
'            "and tdevicebill.date_rec < '" & endDate & "' " & _
'            "and tech_id > 0 and tech_id < 900 " & _
'            "and tech_id <> 99 " & _
'            "group by security.tusers.tech_id, lpsprice.psprice_number " & _
'            "order by security.tusers.tech_id"

'            Dim dr As PSS.Data.Production.Joins
'            Dim dr2 As PSS.Data.Production.Joins
'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            oBook = oExcel.workbooks.add
'            oSheet = oBook.worksheets(1)


'            Dim xCount As Integer = 0
'            Dim r As DataRow

'            oSheet.range("A1").value() = "TECHNICIAN REPORT = " & Me.txtDate.Text
'            oSheet.range("A2").value() = "Tech ID"
'            oSheet.range("A2").columnwidth = 10
'            oSheet.range("B2").value() = "Technician Name"
'            oSheet.range("B2").columnwidth = 25
'            oSheet.range("C2").value() = "Part Number"
'            oSheet.range("C2").columnwidth = 20
'            oSheet.range("D2").value() = "Quantity"
'            oSheet.range("D2").columnwidth = 10
'            oSheet.range("E2").value() = "Part Description"
'            oSheet.range("E2").columnwidth = 40
'            oSheet.range("F2").value() = "Standard Cost"
'            oSheet.range("F2").columnwidth = 20
'            oSheet.range("G2").value() = "Average Cost"
'            oSheet.range("G2").columnwidth = 20
'            oSheet.range("H2").value() = "Invoice Amount"
'            oSheet.range("H2").columnwidth = 20
'            oSheet.range("I2").value() = "Device Count"
'            oSheet.range("I2").columnwidth = 20

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                oSheet.range(CStr("A" & xCount + 3)).value = r(0)
'                oSheet.range(CStr("B" & xCount + 3)).value = r(1)
'                oSheet.range(CStr("C" & xCount + 3)).value = r(2)
'                Try
'                    oSheet.range(CStr("D" & xCount + 3)).value = r("qty").ToString
'                Catch ex As Exception
'                End Try
'                oSheet.range(CStr("E" & xCount + 3)).value = r(4)
'                oSheet.range(CStr("F" & xCount + 3)).value = r(5)
'                oSheet.range(CStr("G" & xCount + 3)).value = r(6)
'                oSheet.range(CStr("H" & xCount + 3)).value = r(7)

'                If vTech <> r(0) Then
'                    Try
'                        strSQL2 = "select distinct device_id from tdevicebill where user_id = " & r(0) & " and date_rec = '" & txtDate.Text & "'"
'                        Dim dt2 As DataTable = dr2.OrderEntrySelect(strSQL2)
'                        Try
'                            oSheet.range(CStr("I" & xCount + 3)).value = dt2.Rows.Count
'                            vTech = r(0)
'                        Catch ex As Exception
'                        End Try
'                    Catch ex As Exception
'                    End Try
'                End If

'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\techdoc.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\techdoc.xls")
'            showXL.Visible = True

'        End Sub

'        Private Sub btnAudit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudit1.Click

'            Dim strSQL As String

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            strSQL = "select lpsprice.psprice_number as 'Part Number', lpsprice.psprice_desc ' Description', " & _
'            "count(lpsprice.psprice_number) as 'Count' from " & _
'            "(((tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id) " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'            "where device_dateship is null " & _
'            "and device_datebill is not null " & _
'            "and tpsmap.prod_id=2 " & _
'            "group by lpsprice.psprice_number " & _
'            "order by psprice_number"


'            Dim dr As PSS.Data.Production.Joins
'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            oBook = oExcel.workbooks.add
'            oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim r As DataRow

'            oSheet.range("A1").value() = "AUDIT REPORT - CELLULAR PARTS DEFINED FOR WIP DEVICES"
'            oSheet.range("A2").value() = "Part Number"
'            oSheet.columns("A").numberformat = "@"
'            oSheet.range("A2").columnwidth = 25
'            oSheet.range("B2").value() = "Description"
'            oSheet.range("B2").columnwidth = 50
'            oSheet.range("C2").value() = "Count"
'            oSheet.range("C2").columnwidth = 10

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                oSheet.range(CStr("A" & xCount + 3)).value = r(0)
'                oSheet.range(CStr("B" & xCount + 3)).value = r(1)
'                Try
'                    oSheet.range(CStr("C" & xCount + 3)).value = r("Count").ToString
'                Catch ex As Exception
'                End Try
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\Audit Reports\Cellular\WIP List Cell.xls")
'            'oBook.saveas("r:\AuditDoc1.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\Audit Reports\Cellular\WIP List Cell.xls")
'            showXL.Visible = True


'        End Sub

'        Private Sub btnAudit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudit2.Click


'            Dim strSQL As String

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            strSQL = "select lpsprice.psprice_number as 'Part Number', lpsprice.psprice_desc ' Description', " & _
'            "count(lpsprice.psprice_number) as 'Count' from " & _
'            "(((tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id) " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'            "where device_dateship is null " & _
'            "and device_datebill is not null " & _
'            "and tpsmap.prod_id=1 " & _
'            "group by lpsprice.psprice_number " & _
'            "order by psprice_number"


'            Dim dr As PSS.Data.Production.Joins
'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            oBook = oExcel.workbooks.add
'            oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim r As DataRow

'            oSheet.range("A1").value() = "AUDIT REPORT - MESSAGING PARTS DEFINED FOR WIP DEVICES"
'            oSheet.range("A2").value() = "Part Number"
'            oSheet.range("A2").columnwidth = 25
'            oSheet.columns("A").numberformat = "@"
'            oSheet.range("B2").value() = "Description"
'            oSheet.range("B2").columnwidth = 50
'            oSheet.range("C2").value() = "Count"
'            oSheet.range("C2").columnwidth = 10

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                oSheet.range(CStr("A" & xCount + 3)).value = r(0)
'                oSheet.range(CStr("B" & xCount + 3)).value = r(1)
'                Try
'                    oSheet.range(CStr("C" & xCount + 3)).value = r("Count").ToString
'                Catch ex As Exception
'                End Try
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\AuditDoc2.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\AuditDoc2.xls")
'            showXL.Visible = True

'        End Sub

'        Private Sub btnAudit3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudit3.Click

'            Dim strSQL, strSQL2 As String

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            strSQL = "select tdevice.model_id, tmodel.model_desc, count(tray_id) " & _
'            "from tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "where(device_dateship Is null) " & _
'            "and tmodel.prod_id=1 " & _
'            "group by tdevice.model_id ORDER BY MODEL_DESC"

'            Dim dr, dr2 As PSS.Data.Production.Joins
'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            oBook = oExcel.workbooks.add
'            oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim r As DataRow

'            oSheet.range("A1").value() = "AUDIT REPORT - MESSAGING TRAY COUNT FOR WIP DEVICES"
'            oSheet.range("A2").value() = "Model"
'            oSheet.range("A2").columnwidth = 20
'            oSheet.columns("A").numberformat = "@"
'            oSheet.range("B2").value() = "Device Count"
'            oSheet.range("B2").columnwidth = 20
'            oSheet.range("C2").value() = "Tray Count"
'            oSheet.range("C2").columnwidth = 20

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                oSheet.range(CStr("A" & xCount + 3)).value = r(1)
'                Try
'                    oSheet.range(CStr("B" & xCount + 3)).value = r(2).ToString
'                Catch ex As Exception
'                End Try

'                Try

'                    strSQL2 = "select distinct model_id, tray_id " & _
'                    "from(tdevice) where(device_dateship Is null) " & _
'                    "and model_id= " & r(0) & " group by tray_id order by model_id, tray_id"

'                    Dim dt2 As DataTable = dr2.OrderEntrySelect(strSQL2)

'                    Try
'                        oSheet.range(CStr("C" & xCount + 3)).value = dt2.Rows.Count
'                    Catch ex As Exception
'                    End Try
'                Catch ex As Exception
'                End Try
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\AuditDoc3.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\AuditDoc3.xls")
'            showXL.Visible = True


'        End Sub



'        Private Sub btnAudit4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudit4.Click

'            Dim strSQL, strSQL2 As String

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            strSQL = "select tdevice.model_id, tmodel.model_desc, count(tray_id) " & _
'            "from tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "where(device_dateship Is null) " & _
'            "and tmodel.prod_id=2 " & _
'            "group by tdevice.model_id ORDER BY MODEL_DESC"

'            Dim dr, dr2 As PSS.Data.Production.Joins
'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            oBook = oExcel.workbooks.add
'            oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim r As DataRow

'            oSheet.range("A1").value() = "AUDIT REPORT - CELLULAR TRAY COUNT FOR WIP DEVICES"
'            oSheet.range("A2").value() = "Model"
'            oSheet.range("A2").columnwidth = 20
'            oSheet.columns("A").numberformat = "@"
'            oSheet.range("B2").value() = "Device Count"
'            oSheet.range("B2").columnwidth = 20
'            oSheet.range("C2").value() = "Tray Count"
'            oSheet.range("C2").columnwidth = 20

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                oSheet.range(CStr("A" & xCount + 3)).value = r(1)
'                Try
'                    oSheet.range(CStr("B" & xCount + 3)).value = r(2).ToString
'                Catch ex As Exception
'                End Try

'                Try

'                    strSQL2 = "select distinct model_id, tray_id " & _
'                    "from(tdevice) where(device_dateship Is null) " & _
'                    "and model_id= " & r(0) & " group by tray_id order by model_id, tray_id"

'                    Dim dt2 As DataTable = dr2.OrderEntrySelect(strSQL2)

'                    Try
'                        oSheet.range(CStr("C" & xCount + 3)).value = dt2.Rows.Count
'                    Catch ex As Exception
'                    End Try
'                Catch ex As Exception
'                End Try
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\AuditDoc4.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\AuditDoc4.xls")
'            showXL.Visible = True



'        End Sub

'        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


'            Dim range1Start As String = "2004-11-14"
'            Dim range1End As String = "2004-11-20"


'            Dim strWeek1 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range1Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range1End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim drWeek1 As PSS.Data.Production.Joins
'            Dim dtWeek1 As DataTable = drWeek1.OrderEntrySelect(strWeek1)
'            Dim CountWeek1 As Integer = 0
'            Dim rWeek1 As DataRow



'            Dim strSQL, strSQL1 As String
'            Dim defaultAdd As Integer = 0

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            '//First group is to get parts issued to floor
'            strSQL = "select distinct part_group from sumparts order by part_desc"


'            Dim dr As PSS.Data.Production.Joins
'            Dim dr1 As PSS.Data.Production.Joins
'            Dim drPName As PSS.Data.Production.Joins
'            Dim drToFloor As PSS.Data.Production.Joins

'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)
'            Dim dt1 As DataTable
'            Dim dtPName As DataTable
'            Dim dtToFloor As DataTable

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            oBook = oExcel.workbooks.add
'            oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim xCount1 As Integer = 0
'            Dim r As DataRow
'            Dim r1 As DataRow
'            Dim rPName As DataRow
'            Dim rToFloor As DataRow

'            oSheet.range("A1").value() = "PSS Parts Billed/Issued Report"
'            oSheet.range("A2").value() = "Part Description"
'            'oSheet.columns("A").numberformat = "@"
'            oSheet.range("A2").columnwidth = 40
'            oSheet.range("B2").value() = "Part Number"
'            oSheet.range("B2").columnwidth = 20
'            oSheet.range("C2").value() = "PN - SubSet"
'            oSheet.range("C2").columnwidth = 40
'            oSheet.range("D2").value() = "SubSet(PN)"
'            oSheet.range("D2").columnwidth = 20

'            oSheet.range("E2").value() = ""
'            oSheet.range("E2").columnwidth = 4
'            oSheet.range("F2").value() = "Billed"
'            oSheet.range("F2").columnwidth = 10
'            oSheet.range("G1").value() = "WEEK 47"
'            oSheet.range("G2").value() = "To Floor"
'            oSheet.range("G2").columnwidth = 10
'            oSheet.range("H2").value() = "Diff."
'            oSheet.range("H2").columnwidth = 10
'            oSheet.range("I2").value() = "Avg Cost"
'            oSheet.range("I2").columnwidth = 10


'            Dim sumToFloor As Integer = 0

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)

'                strSQL1 = "SELECT * FROM SUMPARTS WHERE part_group = '" & r(0) & "' order by part_desc"
'                dt1 = dr1.OrderEntrySelect(strSQL1)
'                If dt1.Rows.Count > 1 Then
'                    sumToFloor = 0
'                    For xCount1 = 0 To dt1.Rows.Count - 1
'                        r1 = dt1.Rows(xCount1)
'                        oSheet.range(CStr("C" & xCount + xCount1 + defaultAdd + 3)).value = r1("Part_Desc").ToString
'                        oSheet.range(CStr("D" & xCount + xCount1 + defaultAdd + 3)).value = r1("Part_Number").ToString

'                        Try
'                            dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count) from sumdparts where dpart_number = '" & r1("Part_Number") & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' group by dpart_number")
'                            rToFloor = dtToFloor.Rows(0)
'                            oSheet.range(CStr("G" & xCount + xCount1 + defaultAdd + 3)).value = rToFloor(0).ToString
'                            sumToFloor += rToFloor(0)
'                        Catch ex As Exception
'                        End Try

'                    Next
'                    defaultAdd += dt1.Rows.Count
'                End If

'                Try
'                    dtPName = drPName.OrderEntrySelect("SELECT Part_Desc FROM sumparts WHERE part_number = '" & r(0) & "'")
'                    rPName = dtPName.Rows(0)
'                    oSheet.range(CStr("A" & xCount + defaultAdd + 3)).value = rPName(0)
'                    If dt1.Rows.Count > 1 Then
'                        oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = sumToFloor
'                    Else
'                        Try
'                            dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' group by dpart_number")
'                            rToFloor = dtToFloor.Rows(0)
'                            oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                        Catch ex As Exception
'                        End Try
'                    End If


'                    Try
'                        For CountWeek1 = 0 To dtWeek1.Rows.Count - 1
'                            rWeek1 = dtWeek1.Rows(CountWeek1)
'                            'MsgBox(rWeek1(0).ToString & ", " & r(0).ToString)
'                            If Trim(rWeek1(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value = rWeek1(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try


'                Catch ex As Exception
'                End Try


'                '//Assign Difference
'                If dt1.Rows.Count < 2 Then
'                    Try
'                        oSheet.range(CStr("H" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try
'                End If

'                oSheet.range(CStr("B" & xCount + defaultAdd + 3)).value = r(0)

'                'Try
'                'oSheet.range(CStr("C" & xCount + 3)).value = r("Count").ToString
'                'Catch ex As Exception
'                'End Try
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\cdhtest.xls")
'            'oBook.saveas("r:\AuditDoc1.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\cdhtest.xls")
'            showXL.Visible = True



'        End Sub

'        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            Dim range1Start As String = "2005-01-29"
'            Dim range1End As String = "2005-01-23"
'            Dim range2Start As String = "2005-01-16"
'            Dim range2End As String = "2005-01-22"
'            Dim range3Start As String = "2005-01-09"
'            Dim range3End As String = "2005-01-15"
'            Dim range4Start As String = "2005-01-02"
'            Dim range4End As String = "2005-01-08"
'            Dim rangeYTDStart As String = "2004-04-01"
'            Dim rangeYTDEnd As String = "2005-01-29"

'            Dim strWeek1 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range1Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range1End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim strWeek2 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range2Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range2End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim strWeek3 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range3Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range3End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim strWeek4 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range4Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range4End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"

'            Dim strWeekYTD As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & rangeYTDStart & "' " & _
'                                        "and tdevice.device_datebill < '" & rangeYTDEnd & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"

'            'Dim strWeekYTD As String = "SELECT spytd_number as psprice_number , spytd_count as countBilled  FROM sumdpartsYTD"


'            Dim drWeek1 As PSS.Data.Production.Joins
'            Dim dtWeek1 As DataTable = drWeek1.OrderEntrySelect(strWeek1)
'            Dim CountWeek1 As Integer = 0
'            Dim rWeek1 As DataRow

'            Dim drWeek2 As PSS.Data.Production.Joins
'            Dim dtWeek2 As DataTable = drWeek2.OrderEntrySelect(strWeek2)
'            Dim CountWeek2 As Integer = 0
'            Dim rWeek2 As DataRow

'            Dim drWeek3 As PSS.Data.Production.Joins
'            Dim dtWeek3 As DataTable = drWeek3.OrderEntrySelect(strWeek3)
'            Dim CountWeek3 As Integer = 0
'            Dim rWeek3 As DataRow

'            Dim drWeek4 As PSS.Data.Production.Joins
'            Dim dtWeek4 As DataTable = drWeek4.OrderEntrySelect(strWeek4)
'            Dim CountWeek4 As Integer = 0
'            Dim rWeek4 As DataRow

'            Dim drWeekYTD As PSS.Data.Production.Joins
'            Dim dtWeekYTD As DataTable = drWeekYTD.OrderEntrySelect(strWeekYTD)
'            Dim CountWeekYTD As Integer = 0
'            Dim rWeekYTD As DataRow

'            Dim strSQL, strSQL1 As String
'            Dim defaultAdd As Integer = 0

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            '//First group is to get parts issued to floor
'            '            strSQL = "select distinct part_number from sumparts order by part_desc"
'            'strSQL = "select distinct spytd_number as part_number from sumdpartsytd order by spytd_number"
'            'strSQL = "select distinct spytd_number as part_number from sumdpartsytd inner join lpsprice on sumdpartsytd.spytd_number = lpsprice.psprice_number order by psprice_Desc"


'            strSQL = "select distinct parts_number as part_number from ((sumpartsnumbers inner join lpsprice on sumpartsnumbers.parts_number = lpsprice.psprice_number) inner join tpsmap on lpsprice.psprice_id = tpsmap.psprice_id) where tpsmap.prod_id=1 order by psprice_Desc"


'            Dim dr As PSS.Data.Production.Joins
'            Dim dr1 As PSS.Data.Production.Joins
'            Dim dr2 As PSS.Data.Production.Joins
'            Dim dr3 As PSS.Data.Production.Joins
'            Dim drYTD As PSS.Data.Production.Joins
'            Dim drPName As PSS.Data.Production.Joins
'            Dim drToFloor As PSS.Data.Production.Joins
'            Dim drToFloor1 As PSS.Data.Production.Joins
'            Dim drToFloor2 As PSS.Data.Production.Joins
'            Dim drToFloor3 As PSS.Data.Production.Joins
'            Dim drToFloorYTD As PSS.Data.Production.Joins

'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)
'            Dim dt1 As DataTable
'            Dim dt2 As DataTable
'            Dim dt3 As DataTable
'            Dim dtYTD As DataTable
'            Dim dtPName As DataTable
'            Dim dtToFloor As DataTable
'            Dim dtToFloor1 As DataTable
'            Dim dtToFloor2 As DataTable
'            Dim dtToFloor3 As DataTable
'            Dim dtToFloorYTD As DataTable

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            'oExcel = GetObject("r:\rptTemplate1.xls", "Excel.Application")
'            oBook = oExcel.workbooks.add
'            'oBook = oExcel.workbooks(1)
'            oSheet = oBook.worksheets(1)
'            'oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim xCount1 As Integer = 0
'            Dim r As DataRow
'            Dim r1 As DataRow
'            Dim r2 As DataRow
'            Dim r3 As DataRow
'            Dim rYTD As DataRow
'            Dim rPName As DataRow
'            Dim rToFloor As DataRow
'            Dim rToFloor1 As DataRow
'            Dim rToFloor2 As DataRow
'            Dim rToFloor3 As DataRow
'            Dim rToFloorYTD As DataRow

'            oSheet.range("A1").value() = "PSS Parts Billed/Issued Report"
'            oSheet.range("A2").value() = "Part Description"
'            'oSheet.columns("A").numberformat = "@"
'            oSheet.range("A2").columnwidth = 20
'            oSheet.range("B2").value() = "Part Number"
'            oSheet.range("B2").columnwidth = 20
'            'oSheet.range("C2").value() = "PN - SubSet"
'            'oSheet.range("C2").columnwidth = 0
'            'oSheet.range("D2").value() = "SubSet(PN)"
'            'oSheet.range("D2").columnwidth = 0

'            oSheet.range("E2").value() = ""
'            oSheet.range("E2").columnwidth = 1
'            oSheet.range("F2").value() = "Billed"
'            oSheet.range("F2").columnwidth = 8
'            oSheet.range("G1").value() = "WEEK 4"
'            oSheet.range("G2").value() = "To Floor"
'            oSheet.range("G2").columnwidth = 8
'            oSheet.range("H2").value() = "Diff."
'            oSheet.range("H2").columnwidth = 8
'            oSheet.range("I2").value() = "Avg Cost"
'            oSheet.range("I2").columnwidth = 8
'            oSheet.columns("I").numberformat = "0.00"

'            oSheet.range("J2").value() = ""
'            oSheet.range("J2").columnwidth = 1
'            oSheet.range("K2").value() = "Billed"
'            oSheet.range("K2").columnwidth = 8
'            oSheet.range("L1").value() = "WEEK 3"
'            oSheet.range("L2").value() = "To Floor"
'            oSheet.range("L2").columnwidth = 8
'            oSheet.range("M2").value() = "Diff."
'            oSheet.range("M2").columnwidth = 8
'            oSheet.range("N2").value() = "Avg Cost"
'            oSheet.range("N2").columnwidth = 8
'            oSheet.columns("N").numberformat = "0.00"

'            oSheet.range("O2").value() = ""
'            oSheet.range("O2").columnwidth = 1
'            oSheet.range("P2").value() = "Billed"
'            oSheet.range("P2").columnwidth = 8
'            oSheet.range("Q1").value() = "WEEK 2"
'            oSheet.range("Q2").value() = "To Floor"
'            oSheet.range("Q2").columnwidth = 8
'            oSheet.range("R2").value() = "Diff."
'            oSheet.range("R2").columnwidth = 8
'            oSheet.range("S2").value() = "Avg Cost"
'            oSheet.range("S2").columnwidth = 8
'            oSheet.columns("S").numberformat = "0.00"

'            oSheet.range("T2").value() = ""
'            oSheet.range("T2").columnwidth = 1
'            oSheet.range("U2").value() = "Billed"
'            oSheet.range("U2").columnwidth = 8
'            oSheet.range("V1").value() = "WEEK 1"
'            oSheet.range("V2").value() = "To Floor"
'            oSheet.range("V2").columnwidth = 8
'            oSheet.range("W2").value() = "Diff."
'            oSheet.range("W2").columnwidth = 8
'            oSheet.range("X2").value() = "Avg Cost"
'            oSheet.range("X2").columnwidth = 8
'            oSheet.columns("X").numberformat = "0.00"

'            oSheet.range("Y2").value() = ""
'            oSheet.range("Y2").columnwidth = 1
'            oSheet.range("Z2").value() = "Billed"
'            oSheet.range("Z2").columnwidth = 8
'            oSheet.range("AA1").value() = "YEAR TO DATE"
'            oSheet.range("AA2").value() = "To Floor"
'            oSheet.range("AA2").columnwidth = 8
'            oSheet.range("AB2").value() = "Diff."
'            oSheet.range("AB2").columnwidth = 8
'            oSheet.range("AC2").value() = "Avg Cost"
'            oSheet.range("AC2").columnwidth = 8
'            oSheet.columns("AC").numberformat = "0.00"


'            Dim sumToFloor As Integer = 0

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                '//Craig Haney December 10m 2004
'                'strSQL1 = "SELECT * FROM SUMPARTS WHERE part_number = '" & r(0) & "' order by part_desc"
'                strSQL1 = "SELECT * FROM lpsprice WHERE PSPrice_number = '" & r(0) & "' order by PSPrice_desc"


'                dt1 = dr1.OrderEntrySelect(strSQL1)

'                Try
'                    '//Craig Haney December 10m 2004
'                    'dtPName = drPName.OrderEntrySelect("SELECT Part_Desc FROM sumparts WHERE part_number = '" & r(0) & "'")
'                    dtPName = drPName.OrderEntrySelect("SELECT PSPrice_Desc FROM lpsprice WHERE PSPrice_number = '" & r(0) & "'")

'                    rPName = dtPName.Rows(0)
'                    oSheet.range(CStr("A" & xCount + defaultAdd + 3)).value = rPName(0)
'                    'If dt1.Rows.Count > 1 Then
'                    'If sumToFloor < 1 Then sumToFloor = 0
'                    'oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = sumToFloor
'                    'Else


'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select dpart_avgcost from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("I" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try


'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range2Start & "' and dpart_date < '" & range2End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("L" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range2Start & "' and dpart_date < '" & range2End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("N" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range3Start & "' and dpart_date < '" & range3End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("Q" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range3Start & "' and dpart_date < '" & range3End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("S" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range4Start & "' and dpart_date < '" & range4End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("V" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range4Start & "' and dpart_date < '" & range4End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("X" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & rangeYTDStart & "' and dpart_date < '" & rangeYTDEnd & "' group by dpart_number")
'                        'dtToFloor = drToFloor.OrderEntrySelect("select spytd_count, spytd_avgcost from sumdpartsytd where spYTD_number = '" & r(0) & "'")
'                        rToFloor = dtToFloor.Rows(0)
'                        If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("AA" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & rangeYTDStart & "' and dpart_date < '" & rangeYTDEnd & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("AC" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try



'                    'End If

'                    Try
'                        For CountWeek1 = 0 To dtWeek1.Rows.Count - 1
'                            rWeek1 = dtWeek1.Rows(CountWeek1)
'                            If Trim(rWeek1(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value = rWeek1(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek2 = 0 To dtWeek2.Rows.Count - 1
'                            rWeek2 = dtWeek2.Rows(CountWeek2)
'                            If Trim(rWeek2(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("K" & xCount + defaultAdd + 3)).value = rWeek2(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek3 = 0 To dtWeek3.Rows.Count - 1
'                            rWeek3 = dtWeek3.Rows(CountWeek3)
'                            If Trim(rWeek3(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("P" & xCount + defaultAdd + 3)).value = rWeek3(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek4 = 0 To dtWeek4.Rows.Count - 1
'                            rWeek4 = dtWeek4.Rows(CountWeek4)
'                            If Trim(rWeek4(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("U" & xCount + defaultAdd + 3)).value = rWeek4(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeekYTD = 0 To dtWeekYTD.Rows.Count - 1
'                            rWeekYTD = dtWeekYTD.Rows(CountWeekYTD)
'                            If Trim(rWeekYTD(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("Z" & xCount + defaultAdd + 3)).value = rWeekYTD(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try


'                Catch ex As Exception
'                End Try


'                '//Assign Difference
'                If dt1.Rows.Count < 2 Then
'                    Try
'                        oSheet.range(CStr("H" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("M" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("K" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("L" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("Q" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("R" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("P" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("V" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("W" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("U" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("AB" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("AA" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("Z" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                End If

'                oSheet.range(CStr("B" & xCount + defaultAdd + 3)).value = r(0)
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\cdhtest.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\cdhtest.xls")
'            showXL.Visible = True


'        End Sub


'        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


'            '//Determine date ranges
'            Dim dteWeekEnd As Date = Now
'            Do Until Weekday(dteWeekEnd) = vbSaturday
'                dteWeekEnd = DateAdd(DateInterval.Day, -1, dteWeekEnd)
'            Loop

'            Dim rangeYTDStart As String = DatePart(DateInterval.Year, dteWeekEnd) & "-01-01"
'            Dim rangeYTDEnd As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)

'            Dim range1End As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -6, dteWeekEnd)
'            Dim range1Start As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -1, dteWeekEnd)

'            Dim range2End As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -6, dteWeekEnd)
'            Dim range2Start As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -1, dteWeekEnd)

'            Dim range3End As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -6, dteWeekEnd)
'            Dim range3Start As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -1, dteWeekEnd)

'            Dim range4End As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -6, dteWeekEnd)
'            Dim range4Start As String = DatePart(DateInterval.Year, dteWeekEnd) & "-" & DatePart(DateInterval.Month, dteWeekEnd) & "-" & DatePart(DateInterval.Day, dteWeekEnd)
'            dteWeekEnd = DateAdd(DateInterval.Day, -1, dteWeekEnd)


'            Dim strWeek1 As String = "select distinct sumpartsnumbers.parts_number as psprice_number, sumdpartsytd.spytd_itemcount as countbilled, sumdpartsytd.spytd_WeekNum from " & _
'"sumpartsnumbers inner join sumdpartsytd on sumpartsnumbers.billcode_id = sumdpartsytd.billcode_id " & _
'"and sumpartsnumbers.model_id = sumdpartsytd.model_id " & _
'"and spytd_weekstart = '" & range1Start & "' " & _
'"and spytd_weekend = '" & range1End & "' "

'            Dim strWeek2 As String = "select distinct sumpartsnumbers.parts_number as psprice_number, sumdpartsytd.spytd_itemcount as countbilled, sumdpartsytd.spytd_WeekNum from " & _
'"sumpartsnumbers inner join sumdpartsytd on sumpartsnumbers.billcode_id = sumdpartsytd.billcode_id " & _
'"and sumpartsnumbers.model_id = sumdpartsytd.model_id " & _
'"and spytd_weekstart = '" & range2Start & "' " & _
'"and spytd_weekend = '" & range2End & "' "

'            Dim strWeek3 As String = "select distinct sumpartsnumbers.parts_number as psprice_number, sumdpartsytd.spytd_itemcount as countbilled, sumdpartsytd.spytd_WeekNum from " & _
'"sumpartsnumbers inner join sumdpartsytd on sumpartsnumbers.billcode_id = sumdpartsytd.billcode_id " & _
'"and sumpartsnumbers.model_id = sumdpartsytd.model_id " & _
'"and spytd_weekstart = '" & range3Start & "' " & _
'"and spytd_weekend = '" & range3End & "' "

'            Dim strWeek4 As String = "select distinct sumpartsnumbers.parts_number as psprice_number, sumdpartsytd.spytd_itemcount as countbilled, sumdpartsytd.spytd_WeekNum from " & _
'"sumpartsnumbers inner join sumdpartsytd on sumpartsnumbers.billcode_id = sumdpartsytd.billcode_id " & _
'"and sumpartsnumbers.model_id = sumdpartsytd.model_id " & _
'"and spytd_weekstart = '" & range4Start & "' " & _
'"and spytd_weekend = '" & range4End & "' "

'            Dim strWeekYTD As String = "select sumpartsnumbers.parts_number as psprice_number, sum(sumdpartsytd.spytd_itemcount) as countbilled from " & _
'"sumpartsnumbers inner join sumdpartsytd on sumpartsnumbers.billcode_id = sumdpartsytd.billcode_id " & _
'"and sumpartsnumbers.model_id = sumdpartsytd.model_id " & _
'"and spytd_weekstart >= '" & rangeYTDStart & "' " & _
'"and spytd_weekend <= '" & rangeYTDEnd & "' " & _
'"group by sumpartsnumbers.parts_number"


'            Dim weekNum1 As Integer
'            Dim weekNum2 As Integer
'            Dim weekNum3 As Integer
'            Dim weekNum4 As Integer





'            Dim drWeek1 As PSS.Data.Production.Joins
'            Dim dtWeek1 As DataTable = drWeek1.OrderEntrySelect(strWeek1)
'            Dim CountWeek1 As Integer = 0
'            Dim rWeek1 As DataRow = dtWeek1.Rows(0)
'            weekNum1 = rWeek1("spytd_WeekNum")
'            'weekNum2 = dtWeek2.Rows(0).Item("spytd_WeekNum")
'            'weekNum3 = dtWeek3.Rows(0).Item("spytd_WeekNum")
'            'weekNum4 = dtWeek4.Rows(0).Item("spytd_WeekNum")

'            Dim drWeek2 As PSS.Data.Production.Joins
'            Dim dtWeek2 As DataTable = drWeek2.OrderEntrySelect(strWeek2)
'            Dim CountWeek2 As Integer = 0
'            Dim rWeek2 As DataRow

'            Dim drWeek3 As PSS.Data.Production.Joins
'            Dim dtWeek3 As DataTable = drWeek3.OrderEntrySelect(strWeek3)
'            Dim CountWeek3 As Integer = 0
'            Dim rWeek3 As DataRow

'            Dim drWeek4 As PSS.Data.Production.Joins
'            Dim dtWeek4 As DataTable = drWeek4.OrderEntrySelect(strWeek4)
'            Dim CountWeek4 As Integer = 0
'            Dim rWeek4 As DataRow

'            Dim drWeekYTD As PSS.Data.Production.Joins
'            Dim dtWeekYTD As DataTable = drWeekYTD.OrderEntrySelect(strWeekYTD)
'            Dim CountWeekYTD As Integer = 0
'            Dim rWeekYTD As DataRow

'            Dim strSQL, strSQL1 As String
'            Dim defaultAdd As Integer = 0

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            '//First group is to get parts issued to floor
'            '            strSQL = "select distinct part_number from sumparts order by part_desc"
'            'strSQL = "select distinct spytd_number as part_number from sumdpartsytd order by spytd_number"
'            'strSQL = "select distinct spytd_number as part_number from sumdpartsytd inner join lpsprice on sumdpartsytd.spytd_number = lpsprice.psprice_number order by psprice_Desc"
'            'strSQL = "select distinct spytd_number as part_number from ((sumdpartsytd inner join lpsprice on sumdpartsytd.spytd_number = lpsprice.psprice_number) inner join tpsmap on lpsprice.psprice_id = tpsmap.psprice_id) where tpsmap.prod_id=1 order by psprice_Desc"
'            'strSQL = "SELECT distinct parts_number as part_number from sumpartsnumbers order by parts_desc"
'            strSQL = "select distinct parts_number as part_number, parts_desc from " & _
'            "((sumpartsnumbers inner join sumdpartsytd on sumpartsnumbers.billcode_id = sumdpartsytd.billcode_id and sumpartsnumbers.model_id = sumdpartsytd.model_id) " & _
'            "inner join tpsmap on sumpartsnumbers.billcode_id = tpsmap.billcode_id and sumpartsnumbers.model_id = tpsmap.model_id) " & _
'            "where(prod_id = 1) " & _
'            "order by parts_number"


'            Dim dr As PSS.Data.Production.Joins
'            Dim dr1 As PSS.Data.Production.Joins
'            Dim dr2 As PSS.Data.Production.Joins
'            Dim dr3 As PSS.Data.Production.Joins
'            Dim drYTD As PSS.Data.Production.Joins
'            Dim drPName As PSS.Data.Production.Joins
'            Dim drToFloor As PSS.Data.Production.Joins
'            Dim drToFloor1 As PSS.Data.Production.Joins
'            Dim drToFloor2 As PSS.Data.Production.Joins
'            Dim drToFloor3 As PSS.Data.Production.Joins
'            Dim drToFloorYTD As PSS.Data.Production.Joins

'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)
'            Dim dt1 As DataTable
'            Dim dt2 As DataTable
'            Dim dt3 As DataTable
'            Dim dtYTD As DataTable
'            Dim dtPName As DataTable
'            Dim dtToFloor As DataTable
'            Dim dtToFloor1 As DataTable
'            Dim dtToFloor2 As DataTable
'            Dim dtToFloor3 As DataTable
'            Dim dtToFloorYTD As DataTable

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            'oExcel = GetObject("r:\rptTemplate1.xls", "Excel.Application")
'            oBook = oExcel.workbooks.add
'            'oBook = oExcel.workbooks(1)
'            oSheet = oBook.worksheets(1)
'            'oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim xCount1 As Integer = 0
'            Dim r As DataRow
'            Dim r1 As DataRow
'            Dim r2 As DataRow
'            Dim r3 As DataRow
'            Dim rYTD As DataRow
'            Dim rPName As DataRow
'            Dim rToFloor As DataRow
'            Dim rToFloor1 As DataRow
'            Dim rToFloor2 As DataRow
'            Dim rToFloor3 As DataRow
'            Dim rToFloorYTD As DataRow

'            oSheet.range("A1").value() = "PSS Parts Billed/Issued Report"
'            oSheet.range("A2").value() = "Part Description"
'            'oSheet.columns("A").numberformat = "@"
'            oSheet.range("A2").columnwidth = 20
'            oSheet.range("B2").value() = "Part Number"
'            oSheet.range("B2").columnwidth = 20
'            'oSheet.range("C2").value() = "PN - SubSet"
'            'oSheet.range("C2").columnwidth = 0
'            'oSheet.range("D2").value() = "SubSet(PN)"
'            'oSheet.range("D2").columnwidth = 0

'            oSheet.range("E2").value() = ""
'            oSheet.range("E2").columnwidth = 1
'            oSheet.range("F2").value() = "Billed"
'            oSheet.range("F2").columnwidth = 8
'            oSheet.range("G1").value() = "WEEK " & weekNum1
'            oSheet.range("G2").value() = "To Floor"
'            oSheet.range("G2").columnwidth = 8
'            oSheet.range("H2").value() = "Diff."
'            oSheet.range("H2").columnwidth = 8
'            oSheet.range("I2").value() = "Avg Cost"
'            oSheet.range("I2").columnwidth = 8
'            oSheet.columns("I").numberformat = "0.00"

'            oSheet.range("J2").value() = ""
'            oSheet.range("J2").columnwidth = 1
'            oSheet.range("K2").value() = "Billed"
'            oSheet.range("K2").columnwidth = 8
'            oSheet.range("L1").value() = "WEEK " & weekNum2
'            oSheet.range("L2").value() = "To Floor"
'            oSheet.range("L2").columnwidth = 8
'            oSheet.range("M2").value() = "Diff."
'            oSheet.range("M2").columnwidth = 8
'            oSheet.range("N2").value() = "Avg Cost"
'            oSheet.range("N2").columnwidth = 8
'            oSheet.columns("N").numberformat = "0.00"

'            oSheet.range("O2").value() = ""
'            oSheet.range("O2").columnwidth = 1
'            oSheet.range("P2").value() = "Billed"
'            oSheet.range("P2").columnwidth = 8
'            oSheet.range("Q1").value() = "WEEK " & weekNum3
'            oSheet.range("Q2").value() = "To Floor"
'            oSheet.range("Q2").columnwidth = 8
'            oSheet.range("R2").value() = "Diff."
'            oSheet.range("R2").columnwidth = 8
'            oSheet.range("S2").value() = "Avg Cost"
'            oSheet.range("S2").columnwidth = 8
'            oSheet.columns("S").numberformat = "0.00"

'            oSheet.range("T2").value() = ""
'            oSheet.range("T2").columnwidth = 1
'            oSheet.range("U2").value() = "Billed"
'            oSheet.range("U2").columnwidth = 8
'            oSheet.range("V1").value() = "WEEK " & weekNum4
'            oSheet.range("V2").value() = "To Floor"
'            oSheet.range("V2").columnwidth = 8
'            oSheet.range("W2").value() = "Diff."
'            oSheet.range("W2").columnwidth = 8
'            oSheet.range("X2").value() = "Avg Cost"
'            oSheet.range("X2").columnwidth = 8
'            oSheet.columns("X").numberformat = "0.00"

'            oSheet.range("Y2").value() = ""
'            oSheet.range("Y2").columnwidth = 1
'            oSheet.range("Z2").value() = "Billed"
'            oSheet.range("Z2").columnwidth = 8
'            oSheet.range("AA1").value() = "YEAR TO DATE"
'            oSheet.range("AA2").value() = "To Floor"
'            oSheet.range("AA2").columnwidth = 8
'            oSheet.range("AB2").value() = "Diff."
'            oSheet.range("AB2").columnwidth = 8
'            oSheet.range("AC2").value() = "Avg Cost"
'            oSheet.range("AC2").columnwidth = 8
'            oSheet.columns("AC").numberformat = "0.00"


'            Dim sumToFloor As Integer = 0

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                '//Craig Haney December 10m 2004
'                'strSQL1 = "SELECT * FROM SUMPARTS WHERE part_number = '" & r(0) & "' order by part_desc"
'                'strSQL1 = "SELECT * FROM lpsprice WHERE PSPrice_number = '" & r(0) & "' order by PSPrice_desc"
'                'dt1 = dr1.OrderEntrySelect(strSQL1)

'                Try
'                    '//Craig Haney December 10m 2004
'                    'rPName = r("parts_desc")
'                    'oSheet.range(CStr("A" & xCount + defaultAdd + 3)).value = rPName(0)
'                    oSheet.range(CStr("A" & xCount + defaultAdd + 3)).value = r("parts_desc")

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select dpart_avgcost from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("I" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try


'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range2Start & "' and dpart_date < '" & range2End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("L" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range2Start & "' and dpart_date < '" & range2End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("N" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range3Start & "' and dpart_date < '" & range3End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("Q" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range3Start & "' and dpart_date < '" & range3End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("S" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range4Start & "' and dpart_date < '" & range4End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("V" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range4Start & "' and dpart_date < '" & range4End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("X" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        'dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & rangeYTDStart & "' and dpart_date < '" & rangeYTDEnd & "' group by dpart_number")
'                        dtToFloor = drToFloor.OrderEntrySelect("select spytd_itemcount from sumdpartsytd inner join sumpartsnumbers on sumdpartsytd.billcode_id = sumpartsnumbers.billcode_id and sumdpartsytd.model_id = sumpartsnumbers.model_id where parts_number = '" & r(0) & "'")
'                        rToFloor = dtToFloor.Rows(0)
'                        If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("AA" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & rangeYTDStart & "' and dpart_date < '" & rangeYTDEnd & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("AC" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try



'                    'End If

'                    Try
'                        For CountWeek1 = 0 To dtWeek1.Rows.Count - 1
'                            rWeek1 = dtWeek1.Rows(CountWeek1)
'                            If Trim(rWeek1(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value = rWeek1(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek2 = 0 To dtWeek2.Rows.Count - 1
'                            rWeek2 = dtWeek2.Rows(CountWeek2)
'                            If Trim(rWeek2(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("K" & xCount + defaultAdd + 3)).value = rWeek2(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek3 = 0 To dtWeek3.Rows.Count - 1
'                            rWeek3 = dtWeek3.Rows(CountWeek3)
'                            If Trim(rWeek3(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("P" & xCount + defaultAdd + 3)).value = rWeek3(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek4 = 0 To dtWeek4.Rows.Count - 1
'                            rWeek4 = dtWeek4.Rows(CountWeek4)
'                            If Trim(rWeek4(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("U" & xCount + defaultAdd + 3)).value = rWeek4(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeekYTD = 0 To dtWeekYTD.Rows.Count - 1
'                            rWeekYTD = dtWeekYTD.Rows(CountWeekYTD)
'                            If Trim(rWeekYTD(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("Z" & xCount + defaultAdd + 3)).value = rWeekYTD(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try


'                Catch ex As Exception
'                End Try


'                '//Assign Difference
'                'If dt1.Rows.Count < 2 Then
'                Try
'                    oSheet.range(CStr("H" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value
'                Catch ex As Exception
'                End Try

'                Try
'                    oSheet.range(CStr("M" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("K" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("L" & xCount + defaultAdd + 3)).value
'                Catch ex As Exception
'                End Try

'                Try
'                    oSheet.range(CStr("Q" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("R" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("P" & xCount + defaultAdd + 3)).value
'                Catch ex As Exception
'                End Try

'                Try
'                    oSheet.range(CStr("V" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("W" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("U" & xCount + defaultAdd + 3)).value
'                Catch ex As Exception
'                End Try

'                Try
'                    oSheet.range(CStr("AB" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("AA" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("Z" & xCount + defaultAdd + 3)).value
'                Catch ex As Exception
'                End Try

'                'End If

'                oSheet.range(CStr("B" & xCount + defaultAdd + 3)).value = r(0)
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\cdhtest.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\cdhtest.xls")
'            showXL.Visible = True



'        End Sub


'        Private Sub ckCompanyALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            If ckCompanyALL.Checked = True Then
'                cboCompany.Enabled = False
'                lblCompany.Enabled = False
'            Else
'                cboCompany.Enabled = True
'                lblCompany.Enabled = True
'            End If

'        End Sub

'        Private Sub ckModelALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            If ckModelALL.Checked = True Then
'                cboModel.Enabled = False
'                lblModel.Enabled = False
'            Else
'                cboModel.Enabled = True
'                lblModel.Enabled = True
'            End If

'        End Sub

'        Private Sub btnAUPreport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAUPreport.Click

'            If ckCompanyALL.Checked = False Then
'                If Trim(cboCompany.Text) = "" Then
'                    MsgBox("A Company must be selected before continuing.", MsgBoxStyle.OKOnly)
'                    cboCompany.Focus()
'                    Exit Sub
'                End If
'            End If

'            If ckModelALL.Checked = False Then
'                If Trim(cboModel.Text) = "" Then
'                    MsgBox("A Model must be selected before continuing.", MsgBoxStyle.OKOnly)
'                    cboModel.Focus()
'                    Exit Sub
'                End If
'            End If

'            Dim currentRow As Integer = 4

'            Dim objXL As Object

'            'Dim oBook As EXCEL.WORKBOOK
'            'Dim oSheet As Excel.Worksheet
'            Dim oSheet As Object

'            '//Define the date values for the report
'            Dim dteStart As String = Me.calStart.Text
'            Dim dteEnd As String = Me.calEnd.Text
'            Dim dteFstart As String = Gui.Receiving.FormatDateShort(dteStart) & " 00:00:00"
'            Dim dteFend As String = Gui.Receiving.FormatDateShort(dteEnd) & " 23:59:59"

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")

'            objXL.Workbooks.Open("r:\Template_Report3.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0.00"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("J").NumberFormat = "0.00"
'            oSheet.Columns("L").NumberFormat = "0.00"
'            oSheet.Columns("M").NumberFormat = "0.00"
'            oSheet.Columns("N").NumberFormat = "0.00"
'            oSheet.Columns("O").NumberFormat = "0.00"

'            oSheet.Columns("N").columnwidth = 0
'            oSheet.Columns("O").columnwidth = 0

'            oSheet.Columns("Q").NumberFormat = "0.00"
'            oSheet.Columns("S").NumberFormat = "0.00"
'            oSheet.Columns("T").NumberFormat = "0.00"
'            oSheet.Columns("U").NumberFormat = "0.00"
'            oSheet.Columns("V").NumberFormat = "0.00"
'            oSheet.Columns("W").NumberFormat = "0.00"
'            oSheet.Columns("X").NumberFormat = "0.00"

'            oSheet.Columns("Z").NumberFormat = "0.00"

'            '//Set title of form
'            oSheet.Range("A1").Value = "AUP Report from " & dteStart & " to " & dteEnd

'            '//Define the SQL statement for data selection
'            Dim strSQL_ALL_DATA_PARTS As String = "select Cust_Name1, Cust_Name2, Model_Desc, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost from " & _
'                                                  "((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc"
'            Dim strSQL_ALL_DATA_LABOR As String = "select Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(Device_SN) as DeviceCount from " & _
'                                                  "(((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc"

'            Dim strSQL_DBR_DATA_LABOR As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(tdevice.Device_SN) as DeviceCount from " & _
'                                                  "(((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'                                                  "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "and lbillcodes.billcode_rule in (1,2) " & _
'                                                  "group by cust_name1, model_desc "

'            'Dim strSQL_DBR_DATA_LABOR As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(tdevice.Device_SN) as DeviceCount from " & _
'            '                                      "((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'            '                                      "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'            '                                      "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'            '                                      "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            '                                      "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'            '                                      "and tdevice.device_dateship <= '" & dteFend & "' " & _
'            '                                      "and tdevicebill.billcode_id=25 " & _
'            '                                      "group by cust_name1, model_desc "




'            Dim objConn As PSS.Data.Production.Joins
'            Dim dtALLPARTS As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS)
'            Dim dtALLLABOR As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_LABOR)
'            Dim dtDBRLABOR As DataTable = objConn.OrderEntrySelect(strSQL_DBR_DATA_LABOR)

'            Dim rAllParts As DataRow
'            Dim rAllLabor As DataRow
'            Dim rDbrLabor As DataRow

'            Dim xAllParts As Integer = 0
'            Dim xAllLabor As Integer = 0
'            Dim xDbrLabor As Integer = 0

'            Dim vLaborAll As Double = 0.0

'            'Start load of data
'            For xAllLabor = 0 To dtALLLABOR.Rows.Count - 1

'                rAllLabor = dtALLLABOR.Rows(xAllLabor)

'                If ckCompanyALL.Checked = False Then
'                    If Trim(rAllLabor("Cust_Name1")) <> Trim(cboCompany.Text) Then
'                        GoTo company_force_next
'                    End If
'                End If

'                If ckModelALL.Checked = False Then
'                    If Trim(rAllLabor("Model_Desc")) <> Trim(cboModel.Text) Then
'                        GoTo company_force_next
'                    End If
'                End If

'                '//Place Customer Name
'                oSheet.Range(CStr("A" & currentRow)).Value = rAllLabor("Cust_name1") & " " & rAllLabor("cust_Name2")

'                '//Place Model Name
'                oSheet.Range(CStr("B" & currentRow)).Value = rAllLabor("Model_Desc")

'                '//Place Labor Amount - ALL
'                If IsDBNull(rAllLabor("LaborAmt")) = False Then
'                    oSheet.Range(CStr("S" & currentRow)).Value = rAllLabor("LaborAmt")
'                Else
'                    oSheet.Range(CStr("S" & currentRow)).Value = "0.00"
'                End If

'                '//Place Device Count - ALL
'                If IsDBNull(rAllLabor("DeviceCount")) = False Then
'                    oSheet.Range(CStr("Y" & currentRow)).Value = rAllLabor("DeviceCount").ToString
'                Else
'                    oSheet.Range(CStr("Y" & currentRow)).Value = "0"
'                End If


'                '//Second loop to acquire parts amount same device
'                For xAllParts = 0 To dtALLPARTS.Rows.Count - 1
'                    rAllParts = dtALLPARTS.Rows(xAllParts)

'                    If Trim(rAllLabor("Cust_Name1")) = Trim(rAllParts("Cust_Name1")) Then
'                        If Trim(rAllLabor("Model_Desc")) = Trim(rAllParts("Model_Desc")) Then
'                            '//Assign parts amount to XL sheet

'                            If IsDBNull(rAllParts("PartAmtCost")) = False Then


'                                MsgBox(rAllParts("PartAmtCost").ToString)
'                                oSheet.Range(CStr("W" & currentRow)).Value = rAllParts("PartAmtCost").ToString
'                                oSheet.Range(CStr("G" & currentRow)).Value = rAllParts("PartAmtCost").ToString
'                            Else
'                                oSheet.Range(CStr("W" & currentRow)).Value = "0"
'                                oSheet.Range(CStr("G" & currentRow)).Value = "0"
'                            End If

'                            If IsDBNull(rAllParts("PartAmt")) = False Then
'                                oSheet.Range(CStr("U" & currentRow)).Value = rAllParts("PartAmt").ToString
'                                Exit For
'                            Else
'                                oSheet.Range(CStr("U" & currentRow)).Value = "0"
'                                Exit For
'                            End If
'                        End If
'                    End If
'                Next

'                '//Default assignment for DBR data in case DBR record does not exists
'                oSheet.Range(CStr("L" & currentRow)).Value = "0"
'                oSheet.Range(CStr("P" & currentRow)).Value = "0"

'                '//Third loop to acquire DBR labor amount same device
'                For xDbrLabor = 0 To dtDBRLABOR.Rows.Count - 1
'                    rDbrLabor = dtDBRLABOR.Rows(xDbrLabor)

'                    If Trim(rAllLabor("Cust_Name1")) = Trim(rDbrLabor("Cust_Name1")) Then
'                        If Trim(rAllLabor("Model_Desc")) = Trim(rDbrLabor("Model_Desc")) Then
'                            '//Place Device Count - DBR
'                            If IsDBNull(rDbrLabor("DeviceCount")) = False Then
'                                oSheet.Range(CStr("P" & currentRow)).Value = rDbrLabor("DeviceCount").ToString
'                            Else
'                                oSheet.Range(CStr("P" & currentRow)).Value = "0"
'                            End If

'                            '//Assign DBR labor amount to XL sheet
'                            If IsDBNull(rDbrLabor("LaborAmt")) = False Then
'                                oSheet.Range(CStr("L" & currentRow)).Value = rDbrLabor("LaborAmt").ToString
'                                Exit For
'                            Else
'                                oSheet.Range(CStr("L" & currentRow)).Value = "0"
'                                Exit For
'                            End If

'                        End If
'                    End If
'                Next
'                '//Set the part amount to 0 for the DBR Section
'                oSheet.Range(CStr("N" & currentRow)).Value = "0"

'                'AUP Cost ALL
'                oSheet.Range(CStr("X" & currentRow)).Value = oSheet.Range(CStr("W" & currentRow)).Value / oSheet.Range(CStr("Y" & currentRow)).Value

'                'Total Revenue - ALL
'                oSheet.Range(CStr("Z" & currentRow)).Value = oSheet.Range(CStr("U" & currentRow)).Value + oSheet.Range(CStr("S" & currentRow)).Value
'                'Total Revenue - DBR
'                oSheet.Range(CStr("Q" & currentRow)).Value = oSheet.Range(CStr("N" & currentRow)).Value + oSheet.Range(CStr("L" & currentRow)).Value
'                'Total PARTS - Repaired
'                oSheet.Range(CStr("E" & currentRow)).Value = oSheet.Range(CStr("U" & currentRow)).Value - oSheet.Range(CStr("N" & currentRow)).Value
'                'Total LABOR - Repaired
'                oSheet.Range(CStr("C" & currentRow)).Value = oSheet.Range(CStr("S" & currentRow)).Value - oSheet.Range(CStr("L" & currentRow)).Value
'                'Total Revenue - Repaired
'                oSheet.Range(CStr("J" & currentRow)).Value = oSheet.Range(CStr("C" & currentRow)).Value + oSheet.Range(CStr("E" & currentRow)).Value

'                oSheet.Range(CStr("O" & currentRow)).Value = 0
'                oSheet.Range(CStr("M" & currentRow)).Value = 0

'                '//AUP Labor DBR
'                If oSheet.Range(CStr("P" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("M" & currentRow)).Value = oSheet.Range(CStr("L" & currentRow)).Value / oSheet.Range(CStr("P" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("M" & currentRow)).Value = 0
'                End If

'                '//AUP Labor ALL
'                If oSheet.Range(CStr("Y" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("T" & currentRow)).Value = oSheet.Range(CStr("S" & currentRow)).Value / oSheet.Range(CStr("Y" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("T" & currentRow)).Value = 0
'                End If

'                '//AUP Parts DBR
'                If oSheet.Range(CStr("P" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("O" & currentRow)).Value = oSheet.Range(CStr("N" & currentRow)).Value / oSheet.Range(CStr("P" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("O" & currentRow)).Value = 0
'                End If

'                '//AUP Parts ALL
'                If oSheet.Range(CStr("Y" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("V" & currentRow)).Value = oSheet.Range(CStr("U" & currentRow)).Value / oSheet.Range(CStr("Y" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("V" & currentRow)).Value = 0
'                End If

'                'Shipped - Repaired
'                oSheet.Range(CStr("I" & currentRow)).Value = oSheet.Range(CStr("Y" & currentRow)).Value - oSheet.Range(CStr("P" & currentRow)).Value
'                'oSheet.Range(CStr("I" & currentRow)).Value = oSheet.Range(CStr("Y" & currentRow)).Value

'                '//AUP Labor Repaired
'                If oSheet.Range(CStr("I" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("D" & currentRow)).Value = oSheet.Range(CStr("C" & currentRow)).Value / oSheet.Range(CStr("I" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("D" & currentRow)).Value = 0
'                End If

'                '//AUP Parts Repaired
'                If oSheet.Range(CStr("I" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("F" & currentRow)).Value = oSheet.Range(CStr("E" & currentRow)).Value / oSheet.Range(CStr("I" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("F" & currentRow)).Value = 0
'                End If

'                'AUP Cost Repair
'                If oSheet.Range(CStr("I" & currentRow)).Value > 0 Then
'                    oSheet.Range(CStr("H" & currentRow)).Value = oSheet.Range(CStr("G" & currentRow)).Value / oSheet.Range(CStr("I" & currentRow)).Value
'                Else
'                    oSheet.Range(CStr("H" & currentRow)).Value = 0
'                End If


'                currentRow += 1

'model_force_next:
'company_force_next:
'            Next

'            oSheet.PageSetup.PrintArea = "$A$1:$Z$" & currentRow

'            objXL.Visible = True

'            objXL = Nothing

'        End Sub


'        'Private Sub ckCompanyALL_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCompanyALL.CheckedChanged

'        'If ckCompanyALL.Checked = True Then
'        '    cboCompany.Enabled = False
'        '    lblCompany.Enabled = False
'        'Else
'        '    cboCompany.Enabled = True
'        '    lblCompany.Enabled = True
'        'End If

'        'End Sub

'        Private Sub ckModelALL_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckModelALL.CheckedChanged

'            If ckModelALL.Checked = True Then
'                cboModel.Enabled = False
'                lblModel.Enabled = False
'            Else
'                cboModel.Enabled = True
'                lblModel.Enabled = True
'            End If

'        End Sub

'        Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        End Sub

'        Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

'            Dim range1Start As String = "2005-10-03"
'            Dim range1End As String = "2005-10-10"
'            Dim range2Start As String = "2005-09-26"
'            Dim range2End As String = "2005-10-02"
'            Dim range3Start As String = "2005-09-19"
'            Dim range3End As String = "2005-09-25"
'            Dim range4Start As String = "2005-09-12"
'            Dim range4End As String = "2005-09-18"
'            Dim rangeYTDStart As String = "2005-04-09"
'            Dim rangeYTDEnd As String = "2005-04-09"

'            'Dim range1Start As String = "2005-02-13"
'            'Dim range1End As String = "2005-02-19"
'            'Dim range2Start As String = "2005-02-06"
'            'Dim range2End As String = "2005-02-12"
'            'Dim range3Start As String = "2005-01-30"
'            'Dim range3End As String = "2005-02-05"
'            'Dim range4Start As String = "2005-01-23"
'            'Dim range4End As String = "2005-01-29"
'            'Dim rangeYTDStart As String = "2004-04-01"
'            'Dim rangeYTDEnd As String = "2005-02-21"

'            'Dim range1Start As String = "2005-01-23"
'            'Dim range1End As String = "2005-01-29"
'            'Dim range2Start As String = "2005-01-29"
'            'Dim range2End As String = "2005-01-29"
'            'Dim range3Start As String = "2005-01-29"
'            'Dim range3End As String = "2005-01-29"
'            'Dim range4Start As String = "2005-01-29"
'            'Dim range4End As String = "2005-01-29"
'            'Dim rangeYTDStart As String = "2005-01-29"
'            'Dim rangeYTDEnd As String = "2005-01-29"


'            Dim strWeek1 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range1Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range1End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim strWeek2 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range2Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range2End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim strWeek3 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range3Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range3End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"
'            Dim strWeek4 As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & range4Start & "' " & _
'                                        "and tdevice.device_datebill < '" & range4End & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"

'            Dim strWeekYTD As String = "select distinct lpsprice.psprice_number, count(lpsprice.psprice_number) as countBilled from " & _
'                                        "(((tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id) " & _
'                                        "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
'                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id) " & _
'                                        "where tdevice.device_datebill > '" & rangeYTDStart & "' " & _
'                                        "and tdevice.device_datebill < '" & rangeYTDEnd & "' " & _
'                                        "group by lpsprice.psprice_number " & _
'                                        "order by lpsprice.psprice_number"

'            'Dim strWeekYTD As String = "SELECT spytd_number as psprice_number , spytd_count as countBilled  FROM sumdpartsYTD"


'            Dim drWeek1 As PSS.Data.Production.Joins
'            Dim dtWeek1 As DataTable = drWeek1.OrderEntrySelect(strWeek1)
'            Dim CountWeek1 As Integer = 0
'            Dim rWeek1 As DataRow

'            Dim drWeek2 As PSS.Data.Production.Joins
'            Dim dtWeek2 As DataTable = drWeek2.OrderEntrySelect(strWeek2)
'            Dim CountWeek2 As Integer = 0
'            Dim rWeek2 As DataRow

'            Dim drWeek3 As PSS.Data.Production.Joins
'            Dim dtWeek3 As DataTable = drWeek3.OrderEntrySelect(strWeek3)
'            Dim CountWeek3 As Integer = 0
'            Dim rWeek3 As DataRow

'            Dim drWeek4 As PSS.Data.Production.Joins
'            Dim dtWeek4 As DataTable = drWeek4.OrderEntrySelect(strWeek4)
'            Dim CountWeek4 As Integer = 0
'            Dim rWeek4 As DataRow

'            Dim drWeekYTD As PSS.Data.Production.Joins
'            Dim dtWeekYTD As DataTable = drWeekYTD.OrderEntrySelect(strWeekYTD)
'            Dim CountWeekYTD As Integer = 0
'            Dim rWeekYTD As DataRow

'            Dim strSQL, strSQL1 As String
'            Dim defaultAdd As Integer = 0

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

'            '//First group is to get parts issued to floor
'            '            strSQL = "select distinct part_number from sumparts order by part_desc"
'            'strSQL = "select distinct spytd_number as part_number from sumdpartsytd order by spytd_number"
'            'strSQL = "select distinct spytd_number as part_number from sumdpartsytd inner join lpsprice on sumdpartsytd.spytd_number = lpsprice.psprice_number order by psprice_Desc"


'            strSQL = "select distinct parts_number as part_number from ((sumpartsnumbers inner join lpsprice on sumpartsnumbers.parts_number = lpsprice.psprice_number) inner join tpsmap on lpsprice.psprice_id = tpsmap.psprice_id) where tpsmap.prod_id=1 order by psprice_Desc"


'            Dim dr As PSS.Data.Production.Joins
'            Dim dr1 As PSS.Data.Production.Joins
'            Dim dr2 As PSS.Data.Production.Joins
'            Dim dr3 As PSS.Data.Production.Joins
'            Dim drYTD As PSS.Data.Production.Joins
'            Dim drPName As PSS.Data.Production.Joins
'            Dim drToFloor As PSS.Data.Production.Joins
'            Dim drToFloor1 As PSS.Data.Production.Joins
'            Dim drToFloor2 As PSS.Data.Production.Joins
'            Dim drToFloor3 As PSS.Data.Production.Joins
'            Dim drToFloorYTD As PSS.Data.Production.Joins

'            Dim dt As DataTable = dr.OrderEntrySelect(strSQL)
'            Dim dt1 As DataTable
'            Dim dt2 As DataTable
'            Dim dt3 As DataTable
'            Dim dtYTD As DataTable
'            Dim dtPName As DataTable
'            Dim dtToFloor As DataTable
'            Dim dtToFloor1 As DataTable
'            Dim dtToFloor2 As DataTable
'            Dim dtToFloor3 As DataTable
'            Dim dtToFloorYTD As DataTable

'            Dim oExcel As Object
'            Dim oBook As Object
'            Dim oSheet As Object
'            oExcel = CreateObject("Excel.Application")
'            'oExcel = GetObject("r:\rptTemplate1.xls", "Excel.Application")
'            oBook = oExcel.workbooks.add
'            'oBook = oExcel.workbooks(1)
'            oSheet = oBook.worksheets(1)
'            'oSheet = oBook.worksheets(1)

'            Dim xCount As Integer = 0
'            Dim xCount1 As Integer = 0
'            Dim r As DataRow
'            Dim r1 As DataRow
'            Dim r2 As DataRow
'            Dim r3 As DataRow
'            Dim rYTD As DataRow
'            Dim rPName As DataRow
'            Dim rToFloor As DataRow
'            Dim rToFloor1 As DataRow
'            Dim rToFloor2 As DataRow
'            Dim rToFloor3 As DataRow
'            Dim rToFloorYTD As DataRow

'            oSheet.range("A1").value() = "PSS Parts Billed/Issued Report"
'            oSheet.range("A2").value() = "Part Description"
'            'oSheet.columns("A").numberformat = "@"
'            oSheet.range("A2").columnwidth = 20
'            oSheet.range("B2").value() = "Part Number"
'            oSheet.range("B2").columnwidth = 20
'            'oSheet.range("C2").value() = "PN - SubSet"
'            'oSheet.range("C2").columnwidth = 0
'            'oSheet.range("D2").value() = "SubSet(PN)"
'            'oSheet.range("D2").columnwidth = 0

'            oSheet.range("E2").value() = ""
'            oSheet.range("E2").columnwidth = 1
'            oSheet.range("F2").value() = "Billed"
'            oSheet.range("F2").columnwidth = 8
'            oSheet.range("G1").value() = "WEEK 13"
'            oSheet.range("G2").value() = "To Floor"
'            oSheet.range("G2").columnwidth = 8
'            oSheet.range("H2").value() = "Diff."
'            oSheet.range("H2").columnwidth = 8
'            oSheet.range("I2").value() = "Avg Cost"
'            oSheet.range("I2").columnwidth = 8
'            oSheet.columns("I").numberformat = "0.00"

'            oSheet.range("J2").value() = ""
'            oSheet.range("J2").columnwidth = 1
'            oSheet.range("K2").value() = "Billed"
'            oSheet.range("K2").columnwidth = 8
'            oSheet.range("L1").value() = "WEEK 12"
'            oSheet.range("L2").value() = "To Floor"
'            oSheet.range("L2").columnwidth = 8
'            oSheet.range("M2").value() = "Diff."
'            oSheet.range("M2").columnwidth = 8
'            oSheet.range("N2").value() = "Avg Cost"
'            oSheet.range("N2").columnwidth = 8
'            oSheet.columns("N").numberformat = "0.00"

'            oSheet.range("O2").value() = ""
'            oSheet.range("O2").columnwidth = 1
'            oSheet.range("P2").value() = "Billed"
'            oSheet.range("P2").columnwidth = 8
'            oSheet.range("Q1").value() = "WEEK unused"
'            oSheet.range("Q2").value() = "To Floor"
'            oSheet.range("Q2").columnwidth = 8
'            oSheet.range("R2").value() = "Diff."
'            oSheet.range("R2").columnwidth = 8
'            oSheet.range("S2").value() = "Avg Cost"
'            oSheet.range("S2").columnwidth = 8
'            oSheet.columns("S").numberformat = "0.00"

'            oSheet.range("T2").value() = ""
'            oSheet.range("T2").columnwidth = 1
'            oSheet.range("U2").value() = "Billed"
'            oSheet.range("U2").columnwidth = 8
'            oSheet.range("V1").value() = "WEEK unused"
'            oSheet.range("V2").value() = "To Floor"
'            oSheet.range("V2").columnwidth = 8
'            oSheet.range("W2").value() = "Diff."
'            oSheet.range("W2").columnwidth = 8
'            oSheet.range("X2").value() = "Avg Cost"
'            oSheet.range("X2").columnwidth = 8
'            oSheet.columns("X").numberformat = "0.00"

'            oSheet.range("Y2").value() = ""
'            oSheet.range("Y2").columnwidth = 1
'            oSheet.range("Z2").value() = "Billed"
'            oSheet.range("Z2").columnwidth = 8
'            oSheet.range("AA1").value() = "YEAR TO DATE"
'            oSheet.range("AA2").value() = "To Floor"
'            oSheet.range("AA2").columnwidth = 8
'            oSheet.range("AB2").value() = "Diff."
'            oSheet.range("AB2").columnwidth = 8
'            oSheet.range("AC2").value() = "Avg Cost"
'            oSheet.range("AC2").columnwidth = 8
'            oSheet.columns("AC").numberformat = "0.00"


'            Dim sumToFloor As Integer = 0

'            For xCount = 0 To dt.Rows.Count - 1
'                r = dt.Rows(xCount)
'                '//Craig Haney December 10m 2004
'                'strSQL1 = "SELECT * FROM SUMPARTS WHERE part_number = '" & r(0) & "' order by part_desc"
'                strSQL1 = "SELECT * FROM lpsprice WHERE PSPrice_number = '" & r(0) & "' order by PSPrice_desc"


'                dt1 = dr1.OrderEntrySelect(strSQL1)

'                Try
'                    '//Craig Haney December 10m 2004
'                    'dtPName = drPName.OrderEntrySelect("SELECT Part_Desc FROM sumparts WHERE part_number = '" & r(0) & "'")
'                    dtPName = drPName.OrderEntrySelect("SELECT PSPrice_Desc FROM lpsprice WHERE PSPrice_number = '" & r(0) & "'")

'                    rPName = dtPName.Rows(0)
'                    oSheet.range(CStr("A" & xCount + defaultAdd + 3)).value = rPName(0)
'                    'If dt1.Rows.Count > 1 Then
'                    'If sumToFloor < 1 Then sumToFloor = 0
'                    'oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = sumToFloor
'                    'Else


'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select dpart_avgcost from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range1Start & "' and dpart_date < '" & range1End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("I" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try


'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range2Start & "' and dpart_date < '" & range2End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("L" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range2Start & "' and dpart_date < '" & range2End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("N" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range3Start & "' and dpart_date < '" & range3End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("Q" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range3Start & "' and dpart_date < '" & range3End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("S" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range4Start & "' and dpart_date < '" & range4End & "' group by dpart_number")
'                        rToFloor = dtToFloor.Rows(0)
'                        'If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("V" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & range4Start & "' and dpart_date < '" & range4End & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("X" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try

'                    Try
'                        dtToFloor = drToFloor.OrderEntrySelect("select sum(dpart_count), max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & rangeYTDStart & "' and dpart_date < '" & rangeYTDEnd & "' group by dpart_number")
'                        'dtToFloor = drToFloor.OrderEntrySelect("select spytd_count, spytd_avgcost from sumdpartsytd where spYTD_number = '" & r(0) & "'")
'                        rToFloor = dtToFloor.Rows(0)
'                        If rToFloor(0) < 1 Then rToFloor(0) = 0
'                        oSheet.range(CStr("AA" & xCount + defaultAdd + 3)).value = rToFloor(0)
'                    Catch ex As Exception
'                    End Try
'                    Try
'                        dtToFloor1 = drToFloor1.OrderEntrySelect("select max(dpart_avgcost) from sumdparts where dpart_number = '" & r(0) & "' and dpart_date > '" & rangeYTDStart & "' and dpart_date < '" & rangeYTDEnd & "' and dpart_count > 0 group by dpart_number")
'                        rToFloor1 = dtToFloor1.Rows(0)
'                        oSheet.range(CStr("AC" & xCount + defaultAdd + 3)).value = rToFloor1(0)
'                    Catch EX As Exception
'                    End Try



'                    'End If

'                    Try
'                        For CountWeek1 = 0 To dtWeek1.Rows.Count - 1
'                            rWeek1 = dtWeek1.Rows(CountWeek1)
'                            If Trim(rWeek1(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value = rWeek1(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek2 = 0 To dtWeek2.Rows.Count - 1
'                            rWeek2 = dtWeek2.Rows(CountWeek2)
'                            If Trim(rWeek2(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("K" & xCount + defaultAdd + 3)).value = rWeek2(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek3 = 0 To dtWeek3.Rows.Count - 1
'                            rWeek3 = dtWeek3.Rows(CountWeek3)
'                            If Trim(rWeek3(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("P" & xCount + defaultAdd + 3)).value = rWeek3(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeek4 = 0 To dtWeek4.Rows.Count - 1
'                            rWeek4 = dtWeek4.Rows(CountWeek4)
'                            If Trim(rWeek4(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("U" & xCount + defaultAdd + 3)).value = rWeek4(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try

'                    Try
'                        For CountWeekYTD = 0 To dtWeekYTD.Rows.Count - 1
'                            rWeekYTD = dtWeekYTD.Rows(CountWeekYTD)
'                            If Trim(rWeekYTD(0).ToString) = Trim(r(0).ToString) Then
'                                oSheet.range(CStr("Z" & xCount + defaultAdd + 3)).value = rWeekYTD(1).ToString
'                                Exit For
'                            End If
'                        Next
'                    Catch ex As Exception
'                        MsgBox(ex)
'                    End Try


'                Catch ex As Exception
'                End Try


'                '//Assign Difference
'                If dt1.Rows.Count < 2 Then
'                    Try
'                        oSheet.range(CStr("H" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("F" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("G" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("M" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("K" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("L" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("Q" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("R" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("P" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("V" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("W" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("U" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                    Try
'                        oSheet.range(CStr("AB" & xCount + defaultAdd + 3)).value = oSheet.range(CStr("AA" & xCount + defaultAdd + 3)).value - oSheet.range(CStr("Z" & xCount + defaultAdd + 3)).value
'                    Catch ex As Exception
'                    End Try

'                End If

'                oSheet.range(CStr("B" & xCount + defaultAdd + 3)).value = r(0)
'            Next

'            Cursor.Current = System.Windows.Forms.Cursors.Default

'            oBook.saveas("r:\cdhtest1.xls")

'            oBook.close()
'            oExcel.quit()

'            oSheet = Nothing
'            oBook = Nothing
'            oExcel = Nothing

'            System.Windows.Forms.Application.DoEvents()

'            Dim showXL As Object
'            showXL = CreateObject("Excel.Application")
'            showXL.Workbooks.Open("r:\cdhtest1.xls")
'            showXL.Visible = True


'        End Sub

'        Private Sub btnATCLEdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnATCLEdata.Click

'            Dim today As String = Gui.Receiving.General.FormatDateShort(Now)
'            Dim startToday As String = today & " 00:00:00"
'            Dim endToday As String = today & " 23:59:59"

'            Dim ds As PSS.Data.Production.Joins
'            Dim dt As DataTable
'            Dim strSQL As String
'            Dim strMessage As String
'            Dim r As DataRow


'            'Count of Testing
'            strSQL = "select count(billcode_id) as dtValue from " & _
'            "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & " ' " & _
'            "and tdevicebill.billcode_id = 448 " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of Testing: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of Flash/Programming
'            strSQL = "select count(billcode_id) as dtValue from " & _
'            "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & " ' " & _
'            "and tdevicebill.billcode_id = 442 " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of Flash/Programming: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of Cosmetic
'            strSQL = "select count(billcode_id) as dtValue from " & _
'            "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & " ' " & _
'            "and tdevicebill.billcode_id = 446 " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of Cosmetic: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of Polish and Buff
'            strSQL = "select count(billcode_id) as dtValue from " & _
'            "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & " ' " & _
'            "and tdevicebill.billcode_id = 447 " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of Polish and Buff: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of Parts
'            strSQL = "select count(billcode_rule) as dtValue from " & _
'            "((tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & "' " & _
'            "and lbillcodes.billcode_rule=0 " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of Parts: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of Devices with Parts added
'            strSQL = "select count(distinct device_sn) as dtValue from " & _
'            "((tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & "' " & _
'            "and lbillcodes.billcode_rule=0 " & _
'            "and loc_id = 2540 " & _
'            "order by device_sn"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of Devices with Parts added: " & r(0) & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of RUR
'            strSQL = "select count(loc_id) as dtValue from " & _
'            "((tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & "' " & _
'            "and lbillcodes.billcode_rule in (1,2,9) " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of RUR: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            'Count of RTM
'            strSQL = "select count(billcode_id) as dtValue from " & _
'            "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "where tdevice.device_dateship > '" & startToday & "' and " & _
'            "tdevice.device_dateship < '" & endToday & "' " & _
'            "and tdevicebill.billcode_id = 466 " & _
'            "and loc_id = 2540"
'            dt = ds.OrderEntrySelect(strSQL)
'            r = dt.Rows(0)
'            System.Windows.Forms.Application.DoEvents()
'            strMessage += "Count of RTM: " & r("dtValue") & vbCrLf
'            System.Windows.Forms.Application.DoEvents()

'            MsgBox("The counts for " & today & " are as follows:" & vbCrLf & vbCrLf & strMessage, MsgBoxStyle.OKOnly, "Results")






'        End Sub

'        Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

'            If ckCompanyALL.Checked = False Then
'                If Trim(cboCompany.Text) = "" Then
'                    MsgBox("A Company must be selected before continuing.", MsgBoxStyle.OKOnly)
'                    cboCompany.Focus()
'                    Exit Sub
'                End If
'            End If

'            If ckModelALL.Checked = False Then
'                If Trim(cboModel.Text) = "" Then
'                    MsgBox("A Model must be selected before continuing.", MsgBoxStyle.OKOnly)
'                    cboModel.Focus()
'                    Exit Sub
'                End If
'            End If

'            Dim currentRow As Integer = 4

'            Dim objXL As Object

'            'Dim oBook As EXCEL.WORKBOOK
'            'Dim oSheet As Excel.Worksheet
'            Dim oSheet As Object

'            Dim modelCount As Integer = 0
'            Dim staticRow As Integer

'            '//Define the date values for the report
'            Dim dteStart As String = Me.calStart.Text
'            Dim dteEnd As String = Me.calEnd.Text
'            Dim dteFstart As String = Gui.Receiving.FormatDateShort(dteStart) & " 00:00:00"
'            Dim dteFend As String = Gui.Receiving.FormatDateShort(dteEnd) & " 23:59:59"

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")

'            objXL.Workbooks.Open("r:\Template_Report3PartDetail.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("B").NumberFormat = "@"
'            'oSheet.Columns("C").NumberFormat = "0.00"
'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("J").NumberFormat = "0.00"
'            oSheet.Columns("L").NumberFormat = "0.00"
'            oSheet.Columns("M").NumberFormat = "0.00"
'            oSheet.Columns("N").NumberFormat = "0.00"
'            oSheet.Columns("O").NumberFormat = "0.00"

'            oSheet.Columns("F").columnwidth = 0
'            oSheet.Columns("N").columnwidth = 0
'            oSheet.Columns("O").columnwidth = 0

'            oSheet.Columns("Q").NumberFormat = "0.00"
'            oSheet.Columns("S").NumberFormat = "0.00"
'            oSheet.Columns("T").NumberFormat = "0.00"
'            oSheet.Columns("U").NumberFormat = "0.00"
'            oSheet.Columns("V").NumberFormat = "0.00"
'            oSheet.Columns("W").NumberFormat = "0.00"
'            oSheet.Columns("X").NumberFormat = "0.00"

'            oSheet.Columns("Z").NumberFormat = "0.00"

'            '//Set title of form
'            oSheet.Range("A1").Value = "Part Cost Report from " & dteStart & " to " & dteEnd

'            '//Define the SQL statement for data selection
'            Dim strSQL_count As String = "select Cust_Name1, Cust_Name2, Model_Desc, count(tdevice.Device_ID) as devicecount from " & _
'                                                  "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc "

'            Dim strSQL_DBRcount As String = "select Cust_Name1, Cust_Name2, Model_Desc, count(tdevice.Device_ID) as devicecount from " & _
'                                                  "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                                                  "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "and lbillcodes.billcode_rule in (1,2,9) " & _
'                                                  "group by cust_name1, model_desc "

'            Dim strSQL_ALL_DATA_PARTS As String = "select Cust_Name1, Cust_Name2, Model_Desc, lpsprice.psprice_number as PartNumber, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost from " & _
'                                                  "((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'                                                  "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                                                  "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc, lpsprice.psprice_number "

'            Dim strSQL_ALL_DATA_LABOR As String = "select Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(Device_SN) as DeviceCount from " & _
'                                                  "(((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc "

'            Dim strSQL_DBR_DATA_LABOR As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(tdevice.Device_SN) as DeviceCount from " & _
'                                                  "(((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'                                                  "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) " & _
'                                                  "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'                                                  "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                                                  "and lbillcodes.billcode_rule in (1,2) " & _
'                                                  "group by cust_name1, model_desc "

'            'Dim strSQL_DBR_DATA_LABOR As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(tdevice.Device_SN) as DeviceCount from " & _
'            '                                      "((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'            '                                      "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'            '                                      "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'            '                                      "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'            '                                      "where tdevice.device_dateship >= '" & dteFstart & "' " & _
'            '                                      "and tdevice.device_dateship <= '" & dteFend & "' " & _
'            '                                      "and tdevicebill.billcode_id=25 " & _
'            '                                      "group by cust_name1, model_desc "


'            Dim strSQL_ALL_DATA_PARTS2 As String
'            strSQL_ALL_DATA_PARTS2 = "select tcustomer.cust_name1, tmodel.model_desc, "
'            strSQL_ALL_DATA_PARTS2 &= "lpsprice.psprice_number as PartNumber, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost, count(tdevicebill.billcode_id) as PartCount, lpsprice.psprice_Desc as Description "
'            strSQL_ALL_DATA_PARTS2 &= "from tdevice "
'            strSQL_ALL_DATA_PARTS2 &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "where tdevice.device_dateship >= '" & dteFstart & "' " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "and tdevice.device_dateship <= '" & dteFend & "' " & Environment.NewLine
'            strSQL_ALL_DATA_PARTS2 &= "group by lpsprice.psprice_number "


'            If ckCompanyALL.Checked = False Then
'                'strSQL_ALL_DATA_PARTS2 += "and tcustomer.Cust_Name1 = '" & Trim(cboCompany.Text) & "'"
'            End If
'            If ckModelALL.Checked = False Then
'                'strSQL_ALL_DATA_PARTS2 += "and tmodel.Model_Desc = '" & Trim(cboModel.Text) & "'"
'            End If
'            strSQL_ALL_DATA_PARTS2 &= "order by tcustomer.cust_name1, tmodel.model_desc, lpsprice.psprice_number;"


'            Dim objConn As PSS.Data.Production.Joins

'            Dim dtCount As DataTable = objConn.OrderEntrySelect(strSQL_count)
'            Dim dtDBRCount As DataTable = objConn.OrderEntrySelect(strSQL_DBRcount)

'            Dim dtALLPARTS As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS)
'            Dim dtALLPARTS2 As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS2)

'            Dim dtALLLABOR As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_LABOR)
'            Dim dtDBRLABOR As DataTable = objConn.OrderEntrySelect(strSQL_DBR_DATA_LABOR)

'            Dim rAllParts As DataRow
'            Dim rAllParts2 As DataRow
'            Dim rAllLabor As DataRow
'            Dim rDbrLabor As DataRow

'            Dim xAllParts As Integer = 0
'            Dim xAllParts2 As Integer = 0
'            Dim xAllLabor As Integer = 0
'            Dim xDbrLabor As Integer = 0

'            Dim vLaborAll As Double = 0.0

'            'Start load of data
'            For xAllLabor = 0 To dtALLLABOR.Rows.Count - 1

'                rAllLabor = dtALLLABOR.Rows(xAllLabor)



'                If ckCompanyALL.Checked = False Then
'                    If Trim(rAllLabor("Cust_Name1")) <> Trim(cboCompany.Text) Then
'                        GoTo company_force_next
'                    End If
'                End If

'                If ckModelALL.Checked = False Then
'                    If Trim(rAllLabor("Model_Desc")) <> Trim(cboModel.Text) Then
'                        GoTo company_force_next
'                    End If
'                End If

'                '//Place Customer Name
'                oSheet.Range(CStr("A" & currentRow)).Value = rAllLabor("Cust_name1") & " " & rAllLabor("cust_Name2")

'                '//Place Model Name
'                oSheet.Range(CStr("B" & currentRow)).Value = rAllLabor("Model_Desc")


'                staticRow = currentRow

'                '//Place Labor Amount - ALL
'                If IsDBNull(rAllLabor("LaborAmt")) = False Then
'                    'oSheet.Range(CStr("S" & currentRow)).Value = rAllLabor("LaborAmt")
'                Else
'                    'oSheet.Range(CStr("S" & currentRow)).Value = "0.00"
'                End If

'                '//Place Device Count - ALL
'                If IsDBNull(rAllLabor("DeviceCount")) = False Then
'                    'oSheet.Range(CStr("Y" & currentRow)).Value = rAllLabor("DeviceCount").ToString
'                Else
'                    'oSheet.Range(CStr("Y" & currentRow)).Value = "0"
'                End If


'                '//New loop to get total count of devices
'                Dim xGetCount As Integer = 0
'                Dim xGetDBRCount As Integer = 0
'                Dim rGetCount As DataRow
'                Dim rGetDBRCount As DataRow



'                Dim intCount, intDBRCount As Integer
'                modelCount = 0
'                For xGetCount = 0 To dtCount.Rows.Count - 1
'                    rGetCount = dtCount.Rows(xGetCount)
'                    If Trim(rGetCount("Cust_Name1")) = Trim(rAllLabor("Cust_Name1")) Then
'                        If Trim(rGetCount("Model_Desc")) = Trim(rAllLabor("Model_Desc")) Then


'                            For xGetDBRCount = 0 To dtDBRCount.Rows.Count - 1
'                                rGetDBRCount = dtDBRCount.Rows(xGetDBRCount)
'                                If Trim(rGetDBRCount("Cust_Name1")) = Trim(rAllLabor("Cust_Name1")) Then
'                                    If Trim(rGetDBRCount("Model_Desc")) = Trim(rAllLabor("Model_Desc")) Then


'                                        'MsgBox(CInt(rGetCount("devicecount")))
'                                        'MsgBox(CInt(rGetDBRCount("devicecount")))
'                                        oSheet.Range(CStr("D" & currentRow)).Value = (CInt(rGetCount("devicecount")) - CInt(rGetDBRCount("devicecount")))
'                                        modelCount = (CInt(rGetCount("devicecount")) - CInt(rGetDBRCount("devicecount")))
'                                        Exit For
'                                    End If
'                                End If
'                            Next


'                        End If
'                    End If
'                Next







'                '//Second loop to acquire parts amount same device

'                Dim rCurrentPart As DataRow = dtALLPARTS.Rows(0)
'                Dim currentPart As String = rCurrentPart("PartNumber")


'                For xAllParts = 0 To dtALLPARTS.Rows.Count - 1
'                    rAllParts = dtALLPARTS.Rows(xAllParts)

'                    If Trim(rAllLabor("Cust_Name1")) = Trim(rAllParts("Cust_Name1")) Then
'                        If Trim(rAllLabor("Model_Desc")) = Trim(rAllParts("Model_Desc")) Then

'                            If IsDBNull(rAllParts("PartAmtCost")) = False Then
'                                'oSheet.Range(CStr("W" & currentRow)).Value = rAllParts("PartAmtCost").ToString
'                                'oSheet.Range(CStr("G" & currentRow)).Value = rAllParts("PartAmtCost").ToString
'                            Else
'                                'oSheet.Range(CStr("W" & currentRow)).Value = "0"
'                                'oSheet.Range(CStr("G" & currentRow)).Value = "0"
'                            End If

'                            If IsDBNull(rAllParts("PartAmt")) = False Then
'                                'oSheet.Range(CStr("U" & currentRow)).Value = rAllParts("PartAmt").ToString
'                                ''Exit For
'                            Else
'                                'oSheet.Range(CStr("U" & currentRow)).Value = "0"
'                                ''Exit For
'                            End If

'                            'strSQL_ALL_DATA_PARTS2 = "select lpsprice.psprice_number as PartNumber, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost, count(tdevicebill.billcode_id) as PartCount, lpsprice.psprice_Desc as Description from " & _
'                            '                         "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                            '                         "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                            '                         "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                            '                         "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                            '                         "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                            '                         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                            '                         "where  cust_name1 = '" & Trim(rAllParts("Cust_Name1")) & "' AND Model_desc = '" & Trim(rAllParts("Model_Desc")) & "' AND lpsprice.psprice_number = '" & Trim(rAllParts("PartNumber")) & "' " & _
'                            '                         "and tdevice.device_dateship >= '" & dteFstart & "' " & _
'                            '                         "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                            '                         "group by lpsprice.psprice_number"
'                            'dtALLPARTS2 = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS2)

'                            ''currentRow += 1
'                            ''oSheet.Range(CStr("B" & currentRow)).Value = "PARTS"


'                            For xAllParts2 = 0 To dtALLPARTS2.Rows.Count - 1
'                                rAllParts2 = dtALLPARTS2.Rows(xAllParts2)

'                                'MsgBox(currentPart)

'                                If Trim(rAllParts2("Cust_Name1")) = Trim(rAllParts("Cust_Name1")) Then
'                                    If Trim(rAllParts2("Model_Desc")) = Trim(rAllParts("Model_Desc")) Then
'                                        If Trim(rAllParts2("PartNumber")) = Trim(rAllParts("PartNumber")) Then

'                                            currentRow += 1

'                                            '//Assign parts amount to XL sheet
'                                            If IsDBNull(rAllParts("PartAmtCost")) = False Then
'                                                oSheet.Range(CStr("B" & currentRow)).Value = rAllParts2("PartNumber").ToString
'                                                oSheet.Range(CStr("C" & currentRow)).Value = rAllParts2("Description").ToString
'                                                oSheet.Range(CStr("D" & currentRow)).Value = rAllParts2("PartCount").ToString
'                                                oSheet.Range(CStr("G" & currentRow)).Value = rAllParts2("PartAmtCost").ToString
'                                            Else
'                                                'oSheet.Range(CStr("W" & currentRow)).Value = "0"
'                                                oSheet.Range(CStr("G" & currentRow)).Value = "0"
'                                            End If

'                                            oSheet.Range(CStr("I" & currentRow)).Value = (CInt(oSheet.Range(CStr("D" & currentRow)).Value)) / modelCount

'                                            If IsDBNull(rAllParts2("PartAmt")) = False Then
'                                                'oSheet.Range(CStr("U" & currentRow)).Value = rAllParts2("PartAmt").ToString
'                                                Exit For
'                                            Else
'                                                'oSheet.Range(CStr("U" & currentRow)).Value = "0"
'                                                Exit For
'                                            End If

'                                        End If
'                                    End If
'                                End If

'                            Next
'                            'Exit For
'                        End If
'                    End If
'                    'currentRow += 1
'                Next

'                '//Default assignment for DBR data in case DBR record does not exists
'                'oSheet.Range(CStr("L" & currentRow)).Value = "0"
'                'oSheet.Range(CStr("P" & currentRow)).Value = "0"

'                '//Third loop to acquire DBR labor amount same device
'                For xDbrLabor = 0 To dtDBRLABOR.Rows.Count - 1
'                    rDbrLabor = dtDBRLABOR.Rows(xDbrLabor)

'                    If Trim(rAllLabor("Cust_Name1")) = Trim(rDbrLabor("Cust_Name1")) Then
'                        If Trim(rAllLabor("Model_Desc")) = Trim(rDbrLabor("Model_Desc")) Then
'                            '//Place Device Count - DBR
'                            If IsDBNull(rDbrLabor("DeviceCount")) = False Then
'                                'oSheet.Range(CStr("P" & currentRow)).Value = rDbrLabor("DeviceCount").ToString
'                            Else
'                                'oSheet.Range(CStr("P" & currentRow)).Value = "0"
'                            End If

'                            '//Assign DBR labor amount to XL sheet
'                            If IsDBNull(rDbrLabor("LaborAmt")) = False Then
'                                'oSheet.Range(CStr("L" & currentRow)).Value = rDbrLabor("LaborAmt").ToString
'                                Exit For
'                            Else
'                                'oSheet.Range(CStr("L" & currentRow)).Value = "0"
'                                Exit For
'                            End If

'                        End If
'                    End If
'                Next
'                ''//Set the part amount to 0 for the DBR Section
'                'oSheet.Range(CStr("N" & currentRow)).Value = "0"

'                ''AUP Cost ALL
'                'oSheet.Range(CStr("X" & currentRow)).Value = oSheet.Range(CStr("W" & currentRow)).Value / oSheet.Range(CStr("Y" & currentRow)).Value

'                'Total Revenue - ALL
'                'oSheet.Range(CStr("Z" & currentRow)).Value = oSheet.Range(CStr("U" & currentRow)).Value + oSheet.Range(CStr("S" & currentRow)).Value
'                'Total Revenue - DBR
'                'oSheet.Range(CStr("Q" & currentRow)).Value = oSheet.Range(CStr("N" & currentRow)).Value + oSheet.Range(CStr("L" & currentRow)).Value
'                'Total PARTS - Repaired
'                'oSheet.Range(CStr("E" & staticRow)).Value = oSheet.Range(CStr("U" & currentRow)).Value - oSheet.Range(CStr("N" & currentRow)).Value
'                'Total LABOR - Repaired
'                'oSheet.Range(CStr("C" & currentRow)).Value = oSheet.Range(CStr("S" & currentRow)).Value - oSheet.Range(CStr("L" & currentRow)).Value
'                'Total Revenue - Repaired
'                'oSheet.Range(CStr("J" & currentRow)).Value = oSheet.Range(CStr("C" & currentRow)).Value + oSheet.Range(CStr("E" & currentRow)).Value

'                'oSheet.Range(CStr("O" & currentRow)).Value = 0
'                'oSheet.Range(CStr("M" & currentRow)).Value = 0

'                '//AUP Labor DBR
'                'If oSheet.Range(CStr("P" & currentRow)).Value > 0 Then
'                'oSheet.Range(CStr("M" & currentRow)).Value = oSheet.Range(CStr("L" & currentRow)).Value / oSheet.Range(CStr("P" & currentRow)).Value
'                'Else
'                '    oSheet.Range(CStr("M" & currentRow)).Value = 0
'                'End If

'                '//AUP Labor ALL
'                'If oSheet.Range(CStr("Y" & currentRow)).Value > 0 Then
'                'oSheet.Range(CStr("T" & currentRow)).Value = oSheet.Range(CStr("S" & currentRow)).Value / oSheet.Range(CStr("Y" & currentRow)).Value
'                'Else
'                '    oSheet.Range(CStr("T" & currentRow)).Value = 0
'                'End If

'                '//AUP Parts DBR
'                'If oSheet.Range(CStr("P" & currentRow)).Value > 0 Then
'                'oSheet.Range(CStr("O" & currentRow)).Value = oSheet.Range(CStr("N" & currentRow)).Value / oSheet.Range(CStr("P" & currentRow)).Value
'                'Else
'                '    oSheet.Range(CStr("O" & currentRow)).Value = 0
'                'End If

'                '//AUP Parts ALL
'                'If oSheet.Range(CStr("Y" & staticRow)).Value > 0 Then
'                'oSheet.Range(CStr("V" & staticRow)).Value = oSheet.Range(CStr("U" & staticRow)).Value / oSheet.Range(CStr("Y" & staticRow)).Value
'                'Else
'                '    oSheet.Range(CStr("V" & staticRow)).Value = 0
'                'End If

'                'Shipped - Repaired
'                'oSheet.Range(CStr("I" & staticRow)).Value = oSheet.Range(CStr("Y" & staticRow)).Value - oSheet.Range(CStr("P" & staticRow)).Value


'                '//AUP Labor Repaired
'                'If oSheet.Range(CStr("I" & staticRow)).Value > 0 Then
'                'oSheet.Range(CStr("D" & staticRow)).Value = oSheet.Range(CStr("C" & staticRow)).Value / oSheet.Range(CStr("I" & staticRow)).Value
'                'Else
'                '    oSheet.Range(CStr("D" & staticRow)).Value = 0
'                'End If

'                '//AUP Parts Repaired
'                'If oSheet.Range(CStr("I" & staticRow)).Value > 0 Then
'                'oSheet.Range(CStr("F" & staticRow)).Value = oSheet.Range(CStr("E" & staticRow)).Value / oSheet.Range(CStr("I" & staticRow)).Value
'                'Else
'                '    oSheet.Range(CStr("F" & staticRow)).Value = 0
'                'End If

'                'AUP Cost Repair
'                'oSheet.Range(CStr("H" & staticRow)).Value = oSheet.Range(CStr("G" & staticRow)).Value / oSheet.Range(CStr("I" & staticRow)).Value

'                currentRow += 1

'model_force_next:
'company_force_next:
'            Next

'            oSheet.PageSetup.PrintArea = "$A$1:$I$" & currentRow

'            objXL.Visible = True

'            objXL = Nothing

'        End Sub


'        Private Sub ckCompanyALL_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCompanyALL.CheckedChanged

'            If ckCompanyALL.Checked = True Then
'                cboCompany.Enabled = False
'                lblCompany.Enabled = False
'            Else
'                cboCompany.Enabled = True
'                lblCompany.Enabled = True
'            End If


'        End Sub

'        Private Sub btnPCDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPCDB.Click
'            If ckCompanyALL.Checked = False Then
'                If Trim(cboCompany.Text) = "" Then
'                    MsgBox("A Company must be selected before continuing.", MsgBoxStyle.OKOnly)
'                    cboCompany.Focus()
'                    Exit Sub
'                End If
'            End If

'            If ckModelALL.Checked = False Then
'                If Trim(cboModel.Text) = "" Then
'                    MsgBox("A Model must be selected before continuing.", MsgBoxStyle.OKOnly)
'                    cboModel.Focus()
'                    Exit Sub
'                End If
'            End If

'            Dim currentRow As Integer = 4

'            Dim objXL As Object

'            'Dim oBook As EXCEL.WORKBOOK
'            'Dim oSheet As Excel.Worksheet
'            Dim oSheet As Object

'            Dim modelCount As Integer = 0
'            Dim staticRow As Integer

'            '//Define the date values for the report
'            Dim dteStart As String = Me.calStart.Text
'            Dim dteEnd As String = Me.calEnd.Text
'            Dim dteFstart As String = Gui.Receiving.FormatDateShort(dteStart) & " 00:00:00"
'            Dim dteFend As String = Gui.Receiving.FormatDateShort(dteEnd) & " 23:59:59"

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")

'            objXL.Workbooks.Open("r:\Template_Report3PartDetail.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("B").NumberFormat = "@"
'            'oSheet.Columns("C").NumberFormat = "0.00"
'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("J").NumberFormat = "0.00"
'            oSheet.Columns("L").NumberFormat = "0.00"
'            oSheet.Columns("M").NumberFormat = "0.00"
'            oSheet.Columns("N").NumberFormat = "0.00"
'            oSheet.Columns("O").NumberFormat = "0.00"

'            oSheet.Columns("F").columnwidth = 0
'            oSheet.Columns("N").columnwidth = 0
'            oSheet.Columns("O").columnwidth = 0

'            oSheet.Columns("Q").NumberFormat = "0.00"
'            oSheet.Columns("S").NumberFormat = "0.00"
'            oSheet.Columns("T").NumberFormat = "0.00"
'            oSheet.Columns("U").NumberFormat = "0.00"
'            oSheet.Columns("V").NumberFormat = "0.00"
'            oSheet.Columns("W").NumberFormat = "0.00"
'            oSheet.Columns("X").NumberFormat = "0.00"

'            oSheet.Columns("Z").NumberFormat = "0.00"

'            '//Set title of form
'            oSheet.Range("A1").Value = "Part Cost Report from " & dteStart & " to " & dteEnd

'            '//Define the SQL statement for data selection
'            Dim strSQL_count As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, count(tdevice.Device_ID) as devicecount from " & _
'                                                  "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                                                  "inner join tparttransaction on tdevice.device_id = tparttransaction.device_id " & _
'                                                  "where tparttransaction.date_rec >= '" & dteFstart & "' " & _
'                                                  "and tparttransaction.date_rec <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc"

'            Dim strSQL_DBRcount As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, count(tdevice.Device_ID) as devicecount from " & _
'                                                  "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                                                  "inner join tparttransaction on tdevicebill.billcode_id = tparttransaction.billcode_id and tdevicebill.device_id = tparttransaction.device_id " & _
'                                                  "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'                                                  "where tparttransaction.date_rec >= '" & dteFstart & "' " & _
'                                                  "and tparttransaction.date_rec <= '" & dteFend & "' " & _
'                                                  "and lbillcodes.billcode_rule in (1,2,9) " & _
'                                                  "group by cust_name1, model_desc"

'            Dim strSQL_ALL_DATA_PARTS As String = "select Cust_Name1, Cust_Name2, Model_Desc, lpsprice.psprice_number as PartNumber, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost from " & _
'                                                  "((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'                                                  "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                                                  "inner join tparttransaction on tdevicebill.billcode_id = tparttransaction.billcode_id and tdevicebill.device_id = tparttransaction.device_id " & _
'                                                  "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                                                  "where tparttransaction.date_rec >= '" & dteFstart & "' " & _
'                                                  "and tparttransaction.date_rec <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc, lpsprice.psprice_number"

'            Dim strSQL_ALL_DATA_LABOR As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(Device_SN) as DeviceCount from " & _
'                                                  "(((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tparttransaction on tdevice.device_id = tparttransaction.device_id " & _
'                                                  "where tparttransaction.date_rec >= '" & dteFstart & "' " & _
'                                                  "and tparttransaction.date_rec <= '" & dteFend & "' " & _
'                                                  "group by cust_name1, model_desc"

'            Dim strSQL_DBR_DATA_LABOR As String = "select distinct Cust_Name1, Cust_Name2, Model_Desc, sum(Device_LaborCharge) as LaborAmt, count(tdevice.Device_SN) as DeviceCount from " & _
'                                                  "(((((tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id) " & _
'                                                  "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
'                                                  "inner join tmodel on tdevice.model_id = tmodel.model_id) " & _
'                                                  "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
'                                                  "inner join tparttransaction on tdevicebill.billcode_id = tparttransaction.billcode_id and tdevicebill.device_id = tparttransaction.device_id " & _
'                                                  "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) " & _
'                                                  "where tparttransaction.date_rec >= '" & dteFstart & "' " & _
'                                                  "and tparttransaction.date_rec <= '" & dteFend & "' " & _
'                                                  "and lbillcodes.billcode_rule in (1,2) " & _
'                                                  "group by cust_name1, model_desc "

'            Dim strSQL_ALL_DATA_PARTS2 As String
'            strSQL_ALL_DATA_PARTS2 = "select tcustomer.cust_name1, tmodel.model_desc, lpsprice.psprice_number as PartNumber, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost, count(tdevicebill.billcode_id) as PartCount, lpsprice.psprice_Desc as Description from " & _
'                                     "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                                     "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                                     "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                                     "inner join tparttransaction on tdevicebill.dbill_id = tparttransaction.dbill_id " & _
'                                     "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'                                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                                     "where tparttransaction.date_rec >= '" & dteFstart & "' " & _
'                                     "and tparttransaction.date_rec <= '" & dteFend & "' "
'            '"group by lpsprice.psprice_number"

'            If ckCompanyALL.Checked = False Then
'                'strSQL_ALL_DATA_PARTS2 += "and tcustomer.Cust_Name1 = '" & Trim(cboCompany.Text) & "'"
'            End If
'            If ckModelALL.Checked = False Then
'                'strSQL_ALL_DATA_PARTS2 += "and tmodel.Model_Desc = '" & Trim(cboModel.Text) & "'"
'            End If
'            strSQL_ALL_DATA_PARTS2 += "group by tcustomer.cust_name1, tmodel.model_desc, lpsprice.psprice_number"


'            Dim objConn As PSS.Data.Production.Joins

'            Dim dtCount As DataTable = objConn.OrderEntrySelect(strSQL_count)
'            Dim dtDBRCount As DataTable = objConn.OrderEntrySelect(strSQL_DBRcount)

'            Dim dtALLPARTS As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS)
'            Dim dtALLPARTS2 As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS2)

'            Dim dtALLLABOR As DataTable = objConn.OrderEntrySelect(strSQL_ALL_DATA_LABOR)
'            Dim dtDBRLABOR As DataTable = objConn.OrderEntrySelect(strSQL_DBR_DATA_LABOR)

'            Dim rAllParts As DataRow
'            Dim rAllParts2 As DataRow
'            Dim rAllLabor As DataRow
'            Dim rDbrLabor As DataRow

'            Dim xAllParts As Integer = 0
'            Dim xAllParts2 As Integer = 0
'            Dim xAllLabor As Integer = 0
'            Dim xDbrLabor As Integer = 0

'            Dim vLaborAll As Double = 0.0

'            'Start load of data
'            For xAllLabor = 0 To dtALLLABOR.Rows.Count - 1

'                rAllLabor = dtALLLABOR.Rows(xAllLabor)

'                If ckCompanyALL.Checked = False Then
'                    If Trim(rAllLabor("Cust_Name1")) <> Trim(cboCompany.Text) Then
'                        GoTo company_force_next
'                    End If
'                End If

'                If ckModelALL.Checked = False Then
'                    If Trim(rAllLabor("Model_Desc")) <> Trim(cboModel.Text) Then
'                        GoTo company_force_next
'                    End If
'                End If

'                '//Place Customer Name
'                oSheet.Range(CStr("A" & currentRow)).Value = rAllLabor("Cust_name1") & " " & rAllLabor("cust_Name2")

'                '//Place Model Name
'                oSheet.Range(CStr("B" & currentRow)).Value = rAllLabor("Model_Desc")


'                staticRow = currentRow

'                '//Place Labor Amount - ALL
'                If IsDBNull(rAllLabor("LaborAmt")) = False Then
'                    'oSheet.Range(CStr("S" & currentRow)).Value = rAllLabor("LaborAmt")
'                Else
'                    'oSheet.Range(CStr("S" & currentRow)).Value = "0.00"
'                End If

'                '//Place Device Count - ALL
'                If IsDBNull(rAllLabor("DeviceCount")) = False Then
'                    'oSheet.Range(CStr("Y" & currentRow)).Value = rAllLabor("DeviceCount").ToString
'                Else
'                    'oSheet.Range(CStr("Y" & currentRow)).Value = "0"
'                End If


'                '//New loop to get total count of devices
'                Dim xGetCount As Integer = 0
'                Dim xGetDBRCount As Integer = 0
'                Dim rGetCount As DataRow
'                Dim rGetDBRCount As DataRow



'                Dim intCount, intDBRCount As Integer
'                modelCount = 0
'                For xGetCount = 0 To dtCount.Rows.Count - 1
'                    rGetCount = dtCount.Rows(xGetCount)
'                    If Trim(rGetCount("Cust_Name1")) = Trim(rAllLabor("Cust_Name1")) Then
'                        If Trim(rGetCount("Model_Desc")) = Trim(rAllLabor("Model_Desc")) Then


'                            For xGetDBRCount = 0 To dtDBRCount.Rows.Count - 1
'                                rGetDBRCount = dtDBRCount.Rows(xGetDBRCount)
'                                If Trim(rGetDBRCount("Cust_Name1")) = Trim(rAllLabor("Cust_Name1")) Then
'                                    If Trim(rGetDBRCount("Model_Desc")) = Trim(rAllLabor("Model_Desc")) Then


'                                        'MsgBox(CInt(rGetCount("devicecount")))
'                                        'MsgBox(CInt(rGetDBRCount("devicecount")))
'                                        oSheet.Range(CStr("D" & currentRow)).Value = (CInt(rGetCount("devicecount")) - CInt(rGetDBRCount("devicecount")))
'                                        modelCount = (CInt(rGetCount("devicecount")) - CInt(rGetDBRCount("devicecount")))
'                                        Exit For
'                                    End If
'                                End If
'                            Next


'                        End If
'                    End If
'                Next







'                '//Second loop to acquire parts amount same device

'                Dim rCurrentPart As DataRow = dtALLPARTS.Rows(0)
'                Dim currentPart As String = rCurrentPart("PartNumber")


'                For xAllParts = 0 To dtALLPARTS.Rows.Count - 1
'                    rAllParts = dtALLPARTS.Rows(xAllParts)

'                    If Trim(rAllLabor("Cust_Name1")) = Trim(rAllParts("Cust_Name1")) Then
'                        If Trim(rAllLabor("Model_Desc")) = Trim(rAllParts("Model_Desc")) Then

'                            If IsDBNull(rAllParts("PartAmtCost")) = False Then
'                                'oSheet.Range(CStr("W" & currentRow)).Value = rAllParts("PartAmtCost").ToString
'                                'oSheet.Range(CStr("G" & currentRow)).Value = rAllParts("PartAmtCost").ToString
'                            Else
'                                'oSheet.Range(CStr("W" & currentRow)).Value = "0"
'                                'oSheet.Range(CStr("G" & currentRow)).Value = "0"
'                            End If

'                            If IsDBNull(rAllParts("PartAmt")) = False Then
'                                'oSheet.Range(CStr("U" & currentRow)).Value = rAllParts("PartAmt").ToString
'                                ''Exit For
'                            Else
'                                'oSheet.Range(CStr("U" & currentRow)).Value = "0"
'                                ''Exit For
'                            End If

'                            'strSQL_ALL_DATA_PARTS2 = "select lpsprice.psprice_number as PartNumber, sum(Dbill_InvoiceAmt) as PartAmt, sum(Dbill_AvgCost) as PartAmtCost, count(tdevicebill.billcode_id) as PartCount, lpsprice.psprice_Desc as Description from " & _
'                            '                         "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                            '                         "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                            '                         "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                            '                         "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                            '                         "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                            '                         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                            '                         "where  cust_name1 = '" & Trim(rAllParts("Cust_Name1")) & "' AND Model_desc = '" & Trim(rAllParts("Model_Desc")) & "' AND lpsprice.psprice_number = '" & Trim(rAllParts("PartNumber")) & "' " & _
'                            '                         "and tdevice.device_dateship >= '" & dteFstart & "' " & _
'                            '                         "and tdevice.device_dateship <= '" & dteFend & "' " & _
'                            '                         "group by lpsprice.psprice_number"
'                            'dtALLPARTS2 = objConn.OrderEntrySelect(strSQL_ALL_DATA_PARTS2)

'                            ''currentRow += 1
'                            ''oSheet.Range(CStr("B" & currentRow)).Value = "PARTS"


'                            For xAllParts2 = 0 To dtALLPARTS2.Rows.Count - 1
'                                rAllParts2 = dtALLPARTS2.Rows(xAllParts2)

'                                'MsgBox(currentPart)

'                                If Trim(rAllParts2("Cust_Name1")) = Trim(rAllParts("Cust_Name1")) Then
'                                    If Trim(rAllParts2("Model_Desc")) = Trim(rAllParts("Model_Desc")) Then
'                                        If Trim(rAllParts2("PartNumber")) = Trim(rAllParts("PartNumber")) Then

'                                            currentRow += 1

'                                            '//Assign parts amount to XL sheet
'                                            If IsDBNull(rAllParts("PartAmtCost")) = False Then
'                                                oSheet.Range(CStr("B" & currentRow)).Value = rAllParts2("PartNumber").ToString
'                                                oSheet.Range(CStr("C" & currentRow)).Value = rAllParts2("Description").ToString
'                                                oSheet.Range(CStr("D" & currentRow)).Value = rAllParts2("PartCount").ToString
'                                                oSheet.Range(CStr("G" & currentRow)).Value = rAllParts2("PartAmtCost").ToString
'                                            Else
'                                                'oSheet.Range(CStr("W" & currentRow)).Value = "0"
'                                                oSheet.Range(CStr("G" & currentRow)).Value = "0"
'                                            End If

'                                            oSheet.Range(CStr("I" & currentRow)).Value = (CInt(oSheet.Range(CStr("D" & currentRow)).Value)) / modelCount

'                                            If IsDBNull(rAllParts2("PartAmt")) = False Then
'                                                'oSheet.Range(CStr("U" & currentRow)).Value = rAllParts2("PartAmt").ToString
'                                                Exit For
'                                            Else
'                                                'oSheet.Range(CStr("U" & currentRow)).Value = "0"
'                                                Exit For
'                                            End If

'                                        End If
'                                    End If
'                                End If

'                            Next
'                            'Exit For
'                        End If
'                    End If
'                    'currentRow += 1
'                Next

'                '//Default assignment for DBR data in case DBR record does not exists
'                oSheet.Range(CStr("L" & currentRow)).Value = "0"
'                oSheet.Range(CStr("P" & currentRow)).Value = "0"

'                '//Third loop to acquire DBR labor amount same device
'                For xDbrLabor = 0 To dtDBRLABOR.Rows.Count - 1
'                    rDbrLabor = dtDBRLABOR.Rows(xDbrLabor)

'                    If Trim(rAllLabor("Cust_Name1")) = Trim(rDbrLabor("Cust_Name1")) Then
'                        If Trim(rAllLabor("Model_Desc")) = Trim(rDbrLabor("Model_Desc")) Then
'                            '//Place Device Count - DBR
'                            If IsDBNull(rDbrLabor("DeviceCount")) = False Then
'                                'oSheet.Range(CStr("P" & currentRow)).Value = rDbrLabor("DeviceCount").ToString
'                            Else
'                                'oSheet.Range(CStr("P" & currentRow)).Value = "0"
'                            End If

'                            '//Assign DBR labor amount to XL sheet
'                            If IsDBNull(rDbrLabor("LaborAmt")) = False Then
'                                'oSheet.Range(CStr("L" & currentRow)).Value = rDbrLabor("LaborAmt").ToString
'                                Exit For
'                            Else
'                                'oSheet.Range(CStr("L" & currentRow)).Value = "0"
'                                Exit For
'                            End If

'                        End If
'                    End If
'                Next

'                currentRow += 1

'model_force_next:
'company_force_next:
'            Next

'            oSheet.PageSetup.PrintArea = "$A$1:$I$" & currentRow

'            objXL.Visible = True

'            objXL = Nothing


'        End Sub

'        Private Sub btnPartReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPartReport.Click

'            Dim objXL As Object
'            Dim oSheet As Object

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("r:\MaterialVarianceTemplate.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"

'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"

'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("I").NumberFormat = "0.00"
'            oSheet.Columns("J").NumberFormat = "0.00"

'            oSheet.Columns("L").NumberFormat = "0.00"
'            oSheet.Columns("M").NumberFormat = "0.00"
'            oSheet.Columns("N").NumberFormat = "0.00"

'            Dim iRow As Integer = 5


'            Dim dtWeekInvoiced As DataTable
'            Dim dt12WeekInvoiced As DataTable
'            Dim dtFYInvoiced As DataTable

'            Dim dtWeekTransact As DataTable
'            Dim dt12WeekTransact As DataTable
'            Dim dtFYTransact As DataTable

'            '//This is the new report for Mr. Cook
'            Dim vStart As Date = dteStart.Text
'            Dim vEnd As Date = dteEnd.Text

'            Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -84, vStart)
'            'Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -7, vStart)

'            '//This must be changed to adapt for dates after January 1
'            Dim fiscalStart As Date
'            If DatePart(DateInterval.Month, vEnd) > 0 And DatePart(DateInterval.Month, vEnd) < 4 Then
'                Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'            Else
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, vEnd)
'                'fiscalStart = "11/01/" & DatePart(DateInterval.Year, vEnd)
'            End If

'            Dim strSQL As String

'            '//Get current Week Invoiced Data
'            strSQL = "select lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(vStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and tdevice.device_invoice = 1 " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number"

'            dtWeekInvoiced = GetGroupData(strSQL)

'            '//Get current Week Transacted Data
'            'strSQL = "select tdevicebill.dbill_id, lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'            '         "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '         "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'            '         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            '         "where tdevicebill.date_rec > '" & Gui.Receiving.FormatDateShort(vStart) & " 00:00:00" & "' " & _
'            '         "and tdevicebill.date_rec < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'            '         "and lpsprice.psprice_inventorypart = 1 " & _
'            '         "group by lpsprice.psprice_number " & _
'            '         "order by lpsprice.psprice_number "
'            strSQL = "select tdevicebill.dbill_id, lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(vStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number "


'            '"left outer join tparttransaction on tdevicebill.dbill_id = tparttransaction.dbill_id " & _


'            dtWeekTransact = GetGroupData(strSQL)

'            '//Get Last 12 Weeks Invoiced Data
'            strSQL = "select lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(v12WeekStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and tdevice.device_invoice = 1 " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number"

'            dt12WeekInvoiced = GetGroupData(strSQL)

'            '//Get Last 12 Weeks Transacted Data
'            'strSQL = "select tdevicebill.dbill_id, lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'            '         "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '         "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'            '         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            '         "where tdevicebill.date_rec > '" & Gui.Receiving.FormatDateShort(v12WeekStart) & " 00:00:00" & "' " & _
'            '         "and tdevicebill.date_rec < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'            '         "and lpsprice.psprice_inventorypart = 1 " & _
'            '         "group by lpsprice.psprice_number " & _
'            '         "order by lpsprice.psprice_number "
'            strSQL = "select tdevicebill.dbill_id, lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(v12WeekStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number "

'            dt12WeekTransact = GetGroupData(strSQL)

'            '//Get This Fiscal Year Invoiced Data
'            strSQL = "select lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(fiscalStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and tdevice.device_invoice = 1 " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number"

'            dtFYInvoiced = GetGroupData(strSQL)

'            '//Get This Fiscal Year Transacted Data
'            'strSQL = "select tdevicebill.dbill_id, lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'            '         "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '         "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'            '         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            '         "where tdevicebill.date_rec > '" & Gui.Receiving.FormatDateShort(fiscalStart) & " 00:00:00" & "' " & _
'            '         "and tdevicebill.date_rec < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'            '         "and lpsprice.psprice_inventorypart = 1 " & _
'            '         "group by lpsprice.psprice_number " & _
'            '         "order by lpsprice.psprice_number "
'            strSQL = "select tdevicebill.dbill_id, lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), sum(tdevicebill.dbill_AvgCost) AS totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(fiscalStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number "

'            dtFYTransact = GetGroupData(strSQL)


'            Dim xCount As Integer = 0
'            Dim cwIssued, cwTransact As Integer
'            Dim c12wIssued, c12wTransact As Integer
'            Dim cFYIssued, cFYTransact As Integer

'            Dim rFYTransact As DataRow
'            Dim rcwIssued As DataRow
'            Dim rcwTransact As DataRow
'            Dim r12wIssued As DataRow
'            Dim r12wTransact As DataRow
'            Dim rFYIssued As DataRow
'            'Dim rFYTransact As DataRow

'            For xCount = 0 To dtFYTransact.Rows.Count - 1
'                rFYTransact = dtFYTransact.Rows(xCount)

'                oSheet.Range(CStr("A" & iRow)).Value = rFYTransact("Description")
'                oSheet.Range(CStr("B" & iRow)).Value = rFYTransact("Number")
'                oSheet.Range(CStr("L" & iRow)).Value = rFYTransact("totalAmount")


'                '//Current Week

'                '//Get Additional Data
'                For cwTransact = 0 To dtWeekTransact.Rows.Count - 1
'                    rcwTransact = dtWeekTransact.Rows(cwTransact)
'                    oSheet.Range(CStr("D" & iRow)).Value = 0
'                    If rFYTransact("Number") = rcwTransact("Number") Then
'                        oSheet.Range(CStr("D" & iRow)).Value = rcwTransact("totalAmount")
'                        Exit For
'                    End If
'                Next
'                '//Get Additional Data
'                For cwIssued = 0 To dtWeekInvoiced.Rows.Count - 1
'                    rcwIssued = dtWeekInvoiced.Rows(cwIssued)
'                    oSheet.Range(CStr("E" & iRow)).Value = 0
'                    If rFYTransact("Number") = rcwIssued("Number") Then
'                        oSheet.Range(CStr("E" & iRow)).Value = rcwIssued("totalAmount")
'                        Exit For
'                    End If
'                Next

'                '//Last 12 Weeks

'                '//Get Additional Data
'                For c12wTransact = 0 To dt12WeekTransact.Rows.Count - 1
'                    r12wTransact = dt12WeekTransact.Rows(c12wTransact)
'                    oSheet.Range(CStr("H" & iRow)).Value = 0
'                    If rFYTransact("Number") = r12wTransact("Number") Then
'                        oSheet.Range(CStr("H" & iRow)).Value = r12wTransact("totalAmount")
'                        Exit For
'                    End If
'                Next
'                '//Get Additional Data
'                For c12wIssued = 0 To dt12WeekInvoiced.Rows.Count - 1
'                    r12wIssued = dt12WeekInvoiced.Rows(c12wIssued)
'                    oSheet.Range(CStr("I" & iRow)).Value = 0
'                    If rFYTransact("Number") = r12wIssued("Number") Then
'                        oSheet.Range(CStr("I" & iRow)).Value = r12wIssued("totalAmount")
'                        Exit For
'                    End If
'                Next


'                '//Fiscal Year

'                '//Get Additional Data
'                oSheet.Range(CStr("L" & iRow)).Value = 0
'                oSheet.Range(CStr("L" & iRow)).Value = rFYTransact("totalAmount")
'                '//Get Additional Data
'                For cFYIssued = 0 To dtFYInvoiced.Rows.Count - 1
'                    rFYIssued = dtFYInvoiced.Rows(cFYIssued)
'                    oSheet.Range(CStr("M" & iRow)).Value = 0
'                    If rFYTransact("Number") = rFYIssued("Number") Then
'                        oSheet.Range(CStr("M" & iRow)).Value = rFYIssued("totalAmount")
'                        Exit For
'                    End If
'                Next

'                'oSheet.Range(CStr("F" & iRow)).FormulaR1C1 = "CStr('D' & iRow) - CStr('E' & iRow)"
'                'oSheet.Range(CStr("J" & iRow)).FormulaR1C1 = "CStr('H' & iRow) - CStr('I' & iRow)"
'                'oSheet.Range(CStr("N" & iRow)).FormulaR1C1 = "CStr('L' & iRow) - CStr('M' & iRow)"

'                iRow += 1

'            Next

'            objXL.Visible = True

'            objXL = Nothing



'        End Sub


'        Private Function GetGroupData(ByVal vSQL As String) As DataTable
'            Return PSS.Data.Production.Joins.OrderEntrySelect(vSQL)
'        End Function





'        Private Sub btnInvRptPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvRptPart.Click

'            Dim objXL As Object
'            Dim oSheet As Object

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("r:\MaterialVarianceTemplateUNITS.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"

'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0"
'            oSheet.Columns("F").NumberFormat = "0"

'            oSheet.Columns("H").NumberFormat = "0"
'            oSheet.Columns("I").NumberFormat = "0"
'            oSheet.Columns("J").NumberFormat = "0"

'            oSheet.Columns("L").NumberFormat = "0"
'            oSheet.Columns("M").NumberFormat = "0"
'            oSheet.Columns("N").NumberFormat = "0"

'            Dim iRow As Integer = 5



'            Dim dtWeekInvoiced As DataTable
'            Dim dt12WeekInvoiced As DataTable
'            Dim dtFYInvoiced As DataTable

'            Dim dtWeekIssued As New DataTable()
'            Dim dt12WeekIssued As New DataTable()
'            Dim dtFYIssued As New DataTable()
'            Dim dtPartData As New DataTable()

'            '//This is the new report for Mr. Cook
'            Dim vStart As Date = dteStart.Text
'            Dim vEnd As Date = dteEnd.Text

'            Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -84, vStart)

'            '//This must be changed to adapt for dates after January 1
'            Dim fiscalStart As Date
'            If DatePart(DateInterval.Month, vEnd) > 0 And DatePart(DateInterval.Month, vEnd) < 4 Then
'                Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'            Else
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, vEnd)
'            End If

'            '***************************************************************
'            Dim sConnectionstring As String
'            Dim objConn As New OleDbConnection()
'            Dim objCmdSelect As New OleDbCommand()
'            Dim objCmdSelect1 As New OleDbCommand()
'            Dim objAdapter1 As New OleDbDataAdapter()
'            Dim dtBin As New DataTable()
'            Dim dsBin As New DataSet()
'            Dim objDataset1 As New DataSet()
'            Dim strFileBin As String
'            Dim rBin As DataRow



'            '?????????????????????????????????????????


'            '?????????????????????????????????????????


'            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
'            Dim odbcStr As String
'            ''odbcStr = "SELECT ""Bin Code"" as BinLocation, ""Item No_"" as Item, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > #" & vStart & "# AND ""Registering Date"" < #" & vEnd & "# AND ""Bin Code"" = 'SFCELL'"
'            'odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" = 'SFCELL' AND ""Entry Type"" IN ('Positive Adjmt.','Negative Adjmt.') GROUP BY ""Item No_"" "
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" >= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" IN ('SFCELL','SFC11', 'SFML01','SFML03') AND ""Entry Type"" IN ('Movement') AND Quantity > 0 GROUP BY ""Item No_"" "

'            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
'            oODBConnection.Open()
'            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
'            Dim nda As New OdbcDataAdapter()
'            nda.SelectCommand = ncmd
'            Try
'                nda.Fill(dtWeekIssued)
'            Catch ex As Exception
'                MsgBox(ex.ToString)
'            End Try

'            Dim arrPKweekIssued(0) As DataColumn
'            arrPKweekIssued(0) = dtWeekIssued.Columns(0)
'            dtWeekIssued.PrimaryKey = arrPKweekIssued

'            'odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" = 'SFCELL' AND ""Entry Type"" IN ('Positive Adjmt.','Negative Adjmt.') GROUP BY ""Item No_"" "
'            'odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" = 'SFCELL' AND ""Entry Type"" IN ('Movement') AND Quantity > 0 GROUP BY ""Item No_"" "
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" IN ('SFCELL','SFC11', 'SFML01','SFML03') AND ""Entry Type"" IN ('Movement') AND Quantity > 0 GROUP BY ""Item No_"" "

'            Dim ncmd1 As New OdbcCommand(odbcStr, oODBConnection)
'            Dim nda1 As New OdbcDataAdapter()
'            nda1.SelectCommand = ncmd1
'            Try
'                nda1.Fill(dt12WeekIssued)
'            Catch ex As Exception
'                MsgBox(ex.ToString)
'            End Try

'            Dim arrPK12weekIssued(0) As DataColumn
'            arrPK12weekIssued(0) = dt12WeekIssued.Columns(0)
'            dt12WeekIssued.PrimaryKey = arrPK12weekIssued

'            'odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" = 'SFCELL' AND ""Entry Type"" IN ('Positive Adjmt.','Negative Adjmt.') GROUP BY ""Item No_"" "
'            'odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" = 'SFCELL' AND ""Entry Type"" IN ('Movement') AND Quantity > 0 GROUP BY ""Item No_"" "
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Qty_ (Base)"") as invCount FROM ""Warehouse Entry"" WHERE ""Registering Date"" > '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" < '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" IN ('SFCELL','SFC11', 'SFML01','SFML03') AND ""Entry Type"" IN ('Movement') AND Quantity > 0 GROUP BY ""Item No_"" "

'            Dim ncmd2 As New OdbcCommand(odbcStr, oODBConnection)
'            Dim nda2 As New OdbcDataAdapter()
'            nda2.SelectCommand = ncmd2
'            Try
'                nda2.Fill(dtFYIssued)
'            Catch ex As Exception
'                MsgBox(ex.ToString)
'            End Try

'            Dim arrPKFYIssued(0) As DataColumn
'            arrPKFYIssued(0) = dtFYIssued.Columns(0)
'            dtFYIssued.PrimaryKey = arrPKFYIssued

'            odbcStr = "SELECT No_ as Number, Description FROM Item"

'            Dim ncmd3 As New OdbcCommand(odbcStr, oODBConnection)
'            Dim nda3 As New OdbcDataAdapter()
'            nda3.SelectCommand = ncmd3
'            Try
'                nda3.Fill(dtPartData)
'            Catch ex As Exception
'                MsgBox(ex.ToString)
'            End Try


'            '***************************************************************
'            Dim strSQL As String

'            strSQL = "select lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), count(tdevicebill.dbill_invoiceamt) as totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(vStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "and tpsmap.prod_id in (1,2) " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number"

'            dtWeekInvoiced = GetGroupData(strSQL)

'            Dim arrPKweek(0) As DataColumn
'            arrPKweek(0) = dtWeekInvoiced.Columns(0)
'            dtWeekInvoiced.PrimaryKey = arrPKweek

'            strSQL = "select lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), count(tdevicebill.dbill_invoiceamt) as totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(v12WeekStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "and tpsmap.prod_id in (1,2) " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number"

'            dt12WeekInvoiced = GetGroupData(strSQL)

'            Dim arrPK12week(0) As DataColumn
'            arrPK12week(0) = dt12WeekInvoiced.Columns(0)
'            dt12WeekInvoiced.PrimaryKey = arrPK12week

'            strSQL = "select lpsprice.psprice_number as Number, lpsprice.psprice_desc as Description, count(tdevicebill.dbill_id), count(tdevicebill.dbill_invoiceamt) as totalAmount from " & _
'                     "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                     "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & _
'                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'                     "where tdevice.device_dateship > '" & Gui.Receiving.FormatDateShort(fiscalStart) & " 00:00:00" & "' " & _
'                     "and tdevice.device_dateship < '" & Gui.Receiving.FormatDateShort(vEnd) & " 23:59:59" & "' " & _
'                     "and lpsprice.psprice_inventorypart = 1 " & _
'                     "and tpsmap.prod_id in (1,2) " & _
'                     "group by lpsprice.psprice_number " & _
'                     "order by lpsprice.psprice_number"

'            dtFYInvoiced = GetGroupData(strSQL)

'            Dim arrFY(0) As DataColumn
'            arrFY(0) = dtFYInvoiced.Columns(0)
'            dtFYInvoiced.PrimaryKey = arrFY

'            Dim xCount As Integer = 0
'            Dim cwIssued, cwTransact As Integer
'            Dim c12wIssued, c12wTransact As Integer
'            Dim cFYIssued, cFYTransact As Integer

'            Dim rFYTransact As DataRow
'            Dim rcwIssued As DataRow
'            Dim rcwTransact As DataRow
'            Dim r12wIssued As DataRow
'            Dim r12wTransact As DataRow
'            Dim rFYIssued As DataRow
'            'Dim rFYTransact As DataRow

'            Dim partCount As Integer = 0
'            Dim rPart As DataRow

'            For xCount = 0 To dtFYIssued.Rows.Count - 1
'                rFYTransact = dtFYIssued.Rows(xCount)


'                For partCount = 0 To dtPartData.Rows.Count - 1
'                    rPart = dtPartData.Rows(partCount)
'                    '//_________________
'                    'rPart = dtPartData.Rows.Find(rFYTransact("Number"))
'                    'Try
'                    'oSheet.Range(CStr("A" & iRow)).Value = rPart("Description")
'                    'Catch ex As Exception
'                    'End Try
'                    '//_________________
'                    If rFYTransact("Number") = rPart("Number") Then
'                        oSheet.Range(CStr("A" & iRow)).Value = rPart("Description")
'                        Exit For
'                    End If
'                Next

'                oSheet.Range(CStr("B" & iRow)).Value = rFYTransact("Number")
'                oSheet.Range(CStr("L" & iRow)).Value = rFYTransact("invCount")

'                '//Current Week

'                '//Get Additional Data
'                'For cwTransact = 0 To dtWeekIssued.Rows.Count - 1
'                'rcwTransact = dtWeekIssued.Rows(cwTransact)
'                oSheet.Range(CStr("D" & iRow)).Value = 0
'                '//_________________
'                rcwTransact = dtWeekIssued.Rows.Find(rFYTransact("Number"))
'                Try
'                    oSheet.Range(CStr("D" & iRow)).Value = rcwTransact("invCount")
'                Catch ex As Exception
'                End Try
'                '//_________________
'                'If rFYTransact("Number") = rcwTransact("Number") Then
'                'oSheet.Range(CStr("D" & iRow)).Value = rcwTransact("invCount")
'                'Exit For
'                'End If
'                'Next

'                '//Get Additional Data
'                'For cwIssued = 0 To dtWeekInvoiced.Rows.Count - 1
'                'rcwIssued = dtWeekInvoiced.Rows(cwIssued)
'                oSheet.Range(CStr("E" & iRow)).Value = 0
'                '//_________________
'                rcwIssued = dtWeekInvoiced.Rows.Find(rFYTransact("Number"))
'                Try
'                    oSheet.Range(CStr("E" & iRow)).Value = rcwIssued("totalAmount").ToString
'                Catch ex As Exception
'                End Try
'                '//_________________
'                'If rFYTransact("Number") = rcwIssued("Number") Then
'                'Try
'                '    oSheet.Range(CStr("E" & iRow)).Value = rcwIssued("totalAmount").ToString
'                'Catch ex As Exception
'                'End Try
'                'Exit For
'                'End If
'                'Next

'                '//Last 12 Weeks

'                '//Get Additional Data
'                'For c12wTransact = 0 To dt12WeekIssued.Rows.Count - 1
'                'r12wTransact = dt12WeekIssued.Rows(c12wTransact)
'                oSheet.Range(CStr("H" & iRow)).Value = 0
'                '//_________________
'                r12wTransact = dt12WeekIssued.Rows.Find(rFYTransact("Number"))
'                Try
'                    oSheet.Range(CStr("H" & iRow)).Value = r12wTransact("invCount")
'                Catch ex As Exception
'                End Try
'                '//_________________
'                'If rFYTransact("Number") = r12wTransact("Number") Then
'                'oSheet.Range(CStr("H" & iRow)).Value = r12wTransact("invCount")
'                'Exit For
'                'End If
'                'Next
'                '//Get Additional Data
'                'For c12wIssued = 0 To dt12WeekInvoiced.Rows.Count - 1
'                '    r12wIssued = dt12WeekInvoiced.Rows(c12wIssued)
'                oSheet.Range(CStr("I" & iRow)).Value = 0
'                '//_________________
'                r12wIssued = dt12WeekInvoiced.Rows.Find(rFYTransact("Number"))
'                Try
'                    oSheet.Range(CStr("I" & iRow)).Value = r12wIssued("totalAmount").ToString
'                Catch ex As Exception
'                End Try
'                '//_________________
'                'If rFYTransact("Number") = r12wIssued("Number") Then
'                'Try
'                '    oSheet.Range(CStr("I" & iRow)).Value = r12wIssued("totalAmount").ToString
'                'Catch ex As Exception
'                'End Try
'                'Exit For
'                'End If
'                ' Next

'                '//Fiscal Year

'                '//Get Additional Data
'                oSheet.Range(CStr("L" & iRow)).Value = 0
'                oSheet.Range(CStr("L" & iRow)).Value = rFYTransact("invCount")


'                '//Get Additional Data
'                'For cFYIssued = 0 To dtFYInvoiced.Rows.Count - 1
'                'rFYIssued = dtFYInvoiced.Rows(cFYIssued)
'                oSheet.Range(CStr("M" & iRow)).Value = 0
'                '//_________________
'                rFYIssued = dtFYInvoiced.Rows.Find(rFYTransact("Number"))
'                Try
'                    oSheet.Range(CStr("M" & iRow)).Value = rFYIssued("totalAmount").ToString
'                    oSheet.Range(CStr("A" & iRow)).Value = rFYIssued("Description")
'                Catch ex As Exception
'                End Try
'                '//_________________
'                'If rFYTransact("Number") = rFYIssued("Number") Then
'                'Try
'                '    oSheet.Range(CStr("M" & iRow)).Value = rFYIssued("totalAmount").ToString
'                '    oSheet.Range(CStr("A" & iRow)).Value = rFYIssued("Description")
'                'Catch ex As Exception
'                'MsgBox(ex.tostring)
'                'End Try
'                'Exit For
'                'End If
'                'Next

'                'oSheet.Range(CStr("F" & iRow)).FormulaR1C1 = "CStr('D' & iRow) - CStr('E' & iRow)"
'                'oSheet.Range(CStr("J" & iRow)).FormulaR1C1 = "CStr('H' & iRow) - CStr('I' & iRow)"
'                'oSheet.Range(CStr("N" & iRow)).FormulaR1C1 = "CStr('L' & iRow) - CStr('M' & iRow)"

'                iRow += 1

'            Next

'            objXL.Visible = True

'            objXL = Nothing



'        End Sub


'        Private Sub btnValueReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValueReport.Click

'            Dim objXL As Object
'            Dim oSheet As Object

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("r:\MaterialVarianceTemplate.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("I").NumberFormat = "0.00"
'            oSheet.Columns("J").NumberFormat = "0.00"
'            oSheet.Columns("L").NumberFormat = "0.00"
'            oSheet.Columns("M").NumberFormat = "0.00"
'            oSheet.Columns("N").NumberFormat = "0.00"

'            Dim iRow As Integer = 5

'            Dim dtWeekTransact As DataTable
'            Dim dt12WeekTransact As DataTable
'            Dim dtFYTransact As DataTable

'            Dim dtWeekIssued As New DataTable() '//January 31, 2006
'            Dim dt12WeekIssued As New DataTable() '//January 31, 2006
'            Dim dtFYIssued As New DataTable() '//January 31, 2006

'            Dim dtWeekInvoiced As New DataTable()
'            Dim dt12WeekInvoiced As New DataTable()
'            Dim dtFYInvoiced As New DataTable()

'            Dim dtItems As New DataTable() '//January 31, 2006

'            '//This is the new report for Mr. Cook
'            Dim vStart As Date = dteStart.Text
'            Dim vEnd As Date = dteEnd.Text

'            Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -85, vStart)
'            Dim v12WeekEnd As Date = DateAdd(DateInterval.Day, -1, vStart)

'            '//This must be changed to adapt for dates after January 1
'            Dim fiscalStart As Date
'            If DatePart(DateInterval.Month, vEnd) > 0 And DatePart(DateInterval.Month, vEnd) < 4 Then
'                Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'            Else
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, vEnd)
'            End If

'            Dim strSQL As String

'            Dim sConnectionstring As String
'            Dim objConn As New OleDbConnection()
'            Dim objCmdSelect As New OleDbCommand()
'            Dim objCmdSelect1 As New OleDbCommand()
'            Dim objAdapter1 As New OleDbDataAdapter()
'            Dim dtBin As New DataTable()
'            Dim dsBin As New DataSet()
'            Dim objDataset1 As New DataSet()
'            Dim strFileBin As String
'            Dim rBin As DataRow

'            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
'            Dim odbcStr As String

'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//Items information
'            odbcStr = "SELECT No_ as Number, Description, ""Unit Cost"" as Amount FROM Item WHERE ""Inventory Posting Group"" IN ('CELL PARTS', 'MESS PARTS') ORDER BY ""Inventory Posting Group"", Description"
'            dtItems = getData(odbcStr)

'            Dim arrItems(0) As DataColumn
'            arrItems(0) = dtItems.Columns(0)
'            dtItems.PrimaryKey = arrItems
'            System.Windows.Forms.Application.DoEvents()


'            '//Issued Information
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtWeekIssued = getData(odbcStr)
'            Dim arrPKweekIssued(0) As DataColumn
'            arrPKweekIssued(0) = dtWeekIssued.Columns(0)
'            dtWeekIssued.PrimaryKey = arrPKweekIssued

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dt12WeekIssued = getData(odbcStr)
'            Dim arrPK12weekIssued(0) As DataColumn
'            arrPK12weekIssued(0) = dt12WeekIssued.Columns(0)
'            dt12WeekIssued.PrimaryKey = arrPK12weekIssued

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtFYIssued = getData(odbcStr)
'            Dim arrPKFYIssued(0) As DataColumn
'            arrPKFYIssued(0) = dtFYIssued.Columns(0)
'            dtFYIssued.PrimaryKey = arrPKFYIssued


'            System.Windows.Forms.Application.DoEvents()




'            '//Invoiced Information
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtWeekInvoiced = getData(odbcStr)

'            Dim arrPKweekInvoiced(0) As DataColumn
'            arrPKweekInvoiced(0) = dtWeekInvoiced.Columns(0)
'            dtWeekInvoiced.PrimaryKey = arrPKweekInvoiced

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dt12WeekInvoiced = getData(odbcStr)
'            Dim arrPK12weekInvoiced(0) As DataColumn
'            arrPK12weekInvoiced(0) = dt12WeekInvoiced.Columns(0)
'            dt12WeekInvoiced.PrimaryKey = arrPK12weekInvoiced

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtFYInvoiced = getData(odbcStr)
'            Dim arrPKFYInvoiced(0) As DataColumn
'            arrPKFYInvoiced(0) = dtFYInvoiced.Columns(0)
'            dtFYInvoiced.PrimaryKey = arrPKFYInvoiced


'            System.Windows.Forms.Application.DoEvents()

'            'Exit Sub

'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________


'            Dim mDescription As String
'            Dim mPartNumber As String
'            Dim mValue As Double



'            Dim xCount As Integer = 0
'            Dim itemCount As Integer = 0


'            Dim rFY_Issued As DataRow
'            Dim rItems As DataRow
'            Dim rWeekIssued As DataRow
'            Dim rWeekInvoiced As DataRow
'            Dim r12WeekIssued As DataRow
'            Dim r12WeekInvoiced As DataRow
'            Dim rFYIssued As DataRow
'            Dim rFYInvoiced As DataRow

'            Dim vWeekIssued, vWeekInvoiced, v12WeekIssued, v12WeekInvoiced As Double

'            '//Get first FY entry

'            For xCount = 0 To dtItems.Rows.Count - 1
'                rItems = dtItems.Rows(xCount)


'                vWeekIssued = 0
'                vWeekInvoiced = 0
'                v12WeekIssued = 0
'                v12WeekInvoiced = 0

'                rWeekIssued = dtWeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    vWeekIssued = rWeekIssued("invCount")
'                Catch ex As Exception
'                    vWeekIssued = 0
'                End Try
'                rWeekInvoiced = dtWeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    vWeekInvoiced = rWeekInvoiced("ttlQty") * -1
'                Catch ex As Exception
'                    vWeekInvoiced = 0
'                End Try
'                r12WeekIssued = dt12WeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    v12WeekIssued = r12WeekIssued("invCount")
'                Catch ex As Exception
'                    v12WeekIssued = 0
'                End Try
'                r12WeekInvoiced = dt12WeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    v12WeekInvoiced = r12WeekInvoiced("ttlQty") * -1
'                Catch ex As Exception
'                    v12WeekInvoiced = 0
'                End Try


'                If vWeekIssued <> 0 Or vWeekInvoiced <> 0 Or v12WeekIssued <> 0 Or v12WeekInvoiced <> 0 Then


'                    'For xCount = 0 To dtFYIssued.Rows.Count - 1
'                    'rFY_Issued = dtFYIssued.Rows(xCount)

'                    '//Iterate through items to get data
'                    'rItems = dtItems.Rows.Find(rFY_Issued("Number"))
'                    Try
'                        oSheet.Range(CStr("A" & iRow)).Value = rItems("Description").ToString
'                        oSheet.Range(CStr("B" & iRow)).Value = rItems("Number").ToString
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for issued - WEEK
'                    rWeekIssued = dtWeekIssued.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("D" & iRow)).Value = rWeekIssued("invCount") * rItems("Amount")
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for invoiced - WEEK
'                    rWeekInvoiced = dtWeekInvoiced.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("E" & iRow)).Value = rWeekInvoiced("ttlQty") * -1
'                    Catch ex As Exception
'                    End Try

'                    '//12Week
'                    ''//Get count and value for issued - WEEK
'                    r12WeekIssued = dt12WeekIssued.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("H" & iRow)).Value = r12WeekIssued("invCount") * rItems("Amount")
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for invoiced - WEEK
'                    r12WeekInvoiced = dt12WeekInvoiced.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("I" & iRow)).Value = r12WeekInvoiced("ttlQty") * -1
'                    Catch ex As Exception
'                    End Try

'                    '//FY
'                    ''//Get count and value for issued - WEEK
'                    rFYIssued = dtFYIssued.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("L" & iRow)).Value = rFYIssued("invCount") * rItems("Amount")
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for invoiced - WEEK
'                    rFYInvoiced = dtFYInvoiced.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("M" & iRow)).Value = rFYInvoiced("ttlQty") * -1
'                    Catch ex As Exception
'                    End Try

'                    iRow += 1



'                End If



'            Next


'            objXL.Visible = True

'            objXL = Nothing

'            Exit Sub



'        End Sub


'        Private Function getData(ByVal strODBC As String) As DataTable

'            Dim returnDT As New DataTable()

'            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
'            oODBConnection.Open()
'            Dim ncmd As New OdbcCommand(strODBC, oODBConnection)
'            Dim nda As New OdbcDataAdapter()
'            nda.SelectCommand = ncmd
'            Try
'                nda.Fill(returnDT)
'            Catch ex As Exception
'                MsgBox(ex.ToString)
'            End Try

'            Return returnDT

'        End Function


'        Private Sub btnValueReportComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValueReportComplete.Click


'            Dim objXL As Object
'            Dim oSheet As Object

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("r:\MaterialVarianceTemplate.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("I").NumberFormat = "0.00"
'            oSheet.Columns("J").NumberFormat = "0.00"
'            oSheet.Columns("L").NumberFormat = "0.00"
'            oSheet.Columns("M").NumberFormat = "0.00"
'            oSheet.Columns("N").NumberFormat = "0.00"

'            Dim iRow As Integer = 5

'            Dim dtWeekTransact As DataTable
'            Dim dt12WeekTransact As DataTable
'            Dim dtFYTransact As DataTable

'            Dim dtWeekIssued As New DataTable() '//January 31, 2006
'            Dim dt12WeekIssued As New DataTable() '//January 31, 2006
'            Dim dtFYIssued As New DataTable() '//January 31, 2006

'            Dim dtWeekInvoiced As New DataTable()
'            Dim dt12WeekInvoiced As New DataTable()
'            Dim dtFYInvoiced As New DataTable()

'            Dim dtItems As New DataTable() '//January 31, 2006

'            '//This is the new report for Mr. Cook
'            Dim vStart As Date = dteStart.Text
'            Dim vEnd As Date = dteEnd.Text

'            Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -85, vStart)
'            Dim v12WeekEnd As Date = DateAdd(DateInterval.Day, -1, vStart)

'            '//This must be changed to adapt for dates after January 1
'            Dim fiscalStart As Date = DateAdd(DateInterval.Day, -365, vStart)
'            'If DatePart(DateInterval.Month, vEnd) > 0 And DatePart(DateInterval.Month, vEnd) < 4 Then
'            'Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'            'fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'            'Else
'            '    fiscalStart = "04/01/" & DatePart(DateInterval.Year, vEnd)


'                '//This is to be used only for Vern Vartdals report this will add to fiscal year from last year (rollover)
'                '//April 4, 2006 - get rid of immediately
'                'Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'                'fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'                '//This is to be used only for Vern Vartdals report this will add to fiscal year from last year (rollover)
'                '//April 4, 2006 - get rid of immediately

'            'End If

'            Dim strSQL As String

'            Dim sConnectionstring As String
'            Dim objConn As New OleDbConnection()
'            Dim objCmdSelect As New OleDbCommand()
'            Dim objCmdSelect1 As New OleDbCommand()
'            Dim objAdapter1 As New OleDbDataAdapter()
'            Dim dtBin As New DataTable()
'            Dim dsBin As New DataSet()
'            Dim objDataset1 As New DataSet()
'            Dim strFileBin As String
'            Dim rBin As DataRow

'            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
'            Dim odbcStr As String

'            '//Items information
'            '//*************************************************************************
'            '//* This section builds a datatable of all items in the Navision system   *
'            '//* based on posting group of CELL PARTS OR MESS PARTS                    *
'            '//*************************************************************************
'            odbcStr = "SELECT No_ as Number, Description, ""Unit Cost"" as Amount FROM Item WHERE ""Inventory Posting Group"" IN ('CELL PARTS', 'MESS PARTS') ORDER BY ""Inventory Posting Group"", Description"
'            dtItems = getData(odbcStr)

'            Dim arrItems(0) As DataColumn
'            arrItems(0) = dtItems.Columns(0)
'            dtItems.PrimaryKey = arrItems
'            System.Windows.Forms.Application.DoEvents()


'            '//Issued Information
'            '//*************************************************************************
'            '//* Issued information for Current Week                                   *
'            '//*************************************************************************
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtWeekIssued = getData(odbcStr)
'            Dim arrPKweekIssued(0) As DataColumn
'            arrPKweekIssued(0) = dtWeekIssued.Columns(0)
'            dtWeekIssued.PrimaryKey = arrPKweekIssued
'            System.Windows.Forms.Application.DoEvents()

'            '//*************************************************************************
'            '//* Issued information for Previous 12 Week Period                        *
'            '//*************************************************************************
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dt12WeekIssued = getData(odbcStr)
'            Dim arrPK12weekIssued(0) As DataColumn
'            arrPK12weekIssued(0) = dt12WeekIssued.Columns(0)
'            dt12WeekIssued.PrimaryKey = arrPK12weekIssued
'            System.Windows.Forms.Application.DoEvents()

'            '//*************************************************************************
'            '//* Issued information for Current Fiscal Year                            *
'            '//*************************************************************************
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtFYIssued = getData(odbcStr)
'            Dim arrPKFYIssued(0) As DataColumn
'            arrPKFYIssued(0) = dtFYIssued.Columns(0)
'            dtFYIssued.PrimaryKey = arrPKFYIssued
'            System.Windows.Forms.Application.DoEvents()

'            '//Invoiced Information
'            '//*************************************************************************
'            '//* Invoiced information for Current Week                                 *
'            '//*************************************************************************
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtWeekInvoiced = getData(odbcStr)
'            Dim arrPKweekInvoiced(0) As DataColumn
'            arrPKweekInvoiced(0) = dtWeekInvoiced.Columns(0)
'            dtWeekInvoiced.PrimaryKey = arrPKweekInvoiced
'            System.Windows.Forms.Application.DoEvents()

'            '//*************************************************************************
'            '//* Invoiced information for Previous 12 Week Period                      *
'            '//*************************************************************************
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dt12WeekInvoiced = getData(odbcStr)
'            Dim arrPK12weekInvoiced(0) As DataColumn
'            arrPK12weekInvoiced(0) = dt12WeekInvoiced.Columns(0)
'            dt12WeekInvoiced.PrimaryKey = arrPK12weekInvoiced
'            System.Windows.Forms.Application.DoEvents()

'            '//*************************************************************************
'            '//* Invoiced information for Current Fiscal Year                          *
'            '//*************************************************************************
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtFYInvoiced = getData(odbcStr)
'            Dim arrPKFYInvoiced(0) As DataColumn
'            arrPKFYInvoiced(0) = dtFYInvoiced.Columns(0)
'            dtFYInvoiced.PrimaryKey = arrPKFYInvoiced
'            System.Windows.Forms.Application.DoEvents()



'            Dim mDescription As String
'            Dim mPartNumber As String
'            Dim mValue As Double

'            Dim xCount As Integer = 0
'            Dim itemCount As Integer = 0

'            'Dim rFY_Issued As DataRow
'            Dim rItems As DataRow
'            Dim rWeekIssued As DataRow
'            Dim rWeekInvoiced As DataRow
'            Dim r12WeekIssued As DataRow
'            Dim r12WeekInvoiced As DataRow
'            Dim rFYIssued As DataRow
'            Dim rFYInvoiced As DataRow

'            Dim vWeekIssued, vWeekInvoiced, v12WeekIssued, v12WeekInvoiced As Double

'            '//Get first item

'            For xCount = 0 To dtItems.Rows.Count - 1
'                rItems = dtItems.Rows(xCount)

'                Try
'                    oSheet.Range(CStr("A" & iRow)).Value = rItems("Description").ToString
'                    oSheet.Range(CStr("B" & iRow)).Value = rItems("Number").ToString
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for issued - WEEK
'                rWeekIssued = dtWeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("D" & iRow)).Value = rWeekIssued("invCount") * rItems("Amount")
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for invoiced - WEEK
'                rWeekInvoiced = dtWeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("E" & iRow)).Value = rWeekInvoiced("ttlQty") * -1
'                Catch ex As Exception
'                End Try

'                '//12Week
'                ''//Get count and value for issued - WEEK
'                r12WeekIssued = dt12WeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("H" & iRow)).Value = r12WeekIssued("invCount") * rItems("Amount")
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for invoiced - WEEK
'                r12WeekInvoiced = dt12WeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("I" & iRow)).Value = r12WeekInvoiced("ttlQty") * -1
'                Catch ex As Exception
'                End Try

'                '//FY
'                ''//Get count and value for issued - WEEK
'                rFYIssued = dtFYIssued.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("L" & iRow)).Value = rFYIssued("invCount") * rItems("Amount")
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for invoiced - WEEK
'                rFYInvoiced = dtFYInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("M" & iRow)).Value = rFYInvoiced("ttlQty") * -1
'                Catch ex As Exception
'                End Try

'                iRow += 1

'            Next


'            objXL.Visible = True

'            objXL = Nothing

'        End Sub


'        Private Sub btnItemReportComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemReportComplete.Click

'            Dim objXL As Object
'            Dim oSheet As Object

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("r:\MaterialVarianceTemplateUNITS.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0"
'            oSheet.Columns("F").NumberFormat = "0"
'            oSheet.Columns("H").NumberFormat = "0"
'            oSheet.Columns("I").NumberFormat = "0"
'            oSheet.Columns("J").NumberFormat = "0"
'            oSheet.Columns("L").NumberFormat = "0"
'            oSheet.Columns("M").NumberFormat = "0"
'            oSheet.Columns("N").NumberFormat = "0"

'            Dim iRow As Integer = 5

'            Dim dtWeekTransact As DataTable
'            Dim dt12WeekTransact As DataTable
'            Dim dtFYTransact As DataTable

'            Dim dtWeekIssued As New DataTable() '//January 31, 2006
'            Dim dt12WeekIssued As New DataTable() '//January 31, 2006
'            Dim dtFYIssued As New DataTable() '//January 31, 2006

'            Dim dtWeekInvoiced As New DataTable()
'            Dim dt12WeekInvoiced As New DataTable()
'            Dim dtFYInvoiced As New DataTable()

'            Dim dtItems As New DataTable() '//January 31, 2006

'            '//This is the new report for Mr. Cook
'            Dim vStart As Date = dteStart.Text
'            Dim vEnd As Date = dteEnd.Text

'            Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -85, vStart)
'            Dim v12WeekEnd As Date = DateAdd(DateInterval.Day, -1, vStart)

'            '//This must be changed to adapt for dates after January 1
'            Dim fiscalStart As Date = DateAdd(DateInterval.Day, -365, vStart)
'            'Dim fiscalStart As Date
'            'If DatePart(DateInterval.Month, vEnd) > 0 And DatePart(DateInterval.Month, vEnd) < 4 Then
'            'Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'            'fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'            'Else
'            '    fiscalStart = "04/01/" & DatePart(DateInterval.Year, vEnd)

'                '//This is to be used only for Vern Vartdals report this will add to fiscal year from last year (rollover)
'                '//April 4, 2006 - get rid of immediately
'                'Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'                'fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'                '//This is to be used only for Vern Vartdals report this will add to fiscal year from last year (rollover)
'                '//April 4, 2006 - get rid of immediately

'            'End If

'            Dim strSQL As String

'            Dim sConnectionstring As String
'            Dim objConn As New OleDbConnection()
'            Dim objCmdSelect As New OleDbCommand()
'            Dim objCmdSelect1 As New OleDbCommand()
'            Dim objAdapter1 As New OleDbDataAdapter()
'            Dim dtBin As New DataTable()
'            Dim dsBin As New DataSet()
'            Dim objDataset1 As New DataSet()
'            Dim strFileBin As String
'            Dim rBin As DataRow

'            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
'            Dim odbcStr As String

'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//Items information
'            odbcStr = "SELECT No_ as Number, Description, ""Unit Cost"" as Amount FROM Item WHERE ""Inventory Posting Group"" IN ('CELL PARTS', 'MESS PARTS') ORDER BY ""Inventory Posting Group"", Description"
'            dtItems = getData(odbcStr)

'            Dim arrItems(0) As DataColumn
'            arrItems(0) = dtItems.Columns(0)
'            dtItems.PrimaryKey = arrItems
'            System.Windows.Forms.Application.DoEvents()


'            '//Issued Information
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtWeekIssued = getData(odbcStr)
'            Dim arrPKweekIssued(0) As DataColumn
'            arrPKweekIssued(0) = dtWeekIssued.Columns(0)
'            dtWeekIssued.PrimaryKey = arrPKweekIssued

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dt12WeekIssued = getData(odbcStr)
'            Dim arrPK12weekIssued(0) As DataColumn
'            arrPK12weekIssued(0) = dt12WeekIssued.Columns(0)
'            dt12WeekIssued.PrimaryKey = arrPK12weekIssued

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtFYIssued = getData(odbcStr)
'            Dim arrPKFYIssued(0) As DataColumn
'            arrPKFYIssued(0) = dtFYIssued.Columns(0)
'            dtFYIssued.PrimaryKey = arrPKFYIssued


'            System.Windows.Forms.Application.DoEvents()




'            '//Invoiced Information
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtWeekInvoiced = getData(odbcStr)

'            Dim arrPKweekInvoiced(0) As DataColumn
'            arrPKweekInvoiced(0) = dtWeekInvoiced.Columns(0)
'            dtWeekInvoiced.PrimaryKey = arrPKweekInvoiced

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dt12WeekInvoiced = getData(odbcStr)
'            Dim arrPK12weekInvoiced(0) As DataColumn
'            arrPK12weekInvoiced(0) = dt12WeekInvoiced.Columns(0)
'            dt12WeekInvoiced.PrimaryKey = arrPK12weekInvoiced

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtFYInvoiced = getData(odbcStr)
'            Dim arrPKFYInvoiced(0) As DataColumn
'            arrPKFYInvoiced(0) = dtFYInvoiced.Columns(0)
'            dtFYInvoiced.PrimaryKey = arrPKFYInvoiced


'            System.Windows.Forms.Application.DoEvents()

'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________

'            Dim mDescription As String
'            Dim mPartNumber As String
'            Dim mValue As Double

'            Dim xCount As Integer = 0
'            Dim itemCount As Integer = 0

'            Dim rFY_Issued As DataRow
'            Dim rItems As DataRow
'            Dim rWeekIssued As DataRow
'            Dim rWeekInvoiced As DataRow
'            Dim r12WeekIssued As DataRow
'            Dim r12WeekInvoiced As DataRow
'            Dim rFYIssued As DataRow
'            Dim rFYInvoiced As DataRow

'            Dim vWeekIssued, vWeekInvoiced, v12WeekIssued, v12WeekInvoiced As Double

'            '//Get first item

'            For xCount = 0 To dtItems.Rows.Count - 1
'                rItems = dtItems.Rows(xCount)

'                Try
'                    oSheet.Range(CStr("A" & iRow)).Value = rItems("Description").ToString
'                    oSheet.Range(CStr("B" & iRow)).Value = rItems("Number").ToString
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for issued - WEEK
'                rWeekIssued = dtWeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("D" & iRow)).Value = rWeekIssued("invCount")
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for invoiced - WEEK
'                rWeekInvoiced = dtWeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("E" & iRow)).Value = rWeekInvoiced("invQty") * -1
'                Catch ex As Exception
'                End Try

'                '//12Week
'                ''//Get count and value for issued - WEEK
'                r12WeekIssued = dt12WeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("H" & iRow)).Value = r12WeekIssued("invCount")
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for invoiced - WEEK
'                r12WeekInvoiced = dt12WeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("I" & iRow)).Value = r12WeekInvoiced("invQty") * -1
'                Catch ex As Exception
'                End Try

'                '//FY
'                ''//Get count and value for issued - WEEK
'                rFYIssued = dtFYIssued.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("L" & iRow)).Value = rFYIssued("invCount")
'                Catch ex As Exception
'                End Try

'                ''//Get count and value for invoiced - WEEK
'                rFYInvoiced = dtFYInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    oSheet.Range(CStr("M" & iRow)).Value = rFYInvoiced("invQty") * -1
'                Catch ex As Exception
'                End Try

'                iRow += 1

'            Next


'            objXL.Visible = True

'            objXL = Nothing


'        End Sub

'        Private Sub btnItemReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemReport.Click

'            Dim objXL As Object
'            Dim oSheet As Object

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("r:\MaterialVarianceTemplateUNITS.xls")
'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0"
'            oSheet.Columns("F").NumberFormat = "0"
'            oSheet.Columns("H").NumberFormat = "0"
'            oSheet.Columns("I").NumberFormat = "0"
'            oSheet.Columns("J").NumberFormat = "0"
'            oSheet.Columns("L").NumberFormat = "0"
'            oSheet.Columns("M").NumberFormat = "0"
'            oSheet.Columns("N").NumberFormat = "0"

'            Dim iRow As Integer = 5

'            Dim dtWeekTransact As DataTable
'            Dim dt12WeekTransact As DataTable
'            Dim dtFYTransact As DataTable

'            Dim dtWeekIssued As New DataTable() '//January 31, 2006
'            Dim dt12WeekIssued As New DataTable() '//January 31, 2006
'            Dim dtFYIssued As New DataTable() '//January 31, 2006

'            Dim dtWeekInvoiced As New DataTable()
'            Dim dt12WeekInvoiced As New DataTable()
'            Dim dtFYInvoiced As New DataTable()

'            Dim dtItems As New DataTable() '//January 31, 2006

'            '//This is the new report for Mr. Cook
'            Dim vStart As Date = dteStart.Text
'            Dim vEnd As Date = dteEnd.Text

'            Dim v12WeekStart As Date = DateAdd(DateInterval.Day, -85, vStart)
'            Dim v12WeekEnd As Date = DateAdd(DateInterval.Day, -1, vStart)

'            '//This must be changed to adapt for dates after January 1
'            Dim fiscalStart As Date
'            If DatePart(DateInterval.Month, vEnd) > 0 And DatePart(DateInterval.Month, vEnd) < 4 Then
'                Dim tmpDate As Date = DateAdd(DateInterval.Year, -1, vEnd)
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, tmpDate)
'            Else
'                fiscalStart = "04/01/" & DatePart(DateInterval.Year, vEnd)
'            End If

'            Dim strSQL As String

'            Dim sConnectionstring As String
'            Dim objConn As New OleDbConnection()
'            Dim objCmdSelect As New OleDbCommand()
'            Dim objCmdSelect1 As New OleDbCommand()
'            Dim objAdapter1 As New OleDbDataAdapter()
'            Dim dtBin As New DataTable()
'            Dim dsBin As New DataSet()
'            Dim objDataset1 As New DataSet()
'            Dim strFileBin As String
'            Dim rBin As DataRow

'            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
'            Dim odbcStr As String

'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//Items information
'            odbcStr = "SELECT No_ as Number, Description, ""Unit Cost"" as Amount FROM Item WHERE ""Inventory Posting Group"" IN ('CELL PARTS', 'MESS PARTS') ORDER BY ""Inventory Posting Group"", Description"
'            dtItems = getData(odbcStr)

'            Dim arrItems(0) As DataColumn
'            arrItems(0) = dtItems.Columns(0)
'            dtItems.PrimaryKey = arrItems
'            System.Windows.Forms.Application.DoEvents()


'            '//Issued Information
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtWeekIssued = getData(odbcStr)
'            Dim arrPKweekIssued(0) As DataColumn
'            arrPKweekIssued(0) = dtWeekIssued.Columns(0)
'            dtWeekIssued.PrimaryKey = arrPKweekIssued

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dt12WeekIssued = getData(odbcStr)
'            Dim arrPK12weekIssued(0) As DataColumn
'            arrPK12weekIssued(0) = dt12WeekIssued.Columns(0)
'            dt12WeekIssued.PrimaryKey = arrPK12weekIssued

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(Quantity) as invCount FROM ""Warehouse Entry"" WHERE (""Source No_""<'PSSA' OR ""Source No_"">'PSSZ') AND ""Registering Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Registering Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Bin Code"" > 'SFA' AND ""Bin Code"" < 'SFZ' GROUP BY ""Item No_"""
'            dtFYIssued = getData(odbcStr)
'            Dim arrPKFYIssued(0) As DataColumn
'            arrPKFYIssued(0) = dtFYIssued.Columns(0)
'            dtFYIssued.PrimaryKey = arrPKFYIssued


'            System.Windows.Forms.Application.DoEvents()




'            '//Invoiced Information
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(vStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtWeekInvoiced = getData(odbcStr)

'            Dim arrPKweekInvoiced(0) As DataColumn
'            arrPKweekInvoiced(0) = dtWeekInvoiced.Columns(0)
'            dtWeekInvoiced.PrimaryKey = arrPKweekInvoiced

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(v12WeekStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(v12WeekEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dt12WeekInvoiced = getData(odbcStr)
'            Dim arrPK12weekInvoiced(0) As DataColumn
'            arrPK12weekInvoiced(0) = dt12WeekInvoiced.Columns(0)
'            dt12WeekInvoiced.PrimaryKey = arrPK12weekInvoiced

'            System.Windows.Forms.Application.DoEvents()
'            odbcStr = "SELECT ""Item No_"" as Number, SUM(""Cost Posted to G/L"") AS ttlQty, SUM(""Invoiced Quantity"") as InvQty FROM ""Value Entry"" WHERE ""Posting Date"">= '" & Format(fiscalStart, "yyyy-MM-dd") & "' AND ""Posting Date"" <= '" & Format(vEnd, "yyyy-MM-dd") & "' AND ""Document No_"" = 'PSSINET00001' AND ""Cost Posted to G/L"" < 0 GROUP BY ""Item No_"""
'            dtFYInvoiced = getData(odbcStr)
'            Dim arrPKFYInvoiced(0) As DataColumn
'            arrPKFYInvoiced(0) = dtFYInvoiced.Columns(0)
'            dtFYInvoiced.PrimaryKey = arrPKFYInvoiced


'            System.Windows.Forms.Application.DoEvents()

'            'Exit Sub

'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________
'            '//___________________________________________________________________


'            Dim mDescription As String
'            Dim mPartNumber As String
'            Dim mValue As Double



'            Dim xCount As Integer = 0
'            Dim itemCount As Integer = 0


'            Dim rFY_Issued As DataRow
'            Dim rItems As DataRow
'            Dim rWeekIssued As DataRow
'            Dim rWeekInvoiced As DataRow
'            Dim r12WeekIssued As DataRow
'            Dim r12WeekInvoiced As DataRow
'            Dim rFYIssued As DataRow
'            Dim rFYInvoiced As DataRow

'            Dim vWeekIssued, vWeekInvoiced, v12WeekIssued, v12WeekInvoiced As Integer

'            '//Get first FY entry

'            For xCount = 0 To dtItems.Rows.Count - 1
'                rItems = dtItems.Rows(xCount)


'                vWeekIssued = 0
'                vWeekInvoiced = 0
'                v12WeekIssued = 0
'                v12WeekInvoiced = 0

'                rWeekIssued = dtWeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    vWeekIssued = rWeekIssued("invCount")
'                Catch ex As Exception
'                    vWeekIssued = 0
'                End Try
'                rWeekInvoiced = dtWeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    vWeekInvoiced = rWeekInvoiced("invQty")
'                Catch ex As Exception
'                    vWeekInvoiced = 0
'                End Try
'                r12WeekIssued = dt12WeekIssued.Rows.Find(rItems("Number"))
'                Try
'                    v12WeekIssued = r12WeekIssued("invCount")
'                Catch ex As Exception
'                    v12WeekIssued = 0
'                End Try
'                r12WeekInvoiced = dt12WeekInvoiced.Rows.Find(rItems("Number"))
'                Try
'                    v12WeekInvoiced = r12WeekInvoiced("invQty")
'                Catch ex As Exception
'                    v12WeekInvoiced = 0
'                End Try


'                If vWeekIssued <> 0 Or vWeekInvoiced <> 0 Or v12WeekIssued <> 0 Or v12WeekInvoiced <> 0 Then


'                    'For xCount = 0 To dtFYIssued.Rows.Count - 1
'                    'rFY_Issued = dtFYIssued.Rows(xCount)

'                    '//Iterate through items to get data
'                    'rItems = dtItems.Rows.Find(rFY_Issued("Number"))
'                    Try
'                        oSheet.Range(CStr("A" & iRow)).Value = rItems("Description").ToString
'                        oSheet.Range(CStr("B" & iRow)).Value = rItems("Number").ToString
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for issued - WEEK
'                    rWeekIssued = dtWeekIssued.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("D" & iRow)).Value = rWeekIssued("invCount")
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for invoiced - WEEK
'                    rWeekInvoiced = dtWeekInvoiced.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("E" & iRow)).Value = rWeekInvoiced("invQty") * -1
'                    Catch ex As Exception
'                    End Try

'                    '//12Week
'                    ''//Get count and value for issued - WEEK
'                    r12WeekIssued = dt12WeekIssued.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("H" & iRow)).Value = r12WeekIssued("invCount")
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for invoiced - WEEK
'                    r12WeekInvoiced = dt12WeekInvoiced.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("I" & iRow)).Value = r12WeekInvoiced("invQty") * -1
'                    Catch ex As Exception
'                    End Try

'                    '//FY
'                    ''//Get count and value for issued - WEEK
'                    rFYIssued = dtFYIssued.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("L" & iRow)).Value = rFYIssued("invCount")
'                    Catch ex As Exception
'                    End Try

'                    ''//Get count and value for invoiced - WEEK
'                    rFYInvoiced = dtFYInvoiced.Rows.Find(rItems("Number"))
'                    Try
'                        oSheet.Range(CStr("M" & iRow)).Value = rFYInvoiced("invQty") * -1
'                    Catch ex As Exception
'                    End Try

'                    iRow += 1

'                End If

'            Next


'            objXL.Visible = True

'            objXL = Nothing

'            Exit Sub

'        End Sub


'        Private Sub btnBounceReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBounceReport.Click

'            Dim objXL As Object
'            Dim oSheet As Object
'            Dim intRow As Integer = 5
'            Dim dblBounceRate As Double

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.workbooks.add()
'            'objXL.Workbooks.Open("r:\PalletTemplate.xls")

'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "@"
'            oSheet.Columns("E").NumberFormat = "0"
'            oSheet.Columns("F").NumberFormat = "0"
'            oSheet.Columns("G").NumberFormat = "0"

'            '//This is to format the sheet - removing the need for a template file - BEGIN

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "BOUNCE REPORT CELLULAR"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = ""
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "WEEK START"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "WEEK ENDING"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "CUSTOMER"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "LOCATION"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "RECORD COUNT"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "NUMBER BOUNCE"
'            oSheet.Range("G4").Select()
'            oSheet.range("G4").FormulaR1C1 = "BOUNCE RATE"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 25
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 25
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 25
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 25
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 25
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 25
'            oSheet.Columns("G:G").Select()
'            oSheet.Columns("G:G").ColumnWidth = 25
'            oSheet.Range("A4:G4").Select()

'            With oSheet.range("A4:G4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:G4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:G4").Select()

'            objXL.Sheets("Sheet1").Select()
'            oSheet = objXL.Worksheets(1)
'            oSheet.Range("A1").Select()
'            '//This is to format the sheet - removing the need for a template file - END






'            Dim ds As New PSS.Data.Production.Joins()
'            Dim dtCountComplete, dtCountLocation As DataTable
'            Dim r1, r2 As DataRow

'            Dim vDate, vDateStartCheckBounce, vDateStartWeek, vDateEndWeek As Date
'            Dim strSQL, mLocationName, mCustomerName As String
'            Dim count1, count2, mLocation, int, intBounce As Integer

'            Try
'                vDate = InputBox("Enter last date of cycle:", "DATE")
'            Catch ex As Exception
'                MsgBox("Date is invalid...Exiting...", MsgBoxStyle.OKOnly, "ERROR")
'                Exit Sub
'            End Try


'            'vDateStartCheckBounce = DateAdd(DateInterval.Day, -90, vDate)
'            'strSQL = "select loc_id, device_sn, count(device_sn) as bounceRate, max(device_daterec) as maxDate from " & _
'            '         "tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            '         "where tdevice.device_daterec > '" & Gui.Receiving.FormatDateShort(vDateStartCheckBounce) & " 00:00:00' " & _
'            '         "and tmodel.prod_id = 2 " & _
'            '         "group by loc_id, device_sn " & _
'            '         "order by bounceRate desc, maxdate desc"
'            'dtCountLocation = ds.OrderEntrySelectRep(strSQL)
'            'System.Windows.Forms.Application.DoEvents()

'            For int = 0 To 12

'                vDateStartCheckBounce = DateAdd(DateInterval.Day, -90, vDate)
'                strSQL = "select loc_id, device_sn, count(device_sn) as bounceRate, max(device_daterec) as maxDate from " & _
'                         "tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                         "where tdevice.device_daterec > '" & Gui.Receiving.FormatDateShort(vDateStartCheckBounce) & " 00:00:00' " & _
'                         "and tmodel.prod_id = 2 " & _
'                         "group by loc_id, device_sn " & _
'                         "order by bounceRate desc, maxdate desc"
'                dtCountLocation = ds.OrderEntrySelect(strSQL)
'                System.Windows.Forms.Application.DoEvents()


'                vDateEndWeek = vDate
'                vDateStartWeek = DateAdd(DateInterval.Day, -6, vDate)

'                strSQL = "select tdevice.loc_id, loc_name, tcustomer.cust_name1, count(device_id) as recordcount from tdevice " & _
'                         "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                         "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
'                         "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
'                         "where device_daterec > '" & Gui.Receiving.FormatDateShort(vDateStartWeek) & " 00:00:00' " & _
'                         "and device_daterec < '" & Gui.Receiving.FormatDateShort(vDateEndWeek) & " 23:59:59' " & _
'                         "and tmodel.prod_id = 2 " & _
'                         "group by tdevice.loc_id"
'                dtCountComplete = ds.OrderEntrySelect(strSQL)


'                For count1 = 0 To dtCountComplete.Rows.Count - 1
'                    r1 = dtCountComplete.Rows(count1)
'                    mLocation = r1("Loc_ID")
'                    mLocationName = r1("Loc_Name")
'                    mCustomerName = r1("Cust_Name1")

'                    intBounce = 0
'                    '//Get data for this location for this week


'                    For count2 = 0 To dtCountLocation.Rows.Count - 1
'                        r2 = dtCountLocation.Rows(count2)
'                        If r2("maxdate") > vDateStartWeek And r2("maxdate") < vDateEndWeek And r2("bounceRate") > 1 And r2("Loc_ID") = mLocation Then
'                            intBounce += 1
'                        End If
'                    Next
'                    '//Write the values out
'                    'MsgBox(mCustomerName & "    " & mLocationName & "    " & r1("recordcount") & "    " & intBounce)
'                    oSheet.Range(CStr("A" & intRow)).Value = vDateStartWeek.ToString
'                    oSheet.Range(CStr("B" & intRow)).Value = vDateEndWeek.ToString
'                    oSheet.Range(CStr("C" & intRow)).Value = mCustomerName.ToString
'                    oSheet.Range(CStr("D" & intRow)).Value = mLocationName.ToString
'                    oSheet.Range(CStr("E" & intRow)).Value = r1("recordcount").ToString
'                    oSheet.Range(CStr("F" & intRow)).Value = intBounce.ToString
'                    dblBounceRate = (intBounce * 100) / r1("recordcount")
'                    System.Windows.Forms.Application.DoEvents()
'                    oSheet.Range(CStr("G" & intRow)).Value = dblBounceRate.ToString

'                    intRow += 1

'                Next

'                '//Before going to new week determine new vDate
'                vDate = DateAdd(DateInterval.Day, -1, vDateStartWeek)
'            Next

'            oSheet.Range("A4:G" & intRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With

'            objXL.visible = True
'            objXL = Nothing

'        End Sub




'        Private Sub btnMcVeyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        End Sub

'        Private Sub btnTechnician_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTechnician.Click

'            Dim objXL As Object
'            Dim oSheet As Object

'            Dim vStart As String
'            'vStart = "2006-06-12"
'            vStart = Gui.Receiving.FormatDateShort(Me.dteStart.Text)
'            Dim vEnd As String
'            'vEnd = "2006-06-18"
'            vEnd = Gui.Receiving.FormatDateShort(Me.dteEnd.Text)
'            Dim mGroupID As Integer = 2

'            '//______________________________________
'            Dim dsEmp As PSS.Data.Production.Joins
'            Dim empCount As Integer = 0
'            Dim rEmpCount As DataRow
'            Dim strHours As String = "SELECT employee_no, SUM(techhours_hours) as ttlHours FROM ttechhours WHERE techhours_date >= '" & vStart & "' AND techhours_date <= '" & vEnd & "' GROUP BY employee_no"
'            Dim dtEmp As DataTable
'            dtEmp = dsEmp.OrderEntrySelect(strHours)
'            '//______________________________________



'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("C:\Template_TechReport.xls")
'            oSheet = objXL.Worksheets(1)

'            Dim iRow As Integer = 4

'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String
'            strSQL = "select distinct tparttransaction.user_id, security.tusers.user_fullname, security.tusers.employeeno, lbillcodes.billtype_id, sum(tdevicebill.dbill_invoiceamt) as cParts, security.tusers.shift_id from " & _
'"tparttransaction inner join tdevicebill on (tparttransaction.device_id = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id) " & _
'"inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
'"inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'"where workdate >= '" & vStart & "' " & _
'"and workdate <= '" & vEnd & "' " & _
'"and trans_amount = 1 " & _
'"and lbillcodes.billtype_id = 2 " & _
'"and security.tusers.shift_id in (1,2,3) and security.tusers.group_id = " & mGroupID & " " & _
'"group by tparttransaction.user_id, lbillcodes.billtype_id " & _
'"order by security.tusers.shift_id, security.tusers.user_fullname"

'            Dim dtParts As DataTable = ds.OrderEntrySelect(strSQL)

'            strSQL = "select distinct tparttransaction.user_id, security.tusers.user_fullname, security.tusers.employeeno, lbillcodes.billtype_id, sum(tdevicebill.dbill_invoiceamt) as mReject from " & _
'            "tparttransaction inner join tdevicebill on (tparttransaction.device_id = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id) " & _
'"inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
'"inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'"inner join tqc on tparttransaction.device_id = tqc.device_id " & _
'"where workdate >= '" & vStart & "' " & _
'"and workdate <= '" & vEnd & "' " & _
'"and trans_amount = 1 " & _
'"and lbillcodes.billtype_id = 2 " & _
'"and tqc.qcresult_id = 2 " & _
'"group by tparttransaction.user_id"

'            Dim dtPartsReject As DataTable = ds.OrderEntrySelect(strSQL)

'            Dim rParts, rPartsReject As DataRow
'            Dim xCount, xCountReject As Integer
'            Dim dtLabor As DataTable
'            Dim dtService As DataTable
'            Dim rService As DataRow
'            Dim ttlService As Double
'            Dim dtServiceReject As DataTable
'            Dim rServiceReject As DataRow
'            Dim ttlServiceReject As Double

'            Dim dtRejectDeviceCount As DataTable

'            Dim zCount As Integer = 0


'            For xCount = 0 To dtParts.Rows.Count - 1
'                rParts = dtParts.Rows(xCount)

'                If mGroupID = 2 Then
'                    oSheet.Range(CStr("A1")).Value = "Technician Report - Robert McVey"
'                    oSheet.Range(CStr("A2")).Value = "From: " & vStart & " To: " & vEnd
'                ElseIf mGroupID = 3 Then
'                    oSheet.Range(CStr("A1")).Value = "Technician Report - Todd Smith"
'                    oSheet.Range(CStr("A2")).Value = "From: " & vStart & " To: " & vEnd
'                ElseIf mGroupID = 4 Then
'                    oSheet.Range(CStr("A1")).Value = "Technician Report - Robert McVey/Rick Staton"
'                    oSheet.Range(CStr("A2")).Value = "From: " & vStart & " To: " & vEnd
'                End If

'                oSheet.Range(CStr("A" & iRow)).Value = rParts("Shift_ID").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = rParts("user_fullname").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = rParts("EmployeeNo").ToString

'                oSheet.Range(CStr("D" & iRow)).Value = 0

'                '//______________________________________
'                For empCount = 0 To dtEmp.Rows.Count - 1
'                    rEmpCount = dtEmp.Rows(empCount)
'                    If rEmpCount("Employee_no") = rParts("EmployeeNo").ToString Then
'                        oSheet.Range(CStr("D" & iRow)).Value = rEmpCount("ttlhours").ToString
'                        Exit For
'                    End If
'                Next
'                '//______________________________________


'                oSheet.Range(CStr("H" & iRow)).Value = rParts("cParts").ToString


'                strSQL = "select distinct tdevice.device_id, tparttransaction.user_id, max(tdevice.device_laborcharge) as mService from " & _
'                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
'                         "where workdate >= '" & vStart & "' " & _
'                         "and workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID") & " " & _
'                         "group by tparttransaction.user_id, tdevice.device_id"

'                dtService = ds.OrderEntrySelect(strSQL)

'                ttlService = 0
'                For zCount = 0 To dtService.Rows.Count - 1
'                    rService = dtService.Rows(zCount)
'                    ttlService += rService("mService")
'                Next
'                oSheet.Range(CStr("E" & iRow)).Value = dtService.Rows.Count
'                oSheet.Range(CStr("G" & iRow)).Value = CStr(ttlService)
'                ttlService = 0



'                strSQL = "select distinct tdevice.device_id, tdevice.device_laborcharge as mService from " & _
'                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
'                         "inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'                         "inner join tqc on tparttransaction.device_id = tqc.device_id " & _
'                         "where qc_workdate >= '" & vStart & "' " & _
'                         "and qc_workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID") & " " & _
'                         "and tqc.qcresult_id = 2"

'                dtServiceReject = ds.OrderEntrySelect(strSQL)

'                strSQL = "select distinct device_id from " & _
'                         "tqc " & _
'                         "where qc_workdate >= '" & vStart & "' " & _
'                         "and qc_workdate <= '" & vEnd & "' " & _
'                         "and tqc.tech_id = " & rParts("User_ID") & " " & _
'                         "and tqc.qcresult_id = 2"


'                dtRejectDeviceCount = ds.OrderEntrySelect(strSQL)

'                ttlServiceReject = 0
'                For zCount = 0 To dtServiceReject.Rows.Count - 1
'                    rServiceReject = dtServiceReject.Rows(zCount)
'                    ttlServiceReject += rServiceReject("mService")
'                Next
'                'oSheet.Range(CStr("L" & iRow)).Value = dtServiceReject.Rows.Count
'                oSheet.Range(CStr("L" & iRow)).Value = dtRejectDeviceCount.Rows.Count
'                oSheet.Range(CStr("M" & iRow)).Value = CStr(ttlServiceReject)
'                ttlServiceReject = 0

'                strSQL = "select distinct tdevicebill.device_id, tdevicebill.billcode_id, tparttransaction.user_id, security.tusers.user_fullname, security.tusers.employeeno, lbillcodes.billtype_id, tdevicebill.dbill_invoiceamt as mPartReject from " & _
'                         "tparttransaction inner join tdevicebill on (tparttransaction.device_id = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id) " & _
'                         "inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
'                         "inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'                         "inner join tqc on tparttransaction.device_id = tqc.device_id " & _
'                         "where qc_workdate >= '" & vStart & "' " & _
'                         "and qc_workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and lbillcodes.billtype_id = 2 " & _
'                         "and tqc.qcresult_id = 2 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID")


'                dtPartsReject = ds.OrderEntrySelect(strSQL)

'                Dim vPartsReject As Double = 0

'                For xCountReject = 0 To dtPartsReject.Rows.Count - 1
'                    rPartsReject = dtPartsReject.Rows(xCountReject)
'                    If rPartsReject("user_id") = rParts("user_id") Then
'                        vPartsReject += rPartsReject("mPartReject")
'                    End If
'                Next
'                oSheet.Range(CStr("N" & iRow)).Value = vPartsReject
'                vPartsReject = 0

'                iRow += 1

'            Next

'            objXL.visible = True


'        End Sub


'        Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


'            Dim objXL As Object
'            Dim oSheet As Object

'            Dim vStart As String
'            'vStart = "2006-06-12"
'            vStart = Gui.Receiving.FormatDateShort(Me.dteStart.Text)
'            Dim vEnd As String
'            'vEnd = "2006-06-18"
'            vEnd = Gui.Receiving.FormatDateShort(Me.dteEnd.Text)
'            'Dim mGroupID As Integer = 2
'            Dim mGroupID As Integer = CInt(txtGroup.Text)

'            '//______________________________________
'            Dim dsEmp As PSS.Data.Production.Joins
'            Dim empCount As Integer = 0
'            Dim rEmpCount As DataRow
'            Dim strHours As String = "SELECT employee_no, SUM(techhours_hours) as ttlHours FROM ttechhours WHERE techhours_date >= '" & vStart & "' AND techhours_date <= '" & vEnd & "' GROUP BY employee_no"
'            Dim dtEmp As DataTable
'            dtEmp = dsEmp.OrderEntrySelect(strHours)
'            '//______________________________________

'            Dim dtRTM As DataTable
'            Dim dtRUR As DataTable

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.Workbooks.Open("C:\Template_TechReport_NEW.xls")
'            oSheet = objXL.Worksheets(1)

'            Dim iRow As Integer = 4

'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String
'            strSQL = "select distinct tparttransaction.user_id, security.tusers.user_fullname, security.tusers.employeeno, lbillcodes.billtype_id, sum(tdevicebill.dbill_invoiceamt) as cParts, security.tusers.shift_id from " & _
'"tparttransaction inner join tdevicebill on (tparttransaction.device_id = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id) " & _
'"inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
'"inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'"where workdate >= '" & vStart & "' " & _
'"and workdate <= '" & vEnd & "' " & _
'"and trans_amount = 1 " & _
'"and lbillcodes.billtype_id = 2 " & _
'"and security.tusers.shift_id in (1,2,3) and security.tusers.group_id = " & mGroupID & " " & _
'"group by tparttransaction.user_id, lbillcodes.billtype_id " & _
'"order by security.tusers.shift_id, security.tusers.user_fullname"

'            Dim dtParts As DataTable = ds.OrderEntrySelect(strSQL)

'            strSQL = "select distinct tparttransaction.user_id, security.tusers.user_fullname, security.tusers.employeeno, lbillcodes.billtype_id, sum(tdevicebill.dbill_invoiceamt) as mReject from " & _
'            "tparttransaction inner join tdevicebill on (tparttransaction.device_id = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id) " & _
'"inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
'"inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'"inner join tqc on tparttransaction.device_id = tqc.device_id " & _
'"where workdate >= '" & vStart & "' " & _
'"and workdate <= '" & vEnd & "' " & _
'"and trans_amount = 1 " & _
'"and lbillcodes.billtype_id = 2 " & _
'"and tqc.qcresult_id = 2 " & _
'"group by tparttransaction.user_id"

'            Dim dtPartsReject As DataTable = ds.OrderEntrySelect(strSQL)

'            Dim rParts, rPartsReject As DataRow
'            Dim xCount, xCountReject As Integer
'            Dim dtLabor As DataTable
'            Dim dtService As DataTable
'            Dim rService As DataRow
'            Dim ttlService As Double
'            Dim dtServiceReject As DataTable
'            Dim rServiceReject As DataRow
'            Dim ttlServiceReject As Double

'            Dim dtRejectDeviceCount As DataTable

'            Dim zCount As Integer = 0


'            For xCount = 0 To dtParts.Rows.Count - 1
'                rParts = dtParts.Rows(xCount)

'                If mGroupID = 2 Then
'                    oSheet.Range(CStr("A1")).Value = "Technician Report - Robert McVey"
'                    oSheet.Range(CStr("A2")).Value = "From: " & vStart & " To: " & vEnd
'                ElseIf mGroupID = 3 Then
'                    oSheet.Range(CStr("A1")).Value = "Technician Report - Todd Smith"
'                    oSheet.Range(CStr("A2")).Value = "From: " & vStart & " To: " & vEnd
'                ElseIf mGroupID = 4 Then
'                    oSheet.Range(CStr("A1")).Value = "Technician Report - Robert McVey/Rick Staton"
'                    oSheet.Range(CStr("A2")).Value = "From: " & vStart & " To: " & vEnd
'                End If

'                oSheet.Range(CStr("A" & iRow)).Value = rParts("Shift_ID").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = rParts("user_fullname").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = rParts("EmployeeNo").ToString

'                oSheet.Range(CStr("D" & iRow)).Value = 0

'                '//______________________________________
'                For empCount = 0 To dtEmp.Rows.Count - 1
'                    rEmpCount = dtEmp.Rows(empCount)
'                    If rEmpCount("Employee_no") = rParts("EmployeeNo").ToString Then
'                        oSheet.Range(CStr("D" & iRow)).Value = rEmpCount("ttlhours").ToString
'                        Exit For
'                    End If
'                Next
'                '//______________________________________


'                oSheet.Range(CStr("H" & iRow)).Value = rParts("cParts").ToString


'                strSQL = "select distinct tdevice.device_id, tparttransaction.user_id, max(tdevice.device_laborcharge) as mService from " & _
'                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
'                         "where workdate >= '" & vStart & "' " & _
'                         "and workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID") & " " & _
'                         "group by tparttransaction.user_id, tdevice.device_id"

'                dtService = ds.OrderEntrySelect(strSQL)

'                ttlService = 0
'                For zCount = 0 To dtService.Rows.Count - 1
'                    rService = dtService.Rows(zCount)
'                    ttlService += rService("mService")
'                Next
'                oSheet.Range(CStr("E" & iRow)).Value = dtService.Rows.Count
'                oSheet.Range(CStr("G" & iRow)).Value = CStr(ttlService)
'                ttlService = 0



'                '//New for RTM Counts
'                strSQL = "select distinct tdevice.device_id from " & _
'                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
'                         "INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                         "where workdate >= '" & vStart & "' " & _
'                         "and workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID") & " " & _
'                         "and tdevicebill.billcode_id = 466 " & _
'                         "group by tparttransaction.user_id, tdevice.device_id"


'                dtRTM = ds.OrderEntrySelect(strSQL)
'                oSheet.Range(CStr("L" & iRow)).Value = dtRTM.Rows.Count
'                '//New for RTM Counts

'                '//New for RUR Counts
'                strSQL = "select distinct tdevice.device_id from " & _
'                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
'                         "INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                         "INNER JOIN lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'                         "where workdate >= '" & vStart & "' " & _
'                         "and workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID") & " " & _
'                         "and lbillcodes.billcode_rule in (1,2) " & _
'                         "group by tparttransaction.user_id, tdevice.device_id"


'                dtRUR = ds.OrderEntrySelect(strSQL)
'                oSheet.Range(CStr("M" & iRow)).Value = dtRUR.Rows.Count
'                '//New for RUR Counts



'                strSQL = "select distinct tdevice.device_id, tdevice.device_laborcharge as mService from " & _
'                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
'                         "inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'                         "inner join tqc on tparttransaction.device_id = tqc.device_id " & _
'                         "where qc_workdate >= '" & vStart & "' " & _
'                         "and qc_workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID") & " " & _
'                         "and tqc.qcresult_id = 2"

'                dtServiceReject = ds.OrderEntrySelect(strSQL)

'                strSQL = "select distinct device_id from " & _
'                         "tqc " & _
'                         "where qc_workdate >= '" & vStart & "' " & _
'                         "and qc_workdate <= '" & vEnd & "' " & _
'                         "and tqc.tech_id = " & rParts("User_ID") & " " & _
'                         "and tqc.qcresult_id = 2"


'                dtRejectDeviceCount = ds.OrderEntrySelect(strSQL)

'                ttlServiceReject = 0
'                For zCount = 0 To dtServiceReject.Rows.Count - 1
'                    rServiceReject = dtServiceReject.Rows(zCount)
'                    ttlServiceReject += rServiceReject("mService")
'                Next
'                'oSheet.Range(CStr("L" & iRow)).Value = dtServiceReject.Rows.Count
'                oSheet.Range(CStr("N" & iRow)).Value = dtRejectDeviceCount.Rows.Count
'                oSheet.Range(CStr("P" & iRow)).Value = CStr(ttlServiceReject)
'                ttlServiceReject = 0

'                strSQL = "select distinct tdevicebill.device_id, tdevicebill.billcode_id, tparttransaction.user_id, security.tusers.user_fullname, security.tusers.employeeno, lbillcodes.billtype_id, tdevicebill.dbill_invoiceamt as mPartReject from " & _
'                         "tparttransaction inner join tdevicebill on (tparttransaction.device_id = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id) " & _
'                         "inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
'                         "inner join security.tusers on tparttransaction.user_id = security.tusers.user_id " & _
'                         "inner join tqc on tparttransaction.device_id = tqc.device_id " & _
'                         "where qc_workdate >= '" & vStart & "' " & _
'                         "and qc_workdate <= '" & vEnd & "' " & _
'                         "and trans_amount = 1 " & _
'                         "and lbillcodes.billtype_id = 2 " & _
'                         "and tqc.qcresult_id = 2 " & _
'                         "and tparttransaction.user_id = " & rParts("User_ID")

'                dtPartsReject = ds.OrderEntrySelect(strSQL)

'                Dim vPartsReject As Double = 0

'                For xCountReject = 0 To dtPartsReject.Rows.Count - 1
'                    rPartsReject = dtPartsReject.Rows(xCountReject)
'                    If rPartsReject("user_id") = rParts("user_id") Then
'                        vPartsReject += rPartsReject("mPartReject")
'                    End If
'                Next
'                oSheet.Range(CStr("Q" & iRow)).Value = vPartsReject
'                vPartsReject = 0

'                iRow += 1

'            Next

'            objXL.visible = True

'        End Sub

'        Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

'            Dim strPath As String = "R:\ATCLE\Dock Receiving\zConsolidated\"
'            Dim strFile As String = Dir(strpath)




'            Dim objXL, objXLSource As Object
'            Dim oSheet, oSheetSource As Object

'            objXLSource = CreateObject("Excel.Application")
'            objXLSource.Workbooks.Open("c:\mainDATA.xls")
'            oSheetSource = objXLsource.Worksheets(1)

'            objXL = CreateObject("Excel.Application")





'            Dim iRow As Integer = 5
'            Dim iRowSource As Integer = 5


'            objXLSource.visible = True


'            Do Until strFile = ""

'                objXL.Workbooks.Open(strPath & strFile)
'                oSheet = objXL.Worksheets(1)

'                Do Until Len(Trim(oSheet.RANGE(CStr("A" & iRow)).Value)) = 0
'                    oSheetSource.Range(CStr("A" & iRowSource)).Value = oSheet.Range(CStr("A" & iRow)).Value
'                    oSheetSource.Range(CStr("B" & iRowSource)).Value = oSheet.Range(CStr("B" & iRow)).Value
'                    oSheetSource.Range(CStr("C" & iRowSource)).Value = oSheet.Range(CStr("C" & iRow)).Value
'                    oSheetSource.Range(CStr("D" & iRowSource)).Value = oSheet.Range(CStr("D" & iRow)).Value
'                    oSheetSource.Range(CStr("E" & iRowSource)).Value = oSheet.Range(CStr("E" & iRow)).Value
'                    oSheetSource.Range(CStr("F" & iRowSource)).Value = oSheet.Range(CStr("F" & iRow)).Value
'                    oSheetSource.Range(CStr("G" & iRowSource)).Value = oSheet.Range(CStr("G" & iRow)).Value
'                    oSheetSource.Range(CStr("H" & iRowSource)).Value = oSheet.Range(CStr("H" & iRow)).Value
'                    oSheetSource.Range(CStr("I" & iRowSource)).Value = strFile

'                    iRow += 1
'                    iRowSource += 1
'                Loop



'                objXL.workbooks.close()

'                iRow = 5
'                strFile = Dir()
'            Loop






'        End Sub

'        Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click


'            Dim objXL As Object


'            Dim oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim r1, r2 As DataRow
'            Dim dt1, dt2 As DataTable
'            Dim strSQL As String
'            Dim x1, x2 As Integer

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            'objXL.workbooks.add()
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            oSheet = oWorkbook.Worksheets(1)


'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0.00"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"

'            '//This is to format the sheet - removing the need for a template file - BEGIN

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY DEPARTMENT"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "LABOR"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "PARTS"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 15
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 10
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Range("A4:E4").Select()

'            With oSheet.range("A4:E4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:E4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:E4").Select()





'            Dim iRow As Integer = 5

'            '//Messaging count
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.device_id is null " & _
'            "group by tworkorder.group_id " & _
'            "order by tdevice.device_id"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Messaging Parts
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.device_id is null " & _
'            "group by tworkorder.group_id " & _
'            "order by tdevice.device_id"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("vCount").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) Then
'                        oSheet.Range(CStr("D" & iRow)).Value = r2("vParts").ToString
'                        oSheet.Range(CStr("E" & iRow)).Value = CInt(r2("vParts").ToString) + CInt(r1("vLabor").ToString)
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next


'            '*************************************************************************
'            '//Cellular count
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id " & _
'            "order by lgroups.group_desc"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id " & _
'            "order by lgroups.group_desc"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("vCount").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) Then
'                        oSheet.Range(CStr("D" & iRow)).Value = r2("vParts").ToString
'                        oSheet.Range(CStr("E" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next



'            oSheet.Range("A4:E" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With


'            '//*******************************************************************
'            '//*******************************************************************

'            objXL.Sheets("Sheet2").Select()
'            oSheet = objXL.Worksheets(2)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY EMPLOYEE"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "EMPLOYEE"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "LABOR"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "PARTS"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 22
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 15
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 10
'            oSheet.Range("A4:F4").Select()

'            iRow = 5


'            With oSheet.range("A4:F4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:F4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:F4").Select()



'            '*************************************************************************
'            '//Cellular count
'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname " & _
'            "order by lgroups.group_desc, security.tusers.user_fullname"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname " & _
'            "order by lgroups.group_desc, security.tusers.user_fullname"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("user_fullname").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("group_desc").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vCount").ToString
'                oSheet.Range(CStr("D" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("user_fullname")) = Trim(r1("user_fullname")) Then
'                        oSheet.Range(CStr("E" & iRow)).Value = r2("vParts").ToString
'                        oSheet.Range(CStr("F" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'                        If r2("user_fullname") = "UNASSIGNED" Then
'                            oSheet.Range(CStr("E" & iRow)).Value = "0"
'                            oSheet.Range(CStr("F" & iRow)).Value = CDbl(r1("vLabor").ToString)
'                        End If
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next


'            oSheet.Range("A4:F" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With


'            objXL.visible = True
'            objXL.quit()
'            System.Windows.Forms.Application.DoEvents()

'            Marshal.ReleaseComObject(oSheet)
'            Marshal.ReleaseComObject(oWorkbook)
'            Marshal.ReleaseComObject(objXL)
'            System.Windows.Forms.Application.DoEvents()
'            System.GC.Collect()
'            'System.Windows.Forms.Application.DoEvents()
'            System.GC.WaitForPendingFinalizers()


'            Me.Refresh()

'        End Sub

'        Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

'            Dim mQuandry As New PSS.Data.Buisness.clsProdTracker()
'            Dim vLabor, vParts As Double
'            Dim dtCount As DataTable
'            Dim rCount As DataRow
'            Dim numCount As Integer = 0
'            Dim xCount As Integer
'            Dim blnResult As Boolean

'            Dim dtPart As DataTable
'            Dim rPart As DataRow
'            Dim xPart As Integer = 0


'            Dim objXL As Object
'            Dim oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim r1, r2 As DataRow
'            Dim dt1, dt2 As DataTable
'            Dim strSQL As String
'            Dim x1, x2 As Integer

'            Cursor.Current = Cursors.WaitCursor

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.workbooks.add()

'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"

'            '//This is to format the sheet - removing the need for a template file - BEGIN

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY DEPARTMENT"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE RANGE : " & dteStart.Text & " - " & dteEnd.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "MODEL"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "LABOR"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "PARTS"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("G4").Select()
'            oSheet.range("G4").FormulaR1C1 = "AUP"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 15
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 20
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").columnwidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 10
'            oSheet.Columns("G:G").Select()
'            oSheet.Columns("G:G").ColumnWidth = 10
'            oSheet.Range("A4:G4").Select()

'            With oSheet.range("A4:G4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:G4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:G4").Select()


'            Dim iRow As Integer = 5

'            ''//Messaging count
'            'strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            '"and tcellopt.device_id is null " & _
'            '"group by tworkorder.group_id " & _
'            '"order by tdevice.device_id"

'            'dt1 = ds.OrderEntrySelect(strSQL)

'            ''//Messaging Parts
'            'strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '"left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            '"and tcellopt.device_id is null " & _
'            '"group by tworkorder.group_id " & _
'            '"order by tdevice.device_id"

'            'dt2 = ds.OrderEntrySelect(strSQL)

'            'For x1 = 0 To dt1.Rows.Count - 1
'            'r1 = dt1.Rows(x1)
'            ''//get group and laborcharge
'            'oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'            'oSheet.Range(CStr("C" & iRow)).Value = r1("vCount").ToString
'            'oSheet.Range(CStr("D" & iRow)).Value = r1("vLabor").ToString

'            'For x2 = 0 To dt2.Rows.Count - 1
'            'r2 = dt2.Rows(x2)
'            ''//get part/service charge for group
'            'If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) Then
'            'oSheet.Range(CStr("E" & iRow)).Value = r2("vParts").ToString
'            'oSheet.Range(CStr("F" & iRow)).Value = CInt(r2("vParts").ToString) + CInt(r1("vLabor").ToString)
'            'Exit For
'            'End If
'            'Next
'            'iRow += 1
'            'Next


'            '*************************************************************************
'            '//Cellular count
'            'strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, tmodel.model_desc from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            '"and tcellopt.cellopt_techassigned is not null " & _
'            '"group by tworkorder.group_id, tmodel.model_desc " & _
'            '"order by lgroups.group_desc, tmodel.model_desc"

'            strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, tmodel.model_desc from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_refurbcompleteuserid is not null " & _
'            "and tcellopt.cellopt_QCReject <> 2 " & _
'            "group by tworkorder.group_id, tmodel.model_desc " & _
'            "order by lgroups.group_desc, tmodel.model_desc"











'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            'strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, tmodel.model_desc from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '"inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            '"and tcellopt.cellopt_techassigned is not null " & _
'            '"group by tworkorder.group_id, tmodel.model_desc " & _
'            '"order by lgroups.group_desc"

'            strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, tmodel.model_desc from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_QCReject <> 2 " & _
'            "group by tworkorder.group_id, tmodel.model_desc " & _
'            "order by lgroups.group_desc"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            '******************************************************************************


'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)

'                '//Get count of devices
'                strSQL = "select lgroups.group_desc, tdevice.device_id, tdevice.device_Laborcharge as mLabor, tmodel.model_desc from " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and tcellopt.cellopt_QCReject <> 2 " & _
'                "and lgroups.group_id = " & r1("Group_ID")

'                dtCount = ds.OrderEntrySelect(strSQL)
'                numCount = 0
'                vLabor = 0

'                For xCount = 0 To dtCount.Rows.Count - 1
'                    rCount = dtCount.Rows(xCount)

'                    blnResult = mQuandry.IsRURRTM(rCount("Device_ID"))
'                    If blnResult = False Then
'                        numCount += 1
'                        vLabor += rCount("mLabor")
'                    End If
'                Next

'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("Model_Desc").ToString

'                oSheet.Range(CStr("C" & iRow)).Value = numCount
'                oSheet.Range(CStr("D" & iRow)).Value = vLabor
'                '//Get part amount
'                strSQL = "select lgroups.group_desc, tworkorder.group_id, tdevice.device_id, tdevicebill.dbill_Invoiceamt as mParts, tmodel.model_desc from " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and tcellopt.cellopt_refurbcompleteuserid is not null " & _
'                "and tcellopt.cellopt_QCReject <> 2 " & _
'                "and lgroups.group_id = " & r1("Group_ID")

'                dtPart = ds.OrderEntrySelect(strSQL)
'                vParts = 0

'                For xPart = 0 To dtPart.Rows.Count - 1
'                    rPart = dtPart.Rows(xPart)
'                    blnResult = mQuandry.IsRURRTM(rPart("Device_ID"))
'                    If blnResult = False Then
'                        vParts += rPart("mParts")
'                    End If
'                Next

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(rPart("group_Desc")) = Trim(rCount("group_Desc")) And Trim(rPart("Model_Desc")) = Trim(rCount("Model_Desc")) Then
'                        oSheet.Range(CStr("E" & iRow)).Value = vParts
'                        oSheet.Range(CStr("F" & iRow)).Value = CDbl(vParts) + CDbl(vLabor)
'                        oSheet.Range(CStr("G" & iRow)).Value = CDbl(vParts) + CDbl(vLabor) / CDbl(numCount)
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next

'            '******************************************************************************
'            'For x1 = 0 To dt1.Rows.Count - 1
'            '    r1 = dt1.Rows(x1)
'            '    '//get group and laborcharge
'            '    oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'            '    oSheet.Range(CStr("B" & iRow)).Value = r1("Model_Desc").ToString
'            '    oSheet.Range(CStr("C" & iRow)).Value = r1("vCount").ToString
'            '    oSheet.Range(CStr("D" & iRow)).Value = r1("vLabor").ToString

'            '    For x2 = 0 To dt2.Rows.Count - 1
'            'r2 = dt2.Rows(x2)
'            ''//get part/service charge for group
'            'If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) And Trim(r2("Model_Desc")) = Trim(r1("Model_Desc")) Then
'            'oSheet.Range(CStr("E" & iRow)).Value = r2("vParts").ToString
'            'oSheet.Range(CStr("F" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'            'oSheet.Range(CStr("G" & iRow)).Value = CDbl(CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)) / CDbl(r1("vCount").ToString)
'            'Exit For
'            'End If
'            '    Next
'            'iRow += 1
'            'Next

'            '****************
'            '****************
'            '****************
'            '****************

'            oSheet.Range("A4:G" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With



'            '//Exit Here
'            'Exit Sub


'            '//*******************************************************************
'            '//*******************************************************************

'            objXL.Sheets("Sheet2").Select()
'            oSheet = objXL.Worksheets(2)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0.00"

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY EMPLOYEE"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "EMPLOYEE"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "MODEL"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "LABOR"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "PARTS"
'            oSheet.Range("G4").Select()
'            oSheet.range("G4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("H4").Select()
'            oSheet.range("H4").FormulaR1C1 = "AUP"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 22
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 15
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 20
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 10
'            oSheet.Columns("G:G").Select()
'            oSheet.Columns("G:G").ColumnWidth = 10
'            oSheet.Columns("H:H").Select()
'            oSheet.Columns("H:H").ColumnWidth = 10
'            oSheet.Range("A4:H4").Select()

'            iRow = 5


'            With oSheet.range("A4:H4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:H4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:H4").Select()



'            '*************************************************************************
'            '//Cellular count
'            'strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, tmodel.model_desc from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            '"inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            '"and tcellopt.cellopt_techassigned is not null " & _
'            '"group by tworkorder.group_id, security.tusers.user_fullname, tmodel.model_desc " & _
'            '"order by lgroups.group_desc, security.tusers.user_fullname, tmodel.model_desc"

'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, tmodel.model_desc from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_QCReject <> 2 " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname, tmodel.model_desc " & _
'            "order by lgroups.group_desc, security.tusers.user_fullname, tmodel.model_desc"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            'strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, tmodel.model_desc from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '"inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            '"inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            '"and tcellopt.cellopt_techassigned is not null " & _
'            '"group by tworkorder.group_id, security.tusers.user_fullname, tmodel.model_desc " & _
'            '"order by lgroups.group_desc, security.tusers.user_fullname, tmodel.model_desc"

'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, tmodel.model_desc from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_QCReject <> 2 " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname, tmodel.model_desc " & _
'            "order by lgroups.group_desc, security.tusers.user_fullname, tmodel.model_desc"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            '******************************************************************************
'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//Get count of devices
'                strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, tdevice.device_id, tdevice.device_laborcharge as mLabor from, tmodel.model_desc " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and tcellopt.cellopt_QCReject <> 2 " & _
'                "and security.tusers.user_fullname = '" & r1("user_fullname") & "' " & _
'                "order by lgroups.group_desc, security.tusers.user_fullname"

'                dtCount = ds.OrderEntrySelect(strSQL)
'                numCount = 0
'                vLabor = 0
'                For xCount = 0 To dtCount.Rows.Count - 1
'                    rCount = dtCount.Rows(xCount)

'                    blnResult = mQuandry.IsRURRTM(rCount("Device_ID"))
'                    If blnResult = False Then
'                        numCount += 1
'                        vLabor += rCount("mLabor")
'                    End If
'                Next
'                '//Get count of devices

'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("user_fullname").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("group_desc").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = rCount("Model_Desc").ToString
'                oSheet.Range(CStr("D" & iRow)).Value = numCount
'                oSheet.Range(CStr("E" & iRow)).Value = vLabor

'                vParts = 0


'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("user_fullname")) = Trim(r1("user_fullname")) And Trim(r2("Model_Desc")) = Trim(r1("Model_Desc")) Then
'                        oSheet.Range(CStr("F" & iRow)).Value = r2("vParts").ToString
'                        oSheet.Range(CStr("G" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(vLabor)
'                        oSheet.Range(CStr("H" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(vLabor) / CDbl(numCount)

'                        If r2("user_fullname") = "UNASSIGNED" Then
'                            oSheet.Range(CStr("F" & iRow)).Value = "0"
'                            oSheet.Range(CStr("G" & iRow)).Value = vLabor
'                            oSheet.Range(CStr("H" & iRow)).Value = CDbl(vLabor) / CDbl(numCount)

'                        End If
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next
'            '******************************************************************************
'            'For x1 = 0 To dt1.Rows.Count - 1
'            'r1 = dt1.Rows(x1)
'            ''//get group and laborcharge
'            'oSheet.Range(CStr("A" & iRow)).Value = r1("user_fullname").ToString
'            'oSheet.Range(CStr("B" & iRow)).Value = r1("group_desc").ToString
'            'oSheet.Range(CStr("C" & iRow)).Value = r1("Model_Desc").ToString
'            'oSheet.Range(CStr("D" & iRow)).Value = r1("vCount").ToString
'            'oSheet.Range(CStr("E" & iRow)).Value = r1("vLabor").ToString

'            'For x2 = 0 To dt2.Rows.Count - 1
'            'r2 = dt2.Rows(x2)
'            ''//get part/service charge for group
'            'If Trim(r2("user_fullname")) = Trim(r1("user_fullname")) And (r2("Model_Desc")) = Trim(r1("Model_Desc")) Then
'            'oSheet.Range(CStr("F" & iRow)).Value = r2("vParts").ToString
'            'oSheet.Range(CStr("G" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'            'oSheet.Range(CStr("H" & iRow)).Value = CDbl(CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)) / CDbl(r1("vCount").ToString)
'            'If r2("user_fullname") = "UNASSIGNED" Then
'            'oSheet.Range(CStr("F" & iRow)).Value = "0"
'            'oSheet.Range(CStr("G" & iRow)).Value = CDbl(r1("vLabor").ToString)
'            'oSheet.Range(CStr("H" & iRow)).Value = CDbl(r1("vLabor").ToString) / CDbl(r1("vCount").ToString)
'            'End If
'            'Exit For
'            'End If
'            'Next
'            'iRow += 1
'            'Next


'            oSheet.Range("A4:H" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With

'            Cursor.Current = Cursors.Default

'            objXL.visible = True
'            objXL = Nothing

'        End Sub

'        Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click


'            Dim objXL As Object
'            Dim oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim r1, r2, r3 As DataRow
'            Dim dt1, dt2, dt3 As DataTable
'            Dim strSQL As String
'            Dim x1, x2, x3, xbillcode As Integer

'            Cursor.Current = Cursors.WaitCursor

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            objXL.workbooks.add()

'            oSheet = objXL.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"

'            '//This is to format the sheet - removing the need for a template file - BEGIN

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "TRIAGE SUMMARY OF UNITS/REVENUE BY DEPARTMENT"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE RANGE : " & dteStart.Text & " - " & dteEnd.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "MODEL"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "TOTAL UNITS"
'            'oSheet.Range("D4").Select()
'            'oSheet.range("D4").FormulaR1C1 = "LABOR"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "PARTS"
'            'oSheet.Range("F4").Select()
'            'oSheet.range("F4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "AUP"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 15
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 20
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").columnwidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            'oSheet.Columns("F:F").Select()
'            'oSheet.Columns("F:F").ColumnWidth = 10
'            'oSheet.Columns("G:G").Select()
'            'oSheet.Columns("G:G").ColumnWidth = 10
'            oSheet.Range("A4:E4").Select()

'            With oSheet.range("A4:E4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:E4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:E4").Select()


'            Dim iRow As Integer = 5

'            ''//Messaging count
'            'strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            '"and tcellopt.device_id is null " & _
'            '"group by tworkorder.group_id " & _
'            '"order by tdevice.device_id"

'            'dt1 = ds.OrderEntrySelect(strSQL)

'            ''//Messaging Parts
'            'strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            '"tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            '"inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            '"left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            '"where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            '"and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            '"and tcellopt.device_id is null " & _
'            '"group by tworkorder.group_id " & _
'            '"order by tdevice.device_id"

'            'dt2 = ds.OrderEntrySelect(strSQL)

'            'For x1 = 0 To dt1.Rows.Count - 1
'            'r1 = dt1.Rows(x1)
'            ''//get group and laborcharge
'            'oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'            'oSheet.Range(CStr("C" & iRow)).Value = r1("vCount").ToString
'            'oSheet.Range(CStr("D" & iRow)).Value = r1("vLabor").ToString

'            'For x2 = 0 To dt2.Rows.Count - 1
'            'r2 = dt2.Rows(x2)
'            ''//get part/service charge for group
'            'If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) Then
'            'oSheet.Range(CStr("E" & iRow)).Value = r2("vParts").ToString
'            'oSheet.Range(CStr("F" & iRow)).Value = CInt(r2("vParts").ToString) + CInt(r1("vLabor").ToString)
'            'Exit For
'            'End If
'            'Next
'            'iRow += 1
'            'Next


'            '*************************************************************************
'            '//Cellular count
'            strSQL = "select tshift.shift_number, security.tusers.user_fullname, lgroups.group_desc, tmodel.model_desc, lpsprice.psprice_number, count(distinct tdevice.device_id) as vCount from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            "inner join security.tusers on tdevicebill.user_id = security.tusers.tech_id " & _
'            "inner join tshift on security.tusers.shift_id = tshift.shift_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            "and lbillcodes.billtype_id = 2 " & _
'            "and tdevicebill.billcode_id in (358,296,316,165,416,173,298,620,201,687,300,295,317,297,179,299,732,744,748,746,745,308,754,336,368,756) " & _
'            "group by tshift.shift_number, tworkorder.group_id, tmodel.model_desc, lpsprice.psprice_number " & _
'            "order by tshift.shift_number, lgroups.group_desc, tmodel.model_desc, lbillcodes.billcode_desc"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select tshift.shift_number, lgroups.group_desc, tworkorder.group_id, lpsprice.psprice_number, sum(tdevicebill.dbill_Invoiceamt) as vParts, tmodel.model_desc from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join security.tusers on tdevicebill.user_id = security.tusers.tech_id " & _
'            "inner join tshift on security.tusers.shift_id = tshift.shift_id " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            "and lbillcodes.billtype_id = 2 " & _
'            "and tdevicebill.billcode_id in (358,296,316,165,416,173,298,620,201,687,300,295,317,297,179,299,732,744,748,746,745,308,754,336,368,756) " & _
'            "group by tshift.shift_number, tworkorder.group_id, tmodel.model_desc, lpsprice.psprice_number " & _
'            "order by tshift.shift_number, lgroups.group_desc, lbillcodes.billcode_desc"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("Model_Desc").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vCount").ToString
'                'oSheet.Range(CStr("D" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) And Trim(r2("Model_Desc")) = Trim(r1("Model_Desc")) Then
'                        oSheet.Range(CStr("D" & iRow)).Value = r2("vParts").ToString
'                        'oSheet.Range(CStr("F" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'                        oSheet.Range(CStr("E" & iRow)).Value = CDbl(r2("vParts").ToString) / CDbl(r1("vCount").ToString)
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next



'            oSheet.Range("A4:E" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With



'            '//Exit Here
'            'Exit Sub


'            '//*******************************************************************
'            '//*******************************************************************

'            objXL.Sheets("Sheet2").Select()
'            oSheet = objXL.Worksheets(2)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "@"
'            oSheet.Columns("D").NumberFormat = "@"
'            oSheet.Columns("E").NumberFormat = "@"
'            oSheet.Columns("F").NumberFormat = "@"
'            oSheet.Columns("G").NumberFormat = "0"
'            oSheet.Columns("H").NumberFormat = "0.00"
'            oSheet.Columns("I").NumberFormat = "0.00"

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "TRIAGE SUMMARY OF UNITS/REVENUE BY EMPLOYEE"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "SHIFT"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "MODEL"

'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "EMPLOYEE"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "PART DESCRIPTION"



'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "PART NUMBER"
'            'oSheet.Range("E4").Select()
'            'oSheet.range("E4").FormulaR1C1 = "LABOR"
'            oSheet.Range("G4").Select()
'            oSheet.range("G4").FormulaR1C1 = "TOTAL UNITS"
'            'oSheet.Range("G4").Select()
'            'oSheet.range("G4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("H4").Select()
'            oSheet.range("H4").FormulaR1C1 = "PARTS"
'            oSheet.Range("I4").Select()
'            oSheet.range("I4").FormulaR1C1 = "TOTAL AUP?"

'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 10
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 15
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 15
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 15
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 20
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 15
'            oSheet.Columns("G:G").Select()
'            oSheet.Columns("G:G").ColumnWidth = 10
'            oSheet.Columns("H:H").Select()
'            oSheet.Columns("H:H").ColumnWidth = 10
'            oSheet.Columns("I:I").Select()
'            oSheet.Columns("I:I").ColumnWidth = 10
'            oSheet.Range("A4:I4").Select()

'            iRow = 5


'            With oSheet.range("A4:I4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:I4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:I4").Select()



'            '*************************************************************************
'            '//Cellular count
'            strSQL = "select tshift.shift_number, security.tusers.user_fullname, lgroups.group_desc, lbillcodes.billcode_desc, lpsprice.psprice_number, tmodel.model_desc, count(distinct tdevice.device_id) as vCount from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'            "inner join security.tusers on tdevicebill.user_id = security.tusers.tech_id " & _
'            "inner join tshift on security.tusers.shift_id = tshift.shift_id " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            "and lbillcodes.billtype_id = 2 " & _
'            "and tdevicebill.billcode_id in (358,296,316,165,416,173,298,620,201,687,300,295,317,297,179,299,732,744,748,746,745,308,754,336,368,756) " & _
'            "group by tshift.shift_number, tworkorder.group_id, tmodel.model_desc, security.tusers.user_fullname, lpsprice.psprice_number " & _
'            "order by tshift.shift_number, lgroups.group_desc, tmodel.model_desc, security.tusers.user_fullname, lbillcodes.billcode_desc"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select tshift.shift_number, security.tusers.user_fullname, lgroups.group_desc, lbillcodes.billcode_desc, lpsprice.psprice_number, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, tmodel.model_desc from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
'            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
'            "inner join security.tusers on tdevicebill.user_id = security.tusers.tech_id " & _
'            "inner join tshift on security.tusers.shift_id = tshift.shift_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            "and lbillcodes.billtype_id = 2 " & _
'            "and tdevicebill.billcode_id in (358,296,316,165,416,173,298,620,201,687,300,295,317,297,179,299,732,744,748,746,745,308,754,336,368,756) " & _
'            "group by tshift.shift_number, tworkorder.group_id, tmodel.model_desc, security.tusers.user_fullname, lpsprice.psprice_number " & _
'            "order by tshift.shift_number, lgroups.group_desc, tmodel.model_desc, security.tusers.user_fullname, lbillcodes.billcode_desc"



'            Dim strName As String = ""
'            Dim ttlUnits As Integer
'            Dim ttlParts As Double


'            dt2 = ds.OrderEntrySelect(strSQL)






'            '//Cellular total count
'            strSQL = "select tshift.shift_number, security.tusers.user_fullname, lgroups.group_desc, tmodel.model_desc, count(distinct tdevice.device_id) as vCount from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & _
'            "inner join security.tusers on tdevicebill.user_id = security.tusers.tech_id " & _
'            "inner join tshift on security.tusers.shift_id = tshift.shift_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Day, 1, CDate(dteEnd.Text))) & " 04:00:00' " & _
'            "and lbillcodes.billtype_id = 2 " & _
'            "and tdevicebill.billcode_id in (358,296,316,165,416,173,298,620,201,687,300,295,317,297,179,299,732,744,748,746,745,308,754,336,368,756) " & _
'            "group by tshift.shift_number, tworkorder.group_id, tmodel.model_desc, security.tusers.user_fullname " & _
'            "order by tshift.shift_number, lgroups.group_desc, tmodel.model_desc, security.tusers.user_fullname"

'            dt3 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)


'                If strName <> r1("user_fullname").ToString And strName <> "" Then
'                    '//put total in

'                    For x3 = 0 To dt3.Rows.Count - 1
'                        r3 = dt3.Rows(x3)
'                        If Trim(r3("user_fullname")) = Trim(r1("user_fullname")) And (r3("Model_Desc")) = Trim(r1("Model_Desc")) Then

'                            'MsgBox(ttlUnits)
'                            'MsgBox(ttlParts)


'                            oSheet.Range(CStr("I" & iRow - 1)).Value = (ttlParts / ttlUnits).ToString
'                        End If
'                    Next
'                    ttlParts = 0
'                    ttlUnits = 0
'                End If


'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("shift_number").ToString
'                oSheet.Range(CStr("D" & iRow)).Value = r1("user_fullname").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("group_desc").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("Model_Desc").ToString
'                oSheet.Range(CStr("G" & iRow)).Value = r1("vCount").ToString
'                'oSheet.Range(CStr("E" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("user_fullname")) = Trim(r1("user_fullname")) And (r2("Model_Desc")) = Trim(r1("Model_Desc")) And (r2("PSPrice_Number")) = Trim(r1("PSPrice_Number")) And (r2("Billcode_Desc")) = Trim(r1("Billcode_Desc")) Then
'                        oSheet.Range(CStr("H" & iRow)).Value = r2("vParts").ToString
'                        'oSheet.Range(CStr("G" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'                        'oSheet.Range(CStr("I" & iRow)).Value = CDbl(r2("vParts").ToString) / CDbl(r1("vCount").ToString)
'                        oSheet.Range(CStr("E" & iRow)).Value = r2("Billcode_Desc").ToString
'                        oSheet.Range(CStr("F" & iRow)).Value = r2("PSPrice_Number").ToString
'                        If r2("user_fullname") = "UNASSIGNED" Then
'                            oSheet.Range(CStr("F" & iRow)).Value = "0"
'                            'oSheet.Range(CStr("G" & iRow)).Value = CDbl(r1("vLabor").ToString)
'                            oSheet.Range(CStr("G" & iRow)).Value = "0"
'                            oSheet.Range(CStr("E" & iRow)).Value = r2("Billcode_Desc").ToString
'                            oSheet.Range(CStr("F" & iRow)).Value = r2("PSPrice_Number").ToString
'                            Exit For
'                        End If
'                        Exit For
'                    End If
'                Next
'                iRow += 1


'                If ttlUnits = 0 Then
'                    For x3 = 0 To dt3.Rows.Count - 1
'                        r3 = dt3.Rows(x3)
'                        If Trim(r3("user_fullname")) = Trim(r1("user_fullname")) And (r3("Model_Desc")) = Trim(r1("Model_Desc")) Then
'                            ttlUnits = CDbl(r3("vCount").ToString)
'                        End If
'                    Next
'                End If

'                ttlParts += CDbl(r2("vParts").ToString)
'                strName = r1("user_fullname").ToString

'                If x1 = dt1.Rows.Count - 1 Then
'                    '//put total in



'                    oSheet.Range(CStr("i" & iRow - 1)).Value = (ttlParts / ttlUnits).ToString
'                    ttlParts = 0
'                End If


'            Next


'            oSheet.Range("A4:I" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With

'            Cursor.Current = Cursors.Default

'            objXL.visible = True
'            objXL = Nothing


'        End Sub

'        Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click



'            Dim objXL As Object


'            Dim oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim r1, r2 As DataRow
'            Dim dt1, dt2 As DataTable
'            Dim strSQL As String
'            Dim x1, x2 As Integer

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            'objXL.workbooks.add()
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            oSheet = oWorkbook.Worksheets(1)


'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0.00"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "@"

'            '//This is to format the sheet - removing the need for a template file - BEGIN

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY DEPARTMENT"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "LABOR"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "PARTS"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "SHIFT"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 15
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 10
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Range("A4:F4").Select()

'            With oSheet.range("A4:F4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:F4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:F4").Select()





'            Dim iRow As Integer = 5

'            '//Messaging count
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.device_id is null " & _
'            "group by tworkorder.group_id " & _
'            "order by tdevice.device_id"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Messaging Parts
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "left outer join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.device_id is null " & _
'            "group by tworkorder.group_id " & _
'            "order by tdevice.device_id"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("vCount").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) Then
'                        oSheet.Range(CStr("D" & iRow)).Value = r2("vParts").ToString
'                        oSheet.Range(CStr("E" & iRow)).Value = CInt(r2("vParts").ToString) + CInt(r1("vLabor").ToString)
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next


'            '*************************************************************************
'            '//Cellular count
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, security.tusers.shift_id as vShift from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id, security.tusers.shift_id " & _
'            "order by lgroups.group_desc, security.tusers.shift_id"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, security.tusers.shift_id as vShift from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id, security.tusers.shift_id " & _
'            "order by lgroups.group_desc, security.tusers.shift_id"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("vCount").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vLabor").ToString
'                oSheet.Range(CStr("F" & iRow)).Value = r1("vShift").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("group_Desc")) = Trim(r1("group_Desc")) Then
'                        Try
'                            If Trim(r2("vShift")) = Trim(r1("vShift")) Then
'                                oSheet.Range(CStr("D" & iRow)).Value = r2("vParts").ToString
'                                oSheet.Range(CStr("E" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'                                Exit For
'                            End If
'                        Catch ex As Exception
'                        End Try
'                    End If

'                Next
'                iRow += 1
'            Next



'            oSheet.Range("A4:F" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With



'            '//*******************************************************************
'            '//*******************************************************************

'            objXL.Sheets("Sheet2").Select()
'            oSheet = objXL.Worksheets(2)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "@"

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY EMPLOYEE"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "EMPLOYEE"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "LABOR"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "PARTS"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("G4").Select()
'            oSheet.range("G4").FormulaR1C1 = "SHIFT"
'            oSheet.Range("H4").Select()
'            oSheet.range("H4").FormulaR1C1 = "HOURS"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 22
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 15
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 10
'            oSheet.Columns("G:G").Select()
'            oSheet.Columns("G:G").ColumnWidth = 10
'            oSheet.Columns("H:H").Select()
'            oSheet.Columns("H:H").ColumnWidth = 10
'            oSheet.Range("A4:H4").Select()

'            iRow = 5


'            With oSheet.range("A4:H4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:H4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:H4").Select()



'            '*************************************************************************
'            '//Cellular count
'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, security.tusers.shift_id as vShift from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname, security.tusers.shift_id " & _
'            "order by lgroups.group_desc, security.tusers.shift_id, security.tusers.user_fullname"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts, security.tusers.shift_id as vShift from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_techassigned = security.tusers.employeeno " & _
'            "where device_datebill > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and device_datebill < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_techassigned is not null " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname, security.tusers.shift_id " & _
'            "order by lgroups.group_desc, security.tusers.shift_id, security.tusers.user_fullname"

'            dt2 = ds.OrderEntrySelect(strSQL)



'            Dim dt3 As DataTable
'            Dim x3 As Integer
'            Dim r3 As DataRow

'            strSQL = "select user_fullname, sum(techhours_hours) as vHours from " & _
'            "security.tusers inner join ttechhours " & _
'            "on security.tusers.employeeno = ttechhours.employee_no " & _
'            "where techhours_date >= '" & Gui.Receiving.FormatDateShort(dteStart.Text) & "' and " & _
'            "techhours_date < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & "'" & _
'            "group by user_fullname"

'            dt3 = ds.OrderEntrySelect(strSQL)



'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("user_fullname").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("group_desc").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vCount").ToString
'                oSheet.Range(CStr("D" & iRow)).Value = r1("vLabor").ToString

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If IsDBNull(r2("vShift")) = False Then
'                        If Trim(r2("user_fullname")) = Trim(r1("user_fullname")) Then
'                            If Trim(r2("vShift")) = Trim(r1("vShift")) Then

'                                oSheet.Range(CStr("G" & iRow)).Value = r1("vShift").ToString


'                                oSheet.Range(CStr("E" & iRow)).Value = r2("vParts").ToString
'                                oSheet.Range(CStr("F" & iRow)).Value = CDbl(r2("vParts").ToString) + CDbl(r1("vLabor").ToString)
'                                If r2("user_fullname") = "UNASSIGNED" Then
'                                    oSheet.Range(CStr("E" & iRow)).Value = "0"
'                                    oSheet.Range(CStr("F" & iRow)).Value = CDbl(r1("vLabor").ToString)
'                                End If
'                                Exit For
'                            End If
'                        End If
'                    End If
'                Next

'                For x3 = 0 To dt3.Rows.Count - 1
'                    r3 = dt3.Rows(x3)
'                    If Trim(r2("user_fullname")) = Trim(r3("user_fullname")) Then
'                        oSheet.Range(CStr("H" & iRow)).Value = r3("vHours").ToString
'                        Exit For
'                    End If
'                Next

'                iRow += 1
'            Next


'            oSheet.Range("A4:H" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                '.LineStyle = Excel.XlLineStyle.xlContinuous
'                '.Weight = Excel.XlBorderWeight.xlThin
'                '.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With


'            objXL.visible = True
'            objXL.quit()
'            System.Windows.Forms.Application.DoEvents()

'            Marshal.ReleaseComObject(oSheet)
'            Marshal.ReleaseComObject(oWorkbook)
'            Marshal.ReleaseComObject(objXL)
'            System.Windows.Forms.Application.DoEvents()
'            System.GC.Collect()
'            'System.Windows.Forms.Application.DoEvents()
'            System.GC.WaitForPendingFinalizers()


'            Me.Refresh()


'        End Sub


'        Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

'            Dim objXL, _
'            oSheet As Object
'            Dim mQuandry As New PSS.Data.Buisness.clsProdTracker()
'            Dim ds As PSS.Data.Production.Joins
'            Dim r1, _
'            r2, _
'            rCount, _
'            rPart, _
'            rHours As DataRow
'            Dim dt1, _
'            dt2, _
'            dtCount, _
'            dtPart, _
'            dtHours As DataTable
'            Dim strSQL As String
'            Dim blnResult As Boolean
'            Dim vLabor, vParts As Double
'            Dim x1, _
'            x2, _
'            numCount, _
'            xCount, _
'            xPart, _
'            xRURRTM, _
'            intEmpNo As Integer
'            numCount = 0
'            xPart = 0

'            '//Create the XL doxument using the template
'            objXL = CreateObject("Excel.Application")
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            oSheet = oWorkbook.Worksheets(1)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0.00"
'            oSheet.Columns("D").NumberFormat = "0.00"
'            oSheet.Columns("E").NumberFormat = "0.00"

'            oSheet.Range("A1").Select()
'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY DEPARTMENT"
'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text & " to " & dteEnd.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "LABOR"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "PARTS"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 15
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 10
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Range("A4:E4").Select()

'            With oSheet.range("A4:E4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:E4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:E4").Select()

'            Dim iRow As Integer = 5

'            '//Cellular Count
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "and tcellopt.cellopt_refurbcompleteuserid is not null " & _
'            "group by tworkorder.group_id " & _
'            "order by lgroups.group_desc"

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "group by tworkorder.group_id " & _
'            "order by lgroups.group_desc"

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)

'                '//Get count of devices
'                strSQL = "select lgroups.group_desc, tdevice.device_id, tdevice.device_Laborcharge as mLabor from " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and lgroups.group_id = " & r1("Group_ID")

'                dtCount = ds.OrderEntrySelect(strSQL)
'                numCount = 0
'                vLabor = 0

'                For xCount = 0 To dtCount.Rows.Count - 1
'                    rCount = dtCount.Rows(xCount)

'                    blnResult = mQuandry.IsRURRTM(rCount("Device_ID"))
'                    If blnResult = False Then
'                        numCount += 1
'                        vLabor += rCount("mLabor")
'                    End If
'                Next

'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("group_Desc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = numCount
'                oSheet.Range(CStr("C" & iRow)).Value = vLabor
'                '//Get part amount
'                strSQL = "select lgroups.group_desc, tworkorder.group_id, tdevice.device_id, tdevicebill.dbill_Invoiceamt as mParts from " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and tcellopt.cellopt_refurbcompleteuserid is not null " & _
'                "and lgroups.group_id = " & r1("Group_ID")

'                '"and tcellopt.cellopt_QCReject <> 2 " & _

'                dtPart = ds.OrderEntrySelect(strSQL)
'                vParts = 0

'                For xPart = 0 To dtPart.Rows.Count - 1
'                    rPart = dtPart.Rows(xPart)
'                    blnResult = mQuandry.IsRURRTM(rPart("Device_ID"))
'                    If blnResult = False Then
'                        vParts += rPart("mParts")
'                    End If
'                Next

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(rPart("group_Desc")) = Trim(rCount("group_Desc")) Then
'                        oSheet.Range(CStr("D" & iRow)).Value = vParts
'                        oSheet.Range(CStr("E" & iRow)).Value = CDbl(vParts) + CDbl(vLabor)
'                        Exit For
'                    End If
'                Next
'                iRow += 1
'            Next

'            oSheet.Range("A4:E" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            '//END FIRST PAGE REPORT SECTION
'            '//*******************************************************************
'            '//*******************************************************************
'            '//START SECOND PAGE REPORT SECTION

'            objXL.Sheets("Sheet2").Select()
'            oSheet = objXL.Worksheets(2)

'            oSheet.Columns("A").NumberFormat = "@"
'            oSheet.Columns("B").NumberFormat = "@"
'            oSheet.Columns("C").NumberFormat = "0"
'            oSheet.Columns("D").NumberFormat = "0"
'            oSheet.Columns("E").NumberFormat = "0.00"
'            oSheet.Columns("F").NumberFormat = "0.00"
'            oSheet.Columns("G").NumberFormat = "0.00"
'            oSheet.Columns("H").NumberFormat = "0"

'            oSheet.Range("A1").Select()

'            oSheet.range("A1").FormulaR1C1 = "SUMMARY OF UNITS/REVENUE BY EMPLOYEE"

'            oSheet.Range("A2").Select()
'            oSheet.range("A2").FormulaR1C1 = "DATE : " & dteStart.Text & " to " & dteEnd.Text
'            oSheet.Range("A4").Select()
'            oSheet.range("A4").FormulaR1C1 = "EMPLOYEE"
'            oSheet.Range("B4").Select()
'            oSheet.range("B4").FormulaR1C1 = "DEPARTMENT"
'            oSheet.Range("C4").Select()
'            oSheet.range("C4").FormulaR1C1 = "SHIFT"
'            oSheet.Range("D4").Select()
'            oSheet.range("D4").FormulaR1C1 = "TOTAL UNITS"
'            oSheet.Range("E4").Select()
'            oSheet.range("E4").FormulaR1C1 = "LABOR"
'            oSheet.Range("F4").Select()
'            oSheet.range("F4").FormulaR1C1 = "PARTS"
'            oSheet.Range("G4").Select()
'            oSheet.range("G4").FormulaR1C1 = "TOTAL REVENUE"
'            oSheet.Range("H4").Select()
'            oSheet.range("H4").FormulaR1C1 = "RUR/RTM"
'            oSheet.Range("I4").Select()
'            oSheet.range("I4").FormulaR1C1 = "HOURS"
'            oSheet.Columns("A:A").Select()
'            oSheet.Columns("A:A").ColumnWidth = 22
'            oSheet.Columns("B:B").Select()
'            oSheet.Columns("B:B").columnwidth = 15
'            oSheet.Columns("C:C").Select()
'            oSheet.Columns("C:C").ColumnWidth = 10
'            oSheet.Columns("D:D").Select()
'            oSheet.Columns("D:D").ColumnWidth = 10
'            oSheet.Columns("E:E").Select()
'            oSheet.Columns("E:E").ColumnWidth = 10
'            oSheet.Columns("F:F").Select()
'            oSheet.Columns("F:F").ColumnWidth = 10
'            oSheet.Columns("G:G").Select()
'            oSheet.Columns("G:G").ColumnWidth = 10
'            oSheet.Columns("H:H").Select()
'            oSheet.Columns("H:H").ColumnWidth = 10
'            oSheet.Columns("I:I").Select()
'            oSheet.Columns("I:I").ColumnWidth = 10
'            oSheet.Range("A4:I4").Select()

'            iRow = 5

'            With oSheet.range("A4:I4")
'                .HorizontalAlignment = Excel.Constants.xlGeneral
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            With oSheet.range("A4:I4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Rows("4:4").RowHeight = 43.5
'            oSheet.Range("A4:I4").Select()
'            '*************************************************************************

'            '//Cellular count
'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, count(tdevice.device_id) as vCount, sum(tdevice.device_laborcharge) as vLabor, security.tusers.shift_id as vShift from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "group by tworkorder.group_id, vshift, security.tusers.user_fullname " & _
'            "order by lgroups.group_desc, vshift, security.tusers.user_fullname"

'            '"and tcellopt.cellopt_QCReject <> 2 " & _

'            dt1 = ds.OrderEntrySelect(strSQL)

'            '//Cellular Parts
'            strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, sum(tdevicebill.dbill_Invoiceamt) as vParts from " & _
'            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'            "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'            "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'            "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'            "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'            "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'            "group by tworkorder.group_id, security.tusers.user_fullname " & _
'            "order by lgroups.group_desc, security.tusers.user_fullname"

'            '"and tcellopt.cellopt_QCReject <> 2 " & _

'            dt2 = ds.OrderEntrySelect(strSQL)

'            For x1 = 0 To dt1.Rows.Count - 1
'                r1 = dt1.Rows(x1)
'                '//Get count of devices
'                strSQL = "select security.tusers.user_fullname, lgroups.group_desc, tworkorder.group_id, tdevice.device_id, tdevice.device_laborcharge as mLabor from " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and security.tusers.user_fullname = '" & r1("user_fullname") & "' " & _
'                "order by lgroups.group_desc, security.tusers.user_fullname"

'                '"and tcellopt.cellopt_QCReject <> 2 " & _

'                dtCount = ds.OrderEntrySelect(strSQL)
'                numCount = 0
'                xRURRTM = 0
'                vLabor = 0
'                For xCount = 0 To dtCount.Rows.Count - 1
'                    rCount = dtCount.Rows(xCount)

'                    blnResult = mQuandry.IsRURRTM(rCount("Device_ID"))
'                    If blnResult = False Then
'                        numCount += 1
'                        vLabor += rCount("mLabor")
'                    Else
'                        xRURRTM += 1
'                    End If
'                Next
'                '//Get count of devices

'                '//get group and laborcharge
'                oSheet.Range(CStr("A" & iRow)).Value = r1("user_fullname").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = r1("group_desc").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = r1("vshift").ToString
'                oSheet.Range(CStr("D" & iRow)).Value = numCount
'                oSheet.Range(CStr("E" & iRow)).Value = vLabor
'                oSheet.Range(CStr("H" & iRow)).Value = xRURRTM

'                '//Get part amount
'                strSQL = "select lgroups.group_desc, tworkorder.group_id, tdevice.device_id, tdevicebill.dbill_Invoiceamt as mParts, security.tusers.user_fullname, security.tusers.EmployeeNo as EmpNO from " & _
'                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
'                "inner join lgroups on tworkorder.group_id = lgroups.group_id " & _
'                "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
'                "inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                "where cellopt_refurbCompleteDt > '" & Gui.Receiving.FormatDateShort(dteStart.Text) & " 06:00:00' " & _
'                "and cellopt_refurbCompleteDt < '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & " 04:00:00' " & _
'                "and tcellopt.cellopt_refurbcompleteuserid is not null " & _
'                "and security.tusers.user_fullname = '" & r1("user_fullname") & "'"

'                dtPart = ds.OrderEntrySelect(strSQL)
'                vParts = 0

'                For xPart = 0 To dtPart.Rows.Count - 1
'                    rPart = dtPart.Rows(xPart)
'                    intEmpNo = rPart("EmpNo").ToString
'                    blnResult = mQuandry.IsRURRTM(rPart("Device_ID"))
'                    If blnResult = False Then
'                        vParts += rPart("mParts")
'                    End If
'                Next

'                For x2 = 0 To dt2.Rows.Count - 1
'                    r2 = dt2.Rows(x2)
'                    '//get part/service charge for group
'                    If Trim(r2("user_fullname")) = Trim(rPart("user_fullname")) Then
'                        oSheet.Range(CStr("F" & iRow)).Value = vParts
'                        oSheet.Range(CStr("G" & iRow)).Value = CDbl(vParts) + CDbl(vLabor)
'                        Exit For
'                    End If
'                Next

'                '//New October 30,2006
'                '//Get Employee Hours
'                'Try
'                'strSQL = "select sum(techhours_hours) as vHours  from " & _
'                '"ttechhours " & _
'                '"where techhours_date >= '" & Gui.Receiving.FormatDateShort(dteStart.Text) & "' " & _
'                '"and techhours_date <= '" & Gui.Receiving.FormatDateShort(dteEnd.Text) & "' " & _
'                '"and employee_no = " & intEmpNo & " " & _
'                '"group by techhours_username"

'                'dtHours = ds.OrderEntrySelect(strSQL)
'                'rHours = dtHours.Rows(0)
'                'oSheet.Range(CStr("I" & iRow)).Value = rHours("vHours").ToString
'                'Catch ex As Exception
'                'End Try
'                '//New October 30,2006

'                iRow += 1
'            Next

'            oSheet.Range("A4:I" & iRow - 1).Select()

'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
'            End With


'            objXL.visible = True
'            objXL.quit()
'            System.Windows.Forms.Application.DoEvents()

'            Marshal.ReleaseComObject(oSheet)
'            Marshal.ReleaseComObject(oWorkbook)
'            Marshal.ReleaseComObject(objXL)
'            System.Windows.Forms.Application.DoEvents()

'        End Sub

'        Private Sub btnProdRpt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            Dim mHR As Double = 0.0
'            Dim objXL, _
'            oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String

'            Dim startDate, _
'            mstartDate, _
'            endDate As Date

'            Dim blnWriteDate As Boolean

'            Dim techName As String
'            Dim techNumber As Integer

'            '//List of Technicians
'            Dim dtTechList As DataTable
'            Dim rTechList As DataRow
'            Dim xTechList As Integer = 0

'            '//Models
'            Dim dtModels As DataTable
'            Dim rModels As DataRow
'            Dim xModels As Integer = 0

'            '//Model Detail
'            Dim dtModelD As DataTable
'            Dim rModelD As DataRow
'            Dim xModelD As Integer = 0

'            '//Labor
'            Dim dtLaborD As DataTable
'            Dim rLaborD As DataRow

'            '//Parts
'            Dim dtPartsD As DataTable
'            Dim rPartsD As DataRow

'            '//TechHours
'            Dim dtHours As DataTable
'            Dim rHours As DataRow
'            Dim mHours As Double

'            '//QC
'            Dim dtQC As DataTable
'            Dim rQC As DataRow
'            Dim xQC As Integer = 0

'            Dim modelName As String
'            Dim modelNumber As Integer
'            Dim modelFactor As Double

'            Dim mDeviceID As Long
'            Dim blnRURRTM As Boolean

'            Dim objRURRTM As New PSS.Data.Buisness.clsProdTracker()

'            Dim dtRURRTM As DataTable

'            Dim intCount, _
'            intRUR, _
'            intRTM, _
'            intReject, _
'            intQCgood As Integer

'            Dim dblLabor, _
'            dblParts, _
'            dblWF As Double

'            Dim SintCount, _
'            SintRUR, _
'            SintRTM, _
'            SintReject, _
'            SintQCgood As Integer

'            Dim SdblLabor, _
'            SdblParts, _
'            SdblWF, _
'            Shours As Double

'            Dim TintCount, _
'            TintRUR, _
'            TintRTM, _
'            TintReject, _
'            TintQCgood As Integer

'            Dim TdblLabor, _
'            TdblParts, _
'            TdblWF, _
'            Thours, _
'            TgoalPointsDay As Double

'            Dim goalPoints As Double = 3.8
'            Dim SOUgoal, TOUgoal As Double

'            Dim iRow As Integer = 5


'            '//Date Range values
'            If Len(Trim(dteStart.Text)) < 1 Or Len(Trim(dteEnd.Text)) < 1 Then Exit Sub
'            startDate = Gui.Receiving.FormatDateShort(dteStart.Text)
'            endDate = Gui.Receiving.FormatDateShort(dteEnd.Text)
'            If endDate < startDate Then
'                MsgBox("The start date must be before the end date. Exiting...", MsgBoxStyle.Critical, "Date Range Invalid")
'                Exit Sub
'            End If
'            '//Date Range values

'            objXL = CreateObject("Excel.Application")
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            objXL.visible = True

'            mstartDate = startDate

'            '//Get list of Technicians
'            '//Get list of technician data for the report
'            strSQL = "select distinct security.tusers.user_fullname, security.tusers.employeeno, security.tusers.shift_id, security.tusers.TechRate, lgroups.group_desc from " & _
'            "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'            "inner join lgroups on security.tusers.group_id = lgroups.group_id " & _
'            "where cellopt_refurbcompletedt >= '" & startDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'            "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, endDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'            "order by security.tusers.user_fullname"
'            dtTechList = ds.OrderEntrySelect(strSQL)


'            '//The main report body
'            For xTechList = 0 To dtTechList.Rows.Count - 1
'                '//Get technician name and number
'                rTechList = dtTechList.Rows(xTechList)
'                techName = rTechList("user_fullname")
'                techNumber = rTechList("employeeno")
'                mHR = rTechList("TechRate")
'                '//Technician obtained


'                If xTechList > 2 Then
'                    oSheet = oWorkbook.worksheets.add 'Add worksheets for more than three technicians
'                End If

'                If xTechList = 0 Then
'                    oSheet = oWorkbook.sheets("Sheet1")
'                ElseIf xTechList = 1 Then
'                    oSheet = oWorkbook.sheets("Sheet2")
'                ElseIf xTechList = 2 Then
'                    oSheet = oWorkbook.sheets("Sheet3")
'                End If

'                iRow = 5
'                formatXLsheet(oSheet)

'                With oSheet.PageSetup
'                    .PrintTitleRows = ""
'                    .PrintTitleColumns = ""
'                End With
'                oSheet.PageSetup.PrintArea = ""
'                With oSheet.PageSetup
'                    .PrintQuality = 600
'                    .CenterHorizontally = False
'                    .CenterVertically = False
'                    .Orientation = Excel.XlPageOrientation.xlLandscape
'                    .Draft = False
'                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                    .FirstPageNumber = Excel.Constants.xlAutomatic
'                    .BlackAndWhite = False
'                    .Zoom = False
'                    .FitToPagesWide = 1
'                    .FitToPagesTall = 1
'                End With

'                oSheet.Range(CStr("B1")).Value = techName
'                oSheet.Range(CStr("E1")).Value = techNumber
'                oSheet.Range(CStr("G1")).Value = rTechList("Shift_ID")
'                oSheet.Range(CStr("I1")).Value = rTechList("Group_Desc")
'                'oSheet.Range(CStr("M1")).Value =                       '//Pay Period

'                '//Iterate through dates
'                Do Until mstartDate > endDate

'                    blnWriteDate = True

'                    '//Get Models for Date for Technician
'                    strSQL = "select distinct tdevice.model_id, tmodel.model_desc, tmodel.Weight_Factor from " & _
'                    "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                    "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                    "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                    "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                    "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                    "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                    "order by tmodel.model_desc"
'                    dtModels = ds.OrderEntrySelect(strSQL)

'                    '//Iterate through models and get data values for report
'                    For xModels = 0 To dtModels.Rows.Count - 1
'                        rModels = dtModels.Rows(xModels)
'                        modelName = rModels("model_desc")
'                        modelNumber = rModels("Model_id")
'                        modelFactor = rModels("Weight_Factor")

'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        'strSQL = "select distinct tcellopt.device_id, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        '"left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"order by tmodel.model_desc, tqc.qc_id desc"
'                        'dtModelD = ds.OrderEntrySelect(strSQL)
'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        strSQL = "select distinct tcellopt.device_id, max(tqc.qc_id) as maxID, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        "left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and tdevice.model_id = " & modelNumber & " " & _
'                        "group by tcellopt.device_id " & _
'                        "order by tmodel.model_desc, tqc.qc_id desc"
'                        dtModelD = ds.OrderEntrySelect(strSQL)

'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                        For xModelD = 0 To dtModelD.Rows.Count - 1
'                            rModelD = dtModelD.Rows(xModelD)
'                            mDeviceID = rModelD("device_id")

'                            intCount += 1

'                            '//Determine if value is complete or RUR/RTM
'                            blnRURRTM = objRURRTM.IsRURRTM(mDeviceID)
'                            If blnRURRTM = True Then
'                                '//Determine if it is RUR or RTM
'                                strSQL = "Select * from tdevicebill WHERE device_id = " & mDeviceID & " and billcode_id = 466"
'                                dtRURRTM = ds.OrderEntrySelect(strSQL)
'                                If dtRURRTM.Rows.Count > 0 Then
'                                    '//Device is RTM
'                                    intRTM += 1
'                                Else
'                                    '//Device is RUR
'                                    intRUR += 1
'                                End If
'                            Else
'                                '//Determine if it has been through QC
'                                If IsDBNull(rModelD("qcDeviceID")) = True Then
'                                    '//It has not been through QC
'                                    '//DO NOT ADD ANY VALUE
'                                Else
'                                    '//It has been QC'd
'                                    '//Determine if it is a reject or good
'                                    strSQL = "SELECT * FROM tqc WHERE Device_ID = " & mDeviceID & " ORDER BY qc_id desc"
'                                    dtQC = ds.OrderEntrySelect(strSQL)
'                                    rQC = dtQC.Rows(0)
'                                    If rQC("QCResult_ID") = 1 Then
'                                        '//Passed
'                                        intQCgood += 1
'                                    ElseIf rQC("QCResult_ID") = 2 Then
'                                        '//Failed
'                                        intReject += 1
'                                    End If
'                                End If
'                            End If
'                        Next



'                        ''//Get Labor Value for techncian/day/model
'                        'strSQL = "select sum(tdevice.device_laborcharge) as vLabor from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber

'                        '//New November 29, 2006
'                        strSQL = "select sum(tdevice.device_laborcharge) as vLabor from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tqc on tdevice.device_id = tqc.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and cellopt_qcreject <> 2 " & _
'                        "and tdevice.model_id = " & modelNumber
'                        '//New November 29, 2006


'                        dtLaborD = ds.OrderEntrySelect(strSQL)

'                        dblLabor = 0.0
'                        Try
'                            rLaborD = dtLaborD.Rows(0)
'                            dblLabor = rLaborD("vLabor")
'                        Catch ex As Exception
'                            dblLabor = 0.0
'                        End Try

'                        ''//Get Part Value for technician/day/model
'                        'strSQL = "select sum(tdevicebill.dbill_invoiceamt) as vParts from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"group by tdevice.model_id"

'                        '//New November 29, 2006
'                        strSQL = "select sum(tdevicebill.dbill_invoiceamt) as vParts from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and cellopt_qcreject <> 2 " & _
'                        "and tdevice.model_id = " & modelNumber & " " & _
'                        "group by tdevice.model_id"
'                        '//New November 29, 2006

'                        dtPartsD = ds.OrderEntrySelect(strSQL)

'                        dblParts = 0.0
'                        Try
'                            rPartsD = dtPartsD.Rows(0)
'                            dblParts = rPartsD("vParts")
'                        Catch ex As Exception
'                            dblParts = 0.0
'                        End Try

'                        dblWF = CDbl(CInt(intQCgood) * CDbl(modelFactor))

'                        '//Add to summary for day
'                        SintCount += intCount
'                        SintRUR += intRUR
'                        SintRTM += intRTM
'                        SintReject += intReject
'                        SintQCgood += intQCgood
'                        SdblLabor += dblLabor
'                        SdblParts += dblParts
'                        SdblWF += dblWF
'                        Shours += mHours

'                        '//write data for model to XL Sheet
'                        If blnWriteDate = True Then oSheet.Range(CStr("A" & iRow)).Value = mstartDate
'                        oSheet.Range(CStr("B" & iRow)).Value = modelName
'                        oSheet.Range(CStr("C" & iRow)).Value = intCount
'                        oSheet.Range(CStr("E" & iRow)).Value = intRUR
'                        oSheet.Range(CStr("F" & iRow)).Value = intRTM
'                        oSheet.Range(CStr("G" & iRow)).Value = intReject
'                        oSheet.Range(CStr("H" & iRow)).Value = intQCgood
'                        oSheet.Range(CStr("I" & iRow)).Value = dblWF



'                        oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                        If dblWF > 0 Then
'                            oSheet.Range(CStr("R" & iRow)).Value = dblLabor.ToString
'                            oSheet.Range(CStr("S" & iRow)).Value = dblParts.ToString
'                            oSheet.Range(CStr("T" & iRow)).Value = (dblLabor + dblParts).ToString
'                            oSheet.Range(CStr("U" & iRow)).Value = (dblParts / intQCgood).ToString
'                        Else
'                            oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                            oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                            oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                            oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                        End If
'                        blnWriteDate = False

'                        'MsgBox("Model " & modelName & " Units " & intCount & " RUR " & intRUR & " RTM " & intRTM & " Reject " & intReject & " QCGood " & intQCgood)

'                        '//Increment row number by 1
'                        iRow += 1

'                        'MsgBox("SModel " & modelName & " SUnits " & SintCount & " SRUR " & SintRUR & " SRTM " & SintRTM & " SReject " & SintReject & " SQCGood " & SintQCgood)

'                        '//Reset int values
'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                    Next
'                    If SintCount > 0 Then

'                        Try
'                            '//Get techhours
'                            strSQL = "select techhours_hours as vHours from " & _
'                            "ttechhours where employee_no = " & techNumber & " " & _
'                            "and techhours_date = '" & mstartDate.ToString("yyyy-MM-dd") & "' "
'                            dtHours = ds.OrderEntrySelect(strSQL)
'                            rHours = dtHours.Rows(0)
'                            mHours = rHours("vHours")
'                        Catch ex As Exception
'                            mHours = 0
'                        End Try

'                        oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                        oSheet.Range(CStr("B" & iRow)).Value = "Subtotal"
'                        oSheet.Range(CStr("D" & iRow)).Value = SintCount
'                        oSheet.Range(CStr("E" & iRow)).Value = SintRUR
'                        oSheet.Range(CStr("F" & iRow)).Value = SintRTM
'                        oSheet.Range(CStr("G" & iRow)).Value = SintReject
'                        oSheet.Range(CStr("H" & iRow)).Value = SintQCgood
'                        oSheet.Range(CStr("I" & iRow)).Value = SdblWF

'                        oSheet.Range(CStr("K" & iRow)).Value = mHours
'                        oSheet.Range(CStr("L" & iRow)).Value = goalPoints
'                        oSheet.Range(CStr("M" & iRow)).Value = goalPoints * mHours
'                        oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"


'                        SOUgoal = CDbl(CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value))
'                        oSheet.Range(CStr("N" & iRow)).Value = SOUgoal
'                        oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        'oSheet.Range(CStr("P" & iRow)).Value = CDbl(CDbl(SdblWF) - CDbl((oSheet.range(CStr("M" & iRow)).value)) * CDbl(mHours)) '/ 100
'                        oSheet.Range(CStr("P" & iRow)).Value = CDbl(CDbl(SdblWF) - CDbl((oSheet.range(CStr("M" & iRow)).value))) * 2 '/ 100

'                        oSheet.Range(CStr("R" & iRow & ":W" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("X" & iRow & ":X" & iRow)).NumberFormat = "#0.0%_);[Red](#0.0%_)"
'                        oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("V" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("W" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("X" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("R" & iRow)).Value = SdblLabor.ToString
'                        oSheet.Range(CStr("S" & iRow)).Value = SdblParts.ToString
'                        oSheet.Range(CStr("T" & iRow)).Value = (SdblLabor + SdblParts).ToString
'                        oSheet.Range(CStr("U" & iRow)).Value = (SdblParts / SintQCgood).ToString

'                        oSheet.Range(CStr("V" & iRow)).Value = mHours * mHR
'                        oSheet.Range(CStr("W" & iRow)).Value = CDbl(SdblLabor) - (mHours * mHR)
'                        oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(SdblLabor) - (mHours * mHR)) / mHours * mHR) / 100

'                        iRow += 1
'                    End If


'                    TintCount += SintCount
'                    TintRUR += SintRUR
'                    TintRTM += SintRTM
'                    TintReject += SintReject
'                    TintQCgood += SintQCgood
'                    TdblLabor += SdblLabor
'                    TdblParts += SdblParts
'                    TdblWF += SdblWF
'                    Thours += mHours
'                    TgoalPointsDay += goalPoints * mHours
'                    TOUgoal += SOUgoal

'                    blnWriteDate = True
'                    '//Reset Sint values
'                    SintCount = 0
'                    SintRUR = 0
'                    SintRTM = 0
'                    SintReject = 0
'                    SintQCgood = 0
'                    SdblLabor = 0.0
'                    SdblParts = 0.0
'                    SdblWF = 0.0
'                    mHours = 0.0
'                    SOUgoal = 0.0

'                    mstartDate = DateAdd(DateInterval.Day, 1, mstartDate)
'                Loop

'                '//Total Line Here
'                If TintCount > 0 Then

'                    With oSheet.Range(CStr("B" & iRow) & ":" & CStr("I" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("K" & iRow) & ":" & CStr("N" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("P" & iRow) & ":" & CStr("P" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("R" & iRow) & ":" & CStr("X" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    oSheet.Rows(CStr(iRow) & ":" & CStr(iRow)).RowHeight = 25.5

'                    oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                    oSheet.Range(CStr("B" & iRow)).Value = "Totals"
'                    oSheet.Range(CStr("D" & iRow)).Value = TintCount
'                    oSheet.Range(CStr("E" & iRow)).Value = TintRUR
'                    oSheet.Range(CStr("F" & iRow)).Value = TintRTM
'                    oSheet.Range(CStr("G" & iRow)).Value = TintReject
'                    oSheet.Range(CStr("H" & iRow)).Value = TintQCgood
'                    oSheet.Range(CStr("I" & iRow)).Value = TdblWF

'                    oSheet.Range(CStr("K" & iRow)).Value = Thours

'                    oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("N" & iRow)).Value = TOUgoal
'                    'oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                    oSheet.Range(CStr("P" & iRow)).Value = (TOUgoal * 2) '* Thours) '/ 100

'                    oSheet.Range(CStr("R" & iRow & ":W" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                    oSheet.Range(CStr("X" & iRow & ":X" & iRow)).NumberFormat = "#0.0%_);[Red](#0.0%_)"
'                    oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("V" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("W" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("X" & iRow)).Font.Bold = True
'                    If TdblWF > 0 Then
'                        oSheet.Range(CStr("R" & iRow)).Value = TdblLabor.ToString
'                        oSheet.Range(CStr("S" & iRow)).Value = TdblParts.ToString
'                        oSheet.Range(CStr("T" & iRow)).Value = (TdblLabor + TdblParts).ToString
'                        oSheet.Range(CStr("U" & iRow)).Value = (TdblParts / TintQCgood).ToString
'                        oSheet.Range(CStr("V" & iRow)).Value = Thours * mHR
'                        oSheet.Range(CStr("W" & iRow)).Value = CDbl(TdblLabor) - (Thours * mHR)
'                        oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(TdblLabor) - (Thours * mHR)) / Thours * mHR) / 100
'                    Else
'                        oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("V" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("W" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("X" & iRow)).Value = "0.00"
'                    End If
'                    'iRow += 1
'                End If

'                TintCount = 0
'                TintRUR = 0
'                TintRTM = 0
'                TintReject = 0
'                TintQCgood = 0
'                TdblLabor = 0.0
'                TdblParts = 0.0
'                TdblWF = 0.0
'                TgoalPointsDay = 0.0
'                TOUgoal = 0.0
'                Thours = 0.0

'                objXL.Range(CStr("A3:I" & iRow & ",K3:N" & iRow & ",P3:P" & iRow & ",R3:X" & iRow)).Select()
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                oSheet.select()
'                oSheet.Name = techNumber
'                oSheet.Range("A1").Select()

'                mstartDate = startDate  '//Return value to start date for next technician
'            Next


'            '//The main report body
'            Exit Sub

'        End Sub

'        Private Sub formatXLsheet_EmployeeReport(ByVal mXL As Excel.Worksheet)
'            mXL.Rows("3:3").RowHeight = 37.5
'            With mXL.Range("A3:I3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("A3:I3").Merge()
'            With mXL.Range("A3:I3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With

'            With mXL.Range("K3:N3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With

'            With mXL.Range("P3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With
'            'mXL.ActiveWindow.SmallScroll(ToRight:=4)

'            mXL.Range("Q1").ColumnWidth = 2
'            mXL.Range("J1").ColumnWidth = 2
'            mXL.Range("O1").ColumnWidth = 2
'            'mXL.Range("Q1").LargeScroll(ToRight:=-1)

'            With mXL.Rows("3:3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlCenter
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'            End With

'            mXL.Range("A3:I3").FormulaR1C1 = "Weekly Production Detail"
'            With mXL.Range("A3:I3").Characters(Start:=1, Length:=24).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            With mXL.Range("K3:N3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlCenter
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("K3:N3").Merge()
'            mXL.Range("K3:N3").FormulaR1C1 = "Actual vs. Goals"
'            With mXL.Range("K3:N3").Characters(Start:=1, Length:=16).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("P3").FormulaR1C1 = "Productivity Bonus"
'            With mXL.Range("P3").Characters(Start:=1, Length:=18).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Columns("P:P").ColumnWidth = 11.43
'            'mXL.Range("R3").Select()
'            'mXL.Range("R3").SmallScroll(ToRight:=6)
'            With mXL.Range("R3:X3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlCenter
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With

'            'mXL.Range("R4").LargeScroll(ToRight:=-1)
'            mXL.Range("A1").FormulaR1C1 = "Name:"
'            mXL.Range("A1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("D1").FormulaR1C1 = "Emp. #"
'            mXL.Range("D1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("F1").FormulaR1C1 = "Shift:"
'            mXL.Range("F1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("H1").FormulaR1C1 = "Group:"
'            mXL.Range("H1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("L1").HorizontalAlignment = Excel.Constants.xlRight

'            mXL.Range("B1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("E1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("G1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("I1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("M1").HorizontalAlignment = Excel.Constants.xlLeft


'            With mXL.Range("K1:L1")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("K1:L1").Merge()
'            mXL.Range("K1:L1").FormulaR1C1 = "Pay Period:"
'            'mXL.Range("K1:L1,H1,F1,D1,A1")
'            With mXL.Range("A1")
'                .HorizontalAlignment = Excel.Constants.xlRight
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'            End With
'            mXL.Rows("4:4").RowHeight = 76.5
'            With mXL.Rows("4:4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With

'            mXL.Range("A4").FormulaR1C1 = "Work Days"
'            With mXL.Range("A4").Characters(Start:=1, Length:=9).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("B4").FormulaR1C1 = "Model"
'            With mXL.Range("B4").Characters(Start:=1, Length:=5).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("C4").FormulaR1C1 = "Total Units Sent To QC By Model"
'            With mXL.Range("C4").Characters(Start:=1, Length:=31).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("D4").FormulaR1C1 = "Total Units Sent To QC"
'            With mXL.Range("D4").Characters(Start:=1, Length:=22).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("E4").FormulaR1C1 = "RUR"
'            With mXL.Range("E4").Characters(Start:=1, Length:=3).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("F4").FormulaR1C1 = "RTM"
'            With mXL.Range("F4").Characters(Start:=1, Length:=3).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("G4").FormulaR1C1 = "Rejects"
'            With mXL.Range("G4").Characters(Start:=1, Length:=7).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("H4").FormulaR1C1 = "Total of Good Units That Passed QC"
'            With mXL.Range("H4").Characters(Start:=1, Length:=34).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("I4").FormulaR1C1 = "Actual Points Achieved"
'            With mXL.Range("I4").Characters(Start:=1, Length:=22).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("K4").FormulaR1C1 = "Hours Worked"
'            With mXL.Range("K4").Characters(Start:=1, Length:=12).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("L4").FormulaR1C1 = "Goal Points Per Hour"
'            With mXL.Range("L4").Characters(Start:=1, Length:=20).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("M4").FormulaR1C1 = "Goal Points Per Day"
'            With mXL.Range("M4").Characters(Start:=1, Length:=19).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("N4").FormulaR1C1 = "Over or (Under) Goal"
'            With mXL.Range("N4").Characters(Start:=1, Length:=20).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("P4").FormulaR1C1 = "Daily Bonus Opportunity"
'            With mXL.Range("P4").Characters(Start:=1, Length:=23).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Columns("P:P").ColumnWidth = 11
'            mXL.Columns("K:N").ColumnWidth = 11
'            mXL.Columns("A:I").ColumnWidth = 11
'            mXL.Columns("B:B").ColumnWidth = 20

'        End Sub



'        Private Sub formatXLsheet(ByVal mXL As Excel.Worksheet)

'            mXL.Rows("3:3").RowHeight = 37.5
'            With mXL.Range("A3:I3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("A3:I3").Merge()
'            With mXL.Range("A3:I3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With

'            With mXL.Range("K3:N3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With

'            With mXL.Range("P3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With
'            'mXL.ActiveWindow.SmallScroll(ToRight:=4)

'            With mXL.Range("R3:X3").Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With
'            'mXL.Range("J:J,O:O,Q:Q").Select()

'            mXL.Range("Q1").ColumnWidth = 2
'            mXL.Range("J1").ColumnWidth = 2
'            mXL.Range("O1").ColumnWidth = 2
'            'mXL.Range("Q1").LargeScroll(ToRight:=-1)

'            With mXL.Rows("3:3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlCenter
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'            End With

'            mXL.Range("A3:I3").FormulaR1C1 = "Weekly Production Detail"
'            With mXL.Range("A3:I3").Characters(Start:=1, Length:=24).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            With mXL.Range("K3:N3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlCenter
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("K3:N3").Merge()
'            mXL.Range("K3:N3").FormulaR1C1 = "Actual vs. Goals"
'            With mXL.Range("K3:N3").Characters(Start:=1, Length:=16).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("P3").FormulaR1C1 = "Productivity Bonus"
'            With mXL.Range("P3").Characters(Start:=1, Length:=18).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Columns("P:P").ColumnWidth = 11.43
'            'mXL.Range("R3").Select()
'            'mXL.Range("R3").SmallScroll(ToRight:=6)
'            With mXL.Range("R3:X3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlCenter
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("R3:X3").Merge()
'            mXL.Range("R3:X3").FormulaR1C1 = "Cost and Revenue Metrics"
'            With mXL.Range("R3:X3").Characters(Start:=1, Length:=24).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            'mXL.Range("R4").LargeScroll(ToRight:=-1)
'            mXL.Range("A1").FormulaR1C1 = "Name:"
'            mXL.Range("A1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("D1").FormulaR1C1 = "Emp. #"
'            mXL.Range("D1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("F1").FormulaR1C1 = "Shift:"
'            mXL.Range("F1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("H1").FormulaR1C1 = "Group:"
'            mXL.Range("H1").HorizontalAlignment = Excel.Constants.xlRight
'            mXL.Range("L1").HorizontalAlignment = Excel.Constants.xlRight

'            mXL.Range("B1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("E1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("G1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("I1").HorizontalAlignment = Excel.Constants.xlLeft
'            mXL.Range("M1").HorizontalAlignment = Excel.Constants.xlLeft


'            With mXL.Range("K1:L1")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            mXL.Range("K1:L1").Merge()
'            mXL.Range("K1:L1").FormulaR1C1 = "Pay Period:"
'            'mXL.Range("K1:L1,H1,F1,D1,A1")
'            With mXL.Range("A1")
'                .HorizontalAlignment = Excel.Constants.xlRight
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'            End With
'            'Range("B1:C1,E1,G1,I1,M1:N1").Select()
'            'mXL.Range("M1").Borders(Excel.Constants.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'            'mXL.Range("M1").Borders(Excel.Constants.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
'            'mXL.Range("M1").Borders(Excel.Constants.xlEdgeLeft).LineStyle = Excel.Constants.xlNone
'            'mXL.Range("M1").Borders(Excel.Constants.xlEdgeTop).LineStyle = Excel.Constants.xlNone
'            'With mXL.Range("M1").Borders(Excel.Constants.xlEdgeBottom)
'            '    .LineStyle = Excel.Constants.xlContinuous
'            '    .Weight = Excel.Constants.xlThin
'            '.ColorIndex = Excel.Constants.xlAutomatic
'            'End With
'            'mXL.Range("M1").Borders(xlEdgeRight).LineStyle = Excel.Constants.xlNone
'            'mXL.Range("M1").Borders(xlInsideVertical).LineStyle = Excel.Constants.xlNone
'            mXL.Rows("4:4").RowHeight = 76.5
'            'mXL.Rows("4:4").Select()
'            With mXL.Rows("4:4")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = True
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With

'            mXL.Range("A4").FormulaR1C1 = "Work Days"
'            With mXL.Range("A4").Characters(Start:=1, Length:=9).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("B4").FormulaR1C1 = "Model"
'            With mXL.Range("B4").Characters(Start:=1, Length:=5).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("C4").FormulaR1C1 = "Total Units Sent To QC By Model"
'            With mXL.Range("C4").Characters(Start:=1, Length:=31).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("D4").FormulaR1C1 = "Total Units Sent To QC"
'            With mXL.Range("D4").Characters(Start:=1, Length:=22).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("E4").FormulaR1C1 = "RUR"
'            With mXL.Range("E4").Characters(Start:=1, Length:=3).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("F4").FormulaR1C1 = "RTM"
'            With mXL.Range("F4").Characters(Start:=1, Length:=3).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("G4").FormulaR1C1 = "Rejects"
'            With mXL.Range("G4").Characters(Start:=1, Length:=7).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("H4").FormulaR1C1 = "Total of Good Units That Passed QC"
'            With mXL.Range("H4").Characters(Start:=1, Length:=34).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("I4").FormulaR1C1 = "Actual Points Achieved"
'            With mXL.Range("I4").Characters(Start:=1, Length:=22).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("K4").FormulaR1C1 = "Hours Worked"
'            With mXL.Range("K4").Characters(Start:=1, Length:=12).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("L4").FormulaR1C1 = "Goal Points Per Hour"
'            With mXL.Range("L4").Characters(Start:=1, Length:=20).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("M4").FormulaR1C1 = "Goal Points Per Day"
'            With mXL.Range("M4").Characters(Start:=1, Length:=19).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("N4").FormulaR1C1 = "Over or (Under) Goal"
'            With mXL.Range("N4").Characters(Start:=1, Length:=20).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("P4").FormulaR1C1 = "Daily Bonus Opportunity"
'            With mXL.Range("P4").Characters(Start:=1, Length:=23).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("R4").FormulaR1C1 = "Labor AUP"
'            With mXL.Range("R4").Characters(Start:=1, Length:=9).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("S4").FormulaR1C1 = "Parts AUP"
'            With mXL.Range("S4").Characters(Start:=1, Length:=9).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("T4").FormulaR1C1 = "Combined AUP"
'            With mXL.Range("T4").Characters(Start:=1, Length:=12).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("U4").FormulaR1C1 = "Avg. Parts AUP"
'            With mXL.Range("U4").Characters(Start:=1, Length:=14).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("V4").FormulaR1C1 = "Daily Cost of Labor (EE Hourly Rate X Hours Worked)"
'            With mXL.Range("V4").Characters(Start:=1, Length:=14).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("W4").FormulaR1C1 = "Daiy Gross Profit On Labor $"
'            With mXL.Range("W4").Characters(Start:=1, Length:=14).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            mXL.Range("X4").FormulaR1C1 = "Daily Gross Profit On Labor %"
'            With mXL.Range("X4").Characters(Start:=1, Length:=14).Font
'                .Name = "Arial"
'                .FontStyle = "Regular"
'                .Size = 10
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With


'            'mXL.Range("A4,B4,C4,D4,E4,F4,G4,H4,I4,K4,L4,M4,N4,P4").Select()
'            'mXL.Range("P4").Activate()
'            'mXL.Range("P4").SmallScroll(ToRight:=4)
'            'mXL.Columns("R:U").Select()
'            mXL.Columns("R:X").ColumnWidth = 11
'            'mXL.Columns("P:P").Select()
'            mXL.Columns("P:P").ColumnWidth = 11
'            'mXL.Columns("K:N").Select()
'            'mXL.Columns("K:N").Activate()
'            mXL.Columns("K:N").ColumnWidth = 11
'            'mXL.ActiveWindow.LargeScroll(ToRight:=-1)
'            'mXL.Columns("A:I").Select()
'            mXL.Columns("A:I").ColumnWidth = 11
'            mXL.Columns("B:B").ColumnWidth = 20
'            'mXL.Range("A5").Select()
'        End Sub


'        Private Sub btnCSWIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSWIP.Click

'            Dim objXL, _
'            oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String
'            objXL = CreateObject("Excel.Application")
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            oSheet = oWorkbook.sheets("Sheet1")

'            Dim iRow As Integer = 5

'            Dim dtData As DataTable
'            Dim rData As DataRow
'            Dim xData As Integer = 0

'            Dim ttl1, ttl2 As Long


'            'NON DETERMINED DEVICES
'            strSQL = "select cstincomingdata.csin_itemdesc as vDesc, count(cstincomingdata.csin_itemdesc) as vCount, csin_ItemNum as ItemNum from " & _
'            "cstincomingdata left outer join cs_partmap on cstincomingdata.csin_itemnum = cs_partmap.part_number " & _
'            "where closedstatussent = 0 " & _
'            "and cs_partmap.model_id is null " & _
'            "and flgreceived = 0 " & _
'            "group by cstincomingdata.csin_itemdesc"
'            dtData = ds.OrderEntrySelect(strSQL)

'            If dtData.Rows.Count > 0 Then
'                oSheet.Range(CStr("A" & iRow)).Value = "THESE DEVICES ARE NOT DEFINED BY PART MAP"
'                iRow += 1
'                oSheet.Range(CStr("A" & iRow)).Value = "MANUFACTURER"
'                oSheet.Range(CStr("B" & iRow)).Value = "MODEL"
'                oSheet.Range(CStr("C" & iRow)).Value = "QUANTITY"
'                iRow += 1
'            End If

'            ttl1 = 0
'            For xData = 0 To dtData.Rows.Count - 1
'                rData = dtData.Rows(xData)
'                oSheet.Range(CStr("A" & iRow)).Value = rData("vDesc").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = rData("ItemNum").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = rData("vCount").ToString
'                ttl1 += CLng(rData("vCount"))
'                iRow += 1
'            Next

'            iRow += 1
'            oSheet.Range(CStr("B" & iRow)).Value = "TOTAL DEVICES GROUP 1"
'            oSheet.Range(CStr("C" & iRow)).Value = ttl1.ToString

'            objXL.Range(CStr("A" & iRow & ":C" & iRow)).Select()
'            With objXL.Selection.Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With
'            objXL.Range(CStr("B" & iRow & ":C" & iRow)).Select()
'            objXL.Selection.Font.Italic = True
'            objXL.Selection.Font.Bold = True
'            iRow += 2

'            'DETERMINED DEVICES
'            strSQL = "select cs_partmap.model_id, lmanuf.manuf_desc as vManuf, tmodel.model_desc as vModel, count(cs_partmap.model_id) as vCount from " & _
'            "cstincomingdata inner join cs_partmap on cstincomingdata.csin_itemnum = cs_partmap.part_number " & _
'            "inner join tmodel on cs_partmap.model_id = tmodel.model_id " & _
'            "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & _
'            "where closedstatussent = 0 " & _
'            "and cs_partmap.model_id is not null " & _
'            "and flgreceived = 0 " & _
'            "group by cs_partmap.model_id " & _
'            "order by lmanuf.manuf_desc, tmodel.model_desc"
'            dtData = ds.OrderEntrySelect(strSQL)

'            ttl2 = 0
'            For xData = 0 To dtData.Rows.Count - 1
'                rData = dtData.Rows(xData)
'                oSheet.Range(CStr("A" & iRow)).Value = rData("vManuf").ToString
'                oSheet.Range(CStr("B" & iRow)).Value = rData("vModel").ToString
'                oSheet.Range(CStr("C" & iRow)).Value = rData("vCount").ToString
'                ttl2 += CLng(rData("vCount"))
'                iRow += 1
'            Next

'            iRow += 1
'            oSheet.Range(CStr("B" & iRow)).Value = "TOTAL DEVICES GROUP 2"
'            oSheet.Range(CStr("C" & iRow)).Value = ttl2.ToString

'            objXL.Range(CStr("A" & iRow & ":C" & iRow)).Select()
'            With objXL.Selection.Interior
'                .ColorIndex = 35
'                .Pattern = Excel.Constants.xlSolid
'            End With
'            objXL.Range(CStr("B" & iRow & ":C" & iRow)).Select()
'            objXL.Selection.Font.Italic = True
'            objXL.Selection.Font.Bold = True
'            iRow += 2
'            oSheet.Range(CStr("B" & iRow)).Value = "TOTAL DEVICES"
'            oSheet.Range(CStr("C" & iRow)).Value = Str(CInt(ttl1) + CInt(ttl2)).ToString

'            '//SHEET FORMATTING
'            oSheet.Columns("A:A").ColumnWidth = 18
'            oSheet.Columns("A:A").ColumnWidth = 30.14
'            oSheet.Columns("A:A").ColumnWidth = 30.14
'            oSheet.Columns("A:A").ColumnWidth = 32.86
'            oSheet.Columns("B:B").ColumnWidth = 24.0
'            oSheet.Columns("C:C").ColumnWidth = 17
'            oSheet.Columns("C:C").Select()
'            With objXL.Selection
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Columns("A:B").Select()
'            With objXL.Selection
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            oSheet.Range("A5:C5").Select()
'            With objXL.Selection
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            objXL.Selection.Merge()
'            oSheet.Range("A1:C1").Select()
'            With objXL.Selection
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            objXL.Selection.Merge()
'            With objXL.Selection.Font
'                .Name = "Arial"
'                .Size = 14
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = Excel.Constants.xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            objXL.Selection.Font.Bold = True
'            oSheet.Range("A1:C1").Select()
'            objXL.ActiveCell.FormulaR1C1 = "Brightpoint WIP DEVICE COUNT"
'            oSheet.Range("A2:C2").Select()
'            With objXL.Selection
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'                .MergeCells = False
'            End With
'            objXL.Selection.Merge()
'            oSheet.Range("A2:C2").Select()
'            objXL.ActiveCell.FormulaR1C1 = Now
'            oSheet.Range(CStr("A5:C" & iRow)).Select()
'            'objXL.Selection.Borders(objXL.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'            'objXL.Selection.Borders(objXL.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                .LineStyle = Excel.XlLineStyle.xlContinuous
'                .Weight = Excel.XlBorderWeight.xlThin
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With
'            objXL.Range(CStr("A1:C" & iRow)).Select()
'            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$C$" & iRow)
'            objXL.Range("A1:C1").Select()


'            objXL.Range(CStr("B" & iRow & ":C" & iRow)).Select()
'            objXL.Selection.Font.Bold = True
'            With objXL.Selection.Font
'                .Name = "Arial"
'                .Size = 14
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                '.Underline = xlUnderlineStyleNone
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            '//TITLE FORMATTING
'            objXL.Range("A1:C1").Select()
'            With objXL.Selection.Interior
'                .ColorIndex = 34
'                .Pattern = Excel.Constants.xlSolid
'            End With
'            '//TITLE FORMATTING
'            '//SHEET FORMATTING

'            '//Repeat header on each sheet
'            With objXL.ActiveSheet.PageSetup
'                .PrintTitleRows = "$1:$4"
'                .PrintTitleColumns = ""
'            End With
'            objXL.ActiveSheet.PageSetup.PrintArea = "$A$1:$C$56"
'            With objXL.ActiveSheet.PageSetup
'                .LeftHeader = ""
'                .CenterHeader = ""
'                .RightHeader = ""
'                .LeftFooter = ""
'                .CenterFooter = ""
'                .RightFooter = ""
'                .PrintHeadings = False
'                .PrintGridlines = False
'                .PrintQuality = 600
'                .CenterHorizontally = False
'                .CenterVertically = False
'                .Draft = False
'                .BlackAndWhite = False
'                .Zoom = 100
'            End With
'            '//Repeat header on each sheet

'            objXL.visible = True

'        End Sub

'        Private Sub btnEmployeeReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


'            Dim mHR As Double = 0.0
'            Dim objXL, _
'            oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String

'            Dim startDate, _
'            mstartDate, _
'            endDate As Date

'            Dim blnWriteDate As Boolean

'            Dim techName As String
'            Dim techNumber As Integer

'            '//List of Technicians
'            Dim dtTechList As DataTable
'            Dim rTechList As DataRow
'            Dim xTechList As Integer = 0

'            '//Models
'            Dim dtModels As DataTable
'            Dim rModels As DataRow
'            Dim xModels As Integer = 0

'            '//Model Detail
'            Dim dtModelD As DataTable
'            Dim rModelD As DataRow
'            Dim xModelD As Integer = 0

'            '//Labor
'            Dim dtLaborD As DataTable
'            Dim rLaborD As DataRow

'            '//Parts
'            Dim dtPartsD As DataTable
'            Dim rPartsD As DataRow

'            '//TechHours
'            Dim dtHours As DataTable
'            Dim rHours As DataRow
'            Dim mHours As Double

'            '//QC
'            Dim dtQC As DataTable
'            Dim rQC As DataRow
'            Dim xQC As Integer = 0

'            Dim modelName As String
'            Dim modelNumber As Integer
'            Dim modelFactor As Double

'            Dim mDeviceID As Long
'            Dim blnRURRTM As Boolean

'            Dim objRURRTM As New PSS.Data.Buisness.clsProdTracker()

'            Dim dtRURRTM As DataTable

'            Dim intCount, _
'            intRUR, _
'            intRTM, _
'            intReject, _
'            intQCgood As Integer

'            Dim dblLabor, _
'            dblParts, _
'            dblWF As Double

'            Dim SintCount, _
'            SintRUR, _
'            SintRTM, _
'            SintReject, _
'            SintQCgood As Integer

'            Dim SdblLabor, _
'            SdblParts, _
'            SdblWF, _
'            Shours As Double

'            Dim TintCount, _
'            TintRUR, _
'            TintRTM, _
'            TintReject, _
'            TintQCgood As Integer

'            Dim TdblLabor, _
'            TdblParts, _
'            TdblWF, _
'            Thours, _
'            TgoalPointsDay As Double

'            Dim goalPoints As Double = 3.8
'            Dim SOUgoal, TOUgoal As Double

'            Dim iRow As Integer = 5


'            '//Date Range values
'            If Len(Trim(dteStart.Text)) < 1 Or Len(Trim(dteEnd.Text)) < 1 Then Exit Sub
'            startDate = Gui.Receiving.FormatDateShort(dteStart.Text)
'            endDate = Gui.Receiving.FormatDateShort(dteEnd.Text)
'            If endDate < startDate Then
'                MsgBox("The start date must be before the end date. Exiting...", MsgBoxStyle.Critical, "Date Range Invalid")
'                Exit Sub
'            End If
'            '//Date Range values

'            objXL = CreateObject("Excel.Application")
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            objXL.visible = True

'            mstartDate = startDate

'            '//Get list of Technicians
'            '//Get list of technician data for the report
'            strSQL = "select distinct security.tusers.user_fullname, security.tusers.employeeno, security.tusers.shift_id, security.tusers.TechRate, lgroups.group_desc from " & _
'            "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'            "inner join lgroups on security.tusers.group_id = lgroups.group_id " & _
'            "where cellopt_refurbcompletedt >= '" & startDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'            "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, endDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'            "order by security.tusers.user_fullname"
'            dtTechList = ds.OrderEntrySelect(strSQL)


'            '//The main report body
'            For xTechList = 0 To dtTechList.Rows.Count - 1
'                '//Get technician name and number
'                rTechList = dtTechList.Rows(xTechList)
'                techName = rTechList("user_fullname")
'                techNumber = rTechList("employeeno")
'                mHR = rTechList("TechRate")
'                '//Technician obtained


'                If xTechList > 2 Then
'                    oSheet = oWorkbook.worksheets.add 'Add worksheets for more than three technicians
'                End If

'                If xTechList = 0 Then
'                    oSheet = oWorkbook.sheets("Sheet1")
'                ElseIf xTechList = 1 Then
'                    oSheet = oWorkbook.sheets("Sheet2")
'                ElseIf xTechList = 2 Then
'                    oSheet = oWorkbook.sheets("Sheet3")
'                End If

'                iRow = 5
'                formatXLsheet_EmployeeReport(oSheet)

'                With oSheet.PageSetup
'                    .PrintTitleRows = ""
'                    .PrintTitleColumns = ""
'                End With
'                oSheet.PageSetup.PrintArea = ""
'                With oSheet.PageSetup
'                    .PrintQuality = 600
'                    .CenterHorizontally = False
'                    .CenterVertically = False
'                    .Orientation = Excel.XlPageOrientation.xlLandscape
'                    .Draft = False
'                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                    .FirstPageNumber = Excel.Constants.xlAutomatic
'                    .BlackAndWhite = False
'                    .Zoom = False
'                    .FitToPagesWide = 1
'                    .FitToPagesTall = 1
'                End With

'                oSheet.Range(CStr("B1")).Value = techName
'                oSheet.Range(CStr("E1")).Value = techNumber
'                oSheet.Range(CStr("G1")).Value = rTechList("Shift_ID")
'                oSheet.Range(CStr("I1")).Value = rTechList("Group_Desc")
'                'oSheet.Range(CStr("M1")).Value =                       '//Pay Period

'                '//Iterate through dates
'                Do Until mstartDate > endDate

'                    blnWriteDate = True

'                    '//Get Models for Date for Technician
'                    strSQL = "select distinct tdevice.model_id, tmodel.model_desc, tmodel.Weight_Factor from " & _
'                    "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                    "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                    "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                    "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                    "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                    "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                    "order by tmodel.model_desc"
'                    dtModels = ds.OrderEntrySelect(strSQL)

'                    '//Iterate through models and get data values for report
'                    For xModels = 0 To dtModels.Rows.Count - 1
'                        rModels = dtModels.Rows(xModels)
'                        modelName = rModels("model_desc")
'                        modelNumber = rModels("Model_id")
'                        modelFactor = rModels("Weight_Factor")

'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        'strSQL = "select distinct tcellopt.device_id, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        '"left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"order by tmodel.model_desc, tqc.qc_id desc"
'                        'dtModelD = ds.OrderEntrySelect(strSQL)
'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        strSQL = "select distinct tcellopt.device_id, max(tqc.qc_id) as maxID, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        "left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and tdevice.model_id = " & modelNumber & " " & _
'                        "group by tcellopt.device_id " & _
'                        "order by tmodel.model_desc, tqc.qc_id desc"
'                        dtModelD = ds.OrderEntrySelect(strSQL)

'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                        For xModelD = 0 To dtModelD.Rows.Count - 1
'                            rModelD = dtModelD.Rows(xModelD)
'                            mDeviceID = rModelD("device_id")

'                            intCount += 1

'                            '//Determine if value is complete or RUR/RTM
'                            blnRURRTM = objRURRTM.IsRURRTM(mDeviceID)
'                            If blnRURRTM = True Then
'                                '//Determine if it is RUR or RTM
'                                strSQL = "Select * from tdevicebill WHERE device_id = " & mDeviceID & " and billcode_id = 466"
'                                dtRURRTM = ds.OrderEntrySelect(strSQL)
'                                If dtRURRTM.Rows.Count > 0 Then
'                                    '//Device is RTM
'                                    intRTM += 1
'                                Else
'                                    '//Device is RUR
'                                    intRUR += 1
'                                End If
'                            Else
'                                '//Determine if it has been through QC
'                                If IsDBNull(rModelD("qcDeviceID")) = True Then
'                                    '//It has not been through QC
'                                    '//DO NOT ADD ANY VALUE
'                                Else
'                                    '//It has been QC'd
'                                    '//Determine if it is a reject or good
'                                    strSQL = "SELECT * FROM tqc WHERE Device_ID = " & mDeviceID & " ORDER BY qc_id desc"
'                                    dtQC = ds.OrderEntrySelect(strSQL)
'                                    rQC = dtQC.Rows(0)
'                                    If rQC("QCResult_ID") = 1 Then
'                                        '//Passed
'                                        intQCgood += 1
'                                    ElseIf rQC("QCResult_ID") = 2 Then
'                                        '//Failed
'                                        intReject += 1
'                                    End If
'                                End If
'                            End If
'                        Next



'                        '//Get Labor Value for techncian/day/model
'                        'strSQL = "select sum(tdevice.device_laborcharge) as vLabor from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber
'                        'dtLaborD = ds.OrderEntrySelect(strSQL)

'                        'dblLabor = 0.0
'                        'Try
'                        'rLaborD = dtLaborD.Rows(0)
'                        'dblLabor = rLaborD("vLabor")
'                        'Catch ex As Exception
'                        '    dblLabor = 0.0
'                        'End Try

'                        '//Get Part Value for technician/day/model
'                        'strSQL = "select sum(tdevicebill.dbill_invoiceamt) as vParts from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"group by tdevice.model_id"
'                        'dtPartsD = ds.OrderEntrySelect(strSQL)

'                        'dblParts = 0.0
'                        'Try
'                        'rPartsD = dtPartsD.Rows(0)
'                        'dblParts = rPartsD("vParts")
'                        'Catch ex As Exception
'                        'dblParts = 0.0
'                        'End Try

'                        dblWF = CDbl(CInt(intQCgood) * CDbl(modelFactor))

'                        '//Add to summary for day
'                        SintCount += intCount
'                        SintRUR += intRUR
'                        SintRTM += intRTM
'                        SintReject += intReject
'                        SintQCgood += intQCgood
'                        SdblLabor += dblLabor
'                        SdblParts += dblParts
'                        SdblWF += dblWF
'                        Shours += mHours

'                        '//write data for model to XL Sheet
'                        If blnWriteDate = True Then oSheet.Range(CStr("A" & iRow)).Value = mstartDate
'                        oSheet.Range(CStr("B" & iRow)).Value = modelName
'                        oSheet.Range(CStr("C" & iRow)).Value = intCount
'                        oSheet.Range(CStr("E" & iRow)).Value = intRUR
'                        oSheet.Range(CStr("F" & iRow)).Value = intRTM
'                        oSheet.Range(CStr("G" & iRow)).Value = intReject
'                        oSheet.Range(CStr("H" & iRow)).Value = intQCgood
'                        oSheet.Range(CStr("I" & iRow)).Value = dblWF



'                        'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                        'If dblWF > 0 Then
'                        'oSheet.Range(CStr("R" & iRow)).Value = dblLabor.ToString
'                        'oSheet.Range(CStr("S" & iRow)).Value = dblParts.ToString
'                        'oSheet.Range(CStr("T" & iRow)).Value = (dblLabor + dblParts).ToString
'                        'oSheet.Range(CStr("U" & iRow)).Value = (dblParts / intQCgood).ToString
'                        'Else
'                        '    oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                        '    oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                        '    oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                        '    oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                        'End If
'                        blnWriteDate = False

'                        'MsgBox("Model " & modelName & " Units " & intCount & " RUR " & intRUR & " RTM " & intRTM & " Reject " & intReject & " QCGood " & intQCgood)

'                        '//Increment row number by 1
'                        iRow += 1

'                        'MsgBox("SModel " & modelName & " SUnits " & SintCount & " SRUR " & SintRUR & " SRTM " & SintRTM & " SReject " & SintReject & " SQCGood " & SintQCgood)

'                        '//Reset int values
'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                    Next
'                    If SintCount > 0 Then

'                        Try
'                            '//Get techhours
'                            strSQL = "select techhours_hours as vHours from " & _
'                            "ttechhours where employee_no = " & techNumber & " " & _
'                            "and techhours_date = '" & mstartDate.ToString("yyyy-MM-dd") & "' "
'                            dtHours = ds.OrderEntrySelect(strSQL)
'                            rHours = dtHours.Rows(0)
'                            mHours = rHours("vHours")
'                        Catch ex As Exception
'                            mHours = 0
'                        End Try

'                        oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                        oSheet.Range(CStr("B" & iRow)).Value = "Subtotal"
'                        oSheet.Range(CStr("D" & iRow)).Value = SintCount
'                        oSheet.Range(CStr("E" & iRow)).Value = SintRUR
'                        oSheet.Range(CStr("F" & iRow)).Value = SintRTM
'                        oSheet.Range(CStr("G" & iRow)).Value = SintReject
'                        oSheet.Range(CStr("H" & iRow)).Value = SintQCgood
'                        oSheet.Range(CStr("I" & iRow)).Value = SdblWF

'                        oSheet.Range(CStr("K" & iRow)).Value = mHours
'                        oSheet.Range(CStr("L" & iRow)).Value = goalPoints
'                        oSheet.Range(CStr("M" & iRow)).Value = goalPoints * mHours
'                        oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"


'                        SOUgoal = CDbl(CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value))
'                        oSheet.Range(CStr("N" & iRow)).Value = SOUgoal
'                        oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                        oSheet.Range(CStr("P" & iRow)).Value = CDbl((CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value)) * CDbl(mHours)) / 100

'                        'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        'oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("R" & iRow)).Value = SdblLabor.ToString
'                        'oSheet.Range(CStr("S" & iRow)).Value = SdblParts.ToString
'                        'oSheet.Range(CStr("T" & iRow)).Value = (SdblLabor + SdblParts).ToString
'                        'oSheet.Range(CStr("U" & iRow)).Value = (SdblParts / SintQCgood).ToString

'                        'oSheet.Range(CStr("V" & iRow)).Value = mHours * mHR
'                        'oSheet.Range(CStr("W" & iRow)).Value = CDbl(SdblLabor) - (mHours * mHR)
'                        'oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(SdblLabor) - (mHours * mHR)) / mHours * mHR)

'                        iRow += 1
'                    End If


'                    TintCount += SintCount
'                    TintRUR += SintRUR
'                    TintRTM += SintRTM
'                    TintReject += SintReject
'                    TintQCgood += SintQCgood
'                    TdblLabor += SdblLabor
'                    TdblParts += SdblParts
'                    TdblWF += SdblWF
'                    Thours += mHours
'                    TgoalPointsDay += goalPoints * mHours
'                    TOUgoal += SOUgoal

'                    blnWriteDate = True
'                    '//Reset Sint values
'                    SintCount = 0
'                    SintRUR = 0
'                    SintRTM = 0
'                    SintReject = 0
'                    SintQCgood = 0
'                    SdblLabor = 0.0
'                    SdblParts = 0.0
'                    SdblWF = 0.0
'                    mHours = 0.0
'                    SOUgoal = 0.0

'                    mstartDate = DateAdd(DateInterval.Day, 1, mstartDate)
'                Loop

'                '//Total Line Here
'                If TintCount > 0 Then

'                    With oSheet.Range(CStr("B" & iRow) & ":" & CStr("I" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("K" & iRow) & ":" & CStr("N" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("P" & iRow) & ":" & CStr("P" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    oSheet.Rows(CStr(iRow) & ":" & CStr(iRow)).RowHeight = 25.5

'                    oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                    oSheet.Range(CStr("B" & iRow)).Value = "Totals"
'                    oSheet.Range(CStr("D" & iRow)).Value = TintCount
'                    oSheet.Range(CStr("E" & iRow)).Value = TintRUR
'                    oSheet.Range(CStr("F" & iRow)).Value = TintRTM
'                    oSheet.Range(CStr("G" & iRow)).Value = TintReject
'                    oSheet.Range(CStr("H" & iRow)).Value = TintQCgood
'                    oSheet.Range(CStr("I" & iRow)).Value = TdblWF

'                    oSheet.Range(CStr("K" & iRow)).Value = Thours

'                    oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("N" & iRow)).Value = TOUgoal
'                    oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("P" & iRow)).Value = (TOUgoal * Thours) / 100

'                    'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                    'oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                    'If TdblWF > 0 Then
'                    'oSheet.Range(CStr("R" & iRow)).Value = TdblLabor.ToString
'                    'oSheet.Range(CStr("S" & iRow)).Value = TdblParts.ToString
'                    'oSheet.Range(CStr("T" & iRow)).Value = (TdblLabor + TdblParts).ToString
'                    'oSheet.Range(CStr("U" & iRow)).Value = (TdblParts / TintQCgood).ToString
'                    'oSheet.Range(CStr("V" & iRow)).Value = Thours * mHR
'                    'oSheet.Range(CStr("W" & iRow)).Value = CDbl(TdblLabor) - (Thours * mHR)
'                    'oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(TdblLabor) - (Thours * mHR)) / Thours * mHR)
'                    'Else
'                    'oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("V" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("W" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("X" & iRow)).Value = "0.00"
'                    'End If
'                    'iRow += 1
'                End If

'                TintCount = 0
'                TintRUR = 0
'                TintRTM = 0
'                TintReject = 0
'                TintQCgood = 0
'                TdblLabor = 0.0
'                TdblParts = 0.0
'                TdblWF = 0.0
'                TgoalPointsDay = 0.0
'                TOUgoal = 0.0
'                Thours = 0.0

'                objXL.Range(CStr("A3:I" & iRow & ",K3:N" & iRow & ",P3:P" & iRow)).Select()
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                oSheet.select()
'                oSheet.Name = techNumber
'                oSheet.Range("A1").Select()

'                mstartDate = startDate  '//Return value to start date for next technician
'            Next


'            '//The main report body
'            Exit Sub
'        End Sub

'        Private Sub grpProductivity_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        End Sub

'        Private Sub formatXLsheet_SMR(ByVal mXL As Excel.Worksheet, ByVal strTitle As String)
'            Dim strColumn() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "L", "M", "N", "O", "Q", "S", "T", "U", "V", "W", "X"}
'            Dim iColumnLength() = {9, 5, 31, 31, 22, 3, 3, 7, 34, 22, 12, 19, 20, 23, 23, 9, 9, 12, 14, 14, 14}
'            Dim strColumnHeader() = {"Name", "Emp. #", "Group", "Shift", "Total Units Sent To QC", _
'                "RUR", "RTM", "Rejects", "Good Units", "Actual Points Achieved", _
'                "Hours Worked", "Goal Points", "Over or (Under) Goal", "% of Goal", "Bonus Opportunity", _
'                "Billed Labor", "Labor Cost (EE Hourly Rate x Hours)", "Gross Profit On Labor $", _
'                "Gross Profit On Labor %", "Billed Parts", "Parts AUP"}
'            Dim i As Integer

'            Try
'                mXL.Range("R1").ColumnWidth = 2
'                mXL.Range("L1").ColumnWidth = 2
'                mXL.Range("P1").ColumnWidth = 2

'                mXL.Columns("Q:Q").ColumnWidth = 11.43

'                mXL.Range("I1").FormulaR1C1 = strTitle
'                mXL.Range("I1").HorizontalAlignment = Excel.Constants.xlCenter

'                With mXL.Range("A1")
'                    .HorizontalAlignment = Excel.Constants.xlRight
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = False
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                End With

'                With mXL.Rows("4:4")
'                    .HorizontalAlignment = Excel.Constants.xlCenter
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = True
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                    .MergeCells = False
'                End With

'                For i = 0 To strColumn.Length - 1
'                    mXL.Range(strColumn(i) & "4").FormulaR1C1 = strColumnHeader(i)

'                    With mXL.Range(strColumn(i) & "4").Characters(Start:=1, Length:=iColumnLength(i)).Font
'                        .Name = "Arial"
'                        .FontStyle = "Regular"
'                        .Size = 10
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        '.Underline = Excel.Constants.xlUnderlineStyleNone
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                Next

'                mXL.Columns("S:X").ColumnWidth = 11
'                mXL.Columns("Q:Q").ColumnWidth = 11
'                mXL.Columns("L:O").ColumnWidth = 11
'                mXL.Columns("A:J").ColumnWidth = 11
'                mXL.Columns("A:A").ColumnWidth = 20
'                mXL.Range("A5").Select()
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub btnSUMmr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'            Dim mHR As Double = 0.0
'            Dim objXL, _
'            oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String

'            Dim startDate, _
'            mstartDate, _
'            endDate As Date

'            Dim blnWriteDate As Boolean

'            Dim techName As String
'            Dim techNumber As Integer

'            '//List of Technicians
'            Dim dtTechList As DataTable
'            Dim rTechList As DataRow
'            Dim xTechList As Integer = 0

'            '//Models
'            Dim dtModels As DataTable
'            Dim rModels As DataRow
'            Dim xModels As Integer = 0

'            '//Model Detail
'            Dim dtModelD As DataTable
'            Dim rModelD As DataRow
'            Dim xModelD As Integer = 0

'            '//Labor
'            Dim dtLaborD As DataTable
'            Dim rLaborD As DataRow

'            '//Parts
'            Dim dtPartsD As DataTable
'            Dim rPartsD As DataRow

'            '//TechHours
'            Dim dtHours As DataTable
'            Dim rHours As DataRow
'            Dim mHours As Double

'            '//QC
'            Dim dtQC As DataTable
'            Dim rQC As DataRow
'            Dim xQC As Integer = 0

'            Dim modelName As String
'            Dim modelNumber As Integer
'            Dim modelFactor As Double

'            Dim mDeviceID As Long
'            Dim blnRURRTM As Boolean

'            Dim objRURRTM As New PSS.Data.Buisness.clsProdTracker()

'            Dim dtRURRTM As DataTable

'            Dim intCount, _
'            intRUR, _
'            intRTM, _
'            intReject, _
'            intQCgood As Integer

'            Dim dblLabor, _
'            dblParts, _
'            dblWF As Double

'            Dim SintCount, _
'            SintRUR, _
'            SintRTM, _
'            SintReject, _
'            SintQCgood As Integer

'            Dim SdblLabor, _
'            SdblParts, _
'            SdblWF, _
'            Shours As Double

'            Dim TintCount, _
'            TintRUR, _
'            TintRTM, _
'            TintReject, _
'            TintQCgood As Integer

'            Dim TdblLabor, _
'            TdblParts, _
'            TdblWF, _
'            Thours, _
'            TgoalPointsDay As Double

'            Dim goalPoints As Double = 3.8
'            Dim SOUgoal, TOUgoal As Double

'            Dim iRow As Integer = 5


'            '//Date Range values
'            If Len(Trim(dteStart.Text)) < 1 Or Len(Trim(dteEnd.Text)) < 1 Then Exit Sub
'            startDate = Gui.Receiving.FormatDateShort(dteStart.Text)
'            endDate = Gui.Receiving.FormatDateShort(dteEnd.Text)
'            If endDate < startDate Then
'                MsgBox("The start date must be before the end date. Exiting...", MsgBoxStyle.Critical, "Date Range Invalid")
'                Exit Sub
'            End If
'            '//Date Range values

'            objXL = CreateObject("Excel.Application")
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            objXL.visible = True

'            objXL.Range("B1").FormulaR1C1 = CStr(startDate & " - " & endDate)

'            mstartDate = startDate

'            '//Get list of Technicians
'            '//Get list of technician data for the report
'            strSQL = "select distinct security.tusers.user_fullname, security.tusers.employeeno, security.tusers.shift_id, security.tusers.TechRate, lgroups.group_desc from " & _
'            "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'            "inner join lgroups on security.tusers.group_id = lgroups.group_id " & _
'            "where cellopt_refurbcompletedt >= '" & startDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'            "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, endDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'            "order by security.tusers.user_fullname"
'            dtTechList = ds.OrderEntrySelect(strSQL)


'            '//The main report body

'            oSheet = oWorkbook.sheets("Sheet1")
'            formatXLsheet_SMR(oSheet, startDate & " - " & endDate)

'            With oSheet.PageSetup
'                .PrintTitleRows = ""
'                .PrintTitleColumns = ""
'            End With
'            oSheet.PageSetup.PrintArea = ""
'            With oSheet.PageSetup
'                .PrintQuality = 600
'                .CenterHorizontally = False
'                .CenterVertically = False
'                .Orientation = Excel.XlPageOrientation.xlLandscape
'                .Draft = False
'                .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                .FirstPageNumber = Excel.Constants.xlAutomatic
'                .BlackAndWhite = False
'                .Zoom = False
'                .FitToPagesWide = 1
'                .FitToPagesTall = 1
'            End With

'            'oSheet.Range(CStr("B1")).Value = techName
'            'oSheet.Range(CStr("E1")).Value = techNumber
'            'oSheet.Range(CStr("G1")).Value = rTechList("Shift_ID")
'            'oSheet.Range(CStr("I1")).Value = rTechList("Group_Desc")
'            'oSheet.Range(CStr("M1")).Value =                       '//Pay Period

'            iRow = 5

'            For xTechList = 0 To dtTechList.Rows.Count - 1
'                '//Get technician name and number
'                rTechList = dtTechList.Rows(xTechList)
'                techName = rTechList("user_fullname")
'                techNumber = rTechList("employeeno")
'                mHR = rTechList("TechRate")
'                '//Technician obtained


'                'If xTechList > 2 Then
'                'oSheet = oWorkbook.worksheets.add 'Add worksheets for more than three technicians
'                'End If

'                'If xTechList = 0 Then
'                'oSheet = oWorkbook.sheets("Sheet1")
'                'ElseIf xTechList = 1 Then
'                '    oSheet = oWorkbook.sheets("Sheet2")
'                'ElseIf xTechList = 2 Then
'                '    oSheet = oWorkbook.sheets("Sheet3")
'                'End If



'                '//Iterate through dates
'                Do Until mstartDate > endDate

'                    blnWriteDate = True

'                    '//Get Models for Date for Technician
'                    strSQL = "select distinct tdevice.model_id, tmodel.model_desc, tmodel.Weight_Factor from " & _
'                    "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                    "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                    "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                    "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                    "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                    "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                    "order by tmodel.model_desc"
'                    dtModels = ds.OrderEntrySelect(strSQL)

'                    '//Iterate through models and get data values for report
'                    For xModels = 0 To dtModels.Rows.Count - 1
'                        rModels = dtModels.Rows(xModels)
'                        modelName = rModels("model_desc")
'                        modelNumber = rModels("Model_id")
'                        modelFactor = rModels("Weight_Factor")

'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        'strSQL = "select distinct tcellopt.device_id, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        '"left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"order by tmodel.model_desc, tqc.qc_id desc"
'                        'dtModelD = ds.OrderEntrySelect(strSQL)
'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        strSQL = "select distinct tcellopt.device_id, max(tqc.qc_id) as maxID, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        "left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and tdevice.model_id = " & modelNumber & " " & _
'                        "group by tcellopt.device_id " & _
'                        "order by tmodel.model_desc, tqc.qc_id desc"
'                        dtModelD = ds.OrderEntrySelect(strSQL)

'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                        For xModelD = 0 To dtModelD.Rows.Count - 1
'                            rModelD = dtModelD.Rows(xModelD)
'                            mDeviceID = rModelD("device_id")

'                            intCount += 1

'                            '//Determine if value is complete or RUR/RTM
'                            blnRURRTM = objRURRTM.IsRURRTM(mDeviceID)
'                            If blnRURRTM = True Then
'                                '//Determine if it is RUR or RTM
'                                strSQL = "Select * from tdevicebill WHERE device_id = " & mDeviceID & " and billcode_id = 466"
'                                dtRURRTM = ds.OrderEntrySelect(strSQL)
'                                If dtRURRTM.Rows.Count > 0 Then
'                                    '//Device is RTM
'                                    intRTM += 1
'                                Else
'                                    '//Device is RUR
'                                    intRUR += 1
'                                End If
'                            Else
'                                '//Determine if it has been through QC
'                                If IsDBNull(rModelD("qcDeviceID")) = True Then
'                                    '//It has not been through QC
'                                    '//DO NOT ADD ANY VALUE
'                                Else
'                                    '//It has been QC'd
'                                    '//Determine if it is a reject or good
'                                    strSQL = "SELECT * FROM tqc WHERE Device_ID = " & mDeviceID & " ORDER BY qc_id desc"
'                                    dtQC = ds.OrderEntrySelect(strSQL)
'                                    rQC = dtQC.Rows(0)
'                                    If rQC("QCResult_ID") = 1 Then
'                                        '//Passed
'                                        intQCgood += 1
'                                    ElseIf rQC("QCResult_ID") = 2 Then
'                                        '//Failed
'                                        intReject += 1
'                                    End If
'                                End If
'                            End If
'                        Next



'                        '//Get Labor Value for techncian/day/model
'                        strSQL = "select sum(tdevice.device_laborcharge) as vLabor from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and cellopt_qcreject = 1 " & _
'                        "and tdevice.model_id = " & modelNumber

'                        '//New November 29, 2006
'                        strSQL = "select sum(tdevice.device_laborcharge) as vLabor from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tqc on tdevice.device_id = tqc.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and cellopt_qcreject <> 2 " & _
'                        "and tdevice.model_id = " & modelNumber
'                        '//New November 29, 2006

'                        dtLaborD = ds.OrderEntrySelect(strSQL)

'                        dblLabor = 0.0
'                        Try
'                            rLaborD = dtLaborD.Rows(0)
'                            dblLabor = rLaborD("vLabor")
'                        Catch ex As Exception
'                            dblLabor = 0.0
'                        End Try

'                        ''//Get Part Value for technician/day/model
'                        'strSQL = "select sum(tdevicebill.dbill_invoiceamt) as vParts from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"group by tdevice.model_id"

'                        '//New November 29, 2006
'                        strSQL = "select sum(tdevicebill.dbill_invoiceamt) as vParts from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and cellopt_qcreject <> 2 " & _
'                        "and tdevice.model_id = " & modelNumber & " " & _
'                        "group by tdevice.model_id"
'                        '//New November 29, 2006


'                        dtPartsD = ds.OrderEntrySelect(strSQL)

'                        dblParts = 0.0
'                        Try
'                            rPartsD = dtPartsD.Rows(0)
'                            dblParts = rPartsD("vParts")
'                        Catch ex As Exception
'                            dblParts = 0.0
'                        End Try

'                        dblWF = CDbl(CInt(intQCgood) * CDbl(modelFactor))

'                        '//Add to summary for day
'                        SintCount += intCount
'                        SintRUR += intRUR
'                        SintRTM += intRTM
'                        SintReject += intReject
'                        SintQCgood += intQCgood
'                        SdblLabor += dblLabor
'                        SdblParts += dblParts
'                        SdblWF += dblWF
'                        Shours += mHours

'                        '//write data for model to XL Sheet
'                        If blnWriteDate = True Then oSheet.Range(CStr("A" & iRow)).Value = mstartDate
'                        'oSheet.Range(CStr("B" & iRow)).Value = modelName
'                        'oSheet.Range(CStr("C" & iRow)).Value = intCount
'                        'oSheet.Range(CStr("E" & iRow)).Value = intRUR
'                        'oSheet.Range(CStr("F" & iRow)).Value = intRTM
'                        'oSheet.Range(CStr("G" & iRow)).Value = intReject
'                        'oSheet.Range(CStr("H" & iRow)).Value = intQCgood
'                        'oSheet.Range(CStr("I" & iRow)).Value = dblWF

'                        'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                        If dblWF > 0 Then
'                            '    oSheet.Range(CStr("R" & iRow)).Value = dblLabor.ToString
'                            '    oSheet.Range(CStr("S" & iRow)).Value = dblParts.ToString
'                            '    oSheet.Range(CStr("T" & iRow)).Value = (dblLabor + dblParts).ToString
'                            '    oSheet.Range(CStr("U" & iRow)).Value = (dblParts / intQCgood).ToString
'                        Else
'                            '    oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                            '    oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                            '    oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                            '    oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                        End If
'                        blnWriteDate = False

'                        'MsgBox("Model " & modelName & " Units " & intCount & " RUR " & intRUR & " RTM " & intRTM & " Reject " & intReject & " QCGood " & intQCgood)

'                        '//Increment row number by 1
'                        'iRow += 1

'                        'MsgBox("SModel " & modelName & " SUnits " & SintCount & " SRUR " & SintRUR & " SRTM " & SintRTM & " SReject " & SintReject & " SQCGood " & SintQCgood)

'                        '//Reset int values
'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                    Next
'                    If SintCount > 0 Then

'                        Try
'                            '//Get techhours
'                            strSQL = "select techhours_hours as vHours from " & _
'                            "ttechhours where employee_no = " & techNumber & " " & _
'                            "and techhours_date = '" & mstartDate.ToString("yyyy-MM-dd") & "' "
'                            dtHours = ds.OrderEntrySelect(strSQL)
'                            rHours = dtHours.Rows(0)
'                            mHours = rHours("vHours")
'                        Catch ex As Exception
'                            mHours = 0
'                        End Try

'                        'oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                        'oSheet.Range(CStr("B" & iRow)).Value = "Subtotal"
'                        'oSheet.Range(CStr("D" & iRow)).Value = SintCount
'                        'oSheet.Range(CStr("E" & iRow)).Value = SintRUR
'                        'oSheet.Range(CStr("F" & iRow)).Value = SintRTM
'                        'oSheet.Range(CStr("G" & iRow)).Value = SintReject
'                        'oSheet.Range(CStr("H" & iRow)).Value = SintQCgood
'                        'oSheet.Range(CStr("I" & iRow)).Value = SdblWF

'                        'oSheet.Range(CStr("K" & iRow)).Value = mHours
'                        'oSheet.Range(CStr("L" & iRow)).Value = goalPoints
'                        'oSheet.Range(CStr("M" & iRow)).Value = goalPoints * mHours
'                        'oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"


'                        SOUgoal = CDbl(CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value))
'                        'oSheet.Range(CStr("N" & iRow)).Value = SOUgoal
'                        'oSheet.Range(CStr("P" & iRow)).Value = CDbl(CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value)) * CDbl(mHours)

'                        'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        'oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("R" & iRow)).Value = SdblLabor.ToString
'                        'oSheet.Range(CStr("S" & iRow)).Value = SdblParts.ToString
'                        'oSheet.Range(CStr("T" & iRow)).Value = (SdblLabor + SdblParts).ToString
'                        'oSheet.Range(CStr("U" & iRow)).Value = (SdblParts / SintQCgood).ToString

'                        'oSheet.Range(CStr("V" & iRow)).Value = mHours * mHR
'                        'oSheet.Range(CStr("W" & iRow)).Value = CDbl(SdblLabor) - (mHours * mHR)
'                        'oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(SdblLabor) - (mHours * mHR)) / mHours * mHR)

'                        'iRow += 1
'                    End If


'                    TintCount += SintCount
'                    TintRUR += SintRUR
'                    TintRTM += SintRTM
'                    TintReject += SintReject
'                    TintQCgood += SintQCgood
'                    TdblLabor += SdblLabor
'                    TdblParts += SdblParts
'                    TdblWF += SdblWF
'                    Thours += mHours
'                    TgoalPointsDay += goalPoints * mHours
'                    TOUgoal += SOUgoal

'                    blnWriteDate = True
'                    '//Reset Sint values
'                    SintCount = 0
'                    SintRUR = 0
'                    SintRTM = 0
'                    SintReject = 0
'                    SintQCgood = 0
'                    SdblLabor = 0.0
'                    SdblParts = 0.0
'                    SdblWF = 0.0
'                    mHours = 0.0
'                    SOUgoal = 0.0

'                    mstartDate = DateAdd(DateInterval.Day, 1, mstartDate)
'                Loop

'                '//Total Line Here
'                If TintCount > 0 Then

'                    'With oSheet.Range(CStr("B" & iRow) & ":" & CStr("H" & iRow)).font
'                    '.Name = "Arial"
'                    '.Size = 14
'                    '.Strikethrough = False
'                    '.Superscript = False
'                    '.Subscript = False
'                    '.OutlineFont = False
'                    '.Shadow = False
'                    '.ColorIndex = Excel.Constants.xlAutomatic
'                    'End With
'                    'oSheet.Rows(CStr(iRow) & ":" & CStr(iRow)).RowHeight = 25.5

'                    'oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("B" & iRow)).Font.Italic = True

'                    oSheet.Range(CStr("A" & iRow)).Value = techName
'                    oSheet.Range(CStr("B" & iRow)).Value = techNumber
'                    oSheet.Range(CStr("C" & iRow)).Value = rTechList("Group_Desc").ToString
'                    oSheet.Range(CStr("D" & iRow)).Value = rTechList("Shift_ID").ToString
'                    oSheet.Range(CStr("E" & iRow)).Value = TintCount
'                    oSheet.Range(CStr("F" & iRow)).Value = TintRUR
'                    oSheet.Range(CStr("G" & iRow)).Value = TintRTM
'                    oSheet.Range(CStr("H" & iRow)).Value = TintReject
'                    oSheet.Range(CStr("I" & iRow)).Value = TintQCgood
'                    oSheet.Range(CStr("J" & iRow & ":J" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("J" & iRow)).Value = TdblWF


'                    oSheet.Range(CStr("L" & iRow)).Value = Thours
'                    oSheet.Range(CStr("M" & iRow & ":M" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("M" & iRow)).Value = CDbl(Thours) * 3.8
'                    oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("N" & iRow)).Value = CDbl(TdblWF) - CDbl(CDbl(Thours) * 3.8)

'                    oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("P" & iRow)).Value = (TOUgoal * 2) '/ 100

'                    oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "#,##0.00%_);[Red](#,##0.00%)"
'                    'oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                    If Thours > 0 Then
'                        oSheet.Range(CStr("R" & iRow & ":R" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("S" & iRow & ":S" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("T" & iRow & ":T" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("R" & iRow)).Value = TdblLabor.ToString
'                        oSheet.Range(CStr("S" & iRow)).Value = CDbl(Thours * mHR)
'                        'oSheet.Range(CStr("S" & iRow)).Value = CDbl(TdblLabor) - (Thours * mHR)
'                        oSheet.Range(CStr("T" & iRow)).Value = CDbl((TdblLabor) - (Thours * mHR))
'                        oSheet.Range(CStr("U" & iRow & ":U" & iRow)).NumberFormat = "0.0%_);[Red](0.0%_)"
'                        oSheet.Range(CStr("U" & iRow)).Value = CDbl(CDbl(TdblLabor) - (Thours * mHR)) / CDbl(Thours * mHR)
'                        oSheet.Range(CStr("V" & iRow & ":V" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("V" & iRow)).Value = TdblParts.ToString

'                        oSheet.Range(CStr("W" & iRow & ":W" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("W" & iRow)).Value = CDbl(TdblParts.ToString) / CInt(TintCount)
'                    Else
'                        oSheet.Range(CStr("R" & iRow & ":R" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("S" & iRow & ":S" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("T" & iRow & ":T" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("U" & iRow & ":U" & iRow)).NumberFormat = "0.0%_);[Red](0.0%_)"
'                        oSheet.Range(CStr("V" & iRow & ":V" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("W" & iRow & ":W" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("V" & iRow)).Value = "0.00"
'                        oSheet.Range(CStr("W" & iRow)).Value = "0.00"
'                    End If
'                    iRow += 1
'                End If

'                TintCount = 0
'                TintRUR = 0
'                TintRTM = 0
'                TintReject = 0
'                TintQCgood = 0
'                TdblLabor = 0.0
'                TdblParts = 0.0
'                TdblWF = 0.0
'                TgoalPointsDay = 0.0
'                TOUgoal = 0.0
'                Thours = 0.0

'                objXL.Range(CStr("A4:J" & iRow & ",L4:N" & iRow & ",P4:P" & iRow & ",R4:W" & iRow)).Select()
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                oSheet.select()
'                'oSheet.Name = techNumber
'                'oSheet.Range("A1").Select()

'                mstartDate = startDate  '//Return value to start date for next technician
'            Next


'            '//The main report body
'            Exit Sub

'        End Sub

'        Private Sub btnProdRpt1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProdRpt1.Click
'            'Const dblRejectFactor As Double = 2.0
'            Dim objXL, oSheet, oWorkbook As Object
'            Dim startDate, endDate As Date
'            Dim iSheetIndex As Integer

'            Try
'                ' Date Range values
'                If Len(Trim(dteStart.Text)) < 1 Or Len(Trim(dteEnd.Text)) < 1 Then Exit Sub

'                startDate = Gui.Receiving.FormatDateShort(dteStart.Text)
'                endDate = Gui.Receiving.FormatDateShort(dteEnd.Text)

'                If endDate < startDate Then
'                    Me._objExcelOutput.DisplayMessage("The start date must precede the end date.  Exiting...", 3)

'                    Exit Sub
'                End If

'                Cursor.Current = Cursors.WaitCursor
'                Me.Enabled = False

'                objXL = CreateObject("Excel.Application")
'                oWorkbook = objXL.workbooks.add
'                objXL.Visible = True

'                oSheet = oWorkbook.Sheets("Sheet1")
'                oSheet.Activate()
'                oSheet.Name = "Cellular - Detail"
'                GetCellularDetailReport(objXL, oSheet, startDate, endDate)

'                ' Delete other unused worksheets
'                objXL.DisplayAlerts = False ' Kill the delete prompt

'                If oWorkbook.Sheets.Count > 1 Then
'                    For iSheetIndex = oWorkbook.Sheets.Count - 1 To 1 Step -1
'                        oWorkbook.Sheets("Sheet" & (iSheetIndex + 1).ToString).Delete()
'                    Next
'                End If

'                ' Make the Cellular worksheet active
'                oSheet = oWorkbook.Sheets("Cellular - Detail")
'                oSheet.select()
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            Finally
'                Me.Enabled = True
'                Cursor.Current = Cursors.Default()
'            End Try
'        End Sub

'        Private Sub GetCellularDetailReport(ByRef objXL As Object, ByRef oSheet As Object, ByVal datStart As Date, ByVal datEnd As Date)
'            Const dblRejectFactor As Double = 2.0
'            Dim iTechNumber As Integer = 0
'            Dim iRow As Integer = 5 ' First row of data
'            Dim iTechRow, iRowIndex, iMaxRow As Integer
'            Dim dblWF, dblLabor, dblParts, dblGoalPoints, dblTotalActualPoints, dblTotalParts As Double
'            Dim dtTech As DataTable = Nothing
'            Dim drTech As DataRow
'            Dim iRURCnt, iRTMCnt, iRejectsCnt, iQCCount As Integer
'            Dim dblModelFactor As Double
'            Dim dblTechHours As Double
'            Dim dblTechRate As Double
'            Dim oWorkbook As Object
'            Dim objCellularDetailData As PSS.Data.Buisness.CellularDetailData
'            Dim dtDeviceDetails, dtParts As DataTable
'            Dim drDeviceDetails, drParts As DataRow
'            Dim arrlstTechDataRows As ArrayList

'            Try
'                arrlstTechDataRows = New ArrayList()

'                oSheet.Range("I1").FormulaR1C1 = "Detailed Cellular Incentive Report for " & datStart & " - " & datEnd
'                oSheet.Range("I1").HorizontalAlignment = Excel.Constants.xlCenter

'                FormatCellularDetailXLsheet(oSheet)

'                With oSheet.PageSetup
'                    .PrintTitleRows = ""
'                    .PrintTitleColumns = ""
'                    .PrintArea = ""
'                    .PrintQuality = 600
'                    .CenterHorizontally = False
'                    .CenterVertically = False
'                    .Orientation = Excel.XlPageOrientation.xlLandscape
'                    .Draft = False
'                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                    .FirstPageNumber = Excel.Constants.xlAutomatic
'                    .BlackAndWhite = False
'                    .Zoom = False
'                    .FitToPagesWide = 1
'                    .FitToPagesTall = 1
'                End With

'                objCellularDetailData = New PSS.Data.Buisness.CellularDetailData()

'                objCellularDetailData.SetData(datStart, datEnd)
'                dtTech = objCellularDetailData.GetTechData()

'                If dtTech.Rows.Count > 0 Then
'                    dblGoalPoints = objCellularDetailData.GetStandardPointGoalsPerHour

'                    For Each drTech In dtTech.Rows
'                        If iTechNumber <> drTech("employeeno") Then
'                            iTechNumber = drTech("employeeno")

'                            iRURCnt = objCellularDetailData.GetRURRTMCount(iTechNumber, 1)
'                            iRTMCnt = objCellularDetailData.GetRURRTMCount(iTechNumber, 9)
'                            iRejectsCnt = dblRejectFactor * objCellularDetailData.GetRejectCount(iTechNumber)
'                            iQCCount = objCellularDetailData.GetGoodCount(iTechNumber)

'                            oSheet.Range(CStr("A" & iRow)).Value = drTech("user_fullname")
'                            oSheet.Range(CStr("B" & iRow)).Value = iTechNumber
'                            oSheet.Range(CStr("C" & iRow)).Value = drTech("Group_Desc").ToString
'                            oSheet.Range(CStr("D" & iRow)).Value = drTech("Shift_ID").ToString
'                            oSheet.Range(CStr("E" & iRow)).Value = iRURCnt
'                            oSheet.Range(CStr("F" & iRow)).Value = iRTMCnt
'                            oSheet.Range(CStr("G" & iRow)).Value = iQCCount
'                            oSheet.Range(CStr("H" & iRow)).Value = iRejectsCnt
'                            oSheet.Range(CStr("I" & iRow)).Value = iRURCnt + iRTMCnt + iQCCount + iRejectsCnt

'                            dblTotalActualPoints = 0
'                            iTechRow = iRow
'                            arrlstTechDataRows.Add(iTechRow)
'                            dtDeviceDetails = objCellularDetailData.GetModelDetails(iTechNumber)

'                            If Not IsNothing(dtDeviceDetails) Then
'                                For Each drDeviceDetails In dtDeviceDetails.Rows
'                                    iRow += 1
'                                    iMaxRow += 1

'                                    oSheet.Range(CStr("K" & iRow & ":K" & iRow)).HorizontalAlignment = Excel.Constants.xlLeft
'                                    oSheet.Range(CStr("K" & iRow)).Value = drDeviceDetails("Model")

'                                    oSheet.Range(CStr("L" & iRow & ":N" & iRow)).NumberFormat = "#,##0_);[Red](#,##0)"
'                                    oSheet.Range(CStr("L" & iRow)).Value = drDeviceDetails("Model RUR Count")
'                                    oSheet.Range(CStr("M" & iRow)).Value = drDeviceDetails("Model RTM Count")
'                                    oSheet.Range(CStr("N" & iRow)).Value = drDeviceDetails("Model Reject Count")

'                                    oSheet.Range(CStr("O" & iRow & ":O" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                                    oSheet.Range(CStr("O" & iRow)).Value = dblRejectFactor

'                                    oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0_);[Red](#,##0)"
'                                    oSheet.Range(CStr("P" & iRow)).Value = Math.Round(dblRejectFactor * drDeviceDetails("Model Reject Count"), 0)

'                                    oSheet.Range(CStr("Q" & iRow & ":Q" & iRow)).NumberFormat = "#,##0_);[Red](#,##0)"
'                                    oSheet.Range(CStr("Q" & iRow)).Value = drDeviceDetails("Model Good Count")

'                                    oSheet.Range(CStr("R" & iRow & ":R" & iRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
'                                    oSheet.Range(CStr("R" & iRow)).Value = drDeviceDetails("Model Units/Hour")

'                                    oSheet.Range(CStr("S" & iRow & ":S" & iRow)).NumberFormat = "#,##0%_);[Red](#,##0%)"

'                                    If iQCCount > 0 Then
'                                        oSheet.Range(CStr("S" & iRow)).Value = drDeviceDetails("Model Good Count") / CDbl(iQCCount)
'                                    Else
'                                        oSheet.Range(CStr("S" & iRow)).Value = 0
'                                    End If

'                                    oSheet.Range(CStr("T" & iRow & ":U" & iRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"

'                                    If iQCCount > 0 Then
'                                        oSheet.Range(CStr("T" & iRow)).Value = drDeviceDetails("Model Units/Hour") * drDeviceDetails("Model Good Count") / CDbl(iQCCount)
'                                    Else
'                                        oSheet.Range(CStr("T" & iRow)).Value = 0
'                                    End If

'                                    oSheet.Range(CStr("U" & iRow)).Value = drDeviceDetails("Model HPU")

'                                    oSheet.Range(CStr("Y" & iRow & ":Z" & iRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
'                                    oSheet.Range(CStr("Y" & iRow)).Value = dblGoalPoints * drDeviceDetails("Model HPU")

'                                    dblTotalActualPoints += drDeviceDetails("Model Good Count") * dblGoalPoints * drDeviceDetails("Model HPU")

'                                    oSheet.Range(CStr("Z" & iRow)).Value = drDeviceDetails("Model Good Count") * dblGoalPoints * drDeviceDetails("Model HPU")
'                                Next
'                            End If

'                            oSheet.Range(CStr("W" & iTechRow & ":W" & iTechRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
'                            oSheet.Range(CStr("W" & iTechRow)).Value = dblGoalPoints

'                            oSheet.Range(CStr("AB" & iTechRow & ":AE" & iTechRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
'                            oSheet.Range(CStr("AB" & iTechRow)).Value = dblTotalActualPoints

'                            dblTechHours = objCellularDetailData.GetTechHours(iTechNumber)
'                            oSheet.Range(CStr("AC" & iTechRow)).Value = dblTechHours
'                            oSheet.Range(CStr("AD" & iTechRow)).Value = dblGoalPoints * dblTechHours
'                            oSheet.Range(CStr("AE" & iTechRow)).Value = dblTotalActualPoints - dblGoalPoints * dblTechHours

'                            oSheet.Range(CStr("AF" & iTechRow & ":AF" & iTechRow)).NumberFormat = "#,##0.00%_);[Red](#,##0.00%)"

'                            If dblGoalPoints * dblTechHours > 0 Then
'                                oSheet.Range(CStr("AF" & iTechRow)).Value = Math.Abs((dblTotalActualPoints - dblGoalPoints * dblTechHours) / (dblGoalPoints * dblTechHours))
'                            Else
'                                oSheet.Range(CStr("AF" & iTechRow)).Value = 0
'                            End If

'                            dblTotalParts = 0
'                            dtParts = objCellularDetailData.GetPartsValue(iTechNumber)

'                            For Each drParts In dtParts.Rows
'                                If iRow > iTechRow Then
'                                    For iRowIndex = iTechRow + 1 To iRow
'                                        If oSheet.Range(CStr("K" & iRowIndex)).Value.ToString = drParts("Model") Then
'                                            oSheet.Range(CStr("AH" & iRowIndex & ":AI" & iRowIndex)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                                            oSheet.Range(CStr("AH" & iRowIndex)).Value = drParts("Parts Value")
'                                            dblTotalParts += drParts("Parts Value")

'                                            If oSheet.Range(CStr("Q" & iRowIndex)).Value > 0 Then
'                                                oSheet.Range(CStr("AI" & iRowIndex)).Value = drParts("Parts Value") / oSheet.Range(CStr("Q" & iRowIndex)).Value
'                                            Else
'                                                oSheet.Range(CStr("AI" & iRowIndex)).Value = 0
'                                            End If

'                                            Exit For
'                                        End If
'                                    Next
'                                End If
'                            Next

'                            oSheet.Range(CStr("AK" & iTechRow & ":AL" & iTechRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                            oSheet.Range(CStr("AK" & iTechRow)).Value = dblTotalParts

'                            If oSheet.Range(CStr("G" & iTechRow)).Value > 0 Then
'                                oSheet.Range(CStr("AL" & iTechRow)).Value = dblTotalParts / oSheet.Range(CStr("G" & iTechRow)).Value
'                            Else
'                                oSheet.Range(CStr("AL" & iTechRow)).Value = 0
'                            End If

'                            iRow += 1
'                        End If
'                    Next

'                    iRow -= 1

'                    objXL.Range(CStr("A4:I" & iRow.ToString & ",K4:U" & iRow.ToString & ",W4:W" & iRow.ToString & ",Y4:Z" & iRow.ToString & ",AB4:AF" & iRow.ToString & ",AH4:AI" & iRow.ToString & ",AK4:AL" & iRow.ToString)).Select()
'                    objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                    objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    iMaxRow = iRow

'                    If arrlstTechDataRows.Count > 0 Then
'                        For iRowIndex = 0 To arrlstTechDataRows.Count - 1
'                            iRow = CInt(arrlstTechDataRows(iRowIndex).ToString)

'                            objXL.Range(CStr("A" & iRow.ToString & ":I" & iRow.ToString & ",K" & iRow.ToString & ":U" & iRow.ToString & ",W" & iRow.ToString & ":W" & iRow.ToString & ",Y" & iRow.ToString & ":Z" & iRow.ToString & ",AB" & iRow.ToString & ":AF" & iRow.ToString & ",AH" & iRow.ToString & ":AI" & iRow.ToString & ",AK" & iRow.ToString & ":AL" & iRow.ToString)).Select()

'                            If oSheet.Range(CStr("AC" & iRow)).Value > 0 Then
'                                objXL.Selection.Interior.ColorIndex = 24 ' Pale violet
'                            Else
'                                objXL.Selection.Interior.ColorIndex = 27  ' Bright yellow
'                            End If

'                            If iRowIndex > 0 Then
'                                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                                    .Weight = Excel.XlBorderWeight.xlThick
'                                    .ColorIndex = Excel.Constants.xlAutomatic
'                                End With
'                            End If
'                        Next
'                    End If

'                    ' Freeze column title area
'                    objXL.ActiveWindow.FreezePanes = False
'                    objXL.Range(CStr("A5:AL5")).Select()
'                    'objXL.Range(CStr("A5:AL5,B5:B" & iMaxRow.ToString)).Select()
'                    objXL.ActiveWindow.FreezePanes = True
'                Else
'                    NoDataFormat(objXL, oSheet)
'                End If
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            Finally
'                drTech = Nothing
'                drDeviceDetails = Nothing
'                drParts = Nothing

'                If Not IsNothing(dtTech) Then
'                    dtTech.Dispose()
'                    dtTech = Nothing
'                End If

'                If Not IsNothing(dtDeviceDetails) Then
'                    dtDeviceDetails.Dispose()
'                    dtDeviceDetails = Nothing
'                End If

'                If Not IsNothing(dtParts) Then
'                    dtParts.Dispose()
'                    dtParts = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub FormatCellularDetailXLsheet(ByVal mXL As Excel.Worksheet)
'            Dim strColumn() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "Y", "Z", _
'            "AB", "AC", "AD", "AE", "AF", "AH", "AI", "AK", "AL"}
'            Dim iColumnLength() = {9, 5, 31, 31, 3, 3, 7, 7, 22, 22, 12, 19, 20, 23, 23, 9, 9, 9, 9, 12, 9, 9, 9, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12}
'            Dim strColumnHeader() = {"Name", "Emp. #", "Group", "Shift", _
'                "RUR", "RTM", "Good Units", "Rejects", "Total Units Sent To QC", _
'                "Model", "Model RUR Count", "Model RTM Count", "Model Reject Count (Actual)", "Model Reject Factor", _
'                "Model Reject Count (Used)", "Model Good Count", "Model UPH", "Model Weight", "Model Avg UPH", "Model HPU", _
'                "Goal Points/Hour", "Points/Model", "Model Total Pts.", "Actual Points Achieved", "Hours Worked", "Goal Points", _
'                "Over or (Under) Goal", "% of Goal", "Model Parts Value", "Model Parts AUP", "Parts Value", "Parts AUP"}
'            Dim i As Integer

'            Try
'                'mXL.Range("R1").ColumnWidth = 2
'                'mXL.Range("L1").ColumnWidth = 2
'                'mXL.Range("P1").ColumnWidth = 2

'                'mXL.Columns("Q:Q").ColumnWidth = 11.43

'                With mXL.Range("A1")
'                    .HorizontalAlignment = Excel.Constants.xlRight
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = False
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                End With

'                With mXL.Rows("4:4")
'                    .HorizontalAlignment = Excel.Constants.xlCenter
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = True
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                    .MergeCells = False
'                End With

'                For i = 0 To strColumn.Length - 1
'                    mXL.Range(strColumn(i) & "4").FormulaR1C1 = strColumnHeader(i)

'                    With mXL.Range(strColumn(i) & "4").Characters(Start:=1, Length:=iColumnLength(i)).Font
'                        .Name = "Arial"
'                        .FontStyle = "Regular"
'                        .Size = 10
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                Next

'                mXL.Columns("AK:AL").ColumnWidth = 11
'                mXL.Columns("AJ:AJ").ColumnWidth = 3
'                mXL.Columns("AH:AI").ColumnWidth = 11
'                mXL.Columns("AG:AG").ColumnWidth = 3
'                mXL.Columns("AB:AF").ColumnWidth = 11
'                mXL.Columns("AA:AA").ColumnWidth = 3
'                mXL.Columns("Y:Z").ColumnWidth = 15
'                mXL.Columns("X:X").ColumnWidth = 3
'                mXL.Columns("W:W").ColumnWidth = 11
'                mXL.Columns("V:V").ColumnWidth = 3
'                mXL.Columns("L:U").ColumnWidth = 11
'                mXL.Columns("K:K").ColumnWidth = 20
'                mXL.Columns("J:J").ColumnWidth = 3
'                mXL.Columns("B:I").ColumnWidth = 11
'                mXL.Columns("A:A").ColumnWidth = 20
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub btnSUMmr_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSUMmr.Click
'            'Const dblRejectFactor As Double = 2.0
'            Dim objXL, oSheet, oWorkbook As Object
'            Dim startDate, endDate As Date
'            Dim iSheetIndex As Integer

'            Try
'                ' Date Range values
'                If Len(Trim(dteStart.Text)) < 1 Or Len(Trim(dteEnd.Text)) < 1 Then Exit Sub

'                startDate = Gui.Receiving.FormatDateShort(dteStart.Text)
'                endDate = Gui.Receiving.FormatDateShort(dteEnd.Text)

'                If endDate < startDate Then
'                    Me._objExcelOutput.DisplayMessage("The start date must precede the end date.  Exiting...", 3)

'                    Exit Sub
'                End If

'                Cursor.Current = Cursors.WaitCursor
'                Me.Enabled = False

'                objXL = CreateObject("Excel.Application")
'                oWorkbook = objXL.workbooks.add
'                objXL.Visible = True

'                ' The main report body
'                For iSheetIndex = 1 To 3
'                    If oWorkbook.Sheets.Count < iSheetIndex Then oWorkbook.Sheets.Add()

'                    oSheet = oWorkbook.Sheets("Sheet" & iSheetIndex.ToString)
'                    oSheet.Activate()

'                    Select Case iSheetIndex
'                        Case 1
'                            oSheet.Name = "Cellular"
'                            GetCellularReport(objXL, oSheet, startDate, endDate)
'                        Case 2
'                            oSheet.Name = "GameStop"
'                            GetGSMsgReport(objXL, oSheet, startDate, endDate, Data.Buisness.ExcelOutput.ReportType.GAME_STOP)
'                        Case 3
'                            oSheet.Name = "Messaging"
'                            GetGSMsgReport(objXL, oSheet, startDate, endDate, Data.Buisness.ExcelOutput.ReportType.MESSAGING)
'                    End Select
'                Next

'                ' Make the Cellular worksheet active
'                oSheet = oWorkbook.Sheets("Cellular")
'                oSheet.select()
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            Finally
'                Me.Enabled = True
'                Cursor.Current = Cursors.Default()
'            End Try
'        End Sub

'        Private Sub GetCellularReport(ByRef objXL As Object, ByRef oSheet As Object, ByVal datStart As Date, ByVal datEnd As Date)
'            Const dblRejectFactor As Double = 2.0
'            Dim iTechNumber As Integer = 0
'            Dim iRow As Integer = 5 ' First row of data
'            Dim dblWF, dblLabor, dblParts, dblGoalPoints As Double
'            Dim dtTech As DataTable = Nothing
'            Dim drTech As DataRow
'            Dim iRURCnt, iRTMCnt, iRejectsCnt, iQCCount As Integer
'            Dim dblModelFactor As Double
'            Dim dblTechHours As Double
'            Dim dblTechRate As Double
'            Dim oWorkbook As Object

'            Try
'                oSheet.Range("I1").FormulaR1C1 = "Cellular Incentive Report for " & datStart & " - " & datEnd
'                oSheet.Range("I1").HorizontalAlignment = Excel.Constants.xlCenter

'                FormatCellularXLsheet_SMR(oSheet)

'                With oSheet.PageSetup
'                    .PrintTitleRows = ""
'                    .PrintTitleColumns = ""
'                    .PrintArea = ""
'                    .PrintQuality = 600
'                    .CenterHorizontally = False
'                    .CenterVertically = False
'                    .Orientation = Excel.XlPageOrientation.xlLandscape
'                    .Draft = False
'                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                    .FirstPageNumber = Excel.Constants.xlAutomatic
'                    .BlackAndWhite = False
'                    .Zoom = False
'                    .FitToPagesWide = 1
'                    .FitToPagesTall = 1
'                End With

'                Me._objExcelOutput.SetData(datStart, datEnd)
'                dtTech = Me._objExcelOutput.GetTechData(Data.Buisness.ExcelOutput.ReportType.CELLULAR)

'                If dtTech.Rows.Count > 0 Then
'                    For Each drTech In dtTech.Rows
'                        If iTechNumber <> drTech("employeeno") Then
'                            iTechNumber = drTech("employeeno")

'                            iRURCnt = Me._objExcelOutput.GetRURRTMCount(iTechNumber, 1)
'                            iRTMCnt = Me._objExcelOutput.GetRURRTMCount(iTechNumber, 9)
'                            iRejectsCnt = dblRejectFactor * Me._objExcelOutput.GetRejectCount(iTechNumber)
'                            iQCCount = Me._objExcelOutput.GetGoodCount(iTechNumber)

'                            oSheet.Range(CStr("A" & iRow)).Value = drTech("user_fullname")
'                            oSheet.Range(CStr("B" & iRow)).Value = iTechNumber
'                            oSheet.Range(CStr("C" & iRow)).Value = drTech("Group_Desc").ToString
'                            oSheet.Range(CStr("D" & iRow)).Value = drTech("Shift_ID").ToString
'                            oSheet.Range(CStr("E" & iRow)).Value = iRURCnt + iRTMCnt + iRejectsCnt + iQCCount
'                            oSheet.Range(CStr("F" & iRow)).Value = iRURCnt
'                            oSheet.Range(CStr("G" & iRow)).Value = iRTMCnt
'                            oSheet.Range(CStr("H" & iRow)).Value = iRejectsCnt

'                            dblWF = Me._objExcelOutput.GetActualPoints(iTechNumber)
'                            oSheet.Range(CStr("I" & iRow)).Value = iQCCount
'                            oSheet.Range(CStr("J" & iRow)).Value = dblWF
'                            oSheet.Range(CStr("J" & iRow & ":J" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"

'                            dblTechHours = Me._objExcelOutput.GetTechHours(drTech("employeeno"))
'                            oSheet.Range(CStr("L" & iRow & ":L" & iRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
'                            oSheet.Range(CStr("L" & iRow)).Value = dblTechHours

'                            dblGoalPoints = Me._objExcelOutput.GetGoalPoints(dblTechHours)
'                            oSheet.Range(CStr("M" & iRow & ":M" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                            oSheet.Range(CStr("M" & iRow)).Value = dblGoalPoints
'                            oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                            oSheet.Range(CStr("N" & iRow)).Value = dblWF - dblGoalPoints

'                            oSheet.Range(CStr("O" & iRow & ":O" & iRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"

'                            If dblTechHours = 0 Then
'                                oSheet.Range(CStr("O" & iRow)).Value = 0
'                            Else
'                                oSheet.Range(CStr("O" & iRow)).Value = 100.0 * dblWF / dblGoalPoints
'                            End If

'                            oSheet.Range(CStr("Q" & iRow & ":Q" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                            oSheet.Range(CStr("Q" & iRow)).Value = (dblWF - dblGoalPoints) * 2.0  'the 2 is the number of dollars per point awarded

'                            dblLabor = Me._objExcelOutput.GetLaborValue(iTechNumber)
'                            dblTechRate = Me._objExcelOutput.GetTechRate(iTechNumber)

'                            oSheet.Range(CStr("S" & iRow & ":S" & iRow)).NumberFormat = "#,##0.00%_);[Red](#,##0.00%)"

'                            If dblTechHours > 0 Then
'                                oSheet.Range(CStr("S" & iRow & ":S" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("T" & iRow & ":T" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("U" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                                oSheet.Range(CStr("S" & iRow)).Value = dblLabor.ToString
'                                oSheet.Range(CStr("T" & iRow)).Value = dblTechHours * dblTechRate
'                                oSheet.Range(CStr("U" & iRow)).Value = dblLabor - (dblTechHours * dblTechRate)
'                                oSheet.Range(CStr("V" & iRow & ":V" & iRow)).NumberFormat = "0.0%_);[Red](0.0%)"

'                                If dblLabor = 0.0 Then
'                                    oSheet.Range(CStr("V" & iRow)).Value = "UNKNOWN"
'                                ElseIf dblTechHours * dblTechRate < 0.01 Then
'                                    oSheet.Range(CStr("V" & iRow)).Value = "1"
'                                Else
'                                    oSheet.Range(CStr("V" & iRow)).Value = (dblLabor - (dblTechHours * dblTechRate)) / (dblTechHours * dblTechRate)
'                                End If

'                                dblParts = Me._objExcelOutput.GetPartsValue(iTechNumber)
'                                oSheet.Range(CStr("W" & iRow & ":W" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("W" & iRow)).Value = dblParts

'                                oSheet.Range(CStr("X" & iRow & ":X" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                                If iQCCount > 0 Then
'                                    oSheet.Range(CStr("X" & iRow)).Value = dblParts / CDbl(iQCCount)
'                                Else
'                                    oSheet.Range(CStr("X" & iRow)).Value = 0
'                                End If
'                            Else
'                                oSheet.Range(CStr("S" & iRow & ":S" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("T" & iRow & ":T" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("U" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("V" & iRow & ":V" & iRow)).NumberFormat = "0.0%_);[Red](0.0%)"
'                                oSheet.Range(CStr("W" & iRow & ":W" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("X" & iRow & ":X" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                                oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                                oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                                oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                                oSheet.Range(CStr("V" & iRow)).Value = "0.00"
'                                oSheet.Range(CStr("W" & iRow)).Value = "0.00"
'                                oSheet.Range(CStr("X" & iRow)).Value = "0.00"

'                                ' Set row background color to yellow.
'                                objXL.Range(CStr("A" & iRow & ":J" & iRow & ",L" & iRow & ":O" & iRow & ",Q" & iRow & ":Q" & iRow & ",S" & iRow & ":X" & iRow)).Select()
'                                objXL.Selection.Interior.ColorIndex = 27 ' Bright yellow
'                            End If

'                            iRow += 1
'                        End If
'                    Next

'                    iRow -= 1

'                    objXL.Range(CStr("A4:J" & iRow & ",L4:O" & iRow & ",Q4:Q" & iRow & ",S4:X" & iRow)).Select()
'                    objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                    objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    ' Freeze column title area
'                    objXL.ActiveWindow.FreezePanes = False
'                    objXL.Range(CStr("A5:X5")).Select()
'                    objXL.ActiveWindow.FreezePanes = True
'                Else
'                    NoDataFormat(objXL, oSheet)
'                End If
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            Finally
'                drTech = Nothing

'                If Not IsNothing(dtTech) Then
'                    dtTech.Dispose()
'                    dtTech = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub FormatCellularXLsheet_SMR(ByVal mXL As Excel.Worksheet)
'            Dim strColumn() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "L", "M", "N", "O", "Q", "S", "T", "U", "V", "W", "X"}
'            Dim iColumnLength() = {9, 5, 31, 31, 22, 3, 3, 7, 34, 22, 12, 19, 20, 23, 23, 9, 9, 12, 14, 14, 14}
'            Dim strColumnHeader() = {"Name", "Emp. #", "Group", "Shift", "Total Units Sent To QC", _
'                "RUR", "RTM", "Rejects", "Good Units", "Actual Points Achieved", _
'                "Hours Worked", "Goal Points", "Over or (Under) Goal", "% of Goal", "Bonus Opportunity", _
'                "Billed Labor", "Labor Cost (EE Hourly Rate x Hours)", "Gross Profit On Labor $", _
'                "Gross Profit On Labor %", "Billed Parts", "Parts AUP"}
'            Dim i As Integer

'            Try
'                mXL.Range("R1").ColumnWidth = 2
'                mXL.Range("L1").ColumnWidth = 2
'                mXL.Range("P1").ColumnWidth = 2

'                mXL.Columns("Q:Q").ColumnWidth = 11.43

'                With mXL.Range("A1")
'                    .HorizontalAlignment = Excel.Constants.xlRight
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = False
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                End With

'                With mXL.Rows("4:4")
'                    .HorizontalAlignment = Excel.Constants.xlCenter
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = True
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                    .MergeCells = False
'                End With

'                For i = 0 To strColumn.Length - 1
'                    mXL.Range(strColumn(i) & "4").FormulaR1C1 = strColumnHeader(i)

'                    With mXL.Range(strColumn(i) & "4").Characters(Start:=1, Length:=iColumnLength(i)).Font
'                        .Name = "Arial"
'                        .FontStyle = "Regular"
'                        .Size = 10
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        '.Underline = Excel.Constants.xlUnderlineStyleNone
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                Next

'                mXL.Columns("S:X").ColumnWidth = 11
'                mXL.Columns("Q:Q").ColumnWidth = 11
'                mXL.Columns("L:O").ColumnWidth = 11
'                mXL.Columns("B:J").ColumnWidth = 11
'                mXL.Columns("A:A").ColumnWidth = 20
'                mXL.Range("A5").Select()
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub GetGSMsgReport(ByRef objXL As Object, ByRef oSheet As Object, ByVal datStart As Date, ByVal datEnd As Date, ByVal rt As Data.Buisness.ExcelOutput.ReportType)
'            Const dblRejectFactor As Double = 2.0
'            Dim iTechNumber As Integer = 0
'            Dim iRow As Integer = 5
'            Dim dtTech As DataTable = Nothing
'            Dim drTech As DataRow
'            Dim dblTechHours As Double
'            Dim oWorkbook As Object
'            Dim strReportType As String = ""
'            Dim iProduction As Integer

'            Try
'                If rt = Data.Buisness.ExcelOutput.ReportType.GAME_STOP Then
'                    strReportType = "GameStop"
'                Else
'                    strReportType = "Messaging"
'                End If

'                oSheet.Range("I1").FormulaR1C1 = strReportType & " Incentive Report for " & datStart & " - " & datEnd
'                oSheet.Range("I1").HorizontalAlignment = Excel.Constants.xlCenter

'                With oSheet.PageSetup
'                    .PrintTitleRows = ""
'                    .PrintTitleColumns = ""
'                    .PrintArea = ""
'                    .PrintQuality = 600
'                    .CenterHorizontally = False
'                    .CenterVertically = False
'                    .Orientation = Excel.XlPageOrientation.xlLandscape
'                    .Draft = False
'                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                    .FirstPageNumber = Excel.Constants.xlAutomatic
'                    .BlackAndWhite = False
'                    .Zoom = False
'                    .FitToPagesWide = 1
'                    .FitToPagesTall = 1
'                End With

'                dtTech = Me._objExcelOutput.GetTechData(rt)

'                If dtTech.Rows.Count > 0 Then
'                    FormatGSMsgXLsheet_SMR(oSheet)
'                    iRow = 5 ' First row of data

'                    For Each drTech In dtTech.Rows
'                        If iTechNumber <> drTech("employeeno") Then
'                            iTechNumber = drTech("employeeno")
'                            dblTechHours = Me._objExcelOutput.GetTechHours(iTechNumber, rt)
'                            iProduction = Me._objExcelOutput.GetProduction(iTechNumber, rt)

'                            oSheet.Range(CStr("A" & iRow)).Value = drTech("user_fullname")
'                            oSheet.Range(CStr("B" & iRow)).Value = iTechNumber
'                            oSheet.Range(CStr("C" & iRow)).Value = drTech("Group_Desc").ToString
'                            oSheet.Range(CStr("D" & iRow)).Value = drTech("Shift_ID").ToString
'                            oSheet.Range(CStr("E" & iRow & ":E" & iRow)).NumberFormat = "#,##0.00_);[Red](#,##0.00)"
'                            oSheet.Range(CStr("E" & iRow)).Value = dblTechHours
'                            oSheet.Range(CStr("F" & iRow & ":F" & iRow)).NumberFormat = "#,##0_);[Red](#,##0)"
'                            oSheet.Range(CStr("F" & iRow)).Value = iProduction

'                            If dblTechHours = 0 Then
'                                ' Set row background color to yellow.
'                                'objXL.Range(CStr("A" & iRow & ":J" & iRow & ",L" & iRow & ":O" & iRow & ",Q" & iRow & ":Q" & iRow & ",S" & iRow & ":X" & iRow)).Select()
'                                objXL.Range(CStr("A" & iRow & ":F" & iRow)).Select()
'                                objXL.Selection.Interior.ColorIndex = 27 ' Bright yellow
'                            End If

'                            iRow += 1
'                        End If
'                    Next

'                    iRow -= 1

'                    'objXL.Range(CStr("A4:J" & iRow & ",L4:O" & iRow & ",Q4:Q" & iRow & ",S4:X" & iRow)).Select()
'                    objXL.Range(CStr("A4:F" & iRow)).Select()
'                    objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                    objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                        .LineStyle = Excel.XlLineStyle.xlContinuous
'                        .Weight = Excel.XlBorderWeight.xlThin
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With

'                    ' Freeze column title area
'                    objXL.ActiveWindow.FreezePanes = False
'                    objXL.Range(CStr("A5:F5")).Select()
'                    objXL.ActiveWindow.FreezePanes = True
'                Else
'                    NoDataFormat(objXL, oSheet)
'                End If
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            Finally
'                drTech = Nothing

'                If Not IsNothing(dtTech) Then
'                    dtTech.Dispose()
'                    dtTech = Nothing
'                End If
'            End Try
'        End Sub

'        Private Sub FormatGSMsgXLsheet_SMR(ByVal oSheet As Excel.Worksheet)
'            Dim strColumn() = {"A", "B", "C", "D", "E", "F"}
'            Dim iColumnLength() = {9, 5, 31, 31, 12, 22}
'            Dim strColumnHeader() = {"Name", "Emp. #", "Group", "Shift", "Hours Worked", "Production"}
'            Dim i As Integer

'            Try
'                'oSheet.Range("R1").ColumnWidth = 2
'                'oSheet.Range("L1").ColumnWidth = 2
'                'oSheet.Range("P1").ColumnWidth = 2

'                'oSheet.Columns("Q:Q").ColumnWidth = 11.43

'                With oSheet.Range("A1")
'                    .HorizontalAlignment = Excel.Constants.xlRight
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = False
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                End With

'                With oSheet.Rows("4:4")
'                    .HorizontalAlignment = Excel.Constants.xlCenter
'                    .VerticalAlignment = Excel.Constants.xlBottom
'                    .WrapText = True
'                    .Orientation = 0
'                    .AddIndent = False
'                    .ShrinkToFit = False
'                    .MergeCells = False
'                End With

'                For i = 0 To strColumn.Length - 1
'                    oSheet.Range(strColumn(i) & "4").FormulaR1C1 = strColumnHeader(i)

'                    With oSheet.Range(strColumn(i) & "4").Characters(Start:=1, Length:=iColumnLength(i)).Font
'                        .Name = "Arial"
'                        .FontStyle = "Regular"
'                        .Size = 10
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                Next

'                oSheet.Columns("A:A").ColumnWidth = 20
'                oSheet.Columns("B:F").ColumnWidth = 11
'                oSheet.Range("A5").Select()
'            Catch ex As Exception
'                Me._objExcelOutput.DisplayMessage(ex.Message)
'            End Try
'        End Sub

'        Private Sub NoDataFormat(ByRef objXL As Object, ByRef oSheet As Object)
'            With oSheet.Range("I3").Characters(Start:=1, Length:=20).Font
'                .Name = "Arial"
'                .FontStyle = "Bold"
'                .Size = 14
'                .Strikethrough = False
'                .Superscript = False
'                .Subscript = False
'                .OutlineFont = False
'                .Shadow = False
'                .ColorIndex = Excel.Constants.xlAutomatic
'            End With

'            objXL.Range("I3").Select()
'            objXL.Selection.Interior.ColorIndex = 3 ' Red
'            oSheet.Range("I3").FormulaR1C1 = "No Data"

'            With oSheet.Range("I3")
'                .HorizontalAlignment = Excel.Constants.xlCenter
'                .VerticalAlignment = Excel.Constants.xlBottom
'                .WrapText = False
'                .Orientation = 0
'                .AddIndent = False
'                .ShrinkToFit = False
'            End With

'            oSheet.Columns("I").ColumnWidth = 20
'        End Sub

'        Private Sub btnEmployeeReport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployeeReport.Click


'            Dim mHR As Double = 0.0
'            Dim objXL, _
'            oSheet As Object
'            Dim ds As PSS.Data.Production.Joins
'            Dim strSQL As String

'            Dim startDate, _
'            mstartDate, _
'            endDate As Date

'            Dim blnWriteDate As Boolean

'            Dim techName As String
'            Dim techNumber As Integer

'            '//List of Technicians
'            Dim dtTechList As DataTable
'            Dim rTechList As DataRow
'            Dim xTechList As Integer = 0

'            '//Models
'            Dim dtModels As DataTable
'            Dim rModels As DataRow
'            Dim xModels As Integer = 0

'            '//Model Detail
'            Dim dtModelD As DataTable
'            Dim rModelD As DataRow
'            Dim xModelD As Integer = 0

'            '//Labor
'            Dim dtLaborD As DataTable
'            Dim rLaborD As DataRow

'            '//Parts
'            Dim dtPartsD As DataTable
'            Dim rPartsD As DataRow

'            '//TechHours
'            Dim dtHours As DataTable
'            Dim rHours As DataRow
'            Dim mHours As Double

'            '//QC
'            Dim dtQC As DataTable
'            Dim rQC As DataRow
'            Dim xQC As Integer = 0

'            Dim modelName As String
'            Dim modelNumber As Integer
'            Dim modelFactor As Double

'            Dim mDeviceID As Long
'            Dim blnRURRTM As Boolean

'            Dim objRURRTM As New PSS.Data.Buisness.clsProdTracker()

'            Dim dtRURRTM As DataTable

'            Dim intCount, _
'            intRUR, _
'            intRTM, _
'            intReject, _
'            intQCgood As Integer

'            Dim dblLabor, _
'            dblParts, _
'            dblWF As Double

'            Dim SintCount, _
'            SintRUR, _
'            SintRTM, _
'            SintReject, _
'            SintQCgood As Integer

'            Dim SdblLabor, _
'            SdblParts, _
'            SdblWF, _
'            Shours As Double

'            Dim TintCount, _
'            TintRUR, _
'            TintRTM, _
'            TintReject, _
'            TintQCgood As Integer

'            Dim TdblLabor, _
'            TdblParts, _
'            TdblWF, _
'            Thours, _
'            TgoalPointsDay As Double

'            Dim goalPoints As Double = 3.8
'            Dim SOUgoal, TOUgoal As Double

'            Dim iRow As Integer = 5


'            '//Date Range values
'            If Len(Trim(dteStart.Text)) < 1 Or Len(Trim(dteEnd.Text)) < 1 Then Exit Sub
'            startDate = Gui.Receiving.FormatDateShort(dteStart.Text)
'            endDate = Gui.Receiving.FormatDateShort(dteEnd.Text)
'            If endDate < startDate Then
'                MsgBox("The start date must be before the end date. Exiting...", MsgBoxStyle.Critical, "Date Range Invalid")
'                Exit Sub
'            End If
'            '//Date Range values

'            objXL = CreateObject("Excel.Application")
'            Dim oWorkbook As Object
'            oWorkbook = objXL.workbooks.add
'            objXL.visible = True

'            mstartDate = startDate

'            '//Get list of Technicians
'            '//Get list of technician data for the report
'            strSQL = "select distinct security.tusers.user_fullname, security.tusers.employeeno, security.tusers.shift_id, security.tusers.TechRate, lgroups.group_desc from " & _
'            "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'            "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'            "inner join lgroups on security.tusers.group_id = lgroups.group_id " & _
'            "where cellopt_refurbcompletedt >= '" & startDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'            "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, endDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'            "order by security.tusers.user_fullname"
'            dtTechList = ds.OrderEntrySelect(strSQL)


'            '//The main report body
'            For xTechList = 0 To dtTechList.Rows.Count - 1
'                '//Get technician name and number
'                rTechList = dtTechList.Rows(xTechList)
'                techName = rTechList("user_fullname")
'                techNumber = rTechList("employeeno")
'                mHR = rTechList("TechRate")
'                '//Technician obtained


'                If xTechList > 2 Then
'                    oSheet = oWorkbook.worksheets.add 'Add worksheets for more than three technicians
'                End If

'                If xTechList = 0 Then
'                    oSheet = oWorkbook.sheets("Sheet1")
'                ElseIf xTechList = 1 Then
'                    oSheet = oWorkbook.sheets("Sheet2")
'                ElseIf xTechList = 2 Then
'                    oSheet = oWorkbook.sheets("Sheet3")
'                End If

'                iRow = 5
'                formatXLsheet_EmployeeReport(oSheet)

'                With oSheet.PageSetup
'                    .PrintTitleRows = ""
'                    .PrintTitleColumns = ""
'                End With
'                oSheet.PageSetup.PrintArea = ""
'                With oSheet.PageSetup
'                    .PrintQuality = 600
'                    .CenterHorizontally = False
'                    .CenterVertically = False
'                    .Orientation = Excel.XlPageOrientation.xlLandscape
'                    .Draft = False
'                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
'                    .FirstPageNumber = Excel.Constants.xlAutomatic
'                    .BlackAndWhite = False
'                    .Zoom = False
'                    .FitToPagesWide = 1
'                    .FitToPagesTall = 1
'                End With

'                oSheet.Range(CStr("B1")).Value = techName
'                oSheet.Range(CStr("E1")).Value = techNumber
'                oSheet.Range(CStr("G1")).Value = rTechList("Shift_ID")
'                oSheet.Range(CStr("I1")).Value = rTechList("Group_Desc")
'                'oSheet.Range(CStr("M1")).Value =                       '//Pay Period

'                '//Iterate through dates
'                Do Until mstartDate > endDate

'                    blnWriteDate = True

'                    '//Get Models for Date for Technician
'                    strSQL = "select distinct tdevice.model_id, tmodel.model_desc, tmodel.Weight_Factor from " & _
'                    "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                    "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                    "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                    "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                    "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                    "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                    "order by tmodel.model_desc"
'                    dtModels = ds.OrderEntrySelect(strSQL)

'                    '//Iterate through models and get data values for report
'                    For xModels = 0 To dtModels.Rows.Count - 1
'                        rModels = dtModels.Rows(xModels)
'                        modelName = rModels("model_desc")
'                        modelNumber = rModels("Model_id")
'                        modelFactor = rModels("Weight_Factor")

'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        'strSQL = "select distinct tcellopt.device_id, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        '"left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"order by tmodel.model_desc, tqc.qc_id desc"
'                        'dtModelD = ds.OrderEntrySelect(strSQL)
'                        '//Get model detail information
'                        '//Get Model Detail for Date for Technician
'                        strSQL = "select distinct tcellopt.device_id, max(tqc.qc_id) as maxID, tqc.qcresult_id, tqc.device_id as qcDeviceID from " & _
'                        "tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        "inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
'                        "left outer join tqc on tdevice.device_id = tqc.device_id " & _
'                        "where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        "and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        "and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        "and tdevice.model_id = " & modelNumber & " " & _
'                        "group by tcellopt.device_id " & _
'                        "order by tmodel.model_desc, tqc.qc_id desc"
'                        dtModelD = ds.OrderEntrySelect(strSQL)

'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                        For xModelD = 0 To dtModelD.Rows.Count - 1
'                            rModelD = dtModelD.Rows(xModelD)
'                            mDeviceID = rModelD("device_id")

'                            intCount += 1

'                            '//Determine if value is complete or RUR/RTM
'                            blnRURRTM = objRURRTM.IsRURRTM(mDeviceID)
'                            If blnRURRTM = True Then
'                                '//Determine if it is RUR or RTM
'                                strSQL = "Select * from tdevicebill WHERE device_id = " & mDeviceID & " and billcode_id = 466"
'                                dtRURRTM = ds.OrderEntrySelect(strSQL)
'                                If dtRURRTM.Rows.Count > 0 Then
'                                    '//Device is RTM
'                                    intRTM += 1
'                                Else
'                                    '//Device is RUR
'                                    intRUR += 1
'                                End If
'                            Else
'                                '//Determine if it has been through QC
'                                If IsDBNull(rModelD("qcDeviceID")) = True Then
'                                    '//It has not been through QC
'                                    '//DO NOT ADD ANY VALUE
'                                Else
'                                    '//It has been QC'd
'                                    '//Determine if it is a reject or good
'                                    strSQL = "SELECT * FROM tqc WHERE Device_ID = " & mDeviceID & " ORDER BY qc_id desc"
'                                    dtQC = ds.OrderEntrySelect(strSQL)
'                                    rQC = dtQC.Rows(0)
'                                    If rQC("QCResult_ID") = 1 Then
'                                        '//Passed
'                                        intQCgood += 1
'                                    ElseIf rQC("QCResult_ID") = 2 Then
'                                        '//Failed
'                                        intReject += 1
'                                    End If
'                                End If
'                            End If
'                        Next



'                        '//Get Labor Value for techncian/day/model
'                        'strSQL = "select sum(tdevice.device_laborcharge) as vLabor from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber
'                        'dtLaborD = ds.OrderEntrySelect(strSQL)

'                        'dblLabor = 0.0
'                        'Try
'                        'rLaborD = dtLaborD.Rows(0)
'                        'dblLabor = rLaborD("vLabor")
'                        'Catch ex As Exception
'                        '    dblLabor = 0.0
'                        'End Try

'                        '//Get Part Value for technician/day/model
'                        'strSQL = "select sum(tdevicebill.dbill_invoiceamt) as vParts from " & _
'                        '"tcellopt inner join security.tusers on tcellopt.cellopt_refurbcompleteuserid = security.tusers.user_id " & _
'                        '"inner join tdevice on tcellopt.device_id = tdevice.device_id " & _
'                        '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
'                        '"where cellopt_refurbcompletedt >= '" & mstartDate.ToString("yyyy-MM-dd") & " 06:00:00' " & _
'                        '"and cellopt_refurbcompletedt <= '" & DateAdd(DateInterval.Day, 1, mstartDate).ToString("yyyy-MM-dd") & " 04:00:00' " & _
'                        '"and cellopt_refurbcompleteuserid = " & PSS.Core.ApplicationUser.IDuser & " " & _
'                        '"and cellopt_qcreject = 1 " & _
'                        '"and tdevice.model_id = " & modelNumber & " " & _
'                        '"group by tdevice.model_id"
'                        'dtPartsD = ds.OrderEntrySelect(strSQL)

'                        'dblParts = 0.0
'                        'Try
'                        'rPartsD = dtPartsD.Rows(0)
'                        'dblParts = rPartsD("vParts")
'                        'Catch ex As Exception
'                        'dblParts = 0.0
'                        'End Try

'                        dblWF = CDbl(CInt(intQCgood) * CDbl(modelFactor))

'                        '//Add to summary for day
'                        SintCount += intCount
'                        SintRUR += intRUR
'                        SintRTM += intRTM
'                        SintReject += intReject
'                        SintQCgood += intQCgood
'                        SdblLabor += dblLabor
'                        SdblParts += dblParts
'                        SdblWF += dblWF
'                        Shours += mHours

'                        '//write data for model to XL Sheet
'                        If blnWriteDate = True Then oSheet.Range(CStr("A" & iRow)).Value = mstartDate
'                        oSheet.Range(CStr("B" & iRow)).Value = modelName
'                        oSheet.Range(CStr("C" & iRow)).Value = intCount
'                        oSheet.Range(CStr("E" & iRow)).Value = intRUR
'                        oSheet.Range(CStr("F" & iRow)).Value = intRTM
'                        oSheet.Range(CStr("G" & iRow)).Value = intReject
'                        oSheet.Range(CStr("H" & iRow)).Value = intQCgood
'                        oSheet.Range(CStr("I" & iRow)).Value = dblWF



'                        'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"

'                        'If dblWF > 0 Then
'                        'oSheet.Range(CStr("R" & iRow)).Value = dblLabor.ToString
'                        'oSheet.Range(CStr("S" & iRow)).Value = dblParts.ToString
'                        'oSheet.Range(CStr("T" & iRow)).Value = (dblLabor + dblParts).ToString
'                        'oSheet.Range(CStr("U" & iRow)).Value = (dblParts / intQCgood).ToString
'                        'Else
'                        '    oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                        '    oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                        '    oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                        '    oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                        'End If
'                        blnWriteDate = False

'                        'MsgBox("Model " & modelName & " Units " & intCount & " RUR " & intRUR & " RTM " & intRTM & " Reject " & intReject & " QCGood " & intQCgood)

'                        '//Increment row number by 1
'                        iRow += 1

'                        'MsgBox("SModel " & modelName & " SUnits " & SintCount & " SRUR " & SintRUR & " SRTM " & SintRTM & " SReject " & SintReject & " SQCGood " & SintQCgood)

'                        '//Reset int values
'                        intCount = 0
'                        intRUR = 0
'                        intRTM = 0
'                        intReject = 0
'                        intQCgood = 0
'                        dblLabor = 0.0
'                        dblParts = 0.0
'                        dblWF = 0.0

'                    Next
'                    If SintCount > 0 Then

'                        Try
'                            '//Get techhours
'                            strSQL = "select techhours_hours as vHours from " & _
'                            "ttechhours where employee_no = " & techNumber & " " & _
'                            "and techhours_date = '" & mstartDate.ToString("yyyy-MM-dd") & "' "
'                            dtHours = ds.OrderEntrySelect(strSQL)
'                            rHours = dtHours.Rows(0)
'                            mHours = rHours("vHours")
'                        Catch ex As Exception
'                            mHours = 0
'                        End Try

'                        oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                        oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                        oSheet.Range(CStr("B" & iRow)).Value = "Subtotal"
'                        oSheet.Range(CStr("D" & iRow)).Value = SintCount
'                        oSheet.Range(CStr("E" & iRow)).Value = SintRUR
'                        oSheet.Range(CStr("F" & iRow)).Value = SintRTM
'                        oSheet.Range(CStr("G" & iRow)).Value = SintReject
'                        oSheet.Range(CStr("H" & iRow)).Value = SintQCgood
'                        oSheet.Range(CStr("I" & iRow)).Value = SdblWF

'                        oSheet.Range(CStr("K" & iRow)).Value = mHours
'                        oSheet.Range(CStr("L" & iRow)).Value = goalPoints
'                        oSheet.Range(CStr("M" & iRow)).Value = goalPoints * mHours
'                        oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"


'                        SOUgoal = CDbl(CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value))
'                        oSheet.Range(CStr("N" & iRow)).Value = SOUgoal
'                        oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                        oSheet.Range(CStr("P" & iRow)).Value = CDbl((CDbl(SdblWF) - CDbl(oSheet.range(CStr("M" & iRow)).value)) * CDbl(mHours)) / 100

'                        'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                        'oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                        'oSheet.Range(CStr("R" & iRow)).Value = SdblLabor.ToString
'                        'oSheet.Range(CStr("S" & iRow)).Value = SdblParts.ToString
'                        'oSheet.Range(CStr("T" & iRow)).Value = (SdblLabor + SdblParts).ToString
'                        'oSheet.Range(CStr("U" & iRow)).Value = (SdblParts / SintQCgood).ToString

'                        'oSheet.Range(CStr("V" & iRow)).Value = mHours * mHR
'                        'oSheet.Range(CStr("W" & iRow)).Value = CDbl(SdblLabor) - (mHours * mHR)
'                        'oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(SdblLabor) - (mHours * mHR)) / mHours * mHR)

'                        iRow += 1
'                    End If


'                    TintCount += SintCount
'                    TintRUR += SintRUR
'                    TintRTM += SintRTM
'                    TintReject += SintReject
'                    TintQCgood += SintQCgood
'                    TdblLabor += SdblLabor
'                    TdblParts += SdblParts
'                    TdblWF += SdblWF
'                    Thours += mHours
'                    TgoalPointsDay += goalPoints * mHours
'                    TOUgoal += SOUgoal

'                    blnWriteDate = True
'                    '//Reset Sint values
'                    SintCount = 0
'                    SintRUR = 0
'                    SintRTM = 0
'                    SintReject = 0
'                    SintQCgood = 0
'                    SdblLabor = 0.0
'                    SdblParts = 0.0
'                    SdblWF = 0.0
'                    mHours = 0.0
'                    SOUgoal = 0.0

'                    mstartDate = DateAdd(DateInterval.Day, 1, mstartDate)
'                Loop

'                '//Total Line Here
'                If TintCount > 0 Then

'                    With oSheet.Range(CStr("B" & iRow) & ":" & CStr("I" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("K" & iRow) & ":" & CStr("N" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    With oSheet.Range(CStr("P" & iRow) & ":" & CStr("P" & iRow)).font
'                        .Name = "Arial"
'                        .Size = 12
'                        .Strikethrough = False
'                        .Superscript = False
'                        .Subscript = False
'                        .OutlineFont = False
'                        .Shadow = False
'                        .ColorIndex = Excel.Constants.xlAutomatic
'                    End With
'                    oSheet.Rows(CStr(iRow) & ":" & CStr(iRow)).RowHeight = 25.5

'                    oSheet.Range(CStr("D" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("E" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("F" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("G" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("H" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("I" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("B" & iRow)).Font.Bold = True
'                    oSheet.Range(CStr("B" & iRow)).Font.Italic = True
'                    oSheet.Range(CStr("B" & iRow)).Value = "Totals"
'                    oSheet.Range(CStr("D" & iRow)).Value = TintCount
'                    oSheet.Range(CStr("E" & iRow)).Value = TintRUR
'                    oSheet.Range(CStr("F" & iRow)).Value = TintRTM
'                    oSheet.Range(CStr("G" & iRow)).Value = TintReject
'                    oSheet.Range(CStr("H" & iRow)).Value = TintQCgood
'                    oSheet.Range(CStr("I" & iRow)).Value = TdblWF

'                    oSheet.Range(CStr("K" & iRow)).Value = Thours

'                    oSheet.Range(CStr("N" & iRow & ":N" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("N" & iRow)).Value = TOUgoal
'                    oSheet.Range(CStr("P" & iRow & ":P" & iRow)).NumberFormat = "#,##0.0_);[Red](#,##0.0)"
'                    oSheet.Range(CStr("P" & iRow)).Value = (TOUgoal * Thours) / 100

'                    'oSheet.Range(CStr("R" & iRow & ":U" & iRow)).NumberFormat = "$#,##0.00_);[Red]($#,##0.00)"
'                    'oSheet.Range(CStr("R" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("S" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("T" & iRow)).Font.Bold = True
'                    'oSheet.Range(CStr("U" & iRow)).Font.Bold = True
'                    'If TdblWF > 0 Then
'                    'oSheet.Range(CStr("R" & iRow)).Value = TdblLabor.ToString
'                    'oSheet.Range(CStr("S" & iRow)).Value = TdblParts.ToString
'                    'oSheet.Range(CStr("T" & iRow)).Value = (TdblLabor + TdblParts).ToString
'                    'oSheet.Range(CStr("U" & iRow)).Value = (TdblParts / TintQCgood).ToString
'                    'oSheet.Range(CStr("V" & iRow)).Value = Thours * mHR
'                    'oSheet.Range(CStr("W" & iRow)).Value = CDbl(TdblLabor) - (Thours * mHR)
'                    'oSheet.Range(CStr("X" & iRow)).Value = CDbl(CDbl(CDbl(TdblLabor) - (Thours * mHR)) / Thours * mHR)
'                    'Else
'                    'oSheet.Range(CStr("R" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("S" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("T" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("U" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("V" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("W" & iRow)).Value = "0.00"
'                    'oSheet.Range(CStr("X" & iRow)).Value = "0.00"
'                    'End If
'                    'iRow += 1
'                End If

'                TintCount = 0
'                TintRUR = 0
'                TintRTM = 0
'                TintReject = 0
'                TintQCgood = 0
'                TdblLabor = 0.0
'                TdblParts = 0.0
'                TdblWF = 0.0
'                TgoalPointsDay = 0.0
'                TOUgoal = 0.0
'                Thours = 0.0

'                objXL.Range(CStr("A3:I" & iRow & ",K3:N" & iRow & ",P3:P" & iRow)).Select()
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
'                objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
'                    .LineStyle = Excel.XlLineStyle.xlContinuous
'                    .Weight = Excel.XlBorderWeight.xlThin
'                    .ColorIndex = Excel.Constants.xlAutomatic
'                End With
'                oSheet.select()
'                oSheet.Name = techNumber
'                oSheet.Range("A1").Select()

'                mstartDate = startDate  '//Return value to start date for next technician
'            Next


'            '//The main report body
'            Exit Sub

'        End Sub

'    End Class

'End Namespace
