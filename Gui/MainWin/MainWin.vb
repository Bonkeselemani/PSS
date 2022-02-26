Imports System
Imports System.Threading
Imports System.Drawing
Imports System.Windows
Imports PSS.Data.Production
Imports PSS.Core.[Global]
Imports PSS.Core
Imports PSS.Gui
Imports PSS.Data.Buisness.Security

Namespace Gui.MainWin

    Public Class MainWin
        Inherits System.Windows.Forms.Form

        Private Updater As New AppUpdater()

        Public Shared wrkArea As New WorkArea()
        Public Shared stbMain As New StatusBar()


        Public Sub New()
            MyBase.New()


            If Me.CheckInstance = False Then
                MsgBox("There is already an instance of PSS running." & vbCrLf & "This instance will now exit.", MsgBoxStyle.Information, "Multiple instance.")
                End
            End If

#If Debug Then
            'Commented out by Asif on 11/11/2005
            'PSS.Core.Global.ApplicationUser = New PSS.Rules.Security("pssadmin", "admin@1234!")

            'Added by Asif on 11/11/2005    'Damn! now it is easier to debug the login issues.
            Dim login As New Security.SecurityWin()
            login.ShowDialog()

#Else
            Updater.CleanDirectory()
            If Updater.Update = True Then
                End
            End If

            '**********************
            'Terminate AppStart
            '**********************
            Dim pc As Process
            For Each pc In Process.GetProcessesByName("AppStart")
                pc.Kill()
            Next pc
            '**********************

            Dim login As New Security.SecurityWin()
            login.ShowDialog()
#End If

            InitializeComponent()

#If Not Debug Then
            Me.WindowState = FormWindowState.Maximized
#End If

            '// start an update listner
            'Dim listner As New PSS.Core.UpdateListner()
            'Dim ckt As New Thread(New ThreadStart(AddressOf listner.Run))
            'ckt.Start()

            Me.Text = Me.Text & " [User: " & Trim(ApplicationUser.User) & "]"

            '// fallowing code to prevent menu fliker.
            SetStyle(Forms.ControlStyles.DoubleBuffer, True)
            SetStyle(Forms.ControlStyles.AllPaintingInWmPaint, True)

            '// pool our connection once so things dont load slow on the first time.
            '//PSS.Data.Production.Connection.poolODBCconnection()

        End Sub

        'Private Sub InitializeComponent()
        '    '
        '    'MainWin
        '    '
        '    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        '    Me.ClientSize = New System.Drawing.Size(792, 573)
        '    Me.Font = New System.Drawing.Font("Verdana", 8.5!)
        '    Me.MinimumSize = New System.Drawing.Size(800, 600)
        '    Me.Name = "MainWin"
        '    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        'End Sub



        Private Sub InitializeComponent()

            '// Setup our main document
            Me.MinimumSize = New Size(800, 600)
            Me.Text = Forms.Application.ProductName
            Me.Font = New Font("Verdana", 8.5)
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Dim mnuMain As New Menu()

            Controls.AddRange(New System.Windows.Forms.Control() {wrkArea, mnuMain, stbMain})
            'wrkArea.BackgroundImage = Image.FromFile("D:\Temp\FallColors1.jpg")
            'stbMain.BackgroundImage = Image.FromFile("D:\Temp\FallColors1.jpg")
            'Me.BackgroundImage = Image.FromFile("D:\Temp\FallColors1.jpg")

        End Sub



        Protected Sub EndApp(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs) Handles MyBase.Closing
            Dim objMisc As New Data.Buisness.Security()

            If Disposing = False Then
                If Forms.MessageBox.Show("Are you sure you want to exit?", "Exit", _
                    Forms.MessageBoxButtons.YesNo, Forms.MessageBoxIcon.Question) = DialogResult.No Then
                    e.Cancel = True

                    Exit Sub
                Else
                    '**************************
                    'Reset Last Logon Machine
                    Try
                        If PSS.Core.[Global].ApplicationUser.IDuser > 0 Then
                            If objMisc.ResetLastLogonMachine(PSS.Core.[Global].ApplicationUser.IDuser) = 0 Then
                                Throw New Exception("Reset 'Last Logon Machine' for this user failed. Inform your lead.")
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Gui.MainWin.Main.Exit_Clicked: " & Environment.NewLine & "Error in resetting the 'Last Logon machine'. " & Environment.NewLine & ex.Message, "End App", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try
                    '**************************
                End If
            End If
        End Sub

        '// This will keep us on top of the taskbar
        Private Sub MainWin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            Me.TopMost = True
        End Sub

        Private Sub MainWin_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
            Me.TopMost = False
        End Sub

        Private Function CheckInstance() As Boolean
            Dim p As Process() = Process.GetProcessesByName("PSS.Net")
            Dim bReturn As Boolean = True
            If p.Length <> 1 Then
                bReturn = False
            End If
            p = Nothing
            Return bReturn
        End Function

    End Class
    '//==========================



End Namespace
