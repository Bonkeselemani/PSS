Option Explicit On 

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Text

Namespace Buisness
    Public Class WIPStatusReport
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

        Public Shared Function LoadWIPSummary(ByVal booDetails As Boolean, ByVal Cust_ID As Integer, ByVal Loc_ID As Integer)
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
                If Cust_ID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    dt1 = GetWIP(booDetails, Cust_ID, Loc_ID)
                Else
                    dt1 = GetWIPForOther(booDetails, Cust_ID, Loc_ID)
                End If
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
                If Cust_ID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    dt2 = GetWIPSummary(dt1, Cust_ID, Loc_ID) 'Move it to top so that we can update classification
                Else
                    dt2 = GetWIPSummaryForOthers(dt1, Cust_ID, Loc_ID) 'Move it to top so that we can update classification
                End If
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
                Throw New Exception("LoadWIPSummary(): " & Environment.NewLine & ex.Message.ToString)
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
        Private Shared Function GetWIP(ByVal booDetails As Boolean, ByVal Cust_ID As Integer, ByVal Loc_ID As Integer) As DataTable
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
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id and a.loc_id = " & Loc_ID & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tcostcenter c ON a.cc_id = c.cc_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder e on e.wo_id = a.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN edi.titem F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN edi.twarehousebox G ON F.wb_id = G.wb_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill db on a.device_id = db.device_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & Loc_ID & " AND a.Device_DateShip is null " & Environment.NewLine
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
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id and a.loc_id = " & Loc_ID & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tcostcenter c ON a.cc_id = c.cc_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder e on e.wo_id = a.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN edi.titem F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett H ON a.Pallett_ID  = H.Pallett_ID" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN edi.twarehousebox G ON F.wb_id = G.wb_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill db on a.device_id = db.device_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & Loc_ID & " AND a.Device_DateShip is not null AND H.Pkslip_ID is null " & Environment.NewLine
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
                    strSql &= "WHERE a.loc_id = " & Loc_ID & Environment.NewLine
                    strSql &= "AND a.Device_DateShip is null " & Environment.NewLine
                    dt1 = objDataProc.GetDataTable(strSql)

                    strSql = "SELECT Device_SN as 'Serial Number', model_desc as 'Model Desc.', '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= "FROM tpallett INNER JOIN tdevice a ON tpallett.Pallett_ID = a.Pallett_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "WHERE tpallett.loc_id = " & Loc_ID & Environment.NewLine
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

        Private Shared Function GetWIPForOther(ByVal booDetails As Boolean, ByVal Cust_ID As Integer, ByVal Loc_ID As Integer) As DataTable
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
                    'strSql &= ", if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '') as 'Warranty coverage by'" & Environment.NewLine
                    strSql &= ",'' as 'Warranty coverage by'" & Environment.NewLine
                    strSql &= ", 0 as 'Days to be expired' " & Environment.NewLine
                    strSql &= ", a.Device_Laborcharge as 'Labor', a.Device_Partcharge as 'Part Charge' " & Environment.NewLine
                    strSql &= ", SUM(dbill_avgcost) as 'Part Cost' " & Environment.NewLine
                    strSql &= ", '' as 'Ship Box'" & Environment.NewLine
                    strSql &= ", if(Device_DateShip is null, '', Device_DateShip) as 'Prod Completed Date' " & Environment.NewLine
                    strSql &= ", IF(G.WHLocation IS NULL, '', G.WHLocation) AS WHLocation  " & Environment.NewLine
                    strSql &= ", F. wb_ID 'Rec Box'" & Environment.NewLine
                    strSql &= ", 0 as 'BERTab' " & Environment.NewLine
                    strSql &= ", date_format(now(), '%Y-%m-%d') as 'Today'" & Environment.NewLine
                    strSql &= "FROM tdevice a " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id and a.loc_id = " & Loc_ID & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tcostcenter c ON a.cc_id = c.cc_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder e on e.wo_id = a.wo_id" & Environment.NewLine
                    'strSql &= "INNER JOIN edi.titem F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN extendedwarranty F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN edi.twarehousebox G ON F.wb_id = G.wb_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill db on a.device_id = db.device_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & Loc_ID & " AND a.Device_DateShip is null " & Environment.NewLine
                    strSql &= "GROUP BY " & Environment.NewLine
                    strSql &= "a.Model_ID, Device_SN,model_desc,wo_custwo,Device_DateRec,WorkStationEntryDt,WorkStation," & Environment.NewLine
                    strSql &= "if (cc_desc is null,'',if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, ''))," & Environment.NewLine
                    strSql &= "if(Device_ManufWrty = 1, 'Yes', 'No')," & Environment.NewLine
                    'strSql &= "if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '')," & Environment.NewLine
                    strSql &= "a.Device_Laborcharge,a.Device_Partcharge," & Environment.NewLine
                    strSql &= "if(Device_DateShip is null, '', Device_DateShip)," & Environment.NewLine
                    strSql &= "IF(G.WHLocation IS NULL, '', G.WHLocation)," & Environment.NewLine
                    strSql &= "F.WB_ID" & Environment.NewLine
                    dt1 = objDataProc.GetDataTable(strSql)

                    strSql = "SELECT a.Model_ID, Device_SN as 'Serial Number', model_desc as 'Model Desc.', '=VLOOKUP(B2,Summary!A:B,2,0)' as 'Pss Classification', '=VLOOKUP(B2,Summary!A:C,3,0)' as 'Customer Classification' " & Environment.NewLine
                    strSql &= ", wo_custwo as 'Order No.' " & Environment.NewLine
                    strSql &= ", Device_DateRec as 'Received Date', WorkStationEntryDt as 'Workstation Entry Date' " & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= ", if (cc_desc is null,'', if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, '')) AS 'Line' " & Environment.NewLine
                    strSql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty?'" & Environment.NewLine
                    ' strSql &= ", if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '') as 'Warranty coverage by'" & Environment.NewLine
                    strSql &= ", 0 as 'Days to be expired' " & Environment.NewLine
                    strSql &= ", a.Device_Laborcharge as 'Labor', a.Device_Partcharge as 'Part Charge' " & Environment.NewLine
                    strSql &= ", SUM(dbill_avgcost) as 'Part Cost' " & Environment.NewLine
                    strSql &= ", IF(Pallett_Name is null, '', Pallett_Name) as 'Ship Box'" & Environment.NewLine
                    strSql &= ", if(Device_DateShip is null, '', Device_DateShip) as 'Prod Completed Date' " & Environment.NewLine
                    strSql &= ", IF(G.WHLocation IS NULL, '', G.WHLocation) AS WHLocation  " & Environment.NewLine
                    strSql &= ", F.WB_ID as 'Rec Box'" & Environment.NewLine
                    strSql &= ", if(Device_DateShip is not null and Pallet_ShipType = 1, 1, 0) as 'BERTab' " & Environment.NewLine
                    strSql &= ", date_format(now(), '%Y-%m-%d') as 'Today'" & Environment.NewLine
                    strSql &= "FROM tdevice a " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id and a.loc_id = " & Loc_ID & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tcostcenter c ON a.cc_id = c.cc_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder e on e.wo_id = a.wo_id" & Environment.NewLine
                    'strSql &= "INNER JOIN edi.titem F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN extendedwarranty F ON a.device_id = F.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett H ON a.Pallett_ID  = H.Pallett_ID" & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN edi.twarehousebox G ON F.wb_id = G.wb_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevicebill db on a.device_id = db.device_id " & Environment.NewLine
                    strSql &= "WHERE a.loc_id = " & Loc_ID & " AND a.Device_DateShip is not null AND H.Pkslip_ID is null " & Environment.NewLine
                    strSql &= "GROUP BY " & Environment.NewLine
                    strSql &= "a.Model_ID, Device_SN,model_desc,wo_custwo,Device_DateRec,WorkStationEntryDt,WorkStation," & Environment.NewLine
                    strSql &= "if (cc_desc is null,'',if(WorkStation = 'REFURBISHED/TECH' or (WorkStation ='FQA'), cc_desc, ''))," & Environment.NewLine
                    strSql &= "if(Device_ManufWrty = 1, 'Yes', 'No')," & Environment.NewLine
                    'strSql &= "if(Device_ManufWrty = 1, if(LastDateInWrty is not null, LastDateInWrty, '')  , '')," & Environment.NewLine
                    strSql &= "a.Device_Laborcharge,a.Device_Partcharge," & Environment.NewLine
                    strSql &= "if(Device_DateShip is null, '', Device_DateShip)," & Environment.NewLine
                    strSql &= "IF(G.WHLocation IS NULL, '', G.WHLocation)," & Environment.NewLine
                    strSql &= "F.wb_ID" & Environment.NewLine
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
                    strSql &= "WHERE a.loc_id = " & Loc_ID & Environment.NewLine
                    strSql &= "AND a.Device_DateShip is null " & Environment.NewLine
                    dt1 = objDataProc.GetDataTable(strSql)

                    strSql = "SELECT Device_SN as 'Serial Number', model_desc as 'Model Desc.', '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                    strSql &= ", WorkStation as 'Workstation' " & Environment.NewLine
                    strSql &= "FROM tpallett INNER JOIN tdevice a ON tpallett.Pallett_ID = a.Pallett_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcellopt b ON a.device_id = b.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel d ON a.model_id  = d.model_id " & Environment.NewLine
                    strSql &= "WHERE tpallett.loc_id = " & Loc_ID & Environment.NewLine
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

        Private Shared Function GetWIPSummary(ByVal dtWipDetails As DataTable, ByVal Cust_ID As Integer, ByVal Loc_ID As Integer) As DataTable
            Dim strSql As String, strPssClassification As String = "", strCustClassification As String = ""
            Dim dtModels, dtWipBucket, dtModelStatus As DataTable
            Dim R1, R2, drZero() As DataRow
            Dim i As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.Model_ID, Model_Desc as Model, '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                strSql &= "From tmodel A INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID and B.Cust_ID = " & Cust_ID & Environment.NewLine
                strSql &= "WHERE A.Prod_ID = 2 AND B.Cust_MaterialCategory = 'PHONE' Order by Model_Desc "
                dtModels = objDataProc.GetDataTable(strSql)
                'dtModels = GetTFModelClassification(objDataProc)

                dtWipBucket = GetWorkFlow(Cust_ID)
                For Each R1 In dtWipBucket.Rows
                    dtModels.Columns.Add(New DataColumn(R1("Bucket"), System.Type.GetType("System.Int32")))
                Next R1
                dtModels.Columns.Add(New DataColumn("Total", System.Type.GetType("System.Int32")))
                dtModels.AcceptChanges()

                strSql = "SELECT A.Model_ID, A.EffectiveDate, IF(B.Status_ID is null, '', D.assign_text) as 'Pss Classification'" & Environment.NewLine
                strSql &= " , IF(C.Dcode_LDesc is null, '', C.Dcode_LDesc) as 'Customer Classification'" & Environment.NewLine
                strSql &= " FROM custmodelclassification A" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN COGS.tmodel_properties B ON A.Model_ID = B.Model_ID And B.cust_ID=" & Cust_ID & Environment.NewLine
                strSql &= " LEFT OUTER JOIN cogs.ldevicestatus D ON B.Status_ID = D.lassign_id" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN lcodesdetail C ON A.Cust_Dcode_ID = C.Dcode_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & Cust_ID & " and A.EffectiveDate <= now();" & Environment.NewLine


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

        Private Shared Function GetWIPSummaryForOthers(ByVal dtWipDetails As DataTable, ByVal Cust_ID As Integer, ByVal Loc_ID As Integer) As DataTable
            Dim strSql As String, strPssClassification As String = "", strCustClassification As String = ""
            Dim dtModels, dtWipBucket, dtModelStatus As DataTable
            Dim R1, R2, drZero() As DataRow
            Dim i As Integer = 0
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.Model_ID, Model_Desc as Model, '' as 'Pss Classification', '' as 'Customer Classification'" & Environment.NewLine
                strSql &= "From tmodel A INNER JOIN tpallett B ON A.Model_ID = B.Model_ID and B.Cust_ID = " & Cust_ID & Environment.NewLine
                strSql &= "WHERE A.Prod_ID = 2 " ' AND B.Cust_MaterialCategory = 'PHONE' Order by Model_Desc "
                dtModels = objDataProc.GetDataTable(strSql)
                'dtModels = GetTFModelClassification(objDataProc)

                dtWipBucket = GetWorkFlow(Cust_ID)
                For Each R1 In dtWipBucket.Rows
                    dtModels.Columns.Add(New DataColumn(R1("Bucket"), System.Type.GetType("System.Int32")))
                Next R1
                dtModels.Columns.Add(New DataColumn("Total", System.Type.GetType("System.Int32")))
                dtModels.AcceptChanges()

                strSql = "SELECT A.Model_ID, A.EffectiveDate, IF(B.Status_ID is null, '', D.assign_text) as 'Pss Classification'" & Environment.NewLine
                strSql &= " , IF(C.Dcode_LDesc is null, '', C.Dcode_LDesc) as 'Customer Classification'" & Environment.NewLine
                strSql &= " FROM custmodelclassification A" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN COGS.tmodel_properties B ON A.Model_ID = B.Model_ID And B.cust_ID=" & Cust_ID & Environment.NewLine
                strSql &= " LEFT OUTER JOIN cogs.ldevicestatus D ON B.Status_ID = D.lassign_id" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN lcodesdetail C ON A.Cust_Dcode_ID = C.Dcode_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & Cust_ID & " and A.EffectiveDate <= now();" & Environment.NewLine


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


        Private Shared Function GetWorkFlow(ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT WorkFlowStation as 'Bucket' FROM wipreportbucket WHERE " & iCustID & " and 2258Active = 1" & Environment.NewLine 'ORDER BY `" & iCustID & "`" & Environment.NewLine
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDataProc) Then objDataProc = Nothing
            End Try
        End Function

        '****************************************************************************************
    End Class
End Namespace