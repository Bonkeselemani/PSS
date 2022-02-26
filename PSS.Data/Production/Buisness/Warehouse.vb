Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Namespace Buisness
    Public Class Warehouse
        Private objMisc As Production.Misc
        'Private strDir As String = "R:\ATCLE\Dock Receiving\" & Format(DateAdd("d", -(Weekday(Now) - 6), Now), "MM-dd-yyyy") & "\"  'Creates a  subfolder for the Friday's date of the week
        'Private strDiscrepPath As String = "P:\Dept\ATCLE\Palet packing list\DISCREPANCY FOLDER\"

        'Lan add
        Private iWHPallet_NoBox As Integer

        '//added by Lan 12/06/2006
        Private iChildPalletID As Integer = 0
        Public Property ChildPalletID() As Integer
            Get
                Return iChildPalletID
            End Get
            Set(ByVal Value As Integer)
                iChildPalletID = Value
            End Set
        End Property
        '//

        Private iPalletID As Integer = 0
        Public Property PalletID() As Integer
            Get
                Return iPalletID
            End Get
            Set(ByVal Value As Integer)
                iPalletID = Value
            End Set
        End Property

        Private iGlobalResult As Integer = 0
        Public Property Result() As Integer
            Get
                Return iGlobalResult
            End Get
            Set(ByVal Value As Integer)
                iGlobalResult = Value
            End Set
        End Property

        Private iWHR_ID As Integer = 0
        Public Property WHR_ID() As Integer
            Get
                Return iWHR_ID
            End Get
            Set(ByVal Value As Integer)
                iWHR_ID = Value
            End Set
        End Property

        Public Function GetGroupName(ByVal iParentGroupID) As String
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                objMisc._SQL = "Select * from lgroups where group_id = " & iParentGroupID & ";"
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    Return Trim(R1("Group_Desc"))
                Else
                    Throw New Exception("Group Description not determined.")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        'lan add Cust_id parameter(INCOMPLETE FUNCTION)
        '***************************************************************************
        '''''Public Function DeleteAcceptedDeviceFromWHReceive(ByVal strPallett As String, _
        '''''                                                ByVal strSN As String, _
        '''''                                                ByVal iCust_id As Integer) As Integer
        '''''    Dim dt1 As New DataTable()
        '''''    Dim R1 As DataRow
        '''''    Dim strsql As String = ""

        '''''    Try
        '''''        strsql = "Delete from twarehousereceive, twarehousepallet " & Environment.NewLine
        '''''        strsql &= "where twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
        '''''        strsql &= "whr_result = 0 and  " & Environment.NewLine
        '''''        strsql &= "WHR_Box_SN = '" & strSN & "' and " & Environment.NewLine
        '''''        strsql &= "twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
        '''''        'lan add
        '''''        strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"

        '''''        objMisc._SQL = strsql
        '''''        Return objMisc.ExecuteNonQuery

        '''''    Catch ex As Exception
        '''''        Throw ex
        '''''    Finally
        '''''        R1 = Nothing
        '''''        If Not IsNothing(dt1) Then
        '''''            dt1.Dispose()
        '''''            dt1 = Nothing
        '''''        End If
        '''''    End Try
        '''''End Function


        Public Function DeletePalletFromDockReceiving(ByVal strPallet As String, _
                                                     ByVal iCust_id As Integer) As Integer
            Dim i As Integer = 0
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                If strPallet = "" Then
                    Throw New Exception("Buisness.Warehouse.DeletePalletFromDockReceiving(): " & Environment.NewLine & "Please enter a valid Pallet Number to delete.")
                End If

                'Step 1:: Get Pallet_ID for strPallet
                objMisc._SQL = "Select * from twarehousepallet where WHPallet_Number = '" & strPallet & "' and Cust_id = " & iCust_id & ";"
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iPalletID = R1("whpallet_id")

                    'Lan Add this section 10/19/2006. Can't delete close pallet.
                    '**********************************************************
                    If R1("WHPalletClosed") = 1 Then
                        Throw New Exception("Pallet '" & strPallet & "' already close. Can not delete.")
                    End If
                    ''**********************************************************

                    'Step 2::Delete entries from twarehousereceive
                    objMisc._SQL = "Delete from twarehousereceive where whpallet_id = " & iPalletID & ";"
                    i = objMisc.ExecuteNonQuery

                    'Step 3::Delete entries from twarehousepalletload
                    'objMisc._SQL = "Delete from twarehousepalletload where whpallet_id = " & iPalletID & ";"
                    'i = objMisc.ExecuteNonQuery

                    'Step 4::Delete entries from twarehousepallet
                    'objMisc._SQL = "Delete from twarehousepallet where whpallet_id = " & iPalletID & ";"
                    'i = objMisc.ExecuteNonQuery
                    iPalletID = 0

                    Return i
                Else
                    Throw New Exception("Buisness.Warehouse.DeletePalletFromDockReceiving(): " & Environment.NewLine & "Pallet does not exist.")
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Warehouse.DeletePalletFromDockReceiving(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        Public Function DeleteDescrepancy(ByVal iwhrid As Integer, ByVal iCust_id As Integer) As Integer
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iPallett_ID As Integer = 0
            Dim strSN As String = ""
            Dim iWHPallet_ID As Integer = 0
            Dim strPalletName As String = ""
            Dim strFilePath As String = ""

            Dim strDiscrepPath_locVar As String = ""

            Try
                If iwhrid > 0 Then

                    '-------------------------
                    'set discrepancy file path (Lan add)
                    Select Case iCust_id
                        Case 2019
                            strDiscrepPath_locVar = "P:\Dept\ATCLE\Palet packing list\DISCREPANCY FOLDER\"
                        Case 2219
                            strDiscrepPath_locVar = "P:\Dept\Game Stop\DISCREPANCY FOLDER\"
                    End Select
                    '-------------------------

                    '**************************
                    'i = Me.AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , iwhrid, 8, )  ' 8 - add one device to Warehouse WIP; Removes it from Triage WIP; Group_ID for Warehouse is 8
                    '**************************
                    'Get Pallett_ID from tpallett
                    objMisc._SQL = "Select pallett_id, WHR_Box_SN, WHR_Dev_SN, WHPallet_ID from twarehousereceive where whr_id = " & iwhrid & ";"
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        R1 = dt1.Rows(0)
                        iPallett_ID = R1("Pallett_ID")
                        If Not IsDBNull(R1("WHR_Box_SN")) Then
                            strSN = Trim(R1("WHR_Box_SN"))
                        ElseIf Not IsDBNull(R1("WHR_Dev_SN")) Then
                            strSN = Trim(R1("WHR_Dev_SN"))
                        Else
                            Throw New Exception("Serial number is not defined.")
                        End If
                        If Not IsDBNull(R1("WHPallet_ID")) Then
                            iWHPallet_ID = R1("WHPallet_ID")
                        Else
                            Throw New Exception("Warehouse pallet ID is not defined.")
                        End If
                    Else
                        Throw New Exception("Device not found.")
                    End If
                    '**************************
                    'Cleanup
                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '**************************
                    'Delete from twarehousereceive
                    objMisc._SQL = "Delete from twarehousereceive where whr_id = " & iwhrid & ";"
                    i = objMisc.ExecuteNonQuery
                    '***************************************
                    'Move device back to warehouse
                    i = Me.AddRemoveFromWarehouseWIP(iWHPallet_NoBox, strSN, iWHPallet_ID, 8)    ' 8 - add one device to Warehouse WIP; Removes it from Triage WIP; Group_ID for Warehouse is 8
                    '**************************
                    'Delete the file and the Shipped Pallet
                    If iPallett_ID > 0 Then
                        objMisc._SQL = "Select Pallett_Name from tpallett where Pallett_ID = " & iPallett_ID & ";"
                        dt1 = objMisc.GetDataTable

                        If dt1.Rows.Count > 0 Then
                            R1 = dt1.Rows(0)
                            If Not IsDBNull(R1("Pallett_Name")) Then
                                strPalletName = Trim(R1("Pallett_Name"))
                                strFilePath = strDiscrepPath_locVar & strPalletName & ".xls"
                                If File.Exists(strFilePath) Then
                                    Kill(strFilePath)
                                End If
                            End If
                            '**************************
                            'Delete from tpallett
                            objMisc._SQL = "Delete from tpallett where Pallett_ID = " & iPallett_ID & ";"
                            i = objMisc.ExecuteNonQuery
                            '**************************
                        Else
                            Throw New Exception("Pallet not found.")
                        End If
                    Else
                        Throw New Exception("'Pallet' and 'Discrepancy File' could not be deleted. Pallet may not have been assigned to this discrepancy.")
                    End If

                    '**************************
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Warehouse.DeleteDescrepancy(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************************
        'lan add iCust_id parameter
        '***************************************************************
        Public Function LoadDockDescrepancies(ByVal strPallett As String, _
                                              ByVal iCust_id As Integer) As DataTable
            Dim strsql As String
            Try

                strsql = "select " & Environment.NewLine
                strsql += "whr_id, " & Environment.NewLine
                strsql += "whr_box_sn as 'Box SN', " & Environment.NewLine
                strsql += "whr_dev_sn as 'Device SN', " & Environment.NewLine
                strsql += "if(WHR_BoxSN_Absent_in_file = 0, '', 'X') as 'Box SN not in file', " & Environment.NewLine
                strsql += "if(whr_devsn_boxsn_different = 0, '', 'X') as 'Box SN & Device SN Different', " & Environment.NewLine
                strsql += "if(WHR_DevSN_Absent_in_file = 0, '', 'X') as 'Device SN not in file', " & Environment.NewLine
                strsql += "if(WHR_Box_Empty = 0, '', 'X') as 'Empty Box', " & Environment.NewLine
                strsql += "if(WHR_WrongSKU = 0, '', 'X') as 'Wrong SKU', " & Environment.NewLine
                strsql += "if(WHR_DupInFile = 0, '', 'X') as 'Duplicate', " & Environment.NewLine
                strsql += "if(WHR_Mutltiple_Phones_In_Box = 0, '', 'X') as 'Mutltiple Devices in Box' " & Environment.NewLine

                strsql += "from twarehousereceive inner join twarehousepallet on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "where whpallet_number = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "whr_result = 1 and " & Environment.NewLine
                '//lan add
                strsql &= "twarehousepallet.Cust_ID = " & iCust_id & " " & Environment.NewLine
                '//
                strsql &= "order by whr_id desc;"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.Warehouse.LoadDockDescrepancies(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        Public Function GetWarehousePalletInfo(ByVal strPallett As String) As DataTable
            Dim strsql As String
            Try
                strsql = "Select * from twarehousepallet where WHPallet_Number = '" & strPallett & "'"
                strsql &= " and WHPallet_ID = " & iPalletID & ";"  'lan add 10/13/2006
                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.Warehouse.GetWarehousePalletInfo(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '''Public Function CreateReport(ByVal strPallett As String) As Integer
        '''    Dim strsql As String = ""
        '''    Dim dt1 As New DataTable()
        '''    Dim R1 As DataRow
        '''    Dim i As Integer = 3
        '''    Dim strPalletDesMsg As String = ""
        '''    Dim strNoBoxPallet As String = ""

        '''    'Excel Related variables
        '''    Dim objXL As Excel.Application
        '''    Dim objExcel As Excel.Application    ' Excel application
        '''    Dim objBook As Excel.Workbook     ' Excel workbook
        '''    Dim objSheet As Excel.Worksheet    ' Excel Worksheet

        '''    Try
        '''        '*****************************************
        '''        'Initialise Excel objects/properties
        '''        '*****************************************
        '''        'Instantiate the excel related objects
        '''        objExcel = New Excel.Application()      'Starts the Excel Session
        '''        objBook = objExcel.Workbooks.Add                    'Add a Workbook
        '''        objExcel.Application.Visible = False                'Make this false while going live
        '''        objExcel.Application.DisplayAlerts = False
        '''        objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
        '''        '******************************************
        '''        'Create header of excel file
        '''        '******************************************
        '''        objExcel.Application.Cells(i, 1).Value = "Bin Location/Pallet"
        '''        objExcel.Application.Cells(i, 2).Value = "Box SN"
        '''        objExcel.Application.Cells(i, 3).Value = "Device SN"
        '''        'objExcel.Application.Cells(i, 4).Value = "Pallet Descrepency"
        '''        objExcel.Application.Cells(i, 4).Value = "Box SN not in File"
        '''        objExcel.Application.Cells(i, 5).Value = "Box & Device SN Different"
        '''        objExcel.Application.Cells(i, 6).Value = "Device SN not in File"
        '''        objExcel.Application.Cells(i, 7).Value = "Empty Box"
        '''        objExcel.Application.Cells(i, 8).Value = "Wrong SKU"

        '''        objSheet.Columns("A:A").ColumnWidth = 18.86
        '''        objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("B:B").ColumnWidth = 21.57
        '''        objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("C:C").ColumnWidth = 16.43
        '''        objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

        '''        'objSheet.Columns("D:D").ColumnWidth = 20.43
        '''        'objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("D:D").ColumnWidth = 18.6
        '''        objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("E:E").ColumnWidth = 26.71
        '''        objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("F:F").ColumnWidth = 20.57
        '''        objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("G:G").ColumnWidth = 12.3
        '''        objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("H:H").ColumnWidth = 12.6
        '''        objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft

        '''        objSheet.Columns("A:A").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("B:B").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("C:C").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        'objSheet.Columns("D:D").Select()
        '''        'objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("D:D").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("E:E").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("F:F").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("G:G").Select()
        '''        objExcel.Selection.NumberFormat = "@"

        '''        objSheet.Columns("H:H").Select()
        '''        objExcel.Selection.NumberFormat = "@"


        '''        objSheet.Range("A" & i & ":H" & i).Select()
        '''        With objExcel.Selection
        '''            .HorizontalAlignment = Excel.Constants.xlCenter
        '''            .font.bold = True
        '''            .Font.ColorIndex = 5
        '''        End With

        '''        '******************************************
        '''        'Get descrepent data from DB
        '''        '******************************************
        '''        strsql = "SELECT " & Environment.NewLine
        '''        strsql += "WHPallet_Number as 'Bin Location/Pallet', " & Environment.NewLine
        '''        strsql += "WHR_Box_SN as 'Box SN', " & Environment.NewLine
        '''        strsql += "WHR_Dev_SN as 'Device SN', " & Environment.NewLine
        '''        strsql += "WHPallet_Descrepency, " & Environment.NewLine
        '''        strsql += "WHR_BoxSN_Absent_in_File, " & Environment.NewLine
        '''        strsql += "WHR_DevSN_BoxSN_Different, " & Environment.NewLine
        '''        strsql += "WHR_DevSN_Absent_in_File, " & Environment.NewLine
        '''        strsql += "WHR_WrongSKU, " & Environment.NewLine
        '''        strsql += "WHPallet_NoBox, " & Environment.NewLine
        '''        strsql += "WHR_Box_Empty " & Environment.NewLine
        '''        strsql += "FROM twarehousepallet " & Environment.NewLine
        '''        strsql += "inner join twarehousereceive on twarehousepallet.WHPallet_ID = twarehousereceive.WHPallet_ID " & Environment.NewLine

        '''        strsql += "where twarehousereceive.WHR_Result = 1 and " & Environment.NewLine
        '''        strsql += "WHPallet_Number = '" & strPallett & "';"

        '''        objMisc._SQL = strsql
        '''        dt1 = objMisc.GetDataTable

        '''        '******************************************
        '''        'Write to excel file
        '''        '******************************************
        '''        i += 2
        '''        For Each R1 In dt1.Rows
        '''            objExcel.Application.Cells(i, 1).Value = R1("Bin Location/Pallet")
        '''            objExcel.Application.Cells(i, 2).Value = R1("Box SN")
        '''            objExcel.Application.Cells(i, 3).Value = R1("Device SN")

        '''            If strPalletDesMsg = "" Then
        '''                If R1("WHPallet_Descrepency") = 1 Then
        '''                    strPalletDesMsg = "Devices received are less than those in the file."
        '''                ElseIf R1("WHPallet_Descrepency") = 2 Then
        '''                    strPalletDesMsg = "Devices received are more than those in the file."
        '''                End If
        '''            End If
        '''            If strNoBoxPallet = "" Then
        '''                If R1("WHPallet_NoBox") = 1 Then
        '''                    strNoBoxPallet = "All devices in this pallet are without boxes."
        '''                End If
        '''            End If
        '''            If R1("WHR_BoxSN_Absent_in_File") = 1 Then
        '''                objExcel.Application.Cells(i, 4).Value = "Box SN not in File"
        '''            End If
        '''            If R1("WHR_DevSN_BoxSN_Different") = 1 Then
        '''                objExcel.Application.Cells(i, 5).Value = "Box & Device SN Different"
        '''            End If
        '''            If R1("WHR_DevSN_Absent_in_File") = 1 Then
        '''                objExcel.Application.Cells(i, 6).Value = "Device SN not in File"
        '''            End If
        '''            If R1("WHR_Box_Empty") = 1 Then
        '''                objExcel.Application.Cells(i, 5).Value = ""
        '''                objExcel.Application.Cells(i, 6).Value = ""
        '''                objExcel.Application.Cells(i, 7).Value = "Empty Box"
        '''            End If
        '''            If R1("WHR_WrongSKU") = 1 Then
        '''                objExcel.Application.Cells(i, 8).Value = "Wrong SKU"
        '''            End If

        '''            i += 1
        '''        Next R1

        '''        '************************************************
        '''        'Set date time
        '''        objExcel.Application.Cells(1, 6).Value = Now

        '''        '************************************************
        '''        'Set borders

        '''        objSheet.Range("A3:H" & (i - 1)).Select()

        '''        'Set Font
        '''        With objExcel.Selection
        '''            .Font.Name = "Microsoft Sans Serif"
        '''        End With

        '''        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        '''        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        '''        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
        '''            .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
        '''            .Weight = Excel.XlBorderWeight.xlThin
        '''            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        '''        End With
        '''        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
        '''            .LineStyle = Excel.XlLineStyle.xlContinuous
        '''            .Weight = Excel.XlBorderWeight.xlThin
        '''            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        '''        End With
        '''        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
        '''            .LineStyle = Excel.XlLineStyle.xlContinuous
        '''            .Weight = Excel.XlBorderWeight.xlThin
        '''            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        '''        End With
        '''        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
        '''            .LineStyle = Excel.XlLineStyle.xlContinuous
        '''            .Weight = Excel.XlBorderWeight.xlThin
        '''            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        '''        End With
        '''        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
        '''            .LineStyle = Excel.XlLineStyle.xlContinuous
        '''            .Weight = Excel.XlBorderWeight.xlThin
        '''            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        '''        End With
        '''        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
        '''            .LineStyle = Excel.XlLineStyle.xlContinuous
        '''            .Weight = Excel.XlBorderWeight.xlThin
        '''            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        '''        End With
        '''        '************************************************
        '''        'Add report header
        '''        objSheet.Range("A1:C1").Select()
        '''        With objExcel.Selection
        '''            .MergeCells = True
        '''            .HorizontalAlignment = Excel.Constants.xlLeft
        '''            .font.bold = True
        '''            .Font.Size = 16
        '''            .Font.Name = "Microsoft Sans Serif"
        '''            .Font.ColorIndex = 11
        '''        End With
        '''        objExcel.Application.Cells(1, 1).Value = "Pallet Discrepancy Report"
        '''        '************************************************
        '''        'ADD FOOTER

        '''        'Pallet Descrepency
        '''        i += 3
        '''        If strPalletDesMsg <> "" Then
        '''            objSheet.Range("A" & i & ":C" & i).Select()
        '''            With objExcel.Selection
        '''                .MergeCells = True
        '''                .HorizontalAlignment = Excel.Constants.xlLeft
        '''                .font.bold = True
        '''                .Font.Size = 11
        '''                .Font.Name = "Tahoma"
        '''                '.Font.ColorIndex = 11
        '''            End With
        '''            objExcel.Application.Cells(i, 1).Value = strPalletDesMsg
        '''        End If


        '''        'No boxes for Pallet
        '''        i += 1
        '''        If strNoBoxPallet <> "" Then
        '''            objSheet.Range("A" & i & ":C" & i).Select()
        '''            With objExcel.Selection
        '''                .MergeCells = True
        '''                .HorizontalAlignment = Excel.Constants.xlLeft
        '''                .font.bold = True
        '''                .Font.Size = 11
        '''                .Font.Name = "Tahoma"
        '''                '.Font.ColorIndex = 11
        '''            End With
        '''            objExcel.Application.Cells(i, 1).Value = strNoBoxPallet
        '''        End If
        '''        '************************************************
        '''        'Fit to page
        '''        With objExcel.ActiveSheet.PageSetup
        '''            .PrintTitleRows = ""
        '''            .PrintTitleColumns = ""
        '''        End With
        '''        objExcel.ActiveSheet.PageSetup.PrintArea = ""
        '''        With objExcel.ActiveSheet.PageSetup
        '''            .LeftHeader = ""
        '''            .CenterHeader = ""
        '''            .RightHeader = ""
        '''            .LeftFooter = ""
        '''            .CenterFooter = ""
        '''            .RightFooter = ""
        '''            .LeftMargin = objExcel.Application.InchesToPoints(0.25)
        '''            .RightMargin = objExcel.Application.InchesToPoints(0.25)
        '''            .TopMargin = objExcel.Application.InchesToPoints(0.5)
        '''            .BottomMargin = objExcel.Application.InchesToPoints(0.5)
        '''            .HeaderMargin = objExcel.Application.InchesToPoints(0.5)
        '''            .FooterMargin = objExcel.Application.InchesToPoints(0.5)
        '''            .PrintHeadings = False
        '''            .PrintGridlines = False
        '''            '.PrintQuality = 600
        '''            .CenterHorizontally = False
        '''            .CenterVertically = False
        '''            .Orientation = Excel.XlPageOrientation.xlLandscape
        '''            .Draft = False
        '''            '.PaperSize = Excel.XlPaperSize.xlPaperLetter
        '''            '.BlackAndWhite = False
        '''            .Zoom = False
        '''            .FitToPagesWide = 1
        '''            .FitToPagesTall = 1
        '''        End With


        '''        '************************************************
        '''        'Save the excel file
        '''        Directory.CreateDirectory(strDir)
        '''        strFilePath = strDir & strPallett & " " & Format(Now, "MM-dd-yyyy HH-mm-ss") & ".xls"
        '''        objBook.SaveAs(strFilePath)
        '''        File.SetAttributes(strFilePath, FileAttributes.ReadOnly)
        '''        '*************************************
        '''        'Excel clean up
        '''        If Not IsNothing(objSheet) Then
        '''            NAR(objSheet)
        '''            objSheet = Nothing
        '''        End If
        '''        If Not IsNothing(objBook) Then
        '''            objBook.Close(False)
        '''            NAR(objBook)
        '''            objBook = Nothing
        '''        End If
        '''        If Not IsNothing(objExcel) Then
        '''            objExcel.Quit()
        '''            NAR(objExcel)
        '''            objExcel = Nothing
        '''        End If
        '''        '*************************************
        '''        'Open Excel File
        '''        objXL = New Excel.Application()
        '''        objXL.Workbooks.Open(strFilePath)
        '''        objXL.Visible = True
        '''        '******************************************
        '''    Catch ex As Exception
        '''        Throw ex
        '''    Finally
        '''        '''Excel clean up
        '''        If Not IsNothing(objSheet) Then
        '''            NAR(objSheet)
        '''        End If
        '''        If Not IsNothing(objBook) Then
        '''            objBook.Close(False)
        '''            NAR(objBook)
        '''        End If
        '''        If Not IsNothing(objExcel) Then
        '''            objExcel.Quit()
        '''            NAR(objExcel)
        '''        End If
        '''    End Try
        '''End Function

        '**************************************************************************
        'lan add Cust_id parameter
        '**************************************************************************
        Public Function ClosePallet(ByVal strPallett As String, ByVal iDescrpType As Integer, _
                                    ByVal iCust_id As Integer, _
                                    ByVal iMachineGroup_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                strsql = "Update twarehousepallet set WHPallet_Descrepency = " & Environment.NewLine
                strsql &= iDescrpType & ", WHPalletClosed = 1 " & Environment.NewLine
                strsql &= "where WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "Cust_id = " & iCust_id & ";"

                objMisc._SQL = strsql
                Return objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '***********************************************************************
        'lan add iCust_id parameter
        '***********************************************************************
        Public Function GetPhonesInFileNotOnPallet(ByVal iParentGroupID As Integer, _
                                                ByVal strPallet As String, _
                                                ByVal iCust_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim R1, R2 As DataRow
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strPrevIMEI As String = ""
            Dim booResult As Boolean = False

            Try
                strsql = "Select twarehousepalletload.WHP_ID, twarehousepalletload.WHP_PieceIdentifier, twarehousepalletload.WHPallet_ID, twarehousepalletload.WHP_Duplicate,twarehousepallet.WHPallet_NoBox " & Environment.NewLine
                strsql &= "from twarehousepalletload  " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHPallet_Number = '" & strPallet & "' and " & Environment.NewLine
                'lan add
                strsql &= "twarehousepallet.Cust_ID = " & iCust_id & " and " & Environment.NewLine
                strsql &= "twarehousepallet.WHPalletClosed = 1 and " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_RcvdFlag = 8 order by WHP_PieceIdentifier;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    '*********************************************************
                    'i = AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , , iParentGroupID, R1("WHP_ID"))
                    i = AddRemoveFromWarehouseWIP(R1("WHPallet_NoBox"), Trim(R1("WHP_PieceIdentifier")), R1("WHPallet_ID"), iParentGroupID)
                    '*********************************************************
                    If strPrevIMEI <> Trim(R1("WHP_PieceIdentifier")) Then
                        '*****************************************************
                        'Insert into twarehousereceive
                        strsql = ""
                        strsql = "Insert into twarehousereceive " & Environment.NewLine
                        strsql &= "(WHR_Box_SN, WHR_Dev_SN, WHR_InFile_NotOnPallet, WHR_WIPOwner, WHR_Result, WHR_DateLoaded, WHR_DupInFile, WHPallet_ID) " & Environment.NewLine
                        strsql &= "values (" & Environment.NewLine
                        strsql &= "'" & Trim(R1("WHP_PieceIdentifier")) & "', " & Environment.NewLine
                        strsql &= "'" & Trim(R1("WHP_PieceIdentifier")) & "', " & Environment.NewLine
                        strsql &= "1, " & Environment.NewLine
                        strsql &= iParentGroupID & ", " & Environment.NewLine
                        strsql &= "1, " & Environment.NewLine
                        strsql &= "'" & strDate & "', " & Environment.NewLine
                        strsql &= R1("WHP_Duplicate") & ", " & Environment.NewLine
                        strsql &= R1("WHPallet_ID") & ");"
                        objMisc._SQL = strsql
                        i += objMisc.ExecuteNonQuery
                        'Select the last inserted whr_id
                        '*****************************************************
                        'strsql = "Select whr_id from twarehousereceive where WHR_Box_SN = '" & Trim(R1("WHP_PieceIdentifier")) & "' and WHR_InFile_NotOnPallet = 1 and whpallet_id = " & R1("WHPallet_ID") & ";"
                        'LAN CHANGE 10/19/2006
                        If R1("WHPallet_NoBox") = 1 Then
                            strsql = "Select whr_id from twarehousereceive where WHR_Dev_SN = '" & Trim(R1("WHP_PieceIdentifier")) & "' and WHR_InFile_NotOnPallet = 1 and whpallet_id = " & R1("WHPallet_ID") & ";"
                        Else
                            strsql = "Select whr_id from twarehousereceive where WHR_Box_SN = '" & Trim(R1("WHP_PieceIdentifier")) & "' and WHR_InFile_NotOnPallet = 1 and whpallet_id = " & R1("WHPallet_ID") & ";"
                        End If
                        '*****************************************************

                        objMisc._SQL = strsql
                        dt2 = objMisc.GetDataTable
                        If dt2.Rows.Count Then
                            R2 = dt2.Rows(0)
                            iWHR_ID = R2("WHR_ID")
                        End If
                        If iWHR_ID = 0 Then
                            Throw New Exception("WHR_ID could not be determined.")
                        Else
                            'Discrepancy Report
                            booResult = createDiscrepantReport(iWHR_ID, iCust_id, iParentGroupID)
                        End If
                        '*****************************************************
                        R2 = Nothing
                        If Not IsNothing(dt2) Then
                            dt2.Dispose()
                            dt2 = Nothing
                        End If
                        '*********************
                    End If

                    'i = AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , , iParentGroupID, R1("WHP_ID"))
                    strPrevIMEI = Trim(R1("WHP_PieceIdentifier"))
                Next R1


                '**************************
                'Added by Lan on 05/07/07
                ' Move all device out from warehouse
                If iCust_id = 2019 Then
                    strsql = "select * from twarehousepallet where WHPallet_Number = '" & strPallet & "' and cust_id = " & iCust_id & ";"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        strsql = "update twarehousepalletload set WHP_RcvdFlag = " & iParentGroupID & " where WHP_RcvdFlag = 8 and WHPallet_ID = " & dt1.Rows(0)("whpallet_id") & ";"
                        objMisc._SQL = strsql
                        i = objMisc.ExecuteNonQuery
                    End If
                End If
                '**************************

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*************************************************************
        'lan ad iCustomeer id parameter
        '*************************************************************
        Public Function GetAcceptedRejectedDevices(ByVal strPallett As String, _
                                                    ByVal iAcceptOrReject As Integer, _
                                                    ByVal iCust_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                strsql = "Select Count(*) as cnt from twarehousereceive " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepallet.WHPallet_ID = twarehousereceive.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousereceive.WHR_Result = " & iAcceptOrReject & " and " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number  = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"  'lan add
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    i = R1("cnt")
                End If
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        'lan add this function: get Good,Bad or Scrap devices
        '*******************************************************************
        Public Function GetGoodBadScrapDevices(ByVal strChildPallett As String, _
                                                ByVal iBadGoodScrap As Integer, _
                                                ByVal iCust_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                strsql = "Select Count(*) as cnt from twarehousereceive " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepallet.WHPallet_ID = twarehousereceive.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousereceive.WHR_DevCondition = " & iBadGoodScrap & " and " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number  = '" & strChildPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.whpallet_id = " & Me.iChildPalletID & " and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    i = R1("cnt")
                End If
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        'lan add this function: get devices had no SN
        '*******************************************************************
        Public Function GetDevicesNoSN(ByVal strPallett As String, _
                                        ByVal iCust_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                strsql = "SELECT count(*) as cnt  FROM twarehousepalletload " & Environment.NewLine
                strsql &= "INNER JOIN twarehousepallet ON twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strsql &= "WHERE twarehousepalletload.WHP_PieceIdentifier like 'na%' " & " and " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number  = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    i = R1("cnt")
                End If
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '*******************************************************************
        'lan add iCust_id parameter
        '*******************************************************************
        Public Function GetDevCountFromLoadedFile(ByVal strPallett As String, _
                                                  ByVal iCust_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim R1, R2 As DataRow

            Try
                If iCust_id = 2219 Then
                    strsql = "Select twarehousepallet.WHPallet_NoBox, twarehousepalletload.* " & Environment.NewLine
                    strsql &= "from twarehousepallet " & Environment.NewLine
                    strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                    strsql &= "where twarehousepallet.WHPalletClosed = 0 and " & Environment.NewLine
                    strsql &= "twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                    strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"  'lan add cust_id

                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        strsql = "Select * " & Environment.NewLine
                        strsql &= "from twarehousepallet " & Environment.NewLine
                        strsql &= "where twarehousepallet.WHPalletClosed = 0 and " & Environment.NewLine
                        strsql &= "twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                        strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"  'lan add cust_id

                        objMisc._SQL = strsql
                        dt1 = objMisc.GetDataTable
                        If dt1.Rows.Count = 0 Then
                            Throw New Exception("Pallet was not loaded in to the system by the warehouse personnel.")
                        Else
                            R1 = dt1.Rows(0)
                            iPalletID = R1("whpallet_ID")
                            iWHPallet_NoBox = R1("WHPallet_NoBox")
                            i = 0
                        End If
                    Else
                        R1 = dt1.Rows(0)
                        iPalletID = R1("whpallet_ID")
                        iWHPallet_NoBox = R1("WHPallet_NoBox")
                        i = dt1.Rows.Count
                    End If

                    Return i
                Else
                    'strsql = "Select Count(*) as cnt from twarehousepalletLoad where WHP_BinLocation = '" & strPallett & "';"
                    'strsql = "Select * from twarehousepalletLoad where WHP_BinLocation = '" & strPallett & "';"

                    strsql = "Select twarehousepallet.WHPallet_NoBox, twarehousepalletload.* " & Environment.NewLine
                    strsql &= "from twarehousepallet " & Environment.NewLine
                    strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                    strsql &= "where twarehousepallet.WHPalletClosed = 0 and " & Environment.NewLine
                    strsql &= "twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                    strsql &= "twarehousepallet.Cust_id = " & iCust_id & ";"  'lan add cust_id

                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Pallet was not loaded in to the system by the warehouse personnel.")
                    Else
                        R1 = dt1.Rows(0)
                        iPalletID = R1("whpallet_ID")
                        iWHPallet_NoBox = R1("WHPallet_NoBox")
                        i = dt1.Rows.Count
                    End If

                    Return i
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        'lan add iCust_id and iDev_billCode parameter
        '*******************************************************************
        Public Function ProcessSerialNumbers(ByVal iParentGroupID As Integer, _
                                            ByVal iUserID As Integer, _
                                            ByVal strPallett As String, _
                                            ByVal strBoxSN As String, _
                                            ByVal strDevSN As String, _
                                            ByVal iEmptyBox As Integer, _
                                            ByVal iNoBoxForPallet As Integer, _
                                            ByVal iWrongSKU As Integer, _
                                            ByVal iCust_id As Integer, _
                                            ByVal iDev_billcode As Integer, _
                                            ByVal iDevNoSN As Integer, _
                                            Optional ByVal iMultiplePhones As Integer = 0) As Integer

            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim R1, R2 As DataRow
            Dim iResult As Integer = 0

            Dim iBoxSN_Absent_in_File As Integer = 1
            Dim iDevSN_BoxSN_Different As Integer = 1
            Dim iDevSN_Absent_in_File As Integer = 1
            Dim iBoxSN_Duplicate_in_File As Integer = 0
            Dim iDevSN_Duplicate_in_File As Integer = 0
            Dim booResult As Boolean = False
            Dim booNoSNResult As Integer = 0

            Dim iPallet_ID As Integer = 0

            Try
                strBoxSN = UCase(strBoxSN)
                strDevSN = UCase(strDevSN)

                '--------------------------------
                'lan add
                If iCust_id = 2219 And iDevNoSN = 1 Then
                    If MessageBox.Show("Are you sure you want to relabel this device?", "Relabel SN", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Exit Function
                    End If

                    booNoSNResult = UpdateSN(strDevSN, iCust_id, strPallett)
                    If booNoSNResult = 0 Then
                        Throw New Exception("Can not replace new SN to an 'NA' serial number." & Environment.NewLine)
                    ElseIf booNoSNResult = -1 Then
                        Throw New Exception("No more 'NA' serial number in the system to relabel." & Environment.NewLine)
                    ElseIf booNoSNResult = -9 Then
                        Throw New Exception("New serial number already existed in this lot and skid. Can not replace it with any NA serial number.")
                    ElseIf booNoSNResult = -99 Then
                        Throw New Exception("New SN (" & strDevSN & ") already existed in the system(Tdevice) with an open ship date. Can not replace it with any 'NA' serial number. Try a different SN.")
                    End If
                End If
                '--------------------------------


                If iNoBoxForPallet = 0 Then     'All phones in Pallet have boxes
                    '*********************
                    'Step 1: Check if the Box SN and Dev SN are the same
                    If strBoxSN = strDevSN And iEmptyBox = 0 And iMultiplePhones = 0 Then
                        iDevSN_BoxSN_Different = 0
                    End If
                    '*********************
                    'Step 2 : Get Devices loaded from the file
                    strsql = "Select twarehousepalletload.* from twarehousepallet inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID where twarehousepallet.WHPallet_Number = '" & strPallett & "' and twarehousepallet.Cust_ID = " & iCust_id & ";"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Serial Number does not exist.")
                    End If
                    R1 = dt1.Rows(0)
                    iPallet_ID = R1("WHPallet_ID")
                    R1 = Nothing
                    '*********************
                    'Step 3: Check if the Box Number exists in the file/Database
                    For Each R1 In dt1.Rows
                        If strBoxSN = Trim(R1("WHP_PieceIdentifier")) Then
                            iBoxSN_Absent_in_File = 0       'iBoxSN_Absent_in_File = 0 means Matched; iBoxSN_Absent_in_File = 1 means did not match
                            If R1("WHP_Duplicate") = 1 Then
                                iBoxSN_Duplicate_in_File = 1
                            Else
                                iBoxSN_Duplicate_in_File = 0
                            End If
                        End If
                    Next R1
                    '*********************
                    'WHR_Result  (Accepted or Rejected)
                    If iBoxSN_Duplicate_in_File = 1 Or iBoxSN_Absent_in_File = 1 Or iEmptyBox = 1 Or iDevSN_BoxSN_Different = 1 Or iWrongSKU = 1 Or iMultiplePhones = 1 Then
                        iResult = 1
                    End If

                    '********************************************************
                    'Lan add 11/06/2006
                    'check if SN already exist in tdevice with open ship date
                    If iResult <> 1 Then
                        If CheckOpenShipDtSN(strDevSN, iCust_id) = True Then
                            Throw New Exception("This device SN (" & strDevSN & ") already existed in Tdevice table with an open ship date.")
                        End If
                    End If
                    '********************************************************


                    ''Discrepancy Report
                    If iResult = 1 Then
                        'Dim response As MsgBoxResult
                        'response = MsgBox("This device is rejected for some reason. Are you sure you want to add it into the system as a discrepancy?", MsgBoxStyle.YesNo, "Discrepant Device")

                        'If response = MsgBoxResult.No Then
                        '    Exit Function
                        'End If

                        '************************************************Lan 10/31/2006
                        If iCust_id = 2219 Then
                            If iDevSN_Absent_in_File = 1 Then
                                iResult = 0
                                Throw New Exception("Box serial number does not exist.")
                            ElseIf iBoxSN_Duplicate_in_File = 1 Then
                                iResult = 0
                                Throw New Exception("Box serial number was duplicate.")
                            Else
                                iResult = 0
                                Throw New Exception("This device is rejected for some reason but discrepancy does not allow for this customer.")
                            End If
                        Else
                            If MessageBox.Show("This device is rejected for some reason. Are you sure you want to add it into the system as a discrepancy?", "Discrepant Device", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                iResult = 0
                                Exit Function
                            End If
                        End If
                        '*************************************************Lan 10/31/2006
                    End If

                    '*********************
                    'Step 4: Insert a row in  to the database for the Device
                    strsql = ""
                    strsql = "Insert into twarehousereceive " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "WHR_Box_SN, " & Environment.NewLine
                    strsql += "WHR_Dev_SN, " & Environment.NewLine
                    strsql += "WHR_WIPOwner, " & Environment.NewLine
                    strsql += "User_ID, " & Environment.NewLine
                    strsql += "WHR_Box_Empty, " & Environment.NewLine
                    strsql += "WHR_Mutltiple_Phones_In_Box, " & Environment.NewLine
                    strsql += "WHR_WrongSKU, " & Environment.NewLine
                    strsql += "WHR_Result, " & Environment.NewLine
                    strsql += "WHR_DateLoaded, " & Environment.NewLine
                    strsql += "WHR_DevSN_BoxSN_Different, " & Environment.NewLine
                    strsql += "WHR_BoxSN_Absent_in_File, " & Environment.NewLine
                    strsql += "WHR_DupInFile, " & Environment.NewLine
                    strsql += "WHPallet_ID " & Environment.NewLine

                    '---------------------
                    'lan add
                    If iCust_id = 2219 Then
                        strsql += ", WHR_DevCondition " & Environment.NewLine()
                    End If
                    '---------------------

                    strsql += ") " & Environment.NewLine
                    strsql += "values (" & Environment.NewLine
                    strsql += "'" & UCase(Trim(strBoxSN)) & "', " & Environment.NewLine
                    strsql += "'" & UCase(Trim(strDevSN)) & "', " & Environment.NewLine
                    'If strDevSN <> "" Then
                    '    strsql += "'" & strDevSN & "', " & Environment.NewLine
                    'Else
                    '    strsql += "NULL, " & Environment.NewLine
                    'End If
                    strsql += iParentGroupID & ", " & Environment.NewLine
                    strsql += iUserID & ", " & Environment.NewLine
                    strsql += iEmptyBox & ", " & Environment.NewLine
                    strsql += iMultiplePhones & ", " & Environment.NewLine
                    strsql += iWrongSKU & ", " & Environment.NewLine
                    strsql += iResult & ", " & Environment.NewLine
                    strsql += "'" & strDate & "', " & Environment.NewLine
                    strsql += iDevSN_BoxSN_Different & ", " & Environment.NewLine
                    strsql += iBoxSN_Absent_in_File & ", " & Environment.NewLine
                    strsql += iBoxSN_Duplicate_in_File & ", " & Environment.NewLine
                    '//Added condition by Lan 12/06/2006
                    If iCust_id = 2219 Then
                        strsql += iChildPalletID & Environment.NewLine
                    Else
                        strsql += iPallet_ID & Environment.NewLine
                    End If

                    '-----------------------
                    'lan added
                    If iCust_id = 2219 Then
                        strsql += ", " & iDev_billcode & Environment.NewLine
                    End If
                    '-----------------------
                    strsql += ");"

                    'iWHR_ID = objMisc.idTransaction(strsql, "twarehousereceive")

                    '*****************************************************
                    '''This sections was added to replace idtransaction
                    ''to improve the performance
                    '*****************************************************
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery()

                    ''Select the last inserted whr_id
                    'strsql = "Select whr_id, WHPallet_ID from twarehousereceive where WHR_Box_SN = '" & strBoxSN & "' and whpallet_id = " & iPallet_ID & ";"
                    If iCust_id = 2219 Then
                        'Select the last inserted whr_id
                        strsql = "Select whr_id from twarehousereceive where WHR_Box_SN = '" & strBoxSN & "' and whpallet_id = " & iChildPalletID & ";"
                    Else
                        'Select the last inserted whr_id
                        strsql = "Select whr_id from twarehousereceive where WHR_Box_SN = '" & strBoxSN & "' and whpallet_id = " & iPallet_ID & ";"
                    End If
                    objMisc._SQL = strsql
                    dt2 = objMisc.GetDataTable
                    If dt2.Rows.Count Then
                        R2 = dt2.Rows(0)
                        iWHR_ID = R2("WHR_ID")
                    End If
                    If iWHR_ID = 0 Then
                        Throw New Exception("WHR_ID could not be determined.")
                    End If
                    '*****************************************************
                    'i = AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , iWHR_ID, iParentGroupID, )     'Remove one device from Warehouse WIP; Adds it to Triage WIP ; 5 is Group_ID for Triage Group
                    i = AddRemoveFromWarehouseWIP(iNoBoxForPallet, strBoxSN, iPallet_ID, iParentGroupID)
                    '*****************************************************
                    'this block added by Lan on 12/06/2006
                    If iCust_id = 2219 Then
                        i = MoveDeviceToSubPallet(strDevSN, iParentGroupID)
                    End If
                    '*****************************************************
                    'Discrepancy Report
                    If iWHR_ID > 0 And iResult = 1 Then
                        booResult = createDiscrepantReport(iWHR_ID, iCust_id, iParentGroupID)
                    End If
                    '*********************


                Else    'If iNoBoxForPallet = 1 then No box is there for the whole pallet

                    'WHR_Result  (Accepted or Rejected)
                    If iWrongSKU = 1 Then
                        iResult = 1
                    End If

                    '*********************
                    'Step 1 : Get Devices loaded from the file
                    strsql = "Select twarehousepalletload.* from twarehousepallet inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID where twarehousepallet.WHPallet_Number = '" & strPallett & "' and twarehousepallet.Cust_ID = " & iCust_id & ";"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Serial Number does not exist.")
                    End If
                    R1 = dt1.Rows(0)
                    iPallet_ID = R1("WHPallet_ID")
                    R1 = Nothing

                    'Step 2: Check if the Device SN exists in the file/database
                    For Each R1 In dt1.Rows
                        If strDevSN = Trim(R1("WHP_PieceIdentifier")) Then
                            iDevSN_Absent_in_File = 0       'iDevSN_Absent_in_File = 0 means Matched; iDevSN_Absent_in_File = 1 means did not match
                            If R1("WHP_Duplicate") = 1 Then
                                iDevSN_Duplicate_in_File = 1
                            Else
                                iDevSN_Duplicate_in_File = 0
                            End If
                        End If
                    Next R1

                    'WHR_Result  (Accepted or Rejected)
                    If iDevSN_Duplicate_in_File = 1 Or iDevSN_Absent_in_File = 1 Then       'Not in the file
                        iResult = 1                         'Rejected
                    End If


                    '********************************************************
                    'Lan add 11/06/2006
                    'check if SN already exist in tdevice with open ship date
                    If iResult <> 1 Then
                        If CheckOpenShipDtSN(strDevSN, iCust_id) = True Then
                            Throw New Exception("This device SN (" & strDevSN & ") already existed in Tdevice table with an open ship date.")
                        End If
                    End If
                    '********************************************************

                    'Discrepancy Report
                    If iResult = 1 Then
                        '''''Dim response As MsgBoxResult
                        '''''response = MsgBox("This device is rejected for some reason. Are you sure you want to add it into the system as a discrepancy?", MsgBoxStyle.YesNo, "Discrepant Device")

                        '''''If response = MsgBoxResult.No Then
                        '''''    Exit Function
                        '''''End If

                        '************************************************Lan 10/31/2006
                        If iCust_id = 2219 Then
                            If iDevSN_Absent_in_File = 1 Then
                                iResult = 0
                                Throw New Exception("Device serial number does not exist.")
                            ElseIf iDevSN_Duplicate_in_File = 1 Then
                                iResult = 0
                                Throw New Exception("Device serial number was duplicate.")
                            Else
                                iResult = 0
                                Throw New Exception("This device is rejected for some reason but discrepancy does not allow for this customer.")
                            End If
                        Else
                            If MessageBox.Show("This device is rejected for some reason. Are you sure you want to add it into the system as a discrepancy?", "Discrepant Device", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                iResult = 0
                                Exit Function
                            End If
                        End If
                        '*************************************************Lan 10/31/2006
                    End If

                    '*********************
                    'Step 3: Insert a row in to the database for the Device
                    strsql = ""
                    strsql = "Insert into twarehousereceive " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "WHR_Box_SN, " & Environment.NewLine
                    strsql += "WHR_Dev_SN, " & Environment.NewLine
                    strsql += "WHR_WIPOwner, " & Environment.NewLine
                    strsql += "User_ID, " & Environment.NewLine
                    strsql += "WHR_WrongSKU, " & Environment.NewLine
                    strsql += "WHR_DevSN_Absent_in_File, " & Environment.NewLine
                    strsql += "WHR_DupInFile, " & Environment.NewLine
                    strsql += "WHR_Result, " & Environment.NewLine
                    strsql += "WHR_DateLoaded, " & Environment.NewLine
                    strsql += "WHPallet_ID " & Environment.NewLine
                    '---------------------
                    'lan add
                    If iCust_id = 2219 Then
                        strsql += ", WHR_DevCondition " & Environment.NewLine()
                    End If
                    '---------------------
                    strsql += ") " & Environment.NewLine

                    strsql += "values (" & Environment.NewLine
                    'strsql += "NULL, " & Environment.NewLine
                    strsql += "'" & UCase(Trim(strBoxSN)) & "', " & Environment.NewLine
                    strsql += "'" & UCase(Trim(strDevSN)) & "', " & Environment.NewLine
                    strsql += iParentGroupID & ", " & Environment.NewLine
                    strsql += iUserID & ", " & Environment.NewLine
                    strsql += iWrongSKU & ", " & Environment.NewLine
                    strsql += iDevSN_Absent_in_File & ", " & Environment.NewLine
                    strsql += iDevSN_Duplicate_in_File & ", " & Environment.NewLine
                    strsql += iResult & ", " & Environment.NewLine
                    strsql += "'" & strDate & "', " & Environment.NewLine

                    '//Added condition by Lan 12/06/2006
                    If iCust_id = 2219 Then
                        strsql += iChildPalletID & Environment.NewLine
                    Else
                        strsql += iPallet_ID & Environment.NewLine
                    End If
                    '-----------------------
                    'lan add
                    If iCust_id = 2219 Then
                        strsql += ", " & iDev_billcode & Environment.NewLine
                    End If
                    '-----------------------
                    strsql += ");"


                    'iWHR_ID = objMisc.idTransaction(strsql, "twarehousereceive")

                    '*****************************************************
                    '''This sections was added to replace idtransaction
                    ''to improve the performance
                    '*****************************************************
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery()

                    If iCust_id = 2219 Then
                        'Select the last inserted whr_id
                        strsql = "Select whr_id from twarehousereceive where WHR_Dev_SN = '" & strDevSN & "' and whpallet_id = " & iChildPalletID & ";"
                    Else
                        'Select the last inserted whr_id
                        strsql = "Select whr_id from twarehousereceive where WHR_Dev_SN = '" & strDevSN & "' and whpallet_id = " & iPallet_ID & ";"
                    End If

                    objMisc._SQL = strsql
                    dt2 = objMisc.GetDataTable
                    If dt2.Rows.Count Then
                        R2 = dt2.Rows(0)
                        iWHR_ID = R2("WHR_ID")
                    End If
                    If iWHR_ID = 0 Then
                        Throw New Exception("WHR_ID could not be determined.")
                    End If
                    '*****************************************************
                    'i = AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , iWHR_ID, iParentGroupID, )     'Remove one device from Warehouse WIP; Adds it to Triage WIP ; 5 is Group_ID for Triage Group
                    i = AddRemoveFromWarehouseWIP(iNoBoxForPallet, strDevSN, iPallet_ID, iParentGroupID)      'Remove one device from Warehouse WIP; Adds it to Triage WIP ; 5 is Group_ID for Triage Group
                    '*****************************************************
                    'this block added by Lan on 12/06/2006
                    If iCust_id = 2219 Then
                        i = MoveDeviceToSubPallet(strDevSN, iParentGroupID)
                    End If
                    '*****************************************************
                    'Discrepancy Report
                    If iWHR_ID > 0 And iResult = 1 Then
                        booResult = createDiscrepantReport(iWHR_ID, iCust_id, iParentGroupID)
                    End If
                    '*********************
                End If

                '*****************************************
                Return iResult      '(0 - No Descrepencies;; 1 - Descrepencies
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R2 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                iGlobalResult = iResult
            End Try
        End Function

        '*******************************************************************************
        'Lan add this function to update SN has value NA to a new SN (for Gamestop only)
        '*******************************************************************************
        Private Function UpdateSN(ByVal strDevSN As String, _
                                  ByVal iCust_id As Integer, _
                                  ByVal strPallett As String) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iDup_WHP_id As Integer = 0
            Dim iNA_WHP_id As Integer = 0
            Dim iDupFlg As Integer = 0

            Try
                ''check if SN exist in tdevice with open shipdate  11/06/2006
                Dim blnResult As Boolean
                blnResult = Me.CheckOpenShipDtSN(strDevSN, iCust_id)   'true: device exist in tdevice with shipdate = null
                If blnResult = True Then
                    'MessageBox.Show("The new SN already exist in the system with open ship date.", "Change SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return -99
                End If


                'Get all data in Excel file
                strsql = "Select twarehousepalletload.* " & Environment.NewLine
                strsql &= "from twarehousepallet " & Environment.NewLine
                strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_ID = " & iCust_id & Environment.NewLine
                'strsql &= "twarehousepalletload.WHP_PieceIdentifier like 'NA%' " & Environment.NewLine
                strsql &= "order by twarehousepalletload.WHP_PieceIdentifier asc;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                'Get 1st Serial Number has value like NA
                '-------------------------
                For Each R1 In dt1.Rows
                    If Mid(R1("WHP_PieceIdentifier"), 1, 2) = "NA" Then
                        iNA_WHP_id = R1("WHP_ID")
                        Exit For
                    End If
                Next R1
                '--------------------------

                If iNA_WHP_id = 0 Then
                    Return -1
                End If
                R1 = Nothing

                'check for duplicate
                '--------------------
                For Each R1 In dt1.Rows
                    If R1("WHP_PieceIdentifier") = strDevSN Then
                        iDup_WHP_id = R1("WHP_ID")
                        iDupFlg = 1
                        Exit For
                    End If
                Next R1
                '--------------------
                If iDupFlg = 1 Then
                    '''''''''set duplicate flag in twarehousepalletload
                    ''''''''strsql = "UPDATE twarehousepalletload SET twarehousepalletload.WHP_Duplicate = 1" & Environment.NewLine
                    ''''''''strsql &= "WHERE twarehousepalletload.WHP_ID = " & iDup_WHP_id
                    ''''''''objMisc._SQL = strsql
                    ''''''''i = objMisc.ExecuteNonQuery

                    ''''''''i = 0

                    '''''''''set new PieceIdentifier to an NA serial number and set duplicate flag
                    ''''''''strsql = "UPDATE twarehousepalletload SET twarehousepalletload.WHP_Duplicate = 1, WHP_PieceIdentifier_Old = WHP_PieceIdentifier, WHP_PieceIdentifier = '" & strDevSN & "' " & Environment.NewLine
                    ''''''''strsql &= "WHERE twarehousepalletload.WHP_ID = " & iNA_WHP_id
                    ''''''''objMisc._SQL = strsql
                    ''''''''i = objMisc.ExecuteNonQuery

                    ''''''''Return i
                    Return -9   'new SN already exist.
                Else
                    i = 0

                    strsql = "UPDATE twarehousepalletload SET WHP_PieceIdentifier_Old = WHP_PieceIdentifier, WHP_PieceIdentifier = '" & strDevSN & "' " & Environment.NewLine
                    strsql &= "WHERE twarehousepalletload.WHP_ID = " & iNA_WHP_id
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery

                    Return i
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        'Public Function AddRemoveFromWarehouseWIP(ByVal iNoBox As Integer, _
        '                                        Optional ByVal iPallet_ID As Integer = 0, _
        '                                        Optional ByVal iWHR_ID As Integer = 0, _
        '                                        Optional ByVal iAddRemoveWIP As Integer = 5, _
        '                                        Optional ByVal iWHP_ID As Integer = 0) _
        '                                        As Integer
        '    Dim strsql As String = ""
        '    Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        '    'iAddRemoveWIP = 5 for Adding to Traige WIP and remove it from Warehouse WIP ;   5 is group_id for triage group
        '    'iAddRemoveWIP = 8 for removing from Traige WIP and adding it back to Warehouse WIP  ; 8 is group_id for warehouse group

        '    If Me.iPalletID > 0 Then
        '        strsql = "Update twarehousepalletload, twarehousereceive set twarehousepalletload.whp_rcvdFlag = " & iAddRemoveWIP & ", WHP_TraigeWIPEntryDt = '" & strDate & "' where twarehousepalletload.WHP_PieceIdentifier = twarehousereceive.WHR_Dev_SN and twarehousereceive.WHR_ID = " & iWHR_ID & " and twarehousepalletload.whpallet_id = " & Me.iPalletID & ";"
        '    ElseIf iWHR_ID > 0 Then
        '        'strsql = "Update twarehousepalletload inner join twarehousereceive on twarehousepalletload.WHP_PieceIdentifier = twarehousereceive.WHR_Dev_SN set whp_rcvdFlag = " & iAddRemoveWIP & " where twarehousereceive.WHR_ID = " & iWHR_ID & ";"
        '        'strsql = "Update twarehousepalletload, twarehousereceive set twarehousepalletload.whp_rcvdFlag = " & iAddRemoveWIP & ", WHP_TraigeWIPEntryDt = '" & strDate & "' where twarehousepalletload.WHP_PieceIdentifier = twarehousereceive.WHR_Box_SN and twarehousereceive.WHR_ID = " & iWHR_ID & ";"
        '        'LAN CHANGE THIS
        '        If iNoBox = 1 Then
        '            strsql = "Update twarehousepalletload, twarehousereceive set twarehousepalletload.whp_rcvdFlag = " & iAddRemoveWIP & ", WHP_TraigeWIPEntryDt = '" & strDate & "' where twarehousepalletload.WHP_PieceIdentifier = twarehousereceive.WHR_Dev_SN and twarehousereceive.WHR_ID = " & iWHR_ID & ";"
        '        Else
        '            strsql = "Update twarehousepalletload, twarehousereceive set twarehousepalletload.whp_rcvdFlag = " & iAddRemoveWIP & ", WHP_TraigeWIPEntryDt = '" & strDate & "' where twarehousepalletload.WHP_PieceIdentifier = twarehousereceive.WHR_Box_SN and twarehousereceive.WHR_ID = " & iWHR_ID & ";"
        '        End If

        '    ElseIf iWHP_ID > 0 Then
        '        strsql = "Update twarehousepalletload set whp_rcvdFlag = " & iAddRemoveWIP & ", WHP_TraigeWIPEntryDt = '" & strDate & "' where WHP_ID = " & iWHP_ID & ";"
        '    ElseIf iPallet_ID > 0 Then
        '        strsql = "Update twarehousepalletload set whp_rcvdFlag = " & iAddRemoveWIP & ", WHP_TraigeWIPEntryDt = '" & strDate & "' where whpallet_id = " & iPallet_ID & ";"
        '    End If

        '    Try
        '        objMisc._SQL = strsql
        '        Return objMisc.ExecuteNonQuery
        '    Catch ex As Exception
        '        Throw New Exception(ex.ToString)
        '    End Try
        'End Function

        Public Function AddRemoveFromWarehouseWIP(ByVal iNoBox As Integer, _
                                                  ByVal strSN As String, _
                                                  ByVal iWHPallet_ID As Integer, _
                                                  ByVal iAddRemoveWIP As Integer) _
                                                  As Integer
            Dim strsql As String = ""
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                strsql = "Update twarehousepalletload " & Environment.NewLine
                strsql &= "set whp_rcvdFlag = " & iAddRemoveWIP & ", " & Environment.NewLine
                strsql &= "WHP_TraigeWIPEntryDt = '" & strDate & "' " & Environment.NewLine
                strsql &= "where WHP_PieceIdentifier = '" & Trim(strSN) & "' " & Environment.NewLine
                strsql &= " and WHPallet_ID = " & iWHPallet_ID & ";"
                objMisc._SQL = strsql
                Return objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Function


        ''Public Function LoadFile(ByVal strPallett As String, _
        ''                        ByVal strFilePath As String, _
        ''                        ByVal iNoBoxForPallet As Integer) As Integer

        ''    Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
        ''    Dim objConn As New OleDbConnection()
        ''    Dim objCmdSelect As New OleDbCommand()
        ''    Dim objAdapter1 As New OleDbDataAdapter()
        ''    Dim dt1 As New DataTable()
        ''    Dim R1 As DataRow
        ''    Dim strsql As String = ""
        ''    Dim i As Integer = 0
        ''    'Dim iPalletID As Integer = 0
        ''    Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        ''    Try
        ''        iPalletID = 0
        ''        '****************************************************
        ''        'Check if the pallet is already loaded in to database
        ''        'strsql = "Select * from twarehousepalletLoad where WHP_BinLocation = '" & strPallett & "';"
        ''        strsql = "Select * from twarehousepallet where WHPallet_Number = '" & strPallett & "';"     ' and WHPalletClosed = 0
        ''        objMisc._SQL = strsql
        ''        dt1 = objMisc.GetDataTable

        ''        If dt1.Rows.Count > 0 Then
        ''            R1 = dt1.Rows(0)
        ''            iPalletID = R1("whpallet_ID")
        ''            If R1("WHPalletClosed") = 1 Then
        ''                Return -1       'Pallet has been loaded before and closed
        ''            ElseIf R1("WHPalletClosed") = 0 Then  'Pallet has been loaded before and not closed Yet
        ''                Return -9
        ''            End If
        ''        End If

        ''        '****************************************************
        ''        R1 = Nothing
        ''        If Not IsNothing(dt1) Then
        ''            dt1.Dispose()
        ''            dt1 = Nothing
        ''        End If
        ''        '****************************************************
        ''        'Pull data from the excel file
        ''        dt1 = New DataTable()
        ''        objConn.ConnectionString = sConnectionstring
        ''        objConn.Open()
        ''        objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]")
        ''        objCmdSelect.Connection = objConn
        ''        objAdapter1.SelectCommand = objCmdSelect
        ''        objAdapter1.Fill(dt1)

        ''        For Each R1 In dt1.Rows
        ''            '******************************************
        ''            'Insert Pallet in twarehousepallet table
        ''            If iPalletID = 0 Then
        ''                strsql = "Insert into twarehousepallet " & Environment.NewLine
        ''                strsql += "(" & Environment.NewLine
        ''                strsql += "WHPallet_Number, " & Environment.NewLine
        ''                strsql += "WHPallet_NoBox, " & Environment.NewLine
        ''                strsql += "WHDateLoaded " & Environment.NewLine
        ''                strsql += ") " & Environment.NewLine
        ''                strsql += "values (" & Environment.NewLine
        ''                strsql += "'" & Trim(R1("Bin Location")) & "', " & Environment.NewLine
        ''                strsql += iNoBoxForPallet & ", " & Environment.NewLine
        ''                strsql += "'" & strDate & "'" & Environment.NewLine
        ''                strsql += ");"

        ''                objMisc._SQL = strsql
        ''                iPalletID = objMisc.idTransaction(strsql, "twarehousepallet")
        ''            End If
        ''            '******************************************
        ''            'Load file in to twarehousepalletLoad table
        ''            strsql = ""
        ''            strsql = "Insert into twarehousepalletLoad " & Environment.NewLine
        ''            strsql += "(" & Environment.NewLine
        ''            strsql += "WHP_BinLocation, " & Environment.NewLine
        ''            strsql += "WHP_LoadNumber, " & Environment.NewLine
        ''            strsql += "WHP_PartNumber, " & Environment.NewLine
        ''            strsql += "WHP_PieceIdentifier, " & Environment.NewLine
        ''            strsql += "WHP_DateLoaded, " & Environment.NewLine
        ''            strsql += "WHP_RcvdFlag, " & Environment.NewLine
        ''            strsql += "WHPallet_ID " & Environment.NewLine
        ''            'iPalletID
        ''            strsql += ") " & Environment.NewLine
        ''            strsql += "values (" & Environment.NewLine
        ''            strsql += "'" & Trim(R1("Bin Location")) & "', " & Environment.NewLine
        ''            strsql += "'" & Trim(R1("Load Number")) & "', " & Environment.NewLine
        ''            strsql += "'" & Trim(R1("Part Number")) & "', " & Environment.NewLine
        ''            strsql += "'" & Trim(R1("Piece Identifier")) & "', " & Environment.NewLine
        ''            strsql += "'" & strDate & "', " & Environment.NewLine
        ''            strsql += 8 & ", " & Environment.NewLine        'By Default Warehouse Group takes ownership of this 
        ''            strsql += iPalletID & Environment.NewLine
        ''            strsql += ");"

        ''            objMisc._SQL = strsql
        ''            i += objMisc.ExecuteNonQuery
        ''            '******************************************
        ''        Next R1

        ''        Return i
        ''    Catch ex As Exception
        ''        Throw ex
        ''    Finally
        ''        R1 = Nothing
        ''        If Not IsNothing(dt1) Then
        ''            dt1.Dispose()
        ''            dt1 = Nothing
        ''        End If

        ''        If Not IsNothing(objConn) Then
        ''            objConn.Close()
        ''            objConn.Dispose()
        ''            objConn = Nothing
        ''        End If
        ''        If Not IsNothing(objCmdSelect) Then
        ''            objCmdSelect.Dispose()
        ''            objCmdSelect = Nothing
        ''        End If
        ''        If Not IsNothing(objAdapter1) Then
        ''            objAdapter1.Dispose()
        ''            objAdapter1 = Nothing
        ''        End If

        ''    End Try

        ''End Function

        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '******************************** LAN ***********************************
        'reject a accepted device
        Public Function RejectDeviceForWrongSKU(ByVal strDeviceSN As String, _
                                                ByVal iCust_id As Integer, _
                                                ByVal iParentGroup_id As Integer) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim iWHRid As Integer = 0
            Dim dt1 As DataTable

            Try
                If iPalletID = 0 Then
                    Throw New Exception("Pallet ID is not determined.")
                End If

                'Get WHR_id
                strsql = "select * from twarehousereceive where WHPallet_ID = " & iPalletID & " and WHR_Dev_SN = '" & strDeviceSN & "';"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iWHRid = dt1.Rows(0)("WHR_id")

                    'discrepant the device
                    strsql = "Update twarehousereceive set WHR_WrongSKU = 1, WHR_Result = 1 where WHPallet_ID = " & iPalletID & " and WHR_Dev_SN = '" & strDeviceSN & "' and WHR_id = " & iWHRid & ";"
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery

                    'create discrepancy report
                    Me.createDiscrepantReport_ATCLE(iWHRid, iCust_id, iParentGroup_id)
                    Return i
                Else
                    Throw New Exception("Device SN does not exist or may not receive.")
                End If


            Catch ex As Exception
                Throw New Exception("Buisness.Warehouse.RejectDeviceForWrongSKU: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        Public Function LoadFileDock(ByVal strPallett As String, _
                                ByVal strFilePath As String, _
                                ByVal iNoBoxForPallet As Integer, _
                                ByVal intCountedQty As Integer, _
                                ByVal intFileQty As Integer, _
                                ByVal arrDup() As String, _
                                ByVal intModelID As Integer, _
                                ByVal strPalletType As String, _
                                ByVal iCust_id As Integer, _
                                ByVal dtIMEI As DataTable) As Integer

            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim iSku_id As Integer = 0

            Try
                iPalletID = 0
                '****************************************************
                'Check if the pallet is already loaded in to database
                'strsql = "Select * from twarehousepalletLoad where WHP_BinLocation = '" & strPallett & "';"


                '''LAN add Cust_ID to where clause in the following query
                strsql = "Select * from twarehousepallet where WHPallet_Number = '" & strPallett & "' and Cust_id = " & iCust_id & ";"     ' and WHPalletClosed = 0
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iPalletID = R1("whpallet_ID")
                    If R1("WHPalletClosed") = 1 Then
                        Return -1       'Pallet has been loaded before and closed
                    ElseIf R1("WHPalletClosed") = 0 Then  'Pallet has been loaded before and not closed Yet
                        Return -9
                    End If
                End If

                '****************************************************
                '''LAN Add a new code segment here that checks if the odel has a SKU assigned
                '''if not create a new SKU. Parameters SKU_Number, Cust_ID, Model_ID
                If iCust_id = 2219 Then
                    iSku_id = ValidateOrInsertSku(iCust_id, intModelID, strFilePath)
                    If iSku_id = 0 Then
                        Throw New Exception(Environment.NewLine & "Fail to insert a new entry to tsku table." & Environment.NewLine)
                    ElseIf iSku_id = -99 Then
                        Throw New Exception(Environment.NewLine & "Sku from excel file does not match with the one in PSS Database." & Environment.NewLine)
                    End If
                End If
                '****************************************************


                '''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                '''LAN : Put it in a seperate function for each customer
                Select Case iCust_id
                    Case 2019   'ATCLE
                        i = LoadFileDock_ATCLE(strFilePath, _
                                               iNoBoxForPallet, _
                                               intCountedQty, _
                                               intFileQty, _
                                               arrDup, _
                                               intModelID, _
                                               strPalletType, _
                                               iCust_id, _
                                               dtIMEI)
                    Case 2219   'Game Stop
                        i = LoadFileDock_GameStop(strFilePath, _
                                               iNoBoxForPallet, _
                                               intCountedQty, _
                                               intFileQty, _
                                               arrDup, _
                                               intModelID, _
                                               strPalletType, _
                                               iCust_id, iSku_id, _
                                               dtIMEI)
                    Case 2249
                        i = LoadFileDock_HTC(strFilePath, _
                                               iNoBoxForPallet, _
                                               intCountedQty, _
                                               intFileQty, _
                                               arrDup, _
                                               intModelID, _
                                               strPalletType, _
                                               iCust_id, _
                                               dtIMEI)

                    Case Else
                        'never happen
                End Select
                Return i
                'Pull data from the excel file
                '''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            Catch ex As Exception
                Throw ex
                'MsgBox(ex) 'cdh
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtIMEI) Then
                    dtIMEI.Dispose()
                    dtIMEI = Nothing
                End If
            End Try
        End Function


        '**********************************************************************
        Private Function LoadFileDock_ATCLE(ByVal strFilePath As String, _
                                ByVal iNoBoxForPallet As Integer, _
                                ByVal intCountedQty As Integer, _
                                ByVal intFileQty As Integer, _
                                ByVal arrDup() As String, _
                                ByVal intModelID As Integer, _
                                ByVal strPalletType As String, _
                                ByVal iCust_id As Integer, _
                                ByVal dt1 As DataTable) As Integer
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim i As Integer = 0
            'Dim iPalletID As Integer = 0
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim mDuplicate As Integer = 0
            Dim x As Integer = 0

            Try
                For Each R1 In dt1.Rows
                    '******************************************
                    'Insert Pallet in twarehousepallet table
                    If iPalletID = 0 Then
                        strsql = "Insert into twarehousepallet " & Environment.NewLine
                        strsql += "(" & Environment.NewLine
                        strsql += "WHPallet_Number, " & Environment.NewLine
                        strsql += "WHPallet_NoBox, " & Environment.NewLine
                        strsql += "WHDateLoaded, " & Environment.NewLine
                        strsql += "WHP_CountedQty, " & Environment.NewLine
                        strsql += "WHP_FileQty, " & Environment.NewLine
                        strsql += "Model_ID, " & Environment.NewLine
                        strsql += "Cust_ID, " & Environment.NewLine    'lan add Cust_ID
                        strsql += "WH_PalletType " & Environment.NewLine
                        strsql += ") " & Environment.NewLine
                        strsql += "values (" & Environment.NewLine
                        strsql += "'" & Trim(R1("Bin Location")) & "', " & Environment.NewLine
                        strsql += iNoBoxForPallet & ", " & Environment.NewLine
                        strsql += "'" & strDate & "', " & Environment.NewLine
                        strsql += intCountedQty & ", " & Environment.NewLine
                        strsql += intFileQty & ", " & Environment.NewLine
                        strsql += intModelID & ", " & Environment.NewLine
                        strsql += iCust_id & ", " & Environment.NewLine   'lan add Cust_ID
                        strsql += "'" & strPalletType & "'" & Environment.NewLine
                        strsql += ");"

                        objMisc._SQL = strsql
                        iPalletID = objMisc.idTransaction(strsql, "twarehousepallet")
                    End If
                    '******************************************

                    mDuplicate = 0
                    '//Duplicate Devices Assignment
                    Try
                        For x = 0 To UBound(arrDup)
                            If Trim(arrDup(x)) = Trim(R1("Piece Identifier")) Then
                                mDuplicate = 1
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                    '//Duplicate Devices Assignment

                    'Load file in to twarehousepalletLoad table
                    strsql = ""
                    strsql = "Insert into twarehousepalletLoad " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "WHP_BinLocation, " & Environment.NewLine
                    strsql += "WHP_LoadNumber, " & Environment.NewLine
                    strsql += "WHP_PartNumber, " & Environment.NewLine
                    strsql += "WHP_ClientID, " & Environment.NewLine
                    strsql += "WHP_PieceIdentifier, " & Environment.NewLine
                    strsql += "WHP_DateLoaded, " & Environment.NewLine
                    strsql += "WHP_RcvdFlag, " & Environment.NewLine
                    strsql += "WHPallet_ID, " & Environment.NewLine
                    strsql += "WHP_Duplicate " & Environment.NewLine
                    'iPalletID
                    strsql += ") " & Environment.NewLine
                    strsql += "values (" & Environment.NewLine
                    strsql += "'" & Trim(R1("Bin Location")) & "', " & Environment.NewLine
                    strsql += "'" & Trim(R1("Load Number")) & "', " & Environment.NewLine
                    strsql += "'" & Trim(R1("Part Number")) & "', " & Environment.NewLine
                    strsql += "'" & Trim(R1("Part Client ID")) & "', " & Environment.NewLine
                    strsql += "'" & Trim(R1("Piece Identifier")) & "', " & Environment.NewLine
                    strsql += "'" & strDate & "', " & Environment.NewLine
                    strsql += 8 & ", " & Environment.NewLine        'By Default Warehouse Group takes ownership of this 
                    strsql += iPalletID & ", " & Environment.NewLine
                    strsql += mDuplicate & Environment.NewLine
                    strsql += ");"

                    objMisc._SQL = strsql
                    i += objMisc.ExecuteNonQuery
                    '******************************************
                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception("LoadFileDock_ATCLE():" & ex.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '************************************************************************
        Private Function LoadFileDock_GameStop(ByVal strFilePath As String, _
                                ByVal iNoBoxForPallet As Integer, _
                                ByVal intCountedQty As Integer, _
                                ByVal intFileQty As Integer, _
                                ByVal arrDup() As String, _
                                ByVal intModelID As Integer, _
                                ByVal strPalletType As String, _
                                ByVal iCust_id As Integer, _
                                ByVal iSku_id As Integer, _
                                ByVal dt1 As DataTable) As Integer
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim i As Integer = 0
            'Dim iPalletID As Integer = 0
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim mDuplicate As Integer = 0
            Dim x As Integer = 0

            Try
                i = 0

                '******************************************
                'Insert Pallet in twarehousepallet table
                '******************************************
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If iPalletID = 0 Then
                        strsql = "Insert into twarehousepallet " & Environment.NewLine
                        strsql += "(" & Environment.NewLine
                        strsql += "WHPallet_Number, " & Environment.NewLine
                        strsql += "WHPallet_NoBox, " & Environment.NewLine
                        strsql += "WHDateLoaded, " & Environment.NewLine
                        strsql += "WHP_CountedQty, " & Environment.NewLine
                        strsql += "WHP_FileQty, " & Environment.NewLine
                        strsql += "Model_ID, " & Environment.NewLine
                        strsql += "Cust_ID, " & Environment.NewLine    'lan add Cust_ID
                        strsql += "SKU_ID, " & Environment.NewLine    'lan add SKU_ID
                        '---------------------
                        strsql += "WHP_SKU, " & Environment.NewLine
                        strsql += "WHP_Lot, " & Environment.NewLine
                        strsql += "WHP_Skid, " & Environment.NewLine
                        '---------------------
                        strsql += "WH_PalletType " & Environment.NewLine
                        strsql += ") " & Environment.NewLine
                        strsql += "values (" & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Lot"))) & UCase(Trim(R1("Skid"))) & "', " & Environment.NewLine
                        strsql += iNoBoxForPallet & ", " & Environment.NewLine
                        strsql += "'" & strDate & "', " & Environment.NewLine
                        strsql += intCountedQty & ", " & Environment.NewLine
                        strsql += intFileQty & ", " & Environment.NewLine
                        strsql += intModelID & ", " & Environment.NewLine
                        strsql += iCust_id & ", " & Environment.NewLine   'lan add Cust_ID
                        strsql += iSku_id & ", " & Environment.NewLine   'lan add SKU_ID
                        '---------------------
                        strsql += "'" & Trim(R1("SKU")) & "', " & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Lot"))) & "', " & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Skid"))) & "', " & Environment.NewLine
                        '---------------------
                        strsql += "'" & strPalletType & "'" & Environment.NewLine
                        strsql += ");"

                        objMisc._SQL = strsql
                        iPalletID = objMisc.idTransaction(strsql, "twarehousepallet")

                        If iPalletID = 0 Then
                            MsgBox("System failed to create pallet.", MsgBoxStyle.Critical, "Create Warehouse Pallet")
                            Exit Function
                        End If
                    End If
                End If

                '******************************************

                R1 = Nothing
                For Each R1 In dt1.Rows

                    'If Trim(dt1.Rows(i)("Serial Number")) <> "" Then  'not empty entry

                    mDuplicate = 0
                    '**************************************
                    '//Duplicate Devices Assignment
                    '**************************************
                    Try
                        'For x = 0 To UBound(arrDup)
                        '    If Trim(arrDup(x)) = Trim(R1("Serial Number")) Then
                        '        mDuplicate = 1
                        '        Exit For
                        '    End If
                        'Next
                        mDuplicate = Me.CheckDuplicate(dt1, Trim(R1("Serial Number")))

                    Catch ex As Exception
                    End Try
                    '//Duplicate Devices Assignment

                    If iPalletID <> 0 Then
                        '*******************************************
                        'Check if IMEI number is already existed
                        '*******************************************


                        '*******************************************
                        'Load file in to twarehousepalletLoad table
                        '*******************************************
                        strsql = ""
                        strsql = "Insert into twarehousepalletLoad " & Environment.NewLine
                        strsql += "(" & Environment.NewLine
                        strsql += "WHP_BinLocation, " & Environment.NewLine
                        strsql += "WHP_LoadNumber, " & Environment.NewLine
                        strsql += "WHP_PartNumber, " & Environment.NewLine
                        strsql += "WHP_PieceIdentifier, " & Environment.NewLine
                        strsql += "WHP_PieceIdentifierOriginal, " & Environment.NewLine
                        strsql += "WHP_DateLoaded, " & Environment.NewLine
                        strsql += "WHP_RcvdFlag, " & Environment.NewLine
                        strsql += "WHPallet_ID, " & Environment.NewLine
                        strsql += "WHP_Duplicate " & Environment.NewLine
                        'iPalletID
                        strsql += ") " & Environment.NewLine
                        strsql += "values (" & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Lot"))) & "', " & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Skid"))) & "', " & Environment.NewLine
                        strsql += "'" & Trim(R1("SKU")) & "', " & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Serial Number"))) & "', " & Environment.NewLine
                        strsql += "'" & UCase(Trim(R1("Serial Number"))) & "', " & Environment.NewLine
                        strsql += "'" & strDate & "', " & Environment.NewLine
                        strsql += 8 & ", " & Environment.NewLine        'By Default Warehouse Group takes ownership of this 
                        strsql += iPalletID & ", " & Environment.NewLine
                        strsql += mDuplicate & Environment.NewLine
                        strsql += ");"

                        objMisc._SQL = strsql
                        i += objMisc.ExecuteNonQuery
                    End If
                    '******************************************
                    'End If
                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception("LoadFileDock_GameStop():" & ex.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '************************************************************************
        Private Function LoadFileDock_HTC(ByVal strFilePath As String, _
                                ByVal iNoBoxForPallet As Integer, _
                                ByVal intCountedQty As Integer, _
                                ByVal intFileQty As Integer, _
                                ByVal arrDup() As String, _
                                ByVal intModelID As Integer, _
                                ByVal strPalletType As String, _
                                ByVal iCust_id As Integer, _
                                ByVal dt1 As DataTable) As Integer
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim i As Integer = 0
            'Dim iPalletID As Integer = 0
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim mDuplicate As Integer = 0
            Dim x As Integer = 0

            Try
                '******************************************
                For Each R1 In dt1.Rows
                    '******************************************
                    'Insert Pallet in twarehousepallet table
                    If iPalletID = 0 Then
                        strsql = "Insert into twarehousepallet " & Environment.NewLine
                        strsql += "(" & Environment.NewLine
                        strsql += "WHPallet_Number, " & Environment.NewLine
                        strsql += "WHPallet_NoBox, " & Environment.NewLine
                        strsql += "WHDateLoaded, " & Environment.NewLine
                        strsql += "WHP_CountedQty, " & Environment.NewLine
                        strsql += "WHP_FileQty, " & Environment.NewLine
                        strsql += "Model_ID, " & Environment.NewLine
                        strsql += "Cust_ID, " & Environment.NewLine    'lan add Cust_ID
                        strsql += "WH_PalletType " & Environment.NewLine
                        strsql += ") " & Environment.NewLine
                        strsql += "values (" & Environment.NewLine
                        strsql += "'" & Trim(R1("RMA")) & "', " & Environment.NewLine
                        strsql += iNoBoxForPallet & ", " & Environment.NewLine
                        strsql += "'" & strDate & "', " & Environment.NewLine
                        strsql += intCountedQty & ", " & Environment.NewLine
                        strsql += intFileQty & ", " & Environment.NewLine
                        strsql += intModelID & ", " & Environment.NewLine
                        strsql += iCust_id & ", " & Environment.NewLine   'lan add Cust_ID
                        strsql += "'" & strPalletType & "'" & Environment.NewLine
                        strsql += ");"

                        objMisc._SQL = strsql
                        iPalletID = objMisc.idTransaction(strsql, "twarehousepallet")
                    End If

                    mDuplicate = 0
                    '//Duplicate Devices Assignment
                    Try
                        For x = 0 To UBound(arrDup)
                            If Trim(arrDup(x)) = Trim(R1("Piece Identifier")) Then
                                mDuplicate = 1
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                    '//Duplicate Devices Assignment

                    'Load file in to twarehousepalletLoad table
                    strsql = ""
                    strsql = "Insert into twarehousepalletLoad " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "WHP_BinLocation, " & Environment.NewLine
                    strsql += "WHP_LoadNumber, " & Environment.NewLine
                    strsql += "WHP_PartNumber, " & Environment.NewLine
                    strsql += "WHP_ClientID, " & Environment.NewLine
                    strsql += "WHP_PieceIdentifier, " & Environment.NewLine
                    strsql += "WHP_PieceIdentifierOriginal, " & Environment.NewLine
                    strsql += "WHP_DateLoaded, " & Environment.NewLine
                    strsql += "WHP_RcvdFlag, " & Environment.NewLine
                    strsql += "WHPallet_ID, " & Environment.NewLine
                    strsql += "WHP_Duplicate " & Environment.NewLine
                    'iPalletID
                    strsql += ") " & Environment.NewLine
                    strsql += "values (" & Environment.NewLine
                    strsql += "'', " & Environment.NewLine
                    strsql += "'" & R1("RMA") & "', " & Environment.NewLine
                    strsql += "'', " & Environment.NewLine
                    strsql += "'', " & Environment.NewLine
                    strsql += "'" & Trim(R1("IMEI")) & "', " & Environment.NewLine
                    strsql += "'" & Trim(R1("IMEI")) & "', " & Environment.NewLine
                    strsql += "now(), " & Environment.NewLine
                    strsql += 8 & ", " & Environment.NewLine        'By Default Warehouse Group takes ownership of this 
                    strsql += iPalletID & ", " & Environment.NewLine
                    strsql += mDuplicate & Environment.NewLine
                    strsql += ");"

                    objMisc._SQL = strsql
                    i += objMisc.ExecuteNonQuery
                    '******************************************
                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception("LoadFileDock_HTC():" & ex.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '*******************************************************************
        Private Function CheckDuplicate(ByVal dt1 As DataTable, ByVal strSN As String) As Integer
            Dim R1 As DataRow
            Dim iCnt As Integer = 0
            Dim iDupl As Integer = 0

            Try
                For Each R1 In dt1.Rows
                    If UCase(Trim(R1("Serial Number"))) = UCase(Trim(strSN)) Then
                        iCnt += 1
                    End If
                    If iCnt > 1 Then
                        iDupl = 1
                        Exit For
                    End If
                Next

                Return iDupl
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************** LAN ***********************************
        Private Function ValidateOrInsertSku(ByVal iCust_id As Integer, _
                                             ByVal iModel_id As Integer, _
                                             ByVal strFilePath As String) As Integer
            Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()

            Dim strSQL As String = ""
            Dim dtDBSku As New DataTable()
            Dim drDBSku As DataRow
            Dim dtExcelSku As New DataTable()
            Dim drExcelSku As DataRow

            Try
                'Read Excel file
                '*******************************************
                objConn.ConnectionString = sConnectionstring
                objConn.Open()
                objCmdSelect.CommandText = ("SELECT * FROM [Sheet 1$] WHERE [Serial Number] IS NOT NULL")
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dtExcelSku)
                '*******************************************

                drExcelSku = dtExcelSku.Rows(0)

                'Check if SKU exist else insert new SKU
                '**************************************
                strSQL = "SELECT Sku_id, Sku_Number FROM tsku " & Environment.NewLine
                strSQL &= "WHERE cust_id = " & iCust_id & " AND " & Environment.NewLine
                strSQL &= "Model_id = " & iModel_id & ";"
                objMisc._SQL = strSQL
                dtDBSku = objMisc.GetDataTable
                If dtDBSku.Rows.Count > 0 Then
                    If dtDBSku.Rows(0)("Sku_Number") = Trim(drExcelSku("SKU")) Then
                        Return dtDBSku.Rows(0)("Sku_id")
                    Else
                        Return -99 'Sku exist for selected model but does not match with excel file
                    End If
                Else
                    '''''confirm SKU number
                    '''''************************
                    ''''If MsgBox("Are you sure you have selected the right model?", MsgBoxStyle.OKCancel, "Validate SKU") = 2 Then
                    ''''    Return 0
                    ''''End If
                    '''''************************
                    strSQL = "INSERT INTO tsku (Sku_Number, Cust_ID, Model_ID) " & Environment.NewLine
                    strSQL &= "VALUES ('" & Trim(drExcelSku("SKU")) & "', " & iCust_id & ", " & iModel_id & ")"
                    Return objMisc.idTransaction(strSQL, "tsku")
                End If
                '**************************************

            Catch ex As Exception
                Throw New Exception("ValidateOrInsertSku():" & ex.ToString)
            Finally
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If
                If Not IsNothing(dtDBSku) Then
                    dtDBSku.Dispose()
                    dtDBSku = Nothing
                End If
                If Not IsNothing(dtExcelSku) Then
                    dtExcelSku.Dispose()
                    dtExcelSku = Nothing
                End If
                drExcelSku = Nothing
                drDBSku = Nothing
            End Try
        End Function

        '***************************************************************************
        'Lan modified this function and put it in separate function base on customer
        '***************************************************************************
        Private Function createDiscrepantReport(ByVal mWHR_ID As Long, _
                                                ByVal iCust_id As Integer, _
                                                ByVal iParentGroupID As Integer) As Boolean

            createDiscrepantReport = False

            If IsDBNull(mWHR_ID) Then Return False
            If Len(Trim(mWHR_ID)) < 1 Then Return False

            Select Case iCust_id
                Case 2019
                    Return createDiscrepantReport_ATCLE(mWHR_ID, iCust_id, iParentGroupID)
                Case 2219
                    Return createDiscrepantReport_GAMESTOP(mWHR_ID, iCust_id, iParentGroupID)
                Case Else
                    'never happen
            End Select
        End Function

        Private Function createDiscrepantReport_ATCLE(ByVal mWHR_ID As Long, _
                                                ByVal iCust_id As Integer, _
                                                ByVal iParentGroupID As Integer) As Boolean
            Dim sConnectionstring As String
            'Dim objConn As New OleDbConnection()
            'Dim objCmdSelect As New OleDbCommand()
            'Dim objAdapter1 As New OleDbDataAdapter()
            'Dim objDataset1 As New DataSet()
            Dim objXL As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet

            Dim strSQL As String

            Dim strPallet As String
            Dim defaultCount As String = "-001"
            Dim strPath As String = ""

            'Set Discrepancy file path (Lan add)
            '---------------------------
            Dim strDiscrepPath_locVar As String = ""
            strDiscrepPath_locVar = "P:\Dept\ATCLE\Palet packing list\DISCREPANCY FOLDER\"
            '---------------------------

            '//Get the correct name for the pallet
            Dim ds As PSS.Data.Production.Joins
            Dim mDate As String = (Format(Now, "yyyyMMdd"))
            '******************************************************
            'lan add Group id in pallet name 10/20/2006 
            If iParentGroupID < 10 Then
                strPallet = "0" & iParentGroupID & "-" & strPallet
            Else
                strPallet = iParentGroupID & "-" & strPallet
            End If
            mDate = strPallet & mDate
            '******************************************************
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tpallett WHERE Pallett_Name LIKE '" & mDate & "%' ORDER BY Pallett_Name")

            Dim r As DataRow

            If dt.Rows.Count < 1 Then
                strPallet = mDate & defaultCount                              '//Set Default
            Else
                Dim mInt As Integer = 0
                Dim iMax As Integer = 0
                For Each r In dt.Rows
                    mInt = CInt(Mid$(r("Pallett_Name"), 13, 3))                  '//Separate out counter value
                    If mInt > iMax Then
                        iMax = mInt
                    End If
                Next r
                'r = dt.Rows(dt.Rows.Count - 1)                          '//Get Last Record
                iMax += 1                                               '//Increment counter by 1
                strPallet = mDate & "-" & iMax.ToString.PadLeft(3, "0") '//Concactenate the pallet name

            End If



            '//Insert value to table
            strSQL = "INSERT INTO tpallett (Pallett_Name, Pallett_ShipDate, Pallett_BulkShipped) VALUES ('" & strPallet & "', '" & FormatDateShort(Now) & "', 9)"
            Dim tblWO As New PSS.Data.Production.tworkorder()
            Dim mPalletID As Long = tblWO.idTransaction(strSQL)

            Dim dsUpdate As PSS.Data.Production.Joins
            Dim blnUpdate As Boolean

            '//update record
            strSQL = "UPDATE twarehousereceive SET Pallett_ID = " & mPalletID & " WHERE WHR_ID = " & mWHR_ID
            System.Windows.Forms.Application.DoEvents()
            blnUpdate = dsUpdate.OrderEntryUpdateDelete(strSQL)

            '//Put report here
            '//Get data for report
            Dim dtReport As DataTable = ds.OrderEntrySelect("select twarehousepallet.whpallet_number, twarehousereceive.* from twarehousereceive inner join twarehousepallet on twarehousereceive.whpallet_id = twarehousepallet.whpallet_id where twarehousereceive.pallett_id = " & mPalletID)
            Dim lineNumber As Integer = 1

            objXL = New Excel.Application()
            oBook = objXL.workbooks.add
            oSheet = oBook.Worksheets(1)

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DISCREPANCEY REPORT"
            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "PALLET NUMBER: " & strPallet

            'add barcode
            '--------------------------------------
            oSheet.Range("C" & lineNumber).Select()
            objXL.Selection.Font.Name = "C39P12DhTt"
            objXL.Selection.Font.Size = 20
            oSheet.Range("C" & lineNumber).FormulaR1C1 = "*" & strPallet & "*"
            '--------------------------------------

            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DATE: " & Now
            lineNumber += 2

            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 20
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").ColumnWidth = 20
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 20
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 25
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 30
            oSheet.Columns("F:F").Select()
            oSheet.Columns("F:F").ColumnWidth = 25
            oSheet.Columns("G:G").Select()
            oSheet.Columns("G:G").ColumnWidth = 12
            oSheet.Columns("H:H").Select()
            oSheet.Columns("H:H").ColumnWidth = 12
            oSheet.Columns("I:I").Select()
            oSheet.Columns("I:I").ColumnWidth = 25
            oSheet.Columns("J:J").Select()
            oSheet.Columns("J:J").ColumnWidth = 20
            oSheet.Columns("K:K").Select()
            oSheet.Columns("K:K").ColumnWidth = 25

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "ORIGINAL PALLET"
            oSheet.Range("B" & lineNumber).Select()
            oSheet.range("B" & lineNumber).FormulaR1C1 = "BOX SN"
            oSheet.Range("C" & lineNumber).Select()
            oSheet.range("C" & lineNumber).FormulaR1C1 = "DEVICE SN"
            oSheet.Range("D" & lineNumber).Select()
            oSheet.range("D" & lineNumber).FormulaR1C1 = "BOX SN ABSENT IN FILE"
            oSheet.Range("E" & lineNumber).Select()
            oSheet.range("E" & lineNumber).FormulaR1C1 = "DEVICE SN/ BOX SN DIFFERENT"
            oSheet.Range("F" & lineNumber).Select()
            oSheet.range("F" & lineNumber).FormulaR1C1 = "DEVICE SN ABSENT IN FILE"
            oSheet.Range("G" & lineNumber).Select()
            oSheet.range("G" & lineNumber).FormulaR1C1 = "BOX EMPTY"
            oSheet.Range("H" & lineNumber).Select()
            oSheet.range("H" & lineNumber).FormulaR1C1 = "WRONG SKU"
            oSheet.Range("I" & lineNumber).Select()
            oSheet.range("I" & lineNumber).FormulaR1C1 = "IN FILE - NOT ON PALLET"
            oSheet.Range("J" & lineNumber).Select()
            oSheet.range("J" & lineNumber).FormulaR1C1 = "DUPLICATE IN FILE"
            oSheet.Range("K" & lineNumber).Select()
            oSheet.range("K" & lineNumber).FormulaR1C1 = "MULTIPLE PHONES IN BOX"

            Dim x As Integer
            lineNumber += 1

            For x = 0 To dtReport.Rows.Count - 1
                r = dtReport.Rows(x)

                oSheet.Range("A" & lineNumber).Select()
                oSheet.range("A" & lineNumber).FormulaR1C1 = "'" & r("WHPallet_Number")
                oSheet.Range("B" & lineNumber).Select()
                oSheet.range("B" & lineNumber).FormulaR1C1 = "'" & r("WHR_Box_SN")
                oSheet.Range("C" & lineNumber).Select()
                oSheet.range("C" & lineNumber).FormulaR1C1 = "'" & r("WHR_Dev_SN")
                oSheet.Range("D" & lineNumber).Select()
                If r("WHR_BoxSN_Absent_in_File") = 1 Then oSheet.range("D" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("E" & lineNumber).Select()
                If r("WHR_DevSN_BoxSN_Different") = 1 Then oSheet.range("E" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("F" & lineNumber).Select()
                If r("WHR_DevSN_Absent_in_File") = 1 Then oSheet.range("F" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("G" & lineNumber).Select()
                If r("WHR_Box_Empty") = 1 Then oSheet.range("G" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("H" & lineNumber).Select()
                If r("WHR_WrongSKU") = 1 Then oSheet.range("H" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("I" & lineNumber).Select()
                If r("WHR_InFile_NotOnPallet") = 1 Then oSheet.range("I" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("J" & lineNumber).Select()
                If r("WHR_DupInFile") = 1 Then oSheet.range("J" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("K" & lineNumber).Select()
                If r("WHR_Mutltiple_Phones_In_Box") = 1 Then oSheet.range("K" & lineNumber).FormulaR1C1 = "X"

                lineNumber += 1

            Next

            oSheet.Range("A5:K" & lineNumber - 1).Select()

            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With

            oSheet.Columns("D:K").Select()
            With objXL.Selection
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                '.BlackAndWhite = False
                .Zoom = False
                .FitToPagesWide = 1
                .FitToPagesTall = 1
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .Draft = False
                '.PaperSize = Excel.XlPaperSize.xlPaperLetter
            End With

            '''objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            '''System.Windows.Forms.Application.DoEvents()

            'oBook.saveas("P:\Dept\ATCLE\Palet Packing List\Discrepancy Folder\" & strPallet & ".xls")
            strPath = ""
            strPath = strDiscrepPath_locVar & strPallet & ".xls"
            oBook.saveas(strPath)
            'File.SetAttributes(strDiscrepPath, FileAttributes.ReadOnly)

            'move by Lan 10/30/2006
            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            System.Windows.Forms.Application.DoEvents()

            'oSheet = Nothing
            'objXL = Nothing

            'Added by Asif on 09-28-2006
            'Excel clean up
            If Not IsNothing(oSheet) Then
                NAR(oSheet)
                oSheet = Nothing
            End If
            If Not IsNothing(oBook) Then
                oBook.Close(False)
                NAR(oBook)
                oBook = Nothing
            End If
            If Not IsNothing(objXL) Then
                objXL.Quit()
                NAR(objXL)
                objXL = Nothing
            End If
            Return True
        End Function

        Private Function createDiscrepantReport_GAMESTOP(ByVal mWHR_ID As Long, _
                                                        ByVal iCust_id As Integer, _
                                                        ByVal iParentGroupID As Integer) As Boolean
            Dim sConnectionstring As String
            'Dim objConn As New OleDbConnection()
            'Dim objCmdSelect As New OleDbCommand()
            'Dim objAdapter1 As New OleDbDataAdapter()
            'Dim objDataset1 As New DataSet()
            Dim objXL As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet

            Dim strSQL As String

            Dim strPallet As String
            Dim defaultCount As String = "-001"
            Dim strPath As String = ""

            'Set Discrepancy file path (Lan add)
            '---------------------------
            Dim strDiscrepPath_locVar As String = ""
            strDiscrepPath_locVar = "P:\Dept\Game Stop\DISCREPANCY FOLDER\"
            '---------------------------

            '//Get the correct name for the pallet
            Dim ds As PSS.Data.Production.Joins
            Dim mDate As String = (Format(Now, "yyyyMMdd"))

            Dim dt As DataTable
            '******************************************************
            'lan add Group id in pallet name 10/20/2006 
            If iParentGroupID < 10 Then
                strPallet = "0" & iParentGroupID & "-" & strPallet
            Else
                strPallet = iParentGroupID & "-" & strPallet
            End If
            mDate = strPallet & mDate
            '******************************************************
            dt = ds.OrderEntrySelect("SELECT * FROM tpallett WHERE Pallett_Name LIKE '" & strPallet & "%' ORDER BY Pallett_Name")

            Dim r As DataRow

            If dt.Rows.Count < 1 Then
                strPallet = mDate & defaultCount                              '//Set Default
            Else
                Dim mInt As Integer = 0
                Dim iMax As Integer = 0
                For Each r In dt.Rows
                    mInt = CInt(Mid$(r("Pallett_Name"), 13, 3))                  '//Separate out counter value
                    If mInt > iMax Then
                        iMax = mInt
                    End If
                Next r
                'r = dt.Rows(dt.Rows.Count - 1)                          '//Get Last Record
                iMax += 1                                               '//Increment counter by 1
                strPallet = mDate & "-" & iMax.ToString.PadLeft(3, "0") '//Concactenate the pallet name
            End If


            '//Insert value to table
            strSQL = "INSERT INTO tpallett (Pallett_Name, Pallett_ShipDate, Pallett_BulkShipped) VALUES ('" & strPallet & "', '" & FormatDateShort(Now) & "', 9)"
            Dim tblWO As New PSS.Data.Production.tworkorder()
            Dim mPalletID As Long = tblWO.idTransaction(strSQL)

            Dim dsUpdate As PSS.Data.Production.Joins
            Dim blnUpdate As Boolean

            '//update record
            strSQL = "UPDATE twarehousereceive SET Pallett_ID = " & mPalletID & " WHERE WHR_ID = " & mWHR_ID
            System.Windows.Forms.Application.DoEvents()
            blnUpdate = dsUpdate.OrderEntryUpdateDelete(strSQL)

            '//Put report here
            '//Get data for report
            Dim dtReport As DataTable = ds.OrderEntrySelect("select twarehousepallet.whpallet_number, twarehousereceive.* from twarehousereceive inner join twarehousepallet on twarehousereceive.whpallet_id = twarehousepallet.whpallet_id where twarehousereceive.pallett_id = " & mPalletID)
            Dim lineNumber As Integer = 1

            objXL = New Excel.Application()
            oBook = objXL.workbooks.add
            oSheet = oBook.Worksheets(1)

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DISCREPANCEY REPORT"
            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "PALLET NUMBER: " & strPallet

            'add barcode
            '--------------------------------------
            oSheet.Range("C" & lineNumber).Select()
            objXL.Selection.Font.Name = "C39P12DhTt"
            objXL.Selection.Font.Size = 20
            oSheet.Range("C" & lineNumber).FormulaR1C1 = "*" & strPallet & "*"
            '--------------------------------------

            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DATE: " & Now
            lineNumber += 2

            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 20
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").ColumnWidth = 20
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 20
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 25
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 30
            oSheet.Columns("F:F").Select()
            oSheet.Columns("F:F").ColumnWidth = 25
            oSheet.Columns("G:G").Select()
            oSheet.Columns("G:G").ColumnWidth = 12
            oSheet.Columns("H:H").Select()
            oSheet.Columns("H:H").ColumnWidth = 12
            oSheet.Columns("I:I").Select()
            oSheet.Columns("I:I").ColumnWidth = 25
            oSheet.Columns("J:J").Select()
            oSheet.Columns("J:J").ColumnWidth = 20
            oSheet.Columns("K:K").Select()
            oSheet.Columns("K:K").ColumnWidth = 25

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "ORIGINAL PALLET"
            'oSheet.Range("B" & lineNumber).Select()
            'oSheet.range("B" & lineNumber).FormulaR1C1 = "BOX SN"
            oSheet.Range("B" & lineNumber).Select()
            oSheet.range("B" & lineNumber).FormulaR1C1 = "DEVICE SN"
            'oSheet.Range("D" & lineNumber).Select()
            'oSheet.range("D" & lineNumber).FormulaR1C1 = "BOX SN ABSENT IN FILE"
            'oSheet.Range("E" & lineNumber).Select()
            'oSheet.range("E" & lineNumber).FormulaR1C1 = "DEVICE SN/ BOX SN DIFFERENT"
            oSheet.Range("C" & lineNumber).Select()
            oSheet.range("C" & lineNumber).FormulaR1C1 = "DEVICE SN ABSENT IN FILE"
            'oSheet.Range("G" & lineNumber).Select()
            'oSheet.range("G" & lineNumber).FormulaR1C1 = "BOX EMPTY"
            oSheet.Range("D" & lineNumber).Select()
            oSheet.range("D" & lineNumber).FormulaR1C1 = "WRONG SKU"
            oSheet.Range("E" & lineNumber).Select()
            oSheet.range("E" & lineNumber).FormulaR1C1 = "IN FILE - NOT ON LOT"
            oSheet.Range("F" & lineNumber).Select()
            oSheet.range("F" & lineNumber).FormulaR1C1 = "DUPLICATE IN FILE"
            'oSheet.Range("K" & lineNumber).Select()
            'oSheet.range("K" & lineNumber).FormulaR1C1 = "MULTIPLE PHONES IN BOX"

            Dim x As Integer
            lineNumber += 1

            For x = 0 To dtReport.Rows.Count - 1
                r = dtReport.Rows(x)

                oSheet.Range("A" & lineNumber).Select()
                oSheet.range("A" & lineNumber).FormulaR1C1 = "'" & r("WHPallet_Number")
                'oSheet.Range("B" & lineNumber).Select()
                'oSheet.range("B" & lineNumber).FormulaR1C1 = "'" & r("WHR_Box_SN")
                oSheet.Range("B" & lineNumber).Select()
                oSheet.range("B" & lineNumber).FormulaR1C1 = "'" & r("WHR_Dev_SN")
                'oSheet.Range("D" & lineNumber).Select()
                'If r("WHR_BoxSN_Absent_in_File") = 1 Then oSheet.range("D" & lineNumber).FormulaR1C1 = "X"
                'oSheet.Range("E" & lineNumber).Select()
                'If r("WHR_DevSN_BoxSN_Different") = 1 Then oSheet.range("E" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("C" & lineNumber).Select()
                If r("WHR_DevSN_Absent_in_File") = 1 Then oSheet.range("C" & lineNumber).FormulaR1C1 = "X"
                'oSheet.Range("G" & lineNumber).Select()
                'If r("WHR_Box_Empty") = 1 Then oSheet.range("G" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("D" & lineNumber).Select()
                If r("WHR_WrongSKU") = 1 Then oSheet.range("D" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("E" & lineNumber).Select()
                If r("WHR_InFile_NotOnPallet") = 1 Then oSheet.range("E" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("F" & lineNumber).Select()
                If r("WHR_DupInFile") = 1 Then oSheet.range("F" & lineNumber).FormulaR1C1 = "X"
                'oSheet.Range("K" & lineNumber).Select()
                'If r("WHR_Mutltiple_Phones_In_Box") = 1 Then oSheet.range("K" & lineNumber).FormulaR1C1 = "X"

                lineNumber += 1

            Next

            'oSheet.Range("A5:K" & lineNumber - 1).Select()
            oSheet.Range("A5:F" & lineNumber - 1).Select()

            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With

            'oSheet.Columns("D:F").Select()
            oSheet.Columns("D:B").Select()
            With objXL.Selection
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                '.BlackAndWhite = False
                .Zoom = False
                .FitToPagesWide = 1
                .FitToPagesTall = 1
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .Draft = False
                '.PaperSize = Excel.XlPaperSize.xlPaperLetter
            End With

            ''''objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            ''''System.Windows.Forms.Application.DoEvents()

            'oBook.saveas("P:\Dept\ATCLE\Palet Packing List\Discrepancy Folder\" & strPallet & ".xls")
            strPath = ""
            strPath = strDiscrepPath_locVar & strPallet & ".xls"
            oBook.saveas(strPath)
            'File.SetAttributes(strDiscrepPath, FileAttributes.ReadOnly)

            'move by Lan 10/30/2006
            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            System.Windows.Forms.Application.DoEvents()

            'oSheet = Nothing
            'objXL = Nothing

            'Added by Asif on 09-28-2006
            'Excel clean up
            If Not IsNothing(oSheet) Then
                NAR(oSheet)
                oSheet = Nothing
            End If
            If Not IsNothing(oBook) Then
                oBook.Close(False)
                NAR(oBook)
                oBook = Nothing
            End If
            If Not IsNothing(objXL) Then
                objXL.Quit()
                NAR(objXL)
                objXL = Nothing
            End If
            Return True
        End Function



        Public Function FormatDateShort(ByVal valStartDate As Date) As String
            FormatDateShort = ""
            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String
            Dim valDate As Date
            valDate = valStartDate
            vMnth = DatePart(DateInterval.Month, valDate)
            vDay = DatePart(DateInterval.Day, valDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, valDate)
            FormatDateShort = vYear & "-" & vMnth & "-" & vDay
        End Function

        Public Function GetDeviceNotWarehouseRec(ByVal strPallett As String, _
                                                ByVal iCust_id As Integer) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "select twarehousepalletload.WHP_PieceIdentifier  " & Environment.NewLine
                strsql &= "from twarehousepalletload, twarehousepallet " & Environment.NewLine
                strsql &= "where twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID and " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_RcvdFlag = 8 and " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number ='" & strPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_id = " & iCust_id & Environment.NewLine
                strsql &= "order by twarehousepalletload.WHP_PieceIdentifier desc;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**************************************************************Lan 10/31/2006
        'use by GameStop: change received SN to new SN
        Public Function ChangeSN(ByVal strOldSN As String, _
                                ByVal strNewSN As String, _
                                ByVal strPallett As String, _
                                ByVal iCust_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim dtOldSN As DataTable
            Dim R1 As DataRow
            Dim i As Integer

            Try
                ''check if SN exist in tdevice with open shipdate
                Dim blnResult As Boolean
                blnResult = Me.CheckOpenShipDtSN(strNewSN, iCust_id)   'true: device exist in tdevice with shipdate = null
                If blnResult = True Then
                    'MessageBox.Show("The new SN already exist in the system with open ship date.", "Change SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Return -99
                End If

                'Step 2: Check if old SN exist or already receive into line
                strsql = "Select twarehousepalletload.* " & Environment.NewLine
                strsql &= "from twarehousepallet " & Environment.NewLine
                strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_ID = " & iCust_id & " and " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_PieceIdentifier = '" & strOldSN & "' and " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_RcvdFlag = 8" & ";"
                'strsql &= "order by twarehousepalletload.WHP_PieceIdentifier asc;"
                objMisc._SQL = strsql
                dtOldSN = objMisc.GetDataTable

                If dtOldSN.Rows.Count = 0 Then
                    Return -2   'Old SN does not exist or line received
                End If

                'Step 3:Check if new SN already exist in master pallet
                strsql = "Select twarehousepalletload.* " & Environment.NewLine
                strsql &= "from twarehousepallet " & Environment.NewLine
                strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHPallet_Number = '" & strPallett & "' and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_ID = " & iCust_id & " and " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_PieceIdentifier = '" & strNewSN & "';" & Environment.NewLine
                'strsql &= "order by twarehousepalletload.WHP_PieceIdentifier asc;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Return -1   'New SN exist
                End If

                '***************************
                strsql = ""
                If Not IsNothing(dt1) Then
                    dt1 = Nothing
                End If
                '***************************

                'Step 4:Check if new SN already exist in subpallet pallet
                strsql = "Select twarehousepalletload.* " & Environment.NewLine
                strsql &= "from twarehousepallet " & Environment.NewLine
                strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHP_ParentPallet = " & dtOldSN.Rows(0)("WHPallet_ID") & " and " & Environment.NewLine
                strsql &= "twarehousepallet.Cust_ID = " & iCust_id & " and " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_PieceIdentifier = '" & strNewSN & "';" & Environment.NewLine
                'strsql &= "order by twarehousepalletload.WHP_PieceIdentifier asc;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Return -1   'New SN exist
                End If

                '***************************
                strsql = ""
                If Not IsNothing(dt1) Then
                    dt1 = Nothing
                End If
                '***************************

                'Every thing is ok upto this point, start the update
                If dtOldSN.Rows.Count > 2 Then
                    '**************************************************************
                    'set 1st duplicate entry to new SN and reset duplicate flag = 0
                    R1 = dtOldSN.Rows(0)
                    strsql = ""
                    strsql = "UPDATE twarehousepalletload SET WHP_PieceIdentifier_Old = WHP_PieceIdentifier, " & Environment.NewLine
                    strsql &= "twarehousepalletload.WHP_PieceIdentifier = '" & strNewSN & "', " & Environment.NewLine
                    strsql &= "twarehousepalletload.WHP_Duplicate = 0 " & Environment.NewLine
                    strsql &= "WHERE twarehousepalletload.WHP_ID = " & R1("WHP_ID")
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery
                    '**************************************************************

                ElseIf dtOldSN.Rows.Count = 2 Then
                    '**************************************************************
                    'set 1st duplicate entry to new SN and reset duplicate flag = 0
                    R1 = dtOldSN.Rows(0)
                    strsql = ""
                    strsql = "UPDATE twarehousepalletload SET WHP_PieceIdentifier_Old = WHP_PieceIdentifier, " & Environment.NewLine
                    strsql &= "twarehousepalletload.WHP_PieceIdentifier = '" & strNewSN & "', " & Environment.NewLine
                    strsql &= "twarehousepalletload.WHP_Duplicate = 0 " & Environment.NewLine
                    strsql &= "WHERE twarehousepalletload.WHP_ID = " & R1("WHP_ID")
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery
                    '**************************************************************
                    'reset 2nd duplicate flag to 0
                    R1 = dtOldSN.Rows(1)
                    strsql = ""
                    strsql = "UPDATE twarehousepalletload SET twarehousepalletload.WHP_Duplicate = 0 " & Environment.NewLine
                    strsql &= "WHERE twarehousepalletload.WHP_ID = " & R1("WHP_ID")
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery

                ElseIf dtOldSN.Rows.Count = 1 Then
                    R1 = dtOldSN.Rows(0)
                    strsql = ""
                    strsql = "UPDATE twarehousepalletload SET WHP_PieceIdentifier_Old = WHP_PieceIdentifier, " & Environment.NewLine
                    strsql &= "twarehousepalletload.WHP_PieceIdentifier = '" & strNewSN & "' " & Environment.NewLine
                    strsql &= "WHERE twarehousepalletload.WHP_ID = " & R1("WHP_ID")
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery
                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
            End Try

        End Function

        '**************************************************************Lan 11/07/2006
        'check if sn exist in tdevice with open shipdate
        Public Function CheckOpenShipDtSN(ByVal strSN As String, _
                                          ByVal iCust_id As Integer) As Boolean
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "select count(*) as cnt from tdevice " & Environment.NewLine
                strsql &= "inner join tlocation on tlocation.Loc_ID = tdevice.Loc_ID " & Environment.NewLine
                strsql &= "where tdevice.device_sn ='" & strSN & "' and " & Environment.NewLine
                strsql &= "tlocation.Cust_ID = " & iCust_id & " and " & Environment.NewLine
                strsql &= "(tdevice.device_dateship is null or  tdevice.device_dateship = '0000-00-00 00:00:00' or tdevice.device_dateship = '');"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows(0)("cnt") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '**************************************************************Lan 11/10/2006
        'reprin discrepancy report. create one if it does not exist. Use by ATCLE only
        Public Function ReprintDiscrepancy(ByVal iWHR_id As Integer, _
                                            ByVal iCust_id As Integer, _
                                            ByVal iGroup_id As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim strDiscrepPath As String = "P:\Dept\ATCLE\Palet packing list\DISCREPANCY FOLDER\"
            Dim strFileName As String = ""

            Try
                'step1: get device information from twarehousereceive
                strSql = "select * from twarehousereceive where WHR_ID = " & iWHR_id & " and WHR_Result = 1;"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    'Step1: check if exel file already exist
                    If Not IsDBNull(R1("Pallett_ID")) Then
                        strSql = "select * from tpallett where pallett_id = " & R1("Pallett_ID") & ";"
                        objMisc._SQL = strSql
                        dt2 = objMisc.GetDataTable
                        If dt2.Rows.Count > 0 Then
                            If Not IsDBNull(Trim(dt2.Rows(0)("Pallett_name"))) And File.Exists(strDiscrepPath & Trim(dt2.Rows(0)("Pallett_name")) & ".xls") Then
                                'reprint excelFile
                                Me.PrintExcel(strDiscrepPath & Trim(dt2.Rows(0)("Pallett_name") & ".xls"))
                            Else
                                Me.createDiscrepantReport_ATCLE(iWHR_id, iCust_id, iGroup_id)
                            End If
                        Else
                            Me.createDiscrepantReport_ATCLE(iWHR_id, iCust_id, iGroup_id)
                        End If
                    Else
                        'Create excel File
                        Me.createDiscrepantReport_ATCLE(iWHR_id, iCust_id, iGroup_id)
                    End If
                Else
                    Throw New Exception("WHR_id was not defined.")
                End If

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
            End Try
        End Function
        Private Function PrintExcel(ByVal strFileLoc As String) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try

                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objExcel.Workbooks.Open(strFileLoc)                 'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                'objSheet = objBook.Worksheets.Item(1)              'Select a Sheet 1 for this
                objSheet = objExcel.Worksheets(1)

                objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                Throw ex
            Finally
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
        '**************************************************************Lan 11/13/2006
        Public Function CheckCompMap(ByVal iGroup_id As Integer) As Boolean
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                strsql = "select * from lgroups where group_id = " & iGroup_id & " and lgroups.ActualGroup = 1;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
        '**************************************************************Lan 12/06/2006

        Public Function GetOpenWarehouseChildPallet(ByVal strPallett As String) As String
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                '********************************
                'Get open child pallet
                '********************************
                strsql = "select * from twarehousepallet " & Environment.NewLine
                strsql &= "where WHPallet_Number like '" & strPallett & "_%' and whp_ParentPallet = " & iPalletID & " and " & Environment.NewLine
                strsql &= "WHPalletClosed = 0;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 1 Then
                    Me.iChildPalletID = dt1.Rows(0)("whpallet_id")
                    Return dt1.Rows(0)("WHPallet_Number")
                ElseIf dt1.Rows.Count > 1 Then
                    Throw New Exception("There are two open subpallet in the system. Please check it again.")
                Else
                    '*****************************
                    'Create child pallet
                    '******************************
                    'Return Me.CreateChildPallet(strPallett)
                    Me.iChildPalletID = 0
                    Return ""
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**************************************************************Lan 12/06/2006
        Public Function CreateChildPallet(ByVal strParentPallet As String) As String
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strChildPallet As String = ""
            Dim iMaxPalletSeqNo As Integer = 0
            Dim i As Integer = 0

            Try
                '********************************
                'Get all previous child pallets and create next child pallet for current lot num
                '********************************
                strsql = "select * from twarehousepallet " & Environment.NewLine
                strsql &= "where WHPallet_Number like '" & strParentPallet & "_%' and whp_ParentPallet = " & iPalletID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        i = CInt(Mid(R1("WHPallet_Number"), R1("WHPallet_Number").LastIndexOf("_") + 2))
                        If iMaxPalletSeqNo < i Then
                            iMaxPalletSeqNo = i
                        End If
                    Next R1

                    strChildPallet = strParentPallet & "_" & iMaxPalletSeqNo + 1
                Else
                    strChildPallet = strParentPallet & "_1"
                End If


                'reset variable
                dt1 = Nothing
                R1 = Nothing
                strsql = ""

                '********************************
                'Get parent pallet information
                '********************************
                strsql = "select * from twarehousepallet " & Environment.NewLine
                strsql &= "where WHPallet_Number = '" & strParentPallet & "' and whpallet_id = " & iPalletID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Can not find 'Parent pallet'. Please check it again.")
                End If

                R1 = dt1.Rows(0)
                '********************************
                'Create child pallet
                '********************************
                strsql = "Insert into twarehousepallet " & Environment.NewLine
                strsql += "(" & Environment.NewLine
                strsql += "WHPallet_Number, " & Environment.NewLine
                strsql += "WHPallet_NoBox, " & Environment.NewLine
                strsql += "WHDateLoaded, " & Environment.NewLine
                strsql += "Model_ID, " & Environment.NewLine
                strsql += "Cust_ID, " & Environment.NewLine
                strsql += "SKU_ID, " & Environment.NewLine
                strsql += "WHP_SKU, " & Environment.NewLine
                strsql += "WHP_Lot, " & Environment.NewLine
                strsql += "WHP_Skid, " & Environment.NewLine
                strsql += "WH_PalletType, " & Environment.NewLine
                strsql += "whp_parentPallet " & Environment.NewLine
                strsql += ") " & Environment.NewLine

                strsql += "values (" & Environment.NewLine
                strsql += "'" & UCase(Trim(strChildPallet)) & "', " & Environment.NewLine
                strsql += R1("WHPallet_NoBox") & ", " & Environment.NewLine
                strsql += "Now()" & ", " & Environment.NewLine
                strsql += R1("Model_ID") & ", " & Environment.NewLine
                strsql += R1("Cust_ID") & ", " & Environment.NewLine   'lan add Cust_ID
                strsql += R1("SKU_ID") & ", " & Environment.NewLine   'lan add SKU_ID
                strsql += "'" & R1("WHP_SKU") & "', " & Environment.NewLine
                strsql += "'" & R1("WHP_Lot") & "', " & Environment.NewLine
                strsql += "'" & R1("WHP_Skid") & "', " & Environment.NewLine
                strsql += "'" & R1("WH_PalletType") & "'," & Environment.NewLine
                strsql += iPalletID & Environment.NewLine
                strsql += ");"

                objMisc._SQL = strsql
                Me.ChildPalletID = objMisc.idTransaction(strsql, "twarehousepallet")

                If Me.ChildPalletID = 0 Then
                    Throw New Exception("Fail to create a child pallet.")
                End If

                Return strChildPallet
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
            End Try
        End Function

        '**************************************************************Lan 12/06/2006
        Public Function MoveDeviceToSubPallet(ByVal strDevSN As String, _
                                              ByVal iParentGroupID As Integer) As Integer
            Dim strsql As String = ""

            strsql = "Update twarehousepalletload " & Environment.NewLine
            strsql &= "set twarehousepalletload.whpallet_id = " & iChildPalletID & " " & Environment.NewLine
            strsql &= "where twarehousepalletload.WHP_PieceIdentifier = '" & strDevSN & "' and " & Environment.NewLine
            strsql &= "twarehousepalletload.whpallet_id = " & iPalletID & " and " & Environment.NewLine
            strsql &= "WHP_RcvdFlag = " & iParentGroupID & ";"
            Try
                objMisc._SQL = strsql
                Return objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Function

        '**************************************************************Lan 12/06/2006
        Public Function ClosePallet_GAMESTOP(ByVal iCloseParent As Integer, _
                                             ByVal iChildPalletQty As Integer, _
                                             ByVal strPallett As String, _
                                             ByVal strChildPallet As String, _
                                             ByVal iCust_id As Integer) As Integer

            Dim strsql As String = ""
            Dim i As Integer = 0

            Try
                If iCloseParent = 1 Then
                    strsql = "Update twarehousepallet set WHPalletClosed = 1 " & Environment.NewLine
                    strsql &= "where WHPallet_Number = '" & strPallett & "' and whpallet_id = " & Me.iPalletID & " and " & Environment.NewLine
                    strsql &= "Cust_id = " & iCust_id & ";"
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery
                    If i = 0 Then
                        Throw New Exception("Can not close parent pallet.")
                    End If
                End If
                strsql = "Update twarehousepallet set WHPalletClosed = 1,WHP_CountedQty = " & iChildPalletQty & ", WHP_FileQty = " & iChildPalletQty & " " & Environment.NewLine
                strsql &= "where WHPallet_Number = '" & strChildPallet & "' and whpallet_id = " & Me.iChildPalletID & " and " & Environment.NewLine
                strsql &= "Cust_id = " & iCust_id & ";"
                objMisc._SQL = strsql
                i = objMisc.ExecuteNonQuery
                If i = 0 Then
                    Throw New Exception("Can not close child pallet.")
                Else
                    Return i
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************Lan 12/06/2006
        Public Function GetChildPallets(ByVal strPallet As String) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select * from twarehousepallet where WHPallet_Number like '" & strPallet & "_%';"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '**************************************************************Lan 04/03/2007
        Public Function GetWHPalletInfo(ByVal iCust_id As Integer, _
                                        ByVal strWHPallet_Number As String) As DataTable
            Dim strSql As String = ""
            Dim dt1 As DataTable

            Try
                strSql = "select tmodel.Model_Desc, twarehousepallet.* from twarehousepallet " & Environment.NewLine
                strSql &= "inner join tmodel on twarehousepallet.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "where cust_id = " & iCust_id & " and " & Environment.NewLine
                strSql &= "WHPallet_Number = '" & strWHPallet_Number & "';"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '**************************************************************Lan 04/03/2007
        Public Function ChangePalletModel(ByVal iCust_id As Integer, _
                                          ByVal iModel_id As Integer, _
                                          ByVal strWHPallet_Number As String, _
                                          ByVal dt1 As DataTable) As Integer
            Dim strSql As String = ""
            Dim dt2 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If R1("WHPalletClosed") = 1 Then
                        strSql = "select count(*) as cnt from tworkorder " & Environment.NewLine
                        strSql &= "inner join tlocation on tworkorder.loc_id = tlocation.loc_id " & Environment.NewLine
                        strSql &= "where WO_RecPalletName = '" & strWHPallet_Number & "' and " & Environment.NewLine
                        strSql &= "cust_id = " & iCust_id & ";"
                        objMisc._SQL = strSql
                        dt2 = objMisc.GetDataTable
                        If dt2.Rows(0)("cnt") > 0 Then
                            Throw New Exception("This pallet is already 'File Received'. Can not change the model now.")
                        End If
                    End If

                    'Change model
                    strSql = "update twarehousepallet set model_id = " & iModel_id & " where whpallet_id = " & R1("WHPallet_ID") & ";"
                    objMisc._SQL = strSql
                    i = Me.objMisc.ExecuteNonQuery
                Else
                    Throw New Exception("There is no information for the pallet.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try

        End Function

        '**************************************************************Lan 04/03/2007
        Public Function IsSNExistedInWHR(ByVal iCust_id As Integer, _
                                          ByVal strWHPallet_Number As String, _
                                          ByVal strBoxSN As String, _
                                          ByVal strDevSN As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strSNCondtion As String = ""

            Try
                If strBoxSN <> "" And strDevSN <> "" Then
                    strSNCondtion = "WHR_Box_SN = '" & strBoxSN & "' and WHR_Dev_SN = '" & strDevSN & "' "
                ElseIf strBoxSN <> "" Then
                    strSNCondtion = "WHR_Box_SN = '" & strBoxSN & "' "
                ElseIf strDevSN <> "" Then
                    strSNCondtion = "WHR_Dev_SN = '" & strDevSN & "' "
                End If

                strSql = "select twarehousereceive.* from twarehousereceive " & Environment.NewLine
                strSql &= "inner join twarehousepallet on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strSql &= "where " & strSNCondtion & " " & Environment.NewLine
                strSql &= "and WHPallet_Number = '" & strWHPallet_Number & "' " & Environment.NewLine
                strSql &= "and cust_id = " & iCust_id & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
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


        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        'FOLLOWING ARE THE FUNCTIONS USED IN SENDING SHIPPING FILES TO CUSTOMER.
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        Public Function GetEmailAddressList(ByVal iCust_id As Integer, _
                                             ByVal strToCcFr As String, _
                                             ByVal strShipmentType As String) As String
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strOutput As String = ""

            Try
                strSql = "SELECT email_address FROM tcustemaillist where email_inactive = 0 AND cust_id = " & iCust_id & " and TO_CC = '" & strToCcFr & "';"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("email_address")) Then
                        'If iCust_id = 14 And strToCcFr.Trim.ToUpper = "TO" And strShipmentType.ToUpper = "NER" And R1("email_address") = "ITOperations@americanmessaging.net" Then
                        '    '//Don't add
                        'Else
                        If strOutput.Trim.Length > 0 Then strOutput &= ";"
                        strOutput &= Trim(R1("email_address"))
                        'End If
                    End If
                Next R1

                Return strOutput
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

        ''**********************************************************************
        'Public Function PrintUPCLabel(ByVal iModelID As Integer, _
        '                              ByVal iCustID As Integer, _
        '                              ByVal iCopies As Integer) As Integer
        '    Const strReportName As String = "UPC Label.rpt"
        '    Dim strSql As String
        '    Dim dt As DataTable

        '    Try
        '        strSql = "SELECT DISTINCT UPC_Code, cust_model_number " & Environment.NewLine
        '        strSql &= "FROM tmodel A" & Environment.NewLine
        '        strSql &= "INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID " & Environment.NewLine
        '        strSql &= "WHERE A.Model_ID = " & iModelID & Environment.NewLine
        '        strSql &= "AND B.Cust_ID = " & iModelID & Environment.NewLine
        '        Me.objMisc._SQL = strSql : dt = Me.objMisc.GetDataTable()

        '        PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, iCopies, )

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '**********************************************************************
        Public Function PrintUPCLabel(ByVal strItemNo As String, _
                                      ByVal strItemDesc As String, _
                                      ByVal strUPCCode As String, _
                                      ByVal iCopies As Integer) As Integer
            Const strReportName As String = "UPC Label.rpt"
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT '" & strItemNo & "' as PartNo " & Environment.NewLine
                strSql &= ", '" & strItemDesc & "' as Description " & Environment.NewLine
                strSql &= ", '" & strUPCCode & "' as UPC " & Environment.NewLine
                Me.objMisc._SQL = strSql : dt = Me.objMisc.GetDataTable()

                PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, iCopies, )

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************


    End Class
End Namespace