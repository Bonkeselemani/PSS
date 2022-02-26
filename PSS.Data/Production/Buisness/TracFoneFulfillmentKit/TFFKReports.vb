Option Explicit On 

Imports System
Imports System.Data
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit

    Public Class TFFKReports

        Private _objDataProc As mySQL5

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New mySQL5()
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

        Public Function TFFK_EDITransaction(Optional ByVal iModelID As Integer = 0)
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
                dt1 = TFFK_GetEDIData(iModelID)
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
                            
                            arrData(i, 5) = Convert.ToString(R1("OrderQty"))
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
                    objExcel.Application.Cells(1, 1).Value = "EDI Transaction Report(TFFK)"
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

        '**************************************************************************
        Public Function CreateWalmartDailyASNRpt()
            Try

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function CreateDailyShipmentsRpt(ByVal iLocID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT * FROM views.v_test_TFSHIP where `Ship Confirm Date` between '" & strDateStart & "' AND '" & strDateEnd & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateWarehouseReceiptReport(ByVal strReportName As String, _
                                                     ByVal strDateStart As String, _
                                                     ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                'strSql = "SELECT * FROM views.v_test_TFMTDREC where `Receipt Date` between '" & strDateStart & "' AND '" & strDateEnd & "';"

                strSql = "select A.RMA,D.Model_Desc,D.model_Ldesc,E.DCode_SDesc as 'Subclass'" & Environment.NewLine
                strSql &= " ,IF(D.iModelSet=3 AND Count(*) =1,C.WO_RAQnty, Count(*)) as Qty,C.WO_RAQnty,C.WO_Quantity,Count(*) as 'itemCount',B.Date_Received" & Environment.NewLine
                strSql &= " from warehouse.warehouse_receipt A" & Environment.NewLine
                strSql &= " Inner join warehouse.warehouse_items B On A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " inner join production.tworkorder C ON A.WO_ID=C.WO_ID" & Environment.NewLine
                strSql &= " inner join production.tmodel_items D ON B.Model_ID=D.Model_ID AND D.iDataSet_ID=1" & Environment.NewLine
                strSql &= " Inner Join production.lcodesDetail E ON D.SubClass_Dcode_ID=E.Dcode_ID" & Environment.NewLine
                strSql &= " where B.Date_Received Between  '" & strDateStart & "' and  '" & strDateEnd & "'" & Environment.NewLine
                strSql &= " GROUP BY A.RMA,D.Model_Desc,C.WO_Quantity,WO_RAQnty" & Environment.NewLine
                strSql &= " ORDER BY  B.Date_Received,D.iModelSet,D.Model_Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateDailyReceiptRpt(ByVal iLocID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT * FROM views.v_test_TFDLYREC where `Doc Date` between '" & strDateStart & "' AND '" & strDateEnd & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateReturnsRpt(ByVal iLocID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT * FROM views.v_test_TFRETN where `Invoice Date` between '" & strDateStart & "' AND '" & strDateEnd & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateInventoryBalanceRpt(ByVal strReportName As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                'strSql = "SELECT * FROM views.v_tffk_tfinvn;"
                strSql = "SELECT Warehouse,ItemNumber as 'Item Number',ItemDescription as 'Item Description',ItemSubclass as 'Item Sub-class',SUM(T1.QuantityOnhand) as 'Quantity On-Hand'" & Environment.NewLine
                strSql &= " ,QuantityAllocated as 'Quantity Allocated',QuantityBackordered as 'Quantity Backordered',QuantityAvailable as 'Quantity Available'" & Environment.NewLine
                strSql &= " FROM" & Environment.NewLine
                strSql &= " (SELECT 'PSSI_IO' AS 'Warehouse',A.RMA,C.Model_Desc AS 'ItemNumber',C.Model_LDesc AS 'ItemDescription',D.Dcode_Sdesc AS 'ItemSubclass'," & Environment.NewLine
                strSql &= " C.ImodelSet,IF(C.iModelSet=3 AND Count(*) =1,E.WO_RAQnty, Count(*)) AS 'QuantityOnhand',Count(*) AS 'QuantityItemsCount',E.WO_RAQnty,0 AS 'QuantityAllocated'" & Environment.NewLine
                strSql &= " ,0 AS 'QuantityBackordered',0 AS 'QuantityAvailable'" & Environment.NewLine
                strSql &= " FROM  warehouse.warehouse_receipt A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items B ON A.WR_ID=B.WR_ID AND A.iDataSet_ID=1 AND B.SoDetailsID = 0" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON B.Model_ID=C.Model_ID AND C.iModelSet in (2,3) AND C.iDataSet_ID=1" & Environment.NewLine
                strSql &= " INNER JOIN production.lcodesdetail D on C.SubClass_DCode_ID = D.Dcode_id" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder E ON A.WO_ID=E.WO_ID" & Environment.NewLine
                strSql &= " group by A.RMA,C.Model_Desc) AS T1" & Environment.NewLine
                strSql &= " GROUP BY ItemNumber" & Environment.NewLine
                strSql &= " ORDER BY iModelSet,ItemNumber;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreateShowCustomersInventoryBalanceRpt(ByVal iLocID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT * FROM views.v_test_SHWBAL;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Public Function CreatePendingOrdersRpt(ByVal iLocID As Integer, ByVal strReportName As String, _
                                        ByVal strDateStart As String, ByVal strDateEnd As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                strSql = "SELECT * FROM views.v_test_TFPENNE;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName)
                    '*************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Private Function TFFK_GetEDIData(ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                'strSql = "select distinct b.Order_Type, if(transsetcode is null and b.Order_Type='IN', 940, transsetcode) As Transsetcode" & Environment.NewLine
                'strSql &= ", b.OrderNo, "
                'strSql &= "CASE b.order_type WHEN 'IN' THEN addin.name WHEN 'OUT' THEN addout.name END AS Name, "
                'strSql &= "VN_ItemNo, IL_No, OrderQty, b.PODate, b.RequestDate, " & Environment.NewLine
                'strSql &= "if(b.msg_id = 0, TO_DAYS(now())-TO_DAYS(b.PODate), TO_DAYS(Msg_RcvdDT)-TO_DAYS(b.PODate))As '940 Aging'," & Environment.NewLine
                'strSql &= "Msg_RcvdDT, if (b.Order_Type = 'OUT', pkslip_createDt, Date_Format(a.Msg_CreationDT, '%Y-%m-%d')) As Msg_CreationDT" & Environment.NewLine
                'strSql &= ", Order_RcvdDate, ReceiptDate, WO_RAQnty" & Environment.NewLine
                'strSql &= "from edi.torder b" & Environment.NewLine
                'strSql &= "left outer join edi.tmessage a on a.msg_id = b.msg_id " & Environment.NewLine
                'strSql &= "inner join edi.torderdetail c on c.orderno = b.orderno" & Environment.NewLine
                'strSql &= "left outer join edi.twarehousereceipt d on b.WHRNO_ID = d.WHRNO_ID" & Environment.NewLine
                'strSql &= "left outer join edi.taddress addin on c.orderno = addin.orderno AND addin.EntityIdentifierCode = 'SF' and b.order_type = 'IN' "
                'strSql &= "left outer join edi.taddress addout on c.orderno = addout.orderno AND addout.EntityIdentifierCode = 'ST' and b.order_type = 'OUT'"
                'strSql &= "left outer join production.tworkorder e on b.PSS_WO_ID = e.WO_ID" & Environment.NewLine
                'strSql &= "left outer join production.tpallett f on e.wo_id = f.wo_id" & Environment.NewLine
                'strSql &= "left outer join production.tpackingslip g on f.pkslip_id = g.pkslip_id" & Environment.NewLine
                'strSql &= "where b.ordercancel = 0 " & Environment.NewLine

                strSql = " select distinct b.Order_Type, if(transsetcode is null and b.Order_Type='IN', 940, transsetcode) As Transsetcode  , b.OrderNo,  CASE b.order_type WHEN 'IN' THEN addin.name WHEN 'OUT' THEN addout.name END AS Name,  VN_ItemNo, IL_No, OrderQty, b.PODate, b.RequestDate,  if(b.msg_id = 0, TO_DAYS(now())-TO_DAYS(b.PODate), TO_DAYS(Msg_RcvdDT)-TO_DAYS(b.PODate))As '940 Aging',  Msg_RcvdDT, if (b.Order_Type = 'OUT', pkslip_createDt, Date_Format(a.Msg_CreationDT, '%Y-%m-%d')) As Msg_CreationDT  , Order_RcvdDate, ReceiptDate, WO_RAQnty  from edi.torder b  left outer join edi.tmessage a on a.msg_id = b.msg_id  inner join edi.torderdetail c on c.orderno = b.orderno  left outer join edi.twarehousereceipt d on b.WHRNO_ID = d.WHRNO_ID  left outer join edi.taddress addin on c.orderno = addin.orderno AND addin.EntityIdentifierCode = 'SF' and b.order_type = 'IN'" & Environment.NewLine
                strSql &= "left outer join edi.taddress addout on c.orderno = addout.orderno AND addout.EntityIdentifierCode = 'ST' and b.order_type = 'OUT'" & Environment.NewLine
                strSql &= "left outer join production.tworkorder e on b.PSS_WO_ID = e.WO_ID  left outer join production.tpallett f on e.wo_id = f.wo_id  left outer join production.tpackingslip g on f.pkslip_id = g.pkslip_id  where b.Order_ID >49039  and b.ordercancel = 0 and b.orderno not in ( '70303640','70303641','70303642','70303643','70303644','70303645','70303646','70303647','70303648','70303649','70303650','70303651','70303652','70303653','70303654','70303655','70303656','70303657','70303658','70303659','70303660','70303661','70303662')" & Environment.NewLine


                If iModelID = 0 Then
                    strSql &= "and TO_DAYS(now()) - TO_DAYS(b.PODate) < 91" & Environment.NewLine
                Else
                    strSql &= "and TO_DAYS(now()) - TO_DAYS(b.PODate) < 366 and c.model_id = " & iModelID & Environment.NewLine
                End If
                strSql &= "order by order_type, transsetcode desc, receiptDate, PODate;"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
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

    End Class
End Namespace
