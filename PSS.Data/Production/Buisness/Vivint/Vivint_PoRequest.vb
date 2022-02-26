Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_PoRequest
        Private _objDataProc As DBQuery.DataProc
        Private _Vivint_custId As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID
        Private _vivint_LocID As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID
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
        Private Shared Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        Public Sub UpdatePCklist(ByVal strPkslip_ID As String, ByVal iUserId As Integer)
            Dim strSql As String = ""
            Dim dt1 As New DataTable()
            strSql = " Update  tpackingslip set PO_Requested=1 ,PO_Requested_DateTime=current_date(), PO_Requested_UserID=" & iUserId & "  where pkslip_id IN ( " & strPkslip_ID & ") and cust_id=" & _Vivint_custId & " " & Environment.NewLine
            Me._objDataProc.GetDataTable(strSql)
        End Sub
        Public Function CheckManifest_Scrap(ByVal iPkslip_ID As Integer) As DataTable
            Dim dt1 As New DataTable()
            Dim strSql As String = ""
            strSql = " SELECT Model_Id FROM  tpallett where pkslip_id= " & iPkslip_ID & " and cust_id=" & _Vivint_custId & " " & Environment.NewLine
            dt1 = Me._objDataProc.GetDataTable(strSql)
            Return dt1
        End Function
        Public Function CheckPO_Request(ByVal iPkslip_ID As Integer) As DataTable
            Dim dt1 As New DataTable()
            Dim strSql As String = ""
            strSql = " SELECT * FROM  tpackingslip where pkslip_id= " & iPkslip_ID & " and cust_id=" & _Vivint_custId & " " & Environment.NewLine
            dt1 = Me._objDataProc.GetDataTable(strSql)
            Return dt1
        End Function
        Public Function PO_RequestVivint(ByVal strPkslip_ID As String) As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim strRptPath As String
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            strRptPath = strRptDir & strFileName
            Dim Locid As Integer = 4488
            Dim strSql As String = ""
            strSql = " select DISTINCT(C.device_id), LPAD(pkslip_id,9,'0') AS 'Manifest Num' ,ShippedModel AS 'PartNumber',ShippedModel_Desc AS 'Part Description','EA' AS 'Purchase UOM',device_SN AS SN,Device_Qty as Qty,pallett_shipdate AS 'Ship Time' ,  C.device_laborcharge  AS 'TotalCost','' AS 'Unit Price', '' AS 'Ext Price'" & Environment.NewLine
            strSql &= "from tdevice C  " & Environment.NewLine
            strSql &= "INNER JOIN  tpallett B ON  C.pallett_id=B.pallett_id " & Environment.NewLine
            strSql &= "INNER JOIN tmodel E ON C.Model_Id=E.Model_id " & Environment.NewLine
            strSql &= "WHERE C.Loc_id = " & _vivint_LocID & "  AND  pkslip_id IN ( " & strPkslip_ID & ")  ORDER BY pkslip_id" & Environment.NewLine
            'strSql &= "WHERE A.cust_id = 2626  AND  pallett_Name IN('4488REF201007N003','4488REF201006N003','4488REF200924N001') GROUP  BY device_sn" & Environment.NewLine
            dt1 = Me._objDataProc.GetDataTable(strSql)
            strSql = String.Empty
            strSql = " select ShippedModel as 'PartNumber' ,ShippedModel_Desc AS 'Part Description','EA' AS 'Purchase UOM', COUNT(*) as Qty,pallett_shipdate AS 'Delivery Date'" & Environment.NewLine
            strSql &= "from extendedwarranty A " & Environment.NewLine
            strSql &= "INNER JOIN  tpallett B ON  C.pallett_id=B.pallett_id " & Environment.NewLine
            strSql &= " INNER JOIN tdevice C ON C.device_id=A.device_id" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill D ON C.device_id=D.device_id " & Environment.NewLine
            strSql &= "INNER JOIN tmodel E ON A.item_sku=E.Model_desc " & Environment.NewLine
            strSql &= "INNER JOIN lpsprice ON  part_number=psprice_Number " & Environment.NewLine
            strSql &= "WHERE A.cust_id =" & _Vivint_custId & "  AND   pkslip_id IN ( " & strPkslip_ID & ") GROUP BY Item_SKU" & Environment.NewLine
            dt2 = Me._objDataProc.GetDataTable(strSql)
            If dt1.Rows.Count = 0 Then
                MsgBox("There is no data in PSS Database for the criterion provided.")
                Return 0
                Exit Function
            Else
                Return CreateRawDataExcelFile(dt1, dt2, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath)

            End If


        End Function
        Public Function CreateRawDataExcelFile(ByRef dt1 As DataTable, ByRef dt2 As DataTable, ByVal strFromDt As String, _
                                                         ByVal strToDt As String, _
                                                         ByVal strRptPath As String) As Integer
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet, objSheet2 As Excel.Worksheet    ' Excel Worksheet
            Dim dSum_Kitting, dSUM As Decimal
            Dim R1, R2 As DataRow
            Dim i As Integer = 3
            Dim k As Integer = dt1.Rows.Count + 6
            Dim arrData(0, 0) As String
            Dim arrDatasummary(0, 0) As String
            Dim arrDatasummary1(0, 0) As String
            Dim j As Integer = 0
            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                objSheet.Name = " Vivint SN " 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                'Create the header for PO Request Deatils
                '*****************************************

                objExcel.Application.Cells(i, 1).Value = "Manifest Num"
                objExcel.Application.Cells(i, 2).Value = "Part Number"
                objExcel.Application.Cells(i, 3).Value = "Part Description"
                objExcel.Application.Cells(i, 4).Value = "SN"
                objExcel.Application.Cells(i, 5).Value = "Ship Time (Packout)"
                objExcel.Application.Cells(i, 6).Value = "Total Cost"


                'Create the header for PO Request summary
                objExcel.Application.Cells(k, 1).Value = "Line #"
                objExcel.Application.Cells(k, 2).Value = "Material #"
                objExcel.Application.Cells(k, 3).Value = "Purchase UOM"
                objExcel.Application.Cells(k, 4).Value = "Qty Ordered"
                objExcel.Application.Cells(k, 5).Value = "Unit Price"
                objExcel.Application.Cells(k, 6).Value = "Per"
                objExcel.Application.Cells(k, 7).Value = "Ext. Price"
                objExcel.Application.Cells(k, 8).Value = "Delivery Date"
                objExcel.Application.Cells(k, 9).Value = "Description"
                '*****************************************
                'Set column widths
                '*****************************************

                objSheet.Columns("A:A").ColumnWidth = 16.86 'Part Number
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 18.86   'Part Description
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 52.86 'SN
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 15.86  'Ship Time (Packout)
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 32.71  'Total Cost
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20.86  'Unit Price
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 13.43    'Ext Price
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 13.43    'Manifest Num
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("I:I").ColumnWidth = 43.43    'Manifest Num
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************
                'Format cells Data Type
                '*****************************************
                
                objSheet.Range("F4", "F" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"

                '*****************************************
                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:H3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & k & ":I" & k & "").Select()
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

                'i += 1
                i = 0

                ReDim arrData(dt1.Rows.Count, 6)
                Dim dPackingCost As Decimal
                Dim dBilling As Decimal
                For Each R1 In dt1.Rows
                    dSum_Kitting = getSUMKitting(R1("device_id"))
                    dPackingCost = getPackagingCost()
                    dBilling = gettdeviceBill(R1("device_id"))
                    If dPackingCost = 0 Then
                        MsgBox("Need to have Packaging Material Cost")
                        Return 0
                        Exit Function
                    End If

                    If dSum_Kitting = 0 Then
                        MsgBox(" Can't create PO request() " & R1("device_id") & " need to be processed: ")
                        Return 0
                        Exit Function
                    End If
                    If Not IsDBNull(R1("Manifest Num")) Then
                        arrData(i, 0) = Trim(R1("Manifest Num"))
                    End If
                    If Not IsDBNull(R1("PartNumber")) Then
                        arrData(i, 1) = Trim(R1("PartNumber"))
                    End If
                    If Not IsDBNull(R1("Part Description")) Then
                        arrData(i, 2) = Trim(R1("Part Description"))
                    End If
                    If Not IsDBNull(R1("SN")) Then
                        arrData(i, 3) = Trim(R1("SN"))
                    End If
                    If Not IsDBNull(R1("Ship Time")) Then
                        arrData(i, 4) = Trim(R1("Ship Time"))
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        dSUM = Convert.ToDecimal(Trim(R1("TotalCost"))) + dSum_Kitting + dPackingCost + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM

                        arrData(i, 5) = "$" & FormatNumber(Trim(R1("TotalCost")), 2, TriState.False, TriState.True, TriState.True)
                    End If
                    i += 1
                Next R1
               

                objSheet.Range("A4", "G" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("F4", "F" & (dt1.Rows.Count + 3)).Value = objSheet.Range("F4", "F" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A4", "A" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "A" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:I" & (dt1.Rows.Count + 3)).Select()

                k = 0
                ReDim arrDatasummary1(dt2.Rows.Count, 9)

                For Each R2 In dt2.Rows
                    Dim dAverage As Decimal = 0
                    Dim iQty As Decimal = 0
                    iQty = Convert.ToInt32(dt1.Compute("COUNT(SN)", "PartNumber = '" & Trim(R2("PartNumber")) & "'"))
                    arrDatasummary1(k, 0) = (k + 1) * 10
                    If Not IsDBNull(R2("PartNumber")) Then
                        arrDatasummary1(k, 1) = Trim(R2("PartNumber"))
                        dAverage = Convert.ToInt32(dt1.Compute("SUM(TotalCost)", "PartNumber = '" & Trim(R2("PartNumber")) & "'")) / iQty
                    End If
                    If Not IsDBNull(R2("Purchase UOM")) Then
                        arrDatasummary1(k, 2) = Trim(R2("Purchase UOM"))
                    End If
                    'If Not IsDBNull(R2("Qty")) Then
                    arrDatasummary1(k, 3) = iQty

                    If Not IsDBNull(dAverage) Then
                        arrDatasummary1(k, 4) = "$" & FormatNumber(dAverage, 2, TriState.False, TriState.True, TriState.True)

                    End If

                    arrDatasummary1(k, 5) = 1
                    arrDatasummary1(k, 6) = "$" & FormatNumber((dAverage * iQty), 2, TriState.False, TriState.True, TriState.True)

                    If Not IsDBNull(R2("Delivery Date")) Then
                        arrDatasummary1(k, 7) = Trim(R2("Delivery Date"))
                    End If
                    If Not IsDBNull(R2("Part Description")) Then
                        arrDatasummary1(k, 8) = Trim(R2("Part Description"))
                    End If

                    k += 1
                Next R2
               
                Dim result As Decimal
                result = dt1.Compute("SUM(TotalCost)", "")
                objExcel.Application.Cells(dt1.Rows.Count + 4, 5).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 6).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
                Dim strRangeX = dt1.Rows.Count + 7
                Dim strRangeY = dt1.Rows.Count + 7 + dt2.Rows.Count
                '     Format Columns Currency 
                objSheet.Range("E" & strRangeX, "E" & strRangeY).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("G" & strRangeX, "G" & strRangeY).NumberFormat = "$#,##0.00;[Red]$#,##0.00"

                objSheet.Range("A" & strRangeX, "I" & strRangeY).Value = arrDatasummary1
                objSheet.Range("A" & strRangeX, "G" & strRangeY).Value = objSheet.Range("A" & strRangeX, "G" & strRangeY).Value

                '*****************************************
                'objSheet.Range(strRangeX: strRangeY).Select()

                'Set Font
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
                '************************************************
                'Add report header

                objSheet.Range("A1:G1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3 'Red
                    .HorizontalAlignment = -4108
                End With

                objSheet.Range("A" & dt1.Rows.Count + 5 & ":G" & dt1.Rows.Count + 5).Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .HorizontalAlignment = -4108
                    .Font.ColorIndex = 3        'Red
                End With
                objExcel.Application.Cells(1, 1).Value = "PO Request Report"
                '*************************************************
                objExcel.Application.Cells(dt1.Rows.Count + 5, 1).Value = "Summary"
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
                'OPen Excel File
                objXL = New Excel.Application()
                objXL.Workbooks.Open(strRptPath)
                objXL.Visible = True
                Return 1
            Catch ex As Exception
                Throw New Exception(" CreateRawDataExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                arrData = Nothing
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
            End Try
        End Function

        Private Function gettdeviceBill(ByVal iDeviceId As Integer) As Decimal
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql = " SELECT SUM(PsPrice_StndCost)as total FROM tdevicebill E INNER JOIN production.lpsprice D ON  D.PSPrice_Number=E.part_Number where device_id=" & iDeviceId & "" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            If Not IsDBNull(dt.Rows(0)("total")) Then
                Return (dt.Rows(0)("total"))
            Else
                Return 0
            End If
        End Function


        Private Function getSUMKitting(ByVal iDeviceId As Integer) As Decimal
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql = " SELECT SUM(PsPrice_StndCost)as total FROM tdevice_kittingbill E  INNER JOIN production.lpsprice D ON  D.PSPrice_Id=E.PSPrice_Id where device_id=" & iDeviceId & "" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            If Not IsDBNull(dt.Rows(0)("total")) Then
                Return (dt.Rows(0)("total"))
            Else
                Return 0
            End If
        End Function

        Private Function getPackagingCost() As Decimal
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= " SELECT tcab_Amount FROM tcustaggregatebilling A " & Environment.NewLine
            strSql &= " INNER JOIN lBillcodes B ON A.Billcode_ID=B.BillCode_ID" & Environment.NewLine
            strSql &= " WHERE Cust_ID= " & _Vivint_custId & " AND A.BillCode_ID =4613 AND tcab_Desc='Packaging Material Cost' " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            If Not IsDBNull(dt.Rows(0)("tcab_Amount")) Then
                Return (dt.Rows(0)("tcab_Amount"))
            Else
                Return 0
            End If
        End Function

    End Class
End Namespace