Public Class frmDiscrepancyReport
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
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents txtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEndDate As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.txtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.txtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(48, 44)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "START DATE:"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(48, 68)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(80, 16)
        Me.lblEndDate.TabIndex = 1
        Me.lblEndDate.Text = "END DATE:"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStartDate
        '
        Me.txtStartDate.Location = New System.Drawing.Point(144, 40)
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.TabIndex = 2
        '
        'txtEndDate
        '
        Me.txtEndDate.Location = New System.Drawing.Point(144, 64)
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.TabIndex = 3
        '
        'frmDiscrepancyReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 405)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEndDate, Me.txtStartDate, Me.lblEndDate, Me.lblStartDate})
        Me.Name = "frmDiscrepancyReport"
        Me.Text = "Discrepancy Report by Date"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
