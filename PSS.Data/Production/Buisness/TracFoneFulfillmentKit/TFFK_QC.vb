Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_QC
        'Private _objDataProc As mySQL5
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


        Public Function GetTFFK_QC_Line() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT B.DCode_ID,B.Dcode_LDesc as 'Line',B.DCode_SDesc as 'LineNumber',A.MCode_Desc,A.MCode_ID" & Environment.NewLine
                strSql &= " FROM lCodesMaster A" & Environment.NewLine
                strSql &= " Inner Join lCodesDetail B ON A.MCode_ID=B.MCode_ID" & Environment.NewLine
                strSql &= " WHERE A.MCode_ID=87 AND B.DCode_Inactive=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetTFFK_QC_FailCode(Optional ByVal bAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT B.DCode_ID,B.Dcode_LDesc as 'FailCode',B.DCode_SDesc as 'FailCode_Short',A.MCode_Desc,A.MCode_ID" & Environment.NewLine
                strSql &= " FROM lCodesMaster A" & Environment.NewLine
                strSql &= " Inner Join lCodesDetail B ON A.MCode_ID=B.MCode_ID" & Environment.NewLine
                strSql &= " WHERE A.MCode_ID=86 AND B.DCode_Inactive=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If bAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, False)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetTFFK_QC_TargetRate() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT B.DCode_ID,B.Dcode_LDesc as 'QCTargetPercent',B.DCode_SDesc as 'QCTargetDecimal',A.MCode_Desc,A.MCode_ID" & Environment.NewLine
                strSql &= " FROM lCodesMaster A" & Environment.NewLine
                strSql &= " Inner Join lCodesDetail B ON A.MCode_ID=B.MCode_ID" & Environment.NewLine
                strSql &= " WHERE A.MCode_ID=88 AND B.DCode_Inactive=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetTFFK_QC_JobID(ByVal strJobNo As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iJobID As Integer = 0

            Try
                strJobNo = strJobNo.Replace("'", "''")
                strSql = "Select * From production.tTFFK_QC_Jobs Where QCJobNumber='" & strJobNo & "';"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then iJobID = dt.Rows(0).Item("QCJob_ID")

                Return iJobID

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function


        Public Function GetTFFK_QC_SN_IDs(ByVal iJobID As Integer, ByVal strSN As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strQC_IDs As String = ""
            Dim row As DataRow

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "Select * From production.tTFFK_QC Where QCJob_ID=" & iJobID & " And SN='" & strSN & "';"

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    If strQC_IDs.Length = 0 Then
                        strQC_IDs = row("TFFK_QC_ID")
                    Else
                        strQC_IDs &= "," & row("TFFK_QC_ID")
                    End If
                Next

                Return strQC_IDs

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function RemoveTFFK_QC_SN(ByVal strQC_SN_IDs As String) As Integer
            Dim strSql As String = ""

            Try

                strSql = "Delete From production.tTFFK_QC Where TFFK_QC_ID in (" & strQC_SN_IDs & ");"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetTFFK_QC_TestedDataByJobID(ByVal strPass1Fail2 As String, ByVal iQCJob_ID As Integer) As DataTable
            'strPass1Fail2 can be 1 or 2 or 1,2
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select A.QCJobNumber,A.QCJob_Quantity,A.QCJob_Date,G.User_FullName As 'Job_User',B.QC_Date,B.QC_WorkDate" & Environment.NewLine
                strSql &= " ,E.DCode_SDesc As 'QC_Line',B.WorkOrderNo,B.Model,B.SN,C.QCResult,F.DCode_SDesc As 'FailCode (Short)'" & Environment.NewLine
                strSql &= " ,F.DCode_LDesc As 'FailCode',B.Note As 'Fail Details',if(B.IsLast=0,'No','Yes') As 'IsLastQCTested'" & Environment.NewLine
                strSql &= " ,H.User_FullName As 'QC_User'" & Environment.NewLine
                strSql &= " ,A.QCJob_ID,A.User_ID As 'Job_User_ID',B.User_ID As 'QC_User_ID',B.TFFK_QC_ID,B.QC_Line_DCode_ID,B.FailCode_DCode_ID,B.QCResult_ID,B.QC_Iteration,IsLast" & Environment.NewLine
                strSql &= " From production.tTFFK_QC_Jobs A" & Environment.NewLine
                strSql &= " Inner Join production.tTFFK_QC B On A.QCJob_ID=B.QCJob_ID" & Environment.NewLine
                strSql &= " Inner Join production.lqcresult C On B.QCResult_ID=C.QCResult_ID" & Environment.NewLine
                strSql &= " Inner Join production.lcodesdetail E On B.QC_Line_DCOde_ID=E.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join production.lcodesdetail F On B.FailCode_DCode_ID=F.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join security.tUsers G On A.User_ID=G.User_ID" & Environment.NewLine
                strSql &= " Left Join security.tUsers H On B.User_ID=H.User_ID" & Environment.NewLine
                strSql &= " Where B.IsLast=1 And B.QCResult_ID In (" & strPass1Fail2 & ") AND A.QCJob_ID=" & iQCJob_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function TFFK_QC_InsertJob(ByVal strJob As String, _
                                             ByVal iQty As Int32, _
                                             ByVal iUserID As Integer, _
                                             ByVal strDateTime As String, _
                                             ByRef bNewJob As Boolean, _
                                             ByRef iPrimKey_jobID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt, dtTmp As DataTable
            Dim i As Integer = 0
            Dim iPrimKey As Integer = 0

            Try
                strJob = strJob.Replace("'", "''")

                strSql = "SELECT * from production.tTFFK_QC_Jobs  WHERE QCJobNumber= '" & strJob & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If Not dt.Rows.Count > 0 Then 'new job
                    strSql = "INSERT INTO production.tTFFK_QC_Jobs (QCJobNumber,QCJob_Quantity,User_ID,QCJob_Date)" & _
                             " VALUES ('" & strJob & "'," & iQty & "," & iUserID & ",'" & strDateTime & "');"

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "SELECT LAST_INSERT_ID();"
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    iPrimKey_jobID = dtTmp.Rows(0).Item(0)

                    If iPrimKey_jobID > 0 Then
                        bNewJob = True
                    Else
                        bNewJob = False
                    End If
                Else
                    bNewJob = False
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing : dtTmp = Nothing
            End Try
        End Function

        Public Function TFFK_QC_SaveResult(ByVal iJob_ID As Integer, _
                                             ByVal bIsPass As Boolean, _
                                             ByVal iQCLineID As Integer, _
                                             ByVal strWO As String, _
                                             ByVal strModel As String, _
                                             ByVal strSN As String, _
                                             ByVal iFailCode_ID As Integer, _
                                             ByVal strNote As String, _
                                             ByVal iUserID As Integer, _
                                             ByVal strDateTime As String, _
                                             ByVal strDate As String, _
                                             ByVal strPC_Name As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iIteration As Integer = 0
            Dim iQCResult As Integer = 0
            Dim stPK_TFFK_QC_IDs As String = ""
            Dim row As DataRow

            Try
                strSN = strSN.Replace("'", "''") : strWO = strWO.Replace("'", "''")
                strModel = strModel.Replace("'", "''") : strNote = strNote.Replace("'", "''")
                strPC_Name = strPC_Name.Replace("'", "''")

                strSql = "SELECT * from production.tTFFK_QC WHERE QCJob_ID= " & iJob_ID & " AND SN= '" & strSN & "' ORDER BY QC_Iteration DESC;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If Not dt.Rows.Count > 0 Then
                    iIteration = 1
                Else
                    For Each row In dt.Rows
                        If stPK_TFFK_QC_IDs.Length = 0 Then
                            stPK_TFFK_QC_IDs = row("TFFK_QC_ID")
                        Else
                            stPK_TFFK_QC_IDs &= "," & row("TFFK_QC_ID")
                        End If
                    Next
                    strSql = "UPDATE production.tTFFK_QC SET IsLast=0 WHERE TFFK_QC_ID IN (" & stPK_TFFK_QC_IDs & ");"
                    Me._objDataProc.ExecuteNonQuery(strSql)

                    iIteration = Convert.ToInt16(dt.Rows(0).Item("QC_Iteration")) + 1
                End If

                If bIsPass Then iQCResult = 1 Else iQCResult = 2

                strSql = "INSERT INTO production.tTFFK_QC" & _
                        " (QC_Date,QC_WorkDate,QC_Iteration,IsLast,QCResult_ID,User_ID,QC_Line_DCode_ID,QCJob_ID,WorkOrderNo,Model,SN,FailCode_DCode_ID,Note, PC_Name)" & _
                        " VALUES ('" & strDateTime & "','" & strDate & "'," & iIteration & ",1," & iQCResult & _
                        "," & iUserID & "," & iQCLineID & "," & iJob_ID & ",'" & strWO & "','" & strModel & "','" & strSN & "'," & iFailCode_ID & ",'" & strNote & "','" & strPC_Name & "');"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getExistingJobs() As DataTable
            Dim strSql As String = ""
            Dim dt, dtTmp, dtOk As DataTable
            Dim row As DataRow
            Dim iJob_ID As Integer = 0
            Dim bFound As Boolean = False

            Try
                strSql = "Select * From production.tTFFK_QC_Jobs;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    dtOk = dt.Clone
                    For Each row In dt.Rows
                        iJob_ID = row("QCJob_ID")
                        strSql = "Select * from production.tTFFK_QC Where IsLast=1 And QCJob_ID=" & iJob_ID & " Limit 1;"
                        dtTmp = Me._objDataProc.GetDataTable(strSql)
                        If dtTmp.Rows.Count > 0 Then
                            bFound = True
                            dtOk.ImportRow(row)
                        End If
                    Next
                    If Not bFound Then 'nothing
                        strSql = "Select * From production.tTFFK_QC_Jobs Limit 0;"
                        dtOk = Me._objDataProc.GetDataTable(strSql)
                    End If
                Else
                        dtOk = dt.Copy
                End If

                Return dtOk

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getTFFK_QC_Report(ByVal bAllColumns As Boolean, ByVal strBeginDate As String, ByVal strEndDate As String, Optional ByVal strJob_IDs As String = "") As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select A.QCJobNumber,A.QCJob_Quantity,A.QCJob_Date,G.User_FullName As 'Job_User',B.QC_Date,B.QC_WorkDate" & Environment.NewLine
                strSql &= " ,E.DCode_SDesc As 'QC_Line',B.WorkOrderNo,B.Model,B.SN,C.QCResult,F.DCode_SDesc As 'FailCode (Short)'" & Environment.NewLine
                strSql &= " ,F.DCode_LDesc As 'FailCode',B.Note As 'Fail Details',if(B.IsLast=0,'No','Yes') As 'IsLastQCTested'" & Environment.NewLine
                strSql &= " ,H.User_FullName As 'QC_User'" & Environment.NewLine
                strSql &= " ,A.QCJob_ID,A.User_ID As 'Job_User_ID',B.User_ID As 'QC_User_ID',B.TFFK_QC_ID,B.QC_Line_DCode_ID,B.FailCode_DCode_ID,B.QCResult_ID,B.QC_Iteration,IsLast" & Environment.NewLine
                strSql &= " From production.tTFFK_QC_Jobs A" & Environment.NewLine
                strSql &= " Inner Join production.tTFFK_QC B On A.QCJob_ID=B.QCJob_ID" & Environment.NewLine
                strSql &= " Inner Join production.lqcresult C On B.QCResult_ID=C.QCResult_ID" & Environment.NewLine
                strSql &= " Inner Join production.lcodesdetail E On B.QC_Line_DCOde_ID=E.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join production.lcodesdetail F On B.FailCode_DCode_ID=F.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join security.tUsers G On A.User_ID=G.User_ID" & Environment.NewLine
                strSql &= " Left Join security.tUsers H On B.User_ID=H.User_ID" & Environment.NewLine
                If strJob_IDs.Length > 0 Then
                    strSql &= " Where B.IsLast=1 And B.QCResult_ID in (1,2) AND A.QCJob_ID in (" & strJob_IDs & "); " & Environment.NewLine
                Else
                    strSql &= " Where B.IsLast=1 And B.QCResult_ID in (1,2) AND B.QC_WorkDate Between '" & strBeginDate & " 00:00:00' And '" & strEndDate & " 23:59:59';"
                End If

                dt = Me._objDataProc.GetDataTable(strSql)

                If Not bAllColumns Then
                    dt.Columns.Remove("QCJob_Quantity")
                    dt.Columns.Remove("QCJob_Date")
                    dt.Columns.Remove("Job_User")
                    dt.Columns.Remove("QC_Date")
                    dt.Columns.Remove("FailCode (Short)")
                    dt.Columns.Remove("IsLastQCTested")
                    dt.Columns.Remove("QCJob_ID")
                    dt.Columns.Remove("Job_User_ID")
                    dt.Columns.Remove("QC_User_ID")
                    dt.Columns.Remove("TFFK_QC_ID")
                    dt.Columns.Remove("QC_Line_DCode_ID")
                    dt.Columns.Remove("FailCode_DCode_ID")
                    dt.Columns.Remove("QCResult_ID")
                    dt.Columns.Remove("QC_Iteration")
                    dt.Columns.Remove("IsLast")
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function CreateExcelReport(ByVal dt As DataTable, ByVal strRptName As String, ByVal bAllColumns As Boolean) As Integer
            Dim strSql As String = ""
            Dim objExcelRpt As ExcelReports

            Try
                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    If bAllColumns Then
                        objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"})
                    Else
                        objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"})
                    End If
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function CreateExcelReportPivot(ByVal dt As DataTable, ByVal strRptName As String, ByVal bAllColumns As Boolean) As Integer
            Dim strSql As String = ""
            Dim objExcelRpt As ExcelReports
 
        End Function

    End Class
End Namespace
