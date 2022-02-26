Option Explicit On 

Imports eInfoDesigns.dbProvider.MySqlClient
Imports System
Imports System.Collections
Imports System.Data
Imports System.Windows.Forms

Namespace MySql4
    Public Class DataProc
        Private _arrlstConnInfo As ArrayList
        Public _bVariablesSet As Boolean = False
        Private _Server As String = ""
        Private _Database As String = ""
        Private _User As String = ""
        Private _Password As String = ""

        '********************************************************************
        Public Sub New(ByVal arrlstConnInfo As ArrayList)
            Try
                SetConnectionInfo(arrlstConnInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************
        ' /* Password MUST be decrypted */
        Public Sub New(ByVal strServer As String, ByVal strDB As String, ByVal strUser As String, ByVal strPW As String)
            Try
                SetConnectionInfo(strServer, strDB, strUser, strPW)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        '********************************************************************
        Private Sub SetConnectionInfo(ByVal arrlstConnInfo As ArrayList)
            Try
                _arrlstConnInfo = arrlstConnInfo
                _bVariablesSet = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************
        ' /* Password MUST be decrypted */
        Private Sub SetConnectionInfo(ByVal strServer As String, ByVal strDB As String, _
                                            ByVal strUser As String, ByVal strPW As String)

            Dim arrlstTemp As ArrayList
            Dim i As Integer

            Try
                _arrlstConnInfo = New ArrayList(4)

                For i = 1 To 4

                    arrlstTemp = New ArrayList(2)

                    Select Case i
                        Case 1
                            arrlstTemp.Add("server")
                            arrlstTemp.Add(strServer)
                        Case 2
                            arrlstTemp.Add("database")
                            arrlstTemp.Add(strDB)

                        Case 3
                            arrlstTemp.Add("user")
                            arrlstTemp.Add(strUser)
                        Case 4
                            arrlstTemp.Add("password")
                            arrlstTemp.Add(strPW)
                    End Select
                    _arrlstConnInfo.Add(arrlstTemp)
                Next i

                _bVariablesSet = False

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function GetConnString() As String
            Try
                Return "SERVER=" & Me._Server & _
                                   ";USER ID=" & Me._User & _
                                   ";PASSWORD=" & Me._Password & _
                                   ";DATABASE=" & Me._Database & _
                                   ";allow zero datetime = yes"

                'Return "SERVER=172.16.25.21;USER ID=apuser;PASSWORD=Asd@321;DATABASE=production" & _
                '                   ";allow zero datetime = yes"
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Private Sub SetVariables()
            '// SetConnInfo MUST be called prior to this
            Dim enumerator As IEnumerator = Nothing
            Dim arrlstCurrent As ArrayList = New ArrayList(2)

            Try
                If Not IsNothing(_arrlstConnInfo) Then
                    enumerator = _arrlstConnInfo.GetEnumerator()
                    While (enumerator.MoveNext())

                        arrlstCurrent = enumerator.Current

                        Select Case (arrlstCurrent(0).ToString())
                            Case "server"
                                _Server = arrlstCurrent(1).ToString()
                            Case "database"
                                _Database = arrlstCurrent(1).ToString()
                            Case "user"
                                _User = arrlstCurrent(1).ToString()
                            Case "password"
                                _Password = arrlstCurrent(1).ToString()
                        End Select
                    End While
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************
        Private Function GetConnection() As MySqlConnection
            Dim _conn As New MySqlConnection()
            Dim strConn As String = ""

            Try
                If _bVariablesSet = False Then
                    SetVariables()
                    _bVariablesSet = True
                End If

                strConn = Me.GetConnString

                _conn.ConnectionString = strConn

                _conn.Open()

                Return _conn

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetDataRow(ByVal strSQL As String) As DataRow
            Dim drRet As DataRow = Nothing
            Dim dt As DataTable = Nothing

            Try
                dt = GetDataTable(strSQL)

                If (dt.Rows.Count > 0) Then drRet = dt.Rows(0)

                Return drRet
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************
        Public Function GetDataTable(ByVal strSQL As String) As DataTable
            Dim _conn As MySqlConnection = New MySqlConnection()
            Dim _da As MySqlDataAdapter = New MySqlDataAdapter()
            Dim _cmd As MySqlCommand = Nothing
            Dim _dt As DataTable = New DataTable()

            Try
                _conn = GetConnection()

                _cmd = New MySqlCommand(strSQL, _conn)
                _da.SelectCommand = _cmd
                _da.Fill(_dt)
                Return _dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(_cmd) Then
                    _cmd.Dispose()
                    _cmd = Nothing
                End If

                If Not IsNothing(_da) Then
                    _da.Dispose()
                    _da = Nothing
                End If

                If Not IsNothing(_conn) Then
                    If (_conn.State = ConnectionState.Open) Then _conn.Close()

                    _conn.Dispose()
                    _conn = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function ExecuteNonQuery(ByVal strSQL As String) As Integer
            Dim i As Integer = 0
            Dim _conn As MySqlConnection = New MySqlConnection()
            Dim _cmd As MySqlCommand = Nothing

            Try
                _conn = GetConnection()
                _cmd = New MySqlCommand(strSQL, _conn)

                i = _cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(_cmd) Then
                    _cmd.Dispose()
                    _cmd = Nothing
                End If

                If Not IsNothing(_conn) Then
                    If (_conn.State = ConnectionState.Open) Then _conn.Close()

                    _conn.Dispose() : _conn = Nothing
                End If
            End Try

            Return i
        End Function

        '********************************************************************
        Public Function idTransaction(ByVal strSQL As String, ByVal strTable As String) As Integer
            Dim _conn As MySqlConnection = New MySqlConnection()
            Dim oTrans As MySqlTransaction = Nothing
            Dim iReturn As Integer = 0
            Dim _cmd1 As MySqlCommand = Nothing
            Dim _rdr As MySqlDataReader = Nothing

            Try
                _conn = GetConnection()
                _cmd1 = New MySqlCommand(strSQL, _conn)
                oTrans = _conn.BeginTransaction(IsolationLevel.Serializable)
                _cmd1.Transaction = oTrans
                _cmd1.ExecuteNonQuery()

                strSQL = "SELECT LAST_INSERT_ID() " + Environment.NewLine
                strSQL += "FROM " + strTable

                _cmd1 = New MySqlCommand(strSQL, _conn)
                _cmd1.Transaction = oTrans

                _rdr = _cmd1.ExecuteReader()

                While (_rdr.Read())
                    iReturn = Convert.ToInt32(_rdr(0).ToString())

                    '// Added code to prevent large amount of unnecessary looping
                    If (iReturn > 0) Then Exit While
                End While

                oTrans.Commit()

            Catch exp As MySqlException
                Throw exp
                oTrans.Rollback()
                iReturn = 0

            Finally
                If Not IsNothing(_cmd1) Then
                    _cmd1.Dispose()
                    _cmd1 = Nothing
                End If

                If Not IsNothing(_rdr) Then
                    _rdr.Close()
                    _rdr = Nothing
                End If

                If Not IsNothing(oTrans) Then oTrans = Nothing

                If Not IsNothing(_conn) Then
                    If (_conn.State = ConnectionState.Open) Then _conn.Close()

                    _conn.Dispose()
                    _conn = Nothing
                End If
            End Try

            Return iReturn
        End Function

        '********************************************************************
        Public Function GetDoubleValue(ByVal strSQL As String) As Double
            Dim dblRet As Double = 0
            Dim strRet As String = ""

            Try
                strRet = GetSingletonString(strSQL)

                If (IsNumeric(strRet)) Then dblRet = Convert.ToDouble(strRet)

                Return dblRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetLongValue(ByVal strSQL As String) As Long
            Dim lRet As Long = 0
            Dim strRet As String = ""
            Try
                strRet = GetSingletonString(strSQL)

                If (IsNumeric(strRet)) Then
                    lRet = Convert.ToInt64(strRet)
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return lRet
        End Function

        '********************************************************************
        Public Function GetIntValue(ByVal strSQL As String) As Integer
            Dim iRet As Integer = 0
            Dim strRet As String = ""

            Try
                strRet = GetSingletonString(strSQL)

                If (IsNumeric(strRet)) Then iRet = Convert.ToInt32(strRet)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetSingletonString(ByVal strSQL As String) As String
            Dim dt As DataTable = Nothing
            Dim dr As DataRow = Nothing
            Dim strRet As String = ""

            Try
                dt = GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    If (dt.Rows.Count > 0) Then
                        dr = dt.Rows(0)

                        If Not IsDBNull(dr(0)) Then strRet = dr(0).ToString()
                    End If
                End If

                Return strRet
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************

    End Class
End Namespace