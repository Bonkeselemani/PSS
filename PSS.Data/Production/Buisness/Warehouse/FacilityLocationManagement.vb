Option Explicit On 

Imports System.IO
Imports System.Data
Imports System.Data.OleDb

Namespace Buisness
    Public Class FacilityLocationManagement

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

        '***************************************************************************************************
        Public Function GetCustomer(ByVal iCust_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT Cust_ID,Cust_Name1 from tCustomer " & Environment.NewLine
                strSQL &= "WHERE cust_ID = " & iCust_ID
                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        '***************************************************************************************************
        Public Function GetFacilityLocationType() As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * from lfacilitylocationtype " & Environment.NewLine
                strSQL &= "WHERE Active=1"
                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        '***************************************************************************************************
        Public Function GetFacilityLocationCustomerTypeMap(ByVal iCustID As Integer, ByVal iLocTypeID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * FROM lfacilitylocationmap" & Environment.NewLine
                strSQL &= "WHERE Cust_ID=" & iCustID & " AND Loc_Type_ID=" & iLocTypeID & "; "
                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function IsTableExist(ByVal strTableName As String) As Boolean
            Dim strSQL As String
            Dim dt As DataTable, row As DataRow
            Dim bResult As Boolean = False

            Try
                strSQL = "SHOW TABLES from Production"
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If Trim(row(0)).ToUpper = strTableName.Trim.ToUpper Then
                            bResult = True : Exit For
                        End If
                    Next
                End If

                Return bResult

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function IsColumnExist(ByVal strTableName As String, ByVal strColName As String) As Boolean
            Dim strSQL As String
            Dim dt As DataTable, row As DataRow
            Dim bResult As Boolean = False

            Try
                strSQL = "desc " & strTableName
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If Trim(row("Field")).ToUpper = strColName.Trim.ToUpper Then
                            bResult = True : Exit For
                        End If
                    Next
                End If

                Return bResult

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        '***************************************************************************************************
        Public Function GetLocatuionfData(ByVal strCustomerLocationTableName As String, ByVal strRequiredColName As String) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT " & strRequiredColName & ", if (active=1, 'Yes','No') as 'Active' from " & strCustomerLocationTableName & " ORDER BY Location;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        '***************************************************************************************************
        Public Function UpdateLocationData(ByVal strCustomerLocationTableName As String, _
                                           ByVal strPrimaryKeyLocationColName As String, _
                                           ByVal strSelectedLocations As String, _
                                           ByVal bYes As Boolean) As Integer
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "Update " & strCustomerLocationTableName
                If bYes Then strSQL &= " Set Active=0 " Else strSQL &= " Set Active=1 "
                strSQL &= " where " & strPrimaryKeyLocationColName & " in (" & strSelectedLocations & ");"

                Return Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
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

                        Dim colOrder() As Integer = {1, 0, 3, 2}
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

        '******************************************************************
        Public Function SaveFacilityLocationData(ByVal strCustomerLocationTableName As String, ByVal strLocColumnName As String, _
                                                 ByVal dt As DataTable, ByVal strPathFileName As String, ByVal iLocTypeID As Integer, _
                                                 ByVal iCustID As Integer, ByVal iUserID As Integer) As DataTable

            Dim strSQL, strLocName As String
            Dim iIdx As Integer
            Dim row, newRow As DataRow
            Dim dt2 As DataTable
            Dim i As Integer = 0
            Dim dtSQLResult As DataTable = SQLResultDatatableDefinition()
            Dim strDtime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Try
                Dim strFileName As String = Path.GetFileName(strPathFileName)

                For Each row In dt.Rows
                    If row("Status") = Me.strReadyToSave Then
                        strLocName = Trim(row("LocationName"))

                        '1. Master Table 
                        strSQL = "SELECT * FROM lfacilitylocation" & Environment.NewLine
                        strSQL &= " WHERE " & strLocColumnName & "='" & strLocName & "' AND Loc_Type_ID=" & iLocTypeID & " AND Cust_ID=" & iCustID & ";"

                        dt2 = Me._objDataProc.GetDataTable(strSQL)

                        i = 0
                        If Not dt2.Rows.Count > 0 Then 'insert new
                            strSQL = "INSERT INTO lfacilitylocation (" & strLocColumnName & ",Loc_Type_ID,Cust_ID,User_ID,Loaded_DateTime,Loaded_File)" & Environment.NewLine
                            strSQL &= " Values ('" & strLocName & "'," & iLocTypeID & "," & iCustID & "," & iUserID & ",'" & strDtime & "','" & strFileName & "');"
                            i = Me._objDataProc.ExecuteNonQuery(strSQL)
                        End If

                        '2. Customer Location Table
                        strSQL = "SELECT * FROM " & strCustomerLocationTableName & Environment.NewLine
                        strSQL &= " WHERE Location='" & strLocName & "';"

                        dt2 = Me._objDataProc.GetDataTable(strSQL)

                        If Not dt2.Rows.Count > 0 Then 'insert new
                            i = 0
                            strSQL = "INSERT INTO " & strCustomerLocationTableName & " (" & strLocColumnName & ") Values ('" & strLocName & "');"
                            i = Me._objDataProc.ExecuteNonQuery(strSQL)

                            newRow = dtSQLResult.NewRow
                            If i = 0 Then
                                newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strSQLFailed
                            Else
                                newRow("RowID") = row("RowID") : newRow("SQLResult") = i : newRow("Status") = Me.strInserted
                            End If
                            dtSQLResult.Rows.Add(newRow) : dtSQLResult.AcceptChanges()
                        Else
                            newRow = dtSQLResult.NewRow
                            newRow("RowID") = row("RowID") : newRow("SQLResult") = 0 : newRow("Status") = Me.strNoChange
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
        Public Function ExcelTableDefinition() As DataTable
            Dim dTB As New DataTable()
            Dim row As DataRow
            dTB.Columns.Add("RowID", GetType(Integer))
            dTB.Columns.Add("LocationName", GetType(String))
            dTB.Columns.Add("UpdateDatetime", GetType(String))
            Return dTB
        End Function
        '******************************************************************

        '***************************************************************************************************
    End Class
End Namespace
