Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tdevicecodes
        'Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tdevicecodes"
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

        Public Shared Function UpdateCodes(ByVal aSQL As String) As Boolean
            Dim objDataProc As DBQuery.DataProc

            Try
                UpdateCodes = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(aSQL)
                UpdateCodes = True
                Return True
            Catch ex As Exception
                UpdateCodes = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function DeleteCodes(ByVal intDevice As Int32) As Boolean
            Dim objDataProc As DBQuery.DataProc

            If intDevice > 0 Then
                Try
                    DeleteCodes = False
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                    Dim strSQL As String = "DELETE FROM tdevicecodes USING tdevicecodes, lcodesdetail where tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & intDevice & " AND lcodesdetail.MCode_ID = 9"
                    objDataProc.ExecuteNonQuery(strSQL)

                    strSQL = "DELETE FROM tdevicecodes USING tdevicecodes, lcodesdetail where tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & intDevice & " AND lcodesdetail.MCode_ID = 3"
                    objDataProc.ExecuteNonQuery(strSQL)

                    'Craig Haney
                    strSQL = "DELETE FROM tdevicecodes USING tdevicecodes, lcodesdetail where tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & intDevice & " AND lcodesdetail.MCode_ID = 20"
                    objDataProc.ExecuteNonQuery(strSQL)

                    DeleteCodes = True
                    Return True
                Catch ex As Exception
                    DeleteCodes = False
                    Throw ex
                Finally
                    objDataProc = Nothing
                End Try
            End If
        End Function

        Public Shared Function GetSelectedValues(ByVal intDevice As Int32, ByVal intManuf As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tdevicecodes WHERE Device_ID= " & intDevice
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

        Public Shared Function GetTroubleFound(ByVal intDevice As Int32) As DataTable
            Dim strSql As String = "SELECT tdevicecodes.*, lcodesdetail.mcode_id FROM (tdevicecodes INNER JOIN lcodesdetail ON tdevicecodes.dcode_id = lcodesdetail.dcode_id) WHERE Device_ID= " & intDevice & " AND MCode_ID = 20"
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

        Public Shared Function GetReturnCode(ByVal intDevice As Int32) As DataTable
            Dim strSql As String = "SELECT tdevicecodes.*, lcodesdetail.mcode_id FROM (tdevicecodes INNER JOIN lcodesdetail ON tdevicecodes.dcode_id = lcodesdetail.dcode_id) WHERE Device_ID= " & intDevice & " AND MCode_ID = 19"
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

        Public Shared Function GetReturnCode() As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.Mcode_ID=19"
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