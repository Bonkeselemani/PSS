Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data

Namespace Production

    Public Class tdevicemetro
        'Inherits TableBase

        ''//----------------------------------------------------------------------------------------------------
        ''// Class Constructor (zero arguments)
        ''// Overloaded:	No
        ''//----------------------------------------------------------------------------------------------------



        'Public Sub New()
        '    '--- Set up the select statement
        '    Dim strSql As String = "SELECT * FROM tdevicemetro"
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

        Public Shared Function GetDetailRecord(ByVal vSN As String) As DataTable
           Dim strSql As String = "SELECT * FROM tdevicemetro WHERE devicemetro_SN = '" & vSN & "'"
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

        Public Shared Function InsertDetailRecord(ByVal vSN As String, ByVal vCAP As String, ByVal vSKU As String, ByVal vModel As String, ByVal vTray As String, ByVal vWO As String, ByVal vstrFreq As String) As Boolean
            Dim vFreq As String = ""
            Dim vFreqID As Integer
            Dim vFreqIDMOTO As Integer
            Dim objDataProc As DBQuery.DataProc

            Try
                vFreq = vstrFreq

                If vFreq <> 0 Then
                    '//Get freqID
                    Dim ds As PSS.Data.Production.Joins
                    Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM lfrequency WHERE freq_Number = '" & Trim(vstrFreq) & "'")
                    Dim r As DataRow = dt.Rows(0)
                    vFreqID = r("Freq_ID")
                    vFreqIDMOTO = r("Freq_MotoCode")
                End If

                Dim strSQL As String = "REPLACE INTO tdevicemetro (devicemetro_SN, devicemetro_SKU, devicemetro_CapCode, devicemetro_FreqCode, Model_ID, Freq_ID, Tray_ID, WO_ID) VALUES ('" & vSN & "', '" & vSKU & "', '" & vCAP & "', " & CInt(vFreqIDMOTO) & ", " & vModel & ", " & vFreqID & ", " & vTray & ", " & vWO & ")"
                InsertDetailRecord = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                InsertDetailRecord = True
                Return True
            Catch ex As Exception
                InsertDetailRecord = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function InsertDetailRecord2(ByVal vSN As String, ByVal vCAP As String, ByVal vSKU As String, ByVal vModel As String, ByVal vTray As String, ByVal vWO As String, ByVal vstrFreq As String, ByVal vstrSKU As String) As Boolean
            Dim vFreq As String = ""
            Dim vFreqID As Integer
            Dim vFreqIDMOTO As Integer
            Dim objDataProc As DBQuery.DataProc

            Try
                InsertDetailRecord2 = False

                vFreq = vstrFreq

                If vFreq <> 0 Then
                    '//Get freqID
                    Dim ds As PSS.Data.Production.Joins
                    Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM lfrequency WHERE freq_Number = '" & Trim(vstrFreq) & "'")
                    Dim r As DataRow = dt.Rows(0)
                    vFreqID = r("Freq_ID")
                    vFreqIDMOTO = r("Freq_MotoCode")
                End If

                Dim strSQL As String = "REPLACE INTO tdevicemetro (devicemetro_SN, devicemetro_SKU, devicemetro_CapCode, devicemetro_FreqCode, Model_ID, Freq_ID, Tray_ID, WO_ID) VALUES ('" & vSN & "', '" & vSKU & "', '" & vCAP & "', " & CInt(vFreqIDMOTO) & ", " & vModel & ", " & vFreqID & ", " & vTray & ", " & vWO & ")"
                InsertDetailRecord2 = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery(strSQL)
                InsertDetailRecord2 = True
                Return True
            Catch ex As Exception
                InsertDetailRecord2 = False
                Throw ex
            End Try
        End Function

    End Class
End Namespace