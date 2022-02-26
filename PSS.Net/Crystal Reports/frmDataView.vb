Public Class frmDataView
    Inherits System.Windows.Forms.Form

    Private Local_strReportTitle As String
    Private Local_dTB As DataTable
    Private Local_dTB2 As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strReportTitle As String, ByVal dTB As DataTable, ByVal dTB2 As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Local_strReportTitle = strReportTitle
        Local_dTB = dTB
        Local_dTB2 = dTB2
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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGrid2 = New System.Windows.Forms.DataGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(24, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(1200, 400)
        Me.DataGrid1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 424)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(368, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        '
        'DataGrid2
        '
        Me.DataGrid2.DataMember = ""
        Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid2.Location = New System.Drawing.Point(24, 456)
        Me.DataGrid2.Name = "DataGrid2"
        Me.DataGrid2.Size = New System.Drawing.Size(1200, 176)
        Me.DataGrid2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(424, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(376, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data View for Debugging"
        '
        'frmDataView
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1288, 646)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.DataGrid2, Me.Label2, Me.Label1, Me.DataGrid1})
        Me.Name = "frmDataView"
        Me.Text = "frmDataView"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmDataView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGrid1.DataSource = Me.Local_dTB
        Me.Label1.Text = Me.Local_strReportTitle
        Me.Label2.Text = "Records: " & Me.Local_dTB.Rows.Count
        Me.DataGrid2.DataSource = Me.Local_dTB2

    End Sub
End Class
