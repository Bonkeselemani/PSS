Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class lparentco
		Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM lparentco"
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

        Public Shared Function GetCustomerByName(ByVal valCompName As String) As DataTable
            Dim strSql As String = "Select * from lparentco where PCo_Name = '" & valCompName & "';"
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

        Public Shared Function GetParentCoByID(ByVal valID As Int32) As DataTable
            Dim strSql As String = "Select * from lparentco where PCo_ID = " & valID & ";"
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

        Public Shared Function GetIDByCustomerName(ByVal valCompName As String) As DataTable
            Dim strSql As String = "Select Pco_ID from lparentco where PCo_Name = '" & valCompName & "';"
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

        Public Shared Function RemoveDataRowByCompID(ByVal CompID As String) As Boolean
            Dim strSQL As String = "DELETE FROM lparentco WHERE PCo_ID = " & CompID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                RemoveDataRowByCompID = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                RemoveDataRowByCompID = True
                Return True
            Catch ex As Exception
                RemoveDataRowByCompID = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function UpdateDataRowByCompName(ByVal CompName As String, ByVal newVal As String) As Boolean
           Dim strSQL As String = "UPDATE lparentco SET PCo_Name = '" & newVal & "' WHERE PCo_Name = '" & CompName & "';"
            Dim objDataProc As DBQuery.DataProc

            Try
                UpdateDataRowByCompName = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                UpdateDataRowByCompName = True
                Return True
            Catch ex As Exception
                UpdateDataRowByCompName = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace