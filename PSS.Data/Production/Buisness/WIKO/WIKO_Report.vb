Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports PSS.Data.Buisness.PreTest
Imports System.Drawing
Imports System.IO
Imports System.Globalization
Namespace Buisness.WIKO
    Public Class WIKO_Report
        Private _objDataProc As DBQuery.DataProc
        Public colDefault As Boolean
        Private objMisc As Production.Misc
        Private objPreTest As PreTest
        Private _cust_Id As Integer = 0
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
            Dim iLocid As Integer = getLocationId(strLocation, iCust_ID)
            Dim strSql As String = String.Empty
            Dim strSql4 As String = String.Empty
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xlsx"
            Dim strRptPath As String = strRptDir & strFileName
            strLocid = ""
            If iLocid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID OrElse iLocid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID Then
                Me.strLocid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
            ElseIf iLocid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID OrElse iLocid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID Then
                Me.strLocid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
            ElseIf iLocid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID OrElse iLocid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID Then
                Me.strLocid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID
            Else
                Me.strLocid = iLocid
            End If

            strSql &= " SELECT B.device_id,K.Device_ID AS OriginalDevice, ClaimNo as PONumber ,Item_Sku as SKU,Model,SerialNo," & Environment.NewLine
            strSql &= "  (B.Device_sn) as IMEI,'Premier Logitech' as 'Service Center'," & Environment.NewLine
            strSql &= " DATE_FORMAT(K.Device_DateRec,'%m/%d/%Y') as 'Date Received' ,DATE_FORMAT(pallett_Shipdate,'%m/%d/%Y') AS 'Date Shipped'," & Environment.NewLine
            strSql &= " (TO_DAYS(F.pkslip_createDt) - TO_DAYS(K.Device_DateRec)) as 'Days',B.Device_Laborlevel AS RepairLevel," & Environment.NewLine
            strSql &= " IF (E.pkslip_id IS NULL,'',if(A.Swapped_Device_ID >0,'Swapp',IF (pallet_ShipType=2,'RUR',if(pallet_ShipType=1,'BER',IF(pallet_ShipType=0 AND B.Device_LaborLevel>0,'Repaired',if(pallet_ShipType =0 AND B.Device_LaborLevel IN (0,15) AND A.Swapped_Device_ID =0,'NTF','')))))) as 'Disposition'," & Environment.NewLine
            strSql &= "pallett_name,Retailer2 as ReturnPlanID,Warranty_Desc AS RepairProgramType,if(Swapped_Device_ID >0,'YES','NO')AS 'Swap device' ,  B.device_LaborCharge AS  TotalCost,F.pkslip_trackNo AS 'Tracking #' " & Environment.NewLine
            strSql &= "  FROM production.extendedwarranty A " & Environment.NewLine
            strSql &= " INNER JOIN tdevice B ON B.device_id=(if (A.swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
            strSql &= " INNER JOIN production.tdevice K ON K.device_id= A.device_id  " & Environment.NewLine
            strSql &= " LEFT JOIN production.tpretest_data C ON  C.device_id =K.Device_ID " & Environment.NewLine
            strSql &= " LEFT JOIN lcodesdetail D on C.PTtf = D.Dcode_id  " & Environment.NewLine
            strSql &= "  INNER JOIN production.tLocation G ON A.Loc_ID=G.Loc_ID " & Environment.NewLine
            strSql &= " LEFT JOIN production.tpallett E ON E.pallett_id= B.pallett_id " & Environment.NewLine
            strSql &= " LEFT JOIN production.tpackingslip F ON F.pkslip_id=E.pkslip_id " & Environment.NewLine
            strSql &= "WHERE A.Cust_id=" & iCust_ID & " AND A.loc_id=" & iLocid & " AND    F.pkslip_createDt BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13   AND A.ACCOUNT NOT IN ('CRICKET','ATT') Group BY B.device_id; " & Environment.NewLine

            'strSql &= " (SELECT Swapped_Device_ID, D.device_id, ClaimNo as PONumber ,Item_Sku as SKU,Model,SerialNo," & Environment.NewLine
            'strSql &= " (Device_sn) as IMEI,'Premier Logitech' as 'Service Center'," & Environment.NewLine
            'strSql &= "DATE_FORMAT(D.Device_DateRec,'%m/%d/%Y') as 'Date Received' ,DATE_FORMAT(pallett_Shipdate,'%m/%d/%Y') AS 'Date Shipped'," & Environment.NewLine
            'strSql &= " (TO_DAYS(C.pallett_shipdate) - TO_DAYS(D.Device_DateRec)) as 'Days',IF(D.Device_Laborlevel=15,0,D.Device_Laborlevel) AS RepairLevel," & Environment.NewLine
            'strSql &= "if(G.billcode_id IN(275,267),'RUR',if (G.billcode_id='1020','BER',if (G.billcode_id is Not null,'REF','' ) )) as 'Disposition',pallett_name,Retailer2 as ReturnPlanID,Warranty_Desc AS RepairProgramType,if(Swapped_Device_ID >0,'YES','NO')AS 'Swap device' ,  D.device_LaborCharge AS  TotalCost,P.pkslip_trackNo AS 'Tracking #'   " & Environment.NewLine
            'strSql &= "FROM extendedwarranty A" & Environment.NewLine
            'strSql &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
            'strSql &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            'strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            'strSql &= " INNER JOIN production.tpackingslip P ON P.pkslip_id=C.pkslip_id " & Environment.NewLine
            'strSql &= "LEFT OUTER JOIN tpretest_data F ON D.device_Id= F.device_Id " & Environment.NewLine
            'strSql &= "LEFT OUTER JOIN lcodesdetail E ON E.Dcode_id=F.Pttf" & Environment.NewLine
            'strSql &= "LEFT OUTER JOIN production.tdevicebill G ON D.device_Id= G.device_Id" & Environment.NewLine

            'If iOption = 1 Then
            '    strSql &= " WHERE D.device_SN IN ( " & strImei & " ) AND  A.sourcefile NOT LIKE '%seed%' GROUP BY Device_sn  " & Environment.NewLine
            'Else
            '    strSql &= " WHERE    A.LOC_ID=" & Locid & "   AND A.sourcefile NOT LIKE '%seed%' AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13  " & Environment.NewLine
            '    strSql &= "GROUP BY D.device_id order by pallett_name" & Environment.NewLine
            'End If
            'strSql &= " )UNION (SELECT  Swapped_Device_ID,D.device_id,  ClaimNo as PONumber ,Item_Sku as SKU,Model ,SerialNo," & Environment.NewLine
            'strSql &= " (Device_sn) as IMEI,'Premier Logitech' as 'Service Center'," & Environment.NewLine
            'strSql &= "DATE_FORMAT(D.Device_DateRec,'%m/%d/%Y') as 'Date Received' ,DATE_FORMAT(pallett_Shipdate,'%m/%d/%Y') AS 'Date Shipped'," & Environment.NewLine
            'strSql &= " (TO_DAYS(pallett_Shipdate) - TO_DAYS(D.Device_DateRec)) as 'Days',IF(D.Device_Laborlevel=15,0,D.Device_Laborlevel) AS RepairLevel," & Environment.NewLine
            'strSql &= "'REF' as 'Disposition',pallett_name,Retailer2 as ReturnPlanID,Warranty_Desc AS RepairProgramType,if(Swapped_Device_ID >0,'YES','NO')AS 'Swap device',D.device_LaborCharge  AS  TotalCost  ,P.pkslip_trackNo AS 'Tracking #'   " & Environment.NewLine
            'strSql &= "FROM extendedwarranty A" & Environment.NewLine
            'strSql &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            'strSql &= "inner join tdevice D ON D.device_id=A.Swapped_Device_ID" & Environment.NewLine
            'strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            'strSql &= " INNER JOIN production.tpackingslip P ON P.pkslip_id=C.pkslip_id " & Environment.NewLine

            'If iOption = 1 Then
            '    strSql &= " WHERE D.device_SN IN ( " & strImei & " )  GROUP BY Device_sn  " & Environment.NewLine
            'Else
            '    strSql &= " WHERE  A.LOC_ID=" & Locid & "  AND  pkslip_createDt BETWEEN '" & dateRec & "' AND '" & dateEnd & "'  and  Pallet_ShipType!=13 " & Environment.NewLine
            '    strSql &= "GROUP BY D.device_id  order by pallett_name )" & Environment.NewLine
            'End If
            dt1 = Me._objDataProc.GetDataTable(strSql)
            If dt1.Rows.Count = 0 Then
                MsgBox("There is no data in PSS Database for the criterion provided.")
                Return 0
                Exit Function
            Else
                Return CreateRawDataExcelFileInvoice(dt1, dt2, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath, strLocation, iLocid)
            End If
        End Function
        Public Function CreateRawDataExcelFileInvoice(ByRef dt1 As DataTable, ByRef dt2 As DataTable, ByVal strFromDt As String, _
                                                       ByVal strToDt As String, _
                                                       ByVal strRptPath As String, _
                                                       ByVal strLocation As String, ByVal iLocid As Integer) As Integer
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
            Dim strColumn() As String = {"PONumber", "SKU", "Model", "Original IMEI", "New IMEI", "Service Center", "Date Received", "Date Shipped", "Days", "Code Failure1", "Failure Reason1", _
            "Code Failure2", "Failure Reason2", "Code Failure3", "Failure Reason3", "Code Failure4", "Failure Reason4", "RepairLevel", "Disposition", "pallett_name", "Tracking #", "ReturnPlanID", _
            "RepairProgramType", "PartNo1", "UseQty1", "PartNo2", "UseQty2", "PartNo3", "UseQty3", "PartNo4", "UseQty4", "PartNo5", "UseQty5", "PartNo6", "UseQty6", "PartNo7", "UseQty7", "PartNo8", "UseQty8" _
            , "PartNo9", "UseQty9", "PartNo10", "UseQty10", "Swap device", "Labor Charge", "Parts Charge", "Total Cost"}
            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                objSheet.Name = " WIKO INVOICE REPORT" 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                For j = 0 To strColumn.Length - 1
                    objExcel.Application.Cells(i, j + 1).Value = strColumn(j)
                Next
                '*****************************************

                objSheet.Range("A1", "AU1").ColumnWidth = 25
                objSheet.Range("A1", "AU1").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:AU3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & 1 & ":AU" & 1 & "").Select()
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

                ReDim arrData(dt1.Rows.Count, 51)

                For Each R1 In dt1.Rows
                    dBilling = 0.0 'gettdeviceBill(R1("IMEI"))
                    Dim Device_LaborLevel As Integer
                    Dim iDeviceID As Integer
                    Dim iRepairLvel As Integer
                    Dim iLaborcharge As Double
                    If Not IsDBNull(R1("RepairLevel")) Then
                        iRepairLvel = R1("RepairLevel")
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        iLaborcharge = Trim(R1("TotalCost"))
                    End If
                    If Trim(R1("IMEI")) = Trim(R1("SerialNo")) Then
                        iDeviceID = R1("Device_id")
                    Else
                        iDeviceID = getdeviceID(R1("IMEI"))
                        If iDeviceID = 0 Then
                            iDeviceID = R1("Device_id")
                        End If
                        Dim dtLabor As DataTable = Me.getDeviceRepairedLevel(iDeviceID)
                        If dtLabor.Rows.Count > 0 Then
                            If Not IsDBNull(dtLabor.Rows(0)("Device_LaborLevel")) And Not IsDBNull(dtLabor.Rows(0)("device_laborcharge")) Then
                                iRepairLvel = dtLabor.Rows(0)("Device_LaborLevel")
                                iLaborcharge = dtLabor.Rows(0)("device_laborcharge")
                            Else
                                If Not IsDBNull(R1("TotalCost")) Then
                                    iRepairLvel = Trim(R1("RepairLevel"))
                                    iLaborcharge = Trim(R1("TotalCost"))
                                End If
                            End If
                        End If
                    End If

                    Dim dtBillPart As DataTable
                    dtBillPart = gettdeviceBill(iDeviceID)
                    If dtBillPart.Rows.Count = 0 Then
                        dBilling = 0.0
                    Else
                        dBilling = dtBillPart.Compute("SUM(Total)", String.Empty)
                    End If

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
                    dtFailureCode = getDeviceFailCode(R1("OriginalDevice"))
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

                    If Not IsDBNull(iRepairLvel) Then
                        arrData(i, 17) = iRepairLvel
                    End If
                   

                    'If Not IsDBNull(R1("RepairLevel")) Then
                    '    arrData(i, 17) = Trim(R1("RepairLevel"))
                    'End If
                    If Not IsDBNull(R1("Disposition")) Then
                        arrData(i, 18) = Trim(R1("Disposition"))
                    End If
                    If Not IsDBNull(R1("pallett_name")) Then
                        arrData(i, 19) = Trim(R1("pallett_name"))
                    End If
                    If Not IsDBNull(R1("Tracking #")) Then
                        arrData(i, 20) = Trim(R1("Tracking #"))
                    End If
                    If Not IsDBNull(R1("ReturnPlanID")) Then
                        arrData(i, 21) = Trim(R1("ReturnPlanID"))
                    End If
                    If Not IsDBNull(R1("RepairProgramType")) Then
                        arrData(i, 22) = Trim(R1("RepairProgramType"))
                    End If
                    Dim dtPartNumber As New DataTable()
                    'dtPartNumber = getDevicePart(R1("IMEI"))
                    Dim iCountPart As Integer = 0
                    For iPartCount = 23 To 41 Step 2
                        If iCountPart < dtBillPart.Rows.Count Then
                            Dim strPartNumber As String = dtBillPart.Rows(iCountPart).Item("Part_Number")
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
                        arrData(i, 43) = Trim(R1("Swap device"))
                    End If

                    If Not IsDBNull(iLaborcharge) Then
                        arrData(i, 44) = iLaborcharge
                    End If
                    'If Not IsDBNull(R1("TotalCost")) Then
                    '    arrData(i, 44) = Trim(R1("TotalCost"))
                    'End If
                    If Not IsDBNull(dBilling) Then
                        arrData(i, 45) = Trim(dBilling)
                    End If
                    If Not IsDBNull(iLaborcharge) Then
                        dSUM = Convert.ToDecimal(iLaborcharge) + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM
                        arrData(i, 46) = "$" & FormatNumber(iLaborcharge, 2, TriState.False, TriState.True, TriState.True)
                    End If
                    i += 1
                Next R1
                objSheet.Range("A4", "AU" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("A4", "AU" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "AU" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:AU" & (dt1.Rows.Count + 3)).Select()
                objSheet.Range("AS4", "AS" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AT4", "AT4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AU4", "AU4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("D4", "D" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("E4", "E" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("U4", "U" & (dt1.Rows.Count + 3)).NumberFormat = 0

                objSheet.Range("H4", "H" & (dt1.Rows.Count + 3)).NumberFormat = "MM/dd/yyyy"
                objSheet.Range("G4", "G" & (dt1.Rows.Count + 3)).NumberFormat = "MM/dd/yyyy"

                Dim iXrange As Integer = (dt1.Rows.Count + 3)
                Dim result As String
                result = dt1.Compute("SUM(TotalCost)", "")
                objExcel.Application.Cells(dt1.Rows.Count + 4, 46).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 47).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
                'set font
                setFont(objExcel)
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
            Dim strPath As String = "P:\OUTBOUND\WEX ORDERS\WIKO-VINSMART-WINGTECH-ATT\"
            Dim strDate As String = dtTime.ToString("yyyyMMddHHmmss")
            Dim strSQLTemp As String
            Dim dtRow As DataRow
            Locid = getLocationId(strLocationId, iCust_ID)
            Dim i As Integer
            Dim strSql3 As String = ""
            Try
                strSql3 &= "SELECT 'EMBLEM'as OEM,ClaimNo AS 'Order #',item_SKU as SKU,item_desc as Model" & Environment.NewLine
                If Locid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID.ToString Then
                    strSql3 &= " ,Device_SN as IMEI,In_pallet_ID AS 'Pallett Name' " & Environment.NewLine
                Else
                    strSql3 &= " ,'' as IMEI,'' AS 'Pallett Name' " & Environment.NewLine
                End If
                strSql3 &= ", IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y'))) as 'Order Date (Receive Date)' " & Environment.NewLine
                strSql3 &= ", (TO_DAYS(CURDATE()) - TO_DAYS(Device_DateRec)) AS 'Order Age(TAT)' ,0 AS 'Order Qty',COUNT(device_sn) AS 'Qty Rcvd',0 AS 'Qty Due', " & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= " E.pkslip_trackNo AS 'Tracking #',IF(pkslip_createDt  IS NULL,'', IF(DATE_FORMAT(pkslip_createDt,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(pkslip_createDt ,'%m/%d/%Y'))) as 'Date Shipped(ASN files uploaded)','' as 'Comments: Overdue TAT reason'" & Environment.NewLine
                Else
                    strSql3 &= " '' AS 'Tracking #','' as 'Date Shipped(ASN files uploaded)','' as 'Comments: Overdue TAT reason'" & Environment.NewLine
                End If
                strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
                strSQLTemp = strSql3
                If iStatus = 0 Then
                    strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                    strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
                    strSql3 &= "inner join tdevice D ON D.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
                Else
                    strSql3 &= "inner join tdevice D ON D.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id)) " & Environment.NewLine
                    strSql3 &= "LEFT JOIN tpallett P ON D.Pallett_ID=P.Pallett_ID" & Environment.NewLine
                End If

                strSql3 &= "inner join tmodel F ON D.Model_id=F.Model_id " & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= "WHERE A.sourceFile NOT LIKE '%seed%'  and  pkslip_createDt  BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and ClaimNo NOT LIKE '%Seed%' AND Pallet_ShipType!=13 " & Environment.NewLine
                Else
                    strSql3 &= "WHERE A.sourceFile NOT LIKE '%seed%'  AND Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND (if ( D.Pallett_ID IS NOT  NULL ,  Pallet_ShipType=13, ship_ID is null  AND device_dateship IS NULL ))  " & Environment.NewLine

                End If
                ' WEX for Crckect
                If Locid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID.ToString _
                   OrElse Locid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID _
                 OrElse Locid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                    strSql3 &= " AND A.ACCOUNT='569955' " & Environment.NewLine
                Else
                    strSql3 &= " AND A.ACCOUNT not in ('POS') " & Environment.NewLine
                End If
                If iStatus = 1 Then
                    strSql3 &= " AND A.loc_id IN (" & Locid & " )   GROUP BY claimNo" & Environment.NewLine
                Else
                    strSql3 &= " AND A.loc_id IN (" & Locid & " )  GROUP BY claimNo, E.pkslip_trackNo" & Environment.NewLine
                End If
                dtSummary = Me._objDataProc.GetDataTable(strSql3)
                Dim iQtyOrdered As Integer
                Dim iQtyReceived As Integer
                Dim iQtyShipped As Integer
                Dim Receive_date As Date
                For Each dtRow In dtSummary.Rows
                    iQtyOrdered = wexOrdered(Convert.ToString(dtRow("Order #")))
                    iQtyShipped = wexShipped(Convert.ToString(dtRow("Order #")))
                    Receive_date = getWexDate(Convert.ToString(dtRow("Order #")))
                    dtRow("Order Date (Receive Date)") = Receive_date.ToString("MM/dd/yyyy")
                    dtRow("Order Qty") = iQtyOrdered
                    If iStatus = 1 Then
                        iQtyReceived = wexReceived(Convert.ToString(dtRow("Order #")))
                        dtRow("Qty Due") = dtRow("Qty Rcvd")
                        dtRow("Qty Rcvd") = iQtyReceived
                        dtRow("Order Age(TAT)") = getDateDiff(Receive_date, Date.Now.Date)
                    Else
                        dtRow("Order Age(TAT)") = getDateDiff(Receive_date, dtRow("Date Shipped(ASN files uploaded)"))
                        dtRow("Qty Due") = iQtyOrdered - iQtyShipped
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
        Public Function wexOrdered(ByVal strClaimNo As String) As Integer
            Dim strSql3 As String = " SELECT serialNo FROM extendedwarranty WHERE claimNo='" + strClaimNo + "'; " & Environment.NewLine
            Dim dtwexOrdered As DataTable = Me._objDataProc.GetDataTable(strSql3)
            Return dtwexOrdered.Rows.Count
        End Function

        Public Function wexShipped(ByVal strClaimNo As String) As Integer

            Dim strSql3 As String = "SELECT device_sn   FROM extendedwarranty A" & Environment.NewLine
            strSql3 &= "INNER JOIN tdevice B ON B.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
            strSql3 &= "INNER JOIN tpallett C ON C.Pallett_ID=B.Pallett_ID " & Environment.NewLine
            strSql3 &= " WHERE claimNo='" + strClaimNo + "' AND B.Device_DateShip IS NOT NULL AND Pallet_ShipType!=13   " & Environment.NewLine
            Dim dtWexShipped As DataTable = Me._objDataProc.GetDataTable(strSql3)
            Return dtWexShipped.Rows.Count
        End Function
        Public Function getWexDate(ByVal strClaimNo As String) As Date
            Dim strSql3 As String = "SELECT B.Device_DateRec FROM extendedwarranty  A " & Environment.NewLine
            strSql3 &= " INNER JOIN tdevice B ON A.device_id=B.device_id " & Environment.NewLine
            strSql3 &= " WHERE claimNo='" + strClaimNo + "'   ORDER BY Device_DateRec ASC LIMIT 1 " & Environment.NewLine
            Dim dtWexDate As DataTable = Me._objDataProc.GetDataTable(strSql3)
            Return dtWexDate.Rows(0)("Device_DateRec")
        End Function
        Public Function getDateDiff(ByVal startDate As DateTime, ByVal EndDate As DateTime) As Integer
            Dim iTotalDays As Integer = 0
            Dim iWorkdays As Integer = 0
            Dim iWeekEndDays As Integer = 0
            Dim i As Integer
            iTotalDays = DateDiff(DateInterval.Day, startDate, EndDate) + 1
            For i = 0 To iTotalDays
                Dim weekday As DayOfWeek = startDate.AddDays(i).DayOfWeek
                If weekday = DayOfWeek.Saturday Then
                    iWeekEndDays += 1
                End If
                If weekday = DayOfWeek.Sunday Then
                    iWeekEndDays += 1
                End If
            Next
            Return iTotalDays - iWeekEndDays
        End Function

        Public Function wexReceived(ByVal strClaimNo As String) As Integer
            Dim strSql3 As String = " SELECT serialNo FROM extendedwarranty  A " & Environment.NewLine
            strSql3 &= " INNER JOIN tdevice B ON A.device_id=B.device_id " & Environment.NewLine
            strSql3 &= " WHERE claimNo='" + strClaimNo + "' " & Environment.NewLine
            Dim dtWexReceived As DataTable = Me._objDataProc.GetDataTable(strSql3)
            Return dtWexReceived.Rows.Count
        End Function


        Public Sub CreateExcelFile_ATT(ByVal dt1 As DataTable, ByVal strRptPath As String)
            Dim i, j As Integer
            Dim xlApp As Excel.Application
            Dim dtcolumn As DataColumn
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            xlWorkSheet.Range("A1", "L1").ColumnWidth = 25
            xlWorkSheet.Range("A1", "L1").HorizontalAlignment = Excel.Constants.xlLeft

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
      
        Private strLocid As String
        Public Function CreateInvoiceATTCTDI(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim strReportName As String = String.Empty
            _cust_Id = iCust_ID
            Dim dt2 As New DataTable()
            Dim dtSummary As DataTable
            Dim iLocid As Integer
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            iLocid = getLocationId(strLocation, iCust_ID)
            strLocid = ""
            If iLocid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID OrElse iLocid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID Then
                Me.strLocid = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
            ElseIf iLocid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID OrElse iLocid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID Then
                Me.strLocid = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
            ElseIf iLocid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID OrElse iLocid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID Then
                Me.strLocid = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID
            Else
                Me.strLocid = iLocid
            End If

            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xlsx"
            Dim strRptPath As String = strRptDir & strFileName
            If iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                strReportName = "WIKO"
            ElseIf iCust_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                strReportName = "VINSMART"
            ElseIf iCust_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                strReportName = "WINGTECH ATT"
            End If
            Dim i As Integer
            Dim strSql3 As String = ""
            Try
                strSql3 &= "SELECT B.device_id,K.Device_ID AS OriginalDeviceID,ClaimNo AS 'PO #',  IF( K.Device_DateRec  IS NULL,'', IF(DATE_FORMAT(K.Device_DateRec,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(K.Device_DateRec ,'%m/%d/%Y')))  AS 'Received Date'" & Environment.NewLine
                strSql3 &= ",Item_SKU AS SKU ,SerialNO as 'Original IMEI',pallett_Name AS 'Box Name',B.Device_LaborLevel AS 'RepairLevel', B.device_laborcharge as TotalCost, " & Environment.NewLine
                strSql3 &= "IF (E.pkslip_id IS NULL,'',if(A.Swapped_Device_ID >0,'Swapp',IF (pallet_ShipType=2,'RUR',if(pallet_ShipType=1,'BER',IF(pallet_ShipType=0 AND B.Device_LaborLevel>0,'Repaired',if(pallet_ShipType =0 AND B.Device_LaborLevel IN (0,15) AND A.Swapped_Device_ID =0,'NTF','')))))) AS  condition," & Environment.NewLine
                strSql3 &= "( B.Device_SN) AS 'Device Shipped', IF( F.pkslip_createDt  IS NULL,'', IF(DATE_FORMAT(F.pkslip_createDt,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(F.pkslip_createDt ,'%m/%d/%Y')))  AS 'Ship Date',F.pkslip_TrackNo  AS 'Tracking #' ,CAST(TO_DAYS(F.pkslip_createDt) - TO_DAYS(B.Device_DateRec) AS UNSIGNED)   AS  'AgedWIP'" & Environment.NewLine
                strSql3 &= "FROM production.extendedwarranty A" & Environment.NewLine
                strSql3 &= "INNER JOIN tdevice B ON B.device_id=(if (A.swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
                strSql3 &= "INNER JOIN production.tdevice K ON K.device_id= A.device_id  " & Environment.NewLine
                strSql3 &= "LEFT JOIN production.tpretest_data C ON  C.device_id =K.Device_ID" & Environment.NewLine
                strSql3 &= "LEFT JOIN lcodesdetail D on C.PTtf = D.Dcode_id  " & Environment.NewLine
                strSql3 &= " INNER JOIN production.tLocation G ON A.Loc_ID=G.Loc_ID" & Environment.NewLine
                strSql3 &= "LEFT JOIN production.tpallett E ON E.pallett_id= B.pallett_id " & Environment.NewLine
                strSql3 &= "LEFT JOIN production.tpackingslip F ON F.pkslip_id=E.pkslip_id 	" & Environment.NewLine
                strSql3 &= "WHERE A.Cust_id=" & iCust_ID & " AND A.loc_id=" & iLocid & " AND    F.pkslip_createDt BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13   AND A.ACCOUNT NOT IN ('CRICKET','ATT') Group BY B.device_id; " & Environment.NewLine
                dtSummary = Me._objDataProc.GetDataTable(strSql3)
                If dtSummary.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.")
                    Return 0
                    Exit Function
                Else
                    Return CreateRawDataExcelFileInvoiceATT(dtSummary, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath, strLocation, strReportName, iLocid)
                End If
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
            Dim Locid As String
            Dim strTempQuery As String
            Dim strCol As String
            Try
                If iReportType = 1 Then
                    strCol = "SerialNo as IMEI"
                ElseIf iReportType = 3 Then
                    strCol = "Device_sn as 'Shipped IMEI', SerialNO AS 'Original IMEI'"
                ElseIf iReportType = 4 Then
                    strCol = "If (A.device_id=0, SerialNo, device_sn) AS 'IMEI'"
                Else
                    strCol = "Device_sn as 'IMEI' "
                End If
                Locid = getLocationId(strLocation, iCust_ID)
                strSql = "SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date',CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer'," & strCol & " ,ClaimNo AS 'RA_Number',Item_SKU AS 'Model'" & Environment.NewLine
                strSql &= " , IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(DATE,'%m/%d/%Y'))) AS 'RA_Date',A.Account AS 'OEM_Account'" & Environment.NewLine
                strSql &= " ,IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y/%m/%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%m/%d/%Y'))) AS 'Carrier_Date'" & Environment.NewLine
                strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%m/%d/%Y')))  AS 'IMM Date',Customer_Work_Number AS 'Cust_WO'" & Environment.NewLine
                strSql &= ",  IF( A.Account  ='569955' ,'Warranty Exchange', IF( A.Account  ='569969' ,'DOA', 'Underfined'  )  ) as 'Return_Type' " & Environment.NewLine
                If iReportType <> 1 Then
                    strSql &= " ,IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y')))  AS 'Received Date',  IF( E.device_laborLevel  =0 , 'NTF', IF( E.device_laborLevel  =1  ,'Refurbished',  IF( E.device_laborLevel  = 2  ,'Repaired ',IF(E.device_laborLevel  = 4454  ,'RUR ','' ) ) ) ) as 'Return_Reason',Item_Desc as 'Cricket Claimed Handset Description'" & Environment.NewLine
                End If
                strSql &= "  ,Item_Desc" & Environment.NewLine
                strSql &= " ,OEM_RA,IMM_Order,IMM_Shipped_SKU" & Environment.NewLine
                'add a column status if the report type is Status report
                If iReportType = 4 Then
                    strSql &= ",  Device_DateBill AS 'Bill Date'" & Environment.NewLine
                    strSql &= ",   IF( Device_DateShip  IS NOT NULL AND  Pallet_ShipType!=13  ,'Produced (Shipped)', IF(Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status" & Environment.NewLine
                ElseIf iReportType = 3 Then
                    strSql &= " ,IF(  Device_DateShip IS NULL,'', IF(DATE_FORMAT(Device_DateShip,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(Device_DateShip,'%m/%d/%Y'))) AS 'Ship Date',S.pkslip_TrackNo as 'Tracking Number',Pallett_name as 'Pallet Name',E.pallett_id as 'Carton Id'" & Environment.NewLine
                    strSql &= ",part_Number ,PSPrice_Desc as Description ,  (device_laborLevel) AS 'Labor Level'" & Environment.NewLine
                End If
                If iReportType = 1 Then
                    strSql &= " , IF(A.Device_id>0,'RECEIVED','OPEN') AS 'Status' " & Environment.NewLine
                End If
                strSql &= " ,B.WO_CustWO AS 'Work_Order',  SourceFile,In_pallet_id as 'Pallett IN'" & Environment.NewLine
                If iReportType = 7 Then
                    strSql = ""
                    strSql = " SELECT SerialNo AS 'Cricket Claimed IMEI', (device_laborLevel) AS 'Labor Level',F.part_Number,PSPrice_Desc as Description " & Environment.NewLine
                End If
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                If iReportType = 3 OrElse iReportType = 7 Then
                    strTempQuery = strSql
                End If
                Select Case iReportType

                    Case 1 'RA_uploaded
                        If iOption = 1 Then
                            strSql &= " WHERE SerialNo IN ( " & strImei & " ) and A.sourcefile not like '%REF%'" & Environment.NewLine
                        Else
                            strSql &= " WHERE A.sourcefile not like '%REF%' AND A.Cust_ID=" & iCust_ID & "  AND A.LOC_ID=" & Locid & " AND LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine
                        End If

                    Case 2 'Received_Report
                        strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) AND A.sourcefile not like '%REF%' Group BY E.device_id " & Environment.NewLine
                        Else
                            strSql &= " WHERE   A.Cust_ID=" & iCust_ID & " AND A.LOC_ID=" & Locid & "   AND A.sourcefile not like '%REF%' AND E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' Group BY E.device_id" & Environment.NewLine
                        End If
                    Case 3, 7 'Shipped 
                        strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpallett P ON P.pallett_id= E.pallett_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpackingslip S ON S.pkslip_id=P.pkslip_id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.tdevicebill F ON F.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.lpsprice J ON  J.PSPrice_Number=F.part_Number" & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )AND  A.sourcefile not like '%seed%' Group BY E.device_id" & Environment.NewLine
                        Else
                            strSql &= " WHERE  A.Cust_ID=" & iCust_ID & " AND  A.LOC_ID=" & Locid & "  AND A.sourcefile not like '%seed%' AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13  Group BY E.device_id " & Environment.NewLine
                        End If
                        strSql &= " UNION " & Environment.NewLine
                        strSql &= strTempQuery
                        strSql &= " INNER JOIN production.tdevice E ON E.device_id=A.swapped_device_id  " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpallett P ON P.pallett_id= E.pallett_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpackingslip S ON S.pkslip_id=P.pkslip_id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.tdevicebill F ON F.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.lpsprice J ON  J.PSPrice_Number=F.part_Number" & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) Group BY E.device_id" & Environment.NewLine
                        Else
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND  A.LOC_ID=" & Locid & " AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13 Group BY E.device_id " & Environment.NewLine
                        End If
                    Case 4 'Status 
                        'strTempQuery = strSql
                        strSql &= " LEFT OUTER JOIN production.tdevice E ON E.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id))   " & Environment.NewLine
                        strSql &= " LEFT JOIN tpallett P ON P.Pallett_ID=E.Pallett_ID " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) and A.sourcefile not like '%REF%'  Group BY E.device_id " & Environment.NewLine
                        Else
                            strSql &= " WHERE  A.cust_ID=" & iCust_ID & " AND  A.LOC_ID IN (" & Locid & ") AND SOURCEFILE NOT LIKE '%Seed%'   AND (if ( P.Pallett_ID IS NOT  NULL ,  Pallet_ShipType!=13  ,device_dateship IS NULL AND P.Pallett_ID IS null ))" & Environment.NewLine
                        End If
                    Case Else
                        Return 0
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


        Public Function getLocationId(ByVal Loc_id As String, ByVal iCust_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow
            Dim LocId As Integer
            Try
                strSql = "SELECT Loc_id FROM tlocation where Loc_name  like '%" & Loc_id & "%' and Cust_ID =" & iCust_ID & " ;" & Environment.NewLine
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


        Public Function CreatePretestRawDataRpt(ByVal iCust_id As Integer, ByVal strFromDt As String, _
                                         ByVal strToDt As String, _
                                         ByRef strRptPath As String, ByVal strLocation As String, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim R1, R2 As DataRow
            Dim strsql As String = ""
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xlsx"
            strRptPath = strRptDir & strFileName
            Dim Locid As Integer = getLocationId(strLocation, iCust_id)
            Try
                strsql = "SELECT Distinct tdevice.device_sn as 'Serial No'," & Environment.NewLine
                strsql &= "'' as Pretester, " & Environment.NewLine
                strsql &= "'' as 'Pretester Shift', " & Environment.NewLine
                strsql &= "tpretest_data.tech_id, " & Environment.NewLine
                strsql &= "DATE_FORMAT(tpretest_data.Date_Rec,'%m/%d/%Y') as 'Pretest Date', " & Environment.NewLine
                strsql &= "lqcresult.QCResult as 'Result', " & Environment.NewLine
                strsql &= "if(lcodesdetail.Dcode_ID = 2515, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine
                strsql &= "tpretest_data.Device_id , " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine

                strsql &= "tmodel.Model_desc as 'Model' " & Environment.NewLine
                strsql &= ", Prod_Desc as 'Product Type', tpretest_data.FailOther " & Environment.NewLine
                strsql &= ",  IF( extendedwarranty.Account  ='569955' ,'Emblem Solution', IF( extendedwarranty.Account  ='569969' ,'Emblem Solution DOA', IF(extendedwarranty.Account='POS','POS','Underfined')  )  ) as Account " & Environment.NewLine
                strsql &= " ,MAX(tdevice.device_laborLevel)AS device_laborLevel,SourceFile,Return_Reason FROM tpretest_data " & Environment.NewLine
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
                objExcel.Application.Cells(i, 7).Value = "Customer Complaint"
                objExcel.Application.Cells(i, 8).Value = "Account"
                objExcel.Application.Cells(i, 9).Value = "Model"
                objExcel.Application.Cells(i, 10).Value = "Product Type"
                objExcel.Application.Cells(i, 11).Value = "Source File"

                '*****************************************
                'Set column widths
                '*****************************************

                objSheet.Range("A1", "K1").ColumnWidth = 35.71 'Serial No
                objSheet.Range("A1", "K1").HorizontalAlignment = Excel.Constants.xlLeft
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
                objSheet.Range("A3:K3").Select()
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
                    If Not IsDBNull(R1("Return_Reason")) Then
                        arrData(i, 6) = Trim(R1("Return_Reason"))
                    End If
                    If Not IsDBNull(R1("Account")) Then
                        arrData(i, 7) = Trim(R1("Account"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 8) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("Product Type")) Then
                        arrData(i, 9) = Trim(R1("Product Type"))
                    End If
                    If Not IsDBNull(R1("SourceFile")) Then
                        arrData(i, 10) = Trim(R1("SourceFile"))
                    End If
                    i += 1
                Next R1

                objSheet.Range("A4", "K" & (dt1.Rows.Count + 3)).Value = arrData

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:K" & (dt1.Rows.Count + 3)).Select()

                'Set Font
                setFont(objExcel)
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
                objExcel.Application.Cells(1, 1).Value = "WIKO Pretest Raw Data Report"
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

        Private Function gettdeviceBill(ByVal iDevice_ID As Integer) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT   PsPrice_StndCost  as Total,Part_Number,Device_LaborLevel FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill B ON A.device_id=B.device_id" & Environment.NewLine
            strSql &= "INNER JOIN lpsprice C ON  C.PSPrice_Number=B.part_Number" & Environment.NewLine
            strSql &= " WHERE (A.loc_id in (" & strLocid & ") AND A.DEVICE_ID=" & iDevice_ID & "  )  " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function

        Private Function getdeviceID(ByVal strDevice_sn As String) As Integer
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT  A.device_id FROM tdevice A INNER JOIN extendedwarranty B ON A.device_id=B.device_id" & Environment.NewLine
            strSql &= " WHERE A.loc_id IN (" & strLocid & ") AND device_sn='" & strDevice_sn & "' and swapped_device_id>0 ORDER BY  Device_DateShip DESC; " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)("device_id"))
            Else
                strSql = String.Empty
                strSql &= "SELECT  A.device_id FROM tdevice A INNER JOIN extendedwarranty B ON A.device_id=B.device_id" & Environment.NewLine
                strSql &= " WHERE A.loc_id IN (" & strLocid & ") AND device_sn='" & strDevice_sn & "' and Account in ('ATT','Cricket') ORDER BY  Device_DateShip DESC; " & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)
                Return (dt.Rows(0)("device_id"))
            End If
        End Function

        Private Function gettdeviceParts(ByVal iDevice_ID As Integer) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT  Part_Number FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill B ON A.device_id=B.device_id" & Environment.NewLine
            strSql &= "INNER JOIN lpsprice C ON  C.PSPrice_Number=B.part_Number" & Environment.NewLine
            strSql &= " WHERE (A.loc_id IN (" & strLocid & ") AND A.DEVICE_ID=" & iDevice_ID & "  )  " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function

        Private Function getDeviceRepairedLevel(ByVal iDeviceId As Integer) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT  Device_LaborLevel,device_laborcharge FROM tdevice A" & Environment.NewLine
            strSql &= " WHERE ( A.loc_id IN (" & strLocid & ") AND device_id=" & iDeviceId & ") ORDER BY  Device_DateShip DESC; " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            dt = _objDataProc.GetDataTable(strSql)
            'If Not IsDBNull(dt.Rows(0)("total")) Then
            Return dt
            'Else
            '    Return 0
            'End If
        End Function

        Private Function getDeviceFailCode(ByVal iDeviceId As Integer) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty

            strSql &= "SELECT distinct(Dcode_Sdesc),Dcode_Ldesc  " & Environment.NewLine
            strSql &= "FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN lcodesdetail B ON B.Dcode_id=C.Pttf" & Environment.NewLine
            strSql &= "INNER JOIN tpretest_data C ON A.device_Id= C.device_Id " & Environment.NewLine
            strSql &= "WHERE  A.device_ID=" & iDeviceId & "" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function


        Public Function CreateRawDataExcelFileInvoiceATT(ByRef dt1 As DataTable, ByVal strFromDt As String, _
                                                       ByVal strToDt As String, _
                                                       ByVal strRptPath As String, _
                                                       ByVal strLocation As String, ByVal strReportName As String, ByVal iloc_id As Integer) As Integer
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
                objSheet.Name = "INVOICE REPORT" 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************

                xlCells = objSheet.Range("H:H")
                xlCells.Select()
                xlCells.NumberFormat = "@"

                objExcel.Application.Cells(i, 1).Value = "PO #'"
                objExcel.Application.Cells(i, 2).Value = "Original IMEI"
                objExcel.Application.Cells(i, 3).Value = "SKU"
                objExcel.Application.Cells(i, 4).Value = "Received Date"
                objExcel.Application.Cells(i, 5).Value = "Device Shipped"
                objExcel.Application.Cells(i, 6).Value = "Box Name"
                objExcel.Application.Cells(i, 7).Value = "Date Shipped"
                objExcel.Application.Cells(i, 8).Value = "condition"
                objExcel.Application.Cells(i, 9).Value = "Tracking #"
                objExcel.Application.Cells(i, 10).Value = "Code Failure1"
                objExcel.Application.Cells(i, 11).Value = "Failure Reason1"
                objExcel.Application.Cells(i, 12).Value = "Code Failure2"
                objExcel.Application.Cells(i, 13).Value = "Failure Reason2"
                objExcel.Application.Cells(i, 14).Value = "Code Failure3"
                objExcel.Application.Cells(i, 15).Value = "Failure Reason3"
                objExcel.Application.Cells(i, 16).Value = "Code Failure4"
                objExcel.Application.Cells(i, 17).Value = "Failure Reason4"
                objExcel.Application.Cells(i, 18).Value = "PartNo1"
                objExcel.Application.Cells(i, 19).Value = "UseQty1"
                objExcel.Application.Cells(i, 20).Value = "PartNo2"
                objExcel.Application.Cells(i, 21).Value = "UseQty2"
                objExcel.Application.Cells(i, 22).Value = "PartNo3"
                objExcel.Application.Cells(i, 23).Value = "UseQty3"
                objExcel.Application.Cells(i, 24).Value = "PartNo4"
                objExcel.Application.Cells(i, 25).Value = "UseQty4"
                objExcel.Application.Cells(i, 26).Value = "PartNo5"
                objExcel.Application.Cells(i, 27).Value = "UseQty5"
                objExcel.Application.Cells(i, 28).Value = "Labor Level"
                objExcel.Application.Cells(i, 29).Value = "Labor Charge"
                objExcel.Application.Cells(i, 30).Value = "Parts Charge"
                objExcel.Application.Cells(i, 31).Value = "Total Cost"

                '*****************************************

                objSheet.Range("A1", "AE1").ColumnWidth = 25 'PO
                objSheet.Range("A1", "AE1").HorizontalAlignment = Excel.Constants.xlLeft


                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:AE3").Select()
                With objExcel.Selection
                    '.WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & 1 & ":AE" & 1 & "").Select()
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

                ReDim arrData(dt1.Rows.Count, 43)

                For Each R1 In dt1.Rows
                    Dim Device_LaborLevel As Integer
                    Dim iDeviceID As Integer
                    Dim iRepairLvel As Integer
                    Dim iLaborcharge As Double
                    If Not IsDBNull(R1("RepairLevel")) Then
                        iRepairLvel = R1("RepairLevel")
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        iLaborcharge = Trim(R1("TotalCost"))
                    End If
                    If Trim(R1("Device Shipped")) = Trim(R1("Original IMEI")) Then
                        iDeviceID = R1("Device_id")
                    Else
                        iDeviceID = getdeviceID(R1("Device Shipped"))
                        If iDeviceID = 0 Then
                            iDeviceID = R1("Device_id")
                        End If
                        Dim dtLabor As DataTable = Me.getDeviceRepairedLevel(iDeviceID)
                        If dtLabor.Rows.Count > 0 Then
                            If Not IsDBNull(dtLabor.Rows(0)("Device_LaborLevel")) And Not IsDBNull(dtLabor.Rows(0)("device_laborcharge")) Then
                                iRepairLvel = dtLabor.Rows(0)("Device_LaborLevel")
                                iLaborcharge = dtLabor.Rows(0)("device_laborcharge")
                            Else
                                If Not IsDBNull(R1("TotalCost")) Then
                                    iRepairLvel = Trim(R1("RepairLevel"))
                                    iLaborcharge = Trim(R1("TotalCost"))
                                End If
                            End If
                        End If
                    End If


                    '(dt.Rows(0)("Device_LaborLevel"))
                    Dim dtBillPart As DataTable
                    dtBillPart = gettdeviceBill(iDeviceID)
                    If dtBillPart.Rows.Count = 0 Then
                        dBilling = 0.0
                    Else
                        dBilling = dtBillPart.Compute("SUM(Total)", String.Empty)
                    End If
                    If Not IsDBNull(R1("PO #")) Then
                        arrData(i, 0) = Trim(R1("PO #"))
                    End If
                    If Not IsDBNull(R1("Original IMEI")) Then
                        arrData(i, 1) = Trim(R1("Original IMEI"))
                    End If
                    If Not IsDBNull(R1("SKU")) Then
                        arrData(i, 2) = Trim(R1("SKU"))
                    End If
                    If Not IsDBNull(R1("Ship Date")) Then
                        arrData(i, 3) = Trim(R1("Received Date"))
                    End If
                    If Not IsDBNull(R1("Device Shipped")) Then
                        arrData(i, 4) = Trim(R1("Device Shipped"))
                    End If
                    If Not IsDBNull(R1("Box Name")) Then
                        arrData(i, 5) = Trim(R1("Box Name"))
                    End If
                    If Not IsDBNull(R1("Ship Date")) Then
                        arrData(i, 6) = Trim(R1("Ship Date"))
                    End If
                    If Not IsDBNull(R1("condition")) Then
                        arrData(i, 7) = Trim(R1("condition"))
                    End If
                    If Not IsDBNull(R1("Tracking #")) Then
                        arrData(i, 8) = Trim(R1("Tracking #"))
                    End If
                    Dim dtFailureCode As New DataTable()
                    dtFailureCode = getDeviceFailCode(R1("OriginalDeviceID"))
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


                    Dim iCountPart As Integer = 0
                    For iPartCount = 17 To 26 Step 2
                        If iCountPart < dtBillPart.Rows.Count Then
                            Dim strPartNumber As String = dtBillPart.Rows(iCountPart).Item("Part_Number")
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
                    If Not IsDBNull(iRepairLvel) Then
                        arrData(i, 27) = iRepairLvel
                    End If
                    If Not IsDBNull(iLaborcharge) Then
                        arrData(i, 28) = iLaborcharge
                    End If
                    If Not IsDBNull(dBilling) Then
                        arrData(i, 29) = Trim(dBilling)
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        dSUM = Convert.ToDecimal(iLaborcharge) + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM
                        arrData(i, 30) = "$" & FormatNumber(iLaborcharge, 2, TriState.False, TriState.True, TriState.True)
                    End If
                    'If Not IsDBNull(R1("Original")) Then
                    '    arrData(i, 29) = Trim(R1("Original"))
                    'End If
                    i += 1
                Next R1

                objSheet.Range("A4", "AE" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("A4", "AE" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "AE" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:AE" & (dt1.Rows.Count + 3)).Select()
                'objSheet.Range("AB4", "AB" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AC4", "AC4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AD4", "AD4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AE4", "AE4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("B4", "B" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("E4", "E" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("H4", "H" & (dt1.Rows.Count + 3)).NumberFormat = "@"
                'objSheet.Range("T4", "AX" & (dt1.Rows.Count + 3)).NumberFormat = 0
                Dim iXrange As Integer = (dt1.Rows.Count + 3)
                Dim result As String
                result = dt1.Compute("SUM(TotalCost)", "")
                objExcel.Application.Cells(dt1.Rows.Count + 4, 30).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 31).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
                setFont(objExcel)
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
                objExcel.Application.Cells(1, 1).Value = String.Concat(strReportName, strLocation.ToUpper, " INVOICE REPORT")
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



        Public Function Get_Weekly_Report(ByVal iCust_id As Integer, ByVal strFromDt As String, _
                                                ByVal strToDt As String, _
                                                ByRef strRptPath As String, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim strSQL As String = String.Empty
            Dim strSql3 As String = String.Empty
            Dim strSql2 As String = String.Empty
            Dim dtrow As DataRow
            Dim dtRepair As New DataTable()
            Dim dtSummary As New DataTable()
            Dim dtAlldata As New DataTable()
            Dim dtTempdata As New DataTable()
            Dim strLocationDOA, strLocCTDI As String
            Dim strAccountDOA, strAccountIW As String
            If iCust_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                strLocationDOA = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                strAccountDOA = "'" & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_FexEx_PosCode & "'," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Cricket_OEMCustomer_DOA_AccountCode & ""
                strAccountIW = "'" & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_FexEx_WexCode & "'," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Cricket_OEMCustomer_EMS_AccountCode & ""
                strLocCTDI = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID
            End If
            Dim dtTMO As New DataTable()
            Dim iweekofYear As Integer = Get_WeekofThe_Year(strToDt)
            Dim strPath As String = "P:\OUTBOUND\WEX ORDERS\Weekly_Reports\"
            'Dim Locid As Integer = getLocationId(strLocation, iCust_id)

            Dim strFile As String = strPath & "Emblem-Q89323 WK" & iweekofYear & "_" & Date.Now.ToString("MMddyyyyhhmmss") & ".xlsx"
            If File.Exists(strFile) Then
                File.Delete(strFile)
            End If
            ' Emblem-Q89323 DOA report 
            strSQL = "SELECT IF(K.Device_DateRec IS NULL,'', IF(DATE_FORMAT(K.Device_DateRec,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(K.Device_DateRec ,'%m/%d/%Y')))  AS 'DateReceived','' AS 'Inovice Date','' as 'DOA# / RMA# / code#'" & Environment.NewLine
            strSQL &= ",A.Item_SKU AS  Description, loc_Name AS 'Group' ,K.Device_sn as 'IMEI' ,A.Return_Reason as  'Emblem Account',F.pretest_wkDt AS 'Pretest Date',CONCAT_WS(' - ',D.Dcode_Sdesc,D.Dcode_Ldesc) AS 'Fail/Pass Reason'" & Environment.NewLine
            strSQL &= ",'' AS 'Premier Account', IF( G.pkslip_createDt  IS NULL,'', IF(DATE_FORMAT(G.pkslip_createDt,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(G.pkslip_createDt ,'%m/%d/%Y')))  AS 'DateShipped'" & Environment.NewLine
            strSQL &= " FROM production.extendedwarranty A" & Environment.NewLine
            strSQL &= " INNER JOIN production.tLocation B ON A.Loc_ID=B.Loc_ID" & Environment.NewLine
            strSQL &= "INNER JOIN tdevice C ON C.device_id=(if (A.swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
            strSQL &= "INNER JOIN production.tdevice K ON K.device_id= A.device_id  " & Environment.NewLine
            strSQL &= " LEFT JOIN production.tpretest_data F ON K.Device_ID=F.device_id" & Environment.NewLine
            strSQL &= " LEFT JOIN lcodesdetail D on F.PTtf = D.Dcode_id  " & Environment.NewLine
            strSQL &= "LEFT JOIN production.tpallett E ON E.pallett_id= K.pallett_id " & Environment.NewLine
            strSQL &= "LEFT JOIN production.tpackingslip G ON G.pkslip_id=E.pkslip_id " & Environment.NewLine
            strSQL &= " WHERE  A.Cust_ID=" & iCust_id & " AND  A.loc_id in (" & strLocationDOA & ")  AND A.sourcefile not like '%Seed%' AND   K.Device_DateRec BETWEEN '2021-01-01 00:00:00' AND '" & strToDt & "'  and A.account IN (" & strAccountDOA & ")  Group BY K.device_id order by   K.Device_DateRec" & Environment.NewLine
            'Summary
            strSql2 = "SELECT  " & iweekofYear & " as 'Week',0 as 'Received_DOA', 0 as 'Received_IW', 0 as 'Received_OOW',  0 as 'Produced_DOA', 0 as 'Produced_IW', 0 as 'Produced_OOW',0 as 'onHnad_DOA', 0 as 'onHnad_IW', 0 as 'onHnad_OOW' " & Environment.NewLine

            'Emblem-Q89323 IW report
            strSql3 &= "SELECT IF( K.Device_DateRec  IS NULL,'', IF(DATE_FORMAT(K.Device_DateRec,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(K.Device_DateRec ,'%m/%d/%Y')))  AS 'DateReceived'" & Environment.NewLine
            strSql3 &= ",A.Model AS Description,Loc_name as 'Group' ,SerialNO as 'Original IMEI',A.Return_Reason AS 'Emblem Account',C.pretest_wkDt AS 'Pretest Date',CONCAT_WS(' - ',D.Dcode_Sdesc,D.Dcode_Ldesc) AS 'Fail/Pass Reason','' AS 'Premier Account'," & Environment.NewLine
            strSql3 &= "IF (E.pkslip_id IS NULL,'',if(A.Swapped_Device_ID >0,'Swapp',IF (pallet_ShipType=2,'RUR',if(pallet_ShipType=1,'BER',IF(pallet_ShipType=0 AND B.Device_LaborLevel>0,'Repaired',if(pallet_ShipType =0 AND B.Device_LaborLevel IN (0,15) AND A.Swapped_Device_ID =0,'NTF','')))))) AS 'Swapped'," & Environment.NewLine
            strSql3 &= "( B.Device_SN) AS 'New IMEI', IF( F.pkslip_createDt  IS NULL,'', IF(DATE_FORMAT(F.pkslip_createDt,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(F.pkslip_createDt ,'%m/%d/%Y')))  AS 'DateShipped',F.pkslip_TrackNo  AS 'Tracking #',CAST(TO_DAYS(F.pkslip_createDt) - TO_DAYS(K.Device_DateRec) AS UNSIGNED)   AS  'AgedWIP',pallet_ShipType as PallettShipType,IF(B.Device_Laborlevel=15,0,B.Device_Laborlevel) AS RepairLevel" & Environment.NewLine
            strSql3 &= "FROM production.extendedwarranty A" & Environment.NewLine
            strSql3 &= "INNER JOIN tdevice B ON B.device_id=(if (A.swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
            strSql3 &= "INNER JOIN production.tdevice K ON K.device_id= A.device_id  " & Environment.NewLine
            strSql3 &= "LEFT JOIN production.tpretest_data C ON  C.device_id =K.Device_ID" & Environment.NewLine
            strSql3 &= "LEFT JOIN lcodesdetail D on C.PTtf = D.Dcode_id  " & Environment.NewLine
            strSql3 &= " INNER JOIN production.tLocation G ON A.Loc_ID=G.Loc_ID" & Environment.NewLine
            strSql3 &= "LEFT JOIN production.tpallett E ON E.pallett_id= B.pallett_id " & Environment.NewLine
            strSql3 &= "LEFT JOIN production.tpackingslip F ON F.pkslip_id=E.pkslip_id " & Environment.NewLine
            strSql3 &= "WHERE  A.cust_ID=" & iCust_id & " AND  ((A.loc_id in (" & strLocationDOA & ") AND A.ACCOUNT IN (" & strAccountIW & "))OR A.Loc_id=" & strLocCTDI & ") AND SOURCEFILE NOT LIKE '%seed%'  AND E.Pallet_ShipType<>13  AND    B.Device_DateRec BETWEEN '2021-01-01 00:00:00' AND '" & strToDt & "'   Group BY B.device_id" & Environment.NewLine

            dtSummary = _objDataProc.GetDataTable(strSql2)
            dtRepair = _objDataProc.GetDataTable(strSQL)
            dtTMO = _objDataProc.GetDataTable(strSql3)
            dtTempdata = GetWingTechData(strToDt)
            dtAlldata = dtTempdata.Clone
            dtAlldata.Columns(0).DataType = GetType(DateTime)
            dtAlldata.Columns(1).DataType = GetType(DateTime)
            For Each dtrow In dtTempdata.Rows
                dtAlldata.ImportRow(dtrow)
            Next

            For Each dtrow In dtSummary.Rows
                dtrow("Produced_IW") = dtAlldata.Select("warranty='IW' AND Status='Produced' AND DateShipped IS NOT NULL AND dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  dateshipped <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                dtrow("Received_IW") = dtAlldata.Select("warranty='IW' AND Status='Received' AND DateReceived >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  DateReceived <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                dtrow("onHnad_IW") = dtAlldata.Select("warranty='IW' AND Status='Received' ").Length
                dtrow("Produced_DOA") = dtAlldata.Select("warranty='DOA' AND Status='Produced' AND DateShipped IS NOT NULL AND dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  dateshipped <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                dtrow("Received_DOA") = dtAlldata.Select("warranty='DOA' AND Status='Received' AND DateReceived >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  DateReceived <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                dtrow("onHnad_DOA") = dtAlldata.Select("warranty='DOA' AND Status='Received' ").Length

                'dtrow("Produced_DOA") = dtAlldata.Select("DateShipped IS NOT NULL AND dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  dateshipped <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                'dtrow("Received_DOA") = dtAlldata.Select("warranty='DOA' AND   DateReceived >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  DateReceived <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                'dtrow("onHnad_DOA") = dtAlldata.Select("warranty='DOA'").Length

            Next
            dtTMO.Columns.Remove("RepairLevel")
            dtTMO.Columns.Remove("PallettShipType")
            CreateExcelFile_Repair(dtRepair, dtTMO, strFile, dtSummary, iweekofYear)
            Return 1
        End Function
        Private Function Get_WeekofThe_Year(ByVal dtweek As Date) As Integer
            Dim a As DateTimeFormatInfo
            a = New DateTimeFormatInfo()
            Dim dt As New DateTime()
            dt = dtweek
            Dim cal As Calendar = a.Calendar
            Return (cal.GetWeekOfYear(dt, a.CalendarWeekRule, a.FirstDayOfWeek))
        End Function
        Private Sub SetColumn_Header_Summary(ByVal dt As DataTable, ByRef excelSheet As Excel.Worksheet, ByVal iweekofYear As Integer)
            Dim j As Integer = 1
            Dim l As Integer = 0
            Dim i As Integer = 1
            Dim strColumns() As String = {"DOA", "IW", "OOW"}
            Dim dtRow As DataRow
            excelSheet.Range("A1:J" & dt.Rows.Count * 3).RowHeight = 30
            'Header for Details report
            With excelSheet
                .Columns("A:A").ColumnWidth = 18 'PO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 8.43   'SKU
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 12.43 'MODEL
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 8.43  'Original IMEI
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 8.43  'New IMEI
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 8.43  'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 11.43    'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 8.43   'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("I:I").ColumnWidth = 8.43    'Days
                .Columns("I:I").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("I:I").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("J:J").ColumnWidth = 8.43  'Code Failure1
                .Columns("J:J").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("J:J").VerticalAlignment = Excel.Constants.xlCenter
            End With
            'weekly range
            Dim strRange = "A" & i + 1 & ":J" & i + 1
            With excelSheet.Range(strRange)
                .MergeCells = True
                .Value = "Week " & iweekofYear & "- Summary "
                .Font.Size = 14
                .Font.Bold = True
                .Font.Name = "Times New Roman"
                .RowHeight = 37.5
            End With

            Dim strRange_ProductReceived = "B" & i + 2 & ":D" & i + 2
            Dim strRange_ProductShipped = "E" & i + 2 & ":G" & i + 2
            Dim strRange_ProductonHand = "H" & i + 2 & ":J" & i + 2
            Dim strRange_Description = "A" & i + 2 & ":A" & i + 3
            setRange(excelSheet, strRange_ProductReceived, "Product received " & vbLf & "(Pcs)", False)
            setRange(excelSheet, strRange_ProductShipped, "Product Shipped " & vbLf & "(Pcs)", False)
            setRange(excelSheet, strRange_ProductonHand, "On hand WIP" & vbLf & " (Pcs)", False)
            setRange(excelSheet, strRange_Description, "Description", True)
            'header for EWP,DOA,IW HEIGHT
            With excelSheet.Range("A" & i + 3 & ":J" & i + 3)
                .RowHeight = 24.75
                .Interior.Color = RGB(180, 198, 231)
                setBorders(excelSheet.Range("A" & i + 3 & ":J" & i + 3))
            End With
            'data for summary 
            Dim k As Integer = 0
            For l = 2 To 10
                If l = 5 OrElse l = 8 Then
                    k = 0
                End If
                excelSheet.Cells(i + 3, l) = strColumns(k)
                k = k + 1
            Next
            For l = 1 To 13
                Select Case l
                    Case 1
                        excelSheet.Cells(i + 4, l) = "Q89323"
                    Case 2
                        excelSheet.Cells(i + 4, l) = dt.Rows(0).Item("Received_DOA")
                    Case 3
                        excelSheet.Cells(i + 4, l) = dt.Rows(0).Item("Received_IW")
                    Case 4
                        excelSheet.Cells(i + 4, l) = 0
                    Case 5
                        excelSheet.Cells(i + 4, l) = dt.Rows(0).Item("Produced_DOA")
                    Case 6
                        excelSheet.Cells(i + 4, l) = dt.Rows(0).Item("Produced_IW")
                    Case 7
                        excelSheet.Cells(i + 4, l) = 0
                    Case 8
                        excelSheet.Cells(i + 4, l) = dt.Rows(0).Item("onHnad_DOA")
                    Case 9
                        excelSheet.Cells(i + 4, l) = dt.Rows(0).Item("onHnad_IW")
                    Case 10
                        excelSheet.Cells(i + 4, l) = 0

                End Select

            Next
            excelSheet.Range("A" & i + 4 & ":J" & i + 4).RowHeight = 25

        End Sub
        Private Sub setRange(ByRef excelSheet As Excel.Worksheet, ByVal strRange As String, ByVal strTitle As String, ByVal isRow As Boolean)
            With excelSheet.Range(strRange)
                .MergeCells = True
                .WrapText = True
                .Value = strTitle
                .Font.Size = 12
                .Font.Bold = True
                .Font.Name = "Times New Roman"
                If Not isRow Then
                    .RowHeight = 34.5
                End If
                .Interior.Color = RGB(180, 198, 231)

            End With
            setBorders(excelSheet.Range(strRange))
        End Sub
        Private Sub setBorders(ByRef strrange As Excel.Range)
            With strrange
                .Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells.Borders.Color = RGB(0, 0, 0)
                .Cells.Borders.Weight = 2D
            End With
        End Sub
        '1
        Private Sub SetColumn_Header_TMO(ByRef excelSheet As Excel.Worksheet)
            Dim j As Integer = 1
            Dim l As Integer = 0
            Dim i As Integer = 2

            With excelSheet
                .Cells(i, 1).Value = "No"
                .Cells(i, 2).Value = "Date Received"
                .Cells(i, 3).Value = "Description"
                .Cells(i, 4).Value = "Group"
                .Cells(i, 5).Value = "Original IMEI"
                .Cells(i, 6).Value = "Emblem Account"
                .Cells(i, 7).Value = "Pretest Date"
                .Cells(i, 8).Value = "Fail/Pass Reason"
                .Cells(i, 9).Value = "Premier Account"
                .Cells(i, 10).Value = "Swaped / Repaired / BER / RUR / NTF"
                .Cells(i, 11).Value = "New IMEI"
                .Cells(i, 12).Value = "Date Shipped"
                .Cells(i, 13).Value = "Tracking #"
                .Cells(i, 14).Value = "Days"
            End With
            With excelSheet
                .Columns("A:A").ColumnWidth = 7.29 'PO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 10.86
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 11.14
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 17.43
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 18
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 18.43 'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 11.86    'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 32.57   'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("I:I").ColumnWidth = 8.86    'Days
                .Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("I:I").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("J:J").ColumnWidth = 15.29 'Code Failure1
                .Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("J:J").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("K:K").ColumnWidth = 17.29  'Failure Reason1
                .Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("K:K").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("L:L").ColumnWidth = 10.71 'Code Failure2
                .Columns("L:L").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("L:L").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("M:M").ColumnWidth = 39.57 'Code Failure2
                .Columns("M:M").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("M:M").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("N:N").ColumnWidth = 6.86  'Code Failure2
                .Columns("N:N").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("N:N").VerticalAlignment = Excel.Constants.xlCenter
            End With
        End Sub


        Private Sub SetColumn_Header_Repair(ByRef excelSheet As Excel.Worksheet)
            Dim i As Integer = 2
            With excelSheet
                .Cells(i, 1).Value = "No"
                .Cells(i, 2).Value = "Date Received"
                .Cells(i, 3).Value = "Inovice Date"
                .Cells(i, 4).Value = "DOA# / RMA# / code#"
                .Cells(i, 5).Value = "Description"
                .Cells(i, 6).Value = "Group"
                .Cells(i, 7).Value = "IMEI"
                .Cells(i, 8).Value = "Emblem Account"
                .Cells(i, 9).Value = "Pretest Date"
                .Cells(i, 10).Value = "Fail/Pass Reason"
                .Cells(i, 11).Value = "Premier Account"


            End With
            With excelSheet
                .Columns("A:A").ColumnWidth = 8.71 'NO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 12.43
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 10.86
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 15.86
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 13.43
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 18.71  'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 17.21   'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 16.43  'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("I:I").ColumnWidth = 12.43  'Days
                .Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("I:I").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("J:J").ColumnWidth = 41.29  'Days
                .Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("J:J").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("K:K").ColumnWidth = 15.43   'Days
                .Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft
                .Columns("K:K").VerticalAlignment = Excel.Constants.xlCenter

            End With
        End Sub


        Private Sub SetColumn_Header_Refurbish(ByRef excelSheet As Excel.Worksheet)
            Dim i As Integer = 2
            With excelSheet
                .Cells(i, 1).Value = "Refurbish time"
                .Cells(i, 2).Value = "Model"
                .Cells(i, 3).Value = "IMEI"
                .Cells(i, 4).Value = "Emblem Account"
                .Cells(i, 5).Value = "Premier Pertest Result"
                .Cells(i, 6).Value = "Physical Damage"
                .Cells(i, 7).Value = "Fail/Pass Reason"
                .Cells(i, 8).Value = "Storege/Shipped Time"

            End With
            With excelSheet
                .Columns("A:A").ColumnWidth = 14.71 'NO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 6.43
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 6.86
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 16.86
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 22.43
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 18.71  'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 17.21   'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 21.43  'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

            End With
        End Sub


        Private Sub CreateExcelFile_Repair(ByVal dtRepair As DataTable, ByVal dtTMO As DataTable, ByVal strRptPath As String, ByVal dtSummary As DataTable, ByVal iweekofYear As Integer)
            Dim i, j As Integer
            Dim xlApp As Excel.Application
            Dim dtcolumn As DataColumn
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet1 As Excel.Worksheet
            Dim xlWorkSheet2 As Excel.Worksheet
            Dim xlWorkSheet3 As Excel.Worksheet
            Dim xlWorkSheet4 As Excel.Worksheet
            Dim arrDataRepair(0, 0) As String
            Dim arrDataTMO(0, 0) As String
            Dim R1 As DataRow
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet1 = xlWorkBook.Sheets("sheet1")
            xlWorkSheet1.Name = "Summary"
            xlWorkSheet2 = xlWorkBook.Sheets("sheet3")
            xlWorkSheet2.Name = "Emblem-Q89323 IW report"
            xlWorkSheet3 = xlWorkBook.Sheets("sheet2")
            xlWorkSheet3.Name = "Emblem-Q89323 DOA report"
            xlWorkSheet4 = xlWorkBook.Worksheets.Add(After:=xlWorkBook.Worksheets("Emblem-Q89323 IW report"))
            xlWorkSheet4.Name = "Refurbish report"

            SetColumn_Header_Summary(dtSummary, xlWorkSheet1, iweekofYear)
            SetColumn_Header_TMO(xlWorkSheet2)
            SetColumn_Header_Repair(xlWorkSheet3)
            SetColumn_Header_Refurbish(xlWorkSheet4)
            'Format cells Data Type
            '*****************************************
            'Repair Report Tab
            xlWorkSheet3.Range("A1", "K" & (dtRepair.Rows.Count + 5)).NumberFormat = "@"
            For i = 0 To dtRepair.Rows.Count - 1
                i = 0
                ReDim arrDataRepair(dtRepair.Rows.Count, 11)
                For Each R1 In dtRepair.Rows
                    arrDataRepair(i, 0) = i + 1
                    If Not IsDBNull(R1("DateReceived")) Then
                        arrDataRepair(i, 1) = Trim(R1("DateReceived"))
                    End If
                    If Not IsDBNull(R1("Inovice Date")) Then
                        arrDataRepair(i, 2) = Trim(R1("Inovice Date"))
                    End If
                    If Not IsDBNull(R1("DOA# / RMA# / code#")) Then
                        arrDataRepair(i, 3) = Trim(R1("DOA# / RMA# / code#"))
                    End If
                    If Not IsDBNull(R1("Description")) Then
                        arrDataRepair(i, 4) = Trim(R1("Description"))
                    End If
                    If Not IsDBNull(R1("Group")) Then
                        arrDataRepair(i, 5) = Trim(R1("Group"))
                    End If
                    If Not IsDBNull(R1("IMEI")) Then
                        arrDataRepair(i, 6) = Trim(R1("IMEI"))
                    End If
                    If Not IsDBNull(R1("Emblem Account")) Then
                        arrDataRepair(i, 7) = Trim(R1("Emblem Account"))
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrDataRepair(i, 8) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Fail/Pass Reason")) Then
                        arrDataRepair(i, 9) = Trim(R1("Fail/Pass Reason"))
                    End If
                    If Not IsDBNull(R1("Premier Account")) Then
                        arrDataRepair(i, 10) = Trim(R1("Premier Account"))
                    End If
                    i += 1
                Next R1

            Next
            xlWorkSheet3.Range("A3", "K" & (dtRepair.Rows.Count + 2)).Value = arrDataRepair
            xlWorkSheet3.Range("A1", "K" & (dtRepair.Rows.Count + 5)).Value = xlWorkSheet3.Range("A1", "K" & (dtRepair.Rows.Count + 5)).Value

            'TMO Report Tab
            xlWorkSheet2.Range("A1", "N" & (dtTMO.Rows.Count + 5)).NumberFormat = "@"
            For i = 0 To dtTMO.Rows.Count - 1
                i = 0
                ReDim arrDataTMO(dtTMO.Rows.Count, 14)
                For Each R1 In dtTMO.Rows
                    arrDataTMO(i, 0) = i + 1
                    If Not IsDBNull(R1("DateReceived")) Then
                        arrDataTMO(i, 1) = Trim(R1("DateReceived"))
                    End If
                    If Not IsDBNull(R1("Description")) Then
                        arrDataTMO(i, 2) = Trim(R1("Description"))
                    End If
                    If Not IsDBNull(R1("Group")) Then
                        arrDataTMO(i, 3) = Trim(R1("Group"))
                    End If
                    If Not IsDBNull(R1("Original IMEI")) Then
                        arrDataTMO(i, 4) = Trim(R1("Original IMEI"))
                    End If
                    If Not IsDBNull(R1("Emblem Account")) Then
                        arrDataTMO(i, 5) = Trim(R1("Emblem Account"))
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrDataTMO(i, 6) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Fail/Pass Reason")) Then
                        arrDataTMO(i, 7) = Trim(R1("Fail/Pass Reason"))
                    End If
                    If Not IsDBNull(R1("Premier Account")) Then
                        arrDataTMO(i, 8) = Trim(R1("Premier Account"))
                    End If
                    If Not IsDBNull(R1("Swapped")) Then
                        arrDataTMO(i, 9) = Trim(R1("Swapped"))
                    End If
                    If Not IsDBNull(R1("New IMEI")) Then
                        arrDataTMO(i, 10) = Trim(R1("New IMEI"))
                    End If
                    If Not IsDBNull(R1("DateShipped")) Then
                        arrDataTMO(i, 11) = Trim(R1("DateShipped"))
                    End If
                    If Not IsDBNull(R1("Tracking #")) Then
                        arrDataTMO(i, 12) = Trim(R1("Tracking #"))
                    End If
                    If Not IsDBNull(R1("AgedWIP")) Then
                        If Trim(R1("AgedWIP")) = "0" Then
                            arrDataTMO(i, 13) = ""
                        Else
                            arrDataTMO(i, 13) = Trim(R1("AgedWIP"))
                        End If

                    End If
                    i += 1
                Next R1
            Next
            xlWorkSheet2.Range("A3", "N" & (dtTMO.Rows.Count + 2)).Value = arrDataTMO

            xlWorkSheet2.Range("A1", "N" & (dtTMO.Rows.Count + 5)).Value = xlWorkSheet2.Range("A1", "N" & (dtTMO.Rows.Count + 5)).Value
            xlWorkSheet2.Range("A3", "N" & (dtTMO.Rows.Count + 5)).Font.Size = 11
            xlWorkSheet2.Range("A3", "N" & (dtTMO.Rows.Count + 5)).Font.Name = "Calibri"
            'set title for Repair and TMO
            SetFont_Title(xlWorkSheet2, "After-sales Service Tracking Form", "A1:N1", "A2:N2")
            SetFont_Title(xlWorkSheet3, "After-sales Service Tracking Form", "A1:K1", "A2:K2")
            SetFont_Title(xlWorkSheet4, "Refurbish  report", "A1:H1", "A2:H2")
            xlWorkSheet2.SaveAs(strRptPath)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet3)
            MsgBox("You can find the file " & strRptPath)
        End Sub

        Private Sub SetFont_Title(ByRef excelSheet As Excel.Worksheet, ByVal title As String, ByVal range As String, ByVal columnFontRange As String)
            With excelSheet.Range(range)
                .MergeCells = True
                .HorizontalAlignment = -4108
                .Value = title
                .Font.Bold = True
                .Font.Size = 14
                .Interior.Color = RGB(255, 217, 102)
                .Font.Name = "Times New Roman"
                .RowHeight = 34
                setBorders(excelSheet.Range(range))
            End With
            With excelSheet.Range(columnFontRange)
                .Font.Size = 11
                .Font.Name = "Times New Roman"
                .WrapText = True
                .RowHeight = 49
                .Interior.Color = RGB(180, 198, 231)
                .HorizontalAlignment = -4108
                .Font.Bold = True
                setBorders(excelSheet.Range(columnFontRange))
            End With
        End Sub
        Private Sub setFont(ByRef objExcel As Excel.Application)
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

        Private Function GetWingTechData(ByVal dtEnd As String) As DataTable
            Dim dt As New DataTable()
            Dim strSQL As String = String.Empty
            Dim strloc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & _
            PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID & "," & _
            PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID



            strSQL &= "SELECT E.Device_DateShip as DateShipped ,F.Device_DateRec as DateReceived,   IF(A.Loc_id=4494 OR A.ACCOUNT IN ('WEX',569955),'IW',IF(A.account IN ('POS',569969),'DOA','')) AS warranty," & Environment.NewLine
            strSQL &= "IF( E.Device_DateShip  IS NOT NULL AND  P.Pallet_ShipType!=13 ,'Produced', IF(F.Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status" & Environment.NewLine
            strSQL &= " FROM production.extendedwarranty A" & Environment.NewLine
            strSQL &= "INNER  JOIN production.tdevice E ON E.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
            strSQL &= " INNER  JOIN production.tdevice F ON F.device_id= A.device_id    " & Environment.NewLine
            strSQL &= "LEFT JOIN tpallett P ON P.Pallett_ID=E.Pallett_ID " & Environment.NewLine
            strSQL &= "WHERE   A.Cust_ID=" & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID & " AND  A.loc_id in (" & strloc_id & ")   AND SOURCEFILE NOT LIKE '%Seed%'   " & Environment.NewLine
            strSQL &= "AND (if ( P.Pallett_ID IS NOT  NULL ,  P.Pallet_ShipType!=13  ,E.device_dateship IS NULL AND P.Pallett_ID IS null ))Group BY F.device_id order by F.Device_DateRec" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSQL)
            Return dt
        End Function


#End Region
    End Class
End Namespace
