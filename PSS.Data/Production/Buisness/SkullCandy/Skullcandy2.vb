Option Explicit On 

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Namespace Buisness
    Public Class Skullcandy2

        Public Const strReadyToSave As String = "Ready to save"
        Public Const strInvalid As String = "Invalid"
        Public Const strInserted As String = "Inserted"
        Public Const strUpdated As String = "Updated"
        Public Const strNoChange As String = "No change"
        Public Const strSQLFailed As String = "SQL Failed"

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


#End Region

#Region "Skullcandy Retail - Load Excel IP/MP data"


        Public Function LoadExcelData(ByVal strExcelPathFile As String, _
                                      ByRef strErrMsg As String) As DataTable
            'Data must be in Excel Sheet 1
            'First row has header names

            Dim HeaderNames As ArrayList = GetRequiredHeaderNames()
            Dim dt As DataTable = ExcelTableDefinition()
            Dim row As DataRow
            Dim objV As Object

            Dim UsedRowsNum1 As Integer = 0, UsedColsNum1 As Integer = 0
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, myIndex As Integer
            Dim strColName As String = "", strTmp As String = ""

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet1 As Excel.Worksheet = Nothing
            'Dim xlWorkSheet2 As Excel.Worksheet = Nothing

            Try
                strErrMsg = ""
                If File.Exists(strExcelPathFile) Then
                    xlWorkBook = xlApp.Workbooks.Open(strExcelPathFile)

                    xlWorkSheet1 = xlWorkBook.Worksheets(1)
                    xlWorkSheet1.Select()
                    UsedRowsNum1 = xlWorkBook.ActiveSheet.UsedRange.Rows.Count()
                    UsedColsNum1 = xlWorkBook.ActiveSheet.UsedRange.Columns.Count()

                    'Get row number util empty cell (first col, rows)
                    For i = 1 To UsedRowsNum1
                        If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, 1).value) Then '.Range("A" & i).Value
                            Exit For
                        ElseIf Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, 1).value) Then
                            Exit For
                        ElseIf xlWorkSheet1.Cells(i, 1).value Is "" Or xlWorkSheet1.Cells(i, 1).value Is Nothing Then
                            Exit For
                        Else
                            strTmp = xlWorkSheet1.Cells(i, 1).value
                            If strTmp.Trim.Length > 0 Then
                                UsedRowsNum1 = i
                            Else
                                Exit For
                            End If
                        End If
                    Next

                    'Get colmun number until empty cell (first row, cols)
                    Try
                        For j = 1 To UsedColsNum1
                            objV = xlWorkSheet1.Cells(1, j).value
                            If objV Is Nothing Then
                                UsedColsNum1 = j - 1 : Exit For 'if empty, stop
                            End If
                            strTmp = xlWorkSheet1.Cells(1, j).value
                            If Not strTmp.Trim.Length > 0 Then
                                UsedColsNum1 = j - 1 : Exit For 'if spaces, stop
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                    MessageBox.Show("UsedRowsNum1 =" & UsedRowsNum1 & "   UsedColsNum1=" & UsedColsNum1)

                    '1. Validate header names:----------------------------------------------------
                    If UsedRowsNum1 > 1 AndAlso UsedColsNum1 >= HeaderNames.Count Then
                        For j = 1 To HeaderNames.Count 'get header names
                            strColName = xlWorkSheet1.Cells(1, j).value
                            If Not HeaderNames.Contains(strColName.Trim) Then
                                strErrMsg = "Invalid header name(s) in Excel file." : Exit Function
                            End If
                        Next 'j
                    Else
                        strErrMsg = "No enough rows or columns  Excel file." : Exit Function
                    End If


                    '3. Load Data---------------------------------------------------------------------------------------------
                    'Load Excdel data into datatable
                    For i = 2 To UsedRowsNum1 'go through each row of the Excelsheet
                        row = dt.NewRow()
                        row("RowID") = i - 1 'col 0
                        For k = 0 To HeaderNames.Count - 1  'each column
                            j = k + 1

                            objV = xlWorkSheet1.Cells(i, j).value
                            If objV Is Nothing Then
                                strErrMsg = "Excel file has no data in cell(" & i & ":" & j & ") ." : Exit Function
                            End If
                            strTmp = xlWorkSheet1.Cells(i, 1).value
                            If Not strTmp.Trim.Length > 0 Then
                                strErrMsg = "Excel file has no data in cell(" & i & ":" & j & ") ." : Exit Function
                            End If

                            Select Case j
                                Case 4, 5, 6
                                    If Not IsNumeric(objV) Then
                                        strErrMsg = "Excel file has non-numeric data in cell(" & i & ":" & j & ") ." : Exit Function
                                    End If
                            End Select
                            row(j) = xlWorkSheet1.Cells(i, j).value
                        Next
                        dt.Rows.Add(row)
                    Next


                    If Not IsNothing(xlWorkSheet1) Then
                        PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                    End If

                    If Not IsNothing(xlWorkBook) Then
                        xlWorkBook.Close(False)
                        PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                    End If
                    If Not IsNothing(xlApp) Then
                        xlApp.Quit()
                        PSS.Data.Buisness.Generic.NAR(xlApp)
                    End If

                    Return dt

                End If

            Catch ex As Exception
                strErrMsg = "Function LoadExcelData: " & ex.ToString
                Return dt
            Finally
                If Not IsNothing(xlWorkSheet1) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                End If
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                End If
            End Try

        End Function


        '******************************************************************
        Public Function LoadExcelData_FastWay(ByVal strExcelPathFile As String, _
                                              ByVal strDateTime As String, _
                                              ByRef strErrMsg As String) As DataTable

            Dim strSheetName As String = "DataReady"
            Dim arrRequiredNames As ArrayList = GetRequiredHeaderNames()
            Dim dt As New DataTable() '= ExcelTableDefinition()
            Dim row As DataRow, col As DataColumn, i As Integer = 0, iCount As Integer = 0
            Dim bValidSheetName As Boolean = False, bFound As Boolean = False
            Dim strColName As String = ""
            Dim arrUnrequiredCols As New ArrayList()

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing

            Dim HDR As String = "Yes" 'if no header, set to no

            Dim strConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strExcelPathFile & ";Extended Properties=""Excel 8.0;HDR=" & HDR & ";IMEX=1"""


            Try
                xlApp.DisplayAlerts = False
                xlApp.Visible = False
                xlApp.EnableEvents = False

                'Validate file and sheet name
                If File.Exists(strExcelPathFile) Then
                    xlWorkBook = xlApp.Workbooks.Open(strExcelPathFile)
                    'xlWorkSheet = xlWorkBook.Worksheets(1)
                    'xlWorkSheet.Select()

                    'Check valid sheet name
                    For i = 1 To xlWorkBook.Worksheets.Count
                        xlWorkSheet = CType(xlWorkBook.Worksheets(i), Excel.Worksheet)
                        If strSheetName.ToUpper = xlWorkSheet.Name().Trim.ToUpper Then
                            bValidSheetName = True : Exit For
                        End If
                        If Not bValidSheetName Then
                            strErrMsg = "No sheet name '" & strSheetName & "' in the file " & strExcelPathFile : Exit Function
                        End If
                    Next
                Else
                    strErrMsg = "Can't find this file: " & strExcelPathFile : Exit Function
                End If

                Try
                    xlWorkBook.Save()
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet)
                    xlWorkBook.Close()
                    xlWorkBook = Nothing
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                Catch ex As Exception
                End Try

                'Ready to load----------------------------------------------------------------
                Dim objConn As New OleDbConnection()
                Dim dtAdapter As OleDbDataAdapter
                Dim strSQL As String


                objConn = New OleDbConnection(strConn)
                objConn.Open()

                strSQL = "SELECT * FROM [" & strSheetName & "$]"
                dtAdapter = New System.Data.OleDb.OleDbDataAdapter(strSQL, objConn)
                dtAdapter.Fill(dt)

                Try
                    dtAdapter = Nothing : dtAdapter.Dispose()
                    objConn.Close() : objConn = Nothing : objConn.Dispose()
                    objConn.ConnectionString = Nothing
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                Catch ex As Exception
                End Try

                If dt.Rows.Count > 0 Then
                    For Each col In dt.Columns
                        bFound = False : strColName = col.ColumnName
                        'If arrRequiredNames.Contains(strColName) = True Then 'not working?
                        '    iCount += 1
                        'Else
                        '    arrUnrequiredCols.Add(strColName)
                        'End If
                        For i = 0 To arrRequiredNames.Count - 1
                            If strColName.Trim.ToUpper = arrRequiredNames(i) Then
                                bFound = True : Exit For
                            End If
                        Next
                        If bFound Then
                            iCount += 1
                        Else
                            arrUnrequiredCols.Add(strColName)
                        End If
                    Next
                    If iCount <> arrRequiredNames.Count Then
                        strErrMsg = "No enough columns (header names) in this file: " & strExcelPathFile : Exit Function
                    Else
                        'remove unwaned cols if any
                        For i = 0 To arrUnrequiredCols.Count - 1
                            dt.Columns.Remove(arrUnrequiredCols(i))
                        Next
                        'remove empty rows
                        For Each row In dt.Rows
                            Dim tmpS As String = ""
                            For i = 0 To dt.Columns.Count - 1
                                If Not row.IsNull(i) Then
                                    tmpS &= row(i)
                                End If
                            Next
                            If Not tmpS.Trim.Length > 0 Then
                                row.Delete()
                            End If
                        Next
                        dt.AcceptChanges()
                        'add new cols and add addtional data
                        dt.Columns.Add("RowID", GetType(Integer))
                        dt.Columns.Add("UpdateDatetime", GetType(String))
                        i = 0
                        For Each row In dt.Rows
                            i += 1 : row("RowID") = i : row("UpdateDatetime") = strDateTime
                        Next
                        ''add new col for invalid =1 and valid=0
                        'Dim newColumn As New System.Data.DataColumn("Invalid", GetType(Integer))
                        'newColumn.DefaultValue = 0
                        'dt.Columns.Add(newColumn)
                        'add new col for status of updated or Inserted
                        Dim newColumn2 As New System.Data.DataColumn("Status", GetType(String))
                        newColumn2.DefaultValue = strReadyToSave
                        dt.Columns.Add(newColumn2)

                        dt.AcceptChanges()

                        Dim colOrder() As Integer = {6, 0, 1, 2, 3, 4, 5, 8, 7}
                        Dim ReorderedDT As DataTable = ReOrderTable(dt, colOrder)
                        dt = ReorderedDT
                    End If
                Else
                    strErrMsg = "No data in this file: " & strExcelPathFile : Exit Function
                End If

                Return dt
                '-----------------------------------------------------------------------------
            Catch ex As Exception
                strErrMsg = "Function LoadExcelData: " & ex.ToString
                Return dt
            Finally
                If Not IsNothing(xlWorkSheet) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet)
                End If
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                End If
            End Try
        End Function


        Public Function ReOrderTable(ByVal dt_in As DataTable, ByVal ColumnOrder() As Integer) As DataTable
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim c, c_in, key() As DataColumn
            Dim i As Integer
            dt.TableName = dt_in.TableName
            ' copy the schema of each columns
            For i = 0 To UBound(ColumnOrder)
                c_in = dt_in.Columns(ColumnOrder(i))
                c = New DataColumn(c_in.ColumnName)
                c.DataType = c_in.DataType
                c.AllowDBNull = c_in.AllowDBNull
                c.MaxLength = c_in.MaxLength
                c.AutoIncrement = c_in.AutoIncrement
                c.AutoIncrementSeed = c_in.AutoIncrementSeed
                c.AutoIncrementStep = c_in.AutoIncrementStep
                dt.Columns.Add(c)
            Next
            ' copy the primary keys
            ReDim key(UBound(dt_in.PrimaryKey))
            For i = 0 To UBound(dt_in.PrimaryKey)
                key(i) = dt.Columns(dt_in.PrimaryKey(i).ColumnName)
            Next
            dt.PrimaryKey = key
            ' copy the data
            For Each dr In dt_in.Rows()
                dt.ImportRow(dr)
            Next
            Return dt
        End Function

        'Private Function GetSheetData(ByVal strExcelPathFile As String, ByVal strSheetName As String, ByVal dSet As DataSet) As System.Data.DataTable

        '    Dim objConn As New OleDbConnection()
        '    Dim dtAdapter As OleDbDataAdapter
        '    Dim strSQL As String
        '    Dim HDR As String = "Yes" 'if no header, set to no
        '    Dim strConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strExcelPathFile & ";Extended Properties=""Excel 8.0;HDR=" & HDR & ";IMEX=1"""


        '    objConn = New OleDbConnection(strConn)
        '    objConn.Open()

        '    strSQL = "SELECT * FROM [" & strSheetName & "$]"
        '    dtAdapter = New System.Data.OleDb.OleDbDataAdapter(strSQL, objConn)

        '    dtAdapter.Fill(dSet)
        '    dtAdapter.SelectCommand.Dispose()
        '    dtAdapter.Dispose()
        '    dtAdapter = Nothing
        '    objConn.ConnectionString = Nothing
        '    objConn.Close()
        '    objConn.Dispose()
        '    objConn = Nothing
        '    GC.Collect()
        '    GC.WaitForPendingFinalizers()
        '    GC.Collect()
        '    GC.WaitForPendingFinalizers()

        '    Return dSet.Tables(0)

        'End Function
        '******************************************************************
        Public Function ExcelTableDefinition() As DataTable
            Dim dTB As New DataTable()
            Dim row As DataRow
            dTB.Columns.Add("RowID", GetType(Integer))
            dTB.Columns.Add("UPC", GetType(String))
            dTB.Columns.Add("Sku", GetType(String))
            dTB.Columns.Add("Family", GetType(String))
            dTB.Columns.Add("InnerPackQty", GetType(Integer))
            dTB.Columns.Add("MasterPackQty", GetType(Integer))
            dTB.Columns.Add("TotalContents", GetType(Integer))
            dTB.Columns.Add("UpdateDatetime", GetType(String))

            Return dTB
        End Function

        '******************************************************************
        Public Function GetRequiredHeaderNames() As ArrayList
            Dim arrNames As New ArrayList()
            Dim tmpDT As DataTable = ExcelTableDefinition()
            Dim i As Integer = 0, tmpS As String = ""

            Try
                For i = 0 To tmpDT.Columns.Count - 1
                    tmpS = tmpDT.Columns(i).ColumnName.ToUpper.Trim
                    If Not (tmpS = "RowID".ToUpper Or tmpS = "UpdateDatetime".ToUpper) Then
                        arrNames.Add(tmpS)
                    End If
                Next
                tmpDT = Nothing

                Return arrNames

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '******************************************************************
        Public Function SQLResultDatatableDefinition() As DataTable
            Dim dTB As New DataTable()
            Dim row As DataRow
            dTB.Columns.Add("RowID", GetType(Integer))
            dTB.Columns.Add("SQLResult", GetType(Integer))
            dTB.Columns.Add("Status", GetType(String))
            Return dTB
        End Function
        '******************************************************************
        'Public Function GetHeaderNames() As ArrayList
        '    Dim arrNames As New ArrayList()
        '    Try
        '        arrNames.Add("UPC_Code") : arrNames.Add("Model Number")
        '        arrNames.Add("Family") : arrNames.Add("Inner Pack (IP) Qty.")
        '        arrNames.Add("Master Pack (MP) Qty.") : arrNames.Add("Total Contents")

        '        Return arrNames

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Function

        '******************************************************************
        Public Function Save_Retail_InnerMasterPackData(ByVal dt As DataTable, ByVal strPathFileName As String, ByVal iUserID As Integer, ByVal strMsg As String) As DataTable
            Dim strSQL As String
            Dim iIdx As Integer
            Dim row, newRow As DataRow
            Dim dt2 As DataTable
            Dim i As Integer = 0
            Dim dtSQLResult As DataTable = SQLResultDatatableDefinition()

            Try
                Dim strFileName As String = Path.GetFileName(strPathFileName)

                'check if UPS  exist
                For Each row In dt.Rows
                    i = 0
                    If row("Status") = Me.strReadyToSave Then
                        strSQL = "Select Concat(trim(A.UPC),trim(A.Sku),trim(A.Family),A.InnerPAckQty,A.MasterPackQty,A.TotalContents) as RowString" & _
                                 ",A.* from tsk_packaging A where A.UPC='" & row("UPC") & " '"
                        dt2 = Me._objDataProc.GetDataTable(strSQL)

                        If dt2.Rows.Count > 0 Then 'update
                            Dim strTmp As String = ""
                            Dim strS As String = "" ' row("UPC") & row("Sku") & row("Family") & row("InnerPackQty") & row("MasterPackQty") & row("TotalContents")
                            If Not row.IsNull("UPC") Then strTmp = row("UPC") : strS &= strTmp.Trim
                            If Not row.IsNull("Sku") Then strTmp = row("Sku") : strS &= strTmp.Trim
                            If Not row.IsNull("Family") Then strTmp = row("Family") : strS &= strTmp.Trim
                            If Not row.IsNull("InnerPackQty") Then strTmp = row("InnerPackQty") : strS &= strTmp.Trim
                            If Not row.IsNull("MasterPackQty") Then strTmp = row("MasterPackQty") : strS &= strTmp.Trim
                            If Not row.IsNull("TotalContents") Then strTmp = row("TotalContents") : strS &= strTmp.Trim

                            strTmp = dt2.Rows(0).Item("RowString")
                            If Not strTmp.ToUpper = strS.ToUpper Then 'need update
                                strSQL = "UPDATE tsk_packaging SET Sku='" & row("Sku") & "',Family='" & row("Family") & "'," & _
                                                                 "InnerPackQty=" & row("InnerPackQty") & ",MasterPackQty=" & row("MasterPackQty") & "," & _
                                                                 "TotalContents=" & row("TotalContents") & "," & "UserID=" & iUserID & "," & _
                                                                 "UpdateDatetime='" & row("UpdateDatetime") & "',LoadedFileName='" & strFileName & "'" & _
                                                                 " WHERE UPC='" & row("UPC") & "';"
                                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                                newRow = dtSQLResult.NewRow
                                If i = 0 Then
                                    newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strSQLFailed
                                Else
                                    newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strUpdated
                                    'Save log of old data
                                    Dim oldDTimeStr As String = Format(dt2.Rows(0).Item("UpdateDatetime"), "yyyy-MM-dd HH:mm:ss")
                                    strSQL = "INSERT INTO Tracker.tsk_packaging_Log" & _
                                            " (UPC,Sku,Family,InnerPackQty,MasterPackQty,TotalContents,UserID,UpdateDatetime,LoadedFileName,Log_UserID,Log_UpdateDatetime)" & _
                                            " VALUES ('" & dt2.Rows(0).Item("UPC") & "','" & _
                                            dt2.Rows(0).Item("Sku") & "','" & _
                                            dt2.Rows(0).Item("Family") & "'," & _
                                            dt2.Rows(0).Item("InnerPackQty") & "," & _
                                            dt2.Rows(0).Item("MasterPackQty") & "," & _
                                            dt2.Rows(0).Item("TotalContents") & "," & _
                                            dt2.Rows(0).Item("UserID") & ",'" & _
                                            oldDTimeStr & "','" & _
                                            dt2.Rows(0).Item("LoadedFileName") & "'," & _
                                            iUserID & ",'" & _
                                            row("UpdateDatetime") & "');"
                                    i = Me._objDataProc.ExecuteNonQuery(strSQL)
                                End If
                                dtSQLResult.Rows.Add(newRow) : dtSQLResult.AcceptChanges()
                            Else
                                newRow = dtSQLResult.NewRow
                                newRow("RowID") = row("RowID") : newRow("SQLResult") = 0 : newRow("Status") = Me.strNoChange
                                dtSQLResult.Rows.Add(newRow) : dtSQLResult.AcceptChanges()
                            End If
                        Else 'insert new
                            strSQL = "INSERT INTO tsk_packaging (UPC,Sku,Family,InnerPackQty,MasterPackQty,TotalContents,UserID,UpdateDatetime,LoadedFileName)" & _
                                     " Values ('" & row("UPC") & "','" & _
                                     row("Sku") & "','" & row("Family") & "'," & _
                                     row("InnerPackQty") & "," & row("MasterPackQty") & "," & _
                                     row("TotalContents") & "," & iUserID & ",'" & row("UpdateDatetime") & "','" & _
                                     strFileName & "');"
                            i = Me._objDataProc.ExecuteNonQuery(strSQL)
                            newRow = dtSQLResult.NewRow
                            If i = 0 Then
                                newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strSQLFailed
                            Else
                                newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strInserted
                            End If
                            dtSQLResult.Rows.Add(newRow) : dtSQLResult.AcceptChanges()
                        End If
                    End If
                Next

                ''debug
                'Dim S As String = ""
                'For Each row In dtSQLResult.Rows
                '    S &= row("RowID") & "     " & row("SQLResult") & "     " & row("Status") & Environment.NewLine
                'Next
                'MessageBox.Show(S)

                Return dtSQLResult

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function Get_Retail_InnerMasterPackData() As DataTable
            Dim strSQL As String

            Try
                strSQL = "Select * from tsk_packaging;"
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "Skullcandy Retail - Reports"
        '******************************************************************
        'Public Function GetSKRetail_Invenotry(ByVal iCustID As Integer, Optional ByVal strLoc As String = "") As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT A.RMA,A.UPC,A.Sku,B.DCode_LDesc as 'Disposition',C.Pallett_Name as 'PalletName',C.WHLocation,A.DCode_ID,A.Pallet_ID,count(A.UPC) AS Qty" & Environment.NewLine
        '        strSql &= " FROM tsk_device A" & Environment.NewLine
        '        strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN tpallett C ON A.Pallet_ID=C.Pallett_ID" & Environment.NewLine
        '        strSql &= " WHERE C.pkslip_ID IS NULL" & Environment.NewLine
        '        strSql &= " GROUP BY A.RMA,A.UPC,A.Sku,B.DCode_SDesc,C.Pallett_Name,A.DCode_ID,A.Pallet_ID;" & Environment.NewLine

        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Function

        '******************************************************************************************************************************
        Public Function CreateSKRetail_InvenotryReport(ByVal strRptName As String) As Integer
            Dim strSql, strFileName As String
            Dim dt As DataTable
            Dim objArrData(,) As Object
            Dim i, j As Integer
            Dim objSaveFileDialog As New SaveFileDialog()
            Dim objXL As Excel.Application
            Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                strSql = "" : strFileName = ""
                strSql = "SELECT A.RMA,A.UPC,A.Sku,B.DCode_LDesc as 'Disposition',C.Pallett_Name as 'PalletName',C.WHLocation,A.DCode_ID,A.Pallet_ID,count(A.UPC) AS Qty" & Environment.NewLine
                strSql &= " FROM tsk_device A" & Environment.NewLine
                strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN tpallett C ON A.Pallet_ID=C.Pallett_ID" & Environment.NewLine
                strSql &= " WHERE C.pkslip_ID IS NULL" & Environment.NewLine
                strSql &= " GROUP BY A.RMA,A.UPC,A.Sku,B.DCode_SDesc,C.Pallett_Name,A.DCode_ID,A.Pallet_ID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    objXL = New Excel.Application()
                    objWorkbook = objXL.Workbooks.Add

                    ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)

                    '***************************************
                    'Assign Data to array
                    '***************************************
                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To dt.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption
                            objArrData(i + 1, j) = dt.Rows(i)(j)
                        Next j
                    Next i

                    objXL.Application.DisplayAlerts = False
                    objSheet = objWorkbook.Worksheets("Sheet1")

                    objXL.Columns("B:E").Select()                'Select columns
                    objXL.Selection.NumberFormat = "@"

                    '********************************
                    'Post data to excel sheet
                    '********************************
                    With objSheet
                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                        With objXL.Selection
                            '.WrapText = True
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            '.Font.ColorIndex = 5
                            .Interior.ColorIndex = 37
                            .Interior.Pattern = Excel.Constants.xlSolid
                        End With

                        .Cells.EntireColumn.AutoFit()
                        .Cells.EntireRow.AutoFit()

                        objSaveFileDialog.DefaultExt = "xls"
                        objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(Now()).ToString("yyyyMMdd") & ".xls" '& Convert.ToDateTime(strDateStart).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strDateEnd).ToString("yyyyMMdd") & ".xls"
                        objSaveFileDialog.ShowDialog()
                        strFileName = objSaveFileDialog.FileName

                        If strFileName.Trim.Length = 0 Then
                            MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If strFileName.IndexOf("\") < 0 Then Exit Function
                            If File.Exists(strFileName) = True Then Kill(strFileName)
                            objWorkbook.SaveAs(strFileName)
                            MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End With
                    '********************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objArrData = Nothing
                Generic.DisposeDT(dt)
                If Not IsNothing(objSaveFileDialog) Then
                    objSaveFileDialog.Dispose()
                    objSaveFileDialog = Nothing
                End If
                If Not IsNothing(objSheet) Then
                    PSS.Data.Buisness.Generic.NAR(objSheet)
                End If
                If Not IsNothing(objWorkbook) Then
                    objWorkbook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(objWorkbook)
                End If
                If Not IsNothing(objXL) Then
                    objXL.Quit()
                    PSS.Data.Buisness.Generic.NAR(objXL)
                End If
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CreateSKRetail_WIPReport(ByVal strRptName As String) As Integer
            Dim strSql, strFileName As String
            Dim dt As DataTable
            Dim objArrData(,) As Object
            Dim i, j As Integer
            Dim objSaveFileDialog As New SaveFileDialog()
            Dim objXL As Excel.Application
            Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                strSql = "" : strFileName = ""
                'strSql = " SELECT A.RMA,A.UPC,A.Sku,B.DCode_LDesc as 'Disposition',C.Pallett_Name as 'PalletName',C.WHLocation,A.Rec_Date as 'ReceivedDate',A.DCode_ID,A.Pallet_ID,count(A.UPC) AS Qty" & Environment.NewLine
                'strSql &= " FROM tsk_device A" & Environment.NewLine
                'strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                'strSql &= " INNER JOIN tpallett C ON A.Pallet_ID=C.Pallett_ID" & Environment.NewLine
                'strSql &= " WHERE C.pkslip_ID IS NULL" & Environment.NewLine
                'strSql &= " GROUP BY A.RMA,A.UPC,A.Sku,B.DCode_SDesc,C.Pallett_Name,A.DCode_ID,A.Pallet_ID" & Environment.NewLine
                'strSql &= " UNION ALL"
                'strSql &= " SELECT A.RMA,A.UPC,A.Sku,B.DCode_LDesc as 'Disposition','' as 'PalletName','' as 'WHLocation',A.Rec_Date as 'ReceivedDate',A.DCode_ID,A.Pallet_ID,count(A.UPC) AS Qty" & Environment.NewLine
                'strSql &= " FROM tsk_device A" & Environment.NewLine
                'strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                'strSql &= " WHERE A.Pallet_ID is null or A.Pallet_ID<=0" & Environment.NewLine
                'strSql &= " GROUP BY A.RMA,A.UPC,A.Sku,B.DCode_SDesc,A.DCode_ID,A.Pallet_ID;" & Environment.NewLine

                strSql = "  SELECT A.RMA,A.UPC,A.Sku,B.DCode_LDesc as 'Disposition',C.Pallett_Name as 'PalletName',C.WHLocation,A.Location as 'Prod_Location'" & Environment.NewLine
                strSql &= ",A.Rec_Date as 'Received_Date',D.User_FullName as 'Received_User',A.DCode_ID,A.Pallet_ID,A.SC_DeviceID,A.MP_ID" & Environment.NewLine
                strSql &= " FROM tsk_device A" & Environment.NewLine
                strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSql &= " INNER JOIN tpallett C ON A.Pallet_ID=C.Pallett_ID" & Environment.NewLine
                strSql &= " LEFT JOIN Security.tusers D ON A.Rec_UserID=D.User_ID" & Environment.NewLine
                strSql &= " WHERE C.pkslip_ID IS NULL" & Environment.NewLine
                strSql &= " UNION ALL" & Environment.NewLine
                strSql &= " SELECT A.RMA,A.UPC,A.Sku,B.DCode_LDesc as 'Disposition','' as 'PalletName','' as 'WHLocation',A.Location as 'Prod_Location'" & Environment.NewLine
                strSql &= ",A.Rec_Date as 'Received_Date',D.User_FullName as 'Received_User',A.DCode_ID,A.Pallet_ID,A.SC_DeviceID,A.MP_ID" & Environment.NewLine
                strSql &= " FROM tsk_device A" & Environment.NewLine
                strSql &= " INNER JOIN lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSql &= " LEFT JOIN Security.tusers D ON A.Rec_UserID=D.User_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallet_ID is null or A.Pallet_ID<=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    objXL = New Excel.Application()
                    objWorkbook = objXL.Workbooks.Add

                    ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)

                    '***************************************
                    'Assign Data to array
                    '***************************************
                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To dt.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption
                            objArrData(i + 1, j) = dt.Rows(i)(j)
                        Next j
                    Next i

                    objXL.Application.DisplayAlerts = False
                    objSheet = objWorkbook.Worksheets("Sheet1")

                    objXL.Columns("B:E").Select()                'Select columns
                    objXL.Selection.NumberFormat = "@"

                    '********************************
                    'Post data to excel sheet
                    '********************************
                    With objSheet
                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                        With objXL.Selection
                            '.WrapText = True
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            '.Font.ColorIndex = 5
                            .Interior.ColorIndex = 37
                            .Interior.Pattern = Excel.Constants.xlSolid
                        End With
                        .Columns("H:H").NumberFormat = "m/d/yyyy"
                        .Cells.EntireColumn.AutoFit()
                        .Cells.EntireRow.AutoFit()

                        objSaveFileDialog.DefaultExt = "xls"
                        objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(Now()).ToString("yyyyMMdd") & ".xls" '& Convert.ToDateTime(strDateStart).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strDateEnd).ToString("yyyyMMdd") & ".xls"
                        objSaveFileDialog.ShowDialog()
                        strFileName = objSaveFileDialog.FileName

                        If strFileName.Trim.Length = 0 Then
                            MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If strFileName.IndexOf("\") < 0 Then Exit Function
                            If File.Exists(strFileName) = True Then Kill(strFileName)
                            objWorkbook.SaveAs(strFileName)
                            MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End With
                    '********************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objArrData = Nothing
                Generic.DisposeDT(dt)
                If Not IsNothing(objSaveFileDialog) Then
                    objSaveFileDialog.Dispose()
                    objSaveFileDialog = Nothing
                End If
                If Not IsNothing(objSheet) Then
                    PSS.Data.Buisness.Generic.NAR(objSheet)
                End If
                If Not IsNothing(objWorkbook) Then
                    objWorkbook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(objWorkbook)
                End If
                If Not IsNothing(objXL) Then
                    objXL.Quit()
                    PSS.Data.Buisness.Generic.NAR(objXL)
                End If
            End Try
        End Function

        '******************************************************************************************************************************
        Public Sub CreateSKRetail_InvoiceRpt(ByVal strRptName As String, ByVal iCust_ID As Integer, _
                                             ByVal strBegDate As String, ByVal strEndDate As String, ByRef dtResult As DataTable)

            Dim strFileName As String
            Dim dtReceived, dtCharge, dtServiceType, dtOutput As DataTable
            Dim arrlstCharges As New ArrayList(), arrlstRMAs As New ArrayList()
            Dim iDCode_ID As Integer, dActualCharge As Double
            Dim strChargeType As String ', strServiceType As String
            Dim arrlstUniqueRMA As New ArrayList()
            Dim oArrData As Object(,)
            Dim row As DataRow, col As DataColumn
            Dim i, j, k, m As Integer

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim rng As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value

            Dim objSaveFileDialog As New SaveFileDialog()

            Dim objSkullcandy As PSS.Data.Buisness.Skullcandy

            Try

                objSkullcandy = New PSS.Data.Buisness.Skullcandy()

                'Get Data------------------------------------------------------------------------------------------------------------------------
                'service Type data
                dtServiceType = getRetailInvoice_ServiceTypeData()

                'Charge data
                dtCharge = getRetailInvoice_ChargeData()

                For Each row In dtCharge.Rows
                    If Not arrlstCharges.Contains(row("RC_Type")) Then
                        arrlstCharges.Add(row("RC_Type"))
                    End If
                Next

                'Received data
                dtReceived = getRetailInvoice_ReceivedData(iCust_ID, strBegDate, strEndDate, dtServiceType, arrlstCharges)

                'dtResult = dtReceived
                'Exit Sub

                'Stop if no data
                If Not dtReceived.Rows.Count > 0 Then
                    Throw New Exception("No data for your selection!")
                End If

                'Get unique RMA
                For Each row In dtReceived.Rows
                    If Not arrlstRMAs.Contains(row("RMA")) Then
                        arrlstRMAs.Add(row("RMA"))
                    End If
                Next
                For Each row In dtReceived.Rows
                    iDCode_ID = row("DCode_ID")
                    For i = 0 To arrlstCharges.Count - 1
                        strChargeType = arrlstCharges(i)
                        dActualCharge = getCharge(dtCharge, iDCode_ID, strChargeType)
                        row.BeginEdit()
                        row(row("ServiceType")) = row("Quantity")
                        row("Unit " & strChargeType) = dActualCharge
                        row(strChargeType) = Math.Round(dActualCharge * row("Quantity"), 2)
                        row.EndEdit()
                    Next
                Next

                'Final Output
                dtOutput = getOutputDatatableDef(dtServiceType, arrlstCharges)
                dtOutput.Rows(0).Delete() : dtOutput.AcceptChanges()
                For Each row In dtReceived.Rows
                    Dim row2 As DataRow = dtOutput.NewRow
                    For Each col In dtOutput.Columns
                        row2(col.ColumnName) = row(col.ColumnName)
                    Next
                    dtOutput.Rows.Add(row2)
                    If Not arrlstUniqueRMA.Contains(row("RMA")) Then
                        arrlstUniqueRMA.Add(row("RMA"))
                    End If
                Next

                If Not dtOutput.Rows.Count > 0 Then
                    Throw New Exception("No data for your selection!")
                End If

                dtResult = dtOutput

                'Create Excel ------------------------------------------------------------------------------------------------------------------------
                xlApp.Visible = False : xlApp.DisplayAlerts = False

                xlApp = New Excel.Application()
                xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)

                'Add new worksheets as needed
                If arrlstUniqueRMA.Count >= 3 Then
                    For m = 3 To arrlstUniqueRMA.Count - 1 + 1  'one sheet one RMA, plus summary sheet
                        xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet) 'Add sheet
                        xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count)) 'Move to the last 
                    Next
                End If

                For k = 0 To arrlstUniqueRMA.Count - 1  'each RMA
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(k + 1), Excel._Worksheet)

                    xlWorkSheet.Columns(1).NumberFormat = "@" : xlWorkSheet.Columns(2).NumberFormat = "@"
                    xlWorkSheet.Columns(3).NumberFormat = "@"

                    Dim dtTmp As DataTable
                    dtTmp = dtOutput.Clone

                    Dim tmpRows() As DataRow = dtOutput.Select("RMA = '" & arrlstUniqueRMA(k) & "'")
                    For Each row In tmpRows
                        dtTmp.ImportRow(row)
                    Next
                    Dim RowsNum As Integer = dtTmp.Rows.Count
                    Dim ColsNum As Integer = dtTmp.Columns.Count
                    ReDim oArrData(RowsNum + 1, ColsNum)

                    For i = 0 To dtTmp.Rows.Count - 1
                        For j = 0 To dtTmp.Columns.Count - 1
                            If i = 0 Then oArrData(i, j) = dtTmp.Columns(j).ColumnName
                            oArrData(i + 1, j) = dtTmp.Rows(i)(j)
                        Next j
                    Next i

                    xlWorkSheet.Range("A1" & ":" & CalExcelColLetter(dtTmp.Columns.Count) & (dtTmp.Rows.Count + 1)).Value = oArrData
                    'Header bold 
                    rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, ColsNum))
                    rng.Font.Bold = True
                    'xlWorkSheet.Range("A1:P1").Font.Bold = True

                    xlWorkSheet.Name = arrlstUniqueRMA(k)

                    ' rng =  xlWorkSheet.Range(CalExcelColLetter(3) & "1"
                    rng = xlWorkSheet.Range(CalExcelColLetter(8) & "2:" & CalExcelColLetter(8) & dtTmp.Rows.Count + 1.ToString)
                    rng.Formula = "=SUM(D2:G2)"
                    rng = xlWorkSheet.Range(CalExcelColLetter(13) & "2:" & CalExcelColLetter(13) & dtTmp.Rows.Count + 1.ToString)
                    rng.Formula = "=SUM(I2:L2)"

                    rng = xlWorkSheet.Range(CalExcelColLetter(4) & dtTmp.Rows.Count + 2.ToString & ":" & CalExcelColLetter(13) & dtTmp.Rows.Count + 2.ToString)
                    rng.Formula = "=SUM(D2:D" & dtTmp.Rows.Count + 1.ToString & ")"

                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'Summary sheet
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(arrlstUniqueRMA.Count + 1), Excel._Worksheet)
                    xlWorkSheet.Name = "Summary"
                    If k = 0 Then
                        xlWorkSheet.Cells(1, 1) = "RMA" : xlWorkSheet.Cells(1, 2) = "Seal factory" : xlWorkSheet.Cells(1, 3) = "B-Stock" : xlWorkSheet.Cells(1, 4) = "Scrap"
                        xlWorkSheet.Cells(1, 5) = "C-Stock" : xlWorkSheet.Cells(1, 6) = "Total Qty" : xlWorkSheet.Cells(1, 7) = "Receiving" : xlWorkSheet.Cells(1, 8) = "Label Removal"
                        xlWorkSheet.Cells(1, 9) = "Audio Testing" : xlWorkSheet.Cells(1, 10) = "Packaging" : xlWorkSheet.Cells(1, 11) = "Total"
                        'Header bold
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, ColsNum))
                        rng.Font.Bold = True
                        'xlWorkSheet.Range("A1:Q1").Font.Bold = True
                    End If

                    xlWorkSheet.Cells(k + 2, 1) = "'" & arrlstUniqueRMA(k)
                    rng = xlWorkSheet.Range(CalExcelColLetter(2) & k + 2.ToString & ":" & CalExcelColLetter(7) & k + 2.ToString)
                    rng.Formula = "='" & arrlstUniqueRMA(k) & "'!" & CalExcelColLetter(4) & dtTmp.Rows.Count + 2.ToString
                    rng = xlWorkSheet.Range(CalExcelColLetter(8) & k + 2.ToString & ":" & CalExcelColLetter(10) & k + 2.ToString)
                    rng.Formula = "='" & arrlstUniqueRMA(k) & "'!" & CalExcelColLetter(10) & dtTmp.Rows.Count + 2.ToString
                    rng = xlWorkSheet.Range(CalExcelColLetter(11) & k + 2.ToString & ":" & CalExcelColLetter(11) & k + 2.ToString)
                    rng.Formula = "=SUM(G" & (k + 2).ToString & ":J" & (k + 2).ToString & ")"
                    If k = arrlstUniqueRMA.Count - 1 Then
                        rng = xlWorkSheet.Range(CalExcelColLetter(2) & k + 3.ToString & ":" & CalExcelColLetter(11) & k + 3.ToString)
                        rng.Formula = "=SUM(B2" & ":B" & (k + 2).ToString & ")"
                    End If
                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()
                Next


                objSaveFileDialog.DefaultExt = "xls"
                objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(strBegDate).ToString("yyyyMMdd") & "_" & _
                                             Convert.ToDateTime(strEndDate).ToString("yyyyMMdd") & ".xls"
                objSaveFileDialog.ShowDialog()
                strFileName = objSaveFileDialog.FileName

                If strFileName.Trim.Length = 0 Then
                    MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If strFileName.IndexOf("\") < 0 Then Exit Sub
                    If File.Exists(strFileName) = True Then Kill(strFileName)
                    xlWorkBook.SaveAs(strFileName)
                    MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            Finally

                Generic.DisposeDT(dtReceived) : Generic.DisposeDT(dtCharge)
                Generic.DisposeDT(dtServiceType) : Generic.DisposeDT(dtOutput)
                If Not IsNothing(objSaveFileDialog) Then
                    objSaveFileDialog.Dispose()
                    objSaveFileDialog = Nothing
                End If
                If Not IsNothing(xlWorkSheet) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet)
                End If
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                End If
            End Try
        End Sub

        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getRetailInvoice_ServiceTypeData() As DataTable
            Dim strSQL As String
            Dim dt As New DataTable()

            Try

                strSQL = "Select DCode_ID,DCode_SDesc,DCode_LDesc from lcodesdetail where  mCode_ID=62 and DCode_Inactive=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getOutputDatatableDef(ByVal dtServiceTypeData As DataTable, ByVal arrlstChargeType As ArrayList) As DataTable

            Dim strSQL As String = "select '' AS RMA, '' AS UPC, '' AS Sku"
            Dim dt As New DataTable()
            Dim row As DataRow
            Dim i As Integer

            Try
                For Each row In dtServiceTypeData.Rows
                    strSQL &= ", 0 AS '" & row("DCode_LDesc") & "'"
                Next
                strSQL &= ",0 AS 'Total Qty'"

                For i = 0 To arrlstChargeType.Count - 1
                    strSQL &= ", 0.00 AS '" & arrlstChargeType(i) & "'"
                Next
                strSQL &= ",0.00 AS 'Total Charge'"

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getRetailInvoice_ChargeData() As DataTable
            Dim strSQL As String
            Dim dt As New DataTable()

            Try

                strSQL = "select A.DCode_ID,C.DCode_SDesc,C.DCode_LDesc" & Environment.NewLine
                strSQL &= " ,A.RC_ID,B.RC_Type,B.RC_Value,Active" & Environment.NewLine
                strSQL &= " ,IF(Active=1,RC_Value,0) AS 'ActualCharge'" & Environment.NewLine
                strSQL &= " from tSKRetailChargesMap A" & Environment.NewLine
                strSQL &= " Inner Join tSKRetailCharges B On A.RC_ID=B.RC_ID" & Environment.NewLine
                strSQL &= " Inner Join lcodesdetail C On A.DCode_ID=C.DCode_ID and C.DCode_Inactive=0;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try

        End Function


        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getRetailInvoice_ReceivedData(ByVal iCust_ID As Integer, ByVal strBegDate As String, ByVal strEndDate As String, _
                                                           ByVal dtServiceTypeData As DataTable, ByVal arrlstChargeType As ArrayList) As DataTable
            Dim strSQL As String
            Dim dt As New DataTable()
            Dim row As DataRow
            Dim i As Integer

            Try

                'SELECT A.BR_ID,A.RMA,A.DCode_ID,concat('''',A.UPC) AS UPC,A.Quantity,A.RecDate,B.DCode_LDesc AS 'ServiceType'" & Environment.NewLine
                strSQL = "SELECT A.RMA,A.DCode_ID,A.UPC,A.Sku,1 AS 'Quantity',A.Rec_Date as 'RecDate',B.DCode_LDesc AS 'ServiceType'" & Environment.NewLine

                For Each row In dtServiceTypeData.Rows
                    strSQL &= ", 0 AS '" & row("DCode_LDesc") & "'"
                Next
                strSQL &= ",0 AS 'Total Qty'"

                For i = 0 To arrlstChargeType.Count - 1
                    strSQL &= ", 0.00 AS 'Unit " & arrlstChargeType(i) & "'"
                Next
                For i = 0 To arrlstChargeType.Count - 1
                    strSQL &= ", 0.00 AS '" & arrlstChargeType(i) & "'"
                Next
                strSQL &= ",0.00 AS 'Total Charge'" ',B.DCode_LDesc AS 'ServiceType',A.Rec_Date AS 'ReceivedDate',A.DCode_ID,B.DCode_SDesc"

                strSQL &= " FROM tsk_Device A" & Environment.NewLine
                strSQL &= " INNER JOIN lcodesdetail B On A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSQL &= " WHERE A.Cust_ID=" & iCust_ID & Environment.NewLine
                strSQL &= " AND A.Rec_Date BETWEEN '" & strBegDate & " 00:00:00'" & Environment.NewLine
                strSQL &= " AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                'strSQL &= " GROUP BY A.RMA,A.UPC,A.Sku,B.DCode_LDesc" ',A.DCode_ID,B.DCode_SDesc" & Environment.NewLine
                'strSQL &= " ORDER BY A.RMA,A.UPC,A.Sku;"

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************************
        Public Sub CreateSKAstro_InvoiceRpt(ByVal strRptName As String, ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, _
                                             ByVal strBegDate As String, ByVal strEndDate As String, ByRef dtResult As DataTable)

            Dim ds As New DataSet()
            Dim strFileName As String = ""
            Dim RowsNum, ColsNum As Integer
            Dim TopHeaderRowNum As Integer = 1
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim rng As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim oArrData As Object(,)
            Dim i, j, k, m As Integer
            Dim strErrMsg As String = ""
            Dim objSaveFileDialog As New SaveFileDialog()

            Try
                'Add many tables to ds as needed.
                ds = GetInvoiceData_Astro(iCust_ID, iLoc_ID, strBegDate, strEndDate)

                If ds.Tables.Count > 0 Then 'AndAlso (ds.Tables("Wrty Claim Processing").Rows.Count > 0 ) Then
                    xlApp = New Excel.Application()
                    xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)

                    'Add new worksheets as needed
                    If ds.Tables.Count > 3 Then
                        For m = 3 To ds.Tables.Count - 1
                            xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet) 'Add sheet
                            xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count)) 'Move to the last 
                        Next
                    End If

                    'Populate data into Excel
                    For k = 0 To ds.Tables.Count - 1 'Go through each table
                        'Initial sheet
                        xlWorkSheet = DirectCast(xlWorkBook.Sheets(k + 1), Excel._Worksheet)

                        'Get counts of rows and columns
                        RowsNum = ds.Tables(k).Rows.Count
                        ColsNum = ds.Tables(k).Columns.Count
                        ReDim oArrData(RowsNum + 1, ColsNum)

                        ''add header
                        'For j As Integer = 0 To ColsNum - 1
                        '    xlWorkSheet.Cells(TopHeaderRowNum, j + 1) = ds.Tables(k).Columns(j).ColumnName
                        'Next

                        ''Populate data into excel sheet
                        'For r As Integer = 0 To RowsNum - 1
                        '    For j As Integer = 0 To ds.Tables(k).Columns.Count - 1
                        '        If ds.Tables(k).Columns(j).Caption.Trim.EndsWith("$") Then
                        '            ' If Not ds.Tables(k).Rows(r).IsNull(j) Then
                        '            xlWorkSheet.Cells(r + TopHeaderRowNum + 1, j + 1) = FormatCurrency(ds.Tables(k).Rows(r).Item(j))
                        '            'End If
                        '        Else
                        '            xlWorkSheet.Cells(r + TopHeaderRowNum + 1, j + 1) = ds.Tables(k).Rows(r).Item(j)
                        '        End If
                        '    Next
                        'Next

                        For i = 0 To ds.Tables(k).Rows.Count - 1
                            For j = 0 To ds.Tables(k).Columns.Count - 1
                                If i = 0 Then oArrData(i, j) = ds.Tables(k).Columns(j).ColumnName
                                If ds.Tables(k).Columns(j).Caption.Trim.EndsWith("$") Then oArrData(i + 1, j) = FormatCurrency(ds.Tables(k).Rows(i)(j)) Else oArrData(i + 1, j) = ds.Tables(k).Rows(i)(j)
                            Next j
                        Next i

                        'When no data
                        If ds.Tables(k).Rows.Count = 0 Then
                            xlWorkSheet.Cells(TopHeaderRowNum + 1, 1) = "No data"
                        Else
                            xlWorkSheet.Range("A1" & ":" & CalExcelColLetter(ds.Tables(k).Columns.Count) & (ds.Tables(k).Rows.Count + 1)).Value = oArrData
                            xlWorkSheet.Columns("A:A").NumberFormat = "###0"
                            xlWorkSheet.Columns("B:B").NumberFormat = "m/d/yyyy"
                            xlWorkSheet.Columns("C:C").NumberFormat = "m/d/yyyy"
                        End If

                        'Set Sheet name
                        xlWorkSheet.Name = ds.Tables(k).TableName

                        'Header bold 'and color
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(TopHeaderRowNum, 1), xlWorkSheet.Cells(TopHeaderRowNum, ColsNum))
                        rng.Font.Bold = True ': rng.Interior.ColorIndex = 15

                        'Auto Fit
                        xlWorkSheet.Cells.EntireColumn.AutoFit()
                        xlWorkSheet.Cells.EntireRow.AutoFit()

                        'Freeze Top Row
                        Try
                            'xlWorkSheet.Activate()
                            xlWorkSheet.Application.ActiveWindow.SplitRow = 1
                            xlWorkSheet.Application.ActiveWindow.FreezePanes = True
                        Catch ex As Exception
                        End Try
                    Next k

                    objSaveFileDialog.DefaultExt = "xls"
                    objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(strBegDate).ToString("yyyyMMdd") & "_" & _
                                                 Convert.ToDateTime(strEndDate).ToString("yyyyMMdd") & ".xls"
                    objSaveFileDialog.ShowDialog()
                    strFileName = objSaveFileDialog.FileName

                    If strFileName.Trim.Length = 0 Then
                        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If strFileName.IndexOf("\") < 0 Then Exit Sub
                        If File.Exists(strFileName) = True Then Kill(strFileName)
                        xlWorkBook.SaveAs(strFileName)
                        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    'Clean/Release 
                    If Not IsNothing(xlWorkSheet) Then
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet)
                    End If
                    If Not IsNothing(xlWorkBook) Then
                        'objWorkbook.Close(False)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
                    End If
                    If Not IsNothing(xlApp) Then
                        xlApp.Quit()
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                    End If

                    GC.Collect() : GC.WaitForPendingFinalizers()
                    GC.Collect() : GC.WaitForPendingFinalizers()
                Else
                    strErrMsg &= vbCrLf & "Alert - Skullcandy_Biz.CreateInvoiceReport_Astro." & vbCrLf & "No data for invoice period " & Convert.ToDateTime(strBegDate).ToString("MM/dd/yyyy") & "-" & Convert.ToDateTime(strEndDate).ToString("MM/dd/yyyy") & "."
                End If

            Catch ex As Exception
                Throw New Exception("Err - Skullcandy_Biz.CreateInvoiceReport_Astro." & vbCrLf & ex.ToString)
            Finally
                Try
                    Generic.DisposeDS(ds)
                    If Not IsNothing(xlWorkSheet) Then
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet)
                    End If
                    If Not IsNothing(xlWorkBook) Then
                        'objWorkbook.Close(False)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
                    End If
                    If Not IsNothing(xlApp.Application) Then
                        xlApp.Quit()
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                    End If
                    GC.Collect() : GC.WaitForPendingFinalizers()
                    GC.Collect() : GC.WaitForPendingFinalizers()
                Catch
                End Try
            End Try

            'Return strFileName
        End Sub

        '******************************************************************************************************************************
        Public Function GetInvoiceData_Astro(ByVal iCustID As Integer, ByVal iLocID As Integer, _
                                                        ByVal strDateStart As String, ByVal strDateEnd As String) As DataSet
            Dim strSql As String = ""
            Dim ds As New DataSet()
            Dim dt, dtServiceBillcode, dtAggBilling, dtAggModelBilling, dtDeviceBill As DataTable
            Dim R1, R2 As DataRow
            Dim i As Integer

            dt = Nothing : dtServiceBillcode = Nothing : dtAggBilling = Nothing : dtAggModelBilling = Nothing

            Try
                'tcab_ID, billcode_id, tcab_Amount, Cust_ID, LastUpdateDT, LastUpdateUserID
                strSql = "SELECT IF(B.cust_IncomingSku is null, '', B.cust_IncomingSku) as 'Bundle Model', A.* " & Environment.NewLine
                strSql &= "FROM tcustaggregatebilling A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map B ON A.Cust_ID = B.Cust_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & Environment.NewLine
                dtAggBilling = Me._objDataProc.GetDataTable(strSql)
                'trans_id, cust_id, model_id, billcode_id, labor_charge
                strSql = "SELECT IF(B.cust_IncomingSku is null, '', B.cust_IncomingSku) as 'Bundle Model', A.*" & Environment.NewLine
                strSql &= "FROM tcust_model_aggbilling_default A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID AND A.Cust_ID = B.Cust_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & Environment.NewLine
                dtAggModelBilling = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT Distinct B.BillCode_ID, C.Billcode_Desc" & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tdevicebill B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes C ON B.Billcode_ID = C.Billcode_ID" & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND A.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "ORDER BY C.Billcode_ID"
                dtServiceBillcode = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT H.PO as 'RMA_PA', A.Device_ID, C.Billcode_ID, C.Billcode_Desc" & Environment.NewLine
                strSql &= ", IF((F.labor_charge is not null AND F.labor_charge > 0), F.labor_charge, IF( E.tcab_Amount is null, 0.0, E.tcab_Amount)) as 'Amount' " & Environment.NewLine
                strSql &= ", IF(G.cust_IncomingSku is null, '', G.cust_IncomingSku) as 'Bundle Model', A.Model_ID " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tdevicebill B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes C ON B.Billcode_ID = C.Billcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN tlocation D ON A.Loc_ID = D.Loc_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustaggregatebilling E ON B.Billcode_ID = E.Billcode_ID AND D.Cust_ID = E.Cust_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcust_model_aggbilling_default F ON A.Model_ID = F.Model_ID AND B.Billcode_ID = F.Billcode_ID AND D.Cust_ID = F.Cust_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map G ON A.Model_ID = G.Model_ID AND D.Cust_ID = D.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline H ON A.WO_ID = H.WO_ID" & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND A.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                dtDeviceBill = Me._objDataProc.GetDataTable(strSql)

                '**********************************************
                'Get Summary data
                '**********************************************
                strSql = "SELECT E.PO as 'RMA_PA', D.BillCode_ID, A.Model_ID, B.Model_desc as Model, D.Billcode_Desc as 'Service Provided', 0 as Quantity " & Environment.NewLine
                strSql &= ", 0.0 as 'Unit Price $', 0.0 as 'Total Price $' " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tmodel B ON A.model_ID = B.model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill C ON A.device_ID = C.device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes D ON C.BillCode_ID = D.BillCode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline E ON A.WO_ID = E.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND A.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "AND D.BillCode_ID <> 2549 " & Environment.NewLine
                strSql &= "GROUP BY E.PO, Model, Billcode_Desc"

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Astro Summary"
                ds.Tables.Add(dt) : ds.AcceptChanges()

                For Each R1 In ds.Tables("Astro Summary").Rows
                    R1.BeginEdit()

                    If dtDeviceBill.Select("Model_ID = " & R1("Model_ID") & " AND Billcode_Desc = '" & R1("Service Provided") & "'").Length > 0 Then
                        R1("Quantity") = dtDeviceBill.Select("RMA_PA = '" & R1("RMA_PA") & "' AND Model_ID = " & R1("Model_ID") & " AND Billcode_Desc = '" & R1("Service Provided") & "'").Length
                    Else
                        R1("Quantity") = 0
                    End If


                    If Not IsDBNull(dtDeviceBill.Compute("sum(Amount)", "Model_ID = " & R1("Model_ID") & " AND Billcode_Desc = '" & R1("Service Provided") & "'")) Then
                        R1("Total Price $") = dtDeviceBill.Compute("sum(Amount)", "RMA_PA = '" & R1("RMA_PA") & "' AND Model_ID = " & R1("Model_ID") & " AND Billcode_Desc = '" & R1("Service Provided") & "'")
                    Else
                        R1("Total Price $") = 0
                    End If

                    If dtAggModelBilling.Select("Model_ID = " & R1("Model_ID") & " AND BillCode_ID = " & R1("BillCode_ID")).Length > 0 AndAlso CDec(dtAggModelBilling.Select("Model_ID = " & R1("Model_ID") & " AND BillCode_ID = " & R1("BillCode_ID"))(0)("labor_charge")) > 0 Then
                        R1("Unit Price $") = CDec(dtAggModelBilling.Select("Model_ID = " & R1("Model_ID") & " AND BillCode_ID = " & R1("BillCode_ID"))(0)("labor_charge"))
                    ElseIf dtAggBilling.Select("BillCode_ID = " & R1("BillCode_ID")).Length > 0 AndAlso CDec(dtAggBilling.Select("BillCode_ID = " & R1("BillCode_ID"))(0)("tcab_Amount")) > 0 Then
                        R1("Unit Price $") = CDec(dtAggBilling.Select("BillCode_ID = " & R1("BillCode_ID"))(0)("tcab_Amount"))
                    Else
                        R1("Unit Price $") = 0
                    End If
                    R1.EndEdit()
                Next R1
                ds.Tables("Astro Summary").Columns.Remove("Model_ID") : ds.Tables("Astro Summary").Columns.Remove("BillCode_ID") : ds.AcceptChanges() : dt = Nothing

                'Summary of Masterpack
                strSql = "SELECT F.PO as 'RMA_PA', D.BillCode_ID, A.Model_ID, IF(E.cust_IncomingSku is null, '', E.cust_IncomingSku) as Model, D.Billcode_Desc as 'Service Provided', 0 as Quantity " & Environment.NewLine
                strSql &= ", 0.0 as 'Unit Price $', 0.0 as 'Total Price $' " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill C ON A.device_ID = C.device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes D ON C.BillCode_ID = D.BillCode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcustmodel_pssmodel_map E ON A.Model_ID = E.Model_ID AND B.Cust_ID = E.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline F ON A.WO_ID = F.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND A.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "AND D.BillCode_ID = 2549 " & Environment.NewLine
                strSql &= "GROUP BY F.PO, Model, Billcode_Desc"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Summary-Masterpack"
                ds.Tables.Add(dt) : ds.AcceptChanges()

                For Each R1 In ds.Tables("Summary-Masterpack").Rows
                    R1.BeginEdit()

                    If dtDeviceBill.Select("[Bundle Model] = '" & R1("Model") & "' AND Billcode_Desc = '" & R1("Service Provided") & "'").Length > 0 Then
                        R1("Quantity") = dtDeviceBill.Select("RMA_PA = '" & R1("RMA_PA") & "' AND [Bundle Model] = '" & R1("Model") & "' AND Billcode_Desc = '" & R1("Service Provided") & "'").Length
                    Else
                        R1("Quantity") = 0
                    End If

                    If Not IsDBNull(dtDeviceBill.Compute("sum(Amount)", "[Bundle Model] = '" & R1("Model") & "' AND Billcode_Desc = '" & R1("Service Provided") & "'")) Then
                        R1("Total Price $") = dtDeviceBill.Compute("sum(Amount)", "RMA_PA = '" & R1("RMA_PA") & "' AND [Bundle Model] = '" & R1("Model") & "' AND Billcode_Desc = '" & R1("Service Provided") & "'")
                    Else
                        R1("Total Price $") = 0
                    End If

                    If dtAggModelBilling.Select("[Bundle Model] = '" & R1("Model") & "' AND BillCode_ID = " & R1("BillCode_ID")).Length > 0 AndAlso CDec(dtAggModelBilling.Select("[Bundle Model] = '" & R1("Model") & "' AND BillCode_ID = " & R1("BillCode_ID"))(0)("labor_charge")) > 0 Then
                        R1("Unit Price $") = CDec(dtAggModelBilling.Select("[Bundle Model] = '" & R1("Model") & "' AND BillCode_ID = " & R1("BillCode_ID"))(0)("labor_charge"))
                    ElseIf dtAggBilling.Select("BillCode_ID = " & R1("BillCode_ID")).Length > 0 AndAlso CDec(dtAggBilling.Select("BillCode_ID = " & R1("BillCode_ID"))(0)("tcab_Amount")) > 0 Then
                        R1("Unit Price $") = CDec(dtAggBilling.Select("BillCode_ID = " & R1("BillCode_ID"))(0)("tcab_Amount"))
                    Else
                        R1("Unit Price $") = 0
                    End If
                    R1.EndEdit()
                Next R1
                ds.Tables("Summary-Masterpack").AcceptChanges()

                For Each R1 In ds.Tables("Summary-Masterpack").Rows
                    R2 = ds.Tables("Astro Summary").NewRow
                    For i = 0 To ds.Tables("Astro Summary").Columns.Count - 1
                        R2(ds.Tables("Astro Summary").Columns(i).Caption) = R1(ds.Tables("Astro Summary").Columns(i).Caption)
                    Next i
                    ds.Tables("Astro Summary").Rows.Add(R2)
                Next R1
                ds.Tables("Astro Summary").AcceptChanges()
                ds.Tables.Remove("Summary-Masterpack") : ds.AcceptChanges()

                '********************************
                'Detail
                '********************************
                strSql = "SELECT Distinct E.PO as 'RMA_PA', A.Device_ID, Date_Format(A.Device_DateRec, '%m/%d/%Y') as 'Receipt Date', Date_Format(A.Device_DateShip, '%m/%d/%Y') as 'Produced Date' " & Environment.NewLine
                strSql &= ", Model_Desc as 'Model', A.Device_SN as 'SN', C.Pallett_Name as 'Masterpack Name', A.Device_LaborCharge as 'Total Labor Charge $' " & Environment.NewLine
                strSql &= "FROM tdevice A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tpallett C ON A.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorderline E ON A.WO_ID = E.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND A.Device_DateShip BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "ORDER BY E.PO, A.Pallett_ID, A.Ship_ID"


                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtServiceBillcode.Rows
                    dt.Columns.Add(New DataColumn(R1("Billcode_Desc") & " $", Type.GetType("System.Double")))
                Next R1
                dt.TableName = "Astro Detail"
                ds.Tables.Add(dt) : ds.AcceptChanges()

                For Each R1 In ds.Tables("Astro Detail").Rows
                    R1.BeginEdit()
                    For Each R2 In dtServiceBillcode.Rows
                        If dtDeviceBill.Select("Device_ID = " & R1("Device_ID") & " AND Billcode_Desc = '" & R2("Billcode_Desc") & "'").Length > 0 Then R1(R2("Billcode_Desc") & " $") = dtDeviceBill.Select("RMA_PA = '" & R1("RMA_PA") & "' AND Device_ID = " & R1("Device_ID") & " AND Billcode_Desc = '" & R2("Billcode_Desc") & "'")(0)("Amount") Else R1(R2("Billcode_Desc") & " $") = 0
                    Next R2
                    If Not IsDBNull(dtDeviceBill.Compute("Sum(Amount)", "Device_ID = " & R1("Device_ID"))) Then R1("Total Labor Charge $") = dtDeviceBill.Compute("Sum(Amount)", "RMA_PA = '" & R1("RMA_PA") & "' AND Device_ID = " & R1("Device_ID")) Else R1("Total Labor Charge $") = 0
                    R1.EndEdit()
                Next R1
                ds.Tables("Astro Detail").Columns.Remove("Device_ID") : ds.AcceptChanges() : dt = Nothing
                '********************************

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtServiceBillcode) : Generic.DisposeDT(dtAggBilling)
                Generic.DisposeDS(ds)
            End Try

        End Function


        '******************************************************************************************************************************
        Private Function getCharge(ByVal dtCharge As DataTable, ByVal iDCode_ID As Integer, ByVal strChargeType As String) As Double
            Dim iDCodeID_Local As Integer
            Dim strChargeType_Local As String
            Dim dResult As Double = 0.0
            Dim row As DataRow

            Try

                For Each row In dtCharge.Rows
                    iDCodeID_Local = row("DCode_ID")
                    strChargeType_Local = row("RC_Type")
                    If iDCodeID_Local = iDCode_ID AndAlso strChargeType_Local = strChargeType Then
                        dResult = row("ActualCharge")
                        Exit For
                    End If
                Next

                Return dResult

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '******************************************************************************************************************************
        Public Function CalExcelColLetter(ByVal iColNo As Integer) As String
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

        '***************************************************************************************************
        Public Function SKRetail_CreateReceiptQtyByFamily(ByVal strRptName As String, ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports
            Dim strCols() As String, i As Integer = 0

            Try
                strSql = "SELECT Family, count(*) as Qty FROM tsk_device A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tsk_packaging B on A.UPC = B.UPC " & Environment.NewLine
                strSql &= "WHERE A.Rec_Date between '" & strDateStart & "'and '" & strDateEnd & "'" & Environment.NewLine
                strSql &= "GROUP BY Family" & Environment.NewLine
                strSql &= "ORDER BY Family "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    ReDim strCols(dt.Columns.Count - 1)
                    For i = 0 To dt.Columns.Count - 1
                        strCols(i) = Generic.CalExcelColLetter(i + 1)
                    Next i

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, strCols)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                objExcelRpt = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************

#End Region

    End Class
End Namespace