Imports System
Imports System.Data
Imports System.IO

Namespace BaseClasses
    'Collect program tracking and log information
    Public Class CollectTrackingLog
        'Private _objDataProc As DBQuery.DataProc
        Private _objDataProc As MySql4.DataProc

        Public Sub New()
            Try
                _objDataProc = New MySql4.DataProc(ConfigFile.GetConnectionInfo)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function GetComputerName() As String
            Dim sMachine As String = ""
            Try
                sMachine = System.Net.Dns.GetHostName

                Return sMachine
            Catch ex As Exception
                Return sMachine
            End Try
        End Function

        Public Function GetComputerIP(ByVal PCName As String) As String
            Dim sIP As String = ""

            If Not PCName.Trim.Length > 0 Then Return ""

            Dim ipE As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(PCName)
            Dim IpA As System.Net.IPAddress() = ipE.AddressList
            Dim i As Integer

            Try
                For i = 0 To IpA.Length - 1
                    sIP = sIP & IpA(i).ToString
                Next

                Return sIP
            Catch ex As Exception

                Return sIP
            End Try
        End Function

        Public Function GetWindowsUser() As String
            Dim sWinUser As String = ""
            Try
                sWinUser = Environment.UserName()

                Return sWinUser
            Catch ex As Exception
                Return sWinUser
            End Try
        End Function

        Public Function GetDOTNETVersion() As String
            Dim sVer As String = ""
            Try
                sVer = Environment.Version().ToString
                Return sVer
            Catch ex As Exception
                Return sVer
            End Try
        End Function


        Public Sub SaveTrackingLogInfo(ByVal strPssNetUser As String, ByVal strPssNetVer As String, Optional ByVal strComments As String = "")
            Dim strSql As String = ""
            Dim strPCName As String = GetComputerName()
            Dim strIP As String = GetComputerIP(strPCName)
            Dim strWinUser As String = GetWindowsUser()
            Dim strDotNetVer As String = GetDOTNETVersion()
            Dim strDBServer As String = getDatabaseIP() '"" '= ConfigFile.GetConnectionInfo
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim i As Integer
            Dim dDate As Date

            Dim iKeepLogDays As Integer = 180 'lod data will be deleted after 180 days

            Try

                'For i = 0 To ConfigFile.GetConnectionInfo.Count - 1
                '    strDBServer &= ConfigFile.GetConnectionInfo.Item(i)
                'Next

                'Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                'FAILED HERE

                strSql = "INSERT INTO tracker.pssnet_log (ComputerName,IP,WindowUser,PSSNETUser,PSSNETVersion,NETFramework,DBServer,Date,Comments)" & Environment.NewLine
                strSql &= " VALUES (" & Environment.NewLine
                strSql &= "'" & strPCName & "'," & Environment.NewLine
                strSql &= "'" & strIP & "'," & Environment.NewLine
                strSql &= "'" & strWinUser & "'," & Environment.NewLine
                strSql &= "'" & strPssNetUser & "'," & Environment.NewLine
                strSql &= "'" & strPssNetVer & "'," & Environment.NewLine
                strSql &= "'" & strDotNetVer & "'," & Environment.NewLine
                strSql &= "'" & strDBServer & "'," & Environment.NewLine
                strSql &= "'" & strDate & "'," & Environment.NewLine
                strSql &= "'" & strComments & "')" & Environment.NewLine

                'Dim tmpS As String = ConfigFile.GetConnectionInfo.Count
                'Dim aItem As ArrayList, myItem As String, j As Integer = 0, k As Integer = 0
                'For Each aItem In ConfigFile.GetConnectionInfo
                '    j += 1 : k = 0
                '    tmpS &= vbCrLf & "Parent ArrayList Item " & j & ":   "
                '    For Each myItem In aItem
                '        k += 1
                '        tmpS &= "  Child ArrayList Item " & k & ": " & myItem
                '    Next
                'Next
                'tmpS &= vbCrLf
                'AppendText2File("Sub SaveTrackingLogInfo: 1" & vbCrLf & strSql & vbCrLf & tmpS)

                'i = Me._objDataProc.ExecuteNonQuery(strSql)

                Me._objDataProc.ExecuteNonQuery(strSql)


                'delete if any------------------------------------------------------------------------
                dDate = Now.AddDays(-iKeepLogDays)
                strDate = Format(dDate, "yyyy-MM-dd")
                strSql = "DELETE FROM tracker.pssnet_log WHERE Date < '" & strDate & "';"
                Me._objDataProc.ExecuteNonQuery(strSql)

                'AppendText2File("Sub SaveTrackingLogInfo: 2  i=" & i & vbCrLf & strSql)
            Catch ex As Exception
                'AppendText2File("Sub SaveTrackingLogInfo: 3  i=" & i & vbCrLf & strSql & ex.ToString)
                Throw ex
            End Try
        End Sub

        Private Function getDatabaseIP() As String
            Dim strSql As String = ""
            Dim dTB As DataTable, row As DataRow
            Dim Res As String = ""
            Try
                'Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SHOW VARIABLES;"
                dTB = Me._objDataProc.GetDataTable(strSql)

                For Each row In dTB.Rows
                    If row.Item("variable_name") = "log_error" Then
                        Res = row.Item("value")
                        Res = Res.Replace(".err", "")
                        Res = Res.Replace(".\", "")
                        Res = Res & " " & GetComputerIP(Res)
                        Exit For
                    End If
                Next

                Return Res
            Catch ex As Exception
                Return Res
            End Try

        End Function

        Private Sub AppendText2File(ByVal strText As String)
            'Z Fang: for debug text to be saved (output) to a text file,
            'I hate there are no messagebox available in some classes 
            'Now, it makes debug messages easier and controlable.
            Dim strProcessedPathFile As String
            Dim fs As IO.FileStream = Nothing
            Dim sw As IO.StreamWriter

            Dim path As String
            path = System.IO.Path.GetDirectoryName( _
               System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\", "")
            strProcessedPathFile = path & "\PSSNET_Debug.txt"

            If (Not IO.File.Exists(strProcessedPathFile)) Then
                Try
                    fs = IO.File.Create(strProcessedPathFile)
                    sw = IO.File.AppendText(strProcessedPathFile)
                    sw.WriteLine(strText)
                    sw.Close()
                Catch ex As Exception
                    '  MsgBox("Error Creating Log File")
                End Try
            Else
                sw = IO.File.AppendText(strProcessedPathFile)
                sw.WriteLine(strText)
                sw.Close()
            End If

        End Sub

    End Class
End Namespace
