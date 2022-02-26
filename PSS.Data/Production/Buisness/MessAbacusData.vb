
Option Explicit On 

Namespace Buisness

    Public Class MessAbacusData

        Private objMisc As Production.Misc

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

        '***************************************************
        Public Function SearchAbacusData(ByVal strSearchType As String, _
                                         ByVal strSearchCriteria As String) As DataTable
            Dim strSql As String = ""
            Dim strSelectStatement As String = ""
            Dim dt1 As DataTable

            Try
                strSelectStatement = "SELECT " & Environment.NewLine
                strSelectStatement &= "if (Device_Cnt IS NULL, '', Device_Cnt ) as 'Count', " & Environment.NewLine
                strSelectStatement &= "if (Device_SN IS NULL, '', Device_SN ) as 'PSS SN',  " & Environment.NewLine
                strSelectStatement &= "if (Device_OldSN IS NULL, '', Device_OldSN ) as 'PSS Old SN', " & Environment.NewLine
                strSelectStatement &= "if (Device_DateShip IS NULL, '', Device_DateShip ) as 'Ship Date', " & Environment.NewLine
                strSelectStatement &= "if (AMData_ID IS NULL, 'No', 'Yes' ) as 'In Abacus', " & Environment.NewLine
                strSelectStatement &= "if (Co_Cd IS NULL, '', Co_Cd  ) as 'Co Cd', " & Environment.NewLine
                strSelectStatement &= "if (Serial_Number IS NULL, '', Serial_Number ) as 'Abacus SN', " & Environment.NewLine
                strSelectStatement &= "if (Own_Cd IS NULL, '', Own_Cd ) as 'Own Cd', " & Environment.NewLine
                strSelectStatement &= "if (Stat_Cd IS NULL, '', Stat_Cd ) as 'Stat Cd', " & Environment.NewLine
                strSelectStatement &= "if (Type IS NULL, '', Type ) as 'Type', " & Environment.NewLine
                strSelectStatement &= "if (Chnl_Cd IS NULL, '', Chnl_Cd) as 'Chnl Cd', " & Environment.NewLine
                strSelectStatement &= "if (Color IS NULL, '', Color ) as 'Color', " & Environment.NewLine
                strSelectStatement &= "if (Capcode_1 IS NULL, '', Capcode_1) as 'Capcode 1', " & Environment.NewLine
                strSelectStatement &= "if (N_U IS NULL, '', N_U) as 'N-U', " & Environment.NewLine
                strSelectStatement &= "if (F_I IS NULL, '', F_I) as 'F-I', " & Environment.NewLine
                strSelectStatement &= "if (Loc_Chg_Date IS NULL, '', Loc_Chg_Date ) as 'Loc Chg Date', " & Environment.NewLine
                strSelectStatement &= "if (Last_Acct IS NULL, '',  Last_Acct) as 'Last Acct', " & Environment.NewLine
                strSelectStatement &= "if (Prev_Acct IS NULL, '', Prev_Acct ) as 'Prev Acct', " & Environment.NewLine
                strSelectStatement &= "if (Equip_Value IS NULL, '', Equip_Value ) as 'Equip Value' " & Environment.NewLine

                Select Case strSearchType
                    Case "Serial Number"
                        strSql = strSelectStatement
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN tamericanmessdata ON tdevice.Device_SN = tamericanmessdata.Serial_Number " & Environment.NewLine
                        strSql &= "WHERE tdevice.loc_id = 19 AND tdevice.Device_SN = '" & strSearchCriteria & "'" & Environment.NewLine
                        strSql &= "ORDER BY Device_Cnt ASC;"

                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable

                        If dt1.Rows.Count = 0 Then
                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If

                            strSql = strSelectStatement
                            strSql &= "FROM tamericanmessdata " & Environment.NewLine
                            strSql &= "LEFT OUTER JOIN tdevice ON tamericanmessdata.Serial_Number = tdevice.Device_SN AND tdevice.loc_id = 19 " & Environment.NewLine
                            strSql &= "WHERE  tamericanmessdata.Serial_Number = '" & strSearchCriteria & "'" & Environment.NewLine
                            strSql &= "ORDER BY Device_Cnt ASC;"

                            Me.objMisc._SQL = strSql
                            dt1 = Me.objMisc.GetDataTable
                        End If
                    Case "Tray ID"
                        strSql = strSelectStatement
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN tamericanmessdata ON tdevice.Device_SN = tamericanmessdata.Serial_Number " & Environment.NewLine
                        strSql &= "WHERE tdevice.loc_id = 19 AND Tray_ID = " & CInt(strSearchCriteria) & " " & Environment.NewLine
                        strSql &= "ORDER BY Device_Cnt ASC;"
                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable
                    Case "Ship ID"
                        strSql &= strSelectStatement
                        strSql = "FROM tdevice " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN tamericanmessdata ON tdevice.Device_SN = tamericanmessdata.Serial_Number " & Environment.NewLine
                        strSql &= "WHERE tdevice.loc_id = 19 AND Ship_ID =  " & CInt(strSearchCriteria) & " " & Environment.NewLine
                        strSql &= "ORDER BY Device_Cnt ASC;"
                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable
                End Select

                Return dt1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function SearchTverdataTable(ByVal strSearchType As String, _
                                          ByVal strSearchCriteria As String) As DataTable
            Dim strSql As String = ""
            Dim strSelectStatement As String = ""
            Dim dt1 As DataTable

            Try
                strSelectStatement = "SELECT " & Environment.NewLine
                strSelectStatement &= "IF (RcvdFlag IS NULL, 'No', IF( RcvdFlag = 0, 'No', 'Yes') ) AS 'Is Received?' " & Environment.NewLine
                strSelectStatement &= ", IF (tdevice.Device_DateRec IS NULL, '', tdevice.Device_DateRec ) AS 'Production Rec Date' " & Environment.NewLine
                strSelectStatement &= ", IF (tverdata.Device_SN IS NULL, '', tverdata.Device_SN ) AS 'Serial Number' " & Environment.NewLine
                strSelectStatement &= ", IF (Device_CapCode IS NULL, '', Device_CapCode ) AS 'Cap Code' " & Environment.NewLine
                strSelectStatement &= ", IF (Device_Freq IS NULL, '', Device_Freq ) AS 'Frequency' " & Environment.NewLine
                strSelectStatement &= ", IF (Loc_Chg_Date IS NULL, '', Loc_Chg_Date ) AS 'Loc Chg Date' " & Environment.NewLine
                strSelectStatement &= ", IF (SKU_Number IS NULL, '', SKU_Number ) AS 'SKU' " & Environment.NewLine
                strSelectStatement &= ", IF (LoadFileName IS NULL, '', LoadFileName ) AS 'Loaded File Name' " & Environment.NewLine
                strSelectStatement &= ", IF (WO_Name IS NULL, '', WO_Name ) AS 'WO Name' " & Environment.NewLine
                strSelectStatement &= ", IF (Device_Model IS NULL, '',  Device_Model ) AS 'Device Model' " & Environment.NewLine

                Select Case strSearchType
                    Case "Serial Number"
                        strSql = strSelectStatement
                        strSql &= "FROM tverdata " & Environment.NewLine
                        strSql &= "LEFT OUTER JOIN tdevice ON tverdata.Device_ID =  tdevice.Device_ID " & Environment.NewLine
                        strSql &= "WHERE tverdata.Device_SN = '" & strSearchCriteria & "'" & Environment.NewLine
                        strSql &= "ORDER BY tverdata.Device_SN ASC;"

                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable
                    Case "Tray ID"
                        strSql = strSelectStatement
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "INNER JOIN tverdata ON tdevice.Device_ID = tverdata.Device_ID " & Environment.NewLine
                        strSql &= "WHERE tdevice.loc_id = 19 AND Tray_ID = " & CInt(strSearchCriteria) & " " & Environment.NewLine
                        strSql &= "ORDER BY tdevice.Device_SN ASC;"
                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable
                    Case "Ship ID"
                        strSql &= strSelectStatement
                        strSql = "FROM tdevice " & Environment.NewLine
                        strSql &= "INNER JOIN tverdata ON tdevice.Device_ID = tverdata.Device_ID " & Environment.NewLine
                        strSql &= "WHERE tdevice.loc_id = 19 AND Ship_ID =  " & CInt(strSearchCriteria) & " " & Environment.NewLine
                        strSql &= "ORDER BY tdevice.Device_SN ASC;"
                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable
                End Select

                Return dt1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function CreateAbacusVsPSSData_DiscrepancyRpt(Optional ByVal strShipFr As String = "", _
                                                             Optional ByVal strShipTo As String = "") As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strSelectStatement As String = ""

            Try
                strSelectStatement = "SELECT lfrequency.freq_Number, " & Environment.NewLine
                strSelectStatement &= "if (capcode is null, '', capcode ) as 'Capcode', " & Environment.NewLine
                strSelectStatement &= "if (Device_SN is null, '', Device_SN ) as 'SN', " & Environment.NewLine
                strSelectStatement &= "if (Device_OldSN IS NULL, '',  Device_OldSN ) as 'Old SN', " & Environment.NewLine
                strSelectStatement &= "if (Device_OldSN IS NULL, '',  concat('*', Device_OldSN, '*' ) ) as 'Old SN Barcode' " & Environment.NewLine

                If strShipFr = "" Or strShipTo = "" Then
                    strSql &= strSelectStatement
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tmessdata ON tdevice.device_id = tmessdata.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tamericanmessdata ON tdevice.Device_SN = tamericanmessdata.Serial_Number " & Environment.NewLine
                    strSql &= "WHERE tdevice.loc_id = 19 " & Environment.NewLine
                    strSql &= "AND Device_DateShip IS NULL " & Environment.NewLine
                    strSql &= "AND AMData_ID is NULL " & Environment.NewLine
                    strSql &= "ORDER BY Device_OldSN DESC;"
                Else
                    strSql &= strSelectStatement
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tmessdata ON tdevice.device_id = tmessdata.device_id " & Environment.NewLine
                    strSql &= "INNER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tamericanmessdata ON tdevice.Device_SN = tamericanmessdata.Serial_Number " & Environment.NewLine
                    strSql &= "WHERE tdevice.loc_id = 19 " & Environment.NewLine
                    strSql &= "AND Device_ShipWorkDate >= '" & strShipFr & "' AND Device_ShipWorkDate <= '" & strShipTo & "' " & Environment.NewLine
                    'strSql &= "AND (AMData_ID is NULL or Capcode_1 <> capcode or freq_id_old is not null ) and Ship_id <> 9999919 " & Environment.NewLine
                    strSql &= "AND ( AMData_ID is NULL or Capcode_1 <> capcode ) AND Ship_id <> 9999919 " & Environment.NewLine
                    strSql &= "ORDER BY Device_OldSN DESC;"
                End If

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Me.CreateAbacusPSSDiscrepancyExcelFile(dt1)
                End If

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        Private Sub CreateAbacusPSSDiscrepancyExcelFile(ByVal dtData As DataTable)
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook   ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim i As Integer = 1
            Dim R1 As DataRow

            Try
                '******************************************************************
                'Instantiate the excel related objects
                '******************************************************************
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True                 'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape

                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "SN"
                objExcel.Application.Cells(i, 2).Value = "SN Barcode"
                objExcel.Application.Cells(i, 3).Value = "Old SN"
                objExcel.Application.Cells(i, 4).Value = "Old SN Barcode"
                objExcel.Application.Cells(i, 5).Value = "Frequency"
                objExcel.Application.Cells(i, 6).Value = "Cap-code"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 21
                objSheet.Columns("B:B").ColumnWidth = 21        'Need to change this
                objSheet.Columns("C:C").ColumnWidth = 21
                objSheet.Columns("D:D").ColumnWidth = 21        'Need to change this
                objSheet.Columns("E:E").ColumnWidth = 21        'Need to change this
                objSheet.Columns("F:F").ColumnWidth = 21        'Need to change this
                '*****************************************
                'Set alignments
                '*****************************************
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.Columns("A:A").Select()
                objExcel.Selection.NumberFormat = "@"
                objSheet.Columns("B:B").Select()
                objExcel.Selection.NumberFormat = "@"
                objSheet.Columns("C:C").Select()
                objExcel.Selection.NumberFormat = "@"
                objSheet.Columns("D:D").Select()
                objExcel.Selection.NumberFormat = "@"
                objSheet.Columns("E:E").Select()
                objExcel.Selection.NumberFormat = "@"
                objSheet.Columns("F:F").Select()
                objExcel.Selection.NumberFormat = "@"
                '*****************************************
                'format header
                '*****************************************
                objSheet.Range("A1:F1").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                With objExcel.Selection.Interior
                    .ColorIndex = 37
                    .Pattern = Excel.Constants.xlSolid
                End With

                i += 1

                'Write data to excel file
                For Each R1 In dtData.Rows
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("SN"))
                    objExcel.Application.Cells(i, 2).Value = "*" & Trim(R1("SN")) & "*"
                    objExcel.Application.Cells(i, 3).Value = Trim(R1("Old SN"))
                    objExcel.Application.Cells(i, 4).Value = Trim(R1("Old SN Barcode"))
                    objExcel.Application.Cells(i, 5).Value = Trim(R1("freq_Number"))
                    objExcel.Application.Cells(i, 6).Value = Trim(R1("capcode"))

                    i += 1
                Next R1

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A1:F" & (dtData.Rows.Count + 1)).Select()
                'Set Font
                With objExcel.Selection
                    .Font.Name = "Microsoft Sans Serif"
                    .Font.Size = 11
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
                'Set the Barcode Font
                objSheet.Range("B2:B" & (dtData.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With
                objSheet.Range("D2:D" & (dtData.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With

                'Fit to page
                With objExcel.ActiveSheet.PageSetup
                    .PrintTitleRows = ""
                    .PrintTitleColumns = ""
                End With
                objExcel.ActiveSheet.PageSetup.PrintArea = ""
                With objExcel.ActiveSheet.PageSetup
                    .LeftHeader = ""
                    .CenterHeader = ""
                    .RightHeader = ""
                    .LeftFooter = ""
                    .CenterFooter = ""
                    .RightFooter = ""
                    .LeftMargin = objExcel.Application.InchesToPoints(0.25)
                    .RightMargin = objExcel.Application.InchesToPoints(0.25)
                    .TopMargin = objExcel.Application.InchesToPoints(0.5)
                    .BottomMargin = objExcel.Application.InchesToPoints(0.5)
                    .HeaderMargin = objExcel.Application.InchesToPoints(0.25)
                    .FooterMargin = objExcel.Application.InchesToPoints(0.25)
                    .PrintHeadings = False
                    .PrintGridlines = False
                    '.PrintQuality = 600
                    .CenterHorizontally = True
                    .CenterVertically = False
                    .Orientation = Excel.XlPageOrientation.xlPortrait
                    .Draft = False
                    '.PaperSize = Excel.XlPaperSize.xlPaperLetter
                    '.BlackAndWhite = False
                    .Zoom = 100
                    '.FitToPagesWide = 1
                    '.FitToPagesTall = 1
                End With

                '*************************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                '*************************************************
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dtData) Then
                    dtData.Dispose()
                    dtData = Nothing
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '***************************************************


    End Class

End Namespace

