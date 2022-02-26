Option Explicit On 

Imports System.Math
Imports System.Windows.Forms
Imports System.Data.OleDb

Namespace Buisness

    Public Class QC
        Private objMyLib As MyLib.Utility
        Private objMisc As Production.Misc
        Private arrSplitLine(0)
        Public strRptPath As String = ""
        Private strShiftStart As String = ""
        Private strShiftEnd As String = ""

        '***************************************************
        Private strShift As String = ""
        Public Property Shift() As String
            Get
                Return strShift
            End Get
            Set(ByVal Value As String)
                strShift = Value
            End Set
        End Property

        '**************************************************************
        Public Function ValidateManufDateCode(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strUsrInputDateCode As String = ""
            Dim booResult As Boolean = False

            Try
                strSql = "SELECT * FROM twarehousereceive " & Environment.NewLine
                strSql &= "WHERE WHR_ManufDateCode is not null  " & Environment.NewLine
                strSql &= "AND DEVICE_ID = " & iDevice_ID & " " & Environment.NewLine

                dt = Me.objMisc.GetDataTable(strSql)

                If IsNothing(dt) Then
                    booResult = True
                ElseIf dt.Rows.Count = 0 Then
                    booResult = True
                ElseIf dt.Rows.Count > 0 AndAlso IsDBNull(dt.Rows(0)("WHR_ManufDateCode")) Then
                    booResult = True
                Else
                    While True
                        strUsrInputDateCode = InputBox("Enter manufacture date in 4 digits format ""MMYY"":", "Manufacture Date").ToString.Trim.ToUpper
                        If strUsrInputDateCode = dt.Rows(0)("WHR_ManufDateCode").ToString.Trim.ToUpper Then
                            booResult = True
                            Exit While
                        ElseIf MessageBox.Show("Incorrect manufacture date. Would you like to try again?", "Manufacture Date", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                            Exit While
                        End If
                    End While
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '**************************************************************
        Public Function GetTotalGoodUnitsByLocCC(ByVal iLoc_ID As Integer, _
                                                 ByVal iCC_ID As Integer, _
                                                 ByVal iCCGrpID As Integer) As Integer
            Dim strSql As String = ""

            Try
                If iCCGrpID = 1 Then
                    strSql = "SELECT distinct tdevice.Device_ID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tqc ON tdevice.Device_ID = tqc.device_id " & Environment.NewLine
                    strSql &= "WHERE tdevice.cc_id = " & iCC_ID & Environment.NewLine
                    'Only refurbish devices
                    strSql &= "AND (Ship_ID IS NULL OR Ship_ID <> 9999919) " & Environment.NewLine
                    strSql &= "AND QCType_ID = 1 AND tqc.qcresult_id = 1 " & Environment.NewLine
                    strSql &= "AND tqc.QC_WorkDate = DATE_FORMAT(NOW(), '%Y-%m-%d') " & Environment.NewLine
                Else
                    strSql = "SELECT distinct tdevice.Device_ID " & Environment.NewLine
                    strSql &= ", if( BillCode_Rule is null, 0, max(BillCode_Rule) ) as BillCode_Rule " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tqc ON tdevice.Device_ID = tqc.device_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.cc_id = " & iCC_ID & Environment.NewLine
                    'Only refurbish devices
                    strSql &= "AND ( billcode_rule is null OR BillCode_Rule NOT IN ( 1, 2, 8) ) " & Environment.NewLine
                    strSql &= "AND QCType_ID = 1 AND tqc.qcresult_id = 1 " & Environment.NewLine
                    strSql &= "AND tqc.QC_WorkDate = DATE_FORMAT(NOW(), '%Y-%m-%d') " & Environment.NewLine
                    strSql &= "GROUP BY tdevice.Device_ID " & Environment.NewLine
                    strSql &= "HAVING BillCode_Rule NOT IN (1, 2, 3, 8, 9) "
                End If
                Return Me.objMisc.GetDataTable(strSql).Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function HasBillDate(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String
            Dim iResutl As Integer

            Try
                strSql = "SELECT count(*) as cnt FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & Environment.NewLine
                strSql &= "AND Device_DateBill is not null AND Device_DateBill <> '0000-00-00 00:00:00' AND Device_DateBill <> '' ;"
                iResutl = Me.objMisc.GetIntValue(strSql)
                If iResutl = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function IsQCPassed(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String
            Dim iResutl As Integer

            Try
                strSql = "SELECT count(*) as cnt FROM tqc " & Environment.NewLine
                strSql &= "WHERE Device_id = " & iDevice_ID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "AND QCType_ID NOT IN (0, 4);"
                iResutl = Me.objMisc.GetIntValue(strSql)
                If iResutl = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function IsAQLPassed(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String
            Dim iResutl As Integer

            Try
                strSql = "SELECT count(*) as cnt FROM tqc " & Environment.NewLine
                strSql &= "WHERE Device_id = " & iDevice_ID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "AND QCType_ID = 4;"
                iResutl = Me.objMisc.GetIntValue(strSql)
                If iResutl = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function ResetMsgQCResult(ByVal iDevice_ID As Integer, _
                                         ByVal strQCType As String) As Integer
            Dim strSql As String = ""

            Try
                If strQCType = "Functional" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "SET qcresult_id = null, qcwork_date = null " & Environment.NewLine
                    strSql &= "WHERE Device_ID =  " & iDevice_ID & " " & Environment.NewLine
                ElseIf strQCType = "AQL" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "SET aqlreject = null, aqlreject_date = null " & Environment.NewLine
                    strSql &= "WHERE Device_ID =  " & iDevice_ID & " " & Environment.NewLine
                End If

                objMisc._SQL = strSql
                Return objMisc.ExecuteNonQuery()

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function CheckAQLFailed(ByVal strDevice_SN As String) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim booAQLFail As Boolean = False

            Try
                strSql = "SELECT tqc.* " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tqc ON tdevice.Device_ID = tqc.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lqctype ON tqc.QCType_ID = lqctype.QCType_ID " & Environment.NewLine
                strSql &= "WHERE Device_SN =  '" & strDevice_SN & "' " & Environment.NewLine
                strSql &= "AND device_dateship is null " & Environment.NewLine
                strSql &= "AND QCType = 'AQL' " & Environment.NewLine
                strSql &= "ORDER BY QC_ID ASC;"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If R1("QCResult_ID") = 2 Then   'Fail
                        booAQLFail = True
                    ElseIf R1("QCResult_ID") = 1 Then   'Pass
                        booAQLFail = False
                        Exit For
                    End If
                Next R1

                Return booAQLFail
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        Public Function CheckDeviceCompleted(ByVal iDevice_ID As Integer) As Integer
            Dim dt1 As DataTable

            Try
                objMisc._SQL = "Select * from tcellopt where device_id = " & iDevice_ID & " and CellOpt_RefurbCompleteDt is not null;"
                dt1 = objMisc.GetDataTable
                Return dt1.Rows.Count
            Catch ex As Exception
                Throw New Exception("Buisness.QC.CheckDeviceCompleted(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        '***************************************************
        Public Function LoadQCFailRate(ByVal strWorkdate As String, _
                                        ByVal iUserID As Integer, _
                                        ByVal iQCTypeID As Integer) As DataTable

            Dim strsql As String = ""
            Dim dt1 As DataTable = Nothing
            Dim R1 As DataRow
            Dim iFail As Integer = 0
            Dim iPass As Integer = 0
            Dim iPrevIteration As Integer = 0
            'Dim iPrevResult As Integer = 0
            Dim i As Integer = 0

            Dim dtNewTable As DataTable
            Dim ColNew As DataColumn
            Dim NewRow As DataRow

            Try

                '**********************************************
                strsql = "select  tqc.qc_Iteration as Iteration, lqcresult.QCResult as Result, count(*) as 'DeviceCount' from tqc " & Environment.NewLine
                strsql += "inner join lqcresult on tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strsql += "where inspector_ID = " & iUserID & " and " & Environment.NewLine
                strsql += "QCType_ID = " & iQCTypeID & " and " & Environment.NewLine
                strsql += "qc_workdate = '" & strWorkdate & "' " & Environment.NewLine
                strsql += "group by tqc.qc_Iteration, tqc.qcresult_id " & Environment.NewLine
                strsql += "order by tqc.qc_Iteration, tqc.qcresult_id;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                '********************************************************
                'Create a a new datatable
                '********************************************************
                If Not IsNothing(dtNewTable) Then
                    dtNewTable.Dispose()
                    dtNewTable = Nothing
                End If

                dtNewTable = New DataTable()    'Create new datatable

                'Iteration
                ColNew = New DataColumn("Iteration")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing
                'Pass
                ColNew = New DataColumn("Pass")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing
                'Fail
                ColNew = New DataColumn("Fail")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing
                'Fail Rate
                ColNew = New DataColumn("Fail Rate")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                If dt1.Rows.Count = 0 Then
                    'Throw New Exception("There is no data for the 'User' and the 'Work Date'.")
                    Return dtNewTable
                End If

                '********************************************************
                'Seperate Passed and failed
                For Each R1 In dt1.Rows

                    If iPrevIteration = 0 Then
                        If R1("Result") = "Pass" Then
                            iPass = R1("DeviceCount")
                        ElseIf R1("Result") = "Fail" Then
                            iFail = R1("DeviceCount")
                        End If
                    Else
                        If R1("Iteration") = iPrevIteration Then
                            If R1("Result") = "Pass" Then
                                iPass = R1("DeviceCount")
                            ElseIf R1("Result") = "Fail" Then
                                iFail = R1("DeviceCount")
                            End If
                        Else
                            '***********************
                            'Add new row
                            NewRow = dtNewTable.NewRow()
                            NewRow("Iteration") = iPrevIteration
                            NewRow("Pass") = iPass
                            NewRow("Fail") = iFail
                            NewRow("Fail Rate") = CStr(Round((iFail / (iFail + iPass)) * 100, 2)) & "%"
                            dtNewTable.Rows.Add(NewRow)
                            NewRow = Nothing
                            dtNewTable.AcceptChanges()

                            iPass = 0
                            iFail = 0
                            '***********************
                            If R1("Result") = "Pass" Then
                                iPass = R1("DeviceCount")
                            ElseIf R1("Result") = "Fail" Then
                                iFail = R1("DeviceCount")
                            End If
                            '***********************
                        End If
                    End If

                    iPrevIteration = R1("Iteration")
                    i += 1
                Next R1
                '***********************
                'Add last row
                NewRow = dtNewTable.NewRow()
                NewRow("Iteration") = iPrevIteration
                NewRow("Pass") = iPass
                NewRow("Fail") = iFail
                NewRow("Fail Rate") = CStr(Round((iFail / (iFail + iPass)) * 100, 2)) & "%"     '(iFail / (iFail + iPass)) * 100
                dtNewTable.Rows.Add(NewRow)
                NewRow = Nothing
                dtNewTable.AcceptChanges()

                iPass = 0
                iFail = 0
                '********************************************************

                Return dtNewTable
            Catch ex As Exception
                Throw New Exception("Buisness.QC.LoadQCFailRate(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Function

        '***************************************************
        'Deletes QC history
        '***************************************************
        Public Function DeleteQCHistory(ByVal iQC_ID As Integer, _
                                        ByVal iUserID As Integer, _
                                        ByVal strMachineName As String) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                '********************
                'Get QC History data
                strsql = "Select * from tqc where qc_id = " & iQC_ID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                Else
                    Exit Function
                End If

                'Make an entry in to QC_History journal
                strsql = "Insert into tqcjournal " & Environment.NewLine
                strsql += "(" & Environment.NewLine

                strsql += "QC_ID, " & Environment.NewLine
                strsql += "QC_Date, " & Environment.NewLine
                strsql += "QC_WorkDate, " & Environment.NewLine
                strsql += "QC_Iteration, " & Environment.NewLine
                strsql += "QCType_ID, " & Environment.NewLine
                strsql += "QCResult_ID, " & Environment.NewLine
                strsql += "Inspector_ID, " & Environment.NewLine
                strsql += "Tech_ID, " & Environment.NewLine
                strsql += "Device_ID, " & Environment.NewLine
                strsql += "DCode_ID, " & Environment.NewLine
                strsql += "QCJ_Machine, " & Environment.NewLine
                strsql += "QCJ_Date, " & Environment.NewLine
                strsql += "QCJ_UserID " & Environment.NewLine

                strsql += ") values (" & Environment.NewLine

                strsql += R1("QC_ID") & ", " & Environment.NewLine
                strsql += "'" & Format(R1("QC_Date"), "yyyy-MM-dd HH:mm:ss") & "', " & Environment.NewLine
                strsql += "'" & Format(R1("QC_WorkDate"), "yyyy-MM-dd") & "', " & Environment.NewLine
                strsql += R1("QC_Iteration") & ", " & Environment.NewLine
                strsql += R1("QCType_ID") & ", " & Environment.NewLine
                strsql += R1("QCResult_ID") & ", " & Environment.NewLine
                strsql += R1("Inspector_ID") & ", " & Environment.NewLine
                strsql += R1("Tech_ID") & ", " & Environment.NewLine
                strsql += R1("Device_ID") & ", " & Environment.NewLine
                strsql += R1("DCode_ID") & ", " & Environment.NewLine
                strsql += "'" & strMachineName & "', " & Environment.NewLine
                strsql += "'" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "', " & Environment.NewLine
                strsql += iUserID & Environment.NewLine

                strsql += ");"

                objMisc._SQL = strsql
                i = objMisc.ExecuteNonQuery

                '********************
                'Delete QC history
                strsql = ""
                strsql = "Delete from tqc where QC_ID = " & iQC_ID & ";"
                objMisc._SQL = strsql
                Return objMisc.ExecuteNonQuery
                '********************
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                DisposeDT(dt1)
            End Try
        End Function

        '***************************************************
        'Get QC Numbers
        '***************************************************
        Public Function GetQCPASSNumber(ByVal iInspectorID As Integer, _
                                        ByVal iShiftID As Integer, _
                                        ByVal iQCType_ID As Integer, _
                                        ByVal iGroupID As Integer) As DataTable

            Dim strsql As String = ""

            Try
                '**********************************************
                'Step 1:: Get the Shift Start and end times
                '**********************************************
                If strShiftStart = "" Or strShiftEnd = "" Then
                    SetShiftInfo(iShiftID)
                End If

                '**********************************************
                'Step 2:: Get the QC Passed Device Count
                '**********************************************
                strsql = "SELECT count(*) AS PassCount " & Environment.NewLine
                strsql += "FROM tqc " & Environment.NewLine
                strsql += "INNER JOIN tdevice ON tqc.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strsql += "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strsql += "WHERE " & Environment.NewLine
                strsql += "QC_Date > '" & strShiftStart & "' AND QC_Date < '" & strShiftEnd & "' " & Environment.NewLine
                strsql += "AND tcostcenter.Group_ID = " & iGroupID & Environment.NewLine
                strsql += "AND inspector_id = " & iInspectorID & " " & Environment.NewLine
                strsql += "AND qctype_id = " & iQCType_ID & Environment.NewLine
                strsql += "AND QCResult_id = 1;" 'Get the QC passed devices only

                objMisc._SQL = strsql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetQCPASSNumber(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        Public Function GetQC_OBA_PASSNumber(ByVal iInspectorID As Integer, _
                                       ByVal iShiftID As Integer, _
                                       ByVal iQCType_ID As Integer, _
                                       ByVal iGroupID As Integer) As DataTable

            Dim strsql As String = ""

            Try
                '**********************************************
                'Step 1:: Get the Shift Start and end times
                '**********************************************
                If strShiftStart = "" Or strShiftEnd = "" Then
                    SetShiftInfo(iShiftID)
                End If

                '**********************************************
                'Step 2:: Get the QC Passed Device Count
                '**********************************************
                strsql = "SELECT count(*) AS PassCount " & Environment.NewLine
                strsql += "FROM tqc " & Environment.NewLine
                strsql += "INNER JOIN tdevice ON tqc.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strsql += "WHERE " & Environment.NewLine
                strsql += "QC_Date > '" & strShiftStart & "' AND QC_Date < '" & strShiftEnd & "' " & Environment.NewLine
                strsql += "AND Group_ID = " & iGroupID & Environment.NewLine
                strsql += "AND inspector_id = " & iInspectorID & " " & Environment.NewLine
                strsql += "AND qctype_id = " & iQCType_ID & Environment.NewLine
                strsql += "AND QCResult_id = 1;" 'Get the QC passed devices only

                objMisc._SQL = strsql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("Buisness.QC. GetQC_OBA_PASSNumber(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function


        Public Sub SetShiftInfo(ByVal iShiftID As Integer)

            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim iCurrentHour As Integer = Now.Hour
            Dim strWorkDay As String = ""
            Dim myArray() As String

            Try
                If iShiftID = 0 Then
                    Exit Sub
                End If

                objMisc._SQL = "Select * from tshift where shift_id =" & iShiftID & ";"
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)

                    If iCurrentHour > 0 And iCurrentHour < 4 Then
                        strWorkDay = Format(DateAdd(DateInterval.Day, -1, Now), "yyyy-MM-dd") 'IF THE CURRENT TIME IS BETWEEN MIDNIGHT AND 4AM THEN GO BACK TO PREVIOUS DATE
                    Else
                        strWorkDay = Format(Now, "yyyy-MM-dd")
                    End If
                    strShiftStart = strWorkDay & " " & Trim(R1("Shift_StartTime"))
                    myArray = Split(Trim(R1("Shift_Duration")), ":", 2, CompareMethod.Text)
                    strShiftEnd = CStr(Format(DateAdd(DateInterval.Minute, CInt(myArray(1)), DateAdd(DateInterval.Hour, CInt(myArray(0)), CDate(strShiftStart))), "yyyy-MM-dd HH:mm:ss"))

                    strShift = "SHIFT " & CStr(R1("Shift_Number"))
                Else
                    Throw New Exception("Shift is not defined.")
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetShiftInfo(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1)
                ReDim myArray(0)
                myArray.Clear(myArray, 0, myArray.Length)
                myArray = Nothing
            End Try
        End Sub

        '*********************************************************************
        Public Function CreateQCRawDataRpt(ByVal strFromDt As String, _
                                            ByVal strToDt As String, _
                                            ByVal iGroup_ID As Integer, _
                                            ByVal iCustID As Integer, _
                                            ByVal iManufID As Integer) As Integer

            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim R1, R2 As DataRow
            Dim strsql As String = ""

            Try
                If iCustID > 0 Then
                    Return CreateQCRawDataReportForCustomer(strFromDt, strToDt, iCustID)
                ElseIf iManufID > 0 Then
                    Return CreateQCRawDataReportForManufacturer(strFromDt, strToDt, iManufID)
                ElseIf iGroup_ID > 0 Then
                    strsql = "select Concat(Cust_name1, ' ', if( cust_name2 is null, '', cust_name2) ) as Customer " & Environment.NewLine
                    strsql += ", '' as Inspector, " & Environment.NewLine
                    strsql += "'' as 'Inspector Shift', " & Environment.NewLine
                    strsql += "'' as Tech, " & Environment.NewLine
                    strsql += "'' as 'Tech Shift', " & Environment.NewLine
                    strsql += "tqc.Tech_ID, " & Environment.NewLine
                    strsql += "tqc.Inspector_ID, " & Environment.NewLine
                    strsql += "tqc.QC_Iteration as Iteration, " & Environment.NewLine
                    strsql += "tqc.QC_Date as 'QC Date', " & Environment.NewLine
                    strsql += "0 as 'QC Week', " & Environment.NewLine
                    strsql += "lqctype.QCType as 'QC Type', " & Environment.NewLine
                    strsql += "lqcresult.QCResult as 'QC Result', " & Environment.NewLine

                    'strsql += "if(lcodesdetail.Dcode_ID = 2506, lcodesdetail.Dcode_Sdesc, Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Fail/Pass Reason', " & Environment.NewLine
                    strsql += "if(lcodesdetail.Dcode_ID = 2506, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine

                    strsql += "tqc.Device_id , " & Environment.NewLine

                    strsql += "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                    'strsql += "lline.Line_Number as 'Line', " & Environment.NewLine
                    strsql += "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine

                    strsql += "tdevice.device_sn as 'Serial No', " & Environment.NewLine
                    strsql += "tmodel.Model_desc as 'Model' " & Environment.NewLine

                    strsql += "from tqc " & Environment.NewLine
                    strsql += "inner join tdevice on tqc.device_id = tdevice.device_id " & Environment.NewLine
                    strsql += "inner join tmodel on tdevice.Model_id = tmodel.Model_id " & Environment.NewLine
                    strsql += "inner join lqcresult on tqc.qcresult_id = lqcresult.QCResult_ID " & Environment.NewLine
                    strsql += "inner join lqctype on tqc.QCType_ID = lqctype.QCType_ID " & Environment.NewLine
                    strsql += "inner join lcodesdetail on tqc.dcode_id = lcodesdetail.Dcode_id " & Environment.NewLine
                    strsql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                    strsql += "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine

                    strsql += "left outer join lgroups on tqc.group_id = lgroups.group_id " & Environment.NewLine
                    'strsql += "left outer join lline on tqc.line_id = lline.line_id " & Environment.NewLine
                    strsql += "left outer join tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine

                    strsql += "where tqc.QC_WorkDate >= '" & strFromDt & "' and " & Environment.NewLine

                    If iGroup_ID > 0 Then
                        strsql += "tqc.group_id = " & iGroup_ID & " and " & Environment.NewLine
                    End If

                    strsql += "tqc.QC_WorkDate <= '" & strToDt & "' " & Environment.NewLine

                    strsql += "order by tqc.Device_id, Iteration;"
                    Me.objMisc._SQL = strsql
                    dt1 = Me.objMisc.GetDataTable()

                    strsql = "select security.tusers.user_id, " & Environment.NewLine
                    strsql += "security.tusers.user_FullName, " & Environment.NewLine
                    strsql += "security.tusers.shift_id, " & Environment.NewLine
                    strsql += "security.tusers.qcstamp, " & Environment.NewLine
                    strsql += "security.tusers.tech_id, " & Environment.NewLine
                    strsql += "production.tshift.shift_number " & Environment.NewLine
                    strsql += "from security.tusers left outer join production.tshift on security.tusers.shift_id = production.tshift.shift_id " & Environment.NewLine
                    strsql += "order by security.tusers.user_id;"
                    Me.objMisc._SQL = strsql
                    dt2 = Me.objMisc.GetDataTable()

                    For Each R1 In dt1.Rows
                        'Loop for Tech info
                        For Each R2 In dt2.Rows
                            If R1("Tech_ID") = R2("User_ID") Then
                                R1("Tech") = R2("Tech_ID") & " - " & Trim(R2("user_FullName"))
                                R1("Tech Shift") = R2("shift_number")
                                Exit For
                            End If
                        Next R2
                        R2 = Nothing

                        'Loop for Inspector info.
                        For Each R2 In dt2.Rows
                            If R1("Inspector_ID") = R2("User_ID") Then
                                R1("Inspector") = "PSS QC " & R2("QCStamp") & " - " & Trim(R2("user_FullName"))
                                R1("Inspector Shift") = R2("shift_number")
                                Exit For
                            End If
                        Next R2
                        R2 = Nothing
                        dt2.AcceptChanges()
                    Next R1


                    GetQCWeekNumbers(dt1)

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("There is no data in the PSS Database for the criteria provided.")
                    Else
                        CreateRawDataExcelFile(dt1, strFromDt, strToDt)
                        Return 1
                    End If
                End If
            Catch ex As Exception
                Throw New Exception("Buisness.QC.CreateQCRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1) : DisposeDT(dt2)
            End Try

        End Function

        '*********************************************************************
        Public Function CreateQCRawDataReportForCustomer(ByVal strFromDt As String, _
                                            ByVal strToDt As String, _
                                            ByVal iCustID As Integer) As Integer
            Dim strSQL As String, strCustName As String = String.Empty
            Dim dt As DataTable

            Try
                strSQL = "SELECT Cust_name1" & Environment.NewLine
                strSQL &= "FROM production.tcustomer" & Environment.NewLine
                strSQL &= String.Format("WHERE cust_id = {0}", iCustID)

                strCustName = Me.objMisc.GetSingletonString(strSQL)

                'Get all locations for this customer
                strSQL = "SELECT loc_id" & Environment.NewLine
                strSQL &= "FROm production.tlocation" & Environment.NewLine
                strSQL &= String.Format("WHERE cust_id = {0}", iCustID)

                dt = Me.objMisc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow
                    Dim strLocIDsIn As String = String.Empty

                    For Each dr In dt.Rows : strLocIDsIn &= IIf(strLocIDsIn.Length > 0, ", ", String.Empty) & dr("loc_id") : Next dr

                    strSQL = "SELECT CONCAT(Cust_name1, ' ', IF( cust_name2 IS NULL, '', cust_name2) ) AS Customer, lgroups.Group_Desc AS 'Group', IF(tcostcenter.cc_desc IS NULL, '', tcostcenter.cc_desc ) AS 'Cost Center', " & Environment.NewLine
                    strSQL &= "CONCAT('PSS QC ', UInspector.QCStamp, ' - ', UInspector.user_FullName) as Inspector, SInspector.shift_number as 'Inspector Shift', " & Environment.NewLine
                    strSQL &= "CONCAT(CAST(UTech.Tech_ID AS CHAR), ' - ', UTech.user_FullName) AS Tech, STech.shift_number AS 'Tech Shift', " & Environment.NewLine
                    strSQL &= "lqctype.QCType AS 'QC Type', tqc.QC_Date AS 'QC Date', 0 AS 'QC Week', lqcresult.QCResult as 'QC Result', " & Environment.NewLine
                    strSQL &= "IF(lcodesdetail.Dcode_ID = 2506, '', CONCAT(TRIM(lcodesdetail.Dcode_Sdesc), ' - ', TRIM(Dcode_Ldesc))) AS 'Failure Reason', tqc.QC_Iteration AS Iteration, " & Environment.NewLine
                    strSQL &= "CONCAT('=""', tdevice.device_sn, '""') AS 'Serial No', " & Environment.NewLine
                    strSQL &= "tqc.Device_id as 'Device ID', tmodel.Model_desc as 'Model'" & Environment.NewLine
                    If iCustID = 2371 Then strSQL &= ",AQL_Lot.AQL_Lot_Name as 'AQL Lot Name',AQL_Lot.Quantity as 'AQL Lot Quantity'" ' Round2
                    If iCustID = 2468 Then strSQL &= ",tdevice.device_qty as 'Socket Qty'" 'Plastronic
                    strSQL &= "FROM production.tqc" & Environment.NewLine
                    strSQL &= "INNER JOIN tdevice ON tqc.device_id = tdevice.device_id" & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel ON tdevice.Model_id = tmodel.Model_id" & Environment.NewLine
                    strSQL &= "INNER JOIN lqcresult ON tqc.qcresult_id = lqcresult.QCResult_ID" & Environment.NewLine
                    strSQL &= "INNER JOIN lqctype ON tqc.QCType_ID = lqctype.QCType_ID" & Environment.NewLine
                    strSQL &= "INNER JOIN lcodesdetail ON tqc.dcode_id = lcodesdetail.Dcode_id" & Environment.NewLine
                    strSQL &= "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id" & Environment.NewLine
                    strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID" & Environment.NewLine
                    strSQL &= "LEFT JOIN lgroups ON tqc.group_id = lgroups.group_id" & Environment.NewLine
                    strSQL &= "LEFT JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id" & Environment.NewLine
                    strSQL &= "LEFT JOIN security.tusers UTech ON UTech.user_id = tqc.Tech_ID" & Environment.NewLine
                    strSQL &= "LEFT JOIN security.tusers UInspector ON UInspector.user_id = tqc.Inspector_ID" & Environment.NewLine
                    strSQL &= "LEFT JOIN production.tshift STech ON UTech.shift_id = STech.shift_id" & Environment.NewLine
                    strSQL &= "LEFT JOIN production.tshift SInspector ON UInspector.shift_id = SInspector.shift_id" & Environment.NewLine
                    strSQL &= "LEFT JOIN tpallett ON tpallett.Pallett_ID = tdevice.Pallett_ID" & Environment.NewLine
                    strSQL &= "LEFT JOIN AQL_Lot ON AQL_Lot.AQL_Lot_ID = tpallett.AQL_Lot_ID" & Environment.NewLine
                    strSQL &= String.Format("WHERE tqc.QC_WorkDate BETWEEN '{0}' AND '{1}' ", strFromDt, strToDt) & Environment.NewLine
                    strSQL &= String.Format("AND tdevice.loc_id IN ({0})", strLocIDsIn) & Environment.NewLine
                    strSQL &= "ORDER BY 'Group', tqc.Device_id, Iteration"

                    dt = Me.objMisc.GetDataTable(strSQL)
                    dt.TableName = strCustName

                    GetQCWeekNumbers(dt)

                    CreateRawDataCustomerManufacturerExcelFile(dt, strFromDt, strToDt)

                    Return 1
                Else
                    Throw New Exception("There is no data in the PSS Database for the criteria provided.")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************
        Public Function CreateQCRawDataReportForManufacturer(ByVal strFromDt As String, _
                                            ByVal strToDt As String, _
                                            ByVal iManufID As Integer) As Integer
            Dim strSQL As String
            Dim strManuf = String.Empty
            Dim dt As DataTable

            Try
                strSQL = "SELECT manuf_desc" & Environment.NewLine
                strSQL &= "FROM production.lmanuf" & Environment.NewLine
                strSQL &= String.Format("WHERE manuf_id = {0}", iManufID)

                strManuf = Me.objMisc.GetSingletonString(strSQL)

                strSQL = "SELECT CONCAT(Cust_name1, ' ', IF( cust_name2 IS NULL, '', cust_name2) ) AS Customer, lgroups.Group_Desc AS 'Group', IF(tcostcenter.cc_desc IS NULL, '', tcostcenter.cc_desc ) AS 'Cost Center', " & Environment.NewLine
                strSQL &= "CONCAT('PSS QC ', UInspector.QCStamp, ' - ', UInspector.user_FullName) as Inspector, SInspector.shift_number as 'Inspector Shift', " & Environment.NewLine
                strSQL &= "CONCAT(CAST(UTech.Tech_ID AS CHAR), ' - ', UTech.user_FullName) AS Tech, STech.shift_number AS 'Tech Shift', " & Environment.NewLine
                strSQL &= "lqctype.QCType AS 'QC Type', tqc.QC_Date AS 'QC Date', 0 AS 'QC Week', lqcresult.QCResult as 'QC Result', " & Environment.NewLine
                strSQL &= "IF(lcodesdetail.Dcode_ID = 2506, '', CONCAT(TRIM(lcodesdetail.Dcode_Sdesc), ' - ', TRIM(Dcode_Ldesc))) AS 'Failure Reason', tqc.QC_Iteration AS Iteration, " & Environment.NewLine
                strSQL &= "CONCAT('=""', tdevice.device_sn, '""') AS 'Serial No', " & Environment.NewLine
                strSQL &= "tqc.Device_id as 'Device ID', tmodel.Model_desc as 'Model'," & Environment.NewLine
                strSQL &= "AQL_Lot.AQL_Lot_Name as 'AQL Lot Name',AQL_Lot.Quantity as 'AQL Lot Quantity'"
                strSQL &= "FROM production.tqc" & Environment.NewLine
                strSQL &= "INNER JOIN tdevice ON tqc.device_id = tdevice.device_id" & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tdevice.Model_id = tmodel.Model_id" & Environment.NewLine
                strSQL &= "INNER JOIN lqcresult ON tqc.qcresult_id = lqcresult.QCResult_ID" & Environment.NewLine
                strSQL &= "INNER JOIN lqctype ON tqc.QCType_ID = lqctype.QCType_ID" & Environment.NewLine
                strSQL &= "INNER JOIN lcodesdetail ON tqc.dcode_id = lcodesdetail.Dcode_id" & Environment.NewLine
                strSQL &= "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id" & Environment.NewLine
                strSQL &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID" & Environment.NewLine
                strSQL &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID" & Environment.NewLine
                strSQL &= "LEFT JOIN lgroups ON tqc.group_id = lgroups.group_id" & Environment.NewLine
                strSQL &= "LEFT JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id" & Environment.NewLine
                strSQL &= "LEFT JOIN security.tusers UTech ON UTech.user_id = tqc.Tech_ID" & Environment.NewLine
                strSQL &= "LEFT JOIN security.tusers UInspector ON UInspector.user_id = tqc.Inspector_ID" & Environment.NewLine
                strSQL &= "LEFT JOIN production.tshift STech ON UTech.shift_id = STech.shift_id" & Environment.NewLine
                strSQL &= "LEFT JOIN production.tshift SInspector ON UInspector.shift_id = SInspector.shift_id" & Environment.NewLine
                strSQL &= "LEFT JOIN tpallett ON tpallett.Pallett_ID = tdevice.Pallett_ID" & Environment.NewLine
                strSQL &= "LEFT JOIN AQL_Lot ON AQL_Lot.AQL_Lot_ID = tpallett.AQL_Lot_ID" & Environment.NewLine
                strSQL &= String.Format("WHERE tqc.QC_WorkDate BETWEEN '{0}' AND '{1}' ", strFromDt, strToDt) & Environment.NewLine
                strSQL &= String.Format("AND lmanuf.Manuf_ID = {0}", iManufID) & Environment.NewLine
                strSQL &= "ORDER BY 'Group', tqc.Device_id, Iteration"

                dt = Me.objMisc.GetDataTable(strSQL)
                dt.TableName = strManuf

                GetQCWeekNumbers(dt)

                CreateRawDataCustomerManufacturerExcelFile(dt, strFromDt, strToDt)

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************
        Private Sub GetQCWeekNumbers(ByRef dt As DataTable)
            Dim dr As DataRow
            Dim dteQCData As DateTime
            Dim iQCWeek As Integer = 0

            Try
                For Each dr In dt.Rows
                    dteQCData = dr("QC Date")
                    iQCWeek = 0

                    dr.BeginEdit()

                    iQCWeek = GetQCWeek(dteQCData)

                    dr("QC Week") = iQCWeek

                    dr.EndEdit()
                    dr.AcceptChanges()
                Next dr

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************
        Private Function GetQCWeek(ByVal dteQCDate As DateTime) As Integer
            Dim strSQL As String

            Try
                'dteQCDate needs to be a Monday
                If dteQCDate.DayOfWeek <> DayOfWeek.Monday Then
                    If dteQCDate.DayOfWeek = DayOfWeek.Sunday Then
                        'Move back to previous Monday.  The DayOfWeek struct starts with Sunday (=0),
                        'and since PSSI's week starts on a Monday (DayOfWeek.Monday = 1),
                        'anything on a Sunday must be moved back to the previous Monday, so add -6 days.
                        dteQCDate = dteQCDate.AddDays(-6)
                    Else
                        dteQCDate = dteQCDate.AddDays(DayOfWeek.Monday - dteQCDate.DayOfWeek)
                    End If
                End If

                strSQL = "SELECT yearweek" & Environment.NewLine
                strSQL &= "FROM cogs.MRPYearsWeeks" & Environment.NewLine
                strSQL &= String.Format("WHERE yearweekstartdate = '{0:yyyy-MM-dd}'", dteQCDate)

                Return Me.objMisc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Private Sub CreateRawDataExcelFile(ByRef dt1 As DataTable, _
                                            ByVal strFromDt As String, _
                                            ByVal strToDt As String)
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = "R:\QC Reports\"
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            strRptPath = strRptDir & strFileName

            Dim R1 As DataRow
            Dim i As Integer = 3
            Dim arrData(0, 0) As String
            Dim j As Integer = 0

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Customer"
                objExcel.Application.Cells(i, 2).Value = "Group"
                'objExcel.Application.Cells(i, 2).Value = "Line"
                objExcel.Application.Cells(i, 3).Value = "Cost Center"

                objExcel.Application.Cells(i, 4).Value = "Inspector"
                objExcel.Application.Cells(i, 5).Value = "Inspector Shift"
                objExcel.Application.Cells(i, 6).Value = "Tech"
                objExcel.Application.Cells(i, 7).Value = "Tech Shift"
                objExcel.Application.Cells(i, 8).Value = "QC Type"
                objExcel.Application.Cells(i, 9).Value = "QC Date"
                objExcel.Application.Cells(i, 10).Value = "QC Week"
                objExcel.Application.Cells(i, 11).Value = "QC Result"
                objExcel.Application.Cells(i, 12).Value = "Fail/Pass Reason"
                objExcel.Application.Cells(i, 13).Value = "Iteration"
                objExcel.Application.Cells(i, 14).Value = "Serial No"
                objExcel.Application.Cells(i, 15).Value = "Device ID"
                objExcel.Application.Cells(i, 16).Value = "Model"

                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.Columns("A:A").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("B:B").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("C:C").Select()
                objExcel.Selection.NumberFormat = "@"                               'Need to change this

                objSheet.Columns("D:D").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("E:E").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"              'Need to change this

                objSheet.Columns("F:F").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("G:G").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"              'Need to change this

                objSheet.Columns("H:H").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("I:I").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("J:J").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("K:K").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("L:L").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("M:M").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("N:N").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("O:O").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("P:P").Select()
                objExcel.Selection.NumberFormat = "@"


                '*****************************************
                'Set horizontal alignment for the header
                '*****************************************
                objSheet.Range("A3:P3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                With objExcel.Selection.Interior
                    .ColorIndex = 37
                    .Pattern = Excel.Constants.xlSolid
                End With

                'i += 1
                i = 0

                ReDim arrData(dt1.Rows.Count, 15)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Customer")) Then
                        arrData(i, 0) = Trim(R1("Customer"))
                    End If
                    If Not IsDBNull(R1("Group")) Then
                        arrData(i, 1) = Trim(R1("Group"))
                    End If

                    If Not IsDBNull(R1("CostCenter")) Then
                        arrData(i, 2) = Trim(R1("CostCenter"))
                    End If

                    If Not IsDBNull(R1("Inspector")) Then
                        arrData(i, 3) = Trim(R1("Inspector"))
                    End If
                    If Not IsDBNull(R1("Inspector Shift")) Then
                        arrData(i, 4) = R1("Inspector Shift")
                    End If
                    If Not IsDBNull(R1("Tech")) Then
                        arrData(i, 5) = Trim(R1("Tech"))
                    End If
                    If Not IsDBNull(R1("Tech Shift")) Then
                        arrData(i, 6) = R1("Tech Shift")
                    End If
                    If Not IsDBNull(R1("QC Type")) Then
                        arrData(i, 7) = Trim(R1("QC Type"))
                    End If
                    If Not IsDBNull(R1("QC Date")) Then
                        arrData(i, 8) = Trim(R1("QC Date"))
                    End If
                    If Not IsDBNull(R1("QC Week")) Then
                        arrData(i, 9) = Trim(R1("QC Week"))
                    End If
                    If Not IsDBNull(R1("QC Result")) Then
                        arrData(i, 10) = Trim(R1("QC Result"))
                    End If
                    If Not IsDBNull(R1("Failure Reason")) Then
                        arrData(i, 11) = Trim(R1("Failure Reason"))
                    End If
                    If Not IsDBNull(R1("Iteration")) Then
                        arrData(i, 12) = Trim(R1("Iteration"))
                    End If
                    If Not IsDBNull(R1("Serial No")) Then
                        arrData(i, 13) = Trim(R1("Serial No"))
                    End If
                    If Not IsDBNull(R1("Device_ID")) Then
                        arrData(i, 14) = Trim(R1("Device_ID"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 15) = Trim(R1("Model"))
                    End If

                    i += 1
                Next R1

                objSheet.Range("A4", "P" & (dt1.Rows.Count + 3)).Value = arrData

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:P" & (dt1.Rows.Count + 3)).Select()

                'Set Font
                With objExcel.Selection
                    .Font.Name = "Microsoft Sans Serif"
                End With

                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                '************************************************
                'Add report header
                objSheet.Range("A1:C1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3        'Red
                End With
                objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report F-8.3-002"
                '*************************************************
                objSheet.Cells.Select()
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()
                '*************************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
                'OPen Excel File
                objXL = New Excel.Application()
                objXL.Workbooks.Open(strRptPath)
                objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.QC.CreateRawDataExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                arrData = Nothing
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()

            End Try
        End Sub

        '*********************************************************************
        Private Sub CreateRawDataCustomerManufacturerExcelFile(ByVal dt As DataTable, ByVal strFromDt As String, ByVal strToDt As String)
            Try
                Dim strLastCol As String = Generic.GetExcelColumnName(dt.Columns.Count)
                Dim strColName As String
                Dim strSheetName As String = String.Format("{0} Devices Processed", dt.TableName.Substring(0, Math.Min(13, dt.TableName.Length))) 'Max 31 characters
                Dim i, j As Integer
                Dim xlApp As New Excel.Application()

                xlApp.DisplayAlerts = False
                xlApp.Visible = False

                Dim xlWB As Excel.Workbook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
                Dim xlWS As Excel.Worksheet = DirectCast(xlWB.Worksheets.Item("Sheet1"), Excel.Worksheet)
                Dim xlRange As Excel.Range

                xlWS.Name = strSheetName

                'Title
                xlRange = xlWS.Range("A1", String.Format("{0}1", strLastCol))
                xlRange.Value2 = String.Format("QC Raw Data Report - {0}", dt.TableName)
                xlRange.MergeCells = True
                xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                xlRange.VerticalAlignment = Excel.Constants.xlBottom
                xlRange.Font.Name = "Arial"
                xlRange.Font.FontStyle = "Bold"
                xlRange.Font.Size = 16
                xlRange.Font.ColorIndex = 10
                xlRange.Interior.ColorIndex = 2
                xlRange.NumberFormat = "@"

                'Date range
                Dim dateFrom As Date = CDate(strFromDt)
                Dim dateTo As Date = CDate(strToDt)

                xlRange = xlWS.Range("A2", String.Format("{0}2", strLastCol))
                xlRange.Value2 = String.Format("{0:ddd, MMM d, yyyy} - {1:ddd, MMM d, yyyy}", dateFrom, dateTo)
                xlRange.MergeCells = True
                xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                xlRange.VerticalAlignment = Excel.Constants.xlBottom
                xlRange.Font.Name = "Arial"
                xlRange.Font.FontStyle = "Regular"
                xlRange.Font.Size = 12
                xlRange.Font.ColorIndex = 25
                xlRange.Interior.ColorIndex = 2
                xlRange.NumberFormat = "@"

                'Data
                For i = 0 To dt.Columns.Count - 1
                    j = i + 1
                    strColName = Generic.GetExcelColumnName(j)

                    xlRange = xlWS.Range(String.Format("{0}3", strColName), String.Format("{0}3", strColName))
                    xlRange.Value2 = dt.Columns(i).ColumnName
                    xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                    xlRange.VerticalAlignment = Excel.Constants.xlBottom
                    xlRange.Font.Name = "Arial"
                    xlRange.Font.FontStyle = "Regular"
                    xlRange.Font.Size = 10
                    xlRange.Font.ColorIndex = 20
                    xlRange.Interior.ColorIndex = 25
                    xlRange.NumberFormat = "@"
                Next i

                Dim objData(,) As Object

                ReDim objData(dt.Rows.Count, dt.Columns.Count)

                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        objData(i, j) = dt.Rows(i)(j)
                    Next j
                Next i

                xlRange = xlWS.Range("A4", String.Format("{0}{1}", strLastCol, dt.Rows.Count + 3))
                xlRange.Value2 = objData
                xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                xlRange.VerticalAlignment = Excel.Constants.xlBottom
                xlRange.Font.Name = "Arial"
                xlRange.Font.FontStyle = "Regular"
                xlRange.Font.Size = 10
                xlRange.Font.ColorIndex = 1
                xlRange.Interior.ColorIndex = 2

                For i = 1 To dt.Columns.Count
                    strColName = Generic.GetExcelColumnName(i)
                    xlRange = xlWS.Range(String.Format("{0}4", strColName), String.Format("{0}{1}", strColName, dt.Rows.Count + 3))

                    Select Case i
                        Case 1 To 4, 6, 8, 11, 12, 16
                            xlRange.HorizontalAlignment = Excel.Constants.xlLeft
                            xlRange.NumberFormat = "@"

                        Case 5, 7, 10, 13, 15
                            xlRange.HorizontalAlignment = Excel.Constants.xlRight
                            xlRange.NumberFormat = "#0"

                        Case 9
                            xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                            xlRange.NumberFormat = "M/d/YYYY H:mm:ss"

                        Case 14
                            xlRange.HorizontalAlignment = Excel.Constants.xlCenter
                            xlRange.NumberFormat = "@"

                        Case Else
                            xlRange.HorizontalAlignment = Excel.Constants.xlLeft
                            xlRange.NumberFormat = "@"
                    End Select

                    xlRange.EntireColumn.AutoFit()
                Next i

                Generic.CreateBorders(xlWS, 1, 4, dt.Columns.Count, dt.Rows.Count + 3)

                xlApp.ActiveWindow.FreezePanes = False
                xlWS.Range("A4", String.Format("{0}4", strLastCol)).Select() 'Note, must select range here
                xlApp.ActiveWindow.FreezePanes = True

                Generic.DeleteExcelSheetsExcept(xlWB, New String() {xlWS.Name})

                Dim strOutputFileName As String = String.Format("R:\QC Reports\{0}__{1:yyyy-MM-dd}__{2:yyyy-MM-dd}__{3:yyyyMMddHHmmss}.xls", dt.TableName, dateFrom, dateTo, DateTime.Now)

                If System.IO.File.Exists(strOutputFileName) Then System.IO.File.Delete(strOutputFileName)

                xlWB.SaveAs(strOutputFileName)
                xlWB.Close()

                xlApp = New Excel.Application()

                xlApp.Workbooks.Open(strOutputFileName)
                xlApp.Visible = True

                MessageBox.Show(String.Format("Report has been created successfully and saved at '{0}'.", strOutputFileName), "Report Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************
        Public Function GetDeviceProductType(ByVal strSN As String, ByVal iCustID As Integer) As Integer
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim strSql As String = ""

            Try
                strSql = "Select " & Environment.NewLine
                If iCustID <> 2485 Then
                    strSql &= "tmodel.Prod_ID " & Environment.NewLine
                Else 'Syx
                    strSql &= "syxdata.NewModelProdID as Prod_ID " & Environment.NewLine
                End If
                strSql &= "from tdevice  " & Environment.NewLine
                If iCustID <> 2485 Then
                    strSql &= "inner join tmodel on tdevice.Model_id = tmodel.Model_ID " & Environment.NewLine
                Else 'Syx
                    strSql &= "inner join syxdata on tdevice.Device_ID = syxdata.Device_ID " & Environment.NewLine
                End If
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "where tdevice.Device_sn = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "order by tdevice.Device_ID Desc;"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    Return R1("Prod_ID")
                Else
                    Throw New Exception("Serial Number does not exist in the database.")
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetDeviceProductType(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1)
            End Try
        End Function
        '*********************************************************************
        Public Function GetLastWeekMonday() As Date
            Return DateAdd(DateInterval.Day, -6, objMyLib.GetLastSunday)
        End Function
        '*********************************************************************
        Public Function GetLastWeekFriday() As Date
            Return DateAdd(DateInterval.Day, -2, objMyLib.GetLastSunday)
        End Function
        '*********************************************************************
        Public Function GetCurrentWeekMonday() As Date
            Return DateAdd(DateInterval.Day, 1, objMyLib.GetLastSunday)
        End Function
        '*********************************************************************
        Public Function GetCurrentWeekFriday() As Date
            Return DateAdd(DateInterval.Day, 5, objMyLib.GetLastSunday)
        End Function
        '*********************************************************************
        Public Function GetQCHistory(ByVal iDevice_ID As Integer) As DataTable
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim strsql As String = ""

            Try
                '*****************
                strsql = "Select " & Environment.NewLine
                strsql += "tqc.QC_Iteration as Iteration, " & Environment.NewLine
                strsql += "tqc.QC_Date as 'QC Date', " & Environment.NewLine
                strsql += "lqctype.QCType as 'QC Type', " & Environment.NewLine
                strsql += "lqcresult.qcresult as 'QC Result', " & Environment.NewLine
                strsql += "lcodesdetail.Dcode_SDesc as 'Failure Code', " & Environment.NewLine
                strsql += "lcodesdetail.Dcode_lDesc as 'Failure Reason', " & Environment.NewLine
                strsql += "'' as 'QC Inspector', " & Environment.NewLine
                strsql += "'' as 'Tech', " & Environment.NewLine
                strsql += "tqc.dcode_id, " & Environment.NewLine
                strsql += "tqc.Inspector_id, " & Environment.NewLine
                strsql += "tqc.tech_id, " & Environment.NewLine
                strsql += "tqc.QC_ID " & Environment.NewLine
                strsql += ", tqc.QCType_ID, QC_OtherFails as 'Other Failure' " & Environment.NewLine
                strsql += "from tqc " & Environment.NewLine
                strsql += "inner join lqctype on tqc.QCType_ID = lqctype.QCType_ID " & Environment.NewLine
                strsql += "inner join lqcresult on tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strsql += "inner join lcodesdetail on tqc.dcode_id = lcodesdetail.dcode_id " & Environment.NewLine
                strsql += "where device_id = " & iDevice_ID & Environment.NewLine
                strsql += "order by tqc.QC_ID DESC;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                '*****************
                'GEt User' Info
                strsql = ""
                strsql = "Select * from security.tusers order by User_ID;"
                objMisc._SQL = strsql
                dt2 = objMisc.GetDataTable
                '*****************
                For Each R1 In dt1.Rows
                    'Inspector Name
                    For Each R2 In dt2.Rows
                        If R1("Inspector_id") = R2("User_ID") Then
                            R1("QC Inspector") = "PSS QC " & R2("QCStamp") & " - " & Trim(R2("User_FullName"))
                        End If
                    Next R2
                    R2 = Nothing
                    'Tech Name
                    For Each R2 In dt2.Rows
                        If R1("tech_id") = R2("User_ID") Then
                            R1("Tech") = R2("Tech_id") & " - " & Trim(R2("User_FullName"))
                        End If
                    Next R2
                    R2 = Nothing
                    dt1.AcceptChanges()
                Next R1

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetQCHistory(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
                DisposeDT(dt2)
            End Try
        End Function

        '*********************************************************************
        Public Function GetQCTypeInfo(ByVal booIncludeOBAType As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String

            Try
                strSql = "Select * from lqctype " & Environment.NewLine
                If booIncludeOBAType = False Then strSql &= "WHERE QCType_ID <> 5 " & Environment.NewLine
                strSql &= "order by QCType_ID "
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "QCType_ID", "QCType", , , "-- Select --")
                Return dt

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetQCTypeInfo(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '*********************************************************************
        Public Function GetQCResultInfo() As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "Select * from lqcresult order by QCResult_ID;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "QCResult_ID", "QCResult", , , "-- Select --")
                Return dt

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetQCResultInfo(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '----------------------Vivint get order Type-------------

        Public Function GetVivintOrderType(ByVal StrIMEI As String) As DataTable
            Dim dt As DataTable
            Dim strSql As String

            Try
                strSql = "Select Billcode_id from tdevice,tdevicebill where device_sn='" & StrIMEI & "' and tdevice.device_id= tdevicebill.device_id and device_dateship is null;"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                Return dt
            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetQCResultInfo(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '---------------Check for Pretest Information 
        Public Function GetDevicePretest(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM  tpretest_data,tdevice " & Environment.NewLine
                strSql &= " WHERE tpretest_data.Device_ID =" & iDevice_ID & " and tpretest_data.device_id=tdevice.device_id and device_DateShip is null;" & Environment.NewLine
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetDeviceSIMcard(ByVal iDevice_ID As Integer, ByVal strAccount As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try

                strSql = "SELECT A.SerialNo AS 'IMEI',E.Serial AS 'ICCID', B.Device_ID,  E.Device_ID AS 'ICCID_Device_ID',A.Cust_ID,A.Loc_ID,A.EW_ID, B.Model_ID,C.wb_id,C.BoxID,A.WI_ID, D.Model_Desc,A.Item_Sku,A.Account,Insert_Decode_ID  " & Environment.NewLine
                strSql &= "FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= "INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.twarehouseBox C ON A.wb_ID=C.wb_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tModel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items E ON A.WI_ID=E.WI_ID" & Environment.NewLine
                strSql &= " WHERE  A.Cust_ID=2624 AND A.Loc_ID=4490 AND A.Account = '" & strAccount & "' and B.device_id=" & iDevice_ID & " ;" & Environment.NewLine
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*********************************************************************
        Public Function GetDeviceInfo(ByVal strDevice_SN As String, ByVal iCustID As Integer, _
                                      ByVal booIncludeCelloptData As Boolean) As DataTable
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strSql As String = ""

            Try
                strDevice_SN = strDevice_SN.Replace("'", "''")

                If iCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    strSql = "SELECT tmodel.Manuf_ID, tmodel.Model_Type,tmodel.Prod_ID, tdevice.*" & Environment.NewLine
                    strSql &= " , IF(tworkorder.Group_ID is null, 0 , tworkorder.Group_ID) as Group_ID" & Environment.NewLine
                    strSql &= " , if(WorkStation is null, '', WorkStation) as WorkStation,tcellopt.CellOpt_DateCode as 'ManufDate'" & Environment.NewLine
                    strSql &= " ,Extendedwarranty.ShipTo_Name AS 'WiKo_Customer_Name',tlocation.Loc_Name, Extendedwarranty.Account " & Environment.NewLine
                    strSql &= " FROM tdevice" & Environment.NewLine
                    strSql &= " INNER JOIN  tmodel on tdevice.model_id = tmodel.model_id" & Environment.NewLine
                    strSql &= " INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN Extendedwarranty ON tdevice.Device_ID=Extendedwarranty.Device_ID" & Environment.NewLine
                    strSql &= " where device_sn = '" & strDevice_SN & "'" & Environment.NewLine
                    strSql &= " AND tlocation.Cust_ID =" & iCustID & Environment.NewLine
                    strSql &= " AND Device_Dateship is null" & Environment.NewLine
                    strSql &= " order by Device_ID desc;" & Environment.NewLine

                ElseIf iCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                    strSql = "SELECT tmodel.Manuf_ID, tmodel.Model_Type,tmodel.Prod_ID, tdevice.*" & Environment.NewLine
                    strSql &= " , IF(tworkorder.Group_ID is null, 0 , tworkorder.Group_ID) as Group_ID" & Environment.NewLine
                    strSql &= " , if(WorkStation is null, '', WorkStation) as WorkStation,tcellopt.CellOpt_DateCode as 'ManufDate'" & Environment.NewLine
                    strSql &= " ,Extendedwarranty.ShipTo_Name AS 'WingTechATT_Customer_Name',tlocation.Loc_Name, Extendedwarranty.Account " & Environment.NewLine
                    strSql &= " FROM tdevice" & Environment.NewLine
                    strSql &= " INNER JOIN  tmodel on tdevice.model_id = tmodel.model_id" & Environment.NewLine
                    strSql &= " INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN Extendedwarranty ON tdevice.Device_ID=Extendedwarranty.Device_ID" & Environment.NewLine
                    strSql &= " where device_sn = '" & strDevice_SN & "'" & Environment.NewLine
                    strSql &= " AND tlocation.Cust_ID =" & iCustID & Environment.NewLine
                    strSql &= " AND Device_Dateship is null" & Environment.NewLine
                    strSql &= " order by Device_ID desc;" & Environment.NewLine

                ElseIf iCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                    strSql = "SELECT tmodel.Manuf_ID, tmodel.Model_Type,tmodel.Prod_ID, tdevice.*" & Environment.NewLine
                    strSql &= " , IF(tworkorder.Group_ID is null, 0 , tworkorder.Group_ID) as Group_ID" & Environment.NewLine
                    strSql &= " , if(WorkStation is null, '', WorkStation) as WorkStation,tcellopt.CellOpt_DateCode as 'ManufDate'" & Environment.NewLine
                    strSql &= " ,Extendedwarranty.ShipTo_Name AS 'Vinsmart_Customer_Name',tlocation.Loc_Name, Extendedwarranty.Account " & Environment.NewLine
                    strSql &= " FROM tdevice" & Environment.NewLine
                    strSql &= " INNER JOIN  tmodel on tdevice.model_id = tmodel.model_id" & Environment.NewLine
                    strSql &= " INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN Extendedwarranty ON tdevice.Device_ID=Extendedwarranty.Device_ID" & Environment.NewLine
                    strSql &= " where device_sn = '" & strDevice_SN & "'" & Environment.NewLine
                    strSql &= " AND tlocation.Cust_ID =" & iCustID & Environment.NewLine
                    strSql &= " AND Device_Dateship is null" & Environment.NewLine
                    strSql &= " order by Device_ID desc;" & Environment.NewLine
                Else
                    strSql = "Select tmodel.Manuf_ID, tmodel.Model_Type,tmodel.Prod_ID, tdevice.* " & Environment.NewLine
                    strSql &= ", IF(tworkorder.Group_ID is null, 0 , tworkorder.Group_ID) as Group_ID " & Environment.NewLine
                    If iCustID = 2258 Then
                        strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                        strSql &= ", edi.titem.manuf_date As 'ManufDate' " & Environment.NewLine
                        strSql &= ", edi.titem.FuncRep, tcellopt.Manuf_SN, tcellopt.OutBoundCosmGradeID, tcellopt.InBoundCosmGrade,tcellopt.Incoming_NTF_Model_ID " & Environment.NewLine
                    ElseIf booIncludeCelloptData = True Then
                        strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                        strSql &= ", '' As 'ManufDate' " & Environment.NewLine
                        strSql &= ", - 1 as FuncRep, tcellopt.Manuf_SN, tcellopt.OutBoundCosmGradeID, tcellopt.InBoundCosmGrade " & Environment.NewLine
                    Else
                        strSql &= ", '' as WorkStation " & Environment.NewLine
                        strSql &= ", '' As 'ManufDate' " & Environment.NewLine
                        strSql &= ", - 1 as FuncRep, '' as Manuf_SN, 0 as OutBoundCosmGradeID, 0 as InBoundCosmGrade " & Environment.NewLine
                    End If
                    strSql &= "from tdevice " & Environment.NewLine
                    strSql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    If iCustID = 2258 Then
                        strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                        strSql &= "INNER JOIN edi.titem ON tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
                    ElseIf booIncludeCelloptData = True Then
                        strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                    End If
                    strSql &= "where device_sn = '" & strDevice_SN & "' " & Environment.NewLine
                    strSql &= "AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                    strSql &= "AND Device_Dateship is null " & Environment.NewLine
                    strSql &= "order by Device_ID desc;"
                End If

                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetDeviceInfo(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1)
            End Try
        End Function

        Public Function GetMaxQCIteration(ByVal idevice_id As Integer) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iIteration As Integer = 0

            Try
                objMisc._SQL = "Select distinct QC_Iteration from tqc where device_id = " & idevice_id & " order by QC_Iteration Desc;"
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iIteration = R1("QC_Iteration")
                Else
                    iIteration = 0
                End If

                Return iIteration
            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetMaxQCIteration(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1)
            End Try
        End Function

        'Public Function GetDeviceIDByDeviceSNCustID(ByVal deviceSN As String, ByVal iCustID As Integer) As DataTable
        '    Dim dt1 As DataTable
        '    Dim StrDeviceSN As String = deviceSN.Replace("'", "''")
        '    Dim strSQL As String = ""

        '    Try
        '        strSQL = "Select tdevice.Device_ID,tdevice.WO_ID" & Environment.NewLine
        '        strSQL &= " FROM tdevice" & Environment.NewLine
        '        strSQL &= " INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
        '        strSQL &= " WHERE device_sn = '" & StrDeviceSN & " '" & Environment.NewLine
        '        strSQL &= " AND tlocation.Cust_ID =" & iCustID & " order by Device_ID Desc limit 1;" & Environment.NewLine
        '        objMisc._SQL = strSQL
        '        dt1 = objMisc.GetDataTable

        '        Return dt1

        '    Catch ex As Exception
        '        Throw New Exception("Buisness.QC.GetDeviceIDByDeviceSNCustID(): " & Environment.NewLine & ex.Message.ToString)
        '    Finally
        '        DisposeDT(dt1)
        '    End Try
        'End Function

        Public Function IsDeviceQC_AQLPassed(ByVal iDeviceID As Integer) As Boolean
            Dim dt1 As DataTable
            Dim tmpResult As Boolean = False

            Try
                objMisc._SQL = "SELECT * FROM tqc where device_ID = " & iDeviceID & ";"
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    tmpResult = True
                End If

                Return tmpResult

            Catch ex As Exception
                Throw New Exception("Buisness.QC.IsDeviceQCPassed(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        Public Function TMI_getShippingDataByDeviceID(ByVal iWO_ID As Integer) As DataTable
            Dim dt1 As New DataTable()
            Dim strSQL As String

            Try
                strSQL = "SELECT a.EW_ID,ClaimNo, a.shipto_name as Customer," & Environment.NewLine
                strSQL &= "Concat(a.Address1, if(Length(a.address2)>0, Concat(' ', a.Address2), '')) as Address," & Environment.NewLine
                strSQL &= "a.City,if(length(b.state_short)>0,b.State_Short,a.State_ShortName) as State,a.Zipcode," & Environment.NewLine
                strSQL &= "if(length(Trim(a.type))>0 and length(Trim(a.Brand)) >0,  Concat(a.Brand, ' - ',a.type)," & Environment.NewLine
                strSQL &= "if(length(Trim(a.type))=0 and length(Trim(a.Brand)) >0,  a.Brand," & Environment.NewLine
                strSQL &= "if(length(Trim(a.type))>0 and length(Trim(a.Brand)) =0,  a.type,''))) as BrandType" & Environment.NewLine
                ' strSQL &= "Concat(a.Brand, ' - ',a.type) as BrandType" & Environment.NewLine
                strSQL &= ", a.Model, a.SerialNo" & Environment.NewLine
                strSQL &= " FROM extendedwarranty a" & Environment.NewLine
                strSQL &= " LEFT JOIN lState b on a.State_ID=b.State_ID" & Environment.NewLine
                strSQL &= " WHERE WO_ID=" & iWO_ID & ";" & Environment.NewLine
                objMisc._SQL = strSQL
                dt1 = objMisc.GetDataTable

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.QC.TMI_getShippingDataByDeviceID(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        Public Function NI_getShippingDataByDeviceID(ByVal iWO_ID As Integer) As DataTable
            Dim dt1 As New DataTable()
            Dim strSQL As String

            Try
                strSQL = "SELECT a.EW_ID,ClaimNo, a.shipto_name as Customer," & Environment.NewLine
                strSQL += "Concat(a.Address1, if(Length(a.address2)>0, Concat(' ', a.Address2), '')) as Address," & Environment.NewLine
                strSQL += "a.City,if(length(b.state_short)>0,b.State_Short,a.State_ShortName) as State,a.Zipcode," & Environment.NewLine
                strSQL += "a.cntry_Name, a.SerialNo" & Environment.NewLine
                strSQL += " FROM extendedwarranty a" & Environment.NewLine
                strSQL += " LEFT JOIN lState b on a.State_ID=b.State_ID" & Environment.NewLine
                strSQL += " WHERE WO_ID=" & iWO_ID & ";" & Environment.NewLine
                objMisc._SQL = strSQL
                dt1 = objMisc.GetDataTable

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.QC.TMI_getShippingDataByDeviceID(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        Public Function getDeviceAccessoryNames(ByVal iDevice_ID As Integer) As DataTable
            Dim dt1 As New DataTable()
            Dim strSQL As String

            Try
                strSQL = "SELECT A.DRA_ID,B.A_ID,A.Device_ID,B.AccessoryDesc" & Environment.NewLine
                strSQL &= " FROM tdevicerecaccessories A" & Environment.NewLine
                strSQL &= " INNER JOIN taccessories B ON A.A_ID = B.A_ID" & Environment.NewLine
                strSQL &= " WHERE A.Device_ID = " & iDevice_ID & ";" & Environment.NewLine
                objMisc._SQL = strSQL
                dt1 = objMisc.GetDataTable

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.QC.TMI_getShippingDataByDeviceID(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        Public Function SaveQCResultsForOBA(ByVal iDevice_ID As Integer, _
                                ByVal iQCtype As Integer, _
                                ByVal iQCResult As Integer, _
                                ByVal iTech_ID As String, _
                                ByVal iInspector_ID As String, _
                                ByVal strWorkDate As String, _
                                ByVal iGroupID As Integer, _
                                ByVal iLineID As Integer, _
                                ByVal iProd_ID As Integer) As Integer

            '--------------------------------------Save QC Result for OBA ------------------------------------------

            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iDcode_ID As Integer = 2506
            Dim iIteration As Integer = 0
            Dim dt1 As DataTable
            Dim iQCCredit As Integer = 0

            'Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strDate As String = ""

            Try
                'Get mySQL server date
                strDate = objGen.MySQLServerDateTime(1)

                'Check if this has already been passed under this QCType
                strsql = "Select Count(*) as cnt " & Environment.NewLine
                strsql += "from tqc " & Environment.NewLine
                strsql += "where " & Environment.NewLine
                strsql += "qcresult_ID = 1 and " & Environment.NewLine
                strsql += "device_id = " & iDevice_ID & " and " & Environment.NewLine
                strsql += "QCType_ID = " & iQCtype & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows(0).Item("cnt") > 0 Then
                    Throw New Exception("This device has already been Passed once.")
                End If

                'Get iteration number
                iIteration = GetMaxQCIteration(iDevice_ID) + 1

                'Insert data
                strsql = "Insert into tqc " & Environment.NewLine
                strsql += "(QC_Date, QC_WorkDate, QCType_ID, QCResult_ID, Inspector_ID, Tech_ID, Device_ID, DCode_ID, QC_Iteration, Group_ID, Line_ID) " & Environment.NewLine
                strsql += " Values ('" & strDate & "', '" & strWorkDate & "', " & iQCtype & ", " & iQCResult & ", " & iInspector_ID & ", " & iTech_ID & ", " & iDevice_ID & ", " & iDcode_ID & ", " & iIteration & ", " & iGroupID & ", " & iLineID & ""
                strsql += ");" & Environment.NewLine
                objMisc._SQL = strsql
                j = objMisc.ExecuteNonQuery()

                Return j
            Catch ex As Exception
                Throw New Exception("Buisness.QC.SaveQCResults(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
                objGen = Nothing
            End Try

        End Function

        Public Function SaveQCResults(ByVal iDevice_ID As Integer, _
                                    ByVal iQCtype As Integer, _
                                    ByVal iQCResult As Integer, _
                                    ByVal strFailCodes As String, _
                                    ByVal iTech_ID As String, _
                                    ByVal iInspector_ID As String, _
                                    ByVal strWorkDate As String, _
                                    ByVal iGroupID As Integer, _
                                    ByVal iLineID As Integer, _
                                    ByVal iProd_ID As Integer, _
                                    ByVal icc_id As Integer, _
                                    Optional ByVal iCustID As Integer = 0, _
                                    Optional ByVal iPalletID As Integer = 0, _
                                    Optional ByVal iComponentQTY As Integer = 0, _
                                    Optional ByVal strFailOther As String = "", _
                                    Optional ByVal iWipOwner As Integer = 0, _
                                    Optional ByVal iWipownersublocID As Integer = 0) As Integer

            Dim strsql As String = ""
            Dim strDelimeter As String = ","
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iDcode_ID As Integer = 2506
            Dim iIteration As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iExists As Integer = 0
            Dim iQCCredit As Integer = 0

            'Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strDate As String = ""

            Try
                strDate = objGen.MySQLServerDateTime(1)

                '****************************************************************
                'CHANGE BY LAN ON 2009-09-24. ALLOW PASS MORE THAN ONE TIME
                '****************************************************************
                If iCustID <> TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso iCustID <> Syx.CUSTOMERID Then
                    '*************************************************************
                    'Check if this has already been passed under this QCType
                    '*************************************************************
                    strsql = "Select Count(*) as cnt " & Environment.NewLine
                    strsql += "from tqc " & Environment.NewLine
                    strsql += "where " & Environment.NewLine
                    strsql += "qcresult_ID = 1 and " & Environment.NewLine
                    strsql += "device_id = " & iDevice_ID & " and " & Environment.NewLine
                    strsql += "QCType_ID = " & iQCtype & ";"

                    objMisc._SQL = strsql

                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        R1 = dt1.Rows(0)
                        iExists = R1("cnt")
                    End If

                    If iExists > 0 Then
                        Throw New Exception("This device has already been Passed once.")
                    End If
                End If

                '*************************************************************
                'Get iteration number
                '*************************************************************
                iIteration = GetMaxQCIteration(iDevice_ID) + 1
                '*************************************************************
                If iQCResult = 2 Then    'Fail

                    arrSplitLine = Split(Trim(strFailCodes), strDelimeter)

                    For i = 0 To UBound(arrSplitLine)
                        If Trim(arrSplitLine(i)) <> "" Then
                            strsql = ""
                            strsql = "Insert into tqc " & Environment.NewLine
                            strsql += "(QC_Date, QC_WorkDate, QCType_ID, QCResult_ID, Inspector_ID, Tech_ID, Device_ID, DCode_ID, QC_Iteration, Group_ID, Line_ID "
                            If iPalletID > 0 Then strsql += ", Pallett_ID " & Environment.NewLine
                            If strFailOther <> "" Then strsql += ", QC_OtherFails " & Environment.NewLine
                            strsql += ")" & Environment.NewLine
                            strsql += "Values ('" & strDate & "', '" & strWorkDate & "', " & iQCtype & ", " & iQCResult & ", " & iInspector_ID & ", " & iTech_ID & ", " & iDevice_ID & ", " & arrSplitLine(i) & ", " & iIteration & ", " & iGroupID & ", " & iLineID & ""
                            If iPalletID > 0 Then strsql += ", " & iPalletID & Environment.NewLine
                            If strFailOther <> "" Then strsql += ", '" & strFailOther & "'" & Environment.NewLine
                            strsql += ");" & Environment.NewLine
                            objMisc._SQL = strsql
                            j = objMisc.ExecuteNonQuery
                            iDcode_ID = arrSplitLine(i)
                        End If
                    Next i

                    ReDim arrSplitLine(0)
                    arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)

                    '************************************************
                    '''Update tcellopt table with QC Result Flag
                    strsql = ""
                    strsql = "update tcellopt set CellOpt_QCReject = " & iQCResult & ", CellOpt_QCFailCode = " & iDcode_ID & " where device_id = " & iDevice_ID & ";"
                    objMisc._SQL = strsql
                    j = objMisc.ExecuteNonQuery
                    '************************************************

                ElseIf iQCResult = 1 Then      'Pass
                    iQCCredit = Generic.CalQCCredit(iDevice_ID, iQCtype)
                    'Insert QC data
                    strsql = ""
                    strsql = "Insert into tqc " & Environment.NewLine
                    strsql += "(QC_Date, QC_WorkDate, QCType_ID, QCResult_ID, Inspector_ID, Tech_ID, Device_ID, DCode_ID, QC_Iteration, Group_ID, Line_ID, QCCredit" & Environment.NewLine
                    If iPalletID > 0 Then strsql += ", Pallett_ID "
                    strsql += ")" & Environment.NewLine
                    strsql += "Values ('" & strDate & "', '" & strWorkDate & "', " & iQCtype & ", " & iQCResult & ", " & iInspector_ID & ", " & iTech_ID & ", " & iDevice_ID & ", " & iDcode_ID & ", " & iIteration & ", " & iGroupID & ", " & iLineID & ", " & iQCCredit
                    If iPalletID > 0 Then strsql += ", " & iPalletID
                    strsql += ");" & Environment.NewLine
                    objMisc._SQL = strsql
                    j = objMisc.ExecuteNonQuery

                    '******************************************************************************
                    ' Update Device's Device Quantity for Plastronics Socket when AQL with PASS 
                    '******************************************************************************
                    If iProd_ID = 18 And iQCtype = 4 Then
                        strsql = "UPDATE tdevice" & Environment.NewLine
                        strsql &= "SET Device_Qty = " & iComponentQTY & Environment.NewLine
                        strsql &= "WHERE device_id = " & iDevice_ID & ";"
                        objMisc._SQL = strsql
                        j = objMisc.ExecuteNonQuery
                    End If
                End If

                '************************************************
                '''Update Wip-owner
                '************************************************
                If iWipOwner = 0 Then
                    iWipOwner = 3     'In-Cell
                    If iQCResult = 1 Then iWipOwner = 4 'Pass QC
                End If

                If iProd_ID = 1 Then    'Messaging
                    strsql = ""
                    strsql = "UPDATE tmessdata " & Environment.NewLine
                    strsql &= "SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id , tmessdata.wipowner_id = " & iWipOwner & ", tmessdata.wipowner_EntryDt = now(), wipownersubloc_id = " & iWipownersublocID & Environment.NewLine
                    strsql &= ", qcresult_id = " & iQCResult & ", qcwork_date = now() " & Environment.NewLine
                    strsql &= "WHERE device_id = " & iDevice_ID & ";"
                    objMisc._SQL = strsql
                    j = objMisc.ExecuteNonQuery


                    Dim _prc_desc As String
                    _prc_desc = "Messaging QC - "
                    Select Case iQCtype
                        Case 1 : _prc_desc &= "Functional "
                        Case 2 : _prc_desc &= "FQA "
                        Case 3 : _prc_desc &= "Cosmedic "
                        Case 4 : _prc_desc &= "AQL "
                    End Select
                    _prc_desc &= IIf(iQCResult = 1, " - Pass", " - Fail")

                    'ADD TO THE DEVICE JOURNAL.
                    BLL.MsgDeviceMovement.DeviceMovementJornalInsert(iDevice_ID, 1, iWipOwner, iWipownersublocID, _prc_desc)

                Else    'Not Messaging
                    'update tcellopt
                    strsql = ""
                    strsql = "UPDATE tcellopt " & Environment.NewLine
                    strsql &= "SET tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                    strsql &= ", tcellopt.Cellopt_WIPOwner = " & iWipOwner & ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                    strsql &= "WHERE device_id = " & iDevice_ID & ";"
                    objMisc._SQL = strsql
                    j = objMisc.ExecuteNonQuery


                End If

                Return j
            Catch ex As Exception
                Throw New Exception("Buisness.QC.SaveQCResults(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                ReDim arrSplitLine(0)
                arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
                R1 = Nothing
                DisposeDT(dt1)
                objGen = Nothing
            End Try
        End Function

        'Private Function GetFailCodes() As String
        '    Dim arrSplitLine
        '    'delimiter = ","
        '    'delimiter = Chr(9)
        '    arrSplitLine = Split(Trim(strLine), delimiter)

        '    For i = 0 To UBound(arrSplitLine)
        '        If Trim(arrSplitLine(i)) <> "" Then
        '            If Trim(arrSplitLine(i)) Like "*" & strTargetStr & "*" Then
        '                iFlag = 1
        '            ElseIf iFlag = 1 Then
        '                strVal = Trim(arrSplitLine(i))
        '                iFlag = 0
        '                Exit For
        '            End If
        '        End If
        '    Next i

        '    ReDim ClaimNoArray(0)
        '    ClaimNoArray.Clear(ClaimNoArray, 0, ClaimNoArray.Length)
        'End Function

        '*********************************************************************************************************
        Public Function SaveCode(ByVal iProdID As Integer, _
                                ByVal strDcode_Sdesc As String, _
                                ByVal strDcode_Ldesc As String, _
                                ByVal iMcode_Id As Integer, _
                                ByVal iDcode_Id As Integer, _
                                ByVal iInactive As Integer, ByVal strDcode_L2desc As String, ByVal iUserID As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As New DataTable()

            Try
                'Check if the Code already exists
                objMisc._SQL = "Select * from lcodesdetail where dcode_sdesc = '" & Generic.AddMySqlEscapeChar(strDcode_Sdesc) & "' and MCode_ID = " & iMcode_Id & ";"
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If iDcode_Id = 0 Then
                        Throw New Exception("Buisness.QC.SaveCode(): " & Environment.NewLine & "Code already exists. Can not create duplicates.")
                    ElseIf iDcode_Id <> dt1.Rows(0)("Dcode_Id") Then
                        Throw New Exception("Buisness.QC.SaveCode(): " & Environment.NewLine & "Code already exists. Can not create duplicates.")
                    End If
                End If

                'no exception
                If iDcode_Id = 0 Then
                    Return InsertLcodesDetail(strDcode_Sdesc, strDcode_Ldesc, strDcode_L2desc, iMcode_Id, iProdID, iInactive, iUserID)
                Else
                    Return UpdateLcodesDetail(strDcode_Sdesc, strDcode_Ldesc, strDcode_L2desc, iInactive, iDcode_Id, iUserID)
                End If
            Catch ex As Exception
                Throw New Exception("Buisness.QC.SaveCode(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '*********************************************************************************************************
        Public Function InsertLcodesDetail(ByVal strDcode_Sdesc As String, ByVal strDcode_Ldesc As String, _
                                           ByVal strDcode_L2desc As String, ByVal iMcodeID As Integer, _
                                           ByVal iProdID As Integer, ByVal iInactive As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "Insert into lcodesdetail " & Environment.NewLine
                strSql += "(Dcode_Sdesc, Dcode_Ldesc, Dcode_L2desc, Mcode_Id, Prod_ID, Dcode_Inactive, User_ID, UpdatedDate ) " & Environment.NewLine
                strSql += "Values ('" & Generic.AddMySqlEscapeChar(strDcode_Sdesc) & "' " & Environment.NewLine
                strSql += ", '" & Generic.AddMySqlEscapeChar(strDcode_Ldesc) & "' " & Environment.NewLine
                strSql += ", '" & Generic.AddMySqlEscapeChar(strDcode_L2desc) & "', " & iMcodeID & Environment.NewLine
                strSql += ", " & iProdID & "," & iInactive & ", " & iUserID & ", now() " & Environment.NewLine
                strSql &= ") "
                Return objMisc.idTransaction(strSql, "lcodesdetail")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function UpdateLcodesDetail(ByVal strDcode_Sdesc As String, ByVal strDcode_Ldesc As String, _
                                          ByVal strDcode_L2desc As String, ByVal iInactive As Integer, _
                                          ByVal iDCodeID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "Update lcodesdetail " + vbCrLf
                strSql += "set Dcode_Sdesc = '" & Generic.AddMySqlEscapeChar(strDcode_Sdesc) & "' " & vbCrLf
                strSql += ", Dcode_Ldesc = '" & Generic.AddMySqlEscapeChar(strDcode_Ldesc) & "' " & vbCrLf
                strSql += ", Dcode_L2desc = '" & Generic.AddMySqlEscapeChar(strDcode_L2desc) & "' " & vbCrLf
                strSql += ", Dcode_Inactive = " & iInactive & ", User_ID = " & iUserID & ", UpdatedDate = now()" & vbCrLf
                strSql += "where Dcode_Id = " & iDCodeID
                objMisc._SQL = strSql
                Return objMisc.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'Load product types
        '***************************************************
        Public Function LoadProductTypes() As DataTable
            Dim dt As DataTable

            Try
                objMisc._SQL = "select distinct lproduct.* from lproduct where Prod_Inactive = 0 ORDER BY Prod_Desc;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "Prod_ID", "Prod_Desc", , , "-- Select --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.LoadProductTypes(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Load Users
        '***************************************************
        Public Function LoadLines() As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "Select * from lline;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "Line_id", "Line_NUmber", , , "-- Select --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.LoadLines(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Load Groups
        '***************************************************
        Public Function LoadGroups(Optional ByVal iMasterGrp As Integer = 0) As DataTable
            Dim dt As DataTable
            Dim strSQL As String

            Try
                objMisc._SQL = "Select * from lgroups WHERE Active = 1" & Environment.NewLine
                If iMasterGrp <> 0 Then
                    objMisc._SQL &= " and mastergroup = " & iMasterGrp & Environment.NewLine
                End If
                objMisc._SQL &= " Order By 'group_desc';"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "group_id", "group_desc", , , "-- Select --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.LoadGroups(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Load Customers
        '***************************************************
        Public Function LoadCustomers() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT A.cust_id, A.cust_name1 AS 'Customer'" & Environment.NewLine
                strSQL &= "FROM production.tcustomer A" & Environment.NewLine
                strSQL &= "INNER JOIN production.lgroups B ON A.cust_id = B.cust_id" & Environment.NewLine
                strSQL &= "WHERE A.cust_inactive = 0 AND B.MasterGroup = 1" & Environment.NewLine
                strSQL &= "UNION" & Environment.NewLine
                strSQL &= "SELECT 0 AS cust_id, '-- Select --' AS 'Customer'" & Environment.NewLine
                strSQL &= "FROM production.tcustomer" & Environment.NewLine
                strSQL &= "ORDER BY Customer"

                objMisc._SQL = strSQL

                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.QC.LoadCustomers(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Load Manufacturers
        '***************************************************
        Public Function LoadManufacturers() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT manuf_id, manuf_desc AS 'Manufacturer'" & Environment.NewLine
                strSQL &= "FROM production.lmanuf" & Environment.NewLine
                strSQL &= "UNION" & Environment.NewLine
                strSQL &= "SELECT 0 AS manuf_id, '-- Select --' AS 'Manufacturer'" & Environment.NewLine
                strSQL &= "FROM production.lmanuf" & Environment.NewLine
                strSQL &= "ORDER BY Manufacturer"

                objMisc._SQL = strSQL

                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.QC.LoadManufacturers(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Load Users
        '***************************************************
        Public Function LoadUsers() As DataTable
            Dim dt As DataTable
            Try
                objMisc._SQL = "Select user_id, Concat(tech_id, ' - ', trim(user_fullname)) as user_fullname from security.tusers where tech_id > 0 AND user_inactive = 0 order by tech_id;"
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "user_id", "user_fullname", , , "-- Select --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.LoadUsers(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        'Select user_id, user_fullname from security.tusers where tech_id > 0
        '***************************************************
        'Load D codes
        '***************************************************
        Public Function LoadCodes(ByVal iProd_ID As Integer, _
                                  ByVal iMcode As Integer) As DataTable
            Dim dt As DataTable
            Try

                objMisc._SQL = "Select * from lcodesdetail where mcode_id = " & iMcode & " and Prod_ID = " & iProd_ID & " order by Dcode_Sdesc ;"
                dt = objMisc.GetDataTable
                dt.LoadDataRow(New Object() {0, "--Select--", "--Select--", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.LoadCodes(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '***************************************************
        'Get QC related Master Codes for QC
        '***************************************************
        Public Function LoadQCMasterCodes(ByVal iProd_ID As Integer) As DataTable
            Dim dt As DataTable
            Try
                'objMisc._SQL = "Select * from lcodesmaster where Prod_ID = " & iProd_ID & " AND QCScreen = 1 order by Mcode_Desc;"
                objMisc._SQL = "Select * from lcodesmaster where Prod_ID = " & iProd_ID & " AND ( QCScreen = 1 or TechScreen=1 ) order by Mcode_Desc;"

                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "MCode_ID", "MCode_Desc", , , "-- ALL --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.LoadMasterCodes(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        Public Function LoadFailureCodes(ByVal iProd_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim iMCode_ID As Integer = 0
            Dim strSql As String = ""

            Try
                strSql = "SELECT DCode_ID, Dcode_SDesc, Dcode_Ldesc, Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_SLDesc " & Environment.NewLine
                strSql &= "FROM lcodesdetail " & Environment.NewLine
                strSql &= "INNER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID " & Environment.NewLine
                strSql &= "WHERE QCScreen = 1 AND lcodesmaster.Prod_ID = " & iProd_ID & " AND Dcode_Inactive = 0 or Dcode_ID=3408 order by Dcode_Sdesc;"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "DCode_ID", "DCode_SLDesc", , , "-- SELECT --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.GetProducts(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        Public Function LoadFailureCodes_WiKo(ByVal iProd_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim iMCode_ID As Integer = 0
            Dim strSql As String = ""

            Try
                Select Case iLoc_ID
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_MCode_ID
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_MCode_ID
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_MCode_ID
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_MCode_ID
                    Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SP_MCode_ID
                End Select
                strSql = "SELECT DCode_ID, Dcode_SDesc, Dcode_Ldesc, Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_SLDesc" & Environment.NewLine
                strSql &= " FROM lcodesdetail" & Environment.NewLine
                strSql &= " INNER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID" & Environment.NewLine
                strSql &= " WHERE lcodesmaster.mcode_id = " & iMCode_ID & " AND lcodesmaster.Prod_ID = " & iProd_ID & "  AND Dcode_Inactive = 0 order by Dcode_Sdesc;" & Environment.NewLine

                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "DCode_ID", "DCode_SLDesc", , , "-- SELECT --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.GetProducts(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        'Added by Amazech-Thanga 07.08.2021
        Public Function LoadFailureCodes_WingTechATT(ByVal iProd_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim iMCode_ID As Integer = 0
            Dim strSql As String = ""

            Try
                Select Case iLoc_ID
                    Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_MCode_ID
                    Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_MCode_ID
                    Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_MCode_ID
                    Case PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_MCode_ID
                End Select
                strSql = "SELECT DCode_ID, Dcode_SDesc, Dcode_Ldesc, Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_SLDesc" & Environment.NewLine
                strSql &= " FROM lcodesdetail" & Environment.NewLine
                strSql &= " INNER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID" & Environment.NewLine
                strSql &= " WHERE lcodesmaster.mcode_id = " & iMCode_ID & " AND lcodesmaster.Prod_ID = " & iProd_ID & "  AND Dcode_Inactive = 0 order by Dcode_Sdesc;" & Environment.NewLine

                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "DCode_ID", "DCode_SLDesc", , , "-- SELECT --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.GetProducts(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        Public Function LoadFailureCodes_Vinsmart(ByVal iProd_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim iMCode_ID As Integer = 0
            Dim strSql As String = ""

            Try
                Select Case iLoc_ID
                    Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_MCode_ID
                 
                    Case PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID
                        iMCode_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SP_MCode_ID
                
                End Select
                strSql = "SELECT DCode_ID, Dcode_SDesc, Dcode_Ldesc, Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_SLDesc" & Environment.NewLine
                strSql &= " FROM lcodesdetail" & Environment.NewLine
                strSql &= " INNER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID" & Environment.NewLine
                strSql &= " WHERE lcodesmaster.mcode_id = " & iMCode_ID & " AND lcodesmaster.Prod_ID = " & iProd_ID & "  AND Dcode_Inactive = 0 order by Dcode_Sdesc;" & Environment.NewLine

                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                InsertEmptyRow(dt, , "DCode_ID", "DCode_SLDesc", , , "-- SELECT --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.QC.GetProducts(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Insert an empty row into the datatable
        '***************************************************
        Private Function InsertEmptyRow(ByRef dt As DataTable, _
                                        Optional ByVal iEmptyRowValue As Integer = 0, _
                                        Optional ByVal strFiledName1 As String = "", _
                                        Optional ByVal strFieldName2 As String = "", _
                                        Optional ByVal strFieldName3 As String = "", _
                                        Optional ByVal strFieldName4 As String = "", _
                                        Optional ByVal strEmptyRowDisplay As String = "")

            Dim R1 As DataRow
            Try
                R1 = dt.NewRow
                If strFiledName1 <> "" Then
                    R1(strFiledName1) = iEmptyRowValue
                End If
                If strFieldName2 <> "" Then
                    R1(strFieldName2) = strEmptyRowDisplay
                End If
                If strFieldName3 <> "" Then
                    R1(strFieldName3) = strEmptyRowDisplay
                End If

                dt.Rows.Add(R1)
            Catch ex As Exception
                Throw New Exception("Buisness.QC.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function
        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
            objMyLib = New MyLib.Utility()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            objMyLib = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '****************************************************
        Public Function CreateQR_Rpt(ByVal iWOID As Integer, _
                                     ByVal iLocID As Integer, _
                                     ByVal strFilePath As String, _
                                     ByVal dtCustFailReason As DataTable) As Integer
            'Excel Related variables
            Dim objDataProc As DBQuery.DataProc
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim dt As DataTable
            Dim R1 As DataRow
            Dim arrObj As Object(,)
            Dim arrObjSummarySheet As Object(,)
            Dim strArrHeader As String() = {"RMA#", "Model", "SN", "Receive Date", "Ship Date", "S25 or S89?", "Fail Reason", "Current Fail Reason", "Current Parts/ Service 1", _
                                            "Current Parts/ Service 2", "Current Parts/ Service 3", "Incoming Freq", "Incoming Cap Code", _
                                            "Previous Workorder#", "Previous Ship Date", "Previous S25 or S89?", "Previous Fail Reason", "Last Parts/ Service 1", _
                                            "Last Parts/ Service 2", "Last Parts/ Service 3", "Outgoing Freq", "Outgoing Cap Code", "QR Categories"}
            Dim strArrQRCategories As String() = {"No Ship Date", "No History", "> 90 days", "Prev NER/DBR", "Current NER/DBR", "Mismatch", "NFF", "Prog Issue", "LCD", "LCDx2", "PSS Wrty"}
            Dim i, j As Integer

            Try
                dt = Me.GetQRData(False, iWOID, iLocID, dtCustFailReason, )
                If dt.Rows.Count > 0 Then
                    '*******************************
                    'Instantiate Excel Object
                    '*******************************
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    If strFilePath.Trim.Length > 0 Then
                        objBook = objExcel.Workbooks.Open(strFilePath)
                    Else
                        objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    End If
                    objExcel.Application.Visible = True                'Make this false while going live
                    objExcel.Application.DisplayAlerts = False

                    '*******************************
                    'Summary data
                    '*******************************
                    i = 0
                    ReDim arrObjSummarySheet(strArrQRCategories.Length + 2, 3)

                    For i = 0 To strArrQRCategories.Length - 1
                        'Header
                        If i = 0 Then
                            arrObjSummarySheet(i, 0) = "Categories ID"
                            arrObjSummarySheet(i, 1) = "Categories Desc"
                            arrObjSummarySheet(i, 2) = "Count"
                        End If

                        'data
                        arrObjSummarySheet(i + 1, 0) = i + 1
                        arrObjSummarySheet(i + 1, 1) = strArrQRCategories(i)
                        arrObjSummarySheet(i + 1, 2) = CInt(dt.Compute("Count([QR Categories])", "[QR Categories] = " & i + 1))

                        'total
                        If i = strArrQRCategories.Length - 1 Then
                            arrObjSummarySheet(i + 2, 1) = "Total"
                            arrObjSummarySheet(i + 2, 2) = "=SUM(R[-" & strArrQRCategories.Length & "]C:R[-1]C)"
                        End If
                    Next i

                    '*******************************
                    '//Summary Page
                    '*******************************
                    objSheet = objBook.Worksheets.Add
                    objSheet.Name = "QR Summary"
                    objSheet.Range("A2" & ":C" & (strArrQRCategories.Length + 3).ToString).Value = arrObjSummarySheet

                    'Set column width
                    objSheet.Columns("A:A").ColumnWidth = 13
                    objSheet.Columns("B:B").ColumnWidth = 16
                    objSheet.Columns("C:C").ColumnWidth = 9

                    objExcel.Range("A2", "C2").Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 15
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    objExcel.Range("A" & (strArrQRCategories.Length + 3).ToString, "C" & (strArrQRCategories.Length + 3).ToString).Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 15
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    With objSheet.Range("A2", "C2").Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 10
                        .ColorIndex = 25
                    End With
                    With objSheet.Range("A" & (strArrQRCategories.Length + 3).ToString, "C" & (strArrQRCategories.Length + 3).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 10
                        .ColorIndex = 25
                    End With
                    objSheet.Range("A2", "C2").HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("B" & (strArrQRCategories.Length + 3).ToString, "B" & (strArrQRCategories.Length + 3).ToString).HorizontalAlignment = Excel.Constants.xlRight

                    'Draw a heavier border for total
                    objExcel.Range("A" & (strArrQRCategories.Length + 3).ToString & ":C" & (strArrQRCategories.Length + 3).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    '*******************************
                    'Detail Data
                    '*******************************
                    i = 0
                    j = 0
                    ReDim arrObj(dt.Rows.Count + 1, strArrHeader.Length)

                    'Header
                    For j = 0 To strArrHeader.Length - 1
                        arrObj(i, j) = strArrHeader(j)
                    Next j

                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To strArrHeader.Length - 1
                            If strArrHeader(j) = "QR Categories" Then arrObj(i + 1, j) = CInt(dt.Rows(i)(strArrHeader(j))) Else arrObj(i + 1, j) = dt.Rows(i)(strArrHeader(j))
                        Next j
                    Next i

                    '*******************************
                    '//Detail Page
                    '*******************************
                    objSheet = objBook.Worksheets.Add
                    objSheet.Name = "QR Detail"
                    objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                    'Set column C to number wit hzero decimal places in case of all-numeric SN
                    objSheet.Columns("C:C").Select()
                    objExcel.Selection.NumberFormat = "0"

                    'Set columns L:M and U:V to text format
                    objSheet.Columns("L:M").Select()
                    objExcel.Selection.NumberFormat = "@"
                    objSheet.Columns("U:V").Select()
                    objExcel.Selection.NumberFormat = "@"

                    'populate data to excel sheet
                    objSheet.Range("A1" & ":" & Generic.CalExcelColLetter(strArrHeader.Length) & (dt.Rows.Count + 1).ToString).Value = arrObj

                    '*******************************
                    'set border
                    '*******************************
                    objExcel.Range("A1:" & Generic.CalExcelColLetter(strArrHeader.Length) & (dt.Rows.Count + 1).ToString).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For i = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(i))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next i

                    'Draw a heavier border on the right side
                    objExcel.Range("M1" & ":M" & (dt.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    '*******************************
                    'header
                    '*******************************
                    objSheet.Range("A1", Generic.CalExcelColLetter(strArrHeader.Length) & (1).ToString).WrapText = True
                    objExcel.Range("A1", "M1").Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 6
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    objExcel.Range("N1", Generic.CalExcelColLetter(strArrHeader.Length) & "1").Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 8
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    With objSheet.Range("A1", Generic.CalExcelColLetter(strArrHeader.Length) & (1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 14
                        .Underline = True
                        .ColorIndex = 25
                    End With
                    objSheet.Range("A1", Generic.CalExcelColLetter(strArrHeader.Length) & (1).ToString).HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Range("A1", Generic.CalExcelColLetter(strArrHeader.Length) & (1).ToString).VerticalAlignment = Excel.Constants.xlTop
                    objSheet.Rows("1:1").RowHeight = 54

                    '***********************************
                    'Adjust column widths
                    '***********************************
                    For i = 0 To strArrHeader.Length - 1
                        If strArrHeader(i).Trim.EndsWith("Freq") Or strArrHeader(i).Trim.EndsWith("?") Then
                            objSheet.Columns(Chr(65 + i) & ":" & Generic.CalExcelColLetter(i + 1)).ColumnWidth = 13
                        ElseIf strArrHeader(i).Trim.EndsWith("Cap Code") Or strArrHeader(i).Trim.EndsWith("Date") Then
                            objSheet.Columns(Chr(65 + i) & ":" & Generic.CalExcelColLetter(i + 1)).ColumnWidth = 15
                        ElseIf strArrHeader(i).Trim.EndsWith("Cap Code") Or strArrHeader(i).Trim.EndsWith("Date") Then
                            objSheet.Columns(Chr(65 + i) & ":" & Generic.CalExcelColLetter(i + 1)).ColumnWidth = 15
                        Else
                            objSheet.Columns(Chr(65 + i) & ":" & Generic.CalExcelColLetter(i + 1)).ColumnWidth = 20
                        End If
                    Next i

                    '***********************************
                    'highlight Customer Complain Reason column
                    '***********************************
                    objExcel.Range("G1", "G" & (dt.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 37
                        .Pattern = Excel.Constants.xlSolid
                    End With

                    '***********************************
                    'Set page orientation
                    '***********************************
                    With objSheet.PageSetup
                        .Orientation = Excel.XlPageOrientation.xlLandscape
                        '.RightMargin = 4
                        '.LeftMargin = 4
                        .RightMargin = 0
                        .LeftMargin = 0
                        .TopMargin = 0
                        .BottomMargin = 0
                        .HeaderMargin = 0
                        .FooterMargin = 0
                        .LeftFooter = "** PSS Confidential **"
                        .CenterFooter = "&P of &N"
                        .RightFooter = "&D &T"
                        .FitToPagesWide = 1
                        .FitToPagesTall = 1
                    End With
                    '***********************************
                    'Set zoom
                    '***********************************
                    objExcel.ActiveWindow.Zoom = 75
                    '***********************************
                    'Move selection outside the data region 
                    '***********************************
                    objExcel.Range("A1:A1").Select()
                    ''***********************************
                    ''Delete unused worksheets
                    ''***********************************
                    'If objBook.Sheets.Count > 1 Then
                    '    For i = objBook.Sheets.Count To 2 Step -1
                    '        objBook.Sheets("Sheet" & i.ToString).Delete()
                    '    Next i
                    'End If
                    ''***********************************
                End If

            Catch ex As Exception
                Throw ex
            Finally
                arrObj = Nothing
                arrObj = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtCustFailReason)
            End Try
        End Function

        '****************************************************
        Public Function GetQRData(ByVal booSkipCategory1 As Boolean, _
                                  ByVal iWOID As Integer, _
                                  ByVal iLocID As Integer, _
                                  ByVal dtCustFailReason As DataTable, _
                                  Optional ByVal iDevice_ID As Integer = 0) As DataTable
            Dim strSql As String
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim objDataProc As DBQuery.DataProc
            Dim iPreviousDeviceID As Integer = 0
            Dim booNoShipDate, booNoHistory, booCurrRcvdGreater90daysOfPrevShipDate, booPrevNerDbr, booCurrNerDbr, booFreqCapMismatch, booCurrLvl3Part, booCurrLCD, booPrevLCD, booPassCurrPretest, booNoPageCurrPretest As Boolean
            Dim iCustID As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "Select Cust_ID From tlocation WHERE Loc_ID = " & iLocID
                iCustID = objDataProc.GetIntValue(strSql)

                'Get RMA/WO data
                strSql = "SELECT DISTINCT WO_CustWO as 'RMA#', Model_Desc as 'Model', Device_sn as 'SN' " & Environment.NewLine
                strSql &= ", DATE_FORMAT(Device_DateRec, '%m-%d-%y %H:%m:%s') as 'Receive Date' " & Environment.NewLine
                strSql &= ", if(Device_DateShip is null, '', DATE_FORMAT(Device_DateShip, '%m-%d-%y %H:%m:%s') ) as 'Ship Date' " & Environment.NewLine
                strSql &= ", if(Billcode_ID in (25, 89), 'YES', 'NO') as 'S25 or S89?' " & Environment.NewLine
                strSql &= ", '' as 'Fail Reason' " & Environment.NewLine
                strSql &= ", '' as 'Current Fail Reason' " & Environment.NewLine
                strSql &= ", '' as 'Current Parts/ Service 1', '' as 'Current Parts/ Service 2', '' as 'Current Parts/ Service 3' " & Environment.NewLine
                strSql &= ", '' as 'Incoming Freq', '' as 'Incoming Cap Code' " & Environment.NewLine
                strSql &= ", '' as 'Previous Workorder#', '' as 'Previous Ship Date' " & Environment.NewLine
                strSql &= ", '' as 'Previous S25 or S89?' " & Environment.NewLine
                strSql &= ", '' as 'Previous Fail Reason' " & Environment.NewLine
                strSql &= ", '' as 'Last Parts/ Service 1', '' as 'Last Parts/ Service 2', '' as 'Last Parts/ Service 3' " & Environment.NewLine
                strSql &= ", '' as 'Outgoing Freq', '' as 'Outgoing Cap code' " & Environment.NewLine
                strSql &= ", tdevice.Device_ID  " & Environment.NewLine
                strSql &= ", 0 as 'QR Categories' " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER join tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.WO_ID = " & iWOID & Environment.NewLine
                If iDevice_ID > 0 Then strSql &= "AND tdevice.Device_ID = " & iDevice_ID & Environment.NewLine
                dt1 = objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    booNoShipDate = False
                    booNoHistory = False
                    booCurrRcvdGreater90daysOfPrevShipDate = False
                    booPrevNerDbr = False
                    booCurrNerDbr = False
                    booFreqCapMismatch = False
                    booCurrLvl3Part = False
                    booCurrLCD = False
                    booPrevLCD = False
                    booPassCurrPretest = False
                    booNoPageCurrPretest = False
                    iPreviousDeviceID = 0

                    '// No Ship Date
                    If booSkipCategory1 = False AndAlso R1("Ship Date").ToString.Trim.Length = 0 Then booNoShipDate = True

                    R1.BeginEdit()
                    '1: Get current pretest fail reason
                    R1("Current Fail Reason") = Me.GetPretestFailReason(R1("Device_ID"), booPassCurrPretest, booNoPageCurrPretest)

                    '2: Get current Level 3 parts/service
                    Generic.DisposeDT(dt2)
                    dt2 = Me.Get3Level3PartsServices(R1("Device_ID"))
                    If dt2.Rows.Count > 0 Then R1("Current Parts/ Service 1") = dt2.Rows(0)("BillCode_Desc")
                    If dt2.Rows.Count > 1 Then R1("Current Parts/ Service 2") = dt2.Rows(1)("BillCode_Desc")
                    If dt2.Rows.Count > 2 Then R1("Current Parts/ Service 3") = dt2.Rows(2)("BillCode_Desc")

                    If dt2.Rows.Count > 0 Then booCurrLvl3Part = True
                    '// Current level 3 parts/service??
                    If dt2.Rows.Count > 0 Then booCurrLvl3Part = True

                    '3: Get incoming freq & cap code
                    Generic.DisposeDT(dt2)
                    If iLocID = 19 Then 'American Messaging
                        strSql = "SELECT if(Device_Freq is null, '', Device_Freq) as 'Freq' " & Environment.NewLine
                        strSql &= ", if(Device_CapCode is null, '', Device_CapCode) as 'Cap' " & Environment.NewLine
                        strSql &= "FROM tverdata " & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & R1("Device_ID") & Environment.NewLine
                        dt2 = objDataProc.GetDataTable(strSql)
                    ElseIf iLocID = 2062 Then 'Skytel
                        strSql = "SELECT if(sd_FreqNo is null, '', sd_FreqNo) as 'Freq' " & Environment.NewLine
                        strSql &= ", if(sd_CapCode is null, '', sd_CapCode) as 'Cap' " & Environment.NewLine
                        strSql &= "FROM t" & iCustID & "data " & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & R1("Device_ID") & Environment.NewLine
                        dt2 = objDataProc.GetDataTable(strSql)
                    Else
                        strSql = "SELECT if(Device_Freq is null, '', Device_Freq) as 'Freq' " & Environment.NewLine
                        strSql &= ", if(Device_CapCode is null, '', Device_CapCode) as 'Cap' " & Environment.NewLine
                        strSql &= "FROM t" & iCustID & "data " & Environment.NewLine
                        strSql &= "WHERE Device_ID = " & R1("Device_ID") & Environment.NewLine
                        dt2 = objDataProc.GetDataTable(strSql)
                    End If

                    If Not IsNothing(dt2) AndAlso dt2.Rows.Count > 0 Then
                        R1("Incoming Freq") = dt2.Rows(0)("Freq")
                        R1("Incoming Cap Code") = dt2.Rows(0)("Cap")
                    End If

                    '4: Get previous repair history
                    Generic.DisposeDT(dt2)

                    strSql = "SELECT DISTINCT WO_CustWO " & Environment.NewLine
                    strSql &= ", if(Device_DateShip is null, '', DATE_FORMAT(Device_DateShip, '%m-%d-%y %H:%m:%s') ) as 'Ship Date' " & Environment.NewLine
                    strSql &= ", if(Billcode_ID in (25, 89), 'YES', 'NO') as 'S25 or S89?' " & Environment.NewLine
                    strSql &= ", if(lfrequency.freq_Number is null, '', lfrequency.freq_Number ) as freq_Number " & Environment.NewLine
                    strSql &= ", if(tmessdata.capcode is null, '', tmessdata.capcode ) as capcode " & Environment.NewLine
                    strSql &= ", tdevice.Device_ID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                    strSql &= "LEFT OUTER join tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "where device_sn = '" & R1("SN") & "' " & Environment.NewLine
                    strSql &= "AND tdevice.device_id <> " & R1("Device_ID") & Environment.NewLine
                    strSql &= "AND Date_format(tdevice.Device_DateShip, '%Y-%m-%d') <= '" & Format(CDate(R1("Receive Date")), "yyyy-MM-dd") & "'" & Environment.NewLine
                    strSql &= "order by tdevice.Device_DateShip desc " & Environment.NewLine
                    strSql &= "limit 1 " & Environment.NewLine
                    dt2 = objDataProc.GetDataTable(strSql)
                    If dt2.Rows.Count > 0 Then
                        R2 = dt2.Rows(0)
                        iPreviousDeviceID = R2("Device_ID")

                        R1("Previous Workorder#") = R2("WO_CustWO")
                        R1("Previous Ship Date") = R2("Ship Date")
                        R1("Previous S25 or S89?") = R2("S25 or S89?")
                        R1("Outgoing Freq") = R2("freq_Number")
                        R1("Outgoing Cap code") = R2("capcode")

                        '4.1: Get previous pretest fail reason
                        R1("Previous Fail Reason") = Me.GetPretestFailReason(iPreviousDeviceID, )

                        '4.2: Get previous Level 3 parts/service
                        Generic.DisposeDT(dt2)
                        dt2 = Me.Get3Level3PartsServices(iPreviousDeviceID)
                        If dt2.Rows.Count > 0 Then R1("Last Parts/ Service 1") = dt2.Rows(0)("BillCode_Desc")
                        If dt2.Rows.Count > 1 Then R1("Last Parts/ Service 2") = dt2.Rows(1)("BillCode_Desc")
                        If dt2.Rows.Count > 2 Then R1("Last Parts/ Service 3") = dt2.Rows(2)("BillCode_Desc")

                        '//category 2: Receive date greater than previous ship date
                        If DateDiff(DateInterval.Day, CDate(R2("Ship Date")), CDate(R1("Receive Date"))) > 90 Then booCurrRcvdGreater90daysOfPrevShipDate = True
                        '//category 3: Previous NER/DBR
                        If R2("S25 or S89?").ToString.Trim.ToUpper = "YES" Then booPrevNerDbr = True
                    Else
                        '//category 1: No history
                        booNoHistory = True
                    End If

                    '//category 4: Current Status is NER/DBR
                    If R1("S25 or S89?").ToString.Trim.ToUpper = "YES" Then booCurrNerDbr = True
                    '//Category 5: Current incoming capcode and freq is different with previous outgoing capcode and freq
                    If (R1("Incoming Freq").ToString.Trim.ToUpper <> R1("Outgoing Freq").ToString.Trim.ToUpper) Or (R1("Incoming Cap Code").ToString.Trim.ToUpper <> R1("Outgoing Cap code")) Then booFreqCapMismatch = True
                    Me.GetCurrLCDAndPrevLCD(R1("Device_ID"), iPreviousDeviceID, booCurrLCD, booPrevLCD)

                    R1("QR Categories") = Me.GetQRCategory(booNoShipDate, booNoHistory, booCurrRcvdGreater90daysOfPrevShipDate, booPrevNerDbr, booCurrNerDbr, booFreqCapMismatch, booCurrLvl3Part, booCurrLCD, booPrevLCD, booPassCurrPretest, booNoPageCurrPretest)

                    '5: add customer fail reason
                    If Not IsNothing(dtCustFailReason) Then
                        If dtCustFailReason.Rows.Count > 0 Then
                            If dtCustFailReason.Select("SN = '" & R1("SN") & "'").Length > 0 Then R1("Fail Reason") = dtCustFailReason.Select("SN = '" & R1("SN") & "'")(0)(1)
                        End If
                    End If

                    R1.EndEdit()
                    R1.AcceptChanges()
                    iPreviousDeviceID = 0
                Next R1

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt2)
                Generic.DisposeDT(dtCustFailReason)
            End Try
        End Function

        '****************************************************
        Private Function GetPretestFailReason(ByVal iDeviceID As Integer, _
                                              Optional ByRef booPassCurrPretest As Boolean = False, _
                                              Optional ByRef booNoPageCurrPretest As Boolean = False) As String
            Dim strSql As String
            Dim strFailReason As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                'Get RMA/WO data
                strSql = "SELECT Dcode_Ldesc, PTtf , Dcode_Sdesc " & Environment.NewLine
                strSql &= "FROM tpretest_data " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
                strSql &= "WHERE device_id = " & iDeviceID & Environment.NewLine
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If strFailReason.Trim.Length > 0 Then strFailReason &= "; "
                    strFailReason &= R1("Dcode_Ldesc")

                    If booPassCurrPretest = False AndAlso R1("PTtf") = 2515 Then booPassCurrPretest = True
                    If booPassCurrPretest = False AndAlso R1("PTtf") = 2419 AndAlso R1("Dcode_Sdesc") = 100 Then booNoPageCurrPretest = True
                Next R1

                Return strFailReason
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '****************************************************
        Private Function Get3Level3PartsServices(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String
            Dim dt1 As DataTable

            Try
                'Get RMA/WO data
                strSql = "SELECT BillCode_Desc " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes  ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDeviceID & Environment.NewLine
                strSql &= "AND tpsmap.LaborLvl_ID = 3 " & Environment.NewLine
                strSql &= "ORDER BY tpsmap.LaborLvl_ID DESC " & Environment.NewLine
                strSql &= "Limit 3" & Environment.NewLine
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '****************************************************
        Public Function GetCustFailReason(ByVal strFilePath As String) As DataTable
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim objDataset1 As New DataSet()
            Dim dt As New DataTable()

            Try
                '//Create a datatable of all values from the assigned file
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()

                objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$] WHERE [SN] is not null or [SN] <> '' ORDER BY [SN]")
                'objCmdSelect.CommandText = ("SELECT * FROM [QR Detail$] WHERE [SN] is not null or [SN] <> '' ORDER BY [SN]")

                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dt)
                objAdapter1.Fill(objDataset1, "XLData")

                Return dt
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return dt
            Finally
                Generic.DisposeDT(dt)
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
                If Not IsNothing(objDataset1) Then
                    objDataset1.Dispose()
                    objDataset1 = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '****************************************************
        Private Sub GetCurrLCDAndPrevLCD(ByVal iCurrDeviceID As Integer, _
                                         ByVal iPrevDeviceID As Integer, _
                                         ByRef booCurrLCD As Boolean, _
                                         ByRef booPrevLCD As Boolean)
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'Category 8: LCD 
                strSql = "SELECT Distinct Billcode_desc " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes  ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.device_id = " & iCurrDeviceID & Environment.NewLine
                strSql &= "AND Billcode_desc like '%LCD%' " & Environment.NewLine
                Me.objMisc._SQL = strSql
                dt = Me.objMisc.GetDataTable

                If dt.Rows.Count > 0 Then booCurrLCD = True

                Me.DisposeDT(dt)

                ' Prev LCD
                If iPrevDeviceID > 0 Then
                    strSql = "SELECT Distinct Billcode_desc " & Environment.NewLine
                    strSql &= "FROM tdevicebill " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes  ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevicebill.device_id = " & iPrevDeviceID & Environment.NewLine
                    strSql &= "AND Billcode_desc like '%LCD%' " & Environment.NewLine
                    Me.objMisc._SQL = strSql
                    dt = Me.objMisc.GetDataTable

                    If dt.Rows.Count > 0 Then booPrevLCD = True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub


        '****************************************************
        Private Function GetQRCategory(ByVal booNoShipDate As Boolean, _
                                       ByVal booNoHistory As Boolean, _
                                       ByVal bbooCurrRcvdGreater90daysOfPrevShipDate As Boolean, _
                                       ByVal booPrevNerDbr As Boolean, _
                                       ByVal booCurrNerDbr As Boolean, _
                                       ByVal booFreqCapMismatch As Boolean, _
                                       ByVal booCurrLvl3Part As Boolean, _
                                       ByVal booCurrLCD As Boolean, _
                                       ByVal booPrevLCD As Boolean, _
                                       ByVal booPassCurrPretest As Boolean, _
                                       ByVal booNoPageCurrPretest As Boolean) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                If booNoShipDate = True Then
                    'Category 1: No Ship Date
                    Return 1
                ElseIf booNoHistory = True Then
                    'Category 2: No History 
                    Return 2
                ElseIf bbooCurrRcvdGreater90daysOfPrevShipDate = True Then
                    'Category 3: > 90 days 
                    Return 3
                ElseIf booPrevNerDbr = True Then
                    'Category 4: Prev NER/DBR 
                    Return 4
                ElseIf booCurrNerDbr Then
                    'Category 5: Current NER/DBR 
                    Return 5
                ElseIf booFreqCapMismatch = True Then
                    'Category 6: Mismatch 
                    Return 6
                ElseIf booPassCurrPretest = True And booCurrLvl3Part = False Then
                    'Category 7: NFF 
                    Return 7
                ElseIf booNoPageCurrPretest = True And booCurrLvl3Part = False Then
                    'Category 8: Prog Issue 
                    Return 8
                ElseIf booCurrLCD = True And booPrevLCD = False Then
                    'Category 9: LCD 
                    Return 9
                ElseIf booCurrLCD = True And booPrevLCD = True Then
                    'Category 10: LCDx2 
                    Return 10
                Else
                    'Category 11: PSS Wrty
                    Return 11
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************
        Public Function CreateLCDRepairHistoryRpt(ByVal iStartCol As Integer, _
                                                  ByVal strFilePatth As String, _
                                                  ByVal iCustID As Integer) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1 As DataRow
            Dim dt1, dt2 As DataTable
            Dim i As Integer
            Dim iCurrentCol As Integer
            Dim strSql As String = ""
            Dim strSN As String = ""
            Dim booLCD As Boolean = False
            Dim iw As Integer
            Dim iC As Integer
            Dim iMaxCol As Integer = 0
            Dim booHasData As Boolean = False

            Dim objQC As PSS.Data.Buisness.QC

            Try
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                iw = objBook.Application.Sheets.Count()
                iC = iw

                While (iw > 0)
                    objSheet = objExcel.Worksheets((iC - iw) + 1)
                    objExcel.Visible = True
                    i = 2
                    booHasData = False

                    While Not IsNothing(objSheet.Range("A" & i).Value) AndAlso objSheet.Range("A" & i).Value.ToString.Trim.Length <> 0
                        strSN = UCase(Trim(objSheet.Range("A" & i).Value))

                        If strSN <> "" Then
                            strSql = "SELECT tdevice.* FROM tdevice " & Environment.NewLine
                            strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                            strSql &= "WHERE tlocation.Cust_ID = " & iCustID & Environment.NewLine
                            strSql &= "AND device_sn = '" & strSN & "' AND Device_DateShip is not null Order by Device_DateShip desc;"
                            Me.objMisc._SQL = strSql
                            dt1 = Me.objMisc.GetDataTable

                            If dt1.Rows.Count > iMaxCol Then iMaxCol = dt1.Rows.Count
                            iCurrentCol = iStartCol
                            If dt1.Rows.Count > 0 Then
                                booHasData = True

                                For Each R1 In dt1.Rows
                                    booLCD = False
                                    Me.DisposeDT(dt2)
                                    strSql = "select tdevicebill.*, billcode_desc from tdevicebill inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id where tdevicebill.device_id = " & R1("Device_ID") & " and billcode_desc like '%LCD%'"
                                    Me.objMisc._SQL = strSql
                                    dt2 = Me.objMisc.GetDataTable

                                    If dt2.Rows.Count > 0 Then booLCD = True

                                    objSheet.Range(Generic.CalExcelColLetter(iCurrentCol) & i).FormulaR1C1 = R1("Device_DateShip")
                                    If booLCD = True Then
                                        objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 1) & i).FormulaR1C1 = "YES - " & dt2.Rows(0)("billcode_desc")
                                        objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 2) & i).FormulaR1C1 = dt2.Rows(0)("Date_Rec")

                                    Else
                                        objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 1) & i).FormulaR1C1 = "NO"
                                    End If

                                    iCurrentCol += 3

                                Next R1
                            Else
                                objSheet.Range(Generic.CalExcelColLetter(iStartCol) & i).FormulaR1C1 = "NOT IN SYSTEM"
                            End If
                        End If
                        i += 1
                        Me.DisposeDT(dt2)
                        strSN = ""
                        strSql = ""
                        Me.DisposeDT(dt1)
                    End While
                    iw -= 1

                    If booHasData = True Then
                        iCurrentCol = iStartCol
                        For i = 0 To iMaxCol - 1
                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol) & 1).Value = ("Date Ship")
                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 1) & 1).Value = ("LCD?")
                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 2) & 1).Value = ("Date Bill")
                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol) & 1, Generic.CalExcelColLetter(iCurrentCol + 2) & 1).Font.Bold = True
                            iCurrentCol += 3
                        Next i

                        objSheet.Cells.EntireColumn.AutoFit()
                        objSheet.Cells.EntireRow.AutoFit()
                    End If
                End While

                objBook.SaveAs(strFilePatth)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dt2)
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '****************************************************
        Public Function CreateRepairHistoryRpt(ByVal iStartCol As Integer, _
                                                  ByVal strFilePatth As String, _
                                                  ByVal iCustID As Integer) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1, drDeviceCnt As DataRow
            Dim dt1, dt2 As DataTable
            Dim i As Integer
            Dim iCurrentCol As Integer
            Dim strSql As String = ""
            Dim strSN As String = ""
            Dim iw As Integer
            Dim iC As Integer
            Dim iMaxCol As Integer = 0
            Dim booHasData As Boolean = False
            Dim strBillcodeDesc As String = ""

            Dim objQC As PSS.Data.Buisness.QC

            Try
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                iw = objBook.Application.Sheets.Count()
                iC = iw

                While (iw > 0)
                    objSheet = objExcel.Worksheets((iC - iw) + 1)
                    objExcel.Visible = True
                    i = 2
                    booHasData = False

                    While Not IsNothing(objSheet.Range("A" & i).Value) AndAlso objSheet.Range("A" & i).Value.ToString.Trim.Length <> 0
                        strSN = UCase(Trim(objSheet.Range("A" & i).Value))

                        If strSN <> "" Then
                            strSql = "SELECT tdevice.* FROM tdevice " & Environment.NewLine
                            strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                            strSql &= "WHERE tlocation.Cust_ID = " & iCustID & Environment.NewLine
                            strSql &= "AND device_sn = '" & strSN & "' AND Device_DateShip is not null Order by Device_DateShip desc;"
                            Me.objMisc._SQL = strSql
                            dt1 = Me.objMisc.GetDataTable

                            If dt1.Rows.Count > iMaxCol Then iMaxCol = dt1.Rows.Count
                            iCurrentCol = iStartCol
                            If dt1.Rows.Count > 0 Then
                                booHasData = True

                                For Each drDeviceCnt In dt1.Rows
                                    Me.DisposeDT(dt2)
                                    strBillcodeDesc = ""

                                    strSql = "select distinct Billcode_Desc from tdevicebill inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id where tdevicebill.device_id = " & drDeviceCnt("Device_ID")
                                    Me.objMisc._SQL = strSql
                                    dt2 = Me.objMisc.GetDataTable
                                    For Each R1 In dt2.Rows
                                        If strBillcodeDesc.Trim.Length > 0 Then strBillcodeDesc &= ";"
                                        strBillcodeDesc &= R1("Billcode_Desc")
                                    Next R1
                                    objSheet.Range(Generic.CalExcelColLetter(iCurrentCol) & i).FormulaR1C1 = drDeviceCnt("Device_DateShip")
                                    objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 1) & i).FormulaR1C1 = strBillcodeDesc

                                    iCurrentCol += 2

                                Next drDeviceCnt

                            Else
                                objSheet.Range(Generic.CalExcelColLetter(iStartCol) & i).FormulaR1C1 = "NOT IN SYSTEM"
                            End If
                        End If
                        i += 1
                        Me.DisposeDT(dt2)
                        strSN = ""
                        strSql = ""
                        Me.DisposeDT(dt1)
                    End While
                    iw -= 1
                    If booHasData = True Then
                        iCurrentCol = iStartCol
                        For i = 0 To iMaxCol - 1
                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol) & 1).Value = ("Date Ship")
                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol + 1) & 1).Value = ("Part/Service")

                            objSheet.Range(Generic.CalExcelColLetter(iCurrentCol) & 1, Generic.CalExcelColLetter(iCurrentCol + 1) & 1).Font.Bold = True
                            iCurrentCol += 2
                        Next i
                    End If
                End While

                MsgBox("Completed.")
                objBook.SaveAs(strFilePatth)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dt2)
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Public Function CreatePreQCHistoryRpt(ByVal iStartCol As Integer, _
                                         ByVal strFilePatth As String, _
                                         ByVal iCustID As Integer) As Integer
            Dim strHeader() As String = {"Pretest", "Function", "FQA", "Cosmetic", "AQL"}
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1, R2, drDeviceCnt As DataRow
            Dim dt1, dt2, dt3 As DataTable
            Dim i, j As Integer
            Dim strSql As String = ""
            Dim strSN As String = ""
            Dim iw As Integer
            Dim iC As Integer
            Dim iMaxCol As Integer = 0
            Dim booHasData As Boolean = False
            Dim strPrecodeDesc As String = ""
            Dim strQCcodeDesc As String = ""

            Dim objQC As PSS.Data.Buisness.QC
            Dim drQCType() As DataRow

            Try
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                iw = objBook.Application.Sheets.Count()
                iC = iw

                While (iw > 0)
                    objSheet = objExcel.Worksheets((iC - iw) + 1)
                    objExcel.Visible = True

                    i = 2
                    booHasData = False

                    While Not IsNothing(objSheet.Range("A" & i).Value) AndAlso objSheet.Range("A" & i).Value.ToString.Trim.Length <> 0
                        strSN = UCase(Trim(objSheet.Range("A" & i).Value))

                        If strSN <> "" Then
                            strSql = "SELECT tdevice.* FROM tdevice " & Environment.NewLine
                            strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                            strSql &= "WHERE tlocation.Cust_ID = " & iCustID & Environment.NewLine
                            strSql &= "AND device_sn = '" & strSN & "' AND Device_DateShip is not null Order by Device_ID desc Limit 1;"
                            Me.objMisc._SQL = strSql
                            dt1 = Me.objMisc.GetDataTable

                            If dt1.Rows.Count > 0 Then
                                booHasData = True

                                For Each drDeviceCnt In dt1.Rows
                                    Me.DisposeDT(dt2)
                                    Me.DisposeDT(dt3)
                                    strPrecodeDesc = ""
                                    strQCcodeDesc = ""
                                    strSql = "select user_fullname ,Dcode_Ldesc, Concat(Dcode_Ldesc,' (', user_fullname,')') As DcodeAUser from tpretest_data A" & Environment.NewLine
                                    strSql &= "inner join security.tusers B on A.Tester_UserID = B.User_ID" & Environment.NewLine
                                    strSql &= "inner join lcodesdetail C On A.pttf = C.Dcode_ID" & Environment.NewLine
                                    strSql &= "where device_id = " & drDeviceCnt("Device_ID")

                                    Me.objMisc._SQL = strSql
                                    dt2 = Me.objMisc.GetDataTable
                                    For Each R1 In dt2.Rows
                                        If strPrecodeDesc.Trim.Length > 0 Then strPrecodeDesc &= "; "
                                        strPrecodeDesc &= R1("DcodeAUser")
                                    Next R1

                                    objSheet.Range(Generic.CalExcelColLetter(iStartCol) & i).FormulaR1C1 = strPrecodeDesc

                                    strSql = "select user_fullname, Dcode_Ldesc, A.Qctype_ID, Concat(Dcode_Ldesc,' (',user_fullname,')') As QCUser from tqc A" & Environment.NewLine
                                    strSql &= "inner join security.tusers B on A.Inspector_ID = B.User_ID" & Environment.NewLine
                                    strSql &= "inner join lcodesdetail C On A.Dcode_ID = C.Dcode_ID" & Environment.NewLine
                                    strSql &= "inner join lqctype D on A.Qctype_ID = D.QCType_ID" & Environment.NewLine
                                    strSql &= "where device_id = " & drDeviceCnt("Device_ID") & Environment.NewLine
                                    strSql &= "order by qc_id;"

                                    Me.objMisc._SQL = strSql
                                    dt3 = Me.objMisc.GetDataTable

                                    'Functional 
                                    strQCcodeDesc = ""
                                    drQCType = Nothing
                                    drQCType = dt3.Select("Qctype_ID = 1", "")
                                    For j = 0 To drQCType.Length - 1
                                        If strQCcodeDesc.Trim.Length > 0 Then strQCcodeDesc &= "; "
                                        strQCcodeDesc &= drQCType(j)("QCUser")
                                    Next j
                                    objSheet.Range(Generic.CalExcelColLetter(iStartCol + 1) & i).FormulaR1C1 = strQCcodeDesc

                                    'FQA 
                                    strQCcodeDesc = ""
                                    drQCType = Nothing
                                    drQCType = dt3.Select("Qctype_ID = 2", "")
                                    For j = 0 To drQCType.Length - 1
                                        If strQCcodeDesc.Trim.Length > 0 Then strQCcodeDesc &= "; "
                                        strQCcodeDesc &= drQCType(j)("QCUser")
                                    Next j
                                    objSheet.Range(Generic.CalExcelColLetter(iStartCol + 2) & i).FormulaR1C1 = strQCcodeDesc

                                    'Cosmetic 
                                    strQCcodeDesc = ""
                                    drQCType = Nothing
                                    drQCType = dt3.Select("Qctype_ID = 3", "")
                                    For j = 0 To drQCType.Length - 1
                                        If strQCcodeDesc.Trim.Length > 0 Then strQCcodeDesc &= "; "
                                        strQCcodeDesc &= drQCType(j)("QCUser")
                                    Next j
                                    objSheet.Range(Generic.CalExcelColLetter(iStartCol + 3) & i).FormulaR1C1 = strQCcodeDesc

                                    'AQL 
                                    strQCcodeDesc = ""
                                    drQCType = Nothing
                                    drQCType = dt3.Select("Qctype_ID = 4", "")
                                    For j = 0 To drQCType.Length - 1
                                        If strQCcodeDesc.Trim.Length > 0 Then strQCcodeDesc &= "; "
                                        strQCcodeDesc &= drQCType(j)("QCUser")
                                    Next j
                                    objSheet.Range(Generic.CalExcelColLetter(iStartCol + 4) & i).FormulaR1C1 = strQCcodeDesc
                                Next drDeviceCnt

                            Else
                                objSheet.Range(Generic.CalExcelColLetter(iStartCol) & i).FormulaR1C1 = "NOT IN SYSTEM"
                            End If
                        End If
                        i += 1
                        Me.DisposeDT(dt3)
                        Me.DisposeDT(dt2)
                        strSN = ""
                        strSql = ""
                        Me.DisposeDT(dt1)
                    End While

                    If booHasData = True Then
                        '*****************************************
                        'format header
                        '*****************************************
                        objSheet.Range(Generic.CalExcelColLetter(iStartCol) & "1:" & Generic.CalExcelColLetter(iStartCol + 4) & "1").Select()
                        With objExcel.Selection
                            .WrapText = True
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            .Font.ColorIndex = 5
                            .Interior.ColorIndex = 37
                            .Interior.Pattern = Excel.Constants.xlSolid

                        End With

                        For j = 0 To strHeader.Length - 1
                            objSheet.Range(Generic.CalExcelColLetter(iStartCol + j) & 1).FormulaR1C1 = strHeader(j)
                        Next j

                        objSheet.Cells.EntireColumn.AutoFit()
                        objSheet.Cells.EntireRow.AutoFit()
                    End If

                    iw -= 1
                End While

                objBook.SaveAs(strFilePatth)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                drQCType = Nothing
                R1 = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dt2)
                Me.DisposeDT(dt3)
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Public Function GetCustIDByPalletName(ByVal strPalletName As String) As Integer
            Dim strSql As String
            Try
                strSql = "Select Cust_ID from tpallett where Pallett_Name = '" & strPalletName & "';"
                Return objMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetLastQCRecord(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tqc.*, lqcresult.QCResult " & Environment.NewLine
                strSql &= "FROM tqc " & Environment.NewLine
                strSql &= "INNER JOIN lqcresult ON tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strSql &= " WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= " ORDER BY QC_ID DESC Limit 1;"
                Return objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetLastLastFQAQCResult(ByVal iDeviceID As Integer) As String
            Dim strSql As String
            Try
                strSql = "SELECT lqcresult.QCResult " & Environment.NewLine
                strSql &= "FROM tqc " & Environment.NewLine
                strSql &= "INNER JOIN lqcresult ON tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND QCType_ID = 2 " & Environment.NewLine     'FQA
                strSql &= "ORDER BY QC_ID DESC Limit 1;"
                Return objMisc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetQCHistoryWithPalletInfo(ByVal iDevice_ID As Integer) As DataTable
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim strsql As String = ""


            Try
                '*****************
                strsql = "Select " & Environment.NewLine
                strsql += "tqc.QC_Iteration as Iteration, " & Environment.NewLine
                strsql += "tqc.QC_Date as 'Date', " & Environment.NewLine
                strsql += "lqctype.QCType as 'Type', " & Environment.NewLine
                strsql += "lqcresult.qcresult as 'Result', " & Environment.NewLine
                strsql += "lcodesdetail.Dcode_SDesc as 'Failure Code', " & Environment.NewLine
                strsql += "lcodesdetail.Dcode_lDesc as 'Failure Reason', " & Environment.NewLine
                strsql += "'' as 'Inspector', " & Environment.NewLine
                strsql += "'' as 'Tech', " & Environment.NewLine
                strsql += "tqc.dcode_id, " & Environment.NewLine
                strsql += "tqc.Inspector_id, " & Environment.NewLine
                strsql += "tqc.tech_id, " & Environment.NewLine
                strsql += "tqc.QC_ID " & Environment.NewLine
                strsql += ", if(tpallett.Pallett_Name is null, '', Pallett_Name) as 'Box' " & Environment.NewLine
                strsql += "from tqc " & Environment.NewLine
                strsql += "inner join lqctype on tqc.QCType_ID = lqctype.QCType_ID " & Environment.NewLine
                strsql += "inner join lqcresult on tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strsql += "inner join lcodesdetail on tqc.dcode_id = lcodesdetail.dcode_id " & Environment.NewLine
                strsql += "inner join tdevice on tqc.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strsql += "left outer join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strsql += "where tqc.device_id = " & iDevice_ID & Environment.NewLine
                strsql += "ORDER BY tqc.QC_Iteration, QC_Date;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                '*****************
                'GEt User' Info
                strsql = ""
                strsql = "Select * from security.tusers order by User_ID;"
                objMisc._SQL = strsql
                dt2 = objMisc.GetDataTable
                '*****************
                For Each R1 In dt1.Rows
                    'Inspector Name
                    For Each R2 In dt2.Rows
                        If R1("Inspector_id") = R2("User_ID") Then
                            R1("Inspector") = "PSS QC " & R2("QCStamp") & " - " & Trim(R2("User_FullName"))
                        End If
                    Next R2
                    R2 = Nothing
                    'Tech Name
                    For Each R2 In dt2.Rows
                        If R1("tech_id") = R2("User_ID") Then
                            R1("Tech") = R2("Tech_id") & " - " & Trim(R2("User_FullName"))
                        End If
                    Next R2
                    R2 = Nothing
                    dt1.AcceptChanges()
                Next R1

                Return dt1
            Catch ex As Exception
                Throw New Exception("Buisness.QC.GetQCHistory(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
                DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletInfo(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tpallett WHERE pallett_ID = " & iPalletID & ";" & Environment.NewLine
                objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function SaveOutBoundCosmGrade(ByVal iDeviceID As Integer, ByVal iOBCosmGrade As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tcellopt SET OutBoundCosmGradeID = " & iOBCosmGrade & " WHERE Device_ID = " & iDeviceID & ";" & Environment.NewLine
                objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsRequire100PercentAQLTest(ByVal iCustID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT ReqAQLCheckOnAllUnit FROM tcustomer WHERE Cust_ID = " & iCustID
                If Me.objMisc.GetIntValue(strSql) = 1 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

    End Class

End Namespace