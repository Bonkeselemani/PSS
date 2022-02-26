
Option Explicit On 

Namespace Buisness
    Public Class DashBoardRpt
        Const _strNullDateFormat As String = "{0} IS NULL OR LENGTH(TRIM({0})) = 0 OR {0} = '0000-00-00 00:00:00' "
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

        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '**************************************************************
        Public Function CreateDashBoardRpt(ByVal strFromDate As String, _
                                           ByVal strToDate As String, _
                                           ByVal iGroup_ID As Integer, _
                                           ByVal strGroupDesc As String) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim dtLine, dtReject As DataTable
            Dim iTotalDays As Integer = 0
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iRow As Integer = 1
            Dim iCol As Integer = 65
            Dim strCalDate As String = ""
            Dim strDailyHeaders() As String = {"QC Functional Pass Units", "Ship Good Units", "Gross UPH", "Fallout %", "AQL Rejects", "Net UPH"}
            Dim strTotalHeaders() As String = {"Line", "QC Functional Pass Units", "Ship Good Units", "Completed Goal", "Completed Variance", "Gross UPH", "UPH Goal", "UPH Variance", "Fallout %", "AQL Rejects", "Net UPH"}
            Dim arrData(,) As Object
            Dim arrSupport(,) As Object
            Dim R1 As DataRow
            Dim iLoc_ID As Integer = 0

            Dim decTotalHrs As Decimal = 0.0
            Dim decGrpHrs As Decimal = 0.0
            Dim iTotalShipGoodUnits As Integer = 0
            Dim iTotalAQLRejCritical As Integer = 0
            Dim iTotalAQLRejNonCritical As Integer = 0
            Dim iTotalQCFunPassUnits As Integer = 0
            Dim iTotalFalloutUnits As Integer = 0

            Dim decLinesTotalHrs As Decimal = 0.0
            Dim iLinesTotalAQLRejCritical As Integer = 0
            Dim iLinesTotalAQLRejNonCritical As Integer = 0
            Dim iLinesTotalFalloutUnits As Integer = 0

            Dim dblDailyWAUPHGoalTier1 As Double = 0.0
            Dim dblWeeklyWAUPHGoalTier1 As Double = 0.0
            Dim dblDailyWAUPHGoalTier2 As Double = 0.0
            Dim dblWeeklyWAUPHGoalTier2 As Double = 0.0

            Try
                '**************************************
                'Define customer's location ID
                '**************************************
                Select Case iGroup_ID
                    Case 1  'Messaging
                        iLoc_ID = 19
                    Case 14, 78, 82 'GameStop-XBOX, GameStop-GAMECUBE 
                        iLoc_ID = 2743
                    Case 77 'Sonitrol
                        iLoc_ID = 2766
                    Case 77 'Sonitrol
                        iLoc_ID = 2766
                    Case 83 'SkyTel
                        iLoc_ID = SkyTel.SKYTEL_LOC_ID
                    Case 100 'Morris Communication
                        iLoc_ID = SkyTel.MorrisCom_LOC_ID
                    Case 101 'Propage
                        iLoc_ID = SkyTel.Propage_LOC_ID
                    Case 96 'Aquis
                        iLoc_ID = SkyTel.Aquis_LOC_ID
                    Case 115 'Cook Pager
                        iLoc_ID = SkyTel.CookPager_LOC_ID
                    Case 85 'Tracfone
                        iLoc_ID = TracFone.BuildShipPallet.TracFone_LOC_ID
                    Case 134 'Vivint
                        iLoc_ID = PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID
                    Case 133 'Wiko
                        iLoc_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID
                    Case 137 'Vinsmart
                        iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID
                    Case 135 'Coolpad
                        iLoc_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CP1_Loc_ID
                    Case Else
                        Throw New Exception("This report is not designed for the selected group. Please contact IT.")
                End Select

                '**************************************
                iTotalDays = DateDiff("d", CDate(strFromDate), CDate(strToDate), , )
                dtLine = Me.GetCostCenterLine(iGroup_ID.ToString(), False, True, strFromDate, strToDate)

                If dtLine.Rows.Count > 0 Then
                    'Prepare report
                    objExcel = New Excel.Application()
                    objExcel.Application.DisplayAlerts = False
                    objWorkbook = objExcel.Workbooks.Add
                    objSheet = objWorkbook.sheets("Sheet1")
                    objExcel.Visible = True
                    'objSheet.Activate()
                    objSheet.Name = "Dash Board"

                    '*********************************************************
                    'Daily(break selected date range into single day) section
                    '*********************************************************
                    'write timestamp and group description as title
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = Me.GetDateTimeStamp
                    iRow += 1
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strGroupDesc
                    iRow += 2

                    'redefine array
                    ReDim arrData(dtLine.Rows.Count + 1, ((iTotalDays + 1) * strDailyHeaders.Length))
                    ReDim arrSupport(1, ((iTotalDays + 1) * strDailyHeaders.Length))
                    '**************************************
                    'assign cost-center line to array data for daily section
                    '**************************************
                    arrData(j, 0) = "Line"

                    For Each R1 In dtLine.Rows
                        If R1("cc_desc") <> "Support" Then
                            j += 1
                            arrData(j, 0) = R1("cc_desc")
                        Else
                            arrSupport(0, 0) = R1("cc_desc")
                        End If
                    Next R1
                    arrData(j + 1, 0) = "Cell Total"

                    '***********************************
                    'Daily data
                    '***********************************
                    j = 0
                    For i = 0 To iTotalDays
                        'reset loop varialble
                        j = 0
                        decLinesTotalHrs = 0.0
                        iLinesTotalFalloutUnits = 0
                        iLinesTotalAQLRejCritical = 0
                        iLinesTotalAQLRejNonCritical = 0

                        'calculate next day
                        strCalDate = Format(DateAdd(DateInterval.Day, i, CDate(strFromDate)), "yyyy-MM-dd")

                        'write date and date name
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 3 + 1) & iRow.ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 3 + 1) & iRow.ToString).Value = Format(CDate(strCalDate), "MM/dd/yyyy")
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 3 + 1) & (iRow + 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 3 + 1) & (iRow + 1).ToString).Value = WeekdayName(Weekday(CDate(strCalDate), FirstDayOfWeek.Sunday))

                        'Header
                        arrData(j, (i * strDailyHeaders.Length) + 1) = strDailyHeaders(0).Replace(" ", vbLf)  'Pass QC Functional units
                        arrData(j, (i * strDailyHeaders.Length) + 2) = strDailyHeaders(1).Replace(" ", vbLf)  'Ship Units
                        arrData(j, (i * strDailyHeaders.Length) + 3) = strDailyHeaders(2).Replace(" ", vbLf)  'Actual UPH
                        arrData(j, (i * strDailyHeaders.Length) + 4) = strDailyHeaders(3).Replace(" ", vbLf)  'Fallout %
                        arrData(j, (i * strDailyHeaders.Length) + 5) = strDailyHeaders(4).Replace(" ", vbLf)  'AQL Reject
                        arrData(j, (i * strDailyHeaders.Length) + 6) = strDailyHeaders(5).Replace(" ", vbLf)  'AQL Reject

                        For Each R1 In dtLine.Rows
                            If R1("cc_desc") = "Support" Then
                                iTotalShipGoodUnits = 0
                                decGrpHrs = 0.0

                                'add special project calculation
                                If R1("GrpSpProj") = 1 Or R1("cc_specproj") = 1 Then
                                    iTotalShipGoodUnits = GetShipGoodUnitsSpecialProj(iGroup_ID, strCalDate, strCalDate, R1("cc_id"))
                                Else
                                    iTotalShipGoodUnits = Me.GetShipGoodUnits(iGroup_ID, strCalDate, strCalDate, )
                                End If

                                decGrpHrs = Math.Round(Me.GetTotalGrpHrs(iGroup_ID, strCalDate, strCalDate), 2)

                                arrSupport(0, (i * strDailyHeaders.Length) + 2) = iTotalShipGoodUnits  'Ship good units
                                If decGrpHrs > 0 Then arrSupport(0, (i * strDailyHeaders.Length) + 3) = "=RC[-1]/" & decGrpHrs Else arrData(j, (i * strDailyHeaders.Length) + 3) = 0 'Gross UPH
                            Else
                                    j += 1
                                    decTotalHrs = 0.0
                                    iTotalShipGoodUnits = 0
                                    iTotalQCFunPassUnits = 0
                                    iTotalAQLRejCritical = 0
                                    iTotalAQLRejNonCritical = 0
                                    iTotalFalloutUnits = 0
                                    Me.DisposeDT(dtReject)

                                    '*******************************
                                    'Daily total good unit, UPH
                                    '*******************************
                                    decTotalHrs = Math.Round(Me.GetTotalCellWorkHours(R1("cc_id"), strCalDate, strCalDate), 2)

                                If decTotalHrs > 0 Then
                                    '*******************************
                                    'Ship Good Units & and QC Functional Pass Unit
                                    '*******************************
                                    'add condition for special project calculation
                                    If R1("GrpSpProj") = 1 Or R1("cc_specproj") = 1 Then
                                        iTotalShipGoodUnits = GetShipGoodUnitsSpecialProj(iGroup_ID, strCalDate, strCalDate, R1("cc_id"))
                                    Else
                                        iTotalShipGoodUnits = Me.GetShipGoodUnits(iGroup_ID, strCalDate, strCalDate, R1("cc_id"))
                                    End If

                                    iTotalQCFunPassUnits = Me.GetCellProducedUnits(R1("Group_ID"), R1("cc_id"), R1("Produce_QCType_ID"), strCalDate, strCalDate)

                                    ''*******************************
                                    'Fallout Units
                                    ''*******************************
                                    iTotalFalloutUnits = Me.GetTotalFallOutUnits(R1("cc_id"), iGroup_ID, strCalDate, strCalDate)

                                    '*******************************
                                    'AQL Reject, Critical vs Non-Critical
                                    '*******************************
                                    dtReject = Me.GetFQA_AQLReject(R1("cc_id"), strCalDate, strCalDate)
                                    iTotalAQLRejCritical = dtReject.Select("Dcode_Critical = 1", "").Length 'Critical
                                    iTotalAQLRejNonCritical = dtReject.Select("Dcode_Critical = 0", "").Length 'Non-Critical

                                    '*******************************
                                    'Lines Total 
                                    '*******************************
                                    iLinesTotalFalloutUnits += iTotalFalloutUnits
                                    decLinesTotalHrs += decTotalHrs
                                    iLinesTotalAQLRejCritical += (iTotalAQLRejCritical * R1("cc_rcf"))
                                    iLinesTotalAQLRejNonCritical += (iTotalAQLRejNonCritical * R1("cc_rof"))

                                    '*******************************
                                    'Assign to array
                                    '*******************************
                                    arrData(j, (i * strDailyHeaders.Length) + 1) = iTotalQCFunPassUnits  'QC Func Pass units
                                    arrData(j, (i * strDailyHeaders.Length) + 2) = iTotalShipGoodUnits   'Ship good units
                                    If decTotalHrs > 0 Then arrData(j, (i * strDailyHeaders.Length) + 3) = "=RC[-1]/" & decTotalHrs Else arrData(j, (i * strDailyHeaders.Length) + 3) = 0 'Actual UPH
                                    If iTotalFalloutUnits > 0 Then arrData(j, (i * strDailyHeaders.Length) + 4) = "=" & CDec(iTotalFalloutUnits) & "/(RC[-2]+" & CDec(iTotalFalloutUnits) & ")" Else arrData(j, (i * strDailyHeaders.Length) + 4) = 0 'Reject %
                                    arrData(j, (i * strDailyHeaders.Length) + 5) = "=" & iTotalAQLRejCritical & "+" & iTotalAQLRejNonCritical  'AQL Reject
                                    If decTotalHrs > 0 Then arrData(j, (i * strDailyHeaders.Length) + 6) = "=(RC[-4]-(" & iTotalAQLRejCritical & "*" & R1("cc_rcf") & ")-(" & iTotalAQLRejNonCritical & "*" & R1("cc_rof") & "))/" & decTotalHrs Else arrData(j, (i * strDailyHeaders.Length) + 6) = 0 'Net UPH
                                    '*******************************
                                End If
                            End If
                        Next R1

                        '****************
                        'Total
                        '****************
                        'If decLinesTotalHrs > 0 Then
                        arrData(j + 1, (i * strDailyHeaders.Length) + 1) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"  'Completed units
                        arrData(j + 1, (i * strDailyHeaders.Length) + 2) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"  'Completed units
                        If decLinesTotalHrs > 0 Then arrData(j + 1, (i * strDailyHeaders.Length) + 3) = "=RC[-1]/" & decLinesTotalHrs Else arrData(j + 1, (i * strDailyHeaders.Length) + 3) = 0 'Gross UPH  

                        If iLinesTotalFalloutUnits > 0 Then arrData(j + 1, (i * strDailyHeaders.Length) + 4) = "=" & CDbl(iLinesTotalFalloutUnits) & "/(" & "RC[-2]+" & CDbl(iLinesTotalFalloutUnits) & ")" Else arrData(j + 1, (i * strDailyHeaders.Length) + 4) = 0 'Fallout %

                        arrData(j + 1, (i * strDailyHeaders.Length) + 5) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"  'AQL Reject
                        If decLinesTotalHrs > 0 Then arrData(j + 1, (i * strDailyHeaders.Length) + 6) = "=(RC[-4]-(" & iLinesTotalAQLRejCritical & "+" & iLinesTotalAQLRejNonCritical & "))/" & decLinesTotalHrs Else arrData(j + 1, (i * strDailyHeaders.Length) + 6) = 0 'Net UPH
                        'End If
                        '****************
                    Next i

                    iRow += 2

                    '*******************************
                    'post data to excel in daily section
                    objSheet.Range("A" & iRow.ToString & ":" & Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count).ToString).Value = arrData
                    objSheet.Range("A" & (iRow + dtLine.Rows.Count + 1).ToString & ":" & Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count + 1).ToString).Value = arrSupport
                    '*******************************
                    'set border
                    objExcel.Range("A" & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count + 1).ToString).Select()
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
                    'Center horizontal and vertical for data in daily section
                    objSheet.Range("A" & (iRow - 2).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count + 1).ToString).HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Range("A" & (iRow - 2).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count + 1).ToString).VerticalAlignment = Excel.Constants.xlBottom
                    '*******************************
                    'Set wrap text for header
                    objSheet.Range("B" & (iRow).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow).ToString).WrapText = True
                    '*******************************
                    'format Line cell
                    objSheet.Range("A" & (iRow - 1).ToString, "A" & (iRow).ToString).Merge()
                    '*******************************
                    'Title
                    With objSheet.Range("A" & (iRow - 4).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow - 4).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 14
                        .Underline = True
                        .ColorIndex = 25
                    End With
                    '*******************************
                    'date
                    With objSheet.Range("A" & (iRow - 1).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow - 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .ColorIndex = 5
                    End With
                    With objSheet.Range("A" & (iRow - 2).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow - 2).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .ColorIndex = 9
                    End With
                    '*******************************
                    'header
                    With objSheet.Range("A" & (iRow).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        '.Size = 12
                    End With
                    '*******************************
                    'Total
                    With objSheet.Range("A" & (iRow + dtLine.Rows.Count).ToString, Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        '.Size = 12
                    End With
                    '*******************************
                    'format
                    '*******************************
                    For i = 0 To iTotalDays
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 1) & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 1 + 1) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0"
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 2 + 1) & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 2 + 1) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.00"
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 3 + 1) & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 3 + 1) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.00%"
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 4 + 1) & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 4 + 1) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0"
                        objSheet.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 5 + 1) & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + 1 + 5 + 1) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.00"

                        'Draw a heavier border on the right side
                        objExcel.Range(Generic.CalExcelColLetter(i * strDailyHeaders.Length + strDailyHeaders.Length - 1 + 1) & (iRow - 1).ToString & ":" & Generic.CalExcelColLetter(i * strDailyHeaders.Length + strDailyHeaders.Length + 1) & (iRow + dtLine.Rows.Count + 1).ToString).Select()

                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With
                    Next i

                    'Draw a heavier border on the right side for cost center line
                    objExcel.Range("A" & (iRow).ToString & ":" & Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count + 1).ToString).Select()
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
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    'Draw a heavier border on the top & bottom edge  of total
                    objExcel.Range("A" & (iRow + dtLine.Rows.Count).ToString & ":" & Generic.CalExcelColLetter(((iTotalDays + 1) * strDailyHeaders.Length) + 1) & (iRow + dtLine.Rows.Count).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 1
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 1
                    End With

                    '***********************************
                    'Total(selected date range) section 
                    '***********************************
                    'reset variables to reuse 
                    arrData = Nothing
                    arrSupport = Nothing
                    decTotalHrs = 0.0
                    iTotalQCFunPassUnits = 0.0
                    iTotalShipGoodUnits = 0
                    iTotalAQLRejCritical = 0
                    iTotalAQLRejNonCritical = 0
                    j = 0
                    i = 0
                    R1 = Nothing
                    decLinesTotalHrs = 0.0
                    iTotalFalloutUnits = 0
                    iLinesTotalFalloutUnits = 0
                    iLinesTotalAQLRejCritical = 0
                    iLinesTotalAQLRejNonCritical = 0

                    'move row forward to total section
                    iRow = iRow + dtLine.Rows.Count + 1

                    iRow += 2
                    'write total title
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Total"

                    iRow += 2

                    'redefine array
                    ReDim arrData(dtLine.Rows.Count + 1, strTotalHeaders.Length)
                    ReDim arrSupport(1, strTotalHeaders.Length)

                    '**************************************
                    'assign cost-center line to array data of total section
                    '**************************************
                    arrData(j, 0) = "Line"

                    For Each R1 In dtLine.Rows
                        If R1("cc_desc") <> "Support" Then
                            j += 1
                            arrData(j, 0) = R1("cc_desc")
                        Else
                            arrSupport(0, 0) = R1("cc_desc")
                        End If
                    Next R1
                    arrData(j + 1, 0) = "Cell Total"

                    j = 0

                    '***********************
                    'Header
                    '***********************
                    For i = 0 To strTotalHeaders.Length - 1
                        arrData(j, i) = strTotalHeaders(i).Replace(" ", vbLf)
                    Next i

                    For Each R1 In dtLine.Rows
                        If R1("cc_desc") = "Support" Then
                            iTotalShipGoodUnits = 0
                            decGrpHrs = 0.0
                            'add special project calculation
                            If R1("GrpSpProj") = 1 Or R1("cc_specproj") = 1 Then
                                iTotalShipGoodUnits = GetShipGoodUnitsSpecialProj(iGroup_ID, strFromDate, strToDate, R1("cc_id"))
                            Else
                                iTotalShipGoodUnits = Me.GetShipGoodUnits(iGroup_ID, strFromDate, strToDate, )
                            End If
                            decGrpHrs = Math.Round(Me.GetTotalGrpHrs(iGroup_ID, strFromDate, strToDate), 2)

                            'assign to array
                            arrSupport(0, 2) = iTotalShipGoodUnits               'Completed units
                            arrSupport(0, 3) = "=" & decGrpHrs & "*" & R1("cc_uph_tier1")   'Completed goal
                            arrSupport(0, 4) = "=RC[-2]-RC[-1]"                    'Completed Variance
                            If decGrpHrs > 0 Then arrSupport(0, 5) = "=RC[-3]/" & decGrpHrs Else arrSupport(0, 5) = 0 'UPH
                            arrSupport(0, 6) = R1("cc_uph_tier1")                      'UPH Goal
                            arrSupport(0, 7) = "=RC[-2]-RC[-1]"                    'UPH Variance
                        Else
                                j += 1
                                decTotalHrs = 0.0
                                iTotalQCFunPassUnits = 0.0
                                iTotalShipGoodUnits = 0
                                iTotalAQLRejCritical = 0
                                iTotalAQLRejNonCritical = 0
                                iTotalFalloutUnits = 0
                                Me.DisposeDT(dtReject)

                                '*******************************
                                'Weeklyy total good unit, UPH
                                '*******************************
                                decTotalHrs = Math.Round(Me.GetTotalCellWorkHours(R1("cc_id"), strFromDate, strToDate), 2)

                                If decTotalHrs > 0 Then
                                    '*******************************
                                    'Ship Good Units & QC functional Pass Units
                                '*******************************
                                'add special project calculation
                                If R1("GrpSpProj") = 1 Or R1("cc_specproj") = 1 Then
                                    iTotalShipGoodUnits = GetShipGoodUnitsSpecialProj(iGroup_ID, strFromDate, strToDate, R1("cc_id"))
                                Else
                                    iTotalShipGoodUnits = Me.GetShipGoodUnits(iGroup_ID, strFromDate, strToDate, R1("cc_id"))
                                End If
                                iTotalQCFunPassUnits = Me.GetCellProducedUnits(R1("Group_ID"), R1("cc_id"), R1("Produce_QCType_ID"), strFromDate, strToDate)

                                ''*******************************
                                'Fallout Unit
                                ''*******************************
                                iTotalFalloutUnits = Me.GetTotalFallOutUnits(R1("cc_id"), iGroup_ID, strFromDate, strToDate)

                                '*******************************
                                'AQL Reject
                                '*******************************
                                dtReject = Me.GetFQA_AQLReject(R1("cc_id"), strFromDate, strToDate)
                                iTotalAQLRejCritical = dtReject.Select("Dcode_Critical = 1", "").Length 'Critical
                                iTotalAQLRejNonCritical = dtReject.Select("Dcode_Critical = 0", "").Length 'Non-Critical

                                '*******************************
                                'Line Total
                                '*******************************
                                decLinesTotalHrs += decTotalHrs
                                iLinesTotalFalloutUnits += iTotalFalloutUnits
                                iLinesTotalAQLRejCritical += (iTotalAQLRejCritical * R1("cc_rcf"))
                                iLinesTotalAQLRejNonCritical += (iTotalAQLRejNonCritical * R1("cc_rof"))

                                '*******************************
                                arrData(j, 1) = iTotalQCFunPassUnits               'QC functional pass units
                                arrData(j, 2) = iTotalShipGoodUnits               'Ship good units
                                arrData(j, 3) = "=" & decTotalHrs & "*" & R1("cc_uph_tier1")   'Completed goal
                                arrData(j, 4) = "=RC[-2]-RC[-1]"                    'Completed Variance
                                If decTotalHrs > 0 Then arrData(j, 5) = "=RC[-3]/" & decTotalHrs Else arrData(j, 5) = 0 'Gross UPH
                                arrData(j, 6) = R1("cc_uph_tier1")                      'UPH Goal
                                arrData(j, 7) = "=RC[-2]-RC[-1]"                    'UPH Variance
                                If iTotalFalloutUnits > 0 Then arrData(j, 8) = "=" & CDbl(iTotalFalloutUnits) & "/" & "(RC[-6]+" & CDbl(iTotalFalloutUnits) & ")" Else arrData(j, 8) = 0 'Fallout %
                                arrData(j, 9) = "=" & iTotalAQLRejCritical & "+" & iTotalAQLRejNonCritical              'AQL Rejects
                                If decTotalHrs > 0 Then arrData(j, 10) = "=(RC[-8]-(" & iTotalAQLRejCritical & "*" & R1("cc_rcf") & ")-(" & iTotalAQLRejNonCritical & "*" & R1("cc_rof") & "))/" & decTotalHrs Else arrData(j, 10) = 0 'Net UPH
                            End If
                            End If
                    Next R1

                    '******************
                    'Total
                    '******************
                    arrData(j + 1, 1) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"        'Completed units
                    arrData(j + 1, 2) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"        'Completed units
                    arrData(j + 1, 3) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"        'Completed units Goal
                    arrData(j + 1, 4) = "=RC[-2]-RC[-1]"        'Variance
                    If decLinesTotalHrs > 0 Then arrData(j + 1, 5) = "=RC[-3]/" & decLinesTotalHrs Else arrData(j + 1, 5) = 0 'UPH
                    If decLinesTotalHrs > 0 Then arrData(j + 1, 6) = "=RC[-3]/" & decLinesTotalHrs Else arrData(j + 1, 6) = 0 'UPH Goal
                    arrData(j + 1, 7) = "=RC[-2]-RC[-1]"        'Variance UPH
                    If iLinesTotalFalloutUnits > 0 Then arrData(j + 1, 8) = "=" & CDbl(iLinesTotalFalloutUnits) & "/" & "(RC[-6]+" & CDbl(iLinesTotalFalloutUnits) & ")" Else arrData(j + 1, 8) = 0 'Fallout % 
                    arrData(j + 1, 9) = "=SUM(R[-" & (j).ToString & "]C:R[-1]C)"        'AQL Reject
                    If decLinesTotalHrs > 0 Then arrData(j + 1, 10) = "=(RC[-8]-(" & iLinesTotalAQLRejCritical & "+" & iLinesTotalAQLRejNonCritical & "))/" & decLinesTotalHrs Else arrData(j + 1, 10) = 0 'Net UPH

                    '*******************************
                    'post data to excel in daily section
                    objSheet.Range("A" & iRow.ToString & ":" & "K" & (iRow + dtLine.Rows.Count).ToString).Value = arrData
                    objSheet.Range("A" & (iRow + dtLine.Rows.Count + 1).ToString & ":" & "K" & (iRow + dtLine.Rows.Count + 1).ToString).Value = arrSupport
                    '*******************************
                    'set border
                    objExcel.Range("A" & (iRow).ToString & ":" & "K" & (iRow + dtLine.Rows.Count + 1).ToString).Select()
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
                    'Set wrap text for header
                    objSheet.Range("A" & (iRow).ToString, "K" & (iRow).ToString).WrapText = True
                    '*******************************
                    'Title
                    With objSheet.Range("A" & (iRow - 2).ToString, "K" & (iRow - 2).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 14
                        .Underline = True
                        .ColorIndex = 25
                    End With
                    '*******************************
                    'header
                    With objSheet.Range("A" & (iRow).ToString, "K" & (iRow).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        '.Size = 12
                    End With

                    '*******************************
                    'Set horizontal and vertical 
                    objSheet.Range("A" & (iRow).ToString, "K" & (iRow + dtLine.Rows.Count + 1).ToString).HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Range("A" & (iRow).ToString, "K" & (iRow + dtLine.Rows.Count + 1).ToString).VerticalAlignment = Excel.Constants.xlBottom

                    '*******************************
                    'Total
                    With objSheet.Range("A" & (iRow + dtLine.Rows.Count).ToString, "K" & (iRow + dtLine.Rows.Count).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        '.Size = 12
                    End With
                    '*******************************
                    'Draw a heavier border on header topedge
                    objExcel.Range("A" & (iRow).ToString & ":" & "K" & iRow.ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    'Draw a heavier border on two side of total section
                    objExcel.Range("A" & (iRow + dtLine.Rows.Count).ToString & ":" & "K" & (iRow + dtLine.Rows.Count).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 1
                    End With
                    objExcel.Range("A" & (iRow + dtLine.Rows.Count).ToString & ":" & "K" & (iRow + dtLine.Rows.Count).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 1
                    End With

                    'Draw a heavier border on the top & bottom edge  of total
                    objExcel.Range("A" & (iRow).ToString & ":" & "K" & (iRow + dtLine.Rows.Count + 1).ToString).Select()
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
                    'format cell
                    objSheet.Range("B" & (iRow + 1).ToString & ":" & "E" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0"
                    objSheet.Range("F" & (iRow + 1).ToString & ":" & "H" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.00"
                    objSheet.Range("I" & (iRow + 1).ToString & ":" & "I" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.00%"
                    objSheet.Range("J" & (iRow + 1).ToString & ":" & "J" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0"
                    objSheet.Range("K" & (iRow + 1).ToString & ":" & "K" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.00"
                    '*******************************

                    '***********************************
                    'Adjust column widths
                    '***********************************
                    For i = 0 To ((iTotalDays + 1) * strDailyHeaders.Length)
                        objSheet.Columns(Generic.CalExcelColLetter(i + 1) & ":" & Generic.CalExcelColLetter(i + 1)).ColumnWidth = 12.43
                    Next i
                    '***********************************
                    'Set page orientation
                    '***********************************
                    objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                    objSheet.PageSetup.RightMargin = 4
                    objSheet.PageSetup.LeftMargin = 4
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
                xlBI = Nothing
                strTotalHeaders = Nothing
                strDailyHeaders = Nothing
                arrData = Nothing
                R1 = Nothing
                me.DisposeDT(dtLine)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetCostCenterLine(Optional ByVal strGroup_IDs As String = "", _
                                                 Optional ByVal iProdCell As Boolean = False, _
                                                 Optional ByVal booCalAvgUPH As Boolean = False, _
                                                 Optional ByVal strFrDate As String = "", _
                                                 Optional ByVal strToDate As String = "") As DataTable
            Dim strSQL As String
            Dim objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim dt, dtAvgUPH As DataTable
            Dim R1 As DataRow

            Try
                strSQL = "SELECT tcostcenter.*, lgroups.Special_Project as 'GrpSpProj', lgroups.Produce_QCType_ID " & Environment.NewLine
                strSQL &= "FROM tcostcenter " & Environment.NewLine
                strSQL &= "INNER JOIN lgroups ON tcostcenter.group_id = lgroups.group_id " & Environment.NewLine
                strSQL &= "WHERE cc_inactive = 0 " & Environment.NewLine
                If strGroup_IDs.Trim.Length > 0 Then
                    strSQL &= "AND tcostcenter.group_id IN ( " & strGroup_IDs & ") " & Environment.NewLine
                End If
                If iProdCell = True Then
                    strSQL &= "AND wa_id = 2 " & Environment.NewLine
                End If
                strSQL &= "ORDER BY tcostcenter.cc_desc ;"

                dt = objDataProc.GetDataTable(strSQL)

                If booCalAvgUPH = True Then
                    For Each R1 In dt.Rows
                        If R1("GrpSpProj") = 0 Then
                            dtAvgUPH = CalWeightedAvgUPH(objDataProc, R1("wa_id"), R1("group_id"), R1("cc_id"), strFrDate, strToDate)
                            R1("cc_uph_tier1") = dtAvgUPH.Rows(0)("Tier1")
                            R1("cc_uph_tier2") = dtAvgUPH.Rows(0)("Tier2")
                        End If
                    Next R1
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                R1 = Nothing
            End Try
        End Function

        '*****************************************************************
        Public Function GetTotalCellWorkHours(ByVal iCC_ID As Integer, _
                                               ByVal strFrDate As String, _
                                               ByVal strToDate As String) As Double
            Dim strSql As String = ""

            Try
                strSql = "SELECT (SUM(HOUR((CASE WHEN " & String.Format(Me._strNullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - HOUR(InTime)) * 3600 + SUM(MINUTE((CASE WHEN " & String.Format(Me._strNullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - MINUTE(InTime)) * 60 + SUM(SECOND((CASE WHEN " & String.Format(Me._strNullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - SECOND(InTime))) / 3600 AS TotalHours" & Environment.NewLine
                strSql &= "FROM production.tpunch " & Environment.NewLine
                strSql &= "WHERE cc_id = " & iCC_ID.ToString & Environment.NewLine
                strSql &= "AND Punch_WkDate >= '" & strFrDate & "' AND Punch_WkDate <= '" & strToDate & "';"

                Return Me._objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function GetCellProducedUnits(ByVal iGroup_ID As Integer, _
                                             ByVal iCC_ID As Integer, _
                                             ByVal iCellProduceQCType As Integer, _
                                             ByVal strFrDate As String, _
                                             ByVal strToDate As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT tdevice.Device_ID, QC_WorkDate " & Environment.NewLine
                strSQL &= ", if( BillCode_Rule is null, 0, max(BillCode_Rule) ) as BillCode_Rule " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tqc ON tdevice.Device_ID = tqc.device_id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.cc_id = " & iCC_ID & Environment.NewLine
                strSQL &= "AND QCType_ID = " & iCellProduceQCType & " AND tqc.qcresult_id = 1 AND tqc.QCCredit = 1" & Environment.NewLine
                strSQL &= "AND QC_WorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
                strSQL &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
                strSQL &= "GROUP BY tdevice.Device_ID, tqc.QC_WorkDate " & Environment.NewLine
                'Only refurbish devices
                strSQL &= "HAVING BillCode_Rule NOT IN (1, 2, 8, 9) "
                Return Me._objDataProc.GetDataTable(strSQL).Rows.Count
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        '*****************************************************************
        Public Shared Function GetFQA_AQLReject(ByVal iCC_ID As Integer, _
                                              ByVal strFrDate As String, _
                                              ByVal strToDate As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT Distinct tdevice.Device_ID, QC_WorkDate, QCType_ID  " & Environment.NewLine
                strSql &= ", max(lcodesdetail.Dcode_Critical) as Dcode_Critical " & Environment.NewLine
                'strSql &= ", if( BillCode_Rule is null, 0, max(BillCode_Rule)  ) as BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tqc ON tdevice.Device_ID = tqc.device_id " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail on tqc.DCode_ID = lcodesdetail.Dcode_id " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.cc_id = " & iCC_ID & Environment.NewLine
                strSql &= "AND tqc.QCType_ID IN (2, 4) " & Environment.NewLine
                strSql &= "AND tqc.QCResult_ID = 2 " & Environment.NewLine
                strSql &= "AND tqc.QC_WorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
                strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID, tqc.QC_WorkDate, QCType_ID " & Environment.NewLine
                ''Only refurbish devices
                'strSql &= "HAVING BillCode_Rule NOT IN (1, 2, 8, 9) "
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                Return dt

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

        '*****************************************************************
        Public Shared Function GetTotalFallOutUnits(ByVal iCC_ID As Integer, _
                                            ByVal iGroupID As Integer, _
                                            ByVal strFrDate As String, _
                                            ByVal strToDate As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                If iGroupID = 1 Then
                    strSql = "SELECT DISTINCT tdevice.Device_ID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.cc_id = " & iCC_ID & Environment.NewLine
                    strSql &= "AND tdevice.Device_ShipWorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
                    strSql &= "AND tdevice.Ship_ID = 9999919 " & Environment.NewLine
                    strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
                Else
                    strSql = "SELECT DISTINCT tdevice.Device_ID, max(lbillcodes.BillCode_Rule) as BillCode_Rule " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.cc_id = " & iCC_ID & Environment.NewLine
                    strSql &= "AND Date_Rec Between '" & strFrDate & "' AND '" & strToDate & "'" & Environment.NewLine
                    strSql &= "GROUP BY tdevice.Device_ID " & Environment.NewLine
                    strSql &= "HAVING BillCode_Rule in (1,2,8,9) " & Environment.NewLine
                End If
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                Return dt.Rows.Count

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

        '*****************************************************************
        Public Shared Function GetShipGoodUnits(ByVal iGroupID As Integer, _
                                            ByVal strFrDate As String, _
                                            ByVal strToDate As String, _
                                            Optional ByVal iCC_ID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                'If iGroupID = 1 Then
                '    strSql = "SELECT DISTINCT tdevice.Device_ID " & Environment.NewLine
                '    strSql &= "FROM tdevice " & Environment.NewLine
                '    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                '    strSql &= "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                '    strSql &= "WHERE tdevice.Device_ShipWorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
                '    strSql &= "AND tdevice.Ship_ID <> 9999919 " & Environment.NewLine
                '    strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
                '    strSql &= "AND tcostcenter.group_id = 1 " & Environment.NewLine
                '    If iCC_ID > 0 Then
                '        strSql &= "AND tdevice.cc_id = " & iCC_ID.ToString
                '    End If
                'Else
                strSql = "SELECT DISTINCT tdevice.Device_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ShipWorkDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
                strSql &= "AND tpallett.Pallet_ShipType not in (1,2,8,9) " & Environment.NewLine
                If iGroupID = 134 Then strSql &= "AND pallett_name like '%REF%'" & Environment.NewLine
                strSql &= "AND tcostcenter.group_id = " & iGroupID & Environment.NewLine
                If iCC_ID > 0 Then
                    strSql &= "AND tdevice.cc_id = " & iCC_ID.ToString
                End If
                'End If
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                Return dt.Rows.Count

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

        '*****************************************************************
        Public Shared Function GetTotalGrpHrs(ByVal iGroupID As Integer, _
                                            ByVal strFrDate As String, _
                                            ByVal strToDate As String) As Double
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Const strNullDateFormat As String = "{0} IS NULL OR LENGTH(TRIM({0})) = 0 OR {0} = '0000-00-00 00:00:00' "

            Try
                strSql = "SELECT (SUM(HOUR((CASE WHEN " & String.Format(strNullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - HOUR(InTime)) * 3600 + SUM(MINUTE((CASE WHEN " & String.Format(strNullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - MINUTE(InTime)) * 60 + SUM(SECOND((CASE WHEN " & String.Format(strNullDateFormat, "OutTime") & " THEN NOW() ELSE OutTime END)) - SECOND(InTime))) / 3600 AS TotalHours" & Environment.NewLine
                strSql &= "FROM production.tpunch " & Environment.NewLine
                strSql &= "INNER JOIN tcostcenter On tpunch.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "WHERE tcostcenter.group_id = " & iGroupID.ToString & Environment.NewLine
                strSql &= "AND Punch_WkDate >= '" & strFrDate & "' AND Punch_WkDate <= '" & strToDate & "';"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetDateTimeStamp() As String
            Dim strSQL As String
            Dim objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSQL = "SELECT DATE_FORMAT(NOW(), '%b %e, %Y@%l:%i %p')"

                Return objDataProc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetShipGoodUnitsSpecialProj(ByVal iGroupID As Integer, _
                                                    ByVal strFrDate As String, _
                                                    ByVal strToDate As String, _
                                                    ByVal iCCID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim iCustID As Integer = 0

            Try
                '*****************************************
                'Bad idea but not too many special project
                'If more then add cc_id into tpallett table
                '*****************************************
                If iGroupID = 82 Then iCustID = 2219

                strSql = "SELECT Sum(Pallett_QTY) as Qty " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Pallett_ShipDate BETWEEN '" & strFrDate & "' AND '" & strToDate & "' " & Environment.NewLine
                strSql &= "AND Pallet_ShipType = 0 " & Environment.NewLine
                strSql &= "AND SpecialInvProject = 1 " & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCustID.ToString

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function CalWeightedAvgUPH(ByRef objDataProc As DBQuery.DataProc, _
                                                 ByVal iWorkAreaID As Integer, _
                                                 ByVal iGroupID As Integer, _
                                                 ByVal iCCID As Integer, _
                                                 ByVal strFrDate As String, _
                                                 ByVal strToDate As String) As DataTable
            Dim strSQL As String
            Dim dt, dtModelIDs, dtAUPH, dtProduceUnits As DataTable
            Dim i As Integer = 0
            Dim drNewRow As DataRow
            Dim strModelIDs, strNoUPHModels As String
            Dim R1 As DataRow
            Dim dblTier1, dblTier2 As Double

            Try
                dblTier1 = 0 : dblTier2 = 0 : strModelIDs = "" : strNoUPHModels = ""
                If iWorkAreaID = 2 Then
                    dtProduceUnits = GetShipGoodUnits(objDataProc, iGroupID, strFrDate, strToDate, iCCID)
                Else
                    'If support then get all units in group
                    dtProduceUnits = GetShipGoodUnits(objDataProc, iGroupID, strFrDate, strToDate, )
                End If

                dtAUPH = GetUPHTemplateDataTable(objDataProc)
                dt = New DataTable()
                dtModelIDs = New DataTable()
                dtModelIDs = dtProduceUnits.Clone

                If dtProduceUnits.Rows.Count > 0 Then
                    For Each R1 In dtProduceUnits.Rows
                        If dtModelIDs.Select("Model_ID = " & R1("Model_ID")).Length = 0 Then
                            drNewRow = dtModelIDs.NewRow
                            drNewRow("Model_ID") = R1("Model_ID")
                            dtModelIDs.Rows.Add(drNewRow)
                            dtModelIDs.AcceptChanges()
                        End If
                    Next R1

                    For Each R1 In dtModelIDs.Rows
                        If strModelIDs.Trim.Length > 0 Then strModelIDs &= ", "
                        strModelIDs &= R1("Model_ID").ToString
                    Next R1

                    '******************************************************
                    'Stop calculate if model's UPH is missing in database
                    '******************************************************
                    strNoUPHModels = GetNoUPHGoalCnt(strModelIDs, iWorkAreaID, iGroupID, objDataProc)
                    If strNoUPHModels.Trim.Length > 0 Then Throw New Exception("The following models missing UPH." & Environment.NewLine & strNoUPHModels)

                    '******************************************************

                    If strModelIDs.Trim.Length > 0 Then dt = GetUPHGoalByModelsWorkArea(objDataProc, strModelIDs, iWorkAreaID, iGroupID)

                    If dt.Rows.Count > 0 Then
                        For Each R1 In dt.Rows
                            If dtProduceUnits.Rows.Count > 0 Then dblTier1 += (CDbl(dtProduceUnits.Select("Model_ID = " & R1("model_id")).Length) / dtProduceUnits.Rows.Count) * R1("gmf_UPH_Tier1")
                            If dtProduceUnits.Rows.Count > 0 Then dblTier2 += (CDbl(dtProduceUnits.Select("Model_ID = " & R1("model_id")).Length) / dtProduceUnits.Rows.Count) * R1("gmf_UPH_Tier2")
                        Next R1
                    End If
                End If
                dtAUPH.Rows(0)("Tier1") = dblTier1
                dtAUPH.Rows(0)("Tier2") = dblTier2

                Return dtAUPH
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                If Not IsNothing(dtProduceUnits) Then
                    dtProduceUnits.Dispose()
                    dtProduceUnits = Nothing
                End If
                If Not IsNothing(dtModelIDs) Then
                    dtModelIDs.Dispose()
                    dtModelIDs = Nothing
                End If
                If Not IsNothing(dtAUPH) Then
                    dtAUPH.Dispose()
                    dtAUPH = Nothing
                End If
            End Try
        End Function

        '*****************************************************************
        Public Shared Function GetNoUPHGoalCnt(ByVal strModelIDs As String, _
                                              ByVal iWorkAreaID As Integer, _
                                              ByVal iGroupID As Integer, _
                                              ByVal objDataProc As DBQuery.DataProc) As String
            Dim strSql, strModels As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strModels = ""
                strSql = "SELECT Model_Desc FROM tmodel " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tgroupmodelfactor ON tmodel.Model_ID = tgroupmodelfactor.Model_ID AND wa_id = " & iWorkAreaID & " AND Group_ID = " & iGroupID & Environment.NewLine
                strSql &= "WHERE group_id = " & iGroupID.ToString & Environment.NewLine
                strSql &= "AND tmodel.model_id in ( " & strModelIDs & ") " & Environment.NewLine
                strSql &= "AND tgroupmodelfactor.Model_ID is null "
                dt = objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strModels.Length > 0 Then strModels &= ", "
                    strModels &= R1("Model_Desc").ToString
                Next R1

                Return strModels
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetUPHTemplateDataTable(ByRef objDataProc As DBQuery.DataProc) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT 0.0 as Tier1, 0.0 as Tier2 limit 1 " & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetUPHGoalByModelsWorkArea(ByRef objDataProc As DBQuery.DataProc, _
                                                   ByVal strModelIDs As String, _
                                                   ByVal iWorkAreaID As Integer, _
                                                   ByVal iGroupID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT * FROM tgroupmodelfactor " & Environment.NewLine
                strSql &= "WHERE group_id = " & iGroupID.ToString & Environment.NewLine
                strSql &= "AND wa_id = " & iWorkAreaID.ToString & Environment.NewLine
                strSql &= "AND model_id in ( " & strModelIDs & ");"
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Shared Function GetShipGoodUnits(ByRef objDataProc As DBQuery.DataProc, _
                                                ByVal iGroupID As Integer, _
                                                ByVal strFrDate As String, _
                                                ByVal strToDate As String, _
                                                Optional ByVal iCC_ID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                If iGroupID = 1 Then
                    strSql = "SELECT Device_ID, Device_ShipWorkDate, Device_ShipWorkDate as DateShip, Model_ID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                    strSql &= "WHERE Device_ShipWorkDate between '" & strFrDate & "'" & Environment.NewLine
                    strSql &= "AND '" & strToDate & "'" & Environment.NewLine
                    strSql &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                    strSql &= "AND (tworkorder.PO_ID is null or tworkorder.PO_ID <> 44) " & Environment.NewLine
                    If iGroupID = 134 Then strSql &= "AND pallett_name like '%REF%'" & Environment.NewLine
                    strSql &= "AND tcostcenter.Group_ID = " & iGroupID & Environment.NewLine
                    If iCC_ID > 0 Then strSql &= "AND tdevice.cc_id = " & iCC_ID & Environment.NewLine
                Else
                    strSql = "SELECT distinct tdevice.Device_ID, Device_ShipWorkDate, Device_ShipWorkDate as DateShip, tdevice.Model_ID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                    strSql &= "WHERE Device_ShipWorkDate between '" & strFrDate & "'" & Environment.NewLine
                    strSql &= "AND '" & strToDate & "'" & Environment.NewLine
                    strSql &= "AND tpallett.Pallet_ShipType NOT IN (1, 2, 8, 9,13) " & Environment.NewLine
                    'If iGroupID = 133 Then strSql &= "AND tpallett.Pallet_ShipType=0" & Environment.NewLine
                    If iGroupID = 134 Then strSql &= "AND pallett_name like '%REF%'" & Environment.NewLine
                    strSql &= "AND tcostcenter.group_id = " & iGroupID & Environment.NewLine
                    If iCC_ID > 0 Then strSql &= "AND tdevice.cc_id = " & iCC_ID & Environment.NewLine
                End If

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************

    End Class
End Namespace