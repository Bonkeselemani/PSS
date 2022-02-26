Imports PSS.Data
Imports PSS.Core

Namespace Gui.Receiving

    Public Class frmWebUserInput
        Inherits System.Windows.Forms.Form

        Public WebUserID As String

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

            If Len(txtWebUserID.Text) < 1 Then
                WebUserID = 0
            End If
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
        Friend WithEvents lblUSer As System.Windows.Forms.Label
        Friend WithEvents txtWebUserID As System.Windows.Forms.TextBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblUSer = New System.Windows.Forms.Label()
            Me.txtWebUserID = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblUSer
            '
            Me.lblUSer.Location = New System.Drawing.Point(0, 16)
            Me.lblUSer.Name = "lblUSer"
            Me.lblUSer.Size = New System.Drawing.Size(280, 16)
            Me.lblUSer.TabIndex = 0
            Me.lblUSer.Text = "Please scan the Web user information from the report:"
            '
            'txtWebUserID
            '
            Me.txtWebUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWebUserID.Location = New System.Drawing.Point(32, 40)
            Me.txtWebUserID.Name = "txtWebUserID"
            Me.txtWebUserID.TabIndex = 1
            Me.txtWebUserID.Text = ""
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Location = New System.Drawing.Point(144, 40)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(104, 23)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            '
            'frmWebUserInput
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(280, 69)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.txtWebUserID, Me.lblUSer})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmWebUserInput"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Enter Web User"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            txtWebUserID.Text = 0
            WebUserID = 0
            Me.Close()
            Me.Dispose()

        End Sub

        Private Sub txtWebUserID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWebUserID.TextChanged

        End Sub


        Private Sub txtWebUserID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWebUserID.KeyDown

            If e.KeyValue = 13 Then
                WebUserID = txtWebUserID.Text
                Me.Close()
                Me.Dispose()
            End If

        End Sub

        Private Sub frmWebUserInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace
