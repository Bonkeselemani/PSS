Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tshipto
        Inherits TableBase


        '      '//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM tshipto"
        '	'--- Set up the Connection
        '	_conn = Connection.GetConnection
        '	'--- Set up the data adapter
        '	_da = GetDataAdapter(strSql, _conn)
        '	'//--- Destroy object

        '          '//Craig Haney
        '          _conn.Close()
        '          _conn.Dispose()
        '          '//Craig Haney

        '	_conn = Nothing
        'End Sub

        'Public Shared Function GetRowByPK(ByVal pkVAL As Int32) As DataRow
        '    Dim _conn As MySqlConnection = Nothing
        '    _conn = Connection.GetConnection
        '    Dim strSql As String = "SELECT * FROM tshipto WHERE ShipTo_ID = " & pkVAL
        '    Dim _cmd As New MySqlCommand(strSql, _conn)
        '    Dim _da As New MySqlDataAdapter()
        '    _da.SelectCommand = _cmd
        '    Dim _dt As New DataTable()
        '    _da.Fill(_dt)
        '    Dim _dr As DataRow
        '    _dr = _dt.Rows(0)
        '    _da.Fill(_dt)
        '    _da.Dispose()
        '    _cmd.Dispose()
        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney
        '    _conn = Nothing
        '    Return _dr
        'End Function

    End Class
End Namespace