Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class rusertogroup
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------

        'Public Sub New()
        '    Dim strSql As String
        '    Try
        '        strSql = "SELECT * FROM security.rusertogroup"
        '        _conn = Connection.GetConnection("security")
        '        _da = GetDataAdapter(strSql, _conn)

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If Not IsNothing(_conn) Then
        '            If _conn.State.Open = ConnectionState.Open Then
        '                _conn.Close()
        '            End If
        '            _conn.Dispose()
        '            _conn = Nothing
        '        End If
        '    End Try
        'End Sub

        Public Shared Function GetSingleUserGroupList(ByVal valID As Integer) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT * FROM security.rusertogroup WHERE user_ID = " & valID
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function InsertUserRecords(ByVal vUserID As Int32, ByVal vGroupID As Int32) As Boolean
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertUserRecords = False
                strSql = "INSERT INTO security.rusertogroup (user_ID, group_ID) VALUES (" & vUserID & ", " & vGroupID & ")"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSql)
                InsertUserRecords = True
                Return True
            Catch ex As Exception
                InsertUserRecords = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function DeleteUserRecords(ByVal vUserID As Int32) As Boolean
            Dim strSql As String = "DELETE FROM security.rusertogroup WHERE user_ID = " & vUserID
            Dim objDataProc As DBQuery.DataProc

            Try
                DeleteUserRecords = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSql)
                DeleteUserRecords = True
                Return True
            Catch ex As Exception
                DeleteUserRecords = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class
End Namespace

