Imports PSS.Data.Buisness.Security

Namespace Buisness
    Public Class clsProdTracker

        Private _objMisc As Production.Misc
        Private _objSecurity As Buisness.Security

        '*******************************************************************************
        'Get productivity number 
        '*******************************************************************************
        Public Function GetProductivityNumber(ByVal strWorkDate As String, _
                                              ByVal iGroupID As Integer, _
                                              ByVal iTestTypeID As Integer) As DataTable
            Dim strSql As String
            Dim dt1, dt2, dt3 As DataTable
            Dim R1, R2 As DataRow
            Dim iTotal, i As Integer

            Try
                'Get Inspector
                strSql = "SELECT DISTINCT A.TD_UsrID, B.user_fullname as 'Inspector' " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers B ON A.TD_UsrID = B.User_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder D ON C.WO_ID = D.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND D.group_id = " & iGroupID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                _objMisc._SQL = strSql
                dt1 = _objMisc.GetDataTable()

                'Get Model
                strSql = "SELECT DISTINCT D.Model_ID, D.Model_Desc " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON B.WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel D On B.Model_ID = D.Model_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND C.group_id = " & iGroupID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "ORDER BY D.Model_Desc " & Environment.NewLine
                _objMisc._SQL = strSql
                dt2 = _objMisc.GetDataTable()

                'qty
                strSql = "SELECT A.TD_UsrID, Model_ID, count(*) as Qty " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON B.WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND C.group_id = " & iGroupID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "GROUP BY A.TD_UsrID, Model_ID " & Environment.NewLine
                _objMisc._SQL = strSql
                dt3 = _objMisc.GetDataTable()

                For Each R2 In dt2.Rows
                    Generic.AddNewColumnToDataTable(dt1, R2("Model_Desc"), "System.Int32", "0")
                    For Each R1 In dt1.Rows
                        R1.BeginEdit()
                        If dt3.Select("TD_UsrID = " & R1("TD_UsrID") & " AND Model_ID = " & R2("Model_ID")).Length > 0 Then R1(R2("Model_Desc")) = dt3.Select("TD_UsrID = " & R1("TD_UsrID") & " AND Model_ID = " & R2("Model_ID"))(0)("Qty")
                        R1.AcceptChanges()
                    Next R1
                Next R2

                Generic.AddNewColumnToDataTable(dt1, "Total", "System.Int32", "0")
                For Each R1 In dt1.Rows
                    iTotal = 0

                    For i = 0 To dt1.Columns.Count - 1
                        If dt1.Columns(i).Caption <> "TD_UsrID" AndAlso dt1.Columns(i).Caption <> "Inspector" Then iTotal += R1(dt1.Columns(i).Caption)
                    Next i

                    R1.BeginEdit()
                    R1("Total") = iTotal
                    R1.AcceptChanges()
                Next R1

                dt1.Columns.Remove("TD_UsrID") : dt1.AcceptChanges()

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : R2 = Nothing
                Generic.DisposeDT(dt1) : Generic.DisposeDT(dt2) : Generic.DisposeDT(dt3)
            End Try
        End Function

        '***************************************************
        'Get all PSS Shifts
        '***************************************************
        Public Function GetAllShifts() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Shift_ID, Concat('SHIFT ', Shift_Number) as Shift from tshift;"
                dt = Me._objMisc.GetDataTable(strSql)
                InsertEmptyRow(dt, , "Shift_ID", "Shift", , , "-- Select --")
                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetAllShifts(): " & Environment.NewLine & ex.Message.ToString)
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

                dt.Rows.Add(R1)
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
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
        Public Function GetHourlyDetail(ByVal iLine_ID As Integer, _
                                        ByVal strHourStart As String, _
                                        ByVal strHourEnd As String) _
                                        As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strDevID As String = ""
            Dim i As Integer = 0

            Try
                strsql = "Select Device_ID " & Environment.NewLine
                strsql &= "from tcellopt " & Environment.NewLine
                strsql &= "where " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteLineID = " & iLine_ID & " and " & Environment.NewLine
                'strsql &= "CellOpt_QCReject <> 2 and " & Environment.NewLine        'No QC Failures
                strsql &= "tcellopt.CellOpt_RefurbCompleteDt > '" & strHourStart & "' and " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteDt <= '" & strHourEnd & "';"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable
                '*************************************
                'Filter RURs and RTMs
                For Each R1 In dt1.Rows
                    If IsRURRTM(R1("Device_ID")) Then
                        R1.Delete()
                        i += 1
                    End If
                Next R1
                dt1.AcceptChanges()
                '*************************************
                R1 = Nothing
                i = 0
                '*************************************
                'Get data for REF devices
                For Each R1 In dt1.Rows
                    If i = dt1.Rows.Count - 1 Then
                        strDevID &= R1("Device_ID")
                    Else
                        strDevID &= R1("Device_ID") & ", "
                    End If
                    i += 1
                Next R1
                If Trim(strDevID) <> "" Then
                    strsql = "select security.tusers.user_fullname as Refurber, tmodel.Model_Desc as 'Model', count(*) as Produced, tmodel.model_id, tcellopt.CellOpt_RefurbCompleteUserID, tmodel.PiecesPerHour, security.tusers.tech_id " & Environment.NewLine
                    strsql &= "from tcellopt " & Environment.NewLine
                    strsql &= "inner join tdevice on tcellopt.device_id = tdevice.device_id " & Environment.NewLine
                    strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                    strsql &= "inner join security.tusers on tcellopt.CellOpt_RefurbCompleteUserID = security.tusers.user_id " & Environment.NewLine
                    strsql &= "where tcellopt.device_id in (" & strDevID & ") " & Environment.NewLine
                    strsql &= "group by CellOpt_RefurbCompleteUserID, Model_desc " & Environment.NewLine
                    strsql &= "order by security.tusers.user_fullname, Model_desc;"
                    Me._objMisc._SQL = strsql
                    Return Me._objMisc.GetDataTable
                Else
                    Return Nothing
                End If

                '*************************************
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
        Public Function GetHourlyDetail_Xtra(ByVal iLine_ID As Integer, _
                                        ByVal strHourStart As String, _
                                        ByVal strHourEnd As String, _
                                        ByVal iRefurbUser As Integer, _
                                        ByVal iModel_ID As Integer) _
                                        As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim NewRow As DataRow

            Try
                strsql = "Select tcellopt.Device_ID, Dcode_Ldesc as 'QC Fail Code' " & Environment.NewLine
                strsql &= "from tcellopt inner join tdevice on tcellopt.device_id = tdevice.device_id " & Environment.NewLine
                strsql &= "left outer join lcodesdetail on tcellopt.CellOpt_QCFailCode = lcodesdetail.dcode_id " & Environment.NewLine
                strsql &= "where " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteLineID = " & iLine_ID & " and " & Environment.NewLine
                strsql &= "tdevice.model_id = " & iModel_ID & " and " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteUserID = " & iRefurbUser & " and " & Environment.NewLine
                strsql &= "CellOpt_QCReject = 2 and " & Environment.NewLine        'No QC Failures
                strsql &= "tcellopt.CellOpt_RefurbCompleteDt > '" & strHourStart & "' and " & Environment.NewLine
                strsql &= "tcellopt.CellOpt_RefurbCompleteDt <= '" & strHourEnd & "' order by Dcode_Ldesc;"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable
                '*************************************
                'Filter RURs and RTMs
                For Each R1 In dt1.Rows
                    If IsRURRTM(R1("Device_ID")) Then
                        R1.Delete()
                        i += 1
                    End If
                Next R1
                dt1.AcceptChanges()

                'Add new row
                NewRow = dt1.NewRow()
                NewRow("QC Fail Code") = "Total = " & dt1.Rows.Count
                dt1.Rows.Add(NewRow)
                NewRow = Nothing
                dt1.AcceptChanges()
                '*************************************
                Return dt1

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

        Public Function GetRefurbNumbers(ByVal strWorkDate As String, _
                                        ByVal iShiftID As Integer, _
                                        ByVal iLineID As Integer, _
                                        ByVal iLineTarget As Integer) As DataTable
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim strShiftStartTime As String = ""
            Dim strShiftEndTime As String = ""
            Dim strHourStart As String = ""
            Dim strHourEnd As String = ""
            Dim iTotalShiftHours As Decimal
            Dim iPos As Integer = 0
            Dim i As Integer = 0
            Dim strHour As String = ""
            Dim iNoFullHours As Integer = 0
            Dim iTotalActualRefurb As Integer = 0
            Dim iTotalVariance As Integer = 0

            Dim iHourlyTarget As Integer = 0
            Dim iActualHourlyProd As Integer = 0
            Dim iVariance As Integer = 0

            Dim dtNewTable As DataTable
            Dim ColNew As DataColumn
            Dim NewRow As DataRow

            Dim iPSSWeekDay As Integer = 0
            Dim iShiftStartDay As Integer = 0
            Dim iShiftEndDay As Integer = 0

            Try
                '''Step 1: Get the Shift Information
                R1 = Me._objSecurity.GetShiftDetail(iShiftID)
                '*************************
                'Step 1: get PSS WeekDay of the Work Date
                '*************************
                R2 = Me._objSecurity.GetPSSWeekDay(WeekdayName(Weekday(CDate(strWorkDate))))
                iPSSWeekDay = R2("weekday_id")
                R2 = Nothing
                '*************************
                'Step 2: Get Current Shift details
                '*************************
                iShiftStartDay = R1("shift_startday")
                iShiftEndDay = R1("shift_endday")

                If iPSSWeekDay < iShiftStartDay Or iPSSWeekDay > iShiftEndDay Then
                    Throw New Exception("This shift does not work on this Work Date.")
                End If

                '*************************
                '''Step 2: Get Start and End Date Times
                '*************************
                strShiftStartTime = strWorkDate & " " & Trim(R1("Shift_StartTime"))
                If R1("Shift_Flag") = 9 Then
                    strShiftEndTime = DateAdd("d", 1, CDate(strWorkDate)) & " " & Trim(R1("Shift_EndTime"))
                Else
                    strShiftEndTime = strWorkDate & " " & Trim(R1("Shift_EndTime"))
                End If

                strShiftEndTime = Format(CDate(strShiftEndTime), "yyyy-MM-dd HH:mm:ss")
                '*************************
                '''Step 3: Calculate the Total Number of Hours
                '*************************
                iTotalShiftHours = DateDiff(DateInterval.Minute, CDate(strShiftStartTime), CDate(strShiftEndTime)) / 60

                '''Get the Whole Hours
                'iPos = iTotalShiftHours Mod 1

                If iTotalShiftHours Mod 1 > 0 Then
                    iPos = InStr(Trim(CStr(iTotalShiftHours)), ".")
                    iNoFullHours = Left(CStr(iTotalShiftHours), iPos - 1)
                Else
                    iNoFullHours = iTotalShiftHours
                End If

                'iNoFullHours = iTotalShiftHours
                '********************************************************
                'Create a a new datatable
                '********************************************************
                If Not IsNothing(dtNewTable) Then
                    dtNewTable.Dispose()
                    dtNewTable = Nothing
                End If

                dtNewTable = New DataTable()    'Create new datatable

                ColNew = New DataColumn("Hour")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Shift Start Time")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Shift End Time")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Hour Start Time")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Hour End Time")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Target")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Produced")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Variance")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing
                '***********************
                'Calculate Hourly Target
                iHourlyTarget = iLineTarget / iNoFullHours
                '''**************************************************
                For i = 1 To iNoFullHours
                    strHour = "HOUR " & i
                    If i = 1 Then
                        strHourStart = strShiftStartTime
                        strHourEnd = CStr(Format(DateAdd(DateInterval.Hour, i, CDate(strShiftStartTime)), "yyyy-MM-dd HH:mm:ss"))
                    Else
                        strHourStart = strHourEnd
                        strHourEnd = CStr(Format(DateAdd(DateInterval.Hour, i, CDate(strShiftStartTime)), "yyyy-MM-dd HH:mm:ss"))
                    End If
                    '***********************
                    'Calculate Actual Hourly Prod
                    iActualHourlyProd = Me.GetHourlyProduction(iLineID, strHourStart, strHourEnd)
                    iTotalActualRefurb += iActualHourlyProd
                    'Calculate Variance
                    iVariance = iActualHourlyProd - iHourlyTarget
                    iTotalVariance += iVariance
                    '***********************
                    'Add new row
                    NewRow = dtNewTable.NewRow()
                    NewRow("Hour") = strHour
                    NewRow("Shift Start Time") = strShiftStartTime
                    NewRow("Shift End Time") = strShiftEndTime
                    NewRow("Hour Start Time") = strHourStart
                    NewRow("Hour End Time") = strHourEnd
                    NewRow("Target") = iHourlyTarget
                    NewRow("Produced") = iActualHourlyProd
                    NewRow("Variance") = iVariance
                    dtNewTable.Rows.Add(NewRow)
                    NewRow = Nothing
                    dtNewTable.AcceptChanges()
                Next i
                '***********************
                'Add info for last Half Hour
                'If iPos > 0 Then
                If iTotalShiftHours Mod 1 > 0 Then
                    strHour = "LAST 1/2 HOUR"
                    strHourStart = strHourEnd
                    strHourEnd = strShiftEndTime
                End If
                '***********************
                'Calculate Hourly Target
                iHourlyTarget = 0

                'Calculate Actual Hourly Prod
                iActualHourlyProd = Me.GetHourlyProduction(iLineID, strHourStart, strHourEnd)
                iTotalActualRefurb += iActualHourlyProd

                'Calculate Variance
                iVariance = iActualHourlyProd - iHourlyTarget
                iTotalVariance += iVariance
                '***********************
                'Add new row
                NewRow = dtNewTable.NewRow()
                NewRow("Hour") = strHour
                NewRow("Shift Start Time") = strShiftStartTime
                NewRow("Shift End Time") = strShiftEndTime
                NewRow("Hour Start Time") = strHourStart
                NewRow("Hour End Time") = strHourEnd
                NewRow("Target") = iHourlyTarget
                NewRow("Produced") = iActualHourlyProd
                NewRow("Variance") = iVariance
                dtNewTable.Rows.Add(NewRow)
                NewRow = Nothing
                dtNewTable.AcceptChanges()
                '***********************
                'Add Total row
                NewRow = dtNewTable.NewRow()
                NewRow("Hour") = "TOTAL"
                NewRow("Shift Start Time") = strShiftStartTime
                NewRow("Shift End Time") = strShiftEndTime
                NewRow("Hour Start Time") = strShiftStartTime
                NewRow("Hour End Time") = strShiftEndTime
                NewRow("Target") = iLineTarget
                NewRow("Produced") = iTotalActualRefurb
                NewRow("Variance") = iTotalVariance
                dtNewTable.Rows.Add(NewRow)
                NewRow = Nothing
                dtNewTable.AcceptChanges()

                Return dtNewTable
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        Private Function GetHourlyProduction(ByVal iLineID As Integer, _
                                            ByVal strHourStart As String, _
                                            ByVal strHourEnd As String) _
                                            As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strsql As String = ""

            strsql = "Select Device_ID " & Environment.NewLine
            strsql &= "from tcellopt " & Environment.NewLine
            strsql &= "where " & Environment.NewLine
            strsql &= "tcellopt.CellOpt_RefurbCompleteLineID = " & iLineID & " and " & Environment.NewLine
            'strsql &= "CellOpt_QCReject <> 2 and " & Environment.NewLine        'No QC Failures
            strsql &= "tcellopt.CellOpt_RefurbCompleteDt > '" & strHourStart & "' and " & Environment.NewLine
            strsql &= "tcellopt.CellOpt_RefurbCompleteDt <= '" & strHourEnd & "';"

            Try
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                'R1 = dt1.Rows(0)
                'Return R1("ActualProd")
                Dim i As Integer = 0
                For Each R1 In dt1.Rows
                    If IsRURRTM(R1("Device_ID")) Then
                        'R1.BeginEdit()
                        R1.Delete()
                        'R1.EndEdit()
                        'dt1.AcceptChanges()
                        i += 1
                    End If
                Next R1
                dt1.AcceptChanges()
                Return dt1.Rows.Count
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

        Public Function IsRURRTM(ByVal iDevice_ID As Integer) As Boolean
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "Select tdevicebill.device_id from " & Environment.NewLine
                strsql &= "tdevicebill inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strsql &= "where tdevicebill.device_id = " & iDevice_ID & " and billcode_rule in (1, 9);"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        Public Sub New()
            Me._objMisc = New Production.Misc()
            Me._objSecurity = New Buisness.Security()

        End Sub

        Protected Overrides Sub Finalize()
            Me._objMisc = Nothing
            Me._objSecurity = Nothing
            MyBase.Finalize()
        End Sub
    End Class
End Namespace