Imports System
Imports System.Data
Imports System.Text

Namespace Buisness
    Public Class NIDataManagement
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
        '*************************************************************************************
		Public Function GetNIRMAEndUserData(ByVal iCustID As Integer) As DataTable

            Dim _sb As New StringBuilder()
            Dim dt, dtTmp As DataTable
            Dim row As DataRow
            Dim strSQL As String = ""

			Try
				_sb.Append("SELECT ")
				_sb.Append("ClaimNo as RMA_No, ")
				_sb.Append("ShipTo_Name as Name, ")
				_sb.Append("Address1, ")
				_sb.Append("Address2, ")
				_sb.Append("City, ")
				_sb.Append("State_ShortName as State, ")
				_sb.Append("ZipCode, ")
				_sb.Append("Cntry_Name as Country, ")
				_sb.Append("Tel as Phone, ")
				_sb.Append("Email, ")
				_sb.Append("SerialNo as HardwareSerial, ")
				_sb.Append("Brand,Model, ")
				_sb.Append("Type as Product, ")
				_sb.Append("ServiceLevel, ")
				_sb.Append("RepairType, ")
				_sb.Append("if(Warranty=1,'Yes','No') as Warranty, ")
				_sb.Append("Prod_Code, ")
                _sb.Append("'' as 'NI_prod_Desc', ")
				_sb.Append("DefectType1, ")
				_sb.Append("DefectType2, ")
				_sb.Append("ErrDesc_ItemSKU as ErrorDescription, ")
				_sb.Append("Language, ")
				_sb.Append("Account, ")
				_sb.Append("SenderReference, ")
				_sb.Append("PurchaseDate, ")
				_sb.Append("PSSI2Cust_TrackNo, ")
				_sb.Append("Cust2PSSI_TrackNo, ")
				_sb.Append("TrackCreatedDateTime, ")
				_sb.Append("Final_PSSI2Cust_TrackNo, ")
                _sb.Append("'' as Device_DateShip, ")
				_sb.Append("Date as EmailReceived, ")
				_sb.Append("LoadedDateTime as RMALoaded, ")
				_sb.Append("Warranty as WarrantyID, ")
				_sb.Append("if(ReturnBoxYesNo=1,'Yes','No') as ReturnBox, ")
                _sb.Append("production.NI_Status.Description, ")
				_sb.Append("production.extendedwarranty.Cust_ID, ")
				_sb.Append("production.extendedwarranty.WO_ID, ")
				_sb.Append("State_ID, ")
				_sb.Append("Cntry_ID, ")
				_sb.Append("SC_ID, ")
				_sb.Append("Final_SC_ID, ")
                _sb.Append("production.extendedwarranty.S_ID, ")
				_sb.Append("EW_ID, ")
				_sb.Append("if(NI_DataSwitch=1,'End User',if(NI_DataSwitch=2,'Bulk',if(NI_DataSwitch=0,'TMI','Unkown'))) as NI_TYPE, ")
				_sb.Append("SparePartQty, ")
				_sb.Append("Requester, ")
				_sb.Append("PackagingUpfront ")
				_sb.Append("FROM production.extendedwarranty ")
                _sb.Append("LEFT JOIN production.NI_Status on production.extendedwarranty.S_ID=production.NI_Status.s_ID ")
                _sb.Append("WHERE ")
                _sb.Append("production.extendedwarranty.Cust_ID = ")
				_sb.Append(iCustID.ToString())
				_sb.Append(" AND ")
				_sb.Append("NI_DataSwitch=1 ")
				_sb.Append(" ORDER BY ew_id desc; ")
                dt = Me._objDataProc.GetDataTable(_sb.ToString())

                For Each row In dt.Rows
                    If IsNumeric(row("Prod_Code")) Then
                        strSQL = "select * from production.NI_products where NI_Prod_ID = " & row("Prod_Code")
                        dtTmp = Me._objDataProc.GetDataTable(strSQL)
                        If dtTmp.Rows.Count > 0 Then
                            row.BeginEdit()
                            row("NI_prod_Desc") = dtTmp.Rows(0).Item("NI_prod_Desc")
                            row.AcceptChanges()
                        End If
                    End If
                    If IsNumeric(row("WO_ID")) Then
                        strSQL = "select * from saleorders.Soheader where Cust_ID = 2531 and WorkOrderID=" & row("WO_ID")
                        dtTmp = Me._objDataProc.GetDataTable(strSQL)
                        If dtTmp.Rows.Count > 0 Then
                            row.BeginEdit()
                            row("Device_DateShip") = dtTmp.Rows(0).Item("ShipDate")
                            If Not dtTmp.Rows(0).IsNull("ShipDate") AndAlso Trim(dtTmp.Rows(0).Item("ShipDate")).ToString.Length > 0 Then
                                row("Description") = "Shipped"
                                row("S_ID") = 7
                            End If
                            row.AcceptChanges()
                        End If
                    End If
                Next

                Return dt
            Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetNIBulkData_Master(ByVal iCustID As Integer) As DataTable
			Dim strSql As String = ""
			Try

				strSql = " SELECT ClaimNo as RMA_No,ShipTo_Name as Name,Address1,Address2,City,State_ShortName as State,ZipCode,Cntry_Name as Country," & Environment.NewLine
				strSql &= " Wo_Date,WO_Quantity,RepairType,if(Warranty=1,'Yes','No') as Warranty,Cust_ID,production.tWorkOrder.WO_ID,State_ID,Cntry_ID,EW_ID," & Environment.NewLine
				strSql &= "  production.extendedwarranty.BulkORderType_ID,production.ni_BulkOrderType.BulkORderType_Desc," & Environment.NewLine
				strSql &= "  if(NI_DataSwitch=1,'End User',if(NI_DataSwitch=2,'Bulk',if(NI_DataSwitch=0,'TMI','Unkown'))) as NI_TYPE, " & Environment.NewLine
				strSql &= " production.extendedwarranty.Requester "
				strSql &= " FROM production.extendedwarranty" & Environment.NewLine
				strSql &= " INNER JOIN production.tWorkOrder on production.extendedwarranty.WO_ID=production.tWorkOrder.WO_ID" & Environment.NewLine
				strSql &= " LEFT JOIN production.ni_BulkOrderType on production.extendedwarranty.BulkORderType_ID=production.ni_BulkOrderType.BulkORderType_ID " & Environment.NewLine
				strSql &= " WHERE production.extendedwarranty.Cust_ID=" & iCustID & "  AND NI_DataSwitch=2;" & Environment.NewLine

				Return Me._objDataProc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetNIBulkData_Detail(ByVal iCustID As Integer, ByVal iWoID As Integer) As DataTable
			Dim strSql As String = ""

			Try
				strSql = " SELECT ClaimNo as RMA_No,Device_SN,RepairType,Final_PSSI2Cust_TrackNo,production.tDevice.Device_DateShip," & Environment.NewLine
				strSql &= " Description,ShipTo_Name as Name,Address1,Address2,City,State_ShortName as State,ZipCode,Cntry_Name as Country," & Environment.NewLine
				strSql &= " if(Warranty=1,'Yes','No') as Warranty,production.extendedwarranty.Cust_ID,production.extendedwarranty.WO_ID,State_ID,Cntry_ID, SC_ID,EW_ID," & Environment.NewLine
				strSql &= " if(NI_DataSwitch=1,'End User',if(NI_DataSwitch=2,'Bulk',if(NI_DataSwitch=0,'TMI','Unkown'))) as NI_TYPE" & Environment.NewLine
				strSql &= " FROM production.extendedwarranty" & Environment.NewLine
				strSql &= "  INNER JOIN production.NI_Status on production.extendedwarranty.S_ID=production.NI_Status.s_ID" & Environment.NewLine
				strSql &= " LEFT JOIN production.ni_products on production.extendedwarranty.Prod_Code=production.ni_products.Ni_prod_ID" & Environment.NewLine
				strSql &= " LEFT JOIN production.tDevice on production.extendedwarranty.WO_ID=production.tDevice.WO_ID" & Environment.NewLine
				strSql &= " WHERE production.extendedwarranty.Cust_ID=" & iCustID & " AND NI_DataSwitch=2 and  production.extendedwarranty.WO_ID=" & iWoID & ";" & Environment.NewLine

				Return Me._objDataProc.GetDataTable(strSql)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetCountryNames() As DataTable
			Dim strSQL1 As String = "", strSQL2 As String = ""
			Dim db As DataTable
			Dim strIDS As String = ""
			Dim row As DataRow

			Try
				strSQL1 = "SELECT Distinct Cntry_ID " & Environment.NewLine
				strSQL1 &= " FROM production.extendedwarranty;" & Environment.NewLine
				db = Me._objDataProc.GetDataTable(strSQL1)
				For Each row In db.Rows
					If Not strIDS.Length > 0 Then
						strIDS &= row.Item("Cntry_ID")
					Else
						strIDS &= "," & row.Item("Cntry_ID")
					End If
				Next

				strSQL2 = "SELECT Cntry_ID,Cntry_Name,Cntry_ShortName from production.lcountry where cntry_ID in (" & strIDS & ")"

				Return Me._objDataProc.GetDataTable(strSQL2)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetStateNames(ByVal iCntryID As Integer) As DataTable
			Dim strSQL As String = ""
			Dim db As DataTable
			Dim strIDS As String = ""
			Dim row As DataRow

			Try
				strSQL = "select State_ID,State_Short,State_Long from  production.lstate where fk_cntry_ID =" & iCntryID & Environment.NewLine

				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetProductData() As DataTable
			Dim strSQL As String = ""
			Dim db As DataTable

			Try
				strSQL = "select * from lproduct where Prod_ID in (24,33);"
				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetNI_Products() As DataTable
			Dim strSQL As String = ""
			Dim strIDS As String = ""
			Dim row As DataRow

			Try

				strSQL = "SELECT NI_Prod_ID,NI_Prod_Desc FROM production.ni_products order by NI_Prod_Desc;" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function GetNI_BulkOrderType() As DataTable
			Dim strSQL As String = ""
			Dim strIDS As String = ""
			Dim row As DataRow

			Try

				strSQL = "SELECT * FROM production.ni_BulkOrderType;" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function RMANumberExist(ByVal iCustID As Integer, ByVal iNI_DataSwitch As Integer, ByVal strClaimNo As String) As Boolean
			Dim strSQL As String = ""
			Dim strIDS As String = ""
			Dim dt As DataTable
			Dim bResult As Boolean = False

			Try
				strSQL = "SELECT ClaimNo FROM production.extendedwarranty" & Environment.NewLine
				strSQL &= " WHERE NI_DataSwitch=" & iNI_DataSwitch & Environment.NewLine
				strSQL &= " AND NI_DataSwitch=" & iNI_DataSwitch & Environment.NewLine
				strSQL &= " AND ClaimNo='" & strClaimNo & "';" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSQL)

				If dt.Rows.Count > 0 Then
					bResult = True
				End If

				Return bResult

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function IsCorectRecordToUpdate(ByVal iEW_ID As Integer, ByVal strClaimNo As String) As Boolean
			Dim strSQL As String = ""
			Dim strIDS As String = ""
			Dim dt As DataTable
			Dim bResult As Boolean = False

			Try
				strSQL = "SELECT ClaimNo as RecNum FROM production.extendedwarranty" & Environment.NewLine
				strSQL &= " WHERE EW_ID=" & iEW_ID & Environment.NewLine
				strSQL &= " AND ClaimNo='" & strClaimNo & "';" & Environment.NewLine

				dt = Me._objDataProc.GetDataTable(strSQL)

				If dt.Rows.Count > 0 Then
					bResult = True
				End If

				Return bResult

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Sub ValidateTableRecord(ByVal iEW_ID As Integer, ByVal iWO_ID As Integer, ByVal iCust_ID As Integer, ByVal strClaimNo As String, _
			ByRef bFirstTB As Boolean, ByRef bSecondTB As Boolean, ByRef strErrMsg As String)
			Dim strSQL As String = ""
			Dim strIDS As String = ""
			Dim dt1 As DataTable, dt2 As DataTable
			Dim j As Integer = 0
			Dim S1 As String = "", S2 As String = ""

			Try
				strErrMsg = "" : bFirstTB = False : bSecondTB = False

				'First table
				strSQL = "SELECT ClaimNo,WO_ID,Shipto_Name,address1,address2,City,State_ShortName,ZipCode FROM production.extendedwarranty" & Environment.NewLine
				strSQL &= " WHERE EW_ID=" & iEW_ID & Environment.NewLine
				strSQL &= " AND WO_ID=" & iWO_ID & Environment.NewLine
				strSQL &= " AND ClaimNo='" & strClaimNo & "';" & Environment.NewLine
				dt1 = Me._objDataProc.GetDataTable(strSQL)
				If dt1.Rows.Count > 0 Then
					bFirstTB = True
				Else
					bFirstTB = False
					strErrMsg = "No record to update in production.extendedwarranty!"
					Exit Sub
				End If

				'Second table
				strSQL = "SELECT CustomerOrderNumber as ClaimNo,WorkOrderID as WO_ID,CustomerFirstName as Shipto_Name," & Environment.NewLine
				strSQL &= " CustomerAddress1 as address1, CustomerAddress2 as address2,CustomerCity as city,CustomerState as State_ShortName," & Environment.NewLine
				strSQL &= " CustomerPostalCode ZipCode FROM saleorders.SOheader" & Environment.NewLine
				strSQL &= " WHERE WorkOrderID=" & iWO_ID & Environment.NewLine
				strSQL &= " AND Cust_ID=" & iCust_ID & Environment.NewLine
				strSQL &= " AND CustomerOrderNumber='" & strClaimNo & "';" & Environment.NewLine
				dt2 = Me._objDataProc.GetDataTable(strSQL)
				If dt2.Rows.Count > 0 Then bSecondTB = True Else bSecondTB = False

				'Check if they have same custoner info
				If bFirstTB AndAlso bSecondTB Then
					For j = 0 To dt1.Columns.Count - 1
						If dt1.Rows(0).IsNull(j) Then S1 = "" Else S1 = dt1.Rows(0).Item(j)
						If dt2.Rows(0).IsNull(j) Then S2 = "" Else S2 = dt2.Rows(0).Item(j)
						If Not S1.Trim.ToUpper = S2.Trim.ToUpper Then
							strErrMsg = "Customer info in tables, ""production.extendedwarranty"" and ""saleorders.SOheader"", are different!"
							Exit Sub
						End If
					Next
				End If

			Catch ex As Exception
				strErrMsg = "Sub ValidateTableRecord:" & ex.Message
			End Try
		End Sub

		'*************************************************************************************
		Public Sub ValidateTableRecord_Bulk(ByVal iEW_ID As Integer, ByVal iWO_ID As Integer, ByVal iCust_ID As Integer, ByVal strClaimNo As String, _
		   ByRef strErrMsg As String)
			Dim strSQL As String = ""
			Dim dt1 As DataTable, dt2 As DataTable

			Try

				strSQL = "SELECT ClaimNo,WO_ID,Shipto_Name,address1,address2,City,State_ShortName,ZipCode FROM production.extendedwarranty" & Environment.NewLine
				strSQL &= " WHERE EW_ID=" & iEW_ID & Environment.NewLine
				strSQL &= " AND WO_ID=" & iWO_ID & Environment.NewLine
				strSQL &= " AND ClaimNo='" & strClaimNo & "';" & Environment.NewLine
				dt1 = Me._objDataProc.GetDataTable(strSQL)
				If dt1.Rows.Count > 0 Then
					strSQL = "Select WO_ID from production.tWorkOrder where WO_ID=" & iWO_ID
					dt2 = Me._objDataProc.GetDataTable(strSQL)
					If dt1.Rows.Count > 0 Then
						strErrMsg = ""
						Exit Sub
					Else
						strErrMsg = "Ready to update in production.extendedwarranty, however, no record to update in production.tWorkOrder!"
						Exit Sub
					End If
				Else
					strErrMsg = "No record to update in production.extendedwarranty!"
					Exit Sub
				End If

				dt1 = Nothing : dt2 = Nothing

			Catch ex As Exception
				strErrMsg = "ValidateTableRecord_Bulk:" & ex.Message
			End Try
		End Sub


		Public Function UpdateTable(ByVal strSQL As String) As Boolean
			'Update or insert for given SQL
			Dim i As Integer
			i = Me._objDataProc.ExecuteNonQuery(strSQL)
			If i = 1 Then Return True Else Return False
		End Function

		Public Sub InsertNewData2Table(ByVal strSQL As String, _
		  ByRef newID As Integer, ByRef errMsg As String)
			Dim myStrSQL As String = "SELECT LAST_INSERT_ID();"
			Dim i As Integer
			Dim dt As DataTable

			i = Me._objDataProc.ExecuteNonQuery(strSQL)
			If i = 1 Then			 'suceessed
				dt = Me._objDataProc.GetDataTable(myStrSQL)
				If dt.Rows.Count > 0 Then
					Try
						newID = dt.Rows(0).Item(0)
						errMsg = ""
						Exit Sub						 'found it, so exit sub
					Catch ex As Exception
						errMsg = "Sub InsertNewData2Table: " & ex.Message
					End Try
				Else
					errMsg = "Sub InsertNewData2Table: Can't find EW_ID "
				End If
			Else			 'Failed
				errMsg = "Sub InsertNewData2Table: Can't find EW_ID "
			End If

		End Sub

		Public Sub CreateWorkOrder_Bulk(ByVal strDateTime As String, ByVal strRMANo As String, ByVal iWO_Qty As Integer, ByVal iLocID As Integer, _
		  ByVal iGroupID As Integer, ByRef iWO_ID As Integer, ByRef errMsg As String)

			Dim strSQL As String
			Dim myStrSQL As String = "SELECT LAST_INSERT_ID();"
			Dim i As Integer
			Dim dt As DataTable

			strSQL = "INSERT INTO Production.tWorkOrder (Wo_Date,WO_CustWO,WO_Quantity,Loc_ID,Group_ID)" & _
			  " VALUES ('" & strDateTime & "','" & strRMANo & "'," & iWO_Qty & "," & iLocID & "," & iGroupID & ");"

			i = Me._objDataProc.ExecuteNonQuery(strSQL)
			If i = 1 Then			 'suceessed
				dt = Me._objDataProc.GetDataTable(myStrSQL)
				If dt.Rows.Count > 0 Then
					Try
						iWO_ID = dt.Rows(0).Item(0)
						errMsg = ""
						Exit Sub						 'found it, so exit sub
					Catch ex As Exception
						errMsg = "Sub CreateWorkOrder_Bulk: " & ex.Message
					End Try
				Else
					errMsg = "Sub CreateWorkOrder_Bulk: Can't find WO_ID."
				End If
			Else			 'Failed
				errMsg = "Sub CreateWorkOrder_Bulk: Can't find WO_ID."
			End If

		End Sub

		Public Function getLocationID(ByVal iCust_ID As Integer) As Integer
			Dim strSQL As String = "select loc_ID from production.tlocation where cust_ID=" & iCust_ID & ";"
			Dim dt As DataTable
			Try
				dt = Me._objDataProc.GetDataTable(strSQL)
				Return dt.Rows(0).Item(0)
			Catch ex As Exception
				Return 0
			End Try
		End Function

		Public Function SaveLog(ByVal strChange_Reason As String, _
		   ByVal strInsertDatetime As String, _
		   ByVal iModifier_ID As Integer, _
		   ByVal iEW_ID As Integer, _
		   ByVal iCust_ID As Integer, _
		   ByVal strClaimNo As String, _
		   ByVal strLog_Method As String, _
		   ByVal strLog_Old_Values As String, _
		   ByVal strLog_New_Values As String) As Boolean
			Dim strSQL As String
			Dim i As Integer

			strSQL = "INSERT INTO tracker.extendedwarranty_log " & _
			  "(Change_Reason,InsertDatetime,Modifier_ID,EW_ID,Cust_ID,ClaimNo,Log_Method,Log_Old_Values,Log_New_Values)" & _
			  " VALUES (" & _
			  "'" & strChange_Reason & "'," & _
			  "'" & strInsertDatetime & "'," & _
			  iModifier_ID & "," & _
			  iEW_ID & " ," & _
			  iCust_ID & " ," & _
			  "'" & strClaimNo & "'," & _
			  "'" & strLog_Method & "'," & _
			  "'" & strLog_Old_Values & "'," & _
			  "'" & strLog_New_Values & "');"

			i = Me._objDataProc.ExecuteNonQuery(strSQL)
			If i = 1 Then Return True Else Return False

		End Function

		'*************************************************************************************
		Public Function getFillOrderHeaderData(ByVal strRMA_No As String) As DataTable
			Dim strSQL As String = ""

			Try
				strSQL = "SELECT * FROM  saleorders.soheader WHERE PONumber='" & strRMA_No & "';" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function getFillOrderDetailsData(ByVal iSOHeaderID As Integer) As DataTable
			Dim strSQL As String = ""

			Try
				strSQL = "SELECT * FROM saleorders.sodetails WHERE SOHeaderID=" & iSOHeaderID & ";" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

		'*************************************************************************************
		Public Function getFillOrderWarehouseItemData(ByVal iSODetailsID As Integer) As DataTable
			Dim strSQL As String = ""

			Try
				strSQL = "SELECT * FROM warehouse.warehouse_items WHERE SODetailsID=" & iSODetailsID & ";" & Environment.NewLine
				Return Me._objDataProc.GetDataTable(strSQL)

			Catch ex As Exception
				Throw ex
			End Try
		End Function

#Region "NI_REQUESTER TABLE METHODS"

		Public Function GetNIRequester(ByVal id As Integer) As DataTable
			' RETURNS A DATATABLE WITH THE REQUESTER FOR THE PASSED IN ID.
			Dim strSQL As String = ""
			Dim _dt As DataTable
			Dim strIDS As String = ""
			Try
				strSQL = "SELECT rqstr_id, rqstr_na FROM ni_requesters WHERE rqstr_id = " & id.ToString() & ";"
				Return Me._objDataProc.GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function GetNIRequesters() As DataTable
			' RETURNS A DATATABLE WITH THE LIST OF NI REQUESTERS.
			Dim strSQL As String = ""
			Dim _dt As DataTable
			Dim strIDS As String = ""
			Try
				strSQL = "SELECT rqstr_id, rqstr_na FROM ni_requesters ORDER BY rqstr_na;"
				Return Me._objDataProc.GetDataTable(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Public Function InsertNIRequester(ByVal requester_name As String) As Integer
			' INSERT A NEW REQUESTER INTO THE NI_REQUESTERS TABLE.
			Dim strSQL
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = "INSERT INTO production.ni_requesters (rqstr_na)"
				strSQL &= "VALUES ('" & requester_name & "');"
				_id = objDataProc.ExecuteScalarForInsert(strSQL, "production.ni_requesters")
				Return _id
			Catch ex As Exception
				If InStr(ex.Message, "Duplicate") > 0 Then
					Throw New Exception("A duplicate exists for this Requester.")
				Else
					Throw ex
				End If
			End Try
		End Function
		Protected Sub UpdateNIRequester(ByVal id As Integer, ByVal requester_name As String)
			' UPDATES A REQUESTERS NAME IN THE NI_REQUESTERS TABLE.
			Dim strSQL
			Try
				Dim objDataProc As DBQuery.DataProc
				Dim _id As Integer
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSQL = "UPDATE production.ni_requesters SET "
				strSQL &= "rqstr_na = '" & requester_name & "' "
				strSQL &= "WHERE rqstr_id = " & id.ToString()
				objDataProc.ExecuteNonQuery(strSQL)
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

#End Region

	End Class
End Namespace