Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.CP
    Public Class CoolPad_RfFlashTests
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

        Public Function GetTestData(ByVal strDevice_SN As String, _
                                                   ByVal strTestType As String) As DataTable
            Dim strsql As String = ""
            Dim dt As DataTable
            Try
                '*****************
                strsql = "Select Device_SN as 'Serial Number',  TestType as 'Test Type', " & Environment.NewLine
                strsql &= "TestTResult as 'RF Result', " & Environment.NewLine
                strsql &= "TestDateTime as 'RF Date', " & Environment.NewLine
                strsql &= "if(D.User_FullName is not null, concat( D.user_id, ' - ', D.User_FullName), '') as 'Tester'  " & Environment.NewLine
                strsql &= "FROM tdevice_test A " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN security.tusers D on A.Man_UserID  = D.user_id " & Environment.NewLine
                strsql &= "WHERE device_SN = '" & strDevice_SN & "'   AND  TestType = '" & strTestType & "' AND IsManual=1  " & Environment.NewLine
                strsql &= "  ORDER BY TestDateTime ;"
               dt = _objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw New Exception("GetTestHistory(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        Public Function InsertRFlashWikoCoolpad(ByVal iUsrID As Integer, _
                                                   ByVal strDeviceSN As String, _
                                                   ByVal iRFResult As Integer) As Boolean
            Dim strSQL As String
            Dim strRFresult As String
            Try
                If Not strDeviceSN = String.Empty Then
                    If iRFResult = 1 Then
                        strRFresult = "Pass"
                    Else
                        strRFresult = "Fail"
                    End If
                    strSQL = "INSERT INTO tdevice_test ( " & Environment.NewLine
                    strSQL &= "device_sn,TestType,TestTResult,TestDateTime,msecond,FiledateTime" & Environment.NewLine
                    strSQL &= ",FileName,IsCorrect,IsManual,Man_DTime,Man_UserID  " & Environment.NewLine
                    strSQL &= ") VALUES ( " & Environment.NewLine
                    strSQL &= strDeviceSN & Environment.NewLine
                    strSQL &= ", 'Flash'" & Environment.NewLine
                    strSQL &= ", '" & strRFresult & "' , CURRENT_TIMESTAMP " & Environment.NewLine
                    strSQL &= ", " & Now.Millisecond & Environment.NewLine
                    strSQL &= ", CURRENT_TIMESTAMP " & Environment.NewLine
                    strSQL &= ", 'No_File.xml'" & Environment.NewLine
                    strSQL &= ", 1" & Environment.NewLine
                    strSQL &= ", 1" & Environment.NewLine
                    strSQL &= ", CURRENT_TIMESTAMP " & Environment.NewLine
                    strSQL &= ", " & iUsrID & ");"
                    Return Me._objDataProc.ExecuteNonQuery(strSQL)

                Else
                    MsgBox("Unable to obtain a device ID for this device.  RF data not updated.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "No Update")
                End If

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        Public Function checkFLashResult(ByVal strDevice_SN As String, ByVal strRFResult As String) As Integer
            Dim dt2 As New DataTable()
            Dim strSQL As String
            strSQL = "SELECT *  " & Environment.NewLine
            strSQL &= "FROM tdevice_test " & Environment.NewLine
            strSQL &= "WHERE Device_SN = '" & strDevice_SN & "'AND TestTResult='" & strRFResult & "' and TestType='Flash'and IsManual=1; " & Environment.NewLine
            dt2 = Me._objDataProc.GetDataTable(strSQL)
            Return dt2.Rows.Count
        End Function
        Public Function GetDeviceFqaData(ByVal strDeviceSN As String) As DataTable
            Dim strSql As String = ""
            Try
                'FQA:   QCType_ID=2, Pass: QCResult_ID=1
                strSql = "SELECT tqc.* FROM tqc,tdevice  WHERE QCType_ID =2 AND tqc.Device_ID=tdevice.Device_ID AND Device_SN='" & strDeviceSN & "' ORDER BY QC_Date DESC;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceRFData(ByVal strDeviceSN As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tdevice_test WHERE IsManual=1 AND   testType='RF Test' and TestTResult='Pass'and  Device_SN='" & strDeviceSN & "' ORDER BY TestDatetime DESC;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
