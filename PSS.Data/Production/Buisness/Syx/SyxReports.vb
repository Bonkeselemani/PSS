
Namespace Buisness
    Public Class SyxReports
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

        '*********************************************************************************************************
        Private Sub NAR(ByRef o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '*********************************************************************************************************
        Public Sub CreateTechOutputRpt(ByVal strRptName As String, ByVal strFromDt As String, ByVal strToDt As String)
            Dim strSql As String = ""
            Dim dt, dtService As DataTable
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim objArrData(,) As Object
            Dim R1 As DataRow
            Dim i, j As Integer
            
            Try
                dt = New DataTable()
                strSql = "Select Distinct A.Device_ID, Device_SN as 'SN', A.TD_TestDt as 'Transaction Date'" & Environment.NewLine
                strSql &= ", Prod_Desc as 'Type', D.Model_Desc as 'Model' " & Environment.NewLine
                strSql &= ", ManufModelNumber as 'Manuf Model #', C.user_fullname as 'Technician' " & Environment.NewLine
                strSql &= ", A.FrWorkStation as 'From Status', A.ToWorkStation as 'To Status' " & Environment.NewLine
                strSql &= ", '' as Service "
                strSql &= "from ttestdata A " & Environment.NewLine
                strSql &= "inner join tdevice B on A.device_id = B.device_id " & Environment.NewLine
                strSql &= "INNER JOIN Security.tusers C on A.TD_UsrID = C.user_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel D on B.Model_ID = D.Model_ID " & Environment.NewLine
                strSql &= "inner join tworkorder E on B.WO_ID = E.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN lproduct F ON D.Prod_ID = F.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN syxdata G ON A.Device_ID = G.Device_ID " & Environment.NewLine
                strSql &= "where A.TD_TestDt >= '" & strFromDt & " 00:00:00' AND A.TD_TestDt <= '" & strToDt & " 23:59:00'" & Environment.NewLine
                strSql &= "AND A.Test_ID = 7 " & Environment.NewLine
                strSql &= "AND B.Loc_ID = " & Syx.LOCID & Environment.NewLine
                strSql &= " order by A.Device_ID, td_id ;" & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)

                strSql = "Select Distinct A.Device_ID, Billcode_Desc " & Environment.NewLine
                strSql &= "from ttestdata A " & Environment.NewLine
                strSql &= "inner join tdevice B on A.device_id = B.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill C on A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes D on C.Billcode_ID = D.Billcode_ID AND Billtype_ID = 1 " & Environment.NewLine
                strSql &= "where A.TD_TestDt >= '" & strFromDt & " 00:00:00' AND A.TD_TestDt <= '" & strToDt & " 23:59:00'" & Environment.NewLine
                strSql &= "AND A.Test_ID = 7 " & Environment.NewLine
                strSql &= "AND B.Loc_ID = " & Syx.LOCID & Environment.NewLine
                strSql &= " order by A.Device_ID, td_id ;" & Environment.NewLine
                dtService = _objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    Dim drServ() As DataRow
                    Dim strService As String = ""
                    drServ = dtService.Select("Device_ID = " & R1("Device_ID"))
                    For i = 0 To drServ.Length - 1
                        If strService.Trim.Length > 0 Then strService &= "; "
                        strService &= drServ(i)("Billcode_Desc")
                    Next i
                    If strService.Trim.Length > 0 Then
                        R1.BeginEdit() : R1("Service") = strService : R1.EndEdit()
                    End If
                Next R1
                dt.Columns.Remove("Device_ID") : dt.AcceptChanges()

                If dt.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.", MsgBoxStyle.Information, "Information")
                Else
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objExcel.ActiveSheet.Pagesetup.Orientation = 1
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                    objSheet.Columns("A:B").Select()
                    objExcel.Selection.NumberFormat = "@"

                    ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
                    i = 0 : j = 0

                    For Each R1 In dt.Rows
                        '********************************
                        'Create Header
                        '********************************
                        If i = 0 Then
                            For j = 0 To dt.Columns.Count - 1
                                objArrData(i, j) = dt.Columns(j).Caption
                            Next j
                            i += 1
                        End If

                        '********************************
                        'Data
                        '********************************
                        For j = 0 To dt.Columns.Count - 1
                            objArrData(i, j) = R1(j)
                        Next j
                        i += 1
                        '********************************
                    Next R1

                    With objSheet
                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                        '*****************************************
                        'format header
                        '*****************************************
                        objSheet.Rows("1:1").Select()
                        With objExcel.Selection
                            .WrapText = False
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        .Cells.EntireColumn.AutoFit()
                        .Cells.EntireRow.AutoFit()

                        'Freeze Panel
                        objExcel.ActiveWindow.FreezePanes = False
                        .Range("A2:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "2").Select()
                        objExcel.ActiveWindow.FreezePanes = True
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt)
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*********************************************************************************************************
        Public Sub CreateWIPRpt(ByVal strRptName As String, ByVal strCutoffDate As String)
            Dim dt As DataTable
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application   ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim objArrData(,) As Object
            Dim R1 As DataRow
            Dim i, j As Integer

            Try
                dt = New DataTable()
                dt = Me.GetTotalWip(Syx.CUSTOMERID, Syx.LOCID, strCutoffDate)

                If dt.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.", MsgBoxStyle.Information, "Information")
                Else
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objExcel.ActiveSheet.Pagesetup.Orientation = 1
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                    objSheet.Columns("A:B").Select()
                    objExcel.Selection.NumberFormat = "@"

                    ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
                    i = 0 : j = 0

                    For Each R1 In dt.Rows
                        '********************************
                        'Create Header
                        '********************************
                        If i = 0 Then
                            For j = 0 To dt.Columns.Count - 1
                                objArrData(i, j) = dt.Columns(j).Caption
                            Next j
                            i += 1
                        End If

                        '********************************
                        'Data
                        '********************************
                        For j = 0 To dt.Columns.Count - 1
                            objArrData(i, j) = R1(j)
                        Next j
                        i += 1
                        '********************************
                    Next R1

                    With objSheet
                        .Range(Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1" & ":" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).NumberFormat = "@"

                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                        '*****************************************
                        'format header
                        '*****************************************
                        objSheet.Rows("1:1").Select()
                        With objExcel.Selection
                            .WrapText = False
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        .Cells.EntireColumn.AutoFit()
                        .Cells.EntireRow.AutoFit()

                        'Freeze Panel
                        objExcel.ActiveWindow.FreezePanes = False
                        .Range("A2:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "2").Select()
                        objExcel.ActiveWindow.FreezePanes = True
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt)
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*********************************************************************************************************
        Public Function GetTotalWip(ByVal iCustID As Integer, Optional ByVal iLocID As Integer = 0, Optional ByVal strCutoffDate As String = "") As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT B.PSS_SerialNumber as 'PSSI SN', B.ReceivingPalletName as 'Receiving Pallet Name' " & Environment.NewLine
                strSql &= ", D.Manuf_Desc as 'Manufacture' " & Environment.NewLine
                strSql &= ", H.Prod_Desc as 'Type' " & Environment.NewLine
                strSql &= ", IF(C.Model_Desc is null, B.Model_Desc, C.Model_Desc) as 'Model'" & Environment.NewLine
                strSql &= ", B.Manuf_SN as 'Manuf SN', B.Cost, I.Workstation as 'Location'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt as 'Location Entry Date', now() as 'Today' " & Environment.NewLine
                strSql &= ", IF(K.WIL_SDesc is null, '', K.WIL_SDesc) as 'Sub Location', IF(K.WIL_LDesc is null, '', K.WIL_LDesc) as 'Sub Location Description' " & Environment.NewLine
                strSql &= ", Device_DateRec, 0 as 'Days in Location', 0 'Days in WIP', '' as 'Out Bound Pallet Name', L.UPCCode " & Environment.NewLine
                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.tlocation ON A.Loc_ID = production.tlocation.Loc_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.syxdata B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tmodel C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.lmanuf D ON B.Manuf_ID = D.Manuf_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lproduct H ON B.newmodelprodid = H.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt I ON A.Device_ID = I.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.wipsublocmap K ON I.WIL_ID = K.WIL_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.syxrecpalletdata L ON B.PD_ID = L.PD_ID " & Environment.NewLine
                strSql &= "WHERE production.tlocation.Cust_ID = " & iCustID & Environment.NewLine
                If iLocID > 0 Then strSql &= "AND A.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND A.Device_DateShip is null " & Environment.NewLine
                If strCutoffDate.Trim.Length > 0 Then strSql &= "AND A.Device_DateRec <= '" & strCutoffDate & " 23:59:59'" & Environment.NewLine
                strSql &= "UNION" & Environment.NewLine
                strSql &= "SELECT B.PSS_SerialNumber as 'PSSI SN', B.ReceivingPalletName as 'Receiving Pallet Name' " & Environment.NewLine
                strSql &= ", D.Manuf_Desc as 'Manufacture' " & Environment.NewLine
                strSql &= ", H.Prod_Desc as 'Type' " & Environment.NewLine
                strSql &= ", IF(C.Model_Desc is null, B.Model_Desc, C.Model_Desc) as 'Model'" & Environment.NewLine
                strSql &= ", B.Manuf_SN as 'Manuf SN', B.Cost, I.Workstation as 'Location'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt as 'Location Entry Date', now() as 'Today'" & Environment.NewLine
                strSql &= ", IF(K.WIL_SDesc is null, '', K.WIL_SDesc) as 'Sub Location', IF(K.WIL_LDesc is null, '', K.WIL_LDesc) as 'Sub Location Description' " & Environment.NewLine
                strSql &= ", Device_DateRec, 0 as 'Days in Location', 0 'Days in WIP' , Pallett_Name as 'Out Bound Pallet Name', L.UPCCode " & Environment.NewLine
                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.syxdata B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tmodel C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.lmanuf D ON B.Manuf_ID = D.Manuf_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lproduct H ON B.newmodelprodid = H.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt I ON A.Device_ID = I.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tpallett J ON A.Pallett_ID = J.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.wipsublocmap K ON I.WIL_ID = K.WIL_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.syxrecpalletdata L ON B.PD_ID = L.PD_ID " & Environment.NewLine
                strSql &= "WHERE J.Cust_ID = " & iCustID & Environment.NewLine
                If iLocID > 0 Then strSql &= "AND A.Loc_ID = " & Syx.LOCID & Environment.NewLine
                strSql &= "AND J.pkslip_ID is null " & Environment.NewLine
                strSql &= "ORDER BY 'PSSI SN' "
                dt = _objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    If Not IsDBNull(R1("Location Entry Date")) Then
                        R1("Days in Location") = DateDiff(DateInterval.Day, Convert.ToDateTime(R1("Location Entry Date")), Convert.ToDateTime(R1("Today")))
                    Else
                        R1("Days in Location") = DateDiff(DateInterval.Day, Convert.ToDateTime(R1("Device_DateRec")), Convert.ToDateTime(R1("Today")))
                    End If
                    R1("Days in WIP") = DateDiff(DateInterval.Day, Convert.ToDateTime(R1("Device_DateRec")), Convert.ToDateTime(R1("Today")))
                    R1.EndEdit()
                Next R1
                dt.Columns.Remove("Today") : dt.Columns.Remove("Device_DateRec") : dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************************
        Public Sub CreateAdvanceReceiptRpt(ByVal strRptName As String)
            'Dim ds As DataSet
            'Dim objXL As Excel.Application
            'Dim objExcel As Excel.Application    ' Excel application
            'Dim objBook As Excel.Workbook     ' Excel workbook
            'Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            'Dim objArrData(,) As Object
            'Dim R1 As DataRow
            'Dim i, j As Integer

            'Try
            '    ds = New DataSet()
            '    ds = Me.GetAdvanceShipData()

            '    If ds.Tables("").Rows.Count = 0 Then
            '        MsgBox("There is no data in PSS Database for the criterion provided.", MsgBoxStyle.Information, "Information")
            '    Else
            '        objExcel = New Excel.Application()      'Starts the Excel Session
            '        objBook = objExcel.Workbooks.Add                    'Add a Workbook
            '        objExcel.Application.Visible = True                'Make this false while going live
            '        objExcel.Application.DisplayAlerts = False
            '        objExcel.ActiveSheet.Pagesetup.Orientation = 1
            '        objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
            '        objSheet.Columns("A:B").Select()
            '        objExcel.Selection.NumberFormat = "@"

            '        ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)
            '        i = 0 : j = 0

            '        For Each R1 In dt.Rows
            '            '********************************
            '            'Create Header
            '            '********************************
            '            If i = 0 Then
            '                For j = 0 To dt.Columns.Count - 1
            '                    objArrData(i, j) = dt.Columns(j).Caption
            '                Next j
            '                i += 1
            '            End If

            '            '********************************
            '            'Data
            '            '********************************
            '            For j = 0 To dt.Columns.Count - 1
            '                objArrData(i, j) = R1(j)
            '            Next j
            '            i += 1
            '            '********************************
            '        Next R1

            '        With objSheet
            '            .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

            '            '*****************************************
            '            'format header
            '            '*****************************************
            '            objSheet.Rows("1:1").Select()
            '            With objExcel.Selection
            '                .WrapText = False
            '                .HorizontalAlignment = Excel.Constants.xlCenter
            '                .VerticalAlignment = Excel.Constants.xlCenter
            '                .font.bold = True
            '                .Font.ColorIndex = 5
            '            End With

            '            .Cells.EntireColumn.AutoFit()
            '            .Cells.EntireRow.AutoFit()

            '            'Freeze Panel
            '            objExcel.ActiveWindow.FreezePanes = False
            '            .Range("A2:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "2").Select()
            '            objExcel.ActiveWindow.FreezePanes = True
            '        End With
            '    End If
            'Catch ex As Exception
            '    Throw ex
            'Finally
            '    Generic.DisposeDT(dt) : Generic.DisposeDT(dt)
            '    GC.WaitForPendingFinalizers()
            '    GC.Collect()
            '    GC.WaitForPendingFinalizers()
            'End Try
        End Sub

        '*********************************************************************************************************
        Public Function CreateNeedImageOnlyRpt(ByVal strRptName As String) As Integer
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim i, j As Integer
            Dim dt As DataTable = Nothing
            Dim arrData(,) As Object
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing

            Try
                dt = GetImageDeviceOnly()

                '*************************************************
                'DETAIL SHEET
                '*************************************************
                ReDim arrData(dt.Rows.Count + 1, dt.Columns.Count)

                'Collect header
                For j = 0 To dt.Columns.Count - 1
                    arrData(0, j) = dt.Columns(j).Caption
                Next j

                'Collect data
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        arrData(i + 1, j) = dt.Rows(i)(j)
                    Next j
                Next i

                xlApp = New Excel.Application()
                xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value)
                xlWorkSheet = xlWorkBook.Worksheets.Item(1)
                xlApp.Visible = True
                'xlWorkSheet = CType(xlWorkBook.Worksheets.Item("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)
                xlApp.Application.DisplayAlerts = False
                xlWorkSheet.Range("A1", Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1)).Value = arrData

                xlWorkSheet.Columns.AutoFit()
                'format header
                xlApp.Range("A1" & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                With xlApp.Selection
                    .WrapText = False : .font.bold = True : .Font.ColorIndex = 5
                    .HorizontalAlignment = Excel.Constants.xlCenter : .VerticalAlignment = Excel.Constants.xlCenter
                End With
                'Freeze Panel
                xlApp.ActiveWindow.FreezePanes = False
                xlApp.Range("A2", Generic.CalExcelColLetter(dt.Columns.Count) & "2").Select()
                xlApp.ActiveWindow.FreezePanes = True

            Catch ex As Exception
                If Not IsNothing(xlApp) Then
                    xlWorkBook.Close(SaveChanges:=False)
                    xlApp.Quit()
                End If
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

            Return 1
        End Function

        '*********************************************************************************************************
        Public Function GetImageDeviceOnly() As DataTable
            Dim strSql, strData As String
            Dim dtSummary, dtDetail, dtNeedVsConsumed, dtImageLib As DataTable
            Dim R1, drNewRow As DataRow

            dtSummary = Nothing : dtDetail = Nothing : dtNeedVsConsumed = Nothing : dtImageLib = Nothing

            Try
                strSql = "SELECT * FROM imagelibrary WHERE HasImage = 1 " & Environment.NewLine
                dtImageLib = Me._objDataProc.GetDataTable(strSql)

                strSql = "" : strData = ""
                strSql = "SELECT distinct tcellopt.workstation AS 'Location', if(wipsublocmap.WIL_SDesc is null, '', wipsublocmap.WIL_SDesc) as 'Sub Location' " & Environment.NewLine
                strSql &= ", '' as 'Has Image?', Model_Desc as 'Model', tmodel.ManufModelNumber as 'Manuf Model', tdevice.Device_ID, tdevice.Model_ID, device_sn as 'S/N', lcase(billcode_desc) as 'Bill code'" & Environment.NewLine
                strSql &= ", sum(trans_amount) as qty, 'No' as 'Consumed?' FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt on tdevice.device_id = tcellopt.device_id" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebillawap on tdevice.device_id = tdevicebillawap.device_id" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tdevicebillawap.billcode_id = lbillcodes.billcode_id AND lbillcodes.billcode_desc = 'IMAGE'" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN wipsublocmap on tcellopt.WIL_ID = wipsublocmap.WIL_ID " & Environment.NewLine
                strSql &= "WHERE device_dateship Is null " & Environment.NewLine
                strSql &= "GROUP BY tcellopt.workstation, device_sn, billcode_desc " & Environment.NewLine
                strSql &= "HAVING qty <> 0 " & Environment.NewLine
                strSql &= "ORDER BY tcellopt.workstation, device_sn, billcode_desc "
                dtDetail = Me._objDataProc.GetDataTable(strSql)

                'Need vs Consume part(s)
                strSql = "SELECT distinct tdevice.Device_ID, tdevicebillawap.Billcode_ID, lcase(billcode_desc) as 'Bill code'" & Environment.NewLine
                strSql &= ", sum(trans_amount) as qty, if(DBill_ID is null, 0, 1) as 'Consumed?' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebillawap on tdevice.device_id = tdevicebillawap.device_id" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tdevicebillawap.billcode_id = lbillcodes.billcode_id AND lbillcodes.BillType_ID <> 1" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill on tdevicebillawap.device_id = tdevicebill.device_id AND tdevicebillawap.Billcode_ID = tdevicebill.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE device_dateship Is null " & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID, tdevicebillawap.Billcode_ID " & Environment.NewLine
                strSql &= "HAVING qty <> 0 " & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_ID "
                dtNeedVsConsumed = Me._objDataProc.GetDataTable(strSql)

                dtSummary = dtDetail.Clone() : dtSummary.Columns.Remove("Bill code") : dtSummary.Columns.Remove("qty")
                dtSummary.Columns.Remove("Model_ID") : dtSummary.AcceptChanges()
                For Each R1 In dtDetail.Rows
                    If dtSummary.Select("[S/N] = '" & R1("S/N") & "'").Length = 0 Then
                        If dtDetail.Select("[S/N] = '" & R1("S/N") & "' and [Bill code] = 'image' and qty > 0").Length > 0 AndAlso dtDetail.Select("[S/N] = '" & R1("S/N") & "' and [Bill code] <> 'image' and qty > 0").Length = 0 Then
                            If dtNeedVsConsumed.Select("Device_ID = " & R1("Device_ID") & " AND [Consumed?] = 0 AND [Bill code] <> 'image'").Length = 0 AndAlso dtNeedVsConsumed.Select("Device_ID = " & R1("Device_ID") & " AND [Consumed?] = 1 AND [Bill code] = 'image'").Length = 0 Then
                                drNewRow = dtSummary.NewRow
                                drNewRow("Location") = R1("Location") : drNewRow("Sub Location") = R1("Sub Location")
                                drNewRow("Model") = R1("Model") : drNewRow("Manuf Model") = R1("Manuf Model")
                                drNewRow("S/N") = R1("S/N")

                                If dtImageLib.Select("Model_ID = " & R1("Model_ID")).Length > 0 Then drNewRow("Has Image?") = "Yes" Else drNewRow("Has Image?") = "No"

                                dtSummary.Rows.Add(drNewRow)
                            End If
                        End If
                    End If
                Next R1

                dtSummary.Columns.Remove("Device_ID") : dtSummary.Columns.Remove("Consumed?") : dtSummary.AcceptChanges()

                Return dtSummary
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtSummary) : Generic.DisposeDT(dtDetail) : Generic.DisposeDT(dtNeedVsConsumed)
            End Try
        End Function

        '*********************************************************************************************************
        Public Function HasConsumedImage(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND LCase(Billcode_Desc) = 'image' ;" & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) = 1 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************
        Public Function CreateBOMRpt(ByVal strRptName As String, ByVal strBillTypeIDs As String) As Integer
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                 Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim i, j As Integer
            Dim dt As New DataTable()
            Dim arrData(,) As Object
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct Prod_Desc as 'Type', Manuf_Desc as 'Manufacture', Model_Desc as 'Model', ManufModelNumber as 'Manuf Model #', Billcode_Desc as 'Bill Code'" & Environment.NewLine
                strSql &= ", psprice_number as 'Part #', psprice_Desc as 'Part Description'" & Environment.NewLine
                strSql &= ", BillType_LDesc as 'Bill Code Type'" & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tpsmap ON tdevice.model_ID = tpsmap.model_id" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpsmap.model_ID = tmodel.model_ID" & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tmodel.prod_id = lproduct.prod_id AND tpsmap.prod_ID = lproduct.prod_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tpsmap.billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID" & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_ID = lpsprice.psprice_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbilltype ON lbillcodes.BillType_ID = lbilltype.BillType_ID" & Environment.NewLine
                If strBillTypeIDs.Trim.Length > 0 Then strSql &= "WHERE lbillcodes.BillType_ID IN ( " & strBillTypeIDs & " );"
                dt = Me._objDataProc.GetDataTable(strSql)

                '*************************************************
                'DETAIL SHEET
                '*************************************************
                ReDim arrData(dt.Rows.Count + 1, dt.Columns.Count)

                'Collect header
                For j = 0 To dt.Columns.Count - 1
                    arrData(0, j) = dt.Columns(j).Caption
                Next j

                'Collect data
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        arrData(i + 1, j) = dt.Rows(i)(j)
                    Next j
                Next i

                xlApp = New Excel.Application()
                xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value)
                xlWorkSheet = xlWorkBook.Worksheets.Item(1)
                xlApp.Visible = True
                'xlWorkSheet = CType(xlWorkBook.Worksheets.Item("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)
                xlApp.Application.DisplayAlerts = False
                xlWorkSheet.Range("A1", Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1)).Value = arrData

                xlWorkSheet.Columns.AutoFit()
                'format header
                xlApp.Range("A1" & ":" & Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                With xlApp.Selection
                    .WrapText = False : .font.bold = True : .Font.ColorIndex = 5
                    .HorizontalAlignment = Excel.Constants.xlCenter : .VerticalAlignment = Excel.Constants.xlCenter
                End With
                'Freeze Panel
                xlApp.ActiveWindow.FreezePanes = False
                xlApp.Range("A2", Generic.CalExcelColLetter(dt.Columns.Count) & "2").Select()
                xlApp.ActiveWindow.FreezePanes = True

                Return dt.Rows.Count
            Catch ex As Exception
                If Not IsNothing(xlApp) Then
                    xlWorkBook.Close(SaveChanges:=False)
                    xlApp.Quit()
                End If
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*********************************************************************************************************

    End Class
End Namespace