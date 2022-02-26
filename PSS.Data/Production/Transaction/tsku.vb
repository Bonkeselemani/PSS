


Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tsku
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tsku"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object
        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney
        '    _conn = Nothing

        'End Sub

        Public Shared Function GetRowBySKU(ByVal valSKU As String) As Boolean
            Dim strSql As String = "SELECT * FROM tsku WHERE Sku_Number = '" & valSKU & "'"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetValSKU(ByVal valSKU As String) As DataRow
            Dim strSql As String = "SELECT * FROM tsku WHERE Sku_Number = '" & valSKU & "'"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetValSKUID(ByVal valSKU As Long) As DataRow
            Dim strSql As String = "SELECT * FROM tsku WHERE Sku_ID = " & valSKU
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function InsertSkuData(ByVal aSQL As String) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                InsertSkuData = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(aSQL)
                InsertSkuData = True
                Return True
            Catch ex As Exception
                InsertSkuData = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class

End Namespace
