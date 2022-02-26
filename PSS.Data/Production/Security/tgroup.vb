Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tgroup
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tgroup"
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

        Public Shared Function GetGroupList(ByVal strusername As String) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                If LCase(strusername) = "pss admin" Then
                    strSql = "SELECT * FROM security.tgroup ORDER BY group_desc"
                Else
                    strSql = "SELECT * FROM security.tgroup where group_OpenToFloor = 1 ORDER BY group_desc"
                End If

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        'Commented out by Asif on 02/21/2006
        'Public Shared Function GetGroupList() As DataTable
        '    _conn = Connection.GetConnection("security")
        '    Dim strSql As String = "SELECT * FROM security.tgroup ORDER BY group_desc"
        '    Dim _cmd As New MySqlCommand(strSql, _conn)
        '    Dim _da As New MySqlDataAdapter()
        '    _da.SelectCommand = _cmd
        '    Dim _dt As New DataTable()
        '    _da.Fill(_dt)
        '    _da.Dispose()
        '    _cmd.Dispose()
        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney
        '    _conn = Nothing
        '    Return _dt
        'End Function

        Public Shared Function InsertGroup(ByVal GroupDesc As String) As Boolean
            Dim strSQL As String = "INSERT INTO security.tgroup (group_Desc) VALUES ('" & GroupDesc & "')"
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertGroup = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                InsertGroup = True
                Return True
            Catch ex As Exception
                InsertGroup = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function EditGroup(ByVal GroupID As String, ByVal GroupDesc As String) As Boolean
            Dim strSQL As String = "UPDATE security.tgroup set group_desc = '" & GroupDesc & "' WHERE group_ID = " & GroupID
            Dim objDataProc As DBQuery.DataProc

            Try
                EditGroup = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                EditGroup = True
                Return True
            Catch ex As Exception
                EditGroup = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function Deletegroup(ByVal groupID As String) As Boolean
            Dim strSQL As String = "DELETE FROM security.tgroup WHERE group_ID = " & groupID
            Dim objDataProc As DBQuery.DataProc

            Try
                Deletegroup = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                Deletegroup = True
                Return True
            Catch ex As Exception
                Deletegroup = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace

