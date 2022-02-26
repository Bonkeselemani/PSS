Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

	Public Class lstate
		Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '	'--- Set up the select statement
        '	Dim strSql As String = "SELECT * FROM lstate"
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

        Public Shared Function GetNameByPK(ByVal pkVAL As Int32) As String
            Dim strSql As String = "SELECT state_short FROM lstate WHERE State_ID = " & pkVAL
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class

End Namespace