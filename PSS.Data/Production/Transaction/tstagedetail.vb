Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Production

    Public Class tstagedetail
        Public Shared Function InsertDataRow(ByVal vSerial As String, ByVal vTrack As String, ByVal vStatus As Integer, ByVal vDS As String, ByVal vCust As Int32, ByVal vLoc As Int32, ByVal vWO As Int32) As Boolean
            Dim strSQL As String = "INSERT INTO tstagedetail (StageD_SN, StageD_TrackingNo, StageD_Status, StageD_DateStaged, StageD_CustID, StageD_LocID, StageD_WOID) VALUES ('" & vSerial & "', '" & vTrack & "', '" & vStatus & "', '" & vDS & "'," & vCust & ", " & vLoc & ", " & vWO & ");"
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
           Dim strSql As String = "SELECT * FROM tstagedetail WHERE StageD_SN = '" & vSerial & "' and StageD_DateRec='0000-00-00' AND StageD_WOID is not null;"
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

        Public Shared Function GetDeviceBySerialLoc(ByVal vSerial As String, ByVal vLoc As Int32) As DataTable
           Dim strSql As String = "SELECT * FROM tstagedetail WHERE StageD_SN = '" & vSerial & "' and StageD_DateRec='0000-00-00' AND StageD_LocID = " & vLoc & ";"
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

        Public Shared Function GetDeviceBySerialDate(ByVal vSerial As String, ByVal vDate As String) As DataTable
          Dim strSql As String = "SELECT * FROM tstagedetail WHERE StageD_SN = '" & vSerial & "' AND StageD_DateStaged = '" & vDate & "';"
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
            Dim strSql As String = "DELETE FROM tstagedetail WHERE StageD_SN = '" & vSerial & "' and StageD_DateRec = '0000-00-00';"
            Dim objDataProc As DBQuery.DataProc

            Try
                DeleteDeviceBySerial = False

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSql)

                DeleteDeviceBySerial = True
                Return True
            Catch ex As Exception
                DeleteDeviceBySerial = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetDuplicateDeviceDataSTAGE(ByVal SerialNum As String, ByVal WO As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tstagedetail WHERE StageD_WOID = " & WO & " AND StageD_SN = '" & SerialNum & "';"
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
