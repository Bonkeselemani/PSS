Imports PSS.Core.[Global]

Namespace Gui.Security
    Public Class SecurityWin
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
        Friend WithEvents lblUser As System.Windows.Forms.Label
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents txtUser As System.Windows.Forms.TextBox
        Friend WithEvents txtPass As System.Windows.Forms.TextBox
        Friend WithEvents btnLogin As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents label2 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblUser = New System.Windows.Forms.Label()
            Me.lblPass = New System.Windows.Forms.Label()
            Me.txtUser = New System.Windows.Forms.TextBox()
            Me.txtPass = New System.Windows.Forms.TextBox()
            Me.btnLogin = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.label2 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblUser
            '
            Me.lblUser.Location = New System.Drawing.Point(8, 16)
            Me.lblUser.Name = "lblUser"
            Me.lblUser.Size = New System.Drawing.Size(80, 24)
            Me.lblUser.TabIndex = 0
            Me.lblUser.Text = "User name:"
            Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPass
            '
            Me.lblPass.Location = New System.Drawing.Point(8, 40)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.Size = New System.Drawing.Size(80, 24)
            Me.lblPass.TabIndex = 1
            Me.lblPass.Text = "Password:"
            Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtUser
            '
            Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUser.Location = New System.Drawing.Point(96, 16)
            Me.txtUser.Name = "txtUser"
            Me.txtUser.Size = New System.Drawing.Size(152, 21)
            Me.txtUser.TabIndex = 1
            Me.txtUser.Text = ""
            '
            'txtPass
            '
            Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPass.Location = New System.Drawing.Point(96, 40)
            Me.txtPass.Name = "txtPass"
            Me.txtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtPass.Size = New System.Drawing.Size(152, 21)
            Me.txtPass.TabIndex = 2
            Me.txtPass.Text = ""
            '
            'btnLogin
            '
            Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnLogin.Location = New System.Drawing.Point(96, 72)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(72, 24)
            Me.btnLogin.TabIndex = 3
            Me.btnLogin.Text = "Login"
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnCancel.Location = New System.Drawing.Point(176, 72)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(72, 24)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'label2
            '
            Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.label2.Location = New System.Drawing.Point(16, 120)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(240, 120)
            Me.label2.TabIndex = 6
            Me.label2.Text = "This software is Copyright © Product Support Services, Inc. 2003. Reproduction, t" & _
            "ransfer, distribution or storage of part or all of the contents in any form with" & _
            "out the prior written permission of Product Support Services, Inc. is prohibited" & _
            "."
            '
            'SecurityWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(266, 247)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label2, Me.btnCancel, Me.btnLogin, Me.txtPass, Me.txtUser, Me.lblPass, Me.lblUser})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "SecurityWin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "PSS Login"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub SecurityWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            PSS.Core.Highlight.SetHighLight(Me)
            If PSS.Core.Registry.GetKey("RecentLogon") <> "" Then
                txtUser.Text = PSS.Core.Registry.GetKey("RecentLogon")
                txtPass.Focus()
            End If
        End Sub

        Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown
            If e.KeyCode = Keys.Enter Then
                txtPass.Focus()
            End If
        End Sub

        Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
            If e.KeyCode = Keys.Enter Then
                btnLogin_Click(Me, e.Empty)
            End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            End
        End Sub

        Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
            ApplicationUser = New PSS.Rules.Security(Trim(Me.txtUser.Text), Trim(Me.txtPass.Text))
            Try
                Dim objCls As PSS.Data.BaseClasses.CollectTrackingLog
                objCls = New PSS.Data.BaseClasses.CollectTrackingLog()
                objCls.SaveTrackingLogInfo(Me.txtUser.Text, Application.ProductVersion)

                ApplicationUser.CheckLogin()
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                txtPass.SelectAll()
                txtPass.Focus()
            End Try
        End Sub

    End Class
End Namespace
