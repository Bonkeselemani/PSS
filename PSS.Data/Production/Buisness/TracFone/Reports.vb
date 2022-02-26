Option Explicit On 

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Text

Namespace Buisness.TracFone
    Public Class Reports

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

        Public Shared Function LoadEDITranasctionReport(Optional ByVal iModelID As Integer = 0)
            Dim dt1 As DataTable
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application   ' Excel application
            Dim objBook As Excel.Workbook       ' Excel workbook
            Dim objSheet As Excel.Worksheet     ' Excel Worksheet
            ' TEST CODE.
            'Dim strFileName As String = "Testing.xls"  'CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            'strRptPath = strRptDir & strFileName
            '
            Dim R1 As DataRow
            Dim i As Integer = 3
            Dim arrData(0, 0) As Object
            Dim j As Integer = 0
            Dim iDiscr As Integer = 0
            Try
                dt1 = GetData(iModelID)
                If dt1.Rows.Count = 0 Then
                    MsgBox("There's no data for this model.", MsgBoxStyle.Information)
                Else
                    ' INSTANTIATE THE EXCEL RELATED OBJECTS
                    objExcel = New Excel.Application()              'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                'Add a Workbook
                    objExcel.Application.Visible = True             'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)           'Select a Sheet 1 for this
                    objExcel.ActiveSheet.Pagesetup.Orientation = 2  ' 1 = Portrait ; 2 = landscape
                    ' CREATE THE HEADER
                    objExcel.Application.Cells(i, 1).Value = "Order Type"
                    objExcel.Application.Cells(i, 2).Value = "Order No."
                    objExcel.Application.Cells(i, 3).Value = "IN-Ship From" & Chr(10) & "OUT-Ship To"
                    objExcel.Application.Cells(i, 4).Value = "Item No."
                    objExcel.Application.Cells(i, 5).Value = "IL No."
                    objExcel.Application.Cells(i, 6).Value = "940 Order Qty."
                    objExcel.Application.Cells(i, 7).Value = "940 PO Date"
                    objExcel.Application.Cells(i, 8).Value = "940 Delivery Requested"
                    objExcel.Application.Cells(i, 9).Value = "940 Aging"
                    objExcel.Application.Cells(i, 10).Value = "856 Loaded Date"
                    objExcel.Application.Cells(i, 11).Value = "856 Shipped Date"
                    objExcel.Application.Cells(i, 12).Value = "WH Received Date"
                    objExcel.Application.Cells(i, 13).Value = "944 Receipt"
                    objExcel.Application.Cells(i, 14).Value = "944 PSSI Qty."
                    objExcel.Application.Cells(i, 15).Value = "Discrepancy"
                    ' SET HORIZONTAL ALIGNMENT FOR THE HEADER
                    objSheet.Range("A3:O3").Select()
                    With objExcel.Selection
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                    End With

                    With objExcel.Selection.Interior
                        .ColorIndex = 37
                        .Pattern = Excel.Constants.xlSolid
                    End With

                    i = 0
                    ReDim arrData(dt1.Rows.Count, 14)
                    For Each R1 In dt1.Rows
                        If Not IsDBNull(R1("Order_Type")) Then
                            arrData(i, 0) = Trim(R1("Order_Type"))
                        End If
                        If Not IsDBNull(R1("OrderNo")) Then
                            arrData(i, 1) = Trim(R1("OrderNo"))
                        End If
                        If Not IsDBNull(R1("Name")) Then
                            arrData(i, 2) = Trim(R1("Name"))
                        End If
                        If Not IsDBNull(R1("VN_ItemNo")) Then
                            arrData(i, 3) = Trim(R1("VN_ItemNo"))
                        End If
                        If Not IsDBNull(R1("IL_No")) Then
                            arrData(i, 4) = Trim(R1("IL_No"))
                        End If
                        If Not IsDBNull(R1("OrderQty")) Then
                            arrData(i, 5) = Trim(R1("OrderQty"))
                        End If
                        If Not IsDBNull(R1("PODate")) Then
                            arrData(i, 6) = Trim(R1("PODate"))
                        End If
                        If Not IsDBNull(R1("RequestDate")) Then
                            arrData(i, 7) = Trim(R1("RequestDate"))
                        End If
                        If Not IsDBNull(R1("940 Aging")) Then
                            arrData(i, 8) = Trim(R1("940 Aging"))
                        End If
                        If Not IsDBNull(R1("Msg_RcvdDT")) Then
                            arrData(i, 9) = Trim(R1("Msg_RcvdDT"))
                        End If
                        If Not IsDBNull(R1("Msg_CreationDT")) Then
                            arrData(i, 10) = Trim(R1("Msg_CreationDT"))
                        End If
                        If Not IsDBNull(R1("Order_RcvdDate")) Then
                            arrData(i, 11) = Trim(R1("Order_RcvdDate"))
                        End If
                        If Not IsDBNull(R1("ReceiptDate")) Then
                            arrData(i, 12) = Trim(R1("ReceiptDate"))
                        End If
                        If Not IsDBNull(R1("WO_RAQnty")) Then
                            arrData(i, 13) = Trim(R1("WO_RAQnty"))
                        End If
                        If ((Trim(R1("Order_Type")) = "IN" AndAlso (Not IsDBNull(R1("Order_RcvdDate"))) AndAlso CInt(R1("WO_RAQnty")) >= 0) Or (Trim(R1("Order_Type")) = "OUT" And (Not IsDBNull(R1("Msg_CreationDT"))))) Then
                            iDiscr = CInt(R1("WO_RAQnty")) - CInt(R1("OrderQty"))
                            arrData(i, 14) = iDiscr.ToString
                        End If

                        i += 1
                    Next R1
                    objSheet.Range("A4", "O" & (dt1.Rows.Count + 3)).Value = arrData
                    ' SET THE BORDERS FOR THE WHOLE REPORT
                    objSheet.Range("A3:O" & (dt1.Rows.Count + 3)).Select()
                    ' SET FONT
                    With objExcel.Selection
                        .Font.Name = "Microsoft Sans Serif"
                    End With
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
                    'ADD REPORT HEADER
                    objSheet.Range("A1:O1").Select()
                    With objExcel.Selection
                        .MergeCells = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .Font.Size = 16
                        .Font.Name = "Verdana"
                        .Font.ColorIndex = 3        'Red
                    End With
                    objExcel.Application.Cells(1, 1).Value = "EDI Transaction Report"
                    ' SET COLUMN WIDTHS
                    objSheet.Cells.EntireColumn.AutoFit()
                    objSheet.Cells.EntireRow.AutoFit()
                    objSheet.Range("B4", "O4").Select()
                    objExcel.ActiveWindow.FreezePanes = True
                    MsgBox("Completed.")
                    objExcel.Sheets("Sheet2").Delete()
                    objExcel.Sheets("Sheet3").Delete()
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                arrData = Nothing
                R1 = Nothing
                ' EXCEL CLEAN UP
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function
        Private Shared Function GetData(ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Try
                strSql = "select distinct b.Order_Type, if(transsetcode is null and b.Order_Type='IN', 940, transsetcode) As Transsetcode" & Environment.NewLine
                strSql &= ", b.OrderNo, "
                strSql &= "CASE b.order_type WHEN 'IN' THEN addin.name WHEN 'OUT' THEN addout.name END AS Name, "
                strSql &= "VN_ItemNo, IL_No, OrderQty, b.PODate, b.RequestDate, " & Environment.NewLine
                strSql &= "if(b.msg_id = 0, TO_DAYS(now())-TO_DAYS(b.PODate), TO_DAYS(Msg_RcvdDT)-TO_DAYS(b.PODate))As '940 Aging'," & Environment.NewLine
                strSql &= "Msg_RcvdDT, if (b.Order_Type = 'OUT', pkslip_createDt, Date_Format(a.Msg_CreationDT, '%Y-%m-%d')) As Msg_CreationDT" & Environment.NewLine
                strSql &= ", Order_RcvdDate, ReceiptDate, WO_RAQnty" & Environment.NewLine
                strSql &= "from edi.torder b" & Environment.NewLine
                strSql &= "left outer join edi.tmessage a on a.msg_id = b.msg_id " & Environment.NewLine
                strSql &= "inner join edi.torderdetail c on c.orderno = b.orderno" & Environment.NewLine
                strSql &= "left outer join edi.twarehousereceipt d on b.WHRNO_ID = d.WHRNO_ID" & Environment.NewLine
                strSql &= "left outer join edi.taddress addin on c.orderno = addin.orderno AND addin.EntityIdentifierCode = 'SF' and b.order_type = 'IN' "
                strSql &= "left outer join edi.taddress addout on c.orderno = addout.orderno AND addout.EntityIdentifierCode = 'ST' and b.order_type = 'OUT'"
                strSql &= "left outer join production.tworkorder e on b.PSS_WO_ID = e.WO_ID" & Environment.NewLine
                strSql &= "left outer join production.tpallett f on e.wo_id = f.wo_id" & Environment.NewLine
                strSql &= "left outer join production.tpackingslip g on f.pkslip_id = g.pkslip_id" & Environment.NewLine
                strSql &= "where b.ordercancel = 0 " & Environment.NewLine
                If iModelID = 0 Then
                    strSql &= "and TO_DAYS(now()) - TO_DAYS(b.PODate) < 91" & Environment.NewLine
                Else
                    strSql &= "and TO_DAYS(now()) - TO_DAYS(b.PODate) < 366 and c.model_id = " & iModelID & Environment.NewLine
                End If
                strSql &= "order by order_type, transsetcode desc, receiptDate, PODate;"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDataProc) Then objDataProc = Nothing
            End Try
        End Function

        '****************************************************************************************
        Private Shared Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '****************************************************************************************
        Public Shared Function LoadWIPSummary(ByVal booDetails As Boolean)
            Dim iMaxExcelRow As Integer = 65536
            Dim dt1, dt2, dtTt As DataTable
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1, drTab() As DataRow
            Dim i, j, k, iProdWipSheetCount, iBERWipSheetCount As Integer
            Dim arrData(0, 0) As Object
            Dim booCompleted As Boolean = False

            Try
                dt1 = GetWIP(booDetails)
                If dt1.Rows.Count = 0 Then Return 0

                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True               'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                '******************************************************************
                'Instantiate the excel related objects

                i = 0 : j = 0
                '******************************************************************
                'SUMMARY TAB
                '******************************************************************
                objSheet = objBook.Sheets.Add()
                'objSheet.Activate()
                objSheet.Name = "Summary"
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                dt2 = GetWIPSummary(dt1) 'Move it to top so that we can update classification
                ReDim arrData(dt2.Rows.Count + 2, dt2.Columns.Count)

                For Each R1 In dt2.Rows
                    For j = 0 To dt2.Columns.Count - 1
                        If i = 0 Then arrData(i, j) = dt2.Columns(j).Caption
                        arrData(i + 1, j) = R1(dt2.Columns(j).Caption)
                    Next j

                    arrData(i + 1, dt2.Columns.Count - 1) = "=SUM(RC[-1]:RC[-" & dt2.Columns.Count - 2 & "])"
                    i += 1
                Next R1

                For j = 0 To dt2.Columns.Count - 1
                    If j = 0 Then arrData(i + 1, j) = "Total" Else arrData(i + 1, j) = "=SUM(R[-1]C:R[-" & dt2.Rows.Count & "]C)"
                Next j

                objSheet.Range("A1", Generic.CalExcelColLetter(dt2.Columns.Count) & (dt2.Rows.Count + 2)).Value = arrData

                For i = 2 To dt2.Columns.Count - 1
                    objSheet.Columns(i + 1).columnWidth = dt2.Columns(i).Caption.Length * 1.45
                Next i
                '*****************************************
                'Set horizontal alignment for the header
                '*****************************************
                objSheet.Range("A1:" & Generic.CalExcelColLetter(dt2.Columns.Count) & "1").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .VerticalAlignment = Excel.Constants.xlTop
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                With objExcel.Selection.Interior
                    .ColorIndex = 37
                    .Pattern = Excel.Constants.xlSolid
                End With

                'Set Font
                With objExcel.Selection
                    .Font.Name = "Microsoft Sans Serif"
                End With

                objSheet.Range("A" & (dt2.Rows.Count + 2).ToString() & ":" & Generic.CalExcelColLetter(dt2.Columns.Count) & (dt2.Rows.Count + 2)).Select()
                With objExcel.Selection
                    .HorizontalAlignment = Excel.Constants.xlRight
                    .font.bold = True
                End With

                objExcel.ActiveWindow.FreezePanes = False
                objExcel.Range("A2:" & Generic.CalExcelColLetter(dt2.Columns.Count) & "2").Select()
                objExcel.ActiveWindow.FreezePanes = True

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()

                '***********************************
                'Set zoom
                '***********************************
                objBook.Sheets("Sheet1").Delete() : objBook.Sheets("Sheet2").Delete() : objBook.Sheets("Sheet3").Delete()
                objExcel.ActiveWindow.Zoom = 70

                If booDetails Then
                    '******************************************************************
                    'PRODUCTION WIP BER TAB
                    '******************************************************************
                    drTab = dt1.Select("BERTab = 1")
                    iBERWipSheetCount = Math.Ceiling(drTab.Length / (iMaxExcelRow - 1))

                    For k = 0 To iBERWipSheetCount - 1
                        If booCompleted = True Then Exit For

                        objSheet = objBook.Sheets.Add()
                        'objSheet.Activate()
                        objSheet.Name = "BER WIP " & k + 1
                        objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape
                        objSheet.Columns(1).Select() : objExcel.Selection.NumberFormat = "@"
                        objExcel.ActiveWindow.FreezePanes = False
                        objExcel.Range("A2:" & Generic.CalExcelColLetter(dt1.Columns.Count - 2) & "2").Select()
                        objExcel.ActiveWindow.FreezePanes = True

                        ReDim arrData(iMaxExcelRow, dt1.Columns.Count - 2) : i = 0 : j = 0

                        For i = 0 To iMaxExcelRow - 2
                            If ((k * (iMaxExcelRow - 1)) + i) >= drTab.Length Then
                                booCompleted = True : Exit For
                            End If

                            R1 = drTab((k * (iMaxExcelRow - 1)) + i)
                            For j = 0 To dt1.Columns.Count - 3
                                If i = 0 Then arrData(i, j) = dt1.Columns(j).Caption
                                arrData(i + 1, j) = R1(dt1.Columns(j).Caption)
                            Next j
                        Next i

                        objSheet.Range("A1", Generic.CalExcelColLetter(dt1.Columns.Count - 2) & (i + 1)).Value = arrData

                        '*****************************************
                        'Set horizontal alignment for the header
                        '*****************************************
                        objSheet.Range("A1:" & Generic.CalExcelColLetter(dt1.Columns.Count - 2) & "1").Select()
                        With objExcel.Selection
                            .WrapText = True
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlTop
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        With objExcel.Selection.Interior
                            .ColorIndex = 37
                            .Pattern = Excel.Constants.xlSolid
                        End With

                        'Set Font
                        With objExcel.Selection
                            .Font.Name = "Microsoft Sans Serif"
                        End With

                        '*****************************************
                        'Set column widths
                        '*****************************************
                        objSheet.Cells.EntireColumn.AutoFit()
                        objSheet.Cells.EntireRow.AutoFit()
                    Next k


                    '******************************************************************
                    'PRODUCTION WIP PRODUCTION TAB
                    '******************************************************************
                    i = 0 : j = 0 : iProdWipSheetCount = 0 : booCompleted = False
                    arrData = Nothing : R1 = Nothing : drTab = Nothing

                    drTab = dt1.Select("BERTab = 0")

                    iProdWipSheetCount = Math.Ceiling(drTab.Length / (iMaxExcelRow - 1))

                    For k = 0 To iProdWipSheetCount - 1
                        If booCompleted = True Then Exit For

                        objSheet = objBook.Sheets.Add()
                        'objSheet.Activate()
                        objSheet.Name = "Prod WIP " & k + 1
                        objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape
                        objExcel.Columns("A").NumberFormat = "@"
                        objExcel.ActiveWindow.FreezePanes = False
                        objExcel.Range("A2:" & Generic.CalExcelColLetter(dt1.Columns.Count - 2) & "2").Select()
                        objExcel.ActiveWindow.FreezePanes = True

                        ReDim arrData(iMaxExcelRow, dt1.Columns.Count - 2) : i = 0 : j = 0

                        For i = 0 To iMaxExcelRow - 2
                            If ((k * (iMaxExcelRow - 1)) + i) >= drTab.Length Then
                                booCompleted = True : Exit For
                            End If

                            R1 = drTab((k * (iMaxExcelRow - 1)) + i)
                            For j = 0 To dt1.Columns.Count - 3
                                If i = 0 Then arrData(i, j) = dt1.Columns(j).Caption
                                arrData(i + 1, j) = R1(dt1.Columns(j).Caption)
                                If dt1.Columns(j).Caption = "Days to be expired" AndAlso R1("Warranty coverage by").ToString.Trim.Length > 0 Then arrData(i + 1, j) = DateDiff(DateInterval.Day, CDate(R1("Today")), CDate(R1("Warranty coverage by")))
                            Next j
                        Next i

                        objSheet.Range("A1", Generic.CalExcelColLetter(dt1.Columns.Count - 2) & (i + 1)).Value = arrData

                        '*****************************************
                        'Set horizontal alignment for the header
                        '*****************************************
                        objSheet.Range("A1:" & Generic.CalExcelColLetter(dt1.Columns.Count - 2) & "1").Select()
                        With objExcel.Selection
                            .WrapText = True
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlTop
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        With objExcel.Selection.Interior
                            .ColorIndex = 37
                            .Pattern = Excel.Constants.xlSolid
                        End With

                        'Set Font
                        With objExcel.Selection
                            .Font.Name = "Microsoft Sans Serif"
                        End With

                        '*****************************************
                        'Set column widths
                        '*****************************************
                        objSheet.Cells.EntireColumn.AutoFit()
                        objSheet.Cells.EntireRow.AutoFit()
                    Next k
                End If

                arrData = Nothing : R1 = Nothing : drTab = Nothing

                MsgBox("Completed.")

            Catch ex As Exception
                Throw New Exception("TracFone.Admin.LoadWIPSummary(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt2)
                arrData = Nothing
                R1 = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '****************************************************************************************
        Private Shared Function GetWIP(ByVal booDetails As Boolean) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt1, dt2, dtModels, dtModelStatus As DataTable
            Dim R1, R2, dr() As DataRow
            Dim i As Integer

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                If booDetails Then
                    'SEPARATE QUERY INTO 2 TO HELP WITH PERFORMANCE - ALOT FASTER
                    strSql = "SELECT a.Model_ID, Device_SN as 'Serial Number', model_desc as 'Model Desc.', '=VLOOKUP(B2,Summary!A:B,2,0)' as 'Pss Classification', '=VLOOKUP(B2,Summary!A:C,3,0)' as 'Customer Classification' " & Environment.NewLine
                    strSql &= ", wo_custwo as 'Order No.' " & Environment.NewLine
                    strSql &= ", Device_DateRec as 'Received Date', WorkStationEntryDt as 'Workstation Entry Date' " & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= ", if (cc_desc is null,'', if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, '')) AS 'Line' " & Environment.NewLine
                    strSql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty?'" & Environment.NewLine
                    strSql &= ", if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '') as 'Warranty coverage by'" & Environment.NewLine
                    strSql &= ", 0 as 'Days to be expired' " & Environment.NewLine
                    strSql &= ", a.Device_Laborcharge as 'Labor', a.Device_Partcharge as 'Part Charge' " & Environment.NewLine
                    strSql &= ", SUM(dbill_avgcost) as 'Part Cost' " & Environment.NewLine
                    strSql &= ", '' as 'Ship Box'" & Environment.NewLine
                    strSql &= ", if(Device_DateShip is null, '', Device_DateShip) as 'Prod Completed Date' " & Environment.NewLine
                    strSql &= ", IF(G.WHLocation IS NULL, '', G.WHLocation) AS WHLocation  " & Environment.NewLine
                    strSql &= ", F.BoxID as 'Rec Box'" & Environment.NewLine
                    strSql &= ", 0 as 'BERTab' " & Environment.NewLine
                    strSql &= ", date_format(now(), '%Y-%m-%d') as 'Today'" & Environment.NewLine
                    strSql &= "FROM tdevice a " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id and a.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tcostcenter c ON a.cc_id = c.cc_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder e on e.wo_id = a.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN edi.titem F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN edi.twarehousebox G ON F.wb_id = G.wb_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill db on a.device_id = db.device_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & " AND a.Device_DateShip is null " & Environment.NewLine
                    strSql &= "GROUP BY " & Environment.NewLine
                    strSql &= "a.Model_ID, Device_SN,model_desc,wo_custwo,Device_DateRec,WorkStationEntryDt,WorkStation," & Environment.NewLine
                    strSql &= "if (cc_desc is null,'',if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, ''))," & Environment.NewLine
                    strSql &= "if(Device_ManufWrty = 1, 'Yes', 'No')," & Environment.NewLine
                    strSql &= "if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '')," & Environment.NewLine
                    strSql &= "a.Device_Laborcharge,a.Device_Partcharge," & Environment.NewLine
                    strSql &= "if(Device_DateShip is null, '', Device_DateShip)," & Environment.NewLine
                    strSql &= "IF(G.WHLocation IS NULL, '', G.WHLocation)," & Environment.NewLine
                    strSql &= "F.BoxID" & Environment.NewLine
                    dt1 = objDataProc.GetDataTable(strSql)

                    strSql = "SELECT a.Model_ID, Device_SN as 'Serial Number', model_desc as 'Model Desc.', '=VLOOKUP(B2,Summary!A:B,2,0)' as 'Pss Classification', '=VLOOKUP(B2,Summary!A:C,3,0)' as 'Customer Classification' " & Environment.NewLine
                    strSql &= ", wo_custwo as 'Order No.' " & Environment.NewLine
                    strSql &= ", Device_DateRec as 'Received Date', WorkStationEntryDt as 'Workstation Entry Date' " & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= ", if (cc_desc is null,'', if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, '')) AS 'Line' " & Environment.NewLine
                    strSql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty?'" & Environment.NewLine
                    strSql &= ", if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '') as 'Warranty coverage by'" & Environment.NewLine
                    strSql &= ", 0 as 'Days to be expired' " & Environment.NewLine
                    strSql &= ", a.Device_Laborcharge as 'Labor', a.Device_Partcharge as 'Part Charge' " & Environment.NewLine
                    strSql &= ", SUM(dbill_avgcost) as 'Part Cost' " & Environment.NewLine
                    strSql &= ", IF(Pallett_Name is null, '', Pallett_Name) as 'Ship Box'" & Environment.NewLine
                    strSql &= ", if(Device_DateShip is null, '', Device_DateShip) as 'Prod Completed Date' " & Environment.NewLine
                    strSql &= ", IF(G.WHLocation IS NULL, '', G.WHLocation) AS WHLocation  " & Environment.NewLine
                    strSql &= ", F.BoxID as 'Rec Box'" & Environment.NewLine
                    strSql &= ", if(Device_DateShip is not null and Pallet_ShipType = 1, 1, 0) as 'BERTab' " & Environment.NewLine
                    strSql &= ", date_format(now(), '%Y-%m-%d') as 'Today'" & Environment.NewLine
                    strSql &= "FROM tdevice a " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id and a.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tcostcenter c ON a.cc_id = c.cc_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder e on e.wo_id = a.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN edi.titem F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett H ON a.Pallett_ID  = H.Pallett_ID" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN edi.twarehousebox G ON F.wb_id = G.wb_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill db on a.device_id = db.device_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & " AND a.Device_DateShip is not null AND H.Pkslip_ID is null " & Environment.NewLine
                    strSql &= "GROUP BY " & Environment.NewLine
                    strSql &= "a.Model_ID, Device_SN,model_desc,wo_custwo,Device_DateRec,WorkStationEntryDt,WorkStation," & Environment.NewLine
                    strSql &= "if (cc_desc is null,'',if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, ''))," & Environment.NewLine
                    strSql &= "if(Device_ManufWrty = 1, 'Yes', 'No')," & Environment.NewLine
                    strSql &= "if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '')," & Environment.NewLine
                    strSql &= "a.Device_Laborcharge,a.Device_Partcharge," & Environment.NewLine
                    strSql &= "if(Device_DateShip is null, '', Device_DateShip)," & Environment.NewLine
                    strSql &= "IF(G.WHLocation IS NULL, '', G.WHLocation)," & Environment.NewLine
                    strSql &= "F.BoxID" & Environment.NewLine
                    Debug.Write(strSql)
                    dt2 = objDataProc.GetDataTable(strSql)

                    'merge table dt2 to table dt1
                    For Each R1 In dt2.Rows
                        dt1.ImportRow(R1)
                    Next
                    dt1.AcceptChanges()

                    ''update model status
                    'dtModelStatus = getModelStatus()
                    'For Each R1 In dt1.Rows
                    '    Dim filteredRows As DataRow()
                    '    filteredRows = dtModelStatus.Select("Model_ID = " & R1("Model_ID"))
                    '    For Each R2 In filteredRows
                    '        R1.BeginEdit()
                    '        R1("Pss Classification") = R2("Pss Classification")
                    '        R1("Customer Classification") = R2("Customer Classification")
                    '        R1.EndEdit()
                    '        Exit For 'it should be one row in filteredRows, exit now
                    '    Next
                    'Next

                    dt1.Columns.Remove("Model_ID") : dt1.AcceptChanges()
                Else
                    'SEPARATE QUERY INTO 2 TO HELP WITH PERFORMANCE - ALOT FASTER
                    strSql = "SELECT Device_SN as 'Serial Number', model_desc as 'Model Desc.', '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= "FROM tdevice a " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine
                    strSql &= "AND a.Device_DateShip is null " & Environment.NewLine
                    dt1 = objDataProc.GetDataTable(strSql)

                    strSql = "SELECT Device_SN as 'Serial Number', model_desc as 'Model Desc.', '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= "FROM tpallett INNER JOIN tdevice a ON tpallett.Pallett_ID = a.Pallett_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "WHERE tpallett.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & Environment.NewLine
                    strSql &= "AND a.Device_DateShip is not null AND tpallett.Pkslip_ID is null " & Environment.NewLine
                    dt2 = objDataProc.GetDataTable(strSql)
                    For Each R1 In dt2.Rows
                        dt1.ImportRow(R1)
                    Next
                    dt1.AcceptChanges()
                End If

                'TAKE TOO LONG TO DO THIS
                ''Add Model Clasification
                ' dtModels = GetTFModelClassification(objDataProc)
                'For Each R1 In dtModels.Rows
                '    dr = dt1.Select("Model_ID = " & R1("Model_ID"))
                '    For i = 0 To dr.Length - 1
                '        dr(i).BeginEdit()
                '        dr(i)("Pss Classification") = R1("Pss Classification")
                '        dr(i)("Customer Classification") = R1("Customer Classification")
                '        dr(i).EndEdit()
                '    Next i
                'Next R1

                dt1.AcceptChanges()

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1) : Generic.DisposeDT(dt1) : Generic.DisposeDT(dtModels)
            End Try
        End Function

        '****************************************************************************************
        Public Shared Function getModelStatus() As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.Model_ID, A.EffectiveDate, IF(B.Dcode_LDesc is null, '', B.Dcode_LDesc) as 'Pss Classification'" & Environment.NewLine
                strSql &= ", IF(C.Dcode_LDesc is null, '', C.Dcode_LDesc) as 'Customer Classification'" & Environment.NewLine
                strSql &= "FROM custmodelclassification A" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail B ON A.Pss_Dcode_ID = B.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail C ON A.Cust_Dcode_ID = C.Dcode_ID" & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & " and A.EffectiveDate <= now()"
                strSql &= "ORDER BY A.Model_ID, A.EffectiveDate desc;"

                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''****************************************************************************************
        'Public Shared Function GetTFModelClassification(ByRef objDataProc As DBQuery.DataProc) As DataTable
        '    Dim strSql As String = ""
        '    Dim dtModels, dtModelStatus As DataTable
        '    Dim R1, R2 As DataRow
        '    Dim i As Integer

        '    Try
        '        If IsNothing(objDataProc) Then objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

        '        strSql = "SELECT A.Model_ID, Model_Desc as Model, '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
        '        strSql &= "From tmodel A INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID and B.Cust_ID = " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
        '        strSql &= "WHERE A.Prod_ID = 2 AND B.Cust_MaterialCategory = 'PHONE' Order by Model_Desc "
        '        dtModels = objDataProc.GetDataTable(strSql)

        '        strSql = "SELECT A.Model_ID, A.EffectiveDate, IF(B.Dcode_LDesc is null, '', B.Dcode_LDesc) as 'Pss Classification'" & Environment.NewLine
        '        strSql &= ", IF(C.Dcode_LDesc is null, '', C.Dcode_LDesc) as 'Customer Classification'" & Environment.NewLine
        '        strSql &= "FROM custmodelclassification A" & Environment.NewLine
        '        strSql &= "LEFT OUTER JOIN lcodesdetail B ON A.Pss_Dcode_ID = B.Dcode_ID" & Environment.NewLine
        '        strSql &= "LEFT OUTER JOIN lcodesdetail C ON A.Cust_Dcode_ID = C.Dcode_ID" & Environment.NewLine
        '        strSql &= "WHERE A.Cust_ID = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & " and A.EffectiveDate <= now()"
        '        dtModelStatus = objDataProc.GetDataTable(strSql)

        '        For Each R1 In dtModels.Rows
        '            R1.BeginEdit()

        '            If dtModelStatus.Select("Model_ID = " & R1("Model_ID"), "EffectiveDate DESC").Length > 0 Then
        '                R2 = dtModelStatus.Select("Model_ID = " & R1("Model_ID"), "EffectiveDate DESC")(0)
        '                R1("Pss Classification") = R2("Pss Classification")
        '                R1("Customer Classification") = R2("Customer Classification")
        '            End If
        '            R1.EndEdit()
        '        Next R1

        '        Return dtModels
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dtModels) : Generic.DisposeDT(dtModelStatus)
        '    End Try
        'End Function

        '****************************************************************************************
        Private Shared Function GetWIPSummary(ByVal dtWipDetails As DataTable) As DataTable
            Dim strSql As String, strPssClassification As String = "", strCustClassification As String = ""
            Dim dtModels, dtWipBucket, dtModelStatus As DataTable
            Dim R1, R2, drZero() As DataRow
            Dim i As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.Model_ID, Model_Desc as Model, '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                strSql &= "From tmodel A INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID and B.Cust_ID = " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "WHERE A.Prod_ID = 2 AND B.Cust_MaterialCategory = 'PHONE' Order by Model_Desc "
                dtModels = objDataProc.GetDataTable(strSql)
                'dtModels = GetTFModelClassification(objDataProc)

                dtWipBucket = GetWorkFlow(TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)
                For Each R1 In dtWipBucket.Rows
                    dtModels.Columns.Add(New DataColumn(R1("Bucket"), System.Type.GetType("System.Int32")))
                Next R1
                dtModels.Columns.Add(New DataColumn("Total", System.Type.GetType("System.Int32")))
                dtModels.AcceptChanges()

                'strSql = "SELECT A.Model_ID, A.EffectiveDate, IF(B.Dcode_LDesc is null, '', B.Dcode_LDesc) as 'Pss Classification'" & Environment.NewLine
                'strSql &= ", IF(C.Dcode_LDesc is null, '', C.Dcode_LDesc) as 'Customer Classification'" & Environment.NewLine
                'strSql &= "FROM custmodelclassification A" & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail B ON A.Pss_Dcode_ID = B.Dcode_ID" & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail C ON A.Cust_Dcode_ID = C.Dcode_ID" & Environment.NewLine
                'strSql &= "WHERE A.Cust_ID = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & " and A.EffectiveDate <= now()"

                strSql = "SELECT A.Model_ID, A.EffectiveDate, IF(B.Status_ID is null, '', D.assign_text) as 'Pss Classification'" & Environment.NewLine
                strSql &= " , IF(C.Dcode_LDesc is null, '', C.Dcode_LDesc) as 'Customer Classification'" & Environment.NewLine
                strSql &= " FROM custmodelclassification A" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN COGS.tmodel_properties B ON A.Model_ID = B.Model_ID And B.cust_ID=" & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= " LEFT OUTER JOIN cogs.ldevicestatus D ON B.Status_ID = D.lassign_id" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN lcodesdetail C ON A.Cust_Dcode_ID = C.Dcode_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & " and A.EffectiveDate <= now();" & Environment.NewLine


                dtModelStatus = objDataProc.GetDataTable(strSql)

                For Each R1 In dtModels.Rows
                    R1.BeginEdit()
                    For i = 4 To dtModels.Columns.Count - 1
                        If dtWipDetails.Select("[Model Desc.] = '" & R1("Model") & "' AND [Workstation] = '" & dtModels.Columns(i).Caption & "'").Length > 0 Then
                            R1(i) = dtWipDetails.Select("[Model Desc.] = '" & R1("Model") & "' AND [Workstation] = '" & dtModels.Columns(i).Caption & "'").Length
                        End If
                    Next i

                    If dtWipDetails.Select("[Model Desc.] = '" & R1("Model") & "' ").Length > 0 Then R1("Total") = dtWipDetails.Select("[Model Desc.] = '" & R1("Model") & "' ").Length Else R1("Total") = 0

                    If dtModelStatus.Select("Model_ID = " & R1("Model_ID"), "EffectiveDate DESC").Length > 0 Then
                        R2 = dtModelStatus.Select("Model_ID = " & R1("Model_ID"), "EffectiveDate DESC")(0)
                        R1("Pss Classification") = R2("Pss Classification")
                        R1("Customer Classification") = R2("Customer Classification")
                    End If

                    R1.EndEdit()
                Next R1
                dtModels.Columns.Remove("Model_ID") : dtModels.AcceptChanges()

                drZero = dtModels.Select("Total = 0")
                For i = 0 To drZero.Length - 1
                    dtModels.Rows.Remove(drZero(i))
                Next i
                dtModels.AcceptChanges()

                i = 0 'Remove Column has zero total
                While i < dtModels.Columns.Count
                    Dim strColName As String = dtModels.Columns(i).Caption.Trim
                    If strColName <> "Model" AndAlso strColName <> "Total" AndAlso strColName <> "Pss Classification" AndAlso strColName <> "Customer Classification" Then
                        If IsDBNull(dtModels.Compute("Sum([" & dtModels.Columns(i).Caption & "])", "")) OrElse dtModels.Compute("Sum([" & dtModels.Columns(i).Caption & "])", "") = 0 Then
                            dtModels.Columns.Remove(dtModels.Columns(i).Caption)
                        Else
                            i += 1
                        End If
                    Else
                        i += 1
                    End If
                End While

                dtModels.AcceptChanges()

                Return dtModels
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDataProc) Then objDataProc = Nothing
            End Try
        End Function

        '****************************************************************************************
        Private Shared Function GetWorkFlow(ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT WorkFlowStation as 'Bucket' FROM wipreportbucket WHERE " & iCustID & "Active = 1 ORDER BY `" & iCustID & "`" & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDataProc) Then objDataProc = Nothing
            End Try
        End Function

        '****************************************************************************************
        Public Shared Function CreateRandomPickBillGroup(ByVal booUseDockShipDate As Boolean, ByVal strStartDate As String, ByVal strEndDate As String)
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook    ' Excel workbook
            Dim objSheet As Excel.Worksheet   ' Excel Worksheet
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i, j As Integer
            Dim arrData(0, 0) As Object
            Dim strSql, strFileName As String
            Dim objDataProc As DBQuery.DataProc
            Dim objSpecialBilling As New SpecialBilling()
            'Dim objSaveFileDialog As New SaveFileDialog()

            Try
                strSql = "SELECT Model_Desc as 'Model', Pallett_Name as 'Box', Device_ID as 'ID', Device_SN as 'S/N', '' as BG, tpallett.Cust_ID, tdevice.Model_ID " & Environment.NewLine
                strSql &= "FROM tpallett INNER JOIN tdevice ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                If booUseDockShipDate Then strSql &= "INNER JOIN tpackingslip ON tpallett.Pkslip_ID = tpackingslip.Pkslip_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallet_ShipType = 0 " & Environment.NewLine
                If booUseDockShipDate Then
                    strSql &= "AND pkslip_createDt Between '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                Else
                    strSql &= "AND Device_Dateship Between '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                End If
                'strSql &= "AND tdevice.Model_ID in ( 2535, 2536 ) "
                strSql &= "ORDER BY Model_Desc, Pallett_Name, Device_ID"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt1 = objDataProc.GetDataTable(strSql)
                If dt1.Rows.Count = 0 Then
                    MsgBox("There's no data for report.", MsgBoxStyle.Information)
                Else
                    For Each R1 In dt1.Rows
                        R1.BeginEdit()
                        R1("BG") = objSpecialBilling.GetRandomBillGroup(R1("ID"), R1("Cust_ID"), R1("Model_ID"), "")
                        R1.EndEdit()
                    Next R1
                    dt1.Columns.Remove("Cust_ID") : dt1.Columns.Remove("Model_ID") : dt1.AcceptChanges()
                    '******************************************************************
                    'Instantiate the excel related objects
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True              'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    '  objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                    i = 0

                    ReDim arrData(dt1.Rows.Count + 1, dt1.Columns.Count)
                    For i = 0 To dt1.Rows.Count - 1

                        For j = 0 To dt1.Columns.Count - 1
                            'Header
                            If i = 0 Then arrData(i, j) = dt1.Columns(j).Caption
                            arrData(i + 1, j) = dt1.Rows(i)(j)
                        Next j
                    Next i

                    objSheet.Columns("D:D").Select()
                    objExcel.Selection.NumberFormat = "@"

                    Dim strEndCol As String = Generic.CalExcelColLetter(dt1.Columns.Count)
                    objSheet.Range("A1", strEndCol & (dt1.Rows.Count + 1)).Value = arrData

                    objSheet.Cells.EntireColumn.AutoFit()
                    objSheet.Cells.EntireRow.AutoFit()
                    '*****************************************

                    '************************************************
                    'Add report header
                    objSheet.Range("A1:" & strEndCol & "1").Select()
                    With objExcel.Selection
                        '.MergeCells = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        '.font.bold = True
                        .Font.Size = 12
                        .Font.Name = "Verdana"
                        .Font.ColorIndex = 23        'Red
                    End With

                    '*************************************************
                    objExcel.Sheets("Sheet2").Delete()
                    objExcel.Sheets("Sheet3").Delete()

                    'strFileName = "RandomPickBillGroup"
                    'objSaveFileDialog.DefaultExt = "xlsx"
                    'objSaveFileDialog.FileName = strFileName & ".xlsx"
                    'objSaveFileDialog.ShowDialog()
                    'strFileName = objSaveFileDialog.FileName
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1) : objSpecialBilling = Nothing : objDataProc = Nothing
                arrData = Nothing

                'If Not IsNothing(objSaveFileDialog) Then
                '    objSaveFileDialog.Dispose()
                'End If
                objDataProc = Nothing
                'If Not IsNothing(objSheet) Then
                '    PSS.Data.Buisness.Generic.NAR(objSheet)
                'End If
                'If Not IsNothing(objBook) Then
                '    objBook.Close(False)
                '    PSS.Data.Buisness.Generic.NAR(objBook)
                'End If
                'If Not IsNothing(objXL) Then
                '    objXL.Quit()
                '    PSS.Data.Buisness.Generic.NAR(objXL)
                'End If
                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Function

        '****************************************************************************************
        Public Function RunPreEvalReport(ByVal iCustID As Integer, ByVal strWHBoxName As String, _
                                         ByVal strCustModel As String, ByVal strWorkStation As String, ByRef dsOutput As DataSet)
            'Excel Related variables
            'Dim objExcel As Excel.Application    ' Excel application
            'Dim objBook As Excel.Workbook     ' Excel workbook
            'Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim rng As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim oArrData As Object(,)
            Dim objSaveFileDialog As New SaveFileDialog()
            Dim strFileName As String
            Dim dtTmp As DataTable
            Dim RowsNum As Integer
            Dim ColsNum As Integer

            Dim Row, drTab() As DataRow
            Dim i, j, k As Integer
            Dim bHasData As Boolean = False
            Dim ds As New DataSet()
            Dim strModelIDs As String = ""
            'Dim dt As DataTable

            Try

                If strCustModel.Trim.Length > 0 Then
                    strModelIDs = Me.GetModelIDsByCustModel(iCustID, strCustModel)
                    If strModelIDs.Trim.Length = 0 Then Throw New Exception("Can't define model ID.")
                End If


                ds = Me.GetPreEvalReportData(iCustID, strWHBoxName, strModelIDs, strWorkStation, bHasData)
                dsOutput = ds
                If Not bHasData Then Throw New Exception("No data for your selection.")

                'POPULATE DATA IN DATASET TO EXCEL  
                xlApp.Visible = False : xlApp.DisplayAlerts = False
                xlApp = New Excel.Application()
                xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)

                'Detail sheet
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(1), Excel._Worksheet)

                dtTmp = ds.Tables(0) 'details
                RowsNum = dtTmp.Rows.Count
                ColsNum = dtTmp.Columns.Count
                ReDim oArrData(RowsNum + 1, ColsNum)

                'get all original col names so that if dtTmp has no rows, excel still have header
                For j = 0 To dtTmp.Columns.Count - 1
                    oArrData(0, j) = dtTmp.Columns(j).ColumnName
                Next

                'Get actual col names if any 
                For i = 0 To dtTmp.Rows.Count - 1
                    For j = 0 To dtTmp.Columns.Count - 1
                        If i = 0 Then
                            For Each Row In ds.Tables(1).Rows 'Billcode col desc
                                If Row("ColName") = dtTmp.Columns(j).ColumnName Then
                                    oArrData(i, j) = Row("ColDesc") 'dtTmp.Columns(j).ColumnName
                                    Exit For
                                Else
                                    oArrData(i, j) = dtTmp.Columns(j).ColumnName
                                End If
                            Next
                        End If
                        oArrData(i + 1, j) = dtTmp.Rows(i)(j)
                    Next j
                Next i

                For i = 1 To dtTmp.Columns.Count
                    xlWorkSheet.Columns(i).NumberFormat = "@"
                    If i > 4 Then
                        xlWorkSheet.Columns(i).NumberFormat = "$#,##.00"
                    End If
                Next

                xlWorkSheet.Range("A1" & ":" & CalExcelColLetter(dtTmp.Columns.Count) & (dtTmp.Rows.Count + 1)).Value = oArrData
                xlWorkSheet.Name = "Details"

                'Auto Fit
                xlWorkSheet.Cells.EntireColumn.AutoFit()
                xlWorkSheet.Cells.EntireRow.AutoFit()

                'Summary
                xlWorkSheet = DirectCast(xlWorkBook.Sheets(2), Excel._Worksheet)

                dtTmp = ds.Tables(2) 'summary table
                RowsNum = dtTmp.Rows.Count
                ColsNum = dtTmp.Columns.Count
                ReDim oArrData(RowsNum + 1, ColsNum)

                'For i = 0 To dtTmp.Rows.Count - 1
                '    For j = 0 To dtTmp.Columns.Count - 1
                '        If i = 0 Then oArrData(i, j) = dtTmp.Columns(j).ColumnName
                '        oArrData(i + 1, j) = dtTmp.Rows(i)(j)
                '    Next j
                'Next i
                For i = 0 To dtTmp.Rows.Count - 1
                    For j = 0 To dtTmp.Columns.Count - 1
                        If i = 0 Then
                            For Each Row In ds.Tables(1).Rows 'Billcode col desc
                                If Row("ColName") = dtTmp.Columns(j).ColumnName Then
                                    oArrData(i, j) = Row("ColDesc") 'dtTmp.Columns(j).ColumnName
                                    Exit For
                                Else
                                    oArrData(i, j) = dtTmp.Columns(j).ColumnName
                                End If
                            Next
                        End If
                        oArrData(i + 1, j) = dtTmp.Rows(i)(j)
                    Next j
                Next i

                xlWorkSheet.Columns(1).NumberFormat = "@"
                xlWorkSheet.Columns(ColsNum).NumberFormat = "$#,##.00"
                xlWorkSheet.Columns(ColsNum - 1).NumberFormat = "$#,##.00"


                xlWorkSheet.Range("A1" & ":" & CalExcelColLetter(dtTmp.Columns.Count) & (dtTmp.Rows.Count + 1)).Value = oArrData
                xlWorkSheet.Name = "Summary"

                'Auto Fit
                xlWorkSheet.Cells.EntireColumn.AutoFit()
                xlWorkSheet.Cells.EntireRow.AutoFit()


                'Save file
                objSaveFileDialog.DefaultExt = "xls"
                objSaveFileDialog.FileName = "Pre-Evaluation Report_" & strWHBoxName & "_" & Format(Now(), "yyyyMMdd") & ".xls"
                objSaveFileDialog.ShowDialog()
                strFileName = objSaveFileDialog.FileName

                If strFileName.Trim.Length = 0 Then
                    MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If strFileName.IndexOf("\") < 0 Then Exit Function
                    If File.Exists(strFileName) = True Then Kill(strFileName)
                    xlWorkBook.SaveAs(strFileName)
                    MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw New Exception("TracFone.Reports.RunPreEvalReport(): " & Environment.NewLine & ex.Message.ToString)
            Finally

                'Generic.DisposeDT(dtReceived) : Generic.DisposeDT(dtCharge)
                'Generic.DisposeDT(dtServiceType) : Generic.DisposeDT(dtOutput)
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
                'Catch ex As Exception
                '    Throw New Exception("TracFone.Reports.RunPreEvalReport(): " & Environment.NewLine & ex.Message.ToString)
                'Finally
                '    Generic.DisposeDS(ds)
                '    arrData = Nothing : R1 = Nothing
                '    GC.Collect() : GC.WaitForPendingFinalizers()
                '    GC.Collect() : GC.WaitForPendingFinalizers()
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

        '****************************************************************************************
        Public Function GetModelIDsByCustModel(ByVal iCustID As Integer, ByVal strCustModel As String) As String
            Dim strSql As String = "", strModelIDs As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT A.Model_ID FROM tmodel A " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "WHERE B.Cust_ID = " & iCustID & " AND cust_model_number = '" & strCustModel & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If strModelIDs.Trim.Length > 0 Then strModelIDs &= ", "
                    strModelIDs &= R1("Model_ID")
                Next R1

                Return strModelIDs
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************
        Private Function GetPreEvalReportData(ByVal iCustID As Integer, ByVal strWHBoxName As String, _
                                              ByVal ModelIDs As String, ByVal strWorkStation As String, _
                                              ByRef bHasData As Boolean) As DataSet
            Dim strSql As String = ""
            Dim dtDetails, dtSummary, dtBillAwap, dtDetails_Sort As DataTable
            Dim ds As New DataSet()
            Dim row, row2, newRow As DataRow
            Dim rowView As DataRowView
            Dim col As DataColumn
            Dim dtBillCodeColumns As DataTable = getBillCodeColumnTable()
            Dim arrLstBillCodes As New ArrayList()
            Dim arrLstBillCodesColumnNames As New ArrayList()
            Dim i As Integer
            Dim vSumPart, vTotal As Double
            Dim vBatteryCoverCharge As Double = 3.04
            Dim vLaborCharge_Cosm As Double = 9.5
            Dim vLaborCharge_Func As Double = 12.5
            Dim vLaborCharge_NoPart As Double = 4.5

            Try
                'Old
                'strSql = "SELECT A.Device_ID, A.Model_ID, E.BoxID as 'Box ID', A.Device_SN as 'SN', F.Model_Desc as Model, D.WorkStation as 'Work Station'" & Environment.NewLine
                'strSql &= "FROM tdevice A" & Environment.NewLine
                'strSql &= "INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tdevicebillawap C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tcellopt D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN edi.titem E ON A.Device_ID = E.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tmodel F ON A.Model_ID = F.Model_ID" & Environment.NewLine
                'strSql &= "WHERE B.Cust_ID = " & iCustID
                'If strWHBoxName.Length > 0 Then strSql &= "AND E.BoxID = '" & strWHBoxName & "'" & Environment.NewLine
                'If ModelIDs.Length > 0 Then strSql &= "AND A.Model_ID in ( " & ModelIDs & " ) " & Environment.NewLine
                'If strWorkStation.Length > 0 Then strSql &= "AND D.WorkStation = '" & ModelIDs & "' " & Environment.NewLine
                'dtDetails = Me._objDataProc.GetDataTable(strSql)

                'All device in the box
                strSql = "select A.BoxID as 'Box ID',B.Device_SN AS SN,C.Model_Desc as Model,D.WorkStation as 'Work Station'" & Environment.NewLine
                strSql &= ", if(substring(Trim(C.Model_Desc),Length(Trim(C.Model_Desc))-3,4)='_FUN', 'Func','Cosm') AS 'ModelType'" & Environment.NewLine
                strSql &= ",B.Device_ID as 'Device_ID',C.model_ID from edi.titem A" & Environment.NewLine
                strSql &= " inner join tdevice B on A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " inner join tmodel C on B.model_ID=C.model_ID" & Environment.NewLine
                strSql &= " inner join tcellopt D on A.device_ID=D.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation E ON B.Loc_ID = E.Loc_ID" & Environment.NewLine
                strSql &= "WHERE E.Cust_ID = " & iCustID & Environment.NewLine
                If strWHBoxName.Length > 0 Then strSql &= "AND A.BoxID = '" & strWHBoxName & "'" & Environment.NewLine
                If ModelIDs.Length > 0 Then strSql &= "AND B.Model_ID in ( " & ModelIDs & " ) " & Environment.NewLine
                If strWorkStation.Length > 0 Then strSql &= "AND D.WorkStation = '" & strWorkStation & "' " & Environment.NewLine
                dtDetails = Me._objDataProc.GetDataTable(strSql)

                'Only those have cost charged in the box: tdevicebillawap
                'strSql = "SELECT E.BoxID as 'Box ID',  A.Device_SN as 'SN', F.Model_Desc as Model,D.WorkStation as 'Work Station'" & Environment.NewLine
                'strSql &= ", if(substring(Trim(F.Model_Desc),Length(Trim( F.Model_Desc))-3,4)='_FUN', 'Func','Cosm') AS 'ModelType'" & Environment.NewLine
                'strSql &= ",  A.Device_ID,F.model_ID" & Environment.NewLine
                'strSql &= " FROM tdevice A" & Environment.NewLine
                'strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                'strSql &= " INNER JOIN tdevicebillawap C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                'strSql &= " INNER JOIN tcellopt D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                'strSql &= " INNER JOIN edi.titem E ON A.Device_ID = E.Device_ID" & Environment.NewLine
                'strSql &= " INNER JOIN tmodel F ON A.Model_ID = F.Model_ID" & Environment.NewLine
                'strSql &= "WHERE B.Cust_ID = " & iCustID & Environment.NewLine
                'If strWHBoxName.Length > 0 Then strSql &= "AND E.BoxID = '" & strWHBoxName & "'" & Environment.NewLine
                'If ModelIDs.Length > 0 Then strSql &= "AND A.Model_ID in ( " & ModelIDs & " ) " & Environment.NewLine
                'If strWorkStation.Length > 0 Then strSql &= "AND D.WorkStation = '" & strWorkStation & "' " & Environment.NewLine
                'strSql &= " GROUP BY E.BoxID,A.Device_SN,F.Model_Desc,D.WorkStation, if(substring(Trim(F.Model_Desc),Length(Trim( F.Model_Desc))-3,4)='_FUN', 'Func','Cosm'), A.Device_ID,F.model_ID;"
                'dtDetails = Me._objDataProc.GetDataTable(strSql)

                If dtDetails.Rows.Count > 0 Then
                    bHasData = True
                Else
                    bHasData = False : Return ds
                End If

                'Old
                'strSql = "SELECT E.BoxID as 'Box ID', A.Device_ID, A.Device_SN, A.Model_ID, F.Model_Desc as Model, D.WorkStation as 'Work Station', C.*" & Environment.NewLine
                'strSql &= "FROM tdevice A" & Environment.NewLine
                'strSql &= "INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tdevicebillawap C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tcellopt D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN edi.titem E ON A.Device_ID = E.Device_ID" & Environment.NewLine
                'strSql &= "INNER JOIN tmodel F ON A.Model_ID = F.Model_ID" & Environment.NewLine
                'strSql &= "WHERE B.Cust_ID = " & iCustID
                'If strWHBoxName.Length > 0 Then strSql &= "AND E.BoxID = '" & strWHBoxName & "'" & Environment.NewLine
                'If ModelIDs.Length > 0 Then strSql &= "AND A.Model_ID in ( " & ModelIDs & " ) " & Environment.NewLine
                'If strWorkStation.Length > 0 Then strSql &= "AND D.WorkStation = '" & ModelIDs & "' " & Environment.NewLine

                strSql = "SELECT E.BoxID as 'Box ID', A.Device_ID AS 'device_ID_Key', A.Device_SN AS SN, A.Model_ID, F.Model_Desc as Model"
                strSql &= ", if(substring(Trim(F.Model_Desc),Length(Trim( F.Model_Desc))-3,4)='_FUN', 'Func','Cosm') AS 'ModelType'"
                strSql &= ", D.WorkStation as 'Work Station', C.*,Concat('C_',C.BillCode_ID) AS 'ColName',G.BillCode_Desc" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebillawap C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.titem E ON A.Device_ID = E.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel F ON A.Model_ID = F.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lBillcodes G ON C.BillCode_ID=G.BillCode_ID" & Environment.NewLine
                strSql &= "WHERE B.Cust_ID = " & iCustID & Environment.NewLine
                If strWHBoxName.Length > 0 Then strSql &= "AND E.BoxID = '" & strWHBoxName & "'" & Environment.NewLine
                If ModelIDs.Length > 0 Then strSql &= "AND A.Model_ID in ( " & ModelIDs & " ) " & Environment.NewLine
                If strWorkStation.Length > 0 Then strSql &= "AND D.WorkStation = '" & strWorkStation & "' " & Environment.NewLine
                strSql &= " ORDER BY C.DBill_AvgCost;"
                dtBillAwap = Me._objDataProc.GetDataTable(strSql)

                'Get unique billcode and col
                For Each row In dtBillAwap.Rows
                    If Not arrLstBillCodes.Contains(row("ColName")) Then
                        arrLstBillCodes.Add(row("ColName"))
                        arrLstBillCodesColumnNames.Add(row("BillCode_Desc"))
                        newRow = dtBillCodeColumns.NewRow
                        newRow("ColName") = row("ColName")
                        newRow("ColDesc") = row("BillCode_Desc")
                        dtBillCodeColumns.Rows.Add(newRow)
                        dtBillCodeColumns.AcceptChanges()
                    End If
                Next

                'Add columns and add the computed values to Detail table
                For i = 0 To arrLstBillCodes.Count - 1
                    dtDetails.Columns.Add(arrLstBillCodes(i), GetType(Double))
                Next
                dtDetails.Columns.Add("Batery Cover", GetType(Double))
                dtDetails.Columns.Add("Parts Total", GetType(Double))
                dtDetails.Columns.Add("Labor Charge", GetType(Double))
                dtDetails.Columns.Add("Total", GetType(Double))

                For Each row In dtDetails.Rows
                    vSumPart = 0 : vTotal = 0
                    row("Batery Cover") = vBatteryCoverCharge
                    If Trim(row("ModelType")).ToUpper = "Cosm".ToUpper Then
                        row("Labor Charge") = vLaborCharge_Cosm
                    ElseIf Trim(row("ModelType")).ToUpper = "Func".ToUpper Then
                        row("Labor Charge") = vLaborCharge_Func
                    End If
                    For Each col In dtDetails.Columns
                        For Each row2 In dtBillAwap.Rows
                            If row2("ColName") = col.ColumnName AndAlso row("Device_ID") = row2("Device_ID_Key") Then
                                row(col.ColumnName) = row2("DBill_AvgCost")
                                vSumPart += row2("DBill_AvgCost")
                                Exit For
                            End If
                        Next
                    Next
                    If vSumPart = 0 Then row("Labor Charge") = vLaborCharge_NoPart
                    row("Parts Total") = vSumPart + row("Batery Cover")
                    vTotal = row("Parts Total") + row("Labor Charge")
                    row("Total") = vTotal
                    dtDetails.AcceptChanges()
                Next
                dtDetails.Columns.Remove("ModelType") : dtDetails.Columns.Remove("Model_ID") : dtDetails.Columns.Remove("Device_ID")

                'summary
                dtSummary = dtDetails.Clone
                dtSummary.Columns.Remove("Parts Total") : dtSummary.Columns.Remove("Labor Charge") : dtSummary.Columns.Remove("Total")
                dtSummary.Columns.Remove("SN") : dtSummary.Columns.Remove("Model") : dtSummary.Columns.Remove("Work Station")

                newRow = dtSummary.NewRow
                For Each col In dtSummary.Columns
                    If Not col.ColumnName.ToUpper = "BOX ID" Then
                        newRow(col.ColumnName) = dtDetails.Compute("Count([" & col.ColumnName & "])", "")
                    End If
                Next
                dtSummary.Rows.Add(newRow) : dtSummary.AcceptChanges()
                dtSummary.Columns.Add("Avg Parts Charge", GetType(Double)) : dtSummary.Columns.Add("Total Avg", GetType(Double))
                dtSummary.Rows(0).Item("Avg Parts Charge") = dtDetails.Compute("Avg([Parts Total])", "")
                dtSummary.Rows(0).Item("Total Avg") = dtDetails.Compute("Avg(Total)", "")
                dtSummary.Rows(0).Item("BOX ID") = strWHBoxName
                dtSummary.AcceptChanges()

                'Sort Total in details table
                Dim v As DataView = dtDetails.DefaultView
                v.Sort = "Total Asc" ',Column3 Asc" 'Desc
                dtDetails_Sort = dtDetails.Clone
                For Each rowView In v
                    row = rowView.Row
                    dtDetails_Sort.ImportRow(row)
                Next

                'Generate dataset
                dtDetails_Sort.TableName = "Details" : ds.Tables.Add(dtDetails_Sort) '0
                dtBillCodeColumns.TableName = "BillcodeColNameDesc" : ds.Tables.Add(dtBillCodeColumns) '1
                dtSummary.TableName = "Summary" : ds.Tables.Add(dtSummary) '2

                Return ds

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dtDetails_Sort) : Generic.DisposeDT(dtBillAwap) : Generic.DisposeDT(dtSummary) : Generic.DisposeDT(dtDetails)
			End Try
        End Function


        '****************************************************************************************
        Private Function getBillCodeColumnTable() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("ColName", GetType(String))
            dTB.Columns.Add("ColDesc", GetType(String))

            Return dTB
        End Function

        '****************************************************************************************
        Public Function RunPartReClaimRpt(ByVal iLocID As Integer, ByVal strReportName As String, ByVal strDateFr As String, ByVal strDateTo As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelReports As ExcelReports

            Try
                strSql = "SELECT Model_Desc as 'Model', Device_SN as 'IMEI', Billcode_Desc as 'BillCode', Part_Number as 'Part #'" & Environment.NewLine
                strSql &= ", Date_Rec as 'Trans Date', User_FullName as 'Trans User', DBillReclaim_RegPartPrice as 'Reg Part Cost'" & Environment.NewLine
                strSql &= ", DBillReclaim_AvgCost as 'Avg Cost', DBillReclaim_StdCost as 'Part Cost'" & Environment.NewLine
                strSql &= "FROM tdevicebill_reclaim A" & Environment.NewLine
                strSql &= "INNER JOIN tdevice B On A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel C On B.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes D On A.Billcode_ID = D.Billcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN security.tusers E ON A.User_ID = E.User_ID" & Environment.NewLine
                strSql &= "WHERE B.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= " AND A.Date_Rec Between '" & strDateFr & "' AND '" & strDateTo & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    objExcelReports = New ExcelReports()
                    objExcelReports.RunSimpleExcelFormat(dt, strReportName & "_" & strDateFr & "_" & strDateTo, New String() {"A", "B", "C", "D"}, New String() {"G", "H", "I"})
                End If
                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objExcelReports = Nothing
            End Try
        End Function

        Public Function RunPartReClaimRpt(ByVal iLocID As Integer, ByVal strReportName As String, ByVal strCustModel As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelReports As ExcelReports

            Try
                strSql = "SELECT Model_Desc as 'Model', Device_SN as 'IMEI', Billcode_Desc as 'BillCode', Part_Number as 'Part #'" & Environment.NewLine
                strSql &= ", Date_Rec as 'Trans Date', User_FullName as 'Trans User', DBillReclaim_RegPartPrice as 'Reg Part Cost'" & Environment.NewLine
                strSql &= ", DBillReclaim_AvgCost as 'Avg Cost', DBillReclaim_StdCost as 'Part Cost'" & Environment.NewLine
                strSql &= " FROM tdevicebill_reclaim A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B On A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C On B.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes D On A.Billcode_ID = D.Billcode_ID" & Environment.NewLine
                strSql &= " INNER JOIN security.tusers E ON A.User_ID = E.User_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation F On B.Loc_ID = F.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map G ON B.Model_ID = G.Model_ID AND F.Cust_ID = G.Cust_ID" & Environment.NewLine
                strSql &= " WHERE B.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= " AND G.cust_model_number = '" & strCustModel & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    objExcelReports = New ExcelReports()
                    objExcelReports.RunSimpleExcelFormat(dt, strReportName & "_" & strCustModel, New String() {"A", "B", "C", "D"}, New String() {"G", "H", "I"})
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
                Generic.DisposeDT(dt) : objExcelReports = Nothing
            End Try
        End Function

        Public Function RunHandSetInvenotryRpt(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, _
                                               ByVal strReportName As String, ByVal iLagEffectiveDate As String) As Integer
            Dim strSql As String = ""
            Dim dtModels, dtModelDetails, dtProduction, dtGroup, dtAging As DataTable
            Dim dtSumary1 As New DataTable(), dtSumary2 As New DataTable(), dtSumary3 As New DataTable()
            Dim dtFilteredRows() As DataRow
            Dim objExcelReports As ExcelReports
            Dim row, row2, rowNew As DataRow
            Dim uniqueGroups As New ArrayList()
            Dim uniqueAging As New ArrayList()
            Dim uniqueDcodeLdesc As New ArrayList()
            Dim i As Integer = 0
            Dim countObject As Object
            Dim ds As New DataSet()

            Try
                'Initial summary table defination
                dtSumary1.Columns.Add("Group", GetType(String))
                dtSumary1.Columns.Add("Count Of Devices", GetType(Integer))

                dtSumary2.Columns.Add("Aging Group", GetType(Integer))
                dtSumary2.Columns.Add("Count Of Devices", GetType(Integer))

                dtSumary3.Columns.Add("Group", GetType(String))
                dtSumary3.Columns.Add("DCode_LDesc", GetType(String))
                dtSumary3.Columns.Add("Count Of Devices", GetType(Integer))

                'Models
                strSql = "SELECT '' AS 'cust_model_number', '' AS 'Model_Desc', '' AS 'Dcode_Ldesc', '' AS 'EffectiveDate',Model_ID, Max(CMC_ID) AS MaxOfCMC_ID" & Environment.NewLine
                strSql &= " FROM custmodelclassification" & Environment.NewLine
                strSql &= " WHERE Cust_ID=" & iCust_ID & " AND EffectiveDate<(CURRENT_DATE - INTERVAL " & iLagEffectiveDate & " DAY)" & Environment.NewLine
                strSql &= " GROUP BY Model_ID;" & Environment.NewLine
                dtModels = Me._objDataProc.GetDataTable(strSql)

                'Model details
                strSql = "SELECT C.cust_model_number,A.Model_Desc, D.Dcode_Ldesc, B.EffectiveDate,A.Model_ID,B.CMC_ID" & Environment.NewLine
                strSql &= " FROM tmodel A" & Environment.NewLine
                strSql &= " INNER JOIN custmodelclassification B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map C ON A.Model_ID = C.model_id" & Environment.NewLine
                strSql &= " INNER JOIN lcodesdetail D ON B.Cust_Dcode_ID = D.Dcode_ID" & Environment.NewLine
                strSql &= " WHERE B.CUST_ID=" & iCust_ID & Environment.NewLine
                strSql &= " ORDER BY A.Model_ID;" & Environment.NewLine
                dtModelDetails = Me._objDataProc.GetDataTable(strSql)

                If dtModels.Rows.Count > 0 Then
                    For Each row In dtModels.Rows 'fill correct required fields
                        dtFilteredRows = dtModelDetails.Select("CMC_ID=" & row("MaxOfCMC_ID"))
                        For Each row2 In dtFilteredRows
                            row.BeginEdit()
                            row("cust_model_number") = row2("cust_model_number") : row("Model_Desc") = row2("Model_Desc")
                            row("Dcode_Ldesc") = row2("Dcode_Ldesc") : row("EffectiveDate") = row2("EffectiveDate")
                            row.AcceptChanges() : Exit For
                        Next
                    Next

                    'Group data
                    strSql = "SELECT * FROM thandset_inventory_groups WHERE Cust_ID=" & iCust_ID & ";"
                    dtGroup = Me._objDataProc.GetDataTable(strSql)

                    'Production data
                    strSql = "SELECT '' AS 'DCode_LDesc',F.Cust_Model_Number,C.Model_Desc,A.Device_SN" & Environment.NewLine
                    strSql &= " ,A.Device_RecWorkDate,A.Device_DateBill,B.WorkStation,B.WorkStationEntryDT,'' AS 'Group'" & Environment.NewLine
                    strSql &= " ,D.BoxID,E.Pallett_Name,E.PAllet_ShipType,A.Device_ID,E.Pallett_ID" & Environment.NewLine
                    strSql &= " ,TO_DAYS(NOW()) - TO_DAYS(A.Device_RecWorkDate) AS 'Aging Days'" & Environment.NewLine
                    strSql &= " ,IF (TO_DAYS(NOW()) - TO_DAYS(A.Device_RecWorkDate)>90, 3, IF(TO_DAYS(NOW()) - TO_DAYS(A.Device_RecWorkDate) <61,1,2)) AS 'Aging Group'" & Environment.NewLine
                    strSql &= " FROM tdevice A" & Environment.NewLine
                    strSql &= " INNER JOIN tcellopt B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                    strSql &= " LEFT JOIN edi.titem D ON A.Device_ID=D.Device_ID" & Environment.NewLine
                    strSql &= " LEFT JOIN tpallett E ON A.Pallett_ID=E.Pallett_ID" & Environment.NewLine
                    strSql &= " INNER JOIN tcustmodel_pssmodel_map F ON  C.Model_ID=F.Model_ID" & Environment.NewLine
                    strSql &= " WHERE A.LOC_ID=" & iLoc_ID & " AND B.WorkStation<>'Intransit' AND E.pkSlip_ID IS NULL;" & Environment.NewLine
                    dtProduction = Me._objDataProc.GetDataTable(strSql)

                    'Fill DCode_LDesc and Group
                    For Each row In dtProduction.Rows
                        dtFilteredRows = dtModels.Select("Model_Desc='" & row("Model_Desc") & "'")
                        For Each row2 In dtFilteredRows
                            row.BeginEdit()
                            row("DCode_LDesc") = row2("DCode_LDesc")
                            row.AcceptChanges() : Exit For
                        Next

                        dtFilteredRows = dtGroup.Select("Classification='" & row("DCode_LDesc") & "' AND WorkStation='" & row("WorkStation") & "'")
                        For Each row2 In dtFilteredRows
                            row.BeginEdit()
                            row("Group") = row2("Group")
                            row.AcceptChanges() : Exit For
                        Next

                        If Not uniqueGroups.Contains(row("Group")) Then uniqueGroups.Add(row("Group"))
                        If Not uniqueAging.Contains(row("Aging Group")) Then uniqueAging.Add(row("Aging Group"))
                        If Trim(row("Group")).ToUpper = "Obsolete".ToUpper Then
                            If Not uniqueDcodeLdesc.Contains(row("DCode_LDesc")) Then uniqueDcodeLdesc.Add(row("DCode_LDesc"))
                        End If
                    Next


                    'Summary 1
                    For i = 0 To uniqueGroups.Count - 1
                        countObject = dtProduction.Compute("Count(Device_ID)", "Group = '" & uniqueGroups(i) & "'")
                        rowNew = dtSumary1.NewRow
                        rowNew("Group") = uniqueGroups(i) : rowNew("Count Of Devices") = countObject
                        dtSumary1.Rows.Add(rowNew)
                    Next
                    'Sort
                    Dim dv1 As New DataView(dtSumary1)
                    dv1.Sort = "Group"
                    Dim dt1 As DataTable
                    dt1 = PSS.Data.Buisness.Generic.DataViewAsDataTable(dv1)
                    dt1.TableName = "Summary SnapShot"

                    'Summary 2
                    dtFilteredRows = dtProduction.Select("GROUP='RU In Repair' OR GROUP='RU Awaiting Repair'")
                    dtAging = dtProduction.Clone
                    For Each row In dtFilteredRows
                        dtAging.ImportRow(row)
                    Next
                    For i = 0 To uniqueAging.Count - 1
                        countObject = dtAging.Compute("Count(Device_ID)", "[Aging Group] = " & uniqueAging(i))
                        rowNew = dtSumary2.NewRow
                        rowNew("Aging Group") = uniqueAging(i) : rowNew("Count Of Devices") = countObject
                        dtSumary2.Rows.Add(rowNew)
                    Next
                    'Sort
                    Dim dv2 As New DataView(dtSumary2)
                    dv2.Sort = "[Aging Group]"
                    Dim dt2 As DataTable
                    dt2 = PSS.Data.Buisness.Generic.DataViewAsDataTable(dv2)
                    dt2.TableName = "Summary Aging"

                    'Summary 3
                    For i = 0 To uniqueDcodeLdesc.Count - 1
                        countObject = dtProduction.Compute("Count(Device_ID)", "GROUP='Obsolete' AND DCode_LDesc='" & uniqueDcodeLdesc(i) & "'")
                        rowNew = dtSumary3.NewRow
                        rowNew("Group") = "Obsolete" : rowNew("DCode_LDesc") = uniqueDcodeLdesc(i) : rowNew("Count Of Devices") = countObject
                        dtSumary3.Rows.Add(rowNew)
                    Next
                    'Sort
                    Dim dv3 As New DataView(dtSumary3)
                    dv3.Sort = "Group, DCode_LDesc"
                    Dim dt3 As DataTable
                    dt3 = PSS.Data.Buisness.Generic.DataViewAsDataTable(dv3)
                    dt3.TableName = "Summary Obsolete"

                    ds.Tables.Add(dt1) : ds.Tables.Add(dt2) : ds.Tables.Add(dt3)

                    'Excel report
                    objExcelReports = New ExcelReports()
                    'objExcelReports.RunSimpleExcelFormat(dtProduction, strReportName) 'Details
                    objExcelReports.RunSimpleExcelFormat_PerSheetPerTable(ds, strReportName) 'Summary ', New String() {"A", "B", "C", "D"})  ',  New String() {"G", "H", "I"}))

                    Generic.DisposeDT(dt1) : Generic.DisposeDT(dt2) : Generic.DisposeDT(dt3)
                End If

                Return dtModels.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtModels) : objExcelReports = Nothing
                Generic.DisposeDT(dtModelDetails) : Generic.DisposeDT(dtProduction)
                Generic.DisposeDT(dtGroup) : Generic.DisposeDT(dtAging)
                Generic.DisposeDT(dtSumary1) : Generic.DisposeDT(dtSumary2) : Generic.DisposeDT(dtSumary3)
            End Try
        End Function

        Public Function RunBatteryCoverDataReport(ByVal iLocID As Integer, ByVal strReportName As String, _
                                            ByVal strBeginDateTime As String, ByVal strEndDateTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim ds As New DataSet()
            Dim objExcelReports As ExcelReports
            Dim bIncludeDeviceID As Boolean = False

            Try
                'In Period
                strSql = "SELECT tdevice.Device_SN as 'Serial',tmodel.Model_desc as 'Model',tdevicebill.dbill_invoiceamt AS 'Battery Charge', tdevicebill.dbill_AvgCost as 'Battery Cost'" & Environment.NewLine
                strSql &= " , 1 as 'Battery Qty',tdevicebill.Part_Number,PSPrice_Desc as 'Part_Desc',BillCode_Desc,tdevice.device_ID" & Environment.NewLine
                strSql &= " FROM tdevice" & Environment.NewLine
                strSql &= " INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes ON tdevicebill.billcode_ID=lbillcodes.billcode_ID" & Environment.NewLine
                strSql &= " INNER JOIN  lpsprice ON tdevicebill.Part_Number= lpsprice.PSprice_number" & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON  tmodel.Model_ID=tdevice.Model_ID" & Environment.NewLine
                strSql &= " WHERE loc_id = " & iLocID & Environment.NewLine
                strSql &= " AND tdevicebill.billcode_ID in ( 154, 1869, 2510 )" & Environment.NewLine
                strSql &= " AND date_rec between '" & strBeginDateTime & "' AND '" & strEndDateTime & "'" & Environment.NewLine
                strSql &= " AND device_shipworkdate between '" & strBeginDateTime & "' AND '" & strEndDateTime & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If Not bIncludeDeviceID Then dt.Columns.Remove("Device_ID")
                dt.TableName = "In Period"
                ds.Tables.Add(dt)

                'Out Period
                strSql = "SELECT tdevice.Device_SN as 'Serial',tmodel.Model_desc as 'Model',tdevicebill.dbill_invoiceamt AS 'Battery Charge', tdevicebill.dbill_AvgCost as 'Battery Cost'" & Environment.NewLine
                strSql &= " , 1 as 'Battery Qty',tdevicebill.Part_Number,PSPrice_Desc as 'Part_Desc',BillCode_Desc,tdevice.device_ID" & Environment.NewLine
                strSql &= " FROM tdevice" & Environment.NewLine
                strSql &= " INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbillcodes ON tdevicebill.billcode_ID=lbillcodes.billcode_ID" & Environment.NewLine
                strSql &= " INNER JOIN  lpsprice ON tdevicebill.Part_Number= lpsprice.PSprice_number" & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON  tmodel.Model_ID=tdevice.Model_ID" & Environment.NewLine
                strSql &= " WHERE loc_id = " & iLocID & Environment.NewLine
                strSql &= " AND tdevicebill.billcode_ID in ( 154, 1869, 2510 )" & Environment.NewLine
                strSql &= " AND date_rec between '" & strBeginDateTime & "' AND '" & strEndDateTime & "'" & Environment.NewLine
                strSql &= " AND device_shipworkdate not between '" & strBeginDateTime & "' AND '" & strEndDateTime & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If Not bIncludeDeviceID Then dt.Columns.Remove("Device_ID")
                dt.TableName = "Out Period"
                ds.Tables.Add(dt)

                objExcelReports = New ExcelReports()
                objExcelReports.RunSimpleExcelFormat_PerSheetPerTable(ds, strReportName, New String() {"A", "B", "F", "G", "H"}, )

                Return 1

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objExcelReports = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function RunVendorPerformanceReport(ByVal strReportName As String, _
                                            ByVal strBeginDateTime As String, ByVal strEndDateTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim ds As New DataSet()
            Dim objExcelReports As ExcelReports
            Dim bIncludeDeviceID As Boolean = False
            Dim _rptNr As Integer = Now.Second
            Try
                Dim _inv As PSS.Data.Buisness.Inventory = New PSS.Data.Buisness.Inventory()
                ds = _inv.GetVendorPerformanceDS(strBeginDateTime, strEndDateTime)
                objExcelReports = New ExcelReports()
                objExcelReports.RunSimpleExcelFormat_PerSheetPerTable(ds, strReportName)
                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objExcelReports = Nothing
                ds = Nothing
            End Try
        End Function

		Public Function RunTFProdPlnBoxAAReport(ByVal strReportName As String) As Integer
			Dim strSql As String = ""
			Dim dt As DataTable
			Dim objExcelReports As ExcelReports
			Dim _sb As New StringBuilder()
			Try
				_sb.Append("SELECT ")
				_sb.Append("tmodel.model_desc , ")
				_sb.Append("wp.model_id , ")
				_sb.Append("itm.boxid, ")
				_sb.Append("tcellopt.workStation, ")
				_sb.Append("wb.whlocation, ")
				_sb.Append("SUM(TO_DAYS(current_date()) - TO_DAYS(tdevice.device_recworkdate)) AS tot_age, ")
				_sb.Append("COUNT(tdevice.device_id) as box_qty, ")
				_sb.Append("ROUND(SUM(TO_DAYS(current_date()) - TO_DAYS(tdevice.device_recworkdate)) / COUNT(tdevice.device_id),0) AS avg_age ")
				_sb.Append("FROM tdevice ")
				_sb.Append("INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID ")
				_sb.Append("INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID ")
				_sb.Append("INNER JOIN cogs.ttf_wkly_plan wp ON wp.model_id = tmodel.Model_ID ")
				_sb.Append("INNER JOIN edi.titem itm ON tdevice.device_id = itm.device_id ")
				_sb.Append("INNER JOIN edi.twarehousebox wb ON itm.boxid = wb.boxid ")
				_sb.Append("WHERE  ")
				_sb.Append("(tcellopt.WorkStation='BER Screen' Or  ")
				_sb.Append("tcellopt.WorkStation='Pre-buff' Or ")
				_sb.Append("tcellopt.WorkStation='wh-wip') ")
				_sb.Append(" AND ")
				' HACK: REMOVE THE NEXT HARDCODED LINE.  FOR TESTING ONLY.
				'_sb.Append("wp.wklyplan_dt = '2016-03-21' ")
				_sb.Append("wp.wklyplan_dt > '" & String.Format("{0:yyyy-MM-dd}", DateTime.Now.Date()) & "' ")
				_sb.Append("GROUP BY ")
				_sb.Append("tmodel.model_desc, ")
				_sb.Append("wp.model_id, ")
				_sb.Append("itm.boxid, ")
				_sb.Append("tcellopt.workstation, ")
				_sb.Append("wb.whlocation; ")
				dt = _objDataProc.GetDataTable(_sb.ToString())
				If dt.Rows.Count > 0 Then
					dt.Columns(0).ColumnName = "Model Desc"
					dt.Columns(1).ColumnName = "Model ID"
					dt.Columns(2).ColumnName = "Box ID"
					dt.Columns(3).ColumnName = "Workstation"
					dt.Columns(4).ColumnName = "WH Location"
					dt.Columns(5).ColumnName = "Total Age"
					dt.Columns(6).ColumnName = "Box Qty"
					dt.Columns(7).ColumnName = "Average Age"
					objExcelReports = New ExcelReports()
					objExcelReports.RunSimpleXlAndOpen(dt, strReportName)
				End If
				Return dt.Rows.Count
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt) : objExcelReports = Nothing
			End Try
		End Function

#Region "TF PQC REPORT."

        Public Function RunTFPQCRpt( _
           ByVal strReportName As String, _
           ByVal strBegDTime As String, _
           ByVal strEndDTime As String) As Integer
            ' Runs the TF PQC Report.
            Dim strSql As String = ""
            Dim _dt1 As New DataTable()
            Dim _dt2 As New DataTable()
            Dim _dt3 As New DataTable()
            Dim _ds As New DataSet()
            Dim objExcelReports As ExcelReports
            Dim _rptNr As Integer = Now.Second
            Try
                _dt1 = _objDataProc.GetDataTable(GetTFPQCDeviceData(strBegDTime, strEndDTime))
                _dt2 = _objDataProc.GetDataTable(GetTFPQCPartsData(strBegDTime, strEndDTime))
                _dt3 = MergeTFPQCData(_dt1, _dt2)
                _ds.Tables.Add(_dt3)
                objExcelReports = New ExcelReports()
                If Not Format(CDate(strBegDTime), "yyyyMMdd").ToString = Format(CDate(strEndDTime), "yyyyMMdd").ToString Then
                    strReportName = strReportName & Format(CDate(strBegDTime), "yyyyMMdd") & "-" & Format(CDate(strEndDTime), "yyyyMMdd")
                Else
                    strReportName = strReportName & Format(CDate(strBegDTime), "yyyyMMdd")
                End If
                objExcelReports.RunSimpleExcelFormat_PerSheetPerTable(_ds, strReportName)
                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(_dt1)
                Generic.DisposeDT(_dt2)
                Generic.DisposeDT(_dt3)
                _ds = Nothing
                objExcelReports = Nothing
            End Try
        End Function
        Public Function GetTFPQCDeviceData(ByVal strBegDTime As String, ByVal strEndDTime As String) As String
            ' Returns the sql string for the TF PQC Report at the device level.
            Dim _sb As New StringBuilder()
            _sb.Append("SELECT ")
            _sb.Append("d.device_id, ")
            _sb.Append("d.device_sn, ")
            _sb.Append("map.cust_outgoingsku, ")
            _sb.Append("d.device_laborlevel, ")
            _sb.Append("pks.pkslip_dockshipdate, ")
            _sb.Append("d.device_shipworkdate, ")
            _sb.Append("o.il_no, ")
            _sb.Append("itm.lastdateinwrty, ")
            _sb.Append("CASE WHEN (d.device_laborlevel > 1) THEN ")
            _sb.Append("CASE WHEN (pks.pkslip_dockshipdate > itm.lastdateinwrty) THEN 'OWD' ")
            _sb.Append("ELSE 'OWA' END ")
            _sb.Append("ELSE '' END AS fail_cd, ")
            _sb.Append("CASE WHEN (d.device_laborlevel >= 0) THEN ")
            _sb.Append("CASE WHEN (pks.pkslip_dockshipdate > itm.lastdateinwrty) THEN 'OWD' ")
            _sb.Append("ELSE 'OWA' END ")
            _sb.Append("ELSE '' END AS fail_cd_all ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("inner join tpallett p on d.pallett_id = p.pallett_id ")
            _sb.Append("inner join tpackingslip pks on p.pkslip_id = pks.pkslip_id ")
            _sb.Append("inner join tworkorder wo on d.wo_id = wo.wo_id ")
            _sb.Append("inner join edi.torder o on wo.wo_id = o.pss_wo_id ")
            _sb.Append("inner join edi.titem itm on d.device_id = itm.device_id ")
            _sb.Append("inner join tmodel m on d.model_id = m.model_id ")
            _sb.Append("inner join tcustmodel_pssmodel_map map on m.model_id = map.model_id ")
            _sb.Append("WHERE ")
            _sb.Append("d.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID)
            _sb.Append(" AND pks.pkslip_dockshipdate BETWEEN '" & strBegDTime & "' and '" & strEndDTime & "'")
            _sb.Append(" AND p.pallet_shiptype = 0; ")
            Return _sb.ToString()
        End Function
        Public Function GetTFPQCPartsData(ByVal strBegDTime As String, ByVal strEndDTime As String) As String
            ' Returns data for the TF PQC Report at the part level.
            Dim _sb As New StringBuilder()
            _sb.Append("SELECT ")
            _sb.Append("d.device_id, ")
            _sb.Append("map.laborlevel, ")
            _sb.Append("tbc.tfb_desc ")
            _sb.Append("FROM ")
            _sb.Append("tdevice d ")
            _sb.Append("inner join tpallett p on d.pallett_id = p.pallett_id ")
            _sb.Append("inner join tpackingslip pks on p.pkslip_id = pks.pkslip_id ")
            _sb.Append("inner join tdevicebill db on d.device_id = db.device_id ")
            _sb.Append("inner join tpsmap map on d.model_id = map.model_id and db.billcode_id = map.billcode_id ")
            _sb.Append("left outer join tracfonebillcodemap tbcm on db.billcode_id = tbcm.billcode_id ")
            _sb.Append("left outer join tracfonebillcode tbc on tbcm.tfb_id = tbc.tfb_id ")
            _sb.Append("WHERE ")
            _sb.Append("d.loc_id = " & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID)
            _sb.Append(" AND pks.pkslip_dockshipdate BETWEEN '" & strBegDTime & "' and '" & strEndDTime & "'")
            _sb.Append(" AND map.laborlevel > 1 ")
            _sb.Append(" AND p.pallet_shiptype = 0; ")
            Return _sb.ToString()
        End Function
        Private Function MergeTFPQCData(ByRef dt1 As DataTable, ByRef dt2 As DataTable) As DataTable
            Dim _dt3 As New DataTable()
            ' Merges the Device and Part data for the TF PQC Report.
            _dt3.BeginInit()
            _dt3.Columns.Add("Model", GetType(String))
            _dt3.Columns.Add("Serial No.", GetType(String))
            _dt3.Columns.Add("Dock Ship Date", GetType(String))
            _dt3.Columns.Add("PRC Disposition", GetType(String))
            _dt3.Columns.Add("Labor Level", GetType(String))
            _dt3.Columns.Add("Repair Action 1", GetType(String))
            _dt3.Columns.Add("Repair Action 2", GetType(String))
            _dt3.Columns.Add("Fail Cd.", GetType(String))
            _dt3.AcceptChanges()
            Dim r As DataRow
            Dim _cnt As Integer
            Dim _ra2 As String
            Dim i As Integer
            Try
                For Each r In dt1.Rows    ' DETAIL LEVEL DATA.
                    _ra2 = ""
                    Dim drRec2 As DataRow() = dt2.Select("device_id = " + r("device_id").ToString() + "")
                    ' BUILD THE REPAIR ACTION 2 VALUE.
                    _cnt = drRec2.GetLength(0)
                    For i = 0 To _cnt - 1       ' PART LEVEL DATA.
                        If drRec2(i)(2).ToString().Length > 0 Then
                            If i = 0 Then
                                _ra2 &= drRec2(i)(2).ToString()
                            Else
                                _ra2 &= ", " & drRec2(i)(2).ToString()
                            End If
                        End If
                    Next

                    ' ADD THE NEW ROW.
                    Dim r2 As DataRow
                    r2 = _dt3.NewRow
                    r2.BeginEdit()
                    r2("Model") = r("cust_outgoingsku").ToString()
                    r2("Serial No.") = "'" & r("device_sn").ToString()
                    r2("Dock Ship Date") = r("pkslip_dockshipdate").ToString().Replace(" 12:00:00 AM", "")
                    r2("PRC Disposition") = r("il_no").ToString()
                    If _cnt = 1 Then
                        r2("Labor Level") = drRec2(0)("laborlevel").ToString()
                    ElseIf _cnt > 1 Then 'Max Labor level
                        Dim iMax As Int32 = 0
                        For i = 0 To _cnt - 1
                            If Convert.ToInt32(drRec2(i)("laborlevel")) > iMax Then
                                iMax = Convert.ToInt32(drRec2(i)("laborlevel"))
                                'If drRec2(0)("Device_ID").ToString() = "16220212" Then
                                '    MessageBox.Show("iMax=" & iMax.ToString() & " :  cd1=" & Convert.ToInt32(drRec2(i)("laborlevel")).ToString & " :  Cd2=" & drRec2(i)("laborlevel").ToString())
                                'End If
                            End If
                        Next
                        r2("Labor Level") = iMax.ToString()
                    Else
                        r2("Labor Level") = r("device_laborlevel").ToString()
                    End If
                    r2("Repair Action 1") = "Cosmetic Refurbishment"
                    r2("Repair Action 2") = _ra2
                    r2("Fail Cd.") = r("fail_cd_all").ToString()
                    _dt3.Rows.Add(r2)
                    _dt3.AcceptChanges()
                Next

                'Reset 'labor level' and 'Fail Cd.' if No level 3 repair
                For Each r In _dt3.Rows
                    If Not r("Repair Action 2").ToString().Trim.Length > 0 AndAlso r("Labor Level") > 1 Then
                        r.BeginEdit() : r("Labor Level") = 1 : r("Fail Cd.") = "" : r.AcceptChanges()
                    End If
                    If r("Labor Level") < 2 Then
                        r.BeginEdit() : r("Fail Cd.") = "" : r.AcceptChanges()
                    End If
                    If r("Labor Level") = 0 Then
                        r.BeginEdit() : r("Labor Level") = 1 : r.AcceptChanges()
                    End If
                Next


                Return _dt3
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "TF Inventory Report"
        Public Function RunTFInventoryReport(ByVal strReportName) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            'Dim dt2 As DataTable
            'Dim dt3 As DataTable
            'Dim ds As New DataSet()
            Dim objExcelReports As ExcelReports
            'Dim bIncludeDeviceID As Boolean = False
            'Dim _rptNr As Integer = Now.Second
            Dim arrLstUniqueMCC As New ArrayList()
            Dim filteredRows() As DataRow
            Dim dtOutput As New DataTable()
            Dim row, RowNew As DataRow, col As DataColumn
            Dim strS1 As String, strS2 As String
            Dim i As Integer = 0
            Dim sumObject As Object

            Try
                'define output datatable
                dtOutput.Columns.Add("Model", GetType(String))
                dtOutput.Columns.Add("Customer Classification", GetType(String))
                dtOutput.Columns.Add("Onhand", GetType(Integer))
                dtOutput.Columns.Add("RB", GetType(Integer))
                dtOutput.Columns.Add("Unprocessed", GetType(Integer))
                dtOutput.Columns.Add("Quarantine", GetType(Integer))
                dtOutput.Columns.Add("SW Lock", GetType(Integer))
                dtOutput.Columns.Add("BER", GetType(Integer))
                dtOutput.Columns.Add("NER", GetType(Integer))
                dtOutput.Columns.Add("Obsolete", GetType(Integer))
                dtOutput.Columns.Add("Processed", GetType(Integer))

                'Get data
                strSql = "SELECT CONCAT_WS(',',C.cust_model_number,E.Dcode_Ldesc) AS 'ModelCustClass',C.cust_model_number AS 'Model', E.Dcode_Ldesc AS 'Customer Classification',B.WorkStation" & Environment.NewLine
                strSql &= " ,COUNT(A.Device_ID) AS 'Quantity'" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tcellopt B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustmodel_pssmodel_map C ON A.Model_ID = C.model_id" & Environment.NewLine
                strSql &= " INNER JOIN tmodel D ON A.Model_ID = D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lcodesdetail E ON D.cur_cust_dcode_id = E.Dcode_id" & Environment.NewLine
                strSql &= " WHERE B.WorkStation<>'intransit' AND A.Loc_ID=2946" & Environment.NewLine
                strSql &= " GROUP BY C.cust_model_number, E.Dcode_Ldesc,B.WorkStation;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    If Not arrLstUniqueMCC.Contains(row("ModelCustClass")) Then
                        arrLstUniqueMCC.Add(row("ModelCustClass"))
                    End If
                Next

                For i = 0 To arrLstUniqueMCC.Count - 1
                    strS1 = arrLstUniqueMCC(i)
                    filteredRows = dt.Select("ModelCustClass='" & strS1 & "'")
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "'")

                    RowNew = dtOutput.NewRow()

                    'Onhand
                    RowNew("Model") = filteredRows(0).Item("Model")
                    RowNew("Customer Classification") = filteredRows(0).Item("Customer Classification")
                    If IsNumeric(sumObject) Then
                        RowNew("Onhand") = Convert.ToInt16(sumObject)
                    End If

                    'RB
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation in ('WH-RB','Production Completed')")
                    If IsNumeric(sumObject) Then
                        RowNew("RB") = Convert.ToInt16(sumObject)
                    End If

                    'Quarantine
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation='Quarantine'")
                    If IsNumeric(sumObject) Then
                        RowNew("Quarantine") = Convert.ToInt16(sumObject)
                    End If

                    'SW  Lock
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation='SW Hold'")
                    If IsNumeric(sumObject) Then
                        RowNew("SW Lock") = Convert.ToInt16(sumObject)
                    End If

                    'BER
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation in ('Unworkable','Teardown','BER','BER Complete')")
                    If IsNumeric(sumObject) Then
                        RowNew("BER") = Convert.ToInt16(sumObject)
                    End If

                    'NER
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation='NER'")
                    If IsNumeric(sumObject) Then
                        RowNew("NER") = Convert.ToInt16(sumObject)
                    End If

                    'Obsolete
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation='Obsolete'")
                    If IsNumeric(sumObject) Then
                        RowNew("Obsolete") = Convert.ToInt16(sumObject)
                    End If

                    'Processed
                    sumObject = dt.Compute("Sum(Quantity)", "ModelCustClass='" & strS1 & "' And WorkStation in ('Obsolete','NER','BER','BER Complete','Teardown','Unworkable','SW Hold','Quarantine','WH-RB','Production Complete')")
                    If IsNumeric(sumObject) Then
                        RowNew("Processed") = Convert.ToInt16(sumObject)
                    End If

                    dtOutput.Rows.Add(RowNew)
                Next

                dt = Nothing

                For Each row In dtOutput.Rows
                    If Not row.IsNull("Processed") AndAlso row("Processed").ToString.Trim.Length > 0 Then
                        If Convert.ToInt16(row("Processed")) > 0 Then
                            row("Unprocessed") = row("Onhand") - row("Processed")
                        Else
                            row("Unprocessed") = row("Onhand")
                        End If
                    Else
                        row("Unprocessed") = row("Onhand")
                    End If
                Next


                objExcelReports = New ExcelReports()
                objExcelReports.RunSimpleExcelFormat(dtOutput, strReportName, New String() {"A", "B"})

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                'Generic.DisposeDT(dt) : objExcelReports = Nothing
                ' ds = Nothing
            End Try
        End Function
#End Region

#Region "TF SW Screen Report."

		Public Function RunTFSWScreenReport(ByVal strReportName As String, ByVal strStartDate As String, ByVal strEndDate As String) As Integer
			Dim strSql As String = ""
			Dim dtSWScreened As DataTable
			Dim dtKSRemoved As DataTable
			Dim dtKSEnabled As DataTable
			Dim objExcelReports As ExcelReports
			Dim strDeviceIDs As String = ""
			Dim arrLstUniqueModels As New ArrayList()

			Dim dtOutput As New DataTable()
			Dim row, RowNew As DataRow
			Dim strModel As String
			Dim i As Integer = 0
			Dim countObject As Object

			Try
				'define output datatable
				dtOutput.Columns.Add("Model", GetType(String))
				dtOutput.Columns.Add("SW Screened", GetType(Integer))
				dtOutput.Columns.Add("Kill Switch Enabled", GetType(Integer))
				dtOutput.Columns.Add("Kill Switch Removed", GetType(Integer))
				dtOutput.Columns.Add("Kill Switch Not Removed", GetType(Integer))

				'Get SW Screened Data
				strSql = "SELECT B.Device_SN,D.Model_desc,E.cust_model_number AS 'Model',DATE_FORMAT(A.crt_DT,'%Y-%m-%d') AS 'SW Date',A.dq_ID,A.Q_ID,A.Answer" & Environment.NewLine
				strSql &= " ,B.Device_ID,B.Model_ID,DATE_FORMAT(B.Device_DateRec,'%Y-%m-%d') AS 'Device_DateRec',DATE_FORMAT(B.Device_DateShip,'%Y-%m-%d') AS 'Device_DateShip'" & Environment.NewLine
				strSql &= " FROM tdevice_question A" & Environment.NewLine
				strSql &= " INNER JOIN tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
				strSql &= " INNER JOIN edi.titem C ON A.Device_ID=C.Device_ID" & Environment.NewLine
				strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
				strSql &= " INNER JOIN tcustmodel_pssmodel_map E ON B.Model_ID=E.Model_ID" & Environment.NewLine
				strSql &= " WHERE DATE_FORMAT(A.crt_DT,'%Y-%m-%d') BETWEEN '" & strStartDate & "' AND '" & strEndDate & "'" & Environment.NewLine
				strSql &= " AND A.Q_ID=2 AND A.Answer='True'" & Environment.NewLine
				strSql &= " ORDER BY E.cust_model_number,D.Model_desc;" & Environment.NewLine

				dtSWScreened = Me._objDataProc.GetDataTable(strSql)

				'Form Device IDs, Unique Models
				For Each row In dtSWScreened.Rows
					If strDeviceIDs.Trim.Length = 0 Then
						strDeviceIDs = row("Device_ID")
					Else
						strDeviceIDs &= "," & row("Device_ID")
					End If

					If Not arrLstUniqueModels.Contains(row("Model")) Then
						arrLstUniqueModels.Add(row("Model"))
					End If
				Next


				'Get KS Enabled Data
				strSql = "SELECT B.Device_SN,D.Model_desc,E.cust_model_number AS 'Model',DATE_FORMAT(A.crt_DT,'%Y-%m-%d') AS 'SW Date',A.dq_ID,A.Q_ID,A.Answer" & Environment.NewLine
				strSql &= " ,B.Device_ID,B.Model_ID,DATE_FORMAT(B.Device_DateRec,'%Y-%m-%d') AS 'Device_DateRec',DATE_FORMAT(B.Device_DateShip,'%Y-%m-%d') AS 'Device_DateShip'" & Environment.NewLine
				strSql &= " FROM tdevice_question A" & Environment.NewLine
				strSql &= " INNER JOIN tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
				strSql &= " INNER JOIN edi.titem C ON A.Device_ID=C.Device_ID" & Environment.NewLine
				strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
				strSql &= " INNER JOIN tcustmodel_pssmodel_map E ON B.Model_ID=E.Model_ID" & Environment.NewLine
				strSql &= " WHERE A.device_ID in (" & Environment.NewLine
				strSql &= strDeviceIDs & Environment.NewLine
				strSql &= " )" & Environment.NewLine
				strSql &= " AND A.Q_ID=5 AND A.Answer='True'" & Environment.NewLine
				strSql &= " ORDER BY E.cust_model_number,D.Model_desc;" & Environment.NewLine

				dtKSEnabled = Me._objDataProc.GetDataTable(strSql)

				'Get KS Removed Data
				strSql = "SELECT B.Device_SN,D.Model_desc,E.cust_model_number AS 'Model',DATE_FORMAT(A.crt_DT,'%Y-%m-%d') AS 'SW Date',A.dq_ID,A.Q_ID,A.Answer" & Environment.NewLine
				strSql &= " ,B.Device_ID,B.Model_ID,DATE_FORMAT(B.Device_DateRec,'%Y-%m-%d') AS 'Device_DateRec',DATE_FORMAT(B.Device_DateShip,'%Y-%m-%d') AS 'Device_DateShip'" & Environment.NewLine
				strSql &= " FROM tdevice_question A" & Environment.NewLine
				strSql &= " INNER JOIN tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
				strSql &= " INNER JOIN edi.titem C ON A.Device_ID=C.Device_ID" & Environment.NewLine
				strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
				strSql &= " INNER JOIN tcustmodel_pssmodel_map E ON B.Model_ID=E.Model_ID" & Environment.NewLine
				strSql &= " WHERE A.device_ID in (" & Environment.NewLine
				strSql &= strDeviceIDs & Environment.NewLine
				strSql &= " )" & Environment.NewLine
				strSql &= " AND A.Q_ID=6 AND A.Answer='True'" & Environment.NewLine
				strSql &= " ORDER BY E.cust_model_number,D.Model_desc;" & Environment.NewLine

				dtKSRemoved = Me._objDataProc.GetDataTable(strSql)

				'Compute output data
				For i = 0 To arrLstUniqueModels.Count - 1
					strModel = arrLstUniqueModels(i)
					countObject = dtSWScreened.Compute("Count(Model)", "Model='" & strModel & "'")

					RowNew = dtOutput.NewRow()

					RowNew("Model") = strModel

					If IsNumeric(countObject) Then
						RowNew("SW Screened") = Convert.ToInt16(countObject)
					End If

					countObject = dtKSEnabled.Compute("Count(Model)", "Model='" & strModel & "'")
					If IsNumeric(countObject) Then
						RowNew("Kill Switch Enabled") = Convert.ToInt16(countObject)
					End If

					countObject = dtKSRemoved.Compute("Count(Model)", "Model='" & strModel & "'")
					If IsNumeric(countObject) Then
						RowNew("Kill Switch Removed") = Convert.ToInt16(countObject)
					End If

					dtOutput.Rows.Add(RowNew)
				Next

				dtSWScreened = Nothing : dtKSEnabled = Nothing : dtKSRemoved = Nothing

				objExcelReports = New ExcelReports()
				objExcelReports.RunTFScreenedExcelReport(dtOutput, strReportName, strStartDate, strEndDate)

				Return 1
			Catch ex As Exception
				Throw ex
			Finally
				'Generic.DisposeDT(dt) : objExcelReports = Nothing
				' ds = Nothing
			End Try
		End Function

#End Region

		Public Function RunTFPCPRecReport(ByVal strReportName As String, ByVal strStartDate As String, ByVal strEndDate As String) As Integer
			Dim _dt As New DataTable()
			Dim _sb As New StringBuilder()
			Dim objExcelReports As ExcelReports
			_sb.Append("SELECT ")
			_sb.Append("bpr_id, ")
			_sb.Append("date_rec, ")
			_sb.Append("pallet, ")
			_sb.Append("carton, ")
			_sb.Append("loc_desc, ")
			_sb.Append("CONCAT(""'"", sku) AS Sku, ")
			_sb.Append("make, ")
			_sb.Append("Model, ")
			_sb.Append("CONCAT(""'"", serial_nr) AS serial_nr, ")
			_sb.Append("pallet_diff, ")
			_sb.Append("carton_diff, ")
			_sb.Append("sku_diff, ")
			_sb.Append("sn_extra, ")
			_sb.Append("crt_ts, ")
			_sb.Append("crt_by, ")
			_sb.Append("comments ")
			_sb.Append("FROM ")
			_sb.Append("production.ttf_bx_phn_received ")
			_sb.Append("WHERE ")
			_sb.Append("date_rec BETWEEN '" & strStartDate & "' AND '" & strStartDate & "'")
			_sb.Append("ORDER BY crt_ts; ")
			Try
				_dt = _objDataProc.GetDataTable(_sb.ToString())
				If _dt.Rows.Count > 0 Then
					_dt.Columns(0).ColumnName = "Receive ID"
					_dt.Columns(1).ColumnName = "Date Received"
					_dt.Columns(2).ColumnName = "Pallet"
					_dt.Columns(3).ColumnName = "Carton"
					_dt.Columns(4).ColumnName = "Location"
					_dt.Columns(5).ColumnName = "Sku"
					_dt.Columns(6).ColumnName = "Make"
					_dt.Columns(7).ColumnName = "Model"
					_dt.Columns(8).ColumnName = "Serial Number"
					_dt.Columns(9).ColumnName = "Pallet Mismatch"
					_dt.Columns(10).ColumnName = "Carton Mismatch"
					_dt.Columns(11).ColumnName = "Sku Mismatch"
					_dt.Columns(12).ColumnName = "Extra Phone"
					_dt.Columns(13).ColumnName = "Received Timestamp"
					_dt.Columns(14).ColumnName = "Received By"
					_dt.Columns(15).ColumnName = "Comments"
					objExcelReports = New ExcelReports()
					objExcelReports.RunSimpleXlAndOpen(_dt, strReportName)
				End If
				Return _dt.Rows.Count
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(_dt) : objExcelReports = Nothing
			End Try
		End Function

	End Class

End Namespace








