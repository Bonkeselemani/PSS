Imports System.Text
Namespace Gui.WFMTracfone
	Public Class frmWfmReports
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
		Friend WithEvents cboReport As System.Windows.Forms.ComboBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cboReport = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.gbDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboReport
            '
            Me.cboReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboReport.Location = New System.Drawing.Point(128, 48)
            Me.cboReport.Name = "cboReport"
            Me.cboReport.Size = New System.Drawing.Size(368, 24)
            Me.cboReport.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Report Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnPrint
            '
            Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.Location = New System.Drawing.Point(120, 192)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(376, 48)
            Me.btnPrint.TabIndex = 2
            Me.btnPrint.Text = "Run Report"
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.Black
            Me.gbDate.Location = New System.Drawing.Point(112, 88)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 80)
            Me.gbDate.TabIndex = 18
            Me.gbDate.TabStop = False
            Me.gbDate.Text = "DATE"
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.Black
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
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.Black
            Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmWfmReports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(648, 382)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbDate, Me.btnPrint, Me.Label1, Me.cboReport})
            Me.Name = "frmWfmReports"
            Me.Text = "WFM Reporting"
            Me.gbDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "DECLARATIONS"


		Dim ReportDictionary As DictionaryEntry

#End Region
#Region "FORM EVENTS"

		Private Sub frmWfmReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PopulateReportCombo()
            Me.dtpStartDate.Value = Now()
            Me.dtpEndDate.Value = Now()
		End Sub

#End Region
#Region "CONTROL EVENTS"
        Private Sub cboReport_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReport.TextChanged
            Me.gbDate.Visible = False
            Try
                If cboReport.Text = "Triage Production Report" Then
                    Me.gbDate.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Dim _xl As New Data.ExcelReports(True)
            Dim _dt As New DataTable()
            Dim _repName As String = "Box Locations"
            Dim strDateStart, strDateEnd As String

            Me.Cursor = Cursors.WaitCursor

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

            Select Case cboReport.Text
                Case "Box Locations"
                    _repName = "Box Locations"
                    Dim _wfmRep As New Data.BLL.WFMReporting()
                    _dt = _wfmRep.GetBoxLocationData()
                Case "WIP Summary"
                    _repName = "WIP Summary"
                    Dim _wfmRep As New Data.BLL.WFMReporting()
                    _dt = _wfmRep.GetWFMWIPSummaryData()
                Case "Triage Production Report"
                    _repName = "WFM Triage Production Report"
                    Dim _wfmRep As New Data.BLL.WFMReporting()
                    _dt = _wfmRep.GetWFMTriageProductionData(strDateStart, strDateEnd)
                Case Else
                    _dt = Nothing
            End Select
            If Not _dt Is Nothing Then
                Me.TopMost = True
                _xl.RunSimpleXlAndOpen(_dt, _repName)
            End If

            Me.Cursor = Cursors.Default
        End Sub
#End Region
#Region "PROPERTIES"

#End Region
#Region "METHODS"

        Private Sub PopulateReportCombo()
            cboReport.Items.Add("--Select--")
            cboReport.Items.Add("Box Locations")
            cboReport.Items.Add("WIP Summary")
            cboReport.Items.Add("Triage Production Report")
            cboReport.SelectedIndex = 0
        End Sub

#End Region
    End Class
End Namespace
