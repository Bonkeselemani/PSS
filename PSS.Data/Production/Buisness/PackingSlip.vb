Option Explicit On 

Namespace Buisness
    Public Class PackingSlip
        Private _objDataProc As DBQuery.DataProc

        '****************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '****************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '****************************************************************
        Public Function GetPackingSlipInfoTable(ByVal iCust_ID As Integer) As DataSet
            Dim strSql As String
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim ds As New DataSet()
            Dim iPkNum_Total As Integer = 0

            Try
                strSql = "SELECT lpad(pkslip_id, 6, '000000') as 'PackingNumber' , " & Environment.NewLine
                strSql &= "pkslip_createDt as 'CreationDate', 0 as Quantity " & Environment.NewLine
                'strSql &= "if(pkslip_invoiceDt is null, '', pkslip_invoiceDt) as InvoiceDate " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "WHERE tpackingslip.cust_id = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND pkslip_invoiceDt IS null;"
                dt1 = Me._objDataProc.GetDataTable(strSql)
                dt1.TableName = "tpackingslip"

                For Each R1 In dt1.Rows
                    strSql = "SELECT Model_Desc as Model, " & Environment.NewLine
                    strSql &= "(CASE WHEN A.Cust_ID = 2019 THEN " & Environment.NewLine
                    strSql &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'REFURBISHED' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 1 THEN 'RUR' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 9 THEN 'RTM' " & Environment.NewLine
                    strSql &= "ELSE '' " & Environment.NewLine
                    strSql &= "END ) " & Environment.NewLine
                    strSql &= "WHEN A.Cust_ID = 2219 THEN " & Environment.NewLine
                    strSql &= "(CASE WHEN A.Model_ID = 1083 THEN IF( A.Pallet_ShipType = 0 , 'PASS', 'FAIL') " & Environment.NewLine
                    strSql &= "ELSE (CASE WHEN A.Pallet_ShipType = 0 THEN 'REFURBISHED' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 1 THEN 'RUR' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 8 THEN 'SCRAP' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 9 THEN 'INCOMPLETE' " & Environment.NewLine
                    strSql &= "ELSE '' " & Environment.NewLine
                    strSql &= "END) " & Environment.NewLine
                    strSql &= "END ) " & Environment.NewLine
                    strSql &= "WHEN A.Cust_ID = 2113 THEN " & Environment.NewLine
                    strSql &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'REFURBISHED' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 1 THEN 'BER' " & Environment.NewLine
                    strSql &= "WHEN A.Pallet_ShipType = 10 THEN 'CANCEL' " & Environment.NewLine
                    strSql &= "ELSE '' " & Environment.NewLine
                    strSql &= "END) " & Environment.NewLine
                    strSql &= "ELSE '' " & Environment.NewLine
                    strSql &= "END) AS ShipType, " & Environment.NewLine
                    strSql &= "count(*) as Qty " & Environment.NewLine
                    strSql &= "FROM  tpallett A " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevice C ON A.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                    strSql &= "WHERE A.pkslip_ID = " & R1("PackingNumber") & Environment.NewLine
                    strSql &= "GROUP BY A.Model_ID, A.Pallet_ShipType;"
                    dt2 = Me._objDataProc.GetDataTable(strSql)
                    dt2.TableName = R1("PackingNumber").ToString
                    ds.Tables.Add(dt2)

                    For Each R2 In dt2.Rows
                        iPkNum_Total += R2("Qty")
                    Next R2

                    R1.BeginEdit()
                    R1("Quantity") = iPkNum_Total
                    R1.EndEdit()
                    dt1.AcceptChanges()

                    iPkNum_Total = 0
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                Next R1

                ds.Tables.Add(dt1)

                dt2 = dt1.Clone
                dt2.TableName = "InvoicePackingSlip"
                ds.Tables.Add(dt2)


                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function CreateInvoiceRpt(ByVal dtInvoice As DataTable, _
                                         ByVal strCustName As String) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iRow As Integer = 0

            Dim strPackingNums As String = ""
            Dim iModel_ID As Integer = 0
            Dim iQuantityTotal As Integer = 0
            Dim decLaborTotal As Decimal = 0
            Dim strServerDT As String = Generic.MySQLServerDateTime(1)
            Dim strRptPath As String = "P:\Dept\Customer Service\Invoice Report\" & strCustName & "\"
            Dim strRptName As String = strCustName & Format(CDate(strServerDT), "yyyyMMdd") & "T" & Format(CDate(strServerDT), "hhmmss") & ".xls"

            '*************************************
            'Excel Related variables
            '*************************************
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                For Each R1 In dtInvoice.Rows
                    If strPackingNums = "" Then
                        strPackingNums = R1("PackingNumber")
                    Else
                        strPackingNums &= ", " & R1("PackingNumber")
                    End If
                Next R1

                strSql = "SELECT Model_Desc as Model, B.Model_ID, " & Environment.NewLine
                strSql &= "(CASE WHEN A.Cust_ID = 2019 THEN " & Environment.NewLine
                strSql &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'REFURBISHED' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 1 THEN 'RUR' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 9 THEN 'RTM' " & Environment.NewLine
                strSql &= "ELSE '' " & Environment.NewLine
                strSql &= "END ) " & Environment.NewLine
                strSql &= "WHEN A.Cust_ID = 2219 THEN " & Environment.NewLine
                strSql &= "(CASE WHEN A.Model_ID = 1083 THEN IF( A.Pallet_ShipType = 0 , 'PASS', 'FAIL') " & Environment.NewLine
                strSql &= "ELSE (CASE WHEN A.Pallet_ShipType = 0 THEN 'REFURBISHED' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 1 THEN 'RUR' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 8 THEN 'SCRAP' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 9 THEN 'INCOMPLETE' " & Environment.NewLine
                strSql &= "ELSE '' " & Environment.NewLine
                strSql &= "END) " & Environment.NewLine
                strSql &= "END ) " & Environment.NewLine
                strSql &= "WHEN A.Cust_ID = 2113 THEN " & Environment.NewLine
                strSql &= "(CASE WHEN A.Pallet_ShipType = 0 THEN 'REFURBISHED' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 1 THEN 'BER' " & Environment.NewLine
                strSql &= "WHEN A.Pallet_ShipType = 10 THEN 'CANCEL' " & Environment.NewLine
                strSql &= "ELSE '' " & Environment.NewLine
                strSql &= "END) " & Environment.NewLine
                strSql &= "ELSE '' " & Environment.NewLine
                strSql &= "END) AS ShipType, " & Environment.NewLine
                strSql &= "count(*) as Qty, " & Environment.NewLine
                strSql &= "Sum(Device_LaborCharge) as Labor " & Environment.NewLine
                strSql &= "FROM  tpallett A " & Environment.NewLine
                strSql &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice C ON A.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE A.pkslip_ID IN ( " & strPackingNums & " ) " & Environment.NewLine
                strSql &= "GROUP BY A.Model_ID, A.Pallet_ShipType " & Environment.NewLine
                strSql &= "ORDER BY A.Model_ID, A.Pallet_ShipType;"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then Exit Function

                iRow = 1

                '**************************************************
                'Instantiate the excel related objects
                '**************************************************
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                '**************************************************
                'Set Page orientation
                '**************************************************
                objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape
                '**************************************************
                'Set File Visible
                '**************************************************
                objExcel.Application.Visible = False            'Make excel invisible to user
                '*****************************************
                'Write Report Title
                '*****************************************
                objExcel.Application.Cells(iRow, 1).Value = strCustName

                objSheet.Range("A" & iRow & ":" & "A" & iRow).Select()
                With objExcel.Selection
                    .NumberFormat = "@"
                    .WrapText = False
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 3    'Red color
                    .MergeCells = True
                End With
                objSheet.Range("A" & iRow & ":" & "A" & iRow).Font.Size = 27
                objSheet.Range("A" & iRow & ":" & "A" & iRow).Font.FontStyle = "Bold"
                objSheet.Range("A" & iRow & ":" & "A" & iRow).Font.Name = "Arial"

                iRow += 2

                objSheet.Range("A" & iRow & ":" & "A" & iRow).Select()
                With objExcel.Selection
                    .NumberFormat = "@"
                    .WrapText = False
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .MergeCells = True
                End With
                objExcel.Application.Cells(iRow, 1).Value = "Date: " & Format(CDate(strServerDT), "MM/dd/yyyy hh:mm:ss")

                iRow += 2

                objExcel.Application.Cells(iRow, 1).Value = dt1.Rows(0)("Model").ToString
                objSheet.Range("A" & iRow & ":A" & iRow).Select()
                objExcel.Selection.HorizontalAlignment = Excel.Constants.xlLeft
                objExcel.Selection.Font.ColorIndex = 5    'Blue color


                objExcel.Application.Cells(iRow, 2).Value = "Quantity"
                objExcel.Application.Cells(iRow, 3).Value = "Labor"
                objSheet.Range("B" & iRow & ":C" & iRow).Select()
                objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Range("A" & iRow & ":" & "C" & iRow).Select()
                objExcel.Selection.font.bold = True
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone

                iRow += 1
                iModel_ID = dt1.Rows(0)("Model_ID")

                For Each R1 In dt1.Rows

                    If iModel_ID <> R1("Model_ID") Then
                        objExcel.Application.Cells(iRow, 1).Value = "Total"
                        objSheet.Range("A" & iRow & ":A" & iRow).Select()
                        objExcel.Selection.HorizontalAlignment = Excel.Constants.xlRight

                        objExcel.Application.Cells(iRow, 2).Value = iQuantityTotal.ToString
                        objSheet.Range("B" & iRow & ":B" & iRow).Select()
                        objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter

                        objExcel.Application.Cells(iRow, 3).Value = decLaborTotal.ToString
                        objSheet.Range("C" & iRow & ":C" & iRow).Select()
                        objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter
                        objExcel.Selection.Style = "Currency"

                        objSheet.Range("A" & iRow & ":" & "C" & iRow).Select()
                        objExcel.Selection.font.bold = True
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone

                        '**********************************************************
                        iRow += 2
                        objExcel.Application.Cells(iRow, 1).Value = R1("Model").ToString
                        objSheet.Range("A" & iRow & ":A" & iRow).Select()
                        objExcel.Selection.HorizontalAlignment = Excel.Constants.xlLeft
                        objExcel.Selection.Font.ColorIndex = 5    'Blue color

                        objExcel.Application.Cells(iRow, 2).Value = "Quantity"
                        objExcel.Application.Cells(iRow, 3).Value = "Labor"
                        objSheet.Range("B" & iRow & ":C" & iRow).Select()
                        objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter

                        objSheet.Range("A" & iRow & ":" & "C" & iRow).Select()
                        objExcel.Selection.font.bold = True
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone

                        iRow += 1
                        iQuantityTotal = 0
                        decLaborTotal = 0
                    End If

                    objExcel.Application.Cells(iRow, 1).Value = R1("ShipType")
                    objSheet.Range("A" & iRow & ":A" & iRow).Select()
                    objExcel.Selection.HorizontalAlignment = Excel.Constants.xlLeft

                    objExcel.Application.Cells(iRow, 2).Value = R1("Qty")
                    objSheet.Range("B" & iRow & ":B" & iRow).Select()
                    objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter

                    objExcel.Application.Cells(iRow, 3).Value = R1("Labor")
                    objSheet.Range("C" & iRow & ":C" & iRow).Select()
                    objExcel.Selection.Style = "Currency"

                    iQuantityTotal += R1("Qty")
                    decLaborTotal += R1("Labor")
                    iRow += 1
                    iModel_ID = R1("Model_ID")

                Next R1

                objExcel.Application.Cells(iRow, 1).Value = "Total"
                objSheet.Range("A" & iRow & ":A" & iRow).Select()
                objExcel.Selection.HorizontalAlignment = Excel.Constants.xlRight

                objExcel.Application.Cells(iRow, 2).Value = iQuantityTotal.ToString
                objSheet.Range("B" & iRow & ":B" & iRow).Select()
                objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter

                objExcel.Application.Cells(iRow, 3).Value = decLaborTotal.ToString
                objSheet.Range("C" & iRow & ":C" & iRow).Select()
                objExcel.Selection.HorizontalAlignment = Excel.Constants.xlCenter
                objExcel.Selection.Style = "Currency"

                objSheet.Range("A" & iRow & ":" & "C" & iRow).Select()
                objExcel.Selection.font.bold = True
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone


                objSheet.Columns("A:A").ColumnWidth = 15
                objSheet.Columns("B:B").ColumnWidth = 14
                objSheet.Columns("C:C").ColumnWidth = 13

                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Save the excel file
                If Len(Dir(strRptPath & strRptName)) > 0 Then
                    Kill(strRptPath & strRptName)
                End If
                objBook.SaveAs(strRptPath & strRptName)

                Return iRow
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                '****************
                'Excel clean up
                '****************
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

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
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


    End Class
End Namespace