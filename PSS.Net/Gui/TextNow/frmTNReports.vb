Option Explicit On 
Imports PSS.Data.Buisness

Public Class frmTNReports
    Inherits System.Windows.Forms.Form

    Public _strScreenName As String = ""
    Public _iMenuCust As Integer = 0
    Private _strRptName As String = ""
    Private _NewPriceStartingDate As Date = #6/29/2015#


    Public Enum ReportNames As Integer
        SIM_Card_Inventory = 1
        Received_Orders = 2
        Open_Orders = 3
        Rejected_Orders = 4
        Returned_Orders = 5
        Filled_Orders = 6
    End Enum

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _strScreenName = strScreenName
        _iMenuCust = iCustID
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
    Friend WithEvents grpRptType As System.Windows.Forms.GroupBox
    Friend WithEvents rbtSummaryDetails As System.Windows.Forms.RadioButton
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents gbDate As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents btnRunRpt As System.Windows.Forms.Button
    Friend WithEvents gbWorkOrder As System.Windows.Forms.GroupBox
    Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
    Friend WithEvents rbtSummary As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpRptType = New System.Windows.Forms.GroupBox()
        Me.rbtSummaryDetails = New System.Windows.Forms.RadioButton()
        Me.rbtSummary = New System.Windows.Forms.RadioButton()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.gbReportName = New System.Windows.Forms.GroupBox()
        Me.cboReportName = New System.Windows.Forms.ComboBox()
        Me.gbDate = New System.Windows.Forms.GroupBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.btnRunRpt = New System.Windows.Forms.Button()
        Me.gbWorkOrder = New System.Windows.Forms.GroupBox()
        Me.txtWorkOrder = New System.Windows.Forms.TextBox()
        Me.grpRptType.SuspendLayout()
        Me.gbReportName.SuspendLayout()
        Me.gbDate.SuspendLayout()
        Me.gbWorkOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRptType
        '
        Me.grpRptType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtSummaryDetails, Me.rbtSummary})
        Me.grpRptType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRptType.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.grpRptType.Location = New System.Drawing.Point(72, 216)
        Me.grpRptType.Name = "grpRptType"
        Me.grpRptType.Size = New System.Drawing.Size(400, 48)
        Me.grpRptType.TabIndex = 28
        Me.grpRptType.TabStop = False
        '
        'rbtSummaryDetails
        '
        Me.rbtSummaryDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSummaryDetails.ForeColor = System.Drawing.Color.Black
        Me.rbtSummaryDetails.Location = New System.Drawing.Point(208, 16)
        Me.rbtSummaryDetails.Name = "rbtSummaryDetails"
        Me.rbtSummaryDetails.Size = New System.Drawing.Size(184, 24)
        Me.rbtSummaryDetails.TabIndex = 1
        Me.rbtSummaryDetails.Text = "Summary and Details"
        '
        'rbtSummary
        '
        Me.rbtSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSummary.ForeColor = System.Drawing.Color.Black
        Me.rbtSummary.Location = New System.Drawing.Point(32, 16)
        Me.rbtSummary.Name = "rbtSummary"
        Me.rbtSummary.Size = New System.Drawing.Size(88, 24)
        Me.rbtSummary.TabIndex = 0
        Me.rbtSummary.Text = "Summary"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Navy
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(184, 32)
        Me.lblTitle.TabIndex = 27
        Me.lblTitle.Text = "TextNow Report"
        '
        'gbReportName
        '
        Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
        Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbReportName.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbReportName.Location = New System.Drawing.Point(72, 40)
        Me.gbReportName.Name = "gbReportName"
        Me.gbReportName.Size = New System.Drawing.Size(400, 48)
        Me.gbReportName.TabIndex = 26
        Me.gbReportName.TabStop = False
        Me.gbReportName.Text = "REPORT NAME"
        '
        'cboReportName
        '
        Me.cboReportName.ItemHeight = 13
        Me.cboReportName.Location = New System.Drawing.Point(112, 16)
        Me.cboReportName.MaxDropDownItems = 25
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(272, 21)
        Me.cboReportName.TabIndex = 6
        '
        'gbDate
        '
        Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
        Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbDate.Location = New System.Drawing.Point(72, 96)
        Me.gbDate.Name = "gbDate"
        Me.gbDate.Size = New System.Drawing.Size(400, 80)
        Me.gbDate.TabIndex = 23
        Me.gbDate.TabStop = False
        Me.gbDate.Text = "DATE"
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.ForeColor = System.Drawing.Color.Green
        Me.lblEndDate.Location = New System.Drawing.Point(24, 48)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(80, 16)
        Me.lblEndDate.TabIndex = 105
        Me.lblEndDate.Text = "End:"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(112, 48)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(272, 21)
        Me.dtpEndDate.TabIndex = 1
        Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(112, 16)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(272, 21)
        Me.dtpStartDate.TabIndex = 0
        Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.ForeColor = System.Drawing.Color.Green
        Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
        Me.lblStartDate.TabIndex = 103
        Me.lblStartDate.Text = "Start:"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRunRpt
        '
        Me.btnRunRpt.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunRpt.ForeColor = System.Drawing.Color.White
        Me.btnRunRpt.Location = New System.Drawing.Point(72, 304)
        Me.btnRunRpt.Name = "btnRunRpt"
        Me.btnRunRpt.Size = New System.Drawing.Size(400, 32)
        Me.btnRunRpt.TabIndex = 24
        '
        'gbWorkOrder
        '
        Me.gbWorkOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWorkOrder})
        Me.gbWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbWorkOrder.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbWorkOrder.Location = New System.Drawing.Point(240, 432)
        Me.gbWorkOrder.Name = "gbWorkOrder"
        Me.gbWorkOrder.Size = New System.Drawing.Size(96, 32)
        Me.gbWorkOrder.TabIndex = 25
        Me.gbWorkOrder.TabStop = False
        Me.gbWorkOrder.Text = "WORK ORDER NAME:"
        '
        'txtWorkOrder
        '
        Me.txtWorkOrder.Location = New System.Drawing.Point(112, 16)
        Me.txtWorkOrder.Name = "txtWorkOrder"
        Me.txtWorkOrder.Size = New System.Drawing.Size(272, 20)
        Me.txtWorkOrder.TabIndex = 1
        Me.txtWorkOrder.Text = ""
        '
        'frmTNReports
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 478)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpRptType, Me.lblTitle, Me.gbReportName, Me.gbDate, Me.btnRunRpt, Me.gbWorkOrder})
        Me.Name = "frmTNReports"
        Me.Text = "frmTNReports"
        Me.grpRptType.ResumeLayout(False)
        Me.gbReportName.ResumeLayout(False)
        Me.gbDate.ResumeLayout(False)
        Me.gbWorkOrder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmTNReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboReportName.Items.Clear()
            Me.cboReportName.Items.Add("Select Report Name")
            Dim item

            For Each item In [Enum].GetNames(GetType(ReportNames)) ' [Enum].GetValues(typeof(ReportNames))
                Me.cboReportName.Items.Add(item.ToString) ' .Replace("_", " "))
            Next

            Me.cboReportName.Text = "Select Report Name"

            Me.gbDate.Visible = False
            Me.gbWorkOrder.Visible = False
            Me.btnRunRpt.Visible = False
            Me.grpRptType.Visible = False
            Me.rbtSummary.Checked = True

            Me.grpRptType.Left = Me.gbDate.Left
            Me.grpRptType.Top = Me.gbDate.Top + Me.gbDate.Height + 10

            Me.dtpStartDate.Value = Now()
            Me.dtpEndDate.Value = Now()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '***********************************************************************
    Private Sub cboReportName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
        Dim dt As DataTable

        Me._strRptName = ""
        Me.gbDate.Visible = False
        Me.gbWorkOrder.Visible = False
        Me.btnRunRpt.Visible = False
        Me.grpRptType.Visible = False
        Me.gbDate.Text = "DATE"

        Try
            If Me.cboReportName.Text <> "Select Report Name" Then
                Me._strRptName = Me.cboReportName.Text

                If Me._strRptName = Me.ReportNames.SIM_Card_Inventory.ToString Then
                    Me.grpRptType.Visible = True
                ElseIf Me._strRptName = Me.ReportNames.Received_Orders.ToString Then
                    Me.gbDate.Visible = True
                    Me.gbDate.Text = "RECEIVED DATE"
                ElseIf Me._strRptName = Me.ReportNames.Open_Orders.ToString Then
                    ' Me.gbDate.Visible = True
                ElseIf Me._strRptName = Me.ReportNames.Rejected_Orders.ToString Then
                    Me.gbDate.Visible = True
                    Me.gbDate.Text = "REJECTED DATE"
                ElseIf Me._strRptName = Me.ReportNames.Returned_Orders.ToString Then
                    Me.gbDate.Visible = True
                    Me.gbDate.Text = "RETURNED DATE"
                ElseIf Me._strRptName = Me.ReportNames.Filled_Orders.ToString Then
                    Me.gbDate.Visible = True
                    Me.gbDate.Text = "SHIPPED DATE"
                End If

                Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                Me.btnRunRpt.Visible = True

            Else
                Me.btnRunRpt.Text = ""
                Me.btnRunRpt.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub
    '***********************************************************************
    Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click
        Dim objTNRpt As PSS.Data.Buisness.TN
        Dim strDateStart, strDateEnd As String
        Dim dStartDate As Date
        Dim i As Integer = 0

        Try
            If Me.gbDate.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.gbWorkOrder.Visible = True AndAlso (Me.txtWorkOrder.Text.Trim.Length = 0) Then
                MessageBox.Show("Please select WorkOrder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                strDateStart = "" : strDateEnd = ""

                If Me.gbDate.Visible = True Then
                    If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                        strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    Else
                        strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    End If
                End If

                '*************************************
                'Generate Report
                '*************************************
                objTNRpt = New PSS.Data.Buisness.TN()
                If Me._strRptName = Me.ReportNames.SIM_Card_Inventory.ToString Then
                    Dim strRptNameTmp As String = ""
                    If Me.rbtSummaryDetails.Checked Then
                        strRptNameTmp = Me._strRptName & "(Summary and Details)_" & Format(Now, "yyyyMMddHHmmss")
                        i = objTNRpt.CreateInventoryReport(Me._iMenuCust, strRptNameTmp, True)
                    ElseIf Me.rbtSummary.Checked Then
                        strRptNameTmp = Me._strRptName & "(Summary)_" & Format(Now, "yyyyMMddHHmmss")
                        i = objTNRpt.CreateInventoryReport(Me._iMenuCust, strRptNameTmp, False)
                    Else
                        MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf Me._strRptName = Me.ReportNames.Received_Orders.ToString Then
                    i = objTNRpt.CreateTNSIMCardOrderReport(Me.ReportNames.Received_Orders, Me._iMenuCust, Me._strRptName, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                    If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me._strRptName = Me.ReportNames.Open_Orders.ToString Then
                    i = objTNRpt.CreateTNSIMCardOrderReport(Me.ReportNames.Open_Orders, Me._iMenuCust, Me._strRptName, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                    If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me._strRptName = Me.ReportNames.Rejected_Orders.ToString Then
                    i = objTNRpt.CreateTNSIMCardOrderReport(Me.ReportNames.Rejected_Orders, Me._iMenuCust, Me._strRptName, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                    If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me._strRptName = Me.ReportNames.Returned_Orders.ToString Then
                    i = objTNRpt.CreateTNSIMCardOrderReport(Me.ReportNames.Returned_Orders, Me._iMenuCust, Me._strRptName, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                    If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me._strRptName = Me.ReportNames.Filled_Orders.ToString Then
                    i = objTNRpt.CreateTNSIMCardOrderReport(Me.ReportNames.Filled_Orders, Me._iMenuCust, Me._strRptName, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                    If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("The " & Me._strRptName & " report is not found. Please contact IT Dept.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            objTNRpt = Nothing
            GC.Collect() : GC.WaitForPendingFinalizers()
            GC.Collect() : GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '***********************************************************************
    Private Sub rbtSummaryDetails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtSummaryDetails.CheckedChanged
        Try
            If Me.rbtSummaryDetails.Checked Then
                Me.rbtSummaryDetails.ForeColor = Color.MediumBlue
            Else
                Me.rbtSummaryDetails.ForeColor = Color.Black
            End If
        Catch ex As Exception
        End Try
    End Sub

    '***********************************************************************
    Private Sub rbtSummary_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtSummary.CheckedChanged
        Try
            If Me.rbtSummary.Checked Then
                Me.rbtSummary.ForeColor = Color.MediumBlue
            Else
                Me.rbtSummary.ForeColor = Color.Black
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cboReportName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged

    End Sub
End Class
