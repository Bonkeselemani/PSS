
Namespace BLL
	Public Class WFMQualityControl
#Region "DECLARATIONS"
		Private _user_id As Integer
		Private _cust_id As Integer = 0
		Private _loc_id As Integer = 0
		Private _prod_id As Integer = 0
		Private arrSplitLine(0)
#End Region
#Region "CONSTRUCTORS"
		Sub New(ByVal user_id As Integer)
			MyBase.New()
			_user_id = user_id
			_cust_id = 2597
			_loc_id = 3402
			_prod_id = 2
		End Sub
#End Region
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
			Dim objDataProc As DBQuery.DataProc
			Dim objGen As New PSS.Data.Buisness.Generic()
			Dim strDate As String = ""
			objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Try
				strDate = objGen.MySQLServerDateTime(1)
				' GET ITERATION NUMBER
				iIteration = GetMaxQCIteration(iDevice_ID) + 1
				If iQCResult = 2 Then				'FAIL
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
							strsql += ");"
							j = objDataProc.ExecuteScalarForInsert(strsql, "production.tqc")
							iDcode_ID = arrSplitLine(i)
						End If
					Next i
					ReDim arrSplitLine(0)
					arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
					' UPDATE TCELLOPT TABLE WITH QC RESULT FLAG
					strsql = ""
					strsql = "update tcellopt set CellOpt_QCReject = " & iQCResult & ", CellOpt_QCFailCode = " & iDcode_ID & " where device_id = " & iDevice_ID & ";"
					j = objDataProc.ExecuteNonQuery(strsql)
				ElseIf iQCResult = 1 Then				  'PASS
					iQCCredit = CalQCCredit(iDevice_ID, iQCtype)
					' INSERT QC DATA
					strsql = ""
					strsql = "Insert into tqc " & Environment.NewLine
					strsql += "(QC_Date, QC_WorkDate, QCType_ID, QCResult_ID, Inspector_ID, Tech_ID, Device_ID, DCode_ID, QC_Iteration, Group_ID, Line_ID, QCCredit" & Environment.NewLine
					If iPalletID > 0 Then strsql += ", Pallett_ID "
					strsql += ")" & Environment.NewLine
					strsql += "Values ('" & strDate & "', '" & strWorkDate & "', " & iQCtype & ", " & iQCResult & ", " & iInspector_ID & ", " & iTech_ID & ", " & iDevice_ID & ", " & iDcode_ID & ", " & iIteration & ", " & iGroupID & ", " & iLineID & ", " & iQCCredit
					If iPalletID > 0 Then strsql += ", " & iPalletID
					strsql += ");" & Environment.NewLine
					j = objDataProc.ExecuteScalarForInsert(strsql, "production.tqc")
				End If
				' UPDATE WIP-OWNER
				If iWipOwner = 0 Then
					iWipOwner = 3					'IN-CELL
					If iQCResult = 1 Then iWipOwner = 4 'PASS QC
				End If
				' UPDATE TCELLOPT
				strsql = ""
				strsql = "UPDATE tcellopt " & Environment.NewLine
				strsql &= "SET tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner " & Environment.NewLine
				strsql &= ", tcellopt.Cellopt_WIPOwner = " & iWipOwner & ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
				strsql &= "WHERE device_id = " & iDevice_ID & ";"
				j = objDataProc.ExecuteNonQuery(strsql)
				Return j
			Catch ex As Exception
				Throw New Exception("Buisness.QC.SaveQCResults(): " & Environment.NewLine & ex.Message.ToString)
			Finally
				ReDim arrSplitLine(0)
				arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
				R1 = Nothing
				dt1 = Nothing
				objGen = Nothing
			End Try
		End Function
		Public Function GetMaxQCIteration(ByVal idevice_id As Integer) As Integer
			Dim dt1 As DataTable
			Dim R1 As DataRow
			Dim iIteration As Integer = 0
			Dim _sql As String = ""
			Dim objDataProc As DBQuery.DataProc
			objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
			Try
				_sql = "Select distinct QC_Iteration from tqc where device_id = " & idevice_id & " order by QC_Iteration Desc;"
				dt1 = objDataProc.GetDataTable(_sql)
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
				dt1 = Nothing
			End Try
		End Function
		Private Function CalQCCredit(ByVal iDeviceID As Integer, ByVal iQCType As Integer) As Integer
			Dim strSql As String
			Dim objDataProc As DBQuery.DataProc
			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "Select count(*) as cnt " & Environment.NewLine
				strSql &= "from tqc  " & Environment.NewLine
				strSql &= "where device_id = " & iDeviceID & Environment.NewLine
				strSql &= "and QCType_ID = " & iQCType & Environment.NewLine
				strSql &= "and QCResult_ID = 1;"
				If objDataProc.GetIntValue(strSql) = 0 Then Return 1 Else Return 0
			Catch ex As Exception
				Throw ex
			Finally
				objDataProc = Nothing
			End Try
		End Function
		Public Function RemoveTqcForADevice(ByVal device_id As Integer, ByVal qctype As Integer)
			Dim _dt As New DataTable()
			Dim _aqlCol As New BOL.tqcDeviceQcCollection(device_id, qctype)
			_dt = _aqlCol.tqcDataTable.Copy
			_aqlCol = Nothing
			Dim _dr As DataRow
			For Each _dr In _dt.Rows()
				Dim _id As Integer = _dr("qc_id")
				Dim _tqc As New BOL.tqc(_id)
				_tqc.MarkDeleted()
				_tqc.ApplyChanges()
				_tqc = Nothing
			Next
			_dt = Nothing
		End Function
	End Class
End Namespace
