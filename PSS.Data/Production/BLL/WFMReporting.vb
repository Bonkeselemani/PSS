Imports System.Text
Imports PSS.Data.Buisness.Generic

Namespace BLL

	Public Class WFMReporting

#Region "DECLARATIONS"

		Private _cust_id = 2597
		Private _loc_id = 3402

#End Region

		Private Sub RunBoxLocationReport()
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _xl As New Data.ExcelReports(True)
			Dim _repName As String = "Box Locations"
			_dt = GetBoxLocationData()
			_xl.RunSimpleXlAndOpen(_dt, _repName)
		End Sub

		Public Function GetBoxLocationData() As DataTable
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			_sb.Append("SELECT ")
			_sb.Append("d.device_id, ")
			_sb.Append("CONCAT('''', itm.sn) as sn, ")
			_sb.Append("d.device_daterec, ")
			_sb.Append("m.Model_Desc, ")
			_sb.Append("wb.box_na, ")
			_sb.Append("wb.quantity, ")
			_sb.Append("bins.bin_na, ")
			_sb.Append("co.workstation, ")
			_sb.Append("co.workstationentrydt, ")
			_sb.Append("d.device_dateship ")
			_sb.Append("FROM ")
			_sb.Append("edi.titem itm ")
			_sb.Append("inner join tdevice d on itm.Device_ID = d.device_id ")
			_sb.Append("left join warehouse.wh_box wb on itm.whb_id = wb.whb_id ")
			_sb.Append("left join tmodel m on d.model_id = m.model_id ")
			_sb.Append("left join tcellopt co on d.device_id = co.device_id ")
			_sb.Append("left join warehouse.wh_bins bins on wb.bin_id = bins.bin_id ")
			_sb.Append("WHERE ")
			_sb.Append("d.Loc_ID = " & _loc_id & " ")
			_sb.Append("AND ")
			_sb.Append("d.device_dateship IS NULL ")
			_sb.Append("ORDER BY d.device_daterec; ")
			_dt = _objDataProc.GetDataTable(_sb.ToString())
			_objDataProc = Nothing
			_sb = Nothing
			Return _dt
		End Function

		Public Function GetWFMWIPSummaryData()
			Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Dim _dt As New DataTable()
			Dim strSql As String
			strSql = "SELECT" & Environment.NewLine
			strSql &= " m.Model_Desc," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'WH-PRE-TRIAGE' THEN 1 ELSE 0 END) AS PRE_TRIAGE," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'TRIAGE-STAGING' THEN 1 ELSE 0 END) AS TRIAGE_STAGING," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'TRIAGE' and ISNULL(trg.dt_id) THEN 1 ELSE 0 END) AS TRIAGE," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'TRIAGE-BOXING' THEN 1 ELSE 0 END) AS BOX," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'AQL' THEN 1 ELSE 0 END) AS AQL," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'PRODUCE' THEN 1 ELSE 0 END) AS PRODUCE," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'WH-FLOOR' AND disp.disp_cd = 'NTF' AND d.device_laborcharge >0 AND p.pallet_qc_passed=1 THEN 1 ELSE 0 END) AS NTF," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'WH-FLOOR' AND disp.disp_cd = 'COS' AND d.device_laborcharge >0 THEN 1 ELSE 0 END) AS COS," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'WH-FLOOR' AND disp.disp_cd = 'FUN' AND d.device_laborcharge >0 THEN 1 ELSE 0 END) AS FUN," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'WH-FLOOR' AND disp.disp_cd = 'SOF' AND d.device_laborcharge >0 THEN 1 ELSE 0 END) AS SOF," & Environment.NewLine
			strSql &= " 0 AS Total,COUNT(*) AS TOTALCOUNT," & Environment.NewLine
			strSql &= " SUM(CASE WHEN (co.workstation = 'WH-FLOOR' AND (disp.disp_cd = 'NTF' OR disp.disp_cd = 'COS' OR disp.disp_cd = 'FUN' OR disp.disp_cd = 'SOF')" & Environment.NewLine
			strSql &= " AND Not d.device_laborcharge >0 AND (d.pallett_id >0 OR wb.whb_id >0) )" & Environment.NewLine
			strSql &= " OR (co.workstation = 'TRIAGE' AND trg.dt_id IS Not Null) OR (co.workstation = 'WH-FLOOR' AND p.pallet_qc_passed<>1) THEN 1 ELSE 0 END) AS AbnormalBox," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation = 'WH-FLOOR' AND (disp.disp_cd = 'NTF' OR disp.disp_cd = 'COS' OR disp.disp_cd = 'FUN' OR disp.disp_cd = 'SOF')" & Environment.NewLine
			strSql &= " AND Not d.device_laborcharge >0 AND (d.pallett_id >0 OR wb.whb_id >0)  THEN 1 ELSE 0 END) AS AbnormalWHFloor," & Environment.NewLine
			strSql &= " SUM(CASE WHEN co.workstation Not IN ('WH-PRE-TRIAGE','TRIAGE-STAGING','TRIAGE','TRIAGE-BOXING','AQL','PRODUCE','WH-FLOOR')  OR co.workstation IS NULL THEN 1 ELSE 0 END) AS OtherWS_NoWS" & Environment.NewLine
			strSql &= " FROM tcustomer c" & Environment.NewLine
			strSql &= " INNER JOIN tcustmodel_pssmodel_map map on c.cust_id = map.cust_id" & Environment.NewLine
			strSql &= " INNER JOIN tmodel m on map.model_id = m.model_id" & Environment.NewLine
			strSql &= " INNER JOIN tdevice d on m.model_id = d.model_id" & Environment.NewLine
			strSql &= " INNER JOIN edi.titem itm on d.device_id = itm.device_id" & Environment.NewLine
            strSql &= " INNER JOIN production.ttf_bx_phn_received rec on d.device_sn = rec.serial_nr" & Environment.NewLine
            strSql &= " LEFT JOIN production.tdevice_triage trg on d.device_id = trg.device_id" & Environment.NewLine
            strSql &= " LEFT JOIN production.tfailcodes fc on trg.fc_id = fc.fc_id" & Environment.NewLine
            strSql &= " LEFT JOIN tcellopt co on d.device_id = co.device_id" & Environment.NewLine
            strSql &= " LEFT JOIN tdispositions disp on trg.disp_id = disp.disp_id" & Environment.NewLine
            strSql &= " LEFT JOIN tpallett p on d.Pallett_ID=p.Pallett_ID" & Environment.NewLine
            strSql &= " LEFT JOIN warehouse.wh_box wb on itm.whb_id=wb.whb_id" & Environment.NewLine
            strSql &= " WHERE c.cust_id = 2597" & Environment.NewLine
            strSql &= " GROUP BY m.model_desc;" & Environment.NewLine
            _dt = _objDataProc.GetDataTable(strSql)

            RemoveWFM2TFCosFunDeviceCount(_dt)

			Dim _dr As DataRow, col As DataColumn
			Dim iSum As Integer = 0
			For Each _dr In _dt.Rows
				_dr.BeginEdit()
				_dr("Total") = _dr("PRE_TRIAGE") + _dr("TRIAGE_STAGING") + _dr("TRIAGE") + _dr("BOX") + _dr("AQL") + _dr("PRODUCE") + _dr("NTF") + _dr("COS") + _dr("FUN") + _dr("SOF")
				_dr.AcceptChanges()
			Next
			If _dt.Rows.Count > 0 Then
				Dim strFieldName As String = ""
				Dim j As Integer = 0
				Dim _drNew As DataRow = _dt.NewRow
				For Each col In _dt.Columns
					strFieldName = col.ColumnName
					If strFieldName.ToUpper = "model_desc".ToUpper Then
						_drNew("model_desc") = "  TOTAL"
					Else
						iSum = Convert.ToInt32(_dt.Compute("SUM([" & strFieldName & "])", String.Empty))
						_drNew.Item(j) = iSum
					End If
					j += 1
				Next
				_dt.Rows.Add(_drNew)
			End If
			_objDataProc = Nothing
			_dt.Columns.Remove("TOTALCOUNT") : _dt.Columns.Remove("AbnormalBox")
			_dt.Columns.Remove("AbnormalWHFloor") : _dt.Columns.Remove("OtherWS_NoWS")
			Return _dt
		End Function

        Private Function RemoveWFM2TFCosFunDeviceCount(ByRef dt As DataTable) As Integer
            Dim row1, row2 As DataRow
            Dim strSql As String
            Dim dt2, dt3 As DataTable
            Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            'SOF,COS,FUN
            strSql = "select G.disp_ID,H.Model_Desc as 'WFM_Model',Count(*) as Qty" & Environment.NewLine
            strSql &= " from tdevice A" & Environment.NewLine
            strSql &= " inner join edi.titem B on A.Device_ID=B.Device_ID" & Environment.NewLine
            strSql &= " inner join tmodel C on A.Model_ID=C.Model_ID" & Environment.NewLine
            strSql &= " left join edi.titem F on B.SN=F.SN and F.whb_ID is not null" & Environment.NewLine
            strSql &= " left join warehouse.wh_box G on F.whb_id=G.whb_id" & Environment.NewLine
            strSql &= " left join tmodel H on G.Model_ID=H.Model_ID" & Environment.NewLine
            strSql &= " where  loc_ID=2946 and B.IsWFM=1" & Environment.NewLine
            strSql &= " group by G.disp_ID,WFM_Model;" & Environment.NewLine

            dt2 = _objDataProc.GetDataTable(strSql)

            For Each row2 In dt2.Rows
                If Not row2.IsNull("disp_id") AndAlso Not row2.IsNull("WFM_Model") Then
                    For Each row1 In dt.Rows
                        If row2("disp_id") = 4 AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("COS") = row1("COS") - row2("Qty")
                            Try
                                If row1("COS") < 0 Then row1("COS") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        ElseIf row2("disp_id") = 3 AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("FUN") = row1("FUN") - row2("Qty")
                            Try
                                If row1("FUN") < 0 Then row1("FUN") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        ElseIf row2("disp_id") = 2 AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("SOF") = row1("SOF") - row2("Qty")
                            Try
                                If row1("SOF") < 0 Then row1("SOF") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        End If
                    Next
                End If
            Next

            'TRIAGE,TRIAGE-STAGING,WH-PRE-TRIAGE
            strSql = "select D.model_desc as 'WFM_Model',E.Workstation,count(*) as 'Qty'" & Environment.NewLine
            strSql &= " from edi.titem A" & Environment.NewLine
            strSql &= " inner join edi.titem B on A.SN=B.SN and A.isWFM =1 and B.IsWFM=0" & Environment.NewLine
            strSql &= " inner join tdevice C on B.device_ID=C.device_ID and  B.IsWFM=0" & Environment.NewLine
            strSql &= " Inner join tmodel D on C.model_ID=D.model_ID" & Environment.NewLine
            strSql &= " inner join tcellopt E on C.device_ID=E.device_ID" & Environment.NewLine
            strSql &= " where E.Workstation in ( 'TRIAGE','TRIAGE-STAGING','WH-PRE-TRIAGE')" & Environment.NewLine
            strSql &= " group by D.model_desc,E.Workstation;" & Environment.NewLine

            dt3 = _objDataProc.GetDataTable(strSql)

            For Each row2 In dt3.Rows
                If Not row2.IsNull("Workstation") AndAlso Not row2.IsNull("WFM_Model") Then
                    For Each row1 In dt.Rows
                        If Trim(row2("Workstation")).ToUpper = "TRIAGE".ToUpper AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("TRIAGE") = row1("TRIAGE") - row2("Qty")
                            Try
                                If row1("TRIAGE") < 0 Then row1("TRIAGE") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        ElseIf Trim(row2("Workstation")).ToUpper = "TRIAGE-STAGING".ToUpper AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("TRIAGE_STAGING") = row1("TRIAGE_STAGING") - row2("Qty")
                            Try
                                If row1("TRIAGE_STAGING") < 0 Then row1("TRIAGE_STAGING") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        ElseIf Trim(row2("Workstation")).ToUpper = "WH-PRE-TRIAGE".ToUpper AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("PRE_TRIAGE") = row1("PRE_TRIAGE") - row2("Qty")
                            Try
                                If row1("PRE_TRIAGE") < 0 Then row1("PRE_TRIAGE") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        End If
                    Next
                End If
            Next

            'NTF
            strSql = " select D.disp_id,C.Model_Desc as 'WFM_Model',Count(*) as Qty" & Environment.NewLine
            strSql &= "  from edi.titem A" & Environment.NewLine
            strSql &= "  inner join tdevice B on A.device_id = B.device_id" & Environment.NewLine
            strSql &= "  inner join tmodel C on B.model_id=C.model_ID" & Environment.NewLine
            strSql &= "  inner join tpallett D on B.pallett_id=D.pallett_id" & Environment.NewLine
            strSql &= "  inner join production.tdispositions E on D.disp_id=E.disp_id" & Environment.NewLine
            strSql &= "  inner join tcellopt F on B.device_id = F.device_id" & Environment.NewLine
            strSql &= "  inner join tdevice G on B.Device_SN=G.Device_SN and G.loc_ID=2946" & Environment.NewLine
            strSql &= "  where D.disp_id =5 and B.loc_ID=3402 and F.WorkStation ='WH-FLOOR'" & Environment.NewLine
            strSql &= "  group by D.disp_id,C.Model_Desc;" & Environment.NewLine
            dt3 = _objDataProc.GetDataTable(strSql)

            For Each row2 In dt3.Rows
                If Not row2.IsNull("disp_id") AndAlso Not row2.IsNull("WFM_Model") Then
                    For Each row1 In dt.Rows
                        If row2("disp_id") = 5 AndAlso Trim(row1("Model_Desc")).ToUpper = Trim(row2("WFM_Model")).ToUpper Then
                            row1.BeginEdit()
                            row1("NTF") = row1("NTF") - row2("Qty")
                            Try
                                If row1("NTF") < 0 Then row1("NTF") = 0
                            Catch ex As Exception
                            End Try
                            row1.AcceptChanges() : Exit For
                        End If
                    Next
                End If
            Next


            Return 1
        End Function

        Public Function GetWFMTriageProductionData(ByVal strBeginDate As String, ByVal strEndDate As String)
            Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim _dt As New DataTable()
            Dim strSql As String

            strSql = "SELECT DATE_FORMAT(trg.crt_ts, '%Y-%m-%d') as 'Date',u.user_Fullname as 'Employee Name'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=5,1,0)) as 'NTF'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=2,1,0)) as 'SOF'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=3,1,0)) as 'FUN'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=4,1,0))  as 'COS'" & Environment.NewLine
            strSql &= " , Count(*) as 'Total'" & Environment.NewLine
            strSql &= " FROM tcustomer c" & Environment.NewLine
            strSql &= " INNER JOIN tcustmodel_pssmodel_map map on c.cust_id = map.cust_id" & Environment.NewLine
            strSql &= " INNER JOIN tmodel m on map.model_id = m.model_id" & Environment.NewLine
            strSql &= " INNER JOIN tdevice d on m.model_id = d.model_id" & Environment.NewLine
            strSql &= " INNER JOIN edi.titem itm on d.device_id = itm.device_id" & Environment.NewLine
            strSql &= " INNER JOIN production.ttf_bx_phn_received rec on d.device_sn = rec.serial_nr" & Environment.NewLine
            strSql &= " INNER JOIN production.tdevice_triage trg on d.device_id = trg.device_id" & Environment.NewLine
            strSql &= " INNER JOIN Security.tusers u on u.user_ID=trg.crt_user_id" & Environment.NewLine
            strSql &= " LEFT JOIN production.tfailcodes fc on trg.fc_id = fc.fc_id" & Environment.NewLine
            strSql &= " LEFT JOIN tcellopt co on d.device_id = co.device_id" & Environment.NewLine
            strSql &= " LEFT JOIN tdispositions disp on trg.disp_id = disp.disp_id" & Environment.NewLine
            strSql &= " LEFT JOIN tpallett p on d.Pallett_ID=p.Pallett_ID" & Environment.NewLine
            strSql &= " LEFT JOIN warehouse.wh_box wb on itm.whb_id=wb.whb_id" & Environment.NewLine
            strSql &= " WHERE c.cust_id = 2597 AND trg.disp_id IN (2,3,4,5)" & Environment.NewLine
            strSql &= " AND DATE_FORMAT(trg.crt_ts, '%Y-%m-%d') BETWEEN '" & strBeginDate & "' AND '" & strEndDate & "'" & Environment.NewLine
            strSql &= " GROUP BY DATE_FORMAT(trg.crt_ts, '%Y-%m-%d'),u.user_Fullname" & Environment.NewLine
            strSql &= " UNION ALL" & Environment.NewLine
            strSql &= " SELECT 'TOTAL' as 'Date', '' AS  'Employee Name'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=5,1,0)) as 'NTF'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=2,1,0)) as 'SOF'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=3,1,0)) as 'FUN'" & Environment.NewLine
            strSql &= " ,SUM(IF(trg.disp_id=4,1,0))  as 'COS'" & Environment.NewLine
            strSql &= " , Count(*) as 'Total'" & Environment.NewLine
            strSql &= " FROM tcustomer c" & Environment.NewLine
            strSql &= " INNER JOIN tcustmodel_pssmodel_map map on c.cust_id = map.cust_id" & Environment.NewLine
            strSql &= " INNER JOIN tmodel m on map.model_id = m.model_id" & Environment.NewLine
            strSql &= " INNER JOIN tdevice d on m.model_id = d.model_id" & Environment.NewLine
            strSql &= " INNER JOIN edi.titem itm on d.device_id = itm.device_id" & Environment.NewLine
            strSql &= " INNER JOIN production.ttf_bx_phn_received rec on d.device_sn = rec.serial_nr" & Environment.NewLine
            strSql &= " INNER JOIN production.tdevice_triage trg on d.device_id = trg.device_id" & Environment.NewLine
            strSql &= " INNER JOIN Security.tusers u on u.user_ID=trg.crt_user_id" & Environment.NewLine
            strSql &= " LEFT JOIN production.tfailcodes fc on trg.fc_id = fc.fc_id" & Environment.NewLine
            strSql &= " LEFT JOIN tcellopt co on d.device_id = co.device_id" & Environment.NewLine
            strSql &= " LEFT JOIN tdispositions disp on trg.disp_id = disp.disp_id" & Environment.NewLine
            strSql &= " LEFT JOIN tpallett p on d.Pallett_ID=p.Pallett_ID" & Environment.NewLine
            strSql &= " LEFT JOIN warehouse.wh_box wb on itm.whb_id=wb.whb_id" & Environment.NewLine
            strSql &= " WHERE c.cust_id = 2597 AND trg.disp_id IN (2,3,4,5)" & Environment.NewLine
            strSql &= " AND DATE_FORMAT(trg.crt_ts, '%Y-%m-%d') BETWEEN '" & strBeginDate & "' AND '" & strEndDate & "'" & Environment.NewLine
            strSql &= " ORDER BY 'Date','Employee Name';"

            _dt = _objDataProc.GetDataTable(strSql)

            Return _dt
        End Function

        Public Function GetTriageCountByUser(ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal user_id As Integer) As Integer
            Dim _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim _dt As New DataTable()
            Dim _retVal As Integer
            Dim _sb As New StringBuilder()
            _sb.Append("SELECT ")
            _sb.Append("COUNT(dt.dt_id) as qty ")
            _sb.Append("FROM tdevice_triage dt ")
            _sb.Append("INNER JOIN security.tusers u on dt.crt_user_id = u.user_id ")
            _sb.Append("WHERE crt_ts between " & ConvertToMySQLDateOrNullString(start_date.ToString()) & " AND " & ConvertToMySQLDateOrNullString(end_date) & " ")
            _sb.Append("AND dt.crt_user_id = " & user_id.ToString & " ")
            _sb.Append("ORDER BY dt.disp_id;")
            _dt = _objDataProc.GetDataTable(_sb.ToString)
            _retVal = _dt.Rows(0)("qty")
            _objDataProc = Nothing
            _dt = Nothing
            Return _retVal
        End Function
    End Class

End Namespace
