Option Explicit On 

Imports System.Data.OleDb

Namespace Buisness
    Public Class AutoBill
        Private objMisc As Production.Misc
        Private iUserID As Integer = 0
        Private strWorkDt As String = ""

        '***************************************
        'Properties
        '***************************************
        Public Property UserID() As Integer
            Get
                Return iUserID
            End Get
            Set(ByVal Value As Integer)
                iUserID = Value
            End Set
        End Property
        Public Property WorkDate() As String
            Get
                Return strWorkDt
            End Get
            Set(ByVal Value As String)
                strWorkDt = Value
            End Set
        End Property

        '***************************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        '***************************************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '***************************************************************************
        Public Function AreBillGroupsCreated(ByVal iCust_ID As Integer, _
                                            ByVal iModel_id As Integer, _
                                            ByVal strEnterprise As String) _
                                            As Boolean
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim booVar As Boolean = True

            Try
                'Check if target is created
                strsql = "Select count(*) as cnt " & Environment.NewLine
                strsql &= "from tmodeltarget  " & Environment.NewLine
                strsql &= "where  " & Environment.NewLine
                strsql &= "tmodeltarget.MT_Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                strsql &= "tmodeltarget.MT_Model_ID = " & iModel_id & " and " & Environment.NewLine
                strsql &= "tmodeltarget.MT_Enterprise = '" & strEnterprise & "';"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    booVar = False
                Else
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    'Check if the billgroups are created
                    dt1 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, iModel_id, strEnterprise)

                    If dt1.Rows.Count = 0 Then
                        booVar = False
                    End If
                End If

                Return booVar
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function Create563ReveueReport(ByVal iCust_ID As Integer, _
                                                    ByVal strCustomer As String, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal strFromDt As String, _
                                                    ByVal strToDt As String) As Integer
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim dtConsumedLabor_Model As DataTable
            Dim dtConsumedInvoiceAmt_Model As DataTable
            Dim DecConsumedLaborGrandTotal As Decimal = 0
            Dim DecConsumedInvAmtGrandTotal As Decimal = 0
            Dim DecConsumedGrandTotal As Decimal = 0
            Dim DecQtyGrandTotal As Decimal = 0
            Dim dtAutoBilledLabor_Model As DataTable
            Dim dtAutoBilledInvoiceAmt_Model As DataTable
            Dim DecAutoBilledLaborGrandTotal As Decimal = 0
            Dim DecAutoBilledInvAmtGrandTotal As Decimal = 0
            Dim DecAutoBilledGrandTotal As Decimal = 0
            Dim DecConsumedLabor As Decimal = 0
            Dim DecAutoBilledLabor As Decimal = 0
            'Dim DecTarget As Decimal = 0
            Dim DecConsumedInvAmt As Decimal = 0
            Dim DecAutoBilledInvAmt As Decimal = 0
            Dim DecAutoBilledTotal As Decimal
            Dim DecConsumedTotal As Decimal = 0

            Dim R1, R2 As DataRow
            Dim i As Integer = 0
            Dim strFilePath As String = "c:\Revenue Report 563.xls"

            Try
                '***********************************************
                'Get Consumed Labor
                '***********************************************
                dtConsumedLabor_Model = Me.GetLaborAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 0, )
                '***********************************************
                'Get Consumed Parts Invoice Amt
                '***********************************************
                dtConsumedInvoiceAmt_Model = Me.GetPartsPlusServiceInvoiceAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 0, )
                '***********************************************
                'Get Auto Billed Labor
                '***********************************************
                dtAutoBilledLabor_Model = Me.GetLaborAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 1, )
                '***********************************************
                'Get Auto-billed Parts Invoice Amt
                '***********************************************
                dtAutoBilledInvoiceAmt_Model = Me.GetPartsPlusServiceInvoiceAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 1, )

                If dtConsumedLabor_Model.Rows.Count > 0 Then

                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Consumed Invoice Amount", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Consumed Total", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Auto-billed Labor", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Auto-billed Invoice Amount", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Auto-billed Total", "System.String")

                    'objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Target vs Auto-billed Variance", "System.String")
                    'objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Consumed vs Auto-billed Variance", "System.String")

                    For Each R1 In dtConsumedLabor_Model.Rows
                        'DecTarget = 0
                        DecConsumedLabor = 0
                        DecConsumedInvAmt = 0
                        DecConsumedTotal = 0
                        DecAutoBilledLabor = 0
                        DecAutoBilledInvAmt = 0
                        DecAutoBilledTotal = 0

                        R1.BeginEdit()

                        '*****************************************
                        'Check for NULL values and initialise the Vars.
                        If IsDBNull(R1("Consumed Labor")) Then
                            R1("Consumed Labor") = "0"
                        Else
                            DecConsumedLabor = CDec(R1("Consumed Labor"))
                        End If

                        '*****************************************
                        'Consumed section
                        '*****************************************
                        For Each R2 In dtConsumedInvoiceAmt_Model.Rows
                            If R1("Model_ID") = R2("Model_ID") And Trim(R1("Enterprise")) = Trim(R2("Enterprise")) Then

                                If Not IsDBNull(R2("InvoiceAmt")) Then
                                    DecConsumedInvAmt = R2("InvoiceAmt")
                                    R1("Consumed Invoice Amount") = CDec(R2("InvoiceAmt"))
                                Else
                                    R1("Consumed Invoice Amount") = "0"
                                End If
                                Exit For
                            End If
                        Next R2
                        R2 = Nothing

                        If DecConsumedInvAmt = 0 Then
                            R1("Consumed Invoice Amount") = "0"
                        End If

                        '***********************************************
                        'Consumed Total = Consumed Labor + Consumed Parts Invoice Amt
                        '***********************************************
                        'R1("Consumed Total") = CDec(R1("Consumed Labor")) + DecVar)
                        DecConsumedTotal = DecConsumedLabor + DecConsumedInvAmt
                        R1("Consumed Total") = DecConsumedTotal

                        '*****************************************
                        'Auto-Bill section
                        '*****************************************
                        'Labor
                        For Each R2 In dtAutoBilledLabor_Model.Rows
                            If R1("Model_ID") = R2("Model_ID") And Trim(R1("Enterprise")) = Trim(R2("Enterprise")) Then

                                If Not IsDBNull(R2("Auto-billed Labor")) Then
                                    DecAutoBilledLabor = CDec(R2("Auto-billed Labor"))
                                    R1("Auto-billed Labor") = R2("Auto-billed Labor")
                                Else
                                    R1("Auto-billed Labor") = "0"
                                End If

                                Exit For
                            End If
                        Next R2
                        R2 = Nothing
                        '****************************
                        'Invoice Amt
                        For Each R2 In dtAutoBilledInvoiceAmt_Model.Rows
                            If R1("Model_ID") = R2("Model_ID") And Trim(R1("Enterprise")) = Trim(R2("Enterprise")) Then
                                If Not IsDBNull(R2("InvoiceAmt")) Then
                                    DecAutoBilledInvAmt = CDec(R2("InvoiceAmt"))
                                    R1("Auto-billed Invoice Amount") = R2("InvoiceAmt")
                                Else
                                    R1("Auto-billed Invoice Amount") = "0"
                                End If
                                Exit For
                            End If
                        Next R2
                        R2 = Nothing

                        If DecAutoBilledInvAmt = 0 Then
                            R1("Auto-billed Invoice Amount") = "0"
                        End If

                        '***********************************************
                        'Auto Billed Labor + Auto-billed Parts Invoice Amt
                        '***********************************************
                        DecAutoBilledTotal = DecAutoBilledLabor + DecAutoBilledInvAmt
                        R1("Auto-billed Total") = DecAutoBilledTotal

                        '***********************************************
                        'Calculate variances
                        '***********************************************
                        'R1("Target vs Auto-billed Variance") = (DecAutoBilledTotal - DecTarget) / CInt(R1("Quantity"))
                        'R1("Consumed vs Auto-billed Variance") = (DecAutoBilledTotal - DecConsumedTotal) / CInt(R1("Quantity"))

                        '***********************************************
                        DecConsumedLaborGrandTotal += DecConsumedLabor
                        DecConsumedInvAmtGrandTotal += DecConsumedInvAmt
                        DecConsumedGrandTotal += DecConsumedTotal

                        DecAutoBilledLaborGrandTotal += DecAutoBilledLabor
                        DecAutoBilledInvAmtGrandTotal += DecAutoBilledInvAmt
                        DecAutoBilledGrandTotal += DecAutoBilledTotal
                        DecQtyGrandTotal += R1("Quantity")

                        R1.EndEdit()
                    Next R1

                    dtConsumedLabor_Model.AcceptChanges()

                    '*********************************************
                    'Create Excel Report
                    '*********************************************
                    'Instantiate the excel related objects
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = False                 'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    'set all cells in sheet to text format
                    objSheet.Cells.Select()
                    objExcel.Selection.NumberFormat = "@"

                    '*****************************************
                    'Set column widths
                    '*****************************************
                    objSheet.Columns("A:A").ColumnWidth = 18
                    objSheet.Columns("B:B").ColumnWidth = 11
                    objSheet.Columns("C:C").ColumnWidth = 11.86
                    objSheet.Columns("D:D").ColumnWidth = 16.57
                    objSheet.Columns("E:E").ColumnWidth = 11.57
                    objSheet.Columns("F:F").ColumnWidth = 13.29
                    objSheet.Columns("G:G").ColumnWidth = 16.43
                    objSheet.Columns("H:H").ColumnWidth = 12.71
                    objSheet.Columns("I:I").ColumnWidth = 5.71
                    'objSheet.Columns("J:J").ColumnWidth = 8
                    'objSheet.Columns("K:K").ColumnWidth = 12.29
                    'objSheet.Columns("L:L").ColumnWidth = 12.14

                    '*****************************************
                    'Format Report Title
                    '*****************************************
                    objSheet.Range("A1:G1").Select()
                    With objExcel.Selection
                        .WrapText = False
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.Size = 18
                        .Font.Name = "Verdana"
                        .Font.ColorIndex = 3    'Red
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    objExcel.Application.Cells(1, 1).Value = "563 Revenue Report"

                    '*****************************************
                    'Format Report Sub-header
                    '*****************************************
                    objSheet.Range("A3:G3").Select()
                    objExcel.Selection.WrapText = False
                    objSheet.Range("A4:G4").Select()
                    objExcel.Selection.WrapText = False
                    objSheet.Range("A3:G4").Select()

                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.Size = 11
                        .Font.Name = "Verdana"
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    objExcel.Application.Cells(3, 1).Value = "Customer: " & strCustomer
                    objExcel.Application.Cells(4, 1).Value = "Ship Work Date: " & Format(CDate(strFromDt), "MM/dd/yyyy") & " - " & Format(CDate(strToDt), "MM/dd/yyyy")

                    i = 6
                    '*****************************************
                    'Format Header
                    '*****************************************
                    objSheet.Range("A" & i & ":I" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.Size = 10
                        .Font.Name = "Verdana"
                        .WrapText = True
                    End With
                    '*************************************************
                    'Set Back color to sections of the report
                    '*************************************************
                    objSheet.Range("C" & i & ":E" & i).Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 37
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    objSheet.Range("F" & i & ":H" & i).Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 35
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    '*************************************************
                    'Bold the Total Columns
                    '*************************************************
                    objSheet.Range("E" & i + 1 & ":E" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.font.bold = True
                    objSheet.Range("H" & i + 1 & ":H" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.font.bold = True
                    '*************************************************
                    'Create Header
                    '*************************************************
                    objExcel.Application.Cells(i, 1).Value = "Model"
                    objExcel.Application.Cells(i, 2).Value = "Enterprise"
                    objExcel.Application.Cells(i, 3).Value = "Consumed Labor"
                    objExcel.Application.Cells(i, 4).Value = "Consumed Parts/Services"
                    objExcel.Application.Cells(i, 5).Value = "Consumed Total"
                    objExcel.Application.Cells(i, 6).Value = "563 Labor"
                    objExcel.Application.Cells(i, 7).Value = "563 Parts/Services"
                    objExcel.Application.Cells(i, 8).Value = "563 Total"
                    objExcel.Application.Cells(i, 9).Value = "Unit Qty."
                    'objExcel.Application.Cells(i, 10).Value = "Target"
                    'objExcel.Application.Cells(i, 11).Value = "Target vs Auto-billed Variance by Unit"
                    'objExcel.Application.Cells(i, 12).Value = "Consumed vs Auto-billed Variance by Unit"

                    i += 1
                    '*****************************************
                    'Format column Number format to Currency
                    '*****************************************
                    objSheet.Range("C" & i & ":I" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00"

                    'Change Quantity Column Number format to Number with 0 decimal places
                    objSheet.Columns("I:I").Select()
                    objExcel.Selection.NumberFormat = "#,##0"

                    '*****************************************
                    'set border line(single border)
                    '*****************************************
                    objSheet.Range("A" & i - 1 & ":I" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                        .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
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

                '*****************************************
                'write report data 
                '*****************************************
                For Each R1 In dtConsumedLabor_Model.Rows
                    objExcel.Application.Cells(i, 1).Value = R1("Model")
                    objExcel.Application.Cells(i, 2).Value = R1("Enterprise")
                    objExcel.Application.Cells(i, 3).Value = R1("Consumed Labor")
                    objExcel.Application.Cells(i, 4).Value = R1("Consumed Invoice Amount")
                    objExcel.Application.Cells(i, 5).Value = R1("Consumed Total")
                    objExcel.Application.Cells(i, 6).Value = R1("Auto-billed Labor")
                    objExcel.Application.Cells(i, 7).Value = R1("Auto-billed Invoice Amount")
                    objExcel.Application.Cells(i, 8).Value = R1("Auto-billed Total")
                    objExcel.Application.Cells(i, 9).Value = CInt(R1("Quantity"))
                    'objExcel.Application.Cells(i, 10).Value = R1("Target")
                    'objExcel.Application.Cells(i, 11).Value = R1("Target vs Auto-billed Variance")
                    'objExcel.Application.Cells(i, 12).Value = R1("Consumed vs Auto-billed Variance")
                    i += 1
                Next R1

                '*****************************************
                'Set Back color to sections in total line
                '*****************************************
                objSheet.Range("C" & i & ":E" & i).Select()
                With objExcel.Selection.Interior
                    .ColorIndex = 37
                    .Pattern = Excel.Constants.xlSolid
                End With
                objSheet.Range("F" & i & ":H" & i).Select()
                With objExcel.Selection.Interior
                    .ColorIndex = 35
                    .Pattern = Excel.Constants.xlSolid
                End With

                '*****************************************
                'Set font color to the total line
                '*****************************************
                objSheet.Range("A" & i & ":I" & i).Select()
                With objExcel.Selection
                    .font.bold = True
                    .Font.ColorIndex = 5    'Blue
                End With
                '*****************************************
                'Write Data to excel
                '*****************************************
                objExcel.Application.Cells(i, 2).Value = "TOTAL"
                objExcel.Application.Cells(i, 3).Value = DecConsumedLaborGrandTotal
                objExcel.Application.Cells(i, 4).Value = DecConsumedInvAmtGrandTotal
                objExcel.Application.Cells(i, 5).Value = DecConsumedGrandTotal
                objExcel.Application.Cells(i, 6).Value = DecAutoBilledLaborGrandTotal
                objExcel.Application.Cells(i, 7).Value = DecAutoBilledInvAmtGrandTotal
                objExcel.Application.Cells(i, 8).Value = DecAutoBilledGrandTotal
                objExcel.Application.Cells(i, 9).Value = DecQtyGrandTotal

                '*****************************************
                'delete extra sheet in report
                '*****************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Page setup
                With objSheet.PageSetup
                    .PrintQuality = 600
                    .CenterHorizontally = False
                    .CenterVertically = False
                    .LeftFooter = "&BPSSI Confidential&B"
                    .CenterFooter = "&D"
                    .RightFooter = "Page &P"

                    .LeftMargin = objExcel.Application.InchesToPoints(0.25)
                    .RightMargin = objExcel.Application.InchesToPoints(0)
                    .TopMargin = objExcel.Application.InchesToPoints(0.5)
                    .BottomMargin = objExcel.Application.InchesToPoints(0.5)
                    .HeaderMargin = objExcel.Application.InchesToPoints(0)
                    .FooterMargin = objExcel.Application.InchesToPoints(0)

                    .Orientation = Excel.XlPageOrientation.xlLandscape
                    .Draft = False
                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
                    .FirstPageNumber = Excel.Constants.xlAutomatic
                    .BlackAndWhite = False
                    .Zoom = 100
                    .FitToPagesWide = 1
                    '.FitToPagesTall = 1
                End With

                'Save the excel file
                If Len(Dir(strFilePath)) > 0 Then
                    Kill(strFilePath)
                End If
                objBook.SaveAs(strFilePath)
                '*************************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()

                '*************************************************
                'Re-open Excel File
                objXL = New Excel.Application()
                objXL.Workbooks.Open(strFilePath, ReadOnly:=True)
                objXL.Visible = True
                '*************************************************

                Return dtConsumedLabor_Model.Rows.Count

            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                objGen = Nothing
                If Not IsNothing(dtConsumedLabor_Model) Then
                    dtConsumedLabor_Model.Dispose()
                    dtConsumedLabor_Model = Nothing
                End If
                If Not IsNothing(dtConsumedInvoiceAmt_Model) Then
                    dtConsumedInvoiceAmt_Model.Dispose()
                    dtConsumedInvoiceAmt_Model = Nothing
                End If
                If Not IsNothing(dtAutoBilledLabor_Model) Then
                    dtAutoBilledLabor_Model.Dispose()
                    dtAutoBilledLabor_Model = Nothing
                End If
                If Not IsNothing(dtAutoBilledInvoiceAmt_Model) Then
                    dtAutoBilledInvoiceAmt_Model.Dispose()
                    dtAutoBilledInvoiceAmt_Model = Nothing
                End If
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************************
        Public Function Create563ReveueReportLevel2And3(ByVal iCust_ID As Integer, _
                                                    ByVal strCustomer As String, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal strFromDt As String, _
                                                    ByVal strToDt As String, _
                                                    ByVal iNoSlvg_OR_Level2And3_Flg As Integer) As Integer
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim dtConsumedLabor_Model As DataTable
            Dim dtConsumedInvoiceAmt_Model As DataTable
            Dim DecConsumedLaborGrandTotal As Decimal = 0
            Dim DecConsumedInvAmtGrandTotal As Decimal = 0
            Dim DecConsumedGrandTotal As Decimal = 0
            Dim DecQtyGrandTotal As Decimal = 0
            Dim dtAutoBilledLabor_Model As DataTable
            Dim dtAutoBilledInvoiceAmt_Model As DataTable
            Dim DecAutoBilledLaborGrandTotal As Decimal = 0
            Dim DecAutoBilledInvAmtGrandTotal As Decimal = 0
            Dim DecAutoBilledGrandTotal As Decimal = 0
            Dim DecConsumedLabor As Decimal = 0
            Dim DecAutoBilledLabor As Decimal = 0
            Dim DecTarget As Decimal = 0
            Dim DecBERCap As Decimal = 0
            Dim DecConsumedInvAmt As Decimal = 0
            Dim DecAutoBilledInvAmt As Decimal = 0
            Dim DecAutoBilledTotal As Decimal
            Dim DecConsumedTotal As Decimal = 0

            Dim R1, R2 As DataRow
            Dim i As Integer = 0
            Dim strFilePath As String = ""
            Dim strRptTitle As String = ""
            Dim strDevIDs As String = ""
            Dim strDateRange As String = "Ship Work Date: " & Format(CDate(strFromDt), "MM/dd/yyyy") & " - " & Format(CDate(strToDt), "MM/dd/yyyy")

            Try
                If iNoSlvg_OR_Level2And3_Flg = 1 Then   'No Salvage
                    strFilePath = "c:\RevenueReport563_ExcludeSalvage.xls"
                    strRptTitle = "563 Revenue Report (Exclude Salvage)"
                ElseIf iNoSlvg_OR_Level2And3_Flg = 2 Then   'Labor level 2 and 3
                    strFilePath = "c:\RevenueReport563_LaborLevelGreaterThan1.xls"
                    strRptTitle = "563 Revenue Report (Labor Level > 1)"
                ElseIf iNoSlvg_OR_Level2And3_Flg = 0 Then 'Salvage Only
                    strFilePath = "c:\RevenueReport563_SalvageOnly.xls"
                    strRptTitle = "563 Revenue Report (Salvage Only)"
                End If

                strDevIDs = GetAllDeviceIDsWithLaborLvlsGreaterThanOne(strFromDt, _
                                                                        strToDt, _
                                                                        iCust_ID, _
                                                                        iModel_ID, _
                                                                        iNoSlvg_OR_Level2And3_Flg)

                '***********************************************
                'Get Consumed Labor
                '***********************************************
                dtConsumedLabor_Model = Me.GetLaborAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 0, strDevIDs)
                '***********************************************
                'Get Consumed Parts Invoice Amt
                '***********************************************
                dtConsumedInvoiceAmt_Model = Me.GetPartsPlusServiceInvoiceAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 0, strDevIDs)
                '***********************************************
                'Get Auto Billed Labor
                '***********************************************
                dtAutoBilledLabor_Model = Me.GetLaborAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 1, strDevIDs)
                '***********************************************
                'Get Auto-billed Parts Invoice Amt
                '***********************************************
                dtAutoBilledInvoiceAmt_Model = Me.GetPartsPlusServiceInvoiceAmt(strFromDt, strToDt, iCust_ID, iModel_ID, 1, strDevIDs)

                If dtConsumedLabor_Model.Rows.Count > 0 Then

                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Consumed Invoice Amount", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Consumed Total", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Auto-billed Labor", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Auto-billed Invoice Amount", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "Auto-billed Total", "System.String")

                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "563BillingPerUnit", "System.String")
                    objGen.AddNewColumnToDataTable(dtConsumedLabor_Model, "ConsumedBillingPerUnit", "System.String")

                    For Each R1 In dtConsumedLabor_Model.Rows
                        DecTarget = 0
                        DecBERCap = 0
                        DecConsumedLabor = 0
                        DecConsumedInvAmt = 0
                        DecConsumedTotal = 0
                        DecAutoBilledLabor = 0
                        DecAutoBilledInvAmt = 0
                        DecAutoBilledTotal = 0

                        R1.BeginEdit()

                        '*****************************************
                        'Check for NULL values and initialise the Vars.
                        If IsDBNull(R1("Consumed Labor")) Then
                            R1("Consumed Labor") = "0"
                        Else
                            DecConsumedLabor = CDec(R1("Consumed Labor"))
                        End If
                        '**********************
                        If IsDBNull(R1("Target")) Then
                            R1("Target") = "0"
                        Else
                            DecTarget = CDec(R1("Target"))
                        End If

                        '**********************
                        If IsDBNull(R1("BERCap")) Then
                            R1("BERCap") = "0"
                        Else
                            DecBERCap = CDec(R1("BERCap"))
                        End If

                        '*****************************************
                        'Consumed section
                        '*****************************************
                        For Each R2 In dtConsumedInvoiceAmt_Model.Rows
                            If R1("Model_ID") = R2("Model_ID") And Trim(R1("Enterprise")) = Trim(R2("Enterprise")) Then

                                If Not IsDBNull(R2("InvoiceAmt")) Then
                                    DecConsumedInvAmt = R2("InvoiceAmt")
                                    R1("Consumed Invoice Amount") = CDec(R2("InvoiceAmt"))
                                Else
                                    R1("Consumed Invoice Amount") = "0"
                                End If
                                Exit For
                            End If
                        Next R2
                        R2 = Nothing

                        If DecConsumedInvAmt = 0 Then
                            R1("Consumed Invoice Amount") = "0"
                        End If

                        '***********************************************
                        'Consumed Total = Consumed Labor + Consumed Parts Invoice Amt
                        '***********************************************
                        DecConsumedTotal = DecConsumedLabor + DecConsumedInvAmt
                        R1("Consumed Total") = DecConsumedTotal

                        '*****************************************
                        'Auto-Bill section
                        '*****************************************
                        'Labor
                        For Each R2 In dtAutoBilledLabor_Model.Rows
                            If R1("Model_ID") = R2("Model_ID") And Trim(R1("Enterprise")) = Trim(R2("Enterprise")) Then

                                If Not IsDBNull(R2("Auto-billed Labor")) Then
                                    DecAutoBilledLabor = CDec(R2("Auto-billed Labor"))
                                    R1("Auto-billed Labor") = R2("Auto-billed Labor")
                                Else
                                    R1("Auto-billed Labor") = "0"
                                End If

                                Exit For
                            End If
                        Next R2
                        R2 = Nothing
                        '****************************
                        'Invoice Amt
                        For Each R2 In dtAutoBilledInvoiceAmt_Model.Rows
                            If R1("Model_ID") = R2("Model_ID") And Trim(R1("Enterprise")) = Trim(R2("Enterprise")) Then
                                If Not IsDBNull(R2("InvoiceAmt")) Then
                                    DecAutoBilledInvAmt = CDec(R2("InvoiceAmt"))
                                    R1("Auto-billed Invoice Amount") = R2("InvoiceAmt")
                                Else
                                    R1("Auto-billed Invoice Amount") = "0"
                                End If
                                Exit For
                            End If
                        Next R2
                        R2 = Nothing

                        If DecAutoBilledInvAmt = 0 Then
                            R1("Auto-billed Invoice Amount") = "0"
                        End If

                        '***********************************************
                        'Auto Billed Labor + Auto-billed Parts Invoice Amt
                        '***********************************************
                        DecAutoBilledTotal = DecAutoBilledLabor + DecAutoBilledInvAmt
                        R1("Auto-billed Total") = DecAutoBilledTotal

                        '***********************************************
                        'Calculate Average Numbers
                        '***********************************************
                        R1("563BillingPerUnit") = (DecAutoBilledTotal) / CInt(R1("Quantity"))
                        R1("ConsumedBillingPerUnit") = (DecConsumedTotal) / CInt(R1("Quantity"))

                        '***********************************************
                        DecConsumedLaborGrandTotal += DecConsumedLabor
                        DecConsumedInvAmtGrandTotal += DecConsumedInvAmt
                        DecConsumedGrandTotal += DecConsumedTotal

                        DecAutoBilledLaborGrandTotal += DecAutoBilledLabor
                        DecAutoBilledInvAmtGrandTotal += DecAutoBilledInvAmt
                        DecAutoBilledGrandTotal += DecAutoBilledTotal

                        DecQtyGrandTotal += R1("Quantity")

                        R1.EndEdit()
                    Next R1

                    dtConsumedLabor_Model.AcceptChanges()

                    '*********************************************
                    'Create Excel Report
                    '*********************************************
                    'Instantiate the excel related objects
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = False                 'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    'set all cells in sheet to text format
                    objSheet.Cells.Select()
                    objExcel.Selection.NumberFormat = "@"

                    '*****************************************
                    'Set column widths
                    '*****************************************
                    objSheet.Columns("A:A").ColumnWidth = 18
                    objSheet.Columns("B:B").ColumnWidth = 11
                    objSheet.Columns("C:C").ColumnWidth = 11.86
                    objSheet.Columns("D:D").ColumnWidth = 16.57
                    objSheet.Columns("E:E").ColumnWidth = 11.57
                    objSheet.Columns("F:F").ColumnWidth = 13.29
                    objSheet.Columns("G:G").ColumnWidth = 16.43
                    objSheet.Columns("H:H").ColumnWidth = 12.71
                    objSheet.Columns("I:I").ColumnWidth = 5.71
                    objSheet.Columns("J:J").ColumnWidth = 8
                    objSheet.Columns("K:K").ColumnWidth = 10
                    objSheet.Columns("L:L").ColumnWidth = 12.14
                    objSheet.Columns("M:M").ColumnWidth = 12.14

                    '*****************************************
                    'Format Report Title
                    '*****************************************
                    objSheet.Range("A1:G1").Select()
                    With objExcel.Selection
                        .WrapText = False
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.Size = 18
                        .Font.Name = "Verdana"
                        .Font.ColorIndex = 3    'Red
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    objExcel.Application.Cells(1, 1).Value = strRptTitle

                    '*****************************************
                    'Format Report Sub-header
                    '*****************************************
                    objSheet.Range("A3:G3").Select()
                    objExcel.Selection.WrapText = False
                    objSheet.Range("A4:G4").Select()
                    objExcel.Selection.WrapText = False
                    objSheet.Range("A3:G4").Select()

                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.Size = 11
                        .Font.Name = "Verdana"
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    objExcel.Application.Cells(3, 1).Value = "Customer: " & strCustomer
                    objExcel.Application.Cells(4, 1).Value = strDateRange

                    i = 6
                    '*****************************************
                    'Format Header
                    '*****************************************
                    objSheet.Range("A" & i & ":M" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.Size = 10
                        .Font.Name = "Verdana"
                        .WrapText = True
                    End With
                    '*************************************************
                    'Set Back color to sections of the report
                    '*************************************************
                    objSheet.Range("C" & i & ":E" & i).Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 37
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    objSheet.Range("F" & i & ":H" & i).Select()
                    With objExcel.Selection.Interior
                        .ColorIndex = 35
                        .Pattern = Excel.Constants.xlSolid
                    End With
                    '*************************************************
                    'Bold the Total Columns
                    '*************************************************
                    objSheet.Range("E" & i + 1 & ":E" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.font.bold = True
                    objSheet.Range("H" & i + 1 & ":H" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.font.bold = True
                    '*************************************************
                    'Create Header
                    '*************************************************
                    objExcel.Application.Cells(i, 1).Value = "Model"
                    objExcel.Application.Cells(i, 2).Value = "Enterprise"
                    objExcel.Application.Cells(i, 3).Value = "Consumed Labor"
                    objExcel.Application.Cells(i, 4).Value = "Consumed Parts/Services"
                    objExcel.Application.Cells(i, 5).Value = "Consumed Total"
                    objExcel.Application.Cells(i, 6).Value = "563 Labor"
                    objExcel.Application.Cells(i, 7).Value = "563 Parts/Services"
                    objExcel.Application.Cells(i, 8).Value = "563 Total"
                    objExcel.Application.Cells(i, 9).Value = "Unit Qty."
                    objExcel.Application.Cells(i, 10).Value = "Target"
                    objExcel.Application.Cells(i, 11).Value = "BER-Cap"
                    objExcel.Application.Cells(i, 12).Value = "563-Billing/Unit"
                    objExcel.Application.Cells(i, 13).Value = "Consumed Billing/Unit"

                    i += 1
                    '*****************************************
                    'Format column Number format to Currency
                    '*****************************************
                    objSheet.Range("C" & i & ":M" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00"

                    'Change Quantity Column Number format to Number with 0 decimal places
                    objSheet.Columns("I:I").Select()
                    objExcel.Selection.NumberFormat = "#,##0"

                    '*****************************************
                    'set border line(single border)
                    '*****************************************
                    objSheet.Range("A" & i - 1 & ":M" & i + dtConsumedLabor_Model.Rows.Count).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                        .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
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

                '*****************************************
                'write report data 
                '*****************************************
                For Each R1 In dtConsumedLabor_Model.Rows
                    objExcel.Application.Cells(i, 1).Value = R1("Model")
                    objExcel.Application.Cells(i, 2).Value = R1("Enterprise")
                    objExcel.Application.Cells(i, 3).Value = R1("Consumed Labor")
                    objExcel.Application.Cells(i, 4).Value = R1("Consumed Invoice Amount")
                    objExcel.Application.Cells(i, 5).Value = R1("Consumed Total")
                    objExcel.Application.Cells(i, 6).Value = R1("Auto-billed Labor")
                    objExcel.Application.Cells(i, 7).Value = R1("Auto-billed Invoice Amount")
                    objExcel.Application.Cells(i, 8).Value = R1("Auto-billed Total")
                    objExcel.Application.Cells(i, 9).Value = CInt(R1("Quantity"))
                    objExcel.Application.Cells(i, 10).Value = R1("Target")
                    objExcel.Application.Cells(i, 11).Value = R1("BERCap")
                    objExcel.Application.Cells(i, 12).Value = R1("563BillingPerUnit")
                    objExcel.Application.Cells(i, 13).Value = R1("ConsumedBillingPerUnit")
                    i += 1
                Next R1

                '*****************************************
                'Set Back color to sections in total line
                '*****************************************
                objSheet.Range("C" & i & ":E" & i).Select()
                With objExcel.Selection.Interior
                    .ColorIndex = 37
                    .Pattern = Excel.Constants.xlSolid
                End With
                objSheet.Range("F" & i & ":H" & i).Select()
                With objExcel.Selection.Interior
                    .ColorIndex = 35
                    .Pattern = Excel.Constants.xlSolid
                End With

                '*****************************************
                'Set font color to the total line
                '*****************************************
                objSheet.Range("A" & i & ":M" & i).Select()
                With objExcel.Selection
                    .font.bold = True
                    .Font.ColorIndex = 5    'Blue
                End With
                '*****************************************
                'Write Data to excel
                '*****************************************
                objExcel.Application.Cells(i, 2).Value = "TOTAL"
                objExcel.Application.Cells(i, 3).Value = DecConsumedLaborGrandTotal
                objExcel.Application.Cells(i, 4).Value = DecConsumedInvAmtGrandTotal
                objExcel.Application.Cells(i, 5).Value = DecConsumedGrandTotal
                objExcel.Application.Cells(i, 6).Value = DecAutoBilledLaborGrandTotal
                objExcel.Application.Cells(i, 7).Value = DecAutoBilledInvAmtGrandTotal
                objExcel.Application.Cells(i, 8).Value = DecAutoBilledGrandTotal
                objExcel.Application.Cells(i, 9).Value = DecQtyGrandTotal
                objExcel.Application.Cells(i, 12).Value = DecAutoBilledGrandTotal / DecQtyGrandTotal
                objExcel.Application.Cells(i, 13).Value = DecConsumedGrandTotal / DecQtyGrandTotal

                '*****************************************
                'delete extra sheet in report
                '*****************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Page setup
                With objSheet.PageSetup
                    .PrintQuality = 600
                    .CenterHorizontally = False
                    .CenterVertically = False
                    .LeftFooter = "&BPSSI Confidential&B"
                    .CenterFooter = "&D"
                    .RightFooter = "Page &P"

                    .LeftMargin = objExcel.Application.InchesToPoints(0.25)
                    .RightMargin = objExcel.Application.InchesToPoints(0)
                    .TopMargin = objExcel.Application.InchesToPoints(0.5)
                    .BottomMargin = objExcel.Application.InchesToPoints(0.5)
                    .HeaderMargin = objExcel.Application.InchesToPoints(0)
                    .FooterMargin = objExcel.Application.InchesToPoints(0)

                    .Orientation = Excel.XlPageOrientation.xlLandscape
                    .Draft = False
                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
                    .FirstPageNumber = Excel.Constants.xlAutomatic
                    .BlackAndWhite = False
                    .Zoom = 80
                    .FitToPagesWide = 1
                    '.FitToPagesTall = 1
                End With

                'Save the excel file
                If Len(Dir(strFilePath)) > 0 Then
                    Kill(strFilePath)
                End If
                objBook.SaveAs(strFilePath)
                '*************************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()

                '*************************************************
                'Re-open Excel File
                objXL = New Excel.Application()
                objXL.Workbooks.Open(strFilePath, ReadOnly:=True)
                objXL.Visible = True
                '*************************************************

                Return dtConsumedLabor_Model.Rows.Count

            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                objGen = Nothing
                If Not IsNothing(dtConsumedLabor_Model) Then
                    dtConsumedLabor_Model.Dispose()
                    dtConsumedLabor_Model = Nothing
                End If
                If Not IsNothing(dtConsumedInvoiceAmt_Model) Then
                    dtConsumedInvoiceAmt_Model.Dispose()
                    dtConsumedInvoiceAmt_Model = Nothing
                End If
                If Not IsNothing(dtAutoBilledLabor_Model) Then
                    dtAutoBilledLabor_Model.Dispose()
                    dtAutoBilledLabor_Model = Nothing
                End If
                If Not IsNothing(dtAutoBilledInvoiceAmt_Model) Then
                    dtAutoBilledInvoiceAmt_Model.Dispose()
                    dtAutoBilledInvoiceAmt_Model = Nothing
                End If
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function



        '***************************************************************************
        Private Function GetAllDeviceIDsWithLaborLvlsGreaterThanOne(ByVal strFromDt As String, _
                                            ByVal strToDt As String, _
                                            ByVal iCust_ID As Integer, _
                                            ByVal iModel_ID As Integer, _
                                            ByVal iNoSlvg_OR_Level2And3_Flg As Integer) As String

            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strDevIDs As String = ""

            Try
                If iNoSlvg_OR_Level2And3_Flg = 1 Then
                    '**************************************************************
                    'First get distinct Device IDs with Labor Levels greater than 1
                    '**************************************************************
                    strSql = "Select distinct tdevice.device_id " & Environment.NewLine
                    strSql &= "from tdevice " & Environment.NewLine
                    strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "inner join cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                    strSql &= "where  " & Environment.NewLine
                    strSql &= "Device_ShipWorkDate >= '" & strFromDt & "' and " & Environment.NewLine
                    strSql &= "Device_ShipWorkDate <= '" & strToDt & "' and " & Environment.NewLine
                    strSql &= "tlocation.cust_ID = " & iCust_ID & " and " & Environment.NewLine
                    If iModel_ID > 0 Then
                        strSql &= "tdevice.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                    End If
                    strSql &= "cstincomingdata.isSalvageFlg = 0 " & Environment.NewLine
                    strSql &= "order by device_id;"

                ElseIf iNoSlvg_OR_Level2And3_Flg = 2 Then
                    '**************************************************************
                    'First get distinct Device IDs with Labor Levels greater than 1
                    '**************************************************************
                    strSql = "Select distinct tdevice.device_id " & Environment.NewLine
                    strSql &= "from tdevice " & Environment.NewLine
                    strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "inner join tdevicebill_563 on tdevice.Device_ID = tdevicebill_563.Device_ID " & Environment.NewLine
                    strSql &= "where  " & Environment.NewLine
                    strSql &= "Device_ShipWorkDate >= '" & strFromDt & "' and " & Environment.NewLine
                    strSql &= "Device_ShipWorkDate <= '" & strToDt & "' and " & Environment.NewLine
                    strSql &= "tlocation.cust_ID = " & iCust_ID & " and " & Environment.NewLine
                    If iModel_ID > 0 Then
                        strSql &= "tdevice.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                    End If
                    strSql &= "tdevicebill_563.DBill_Condition  not in (1, 2, 3) " & Environment.NewLine
                    strSql &= "order by device_id;"
                ElseIf iNoSlvg_OR_Level2And3_Flg = 0 Then
                    strSql = "Select distinct tdevice.device_id " & Environment.NewLine
                    strSql &= "from tdevice " & Environment.NewLine
                    strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "inner join cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                    strSql &= "where  " & Environment.NewLine
                    strSql &= "Device_ShipWorkDate >= '" & strFromDt & "' and " & Environment.NewLine
                    strSql &= "Device_ShipWorkDate <= '" & strToDt & "' and " & Environment.NewLine
                    strSql &= "tlocation.cust_ID = " & iCust_ID & " and " & Environment.NewLine
                    If iModel_ID > 0 Then
                        strSql &= "tdevice.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                    End If
                    strSql &= "cstincomingdata.isSalvageFlg = 1 " & Environment.NewLine
                    strSql &= "order by device_id;"
                End If


                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                '**************************************************************
                'Concatenate all Device IDs
                strDevIDs = ""
                For Each R1 In dt1.Rows
                    If Trim(strDevIDs) = "" Then
                        strDevIDs = R1("Device_ID")
                    Else
                        strDevIDs &= ", " & R1("Device_ID")
                    End If
                Next R1

                Return strDevIDs
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetLaborAmt(ByVal strFromDt As String, _
                                            ByVal strToDt As String, _
                                            ByVal iCust_ID As Integer, _
                                            ByVal iModel_ID As Integer, _
                                            ByVal iAutoBill As Integer, _
                                            Optional ByVal strDevIDs As String = "") _
                                            As DataTable

            Dim strSql As String = ""

            Try
                strSql = "select Model_Desc as Model,  " & Environment.NewLine
                strSql &= "tdevice.Model_ID,  " & Environment.NewLine
                strSql &= "cstincomingdata.csin_EnterpriseCode as Enterprise, " & Environment.NewLine
                strSql &= "count(*) as Quantity, " & Environment.NewLine
                strSql &= "tmodeltarget.MT_Target as Target, " & Environment.NewLine
                strSql &= "tmodeltarget.MT_BERCap as BERCap, " & Environment.NewLine

                If iAutoBill = 0 Then
                    strSql &= "sum(Device_LaborCharge) as 'Consumed Labor' " & Environment.NewLine
                Else
                    strSql &= "sum(Device_LaborCharge_AutoBilled) as 'Auto-billed Labor' " & Environment.NewLine
                End If

                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join cstincomingdata on tdevice.device_ID = cstincomingdata.device_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "left outer join tmodeltarget on tlocation.Cust_ID = tmodeltarget.MT_Cust_ID and tmodel.Model_ID = tmodeltarget.MT_Model_ID and cstincomingdata.csin_EnterpriseCode = tmodeltarget.MT_Enterprise " & Environment.NewLine
                strSql &= "where " & Environment.NewLine
                strSql &= " Device_ShipWorkDate >= '" & strFromDt & "'" & Environment.NewLine
                strSql &= " and Device_ShipWorkDate <= '" & strToDt & "'" & Environment.NewLine
                strSql &= " and tlocation.Cust_ID = " & iCust_ID & Environment.NewLine

                'This condition is used only when we get info for Lavel 2 and 3 devices
                If Trim(strDevIDs) <> "" Then
                    strSql &= " and tdevice.device_id in (" & strDevIDs & ") " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strSql &= " and tdevice.Model_ID = " & iModel_ID & Environment.NewLine
                End If

                strSql &= " group by tdevice.Model_ID, cstincomingdata.csin_EnterpriseCode " & Environment.NewLine
                strSql &= " order by Model, cstincomingdata.csin_EnterpriseCode;"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetPartsPlusServiceInvoiceAmt(ByVal strFromDt As String, _
                                                    ByVal strToDt As String, _
                                                    ByVal iCust_ID As Integer, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal iAutoBill As Integer, _
                                                    Optional ByVal strDevIDs As String = "") _
                                                    As DataTable

            Dim strSql As String = ""

            Try
                strSql = "select sum(DBill_InvoiceAmt) as InvoiceAmt , tdevice.Model_ID, cstincomingdata.csin_EnterpriseCode as Enterprise " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join cstincomingdata on tdevice.device_ID = cstincomingdata.device_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                If iAutoBill = 0 Then
                    strSql &= "inner join tdevicebill on tdevice.device_id = tdevicebill.Device_ID " & Environment.NewLine
                Else
                    strSql &= "inner join tdevicebill_563 on tdevice.device_id = tdevicebill_563.Device_ID " & Environment.NewLine
                End If

                strSql &= "where " & Environment.NewLine
                strSql &= " Device_ShipWorkDate >= '" & strFromDt & "'" & Environment.NewLine
                strSql &= " and Device_ShipWorkDate <= '" & strToDt & "'" & Environment.NewLine
                strSql &= " and tlocation.Cust_ID = " & iCust_ID & Environment.NewLine

                'This condition is used only when we get info for Lavel 2 and 3 devices
                If Trim(strDevIDs) <> "" Then
                    strSql &= " and tdevice.device_id in (" & strDevIDs & ") " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strSql &= " and tdevice.Model_ID = " & iModel_ID & Environment.NewLine
                End If

                strSql &= " group by tdevice.Model_ID, cstincomingdata.csin_EnterpriseCode;"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        'Private Function GetDistinctModelsShippedForWorkDates(ByVal strFromDt As String, _
        '                                                    ByVal strToDt As String, _
        '                                                    ByVal iModel_ID As Integer, _
        '                                                    ByVal iCust_ID As Integer) _
        '                                                    As DataTable
        '    Dim strsql As String = ""

        '    Try
        '        strsql = "Select distinct Model_ID " & Environment.NewLine
        '        strsql &= "from  tdevice " & Environment.NewLine
        '        strsql &= "inner join tlocation on tdevice.Loc_ID = tlocation.loc_id " & Environment.NewLine
        '        strsql &= "where " & Environment.NewLine
        '        strsql &= " Device_ShipWorkDate >= '" & strFromDt & "'" & Environment.NewLine
        '        strsql &= " and Device_ShipWorkDate <= '" & strToDt & "'" & Environment.NewLine
        '        strsql &= " and model_id = " & iModel_ID & Environment.NewLine
        '        strsql &= " and tlocation.Cust_ID = " & iCust_ID & ";"
        '        objMisc._SQL = strsql
        '        Return objMisc.GetDataTable

        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Function

        '***************************************************************************
        '''Public Function BrightpointSpecialBilling(ByVal strBeginDt As String, _
        '''                                          ByVal strEndDt As String) _
        '''                                          As Integer
        Public Function BrightpointSpecialBilling(ByVal R1 As DataRow) _
                                                  As Integer
            '''Dim dt1 as DataTable 
            Dim dt2 As DataTable
            '''Dim R1 as DataRow
            Dim R2 As DataRow
            Dim strsql As String = ""
            Const iLoc_ID As Integer = 2636      'Brightpoint Location ID
            Const iCust_ID As Integer = 2113     'Brightpoint customer id
            Dim strRndBillGroup As String = ""
            Dim boovar As Boolean = False
            Dim iRowIndex As Integer = 1
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strServerDateTime As String = ""
            Dim RDevice As DataRow
            Dim strFP As String = "P:\Dept\Cellstar\Log\AB\Random Billgroups.txt"
            Dim decConsumedTotal As Decimal = 0
            Dim decTarget As Decimal = 0
            Dim iMaxLaborLevelForDevice As Integer = 0
            Dim booBillGroupsCreated As Boolean = False
            Dim iModelBillLevel As Integer = 0
            Dim decBillGroupTotal As Decimal = 0
            Dim decBERCap As Decimal = 0

            Try
                strServerDateTime = objGen.MySQLServerDateTime(1)

                '**************************************************
                'OPen text file to append
                'If Len(Dir(strFP)) > 0 Then
                '    Kill(strFP)
                'End If
                FileOpen(1, strFP, OpenMode.Append)   'Open TXT file
                '**************************************************

                '''''//Move this section to frmAdminCellstar
                ''''***************************************************
                ''''Check if all billcodes in bill groups existed in tpsmap
                ''''  or if it is inactive then turn it to inactive
                ''''//*************************************************
                '''Me.UpdateStatusOfBillcodeInBillGrp()

                '***************************************************
                'Check if all models shipped have bill groups created
                '//*************************************************
                'dt1 = Me.GetModelsShippedByLocationByWorkDt(iLoc_ID, strBeginDt, strEndDt)

                'For Each R1 In dt1.Rows
                '    If IsDBNull(R1("csin_EnterpriseCode")) Then
                '        Throw New Exception("No 'Enterprise code' found for '" & Trim(R1("Model_Desc")) & "'.")
                '    End If

                '    dt2 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, R1("Model_ID"), Trim(R1("csin_EnterpriseCode")))

                '    If dt2.Rows.Count = 0 Then
                '        Throw New Exception("No 'Bill Groups' exist for '" & Trim(R1("Model_Desc")) & "' and '" & R1("csin_EnterpriseCode") & "'.")
                '    End If
                'Next R1

                'R1 = Nothing
                'If Not IsNothing(dt1) Then
                '    dt1.Dispose()
                '    dt1 = Nothing
                'End If
                'If Not IsNothing(dt2) Then
                '    dt2.Dispose()
                '    dt2 = Nothing
                'End If

                '''''//Move this section to frmAdminCellstar
                ''''***************************************************
                ''''//Step 1: Get all Brightpoint Shipped Devices today.
                ''''//*************************************************
                '''dt1 = GetDevicesShippedByLocationByWorkDt(iLoc_ID, strBeginDt, strEndDt)
                ''''***************************************************
                ''''//Step 2: Loop through all devices and check if each has atleast one entry in 
                ''''//in the new billing table tdevicebill_563
                ''''//*************************************************
                ''''device loop
                '''For Each R1 In dt1.Rows

                '//***********************************************
                '//Check if the model can be auto billed
                '//***********************************************
                If R1("AutoBill") = 0 Then
                    '//*****************************************
                    'move all parts and services for the device
                    '//*****************************************
                    i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 1, )
                    '*********************************************************
                    'Copy existing regurlar tdevice field values to Auto Billed field values
                    '*********************************************************
                    i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                    '*********************************************************
                Else
                    '//************************************
                    'Check if device is repaired
                    '//************************************
                    boovar = objGen.IsDeviceRepaired(R1("Device_ID"))
                    If boovar = False Then
                        '//************************************
                        'move all parts and services for the device
                        '//************************************
                        i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 2, )
                        '*********************************************************
                        'Copy existing regurlar tdevice field values to Auto Billed field values
                        '*********************************************************
                        i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                        '*********************************************************
                    Else
                        '//***********************************************
                        '//Check if the device is already auto-billed
                        '//***********************************************
                        boovar = False
                        boovar = CheckIfDeviceAutoBilledAlready(R1("Device_ID"))

                        If boovar = False Then      'if the device is not auto billed
                            '//***********************************
                            '//Get Device related info
                            '//***********************************
                            dt2 = GetDeviceInfo(R1("Device_ID"))

                            If dt2.Rows.Count = 0 Then
                                MsgBox("Device info could not be pulled.")
                                Exit Function
                            Else
                                RDevice = dt2.Rows(0)
                                If dt2.Rows.Count > 1 Then
                                    MsgBox("Two rows retrieve for Device_ID: " & R1("Device_ID"))
                                End If
                            End If
                            '//***********************************
                            If Not IsNothing(dt2) Then
                                dt2.Dispose()
                                dt2 = Nothing
                            End If

                            ''**********************************************
                            ''Compare Max labor level in tdevice
                            '' if Max labor level = 1, transfer all parts/services
                            ''  from tdevicebill to tdevicebill_563
                            ''//********************************************
                            'iMaxLaborLevelForDevice = Me.GetMaxLaborLevelForDevice(R1("Device_ID"))
                            'If iMaxLaborLevelForDevice = 1 Then     'Pass through Labor Level 1 stuff
                            boovar = False
                            boovar = Me.HasNoPartBillCode(R1("Device_ID"))
                            If boovar = True Then
                                '//*****************************************
                                'move all parts and services for the device
                                '//*****************************************
                                i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 3, )
                                '*********************************************************
                                'Copy existing regurlar tdevice field values to Auto Billed field values
                                '*********************************************************
                                i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                                '*********************************************************
                                'Else    'Labor Level > 1
                            Else 'device does not have NO PART billcodes

                                '**********************************************
                                'Is device come from Brightpoint
                                '//********************************************
                                If R1("DevFrBP") = 1 Then
                                    'Throw New Exception("No 'Bill Groups' exist for '" & Trim(R1("Model_Desc")) & "' and '" & R1("csin_EnterpriseCode") & "'.")
                                    '//*****************************************
                                    'move all parts and services of the device
                                    '//*****************************************
                                    i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 7, )
                                    '*********************************************************
                                    'Copy existing regurlar tdevice field values to Auto Billed field values
                                    '*********************************************************
                                    i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                                    '*********************************************************
                                Else     'Device not from Brightpoint
                                    '**********************************************
                                    'Are Billgroups created for customer, model and enterprise 
                                    '//********************************************
                                    'dt3 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, R1("Model_ID"), Trim(R1("csin_EnterpriseCode")))
                                    booBillGroupsCreated = Me.AreBillGroupsCreated(iCust_ID, R1("Model_ID"), Trim(R1("Enterprise")))

                                    If booBillGroupsCreated = False Then
                                        'Throw New Exception("No 'Bill Groups' exist for '" & Trim(R1("Model_Desc")) & "' and '" & R1("csin_EnterpriseCode") & "'.")
                                        '//*****************************************
                                        'move all parts and services of the device
                                        '//*****************************************
                                        i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 4, )
                                        '*********************************************************
                                        'Copy existing regurlar tdevice field values to Auto Billed field values
                                        '*********************************************************
                                        i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                                        '*********************************************************
                                    Else
                                        '**********************************************
                                        'Get Model Bill Level for this model
                                        '//********************************************
                                        iModelBillLevel = Me.GetModelBillLevel(iCust_ID, R1("Model_ID"))
                                        If iModelBillLevel = 0 Then
                                            '//*****************************************
                                            'move all parts and services of the device
                                            ' Use the same condition as when billgroup are not created(4)
                                            '//*****************************************
                                            i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 4, )
                                            '*********************************************************
                                            'Copy existing regurlar tdevice field values to Auto Billed field values
                                            '*********************************************************
                                            i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                                            '*********************************************************
                                        Else
                                            '**********************************************
                                            'Compare consumed and target
                                            '//********************************************
                                            decConsumedTotal = Me.GetConsumedTotal(R1("Device_ID"))
                                            decTarget = Me.GetTargetAmount(iCust_ID, R1("Model_ID"), R1("Enterprise"), decBERCap)

                                            '**********************************************
                                            'Randomly select a Bill Group
                                            '//********************************************
                                            'strRndBillGroup = GetRandomBillGroup(iCust_ID, R1("Model_ID"), R1("Enterprise"), iRowIndex)
                                            strRndBillGroup = GetRandomBillGroup(iCust_ID, R1("Model_ID"), R1("Enterprise"))
                                            'iModelBillLevel
                                            '**********************************************
                                            'Write Random bill group to text file
                                            '**********************************************
                                            PrintLine(1, strRndBillGroup)
                                            '**********************************************
                                            'Get Billcodes in Random Bill Group
                                            '//***********************************************
                                            'dt2 = GetBillGroupInfo(iCust_ID, R1("Model_ID"), strRndBillGroup, Trim(R1("Enterprise")))
                                            dt2 = GetBillGroupInfo(iCust_ID, R1("Model_ID"), strRndBillGroup, Trim(R1("Enterprise")), iModelBillLevel)

                                            If decConsumedTotal > decBERCap Then
                                                'Billcode loop
                                                For Each R2 In dt2.Rows
                                                    '//********************************************************************
                                                    '// Bill all Parts from the above selected Bill Group for the device
                                                    '//********************************************************************
                                                    j += Me.AutoBill_Brightpoint(strServerDateTime, RDevice, R2("billcode_id"), R2("bg_id"))
                                                    '//************************************
                                                Next R2

                                                '******************************************
                                                'Lan added on 06/29/2007
                                                ' Bill all sevices from tdevicebill 
                                                '******************************************
                                                i = Me.AutoBillConsumedServices(strServerDateTime, RDevice)
                                                '******************************************
                                            Else
                                                'If Consumed >= target then pass through
                                                If decConsumedTotal >= decTarget Then
                                                    '//*****************************************
                                                    'move all parts and services of the device
                                                    '//*****************************************
                                                    i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 5, )
                                                    '*********************************************************
                                                    'Copy existing regurlar tdevice field values to Auto Billed field values
                                                    '*********************************************************
                                                    i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                                                    '*********************************************************
                                                Else   'If Consumed < target then Auto Bill

                                                    '*************************************************
                                                    'Get total billed amount(labor+parts) of billgroup
                                                    '//***********************************************
                                                    decBillGroupTotal = Me.GetBillGroupTotal(dt2, RDevice)

                                                    If decConsumedTotal > decBillGroupTotal Then
                                                        '//*****************************************
                                                        'move all parts and services of the device
                                                        ' Use the same condition as when billgroup are not created(4)
                                                        '//*****************************************
                                                        i = Me.CopyBillcodesFromTdevicebillToTdevicebill_563(R1("Device_ID"), 6, )
                                                        '*********************************************************
                                                        'Copy existing regurlar tdevice field values to Auto Billed field values
                                                        '*********************************************************
                                                        i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), , , )
                                                        '*********************************************************

                                                    Else    'decConsumedTotal > decBillGroupTotal
                                                        'Billcode loop
                                                        For Each R2 In dt2.Rows
                                                            '//********************************************************************
                                                            '// Bill all Parts from the above selected Bill Group for the device
                                                            '//********************************************************************
                                                            j += Me.AutoBill_Brightpoint(strServerDateTime, RDevice, R2("billcode_id"), R2("bg_id"))
                                                            '//************************************
                                                        Next R2

                                                        '******************************************
                                                        'Lan added on 06/29/2007
                                                        ' Bill all sevices from tdevicebill 
                                                        '******************************************
                                                        i = Me.AutoBillConsumedServices(strServerDateTime, RDevice)
                                                        '******************************************
                                                    End If      'Check if the total consumed higher than total selected billgroup
                                                End If      'Compare consumed and target
                                            End If      'if consumed > BER
                                        End If      'if Model Bill Level is missing in tmodelbilllevel
                                    End If      'Are Billgroups created for customer, model and enterprise 
                                End If       'Device come from Brightpoint
                                'End If      'Compare Max labor level
                            End If      'NO PART
                        End If      'if the device is not auto billed
                    End If      'Check if device is repaired
                End If      '//Check if model of device can be auto billed

                '**************************
                'Reinitialise loop variables
                '//************************
                boovar = False
                strRndBillGroup = ""
                iRowIndex += 1
                j = 0
                decConsumedTotal = 0
                decBillGroupTotal = 0
                decTarget = 0
                iMaxLaborLevelForDevice = 0
                booBillGroupsCreated = False
                iModelBillLevel = 0
                decBERCap = 0

                ''''**************************
                '''Next R1
                ''''***************************************************

                '''Return dt1.Rows.Count

                Return 1
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                Reset()
                objGen = Nothing
                R1 = Nothing
                R2 = Nothing
                '''If Not IsNothing(dt1) Then
                '''    dt1.Dispose()
                '''    dt1 = Nothing
                '''End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Sub UpdateStatusOfBillcodeInBillGrp()
            Dim strSql As String = ""
            Dim strModel_IDs As String = ""
            Dim dt1, dt2 As DataTable
            Dim arrBillCode() As DataRow
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim iUpdCnt As Integer = 0
            Dim iCntActive As Integer = 0

            Try
                strSql = "SELECT DISTINCT bg_model_id, tbillgroup.billcode_id, Model_Desc, lbillcodes.Billcode_Desc" & Environment.NewLine
                strSql &= "FROM tbillgroup " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tbillgroup.bg_model_id = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tbillgroup.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= " WHERE bg_Inactive = 0 " & Environment.NewLine
                strSql &= "ORDER BY bg_model_id;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If strModel_IDs = "" Then
                        strModel_IDs &= R1("bg_model_id")
                    Else
                        strModel_IDs &= ", " & R1("bg_model_id")
                    End If
                Next R1

                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "WHERE Model_ID IN ( " & strModel_IDs & ") " & Environment.NewLine
                strSql &= "ORDER BY Model_ID;"
                Me.objMisc._SQL = strSql
                dt2 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    arrBillCode = dt2.Select("Model_ID = " & R1("bg_model_id") & " AND Billcode_ID = " & R1("billcode_id"))
                    If arrBillCode.Length = 0 Then
                        strSql = "Update tbillgroup " & Environment.NewLine
                        strSql &= "SET bg_Inactive = 1 " & Environment.NewLine
                        strSql &= "WHERE bg_model_id = " & R1("bg_model_id") & Environment.NewLine
                        strSql &= "AND billcode_id = " & R1("billcode_id") & ";"
                        Me.objMisc._SQL = strSql
                        iUpdCnt += Me.objMisc.ExecuteNonQuery()
                    ElseIf arrBillCode.Length = 1 Then
                        If arrBillCode(0)("Inactive") = 1 Then
                            strSql = "Update tbillgroup " & Environment.NewLine
                            strSql &= "SET bg_Inactive = 1 " & Environment.NewLine
                            strSql &= "WHERE bg_model_id = " & R1("bg_model_id") & Environment.NewLine
                            strSql &= "AND billcode_id = " & R1("billcode_id") & ";"
                            Me.objMisc._SQL = strSql
                            iUpdCnt += Me.objMisc.ExecuteNonQuery()
                        End If
                    Else
                        For i = 0 To arrBillCode.Length - 1
                            If arrBillCode(i)("Inactive") = 0 Then
                                iCntActive += 1
                            End If
                        Next i
                        If iCntActive > 1 Then
                            MsgBox("Model " & R1("Model_Desc") & " and Bill code " & R1("Billcode_Desc") & " existed more than one in tpsmap with active state.")
                        End If
                    End If

                    arrBillCode = Nothing
                Next R1

            Catch ex As Exception
                Throw New Exception("Update Status Of Billcode In Bill Group" & ex.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Sub

        '***************************************************************************
        Private Function GetModelBillLevel(ByVal iCust_ID As Integer, _
                                           ByVal iModel_ID As Integer) _
                                           As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim iModelBillLevel As Integer = 0

            Try
                strsql = "select mbl_level from tmodelbilllevel " & Environment.NewLine
                strsql &= "where mbl_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "and mbl_model_id = " & iModel_ID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("mbl_level")) Then
                        iModelBillLevel = dt1.Rows(0)("mbl_level")
                    End If
                End If

                Return iModelBillLevel
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Private Function GetConsumedTotal(ByVal iDevice_ID As Integer) As Decimal
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim decLabor As Decimal = 0
            Dim decInvAmt As Decimal = 0

            Try
                '**********************************
                'Get Labor charge
                '**********************************
                strsql = "select Device_LaborCharge from tdevice where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Device_LaborCharge")) Then
                        decLabor = dt1.Rows(0)("Device_LaborCharge")
                    End If
                End If

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '*********************************************
                'Get part and service amount (invoice amount)
                '*********************************************
                strsql = "select sum(DBill_InvoiceAmt) as InviceAmt from tdevicebill where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("InviceAmt")) Then
                        decInvAmt = dt1.Rows(0)("InviceAmt")
                    End If
                End If

                '******************
                'Total consumed
                '******************
                Return decLabor + decInvAmt

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Private Function GetBillGroupTotal(ByVal dtBillGroup As DataTable, _
                                           ByVal RDevice As DataRow) As Decimal
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim decLabor As Decimal = 0
            Dim decTotalSandardCost As Decimal = 0
            Dim strBillcode_IDs As String = ""
            Dim strLaborLvl_IDs As String = ""

            Try
                '*******************************
                'get billcode_id string
                '*******************************
                For Each R1 In dtBillGroup.Rows
                    If strBillcode_IDs = "" Then
                        strBillcode_IDs &= R1("billcode_id")
                    Else
                        strBillcode_IDs &= ", " & R1("billcode_id")
                    End If
                Next R1

                If strBillcode_IDs <> "" Then
                    '***************************************
                    'get Total Standard cost for billgroup
                    '***************************************
                    strsql = "SELECT sum(PSPrice_StndCost) * 1.1 as TotalSandardCost " & Environment.NewLine
                    strsql &= "FROM tpsmap " & Environment.NewLine
                    strsql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                    strsql &= "WHERE model_id = " & RDevice("Model_ID") & Environment.NewLine
                    strsql &= "AND prod_id = " & RDevice("Prod_ID") & Environment.NewLine
                    strsql &= "AND Inactive = 0 " & Environment.NewLine
                    strsql &= "AND billcode_id in ( " & strBillcode_IDs & "); "
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        If Not IsDBNull(dt1.Rows(0)("TotalSandardCost")) Then
                            decTotalSandardCost = dt1.Rows(0)("TotalSandardCost")
                        End If
                    End If

                    ''***************************************
                    ''get highest labor level of billgroup
                    ''***************************************
                    'R1 = Nothing
                    'If Not IsNothing(dt1) Then
                    '    dt1.Dispose()
                    '    dt1 = Nothing
                    'End If

                    'strsql = "SELECT distinct LaborLvl_ID from tpsmap " & Environment.NewLine
                    'strsql &= "WHERE Model_id = " & RDevice("Model_ID") & Environment.NewLine
                    'strsql &= "AND Prod_ID = " & RDevice("Prod_ID") & Environment.NewLine
                    'strsql &= "AND Inactive = 0 " & Environment.NewLine
                    'strsql &= "AND billcode_id in ( " & strBillcode_IDs & ");"
                    'objMisc._SQL = strsql
                    'dt1 = objMisc.GetDataTable
                    'For Each R1 In dt1.Rows
                    '    If Not IsDBNull(R1("LaborLvl_ID")) Then
                    '        If strLaborLvl_IDs = "" Then
                    '            strLaborLvl_IDs &= R1("LaborLvl_ID")
                    '        Else
                    '            strLaborLvl_IDs &= ", " & R1("LaborLvl_ID")
                    '        End If
                    '    End If
                    'Next R1

                    'Use only Level 1
                    strLaborLvl_IDs = "1"

                    If strLaborLvl_IDs <> "" Then

                        '***************************************
                        'get highest labor charge of billgroup
                        '***************************************
                        R1 = Nothing
                        If Not IsNothing(dt1) Then
                            dt1.Dispose()
                            dt1 = Nothing
                        End If

                        strsql = "SELECT max(laborprc_regprc) as MaxLaborCharge " & Environment.NewLine
                        strsql &= "FROM tdevice " & Environment.NewLine
                        strsql &= "INNER JOIN tmodel  ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tcusttoprice ON tlocation.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                        strsql &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tlaborprc on (If(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) = tlaborprc.prodgrp_id " & Environment.NewLine
                        strsql &= "AND If(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, tcusttoprice.PrcGroup_ID) = tlaborprc.prcgroup_id) " & Environment.NewLine
                        strsql &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
                        strsql &= "WHERE tdevice.device_ID = " & RDevice("Device_ID") & Environment.NewLine
                        strsql &= "AND LaborLvl_ID in( " & strLaborLvl_IDs & ");"
                        objMisc._SQL = strsql
                        dt1 = objMisc.GetDataTable
                        If dt1.Rows.Count > 0 Then
                            If Not IsDBNull(dt1.Rows(0)("MaxLaborCharge")) Then
                                decLabor = dt1.Rows(0)("MaxLaborCharge")
                            End If
                        End If
                    End If
                End If

                Return decLabor + decTotalSandardCost

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtBillGroup) Then
                    dtBillGroup.Dispose()
                    dtBillGroup = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Private Function GetTargetAmount(ByVal iCust_ID As Integer, _
                                         ByVal iModel_ID As Integer, _
                                         ByVal strEnterprise As String, _
                                         ByVal decBERCap As Decimal) As Decimal
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim decTarget As Decimal = 0

            Try
                strsql = "select * from tmodeltarget " & Environment.NewLine
                strsql &= "where MT_Cust_ID = " & iCust_ID & Environment.NewLine
                strsql &= " and MT_Model_ID = " & iModel_ID & Environment.NewLine
                strsql &= " and MT_Enterprise = '" & Trim(strEnterprise) & "';"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("MT_Target")) Then
                        decTarget = dt1.Rows(0)("MT_Target")
                    End If
                    If Not IsDBNull(dt1.Rows(0)("MT_BERCap")) Then
                        decBERCap = dt1.Rows(0)("MT_BERCap")
                    End If
                End If

                Return decTarget
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function CopyBillcodesFromTdevicebillToTdevicebill_563(ByVal idevice_id As Integer, _
                                                                      ByVal iBillCondion As Integer, _
                                                                      Optional ByVal iTransfer_Part_Service As Integer = 0) _
                                                                        As Integer
            Dim strsql As String = ""
            Dim strsql1 As String = ""
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try

                '********************************************
                'Get stuff from tdevicebill
                '********************************************
                strsql = "Select tdevicebill.* from tdevicebill " & Environment.NewLine
                If iTransfer_Part_Service > 0 Then
                    strsql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                End If
                strsql &= "where tdevicebill.device_id = " & idevice_id & " " & Environment.NewLine
                If iTransfer_Part_Service > 0 Then
                    strsql &= " and lbillcodes.BillType_ID = " & iTransfer_Part_Service & " "    'Services or Parts
                End If
                strsql &= ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                '********************************************
                If dt1.Rows.Count = 0 Then
                    Exit Function
                End If
                '********************************************
                For Each R1 In dt1.Rows
                    '**********************************************
                    'Check if billcode already existed then skip it
                    '**********************************************
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                    strsql = "select count(*) as cnt from tdevicebill_563 " & Environment.NewLine
                    strsql &= "where device_id = " & idevice_id & Environment.NewLine
                    strsql &= " and billcode_id = " & R1("BillCode_ID") & ";"
                    objMisc._SQL = strsql
                    dt2 = objMisc.GetDataTable

                    If dt2.Rows(0)("cnt") = 0 Then
                        strsql = ""
                        strsql1 = ""
                        '********************************************
                        'Insert into tdveicbill_563
                        '********************************************
                        strsql = "insert into tdevicebill_563 (DBill_Condition, " & Environment.NewLine

                        If Not IsDBNull(R1("DBill_AvgCost")) Then
                            strsql &= "DBill_AvgCost, " & Environment.NewLine
                            strsql1 &= R1("DBill_AvgCost") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("DBill_StdCost")) Then
                            strsql &= "DBill_StdCost, " & Environment.NewLine
                            strsql1 &= R1("DBill_StdCost") & ", " & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("DBill_InvoiceAmt")) Then
                            strsql &= "DBill_InvoiceAmt, " & Environment.NewLine
                            strsql1 &= R1("DBill_InvoiceAmt") & ", " & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("Device_ID")) Then
                            strsql &= "Device_ID, " & Environment.NewLine
                            strsql1 &= R1("Device_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("BillCode_ID")) Then
                            strsql &= "BillCode_ID, " & Environment.NewLine
                            strsql1 &= R1("BillCode_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Fail_ID")) Then
                            strsql &= "Fail_ID, " & Environment.NewLine
                            strsql1 &= R1("Fail_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Repair_ID")) Then
                            strsql &= "Repair_ID, " & Environment.NewLine
                            strsql1 &= R1("Repair_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Comp_ID")) Then
                            strsql &= "Comp_ID, " & Environment.NewLine
                            strsql1 &= R1("Comp_ID") & ", " & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("User_ID")) Then
                            strsql &= "User_ID, " & Environment.NewLine
                            strsql1 &= R1("User_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Date_Rec")) Then
                            strsql &= "Date_Rec " & Environment.NewLine
                            strsql1 &= "'" & Format(R1("Date_Rec"), "yyyy-MM-dd") & "'" & Environment.NewLine
                        Else
                            strsql &= "Date_Rec " & Environment.NewLine
                            strsql1 &= "'" & Format(Now, "yyyy-MM-dd") & "'" & Environment.NewLine
                        End If

                        strsql &= ") values (" & iBillCondion & ", " & Environment.NewLine
                        strsql1 &= ");"

                        strsql &= strsql1
                        objMisc._SQL = strsql
                        i += objMisc.ExecuteNonQuery
                        '********************************************
                    End If

                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
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

        '***************************************************************************
        'Get all services from tdevicebill that missing in tdevicebill_563 and
        ' and start bill them. This will give tdevicebill and tdevicebill_563 have the same 
        ' service billcodes.
        '***************************************************************************
        Private Function AutoBillConsumedServices(ByVal strServerDateTime As String, _
                                                  ByVal RDevice As DataRow) _
                                                  As Integer
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                '********************************************
                'Get stuff from tdevicebill
                '********************************************
                strsql = "Select tdevicebill.* from tdevicebill " & Environment.NewLine
                strsql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strsql &= "where tdevicebill.device_id = " & RDevice("Device_ID") & " " & Environment.NewLine
                strsql &= " and lbillcodes.BillType_ID = 1;"     '1:Services
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                '********************************************
                If dt1.Rows.Count = 0 Then
                    Exit Function
                End If
                '********************************************
                For Each R1 In dt1.Rows
                    '**********************************************
                    'Check if billcode already existed then skip it
                    '**********************************************
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                    strsql = "select count(*) as cnt from tdevicebill_563 " & Environment.NewLine
                    strsql &= "where device_id = " & RDevice("Device_ID") & Environment.NewLine
                    strsql &= " and billcode_id = " & R1("BillCode_ID") & ";"
                    objMisc._SQL = strsql
                    dt2 = objMisc.GetDataTable

                    '**********************************************
                    'Billcode does not exist then add to tdevicebill_563
                    '**********************************************
                    If dt2.Rows(0)("cnt") = 0 Then
                        i += Me.AutoBill_Brightpoint(strServerDateTime, _
                                                 RDevice, _
                                                 R1("BillCode_ID"), _
                                                 0)     'bg_id
                    End If

                Next R1
                '********************************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
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

        '***************************************************************************
        'Public Function GetBillGroupInfo(ByVal iCust_ID As Integer, _
        '                                ByVal iModel_ID As Integer, _
        '                                ByVal strRndBillGroup As String, _
        '                                ByVal strEnterprise As String) _
        '                                As DataTable
        Public Function GetBillGroupInfo(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer, _
                                        ByVal strRndBillGroup As String, _
                                        ByVal strEnterprise As String, _
                                        ByVal iModelBillLevel As Integer) _
                                        As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select * from tbillgroup " & Environment.NewLine
                strsql &= "where bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "and bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strsql &= "and bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strsql &= "and bg_bill_group = '" & strRndBillGroup & "' " & Environment.NewLine
                strsql &= "and bg_Inactive = 0 " & Environment.NewLine
                strsql &= "and bg_level = " & iModelBillLevel & ";"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '***************************************************************************
        'Public Function GetRandomBillGroup(ByVal iCust_ID As Integer, _
        '                                    ByVal iModel_ID As Integer, _
        '                                    ByVal strEnterprise As String, _
        '                                    Optional ByVal iRowIndex As Integer = 0) _
        '                                    As String
        Public Function GetRandomBillGroup(ByVal iCust_ID As Integer, _
                                           ByVal iModel_ID As Integer, _
                                           ByVal strEnterprise As String) _
                                           As String

            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim iRndNum As Integer = 0
            Dim iLoopCounter As Integer = 1
            Dim iLowerBound As Integer = 1
            Dim iUpperBound As Integer = 0
            Dim strRndBillGroup As String = ""

            Try
                dt1 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, iModel_ID, strEnterprise)

                iUpperBound = dt1.Rows.Count
                iRndNum = CInt(Int((iUpperBound * Rnd()) + iLowerBound))

                '*******************************************************
                'Further randomize
                ''''If iRowIndex Mod 3 = 0 Then     'If the RowIndex id divisible by 3
                ''''    iRndNum = CInt(Int((iUpperBound * Rnd()) + iLowerBound))
                ''''ElseIf iRowIndex Mod 5 = 0 Then 'If the RowIndex id divisible by 5
                ''''    iRndNum = CInt(Int((iUpperBound * Rnd()) + iLowerBound))
                ''''Else
                ''''    ''//Do nothing
                ''''End If

                '*************************************************************
                'Open the file
                'If Len(Dir("C:\RandomNumber.txt")) > 0 Then
                '    Kill("C:\RandomNumber.txt")
                'End If
                'FileOpen(1, "C:\RandomNumber.txt", OpenMode.Append)
                'PrintLine(1, iRndNum)
                'Reset()
                '*************************************************************
                '//Select the Bill group based on the random number generated.
                For Each R1 In dt1.Rows
                    If iRndNum = iLoopCounter Then
                        strRndBillGroup = Trim(R1("bg_bill_group"))
                        Exit For
                    End If

                    iLoopCounter += 1
                Next R1
                '*************************************************************
                Return strRndBillGroup

            Catch ex As Exception
                Throw ex
            Finally
                'Reset()
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetBillGroupsForCustModelEnterprise(ByVal iCust_ID As Integer, _
                                                            ByVal iModel_ID As Integer, _
                                                            ByVal strEnterpriseCode As String) _
                                                            As DataTable
            Dim strsql As String = ""
            Dim objMisc As New Production.Misc()

            Try
                strsql = "Select distinct bg_bill_group from tbillgroup " & Environment.NewLine
                strsql &= "inner join tmodelbilllevel on tmodelbilllevel.mbl_cust_id = tbillgroup.bg_cust_id and tmodelbilllevel.mbl_model_id = tbillgroup.bg_model_id and tmodelbilllevel.mbl_level = tbillgroup.bg_level " & Environment.NewLine
                strsql &= "where bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "and  bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strsql &= "and  bg_enterprise = '" & strEnterpriseCode & "' " & Environment.NewLine
                strsql &= "and bg_inactive = 0;"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetDevicesShippedByLocationByWorkDt(ByVal iLoc_ID As Integer, _
                                                            ByVal strBeginDt As String, _
                                                            ByVal strEndDt As String) _
                                                            As DataTable
            Dim strsql As String = ""

            Try
                '//Get all Brightpoint Shipped Devices today.
                strsql = "SELECT tdevice.*, tmodeltarget.AutoBill, " & Environment.NewLine
                strsql &= "csin_EnterpriseCode as Enterprise, cstincomingdata.cs_DevFrBP as DevFrBP " & Environment.NewLine
                strsql &= "FROM tdevice " & Environment.NewLine
                strsql &= "INNER JOIN cstincomingdata on tdevice.device_id = cstincomingdata.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "INNER JOIN tmodeltarget ON tdevice.Model_ID = tmodeltarget.MT_Model_ID AND tlocation.Cust_ID = tmodeltarget.MT_Cust_ID AND cstincomingdata.csin_EnterpriseCode = tmodeltarget.MT_Enterprise " & Environment.NewLine
                strsql &= "WHERE tdevice.loc_id = " & iLoc_ID & Environment.NewLine
                strsql &= "AND Device_ShipWorkDate >= '" & strBeginDt & "' and  " & Environment.NewLine
                strsql &= "Device_ShipWorkDate <= '" & strEndDt & "'" & Environment.NewLine
                strsql &= "AND tdevice.Device_LaborLevel_AutoBilled is null;"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetModelsShippedByLocationByWorkDt(ByVal iLoc_ID As Integer, _
                                                            ByVal strBeginDt As String, _
                                                            ByVal strEndDt As String) _
                                                            As DataTable
            Dim strsql As String = ""

            Try
                '//Get all Brightpoint Shipped Devices today.
                strsql = "Select distinct tdevice.Model_ID, " & Environment.NewLine
                strsql &= "model_desc, " & Environment.NewLine
                strsql &= "csin_EnterpriseCode " & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join cstincomingdata on tdevice.device_id = cstincomingdata.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "INNER JOIN tmodeltarget ON tdevice.Model_ID = tmodeltarget.MT_Model_ID AND tlocation.Cust_ID = tmodeltarget.MT_Cust_ID AND cstincomingdata.csin_EnterpriseCode = tmodeltarget.MT_Enterprise " & Environment.NewLine
                strsql &= "where tdevice.loc_id = " & iLoc_ID & " and " & Environment.NewLine
                strsql &= "tmodeltarget.AutoBill = 1 and " & Environment.NewLine
                strsql &= "Device_ShipWorkDate >= '" & strBeginDt & "' and " & Environment.NewLine
                strsql &= "Device_ShipWorkDate <= '" & strEndDt & "';"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function CheckIfDeviceAutoBilledAlready(ByVal iDevice_ID As Integer) As Boolean
            Dim dt2 As DataTable
            Dim strsql As String = ""
            Dim booVar As Boolean = False

            Try
                'Check if the device is already auto-billed
                strsql = "Select * from tdevicebill_563 where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                dt2 = objMisc.GetDataTable

                If dt2.Rows.Count > 0 Then
                    booVar = True
                End If

                Return booVar
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetBillCodesPerModelID(ByVal iModel_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc " & Environment.NewLine
                strSql &= "from tpsmap " & Environment.NewLine
                strSql &= "inner join lbillcodes on tpsmap.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "where tpsmap.Model_ID =  " & iModel_id & " " & Environment.NewLine
                strSql &= "and Inactive = 0;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& frmBillGroups
        '***************************************************************************
        Public Function GetBillGroups() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select bg_loadnumber as 'Load Number', " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1 as Customer, " & Environment.NewLine
                strSql &= "tmodel.Model_Desc as Model," & Environment.NewLine
                strSql &= "bg_enterprise as Enterprise," & Environment.NewLine
                strSql &= "tbillgroup.bg_bill_group as BillGroup, " & Environment.NewLine
                strSql &= "tbillgroup.bg_level as BillLevel, " & Environment.NewLine
                strSql &= "concat(tbillgroup.billcode_id, ' - ', lbillcodes.BillCode_Desc) as 'Bill Code', " & Environment.NewLine
                strSql &= "bg_id, bg_cust_id, bg_model_id, tbillgroup.billcode_id  " & Environment.NewLine
                strSql &= "from tbillgroup " & Environment.NewLine
                strSql &= "inner join tcustomer on tbillgroup.bg_cust_id = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "inner join lbillcodes on tbillgroup.billcode_id = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tbillgroup.bg_model_id = tmodel.Model_ID " & Environment.NewLine
                strSql &= "where bg_Inactive = 0 "
                strSql &= "order by 'Load Number', Customer, Model, Enterprise, BillGroup, BillLevel, 'Bill Code' desc;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function UploadBillGroups(ByVal strFilePath As String) As Integer
            Dim strSql As String = ""
            Dim dtExcelData As DataTable
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim objDataset1 As New DataSet()
            Dim strCust_id As String = ""
            Dim strModel_id As String = ""
            Dim strBillGroup As String = ""
            Dim strBillCode_id As String = ""
            Dim strEnterprise As String = ""
            Dim iLoadNumber As Integer = 0
            Dim strBillLevel As String = ""

            Try
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()

                objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$] where [Cust_id] is not null;")

                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(objDataset1)
                objConn.Close()

                dtExcelData = objDataset1.Tables(0)

                i = 2
                '*****************************************
                'Validate excel format and billcodes
                '*****************************************
                For Each R1 In dtExcelData.Rows

                    '********************************************
                    'Check if excel contain incorrect format data
                    '********************************************
                    If Not IsDBNull(R1("Cust_id")) Then
                        strCust_id = Trim(R1("Cust_id"))
                    End If
                    If IsNumeric(strCust_id) = False Then
                        Throw New Exception("'Cust_id' must be numeric format for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("Model_id")) Then
                        strModel_id = Trim(R1("Model_id"))
                    End If
                    If IsNumeric(strModel_id) = False Then
                        Throw New Exception("'Model_id' must be numeric format for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("BillGroup")) Then
                        strBillGroup = UCase(Trim(R1("BillGroup")))
                    End If
                    If strBillGroup = "" Then
                        Throw New Exception("'BillGroup' can not be blank for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("Billcode_ID")) Then
                        strBillCode_id = Trim(R1("Billcode_ID"))
                    End If
                    If IsNumeric(strBillCode_id) = False Then
                        Throw New Exception("'Billcode_ID' must be numeric format for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("Enterprise")) Then
                        strEnterprise = Trim(R1("Enterprise"))
                    End If
                    If strEnterprise = "" Then
                        Throw New Exception("'Enterprise' can not be blank for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("BillLevel")) Then
                        strBillLevel = Trim(R1("BillLevel"))
                    End If
                    If IsNumeric(strBillLevel) = False Then
                        Throw New Exception("'BillLevel' must be numeric format for record number " & i & ".")
                    End If

                    '*****************************************
                    'Check if billcode is an active billcode
                    '*****************************************
                    strSql = "select count(*) as cnt from tpsmap " & Environment.NewLine
                    strSql &= "where model_id = " & R1("Model_id") & " " & Environment.NewLine
                    strSql &= "and billcode_id = " & R1("Billcode_ID") & " " & Environment.NewLine
                    strSql &= "and Inactive = 0;"
                    Me.objMisc._SQL = strSql
                    dt1 = Me.objMisc.GetDataTable

                    If dt1.Rows(0)("cnt") = 0 Then
                        Throw New Exception("For Model '" & R1("Model_id") & "' Billcode ID '" & R1("Billcode_ID") & "' is set to be inactive. Can not use it in Bill Groups.")
                    End If

                    '*********************
                    'Reset variable
                    '*********************
                    strCust_id = ""
                    strModel_id = ""
                    strBillGroup = ""
                    strBillCode_id = ""
                    strEnterprise = ""
                    strBillLevel = ""
                    i += 1
                    'dispose datatable
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '*********************
                Next R1


                '*****************************************
                'Get previous Load Number plus 1
                '*****************************************
                strSql = "select max(bg_loadnumber) + 1 as newLoadNumber from tbillgroup;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("newLoadNumber")) Then
                        iLoadNumber = dt1.Rows(0)("newLoadNumber")
                    End If
                End If

                'dispose datatable
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                i = 0
                '*****************************************
                'loop through excel file to insert
                '*****************************************
                For Each R1 In dtExcelData.Rows

                    If Not IsDBNull(R1("Cust_id")) Then
                        strCust_id = Trim(R1("Cust_id"))
                    End If
                    If Not IsDBNull(R1("Model_id")) Then
                        strModel_id = Trim(R1("Model_id"))
                    End If
                    If Not IsDBNull(R1("BillGroup")) Then
                        strBillGroup = UCase(Trim(R1("BillGroup")))
                    End If
                    If Not IsDBNull(R1("Billcode_ID")) Then
                        strBillCode_id = Trim(R1("Billcode_ID"))
                    End If
                    If Not IsDBNull(R1("Enterprise")) Then
                        strEnterprise = Trim(R1("Enterprise"))
                    End If
                    If Not IsDBNull(R1("BillLevel")) Then
                        strBillLevel = Trim(R1("BillLevel"))
                    End If

                    '***********************************************************
                    'skip entry in excel file if it contains incorrect format
                    '***********************************************************
                    If IsNumeric(strCust_id) = True And _
                       IsNumeric(strModel_id) = True And _
                       IsNumeric(strBillCode_id) = True And _
                       IsNumeric(strBillLevel) = True And _
                       strBillGroup <> "" And _
                       strEnterprise <> "" Then

                        '***************************
                        'Check if billcode exists
                        '***************************
                        strSql = "select * from tbillgroup " & Environment.NewLine
                        strSql &= "where bg_cust_id = " & CInt(strCust_id) & " " & Environment.NewLine
                        strSql &= "and bg_model_id = " & CInt(strModel_id) & " " & Environment.NewLine
                        strSql &= "and bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                        strSql &= "and bg_bill_group = '" & strBillGroup & "' " & Environment.NewLine
                        strSql &= "and billcode_id = " & CInt(strBillCode_id) & " " & Environment.NewLine
                        strSql &= "and bg_level = " & CInt(strBillLevel) & " " & Environment.NewLine
                        strSql &= "and bg_Inactive = 0;"
                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable

                        '********************************
                        'Insert new record in tbillgroup
                        '********************************
                        If dt1.Rows.Count = 0 Then
                            strSql = "INSERT INTO tbillgroup " & Environment.NewLine
                            strSql &= "( " & Environment.NewLine
                            strSql &= "bg_cust_id, " & Environment.NewLine
                            strSql &= "bg_model_id, " & Environment.NewLine
                            strSql &= "bg_enterprise, " & Environment.NewLine
                            strSql &= "bg_bill_group, " & Environment.NewLine
                            strSql &= "billcode_id, " & Environment.NewLine
                            strSql &= "bg_loadnumber, " & Environment.NewLine
                            strSql &= "bg_level " & Environment.NewLine
                            strSql &= ") " & Environment.NewLine
                            strSql &= "VALUES " & Environment.NewLine
                            strSql &= "( " & Environment.NewLine
                            strSql &= CInt(strCust_id) & ", " & Environment.NewLine
                            strSql &= CInt(strModel_id) & ", " & Environment.NewLine
                            strSql &= "'" & strEnterprise & "', " & Environment.NewLine
                            strSql &= "'" & strBillGroup & "', " & Environment.NewLine
                            strSql &= CInt(strBillCode_id) & ", " & Environment.NewLine
                            strSql &= iLoadNumber & ", " & Environment.NewLine
                            strSql &= CInt(strBillLevel) & " " & Environment.NewLine
                            strSql &= ");"
                            Me.objMisc._SQL = strSql
                            i += Me.objMisc.ExecuteNonQuery
                        End If
                        '********************************
                    End If

                    '*********************
                    'Reset variable
                    '*********************
                    strCust_id = ""
                    strModel_id = ""
                    strBillGroup = ""
                    strBillCode_id = ""
                    strEnterprise = ""
                    strBillLevel = ""

                    'dispose datatable
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '*********************
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtExcelData) Then
                    dtExcelData.Dispose()
                    dtExcelData = Nothing
                End If
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing

                Reset()
                If Not IsNothing(objDataset1) Then
                    objDataset1.Dispose()
                    objDataset1 = Nothing
                End If
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If

                'Invoke Garbage Collector
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************************
        Public Function InactivateBillGroupByLoadNo(ByVal iLoadNumber As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "update tbillgroup set bg_Inactive = 1 where bg_loadnumber = " & iLoadNumber & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetBillLevels() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select tcustomer.Cust_Name1 as Customer, tmodel.Model_Desc as Model, mbl_level as LaborLevel, " & Environment.NewLine
                strSql &= "mbl_id, mbl_cust_id, mbl_model_id " & Environment.NewLine
                strSql &= "from tmodelbilllevel " & Environment.NewLine
                strSql &= "inner join tcustomer on tmodelbilllevel.mbl_cust_id = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tmodelbilllevel.mbl_model_id = tmodel.Model_ID;"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function UploadBillLevels(ByVal strFilePath As String) As Integer
            Dim strSql As String = ""
            Dim dtExcelData As DataTable
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim objDataset1 As New DataSet()
            Dim strCust_id As String = ""
            Dim strModel_id As String = ""
            Dim strBillLevel As String = ""

            Try
                '*********************************************
                'Read from excel file
                '*********************************************
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()

                objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$] where [Cust_id] is not null;")

                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(objDataset1)
                objConn.Close()

                dtExcelData = objDataset1.Tables(0)

                '*********************************************
                i = 2
                '*****************************************
                'Validate excel format and billcodes
                '*****************************************
                For Each R1 In dtExcelData.Rows
                    '********************************************
                    'Check if excel contain incorrect format data
                    '********************************************
                    If Not IsDBNull(R1("Cust_id")) Then
                        strCust_id = Trim(R1("Cust_id"))
                    End If
                    If IsNumeric(strCust_id) = False Then
                        Throw New Exception("'Cust_id' must be numeric format for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("Model_id")) Then
                        strModel_id = Trim(R1("Model_id"))
                    End If
                    If IsNumeric(strModel_id) = False Then
                        Throw New Exception("'Model_id' must be numeric format for record number " & i & ".")
                    End If

                    If Not IsDBNull(R1("BillLevel")) Then
                        strBillLevel = Trim(R1("BillLevel"))
                    End If
                    If IsNumeric(strBillLevel) = False Then
                        Throw New Exception("'BillLevel' must be numeric format for record number " & i & ".")
                    End If

                    '*********************
                    'Reset variable
                    '*********************
                    strCust_id = ""
                    strModel_id = ""
                    strBillLevel = ""
                    i += 1
                Next R1


                i = 0
                '*****************************************
                'loop through excel file to insert
                '*****************************************
                For Each R1 In dtExcelData.Rows

                    If Not IsDBNull(R1("Cust_id")) Then
                        strCust_id = Trim(R1("Cust_id"))
                    End If
                    If Not IsDBNull(R1("Model_id")) Then
                        strModel_id = Trim(R1("Model_id"))
                    End If
                    If Not IsDBNull(R1("BillLevel")) Then
                        strBillLevel = Trim(R1("BillLevel"))
                    End If

                    '***********************************************************
                    'skip entry in excel file if it contains incorrect format
                    '***********************************************************
                    If IsNumeric(strCust_id) = True And _
                       IsNumeric(strModel_id) = True And _
                       IsNumeric(strBillLevel) = True Then

                        ''********************************************************
                        ''Check if Labor level for customer and model was existed
                        ''********************************************************
                        'strSql = "select * from tmodelbilllevel " & Environment.NewLine
                        'strSql &= "where mbl_cust_id = " & CInt(strCust_id) & " " & Environment.NewLine
                        'strSql &= "and mbl_model_id = " & CInt(strModel_id) & " " & Environment.NewLine
                        'strSql &= "and mbl_level = " & CInt(strBillLevel) & ";"
                        'Me.objMisc._SQL = strSql
                        'dt1 = Me.objMisc.GetDataTable

                        '********************************
                        'Insert new record in tbillgroup
                        '********************************
                        'If dt1.Rows.Count = 0 Then
                        strSql = "replace into tmodelbilllevel " & Environment.NewLine
                        strSql &= "( " & Environment.NewLine
                        strSql &= "mbl_cust_id, " & Environment.NewLine
                        strSql &= "mbl_model_id, " & Environment.NewLine
                        strSql &= "mbl_level " & Environment.NewLine
                        strSql &= ") " & Environment.NewLine
                        strSql &= "VALUES " & Environment.NewLine
                        strSql &= "( " & Environment.NewLine
                        strSql &= CInt(strCust_id) & ", " & Environment.NewLine
                        strSql &= CInt(strModel_id) & ", " & Environment.NewLine
                        strSql &= CInt(strBillLevel) & " " & Environment.NewLine
                        strSql &= ");"
                        Me.objMisc._SQL = strSql
                        i += Me.objMisc.ExecuteNonQuery
                        'End If
                        '********************************
                    End If

                    '*********************
                    'Reset variable
                    '*********************
                    strCust_id = ""
                    strModel_id = ""
                    strBillLevel = ""

                    'dispose datatable
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '*********************
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtExcelData) Then
                    dtExcelData.Dispose()
                    dtExcelData = Nothing
                End If
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing

                If Not IsNothing(objDataset1) Then
                    objDataset1.Dispose()
                    objDataset1 = Nothing
                End If
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If

                'Invoke Garbage Collector
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************************
        Public Function UpdateBillLevel(ByVal iCustomer_ID As Integer, _
                                         ByVal iModel_ID As Integer, _
                                         ByVal iHighLow As Integer) _
                                         As Integer
            Dim strSql As String = ""

            Try
                strSql = "replace into tmodelbilllevel ( " & Environment.NewLine
                strSql &= "mbl_cust_id, " & Environment.NewLine
                strSql &= "mbl_model_id, " & Environment.NewLine
                strSql &= "mbl_level " & Environment.NewLine
                strSql &= ") values ( " & Environment.NewLine
                strSql &= iCustomer_ID & ", " & Environment.NewLine
                strSql &= iModel_ID & ", " & Environment.NewLine
                strSql &= iHighLow & Environment.NewLine
                strSql &= ");"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function DeleteBillLevel(ByVal iModBillLvl_id As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "delete from tmodelbilllevel " & Environment.NewLine
                strSql &= "where mbl_id = " & iModBillLvl_id & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

        Public Function AutoBill_Brightpoint(ByVal strServerDateTime As String, _
                                          ByVal R1 As DataRow, _
                                          ByVal iAutoBillCode As Integer, _
                                          ByVal iBillgroup_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R2, RLabor As DataRow
            Dim decAvgcost As Decimal = 0
            Dim decStdcost As Decimal = 0
            Dim decInvcost As Decimal = 0
            Dim DecLaborChg As Decimal = 0
            Dim iLaborLvlID As Integer = 0
            Dim booWarranty As Boolean = False
            Dim iDBill_ID As Integer = 0
            Dim iManufWrty As Integer = 0
            Dim iCurLaborLevel As Integer = 0
            Dim decCurrentLaborCharge As Decimal = 0
            Dim iPSSWrty As Integer = 0
            ''Dim booFailCode As Boolean = False
            Dim objGen As New PSS.Data.Buisness.Generic()

            Try
                '***********************************************************
                'Get Avg Cost and Std Cost and inv price from lpsprice table
                '***********************************************************
                dt1 = Me.GetPriceInfo(R1("Model_ID"), iAutoBillCode)

                If dt1.Rows.Count = 0 Then
                    MsgBox("Billcode to Part mapping information could not be determined.")
                    Exit Function
                Else
                    R2 = dt1.Rows(0)
                End If

                ''********************************
                ''set Failure code
                ''********************************
                ''booFailCode = Me.CheckFailCodeExists(R1("Cust_ID"), R1("Model_ID"), iAutoBillCode)

                '***********************************************
                'Get DeviceInvoice Amount
                '***********************************************
                decInvcost = Me.GetAutoBillDeviceInvoiceAmt(R1, R2)
                '***********************************************

                Try
                    If Not IsDBNull(R2("PSPrice_AvgCost")) Then
                        decAvgcost = Math.Round(R2("PSPrice_AvgCost"), 2)
                    End If
                    If Not IsDBNull(R2("PSPrice_StndCost")) Then
                        decStdcost = Math.Round(R2("PSPrice_StndCost"), 2)
                    End If

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try


                '*************************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '**************************************************
                'Determine the Labor Level and Labor Charge Info
                '**************************************************
                'dt1 = Me.DetermineLaborLevel_LaborCharge(iAutoBillCode, R1("Model_ID"), R1("PricingGroup"), R1("ProductGroup"))
                dt1 = Me.GetLaborCharge_ByLaborLvl(1, R1("PricingGroup"), R1("ProductGroup"))

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("'Pricing Group', 'Product Group' and 'Labor Level' relationship was not established by Customer Service. Please contact the relevant department to address the issue.")
                Else
                    RLabor = dt1.Rows(0)
                    If Not IsDBNull(RLabor("LaborLvl_ID")) Then
                        iLaborLvlID = RLabor("LaborLvl_ID")
                    Else
                        Throw New Exception("Labor Level can not be NULL. Customer Service issue. Please contact the relevant department to address the issue.")
                    End If

                    If Not IsDBNull(RLabor("LaborPrc_RegPrc")) Then
                        DecLaborChg = RLabor("LaborPrc_RegPrc")
                    Else
                        Throw New Exception("Labor charge can not be NULL. Customer Service issue. Please contact the relevant department to address the issue.")
                    End If
                End If

                '*************************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '**********************************
                'Get Current Labor Level of auto-bill
                '**********************************
                dt1 = Me.GetCurrent563LaborLevelForDevice(R1("Device_ID"))

                If Not IsDBNull(dt1.Rows(0)("Device_LaborLevel_AutoBilled")) Then
                    iCurLaborLevel = dt1.Rows(0)("Device_LaborLevel_AutoBilled")
                Else
                    iCurLaborLevel = 0
                End If

                If Not IsDBNull(dt1.Rows(0)("Device_LaborCharge_AutoBilled")) Then
                    decCurrentLaborCharge = dt1.Rows(0)("Device_LaborCharge_AutoBilled")
                Else
                    decCurrentLaborCharge = 0
                End If

                '*************************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '*****************************************************************************
                'Compare Current Billcode's labor charge with the tdevice labor charge.
                'Update tdevice if and only if current one is greater than the one in tdevice.
                '*****************************************************************************
                If iLaborLvlID > iCurLaborLevel Then
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&''SetLaborData
                    i = Me.UpdateLaborInfo_Autobill(R1("Device_ID"), strServerDateTime, iLaborLvlID, DecLaborChg)
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&''SetLaborData
                End If

                'Insert in to tdevicebill_563
                i = Me.AutoBill(decAvgcost, decStdcost, decInvcost, R1("Device_ID"), iAutoBillCode, iBillgroup_ID)

                Return i
                '**************************************
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetDeviceInfo(ByVal iDevice_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '//*****************************************************************
                '//Get Device related info
                '//*****************************************************************
                strSql = "SELECT " & Environment.NewLine
                strSql &= "tdevice.Device_ID, " & Environment.NewLine
                strSql &= "tdevice.Device_SN, " & Environment.NewLine
                strSql &= "tdevice.Device_OldSN, " & Environment.NewLine
                strSql &= "tdevice.Device_DateBill, " & Environment.NewLine
                strSql &= "tdevice.Device_DateShip, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
                strSql &= "tdevice.Tray_ID, " & Environment.NewLine
                strSql &= "tdevice.Loc_ID, " & Environment.NewLine
                strSql &= "tdevice.WO_ID, " & Environment.NewLine
                strSql &= "tdevice.Model_ID, " & Environment.NewLine
                strSql &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
                strSql &= "If(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
                strSql &= "lpricinggroup.PrcType_ID, " & Environment.NewLine
                strSql &= "If(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
                strSql &= "tmodel.Prod_ID, " & Environment.NewLine
                strSql &= "tmodel.Manuf_ID, " & Environment.NewLine
                strSql &= "tmodel.ASCPrice_ID, " & Environment.NewLine
                strSql &= "lascprice.ASCPrice_Price, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1," & Environment.NewLine
                strSql &= "tcustomer.Cust_Name2," & Environment.NewLine
                strSql &= "tlocation.Loc_Name," & Environment.NewLine
                strSql &= "tcustomer.Pay_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
                strSql &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
                strSql &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
                strSql &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
                strSql &= "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
                strSql &= "tcustwrty.PSSWrtyParts_ID, " & Environment.NewLine
                strSql &= "tcustwrty.PSSWrtyLabor_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_AutoShip , " & Environment.NewLine
                strSql &= "tcustomer.Cust_ID , " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "inner join lascprice on tmodel.ASCPrice_ID = lascprice.ASCPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID and tmodel.Prod_ID = tcustmarkup.Prod_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID and tmodel.Prod_ID = lpricinggroup.Prod_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID and tcustwrty.Prod_ID = tmodel.Prod_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
                strSql &= "WHERE " & Environment.NewLine
                strSql &= "tdevice.Device_ID = " & iDevice_id & ";"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetPriceInfo(ByVal iModel_ID As Integer, _
                                     ByVal iBillCode_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '***********************************************************
                'Get Avg Cost and Std Cost and inv price from lpsprice table
                '***********************************************************

                strSql = "Select lpsprice.*, lbillcodes.BillType_ID, lbillcodes.BillCode_Rule " & Environment.NewLine
                strSql &= "from tpsmap " & Environment.NewLine
                strSql &= "inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "where tpsmap.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                strSql &= "tpsmap.BillCode_ID = " & iBillCode_ID & ";"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '''***************************************************************************
        ''Public Function CheckFailCodeExists(ByVal iCust_ID As Integer, _
        ''                                    ByVal iModel_ID As Integer, _
        ''                                    ByVal iAutoBillCode As Integer) As Boolean
        ''    Dim strSql As String = ""
        ''    Dim dt1 As DataTable

        ''    Try
        ''        strSql = "select count(*) as cnt from tbillmap " & Environment.NewLine
        ''        strSql &= "inner join lcodesdetail on tbillmap.BMap_Failure = lcodesdetail.Dcode_id " & Environment.NewLine
        ''        strSql &= "where tbillmap.Cust_Id = " & iCust_ID & Environment.NewLine
        ''        strSql &= "and model_id = " & iModel_ID & " " & Environment.NewLine
        ''        strSql &= "and billcode_id = " & iAutoBillCode & " " & Environment.NewLine
        ''        strSql &= "and BMap_Inactive = 0 " & Environment.NewLine
        ''        strSql &= "and lcodesdetail.Dcode_ChrgCust = 1;"
        ''        Me.objMisc._SQL = strSql
        ''        dt1 = Me.objMisc.GetDataTable()

        ''        If dt1.Rows(0)("cnt") > 0 Then
        ''            Return True
        ''        Else
        ''            Return False
        ''        End If

        ''    Catch ex As Exception
        ''        Throw ex
        ''    Finally
        ''        If Not IsNothing(dt1) Then
        ''            dt1.Dispose()
        ''            dt1 = Nothing
        ''        End If
        ''    End Try
        ''End Function

        '***************************************************************************

        Private Function Price(ByVal dcStandardPrice As Object, ByVal iBillType As Integer, ByVal dcCust_Markup As Decimal) As Decimal
            Try
                If Not IsNothing(dcStandardPrice) Then
                    If Not IsDBNull(dcStandardPrice) Then
                        If iBillType = 1 Then 'Service
                            Return dcStandardPrice
                        ElseIf iBillType = 2 Then 'Part
                            Return Math.Round(dcStandardPrice * (dcCust_Markup + 1), 2)
                        Else                      'Everything else
                            Return Math.Round(dcStandardPrice * (dcCust_Markup + 1), 2)
                        End If
                    End If
                End If

                Return 0.0
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Function

        '***************************************************************************
        Private Function GetAutoBillDeviceInvoiceAmt(ByVal drDevInfo As DataRow, _
                                             ByVal drPSPriceInfo As DataRow) As Decimal
            Dim dcPrice As Decimal = 0.0

            Try
                If Not IsDBNull(drPSPriceInfo("PSPrice_StndCost")) Then
                    dcPrice = Me.Price(drPSPriceInfo("PSPrice_StndCost"), drPSPriceInfo("BillType_ID"), drDevInfo("Cust_Markup"))
                End If

                Return dcPrice
            Catch ex As Exception
                Throw ex
            Finally
                drDevInfo = Nothing
                drPSPriceInfo = Nothing
            End Try
        End Function

        '***************************************************************************
        Public Function DetermineLaborLevel_LaborCharge(ByVal iBillCode As Integer, _
                                                        ByVal iModel_ID As Integer, _
                                                        ByVal iPricingGroup_ID As Integer, _
                                                        ByVal iProductGroup_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '**************************************************
                'Determine the Labor Level and Labor Charge Info
                '**************************************************
                strSql = "SELECT tlaborprc.LaborPrc_RegPrc, " & Environment.NewLine
                strSql &= "tlaborprc.LaborPrc_WrtyPrc, " & Environment.NewLine
                strSql &= "tlaborprc.LaborLvl_ID " & Environment.NewLine
                strSql &= "FROM tlaborprc " & Environment.NewLine
                strSql &= "inner join tpsmap on tlaborprc.LaborLvl_ID = tpsmap.LaborLvl_ID " & Environment.NewLine
                strSql &= "Where tpsmap.billcode_id = " & iBillCode & " and " & Environment.NewLine
                strSql &= "tpsmap.model_id = " & iModel_ID & " and " & Environment.NewLine
                strSql &= "PrcGroup_ID = " & iPricingGroup_ID & " and " & Environment.NewLine
                strSql &= "ProdGrp_ID = " & iProductGroup_ID & ";" & Environment.NewLine
                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetLaborCharge_ByLaborLvl(ByVal iLaborLvl_ID As Integer, _
                                              ByVal iPricingGroup_ID As Integer, _
                                              ByVal iProductGroup_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '**************************************************
                'Determine the Labor Level and Labor Charge Info
                '**************************************************
                strSql = "SELECT tlaborprc.LaborPrc_RegPrc, " & Environment.NewLine
                strSql &= "tlaborprc.LaborPrc_WrtyPrc, " & Environment.NewLine
                strSql &= "tlaborprc.LaborLvl_ID " & Environment.NewLine
                strSql &= "FROM tlaborprc " & Environment.NewLine
                strSql &= "Where LaborLvl_ID = " & iLaborLvl_ID & " AND " & Environment.NewLine
                strSql &= "PrcGroup_ID = " & iPricingGroup_ID & " AND " & Environment.NewLine
                strSql &= "ProdGrp_ID = " & iProductGroup_ID & ";" & Environment.NewLine
                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetMaxLaborLevelForDevice(ByVal iDevice_id As Integer) _
                                                    As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iMaxLaborLevel As Integer = 0

            Try
                '**********************************
                'Get Maximum Labor Level
                '**********************************
                strSql = "select max(tpsmap.LaborLvl_ID) as MaxLaborLevel " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql &= "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                strSql &= "where tdevice.device_id = " & iDevice_id & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("MaxLaborLevel")) Then
                        iMaxLaborLevel = dt1.Rows(0)("MaxLaborLevel")
                    End If
                End If

                Return iMaxLaborLevel
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function HasNoPartBillCode(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable

            Try
                strSql = "select count(*) as cnt " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql &= "where tdevice.device_id = " & iDevice_ID & " " & Environment.NewLine
                strSql &= "AND Billcode_ID = 255;"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows(0)("cnt") > 0 Then      'NO PART Billcode is existed
                    Return True
                Else                                'Does not have NO PART Billcode
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetCurrent563LaborLevelForDevice(ByVal iDevice_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '**********************************
                'Get Maximum Labor Level
                '**********************************
                'strSql = "select max(tpsmap.LaborLvl_ID) as CurrentLaborLevel " & Environment.NewLine
                'strSql &= "from tdevicebill_563 " & Environment.NewLine
                'strSql &= "inner join tpsmap on tdevicebill_563.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                'strSql &= "where tdevicebill_563.device_id = " & iDevice_id & " "
                'strSql &= " and tpsmap.model_id = " & iModel_id & ";"

                strSql = "Select Device_LaborLevel_AutoBilled, Device_LaborCharge_AutoBilled from tdevice where device_id = " & iDevice_id & ";"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function UpdateLaborInfo_Autobill(ByVal iDevice_ID As Integer, _
                                                 Optional ByVal strDateTime As String = "", _
                                                 Optional ByVal iCurLaborLevel As Integer = 0, _
                                                 Optional ByVal DecCurLaborChg As Decimal = 0.0 _
                                                 ) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tdevice " & Environment.NewLine
                If strDateTime <> "" Then
                    strSql &= "SET Device_DateBill_AutoBilled = '" & strDateTime & "', " & Environment.NewLine
                Else
                    strSql &= "SET Device_DateBill_AutoBilled = Device_DateBill, " & Environment.NewLine
                End If

                If iCurLaborLevel > 0 Then
                    strSql &= "Device_LaborLevel_AutoBilled = " & iCurLaborLevel & ", " & Environment.NewLine
                Else
                    strSql &= "Device_LaborLevel_AutoBilled = Device_LaborLevel, " & Environment.NewLine
                End If

                If DecCurLaborChg > 0 Then
                    strSql &= "Device_LaborCharge_AutoBilled = " & DecCurLaborChg & " " & Environment.NewLine
                Else
                    strSql &= "Device_LaborCharge_AutoBilled =  Device_LaborCharge " & Environment.NewLine
                End If

                strSql &= " WHERE Device_ID = " & iDevice_ID & ";"
                objMisc._SQL = strSql
                Return objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function AutoBill(ByVal decAvgcost As Decimal, _
                                 ByVal decStdcost As Decimal, _
                                 ByVal decInvcost As Decimal, _
                                 ByVal iDevice_ID As Integer, _
                                 ByVal iBillcode_ID As Integer, _
                                 ByVal iBillgroup_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                '************************************
                'Lan added on 11/30/2007.
                'Prevent duplicate billcode for device 
                ' due to system hang-up. 
                '************************************
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevicebill_563 " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & " " & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcode_ID & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                '************************************

                If dt1.Rows(0)("cnt") = 0 Then

                    strSql = "insert into tdevicebill_563 ( " & Environment.NewLine
                    strSql &= "DBill_AvgCost, " & Environment.NewLine
                    strSql &= "DBill_StdCost, " & Environment.NewLine
                    strSql &= "DBill_InvoiceAmt, " & Environment.NewLine
                    strSql &= "Device_ID, " & Environment.NewLine
                    strSql &= "BillCode_ID, " & Environment.NewLine
                    strSql &= "User_ID, " & Environment.NewLine
                    strSql &= "BG_ID, " & Environment.NewLine
                    strSql &= "Date_Rec " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= decAvgcost & ", " & Environment.NewLine
                    strSql &= decStdcost & ", " & Environment.NewLine
                    strSql &= decInvcost & ", " & Environment.NewLine
                    strSql &= iDevice_ID & ", " & Environment.NewLine
                    strSql &= iBillcode_ID & ", " & Environment.NewLine
                    strSql &= Me.iUserID & ", " & Environment.NewLine
                    strSql &= iBillgroup_ID & ", " & Environment.NewLine
                    strSql &= "'" & Me.strWorkDt & "');"

                    objMisc._SQL = strSql
                    i = objMisc.ExecuteNonQuery
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
    End Class





    Public Class ATCLE_LaborLevel

        Private ds As PSS.Data.Production.Joins
        Private r As DataRow

#Region "INTERNALS"

        Private _Device As Long
        Private _Customer As Long
        Private _Model As Long

        Private PO As Integer = 0
        Private iAgg As Integer = 0
        Private iPrcGroup As Integer = 0
        Private iPrcGroupType As Integer = 0
        Private iModelTier As Integer = 0
        Private iModelFlat As Integer = 0
        Private iProdID As Integer = 0
        Private iLL As Integer = 0

        Private dblRTM As Double = 0.0
        Private dblRUR As Double = 0.0
        Private dblNER As Double = 0.0
        Private dblNTF As Double = 0.0

        Private isPO As Boolean = False
        Private isRTM As Boolean = False
        Private isRUR As Boolean = False
        Private isNER As Boolean = False
        Private isManufWrty As Boolean = False
        Private isPSSWrty As Boolean = False
        Private isAgg As Boolean = False

        Private strSQL As String

#End Region

#Region "PUBLIC FUNCTIONS"

        Public Function getLaborCharge(ByVal DeviceID As Long, ByVal custID As Long) As Double

            _Device = DeviceID
            _Customer = custID

            '//*******************************************************************
            '//Validate that device ID exists in database
            Try
                strSQL = "SELECT * FROM tdevice WHERE device_id = " & _Device
                r = getDataRow(strSQL)
            Catch ex As Exception
                MsgBox("The Device_ID is not in system")
                Return -1
            End Try

            Dim dt As DataTable

            '//*******************************************************************
            '//Get the device specific data
            getData()

            '//*******************************************************************
            '//If device is rur/rtm then return value
            If isRUR = True Then Return dblRUR
            If isNER = True Then Return dblNER

            '//*******************************************************************
            '//*******************************************************************
            '//This section will perform the aggregate billing structure
            If iAgg <> 0 Then

                Dim vProgramming As Double
                Dim vCosmeticRepair As Double
                Dim vPolish As Double
                Dim vTesting As Double

                '//Get customer default values
                Dim x As Integer
                strSQL = "SELECT * FROM tcustaggregatebilling WHERE cust_id = " & _Customer
                dt = ds.OrderEntrySelect(strSQL)
                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("billcode_id") = 442 Then vProgramming = r("tcab_Amount")
                    If r("billcode_id") = 446 Then vCosmeticRepair = r("tcab_Amount")
                    If r("billcode_id") = 447 Then vPolish = r("tcab_Amount")
                    If r("billcode_id") = 448 Then vTesting = r("tcab_Amount")
                Next

                '//Get model override data
                strSQL = "SELECT * FROM tcust_model_aggbilling_default WHERE cust_id = " & _Customer & " AND model_ID = " & _Model
                dt = ds.OrderEntrySelect(strSQL)
                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("billcode_id") = 442 Then vProgramming = r("labor_charge")
                    If r("billcode_id") = 446 Then vCosmeticRepair = r("labor_charge")
                    If r("billcode_id") = 447 Then vPolish = r("labor_charge")
                    If r("billcode_id") = 448 Then vTesting = r("labor_charge")
                Next

                If isRTM = True Then Return vTesting
                If isRUR = True Then Return dblRUR

                '//Determine if device has cosmetic parts
                '//Has any parts been billed
                strSQL = "SELECT tdevicebill.billcode_id FROM tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevice.device_id = " & _Device & " AND billtype_id = 2"
                dt = ds.OrderEntrySelect(strSQL)
                If dt.Rows.Count > 0 Then
                    '//Parts have been charged add cosmetics
                    Return vTesting + vProgramming + vPolish + vCosmeticRepair
                Else
                    Return vTesting + vProgramming + vPolish
                End If
            End If
            '//end of aggregate billing structure
            '//*******************************************************************
            '//*******************************************************************

            '//*******************************************************************
            '//This is the standard billing structure
            If isRTM = True Then Return dblRTM

            iLL = getMaxLaborLevel()

            Dim mPrcGroup As Long = getPricingGroup(PO, iProdID)
            Dim mProdGroup As Long = 0
            If iPrcGroupType = 1 Then
                '//Tier
                mProdGroup = iModelTier
                strSQL = "SELECT * FROM tlaborprc WHERE PrcGroup_ID = " & iPrcGroup & " AND ProdGrp_ID = " & mProdGroup & " AND LaborLvl_ID = " & iLL
            Else
                '//Flat
                mProdGroup = iModelFlat
                strSQL = "SELECT * FROM tlaborprc WHERE PrcGroup_ID = " & iPrcGroup & " AND ProdGrp_ID = " & mProdGroup & " AND LaborLvl_ID = 0"
            End If
            dt = ds.OrderEntrySelect(strSQL)
            If dt.Rows.Count <> 1 Then
                '//Throw error and exit
            End If

            r = dt.Rows(0)
            '//*******************************************************************
            '//If PO then return PO based value
            If isPO = True Then Return r("LaborPrc_RegPrc")
            '//*******************************************************************
            If isManufWrty = True Then Return ("LaborPrc_RegPrc")
            '//*******************************************************************
            '//If PSS Wrty is true then read table tcustwrty to get specific warranty standards
            '//(client specific)
            If isPSSWrty = True Then
                strSQL = "SELECT * FROM tcustwrty WHERE cust_id = " & _Customer & " AND ProdID = " & iProdID

                r = getDataRow(strSQL)
                Dim iResult As Integer = r("PSSWrtyLabor_ID")

                Select Case iResult
                    Case 1
                        Return ("LaborPrc_RegPrc")
                    Case 2
                        Return ("LaborPrc_WrtyPrc")
                    Case 4
                        If iLL = 3 Then
                            Return ("LaborPrc_WrtyPrc")
                        Else
                            Return ("LaborPrc_RegPrc")
                        End If
                    Case Else
                        Return ("LaborPrc_RegPrc")
                End Select
            Else
                Return ("LaborPrc_RegPrc")
            End If

        End Function

#End Region

#Region "DATA ACQUISITIONS"

        Private Sub getData()

            Dim mComplete As Boolean

            If IsDBNull(_Device) = True Then
                MsgBox("No device was defined.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            isPO = isValue(_Device, "PO")
            isRTM = isValue(_Device, "RTM")
            isRUR = isValue(_Device, "RUR")
            isNER = isValue(_Device, "NER")
            isManufWrty = isValue(_Device, "MW")
            isPSSWrty = isValue(_Device, "PW")
            isAgg = isValue(_Device, "AGG")

            mComplete = getCustomerDefaults()
            mComplete = getModelData()
            mComplete = getPricingGroupData(iPrcGroup)

            If PO > 0 Then
                mComplete = getPOData(PO)
            End If

        End Sub

        Private Function getMaxLaborLevel() As Integer
            Try
                Dim dt As DataTable
                strSQL = "SELECT MAX(tpsmap.LaborLvl_id) as MaxLL from tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id INNER JOIN tpsmap ON (tdevice.model_id = tpsmap.model_id AND tdevicebill.billcode_id = tpsmap.billcode_id) WHERE tdevice.device_id = " & _Device & " AND tpsmap.Inactive = 0 GROUP BY by LaborLvl_ID"
                r = dt.Rows(0)
                Return r("MaxLL")
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Private Function getCustomerDefaults() As Boolean
            Try
                strSQL = "SELECT tcustomer.cust_AggBilling, tcustmarkup.* FROM tcustomer INNER JOIN tcustmarkup ON tcustomer.cust_id = tcustmarkup.cust_id WHERE tcustomer.Cust_ID = " & _Customer
                r = getDataRow(strSQL)
                dblRTM = r("MarkUp_RTM")
                dblRUR = r("MarkUp_RUR")
                dblNER = r("MarkUP_NER")
                dblNTF = r("MarkUP_NTF")
                iAgg = r("Cust_AggBilling")
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Function getPOData(ByVal PO As Long) As Boolean
            Try
                strSQL = "SELECT * FROM tpurchaseorder WHERE PO_ID = " & PO
                r = getDataRow(strSQL)
                If IsDBNull(r("PO_RTM")) = False Then dblRTM = r("PO_RTM")
                If IsDBNull(r("PO_RUR")) = False Then dblRUR = r("PO_RUR")
                If IsDBNull(r("PO_NER")) = False Then dblNER = r("PO_NER")
                iAgg = r("PO_Aggregate")
                iPrcGroup = r("PrcGroup_ID")
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Function getPricingGroupData(ByVal PrcGroup As Integer) As Boolean
            If PrcGroup = 0 Then
                '//get customer default
                Try
                    strSQL = "SELECT * FROM lpricinggroup WHERE cust_ID = " & _Customer & " AND prod_id = " & iProdID
                    r = getDataRow(strSQL)
                    iPrcGroup = r("PrcGroup_ID")
                    iPrcGroupType = r("PrcGroup_Type")
                Catch ex As Exception
                    iPrcGroup = -1
                    iPrcGroupType = -1
                    Return False
                End Try
            Else
                Try
                    strSQL = "SELECT * FROM lpricinggroup WHERE PrcGroup_ID = " & PrcGroup
                    r = getDataRow(strSQL)
                    iPrcGroupType = r("PrcGroup_Type")
                Catch ex As Exception
                    iPrcGroupType = -1
                    Return False
                End Try
            End If
            Return True
        End Function

        Private Function getModelData() As Boolean
            Try
                strSQL = "SELECT tmodel.* FROM tdevice INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id WHERE Device_ID = " & _Device
                r = getDataRow(strSQL)
                _Model = r("Model_ID")
                iModelTier = r("Model_Tier")
                iModelFlat = r("Model_Flat")
                iProdID = r("Prod_ID")
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

        Private Function getPricingGroup(ByVal iPO As Integer, ByVal iProdID As Integer) As Long
            If iPO > 0 Then
                Return iPrcGroup
            Else
                '//Get pricing group from tcusttoprice
                strSQL = "SELECT * FROM tcusttoprice WHERE cust_id = " & _Customer & " AND Prod_ID = " & iProdID
                r = getDataRow(strSQL)
                iPrcGroup = r("PrcGroup_ID")
                strSQL = "SELECT prcGroup_Type FROM lpricinggroup WHERE prcgroup_id = " & iPrcGroup
                r = getDataRow(strSQL)
                iPrcGroupType = r("PrcGroup_Type")
                Return iPrcGroup
            End If
        End Function

#End Region

#Region "BASE FUNCTIONS"

        Private Function getDataRow(ByVal strSQL As String) As DataRow
            Return ds.OrderEntrySelect(strSQL).Rows(0)
        End Function

        Private Function getDataTable(ByVal strSQL As String) As DataTable
            Return ds.OrderEntrySelect(strSQL)
        End Function

#End Region

#Region "QUALIFIERS"

        Private Function isValue(ByVal _Device As Long, ByVal strType As String) As Boolean
            Select Case strType
                Case "PO"
                    strSQL = " SELECT PO_ID FROM tdevice INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id WHERE tdevice.device_id = " & _Device
                    Return returnBoolean(strSQL, "PO")
                Case "RTM"
                    strSQL = "SELECT BillCode_Rule FROM tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevice.device_id = " & _Device
                    Return returnBoolean(strSQL, "RTM")
                Case "RUR"
                    strSQL = "SELECT BillCode_Rule FROM tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevice.device_id = " & _Device
                    Return returnBoolean(strSQL, "RUR")
                Case "NER"
                    strSQL = "SELECT BillCode_Rule FROM tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevice.device_id = " & _Device
                    Return returnBoolean(strSQL, "NER")
                Case "MW"
                    strSQL = "SELECT Device_ManufWrty FROM tdevice WHERE device_id = " & _Device
                    Return returnBoolean(strSQL, "MW")
                Case "PW"
                    strSQL = "SELECT Device_PSSWrty FROM tdevice WHERE device_id = " & _Device
                    Return returnBoolean(strSQL, "PW")
                Case "AGG"
                    strSQL = "SELECT Cust_AggBilling FROM tdevice INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_id WHERE tdevice.device_id = " & _Device
                    Return returnBoolean(strSQL, "AGG")
            End Select
        End Function

        Private Function returnBoolean(ByVal strSQL As String, ByVal strType As String) As Boolean
            Dim X As Integer
            Dim dt As DataTable
            Select Case strType
                Case "PO"
                    r = getDataRow(strSQL)
                    Try
                        If IsDBNull("PO_ID") = False Then PO = r("PO_ID")
                        If r("PO_ID") > 0 Then Return True
                    Catch ex As Exception
                        Return 0
                    End Try
                Case "RTM"
                    dt = getDataTable(strSQL)
                    For X = 0 To dt.Rows.Count - 1
                        r = dt.Rows(X)
                        If r("BillCode_Rule") = 9 Then Return True
                    Next
                Case "RUR"
                    dt = getDataTable(strSQL)
                    For X = 0 To dt.Rows.Count - 1
                        r = dt.Rows(X)
                        If r("BillCode_Rule") = 1 Then Return True
                    Next
                Case "NER"
                    dt = getDataTable(strSQL)
                    For X = 0 To dt.Rows.Count - 1
                        r = dt.Rows(X)
                        If r("BillCode_Rule") = 2 Then Return True
                    Next
                Case "MW"
                    r = getDataRow(strSQL)
                    If r("Device_ManufWrty") = 1 Then Return True
                Case "PW"
                    r = getDataRow(strSQL)
                    If r("Device_PSSWrty") = 1 Then Return True
                Case "AGG"
                    r = getDataRow(strSQL)
                    If r("Cust_AggBilling") = 2 Then Return True
            End Select
            dt = Nothing
        End Function

#End Region

    End Class

End Namespace

