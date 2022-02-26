Namespace Gui.NewRec


    Public Class frmNEWrec
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
        Friend WithEvents btnTest As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnTest = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'btnTest
            '
            Me.btnTest.Location = New System.Drawing.Point(384, 280)
            Me.btnTest.Name = "btnTest"
            Me.btnTest.Size = New System.Drawing.Size(104, 23)
            Me.btnTest.TabIndex = 0
            Me.btnTest.Text = "User Control"
            '
            'frmNEWrec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(496, 309)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnTest})
            Me.Name = "frmNEWrec"
            Me.Text = "frmNEWrec"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmNEWrec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub

        Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        End Sub
    End Class

End Namespace
