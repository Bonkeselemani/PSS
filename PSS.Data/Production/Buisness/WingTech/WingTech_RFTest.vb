Option Explicit On 

Namespace Buisness.WingTech
    Public Class WingTech_RFTest
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
        '***************************************************************
        Public Function GetManufFailCodesList(ByVal iProd_ID As Integer, _
                                              Optional ByVal booFilterRFOnly As Boolean = False) As DataTable
            Dim strSQL As String
            Dim iMCode_ID As Integer = 0
            Dim dt As DataTable

            Try
                strSQL = "SELECT Fail_ID, " & Environment.NewLine
                strSQL &= "Concat(trim(A.Fail_SDesc), ' - ', trim(A.Fail_Ldesc)) as Fail_LDesc " & Environment.NewLine
                strSQL &= "FROM lfailcodes A " & Environment.NewLine
                strSQL &= "WHERE manuf_id = 21 and fail_inactive = 0 and prod_id = " & iProd_ID & Environment.NewLine
                If booFilterRFOnly = True Then strSQL &= "AND RF = 1 " & Environment.NewLine
                strSQL &= "ORDER BY A.Fail_SDesc;"
                dt = Me._objDataProc.GetDataTable(strSQL)
                dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetTestData(ByVal strDevice_SN As String, _
                                            ByVal strTestType As String) As DataTable
            Dim strsql As String = ""

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

                Return Me._objDataProc.GetDataTable(strsql)

            Catch ex As Exception
                Throw New Exception("GetTestHistory(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************************
        Public Function GetTestHistory(ByVal iDevice_ID As Integer, _
                                     ByVal iTestTypeID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                '*****************
                strsql = "Select TD_Sequence as 'Seq', " & Environment.NewLine
                strsql &= "a.TD_TestDt as 'RF Date', " & Environment.NewLine
                strsql &= "b.qcresult as 'RF Result', " & Environment.NewLine
                strsql &= "c.Fail_SDesc as 'Fail Code', " & Environment.NewLine
                strsql &= "c.Fail_LDesc as 'Code Desc', " & Environment.NewLine
                strsql &= "if(d.User_FullName is not null, concat( d.user_id, ' - ', d.User_FullName), '') as 'Tester', " & Environment.NewLine
                strsql &= "a.QCResult_ID, " & Environment.NewLine
                strsql &= "a.Test_ID, " & Environment.NewLine
                strsql &= "a.TD_UsrID, " & Environment.NewLine
                strsql &= "a.completedTechUsrID, " & Environment.NewLine
                strsql &= "a.Device_ID " & Environment.NewLine
                strsql &= ", a.Fail_ID " & Environment.NewLine
                strsql &= "FROM ttestdata a " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult b on a.QCResult_ID = b.QCResult_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lfailcodes c on a.fail_id  = c.fail_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN security.tusers d on a.TD_UsrID  = d.user_id " & Environment.NewLine
                strsql &= "WHERE a.device_id = " & iDevice_ID & Environment.NewLine
                strsql &= "AND a.Test_ID = " & iTestTypeID & Environment.NewLine
                strsql &= "ORDER BY Seq, TD_TestDt;"

                Return Me._objDataProc.GetDataTable(strsql)

            Catch ex As Exception
                Throw New Exception("GetTestHistory(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************************
        Public Function GetLoadUserPassFailNumber(ByVal iGroup_ID As Integer, _
                                                  ByVal iWCLocation_ID As Integer, _
                                                  ByVal iUserID As Integer, _
                                                  ByVal strWkDt As String) As Integer()
            Dim strSql As String
            Dim dt As DataTable
            Dim iArr(2) As Integer

            Try
                strSql = "SELECT distinct ttestdata.Device_ID, ttestdata.QCResult_ID  as Result " & Environment.NewLine
                strSql &= "FROM ttestdata " & Environment.NewLine
                strSql &= "WHERE ttestdata.TD_UsrID = " & iUserID & Environment.NewLine
                strSql &= "AND TD_TestDt like '" & Format(CDate(strWkDt), "yyyy-MM-dd") & "%';"
                dt = Me._objDataProc.GetDataTable(strSql)
                iArr(0) = dt.Select(" Result = 1").Length  'Pass
                iArr(1) = dt.Select(" Result = 2").Length  'Fail

                Return iArr
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Get User Pass/Fail Number")
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************
        Public Function DeletePretestDataByPretestID(ByVal iRFtest_id As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "DELETE FROM ttestdata " & Environment.NewLine
                strSql &= "WHERE ttestdata.Fail_id = " & iRFtest_id.ToString & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "RemovePretestEntry")
            End Try
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


        '***************************************************************
        Public Function InsertPFData(ByVal iUsrID As Integer, _
                                     ByVal iDevice_ID As Integer, _
                                     ByVal iTestType As Integer, _
                                     ByVal dtFailcode As DataTable, _
                                     ByVal iRFResult As Integer, _
                                     ByVal strScreen As String) As Boolean

            Dim bUpdatePFData As Boolean = False
            Dim strSQL As String
            Dim iReturn As Integer
            Dim dt2 As DataTable
            Dim R1 As DataRow
            Dim strFailCodes As String
            Dim iRFSequence As Integer = 0

            Try
                If iDevice_ID > 0 Then
                    'Get Sequence
                    strSQL = "SELECT (if(max(TD_Sequence) is null, 0, max(TD_Sequence)) + 1) as 'Iteration' " & Environment.NewLine
                    strSQL &= "FROM ttestdata " & Environment.NewLine
                    strSQL &= "WHERE Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                    strSQL &= "AND Test_ID = " & iTestType & Environment.NewLine
                    iRFSequence = Me._objDataProc.GetIntValue(strSQL)

                    strSQL = "SELECT qc_id, inspector_id, tech_id  " & Environment.NewLine
                    strSQL &= "FROM tqc " & Environment.NewLine
                    strSQL &= "WHERE Device_ID = " & iDevice_ID.ToString & " order by qc_id desc; " & Environment.NewLine
                    dt2 = Me._objDataProc.GetDataTable(strSQL)

                    '***********************************
                    If iRFResult = 1 Or dtFailcode.Rows.Count = 0 Then 'Pass or no failcode selected
                        strSQL = "INSERT INTO ttestdata ( " & Environment.NewLine
                        strSQL &= "TD_TestDt, TD_UsrID, TD_Sequence " & Environment.NewLine
                        strSQL &= ", Device_ID, Test_ID " & Environment.NewLine
                        strSQL &= ", QCResult_ID " & Environment.NewLine

                        strSQL &= ") VALUES ( " & Environment.NewLine
                        strSQL &= "now() " & Environment.NewLine
                        strSQL &= ", " & iUsrID & Environment.NewLine
                        strSQL &= ", " & iRFSequence & Environment.NewLine
                        strSQL &= ", " & iDevice_ID & Environment.NewLine
                        strSQL &= ", " & iTestType & Environment.NewLine
                        strSQL &= ", " & iRFResult & ");"
                        Return Me._objDataProc.ExecuteNonQuery(strSQL)

                    ElseIf iRFResult = 2 Then 'Fail
                        For Each R1 In dtFailcode.Rows
                            strSQL = "INSERT INTO ttestdata ( " & Environment.NewLine
                            strSQL &= "TD_TestDt, TD_UsrID, TD_Sequence " & Environment.NewLine
                            If strScreen = "RF2" Then strSQL &= ", CompletedTechUsrID, FinalTestInspectorUsrID " & Environment.NewLine
                            strSQL &= ", Device_ID, Test_ID " & Environment.NewLine
                            If iRFResult = 2 Then strSQL &= ", Fail_ID " & Environment.NewLine
                            strSQL &= ", QCResult_ID " & Environment.NewLine

                            strSQL &= ") VALUES ( " & Environment.NewLine
                            strSQL &= "now() " & Environment.NewLine
                            strSQL &= ", " & iUsrID & Environment.NewLine
                            strSQL &= ", " & iRFSequence & Environment.NewLine
                            If strScreen = "RF2" Then strSQL &= ", " & dt2.Rows(0)("tech_id") & ", " & dt2.Rows(0)("inspector_id") & Environment.NewLine
                            strSQL &= ", " & iDevice_ID & Environment.NewLine
                            strSQL &= ", " & iTestType & Environment.NewLine
                            If iRFResult = 2 Then strSQL &= ", " & R1("Fail_ID").ToString & Environment.NewLine

                            strSQL &= ", " & iRFResult & ");"
                            Return Me._objDataProc.ExecuteNonQuery(strSQL)

                        Next R1

                    End If
                Else
                    MsgBox("Unable to obtain a device ID for this device.  RF data not updated.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "No Update")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Buisness.Generic.DisposeDT(dtFailcode)
                Buisness.Generic.DisposeDT(dt2)
            End Try
        End Function
        Public Function checkRFResult(ByVal strDevice_SN As String, ByVal strRFResult As String) As Integer
            Dim dt2 As New DataTable()
            Dim strSQL As String
            strSQL = "SELECT *  " & Environment.NewLine
            strSQL &= "FROM tdevice_test " & Environment.NewLine
            strSQL &= "WHERE Device_SN = '" & strDevice_SN & "'AND TestTResult='" & strRFResult & "' and TestType='RF Test'and IsManual=1; " & Environment.NewLine
            dt2 = Me._objDataProc.GetDataTable(strSQL)
            Return dt2.Rows.Count
        End Function


        Public Function InsertRFWikoCoolpad(ByVal iUsrID As Integer, _
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
                    strSQL &= ", 'RF Test'" & Environment.NewLine
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

        Public Shared Function GetRFFailDesc(ByVal iDeviceID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT concat('RF2 Fail:', Fail_SDesc, '-', Fail_LDesc) as 'Fail Desc'  FROM ttestdata " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes on ttestdata.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY ttestdata.td_id desc " & Environment.NewLine
                strSql &= "limit 1; " & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************


    End Class
End Namespace