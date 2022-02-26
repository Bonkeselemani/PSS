Option Explicit On 

Imports System.Windows.Forms

Namespace buisness

    Public Class MessProdTracking
        Implements IDisposable

        'Const _strHost As String = "172.16.25.21"
        'Const _strDB As String = "production"
        'Const _strUser As String = "apuser"
        'Const _strPWEnc As String = "rqYO+SPdyd1g1JGhUXMm2w=="

        Dim _objDataProc As DBQuery.DataProc

        '***********************************************************************
        Public Sub New()
            Dim strErr As String = ""
            Dim strPWDec As String = ""

            Try
                'strPWDec = EncDec.Rijndael.Decrypt(Me._strPWEnc, strErr)

                'If strErr.Length > 0 Then
                '    MessageBox.Show(strErr & ".  Data processing discontinued.", "Error Decrypting Password", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Else
                '    Me._objDataProc = New DBQuery.DataProc(Me._strHost, Me._strDB, Me._strUser, strPWDec)
                'End If

                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
            End Try
        End Sub

        '***********************************************************************
        Public Sub Dispose() Implements IDisposable.Dispose
            Me._objDataProc = Nothing
        End Sub

        '***********************************************************************
        Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackLevel As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
            Me._objDataProc.DisplayMessage(strMsg, iStackLevel, bIsErrMsg)
        End Sub

        '***********************************************************************
        'Dispose dt
        '***********************************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '***********************************************************************
        Public Function GetFrequencyData() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT freq_number, freq_id " & Environment.NewLine
                strSQL &= "FROM lfrequency " & Environment.NewLine
                strSQL &= "WHERE LEFT(freq_number, 3) <> '000' " & Environment.NewLine
                strSQL &= "ORDER BY freq_number"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*********************************************************************
        Public Function GetExistingMsgWeeklyGoal() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Model_Desc as Model, MsgWlyGoal_SpecialProj as Special, " & Environment.NewLine
                strSQL &= "IF (tmsgweeklygoal.freq_id = 0, '0', freq_Number) as Frequency, " & Environment.NewLine
                strSQL &= "MsgWlyGoal_AWAP as AWAP, " & Environment.NewLine
                strSQL &= "MsgWlyGoal_W1 as 'Week 01', MsgWlyGoal_W2 as 'Week 02', " & Environment.NewLine
                strSQL &= "MsgWlyGoal_W3 as 'Week 03', MsgWlyGoal_W4 as 'Week 04', MsgWlyGoal_W5 as 'Week 05', " & Environment.NewLine
                strSQL &= "MsgWlyGoal_ID, tmsgweeklygoal.Model_ID, tmsgweeklygoal.freq_id, 0 as IsNeedUpdate " & Environment.NewLine
                'strSQL &= "Model_Desc as Model, 0 as Goal, 0 as Receipts, 0 AWAP, 0 'Workable WIP', " & Environment.NewLine
                'strSQL &= "0 Shipped, 0 'Percent of Goal', 0 Variance, 0 'Monthly Percent of Goal' " & Environment.NewLine
                strSQL &= "FROM tmsgweeklygoal " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tmsgweeklygoal.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lfrequency ON tmsgweeklygoal.freq_id = lfrequency.freq_id " & Environment.NewLine
                strSQL &= "WHERE MsgWlyGoal_Inactive = 0;"
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*********************************************************************
        Public Function UpdateMsgWeeklyGoalData(ByVal iModel_ID As Integer, _
                                                ByVal iFreq_ID As Integer, _
                                                ByVal iSpecialProj As Integer, _
                                                ByVal iAWAP As Integer, _
                                                ByVal iWeek01 As Integer, _
                                                ByVal iWeek02 As Integer, _
                                                ByVal iWeek03 As Integer, _
                                                ByVal iWeek04 As Integer, _
                                                ByVal iWeek05 As Integer, _
                                                Optional ByVal iMsgWlyGoal_ID As Integer = 0) As Integer
            Dim strSQL As String
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim strSvr_DT As String
            Dim strStartDtOfMonth As String
            Dim strEndDtOfMonth As String
            Dim strMondayDtOfWeek As String

            Try
                '******************************************
                'Get server date and time in mySql format
                '******************************************
                strSQL = "Select DATE_FORMAT(Now(), '%Y-%m-%d %T') as ServerDateTime;"
                strSvr_DT = Me._objDataProc.GetSingletonString(strSQL).ToString

                '******************************************
                Me.CalStartAndEndDtOfWeek(strSvr_DT, strMondayDtOfWeek, "")
                Me.GetWeekNumOfMonth(strMondayDtOfWeek, strStartDtOfMonth, strEndDtOfMonth)

                '******************************
                'Check for existing of record
                '******************************
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tmsgweeklygoal " & Environment.NewLine
                strSQL &= "WHERE Model_ID = " & iModel_ID & " " & Environment.NewLine
                strSQL &= "AND MsgWlyGoal_SpecialProj = " & iSpecialProj & ";"
                dt1 = Me._objDataProc.GetDataTable(strSQL)

                If dt1.Rows.Count > 1 Then
                    Throw New Exception("Multiple records exist for Model ID " & iModel_ID & ". Please contact IT.")
                ElseIf dt1.Rows.Count = 1 Then
                    If Not IsDBNull(dt1.Rows(0)("MsgWlyGoal_ID")) Then
                        If iMsgWlyGoal_ID = 0 Or iMsgWlyGoal_ID = dt1.Rows(0)("MsgWlyGoal_ID") Then
                            i = Me.UpdateMsgWlyGoal(iModel_ID, iFreq_ID, iAWAP, iWeek01, iWeek02, iWeek03, iWeek04, iWeek05, strStartDtOfMonth, strEndDtOfMonth, strSvr_DT, dt1.Rows(0)("MsgWlyGoal_ID"))
                        ElseIf iMsgWlyGoal_ID <> dt1.Rows(0)("MsgWlyGoal_ID") Then
                            strSQL = "DELETE FROM tmsgweeklygoal WHERE MsgWlyGoal_ID = " & dt1.Rows(0)("MsgWlyGoal_ID") & ";"
                            i = Me._objDataProc.ExecuteNonQuery(strSQL)

                            i = Me.UpdateMsgWlyGoal(iModel_ID, iFreq_ID, iAWAP, iWeek01, iWeek02, iWeek03, iWeek04, iWeek05, strStartDtOfMonth, strEndDtOfMonth, strSvr_DT, iMsgWlyGoal_ID)
                        End If
                    End If
                ElseIf iMsgWlyGoal_ID > 0 Then
                    i = Me.UpdateMsgWlyGoal(iModel_ID, iFreq_ID, iAWAP, iWeek01, iWeek02, iWeek03, iWeek04, iWeek05, strStartDtOfMonth, strEndDtOfMonth, strSvr_DT, iMsgWlyGoal_ID)
                Else
                    i = Me.InsertMsgWlyGoal(iModel_ID, iFreq_ID, iAWAP, iWeek01, iWeek02, iWeek03, iWeek04, iWeek05, strStartDtOfMonth, strEndDtOfMonth, strSvr_DT)
                End If

                Return i
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*********************************************************************
        Public Function UpdateMsgWlyGoal(ByVal iModel_ID As Integer, _
                                         ByVal iFreq_ID As Integer, _
                                         ByVal iAWAP As Integer, _
                                         ByVal iWeek01 As Integer, _
                                         ByVal iWeek02 As Integer, _
                                         ByVal iWeek03 As Integer, _
                                         ByVal iWeek04 As Integer, _
                                         ByVal iWeek05 As Integer, _
                                         ByVal strStartDtOfMonth As String, _
                                         ByVal strEndDtOfMonth As String, _
                                         ByVal strEditDT As String, _
                                         ByVal iMsgWlyGoal_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "UPDATE tmsgweeklygoal " & Environment.NewLine
                strSQL &= "SET Model_ID = " & iModel_ID & Environment.NewLine
                strSQL &= ", freq_id = " & iFreq_ID & Environment.NewLine
                strSQL &= ", MsgWlyGoal_AWAP = " & iAWAP & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W1 = " & iWeek01 & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W2 = " & iWeek02 & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W3 = " & iWeek03 & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W4 = " & iWeek04 & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W5 = " & iWeek05 & Environment.NewLine
                strSQL &= ", MsgWlyGoal_StartDtOfMonth = '" & strStartDtOfMonth & "' " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_EndDtOfMonth = '" & strEndDtOfMonth & "' " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_EditDT = '" & strEditDT & "' " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_Inactive = 0 " & Environment.NewLine
                strSQL &= "WHERE MsgWlyGoal_ID = " & iMsgWlyGoal_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function InsertMsgWlyGoal(ByVal iModel_ID As Integer, _
                                                ByVal iFreq_ID As Integer, _
                                                ByVal iAWAP As Integer, _
                                                ByVal iWeek01 As Integer, _
                                                ByVal iWeek02 As Integer, _
                                                ByVal iWeek03 As Integer, _
                                                ByVal iWeek04 As Integer, _
                                                ByVal iWeek05 As Integer, _
                                                ByVal strStartDtOfMonth As String, _
                                                ByVal strEndDtOfMonth As String, _
                                                ByVal strEditDT As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "INSERT INTO tmsgweeklygoal ( " & Environment.NewLine
                strSQL &= " Model_ID  " & Environment.NewLine
                strSQL &= ", freq_id  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_AWAP " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W1  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W2  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W3  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W4  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_W5  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_StartDtOfMonth " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_EndDtOfMonth  " & Environment.NewLine
                strSQL &= ", MsgWlyGoal_EditDT " & Environment.NewLine
                strSQL &= ") VALUES ( " & Environment.NewLine
                strSQL &= " " & iModel_ID & Environment.NewLine
                strSQL &= ", " & iFreq_ID & Environment.NewLine
                strSQL &= ", " & iAWAP & Environment.NewLine
                strSQL &= ", " & iWeek01 & Environment.NewLine
                strSQL &= ", " & iWeek02 & Environment.NewLine
                strSQL &= ", " & iWeek03 & Environment.NewLine
                strSQL &= ", " & iWeek04 & Environment.NewLine
                strSQL &= ", " & iWeek05 & Environment.NewLine
                strSQL &= ", '" & strStartDtOfMonth & "' " & Environment.NewLine
                strSQL &= ", '" & strEndDtOfMonth & "' " & Environment.NewLine
                strSQL &= ", '" & strEditDT & "' );" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function DeleteMsgWeeklyGoalData(ByVal MsgWlyGoal_ID As Integer) As Integer
            Dim strSQL As String
            Dim i As Integer = 0
            Dim strSvr_DT As String

            Try
                '******************************************
                'Get server date and time in mySql format
                '******************************************
                strSQL = "Select DATE_FORMAT(Now(), '%Y-%m-%d %T') as ServerDateTime;"
                strSvr_DT = Me._objDataProc.GetSingletonString(strSQL).ToString

                strSQL = "UPDATE tmsgweeklygoal " & Environment.NewLine
                strSQL &= "SET MsgWlyGoal_Inactive = 1 " & Environment.NewLine
                strSQL &= "WHERE MsgWlyGoal_ID = " & MsgWlyGoal_ID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*********************************************************************
        Public Function LoadMsgProdTracker_Data(ByRef lblWeekly As Label,
                                                ByRef lblMonthly As Label,
                                                ByRef iTotalWeeksOfMonth As Integer,
                                                ByVal iSpecialProj As Integer) As DataTable
            Const iLoc_ID As Integer = 19
            Dim strSQL As String
            Dim dtData As DataTable
            Dim R1 As DataRow
            Dim iWeekNumOfMonth As Integer
            Dim strStartDayOfWeek As String
            Dim strEndDayOfWeek As String
            Dim strStartDayOfMonth As String
            Dim strEndDayOfMonth As String
            Dim strModel_IDs As String = ""
            Dim strSvr_DT As String

            Try
                '******************************************
                'Get server date and time in mySql format
                '******************************************
                strSQL = "Select DATE_FORMAT(Now(), '%Y-%m-%d %T') as ServerDateTime;"
                strSvr_DT = Me._objDataProc.GetSingletonString(strSQL).ToString

                Me.CalStartAndEndDtOfWeek(strSvr_DT, strStartDayOfWeek, strEndDayOfWeek)

                iWeekNumOfMonth = Me.GetWeekNumOfMonth(strStartDayOfWeek, strStartDayOfMonth, strEndDayOfMonth)
                iTotalWeeksOfMonth = Me.GetTotalWeeksOfMonth(strStartDayOfMonth, strEndDayOfMonth)
                lblWeekly.Text = "Week " & iWeekNumOfMonth & " of " & iTotalWeeksOfMonth & " : " & Format(CDate(strStartDayOfWeek), "MM/dd/yyyy") & " - " & Format(CDate(strEndDayOfWeek), "MM/dd/yyyy")
                lblMonthly.Text = "Month Range: " & Format(CDate(strStartDayOfMonth), "MM/dd/yyyy") & " - " & Format(CDate(strEndDayOfMonth), "MM/dd/yyyy")
                '******************************************
                'Get weekly goal data
                '******************************************
                strSQL = "SELECT Model_Desc as Model, 0 as Goal, 0 as Receipts, MsgWlyGoal_AWAP as AWAP, 0 as 'Workable WIP', " & Environment.NewLine
                strSQL &= "0 as Shipped, '0' as '% of Goal', 0 as  Variance, '0' as 'Monthly % of Goal', " & Environment.NewLine
                strSQL &= "MsgWlyGoal_W1, MsgWlyGoal_W2, " & Environment.NewLine
                strSQL &= "MsgWlyGoal_W3, MsgWlyGoal_W4, MsgWlyGoal_W5, " & Environment.NewLine
                strSQL &= "tmsgweeklygoal.Model_ID, freq_id, 0 as MonthlyShip " & Environment.NewLine
                strSQL &= "FROM tmsgweeklygoal " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON  tmsgweeklygoal.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSQL &= "WHERE MsgWlyGoal_Inactive = 0 " & Environment.NewLine
                strSQL &= "AND MsgWlyGoal_SpecialProj = " & iSpecialProj & Environment.NewLine
                strSQL &= "ORDER BY Model_ID;"

                dtData = Me._objDataProc.GetDataTable(strSQL)
                If dtData.Rows.Count > 0 Then
                    For Each R1 In dtData.Rows
                        If strModel_IDs = "" Then
                            strModel_IDs = R1("Model_ID")
                        Else
                            strModel_IDs &= "," & R1("Model_ID")
                        End If
                    Next R1

                    If iSpecialProj = 0 Then
                        Me.LoadMsgProdTracker_Data_Prod(dtData, iLoc_ID, strModel_IDs, iWeekNumOfMonth, iTotalWeeksOfMonth, strStartDayOfWeek, strEndDayOfWeek, strStartDayOfMonth, strEndDayOfMonth)
                    Else
                        Me.LoadMsgProdTracker_Data_Special(dtData, iLoc_ID, strModel_IDs, iWeekNumOfMonth, iTotalWeeksOfMonth, strStartDayOfWeek, strEndDayOfWeek, strStartDayOfMonth, strEndDayOfMonth)
                    End If
                End If

                Return dtData
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************************
        Public Function LoadMsgProdTracker_Data_Prod(ByRef dtData As DataTable, _
                                                     ByVal iLoc_ID As Integer, _
                                                     ByVal strModel_IDs As String, _
                                                     ByVal iWeekNumOfMonth As Integer, _
                                                     ByVal iTotalWeekOfMonth As Integer, _
                                                     ByVal strStartDayOfWeek As String, _
                                                     ByVal strEndDayOfWeek As String, _
                                                     ByVal strStartDayOfMonth As String, _
                                                     ByVal strEndDayOfMonth As String) As DataTable
            Dim strSQL As String
            Dim dtRec, dtShip, dtWip, dtMonthlyShip As DataTable
            Dim R1, R2 As DataRow

            Try
                '*************************************
                'Get Receipts
                '*************************************
                strSQL = "SELECT Model_ID, count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 0 " & Environment.NewLine
                strSQL &= "AND Device_RecWorkDate >= '" & strStartDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Device_RecWorkDate <= '" & strEndDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Model_ID IN ( " & strModel_IDs & " ) " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID;"
                dtRec = Me._objDataProc.GetDataTable(strSQL)

                '*************************************
                'Get current Wip
                '*************************************
                strSQL = "SELECT Model_ID, count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 0 " & Environment.NewLine
                strSQL &= "AND Device_DateShip is null " & Environment.NewLine
                strSQL &= "AND Model_ID IN (" & strModel_IDs & " ) " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID;"
                dtWip = Me._objDataProc.GetDataTable(strSQL)

                '*************************************
                'Get Ship
                '*************************************
                strSQL = "SELECT Model_ID, count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 0 " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate >= '" & strStartDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate <= '" & strEndDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                strSQL &= "AND Model_ID IN ( " & strModel_IDs & " ) " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID;"
                dtShip = Me._objDataProc.GetDataTable(strSQL)

                '*************************************
                'Get Monthly Ship 
                '*************************************
                strSQL = "SELECT Model_ID, count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 0 " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate >= '" & strStartDayOfMonth & "' " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate <= '" & strEndDayOfMonth & "' " & Environment.NewLine
                strSQL &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                strSQL &= "AND Model_ID IN ( " & strModel_IDs & ") " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID;"
                dtMonthlyShip = Me._objDataProc.GetDataTable(strSQL)

                '*************************************

                For Each R1 In dtData.Rows
                    R1.BeginEdit()

                    '*************************************
                    'Get Receipts
                    '*************************************
                    For Each R2 In dtRec.Rows
                        If R1("Model_ID") = R2("Model_ID") Then
                            R1("Receipts") = R2("cnt")
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing

                    '*************************************
                    'Get Shipped
                    '*************************************
                    For Each R2 In dtShip.Rows
                        If R1("Model_ID") = R2("Model_ID") Then
                            R1("Shipped") = R2("cnt")
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing

                    '*************************************
                    'Get current Wip
                    '*************************************
                    For Each R2 In dtWip.Rows
                        If R1("Model_ID") = R2("Model_ID") Then
                            R1("Workable WIP") = R2("cnt") - R1("AWAP")
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing

                    '*************************************
                    'Get Weekly Goal
                    '*************************************
                    Select Case iWeekNumOfMonth
                        Case 1
                            R1("Goal") = R1("MsgWlyGoal_W1")
                        Case 2
                            R1("Goal") = R1("MsgWlyGoal_W2")
                        Case 3
                            R1("Goal") = R1("MsgWlyGoal_W3")
                        Case 4
                            R1("Goal") = R1("MsgWlyGoal_W4")
                        Case 5
                            R1("Goal") = R1("MsgWlyGoal_W5")
                    End Select

                    If R1("Goal") <> 0 Then
                        R1("% of Goal") = Format((R1("Shipped") / R1("Goal")), "##0.000")
                    End If

                    '*************************************
                    'Varian
                    '*************************************
                    R1("Variance") = R1("Shipped") - R1("Goal")

                    '*************************************
                    'Get Monthly Goal
                    '*************************************
                    For Each R2 In dtMonthlyShip.Rows
                        If R1("Model_ID") = R2("Model_ID") Then
                            If R1("Goal") <> 0 Then
                                R1("Monthly % of Goal") = Format((R2("cnt") / (R1("Goal") * iTotalWeekOfMonth)), "##0.000")
                                R1("MonthlyShip") = R2("cnt")
                            End If
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing
                    '*************************************

                    R1.EndEdit()
                Next R1

                dtData.AcceptChanges()

                dtData.Columns.Remove("Model_ID")
                dtData.Columns.Remove("freq_id")
                dtData.Columns.Remove("MsgWlyGoal_W1")
                dtData.Columns.Remove("MsgWlyGoal_W2")
                dtData.Columns.Remove("MsgWlyGoal_W3")
                dtData.Columns.Remove("MsgWlyGoal_W4")
                dtData.Columns.Remove("MsgWlyGoal_W5")

                dtData.AcceptChanges()

                Return dtData
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            Finally
                R1 = Nothing
                R2 = Nothing
                Me.DisposeDT(dtRec)
                Me.DisposeDT(dtWip)
                Me.DisposeDT(dtShip)
                Me.DisposeDT(dtMonthlyShip)
            End Try
        End Function

        '*********************************************************************
        Public Function LoadMsgProdTracker_Data_Special(ByRef dtData As DataTable, _
                                                     ByVal iLoc_ID As Integer, _
                                                     ByVal strModel_IDs As String, _
                                                     ByVal iWeekNumOfMonth As Integer, _
                                                     ByVal iTotalWeekOfMonth As Integer, _
                                                     ByVal strStartDayOfWeek As String, _
                                                     ByVal strEndDayOfWeek As String, _
                                                     ByVal strStartDayOfMonth As String, _
                                                     ByVal strEndDayOfMonth As String) As DataTable
            Dim strSQL As String
            Dim dtRec, dtShip, dtWip, dtMonthlyShip As DataTable
            Dim R1, R2 As DataRow
            Dim dtFreq As DataTable


            Try
                '*************************************
                'Get Frequency
                '*************************************
                dtFreq = Me.GetFrequencyData()

                '*************************************
                'Get Receipts
                '*************************************
                strSQL = "SELECT Model_ID, tmessdata.freq_id, count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata on tdevice.device_ID = tmessdata.device_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 1 " & Environment.NewLine
                strSQL &= "AND Device_RecWorkDate >= '" & strStartDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Device_RecWorkDate <= '" & strEndDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Model_ID IN ( " & strModel_IDs & " ) " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID, tmessdata.freq_id " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID, tmessdata.freq_id; "
                dtRec = Me._objDataProc.GetDataTable(strSQL)

                '*************************************
                'Get current Wip
                '*************************************
                strSQL = "SELECT Model_ID, tmessdata.freq_id, count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata on tdevice.device_ID = tmessdata.device_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 1 " & Environment.NewLine
                strSQL &= "AND Device_DateShip is null " & Environment.NewLine
                strSQL &= "AND Model_ID IN (" & strModel_IDs & " ) " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID, tmessdata.freq_id " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID, tmessdata.freq_id; "
                dtWip = Me._objDataProc.GetDataTable(strSQL)

                '*************************************
                'Get Ship
                '*************************************
                strSQL = "SELECT Model_ID, tmessdata.freq_id,  count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata on tdevice.device_ID = tmessdata.device_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 1 " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate >= '" & strStartDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate <= '" & strEndDayOfWeek & "' " & Environment.NewLine
                strSQL &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                strSQL &= "AND Model_ID IN ( " & strModel_IDs & " ) " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID, tmessdata.freq_id " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID, tmessdata.freq_id; "
                dtShip = Me._objDataProc.GetDataTable(strSQL)

                '*************************************
                'Get Monthly Goal
                '*************************************
                strSQL = "SELECT Model_ID, tmessdata.freq_id,  count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata on tdevice.device_ID = tmessdata.device_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSQL &= "AND WO_SpecialProj = 1 " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate >= '" & strStartDayOfMonth & "' " & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate <= '" & strEndDayOfMonth & "' " & Environment.NewLine
                strSQL &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                strSQL &= "AND Model_ID IN ( " & strModel_IDs & ") " & Environment.NewLine
                strSQL &= "GROUP BY Model_ID, tmessdata.freq_id " & Environment.NewLine
                strSQL &= "ORDER BY Model_ID, tmessdata.freq_id; "
                dtMonthlyShip = Me._objDataProc.GetDataTable(strSQL)

                '*************************************

                For Each R1 In dtData.Rows
                    R1.BeginEdit()

                    '*************************************
                    'Model
                    '*************************************
                    If dtFreq.Select("freq_id = " & R1("freq_id")).Length > 0 Then
                        R1("Model") = R1("Model") & " - " & dtFreq.Select("freq_id = " & R1("freq_id"))(0)("freq_Number")
                    End If

                    '*************************************
                    'Get Receipts
                    '*************************************
                    For Each R2 In dtRec.Rows
                        If R1("Model_ID") = R2("Model_ID") And R1("freq_id") = R2("Freq_id") Then
                            R1("Receipts") = R2("cnt")
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing

                    '*************************************
                    'Get Shipped
                    '*************************************
                    For Each R2 In dtShip.Rows
                        If R1("Model_ID") = R2("Model_ID") And R1("freq_id") = R2("Freq_id") Then
                            R1("Shipped") = R2("cnt")
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing

                    '*************************************
                    'Get current Wip
                    '*************************************
                    For Each R2 In dtWip.Rows
                        If R1("Model_ID") = R2("Model_ID") And R1("freq_id") = R2("Freq_id") Then
                            R1("Workable WIP") = R2("cnt") - R1("AWAP")
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing

                    '*************************************
                    'Get Weekly Goal
                    '*************************************
                    Select Case iWeekNumOfMonth
                        Case 1
                            R1("Goal") = R1("MsgWlyGoal_W1")
                        Case 2
                            R1("Goal") = R1("MsgWlyGoal_W2")
                        Case 3
                            R1("Goal") = R1("MsgWlyGoal_W3")
                        Case 4
                            R1("Goal") = R1("MsgWlyGoal_W4")
                        Case 5
                            R1("Goal") = R1("MsgWlyGoal_W5")
                    End Select

                    If R1("Goal") <> 0 Then
                        R1("% of Goal") = Format((R1("Shipped") / R1("Goal")), "##0.000")
                    End If

                    '*************************************
                    'Varian
                    '*************************************
                    R1("Variance") = R1("Shipped") - R1("Goal")

                    '*************************************
                    'Get Monthly Goal
                    '*************************************
                    For Each R2 In dtMonthlyShip.Rows
                        If R1("Model_ID") = R2("Model_ID") Then
                            If R1("Goal") <> 0 Then
                                R1("Monthly % of Goal") = Format((R2("cnt") / (R1("Goal") * iTotalWeekOfMonth)), "##0.000")
                                R1("MonthlyShip") = R2("cnt")
                            End If
                            Exit For
                        End If
                    Next R2
                    R2 = Nothing
                    '*************************************

                    R1.EndEdit()
                Next R1

                dtData.AcceptChanges()

                dtData.Columns.Remove("Model_ID")
                dtData.Columns.Remove("freq_id")
                dtData.Columns.Remove("MsgWlyGoal_W1")
                dtData.Columns.Remove("MsgWlyGoal_W2")
                dtData.Columns.Remove("MsgWlyGoal_W3")
                dtData.Columns.Remove("MsgWlyGoal_W4")
                dtData.Columns.Remove("MsgWlyGoal_W5")

                dtData.AcceptChanges()

                Return dtData
            Catch ex As Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            Finally
                R1 = Nothing
                R2 = Nothing
                Me.DisposeDT(dtRec)
                Me.DisposeDT(dtWip)
                Me.DisposeDT(dtShip)
                Me.DisposeDT(dtMonthlyShip)
                Me.DisposeDT(dtFreq)
            End Try
        End Function

        '*********************************************************************
        Public Sub CalStartAndEndDtOfWeek(ByVal strToday As String, _
                                          ByRef strStartDayOfWeek As String, _
                                          ByRef strEndDayOfWeek As String)
            Dim iWeekDay As Integer

            Try
                iWeekDay = Weekday(CDate(strToday), FirstDayOfWeek.Monday)
                If iWeekDay = 1 Then
                    strStartDayOfWeek = Format(CDate(strToday), "yyyy-MM-dd")
                Else
                    strStartDayOfWeek = Format(DateAdd(DateInterval.Day, ((iWeekDay - 1) * -1), CDate(strToday)), "yyyy-MM-dd")
                End If

                strEndDayOfWeek = Format(DateAdd(DateInterval.Day, 6, CDate(strStartDayOfWeek)), "yyyy-MM-dd")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************
        Public Function GetWeekNumOfMonth(ByVal strStartDtOfWeek As String, _
                                       ByRef strStartDtOfMonth As String, _
                                       ByRef strEndDtOfMonth As String) As Integer

            Dim strSql As String
            Dim iWeekNumOfMonth As Integer = 0
            Dim dt1 As DataTable
            Dim booLoopVar As Boolean = True
            Dim booReCalStartAndEndDtOfMonth As Boolean = False
            Dim strStartDate As Date

            Try
                dt1 = Me.GetStartAndEndDateOfMonth()

                If dt1.Rows.Count = 1 Then
                    strStartDtOfMonth = Format(CDate(dt1.Rows(0)("MsgWlyGoal_StartDtOfMonth")), "yyyy-MM-dd")
                    strEndDtOfMonth = Format(CDate(dt1.Rows(0)("MsgWlyGoal_EndDtOfMonth")), "yyyy-MM-dd")
                    strStartDate = CDate(strStartDtOfMonth)

                    'Check if Start Date Of Week in range of the month 
                    If CDate(strStartDtOfWeek) >= CDate(strStartDtOfMonth) And CDate(strStartDtOfWeek) <= CDate(strEndDtOfMonth) Then
                        While booLoopVar
                            If strStartDate = CDate(strStartDtOfWeek) Then
                                iWeekNumOfMonth += 1
                                Exit While
                            Else
                                strStartDate = DateAdd(DateInterval.Day, 7, strStartDate)
                                iWeekNumOfMonth += 1
                            End If

                            If iWeekNumOfMonth = 10 Then
                                Throw New Exception("Could not define week number.")
                            End If
                        End While
                    Else
                        booReCalStartAndEndDtOfMonth = True
                    End If
                Else
                    booReCalStartAndEndDtOfMonth = True
                End If

                If booReCalStartAndEndDtOfMonth = True Then
                    Me.CalStartAndEndDtOfMonth(strStartDtOfWeek, strStartDtOfMonth, strEndDtOfMonth, True)
                    While booLoopVar
                        If strStartDate = CDate(strStartDtOfWeek) Then
                            iWeekNumOfMonth += 1
                            Exit While
                        Else
                            strStartDate = DateAdd(DateInterval.Day, 7, strStartDate)
                            iWeekNumOfMonth += 1
                        End If

                        If iWeekNumOfMonth = 10 Then
                            Throw New Exception("Could not define week number.")
                        End If
                    End While
                End If

                Return iWeekNumOfMonth
            Catch ex As System.Exception
                Me._objDataProc.DisplayMessage(ex.Message)
                GetWeekNumOfMonth = 0
            Finally
                Me.DisposeDT(dt1)
            End Try
        End Function

        '*********************************************************************
        Public Function GetStartAndEndDateOfMonth() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT DISTINCT MsgWlyGoal_StartDtOfMonth, MsgWlyGoal_EndDtOfMonth " & Environment.NewLine
                strSql &= "FROM tmsgweeklygoal " & Environment.NewLine
                strSql &= "WHERE MsgWlyGoal_Inactive = 0" & ";"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As System.Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*********************************************************************
        Public Sub CalStartAndEndDtOfMonth(ByVal strMondayDtOfWeek As String, _
                                           ByRef strStartDtOfMonth As String, _
                                           ByRef strEndDtOfMonth As String, _
                                           Optional ByVal booUpdateSystem As Boolean = False)
            Dim iCurrentMonth As Integer
            Dim iCalMonth As Integer
            Dim dteCalFriday As Date

            Try
                strStartDtOfMonth = ""
                strEndDtOfMonth = ""

                dteCalFriday = DateAdd(DateInterval.Day, 4, CDate(strMondayDtOfWeek))
                iCurrentMonth = Month(dteCalFriday)

                'Find Start Date of Month
                While strStartDtOfMonth = ""
                    dteCalFriday = DateAdd(DateInterval.Day, -7, dteCalFriday)
                    iCalMonth = Month(dteCalFriday)
                    If iCurrentMonth <> iCalMonth Then
                        strStartDtOfMonth = Format(DateAdd(DateInterval.Day, 3, dteCalFriday), "yyyy-MM-dd")
                    End If
                End While

                'Find End Date of Month
                dteCalFriday = DateAdd(DateInterval.Day, 4, CDate(strMondayDtOfWeek))
                While strEndDtOfMonth = ""
                    dteCalFriday = DateAdd(DateInterval.Day, 7, dteCalFriday)
                    iCalMonth = Month(dteCalFriday)
                    If iCurrentMonth <> iCalMonth Then
                        strEndDtOfMonth = Format(DateAdd(DateInterval.Day, -5, dteCalFriday), "yyyy-MM-dd")
                    End If
                End While

                If booUpdateSystem = True And strStartDtOfMonth <> "" And strEndDtOfMonth <> "" Then
                    Me.UpdateStartAndEndDateOfMonth(strStartDtOfMonth, strEndDtOfMonth)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************
        Public Function UpdateStartAndEndDateOfMonth(ByVal strStartDtOfMonth As String, _
                                                     ByVal strEndDtOfMonth As String) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tmsgweeklygoal " & Environment.NewLine
                strSql &= "SET MsgWlyGoal_StartDtOfMonth = '" & strStartDtOfMonth & "' " & Environment.NewLine
                strSql &= ", MsgWlyGoal_EndDtOfMonth = '" & strEndDtOfMonth & "'; " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As System.Exception
                Me._objDataProc.DisplayMessage(ex.Message)
            End Try
        End Function

        '*********************************************************************
        Public Function GetTotalWeeksOfMonth(ByVal strStartDtOfMonth As Date, _
                                            ByVal strEndDtOfMonth As Date) As Integer
            Dim iTotalWeek As Integer = 0

            Try
                While strStartDtOfMonth < strEndDtOfMonth
                    strStartDtOfMonth = DateAdd(DateInterval.Day, 7, strStartDtOfMonth)
                    iTotalWeek += 1
                End While

                Return iTotalWeek
            Catch ex As System.Exception
                Me._objDataProc.DisplayMessage(ex.Message)
                GetTotalWeeksOfMonth = 0
            End Try
        End Function

        '*********************************************************************
        Public Sub CreateMsgProdTrackerExelReport(ByVal dtProd As DataTable, _
                                                  ByVal dtSpecial As DataTable, _
                                                  ByVal iTotalWeeksOfMonth As Integer)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1 As DataRow
            Dim iRow As Integer = 0
            Dim iCol As Integer = 0
            Dim arrData(,) As Object
            Dim dc As DataColumn
            Dim i As Integer = 0

            Try
                '**************************************************
                'Header
                '**************************************************
                If Not IsNothing(dtProd) And Not IsNothing(dtSpecial) Then
                    ReDim arrData(dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 3, dtProd.Columns.Count)
                ElseIf Not IsNothing(dtProd) Then
                    ReDim arrData(dtProd.Rows.Count + 2, dtProd.Columns.Count)
                ElseIf Not IsNothing(dtProd) Then
                    ReDim arrData(dtSpecial.Rows.Count + 3, dtProd.Columns.Count)
                End If

                For Each dc In dtProd.Columns
                    If dc.Caption <> "MonthlyShip" Then
                        'Production header
                        arrData(iRow, iCol) = dc.Caption

                        'special project header
                        If Not IsNothing(dtSpecial) Then
                            If dtSpecial.Rows.Count > 0 Then
                                arrData(dtProd.Rows.Count + 2 + 3 - 1, iCol) = dc.Caption
                            End If
                        End If

                        iCol += 1
                    End If
                Next dc

                iRow += 1
                iCol = 0

                '**************************************************
                'Production plan data
                '**************************************************
                For Each R1 In dtProd.Rows
                    For Each dc In dtProd.Columns
                        If dc.Caption <> "MonthlyShip" Then
                            If dc.Caption <> "Model" And dc.Caption <> "Workable WIP" And dc.Caption <> "% of Goal" Or dc.Caption = "Variance" Then
                                arrData(iRow, iCol) = CDbl(R1(iCol))
                            ElseIf dc.Caption = "Model" Then
                                arrData(iRow, iCol) = R1(iCol).ToString
                            End If
                        End If
                        iCol += 1
                    Next dc

                    iCol = 0
                    iRow += 1
                Next R1

                iRow += 1   'Skip a blank line

                '**************************************************
                'Special Project data
                '**************************************************
                iRow += 1   'Special Project

                If Not IsNothing(dtSpecial) Then
                    If dtSpecial.Rows.Count > 0 Then
                        arrData(iRow, iCol) = "Special Project"
                        iRow += 2   'Header of 

                        For Each R1 In dtSpecial.Rows
                            For Each dc In dtSpecial.Columns
                                If dc.Caption <> "MonthlyShip" Then
                                    If dc.Caption <> "Model" And dc.Caption <> "Workable WIP" And dc.Caption <> "% of Goal" Or dc.Caption = "Variance" Then
                                        arrData(iRow, iCol) = CDbl(R1(iCol))
                                    ElseIf dc.Caption = "Model" Then
                                        arrData(iRow, iCol) = R1(iCol).ToString
                                    End If
                                End If
                                iCol += 1
                            Next dc

                            iCol = 0
                            iRow += 1
                        Next R1
                    End If
                End If

                '**************************************************
                'Instantiate the excel related objects
                '**************************************************
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True                 'Make excel invisible to user

                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                '*******************************
                'Write header and data to excel 
                '*******************************
                With objSheet
                    .Range("A1:" & Chr(65 + dtProd.Columns.Count - 1) & (iRow).ToString).Value = arrData
                End With

                '*****************************************
                'format header
                '*****************************************
                Me.FormatExcel(objExcel, objSheet, "A1", Chr(65 + dtProd.Columns.Count - 1 - 1) & 1.ToString, True, True, False, "@", "", 12, 5, 37, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
                If Not IsNothing(dtSpecial) Then
                    If dtSpecial.Rows.Count > 0 Then
                        Me.FormatExcel(objExcel, objSheet, "A" & dtProd.Rows.Count + 2 + 3, Chr(65 + dtProd.Columns.Count - 1 - 1) & (dtProd.Rows.Count + 2 + 3).ToString, True, True, False, "@", "", 12, 3, 37, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
                    End If
                End If

                '*****************************************
                'PRODUCTION PLAN
                'format Data, write grand total, write formula
                '*****************************************
                R1 = Nothing
                dc = Nothing
                iCol = 1

                For Each dc In dtProd.Columns
                    If dc.Caption <> "MonthlyShip" Then
                        If dc.Caption = "Model" Then
                            'write Total
                            objExcel.Application.Cells(dtProd.Rows.Count + 2, iCol).Value = "Total"

                            'format
                            Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & "2", Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2).ToString, True, False, False, "@", "", 11, , , , )

                        ElseIf dc.Caption = "% of Goal" Or dc.Caption = "Monthly % of Goal" Then
                            If dc.Caption = "% of Goal" Then
                                For i = 0 To dtProd.Rows.Count - 1
                                    R1 = dtProd.Rows(i)
                                    'write formula
                                    If R1("Goal") = 0 Then
                                        objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = "N/A"
                                    Else
                                        objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = "=RC[-1]/RC[-5]"
                                    End If
                                    R1 = Nothing
                                Next i
                            End If

                            'write Total value
                            If dtProd.Compute("Sum(Goal)", "") = 0 Then
                                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = 0
                            ElseIf dc.Caption = "% of Goal" Then
                                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=(RC[-1]/RC[-5])"
                            Else
                                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=" & dtProd.Compute("Sum(MonthlyShip)", "") & "/(RC[-7] * " & iTotalWeeksOfMonth & ")"
                            End If

                            'format
                            Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & "2", Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2).ToString, True, False, False, "#,##0.000%", "", 11, , , , )
                        Else
                            If dc.Caption = "Workable WIP" Then
                                For i = 0 To dtProd.Rows.Count - 1
                                    R1 = dtProd.Rows(i)
                                    'write formula
                                    objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = R1("Workable WIP") '"=" & R1("Workable WIP") & "-RC[-1]"
                                    R1 = Nothing
                                Next i
                            ElseIf dc.Caption = "Variance" Then
                                For i = 0 To dtProd.Rows.Count - 1
                                    R1 = dtProd.Rows(i)
                                    'write formula
                                    objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = "=RC[-2]-RC[-6]"
                                    R1 = Nothing
                                Next i
                            End If

                            'write Total value
                            If dtProd.Rows.Count = 1 Then
                                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = dtProd.Rows(0)(dc.Caption)
                            Else
                                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=SUM(R[" & (-1 * dtProd.Rows.Count).ToString & "]C:R[-1]C)"
                            End If

                            'format
                            Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & "2", Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2).ToString, True, False, False, "", "", 11, , , , )
                        End If
                    End If

                    iCol += 1
                Next dc

                'Format grand total
                Me.FormatExcel(objExcel, objSheet, "A" & (dtProd.Rows.Count + 2), Chr(65 + dtProd.Columns.Count - 1) & (dtProd.Rows.Count + 2).ToString, False, True, False, "", "", 12, 11, , , )

                '*****************************************
                'SPECIAL PROJECT
                'format Data, write grand total, write formula
                '*****************************************
                R1 = Nothing
                dc = Nothing
                iCol = 1

                If Not IsNothing(dtSpecial) Then
                    If dtSpecial.Rows.Count > 0 Then
                        'Format 'Special Project' cell
                        Me.FormatExcel(objExcel, objSheet, "A" & (dtProd.Rows.Count + 2 + 2).ToString, "A" & (dtProd.Rows.Count + 2 + 2).ToString, False, True, False, "@", "", 12, 3, , , )

                        For Each dc In dtSpecial.Columns
                            If dc.Caption <> "MonthlyShip" Then
                                If dc.Caption = "Model" Then
                                    'write Total
                                    objExcel.Application.Cells(dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4, iCol).Value = "Total"

                                    'format
                                    Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + 3).ToString, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString, True, False, False, "@", "", 11, , , , )

                                ElseIf dc.Caption = "% of Goal" Or dc.Caption = "Monthly % of Goal" Then
                                    If dc.Caption = "% of Goal" Then
                                        For i = 0 To dtSpecial.Rows.Count - 1
                                            R1 = dtSpecial.Rows(i)
                                            'write formula
                                            If R1("Goal") = 0 Then
                                                objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "N/A"
                                            Else
                                                objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=RC[-1]/RC[-5]"
                                            End If

                                            R1 = Nothing
                                        Next i
                                    End If

                                    'write Total value
                                    If dtSpecial.Compute("Sum(Goal)", "") = 0 Then
                                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = 0
                                    ElseIf dc.Caption = "% of Goal" Then
                                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = "=(RC[-1]/RC[-5])"
                                    Else
                                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = "=" & dtSpecial.Compute("Sum(MonthlyShip)", "") & "/(RC[-7] * " & iTotalWeeksOfMonth & ")"
                                    End If

                                    'format
                                    Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + 3).ToString, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString, True, False, False, "#,##0.000%", "", 11, , , , )
                                Else
                                    If dc.Caption = "Workable WIP" Then
                                        For i = 0 To dtSpecial.Rows.Count - 1
                                            R1 = dtSpecial.Rows(i)

                                            'write formula
                                            objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = R1("Workable WIP") '"=" & R1("Workable WIP") & "-RC[-1]"
                                            R1 = Nothing
                                        Next i
                                    ElseIf dc.Caption = "Variance" Then
                                        For i = 0 To dtSpecial.Rows.Count - 1
                                            R1 = dtSpecial.Rows(i)
                                            'write formula
                                            objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=RC[-2]-RC[-6]"
                                            R1 = Nothing
                                        Next i
                                    End If

                                    'write Total value
                                    If dtSpecial.Rows.Count = 1 Then
                                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = dtSpecial.Rows(0)(dc.Caption)
                                    Else
                                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = "=SUM(R[" & (-1 * (dtSpecial.Rows.Count)).ToString & "]C:R[-1]C)"
                                    End If

                                    'format
                                    Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + 3).ToString, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString, True, False, False, "", "", 11, , , , )
                                End If
                            End If

                            iCol += 1
                        Next dc

                        'Format grand total
                        Me.FormatExcel(objExcel, objSheet, "A" & (iRow + 1), Chr(65 + dtProd.Columns.Count - 1) & (iRow + 1).ToString, False, True, False, "", "", 12, 11, , , )
                    End If
                End If

                '************************************************
                'set all cell to be auto-fit 
                objSheet.Cells.Select()
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()
                ''*************************************************

                '***********************
                'Print Report
                '***********************
                ' objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                dc = Nothing
                arrData = Nothing
                System.Windows.Forms.Application.DoEvents()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*********************************************************************
        Public Sub FormatExcel(ByRef objExcel As Object, _
                                  ByRef objSheet As Object, _
                                  ByVal strStartCell As String, _
                                  ByVal strEndCell As String, _
                                  Optional ByVal booSetBorder As Boolean = False, _
                                  Optional ByVal booBold As Boolean = False, _
                                  Optional ByVal booWrapText As Boolean = False, _
                                  Optional ByVal strNumberFormat As String = "", _
                                  Optional ByVal strFontName As String = "", _
                                  Optional ByVal iFontSize As Integer = 0, _
                                  Optional ByVal iFontColor As Integer = 0, _
                                  Optional ByVal iFillColor As Integer = 0, _
                                  Optional ByVal iHorizontalAlignment As Integer = 0, _
                                  Optional ByVal iVerticalAlignment As Integer = 0)
            Dim strStartCellLetter As String = ""
            Dim strStartCellNumber As String = ""
            Dim strEndCellLetter As String = ""
            Dim strEndCellNumber As String = ""
            Dim i As Integer = 0

            Try

                If strStartCell <> "" And strEndCell <> "" Then
                    objSheet.Range(strStartCell & ":" & strEndCell).Select()

                    With objExcel.Selection
                        If booBold = True Then
                            .font.bold = booBold
                        End If
                        If booWrapText = True Then
                            .WrapText = booWrapText
                        End If
                        If strNumberFormat <> "" Then
                            .NumberFormat = strNumberFormat
                        End If

                        'Set Font
                        If strFontName <> "" Then
                            .Font.Name = strFontName
                        End If
                        If iFontSize > 0 Then
                            .Font.Size = iFontSize
                        End If
                        If iFontColor <> 0 Then
                            .Font.ColorIndex = iFontColor
                        End If
                        If iFillColor <> 0 Then
                            .Interior.ColorIndex = iFillColor
                        End If

                        'set alignment
                        If iHorizontalAlignment <> 0 And iVerticalAlignment <> 0 Then
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                        End If
                    End With

                    '**************************
                    'Set the borders 
                    '**************************
                    If booSetBorder = True Then
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

                        If strStartCell.Trim.ToUpper <> strEndCell.Trim.ToUpper Then

                            '************************
                            i = strStartCell.Length
                            While i > 0
                                If IsNumeric(Mid(strStartCell.Trim, i, 1)) Then
                                    strStartCellNumber = Mid(strStartCell.Trim, i, 1) & strStartCellNumber
                                Else
                                    strStartCellLetter = Mid(strStartCell.Trim, 1, i)
                                    Exit While
                                End If
                                i -= 1
                            End While

                            i = strEndCell.Length
                            While i > 0
                                If IsNumeric(Mid(strEndCell.Trim, i, 1)) Then
                                    strEndCellNumber = Mid(strEndCell.Trim, i, 1) & strEndCellNumber
                                Else
                                    strEndCellLetter = Mid(strEndCell.Trim, 1, i)
                                    Exit While
                                End If
                                i -= 1
                            End While
                            '************************

                            If strStartCellLetter.Trim.ToUpper <> strEndCellLetter.Trim.ToUpper Then
                                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlThin
                                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                                End With
                            End If

                            If strStartCellNumber.Trim.ToUpper <> strEndCellNumber.Trim.ToUpper Then
                                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlThin
                                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                                End With
                            End If

                        End If 'One cell
                    End If  'Set border
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************
        Private Shared Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '*********************************************************************

    End Class
End Namespace

