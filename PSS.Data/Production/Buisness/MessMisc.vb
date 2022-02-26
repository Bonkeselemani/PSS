Option Explicit On 

Imports System.IO
'Imports System.Windows.Forms

Namespace Buisness
    Public Class MessMisc

        Private objMisc As Production.Misc


        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub


        '**********************************************************************
        'Unship all device in ship_id for messaging
        '**********************************************************************
        Public Function UnshipMessgShipID(ByVal iShipID As Integer, _
                                          ByVal iUserShipQty As Integer, _
                                          ByVal strSN As String) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                '******************************
                'Get all devices in tray
                '******************************
                strSql = "select tdevice.*, Week(Device_DateShip) as 'ShipWeek', Week(now()) 'CurrentWeek' " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "where tworkorder.Prod_ID = 1 " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is not null " & Environment.NewLine
                'strSql &= "AN tdevice.Device_Invoice  = 0 " & Environment.NewLine
                If strSN.Trim.Length > 0 Then strSql &= "AND tdevice.Device_SN = '" & strSN & "'" & Environment.NewLine
                strSql &= "AND tdevice.ship_id = " & iShipID & ";"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Ship_ID does not exist or devices already invoiced.")
                End If

                If dt1.Rows.Count <> iUserShipQty Then
                    Throw New Exception("Quantity in the system are different with user input. Unship was cancelled.")
                ElseIf dt1.Select("Device_Invoice > 0 ").Length > 0 Then
                    Throw New Exception("Device(s) has been invoiced.")
                ElseIf dt1.Select("Pallett_ID > 0 ").Length > 0 Then
                    Throw New Exception("Device(s) has been manifested.")
                ElseIf dt1.Rows(0)("ShipWeek") <> dt1.Rows(0)("CurrentWeek") Then
                    Throw New Exception("Device(s) has been posted for incentive pay.")
                End If

                '******************************
                'Update tdevice and tworkorder
                '******************************
                strSql = "update tdevice, tworkorder, tmessdata " & Environment.NewLine
                strSql &= "set tdevice.Device_DateShip = null, " & Environment.NewLine
                strSql &= "tdevice.Device_ShipWorkDate = NULL, " & Environment.NewLine
                strSql &= "tdevice.Ship_ID = null, " & Environment.NewLine
                strSql &= "tdevice.Pallett_ID = null, " & Environment.NewLine
                strSql &= "tdevice.Shift_ID_Ship = 0, " & Environment.NewLine
                strSql &= "tworkorder.WO_Shipped = 0, " & Environment.NewLine
                strSql &= "tworkorder.WO_DateShip = null " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id = 3 " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_EntryDt = now() " & Environment.NewLine
                strSql &= "where tdevice.wo_id = tworkorder.wo_id and tdevice.device_id = tmessdata.device_id and " & Environment.NewLine
                strSql &= "tworkorder.Prod_ID = 1 and " & Environment.NewLine
                strSql &= "tdevice.Device_DateShip is not null  and " & Environment.NewLine
                strSql &= "tdevice.Device_Invoice  = 0 and  " & Environment.NewLine
                strSql &= "tdevice.ship_id = " & iShipID & Environment.NewLine
                If strSN.Trim.Length > 0 Then strSql &= "AND tdevice.Device_SN = '" & strSN & "';"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                '******************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
            End Try
        End Function

        '**********************************************************************
        'delete a tray out from the system
        '**********************************************************************
        Public Function DeleteTray(ByVal iTray_id As Integer) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                '******************************
                'Get all devices in tray
                '******************************
                'strSql = "select tdevice.* " & Environment.NewLine
                strSql = "select Count(*) as cnt " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "where tworkorder.Prod_ID = 1 and " & Environment.NewLine
                strSql &= "tdevice.Device_DateShip is null  and " & Environment.NewLine
                strSql &= "tdevice.Device_DateBill is null and " & Environment.NewLine
                strSql &= "tdevice.Device_Invoice  = 0 and " & Environment.NewLine
                strSql &= "tdevice.tray_id = " & iTray_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows(0)("cnt") = 0 Then
                    Throw New Exception("Devices may already be Shipped or Billed or Invoiced or Tray just does not exist.")
                End If
                '******************************
                'Delete from tdevice
                '******************************
                strSql = "delete from tdevice where tray_id = " & iTray_id & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                '******************************
                'Delete from ttray
                '******************************
                strSql = "delete from ttray where tray_id = " & iTray_id & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                '******************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
            End Try
        End Function
        '*******************************************************
        Public Function GetFrequencies() As DataTable
            Dim strSql As String

            Try
                strSql = "Select * from lfrequency order by freq_id;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '*****************************************************************************************************************************************
        Public Function LoadForecastExcelData(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strFileLocAndName As String, ByVal bSpecialQty As Boolean) As DataTable
            Dim strHeader() As String = New String() {"Eq Type", "Format", "FREQ CODE", "Qty Needed Per Wk"}
            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet1 As Excel.Worksheet = Nothing
            Dim HeaderNames As New ArrayList()

            Dim dt As New DataTable()
            Dim R1 As DataRow

            Dim strVal As String = ""
            Dim booHasFreq As Boolean = False
            Dim i As Integer, j As Integer, iRowsCnt, iColCnt, iFreqID, iBaudID, iModelID As Integer

            Try
                If bSpecialQty Then strHeader(3) = "Special Qty Needed"

                If File.Exists(strFileLocAndName) Then

                    xlWorkBook = xlApp.Workbooks.Open(strFileLocAndName)

                    xlWorkSheet1 = xlWorkBook.Worksheets(1)
                    xlWorkSheet1.Select()
                    iRowsCnt = xlWorkBook.ActiveSheet.UsedRange.Rows.Count()
                    iColCnt = xlWorkBook.ActiveSheet.UsedRange.Columns.Count()

                    If iColCnt < strHeader.Length Then Throw New Exception("Excel does not contain enough column.")

                    'Check Header
                    For i = 1 To iColCnt
                        If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(1, i).value) Then '.Range("A" & i).Value
                            Exit For
                        ElseIf Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(1, i).value) Then
                            Exit For
                        ElseIf xlWorkSheet1.Cells(1, i).value Is "" Or xlWorkSheet1.Cells(1, i).value Is Nothing Then
                            Exit For
                        Else
                            strVal = xlWorkSheet1.Cells(1, i).value.ToString.Trim()
                            Select Case i
                                Case 1
                                    If strVal.ToLower <> "eq type" Then Throw New Exception("Header of Column A must be 'Eq Type'.")
                                Case 2
                                    If strVal.ToLower <> "format" Then Throw New Exception("Header of Column B must be 'Format'.")
                                Case 3
                                    If strVal.ToUpper <> "FREQ CODE" AndAlso strVal.ToUpper <> "FREQUENCY" Then Throw New Exception("Header of Column C must be either 'FREQ CODE' or 'FREQUENCY'.")
                                    If strVal.ToUpper = "FREQUENCY" Then booHasFreq = True
                                Case 4
                                    If bSpecialQty Then
                                        If strVal.ToLower <> "special qty needed" Then Throw New Exception("Header of Column D must be 'Special Qty Needed'.")
                                    Else
                                        If strVal.ToLower <> "qty needed per wk" Then Throw New Exception("Header of Column D must be 'Qty Needed Per Wk'.")
                                    End If
                                Case Else
                                    Throw New Exception("Invalid colunm name " & strVal & ".")
                            End Select
                        End If
                    Next i

                    If booHasFreq Then strHeader(2) = "FREQUENCY"

                    ' dt = Generic.GetDatabaseTableTemplate("Production.tamsforecastedneed")
                    dt.Columns.Add(New DataColumn("LineNo", GetType(Integer)))
                    dt.Columns.Add(strHeader(0), GetType(String))
                    dt.Columns.Add(strHeader(1), GetType(String))
                    dt.Columns.Add(strHeader(2), GetType(String))
                    dt.Columns.Add(strHeader(3), GetType(Integer))
                    dt.Columns.Add(New DataColumn("HasModel", GetType(String)))
                    dt.Columns.Add(New DataColumn("Freq_ID", GetType(Integer)))
                    dt.Columns.Add(New DataColumn("Baud_ID", GetType(Integer)))
                    dt.Columns.Add(New DataColumn("HasFreq", GetType(Integer)))
                    dt.Columns.Add(New DataColumn("Model_ID", GetType(Integer)))


                    'Get Data
                    i = 2
                    While True
                        R1 = dt.NewRow

                        If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, 1).value) _
                           OrElse Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, 1).value) _
                           OrElse xlWorkSheet1.Cells(i, 1).value Is "" Or xlWorkSheet1.Cells(i, 1).value Is Nothing Then Exit While

                        For j = 1 To 4
                            If Microsoft.VisualBasic.IsDBNull(xlWorkSheet1.Cells(i, j).value) _
                               OrElse Microsoft.VisualBasic.IsNothing(xlWorkSheet1.Cells(i, j).value) _
                               OrElse xlWorkSheet1.Cells(i, j).value Is "" Or xlWorkSheet1.Cells(i, j).value Is Nothing Then Throw New Exception("Column " & strHeader(j - 1) & " can't not be blank.")

                            strVal = xlWorkSheet1.Cells(i, j).value.ToString.Trim()
                            ' AMS_Model, AMS_Baud, AMS_Freq, PSSI_Model_ID, PSSI_Baud_ID, PSSI_Freq_ID, Date, YearWeekStartDate, FC_Year, FC_Week, Qty, Cust_ID
                            Select Case j
                                Case 1
                                    iModelID = Me.GetModelID(strVal)
                                    If iModelID > 0 Then R1("HasModel") = "Yes" Else R1("HasModel") = "No"
                                    R1(strHeader(0)) = strVal
                                    R1("Model_ID") = iModelID
                                Case 2
                                    If strVal.ToUpper <> "FLEX" Then strVal = "POCSAG " & strVal
                                    iBaudID = Me.GetBaudID(strVal)
                                    R1(strHeader(1)) = strVal
                                    R1("Baud_ID") = iBaudID
                                Case 3
                                    If booHasFreq = True Then
                                        strVal = Me.FormatFreq(strVal)
                                        iFreqID = Me.GetFreqIDByFreqNo(strVal)
                                        R1("HasFreq") = 1
                                    Else
                                        iFreqID = Me.GetFreqIDByFreqCode(iCustID, iLocID, strVal)
                                        R1("HasFreq") = 0
                                    End If
                                    R1(strHeader(2)) = strVal
                                    R1("Freq_ID") = iFreqID
                                Case 4
                                    If Not IsNumeric(strVal) Then Throw New Exception("Line # " & i & " column " & strHeader(3) & " has an invalid value.")
                                    R1(strHeader(3)) = CInt(strVal)
                            End Select
                        Next j

                        R1("LineNo") = i
                        dt.Rows.Add(R1)
                        i += 1
                    End While

                Else
                    Throw New Exception("Can't find file.")
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(xlWorkSheet1) Then PSS.Data.Buisness.Generic.NAR(xlWorkSheet1)
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False) : PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit() : PSS.Data.Buisness.Generic.NAR(xlApp)
                End If

                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*****************************************************************************************************************************************
        Private Function FormatFreq(ByVal strFreq As String) As String
            Dim strArr As String(), strRetVal As String = ""

            Try
                strArr = strFreq.Split(".")

                If strArr.Length = 0 Then Return strFreq

                If strArr.Length = 1 Then
                    strRetVal = strArr(0).PadLeft(3, "0")
                    strRetVal &= ".0000"
                Else
                    strRetVal = strArr(0).PadLeft(3, "0")
                    strRetVal &= "." & strArr(1).PadRight(4, "0")
                End If
                Return strRetVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function GetFreqIDByFreqNo(ByVal strFreqNumber As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT Freq_ID FROM lfrequency WHERE Freq_Number = '" & strFreqNumber & "' "
                Return Me.objMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Private Function GetFreqIDByFreqCode(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strFreqCode As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT Freq_ID FROM tcustomerfreqcodemap WHERE Freq_Code = '" & strFreqCode & "' AND Cust_ID = " & iCustID & " AND Loc_ID = " & iLocID
                Return Me.objMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function GetBaudID(ByVal strBaudNumber As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT baud_id FROM lbaud WHERE baud_Number = '" & strBaudNumber & "';"
                Return Me.objMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function GetModelID(ByVal strModelDesc As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_ID FROM tmodel WHERE Model_Desc = '" & strModelDesc & "'"
                Return Me.objMisc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''*****************************************************************************************************************************************
        ''OLD
        'Public Function AMSFC_UploadingWeeklyForecast(ByVal iCustID As Integer, ByVal strStartDateOfWeek As String, ByVal iWeekQty As Integer, _
        '                                              ByVal dtFCData As DataTable, ByVal booSpecialRequestedFC As Boolean, ByVal iUserID As Integer) As Integer
        '    Dim strCustFreq, strChkWeekStartDate, strThisWeekStartDate, strToday As String
        '    Dim dtMRPYearWeek, dt As DataTable
        '    Dim iYear, iYearWeekNo, i, iFC_ID, j As Integer
        '    Dim R1 As DataRow

        '    Try
        '        strToday = Generic.MySQLServerDateTime(1)
        '        strThisWeekStartDate = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
        '        If DateDiff(DateInterval.Day, CDate(strThisWeekStartDate), CDate(strStartDateOfWeek), FirstDayOfWeek.Monday, ) < 0 Then Throw New Exception("Can't make change to forecast in previous weeks.")
        '        If DateDiff(DateInterval.Month, CDate(strThisWeekStartDate), CDate(strStartDateOfWeek), , ) > 6 Then Throw New Exception("Can't make change to forecast in previous weeks.")

        '        '*************************************************************
        '        'Check if week is setup in MRP
        '        '*************************************************************
        '        strChkWeekStartDate = strStartDateOfWeek
        '        For i = 1 To iWeekQty
        '            dtMRPYearWeek = AMSFC_GetMRPYearWeek(CDate(strChkWeekStartDate))
        '            If dtMRPYearWeek.Rows.Count = 0 Then Throw New Exception("Week number of the year did not set up in MRP for week start start with '" & CDate(strChkWeekStartDate).ToString("MM/dd/yyyy") & "'.")

        '            strChkWeekStartDate = DateAdd(DateInterval.Day, 7, CDate(strChkWeekStartDate)).ToString("yyyy-MM-dd")
        '        Next i

        '        '*************************************************************
        '        For i = 1 To iWeekQty
        '            dtMRPYearWeek = AMSFC_GetMRPYearWeek(CDate(strStartDateOfWeek))
        '            iYear = CInt(dtMRPYearWeek.Rows(0)("Year"))
        '            iYearWeekNo = CInt(dtMRPYearWeek.Rows(0)("YearWeek"))

        '            For Each R1 In dtFCData.Rows
        '                dt = AMSFC_GetExistingFC(iCustID, CInt(R1("Model_ID")), CInt(R1("Baud_ID")), CInt(R1("Freq_ID")), iYear, strStartDateOfWeek)
        '                If dt.Rows.Count > 0 Then iFC_ID = CInt(dt.Rows(0)("AFN_ID")) Else iFC_ID = 0

        '                If CInt(R1("HasFreq")) = 1 Then
        '                    strCustFreq = R1("FREQUENCY").ToString
        '                Else
        '                    strCustFreq = R1("FREQ CODE").ToString
        '                End If

        '                j += AMSFC_UpdateFC(iCustID, CInt(R1("Model_ID")), R1("Eq Type").ToString, R1("Format").ToString, strCustFreq, CInt(R1("Baud_ID")), CInt(R1("Freq_ID")), strStartDateOfWeek, iYear, iYearWeekNo, CInt(R1("Qty Needed Per Wk")), booSpecialRequestedFC, iUserID, iFC_ID)
        '            Next R1

        '            iFC_ID = 0
        '            iYearWeekNo += 1
        '            strStartDateOfWeek = DateAdd(DateInterval.Day, 7, CDate(strStartDateOfWeek)).ToString("yyyy-MM-dd")
        '        Next i

        '        Return j
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dtFCData) : Generic.DisposeDT(dtMRPYearWeek) : Generic.DisposeDT(dt)
        '    End Try
        'End Function

        '*****************************************************************************************************************************************
        Public Function AMSFC_UploadingWeeklyForecast(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strStartDateOfWeek As String, _
                                                      ByVal dtFCData As DataTable, ByVal iUserID As Integer) As Integer
            'ByVal dtFCData As DataTable, ByVal booSpecialRequestedFC As Boolean, ByVal iUserID As Integer) As Integer

            'Regular Qty data------------------------------------------------------------------------
            Dim strCustFreq, strChkWeekStartDate, strThisWeekStartDate, strToday As String
            Dim dtMRPYearWeek, dt As DataTable
            Dim iYear, iYearWeekNo, i, iFC_ID, j As Integer
            Dim R1 As DataRow

            Try

                strToday = Generic.MySQLServerDateTime(1)
                strThisWeekStartDate = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                If DateDiff(DateInterval.Day, CDate(strThisWeekStartDate), CDate(strStartDateOfWeek), FirstDayOfWeek.Monday, ) < 0 Then Throw New Exception("Can't make change to forecast in previous weeks.")
                If DateDiff(DateInterval.Month, CDate(strThisWeekStartDate), CDate(strStartDateOfWeek), , ) > 6 Then Throw New Exception("Can't make change to forecast in previous weeks.")

                '*************************************************************
                'Check if week is setup in MRP
                '*************************************************************
                strChkWeekStartDate = strStartDateOfWeek
                ' For i = 1 To iWeekQty
                dtMRPYearWeek = AMSFC_GetMRPYearWeek(CDate(strChkWeekStartDate))
                If dtMRPYearWeek.Rows.Count = 0 Then Throw New Exception("Week number of the year did not set up in MRP for week start start with '" & CDate(strChkWeekStartDate).ToString("MM/dd/yyyy") & "'.")

                'strChkWeekStartDate = DateAdd(DateInterval.Day, 7, CDate(strChkWeekStartDate)).ToString("yyyy-MM-dd")
                ' Next i

                '*************************************************************
                'For i = 1 To iWeekQty
                dtMRPYearWeek = AMSFC_GetMRPYearWeek(CDate(strStartDateOfWeek))
                iYear = CInt(dtMRPYearWeek.Rows(0)("Year"))
                iYearWeekNo = CInt(dtMRPYearWeek.Rows(0)("YearWeek"))

                For Each R1 In dtFCData.Rows
                    dt = AMSFC_GetExistingFC(iCustID, iLocID, CInt(R1("Model_ID")), CInt(R1("Baud_ID")), CInt(R1("Freq_ID")), iYear, strStartDateOfWeek)
                    If dt.Rows.Count > 0 Then iFC_ID = CInt(dt.Rows(0)("AFN_ID")) Else iFC_ID = 0

                    If CInt(R1("HasFreq")) = 1 Then
                        strCustFreq = R1("FREQUENCY").ToString
                    Else
                        strCustFreq = R1("FREQ CODE").ToString
                    End If

                    'j += AMSFC_UpdateFC(iCustID, CInt(R1("Model_ID")), R1("Eq Type").ToString, R1("Format").ToString, strCustFreq, CInt(R1("Baud_ID")), CInt(R1("Freq_ID")), strStartDateOfWeek, iYear, iYearWeekNo, CInt(R1("Qty Needed Per Wk")), booSpecialRequestedFC, iUserID, iFC_ID)
                    j += AMSFC_UpdateFC(iCustID, iLocID, CInt(R1("Model_ID")), R1("Eq Type").ToString, R1("Format").ToString, strCustFreq, CInt(R1("Baud_ID")), CInt(R1("Freq_ID")), strStartDateOfWeek, iYear, iYearWeekNo, CInt(R1("Qty Needed Per Wk")), iUserID, iFC_ID)
                Next R1

                iFC_ID = 0
                iYearWeekNo += 1
                strStartDateOfWeek = DateAdd(DateInterval.Day, 7, CDate(strStartDateOfWeek)).ToString("yyyy-MM-dd")
                ' Next i

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtFCData) : Generic.DisposeDT(dtMRPYearWeek) : Generic.DisposeDT(dt)
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function AMSFC_InsertForecastSpecialQty(ByVal iCustID As Integer, _
                                                       ByVal iLocID As Integer, _
                                                       ByVal dtFCData As DataTable, _
                                                       ByVal iUserID As Integer) As Integer

            'Speical Requested Qty data------------------------------------------------------------------------
            Dim j As Integer = 0
            Dim R1 As DataRow
            Dim strCustFreq As String = ""

            Try

                For Each R1 In dtFCData.Rows
                    If CInt(R1("HasFreq")) = 1 Then
                        strCustFreq = R1("FREQUENCY").ToString
                    Else
                        strCustFreq = R1("FREQ CODE").ToString
                    End If
                    j += AMSFC_InsertFC_Special(iCustID, iLocID, CInt(R1("Model_ID")), R1("Eq Type").ToString, R1("Format").ToString, strCustFreq, CInt(R1("Baud_ID")), CInt(R1("Freq_ID")), CInt(R1("Special Qty Needed")), iUserID)
                Next R1

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtFCData)
            End Try
        End Function


        '*****************************************************************************************************************************************
        Private Function AMSFC_GetMRPYearWeek(ByVal dteFirDateOfWeek As Date) As DataTable
            Dim strSql As String = ""
            Dim iYearWeek As Integer

            Try
                strSql = "SELECT * FROM cogs.mrpyearsweeks " & Environment.NewLine
                strSql &= "WHERE Year = " & dteFirDateOfWeek.Year & " AND YearWeekStartDate = '" & CDate(dteFirDateOfWeek).ToString("yyyy-MM-dd") & "'"
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Private Function AMSFC_GetExistingFC(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iModelID As Integer, ByVal iBaudID As Integer, ByVal iFreqID As Integer, _
                                             ByVal iYear As Integer, ByVal strYearWeekStartDate As String) As DataTable
            Dim strSql As String = ""
            Dim iYearWeek As Integer

            Try
                'AFN_ID, AMS_Orig_Model, AMS_Model, AMS_Baud, AMS_Freq, PSSI_Model_ID, PSSI_Baud_ID, PSSI_Freq_ID, Date
                ', YearWeekStartDate, FC_Year, FC_Week, Qty, SpecialRequestedQty, Cust_ID, UpdateDate, UpdateUserID
                strSql = "SELECT * FROM tamsforecastedneed " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND Loc_ID = " & iLocID & " AND PSSI_Model_ID = " & iModelID & " AND PSSI_Baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND PSSI_Freq_ID = " & iFreqID & " AND  YearWeekStartDate = '" & strYearWeekStartDate & "'" & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Private Function AMSFC_UpdateFC(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iModelID As Integer, ByVal strCustModel As String, ByVal strCustBaud As String, _
                                        ByVal strCustFreq As String, ByVal iBaudID As Integer, ByVal iFreqID As Integer, ByVal strYearWeekStartDate As String, _
                                        ByVal iYear As Integer, ByVal iWeekNo As Integer, ByVal iFCQty As Integer, _
                                        ByVal iUserID As Integer, ByVal iAFN_ID As Integer) As Integer

            'ByVal iYear As Integer, ByVal iWeekNo As Integer, ByVal iFCQty As Integer, ByVal booSpecialRequestedFC As Boolean, _
            'ByVal iUserID As Integer, ByVal iAFN_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                If iAFN_ID = 0 Then
                    strSql = "INSERT INTO tamsforecastedneed ( " & Environment.NewLine
                    strSql &= " AMS_Orig_Model, AMS_Model, AMS_Baud, AMS_Freq, PSSI_Model_ID, PSSI_Baud_ID, PSSI_Freq_ID, Date " & Environment.NewLine
                    strSql &= " , YearWeekStartDate, FC_Year, FC_Week, Cust_ID, Loc_ID, UpdateDate, UpdateUserID, UpdateFlag " & Environment.NewLine
                    'If booSpecialRequestedFC Then strSql &= ", SpecialRequestedQty " & Environment.NewLine Else strSql &= ", Qty " & Environment.NewLine
                    strSql &= ", Qty " & Environment.NewLine
                    strSql &= " ) VALUES ( " & Environment.NewLine
                    strSql &= "  '" & strCustModel & "', '" & strCustModel & "', '" & strCustBaud & "', '" & strCustFreq & "', " & iModelID & ", " & iBaudID & ", " & iFreqID & ", '" & strYearWeekStartDate & "' " & Environment.NewLine
                    strSql &= ", '" & strYearWeekStartDate & "', " & iYear & ", " & iWeekNo & ", " & iCustID & ", " & iLocID & ", now(), " & iUserID & ", 1 " & Environment.NewLine
                    strSql &= ", " & iFCQty & Environment.NewLine
                    strSql &= " ) " & Environment.NewLine
                    i = Me.objMisc.ExecuteNonQuery(strSql)
                Else
                    strSql = " UPDATE tamsforecastedneed SET UpdateFlag = 1 " & Environment.NewLine
                    'If booSpecialRequestedFC Then strSql &= ", SpecialRequestedQty = " & iFCQty & Environment.NewLine Else strSql &= ", Qty = " & iFCQty & Environment.NewLine
                    strSql &= ", Qty = " & iFCQty & Environment.NewLine
                    strSql &= " WHERE AFN_ID = " & iAFN_ID & Environment.NewLine
                    strSql &= "  " & Environment.NewLine
                    i = Me.objMisc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''*****************************************************************************************************************************************
        ''Old
        'Public Function AMSFC_GetAMSForcast(ByVal iCustID As Integer, ByVal strWeekStartFrDate As String, ByVal iWeekQty As Integer) As DataTable
        '    Dim strSql As String = ""
        '    Dim dteWeekStartToDate As Date

        '    Try
        '        dteWeekStartToDate = DateAdd(DateInterval.Day, ((iWeekQty - 1) * 7), CDate(strWeekStartFrDate))
        '        strSql = "SELECT AMS_Model as 'Cust Model', AMS_Baud as 'Cust Baud', AMS_Freq as 'Cust Freq'" & Environment.NewLine
        '        strSql &= ", Qty as 'FC Qty', SpecialRequestedQty as 'Special Requested Qty', YearWeekStartDate, FC_Year as Year, FC_Week  as Week  " & Environment.NewLine
        '        strSql &= ", UpdateDate as 'Last Update Date', User_FullName as 'Last Update User'" & Environment.NewLine
        '        strSql &= "FROM tamsforecastedneed A" & Environment.NewLine
        '        strSql &= "INNER JOIN lfrequency B ON A.PSSI_Freq_ID = B.Freq_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN security.tusers C ON A.UpdateUserID = C.User_ID " & Environment.NewLine
        '        strSql &= "WHERE A.Cust_ID = " & iCustID & "" & Environment.NewLine
        '        strSql &= " AND YearWeekStartDate BETWEEN '" & CDate(strWeekStartFrDate).ToString("yyyy-MM-dd") & "' AND '" & dteWeekStartToDate.ToString("yyyy-MM-dd") & "'" & Environment.NewLine
        '        strSql &= "ORDER BY FC_Year, FC_Week "
        '        Return Me.objMisc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '*****************************************************************************************************************************************
        Private Function AMSFC_InsertFC_Special(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iModelID As Integer, _
                                                ByVal strCustModel As String, ByVal strCustBaud As String, _
                                                ByVal strCustFreq As String, ByVal iBaudID As Integer, _
                                                ByVal iFreqID As Integer, ByVal iFCQty As Integer, _
                                                ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "INSERT INTO  tamsforecastedneed_special( " & Environment.NewLine
                strSql &= " AMS_Orig_Model, AMS_Model, AMS_Baud, AMS_Freq, PSSI_Model_ID, PSSI_Baud_ID, PSSI_Freq_ID " & Environment.NewLine
                strSql &= " , Cust_ID, Loc_ID, UpdateDate, UpdateUserID " & Environment.NewLine
                strSql &= ", SpecialRequestedQty " & Environment.NewLine
                strSql &= " ) VALUES ( " & Environment.NewLine
                strSql &= "  '" & strCustModel & "', '" & strCustModel & "', '" & strCustBaud & "', '" & strCustFreq & "', " & iModelID & ", " & iBaudID & ", " & iFreqID & Environment.NewLine
                strSql &= "," & iCustID & "," & iLocID & ", now(), " & iUserID & Environment.NewLine
                strSql &= ", " & iFCQty & Environment.NewLine
                strSql &= " ) " & Environment.NewLine
                i = Me.objMisc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function AMSFC_GetAMSForcast(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strWeekStartFrDate As String) As DataTable
            Dim strSql As String = ""
            Dim dteWeekStartToDate As Date

            Try
                strSql = "SELECT AMS_Model as 'Cust Model', AMS_Baud as 'Cust Baud', AMS_Freq as 'Cust Freq'" & Environment.NewLine
                'strSql &= ", Qty as 'FC Qty', SpecialRequestedQty as 'Special Requested Qty', YearWeekStartDate, FC_Year as Year, FC_Week  as Week  " & Environment.NewLine
                strSql &= ", Qty as 'FC Qty', YearWeekStartDate, FC_Year as Year, FC_Week  as Week  " & Environment.NewLine
                strSql &= ", UpdateDate as 'Last Update Date', User_FullName as 'Last Update User'" & Environment.NewLine
                strSql &= " FROM tamsforecastedneed A" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency B ON A.PSSI_Freq_ID = B.Freq_ID " & Environment.NewLine
                strSql &= " INNER JOIN security.tusers C ON A.UpdateUserID = C.User_ID " & Environment.NewLine
                strSql &= " WHERE A.Cust_ID = " & iCustID & " AND A.Loc_ID = " & iLocID & "" & Environment.NewLine
                strSql &= " AND YearWeekStartDate >= '" & strWeekStartFrDate & "'" & Environment.NewLine
                strSql &= " ORDER BY FC_Year, FC_Week "
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function AMSFC_EarlyCloseAMSSpecialRequested(ByVal iAFSPQTYID As Integer, ByVal strComment As String, _
                                                            ByVal iUserID As Integer, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iCurrentSpecialRequestedQty As Integer = 0
            Dim i As Integer = 0
            Dim strLogType As String = "Early Close"
            Try
                'Check it
                strSql = "SELECT * FROM tamsforecastedneed_special WHERE AFSPQTY_ID=" & iAFSPQTYID
                dt = Me.objMisc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("SpecialQtyCompleted") = 1 Then
                        Throw New Exception("It is already closed.")
                    Else 'update it
                        iCurrentSpecialRequestedQty = Trim(dt.Rows(0).Item("SpecialRequestedQty"))

                        strSql = "UPDATE tamsforecastedneed_special " & Environment.NewLine
                        strSql &= " SET SpecialRequestedQty=SpecialShippedQty, SpecialQtyCompleted=1 " & Environment.NewLine
                        strSql &= ", UpdateDate='" & strDateTime & "', UpdateUserID=" & iUserID & Environment.NewLine
                        strSql &= " WHERE AFSPQTY_ID = " & iAFSPQTYID
                        i = Me.objMisc.ExecuteNonQuery(strSql)

                        strSql = "INSERT INTO tamsforecastedneed_special_log (AFSPQTY_ID,HistoryQty,Comment,UpdateDate,UpdateUserID,LogType)" & _
                                 " VALUES (" & iAFSPQTYID & "," & iCurrentSpecialRequestedQty & _
                                 ",'" & strComment.Replace("'", "''") & "','" & strDateTime & _
                                 "'," & iUserID & ",'" & strLogType & "');"
                        i += Me.objMisc.ExecuteNonQuery(strSql)

                        Return i

                    End If
                Else
                    Throw New Exception("Can't find it. Failed to change.")
                End If

                dt = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function AMSFC_GetAMSSpecialRequested(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal bIncludingHistory As Boolean) As DataTable
            Dim strSql As String = ""
            ' Dim dteWeekStartToDate As Date
            Dim dt, dt2 As DataTable
            Dim row, row2 As DataRow
            Dim strS As String = "; "
            Dim strHistory As String = ""
            Dim strComment As String = ""
            Dim strUserUpdateName As String = ""
            Dim strUserUpdatetime As String = ""

            Try
                strSql = "SELECT AMS_Model as 'Cust Model', AMS_Baud as 'Cust Baud', AMS_Freq as 'Cust Freq'" & Environment.NewLine
                strSql &= ",SpecialRequestedQty as 'SpecialRequestedQty_Old',SpecialRequestedQty,SpecialShippedQty,if(SpecialQtyCompleted=1, 'Yes','No') as SpecialQtyCompleted " & Environment.NewLine
                strSql &= ",UpdateDate as 'Last Update Date', C.User_FullName as 'Last Update User','' as History,'' as Comment,'' as HistUpdate,'' as HistUpdateUser" & Environment.NewLine
                strSql &= ",AFSPQTY_ID" & Environment.NewLine
                ' strSql &= ",SpecialShippedQty_Date,D.User_FullName as 'SpecialShippedQty Update User',AFSPQTY_ID"
                strSql &= " FROM tamsforecastedneed_special  A" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency B ON A.PSSI_Freq_ID = B.Freq_ID " & Environment.NewLine
                strSql &= " INNER JOIN security.tusers C ON A.UpdateUserID = C.User_ID " & Environment.NewLine
                strSql &= " LEFT JOIN  security.tusers D ON A.SpecialShippedQty_UserID= D.User_ID" & Environment.NewLine
                If bIncludingHistory Then
                    strSql &= " WHERE A.Cust_ID = " & iCustID & " AND A.Loc_ID = " & iLocID & " & Environment.NewLine"
                Else
                    strSql &= " WHERE A.Cust_ID = " & iCustID & " AND A.Loc_ID = " & iLocID & " AND A.SpecialQtyCompleted=0" & Environment.NewLine
                End If
                dt = Me.objMisc.GetDataTable(strSql)

                For Each row In dt.Rows
                    strSql = "SELECT A.*,B.User_FullName FROM tamsforecastedneed_special_log A " & Environment.NewLine
                    strSql &= " LEFT JOIN  security.tusers B ON A.UpdateUserID= B.User_ID" & Environment.NewLine
                    strSql &= " WHERE AFSPQTY_ID = " & row("AFSPQTY_ID")
                    dt2 = Me.objMisc.GetDataTable(strSql)

                    strHistory = "" : strComment = "" : strUserUpdateName = "" : strUserUpdatetime = ""
                    For Each row2 In dt2.Rows
                        If strHistory.Length = 0 Then strHistory = row2("HistoryQty") Else strHistory &= strS & row2("HistoryQty")
                        If strComment.Length = 0 Then strComment = row2("LogType") & ":  " & row2("Comment") Else strComment &= strS & row2("LogType") & ":  " & row2("Comment")
                        If strUserUpdatetime.Length = 0 Then strUserUpdatetime = row2("UpdateDate") Else strUserUpdatetime &= strS & row2("UpdateDate")
                        If strUserUpdateName.Length = 0 Then strUserUpdateName = row2("User_FullName") Else strUserUpdateName &= strS & row2("User_FullName")
                        row.BeginEdit()
                        row("History") = strHistory : row("Comment") = strComment
                        row("HistUpdate") = strUserUpdatetime : row("HistUpdateUser") = strUserUpdateName
                        row.AcceptChanges()
                    Next
                    dt2 = Nothing
                Next

                Return dt


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function DeleteAMSForcast_UnwantedData(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strYearWeekStartDate As String) As Integer
            Dim strSQL As String = ""
            Dim i As Integer = 0

            Try
                'delete if any
                'strSql = "Delete from tamsforecastedneed where yearWeekStartDate >='" & strYearWeekStartDate & "' and not SpecialRequestedQty>0 and Cust_ID=" & iCustID & ";"
                strSQL = "Delete from tamsforecastedneed where yearWeekStartDate >='" & strYearWeekStartDate & "' and Cust_ID=" & iCustID & " AND Loc_ID = " & iLocID & ";"

                i = Me.objMisc.ExecuteNonQuery(strSQL)

                ''Reset if any
                'strSQL = "Update tamsforecastedneed set qty=0 where yearWeekStartDate >='" & strYearWeekStartDate & "' and Cust_ID=" & iCustID & ";"
                'i = Me.objMisc.ExecuteNonQuery(strSQL)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************
        Public Function UpdateAMSForcast_SpecialRequestQty(ByVal iCustID As Integer, _
                                                           ByVal iLocID As Integer, _
                                                           ByVal iQty As Integer, _
                                                           ByVal iAFSPQTYID As Integer, _
                                                           ByVal strComment As String, _
                                                           ByVal strUpdateDatetime As String, _
                                                           ByVal iUserID As Integer) As Integer
            Dim strSQL As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim row As DataRow
            Dim iCurrentSpecialRequestedQty As Integer
            Dim strLogType As String = "Changed Qty"
            Try
                strSQL = "SELECT * from tamsforecastedneed_special where AFSPQTY_ID=" & iAFSPQTYID
                dt = Me.objMisc.GetDataTable(strSQL)

                If dt.Rows.Count = 1 Then 'must be 1 row
                    For Each row In dt.Rows
                        If row("SpecialQtyCompleted") = 1 Then
                            Throw New Exception("Already closed. Can't change.")
                        Else
                            If row("SpecialShippedQty") < iQty Then
                                iCurrentSpecialRequestedQty = row("SpecialRequestedQty")

                                strSQL = "UPDATE tamsforecastedneed_special SET SpecialRequestedQty=" & iQty & _
                                " WHERE AFSPQTY_ID=" & iAFSPQTYID
                                i = Me.objMisc.ExecuteNonQuery(strSQL)


                                strSQL = "INSERT INTO tamsforecastedneed_special_log (AFSPQTY_ID,HistoryQty,Comment,UpdateDate,UpdateUserID,LogType)" & _
                                                            " VALUES (" & iAFSPQTYID & "," & iCurrentSpecialRequestedQty & _
                                                            ",'" & strComment.Replace("'", "''") & "','" & strUpdateDatetime & _
                                                            "'," & iUserID & ",'" & strLogType & "');"
                                i += Me.objMisc.ExecuteNonQuery(strSQL)
                            Else
                                Throw New Exception("Can't change it. SpecialRequestedQty must be greater than SpecialShippedQty.")
                            End If
                        End If
                    Next
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Can't change it. The qty has been filled and completed.")
                Else
                    Throw New Exception("Can't find it in database.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************************************

#Region "Forecasted vs Shipments"
        '*******************************************************************************************************************
        Public Function getDockShippedData(ByVal strCustIDs As String, ByVal strBeginDate As String, ByVal strEndDate As String) As DataTable
            'Master data: dockshipped

            Dim strSQL As String = ""
            ' Dim dt, dt2 As DataTable
            ' Dim dt, dtFinal As DataTable


            Try
                strSQL = "select E.Cust_Name1 as 'Customer',D.Loc_Name as 'Location,'' as 'Freq_Code',B.Model_Desc as 'Model'" & Environment.NewLine
                strSQL &= " ,I.freq_Number as 'Frequency',H.baud_Number as 'Baud_Rate','' as 'Space1'" & Environment.NewLine
                strSQL &= " ,0 as 'wkForecast',0 as 'wkSpecialQty', 0 as 'wkActuals',0 as 'wkVariance','' as 'Space2'" & Environment.NewLine
                strSQL &= " ,0 as 'mnForecast',0 as 'mnSpecialQty', count(*) as 'mnActuals',0 as 'mnVariance','' as 'Space3'" & Environment.NewLine
                strSQL &= " ,0 as 'Produced_NotYetShipped',0 as 'WIP_AQL_Passed',0 as 'Net_Variance'" & Environment.NewLine
                strSQL &= " ,E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID,Concat_WS('_',E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID) as 'NewUniqueID'" & Environment.NewLine
                strSQL &= " from tdevice A" & Environment.NewLine
                strSQL &= " inner join tmodel B on A.model_ID=B.Model_ID" & Environment.NewLine
                strSQL &= " inner join tmessdata C on A.device_ID=C.device_ID" & Environment.NewLine
                strSQL &= " inner join tlocation D on A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tcustomer E on D.Cust_ID=E.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tpallett F on A.Pallett_ID=F.Pallett_ID" & Environment.NewLine
                strSQL &= " inner join tpackingslip G on F.pkslip_ID=G.pkslip_ID" & Environment.NewLine
                strSQL &= " inner join lbaud H on C.baud_ID=H.baud_ID" & Environment.NewLine
                strSQL &= " inner join lfrequency I on C.freq_ID=I.freq_ID" & Environment.NewLine
                strSQL &= " where D.Cust_ID in (" & strCustIDs & ") and F.Pallet_ShipType=0" & Environment.NewLine
                strSQL &= " and  G.pkslip_CreateDT between '" & strBeginDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSQL &= " group by E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID;" & Environment.NewLine

                'strSQL = "select E.Cust_Name1 as 'Customer','' as 'Freq_Code',B.Model_Desc as 'Model'" & Environment.NewLine
                'strSQL &= " ,I.freq_Number as 'Frequency',H.baud_Number as 'Baud_Rate','' as 'Space1'" & Environment.NewLine
                'strSQL &= " ,0 as 'wkForecast',0 as wkSpecialQty, 0 as 'wkActuals',0 as 'wkVariance','' as 'Space2'" & Environment.NewLine
                'strSQL &= " ,0 as 'mnForecast',0 as mnSpecialQty, count(*) as 'mnActuals',0 as 'mnVariance','' as 'Space3'" & Environment.NewLine
                'strSQL &= " ,0 as 'Produced_NotYetShipped',0 as 'WIP_AQL_Passed',0 as 'Net_Variance'" & Environment.NewLine
                'strSQL &= " ,E.Cust_ID,B.Model_ID,I.Freq_ID,H.baud_ID,'' as 'NewUniqueID','' as 'Model_IDs','' as 'mnActuals_Grp'" & Environment.NewLine
                'strSQL &= ",'' as 'Count_Grp'" & Environment.NewLine
                'strSQL &= " from tdevice A" & Environment.NewLine
                'strSQL &= " inner join tmodel B on A.model_ID=B.Model_ID" & Environment.NewLine
                'strSQL &= " inner join tmessdata C on A.device_ID=C.device_ID" & Environment.NewLine
                'strSQL &= " inner join tlocation D on A.Loc_ID=D.Loc_ID" & Environment.NewLine
                'strSQL &= " inner join tcustomer E on D.Cust_ID=E.Cust_ID" & Environment.NewLine
                'strSQL &= " inner join tpallett F on A.Pallett_ID=F.Pallett_ID" & Environment.NewLine
                'strSQL &= " inner join tpackingslip G on F.pkslip_ID=G.pkslip_ID" & Environment.NewLine
                'strSQL &= " left join lbaud H on C.baud_ID=H.baud_ID" & Environment.NewLine
                'strSQL &= " left join lfrequency I on C.freq_ID=I.freq_ID" & Environment.NewLine
                'strSQL &= " where D.Cust_ID in (" & strCustIDs & ") and F.Pallet_ShipType=0" & Environment.NewLine
                'strSQL &= " and  G.pkslip_CreateDT between '" & strBeginDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                'strSQL &= " group by E.Cust_ID,B.Model_ID,I.Freq_ID,H.baud_ID;" & Environment.NewLine

                Return Me.objMisc.GetDataTable(strSQL)

                'If dt.Rows.Count > 0 Then
                '    dtFinal = UpdateModel(dt, TriState.False)
                '    Return dtFinal
                'Else
                '    Return dt
                'End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function getAllWeeksOfMonth_ForecatedNeedData(ByVal strCustIDs As String, ByVal strBeginYrWkStartDate As String, ByVal strEndYrWkStartDate As String) As DataTable
            Dim strSQL As String = ""
            Dim dt As DataTable

            Try
                strSQL = "select B.Cust_Name1 as 'Customer',A.AMS_Freq as 'Freq_Code',F.Model_Desc as 'Model'" & Environment.NewLine
                strSQL &= " ,D.freq_Number as 'Frequency',E.baud_Number as 'Baud_Rate','' as 'Space1'" & Environment.NewLine
                strSQL &= " ,0 as 'wkForecast',0 as 'wkSpecialQty', 0 as 'wkActuals',0 as 'wkVariance','' as 'Space2'" & Environment.NewLine
                strSQL &= " ,0 as 'mnForecast',0 as 'mnSpecialQty', 0 as 'mnActuals',0 as 'mnVariance','' as 'Space3'" & Environment.NewLine
                strSQL &= " ,0 as 'Produced_NotYetShipped',0 as 'WIP_AQL_Passed',0 as 'Net_Variance'" & Environment.NewLine
                strSQL &= " ,A.Cust_ID,A.PSSI_Model_ID as 'Model_ID',D.Freq_ID,E.baud_ID" & Environment.NewLine
                strSQL &= " ,Concat_WS('_',A.Cust_ID, A.Loc_ID, A.PSSI_Model_ID,D.Freq_ID,E.baud_ID) as 'NewUniqueID'" & Environment.NewLine
                strSQL &= "  from tamsForecastedNeed A" & Environment.NewLine
                strSQL &= "  inner join tmodel F on A.PSSI_Model_ID=F.Model_ID" & Environment.NewLine
                strSQL &= "  inner join tcustomer B on A.Cust_ID=B.Cust_ID" & Environment.NewLine
                strSQL &= "  inner join tlocation F on A.Loc_ID=B.Loc_ID" & Environment.NewLine
                strSQL &= "  inner join lfrequency D on A.PSSI_freq_ID=D.freq_ID" & Environment.NewLine
                strSQL &= "  inner join lbaud E on A.PSSI_baud_ID=E.baud_ID" & Environment.NewLine
                strSQL &= "  where  B.Cust_ID in (" & strCustIDs & ") and YearWeekStartDate between '" & strBeginYrWkStartDate & " 00:00:00' and '" & strEndYrWkStartDate & " 00:00:00';" & Environment.NewLine


                'strSQL = "select B.Cust_Name1 as 'Customer',A.AMS_Freq as 'Freq_Code',A.AMS_Model as Model" & Environment.NewLine
                'strSQL &= "   ,D.freq_Number as 'Frequency',E.baud_Number as 'Baud_Rate','' as 'Space1'" & Environment.NewLine
                'strSQL &= "   ,0 as 'wkForecast',0 as 'wkSpecialQty', 0 as 'wkActuals',0 as 'wkVariance','' as 'Space2'" & Environment.NewLine
                'strSQL &= "   ,0 as 'mnForecast',0 as 'mnSpecialQty', 0 as 'mnActuals',0 as 'mnVariance','' as 'Space3'" & Environment.NewLine
                'strSQL &= "   ,0 as 'Produced_NotYetShipped',0 as 'WIP_AQL_Passed',0 as 'Net_Variance'" & Environment.NewLine
                'strSQL &= "   ,A.Cust_ID,0 as 'Model_ID',D.Freq_ID,E.baud_ID" & Environment.NewLine
                'strSQL &= "   ,Concat_WS('_',A.Cust_ID, trim(A.AMS_Model),A.PSSI_Freq_ID,A.PSSI_baud_ID) as 'NewUniqueID'" & Environment.NewLine
                'strSQL &= "   ,'' as 'Model_IDs','' as 'mnActuals_Grp','' as 'Count_Grp'" & Environment.NewLine
                'strSQL &= "  from tamsForecastedNeed A" & Environment.NewLine
                'strSQL &= "  inner join tcustomer B on A.Cust_ID=B.Cust_ID" & Environment.NewLine
                'strSQL &= "  inner join lfrequency D on A.PSSI_freq_ID=D.freq_ID" & Environment.NewLine
                'strSQL &= "  inner join lbaud E on A.PSSI_baud_ID=E.baud_ID" & Environment.NewLine
                'strSQL &= "  where  B.Cust_ID in (" & strCustIDs & ") and YearWeekStartDate between '" & strBeginYrWkStartDate & " 00:00:00' and '" & strEndYrWkStartDate & " 00:00:00';" & Environment.NewLine

                dt = Me.objMisc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function UpdateModel(ByVal dt As DataTable, ByVal bIsProduced_NotYetShipped As TriState) As DataTable
            'NO NEED THIS. WE JUST USE PSSI MODEL DESC 2014-08-15

            '1. Update dt.model by using tcustmodel_pssmodel_map.cust_model_number.
            '2. Regroup data

            Dim strSQL As String = ""
            Dim dt2, dtFinal As DataTable
            Dim filteredRows() As DataRow
            Dim row, row2 As DataRow
            Dim strS As String = "", strV As String = ""
            Dim arrLstUniqueIDs As New ArrayList()
            Dim strExpression, strCol As String
            Dim i, k, iSum As Integer

            Try

                'Update dt.model by using tcustmodel_pssmodel_map.cust_model_number.
                For Each row In dt.Rows
                    strSQL = "Select * from tcustmodel_pssmodel_map where cust_id=" & row("Cust_ID") & " and Model_ID=" & row("Model_ID")
                    dt2 = Me.objMisc.GetDataTable(strSQL)
                    For Each row2 In dt2.Rows 'should be one row if any
                        If Not row2.IsNull("cust_model_number") Then
                            strS = row2("cust_model_number")
                            If strS.Trim.Length > 0 Then
                                row("Model") = strS 'Replace model desc with tcustmodel_pssmodel_map.cust_model_number
                            End If
                        End If
                    Next
                Next
                dt.AcceptChanges()

                'Update newUniqueID col and Get unique  newUniqueID 
                For Each row In dt.Rows
                    strS = row("Cust_ID") & "_" & row("Model").ToString.Trim.Replace("'", "''") & "_" & row("Freq_ID") & "_" & row("Baud_ID")
                    row("NewUniqueID") = strS
                    If Not arrLstUniqueIDs.Contains(row("NewUniqueID")) Then
                        arrLstUniqueIDs.Add(row("NewUniqueID"))
                    End If
                Next
                dt.AcceptChanges()
                'System.Windows.Forms.MessageBox.Show("arrLstUniqueIDs.Count =" & arrLstUniqueIDs.Count)

                'RE-GROUP DATA mnActuals_Grp
                dtFinal = dt.Clone
                Select Case bIsProduced_NotYetShipped
                    Case TriState.True
                        strCol = "Produced_NotYetShipped"
                    Case TriState.False
                        strCol = "mnActuals"
                    Case TriState.UseDefault
                        strCol = "WIP_AQL_Passed"
                End Select

                For k = 0 To arrLstUniqueIDs.Count - 1 'each unique model
                    strExpression = "NewUniqueID='" & arrLstUniqueIDs(k) & "'"
                    filteredRows = dt.Select(strExpression)
                    If filteredRows.Length > 1 Then
                        i = 0 : strS = "" : strV = "" : iSum = 0
                        For Each row2 In filteredRows
                            If Not row2.IsNull(strCol) Then 'compute total
                                If IsNumeric(row2(strCol)) Then iSum += row2(strCol)
                            End If
                            If i = 0 Then 'get model_Ids
                                strS = row2("Model_ID").ToString : strV = row2(strCol).ToString
                            Else
                                strS &= "_" & row2("Model_ID").ToString : strV &= "_" & row2(strCol).ToString
                            End If
                            i += 1
                        Next
                        For Each row2 In filteredRows 'update firts row: clear molde_Id and update model_IDs and mnActuals, import to dtfinal
                            row2("Model_ID") = 0 : row2("Model_IDs") = strS : row2("mnActuals_Grp") = strV : row2(strCol) = iSum
                            row2("Count_Grp") = filteredRows.Length
                            dtFinal.ImportRow(row2)
                            Exit For
                        Next
                    Else
                        For Each row2 In filteredRows 'should be 1 row
                            row2("Model_IDs") = row2("Model_ID").ToString : row2("mnActuals_Grp") = row2(strCol)
                            row2("Count_Grp") = filteredRows.Length
                            dtFinal.ImportRow(row2)
                        Next
                    End If
                Next
                dtFinal.AcceptChanges()
                'System.Windows.Forms.MessageBox.Show("dtFinal.Rows.Count =" & dtFinal.Rows.Count)

                Return dtFinal

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Sub AddForecastedNotIncludedInDockShip(ByRef dtDockShipped As DataTable, ByVal dtAllWeekOfMonth_ForecastedNeed As DataTable)
            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim arrLstKeys As New ArrayList()
            Dim i As Integer

            Try
                For Each row In dtDockShipped.Rows
                    arrLstKeys.Add(row("NewUniqueID")) 'NewUniqueID is unique in dtDockShipped (Group By)
                Next

                For Each row In dtAllWeekOfMonth_ForecastedNeed.Rows
                    If Not arrLstKeys.Contains(row("NewUniqueID")) Then
                        arrLstKeys.Add(row("NewUniqueID"))
                        dtDockShipped.ImportRow(row)
                    End If
                Next


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Public Function getProducedButNotYetShippedData(ByVal strCustIDs As String) As DataTable
            'Public Function getProducedButNotYetShippedData(ByVal strCustIDs As String, ByVal strBeginDate As String, ByVal strEndDate As String) As DataTable

            Dim strSQL As String = ""
            ' Dim dt, dtFinal As DataTable

            Try
                strSQL = "Select E.Cust_Name1 as 'Customer',D.Loc_Name as 'Location','' as 'Freq_Code',B.Model_Desc as 'Model'" & Environment.NewLine
                strSQL &= " ,I.freq_Number as 'Frequency',H.baud_Number as 'Baud_Rate'" & Environment.NewLine
                strSQL &= " ,count(*) as 'Produced_NotYetShipped'" & Environment.NewLine
                strSQL &= " ,E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID" & Environment.NewLine
                strSQL &= " ,Concat_WS('_',E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID) as 'NewUniqueID',0 as 'UpdatedIntoMaster'" & Environment.NewLine
                strSQL &= " ,Concat_WS('_',E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID) as 'UniqueID'" & Environment.NewLine
                strSQL &= " from tdevice A" & Environment.NewLine
                strSQL &= " inner join tmodel B on A.model_ID=B.Model_ID" & Environment.NewLine
                strSQL &= " inner join tmessdata C on A.device_ID=C.device_ID" & Environment.NewLine
                strSQL &= " inner join tlocation D on A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tcustomer E on D.Cust_ID=E.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tpallett F on A.Pallett_ID=F.Pallett_ID" & Environment.NewLine
                strSQL &= " inner join lbaud H on C.baud_ID=H.baud_ID" & Environment.NewLine
                strSQL &= " inner join lfrequency I on C.freq_ID=I.freq_ID" & Environment.NewLine
                strSQL &= " where D.Cust_ID in (" & strCustIDs & ") and F.Pallet_ShipType=0 and F.pkSlip_ID is null" & Environment.NewLine
                ' strSQL &= " and A.Device_DateShip between '" & strBeginDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSQL &= " group by E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID;" & Environment.NewLine

                Return Me.objMisc.GetDataTable(strSQL)

                'strSQL = "Select E.Cust_Name1 as 'Customer','' as 'Freq_Code',B.Model_Desc as 'Model'" & Environment.NewLine
                'strSQL &= " ,I.freq_Number as 'Frequency',H.baud_Number as 'Baud_Rate'" & Environment.NewLine
                'strSQL &= " ,count(*) as 'Produced_NotYetShipped'" & Environment.NewLine
                'strSQL &= " ,E.Cust_ID,B.Model_ID,I.Freq_ID,H.baud_ID,'' as 'NewUniqueID','' as 'Model_IDs','' as 'mnActuals_Grp'" & Environment.NewLine
                'strSQL &= ",'' as 'Count_Grp',0 as 'UpdatedIntoMaster'" & Environment.NewLine
                'strSQL &= " from tdevice A" & Environment.NewLine
                'strSQL &= " inner join tmodel B on A.model_ID=B.Model_ID" & Environment.NewLine
                'strSQL &= " inner join tmessdata C on A.device_ID=C.device_ID" & Environment.NewLine
                'strSQL &= " inner join tlocation D on A.Loc_ID=D.Loc_ID" & Environment.NewLine
                'strSQL &= " inner join tcustomer E on D.Cust_ID=E.Cust_ID" & Environment.NewLine
                'strSQL &= " inner join tpallett F on A.Pallett_ID=F.Pallett_ID" & Environment.NewLine
                'strSQL &= " left join lbaud H on C.baud_ID=H.baud_ID" & Environment.NewLine
                'strSQL &= " left join lfrequency I on C.freq_ID=I.freq_ID" & Environment.NewLine
                'strSQL &= " where D.Cust_ID in (" & strCustIDs & ") and F.Pallet_ShipType=0 and F.pkSlip_ID is null" & Environment.NewLine
                'strSQL &= " and A.Device_DateShip between '" & strBeginDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                'strSQL &= " group by E.Cust_ID,B.Model_ID,I.Freq_ID,H.baud_ID;" & Environment.NewLine

                'dt = Me.objMisc.GetDataTable(strSQL)

                'If dt.Rows.Count > 0 Then
                '    dtFinal = UpdateModel(dt, TriState.True)
                '    Return dtFinal
                'Else
                '    Return dt
                'End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function getWIPWithAQLPassedData(ByVal strCustIDs As String) As DataTable
            'Public Function getWIPWithAQLPassedData(ByVal strCustIDs As String, ByVal strBeginDate As String, ByVal strEndDate As String) As DataTable

            Dim strSQL As String = ""
            'Dim dt, dtFinal As DataTable

            Try
                strSQL = "select distinct E.Cust_Name1 as 'Customer','' as 'Freq_Code',B.Model_Desc as 'Model'" & Environment.NewLine
                strSQL &= "  ,I.freq_Number as 'Frequency',H.baud_Number as 'Baud_Rate'" & Environment.NewLine
                strSQL &= "  , 1 as 'WIP_AQL_Passed'" & Environment.NewLine
                strSQL &= "  ,E.Cust_ID,B.Model_ID,I.Freq_ID,H.baud_ID,A.device_ID" & Environment.NewLine
                strSQL &= "  ,Concat_WS('_',E.Cust_ID,D.Loc_ID,B.Model_ID,I.Freq_ID,H.baud_ID) as 'NewUniqueID',0 as 'UpdatedIntoMaster'" & Environment.NewLine
                strSQL &= "  from tdevice A" & Environment.NewLine
                strSQL &= "  inner join tmodel B on A.model_ID=B.Model_ID" & Environment.NewLine
                strSQL &= "  inner join tmessdata C on A.device_ID=C.device_ID" & Environment.NewLine
                strSQL &= "  inner join tlocation D on A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSQL &= "  inner join tcustomer E on D.Cust_ID=E.Cust_ID" & Environment.NewLine
                strSQL &= "  inner join tqc F on A.Device_ID=F.Device_ID and F.QCType_ID=4 and F.QCResult_ID=1" & Environment.NewLine
                strSQL &= "  inner join lbaud H on C.baud_ID=H.baud_ID" & Environment.NewLine
                strSQL &= "  inner join lfrequency I on C.freq_ID=I.freq_ID" & Environment.NewLine
                strSQL &= "   where D.Cust_ID in (" & strCustIDs & ")" & Environment.NewLine ' and A.Device_DateRec between  '" & strBeginDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSQL &= "   and  A.Device_DateShip is null;" & Environment.NewLine

                Return Me.objMisc.GetDataTable(strSQL)

                'strSQL = "select distinct E.Cust_Name1 as 'Customer','' as 'Freq_Code',B.Model_Desc as 'Model'" & Environment.NewLine
                'strSQL &= "   ,I.freq_Number as 'Frequency',H.baud_Number as 'Baud_Rate'" & Environment.NewLine
                'strSQL &= "   , 1 as 'WIP_AQL_Passed'" & Environment.NewLine
                'strSQL &= "   ,E.Cust_ID,B.Model_ID,I.Freq_ID,H.baud_ID,A.device_ID,'' as 'NewUniqueID','' as 'Model_IDs','' as 'mnActuals_Grp'" & Environment.NewLine
                'strSQL &= "    ,'' as 'Count_Grp',0 as 'UpdatedIntoMaster'" & Environment.NewLine
                'strSQL &= "   from tdevice A" & Environment.NewLine
                'strSQL &= "   inner join tmodel B on A.model_ID=B.Model_ID" & Environment.NewLine
                'strSQL &= "   inner join tmessdata C on A.device_ID=C.device_ID" & Environment.NewLine
                'strSQL &= "   inner join tlocation D on A.Loc_ID=D.Loc_ID" & Environment.NewLine
                'strSQL &= "   inner join tcustomer E on D.Cust_ID=E.Cust_ID" & Environment.NewLine
                'strSQL &= "   inner join tqc F on A.Device_ID=F.Device_ID and F.QCType_ID=4 and F.QCResult_ID=1" & Environment.NewLine
                'strSQL &= "   left join lbaud H on C.baud_ID=H.baud_ID" & Environment.NewLine
                'strSQL &= "   left join lfrequency I on C.freq_ID=I.freq_ID" & Environment.NewLine
                'strSQL &= "   where D.Cust_ID in (" & strCustIDs & ") and A.Device_DateRec between  '" & strBeginDate & " 00:00:00' and '" & strEndDate & " 23:59:59'" & Environment.NewLine
                'strSQL &= "   and  A.Device_DateShip is null;" & Environment.NewLine

                'dt = Me.objMisc.GetDataTable(strSQL)

                'If dt.Rows.Count > 0 Then
                '    dt.Columns.Remove("Device_ID")
                '    dtFinal = UpdateModel(dt, TriState.UseDefault)
                '    Return dtFinal
                'Else
                '    Return dt
                'End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function getForecastedData(ByVal strCustModelFreBaud As String, ByVal strDate As String) As DataTable
            'Public Function getForecastedData(ByVal iCustID As Integer, ByVal strDate As String, _
            '                                  ByVal strModel As String, ByVal iFreqID As Integer, _
            '                                  ByVal iBaudID As Integer) As DataTable
            Dim strSQL As String = ""
            Dim dt As DataTable

            Try

                strSQL = " select B.Cust_Name1 as 'Customer',A.AMS_Model as Model,A.AMS_Freq as 'Freq_Code'" & Environment.NewLine
                strSQL &= " ,D.freq_Number as 'Frequency',E.baud_Number as 'Baud_Rate',A.Qty as 'Forecast',A.SpecialRequestedQty" & Environment.NewLine
                strSQL &= " ,A.Cust_ID,A.PSSI_Model_ID as 'Model_ID',D.Freq_ID,E.baud_ID,A.YearWeekStartDate" & Environment.NewLine
                strSQL &= "  from tamsForecastedNeed A" & Environment.NewLine
                strSQL &= "  inner join tcustomer B on A.Cust_ID=B.Cust_ID" & Environment.NewLine
                strSQL &= "  inner join tlocation F on A.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSQL &= "  inner join lfrequency D on A.PSSI_freq_ID=D.freq_ID" & Environment.NewLine
                strSQL &= "  inner join lbaud E on A.PSSI_baud_ID=E.baud_ID" & Environment.NewLine
                strSQL &= "  where Concat_WS('_',A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,D.Freq_ID,E.baud_ID) ='" & strCustModelFreBaud & "'" & Environment.NewLine
                strSQL &= "  and A.YearWeekStartDate='" & strDate & " 00:00:00';" & Environment.NewLine

                'strSQL = "select B.Cust_Name1 as 'Customer',A.AMS_Model as Model,A.AMS_Freq as 'Freq_Code'" & Environment.NewLine
                'strSQL &= " ,D.freq_Number as 'Frequency',E.baud_Number as 'Baud_Rate',A.Qty as 'Forecast',A.SpecialRequestedQty" & Environment.NewLine
                'strSQL &= " ,A.Cust_ID,D.Freq_ID,E.baud_ID,A.YearWeekStartDate" & Environment.NewLine
                'strSQL &= "  from tamsForecastedNeed A" & Environment.NewLine
                'strSQL &= "  inner join tcustomer B on A.Cust_ID=B.Cust_ID" & Environment.NewLine
                'strSQL &= "  inner join lfrequency D on A.PSSI_freq_ID=D.freq_ID" & Environment.NewLine
                'strSQL &= "  inner join lbaud E on A.PSSI_baud_ID=E.baud_ID" & Environment.NewLine
                'strSQL &= "  where A.Cust_ID=" & iCustID & " AND A.AMS_Model='" & strModel & "'and D.Freq_ID=" & iFreqID & " and E.baud_ID=" & iBaudID & Environment.NewLine
                'strSQL &= "  and A.YearWeekStartDate='" & strDate & " 00:00:00';" & Environment.NewLine


                dt = Me.objMisc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*********************
        Public Function getCustModelFreqBaud(ByVal strDevices As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Concat_WS('_',D.cust_id,C.Loc_ID,A.model_id,B.freq_id,B.baud_id) AS UniqueID" & Environment.NewLine
                strSQL &= " ,D.cust_id,C.Loc_ID,A.model_id,B.freq_id,B.baud_id,D.cust_name1,C.Loc_Name" & Environment.NewLine
                strSQL &= ",E.model_desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSQL &= " FROM tdevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tmessdata B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tlocation C ON A.loc_ID=C.loc_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tcustomer D ON C.cust_ID=D.cust_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmodel E ON A.model_ID=E.model_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lfrequency F ON B.freq_id=F.freq_id" & Environment.NewLine
                strSQL &= " INNER JOIN lbaud G ON B.baud_id=G.baud_id" & Environment.NewLine
                strSQL &= " WHERE A.device_ID in (" & strDevices & ")" & Environment.NewLine
                strSQL &= " GROUP BY D.cust_id,C.Loc_ID,A.model_id,B.freq_id,B.baud_id;" & Environment.NewLine

                Return Me.objMisc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************
        Public Function getRegularInBoxQty(ByVal strCustIDs As String, Optional ByVal strCustModelFreqBaud As String = "") As DataTable
            Dim strSQL As String

            Try
                'Regular FC in boxes (open or closed), GROUP BY
                strSQL = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSQL &= " ,Count(*) as RegularQty,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSQL &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSQL &= " FROM  tpallett A" & Environment.NewLine
                strSQL &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tcustomer E ON A.Cust_ID =E.Cust_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tlocation H ON A.Loc_ID =H.Loc_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lfrequency F ON C.Freq_ID=F.Freq_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lbaud G ON C.Baud_ID=G.Baud_ID" & Environment.NewLine
                strSQL &= " WHERE A.Pallet_ShipType=0 AND A.Pallet_Invalid = 0" & Environment.NewLine
                strSQL &= " AND B.device_dateship is null AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                strSQL &= " AND C.AFSPQTY_ID = 0" & Environment.NewLine
                If strCustModelFreqBaud.Trim.Length > 0 Then strSQL &= " AND  Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) ='" & strCustModelFreqBaud & "'" & Environment.NewLine
                strSQL &= " GROUP BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID;"
                Return Me.objMisc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************
        Public Function getRegularShippedQty(ByVal strCustIDs As String, ByVal strBeginDate As String, ByVal strEndDate As String, Optional ByVal strCustModelFreqBaud As String = "") As DataTable
            Dim strSQL As String

            Try
                'Regular FC shipped, GROUP BY
                strSQL = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSQL &= " ,Count(*) as RegularQty,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSQL &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSQL &= " FROM  tpallett A" & Environment.NewLine
                strSQL &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tcustomer E ON A.Cust_ID =E.Cust_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tlocation H ON A.Loc_ID =H.Loc_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lfrequency F ON C.Freq_ID=F.Freq_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lbaud G ON C.Baud_ID=G.Baud_ID" & Environment.NewLine
                strSQL &= " WHERE A.Pallet_ShipType=0 AND A.Pallet_Invalid = 0" & Environment.NewLine
                strSQL &= " AND B.device_dateship BETWEEN '" & strBeginDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSQL &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                strSQL &= " AND C.AFSPQTY_ID = 0" & Environment.NewLine
                If strCustModelFreqBaud.Trim.Length > 0 Then strSQL &= " AND  Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) ='" & strCustModelFreqBaud & "'" & Environment.NewLine
                strSQL &= " GROUP BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID;"
                Return Me.objMisc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function MonthWeeksDays_TableDefinition() As DataTable
            Dim dTB As New DataTable()
            dTB.Columns.Add("ID", GetType(Integer))
            dTB.Columns.Add("Year", GetType(Integer))
            dTB.Columns.Add("Month", GetType(Integer))
            dTB.Columns.Add("WeekIdx", GetType(Integer))
            dTB.Columns.Add("WeekDay", GetType(String))
            dTB.Columns.Add("WeekStartDate", GetType(Date))
            dTB.Columns.Add("Date", GetType(Date))
            dTB.Columns.Add("WeekForecast", GetType(Integer))
            dTB.Columns.Add("SpecialQty", GetType(Integer))
            Return dTB
        End Function

        '*******************************************************************************************************************
        Public Function getRequiredWorkingWeekDays() As ArrayList
            Dim arrList As New ArrayList()
            arrList.Add("Monday")
            arrList.Add("Tuesday")
            arrList.Add("Wednesday")
            arrList.Add("Thursday")
            Return arrList
        End Function

        '***************************************************************************************************************
        Private Function GetLastDayOfMonth2(ByVal aDate As DateTime) As Date
            Return New DateTime(aDate.Year, aDate.Month, DateTime.DaysInMonth(aDate.Year, aDate.Month))
        End Function

        '*******************************************************************************************************************
        Public Function CalMonthlyForecated(ByVal dDate As Date) As DataTable
            'One function to get month forecasted Qty 

            Dim currDate As Date = dDate.Date
            Dim wkBeginDate, wkEndDate, MonthWeeksBeginDate, MonthWeeksEndDate As Date
            Dim mnBeginDate, mnEndDate, tmpDate, wkStartDate, mnBeginYrWkStartDate, mnEndYrWkStartDate As Date
            Dim dayOfWeek As dayOfWeek
            Dim dtMonthWeeksDays_Forecasted, dtForecasted, dtAllCustModelFreqBaud_UnqiueAsOutput As DataTable
            Dim i, iWeekIdx, iWeekCount As Integer
            Dim strSQL As String
            Dim row, row2 As DataRow
            Dim iCurrentWkForecast As Integer = 0, iCurrentMonthForecast As Integer = 0, bFoundVal As Boolean = False
            Dim iCurrentWkSpecialQty As Integer = 0, iCurrentMonthSpecialQty As Integer = 0, bFoundVal2 As Boolean = False

            Try

                'Generate calendar month dates
                mnBeginDate = currDate.AddDays(1 - currDate.Day)
                mnEndDate = GetLastDayOfMonth2(currDate)


                'Determine week begin and end day for the month, and Current week begin and end dates
                Dim thisCulture = Globalization.CultureInfo.CurrentCulture
                dayOfWeek = thisCulture.Calendar.GetDayOfWeek(mnBeginDate)
                If Not dayOfWeek = System.DayOfWeek.Monday Then
                    If dayOfWeek = System.DayOfWeek.Sunday Then
                        MonthWeeksBeginDate = Generic.DateOfPreviousWeek(mnBeginDate, dayOfWeek.Monday, 1)
                    Else
                        MonthWeeksBeginDate = Generic.DateOfPreviousWeek(mnBeginDate, dayOfWeek.Monday, 0)
                    End If
                Else
                    MonthWeeksBeginDate = mnBeginDate
                End If
                dayOfWeek = thisCulture.Calendar.GetDayOfWeek(mnEndDate)
                If Not dayOfWeek = System.DayOfWeek.Sunday Then
                    MonthWeeksEndDate = Generic.DateOfPreviousWeek(mnEndDate, dayOfWeek.Monday, 0)
                    MonthWeeksEndDate = MonthWeeksEndDate.AddDays(6)
                Else
                    MonthWeeksEndDate = mnEndDate
                End If

                dayOfWeek = thisCulture.Calendar.GetDayOfWeek(currDate)
                If dayOfWeek = System.DayOfWeek.Sunday Then
                    wkBeginDate = Generic.DateOfPreviousWeek(currDate, dayOfWeek.Monday, 1)
                Else
                    wkBeginDate = Generic.DateOfPreviousWeek(currDate, dayOfWeek.Monday, 0)
                End If
                wkEndDate = wkBeginDate.AddDays(6)

                'Build days of the month which includes all full weeks
                dtMonthWeeksDays_Forecasted = MonthWeeksDays_TableDefinition()
                tmpDate = MonthWeeksBeginDate : i = 0
                Do While tmpDate <= MonthWeeksEndDate
                    i += 1
                    Dim rowNew As DataRow = dtMonthWeeksDays_Forecasted.NewRow
                    rowNew("ID") = i : rowNew("Year") = Year(tmpDate) : rowNew("Month") = Month(tmpDate)
                    rowNew("WeekDay") = thisCulture.Calendar.GetDayOfWeek(tmpDate) : rowNew("Date") = tmpDate
                    If i = 1 Then
                        iWeekIdx = 1 : wkStartDate = tmpDate : mnBeginYrWkStartDate = tmpDate
                    Else
                        If rowNew("WeekDay") = "Monday" Then iWeekIdx += 1 : wkStartDate = tmpDate : mnEndYrWkStartDate = tmpDate
                    End If
                    rowNew("WeekIdx") = iWeekIdx
                    rowNew("WeekStartDate") = wkStartDate
                    dtMonthWeeksDays_Forecasted.Rows.Add(rowNew)
                    tmpDate = tmpDate.AddDays(1)
                Loop
                iWeekCount = iWeekIdx
                'Return dtMonthWeeksDays_Forecasted

                strSQL = "select Distinct Concat_WS('_',B.Cust_ID,F.Loc_ID,C.Model_ID,D.Freq_ID,E.baud_ID) as 'NewUniqueID',0 as 'mnForecast',0 as 'mnSpecialQty',B.Cust_ID,C.Model_ID,D.Freq_ID,E.baud_ID" & Environment.NewLine
                strSQL &= ",B.Cust_Name1,C.Model_Desc,D.freq_Number,E.baud_Number" & Environment.NewLine
                strSQL &= " from tamsForecastedNeed A" & Environment.NewLine
                strSQL &= " inner join tcustomer B on A.Cust_ID=B.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tlocation F on A.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tmodel C on A.PSSI_Model_ID=C.Model_ID" & Environment.NewLine
                strSQL &= " inner join lfrequency D on A.PSSI_freq_ID=D.freq_ID" & Environment.NewLine
                strSQL &= " inner join lbaud E on A.PSSI_baud_ID=E.baud_ID" & Environment.NewLine
                strSQL &= " where A.YearWeekStartDate between '" & Format(MonthWeeksBeginDate, "yyyy-MM-dd") & " 00:00:00'" & Environment.NewLine
                strSQL &= " and  '" & Format(MonthWeeksEndDate, "yyyy-MM-dd") & " 23:59:59';" & Environment.NewLine

                'MessageBox.Show("MonthWeeksBeginDate=" & MonthWeeksBeginDate & "   MonthWeeksEndDate=" & MonthWeeksEndDate)

                dtAllCustModelFreqBaud_UnqiueAsOutput = Me.objMisc.GetDataTable(strSQL)
                ' Return dtAllCustModelFreqBaud_UnqiueAsOutput

                For Each row In dtAllCustModelFreqBaud_UnqiueAsOutput.Rows
                    If Trim(row("NewUniqueID")).Length > 0 Then  'valid ids
                        'initial 
                        For Each row2 In dtMonthWeeksDays_Forecasted.Rows 'reset
                            row2("WeekForecast") = DBNull.Value : row2("SpecialQty") = DBNull.Value : row2.AcceptChanges()
                        Next

                        'Week forecast
                        For Each row2 In dtMonthWeeksDays_Forecasted.Rows 'each day 
                            'dtForecasted = Me._objAMS.getForecastedData(row("Cust_ID"), Format(row2("WeekStartDate"), "yyyy-MM-dd"), row("Model"), row("Freq_ID"), row("Baud_ID"))
                            dtForecasted = getForecastedData(row("NewUniqueID"), Format(row2("WeekStartDate"), "yyyy-MM-dd"))
                            If dtForecasted.Rows.Count > 0 Then
                                row2("WeekForecast") = dtForecasted.Rows(0).Item("Forecast") : row2.AcceptChanges() 'forecast
                                row2("SpecialQty") = dtForecasted.Rows(0).Item("SpecialRequestedQty") : row2.AcceptChanges() 'SpecialRequestedQty
                            End If
                        Next

                        'Current month forecast and specialQty
                        bFoundVal = False : iCurrentMonthForecast = 0 : bFoundVal2 = False : iCurrentMonthSpecialQty = 0
                        getCurrentMonthForecastValue(mnBeginDate, mnEndDate, dtMonthWeeksDays_Forecasted, iWeekCount, bFoundVal, iCurrentMonthForecast, bFoundVal2, iCurrentMonthSpecialQty)
                        If bFoundVal Then
                            row("mnForecast") = iCurrentMonthForecast : row.AcceptChanges()
                        End If
                        If bFoundVal2 Then
                            row("mnSpecialQty") = iCurrentMonthSpecialQty : row.AcceptChanges()
                        End If
                    End If
                Next

                Return dtAllCustModelFreqBaud_UnqiueAsOutput

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*******************************************************************************************************************
        Public Function GetMonthlyForecasted(ByVal strCustIDs As String, ByVal dteToday As Date, _
                                             Optional ByVal iModelID As Integer = 0, Optional ByVal iFreqID As Integer = 0, _
                                             Optional ByVal iBaudID As Integer = 0, Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql ', strDateWeekStart, strDateWeekEnd As String
            'Dim iYear, iMonth As Integer
            'Dim dtFC As DataTable
            Dim strToday As String = "", strS As String = ""
            Dim dtTmp, dtRegularMonthFC As DataTable
            Dim dtSpecialMonthFC_Available As DataTable
            Dim dtSpecialMonthFC_Inbox As DataTable
            Dim dtSpecialMonthFC_Shipped As DataTable
            Dim dtOutput As DataTable
            Dim filteredRows() As DataRow
            Dim ds As New DataSet()
            Dim row As DataRow
            Dim strMonthBeginDate As String = "", strMonthEndDate As String = ""
            Dim arrlstUniqueIDs As New ArrayList()
            Dim iRowCount As Integer = 0, i As Integer = 0
            Dim iMyCustID As Integer = 0, iMyLocID As Integer = 0, iFCQty As Integer = 0
            Dim iMyModelID As Integer = 0, iMyFreqID As Integer = 0, iMyBaudID As Integer = 0
            Dim strArr()
            Dim bHasIt As Boolean

            Try

                strToday = Format(dteToday, "yyyy-MM-dd")

                'Regular FC
                strSql = "SELECT Distinct NewUniqueID as UniqueID , mnForecast, mnSpecialQty, A.Cust_ID, A.Loc_ID, A.Model_ID, A.Freq_ID, A.baud_ID" & Environment.NewLine
                strSql &= ",B.Cust_Name1, F.Loc_Name, C.Model_Desc, D.freq_Number, E.baud_Number" & Environment.NewLine
                strSql &= " FROM tamsforecastedneed_Month A " & Environment.NewLine
                strSql &= " INNER JOIN tcustomer B on A.Cust_ID = B.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation F on A.Loc_ID = F.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C on A.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency D on A.freq_ID = D.freq_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbaud E on A.baud_ID = E.baud_ID " & Environment.NewLine
                strSql &= " WHERE A.MonthWeekStartDate <='" & strToday & "' and A.MonthWeekEnddate >='" & strToday & "'" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND A.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND A.baud_ID = " & iBaudID & Environment.NewLine

                dtRegularMonthFC = Me.objMisc.GetDataTable(strSql)
                dtRegularMonthFC.TableName = "RegularFC" : ds.Tables.Add(dtRegularMonthFC)
                dtOutput = dtRegularMonthFC.Clone

                'Special FC Available
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,0 as mnForecast,SUM(A.SpecialRequestedQty) as SpecialRequestedQty,SUM(A.SpecialShippedQty) as SpecialShippedQty" & Environment.NewLine
                strSql &= " ,SUM(A.SpecialRequestedQty-A.SpecialShippedQty) as SpecialAvailableQty" & Environment.NewLine
                strSql &= " ,A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID as Model_ID,A.PSSI_Freq_ID as Freq_ID,A.PSSI_Baud_ID as baud_ID,B.Cust_Name1,C.Loc_Name,A.AMS_Model as Model_Desc" & Environment.NewLine
                strSql &= " ,A.AMS_Freq as freq_Number,AMS_Baud as baud_Number,COUNT(*) as RecCount" & Environment.NewLine
                strSql &= " FROM tamsforecastedneed_Special A" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer B on A.Cust_ID = B.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation C on A.Loc_ID = C.Loc_ID" & Environment.NewLine
                strSql &= " WHERE (A.SpecialRequestedQty-A.SpecialShippedQty)>0" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.PSSI_Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND A.PSSI_Freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND A.PSSI_baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID;" & Environment.NewLine

                dtSpecialMonthFC_Available = Me.objMisc.GetDataTable(strSql)
                dtSpecialMonthFC_Available.TableName = "SpecialFCAvailable" : ds.Tables.Add(dtSpecialMonthFC_Available)

                'Special FC in boxes (open or closed)
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSql &= " ,A.Cust_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " FROM  tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer E ON A.Cust_ID =E.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation H ON A.Loc_ID =H.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency F ON C.Freq_ID=F.Freq_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbaud G ON C.Baud_ID=G.Baud_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallet_ShipType=0 AND A.Pallet_Invalid = 0" & Environment.NewLine
                strSql &= " AND B.device_dateship is null AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND D.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND F.Freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND G.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND C.AFSPQTY_ID >0;" & Environment.NewLine

                dtSpecialMonthFC_Inbox = Me.objMisc.GetDataTable(strSql)
                dtSpecialMonthFC_Inbox.TableName = "SpecialFCInBox" : ds.Tables.Add(dtSpecialMonthFC_Inbox)

                'Month Begin Date and end date
                strSql = "select distinct MonthWeekStartDate,MonthWeekEnddate from tamsforecastedneed_month" & Environment.NewLine
                strSql &= " where MonthWeekStartDate <='" & strToday & "' and  MonthWeekEnddate >='" & strToday & "';" & Environment.NewLine
                dtTmp = Me.objMisc.GetDataTable(strSql)
                If dtTmp.Rows.Count > 0 Then
                    strMonthBeginDate = Format(CDate(dtTmp.Rows(0).Item("MonthWeekStartDate")), "yyyy-MM-dd")
                    strMonthEndDate = Format(CDate(dtTmp.Rows(0).Item("MonthWeekEnddate")), "yyyy-MM-dd")
                Else
                    Throw New Exception("System has failed to define month beginDate and EndDate for monthly forecast.")
                End If


                'Special FC shipped
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSql &= " ,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " FROM  tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer E ON A.Cust_ID =E.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation H ON A.Loc_ID =H.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency F ON C.Freq_ID=F.Freq_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbaud G ON C.Baud_ID=G.Baud_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallet_ShipType=0 AND A.Pallet_Invalid = 0" & Environment.NewLine
                strSql &= " AND B.device_dateship BETWEEN '" & strMonthBeginDate & " 00:00:00' AND '" & strMonthEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND D.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND F.Freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND G.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND C.AFSPQTY_ID >0;" & Environment.NewLine

                dtSpecialMonthFC_Shipped = Me.objMisc.GetDataTable(strSql)
                dtSpecialMonthFC_Shipped.TableName = "SpecialFCShipped" : ds.Tables.Add(dtSpecialMonthFC_Shipped)

                'Unique IDs
                dtTmp = Nothing : iRowCount = 0
                For Each dtTmp In ds.Tables
                    For Each row In dtTmp.Rows
                        If Not arrlstUniqueIDs.Contains(row("UniqueID")) Then
                            arrlstUniqueIDs.Add(row("UniqueID"))
                        End If
                    Next
                    iRowCount += dtTmp.Rows.Count
                Next

                'Retrun no data and validate data
                If iRowCount = 0 Then
                    Return dtOutput 'No data 
                ElseIf iRowCount > 0 AndAlso Not arrlstUniqueIDs.Count > 0 Then
                    Throw New Exception("System has failed to find unique IDs.")
                End If


                'Calculations
                For i = 0 To arrlstUniqueIDs.Count - 1
                    bHasIt = False : iFCQty = 0
                    strS = arrlstUniqueIDs(i) : strArr = strS.Split("_")
                    iMyCustID = strArr(0) : iMyLocID = strArr(1) : iMyModelID = strArr(2)
                    iMyFreqID = strArr(3) : iMyBaudID = strArr(4)

                    filteredRows = dtRegularMonthFC.Select("UniqueID='" & arrlstUniqueIDs(i) & "'")
                    If filteredRows.Length > 0 Then 'should be one row if any
                        For Each row In filteredRows
                            dtOutput.ImportRow(row) : bHasIt = True
                        Next
                    End If

                    'Available
                    filteredRows = dtSpecialMonthFC_Available.Select("UniqueID='" & arrlstUniqueIDs(i) & "'")
                    If filteredRows.Length > 0 Then 'should be one row if any
                        For Each row In filteredRows
                            iFCQty += row("SpecialAvailableQty")
                        Next
                    End If

                    'In boxes
                    filteredRows = dtSpecialMonthFC_Inbox.Select("UniqueID='" & arrlstUniqueIDs(i) & "'")
                    iFCQty += filteredRows.Length


                    'Shipped
                    filteredRows = dtSpecialMonthFC_Shipped.Select("UniqueID='" & arrlstUniqueIDs(i) & "'")
                    iFCQty += filteredRows.Length

                    If bHasIt Then 'update Special FC
                        For Each row In dtOutput.Rows
                            If row("UniqueID") = arrlstUniqueIDs(i) Then
                                row.BeginEdit() : row("mnSpecialQty") = iFCQty : row.AcceptChanges()
                            End If
                        Next
                    ElseIf iFCQty > 0 Then 'Add new
                        strSql = "SELECT Concat_WS('_',A.Cust_ID,E.Loc_ID,D.model_ID,B.Freq_ID,C.Baud_ID) AS UniqueID, 0 AS mnForecast, " & iFCQty & " AS mnSpecialQty" & Environment.NewLine
                        strSql &= " ,A.Cust_ID,E.Loc_ID,D.Model_ID,B.Freq_ID,C.Baud_ID,A.Cust_Name1,E.Loc_Name" & Environment.NewLine
                        strSql &= " ,D.Model_Desc,B.Freq_Number, C.Baud_Number" & Environment.NewLine
                        strSql &= " FROM  tcustomer A, tlocation E, lfrequency B,lbaud C, tmodel D" & Environment.NewLine
                        strSql &= " WHERE A.Cust_ID=" & iMyCustID & " AND E.Loc_ID =" & iMyLocID & " AND D.model_ID=" & iMyModelID & " AND B.Freq_ID=" & iMyFreqID & " AND C.Baud_ID=" & iMyBaudID & ";" & Environment.NewLine
                        dtTmp = Me.objMisc.GetDataTable(strSql)
                        If dtTmp.Rows.Count = 0 Then
                            Throw New Exception("System has failed to find data for " & arrlstUniqueIDs(i))
                        Else
                            For Each row In dtTmp.Rows 'should be one row
                                dtOutput.ImportRow(row)
                            Next
                        End If
                    End If
                Next

                Return dtOutput

                'strDateWeekStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(dteToday), FirstDayOfWeek.Monday) - 1) * -1, dteToday), "yyyy-MM-dd")
                'strDateWeekEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateWeekStart)), "yyyy-MM-dd")

                'strSql = "SELECT DISTINCT FC_Year, FC_Week FROM tamsforecastedneed " & Environment.NewLine
                'strSql &= " WHERE  Cust_ID in (" & strCustIDs & ") " & Environment.NewLine
                'strSql &= " AND YearWeekStartDate BETWEEN '" & strDateWeekStart & " 00:00:00' and '" & strDateWeekEnd & " 00:00:00' " & Environment.NewLine
                'dtFC = Me.objMisc.GetDataTable(strSql)

                'If dtFC.Rows.Count = 0 Then
                '    Throw New Exception("Can't define forecast year and week.")
                'ElseIf dtFC.Rows.Count > 1 Then
                '    Throw New Exception("More than one record existed for forecast year and week in weekly forecast table.")
                'Else
                '    iYear = CInt(dtFC.Rows(0)("FC_Year"))

                '    Select Case CInt(dtFC.Rows(0)("FC_Week"))
                '        Case 1, 2, 3, 4
                '            iMonth = 1
                '        Case 5, 6, 7, 8
                '            iMonth = 2
                '        Case 9, 10, 11, 12, 13
                '            iMonth = 3

                '        Case 14, 15, 16, 17
                '            iMonth = 4
                '        Case 18, 19, 20, 21
                '            iMonth = 5
                '        Case 22, 23, 24, 25, 26
                '            iMonth = 6

                '        Case 27, 28, 29, 30
                '            iMonth = 7
                '        Case 31, 32, 33, 34
                '            iMonth = 8
                '        Case 35, 36, 37, 38, 39
                '            iMonth = 9

                '        Case 40, 41, 42, 43
                '            iMonth = 10
                '        Case 44, 45, 46, 47
                '            iMonth = 11
                '        Case Else
                '            If CInt(dtFC.Rows(0)("FC_Week")) >= 48 Then
                '                iMonth = 12
                '            Else
                '                Throw New Exception("System has failed to define month for monthly forecast.")
                '            End If
                '    End Select
                'End If

                'strSql = "SELECT Distinct NewUniqueID as UniqueID , mnForecast, mnSpecialQty, A.Cust_ID, A.Model_ID, A.Freq_ID, A.baud_ID" & Environment.NewLine
                'strSql &= ",B.Cust_Name1, C.Model_Desc, D.freq_Number, E.baud_Number" & Environment.NewLine
                'strSql &= " FROM tamsforecastedneed_Month A " & Environment.NewLine
                'strSql &= " INNER JOIN tcustomer B on A.Cust_ID = B.Cust_ID" & Environment.NewLine
                'strSql &= " INNER JOIN tmodel C on A.Model_ID = C.Model_ID" & Environment.NewLine
                'strSql &= " INNER JOIN lfrequency D on A.freq_ID = D.freq_ID" & Environment.NewLine
                'strSql &= " INNER JOIN lbaud E on A.baud_ID = E.baud_ID " & Environment.NewLine
                'strSql &= " WHERE A.FC_Year = " & iYear & " AND FC_Month = " & iMonth.ToString.PadLeft(2, "0") & Environment.NewLine
                'strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                'If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                'If iFreqID > 0 Then strSql &= " AND A.freq_ID = " & iFreqID & Environment.NewLine
                'If iBaudID > 0 Then strSql &= " AND A.baud_ID = " & iBaudID & Environment.NewLine
                'Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************************
        Private Sub getCurrentMonthForecastValue(ByVal mnBeginDate As Date, ByVal mnEndDate As Date, _
                                                ByVal dtMonthWeeksDaysForecasted As DataTable, ByVal iWeekCount As Integer, _
                                                ByRef bFound As Boolean, ByRef iVal As Integer, _
                                                ByRef bFound2 As Boolean, ByRef iVal2 As Integer)

            Dim v As Integer = 0, n As Integer = 0, iCnt As Integer = 0, m As Integer = 0
            Dim vWeekResult As Integer = 0, iMonthTotal As Integer = 0, vDailyAvgOfWeek As Double = 0
            Dim v2 As Integer = 0, n2 As Integer = 0, iCnt2 As Integer = 0, m2 As Integer = 0
            Dim vWeekResult2 As Integer = 0, iMonthTotal2 As Integer = 0, vDailyAvgOfWeek2 As Double = 0
            Dim dtFilteredRows() As DataRow
            Dim dtMonthFilteredRows() As DataRow
            Dim row As DataRow
            Dim k As Integer

            Try
                Dim arrListWeekDays As ArrayList = getRequiredWorkingWeekDays()
                bFound = False : bFound2 = False

                For k = 1 To iWeekCount 'every week
                    vWeekResult = 0 : n = 0 : m = 0 : v = 0 : vDailyAvgOfWeek = 0
                    vWeekResult2 = 0 : n2 = 0 : m2 = 0 : v2 = 0 : vDailyAvgOfWeek2 = 0
                    dtFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k)
                    If dtFilteredRows.Length = 7 Then
                        For Each row In dtFilteredRows 'every full week averaged
                            If arrListWeekDays.Contains(row("WeekDay")) Then
                                If Not row.IsNull("WeekForecast") Then
                                    v += row("WeekForecast") : n += 1
                                End If
                                If Not row.IsNull("SpecialQty") Then
                                    v2 += row("SpecialQty") : n2 += 1
                                End If
                            End If
                        Next
                        If n > 0 Then
                            iCnt += 1
                            vWeekResult = Math.Ceiling((v / n)) : vDailyAvgOfWeek = vWeekResult / arrListWeekDays.Count
                            'Get averaged within the month (maybe some partial week for the month), recompute
                            If k = iWeekCount Then 'last week
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]<=#" & mnEndDate & "#")
                            Else
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]>=#" & mnBeginDate & "#")
                            End If
                            v = 0
                            For Each row In dtMonthFilteredRows
                                ' For i As Integer = 0 To arrListWeekDays.Count - 1
                                If arrListWeekDays.Contains(row("WeekDay")) Then
                                    If Not row.IsNull("WeekForecast") Then
                                        v += row("WeekForecast") : m += 1
                                    End If
                                End If
                                'Next
                            Next
                            If m = 0 Then 'nothing for this partial week 
                                iCnt = iCnt - 1
                            ElseIf m <> n Then 'recompute
                                vWeekResult = Math.Ceiling(vDailyAvgOfWeek * m) '(v / m)
                            End If
                        End If
                        iMonthTotal += vWeekResult

                        If n2 > 0 Then
                            iCnt2 += 1
                            vWeekResult2 = Math.Ceiling((v2 / n2)) : vDailyAvgOfWeek2 = vWeekResult2 / arrListWeekDays.Count
                            'Get averaged within the month (maybe some partial week for the month), recompute
                            If k = iWeekCount Then 'last week
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]<=#" & mnEndDate & "#")
                            Else
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]>=#" & mnBeginDate & "#")
                            End If
                            v2 = 0
                            For Each row In dtMonthFilteredRows
                                If arrListWeekDays.Contains(row("WeekDay")) Then
                                    If Not row.IsNull("SpecialQty") Then
                                        v2 += row("SpecialQty") : m2 += 1
                                    End If
                                End If

                            Next
                            If m2 = 0 Then 'nothing for this partial week 
                                iCnt2 = iCnt2 - 1
                            ElseIf m2 <> n2 Then 'recompute
                                vWeekResult2 = Math.Ceiling(vDailyAvgOfWeek2 * m2) '(v2 / m2)
                            End If
                        End If
                        iMonthTotal2 += vWeekResult2
                    Else
                        'MessageBox.Show("Invalid week length: it does not equal to 7 in getCurrentMonthForecastValue", "getCurrentMonthForecastValue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Throw New Exception("Invalid week length: it does not equal to 7 in getCurrentMonthForecastValue")
                    End If
                Next
                If iCnt > 0 Then
                    iVal = iMonthTotal : bFound = True
                End If
                If iCnt2 > 0 Then
                    iVal2 = iMonthTotal2 : bFound2 = True
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        '*******************************************************************************************************************
        Public Sub CreateExcelReport(ByVal dtFinal As DataTable, ByVal rptDate As Date)
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim rng As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim oArrData As Object(,)
            Dim RowsNum, ColsNum As Integer
            Dim TopHeaderRowNum As Integer = 2
            Dim p, k, j, s As Integer
            Dim objSaveFileDialog As New System.Windows.Forms.SaveFileDialog()
            Dim strfileName As String = ""

            xlApp = New Excel.Application()
            xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)
            xlApp.Visible = False : xlApp.DisplayAlerts = False

            'Initial sheet
            xlWorkSheet = DirectCast(xlWorkBook.Sheets(1), Excel._Worksheet)

            'Set text columns
            For p = 1 To 5
                xlWorkSheet.Columns(p).NumberFormat = "@"
            Next p

            'Get counts of rows and columns
            RowsNum = dtFinal.Rows.Count : ColsNum = dtFinal.Columns.Count
            ReDim oArrData(RowsNum + 1, ColsNum)

            'Get data into array (for quickly filling into excel)
            For k = 0 To dtFinal.Rows.Count - 1
                For j = 0 To dtFinal.Columns.Count - 1
                    If k = 0 Then
                        Dim strColName As String = dtFinal.Columns(j).ColumnName.ToString.Replace("wk", "").Replace("mn", "")
                        strColName = strColName.Replace("Space1", "").Replace("Space2", "").Replace("Space3", "")
                        oArrData(k, j) = strColName 'header
                    End If
                    oArrData(k + 1, j) = dtFinal.Rows(k)(j) 'data
                Next j
            Next k

            'Fill data into excel
            If dtFinal.Rows.Count = 0 Then
                xlWorkSheet.Cells(1, 1) = "No data"
            Else
                xlWorkSheet.Range("A" & TopHeaderRowNum & ":" & CalExcelColLetter(ColsNum) & (RowsNum + 1)).Value = oArrData
            End If

            'Add formula calculatons
            rng = xlWorkSheet.Range(CalExcelColLetter(10) & "3:" & CalExcelColLetter(10) & RowsNum.ToString)
            rng.Formula = "=I3-(G3+H3)"
            rng = xlWorkSheet.Range(CalExcelColLetter(15) & "3:" & CalExcelColLetter(15) & RowsNum.ToString)
            rng.Formula = "=N3-(L3+M3)"
            rng = xlWorkSheet.Range(CalExcelColLetter(19) & "3:" & CalExcelColLetter(19) & RowsNum.ToString)
            rng.Formula = "=O3+Q3+R3"

            'Border and font
            rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(RowsNum + 1, ColsNum))
            rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            rng.Font.Name = "Arial" : rng.Font.Bold = False : rng.Font.Italic = False : rng.Font.Size = 8

            'Header rows back color
            rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(2, ColsNum))
            rng.Interior.ColorIndex = 15 'light gray  ' Rng.Font.ColorIndex = 1

            'Merge cells and add master header, alignment
            For s = 19 To 1 Step -1
                Select Case s
                    Case 19
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, s - 2), xlWorkSheet.Cells(1, s))
                        rng.Value = "Backup Data"
                    Case 15
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, s - 3), xlWorkSheet.Cells(1, s))
                        rng.Value = "Current Month"
                    Case 10
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, s - 3), xlWorkSheet.Cells(1, s))
                        rng.Value = "Current Week"
                    Case 5
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, s - 4), xlWorkSheet.Cells(1, s))
                        rng.Value = "SKU Information"
                End Select
                rng.Merge() : rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                rng.Font.Size = 10 : rng.HorizontalAlignment = Excel.Constants.xlCenter
            Next s

            'Set color, width of space cols
            For s = 6 To 16
                Select Case s
                    Case 6, 11, 16
                        rng = xlWorkSheet.Range(xlWorkSheet.Cells(1, s), xlWorkSheet.Cells(RowsNum + 1, s))
                        rng.ColumnWidth = 1 : rng.Interior.ColorIndex = 1 '16 1=black, 16 dark black
                End Select
            Next s

            'Auto Fit Cols
            xlWorkSheet.Cells.EntireColumn.AutoFit()

            'Modify col header Produced_NotYetShipped
            rng = xlWorkSheet.Range(xlWorkSheet.Cells(2, 17), xlWorkSheet.Cells(2, 17))
            rng.ColumnWidth = 12
            rng.Value = "Produced" & vbCrLf & "(NotYetShipped)"  '"Produced_Qty (NotYetShipped)" : rng.WrapText = True

            'Auto fit rows
            xlWorkSheet.Cells.EntireRow.AutoFit()

            'Save file
            objSaveFileDialog.DefaultExt = "xls"
            objSaveFileDialog.FileName = "AMS Forecasted vs Shippments " & Convert.ToDateTime(rptDate).ToString("yyyyMMdd") & ".xls"
            objSaveFileDialog.ShowDialog()
            strfileName = objSaveFileDialog.FileName

            If strfileName.Trim.Length = 0 Then
                System.Windows.Forms.MessageBox.Show("No file name has been selected.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop)
            Else
                If strfileName.IndexOf("\") < 0 Then Exit Sub
                If File.Exists(strfileName) = True Then Kill(strfileName)
                xlWorkBook.SaveAs(strfileName)
                System.Windows.Forms.MessageBox.Show("File has been saved.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
            End If

            'Clean/Release 
            If Not IsNothing(xlWorkSheet) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet)
            End If
            If Not IsNothing(xlWorkBook) Then
                'objWorkbook.Close(False)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
            End If
            If Not IsNothing(xlApp) Then
                xlApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            End If

            GC.Collect() : GC.WaitForPendingFinalizers()
            GC.Collect() : GC.WaitForPendingFinalizers()

        End Sub

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
#End Region


    End Class
End Namespace