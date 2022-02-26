Namespace Gui.Shipping

    Public Class frmFOLOT
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
        Friend WithEvents grpFOLOT As System.Windows.Forms.GroupBox
        Friend WithEvents txtFOLOT As System.Windows.Forms.TextBox
        Friend WithEvents lblFOLOT As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grpFOLOT = New System.Windows.Forms.GroupBox()
            Me.txtFOLOT = New System.Windows.Forms.TextBox()
            Me.lblFOLOT = New System.Windows.Forms.Label()
            Me.grpFOLOT.SuspendLayout()
            Me.SuspendLayout()
            '
            'grpFOLOT
            '
            Me.grpFOLOT.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFOLOT, Me.lblFOLOT})
            Me.grpFOLOT.Location = New System.Drawing.Point(8, 8)
            Me.grpFOLOT.Name = "grpFOLOT"
            Me.grpFOLOT.Size = New System.Drawing.Size(408, 56)
            Me.grpFOLOT.TabIndex = 20
            Me.grpFOLOT.TabStop = False
            Me.grpFOLOT.Text = "FO/LOT"
            '
            'txtFOLOT
            '
            Me.txtFOLOT.Location = New System.Drawing.Point(176, 19)
            Me.txtFOLOT.Name = "txtFOLOT"
            Me.txtFOLOT.Size = New System.Drawing.Size(224, 20)
            Me.txtFOLOT.TabIndex = 1
            Me.txtFOLOT.Text = ""
            '
            'lblFOLOT
            '
            Me.lblFOLOT.Location = New System.Drawing.Point(16, 24)
            Me.lblFOLOT.Name = "lblFOLOT"
            Me.lblFOLOT.Size = New System.Drawing.Size(160, 16)
            Me.lblFOLOT.TabIndex = 0
            Me.lblFOLOT.Text = "Please scan the FO/LOT #:"
            '
            'frmFOLOT
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(424, 69)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpFOLOT})
            Me.Name = "frmFOLOT"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "frmFOLOT"
            Me.grpFOLOT.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmFOLOT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtFOLOT.Text = ""
        End Sub

        Private Sub txtFOLOT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFOLOT.KeyUp
            If e.KeyCode = 13 Then
                '//Send data back to form
                Gui.Shipping.frmShipping.G_strFOLOT = txtFOLOT.Text
                Me.Close()
            End If
        End Sub
    End Class

End Namespace
