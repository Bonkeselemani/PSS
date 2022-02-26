Imports Microsoft.Win32
Imports Microsoft.Win32.Registry

Namespace Core

    Public Class Registry

        Protected Shared RegPath As String = Application.ProductName & "\" & Application.ProductVersion

        Public Shared Sub SetKey(ByVal Key As String, ByVal Value As String)
            Dim oKey As RegistryKey
            Try
                oKey = CurrentUser.OpenSubKey(RegPath, True)
                oKey.SetValue(Key, Value)
                oKey.Close()
            Catch exp As System.Exception
                oKey = CurrentUser.CreateSubKey(RegPath)
                oKey.SetValue(Key, Value)
                oKey.Close()
            End Try
        End Sub

        Public Shared Function GetKey(ByVal Key As String) As String
            Dim oKey As RegistryKey
            Dim iReturn As String = ""
            Try
                oKey = CurrentUser.OpenSubKey(RegPath, False)
                iReturn = oKey.GetValue(Key)
                oKey.Close()
            Catch exp As System.Exception
            End Try
            Return iReturn
        End Function

        Public Shared Sub SetUpRegistry()
            Dim oKey As RegistryKey
            oKey = CurrentUser.CreateSubKey(RegPath)
            oKey.SetValue("FirstRun", False)
            oKey.Close()
        End Sub

    End Class

End Namespace
