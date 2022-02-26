Imports System.IO
Imports System.Windows.Forms
Imports PSS.Data.Buisness

Public Class ExcelReports
    Public Enum Excel_Report_Call
        BRIGHTPOINT_RECEIVED_DEVICES = 0
    End Enum

    Structure FontAttributes
        Public strFontName, strFontStyle As String
        Public iFontSize, iFontColorIndex As Integer

        Public Sub New(ByVal strName As String, ByVal strStyle As String, ByVal iSize As Integer, Optional ByVal iColorIndex As Integer = 1)
            Me.strFontName = strName
            Me.strFontStyle = strStyle
            Me.iFontSize = iSize
            Me.iFontColorIndex = iColorIndex
        End Sub
    End Structure

    Private _objDataProc As DBQuery.DataProc
    Private _datStart, _datEnd As Date
    'Private _objXL, _objWorkbook As Object

    Private _objXL As Excel.Application
    Private _objWorkbook As Excel.Workbook
    Private _lastSimpleFileSaved As String

    '*****************************************************************************
    Public Sub New(Optional ByVal bCreateDataProc As Boolean = False)
        If bCreateDataProc Then Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

        CreateXLObjs()
    End Sub

    '*****************************************************************************

#Region "Properties"
    '*****************************************************************************
    Public Property StartDate()
        Get
            Return Me._datStart
        End Get
        Set(ByVal Value)
            Me._datStart = Value
        End Set
    End Property

    '*****************************************************************************
    Public Property EndDate()
        Get
            Return Me._datEnd
        End Get
        Set(ByVal Value)
            Me._datEnd = Value
        End Set
    End Property

    '*****************************************************************************

#End Region     'Properties

#Region "Excel Format"

    '*****************************************************************************
    Private Sub CreateXLObjs()
        Try
            Me._objXL = New Excel.Application()
            Me._objWorkbook = Me._objXL.Workbooks.Add
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating Excel Objects")
        End Try
    End Sub

    '****************** ***********************************************************
    Private Sub FormatXLSheet(ByVal objSheet As Excel.Worksheet, ByVal dt As DataTable, ByVal faHeaders() As FontAttributes, ByVal iCellHAlign() As Integer, Optional ByVal iHeadersRow As Integer = 1)
        Dim i As Integer
        Dim strHeadersRow As String

        Try
            strHeadersRow = iHeadersRow.ToString

            With objSheet.Rows(iHeadersRow.ToString & ":" & iHeadersRow.ToString)
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With

            For i = 0 To dt.Columns.Count - 1
                With objSheet.Range(Chr(65 + i) & iHeadersRow.ToString).Characters(Start:=1, Length:=dt.Columns(i).ColumnName.Length).Font
                    .Name = faHeaders(i).strFontName
                    .FontStyle = faHeaders(i).strFontStyle
                    .Size = faHeaders(i).iFontSize
                    .Strikethrough = False
                    .Superscript = False
                    .Subscript = False
                    .OutlineFont = False
                    .Shadow = False
                    '.Underline = Excel.Constants.xlUnderlineStyleNone
                    .ColorIndex = Excel.Constants.xlAutomatic
                End With

                objSheet.Range(Chr(65 + i) & iHeadersRow.ToString).FormulaR1C1 = dt.Columns(i).ColumnName
                objSheet.Range(Chr(65 + i) & (iHeadersRow + 1).ToString & ":" & Chr(65 + i) & (dt.Rows.Count + iHeadersRow).ToString).HorizontalAlignment = iCellHAlign(i)
            Next

            For i = 0 To dt.Columns.Count - 1
                objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = dt.Columns(i).ColumnName.Length
            Next i

            objSheet.Rows(iHeadersRow.ToString & ":" & iHeadersRow.ToString).RowHeight = objSheet.Rows((iHeadersRow + 1).ToString & ":" & (iHeadersRow + 1).ToString).RowHeight
            objSheet.Range("A" & (iHeadersRow + 1).ToString).Select()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Public Shared Sub SetCellWidths(ByVal objSheet As Excel.Worksheet, ByVal dt As DataTable)
        Dim iColWidth(), i As Integer
        Dim dr As DataRow

        Try
            ReDim iColWidth(dt.Columns.Count)

            For i = 0 To dt.Columns.Count - 1
                iColWidth(i) = dt.Columns(i).ColumnName.Length
            Next i

            For Each dr In dt.Rows
                For i = 0 To dt.Columns.Count - 1
                    iColWidth(i) = Math.Max(iColWidth(i), dr(i).ToString.Length)
                Next i
            Next dr

            For i = 0 To dt.Columns.Count - 1
                objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = iColWidth(i) + 5
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub DeleteUnusedWorksheets(ByVal iSheetsUsed As Integer)
        ' Delete unused worksheets
        Dim i As Integer

        Try
            Me._objXL.DisplayAlerts = False ' Kill the delete prompt

            If iSheetsUsed < Me._objWorkbook.Sheets.Count Then
                For i = Me._objWorkbook.Sheets.Count To iSheetsUsed + 1 Step -1
                    Me._objWorkbook.Sheets("Sheet" & i.ToString).Delete()
                Next i
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub SetFontAttributes(ByVal objSheet As Excel.Worksheet, ByVal fa As FontAttributes, ByVal iRow As Integer, Optional ByVal iCol As Integer = 1)
        Try
            SetFontAttributes(objSheet, New FontAttributes() {fa}, iRow, iRow, iCol)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub SetFontAttributes(ByVal objSheet As Excel.Worksheet, ByVal fa() As FontAttributes, ByVal iFirstRow As Integer, ByVal iLastRow As Integer, Optional ByVal iCol As Integer = 1)
        Dim i As Integer

        Try
            For i = 0 To fa.Length - 1
                With objSheet.Range(Chr(65 + i + iCol - 1) & iFirstRow.ToString & ":" & Chr(65 + i + iCol - 1) & iLastRow.ToString).Font
                    .Name = fa(i).strFontName
                    .FontStyle = fa(i).strFontStyle
                    .Size = fa(i).iFontSize
                    .ColorIndex = fa(i).iFontColorIndex
                End With
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub CreateBorders(ByVal iFirstCol As Integer, ByVal iFirstRow As Integer, ByVal iLastCol As Integer, ByVal iLastRow As Integer)
        Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
            Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
        Dim i As Integer

        Try
            Me._objXL.Range(Chr(65 + iFirstCol - 1) & iFirstRow.ToString & ":" & Chr(65 + iLastCol - 1) & iLastRow.ToString).Select()
            Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
            Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

            For i = 0 To xlBI.Length - 1
                With Me._objXL.Selection.Borders(xlBI(i))
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.Constants.xlAutomatic
                End With
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub SetHeaderRowBackgroundColor(ByVal iRow As Integer, ByVal iStartCol As Integer, ByVal iEndCol As Integer, Optional ByVal iColorIndex As Integer = 15) '15 = Light gray
        'Set header row background color

        Try
            Me._objXL.Range(Chr(65 + iStartCol - 1) & iRow.ToString & ":" & Chr(65 + iEndCol - 1) & iRow.ToString).Select()
            Me._objXL.Selection.Interior.ColorIndex = iColorIndex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub FreezeHeaders(ByVal iHeaderRow As Integer, ByVal iStartCol As Integer, ByVal iEndCol As Integer)
        ' Freeze column headers area

        Try
            Me._objXL.ActiveWindow.FreezePanes = False
            Me._objXL.Range(Chr(65 + iStartCol - 1) & (iHeaderRow + 1).ToString & ":" & Chr(65 + iEndCol - 1) & (iHeaderRow + 1).ToString).Select()
            Me._objXL.ActiveWindow.FreezePanes = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Sub SetHorizontalAlignment(ByVal objSheet As Excel.Worksheet, ByVal iColHorizAlignment() As Integer, ByVal iStartCol As Integer, ByVal iFirstRow As Integer, ByVal iLastRow As Integer)
        Dim i As Integer

        Try
            For i = 0 To iColHorizAlignment.Length - 1
                objSheet.Range(Chr(65 + i + iStartCol - 1) & iFirstRow.ToString & ":" & Chr(65 + i + iStartCol - 1) & iLastRow.ToString).HorizontalAlignment = iColHorizAlignment(i)
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    'Private Sub SetNumberFormat(ByRef objSheet As Excel.Worksheet, ByVal strNumberFormat() As String)
    '    Dim i As Integer

    '    Try
    '        For i = 0 To strNumberFormat.Length - 1
    '            objSheet.Columns(Chr(65 + i)).NumberFormat = strNumberFormat(i)
    '        Next i
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    '*****************************************************************************
    Public Sub SetNumberFormat(ByRef objSheet As Excel.Worksheet, ByVal strNumberFormats() As String, ByVal iStartCol As Integer, ByVal iFirstRow As Integer, ByVal iLastRow As Integer)
        Dim i As Integer

        Try
            For i = 0 To strNumberFormats.Length - 1
                objSheet.Range(Chr(65 + i + iStartCol - 1) & iFirstRow.ToString & ":" & Chr(65 + i + iStartCol - 1) & iLastRow.ToString).NumberFormat = strNumberFormats(i)
            Next i
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Private Function CreateReportDir(ByVal strReportDir As String) As Boolean
        Dim bDirCreated As Boolean = False

        Try
            If Not Directory.Exists(strReportDir) Then Directory.CreateDirectory(strReportDir)
            If Directory.Exists(strReportDir) Then bDirCreated = True

            Return bDirCreated
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*****************************************************************************
    Private Function SetupDateStrings(ByVal strDateField As String, ByRef strDateRange As String, Optional ByVal iTimeFieldIndex As Short = 0, Optional ByVal bIsMonthly As Boolean = False) As String
        Dim strRet As String = ""
        Dim strStartDate, strEndDate As String

        Try
            If bIsMonthly Then
                If Me._datStart.Day > 1 Then Me._datStart = Me._datStart.AddDays(1 - Me._datStart.Day)

                If Me._datEnd.Month = Me._datStart.Month And Me._datEnd.Year = Me._datStart.Year Then
                    If Me._datStart.Month < 12 Then
                        Me._datEnd = New DateTime(Me._datStart.Year, Me._datStart.Month + 1, 1)
                    Else
                        Me._datEnd = New DateTime(Me._datStart.Year + 1, 1, 1)
                    End If
                ElseIf Me._datEnd.Day > 1 Then ' Move to first of next month
                    Me._datEnd = Me._datEnd.AddDays((Me._datEnd.DaysInMonth(Me._datEnd.Year, Me._datEnd.Month) - Me._datEnd.Day) + 1)
                End If

                'If Me._datEnd.Day < Me._datEnd.DaysInMonth(Me._datEnd.Year, Me._datEnd.Month) Then Me._datEnd = Me._datEnd.AddDays(Me._datEnd.DaysInMonth(Me._datEnd.Year, Me._datEnd.Month) - Me._datEnd.Day)
            End If

            Select Case iTimeFieldIndex
                Case 0 ' No time
                    strStartDate = Format(Me._datStart, "yyyy-MM-dd")
                    strEndDate = Format(Me._datEnd, "yyyy-MM-dd")

                Case 1 ' Account for shift start and end times
                    strStartDate = Format(Me._datStart, "yyyy-MM-dd") & " 06:00:00"
                    strEndDate = Format(DateAdd(DateInterval.Day, 1, Me._datEnd), "yyyy-MM-dd") & " 04:30:00"

                Case 2 ' Account for start/end dates start/end times, respectively
                    strStartDate = Format(Me._datStart, "yyyy-MM-dd") & " 00:00:00"
                    strEndDate = Format(Me._datEnd, "yyyy-MM-dd") & " 23:59:59"
            End Select

            'If Me._bUseStartDate And Me._bUseEndDate Then
            If bIsMonthly Then
                strDateRange = String.Format("{0} - {1}", Format(Me._datStart, "MMM d, yyyy"), Format(Me._datEnd.AddDays(-1), "MMM d, yyyy"))
            Else
                strDateRange = String.Format("{0} - {1}", Format(Me._datStart, "MMM d, yyyy"), Format(Me._datEnd, "MMM d, yyyy"))
            End If

            strRet = strDateField & " BETWEEN '" & strStartDate & "' AND '" & strEndDate & "'"
            'ElseIf Me._bUseStartDate Then
            '    strDateRange = String.Format("{0} and Thereafter", Format(Me._datStart, "MMM d, yyyy"))
            '    strRet = strDateField & " >= '" & strStartDate & "'"
            'ElseIf Me._bUseEndDate Then
            '    If bIsMonthly Then
            '        strDateRange = String.Format("Up to {0}", Format(Me._datEnd.AddDays(-1), "MMM d, yyyy"))
            '    Else
            '        strDateRange = String.Format("Up to {0}", Format(Me._datEnd, "MMM d, yyyy"))
            '    End If

            '    strRet = strDateField & " <= '" & strEndDate & "'"
            'End If

            Return strRet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*****************************************************************************
#End Region    'Excel Format

#Region "Internal Reports"
    '*****************************************************************************
    Public Sub RunReport(ByVal xlrc As Excel_Report_Call)
        Dim dt As DataTable
        Dim strReportName, strDateRange As String

        Try
            dt = GetReportData(xlrc, strDateRange)

            Select Case xlrc
                Case Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES
                    strReportName = "Brightpoint Received Devices"
                    RunBrightpointReceivedDevicesReport(dt, strReportName, strDateRange)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Running " & strReportName & " Report")
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunTFTriageReport(ByVal xlrc As Excel_Report_Call, ByVal dt As DataTable, ByVal strDateRange As String)
        Dim strReportName As String

        Try
            Select Case xlrc
                Case Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES
                    strReportName = "Admin Revenue Detail TF Triage"
                    RunBrightpointReceivedDevicesReport(dt, strReportName, strDateRange)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Running " & strReportName & " Report")
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '*****************************************************************************
    Private Function GetReportData(ByVal xlrc As Excel_Report_Call, ByRef strDateRange As String) As DataTable
        Dim strSQL, strDateClause, strTableName As String
        Dim dt As DataTable

        Try
            Select Case xlrc
                Case Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES
                    strDateClause = Me.SetupDateStrings("A.Device_RecWorkDate ", strDateRange, 0)

                    'strSQL = "SELECT '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    'strSQL = "SELECT '" & Me._strReportTitle & "' AS ReportTitle, '" & strDateRange & "' AS DateRange, " & Environment.NewLine
                    strSQL = "SELECT C.Model_Desc AS 'Model Desc', IF(B.csin_enterprisecode IS NULL OR  LENGTH(TRIM(B.csin_enterprisecode)) = 0, '--- No Code ---', B.csin_enterprisecode) AS 'Enterprise Code', COUNT(*) AS Quantity " & Environment.NewLine
                    strSQL &= "FROM tdevice A " & Environment.NewLine
                    strSQL &= "INNER JOIN cstincomingdata B ON B.Device_ID = A.Device_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                    strSQL &= "WHERE A.loc_id = 2636 " & Environment.NewLine
                    strSQL &= "AND " & strDateClause & Environment.NewLine
                    strSQL &= "AND B.issalvageflg = 0 " & Environment.NewLine
                    strSQL &= "GROUP BY A.Model_ID,  B.csin_enterprisecode " & Environment.NewLine
                    strSQL &= "ORDER BY 'Model Desc', 'Enterprise Code'"

                    strTableName = "Brightpoint Received Devices Data"
            End Select

            dt = Me._objDataProc.GetDataTable(strSQL)

            If Not IsNothing(dt) Then dt.TableName = strTableName

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Function

    '*****************************************************************************
    Private Sub RunBrightpointReceivedDevicesReport(ByVal dt As DataTable, ByVal strReportName As String, ByVal strDateRange As String)
        Dim objSheet As Object
        Dim arrOutput(,)
        Dim dr As DataRow
        Dim i, iDataRow, iCellHAlign() As Integer
        Dim faTitle, faHeaders(), faData(), faDateRange, faHighQty As FontAttributes
        Dim RowsNum As Integer, ColsNum As Integer
        Dim TopHeaderRowNum As Integer = 4
        Dim TopHeaderColNum As Integer = 1
        Dim Rng As Excel.Range = Nothing

        Try
            Me._objXL.Visible = True
            objSheet = Me._objWorkbook.Sheets("Sheet1")
            objSheet.Name = strReportName

            If Not IsNothing(dt) Then
                RowsNum = dt.Rows.Count
                ColsNum = dt.Columns.Count

                If dt.Rows.Count > 0 Then
                    ReDim iCellHAlign(dt.Columns.Count - 1)
                    ReDim arrOutput(dt.Rows.Count - 1, dt.Columns.Count - 1)
                    ReDim faData(dt.Columns.Count - 1)
                    ReDim faHeaders(dt.Columns.Count - 1)

                    iDataRow = -1

                    For Each dr In dt.Rows
                        iDataRow += 1

                        For i = 0 To dt.Columns.Count - 1 : arrOutput(iDataRow, i) = dr(i).ToString : Next i
                    Next dr

                    With objSheet
                        .Activate()

                        For i = 0 To iCellHAlign.Length - 1
                            iCellHAlign(i) = IIf(i < iCellHAlign.Length - 1, Excel.Constants.xlLeft, Excel.Constants.xlRight)
                            faHeaders(i).iFontSize = 10
                            faHeaders(i).strFontName = "Arial"
                            faHeaders(i).strFontStyle = "Bold"
                            faData(i).iFontSize = 10
                            faData(i).strFontName = "Arial"
                            faData(i).strFontStyle = "Regular"
                        Next i

                        faTitle.iFontSize = 20
                        faTitle.strFontName = "Arial"
                        faTitle.strFontStyle = "Bold"
                        faDateRange.iFontSize = 12
                        faDateRange.strFontName = "Arial"
                        faDateRange.strFontStyle = "Bold"
                        faHighQty.iFontSize = 10
                        faHighQty.strFontName = "Arial"
                        faHighQty.strFontStyle = "Regular"

                        SetFontAttributes(objSheet, faTitle, 1, 1)
                        SetFontAttributes(objSheet, faDateRange, 2, 2)

                        .Range("A1:A1").Value = strReportName
                        .Range("B2:B2").Value = strDateRange

                        SetHeaderRowBackgroundColor(4, 1, dt.Columns.Count + 1)
                        FormatXLSheet(objSheet, dt, faHeaders, iCellHAlign, 4)

                        iDataRow = 5

                        .Range("A" & iDataRow.ToString & ":" & Chr(65 + dt.Columns.Count - 1) & (iDataRow + arrOutput.GetUpperBound(0)).ToString).Value = arrOutput
                        SetCellWidths(objSheet, dt)
                        SetFontAttributes(objSheet, faData, iDataRow, iDataRow + arrOutput.GetUpperBound(0))

                        For i = 0 To dt.Rows.Count - 1
                            If CInt(dt.Rows(i)(dt.Columns.Count - 1)) > 100 Then
                                SetFontAttributes(objSheet, faHighQty, 5 + i, dt.Columns.Count)
                            End If
                        Next i

                        'Add total column
                        SetHeaderRowBackgroundColor(4, 1, ColsNum + 1)
                        objSheet.Cells(4, ColsNum + 1) = "Total Charge"
                        Dim rowName As String = Number2Char(ColsNum - 2)
                        Dim rowName2 As String = Number2Char(ColsNum)
                        For i = 5 To RowsNum + 4
                            Rng = objSheet.Range(objSheet.Cells(i, ColsNum + 1), objSheet.Cells(i, ColsNum + 1))
                            Rng.Formula = "=SUM(" & rowName & i & "," & rowName2 & i & ")"
                        Next

                        'Add sum row
                        SetHeaderRowBackgroundColor(RowsNum + TopHeaderRowNum + 1, 1, ColsNum + 1)
                        objSheet.Cells(RowsNum + TopHeaderRowNum + 1, 1) = "TOTAL"
                        For i = 2 To ColsNum + 1
                            Dim colName As String = Number2Char(i)
                            Rng = objSheet.Range(objSheet.Cells(RowsNum + TopHeaderRowNum + 1, i), objSheet.Cells(RowsNum + TopHeaderRowNum + 1, i))
                            Rng.Formula = "=SUM(" & colName & TopHeaderRowNum + 1 & ":" & colName & RowsNum + TopHeaderRowNum & ")"
                            SetHeaderRowBackgroundColor(RowsNum + TopHeaderRowNum + 1, i, ColsNum + 1)
                        Next

                        'Data format
                        For i = 1 To ColsNum + 1
                            Rng = objSheet.Range(objSheet.Cells(TopHeaderRowNum + 1, i), objSheet.Cells(RowsNum + TopHeaderRowNum + 1, i))
                            Select Case i
                                Case 1
                                    Rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                    Rng.NumberFormat = "@"
                                    Exit Select
                                Case 2, 4
                                    Rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    Rng.NumberFormat = "#,##0"
                                    Exit Select
                                Case Else
                                    Rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                                    Rng.NumberFormat = "$#,##0.00"
                                    Exit Select
                            End Select
                        Next

                        CreateBorders(1, 5, ColsNum + 1, iDataRow + arrOutput.GetUpperBound(0))
                        FreezeHeaders(4, 1, ColsNum + 1)

                        DeleteUnusedWorksheets(1)
                    End With
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function Number2Char(ByVal vNumber) As String

        Dim iDiv As Double, iMod As Integer

        Number2Char = Nothing
        If vNumber < 1 Then Exit Function

        iDiv = vNumber
        While iDiv > 26
            iMod = iDiv Mod 26
            If iMod = 0 Then
                iMod = 26
                iDiv = iDiv - 1
            End If
            Number2Char = Chr(64 + iMod) & Number2Char
            iDiv = iDiv \ 26
        End While

        Number2Char = Chr(64 + iDiv) & Number2Char

    End Function

    '*****************************************************************************

#End Region     'Internal Reports

#Region "External Report"

    '*****************************************************************************
    Public Sub RunAMManifestReport(ByVal dt As DataTable, _
                                   ByVal strPallett_name As String, _
                                   ByVal strReportDir As String, _
                                   ByVal strRptTitle As String, _
                                   Optional ByVal booCreateTabDelimited As Boolean = False, _
                                   Optional ByVal booPrintReport As Boolean = True)
        'Const strReportDir = "P:\Dept\Messaging\DBR Manifest\"
        Dim objSheet As Object
        Dim dr As DataRow
        Dim iDataRow, i, iCellHAlign(), iDataStartRow As Integer
        Dim arrOutput(,)
        Dim faTitle, faHeaders(), faData(), faCount, faReportName As FontAttributes
        Dim bReportDirExists As Boolean = True
        Dim strTabDelimitedData, strTabDelimitedHeader As String

        Try
            Me._objXL.Visible = False
            objSheet = Me._objWorkbook.Sheets("Sheet1")
            'objSheet.Name = "DBR Manifest"

            strTabDelimitedData = "" : strTabDelimitedHeader = ""

            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    ReDim iCellHAlign(dt.Columns.Count - 1)
                    ReDim arrOutput(dt.Rows.Count - 1, dt.Columns.Count - 1)
                    ReDim faData(dt.Columns.Count - 1)
                    ReDim faHeaders(dt.Columns.Count - 1)

                    For i = 0 To iCellHAlign.Length - 1
                        iCellHAlign(i) = Excel.Constants.xlLeft
                        faHeaders(i).iFontSize = 8
                        faHeaders(i).strFontName = "Arial"
                        faHeaders(i).strFontStyle = "Bold"
                        faData(i).iFontSize = 8
                        faData(i).strFontName = IIf(dt.Columns(i).ColumnName.ToUpper.IndexOf("BARCODE") = -1, "Arial", "C39P12DhTt")
                        faData(i).strFontStyle = "Regular"
                    Next i

                    faTitle.iFontSize = 20
                    faTitle.strFontName = "Arial"
                    faTitle.strFontStyle = "Bold"
                    faCount.iFontSize = 18
                    faCount.strFontName = "Arial"
                    faCount.strFontStyle = "Bold"
                    faReportName.iFontSize = 18
                    faReportName.strFontName = "Arial"
                    faReportName.strFontStyle = "Bold"

                    objSheet.Activate()
                    FormatXLSheet(objSheet, dt, faHeaders, iCellHAlign, 4)

                    SetHeaderRowBackgroundColor(4, 1, dt.Columns.Count)
                    'Me._objXL.Range("A4:" & Chr(65 + dt.Columns.Count - 1) & "4").Select()
                    'Me._objXL.Selection.Interior.ColorIndex = 15 'Light gray

                    SetFontAttributes(objSheet, faTitle, 1, 1)
                    SetFontAttributes(objSheet, faReportName, 2, 1)
                    SetFontAttributes(objSheet, faCount, 2, 4)

                    iDataStartRow = 5
                    iDataRow = 0

                    With objSheet
                        .Range("A1:A1").Value = strRptTitle
                        .Range("A2:A2").Value = strPallett_name
                        .Range("D2:D2").Value = "Total: " & Format(dt.Rows.Count, "#,##0")

                        For Each dr In dt.Rows
                            iDataRow += 1

                            For i = 0 To dt.Columns.Count - 1
                                arrOutput(iDataRow - 1, i) = dr(i).ToString

                                '***********************************
                                If booCreateTabDelimited = True Then
                                    'header
                                    If iDataRow = 1 AndAlso i > 0 Then strTabDelimitedHeader &= vbTab
                                    If iDataRow = 1 Then strTabDelimitedHeader &= dt.Columns(i).Caption
                                    'Data
                                    If i > 0 Then strTabDelimitedData &= vbTab
                                    strTabDelimitedData &= dr(i).ToString
                                End If
                                '***********************************
                            Next i

                            strTabDelimitedData &= vbCrLf
                        Next dr

                        .Range("A" & iDataStartRow.ToString & ":" & Chr(65 + dt.Columns.Count - 1) & (iDataStartRow + iDataRow - 1).ToString).Value = arrOutput
                    End With

                    SetCellWidths(objSheet, dt)
                    SetFontAttributes(objSheet, faData, iDataStartRow, iDataStartRow + iDataRow - 1)
                    CreateBorders(1, 4, dt.Columns.Count, iDataStartRow + iDataRow - 1)

                    DeleteUnusedWorksheets(1)

                    '***********************************
                    'Set page orientation
                    '***********************************
                    'If strPallett_name.StartsWith("DBR") Then
                    '    objSheet.PageSetup.Orientation = 2
                    'End If
                    If InStr(strPallett_name.ToUpper, "DBR") = 0 Or InStr(strPallett_name.ToUpper, "NER") = 0 Then
                        objSheet.PageSetup.Orientation = 2
                    End If

                    With objSheet.PageSetup
                        .RightMargin = 0
                        .LeftMargin = 0
                        .TopMargin = 0
                        .BottomMargin = 0
                        .HeaderMargin = 0
                        .FooterMargin = 0
                        .RightFooter = "&P of &N"
                        .FitToPagesWide = 1
                        .FitToPagesTall = 1
                    End With

                    'Save report
                    If Not Directory.Exists(strReportDir) Then bReportDirExists = CreateReportDir(strReportDir)

                    If bReportDirExists Then
                        'strReportName = "DBR Manifest " & Format(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)), "yyyyMMddhhmmss") & ".xls"
                        Me._objWorkbook.SaveAs(strReportDir & strPallett_name & ".xls")
                        If booCreateTabDelimited = True Then
                            strTabDelimitedData = strRptTitle & vbCrLf & strPallett_name & vbTab & vbTab & vbTab & "Total: " & Format(dt.Rows.Count, "#,##0") & vbCrLf & vbCrLf & strTabDelimitedHeader & vbCrLf & strTabDelimitedData
                            FileOpen(1, strReportDir & strPallett_name & ".txt", OpenMode.Append)   'Open TXT file
                            PrintLine(1, strTabDelimitedData)
                        End If
                    Else
                        MsgBox("Unable to save report under " & strReportDir & ".  Directory doesn't exist and can't be created.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "File Save Error")
                    End If

                    'Print report
                    If booPrintReport = True Then Me._objWorkbook.PrintOut()

                    'Close the workbook
                    Me._objWorkbook.Close(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Reset()
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunAmericanMsgWIPDetailReport(ByVal dt As DataTable, ByVal datWIPCutoffDate As DateTime)
        Dim objSheet As Object
        Dim i, j, iHAlignment() As Integer
        Dim arrOutput(,)
        Dim strNumberFormat(), strBarCodeCol As String
        Dim faHeaders(), faData() As FontAttributes

        Try
            Me._objXL.Visible = True
            objSheet = Me._objWorkbook.Sheets("Sheet1")
            objSheet.Name = Format(datWIPCutoffDate, "yyyy-MM-dd")

            DeleteUnusedWorksheets(1)

            '//Place data on sheet
            With objSheet
                ReDim iHAlignment(dt.Columns.Count - 1)
                ReDim strNumberFormat(dt.Columns.Count - 1)
                ReDim faHeaders(dt.Columns.Count - 1)
                ReDim faData(dt.Columns.Count - 1)
                ReDim arrOutput(dt.Rows.Count - 1, dt.Columns.Count - 1)

                For i = 0 To dt.Columns.Count - 1
                    faHeaders(i).iFontSize = 10
                    faHeaders(i).strFontName = "Arial"
                    faHeaders(i).strFontStyle = "Bold"
                    faData(i).iFontSize = 10
                    faData(i).strFontStyle = "Regular"

                    If dt.Columns(i).ColumnName.ToUpper.Substring(0, Math.Min(11, dt.Columns(i).ColumnName.Length)) = "DAYS IN WIP" Then
                        iHAlignment(i) = Excel.Constants.xlRight
                        strNumberFormat(i) = "#0"
                        faData(i).strFontName = "Arial"
                    ElseIf dt.Columns(i).ColumnName.ToUpper.IndexOf("BARCODE") > -1 Then
                        iHAlignment(i) = Excel.Constants.xlLeft
                        strBarCodeCol = Chr(65 + i)
                        strNumberFormat(i) = "@"
                        faData(i).strFontName = "C39P12DhTt"
                    Else
                        iHAlignment(i) = Excel.Constants.xlLeft
                        strNumberFormat(i) = "@"
                        faData(i).strFontName = "Arial"
                    End If
                Next i

                .Activate()
                FormatXLSheet(objSheet, dt, faHeaders, iHAlignment)

                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        arrOutput(i, j) = dt.Rows(i)(j)
                    Next j
                Next i

                SetHorizontalAlignment(objSheet, iHAlignment, 1, 1, dt.Rows.Count + 1)
                SetNumberFormat(objSheet, strNumberFormat, 1, 2, dt.Rows.Count + 1)
                SetCellWidths(objSheet, dt)
                SetFontAttributes(objSheet, faData, 2, dt.Rows.Count + 1)
                SetHeaderRowBackgroundColor(1, 1, dt.Columns.Count)

                .Range("A2", Chr(65 + dt.Columns.Count - 1) & (dt.Rows.Count + 1).ToString).Value = arrOutput

                .PageSetup.RightMargin = 2
                .PageSetup.LeftMargin = 2
                .pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape
            End With

            FreezeHeaders(1, 1, dt.Columns.Count)

            Me._objXL.ActiveWindow.Zoom = 85
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunAPCReport(ByVal dt As DataTable, ByVal decTotalPartCost As Decimal)
        Dim objSheet As Object
        Dim i, j, iHAlignment() As Integer
        Dim arrOutput(,)
        Dim strNumberFormat() As String
        Dim faHeaders(), faData() As FontAttributes

        Try
            Me._objXL.Visible = True
            objSheet = Me._objWorkbook.Sheets("Sheet1")
            objSheet.Name = "APC"

            DeleteUnusedWorksheets(1)

            '//Place data on sheet
            With objSheet
                ReDim iHAlignment(dt.Columns.Count - 1)
                ReDim strNumberFormat(dt.Columns.Count - 1)
                ReDim faHeaders(dt.Columns.Count - 1)
                ReDim faData(dt.Columns.Count - 1)
                ReDim arrOutput(dt.Rows.Count, dt.Columns.Count - 1)

                For i = 0 To dt.Columns.Count - 1
                    faHeaders(i).iFontSize = 10
                    faHeaders(i).strFontName = "Arial"
                    faHeaders(i).strFontStyle = "Bold"
                    faData(i).iFontSize = 10
                    faData(i).strFontStyle = "Regular"

                    If dt.Columns(i).ColumnName.ToUpper.IndexOf("QTY") > -1 Then
                        iHAlignment(i) = Excel.Constants.xlRight
                        strNumberFormat(i) = "#0"
                        faData(i).strFontName = "Arial"
                    ElseIf dt.Columns(i).ColumnName.ToUpper.IndexOf("APC") > -1 Then
                        iHAlignment(i) = Excel.Constants.xlRight
                        strNumberFormat(i) = "$#0.00"
                        faData(i).strFontName = "Arial"
                    Else
                        iHAlignment(i) = Excel.Constants.xlLeft
                        strNumberFormat(i) = "@"
                        faData(i).strFontName = "Arial"
                    End If
                Next i

                .Activate()
                FormatXLSheet(objSheet, dt, faHeaders, iHAlignment)

                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        If j = 1 Then arrOutput(i, j) = CInt(dt.Rows(i)(j)) Else arrOutput(i, j) = dt.Rows(i)(j)
                    Next j
                Next i

                arrOutput(i, 1) = "=SUM(R[-1]C:R[-" & dt.Rows.Count & "]C)"
                If decTotalPartCost > 0 Then arrOutput(i, 3) = "=" & decTotalPartCost & "/RC[-2]" Else arrOutput(i, 3) = "=0"

                .Range("A2", Chr(65 + dt.Columns.Count - 1) & (dt.Rows.Count + 2).ToString).Value = arrOutput

                SetHorizontalAlignment(objSheet, iHAlignment, 1, 1, dt.Rows.Count + 2)
                SetNumberFormat(objSheet, strNumberFormat, 1, 2, dt.Rows.Count + 2)
                SetCellWidths(objSheet, dt)
                SetFontAttributes(objSheet, faData, 2, dt.Rows.Count + 1)
                SetHeaderRowBackgroundColor(1, 1, dt.Columns.Count)
                .Range("A" & (dt.Rows.Count + 2).ToString & ":" & Chr(65 + dt.Columns.Count - 1) & (dt.Rows.Count + 2).ToString).Font.FontStyle = "Bold"

                'Draw a heavier border on the right side for cost center line
                _objXL.Range("A" & (dt.Rows.Count + 2).ToString & ":" & Chr(65 + dt.Columns.Count - 1) & (dt.Rows.Count + 2).ToString).Select()
                With Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThick
                    .ColorIndex = 25
                End With
                With _objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThick
                    .ColorIndex = 25
                End With

                .PageSetup.RightMargin = 2
                .PageSetup.LeftMargin = 2
                .pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape
            End With

            FreezeHeaders(1, 1, dt.Columns.Count)

            Me._objXL.ActiveWindow.Zoom = 85
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************
    Public Function RunDriveCamDockShipDevices(ByVal strDateStart As String, ByVal strDateEnd As String, ByVal booProduceDate As Boolean)
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim objSheet, objArrData(,) As Object
        Dim R1 As DataRow
        Dim i, j As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim strFileName As String = ""

        Try
            strSql = "SELECT Distinct Device_sn as 'SN', WO_CustWO as 'WO', Device_DateShip as 'Produce Date'" & Environment.NewLine
            strSql &= ", pkslip_DockShipDate as 'Dock Ship Date',  IF(Max(BillCode_Rule) = 0, 'Repair', 'RUR') as 'Status'" & Environment.NewLine
            strSql &= ", Pallett_Name as 'Box Name',  concat( Cust_Name1, ' ', if(Cust_Name2 is null, '', Cust_Name2) ) as Customer" & Environment.NewLine
            strSql &= ", IF( tpallett.pkslip_ID is null, '',  tpallett.pkslip_ID) as 'Manifest #'" & Environment.NewLine
            strSql &= ", IF( pkslip_TrackNo is null, '', pkslip_TrackNo) as 'Tracking #', lpaymethod.Pay_Desc as 'Pay Type'" & Environment.NewLine
            strSql &= "FROM tdevice  " & Environment.NewLine
            strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID" & Environment.NewLine
            strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
            strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID" & Environment.NewLine
            strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
            strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
            strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID" & Environment.NewLine
            strSql &= "INNER JOIN lpaymethod ON tcustomer.Pay_ID = lpaymethod.Pay_ID" & Environment.NewLine
            If booProduceDate = True Then
                strSql &= "LEFT OUTER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
            Else
                strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
            End If
            strSql &= "WHERE tmodel.Prod_ID = 9 " & Environment.NewLine

            If booProduceDate = True Then
                strSql &= "AND tdevice.Device_Dateship BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
            Else
                strSql &= "AND tpackingslip.pkslip_DockShipDate BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
            End If
            strSql &= "GROUP BY tdevice.Device_ID " & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Me._objXL.Application.DisplayAlerts = False
                Me._objXL.Columns("A:B").Select()                'Select columns
                Me._objXL.Selection.NumberFormat = "@"           'Set text format to selected columns
                Me._objXL.Columns("E:I").Select()                'Select columns
                Me._objXL.Selection.NumberFormat = "@"           'Set text format to selected columns
                objSheet = _objWorkbook.Worksheets("Sheet1")


                ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
                i = 0 : j = 0

                For Each R1 In dt.Rows
                    '********************************
                    'Create Header
                    '********************************
                    If i = 0 Then
                        For j = 0 To dt.Columns.Count - 1
                            objArrData(i, j) = dt.Columns(j).Caption
                        Next j
                        i += 1
                    End If

                    '********************************
                    'Data
                    '********************************
                    For j = 0 To dt.Columns.Count - 1
                        objArrData(i, j) = R1(j)
                    Next j
                    i += 1
                    '********************************
                Next R1

                '********************************
                'Post data to excel sheet
                '********************************
                With objSheet
                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                    .Range("A1:I1").Select()
                    With Me._objXL.Selection
                        .WrapText = True
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
                    objSaveFileDialog.FileName = "DriveCamShipFrom" & strDateStart & "To" & strDateEnd & ".xls"
                    objSaveFileDialog.ShowDialog()
                    strFileName = objSaveFileDialog.FileName

                    If strFileName.Trim.Length = 0 Then
                        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If strFileName.IndexOf("\") < 0 Then Exit Function
                        If File.Exists(strFileName) = True Then Kill(strFileName)
                        Me._objWorkbook.SaveAs(strFileName)
                        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End With
                '********************************
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                objSaveFileDialog = Nothing
            End If
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._objDataProc = Nothing : objArrData = Nothing : R1 = Nothing
            If Not IsNothing(objSheet) Then
                PSS.Data.Buisness.Generic.NAR(objSheet)
            End If
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False)
                PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit()
                PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Function

    '******************************************************************
    Public Function RunExcelReport(ByVal strRptName As String, _
                                   Optional ByVal strDateStart As String = "", _
                                   Optional ByVal strDateEnd As String = "", _
                                   Optional ByVal iCustID As Integer = 0, _
                                   Optional ByVal iLocID As Integer = 0, _
                                   Optional ByVal strComputerName As String = "") As Integer
        Dim strSql, strCriteria As String
        Dim dt, dtQuery As DataTable


        Try
            strSql = "" : strCriteria = ""
            strSql = "SELECT Query FROM production.selqueries WHERE QueryName = '" & strRptName & "' AND Active = 1 "
            dtQuery = Connection5.GetDataTable(strSql)

            If dtQuery.Rows.Count = 0 Then
                MessageBox.Show("No query has been created for this report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                '*************************
                'Define report criteria
                '*************************
                Select Case strRptName
                    Case "Scrap Report"
                        strCriteria = " tlocation.Cust_ID = " & iCustID & " AND tscrap.workdate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "' "
                        If strComputerName.Trim.Length > 0 Then strCriteria &= " AND computerName = '" & strComputerName & "' "
                End Select

                '*************************
                'Get report data
                '*************************
                strSql = dtQuery.Rows(0)(0).ToString().Insert(dtQuery.Rows(0)(0).ToString().IndexOf("WHERE") + 5, strCriteria)
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data for selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                End If

                '*************************
                'Format Report
                '*************************
                If strRptName = "Scrap Report" Then
                    RunScrapReportFormat(dt, strRptName)
                Else
                    RunSimpleExcelFormat(dt, strRptName)
                End If
                '*************************

                Return dt.Rows.Count
            End If
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    '******************************************************************
    Public Function RunTriageFailOtherReport(ByVal strRptName As String, _
                                   ByVal strDateStart As String, _
                                   ByVal strDateEnd As String) As Integer

        Dim strSql As String
        Dim dt As DataTable

        Try
            strSql = "Select " & Environment.NewLine
            strSql &= "tpretest_data.pretest_wkDt as 'Pretest Date', " & Environment.NewLine
            strSql &= "lqcresult.qcresult as 'Pretest Result', " & Environment.NewLine
            strSql &= "lcodesdetail.Dcode_SDesc as 'Test Code', " & Environment.NewLine
            strSql &= "lcodesdetail.Dcode_lDesc as 'Code Desc', " & Environment.NewLine
            strSql &= "tpretest_data.FailOther as 'Fail Other Desc', " & Environment.NewLine
            strSql &= "security.tusers.user_fullname as 'Tester'" & Environment.NewLine
            strSql &= ", if(syxdata.Pss_SerialNumber is null, '',syxdata.Pss_SerialNumber) as 'PSS SN' " & Environment.NewLine
            strSql &= ", if(syxdata.Manuf_SN is null, '', syxdata.Manuf_SN ) as 'Manuf SN' " & Environment.NewLine
            strSql &= ", if(tmodel.Model_Desc is null, '',tmodel.Model_Desc) as 'Model' " & Environment.NewLine
            strSql &= ", if(lmanuf.Manuf_Desc is null, '', lmanuf.Manuf_Desc) as 'Manufacture' " & Environment.NewLine
            strSql &= ", if(lproduct.Prod_Desc is null, '', lproduct.Prod_Desc) as 'Product Type' " & Environment.NewLine
            strSql &= "FROM tdevice INNER JOIN tpretest_data ON tdevice.Device_ID = tpretest_data.Device_ID " & Environment.NewLine
            strSql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.dcode_id " & Environment.NewLine
            strSql &= "INNER JOIN lqcresult on tpretest_data.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
            strSql &= "INNER JOIN security.tusers on security.tusers.user_id=tpretest_data.tester_userid" & Environment.NewLine
            strSql &= "Left outer join syxdata On tpretest_data.Device_ID = syxdata.Device_ID" & Environment.NewLine
            strSql &= "Left outer join tmodel On syxdata.Model_ID = tmodel.Model_ID" & Environment.NewLine
            strSql &= "Left outer join lmanuf On tmodel.Manuf_ID = lmanuf.Manuf_ID" & Environment.NewLine
            strSql &= "Left outer join lproduct On tmodel.Prod_ID = lproduct.Prod_ID" & Environment.NewLine
            strSql &= "WHERE length(tpretest_data.FailOther) > 0" & Environment.NewLine
            strSql &= "And tpretest_data.pretest_wkDt >='" & strDateStart & "'" & Environment.NewLine
            strSql &= "And tpretest_data.pretest_wkDt <='" & strDateEnd & "'" & Environment.NewLine
            strSql &= "AND Device_DateShip is null "
            strSql &= "ORDER BY tpretest_data.tpretest_id, pretest_wkDt;"

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for Triage Fail Other Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            '*************************
            'Format Report
            '*************************
            RunSimpleExcelFormat(dt, strRptName)
            'RunScrapReportFormat(dt, strRptName)
            '*************************

            Return dt.Rows.Count

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    '*****************************************************************************
    Public Function RunReceivingReport(ByVal strRptName As String, _
                                       ByVal WorkOrder As String, _
                                       ByVal Loc_ID As Integer _
                                       ) As Integer

        Dim strSql As String = ""
        Dim dt As DataTable
        Dim strFileName As String = ""
        Dim objSheet, objArrData(,) As Object
        Dim dr As DataRow
        Dim i, j As Integer
        Dim objSaveFileDialog As New SaveFileDialog()

        Try


            '***************************************
            ' Get Summary Report data to Sheet1 ****
            '***************************************
            strSql = "SELECT m.Model_Desc as Model, Count(t.Device_SN) as Quantity" & Environment.NewLine
            strSql &= ",If(p.Pallet_ShipType is null, '', Case p.Pallet_ShipType When 0 then 'Pass' Else 'Fail' End) as 'Status'" & Environment.NewLine
            strSql &= "FROM tdevice t " & Environment.NewLine
            strSql &= "Left Join tworkorder w on w.WO_ID=t.WO_ID" & Environment.NewLine
            strSql &= "Left Join tmodel m on m.Model_ID=t.Model_ID" & Environment.NewLine
            strSql &= "Left Join tpallett p on p.Pallett_ID=t.Pallett_ID" & Environment.NewLine
            strSql &= "Where t.Loc_ID=" & Loc_ID & " And w.wo_custwo='" & WorkOrder & "'" & Environment.NewLine
            strSql &= "Group By Model,Status;" & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No Receiving Summary data for selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If
            objSheet = Me._objWorkbook.Worksheets.Item(1)
            objSheet.Name = "Summary"
            objSheet.Activate()

            ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
            i = 0 : j = 0
            For Each dr In dt.Rows
                '********************************
                'Create Header
                '********************************
                If i = 0 Then
                    For j = 0 To dt.Columns.Count - 1
                        objArrData(i, j) = dt.Columns(j).Caption
                    Next j
                    i += 1
                End If
                '********************************
                'Data
                '********************************
                For j = 0 To dt.Columns.Count - 1
                    objArrData(i, j) = dr(j)
                Next j
                i += 1
            Next dr
            '********************************
            'Post data to excel sheet
            '********************************
            With objSheet
                .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData
                .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                With Me._objXL.Selection
                    .WrapText = False
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Interior.ColorIndex = 37
                    .Interior.Pattern = Excel.Constants.xlSolid
                End With
                .Cells.EntireColumn.AutoFit()
                .Cells.EntireRow.AutoFit()

            End With

            '***************************************
            ' Get Details Report data to Sheet2 ****
            '***************************************
            strSql = "SELECT t.WO_ID as WorkOrder, m.Model_Desc as Model, t.Device_SN as Serial" & Environment.NewLine
            strSql &= ",If(p.Pallet_ShipType is null, '', Case p.Pallet_ShipType When 0 then 'Pass' Else 'Fail' End) as 'Status'" & Environment.NewLine
            strSql &= ",Device_RecWorkDate as 'Receive Date' , Device_DateShip as 'Ship Date' " & Environment.NewLine
            strSql &= "FROM tdevice t " & Environment.NewLine
            strSql &= "Left Join tworkorder w on w.WO_ID=t.WO_ID" & Environment.NewLine
            strSql &= "Left Join tmodel m on m.Model_ID=t.Model_ID" & Environment.NewLine
            strSql &= "Left Join tpallett p on p.Pallett_ID=t.Pallett_ID" & Environment.NewLine
            strSql &= "Where t.Loc_ID=" & Loc_ID & " And w.wo_custwo='" & WorkOrder & "'" & Environment.NewLine
            strSql &= "Order by m.Model_Desc,t.Device_SN Desc;" & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No Receiving Detail data for selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            Me._objXL.Application.DisplayAlerts = False
            'objSheet = Me._objWorkbook.Worksheets("Sheet2")
            objSheet = Me._objWorkbook.Worksheets.Item(2)
            objSheet.Name = "Detail"
            objSheet.Activate()

            ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
            i = 0 : j = 0
            For Each dr In dt.Rows
                '********************************
                'Create Header
                '********************************
                If i = 0 Then
                    For j = 0 To dt.Columns.Count - 1
                        objArrData(i, j) = dt.Columns(j).Caption
                    Next j
                    i += 1
                End If
                '********************************
                'Data
                '********************************
                For j = 0 To dt.Columns.Count - 1
                    objArrData(i, j) = dr(j)
                Next j
                i += 1
            Next dr
            '********************************
            'Post data to excel sheet
            '********************************
            With objSheet
                .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData
                .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                With Me._objXL.Selection
                    .WrapText = False
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Interior.ColorIndex = 37
                    .Interior.Pattern = Excel.Constants.xlSolid
                End With
                .Cells.EntireColumn.AutoFit()
                .Cells.EntireRow.AutoFit()

            End With

            '*****************************************************
            ' Save to file ***************************************
            '*****************************************************

            Me._objXL.Sheets("Sheet3").Delete()
            'Return to Sheet1; user will see Summary Report when open the workbook
            objSheet = Me._objWorkbook.Worksheets.Item(1)
            objSheet.Activate()

            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = strRptName & "_" & WorkOrder & ".xls"
            objSaveFileDialog.ShowDialog()
            strFileName = objSaveFileDialog.FileName

            If strFileName.Trim.Length = 0 Then
                MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If strFileName.IndexOf("\") < 0 Then Exit Function
                If File.Exists(strFileName) = True Then Kill(strFileName)
                Me._objWorkbook.SaveAs(strFileName)
                MessageBox.Show(strRptName & "_" & WorkOrder & " file has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '*****************************************************

            Return dt.Rows.Count

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
            End If
            If Not IsNothing(_objDataProc) Then
                PSS.Data.Buisness.Generic.NAR(_objDataProc)
            End If
            If Not IsNothing(objSheet) Then
                PSS.Data.Buisness.Generic.NAR(objSheet)
            End If
            If Not IsNothing(objArrData) Then
                PSS.Data.Buisness.Generic.NAR(objArrData)
            End If
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False)
                PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit()
                PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Function
    '*****************************************************************************
    Private Sub RunScrapReportFormat(ByVal dt As DataTable, ByVal strRptName As String)
        Dim strFileName, strComName As String
        Dim objSheet, objArrData(,) As Object
        Dim R1 As DataRow
        Dim i, j, iPageBreakRow() As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim booNewComName As Boolean = False

        Try
            strFileName = "" : iPageBreakRow = Nothing : strComName = ""
            Me._objXL.Application.DisplayAlerts = False
            objSheet = _objWorkbook.Worksheets("Sheet1")

            ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
            i = 0 : j = 0

            For Each R1 In dt.Rows
                'break page on very new computer name
                If strComName <> R1("Computer Name").ToString.ToLower Then
                    strComName = R1("Computer Name").ToString.Trim.ToLower
                    booNewComName = True
                End If

                '********************************
                'Create Header
                '********************************
                If i = 0 Then
                    For j = 0 To dt.Columns.Count - 1
                        objArrData(i, j) = dt.Columns(j).Caption
                    Next j
                    i += 1
                End If

                '********************************
                'Data 
                '********************************
                If booNewComName Then
                    objArrData(i, 0) = R1("Customer Name") : objArrData(i, 1) = R1("Computer Name")

                    If IsNothing(iPageBreakRow) Then
                        ReDim iPageBreakRow(0) : iPageBreakRow(iPageBreakRow.Length - 1) = i + 1
                    Else
                        ReDim Preserve iPageBreakRow(UBound(iPageBreakRow) + 1) : iPageBreakRow(iPageBreakRow.Length - 1) = i + 1
                    End If

                    booNewComName = False
                End If

                For j = 2 To dt.Columns.Count - 1
                    objArrData(i, j) = R1(j)
                Next j
                '********************************

                i += 1
                '********************************
            Next R1

            '********************************
            'Post data to excel sheet
            '********************************
            With objSheet
                .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                With Me._objXL.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    '.Font.ColorIndex = 5
                    .Interior.ColorIndex = 37
                    .Interior.Pattern = Excel.Constants.xlSolid
                End With

                .Cells.EntireColumn.AutoFit()
                .Cells.EntireRow.AutoFit()

                'print header on every pages
                .PageSetup.PrintTitleRows = .Rows(1).Address
                .PageSetup.FitToPagesWide = 1
                .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape

                'page break
                For i = 1 To iPageBreakRow.Length - 1
                    .HPageBreaks.Add(.Range("A" & (iPageBreakRow(i)).ToString()))
                Next i

                objSaveFileDialog.DefaultExt = "xls"
                objSaveFileDialog.FileName = strRptName & ".xls"
                objSaveFileDialog.ShowDialog()
                strFileName = objSaveFileDialog.FileName

                If strFileName.Trim.Length = 0 Then
                    MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If strFileName.IndexOf("\") < 0 Then Exit Sub
                    If File.Exists(strFileName) = True Then Kill(strFileName)
                    Me._objWorkbook.SaveAs(strFileName)
                    MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With

            '********************************
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                objSaveFileDialog = Nothing
            End If
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._objDataProc = Nothing
            If Not IsNothing(objSheet) Then
                PSS.Data.Buisness.Generic.NAR(objSheet)
            End If
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False)
                PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit()
                PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Sub

    '*****************************************************************************

    Public Sub RunExcel_PerSheetPerTableWithOpen(ByVal ds As DataSet, ByVal strRptName As String)
        _lastSimpleFileSaved = ""
        RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName)
        If _lastSimpleFileSaved <> "" Then
            OpenExcelFile(_lastSimpleFileSaved)
        End If
    End Sub

	Public Sub RunSimpleXlAndOpen(ByVal dt As DataTable, ByVal strRptName As String, _
	   Optional ByVal strTextCol() As String = Nothing, _
	   Optional ByVal DollarNumberCol() As String = Nothing)
		_lastSimpleFileSaved = ""
		RunSimpleExcelFormat(dt, strRptName, strTextCol, DollarNumberCol)
		If _lastSimpleFileSaved <> "" Then
			OpenExcelFile(_lastSimpleFileSaved)
		End If
	End Sub

	Public Sub RunSimpleExcelFormat(ByVal dt As DataTable, ByVal strRptName As String, _
	   Optional ByVal strTextCol() As String = Nothing, _
	   Optional ByVal DollarNumberCol() As String = Nothing)
		Dim strFileName As String = ""
		Dim objSheet, objArrData(,) As Object
		Dim R1 As DataRow
		Dim i, j As Integer
		Dim objSaveFileDialog As New SaveFileDialog()

		Try
			If dt.Rows.Count = 0 Then Exit Sub

			strFileName = ""
			'strRptName = ""
			Me._objXL.Application.DisplayAlerts = False
			objSheet = _objWorkbook.Worksheets("Sheet1")

			If Not IsNothing(strTextCol) Then
				For i = 0 To strTextCol.Length - 1
					If strTextCol(i).Trim.Length > 0 Then
						Me._objXL.Columns(strTextCol(i) & ":" & strTextCol(i)).Select()
						Me._objXL.Selection.NumberFormat = "@"
					End If
				Next i
			End If

			If Not IsNothing(DollarNumberCol) Then
				For i = 0 To DollarNumberCol.Length - 1
					If DollarNumberCol(i).Trim.Length > 0 Then
						Me._objXL.Columns(DollarNumberCol(i) & ":" & DollarNumberCol(i)).Select()
						Me._objXL.Selection.NumberFormat = "$#,##0.00"
					End If
				Next i
			End If

			ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
			i = 0 : j = 0

			For Each R1 In dt.Rows
				'********************************
				'Create Header
				'********************************
				If i = 0 Then
					For j = 0 To dt.Columns.Count - 1
						objArrData(i, j) = dt.Columns(j).Caption
					Next j
					i += 1
				End If

				'********************************
				'Data
				'********************************
				For j = 0 To dt.Columns.Count - 1
					objArrData(i, j) = R1(j)
				Next j
				i += 1
				'********************************
			Next R1

			'********************************
			'Post data to excel sheet
			'********************************
			With objSheet
				.Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

				.Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
				With Me._objXL.Selection
					.WrapText = True
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
				objSaveFileDialog.FileName = strRptName & ".xls"
				objSaveFileDialog.ShowDialog()
				strFileName = objSaveFileDialog.FileName

				If strFileName.Trim.Length = 0 Then
					MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Else
					If strFileName.IndexOf("\") < 0 Then Exit Sub
					If File.Exists(strFileName) = True Then Kill(strFileName)
					Me._objWorkbook.SaveAs(strFileName)
					_lastSimpleFileSaved = strFileName
					MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			End With
			'********************************
		Catch ex As Exception
			Throw ex
		Finally
			If Not IsNothing(objSaveFileDialog) Then
				objSaveFileDialog.Dispose()
				'objSaveFileDialog = Nothing() Hung Nguyen 11/07/2011 This casue error
			End If
			PSS.Data.Buisness.Generic.DisposeDT(dt)
			Me._objDataProc = Nothing
			If Not IsNothing(objSheet) Then
				PSS.Data.Buisness.Generic.NAR(objSheet)
			End If
			If Not IsNothing(Me._objWorkbook) Then
				_objWorkbook.Close(False)
				PSS.Data.Buisness.Generic.NAR(_objWorkbook)
			End If
			If Not IsNothing(Me._objXL) Then
				_objXL.Quit()
				PSS.Data.Buisness.Generic.NAR(_objXL)
			End If
		End Try
	End Sub

	'*****************************************************************************
	Public Function RunAverageInvoiceAmt(ByVal strDateStart As String, ByVal strDateEnd As String, ByVal iCustID As Integer)
		Dim strSql As String = ""
		Dim dtData, dtInvAmt As DataTable
		Dim objSheet, objArrData(,) As Object
		Dim R1 As DataRow
		Dim i, j As Integer
		Dim objSaveFileDialog As New SaveFileDialog()
		Dim strFileName As String = ""

		Try
			strSql = "SELECT Distinct tmodel.Model_ID, Model_Desc as Model, concat(Year(Device_ShipWorkDate), LPad(Week(Device_ShipWorkDate), 2,'0' ) ) as 'WK#'" & Environment.NewLine
			strSql &= ", Count(*) as 'UnitQuantity', 0.0 as 'TotalCOS', 0.0 as 'TotalFUN', 0.0 as 'AVGCOS', 0.0 as 'AVGFUN' " & Environment.NewLine
			strSql &= "FROM tpallett " & Environment.NewLine
			strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
			strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
			strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "'" & Environment.NewLine
			strSql &= "AND Pallet_ShipType = 0 " & Environment.NewLine
			strSql &= "GROUP BY Model_ID, 'WK#' " & Environment.NewLine
			strSql &= "ORDER BY Model" & Environment.NewLine
			dtData = Me._objDataProc.GetDataTable(strSql)
			If dtData.Rows.Count = 0 Then
				MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Else
				strSql = "SELECT Distinct tmodel.Model_ID, Model_Desc as Model, concat(Year(Device_ShipWorkDate), LPad(Week(Device_ShipWorkDate), 2,'0' ) ) as 'WK#', tpsmap.LaborLevel " & Environment.NewLine
				strSql &= ", sum(DBill_InvoiceAmt) as 'TotalInvAmt' " & Environment.NewLine
				strSql &= "FROM tpallett " & Environment.NewLine
				strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
				strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
				strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID= tpsmap.Model_ID AND tdevicebill.BillCode_ID = tpsmap.BillCode_ID" & Environment.NewLine
				strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "'" & Environment.NewLine
				strSql &= "AND Pallet_ShipType = 0 " & Environment.NewLine
				strSql &= "GROUP BY Model_Desc, 'WK#', tpsmap.LaborLevel " & Environment.NewLine
				strSql &= "ORDER BY Model" & Environment.NewLine
				dtInvAmt = Me._objDataProc.GetDataTable(strSql)

				For Each R1 In dtData.Rows
					R1.BeginEdit()
					If Not IsDBNull(dtInvAmt.Compute("Sum(TotalInvAmt)", "LaborLevel < 2 AND Model_ID = " & R1("Model_ID") & " AND [WK#] = '" & R1("WK#") & "'")) Then R1("TotalCOS") = Format(Convert.ToDouble(dtInvAmt.Compute("Sum(TotalInvAmt)", "LaborLevel < 2 AND Model_ID = " & R1("Model_ID") & " AND [WK#] = '" & R1("WK#") & "'")), "###,##0.00")
					If Not IsDBNull(dtInvAmt.Compute("Sum(TotalInvAmt)", "LaborLevel > 1 AND Model_ID = " & R1("Model_ID") & " AND [WK#] = '" & R1("WK#") & "'")) Then R1("TotalFUN") = Format(Convert.ToDouble(dtInvAmt.Compute("Sum(TotalInvAmt)", "LaborLevel > 1 AND Model_ID = " & R1("Model_ID") & " AND [WK#] = '" & R1("WK#") & "'")), "###,##0.00")
					If Convert.ToInt32(R1("UnitQuantity")) > 0 Then
						R1("AVGCOS") = Format(Convert.ToDouble(R1("TotalCOS")) / Convert.ToInt32(R1("UnitQuantity")), "###,##0.00")
						R1("AVGFUN") = Format(Convert.ToDouble(R1("TotalFUN")) / Convert.ToInt32(R1("UnitQuantity")), "###,##0.00")
					End If
					R1.EndEdit()
				Next R1

				dtData.Columns.Remove("Model_ID") : dtData.AcceptChanges()

				Me._objXL.Application.DisplayAlerts = False
				objSheet = _objWorkbook.Worksheets("Sheet1")

				ReDim objArrData(dtData.Rows.Count + 1, dtData.Columns.Count)
				i = 0 : j = 0

				For Each R1 In dtData.Rows
					'********************************
					'Create Header
					'********************************
					If i = 0 Then
						For j = 0 To dtData.Columns.Count - 1
							objArrData(i, j) = dtData.Columns(j).Caption
						Next j
						i += 1
					End If

					'********************************
					'Data
					'********************************
					For j = 0 To dtData.Columns.Count - 1
						objArrData(i, j) = R1(j)
					Next j
					i += 1
					'********************************
				Next R1

				'********************************
				'Post data to excel sheet
				'********************************
				With objSheet
					.Range("A1:" & Buisness.Generic.CalExcelColLetter(dtData.Columns.Count) & (dtData.Rows.Count + 1).ToString).Value = objArrData

					.Range("A1:" & Buisness.Generic.CalExcelColLetter(dtData.Columns.Count) & "1").Select()
					With Me._objXL.Selection
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
					objSaveFileDialog.FileName = "AvgInvPrice_" & Convert.ToDateTime(strDateStart).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strDateEnd).ToString("yyyyMMdd") & ".xls"
					objSaveFileDialog.ShowDialog()
					strFileName = objSaveFileDialog.FileName

					If strFileName.Trim.Length = 0 Then
						MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						If strFileName.IndexOf("\") < 0 Then Exit Function
						If File.Exists(strFileName) = True Then Kill(strFileName)
						Me._objWorkbook.SaveAs(strFileName)
						MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
				End With
				'********************************
			End If

		Catch ex As Exception
			Throw ex
		Finally
			objArrData = Nothing : R1 = Nothing : Me._objDataProc = Nothing
			PSS.Data.Buisness.Generic.DisposeDT(dtData)
			PSS.Data.Buisness.Generic.DisposeDT(dtInvAmt)
			If Not IsNothing(objSaveFileDialog) Then
				objSaveFileDialog.Dispose()
				objSaveFileDialog = Nothing
			End If
			If Not IsNothing(objSheet) Then
				PSS.Data.Buisness.Generic.NAR(objSheet)
			End If
			If Not IsNothing(Me._objWorkbook) Then
				_objWorkbook.Close(False)
				PSS.Data.Buisness.Generic.NAR(_objWorkbook)
			End If
			If Not IsNothing(Me._objXL) Then
				_objXL.Quit()
				PSS.Data.Buisness.Generic.NAR(_objXL)
			End If
		End Try
	End Function

	'*****************************************************************************
	Public Function MessagingMonthlyInvoiceSummaryRpt(ByVal iStartMonth As Integer, ByVal iStartYear As Integer _
	  , ByVal iEndMonth As Integer, ByVal iEndYear As Integer, ByVal iCustID As Integer)
		Dim strSql, strFileName, strDateStart, strDateEnd As String
		Dim dtModels, dtMonths, dtRepLaborAmt, dtRepPartAmt, dtRURLaborAmt As DataTable
		Dim objSheet, objArrData(,) As Object
		Dim R1, R2 As DataRow
		Dim i, iLineNo, iMonthCount As Integer
		Dim objSaveFileDialog As New SaveFileDialog()


		Try
			strSql = "" : strFileName = "" : strDateStart = "" : strDateEnd = ""
			i = 0 : iLineNo = 0 : iMonthCount = 0
			strDateStart = iStartYear.ToString().PadLeft(4, "0") & "-" & iStartMonth.ToString().PadLeft(2, "0") & "-01"
			strDateEnd = iEndYear.ToString().PadLeft(4, "0") & "-" & iEndMonth.ToString().PadLeft(2, "0") & "-31"

			strSql = "SELECT Distinct tmodel.Model_ID, Model_Desc as Model" & Environment.NewLine
			strSql &= "FROM tdevice " & Environment.NewLine
			strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
			strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
			strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "'" & Environment.NewLine
			strSql &= "ORDER BY Model" & Environment.NewLine
			dtModels = Me._objDataProc.GetDataTable(strSql)
			If dtModels.Rows.Count = 0 Then
				MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Else
				strSql = "SELECT Distinct date_format( Device_ShipWorkDate, '%M') as MonthDescription, month(Device_ShipWorkDate) as ShipMonth, year(Device_ShipWorkDate) as ShipYear, concat( month(Device_ShipWorkDate) as ShipMonth, year(Device_ShipWorkDate) as ShipMonthYear )" & Environment.NewLine
				strSql &= "FROM tdevice " & Environment.NewLine
				strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
				strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "'" & Environment.NewLine
				strSql &= "ORDER BY ShipMonthYear" & Environment.NewLine
				dtMonths = Me._objDataProc.GetDataTable(strSql)

				ReDim objArrData(dtModels.Rows.Count + 10, (dtMonths.Columns.Count * 6) + 1)
				objArrData(0, 0) = "SUMMARY" : objArrData(1, 0) = "Model" : iLineNo = 3

				'***************************************
				'Assign Model description in column A
				'***************************************
				For Each R1 In dtModels.Rows
					objArrData(iLineNo, 0) = R1("Model") : iLineNo += 1
				Next R1

				'***************************************
				'Loop through each month
				'***************************************
				For Each R1 In dtMonths.Rows
					iLineNo = 3 : i = 0 : Generic.DisposeDT(dtRepLaborAmt) : Generic.DisposeDT(dtRepPartAmt) : Generic.DisposeDT(dtRURLaborAmt)

					If iCustID = 14 Then					  'American Messaging
						'NOTHING YET
					Else
						strSql = "SELECT tdevice.Model_ID, count(*) as Qty, Sum(Device_Labor) as LaborAmt" & Environment.NewLine
						strSql &= "FROM tdevice " & Environment.NewLine
						strSql &= "INNER JOIN tpallett ON tpallett_ID.Device_ID = tpallett.Pallett_ID " & Environment.NewLine
						strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & R2("ShipYear") & R2("ShipMonth").ToString().PadLeft(2, "0") & "-01" & "' AND '" & R2("ShipYear") & R2("ShipMonth").ToString().PadLeft(2, "0") & "-31" & "'" & Environment.NewLine
						strSql &= "AND Pallet_ShipType = 0"
						strSql &= "Group By tdevice.Model_ID" & Environment.NewLine
						dtRepLaborAmt = Me._objDataProc.GetDataTable(strSql)

						strSql = "SELECT tdevice.Model_ID, Sum(DBill_InvoiceAmt) as PartAmt" & Environment.NewLine
						strSql &= "FROM tdevice " & Environment.NewLine
						strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
						strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
						strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & R2("ShipYear") & R2("ShipMonth").ToString().PadLeft(2, "0") & "-01" & "' AND '" & R2("ShipYear") & R2("ShipMonth").ToString().PadLeft(2, "0") & "-31" & "'" & Environment.NewLine
						strSql &= "AND Pallet_ShipType = 0"
						strSql &= "Group By tdevice.Model_ID" & Environment.NewLine
						dtRepPartAmt = Me._objDataProc.GetDataTable(strSql)

						strSql = "SELECT tdevice.Model_ID, count(*) as Qty, Sum(Device_Labor) as LaborAmt" & Environment.NewLine
						strSql &= "FROM tdevice " & Environment.NewLine
						strSql &= "INNER JOIN tpallett ON tpallett_ID.Device_ID = tpallett.Pallett_ID " & Environment.NewLine
						strSql &= "WHERE Cust_ID = " & iCustID & " AND Device_ShipWorkDate BETWEEN '" & R2("ShipYear") & R2("ShipMonth").ToString().PadLeft(2, "0") & "-01" & "' AND '" & R2("ShipYear") & R2("ShipMonth").ToString().PadLeft(2, "0") & "-31" & "'" & Environment.NewLine
						strSql &= "AND Pallet_ShipType > 0"
						strSql &= "Group By tdevice.Model_ID" & Environment.NewLine
						dtRURLaborAmt = Me._objDataProc.GetDataTable(strSql)
					End If

					For Each R2 In dtModels.Rows
						objArrData(iLineNo, (iMonthCount * 6) + 2 + 0) = ""
						If dtRepLaborAmt.Select("Model_ID = " & R2("Model_ID")).Length > 0 Then
							objArrData(iLineNo, (iMonthCount * 6) + 2 + 1) = dtRepLaborAmt.Select("Model_ID = " & R2("Model_ID"))(0)("Qty")
							objArrData(iLineNo, (iMonthCount * 6) + 2 + 2) = dtRepLaborAmt.Select("Model_ID = " & R2("Model_ID"))(0)("LaborAmt")
						End If

						If dtRepPartAmt.Select("Model_ID = " & R2("Model_ID")).Length > 0 Then objArrData(iLineNo, (iMonthCount * 6) + 2 + 3) = dtRepPartAmt.Select("Model_ID = " & R2("Model_ID"))(0)("PartAmt")
						objArrData(iLineNo, (iMonthCount * 6) + 2 + 4) = ""
						objArrData(iLineNo, (iMonthCount * 6) + 2 + 5) = ""
					Next R2

					iMonthCount += 1
				Next R1

				'Me._objXL.Application.DisplayAlerts = False
				'objSheet = _objWorkbook.Worksheets("Sheet1")

				'ReDim objArrData(dtData.Rows.Count + 1, dtData.Columns.Count)
				'i = 0 : j = 0

				'For Each R1 In dtData.Rows
				'    '********************************
				'    'Create Header
				'    '********************************
				'    If i = 0 Then
				'        For j = 0 To dtData.Columns.Count - 1
				'            objArrData(i, j) = dtData.Columns(j).Caption
				'        Next j
				'        i += 1
				'    End If

				'    '********************************
				'    'Data
				'    '********************************
				'    For j = 0 To dtData.Columns.Count - 1
				'        objArrData(i, j) = R1(j)
				'    Next j
				'    i += 1
				'    '********************************
				'Next R1

				''********************************
				''Post data to excel sheet
				''********************************
				'With objSheet
				'    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dtData.Columns.Count) & (dtData.Rows.Count + 1).ToString).Value = objArrData

				'    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dtData.Columns.Count) & "1").Select()
				'    With Me._objXL.Selection
				'        '.WrapText = True
				'        .HorizontalAlignment = Excel.Constants.xlCenter
				'        .VerticalAlignment = Excel.Constants.xlCenter
				'        .font.bold = True
				'        '.Font.ColorIndex = 5
				'        .Interior.ColorIndex = 37
				'        .Interior.Pattern = Excel.Constants.xlSolid
				'    End With

				'    .Cells.EntireColumn.AutoFit()
				'    .Cells.EntireRow.AutoFit()

				'    objSaveFileDialog.DefaultExt = "xls"
				'    objSaveFileDialog.FileName = "AvgInvPrice_" & Convert.ToDateTime(strDateStart).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strDateEnd).ToString("yyyyMMdd") & ".xls"
				'    objSaveFileDialog.ShowDialog()
				'    strFileName = objSaveFileDialog.FileName

				'    If strFileName.Trim.Length = 0 Then
				'        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				'    Else
				'        If strFileName.IndexOf("\") < 0 Then Exit Function
				'        If File.Exists(strFileName) = True Then Kill(strFileName)
				'        Me._objWorkbook.SaveAs(strFileName)
				'        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				'    End If
				'End With
				''********************************

			End If

		Catch ex As Exception
			Throw ex
		Finally
			objArrData = Nothing : R1 = Nothing : R2 = Nothing : Me._objDataProc = Nothing
			Generic.DisposeDT(dtRepLaborAmt) : Generic.DisposeDT(dtRepPartAmt) : Generic.DisposeDT(dtRURLaborAmt)
			Generic.DisposeDT(dtModels) : Generic.DisposeDT(dtMonths)
			If Not IsNothing(objSaveFileDialog) Then
				objSaveFileDialog.Dispose()
				objSaveFileDialog = Nothing
			End If
			If Not IsNothing(objSheet) Then
				PSS.Data.Buisness.Generic.NAR(objSheet)
			End If
			If Not IsNothing(Me._objWorkbook) Then
				_objWorkbook.Close(False)
				PSS.Data.Buisness.Generic.NAR(_objWorkbook)
			End If
			If Not IsNothing(Me._objXL) Then
				_objXL.Quit()
				PSS.Data.Buisness.Generic.NAR(_objXL)
			End If
		End Try
	End Function

	'*****************************************************************************
	Public Function RVSavingReport(ByVal strDateStart As String, ByVal strDateEnd As String, ByVal iCustID As Integer, ByVal bSpecialBilling As Boolean) As Integer
		Dim strSql As String = ""
		Dim dtManufs, dtDevices, dtParts, dtBillcodes As DataTable
		Dim objSheet, objArrData(,) As Object
		Dim R1, drManufID As DataRow
		Dim i, j, k As Integer
		Dim objSaveFileDialog As New SaveFileDialog()
		Dim strFileName As String = ""
		Dim dbTotalSaving As Double = 0.0
		Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
		  Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

		Try
			strSql = "SELECT Distinct lmanuf.Manuf_ID, lmanuf.Manuf_Desc " & Environment.NewLine
			strSql &= "FROM tpackingslip " & Environment.NewLine
			strSql &= "INNER JOIN tpallett ON tpackingslip.pkslip_ID = tpallett.pkslip_ID AND tpackingslip.Cust_ID = " & iCustID & " AND pkslip_createDt BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' AND Pallet_ShipType = 0 " & Environment.NewLine
			strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
			strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
			strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID" & Environment.NewLine
			If bSpecialBilling Then
				strSql &= "INNER JOIN tdevicebill_special tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
			Else
				strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
			End If
			strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
			strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.Psprice_ID AND lpsprice.RVFlag = 1 " & Environment.NewLine
			strSql &= "ORDER BY lmanuf.Manuf_Desc "
			dtManufs = Me._objDataProc.GetDataTable(strSql)

			If dtManufs.Rows.Count = 0 Then
				MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Else
				Me._objXL.Application.DisplayAlerts = False

				For Each drManufID In dtManufs.Rows
					strSql = "SELECT Distinct concat(Cust_Name1, ' ', if( Cust_Name2 is null, '', Cust_name2)) as Company, Loc_Name as 'Account No' " & Environment.NewLine
					strSql &= ", tpackingslip.pkslip_ID as 'Manifest No', tworkorder.WO_CustWO as 'Workorder No' " & Environment.NewLine
					strSql &= ", Date_Format(pkslip_createDt, '%m/%d/%Y') as 'Shipping Date', Device_SN as 'Serial No', Device_OldSN as 'Old Serial No'" & Environment.NewLine
					strSql &= ", if( FuncRep = 1, 'FUN', 'COS') as 'Fun/Cos', Manuf_Desc as Manufacture, Model_Desc as 'Model'" & Environment.NewLine
					strSql &= ", if( Device_ManufWrty = 1, 'Yes', 'No') as 'Manuf Wrty', if( Device_PSSWrty = 1, 'Yes', 'No') as 'PSS Wrty' " & Environment.NewLine
					strSql &= "FROM tpackingslip " & Environment.NewLine
					strSql &= "INNER JOIN tpallett ON tpackingslip.pkslip_ID = tpallett.pkslip_ID AND tpackingslip.Cust_ID = " & iCustID & " AND pkslip_createDt BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' AND Pallet_ShipType = 0 " & Environment.NewLine
					strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
					strSql &= "INNER JOIN edi.titem ON tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
					strSql &= "INNER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID " & Environment.NewLine
					strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID AND tmodel.Manuf_ID = " & drManufID("Manuf_ID") & Environment.NewLine
					strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
					strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
					strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID" & Environment.NewLine

					If bSpecialBilling Then
						strSql &= "INNER JOIN tdevicebill_special tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
					Else
						strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
					End If

					strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
					strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.Psprice_ID AND lpsprice.RVFlag = 1 " & Environment.NewLine
					dtDevices = Me._objDataProc.GetDataTable(strSql)

					strSql = "SELECT Distinct lbillcodes.Billcode_ID, concat(lbillcodes.Billcode_ID, ' ', Billcode_Desc, ' ', BillType_ID) as 'Billcode' " & Environment.NewLine
					strSql &= "FROM tpackingslip " & Environment.NewLine
					strSql &= "INNER JOIN tpallett ON tpackingslip.pkslip_ID = tpallett.pkslip_ID AND  tpackingslip.Cust_ID = " & iCustID & " AND pkslip_createDt BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' AND Pallet_ShipType = 0 " & Environment.NewLine
					strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
					strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID AND tmodel.Manuf_ID = " & drManufID("Manuf_ID") & Environment.NewLine
					If bSpecialBilling Then
						strSql &= "INNER JOIN tdevicebill_special tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
					Else
						strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
					End If
					strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
					strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
					strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.Psprice_ID AND lpsprice.RVFlag = 1 " & Environment.NewLine
					strSql &= "ORDER BY lbillcodes.Billcode_ID"
					dtBillcodes = Me._objDataProc.GetDataTable(strSql)

					ReDim objArrData(dtDevices.Rows.Count + 2, dtDevices.Columns.Count + (dtBillcodes.Rows.Count * 3) + 1)
					objSheet = Me._objWorkbook.Sheets.Add() : objSheet.Activate()
					objSheet.Name = drManufID("Manuf_Desc")

					i = 0 : j = 0

					For Each R1 In dtDevices.Rows
						'********************************
						'Create Header
						'********************************
						If i = 0 Then
							For j = 0 To dtDevices.Columns.Count - 1							'Device Information
								objArrData(i, j) = dtDevices.Columns(j).Caption
							Next j

							For k = 0 To dtBillcodes.Rows.Count - 1
								objArrData(i, j) = dtBillcodes.Rows(k)("Billcode")
								j += 3
							Next k

							i += 1

							j = dtDevices.Columns.Count
							For k = 0 To dtBillcodes.Rows.Count - 1
								objArrData(i, j) = "Reg Part Price" : objArrData(i, j + 1) = "RV Price" : objArrData(i, j + 2) = "Savings"
								j += 3
							Next k
							objArrData(i, j) = "Total Savings"

							i += 1
						End If

						'********************************
						'Data
						'********************************
						'Device information
						For j = 0 To dtDevices.Columns.Count - 1
							objArrData(i, j) = R1(j)
						Next j

						'Part Information
						dbTotalSaving = 0.0
						dtParts = Me.GetBilledRVPart(R1("Manifest No"), R1("Serial No"), bSpecialBilling)
						j = dtDevices.Columns.Count
						For k = 0 To dtBillcodes.Rows.Count - 1
							If dtParts.Select("Billcode_ID = " & dtBillcodes.Rows(k)("Billcode_ID")).Length > 0 Then
								objArrData(i, j) = dtParts.Select("Billcode_ID = " & dtBillcodes.Rows(k)("Billcode_ID"))(0)("DBill_RegPartPrice")
								objArrData(i, j + 1) = dtParts.Select("Billcode_ID = " & dtBillcodes.Rows(k)("Billcode_ID"))(0)("DBill_InvoiceAmt")
								objArrData(i, j + 2) = "=RC[-2]-RC[-1]"
								dbTotalSaving += Convert.ToDecimal(dtParts.Select("Billcode_ID = " & dtBillcodes.Rows(k)("Billcode_ID"))(0)("DBill_RegPartPrice")) - Convert.ToDecimal(dtParts.Select("Billcode_ID = " & dtBillcodes.Rows(k)("Billcode_ID"))(0)("DBill_InvoiceAmt"))
							End If

							j += 3
						Next k

						objArrData(i, dtDevices.Columns.Count + (dtBillcodes.Rows.Count * 3)) = dbTotalSaving

						i += 1
						'********************************
					Next R1

					'********************************
					'Post data to excel sheet
					'********************************
					With objSheet
						'*******************************
						'format
						'*******************************
						objSheet.Columns("A:D").Select() : Me._objXL.Selection.NumberFormat = "@"
						objSheet.Columns("F:L").Select() : Me._objXL.Selection.NumberFormat = "@"
						objSheet.Range("M2:" & Buisness.Generic.CalExcelColLetter(dtDevices.Columns.Count + (dtBillcodes.Rows.Count * 3) + 2) & (dtDevices.Rows.Count + 2).ToString).NumberFormat = "$#,##0.00"

						'Draw a border
						Me._objXL.Range("A2:" & Generic.CalExcelColLetter(dtDevices.Columns.Count + (dtBillcodes.Rows.Count * 3) + 1) & (dtDevices.Rows.Count + 2).ToString).Select()
						Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
						Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

						For i = 0 To xlBI.Length - 1
							With Me._objXL.Selection.Borders(xlBI(i))
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThin
								.ColorIndex = Excel.Constants.xlAutomatic
							End With
						Next i
						'**************************************

						'**************************************
						'merge header & align to center
						'**************************************
						.Range("A2", Generic.CalExcelColLetter(dtDevices.Columns.Count) & "2").Merge()
						j = dtDevices.Columns.Count
						For k = 0 To dtBillcodes.Rows.Count - 1
							.Range(Generic.CalExcelColLetter(j + 1) & "1", Generic.CalExcelColLetter(j + 3) & "1").Merge()

							'align to center
							.Range(Generic.CalExcelColLetter(j + 1) & "1", Generic.CalExcelColLetter(j + 3) & "1").Select()
							With Me._objXL.Selection
								.HorizontalAlignment = Excel.Constants.xlCenter
								.VerticalAlignment = Excel.Constants.xlCenter
								.font.bold = True
							End With

							'Draw a border 
							Me._objXL.Range(Generic.CalExcelColLetter(j + 1) & "1:" & Generic.CalExcelColLetter(j + 3) & (1).ToString).Select()
							Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
							Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlThin

							'draw thick border
							Me._objXL.Range(Generic.CalExcelColLetter(j + 1) & "1:" & Generic.CalExcelColLetter(j + 3) & (dtDevices.Rows.Count + 2).ToString).Select()
							With Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
								.LineStyle = Excel.XlLineStyle.xlContinuous
								.Weight = Excel.XlBorderWeight.xlThick
								.ColorIndex = 25
							End With

							j += 3
						Next k

						'draw last thick border
						Me._objXL.Range(Generic.CalExcelColLetter(j + 1) & "1:" & Generic.CalExcelColLetter(j + 3) & (dtDevices.Rows.Count + 2).ToString).Select()
						With Me._objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
							.LineStyle = Excel.XlLineStyle.xlContinuous
							.Weight = Excel.XlBorderWeight.xlThick
							.ColorIndex = 25
						End With

						'Freeze Pane
						Me._objXL.ActiveWindow.FreezePanes = False
						Me._objXL.Range("A3:" & Generic.CalExcelColLetter(dtDevices.Columns.Count + (dtBillcodes.Rows.Count * 3) + 1) & (3).ToString).Select()
						Me._objXL.ActiveWindow.FreezePanes = True

						'populate data
						.Range("A1:" & Buisness.Generic.CalExcelColLetter(dtDevices.Columns.Count + (dtBillcodes.Rows.Count * 3) + 2) & (dtDevices.Rows.Count + 2).ToString).Value = objArrData

						.Range("A2:" & Buisness.Generic.CalExcelColLetter(dtDevices.Columns.Count) & "2").Select()
						With Me._objXL.Selection
							'.WrapText = True
							.HorizontalAlignment = Excel.Constants.xlCenter
							.VerticalAlignment = Excel.Constants.xlCenter
							.font.bold = True
							'.Font.ColorIndex = 5
							.Interior.ColorIndex = 15							'37
							.Interior.Pattern = Excel.Constants.xlSolid
						End With

						.Cells.EntireColumn.AutoFit()
						.Cells.EntireRow.AutoFit()
					End With

				Next drManufID

				Me._objXL.Sheets("Sheet1").Delete() : Me._objXL.Sheets("Sheet2").Delete() : Me._objXL.Sheets("Sheet3").Delete()

				objSaveFileDialog.DefaultExt = "xls"
				objSaveFileDialog.FileName = "RVSaving_" & Convert.ToDateTime(strDateStart).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strDateEnd).ToString("yyyyMMdd") & ".xls"
				objSaveFileDialog.ShowDialog()
				strFileName = objSaveFileDialog.FileName

				If strFileName.Trim.Length = 0 Then
					MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Else
					If strFileName.IndexOf("\") < 0 Then Exit Function
					If File.Exists(strFileName) = True Then Kill(strFileName)
					Me._objWorkbook.SaveAs(strFileName)
					MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If



				'********************************
			End If

		Catch ex As Exception
			Throw ex
		Finally
			objArrData = Nothing : R1 = Nothing : Me._objDataProc = Nothing
			Generic.DisposeDT(dtDevices) : Generic.DisposeDT(dtParts) : Generic.DisposeDT(dtParts)
			If Not IsNothing(objSaveFileDialog) Then
				objSaveFileDialog.Dispose()
				objSaveFileDialog = Nothing
			End If
			If Not IsNothing(objSheet) Then
				PSS.Data.Buisness.Generic.NAR(objSheet)
			End If
			If Not IsNothing(Me._objWorkbook) Then
				_objWorkbook.Close(False)
				PSS.Data.Buisness.Generic.NAR(_objWorkbook)
			End If
			If Not IsNothing(Me._objXL) Then
				_objXL.Quit()
				PSS.Data.Buisness.Generic.NAR(_objXL)
			End If
		End Try
	End Function

	'*****************************************************************************
	Public Function GetBilledRVPart(ByVal iPkslipID As Integer, ByVal strDeviceSN As String, ByVal bSpecialBilling As Boolean) As DataTable
		Dim strSql As String = ""

		Try
			strSql = "SELECT Distinct tdevicebill.* " & Environment.NewLine
			strSql &= "FROM tpackingslip " & Environment.NewLine
			strSql &= "INNER JOIN tpallett ON tpackingslip.pkslip_ID = tpallett.pkslip_ID AND tpackingslip.pkslip_ID = " & iPkslipID & Environment.NewLine
			strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID AND Device_SN = '" & strDeviceSN & "'" & Environment.NewLine
			If bSpecialBilling Then
				strSql &= "INNER JOIN tdevicebill_special tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
			Else
				strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
			End If
			strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
			strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.Psprice_ID AND lpsprice.RVFlag = 1 " & Environment.NewLine
			strSql &= "ORDER BY tdevicebill.Billcode_ID"
			Return Me._objDataProc.GetDataTable(strSql)

		Catch ex As Exception
			Throw ex
		End Try
	End Function

	'*****************************************************************************
	Public Function RunCogsReport(ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
		'Dim strOutputDir As String = "\\svr_pssnet\reports\InventoryData\COGS\"
		Dim strOutputDir As String = "C:\COGS\"
		Dim strUplHeader As String() = New String() {"FromBin", "PartNumber", "AdjQty", "AdjType", "EndDate", "DepartmentID", "ConsQty"}
		Dim strSql As String = ""
		Dim dtRefCons, dtNavBinContent, dtDept As DataTable
		Dim drArr(), R1 As DataRow
		Dim objSheet, objArrData(,) As Object
		Dim i As Integer
		Dim strFileName As String = ""
		Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
		 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
		Dim objInv As New Inventory()
		'Dim objDataProc As DBQuery.DataProc

		Try
			'1: Get Production consumption
			strSql = "SELECT 'WIP' as FromBin, D.Psprice_Number as 'PartNumber' " & Environment.NewLine
			strSql &= ", count(*) as ConsQty, 'Negative' as 'AdjType'" & Environment.NewLine
			strSql &= ", '" & Convert.ToDateTime(strDateEnd).ToString("MM/dd/yyy") & "' as 'EndDate' " & Environment.NewLine
			strSql &= ", if(G.DepartmentID is null, 0 , G.DepartmentID) as DepartmentID, sum(DBill_AvgCost) as AvgCost, 0 as AdjQty " & Environment.NewLine
			strSql &= "FROM tdevice A " & Environment.NewLine
			strSql &= "INNER JOIN tdevicebill B ON A.Device_ID = B.Device_ID" & Environment.NewLine
			strSql &= "INNER JOIN tpsmap C ON A.Model_ID = C.Model_ID AND B.Billcode_ID = C.Billcode_ID " & Environment.NewLine
			strSql &= "INNER JOIN lpsprice D ON C.Psprice_ID = D.Psprice_ID" & Environment.NewLine
			strSql &= "INNER JOIN lbillcodes E ON B.Billcode_ID = E.Billcode_ID" & Environment.NewLine
			strSql &= "INNER JOIN tlocation F ON A.Loc_ID = F.Loc_ID" & Environment.NewLine
			strSql &= "INNER JOIN tcustomer G ON F.Cust_ID = G.Cust_ID" & Environment.NewLine
			strSql &= "WHERE A.Device_dateship between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
			strSql &= "AND E.Billtype_ID <> 1 " & Environment.NewLine
			strSql &= "GROUP BY G.DepartmentID, D.Psprice_Number " & Environment.NewLine
			dtRefCons = Me._objDataProc.GetDataTable(strSql)

			If dtRefCons.Rows.Count = 0 Then Return 0

			'2: Define Distinct Department
			dtDept = New DataTable()
			dtDept.Columns.Add("DepartmentID", System.Type.GetType("System.Int32"))
			For Each R1 In dtRefCons.Rows
				If dtDept.Select("DepartmentID = " & R1("DepartmentID")).Length = 0 Then
					Dim drNewRow As DataRow = dtDept.NewRow
					drNewRow("DepartmentID") = R1("DepartmentID")
					dtDept.Rows.Add(drNewRow) : dtDept.AcceptChanges()
				End If
			Next R1

			'3: Get Navision Bin Content 
			dtNavBinContent = objInv.GetNavBinContent("'WIP'")

			'4: Define adjustment quantity
			For Each R1 In dtNavBinContent.Rows
				drArr = dtRefCons.Select("PartNumber = '" & R1("ItemNo") & "'")
				If drArr.Length > 0 Then
					R1.BeginEdit()
					For i = 0 To drArr.Length - 1
						drArr(i).BeginEdit()
						If Convert.ToInt32(drArr(i)("ConsQty")) <= Convert.ToInt32(R1("Quantity")) Then
							drArr(i)("AdjQty") = drArr(i)("ConsQty")
							R1("Quantity") = Convert.ToInt32(R1("Quantity")) - Convert.ToInt32(drArr(i)("ConsQty"))
						Else
							drArr(i)("AdjQty") = R1("Quantity")
							R1("Quantity") = 0
							drArr(i).EndEdit() : Exit For
						End If
						drArr(i).EndEdit()
					Next i
					R1.EndEdit()
				End If
			Next R1

			'5: Create file to upload into navision
			For Each R1 In dtDept.Rows
				If dtRefCons.Select("DepartmentID = " & R1("DepartmentID") & " AND AdjQty > 0 ").Length > 0 Then
					strFileName = "COGS Worksheet " & Convert.ToDateTime(strDateEnd).ToString("yyMMdd") & "_" & R1("DepartmentID") & ".txt"
					OutputToTabDelimitedFiles(strOutputDir & strFileName, dtRefCons.Select("DepartmentID = " & R1("DepartmentID") & " AND AdjQty > 0 "), strUplHeader)
				End If
			Next R1

			'6: Create excel version

		Catch ex As Exception
			Throw ex
		Finally
			objArrData = Nothing : R1 = Nothing : drArr = Nothing : objInv = Nothing
			Generic.DisposeDT(dtRefCons) : Generic.DisposeDT(dtNavBinContent)
			If Not IsNothing(objSheet) Then
				PSS.Data.Buisness.Generic.NAR(objSheet)
			End If
			If Not IsNothing(Me._objWorkbook) Then
				_objWorkbook.Close(False)
				PSS.Data.Buisness.Generic.NAR(_objWorkbook)
			End If
			If Not IsNothing(Me._objXL) Then
				_objXL.Quit()
				PSS.Data.Buisness.Generic.NAR(_objXL)
			End If
		End Try
	End Function

	Private Sub OutputToTabDelimitedFiles(ByVal strFileLoc As String, ByVal drArrData() As DataRow, ByVal strHeader() As String)
		Dim sw As StreamWriter
		Dim i, j As Integer
		Dim strData As String = ""

		Try
			If (File.Exists(strFileLoc)) Then File.Delete(strFileLoc)

			sw = New StreamWriter(strFileLoc)

			For i = 0 To drArrData.Length - 1
				strData = ""
				For j = 0 To strHeader.Length - 1
					If strData.Trim.Length = 0 Then strData = drArrData(i)(strHeader(j)).ToString() Else strData &= vbTab & drArrData(i)(strHeader(j)).ToString()
				Next j
				sw.WriteLine(strData)
			Next i

			sw.Close()
		Catch ex As Exception
			Throw ex
		Finally
			sw.Close()
		End Try
	End Sub

	Public Function RunDetailBillingReportByManifestID(ByVal strRptName As String, ByVal iCustID As Integer, ByVal iPkslipID As Integer) As Integer
		Dim strSql, strFileName, strDateStart, strDateEnd, strSN, strCustName As String
		Dim dt As DataTable
		Dim objArrData(,) As Object
		Dim objSheet As Excel.Worksheet		  ' Excel Worksheet
		Dim i, j As Integer
		Dim objSaveFileDialog As New SaveFileDialog()

		Try
			strSql = "" : strFileName = "" : strDateStart = "" : strDateEnd = ""

			strSql = "SELECT Cust_name1 as 'Customer', Device_SN as 'S/N', Model_Desc as Model, Device_Laborcharge as 'Labor'" & Environment.NewLine
			strSql &= ", Dbill_invoiceAmt as 'Part Charge', Billcode_Desc as 'Bill Code'" & Environment.NewLine
			strSql &= "FROM tdevice " & Environment.NewLine
			strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
			strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
			strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
			strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
			strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
			strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID" & Environment.NewLine
			strSql &= "WHERE tcustomer.Cust_ID = " & iCustID & " AND Pkslip_ID = " & iPkslipID & Environment.NewLine
			strSql &= "ORDER BY Device_SN " & Environment.NewLine
			dt = Me._objDataProc.GetDataTable(strSql)
			If dt.Rows.Count = 0 Then
				MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Else
				strCustName = dt.Rows(0)("Customer")
				dt.Columns.Remove("Customer") : dt.AcceptChanges()

				ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
				strSN = ""
				'***************************************
				'Assign Data to array
				'***************************************
				For i = 0 To dt.Rows.Count - 1
					For j = 0 To dt.Columns.Count - 1
						If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption

						If dt.Columns(j).Caption = "S/N" OrElse dt.Columns(j).Caption = "Labor" OrElse dt.Columns(j).Caption = "Model" Then
							If strSN.Trim.ToLower <> dt.Rows(i)("S/N").ToString.Trim.ToLower Then
								objArrData(i + 1, j) = dt.Rows(i)(j)
								'Else
								'    objArrData(i + 1, j) = ""
							End If
						Else
							objArrData(i + 1, j) = dt.Rows(i)(j)
						End If
					Next j

					If strSN.Trim.ToLower <> dt.Rows(i)("S/N").ToString.Trim.ToLower Then strSN = dt.Rows(i)("S/N").ToString.Trim
				Next i


				Me._objXL.Application.DisplayAlerts = False
				objSheet = _objWorkbook.Worksheets("Sheet1")

				'Me._objXL.Columns("A:B").Select()                'Select columns
				'Me._objXL.Selection.NumberFormat = "@"

				'********************************
				'Post data to excel sheet
				'********************************
				With objSheet
					.Range("A1:A1").Value = strCustName
					.Range("A2:A2").Value = "Ship Manifest : " & iPkslipID
					.Range("A3:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 3).ToString).Value = objArrData

					.Range("A1:A2").Select()
					With Me._objXL.Selection
						.HorizontalAlignment = Excel.Constants.xlLeft
						.VerticalAlignment = Excel.Constants.xlCenter
						.font.bold = True
						.Font.ColorIndex = 5
						.font.size = 16
						.Interior.Pattern = Excel.Constants.xlSolid
					End With
					.Range("A3:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "3").Select()
					With Me._objXL.Selection
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
					objSaveFileDialog.FileName = strCustName & "_DetailsBilling_" & iPkslipID & ".xls"
					objSaveFileDialog.ShowDialog()
					strFileName = objSaveFileDialog.FileName

					If strFileName.Trim.Length = 0 Then
						MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						If strFileName.IndexOf("\") < 0 Then Exit Function
						If File.Exists(strFileName) = True Then Kill(strFileName)
						Me._objWorkbook.SaveAs(strFileName)
						MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
				End With
				'********************************
			End If

		Catch ex As Exception
			Throw ex
		Finally
			objArrData = Nothing : Me._objDataProc = Nothing
			Generic.DisposeDT(dt)
			If Not IsNothing(objSaveFileDialog) Then
				objSaveFileDialog.Dispose()
				objSaveFileDialog = Nothing
			End If
			If Not IsNothing(objSheet) Then
				PSS.Data.Buisness.Generic.NAR(objSheet)
			End If
			If Not IsNothing(Me._objWorkbook) Then
				_objWorkbook.Close(False)
				PSS.Data.Buisness.Generic.NAR(_objWorkbook)
			End If
			If Not IsNothing(Me._objXL) Then
				_objXL.Quit()
				PSS.Data.Buisness.Generic.NAR(_objXL)
			End If
		End Try
	End Function

	'*****************************************************************************
	Public Function RunUnitsProduceNotShip(ByVal strRptName As String, ByVal iCustID As Integer) As Integer
		Try
			Dim strSql, strFileName As String
			Dim dt As DataTable
			Dim objArrData(,) As Object
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim i, j As Integer
			Dim objSaveFileDialog As New SaveFileDialog()

			Try
				strSql = "" : strFileName = ""

				strSql = "SELECT Device_SN as 'S/N'" & Environment.NewLine
				strSql &= ", date_format(Device_dateship, '%m/%d/%Y') as 'Produce Date'" & Environment.NewLine
                strSql &= ", IF(Device_laborCharge is null, 0.0,Device_laborCharge) as 'Labor'" & Environment.NewLine
                strSql &= ", IF(device_partcharge is null, 0.0, device_partcharge) as 'Part Charge'" & Environment.NewLine
                strSql &= ", (IF(Device_laborCharge is null, 0.0,Device_laborCharge) + IF(device_partcharge is null, 0.0, device_partcharge)) as 'Total Charge'" & Environment.NewLine
				strSql &= ", IF(Device_LaborCharge_AutoBilled is null, 0.0, Device_LaborCharge_AutoBilled ) as 'SP Labor'" & Environment.NewLine
				strSql &= ", IF(Device_PartCharge_AutoBilled is null, 0.0, Device_PartCharge_AutoBilled) as 'SP Part Charge'" & Environment.NewLine
				strSql &= ", (IF(Device_LaborCharge_AutoBilled is null, 0.0, Device_LaborCharge_AutoBilled) + IF(Device_PartCharge_AutoBilled is null, 0.0, Device_PartCharge_AutoBilled) ) as 'SP Total Charge'" & Environment.NewLine
				strSql &= ", Model_Desc as Model, Pallett_name as 'Pallet Name', tdevice.Ship_ID as 'Ship ID' " & Environment.NewLine

				strSql &= ", If(Freq_Number is null, '', concat('=""', Freq_Number, '""') ) as 'Frequency'" & Environment.NewLine
				strSql &= ", If(baud_Number is null, '', baud_Number) as 'Baud Rate'" & Environment.NewLine

				strSql &= "FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
				strSql &= "LEFT JOIN tpallett on tdevice.pallett_id = tpallett.pallett_id" & Environment.NewLine
				strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine

				strSql &= "LEFT OUTER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_ID " & Environment.NewLine
				strSql &= "LEFT OUTER JOIN lbaud ON tmessdata.baud_id = lbaud.baud_ID " & Environment.NewLine

				strSql &= "WHERE tlocation.Cust_ID = " & iCustID & " AND tdevice.Device_Dateship > '2000-01-01 00:00:00' AND tdevice.Device_Dateship is not null AND pkslip_id is null" & Environment.NewLine
				dt = Me._objDataProc.GetDataTable(strSql)
				If dt.Rows.Count = 0 Then
					MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				Else
					If dt.Select("[Baud Rate] <> ''").Length = 0 Then
						dt.Columns.Remove("Frequency") : dt.Columns.Remove("Baud Rate") : dt.AcceptChanges()
					End If

					ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)

					'***************************************
					'Assign Data to array
					'***************************************
					For i = 0 To dt.Rows.Count - 1
						For j = 0 To dt.Columns.Count - 1
							If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption
							If dt.Columns(j).Caption = "Labor" OrElse dt.Columns(j).Caption.EndsWith("Charge") Then
								objArrData(i + 1, j) = Format(dt.Rows(i)(j), "$#,##0.00")
							Else
								objArrData(i + 1, j) = dt.Rows(i)(j)
							End If
						Next j
					Next i

					Me._objXL.Application.DisplayAlerts = False
					objSheet = _objWorkbook.Worksheets("Sheet1")

					objSheet.Columns("A").NumberFormat = "@"

					'Me._objXL.Columns("A:B").Select()                'Select columns
					'Me._objXL.Selection.NumberFormat = "@"

					'********************************
					'Post data to excel sheet
					'********************************
					With objSheet
						.Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

						.Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
						With Me._objXL.Selection
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
						objSaveFileDialog.FileName = strRptName & "_" & Now().ToString("yyyyMMddHHmmss") & ".xls"
						objSaveFileDialog.ShowDialog()
						strFileName = objSaveFileDialog.FileName

						If strFileName.Trim.Length = 0 Then
							MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Else
							If strFileName.IndexOf("\") < 0 Then Exit Function
							If File.Exists(strFileName) = True Then Kill(strFileName)
							Me._objWorkbook.SaveAs(strFileName)
							MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						End If
					End With
					'********************************
				End If

			Catch ex As Exception
				Throw ex
			Finally
				objArrData = Nothing : Me._objDataProc = Nothing
				Generic.DisposeDT(dt)
				If Not IsNothing(objSaveFileDialog) Then
					objSaveFileDialog.Dispose()
					objSaveFileDialog = Nothing
				End If
				If Not IsNothing(objSheet) Then
					PSS.Data.Buisness.Generic.NAR(objSheet)
				End If
				If Not IsNothing(Me._objWorkbook) Then
					_objWorkbook.Close(False)
					PSS.Data.Buisness.Generic.NAR(_objWorkbook)
				End If
				If Not IsNothing(Me._objXL) Then
					_objXL.Quit()
					PSS.Data.Buisness.Generic.NAR(_objXL)
				End If
			End Try
		Catch ex As Exception
			Throw ex
		End Try
	End Function

	'*****************************************************************************
    Public Function DockShipReport(ByVal strRptName As String, ByVal iCustID As Integer, _
                                   ByVal strStartDate As String, ByVal strEndDate As String, _
                                   Optional ByVal iLoc_ID As Integer = 0) As Integer

        Dim strSql, strFileName As String
        Dim dt As DataTable
        Dim objArrData(,) As Object
        Dim objSheet As Excel.Worksheet    ' Excel Worksheet
        Dim i, j As Integer
        Dim objSaveFileDialog As New SaveFileDialog()

        Try

            strSql = "" : strFileName = ""

            strSql = "SELECT Device_SN as 'S/N'" & Environment.NewLine
            strSql &= ", date_format(Device_daterec, '%m/%d/%Y') as 'Received Date'" & Environment.NewLine
            strSql &= ", date_format(Device_dateship, '%m/%d/%Y') as 'Produce Date'" & Environment.NewLine
            strSql &= ", date_format(pkslip_createDt, '%m/%d/%Y') as 'Ship Date' " & Environment.NewLine
            strSql &= ", Device_laborCharge as 'Labor'" & Environment.NewLine
            strSql &= ",if (device_partcharge =0, SUM( DBill_AvgCost),device_partcharge)  as 'Part Charge'" & Environment.NewLine
            strSql &= ", (Device_laborCharge + if (device_partcharge =0, SUM( DBill_AvgCost), device_partcharge)) as 'Total Charge'" & Environment.NewLine
            strSql &= ", IF(Device_LaborCharge_AutoBilled is null, 0.0, Device_LaborCharge_AutoBilled ) as 'SP Labor'" & Environment.NewLine
            strSql &= ", IF(Device_PartCharge_AutoBilled is null, 0.0, Device_PartCharge_AutoBilled) as 'SP Part Charge'" & Environment.NewLine
            strSql &= ", (IF(Device_LaborCharge_AutoBilled is null, 0.0, Device_LaborCharge_AutoBilled) + IF(Device_PartCharge_AutoBilled is null, 0.0, Device_PartCharge_AutoBilled) ) as 'SP Total Charge'" & Environment.NewLine
            strSql &= ", Model_Desc as Model, Pallett_name as 'Pallet Name', tpallett.Pkslip_ID as 'Manifest ID'" & Environment.NewLine
            strSql &= ", If(tpallett.Pallet_ShipType = 0, 'Yes', 'No') as 'Finished Good'" & Environment.NewLine

            'strSql &= ", If(Freq_Number is null, '', concat('=""', Freq_Number, '""') ) as 'Frequency'" & Environment.NewLine
            'strSql &= ", If(baud_Number is null, '', baud_Number) as 'Baud Rate'" & Environment.NewLine
            strSql &= ",  Freq_Number as 'Frequency'" & Environment.NewLine
            strSql &= ",  baud_Number as 'Baud Rate'" & Environment.NewLine

            If iCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then strSql &= ",tmessdata.capcode" & Environment.NewLine

            strSql &= "FROM tdevice INNER JOIN tpallett on tdevice.pallett_id = tpallett.pallett_id" & Environment.NewLine
            strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
            strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine

            strSql &= "LEFT OUTER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN lbaud ON tmessdata.baud_id = lbaud.baud_ID " & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill   ON tdevicebill.device_id=tdevice.device_id" & Environment.NewLine
            strSql &= "WHERE tpallett.Cust_ID = " & iCustID & Environment.NewLine
            If iLoc_ID > 0 Then
                strSql &= " AND tdevice.Loc_ID = " & iLoc_ID & Environment.NewLine
            End If
            strSql &= " AND pkslip_createDt BETWEEN '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'  GROUP BY tdevice.device_id" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)

            If dt.Select("[Baud Rate] <> ''").Length = 0 Then
                dt.Columns.Remove("Frequency") : dt.Columns.Remove("Baud Rate") : dt.AcceptChanges()
            End If

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else

                ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)

                '***************************************
                'Assign Data to array
                '***************************************
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption
                        If dt.Columns(j).Caption = "Labor" OrElse dt.Columns(j).Caption.EndsWith("Charge") Then
                            objArrData(i + 1, j) = Format(dt.Rows(i)(j), "$#,##0.00")
                        Else
                            objArrData(i + 1, j) = dt.Rows(i)(j)
                        End If
                    Next j
                Next i

                Me._objXL.Application.DisplayAlerts = False
                objSheet = _objWorkbook.Worksheets("Sheet1")

                'objSheet.Columns("A").NumberFormat = "@" : objSheet.Columns("J").NumberFormat = "@"
                'objSheet.Columns("K").NumberFormat = "@" : objSheet.Columns("L").NumberFormat = "@"
                'objSheet.Columns("M").NumberFormat = "@" : objSheet.Columns("N").NumberFormat = "@"
                'objSheet.Columns("O").NumberFormat = "@" : objSheet.Columns("P").NumberFormat = "@"
                objSheet.Columns("B:B").Select()
                _objXL.Selection.NumberFormat = "mm/dd/yyyy"
                objSheet.Columns("C:C").Select()
                _objXL.Selection.NumberFormat = "mm/dd/yyyy"
                objSheet.Columns("D:D").Select()
                _objXL.Selection.NumberFormat = "mm/dd/yyyy"
                objSheet.Columns("A").NumberFormat = "@" : objSheet.Columns("K").NumberFormat = "@"
                objSheet.Columns("L").NumberFormat = "@" : objSheet.Columns("M").NumberFormat = "@"
                objSheet.Columns("N").NumberFormat = "@" : objSheet.Columns("O").NumberFormat = "@"
                objSheet.Columns("P").NumberFormat = "@" : objSheet.Columns("Q").NumberFormat = "@"

                'Me._objXL.Columns("A:B").Select()                'Select columns
                'Me._objXL.Selection.NumberFormat = "@"

                '********************************
                'Post data to excel sheet
                '********************************
                With objSheet
                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                    With Me._objXL.Selection
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
                    objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(strStartDate).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strEndDate).ToString("yyyyMMdd") & ".xls"
                    objSaveFileDialog.ShowDialog()
                    strFileName = objSaveFileDialog.FileName

                    If strFileName.Trim.Length = 0 Then
                        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If strFileName.IndexOf("\") < 0 Then Exit Function
                        If File.Exists(strFileName) = True Then Kill(strFileName)
                        Me._objWorkbook.SaveAs(strFileName)
                        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End With
                '********************************
            End If

        Catch ex As Exception
            Throw ex
        Finally
            objArrData = Nothing : Me._objDataProc = Nothing
            Generic.DisposeDT(dt)
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                objSaveFileDialog = Nothing
            End If
            If Not IsNothing(objSheet) Then
                PSS.Data.Buisness.Generic.NAR(objSheet)
            End If
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False)
                PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit()
                PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Function

    '*****************************************************************************
    Public Function NeedPartReport(ByVal strRptName As String, ByVal iCustID As Integer) As Integer
        Dim strSql, strFileName, strSN As String
        Dim dt As DataTable
        Dim objArrData(,) As Object
        Dim objSheet As Excel.Worksheet    ' Excel Worksheet
        Dim i, j As Integer
        Dim objSaveFileDialog As New SaveFileDialog()

        Try
            strSql = "SELECT Cust_Name1, device_sn as 'PSS SN', date_rec as 'Date'" & Environment.NewLine
            strSql &= ", Billcode_Desc as 'Billcode', part_number as 'Part #', sum(Trans_Amount) as 'Qty'" & Environment.NewLine
            strSql &= ", prod_desc as 'Product Type', Manuf_Desc as 'Manufacture', tmodel.model_desc as 'Model'" & Environment.NewLine
            strSql &= ", WO_Custwo as 'Work Order', Device_DateRec as 'Receipt Date' "
            strSql &= "FROM tdevice " & Environment.NewLine
            strSql &= "INNER JOIN tlocation On tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
            strSql &= "INNER JOIN tworkorder on tdevice.wo_id = tworkorder.wo_id" & Environment.NewLine
            strSql &= "INNER JOIN tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
            strSql &= "INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.Manuf_ID " & Environment.NewLine
            strSql &= "INNER JOIN lproduct ON tmodel.prod_id = lproduct.prod_id " & Environment.NewLine
            strSql &= "INNER JOIN tdevicebillawap ON tdevice.device_id = tdevicebillawap.device_ID " & Environment.NewLine
            strSql &= "INNER JOIN lbillcodes ON tdevicebillawap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
            strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
            strSql &= "WHERE tlocation.Cust_ID = " & iCustID & " AND device_dateship is null " & Environment.NewLine
            strSql &= "GROUP BY tdevice.device_SN, date_rec, tdevicebillawap.Billcode_ID, part_Number " & Environment.NewLine
            strSql &= "HAVING qty <> 0" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            dt.DefaultView.Sort = "[PSS SN] ASC"

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                strFileName = dt.Rows(0)("Cust_Name1").ToString & "_" & strRptName
                dt.Columns.Remove("Cust_Name1") : dt.AcceptChanges()

                ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)

                '***************************************
                'Assign Data to array
                '***************************************
                strSN = ""
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption

                        If dt.Columns(j).Caption = "PSS SN" Then
                            If strSN.Trim.ToLower <> dt.Rows(i)(j).ToString.Trim.ToLower Then
                                objArrData(i + 1, j) = dt.Rows(i)(j).ToString.Trim
                                strSN = dt.Rows(i)(j).ToString.Trim
                            Else
                                objArrData(i + 1, j) = ""
                            End If
                        Else
                            objArrData(i + 1, j) = dt.Rows(i)(j)
                        End If

                    Next j
                Next i

                Me._objXL.Application.DisplayAlerts = False
                objSheet = _objWorkbook.Worksheets("Sheet1")

                objSheet.Columns("A").NumberFormat = "@"

                'Me._objXL.Columns("A:B").Select()                'Select columns
                'Me._objXL.Selection.NumberFormat = "@"

                '********************************
                'Post data to excel sheet
                '********************************
                With objSheet
                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                    With Me._objXL.Selection
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
                    objSaveFileDialog.FileName = strFileName & ".xls"
                    objSaveFileDialog.ShowDialog()
                    strFileName = objSaveFileDialog.FileName

                    If strFileName.Trim.Length = 0 Then
                        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If strFileName.IndexOf("\") < 0 Then Exit Function
                        If File.Exists(strFileName) = True Then Kill(strFileName)
                        Me._objWorkbook.SaveAs(strFileName)
                        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End With
                '********************************
            End If

        Catch ex As Exception
            Throw ex
        Finally
            objArrData = Nothing : Me._objDataProc = Nothing
            Generic.DisposeDT(dt)
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose() : objSaveFileDialog = Nothing
            End If
            If Not IsNothing(objSheet) Then PSS.Data.Buisness.Generic.NAR(objSheet)
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False) : PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit() : PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Function

    '******************************************************************
    Public Function RunTracFoneReceiveShipRpt(ByVal strRptName As String, _
      ByVal iLocID As Integer, _
      ByVal strStartDateTime As String, _
      ByVal strEndDateTime As String, _
      ByVal iYearArrList As ArrayList) As Integer

        Dim strSql, strCriteria As String
        Dim dt As DataTable
        Dim i, j, k, m, iRowNum, iYr, iMo As Integer
        Dim TotalNum As Integer = 0
        Dim rng As Excel.Range
        Dim strFileName As String
        Dim objSheet As Object
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim strVarNames As New ArrayList(), strMonthNames As New ArrayList()

        Try

            'Initial Excel
            _objXL.Application.DisplayAlerts = False
            _objXL.Visible = False    'True 'False

            objSheet = Me._objWorkbook.Worksheets("Sheet1")
            objSheet.Name = "Result"
            objSheet.Activate()

            'Set up Variables and Month Names for report
            strVarNames.Add("Received")
            strVarNames.Add("Produced (Good)") : strVarNames.Add("Produced (Not Good)")
            strVarNames.Add("DockShipped (Good)") : strVarNames.Add("DockShipped (Not Good)")
            For i = 1 To 12
                strMonthNames.Add(MonthName(i, False))
            Next

            'Set header and tables in Excel sheet
            For i = 0 To iYearArrList.Count - 1
                iRowNum = (i * strVarNames.Count) + (i * 2) + 1
                objSheet.Cells(iRowNum, 1) = iYearArrList(i)    'add year
                For k = 0 To strMonthNames.Count - 1
                    objSheet.Cells(iRowNum, k + 2) = strMonthNames(k)       'add month name
                Next
                For j = 0 To strVarNames.Count - 1
                    objSheet.Cells((i * strVarNames.Count) + (i * 2) + 2 + j, 1) = strVarNames(j)       ' add variables
                Next
            Next

            'Add Each Table Header's Font Bold
            For i = 0 To iYearArrList.Count - 1
                iRowNum = (i * strVarNames.Count) + (i * 2) + 1
                rng = objSheet.Range(objSheet.Cells(iRowNum, 1), objSheet.Cells(iRowNum, strMonthNames.Count + 1))
                rng.Font.Bold = True : rng.Font.ColorIndex = 1 'rng.Font.Name = "Calibri" : rng.Font.Bold = False : rng.Font.Italic = False :r ng.Font.Size = 8 : rng.Font.ColorIndex = 1
            Next

            'Add borders 
            For i = 0 To iYearArrList.Count - 1
                iRowNum = (i * strVarNames.Count) + (i * 2) + 1
                rng = objSheet.Range(objSheet.Cells(iRowNum, 1), objSheet.Cells(iRowNum + strVarNames.Count, strMonthNames.Count + 1))
                rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            Next

            'Received data
            strSql = "Select Year(device_DateRec) as Yr, Month(device_DateRec) as Mo, Count(*) As Qty" & Environment.NewLine
            strSql &= " From tdevice" & Environment.NewLine
            strSql &= " Where Loc_ID = " & iLocID & Environment.NewLine
            strSql &= " And device_DateRec Between '" & strStartDateTime & "' And '" & strEndDateTime & "'" & Environment.NewLine
            strSql &= " Group By Year(device_DateRec), Month(device_DateRec);" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            SetSheetData(objSheet, dt, 0, iYearArrList, strVarNames, strMonthNames)
            TotalNum += dt.Rows.Count

            'Produced (Good)
            strSql = "select Year(device_DateShip) as Yr, Month(device_DateShip) as Mo, Count(*) As Qty" & Environment.NewLine
            strSql &= " from tDevice" & Environment.NewLine
            strSql &= " inner join tPallett On tDevice.Pallett_ID= tPallett.Pallett_ID" & Environment.NewLine
            strSql &= " Where tDevice.Loc_ID= " & iLocID & " and tPallett.Pallet_ShipType=0" & Environment.NewLine
            strSql &= " And device_DateShip Between '" & strStartDateTime & "' And '" & strEndDateTime & "'" & Environment.NewLine
            strSql &= " group by Year(device_DateShip),Month(device_DateShip);" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            SetSheetData(objSheet, dt, 1, iYearArrList, strVarNames, strMonthNames)
            TotalNum += dt.Rows.Count

            'Produced (Not Good)
            strSql = "select Year(device_DateShip) as Yr, Month(device_DateShip) as Mo, Count(*) As Qty" & Environment.NewLine
            strSql &= " from tDevice" & Environment.NewLine
            strSql &= " inner join tPallett On tDevice.Pallett_ID= tPallett.Pallett_ID" & Environment.NewLine
            strSql &= " Where tDevice.Loc_ID= " & iLocID & " and tPallett.Pallet_ShipType<>0" & Environment.NewLine
            strSql &= " And device_DateShip Between '" & strStartDateTime & "' And '" & strEndDateTime & "'" & Environment.NewLine
            strSql &= " group by Year(device_DateShip),Month(device_DateShip);" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            SetSheetData(objSheet, dt, 2, iYearArrList, strVarNames, strMonthNames)
            TotalNum += dt.Rows.Count

            'Dock Shipped (Good)
            strSql = "select Year(pkslip_createDt) As Yr, Month(pkslip_createDt) As Mo, Count(*) As Qty" & Environment.NewLine
            strSql &= " from tDevice" & Environment.NewLine
            strSql &= " inner join tPallett On tDevice.Pallett_ID= tPallett.Pallett_ID" & Environment.NewLine
            strSql &= " Inner Join tPackingSlip On tPallett.pkslip_ID=tPackingSlip.pkslip_ID" & Environment.NewLine
            strSql &= " Where tDevice.Loc_ID= " & iLocID & " and tPallett.Pallet_ShipType=0" & Environment.NewLine
            strSql &= " And pkslip_createDt Between '" & strStartDateTime & "' And '" & strEndDateTime & "'" & Environment.NewLine
            strSql &= " group by Year(pkslip_createDt), Month(pkslip_createDt);" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            SetSheetData(objSheet, dt, 3, iYearArrList, strVarNames, strMonthNames)
            TotalNum += dt.Rows.Count

            'Dock Shipped (Not Good)
            strSql = "select Year(pkslip_createDt) As Yr, Month(pkslip_createDt) As Mo, Count(*) As Qty" & Environment.NewLine
            strSql &= " from tDevice" & Environment.NewLine
            strSql &= " inner join tPallett On tDevice.Pallett_ID= tPallett.Pallett_ID" & Environment.NewLine
            strSql &= " Inner Join tPackingSlip On tPallett.pkslip_ID=tPackingSlip.pkslip_ID" & Environment.NewLine
            strSql &= " Where tDevice.Loc_ID= " & iLocID & " and tPallett.Pallet_ShipType<>0" & Environment.NewLine
            strSql &= " And pkslip_createDt Between '" & strStartDateTime & "' And '" & strEndDateTime & "'" & Environment.NewLine
            strSql &= " group by Year(pkslip_createDt), Month(pkslip_createDt);" & Environment.NewLine
            dt = Me._objDataProc.GetDataTable(strSql)
            SetSheetData(objSheet, dt, 4, iYearArrList, strVarNames, strMonthNames)
            TotalNum += dt.Rows.Count

            'Fit rows and columns
            objSheet.Cells.EntireColumn.AutoFit()
            objSheet.Cells.EntireRow.AutoFit()

            'Save Excel file
            strFileName = strRptName.Replace("/", "_").Replace(".", "").Replace(" ", "_") & "_" & _
             strStartDateTime.Replace(" 00:00:00", "_To_") & _
             strEndDateTime.Replace(" 23:59:59", "")
            objSaveFileDialog.DefaultExt = "xlsx"
            objSaveFileDialog.FileName = strFileName & ".xlsx"
            objSaveFileDialog.ShowDialog()
            strFileName = objSaveFileDialog.FileName

            If strFileName.Trim.Length = 0 Then
                MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If strFileName.IndexOf("\") < 0 Then Exit Function
                If File.Exists(strFileName) = True Then Kill(strFileName)
                Me._objWorkbook.SaveAs(strFileName)
                MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Return TotalNum

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)

            'Close Excel
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
            End If
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._objDataProc = Nothing
            If Not IsNothing(objSheet) Then
                PSS.Data.Buisness.Generic.NAR(objSheet)
            End If
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False)
                PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit()
                PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Function

    '*****************************************************************************

    Private Sub SetSheetData(ByVal ObjSheet As Object, ByVal dt As DataTable, ByVal iVar As Integer, _
     ByVal iYearArrList As ArrayList, ByVal strVarNames As ArrayList, _
     ByVal strMonthNames As ArrayList)

        Dim i, j, k, m, iRowNum, iYr, iMo As Integer
        Try
            For i = 0 To iYearArrList.Count - 1
                j = iVar : iYr = iYearArrList(i)
                iRowNum = (i * strVarNames.Count) + (i * 2) + 2 + j
                For k = 0 To strMonthNames.Count - 1
                    iMo = k + 1
                    For m = 0 To dt.Rows.Count - 1
                        If dt.Rows(m).Item("Yr") = iYr AndAlso dt.Rows(m).Item("Mo") = iMo Then
                            ObjSheet.Cells(iRowNum, k + 2) = dt.Rows(m).Item("Qty")
                            Exit For
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************************

    Private Sub ReleaseObject(ByVal Obj As Object)
        'Release COM Object 
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Obj)
            Obj = Nothing
        Catch ex As Exception
            Obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    '*****************************************************************************
    Public Function PartConsumptionByDateRange(ByVal strRptName As String, ByVal iLocID As Integer, _
     ByVal booUseProdCompletedDate As Boolean, ByVal strDateStart As String, _
     ByVal strDateEnd As String) As Integer
        Dim strSql, strFileName As String
        Dim dt As DataTable
        Dim objArrData(,) As Object
        Dim objSheet As Excel.Worksheet    ' Excel Worksheet
        Dim i, j As Integer
        Dim objSaveFileDialog As New SaveFileDialog()

        Try
            strSql = "SELECT model_desc as 'Model', part_number as 'Part #'" & Environment.NewLine
            strSql &= ", date_format(device_dateship, '%m/%d/%Y') as 'Prod Completed Date', count(*) as 'Quantity'" & Environment.NewLine
            strSql &= "FROM tdevice INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.device_ID" & Environment.NewLine
            strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.billcode_ID" & Environment.NewLine
            strSql &= "INNER JOIN tmodel ON tdevice.model_ID = tmodel.model_ID" & Environment.NewLine
            If booUseProdCompletedDate Then
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID" & Environment.NewLine
            Else
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID" & Environment.NewLine
                strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID" & Environment.NewLine
            End If
            strSql &= "WHERE tdevice.Loc_ID = " & iLocID & " AND billtype_id = 2 " & Environment.NewLine
            If booUseProdCompletedDate Then
                strSql &= "AND device_dateship BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
            Else
                strSql &= "AND pkslip_createdt BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
            End If
            strSql &= "GROUP BY model_desc, part_number, 'Prod Completed Date'"
            dt = Me._objDataProc.GetDataTable(strSql)
            dt.DefaultView.Sort = "Model ASC"

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                strFileName = strRptName & " " & strDateStart & " to " & strDateEnd

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

                Me._objXL.Application.DisplayAlerts = False
                objSheet = _objWorkbook.Worksheets("Sheet1")

                objSheet.Columns("B").NumberFormat = "@"

                'Me._objXL.Columns("A:B").Select()                'Select columns
                'Me._objXL.Selection.NumberFormat = "@"

                '********************************
                'Post data to excel sheet
                '********************************
                With objSheet
                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                    .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                    With Me._objXL.Selection
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
                    objSaveFileDialog.FileName = strFileName & ".xls"
                    objSaveFileDialog.ShowDialog()
                    strFileName = objSaveFileDialog.FileName

                    If strFileName.Trim.Length = 0 Then
                        MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If strFileName.IndexOf("\") < 0 Then Exit Function
                        If File.Exists(strFileName) = True Then Kill(strFileName)
                        Me._objWorkbook.SaveAs(strFileName)
                        MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End With
                '********************************
            End If

        Catch ex As Exception
            Throw ex
        Finally
            objArrData = Nothing : Me._objDataProc = Nothing
            Generic.DisposeDT(dt)
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose() : objSaveFileDialog = Nothing
            End If
            If Not IsNothing(objSheet) Then PSS.Data.Buisness.Generic.NAR(objSheet)
            If Not IsNothing(Me._objWorkbook) Then
                _objWorkbook.Close(False) : PSS.Data.Buisness.Generic.NAR(_objWorkbook)
            End If
            If Not IsNothing(Me._objXL) Then
                _objXL.Quit() : PSS.Data.Buisness.Generic.NAR(_objXL)
            End If
        End Try
    End Function

    '*****************************************************************************
    Public Sub RunDetailSummaryExcelFormat_MultipleSheets(ByVal dtDetails_1 As DataTable, ByVal dtDetails_2 As DataTable, ByVal dtSummary As DataTable, _
       ByVal strRptName As String, ByVal strSheetNamePrefix_1 As String, ByVal strSheetNamePrefix_2 As String, _
       Optional ByVal strTextCol() As String = Nothing, _
       Optional ByVal DollarNumberCol() As String = Nothing)
        'Just for messaging WIP report. It takes time to make a generic

        Dim strFileName As String = ""
        Dim objArrData(,) As Object
        Dim R1, row As DataRow
        Dim col As DataColumn
        Dim i, j, k, m As Integer
        Dim iSumColIdx1, iSumColIdx2 As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim iSheetMaxRows As Integer = 65536    'Excel 2003 - Excel 97
        Dim iSheetMaxName As Integer = 31
        Dim strS As String = ""
        Dim dtTmp As DataTable
        Dim ds As New DataSet()
        Dim intLastRow As Integer

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim rng As Excel.Range
        Dim misValue As Object = System.Reflection.Missing.Value

        Try
            If (dtDetails_1.Rows.Count + dtDetails_2.Rows.Count) = 0 AndAlso dtSummary.Rows.Count = 0 Then Exit Sub

            If dtDetails_1.Rows.Count > 0 Then
                If dtDetails_1.Rows.Count > iSheetMaxRows - 1 Then    'one row is header, multiple sheets
                    'now split the datatable
                    Dim n As Integer = iSheetMaxRows - 1       'number of rows per datatable
                    For i = 0 To dtDetails_1.Rows.Count - 1 Step n
                        intLastRow = i + n - 1
                        If intLastRow > dtDetails_1.Rows.Count - 1 Then intLastRow = dtDetails_1.Rows.Count - 1
                        Dim dtbNew As DataTable = dtDetails_1.Clone       'copy structure of original datatable 
                        'dtbNew.TableName = dt.TableName & " " & (i \ n).ToString
                        If strSheetNamePrefix_1.Trim.ToString.Length = 0 Then
                            strS = "Sheet" & " " & ((i \ n) + 1).ToString
                        ElseIf strSheetNamePrefix_1.Trim.ToString.Length <= iSheetMaxName - 3 Then       'assume max sheet sequence number is 999
                            strS = strSheetNamePrefix_1.Trim.ToString & " " & ((i \ n) + 1).ToString
                        Else
                            strS = strSheetNamePrefix_1.Trim.ToString.Substring(0, iSheetMaxName - 3) & " " & ((i \ n) + 1).ToString
                        End If
                        For j = i To intLastRow
                            dtbNew.ImportRow(dtDetails_1.Rows(j))
                        Next j
                        dtbNew.TableName = strS
                        ds.Tables.Add(dtbNew)
                    Next i
                Else    ' One sheet
                    If strSheetNamePrefix_1.Trim.ToString.Length = 0 Then
                        strS = "Hold"
                    ElseIf strSheetNamePrefix_1.Trim.ToString.Length <= iSheetMaxName Then
                        strS = strSheetNamePrefix_1.Trim.ToString
                    Else
                        strS = strSheetNamePrefix_1.Trim.ToString.Substring(0, iSheetMaxName)
                    End If
                    dtDetails_1.TableName = strS
                    ds.Tables.Add(dtDetails_1)
                End If
            End If

            If dtDetails_2.Rows.Count > 0 Then
                If dtDetails_2.Rows.Count > iSheetMaxRows - 1 Then    'one row is header, multiple sheets
                    'now split the datatable
                    Dim n As Integer = iSheetMaxRows - 1       'number of rows per datatable
                    For i = 0 To dtDetails_2.Rows.Count - 1 Step n
                        intLastRow = i + n - 1
                        If intLastRow > dtDetails_2.Rows.Count - 1 Then intLastRow = dtDetails_2.Rows.Count - 1
                        Dim dtbNew As DataTable = dtDetails_2.Clone       'copy structure of original datatable 
                        'dtbNew.TableName = dt.TableName & " " & (i \ n).ToString
                        If strSheetNamePrefix_2.Trim.ToString.Length = 0 Then
                            strS = "Sheet" & " " & ((i \ n) + 1).ToString
                        ElseIf strSheetNamePrefix_2.Trim.ToString.Length <= iSheetMaxName - 3 Then       'assume max sheet sequence number is 999
                            strS = strSheetNamePrefix_2.Trim.ToString & " " & ((i \ n) + 1).ToString
                        Else
                            strS = strSheetNamePrefix_2.Trim.ToString.Substring(0, iSheetMaxName - 3) & " " & ((i \ n) + 1).ToString
                        End If
                        For j = i To intLastRow
                            dtbNew.ImportRow(dtDetails_2.Rows(j))
                        Next j
                        dtbNew.TableName = strS
                        ds.Tables.Add(dtbNew)
                    Next i
                Else    ' One sheet
                    If strSheetNamePrefix_2.Trim.ToString.Length = 0 Then
                        strS = "Other"
                    ElseIf strSheetNamePrefix_2.Trim.ToString.Length <= iSheetMaxName Then
                        strS = strSheetNamePrefix_2.Trim.ToString
                    Else
                        strS = strSheetNamePrefix_2.Trim.ToString.Substring(0, iSheetMaxName)
                    End If
                    dtDetails_2.TableName = strS
                    ds.Tables.Add(dtDetails_2)
                End If
            End If

            'last add summary datatable
            If dtSummary.Rows.Count > 0 Then
                dtSummary.TableName = "Summary"
                ds.Tables.Add(dtSummary)
            End If

            If Not ds.Tables.Count > 0 Then
                MessageBox.Show("Master datatable(s) have data, but dataset has no tables.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'Create Excel ------------------------------------------------------------------------------------------------------------------------
            xlApp = New Excel.Application()
            xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
            xlApp.Visible = False : xlApp.DisplayAlerts = False

            'Add new worksheets as needed
            If ds.Tables.Count >= 3 Then
                For m = 4 To ds.Tables.Count
                    xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet)       'Add sheet
                    xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count))       'Move to the last 
                Next
            End If

            k = 0
            For Each dtTmp In ds.Tables
                k += 1
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(k), Excel._Worksheet)
                xlWorkSheet.Select()

                If Not dtTmp.Rows.Count > 0 Then
                    xlWorkSheet.Cells(1, 1) = "No data"
                    xlWorkSheet.Name = dtTmp.TableName
                    'Set font 
                    rng = xlWorkSheet.Range("A1:A1")
                    rng.Font.Name = "Calibri" : rng.Font.Size = 9
                Else

                    'Get row and col counts
                    Dim RowsNum As Integer = dtTmp.Rows.Count
                    Dim ColsNum As Integer = dtTmp.Columns.Count

                    'Summary sum col index
                    j = 0
                    If dtTmp.TableName = dtSummary.TableName Then
                        For Each col In dtTmp.Columns
                            j += 1
                            If col.ColumnName.Trim.ToUpper = "WIP Location Total".ToUpper Then
                                iSumColIdx1 = j
                            ElseIf col.ColumnName.Trim.ToUpper = "Customer Total".ToUpper Then
                                iSumColIdx2 = j
                            End If
                        Next
                    End If

                    'Set column format (detail sheets)
                    If Not IsNothing(strTextCol) Then
                        For i = 0 To strTextCol.Length - 1
                            If strTextCol(i).Trim.Length > 0 Then
                                rng = xlWorkSheet.Range(strTextCol(i).Trim & 1.ToString & ":" & strTextCol(i).Trim & (RowsNum + 1).ToString)
                                rng.NumberFormat = "@"          'text
                            End If
                        Next i
                    End If
                    If Not IsNothing(DollarNumberCol) Then
                        For i = 0 To DollarNumberCol.Length - 1
                            If DollarNumberCol(i).Trim.Length > 0 Then
                                rng = xlWorkSheet.Range(DollarNumberCol(i).Trim & 1.ToString & ":" & DollarNumberCol(i).Trim & (RowsNum + 1).ToString)
                                rng.NumberFormat = "$#,##0.00"
                            End If
                        Next i
                    End If

                    'Set column format (summary sheets)
                    If dtTmp.TableName = dtSummary.TableName AndAlso dtSummary.Rows.Count > 0 Then
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(4) & 1.ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx2) & (RowsNum + 1).ToString)
                        rng.NumberFormat = "#"       'number
                    End If

                    'Produce data for excel
                    ReDim objArrData(RowsNum + 1, ColsNum)
                    For i = 0 To dtTmp.Rows.Count - 1
                        For j = 0 To dtTmp.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dtTmp.Columns(j).ColumnName
                            objArrData(i + 1, j) = dtTmp.Rows(i)(j)
                        Next j
                    Next i

                    'Post data to excel sheet
                    xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + 1).ToString).Value = objArrData

                    'Summary format
                    j = 0
                    If dtTmp.TableName = dtSummary.TableName AndAlso dtSummary.Rows.Count > 0 Then
                        'sum cols
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(iSumColIdx1) & 2.ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx1) & (RowsNum + 1).ToString)
                        rng.Formula = "=SUM(" & Buisness.Generic.CalExcelColLetter(4) & 2 & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx1 - 1) & 2.ToString & ")"
                        rng.Font.Bold = True
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(iSumColIdx2) & 2.ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx2) & (RowsNum + 1).ToString)
                        rng.Formula = "=SUM(" & Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 2) & 2.ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx2 - 1) & 2.ToString & ")"
                        rng.Font.Bold = True
                        'sum row
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(4) & (RowsNum + 2).ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx1) & (RowsNum + 2).ToString)
                        rng.Formula = "=SUM(" & Buisness.Generic.CalExcelColLetter(4) & 2 & ":" & Buisness.Generic.CalExcelColLetter(4) & (RowsNum + 1).ToString & ")"
                        rng.Font.Bold = True
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 2) & (RowsNum + 2).ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx2) & (RowsNum + 2).ToString)
                        rng.Formula = "=SUM(" & Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 2) & 2 & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 2) & (RowsNum + 1).ToString & ")"
                        rng.Font.Bold = True
                        rng = xlWorkSheet.Range("A" & (RowsNum + 2).ToString & ":" & "A" & (RowsNum + 2).ToString)
                        rng.Value = "Total" : rng.Font.Bold = True

                        'split bar
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 1) & 1.ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 1) & 1.ToString)
                        rng.Value = ""
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 1) & 1.ToString & ":" & Buisness.Generic.CalExcelColLetter(iSumColIdx1 + 1) & (RowsNum + 2).ToString)
                        rng.ColumnWidth = 1 : rng.Interior.ColorIndex = 16
                    End If

                    'Format header
                    rng = xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & "1")
                    With rng
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .Font.Bold = True
                        '.Font.ColorIndex = 5
                        .Interior.ColorIndex = 37
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    'Font size 
                    If (RowsNum + 2) > iSheetMaxRows Then
                        rng = xlWorkSheet.Range("A1" & ":" & Buisness.Generic.CalExcelColLetter(ColsNum) & iSheetMaxRows.ToString)
                    Else
                        rng = xlWorkSheet.Range("A1" & ":" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + 2).ToString)
                    End If
                    rng.Font.Size = 9

                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'Freeze Top 1 Row
                    Try
                        xlWorkSheet.Application.ActiveWindow.SplitRow = 1
                        xlWorkSheet.Application.ActiveWindow.FreezePanes = True
                    Catch ex As Exception
                    End Try

                    'Set Sheet Name
                    xlWorkSheet.Name = dtTmp.TableName
                End If
            Next

            strFileName = ""
            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = strRptName & ".xls"
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


            Try
                'Close Excel
                ' xlWorkBook.Close(SaveChanges:=False)
                xlWorkSheet = Nothing
                xlWorkBook = Nothing
                xlApp.Quit()
                ReleaseObject(xlWorkSheet)
                ReleaseObject(xlWorkBook)
                ReleaseObject(xlApp)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                'objSaveFileDialog = Nothing() Hung Nguyen 11/07/2011 This casue error
            End If
            PSS.Data.Buisness.Generic.DisposeDT(dtTmp)
            Me._objDataProc = Nothing

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
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunSimpleExcelFormat_MultipleSheets(ByVal dt As DataTable, _
      ByVal strRptName As String, _
      ByVal strSheetNamePrefix As String, _
      Optional ByVal strTextCol() As String = Nothing, _
      Optional ByVal DollarNumberCol() As String = Nothing)
        Dim strFileName As String = ""
        Dim objArrData(,) As Object
        Dim R1, row As DataRow
        Dim i, j, k, m As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim iSheetMaxRows As Integer = 65536    'Excel 2003 - Excel 97
        Dim iSheetMaxName As Integer = 31
        Dim strS As String = ""
        Dim dtTmp As DataTable
        Dim ds As New DataSet()

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim rng As Excel.Range
        Dim misValue As Object = System.Reflection.Missing.Value

        Try
            If dt.Rows.Count = 0 Then Exit Sub

            If dt.Rows.Count > iSheetMaxRows - 1 Then    'one row is header, multiple sheets
                'now split the datatable
                Dim n As Integer = iSheetMaxRows - 1    'number of rows per datatable
                For i = 0 To dt.Rows.Count - 1 Step n
                    Dim intLastRow As Integer = i + n - 1
                    If intLastRow > dt.Rows.Count - 1 Then intLastRow = dt.Rows.Count - 1
                    Dim dtbNew As DataTable = dt.Clone       'copy structure of original datatable 
                    'dtbNew.TableName = dt.TableName & " " & (i \ n).ToString
                    If strSheetNamePrefix.Trim.ToString.Length = 0 Then
                        strS = "Sheet" & " " & ((i \ n) + 1).ToString
                    ElseIf strSheetNamePrefix.Trim.ToString.Length <= iSheetMaxName - 3 Then       'assume max sheet sequence number is 999
                        strS = strSheetNamePrefix.Trim.ToString & " " & ((i \ n) + 1).ToString
                    Else
                        strS = strSheetNamePrefix.Trim.ToString.Substring(0, iSheetMaxName - 3) & " " & ((i \ n) + 1).ToString
                    End If
                    For j = i To intLastRow
                        dtbNew.ImportRow(dt.Rows(j))
                    Next j
                    dtbNew.TableName = strS
                    ds.Tables.Add(dtbNew)
                Next i
            Else    ' One sheet
                If strSheetNamePrefix.Trim.ToString.Length = 0 Then
                    strS = "Sheet1"
                ElseIf strSheetNamePrefix.Trim.ToString.Length <= iSheetMaxName Then
                    strS = strSheetNamePrefix.Trim.ToString
                Else
                    strS = strSheetNamePrefix.Trim.ToString.Substring(0, iSheetMaxName)
                End If
                dt.TableName = strS
                ds.Tables.Add(dt)
            End If

            If Not ds.Tables.Count > 0 Then
                MessageBox.Show("Master datatable has data, but dataset has no tables.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'Create Excel ------------------------------------------------------------------------------------------------------------------------
            xlApp = New Excel.Application()
            xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
            xlApp.Visible = False : xlApp.DisplayAlerts = False

            'Add new worksheets as needed
            If ds.Tables.Count >= 3 Then
                For m = 4 To ds.Tables.Count
                    xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet)       'Add sheet
                    xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count))       'Move to the last 
                Next
            End If

            k = 0
            For Each dtTmp In ds.Tables
                k += 1
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(k), Excel._Worksheet)
                xlWorkSheet.Select()

                If Not dtTmp.Rows.Count > 0 Then
                    xlWorkSheet.Cells(1, 1) = "No data"
                    xlWorkSheet.Name = dtTmp.TableName
                    'Set font 
                    rng = xlWorkSheet.Range("A1:A1")
                    rng.Font.Name = "Calibri" : rng.Font.Size = 9
                Else
                    Dim RowsNum As Integer = dtTmp.Rows.Count
                    Dim ColsNum As Integer = dtTmp.Columns.Count


                    'Set column format
                    If Not IsNothing(strTextCol) Then
                        For i = 0 To strTextCol.Length - 1
                            If strTextCol(i).Trim.Length > 0 Then
                                rng = xlWorkSheet.Range(strTextCol(i).Trim & 1.ToString & ":" & strTextCol(i).Trim & (RowsNum + 1).ToString)
                                rng.NumberFormat = "@"          'text
                            End If
                        Next i
                    End If
                    If Not IsNothing(DollarNumberCol) Then
                        For i = 0 To DollarNumberCol.Length - 1
                            If DollarNumberCol(i).Trim.Length > 0 Then
                                rng = xlWorkSheet.Range(DollarNumberCol(i).Trim & 1.ToString & ":" & DollarNumberCol(i).Trim & (RowsNum + 1).ToString)
                                rng.NumberFormat = "$#,##0.00"
                            End If
                        Next i
                    End If

                    'Form data for excel
                    'i = 0 : j = 0
                    ReDim objArrData(RowsNum + 1, ColsNum)
                    For i = 0 To dtTmp.Rows.Count - 1
                        For j = 0 To dtTmp.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dtTmp.Columns(j).ColumnName
                            objArrData(i + 1, j) = dtTmp.Rows(i)(j)
                        Next j
                    Next i

                    'Post data to excel sheet
                    xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + 1).ToString).Value = objArrData

                    'Format
                    rng = xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & "1")
                    With rng
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .Font.Bold = True
                        '.Font.ColorIndex = 5
                        .Interior.ColorIndex = 37
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'Set Sheet Name
                    xlWorkSheet.Name = dtTmp.TableName
                End If
            Next

            strFileName = ""
            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = strRptName & ".xls"
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
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                'objSaveFileDialog = Nothing() Hung Nguyen 11/07/2011 This casue error
            End If
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._objDataProc = Nothing

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
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunSimpleExcelFormat_PerSheetPerTable(ByVal ds As DataSet, _
     ByVal strRptName As String, _
     Optional ByVal strTextCol() As String = Nothing, _
     Optional ByVal DollarNumberCol() As String = Nothing, _
     Optional ByVal bAutoCol As Boolean = True)

        Dim strFileName As String = ""
        Dim objArrData(,) As Object
        Dim R1, row As DataRow
        Dim i, j, k, m As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim strS As String = ""
        Dim dtTmp As DataTable

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim rng As Excel.Range
        Dim misValue As Object = System.Reflection.Missing.Value

        Try

            'Create Excel ------------------------------------------------------------------------------------------------------------------------
            xlApp = New Excel.Application()
            xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
            xlApp.Visible = False : xlApp.DisplayAlerts = False

            'Add new worksheets as needed
            If ds.Tables.Count >= 3 Then
                For m = 4 To ds.Tables.Count
                    xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet)       'Add sheet
                    xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count))       'Move to the last 
                Next
            End If

            k = 0
            For Each dtTmp In ds.Tables
                k += 1
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(k), Excel._Worksheet)
                xlWorkSheet.Select()

                If Not dtTmp.Rows.Count > 0 Then
                    xlWorkSheet.Cells(1, 1) = "No data"
                    xlWorkSheet.Name = dtTmp.TableName
                    'Set font 
                    rng = xlWorkSheet.Range("A1:A1")
                    rng.Font.Name = "Calibri" : rng.Font.Size = 9
                Else
                    Dim RowsNum As Integer = dtTmp.Rows.Count
                    Dim ColsNum As Integer = dtTmp.Columns.Count


                    'Set column format
                    If Not IsNothing(strTextCol) Then
                        For i = 0 To strTextCol.Length - 1
                            If strTextCol(i).Trim.Length > 0 Then
                                rng = xlWorkSheet.Range(strTextCol(i).Trim & 1.ToString & ":" & strTextCol(i).Trim & (RowsNum + 1).ToString)
                                rng.NumberFormat = "@"          'text
                            End If
                        Next i
                    End If
                    If Not IsNothing(DollarNumberCol) Then
                        For i = 0 To DollarNumberCol.Length - 1
                            If DollarNumberCol(i).Trim.Length > 0 Then
                                rng = xlWorkSheet.Range(DollarNumberCol(i).Trim & 1.ToString & ":" & DollarNumberCol(i).Trim & (RowsNum + 1).ToString)
                                rng.NumberFormat = "$#,##0.00"
                            End If
                        Next i
                    End If

                    'Form data for excel
                    'i = 0 : j = 0
                    ReDim objArrData(RowsNum + 1, ColsNum)
                    For i = 0 To dtTmp.Rows.Count - 1
                        For j = 0 To dtTmp.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dtTmp.Columns(j).ColumnName
                            objArrData(i + 1, j) = dtTmp.Rows(i)(j)
                        Next j
                    Next i

                    'Post data to excel sheet
                    xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + 1).ToString).Value = objArrData

                    'Format
                    rng = xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & "1")
                    With rng
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .Font.Bold = True
                        '.Font.ColorIndex = 5
                        .Interior.ColorIndex = 37
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    'Auto Fit
                    If bAutoCol Then
                        xlWorkSheet.Cells.EntireColumn.AutoFit()
                    End If
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'Set Sheet Name
                    xlWorkSheet.Name = dtTmp.TableName
                    End If
            Next

            strFileName = ""
            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = strRptName & ".xls"
            objSaveFileDialog.ShowDialog()
            strFileName = objSaveFileDialog.FileName

            If strFileName.Trim.Length = 0 Then
                MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If strFileName.IndexOf("\") < 0 Then Exit Sub
                If File.Exists(strFileName) = True Then Kill(strFileName)
                xlWorkBook.SaveAs(strFileName)
                _lastSimpleFileSaved = strFileName
                MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                'objSaveFileDialog = Nothing() Hung Nguyen 11/07/2011 This casue error
            End If
            'PSS.Data.Buisness.Generic.DisposeDT(dt)
            'Me._objDataProc = Nothing

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
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunNIInvoiceReport(ByVal ds As DataSet, _
      ByVal strRptName As String, _
      ByVal strHeaderDates As String, _
      ByVal bSummaryDetails As Boolean, _
      Optional ByVal strTextCol() As String = Nothing, _
      Optional ByVal DollarNumberCol() As String = Nothing)
        Dim strFileName As String = ""
        Dim objArrData(,) As Object
        Dim R1, row As DataRow
        Dim i, j, k, m As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim strS As String = ""
        Dim dtTmp As DataTable
        Dim iStartingRowNum As Integer = 1

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim rng As Excel.Range
        Dim misValue As Object = System.Reflection.Missing.Value

        Try

            'Create Excel ------------------------------------------------------------------------------------------------------------------------
            xlApp = New Excel.Application()
            xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
            xlApp.Visible = False : xlApp.DisplayAlerts = False
            xlApp.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
            xlApp.ActiveWindow.DisplayGridlines = False

            'Add new worksheets as needed
            If ds.Tables.Count >= 3 Then
                For m = 4 To ds.Tables.Count + 1    'plus 1 summery sheet
                    xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet)       'Add sheet
                    xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count))       'Move to the last 
                Next
            End If

            k = 0
            For Each dtTmp In ds.Tables
                k += 1
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(k), Excel._Worksheet)
                xlWorkSheet.Select()

                If Not dtTmp.Rows.Count > 0 Then
                    xlWorkSheet.Cells(1, 1) = "No data"
                    xlWorkSheet.Name = dtTmp.TableName
                    'Set font 
                    rng = xlWorkSheet.Range("A1:A1")
                    rng.Font.Name = "Calibri" : rng.Font.Size = 9
                Else
                    Dim RowsNum As Integer = dtTmp.Rows.Count
                    Dim ColsNum As Integer = dtTmp.Columns.Count

                    'Set column format
                    If Not bSummaryDetails Then
                        iStartingRowNum = 4
                        If Not IsNothing(strTextCol) Then
                            For i = 0 To strTextCol.Length - 1
                                If strTextCol(i).Trim.Length > 0 Then
                                    rng = xlWorkSheet.Range(strTextCol(i).Trim & 1.ToString & ":" & strTextCol(i).Trim & (RowsNum + iStartingRowNum + 1).ToString)
                                    rng.NumberFormat = "@"          'text
                                End If
                            Next i
                        End If
                        If Not IsNothing(DollarNumberCol) Then
                            For i = 0 To DollarNumberCol.Length - 1
                                If DollarNumberCol(i).Trim.Length > 0 Then
                                    rng = xlWorkSheet.Range(DollarNumberCol(i).Trim & 1.ToString & ":" & DollarNumberCol(i).Trim & (RowsNum + iStartingRowNum + 1).ToString)
                                    rng.NumberFormat = "$#,##0.00"
                                End If
                            Next i
                        End If
                    Else
                        iStartingRowNum = 1
                        If Not IsNothing(strTextCol) Then
                            For i = 0 To strTextCol.Length - 1
                                If strTextCol(i).Trim.Length > 0 Then
                                    rng = xlWorkSheet.Range(strTextCol(i).Trim & 1.ToString & ":" & strTextCol(i).Trim & (RowsNum + iStartingRowNum + 1).ToString)
                                    rng.NumberFormat = "@"          'text
                                End If
                            Next i
                        End If

                        Select Case k
                            Case 1
                                strS = (RowsNum + iStartingRowNum).ToString
                                rng = xlWorkSheet.Range("N" & (iStartingRowNum).ToString & ":W" & strS)
                                rng.NumberFormat = "@"          'text
                                rng = xlWorkSheet.Range("V" & (iStartingRowNum).ToString & ":AC" & strS)
                                rng.NumberFormat = "@"          'text
                                rng = xlWorkSheet.Range("AJ" & (iStartingRowNum).ToString & ":AM" & strS)
                                rng.NumberFormat = "@"          'text

                            Case 2
                                rng = xlWorkSheet.Range("G" & (iStartingRowNum).ToString & ":L" & strS)
                                rng.NumberFormat = "@"          'text
                            Case 3
                                rng = xlWorkSheet.Range("G" & (iStartingRowNum).ToString & ":I" & strS)
                                rng.NumberFormat = "@"          'text
                                rng = xlWorkSheet.Range("K" & (iStartingRowNum).ToString & ":U" & strS)
                                rng.NumberFormat = "@"          'text
                            Case 4
                                rng = xlWorkSheet.Range("G" & (iStartingRowNum).ToString & ":X" & strS)
                                rng.NumberFormat = "@"          'text
                        End Select
                    End If

                    'Form data for excel
                    'i = 0 : j = 0
                    ReDim objArrData(RowsNum + 1, ColsNum)
                    For i = 0 To dtTmp.Rows.Count - 1
                        For j = 0 To dtTmp.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dtTmp.Columns(j).ColumnName
                            objArrData(i + 1, j) = dtTmp.Rows(i)(j)
                        Next j
                    Next i

                    'Font
                    rng = xlWorkSheet.Range("A" & iStartingRowNum.ToString & ":" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + iStartingRowNum + 1).ToString)
                    rng.Font.Name = "Calibri" : rng.Font.Size = 9

                    'Post data to excel sheet
                    xlWorkSheet.Range("A" & iStartingRowNum.ToString & ":" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + iStartingRowNum).ToString).Value = objArrData

                    'Add borders 
                    rng = xlWorkSheet.Range("A" & iStartingRowNum.ToString & ":" & Buisness.Generic.CalExcelColLetter(ColsNum) & (RowsNum + iStartingRowNum + 1).ToString)
                    rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                    'Format 
                    rng = xlWorkSheet.Range("A" & iStartingRowNum.ToString & ":" & Buisness.Generic.CalExcelColLetter(ColsNum) & iStartingRowNum.ToString)
                    With rng
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .Font.Bold = True
                        '.Font.ColorIndex = 5
                        ' .Interior.ColorIndex = 37
                        ' .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    If Not bSummaryDetails Then
                        'add Sum
                        rng = xlWorkSheet.Range("P" & (iStartingRowNum + 1).ToString & ":" & "P" & (RowsNum + iStartingRowNum).ToString)
                        rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "O" & (iStartingRowNum + 1).ToString & ")"
                        rng = xlWorkSheet.Range("F" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "P" & (RowsNum + iStartingRowNum + 1).ToString)
                        rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum).ToString & ")"

                        'total, merge
                        rng = xlWorkSheet.Range("A" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "E" & (RowsNum + iStartingRowNum + 1).ToString)
                        rng.HorizontalAlignment = Excel.Constants.xlCenter
                        rng.MergeCells = True : xlWorkSheet.Cells(RowsNum + iStartingRowNum + 1, 1) = "Total"
                        rng = xlWorkSheet.Range("A" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "P" & (RowsNum + iStartingRowNum + 1).ToString)
                        rng.Font.Bold = True

                        'Headers
                        rng = xlWorkSheet.Range("A1:" & Buisness.Generic.CalExcelColLetter(ColsNum) & +1.ToString)
                        rng.Font.Bold = True : rng.Font.Size = 14 : rng.Font.ColorIndex = 49
                        rng.MergeCells = True : xlWorkSheet.Cells(1, 1) = "Native Instruments Invoice"

                        rng = xlWorkSheet.Range("A" & (iStartingRowNum - 1).ToString & ":" & "E" & (iStartingRowNum - 1).ToString)
                        rng.HorizontalAlignment = Excel.Constants.xlCenter
                        rng.MergeCells = True : xlWorkSheet.Cells(iStartingRowNum - 1, 1) = strHeaderDates
                        rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

                        rng = xlWorkSheet.Range("J" & (iStartingRowNum - 1).ToString & ":" & "J" & (iStartingRowNum - 1).ToString)
                        rng.Value = "Service Codes" : rng.Font.Size = 8

                        rng = xlWorkSheet.Range("O" & (iStartingRowNum - 1).ToString & ":" & "O" & (iStartingRowNum - 1).ToString)
                        rng.Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                        rng = xlWorkSheet.Range("F" & (iStartingRowNum - 2).ToString & ":" & "O" & (iStartingRowNum - 2).ToString)
                        rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        rng.Font.Size = 8 : rng.Font.Bold = True
                        rng.HorizontalAlignment = Excel.Constants.xlCenter
                        rng.VerticalAlignment = Excel.Constants.xlCenter

                        strS = "Call-Tag" & Environment.NewLine & " Mailing"
                        rng = xlWorkSheet.Range("F" & (iStartingRowNum - 2).ToString & ":" & "F" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 33

                        strS = "Receive &" & Environment.NewLine & " Reconcile" & Environment.NewLine & " RMA"
                        rng = xlWorkSheet.Range("G" & (iStartingRowNum - 2).ToString & ":" & "G" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 44

                        strS = "Customer" & Environment.NewLine & " Abuse"
                        rng = xlWorkSheet.Range("H" & (iStartingRowNum - 2).ToString & ":" & "H" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 38

                        strS = "Beyond-" & Environment.NewLine & "Economic-" & Environment.NewLine & "Repair"
                        rng = xlWorkSheet.Range("I" & (iStartingRowNum - 2).ToString & ":" & "I" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 50

                        strS = "Power-On," & Environment.NewLine & " Test, Triage," & Environment.NewLine & " No-Fault-" & Environment.NewLine & _
                         "Found (NFF)" & Environment.NewLine & " and Sort"
                        rng = xlWorkSheet.Range("J" & (iStartingRowNum - 2).ToString & ":" & "J" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 50

                        strS = "Repair &" & Environment.NewLine & " Refurbish"
                        rng = xlWorkSheet.Range("K" & (iStartingRowNum - 2).ToString & ":" & "K" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 50

                        strS = "Scrapping" & Environment.NewLine & " Fee/Each"
                        rng = xlWorkSheet.Range("L" & (iStartingRowNum - 2).ToString & ":" & "L" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 39

                        strS = "Reclamation" & Environment.NewLine & " & Parts" & Environment.NewLine & " Harvesting"
                        rng = xlWorkSheet.Range("M" & (iStartingRowNum - 2).ToString & ":" & "M" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 39

                        strS = "Pack &" & Environment.NewLine & " Ship"
                        rng = xlWorkSheet.Range("N" & (iStartingRowNum - 2).ToString & ":" & "N" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 45

                        strS = "Special" & Environment.NewLine & " Projects"
                        rng = xlWorkSheet.Range("O" & (iStartingRowNum - 2).ToString & ":" & "O" & (iStartingRowNum - 2).ToString)
                        rng.Value = strS : rng.Interior.ColorIndex = 37
                    Else
                        Select Case k
                            Case 1
                                rng = xlWorkSheet.Range("F" & iStartingRowNum.ToString & ":" & "F" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(Abuse)"
                                rng = xlWorkSheet.Range("G" & iStartingRowNum.ToString & ":" & "G" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(BER)"
                                rng = xlWorkSheet.Range("H" & iStartingRowNum.ToString & ":" & "H" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(TTS)"
                                rng = xlWorkSheet.Range("I" & iStartingRowNum.ToString & ":" & "I" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(Repair)"
                                rng = xlWorkSheet.Range("J" & iStartingRowNum.ToString & ":" & "J" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(Scrap)"
                                rng = xlWorkSheet.Range("K" & iStartingRowNum.ToString & ":" & "K" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(Reclm)"
                                rng = xlWorkSheet.Range("L" & iStartingRowNum.ToString & ":" & "L" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(Sp proj)"

                                rng = xlWorkSheet.Range("M" & (iStartingRowNum + 1).ToString & ":" & "M" & (RowsNum + iStartingRowNum).ToString)
                                rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "L" & (iStartingRowNum + 1).ToString & ")"
                                rng = xlWorkSheet.Range("F" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "M" & (RowsNum + iStartingRowNum + 1).ToString)
                                rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum).ToString & ")"
                                rng.Font.Bold = True
                            Case 2
                                rng = xlWorkSheet.Range("F" & iStartingRowNum.ToString & ":" & "F" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(Receive)"
                                rng = xlWorkSheet.Range("F" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum + 1).ToString)
                                rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum).ToString & ")"
                                rng.Font.Bold = True
                            Case 3
                                rng = xlWorkSheet.Range("F" & iStartingRowNum.ToString & ":" & "F" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(CTM)"
                                rng = xlWorkSheet.Range("F" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum + 1).ToString)
                                rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum).ToString & ")"
                                rng.Font.Bold = True
                            Case 4
                                rng = xlWorkSheet.Range("F" & iStartingRowNum.ToString & ":" & "F" & iStartingRowNum.ToString)
                                rng.Value = rng.Value & Environment.NewLine & "(PackShip)"
                                rng = xlWorkSheet.Range("F" & (RowsNum + iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum + 1).ToString)
                                rng.Formula = "=SUM(F" & (iStartingRowNum + 1).ToString & ":" & "F" & (RowsNum + iStartingRowNum).ToString & ")"
                                rng.Font.Bold = True
                        End Select

                    End If

                    'Freeze Top Row
                    If Not bSummaryDetails Then
                        Try
                            'objSheet.FreezePanes(2, 1) 'not correct
                            'objExcel.Windows(1).SplitColumn = 1 'freeze column 1 (Column A)
                            'xlWorkSheet.Windows(1).SplitRow = 1 'freeze top 1 row; if =4 freeze top 4 rows
                            'xlWorkSheet.Windows(1).FreezePanes = True
                            'xlWorkSheet.ActiveWindow.FreezePanes = False
                            'xlWorkSheet.Range("A4:E4").Select()
                            'xlWorkSheet.ActiveWindow.FreezePanes = True
                            xlWorkSheet.Application.ActiveWindow.SplitRow = 4
                            xlWorkSheet.Application.ActiveWindow.FreezePanes = True
                        Catch ex As Exception
                        End Try
                    Else
                        Try
                            xlWorkSheet.Application.ActiveWindow.SplitRow = 1
                            xlWorkSheet.Application.ActiveWindow.FreezePanes = True
                        Catch ex As Exception
                        End Try
                    End If


                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'reset Column M width
                    If Not bSummaryDetails Then
                        xlWorkSheet.Columns("M:M").ColumnWidth = 8.6
                    Else
                        If k = 1 Then
                            xlWorkSheet.Columns("Z:Z").ColumnWidth = 8 : xlWorkSheet.Columns("AB:AB").ColumnWidth = 8
                            xlWorkSheet.Columns("AC:AC").ColumnWidth = 8 : xlWorkSheet.Columns("AJ:AJ").ColumnWidth = 8
                            xlWorkSheet.Columns("AK:AK").ColumnWidth = 8 : xlWorkSheet.Columns("W:W").ColumnWidth = 8
                        End If
                    End If

                    'Set Sheet Name
                    xlWorkSheet.Name = dtTmp.TableName
                End If
            Next

            'summary
            k = ds.Tables.Count + 1
            If bSummaryDetails Then
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(k), Excel._Worksheet)
                xlWorkSheet.Select()
                xlWorkSheet.Name = "Summary"

                rng = xlWorkSheet.Range("A1" & ":B" & k.ToString)
                rng.Font.Name = "Calibri" : rng.Font.Size = 11
                rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rng = xlWorkSheet.Range("A" & k.ToString & ":B" & k.ToString)
                rng.Font.Bold = True
                rng = xlWorkSheet.Range("A" & k.ToString & ":A" & k.ToString)
                rng.HorizontalAlignment = Excel.Constants.xlLeft
                rng.Value = "Total"

                j = 1
                For Each dtTmp In ds.Tables
                    xlWorkSheet.Cells(j, 1) = dtTmp.TableName
                    rng = xlWorkSheet.Range("B" & j.ToString & ":" & "B" & j.ToString)
                    If j = 1 Then
                        If dtTmp.Rows.Count > 0 Then
                            rng.Formula = "='" & dtTmp.TableName & "'!M" & dtTmp.Rows.Count + 2
                        Else
                            rng.Value = 0
                        End If
                    Else
                        If dtTmp.Rows.Count > 0 Then
                            rng.Formula = "='" & dtTmp.TableName & "'!F" & dtTmp.Rows.Count + 2
                        Else
                            rng.Value = 0
                        End If
                    End If
                    j += 1
                Next
                rng = xlWorkSheet.Range("B" & k.ToString & ":B" & k.ToString)
                rng.Formula = "=SUM(B1" & ":" & "B" & ds.Tables.Count.ToString & ")"

                'Auto Fit
                xlWorkSheet.Cells.EntireColumn.AutoFit()
                xlWorkSheet.Cells.EntireRow.AutoFit()
            End If

            'File handle
            strFileName = ""
            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = strRptName & ".xls"
            objSaveFileDialog.ShowDialog()
            strFileName = objSaveFileDialog.FileName

            If strFileName.Trim.Length = 0 Then
                MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If strFileName.IndexOf("\") < 0 Then Exit Sub
                If File.Exists(strFileName) = True Then Kill(strFileName)
                xlWorkBook.SaveAs(strFileName)
                _lastSimpleFileSaved = strFileName
                MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                'objSaveFileDialog = Nothing() Hung Nguyen 11/07/2011 This casue error
            End If
            'PSS.Data.Buisness.Generic.DisposeDT(dt)
            'Me._objDataProc = Nothing

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
        End Try
    End Sub

    '*****************************************************************************
    Public Sub RunTFScreenedExcelReport(ByVal dt As DataTable, ByVal strRptName As String, _
                                   ByVal strStartDate As String, ByVal strEndDate As String)
        Dim strFileName As String = ""
        Dim objArrData(,) As Object
        Dim R1, row As DataRow
        Dim i, j, k, m As Integer
        Dim objSaveFileDialog As New SaveFileDialog()
        Dim strS As String = ""
        'Dim dtTmp As DataTable
        Dim iStartingRowNum As Integer = 1

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim rng As Excel.Range
        Dim misValue As Object = System.Reflection.Missing.Value

        Try

            'Create Excel ------------------------------------------------------------------------------------------------------------------------
            xlApp = New Excel.Application()
            xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
            xlApp.Visible = False : xlApp.DisplayAlerts = False
            xlApp.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape
            xlApp.ActiveWindow.DisplayGridlines = False


            k = 1
            xlWorkSheet = DirectCast(xlWorkBook.Sheets(k), Excel._Worksheet)
            xlWorkSheet.Select()

            If Not dt.Rows.Count > 0 Then
                xlWorkSheet.Cells(1, 1) = "No data"
                'xlWorkSheet.Name = dt.TableName
                'Set font 
                rng = xlWorkSheet.Range("A1:A1")
                rng.Font.Name = "Calibri" : rng.Font.Size = 14
            Else
                Dim RowsNum As Integer = dt.Rows.Count
                Dim ColsNum As Integer = dt.Columns.Count

                'Set column format
                rng = xlWorkSheet.Range("A" & 1.ToString & ":A" & (RowsNum + 3).ToString)
                rng.NumberFormat = "@" 'Text
                rng = xlWorkSheet.Range("B" & 2.ToString & ":E" & 2.ToString)
                rng.NumberFormat = "@" 'Text
                rng = xlWorkSheet.Range("B" & 3.ToString & ":E" & (RowsNum + 3).ToString)
                rng.NumberFormat = "#,##0" 'Dallar "$#,##0.00"

                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        For j = 0 To dt.Columns.Count - 1
                            rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(j + 1) & 2.ToString & ":" & Buisness.Generic.CalExcelColLetter(j + 1) & 2.ToString)
                            rng.Value2 = dt.Columns(j).ColumnName()
                        Next
                    End If

                    For j = 0 To dt.Columns.Count - 1
                        rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(j + 1) & (i + 3).ToString & ":" & Buisness.Generic.CalExcelColLetter(j + 1) & (i + 3).ToString)
                        If j = dt.Columns.Count - 1 Then 'last col
                            rng.Formula = "=C" & (i + 3).ToString & " - D" & (i + 3).ToString
                        Else
                            rng.Value2 = dt.Rows(i)(j)
                        End If
                    Next j

                    If i = dt.Rows.Count - 1 Then
                        rng = xlWorkSheet.Range("A" & (RowsNum + 3).ToString & ":A" & (RowsNum + 3).ToString)
                        rng.Value2 = "Total"
                        For j = 1 To dt.Columns.Count - 1
                            rng = xlWorkSheet.Range(Buisness.Generic.CalExcelColLetter(j + 1) & (RowsNum + 3).ToString & ":" & Buisness.Generic.CalExcelColLetter(j + 1) & (RowsNum + 3).ToString)
                            rng.Formula = "=SUM(" & Buisness.Generic.CalExcelColLetter(j + 1) & 3.ToString & ":" & Buisness.Generic.CalExcelColLetter(j + 1) & (RowsNum + 2).ToString & ")"
                        Next
                    End If
                Next i

                'Merge top header
                rng = xlWorkSheet.Range("A1:E1")
                rng.Merge()
                rng = xlWorkSheet.Range("A1:A1")
                rng.Value2 = strRptName & " (" & strStartDate & " to " & strEndDate & ")" 'set header
                rng.Font.Name = "Calibri" : rng.Font.Size = 12 : rng.Font.Bold = True

                'Border,Font
                rng = xlWorkSheet.Range("A2:E" & (RowsNum + 3).ToString)
                rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rng.Font.Name = "Calibri" : rng.Font.Size = 10

                rng = xlWorkSheet.Range("A2:E2")
                rng.Font.Bold = True 'rng.WrapText = True

                rng = xlWorkSheet.Range("A1:A" & (RowsNum + 3).ToString)
                rng.HorizontalAlignment = Excel.Constants.xlLeft

                rng = xlWorkSheet.Range("B2:E" & (RowsNum + 3).ToString)
                rng.HorizontalAlignment = Excel.Constants.xlRight

                rng = xlWorkSheet.Range("A" & (RowsNum + 3).ToString & ":E" & (RowsNum + 3).ToString)
                rng.Font.Bold = True

                'FreeseTop 2 rows
                Try
                    xlWorkSheet.Application.ActiveWindow.SplitRow = 2
                    xlWorkSheet.Application.ActiveWindow.FreezePanes = True
                Catch ex As Exception
                End Try

                'Auto Fit
                xlWorkSheet.Cells.EntireColumn.AutoFit()
                xlWorkSheet.Cells.EntireRow.AutoFit()

            End If

            'File handle
            strFileName = ""
            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = strRptName & ".xls"
            objSaveFileDialog.ShowDialog()
            strFileName = objSaveFileDialog.FileName

            If strFileName.Trim.Length = 0 Then
                MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If strFileName.IndexOf("\") < 0 Then Exit Sub
                If File.Exists(strFileName) = True Then Kill(strFileName)
                xlWorkBook.SaveAs(strFileName)
                _lastSimpleFileSaved = strFileName
                MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objSaveFileDialog) Then
                objSaveFileDialog.Dispose()
                'objSaveFileDialog = Nothing() Hung Nguyen 11/07/2011 This casue error
            End If
            'PSS.Data.Buisness.Generic.DisposeDT(dt)
            'Me._objDataProc = Nothing

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
        End Try
    End Sub
    '*****************************************************************************


#End Region     'External Reports

#Region "Syx Excel Report"

    '******************************************************************
    Public Function SyxReceivingModels(ByVal strRptName As String) As Integer

        Dim strSql As String
        Dim dt As DataTable


        Try

            strSql = "SELECT b.prod_desc as Product, c.Manuf_desc as Manuf ,a.Model_Desc as Model" & Environment.NewLine
            strSql &= ",d.ItemDescription as Description, a.Cost" & Environment.NewLine
            strSql &= "FROM syxdata a" & Environment.NewLine
            strSql &= "INNER JOIN lproduct b on b.prod_id= a.NewModelProdID" & Environment.NewLine
            strSql &= "INNER JOIN lmanuf c on c.manuf_id=a.manuf_id" & Environment.NewLine
            strSql &= "LEFT JOIN syxrecpalletdata d on d.itemnumber=a.model_desc" & Environment.NewLine
            strSql &= "GROUP BY b.prod_desc, c.Manuf_desc,a.Model_Desc;" & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for " & strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            '*************************
            'Format Report
            '*************************
            RunSimpleExcelFormat(dt, strRptName)
            '*************************

            Return dt.Rows.Count

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    '******************************************************************

    Public Function SyxTriagePretestCurrentInventory(ByVal strRptName As String) As Integer

        Dim strSql As String
        Dim dt As DataTable


        Try
            strSql = "SELECT c.prod_desc as Product, d.Manuf_desc as Manuf ,b.Model_Desc as Model ,f.QCResult as Result,b.Status" & Environment.NewLine
            strSql &= ",count(b.device_id) as Qty,  sum(b.Cost) as Cost" & Environment.NewLine
            strSql &= "FROM tdevice a" & Environment.NewLine
            strSql &= "INNER JOIN syxdata b on b.device_id=a.device_id" & Environment.NewLine
            strSql &= "INNER JOIN lproduct c on c.prod_id= b.NewModelProdID" & Environment.NewLine
            strSql &= "INNER JOIN lmanuf d on d.manuf_id=b.manuf_id" & Environment.NewLine
            strSql &= "LEFT JOIN tpretest_data e on e.device_id= a.device_id" & Environment.NewLine
            strSql &= "LEFT JOIN lqcresult f on f.qcresult_id= e.qcresult_id" & Environment.NewLine
            strSql &= "WHERE a.device_dateShip is null and e.qcresult_id > 0" & Environment.NewLine
            strSql &= "GROUP BY c.prod_desc, d.Manuf_desc,b.Model_Desc,f.QCResult,b.Status" & Environment.NewLine
            strSql &= "ORDER BY c.prod_desc, d.Manuf_desc,b.Model_Desc;" & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for " & strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            '*************************
            'Format Report
            '*************************
            RunSimpleExcelFormat(dt, strRptName)
            '*************************

            Return dt.Rows.Count

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function


    '******************************************************************

    Public Function SyxDateReport(ByVal strRptName As String, _
                                   ByVal strDateStart As String, _
                                   ByVal strDateEnd As String) As Integer

        Dim strSql As String
        Dim dt As DataTable


        Try
            strSql = "" & Environment.NewLine
            strSql &= "" & Environment.NewLine
            strSql &= "FROM " & Environment.NewLine
            strSql &= "INNER JOIN " & Environment.NewLine
            strSql &= "LEFT JOIN " & Environment.NewLine
            strSql &= "WHERE " & Environment.NewLine
            strSql &= "GROUP BY " & Environment.NewLine
            strSql &= "ORDER BY ;" & Environment.NewLine

            dt = Me._objDataProc.GetDataTable(strSql)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No data for " & strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Function
            End If

            '*************************
            'Format Report
            '*************************
            RunSimpleExcelFormat(dt, strRptName)
            '*************************

            Return dt.Rows.Count

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    Public Sub OpenExcelFile(ByVal filePath As String)
        Dim excelApp As Excel.Application = New Excel.Application()
        excelApp.Visible = True
        Dim workbookPath As String = (filePath)
        Dim excelWorkbook As Excel.Workbook = excelApp.Workbooks.Open(workbookPath, _
        0, False, 5, "", "", False, Excel.XlPlatform.xlWindows, "", _
        True, False, 0, True)
    End Sub


#End Region

End Class
