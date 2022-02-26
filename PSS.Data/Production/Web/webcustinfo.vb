Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    'Public Class webcustinfo

    '    'Inherits TableBase

    '    '//----------------------------------------------------------------------------------------------------
    '    '// Class Constructor (zero arguments)
    '    '// Overloaded:	No
    '    '//----------------------------------------------------------------------------------------------------

    '    'Public Shared Function GenericSelect(ByVal sSQL As String) As DataTable
    '    '    _conn = Connection.GetConnection("web")
    '    '    Dim strSql As String = sSQL
    '    '    Dim _cmd As New MySqlCommand(strSql, _conn)
    '    '    Dim _da As New MySqlDataAdapter()
    '    '    _da.SelectCommand = _cmd
    '    '    Dim _dt As New DataTable()
    '    '    _da.Fill(_dt)
    '    '    _da.Dispose()
    '    '    _cmd.Dispose()
    '    '    '//Craig Haney
    '    '    _conn.Close()
    '    '    _conn.Dispose()
    '    '    '//Craig Haney
    '    '    _conn = Nothing
    '    '    Return _dt
    '    'End Function

    '    Public Shared Function GenericInsert(ByVal sSQL As String) As Boolean
    '        Dim objDataProc As DBQuery.DataProc

    '        Try
    '            Dim _conn As MySqlConnection = Connection.GetConnection("web")
    '            Dim strSQL As String = sSQL
    '            Dim cmd1 As New MySqlCommand(strSQL, _conn)
    '            '_conn.Open()
    '            cmd1.ExecuteNonQuery()
    '            '//Craig Haney
    '            _conn.Close()
    '            _conn.Dispose()
    '            '//Craig Haney
    '            _conn = Nothing
    '            Return True
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    End Function


    '    Public Function idTrans(ByVal SQL As String, ByVal tName As String) As Int32

    '        Dim oTrans As MySqlTransaction
    '        Dim iReturn As Int32

    '        Try
    '            _conn = Connection.GetConnection("web")
    '            '_conn.Open()
    '            Dim _cmd1 As New MySqlCommand(SQL, _conn)
    '            oTrans = _conn.BeginTransaction(IsolationLevel.Serializable)
    '            _cmd1.Transaction = oTrans

    '            _cmd1.ExecuteNonQuery()

    '            _cmd1 = New MySqlCommand("SELECT LAST_INSERT_ID() FROM " & tName & ";", _conn)
    '            _cmd1.Transaction = oTrans

    '            Dim _rdr As MySqlDataReader = _cmd1.ExecuteReader
    '            Do While _rdr.Read
    '                iReturn = _rdr(0)
    '                'Added code to prevent large amount of unnecessary looping
    '                If Len(iReturn) > 0 Then Exit Do
    '            Loop

    '            _rdr.Close()
    '            _cmd1.Dispose()

    '            oTrans.Commit()

    '            '//Craig Haney
    '            _conn.Close()
    '            _conn.Dispose()
    '            '//Craig Haney
    '        Catch exp As MySqlException
    '            MsgBox(exp.ToString)
    '            Throw exp
    '            oTrans.Rollback()
    '            iReturn = 0
    '        End Try

    '        Return iReturn
    '    End Function

    'End Class

End Namespace



