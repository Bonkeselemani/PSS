Namespace Buisness
    Public Class WorkDate
        Private objMisc As Production.Misc

        '***************************************************
        'Get the Parent Group ID for the machine being logged on
        '***************************************************
        Public Function GetParentGroupForMachine() As DataTable
            Dim strSql As String = ""

            Try
                'objMisc._SQL = "Select tgrouplinemap.Group_ID, tgrouplinemap.Line_ID from lwclocation, tgrouplinemap where tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID and WC_ActiveFlag = 1 and wc_machine = '" & Trim(System.Net.Dns.GetHostName) & "';"
                strSql = "Select lgroups.Group_Desc, tgrouplinemap.Group_ID, tgrouplinemap.Line_ID " & Environment.NewLine
                strSql &= "from lwclocation, tgrouplinemap " & Environment.NewLine
                strSql &= "inner join lgroups on tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strSql &= "where tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID and WC_ActiveFlag = 1 and wc_machine = '" & Trim(System.Net.Dns.GetHostName) & "';"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("GetParentGroupForMachine: " & ex.ToString)
            End Try

        End Function

        '***************************************************
        'Determine the Workdate based on Shift_ID and 
        'Current date time.
        '***************************************************
        Public Function WorkDate(ByVal iShiftID As Integer, _
                                 ByVal dttDateTime As DateTime) As String
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim iShiftFlag As Integer = 0
            Dim strWorkDate As String = ""
            Dim myArray() As String
            Dim myArray1() As String

            Try
                '*****************************
                'Step 1: Get the Shift Number
                '*****************************
                objMisc._SQL = "Select * from tshift where shift_id = " & iShiftID & ";"
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iShiftFlag = R1("Shift_Flag")
                    myArray = Split(Trim(R1("Shift_StartTime")), ":", 3, CompareMethod.Text)
                    myArray1 = Split(Trim(R1("Shift_EndTime")), ":", 3, CompareMethod.Text)
                Else
                    Throw New Exception("Shift does not exist.")
                End If
                '*****************************
                'Step 2: Determine the Work Date for the shift.
                '*****************************
                Select Case iShiftFlag
                    Case 0      'Use current date
                        strWorkDate = CStr(Format(DateAdd(DateInterval.Day, iShiftFlag, dttDateTime), "yyyy-MM-dd"))

                    Case -1     'Use Previous date
                        strWorkDate = CStr(Format(DateAdd(DateInterval.Day, iShiftFlag, dttDateTime), "yyyy-MM-dd"))

                    Case 9      'calcuate the Work date
                        If (CInt(DatePart(DateInterval.Hour, dttDateTime)) - CInt(myArray(0))) < 0 Then
                            If CInt(DatePart(DateInterval.Hour, dttDateTime)) <= CInt(myArray1(0)) Then
                                iShiftFlag = -1     'Use previous date
                            Else
                                iShiftFlag = 0     'Use current date
                            End If

                        Else
                            iShiftFlag = 0     'Use current date
                        End If
                        strWorkDate = CStr(Format(DateAdd(DateInterval.Day, iShiftFlag, dttDateTime), "yyyy-MM-dd"))

                    Case Else   'Shift Flag not setup for the shift in tshift table.
                        Throw New Exception("Shift flag is not setup for the Shift in the database.")
                End Select
                '*****************************

                Return strWorkDate

            Catch ex As Exception
                Throw New Exception("Buisness.ShiftWorkDay.GetWorkDate(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1)
                ReDim myArray(0)
                myArray.Clear(myArray, 0, myArray.Length)
                myArray = Nothing

                ReDim myArray1(0)
                myArray1.Clear(myArray1, 0, myArray1.Length)
                myArray1 = Nothing
            End Try

        End Function

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************
        Private Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '***************************************************
    End Class
End Namespace