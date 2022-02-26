Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO
Imports System.Windows.Forms
Namespace Buisness.VV
    Public Class Vivint_Report
        Private _objDataProc As DBQuery.DataProc
        Public colDefault As Boolean
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

        
        Private _Vivint_custId As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID
        Public Function CreateInvoiceVivint(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim strRptPath As String
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            strRptPath = strRptDir & strFileName
            Dim Locid As Integer = getLocationId(strLocation)
            Dim strSql As String = ""
            strSql = " select DISTINCT(C.device_id), LPAD(pkslip_id,9,'0') AS 'Manifest Num' ,ShippedModel AS 'PartNumber',ShippedModel_Desc AS 'Part Description','EA' AS 'Purchase UOM',device_SN AS SN,Device_Qty as Qty,pallett_shipdate AS 'Ship Time' ,  C.device_laborcharge  AS 'TotalCost','' AS 'Unit Price', '' AS 'Ext Price'" & Environment.NewLine
            strSql &= "from tdevice C  " & Environment.NewLine
            strSql &= "INNER JOIN  tpallett B ON  C.pallett_id=B.pallett_id " & Environment.NewLine
            strSql &= "INNER JOIN tmodel E ON C.Model_Id=E.Model_id " & Environment.NewLine
            If iOption = 1 Then
                strSql &= " WHERE device_SN IN ( " & strImei & " )and B.LOC_ID=" & Locid & "" & Environment.NewLine
            Else
                strSql &= " WHERE  B.LOC_ID=" & Locid & " AND  B.pallett_shipdate BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and pkslip_id is not null" & Environment.NewLine

            End If
                    dt1 = Me._objDataProc.GetDataTable(strSql)
            If dt1.Rows.Count = 0 Then
                MsgBox("There is no data in PSS Database for the criterion provided.")
                Return 0
                Exit Function
            Else
                Return CreateRawDataExcelFile(dt1, dt2, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath)

            End If
        End Function

        Public Function CreateInventoryReport(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim strSql As String
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim Locid As Integer = getLocationId(strLocation)
            Dim strRptPath As String
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            strRptPath = strRptDir & strFileName
            Try

                strSql &= " SELECT  DISTINCT(SerialNo) as IMEI,ClaimNo,B.Wo_id AS 'Work Order', IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date', CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer',Item_SKU AS SKU " & Environment.NewLine
                If iReportType <> 1 Then 'Ra_uploader
                    strSql &= " , IF(Device_DateRec IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateRec,'%m/%d/%Y'))) AS 'Date Received'" & Environment.NewLine
                End If
                If iReportType = 3 Or iReportType = 8 Then 'shipped report
                    strSql &= " ,pallett_Name as 'PAllet Name',pallett_shipdate as 'Ship Date'" & Environment.NewLine
                End If
                strSql &= " ,Warranty_Desc " & Environment.NewLine
                If iReportType = 4 Then 'status report
                    strSql &= ",DATE_FORMAT(Device_DateBill,'%Y-%m-%d') AS 'Bill Date',DATE_FORMAT(pallett_shipdate,'%Y-%m-%d') as 'Ship Date'" & Environment.NewLine
                    strSql &= ",  IF( pallett_shipdate  IS NOT NULL ,'Produced (Shipped)', IF(Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status, if (K.billcode_id='4630','SCRAP',if (K.billcode_id='4614','BER',if (K.billcode_id IS NOT NULL,'REF','' ) )) as 'WIP Type', (TO_DAYS(CURDATE()) - TO_DAYS(Device_DateRec)) as 'WIP Age' " & Environment.NewLine
                    strSql &= " ,DCode_Sdesc as 'Code Failure' ,Dcode_Ldesc as 'Failure Reason'" & Environment.NewLine
                ElseIf iReportType = 3 Or iReportType = 8 Then
                    strSql &= ",K.part_Number,PSPrice_Desc as Description   , (device_laborLevel) AS 'Labor Level'" & Environment.NewLine
                End If
                If iReportType = 7 Then 'part report
                    strSql = ""
                    strSql = " SELECT SerialNo AS 'IMEI', (device_laborLevel) AS 'Labor Level',K.part_Number,PSPrice_Desc as Description " & Environment.NewLine
                End If
                If iReportType = 8 Then 'repair record 
                    strSql &= ",E.device_id" & Environment.NewLine
                End If
                strSql &= " FROM Production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine

                Select Case iReportType
                    Case 1 'RA_uploaded

                        If iOption = 1 Then
                            strSql &= " WHERE SerialNo IN ( " & strImei & " )" & Environment.NewLine 'based on the SN in the rich text  
                        Else
                            strSql &= "  WHERE  A.cust_ID=" & iCust_ID & " and A.Loc_ID=" & Locid & " AND LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "';" & Environment.NewLine
                        End If

                    Case 2 'Received_Report
                        strSql &= " INNER JOIN production.tdevice E ON A.SerialNo= E.device_SN " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine 'based on the SN in the rich text  
                        Else
                            strSql &= " WHERE A.cust_ID=" & iCust_ID & " AND A.LOC_ID=" & Locid & "  AND E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND   E.Device_DateShip IS NULL;" & Environment.NewLine
                        End If

                    Case 3, 7, 8 'Shipped 
                        strSql &= " INNER JOIN production.tdevice E ON A.SerialNo= E.device_SN " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpallett F ON E.pallett_id= F.pallett_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tdevicebill K ON K.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= " INNER JOIN production.lpsprice J ON  J.PSPrice_Number=K.part_Number" & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine 'based on the SN in the rich text  
                        Else
                            strSql &= " WHERE  A.cust_ID=" & iCust_ID & " AND  A.LOC_ID=" & Locid & " AND  F.pallett_shipdate BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine

                        End If

                    Case 4 'Status 
                        strSql &= " LEFT JOIN production.tdevice E ON A.SerialNo= E.device_SN " & Environment.NewLine
                        strSql &= " LEFT JOIN production.tpallett F ON F.pallett_id= E.pallett_id " & Environment.NewLine
                        strSql &= "LEFT  JOIN production.tpretest_data G ON G.device_Id= E.device_Id  " & Environment.NewLine
                        strSql &= "LEFT JOIN production.tdevicebill K ON K.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= "LEFT JOIN lcodesdetail on G.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine 'based on the SN in the rich text  
                        Else
                            strSql &= " WHERE  A.LOC_ID=" & Locid & " OR ( F.pallett_shipdate  BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND F.LOC_ID=" & Locid & " )OR (E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and E.LOC_ID=" & Locid & " ) OR ( LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and A.LOC_ID=" & Locid & ") order by status,SerialNo  " & Environment.NewLine
                        End If
                    Case Else
                        Return 0
                End Select
                If iReportType = 8 Then 'repair record 
                    strSql &= " Group by E.device_id" & Environment.NewLine
                End If
                dtSummary = Me._objDataProc.GetDataTable(strSql)
                dtSummary.TableName = strRptName
                ds.Tables.Add(dtSummary)
                objExcelRpt = New ExcelReports(False)
                If iReportType = 8 Then ' for repair record only 
                    CreateRawDataExcelFileInvoice(dtSummary, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath)
                Else
                    objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"})
                End If
                Return dtSummary.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try

        End Function


        Public Function getCustomerLocation(ByVal iCust_ID As Integer, ByVal cboLocation As ComboBox) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow

            Try
                strSql = "SELECT Loc_name FROM tlocation INNER JOIN tcustomer " & Environment.NewLine
                strSql &= " ON tlocation.Cust_id = tcustomer.Cust_id  where tcustomer.cust_ID=" & iCust_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    cboLocation.Items.Add("Select Location")
                    Return 1
                Else
                    cboLocation.Items.Add("Select Location")
                    For Each dtrow In dt.Rows
                        cboLocation.Items.Add(dtrow("Loc_name"))
                    Next
                End If

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function CreatePretestRawDataRpt(ByVal strFromDt As String, _
                                       ByVal strToDt As String, _
                                       ByRef strRptPath As String, ByVal strLocation As String, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim R1, R2 As DataRow
            Dim strsql As String = ""
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            strRptPath = strRptDir & strFileName
            Dim Locid As Integer = getLocationId(strLocation)

            Try
                strsql = "SELECT " & Environment.NewLine
                strsql &= "'' as Pretester, " & Environment.NewLine
                strsql &= "'' as 'Pretester Shift', " & Environment.NewLine
                strsql &= "tpretest_data.tech_id, " & Environment.NewLine
                strsql &= "tpretest_data.Date_Rec as 'Pretest Date', " & Environment.NewLine
                strsql &= "lqcresult.QCResult as 'Result', " & Environment.NewLine
                strsql &= "if(lcodesdetail.Dcode_ID = 2515, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine
                strsql &= "tpretest_data.Device_id , " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine
                strsql &= "tdevice.device_sn as 'Serial No', " & Environment.NewLine
                strsql &= "tmodel.Model_desc as 'Model' " & Environment.NewLine
                strsql &= ", Prod_Desc as 'Product Type', tpretest_data.FailOther " & Environment.NewLine
                strsql &= "FROM tpretest_data " & Environment.NewLine
                strsql &= "INNER JOIN tdevice on tpretest_data.device_id = tdevice.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel on tdevice.Model_id = tmodel.Model_id " & Environment.NewLine
                strsql &= "INNER JOIN lproduct on tmodel.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strsql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult on tpretest_data.qcresult_id = lqcresult.QCResult_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tgrouplinemap on tpretest_data.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lgroups on tgrouplinemap.Group_ID = lgroups.group_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lline on tgrouplinemap.Line_ID = lline.line_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine


                If iOption = 1 Then
                    strsql &= "WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine
                Else
                    strsql &= "WHERE tpretest_data.pretest_wkDt >= '" & strFromDt & "' and " & Environment.NewLine
                    strsql &= "tpretest_data.pretest_wkDt <= '" & strToDt & "' and tdevice.loc_id=" & Locid & " " & Environment.NewLine
                End If

                strsql &= "order by tpretest_data.Device_id;"

                dt1 = Me._objDataProc.GetDataTable(strsql)

                strsql = "select security.tusers.user_id, " & Environment.NewLine
                strsql += "security.tusers.user_FullName, " & Environment.NewLine
                strsql += "security.tusers.shift_id, " & Environment.NewLine
                strsql += "security.tusers.qcstamp, " & Environment.NewLine
                strsql += "security.tusers.tech_id, " & Environment.NewLine
                strsql += "production.tshift.shift_number " & Environment.NewLine
                strsql += "from security.tusers left outer join production.tshift on security.tusers.shift_id = production.tshift.shift_id " & Environment.NewLine
                strsql += "order by security.tusers.user_id;"
                dt2 = _objDataProc.GetDataTable(strsql)

                For Each R1 In dt1.Rows
                    'Loop for Pretester info
                    For Each R2 In dt2.Rows
                        If Not IsDBNull(R1("Tech_ID")) And Not IsDBNull(R2("tech_id")) Then
                            If R1("Tech_ID") = R2("tech_id") Then
                                R1("Pretester") = R2("Tech_ID") & " - " & Trim(R2("user_FullName"))
                                R1("Pretester Shift") = R2("shift_number")
                                Exit For
                            End If
                        End If
                    Next R2

                    R2 = Nothing
                    dt1.AcceptChanges()
                Next R1

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("There is no data in PSS Database for the criterion provided.")
                Else
                    Me.CreateRawDataExcelFile(dt1, strFromDt, strToDt, strRptPath)
                    Return 1
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                'DisposeDT(dt1) : DisposeDT(dt2)
            End Try


        End Function
        Public Sub CreateRawDataExcelFile(ByRef dt1 As DataTable, _
                                            ByVal strFromDt As String, _
                                            ByVal strToDt As String, _
                                            ByVal strRptPath As String)
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim R1 As DataRow
            Dim i As Integer = 3
            Dim arrData(0, 0) As String
            Dim j As Integer = 0

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Group"
                objExcel.Application.Cells(i, 2).Value = "Line"
                objExcel.Application.Cells(i, 3).Value = "Cost Center"
                objExcel.Application.Cells(i, 4).Value = "Pretester"
                objExcel.Application.Cells(i, 5).Value = "Pretester Shift"
                objExcel.Application.Cells(i, 6).Value = "Pretest Date"
                objExcel.Application.Cells(i, 7).Value = "Pretest Result"
                objExcel.Application.Cells(i, 8).Value = "Fail/Pass Reason"
                objExcel.Application.Cells(i, 9).Value = "Serial No"
                objExcel.Application.Cells(i, 10).Value = "Device ID"
                objExcel.Application.Cells(i, 11).Value = "Model"
                objExcel.Application.Cells(i, 12).Value = "Product Type"
                objExcel.Application.Cells(i, 13).Value = "Other Failure"

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 11.29 'Group
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 9.43  'Line
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 32.71 'Pretester
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 32.71 'Pretester
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 9.43  'Pretester Shift
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20.86  'Pretest Date
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 11    'Pretest Result
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 43.43 'Fail/Pass Reason
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("I:I").ColumnWidth = 18.71 'Serial No
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("J:J").ColumnWidth = 11    'Device ID
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("K:K").ColumnWidth = 20.86 'Model
                objSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("L:L").ColumnWidth = 18.71 'Product Type
                objSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("M:M").ColumnWidth = 43.43 'FailOther
                objSheet.Columns("M:M").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.Columns("A:D").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("E:E").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"              'Need to change this

                objSheet.Columns("F:F").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("G:G").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"              'Need to change this

                objSheet.Columns("H:M").Select()
                objExcel.Selection.NumberFormat = "@"

                '*****************************************
                'Set horizontal alignment for the header
                '*****************************************
                objSheet.Range("A3:M3").Select()
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

                ReDim arrData(dt1.Rows.Count, 12)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Group")) Then
                        arrData(i, 0) = Trim(R1("Group"))
                    End If
                    If Not IsDBNull(R1("Line")) Then
                        arrData(i, 1) = Trim(R1("Line"))
                    End If
                    If Not IsDBNull(R1("CostCenter")) Then
                        arrData(i, 2) = Trim(R1("CostCenter"))
                    End If
                    If Not IsDBNull(R1("Pretester")) Then
                        arrData(i, 3) = Trim(R1("Pretester"))
                    End If
                    If Not IsDBNull(R1("Pretester Shift")) Then
                        arrData(i, 4) = R1("Pretester Shift")
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrData(i, 5) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Result")) Then
                        arrData(i, 6) = Trim(R1("Result"))
                    End If
                    If Not IsDBNull(R1("Failure Reason")) Then
                        arrData(i, 7) = Trim(R1("Failure Reason"))
                    End If
                    If Not IsDBNull(R1("Serial No")) Then
                        arrData(i, 8) = Trim(R1("Serial No"))
                    End If
                    If Not IsDBNull(R1("Device_ID")) Then
                        arrData(i, 9) = Trim(R1("Device_ID"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 10) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("Product Type")) Then
                        arrData(i, 11) = Trim(R1("Product Type"))
                    End If
                    If Not IsDBNull(R1("FailOther")) Then
                        arrData(i, 12) = Trim(R1("FailOther"))
                    End If

                    i += 1
                Next R1

                objSheet.Range("A4", "M" & (dt1.Rows.Count + 3)).Value = arrData

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:M" & (dt1.Rows.Count + 3)).Select()

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
                objSheet.Range("A1:C1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3        'Red
                End With
                objExcel.Application.Cells(1, 1).Value = "Pretest Raw Data Report"
                '*************************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
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

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreateRawDataExcelFile(): " & Environment.NewLine & ex.Message.ToString)
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
        End Sub
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub
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
                objExcel.Application.Cells(i, 5).Value = "Ship Date"
                objExcel.Application.Cells(i, 6).Value = "Packaging Cost"
                objExcel.Application.Cells(i, 7).Value = "Kitting Charge"
                objExcel.Application.Cells(i, 8).Value = "Billing Cost"
                objExcel.Application.Cells(i, 9).Value = "Labor Charge"
                objExcel.Application.Cells(i, 10).Value = "Total Cost"


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

                objSheet.Columns("F:F").ColumnWidth = 30.86  'Unit Price
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 40.43    'Ext Price
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 40.43    'Manifest Num
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("I:I").ColumnWidth = 43.43    'Manifest Num
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft


                objSheet.Columns("J:J").ColumnWidth = 43.43    'Manifest Num
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************
                'Format cells Data Type
                '*****************************************

                objSheet.Range("F4", "J" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"

                '*****************************************
                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:J3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & k & ":J" & k & "").Select()
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

                ReDim arrData(dt1.Rows.Count, 14)
                Dim dPackingCost As Decimal
                Dim dBilling As Decimal
                For Each R1 In dt1.Rows
                    dSum_Kitting = getSUMKitting(R1("device_id"))
                    dPackingCost = getPackagingCost()
                    dBilling = gettdeviceBill(R1("device_id"))
                    If dPackingCost = 0 Then
                        MsgBox("Need to have Packaging Material Cost", MsgBoxStyle.Exclamation, "ERROR")
                        Return 0
                        Exit Function
                    End If
                    'added by amazech -thanga 19.08.2021
                    'If dSum_Kitting = 0 Then
                    '    MsgBox("No Kitting Cost" & R1("device_id") & " need to be processed: ", MsgBoxStyle.Exclamation, "ERROR")
                    '    Return 0
                    '    Exit Function
                    'End If
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
                    If Not IsDBNull(dPackingCost) Then
                        arrData(i, 5) = "$" & FormatNumber(dPackingCost, 2, TriState.False, TriState.True, TriState.True)
                    End If
                    If Not IsDBNull(dSum_Kitting) Then
                        arrData(i, 6) = "$" & FormatNumber(dSum_Kitting, 2, TriState.False, TriState.True, TriState.True)
                    End If
                    If Not IsDBNull(dBilling) Then
                        arrData(i, 7) = "$" & FormatNumber(dBilling, 2, TriState.False, TriState.True, TriState.True)
                    End If
                    If Not IsDBNull(R1("Ship Time")) Then
                        arrData(i, 8) = "$" & FormatNumber(Trim(R1("TotalCost")), 2, TriState.False, TriState.True, TriState.True)
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        dSUM = Convert.ToDecimal(Trim(R1("TotalCost"))) + dSum_Kitting + dPackingCost + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM
                        arrData(i, 9) = "$" & FormatNumber(Trim(R1("TotalCost")), 2, TriState.False, TriState.True, TriState.True)
                    End If
                    i += 1
                Next R1


                objSheet.Range("A4", "J" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("F4", "F" & (dt1.Rows.Count + 3)).Value = objSheet.Range("F4", "F" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A4", "A" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "A" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:J" & (dt1.Rows.Count + 3)).Select()

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
                objExcel.Application.Cells(dt1.Rows.Count + 4, 9).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 10).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
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
            strSql = " SELECT SUM(DBill_AVGcost)as total FROM tdevicebill where device_id=" & iDeviceId & "" & Environment.NewLine
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
        Public Function getLocationId(ByVal Loc_id As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow
            Dim LocId As Integer
            Try
                strSql = "SELECT Loc_id FROM tlocation where Loc_name ='" & Loc_id & "' ;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Exit Function
                Else
                    For Each dtrow In dt.Rows
                        LocId = dtrow("Loc_id")
                    Next
                End If
                Return LocId
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function


        Public Function CreateRawDataExcelFileInvoice(ByRef dt1 As DataTable, ByVal strFromDt As String, _
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
            Dim iPartCount As Integer
            Dim dBilling As Decimal
            Dim j As Integer = 0
            Dim iCountPart As Integer
            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                objSheet.Name = " VIVINT REPAIR REPORT" 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Serial Number"
                objExcel.Application.Cells(i, 2).Value = "ClaimNo"
                objExcel.Application.Cells(i, 3).Value = "Work Order"
                objExcel.Application.Cells(i, 4).Value = "Loaded Date"
                objExcel.Application.Cells(i, 5).Value = "Customer"
                objExcel.Application.Cells(i, 6).Value = "SKU"
                objExcel.Application.Cells(i, 7).Value = "Date Received"
                objExcel.Application.Cells(i, 8).Value = "PAllet Name"
                objExcel.Application.Cells(i, 9).Value = "Ship Date"
                objExcel.Application.Cells(i, 10).Value = "Warranty Description"
                objExcel.Application.Cells(i, 11).Value = "Part Number"
                objExcel.Application.Cells(i, 12).Value = "Description"
                objExcel.Application.Cells(i, 13).Value = "Labor Level"
                objExcel.Application.Cells(i, 14).Value = "Code Failure"
                objExcel.Application.Cells(i, 15).Value = "Failure Reason"


                '*****************************************

                objSheet.Columns("A:A").ColumnWidth = 15 'PO
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 15   'SKU
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 20 'MODEL
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 20   'Original IMEI
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 20  'New IMEI
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20  'Service Center
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 20    'DATE Received
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 20    'Date Shiiped
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("I:I").ColumnWidth = 15    'Days
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("J:J").ColumnWidth = 30  'Code Failure1
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("K:K").ColumnWidth = 35  'Failure Reason1
                objSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("L:L").ColumnWidth = 30  'Code Failure2
                objSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("M:M").ColumnWidth = 35  'Failure Reason2
                objSheet.Columns("M:M").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("N:N").ColumnWidth = 30  'Code Failure3
                objSheet.Columns("N:N").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("O:O").ColumnWidth = 35  'Failure Reason3
                objSheet.Columns("O:O").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:O3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & 1 & ":O" & 1 & "").Select()
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

                ReDim arrData(dt1.Rows.Count, 15)

                For Each R1 In dt1.Rows
                    dBilling = gettdeviceBill(R1("device_id"))
                    If Not IsDBNull(R1("IMEI")) Then
                        arrData(i, 0) = Trim(R1("IMEI"))
                    End If
                    If Not IsDBNull(R1("ClaimNo")) Then
                        arrData(i, 1) = Trim(R1("ClaimNo"))
                    End If
                    If Not IsDBNull(R1("Work Order")) Then
                        arrData(i, 2) = Trim(R1("Work Order"))
                    End If
                    If Not IsDBNull(R1("Loaded Date")) Then
                        arrData(i, 3) = Trim(R1("Loaded Date"))
                    End If
                    If Not IsDBNull(R1("Customer")) Then
                        arrData(i, 4) = Trim(R1("Customer"))
                    End If
                    If Not IsDBNull(R1("SKU")) Then
                        arrData(i, 5) = Trim(R1("SKU"))
                    End If
                    If Not IsDBNull(R1("Date Received")) Then
                        arrData(i, 6) = Trim(R1("Date Received"))
                    End If
                    If Not IsDBNull(R1("PAllet Name")) Then
                        arrData(i, 7) = Trim(R1("PAllet Name"))
                    End If
                    If Not IsDBNull(R1("Ship Date")) Then
                        arrData(i, 8) = Trim(R1("Ship Date"))
                    End If
                    If Not IsDBNull(R1("Warranty_Desc")) Then
                        arrData(i, 9) = Trim(R1("Warranty_Desc"))
                    End If
                    Dim dtPart As New DataTable()
                    dtPart = getDevicePart(R1("device_id"))
                    Dim iCountPartNumber As Integer = 0
                    Dim strPartNumber As String = ""
                    Dim strPartNumberDescription As String = ""
                    For iCountPartNumber = 0 To dtPart.Rows.Count - 1
                        If iCountPartNumber = dtPart.Rows.Count - 1 Then
                            strPartNumber &= dtPart.Rows(iCountPartNumber).Item("Part_Number")
                            strPartNumberDescription &= dtPart.Rows(iCountPartNumber).Item("PSPrice_Desc")
                        Else
                            strPartNumber &= dtPart.Rows(iCountPartNumber).Item("Part_Number") & vbLf
                            strPartNumberDescription &= dtPart.Rows(iCountPartNumber).Item("PSPrice_Desc") & vbLf
                        End If

                    Next
                    arrData(i, 10) = strPartNumber
                    arrData(i, 11) = strPartNumberDescription
                    If Not IsDBNull(R1("Labor Level")) Then
                        arrData(i, 12) = Trim(R1("Labor Level"))
                    End If
                    Dim dtFailureCode As New DataTable()
                    dtFailureCode = getDeviceFailCode(R1("device_id"))
                    Dim iCountFailure As Integer = 0
                    Dim iFailureCount As Integer
                    Dim strFailCode As String = ""
                    Dim strFailDescription As String = ""
                    For iCountFailure = 0 To dtFailureCode.Rows.Count - 1
                        If iCountFailure = dtFailureCode.Rows.Count - 1 Then
                            strFailCode &= dtFailureCode.Rows(iCountFailure).Item("Dcode_Sdesc")
                            strFailDescription &= dtFailureCode.Rows(iCountFailure).Item("Dcode_Ldesc")
                        Else
                            strFailCode &= dtFailureCode.Rows(iCountFailure).Item("Dcode_Sdesc") & vbLf
                            strFailDescription &= dtFailureCode.Rows(iCountFailure).Item("Dcode_Ldesc") & vbLf
                        End If

                    Next
                    arrData(i, 13) = strFailCode
                    arrData(i, 14) = strFailDescription
                    i += 1
                Next R1
                objSheet.Range("A4", "O" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("A4", "O" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "AT" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:AO" & (dt1.Rows.Count + 3)).Select()
                'objSheet.Range("AR4", "AR" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                'objSheet.Range("AS4", "AS4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                'objSheet.Range("AT4", "AT4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                'objSheet.Range("D4", "D" & (dt1.Rows.Count + 3)).NumberFormat = 0
                'objSheet.Range("E4", "E" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("M4", "M" & (dt1.Rows.Count + 3)).WrapText = True
                objSheet.Range("N4", "N" & (dt1.Rows.Count + 3)).WrapText = True
                objSheet.Range("M4", "M" & (dt1.Rows.Count + 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                objSheet.Range("N4", "N" & (dt1.Rows.Count + 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

                objSheet.Range("I4", "I" & (dt1.Rows.Count + 3)).NumberFormat = "MM/dd/yyyy"
                objSheet.Range("G4", "G" & (dt1.Rows.Count + 3)).NumberFormat = "MM/dd/yyyy"
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

                objSheet.Range("A1:O1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3 'Red
                    .HorizontalAlignment = -4108
                End With
                objExcel.Application.Cells(1, 1).Value = "VIVINT REPAIR REPORT"
                '*************************************************

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

        Private Function getDevicePart(ByVal iDeviceId As Integer) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql = " SELECT Part_Number,PSPrice_Desc FROM tdevicebill A" & Environment.NewLine
            strSql &= " INNER JOIN production.lpsprice B ON  B.PSPrice_Number=A.part_Number" & Environment.NewLine
            strSql &= " where device_id = " & iDeviceId & "" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function


        Private Function getDeviceFailCode(ByVal iDeviceId As Integer) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty

            strSql &= "SELECT Dcode_Sdesc,Dcode_Ldesc  " & Environment.NewLine
            strSql &= "FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN lcodesdetail B ON B.Dcode_id=C.Pttf" & Environment.NewLine
            strSql &= "INNER JOIN tpretest_data C ON A.device_Id= C.device_Id " & Environment.NewLine
            strSql &= "WHERE  A.device_id=" & iDeviceId & " " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function










    End Class
End Namespace