Imports PSS.Core.Global
Imports System.Configuration.ConfigurationSettings
Imports PSS.Data.Buisness.Security
Imports PSS.Data
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
        Friend WithEvents grpBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtOldPass As System.Windows.Forms.TextBox
        Friend WithEvents lblOldPass As System.Windows.Forms.Label
        Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
        Friend WithEvents lblNewPass As System.Windows.Forms.Label
        Friend WithEvents txtConfirmPass As System.Windows.Forms.TextBox
        Friend WithEvents lblConfirmPass As System.Windows.Forms.Label
        Friend WithEvents btnCancelReset As System.Windows.Forms.Button
        Friend WithEvents btnOKSave As System.Windows.Forms.Button
        Friend WithEvents btnPassRule As System.Windows.Forms.Button
        Friend WithEvents lblInfo As System.Windows.Forms.Label
        Friend WithEvents pnlLogin As System.Windows.Forms.Panel
        Friend WithEvents btnPassReset As System.Windows.Forms.Button
        Friend WithEvents txtUserName As System.Windows.Forms.TextBox
        Friend WithEvents lbluserName As System.Windows.Forms.Label
        Friend WithEvents lblVersion As System.Windows.Forms.Label
        Friend WithEvents lblProd As System.Windows.Forms.Label
        Friend WithEvents lblDevNet As System.Windows.Forms.Label
        Friend WithEvents lblTestNet As System.Windows.Forms.Label

        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SecurityWin))
            Me.lblUser = New System.Windows.Forms.Label()
            Me.lblPass = New System.Windows.Forms.Label()
            Me.txtUser = New System.Windows.Forms.TextBox()
            Me.txtPass = New System.Windows.Forms.TextBox()
            Me.btnLogin = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grpBox1 = New System.Windows.Forms.GroupBox()
            Me.txtUserName = New System.Windows.Forms.TextBox()
            Me.lbluserName = New System.Windows.Forms.Label()
            Me.btnPassRule = New System.Windows.Forms.Button()
            Me.btnCancelReset = New System.Windows.Forms.Button()
            Me.btnOKSave = New System.Windows.Forms.Button()
            Me.txtConfirmPass = New System.Windows.Forms.TextBox()
            Me.lblConfirmPass = New System.Windows.Forms.Label()
            Me.txtNewPass = New System.Windows.Forms.TextBox()
            Me.lblNewPass = New System.Windows.Forms.Label()
            Me.txtOldPass = New System.Windows.Forms.TextBox()
            Me.lblOldPass = New System.Windows.Forms.Label()
            Me.pnlLogin = New System.Windows.Forms.Panel()
            Me.lblVersion = New System.Windows.Forms.Label()
            Me.btnPassReset = New System.Windows.Forms.Button()
            Me.lblInfo = New System.Windows.Forms.Label()
            Me.lblProd = New System.Windows.Forms.Label()
            Me.lblDevNet = New System.Windows.Forms.Label()
            Me.lblTestNet = New System.Windows.Forms.Label()
            Me.grpBox1.SuspendLayout()
            Me.pnlLogin.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblUser
            '
            Me.lblUser.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUser.Location = New System.Drawing.Point(16, 12)
            Me.lblUser.Name = "lblUser"
            Me.lblUser.Size = New System.Drawing.Size(80, 24)
            Me.lblUser.TabIndex = 0
            Me.lblUser.Text = "User name:"
            Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPass
            '
            Me.lblPass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPass.Location = New System.Drawing.Point(16, 36)
            Me.lblPass.Name = "lblPass"
            Me.lblPass.Size = New System.Drawing.Size(80, 24)
            Me.lblPass.TabIndex = 1
            Me.lblPass.Text = "Password:"
            Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtUser
            '
            Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUser.Location = New System.Drawing.Point(104, 16)
            Me.txtUser.Name = "txtUser"
            Me.txtUser.Size = New System.Drawing.Size(152, 21)
            Me.txtUser.TabIndex = 1
            Me.txtUser.Text = ""
            '
            'txtPass
            '
            Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPass.Location = New System.Drawing.Point(104, 40)
            Me.txtPass.Name = "txtPass"
            Me.txtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtPass.Size = New System.Drawing.Size(152, 21)
            Me.txtPass.TabIndex = 2
            Me.txtPass.Text = ""
            '
            'btnLogin
            '
            Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLogin.ForeColor = System.Drawing.Color.Black
            Me.btnLogin.Location = New System.Drawing.Point(104, 72)
            Me.btnLogin.Name = "btnLogin"
            Me.btnLogin.Size = New System.Drawing.Size(72, 24)
            Me.btnLogin.TabIndex = 3
            Me.btnLogin.Text = "Login"
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(184, 72)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(72, 24)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Quit"
            '
            'grpBox1
            '
            Me.grpBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtUserName, Me.lbluserName, Me.btnPassRule, Me.btnCancelReset, Me.btnOKSave, Me.txtConfirmPass, Me.lblConfirmPass, Me.txtNewPass, Me.lblNewPass, Me.txtOldPass, Me.lblOldPass})
            Me.grpBox1.ForeColor = System.Drawing.Color.Black
            Me.grpBox1.Location = New System.Drawing.Point(0, 288)
            Me.grpBox1.Name = "grpBox1"
            Me.grpBox1.Size = New System.Drawing.Size(360, 232)
            Me.grpBox1.TabIndex = 7
            Me.grpBox1.TabStop = False
            Me.grpBox1.Text = "Reset Password"
            '
            'txtUserName
            '
            Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtUserName.Location = New System.Drawing.Point(168, 24)
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.Size = New System.Drawing.Size(152, 21)
            Me.txtUserName.TabIndex = 10
            Me.txtUserName.Text = ""
            '
            'lbluserName
            '
            Me.lbluserName.Location = New System.Drawing.Point(80, 24)
            Me.lbluserName.Name = "lbluserName"
            Me.lbluserName.Size = New System.Drawing.Size(80, 24)
            Me.lbluserName.TabIndex = 9
            Me.lbluserName.Text = "User name:"
            Me.lbluserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPassRule
            '
            Me.btnPassRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPassRule.ForeColor = System.Drawing.SystemColors.Control
            Me.btnPassRule.Image = CType(resources.GetObject("btnPassRule.Image"), System.Drawing.Bitmap)
            Me.btnPassRule.Location = New System.Drawing.Point(326, 206)
            Me.btnPassRule.Name = "btnPassRule"
            Me.btnPassRule.Size = New System.Drawing.Size(24, 24)
            Me.btnPassRule.TabIndex = 8
            '
            'btnCancelReset
            '
            Me.btnCancelReset.Location = New System.Drawing.Point(248, 168)
            Me.btnCancelReset.Name = "btnCancelReset"
            Me.btnCancelReset.Size = New System.Drawing.Size(72, 24)
            Me.btnCancelReset.TabIndex = 5
            Me.btnCancelReset.Text = "Cancel"
            '
            'btnOKSave
            '
            Me.btnOKSave.Location = New System.Drawing.Point(168, 168)
            Me.btnOKSave.Name = "btnOKSave"
            Me.btnOKSave.Size = New System.Drawing.Size(72, 24)
            Me.btnOKSave.TabIndex = 4
            Me.btnOKSave.Text = "OK"
            '
            'txtConfirmPass
            '
            Me.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtConfirmPass.Location = New System.Drawing.Point(168, 128)
            Me.txtConfirmPass.Name = "txtConfirmPass"
            Me.txtConfirmPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtConfirmPass.Size = New System.Drawing.Size(152, 21)
            Me.txtConfirmPass.TabIndex = 3
            Me.txtConfirmPass.Text = ""
            '
            'lblConfirmPass
            '
            Me.lblConfirmPass.Location = New System.Drawing.Point(16, 128)
            Me.lblConfirmPass.Name = "lblConfirmPass"
            Me.lblConfirmPass.Size = New System.Drawing.Size(144, 24)
            Me.lblConfirmPass.TabIndex = 7
            Me.lblConfirmPass.Text = "Confirm New Password:"
            Me.lblConfirmPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNewPass
            '
            Me.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNewPass.Location = New System.Drawing.Point(168, 96)
            Me.txtNewPass.Name = "txtNewPass"
            Me.txtNewPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtNewPass.Size = New System.Drawing.Size(152, 21)
            Me.txtNewPass.TabIndex = 2
            Me.txtNewPass.Text = ""
            '
            'lblNewPass
            '
            Me.lblNewPass.Location = New System.Drawing.Point(56, 96)
            Me.lblNewPass.Name = "lblNewPass"
            Me.lblNewPass.Size = New System.Drawing.Size(104, 24)
            Me.lblNewPass.TabIndex = 5
            Me.lblNewPass.Text = "New Password:"
            Me.lblNewPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtOldPass
            '
            Me.txtOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOldPass.Location = New System.Drawing.Point(168, 64)
            Me.txtOldPass.Name = "txtOldPass"
            Me.txtOldPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtOldPass.Size = New System.Drawing.Size(152, 21)
            Me.txtOldPass.TabIndex = 1
            Me.txtOldPass.Text = ""
            '
            'lblOldPass
            '
            Me.lblOldPass.Location = New System.Drawing.Point(56, 64)
            Me.lblOldPass.Name = "lblOldPass"
            Me.lblOldPass.Size = New System.Drawing.Size(104, 24)
            Me.lblOldPass.TabIndex = 3
            Me.lblOldPass.Text = "Old Password:"
            Me.lblOldPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlLogin
            '
            Me.pnlLogin.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDevNet, Me.lblTestNet, Me.lblVersion, Me.btnPassReset, Me.lblInfo, Me.btnLogin, Me.txtPass, Me.lblPass, Me.txtUser, Me.btnCancel, Me.lblUser, Me.lblProd})
            Me.pnlLogin.Name = "pnlLogin"
            Me.pnlLogin.Size = New System.Drawing.Size(296, 256)
            Me.pnlLogin.TabIndex = 8
            '
            'lblVersion
            '
            Me.lblVersion.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblVersion.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblVersion.Location = New System.Drawing.Point(16, 216)
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Size = New System.Drawing.Size(64, 32)
            Me.lblVersion.TabIndex = 13
            Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnPassReset
            '
            Me.btnPassReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPassReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPassReset.ForeColor = System.Drawing.Color.DimGray
            Me.btnPassReset.Location = New System.Drawing.Point(168, 224)
            Me.btnPassReset.Name = "btnPassReset"
            Me.btnPassReset.Size = New System.Drawing.Size(120, 24)
            Me.btnPassReset.TabIndex = 10
            Me.btnPassReset.Text = "Password Reset . . ."
            '
            'lblInfo
            '
            Me.lblInfo.Location = New System.Drawing.Point(16, 112)
            Me.lblInfo.Name = "lblInfo"
            Me.lblInfo.Size = New System.Drawing.Size(240, 96)
            Me.lblInfo.TabIndex = 9
            Me.lblInfo.Text = "This software is Copyright © Product Support Services, Inc. 2003. Reproduction, t" & _
            "ransfer, distribution or storage of part or all of the contents in any form with" & _
            "out the prior written permission of Product Support Services, Inc. is prohibited" & _
            "."
            '
            'lblProd
            '
            Me.lblProd.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblProd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProd.ForeColor = System.Drawing.Color.White
            Me.lblProd.Location = New System.Drawing.Point(80, 230)
            Me.lblProd.Name = "lblProd"
            Me.lblProd.Size = New System.Drawing.Size(72, 20)
            Me.lblProd.TabIndex = 18
            Me.lblProd.Text = "Production"
            Me.lblProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDevNet
            '
            Me.lblDevNet.BackColor = System.Drawing.Color.ForestGreen
            Me.lblDevNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDevNet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevNet.ForeColor = System.Drawing.Color.White
            Me.lblDevNet.Location = New System.Drawing.Point(80, 230)
            Me.lblDevNet.Name = "lblDevNet"
            Me.lblDevNet.Size = New System.Drawing.Size(72, 20)
            Me.lblDevNet.TabIndex = 17
            Me.lblDevNet.Text = "DEVNET"
            Me.lblDevNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblTestNet
            '
            Me.lblTestNet.BackColor = System.Drawing.Color.Red
            Me.lblTestNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTestNet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestNet.ForeColor = System.Drawing.Color.White
            Me.lblTestNet.Location = New System.Drawing.Point(80, 230)
            Me.lblTestNet.Name = "lblTestNet"
            Me.lblTestNet.Size = New System.Drawing.Size(72, 20)
            Me.lblTestNet.TabIndex = 16
            Me.lblTestNet.Text = "TESTNET"
            Me.lblTestNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'SecurityWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(370, 544)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlLogin, Me.grpBox1})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "SecurityWin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "PSS.Net Login"
            Me.grpBox1.ResumeLayout(False)
            Me.pnlLogin.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private Sub SecurityWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objSecurity As PSS.Data.Buisness.Security
            Dim objSecurityRulePW As PSS.rules.SecurityPassword
            Try

                lblVersion.Text = "Version" & vbCrLf & Application.ProductVersion.ToString()
                CheckEnvironment()

                PSS.Core.Highlight.SetHighLight(Me)

                SetLoginMode()

                If PSS.Core.Registry.GetKey("RecentLogon") <> "" Then
                    txtUser.Text = PSS.Core.Registry.GetKey("RecentLogon")
                    Me.ActiveControl = txtPass
                    txtPass.Text = "" : txtPass.SelectAll() : txtPass.Focus()
                End If


                objSecurity = New PSS.Data.Buisness.Security()
                'objSecurityRulePW = New PSS.Rules.SecurityPassword()

                'MessageBox.Show("LowerLetter=" & objSecurityRulePW.LowerLetter & Environment.NewLine & _
                '                "UpperLetter=" & objSecurityRulePW.UpperLetter & Environment.NewLine & _
                '                "NumericNumber=" & objSecurityRulePW.NumericNumber & Environment.NewLine & _
                '                "SpecialCharacter=" & objSecurityRulePW.SpecialCharacter & Environment.NewLine & _
                '                "PasswordLength=" & objSecurityRulePW.PasswordLength & Environment.NewLine & _
                '                "PasswordExpireDays=" & objSecurityRulePW.PasswordExpireDays & Environment.NewLine & _
                '                "ReuseLastPWMonth=" & objSecurityRulePW.ReuseLastPWMonths & Environment.NewLine & _
                '                "AccoutLockoutTimes=" & objSecurityRulePW.AccoutLockoutTimes & Environment.NewLine & _
                '                "AccountResetMinutes=" & objSecurityRulePW.AccountResetMinutes & Environment.NewLine)




                'If objSecurity.IsRuleItemMatched Then

                '    objSecurityRulePW.CheckpasswordExpired()

                '    SetLoginModel()

                '    If PSS.Core.Registry.GetKey("RecentLogon") <> "" Then
                '        txtUser.Text = PSS.Core.Registry.GetKey("RecentLogon")
                '        txtPass.Focus()
                '    End If
                'Else
                '    MessageBox.Show("Table security.tpasswordrules has invalid rule item(s). Can't run PSS.NET. ", " SecurityWin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    End
                'End If

                'objSecurity = Nothing : objSecurityRulePW = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.Message, " SecurityWin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End Try
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
            Dim objSecurity As PSS.Data.Buisness.Security
            Dim objSecurityRulePW As PSS.rules.SecurityPassword
            Dim bReadyToProcessLogin As Boolean = False

            Dim dt, dt2 As DataTable
            Dim iUserID As Integer = 0
            Dim strUserName As String = Trim(Me.txtUser.Text)
            Dim strPassword As String = Trim(Me.txtPass.Text)

            objSecurity = New PSS.Data.Buisness.Security()
            objSecurityRulePW = New PSS.rules.SecurityPassword()

            'MessageBox.Show("LowerLetter=" & objSecurityRulePW.LowerLetter & Environment.NewLine & _
            '                "UpperLetter=" & objSecurityRulePW.UpperLetter & Environment.NewLine & _
            '                "NumericNumber=" & objSecurityRulePW.NumericNumber & Environment.NewLine & _
            '                "SpecialCharacter=" & objSecurityRulePW.SpecialCharacter & Environment.NewLine & _
            '                "PasswordLength=" & objSecurityRulePW.PasswordLength & Environment.NewLine & _
            '                "PasswordExpireDays=" & objSecurityRulePW.PasswordExpireDays & Environment.NewLine & _
            '                "ReuseLastPWMonth=" & objSecurityRulePW.ReuseLastPWMonths & Environment.NewLine & _
            '                "AccoutLockoutTimes=" & objSecurityRulePW.AccoutLockoutTimes & Environment.NewLine & _
            '                "AccountResetMinutes=" & objSecurityRulePW.AccountResetMinutes & Environment.NewLine)

            If strUserName.Length = 0 Then
                MessageBox.Show("Please enter user login name. ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUser.SelectAll() : txtUser.Focus() : Exit Sub
            End If
            If strPassword.Length = 0 Then
                MessageBox.Show("Please enter password. ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPass.SelectAll() : txtPass.Focus() : Exit Sub
            End If

            ApplicationUser = New PSS.rules.Security(strUserName, strPassword)

            If strUserName.ToLower <> ApplicationUser.AdminUserName.ToLower Then 'non admin account 

                If Not objSecurity.IsUserExist(strUserName) Then
                    MessageBox.Show("Can't find Login name '" & strUserName & "' in the system.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUser.SelectAll() : txtUser.Focus() : txtPass.Text = "" : Exit Sub
                End If
                iUserID = objSecurity.getUserID(strUserName)
                If Not iUserID > 0 Then
                    MessageBox.Show("Can't identify user id for login name '" & strUserName & "'.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUser.SelectAll() : txtUser.Focus() : txtPass.Text = "" : Exit Sub
                End If
                If Not objSecurity.IsUserActive(iUserID) Then
                    MessageBox.Show("This account '" & strUserName & "' is inactive.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtUser.SelectAll() : txtUser.Focus() : txtPass.Text = "" : Exit Sub
                End If
                If objSecurityRulePW.IsAccountLocked(iUserID) AndAlso Not objSecurityRulePW.IsAccountResetMinutesOver(iUserID) _
                    AndAlso (objSecurityRulePW.IsAccountResetMinutesOver_AttemptedNo(iUserID) = 0 _
                    OrElse objSecurityRulePW.IsAccountResetMinutesOver_AttemptedNo(iUserID) > objSecurityRulePW.AccoutLockoutTimes - 1) Then
                    MessageBox.Show("Your PSS.NET account '" & strUserName & "' has been locked out." & Environment.NewLine & _
                                    "It will be unlock in " & objSecurityRulePW.AccountResetMinutes & " minutes." & Environment.NewLine & _
                                    "See your supervisor or IT.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtUser.SelectAll() : txtUser.Focus() : txtPass.Text = "" : Exit Sub
                End If

                If objSecurity.IsRuleItemMatched Then
                    bReadyToProcessLogin = True
                    'dt2 = objSecurity.getPasswordLogData(iUserID)
                    'If dt2.Rows.Count = 0 OrElse objSecurityRulePW.IsPsswordExpired(iUserID) Then
                    '    SetResetMode() : bReadyToProcessLogin = False
                    'Else
                    '    bReadyToProcessLogin = True
                    'End If
                Else
                    MessageBox.Show("Table security.tpasswordrules has invalid rule item(s). Can't run PSS.NET. ", " SecurityWin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    bReadyToProcessLogin = False
                End If
            Else 'admin account 
                bReadyToProcessLogin = True
            End If



            '#########################################################################################################
            If bReadyToProcessLogin Then

                'Login processing
                'ApplicationUser = New PSS.Rules.Security(strUserName, strPassword)

                Try
                    If strUserName.ToLower = ApplicationUser.AdminUserName.ToLower Then 'admin
                        If strPassword = ApplicationUser.AdminPassword Then

                            ' ApplicationUser = New PSS.Rules.Security(strUserName, strPassword)
                            ApplicationUser.CheckLogin() 'Process login 

                            'KEEP LOGIN TRACK
                            Dim objCls As PSS.Data.BaseClasses.CollectTrackingLog
                            objCls = New PSS.Data.BaseClasses.CollectTrackingLog()
                            objCls.SaveTrackingLogInfo(strUserName, Application.ProductVersion)

                            Me.Close()
                        Else
                            MessageBox.Show("Invalid Password!", "btnLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.ActiveControl = txtPass : txtPass.SelectAll() : txtPass.Focus()
                            ApplicationUser = Nothing
                        End If
                    Else 'non-admin
                        dt = objSecurity.GetLoginDatatable(strUserName, strPassword)

                        If dt.Rows.Count > 0 Then 'PASSED
                            'Check lock out again
                            If objSecurityRulePW.IsAccountLocked(iUserID) Then
                                MessageBox.Show("Your PSS.NET account '" & strUserName & "' has been locked out." & Environment.NewLine & _
                                                "It will be unlock in " & objSecurityRulePW.AccountResetMinutes & " minutes." & Environment.NewLine & _
                                                "See your supervisor or IT.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                txtUser.SelectAll() : txtUser.Focus() : txtPass.Text = ""
                                ApplicationUser = Nothing : Exit Sub
                            End If
                            dt2 = objSecurity.getPasswordLogData(iUserID)
                            If dt2.Rows.Count = 0 OrElse objSecurityRulePW.IsPsswordExpired(iUserID) Then
                                MessageBox.Show("Your PSS.NET password is expired. Please reset it.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                SetResetMode() : ApplicationUser = Nothing : Exit Sub
                            End If

                            ApplicationUser.CheckLogin() 'Process login 

                            'KEEP LOGIN TRACK
                            Dim objCls As PSS.Data.BaseClasses.CollectTrackingLog
                            objCls = New PSS.Data.BaseClasses.CollectTrackingLog()
							objCls.SaveTrackingLogInfo(strUserName, Application.ProductVersion)

							_app = Data.BaseClasses.App.Create(ApplicationUser.IDuser, ApplicationUser.User, Environment.MachineName)

							Me.Close()

                        Else 'FAILED
                            objSecurityRulePW.SavePasswordAttemptedFailedLog(iUserID, strPassword)
                            MessageBox.Show("Invalid Password!", "btnLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                            Me.ActiveControl = txtPass : txtPass.SelectAll() : txtPass.Focus()
                            ApplicationUser = Nothing
                        End If

                    End If

                    'If dt.Rows.Count > 0 Then 'PASSED
                    '    If objSecurityRulePW.IsAccountLocked(iUserID) AndAlso strUserName.ToUpper <> "pssadmin".ToUpper Then
                    '        MessageBox.Show("Your PSS.NET account '" & strUserName & "' is locked out. Can't login. See your supervisor or IT.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        txtUser.SelectAll() : txtUser.Focus() : txtPass.Text = "" : Exit Sub
                    '    End If

                    '    ApplicationUser.CheckLogin() 'Process login 

                    '    'KEEP LOGIN TRACK
                    '    Dim objCls As PSS.Data.BaseClasses.CollectTrackingLog
                    '    objCls = New PSS.Data.BaseClasses.CollectTrackingLog()
                    '    objCls.SaveTrackingLogInfo(strUserName, Application.ProductVersion)

                    '    Me.Close()
                    'Else 'FAILED
                    '    If strUserName.ToUpper <> "pssadmin".ToUpper Then
                    '        objSecurityRulePW.SavePasswordAttemptedFailedLog(iUserID, strPassword)
                    '        MessageBox.Show("Invalid Password!", "btnLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        Me.ActiveControl = txtPass
                    '        txtPass.SelectAll() : txtPass.Focus()
                    '    End If
                    'End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "btnLogin_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    txtPass.SelectAll()
                    txtPass.Focus()
                Finally
                    objSecurity = Nothing : objSecurityRulePW = Nothing : dt = Nothing
                End Try
            End If

        End Sub
        Private Sub btnPassRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassRule.Click
            Dim objSecurityRulePW As New PSS.rules.SecurityPassword()
            Try
                MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Password Rule", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPassRule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSecurityRulePW = Nothing
            End Try
        End Sub
        Private Sub btnPassReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassReset.Click
            'Dim objSecurity As New PSS.Data.Buisness.Security()
            'Dim objSecurityRulePW As New PSS.Rules.SecurityPassword()
            'Dim iUserID As Integer = 0

            Try
                'iUserID = objSecurity.getUserID(Trim(Me.txtUser.Text))
                'If iUserID > 0 AndAlso Not objSecurityRulePW.IsAccountLocked(iUserID) Then
                '    SetResetMode()
                'Else
                '    MessageBox.Show("Your PSS.NET account '" & Trim(Me.txtUser.Text) & "' is locked out.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If

                SetResetMode()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPassReset_Clickk", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Finally
                ' objSecurity = Nothing : objSecurityRulePW = Nothing
            End Try
        End Sub
        Private Sub btnOKSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOKSave.Click
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim objSecurityRulePW As New PSS.rules.SecurityPassword()
            Dim dt As DataTable

            Dim iUserID As Integer = 0
            Dim strUserName As String = Trim(Me.txtUserName.Text)
            Dim strOldPassword As String = Trim(Me.txtOldPass.Text)
            Dim strNewPW As String = ""
            Dim i As Integer = 0

            Try


                If strUserName.Length = 0 Then
                    MessageBox.Show("Please enter user login name. ", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNewPass.Text = "" : txtConfirmPass.Text = ""
                    txtUserName.SelectAll() : txtUserName.Focus() : Exit Sub
                End If
                If strOldPassword.Length = 0 Then
                    MessageBox.Show("Please enter old password. ", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNewPass.Text = "" : txtConfirmPass.Text = ""
                    txtOldPass.SelectAll() : txtOldPass.Focus() : Exit Sub
                End If

                ApplicationUser = New PSS.rules.Security(strUserName, strOldPassword)
                If strUserName.ToLower = ApplicationUser.AdminUserName.ToLower Then
                    MessageBox.Show("Can't reset the password for '" & ApplicationUser.AdminUserName & "'!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ApplicationUser = Nothing : Exit Sub
                End If

                If Not objSecurity.IsUserExist(strUserName) Then
                    MessageBox.Show("Can't find user login name '" & strUserName & "' in the system.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNewPass.Text = "" : txtConfirmPass.Text = ""
                    txtUserName.SelectAll() : txtUserName.Focus() : txtOldPass.Text = "" : Exit Sub
                End If
                iUserID = objSecurity.getUserID(strUserName)
                If Not iUserID > 0 Then
                    MessageBox.Show("Can't identify user id for login name '" & strUserName & "'.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNewPass.Text = "" : txtConfirmPass.Text = ""
                    txtUserName.SelectAll() : txtUserName.Focus() : txtOldPass.Text = "" : Exit Sub
                End If
                If Not objSecurity.IsUserActive(iUserID) Then
                    MessageBox.Show("This account '" & strUserName & "' is inactive.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtNewPass.Text = "" : txtConfirmPass.Text = "" : txtOldPass.Text = ""
                    txtUserName.SelectAll() : txtUserName.Focus() : Exit Sub
                End If
                If objSecurityRulePW.IsAccountLocked(iUserID) AndAlso Not objSecurityRulePW.IsAccountResetMinutesOver(iUserID) _
                    AndAlso (objSecurityRulePW.IsAccountResetMinutesOver_AttemptedNo(iUserID) = 0 _
                    OrElse objSecurityRulePW.IsAccountResetMinutesOver_AttemptedNo(iUserID) > objSecurityRulePW.AccoutLockoutTimes - 1) Then
                    MessageBox.Show("Your PSS.NET account '" & strUserName & "' has been locked out." & Environment.NewLine & _
                                    "It will be unlock in " & objSecurityRulePW.AccountResetMinutes & " minutes." & Environment.NewLine & _
                                    "See your supervisor or IT.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtNewPass.Text = "" : txtConfirmPass.Text = "" : txtOldPass.Text = ""
                    txtUserName.SelectAll() : txtUserName.Focus() : Exit Sub
                End If

                'Old password--------------------------------------------
                dt = objSecurity.GetLoginDatatable(strUserName, strOldPassword)
                If dt.Rows.Count > 0 Then 'PASSED
                    If objSecurityRulePW.IsAccountLocked(iUserID) Then
                        MessageBox.Show("This PSS.NET account '" & strUserName & "' is locked out. Can't reset. See your supervisor or IT.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        txtNewPass.Text = "" : txtConfirmPass.Text = "" : txtOldPass.Text = ""
                        txtUserName.SelectAll() : txtUserName.Focus() : Exit Sub
                    End If
                Else 'FAILED
                    objSecurityRulePW.SavePasswordAttemptedFailedLog(iUserID, strOldPassword)
                    MessageBox.Show("Old password is not correct.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Me.ActiveControl = txtPass : txtPass.SelectAll() : txtPass.Focus()
                    ApplicationUser = Nothing : Exit Sub
                End If
                '---------------------------------------------------

                dt = objSecurity.GetLoginDatatableByUserID(iUserID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't identify this account '" & strUserName & "' in the system.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNewPass.Text = "" : txtConfirmPass.Text = ""
                    txtUserName.SelectAll() : txtUserName.Focus() : txtOldPass.Text = ""
                Else 'rows.count =1
                    strNewPW = txtNewPass.Text.Trim
                    If Not txtOldPass.Text.Trim = dt.Rows(0).Item("user_pass").ToString.Trim Then
                        MessageBox.Show("Old password is not correct.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtNewPass.Text = "" : txtConfirmPass.Text = ""
                        txtOldPass.SelectAll() : txtOldPass.Focus()
                    ElseIf txtNewPass.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter a new password.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtNewPass.SelectAll() : txtNewPass.Focus()
                    ElseIf Not strNewPW = txtConfirmPass.Text.Trim Then
                        MessageBox.Show("The confirm new password differs from the new password.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtConfirmPass.SelectAll() : txtNewPass.Focus()
                    ElseIf objSecurityRulePW.UpperLetter AndAlso _
                           Not objSecurityRulePW.IsPsswordContainUpperLeter(strNewPW) Then
                        'MessageBox.Show("New password must include at least one uppercase letter.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                        txtConfirmPass.SelectAll() : txtNewPass.Focus()
                    ElseIf objSecurityRulePW.LowerLetter AndAlso _
                           Not objSecurityRulePW.IsPsswordContainLowerLeter(strNewPW) Then
                        'MessageBox.Show("New password must include at least one lowercase letter.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                    ElseIf objSecurityRulePW.SpecialCharacter AndAlso _
                           Not objSecurityRulePW.IsPsswordContainSpecialChar(strNewPW) Then
                        'MessageBox.Show("New password must include at least one special character (one of these " & objSecurityRulePW.SpeicalCharacters & ").", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                    ElseIf objSecurityRulePW.NumericNumber AndAlso _
                           Not objSecurityRulePW.IsPsswordContainNumber(strNewPW) Then
                        'MessageBox.Show("New password must include at least one number (0-9).", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                    ElseIf strNewPW.Length > objSecurityRulePW.MaxPasswordLength Then
                        MessageBox.Show("New password length is greater than maximum length (" & objSecurityRulePW.MaxPasswordLength & ".", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                    ElseIf strNewPW.Length < objSecurityRulePW.PasswordLength Then
                        'MessageBox.Show("New password length must be at least " & objSecurityRulePW.PasswordLength & ".", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                    ElseIf objSecurityRulePW.IsPsswordUsedBefore(iUserID, strNewPW) Then
                        MessageBox.Show("New password is already used in the last " & objSecurityRulePW.ReuseLastPWMonths & " months. It can't be reused.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtConfirmPass.Text = "" : txtNewPass.SelectAll() : txtNewPass.Focus()
                    Else 'ready to reset PW
                        i = objSecurity.SavePasswordAndPWLog(iUserID, strNewPW)
                        If Not i > 0 Then
                            MessageBox.Show("Failed to update.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtNewPass.SelectAll() : txtNewPass.Focus()
                        Else
                            MessageBox.Show("Your password has been reset.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtUser.Text = txtUserName.Text : txtPass.Text = txtNewPass.Text
                            txtUserName.Text = "" : txtOldPass.Text = ""
                            txtConfirmPass.Text = "" : txtNewPass.Text = ""
                            SetLoginMode()
                            Me.btnLogin_Click(sender, e)
                        End If
                    End If
                End If


                'SetLoginMode()
                'Me.txtUser.Text = Me.txtUserName.Text
                'Me.txtPass.Text = Me.txtConfirmPass.Text

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPassRule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSecurity = Nothing : objSecurityRulePW = Nothing
                '    txtNewPass.Text = "" : txtConfirmPass.Text = ""
                '    txtUserName.SelectAll() : txtUserName.Focus()
            End Try
        End Sub

        Private Sub SecurityWin_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, pnlLogin.MouseMove, lblInfo.MouseMove
            Me.btnPassReset.ForeColor = Color.DimGray
        End Sub

        Private Sub btnPassReset_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPassReset.MouseMove
            Me.btnPassReset.ForeColor = Color.Black
        End Sub

        Private Sub SetResetMode()
            Try
                With Me
                    .pnlLogin.Visible = False
                    .grpBox1.Top = .pnlLogin.Top + 10
                    .grpBox1.Left = .pnlLogin.Left + 10
                    .Width = .grpBox1.Width + 30
                    .Height = .grpBox1.Height + 60
                    .txtUserName.Text = .txtUser.Text
                    .txtOldPass.Text = .txtPass.Text
                    .txtNewPass.Text = ""
                    .txtConfirmPass.Text = ""
                    .grpBox1.Visible = True
                    If .txtOldPass.Text.Trim.Length = 0 Then
                        Me.ActiveControl = .txtOldPass : .txtOldPass.Focus()
                    Else
                        Me.ActiveControl = .txtNewPass : .txtNewPass.Focus()
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "SetResetModel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub
        Private Sub SetLoginMode()
            Try
                Me.pnlLogin.Visible = True
                Me.Width = Me.pnlLogin.Width + 5 : Me.Height = pnlLogin.Height + 30
                Me.grpBox1.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "SetLoginModel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub
        Private Sub CheckEnvironment()
            Dim objDataProc As DBQuery.DataProc
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Me.lblTestNet.Visible = (ConfigFile.Server <> "172.16.25.21")
            ' DISPLAY THE LABLE REPRESENTING THE ENVIRONMENT.
            lblProd.Visible = False
            lblTestNet.Visible = False
            lblDevNet.Visible = False
            Dim _envText As String
            Select Case ConfigFile.Server.ToString()
                'Case "172.16.25.21" : lblProd.Visible = True : lblProd.Top = 16
            Case "172.16.25.79", "172.16.25.74" : lblTestNet.Visible = True ': lblTestNet.Top = 16
                Case "172.16.25.112" : lblDevNet.Visible = True ': lblDevNet.Top = 16
                Case "172.16.25.119" : lblDevNet.Visible = True ': lblDevNet.Top = 16
                Case "172.16.25.95" : lblDevNet.Visible = True
                Case "172.16.25.60" : lblDevNet.Visible = True
                Case "172.16.25.89" : lblDevNet.Visible = True
                Case "172.16.25.134" : lblDevNet.Visible = True
                Case "172.16.25.29" : lblDevNet.Visible = True
                Case "172.16.25.32" : lblDevNet.Visible = True
                    'Case Else
                    '    lblDevNet.Visible = True
            End Select
        End Sub
        Private Sub btnCancelReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelReset.Click
            SetLoginMode()
        End Sub
    End Class
End Namespace
