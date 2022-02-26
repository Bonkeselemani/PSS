Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tpermissions
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tpermissions"
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

        Public Shared Function GetPermissionsList() As DataTable
            Dim strSql As String = "SELECT security.tpermissions.perm_id, security.tgroup.group_desc, security.tscreen.screen_desc, security.llevel.level_desc, security.tpermissions.group_id, security.tpermissions.screen_id, security.tpermissions.level_id FROM (((security.tpermissions INNER JOIN security.tgroup ON security.tpermissions.group_id = security.tgroup.group_id) INNER JOIN security.tscreen ON security.tpermissions.screen_id = security.tscreen.screen_ID) INNER JOIN security.llevel ON security.tpermissions.level_id = security.llevel.level_id) ORDER BY security.tgroup.group_desc, security.tscreen.screen_desc"
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

        Public Shared Function VerifyLevelDelete(ByVal tmpID As Integer) As DataTable
            Dim strSql As String = "SELECT * FROM security.tpermissions WHERE level_ID = " & tmpID
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

        Public Shared Function VerifyGroupDelete(ByVal tmpID As Integer) As DataTable
            Dim strSql As String = "SELECT * FROM security.tpermissions WHERE group_ID = " & tmpID
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

        Public Shared Function InsertPermissions(ByVal vGroup As Int32, ByVal vScreen As Int32, ByVal vLevel As Int32) As Boolean
            Dim strSQL As String = "INSERT INTO security.tpermissions (group_ID, screen_ID, level_ID) VALUES (" & vGroup & ", " & vScreen & ", " & vLevel & ")"
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertPermissions = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                InsertPermissions = True
                Return True
            Catch ex As Exception
                InsertPermissions = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function EditPermissions(ByVal permID As Int32, ByVal vGroup As Int32, ByVal vScreen As Int32, ByVal vLevel As Int32) As Boolean
            Dim strSQL As String = "UPDATE security.tpermissions set group_ID = " & vGroup & ", screen_ID = " & vScreen & ", level_ID = " & vLevel & " WHERE perm_ID = " & permID
            Dim objDataProc As DBQuery.DataProc

            Try
                EditPermissions = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                EditPermissions = True
                Return True
            Catch ex As Exception
                EditPermissions = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function DeletePermissions(ByVal permID As String) As Boolean
            Dim strSQL As String = "DELETE FROM security.tpermissions WHERE perm_ID = " & permID
            Dim objDataProc As DBQuery.DataProc

            Try
                DeletePermissions = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                DeletePermissions = True
                Return True
            Catch ex As Exception
                DeletePermissions = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetScreenListByUser(ByVal tmpUser As Int32) As DataTable
            Dim strSql As String = "select security.tscreen.screen_desc from ((security.tpermissions INNER JOIN security.tscreen ON security.tpermissions.screen_id = security.tscreen.screen_id) INNER JOIN security.rusertogroup ON security.tpermissions.group_id = security.rusertogroup.group_id) WHERE security.rusertogroup.user_id = " & tmpUser & " ORDER BY security.tscreen.screen_desc"
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

        Public Shared Function GetScreenListByGroup(ByVal tmpGroup As Int32) As DataTable
            Dim strSql As String = "SELECT security.tscreen.screen_desc FROM (security.tpermissions INNER JOIN security.tscreen ON security.tpermissions.screen_id = security.tscreen.screen_id) WHERE security.tpermissions.group_id = " & tmpGroup & " ORDER BY screen_desc"
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

