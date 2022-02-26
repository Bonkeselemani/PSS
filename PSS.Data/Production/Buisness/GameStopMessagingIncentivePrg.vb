Option Explicit On 

Imports DBQuery.DataProc
Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production
Imports System.Windows.Forms
Imports system.IO
Imports System.Text
Imports PSS.Data.Buisness.Generic

Namespace Buisness
    Public Class IncentivePrg
        
        Dim _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

		Public Sub New()
			Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
		End Sub


		Public Sub DisplayMessage(ByVal strMsg As String, Optional ByVal iStackIndex As Integer = 3, Optional ByVal bIsErrMsg As Boolean = True)
			Me._objDataProc.DisplayMessage(strMsg, iStackIndex, bIsErrMsg)
		End Sub


		Private Shared Sub NAR(ByVal o As Object)
			Try
				System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
			Catch
			Finally
				o = Nothing
			End Try
		End Sub

		'***************************************************
		'Dispose dt
		'***************************************************
		Public Function DisposeDT(ByRef dt As DataTable)
			If Not IsNothing(dt) Then
				dt.Dispose()
				dt = Nothing
			End If
		End Function

#End Region

#Region "Set PIP UPH By Model"

		Public Function GetMasterGroups(ByVal booAddSelectRow As Boolean) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT * " & Environment.NewLine
				strSql &= "FROM lgroups " & Environment.NewLine
				strSql &= "WHERE MasterGroup = 1 and Active = 1" & Environment.NewLine
				strSql &= "ORDER BY Group_desc " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try
		End Function


		Public Function GetWorkAreas(ByVal booAddSelectRow As Boolean) As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable

			Try
				strSql = "SELECT * FROM lworkarea WHERE wa_inactive = 0 " & Environment.NewLine
				strSql &= "ORDER BY wa_desc " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try
		End Function

		Public Function GetGroupModel(ByVal GroupID As Integer) As DataTable
			Dim _sb As New StringBuilder()
			Dim dt As DataTable
			Try
				_sb.Append("SELECT ")
				_sb.Append("Group_Desc As 'Group Desc.', ")
				_sb.Append("wa_desc As 'Work Area', ")
				_sb.Append("model_desc As 'Model Desc.', ")
				_sb.Append("gmf_UPH_Tier1 AS 'Tier 1', ")
				_sb.Append("gmf_UPH_Tier2 AS 'Tier 2', ")
				_sb.Append("split_by_disp AS 'Split By Disp', ")
				_sb.Append("sof_uph_tier1 AS 'SOF Tier 1', ")
				_sb.Append("sof_uph_tier2 AS 'SOF Tier 2', ")
				_sb.Append("fun_uph_tier1 AS 'FUN Tier 1', ")
				_sb.Append("fun_uph_tier2 AS 'FUN Tier 2', ")
				_sb.Append("cos_uph_tier1 AS 'COS Tier 1', ")
				_sb.Append("cos_uph_tier2 AS 'COS Tier 2', ")
				_sb.Append("ntf_uph_tier1 AS 'NTF Tier 1', ")
				_sb.Append("ntf_uph_tier2 AS 'NTF Tier 2', ")
				_sb.Append("gmf_id AS 'GMID' ")
				_sb.Append("FROM tgroupmodelfactor a ")
				_sb.Append("INNER JOIN tmodel b ON a.model_id = b.model_id ")
				_sb.Append("INNER JOIN lgroups c ON a.group_id = c.group_id ")
				_sb.Append("LEFT OUTER JOIN lworkarea d ON a.wa_id = d.wa_id ")
				_sb.Append("WHERE a.group_id = " & GroupID.ToString() & " ")
				_sb.Append("ORDER BY 'Work Area', 'Model Desc.'; ")
				dt = Me._objDataProc.GetDataTable(_sb.ToString())
				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Me.DisposeDT(dt)
			End Try
		End Function

		Public Function UpdateGroupModel(ByVal GMID As Integer, _
		 ByVal Tier1 As Double, ByVal Tier2 As Double, _
		 ByVal sof_tier1 As Double, ByVal sof_tier2 As Double, _
		 ByVal fun_tier1 As Double, ByVal fun_tier2 As Double, _
		 ByVal cos_tier1 As Double, ByVal cos_tier2 As Double, _
		 ByVal ntf_tier1 As Double, ByVal ntf_tier2 As Double, _
		 ByVal split_by_disp As Integer) As Integer
			Dim _sb As New StringBuilder()
			Try
				_sb.Append("UPDATE tgroupmodelfactor ")
				_sb.Append("SET ")
				_sb.Append("gmf_unithour = " & Tier1.ToString() & ", ")
				_sb.Append("split_by_disp = " & split_by_disp.ToString() & ", ")
				_sb.Append("gmf_UPH_Tier1 = " & ConvertBackToNullString(Tier1.ToString(), False) & ", ")
				_sb.Append("gmf_UPH_Tier2 = " & ConvertBackToNullString(Tier2.ToString(), False) & ", ")
				_sb.Append("sof_uph_tier1 = " & ConvertBackToNullString(sof_tier1.ToString(), False) & ", ")
				_sb.Append("sof_uph_tier2 = " & ConvertBackToNullString(sof_tier2.ToString(), False) & ", ")
				_sb.Append("fun_uph_tier1 = " & ConvertBackToNullString(fun_tier1.ToString(), False) & ", ")
				_sb.Append("fun_uph_tier2 = " & ConvertBackToNullString(fun_tier2.ToString(), False) & ", ")
				_sb.Append("cos_uph_tier1 = " & ConvertBackToNullString(cos_tier1.ToString(), False) & ", ")
				_sb.Append("cos_uph_tier2 = " & ConvertBackToNullString(cos_tier2.ToString(), False) & ", ")
				_sb.Append("ntf_uph_tier1 = " & ConvertBackToNullString(ntf_tier1.ToString(), False) & ", ")
				_sb.Append("ntf_uph_tier2 = " & ConvertBackToNullString(ntf_tier2.ToString(), False) & " ")
				_sb.Append("WHERE gmf_id = " & GMID.ToString() & ";")
				Return _objDataProc.ExecuteNonQuery(_sb.ToString())
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function InsertintoGroupModel( _
		 ByVal GroupID As Integer, _
		 ByVal WaID As Integer, _
		 ByVal ModelID As Integer, _
		 ByVal Tier1 As Double, ByVal Tier2 As Double, _
		 ByVal sof_tier1 As Double, ByVal sof_tier2 As Double, _
		 ByVal fun_tier1 As Double, ByVal fun_tier2 As Double, _
		 ByVal cos_tier1 As Double, ByVal cos_tier2 As Double, _
		 ByVal ntf_tier1 As Double, ByVal ntf_tier2 As Double, _
		 ByVal split_by_disp As Integer) As Integer
			Dim _sb As New StringBuilder()
			Try
				_sb.Append("INSERT INTO tgroupmodelfactor (")
				_sb.Append("gmf_unithour, ")
				_sb.Append("gmf_UPH_Tier1, ")
				_sb.Append("gmf_UPH_Tier2, ")
				_sb.Append("split_by_disp, ")
				_sb.Append("sof_uph_tier1, ")
				_sb.Append("sof_uph_tier2, ")
				_sb.Append("fun_uph_tier1, ")
				_sb.Append("fun_uph_tier2, ")
				_sb.Append("cos_uph_tier1, ")
				_sb.Append("cos_uph_tier2, ")
				_sb.Append("ntf_uph_tier1, ")
				_sb.Append("ntf_uph_tier2, ")
				_sb.Append("group_id, ")
				_sb.Append("wa_id, ")
				_sb.Append("model_id ")
				_sb.Append(") ")
				_sb.Append("VALUES ")
				_sb.Append("( ")
				_sb.Append(Tier1.ToString() & ", ")
				_sb.Append(ConvertBackToNullString(Tier1.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(Tier2.ToString(), False) & ", ")
				_sb.Append(split_by_disp.ToString() & ", ")
				_sb.Append(ConvertBackToNullString(sof_tier1.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(sof_tier2.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(fun_tier1.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(fun_tier2.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(cos_tier1.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(cos_tier2.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(ntf_tier1.ToString(), False) & ", ")
				_sb.Append(ConvertBackToNullString(ntf_tier2.ToString(), False) & ", ")
				_sb.Append(GroupID.ToString() & ", ")
				_sb.Append(WaID.ToString() & ", ")
				_sb.Append(ModelID.ToString() & " ")
				_sb.Append("); ")
				Return _objDataProc.ExecuteNonQuery(_sb.ToString())
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function InsertintoGroupModelHistory( _
		 ByVal GroupID As Integer, _
		 ByVal WaID As Integer, _
		 ByVal ModelID As Integer, _
		 ByVal Tier1 As Double, _
		 ByVal Tier2 As Double, _
		 ByVal split_by_disp As Integer, _
		 ByVal sof_uph_tier1 As Double, _
		 ByVal sof_uph_tier2 As Double, _
		 ByVal fun_uph_tier1 As Double, _
		 ByVal fun_uph_tier2 As Double, _
		 ByVal cos_uph_tier1 As Double, _
		 ByVal cos_uph_tier2 As Double, _
		 ByVal ntf_uph_tier1 As Double, _
		 ByVal ntf_uph_tier2 As Double, _
		 ByVal UserID As String) As Integer
			Dim _sb As New StringBuilder()
			Try
				_sb.Append("INSERT INTO tgroupmodelfactorhistory ( ")
				_sb.Append("gmf_UPH_Tier1, ")
				_sb.Append("gmf_UPH_Tier2, ")
				_sb.Append("group_id, ")
				_sb.Append("wa_id, ")
				_sb.Append("model_id, ")
				_sb.Append("gmfh_updateDT, ")
				_sb.Append("gmfh_userid, ")
				_sb.Append("gmf_split_by_disp, ")
				_sb.Append("gmf_sof_uph_tier1, ")
				_sb.Append("gmf_sof_uph_tier2, ")
				_sb.Append("gmf_fun_uph_tier1, ")
				_sb.Append("gmf_fun_uph_tier2, ")
				_sb.Append("gmf_cos_uph_tier1, ")
				_sb.Append("gmf_cos_uph_tier2, ")
				_sb.Append("gmf_ntf_uph_tier1, ")
				_sb.Append("gmf_ntf_uph_tier2 ")
				_sb.Append(") ")
				_sb.Append("VALUES( ")
				_sb.Append(Tier1.ToString() & ", ")
				_sb.Append(Tier2.ToString() & ", ")
				_sb.Append(GroupID.ToString() & ", ")
				_sb.Append(WaID.ToString() & ", ")
				_sb.Append(ModelID.ToString() & ", ")
				_sb.Append(ConvertToMySQLDateOrNullString(Now()) & ", ")
				_sb.Append(UserID.ToString() & ", ")
				_sb.Append(split_by_disp.ToString() & ", ")
				_sb.Append(sof_uph_tier1.ToString() & ", ")
				_sb.Append(sof_uph_tier2.ToString() & ", ")
				_sb.Append(fun_uph_tier1.ToString() & ", ")
				_sb.Append(fun_uph_tier2.ToString() & ", ")
				_sb.Append(cos_uph_tier1.ToString() & ", ")
				_sb.Append(cos_uph_tier2.ToString() & ", ")
				_sb.Append(ntf_uph_tier1.ToString() & ", ")
				_sb.Append(ntf_uph_tier2.ToString() & " ")
				_sb.Append("); ")
				Return _objDataProc.ExecuteNonQuery(_sb.ToString())
			Catch ex As Exception
				Throw ex
			End Try
		End Function

#End Region

		Public Function GetPayRollPeriodWeekly() As DataTable
			Dim strSql As String
			Dim dt As DataTable
			Dim R1 As DataRow
			Dim dteEndDate As Date
			Dim dteToday As Date
			Dim iID As Integer

			Try
				strSql = "SELECT PC_ID as ID, PC_YearStartDate AS StartDate, " & Environment.NewLine
				strSql &= "DATE_ADD(PC_YearStartDate,  INTERVAL 6 DAY) as EndDate, " & Environment.NewLine
				strSql &= "DATE_FORMAT(now(), '%Y-%m-%d') as Today, " & Environment.NewLine
				strSql &= "CONCAT(DATE_FORMAT(PC_YearStartDate, '%m/%d/%Y'), ' To ', DATE_FORMAT(DATE_ADD(PC_YearStartDate,  INTERVAL 13 DAY) , '%m/%d/%Y') ) AS DatePeriod " & Environment.NewLine
				strSql &= "FROM lpaycalendar " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					R1 = dt.Rows(0)
					dteEndDate = dt.Rows(0)("EndDate")
					dteToday = dt.Rows(0)("Today")
					iID = dt.Rows(0)("ID")
				End If

				dteEndDate = DateAdd(DateInterval.Day, 7, dteEndDate)

				While dteEndDate < dteToday
					R1 = dt.NewRow
					iID += 1
					R1("ID") = iID
					R1("StartDate") = Format(DateAdd(DateInterval.Day, -6, dteEndDate), "yyyy-MM-dd")
					R1("EndDate") = Format(dteEndDate, "yyyy-MM-dd")
					R1("Today") = Format(dteToday, "yyyy-MM-dd")
					R1("DatePeriod") = Format(CDate(R1("StartDate")), "MM/dd/yyyy") & " To " & Format(CDate(R1("EndDate")), "MM/dd/yyyy")
					dt.Rows.Add(R1)
					dt.AcceptChanges()
					R1 = Nothing
					dteEndDate = DateAdd(DateInterval.Day, 7, dteEndDate)
				End While

				dt.LoadDataRow(New Object() {"0", Now(), Now(), Now(), "-- SELECT --"}, False)

				Return dt

			Catch ex As Exception
				Me._objDataProc.DisplayMessage(ex.Message)
			Finally
				If Not IsNothing(dt) Then
					dt.Dispose()
					dt = Nothing
				End If
			End Try
		End Function
		Public Function GetPayRollPeriodBiWeekly() As DataTable
			Dim strSql As String
			Dim dt As DataTable
			Dim R1 As DataRow
			Dim dteStartDate As Date
			Dim dteToday As Date
			Dim iID As Integer

			Try
				strSql = "SELECT PC_ID as ID, PC_YearStartDate AS StartDate, " & Environment.NewLine
				strSql &= "DATE_ADD(PC_YearStartDate,  INTERVAL 13 DAY) as EndDate, " & Environment.NewLine
				strSql &= "DATE_FORMAT(now(), '%Y-%m-%d') as Today, " & Environment.NewLine
				strSql &= "CONCAT(DATE_FORMAT(PC_YearStartDate, '%m/%d/%Y'), ' To ', DATE_FORMAT(DATE_ADD(PC_YearStartDate,  INTERVAL 13 DAY) , '%m/%d/%Y') ) AS DatePeriod " & Environment.NewLine
				strSql &= "FROM lpaycalendar " & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)

				If dt.Rows.Count > 0 Then
					R1 = dt.Rows(0)
					dteStartDate = dt.Rows(0)("StartDate")
					dteToday = dt.Rows(0)("Today")
					iID = dt.Rows(0)("ID")
				End If

				dteStartDate = DateAdd(DateInterval.Day, 14, dteStartDate)

				While DateAdd(DateInterval.Day, 7, dteStartDate) <= dteToday
					R1 = dt.NewRow
					iID += 1
					R1("ID") = iID
					R1("StartDate") = Format(dteStartDate, "yyyy-MM-dd")
					R1("EndDate") = Format(DateAdd(DateInterval.Day, 13, dteStartDate), "yyyy-MM-dd")
					R1("Today") = Format(dteToday, "yyyy-MM-dd")
					R1("DatePeriod") = Format(dteStartDate, "MM/dd/yyyy") & " To " & Format(CDate(R1("EndDate")), "MM/dd/yyyy")
					dt.Rows.Add(R1)
					dt.AcceptChanges()
					R1 = Nothing
					dteStartDate = DateAdd(DateInterval.Day, 14, dteStartDate)
				End While

				dt.LoadDataRow(New Object() {"0", Now(), Now(), Now(), "-- SELECT --"}, False)

				Return dt

			Catch ex As Exception
				Me._objDataProc.DisplayMessage(ex.Message)
			Finally
				If Not IsNothing(dt) Then
					dt.Dispose()
					dt = Nothing
				End If
			End Try
		End Function
		Public Function GetGroupData() As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT Group_Desc as Name, Group_ID as ID, Special_Project " & Environment.NewLine
				strSql &= "FROM lgroups " & Environment.NewLine
				strSql &= "WHERE PIP_Rpt = 1 "

				Return Me._objDataProc.GetDataTable(strSql)

			Catch ex As Exception
				Me._objDataProc.DisplayMessage(ex.Message)
			End Try
		End Function
		Public Function GetCosCenters(ByVal iGroupID) As DataTable
			Dim strSql As String
			Dim dt As DataTable
			Try
				strSql = "SELECT Concat(Group_Desc,'-',CC_Desc) as CC_Desc, CC_ID " & Environment.NewLine
				strSql &= "FROM tcostcenter " & Environment.NewLine
				strSql &= "INNER JOIN lgroups ON tcostcenter.Group_ID = lgroups.Group_ID " & Environment.NewLine
				strSql &= "WHERE tcostcenter.Group_ID = " & iGroupID
				dt = Me._objDataProc.GetDataTable(strSql)
				dt.LoadDataRow(New Object() {"--Select--", 0}, False)
				Return dt
			Catch ex As Exception
				Me._objDataProc.DisplayMessage(ex.Message)
			Finally
				PSS.Data.Buisness.Generic.DisposeDT(dt)
			End Try
		End Function
		Public Function CreateDynamicCellsCalRpt( _
		  ByVal iGroup_ID As Integer, _
		  ByVal strGroupDesc As String, _
		  ByVal strStartDate As String, _
		  ByVal strEndDate As String, _
		  ByVal iSpecialProject As Integer) As Integer
			Dim objDBRpt As PSS.Data.Buisness.DashBoardRpt
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objWorkbook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
			 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim iRow As Integer = 1
			Dim iCol As Integer = 65
			Dim strCellHeaders() As String = {"CELL", "Fallout %Goal", "Actual Fallout%", "AQL2 Rejects FACTOR", "AQL1 rejects FACTOR", "Hrs Worked inCell", _
			 "#Of GoodUnits OutOfCell", "#Of Ship GoodUnits OutOfCell", "Gross UPH", "#of AQL1 (Critical) Failures", "#of AQL2 (Cosmetic) Failures", "Net Units Produced", _
			 "Net UPH", "Tier1 Cell UPH Goal", "Tier2 Cell UPH Goal", "Tier1 Rate", "Tier2 Rate", "Payout forCell"}
			Dim strSupHeaders() As String = {"Support Hrs", "Hrs Worked Overall", "Good Units Produced", "Net UPH", "Support Overall UPH Goal", "Incentive Rate", "Payout forCell"}
			Dim arrCellData(,) As Object
			Dim arrSupData(,) As Object
			Dim R1 As DataRow
			Dim dtLine, dtHrs, dtAQLRej As DataTable
			Dim dblTotalHrs As Double = 0.0
			Dim iTotalShipGoodUnits As Integer = 0
			Dim iTotalQCFunPassUnits As Integer = 0
			Dim iTotalAQLRejCritical As Integer = 0
			Dim iTotalAQLRejNoneCritical As Integer = 0
			Dim iTotalFallout As Integer = 0
			Dim iLinesTotalFallout As Integer = 0

			Try
				'**************************************
				objDBRpt = New PSS.Data.Buisness.DashBoardRpt()
				dtLine = objDBRpt.GetCostCenterLine(iGroup_ID, False, True, strStartDate, strEndDate)
				dtHrs = Me.GetTotalWrkHrByDateRange(strStartDate, strEndDate, iGroup_ID)

				If dtLine.Rows.Count > 0 Then
					'Prepare report
					objExcel = New Excel.Application()
					objExcel.Application.DisplayAlerts = False
					objWorkbook = objExcel.Workbooks.Add
					objSheet = objWorkbook.Sheets("Sheet1")
					objExcel.Visible = True
					'objSheet.Activate()
					objSheet.Name = "Incentive Data"

					'***********************************
					'Daily section
					'***********************************
					'write timestamp and group description as title
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = objDBRpt.GetDateTimeStamp
					iRow += 1
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strGroupDesc & " Week: " & Format(CDate(strStartDate), "MM/dd/yyyy") & " - " & Format(CDate(strEndDate), "MM/dd/yyyy")
					iRow += 2
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "CELL UPH CALCULATION"
					iRow += 2

					'redefine array
					ReDim arrCellData(dtLine.Rows.Count + 1, strCellHeaders.Length)
					ReDim arrSupData(2, strSupHeaders.Length)

					'***********************************
					'Cell data
					'***********************************
					'Header production cell
					For i = 0 To strCellHeaders.Length - 1
						arrCellData(j, i) = strCellHeaders(i).Replace(" ", vbLf)
					Next i

					'Header for support
					For i = 0 To strSupHeaders.Length - 1
						arrSupData(j, i) = strSupHeaders(i).Replace(" ", vbLf)
					Next i

					For Each R1 In dtLine.Rows
						If R1("cc_desc").ToString.Trim.ToUpper = "SUPPORT" Then
							If Not IsDBNull(dtHrs.Compute("SUM(TotalTime)", "cc_id = " & R1("cc_id"))) Then arrSupData(1, 0) = Math.Round(CDec(dtHrs.Compute("SUM(TotalTime)", "cc_id = " & R1("cc_id"))) / 3600.0, 2) Else arrSupData(1, 0) = "0.00"
							If Not IsDBNull(dtHrs.Compute("SUM(TotalTime)", "")) Then arrSupData(1, 1) = Math.Round(CDec(dtHrs.Compute("SUM(TotalTime)", "")) / 3600.0, 2) Else arrSupData(1, 1) = "0.00"
							If iSpecialProject = 1 Or R1("cc_specproj") = 1 Then
								arrSupData(1, 2) = DashBoardRpt.GetShipGoodUnitsSpecialProj(iGroup_ID, strStartDate, strEndDate, R1("cc_id"))
							Else
								arrSupData(1, 2) = DashBoardRpt.GetShipGoodUnits(iGroup_ID, strStartDate, strEndDate, )
							End If
							arrSupData(1, 3) = "=IF(RC[-2]>= 0,(RC[-1]/RC[-2]),0)"
							arrSupData(1, 4) = R1("cc_uph_tier1")
							arrSupData(1, 5) = R1("cc_tier1_rate")
							arrSupData(1, 6) = "=IF(RC[-3]>=RC[-2],(RC[-1]*RC[-6]),0)"
						Else
							j += 1
							dblTotalHrs = 0.0
							iTotalQCFunPassUnits = 0
							iTotalShipGoodUnits = 0
							iTotalAQLRejCritical = 0
							iTotalAQLRejNoneCritical = 0
							iTotalFallout = 0

							'*******************************
							'Daily total good unit, UPH
							'*******************************
							If Not IsDBNull(dtHrs.Compute("SUM(TotalTime)", "cc_id = " & R1("cc_id"))) Then
								dblTotalHrs = Math.Round(CDec(dtHrs.Compute("SUM(TotalTime)", "cc_id = " & R1("cc_id"))) / 3600.0, 2)
							End If
							arrCellData(j, 0) = R1("cc_desc")

							If dblTotalHrs > 0 Then
								'*******************************
								'QC Functional Pass Units
								'*******************************
								iTotalQCFunPassUnits = objDBRpt.GetCellProducedUnits(R1("Group_ID"), R1("cc_id"), R1("Produce_QCType_ID"), strStartDate, strEndDate)

								'*******************************
								'Ship Good Units
								'*******************************
								If iSpecialProject = 1 Or R1("cc_specproj") = 1 Then
									iTotalShipGoodUnits = DashBoardRpt.GetShipGoodUnitsSpecialProj(iGroup_ID, strStartDate, strEndDate, R1("cc_id"))
								Else
									iTotalShipGoodUnits = DashBoardRpt.GetShipGoodUnits(iGroup_ID, strStartDate, strEndDate, R1("cc_id"))
								End If

								'*******************************
								'AQL Reject
								'*******************************
								Me.DisposeDT(dtAQLRej)
								dtAQLRej = DashBoardRpt.GetFQA_AQLReject(R1("cc_id"), strStartDate, strEndDate)
								iTotalAQLRejCritical = dtAQLRej.Select("Dcode_Critical = 1").Length
								iTotalAQLRejNoneCritical = dtAQLRej.Select("Dcode_Critical = 0").Length

								'*******************************
								'Fallout
								'*******************************
								iTotalFallout = DashBoardRpt.GetTotalFallOutUnits(R1("cc_id"), iGroup_ID, strStartDate, strEndDate)
								iLinesTotalFallout += iTotalFallout

								'*******************************
								arrCellData(j, 1) = R1("cc_failLimitPercent") & "%"
								arrCellData(j, 2) = "=" & iTotalFallout & "/(" & iTotalFallout & "+RC[5])"
								arrCellData(j, 3) = R1("cc_rof")
								arrCellData(j, 4) = R1("cc_rcf")
								arrCellData(j, 5) = dblTotalHrs
								arrCellData(j, 6) = iTotalQCFunPassUnits								 'QC Functional Pass Units
								arrCellData(j, 7) = iTotalShipGoodUnits								'Ship units
								arrCellData(j, 8) = "=ROUND(RC[-1]/RC[-3],2)"								'Gross UPH
								arrCellData(j, 9) = iTotalAQLRejCritical
								arrCellData(j, 10) = iTotalAQLRejNoneCritical
								arrCellData(j, 11) = "=RC[-4]-(RC[-2]*RC[-7])-(RC[-1]*RC[-8])"								'Net Units Produced
								arrCellData(j, 12) = "=ROUND(RC[-1]/RC[-7],2)"								'Net UPH
								arrCellData(j, 13) = R1("cc_uph_tier1")								  'Tier 1
								arrCellData(j, 14) = R1("cc_uph_tier2")								  'Tier 2
								arrCellData(j, 15) = R1("cc_tier1_rate")								  'Tier 1 Rate
								arrCellData(j, 16) = R1("cc_tier2_rate")								  'Tier 2 Rate
								arrCellData(j, 17) = "=IF(RC[-5]>=RC[-3],(RC[-1]*RC[-12]),IF(RC[-5]>=RC[-4],(RC[-2]*RC[-12]),0))"
							End If
						End If
					Next R1

					j += 1					'Total
					arrCellData(j, 0) = "Total"
					arrCellData(j, 2) = "=" & iLinesTotalFallout & "/(" & iLinesTotalFallout & "+RC[5])"
					arrCellData(j, 5) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
					arrCellData(j, 6) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"					'QC Functional Pass Units
					arrCellData(j, 7) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"					'Ship units
					arrCellData(j, 8) = "=ROUND(RC[-1]/RC[-3],2)"					'Gross UPH
					arrCellData(j, 9) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
					arrCellData(j, 10) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
					arrCellData(j, 11) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
					arrCellData(j, 12) = "=ROUND(RC[-1]/RC[-7],2)"
					arrCellData(j, 17) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"

					'*******************************
					'post data to excel
					objSheet.Range("A" & iRow.ToString & ":R" & (iRow + j).ToString).Value = arrCellData

					'*******************************
					'set border
					objExcel.Range("A" & (iRow).ToString & ":R" & (iRow + j).ToString).Select()
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

					For i = 0 To xlBI.Length - 1
						With objExcel.Selection.Borders(xlBI(i))
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThin
							.ColorIndex = Excel.Constants.xlAutomatic
						End With
					Next i

					'*******************************
					'Center horizontal and vertical for data 
					objSheet.Range("A" & (iRow).ToString, "R" & (iRow + j).ToString).HorizontalAlignment = Excel.Constants.xlRight
					objSheet.Range("A" & (iRow).ToString, "R" & (iRow + j).ToString).VerticalAlignment = Excel.Constants.xlBottom

					'*******************************
					'Set wrap text for header
					objSheet.Range("A" & (iRow).ToString, "R" & (iRow).ToString).WrapText = True

					'*******************************
					'format Line cell
					objSheet.Range("A" & (iRow - 2).ToString, "R" & (iRow - 2).ToString).Merge()
					objSheet.Range("A" & (iRow - 2).ToString, "R" & (iRow - 2).ToString).HorizontalAlignment = Excel.Constants.xlCenter

					'*******************************
					'Title
					With objSheet.Range("A" & (iRow - 2).ToString, "A" & (iRow - 2).ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						.Size = 14
						.Underline = True
						.ColorIndex = 25
					End With
					objSheet.Range("A" & (iRow - 4).ToString, "R" & (iRow - 4).ToString).Merge()
					With objSheet.Range("A" & (iRow - 4).ToString, "A" & (iRow - 4).ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						.Size = 14
						.Underline = True
						.ColorIndex = 25
					End With

					'*******************************
					'header
					With objSheet.Range("A" & iRow.ToString, "R" & iRow.ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						'.Size = 12
						.Underline = True
						.ColorIndex = 25
					End With

					'*******************************
					'Total
					With objSheet.Range("A" & (iRow + j).ToString, "R" & (iRow + j).ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						'.Size = 12
					End With

					'*******************************
					'format
					'*******************************
					objSheet.Range("C" & iRow.ToString & ":C" & (iRow + j).ToString).NumberFormat = "#,##0.00%"
					objSheet.Range("D" & iRow.ToString & ":E" & (iRow + j).ToString).NumberFormat = "#,##0"
					objSheet.Range("F" & iRow.ToString & ":F" & (iRow + j).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("G" & iRow.ToString & ":H" & (iRow + j).ToString).NumberFormat = "#,##0"
					objSheet.Range("I" & iRow.ToString & ":I" & (iRow + j).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("J" & iRow.ToString & ":L" & (iRow + j).ToString).NumberFormat = "#,##0"
					objSheet.Range("M" & iRow.ToString & ":Q" & (iRow + j).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("R" & iRow.ToString & ":R" & (iRow + j).ToString).NumberFormat = "$#,##0.00"

					'Draw a heavier border on the left side
					objExcel.Range("A" & iRow.ToString & ":R" & (iRow + j).ToString).Select()
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With

					'Draw a heavier border on the top & bottom edge  of total
					objExcel.Range("A" & iRow.ToString & ":R" & (iRow + j).ToString).Select()
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

					'Draw a heavier border on the top & bottom edge  of total
					objExcel.Range("A" & (iRow + j).ToString & ":R" & (iRow + j).ToString).Select()
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 1
					End With

					'Highlight odd row in data section
					For i = iRow + 1 To iRow + j
						objExcel.Range("A" & i.ToString & ":R" & i.ToString).Select()
						objExcel.Selection.Interior.ColorIndex = 15
						i += 1
					Next i

					iRow += j + 2

					'***********************************
					'SUPPORT SECTION
					'***********************************
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "SUPPORT UPH CALCULATION"
					iRow += 2

					'*******************************
					'post data to excel
					objSheet.Range("A" & iRow.ToString & ":G" & (iRow + 1).ToString).Value = arrSupData

					'*******************************
					'set border
					objExcel.Range("A" & (iRow).ToString & ":G" & (iRow + 1).ToString).Select()
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

					For i = 0 To xlBI.Length - 1
						With objExcel.Selection.Borders(xlBI(i))
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThin
							.ColorIndex = Excel.Constants.xlAutomatic
						End With
					Next i

					'*******************************
					'Center horizontal and vertical for data 
					objSheet.Range("A" & (iRow).ToString, "G" & (iRow + 1).ToString).HorizontalAlignment = Excel.Constants.xlRight
					objSheet.Range("A" & (iRow).ToString, "G" & (iRow + 1).ToString).VerticalAlignment = Excel.Constants.xlBottom

					'*******************************
					'Set wrap text for header
					objSheet.Range("A" & (iRow).ToString, "G" & (iRow).ToString).WrapText = True

					'*******************************
					'format Line cell
					objSheet.Range("A" & (iRow - 2).ToString, "G" & (iRow - 2).ToString).Merge()
					objSheet.Range("A" & (iRow - 2).ToString, "G" & (iRow - 2).ToString).HorizontalAlignment = Excel.Constants.xlCenter

					'*******************************
					'Title
					With objSheet.Range("A" & (iRow - 2).ToString, "A" & (iRow - 2).ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						.Size = 14
						.Underline = True
						.ColorIndex = 25
					End With

					'*******************************
					'header
					With objSheet.Range("A" & iRow.ToString, "G" & iRow.ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						'.Size = 12
						.Underline = True
						.ColorIndex = 25
					End With

					'*******************************
					'Total
					With objSheet.Range("A" & (iRow + 1).ToString, "G" & (iRow + 1).ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						'.Size = 12
					End With

					'*******************************
					'format
					'*******************************
					objSheet.Range("A" & (iRow + 1).ToString & ":B" & (iRow + 1).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("C" & (iRow + 1).ToString & ":C" & (iRow + 1).ToString).NumberFormat = "#,##0"
					objSheet.Range("D" & (iRow + 1).ToString & ":G" & (iRow + 1).ToString).NumberFormat = "#,##0.00"

					'*******************************
					'Draw a heavier border on the left side
					objExcel.Range("A" & iRow.ToString & ":G" & (iRow + 1).ToString).Select()
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With

					'*******************************
					'Draw a heavier border on the top & bottom edge  of total
					objExcel.Range("A" & iRow.ToString & ":G" & (iRow + 1).ToString).Select()
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
					'Highlight odd row in support section
					objExcel.Range("A" & (iRow + 1).ToString & ":G" & (iRow + 1).ToString).Select()
					objExcel.Selection.Interior.ColorIndex = 15

					'***********************************
					'Adjust column widths
					'***********************************
					For i = 0 To strCellHeaders.Length - 1
						objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 12.43
					Next i

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
						.RightFooter = "&P of &N"
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
					objExcel.Range("C1:C1").Select()
					'***********************************
					'Delete unused worksheets
					'***********************************
					If objWorkbook.Sheets.Count > 1 Then
						For i = objWorkbook.Sheets.Count To 2 Step -1
							objWorkbook.Sheets("Sheet" & i.ToString).Delete()
						Next i
					End If
					'***********************************
				End If
			Catch ex As Exception
				Throw ex
			Finally
				objDBRpt = Nothing
				xlBI = Nothing
				strCellHeaders = Nothing
				arrCellData = Nothing
				R1 = Nothing
				Me.DisposeDT(dtLine)
				Me.DisposeDT(dtHrs)
				Me.DisposeDT(dtAQLRej)
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function
		Public Function CreateDynamicEEStatement( _
		 ByVal strFrDate As String, _
		 ByVal strToDate As String, _
		ByVal iGroup_ID As Integer, _
		Optional ByVal iEENo As Integer = 0) As Integer
			Dim objDBRpt As PSS.Data.Buisness.DashBoardRpt
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objWorkbook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
			 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim iRow As Integer = 1
			Dim strCellHeaders() As String = {"Group", "Area", "Individual Hours Worked", "% in Area Worked", _
			"Team Hours", "Total Hours Worked", "Good Units Produced", "Gross UPH", "AQL1 (Critical) ", _
			"AQL2 (Non-Critical) ", "Net Good Produced", "Net UPH", "Tier 1 Goal @", "Tier 2 Goal @", "% Fallout Goal <=", "% Fallout Actual", ""}
			Dim arrData(,) As Object
			Dim arrEEWorkLines() As DataRow
			Dim R1 As DataRow
			Dim dtEE, dtLine, dtHrs, dtShipUnits, dtFailUnit, dtAQLRej As DataTable
			Dim dblTotalHrs As Double = 0.0
			Dim iTotalGoodUnits As Integer = 0
			Dim iTotalAQLRejCritical As Integer = 0
			Dim iTotalAQLRejNoneCritical As Integer = 0
			Dim booUpdHeader As Boolean = False
			Dim strTimeStamp As String

			Try
				objDBRpt = New PSS.Data.Buisness.DashBoardRpt()
				strTimeStamp = objDBRpt.GetDateTimeStamp
				dtLine = objDBRpt.GetCostCenterLine(iGroup_ID, False, True, strFrDate, strToDate)
				dtEE = Me.GetEEDeptInfoByWrkDate(strFrDate, strToDate, iGroup_ID.ToString, iEENo)
				dtHrs = Me.GetTotalWrkHrByDateRange(strFrDate, strToDate)
				dtShipUnits = Me.GetShipGoodUnitsGroupCnt(strFrDate, strToDate)
				dtFailUnit = Me.GetScrapAndDBRUnitsOfCells(strFrDate, strToDate)

				'Prepare report
				objExcel = New Excel.Application()
				objExcel.Application.DisplayAlerts = False
				objWorkbook = objExcel.Workbooks.Add
				objSheet = objWorkbook.Sheets("Sheet1")
				objExcel.Visible = True
				'objSheet.Activate()
				objSheet.Name = "Incentive Data"

				'***********************************
				'Daily section
				'***********************************
				For Each R1 In dtEE.Rows
					iRow = 1

					'set all cell to be auto-fit 
					objSheet.Cells.Select()
					objSheet.Cells.Clear()

					'write timestamp and group description as title
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strTimeStamp

					iRow += 2

					'*******************************
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Employee Incentive Statement"
					objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).Merge()
					objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

					With objSheet.Range("A" & iRow.ToString, "A" & iRow.ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						.Size = 14
						.Underline = True
						.ColorIndex = 25
					End With
					'*******************************

					iRow += 2

					'*******************************
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Employee#"
					objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = R1("EmployeeNo")
					objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()
					iRow += 1
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Name"
					objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = R1("FirstName") & " " & R1("LastName")
					objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()
					iRow += 1
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Home Department"
					objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = R1("DepartmentDesc")
					objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()
					iRow += 1
					objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Week"
					objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = Format(CDate(strFrDate), "MM/dd") & "-" & Format(CDate(strToDate), "MM/dd")
					objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()

					objSheet.Range("A" & (iRow - 3).ToString & ":D" & (iRow).ToString).NumberFormat = "@"

					'Draw a heavier border on the left side
					objExcel.Range("A" & (iRow - 3).ToString & ":C" & (iRow).ToString).Select()
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With

					iRow += 1
					i = 0
					j = 0
					booUpdHeader = False
					arrEEWorkLines = dtHrs.Select("EmployeeNo = " & R1("EmployeeNo"))
					'***********************************
					'Cell data
					'***********************************
					'redefine array
					ReDim arrData(arrEEWorkLines.Length + 1, strCellHeaders.Length)

					'Header
					For j = 0 To strCellHeaders.Length - 1
						arrData(i, j) = strCellHeaders(j)
					Next j

					For i = 0 To arrEEWorkLines.Length - 1
						arrEEWorkLines(i)("cc_uph_tier1") = dtLine.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("cc_uph_tier1")
						arrEEWorkLines(i)("cc_uph_tier2") = dtLine.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("cc_uph_tier2")

						If arrEEWorkLines(i)("cc_desc").ToString.Trim.ToUpper = "SUPPORT" Then
							arrData(i + 1, 0) = arrEEWorkLines(i)("Group_Desc")
							arrData(i + 1, 1) = arrEEWorkLines(i)("cc_desc")
							arrData(i + 1, 2) = arrEEWorkLines(i)("TotalTime") / 3600.0
							arrData(i + 1, 3) = (arrEEWorkLines(i)("TotalTime") / 3600) / (dtHrs.Compute("SUM(TotalTime)", "EmployeeNo = " & R1("EmployeeNo")) / 3600.0)
							arrData(i + 1, 4) = dtHrs.Compute("SUM(TotalTime)", "cc_id = " & arrEEWorkLines(i)("cc_id")) / 3600.0
							arrData(i + 1, 5) = dtHrs.Compute("SUM(TotalTime)", "Group_ID = " & arrEEWorkLines(i)("Group_ID")) / 3600.0
							arrData(i + 1, 6) = CInt(dtShipUnits.Select("Group_ID = " & arrEEWorkLines(i)("Group_ID"))(0)("Qty"))
							arrData(i + 1, 7) = "=IF(RC[-2]>0,RC[-1]/RC[-2],0)"
							arrData(i + 1, 8) = ""
							arrData(i + 1, 9) = ""
							arrData(i + 1, 10) = CInt(dtShipUnits.Select("Group_ID = " & arrEEWorkLines(i)("Group_ID"))(0)("Qty"))
							arrData(i + 1, 11) = "=IF(RC[-6]>0,RC[-1]/RC[-6],0)"
							arrData(i + 1, 12) = arrEEWorkLines(i)("cc_uph_tier1")
							arrData(i + 1, 13) = arrEEWorkLines(i)("cc_uph_tier2")
							arrData(i + 1, 14) = ""
							arrData(i + 1, 15) = ""
							arrData(i + 1, 16) = "=IF(RC[-5]>=RC[-3],RC[-14]*" & arrEEWorkLines(i)("cc_tier2_rate") & ",IF(RC[-5]>=RC[-4],RC[-14]*" & arrEEWorkLines(i)("cc_tier1_rate") & ",0))"
						Else
							dblTotalHrs = 0.0
							iTotalGoodUnits = 0
							iTotalAQLRejCritical = 0
							iTotalAQLRejNoneCritical = 0

							'******************************************
							'add critical faction and payrate to header
							'******************************************
							If booUpdHeader = False Then
								arrData(i, 8) = arrData(i, 8) & "(x" & arrEEWorkLines(i)("cc_rcf") & ")"
								arrData(i, 9) = arrData(i, 9) & "(x" & arrEEWorkLines(i)("cc_rof") & ")"
								arrData(i, 12) = arrData(i, 12) & arrEEWorkLines(i)("cc_tier1_rate")
								arrData(i, 13) = arrData(i, 13) & arrEEWorkLines(i)("cc_tier2_rate")
								booUpdHeader = True
							End If

							'*******************************
							'AQL Reject

							'*******************************
							Me.DisposeDT(dtAQLRej)
							dtAQLRej = DashBoardRpt.GetFQA_AQLReject(arrEEWorkLines(i)("cc_id"), strFrDate, strToDate)
							iTotalAQLRejCritical = dtAQLRej.Select("Dcode_Critical = 1").Length
							iTotalAQLRejNoneCritical = dtAQLRej.Select("Dcode_Critical = 0").Length

							'*******************************
							'Good Units
							'*******************************
							'iTotalGoodUnits = objDBRpt.GetPassQCFuncUnits(arrEEWorkLines(i)("cc_id"), strFrDate, strToDate)
							iTotalGoodUnits = objDBRpt.GetShipGoodUnits(arrEEWorkLines(i)("Group_ID"), strFrDate, strToDate, arrEEWorkLines(i)("cc_id"))

							arrData(i + 1, 0) = arrEEWorkLines(i)("Group_Desc")
							arrData(i + 1, 1) = arrEEWorkLines(i)("cc_desc")
							arrData(i + 1, 2) = arrEEWorkLines(i)("TotalTime") / 3600.0
							arrData(i + 1, 3) = (arrEEWorkLines(i)("TotalTime") / 3600) / (dtHrs.Compute("SUM(TotalTime)", "EmployeeNo = " & R1("EmployeeNo")) / 3600.0)
							arrData(i + 1, 4) = dtHrs.Compute("SUM(TotalTime)", "cc_id = " & arrEEWorkLines(i)("cc_id")) / 3600.0
							arrData(i + 1, 5) = ""
							arrData(i + 1, 6) = iTotalGoodUnits
							arrData(i + 1, 7) = "=IF(RC[-3]>0,RC[-1]/RC[-3],0)"
							arrData(i + 1, 8) = iTotalAQLRejCritical
							arrData(i + 1, 9) = iTotalAQLRejNoneCritical
							arrData(i + 1, 10) = "=RC[-4] - (RC[-2] * " & arrEEWorkLines(i)("cc_rcf") & ") - (RC[-1] * " & arrEEWorkLines(i)("cc_rof") & ")"
							arrData(i + 1, 11) = "=IF(RC[-7]>0,RC[-1]/RC[-7],0)"
							arrData(i + 1, 12) = arrEEWorkLines(i)("cc_uph_tier1")
							arrData(i + 1, 13) = arrEEWorkLines(i)("cc_uph_tier2")
							arrData(i + 1, 14) = arrEEWorkLines(i)("cc_failLimitPercent") / 100
							arrData(i + 1, 15) = CInt(dtFailUnit.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("cnt")) / (iTotalGoodUnits + CInt(dtFailUnit.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("cnt")))
							arrData(i + 1, 16) = "=IF(RC[-5]>=RC[-3],RC[-14]*" & arrEEWorkLines(i)("cc_tier2_rate") & ",IF(RC[-5]>=RC[-4],RC[-14]*" & arrEEWorkLines(i)("cc_tier1_rate") & ",0))"
						End If
					Next i

					arrData(i + 1, 1) = "Total"
					arrData(i + 1, 2) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
					arrData(i + 1, 3) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
					arrData(i + 1, 8) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
					arrData(i + 1, 9) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
					arrData(i + 1, 16) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"

					'*******************************
					'post data to excel in daily section
					objSheet.Range("A" & iRow.ToString & ":Q" & (iRow + i + 1).ToString).Value = arrData
					'*******************************
					'set border
					objExcel.Range("A" & (iRow).ToString & ":Q" & (iRow + i + 1).ToString).Select()
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

					For j = 0 To xlBI.Length - 1
						With objExcel.Selection.Borders(xlBI(j))
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThin
							.ColorIndex = Excel.Constants.xlAutomatic
						End With
					Next j
					'*******************************
					'Center horizontal and vertical for data
					objSheet.Range("A" & (iRow).ToString, "Q" & (iRow + i + 1).ToString).HorizontalAlignment = Excel.Constants.xlCenter
					objSheet.Range("A" & (iRow).ToString, "Q" & (iRow + i + 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
					'*******************************
					'Header
					objSheet.Range("A" & (iRow).ToString, "Q" & (iRow).ToString).WrapText = True
					With objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						.Size = 8
						.Underline = True
						.ColorIndex = 25
					End With
					objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
					objSheet.Rows(iRow.ToString & ":" & iRow.ToString).EntireRow.AutoFit()
					objSheet.Rows(iRow.ToString & ":" & iRow.ToString).RowHeight = 48
					'*******************************
					'Data
					With objSheet.Range("A" & (iRow + 1).ToString, "Q" & (iRow + i).ToString).Font
						.Name = "Arial"
						.Size = 8
					End With
					'*******************************
					'Total
					With objSheet.Range("A" & (iRow + i + 1).ToString, "Q" & (iRow + i + 1).ToString).Font
						.Name = "Arial"
						.FontStyle = "Bold"
						.Size = 8
					End With

					'*******************************
					'format
					'*******************************
					objSheet.Range("C" & (iRow - 1).ToString & ":C" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("D" & (iRow - 1).ToString & ":D" & (iRow + i + 1).ToString).NumberFormat = "#,##0%"
					objSheet.Range("E" & (iRow - 1).ToString & ":F" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("G" & (iRow - 1).ToString & ":G" & (iRow + i + 1).ToString).NumberFormat = "#,##0"
					objSheet.Range("H" & (iRow - 1).ToString & ":H" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("I" & (iRow - 1).ToString & ":K" & (iRow + i + 1).ToString).NumberFormat = "#,##0"
					objSheet.Range("L" & (iRow - 1).ToString & ":N" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
					objSheet.Range("O" & (iRow - 1).ToString & ":P" & (iRow + i + 1).ToString).NumberFormat = "#,##0%"
					objSheet.Range("Q" & (iRow - 1).ToString & ":Q" & (iRow + i + 1).ToString).NumberFormat = "$#,##0.00"

					'Draw a heavier border on the left side
					objExcel.Range("A" & iRow.ToString & ":Q" & (iRow + i + 1).ToString).Select()
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With
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

					'Draw a heavier border on the top & bottom edge  of total
					objExcel.Range("A" & (iRow + i + 1).ToString & ":Q" & (iRow + i + 1).ToString).Select()
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
						.LineStyle = Excel.XlLineStyle.xlContinuous
						.Weight = Excel.XlBorderWeight.xlThick
						.ColorIndex = 25
					End With

					'***********************************
					'Adjust column widths
					'***********************************
					For i = 0 To strCellHeaders.Length - 1
						If i = 0 Then
							objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 17
						Else
							objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 6.5
						End If
					Next i

					'***********************************
					'Move selection outside the data region 
					'***********************************
					objExcel.Range("C1:C1").Select()
					'***********************************
					'Set page orientation
					'***********************************
					With objSheet.PageSetup
						.Orientation = Excel.XlPageOrientation.xlLandscape
						.LeftFooter = "** PSS Confidential **"
						.RightMargin = -25
						.LeftMargin = -25
						.FitToPagesWide = 1
						.FitToPagesTall = 1
					End With
					'***********************************
					'Set zoom
					'***********************************
					objExcel.ActiveWindow.Zoom = 90
					''***********************************
					''Save Report
					''***********************************
					'If Len(Dir("C:\IncentiveRpt.xls")) > 0 Then
					'    Kill("C:\IncentiveRpt.xls")
					'End If
					'objWorkbook.SaveAs("C:\IncentiveRpt.xls")
					'***********************************
					'print Report
					'***********************************
					'objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
					'***********************************
				Next R1
			Catch ex As Exception
				Throw ex
			Finally
				xlBI = Nothing
				strCellHeaders = Nothing
				arrData = Nothing
				R1 = Nothing
				Me.DisposeDT(dtEE)
				Me.DisposeDT(dtLine)
				Me.DisposeDT(dtHrs)
				Me.DisposeDT(dtShipUnits)
				Me.DisposeDT(dtFailUnit)
				Me.DisposeDT(dtAQLRej)
				'*************************************
				'Excel clean up
				If Not IsNothing(objSheet) Then
					NAR(objSheet)
				End If
				If Not IsNothing(objWorkbook) Then
					objWorkbook.Close(False)
					NAR(objWorkbook)
				End If
				If Not IsNothing(objExcel) Then
					objExcel.Quit()
					NAR(objExcel)
				End If
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function
		Public Function CreateDynamicProdIncPayRpt(ByVal strStartDate As String, _
		 ByVal strEndDate As String, _
		 ByVal strGroupIDs As String) As Integer
			Dim objDBRpt As PSS.Data.Buisness.DashBoardRpt
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objWorkbook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim strHeaders() As String = {"Employee ID", "Date", "Dept", "Pay Type", "Amt"}
			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim iRow As Integer = 1
			Dim arrData(,) As Object
			Dim arrEEWorkLines() As DataRow
			Dim R1 As DataRow
			Dim dtEE, dtHrs, dtShipUnits, dtAQLRej, dtLine As DataTable
			Dim dblIndividualHrs As Double = 0.0
			Dim dblTeamHrs As Double = 0.0
			Dim dblGrpHrs As Double = 0.0
			Dim dblPayAmt As Double = 0.0
			Dim iTotalGoodUnits As Integer = 0
			Dim iTotalAQLRejCritical As Integer = 0
			Dim iTotalAQLRejNoneCritical As Integer = 0
			Dim dblNetUPH As Double = 0.0
			Dim strData As String
			Dim strRptFilePath As String = "C:\Project\Reports\ProdIncPay\ProdIncPay" & Format(Now(), "yyyyMMdd") & ".csv"
			Dim objWriter As StreamWriter

			Try
				objDBRpt = New PSS.Data.Buisness.DashBoardRpt()
				dtLine = objDBRpt.GetCostCenterLine(strGroupIDs, False, True, strStartDate, strEndDate)
				dtEE = Me.GetEEDeptInfoByWrkDate(strStartDate, strEndDate, strGroupIDs, )
				dtHrs = Me.GetTotalWrkHrByDateRange(strStartDate, strEndDate)
				dtShipUnits = Me.GetShipGoodUnitsGroupCnt(strStartDate, strEndDate)

				'Prepare report
				objExcel = New Excel.Application()
				objExcel.Application.DisplayAlerts = False
				objWorkbook = objExcel.Workbooks.Add
				objSheet = objWorkbook.Sheets("Sheet1")
				objExcel.Visible = True
				'objSheet.Activate()
				objSheet.Name = "Incentive Data"

				'*******************************
				'format
				'*******************************
				objSheet.Range("A" & (iRow).ToString & ":A" & (iRow + dtEE.Rows.Count).ToString).NumberFormat = "@"
				objSheet.Range("B" & (iRow).ToString & ":B" & (iRow + dtEE.Rows.Count).ToString).NumberFormat = "m/d/yyyy"
				objSheet.Range("C" & (iRow).ToString & ":D" & (iRow + dtEE.Rows.Count).ToString).NumberFormat = "@"
				objSheet.Range("E" & (iRow).ToString & ":E" & (iRow + dtEE.Rows.Count).ToString).NumberFormat = "#,##0.00"

				'redefine array
				ReDim arrData(dtEE.Rows.Count, strHeaders.Length)

				'write header
				For i = 0 To strHeaders.Length - 1
					arrData(j, i) = strHeaders(i)
					strData &= strHeaders(i) & ","
				Next i

				strData &= vbCrLf

				'***********************************
				'Data section
				'***********************************
				For Each R1 In dtEE.Rows
					dblPayAmt = 0.0

					If Not IsDBNull(dtHrs.Select("EmployeeNo = " & R1("EmployeeNo"))) Then
						arrEEWorkLines = dtHrs.Select("EmployeeNo = " & R1("EmployeeNo"))

						'***********************************
						'Cell data
						'***********************************

						For i = 0 To arrEEWorkLines.Length - 1
							arrEEWorkLines(i)("cc_uph_tier1") = dtLine.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("cc_uph_tier1")
							arrEEWorkLines(i)("cc_uph_tier2") = dtLine.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("cc_uph_tier2")

							If arrEEWorkLines(i)("cc_desc").ToString.Trim.ToUpper = "SUPPORT" Then
								dblIndividualHrs = 0.0
								dblTeamHrs = 0.0
								dblGrpHrs = 0.0
								dblNetUPH = 0.0
								iTotalGoodUnits = 0.0

								dblIndividualHrs = arrEEWorkLines(i)("TotalTime") / 3600.0
								'dblTeamHrs = dtHrs.Compute("SUM(TotalTime)", "cc_id = " & arrEEWorkLines(i)("cc_id")) / 3600.0
								dblGrpHrs = dtHrs.Compute("SUM(TotalTime)", "Group_ID = " & arrEEWorkLines(i)("Group_ID")) / 3600.0

								iTotalGoodUnits = CInt(dtShipUnits.Select("Group_ID = " & arrEEWorkLines(i)("Group_ID"))(0)("Qty"))
								If dblGrpHrs > 0 Then dblNetUPH = iTotalGoodUnits / dblGrpHrs

								If dblNetUPH >= arrEEWorkLines(i)("cc_uph_tier2") Then
									dblPayAmt += arrEEWorkLines(i)("cc_tier2_rate") * dblIndividualHrs
								ElseIf dblNetUPH >= arrEEWorkLines(i)("cc_uph_tier1") Then
									dblPayAmt += arrEEWorkLines(i)("cc_tier1_rate") * dblIndividualHrs
								End If
							Else
								dblIndividualHrs = 0.0
								dblTeamHrs = 0.0
								dblGrpHrs = 0.0
								dblNetUPH = 0.0
								iTotalGoodUnits = 0
								iTotalAQLRejCritical = 0
								iTotalAQLRejNoneCritical = 0

								dblIndividualHrs = arrEEWorkLines(i)("TotalTime") / 3600.0
								dblTeamHrs = dtHrs.Compute("SUM(TotalTime)", "cc_id = " & arrEEWorkLines(i)("cc_id")) / 3600.0
								'dblGrpHrs = dtHrs.Compute("SUM(TotalTime)", "Group_ID = " & arrEEWorkLines(i)("Group_ID")) / 3600.0

								'Good produced
								'iTotalGoodUnits = objDBRpt.GetPassQCFuncUnits(arrEEWorkLines(i)("cc_id"), strStartDate, strEndDate)
								iTotalGoodUnits = objDBRpt.GetShipGoodUnits(arrEEWorkLines(i)("Group_ID"), strStartDate, strEndDate, arrEEWorkLines(i)("cc_id"))

								'AQL Reject
								Me.DisposeDT(dtAQLRej)
								dtAQLRej = DashBoardRpt.GetFQA_AQLReject(arrEEWorkLines(i)("cc_id"), strStartDate, strEndDate)
								iTotalAQLRejCritical = dtAQLRej.Select("Dcode_Critical = 1").Length
								iTotalAQLRejNoneCritical = dtAQLRej.Select("Dcode_Critical = 0").Length

								'Net Produced
								iTotalGoodUnits = iTotalGoodUnits - (iTotalAQLRejCritical * arrEEWorkLines(i)("cc_rcf"))
								iTotalGoodUnits = iTotalGoodUnits - (iTotalAQLRejNoneCritical * arrEEWorkLines(i)("cc_rof"))

								'Net UPH
								If dblTeamHrs > 0 Then dblNetUPH = iTotalGoodUnits / dblTeamHrs

								If dblNetUPH >= arrEEWorkLines(i)("cc_uph_tier2") Then
									dblPayAmt += arrEEWorkLines(i)("cc_tier2_rate") * dblIndividualHrs
								ElseIf dblNetUPH >= arrEEWorkLines(i)("cc_uph_tier1") Then
									dblPayAmt += arrEEWorkLines(i)("cc_tier1_rate") * dblIndividualHrs
								End If
							End If
						Next i

						If Format(dblPayAmt, "####.00") > 0 Then
							j += 1
							arrData(j, 0) = R1("EENumLegiantFormat")
							arrData(j, 1) = CDate(strEndDate)
							arrData(j, 2) = R1("DepartmentID")
							arrData(j, 3) = "Prod Pay"
							arrData(j, 4) = dblPayAmt
							strData &= R1("EENumLegiantFormat") & "," & Format(CDate(strEndDate), "MM/dd/yyyy") & "," & R1("DepartmentID") & ",Prod Pay," & Format(dblPayAmt, "#####.00") & vbCrLf
						End If
					End If
				Next R1

				'*******************************
				'post data to excel in daily section
				objSheet.Range("A" & (iRow).ToString & ":E" & (iRow + j).ToString).Value = arrData
				'*******************************
				'Center horizontal and vertical for data
				objSheet.Range("A" & (iRow).ToString, "E" & (iRow + j).ToString).HorizontalAlignment = Excel.Constants.xlCenter
				objSheet.Range("A" & (iRow).ToString, "E" & (iRow + j).ToString).VerticalAlignment = Excel.Constants.xlCenter

				'***********************************
				'Adjust column widths
				'***********************************
				For i = 0 To 4 - 1
					objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 17
				Next i

				'***********************************
				'Move selection outside the data region 
				'***********************************
				objExcel.Range("C1:C1").Select()
				'***********************************
				'Set page orientation
				'***********************************
				With objSheet.PageSetup
					.Orientation = Excel.XlPageOrientation.xlLandscape
					.LeftFooter = "** PSS Confidential **"
					.RightMargin = -15
					.LeftMargin = -15
					.FitToPagesWide = 1
					.FitToPagesTall = 1
				End With
				'***********************************
				'Set zoom
				'***********************************
				objExcel.ActiveWindow.Zoom = 100
				''***********************************
				''Save Report
				''***********************************
				'If Len(Dir("C:\IncentiveRpt.xls")) > 0 Then
				'    Kill("C:\IncentiveRpt.xls")
				'End If
				'objWorkbook.SaveAs("C:\IncentiveRpt.xls")
				'***********************************
				'print Report
				'***********************************
				'objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
				'***********************************

				If strData <> "" Then
					If Len(Dir(strRptFilePath)) > 0 Then
						Kill(strRptFilePath)
					End If
					objWriter = New StreamWriter(strRptFilePath)
					objWriter.Write(strData)
				Else
					MsgBox("No data for report.", MsgBoxStyle.Information, "Information")
				End If

			Catch ex As Exception
				Throw ex
			Finally
				objWriter.Close()
				If Not IsNothing(objWriter) Then
					objWriter = Nothing
				End If

				arrData = Nothing
				R1 = Nothing
				Me.DisposeDT(dtEE)
				Me.DisposeDT(dtLine)
				Me.DisposeDT(dtHrs)
				Me.DisposeDT(dtShipUnits)
				Me.DisposeDT(dtAQLRej)
				''*************************************
				''Excel clean up
				'If Not IsNothing(objSheet) Then
				'    NAR(objSheet)
				'End If
				'If Not IsNothing(objWorkbook) Then
				'    objWorkbook.Close(False)
				'    NAR(objWorkbook)
				'End If
				'If Not IsNothing(objExcel) Then
				'    objExcel.Quit()
				'    NAR(objExcel)
				'End If
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function
		Public Function CreateStaticCellCalsRpt(ByVal iGroup_ID As Integer, _
		  ByVal strGroupDesc As String, _
		  ByVal strStartDate As String, _
		  ByVal strEndDate As String) As Integer
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objWorkbook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
			 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim iRow As Integer = 1
			Dim iCol As Integer = 65
			Dim strCellHeaders() As String = {"CELL", "Fallout %Goal", "Actual Fallout%", "AQL2 Rejects FACTOR", "AQL1 rejects FACTOR", "Hrs Worked inCell", _
			"#Of GoodUnits OutOfCell", "#Of Ship GoodUnits OutOfCell", "Gross UPH", "#of AQL1 (Critical) Failures", "#of AQL2 (Cosmetic) Failures", "Net Units Produced", _
			"Net UPH", "Tier1 Cell UPH Goal", "Tier2 Cell UPH Goal", "Tier1 Rate", "Tier2 Rate", "Payout forCell"}
			Dim strSupHeaders() As String = {"Support Hrs", "Hrs Worked Overall", "Good Units Produced", "Net UPH", "Support Overall UPH Goal", "Incentive Rate", "Payout forCell"}
			Dim arrCellData(,) As Object
			Dim arrSupData(,) As Object
			Dim R1 As DataRow
			Dim dtLine, dtWeekInfo As DataTable
			Dim iNumOfWeekInRpt As Integer = 0
			Dim strWeekStartDate As String = ""
			Dim strWeekEndDate As String = ""
			Dim iTotalWeeks As Integer = 1

			Try
				'**************************************
				dtWeekInfo = Me.GetWeekInfo(strStartDate, strEndDate)
				'If DateDiff(DateInterval.Day, CDate(strStartDate), CDate(strEndDate)) > 7 Then iTotalWeeks = 2
				If DateDiff(DateInterval.Day, CDate(strStartDate), CDate(strEndDate)) > 7 And DateDiff(DateInterval.Day, CDate(strStartDate), Now()) >= 14 Then iTotalWeeks = 2

				'Prepare report
				objExcel = New Excel.Application()
				objExcel.Application.DisplayAlerts = False
				objWorkbook = objExcel.Workbooks.Add
				objSheet = objWorkbook.Sheets("Sheet1")
				objExcel.Visible = True
				'objSheet.Activate()
				objSheet.Name = "Cells UPH Cal"

				'write timestamp and group description as title
				objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = DashBoardRpt.GetDateTimeStamp

				'For iNumOfWeekInRpt = 1 To dtWeekInfo.Rows(0)("TotalWeeks")
				For iNumOfWeekInRpt = 1 To iTotalWeeks
					i = 0
					j = 0
					arrCellData = Nothing
					arrSupData = Nothing
					Me.DisposeDT(dtLine)

					If iNumOfWeekInRpt = 1 Then
						strWeekStartDate = strStartDate
						strWeekEndDate = Format(DateAdd(DateInterval.Day, 6, CDate(strStartDate)), "yyyy-MM-dd")
					Else
						strWeekStartDate = Format(DateAdd(DateInterval.Day, 1, CDate(strWeekEndDate)), "yyyy-MM-dd")
						strWeekEndDate = Format(DateAdd(DateInterval.Day, 7, CDate(strWeekEndDate)), "yyyy-MM-dd")
					End If

					dtLine = Me.GetStatCostCenterData(strWeekStartDate, strWeekEndDate, iGroup_ID)
					If dtLine.Rows.Count > 0 Then
						iRow += 1
						objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strGroupDesc & " Week: " & Format(CDate(strWeekStartDate), "MM/dd/yyyy") & " - " & Format(CDate(strWeekEndDate), "MM/dd/yyyy")
						iRow += 2
						objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "CELL UPH CALCULATION"
						iRow += 2

						'redefine array
						ReDim arrCellData(dtLine.Rows.Count + 1, strCellHeaders.Length)
						ReDim arrSupData(2, strSupHeaders.Length)

						'***********************************
						'Cell data
						'***********************************
						'Header production cell
						For i = 0 To strCellHeaders.Length - 1
							arrCellData(j, i) = strCellHeaders(i).Replace(" ", vbLf)
						Next i

						'Header for support
						For i = 0 To strSupHeaders.Length - 1
							arrSupData(j, i) = strSupHeaders(i).Replace(" ", vbLf)
						Next i

						For Each R1 In dtLine.Rows
							If R1("cc_desc").ToString.Trim.ToUpper = "SUPPORT" Then
								arrSupData(1, 0) = Math.Round(R1("ccsd_TeamHrs"), 2)
								arrSupData(1, 1) = Math.Round(R1("ccsd_GrpHrs"), 2)
								arrSupData(1, 2) = Math.Round(R1("ccsd_NetUP"), 2)
								arrSupData(1, 3) = Math.Round(R1("ccsd_NetUPH"), 2)
								arrSupData(1, 4) = Math.Round(R1("ccsd_Tier1UPHGoal"), 2)
								arrSupData(1, 5) = Math.Round(R1("ccsd_Tier1Rate"), 2)
								arrSupData(1, 6) = Math.Round(R1("ccsd_PayoutAmt"), 2)
							Else
								j += 1

								arrCellData(j, 0) = R1("cc_desc")
								arrCellData(j, 1) = R1("ccsd_FalloutGoalPer") & "%"
								arrCellData(j, 2) = CDbl(R1("ccsd_FalloutActPer")) / 100.0
								arrCellData(j, 3) = R1("ccsd_AQL2_Factor")
								arrCellData(j, 4) = R1("ccsd_AQL1_Factor")
								arrCellData(j, 5) = R1("ccsd_TeamHrs")
								arrCellData(j, 6) = R1("ccsd_GUPBC")
								arrCellData(j, 7) = R1("ccsd_GUP")								  'Completed units
								arrCellData(j, 8) = R1("ccsd_GrossUPH")								'Gross UPH
								arrCellData(j, 9) = R1("ccsd_AQL1")
								arrCellData(j, 10) = R1("ccsd_AQL2")
								arrCellData(j, 11) = R1("ccsd_NetUP")
								arrCellData(j, 12) = R1("ccsd_NetUPH")
								arrCellData(j, 13) = R1("ccsd_Tier1UPHGoal")
								arrCellData(j, 14) = R1("ccsd_Tier2UPHGoal")
								arrCellData(j, 15) = R1("ccsd_Tier1Rate")
								arrCellData(j, 16) = R1("ccsd_Tier2Rate")
								arrCellData(j, 17) = R1("ccsd_PayoutAmt")
							End If
						Next R1

						j += 1						  'Total
						arrCellData(j, 0) = "Total"
						arrCellData(j, 2) = "=" & dtLine.Compute("Sum(ccsd_FalloutAccUnits)", "") & "/(" & dtLine.Compute("Sum(ccsd_FalloutAccUnits)", "") & "+RC[5])"
						arrCellData(j, 3) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 4) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 5) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 6) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 7) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"						  'Completed units
						arrCellData(j, 8) = "=ROUND(RC[-1]/RC[-3],2)"						  'Gross UPH
						arrCellData(j, 9) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 10) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 11) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"
						arrCellData(j, 12) = "=ROUND(RC[-1]/RC[-7],2)"
						arrCellData(j, 17) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"

						'*******************************
						'post data to excel
						objSheet.Range("A" & iRow.ToString & ":R" & (iRow + j).ToString).Value = arrCellData

						'*******************************
						'set border
						objExcel.Range("A" & (iRow).ToString & ":R" & (iRow + j).ToString).Select()
						objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
						objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

						For i = 0 To xlBI.Length - 1
							With objExcel.Selection.Borders(xlBI(i))
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThin
								.ColorIndex = Excel.Constants.xlAutomatic
							End With
						Next i

						'*******************************
						'Center horizontal and vertical for data 
						objSheet.Range("A" & (iRow).ToString, "R" & (iRow + j).ToString).HorizontalAlignment = Excel.Constants.xlRight
						objSheet.Range("A" & (iRow).ToString, "R" & (iRow + j).ToString).VerticalAlignment = Excel.Constants.xlBottom

						'*******************************
						'Set wrap text for header
						objSheet.Range("A" & (iRow).ToString, "R" & (iRow).ToString).WrapText = True

						'*******************************
						'format Line cell
						objSheet.Range("A" & (iRow - 2).ToString, "R" & (iRow - 2).ToString).Merge()
						objSheet.Range("A" & (iRow - 2).ToString, "R" & (iRow - 2).ToString).HorizontalAlignment = Excel.Constants.xlCenter

						'*******************************
						'Title
						With objSheet.Range("A" & (iRow - 2).ToString, "A" & (iRow - 2).ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							'.Size = 14
							.Underline = True
							.ColorIndex = 25
						End With
						objSheet.Range("A" & (iRow - 4).ToString, "R" & (iRow - 4).ToString).Merge()
						With objSheet.Range("A" & (iRow - 4).ToString, "A" & (iRow - 4).ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							.Size = 14
							.Underline = True
							.ColorIndex = 25
						End With

						'*******************************
						'header
						With objSheet.Range("A" & iRow.ToString, "R" & iRow.ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							'.Size = 12
							.Underline = True
							.ColorIndex = 25
						End With
						'objSheet.Range("A" & iRow.ToString, "R" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

						'*******************************
						'Total
						With objSheet.Range("A" & (iRow + j).ToString, "R" & (iRow + j).ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							'.Size = 12
						End With

						'*******************************
						'format
						'*******************************
						objSheet.Range("C" & iRow.ToString & ":C" & (iRow + j).ToString).NumberFormat = "#,##0.00%"
						objSheet.Range("D" & iRow.ToString & ":E" & (iRow + j).ToString).NumberFormat = "#,##0"
						objSheet.Range("F" & iRow.ToString & ":F" & (iRow + j).ToString).NumberFormat = "#,##0.00"
						objSheet.Range("G" & iRow.ToString & ":H" & (iRow + j).ToString).NumberFormat = "#,##0"
						objSheet.Range("I" & iRow.ToString & ":I" & (iRow + j).ToString).NumberFormat = "#,##0.00"
						objSheet.Range("J" & iRow.ToString & ":L" & (iRow + j).ToString).NumberFormat = "#,##0"
						objSheet.Range("M" & iRow.ToString & ":Q" & (iRow + j).ToString).NumberFormat = "#,##0.00"
						objSheet.Range("R" & iRow.ToString & ":R" & (iRow + j).ToString).NumberFormat = "$#,##0.00"

						'Draw a heavier border on the left side
						objExcel.Range("A" & iRow.ToString & ":R" & (iRow + j).ToString).Select()
						With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThick
							.ColorIndex = 25
						End With
						With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThick
							.ColorIndex = 25
						End With

						'Draw a heavier border on the top & bottom edge  of total
						objExcel.Range("A" & iRow.ToString & ":R" & (iRow + j).ToString).Select()
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

						'Draw a heavier border on the top & bottom edge  of total
						objExcel.Range("A" & (iRow + j).ToString & ":R" & (iRow + j).ToString).Select()
						With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThick
							.ColorIndex = 1
						End With

						'Highlight odd row in data section
						For i = iRow + 1 To iRow + j
							objExcel.Range("A" & i.ToString & ":R" & i.ToString).Select()
							objExcel.Selection.Interior.ColorIndex = 15
							i += 1
						Next i

						iRow += j + 2

						'***********************************
						'SUPPORT SECTION
						'***********************************
						objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "SUPPORT UPH CALCULATION"
						iRow += 2

						'*******************************
						'post data to excel
						objSheet.Range("A" & iRow.ToString & ":G" & (iRow + 1).ToString).Value = arrSupData

						'*******************************
						'set border
						objExcel.Range("A" & (iRow).ToString & ":G" & (iRow + 1).ToString).Select()
						objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
						objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

						For i = 0 To xlBI.Length - 1
							With objExcel.Selection.Borders(xlBI(i))
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThin
								.ColorIndex = Excel.Constants.xlAutomatic
							End With
						Next i

						'*******************************
						'Center horizontal and vertical for data 
						objSheet.Range("A" & (iRow).ToString, "G" & (iRow + 1).ToString).HorizontalAlignment = Excel.Constants.xlRight
						objSheet.Range("A" & (iRow).ToString, "G" & (iRow + 1).ToString).VerticalAlignment = Excel.Constants.xlBottom

						'*******************************
						'Set wrap text for header
						objSheet.Range("A" & (iRow).ToString, "G" & (iRow).ToString).WrapText = True

						'*******************************
						'format Line cell
						objSheet.Range("A" & (iRow - 2).ToString, "G" & (iRow - 2).ToString).Merge()
						objSheet.Range("A" & (iRow - 2).ToString, "G" & (iRow - 2).ToString).HorizontalAlignment = Excel.Constants.xlCenter

						'*******************************
						'Title
						With objSheet.Range("A" & (iRow - 2).ToString, "A" & (iRow - 2).ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							'.Size = 14
							.Underline = True
							.ColorIndex = 25
						End With

						'*******************************
						'header
						With objSheet.Range("A" & iRow.ToString, "G" & iRow.ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							'.Size = 12
							.Underline = True
							.ColorIndex = 25
						End With
						'objSheet.Range("A" & iRow.ToString, "G" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

						'*******************************
						'Total
						With objSheet.Range("A" & (iRow + 1).ToString, "G" & (iRow + 1).ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							'.Size = 12
						End With

						'*******************************
						'format
						'*******************************
						objSheet.Range("A" & (iRow + 1).ToString & ":B" & (iRow + 1).ToString).NumberFormat = "#,##0.00"
						objSheet.Range("C" & (iRow + 1).ToString & ":C" & (iRow + 1).ToString).NumberFormat = "#,##0"
						objSheet.Range("D" & (iRow + 1).ToString & ":G" & (iRow + 1).ToString).NumberFormat = "#,##0.00"

						'*******************************
						'Draw a heavier border on the left side
						objExcel.Range("A" & iRow.ToString & ":G" & (iRow + 1).ToString).Select()
						With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThick
							.ColorIndex = 25
						End With
						With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThick
							.ColorIndex = 25
						End With

						'*******************************
						'Draw a heavier border on the top & bottom edge  of total
						objExcel.Range("A" & iRow.ToString & ":G" & (iRow + 1).ToString).Select()
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
						'Highlight odd row in support section
						objExcel.Range("A" & (iRow + 1).ToString & ":G" & (iRow + 1).ToString).Select()
						objExcel.Selection.Interior.ColorIndex = 15

						iRow += 4
					End If
				Next iNumOfWeekInRpt

				'***********************************
				'Adjust column widths
				'***********************************
				For i = 0 To strCellHeaders.Length - 1
					objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 12.43
				Next i

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
					.RightFooter = "&P of &N"
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
				objExcel.Range("C1:C1").Select()
				'***********************************
				'Delete unused worksheets
				'***********************************
				If objWorkbook.Sheets.Count > 1 Then
					For i = objWorkbook.Sheets.Count To 2 Step -1
						objWorkbook.Sheets("Sheet" & i.ToString).Delete()
					Next i
				End If
				'***********************************

			Catch ex As Exception
				Throw ex
			Finally
				xlBI = Nothing
				strCellHeaders = Nothing
				arrCellData = Nothing
				R1 = Nothing
				Me.DisposeDT(dtLine)
				Me.DisposeDT(dtWeekInfo)
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function
		Public Function CreateStaticEEStatement(ByVal strStartDate As String, _
		 ByVal strEndDate As String, _
		 ByVal strGroupIDs As String, _
		 Optional ByVal iEENo As Integer = 0, _
		 Optional ByVal strCCIDs As String = "") As Integer
			Dim objDBRpt As PSS.Data.Buisness.DashBoardRpt
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objWorkbook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
			 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

			Dim i As Integer = 0
			Dim j As Integer = 0
			Dim iRow As Integer = 1
			Dim strCellHeaders() As String = {"Group", "Area", "Individual Hours Worked", "% in Area Worked", _
			"Team Hours", "Total Hours Worked", "Good Units Produced", "Gross UPH", "AQL1 (Critical) ", _
			"AQL2 (Non-Critical) ", "Net Good Produced", "Net UPH", "Tier 1 Goal @", "Tier 2 Goal @", "% Fallout Goal <=", "% Fallout Actual", ""}
			Dim arrData(,) As Object
			Dim arrEEWorkLines() As DataRow
			Dim R1 As DataRow
			Dim dtWeekInfo, dtEEInfo, dtCCData, dtEEHrs As DataTable
			Dim booUpdHeader As Boolean = False
			Dim strTimeStamp As String
			Dim iNumOfWeekInRpt As Integer = 1
			Dim iWeek As Integer = 0
			Dim iTotalWeeks As Integer = 1

			Try
				objDBRpt = New PSS.Data.Buisness.DashBoardRpt()
				strTimeStamp = objDBRpt.GetDateTimeStamp
				dtWeekInfo = Me.GetWeekInfo(strStartDate, strEndDate)
				dtCCData = Me.GetStatCostCenterData(strStartDate, strEndDate)
				dtEEInfo = Me.GetStatEEDeptInfo(strStartDate, strEndDate, strGroupIDs, iEENo, strCCIDs)
				dtEEHrs = Me.GetStatEECellsHrsPIPAmt(strStartDate, strEndDate, iEENo)

				If DateDiff(DateInterval.Day, CDate(strStartDate), CDate(strEndDate)) > 7 And DateDiff(DateInterval.Day, CDate(strStartDate), Now()) >= 14 Then iTotalWeeks = 2

				If dtEEInfo.Rows.Count > 0 Then

					'Prepare report
					objExcel = New Excel.Application()
					objExcel.Application.DisplayAlerts = False
					objWorkbook = objExcel.Workbooks.Add
					objSheet = objWorkbook.Sheets("Sheet1")
					objExcel.Visible = True
					'objSheet.Activate()
					objSheet.Name = "Incentive Data"

					'***********************************
					'Daily section
					'***********************************
					For Each R1 In dtEEInfo.Rows
						iRow = 1

						'set all cell to be auto-fit 
						objSheet.Cells.Select()
						objSheet.Cells.Clear()
						objSheet.Cells.EntireRow.AutoFit()

						'write timestamp and group description as title
						objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strTimeStamp

						iRow += 2

						'*******************************
						objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Productivity Pay"
						objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).Merge()
						objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
						iRow += 1
						objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = Format(CDate(strStartDate), "MM/dd") & " - " & Format(CDate(strEndDate), "MM/dd")
						objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).Merge()
						objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
						With objSheet.Range("A" & (iRow - 1).ToString, "A" & iRow.ToString).Font
							.Name = "Arial"
							.FontStyle = "Bold"
							.Size = 16
							.Underline = True
							.ColorIndex = 25
						End With
						'*******************************

						' For iNumOfWeekInRpt = 1 To dtWeekInfo.Rows(0)("TotalWeeks")
						For iNumOfWeekInRpt = 1 To iTotalWeeks
							iRow += 2
							If iNumOfWeekInRpt = 1 Then
								iWeek = dtWeekInfo.Rows(0)("StartWeek")
							Else
								iWeek = dtWeekInfo.Rows(0)("EndWeek")
							End If

							'*******************************
							objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Employee#"
							objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = R1("EmployeeNo")
							objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()
							iRow += 1
							objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Name"
							objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = R1("FirstName") & " " & R1("LastName")
							objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()
							iRow += 1
							objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Home Department"
							objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = R1("DepartmentDesc")
							objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()
							iRow += 1
							If iNumOfWeekInRpt = 1 Then
								objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Week(" & iWeek & ")"
								objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = Format(CDate(strStartDate), "MM/dd") & "-" & Format(DateAdd(DateInterval.Day, 6, CDate(strStartDate)), "MM/dd")
							Else
								objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Week(" & iWeek & ")"
								objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = Format(DateAdd(DateInterval.Day, 7, CDate(strStartDate)), "MM/dd") & "-" & Format(CDate(strEndDate), "MM/dd")
							End If
							objSheet.Range("B" & iRow.ToString, "D" & iRow.ToString).Merge()

							objSheet.Range("A" & (iRow - 3).ToString & ":D" & (iRow).ToString).NumberFormat = "@"

							'Draw a heavier border on the left side
							objExcel.Range("A" & (iRow - 3).ToString & ":C" & (iRow).ToString).Select()
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With

							iRow += 1
							i = 0
							j = 0
							booUpdHeader = False
							arrEEWorkLines = dtEEHrs.Select("EmployeeNo = " & R1("EmployeeNo") & " AND cceh_WeekNum = " & iWeek)
							'***********************************
							'Cell data
							'***********************************
							'redefine array
							ReDim arrData(arrEEWorkLines.Length + 1, strCellHeaders.Length)

							'Header
							For j = 0 To strCellHeaders.Length - 1
								arrData(i, j) = strCellHeaders(j)
							Next j

							For i = 0 To arrEEWorkLines.Length - 1
								If arrEEWorkLines(i)("cc_desc").ToString.Trim.ToUpper = "SUPPORT" Then
									arrData(i + 1, 0) = arrEEWorkLines(i)("Group_Desc")
									arrData(i + 1, 1) = arrEEWorkLines(i)("cc_desc")
									arrData(i + 1, 2) = arrEEWorkLines(i)("cceh_TotalHrs")

									If Not IsDBNull(dtEEHrs.Compute("SUM(cceh_TotalHrs)", "EmployeeNo = " & R1("EmployeeNo"))) Then
										arrData(i + 1, 3) = arrEEWorkLines(i)("cceh_TotalHrs") / dtEEHrs.Compute("SUM(cceh_TotalHrs)", "EmployeeNo = " & R1("EmployeeNo") & " AND cceh_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))
									Else
										arrData(i + 1, 3) = ""
									End If

									If dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum")).Length > 0 Then
										arrData(i + 1, 4) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_TeamHrs")
										arrData(i + 1, 5) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_GrpHrs")
										arrData(i + 1, 6) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_GUP")
										'arrData(i + 1, 7) = "=IF(RC[-2]>0,RC[-1]/RC[-2],0)"
										arrData(i + 1, 7) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_GrossUPH")
										'arrData(i + 1, 11) = "=IF(RC[-6]>0,RC[-1]/RC[-6],0)"
										arrData(i + 1, 11) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_NetUPH")
									Else
										arrData(i + 1, 4) = ""
										arrData(i + 1, 5) = ""
										arrData(i + 1, 6) = ""
										arrData(i + 1, 7) = ""
										arrData(i + 1, 11) = ""
									End If

									arrData(i + 1, 8) = ""
									arrData(i + 1, 9) = ""
									arrData(i + 1, 10) = arrData(i + 1, 6)
									arrData(i + 1, 12) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_Tier1UPHGoal")
									arrData(i + 1, 13) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_Tier2UPHGoal")
									arrData(i + 1, 14) = ""
									arrData(i + 1, 15) = ""
									arrData(i + 1, 16) = arrEEWorkLines(i)("cceh_PPAmt")
									'arrData(i + 1, 16) = "=IF(RC[-5]>=RC[-3],RC[-14]*" & arrEEWorkLines(i)("cc_tier2_rate") & ",IF(RC[-5]>=RC[-4],RC[-14]*" & arrEEWorkLines(i)("cc_tier1_rate") & ",0))"
								Else
									'******************************************
									'add critical faction and payrate to header
									'******************************************
									If booUpdHeader = False Then
										If dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum")).Length > 0 Then
											arrData(0, 8) = arrData(i, 8) & "(x" & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_AQL1_Factor") & ")"
											arrData(0, 9) = arrData(i, 9) & "(x" & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_AQL2_Factor") & ")"
											arrData(0, 12) = arrData(i, 12) & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_Tier1Rate")
											arrData(0, 13) = arrData(i, 13) & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_Tier2Rate")
											booUpdHeader = True
										End If
									End If

									arrData(i + 1, 0) = arrEEWorkLines(i)("Group_Desc")
									arrData(i + 1, 1) = arrEEWorkLines(i)("cc_desc")
									arrData(i + 1, 2) = arrEEWorkLines(i)("cceh_TotalHrs")
									If dtEEHrs.Compute("SUM(cceh_TotalHrs)", "EmployeeNo = " & R1("EmployeeNo") & " AND cceh_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum")) > 0 Then
										arrData(i + 1, 3) = arrEEWorkLines(i)("cceh_TotalHrs") / dtEEHrs.Compute("SUM(cceh_TotalHrs)", "EmployeeNo = " & R1("EmployeeNo") & " AND cceh_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))
									End If

									If dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum")).Length > 0 Then
										arrData(i + 1, 4) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_TeamHrs")
										arrData(i + 1, 5) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_GrpHrs")

										'Good Units
										arrData(i + 1, 6) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_GUP")

										'arrData(i + 1, 7) = "=IF(RC[-3]>0,RC[-1]/RC[-3],0)"
										arrData(i + 1, 7) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_GrossUPH")

										'AQL Reject
										arrData(i + 1, 8) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_AQL1")
										arrData(i + 1, 9) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_AQL2")

										arrData(i + 1, 10) = "=RC[-4] - (RC[-2] * " & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_AQL1_Factor") & ") - (RC[-1] * " & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_AQL2_Factor") & ")"

										'arrData(i + 1, 11) = "=IF(RC[-7]>0,RC[-1]/RC[-7],0)"
										arrData(i + 1, 11) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_NetUPH")

										arrData(i + 1, 12) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_Tier1UPHGoal")
										arrData(i + 1, 13) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_Tier2UPHGoal")
										arrData(i + 1, 14) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_FalloutGoalPer") / 100
										arrData(i + 1, 15) = dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id") & " AND ccsd_WeekNum = " & arrEEWorkLines(i)("cceh_WeekNum"))(0)("ccsd_FalloutActPer") / 100
										arrData(i + 1, 16) = arrEEWorkLines(i)("cceh_PPAmt")
										'arrData(i + 1, 16) = "=IF(RC[-5]>=RC[-3],RC[-14]*" & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("ccsd_Tier2Rate") & ",IF(RC[-5]>=RC[-4],RC[-14]*" & dtCCData.Select("cc_id = " & arrEEWorkLines(i)("cc_id"))(0)("ccsd_Tier1Rate") & ",0))"
									Else
										arrData(i + 1, 4) = ""
										arrData(i + 1, 5) = ""
										arrData(i + 1, 6) = ""
										arrData(i + 1, 7) = ""
										'AQL Reject
										arrData(i + 1, 8) = ""
										arrData(i + 1, 9) = ""
										arrData(i + 1, 10) = ""
										arrData(i + 1, 11) = ""
										arrData(i + 1, 12) = ""
										arrData(i + 1, 13) = ""
										arrData(i + 1, 14) = ""
										arrData(i + 1, 15) = ""
										arrData(i + 1, 16) = ""
									End If
								End If
							Next i

							arrData(i + 1, 1) = "Total"
							arrData(i + 1, 2) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
							arrData(i + 1, 3) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
							arrData(i + 1, 8) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
							arrData(i + 1, 9) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
							arrData(i + 1, 16) = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"

							'*******************************
							'post data to excel in daily section
							objSheet.Range("A" & iRow.ToString & ":Q" & (iRow + i + 1).ToString).Value = arrData
							'*******************************
							'set border
							objExcel.Range("A" & (iRow).ToString & ":Q" & (iRow + i + 1).ToString).Select()
							objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
							objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

							For j = 0 To xlBI.Length - 1
								With objExcel.Selection.Borders(xlBI(j))
									.LineStyle = Excel.XlLineStyle.xlContinuous
									.Weight = Excel.XlBorderWeight.xlThin
									.ColorIndex = Excel.Constants.xlAutomatic
								End With
							Next j
							'*******************************
							'Center horizontal and vertical for data
							objSheet.Range("A" & (iRow).ToString, "Q" & (iRow + i + 1).ToString).HorizontalAlignment = Excel.Constants.xlCenter
							objSheet.Range("A" & (iRow).ToString, "Q" & (iRow + i + 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
							'*******************************
							'Header
							objSheet.Range("A" & (iRow).ToString, "Q" & (iRow).ToString).WrapText = True
							With objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).Font
								.Name = "Arial"
								.FontStyle = "Bold"
								.Size = 8
								.Underline = True
								.ColorIndex = 25
							End With
							objSheet.Range("A" & iRow.ToString, "Q" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
							objSheet.Rows(iRow.ToString & ":" & iRow.ToString).EntireRow.AutoFit()
							objSheet.Rows(iRow.ToString & ":" & iRow.ToString).RowHeight = 48
							'*******************************
							'Data
							With objSheet.Range("A" & (iRow + 1).ToString, "Q" & (iRow + i).ToString).Font
								.Name = "Arial"
								.Size = 8
							End With
							'*******************************
							'Total
							With objSheet.Range("A" & (iRow + i + 1).ToString, "Q" & (iRow + i + 1).ToString).Font
								.Name = "Arial"
								.FontStyle = "Bold"
								.Size = 8
							End With

							'*******************************
							'format
							'*******************************
							objSheet.Range("C" & (iRow - 1).ToString & ":C" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
							objSheet.Range("D" & (iRow - 1).ToString & ":D" & (iRow + i + 1).ToString).NumberFormat = "#,##0%"
							objSheet.Range("E" & (iRow - 1).ToString & ":F" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
							objSheet.Range("G" & (iRow - 1).ToString & ":G" & (iRow + i + 1).ToString).NumberFormat = "#,##0"
							objSheet.Range("H" & (iRow - 1).ToString & ":H" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
							objSheet.Range("I" & (iRow - 1).ToString & ":K" & (iRow + i + 1).ToString).NumberFormat = "#,##0"
							objSheet.Range("L" & (iRow - 1).ToString & ":N" & (iRow + i + 1).ToString).NumberFormat = "#,##0.00"
							objSheet.Range("O" & (iRow - 1).ToString & ":P" & (iRow + i + 1).ToString).NumberFormat = "#,##0%"
							objSheet.Range("Q" & (iRow - 1).ToString & ":Q" & (iRow + i + 1).ToString).NumberFormat = "$#,##0.00"

							'Draw a heavier border on the left side
							objExcel.Range("A" & iRow.ToString & ":Q" & (iRow + i + 1).ToString).Select()
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With
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

							'Draw a heavier border on the top & bottom edge  of total
							objExcel.Range("A" & (iRow + i + 1).ToString & ":Q" & (iRow + i + 1).ToString).Select()
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With

							iRow += i + 1

						Next iNumOfWeekInRpt

						iRow += 4

						'*******************************
						'2Weeks Total
						If dtWeekInfo.Rows(0)("TotalWeeks") > 1 Then
							objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Productivity Pay Total:"
							objSheet.Range("A" & iRow.ToString, "O" & iRow.ToString).Merge()
							objSheet.Range("A" & iRow.ToString, "O" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlRight
							objSheet.Range("P" & iRow.ToString & ":P" & iRow.ToString).Value = dtEEHrs.Compute("SUM(cceh_PPAmt)", "EmployeeNo = " & R1("EmployeeNo"))
							objSheet.Range("P" & iRow.ToString, "Q" & iRow.ToString).Merge()
							objSheet.Range("P" & iRow.ToString, "Q" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlRight
							'font
							With objSheet.Range("A" & (iRow).ToString, "Q" & (iRow).ToString).Font
								.Name = "Arial"
								.FontStyle = "Bold"
								.Size = 16
							End With
							objSheet.Range("P" & (iRow).ToString & ":P" & (iRow).ToString).NumberFormat = "$#,##0.00"

							'Draw a heavier border box around 2weeks total
							objExcel.Range("P" & iRow.ToString & ":Q" & (iRow).ToString).Select()
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With
							With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With
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
						End If

						'***********************************
						'Adjust column widths
						'***********************************
						For j = 0 To strCellHeaders.Length - 1
							If j = 0 Then
								objSheet.Columns(Chr(65 + j) & ":" & Chr(65 + j)).ColumnWidth = 17
							Else
								objSheet.Columns(Chr(65 + j) & ":" & Chr(65 + j)).ColumnWidth = 6.5
							End If
						Next j

						'***********************************
						'Move selection outside the data region 
						'***********************************
						objExcel.Range("C1:C1").Select()
						'***********************************
						'Set page orientation
						'***********************************
						With objSheet.PageSetup
							.Orientation = Excel.XlPageOrientation.xlLandscape
							.LeftFooter = "** PSS Confidential **"
							.RightMargin = -25
							.LeftMargin = -25
							.FitToPagesWide = 1
							.FitToPagesTall = 1
						End With
						'***********************************
						'Set zoom
						'***********************************
						objExcel.ActiveWindow.Zoom = 90
						''***********************************
						''Save Report
						''***********************************
						'If Len(Dir("C:\IncentiveRpt.xls")) > 0 Then
						'    Kill("C:\IncentiveRpt.xls")
						'End If
						'objWorkbook.SaveAs("C:\IncentiveRpt.xls")
						'***********************************
						'print Report
						'***********************************
						objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
						'***********************************
					Next R1
				End If
			Catch ex As Exception
				Throw ex
			Finally
				xlBI = Nothing
				strCellHeaders = Nothing
				arrData = Nothing
				arrEEWorkLines = Nothing
				R1 = Nothing
				If Not IsNothing(dtEEInfo) Then
					dtEEInfo.Dispose()
					dtEEInfo = Nothing
				End If
				If Not IsNothing(dtEEHrs) Then
					dtEEHrs.Dispose()
					dtEEHrs = Nothing
				End If
				If Not IsNothing(dtCCData) Then
					dtCCData.Dispose()
					dtCCData = Nothing
				End If
				If Not IsNothing(dtWeekInfo) Then
					dtWeekInfo.Dispose()
					dtWeekInfo = Nothing
				End If
				'*************************************
				'Excel clean up
				If Not IsNothing(objSheet) Then
					NAR(objSheet)
				End If
				If Not IsNothing(objWorkbook) Then
					objWorkbook.Close(False)
					NAR(objWorkbook)
				End If
				If Not IsNothing(objExcel) Then
					objExcel.Quit()
					NAR(objExcel)
				End If
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function
		Public Function CreateStaticProdIncPayRpt(ByVal strStartDate As String, _
		   ByVal strEndDate As String, _
		   ByVal strGroupIDs As String) As Integer
			Dim strHeaders() As String = {"Employee ID", "Date", "Dept", "Pay Type", "Pay Group ID", "Amt"}
			Dim strRptFilePath As String = ""
			Dim i As Integer = 0
			Dim R1 As DataRow
			Dim dtEE As DataTable
			Dim strData As String
			Dim objWriter As StreamWriter
			Dim SaveFileDialog1 As SaveFileDialog

			Try
				dtEE = Me.GetStatEEPIPAmt(strStartDate, strEndDate, strGroupIDs)
				If dtEE.Rows.Count > 0 Then
					'write header
					For i = 0 To strHeaders.Length - 1
						strData &= strHeaders(i) & ","
					Next i

					strData &= vbCrLf

					For Each R1 In dtEE.Rows
						strData &= R1("Employee ID") & "," & R1("Date") & "," & R1("Dept") & ",Prod Pay," & R1("Pay Group ID") & ", " & R1("Amt") & vbCrLf
					Next R1

					If strData <> "" Then
						SaveFileDialog1 = New SaveFileDialog()
						SaveFileDialog1.FileName = "Productivity Pay " & Format(CDate(strStartDate), "MM-dd") & " to " & Format(CDate(strEndDate), "MM-dd") & ".csv"

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
						End If
					Else
						MsgBox("No data for report.", MsgBoxStyle.Information, "Information")
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

				objWriter.Close()
				If Not IsNothing(objWriter) Then
					objWriter = Nothing
				End If
				R1 = Nothing
				Me.DisposeDT(dtEE)
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function
		Public Function GetTotalWrkHrByDateRange(ByVal strFrDate As String, _
		  ByVal strToDate As String, _
		  Optional ByVal iGroup_ID As Integer = 0) As DataTable
			Dim strSql As String = ""
			Dim dtData As DataTable

			Try
				strSql = "SELECT distinct tcostcenter.cc_rcf, tcostcenter.cc_rof, " & Environment.NewLine
				'strSql &= "tcostcenter.cc_uph_tier1, tcostcenter.cc_uph_tier2, " & Environment.NewLine
				strSql &= "tcostcenter.cc_tier1_rate, tcostcenter.cc_tier2_rate, " & Environment.NewLine
				strSql &= "tcostcenter.cc_desc, cc_failLimitPercent, " & Environment.NewLine
				strSql &= "lgroups.Group_ID, lgroups.Group_Desc, " & Environment.NewLine
				strSql &= "tpunch.cc_id, tpunch.EmployeeNo, " & Environment.NewLine
				strSql &= "SUM( (HOUR(if(OutTime is null, now(), OutTime)) - HOUR(InTime) ) * 3600 + (MINUTE(if(OutTime is null, now(), OutTime)) - MINUTE(InTime)) * 60 + (SECOND(if(OutTime is null, now(), OutTime)) - SECOND(Intime)) )  as TotalTime " & Environment.NewLine
				strSql &= "FROM tpunch " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter on tpunch.cc_id = tcostcenter.cc_id  " & Environment.NewLine
				strSql &= "INNER JOIN lgroups ON tcostcenter.Group_ID = lgroups.Group_ID " & Environment.NewLine
				strSql &= "WHERE tpunch.punch_wkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "'" & Environment.NewLine
				If iGroup_ID > 0 Then
					strSql &= "AND tcostcenter.Group_ID = " & iGroup_ID & Environment.NewLine
				End If
				strSql &= "GROUP BY tpunch.cc_id, tpunch.EmployeeNo " & Environment.NewLine
				strSql &= "ORDER BY tpunch.cc_id;"
				dtData = Me._objDataProc.GetDataTable(strSql)
				Return dtData
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dtData) Then
					dtData.Dispose()
					dtData = Nothing
				End If
			End Try
		End Function
		Public Function GetEEDeptInfoByWrkDate(ByVal strFrDate As String, _
		 ByVal strToDate As String, _
		 Optional ByVal strGroupIDs As String = "", _
		 Optional ByVal iEENo As Integer = 0) As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT DISTINCT A.EmployeeNo, C.LastName, C.FirstName, C.ShiftID, C.EENumLegiantFormat, C.DepartmentID, D.DepartmentDesc " & Environment.NewLine
				strSql &= "FROM tpunch A " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter B ON A.cc_id = B.cc_id " & Environment.NewLine
				strSql &= "INNER JOIN security.tlegianteedata C ON A.EmployeeNo = C.EmployeeNum " & Environment.NewLine
				strSql &= "INNER JOIN security.tlegiantdeptdata D ON C.DepartmentID = D.DepartmentID " & Environment.NewLine
				strSql &= "WHERE A.punch_wkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
				If strGroupIDs.Trim.Length > 0 Then
					strSql &= "AND B.Group_ID IN ( " & strGroupIDs & ") " & Environment.NewLine
				End If
				If iEENo > 0 Then
					strSql &= "AND A.EmployeeNo = " & iEENo & Environment.NewLine
				End If

				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetShipGoodUnitsGroupCnt(ByVal strFrDate As String, _
		   ByVal strToDate As String) As DataTable
			Dim strSql As String

			Try
				strSql = "SELECT tcostcenter.Group_ID, count(*) as Qty " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
				strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_ShipWorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
				strSql &= "AND tpallett.Pallet_ShipType not in (1,2,8,9,10) " & Environment.NewLine
				strSql &= "AND tcostcenter.group_id <> 1 " & Environment.NewLine
				strSql &= "GROUP BY tcostcenter.group_id " & Environment.NewLine
				strSql &= "UNION "
				strSql &= "SELECT tcostcenter.Group_ID, count(*) as Qty " & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
				strSql &= "WHERE tdevice.Device_ShipWorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
				strSql &= "AND tdevice.Ship_ID <> 9999919 " & Environment.NewLine
				strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
				strSql &= "AND tcostcenter.group_id = 1 " & Environment.NewLine
				strSql &= "GROUP BY tcostcenter.group_id " & Environment.NewLine

				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetScrapAndDBRUnitsOfCells(ByVal strFrDate As String, _
		   ByVal strToDate As String) As DataTable
			Dim strSql As String
			Dim dt1, dt2 As DataTable
			Dim R1 As DataRow

			Try
				strSql = "SELECT DISTINCT tdevice.cc_id, 0 as cnt " & Environment.NewLine
				strSql &= "FROM tdevice  " & Environment.NewLine
				strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
				strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
				strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
				strSql &= "WHERE BillCode_Rule IN ( 1, 2, 8, 9) " & Environment.NewLine
				strSql &= "AND tdevicebill.Date_Rec BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
				strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
				dt1 = Me._objDataProc.GetDataTable(strSql)

				For Each R1 In dt1.Rows
					strSql = "SELECT DISTINCT tdevice.Device_ID " + Environment.NewLine
					strSql += "FROM tdevice  " + Environment.NewLine
					strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
					strSql += "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " + Environment.NewLine
					strSql += "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " + Environment.NewLine
					strSql += "WHERE tdevice.cc_id = " + R1("cc_id").ToString + Environment.NewLine
					strSql += "AND BillCode_Rule IN ( 1, 2, 8, 9) " + Environment.NewLine
					strSql += "AND tdevicebill.Date_Rec BETWEEN '" + strFrDate + "' AND '" + strToDate + "' " + Environment.NewLine
					strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
					dt2 = Me._objDataProc.GetDataTable(strSql)

					R1.BeginEdit()
					R1("cnt") = dt2.Rows.Count
					R1.EndEdit()
					dt1.AcceptChanges()
				Next R1

				Return dt1
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				If Not IsNothing(dt2) Then
					dt2.Dispose()
					dt2 = Nothing
				End If
			End Try
		End Function
		Public Function GetStatCostCenterData(ByVal strStartDate As String, _
		  ByVal strEndDate As String, _
		  Optional ByVal iGroupID As Integer = 0) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT lgroups.group_desc, tcostcenter.cc_desc, tcc_statdata.* " & Environment.NewLine
				strSql &= "FROM tcc_statdata  " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter ON tcc_statdata.cc_id = tcostcenter.cc_id " & Environment.NewLine
				strSql &= "INNER JOIN lgroups ON tcostcenter.group_id = lgroups.group_id " & Environment.NewLine
				strSql &= "WHERE ccsd_StartDate >= '" & strStartDate & "' " & Environment.NewLine
				strSql &= "AND ccsd_EndDate <= '" & strEndDate & "' " & Environment.NewLine
				If iGroupID > 0 Then
					strSql &= "AND tcostcenter.group_id = " & iGroupID & Environment.NewLine
				End If
				strSql &= "ORDER BY lgroups.group_id, tcostcenter.cc_desc" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetStatEEDeptInfo(ByVal strStartDate As String, _
		 ByVal strEndDate As String, _
		 Optional ByVal strGroupIDs As String = "", _
		 Optional ByVal iEENo As Integer = 0, _
		 Optional ByVal strCCIDs As String = "") As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT DISTINCT A.EmployeeNo " & Environment.NewLine
				strSql &= ", B.LastName, B.FirstName, B.ShiftID " & Environment.NewLine
				strSql &= ", C.DepartmentDesc " & Environment.NewLine
				strSql &= "FROM tcc_stateehrs A " & Environment.NewLine
				strSql &= "INNER JOIN security.tlegianteedata B ON A.EmployeeNo = B.EmployeeNum " & Environment.NewLine
				strSql &= "INNER JOIN security.tlegiantdeptdata C ON B.DepartmentID = C.DepartmentID " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter D ON A.cc_id = D.cc_id " & Environment.NewLine
				strSql &= "WHERE A.cceh_StartDate >= '" & strStartDate & "' " & Environment.NewLine
				strSql &= "AND A.cceh_EndDate <= '" & strEndDate & "' " & Environment.NewLine
				strSql &= "AND A.EmployeeNo > 20 " & Environment.NewLine
				If strGroupIDs.Trim.Length > 0 Then strSql &= "AND D.group_id IN (" & strGroupIDs & ")" & Environment.NewLine
				If iEENo > 0 Then strSql &= "AND A.EmployeeNo = " & iEENo & Environment.NewLine
				If strCCIDs.Trim.Length > 0 Then strSql &= "AND A.cc_id IN ( " & strCCIDs & " )" & Environment.NewLine
				strSql &= "ORDER BY A.EmployeeNo " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetStatEECellsHrsPIPAmt(ByVal strStartDate As String, _
		 ByVal strEndDate As String, _
		 Optional ByVal iEENo As Integer = 0) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT C.Group_Desc, B.cc_desc, A.* " & Environment.NewLine
				strSql &= "FROM tcc_stateehrs A " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter B ON A.cc_id = B.cc_id " & Environment.NewLine
				strSql &= "INNER JOIN lgroups C ON B.group_id = C.group_id " & Environment.NewLine
				strSql &= "WHERE A.cceh_StartDate >= '" & strStartDate & "' " & Environment.NewLine
				strSql &= "AND A.cceh_EndDate <= '" & strEndDate & "' " & Environment.NewLine
				If iEENo > 0 Then
					strSql &= "AND A.EmployeeNo = " & iEENo & Environment.NewLine
				End If
				strSql &= "ORDER BY A.cceh_WeekNum, A.EmployeeNo " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetWeekInfo(ByVal strStartDate As String, _
		 ByVal strEndDate As String) As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT week('" & strStartDate & "',3) AS StartWeek " & Environment.NewLine
				strSql &= ", week('" & strEndDate & "',3) AS EndWeek " & Environment.NewLine
				strSql &= ", week(now(), 3) AS ThisWeek " & Environment.NewLine
				strSql &= ", if((week(now(),3) - week('" & strStartDate & "',3) ) > 1, 2, 1) as TotalWeeks;"

				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetStatEEPIPAmt(ByVal strStartDate As String, _
		  ByVal strEndDate As String, _
		  Optional ByVal strGroupIDs As String = "") As DataTable
			Dim strSql As String = ""

			Try
				strSql = "SELECT B.EENumLegiantFormat AS 'Employee ID' " & Environment.NewLine
				strSql &= ", DATE_FORMAT( '" & strEndDate & "', '%m/%d/%Y') AS 'Date' " & Environment.NewLine
				strSql &= ", B.DepartmentID as Dept " & Environment.NewLine
				strSql &= ", 'Prod Pay' AS 'Pay Type' " & Environment.NewLine
				strSql &= ", B.PayGroupID AS 'Pay Group ID' " & Environment.NewLine
				strSql &= ", sum(A.cceh_PPAmt) AS Amt " & Environment.NewLine
				strSql &= "FROM tcc_stateehrs A " & Environment.NewLine
				strSql &= "INNER JOIN security.tlegianteedata B ON A.EmployeeNo = B.EmployeeNum " & Environment.NewLine
				strSql &= "INNER JOIN tcostcenter C ON A.cc_id = C.cc_id " & Environment.NewLine
				strSql &= "WHERE A.EmployeeNo > 300 " & Environment.NewLine				'Temporary badge
				strSql &= "AND A.cceh_StartDate >= '" & strStartDate & "' " & Environment.NewLine
				strSql &= "AND A.cceh_EndDate <= '" & strEndDate & "' " & Environment.NewLine
				If strGroupIDs.Trim.Length > 0 Then
					strSql &= "AND C.group_id IN ( " & strGroupIDs & ") " & Environment.NewLine
				End If
				strSql &= "GROUP BY A.EmployeeNo " & Environment.NewLine
				strSql &= "HAVING Amt > 0 " & Environment.NewLine
				strSql &= "ORDER BY B.EmployeeNum " & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSql)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
	End Class
End Namespace
