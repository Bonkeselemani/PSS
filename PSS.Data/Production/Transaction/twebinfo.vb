'Imports System
'Imports System.Data
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data

'Namespace Production

'	Public Class twebinfo
'		Inherits TableBase

'        ''//----------------------------------------------------------------------------------------------------
'        ''// Class Constructor (zero arguments)
'        ''// Overloaded:	No
'        ''//----------------------------------------------------------------------------------------------------
'        'Public Sub New()
'        '	'--- Set up the select statement
'        '	Dim strSql As String = "SELECT * FROM twebinfo"
'        '	'--- Set up the Connection
'        '	_conn = Connection.GetConnection
'        '	'--- Set up the data adapter
'        '	_da = GetDataAdapter(strSql, _conn)
'        '	'//--- Destroy object

'        '          '//Craig Haney
'        '          _conn.Close()
'        '          _conn.Dispose()
'        '          '//Craig Haney

'        '	_conn = Nothing
'        'End Sub

'	End Class
'End Namespace