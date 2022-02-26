Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Production

    Public Class tmetrocalldetail
        'Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM lmetrocall"
        '    '--- Set up the Connection
        '    _conn = Connection.GetConnection
        '    '--- Set up the data adapter
        '    _da = GetDataAdapter(strSql, _conn)
        '    '//--- Destroy object

        '    '//Craig Haney
        '    _conn.Close()
        '    _conn.Dispose()
        '    '//Craig Haney

        '    _conn = Nothing
        'End Sub

        Public Shared Function InsertDataRow(ByVal vSerial As String, ByVal vTrack As String, ByVal vStatus As Integer, ByVal vDS As String) As Boolean
            Dim strSQL As String = "INSERT INTO tstagedetail (StageD_SN, StageD_TrackingNo, StageD_Status, StageD_DateStaged) VALUES ('" & vSerial & "', '" & vTrack & "', '" & vStatus & "', '" & vDS & "');"
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertDataRow = False

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)

                InsertDataRow = True
                Return True
            Catch ex As Exception
                InsertDataRow = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDeviceBySerial(ByVal vSerial As String) As DataTable
            Dim strSql As String = "SELECT * FROM tstagedetail WHERE MetroD_SN = '" & vSerial & "' and MetroD_DateRec='0000-00-00';"
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

        Public Shared Function DeleteDeviceBySerial(ByVal vSerial As String) As Boolean
            Dim strSql As String = "DELETE FROM tmetrocalldetail WHERE MetroD_SN = '" & vSerial & "' and MetroD_DateRec = '0000-00-00';"
            Dim objDataProc As DBQuery.DataProc

            Try
                DeleteDeviceBySerial = False

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSql)

                DeleteDeviceBySerial = True
                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

    End Class

End Namespace
