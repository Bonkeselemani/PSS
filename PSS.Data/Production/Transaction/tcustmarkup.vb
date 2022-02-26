Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class tcustmarkup
		Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM tcustmarkup"
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

        Public Shared Function GetRowByPK(ByVal valCustID As Int32) As DataRow
             Dim strSql As String = "SELECT * FROM tcustmarkup WHERE Cust_ID = " & valCustID
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

        Public Shared Function GetRowByCustProdInvMthd(ByVal valCustID As Int32, ByVal valProdID As Int32, ByVal valInvMthd As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM tcustmarkup WHERE Cust_ID = " & valCustID & " AND Prod_ID = " & valProdID & " AND InvtryMthd_ID = " & valInvMthd
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

        Public Shared Function GetRowByCustProd(ByVal valCustID As Int32, ByVal valProdID As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM tcustmarkup WHERE Cust_ID = " & valCustID & " AND Prod_ID = " & valProdID & ""
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

    End Class
End Namespace