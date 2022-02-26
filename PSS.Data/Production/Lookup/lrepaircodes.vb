Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class lrepaircodes
		Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM lrepaircodes"
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

        Public Shared Function TechScreenRepairList(ByVal valManuf As Integer, ByVal valProdID As Integer) As DataTable
            Dim strSql As String = "SELECT Dcode_ID as Repair_ID, Dcode_SDesc as Repair_SDesc, Dcode_LDesc as Repair_LDesc, Manuf_ID, Prod_ID FROM " & _
                          "(lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.Mcode_ID = lcodesdetail.Mcode_ID) " & _
                          "WHERE lcodesmaster.Mcode_Desc='Repair' " & _
                          "ORDER BY Dcode_LDesc"
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

        Public Shared Function RepairCodeList() As DataTable
            Dim strSql As String = "SELECT Dcode_ID as Repair_ID, Dcode_SDesc as Repair_SDesc, Dcode_LDesc as Repair_LDesc, Manuf_ID, Prod_ID FROM " & _
                           "(lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.Mcode_ID = lcodesdetail.Mcode_ID) " & _
                           "WHERE lcodesmaster.Mcode_Desc='Repair' " & _
                           "ORDER BY Dcode_LDesc"
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

    End Class
End Namespace