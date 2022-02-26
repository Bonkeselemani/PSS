'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports Microsoft.Data.Odbc

'Namespace Production
'    Public Class Connection

'        'Real Servere
'        Public Const _server As String = "172.16.25.21"                 'Production Server
'        Public Const _ReplServer1 As String = "172.16.25.21"             'Replication Server 1
'        Public Const _ReplServer2 As String = "172.16.25.21"           'Replication Server 2

'        ''Testing Server
'        'Public Const _server As String = "172.16.25.156"                 'Production Server
'        'Public Const _ReplServer1 As String = "172.16.25.156"             'Replication Server 1
'        'Public Const _ReplServer2 As String = "172.16.25.156"           'Replication Server 2

'        'Public Const _server As String = "172.16.25.64"                 'Production Server
'        'Public Const _ReplServer1 As String = "172.16.25.64"             'Replication Server 1
'        'Public Const _ReplServer2 As String = "172.16.25.64"           'Replication Server 2

'        Private Const _ReplPath1 As String = "\\svr_pssiusr\Reports\PSSInet_Reports_Repl1\"
'        Private Const _ReplPath2 As String = "\\svr_pssiusr\Reports\PSSInet_Reports_Repl2\"

'        Public Shared strServer As String = ""
'        Public Const _user As String = "apuser"
'        Public Const _pass As String = "Asd@321"
'        Private Const _ReplUser As String = "apuser"
'        Private Const _Replpass As String = "Asd@321"
'        Private Const _smtpServer As String = "svr_pssimail"
'        Private Const _MailFrom As String = "itnotifications@productsupportservices.com"
'        Private Const _MailTo As String = "it@productsupportservices.com"

'        Private Shared _arrlstConnInfo As ArrayList

'        '//*****************************************************************************
'        '(1)This method returns a connection.
'        '(2)It takes two optional parameters one is database name and the other is serverID.
'        '(3)For Production database use ServerID = 0 which is the default value and don't 
'        '   have to pass this value explicitly.
'        '(4)If you want to use a replication database pass ServerID = 1 (For replication db 1) and
'        '   ServerID = 2 (For replication db 2) "explicitly".
'        '(5)If you want to use production database it creates a connection straight up.
'        '(6)But if you want to use a replication database it returns a connection to the 
'        '   first available good Replication database after checking its status.
'        '//*******************************************************************************
'        Public Shared Function GetConnection(Optional ByVal database As String = "Production", _
'                                    Optional ByVal iServerID As Integer = 0) As MySqlConnection

'            Dim objConnect As New CONN._Connection()
'            Dim i As Integer = 0
'            Dim objMySQLConn As MySqlConnection

'            Try
'                If Not IsNothing(_arrlstConnInfo) Then
'                    strServer = SetVariables(objConnect)
'                    objMySQLConn = objConnect.GetConnection

'                    Return objMySQLConn 'objConnect.GetConnection
'                Else
'                    Select Case iServerID
'                        Case 0      'Production Database
'                            SetVariables(_server, database, _user, _pass, objConnect)
'                            strServer = _server
'                            Return objConnect.GetConnection

'                        Case Else      'Any of the replicated databases
'                            SetVariables(_ReplServer1, database, _user, _pass, objConnect)
'                            strServer = _server
'                            Return objConnect.GetConnection
'                    End Select
'                End If
'            Catch ex As Exception
'                Throw ex
'            Finally
'                'objConnect = Nothing

'                GC.Collect()
'                GC.WaitForPendingFinalizers()
'                GC.Collect()
'                GC.WaitForPendingFinalizers()
'            End Try

'            ''''On Error Resume Next
'            ''''**********************************************
'            ''''Check if Replication Server 1 is available
'            ''''**********************************************
'            '''SetVariables(_ReplServer1, database, _ReplUser, _Replpass, objConnect)
'            '''i = objConnect.CheckServerStatus        'for Slave servers only
'            '''If i <> 0 Then  'means replication encountered errors
'            '''    '**********************************************
'            '''    'Send an email to DB Admins
'            '''    SendEmailNotification("Replication Failure!", "Replication of Production database on server (" & _ReplServer1 & ") failed approximately at " & Now & ".")
'            '''    '**********************************************
'            '''    'if Replication Server 1 is not available then
'            '''    'Check if Replication Server 2 is available
'            '''    '**********************************************
'            '''    i = 0
'            '''    SetVariables(_ReplServer2, database, _ReplUser, _Replpass, objConnect)
'            '''    i = objConnect.CheckServerStatus    'for Slave servers only
'            '''    If i <> 0 Then  'means replication encountered errors
'            '''        '**********************************************
'            '''        'Send an email to DB Admins
'            '''        SendEmailNotification("Replication Failure!", "Replication of Production database on server (" & _ReplServer2 & ") failed approximately at " & Now & ".")
'            '''        '**********************************************
'            '''        'if both the slave servers are not available then
'            '''        'use the production server
'            '''        '**********************************************
'            '''        SetVariables(_server, database, _user, _pass, objConnect)
'            '''        strServer = _server
'            '''        Return objConnect.GetConnection
'            '''    Else
'            '''        SetVariables(_ReplServer2, database, _user, _pass, objConnect)
'            '''        strServer = _ReplServer2
'            '''        Return objConnect.GetConnection
'            '''    End If
'            '''    '**********************************************
'            '''Else    'means replication on the first replication server is fine
'            '''    SetVariables(_ReplServer1, database, _user, _pass, objConnect)
'            '''    strServer = _ReplServer1
'            '''    Return objConnect.GetConnection
'            '''End If


'            '''    Case 2      'Replication Server 2. This is to be used just by IT. IP: 172.16.25.154
'            '''        SetVariables(_ReplServer2, database, _ReplUser, _Replpass, objConnect)
'            '''        i = objConnect.CheckServerStatus    'for Slave servers only
'            '''        If i = 0 Then  'means replication encountered errors
'            '''            SetVariables(_ReplServer2, database, _user, _pass, objConnect)
'            '''            strServer = _ReplServer2
'            '''            Return objConnect.GetConnection
'            '''        Else
'            '''            MsgBox("Replication database (" & _ReplServer2 & ") is not available.")
'            '''        End If
'            '''End Select

'            'objConnect = Nothing
'        End Function

'        '*******************************************************************************
'        Private Shared Sub SetVariables(ByVal strServer As String, _
'                                        ByVal strDB As String, _
'                                        ByVal strUser As String, _
'                                        ByVal strPWD As String, _
'                                        ByRef objConnect As Object)
'            With objConnect
'                ._Server = strServer
'                ._Database = strDB
'                ._User = strUser
'                ._Password = strPWD
'            End With
'        End Sub

'        Private Shared Function SetVariables(ByVal objConnect As Object) As String
'            ' SetConnInfo MUST be called prior to this
'            Dim i As Integer
'            Dim enumerator As IEnumerator
'            Dim objCurrent As Object
'            Dim strServer As String = ""

'            If Not IsNothing(_arrlstConnInfo) Then
'                enumerator = _arrlstConnInfo.GetEnumerator

'                While enumerator.MoveNext()
'                    objCurrent = enumerator.Current()

'                    Select Case objCurrent(0).ToString
'                        Case "server"
'                            objConnect._Server = objCurrent(1).ToString
'                            strServer = objCurrent(1).ToString
'                        Case "database"
'                            objConnect._Database = objCurrent(1).ToString
'                        Case "user"
'                            objConnect._User = objCurrent(1).ToString
'                        Case "password"
'                            objConnect._Password = objCurrent(1).ToString
'                    End Select
'                End While
'            End If

'            Return strServer
'        End Function

'        '******************************************************************************
'        '''Public Shared Function CheckServerStatus(ByVal strServerIP As String) As Integer
'        '''    Dim objConnect As New CONN._Connection()
'        '''    Dim strDB As String = "Production"

'        '''    SetVariables(strServerIP, strDB, _ReplUser, _Replpass, objConnect)
'        '''    Return objConnect.CheckServerStatus        'for Slave servers only

'        '''    objConnect = Nothing
'        '''End Function

'        '******************************************************************************
'        Public Shared Function GetRptPath() As String
'            'Dim i As Integer = 0
'            'Dim ReportPath As String = ""

'            '''i = CheckServerStatus(_ReplServer2)

'            '''If i = 0 Then  'means replication has no errors
'            '''    ReportPath = _ReplPath2                 '"\\svr_pssiusr\Reports\PSSInet_Reports_Repl2\"    '154
'            '''Else
'            '''    i = 0
'            '''    i = Production.Connection.CheckServerStatus(Production.Connection._ReplServer1)
'            '''    If i = 0 Then  'means replication has no errors
'            '''        ReportPath = _ReplPath1             '"\\svr_pssiusr\Reports\PSSInet_Reports_Repl1\"
'            '''    Else
'            '''        MsgBox("Both replications failed.", MsgBoxStyle.Information)
'            '''        '    ReportPath = "\\svr_pssiusr\Reports\PSSInet_Reports_Prod\"
'            '''    End If
'            '''End If

'            Return _ReplPath1
'        End Function

'        '******************************************************************************
'        Private Shared Sub SendEmailNotification(ByVal strSubject As String, ByVal strBody As String)
'            On Error Resume Next
'            Dim ObjLib As New MyLib.VBNETMAIL()
'            Dim i As Integer = 0

'            With ObjLib
'                .SMTPServer = _smtpServer
'                .MailFrom = _MailFrom
'                .MailTo = _MailTo
'                .Subject = strSubject
'                .Body = strBody
'                i = .SendMail
'            End With

'            ObjLib = Nothing

'        End Sub

'        '******************************************************************************
'        Public Shared Sub SetConnInfo(ByVal arrlstInfo As ArrayList)
'            _arrlstConnInfo = arrlstInfo
'        End Sub

'        '******************************************************************************

'    End Class
'End Namespace