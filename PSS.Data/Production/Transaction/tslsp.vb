'Imports System
'Imports System.Data
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data

'Namespace Production

'	Public Class tslsp
'        Inherits TableBase

'        ''//----------------------------------------------------------------------------------------------------
'        ''// Class Constructor (zero arguments)
'        ''// Overloaded:	No
'        ''//----------------------------------------------------------------------------------------------------
'        'Public Sub New()
'        '	'--- Set up the select statement
'        '	Dim strSql As String = "SELECT * FROM tslsp"
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
'        '      End Sub

'        'Public Shared Function GetSalesPersonOrder() As DataSet
'        '    Dim ds As New DataSet()
'        '    Dim strSql As String = "SELECT DISTINCT * FROM tslsp WHERE SlsP_SSNum <> 'DELETE' ORDER BY Slsp_FirstName"
'        '    Dim dt As New DataTable()
'        '    Dim objDataProc As DBQuery.DataProc


'        '    Try
'        '        objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'        '        dt = objDataProc.GetDataTable(strSql)
'        '        dt.TableName = "tslsp"

'        '        ds.Tables.Add(dt)

'        '        Return ds
'        '    Catch ex As Exception
'        '        Throw ex
'        '    Finally
'        '        objDataProc = Nothing
'        '        Buisness.Generic.DisposeDT(dt)
'        '    End Try
'        '    Return ds
'        'End Function

'        Public Shared Function GetSalesPersonOrderLast() As DataTable
'            Dim strSql As String = "SELECT DISTINCT * FROM tslsp WHERE SlsP_SSNum <> 'DELETE' ORDER BY Slsp_LastName"
'            Dim objDataProc As DBQuery.DataProc

'            Try
'                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
'                Return objDataProc.GetDataTable(strSql)

'            Catch ex As Exception
'                Throw ex
'            Finally
'                objDataProc = Nothing
'            End Try
'        End Function

'    End Class
'End Namespace