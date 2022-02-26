Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class llevel
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM security.llevel"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection("security")
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object

        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney

        '    _conn = Nothing
        'End Sub

        Public Shared Function GetLevelList() As DataTable
            Dim strSql As String = "SELECT * FROM security.llevel ORDER BY level_desc"
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

        Public Shared Function InsertLevel(ByVal LevelDesc As String) As Boolean
            Dim strSQL As String = "INSERT INTO security.llevel (level_Desc) VALUES ('" & LevelDesc & "')"
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertLevel = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                InsertLevel = True
                Return True
            Catch ex As Exception
                InsertLevel = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function EditLevel(ByVal LevelID As String, ByVal LevelDesc As String) As Boolean
            Dim strSQL As String = "UPDATE security.llevel set level_desc = '" & LevelDesc & "' WHERE level_ID = " & LevelID
            Dim objDataProc As DBQuery.DataProc

            Try
                EditLevel = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                EditLevel = True
                Return True
            Catch ex As Exception
                EditLevel = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function DeleteLevel(ByVal LevelID As String) As Boolean
            Dim strSQL As String = "DELETE FROM security.llevel WHERE level_ID = " & LevelID
            Dim objDataProc As DBQuery.DataProc

            Try
                DeleteLevel = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                DeleteLevel = True
                Return True
            Catch ex As Exception
                DeleteLevel = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace

