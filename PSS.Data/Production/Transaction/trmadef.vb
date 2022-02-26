'Imports System
'Imports System.Data
'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data

'Namespace Production

'    Public Class trmadef
'        'Inherits TableBase


'        ''//----------------------------------------------------------------------------------------------------
'        ''// Class Constructor (zero arguments)
'        ''// Overloaded:	No
'        ''//----------------------------------------------------------------------------------------------------
'        'Public Sub New()
'        '    '--- Set up the select statement
'        '    Dim strSql As String = "SELECT * FROM trmadef"
'        '    '--- Set up the Connection
'        '    _conn = Connection.GetConnection
'        '    '--- Set up the data adapter
'        '    _da = GetDataAdapter(strSql, _conn)
'        '    '//--- Destroy object

'        '    '//Craig Haney
'        '    _conn.Close()
'        '    _conn.Dispose()
'        '    '//Craig Haney

'        '    _conn = Nothing
'        'End Sub

'        Public Shared Function InsertRecord(ByVal vName As String, ByVal vQty As Integer, ByVal vPRL As String, ByVal vIP As String, ByVal vSKU As String, ByVal vcustID As Int32, ByVal vmanufID As Int32, ByVal vmodID As Int32) As Boolean
'            Try
'                Dim _conn As MySqlConnection = Connection.GetConnection
'                Dim strSQL As String = "INSERT into trmadef " & _
'                "(RMA_Name, RMA_Qty, RMA_PRL, RMA_IP, RMA_SKU, Cust_ID, Manuf_ID, Model_ID) " & _
'                "VALUES('" & vName & "', " & vQty & ", '" & _
'                vPRL & "', '" & vIP & "', '" & vSKU & "', " & _
'                vcustID & ", " & vmanufID & ", " & vmodID & ")"
'                Dim cmd1 As New MySqlCommand(strSQL, _conn)
'                '_conn.Open()
'                cmd1.ExecuteNonQuery()
'                '//Craig Haney
'                _conn.Close()
'                _conn.Dispose()
'                '//Craig Haney
'                _conn = Nothing
'                Return True
'            Catch ex As Exception
'                Return False
'            End Try
'        End Function

'    End Class

'End Namespace