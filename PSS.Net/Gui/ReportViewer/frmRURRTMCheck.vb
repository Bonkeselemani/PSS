
Namespace Gui.ReportViewer
    Public Class frmRURRTMCheck
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
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents cmdCheck As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.cmdCheck = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'cmdCheck
            '
            Me.cmdCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCheck.Location = New System.Drawing.Point(129, 48)
            Me.cmdCheck.Name = "cmdCheck"
            Me.cmdCheck.Size = New System.Drawing.Size(245, 64)
            Me.cmdCheck.TabIndex = 0
            Me.cmdCheck.Text = "Perform RUR/RTM Check"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(536, 32)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Please click this button and select the excel file you want to validate."
            '
            'frmRURRTMCheck
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(696, 316)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.cmdCheck})
            Me.Name = "frmRURRTMCheck"
            Me.Text = "ATCLE-AWS RUR/RTM Check"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub cmdCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheck.Click
            Dim i As Integer = 0
            Me.OpenFileDialog1.ShowDialog()

            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MsgBox("Please select an excel file for validation.")
                Else
                    i = objMisc.RURRTMCheck(Me.OpenFileDialog1.FileName)
                End If

            End If
        End Sub
    End Class
End Namespace