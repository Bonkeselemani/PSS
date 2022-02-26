Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing.Printing
Imports System.Windows.Forms

Namespace Buisness
    Public Class EmployeeIncentive
        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '****************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************************************************************
#End Region

        '****************************************************************************************************
        Public Function LoadEmployeeHours(ByVal strFilePath As String) As Integer
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim dt1 As New DataTable()
            Dim dt2 As DataTable
            Dim R1 As DataRow
            Dim sConnectionstring As String = ""
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim NewCol As DataColumn
            Dim iHours As Decimal = 0

            Try
                '***********************************************************
                'Get data from the excel file in to a data table
                '***********************************************************
                'Crate the connection string
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()
                objCmdSelect.CommandText = ("SELECT * FROM [hours$] where [ClockNumber] is not NULL")
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dt1)
                '***********************************************************
                'Add a new columns to dt1
                '***********************************************************
                NewCol = New DataColumn("EmployeeName")
                NewCol.DataType = System.Type.GetType("System.String")
                NewCol.DefaultValue = ""
                NewCol.MaxLength = 50
                dt1.Columns.Add(NewCol)
                If Not IsNothing(NewCol) Then
                    NewCol.Dispose()
                    NewCol = Nothing
                End If
                '*******************************
                NewCol = New DataColumn("IsRefurber")
                NewCol.DataType = System.Type.GetType("System.Int32")
                NewCol.DefaultValue = 0
                dt1.Columns.Add(NewCol)
                If Not IsNothing(NewCol) Then
                    NewCol.Dispose()
                    NewCol = Nothing
                End If
                '********************************
                'Validate data
                '*******************************
                ValidateFileData(dt1)

                '***************************************************
                'Write hours to ttechhours
                '***************************************************
                For Each R1 In dt1.Rows

                    If R1("IsRefurber") = 1 Then
                        '************************************
                        If IsDBNull(R1("Hours")) Then
                            iHours = 0
                        Else
                            If Not IsNumeric(R1("Hours")) Then
                                iHours = 0
                            Else
                                iHours = R1("Hours")
                            End If
                        End If

                        '************************************
                        'Check for duplicate
                        '************************************
                        strsql = "select * from ttechhours " & Environment.NewLine
                        strsql &= "where ucase(trim(techhours_username)) = '" & UCase(Trim(R1("EmployeeName"))) & "'" & Environment.NewLine
                        strsql &= " and trim(techhours_date) = '" & Format(R1("PunchDate"), "yyyy-MM-dd") & "'" & Environment.NewLine
                        strsql &= " and employee_no = " & R1("ClockNumber") & ";"
                        dt2 = Me._objDataProc.GetDataTable(strsql)

                        If dt2.Rows.Count > 0 Then
                            'Update
                            strsql = "Update ttechhours " & Environment.NewLine
                            strsql &= "set techhours_hours = " & iHours & Environment.NewLine
                            strsql &= "where techhours_username = " & " '" & Trim(R1("EmployeeName")) & "'" & Environment.NewLine
                            strsql &= " and techhours_date = " & "'" & Format(R1("PunchDate"), "yyyy-MM-dd") & "'" & Environment.NewLine
                            strsql &= " and employee_no = " & R1("ClockNumber") & ";"
                            i += Me._objDataProc.ExecuteNonQuery(strsql)
                        Else
                            'Insert
                            strsql = "Insert into ttechhours ( " & Environment.NewLine
                            strsql &= "techhours_username,  " & Environment.NewLine
                            strsql &= "techhours_date,  " & Environment.NewLine
                            strsql &= "techhours_hours,  " & Environment.NewLine
                            strsql &= "employee_no " & Environment.NewLine
                            strsql &= ") values ( " & Environment.NewLine
                            strsql &= "'" & Trim(R1("EmployeeName")) & "', " & Environment.NewLine
                            strsql &= "'" & Format(R1("PunchDate"), "yyyy-MM-dd") & "', " & Environment.NewLine
                            strsql &= iHours & ", " & Environment.NewLine
                            strsql &= R1("ClockNumber") & Environment.NewLine
                            strsql &= ");"
                            i += Me._objDataProc.ExecuteNonQuery(strsql)

                        End If

                        ''************************************
                        ''Insert into ttechhours
                        ''************************************
                        'strsql = "Replace into ttechhours ( " & Environment.NewLine
                        'strsql &= "techhours_username,  " & Environment.NewLine
                        'strsql &= "techhours_date,  " & Environment.NewLine
                        'strsql &= "techhours_hours,  " & Environment.NewLine
                        'strsql &= "employee_no " & Environment.NewLine
                        'strsql &= ") values ( " & Environment.NewLine
                        'strsql &= "'" & Trim(R1("EmployeeName")) & "', " & Environment.NewLine
                        'strsql &= "'" & Format(R1("PunchDate"), "yyyy-MM-dd") & "', " & Environment.NewLine
                        'strsql &= iHours & ", " & Environment.NewLine
                        'strsql &= R1("ClockNumber") & Environment.NewLine
                        'strsql &= ");"

                        'GobjMisc._SQL = strsql
                        'i += GobjMisc.ExecuteNonQuery

                        ''************************************

                        If Not IsNothing(dt2) Then
                            dt2.Dispose()
                            dt2 = Nothing
                        End If
                    End If

                Next R1

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(NewCol) Then
                    NewCol.Dispose()
                    NewCol = Nothing
                End If
                NewCol = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If

                'Invoke Garbage Collector
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '****************************************************************************************************
        Private Sub ValidateFileData(ByRef dt1 As DataTable)
            Dim dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim strsql As String = ""

            Dim strFilePath As String = "C:\MissingEmpNum.txt"
            Dim booVar As Boolean = False
            Dim ObjPrinting As New MyLib.Printing()
            Dim j As Integer = 0
            Dim iPrevEmpNo As Decimal = 0

            Try
                '**************************************************************
                'Initialize the text file
                If Len(Dir(strFilePath)) > 0 Then
                    Kill(strFilePath)
                End If
                FileOpen(1, strFilePath, OpenMode.Append)
                PrintLine(1, "Employee Numbers missing in PSS Database")
                PrintLine(1, "")

                '***********************************************************
                'Get Employee Name from security database for all refurbers
                strsql = "Select * from security.tusers where is_user_refurber = 1;"
                dt2 = Me._objDataProc.GetDataTable(strsql)

                '///***************************************************************************************************************
                '///Loopthrough dt1 and find out the employee numbers and if it is refurber or not
                '///***************************************************************************************************************
                For Each R1 In dt1.Rows
                    R1.BeginEdit()
                    '***********************************************************
                    'NULL Field Validation
                    '***********************************************************
                    If IsDBNull(R1("ClockNumber")) Then
                        Throw New Exception("Clock Number can not be blank.")
                    End If
                    If IsDBNull(R1("PunchDate")) Then
                        Throw New Exception("Punch Date can not be blank.")
                    End If
                    '***********************************************************
                    'Assign EmployeeName and IsRefurber valude
                    '***********************************************************
                    For Each R2 In dt2.Rows
                        If R1("ClockNumber") = R2("employeeNo") Then
                            R1("EmployeeName") = Trim(R2("user_fullname"))
                            R1("IsRefurber") = R2("is_user_refurber")
                            Exit For
                        End If
                    Next R2
                    '***********************************************************
                    'Write mising employee to text file
                    '***********************************************************
                    If Trim(R1("EmployeeName")) = "" Then
                        If iPrevEmpNo <> R1("ClockNumber") Then
                            PrintLine(1, R1("ClockNumber"))
                            booVar = True
                        End If
                    End If

                    '***********************************************************
                    'Reset loop variable
                    '***********************************************************
                    iPrevEmpNo = R1("ClockNumber")
                    R2 = Nothing
                    R1.EndEdit()
                    '***********************************************************
                Next R1
                '///**************************************************************************************************
                dt1.AcceptChanges()

                '*************************************************
                'Print the file
                '*************************************************
                Reset()
                If booVar = True Then
                    'uncomment this line if you need the report printed 
                    'ObjPrinting.DoPrint(strFilePath)
                    '("There are ""Employee Numbers"" in the file that do not exist in PSS Database. A report is being printed. Please contact ""Operations"" with that report.")
                End If
                '*************************************************
            Catch ex As Exception
                Throw ex
            Finally
                Reset()
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                ObjPrinting = Nothing

                'Invoke Garbage Collector
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '****************************************************************************************************
        Public Function GetIncentivePayOutDataByWeek(ByVal strStartDate As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT  Group_Desc as 'Group', cc_desc as 'Cell', ccsd_NetUP as 'Net Produce Qty', ccsd_TeamHrs as 'Team Hours',  ccsd_NetUPH as 'Net UPH'" & Environment.NewLine
                strSql &= ", ccsd_Tier1UPHGoal AS 'Tier 1 UPH Goal', ccsd_Tier2UPHGoal as 'Tier 2 UPH Goal', ccsd_Tier1Rate as 'Tier 1 Rate', ccsd_Tier2Rate as 'Tier 2 Rate'" & Environment.NewLine
                strSql &= ", ccsd_PayoutRate as 'Payout Rate', ccsd_PayoutAmt as 'Total Payout Amount',AQL_FailRate_Allowance,AQL_FailRate_Actual,AQL_FailNumber,AQL_TotalTestNumber, ccsd_StartDate as 'Start Date', ccsd_EndDate as 'End Date' " & Environment.NewLine
                strSql &= ",tcostcenter.group_id,tcc_statdata.cc_id" & Environment.NewLine
                strSql &= "FROM tcc_statdata  INNER JOIN tcostcenter ON tcc_statdata.cc_id = tcostcenter.cc_id" & Environment.NewLine
                strSql &= "INNER JOIN lgroups ON tcostcenter.group_id = lgroups.Group_ID" & Environment.NewLine
                strSql &= "WHERE ccsd_StartDate = '" & strStartDate & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetEmployeeHoursByWeek(ByVal strStartDate As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Group_Desc as 'Group', cc_desc as 'Cell', cceh_TotalHrs as 'Total Hours', cceh_PPAmt as 'Pay Amount'" & Environment.NewLine
                strSql &= ",AQL_FailRate_Allowance,AQL_FailRate_Actual,AQL_FailNumber,AQL_TotalTestNumber, EmployeeNo as 'EE #', LastName as 'Last Name', FirstName as 'First Name', cceh_StartDate as 'Start Date', cceh_EndDate as 'End Date'" & Environment.NewLine
                strSql &= ",tcostcenter.group_id,tcc_stateehrs.cc_id" & Environment.NewLine
                strSql &= "FROM tcc_stateehrs " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tcc_stateehrs.cc_id = tcostcenter.cc_id" & Environment.NewLine
                strSql &= "INNER JOIN lgroups ON tcostcenter.group_id = lgroups.Group_ID" & Environment.NewLine
                strSql &= "INNER JOIN security.tlegianteedata ON tcc_stateehrs.EmployeeNo = security.tlegianteedata.EmployeeNum" & Environment.NewLine
                strSql &= "WHERE tcc_stateehrs.cceh_StartDate = '" & strStartDate & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Sub CreateCSVFile(ByVal dt As DataTable, ByVal strWeekStartDate As String)
            Dim strRptFilePath As String = ""
            Dim i As Integer = 0
            Dim R1 As DataRow, col As DataColumn
            Dim strData As String = ""
            Dim objWriter As StreamWriter
            Dim SaveFileDialog1 As SaveFileDialog

            Try


                If dt.Rows.Count > 0 Then
                    'Get header
                    For Each col In dt.Columns
                        If i = 0 Then
                            strData &= col.ColumnName
                        Else
                            strData &= "," & col.ColumnName
                        End If
                        i += 1
                    Next
                    strData &= vbCrLf

                    'Get data rows

                    For Each R1 In dt.Rows
                        i = 0
                        For Each col In dt.Columns
                            If i = 0 Then
                                strData &= R1(col.ColumnName)
                            Else
                                strData &= "," & R1(col.ColumnName)
                            End If
                            i += 1
                        Next
                        strData &= vbCrLf
                    Next

                    If strData <> "" Then
                        SaveFileDialog1 = New SaveFileDialog()
                        SaveFileDialog1.FileName = dt.TableName & " Week" & strWeekStartDate & ".csv"

                        SaveFileDialog1.Filter = "CSV (Comma delimited)(*.csv)| (*.*)"
                        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                            strRptFilePath = Trim(SaveFileDialog1.FileName)
                            If strRptFilePath.Trim.Length > 0 Then
                                If Len(Dir(strRptFilePath)) > 0 Then
                                    Kill(strRptFilePath)
                                End If
                                objWriter = New StreamWriter(strRptFilePath)
                                objWriter.Write(strData)
                            End If
                            objWriter.Close()
                        End If
                    Else
                        MessageBox.Show("No data for report", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("No Productivity Pay for the selected date period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(SaveFileDialog1) Then
                    SaveFileDialog1.Dispose()
                    SaveFileDialog1 = Nothing
                End If
 
                If Not IsNothing(objWriter) Then
                    objWriter = Nothing
                End If
                R1 = Nothing
                dt = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '****************************************************************************************************
        Public Sub CreateCSVFileProductionPay(ByVal dt As DataTable, ByVal strWeekStartDate As String)
            Dim strRptFilePath As String = ""
            Dim i As Integer = 0
            Dim R1 As DataRow, col As DataColumn
            Dim strData As String = ""
            Dim objWriter As StreamWriter
            Dim SaveFileDialog1 As SaveFileDialog
            Dim strEE As String = ""
            Dim strGroup As String = ""
            Dim strHeaders() As String = {"Employee ID", "Report Date", "Department ID", "Pay Type", "Amount"}

            Try

                If dt.Rows.Count > 0 Then

                    'Add header
                    For i = 0 To strHeaders.Length - 1
                        strData &= strHeaders(i) & ","
                    Next i
                    strData &= vbCrLf

                    'Get data rows
                    For Each R1 In dt.Rows
                        strEE = "" : strGroup = ""
                        If Not R1.IsNull("Pay Amount") AndAlso R1("Pay Amount") > 0 Then
                            strEE = R1("EE #")
                            strEE = strEE.PadLeft(6, "0"c)
                            If R1("Group").ToUpper = "MESSAGING".ToUpper Then
                                strGroup = "520"
                            ElseIf R1("Group").ToUpper = "TRACFONE".ToUpper Then
                                strGroup = "585"
                            End If
                            strData &= strEE & "," & R1("End Date") & "," & strGroup & _
                                       ",Prod Pay," & R1("Pay Amount") & vbCrLf
                        End If
                    Next

                    If strData <> "" Then
                        SaveFileDialog1 = New SaveFileDialog()
                        SaveFileDialog1.FileName = dt.TableName & " Week" & strWeekStartDate & ".csv"

                        SaveFileDialog1.Filter = "CSV (Comma delimited)(*.csv)| (*.*)"
                        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                            strRptFilePath = Trim(SaveFileDialog1.FileName)
                            If strRptFilePath.Trim.Length > 0 Then
                                If Len(Dir(strRptFilePath)) > 0 Then
                                    Kill(strRptFilePath)
                                End If
                                objWriter = New StreamWriter(strRptFilePath)
                                objWriter.Write(strData)
                            End If
                            objWriter.Close()
                        End If
                    Else
                        MessageBox.Show("No data for report", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("No Productivity Pay for the selected date period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(SaveFileDialog1) Then
                    SaveFileDialog1.Dispose()
                    SaveFileDialog1 = Nothing
                End If

                If Not IsNothing(objWriter) Then
                    objWriter = Nothing
                End If
                R1 = Nothing
                dt = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '****************************************************************************************************

    End Class
End Namespace

