Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tdevicejournal
        'Inherits TableBase


        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tdevicejournal"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection
        '    '_conn = Connection.GetConnection(, 1)   'Pass 1 for replication database connectivity.
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object

        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney

        '    _conn = Nothing
        'End Sub

        Public Shared Function GetMaxJIDbyUser(ByVal mUser As Long) As Long
            Dim strSql As String = "Select * from tdevicejournal where User_ID = " & mUser
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0)("Journal_ID") Else Return 0
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetTimeDataBeforeUpdate(ByVal mJID As Long) As String
             Dim strSql As String = "Select * from tdevicejournal where Journal_ID = " & mJID
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0)("dteEnd").ToString Else Return ""
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function UpdateDateTimeData(ByVal mJID As Long) As Boolean
            Dim strSql As String = "UPDATE tdevicejournal SET dteEnd = '" & Now & "' where Journal_ID = " & mJID
            Dim objDataProc As DBQuery.DataProc

            Try
                UpdateDateTimeData = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSql)

                UpdateDateTimeData = True
                Return True
            Catch ex As Exception
                UpdateDateTimeData = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class

End Namespace

