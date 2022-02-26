Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Core
    Public Class Highlight

        '//==========================
        '//     Function: SetHighlight
        '//     Call: PSS.Core.HighLight.SetHighLight(Me)
        '//     Explanation: will set highlight of all controls
        '//         in a form: call in the load event; me = the 
        '//         form your calling.
        '//==========================


        Private Shared ctl As Control
        Private Shared ctls As Control
        Private Shared HighLightColor As Color = Color.Yellow
        Private Shared WindowColor As Color = SystemColors.Window
        Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
        Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

        Public Shared Sub SetHighLight(ByVal sender As Form)
            For Each ctl In sender.Controls
                Recurse(ctl)
            Next
        End Sub

        Private Shared Sub Recurse(ByVal c As Control)
            For Each ctl In c.Controls
                If c.Controls.Count > 0 Then
                    For Each ctls In c.Controls
                        Recurse(ctl)
                    Next
                End If
                SetHandler(ctl) 'handles control base level controls
            Next
            SetHandler(ctl) 'hadles base level controls
        End Sub

        Private Shared Sub SetHandler(ByVal ctl As Control)
            AddHandler ctl.Enter, EnterHandler
            AddHandler ctl.Leave, LeaveHandler
            AddHandler ctl.Click, EnterHandler
        End Sub

        Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, HighLightColor)
        End Sub

        Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, WindowColor)
        End Sub

        Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
            Dim Type As String = sender.GetType.Name.ToString
            Select Case Type
                Case "ComboBox"
                    CType(sender, ComboBox).BackColor = color
                Case "TextBox"
                    CType(sender, TextBox).BackColor = color
                Case Else
                    'no other types should be hightlighted.
            End Select
        End Sub

    End Class
End Namespace