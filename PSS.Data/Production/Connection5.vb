Option Explicit On 

Imports MySql.Data.MySqlClient

Public Class Connection5
    Private Const strConnectionString As String = "SERVER=172.16.25.19;USER ID=root;PASSWORD=!9724623970;DATABASE=salesorders;allow zero datetime = yes"

    '*************************************************************************
    Public Shared Function GetDataTable(ByVal strSql As String) As DataTable
        Dim _conn As New MySqlConnection()
        Dim _da As New MySqlDataAdapter()
        Dim _dt As New DataTable()
        Dim _cmd As MySqlCommand

        Try
            _conn.ConnectionString = strConnectionString
            _conn.Open()
            _cmd = New MySqlCommand(strSql, _conn)
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
                If _conn.State.Open = ConnectionState.Open Then
                    _conn.Close()
                End If
                _conn.Dispose()
                _conn = Nothing
            End If
        End Try
    End Function

    '*************************************************************************
    Public Shared Function ExecuteNonQueries(ByVal strSql As String) As Integer
        Dim i As Integer = 0
        Dim _conn As New MySqlConnection()
        Dim _da As New MySqlDataAdapter()
        Dim _cmd As New MySqlCommand()

        Try
            _conn.ConnectionString = strConnectionString
            _conn.Open()
            _cmd.Connection = _conn
            _cmd.CommandText = strSql
            _da.InsertCommand = _cmd
            i = _da.InsertCommand.ExecuteNonQuery()
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
                If _conn.State.Open = ConnectionState.Open Then
                    _conn.Close()
                End If
                _conn.Dispose()
                _conn = Nothing
            End If
        End Try

        Return i
    End Function

    '*************************************************************************

End Class
