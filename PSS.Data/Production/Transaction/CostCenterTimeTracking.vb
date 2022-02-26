Option Explicit On 

Namespace Production
    Public Class CostCenterTimeTracking
        Private _objDataProc As DBQuery.DataProc

        '**************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '**************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '**************************************************************************
        Public Function GetCCIDDesc(Optional ByVal iGroup_ID As Integer = 0, _
                                    Optional ByVal iDataSourceForCombobox As Integer = 0) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT cc_id, cc_desc " & Environment.NewLine
                strSql &= "FROM production.tcostcenter " & Environment.NewLine
                strSql &= "WHERE cc_inactive = 0 " & Environment.NewLine
                If iGroup_ID > 0 Then
                    strSql &= "AND group_id = " & iGroup_ID & Environment.NewLine
                End If
                strSql &= "ORDER BY cc_desc"

                dt = Me._objDataProc.GetDataTable(strSql)
                If iDataSourceForCombobox > 0 Then
                    dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function GetTimeCardEEInfo(ByVal strDate As String, _
                                          Optional ByVal iGroupID As Integer = 0, _
                                          Optional ByVal iCCID As Integer = 0, _
                                          Optional ByVal iEENum As Integer = 0) As DataTable
            Dim objLegiant As PSS.Data.Buisness.Legiant
            Dim strSql As String
            Dim dt, dt1, dtLegiantHrs As DataTable
            Dim R1 As DataRow
            Dim strEENums As String = ""

            Try
                strSql = "SELECT Distinct CONCAT(B.LastName, ', ', B.FirstName) as Name, A.EmployeeNo as 'EE#', C.DepartmentDesc as Department " & Environment.NewLine
                strSql &= ", 0.0 as 'Date Hours' " & Environment.NewLine
                strSql &= ", (SUM(HOUR((CASE WHEN " & String.Format(PSS.Data.Buisness.Generic.NullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - HOUR(InTime)) * 3600 + SUM(MINUTE((CASE WHEN " & String.Format(PSS.Data.Buisness.Generic.NullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - MINUTE(InTime)) * 60 + SUM(SECOND((CASE WHEN " & String.Format(PSS.Data.Buisness.Generic.NullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - SECOND(InTime))) / 3600.0 AS 'Week Hours'" & Environment.NewLine
                'strSql &= ", '' as 'Legiant Hours' " & Environment.NewLine  'Commented out to remove errors from the Legiant system -- 7-Jul-2021 - Charles Hummer
                strSql &= "FROM tpunch A " & Environment.NewLine
                strSql &= "INNER JOIN Security.tlegianteedata B ON A.EmployeeNo = B.EmployeeNum " & Environment.NewLine
                strSql &= "INNER JOIN Security.tlegiantdeptdata C ON B.DepartmentID = C.DepartmentID " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter D ON A.cc_id = D.cc_ID " & Environment.NewLine
                strSql &= "WHERE A.EmployeeNo > 200 " & Environment.NewLine
                strSql &= "AND YEAR(A.punch_wkDate) = YEAR('" & strDate & "') " & Environment.NewLine
                strSql &= "AND WEEK(A.punch_wkDate, 3) = WEEK('" & strDate & "', 3) " & Environment.NewLine
                If iGroupID > 0 Then
                    strSql &= "AND D.group_id = " & iGroupID & Environment.NewLine
                End If
                If iCCID > 0 Then
                    strSql &= "AND A.cc_id = " & iCCID & Environment.NewLine
                End If
                If iEENum > 0 Then
                    strSql &= "AND A.EmployeeNo = " & iEENum & Environment.NewLine
                End If
                strSql &= "GROUP BY A.EmployeeNo " & Environment.NewLine
                strSql &= "ORDER BY Name" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        If strEENums.Trim.Length > 0 Then strEENums &= ", "
                        strEENums &= R1("EE#")
                    Next R1

                    strSql = "SELECT Distinct CONCAT(B.LastName, ', ', B.FirstName) as Name, A.EmployeeNo as 'EE#', C.DepartmentDesc as Department " & Environment.NewLine
                    strSql &= ", (SUM(HOUR((CASE WHEN " & String.Format(PSS.Data.Buisness.Generic.NullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - HOUR(InTime)) * 3600 + SUM(MINUTE((CASE WHEN " & String.Format(PSS.Data.Buisness.Generic.NullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - MINUTE(InTime)) * 60 + SUM(SECOND((CASE WHEN " & String.Format(PSS.Data.Buisness.Generic.NullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - SECOND(InTime))) / 3600.0 AS 'Date Hours'" & Environment.NewLine
                    'strSql &= ", 0.0 as 'Legiant Hours' " & Environment.NewLine  'Commented out to remove errors from the Legiant system -- 7-Jul-2021 - Charles Hummer
                    strSql &= "FROM tpunch A " & Environment.NewLine
                    strSql &= "INNER JOIN Security.tlegianteedata B ON A.EmployeeNo = B.EmployeeNum " & Environment.NewLine
                    strSql &= "INNER JOIN Security.tlegiantdeptdata C ON B.DepartmentID = C.DepartmentID " & Environment.NewLine
                    strSql &= "INNER JOIN tcostcenter D ON A.cc_id = D.cc_ID " & Environment.NewLine
                    strSql &= "WHERE A.EmployeeNo > 200 " & Environment.NewLine
                    strSql &= "AND A.punch_wkDate = '" & strDate & "'" & Environment.NewLine
                    If iGroupID > 0 Then
                        strSql &= "AND D.group_id = " & iGroupID & Environment.NewLine
                    End If
                    If iCCID > 0 Then
                        strSql &= "AND A.cc_id = " & iCCID & Environment.NewLine
                    End If
                    If iEENum > 0 Then
                        strSql &= "AND A.EmployeeNo = " & iEENum & Environment.NewLine
                    End If
                    strSql &= "GROUP BY A.EmployeeNo " & Environment.NewLine
                    strSql &= "ORDER BY Name" & Environment.NewLine

                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    'Commented out to remove errors from the Legiant system -- 7-Jul-2021 - Charles Hummer
                    'objLegiant = New PSS.Data.Buisness.Legiant()
                    'dtLegiantHrs = objLegiant.GetLegiantTimeCardHrs(strEENums, strDate)

                    For Each R1 In dt.Rows
                        R1.BeginEdit()

                        If Not IsDBNull(R1("Week Hours")) Then If R1("Week Hours") > 0 Then R1("Week Hours") = Format(R1("Week Hours"), "#,###.##")

                        'DashBoad selected date work hours
                        If dt1.Select("[EE#] = " & R1("EE#")).Length > 0 Then
                            If Not IsDBNull(dt1.Select("[EE#] = " & R1("EE#"))(0)("Date Hours")) Then
                                If dt1.Select("[EE#] = " & R1("EE#"))(0)("Date Hours") > 0 Then R1("Date Hours") = Format(dt1.Select("[EE#] = " & R1("EE#"))(0)("Date Hours"), "#,###.##")
                            End If
                        End If

                        'Commented out to remove errors from the Legiant system -- 7-Jul-2021 - Charles Hummer
                        'Legiant selected date work hours
                        'If dtLegiantHrs.Select("[EE#] = " & R1("EE#")).Length > 0 Then
                        '    If Not IsDBNull(dtLegiantHrs.Select("[EE#] = " & R1("EE#"))(0)("LegiantHrs")) Then
                        '        If R1("Legiant Hours").ToString.Trim.Length = 0 Then R1("Legiant Hours") = 0
                        '        If dtLegiantHrs.Select("[EE#] = " & R1("EE#"))(0)("LegiantHrs") > 0 Then R1("Legiant Hours") = Format(dtLegiantHrs.Select("[EE#] = " & R1("EE#"))(0)("LegiantHrs"), "#,###.##")
                        '        If R1("Legiant Hours").ToString.Trim.Length > 0 AndAlso R1("Legiant Hours") < 0 Then R1("Legiant Hours") = "Miss Punch"
                        '    End If
                        'End If

                        R1.EndEdit()
                    Next R1
                    dt.AcceptChanges()
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                PSS.Data.Buisness.Generic.DisposeDT(dtLegiantHrs)
            End Try
        End Function

        '**************************************************************************
        Public Function IsStatProdIncDataAvail(ByVal dDateStarWeek As Date) As Boolean
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM production.tcc_stateehrs " & Environment.NewLine
                strSql &= "WHERE cceh_StartDate = '" & Format(dDateStarWeek, "yyyy-MM-dd") & "'" & Environment.NewLine

                If Me._objDataProc.GetIntValue(strSql) > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function GetDasBoardTime(ByVal strWkDate As String, _
                                        ByVal iEENum As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tpunch.punch_id, group_desc as 'Group' " & Environment.NewLine
                strSql &= ", cc_desc as 'Line' " & Environment.NewLine
                strSql &= ", intime as 'In' " & Environment.NewLine
                strSql &= ", outtime as 'Out' " & Environment.NewLine
                strSql &= ", InTime, OutTime " & Environment.NewLine
                strSql &= "FROM tpunch " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tpunch.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "INNER JOIN lgroups On tcostcenter.group_id = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE tpunch.EmployeeNo = " & iEENum & Environment.NewLine
                strSql &= "AND tpunch.punch_wkDate = '" & strWkDate & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function UpdateLogInOutTime(ByVal iPunch_ID As Integer, _
                                           ByVal strOldInTime As String, _
                                           ByVal strOldOutTime As String, _
                                           ByVal strNewInTime As String, _
                                           ByVal strNewOutTime As String, _
                                           ByVal iCC_ID As Integer, _
                                           ByVal iEENo As Integer, _
                                           ByVal iUserID As Integer, _
                                           ByVal strUserName As String) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                If iPunch_ID > 0 Then

                    strSql = "UPDATE tpunch " & Environment.NewLine
                    strSql &= "SET InTime = '" & strNewInTime & "'" & Environment.NewLine
                    strSql &= ", OutTime = '" & strNewOutTime & "'" & Environment.NewLine
                    strSql &= "WHERE tpunch.Punch_ID = " & iPunch_ID & Environment.NewLine

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "INSERT INTO tpunchedithistory ( " & Environment.NewLine
                    strSql &= "pe_EditDateTime " & Environment.NewLine
                    strSql &= ", pe_EditType" & Environment.NewLine
                    strSql &= ", pe_OldInTime" & Environment.NewLine
                    strSql &= ", pe_OldOutTime" & Environment.NewLine
                    strSql &= ", pe_NewInTime" & Environment.NewLine
                    strSql &= ", pe_NewOutTime" & Environment.NewLine
                    strSql &= ", punch_id" & Environment.NewLine
                    strSql &= ", user_id" & Environment.NewLine
                    strSql &= ", user_name" & Environment.NewLine
                    strSql &= ") VALUES ( "
                    strSql &= "now() " & Environment.NewLine
                    strSql &= ", 'Update' " & Environment.NewLine
                    strSql &= ", '" & strOldInTime & "' " & Environment.NewLine
                    strSql &= ", '" & strOldOutTime & "' " & Environment.NewLine
                    strSql &= ", '" & strNewInTime & "' " & Environment.NewLine
                    strSql &= ", '" & strNewOutTime & "' " & Environment.NewLine
                    strSql &= ", " & iPunch_ID & " " & Environment.NewLine
                    strSql &= ", " & iUserID & " " & Environment.NewLine
                    strSql &= ", '" & strUserName & "' );" & Environment.NewLine

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                Else
                    strSql = "INSERT INTO tpunch ( InTime, OutTime, punch_wkDate, cc_id, EmployeeNo )" & Environment.NewLine
                    strSql &= "VALUES " & Environment.NewLine
                    strSql &= "( '" & strNewInTime & "'" & Environment.NewLine
                    strSql &= ", '" & strNewOutTime & "'" & Environment.NewLine
                    strSql &= ", '" & Format(CDate(strNewInTime), "yyyy-MM-dd") & "'" & Environment.NewLine
                    strSql &= ", " & iCC_ID & Environment.NewLine
                    strSql &= ", " & iEENo & Environment.NewLine
                    strSql &= ") " & Environment.NewLine

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "INSERT INTO tpunchedithistory ( " & Environment.NewLine
                    strSql &= "pe_EditDateTime " & Environment.NewLine
                    strSql &= ", pe_EditType" & Environment.NewLine
                    strSql &= ", pe_NewInTime" & Environment.NewLine
                    strSql &= ", pe_NewOutTime" & Environment.NewLine
                    strSql &= ", punch_id" & Environment.NewLine
                    strSql &= ", user_id" & Environment.NewLine
                    strSql &= ", user_name" & Environment.NewLine
                    strSql &= ") VALUES ( "
                    strSql &= "now() " & Environment.NewLine
                    strSql &= ", 'New' " & Environment.NewLine
                    strSql &= ", '" & strNewInTime & "' " & Environment.NewLine
                    strSql &= ", '" & strNewOutTime & "' " & Environment.NewLine
                    strSql &= ", " & iPunch_ID & " " & Environment.NewLine
                    strSql &= ", " & iUserID & " " & Environment.NewLine
                    strSql &= ", '" & strUserName & "' );" & Environment.NewLine

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function DeletePunchRecord(ByVal iPunch_ID As Integer, _
                                          ByVal iUserID As Integer, _
                                          ByVal strUserName As String, _
                                          ByVal strInTime As String, _
                                          ByVal strOutTime As String) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                strSql = "DELETE FROM tpunch " & Environment.NewLine
                strSql &= "WHERE tpunch.Punch_ID = " & iPunch_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "INSERT INTO tpunchedithistory ( " & Environment.NewLine
                strSql &= "pe_EditDateTime " & Environment.NewLine
                strSql &= ", pe_EditType" & Environment.NewLine
                If strInTime.Trim.Length > 0 Then strSql &= ", pe_OldInTime" & Environment.NewLine
                If strOutTime.Trim.Length > 0 Then strSql &= ", pe_OldOutTime" & Environment.NewLine
                strSql &= ", punch_id" & Environment.NewLine
                strSql &= ", user_id" & Environment.NewLine
                strSql &= ", user_name" & Environment.NewLine
                strSql &= ") VALUES ( "
                strSql &= "now() " & Environment.NewLine
                strSql &= ", 'Delete' " & Environment.NewLine
                If strInTime.Trim.Length > 0 Then strSql &= ", '" & strInTime & "' " & Environment.NewLine
                If strOutTime.Trim.Length > 0 Then strSql &= ", '" & strOutTime & "' " & Environment.NewLine
                strSql &= ", " & iPunch_ID & " " & Environment.NewLine
                strSql &= ", " & iUserID & " " & Environment.NewLine
                strSql &= ", '" & strUserName & "' );" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function getEmployeeDeptData() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT IF(Length(trim(b.DepartmentDesc))>0, 'Yes','No') AS IsMapped,a.EmployeeNum,a.FirstName,a.LastName,a.MiddleInitial as MidIni_MidName,IF(Length(trim(b.DepartmentDesc))>0, b.DepartmentDesc,'')  as Dept" & Environment.NewLine
                strSql &= " ,IF(Length(trim(c.user_fullname))>0, c.user_fullname,'') AS 'Map Creator',IF(Length(trim(a.EmpDeptMapUpdateTime))>0,a.EmpDeptMapUpdateTime,'') AS EmpDeptMapUpdateTime,IF(Length(trim(a.HireDate))>0, a.HireDate,'') AS HireDate,a.EmpDeptMapUserID,a.ShiftID,a.DepartmentID,a.PayGroupID" & Environment.NewLine
                strSql &= " ,IF(Length(trim(a.EmpKey))>0,a.EmpKey,'') AS EmpKey,IF(Length(trim(a.EmpID))>0,a.EmpID,'') AS EmpID,IF(Length(trim(a.UpdatedDateTime))>0,a.UpdatedDateTime,'') AS UpdatedDateTime,a.LegiantEEData_ID,a.EENumLegiantFormat,IF(Length(trim(b.LegiantDeptData_ID))>0,b.LegiantDeptData_ID,0) AS LegiantDeptData_ID,0 AS 'SessionUpdate'" & Environment.NewLine
                strSql &= " FROM security.tlegianteedata a" & Environment.NewLine
                strSql &= " LEFT JOIN security.tlegiantdeptdata b ON a.DepartmentID=b.DepartmentID" & Environment.NewLine
                strSql &= " LEFT JOIN security.tusers c ON a.EmpDeptMapUserID=c.user_id" & Environment.NewLine
                strSql &= " ORDER BY SessionUpdate Desc, IsMapped,a.FirstName;" & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function getSessionUpdateDbDef() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT 0 AS LegiantEEData_ID, 0 AS SessionUpdate;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**************************************************************************

        Public Function getDepartmentData() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT LegiantDeptData_ID,DepartmentID,DepartmentDesc,Active FROM security.tlegiantdeptdata" & Environment.NewLine
                strSql &= " ORDER BY Active Desc,DepartmentDesc;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************

        Public Function UpdateEmployeeDepartmentMap(ByVal iLegiantEEData_ID As Integer, ByVal strDepartmentID As String, _
                                                    ByVal iUserID As Integer, ByVal strDTime As String) As Integer
            Dim strSql As String

            Try
                strDepartmentID = strDepartmentID.Replace("'", "''")
                strSql = "UPDATE security.tlegianteedata SET DepartmentID='" & strDepartmentID & "',EmpDeptMapUserID=" & iUserID & _
                          ", EmpDeptMapUpdateTime='" & strDTime & "' WHERE LegiantEEData_ID = " & iLegiantEEData_ID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************

    End Class
End Namespace
