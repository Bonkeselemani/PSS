
Option Explicit On 

Namespace Gui.ReportViewer
    Public Class frmNavisionReports
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
        Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
        Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents rbtnOrderDate As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnPostingDate As System.Windows.Forms.RadioButton
        Friend WithEvents btnRunSelectedRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.gbReportName = New System.Windows.Forms.GroupBox()
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.rbtnOrderDate = New System.Windows.Forms.RadioButton()
            Me.rbtnPostingDate = New System.Windows.Forms.RadioButton()
            Me.btnRunSelectedRpt = New System.Windows.Forms.Button()
            Me.gbReportName.SuspendLayout()
            Me.gbDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbReportName
            '
            Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
            Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbReportName.ForeColor = System.Drawing.Color.White
            Me.gbReportName.Location = New System.Drawing.Point(24, 16)
            Me.gbReportName.Name = "gbReportName"
            Me.gbReportName.Size = New System.Drawing.Size(400, 48)
            Me.gbReportName.TabIndex = 7
            Me.gbReportName.TabStop = False
            Me.gbReportName.Text = "REPORT NAME"
            '
            'cboReportName
            '
            Me.cboReportName.Location = New System.Drawing.Point(112, 16)
            Me.cboReportName.Name = "cboReportName"
            Me.cboReportName.Size = New System.Drawing.Size(272, 21)
            Me.cboReportName.TabIndex = 6
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnPostingDate, Me.rbtnOrderDate, Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.White
            Me.gbDate.Location = New System.Drawing.Point(24, 72)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 112)
            Me.gbDate.TabIndex = 6
            Me.gbDate.TabStop = False
            Me.gbDate.Text = "DATE"
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.White
            Me.lblEndDate.Location = New System.Drawing.Point(24, 80)
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
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 80)
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
            Me.dtpStartDate.Location = New System.Drawing.Point(112, 48)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpStartDate.TabIndex = 0
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.White
            Me.lblStartDate.Location = New System.Drawing.Point(24, 48)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbtnOrderDate
            '
            Me.rbtnOrderDate.Location = New System.Drawing.Point(120, 16)
            Me.rbtnOrderDate.Name = "rbtnOrderDate"
            Me.rbtnOrderDate.TabIndex = 106
            Me.rbtnOrderDate.Text = "Order"
            '
            'rbtnPostingDate
            '
            Me.rbtnPostingDate.Location = New System.Drawing.Point(272, 16)
            Me.rbtnPostingDate.Name = "rbtnPostingDate"
            Me.rbtnPostingDate.TabIndex = 107
            Me.rbtnPostingDate.Text = "Posting"
            '
            'btnRunSelectedRpt
            '
            Me.btnRunSelectedRpt.BackColor = System.Drawing.Color.Green
            Me.btnRunSelectedRpt.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunSelectedRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunSelectedRpt.Location = New System.Drawing.Point(24, 216)
            Me.btnRunSelectedRpt.Name = "btnRunSelectedRpt"
            Me.btnRunSelectedRpt.Size = New System.Drawing.Size(400, 32)
            Me.btnRunSelectedRpt.TabIndex = 8
            Me.btnRunSelectedRpt.Text = "Run"
            '
            'frmNavisionReports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(688, 502)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRunSelectedRpt, Me.gbReportName, Me.gbDate})
            Me.Name = "frmNavisionReports"
            Me.Text = "frmNavisionReports"
            Me.gbReportName.ResumeLayout(False)
            Me.gbDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace