Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tcreditcard
        Inherits TableBase

        '//----------------------------------------------------------------------------------------------------
        '// Class Constructor (zero arguments)
        '// Overloaded:	No
        '//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM tcreditcard"
        '	'--- Set up the Connection
        '          _conn = Connection.GetConnection
        '          '_conn = Connection.GetConnection(, 1)   'Pass 1 for replication database connectivity.
        '	'--- Set up the data adapter
        '	_da = GetDataAdapter(strSql, _conn)
        '	'//--- Destroy object

        '          '//Craig Haney
        '          _conn.Close()
        '          _conn.Dispose()
        '          '//Craig Haney

        '	_conn = Nothing
        'End Sub

        'Public Shared Function GetCCbyCustID(ByVal ID As Int32) As DataRow
        '    Dim _conn As MySqlConnection = Connection.GetConnection(, 1)
        '    '_conn.Open()
        '    Dim strSql As String = "SELECT * FROM tcreditcard WHERE Cust_ID = " & ID & ";"
        '    Dim _cmd As New MySqlCommand(strSql, _conn)
        '    Dim _da As New MySqlDataAdapter()
        '    _da.SelectCommand = _cmd
        '    Dim _dt As New DataTable()
        '    _da.Fill(_dt)
        '    _da.Dispose()
        '    _conn.Close()
        '    _cmd.Dispose()
        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney
        '    _conn = Nothing
        '    Return _dt.Rows(0)
        'End Function

    End Class
End Namespace