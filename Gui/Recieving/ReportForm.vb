
Namespace Gui.Receiving

    Public Class ReportForm
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
        Friend WithEvents btnDailyCount As System.Windows.Forms.Button
        Friend WithEvents grpDateRange As System.Windows.Forms.GroupBox
        Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
        Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
        Friend WithEvents lblEnd As System.Windows.Forms.Label
        Friend WithEvents lblStart As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnDailyCount = New System.Windows.Forms.Button()
            Me.grpDateRange = New System.Windows.Forms.GroupBox()
            Me.txtEndDate = New System.Windows.Forms.TextBox()
            Me.txtStartDate = New System.Windows.Forms.TextBox()
            Me.lblEnd = New System.Windows.Forms.Label()
            Me.lblStart = New System.Windows.Forms.Label()
            Me.grpDateRange.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnDailyCount
            '
            Me.btnDailyCount.Location = New System.Drawing.Point(8, 16)
            Me.btnDailyCount.Name = "btnDailyCount"
            Me.btnDailyCount.Size = New System.Drawing.Size(152, 23)
            Me.btnDailyCount.TabIndex = 0
            Me.btnDailyCount.Text = "Daily &Count"
            '
            'grpDateRange
            '
            Me.grpDateRange.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEndDate, Me.txtStartDate, Me.lblEnd, Me.lblStart})
            Me.grpDateRange.Location = New System.Drawing.Point(192, 8)
            Me.grpDateRange.Name = "grpDateRange"
            Me.grpDateRange.Size = New System.Drawing.Size(192, 88)
            Me.grpDateRange.TabIndex = 5
            Me.grpDateRange.TabStop = False
            Me.grpDateRange.Text = "DateRange"
            '
            'txtEndDate
            '
            Me.txtEndDate.Location = New System.Drawing.Point(64, 48)
            Me.txtEndDate.Name = "txtEndDate"
            Me.txtEndDate.TabIndex = 8
            Me.txtEndDate.Text = ""
            '
            'txtStartDate
            '
            Me.txtStartDate.Location = New System.Drawing.Point(64, 24)
            Me.txtStartDate.Name = "txtStartDate"
            Me.txtStartDate.TabIndex = 7
            Me.txtStartDate.Text = ""
            '
            'lblEnd
            '
            Me.lblEnd.Location = New System.Drawing.Point(32, 48)
            Me.lblEnd.Name = "lblEnd"
            Me.lblEnd.Size = New System.Drawing.Size(32, 16)
            Me.lblEnd.TabIndex = 6
            Me.lblEnd.Text = "End:"
            '
            'lblStart
            '
            Me.lblStart.Location = New System.Drawing.Point(32, 24)
            Me.lblStart.Name = "lblStart"
            Me.lblStart.Size = New System.Drawing.Size(32, 16)
            Me.lblStart.TabIndex = 5
            Me.lblStart.Text = "Start:"
            '
            'ReportForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(392, 229)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDateRange, Me.btnDailyCount})
            Me.Name = "ReportForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "General Reports"
            Me.grpDateRange.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnDailyCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyCount.Click

            'If grpDateRange.Visible = False Then
            'grpDateRange.Visible = True
            'txtStartDate.Focus()
            'Exit Sub
            'End If

            Dim intStartMonth, intStartDay, intStartYear As Integer
            Dim intEndMonth, intEndDay, intEndYear As Integer
            Dim startDate, endDate As Date
            Dim valStart, valEnd As String

            'If IsDate(txtStartDate.Text) = False Then
            'MsgBox("Start Date is not a valid date. Please try again.", MsgBoxStyle.OKOnly, "Invalid Date")
            'txtStartDate.Focus()
            'Exit Sub
            'End If

            'If IsDate(txtEndDate.Text) = False Then
            'MsgBox("End Date is not a valid date. Please try again.", MsgBoxStyle.OKOnly, "Invalid Date")
            'txtEndDate.Focus()
            'Exit Sub
            'End If

            'If txtEndDate.Text < txtStartDate.Text Then
            'MsgBox("End date is before start date. Please reselect date range.", MsgBoxStyle.OKOnly, "Invalid Date Range")
            'txtStartDate.Focus()
            'Exit Sub
            'End If

            'startDate = txtStartDate.Text
            'endDate = txtEndDate.Text

            'intStartMonth = DatePart(DateInterval.Month, startDate)
            'intStartDay = DatePart(DateInterval.Day, startDate)
            'intStartYear = DatePart(DateInterval.Year, startDate)

            'intEndMonth = DatePart(DateInterval.Month, endDate)
            'intEndDay = DatePart(DateInterval.Day, endDate)
            'intEndYear = DatePart(DateInterval.Year, endDate)

            'valStart = "(" & intStartYear & ", " & intStartMonth & ", " & intStartDay & ")"
            'valEnd = "(" & intEndYear & ", " & intEndMonth & ", " & intEndDay & ")"

            'Dim crReport As New Ship_CustCntDly()
            'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            'Dim crParameterFieldDefinition As ParameterFieldDefinition
            'Dim crParameterValues As New ParameterValues()
            'Dim crParameterRangeValue As New ParameterRangeValue()

            'crParameterRangeValue.StartValue = valStart
            'crParameterRangeValue.EndValue = valEnd

            'crParameterFieldDefinitions = crReport.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFieldDefinitions.Item("Date")
            'crParameterValues = crParameterFieldDefinition.CurrentValues
            'crParameterValues.Add(crParameterRangeValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'crReport.PrintToPrinter(1, False, 0, 0)

            'grpDateRange.Visible = False
            'txtStartDate.Text = ""
            'txtEndDate.Text = ""

        End Sub

        Private Sub ReportForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            grpDateRange.Visible = False

        End Sub
    End Class

End Namespace
