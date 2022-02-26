'Imports System
'Imports System.Data
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data

'Namespace Production

'	Public Class lpricinggroup
'		Inherits TableBase

'        ''//----------------------------------------------------------------------------------------------------
'        ''// Class Constructor (zero arguments)
'        ''// Overloaded:	No
'        ''//----------------------------------------------------------------------------------------------------
'        'Public Sub New()
'        '	'--- Set up the select statement
'        '	Dim strSql As String = "SELECT * FROM lpricinggroup"
'        '	'--- Set up the Connection
'        '          _conn = Connection.GetConnection
'        '          '_conn = Connection.GetConnection(, 1)   'Pass 1 for replication database connectivity.
'        '	'--- Set up the data adapter
'        '	_da = GetDataAdapter(strSql, _conn)
'        '	'//--- Destroy object

'        '          '//Craig Haney
'        '          _conn.Close()
'        '          _conn.Dispose()
'        '          '//Craig Haney

'        '	_conn = Nothing
'        'End Sub

'        'Public Shared Function GetRowsByProdID(ByVal valProd As Int32) As DataSet
'        '    Dim strSql As String = "SELECT * FROM lpricinggroup WHERE Prod_ID = " & valProd & " Order by lpricinggroup.PrcGroup_LDesc"
'        '    Dim ds As New DataSet()
'        '    Dim objDataProc As DBQuery.DataProc
'        '    Dim dt As New DataTable()

'        '    Try
'        '        objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'        '        dt = objDataProc.GetDataTable(strSql)
'        '        dt.TableName = "lpricinggroup"

'        '        ds.Tables.Add(dt)
'        '        Return ds
'        '    Catch ex As Exception
'        '        Throw ex
'        '    Finally
'        '        objDataProc = Nothing
'        '        Buisness.Generic.DisposeDT(dt)
'        '    End Try
'        'End Function



'    End Class
'End Namespace