Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Imports PSS.Data
Imports PSS.Core
Imports PSS.rules
Imports PSS.Core.Global
Imports System
Imports System.Data
Imports System.GC
Imports System.IO

Imports System.Data.OleDb
Imports System.Net
Imports System.Net.Dns


Namespace Gui

    Public Class frmAdminBrightPoint
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
        Friend WithEvents btnCloseReport As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lblIncoming As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnInvoice As System.Windows.Forms.Button
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Button8 As System.Windows.Forms.Button
        Friend WithEvents grpDeviceLaborUpdate As System.Windows.Forms.GroupBox
        Friend WithEvents lblStart As System.Windows.Forms.Label
        Friend WithEvents lblEnd As System.Windows.Forms.Label
        Friend WithEvents cboStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnProcess As System.Windows.Forms.Button
        Friend WithEvents btnProcess2 As System.Windows.Forms.Button
        Friend WithEvents Button11 As System.Windows.Forms.Button
        Friend WithEvents lblWIP As System.Windows.Forms.Label
        Friend WithEvents lblClosed As System.Windows.Forms.Label
        Friend WithEvents lblInvoice As System.Windows.Forms.Label
        Friend WithEvents cmdLoadRecData As System.Windows.Forms.Button
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents cmdAutoBill As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dtpEndDt As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpStartDt As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cmdCheckMap As System.Windows.Forms.Button
        Friend WithEvents btnAutoBillATCLE As System.Windows.Forms.Button
        Friend WithEvents grpboxBrightpoin As System.Windows.Forms.GroupBox
        Friend WithEvents grpboxATCLE As System.Windows.Forms.GroupBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btnAutoBillPrebillDevs As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnCloseReport = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cmdLoadRecData = New System.Windows.Forms.Button()
            Me.lblIncoming = New System.Windows.Forms.Label()
            Me.lblWIP = New System.Windows.Forms.Label()
            Me.lblClosed = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Button8 = New System.Windows.Forms.Button()
            Me.btnInvoice = New System.Windows.Forms.Button()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Button11 = New System.Windows.Forms.Button()
            Me.grpDeviceLaborUpdate = New System.Windows.Forms.GroupBox()
            Me.btnProcess2 = New System.Windows.Forms.Button()
            Me.btnProcess = New System.Windows.Forms.Button()
            Me.cboEnd = New System.Windows.Forms.DateTimePicker()
            Me.cboStart = New System.Windows.Forms.DateTimePicker()
            Me.lblEnd = New System.Windows.Forms.Label()
            Me.lblStart = New System.Windows.Forms.Label()
            Me.lblInvoice = New System.Windows.Forms.Label()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.cmdAutoBill = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dtpEndDt = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dtpStartDt = New System.Windows.Forms.DateTimePicker()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cmdCheckMap = New System.Windows.Forms.Button()
            Me.btnAutoBillATCLE = New System.Windows.Forms.Button()
            Me.grpboxBrightpoin = New System.Windows.Forms.GroupBox()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.grpboxATCLE = New System.Windows.Forms.GroupBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.btnAutoBillPrebillDevs = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.grpDeviceLaborUpdate.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.grpboxBrightpoin.SuspendLayout()
            Me.grpboxATCLE.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnCloseReport
            '
            Me.btnCloseReport.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCloseReport.ForeColor = System.Drawing.Color.Black
            Me.btnCloseReport.Location = New System.Drawing.Point(136, 176)
            Me.btnCloseReport.Name = "btnCloseReport"
            Me.btnCloseReport.Size = New System.Drawing.Size(200, 32)
            Me.btnCloseReport.TabIndex = 2
            Me.btnCloseReport.Text = "Close Report"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLoadRecData})
            Me.Panel1.Location = New System.Drawing.Point(21, 39)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(216, 40)
            Me.Panel1.TabIndex = 3
            '
            'cmdLoadRecData
            '
            Me.cmdLoadRecData.BackColor = System.Drawing.Color.Green
            Me.cmdLoadRecData.ForeColor = System.Drawing.Color.White
            Me.cmdLoadRecData.Location = New System.Drawing.Point(6, 8)
            Me.cmdLoadRecData.Name = "cmdLoadRecData"
            Me.cmdLoadRecData.Size = New System.Drawing.Size(200, 23)
            Me.cmdLoadRecData.TabIndex = 1
            Me.cmdLoadRecData.Text = "Load XML - FTP Incoming (ALL)"
            '
            'lblIncoming
            '
            Me.lblIncoming.ForeColor = System.Drawing.Color.Black
            Me.lblIncoming.Location = New System.Drawing.Point(21, 22)
            Me.lblIncoming.Name = "lblIncoming"
            Me.lblIncoming.Size = New System.Drawing.Size(144, 16)
            Me.lblIncoming.TabIndex = 4
            Me.lblIncoming.Text = "Incoming Procedures"
            '
            'lblWIP
            '
            Me.lblWIP.ForeColor = System.Drawing.Color.Black
            Me.lblWIP.Location = New System.Drawing.Point(21, 86)
            Me.lblWIP.Name = "lblWIP"
            Me.lblWIP.Size = New System.Drawing.Size(144, 16)
            Me.lblWIP.TabIndex = 5
            Me.lblWIP.Text = "WIP Procedures"
            '
            'lblClosed
            '
            Me.lblClosed.ForeColor = System.Drawing.Color.Black
            Me.lblClosed.Location = New System.Drawing.Point(21, 150)
            Me.lblClosed.Name = "lblClosed"
            Me.lblClosed.Size = New System.Drawing.Size(144, 16)
            Me.lblClosed.TabIndex = 6
            Me.lblClosed.Text = "Closed Item Procedures"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Location = New System.Drawing.Point(21, 103)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(216, 40)
            Me.Panel2.TabIndex = 7
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button8})
            Me.Panel3.Location = New System.Drawing.Point(21, 167)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(408, 40)
            Me.Panel3.TabIndex = 8
            '
            'Button8
            '
            Me.Button8.BackColor = System.Drawing.Color.SteelBlue
            Me.Button8.ForeColor = System.Drawing.Color.White
            Me.Button8.Location = New System.Drawing.Point(208, 6)
            Me.Button8.Name = "Button8"
            Me.Button8.Size = New System.Drawing.Size(192, 23)
            Me.Button8.TabIndex = 3
            Me.Button8.Text = "Close Report REPLACEMENT"
            '
            'btnInvoice
            '
            Me.btnInvoice.BackColor = System.Drawing.Color.SteelBlue
            Me.btnInvoice.ForeColor = System.Drawing.Color.White
            Me.btnInvoice.Location = New System.Drawing.Point(8, 6)
            Me.btnInvoice.Name = "btnInvoice"
            Me.btnInvoice.Size = New System.Drawing.Size(192, 24)
            Me.btnInvoice.TabIndex = 9
            Me.btnInvoice.Text = "Invoice"
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button11, Me.btnInvoice})
            Me.Panel4.Location = New System.Drawing.Point(21, 232)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(408, 40)
            Me.Panel4.TabIndex = 10
            Me.Panel4.Visible = False
            '
            'Button11
            '
            Me.Button11.BackColor = System.Drawing.Color.SteelBlue
            Me.Button11.ForeColor = System.Drawing.Color.White
            Me.Button11.Location = New System.Drawing.Point(208, 6)
            Me.Button11.Name = "Button11"
            Me.Button11.Size = New System.Drawing.Size(192, 24)
            Me.Button11.TabIndex = 19
            Me.Button11.Text = "Invoice from Excel"
            '
            'grpDeviceLaborUpdate
            '
            Me.grpDeviceLaborUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnProcess2, Me.btnProcess, Me.cboEnd, Me.cboStart, Me.lblEnd, Me.lblStart})
            Me.grpDeviceLaborUpdate.Location = New System.Drawing.Point(277, 15)
            Me.grpDeviceLaborUpdate.Name = "grpDeviceLaborUpdate"
            Me.grpDeviceLaborUpdate.Size = New System.Drawing.Size(152, 128)
            Me.grpDeviceLaborUpdate.TabIndex = 18
            Me.grpDeviceLaborUpdate.TabStop = False
            '
            'btnProcess2
            '
            Me.btnProcess2.ForeColor = System.Drawing.Color.Black
            Me.btnProcess2.Location = New System.Drawing.Point(8, 96)
            Me.btnProcess2.Name = "btnProcess2"
            Me.btnProcess2.Size = New System.Drawing.Size(136, 23)
            Me.btnProcess2.TabIndex = 5
            Me.btnProcess2.Text = "Process Updates"
            '
            'btnProcess
            '
            Me.btnProcess.ForeColor = System.Drawing.Color.Black
            Me.btnProcess.Location = New System.Drawing.Point(8, 64)
            Me.btnProcess.Name = "btnProcess"
            Me.btnProcess.Size = New System.Drawing.Size(136, 23)
            Me.btnProcess.TabIndex = 4
            Me.btnProcess.Text = "Modification Count"
            '
            'cboEnd
            '
            Me.cboEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.cboEnd.Location = New System.Drawing.Point(48, 40)
            Me.cboEnd.Name = "cboEnd"
            Me.cboEnd.Size = New System.Drawing.Size(96, 22)
            Me.cboEnd.TabIndex = 3
            '
            'cboStart
            '
            Me.cboStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.cboStart.Location = New System.Drawing.Point(48, 16)
            Me.cboStart.Name = "cboStart"
            Me.cboStart.Size = New System.Drawing.Size(96, 22)
            Me.cboStart.TabIndex = 2
            '
            'lblEnd
            '
            Me.lblEnd.ForeColor = System.Drawing.Color.Black
            Me.lblEnd.Location = New System.Drawing.Point(8, 44)
            Me.lblEnd.Name = "lblEnd"
            Me.lblEnd.Size = New System.Drawing.Size(40, 16)
            Me.lblEnd.TabIndex = 1
            Me.lblEnd.Text = "End:"
            Me.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStart
            '
            Me.lblStart.ForeColor = System.Drawing.Color.Black
            Me.lblStart.Location = New System.Drawing.Point(8, 20)
            Me.lblStart.Name = "lblStart"
            Me.lblStart.Size = New System.Drawing.Size(40, 16)
            Me.lblStart.TabIndex = 0
            Me.lblStart.Text = "Start:"
            Me.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInvoice
            '
            Me.lblInvoice.ForeColor = System.Drawing.Color.Black
            Me.lblInvoice.Location = New System.Drawing.Point(21, 216)
            Me.lblInvoice.Name = "lblInvoice"
            Me.lblInvoice.Size = New System.Drawing.Size(144, 16)
            Me.lblInvoice.TabIndex = 19
            Me.lblInvoice.Text = "Invoice"
            Me.lblInvoice.Visible = False
            '
            'Panel5
            '
            Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.Panel4, Me.lblInvoice, Me.Panel3, Me.lblIncoming, Me.lblClosed, Me.grpDeviceLaborUpdate, Me.lblWIP, Me.Panel2})
            Me.Panel5.Location = New System.Drawing.Point(392, 392)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(152, 56)
            Me.Panel5.TabIndex = 20
            Me.Panel5.Visible = False
            '
            'cmdAutoBill
            '
            Me.cmdAutoBill.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdAutoBill.ForeColor = System.Drawing.Color.Black
            Me.cmdAutoBill.Location = New System.Drawing.Point(136, 24)
            Me.cmdAutoBill.Name = "cmdAutoBill"
            Me.cmdAutoBill.Size = New System.Drawing.Size(200, 32)
            Me.cmdAutoBill.TabIndex = 21
            Me.cmdAutoBill.Text = "AUTO-BILL"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(146, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 102
            Me.Label1.Text = "To Work Date:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpEndDt
            '
            Me.dtpEndDt.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDt.Location = New System.Drawing.Point(258, 40)
            Me.dtpEndDt.Name = "dtpEndDt"
            Me.dtpEndDt.Size = New System.Drawing.Size(90, 20)
            Me.dtpEndDt.TabIndex = 101
            Me.dtpEndDt.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(130, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 100
            Me.Label4.Text = "From Work Date:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpStartDt
            '
            Me.dtpStartDt.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDt.Location = New System.Drawing.Point(258, 16)
            Me.dtpStartDt.Name = "dtpStartDt"
            Me.dtpStartDt.Size = New System.Drawing.Size(90, 20)
            Me.dtpStartDt.TabIndex = 99
            Me.dtpStartDt.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Yellow
            Me.Label2.Location = New System.Drawing.Point(34, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(70, 23)
            Me.Label2.TabIndex = 103
            Me.Label2.Text = "STEP 1:"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Yellow
            Me.Label3.Location = New System.Drawing.Point(16, 184)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(77, 23)
            Me.Label3.TabIndex = 104
            Me.Label3.Text = "STEP 4:"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Yellow
            Me.Label5.Location = New System.Drawing.Point(16, 32)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(78, 23)
            Me.Label5.TabIndex = 105
            Me.Label5.Text = "STEP 2:"
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Blue
            Me.Label7.Location = New System.Drawing.Point(16, 136)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(77, 23)
            Me.Label7.TabIndex = 108
            Me.Label7.Text = "STEP 3:"
            '
            'cmdCheckMap
            '
            Me.cmdCheckMap.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCheckMap.ForeColor = System.Drawing.Color.Blue
            Me.cmdCheckMap.Location = New System.Drawing.Point(136, 128)
            Me.cmdCheckMap.Name = "cmdCheckMap"
            Me.cmdCheckMap.Size = New System.Drawing.Size(200, 32)
            Me.cmdCheckMap.TabIndex = 107
            Me.cmdCheckMap.Text = "Check Mapping"
            '
            'btnAutoBillATCLE
            '
            Me.btnAutoBillATCLE.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnAutoBillATCLE.ForeColor = System.Drawing.Color.Red
            Me.btnAutoBillATCLE.Location = New System.Drawing.Point(136, 32)
            Me.btnAutoBillATCLE.Name = "btnAutoBillATCLE"
            Me.btnAutoBillATCLE.Size = New System.Drawing.Size(200, 32)
            Me.btnAutoBillATCLE.TabIndex = 109
            Me.btnAutoBillATCLE.Text = "AUTO-BILL ATCLE"
            '
            'grpboxBrightpoin
            '
            Me.grpboxBrightpoin.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAutoBillPrebillDevs, Me.lblStatus, Me.btnCloseReport, Me.Label5, Me.Label3, Me.cmdAutoBill, Me.cmdCheckMap, Me.Label7})
            Me.grpboxBrightpoin.ForeColor = System.Drawing.Color.White
            Me.grpboxBrightpoin.Location = New System.Drawing.Point(8, 72)
            Me.grpboxBrightpoin.Name = "grpboxBrightpoin"
            Me.grpboxBrightpoin.Size = New System.Drawing.Size(568, 232)
            Me.grpboxBrightpoin.TabIndex = 111
            Me.grpboxBrightpoin.TabStop = False
            Me.grpboxBrightpoin.Text = "Brightpoint"
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Yellow
            Me.lblStatus.Location = New System.Drawing.Point(360, 32)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(200, 24)
            Me.lblStatus.TabIndex = 109
            Me.lblStatus.Text = "STATUS"
            '
            'grpboxATCLE
            '
            Me.grpboxATCLE.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.btnAutoBillATCLE})
            Me.grpboxATCLE.Location = New System.Drawing.Point(8, 320)
            Me.grpboxATCLE.Name = "grpboxATCLE"
            Me.grpboxATCLE.Size = New System.Drawing.Size(360, 136)
            Me.grpboxATCLE.TabIndex = 112
            Me.grpboxATCLE.TabStop = False
            Me.grpboxATCLE.Text = "ATCLE"
            Me.grpboxATCLE.Visible = False
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Yellow
            Me.Label8.Location = New System.Drawing.Point(16, 40)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(78, 23)
            Me.Label8.TabIndex = 110
            Me.Label8.Text = "STEP 2:"
            '
            'btnAutoBillPrebillDevs
            '
            Me.btnAutoBillPrebillDevs.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnAutoBillPrebillDevs.ForeColor = System.Drawing.Color.Black
            Me.btnAutoBillPrebillDevs.Location = New System.Drawing.Point(16, 80)
            Me.btnAutoBillPrebillDevs.Name = "btnAutoBillPrebillDevs"
            Me.btnAutoBillPrebillDevs.Size = New System.Drawing.Size(320, 32)
            Me.btnAutoBillPrebillDevs.TabIndex = 110
            Me.btnAutoBillPrebillDevs.Text = "AUTO-BILL PRE-BILL DEVICES"
            '
            'frmAdminBrightPoint
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(728, 470)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpboxATCLE, Me.grpboxBrightpoin, Me.Label2, Me.Panel5, Me.dtpStartDt, Me.Label4, Me.Label1, Me.dtpEndDt})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.Color.White
            Me.Name = "frmAdminBrightPoint"
            Me.Text = "Brightpoint XML Administration"
            Me.Panel1.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.grpDeviceLaborUpdate.ResumeLayout(False)
            Me.Panel5.ResumeLayout(False)
            Me.grpboxBrightpoin.ResumeLayout(False)
            Me.grpboxATCLE.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "HidingSection"
        Public Function FormatDate(ByVal valStartDate As Date) As String

            FormatDate = ""

            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String

            Dim vHour As String
            Dim vMinute As String
            Dim vSecond As String

            Dim valDate As Date
            valDate = valStartDate

            vMnth = DatePart(DateInterval.Month, valDate)
            vDay = DatePart(DateInterval.Day, valDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, valDate)

            vHour = DatePart(DateInterval.Hour, valDate)
            vMinute = DatePart(DateInterval.Minute, valDate)
            vSecond = DatePart(DateInterval.Second, valDate)

            FormatDate = vYear & "-" & vMnth & "-" & vDay & " " & vHour & ":" & vMinute & ":" & vSecond
        End Function


        Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click

            Dim strFile As String = "cell240383_0009_PSSI.txt"
            Dim strData As String = ""

            Dim vsWriter As StreamWriter

            Dim fs As New FileStream("C:\\cellstar_wip_xml\Current\INVOICE\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)


            Dim ds As PSS.Data.production.Joins
            Dim strSQL As String
            Dim dt As DataTable
            Dim r As DataRow
            Dim x As Integer

            Dim strCustomer As String = "Brightpoint, Ltd."
            Dim strAddress1 As String = "601 S. Royal Lane"
            Dim strAddress2 As String = ""
            Dim strCity As String = "Coppell"
            Dim strState As String = "TX"
            Dim strZip As String = "75019"
            Dim strPhone As String = ""
            Dim strServiceCenter As String = "0001"

            Dim strDateIn As String = "09/13/06"
            Dim strDateOut As String = "09/15/06"
            Dim strRepairLevel As String = "R"
            Dim strComplaint As String = "NO COMPLAINT GIVEN"
            Dim strLabor As String = "5.00"
            Dim strParts As String = "1.00"
            Dim strICRT As String = ""
            Dim strService As String = "Replace Mechanical Part"
            Dim strPartNumber As String
            Dim strPartQty As String = "1"

            Dim strHeader As String = ""
            strHeader = "EnterpriseCode" & vbTab & _
                        "Service Invoice" & vbTab & _
                        "ESN" & vbTab & _
                        "Model" & vbTab & _
                        "Customer" & vbTab & _
                        "Address One" & vbTab & _
                        "Address Two" & vbTab & _
                        "City" & vbTab & _
                        "State" & vbTab & _
                        "Zip" & vbTab & _
                        "Phone" & vbTab & _
                        "Service Center" & vbTab & _
                        "Date In" & vbTab & _
                        "Date Out" & vbTab & _
                        "Repair Level" & vbTab & _
                        "Complaint" & vbTab & _
                        "Labor Cost" & vbTab & _
                        "Parts Cost" & vbTab & _
                        "ICRT" & vbTab & _
                        "Service" & vbTab & _
                        "Part #" & vbTab & _
                        "Qty"

            s.WriteLine(strHeader)
            System.Windows.Forms.Application.DoEvents()

            'strSQL = "SELECT * FROM cstincomingdata WHERE flgReceived = 1"
            'strSQL = "SELECT * FROM cstincomingdata INNER JOIN tdevice ON cstincomingdata.csin_esn = tdevice.device_sn " & _
            '"WHERE ClosedStatusSent = 1 and Invoice_Sent = 0"

            '//New November 7, 2006
            strSQL = "SELECT cstincomingdata.*, tdevice.* FROM " & _
            "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
            "inner join cstincomingdata on tdevice.device_sn = cstincomingdata.csin_esn and " & _
            "tworkorder.wo_custwo = cstincomingdata.csin_repairordernum " & _
            "WHERE  Invoice_Sent = 0 " & _
            "and tdevice.device_dateship > '2006-12-04 00:00:00' " & _
            "and tdevice.device_dateship < '2006-12-11 00:00:00'"
            dt = ds.OrderEntrySelect(strSQL)

            '//WHERE ClosedStatusSent = 1 and

            Dim dtParts As DataTable
            Dim rParts As DataRow
            Dim vParts As Double

            Dim dtLabor As DataTable
            Dim rLabor As DataRow
            Dim vLabor As Double

            Dim dtService As DataTable
            Dim rService As DataRow
            Dim vService As String
            Dim xService As Integer = 0

            Dim dtRepairStatus As DataTable
            Dim mRepairStatus As String
            Dim xRS As Integer
            Dim rRS As DataRow

            For x = 0 To dt.Rows.Count - 1
                r = dt.Rows(x)

                strData += r("csin_EnterpriseCode").ToString & vbTab
                strData += r("csin_RepairOrderNum").ToString & vbTab
                strData += r("csin_ESN").ToString & vbTab
                strData += r("csin_Model").ToString & vbTab
                strData += strCustomer & vbTab
                strData += strAddress1 & vbTab
                strData += strAddress2 & vbTab
                strData += strCity & vbTab
                strData += strState & vbTab
                strData += strZip & vbTab
                strData += strPhone & vbTab
                strData += strServiceCenter & vbTab
                strData += Format(r("Device_DateRec"), "MMddyyyy") & vbTab
                strData += Format(r("Device_DateShip"), "MMddyyyy") & vbTab


                mRepairStatus = ""
                strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_rule FROM tdevice " & _
                "INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & _
                "WHERE tdevice.device_sn = '" & r("csin_ESN") & "' " & _
            "and tdevice.device_dateship > '2006-12-04 00:00:00' " & _
            "and tdevice.device_dateship < '2006-12-11 00:00:00'"
                dtRepairStatus = ds.OrderEntrySelect(strSQL)

                For xRS = 0 To dtRepairStatus.Rows.Count - 1
                    rRS = dtRepairStatus.Rows(xRS)
                    'RUR
                    If rRS("billcode_rule") = 1 Or rRS("billcode_rule") = 2 Then
                        mRepairStatus = "0"
                        Exit For
                    End If
                    'No Trouble Found
                    If rRS("billcode_id") = 541 Or rRS("billcode_id") = 533 Then
                        mRepairStatus = "5"
                        Exit For
                    End If
                    'Flashing
                    If rRS("billcode_id") = 442 Or rRS("billcode_id") = 255 Or rRS("billcode_id") = 1010 Then
                        mRepairStatus = "6"
                        Exit For
                    End If
                    'Cancelled
                    If rRS("billcode_id") = 466 Then
                        mRepairStatus = "7"
                        Exit For
                    End If
                Next


                If mRepairStatus = "" Then
                    mRepairStatus = r("Device_LaborLevel")
                End If

                If mRepairStatus = "5" Then
                    If r("Device_LaborLevel") > 1 Then
                        mRepairStatus = r("Device_LaborLevel")
                    End If
                End If

                strData += mRepairStatus & vbTab

                strData += strComplaint & vbTab

                strSQL = "select tdevice.device_sn, tdevice.device_Laborcharge as amountLabor from " & _
                "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                "where tdevice.device_sn = '" & r("csin_ESN") & "' " & _
            "and tdevice.device_dateship > '2006-12-04 00:00:00' " & _
            "and tdevice.device_dateship < '2006-12-11 00:00:00'"

                dtLabor = ds.OrderEntrySelect(strSQL)
                System.Windows.Forms.Application.DoEvents()
                Try
                    rLabor = dtLabor.Rows(0)
                    vLabor = FormatNumber(rLabor("amountLabor"), 2)
                Catch ex As Exception
                    MsgBox("vLabor has failed on device_id = " & r("csin_ESN"), MsgBoxStyle.Critical, "ERROR")
                End Try

                Dim sl As String = String.Format("{0:n2}", vLabor)

                strData += sl & vbTab

                'strSQL = "select tdevice.device_sn, sum(tdevicebill.dbill_invoiceamt) as amountParts from " & _
                '"cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                '"inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                '"where tdevice.device_sn = '" & r("csin_ESN") & "'" & _
                '"group by cstincomingdata.csin_esn "

                strSQL = "select tdevice.device_sn, sum(tdevicebill.dbill_invoiceamt) as amountParts from " & _
                "tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
                "inner join cstincomingdata on tdevice.device_sn = cstincomingdata.csin_esn and " & _
                "tworkorder.wo_custwo = cstincomingdata.csin_repairordernum " & _
                "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                "where tdevice.device_sn = '" & r("csin_ESN") & "' " & _
            "and tdevice.device_dateship > '2006-12-04 00:00:00' " & _
            "and tdevice.device_dateship < '2006-12-11 00:00:00'" & _
                "group by cstincomingdata.csin_esn "

                dtParts = ds.OrderEntrySelect(strSQL)
                System.Windows.Forms.Application.DoEvents()
                Try
                    rParts = dtParts.Rows(0)
                    vParts = FormatNumber(rParts("amountParts"), 2)
                Catch ex As Exception
                    MsgBox("vParts has failed on device_id = " & r("csin_ESN"), MsgBoxStyle.Critical, "ERROR")
                End Try


                Dim sp As String = String.Format("{0:n2}", vParts)

                strData += sp & vbTab

                strData += strICRT & vbTab

                strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                "where cstincomingdata.csin_esn = '" & r("csin_ESN") & "' " & _
                "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
            "and tdevice.device_dateship > '2006-12-04 00:00:00' " & _
            "and tdevice.device_dateship < '2006-12-11 00:00:00'" & _
                "order by laborlvl_id desc"

                dtService = ds.OrderEntrySelect(strSQL)
                System.Windows.Forms.Application.DoEvents()
                Try
                    vService = ""
                    For xService = 0 To dtService.Rows.Count - 1
                        rService = dtService.Rows(xService)
                        If xService = dtService.Rows.Count - 1 Then
                            vService += rService("mService")
                        Else
                            vService += rService("mService") & " ;  "
                        End If
                    Next

                    If mRepairStatus = 6 Then
                        vService = "WIPEDOWN"
                    End If
                    If mRepairStatus = 0 Then
                        vService = "BER"
                    End If
                    If mRepairStatus = 5 Then
                        vService = "NTF"
                    End If

                Catch ex As Exception
                    MsgBox("vService has failed on device_id = " & r("csin_ESN"), MsgBoxStyle.Critical, "ERROR")
                End Try

                strData += vService & vbTab

                strData += r("csin_ItemNum").ToString & vbTab
                strData += strPartQty


                s.WriteLine(strData)
                System.Windows.Forms.Application.DoEvents()

                strData = ""

            Next

            s.Close()

            MsgBox("File has been created.")

        End Sub

        Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
            Dim cCS As New PSS.Data.Buisness.CellStar()
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            cCS.createCloseReportReplace()

            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("Complete")

        End Sub


        Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

            Dim dteStart, _
            dteEnd, _
            strSQL, _
            strError As String

            Dim ds As PSS.Data.production.Joins
            Dim dt, _
            dtRUR, _
            dtWD, _
            dtNTF As DataTable
            Dim r As DataRow

            Dim xCount As Integer
            Dim countHigh As Integer = 0
            Dim countLow As Integer = 0

            Dim dblLC As Double

            Dim blnRUR, _
            blnWD, _
            blnNTF As Boolean

            Dim blnUpdate As Boolean


            '//Get a list of devices for Brightpoint for the date period
            If Len(Trim(cboStart.Text)) < 1 Or Len(Trim(cboEnd.Text)) < 1 Then
                MsgBox("Please provide a date range.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            dteStart = FormatDate(cboStart.Text)
            dteEnd = FormatDate(cboEnd.Text)

            '//HIGH VOLUME MODELS
            strSQL = "select tmodel.model_desc, tdevice.device_id, tdevice.device_Laborlevel, tdevice.device_Laborcharge, prodgrp_ldesc, tlaborprc.laborprc_regprc from " & _
            "tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
            "inner join lprodgrp on tmodel.model_tier = lprodgrp.prodgrp_id " & _
            "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tcusttoprice on tlocation.cust_id = tcusttoprice.cust_id " & _
            "inner join tlaborprc on (lprodgrp.prodgrp_id = tlaborprc.prodgrp_id and tdevice.device_laborlevel = tlaborprc.laborlvl_id and tcusttoprice.prcgroup_id = tlaborprc.prcgroup_id) " & _
            "where tdevice.loc_id = 2636 and Device_dateship >= '" & dteStart & "' AND Device_DateShip <= '" & dteEnd & "' " & _
            "and model_volume = 0 " & _
            "order by device_Laborlevel, device_laborcharge"

            dt = ds.OrderEntrySelect(strSQL)




            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                blnRUR = False
                blnWD = False
                blnNTF = False

                dblLC = r("Device_LaborCharge")
                If dblLC = 3.0 Then
                    '//Check for RUR
                    dtRUR = ds.OrderEntrySelect("SELECT tdevicebill.* FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevicebill.device_id = " & r("Device_ID") & " AND lbillcodes.billcode_rule in (1,2)")
                    If dtRUR.Rows.Count > 0 Then
                        '//Device IS RUR
                        blnRUR = True
                    Else
                        '//Device IS NOT RUR
                    End If
                ElseIf dblLC = 4.5 Then
                    '//Check for WIPEDOWN
                    dtWD = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id = 1010")
                    If dtWD.Rows.Count > 0 Then
                        '//Device IS WIPEDOWN
                        blnWD = True
                    Else
                        '//Device IS NOT WIPEDOWN
                    End If
                Else
                    '//check for NTF value
                    dtNTF = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id in (533,541)")
                    If dtNTF.Rows.Count > 0 Then
                        '//Device IS NTF
                        blnNTF = True
                    Else
                        '//Device IS NOT NTF
                    End If
                End If

                If blnWD = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 6 WHERE Device_ID = " & r("Device_ID"))
                    End If
                ElseIf blnNTF = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 5 WHERE Device_ID = " & r("Device_ID"))
                    End If
                End If

                '//This section is only if the device is not RUR or WIPEDOWN
                If blnRUR = False And blnWD = False Then
                    If r("Device_LaborCharge") <> r("Laborprc_regprc") Then
                        '//Write Error Message
                        strError = "DEVICE ID: " & r("Device_ID") & " FOR LABOR LEVEL " & r("Device_LaborLevel") & " IS INVALID. THE LABOR CHARGE SHOULD BE " & r("laborprc_regprc") & " NOT " & r("Device_Laborcharge")
                        'MsgBox(strError)
                        'If r("Device_ID") > 0 Then
                        'blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborcharge = " & r("laborprc_regprc") & " WHERE Device_ID = " & r("Device_ID"))
                        'End If
                        countHigh += 1
                        strError = ""
                    End If
                End If

            Next

            MsgBox(countHigh & " OUT OF " & dt.Rows.Count - 1)


            '//LOW VOLUME MODELS
            strSQL = "select tmodel.model_desc, tdevice.device_id, tdevice.device_Laborlevel, tdevice.device_Laborcharge, tdevice.device_datebill, tmodel.model_volume, prodgrp_ldesc, sc_amount from " & _
            "tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
            "inner join lprodgrp on tmodel.model_tier = lprodgrp.prodgrp_id " & _
            "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tsubcontractlaborcharge on (tlocation.cust_id = tsubcontractlaborcharge.sc_cust_id and lprodgrp.prodgrp_id = tsubcontractlaborcharge.sc_prodgrp_id and tdevice.device_laborlevel = tsubcontractlaborcharge.sc_laborlevel) " & _
            "where tdevice.loc_id = 2636 and Device_dateship >= '" & dteStart & "' AND Device_DateShip <= '" & dteEnd & "' " & _
            "and model_volume = 1 " & _
            "order by model_desc, device_Laborlevel, device_laborcharge"

            dt = ds.OrderEntrySelect(strSQL)


            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                blnRUR = False
                blnWD = False
                blnNTF = False

                dblLC = r("Device_LaborCharge")
                If dblLC = 3.0 Then
                    '//Check for RUR
                    dtRUR = ds.OrderEntrySelect("SELECT tdevicebill.* FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevicebill.device_id = " & r("Device_ID") & " AND lbillcodes.billcode_rule in (1,2)")
                    If dtRUR.Rows.Count > 0 Then
                        '//Device IS RUR
                        blnRUR = True
                    Else
                        '//Device IS NOT RUR
                    End If
                ElseIf dblLC = 5.0 Then
                    '//Check for RUR
                    dtRUR = ds.OrderEntrySelect("SELECT tdevicebill.* FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevicebill.device_id = " & r("Device_ID") & " AND lbillcodes.billcode_rule in (1,2)")
                    If dtRUR.Rows.Count > 0 Then
                        '//Device IS RUR
                        blnRUR = True
                    Else
                        '//Device IS NOT RUR
                    End If
                ElseIf dblLC = 4.5 Then
                    '//Check for WIPEDOWN
                    dtWD = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id = 1010")
                    If dtWD.Rows.Count > 0 Then
                        '//Device IS WIPEDOWN
                        blnWD = True
                    Else
                        '//Device IS NOT WIPEDOWN
                    End If
                Else
                    '//check for NTF value
                    dtNTF = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id in (533,541)")
                    If dtNTF.Rows.Count > 0 Then
                        '//Device IS NTF
                        blnNTF = True
                    Else
                        '//Device IS NOT NTF
                    End If
                End If


                If blnWD = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 6 WHERE Device_ID = " & r("Device_ID"))
                    End If
                ElseIf blnNTF = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 5 WHERE Device_ID = " & r("Device_ID"))
                    End If
                End If

                '//This section is only if the device is not RUR or WIPEDOWN
                If blnRUR = False And blnWD = False Then
                    If r("Device_LaborCharge") <> r("sc_amount") Then
                        '//Write Error Message
                        strError = "DEVICE ID: " & r("Device_ID") & " FOR LABOR LEVEL " & r("Device_LaborLevel") & " IS INVALID. THE LABOR CHARGE SHOULD BE " & r("sc_amount") & " NOT " & r("Device_Laborcharge")
                        'MsgBox(strError)
                        'If r("Device_ID") > 0 Then
                        'blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborcharge = " & r("sc_amount") & " WHERE Device_ID = " & r("Device_ID"))
                        'End If
                        countLow += 1
                        strError = ""
                    End If
                End If

            Next

            MsgBox(countLow & " OUT OF " & dt.Rows.Count - 1)

        End Sub

        Private Sub cmdLoadRecData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadRecData.Click

            Dim iParentGroupID As Integer = PSS.Core.Global.ApplicationUser.GroupID
            Dim objCS As New PSS.Data.Buisness.CellStar()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim iResult As Integer = 0
            Dim dt1 As DataTable
            Dim strFile As String
            Dim strDir As String = "\\SVR_PSSNET\CellstarFTP\Incoming\"
            Dim strFileLoc As String = ""
            Dim strRejectRptDir As String = "P:\Dept\Cellstar\XLM Load Reject Report\"
            Dim strRejectRptFileName As String = "CS Could not Load File " & Format(Now, "yyyy-MM-dd hhmmss") & ".xls"
            Dim strNewPartNumbers As String = ""

            Try
                Me.Enabled = False
                '*****************************************
                'get 1st XML file name in given directory
                '*****************************************
                strFile = Dir(strDir & "*.xml")

                MsgBox(strFile)

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '*****************************************
                'create datatable for reject report
                '*****************************************
                dt1 = objCS.CreateCSAdvanceRecXML_RejectRptDt()

                '*******************************
                'loop through given directory
                '*******************************
                Do Until strFile = Nothing
                    strFileLoc = strDir & strFile

                    If New FileInfo(strFileLoc).Length <> 0 Then
                        '*********************************
                        'load data in XML file into system
                        '*********************************
                        iResult += objCS.loadAdvanceShipNotice("\\SVR_PSSNET\CellstarFTP\Incoming\" & strFile, iParentGroupID, strNewPartNumbers, dt1)

                        '*********************************
                        'move XML file to archive folder
                        '*********************************
                        System.IO.File.Move(strFileLoc, strDir & "Archive\" & strFile)
                    Else
                        '****************************************************
                        'move XML file to BadFile folder if file size is zero
                        '****************************************************
                        System.IO.File.Move(strFileLoc, strDir & "BadFiles\" & strFile)

                    End If
                    strFile = Dir()
                Loop

                If iResult > 0 Then
                    MessageBox.Show(iResult & " device(s) have been loaded.", "Load XML File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("No device is loaded.", "Load XML File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                System.Windows.Forms.Application.DoEvents()

                '*******************************************
                'print new part number to user
                '*******************************************
                If strNewPartNumbers <> "" Then
                    objCS.PrintCS_NewPartNumber_Rpt(strNewPartNumbers)
                    'MessageBox.Show("The following is new part number: " & Environment.NewLine & strNewPartNumbers, "New Part Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                System.Windows.Forms.Application.DoEvents()

                '*******************************************
                'Create report if required field are missing
                '*******************************************
                If dt1.Rows.Count > 0 Then
                    objGen.CreateExelReport(dt1, 1, strRejectRptDir & strRejectRptFileName)
                    Me.MinimizeBox = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Load Brightpoint Receive XML File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objCS = Nothing
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                Me.Enabled = True
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub




        Private Sub btnProcess2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess2.Click
            Dim dteStart, _
            dteEnd, _
            strSQL, _
            strError As String

            Dim ds As PSS.Data.production.Joins
            Dim dt, _
            dtRUR, _
            dtWD, _
            dtNTF As DataTable
            Dim r As DataRow

            Dim xCount As Integer
            Dim countHigh As Integer = 0
            Dim countLow As Integer = 0

            Dim dblLC As Double

            Dim blnRUR, _
            blnWD, _
            blnNTF As Boolean

            Dim blnUpdate As Boolean


            '//Get a list of devices for Brightpoint for the date period
            If Len(Trim(cboStart.Text)) < 1 Or Len(Trim(cboEnd.Text)) < 1 Then
                MsgBox("Please provide a date range.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            dteStart = FormatDate(cboStart.Text)
            dteEnd = FormatDate(cboEnd.Text)

            '//HIGH VOLUME MODELS
            strSQL = "select tmodel.model_desc, tdevice.device_id, tdevice.device_Laborlevel, tdevice.device_Laborcharge, prodgrp_ldesc, tlaborprc.laborprc_regprc from " & _
            "tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
            "inner join lprodgrp on tmodel.model_tier = lprodgrp.prodgrp_id " & _
            "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tcusttoprice on tlocation.cust_id = tcusttoprice.cust_id " & _
            "inner join tlaborprc on (lprodgrp.prodgrp_id = tlaborprc.prodgrp_id and tdevice.device_laborlevel = tlaborprc.laborlvl_id and tcusttoprice.prcgroup_id = tlaborprc.prcgroup_id) " & _
            "where tdevice.loc_id = 2636 and Device_dateship >= '" & dteStart & "' AND Device_DateShip <= '" & dteEnd & "' " & _
            "and model_volume = 0 " & _
            "order by device_Laborlevel, device_laborcharge"

            dt = ds.OrderEntrySelect(strSQL)




            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                blnRUR = False
                blnWD = False
                blnNTF = False

                dblLC = r("Device_LaborCharge")
                If dblLC = 3.0 Then
                    '//Check for RUR
                    dtRUR = ds.OrderEntrySelect("SELECT tdevicebill.* FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevicebill.device_id = " & r("Device_ID") & " AND lbillcodes.billcode_rule in (1,2)")
                    If dtRUR.Rows.Count > 0 Then
                        '//Device IS RUR
                        blnRUR = True
                    Else
                        '//Device IS NOT RUR
                    End If
                ElseIf dblLC = 4.5 Then
                    '//Check for WIPEDOWN
                    dtWD = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id = 1010")
                    If dtWD.Rows.Count > 0 Then
                        '//Device IS WIPEDOWN
                        blnWD = True
                    Else
                        '//Device IS NOT WIPEDOWN
                    End If
                Else
                    '//check for NTF value
                    dtNTF = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id in (533,541)")
                    If dtNTF.Rows.Count > 0 Then
                        '//Device IS NTF
                        blnNTF = True
                    Else
                        '//Device IS NOT NTF
                    End If
                End If

                If blnWD = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 6 WHERE Device_ID = " & r("Device_ID"))
                    End If
                ElseIf blnNTF = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 5 WHERE Device_ID = " & r("Device_ID"))
                    End If
                End If

                '//This section is only if the device is not RUR or WIPEDOWN
                If blnRUR = False And blnWD = False Then
                    If r("Device_LaborCharge") <> r("Laborprc_regprc") Then
                        '//Write Error Message
                        strError = "DEVICE ID: " & r("Device_ID") & " FOR LABOR LEVEL " & r("Device_LaborLevel") & " IS INVALID. THE LABOR CHARGE SHOULD BE " & r("laborprc_regprc") & " NOT " & r("Device_Laborcharge")
                        'MsgBox(strError)
                        If r("Device_ID") > 0 Then
                            blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborcharge = " & r("laborprc_regprc") & " WHERE Device_ID = " & r("Device_ID"))
                        End If
                        countHigh += 1
                        strError = ""
                    End If
                End If

            Next

            'MsgBox(countHigh & " OUT OF " & dt.Rows.Count - 1)


            '//LOW VOLUME MODELS
            strSQL = "select tmodel.model_desc, tdevice.device_id, tdevice.device_Laborlevel, tdevice.device_Laborcharge, tdevice.device_datebill, tmodel.model_volume, prodgrp_ldesc, sc_amount from " & _
            "tdevice inner join tmodel on tdevice.model_id = tmodel.model_id " & _
            "inner join lprodgrp on tmodel.model_tier = lprodgrp.prodgrp_id " & _
            "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tsubcontractlaborcharge on (tlocation.cust_id = tsubcontractlaborcharge.sc_cust_id and lprodgrp.prodgrp_id = tsubcontractlaborcharge.sc_prodgrp_id and tdevice.device_laborlevel = tsubcontractlaborcharge.sc_laborlevel) " & _
            "where tdevice.loc_id = 2636 and Device_dateship >= '" & dteStart & "' AND Device_DateShip <= '" & dteEnd & "' " & _
            "and model_volume = 1 " & _
            "order by model_desc, device_Laborlevel, device_laborcharge"

            dt = ds.OrderEntrySelect(strSQL)


            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                blnRUR = False
                blnWD = False
                blnNTF = False

                dblLC = r("Device_LaborCharge")
                If dblLC = 3.0 Then
                    '//Check for RUR
                    dtRUR = ds.OrderEntrySelect("SELECT tdevicebill.* FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevicebill.device_id = " & r("Device_ID") & " AND lbillcodes.billcode_rule in (1,2)")
                    If dtRUR.Rows.Count > 0 Then
                        '//Device IS RUR
                        blnRUR = True
                    Else
                        '//Device IS NOT RUR
                    End If
                ElseIf dblLC = 5.0 Then
                    '//Check for RUR
                    dtRUR = ds.OrderEntrySelect("SELECT tdevicebill.* FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevicebill.device_id = " & r("Device_ID") & " AND lbillcodes.billcode_rule in (1,2)")
                    If dtRUR.Rows.Count > 0 Then
                        '//Device IS RUR
                        blnRUR = True
                    Else
                        '//Device IS NOT RUR
                    End If
                ElseIf dblLC = 4.5 Then
                    '//Check for WIPEDOWN
                    dtWD = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id = 1010")
                    If dtWD.Rows.Count > 0 Then
                        '//Device IS WIPEDOWN
                        blnWD = True
                    Else
                        '//Device IS NOT WIPEDOWN
                    End If
                Else
                    '//check for NTF value
                    dtNTF = ds.OrderEntrySelect("SELECT * FROM tdevicebill WHERE tdevicebill.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id in (533,541)")
                    If dtNTF.Rows.Count > 0 Then
                        '//Device IS NTF
                        blnNTF = True
                    Else
                        '//Device IS NOT NTF
                    End If
                End If


                If blnWD = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 6 WHERE Device_ID = " & r("Device_ID"))
                    End If
                ElseIf blnNTF = True Then
                    If r("Device_ID") > 0 Then
                        blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborlevel = 5 WHERE Device_ID = " & r("Device_ID"))
                    End If
                End If

                '//This section is only if the device is not RUR or WIPEDOWN
                If blnRUR = False And blnWD = False Then
                    If r("Device_LaborCharge") <> r("sc_amount") Then
                        '//Write Error Message
                        strError = "DEVICE ID: " & r("Device_ID") & " FOR LABOR LEVEL " & r("Device_LaborLevel") & " IS INVALID. THE LABOR CHARGE SHOULD BE " & r("sc_amount") & " NOT " & r("Device_Laborcharge")
                        'MsgBox(strError)
                        If r("Device_ID") > 0 Then
                            blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Device_Laborcharge = " & r("sc_amount") & " WHERE Device_ID = " & r("Device_ID"))
                        End If
                        countLow += 1
                        strError = ""
                    End If
                End If

            Next

            'MsgBox(countLow & " OUT OF " & dt.Rows.Count - 1)
            MsgBox("Complete")

        End Sub

        Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

            '//This method creates a text file from the invoice excel document
            '//Prepared by Crystal Cozart
            '//CONSTANTS *************************************************
            Dim strCustomer As String = "Brightpoint, Ltd."
            Dim strAddress1 As String = "601 S. Royal Lane"
            Dim strAddress2 As String = ""
            Dim strCity As String = "Coppell"
            Dim strState As String = "TX"
            Dim strZip As String = "75019"
            Dim strPhone As String = ""
            Dim strServiceCenter As String = "0001"
            Dim strRepairLevel As String = "R"
            Dim strComplaint As String = "NO COMPLAINT GIVEN"
            Dim strICRT As String = ""
            Dim strPartQty As String = "1"
            '//CONSTANTS *************************************************

            Dim ds As PSS.Data.production.Joins
            Dim OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Dim vsWriter As StreamWriter
            Dim strData As String = ""
            Dim strHeader As String = ""
            Dim strPartNumber, mFileName, vService, mRepairStatus, mSerial, strSQL As String
            Dim dt1 As New DataTable()
            Dim dtDateRec, dt, dtService, dtCSIN, dtOld As DataTable
            Dim r, rDateRec, rService, rOld, rCSIN As DataRow
            Dim vParts, vLabor As Double
            Dim mHN As Integer = 0
            Dim xService As Integer = 0
            Dim x As Integer
            Dim strFile As String = "cell240383_" & mHN.ToString.PadLeft(4, "0") & "_PSSINEW.txt"
            Dim fs As New FileStream("D:\\cellstarINVOICE\Current\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            '//Get the filename to load from
            OpenFileDialog1.ShowDialog()
            If Len(Trim(OpenFileDialog1.filename)) < 1 Then
                MsgBox("Data can not be loaded. No file has been selected.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & OpenFileDialog1.filename & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()

            objConn.ConnectionString = sConnectionstring
            objConn.Open()
            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect
            objAdapter1.Fill(dt1)

            strHeader = "EnterpriseCode" & vbTab & _
                        "Service Invoice" & vbTab & _
                        "ESN" & vbTab & _
                        "Model" & vbTab & _
                        "Customer" & vbTab & _
                        "Address One" & vbTab & _
                        "Address Two" & vbTab & _
                        "City" & vbTab & _
                        "State" & vbTab & _
                        "Zip" & vbTab & _
                        "Phone" & vbTab & _
                        "Service Center" & vbTab & _
                        "Date In" & vbTab & _
                        "Date Out" & vbTab & _
                        "Repair Level" & vbTab & _
                        "Complaint" & vbTab & _
                        "Labor Cost" & vbTab & _
                        "Parts Cost" & vbTab & _
                        "ICRT" & vbTab & _
                        "Service" & vbTab & _
                        "Part #" & vbTab & _
                        "Qty"

            s.WriteLine(strHeader)
            System.Windows.Forms.Application.DoEvents()

            For x = 0 To dt1.Rows.Count - 2
                r = dt1.Rows(x)
                Try
                    If IsDBNull(r("Serial No")) = True Then
                        s.Close()
                        MsgBox("File has been created")
                        Exit Sub
                    End If

                    dtOld = ds.OrderEntrySelect("SELECT tdevice.device_oldSN FROM tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id WHERE tworkorder.wo_custwo = '" & r("Workorder No") & "' AND tdevice.device_sn = '" & r("Serial No") & "'")
                    rOld = dtOld.Rows(0)
                    If Len(Trim(rOld("Device_OldSN"))) > 1 Then
                        strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & rOld("Device_OldSN") & "'"
                        mSerial = rOld("Device_OldSN")
                    ElseIf r("Serial No") > 0 Then
                        strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & r("Serial No") & "'"
                        mSerial = r("Serial No")
                    End If
                Catch ex As Exception
                    strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & r("Serial No") & "'"
                    mSerial = r("Serial No")
                End Try

                dtCSIN = ds.OrderEntrySelect(strSQL)

                rCSIN = dtCSIN.Rows(0)

                strData += rCSIN("csin_EnterpriseCode").ToString & vbTab
                strData += r("Workorder No").ToString & vbTab
                strData += mSerial & vbTab
                strData += rCSIN("csin_Model").ToString & vbTab
                strData += strCustomer & vbTab
                strData += strAddress1 & vbTab
                strData += strAddress2 & vbTab
                strData += strCity & vbTab
                strData += strState & vbTab
                strData += strZip & vbTab
                strData += strPhone & vbTab
                strData += strServiceCenter & vbTab

                strSQL = "SELECT Device_DateRec FROM tdevice INNER JOIN tworkorder on tdevice.wo_id = tworkorder.wo_id WHERE tdevice.device_sn = '" & r("Serial No") & "' AND tworkorder.wo_custwo = '" & r("Workorder No") & "'"
                dtDateRec = ds.OrderEntrySelect(strSQL)
                rDateRec = dtDateRec.Rows(0)

                strData += Format(rDateRec("Device_DateRec"), "MMddyyyy") & vbTab
                strData += Format(r("Shipping Date"), "MMddyyyy") & vbTab

                mRepairStatus = r("Labor Level")

                strData += mRepairStatus & vbTab
                strData += strComplaint & vbTab

                vLabor = FormatNumber(r("Labor Charge"), 2)
                Dim sl As String = String.Format("{0:n2}", vLabor)
                strData += sl & vbTab

                vParts = FormatNumber(r("Parts Charge"), 2)
                Dim sp As String = String.Format("{0:n2}", vParts)
                strData += sp & vbTab

                strData += strICRT & vbTab
                Try
                    If r("Old Serial No") > 0 Then
                        strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                        "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                        "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                        "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                        "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                        "where cstincomingdata.csin_esn = '" & r("Old Serial No") & "' " & _
                        "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
                        "and cstincomingdata.csin_RepairOrderNum = '" & r("Workorder No") & "' " & _
                        "order by laborlvl_id desc"
                    Else
                        strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                        "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                        "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                        "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                        "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                        "where cstincomingdata.csin_esn = '" & r("Serial No") & "' " & _
                        "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
                        "and cstincomingdata.csin_RepairOrderNum = '" & r("Workorder No") & "' " & _
                        "order by laborlvl_id desc"
                    End If
                Catch ex As Exception
                    strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                    "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                    "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                    "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                    "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                    "where cstincomingdata.csin_esn = '" & r("Serial No") & "' " & _
                    "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
                    "and cstincomingdata.csin_RepairOrderNum = '" & r("Workorder No") & "' " & _
                    "order by laborlvl_id desc"
                End Try

                dtService = ds.OrderEntrySelect(strSQL)
                System.Windows.Forms.Application.DoEvents()
                Try
                    vService = ""
                    For xService = 0 To dtService.Rows.Count - 1
                        rService = dtService.Rows(xService)
                        If xService = dtService.Rows.Count - 1 Then
                            vService += rService("mService")
                        Else
                            vService += rService("mService") & " ;  "
                        End If
                    Next

                    If mRepairStatus = 6 Then
                        vService = "WIPEDOWN"
                    End If
                    If mRepairStatus = 0 Then
                        vService = "BER"
                    End If
                    If mRepairStatus = 5 Then
                        vService = "NTF"
                    End If

                    If Len(Trim(vService)) > 199 Then
                        vService = Mid(vService, 1, 198)
                    End If


                Catch ex As Exception
                    MsgBox("vService has failed on device_id = " & r("csin_ESN"), MsgBoxStyle.Critical, "ERROR")
                End Try

                strData += vService & vbTab
                strData += rCSIN("csin_ItemNum").ToString & vbTab
                strData += strPartQty

                s.WriteLine(strData)
                System.Windows.Forms.Application.DoEvents()
                strData = ""
            Next

            s.Close()

            objConn = Nothing
            MsgBox("File has been created.")

        End Sub
#End Region


        '************************************************************************
        Private Sub frmAdminCellstar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                Me.dtpStartDt.Value = Now()
                Me.dtpEndDt.Value = Now()

                If ApplicationUser.GetPermission("563Bill_PrebillDevsInWIP") > 0 Then
                    Me.btnAutoBillPrebillDevs.Visible = True
                Else
                    Me.btnAutoBillPrebillDevs.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '************************************************************************
        Private Sub cmdAutoBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoBill.Click
            Dim i As Integer = 0
            Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iLoc_ID As Integer = 2636
            Dim iDevTotal As Integer
            Dim strFP As String = "P:\Dept\Cellstar\Log\AB\Random Billgroups.txt"

            Try
                DateValidation()

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                Me.Enabled = False

                objAutoBill.WorkDate = PSS.Core.Global.ApplicationUser.Workdate

                '**************************************************
                FileOpen(1, strFP, OpenMode.Append)   'Open TXT file
                PrintLine(1, "-------------------------------------")
                PrintLine(1, objAutoBill.WorkDate)
                PrintLine(1, "-------------------------------------")
                Reset()
                '***************************************************
                'Check if all billcodes in bill groups existed in tpsmap
                '  or if it is inactive then turn it to inactive
                '//*************************************************
                Me.lblStatus.Text = "VALIDATE BILL-GROUP"
                objAutoBill.UpdateStatusOfBillcodeInBillGrp()

                ''//Move this section to frmAdminCellstar
                '***************************************************
                '//Step 1: Get all Brightpoint Shipped Devices today.
                '//*************************************************
                dt1 = objAutoBill.GetDevicesShippedByLocationByWorkDt(iLoc_ID, _
                                                                      Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
                                                                      Format(Me.dtpEndDt.Value, "yyyy-MM-dd"))

                iDevTotal = dt1.Rows.Count
                '***************************************************
                '//Step 2: Loop through all devices and check if each has atleast one entry in 
                '//in the new billing table tdevicebill_563
                '//*************************************************
                'device loop
                For Each R1 In dt1.Rows
                    i += objAutoBill.BrightpointSpecialBilling(R1)

                    Me.lblStatus.Text = iDevTotal.ToString
                    Me.Refresh()
                    Application.DoEvents()
                    iDevTotal -= 1
                Next R1

                MessageBox.Show("Auto-Bill completed.", "Auto-Bill", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Auto Bill", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objAutoBill = Nothing
                Me.Enabled = True
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '************************************************************************
        Private Sub DateValidation()
            If Me.dtpStartDt.Text = "" Or Me.dtpEndDt.Text = "" Then
                Throw New Exception("Please select 'From Work Date' and 'To Work Date'.")
            End If

            If Me.dtpEndDt.Value < Me.dtpStartDt.Value Then
                Throw New Exception("'To Work Date' can't be before 'From Work Date'.")
            End If
        End Sub

        '***********************************************************************
        Private Sub btnAutoBillPrebillDevs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoBillPrebillDevs.Click
            Dim i As Integer = 0
            Dim objAutoBill As New PSS.Data.Buisness.AutoBill_Prebill_InWIP()
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iLoc_ID As Integer = 2636
            Dim iDevTotal As Integer
            Dim strFP As String = "P:\Dept\Cellstar\Log\AB\PB Random Billgroups.txt"

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                Me.Enabled = False

                objAutoBill.WorkDate = PSS.Core.Global.ApplicationUser.Workdate

                '**************************************************
                FileOpen(1, strFP, OpenMode.Append)   'Open TXT file
                PrintLine(1, "-------------------------------------")
                PrintLine(1, objAutoBill.WorkDate)
                PrintLine(1, "-------------------------------------")
                Reset()
                '***************************************************
                'Check if all billcodes in bill groups existed in tpsmap
                '  or if it is inactive then turn it to inactive
                '//*************************************************
                Me.lblStatus.Text = "VALIDATE BILL-GROUP"
                '''''objAutoBill.UpdateStatusOfBillcodeInBillGrp()

                ''//Move this section to frmAdminCellstar
                '***************************************************
                '//Step 1: Get all Brightpoint Shipped Devices today.
                '//*************************************************
                dt1 = objAutoBill.GetPreBillDevices_Lvl2And3(iLoc_ID)

                iDevTotal = dt1.Rows.Count
                '***************************************************
                '//Step 2: Loop through all devices and check if each has atleast one entry in 
                '//in the new billing table tdevicebill_563
                '//*************************************************
                'device loop
                For Each R1 In dt1.Rows
                    i += objAutoBill.BrightpointSpecialBilling(R1)

                    Me.lblStatus.Text = iDevTotal.ToString
                    Me.Refresh()
                    Application.DoEvents()
                    iDevTotal -= 1
                Next R1

                MessageBox.Show("Auto-Bill completed.", "Auto-Bill", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Auto Bill", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objAutoBill = Nothing
                Me.Enabled = True
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '************************************************************************
        Private Sub btnCloseReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseReport.Click
            Dim objCellStar As New PSS.Data.Buisness.CellStar()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim iCust_ID = 2113 'Brightpoint

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                DateValidation()

                '''*******************************************
                '''Check billcode mapping
                '''*******************************************
                ''dt1 = objCellStar.GetUnMapBillcodesInfo(iCust_ID, _
                ''                                       Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
                ''                                       Format(Me.dtpEndDt.Value, "yyyy-MM-dd"))

                ''If dt1.Rows.Count > 0 Then
                ''    MessageBox.Show("There is billcodes without mapping. Please complete all mapping in excel report and re-run the 'Close Report'.", "Validate Mapping of Billcode", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ''    objGen.CreateExelReport(dt1, , , )
                ''    Me.MinimizeBox = True
                ''    Exit Sub
                ''End If

                '*******************************************
                'Create Close Report
                '*******************************************
                i = objCellStar.createCloseReport(Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
                                                     Format(Me.dtpEndDt.Value, "yyyy-MM-dd"), _
                                                     "")
                '''If i > 0 Then
                '''    MsgBox("Upload Completed.")
                '''End If
                '*******************************************
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Create Close Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objCellStar = Nothing
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '************************************************************************
        Private Sub cmdCheckMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckMap.Click
            Dim objCellStar As New PSS.Data.Buisness.CellStar()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim dt1 As DataTable
            Dim iCust_ID As Integer = 2113
            Dim i As Integer = 0

            Try
                DateValidation()

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                dt1 = objCellStar.GetUnMapBillcodesInfo(iCust_ID, _
                                                       Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
                                                       Format(Me.dtpEndDt.Value, "yyyy-MM-dd"))

                If dt1.Rows.Count > 0 Then
                    objGen.CreateExelReport(dt1, , , )
                    Me.MinimizeBox = True
                Else
                    MessageBox.Show("No un-map billcode.", "Check Billcode Map", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Get Un-Map Billcodes Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objCellStar = Nothing
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub


        '***********************************************************************
        Private Sub btnAutoBillATCLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoBillATCLE.Click
            Dim i As Integer = 0
            Dim iCust_ID As Integer = 2019
            Dim objATCLESpecialBilling As New PSS.Data.Buisness.ATCLESpecialBilling()

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                DateValidation()
                objATCLESpecialBilling.WorkDate = PSS.Core.Global.ApplicationUser.Workdate
                objATCLESpecialBilling.UserID = PSS.Core.Global.ApplicationUser.IDuser
                i = objATCLESpecialBilling.SpecialBilling(Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
                                                          Format(Me.dtpEndDt.Value, "yyyy-MM-dd"), _
                                                          iCust_ID)

                MessageBox.Show("Auto-Bill completed.", "Auto-Bill", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Auto Bill", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objATCLESpecialBilling = Nothing
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '***********************************************************************
    End Class
End Namespace




