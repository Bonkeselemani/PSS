Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class tlocation
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM tlocation"
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

        Public Shared Function GetRowByPK(ByVal pkVAL As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM tlocation WHERE Loc_ID = " & pkVAL
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetRowsByCustomerID(ByVal CustID As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tlocation WHERE Cust_ID = " & CustID & " ORDER BY Loc_Name;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetRowByLocID(ByVal LocID As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tlocation WHERE Loc_ID = " & LocID
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function RemoveDataRowByCustID(ByVal CustID As String) As Boolean
           Dim strSQL As String = "DELETE FROM tlocation WHERE Cust_ID = " & CustID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                RemoveDataRowByCustID = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                RemoveDataRowByCustID = True
                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace