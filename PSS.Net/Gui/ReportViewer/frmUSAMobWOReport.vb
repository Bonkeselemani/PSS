Namespace Gui.ReportViewer
    Public Class frmUSAMobWOReport
        Inherits System.Windows.Forms.Form
        Private objMisc As PSS.Data.Buisness.Misc
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Buisness.Misc()
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
        Friend WithEvents cmdCreateRpt As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cmdCreateRpt = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'cmdCreateRpt
            '
            Me.cmdCreateRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCreateRpt.Location = New System.Drawing.Point(62, 56)
            Me.cmdCreateRpt.Name = "cmdCreateRpt"
            Me.cmdCreateRpt.Size = New System.Drawing.Size(152, 56)
            Me.cmdCreateRpt.TabIndex = 1
            Me.cmdCreateRpt.Text = "Create Report"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(264, 32)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "USA Mobility WO Report "
            '
            'frmUSAMobWOReport
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(456, 244)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.cmdCreateRpt})
            Me.Name = "frmUSAMobWOReport"
            Me.Text = "USA Mobility WO Report"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub cmdCreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateRpt.Click
            Dim i As Integer = 0

            Try
                Me.cmdCreateRpt.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                i = objMisc.CreateUSAMobilityWORpt()
                If i = 1 Then
                    MessageBox.Show("Report has been created successfully and saved at '" & objMisc.strRptDir & "'", "USA Mobility WO Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show("frmUSAMobWOReport.cmdCreateRpt_Click:: " & ex.Message)
            Finally
                Me.cmdCreateRpt.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
