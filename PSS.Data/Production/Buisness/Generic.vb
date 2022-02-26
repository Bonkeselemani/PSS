Option Explicit On 

Imports PSS.Data.Production
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Namespace Buisness

    Public Class Generic
        '***************************************************
        Public Const NullDateFormat = "{0} IS NULL OR LENGTH(TRIM({0})) = 0 OR {0} = '0000-00-00 00:00:00' "

        '***************************************************
        Public Shared Sub NAR(ByRef o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        Public Shared Function ConvertToSomething(ByVal obj As Object, ByVal newVal As Object) As Object
            If obj Is System.DBNull.Value Or IsNothing(obj) Then
                Return newVal
            Else
                Return obj
            End If
		End Function

		Public Shared Function ConvertBackToNullString(ByVal obj As Object, ByVal includeQuotes As Boolean) As String
			Dim _retVal As String
			If IsNothing(obj) Then
				_retVal = "NULL "
			Else

				_retVal = obj.ToString()
				If obj.ToString() = "0" Then _retVal = "NULL "
				If obj.ToString() = "" Then _retVal = "NULL "
				If obj.ToString() = "0000-00-00 00:00:00" Then _retVal = "NULL "
				If _retVal <> "NULL " Then
					_retVal = (IIf(includeQuotes, "'", "") & _retVal & IIf(includeQuotes, "'", ""))
				End If
			End If
			Return _retVal
		End Function

		Public Shared Function ConvertToMySQLDateOrNullString(ByVal obj As Object) As String
			Dim _retVal As String
			If IsNothing(obj) Then
				_retVal = "NULL "
			Else
				_retVal = obj.ToString()
				If obj.ToString() = "" Then _retVal = "NULL "
				If obj.ToString() = "0000-00-00 00:00:00" Then _retVal = "NULL "
				If obj.ToString() = "1/1/0001 12:00:00 AM" Then _retVal = "NULL "
			End If
			Try
				If _retVal <> "NULL " Then
					_retVal = "'" & Format(Convert.ToDateTime(_retVal), "yyyy-MM-dd HH:mm:ss").ToString() & "'"
				End If
				Return _retVal
			Catch ex As Exception
				Throw ex
			End Try
		End Function

		Public Shared Function GetFirstSecondOfDate(ByVal dateValue As Date)
			Dim _retVal As Date
			_retVal = dateValue.Date
			Return _retVal
		End Function

		Public Shared Function GetLastSecondOfDate(ByVal dateValue As Date)
			Dim _retVal As Date
			_retVal = dateValue.Date.AddDays(1).AddTicks(-1)
			Return _retVal
		End Function

		Public Shared Function ConvertBoolToIntString(ByVal val As Boolean) As Integer
			Return IIf(val, "1", "0")
		End Function

		'***************************************************
		Public Shared Sub DisposeDT(ByRef dt As DataTable)
			Try
				If Not IsNothing(dt) Then
					dt.Dispose()
					dt = Nothing
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'***************************************************
		Public Shared Sub DisposeDS(ByRef ds As DataSet)
			Try
				If Not IsNothing(ds) Then
					ds.Dispose()
					ds = Nothing
				End If
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'***************************************************
		Protected Overrides Sub Finalize()
			MyBase.Finalize()
		End Sub

		'***************************************************
		Public Shared Function GetObjectInfo(ByVal sender As Object, ByVal e As System.EventArgs) As String
			'MsgBox(sender.GetType.Name)
			GetObjectInfo = "xxx"
		End Function

        '***************************************************
        Public Sub LoadModels(ByRef cmbModel As ComboBox,
           Optional ByVal iProd_ID As Integer = 0)
            Dim dtModels As New DataTable()
            Dim objMisc As New Production.Misc()
            Dim strsql As String = ""

            Try
                '*******************************************************************
                strsql = "Select distinct Model_id, model_desc "
                strsql &= " from tmodel "
                If iProd_ID > 0 Then strsql &= " where prod_id = " & iProd_ID & " "

                strsql &= " order by Model_Desc;"

                objMisc._SQL = strsql
                dtModels = objMisc.GetDataTable
                InsertEmptyRow(dtModels, , "Model_id", "model_desc", , , "--SELECT--")
                '*******************************************************************
                'Populate the Combo Box
                With cmbModel
                    .DataSource = dtModels.DefaultView
                    .DisplayMember = dtModels.Columns("Model_Desc").ToString
                    .ValueMember = dtModels.Columns("Model_ID").ToString
                    .SelectedValue = 0
                End With
                '*******************************************************************
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtModels) Then
                    dtModels.Dispose()
                    dtModels = Nothing
                End If
                objMisc = Nothing
            End Try
        End Sub

        '***************************************************
        Public Shared Function GetModels(ByVal booAddSelectRow As Boolean, _
		  Optional ByVal iProd_ID As Integer = 0, _
		  Optional ByVal booHasUPCCode As Boolean = False, _
		  Optional ByVal iCustID As Integer = 0) As DataTable
			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql, strCriteria As String
			Try
				strSql = "" : strCriteria = ""
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT distinct A.Model_id, A.Model_desc, A.Model_MotoSku, A.Manuf_ID, A.Prod_ID, A.UPC_Code " & Environment.NewLine
				strSql &= "FROM tmodel A" & Environment.NewLine
				If iCustID > 0 Then strSql &= "INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND B.Cust_ID = " & iCustID & Environment.NewLine
				If iProd_ID > 0 OrElse booHasUPCCode = True Then
					If iProd_ID > 0 Then
						strCriteria &= " WHERE A.prod_id = " & iProd_ID
					End If
					If booHasUPCCode = True Then
						If strCriteria.Trim.Length > 0 Then strCriteria &= " AND " Else strCriteria &= " WHERE "
						strCriteria &= " A.UPC_Code is not null " & Environment.NewLine
					End If
				End If
				If strCriteria.Trim.Length > 0 Then
					strSql &= strCriteria
				End If
				strSql &= " order by Model_Desc"
				dt = objDataProc.GetDataTable(strSql)
				If booAddSelectRow Then
					Dim dr As DataRow
					dr = dt.NewRow()
					dr(0) = "0"
					dr(1) = "--SELECT--"
					dr(2) = False
					dt.Rows.InsertAt(dr, 0)
				End If
				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

		'***************************************************
		Public Shared Function GetModelsByManufID(ByVal booAddSelectRow As Boolean, _
		 ByVal iManuf_ID As Integer) As DataTable
			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql As String = ""

			Try

				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT A.Model_id, A.Model_desc, A.Model_MotoSku, A.Manuf_ID, A.Prod_ID, A.UPC_Code" & Environment.NewLine
				strSql &= "FROM tmodel A  where A.Manuf_ID=199 order by Model_desc;" & Environment.NewLine
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

		'***************************************************
		Public Shared Function GetModelsWithCustCriteria(ByVal iCustID As Integer, ByVal booAddSelectRow As Boolean, _
		  Optional ByVal iProdID As Integer = 0, _
		  Optional ByVal iManufID As Integer = 0) As DataTable
			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql, strCriteria As String

			Try
				strSql = "" : strCriteria = ""
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT DISTINCT A.Model_ID, A.Model_Desc, A.Manuf_ID, A.Prod_ID " & Environment.NewLine
				strSql &= ", IF(B.ModelCriteria_ID is null, 0, B.ModelCriteria_ID) as ModelCriteria_ID " & Environment.NewLine
				strSql &= ", IF(B.EndOfLife is null, 0, B.EndOfLife ) as EndOfLife" & Environment.NewLine
				strSql &= ", IF(B.Recycle is null, 0 , B.Recycle) as Recycle " & Environment.NewLine
				strSql &= "FROM tmodel A " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN tmodelcriteria B ON A.Model_ID = B.Model_ID AND B.Cust_ID = " & iCustID & Environment.NewLine
				If iProdID > 0 Then
					strCriteria = "WHERE A.Prod_ID = " & iProdID & Environment.NewLine
				End If

				If iManufID > 0 Then
					If strCriteria.StartsWith("WHERE") = False Then strCriteria = "WHERE " Else strCriteria &= " AND "
					strCriteria &= "Manuf_ID = " & iManufID
				End If
				If strCriteria.Length > 0 Then strSql &= strCriteria
				strSql &= " ORDER BY A.Model_Desc"
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

        '***********************************************
        'select query must have field name ID and Desc
        '***********************************************
        Public Shared Sub LoadProduct(ByRef cmbCtrl As ComboBox,
           Optional ByVal iAddSelectRow As Integer = 0)
            Dim dt As DataTable
            Dim objMisc As New Production.Misc()

            Try
                objMisc._SQL = "Select Prod_ID, Prod_Desc from lproduct where Prod_Inactive = 0;"
                dt = objMisc.GetDataTable

                If iAddSelectRow = 1 Then
                    dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                End If

                With cmbCtrl
                    .DataSource = dt.DefaultView
                    .DisplayMember = dt.Columns("Prod_Desc").ToString
                    .ValueMember = dt.Columns("Prod_ID").ToString
                End With

                If iAddSelectRow = 1 Then
                    cmbCtrl.SelectedValue = 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objMisc = Nothing
            End Try
        End Sub

        '***************************************************
        Public Shared Function GetProducts(ByVal booAddSelectRow As Boolean) As DataTable
			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql As String = ""

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "Select Prod_ID, Prod_Desc from lproduct where Prod_Inactive = 0 Order By Prod_Desc;"
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

        '***********************************************
        'select query must have field name ID and Desc
        '***********************************************
        Public Shared Sub LoadComboBox(ByRef cmbCtrl As ComboBox,
           ByVal strSql As String,
           Optional ByVal iAddSelectRow As Integer = 0)

            Dim dt As DataTable
            Dim objMisc As New Production.Misc()

            Try
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                If iAddSelectRow = 1 Then
                    dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                End If

                With cmbCtrl
                    .DataSource = dt.DefaultView
                    .DisplayMember = dt.Columns("Desc").ToString
                    .ValueMember = dt.Columns("ID").ToString
                End With

                If iAddSelectRow = 1 Then
                    cmbCtrl.SelectedValue = 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objMisc = Nothing
            End Try
        End Sub

        '***************************************************
        Public Function LoadCustomers(ByRef cmbCust As ComboBox,
           Optional ByVal iProd_ID As Integer = 0) As DataTable

            Dim dtCustomers As DataTable
            Dim strsql As String = ""
            Dim objMisc As New Production.Misc()

            Try

                strsql = "Select distinct tcustomer.cust_id, tcustomer.cust_name1 " & Environment.NewLine
                strsql += "from tcustomer inner join tcusttoprice on tcustomer.cust_id = tcusttoprice.cust_id " & Environment.NewLine
                strsql += " where tcustomer.cust_name2 is null " & Environment.NewLine
                If iProd_ID <> 0 Then
                    strsql += " and tcusttoprice.prod_id = " & iProd_ID & Environment.NewLine
                End If
                strsql += " order by cust_name1 "

                objMisc._SQL = strsql
                dtCustomers = objMisc.GetDataTable
                InsertEmptyRow(dtCustomers, , "cust_id", "cust_name1", , , "--SELECT--")
                Return dtCustomers
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtCustomers) Then
                    dtCustomers.Dispose()
                    dtCustomers = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function GetCustomers(ByVal booAddSelectRow As Boolean, _
		   Optional ByVal iProd_ID As Integer = 0, _
		   Optional ByVal booTermOnly As Boolean = False, _
		   Optional ByVal booAutoBillCustOnly As Boolean = False, _
		   Optional ByVal iPCoID As Integer = 0) As DataTable

			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql As String = ""

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT distinct tcustomer.Cust_ID, Concat(tcustomer.Cust_Name1, ' ', if(tcustomer.Cust_Name2 is null, '', tcustomer.Cust_Name2)) as Cust_Name1 " & Environment.NewLine
				strSql &= ", Cust_AutoBill " & Environment.NewLine
				strSql += "FROM tcustomer inner join tcusttoprice on tcustomer.cust_id = tcusttoprice.cust_id " & Environment.NewLine
				strSql += "WHERE Cust_Inactive = 0 " & Environment.NewLine
				If booTermOnly Then strSql += " AND tcustomer.Pay_ID = 1 " & Environment.NewLine 'term customer
				If iProd_ID <> 0 Then strSql += " AND tcusttoprice.prod_id = " & iProd_ID & Environment.NewLine
				If booAutoBillCustOnly Then strSql &= "AND Cust_AutoBill = 1 " & Environment.NewLine
				If iPCoID > 0 Then strSql &= " AND tcustomer.PCo_ID = " & iPCoID & Environment.NewLine
				strSql += "ORDER BY cust_name1;"
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

		'******************************************************************
		Public Shared Function GetShipCarriers() As DataTable
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT SC_ID,SC_Desc" & Environment.NewLine
				strSql &= " FROM lshipcarrier " & Environment.NewLine
				strSql &= " WHERE  SC_Active=1" & Environment.NewLine
				dt = objDataProc.GetDataTable(strSql)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				Buisness.Generic.DisposeDT(dt)
			End Try
		End Function

		'********************************************************************************************************
		Public Shared Function GetCustomerListByParentComp(ByVal booAddSelectRow As Boolean, _
		   ByVal iPCoID As Integer) As DataTable

			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql As String = ""

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT distinct tcustomer.Cust_ID, Concat(tcustomer.Cust_Name1, ' ', if(tcustomer.Cust_Name2 is null, '', tcustomer.Cust_Name2)) as Cust_Name1 " & Environment.NewLine
				strSql += "FROM tcustomer " & Environment.NewLine
				strSql += "WHERE Cust_Inactive = 0 " & Environment.NewLine
				strSql += "AND PCo_ID = " & iPCoID & Environment.NewLine
				strSql += "AND Cust_Inactive = 0 " & Environment.NewLine
				strSql += "ORDER BY cust_name1;"
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

		'***************************************************
		Public Shared Function GetLocations(ByVal booAddSelectRow As Boolean, _
		   ByVal iCustID As Integer) As DataTable

			Dim dt As DataTable
			Dim objDataProc As DBQuery.DataProc
			Dim strSql As String = ""

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "SELECT distinct Loc_ID, Loc_Name, concat(Loc_Name, '-', Loc_Zip) as LocNameZip " & Environment.NewLine
				strSql += "FROM tlocation " & Environment.NewLine
				strSql += "WHERE Cust_ID = " & iCustID & Environment.NewLine
				strSql += "ORDER BY Loc_Name;"
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				DisposeDT(dt)
				objDataProc = Nothing
			End Try
		End Function

		'**************************************************************
		Public Shared Function GetPOs(ByVal booAddSelectRow As Boolean, _
		   ByVal iLoc_ID As Integer) As DataTable
			Dim strSql As String = ""
			Dim objDataProc As DBQuery.DataProc
			Dim dt As DataTable

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
				strSql = "select PO_ID, PO_Desc from tpurchaseorder " & Environment.NewLine
				strSql &= "WHERE loc_id = " & iLoc_ID & Environment.NewLine
				dt = objDataProc.GetDataTable(strSql)

				If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

				Return dt
			Catch ex As Exception
				Throw ex
			Finally
				objDataProc = Nothing
			End Try
		End Function

		'***************************************************
		Public Shared Function MySQLServerDateTime(Optional ByVal iSQLFormat As Integer = 0) As String

			'Public Function MySQLServerDateTime() As String
			Dim objMisc As New Production.Misc()
			Dim strsql As String = ""
			Dim dt1 As DataTable
			Dim R1 As DataRow

			Try
				If iSQLFormat = 0 Then
					strsql = "Select DATE_FORMAT(Now(), '%m/%d/%Y %T') as ServerDateTime;"
				Else
					strsql = "Select DATE_FORMAT(Now(), '%Y-%m-%d %T') as ServerDateTime;"
				End If

				objMisc._SQL = strsql
				dt1 = objMisc.GetDataTable
				If dt1.Rows.Count > 0 Then
					R1 = dt1.Rows(0)
					Return (R1("ServerDateTime"))
				Else
					Return ""
				End If
			Catch ex As Exception
				Throw ex
			Finally
				R1 = Nothing
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				objMisc = Nothing
			End Try
		End Function

		'***************************************************
		Public Shared Function GetMySqlDateTime(ByVal strFormat As String) As String
			Dim strsql As String = ""
			Dim objDataProc As DBQuery.DataProc

			Try
				objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

				strsql = "Select DATE_FORMAT(Now(), '" + strFormat + "') as ServerDateTime;"
				Return objDataProc.GetSingletonString(strsql)
			Catch ex As Exception
				Throw ex
			Finally
				objDataProc = Nothing
			End Try
		End Function

		'******************************************************************
		Public Shared Sub CreateExelReport(ByVal dt1 As DataTable, _
		 Optional ByVal iSaveFile As Integer = 0, _
		 Optional ByVal strFilePath As String = "", _
		 Optional ByVal iFileVisible As Integer = 1, _
		 Optional ByVal iWriteTotal As Integer = 0, _
		 Optional ByVal iPrintRpt As Integer = 0, _
		 Optional ByVal iNoConfirmMsg As Integer = 0, _
		 Optional ByVal strBorderColEnd As String = "", _
		 Optional ByVal iTextColNoArr() As Integer = Nothing, _
		 Optional ByVal iTotal As Integer = 0)
			Dim i As Integer = 1
			Dim j As Integer = 0

			'*************************************
			'Excel Related variables
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objBook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet

			'Dim strRptPath As String = "C:\ExcelReport.xls"
			Dim R1 As DataRow
			Dim objArrData(,) As Object

			Try
				If iSaveFile = 1 And strFilePath = "" Then
					iSaveFile = 0
				End If

				If dt1.Rows.Count = 0 Then Exit Sub

				ReDim objArrData(dt1.Rows.Count + 1, dt1.Columns.Count)

				'post header
				For i = 0 To dt1.Columns.Count - 1
					objArrData(0, i) = dt1.Columns(i).Caption
				Next i

				'post data
				For i = 1 To dt1.Rows.Count
					For j = 0 To dt1.Columns.Count - 1
						objArrData(i, j) = dt1.Rows(i - 1)(j)
					Next j
				Next i

				'**************************************************
				'Instantiate the excel related objects
				objExcel = New Excel.Application()				  'Starts the Excel Session
				objBook = objExcel.Workbooks.Add				 'Add a Workbook
				If iFileVisible = 1 Then
					objExcel.Application.Visible = True					  'Make excel visible to user
				Else
					objExcel.Application.Visible = False					 'Make excel invisible to user
				End If
				objExcel.Application.DisplayAlerts = False
				objSheet = objBook.Worksheets.Item(1)				  'Select a Sheet 1 for this

				objExcel.ActiveSheet.Pagesetup.Orientation = 1				  ' 1 = Portrait ; 2 = landscape

				'***********************************************
				'Text format
				'***********************************************
				If Not IsNothing(iTextColNoArr) AndAlso iTextColNoArr.Length > 0 Then
					For j = 0 To iTextColNoArr.Length - 1
						objSheet.Columns(iTextColNoArr(j)).Select() : objExcel.Selection.NumberFormat = "@"
					Next j
				End If

				'***********************************************
				objSheet.Range("A1:" & Chr(65 + dt1.Columns.Count - 1) & (dt1.Rows.Count + 1).ToString).Value = objArrData

				'***********************************************
				'Freeze header
				'***********************************************
				objExcel.ActiveWindow.FreezePanes = False
				objExcel.Range("A2:" & Chr(65 + dt1.Columns.Count - 1) & (2).ToString).Select()
				objExcel.ActiveWindow.FreezePanes = True

				'***********************************************
				'For j = 0 To dt1.Columns.Count - 1
				'    '*****************************************
				'    'Create the header
				'    '*****************************************
				'    objExcel.Application.Cells(i, j + 1).Value = dt1.Columns(j).Caption
				'    '*****************************************
				'    'Set alignments
				'    '*****************************************
				'    objSheet.Columns(j + 1).HorizontalAlignment = Excel.Constants.xlLeft
				'    '*****************************************
				'    'Format cells Data Type
				'    '*****************************************
				'    objSheet.Columns(j + 1).Select()
				'    objExcel.Selection.NumberFormat = "@"
				'Next j

				'*****************************************
				'format header
				'*****************************************
				objSheet.Rows("1:1").Select()
				With objExcel.Selection
					.WrapText = False
					.HorizontalAlignment = Excel.Constants.xlCenter
					.VerticalAlignment = Excel.Constants.xlCenter
					.font.bold = True
					.Font.ColorIndex = 5
				End With

				i += 1

				''Write data to excel file
				'For Each R1 In dt1.Rows
				'    For j = 0 To dt1.Columns.Count - 1
				'        If Not IsDBNull(R1(j)) Then
				'            objExcel.Application.Cells(i, j + 1).Value = R1(j).ToString
				'        End If
				'    Next j
				'    i += 1
				'Next R1

				'*****************************************
				'Set the borders for the whole report
				'*****************************************
				If strBorderColEnd <> "" Then
					objSheet.Range("A1:" & strBorderColEnd & (dt1.Rows.Count + 1)).Select()
					'Set Font
					With objExcel.Selection
						.Font.Name = "Microsoft Sans Serif"
						.Font.Size = 11
					End With

					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
						.LineStyle = Excel.XlLineStyle.xlContinuous						 'xlContinuous
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
				End If
				'************************************************
				'set all cell to be auto-fit 
				objSheet.Cells.Select()
				objSheet.Cells.EntireColumn.AutoFit()
				objSheet.Cells.EntireRow.AutoFit()
				''*************************************************

				i += 1

				'***********************
				'Write Total
				'***********************
				If iWriteTotal = 1 Then
					If iTotal = 0 Then iTotal = dt1.Rows.Count
					objExcel.Application.Cells(i, 1).Value = "Total Count = " & iTotal
					objSheet.Range("A" & i & ":B" & i).Select()
					With objExcel.Selection
						.font.bold = True
						.Font.ColorIndex = 5
						.Font.Size = 12
					End With
				End If

				'***********************
				'Print Report
				'***********************
				If iPrintRpt > 0 Then
					objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=iPrintRpt, Collate:=True)
				End If

				''*************************************************
				objExcel.Sheets("Sheet2").Delete()
				objExcel.Sheets("Sheet3").Delete()
				'Save the excel file
				If iSaveFile = 1 Then
					If Len(Dir(strFilePath)) > 0 Then
						Kill(strFilePath)
					End If
					objBook.SaveAs(strFilePath)
				End If
				System.Windows.Forms.Application.DoEvents()
				''*************************************************
				If iFileVisible = 0 And iNoConfirmMsg = 0 Then
					MsgBox("Report is created.")
				End If

			Catch ex As Exception
				Throw ex
			Finally
				System.Windows.Forms.Application.DoEvents()
				R1 = Nothing
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				If iFileVisible = 0 Then
					'*************************************
					'Excel clean up
					If Not IsNothing(objSheet) Then
						NAR(objSheet)
					End If
					If Not IsNothing(objBook) Then
						objBook.Close(False)
						NAR(objBook)
					End If
					If Not IsNothing(objExcel) Then
						objExcel.Quit()
						NAR(objExcel)
					End If
				End If
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

		'************************************************************
		Public Shared Function CreateExelReportWithTitle(ByVal dt1 As DataTable, _
		 ByVal strTitleArr As String(), _
		 Optional ByVal iFileVisible As Integer = 1, _
		 Optional ByVal iPageOrientation As Integer = 1, _
		 Optional ByVal iWriteHeader As Integer = 0, _
		 Optional ByVal iSetBorder As Integer = 0, _
		 Optional ByVal iWriteTotal As Integer = 0, _
		 Optional ByVal iPrintRpt As Integer = 0, _
		 Optional ByVal iNoConfirmMsg As Integer = 0, _
		 Optional ByVal strFilePath As String = "", _
		 Optional ByVal iAutoFit As Integer = 0 _
		 ) As Integer
			Dim i As Integer = 1
			Dim j As Integer = 0
			Dim k As Integer = 0
			Dim iDataStartRow As Integer = 0
			Dim R1 As DataRow
			Dim arrOutput(,) As String

			'*************************************
			'Excel Related variables
			'*************************************
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objBook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet

			Try
				ReDim arrOutput(dt1.Rows.Count - 1, dt1.Columns.Count - 1)

				If strFilePath = "" Or Not File.Exists(strFilePath) Then
					iFileVisible = 1
				End If

				'**************************************************
				'Instantiate the excel related objects
				'**************************************************
				objExcel = New Excel.Application()				  'Starts the Excel Session
				objBook = objExcel.Workbooks.Add				 'Add a Workbook
				objExcel.Application.DisplayAlerts = False
				objSheet = objBook.Worksheets.Item(1)				  'Select a Sheet 1 for this

				'**************************************************
				'Set Page orientation
				'**************************************************
				objExcel.ActiveSheet.Pagesetup.Orientation = 1				  ' 1 = Portrait ; 2 = landscape

				'**************************************************
				'Set File Visible
				'**************************************************
				If iFileVisible = 1 Then
					objExcel.Application.Visible = True					  'Make excel visible to user
				Else
					objExcel.Application.Visible = False					 'Make excel invisible to user
				End If

				'*****************************************
				'Write Report Title
				'*****************************************
				For j = 0 To strTitleArr.Length - 1
					objExcel.Application.Cells(i, 1).Value = strTitleArr(j)

					objSheet.Range("A" & i & ":" & "A" & i).Select()
					With objExcel.Selection
						.NumberFormat = "@"
						.WrapText = False
						.HorizontalAlignment = Excel.Constants.xlLeft
						.VerticalAlignment = Excel.Constants.xlCenter
						.font.bold = True
						.Font.ColorIndex = 3						 'Red color
						.MergeCells = True
					End With
					objSheet.Range("A" & i & ":" & "A" & i).Font.Size = 27
					objSheet.Range("A" & i & ":" & "A" & i).Font.FontStyle = "Bold"
					objSheet.Range("A" & i & ":" & "A" & i).Font.Name = "Arial"

					i += 1
				Next j

				i += 1

				iDataStartRow = i

				'*****************************************
				'Create the header
				'*****************************************
				For j = 0 To dt1.Columns.Count - 1
					'***********************
					'Set alignments
					'***********************
					objSheet.Columns(j + 1).HorizontalAlignment = Excel.Constants.xlLeft

					'***********************
					'Set column widths
					'***********************
					objSheet.Columns(j + 1).ColumnWidth = dt1.Columns(j).Caption.ToString.Length * 2

					If iWriteHeader = 1 Then
						'***********************
						'Write header
						'***********************
						objExcel.Application.Cells(i, j + 1).Value = dt1.Columns(j).Caption
						i += 1

						'***********************
						'Format Header
						'***********************
						objSheet.Cells(i, j + 1).Select()
						With objExcel.Selection
							.NumberFormat = "@"
							.WrapText = False
							.HorizontalAlignment = Excel.Constants.xlCenter
							.VerticalAlignment = Excel.Constants.xlCenter
							.font.bold = True
							.Font.ColorIndex = 5
						End With
					End If
				Next j


				'*****************************************
				'Write data to excel file
				'*****************************************
				j = 0
				With objSheet
					For Each R1 In dt1.Rows
						j += 1

						For k = 0 To dt1.Columns.Count - 1 : arrOutput(j - 1, k) = R1(k).ToString : Next k

						i += 1
					Next R1

					.Range("A" & iDataStartRow.ToString & ":" & Chr(65 + dt1.Columns.Count - 1) & (i - 1).ToString).Value = arrOutput
				End With

				'*****************************************
				'Set the borders for the whole report
				'*****************************************
				If iSetBorder = 1 Then
					objSheet.Range("A" & iDataStartRow & ":" & Chr(65 + dt1.Columns.Count - 1) & (dt1.Rows.Count + iDataStartRow - 1)).Select()
					'Set Font
					With objExcel.Selection
						.Font.Name = "Microsoft Sans Serif"
						.Font.Size = 11
					End With

					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
					objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
					With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
						.LineStyle = Excel.XlLineStyle.xlContinuous						 'xlContinuous
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
				End If

				'************************************************
				'set all cell to be auto-fit 
				'************************************************
				If iAutoFit = 1 Then
					objSheet.Cells.EntireColumn.AutoFit()
					objSheet.Cells.EntireRow.AutoFit()
				End If
				'*************************************************

				i += 1

				'***********************
				'Write Total
				'***********************
				If iWriteTotal = 1 Then
					objExcel.Application.Cells(i, 1).Value = "Total Count = " & dt1.Rows.Count
					objSheet.Range("A" & i & ":B" & i).Select()
					With objExcel.Selection
						.font.bold = True
						.Font.ColorIndex = 5
						.Font.Size = 12
					End With
				End If

				'***********************
				'Print Report
				'***********************
				If iPrintRpt = 1 Then
					objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
				End If

				''*************************************************
				objExcel.Sheets("Sheet2").Delete()
				objExcel.Sheets("Sheet3").Delete()

				'***********************
				'Save the excel file
				'***********************
				If strFilePath <> "" Then
					If Len(Dir(strFilePath)) > 0 Then
						Kill(strFilePath)
					End If
					objBook.SaveAs(strFilePath)
				End If

				System.Windows.Forms.Application.DoEvents()
				''*************************************************
				If iFileVisible = 0 And iNoConfirmMsg = 0 Then
					MsgBox("Report is created.")
				End If

				Return i
			Catch ex As Exception
				Throw ex
			Finally
				System.Windows.Forms.Application.DoEvents()
				R1 = Nothing
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				If iFileVisible = 0 Then
					'*************************************
					'Excel clean up
					If Not IsNothing(objSheet) Then
						NAR(objSheet)
					End If
					If Not IsNothing(objBook) Then
						objBook.Close(False)
						NAR(objBook)
					End If
					If Not IsNothing(objExcel) Then
						objExcel.Quit()
						NAR(objExcel)
					End If
				End If
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Function

		'************************************************************
		Public Shared Function AddNewColumnToDataTable(ByRef dt1 As DataTable, _
		 ByVal strColName As String, _
		 ByVal strDataType As String, _
		 Optional ByVal strDefaultVal As String = "") As Integer
			Dim ColNew As DataColumn
			Dim i As Integer = 0

			Try
				ColNew = New DataColumn(strColName)
				ColNew.DataType = System.Type.GetType(strDataType)
				If strDefaultVal <> "" Then
					ColNew.DefaultValue = strDefaultVal
				End If

				dt1.Columns.Add(ColNew)
				i = 1
			Catch ex As Exception
				Throw ex
			Finally
				ColNew.Dispose()
				ColNew = Nothing
			End Try

			Return i
		End Function

		'************************************************************
		'Check if device exist in tdevice table without the ship date 
		'************************************************************
		Public Shared Function IsSNInWIP(ByVal iCust_id As Integer, _
		   ByVal strDevice_sn As String) As Boolean

			Dim objMisc As New Production.Misc()
			Dim strSql As String = ""
			Dim dt1 As DataTable
			Dim booResult As Boolean = False

			Try
				strSql = "select count(*) as cnt " & Environment.NewLine
				strSql &= "from tdevice " & Environment.NewLine
				strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
				strSql &= "where device_sn = '" & strDevice_sn & "' " & Environment.NewLine
				strSql &= "and cust_id = " & iCust_id & Environment.NewLine
				strSql &= " and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '');"
				objMisc._SQL = strSql
				dt1 = objMisc.GetDataTable

				If dt1.Rows(0)("cnt") > 0 Then
					booResult = True
					'Throw New Exception("This ""Serial Number"" already exists in WIP. Can not receive.")
				End If

				Return booResult
			Catch ex As Exception
				Throw ex
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				objMisc = Nothing
			End Try
		End Function
        '************************************************************
        Public Shared Function AreAnySNsInWIPInBox(ByVal iCust_id As Integer, ByVal strDevice_SNs As String) As String
            'return those SNs which are in WIP in the box

            Dim objMisc As New Production.Misc()
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strSNsInWIP As String = ""
            Dim row As DataRow
            Try
                strSql = "select device_ID,Device_SN " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "where device_sn in (" & strDevice_SNs & ") " & Environment.NewLine
                strSql &= "and cust_id = " & iCust_id & Environment.NewLine
                strSql &= " and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '');"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                For Each row In dt.Rows
                    If strSNsInWIP.Trim.Length = 0 Then
                        strSNsInWIP = row("Device_SN")
                    Else
                        strSNsInWIP &= "," & row("Device_SN")
                    End If
                Next

                Return strSNsInWIP
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function
        '********************************************************************
        Public Shared Function GetDevIDInWIPBySNCustID(ByVal strSN As String, _
          ByVal iCust_ID As Integer) As Integer
            Dim objMisc As New Production.Misc()
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iDevID As Integer = 0

            Try
                strSql = "SELECT Device_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "WHERE device_sn = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND cust_id = " & iCust_ID & Environment.NewLine
                strSql &= " AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' OR trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= " ORDER BY Device_ID desc;"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iDevID = dt1.Rows(0)("Device_ID")
                End If

                Return iDevID
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        Public Function IsDeviceRepaired(ByVal iDevice_ID As Integer) As Boolean
            Dim dt1 As DataTable
            Dim objMisc As New Production.Misc()
            Dim strSql As String = ""

            Try
                strSql = "Select count(*) as cnt " & Environment.NewLine
                strSql &= "from tdevicebill  " & Environment.NewLine
                strSql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "where tdevicebill.device_id = " & iDevice_ID & " and " & Environment.NewLine
                strSql &= "lbillcodes.BillCode_Rule > 0;"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows(0)("cnt") = 0 Then      'Repaired
                    Return True
                Else     'RUR,RTM.....
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function

        '********************************************************************
        Public Function IsRURDev(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim booRUR As Boolean = False
            Dim booREP As Boolean = False
            Dim objMisc As New Production.Misc()

            Try
                strSql = "SELECT distinct BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tdevicebill.billcode_ID = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDevice_ID & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        If Not IsDBNull(R1("BillCode_Rule")) AndAlso R1("BillCode_Rule") = 1 Then
                            booRUR = True
                            'Exit For
                        End If
                        If Not IsDBNull(R1("BillCode_Rule")) AndAlso R1("BillCode_Rule") = 0 Then
                            booREP = True
                            'Exit For
                        End If
                    Next R1
                End If

                'Can not bill part on RUR
                If booRUR = True And booREP = True Then
                    Throw New Exception("This device contain parts/services and RUR together. Can not have parts/services on RUR.")
                End If

                Return booRUR
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
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
        Public Shared Function GetConstantDbValue(ByVal strConstantName As String) As String
            Dim strSql As String
            Dim dt1 As DataTable
            Dim strConsVal As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "Select ConstValue " & Environment.NewLine
                strSql &= "FROM lconstants " & Environment.NewLine
                strSql &= "WHERE ShortDesc = '" & strConstantName & "'" & Environment.NewLine

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt1 = objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    strConsVal = dt1.Rows(0)("ConstValue").ToString
                End If

                Return strConsVal
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        Public Shared Function GetConstantDbStrValue(ByVal strConstantName As String) As DataRow
            Dim strSql As String
            Dim dr1 As DataRow
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "Select ConstValue as DbVal, ConstStringValue as StrVal " & Environment.NewLine
                strSql &= "FROM lconstants " & Environment.NewLine
                strSql &= "WHERE ShortDesc = '" & strConstantName & "'" & Environment.NewLine

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dr1 = objDataProc.GetDataRow(strSql)

                Return dr1
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function UpLoadFileToFTPSite(ByVal strRemoteHost As String, _
         ByVal strFTPUser As String, _
         ByVal strFTPPWD As String, _
         ByVal strChangeFTPDir As String, _
         ByVal strFilePath As String) As Integer
            Dim i As Integer = 0
            Dim ObjUtility As New MyLib.Utility()

            Try
                ObjUtility = New MyLib.Utility()
                i = ObjUtility.UploadFiles(strRemoteHost, strFTPUser, strFTPPWD, , strFilePath, strChangeFTPDir)
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                ObjUtility = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function GetMachineCostCenterID() As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "Select if (tcostcenter.cc_id is null, 0, tcostcenter.cc_id ) as cc_id " & Environment.NewLine
                strSql &= "from lwclocation " & Environment.NewLine
                strSql &= "INNER JOIN tcostcentermapping ON  lwclocation.WCLocation_ID =  tcostcentermapping.WCLocation_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tcostcentermapping.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "where WC_ActiveFlag = 1 and " & Environment.NewLine
                strSql &= "wc_machine = '" & System.Net.Dns.GetHostName & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function GetMachineCostCenterGrpID() As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "Select tcostcenter.group_id " & Environment.NewLine
                strSql &= "from lwclocation " & Environment.NewLine
                strSql &= "INNER JOIN tcostcentermapping ON  lwclocation.WCLocation_ID =  tcostcentermapping.WCLocation_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tcostcentermapping.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "where WC_ActiveFlag = 1 and " & Environment.NewLine
                strSql &= "wc_machine = '" & System.Net.Dns.GetHostName & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function GetCostCenterIDOfDevice(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim myI As Integer = 0
            Try
                strSql = "Select cc_id " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "where Device_ID =  " & iDevice_ID & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                'Dim objReader As System.IO.StreamWriter
                'objReader = New System.IO.StreamWriter("C:\Documents and Settings\zfang\My Documents\debug.txt")
                'objReader.Write(strSql)
                'myI = objDataProc.GetIntValue(strSql)
                'objReader.Write("myI=" & myI)
                'objReader.Close()

                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function UpdateCostCenterIDOfDevice(ByVal iDevice_ID As Integer, ByVal iCC_ID As Integer) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim myI As Integer = 0
            Try
                strSql = "Update tdevice Set cc_id = " & iCC_ID & Environment.NewLine
                strSql &= "where Device_ID =  " & iDevice_ID & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function GetCostCenterDescOfDevice(ByVal iDevice_ID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim strResutl As String = ""

            Try
                strSql = "SELECT Group_Desc, cc_desc FROM tdevice " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups ON tcostcenter.group_id = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Group_Desc")) And Not IsDBNull(dt.Rows(0)("cc_desc")) Then
                        strResutl = dt.Rows(0)("Group_Desc").ToString.ToUpper & " CELL " & dt.Rows(0)("cc_desc").ToString.ToUpper
                    End If
                End If

                Return strResutl
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************
        Public Shared Function GetCostCenterDescOfDeviceInWIP(ByVal strSN As String, ByVal iCust_ID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim strResutl As String = ""

            Try
                strSql = "SELECT Group_Desc, cc_desc FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups ON tcostcenter.group_id = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN.Trim & "'" & Environment.NewLine
                strSql &= "AND tlocation.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= " AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' OR trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= " ORDER BY tdevice.Device_ID desc;"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Group_Desc")) And Not IsDBNull(dt.Rows(0)("cc_desc")) Then
                        strResutl = dt.Rows(0)("Group_Desc").ToString.ToUpper & " CELL " & dt.Rows(0)("cc_desc").ToString.ToUpper
                    End If
                End If

                Return strResutl
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************
        Public Shared Function GetWorkDate(ByVal iShiftID As Integer) As String
            Dim strSql As String
            Dim objWD As PSS.Data.Buisness.WorkDate
            Dim strWorkDate As String = ""
            Dim strSvrDateTime As String = ""

            Try
                objWD = New WorkDate()
                strSvrDateTime = Generic.MySQLServerDateTime(1)

                'strWorkdate = mWD.WorkDate(ShiftID, Now)
                strWorkDate = objWD.WorkDate(iShiftID, strSvrDateTime)
                If Len(Trim(strWorkDate)) > 0 Then
                Else
                    Throw New Exception("The system could not determine the work date. Contact your direct lead or IT to resolve this issue.")
                End If

                Return strWorkDate
            Catch ex As Exception
                Throw ex
            Finally
                objWD = Nothing
            End Try
        End Function

        '***************************************************
        Public Shared Function GetLastTrayIDOfWOID(ByVal iWOID As Integer, _
         ByRef strTrayMemo As String, _
         Optional ByVal iUserID As Integer = 0) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim iTrayID As Integer = 0

            Try
                strTrayMemo = ""

                strSql = "SELECT Tray_ID, Tray_Memo " & Environment.NewLine
                strSql &= "FROM ttray " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & " " & Environment.NewLine
                If iUserID > 0 Then
                    strSql &= "AND Tray_RecUserID = " & iUserID & Environment.NewLine
                End If
                strSql &= " ORDER BY Tray_ID desc;"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iTrayID = dt.Rows(0)("Tray_ID")
                    strTrayMemo = dt.Rows(0)("Tray_Memo")
                End If

                Return iTrayID
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                DisposeDT(dt)
            End Try
        End Function


        '**************************************************************
        Public Shared Function IsBillcodeMapped(ByVal iModel_ID As Integer, _
          ByVal iBillcode_ID As Integer) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "Select count(*) from tpsmap where Model_ID = " & iModel_ID & " and billcode_id = " & iBillcode_ID & ";"
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetNextWorkStationInWFP(ByVal strScreenName As String, _
          ByVal iModelID As Integer, _
          ByVal strCustIDs As String, _
          Optional ByVal iFailUnit As Integer = 0, _
          Optional ByVal iWrty As Integer = 0) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim R1 As DataRow
            Dim strNextStation As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT wfp_ToStation, wfp_FailUnit_ToStation, wfp_WrtyUnit_ToStation " & Environment.NewLine
                strSql &= "FROM lworkflowprocess " & Environment.NewLine
                strSql &= "WHERE Cust_IDs IN ( " & strCustIDs & " ) " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND wfp_ScreenName = '" & strScreenName & "'" & Environment.NewLine
                strSql &= "AND wfp_Inactive = 0 " & Environment.NewLine
                R1 = objDataProc.GetDataRow(strSql)
                If Not IsNothing(R1) Then
                    If iFailUnit > 0 Then
                        strNextStation = R1("wfp_FailUnit_ToStation")
                    ElseIf iWrty > 0 Then
                        strNextStation = R1("wfp_WrtyUnit_ToStation")
                    Else
                        strNextStation = R1("wfp_ToStation")
                    End If
                End If

                Return strNextStation
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetFromWorkStationInWFP(ByVal strScreenName As String, _
          ByVal iModelID As Integer, _
          ByVal strCustIDs As String) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim strFromStation As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM lworkflowprocess " & Environment.NewLine
                strSql &= "WHERE Cust_IDs IN ( " & strCustIDs & " ) " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND wfp_ScreenName = '" & strScreenName & "'" & Environment.NewLine
                strSql &= "AND wfp_Inactive = 0 " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception(" GetFromLWorkStationInWFP:Duplicate record in work flow process (ScreenName = " & strScreenName & ", CustIDs IN " & strCustIDs & ")")
                ElseIf dt.Rows.Count = 1 Then
                    strFromStation = dt.Rows(0)("wfp_FrStation")
                Else
                    strFromStation = ""
                End If

                Return strFromStation
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetWorkFlowProcessData(ByVal strScreenName As String, _
          ByVal iModelID As Integer, _
          ByVal strCustIDs As String) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            'set it back to original code: strSql &= "WHERE Cust_IDs LIKE ( " & strCustIDs & " ) " & Environment.NewLine
            ' but I think it has some problem with it. need to look at more.......
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM lworkflowprocess " & Environment.NewLine
                strSql &= "WHERE Cust_IDs LIKE ( " & strCustIDs & " ) " & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND wfp_ScreenName = '" & strScreenName & "'" & Environment.NewLine
                strSql &= "AND wfp_Inactive = 0 " & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function SetTcelloptWorkStationForDevice(ByVal strNextStation As String, ByVal iDeviceID As Integer, _
         ByVal iUserID As Integer, ByVal strScreenName As String, ByVal strFormName As String, _
         Optional ByVal iWipOwnerID As Integer = 0, _
         Optional ByVal strCelloptVerificationID As String = "", _
         Optional ByVal strCellOptSoftVerIN As String = "", _
         Optional ByVal strCellOptSoftVerOUT As String = "", _
         Optional ByVal iInboundCosmGrade As Integer = 0, _
         Optional ByVal iOutboundCosmGrade As Integer = 0) As Integer
            Dim strSql As String, i As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim R1 As DataRow, dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Device_ID, WorkStation FROM tcellopt WHERE Device_ID = " & iDeviceID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("System has failed to find data for device ID " & iDeviceID & ".")

                strSql = "UPDATE tcellopt " & Environment.NewLine
                strSql &= "SET WorkStation = '" & strNextStation & "'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt = now(), WIL_ID = 0" & Environment.NewLine
                If iWipOwnerID > 0 Then strSql &= ", Cellopt_WIPEntryDt = now(), Cellopt_WIPOwnerOld = Cellopt_WIPOwner, Cellopt_WIPOwner = " & iWipOwnerID & Environment.NewLine
                If strCelloptVerificationID.Trim.Length > 0 Then strSql &= ", CellOpt_VerificationID = '" & strCelloptVerificationID & "'" & Environment.NewLine
                If strCellOptSoftVerIN.Trim.Length > 0 Then strSql &= ", CellOpt_SoftVerIN = '" & strCellOptSoftVerIN & "'" & Environment.NewLine
                If strCellOptSoftVerOUT.Trim.Length > 0 Then strSql &= ", CellOpt_SoftVerOUT = '" & strCellOptSoftVerOUT & "'" & Environment.NewLine
                If iInboundCosmGrade > 0 Then strSql &= ", InBoundCosmGrade = " & iInboundCosmGrade & Environment.NewLine
                If iOutboundCosmGrade > 0 Then strSql &= ", OutBoundCosmGradeID = " & iOutboundCosmGrade & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                i = objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strNextStation, strScreenName, strFormName)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing : Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************************************
        Public Shared Function SetTcelloptWorkstationJournal(ByVal dt As DataTable, ByVal iUserID As Integer, ByVal strToStation As String, _
          ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim R1 As DataRow
            Dim i As Integer

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                For Each R1 In dt.Rows
                    strSql = "INSERT INTO tcellopt_wstationjournal ( EntryDate, User_ID, FrStation, ToStation, ScreenName, FormName, Device_ID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "now(), " & iUserID & ", '" & R1("WorkStation") & "', '" & strToStation & "', '" & strScreenName & "'" & Environment.NewLine
                    strSql &= ", '" & strFormName & "', " & R1("Device_ID") & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                    i += objDataProc.ExecuteNonQuery(strSql)
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*********************************************************************************************************************
        Public Shared Function UpdateDevice_XModel_FUN_Model(ByVal iDevice_ID As Integer, ByVal iX_Model_ID As Integer, ByVal iFUN_Model_ID As Integer) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim i As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "UPDATE production.tdevice set model_ID=" & iFUN_Model_ID & " WHERE Device_ID =" & iDevice_ID
                i = objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE production.tcellopt set Incoming_NTF_Model_ID=" & iX_Model_ID & " WHERE Device_ID =" & iDevice_ID
                i += objDataProc.ExecuteNonQuery(strSql)

                'FuncRep=1 is functional
                strSql = "UPDATE edi.titem set FuncRep=1 WHERE Device_ID =" & iDevice_ID
                i += objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function SetTmessdataWipOwnerdataForDevices(ByVal strDeviceIDs As String, ByVal iWipOwnerID As Integer, ByVal iWipOwnerSubLocID As Integer, ByVal iPalletID As Integer) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim _sb As New StringBuilder()
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                If iPalletID = 0 Then
                    _sb.Append("UPDATE tmessdata SET ")
                    _sb.Append("wipowner_EntryDt = now(), ")
                    _sb.Append("wipowner_id_Old = wipowner_id, ")
                    _sb.Append("wipowner_id = " & iWipOwnerID & ", ")
                    _sb.Append("wipownersubloc_id = " & iWipOwnerSubLocID & " ")
                    _sb.Append("WHERE Device_ID in ( " & strDeviceIDs & ") ")
                Else
                    _sb.Append("UPDATE tmessdata ")
                    _sb.Append("INNER JOIN tdevice ON tmessdata.Device_ID = tdevice.Device_ID ")
                    _sb.Append("SET ")
                    _sb.Append("wipowner_EntryDt = now(), ")
                    _sb.Append("wipowner_id_Old = wipowner_id, ")
                    _sb.Append("wipowner_id = " & iWipOwnerID & ", ")
                    _sb.Append("wipownersubloc_id = " & iWipOwnerSubLocID & " ")
                    _sb.Append("WHERE tdevice.Pallett_ID = " & iPalletID & " ")
                End If
                Return objDataProc.ExecuteNonQuery(_sb.ToString())
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function SetTcelloptWorkStationForPallet(ByVal strNextStation As String, ByVal iPalletID As Integer, ByVal iUserID As Integer, _
         ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim i As Integer

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT tcellopt.Device_ID, WorkStation FROM tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("Pallet/Box is empty.")

                strSql = "UPDATE tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "SET WorkStation = '" & strNextStation & "'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt = now()" & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                i = objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strNextStation, strScreenName, strFormName)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing : Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetTestTypeID(ByVal strTestName As String) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Test_ID " & Environment.NewLine
                strSql &= "FROM ltesttype " & Environment.NewLine
                strSql &= "WHERE Test_Inactive = 0 " & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************
        Public Shared Function GetTestTypesList(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Test_ID, Test_Desc2 FROM ltesttype WHERE Test_Inactive = 0 "
                dt = objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {0, "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetPartNumberFrTdevicebill(ByVal iBillcodeID As Integer, ByVal iDeviceID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim strPartnumber As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Part_Number " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Part_Number")) Then
                        strPartnumber = dt.Rows(0)("Part_Number")
                    End If
                End If
                Return strPartnumber
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetProdIDOfUnit(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Prod_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function CalExcelColLetter(ByVal iColNo As Integer) As String
            Const iLetterADecNo As Integer = 65
            Const iTotalAlpha As Integer = 26
            Dim strExcelColLetter As String = ""
            Dim iFirstLetter As Integer = 0
            Dim iSecondLeter As Integer = 0
            Dim iTemp As Integer = 0

            Try
                If iColNo < 1 Then Return ""

                If iColNo <= iTotalAlpha Then
                    strExcelColLetter = Chr(iColNo + iLetterADecNo - 1)
                Else
                    iFirstLetter = Math.Floor(iColNo / 26)
                    iSecondLeter = iColNo Mod 26
                    If iSecondLeter = 0 Then
                        iSecondLeter = iTotalAlpha
                        iFirstLetter -= 1
                    End If
                    strExcelColLetter = Chr(iFirstLetter + iLetterADecNo - 1) & Chr(iSecondLeter + iLetterADecNo - 1)
                End If

                Return strExcelColLetter
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function CalQCCredit(ByVal iDeviceID As Integer, ByVal iQCType As Integer) As Integer
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

        '**************************************************************
        Public Shared Function GetRURPriceException(ByVal iCustID As Integer, _
          ByVal iModelID As Integer) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * FROM trurpriceexception " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND RP_Inactive = 0" & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetDataTable(ByVal strSql As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetCustWo(ByVal strWoName As String, _
           Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE WO_CustWO  = '" & strWoName.Trim & "'" & Environment.NewLine
                If iLocID > 0 Then strSql &= "AND Loc_ID = " & iLocID & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetModelDesc(ByVal iModelID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Model_Desc FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Model_ID  = " & iModelID & " " & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetFreqs(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT freq_id, freq_Number, freq_MotoCode " & Environment.NewLine
                strSql &= "FROM lfrequency  " & Environment.NewLine
                strSql &= "WHERE freq_Number NOT IN ( '000.0000' ) " & Environment.NewLine
                strSql &= "ORDER BY freq_Number "
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--", "0"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetBauds(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT baud_id, baud_Number " & Environment.NewLine
                strSql &= "FROM lbaud ORDER BY baud_Number "
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetTrayID(ByVal iWOID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT tray_id " & Environment.NewLine
                strSql &= "FROM ttray  " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
                strSql &= "ORDER BY tray_id desc "
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function UpdateWOQuantity(ByVal iWO_ID As Integer, ByVal iQty As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "UPDATE tworkorder SET WO_RAQnty = " & iQty & " WHERE WO_ID = " & iWO_ID & Environment.NewLine
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetRecQty(ByVal iWO_ID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Count(*) as cnt FROM tdevice WHERE WO_ID = " & iWO_ID
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Sub GetQCFuncAQLResults(ByVal iDevice_ID As Integer, _
         ByRef booQCFuncResult As Boolean, _
         ByRef booAQLResult As Boolean)
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                booQCFuncResult = False
                booAQLResult = False

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * FROM tqc " & Environment.NewLine
                strSql &= "WHERE Device_id = " & iDevice_ID & Environment.NewLine
                strSql &= "ORDER BY QC_ID, QCType_ID, QCResult_ID " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    booQCFuncResult = False
                    booAQLResult = False
                Else
                    If dt.Select("QCType_ID = 1 AND QCResult_ID = 1").Length > 0 Then
                        booQCFuncResult = True
                    End If
                    If dt.Select("QCType_ID = 4").Length = 0 Then
                        booAQLResult = True
                    ElseIf dt.Select("QCType_ID = 4 AND QCResult_ID = 2").Length = 0 Then
                        booAQLResult = True
                    ElseIf dt.Select("QCType_ID = 4 AND QCResult_ID = 2").Length > 0 And dt.Select("QCType_ID = 4 AND QCResult_ID = 1").Length > 0 Then
                        booAQLResult = True
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Sub

        '**************************************************************
        Public Shared Function GetCustIDByMachine() As Integer
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT tcustomer.Cust_ID FROM tcostcentermapping " & Environment.NewLine
                strSql &= "INNER JOIN lwclocation ON tcostcentermapping.WCLocation_ID = lwclocation.WCLocation_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tcostcentermapping.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "INNER JOIN lgroups ON tcostcenter.group_id = lgroups.Group_ID " & Environment.NewLine
                strSql &= " INNER JOIN tcustomer ON group_desc=cust_name1 " & Environment.NewLine
                strSql &= "WHERE lwclocation.WC_Machine like '" & System.Net.Dns.GetHostName & "'" & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetGroupByMachine() As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT group_desc FROM tcostcentermapping " & Environment.NewLine
                strSql &= "INNER JOIN lwclocation ON tcostcentermapping.WCLocation_ID = lwclocation.WCLocation_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tcostcentermapping.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "INNER JOIN lgroups ON tcostcenter.group_id = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE lwclocation.WC_Machine like '" & System.Net.Dns.GetHostName & "'" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                Return dt.Rows(0)("group_desc")
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetCustomerName(ByVal iCustID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Cust_Name1 FROM tcustomer WHERE Cust_ID = " & iCustID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetProductByCustID(ByVal booAddSelectionRow As Boolean, _
           ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT lproduct.Prod_ID, Prod_Desc " & Environment.NewLine
                strSql &= "FROM tcustmarkup " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tcustmarkup.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tcustmarkup.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strSql &= "WHERE tcustomer.Cust_ID = " & iCustID & " " & Environment.NewLine
                strSql &= "ORDER BY Prod_Desc "
                dt = objDataProc.GetDataTable(strSql)
                If booAddSelectionRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetWipOwnerDesc(ByVal iWipOwnerID As Integer) As String
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT wipowner_desc " & Environment.NewLine
                strSql &= "FROM lwipowner " & Environment.NewLine
                strSql &= "WHERE wipowner_id = " & iWipOwnerID & " " & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetLastBillCCID(ByVal iDeviceID As Integer, _
           ByVal iBillCodeID As Integer) As String
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT cc_id " & Environment.NewLine
                strSql &= "FROM tparttransaction " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
                strSql &= "AND BillCode_ID = " & iBillCodeID & Environment.NewLine
                strSql &= "AND Trans_Amount > 0 " & Environment.NewLine
                strSql &= "ORDER BY Trans_ID DESC" & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetThisMonth() As String
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT date_format(now(), '%m') as Month " & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetThisYear() As String
            Dim strSql As String
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT date_format(now(), '%Y') as 'Year' " & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************
        Public Shared Function CloseWO(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""
            Dim iRecQty As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                iRecQty = Generic.GetRecQty(iWOID)

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "UPDATE tworkorder SET WO_RAQnty  = " & iRecQty & ", WO_Closed  = 1 WHERE WO_ID = " & iWOID
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '******************************************************************
        Public Shared Function ReOpenWO(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""
            Dim iRecQty As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                iRecQty = Generic.GetRecQty(iWOID)

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "UPDATE tworkorder SET WO_Closed  = 0 WHERE WO_ID = " & iWOID
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function IsPalletClosed(ByVal iPalletID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim booPalletClosed As Boolean = False
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT Pallett_ReadyToShipFlg, Pallett_ShipDate " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID.ToString & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0"

                dt1 = objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)("Pallett_ReadyToShipFlg") <> 0 Then
                        booPalletClosed = True
                    ElseIf Not IsDBNull(dt1.Rows(0)("Pallett_ShipDate")) AndAlso dt1.Rows(0)("Pallett_ShipDate").ToString.Trim.Length > 0 Then
                        booPalletClosed = True
                    End If
                Else
                    Throw New Exception("Box ID is missing in the system.")
                End If

                Return booPalletClosed
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetDevicePartsCount(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND BillType_ID = 2 " & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function IsValidQCResults(ByVal iDeviceID As Integer, _
           ByVal iQCTypeID As Integer, _
           ByVal strQCTypeDesc As String, _
           ByVal booCheckAQL As Boolean, _
           Optional ByVal booThrowErrMsg As Boolean = True) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strMsg As String = ""

            Try
                IsValidQCResults = False
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tqc " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY QCType_ID " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If dt.Select("QCType_ID = " & iQCTypeID & " AND QCResult_ID = 1").Length = 0 Then
                    'No pass in required qc
                    strMsg = "Device has not been passed at QC (" & strQCTypeDesc & ") test."
                ElseIf dt.Select("QCType_ID = " & iQCTypeID & " AND QCResult_ID = 1").Length = 0 AndAlso dt.Select("QCType_ID = " & iQCTypeID & " AND QCResult_ID = 2").Length > 0 Then
                    'Required qc resulst is fail without pass
                    strMsg = "Device has been failed at QC (" & strQCTypeDesc & ") test."
                ElseIf booCheckAQL = True AndAlso dt.Select("QCType_ID = 4 ").Length > 0 Then
                    If Convert.ToInt32(dt.Select("QCType_ID = 4", "QC_ID DESC")(0)("QCResult_ID")) = 1 Then
                        IsValidQCResults = True
                    Else
                        'AQL failed without pass
                        strMsg = "Device has been failed at AQL test."
                    End If
                Else
                    IsValidQCResults = True
                End If

                If booThrowErrMsg = True AndAlso strMsg.Trim.Length > 0 Then Throw New Exception(strMsg)

                Return IsValidQCResults
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function IsBillcodeExisted(ByVal iDeviceID As Integer, _
          ByVal iBillCodeID As Integer) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt FROM tdevicebill " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID.ToString & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillCodeID.ToString
                If objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function IsBillcodeExisted(ByVal iDeviceID As Integer, _
          ByVal strBillCodeDesc As String) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID.ToString & Environment.NewLine
                strSql &= "AND Billcode_Desc = '" & strBillCodeDesc & "'"
                If objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function IsBillcodeExistedInAWAP(ByVal iDeviceID As Integer, _
          ByVal iBillCodeID As Integer) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT sum(Trans_Amount) as Amt FROM tdevicebillawap " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID.ToString & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillCodeID.ToString & Environment.NewLine
                strSql &= "Having Amt > 0 "
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing : DisposeDT(dt)
            End Try
        End Function
        '***************************************************************************************
        Public Shared Function GetRURReturnToCust(ByVal iDeviceID As Integer) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT RUR_ReturnToCust FROM tcellopt " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID.ToString & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetLocID(ByVal iCustID As Integer, Optional ByVal _iLocID As Integer = 0) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iLocID As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Loc_ID FROM tlocation " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID.ToString & Environment.NewLine
                If _iLocID > 0 Then
                    strSql &= " AND Loc_ID = " & _iLocID.ToString & Environment.NewLine
                End If
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("This customer has more than one Location ID.")
                Else
                    iLocID = dt.Rows(0)("Loc_ID")
                End If
                Return iLocID
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetWONameByWOID(ByVal iWOID As Integer) As String
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim iLocID As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT WO_CustWO FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID.ToString & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function PrintRecReport(ByVal iTray_ID As Integer, _
          ByVal iPrintoutQty As Integer) As Integer
            Dim objRecWksht As RecWorksheet

            Try
                objRecWksht = New RecWorksheet()

                objRecWksht.PrintRecReport(iTray_ID, iPrintoutQty)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetBillCodes(ByVal booAddSelectRow As Boolean, _
           Optional ByVal iProdID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Billcode_ID, Billcode_Desc, BillType_ID FROM lbillcodes " & Environment.NewLine
                If iProdID > 0 Then strSql &= "WHERE Device_ID = " & iProdID & Environment.NewLine
                strSql &= "ORDER BY Billcode_Desc " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetMaxBillRule(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT if(Max(lbillcodes.BillCode_Rule) is null, -1, Max(lbillcodes.BillCode_Rule)) as MaxBillRule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDevice_ID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetMaxBillRuleByBillcodeID(ByVal iBillcodeID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT if(Max(lbillcodes.BillCode_Rule) is null, -1, Max(lbillcodes.BillCode_Rule)) as MaxBillRule " & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "WHERE Billcode_ID = " & iBillcodeID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetDeviceInfoInWIP(ByVal strSN As String, _
           ByVal iCustID As Integer, _
           Optional ByVal iLocID As Integer = 0, _
           Optional ByVal booIncludeCelloptData As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT C.Prod_ID, C.Model_Type, C.Model_Desc, C.Manuf_ID, A.* "

                If iCustID = 2258 OrElse booIncludeCelloptData = True Then
                    strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_SoftVerIN is null, '', D.CellOpt_SoftVerIN) as CellOpt_SoftVerIN " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_SoftVerOUT is null, '', D.CellOpt_SoftVerOUT) as CellOpt_SoftVerOUT " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_MSN is null, '', D.CellOpt_MSN) as CellOpt_MSN " & Environment.NewLine
                    strSql &= ", Cellopt_WIPOwner " & Environment.NewLine
                    strSql &= ", CellOpt_RefurbCompleteDt " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_VerificationID is null, '', D.CellOpt_VerificationID) as CellOpt_VerificationID " & Environment.NewLine

                    If iCustID = 2258 Then
                        strSql &= ", if(E.manuf_date is null, '', E.manuf_date) As 'ManufDate'" & Environment.NewLine
                        strSql &= ", if(E.FuncRep is null, -1, E.FuncRep) as FuncRep " & Environment.NewLine
                    Else
                        strSql &= ", '' As 'ManufDate'" & Environment.NewLine
                        strSql &= ", -1 as FuncRep " & Environment.NewLine
                    End If
                Else
                    strSql &= ", '' as WorkStation, '' as 'ManufDate', -1 as FuncRep " & Environment.NewLine
                End If

                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel C ON A.Model_ID = C.Model_ID " & Environment.NewLine

                If iCustID = 2258 OrElse booIncludeCelloptData = True Then
                    strSql &= "INNER JOIN production.tcellopt D ON A.Device_ID = D.Device_ID " & Environment.NewLine
                    If iCustID = 2258 Then strSql &= "INNER JOIN edi.titem E ON A.device_id = E.device_id " & Environment.NewLine
                End If
                strSql &= String.Format("WHERE A.Device_SN = '{0}' AND Cust_ID = {1}", strSN, iCustID) & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00')"

                If iLocID > 0 Then strSql &= String.Format("AND A.Loc_ID = {0}", iLocID) & Environment.NewLine


                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetDeviceCurrentWorkStation(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT WorkStation" & Environment.NewLine
                strSql &= "FROM tcellopt " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCelloptLastCompletedTech(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT concat(B.User_ID, '-', if(B.user_fullname is null, '', B.user_fullname)) as CompletedTech " & Environment.NewLine
                strSql &= "FROM production.tcellopt A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers B ON A.CellOpt_RefurbCompleteUserID = B.user_id " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCelloptLastCompletedTechOrBiller(ByVal iDeviceID As Integer) As String
            Dim strSql, strTech As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT concat(if(B.User_ID is null, '', B.User_ID) , '-', if(B.user_fullname is null, '', B.user_fullname)) as CompletedTech " & Environment.NewLine
                strSql &= ", concat(if(C.User_ID is null, '', C.User_ID) , '-', if(C.user_fullname is null, '', C.user_fullname)) as Tech " & Environment.NewLine
                strSql &= "FROM production.tcellopt A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers B ON A.CellOpt_RefurbCompleteUserID = B.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers C ON A.CellOpt_TechAssigned = C .user_id " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & " " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    strTech = ""
                ElseIf dt.Rows(0)("CompletedTech").ToString.Trim <> "-" Then
                    strTech = dt.Rows(0)("CompletedTech").ToString.Trim
                ElseIf dt.Rows(0)("Tech").ToString.Trim <> "-" Then
                    strTech = dt.Rows(0)("Tech").ToString.Trim
                Else
                    strTech = ""
                End If

                Return strTech
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetPalletQty(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM production.tdevice " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetPalletAQLPassQty(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) " & Environment.NewLine
                strSql &= "FROM production.tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tqc B ON A.Device_ID = B.Device_ID AND B.QCType_ID = 4 AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "WHERE A.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Shared Function GetPalletAQLFailQty(ByVal iPalletID As Integer) As Integer
            ' CURRENTLY NOT USED.
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) " & Environment.NewLine
                strSql &= "FROM production.tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tqc B ON A.Device_ID = B.Device_ID AND B.QCType_ID = 4 AND QCResult_ID = 2 " & Environment.NewLine
                strSql &= "WHERE A.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetWFMPalletAQLFailQty(ByVal pallet_id As Integer) As Integer
            ' RETURNS THE NUMBER OF FAILED DEVICES
            Dim strSql As String = ""
            Dim objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Try
                Dim _sb As New StringBuilder()
                _sb.Append("SELECT count(d.device_id) as cnt ")
                _sb.Append("FROM production.tdevice d ")
                _sb.Append("INNER JOIN tqc on d.device_id = tqc.device_id ")
                _sb.Append("LEFT JOIN tdevice_triage trg on d.device_id = trg.device_id ")
                _sb.Append("WHERE tqc.qctype_id = 4 ")
                _sb.Append("AND tqc.qcresult_id = 2 ")
                _sb.Append("AND tqc.qc_date > trg.crt_ts ")
                _sb.Append("AND d.pallett_id = " & pallet_id.ToString() & " ")
                _sb.Append(";")
                Return objDataProc.GetIntValue(_sb.ToString())
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetPalletNotAQLPassDevices(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= "FROM production.tdevice A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tqc B ON A.Device_ID = B.Device_ID AND B.QCType_ID = 4 AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "WHERE A.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                strSql &= "AND B.QC_ID is null " & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function UpdatePalletQty(ByVal iPalletID As Integer, _
           ByVal iPalletQty As Integer, _
           Optional ByVal booReopenBox As Boolean = False, _
           Optional ByVal iBoxStatus As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "Update production.tpallett " & Environment.NewLine
                strSql &= "Set Pallett_QTY = " & iPalletQty & Environment.NewLine
                If booReopenBox = True Then strSql &= ", Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                If iBoxStatus > 0 Then strSql &= ", AQL_QCResult_ID = " & iBoxStatus & Environment.NewLine 'Reference this value back to lqcresult table
                strSql &= "WHERE Pallett_ID = " & iPalletID & " " & Environment.NewLine
                Return objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetMachineMapGroupID() As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT tgrouplinemap.Group_ID " & Environment.NewLine
                strSql += "FROM lwclocation " & Environment.NewLine
                strSql += "INNER JOIN tgrouplinemap ON tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID " & Environment.NewLine
                strSql += "WHERE WC_ActiveFlag = 1 " & Environment.NewLine
                strSql += "AND wc_machine = '" & System.Net.Dns.GetHostName & "'"
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetTodayCCEntryCount(ByVal iCCID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM production.tdevice " & Environment.NewLine
                strSql &= "WHERE cc_id = " & iCCID & Environment.NewLine
                strSql &= "AND cc_entrydate = date_format(now(), '%Y-%m-%d');"
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetBillTypeID(ByVal iBillcodeID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT BillType_ID " & Environment.NewLine
                strSql &= "FROM production.lbillcodes " & Environment.NewLine
                strSql &= "WHERE billcode_id = " & iBillcodeID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetDeviceCntInAscbill(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM production.tascbill  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetBillcodeCount(ByVal strBillcodeDesc As String, _
         ByVal iProdID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM production.lbillcodes  " & Environment.NewLine
                strSql &= "WHERE Trim(Billcode_Desc) = '" & strBillcodeDesc & "'" & Environment.NewLine
                strSql &= "AND Device_ID = " & iProdID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetManufactures(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Manuf_ID, Manuf_Desc FROM lmanuf" & Environment.NewLine
                strSql &= "ORDER BY Manuf_Desc " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetManufactureID(ByVal strManufDesc As String) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Manuf_ID FROM lmanuf" & Environment.NewLine
                strSql &= "WHERE Manuf_Desc = '" & strManufDesc & "'" & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function IsDeviceHadParts(ByVal iDeviceID As Integer) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND BillType_ID = 2 " & Environment.NewLine
                If objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetGroupCCProduceQCType(ByVal iGroupID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Produce_QCType_ID " & Environment.NewLine
                strSql &= "FROM lgroups " & Environment.NewLine
                strSql &= "WHERE Group_ID = " & iGroupID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetAQLFailBoxStatus(ByVal iPalletID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT AQL_QCResult_ID " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetDefaultPartsForNTFDevice(ByVal iCustID As Integer, ByVal iModelID As Integer) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Billcode_ID " & Environment.NewLine
                strSql &= "FROM tbilldefaultntfpart " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND Active = 1" & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetMasterGroupsList(ByVal booAddSelectRow As Boolean, _
         Optional ByVal iCustID As Integer = 0) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Group_ID, Group_Desc, Cust_ID FROM lgroups " & Environment.NewLine
                strSql &= "WHERE MasterGroup = 1 AND Active = 1 " & Environment.NewLine
                If iCustID > 0 Then strSql &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "ORDER BY Group_Desc " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--", "0"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function ResetCostCenter(ByVal iDeviceID As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "Update tdevice SET cc_id = 0, CC_EntryDate = null " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetAccessoryCategories() As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * FROM accessorycatergories " & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "Not Accessory"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetNextSeqNoInTtestdata(ByVal iDeviceID As Integer, _
          ByVal iTestTypeID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT IF(MAX(TD_Sequence) is null, 0, MAX(TD_Sequence)) as MaxSeq " & Environment.NewLine
                strSql &= "FROM ttestdata  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql) + 1
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function ChangeModel(ByVal iDeviceID As Integer, _
          ByVal iOldModelID As Integer, _
          ByVal iNewModelID As Integer, _
          ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim i As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "UPDATE tdevice SET Model_ID = " & iNewModelID & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                i = objDataProc.ExecuteNonQuery(strSql)

                strSql = "INSERT INTO changemodelhistory ( Device_ID, OldModel_ID, NewModel_ID, User_ID, ChangeDate " & Environment.NewLine
                strSql &= ") VALUES ( " & iDeviceID & ", " & iOldModelID & ", " & iNewModelID & ", " & iUserID & ", now()" & Environment.NewLine
                strSql &= "); " & Environment.NewLine
                i += objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetModelFamilies(ByVal booAddSelectRow As Boolean) As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSQL As String
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSQL = "SELECT Name AS 'Model Family', ModelFamiliesID" & Environment.NewLine
                strSQL += "FROM cogs.ModelFamilies" & Environment.NewLine
                strSQL += "ORDER BY Name"

                dt = objDataProc.GetDataTable(strSQL)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"--Select--", "0"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetModelFamiliesID(ByVal iModelID As Integer) As Integer
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSQL As String
            Dim iModelFamiliesID As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSQL = "SELECT IFNULL(ModelFamiliesID, 0)" & Environment.NewLine
                strSQL &= "FROM cogs.ModelFamilies" & Environment.NewLine
                strSQL &= String.Format("WHERE FIND_IN_SET('{0}', ModelIDSet) > 0", iModelID)

                dt = objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then iModelFamiliesID = dt.Rows(0)(0)

                Return iModelFamiliesID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetShipToData(ByVal iShipToID As Integer) As DataRow
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSQL As String

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSQL = "SELECT * FROM tshipto WHERE ShipTo_ID = " & iShipToID

                dt = objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function HasQCPassInLastTransaction(ByVal iDeviceID As Integer) As Boolean
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim strSQL As String

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSQL = "SELECT QCResult_ID FROM tqc WHERE device_id = " & iDeviceID & " ORDER BY QC_ID Desc LIMIT 1"

                dt = objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count = 0 Then
                    Return False
                ElseIf dt.Rows(0)("QCResult_ID") = 1 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCustomerMarkup(ByVal iCustomerID As Integer) As Decimal
            Dim strSQL As String
            Dim decCustMarkup As Decimal = 1
            Dim dt As DataTable = Nothing

            Try
                Dim objDataProc As DBQuery.DataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSQL = "SELECT markup_cust" & Environment.NewLine
                strSQL &= "FROM production.tcustmarkup" & Environment.NewLine
                strSQL &= String.Format("WHERE cust_id = {0}", iCustomerID) & Environment.NewLine
                dt = objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then decCustMarkup = 1 + Convert.ToDecimal(dt.Rows(0)(0))

                Return decCustMarkup
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCustomerMarkupByDevice(ByVal iDeviceID As Integer) As Decimal
            Dim strSQL As String
            Dim decCustMarkup As Decimal = 0
            Dim dt As DataTable = Nothing

            Try
                Dim objDataProc As DBQuery.DataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSQL = "SELECT markup_cust" & Environment.NewLine
                strSQL &= "FROM tdevice INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tcustmarkup ON tlocation.Cust_ID = tcustmarkup.Cust_ID AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    decCustMarkup = Convert.ToDecimal(dt.Rows(0)(0))
                Else
                    Throw New Exception("Customer mark up is missing for current product type.")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetBillCodeDesc(ByVal iBillcodeID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Billcode_Desc FROM lbillcodes WHERE Billcode_ID = " & iBillcodeID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetBillCodeID(ByVal strBillcodeDesc As String, ByVal iProdID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Billcode_ID FROM lbillcodes WHERE Billcode_Desc = '" & strBillcodeDesc & "'" & Environment.NewLine
                strSql &= "AND Device_ID = " & iProdID
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetAllPartNumberDesc(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT PSPrice_ID,PSPrice_Desc,PsPrice_Number FROM lpsprice" & Environment.NewLine
                strSql &= " where PSPrice_desc is not null And length(Trim(PSPrice_desc))>0 order by PSPrice_Desc;" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetPartNoDesc(ByVal iPSpriceID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT PsPrice_Number FROM lpsprice WHERE Psprice_ID = " & iPSpriceID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetProductDesc(ByVal iProdID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Prod_Desc FROM lproduct WHERE Prod_ID = " & iProdID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCurrentWorkstaion(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT Workstation FROM tcellopt WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetWorkStationCount(ByVal iCustID As Integer, ByVal strWorkstation As String, Optional ByVal iModelID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as cnt FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE tlocation.Cust_ID = " & iCustID & " AND WorkStation = '" & strWorkstation & "'" & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND tdevice.Model_ID = " & iModelID
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetManufSNDeviceInfoInWIP(ByVal strManufSN As String, _
          ByVal iCustID As Integer, _
          Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.* "

                strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                strSql &= ", if(D.CellOpt_SoftVerIN is null, '', D.CellOpt_SoftVerIN) as CellOpt_SoftVerIN " & Environment.NewLine
                strSql &= ", if(D.CellOpt_SoftVerOUT is null, '', D.CellOpt_SoftVerOUT) as CellOpt_SoftVerOUT " & Environment.NewLine
                strSql &= ", if(D.CellOpt_MSN is null, '', D.CellOpt_MSN) as CellOpt_MSN " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", CellOpt_RefurbCompleteDt " & Environment.NewLine
                strSql &= ", if(D.CellOpt_VerificationID is null, '', D.CellOpt_VerificationID) as CellOpt_VerificationID " & Environment.NewLine

                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine

                strSql &= "INNER JOIN production.tcellopt D ON A.Device_ID = D.Device_ID " & Environment.NewLine

                strSql &= String.Format("WHERE D.Manuf_SN = '{0}' AND Cust_ID = {1}", strManufSN, iCustID) & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00')" & Environment.NewLine

                If iLocID > 0 Then strSql &= String.Format("AND A.Loc_ID = {0}", iLocID) & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetAcceptedWorkStationInWorkFlow(ByVal strScreenName As String, _
          ByVal strCustIDs As String, _
          Optional ByVal iModelID As Integer = 0) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT wfp_FrStation FROM lworkflowprocess " & Environment.NewLine
                strSql &= "WHERE wfp_Inactive = 0 AND Cust_IDs IN ( " & strCustIDs & " ) " & Environment.NewLine
                strSql &= "AND wfp_ScreenName = '" & strScreenName & "'" & Environment.NewLine
                If iModelID > 0 Then strSql &= "AND Model_ID = " & iModelID

                Return objDataProc.GetSingletonString(strSql)
                Debug.WriteLine(strSql)


            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCodesDetailByMasterCode(ByVal booAddSelecRow As Boolean, ByVal iMasterCodeID As Integer, Optional ByVal strSortString As String = "") As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT DCode_ID, DCode_SDesc, DCode_LDesc, DCode_L2Desc, Conv_ID FROM lcodesdetail " & Environment.NewLine
                strSql &= "WHERE Mcode_ID = " & iMasterCodeID & " AND DCode_Inactive = 0 " & Environment.NewLine
                If strSortString.Trim.Length > 0 Then strSql &= "ORDER BY " & strSortString & Environment.NewLine Else strSql &= "ORDER BY DCode_SDesc " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelecRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--", "--Select--", "--Select--", "0"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetConditionDefinitionForRecvDevice(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT DCode_ID, DCode_LDesc, DCode_SDesc FROM lcodesdetail " & Environment.NewLine
                strSql &= "WHERE Mcode_ID = 54 AND Dcode_ID <> 3857 " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--", ""}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetDeviceConditionDefinition(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT DCode_ID, DCode_LDesc, DCode_SDesc FROM lcodesdetail " & Environment.NewLine
                strSql &= "WHERE Mcode_ID = 54 AND Dcode_Inactive = 0 " & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--", ""}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCosmeticGrades(ByVal booAddSelecRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT DCode_ID, DCode_LDesc, DCode_SDesc FROM lcodesdetail " & Environment.NewLine
                strSql &= "WHERE Mcode_ID = 55 AND DCode_Inactive = 0" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelecRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--", ""}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetSelfInflictedReasons(ByVal booAddSelecRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim rowNew As DataRow

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT DCode_ID, DCode_LDesc, DCode_SDesc FROM lcodesdetail " & Environment.NewLine
                strSql &= " WHERE Mcode_ID = 77 AND DCode_Inactive = 0" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                rowNew = dt.NewRow : rowNew("DCode_ID") = 0
                rowNew("DCode_LDesc") = "No Damage" : rowNew("DCode_SDesc") = ""
                dt.Rows.InsertAt(rowNew, 0) : dt.AcceptChanges()

                If booAddSelecRow = True Then dt.LoadDataRow(New Object() {"-1", "--Select--", ""}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetOutBoundCosmeticGrades(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT DCode_LDesc FROM tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tcellopt.OutBoundCosmGradeID = lcodesdetail.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetCelloptData(ByVal iDeviceID As Integer) As DataRow
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT * FROM tcellopt " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function BuildDTWithAutoIncrementID(ByVal strArrData() As String, ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim i As Integer

            Try
                dt.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("Desc", System.Type.GetType("System.String")))
                dt.AcceptChanges()

                For i = 0 To strArrData.Length - 1
                    If strArrData(i).Trim.Length > 0 Then
                        dr = dt.NewRow
                        dr("ID") = i + 1
                        dr("Desc") = strArrData(i).Trim
                        dt.Rows.Add(dr)
                    End If
                Next i

                'dt.DefaultView.Sort = "Desc"
                dt.AcceptChanges()

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function HasPrestestRecord(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT count(*) as 'PrestestCount' FROM tpretest_data " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                If objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function AddMySqlEscapeChar(ByVal strString As String) As String
            Dim strReturnString As String = ""

            Try
                strReturnString = strString.Replace("\", "\\").Replace("'", "\'")
                Return strReturnString
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***************************************************************************************
        Public Shared Function GetBillCodesForReport(ByVal booAddSelectRow As Boolean) As DataTable

            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT TFB_ID,TFB_Desc,TFB_Desc2,TFB_Type,TFB_SubType,tfb_COSFUNC_Order,TFB_Desc_Order" & Environment.NewLine
                strSql &= " FROM tracfonebillcode order by TFB_Desc; "
                dt = objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************
        Public Shared Sub SavePackageMaterialsData(ByVal iCust_ID As Integer, _
         ByVal iModel_ID As Integer, _
         ByVal iPSPrice_ID As Integer, _
         ByVal iQty As Integer, _
         ByVal strLastUpdateDT As String, _
         ByVal iLastUpdateUserID As Integer, _
         ByRef strErrMsg As String)

            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim pKey As Integer = 0
            Dim iOldQty As Integer = 0
            Dim strOldLastUpdateDT As String, DTime As Date
            Dim iOldLastUpdateUserID As Integer
            Dim i As Integer = 0

            Dim strFields As String = "Cust_ID,Model_ID,PSPrice_ID,Qty,LastUpdateDT,LastUpdateUserID"

            Try

                strErrMsg = ""
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = " SELECT * FROM tpackagingusage WHERE Cust_ID=" & iCust_ID & " AND Model_ID=" & iModel_ID & " AND PSPrice_ID=" & iPSPrice_ID & ";" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 1 Then    'found, so update and insert
                    pKey = dt.Rows(0).Item("PU_ID")
                    iOldQty = dt.Rows(0).Item("Qty")
                    If IsDate(dt.Rows(0).Item("LastUpdateDT")) Then
                        DTime = dt.Rows(0).Item("LastUpdateDT")
                        strOldLastUpdateDT = Format(DTime, "yyyy-MM-dd HH:mm:ss")
                    End If
                    'strOldLastUpdateDT = dt.Rows(0).Item("LastUpdateDT")
                    iOldLastUpdateUserID = dt.Rows(0).Item("LastUpdateUserID")

                    'Same record, no need to update
                    If iOldQty = iQty Then
                        strErrMsg = "Already exists. No need to change." : Exit Sub
                    End If

                    'tpackagingusage
                    strSql = "UPDATE tpackagingusage SET " & Environment.NewLine
                    strSql &= " Qty =" & iQty & ", LastUpdateDT='" & strLastUpdateDT & "'," & Environment.NewLine
                    strSql &= " LastUpdateUserID =" & iLastUpdateUserID & " WHERE PU_ID =" & pKey & ";" & Environment.NewLine
                    i = objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then strErrMsg &= "Failed to Update table tPackagingUsage." & Environment.NewLine

                    'tpackagingusage_Hist
                    i = 0
                    strSql = "INSERT INTO tpackagingusage_Hist (" & strFields & ")" & Environment.NewLine
                    strSql &= " VALUES (" & iCust_ID & "," & iModel_ID & "," & iPSPrice_ID & "," & Environment.NewLine
                    strSql &= iOldQty & ",'" & strOldLastUpdateDT & "'," & iOldLastUpdateUserID & ");" & Environment.NewLine
                    i = objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then strErrMsg &= "Failed to Insert Into table tPackagingUsage_Hist." & Environment.NewLine
                ElseIf dt.Rows.Count = 0 Then    'new, so insert
                    'tpackagingusage
                    i = 0
                    strSql = "INSERT INTO tpackagingusage (" & strFields & ")" & Environment.NewLine
                    strSql &= " VALUES (" & iCust_ID & "," & iModel_ID & "," & iPSPrice_ID & "," & Environment.NewLine
                    strSql &= iQty & ",'" & strLastUpdateDT & "'," & iLastUpdateUserID & ");" & Environment.NewLine
                    i = objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then strErrMsg &= "Failed to Insert Into table tPackagingUsage." & Environment.NewLine

                    'tpackagingusage_Hist
                    'i = 0
                    'strSql = "INSERT INTO tpackagingusage_Hist (" & strFields & ")" & Environment.NewLine
                    'strSql &= " VALUES (" & iCust_ID & "," & iModel_ID & "," & iPSPrice_ID & "," & Environment.NewLine
                    'strSql &= iQty & ",'" & strLastUpdateDT & "'," & iLastUpdateUserID & ");" & Environment.NewLine
                    'i = objDataProc.ExecuteNonQuery(strSql)
                    'If i = 0 Then strErrMsg &= "Failed to Insert Into table tPackagingUsage_Hist." & Environment.NewLine
                Else
                    strErrMsg &= "Failed to save. Found duplicate rows." & Environment.NewLine
                End If

            Catch ex As Exception
                'Throw ex
                strErrMsg &= ex.ToString
            Finally
                objDataProc = Nothing
                DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Public Shared Function GetSMTPServer() As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT Server FROM reports.smtp" & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetTasksEmailInfo(ByVal strTaskName As String, ByVal strLineOfBussiness As String, ByVal bSMTPSvr As Boolean) As DataRow
            Dim strSql, strSMTPSer As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                strSql = "" : strSMTPSer = ""
                strSql = "SELECT A.Name, A.OutputPath, A.LineOfBusiness, A.Subject, A.Body, A.InputPath, A.ReportInfoID" & Environment.NewLine
                strSql &= ", B.Addresses, B.ErrorAddresses, B.EmailFromID, B.EmailFromPW, '' as 'SmtpServer' " & Environment.NewLine
                strSql &= "FROM reports.reportinfo A INNER JOIN reports.emails B ON A.ReportInfoID = B.ReportInfoID" & Environment.NewLine
                strSql &= "WHERE A.Name = '" & strTaskName & "' AND LineOfBusiness = '" & strLineOfBussiness & "'"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If bSMTPSvr AndAlso dt.Rows.Count > 0 Then
                    strSql = "SELECT Server FROM reports.smtp" & Environment.NewLine
                    strSMTPSer = objDataProc.GetSingletonString(strSql)
                    dt.Rows(0).BeginEdit() : dt.Rows(0)("SmtpServer") = strSMTPSer : dt.Rows(0).EndEdit()
                End If

                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************
        Public Shared Sub ParseEmailAddress(ByVal strEmails As String, _
           ByRef strFrom As String, ByRef strTo As String, ByRef strCC As String, ByRef strBCC As String)
            Try
                Dim strArr() As String
                Dim i As Integer

                strArr = strEmails.Split(Convert.ToChar("|"))
                For i = 0 To strArr.Length - 1
                    If strArr(i).Trim.ToUpper.StartsWith("FROM:") Then strFrom = strArr(i).Trim.ToLower.Replace("from:", "")
                    If strArr(i).Trim.ToUpper.StartsWith("TO:") Then strTo = strArr(i).Trim.ToLower.Replace("to:", "")
                    If strArr(i).Trim.ToUpper.StartsWith("CC:") Then strCC = strArr(i).Trim.ToLower.Replace("cc:", "")
                    If strArr(i).Trim.ToUpper.StartsWith("BCC:") Then strBCC = strArr(i).Trim.ToLower.Replace("bcc:", "")
                Next i

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************
        Public Shared Function GetDevicesInWO(ByVal iWO_ID As String) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tdevice WHERE WO_ID = " & iWO_ID
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************

#Region "Excel Methods"

        Public Shared Function GetExcelColumnName(ByVal iColumnNumber As Integer) As String

            Dim iDividend As Integer = iColumnNumber
            Dim strColumnName As String = String.Empty
            Dim iModulo As Integer

            Try
                While iDividend > 0
                    iModulo = (iDividend - 1) Mod 26
                    strColumnName = Convert.ToChar(65 + iModulo).ToString() + strColumnName
                    iDividend = Convert.ToInt32((iDividend - iModulo) / 26)
                End While

                Return strColumnName

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Sub CreateBorders(ByVal xlWS As Excel.Worksheet, ByVal iFirstCol As Integer, ByVal iFirstRow As Integer, ByVal iLastCol As Integer, ByVal iLastRow As Integer)
            Dim xlBI() As Excel.XlBordersIndex = { _
             Excel.XlBordersIndex.xlEdgeLeft, _
             Excel.XlBordersIndex.xlEdgeTop, _
             Excel.XlBordersIndex.xlEdgeBottom, _
             Excel.XlBordersIndex.xlEdgeRight, _
             Excel.XlBordersIndex.xlInsideVertical, _
             Excel.XlBordersIndex.xlInsideHorizontal}

            Try
                Dim i As Integer
                Dim strStartRange As String = GetCellPosition(GetExcelColumnName(iFirstCol), iFirstRow)
                Dim strEndRange As String = GetCellPosition(GetExcelColumnName(iLastCol), iLastRow)

                xlWS.Range(strStartRange, strEndRange).Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                xlWS.Range(strStartRange, strEndRange).Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                For i = 0 To xlBI.Length - 1
                    If Not ((iLastRow - iFirstRow = 0 And i = 5) Or (iLastCol - iFirstCol = 0 And i = 4)) Then       'Can't draw inside borders for these cases

                        xlWS.Range(strStartRange, strEndRange).Borders(xlBI(i)).LineStyle = Excel.XlLineStyle.xlContinuous
                        xlWS.Range(strStartRange, strEndRange).Borders(xlBI(i)).Weight = Excel.XlBorderWeight.xlThin
                        xlWS.Range(strStartRange, strEndRange).Borders(xlBI(i)).ColorIndex = Excel.Constants.xlAutomatic
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetCellPosition(ByVal strColumn As String, ByVal iRow As Integer) As String
            Try
                Return String.Format("{0}{1}", strColumn, iRow)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Sub DeleteExcelSheetsExcept(ByVal xlWB As Excel.Workbook, ByVal strKeep() As String)
            Try
                Dim i As Integer

                For i = xlWB.Sheets.Count To 1 Step -1    'Worksheets are indexed on 1
                    Dim xlWS As Excel.Worksheet = xlWB.Sheets(i)
                    Dim strSheetName As String = xlWS.Name

                    If strKeep.IndexOf(strKeep, strSheetName) = -1 Then xlWB.Sheets(i).Delete()
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region 'Excel Methods

        '***************************************************************************************
        Public Shared Function DateOfPreviousWeek(ByVal fromDate As DateTime, ByVal dayOfWeek As DayOfWeek, ByVal PreviousWeeksNum As Integer) As DateTime
            Dim start As Integer = CInt(fromDate.DayOfWeek)
            Dim target As Integer = CInt(dayOfWeek)
            Dim DiffDays As Integer = 0
            Dim resDate As Date

            If PreviousWeeksNum < 0 Then PreviousWeeksNum = 0

            If target <= start Then
                DiffDays = start - target
                resDate = fromDate.AddDays(-(DiffDays + 7 * PreviousWeeksNum))
            Else
                DiffDays = target - start
                resDate = fromDate.AddDays(+(DiffDays - 7 * PreviousWeeksNum))
            End If

            Return resDate
        End Function

        '***************************************************************************************
        Public Shared Function GetPrinterName(ByVal strPrinterDesc As String) As String
            Dim strSql As String = "", strPrinterName As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tprinter WHERE Printer_Desc = '" & strPrinterDesc & "' AND Active = 1 "
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate record for printer " & strPrinterDesc & ".")
                Else
                    strPrinterName = dt.Rows(0)("PrinterName")
                End If

                Return strPrinterName
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetModelIDByModelDesc(ByVal strModelDesc As String) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim iModelID As Integer

            Try
                strSql = "SELECT Model_ID FROM tmodel WHERE Model_Desc = '" & strModelDesc & "' "
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate record in tmodel.")
                ElseIf dt.Rows.Count = 0 Then
                    iModelID = 0
                Else
                    iModelID = dt.Rows(0)("Model_ID")
                End If

                Return iModelID
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function GetModelPartData(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT B.Model_desc AS 'Model',E.PSPrice_Desc AS 'Part (Box)',A.Qty" & Environment.NewLine
                strSql &= " ,'Mapped' AS 'Status_Desc',E.PSPrice_Number AS'Part Number',E.PSPrice_stndCost AS 'Std. Cost'" & Environment.NewLine
                strSql &= " ,A.LastUpdateDT,F.user_fullname AS 'Update User'" & Environment.NewLine
                strSql &= " ,A.Model_ID,A.PSPRice_ID,A.LastUpdateUserID,'0' AS 'Status',A.PU_ID" & Environment.NewLine
                strSql &= " FROM tpackagingusage A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lpsprice E ON A.Psprice_ID = E.Psprice_ID" & Environment.NewLine
                strSql &= " LEFT JOIN security.tusers F ON A.lastupdateUserID=F.User_ID" & Environment.NewLine
                strSql &= " WHERE cust_ID=" & iCust_ID & ";" & Environment.NewLine

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        '***************************************************************************************
        Public Shared Function DeleteModelPartData(ByVal iPu_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "DELETE FROM tpackagingusage" & Environment.NewLine
                strSql &= " WHERE Pu_ID=" & iPu_ID & ";" & Environment.NewLine

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '***************************************************************************************
        Public Shared Function DataViewAsDataTable(ByVal dv As DataView) As DataTable
            Dim drv As DataRowView
            Dim dt As DataTable = dv.Table.Clone
            Try
                For Each drv In dv
                    dt.ImportRow(drv.Row)
                Next
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************

        Public Shared Function GetBoxQty(ByVal BoxNr As String) As Int16
            Dim _retVal As Int16 = 0
            Dim _dt As New DataTable()
            Dim strSql As New StringBuilder()
            Dim objDataProc As DBQuery.DataProc
            Try
                strSql.Append("SELECT ")
                strSql.Append("COUNT(A.ITEM_ID) AS QTY ")
                strSql.Append("FROM edi.titem A ")
                strSql.Append("INNER JOIN edi.twarehousebox E ON A.wb_id = E.wb_id ")
                strSql.Append("WHERE E.BOXID = '")
                strSql.Append(BoxNr)
                strSql.Append("';")
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                _dt = objDataProc.GetDataTable(strSql.ToString())
                _retVal = _dt.Rows(0)(0)
                Return _retVal
            Catch
                Return 0
            End Try
        End Function

        'Get the first day of the month
        Public Shared Function GetFirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
            Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
        End Function

        'Get the last day of the month
        Public Shared Function GetLastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
            Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
            Return lastDay.AddMonths(1).AddDays(-1)
        End Function


        Public Shared Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
            Dim builder As New StringBuilder()
            Dim random As New Random()
            Dim ch As Char
            Dim i As Integer = 0

            Threading.Thread.Sleep(10) 'must put this, otherwise, give the same string. Not sure why

            For i = 0 To size - 1
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)))
                builder.Append(ch)
            Next
            random = Nothing
            If lowerCase Then
                Return builder.ToString().ToLower()
            End If
            Return builder.ToString()
        End Function

    End Class
End Namespace
