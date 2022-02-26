Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tscreen
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tscreen"
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

        Public Shared Function GetScreenList() As DataTable
            Dim strSql As String = "SELECT * FROM security.tscreen ORDER BY screen_desc"
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

        Public Shared Function InsertScreen(ByVal vDesc As String, ByVal vSysName As String) As Boolean
            Dim strSQL As String = "INSERT INTO security.tscreen (screen_Desc, screen_sysname) VALUES ('" & vDesc & "', '" & vSysName & "')"
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertScreen = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                InsertScreen = True
                Return True
            Catch ex As Exception
                InsertScreen = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function EditScreen(ByVal screenID As Int32, ByVal vDesc As String, ByVal vSysName As String) As Boolean
            Dim strSQL As String = "UPDATE security.tscreen set screen_desc = '" & vDesc & "', screen_sysname = '" & vSysName & "' WHERE screen_ID = " & screenID
            Dim objDataProc As DBQuery.DataProc

            Try
                EditScreen = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                EditScreen = True
                Return True
            Catch ex As Exception
                EditScreen = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function DeleteScreen(ByVal screenID As String) As Boolean
            Dim strSQL As String = "DELETE FROM security.tscreen WHERE screen_ID = " & screenID
            Dim objDataProc As DBQuery.DataProc

            Try
                DeleteScreen = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                DeleteScreen = True
                Return True
            Catch ex As Exception
                DeleteScreen = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace

