Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports PSS.Data.Buisness.PreTest
Namespace Buisness.WingTechATT
    Public Class WingTechATT_Report
        Private _objDataProc As DBQuery.DataProc
        Public colDefault As Boolean
        Private objMisc As Production.Misc
        Private objPreTest As PreTest
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

#Region "Report"
        'CONNEXION  FOR TEST WILL BE REMOVED 
        
       

        Public Function CreateInvoiceCricket(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim Locid As Integer = getLocationId(strLocation)
            Dim strSql As String = String.Empty
            Dim strSql4 As String = String.Empty
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xlsx"
            Dim strRptPath As String = strRptDir & strFileName
            strSql &= " (SELECT Swapped_Device_ID, D.device_id, ClaimNo as PONumber ,Item_Sku as SKU,Model,SerialNo," & Environment.NewLine
            strSql &= " (Device_sn) as IMEI,'Premier Logitech' as 'Service Center'," & Environment.NewLine
            strSql &= "DATE_FORMAT(D.Device_DateRec,'%Y-%m-%d') as 'Date Received' ,DATE_FORMAT(pallett_Shipdate,'%Y-%m-%d') AS 'Date Shipped'," & Environment.NewLine
            strSql &= " (TO_DAYS(C.pallett_shipdate) - TO_DAYS(D.Device_DateRec)) as 'Days',IF(D.Device_Laborlevel=15,0,D.Device_Laborlevel) AS RepairLevel," & Environment.NewLine
            strSql &= "if(G.billcode_id IN(275,267),'RUR',if (G.billcode_id='1020','BER',if (G.billcode_id is Not null,'REF','' ) )) as 'Disposition',pallett_name,Retailer2 as ReturnPlanID,Warranty_Desc AS RepairProgramType,if(Swapped_Device_ID >0,'YES','NO')AS 'Swap device' ,  D.device_LaborCharge AS  TotalCost   " & Environment.NewLine
            strSql &= "FROM extendedwarranty A" & Environment.NewLine
            strSql &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql &= "LEFT JOIN tpretest_data F ON D.device_Id= F.device_Id " & Environment.NewLine
            strSql &= "LEFT JOIN lcodesdetail E ON E.Dcode_id=F.Pttf" & Environment.NewLine
            strSql &= "INNER JOIN production.tdevicebill G ON D.device_Id= G.device_Id" & Environment.NewLine
            strSql &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
            If iOption = 1 Then
                strSql &= " WHERE D.device_SN IN ( " & strImei & " ) AND  bulkordertype_id=1 GROUP BY Device_sn  " & Environment.NewLine
            Else
                strSql &= " WHERE   bulkordertype_id=1 AND C.LOC_ID=" & Locid & "  AND C.pallett_shipdate BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  pallett_name not like '%2631SDS%'   " & Environment.NewLine
                'If iReportType = 3 Then
                '    strSql &= "AND A.ship_ack=0" & Environment.NewLine
                'End If
                strSql &= "GROUP BY D.device_id order by pallett_name" & Environment.NewLine
            End If
            strSql &= " )UNION (SELECT  Swapped_Device_ID,D.device_id,  ClaimNo as PONumber ,Item_Sku as SKU,Model ,SerialNo," & Environment.NewLine
            strSql &= " (Device_sn) as IMEI,'Premier Logitech' as 'Service Center'," & Environment.NewLine
            strSql &= "DATE_FORMAT(D.Device_DateRec,'%Y-%m-%d') as 'Date Received' ,DATE_FORMAT(pallett_Shipdate,'%Y-%m-%d') AS 'Date Shipped'," & Environment.NewLine
            strSql &= " (TO_DAYS(pallett_Shipdate) - TO_DAYS(D.Device_DateRec)) as 'Days',IF(D.Device_Laborlevel=15,0,D.Device_Laborlevel) AS RepairLevel," & Environment.NewLine
            strSql &= "'REF' as 'Disposition',pallett_name,Retailer2 as ReturnPlanID,Warranty_Desc AS RepairProgramType,if(Swapped_Device_ID >0,'YES','NO')AS 'Swap device',D.device_LaborCharge  AS  TotalCost    " & Environment.NewLine
            strSql &= "FROM extendedwarranty A" & Environment.NewLine
            strSql &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql &= "inner join tdevice D ON D.device_id=A.Swapped_Device_ID" & Environment.NewLine
            If iOption = 1 Then
                strSql &= " WHERE D.device_SN IN ( " & strImei & " )  GROUP BY Device_sn  " & Environment.NewLine
            Else
                strSql &= " WHERE  C.LOC_ID=" & Locid & "  AND C.pallett_shipdate BETWEEN '" & dateRec & "' AND '" & dateEnd & "'  and  pallett_name not like '%2631SDS%' " & Environment.NewLine
                strSql &= "GROUP BY D.device_id  order by pallett_name )" & Environment.NewLine
            End If
            dt1 = Me._objDataProc.GetDataTable(strSql)
            If dt1.Rows.Count = 0 Then
                MsgBox("There is no data in PSS Database for the criterion provided.")
                Return 0
                Exit Function
            Else

                If iReportType = 3 Then
                    ds.Tables.Add(dt1)
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "AB", "AC", "AD", "AE", "AG", "AH", "AK", "S", "N"})
                    Return dtSummary.Rows.Count
                Else
                    Return CreateRawDataExcelFileInvoice(dt1, dt2, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath, strLocation)
                End If
            End If

        End Function


        Public Function CreateRawDataExcelFileInvoice(ByRef dt1 As DataTable, ByRef dt2 As DataTable, ByVal strFromDt As String, _
                                                       ByVal strToDt As String, _
                                                       ByVal strRptPath As String, ByVal strLocation As String) As Integer
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

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                objSheet.Name = " WingTechATT INVOICE REPORT" 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "PONumber"
                objExcel.Application.Cells(i, 2).Value = "SKU"
                objExcel.Application.Cells(i, 3).Value = "Model"
                objExcel.Application.Cells(i, 4).Value = "Original IMEI"
                objExcel.Application.Cells(i, 5).Value = "New IMEI"
                objExcel.Application.Cells(i, 6).Value = "Service Center"
                objExcel.Application.Cells(i, 7).Value = "Date Received"
                objExcel.Application.Cells(i, 8).Value = "Date Shipped"
                objExcel.Application.Cells(i, 9).Value = "Days"
                objExcel.Application.Cells(i, 10).Value = "Code Failure1"
                objExcel.Application.Cells(i, 11).Value = "Failure Reason1"
                objExcel.Application.Cells(i, 12).Value = "Code Failure2"
                objExcel.Application.Cells(i, 13).Value = "Failure Reason2"
                objExcel.Application.Cells(i, 14).Value = "Code Failure3"
                objExcel.Application.Cells(i, 15).Value = "Failure Reason3"
                objExcel.Application.Cells(i, 16).Value = "Code Failure4"
                objExcel.Application.Cells(i, 17).Value = "Failure Reason4"
                objExcel.Application.Cells(i, 18).Value = "RepairLevel"
                objExcel.Application.Cells(i, 19).Value = "Disposition"
                objExcel.Application.Cells(i, 20).Value = "pallett_name"
                objExcel.Application.Cells(i, 21).Value = "ReturnPlanID"
                objExcel.Application.Cells(i, 22).Value = "RepairProgramType"
                objExcel.Application.Cells(i, 23).Value = "PartNo1"
                objExcel.Application.Cells(i, 24).Value = "UseQty1"
                objExcel.Application.Cells(i, 25).Value = "PartNo2"
                objExcel.Application.Cells(i, 26).Value = "UseQty2"
                objExcel.Application.Cells(i, 27).Value = "PartNo3"
                objExcel.Application.Cells(i, 28).Value = "UseQty3"
                objExcel.Application.Cells(i, 29).Value = "PartNo4"
                objExcel.Application.Cells(i, 30).Value = "UseQty4"
                objExcel.Application.Cells(i, 31).Value = "PartNo5"
                objExcel.Application.Cells(i, 32).Value = "UseQty5"
                objExcel.Application.Cells(i, 33).Value = "PartNo6"
                objExcel.Application.Cells(i, 34).Value = "UseQty6"
                objExcel.Application.Cells(i, 35).Value = "PartNo7"
                objExcel.Application.Cells(i, 36).Value = "UseQty7"
                objExcel.Application.Cells(i, 37).Value = "PartNo8"
                objExcel.Application.Cells(i, 38).Value = "UseQty8"
                objExcel.Application.Cells(i, 39).Value = "PartNo9"
                objExcel.Application.Cells(i, 40).Value = "UseQty9"
                objExcel.Application.Cells(i, 41).Value = "PartNo10"
                objExcel.Application.Cells(i, 42).Value = "UseQty10"

                objExcel.Application.Cells(i, 43).Value = "Swap device"
                objExcel.Application.Cells(i, 44).Value = "Labor Charge"
                objExcel.Application.Cells(i, 45).Value = "Parts Charge"
                objExcel.Application.Cells(i, 46).Value = "Total Cost"


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

                objSheet.Columns("J:J").ColumnWidth = 12  'Code Failure1
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("K:K").ColumnWidth = 35  'Failure Reason1
                objSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("L:L").ColumnWidth = 12  'Code Failure2
                objSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("M:M").ColumnWidth = 35  'Failure Reason2
                objSheet.Columns("M:M").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("N:N").ColumnWidth = 12  'Code Failure3
                objSheet.Columns("N:N").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("O:O").ColumnWidth = 35  'Failure Reason3
                objSheet.Columns("O:O").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("P:P").ColumnWidth = 12  'Code Failure4
                objSheet.Columns("P:P").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("Q:Q").ColumnWidth = 35  'Failure Reason4
                objSheet.Columns("Q:Q").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("R:R").ColumnWidth = 18    'Repair Level
                objSheet.Columns("R:R").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("S:S").ColumnWidth = 18    'Disposition
                objSheet.Columns("S:S").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("T:T").ColumnWidth = 24    'Pallett_Name
                objSheet.Columns("T:T").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("U:U").ColumnWidth = 25    'Return Plan Id
                objSheet.Columns("U:U").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("V:V").ColumnWidth = 30    'Reapair Program Type
                objSheet.Columns("V:V").HorizontalAlignment = Excel.Constants.xlLeft
                ' PART USED 
                objSheet.Columns("W:W").ColumnWidth = 24    'PARTN1
                objSheet.Columns("W:W").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("X:X").ColumnWidth = 15    'USEDQTY1
                objSheet.Columns("X:X").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("Y:Y").ColumnWidth = 15    'PARTN2
                objSheet.Columns("Y:Y").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("Z:Z").ColumnWidth = 15   'USEDQTY2
                objSheet.Columns("Z:Z").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AA:AA").ColumnWidth = 15    'PARTN3
                objSheet.Columns("AA:AA").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AB:AB").ColumnWidth = 15    'USEDQTY3
                objSheet.Columns("AB:AB").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AC:AC").ColumnWidth = 15    'PARTN4
                objSheet.Columns("AC:AC").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AD:AD").ColumnWidth = 15   'USEDQTY4
                objSheet.Columns("AD:AD").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AE:AE").ColumnWidth = 15    'PARTN5
                objSheet.Columns("AE:AE").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AF:AF").ColumnWidth = 15   'USEDQTY5
                objSheet.Columns("AF:AF").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AG:AG").ColumnWidth = 15    'PARTN6
                objSheet.Columns("AG:AG").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AH:AH").ColumnWidth = 15   'USEDQTY6
                objSheet.Columns("AH:AH").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AI:AI").ColumnWidth = 15    'PARTN7
                objSheet.Columns("AI:AI").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AJ:AJ").ColumnWidth = 15    'USEDQTY7
                objSheet.Columns("AJ:AJ").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AK:AK").ColumnWidth = 15   'PARTN8
                objSheet.Columns("AK:AK").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AL:AL").ColumnWidth = 15   'USEDQTY8
                objSheet.Columns("AL:AL").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AM:AM").ColumnWidth = 15    'PARTN9
                objSheet.Columns("AM:AM").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AN:AN").ColumnWidth = 15   'USEDQTY9
                objSheet.Columns("AN:AN").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AO:AO").ColumnWidth = 15    'PARTN10
                objSheet.Columns("AO:AO").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AP:AP").ColumnWidth = 15    'USEDQTY10
                objSheet.Columns("AP:AP").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.Columns("AQ:AQ").ColumnWidth = 20   'SWAPPED DEVICE
                objSheet.Columns("AQ:AQ").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AR:AR").ColumnWidth = 20    'LASBOR CHARGE
                objSheet.Columns("AR:AR").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AS:AS").ColumnWidth = 20    'PART CHARGE
                objSheet.Columns("AS:AS").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AT:AT").ColumnWidth = 20    'TOTAL COST
                objSheet.Columns("AT:AT").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:AT3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & 1 & ":AT" & 1 & "").Select()
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

                ReDim arrData(dt1.Rows.Count, 50)

                For Each R1 In dt1.Rows
                    dBilling = gettdeviceBill(R1("IMEI"))
                    If Not IsDBNull(R1("PONumber")) Then
                        arrData(i, 0) = Trim(R1("PONumber"))
                    End If
                    If Not IsDBNull(R1("SKU")) Then
                        arrData(i, 1) = Trim(R1("SKU"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 2) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("SerialNo")) Then
                        arrData(i, 3) = Trim(R1("SerialNo"))
                    End If
                    If Not IsDBNull(R1("IMEI")) Then
                        If R1("IMEI") = R1("SerialNo") Then
                            arrData(i, 4) = ""
                        Else
                            arrData(i, 4) = Trim(R1("IMEI"))
                        End If
                    End If
                    If Not IsDBNull(R1("Service Center")) Then
                        arrData(i, 5) = Trim(R1("Service Center"))
                    End If
                    If Not IsDBNull(R1("Date Received")) Then
                        arrData(i, 6) = Trim(R1("Date Received"))
                    End If
                    If Not IsDBNull(R1("Date Shipped")) Then
                        arrData(i, 7) = Trim(R1("Date Shipped"))
                    End If
                    If Not IsDBNull(R1("Days")) Then
                        arrData(i, 8) = Trim(R1("Days"))
                    End If
                    Dim dtFailureCode As New DataTable()
                    dtFailureCode = getDeviceFailCode(R1("SerialNo"))
                    Dim iCountFailure As Integer = 0
                    Dim iFailureCount As Integer
                    For iFailureCount = 9 To 16 Step 2
                        If iCountFailure < dtFailureCode.Rows.Count Then
                            Dim strFailCode As String = dtFailureCode.Rows(iCountFailure).Item("Dcode_Sdesc")
                            Dim strFailCodeDesc As String = dtFailureCode.Rows(iCountFailure).Item("Dcode_Ldesc")
                            arrData(i, iFailureCount) = strFailCode
                            arrData(i, iFailureCount + 1) = strFailCodeDesc
                        Else
                            arrData(i, iFailureCount) = ""
                            arrData(i, iFailureCount + 1) = ""
                        End If
                        iCountFailure += 1
                    Next
                    If Not IsDBNull(R1("RepairLevel")) Then
                        arrData(i, 17) = Trim(R1("RepairLevel"))
                    End If
                    If Not IsDBNull(R1("Disposition")) Then
                        arrData(i, 18) = Trim(R1("Disposition"))
                    End If
                    If Not IsDBNull(R1("pallett_name")) Then
                        arrData(i, 19) = Trim(R1("pallett_name"))
                    End If
                    If Not IsDBNull(R1("ReturnPlanID")) Then
                        arrData(i, 20) = Trim(R1("ReturnPlanID"))
                    End If
                    If Not IsDBNull(R1("RepairProgramType")) Then
                        arrData(i, 21) = Trim(R1("RepairProgramType"))
                    End If
                    Dim dtPartNumber As New DataTable()
                    dtPartNumber = getDevicePart(R1("IMEI"))
                    Dim iCountPart As Integer = 0
                    For iPartCount = 22 To 41 Step 2
                        If iCountPart < dtPartNumber.Rows.Count Then
                            Dim strPartNumber As String = dtPartNumber.Rows(iCountPart).Item("Part_Number")
                            If strPartNumber = "RUR" Or strPartNumber = "Swap" Or strPartNumber = "BER" Then
                                arrData(i, iPartCount) = ""
                                arrData(i, iPartCount + 1) = ""
                            Else
                                arrData(i, iPartCount) = strPartNumber
                                arrData(i, iPartCount + 1) = 1
                            End If
                        Else
                            arrData(i, iPartCount) = ""
                            arrData(i, iPartCount + 1) = ""
                        End If

                        iCountPart += 1
                    Next
                    If Not IsDBNull(R1("Swap device")) Then
                        arrData(i, 42) = Trim(R1("Swap device"))
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        arrData(i, 43) = Trim(R1("TotalCost"))
                    End If
                    If Not IsDBNull(dBilling) Then
                        arrData(i, 44) = Trim(dBilling)
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        dSUM = Convert.ToDecimal(Trim(R1("TotalCost"))) + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM
                        arrData(i, 45) = "$" & FormatNumber(Trim(R1("TotalCost")), 2, TriState.False, TriState.True, TriState.True)
                    End If
                    i += 1
                Next R1
                objSheet.Range("A4", "AT" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("A4", "AT" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "AT" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:AT" & (dt1.Rows.Count + 3)).Select()
                objSheet.Range("AR4", "AR" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AS4", "AS4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AT4", "AT4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("D4", "D" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("E4", "E" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("T4", "T" & (dt1.Rows.Count + 3)).NumberFormat = 0

                objSheet.Range("H4", "H" & (dt1.Rows.Count + 3)).NumberFormat = "MM/dd/yyyy"
                objSheet.Range("G4", "G" & (dt1.Rows.Count + 3)).NumberFormat = "MM/dd/yyyy"

                Dim iXrange As Integer = (dt1.Rows.Count + 3)
                Dim result As String
                result = dt1.Compute("SUM(TotalCost)", "")
                objExcel.Application.Cells(dt1.Rows.Count + 4, 44).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 45).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
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

                objSheet.Range("A1:S1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3 'Red
                    .HorizontalAlignment = -4108
                End With
                objExcel.Application.Cells(1, 1).Value = String.Concat(strLocation.ToUpper, " INVOICE REPORT")
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

        Public Function CreateWexATT(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocationId As String, ByVal iStatus As Integer) As Integer
            Dim strSql As String
            Dim Locid As String
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim strFile As String
            Dim dtTime As DateTime = Now
            Dim _dtShipment As New DataTable()
            Dim strPath As String = "P:\Wiko\WEX WINGTECH\"
            Dim strDate As String = dtTime.ToString("yyyyMMddHHmmss")
            Dim dtRow As DataRow
            Dim strSQLTemp As String
            If strLocationId = "ATT" Then
                Locid = (PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID).ToString
            Else
                Locid = getLocationId(strLocationId)
            End If

            Dim i As Integer
            Dim strSql3 As String = ""
            Try
                strSql3 &= "SELECT 'EMBLEM'as OEM,ClaimNo AS 'Order #',item_SKU as SKU,item_desc as Model" & Environment.NewLine
                If Locid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID.ToString Then
                    strSql3 &= " ,Device_SN as IMEI,In_pallet_ID AS 'Pallett Name' " & Environment.NewLine
                Else
                    strSql3 &= " ,'' as IMEI,'' AS 'Pallett Name' " & Environment.NewLine
                End If
                strSql3 &= ", IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y'))) as 'Order Date (Receive Date)' " & Environment.NewLine
                strSql3 &= ", (TO_DAYS(CURDATE()) - TO_DAYS(Device_DateRec)) AS 'Order Age(TAT)' ,0 AS 'Order Qty',COUNT(device_sn) AS 'Qty Rcvd',0 AS 'Qty Due', " & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= " E.pkslip_trackNo AS 'Tracking #',IF(pkslip_createDt  IS NULL,'', IF(DATE_FORMAT(pkslip_createDt,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(pkslip_createDt ,'%m/%d/%Y'))) as 'Date Shipped(ASN files uploaded)','' as 'Comments: Overdue TAT reason'" & Environment.NewLine
                Else
                    strSql3 &= " '' AS 'Tracking #','' as 'Date Shipped(ASN files uploaded)','' as 'Comments: Overdue TAT reason'" & Environment.NewLine
                End If
                strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
                strSQLTemp = strSql3
                If iStatus = 0 Then
                    strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                    strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
                    strSql3 &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
                Else
                    strSql3 &= "inner join tdevice D ON D.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id)) " & Environment.NewLine
                End If

                strSql3 &= "inner join tmodel F ON D.Model_id=F.Model_id " & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= "WHERE A.sourceFile NOT LIKE '%seed%'  and  pkslip_createDt  BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND pallett_name NOT LIKE '%SDS%' and ClaimNo NOT LIKE '%Seed%' " & Environment.NewLine
                Else
                    strSql3 &= "WHERE A.sourceFile NOT LIKE '%seed%'  and  Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND ship_ID is null AND device_dateship IS null " & Environment.NewLine
                End If
                ' WEX for Crckect
                If Locid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID.ToString Then
                    strSql3 &= " AND A.ACCOUNT='569955' " & Environment.NewLine
                Else
                    strSql3 &= " AND A.ACCOUNT not in ('POS') " & Environment.NewLine
                End If
                strSql3 &= " AND A.loc_id IN (" & Locid & " )   GROUP BY claimNo" & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= " UNION " & Environment.NewLine
                    strSql3 &= strSQLTemp
                    strSql3 &= "inner join tdevice D ON D.device_id= A.swapped_device_id " & Environment.NewLine
                    strSql3 &= "inner join tmodel F ON D.Model_id=F.Model_id " & Environment.NewLine
                    strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                    strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
                    strSql3 &= "WHERE  pkslip_createDt  BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND pallett_name NOT LIKE '%SDS%'" & Environment.NewLine
                    If Locid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID.ToString Then
                        strSql3 &= " AND A.ACCOUNT='569955' " & Environment.NewLine
                    Else
                        strSql3 &= " AND A.ACCOUNT not in ('POS') " & Environment.NewLine
                    End If
                    If iStatus = 0 Then
                        strSql3 &= " AND A.loc_id IN (" & Locid & " )   GROUP BY claimNo " & Environment.NewLine
                    End If
                End If
                dtSummary = Me._objDataProc.GetDataTable(strSql3)
                Dim iQtyOrdered As Integer
                Dim iQtyReceived As Integer
                For Each dtRow In dtSummary.Rows
                    iQtyOrdered = wexOrdered(Convert.ToString(dtRow("Order #")))
                    dtRow("Order Qty") = iQtyOrdered
                    If iStatus = 1 Then
                        iQtyReceived = wexReceived(Convert.ToString(dtRow("Order #")))
                        dtRow("Qty Due") = dtRow("Qty Rcvd")
                        dtRow("Qty Rcvd") = iQtyReceived
                    Else
                        dtRow("Qty Due") = iQtyOrdered - dtRow("Qty Rcvd")
                    End If

                Next
                If iStatus = 0 Then
                    dtSummary.Columns("Qty Rcvd").ColumnName = "Qty Shipped"
                End If

                If dtSummary.Rows.Count = 0 Then

                End If
                If iStatus = 1 Then
                    strFile = strLocationId.ToUpper & "WEX Open Orders" & strDate & ".xlsx"
                Else
                    strFile = strLocationId.ToUpper & "WEX Closed Orders" & strDate & ".xlsx"
                End If

                Dim strFilename As String = strPath & strFile
                'If dtSummary.Rows.Count > 0 Then
                CreateExcelFile_ATT(dtSummary, strFilename)
                'End If
                'dtSummary.Clear()
                Return dtSummary.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Function wexOrdered(ByVal strClaimNo As String) As Integer
            Dim strSql3 As String = " SELECT serialNo FROM extendedwarranty WHERE claimNo='" + strClaimNo + "'; " & Environment.NewLine
            Dim dtwexOrdered As DataTable = Me._objDataProc.GetDataTable(strSql3)
            Return dtwexOrdered.Rows.Count
        End Function

        Private Function wexReceived(ByVal strClaimNo As String) As Integer
            Dim strSql3 As String = " SELECT serialNo FROM extendedwarranty  A " & Environment.NewLine
            strSql3 &= " INNER JOIN tdevice B ON A.device_id=B.device_id " & Environment.NewLine
            strSql3 &= " WHERE claimNo='" + strClaimNo + "' " & Environment.NewLine
            Dim dtWexReceived As DataTable = Me._objDataProc.GetDataTable(strSql3)
            Return dtWexReceived.Rows.Count
        End Function
        Private Sub CreateExcelFile_ATT(ByVal dt1 As DataTable, ByVal strRptPath As String)
            Dim i, j As Integer
            Dim xlApp As Excel.Application
            Dim dtcolumn As DataColumn
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            xlWorkSheet.Columns("A:A").ColumnWidth = 8 'Part Number
            xlWorkSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

            xlWorkSheet.Columns("B:B").ColumnWidth = 12   'Part Description
            xlWorkSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

            xlWorkSheet.Columns("C:C").ColumnWidth = 7 'SN
            xlWorkSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

            xlWorkSheet.Columns("D:D").ColumnWidth = 35  'Ship Time (Packout)
            xlWorkSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

            xlWorkSheet.Columns("E:E").ColumnWidth = 24 'Total Cost
            xlWorkSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

            xlWorkSheet.Columns("F:F").ColumnWidth = 15  'Unit Price
            xlWorkSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

            xlWorkSheet.Columns("G:G").ColumnWidth = 10    'Ext Price
            xlWorkSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

            xlWorkSheet.Columns("H:H").ColumnWidth = 10    'Manifest Num
            xlWorkSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
            xlWorkSheet.Columns("I:I").ColumnWidth = 10   'Manifest Num
            xlWorkSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft
            xlWorkSheet.Columns("J:J").ColumnWidth = 30   'Manifest Num
            xlWorkSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft

            xlWorkSheet.Columns("K:K").ColumnWidth = 32   'Manifest Num
            xlWorkSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft
            xlWorkSheet.Columns("L:L").ColumnWidth = 32  'Manifest Num
            xlWorkSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlLeft
            Dim icol As Integer
            For icol = 0 To dt1.Columns.Count - 1
                xlApp.Cells(1, icol + 1).Value = dt1.Columns(icol).ColumnName
            Next
            'Format cells Data Type
            '*****************************************
            xlWorkSheet.Range("A1", "N" & (dt1.Rows.Count + 3)).NumberFormat = "@"
            For i = 0 To dt1.Rows.Count - 1
                For j = 0 To dt1.Columns.Count - 1
                    xlWorkSheet.Cells(i + 2, j + 1) = dt1.Rows(i).Item(j)
                Next
            Next
            xlWorkSheet.Range("A1", "N" & (dt1.Rows.Count + 3)).Value = xlWorkSheet.Range("A1", "N" & (dt1.Rows.Count + 3)).Value
            xlWorkSheet.SaveAs(strRptPath)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            MsgBox("You can find the file " & strRptPath)

        End Sub
        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            Finally
                GC.Collect()
            End Try
        End Sub

        Public Function CreateInvoiceATTCTDI(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer

            Dim dt2 As New DataTable()
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim Locid As Integer = getLocationId(strLocation)
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xlsx"
            Dim strRptPath As String = strRptDir & strFileName
            Dim i As Integer
            Dim strSql3 As String = ""
            Try
                strSql3 &= "SELECT D.device_id, '' AS invlin, '' AS untqty,ClaimNo AS invnum,C.Pallett_shipdate AS vndlod,pallett_Name AS vndsub,serialNo as 'Original',device_SN as vnddtl" & Environment.NewLine
                strSql3 &= ",Item_SKU AS vndprt ,serialNo AS vndtrk,'' AS prt_client_id,'' AS condition, " & Environment.NewLine
                strSql3 &= " E.pkslip_trackNo AS bill_of_lading , (device_laborLevel) AS 'Labor Level',device_laborcharge as TotalCost " & Environment.NewLine
                strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
                strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql3 &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
                strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
                strSql3 &= "WHERE  C.Pallett_shipdate BETWEEN '" & dateRec & "' AND '" & dateEnd & "'AND C.loc_id=" & Locid & "  and  pallett_name not like '%2631SDS%'  AND A.ACCOUNT NOT IN ('CRICKET','ATT') " & Environment.NewLine

                strSql3 &= "UNION SELECT D.device_id, '' AS invlin, '' AS untqty,ClaimNo AS invnum,C.Pallett_shipdate as vndlod,pallett_Name AS vndsub,serialNo as 'Original',device_SN as vnddtl" & Environment.NewLine
                strSql3 &= ",Item_SKU AS vndprt ,serialNo AS vndtrk,'' AS prt_client_id,'' AS condition, " & Environment.NewLine
                strSql3 &= " E.pkslip_trackNo AS bill_of_lading , (device_laborLevel) AS 'Labor Level',device_laborcharge as TotalCost " & Environment.NewLine
                strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
                strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql3 &= "inner join tdevice D ON D.device_id=A.Swapped_Device_ID " & Environment.NewLine
                strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
                strSql3 &= "WHERE  C.Pallett_shipdate BETWEEN '" & dateRec & "' AND '" & dateEnd & "'AND C.loc_id=" & Locid & "  and  pallett_name not like '%2631SDS%' " & Environment.NewLine
                dtSummary = Me._objDataProc.GetDataTable(strSql3)
                For i = 0 To dtSummary.Rows.Count - 1
                    Dim strTempValue As String
                    strTempValue = dtSummary.Rows(i)("vndsub")
                    If strTempValue.IndexOf("REF") <> -1 Then
                        dtSummary.Rows(i)("condition") = "Refurb"
                    ElseIf strTempValue.IndexOf("RUR") <> -1 Then
                        dtSummary.Rows(i)("condition") = "RUR"
                    End If
                Next

                If dtSummary.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.")
                    Return 0
                    Exit Function
                Else
                    Return CreateRawDataExcelFileInvoiceATT(dtSummary, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath, strLocation)
                End If
                'dtSummary.TableName = strRptName
                'ds.Tables.Add(dtSummary)
                'objExcelRpt = New ExcelReports(False)
                'objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"})
                Return dtSummary.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateInventoryReport(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer

            Dim strSql As String
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim Locid As Integer = getLocationId(strLocation)
            Try


                strSql = "SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date',CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer',SerialNo AS 'SN',ClaimNo AS 'RA_Number',Item_SKU AS 'Model'" & Environment.NewLine
                strSql &= " , IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'RA_Date',A.Account AS 'OEM_Account'" & Environment.NewLine
                strSql &= " ,ShipTo_Name AS 'Customer_Name',IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y/%m/%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier_Date'" & Environment.NewLine
                strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Date',Customer_Work_Number AS 'Cust_WO'" & Environment.NewLine
                strSql &= ",  IF( A.Account  ='569955' ,'Warranty Exchange', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Return_Type' " & Environment.NewLine
                If iReportType <> 1 Then
                    strSql &= " ,IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y')))  AS 'Received Date',  IF( E.device_laborLevel  =0 , 'NTF', IF( E.device_laborLevel  =1  ,'Refurbished',  IF( E.device_laborLevel  = 2  ,'Repaired ',IF(E.device_laborLevel  = 4454  ,'RUR ','' ) ) ) ) as 'Return_Reason',Item_Desc as 'Cricket Claimed Handset Description'" & Environment.NewLine
                End If
                strSql &= "  ,Item_Desc" & Environment.NewLine
                strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%m/%d/%Y'))) AS 'To_RA_Date'" & Environment.NewLine
                strSql &= " ,Pass_Cos,Pass_Fun,Pass_Flash,Pass_RF,Failure_Reason,MCE_Failure_Reason,Kit_Complete" & Environment.NewLine
                strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%m/%d/%Y'))) AS 'POP_Date'" & Environment.NewLine
                strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%m/%d/%Y'))) AS 'POR_Date'" & Environment.NewLine
                strSql &= " , IF(Activation_Date IS NULL,'', IF(DATE_FORMAT(Activation_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Activation_Date,'%m/%d/%Y'))) AS 'Activation_Date'     ,OEM_RA,IMM_Order,IMM_Shipped_SKU" & Environment.NewLine
                'strSql &= " ,   IF(IMM_Shipped_Date IS NULL,'', IF(DATE_FORMAT(IMM_Shipped_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Shipped_Date,'%m/%d/%Y'))) AS 'IMM_Shipped_Date'   ,Cust2PSSI_TrackNo,In_Pallet_ID,In_Carton_ID" & Environment.NewLine
                'add a column status if the report type is Status report
                If iReportType = 4 Then
                    strSql &= ",  Device_DateBill AS 'Bill Date'" & Environment.NewLine
                    strSql &= ",  IF( Device_DateShip  IS NOT NULL ,'Produced (Shipped)', IF(Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status" & Environment.NewLine
                ElseIf iReportType = 3 Then
                    strSql &= " ,IF(  Device_DateShip IS NULL,'', IF(DATE_FORMAT(Device_DateShip,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateShip,'%m/%d/%Y'))) AS 'Ship Date',PSSI2Cust_TrackNo as 'Tracking Number',Pallett_name as 'Pallet Name',E.pallett_id as 'Carton Id'" & Environment.NewLine
                    strSql &= ",part_Number ,PSPrice_Desc as Description ,  (device_laborLevel) AS 'Labor Level'" & Environment.NewLine
                End If
                strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile,in_pallet_id as 'Pallett IN'" & Environment.NewLine
                If iReportType = 7 Then
                    strSql = ""
                    strSql = " SELECT SerialNo AS 'Cricket Claimed IMEI', (device_laborLevel) AS 'Labor Level',F.part_Number,PSPrice_Desc as Description " & Environment.NewLine
                End If
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine

                If colDefault = False Then ' when Original column radio button is checked

                    strSql = "SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date',CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer',SerialNo AS 'Cricket Claimed IMEI',ClaimNo AS 'IMM RA Number',Item_SKU AS 'Cricket Claimed SKU'" & Environment.NewLine
                    strSql &= " , IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'IMM RA Create Date',A.Account AS 'IMM-OEM Customer Account Number'" & Environment.NewLine
                    strSql &= " ,ShipTo_Name AS 'OEM/Customer Name',IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier Dock Date'" & Environment.NewLine
                    strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Dock Date',Customer_Work_Number AS 'IMM Work Ticket Number'" & Environment.NewLine
                    strSql &= ",  IF( A.Account  ='569955' ,'WE', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Service Category - IMM Return Type' " & Environment.NewLine
                    If iReportType <> 1 Then
                        strSql &= " ,IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y')))  AS 'Received Date',  IF( device_laborLevel  =0 , 'NTF', IF( device_laborLevel  =1  ,'Refurbished',  IF( device_laborLevel  = 2  ,'Repaired ', IF( device_laborLevel  = 4454  ,'RUR ','' ) ) ) ) as 'Return_Reason',Item_Desc as 'Cricket Claimed Handset Description'" & Environment.NewLine
                    End If
                    strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%m/%d/%Y'))) AS 'Original Order Date to RA Create Date (EU BRE Web Only)'" & Environment.NewLine
                    strSql &= " ,Pass_Cos as 'Handset Pass Cosmetics',Pass_Fun as 'Handset pass functional test',Pass_Flash as 'Handset Pass Flash Successful',Pass_RF as 'Handset pass RF test',Failure_Reason as 'Failure Reason' ,MCE_Failure_Reason as 'MCE Failure Reason',Kit_Complete as 'Kit Complete'" & Environment.NewLine
                    strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%m/%d/%Y'))) AS 'DA/COS-POP'" & Environment.NewLine
                    strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%m/%d/%Y'))) AS 'DA/COS-POR'" & Environment.NewLine
                    strSql &= ", IF(Activation_Date IS NULL,'', IF(DATE_FORMAT(Activation_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Activation_Date,'%m/%d/%Y'))) as 'WEX Activation Date',OEM_RA as 'OEM RA',IMM_Order as 'IMM Order',IMM_Shipped_SKU as 'IMM Shipped SKU'" & Environment.NewLine
                    If iReportType = 4 Then
                        strSql &= ", IF(Device_DateBill IS NULL,'', IF(DATE_FORMAT(Device_DateBill,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateBill,'%m/%d/%Y'))) as 'Bill Date'" & Environment.NewLine
                        strSql &= ",  IF( Device_DateShip  IS NOT NULL ,'Produced (Shipped)', IF(Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status" & Environment.NewLine
                    ElseIf iReportType = 3 Then
                        strSql &= " ,IF(  Device_DateShip IS NULL,'', IF(DATE_FORMAT(Device_DateShip,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Device_DateShip,'%m/%d/%Y'))) AS 'Ship Date',PSSI2Cust_TrackNo as 'Tracking Number',Pallett_name as 'Pallet Name',E.pallett_id as 'Carton Id'" & Environment.NewLine
                        strSql &= ",part_Number ,PSPrice_Desc as Description ,  (device_laborLevel) AS 'Labor Level'" & Environment.NewLine
                    End If
                    strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile" & Environment.NewLine
                    If iReportType = 7 Then
                        strSql = ""
                        strSql = " SELECT SerialNo AS 'Cricket Claimed IMEI', (device_laborLevel) AS 'Labor Level',F.part_Number,PSPrice_Desc as Description " & Environment.NewLine
                    End If
                    strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                    strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine

                End If

                Select Case iReportType

                    Case 1 'RA_uploaded
                        If iOption = 1 Then
                            strSql &= " WHERE SerialNo IN ( " & strImei & " ) " & Environment.NewLine
                        Else
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & "  AND D.LOC_ID=" & Locid & "  AND LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine
                        End If

                    Case 2 'Received_Report
                        strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine
                        Else
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND E.LOC_ID=" & Locid & "   AND E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine
                        End If


                    Case 3, 7  'Shipped 
                        strSql &= " INNER JOIN production.tdevice E ON A.SerialNo= E.device_SN " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpallett P ON P.pallett_id= E.pallett_id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.tdevicebill F ON F.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.lpsprice J ON  J.PSPrice_Number=F.part_Number" & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) " & Environment.NewLine
                        Else
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND  E.LOC_ID=" & Locid & " AND  E.Device_DateShip BETWEEN '" & dateRec & "' AND '" & dateEnd & "'" & Environment.NewLine

                        End If

                    Case 4 'Status 
                        strSql &= " LEFT OUTER JOIN production.tdevice E ON A.SerialNo= E.device_SN " & Environment.NewLine

                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine
                        Else

                            strSql &= " WHERE  A.cust_ID=" & iCust_ID & " AND  A.LOC_ID=" & Locid & " OR ( E.Device_DateShip   BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND E.LOC_ID=" & Locid & " )OR (E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and E.LOC_ID=" & Locid & " ) OR ( LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and A.LOC_ID=" & Locid & ") " & Environment.NewLine

                        End If

                    Case Else
                        Return 0
                End Select
                Select Case iReportType
                    Case 1, 2, 4
                        If Not Locid = 4496 Then
                            strSql &= "and A.Account Not in ('ATT','CRICKET')" & Environment.NewLine
                        End If

                End Select

                dtSummary = Me._objDataProc.GetDataTable(strSql)
                dtSummary.TableName = strRptName
                ds.Tables.Add(dtSummary)
                objExcelRpt = New ExcelReports(False)
                objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "F", "J", "M", "X", "Y", "W", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AK"})
                Return dtSummary.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function CreateInvoice(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer) As Integer
        '    Dim strSql As String
        '    Dim dtSummary As DataTable
        '    Dim ds As New DataSet()
        '    Dim objExcelRpt As ExcelReports
        '    Dim Locid As Integer = getLocationId(strLocation)
        '    Try

        '        strSql = "SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%Y-%m-%d')))  AS 'Loaded Date',ClaimNo AS 'RA_Number',Account AS 'OEM_Account'" & Environment.NewLine
        '        strSql &= ",  IF( Account=59955 ,'WEX', IF(Account=569969, 'DOA',''))  as Return_Type  " & Environment.NewLine
        '        strSql &= " ,SerialNo AS 'SN',Item_SKU AS 'Model' ,Failure_Reason" & Environment.NewLine
        '        strSql &= ",  IF( E.device_laborLevel=0 ,'NTF', IF(E.device_laborLevel=1, 'Refurbished' , IF( device_laborLevel  = 2  ,'Refurbished ', IF( device_laborLevel  = 4454  ,'RUR ','' ) )) ) as 'Primary Action',device_laborLevel,E.LastDockShipDate" & Environment.NewLine
        '        strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tdevice E ON A.device_ID=E.device_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tdevicebill F ON A.device_ID=F.device_ID" & Environment.NewLine
        '        strSql &= " INNER JOIN production.lpsprice G ON F.Part_Number=G.PSPrice_Number" & Environment.NewLine
        '        strSql &= " WHERE A.Cust_ID=2631 AND E.LOC_ID=" & Locid & "  AND E.Device_DateShip BETWEEN '" & dateRec & "' AND '" & dateEnd & "';" & Environment.NewLine
        '        dtSummary = Me._objDataProc.GetDataTable(strSql)
        '        dtSummary.TableName = strRptName
        '        ds.Tables.Add(dtSummary)
        '        objExcelRpt = New ExcelReports(False)
        '        objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "E"})
        '        Return dtSummary.Rows.Count
        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        'End Function

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
                strsql = "SELECT Distinct tdevice.device_sn as 'Serial No'," & Environment.NewLine
                strsql &= "'' as Pretester, " & Environment.NewLine
                strsql &= "'' as 'Pretester Shift', " & Environment.NewLine
                strsql &= "tpretest_data.tech_id, " & Environment.NewLine
                strsql &= "DATE_FORMAT(tpretest_data.Date_Rec,'%Y-%m-%d') as 'Pretest Date', " & Environment.NewLine
                strsql &= "lqcresult.QCResult as 'Result', " & Environment.NewLine
                strsql &= "if(lcodesdetail.Dcode_ID = 2515, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine
                strsql &= "tpretest_data.Device_id , " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine

                strsql &= "tmodel.Model_desc as 'Model' " & Environment.NewLine
                strsql &= ", Prod_Desc as 'Product Type', tpretest_data.FailOther " & Environment.NewLine
                strsql &= ",  IF( extendedwarranty.Account  ='569955' ,'Emblem Solution', IF( extendedwarranty.Account  ='569969' ,'Emblem Solution DOA', IF(extendedwarranty.Account='POS','POS','Underfined')  )  ) as Account " & Environment.NewLine
                strsql &= " ,MAX(tdevice.device_laborLevel)AS device_laborLevel,SourceFile FROM tpretest_data " & Environment.NewLine
                strsql &= "INNER JOIN tdevice on tpretest_data.device_id = tdevice.device_id " & Environment.NewLine
                strsql &= "INNER JOIN  extendedwarranty on tpretest_data.device_id = extendedwarranty.device_id " & Environment.NewLine
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
                    strsql &= "tpretest_data.pretest_wkDt <= '" & strToDt & "' and  " & Environment.NewLine
                    strsql &= " tdevice.LOC_ID=" & Locid & " " & Environment.NewLine

                End If
                strsql &= "GROUP BY tpretest_data.Device_id order by tpretest_data.Device_id ;"
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


                    CreateRawDataExcelFile(dt1, strFromDt, strToDt, strRptPath)
                    Return 1
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing

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
                objExcel.Application.Cells(i, 1).Value = "Serial No"
                objExcel.Application.Cells(i, 2).Value = "Pretester"
                objExcel.Application.Cells(i, 3).Value = "Group"
                objExcel.Application.Cells(i, 4).Value = "Pretest Date"
                objExcel.Application.Cells(i, 5).Value = "Pretest Result"
                objExcel.Application.Cells(i, 6).Value = "Fail/Pass Reason"
                objExcel.Application.Cells(i, 7).Value = "Account"
                objExcel.Application.Cells(i, 8).Value = "Model"
                objExcel.Application.Cells(i, 9).Value = "Product Type"
                objExcel.Application.Cells(i, 10).Value = "Source File"

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 32.71 'Serial No
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 43.43  'Return Type
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 32.71 'Group
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 32.71 'Pretest Date
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 9.43  'Pretest Result
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20.86  'Fail/Pass Reason
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 20.86    'Account
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 20.43 'Model
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("I:I").ColumnWidth = 25.71 'Product Type 
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("J:J").ColumnWidth = 25.7    'Source File
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft


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
                objSheet.Range("A3:J3").Select()
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

                ReDim arrData(dt1.Rows.Count, 10)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Serial No")) Then
                        arrData(i, 0) = Trim(R1("Serial No"))
                    End If
                    If Not IsDBNull(R1("Pretester")) Then
                        arrData(i, 1) = Trim(R1("Pretester"))
                    End If
                    If Not IsDBNull(R1("Group")) Then
                        arrData(i, 2) = Trim(R1("Group"))
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrData(i, 3) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Result")) Then
                        arrData(i, 4) = Trim(R1("Result"))
                    End If
                    If Not IsDBNull(R1("Failure Reason")) Then
                        arrData(i, 5) = Trim(R1("Failure Reason"))
                    End If
                    If Not IsDBNull(R1("Account")) Then
                        arrData(i, 6) = Trim(R1("Account"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 7) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("Product Type")) Then
                        arrData(i, 8) = Trim(R1("Product Type"))
                    End If
                    If Not IsDBNull(R1("SourceFile")) Then
                        arrData(i, 9) = Trim(R1("SourceFile"))
                    End If
                    i += 1
                Next R1

                objSheet.Range("A4", "J" & (dt1.Rows.Count + 3)).Value = arrData

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:J" & (dt1.Rows.Count + 3)).Select()

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
                objExcel.Application.Cells(1, 1).Value = "WingTechATT Pretest Raw Data Report"
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
        End Sub
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        Private Function gettdeviceBill(ByVal iDeviceId As String) As Decimal
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT SUM(PsPrice_StndCost)as total FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill B ON A.device_id=B.device_id    " & Environment.NewLine
            strSql &= "INNER JOIN lpsprice C ON  C.PSPrice_Number=B.part_Number" & Environment.NewLine
            strSql &= "WHERE device_sn='  " & iDeviceId & " ' " & Environment.NewLine
            'strSql = "SELECT SUM(PsPrice_StndCost)as total FROM tdevicebill E INNER JOIN production.lpsprice D ON  D.PSPrice_Number=E.part_Number where device_id=" & iDeviceId & "" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            If Not IsDBNull(dt.Rows(0)("total")) Then
                Return (dt.Rows(0)("total"))
            Else
                Return 0
            End If
        End Function


        Private Function getDevicePart(ByVal iDeviceSN As String) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql = " SELECT distinct(Part_Number) FROM tdevicebill,tdevice where device_sn='" & iDeviceSN & "' and tdevicebill.device_id=tdevice.device_id" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function


        Private Function getDeviceFailCode(ByVal iDeviceId As String) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty

            strSql &= "SELECT distinct(Dcode_Sdesc),Dcode_Ldesc  " & Environment.NewLine
            strSql &= "FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN lcodesdetail B ON B.Dcode_id=C.Pttf" & Environment.NewLine
            strSql &= "INNER JOIN tpretest_data C ON A.device_Id= C.device_Id " & Environment.NewLine
            strSql &= "WHERE  A.device_sn='" & iDeviceId & "' " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function


        Public Function CreateRawDataExcelFileInvoiceATT(ByRef dt1 As DataTable, ByVal strFromDt As String, _
                                                       ByVal strToDt As String, _
                                                       ByVal strRptPath As String, ByVal strLocation As String) As Integer
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
            Dim xlCells As Excel.Range = Nothing

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                objSheet.Name = "WingTechATT INVOICE REPORT" 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape


                xlCells = objSheet.Range("H:H")
                xlCells.Select()
                xlCells.NumberFormat = "@"

                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "invlin"
                objExcel.Application.Cells(i, 2).Value = "untqty"
                objExcel.Application.Cells(i, 3).Value = "invnum"
                objExcel.Application.Cells(i, 4).Value = "Shipped Date"
                objExcel.Application.Cells(i, 5).Value = "Cvndsub"
                objExcel.Application.Cells(i, 6).Value = "vnddtl"
                objExcel.Application.Cells(i, 7).Value = "vndprt"
                objExcel.Application.Cells(i, 8).Value = "Original IMEI"
                objExcel.Application.Cells(i, 9).Value = "prt_client_id"
                objExcel.Application.Cells(i, 10).Value = "condition"
                objExcel.Application.Cells(i, 11).Value = "Cbill_of_lading"
                objExcel.Application.Cells(i, 12).Value = "Code Failure1"
                objExcel.Application.Cells(i, 13).Value = "Failure Reason1"
                objExcel.Application.Cells(i, 14).Value = "Code Failure2"
                objExcel.Application.Cells(i, 15).Value = "Failure Reason2"
                objExcel.Application.Cells(i, 16).Value = "Code Failure3"
                objExcel.Application.Cells(i, 17).Value = "Failure Reason3"
                objExcel.Application.Cells(i, 18).Value = "Code Failure4"
                objExcel.Application.Cells(i, 19).Value = "Failure Reason4"
                objExcel.Application.Cells(i, 20).Value = "PartNo1"
                objExcel.Application.Cells(i, 21).Value = "UseQty1"
                objExcel.Application.Cells(i, 22).Value = "PartNo2"
                objExcel.Application.Cells(i, 23).Value = "UseQty2"
                objExcel.Application.Cells(i, 24).Value = "PartNo3"
                objExcel.Application.Cells(i, 25).Value = "UseQty3"
                objExcel.Application.Cells(i, 26).Value = "PartNo4"
                objExcel.Application.Cells(i, 27).Value = "UseQty4"
                objExcel.Application.Cells(i, 28).Value = "PartNo5"
                objExcel.Application.Cells(i, 29).Value = "UseQty5"
                objExcel.Application.Cells(i, 30).Value = "Labor Level"
                objExcel.Application.Cells(i, 31).Value = "Labor Charge"
                objExcel.Application.Cells(i, 32).Value = "Parts Charge"
                objExcel.Application.Cells(i, 33).Value = "Total Cost"
                objExcel.Application.Cells(i, 34).Value = "Original"

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

                objSheet.Columns("P:P").ColumnWidth = 30  'Code Failure4
                objSheet.Columns("P:P").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("Q:Q").ColumnWidth = 35  'Failure Reason4
                objSheet.Columns("Q:Q").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("R:R").ColumnWidth = 14    'Repair Level
                objSheet.Columns("R:R").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("S:S").ColumnWidth = 20    'Disposition
                objSheet.Columns("S:S").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("T:T").ColumnWidth = 20    'Pallett_Name
                objSheet.Columns("T:T").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("U:U").ColumnWidth = 25    'Return Plan Id
                objSheet.Columns("U:U").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("V:V").ColumnWidth = 30    'Reapair Program Type
                objSheet.Columns("V:V").HorizontalAlignment = Excel.Constants.xlLeft
                ' PART USED 
                objSheet.Columns("W:W").ColumnWidth = 15    'PARTN1
                objSheet.Columns("W:W").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("X:X").ColumnWidth = 15   'USEDQTY1
                objSheet.Columns("X:X").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("Y:Y").ColumnWidth = 15    'PARTN2
                objSheet.Columns("Y:Y").HorizontalAlignment = Excel.Constants.xlLeft
                '*****************************************
                objSheet.Columns("Z:Z").ColumnWidth = 15    'PARTN2
                objSheet.Columns("Z:Z").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AA:AA").ColumnWidth = 15    'PARTN2
                objSheet.Columns("AA:AA").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("AB:AB").ColumnWidth = 24
                objSheet.Columns("AB:AB").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AC:AC").ColumnWidth = 15    'PARTN2
                objSheet.Columns("AC:AC").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("AD:AD").ColumnWidth = 15    'PARTN2
                objSheet.Columns("AD:AD").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("AE:AG").ColumnWidth = 18
                objSheet.Columns("AE:AG").HorizontalAlignment = Excel.Constants.xlLeft

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:AH3").Select()
                With objExcel.Selection
                    '.WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & 1 & ":AH" & 1 & "").Select()
                With objExcel.Selection
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

                ReDim arrData(dt1.Rows.Count, 41)

                For Each R1 In dt1.Rows
                    dBilling = gettdeviceBill(R1("vnddtl"))
                    If Not IsDBNull(R1("invlin")) Then
                        arrData(i, 0) = Trim(R1("invlin"))
                    End If
                    If Not IsDBNull(R1("untqty")) Then
                        arrData(i, 1) = Trim(R1("untqty"))
                    End If
                    If Not IsDBNull(R1("invnum")) Then
                        arrData(i, 2) = Trim(R1("invnum"))
                    End If
                    If Not IsDBNull(R1("vndlod")) Then
                        arrData(i, 3) = Trim(R1("vndlod"))
                    End If
                    If Not IsDBNull(R1("vndsub")) Then
                        arrData(i, 4) = Trim(R1("vndsub"))
                    End If

                    If Not IsDBNull(R1("vnddtl")) Then
                        arrData(i, 5) = Trim(R1("vnddtl"))
                    End If
                    If Not IsDBNull(R1("vndprt")) Then
                        arrData(i, 6) = Trim(R1("vndprt"))
                    End If
                    If Not IsDBNull(R1("vndtrk")) Then
                        arrData(i, 7) = Trim(R1("vndtrk"))
                    End If
                    If Not IsDBNull(R1("prt_client_id")) Then
                        arrData(i, 8) = Trim(R1("prt_client_id"))
                    End If
                    If Not IsDBNull(R1("condition")) Then
                        arrData(i, 9) = Trim(R1("condition"))
                    End If
                    If Not IsDBNull(R1("bill_of_lading")) Then
                        arrData(i, 10) = Trim(R1("bill_of_lading"))
                    End If

                    Dim dtFailureCode As New DataTable()
                    dtFailureCode = getDeviceFailCode(R1("Original"))
                    Dim iCountFailure As Integer = 0
                    Dim iFailureCount As Integer
                    For iFailureCount = 11 To 18 Step 2
                        If iCountFailure < dtFailureCode.Rows.Count Then
                            Dim strFailCode As String = dtFailureCode.Rows(iCountFailure).Item("Dcode_Sdesc")
                            Dim strFailCodeDesc As String = dtFailureCode.Rows(iCountFailure).Item("Dcode_Ldesc")
                            arrData(i, iFailureCount) = strFailCode
                            arrData(i, iFailureCount + 1) = strFailCodeDesc
                        Else
                            arrData(i, iFailureCount) = ""
                            arrData(i, iFailureCount + 1) = ""
                        End If
                        iCountFailure += 1
                    Next

                    Dim dtPartNumber As New DataTable()
                    dtPartNumber = getDevicePart(R1("vnddtl"))
                    Dim iCountPart As Integer = 0
                    For iPartCount = 19 To 28 Step 2
                        If iCountPart < dtPartNumber.Rows.Count Then
                            Dim strPartNumber As String = dtPartNumber.Rows(iCountPart).Item("Part_Number")
                            If strPartNumber = "RUR" Or strPartNumber = "Swap" Or strPartNumber = "BER" Then
                                arrData(i, iPartCount) = ""
                                arrData(i, iPartCount + 1) = ""
                            Else
                                arrData(i, iPartCount) = strPartNumber
                                arrData(i, iPartCount + 1) = 1
                            End If
                        Else
                            arrData(i, iPartCount) = ""
                            arrData(i, iPartCount + 1) = ""
                        End If

                        iCountPart += 1
                    Next
                    If Not IsDBNull(R1("Labor Level")) Then
                        arrData(i, 29) = Trim(R1("Labor Level"))
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        arrData(i, 30) = Trim(R1("TotalCost"))
                    End If
                    If Not IsDBNull(dBilling) Then
                        arrData(i, 31) = Trim(dBilling)
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        dSUM = Convert.ToDecimal(Trim(R1("TotalCost"))) + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM
                        arrData(i, 32) = "$" & FormatNumber(Trim(R1("TotalCost")), 2, TriState.False, TriState.True, TriState.True)
                    End If
                    If Not IsDBNull(R1("Original")) Then
                        arrData(i, 33) = Trim(R1("Original"))
                    End If
                    i += 1
                Next R1

                objSheet.Range("A4", "AG" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("A4", "AG" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "AG" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:AG" & (dt1.Rows.Count + 3)).Select()
                objSheet.Range("AE4", "AE" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AF4", "AF4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AG4", "AG4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("F4", "F" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("K4", "K" & (dt1.Rows.Count + 3)).NumberFormat = "@"
                'objSheet.Range("T4", "AX" & (dt1.Rows.Count + 3)).NumberFormat = 0
                Dim iXrange As Integer = (dt1.Rows.Count + 3)
                Dim result As String
                result = dt1.Compute("SUM(TotalCost)", "")
                objExcel.Application.Cells(dt1.Rows.Count + 4, 32).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 33).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
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
                objExcel.Application.Cells(1, 1).Value = String.Concat("WIKO ", strLocation.ToUpper, " INVOICE REPORT")
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


#End Region
    End Class
End Namespace
