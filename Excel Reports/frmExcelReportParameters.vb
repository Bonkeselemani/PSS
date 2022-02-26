Public Class frmExcelReportParameters
    Inherits System.Windows.Forms.Form

    Dim _bUseParams As Boolean() = {False}
    Private _strReportTitle As String
    Private _xlRC As Data.ExcelReports.Excel_Report_Call

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strReportTitle As String, ByVal xlrc As Data.ExcelReports.Excel_Report_Call)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strReportTitle = strReportTitle
        Me._xlRC = xlrc

        Select Case xlrc
            Case Data.ExcelReports.Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES
                Me._bUseParams(0) = True
        End Select

        If Me._bUseParams(0) Then
            Me.grpDateRange.Enabled = True
        Else
            Me.grpDateRange.Enabled = False
        End If

        Me.btnRunReport.Enabled = True
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
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpDateRange As System.Windows.Forms.GroupBox
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpDateRange = New System.Windows.Forms.GroupBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.grpDateRange.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDateRange
        '
        Me.grpDateRange.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpEndDate, Me.dtpStartDate, Me.lblEndDate, Me.lblStartDate})
        Me.grpDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDateRange.Location = New System.Drawing.Point(16, 24)
        Me.grpDateRange.Name = "grpDateRange"
        Me.grpDateRange.Size = New System.Drawing.Size(320, 96)
        Me.grpDateRange.TabIndex = 0
        Me.grpDateRange.TabStop = False
        Me.grpDateRange.Text = "Date Range"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(88, 64)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(88, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'lblEndDate
        '
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.Location = New System.Drawing.Point(16, 64)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEndDate.TabIndex = 1
        Me.lblEndDate.Text = "End Date:"
        '
        'lblStartDate
        '
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.Location = New System.Drawing.Point(16, 24)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(64, 16)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date:"
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(184, 192)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(128, 40)
        Me.btnRunReport.TabIndex = 1
        Me.btnRunReport.Text = "Run Report"
        '
        'frmExcelReportParameters
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(496, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRunReport, Me.grpDateRange})
        Me.Name = "frmExcelReportParameters"
        Me.Text = "Excel Report Parameters"
        Me.grpDateRange.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmExcelReportParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpStartDate.Value = Now
        Me.dtpEndDate.Value = Now
    End Sub

    Private Sub btnRunReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click
        Dim objXLReports As Data.ExcelReports

        Try
            objXLReports = New Data.ExcelReports(True)

            Select Case Me._xlRC
                Case Data.ExcelReports.Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES
                    objXLReports.StartDate = Me.dtpStartDate.Value
                    objXLReports.EndDate = Me.dtpEndDate.Value

                    objXLReports.RunReport(Data.ExcelReports.Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Running Excel Report")
        End Try
    End Sub
End Class
