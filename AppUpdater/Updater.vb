Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Class AppUpdater

    Private uPath As String = "N:\PSS_Rel_Win7\"
    Private uDir As String = ""
    Dim stat As New StatusWin()

    Public Function Update() As Boolean
        stat.Show()
        stat.Label1.Text = stat.Label1.Text & vbCrLf & "This will take a few moments."
        Application.DoEvents()
        Dim dir As DirectoryInfo = New DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
        Dim files As FileInfo() = dir.GetFiles
        Dim uFile As FileInfo, weUpdated As Boolean = False
        For Each uFile In files
            If uFile.Extension = ".exe" Or uFile.Extension = ".dll" Or uFile.Extension = ".config" Then
                If HasUpdate(uFile.Name) = True Then
                    weUpdated = True
                End If
            End If
            uFile = Nothing
        Next
        dir = Nothing
        files = Nothing
        uFile = Nothing
        If weUpdated = True Then
            stat.Label1.Text = "Downloading updates."
            Application.DoEvents()
            GetUpDate()
            stat.Label1.Text = "Update complete." & vbCrLf & "Starting up PSS.Net."
            stat.Close()
            MsgBox("PSS.Net will now close. You must restart PSS.Net in order for the changes to take effect.", MsgBoxStyle.Information, "Update Complete")
            Application.DoEvents()
            Return True
        End If
        stat.Label1.Text = "Starting up PSS.Net."
        Application.DoEvents()
        stat.Close()
        Return False
    End Function

    Private Sub GetUpDate()
        CreateNewDir()
        Dim dir As DirectoryInfo = New DirectoryInfo(uPath)
        Dim files As FileInfo() = dir.GetFiles
        Dim uFile As FileInfo, weUpdated As Boolean
        For Each uFile In files
            If uFile.Extension = ".exe" Or uFile.Extension = ".dll" Or uFile.Extension = ".config" Then
                uFile.CopyTo(uDir & uFile.Name, True)
            End If
        Next
        stat.Label1.Text = "Merging Directories."
        Application.DoEvents()
        MergeDirectory() '// we do this to get the support files that we did not update
        stat.Label1.Text = "Updating Configuration."
        Application.DoEvents()
        UpdateConfig()
    End Sub

    Private Sub MergeDirectory()
        Dim dir As DirectoryInfo = New DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
        Dim files As FileInfo() = dir.GetFiles
        Dim mFile As FileInfo
        For Each mFile In files
            If File.Exists(uDir & mFile.Name) = False Then
                mFile.CopyTo(uDir & mFile.Name, True)
            End If
        Next
    End Sub

    Private Function Version(ByVal file As String) As Version
        Try
            Return AssemblyName.GetAssemblyName(file).Version
        Catch e As Exception
            Return New Version(1, 0, 0, 0)
        End Try
    End Function

    Private Function HasUpdate(ByVal file As String) As Boolean
        If Version(file).Major < Version(uPath & file).Major Then
            Return True
        ElseIf Version(file).Minor < Version(uPath & file).Minor Then
            Return True
        ElseIf Version(file).Revision < Version(uPath & file).Revision Then
            Return True
        ElseIf Version(file).Build < Version(uPath & file).Build Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CreateNewDir()
        If Directory.Exists("..\" & Version(uPath & "PSS.Net.exe").ToString) = False Then
            Directory.CreateDirectory("..\" & Version(uPath & "PSS.Net.exe").ToString)
        End If
        uDir = "..\" & Version(uPath & "PSS.Net.exe").ToString & "\"
    End Sub

    Private Sub UpdateConfig()
        Dim ds As New DataSet()
        ds.ReadXml("..\AppStart.Config")
        ds.Tables(0).Rows(0)(0) = Version(uPath & "PSS.Net.exe")
        ds.AcceptChanges()
        ds.WriteXml("..\AppStart.Config")
    End Sub

    Public Sub CleanDirectory()
        Dim ds As New DataSet()
        ds.ReadXml("..\AppStart.Config")
        Dim cDir As String = ds.Tables(0).Rows(0)(0)
        ds.Dispose()
        Dim dir As DirectoryInfo = New DirectoryInfo("..\")
        Dim dirs As DirectoryInfo() = dir.GetDirectories
        Dim dDir As DirectoryInfo
        For Each dDir In dirs
            If dDir.Name <> cDir Then
                Try
                    dDir.Delete(True)
                Catch e As Exception
                    'if we cant delete it then leave it
                End Try
            End If
        Next
        dir = Nothing
        dirs = Nothing
    End Sub

End Class

