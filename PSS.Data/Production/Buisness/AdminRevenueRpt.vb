Option Explicit On 

Imports PSS.Data.Production
Imports System.IO

Namespace Buisness
    Public Class AdminRevenueRpt

        Private _objDataProc As DBQuery.DataProc

        '****************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '****************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            MyBase.Finalize()
        End Sub

        '****************************************************************
        Public Shared Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '****************************************************************
        Private Shared Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '****************************************************************
        Public Function GetAdminRevenueSummaryRptData(ByVal strFromShipWrkDate As String, _
                                                      ByVal strToShipWrkDate As String, _
                                                      ByVal iProd_ID As Integer) As DataTable
            Dim strSql As String
            Dim dtData As DataTable
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                strSql = " SELECT lproduct.Prod_Desc as Product, lgroups.Group_Desc as 'ProdGroup', lparentco.PCo_Name as Company, tshift.Shift_Number as Shift, Count(*) as 'DeviceCount', " & Environment.NewLine
                'strSql = "SELECT concat( lproduct.Prod_Desc , '-', lgroups.Group_Desc , '-', lparentco.PCo_Name ) as 'ProdCompProdGrp',  tshift.Shift_Number as Shift, Count(*) as 'DeviceCount', " & Environment.NewLine
                strSql &= "0.0 as Cost, 0.0 as PartSvc, " & Environment.NewLine
                strSql &= "if(tcustomer.Cust_ID = 2113, Sum(IFNULL(tdevice.Device_LaborCharge_AutoBilled,0.0)), Sum(tdevice.Device_LaborCharge)) AS Labor, " & Environment.NewLine
                strSql &= "0.0 as TotalSales, " & Environment.NewLine
                strSql &= "0.0 as BilledAUP, 0.0 as LaborAUP, 0 as 'RUR-DBR', 0 as RTM, 0 as NER, 0 as Scrap,  "
                strSql &= "sum(tdevice.Device_Reject) AS RepeatRep, sum(tdevice.Device_PSSWrty) AS PSSWrty, sum(tdevice.Device_ManufWrty) AS ManWrty, " & Environment.NewLine
                strSql &= "sum(IFNULL(tascbill.ASCBill_Price, 0)) AS ManChrg, "
                strSql &= "lproduct.Prod_ID, lgroups.Group_ID, tcustomer.Cust_ID, tshift.Shift_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN lparentco ON tcustomer.PCo_ID = lparentco.PCo_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tshift ON tdevice.Shift_ID_Ship = tshift.Shift_ID " & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tworkorder.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN lgroups ON lgroups.Group_ID = tworkorder.Group_ID " & Environment.NewLine
                strSql &= "LEFT JOIN tascbill ON tdevice.Device_ID = tascbill.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ShipWorkDate >= '" & strFromShipWrkDate & "' AND Device_ShipWorkDate <= '" & strToShipWrkDate & "' " & Environment.NewLine
                strSql &= "AND lproduct.Prod_ID IN ( " & iProd_ID & ") " & Environment.NewLine
                strSql &= "GROUP BY lproduct.Prod_ID, lgroups.Group_ID, tcustomer.Cust_ID, tshift.Shift_ID " & Environment.NewLine
                strSql &= "ORDER BY lproduct.Prod_ID, lgroups.Group_ID, tcustomer.Cust_ID, tshift.Shift_ID " & Environment.NewLine
                dtData = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtData.Rows
                    If R1("Cust_ID") = 2113 Then
                        strSql = " SELECT tdevice.Device_ID, " & Environment.NewLine
                        strSql &= "sum(tdevicebill_563.DBill_AvgCost) AS DBill_AvgCost, sum(tdevicebill_563.DBill_InvoiceAmt) AS DBill_InvoiceAmt, " & Environment.NewLine
                        strSql &= "max(lbillcodes.BillCode_Rule) AS BillCode_Rule " & Environment.NewLine
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tdevicebill_563 ON tdevice.Device_ID = tdevicebill_563.Device_ID " & Environment.NewLine
                        strSql &= "INNER JOIN lbillcodes ON tdevicebill_563.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                        strSql &= "WHERE tdevice.Device_ShipWorkDate >= '" & strFromShipWrkDate & "' AND Device_ShipWorkDate <= '" & strToShipWrkDate & "' " & Environment.NewLine
                        strSql &= "AND tworkorder.Prod_ID IN ( " & iProd_ID & ") " & Environment.NewLine
                        strSql &= "AND tworkorder.Group_ID = " & R1("Group_ID") & Environment.NewLine
                        strSql &= "AND tlocation.Cust_ID = " & R1("Cust_ID") & Environment.NewLine
                        strSql &= "AND tdevice.Shift_ID_Ship = " & R1("Shift_ID") & Environment.NewLine
                        strSql &= "GROUP BY tdevice.Device_ID;"
                    Else
                        strSql = " SELECT tdevice.Device_ID, " & Environment.NewLine
                        strSql &= "sum(tdevicebill.DBill_AvgCost) AS DBill_AvgCost, sum(tdevicebill.DBill_InvoiceAmt) AS DBill_InvoiceAmt, " & Environment.NewLine
                        strSql &= "max(lbillcodes.BillCode_Rule) AS BillCode_Rule " & Environment.NewLine
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                        strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                        strSql &= "WHERE tdevice.Device_ShipWorkDate >= '" & strFromShipWrkDate & "' AND Device_ShipWorkDate <= '" & strToShipWrkDate & "' " & Environment.NewLine
                        strSql &= "AND tworkorder.Prod_ID IN ( " & iProd_ID & ") " & Environment.NewLine
                        strSql &= "AND tworkorder.Group_ID = " & R1("Group_ID") & Environment.NewLine
                        strSql &= "AND tlocation.Cust_ID = " & R1("Cust_ID") & Environment.NewLine
                        strSql &= "AND tdevice.Shift_ID_Ship = " & R1("Shift_ID") & Environment.NewLine
                        strSql &= "GROUP BY tdevice.Device_ID;"
                    End If

                    dt1 = Me._objDataProc.GetDataTable(strSql)
                    If dt1.Rows.Count > 0 Then
                        R1.BeginEdit()
                        R1("Cost") = dt1.Compute("Sum(DBill_AvgCost)", "")
                        R1("PartSvc") = dt1.Compute("Sum(DBill_InvoiceAmt)", "")
                        R1("TotalSales") = R1("PartSvc") + R1("Labor")
                        If R1("TotalSales") <> 0 Then
                            R1("BilledAUP") = R1("TotalSales") / R1("DeviceCount")
                        End If
                        If R1("Labor") <> 0 Then
                            R1("LaborAUP") = R1("Labor") / R1("DeviceCount")
                        End If
                        R1("RUR-DBR") = dt1.Select("BillCode_Rule = 1").Length
                        R1("RTM") = dt1.Select("BillCode_Rule = 9").Length
                        R1("NER") = dt1.Select("BillCode_Rule = 2").Length
                        R1("Scrap") = dt1.Select("BillCode_Rule = 8").Length

                        R1.EndEdit()
                        dtData.AcceptChanges()
                    End If

                    Me.DisposeDT(dt1)

                Next R1

                dtData.Columns.Remove("Prod_ID")
                dtData.Columns.Remove("Group_ID")
                dtData.Columns.Remove("Cust_ID")
                dtData.Columns.Remove("Shift_ID")

                ' CreateAdminRevenueSummaryExcelRpt(dtData, "Admin Revenue Summary", strFromShipWrkDate & "-" & strToShipWrkDate)

                Return dtData

            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Function

        '****************************************************************
        Public Sub CreateAdminRevenueSummaryExcelRpt(ByRef dtData As DataTable, _
                                                     ByVal strTitle As String, _
                                                     ByVal strDateRange As String)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1 As DataRow
            Dim iRow As Integer = 1
            Dim iCol As Integer = 0
            Dim dc As DataColumn
            Dim i As Integer = 0
            Dim strProduct As String = ""
            Dim strGroup As String = ""
            Dim strCompany As String = ""
            'Dim booShiftChange As Boolean = False
            'Dim booProdGrpChange As Boolean = False
            'Dim booProdChange As Boolean = False
            Dim strStartCell As String
            Dim strEndCell As String

            Try
                If IsNothing(dtData) Then
                    Exit Sub
                ElseIf dtData.Rows.Count = 0 Then
                    Exit Sub
                End If
                '**************************************************
                'Instantiate the excel related objects
                '**************************************************
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True                 'Make excel invisible to user

                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                '**************************************************
                'Header
                '**************************************************
                objSheet.Range(Chr(65 + CInt((dtData.Columns.Count - 1) / 2)) & (iRow).ToString).FormulaR1C1 = strTitle
                strStartCell = Chr(65 + CInt((dtData.Columns.Count - 1) / 2)) & (iRow).ToString
                strEndCell = strStartCell
                FormatExcel(objExcel, objSheet, strStartCell, strEndCell, , True, False, "@", , 20, 3, , 1, 1)
                iRow += 2

                objSheet.Range(Chr(65 + CInt((dtData.Columns.Count - 1) / 2)) & (iRow).ToString).FormulaR1C1 = strDateRange
                strStartCell = "A" & (iRow).ToString
                strEndCell = Chr(65 + CInt(dtData.Columns.Count - 1)) & iRow
                FormatExcel(objExcel, objSheet, strStartCell, strEndCell, New Boolean() {False, False, False, True, False, False}, True, False, "@", , 14, 5, , 1, 1)
                iRow += 2

                '**************************************************
                'Production plan data
                '**************************************************
                strProduct = dtData.Rows(0)("Product").ToString
                strGroup = dtData.Rows(0)("ProdGroup").ToString
                strCompany = dtData.Rows(0)("Company").ToString

                objSheet.Range("A" & (iRow).ToString).FormulaR1C1 = "Product: " & strProduct
                strStartCell = "A" & (iRow).ToString
                strEndCell = strStartCell
                FormatExcel(objExcel, objSheet, strStartCell, strEndCell, , True, False, "@", , 12, , 37, Excel.Constants.xlCenter, Excel.Constants.xlLeft)

                iRow += 1

                For iCol = 3 To dtData.Columns.Count - 1
                    objSheet.Range(Chr(65 + iCol) & (iRow).ToString).FormulaR1C1 = dtData.Columns(iCol).Caption
                Next iCol

                iRow += 1

                objSheet.Range("B" & (iRow).ToString).FormulaR1C1 = "Group: " & strGroup
                strStartCell = "B" & (iRow).ToString
                strEndCell = Chr(65 + dtData.Columns.Count - 1) & iRow.ToString
                FormatExcel(objExcel, objSheet, strStartCell, strEndCell, , True, False, "@", , 12, , 10, 1, 1)

                iRow += 1

                objSheet.Range("C" & (iRow).ToString).FormulaR1C1 = "Company: " & strCompany
                strStartCell = "C" & (iRow).ToString
                strEndCell = Chr(65 + dtData.Columns.Count - 1) & iRow.ToString
                FormatExcel(objExcel, objSheet, strStartCell, strEndCell, , True, False, "@", , 12, , 34, 1, 1)

                iRow += 1

                For Each R1 In dtData.Rows
                    For iCol = 3 To dtData.Columns.Count - 1
                        objSheet.Range(Chr(65 + iCol) & (iRow).ToString).FormulaR1C1 = R1(iCol)
                    Next iCol
                    iRow += 1

                    If R1("Company") <> strCompany Then
                        objSheet.Range("C" & (iRow).ToString).FormulaR1C1 = "Company Total:"
                        For iCol = 4 To dtData.Columns.Count - 1
                            objSheet.Range(Chr(65 + iCol) & (iRow).ToString).FormulaR1C1 = dtData.Compute("sum([" & dtData.Columns(iCol).Caption & "])", "Product = '" & strProduct & "' AND ProdGroup = '" & strGroup & "' AND Company = '" & strCompany & "'").ToString
                        Next iCol

                        strStartCell = "A" & (iRow).ToString
                        strEndCell = Chr(65 + dtData.Columns.Count - 1) & iRow.ToString
                        FormatExcel(objExcel, objSheet, strStartCell, strEndCell, , True, False, "@", , , , 34, 1, 1)

                        iRow += 1
                    End If
                    If R1("Company") <> strCompany Then
                        objSheet.Range("B" & (iRow).ToString).FormulaR1C1 = "Group Total:"
                        For iCol = 4 To dtData.Columns.Count - 1
                            objSheet.Range(Chr(65 + iCol) & (iRow).ToString).FormulaR1C1 = dtData.Compute("sum([" & dtData.Columns(iCol).Caption & "])", "Product = '" & strProduct & "' AND ProdGroup = '" & strGroup & "'").ToString
                        Next iCol
                        iRow += 1
                    End If
                    If R1("Company") <> strCompany Then
                        objSheet.Range("C" & (iRow).ToString).FormulaR1C1 = "Product Total:"
                        For iCol = 4 To dtData.Columns.Count - 1
                            objSheet.Range(Chr(65 + iCol) & (iRow).ToString).FormulaR1C1 = dtData.Compute("sum([" & dtData.Columns(iCol).Caption & "])", "Product = '" & strProduct & "'").ToString
                        Next iCol
                        iRow += 1
                    End If

                    strProduct = R1("Product").ToString
                    strGroup = R1("ProdGroup").ToString
                    strCompany = R1("Company").ToString

                Next R1

                iRow += 1   'Skip a blank line





                ''*******************************
                ''Write header and data to excel 
                ''*******************************
                'With objSheet
                '    .Range("A1:" & Chr(65 + dtProd.Columns.Count - 1) & (iRow).ToString).Value = arrData
                'End With

                ''*****************************************
                ''format header
                ''*****************************************
                'Me.FormatExcel(objExcel, objSheet, "A1", Chr(65 + dtProd.Columns.Count - 1 - 1) & 1.ToString, True, True, False, "@", "", 12, 5, 37, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
                'If Not IsNothing(dtSpecial) Then
                '    If dtSpecial.Rows.Count > 0 Then
                '        Me.FormatExcel(objExcel, objSheet, "A" & dtProd.Rows.Count + 2 + 3, Chr(65 + dtProd.Columns.Count - 1 - 1) & (dtProd.Rows.Count + 2 + 3).ToString, True, True, False, "@", "", 12, 3, 37, Excel.Constants.xlCenter, Excel.Constants.xlCenter)
                '    End If
                'End If

                ''*****************************************
                ''PRODUCTION PLAN
                ''format Data, write grand total, write formula
                ''*****************************************
                'R1 = Nothing
                'dc = Nothing
                'iCol = 1

                'For Each dc In dtProd.Columns
                '    If dc.Caption <> "MonthlyShip" Then
                '        If dc.Caption = "Model" Then
                '            'write Total
                '            objExcel.Application.Cells(dtProd.Rows.Count + 2, iCol).Value = "Total"

                '            'format
                '            Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & "2", Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2).ToString, True, False, False, "@", "", 11, , , , )

                '        ElseIf dc.Caption = "% of Goal" Or dc.Caption = "Monthly % of Goal" Then
                '            If dc.Caption = "% of Goal" Then
                '                For i = 0 To dtProd.Rows.Count - 1
                '                    R1 = dtProd.Rows(i)
                '                    'write formula
                '                    If R1("Goal") = 0 Then
                '                        objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = "N/A"
                '                    Else
                '                        objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = "=RC[-1]/RC[-5]"
                '                    End If
                '                    R1 = Nothing
                '                Next i
                '            End If

                '            'write Total value
                '            If dtProd.Compute("Sum(Goal)", "") = 0 Then
                '                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = 0
                '            ElseIf dc.Caption = "% of Goal" Then
                '                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=(RC[-1]/RC[-5])"
                '            Else
                '                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=" & dtProd.Compute("Sum(MonthlyShip)", "") & "/RC[-7]"
                '            End If

                '            'format
                '            Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & "2", Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2).ToString, True, False, False, "00.000%", "", 11, , , , )
                '        Else
                '            If dc.Caption = "Workable WIP" Then
                '                For i = 0 To dtProd.Rows.Count - 1
                '                    R1 = dtProd.Rows(i)
                '                    'write formula
                '                    objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = R1("Workable WIP") '"=" & R1("Workable WIP") & "-RC[-1]"
                '                    R1 = Nothing
                '                Next i
                '            ElseIf dc.Caption = "Variance" Then
                '                For i = 0 To dtProd.Rows.Count - 1
                '                    R1 = dtProd.Rows(i)
                '                    'write formula
                '                    objSheet.Range(Chr(65 + iCol - 1) & (i + 2).ToString).FormulaR1C1 = "=RC[-2]-RC[-6]"
                '                    R1 = Nothing
                '                Next i
                '            End If

                '            'write Total value
                '            If dtProd.Rows.Count = 1 Then
                '                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = dtProd.Rows(0)(dc.Caption)
                '            Else
                '                objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=SUM(R[" & (-1 * dtProd.Rows.Count).ToString & "]C:R[-1]C)"
                '            End If

                '            'format
                '            Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & "2", Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2).ToString, True, False, False, "", "", 11, , , , )
                '        End If
                '    End If

                '    iCol += 1
                'Next dc

                ''Format grand total
                'Me.FormatExcel(objExcel, objSheet, "A" & (dtProd.Rows.Count + 2), Chr(65 + dtProd.Columns.Count - 1) & (dtProd.Rows.Count + 2).ToString, False, True, False, "", "", 12, 11, , , )

                ''*****************************************
                ''SPECIAL PROJECT
                ''format Data, write grand total, write formula
                ''*****************************************
                'R1 = Nothing
                'dc = Nothing
                'iCol = 1

                'If Not IsNothing(dtSpecial) Then
                '    If dtSpecial.Rows.Count > 0 Then
                '        'Format 'Special Project' cell
                '        Me.FormatExcel(objExcel, objSheet, "A" & (dtProd.Rows.Count + 2 + 2).ToString, "A" & (dtProd.Rows.Count + 2 + 2).ToString, False, True, False, "@", "", 12, 3, , , )

                '        For Each dc In dtSpecial.Columns
                '            If dc.Caption <> "MonthlyShip" Then
                '                If dc.Caption = "Model" Then
                '                    'write Total
                '                    objExcel.Application.Cells(dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4, iCol).Value = "Total"

                '                    'format
                '                    Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + 3).ToString, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString, True, False, False, "@", "", 11, , , , )

                '                ElseIf dc.Caption = "% of Goal" Or dc.Caption = "Monthly % of Goal" Then
                '                    If dc.Caption = "% of Goal" Then
                '                        For i = 0 To dtSpecial.Rows.Count - 1
                '                            R1 = dtSpecial.Rows(i)
                '                            'write formula
                '                            objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=RC[-1]/RC[-5]"
                '                            R1 = Nothing
                '                        Next i
                '                    End If

                '                    'write Total value
                '                    If dtSpecial.Compute("Sum(Goal)", "") = 0 Then
                '                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = 0
                '                    ElseIf dc.Caption = "% of Goal" Then
                '                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = "=(RC[-1]/RC[-5])"
                '                    Else
                '                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = "=" & dtSpecial.Compute("Sum(MonthlyShip)", "") & "/RC[-7]"
                '                    End If

                '                    'format
                '                    Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + 3).ToString, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString, True, False, False, "00.000%", "", 11, , , , )
                '                Else
                '                    If dc.Caption = "Workable WIP" Then
                '                        For i = 0 To dtSpecial.Rows.Count - 1
                '                            R1 = dtSpecial.Rows(i)

                '                            'write formula
                '                            objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = R1("Workable WIP") '"=" & R1("Workable WIP") & "-RC[-1]"
                '                            R1 = Nothing
                '                        Next i
                '                    ElseIf dc.Caption = "Variance" Then
                '                        For i = 0 To dtSpecial.Rows.Count - 1
                '                            R1 = dtSpecial.Rows(i)
                '                            'write formula
                '                            objSheet.Range(Chr(65 + iCol - 1) & (i + 4 + dtProd.Rows.Count + 2).ToString).FormulaR1C1 = "=RC[-2]-RC[-6]"
                '                            R1 = Nothing
                '                        Next i
                '                    End If

                '                    'write Total value
                '                    If dtSpecial.Rows.Count = 1 Then
                '                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = dtSpecial.Rows(0)(dc.Caption)
                '                    Else
                '                        objSheet.Range(Chr(65 + iCol - 1) & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString).FormulaR1C1 = "=SUM(R[" & (-1 * (dtSpecial.Rows.Count)).ToString & "]C:R[-1]C)"
                '                    End If

                '                    'format
                '                    Me.FormatExcel(objExcel, objSheet, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + 3).ToString, Chr(65 + iCol - 1).ToString & (dtProd.Rows.Count + 2 + dtSpecial.Rows.Count + 4).ToString, True, False, False, "", "", 11, , , , )
                '                End If
                '            End If

                '            iCol += 1
                '        Next dc

                '        'Format grand total
                '        Me.FormatExcel(objExcel, objSheet, "A" & (iRow + 1), Chr(65 + dtProd.Columns.Count - 1) & (iRow + 1).ToString, False, True, False, "", "", 12, 11, , , )
                '    End If
                'End If

                '************************************************
                'set all cell to be auto-fit 
                objSheet.Cells.Select()
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()
                ''*************************************************

                '***********************
                'Print Report
                '***********************
                ' objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                dc = Nothing

                System.Windows.Forms.Application.DoEvents()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*********************************************************************
        Public Sub FormatExcel(ByRef objExcel As Object, _
                                  ByRef objSheet As Object, _
                                  ByVal strStartCell As String, _
                                  ByVal strEndCell As String, _
                                  Optional ByVal booSetBorderArr() As Boolean = Nothing, _
                                  Optional ByVal booBold As Boolean = False, _
                                  Optional ByVal booWrapText As Boolean = False, _
                                  Optional ByVal strNumberFormat As String = "", _
                                  Optional ByVal strFontName As String = "", _
                                  Optional ByVal iFontSize As Integer = 0, _
                                  Optional ByVal iFontColor As Integer = 0, _
                                  Optional ByVal iFillColor As Integer = 0, _
                                  Optional ByVal iHorizontalAlignment As Integer = 0, _
                                  Optional ByVal iVerticalAlignment As Integer = 0)
            Dim strStartCellLetter As String = ""
            Dim strStartCellNumber As String = ""
            Dim strEndCellLetter As String = ""
            Dim strEndCellNumber As String = ""
            Dim i As Integer = 0

            Try

                If strStartCell <> "" And strEndCell <> "" Then
                    objSheet.Range(strStartCell & ":" & strEndCell).Select()

                    With objExcel.Selection
                        If booBold = True Then
                            .font.bold = booBold
                        End If
                        If booWrapText = True Then
                            .WrapText = booWrapText
                        End If
                        If strNumberFormat <> "" Then
                            .NumberFormat = strNumberFormat
                        End If

                        'Set Font
                        If strFontName <> "" Then
                            .Font.Name = strFontName
                        End If
                        If iFontSize > 0 Then
                            .Font.Size = iFontSize
                        End If
                        If iFontColor <> 0 Then
                            .Font.ColorIndex = iFontColor
                        End If
                        If iFillColor <> 0 Then
                            .Interior.ColorIndex = iFillColor
                        End If

                        'set alignment
                        If iHorizontalAlignment <> 0 And iVerticalAlignment <> 0 Then
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                        End If
                    End With

                    '**************************
                    'Set the borders 
                    '**************************
                    If Not IsNothing(booSetBorderArr) Then
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone

                        If booSetBorderArr(0) = True Then
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThin
                                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                            End With
                        End If

                        If booSetBorderArr(1) = True Then
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThin
                                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                            End With
                        End If

                        If booSetBorderArr(2) = True Then
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThin
                                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                            End With
                        End If

                        If booSetBorderArr(3) = True Then
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThin
                                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                            End With
                        End If

                        If strStartCell.Trim.ToUpper <> strEndCell.Trim.ToUpper Then

                            '************************
                            i = strStartCell.Length
                            While i > 0
                                If IsNumeric(Mid(strStartCell.Trim, i, 1)) Then
                                    strStartCellNumber = Mid(strStartCell.Trim, i, 1) & strStartCellNumber
                                Else
                                    strStartCellLetter = Mid(strStartCell.Trim, 1, i)
                                    Exit While
                                End If
                                i -= 1
                            End While

                            i = strEndCell.Length
                            While i > 0
                                If IsNumeric(Mid(strEndCell.Trim, i, 1)) Then
                                    strEndCellNumber = Mid(strEndCell.Trim, i, 1) & strEndCellNumber
                                Else
                                    strEndCellLetter = Mid(strEndCell.Trim, 1, i)
                                    Exit While
                                End If
                                i -= 1
                            End While
                            '************************

                            If booSetBorderArr(4) = True Then
                                If strStartCellLetter.Trim.ToUpper <> strEndCellLetter.Trim.ToUpper Then
                                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                                    End With
                                End If
                            End If

                            If booSetBorderArr(5) = True Then
                                If strStartCellNumber.Trim.ToUpper <> strEndCellNumber.Trim.ToUpper Then
                                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                                    End With
                                End If
                            End If
                           
                        End If 'One cell
                    End If  'Set border
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************
        Public Function GetAdminRevenueDetailRptData(ByVal strFromShipWrkDate As String, _
                                                      ByVal strToShipWrkDate As String, _
                                                      ByVal iProd_ID As Integer) As DataTable
            Dim strSql As String

            Try

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************



    End Class
End Namespace