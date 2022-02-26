Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tcellopt
        Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------
        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tcellopt"
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

        Public Shared Function GetRowByDeviceID(ByVal valDeviceID As Int32) As DataRow
            Dim strSql As String = "SELECT * FROM tcellopt WHERE Device_ID = " & valDeviceID
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function UpdateCellOptData(ByVal aSQL As String) As Boolean
            Dim objDataProc As DBQuery.DataProc
            
            Try
                UpdateCellOptData = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(aSQL)
                UpdateCellOptData = True
                Return True
            Catch ex As Exception
                UpdateCellOptData = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function UpdateDecimalData(ByVal vDevice As Integer, ByVal vDecimal As String) As Boolean
            If Len(Trim(vDevice)) > 0 Then
                Dim strSQL As String = "UPDATE tcellopt SET CellOpt_CSN_Dec = '" & vDecimal & "' WHERE Device_ID = " & vDevice
                Dim objDataProc As DBQuery.DataProc

                Try
                    UpdateDecimalData = False
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                    objDataProc.ExecuteNonQuery(strSQL)
                    UpdateDecimalData = True
                    Return True
                Catch ex As Exception
                    UpdateDecimalData = False
                    Throw ex
                Finally
                    objDataProc = Nothing
                End Try
            Else
                Return False
            End If
        End Function

    End Class
End Namespace