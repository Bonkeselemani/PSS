Public Class frmFailCodeConfig
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
	Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
	Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.DataGrid1 = New System.Windows.Forms.DataGrid()
		Me.DataGrid2 = New System.Windows.Forms.DataGrid()
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'DataGrid1
		'
		Me.DataGrid1.CaptionText = "Fail Codes"
		Me.DataGrid1.DataMember = ""
		Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
		Me.DataGrid1.Name = "DataGrid1"
		Me.DataGrid1.Size = New System.Drawing.Size(264, 200)
		Me.DataGrid1.TabIndex = 0
		'
		'DataGrid2
		'
		Me.DataGrid2.DataMember = ""
		Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid2.Location = New System.Drawing.Point(288, 8)
		Me.DataGrid2.Name = "DataGrid2"
		Me.DataGrid2.Size = New System.Drawing.Size(328, 200)
		Me.DataGrid2.TabIndex = 1
		'
		'frmFailCodeConfig
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(792, 590)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid2, Me.DataGrid1})
		Me.Name = "frmFailCodeConfig"
		Me.Text = "Fail Codes"
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

End Class
