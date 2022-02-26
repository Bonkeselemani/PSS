Option Explicit On 

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Namespace Buisness
    Public Class Mobilio
        Public Const CUSTOMERID As Integer = 2580
        Public Const LOCID As Integer = 3384

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

#Region "Mobilio - Load Excel IP/MP data"


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

                        Dim colOrder() As Integer = {4, 0, 1, 2, 3, 6, 5}
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
            ' dTB.Columns.Add("UPC", GetType(String))
            dTB.Columns.Add("Sku", GetType(String))
            'dTB.Columns.Add("Family", GetType(String))
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
        Public Function Save_InnerMasterPackData(ByVal dt As DataTable, ByVal strPathFileName As String, _
                                                        ByVal iUserID As Integer, ByVal strMsg As String) As DataTable
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
                        strSQL = "Select Concat(trim(A.Sku),A.InnerPAckQty,A.MasterPackQty,A.TotalContents) as RowString" & _
                                 ",A.* from tmb_packaging A where A.Sku='" & row("sku") & "'"
                        dt2 = Me._objDataProc.GetDataTable(strSQL)

                        If dt2.Rows.Count > 0 Then 'update
                            Dim strTmp As String = ""
                            Dim strS As String = "" ' row("UPC") & row("Sku") & row("Family") & row("InnerPackQty") & row("MasterPackQty") & row("TotalContents")
                            'If Not row.IsNull("UPC") Then strTmp = row("UPC") : strS &= strTmp.Trim
                            If Not row.IsNull("Sku") Then strTmp = row("Sku") : strS &= strTmp.Trim
                            'If Not row.IsNull("Family") Then strTmp = row("Family") : strS &= strTmp.Trim
                            If Not row.IsNull("InnerPackQty") Then strTmp = row("InnerPackQty") : strS &= strTmp.Trim
                            If Not row.IsNull("MasterPackQty") Then strTmp = row("MasterPackQty") : strS &= strTmp.Trim
                            If Not row.IsNull("TotalContents") Then strTmp = row("TotalContents") : strS &= strTmp.Trim

                            strTmp = dt2.Rows(0).Item("RowString")
                            If Not strTmp.ToUpper = strS.ToUpper Then 'need update
                                strSQL = "UPDATE tmb_packaging SET InnerPackQty=" & row("InnerPackQty") & ",MasterPackQty=" & row("MasterPackQty") & "," & _
                                                                  "TotalContents=" & row("TotalContents") & "," & "UserID=" & iUserID & "," & _
                                                                  "UpdateDatetime='" & row("UpdateDatetime") & "',LoadedFileName='" & strFileName & "'" & _
                                                                  " WHERE sku='" & row("sku") & "';"
                                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                                newRow = dtSQLResult.NewRow
                                If i = 0 Then
                                    newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strSQLFailed
                                Else
                                    newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strUpdated
                                    'Save log of old data
                                    Dim oldDTimeStr As String = Format(dt2.Rows(0).Item("UpdateDatetime"), "yyyy-MM-dd HH:mm:ss")
                                    strSQL = "INSERT INTO Tracker.tmb_packaging_Log" & _
                                            " (Sku,InnerPackQty,MasterPackQty,TotalContents,UserID,UpdateDatetime,LoadedFileName,Log_UserID,Log_UpdateDatetime)" & _
                                            " VALUES ('" & dt2.Rows(0).Item("Sku") & "','" & _
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
                            strSQL = "INSERT INTO tmb_packaging (sku,InnerPackQty,MasterPackQty,TotalContents,UserID,UpdateDatetime,LoadedFileName)" & _
                                     " Values ('" & row("Sku") & "'," & _
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
        Public Function Get_InnerMasterPackData() As DataTable
            Dim strSQL As String

            Try
                strSQL = "Select * from tmb_packaging;"
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region



    End Class
End Namespace