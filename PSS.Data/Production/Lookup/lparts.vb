Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class lparts
		Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM lparts"
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

        Public Shared Function TechScreenGetPartData(ByVal valPartCode As String) As DataTable
            Dim strSql As String = "Select * from lparts where lparts.Parts_PartNumber = '" & valPartCode & "'"
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