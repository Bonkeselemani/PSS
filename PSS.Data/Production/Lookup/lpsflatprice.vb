'Imports System
'Imports System.Data
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data

'Namespace Production

'    Public Class lpsflatprice
'        Inherits TableBase

'        ''//----------------------------------------------------------------------------------------------------
'        ''// Class Constructor (zero arguments)
'        ''// Overloaded:	No
'        ''//----------------------------------------------------------------------------------------------------
'        'Public Sub New()
'        '    '--- Set up the select statement
'        '    Dim strSql As String = "SELECT * FROM lpsflatprice"
'        '    '--- Set up the Connection
'        '    _conn = Connection.GetConnection
'        '    '_conn = Connection.GetConnection(, 1)   'Pass 1 for replication database connectivity.
'        '    '--- Set up the data adapter
'        '    _da = GetDataAdapter(strSql, _conn)
'        '    '//--- Destroy object

'        '    '//Craig Haney
'        '    _conn.Close()
'        '    _conn.Dispose()
'        '    '//Craig Haney

'        '    _conn = Nothing
'        'End Sub

'        ''Public Shared Function getFlatPrice(ByVal valCust As Int32, ByVal valPSprice As Int32) As DataTable
'            '            Dim _conn As MySqlConnection = Nothing
'            '            _conn = Connection.GetConnection
'            '            Dim strSql As String = "Select * from lpsflatprice where Cust_ID = " & valCust & " AND PSPrice_ID"
'            '            Dim _cmd As New MySqlCommand(strSql, _conn)
'            '            Dim _da As New MySqlDataAdapter()
'            '            _da.SelectCommand = _cmd
'            '            Dim _dt As New DataTable()
'            '            _da.Fill(_dt)
'            '            _da.Dispose()
'            '            _cmd.Dispose()
'            '            '//Craig Haney
'            '            _conn.Close()
'            '            _conn.Dispose()
'            '            '//Craig Haney
'            '            _conn = Nothing
'            '            Return _dt
'        '' End Function

'    End Class

'End Namespace