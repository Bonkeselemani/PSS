Option Explicit On 

Imports Microsoft.Data.Odbc
Imports System.IO
Imports System.Text

Namespace Buisness
    Public Class Inventory
        Private _objMisc As Production.Misc
        Private iCurrentFlg As Integer = 0
        Private iEmailFlg As Integer = 0
        Private iMMMID As Integer = 0
        Private _objNavConn As OdbcConnection = Nothing
        '**********************************************************

        Private strConsumptionStartDate As String
        Public Property ConsumptionStartDate() As String
            Get
                Return strConsumptionStartDate
            End Get
            Set(ByVal Value As String)
                strConsumptionStartDate = Value
            End Set
        End Property

        Private strShift As String = ""
        Public Property Shift() As String
            Get
                Return strShift
            End Get
            Set(ByVal Value As String)
                strShift = Value
            End Set
        End Property

        Private strBin As String = ""
        Public Property BinCode() As String
            Get
                Return strBin
            End Get
            Set(ByVal Value As String)
                strBin = Value
            End Set
        End Property

        Private strMachineName As String = System.Net.Dns.GetHostName
        Public Property MachineName() As String
            Get
                Return strMachineName
            End Get
            Set(ByVal Value As String)
                strMachineName = Value
            End Set
        End Property
        '**********************************************************
        'Get Consumption Date
        '**********************************************************
        Public Function CreateShopFloorOnHandReport() As Integer
            Dim strsql As String = ""
            'Dim i As Integer = 4
            Dim dt1, dt2, dt3, dtProdActiveBin As DataTable
            Dim R1, R2, R3, drFiltered() As DataRow
            Dim drSelect() As DataRow
            'Dim j As Integer = 1
            'Dim strRegisteringDate As String = ""

            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strSheetName() As String = {"Cellular", "Messaging", "HTC"}
            'Dim strFilter() As String = {"SFCELL%", "SFM%"}
            Dim strFilter() As String = {"SFCELL%", "MESS%", "SFCH1"}
            Dim i, j, k, l As Integer
            Dim objOutput(,) As Object

            Try
                Me.GetSheetNameAndFilter(strSheetName, strFilter, dtProdActiveBin)

                '*************************************************************
                'Step 1: Get Last Navision Post Date
                '*************************************************************
                Me.SetConsumptionDate()
                '*************************************************************
                'Step 2: Get Bincontent for Navision
                '*************************************************************
                dt1 = GetBinContent()

                For Each R1 In dt1.Rows
                    'If String.Equals(R1("Bin Code").ToString.Substring(0, 3), "SFM") Then
                    '    R1.BeginEdit()
                    '    R1("Bin Code") = "MESSAGING"
                    '    R1.EndEdit()
                    '    R1.AcceptChanges()
                    'End If
                    For Each R2 In dtProdActiveBin.Rows
                        If R1("Bin Code").ToString = R2("cc_bin") Then
                            R1.BeginEdit()
                            'R1("Bin Code") = R2("cc_bin")
                            R1("Description") = R2("Group_Desc")
                            R1.EndEdit()
                            R1.AcceptChanges()
                        End If
                    Next R2
                Next R1
                '*************************************************************
                'Step 3: Get Items for Navision
                '*************************************************************
                dt3 = GetItems()
                '*************************************************************
                'STEP 4: Update Description in dt1 from dt3
                '*************************************************************
                For Each R1 In dt1.Rows
                    drSelect = dt3.Select("No_ = '" & R1("Item No_").ToString.Trim.ToUpper & "'")

                    If drSelect.Length > 0 Then
                        R1.BeginEdit()
                        R1("Description") = drSelect(0)("Description")
                        R1.EndEdit()
                        R1.AcceptChanges()
                    End If
                Next R1

                dt1.AcceptChanges()
                '*************************************************************
                'Step 5: Get Consumption from PSS DB
                '*************************************************************
                dt2 = Me.GetConsumption()
                '*************************************************************
                For Each R1 In dt1.Rows
                    drSelect = dt2.Select("BIN = '" & R1("Bin Code").ToString.Trim.ToUpper & "' AND psprice_number = '" & R1("Item No_").ToString.Trim.ToUpper & "'")

                    If drSelect.Length > 0 Then
                        R1.BeginEdit()
                        R1("Consumed") = CInt(drSelect(0)("Consumed"))
                        R1.EndEdit()
                        R1.AcceptChanges()
                    End If
                Next R1

                dt1.AcceptChanges()
                '*************************************************************
                'Create Excel File
                '*************************************************************
                ''Initialise Excel objects/properties
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True               'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objBook.Sheets("Sheet1").Delete() : objBook.Sheets("Sheet2").Delete()

                For k = 0 To strSheetName.Length - 1
                    i = 4
                    j = 1
                    objSheet = objBook.Sheets.Add()
                    'objSheet = objBook.Worksheets.Item(k + 1)
                    'objSheet.Activate()
                    objSheet.Name = strSheetName(k)
                    objExcel.ActiveSheet.Pagesetup.Orientation = 2
                    '*****************************************
                    'Columns("A:A").ColumnWidth = 8.57
                    'Columns("B:B").ColumnWidth = 24.86
                    'Columns("C:C").ColumnWidth = 49.57
                    'Columns("D:D").ColumnWidth = 7.14
                    'Columns("E:E").ColumnWidth = 12
                    'Columns("F:F").ColumnWidth = 14.14

                    'Set Alignments of columns
                    objSheet.Columns("A:A").ColumnWidth = 8.57
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                    objSheet.Columns("B:B").ColumnWidth = 24.86
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

                    objSheet.Columns("C:C").ColumnWidth = 49.57
                    objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                    objSheet.Columns("D:D").ColumnWidth = 7.14
                    objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlRight

                    objSheet.Columns("E:E").ColumnWidth = 12
                    objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlRight

                    objSheet.Columns("F:F").ColumnWidth = 14.14
                    objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlRight

                    '******************************************
                    'Set the Column data type
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
                    '******************************************
                    'Report header Format
                    objSheet.Range("A2:B2").Select()
                    With objExcel.Selection
                        .MergeCells = True
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .font.bold = True
                        .Font.Size = 16
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.ColorIndex = 11
                    End With
                    objExcel.Application.Cells(2, 1).Value = strSheetName(k) & " Shop Floor Quantity"
                    '******************************************
                    objExcel.Application.Cells(2, 3).Value = "Consumption from : " & strConsumptionStartDate

                    '******************************************
                    ''Create header of excel file
                    '******************************************
                    objExcel.Application.Cells(i, 1).Value = "BIN"
                    objExcel.Application.Cells(i, 2).Value = "Item No."
                    objExcel.Application.Cells(i, 3).Value = "Item Description"
                    objExcel.Application.Cells(i, 4).Value = "Nav Qty"
                    objExcel.Application.Cells(i, 5).Value = "Consumption"
                    objExcel.Application.Cells(i, 6).Value = "Shop Floor Qty"
                    '******************************************
                    objSheet.Range("A" & i & ":F" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    End With
                    '*************************************************************

                    drFiltered = dt1.Select("[Bin Code] IN (" & strFilter(k) & ")")

                    ReDim objOutput(drFiltered.Length - 1, 5)

                    For l = 0 To drFiltered.Length - 1
                        i += 1
                        If Trim(drFiltered(l)("Quantity")) = "" Then
                            drFiltered(l)("Quantity") = 0
                        End If

                        If Trim(drFiltered(l)("Consumed")) = "" Then
                            drFiltered(l)("Consumed") = 0
                        End If

                        objOutput(l, 0) = Trim(drFiltered(l)("Bin Code"))
                        objOutput(l, 1) = Trim(drFiltered(l)("Item No_"))
                        objOutput(l, 2) = Trim(drFiltered(l)("Description"))
                        objOutput(l, 3) = Trim(drFiltered(l)("Quantity"))
                        objOutput(l, 4) = Trim(drFiltered(l)("Consumed"))
                        objOutput(l, 5) = drFiltered(l)("Quantity") - drFiltered(l)("Consumed")
                    Next l

                    objSheet.Range("A5:F" & (4 + drFiltered.Length).ToString).Value = objOutput

                    objExcel.ActiveWindow.FreezePanes = False
                    objExcel.Range("A5:F5").Select()
                    objExcel.ActiveWindow.FreezePanes = True
                Next k

                objBook.Sheets("Sheet3").Delete()

                '*************************************************************
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
            End Try
        End Function

        '********************************************************************************
        Private Sub GetSheetNameAndFilter(ByRef strSheetName() As String, _
                                          ByRef strFilter() As String, _
                                          ByRef dtProdActiveBin As DataTable)
            Dim strSql As String = ""
            Dim R1, drArrCC() As DataRow
            Dim strBinList As String = ""
            Dim dtGroups As DataTable
            Dim i, j As Integer

            Try
                strSql = "SELECT DISTINCT A.Group_ID" & Environment.NewLine
                strSql &= "FROM tcostcenter A " & Environment.NewLine
                strSql &= "INNER JOIN lgroups B ON A.Group_ID = B.Group_ID " & Environment.NewLine
                strSql &= "WHERE cc_bin is not null AND  cc_bin <> '' AND cc_inactive = 0 AND B.Active = 1 " & Environment.NewLine
                Me._objMisc._SQL = strSql
                dtGroups = Me._objMisc.GetDataTable

                If dtGroups.Rows.Count > 0 Then
                    ReDim strSheetName(dtGroups.Rows.Count - 1)
                    ReDim strFilter(dtGroups.Rows.Count - 1)
                    i = 0 : j = 0

                    strSql = "SELECT DISTINCT A.Group_ID, Group_Desc, cc_bin " & Environment.NewLine
                    strSql &= "FROM tcostcenter A " & Environment.NewLine
                    strSql &= "INNER JOIN lgroups B ON A.Group_ID = B.Group_ID " & Environment.NewLine
                    strSql &= "WHERE cc_bin is not null AND  cc_bin <> '' AND cc_inactive = 0 AND B.Active = 1 " & Environment.NewLine
                    Me._objMisc._SQL = strSql
                    dtProdActiveBin = Me._objMisc.GetDataTable

                    For Each R1 In dtGroups.Rows
                        strBinList = ""
                        drArrCC = dtProdActiveBin.Select("Group_ID = " & R1("Group_ID"))
                        If drArrCC.Length > 0 Then
                            strSheetName(i) = drArrCC(0)("Group_Desc")
                            For j = 0 To drArrCC.Length - 1
                                If strBinList.Trim.Length > 0 Then strBinList &= ", "
                                strBinList &= "'" & drArrCC(j)("cc_bin") & "'"
                            Next j
                            strFilter(i) = strBinList
                            i += 1
                        End If
                    Next R1
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtGroups) Then
                    dtGroups.Dispose()
                    dtGroups = Nothing
                End If
                R1 = Nothing : drArrCC = Nothing
            End Try
        End Sub

        '********************************************************************************

        Private Function GetConsumption() As DataTable
            Dim strsql As String = ""

            Try
                'strsql = "Select UPPER(TRIM(if(tworkorder.Group_ID=2,'SFCELL', if(tworkorder.Group_ID=3, 'SFCELL2', '')))) as BIN, " & Environment.NewLine
                'strsql = "Select UPPER(TRIM((CASE WHEN tworkorder.Group_ID = 1 THEN 'MESSAGING' WHEN tworkorder.Group_ID = 2 THEN 'SFCELL' WHEN tworkorder.Group_ID = 3 THEN 'SFCELL2' WHEN tworkorder.Group_ID = 79 THEN 'SFCH1' ELSE '' END))) AS BIN, " & Environment.NewLine
                strsql = "SELECT cc_bin AS BIN, " & Environment.NewLine
                strsql &= "UPPER(TRIM(lpsprice.psprice_number)) AS psprice_number,  " & Environment.NewLine
                'strsql &= "lpsprice.PSPrice_Desc,  " & Environment.NewLine
                strsql &= "SUM(trans_amount) as Consumed " & Environment.NewLine
                strsql &= "from tdevice inner join tparttransaction on tdevice.device_id = tparttransaction.device_id " & Environment.NewLine
                strsql &= "inner join tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strsql &= "inner join lbillcodes on tparttransaction.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strsql &= "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id  " & Environment.NewLine
                strsql &= "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id  " & Environment.NewLine
                strsql &= "where workdate > '" & Format(CDate(strConsumptionStartDate), "yyyy-MM-dd") & "' and " & Environment.NewLine
                strsql &= "lbillcodes.billtype_id = 2 " & Environment.NewLine
                'strsql &= "and lbillcodes.Device_ID IN (1, 2)" & Environment.NewLine
                strsql &= "group by cc_bin, lpsprice.psprice_number " & Environment.NewLine
                strsql &= "order by BIN, psprice_number;"

                _objMisc._SQL = strsql
                Return _objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetConsumption(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        Private Sub CreateNavisionConnection()
            If IsNothing(Me._objNavConn) Then
                Me._objNavConn = New OdbcConnection("DSN=Navision Database")

                Me._objNavConn.Open()
            End If
        End Sub

        '****************************************************************
        'Sets begin date of the date range we have to pull consumption for.
        '****************************************************************
        Private Sub SetConsumptionDate()
            Dim strSql As String = ""
            Dim MyCmd As New OdbcCommand()
            Dim MyDA As New OdbcDataAdapter()
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                CreateNavisionConnection()

                'Get the last Registering date
                '**************************************
                strSql = "Select Max(""Registering Date"") as ""Registering Date"" from ""Warehouse Entry"" where ""Source No_"" = 'PSSINETWIPXFER'"

                MyCmd = New OdbcCommand(strSql, Me._objNavConn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt1)
                R1 = dt1.Rows(0)
                strConsumptionStartDate = Trim(R1("Registering Date"))
            Catch ex As Exception
                Throw New Exception("Inventory.ImportBinContentFromNavisionToPSSI(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If
                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If
            End Try
        End Sub

        Public Function GetBinContent() As DataTable
            Dim strSql As String = ""
            Dim MyCmd As New OdbcCommand()
            Dim MyDA As New OdbcDataAdapter()
            Dim dt As New DataTable()
            Dim strProdActiveBinList As String = ""

            Try
                strProdActiveBinList = Me.GetProdActiveBinList()
                CreateNavisionConnection()

                '**************************************
                'Get BinContent Info from Navision
                '**************************************
                'strSql = "Select ""Bin Code"", ""Item No_"", Quantity, '' as Description, '' as Consumed from ""Bin Content"" where ""Bin Code"" in ('SFCELL', 'SFCELL2') order by ""Bin Code"", ""Item No_"""
                strSql = "Select ""Bin Code"", ""Item No_"", Quantity, '' AS Description, '' AS Consumed" & Environment.NewLine
                'strSql = "SELECT CASE ""Bin Code"" WHEN 'SFCELL' THEN 'SFCELL' WHEN 'SFCELL2' THEN 'SFCELL2' ELSE 'MESSAGING' END AS ""Bin Code"", " & Environment.NewLine
                'strSql &= """Item No_"", Quantity, '' AS Description, '' AS Consumed" & Environment.NewLine
                strSql &= "FROM ""Bin Content""" & Environment.NewLine
                'strSql &= "WHERE ""Bin Code"" IN ('SFCELL', 'SFCELL2', 'SFMA', 'SFMB', 'SFMC', 'SFMD', 'SFME', 'SFMF', 'SFMG', 'SFCH1')" & Environment.NewLine
                strSql &= "WHERE ""Bin Code"" IN (" & strProdActiveBinList & ")" & Environment.NewLine
                strSql &= "ORDER BY ""Bin Code"", ""Item No_"""

                MyCmd = New OdbcCommand(strSql, Me._objNavConn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt)

                Return dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetBinContent(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If

                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '**********************************************
        Private Function GetProdActiveBinList() As String
            Dim strSql As String = ""
            Dim strActiveBinList As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT DISTINCT cc_bin FROM tcostcenter WHERE cc_inactive = 0;"
                Me._objMisc._SQL = strSql
                dt = Me._objMisc.GetDataTable()

                For Each R1 In dt.Rows
                    If strActiveBinList.Trim.Length > 0 Then strActiveBinList &= ", "
                    strActiveBinList &= "'" & R1("cc_bin") & "'"
                Next R1

                Return strActiveBinList
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************
        Public Function GetItems() As DataTable
            Dim strSql As String = ""
            Dim MyCmd As New OdbcCommand()
            Dim MyDA As New OdbcDataAdapter()
            Dim dt As New DataTable()

            Try
                CreateNavisionConnection()

                '**************************************
                'Get BinContent Info from Navision
                '**************************************
                'strSql = "Select UCASE(LTRIM(RTRIM(No_))) AS No_, Description, ""Shelf No_"", ""Indirect Cost %"" from Item"
                strSql = "SELECT UCASE(LTRIM(RTRIM(No_))) AS No_, Description, ""Shelf No_"", ""Indirect Cost %""" & Environment.NewLine
                strSql &= "FROM Item"

                MyCmd = New OdbcCommand(strSql, Me._objNavConn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt)

                Return dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetItems(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If

                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '**********************************************************

        'Public Sub ImportItemsFromNavisionToPSSI()
        '    Dim _Conn As OdbcConnection
        '    Dim strSql As String = ""
        '    Dim MyCmd As OdbcCommand
        '    Dim MyDA As OdbcDataAdapter
        '    Dim dt1 As New DataTable()
        '    Dim R1 As DataRow
        '    Dim i As Integer = 0
        '    Dim strDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        '    Dim strDesc As String = ""
        '    Dim strShelfNo As String = ""
        '    Dim strNo As String = ""
        '    Dim iIndirectCost As Integer = 0

        '    Try
        '        _Conn = New OdbcConnection("DSN=Navision Database")
        '        _Conn.Open()
        '        MyDA = New OdbcDataAdapter()
        '        '**************************************
        '        'Get the Item table Info from Navision
        '        '**************************************
        '        strSql = "Select No_, Description, ""Shelf No_"", ""Indirect Cost %"" from Item"
        '        MyCmd = New OdbcCommand(strSql, _Conn)
        '        MyDA.SelectCommand = MyCmd
        '        MyDA.Fill(dt1)

        '        If dt1.Rows.Count > 0 Then
        '            '**************************************
        '            'Delete All  records from tnav_item
        '            '**************************************
        '            DeleteAllRecords("tnav_item")

        '            '**************************************
        '            'Insert in to PSS Database table tnav_item
        '            '**************************************
        '            For Each R1 In dt1.Rows

        '                If IsDBNull(R1("Description")) Then
        '                    strDesc = ""
        '                Else
        '                    If Len(Trim(R1("Description"))) = 0 Then
        '                        strDesc = ""
        '                    Else
        '                        strDesc = Replace(Replace(Trim(R1("Description")), "'", "''"), """", """""")
        '                    End If
        '                End If

        '                If IsDBNull(R1("Shelf No_")) Then
        '                    strShelfNo = ""
        '                Else
        '                    If Len(Trim(R1("Shelf No_"))) = 0 Then
        '                        strShelfNo = ""
        '                    Else
        '                        strShelfNo = Replace(Replace(Trim(R1("Shelf No_")), "'", "''"), """", """""")
        '                    End If
        '                End If

        '                If IsDBNull(R1("No_")) Then
        '                    strNo = ""
        '                Else
        '                    If Len(Trim(R1("No_"))) = 0 Then
        '                        strNo = ""
        '                    Else
        '                        strNo = Replace(Replace(Trim(R1("No_")), "'", "''"), """", """""")
        '                    End If
        '                End If

        '                If IsDBNull(R1("Indirect Cost %")) Then
        '                    iIndirectCost = 0
        '                Else
        '                    If Len(Trim(R1("Indirect Cost %"))) = 0 Then
        '                        iIndirectCost = 0
        '                    Else
        '                        iIndirectCost = R1("Indirect Cost %")
        '                    End If
        '                End If

        '                If Len(strNo) > 0 Then
        '                    strSql = ""
        '                    strSql = "Insert into tnav_item " & Environment.NewLine
        '                    strSql += "(No_, Description, Shelf_No_, MaxQty, ImportDate) " & Environment.NewLine
        '                    strSql += "Values ('" & strNo & "', " & Environment.NewLine

        '                    If strDesc = "" Then
        '                        strSql += "NULL, " & Environment.NewLine
        '                    Else
        '                        strSql += "'" & strDesc & "', " & Environment.NewLine
        '                    End If

        '                    If strShelfNo = "" Then
        '                        strSql += "NULL, " & Environment.NewLine
        '                    Else
        '                        strSql += "'" & strShelfNo & "', " & Environment.NewLine
        '                    End If

        '                    strSql += iIndirectCost & ", " & Environment.NewLine
        '                    strSql += "'" & strDate & "');"

        '                    objData._SQL = strSql
        '                    i = objData.ExecuteNonQueries
        '                End If

        '            Next R1
        '            '**************************************
        '        End If

        '    Catch ex As Microsoft.Data.Odbc.OdbcException
        '        Throw New Exception("Int_Biz.ImportItemsFromNavisionToPSSI(): " & Environment.NewLine & "Could not connect to Navision.")
        '    Catch ex As Exception
        '        Throw New Exception("Int_Biz.ImportItemsFromNavisionToPSSI(): " & Environment.NewLine & ex.Message.ToString)
        '    Finally
        '        R1 = Nothing
        '        If Not IsNothing(dt1) Then
        '            dt1.Dispose()
        '            dt1 = Nothing
        '        End If
        '        If _Conn.State = ConnectionState.Open Then
        '            _Conn.Close()
        '        End If
        '        If Not IsNothing(_Conn) Then
        '            _Conn.Dispose()
        '            _Conn = Nothing
        '        End If
        '        If Not IsNothing(MyCmd) Then
        '            MyCmd.Dispose()
        '            MyCmd = Nothing
        '        End If
        '        If Not IsNothing(MyDA) Then
        '            MyDA.Dispose()
        '            MyDA = Nothing
        '        End If
        '    End Try
        'End Sub

        '**********************************************************
        Public Function NotifyModelChangeToPartsCage(ByVal iGroupID As Integer, _
                                                    ByVal StrCurDtTime As String) As Integer
            Dim dt1, dt2, dt3 As DataTable
            Dim R1, R2, R3 As DataRow
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim k As Integer = 0
            Dim iFlag As Integer = 0
            Dim iTestDone As Integer = 0
            Dim iPartAlreadyExistsOnBench As Integer = 0

            Try
                'Get all models on machines for a group
                _objMisc._SQL = "Select * from tmachinemodelmap where Group_ID = " & iGroupID & " and MMM_EmailFlg <> 0;"
                dt1 = _objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    '*****************************************
                    'New Code
                    If R1("MMM_EmailFlg") = -1 Then     'if removing parts from the bench then the bench must have those parts on it.
                        strsql = "Select tmachinemodelmap.MMM_ID, tmachinemodelmap.WCLocation_ID, lwclocation.WC_Machine, tnav_item.No_, lpsprice.PSPrice_MaxQty, " & Environment.NewLine
                        strsql += "IF((tparttranssummary.tpts_NewQty - tparttranssummary.tpts_ConsumedQty) < 0, 0, (tparttranssummary.tpts_NewQty - tparttranssummary.tpts_ConsumedQty)) AS QtyOnBench, " & Environment.NewLine
                        strsql += "tmachinemodelmap.MMM_EmailFlg " & Environment.NewLine
                        strsql += "from tpsmap " & Environment.NewLine
                        strsql += "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql += "inner join tnav_item on lpsprice.PSPrice_Number = tnav_item.No_ " & Environment.NewLine
                        strsql += "inner join tmachinemodelmap on tpsmap.Model_ID = tmachinemodelmap.Model_ID " & Environment.NewLine
                        strsql += "inner join lwclocation on tmachinemodelmap.WCLocation_ID = lwclocation.WCLocation_ID " & Environment.NewLine
                        strsql += "inner join tparttranssummary on lwclocation.WC_Machine = tparttranssummary.tpts_Machine and tnav_item.No_ = tparttranssummary.tpts_ItemNo " & Environment.NewLine
                        strsql += "where tmachinemodelmap.MMM_ID = " & R1("MMM_ID") & " and " & Environment.NewLine
                        strsql += "tnav_item.Shelf_No_ = 'BENCH' and " & Environment.NewLine
                        strsql += "tmachinemodelmap.Group_ID = " & iGroupID & " and " & Environment.NewLine
                        strsql += "tpsmap.Inactive = 0 and " & Environment.NewLine
                        strsql += "MMM_EmailFlg <> 0;"
                    ElseIf R1("MMM_EmailFlg") = 1 Then  'Adding parts  to the bench.
                        strsql = ""
                        strsql = "Select tmachinemodelmap.MMM_ID, tmachinemodelmap.WCLocation_ID, lwclocation.WC_Machine, tnav_item.No_, lpsprice.PSPrice_MaxQty, tmachinemodelmap.MMM_EmailFlg " & Environment.NewLine
                        strsql += "from tpsmap " & Environment.NewLine
                        strsql += "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql += "inner join tnav_item on lpsprice.PSPrice_Number = tnav_item.No_ " & Environment.NewLine
                        strsql += "inner join tmachinemodelmap on tpsmap.Model_ID = tmachinemodelmap.Model_ID " & Environment.NewLine
                        strsql += "inner join lwclocation on tmachinemodelmap.WCLocation_ID = lwclocation.WCLocation_ID " & Environment.NewLine
                        strsql += "where tmachinemodelmap.MMM_ID = " & R1("MMM_ID") & " and " & Environment.NewLine
                        strsql += "tnav_item.Shelf_No_ = 'BENCH' and " & Environment.NewLine
                        strsql += "tmachinemodelmap.Group_ID = " & iGroupID & " and " & Environment.NewLine
                        strsql += "tpsmap.Inactive = 0 and " & Environment.NewLine
                        strsql += "MMM_EmailFlg <> 0;"
                    End If

                    _objMisc._SQL = strsql
                    dt2 = _objMisc.GetDataTable

                    For Each R2 In dt2.Rows     'All BENCH parts for a devcie

                        '*************************************************
                        'Check if this part is tied to another model that 
                        'is already on the bench
                        'If Trim(R2("No_")) = "1590043N07" Then
                        '    MsgBox("Stop")
                        'End If

                        strsql = ""
                        strsql = "Select Count(*) as cnt " & Environment.NewLine
                        strsql += "from tpsmap " & Environment.NewLine
                        strsql += "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql += "inner join tnav_item on lpsprice.PSPrice_Number = tnav_item.No_ " & Environment.NewLine
                        strsql += "inner join tmachinemodelmap on tpsmap.Model_ID = tmachinemodelmap.Model_ID " & Environment.NewLine
                        strsql += "where " & Environment.NewLine
                        strsql += "tnav_item.Shelf_No_ = 'BENCH' and " & Environment.NewLine
                        strsql += "tmachinemodelmap.WClocation_ID = " & R2("WCLocation_ID") & " and " & Environment.NewLine
                        strsql += "lpsprice.PSPrice_Number = '" & Trim(R2("No_")) & "' and " & Environment.NewLine
                        strsql += "MMM_emailFlg = 0 and " & Environment.NewLine
                        strsql += "tpsmap.Inactive = 0 and " & Environment.NewLine
                        strsql += "MMM_CurrentFlg = 1;"
                        _objMisc._SQL = strsql
                        dt3 = _objMisc.GetDataTable
                        R3 = dt3.Rows(0)
                        iPartAlreadyExistsOnBench = R3("cnt")

                        R3 = Nothing
                        If Not IsNothing(dt3) Then
                            dt3.Dispose()
                            dt3 = Nothing
                        End If
                        '*************************************************
                        If iPartAlreadyExistsOnBench = 0 Then
                            '******************************************
                            'Check if this Part request already exists 
                            'in tpartreplenish table
                            '******************************************
                            If iTestDone = 0 Then
                                strsql = "Select * from tpartreplenish where tpts_Batch = 0 and MMM_ID = " & R2("MMM_ID") & ";"
                                _objMisc._SQL = strsql
                                dt3 = _objMisc.GetDataTable
                                iTestDone = 1
                                If dt3.Rows.Count > 0 Then
                                    If R2("MMM_EmailFlg") = -1 Then     'Recover
                                        For Each R3 In dt3.Rows
                                            'Update tparttranssummary set tpts_Flag = 0
                                            '_objMisc._SQL = "update tparttranssummary set tpts_Flag = 0 where tpts_machine = '" & R3("tpts_Machine") & "' and tpts_itemno = '" & R3("tpts_itemno") & "';"
                                            'j = _objMisc.ExecuteNonQuery

                                            'Remove from tpartReplenish
                                            _objMisc._SQL = "Delete from tpartreplenish where tpts_ID = " & R3("tpts_ID")
                                            j = _objMisc.ExecuteNonQuery
                                        Next R3
                                    ElseIf R2("MMM_EmailFlg") = 1 Then  'Replenish
                                        Exit For
                                    End If
                                End If
                                R3 = Nothing
                                If Not IsNothing(dt3) Then
                                    dt3.Dispose()
                                    dt3 = Nothing
                                End If
                            End If
                            '*******************************************
                            'Insert into tparttranssummary
                            '*******************************************
                            If R1("MMM_EmailFlg") = 1 Then  'Adding parts to the bench.
                                'Check if this part exists on this machine in tparttranssummary
                                strsql = "Select Count(*) as cnt from tparttranssummary where tpts_itemno = '" & Trim(R2("No_")) & "' and tpts_machine = '" & Trim(R2("WC_Machine")) & "';"
                                _objMisc._SQL = strsql
                                dt3 = _objMisc.GetDataTable
                                R3 = dt3.Rows(0)

                                If R3("cnt") = 0 Then   '''if doen't exist
                                    strsql = ""
                                    strsql = "Insert into tparttranssummary " & Environment.NewLine
                                    strsql += "(tpts_Machine, tpts_ItemNo, tpts_NewQty, tpts_ConsumedQty, tpts_DateTime) " & Environment.NewLine
                                    strsql += "Values ('" & Trim(R2("WC_Machine")) & "', '" & Trim(R2("No_")) & "', 0, 0, '" & StrCurDtTime & "');"
                                    _objMisc._SQL = strsql
                                    j = _objMisc.ExecuteNonQuery
                                End If
                                R3 = Nothing
                                If Not IsNothing(dt3) Then
                                    dt3.Dispose()
                                    dt3 = Nothing
                                End If
                            End If
                            '******************************************
                            'Insert into tpartreplenish
                            '******************************************
                            'strsql = "Select Count(*) as cnt from tpartreplenish where tpts_batch = 0 and tpts_itemno = '" & Trim(R2("No_")) & "' and tpts_machine = '" & Trim(R2("WC_Machine")) & "';"
                            '_objMisc._SQL = strsql
                            'dt3 = _objMisc.GetDataTable
                            'R3 = dt3.Rows(0)

                            'If R3("cnt") = 0 Then   '''if doen't exist
                            strsql = ""
                            strsql = "insert into tpartreplenish " & Environment.NewLine
                            strsql += "( " & Environment.NewLine
                            strsql += "tpts_machine, " & Environment.NewLine
                            strsql += "tpts_ItemNo, " & Environment.NewLine
                            strsql += "tpts_Qty, " & Environment.NewLine
                            strsql += "MMM_ID, " & Environment.NewLine
                            strsql += "tpr_DateTime " & Environment.NewLine
                            strsql += ") values ( " & Environment.NewLine
                            strsql += "'" & R2("WC_Machine") & "', " & Environment.NewLine
                            strsql += "'" & R2("No_") & "', " & Environment.NewLine

                            If R2("MMM_EmailFlg") = -1 Then     'Removing a model
                                strsql += (-1 * R2("QtyOnBench")) & ", " & Environment.NewLine
                            ElseIf R2("MMM_EmailFlg") = 1 Then  'Adding a new model
                                strsql += R2("PSPrice_MaxQty") & ", " & Environment.NewLine
                            End If

                            strsql += R2("MMM_ID") & ", " & Environment.NewLine
                            strsql += "'" & StrCurDtTime & "'" & Environment.NewLine
                            strsql += ");"

                            _objMisc._SQL = strsql
                            i += _objMisc.ExecuteNonQuery        '"i" Gets incremented and shows how many rows have been inserted for a WWW_ID
                            'End If


                            R3 = Nothing
                            If Not IsNothing(dt3) Then
                                dt3.Dispose()
                                dt3 = Nothing
                            End If

                        End If



                        '******************************************
                        'Reset loop variables
                        iFlag = 1
                        iPartAlreadyExistsOnBench = 0
                        '******************************************
                    Next R2
                    '*****************************************
                    'Update email flag in tmachinemodelmap
                    If i > 0 Then       'If i > 0, that means if any rows were inserted then only do the following update
                        strsql = ""

                        If R1("MMM_EmailFlg") = 1 Then
                            strsql = "Update tmachinemodelmap Set MMM_EmailFlg = 0 where MMM_ID = " & R2("MMM_ID") & ";"
                        ElseIf R1("MMM_EmailFlg") = -1 Then
                            strsql = "Update tmachinemodelmap Set MMM_EmailFlg = 0, MMM_CurrentFlg = 0 where MMM_ID = " & R2("MMM_ID") & ";"
                        End If
                        _objMisc._SQL = strsql
                        j = _objMisc.ExecuteNonQuery
                    End If
                    '*****************************************
                    If Not IsNothing(dt3) Then
                        dt3.Dispose()
                        dt3 = Nothing
                    End If
                    '*****************************************
                    'Reset loop variables
                    iTestDone = 0
                    i = 0       'Reset i = 0 for the next iteration of MMM_ID
                    '*****************************************
                Next R1
                '**************************
                'Send email to Parts cage
                If iFlag = 1 Then
                    If dt1.Rows.Count > 0 Then
                        'Send email to parts cage
                        SendEmailNotification("Floor Needs Parts", "Model has been swithched on a production line. Please provide them with the required parts.")
                    End If
                End If
                '**************************
                Return iFlag
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.NotifyModelChangeToPartsCage(): " & Environment.NewLine & ex.Message.ToString)
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
                If Not IsNothing(dt3) Then
                    dt3.Dispose()
                    dt3 = Nothing
                End If
            End Try
        End Function
        '**********************************************************
        Private Shared Sub SendEmailNotification(ByVal strSubject As String, ByVal strBody As String)

            Dim ObjLib As New MyLib.VBNETMAIL()
            Dim i As Integer = 0
            Const _smtpServer As String = "svr_pssimail"
            'Const _smtpServer As String = "172.16.25.20"
            Dim _MailFrom As String = Trim(Environment.UserName) & "@productsupportservices.com"
            Const _MailTo As String = "partscage@productsupportservices.com"

            Try
                With ObjLib
                    .SMTPServer = _smtpServer
                    .MailFrom = _MailFrom
                    .MailTo = _MailTo
                    .Subject = strSubject
                    .Body = strBody
                    i = .SendMail
                End With

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                ObjLib = Nothing
            End Try
        End Sub

        '**********************************************************
        Public Function GetAllMachineModelMappings(Optional ByVal iGroupID As Integer = 0, _
                                                    Optional ByVal iLineID As Integer = 0, _
                                                    Optional ByVal iSideID As Integer = 0, _
                                                    Optional ByVal iWCLocationID As Integer = 0) As DataTable
            Dim strsql As String = ""
            Try
                strsql = "Select " & Environment.NewLine
                strsql += "MMM_ID, " & Environment.NewLine
                'strsql += "tmachinemodelmap.Model_ID, " & Environment.NewLine
                'strsql += "tmachinemodelmap.Group_ID, " & Environment.NewLine
                'strsql += "tmachinemodelmap.WCLocation_ID, " & Environment.NewLine
                strsql += "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql += "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql += "llineside.LineSide_Desc as 'Side', " & Environment.NewLine
                strsql += "lwclocation.WC_Machine as 'Machine', " & Environment.NewLine
                strsql += "lwclocation.WC_Location as 'Bench', " & Environment.NewLine
                strsql += "tmodel.Model_Desc as 'Model' " & Environment.NewLine

                strsql += "from tmachinemodelmap " & Environment.NewLine
                strsql += "inner join lwclocation on tmachinemodelmap.WCLocation_ID = lwclocation.WCLocation_ID " & Environment.NewLine
                strsql += "inner join tgrouplinemap on lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strsql += "inner join lgroups on tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strsql += "inner join lline on tgrouplinemap.Line_ID = lline.Line_ID " & Environment.NewLine
                strsql += "inner join llineside on tgrouplinemap.LineSide_ID = llineside.LineSide_ID " & Environment.NewLine
                strsql += "inner join tmodel on tmachinemodelmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql += " where tmachinemodelmap.MMM_CurrentFlg = 1 " & Environment.NewLine

                If iGroupID > 0 Then
                    strsql += " and lgroups.group_id = " & iGroupID & Environment.NewLine
                End If
                If iLineID > 0 Then
                    strsql += " and lline.line_id = " & iLineID & Environment.NewLine
                End If
                If iSideID > 0 Then
                    strsql += " and llineside.LineSide_id = " & iSideID & Environment.NewLine
                End If
                If iWCLocationID > 0 Then
                    strsql += " and lwclocation.wclocation_id = " & iWCLocationID & Environment.NewLine
                End If

                strsql += " Order by MMM_ID Desc;"

                _objMisc._SQL = strsql
                Return _objMisc.GetDataTable

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetAllMachineModelMappings(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function
        '**********************************************************
        Private Sub CheckMachineModelMappingExists(ByVal iWClocID As Integer, _
                                                        ByVal iModel_ID As Integer, _
                                                        ByVal iAddRemove As Integer)

            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try

                _objMisc._SQL = "Select * from tmachinemodelmap where wclocation_id = " & iWClocID & " and Model_ID = " & iModel_ID & ";"
                dt1 = _objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iCurrentFlg = R1("MMM_CurrentFlg")
                    iEmailFlg = R1("MMM_EmailFlg")
                    iMMMID = R1("MMM_ID")
                Else
                    iCurrentFlg = 0
                    iEmailFlg = 0
                    iMMMID = 0
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CheckMachineModelMappingExists(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub
        '**********************************************************
        Public Function ProcessAddModel(ByVal iGroupID As Integer, _
                                        ByVal iWCLocation_ID As Integer, _
                                        ByVal iModelID As Integer, _
                                        ByVal iAddRemove As Integer) As Integer

            Dim strsql As String = ""
            Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                CheckMachineModelMappingExists(iWCLocation_ID, iModelID, iAddRemove)

                If iAddRemove = 1 Then      'Assigning a model to Machine
                    If iMMMID = 0 Then
                        strsql = "Insert into tmachinemodelmap " & Environment.NewLine
                        strsql += "(" & Environment.NewLine
                        strsql += "Group_ID, " & Environment.NewLine
                        strsql += "WCLocation_ID, " & Environment.NewLine
                        strsql += "Model_ID, " & Environment.NewLine
                        strsql += "MMM_EmailFlg, " & Environment.NewLine
                        strsql += "MMM_CurrentFlg, " & Environment.NewLine
                        strsql += "MMM_Dt" & Environment.NewLine
                        strsql += ") Values (" & Environment.NewLine
                        strsql += iGroupID & ", " & Environment.NewLine
                        strsql += iWCLocation_ID & ", " & Environment.NewLine
                        strsql += iModelID & ", " & Environment.NewLine
                        strsql += iAddRemove & ", " & Environment.NewLine
                        strsql += 1 & ", " & Environment.NewLine
                        strsql += "'" & strDate & "' " & Environment.NewLine
                        strsql += ");"

                        _objMisc._SQL = strsql
                        Return _objMisc.ExecuteNonQuery
                    Else
                        If iCurrentFlg = 1 Then 'And iEmailFlg = 0 Then
                            'Means model has already been assigned to this machine
                            'Do nothing

                        ElseIf iCurrentFlg = 0 Then
                            'Means Model has not been assigned yet.
                            'set the CurrentFlg = 1 and EmailFlg = 1
                            strsql = "Update tmachinemodelmap " & Environment.NewLine
                            strsql += "Set MMM_EmailFlg = " & iAddRemove & ", " & Environment.NewLine
                            strsql += "MMM_CurrentFlg = 1, " & Environment.NewLine
                            strsql += "MMM_Dt = '" & strDate & "' " & Environment.NewLine
                            strsql += "where MMM_ID = " & iMMMID & Environment.NewLine
                            strsql += ";"

                            _objMisc._SQL = strsql
                            Return _objMisc.ExecuteNonQuery
                        End If
                    End If
                ElseIf iAddRemove = -1 Then     'unassigning a model to Machine
                    If iMMMID = 0 Then
                        'This situation should not occur. If we are trying to remove 
                        'a model from the machine there should be a row with 
                        'iMMMID > 0 ; iCurrentFlg = 1 
                        'Do nothing
                        Throw New Exception("This model is not mapped to this machine.")

                    Else
                        If iCurrentFlg = 1 Then
                            If iEmailFlg = 0 Then
                                'Genuine Remove
                                '1. Set the email flag to -1
                                strsql = "Update tmachinemodelmap " & Environment.NewLine
                                strsql += "Set MMM_EmailFlg = " & iAddRemove & ", " & Environment.NewLine
                                strsql += "MMM_Dt = '" & strDate & "' " & Environment.NewLine
                                strsql += "where MMM_ID = " & iMMMID & Environment.NewLine
                                strsql += ";"

                                _objMisc._SQL = strsql
                                Return _objMisc.ExecuteNonQuery
                            ElseIf iEmailFlg = 1 Then
                                'Model is current and is set to be added to the machine
                                'but parts cage has not been notified yet.
                                'There won't be any rows in tpartsreplenish table at this point.
                                '1. Set email flag to 0
                                '2. set current flag = 0
                                strsql = "Update tmachinemodelmap " & Environment.NewLine
                                strsql += "Set MMM_EmailFlg = 0, " & Environment.NewLine
                                strsql += "MMM_CurrentFlg = 0, " & Environment.NewLine
                                strsql += "MMM_Dt = '" & strDate & "' " & Environment.NewLine
                                strsql += "where MMM_ID = " & iMMMID & Environment.NewLine
                                strsql += ";"

                                _objMisc._SQL = strsql
                                Return _objMisc.ExecuteNonQuery
                            ElseIf iEmailFlg = -1 Then
                                'Model is current and it is set to be removed from the machine
                                'do nothing

                            End If
                        ElseIf iCurrentFlg = 0 Then
                            'This situation should not occur also because they can not remove a 
                            'a model that is not current for that machine.
                            'Do nothing
                            Throw New Exception("This model is not mapped to this machine.")

                        End If
                    End If
                End If


            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.ProcessAddModel(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '**********************************************************
        Public Function AssignModelToMachine(ByVal iWCLocation_ID As Integer, _
                                ByVal iLineSideID As Integer, _
                                ByVal iLineID As Integer, _
                                ByVal iGroupID As Integer, _
                                ByVal iModelID As Integer, _
                                ByVal iAddRemove As Integer) As Integer

            Dim strsql As String = ""
            Dim R1 As DataRow
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                If iWCLocation_ID > 0 Then
                    i = ProcessAddModel(iGroupID, _
                                        iWCLocation_ID, _
                                        iModelID, _
                                        iAddRemove)

                ElseIf iLineSideID > 0 Then
                    '********************************************************************
                    'Get all machines for GroupID and LineID and LineSdieID supplied
                    '********************************************************************
                    strsql = "Select lwclocation.WCLocation_ID " & Environment.NewLine
                    strsql += "from tgrouplinemap inner join lwclocation on tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID " & Environment.NewLine
                    strsql += "where tgrouplinemap.Group_ID = " & iGroupID & Environment.NewLine
                    strsql += " and tgrouplinemap.Line_ID = " & iLineID & Environment.NewLine
                    strsql += " and tgrouplinemap.LineSide_ID = " & iLineSideID & Environment.NewLine
                    strsql += " and lwclocation.WC_ActiveConsume = 1 " & Environment.NewLine
                    strsql += ";"

                    _objMisc._SQL = strsql
                    dt1 = _objMisc.GetDataTable

                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            i = ProcessAddModel(iGroupID, _
                                                R1("WCLocation_ID"), _
                                                iModelID, _
                                                iAddRemove)
                        Next R1
                    Else
                        Throw New Exception("There are no 'Machines' tied  to this Group-Line-Side.")
                    End If
                    '********************************************************************
                ElseIf iLineID > 0 Then
                    '********************************************************************
                    'Get all machines for GroupID and LineID supplied
                    '********************************************************************
                    strsql = "Select lwclocation.WCLocation_ID " & Environment.NewLine
                    strsql += "from tgrouplinemap inner join lwclocation on tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID " & Environment.NewLine
                    strsql += "where tgrouplinemap.Group_ID = " & iGroupID & Environment.NewLine
                    strsql += " and tgrouplinemap.Line_ID = " & iLineID & Environment.NewLine
                    strsql += " and lwclocation.WC_ActiveConsume = 1 " & Environment.NewLine
                    strsql += ";"

                    _objMisc._SQL = strsql
                    dt1 = _objMisc.GetDataTable

                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            i = ProcessAddModel(iGroupID, _
                                                R1("WCLocation_ID"), _
                                                iModelID, _
                                                iAddRemove)
                        Next R1
                    Else
                        Throw New Exception("There are no 'Machines' tied  to this Group-Line.")
                    End If
                ElseIf iGroupID > 0 Then
                    '********************************************************************
                    'Get all machines for GroupID supplied
                    '********************************************************************
                    strsql = "Select lwclocation.WCLocation_ID " & Environment.NewLine
                    strsql += "from tgrouplinemap inner join lwclocation on tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID " & Environment.NewLine
                    strsql += "where tgrouplinemap.Group_ID = " & iGroupID & Environment.NewLine
                    strsql += " and lwclocation.WC_ActiveConsume = 1 " & Environment.NewLine
                    strsql += ";"

                    _objMisc._SQL = strsql
                    dt1 = _objMisc.GetDataTable

                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            i = ProcessAddModel(iGroupID, _
                                                R1("WCLocation_ID"), _
                                                iModelID, _
                                                iAddRemove)
                        Next R1
                    Else
                        Throw New Exception("There are no 'Machines' tied  to this Group.")
                    End If
                End If

                Return i

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.AssignModelToMachine(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Function
        '**********************************************************
        Public Function DeleteMapping(ByVal iWCLocationID As Integer) As Integer
            Dim strsql As String = ""

            Try
                strsql = ""
                strsql = "Update lwclocation " & Environment.NewLine
                strsql += "set GrpLineMap_ID = 0 " & Environment.NewLine
                strsql += "where WClocation_ID = " & iWCLocationID & ";"
                _objMisc._SQL = strsql
                Return _objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.DeleteMapping(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '**********************************************************
        'CreateMapping
        Public Function CreateMapping(ByVal iGroupID As Integer, _
                                    ByVal iLineID As Integer, _
                                    ByVal iLineSideID As Integer, _
                                    ByVal iWClocationID As Integer) As Integer

            Dim strsql As String = ""
            Dim iGrpLineMapID As Integer = 0
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                ''''**************************************************************
                ''''Check if the Line is already assigned another group
                ''''**************************************************************
                '''If iLineID > 0 Then
                '''    strsql = "select Count(*) as cnt from tgrouplinemap where Line_ID = " & iLineID & " and Group_ID <> " & iGroupID & ";"
                '''    _objMisc._SQL = strsql
                '''    dt1 = _objMisc.GetDataTable
                '''    R1 = dt1.Rows(0)
                '''    If R1("cnt") > 0 Then
                '''        Throw New Exception("This 'Line' has already been assigned to another Group.")
                '''    End If
                '''End If
                ''''**************************************************************
                '''R1 = Nothing
                '''If Not IsNothing(dt1) Then
                '''    dt1.Dispose()
                '''    dt1 = Nothing
                '''End If
                '''**************************************************************
                strsql = ""
                strsql += "Select GrpLineMap_ID from tgrouplinemap " & Environment.NewLine
                strsql += "where Group_id = " & iGroupID & Environment.NewLine
                strsql += " and Line_id = " & iLineID & Environment.NewLine
                strsql += " and LineSide_id = " & iLineSideID & Environment.NewLine
                strsql += ";"

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iGrpLineMapID = R1("GrpLineMap_ID")
                End If

                '**************************************************************
                If iGrpLineMapID = 0 Then

                    strsql = ""
                    strsql = "Insert into tgrouplinemap " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "Group_ID, " & Environment.NewLine
                    strsql += "Line_ID, " & Environment.NewLine
                    strsql += "LineSide_ID " & Environment.NewLine
                    strsql += ") values (" & Environment.NewLine
                    strsql += iGroupID & ", " & Environment.NewLine
                    strsql += iLineID & ", " & Environment.NewLine
                    strsql += iLineSideID & " " & Environment.NewLine
                    strsql += ")" & Environment.NewLine
                    strsql += ";"

                    _objMisc._SQL = strsql
                    iGrpLineMapID = _objMisc.idTransaction(strsql, "tgrouplinemap")
                End If
                '**************************************************************
                If iGrpLineMapID > 0 Then
                    strsql = ""
                    strsql = "Update lwclocation " & Environment.NewLine
                    strsql += "set GrpLineMap_ID = " & iGrpLineMapID & " " & Environment.NewLine
                    strsql += "where WClocation_ID = " & iWClocationID & ";"
                    _objMisc._SQL = strsql
                    i = _objMisc.ExecuteNonQuery
                End If
                '**************************************************************
                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CreateMapping(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Function


        '**********************************************************
        Public Function SaveLineSide(Optional ByVal strLineSide As String = "", _
                                Optional ByVal iLineSide_ID As Integer = 0) As Integer

            Dim strsql As String = ""

            Try
                If iLineSide_ID > 0 Then
                    strsql = "Update llineside " & Environment.NewLine
                    strsql += "Set LineSide_Desc = '" & strLineSide & "' " & Environment.NewLine
                    strsql += "where LineSide_ID = " & iLineSide_ID & Environment.NewLine
                    strsql += ";" & Environment.NewLine
                Else
                    strsql = "Insert into llineside " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "LineSide_Desc " & Environment.NewLine
                    strsql += ") values (" & Environment.NewLine
                    strsql += "'" & strLineSide & "' " & Environment.NewLine
                    strsql += ")" & Environment.NewLine
                    strsql += ";"
                End If

                _objMisc._SQL = strsql
                Return _objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.SaveLineSide(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function
        '**********************************************************
        Public Function SaveLine(Optional ByVal strLine As String = "", _
                                Optional ByVal iLine_ID As Integer = 0) As Integer

            Dim strsql As String = ""

            Try

                If iLine_ID > 0 Then
                    strsql = "Update lline " & Environment.NewLine
                    strsql += "Set Line_Number = '" & strLine & "' " & Environment.NewLine
                    strsql += "where Line_ID = " & iLine_ID & Environment.NewLine
                    strsql += ";" & Environment.NewLine
                Else
                    strsql = "Insert into lline " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "Line_Number " & Environment.NewLine
                    strsql += ") values (" & Environment.NewLine
                    strsql += "'" & strLine & "' " & Environment.NewLine
                    strsql += ")" & Environment.NewLine
                    strsql += ";"
                End If

                _objMisc._SQL = strsql
                Return _objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.SaveLine(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function
        '**********************************************************
        Public Function DeleteGroup(Optional ByVal iGroup_ID As Integer = 0, _
                                    Optional ByVal strGroupDesc As String = "") As Integer
            Dim strsql As String = ""
            Try
                If iGroup_ID > 0 Then
                    strsql = "Delete from lgroups where Group_ID = " & iGroup_ID & ";"
                ElseIf strGroupDesc <> "" Then
                    strsql = "Delete from lgroups where Group_Desc = " & strGroupDesc & ";"
                End If

                If strsql <> "" Then
                    _objMisc._SQL = strsql
                    Return _objMisc.ExecuteNonQuery
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '**********************************************************
        Public Function SaveGroup(Optional ByVal strGroup As String = "", _
                                  Optional ByVal iGroup_ID As Integer = 0, _
                                  Optional ByVal strManager As String = "", _
                                  Optional ByVal sglIncentAQLFailRate As Single = 0.0) As Integer
            Dim strsql As String = ""

            Try
                If iGroup_ID > 0 Then
                    strsql = "Update lgroups " & Environment.NewLine
                    strsql &= "Set Group_Desc = '" & strGroup & "', " & Environment.NewLine
                    strsql &= "Group_Manager = '" & strManager & "', " & Environment.NewLine
                    strsql &= "Incen_AQL_FailRate_Allowance = " & sglIncentAQLFailRate & Environment.NewLine
                    strsql &= "where Group_ID = " & iGroup_ID & Environment.NewLine
                    strsql &= ";" & Environment.NewLine
                Else
                    strsql = "Insert into lgroups " & Environment.NewLine
                    strsql &= "(" & Environment.NewLine
                    strsql &= "Group_Desc, " & Environment.NewLine
                    strsql &= "Group_Manager, " & Environment.NewLine
                    strsql &= "LikeBucketGrouping, " & Environment.NewLine
                    strsql &= "ReportingSequence," & Environment.NewLine
					strsql &= "Incen_AQL_FailRate_Allowance, " & Environment.NewLine
					strsql &= "MasterGroup" & Environment.NewLine
					strsql &= ") values (" & Environment.NewLine
					strsql &= "'" & strGroup & "', " & Environment.NewLine
                    strsql &= "'" & strManager & "'," & Environment.NewLine
                    strsql &= "2," & Environment.NewLine
					strsql &= "5," & Environment.NewLine
					strsql &= sglIncentAQLFailRate & ", " & Environment.NewLine
					strsql &= "1" & Environment.NewLine
					strsql &= ")" & Environment.NewLine
                    strsql &= ";"
                End If
				_objMisc._SQL = strsql
				Return _objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.SaveGroup(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function

        '**********************************************************
        Public Function SaveMachine(Optional ByVal strMachine As String = "", _
                                Optional ByVal iWCLocation_ID As Integer = 0, _
                                Optional ByVal strBin As String = "", _
                                Optional ByVal iActiveConsumFlag As Integer = 0 _
                                ) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iExists As Integer = 0

            Try
                '**************************************
                'Check if the Machine already exists
                If iWCLocation_ID > 0 Then
                    strsql = "Select Count(*) as cnt from lwclocation where WC_ActiveFlag = 1 and wc_machine = '" & strMachine & "' and wclocation_id <> " & iWCLocation_ID & ";"
                Else
                    strsql = "Select Count(*) as cnt from lwclocation where WC_ActiveFlag = 1 and wc_machine = '" & strMachine & "';"
                End If
                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable
                R1 = dt1.Rows(0)
                iExists = R1("cnt")
                '**************************************
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                '**************************************
                If iExists > 0 Then
                    Throw New Exception("Machine already exists.")
                Else
                    '*******************************************************
                    'COMMENT BY LAN ON 04/08/08. ALLOW MULTIPLE MACHINES MAP TO ONE BIN
                    '*******************************************************
                    'If Len(Trim(strBin)) > 0 Then
                    '    'See if the bin has been assigned to any other machine
                    '    strsql = "Select Count(*) as cnt from lwclocation where WC_ActiveFlag = 1 and wclocation_id <> " & iWCLocation_ID & " and wc_location = '" & strBin & "';"
                    '    _objMisc._SQL = strsql
                    '    dt1 = _objMisc.GetDataTable
                    '    R1 = dt1.Rows(0)
                    '    iExists = R1("cnt")
                    '    If iExists > 0 Then
                    '        Throw New Exception("Bin is already assigned to another Machine.")
                    '    End If
                    'End If
                End If
                '**************************************
                If iWCLocation_ID > 0 Then
                    strsql = "Update lwclocation " & Environment.NewLine
                    strsql += "Set wc_machine = '" & strMachine & "', " & Environment.NewLine
                    strsql += "wc_location = '" & strBin & "', " & Environment.NewLine
                    strsql += "wc_activeconsume = " & iActiveConsumFlag & " " & Environment.NewLine
                    strsql += "where WCLocation_ID = " & iWCLocation_ID & Environment.NewLine
                    strsql += ";" & Environment.NewLine
                Else
                    strsql = "Insert into lwclocation " & Environment.NewLine
                    strsql += "(" & Environment.NewLine
                    strsql += "wc_machine, " & Environment.NewLine
                    strsql += "wc_location, " & Environment.NewLine
                    strsql += "wc_activeflag " & Environment.NewLine

                    strsql += ") values (" & Environment.NewLine
                    strsql += "'" & strMachine & "', " & Environment.NewLine
                    strsql += "'" & strBin & "', " & Environment.NewLine
                    strsql += "1" & Environment.NewLine
                    strsql += ")" & Environment.NewLine
                    strsql += ";"
                End If

                _objMisc._SQL = strsql
                Return _objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.SaveGroup(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function
        '****************************************************************
        Public Function TriggerPartsReplenishment() As Integer
            Dim dt1, dt2, dt3 As DataTable
            Dim R1, R2, R3 As DataRow
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim strCurDtTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Try

                '*****************************************************************
                strsql = ""
                strsql = "Select wclocation_id, wc_location, wc_machine from lwclocation " & Environment.NewLine
                strsql += "where WC_ActiveFlag = 1 and WC_ActiveConsume = 1 order by wclocation_id;"
                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                '*****************************************************************

                For Each R1 In dt1.Rows

                    '*****************************************************************
                    strsql = ""
                    strsql = "Select distinct lpsprice.PSPrice_Number, lpsprice.PSPrice_MaxQty as MaxQty, '' as ReplenishQty " & Environment.NewLine
                    strsql += "from tmachinemodelmap " & Environment.NewLine
                    strsql += "inner join tpsmap on tmachinemodelmap.Model_ID = tpsmap.Model_ID " & Environment.NewLine
                    strsql += "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                    strsql += "inner join tnav_item on lpsprice.PSPrice_Number = tnav_item.No_ " & Environment.NewLine
                    strsql += "where tmachinemodelmap.WCLocation_ID = " & R1("wclocation_id") & " and tnav_item.Shelf_No_ = 'BENCH' and MMM_CurrentFlg = 1;"
                    _objMisc._SQL = strsql
                    dt2 = _objMisc.GetDataTable

                    '*****************************************************************

                    For Each R2 In dt2.Rows

                        '*****************************************************************
                        strsql = ""
                        strsql = "Select tpts_Machine, tpts_ItemNo, tpts_NewQty, tpts_ConsumedQty from tparttranssummary where tpts_Machine = '" & Trim(R1("wc_machine")) & "' and tpts_ItemNo = '" & Trim(R2("PSPrice_Number")) & "' order by tpts_id desc;"
                        _objMisc._SQL = strsql
                        dt3 = _objMisc.GetDataTable
                        If dt3.Rows.Count > 0 Then
                            R3 = dt3.Rows(0)
                            'R2("ReplenishQty") = R2("MaxQty") - (R3("tpts_NewQty") - R3("tpts_ConsumedQty"))
                            R2("ReplenishQty") = R2("MaxQty") - R3("tpts_NewQty")
                            If R2("ReplenishQty") < 0 Then
                                R2("ReplenishQty") = 0
                            End If

                            R2.AcceptChanges()
                            dt2.AcceptChanges()
                        End If

                        R3 = Nothing
                        If Not IsNothing(dt3) Then
                            dt3.Dispose()
                            dt3 = Nothing
                        End If

                        '*****************************************************************
                        'Insert into tpartreplenish
                        strsql = ""
                        strsql = "insert into tpartreplenish " & Environment.NewLine
                        strsql += "( " & Environment.NewLine
                        strsql += "tpts_machine, " & Environment.NewLine
                        strsql += "tpts_ItemNo, " & Environment.NewLine
                        strsql += "tpts_Qty, " & Environment.NewLine
                        'strsql += "tpts_Batch, " & Environment.NewLine
                        strsql += "tpr_DateTime " & Environment.NewLine
                        strsql += ") values ( " & Environment.NewLine
                        strsql += "'" & R1("WC_Machine") & "', " & Environment.NewLine
                        strsql += "'" & R2("PSPrice_Number") & "', " & Environment.NewLine
                        strsql += R2("ReplenishQty") & ", " & Environment.NewLine
                        'strsql &= "999, " & Environment.NewLine
                        strsql += "'" & strCurDtTime & "'" & Environment.NewLine
                        strsql += ");"

                        _objMisc._SQL = strsql
                        i += _objMisc.ExecuteNonQuery()
                        '*****************************************************************

                    Next R2

                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.TriggerPartsReplenishment(): " & Environment.NewLine & ex.Message.ToString)
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
                R3 = Nothing
                If Not IsNothing(dt3) Then
                    dt3.Dispose()
                    dt3 = Nothing
                End If
            End Try


        End Function
        '****************************************************************
        Public Function CreateReplenishPickTicket(Optional ByVal iBatchNo As Integer = 0) As Integer
            Dim strFilePath As String = "R:\InventoryData\BenchReplenish\"
            Dim strFileName As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iBatch As Integer = 0
            Dim i As Integer = 4
            Dim j As Integer = 0
            Dim strsql As String = ""
            Dim iQtyByBench As Integer = 0
            Dim strPrevPartNumber As String = ""
            Dim dv1 As DataView
            Dim strPrevBIN As String = ""

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook        ' Excel workbook
            Dim objSheet As Excel.Worksheet      ' Excel Worksheet

            Try
                '*****************************************
                ''Get the New Batch No
                If iBatchNo = 0 Then    'Means they are recreating the report for the first time
                    _objMisc._SQL = "Select max(tpts_batch) + 1 as BatchNo from tpartreplenish;"
                    dt1 = _objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        R1 = dt1.Rows(0)
                        iBatch = R1("BatchNo")
                    End If

                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                End If
                '*****************************************
                ''Construct the fileName
                strFileName = "BenchReplenish-" & iBatch & ".xls"
                strFilePath = strFilePath & strFileName
                '******************************************
                ''Get the Replenish data from tpartreplenish
                '***************************
                strsql = ""
                strsql = "Select " & Environment.NewLine
                strsql += "tpts_ID, " & Environment.NewLine
                strsql += "tpartreplenish.tpts_ItemNo as 'Item No.', " & Environment.NewLine
                strsql += "lwclocation.WC_Location as 'BIN', " & Environment.NewLine
                strsql += "lwclocation.WC_Machine as 'Machine', " & Environment.NewLine
                strsql += "tnav_item.Description as 'Item Description', " & Environment.NewLine
                strsql += "tpartreplenish.tpts_qty as 'Quantity', " & Environment.NewLine
                strsql += "tpartreplenish.tpts_batch as 'Batch No.' " & Environment.NewLine
                strsql += "from tpartreplenish inner join lwclocation on tpts_Machine = lwclocation.WC_Machine " & Environment.NewLine
                strsql += "inner join tnav_item on tpartreplenish.tpts_ItemNo = tnav_item.No_ " & Environment.NewLine
                If iBatchNo = 0 Then
                    strsql += "where tpts_Batch = 0 " & Environment.NewLine
                Else            'Means they are recreating a report
                    strsql += "where tpts_Batch = " & iBatchNo & " " & Environment.NewLine
                End If
                strsql += "order by 'Item Description', BIN;"

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    ''*****************************************
                    ''Initialise Excel objects/properties
                    '*****************************************
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = False               'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                    '*****************************************
                    '******************************************
                    'Set Alignments of columns
                    objSheet.Columns("A:A").ColumnWidth = 15.3
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                    objSheet.Columns("B:B").ColumnWidth = 36.5
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

                    objSheet.Columns("C:C").ColumnWidth = 30
                    objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                    objSheet.Columns("D:D").ColumnWidth = 12
                    objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter

                    '******************************************
                    'Set the Column data type
                    objSheet.Columns("A:A").Select()
                    objExcel.Selection.NumberFormat = "@"

                    objSheet.Columns("B:B").Select()
                    objExcel.Selection.NumberFormat = "@"

                    objSheet.Columns("C:C").Select()
                    objExcel.Selection.NumberFormat = "@"

                    objSheet.Columns("D:D").Select()
                    objExcel.Selection.NumberFormat = "#,##0" '"#,##0;[Red]#,##0"
                    '************************************************
                    'Report header Format
                    objSheet.Range("A2:B2").Select()
                    With objExcel.Selection
                        .MergeCells = True
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .font.bold = True
                        .Font.Size = 16
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.ColorIndex = 11
                    End With
                    objExcel.Application.Cells(2, 1).Value = "Part Replenish Report"

                    '******************************************
                    ''Create header of excel file
                    '******************************************
                    objExcel.Application.Cells(i, 1).Value = "Item No."
                    objExcel.Application.Cells(i, 2).Value = "Item Description"
                    objExcel.Application.Cells(i, 3).Value = "BIN"
                    objExcel.Application.Cells(i, 4).Value = "Quantity"
                    '******************************************
                    objSheet.Range("A" & i & ":D" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    End With
                    '******************************************
                    i += 1
                    For Each R1 In dt1.Rows
                        If Trim(strPrevPartNumber) <> Trim(R1("Item No.")) Then
                            If Trim(strPrevPartNumber) <> "" Then
                                '***************************************
                                'Write the Total Qty for that Part
                                objExcel.Application.Cells(i, 4).Value = iQtyByBench
                                iQtyByBench = 0

                                objSheet.Range("D" & i).Select()
                                With objExcel.Selection
                                    .font.bold = True
                                    .Interior.ColorIndex = 15
                                    .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                                End With

                                i += 1
                                '***************************************
                            End If

                            objExcel.Application.Cells(i, 1).Value = Trim(R1("Item No."))
                            objExcel.Application.Cells(i, 2).Value = Trim(R1("Item Description"))

                            objSheet.Range("A" & i & ":D" & i).Select()
                            With objExcel.Selection
                                .font.bold = True
                            End With

                            i += 1
                        End If

                        'List out the BIN numbers for a part
                        objExcel.Application.Cells(i, 3).Value = Trim(R1("BIN"))
                        objExcel.Application.Cells(i, 4).Value = R1("Quantity")
                        iQtyByBench += R1("Quantity")
                        i += 1

                        'Reinitialise Loop variables
                        strPrevPartNumber = Trim(R1("Item No."))
                    Next R1

                    '***************************************************
                    'Write the last item total 
                    '***************************************************
                    If Trim(strPrevPartNumber) <> "" Then

                        'Write the Total Qty for that Part
                        objExcel.Application.Cells(i, 4).Value = iQtyByBench
                        iQtyByBench = 0

                        objSheet.Range("D" & i).Select()
                        With objExcel.Selection
                            .font.bold = True
                            .Interior.ColorIndex = 15
                            .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                        End With

                        i += 1

                    End If
                    '***************************************************
                    'Summary by Bin and Part
                    'dvEmployees.Sort = "[Item No.], Deparment"
                    R1 = Nothing
                    i += 2

                    '******************************************
                    ''Create header of excel file
                    '******************************************
                    objExcel.Application.Cells(i, 1).Value = "BIN"
                    objExcel.Application.Cells(i, 2).Value = "Item Description"
                    objExcel.Application.Cells(i, 3).Value = "Item No."
                    objExcel.Application.Cells(i, 4).Value = "Quantity"
                    '******************************************
                    objSheet.Range("A" & i & ":D" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    End With
                    '******************************************
                    i += 1
                    dv1 = dt1.DefaultView

                    dv1.Sort = "BIN, [Item Description]"

                    For j = 0 To dv1.Count - 1

                        If Trim(strPrevBIN) <> Trim(dv1(j)("BIN")) Then
                            i += 1
                            objExcel.Application.Cells(i, 1).Value = Trim(dv1(j)("BIN"))
                            objSheet.Range("A" & i & ":D" & i).Select()
                            With objExcel.Selection
                                .font.bold = True
                            End With
                            i += 1
                        End If

                        'List out the Item numbers for a BIN
                        objExcel.Application.Cells(i, 2).Value = Trim(dv1(j)("Item Description"))
                        objExcel.Application.Cells(i, 3).Value = Trim(dv1(j)("Item No."))
                        objExcel.Application.Cells(i, 4).Value = dv1(j)("Quantity")
                        i += 1

                        'Reinitialise Loop variables
                        strPrevBIN = Trim(dv1(j)("BIN"))

                    Next j

                    '***************************************************
                    j = 4
                    'Set borders
                    objSheet.Range("A" & j & ":D" & (i - 1)).Select()

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

                    '*****************************************
                    ''Update tpartsreplenish with Batch No.
                    For Each R1 In dt1.Rows
                        '*************************************
                        'Update tpartsreplenish with Batch No.
                        If iBatchNo = 0 Then    'Means they are recreating a report
                            _objMisc._SQL = "Update tpartreplenish set tpts_batch = " & iBatch & " where tpts_ID = " & R1("tpts_ID") & ";"
                            j = _objMisc.ExecuteNonQuery()
                        End If

                    Next R1
                    R1 = Nothing

                    '******************************************
                    'Set Datetime
                    objExcel.Application.Cells(2, 3).Value = Now

                    'Write Batch No
                    If iBatchNo = 0 Then    'Means they are recreating a report
                        objExcel.Application.Cells(2, 4).Value = "Batch No: " & iBatch
                    Else
                        objExcel.Application.Cells(2, 4).Value = "Batch No: " & iBatchNo
                    End If

                    '******************************************
                    objExcel.Sheets("Sheet2").Delete()
                    objExcel.Sheets("Sheet3").Delete()

                    '******************************************
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
                        .BottomMargin = objExcel.Application.InchesToPoints(0.25)
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

                    objSheet.Range("A1").Select()

                    '*************************************
                    'Save the excel file
                    objBook.SaveAs(strFilePath)
                    '*************************************
                    'Excel clean up
                    If Not IsNothing(objSheet) Then
                        NAR(objSheet)
                        objSheet = Nothing
                    End If
                    If Not IsNothing(objBook) Then
                        objBook.Close(False)
                        NAR(objBook)
                        objBook = Nothing
                    End If
                    If Not IsNothing(objExcel) Then
                        objExcel.Quit()
                        NAR(objExcel)
                        objExcel = Nothing
                    End If
                    '*************************************
                    'Open Excel File
                    objXL = New Excel.Application()
                    objXL.Workbooks.Open(strFilePath)
                    objXL.Visible = True
                    '******************************************
                    Return 1
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CreateReplenishPickTicket(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dv1) Then
                    dv1.Dispose()
                    dv1 = Nothing
                End If
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                ''Excel clean up
                If Not IsNothing(objSheet) Then
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close(False)
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    NAR(objExcel)
                End If

            End Try

        End Function

        '****************************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '****************************************************************
        Public Function CheckForSystemLocks() As Integer
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                _objMisc._SQL = "Select NavItemTableLock from tflag;"
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    i = R1("NavItemTableLock")
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CheckForSystemLocks(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
        '****************************************************************
        Public Function CreateBenchCycleCountVarianceFile() As Integer
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim strFileLine As String = ""
            Dim strFilePath As String = "R:\InventoryData\Bench Cycle Count Variance\BenchCycleCountVariance.txt"
            Dim strDtTime As String = Format(Now(), "yyyyMMddHHmmss")
            Dim strBackupDir As String = "R:\InventoryData\Bench Cycle Count Variance\Archive\BenchCycleCountVariance" & strDtTime & ".txt"
            Dim strBin As String = ""
            Dim iQty As Integer = 0
            Dim iDept_ID As Integer = 0
            Dim i As Integer = 0
            Dim strTransType As String = ""
            Dim strPostingGroup As String = "BENCH"
            Dim strsql As String = ""
            Dim strPrevBin As String = ""
            Dim strPrevItem As String = ""

            Try
                strsql = "Select " & Environment.NewLine
                strsql += "lgroups.Dept_ID, " & Environment.NewLine
                strsql += "tbenchinvjournal.BIJ_BinCode, " & Environment.NewLine
                strsql += "tbenchinvjournal.BIJ_ItemNo, " & Environment.NewLine
                strsql += "tbenchinvjournal.BIJ_Variance, " & Environment.NewLine
                strsql += "tbenchinvjournal.BIJ_WorkDate, " & Environment.NewLine
                strsql += "tbenchinvjournal.BIJ_DateTime, " & Environment.NewLine
                strsql += "tbenchinvjournal.BIJ_ID " & Environment.NewLine
                strsql += "from tbenchinvjournal  " & Environment.NewLine
                strsql += "inner join lwclocation on tbenchinvjournal.BIJ_Machine = lwclocation.WC_Machine " & Environment.NewLine
                strsql += "inner join tgrouplinemap on lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strsql += "inner join lgroups on tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strsql += "where tbenchinvjournal.BIJ_Flag = 0  " & Environment.NewLine
                strsql += "order by dept_id, BIJ_BinCode, BIJ_ItemNo, BIJ_DateTime Desc;"

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    '********************************
                    'Open the file
                    If Len(Dir(strFilePath)) > 0 Then
                        File.Move(strFilePath, strBackupDir)
                    End If
                    FileOpen(1, strFilePath, OpenMode.Append)
                    '********************************
                    strFileLine = ""
                    For Each R1 In dt1.Rows
                        If strPrevBin = "" Then
                            If R1("BIJ_Variance") >= 0 Then
                                iQty = R1("BIJ_Variance")
                                strTransType = "POSITIVE"
                            Else
                                iQty = -1 * R1("BIJ_Variance")
                                strTransType = "NEGATIVE"
                            End If
                            iDept_ID = R1("Dept_ID")
                            strFileLine += Trim(R1("BIJ_BinCode")) & "," & Trim(R1("BIJ_ItemNo")) & "," & iQty & "," & strTransType & "," & Format(CDate(Trim(R1("BIJ_WorkDate"))), "MM/dd/yyyy") & "," & iDept_ID & "," & strPostingGroup & Environment.NewLine
                        Else
                            If Trim(R1("BIJ_BinCode")) = strPrevBin And Trim(R1("BIJ_ItemNo")) = strPrevItem Then
                                'Do nothing
                            Else
                                If R1("BIJ_Variance") >= 0 Then
                                    iQty = R1("BIJ_Variance")
                                    strTransType = "POSITIVE"
                                Else
                                    iQty = -1 * R1("BIJ_Variance")
                                    strTransType = "NEGATIVE"
                                End If
                                iDept_ID = R1("Dept_ID")
                                strFileLine += Trim(R1("BIJ_BinCode")) & "," & Trim(R1("BIJ_ItemNo")) & "," & iQty & "," & strTransType & "," & Format(CDate(Trim(R1("BIJ_WorkDate"))), "MM/dd/yyyy") & "," & iDept_ID & "," & strPostingGroup & Environment.NewLine
                            End If

                        End If

                        strPrevBin = Trim(R1("BIJ_BinCode"))
                        strPrevItem = Trim(R1("BIJ_ItemNo"))
                    Next R1

                    PrintLine(1, strFileLine)

                    R1 = Nothing

                    '**************************************************
                    'Update tbenchinvjournal Set the BIJ_Flag = 1
                    iQty = 0
                    For Each R1 In dt1.Rows
                        _objMisc._SQL = "Update tbenchinvjournal Set BIJ_Flag = 1 where BIJ_ID = " & R1("BIJ_ID") & ";"
                        iQty = _objMisc.ExecuteNonQuery()
                    Next R1
                    '**************************************************
                    Return iQty
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CreateBenchCycleCountVarianceFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                Reset()
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '****************************************************************
        Public Function CreateReplenishedPartsFile() As Integer
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim strFileLine As String = ""
            Dim strFilePath As String = "R:\InventoryData\ReplenishParts\Replenish_" & Format(Now(), "yyyyMMddHHmmss") & ".txt"
            Dim strSourceBin As String = ""
            Dim strDstnBin As String = ""
            Dim iQty As Integer = 0

            Try
                _objMisc._SQL = "Select * from tpartreplenishtonav where PRDN_Flag = 0;"
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    'Open the file
                    If Len(Dir(strFilePath)) > 0 Then
                        Kill(strFilePath)
                    End If
                    FileOpen(1, strFilePath, OpenMode.Append)
                    strFileLine = ""
                    For Each R1 In dt1.Rows
                        If R1("PRDN_Qty") >= 0 Then
                            strSourceBin = "C-SFTEMP"
                            strDstnBin = Trim(R1("PRDN_Bin"))
                            iQty = R1("PRDN_Qty")
                        Else
                            strSourceBin = Trim(R1("PRDN_Bin"))
                            strDstnBin = "C-SFRETURNS"
                            iQty = -1 * R1("PRDN_Qty")
                        End If
                        'strFileLine += strSourceBin & "," & Trim(R1("PRDN_ItemNo")) & "," & iQty & "," & strDstnBin & "," & "Transfer" & "," & Format(CDate(strWorkDt), "MM/dd/yyyy") & Environment.NewLine
                        strFileLine += strSourceBin & "," & Trim(R1("PRDN_ItemNo")) & "," & iQty & "," & strDstnBin & "," & "Transfer" & "," & Format(CDate(Trim(R1("PRDN_WorkDate"))), "MM/dd/yyyy") & Environment.NewLine
                    Next R1

                    PrintLine(1, strFileLine)

                    R1 = Nothing

                    '**************************************************
                    'Update tpartreplenishtonav Set the PRDN_Flag = 1
                    iQty = 0
                    For Each R1 In dt1.Rows
                        _objMisc._SQL = "Update tpartreplenishtonav Set PRDN_Flag = 1 where PRDN_ID = " & R1("PRDN_ID") & ";"
                        iQty = _objMisc.ExecuteNonQuery()
                    Next R1
                    '**************************************************

                    Return iQty
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CreateReplenishedPartsFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                Reset()
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '****************************************************************
        'replenish parts
        '****************************************************************
        Public Function ReplenishParts(ByVal strWorkDate As String, _
                                        ByVal strItem As String, _
                                        ByVal iReplenish As Integer) As Integer
            Dim iReplenishedNewQty As Integer = 0
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim R1 As DataRow
            Dim dt1 As New DataTable()
            Dim iExists As Integer = 0


            Try
                If strBin = "" Then
                    Throw New Exception("Missing BIN CODE.")
                ElseIf strMachineName = "" Then
                    Throw New Exception("Machine Name is missing.")
                End If
                '*******************************************************
                'STEP 1:  Check if the Cycle Count is done.
                strsql = "Select Count(*) as cnt from tparttranssummary "
                strsql += "where tpts_machine = '" & strMachineName & "' and tpts_itemno = '" & strItem & "';"
                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable
                R1 = dt1.Rows(0)
                iExists = R1("cnt")
                If iExists = 0 Then
                    Throw New Exception("Cycle Count was not done on this desk. Can not replenish/recover at this point.")
                End If
                '*******************************************************
                'Step 2: Insert into tpartreplenishtonav
                strsql = ""
                strsql = "Insert into tpartreplenishtonav (" & Environment.NewLine
                strsql += "PRDN_Machine,  " & Environment.NewLine
                strsql += "PRDN_Bin, " & Environment.NewLine
                strsql += "PRDN_ItemNo, " & Environment.NewLine
                strsql += "PRDN_Qty, " & Environment.NewLine
                strsql += "PRDN_WorkDate " & Environment.NewLine
                strsql += ") values (" & Environment.NewLine

                strsql += "'" & strMachineName & "', " & Environment.NewLine
                strsql += "'" & strBin & "', " & Environment.NewLine
                strsql += "'" & strItem & "', " & Environment.NewLine
                strsql += iReplenish & ", " & Environment.NewLine
                strsql += "'" & strWorkDate & "'" & Environment.NewLine

                strsql += ");"

                _objMisc._SQL = strsql
                i = _objMisc.ExecuteNonQuery()
                '*******************************************************
                'Step 2: Update the New Quantities in tparttranssummary
                _objMisc._SQL = "Update tparttranssummary Set tpts_NewQty = tpts_NewQty + " & iReplenish & " where tpts_Machine = '" & strMachineName & "' and tpts_ItemNo = '" & strItem & "';"
                i = _objMisc.ExecuteNonQuery()
                '*******************************************************

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.ReplenishParts(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        '****************************************************************
        'Validate password for part replenishment
        'Returns a 1 if the password if good
        'Return a 0 if the password does not match
        '****************************************************************
        Public Function ValidatePassword(ByVal strPwd As String) As Integer
            Dim strsql As String = ""
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                _objMisc._SQL = "Select Count(*) as cnt from tflag where partsreplenishpwd = '" & strPwd & "'"
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    i = R1("cnt")
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.ValidatePassword(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        'Check if this desk is waiting for parts replenishment
        '****************************************************************
        Public Function DeskWaitingForReplenishment() As Integer
            Dim strsql As String = ""
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                _objMisc._SQL = "Select Count(*) as cnt from tpartreplenish where tpts_Machine = '" & strMachineName & "'"
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    i = R1("cnt")
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.DeskWaitingForReplenishment(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
        '****************************************************************
        Public Function GetMappings() As DataTable

            Dim strsql As String = ""
            Try
                strsql = "Select " & Environment.NewLine
                strsql += "lwclocation.WCLocation_ID, " & Environment.NewLine
                strsql += "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql += "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql += "llineside.LineSide_Desc as 'Line Side', " & Environment.NewLine
                strsql += "lwclocation.WC_Machine as 'Machine', " & Environment.NewLine
                strsql += "lwclocation.WC_Location as 'BIN' " & Environment.NewLine
                strsql += "from tgrouplinemap " & Environment.NewLine
                strsql += "inner join lwclocation on tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID " & Environment.NewLine
                strsql += "inner join lgroups on tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strsql += "inner join lline on tgrouplinemap.line_id = lline.Line_ID " & Environment.NewLine
                strsql += "inner join llineside on tgrouplinemap.LineSide_ID = llineside.LineSide_ID " & Environment.NewLine
                strsql += "Order by WCLocation_ID Desc" & Environment.NewLine
                strsql += ";"

                _objMisc._SQL = strsql
                Return _objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetMappings(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '****************************************************************
        Public Function GetMachines(Optional ByVal iGroupID As Integer = 0, _
                                    Optional ByVal iLineID As Integer = 0, _
                                    Optional ByVal iSideID As Integer = 0, _
                                    Optional ByVal iActivePartConsume As Integer = 0, _
                                    Optional ByVal iDataSourceForComboBox As Integer = 0, _
                                    Optional ByVal iUnmapped As Integer = 0) As DataTable

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Try
                If iGroupID > 0 Or iLineID > 0 Or iSideID > 0 Or iActivePartConsume > 0 Then

                    strsql = "Select wclocation_id, wc_machine as 'Machine', WC_Location as 'Bin', wc_activeconsume as 'Track Parts' " & Environment.NewLine
                    strsql += "from tgrouplinemap inner join lwclocation on tgrouplinemap.GrpLineMap_ID = lwclocation.GrpLineMap_ID " & Environment.NewLine
                    strsql += " where "

                    If iGroupID > 0 Then
                        strsql += " tgrouplinemap.Group_ID = " & iGroupID
                    End If

                    If iLineID > 0 Then
                        If iGroupID > 0 Then
                            strsql += " and "
                        End If
                        strsql += " tgrouplinemap.Line_ID = " & iLineID & Environment.NewLine
                    End If

                    If iSideID > 0 Then
                        If iGroupID > 0 Or iLineID > 0 Then
                            strsql += " and "
                        End If
                        strsql += " tgrouplinemap.LineSide_ID = " & iSideID & Environment.NewLine
                    End If

                    If iActivePartConsume > 0 Then
                        If iGroupID > 0 Or iLineID > 0 Or iSideID > 0 Then
                            strsql += " and "
                        End If
                        strsql += " lwclocation.WC_ActiveConsume = " & iActivePartConsume & Environment.NewLine
                    End If

                    If iUnmapped > 0 Then
                        If iGroupID > 0 Or iLineID > 0 Or iSideID > 0 Then
                            strsql += " and "
                        End If
                        strsql += " lwclocation.GrpLineMap_ID = 0 " & Environment.NewLine
                    End If

                    strsql += ";"
                Else
                    If iUnmapped = 0 Then
                        strsql = "Select wclocation_id, wc_machine as 'Machine', WC_Location as 'Bin', wc_activeconsume as 'Track Parts' from lwclocation where WC_ActiveFlag = 1;"
                    Else
                        strsql = "Select wclocation_id, wc_machine as 'Machine', WC_Location as 'Bin', wc_activeconsume as 'Track Parts' from lwclocation where WC_ActiveFlag = 1 and lwclocation.GrpLineMap_ID = 0;"
                    End If

                End If

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                If iDataSourceForComboBox > 0 Then
                    InsertEmptyRow(dt1, , "wclocation_id", "Machine", "Bin", , "-- ALL --")
                End If

                Return dt1
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetMachines(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '****************************************************************
        Public Function GetModels(Optional ByVal iProd_ID As Integer = 0, _
                                Optional ByVal iDataSourceForComboBox As Integer = 0) As DataTable
            Dim dt1 As DataTable

            Try
                If iDataSourceForComboBox = 0 Then
                    If iProd_ID > 0 Then
                        _objMisc._SQL = "Select Model_ID, Model_Desc as Model from tmodel inner join lrptgrp on tmodel.RptGrp_ID = lrptgrp.rptgrp_id where lrptgrp.Prod_ID = " & iProd_ID & " order by Model;"
                    Else
                        _objMisc._SQL = "Select Model_ID, Model_Desc as Model from tmodel inner join lrptgrp on tmodel.RptGrp_ID = lrptgrp.rptgrp_id Order by Model;"
                    End If
                    dt1 = _objMisc.GetDataTable
                Else
                    If iProd_ID > 0 Then
                        _objMisc._SQL = "Select Model_ID, Model_Desc as Model from tmodel inner join lrptgrp on tmodel.RptGrp_ID = lrptgrp.rptgrp_id where lrptgrp.Prod_ID = " & iProd_ID & " order by Model;"
                    Else
                        _objMisc._SQL = "Select Model_ID, Model_Desc as Model from tmodel inner join lrptgrp on tmodel.RptGrp_ID = lrptgrp.rptgrp_id Order by Model;"
                    End If
                    dt1 = _objMisc.GetDataTable
                    InsertEmptyRow(dt1, , "Model_ID", "Model", , , "-- SELECT --")
                End If

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetModels(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '****************************************************************
        Public Function GetLineSides(Optional ByVal iLineID As Integer = 0, _
                                    Optional ByVal iDataSourceForComboBox As Integer = 0) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                If iLineID > 0 Then
                    strsql = "Select Distinct llineside.LineSide_ID, llineside.LineSide_Desc as 'Line Side' from tgrouplinemap " & Environment.NewLine
                    strsql += "inner join llineside on tgrouplinemap.LineSide_ID = llineside.LineSide_ID " & Environment.NewLine
                    strsql += "where tgrouplinemap.Line_ID = " & iLineID & " " & Environment.NewLine
                    strsql += ";"
                Else
                    strsql = "Select llineside.LineSide_ID, llineside.LineSide_Desc as 'Line Side' from llineside order by 'Line Side';"
                End If

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                If iDataSourceForComboBox > 0 Then
                    InsertEmptyRow(dt1, , "LineSide_ID", "Line Side", , , "-- ALL --")
                End If

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetLineSides(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '****************************************************************
        Public Function GetLines(Optional ByVal iGroupID As Integer = 0, _
                                Optional ByVal iDataSourceForComboBox As Integer = 0) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable

            Try
                If iGroupID > 0 Then
                    strsql = "Select Distinct lline.Line_ID, lline.Line_Number as Line " & Environment.NewLine
                    strsql += "from tgrouplinemap " & Environment.NewLine
                    strsql += "inner join lgroups on tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine
                    strsql += "inner join lline on tgrouplinemap.Line_ID = lline.Line_ID " & Environment.NewLine
                    strsql += "where tgrouplinemap.Group_ID = " & iGroupID & Environment.NewLine
                    strsql += ";"
                Else
                    strsql = "Select lline.Line_ID, lline.Line_Number as Line from lline order by Line;"
                End If

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                If iDataSourceForComboBox > 0 Then
                    InsertEmptyRow(dt1, , "Line_ID", "Line", , , "-- Select --")
                End If

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetLines(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '****************************************************************
        Public Function GetGroups(Optional ByVal iDataSourceForComboBox As Integer = 0, _
                                 Optional ByVal iShowHideGroups As Integer = 0, _
                                 Optional ByVal iMasterGroups As Integer = 0) _
                                As DataTable
            Dim dt1 As DataTable

            Try
                If iMasterGroups = 1 Then
                    _objMisc._SQL = "Select Group_ID, Group_Desc as 'Group', Group_Manager as 'Manager',Incen_AQL_FailRate_Allowance as 'Incent AQL FailRate Allowance %' from lgroups where MasterGroup = 1 order by 'Group';"
                ElseIf iShowHideGroups = 0 Then
                    _objMisc._SQL = "Select Group_ID, Group_Desc as 'Group', Group_Manager as 'Manager' from lgroups order by 'Group';"
                Else
                    _objMisc._SQL = "Select Group_ID, Group_Desc as 'Group', Group_Manager as 'Manager' from lgroups where group_hide = 0 order by 'Group';"
                End If

                dt1 = _objMisc.GetDataTable

                If iDataSourceForComboBox > 0 Then
                    InsertEmptyRow(dt1, , "Group_ID", "Group", , , "-- SELECT --")
                End If

                Return dt1

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetGroups(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '****************************************************************
        Public Function GetExistingCostCenters() As DataTable
            Try
                _objMisc._SQL = "SELECT A.cc_id, A.cc_desc AS Name, A.group_id, B.group_desc AS 'Group Desc', C.wa_desc as 'Work Area', A.cc_uph_tier1 as 'T1 UPH', A.cc_uph_tier2 as 'T2 UPH',Trim(cc_lunchStartTime) As 'Lunch Start',Trim(cc_lunchEndTime) As 'Lunch End'" & Environment.NewLine
                _objMisc._SQL &= "FROM production.tcostcenter A" & Environment.NewLine
                _objMisc._SQL &= "INNER JOIN production.lgroups B ON B.group_id = A.group_id" & Environment.NewLine
                _objMisc._SQL &= "INNER JOIN production.lworkarea C ON A.wa_id = C.wa_id" & Environment.NewLine
                _objMisc._SQL &= "WHERE cc_inactive = 0 " & Environment.NewLine
                _objMisc._SQL &= "ORDER BY 'Group Desc', Name"

                Return _objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetExistingCostCenters(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '****************************************************************
        Public Sub SetConsumptionStartDate()
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                _objMisc._SQL = "Select * from tnav_postdt;"
                dt1 = _objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    strConsumptionStartDate = R1("PostDt")
                Else
                    Throw New Exception("Consumption Start Date is not set.")
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.SetConsumptionStartDate(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Sub

        '****************************************************************
        Public Sub SetShiftInfo(ByVal iShiftID As Integer)
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                If iShiftID = 0 Then
                    Exit Sub
                End If

                _objMisc._SQL = "Select * from tshift where shift_id =" & iShiftID & ";"
                dt1 = _objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    strShift = "SHIFT " & CStr(R1("Shift_Number"))
                Else
                    Throw New Exception("User is not assigned to any shift.")
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetShiftInfo(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '****************************************************************
        'BIJ_DateTime, BIJ_BinCode, BIJ_Machine, BIJ_UserID, BIJ_ItemNo, BIJ_ItemDesc, BIJ_NewQty, BIJ_ScrapQty, BIJ_DefectiveQty, BIJ_ConsumedQty, BIJ_Variance

        Public Function SaveBenchData(ByVal strWorkDate As String, _
                                        ByVal iShiftID As Integer, _
                                        ByVal strdate As String, _
                                        ByVal strItemNo As String, _
                                        ByVal strItemDesc As String, _
                                        ByVal iNewQty As Integer, _
                                        ByVal iScrapQty As Integer, _
                                        ByVal iDefectiveQty As Integer, _
                                        ByVal iUserID As Integer) As Integer

            Dim iConsumedQty As Integer = 0
            Dim iBinQtyForBinPart As Integer = 0
            Dim iVariance As Integer = 0
            Dim iDeskQty As Integer = 0
            Dim i As Integer = 0
            Dim strSql As String = ""
            Dim strCurDtTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim iFlg As Integer = 0
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim iExists As Integer = 0


            Try
                '*************************************************************
                'STEP 1: Get the ConsumedQty for the part from tparttransaction
                iConsumedQty = GetConsumedQuantity(strItemNo)

                'Step 2: Get Navision Bin Quantity
                iBinQtyForBinPart = GetPartQuantityInBin(strItemNo)

                'If Navision bin quantity is 0 then if the user didn't input 
                If iBinQtyForBinPart = 0 Then
                    If iNewQty = 0 And iScrapQty = 0 And iDefectiveQty = 0 Then
                        'Exit Function
                        iFlg = 1
                    End If
                End If

                'Step 3: Calculate the Total Qty On Desk
                If iConsumedQty > 0 Then
                    iDeskQty = iNewQty + iScrapQty + iDefectiveQty + iConsumedQty   'What happens if iConsumedQty is -ve.
                Else
                    iDeskQty = iNewQty + iScrapQty + iDefectiveQty      'iConsumedQty is -ve: Reclaimed parts how to handle
                End If

                'Step 4: Calculate Variance
                iVariance = iDeskQty - iBinQtyForBinPart

                'STEP 5: Insert data into tbenchinvjournal
                If iFlg = 0 Then
                    strSql = ""
                    strSql = "Insert into tbenchinvjournal " & Environment.NewLine
                    strSql += "(BIJ_WorkDate, BIJ_Shift_ID, BIJ_DateTime, BIJ_BinCode, BIJ_Machine, BIJ_UserID, BIJ_ItemNo, BIJ_ItemDesc, BIJ_NavBinQty, BIJ_NewQty, BIJ_ScrapQty, BIJ_DefectiveQty, BIJ_ConsumedQty, BIJ_Variance) " & Environment.NewLine
                    strSql += "Values ('" & strWorkDate & "', " & Environment.NewLine
                    strSql += iShiftID & ", " & Environment.NewLine
                    strSql += "'" & strdate & "', " & Environment.NewLine
                    strSql += "'" & strBin & "', " & Environment.NewLine
                    strSql += "'" & strMachineName & "', " & Environment.NewLine
                    strSql += iUserID & ", " & Environment.NewLine
                    strSql += "'" & strItemNo & "', " & Environment.NewLine
                    strSql += "'" & strItemDesc & "', " & Environment.NewLine
                    strSql += iBinQtyForBinPart & ", " & Environment.NewLine
                    strSql += iNewQty & ", " & Environment.NewLine
                    strSql += iScrapQty & ", " & Environment.NewLine
                    strSql += iDefectiveQty & ", " & Environment.NewLine
                    strSql += iConsumedQty & ", " & Environment.NewLine
                    strSql += iVariance & Environment.NewLine
                    strSql += ");"

                    _objMisc._SQL = strSql
                    i = _objMisc.ExecuteNonQuery
                End If

                '*************************************************************
                'Delete from tparttranssummary
                '_objMisc._SQL = "Delete from tparttranssummary where tpts_machine = '" & strMachineName & "' and tpts_itemno = '" & strItemNo & "';"
                'i = _objMisc.ExecuteNonQuery

                ''Check if tparttranssummary table has an entry for this part, bench
                _objMisc._SQL = "Select Count(*) as cnt from tparttranssummary where tpts_machine = '" & strMachineName & "' and tpts_itemno = '" & strItemNo & "';"
                dt1 = _objMisc.GetDataTable
                R1 = dt1.Rows(0)
                iExists = R1("cnt")

                If iExists = 0 Then
                    'Insert into tparttranssummary
                    strSql = ""
                    strSql = "Insert into tparttranssummary " & Environment.NewLine
                    strSql += "(tpts_Machine, tpts_ItemNo, tpts_NewQty, tpts_ConsumedQty, tpts_DateTime) " & Environment.NewLine
                    strSql += "Values ('" & strMachineName & "', '" & strItemNo & "', " & iNewQty & ", " & iConsumedQty & ", '" & strCurDtTime & "');"
                    _objMisc._SQL = strSql
                    i = _objMisc.ExecuteNonQuery
                Else
                    'Just update the record with New and Consumed fields
                    strSql = ""
                    strSql = "Update tparttranssummary " & Environment.NewLine
                    strSql += "set " & Environment.NewLine
                    strSql += "tpts_NewQty = " & iNewQty & ", " & Environment.NewLine
                    strSql += "tpts_ConsumedQty = " & iConsumedQty & ", " & Environment.NewLine
                    strSql += "tpts_DateTime = '" & strCurDtTime & "' " & Environment.NewLine
                    strSql += "where tpts_machine = '" & strMachineName & "' and tpts_itemno = '" & strItemNo & "';"
                    _objMisc._SQL = strSql
                    i = _objMisc.ExecuteNonQuery
                End If

                '*************************************************************

                Return i
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.SaveBenchData(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Private Function GetPartQuantityInBin(ByVal strItemNo As String) As Integer
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim iNavBinQty As Integer = 0

            Try
                If strBin = "" Then
                    Throw New Exception("Missing Bin Code. Contact Administrator.")
                End If
                _objMisc._SQL = "Select * from tnav_bincontent where Bin_Code = '" & strBin & "' and Item_No_ = '" & strItemNo & "';"
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iNavBinQty = R1("Quantity")
                End If
                Return iNavBinQty

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetPartQuantityInBin(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Private Function GetConsumedQuantity(ByVal strPartNumber As String) As Integer
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim iConsumedQty As Integer = 0
            Dim strsql As String = ""

            Try
                strsql = "Select SUM(trans_amount) as Consumed " & Environment.NewLine
                strsql += "from tdevice inner join tparttransaction on tdevice.device_id = tparttransaction.device_id " & Environment.NewLine
                strsql += "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                strsql += "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strsql += "where machinename = '" & strMachineName & "' and workdate > '" & Format(CDate(strConsumptionStartDate), "yyyy-MM-dd") & "' and lpsprice.psprice_number = '" & strPartNumber & "';"

                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If Not IsDBNull(R1("Consumed")) Then
                        iConsumedQty = R1("Consumed")
                    Else
                        iConsumedQty = 0
                    End If
                Else
                    iConsumedQty = 0
                End If

                Return iConsumedQty

            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetConsumedQuantity(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function
        '****************************************************************
        Public Function GetItemGridData() As DataTable
            Try
                _objMisc._SQL = "Select No_, Description, No_ as 'Item No', Description as 'Item Description', '' as 'New', '' as 'Scrap', '' as 'Defective', '' as 'Replenish', '' as 'Recover'  from tnav_item where shelf_no_ = 'BENCH'"
                Return _objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetItemGridData(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '****************************************************************
        Public Function GetItemGridData_Replenish(ByVal strMachine As String) As DataTable
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim iBatch As Integer = 0

            Try
                _objMisc._SQL = "Select No_, Description, No_ as 'Item No', Description as 'Item Description', '' as 'REPLENISH', '' as 'RECOVER'  from tnav_item where shelf_no_ = 'BENCH' order by Description;"
                dt1 = _objMisc.GetDataTable

                _objMisc._SQL = "Select Max(tpts_batch) as 'MaxBatchNo' from tpartreplenish;"
                dt2 = _objMisc.GetDataTable
                R2 = dt2.Rows(0)
                iBatch = R2("MaxBatchNo")

                R2 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If

                _objMisc._SQL = "Select * from tpartreplenish where tpts_machine = '" & strMachine & "' and tpts_batch = " & iBatch & ";"
                dt2 = _objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    For Each R2 In dt2.Rows
                        If UCase(Trim(R1("Item No"))) = UCase(Trim(R2("tpts_ItemNo"))) Then
                            If R2("tpts_qty") > 0 Then     'Replenish
                                R1("REPLENISH") = R2("tpts_qty")
                            ElseIf R2("tpts_qty") < 0 Then  'Recover
                                R1("RECOVER") = R2("tpts_qty")
                            End If
                        End If
                    Next R2
                    R1.AcceptChanges()
                Next R1
                dt1.AcceptChanges()

                Return dt1
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetItemGridData_Replenish(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing

                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function GetTrackedItemsFromNavision() As DataTable
            Dim strSql As String
            Dim MyCmd As OdbcCommand
            Dim MyDA As OdbcDataAdapter
            Dim dt1 As New DataTable()

            Try
                CreateNavisionConnection()

                MyDA = New OdbcDataAdapter()
                '**************************************
                'Get the Item table Info from Navision
                '**************************************
                'strSql = "Select * from Item inner join ""Bin Content"" on Item.No_ = ""Bin Content"".""Item No_"" where Item.""Shelf No_"" = 'BENCH' and ""Bin Code"" = 'SFC19B05'"
                strSql = "Select No_ from Item where Item.""Shelf No_"" = 'BENCH'"
                MyCmd = New OdbcCommand(strSql, Me._objNavConn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt1)

                Return dt1
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetTrackedItemsFromNavision(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If

                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If
            End Try
        End Function

        Public Function CheckMachineBinAssociation() As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                strsql = "Select * from lwclocation where wc_machine = '" & strMachineName & "';"
                _objMisc._SQL = strsql
                dt1 = _objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)

                    If Not IsDBNull(R1("WC_Location")) Then
                        strBin = Trim(R1("WC_Location"))
                    Else
                        strBin = ""
                    End If

                End If

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.CheckMachineBinAssociation(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        'Insert an empty row into the datatable
        '***************************************************
        Private Function InsertEmptyRow(ByRef dt As DataTable, _
                                        Optional ByVal iEmptyRowValue As Integer = 0, _
                                        Optional ByVal strFiledName1 As String = "", _
                                        Optional ByVal strFieldName2 As String = "", _
                                        Optional ByVal strFieldName3 As String = "", _
                                        Optional ByVal strFieldName4 As String = "", _
                                        Optional ByVal strEmptyRowDisplay As String = "")

            Dim R1 As DataRow

            Try
                R1 = dt.NewRow

                If strFiledName1 <> "" Then
                    R1(strFiledName1) = iEmptyRowValue
                End If
                If strFieldName2 <> "" Then
                    R1(strFieldName2) = strEmptyRowDisplay
                End If
                If strFieldName3 <> "" Then
                    R1(strFieldName3) = strEmptyRowDisplay
                End If

                dt.Rows.Add(R1)
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function

        Public Sub New()
            _objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            _objMisc = Nothing
            Me._objNavConn = Nothing
            MyBase.Finalize()
        End Sub

        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        'start Work Flow Process Project
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '****************************************************************
        Public Function DetermineIfBucketPushes(ByVal strFlowItem As String) As String
            Dim iPos As Integer = 0

            Try
                If Trim(strFlowItem) = "" Then
                    Exit Function
                Else
                    strFlowItem = Trim(strFlowItem)
                    iPos = InStr(strFlowItem, "PUSH")
                    If iPos > 0 Then
                        Return "PUSH"
                    Else
                        Return ""
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function SaveFlowSequence(ByVal iUserID As Integer, _
                                         ByVal iLineID As Integer, _
                                         ByVal iCustID As Integer, _
                                         ByVal iModelID As Integer, _
                                         ByVal lstFlowSeq As System.Windows.Forms.ListBox) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iIndex As Integer = 0
            Dim iGroup_id As Integer = 0
            Dim strDoesBucketPush As String = ""
            Dim strGroup As String = ""
            Dim iPos As Integer = 0

            Try
                '*************************
                'delete old flow squence 
                '*************************
                j = DeleteWorkFlowSeq(iLineID, iCustID, iModelID)

                '*************************
                'insert new flow seq
                '*************************
                For iIndex = 0 To lstFlowSeq.Items.Count - 1
                    '*************************
                    'reset datatable
                    If Not IsNothing(dt1) Then
                        dt1 = Nothing
                    End If
                    '*************************
                    strDoesBucketPush = DetermineIfBucketPushes(Trim(lstFlowSeq.Items.Item(iIndex)))
                    '*************************
                    If strDoesBucketPush = "PUSH" Then
                        iPos = 0
                        iPos = InStr(Trim(lstFlowSeq.Items.Item(iIndex)), "(")
                        strGroup = ""
                        strGroup = Left(Trim(lstFlowSeq.Items.Item(iIndex)), iPos - 1)
                    Else
                        strGroup = Trim(lstFlowSeq.Items.Item(iIndex))
                    End If

                    '*************************
                    'Get Group id
                    strsql = "select group_id from lgroups where group_desc = '" & strGroup & "';"
                    Me._objMisc._SQL = strsql
                    dt1 = Me._objMisc.GetDataTable

                    If dt1.Rows.Count > 0 Then
                        iGroup_id = dt1.Rows(0)("group_id")
                    Else
                        Throw New Exception(Trim(lstFlowSeq.Items.Item(iIndex)) & " does not exist in the system.")
                    End If

                    '*************************
                    'insert
                    strsql = "INSERT INTO tlineprocessflow " & Environment.NewLine
                    strsql &= "(Line_ID, Cust_ID, Model_id, LPF_Sequence, LPF_DoesBucketPush, LPF_Bucket, LPF_UserID) " & Environment.NewLine
                    strsql &= "VALUES(" & iLineID & ", " & iCustID & ", " & iModelID & ", " & iIndex + 1 & ", '" & strDoesBucketPush & "', " & iGroup_id & ", " & iUserID & ");"

                    Me._objMisc._SQL = strsql
                    i += Me._objMisc.ExecuteNonQuery
                    '*************************

                Next iIndex

                Return i
            Catch ex As Exception
                Throw New Exception("Business.Inventory.SaveFlowSequence():" & ex.Message)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function GetAllWorkFlowSeq() As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select distinct tlineprocessflow.line_id, " & Environment.NewLine
                strsql &= "tlineprocessflow.cust_id, " & Environment.NewLine
                strsql &= "tlineprocessflow.model_id, " & Environment.NewLine
                strsql &= "lline.Line_Number as Line, " & Environment.NewLine
                strsql &= "tcustomer.Cust_Name1 as Customer,  " & Environment.NewLine
                strsql &= "tmodel.Model_Desc as Model " & Environment.NewLine
                strsql &= "from tlineprocessflow  " & Environment.NewLine
                strsql &= "inner join lline on tlineprocessflow.line_id = lline.line_id " & Environment.NewLine
                strsql &= "inner join tcustomer on tlineprocessflow.cust_id = tcustomer.cust_id " & Environment.NewLine
                strsql &= "inner join tmodel on tlineprocessflow.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "order by tlineprocessflow.line_id, tlineprocessflow.cust_id, tlineprocessflow.model_id;"
                Me._objMisc._SQL = strsql
                Return Me._objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetAllWorkFlowSeq():" & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function GetWorkFlowSeq_GroupDesc(ByVal iLineID As Integer, _
                                       ByVal iCustID As Integer, _
                                       ByVal iModelID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select lgroups.Group_Desc, tlineprocessflow.LPF_DoesBucketPush " & Environment.NewLine
                strsql &= "from tlineprocessflow " & Environment.NewLine
                strsql &= "inner join lgroups on tlineprocessflow.LPF_Bucket = lgroups.group_id " & Environment.NewLine
                strsql &= "where tlineprocessflow.Line_ID = " & iLineID & " and " & Environment.NewLine
                strsql &= "tlineprocessflow.Cust_ID = " & iCustID & " and " & Environment.NewLine
                strsql &= "tlineprocessflow.Model_ID = " & iModelID & " " & Environment.NewLine
                strsql &= "order by tlineprocessflow.LPF_Sequence;"
                Me._objMisc._SQL = strsql
                Return Me._objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetWorkFlowSeq_GroupDesc():" & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function DeleteWorkFlowSeq(ByVal iLineID As Integer, _
                                          ByVal iCustID As Integer, _
                                          ByVal iModelID As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                'Get all LFP entries
                strsql = "select LPF_ID from tlineprocessflow " & Environment.NewLine
                strsql &= "WHERE line_id = " & iLineID & " and cust_id = " & iCustID & " and model_id = " & iModelID & ";"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                'Delete all entries in tconditionalpush table
                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        strsql = "delete from tconditionalpush where LPF_ID = " & R1("LPF_ID") & ";"
                        Me._objMisc._SQL = strsql
                        i = Me._objMisc.ExecuteNonQuery
                    Next R1
                End If

                'delete all entries in tlineprocessflow
                strsql = "DELETE FROM tlineprocessflow " & Environment.NewLine
                strsql &= "WHERE line_id = " & iLineID & " and cust_id = " & iCustID & " and model_id = " & iModelID & ";"
                Me._objMisc._SQL = strsql
                Return Me._objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Business.Inventory.DeleteWorkFlowSeq():" & ex.Message)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
            End Try
        End Function

        '****************************************************************
        Public Function GetLPF_ID(ByVal iLineID As Integer, _
                                  ByVal iCustID As Integer, _
                                  ByVal iModelID As Integer, _
                                  ByVal strGroup_desc As String) As Integer

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim iLPF_Bucket As Integer = 0


            Try
                'Get GroupID
                strsql = "select group_id from lgroups where group_desc = '" & strGroup_desc & "';"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iLPF_Bucket = dt1.Rows(0)("group_id")
                End If

                dt1 = Nothing

                'Get LFP id
                strsql = "select LPF_ID FROM tlineprocessflow " & Environment.NewLine
                strsql &= "WHERE line_id = " & iLineID & " and cust_id = " & iCustID & " and model_id = " & iModelID & " and LPF_Bucket = " & iLPF_Bucket & ";"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    Return dt1.Rows(0)("LPF_ID")
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetLPF_ID():" & ex.Message)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function SaveConditonalPushBucket(ByVal iLPF_id As Integer, _
                                                 ByVal iCP_Bucket As Integer) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0

            Try
                'delete old conditional push
                'strsql = "delete from tconditionalpush where CP_Bucket = " & iCP_Bucket & " and LPF_ID = " & iLPF_id & ";"
                strsql = "delete from tconditionalpush where LPF_ID = " & iLPF_id & ";"
                Me._objMisc._SQL = strsql
                i = Me._objMisc.ExecuteNonQuery

                i = 0

                'insert new conditional push
                strsql = "insert into tconditionalpush (CP_Bucket, LPF_ID) values (" & iCP_Bucket & ", " & iLPF_id & ");"
                Me._objMisc._SQL = strsql
                i = Me._objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw New Exception("Business.Inventory.SaveConditonalPushBucket(): " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function DeleteConditionalPush(ByVal iLPF_id As Integer) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0

            Try
                'delete conditional push
                strsql = "delete from tconditionalpush where LPF_ID = " & iLPF_id & ";"
                Me._objMisc._SQL = strsql
                i = Me._objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw New Exception("Business.Inventory.DeleteConditionalPush():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function GetCP_BucketDesc(ByVal LPF_id As Integer) As String
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim strGroupDesc As String = ""

            Try

                strsql = "select lgroups.group_desc from tconditionalpush " & Environment.NewLine
                strsql &= "inner join lgroups on tconditionalpush.CP_Bucket = lgroups.group_id " & Environment.NewLine
                strsql &= "WHERE tconditionalpush.LPF_ID = " & LPF_id & ";"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    strGroupDesc = dt1.Rows(0)("group_desc")
                End If

                Return strGroupDesc
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetCP_BucketDesc():" & ex.Message)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function GetCP_BucketID(ByVal LPF_id As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim iGroup_id As Integer = 0

            Try

                strsql = "select lgroups.group_id from tconditionalpush " & Environment.NewLine
                strsql &= "inner join lgroups on tconditionalpush.CP_Bucket = lgroups.group_id " & Environment.NewLine
                strsql &= "WHERE tconditionalpush.LPF_ID = " & LPF_id & ";"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iGroup_id = dt1.Rows(0)("group_id")
                End If

                Return iGroup_id
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetCP_BucketID():" & ex.Message)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '''****************************************************************
        ''Public Function GetQCFailureGroups(ByVal iLineID As Integer, _
        ''                                   ByVal iCustID As Integer, _
        ''                                   ByVal iModelID As Integer, _
        ''                                   ByVal iCurBucket As Integer) As DataTable
        ''    Dim strsql As String = ""
        ''    Dim dt1, dt2 As DataTable

        ''    Try
        ''        strsql = "select * from tlineprocessflow " & Environment.NewLine
        ''        strsql &= "where tlineprocessflow.line_id = " & iLineID & " and  " & Environment.NewLine
        ''        strsql &= "tlineprocessflow.cust_id = " & iCustID & " and  " & Environment.NewLine
        ''        strsql &= "tlineprocessflow.model_id = " & iModelID & " and  " & Environment.NewLine
        ''        strsql &= "tlineprocessflow.LPF_Bucket = " & iCurBucket & Environment.NewLine
        ''        Me._objMisc._SQL = strsql
        ''        dt1 = Me._objMisc.GetDataTable

        ''        If dt1.Rows.Count > 0 Then
        ''            strsql = "select lgroups.group_id, lgroups.group_desc from tlineprocessflow  " & Environment.NewLine
        ''            strsql &= "inner join lgroups on  tlineprocessflow.LPF_Bucket = lgroups.group_id " & Environment.NewLine
        ''            strsql &= "where tlineprocessflow.line_id = " & iLineID & " and  " & Environment.NewLine
        ''            strsql &= "tlineprocessflow.cust_id = " & iCustID & " and  " & Environment.NewLine
        ''            strsql &= "tlineprocessflow.model_id = " & iModelID & " and  " & Environment.NewLine
        ''            strsql &= "tlineprocessflow.LPF_Sequence < " & dt1.Rows(0)("LPF_Sequence") & Environment.NewLine
        ''            strsql &= "order by tlineprocessflow.LPF_Sequence asc" & ";"
        ''            Me._objMisc._SQL = strsql
        ''            dt2 = Me._objMisc.GetDataTable
        ''        End If

        ''        Return dt2
        ''    Catch ex As Exception
        ''        Throw New Exception("Business.Inventory.GetQCFailureGroups():" & ex.Message)
        ''    Finally
        ''        If Not IsNothing(dt1) Then
        ''            dt1.Dispose()
        ''            dt1 = Nothing
        ''        End If
        ''        If Not IsNothing(dt2) Then
        ''            dt2.Dispose()
        ''            dt2 = Nothing
        ''        End If
        ''    End Try
        ''End Function

        '****************************************************************
        Public Function GetGroupDesc(ByVal iGroupID As Integer) As String
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim strGroupDesc As String = ""

            Try

                strsql = "select lgroups.group_desc from lgroups " & Environment.NewLine
                strsql &= "WHERE lgroups.group_id = " & iGroupID & ";"
                Me._objMisc._SQL = strsql
                dt1 = Me._objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    strGroupDesc = dt1.Rows(0)("group_desc")
                End If

                Return strGroupDesc
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetGroupDesc():: " & ex.Message)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Shared Function GetBinLocByMachineName(ByVal strMachine As String) As String
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT TRIM(WC_Location) " & Environment.NewLine
                strSql &= "FROM lwclocation " & Environment.NewLine
                strSql &= "WHERE WC_ActiveFlag = 1 AND wc_machine = '" & strMachine & "';"
                Return objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetBinLoc():: " & ex.Message)
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '****************************************************************
        Public Function GetCostCenterGroups(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT Group_ID, Group_Desc AS 'Group Desc'" & Environment.NewLine
                strSQL &= "FROM production.lgroups" & Environment.NewLine
                strSQL &= "WHERE mastergroup = 1" & Environment.NewLine
                strSQL &= "ORDER BY 'Group Desc'"
                dt = _objMisc.GetDataTable(strSQL)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetGroups(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function CheckCostCenter(ByVal iGroupID As Integer, ByVal strCCName As String) As Boolean
            Dim bCheckCostCenter As Boolean = False
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tcostcenter" & Environment.NewLine
                strSQL &= "WHERE group_id = " & iGroupID.ToString & Environment.NewLine
                strSQL &= "AND UPPER(cc_desc) = '" & strCCName & "'"

                dt = Me._objMisc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then bCheckCostCenter = IIf(dt.Rows(0)(0) = 0, False, True)
                End If

                Return bCheckCostCenter
            Catch ex As Exception
                Throw New Exception("Business.Inventory.CheckCostCenter():: " & ex.Message)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function AddCostCenter(ByVal iGroupID As Integer, _
                                      ByVal strCCName As String, _
                                      ByVal iWorkArea As Integer, _
                                      ByVal iHour As Integer, _
                                    ByVal iMinute As Integer, _
                                      Optional ByVal iSerialize As Integer = 0) As Boolean
            Dim strSQL As String
            Dim iRet As Integer

            Try
                strSQL = "INSERT INTO production.tcostcenter (cc_desc, group_id, cc_lunchStartTime, cc_lunchEndTime, cc_specproj, wa_id)" & Environment.NewLine
                strSQL &= "VALUES ('" & strCCName & "', " & iGroupID.ToString & ", Date_Format('2009-11-24 " & iHour & ":" & iMinute & ":00', '%H:%i:%s'), " & Environment.NewLine
                strSQL &= "Date_Format(Date_ADD('2009-11-24 " & iHour & ":" & iMinute & ":00', INTERVAL '0 0:30' DAY_MINUTE),'%H:%i:%s'), " & iSerialize & ", " & iWorkArea & ")"

                iRet = Me._objMisc.ExecuteNonQuery(strSQL)

                Return IIf(iRet = 0, False, True)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.AddCostCenter():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Sub DeleteCostCenter(ByVal iCCID As Integer)
            Dim strSQL As String
            Dim strTableNames() = {"tcostcentermapping", "tcostcenter"}, strTable

            Try
                For Each strTable In strTableNames
                    strSQL = "DELETE FROM production." & strTable & Environment.NewLine
                    strSQL &= "WHERE cc_id = " & iCCID.ToString

                    Me._objMisc.ExecuteNonQuery(strSQL)
                Next strTable
            Catch ex As Exception
                Throw New Exception("Business.Inventory.DeleteCostCenter():: " & ex.Message)
            End Try
        End Sub

        '****************************************************************
        Public Function GetActiveMachines() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT lwclocation.WCLocation_ID AS 'Location ID', WC_Machine AS 'Name'" & Environment.NewLine
                strSQL &= "FROM production.lwclocation" & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN production.tcostcentermapping on lwclocation.WCLocation_ID = tcostcentermapping.WCLocation_ID " & Environment.NewLine
                strSQL &= "WHERE WC_ActiveFlag = 1" & Environment.NewLine
                strSQL &= "AND LENGTH(TRIM(WC_Machine)) > 0 and  tcostcentermapping.WCLocation_ID is null " & Environment.NewLine
                strSQL &= "ORDER BY WC_Machine"

                Return Me._objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetActiveMachines():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function CheckCostCenterMachineMapping(ByVal iCCID As Integer, ByVal iWCLocID As Integer) As Boolean
            Dim strSQL As String
            Dim iCount As Integer = 0

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tcostcentermapping" & Environment.NewLine
                strSQL &= "WHERE cc_id = " & iCCID.ToString & Environment.NewLine
                strSQL &= "AND WCLocation_ID = " & iWCLocID.ToString

                iCount = Me._objMisc.GetIntValue(strSQL)

                Return IIf(iCount = 0, False, True)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.CheckCostCenterMachineMapping():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function AddMachineMapping(ByVal iCCID As Integer, ByVal iDesk As Integer, ByVal iWCLocID As Integer) As Boolean
            Dim strSQL As String
            Dim iRet As Integer

            Try
                strSQL = "INSERT INTO production.tcostcentermapping (cc_id, desk, WCLocation_ID)" & Environment.NewLine
                strSQL &= "VALUES (" & iCCID.ToString & ", " & iDesk.ToString & ", " & iWCLocID.ToString & ")"

                iRet = Me._objMisc.ExecuteNonQuery(strSQL)

                Return IIf(iRet = 0, False, True)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.AddMachineMapping():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function GetMappedMachines() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT A.ccmap_id, D.Group_Desc AS 'Group', B.cc_desc AS 'Cost Center', A.Desk, C.WC_Machine AS 'Machine Name'" & Environment.NewLine
                strSQL &= "FROM production.tcostcentermapping A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tcostcenter B ON B.cc_id = A.cc_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.lwclocation C ON C.WCLocation_ID = A.WCLocation_ID" & Environment.NewLine
                strSQL &= "INNER JOIN production.lgroups D ON B.Group_ID = D.Group_ID " & Environment.NewLine
                strSQL &= "ORDER BY B.cc_desc, C.WC_Machine"

                Return Me._objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.GetActiveMachines():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Sub DeleteCostCenterMapping(ByVal iCCMapID As Integer)
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM production.tcostcentermapping" & Environment.NewLine
                strSQL &= "WHERE ccmap_id = " & iCCMapID.ToString

                Me._objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.DeleteCostCenterMapping():: " & ex.Message)
            End Try
        End Sub

        '****************************************************************
        Public Sub UpdateUPHGoal(ByVal iCCID As Integer, ByVal dblUPHGoal As Double)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tcostcenter" & Environment.NewLine
                strSQL &= "SET uph_goal = " & dblUPHGoal.ToString & Environment.NewLine
                strSQL &= "WHERE cc_id = " & iCCID.ToString

                Me._objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.UpdateUPHGoal():: " & ex.Message)
            End Try
        End Sub

        '****************************************************************
        Public Sub UpdateCostCenterName(ByVal iCCID As Integer, ByVal strCCName As String)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tcostcenter" & Environment.NewLine
                strSQL &= "SET cc_desc = '" & strCCName & "'" & Environment.NewLine
                strSQL &= "WHERE cc_id = " & iCCID.ToString

                Me._objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Business.Inventory.UpdateCostCenterName():: " & ex.Message)
            End Try
        End Sub

        '****************************************************************
        Public Function UpdateCostCenterUPH(ByVal iCCID As Integer, _
                                            ByVal decOldT1UHP As Decimal, _
                                            ByVal decOldT2UPH As Decimal, _
                                            ByVal decNewT1UHP As Decimal, _
                                            ByVal decNewT2UPH As Decimal, _
                                            ByVal iUserID As Integer, _
                                            ByVal strUserName As String) As Integer
            Dim strSQL As String
            Dim i As Integer

            Try
                strSQL = "UPDATE production.tcostcenter" & Environment.NewLine
                strSQL &= "SET cc_uph_tier1 = " & decNewT1UHP.ToString & Environment.NewLine
                strSQL &= ", cc_uph_tier2 = " & decNewT2UPH.ToString & Environment.NewLine
                strSQL &= "WHERE cc_id = " & iCCID.ToString
                i = Me._objMisc.ExecuteNonQuery(strSQL)

                strSQL = "INSERT INTO tccupdatehistory (" & Environment.NewLine
                strSQL &= " cc_id " & Environment.NewLine
                strSQL &= ", currentT1UPH " & Environment.NewLine
                strSQL &= ", currentT2UHP " & Environment.NewLine
                strSQL &= ", newT1UPH " & Environment.NewLine
                strSQL &= ", newT2UHP " & Environment.NewLine
                strSQL &= ", UPHUpdateDT " & Environment.NewLine
                strSQL &= ", UPHUpdateUsrID " & Environment.NewLine
                strSQL &= ", UPHUpdateUser " & Environment.NewLine
                strSQL &= ") VALUES ( " & Environment.NewLine
                strSQL &= " " & iCCID & Environment.NewLine
                strSQL &= ", " & decOldT1UHP & Environment.NewLine
                strSQL &= ", " & decOldT2UPH & Environment.NewLine
                strSQL &= ", " & decNewT1UHP & Environment.NewLine
                strSQL &= ", " & decNewT2UPH & Environment.NewLine
                strSQL &= ", now() " & Environment.NewLine
                strSQL &= ", " & iUserID & Environment.NewLine
                strSQL &= ", '" & strUserName & "' " & Environment.NewLine
                strSQL &= " ) " & Environment.NewLine
                i += Me._objMisc.ExecuteNonQuery(strSQL)
                Return i
            Catch ex As Exception
                Throw New Exception("Business.Inventory.UpdateUPHGoal():: " & ex.Message)
            End Try
        End Function

        '****************************************************************
        Public Function GetNavBinContent(ByVal strBinList As String) As DataTable
            Dim strSql As String = ""
            Dim MyCmd As New OdbcCommand()
            Dim MyDA As New OdbcDataAdapter()
            Dim dt As New DataTable()

            Try
                CreateNavisionConnection()

                '**************************************
                'Get BinContent Info from Navision
                '**************************************
                strSql = "Select ""Bin Code"" as BinCode, ""Item No_"" as ItemNo, Quantity " & Environment.NewLine
                strSql &= "FROM ""Bin Content""" & Environment.NewLine
                strSql &= "WHERE ""Bin Code"" IN (" & strBinList & ")" & Environment.NewLine
                strSql &= "ORDER BY ""Bin Code"", ""Item No_"""

                MyCmd = New OdbcCommand(strSql, Me._objNavConn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt)

                Return dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetNavBinContent(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If

                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

#Region " VENDOR PERFORMANCE REPORT "

        Public Function GetVendorPerformanceDS(ByVal startDt As Date, ByVal endDt As Date) As DataSet
            Dim _ds As New DataSet()
            Dim _dt0 As New DataTable()
            Dim _dt1 As New DataTable()
            Dim _dt2 As New DataTable()
            Dim _dt3 As New DataTable()
            Dim _rptNr As Integer = CType(Now.Minute.ToString & Now.Second.ToString(), Integer)
            ' GET NAVISION DATA.
            _dt0 = GetVendorPerformanceNavData(startDt, endDt)
            ' INSERT DATA INTO MYSQL TABLE.
            PopulateVendorPerfTable(_rptNr, _dt0)
            ' GET FORECAST DATA.
            _dt1 = GetVendorPerformanceForecast(_rptNr)
            ' GET SPOTBUY DATA.
            _dt2 = GetVendorPerformanceSpotBuy(_rptNr)
            ' GET DETAIL DATA.
            _dt3 = GetVendorPerformanceDetails(_rptNr)
            ' CLEAN MYSQL TABLE.
            'DeleteVendorPerfTableData(_rptNr)
            ' BUILD THE DATASET AND RETURN IT TO THE CALLING PROCEDURE.
            _ds.Tables.Add(_dt1)
            _ds.Tables.Add(_dt2)
            _ds.Tables.Add(_dt3)
            Return _ds
        End Function

        Public Function GetVendorPerformanceNavData(ByVal startDt As Date, ByVal endDt As Date) As DataTable
            Dim _sb As StringBuilder = New StringBuilder()
            Dim MyCmd As New OdbcCommand()
            Dim MyDA As New OdbcDataAdapter()
            Dim dt As New DataTable()
            Try
                CreateNavisionConnection()
                ' GET THE DATA.
                _sb.Append("SELECT ")
                _sb.Append(" ""HD"".""No_"", ")
                _sb.Append(" ""HD"".""Buy-from Vendor No_"", ")
                _sb.Append(" ""HD"".""Name"", ")
                _sb.Append(" ""HD"".""Order Date"", ")
                _sb.Append(" ""HD"".""Posting Date"", ")
                _sb.Append(" 0 AS ""Delivery Days"", ")
                _sb.Append(" ""HD"".""Order No_"", ")
                _sb.Append(" ""LN"".""No_"", ")
                _sb.Append(" ""LN"".""Quantity"", ")
                _sb.Append(" ""ITM"".""Description"", ")
                _sb.Append(" ' ' AS ""Perf_Group"", ")
                _sb.Append(" ""LN"".""Posting Group"", ")
                _sb.Append(" ' ' AS ""Type_"" ")
                _sb.Append(" FROM ""Purch_ Rcpt_ Header"" AS ""HD"" ")
                _sb.Append(" INNER JOIN ""Purch_ Rcpt_ Line"" AS ""LN"" ON ""HD"".""No_"" = ""LN"".""Document No_"" ")
                _sb.Append(" INNER JOIN ""Item"" AS ""ITM"" ON ""LN"".""No_"" = ""ITM"".""No_"" ")
                _sb.Append(String.Format("WHERE ""HD"".""Posting Date"" Between '{0: yyyy-MM-dd}'", startDt) & " ")
                _sb.Append(String.Format(" AND '{0: yyyy-MM-dd}'", endDt) & " AND ")
                _sb.Append(" ""HD"".""Order Date"" > '1900-01-01' AND ")
                _sb.Append(" ""LN"".""Quantity"" <> 0 AND ")
                _sb.Append(" ""LN"".""Buy-from Vendor No_"" NOT LIKE 'V0012%' AND ")
                _sb.Append(" ""LN"".""Posting Group"" = 'CELL PARTS' ")
                MyCmd = New OdbcCommand(_sb.ToString(), Me._objNavConn)
                MyDA.SelectCommand = MyCmd
                MyDA.Fill(dt)
                Dim _dr As DataRow
                For Each _dr In dt.Rows()
                    _dr("Type_") = Mid(_dr("Order No_"), 9, 1)
                    If (Not _dr("Order Date") Is System.DBNull.Value) And (Not _dr("Posting Date") Is System.DBNull.Value) Then
                        Dim _i As Integer
                        _i = DateDiff(DateInterval.Day, _dr("Order Date"), _dr("Posting Date"))
						_dr("delivery days") = _i
                        Select Case _i
							Case 0 To 30 : _dr("Perf_Group") = "0-30 Days"
							Case 31 To 45 : _dr("Perf_Group") = "31-45 Days"
							Case 46 To 60 : _dr("Perf_Group") = "46-60 Days"
							Case 61 To 90 : _dr("Perf_Group") = "61-90 Days"
							Case Else : _dr("Perf_Group") = " > 90 Days"
						End Select
                    End If
                    If _dr("Name").ToString() = "LG Electronics Alabama Inc." Then
                        _dr("Name") = "LG Electronics Alabama WIRE"
					End If
					_dr.AcceptChanges()
				Next
                dt.AcceptChanges()
                Return dt
            Catch ex As Exception
                Debug.Write(ex.Message)
                Throw New Exception("Buisness.Inventory.GetVendorPerformanceNavData(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(MyCmd) Then
                    MyCmd.Dispose()
                    MyCmd = Nothing
                End If
                If Not IsNothing(MyDA) Then
                    MyDA.Dispose()
                    MyDA = Nothing
                End If
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        Private Sub PopulateVendorPerfTable(ByVal rptNr As Integer, ByVal dt As DataTable)
            Dim objDataProc As DBQuery.DataProc
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Dim strsql As String
            Dim dr As DataRow
            For Each dr In dt.Rows()
                strsql = "Insert into reports.tf_vendor_performance "
                strsql += "("
                strsql += "vp_rpt_nr, "
                strsql += "no, "
                strsql += "vendor_no, "
                strsql += "vendor_na, "
                strsql += "order_dt, "
				strsql += "posting_dt, "
				strsql += "delivery_days, "
				strsql += "order_no, "
				strsql += "pur_rcpt_line_no, "
                strsql += "quantity,"
                strsql += "description,"
                strsql += "perf_group,"
                strsql += "rec_type,"
                strsql += "posting_group "
                strsql += ") Values ("
                strsql += rptNr.ToString() & ", "
                strsql += "'" & dr("No_").ToString().Trim() & "', "
                strsql += "'" & dr("Buy-from Vendor No_").ToString().Trim() & "', "
                strsql += "'" & dr("Name").ToString().Trim() & "', "
				strsql += "'"
				strsql += String.Format("{0: yyyy-MM-dd}", dr("Order Date"))
                strsql += "', "
                strsql += "'"
                strsql += String.Format("{0: yyyy-MM-dd}", dr("Posting Date"))
				strsql += "', "
				strsql += "" & dr("delivery days").ToString().Trim() & ", "
				strsql += "'" & dr("Order No_").ToString().Trim() & "', "
				strsql += "'" & dr("No_1").ToString().Trim() & "', "
				strsql += dr("Quantity").ToString() & ", "
                strsql += "'" & dr("Description").ToString().Trim() & "', "
                strsql += "'" & dr("Perf_Group").ToString().Trim() & "', "
                strsql += "'" & dr("Type_").ToString().Trim() & "', "
                strsql += "'" & dr("Posting Group").ToString().Trim() & "' "
                strsql += ");"
                objDataProc.ExecuteNonQuery(strsql)
            Next
        End Sub

        Public Function GetVendorPerformanceForecast(ByVal rptNr As Integer) As DataTable
            Dim _sb As StringBuilder = New StringBuilder()
            Dim _dt As DataTable
            Dim _dt2 As DataTable
            Dim _dr As DataRow
            Dim _dr2 As DataRow
            Dim _vdr As String = ""
            Dim _sum As Int32 = 0
            Dim _ratio As Double = 0
            Try
                _sb.Append("SELECT ")
                _sb.Append("vendor_no AS 'Vender No.', ")
                _sb.Append("vendor_na AS 'Vendor', ")
                _sb.Append("perf_group AS 'Performance Group', ")
                _sb.Append("0 AS 'Vendor Total', ")
                _sb.Append("SUM(quantity) AS 'Perf. Group Total', ")
                _sb.Append("'' AS 'Ratio' ")
                _sb.Append("FROM reports.tf_vendor_performance ")
                _sb.Append("WHERE rec_type IN ('F','B') ")
                _sb.Append("AND vendor_no <> 'V0012' ")
                _sb.Append("AND vp_rpt_nr = " & rptNr.ToString() & " ")
                _sb.Append("GROUP BY vendor_no, vendor_na, perf_group; ")
                _dt = _objMisc.GetDataTable(_sb.ToString())
                _dt2 = _dt.Copy()
                For Each _dr In _dt.Rows()
                    _vdr = _dr("Vender No.")
                    _sum = 0
                    _ratio = 0
                    For Each _dr2 In _dt2.Rows()
                        If _dr2("Vender No.") = _vdr Then
                            _sum += _dr2("Perf. Group Total")
                        End If
                    Next
                    _dr("Vendor Total") = _sum
                    _ratio = _dr("Perf. Group Total") / _sum * 100
                    _dr("Ratio") = _ratio.ToString() & "%"
                Next
                _dt2.Dispose()
                _dt.AcceptChanges()
                _dt.TableName = "Forecast"
                Return _dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetVendorPerformanceForecast(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(_dt) Then
                    _dt.Dispose()
                    _dt = Nothing
                End If
            End Try
        End Function

        Public Function GetVendorPerformanceSpotBuy(ByVal rptNr As Integer) As DataTable
            Dim _sb As StringBuilder = New StringBuilder()
            Dim _dt As DataTable
            Dim _dt2 As DataTable
            Dim _dr As DataRow
            Dim _dr2 As DataRow
            Dim _vdr As String = ""
            Dim _sum As Int32 = 0
            Dim _ratio As Double = 0
            Try
                _sb.Append("SELECT ")
                _sb.Append("vendor_no AS 'Vender No.', ")
                _sb.Append("vendor_na AS 'Vendor', ")
                _sb.Append("perf_group AS 'Performance Group', ")
                _sb.Append("0 AS 'Vendor Total', ")
                _sb.Append("SUM(quantity) AS 'Perf. Group Total', ")
                _sb.Append("'' AS 'Ratio' ")
                _sb.Append("FROM reports.tf_vendor_performance ")
				_sb.Append("WHERE rec_type NOT IN ('F','B') ")
                _sb.Append("AND vendor_no <> 'V0012' ")
                _sb.Append("AND vp_rpt_nr = " & rptNr.ToString() & " ")
                _sb.Append("GROUP BY vendor_no, vendor_na, perf_group; ")
                _dt = _objMisc.GetDataTable(_sb.ToString())
                _dt2 = _dt.Copy()
                For Each _dr In _dt.Rows()
                    _vdr = _dr("Vender No.")
                    _sum = 0
                    _ratio = 0
                    For Each _dr2 In _dt2.Rows()
                        If _dr2("Vender No.") = _vdr Then
                            _sum += _dr2("Perf. Group Total")
                        End If
                    Next
                    _dr("Vendor Total") = _sum
                    _ratio = _dr("Perf. Group Total") / _sum * 100
                    _dr("Ratio") = _ratio.ToString() & "%"
                Next
                _dt2.Dispose()
                _dt.AcceptChanges()
                _dt.TableName = "Spot By"
                Return _dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetVendorPerformanceSpotBuy(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(_dt) Then
                    _dt.Dispose()
                    _dt = Nothing
                End If
            End Try
        End Function

        Public Function GetVendorPerformanceDetails(ByVal rptNr As Integer) As DataTable
            Dim _sb As StringBuilder = New StringBuilder()
            Dim _dt As DataTable
            Try
                _sb.Append("SELECT ")
                _sb.Append("no AS 'Vendor Performance No.' ,")
                _sb.Append("vendor_no AS 'Buy From Vendor No.' ,")
                _sb.Append("vendor_na AS 'Vendor' ,")
                _sb.Append("order_dt AS 'Order Dt.' , ")
                _sb.Append("posting_dt AS 'Posting Dt.' , ")
                _sb.Append("order_no AS 'Order No.' , ")
                _sb.Append("delivery_days AS 'Delivery Performance' , ")
                _sb.Append("pur_rcpt_line_no AS 'Purchase Rcpt Line No.' , ")
                _sb.Append("description AS 'Description' , ")
                _sb.Append("quantity AS 'Quantity' , ")
                _sb.Append("rec_type AS 'Record Type' , ")
                _sb.Append("perf_group AS 'Performance Group' ")
                _sb.Append("FROM reports.tf_vendor_performance ")
                _sb.Append("WHERE vendor_no <> 'V0012' ")
                _sb.Append("AND vp_rpt_nr = " & rptNr.ToString() & "; ")
                _dt = _objMisc.GetDataTable(_sb.ToString())
                _dt.TableName = "Details"
                Return _dt
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.GetVendorPerformanceDetails(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(_dt) Then
                    _dt.Dispose()
                    _dt = Nothing
                End If
            End Try
        End Function

        Private Sub DeleteVendorPerfTableData(ByVal rptNr As Integer)
            ' DELETE THE REPORT DATA FOR THE PASSED IN REPORT NUMBER.
            Dim _sb As StringBuilder = New StringBuilder()

            Dim objDataProc As DBQuery.DataProc
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Try
                _sb.Append("DELETE FROM REPORTS.tf_vendor_performance WHERE VP_RPT_NR = " & rptNr.ToString())
                objDataProc.ExecuteNonQuery(_sb.ToString())
            Catch ex As Exception
                Throw New Exception("Buisness.Inventory.DeleteVendorPerfTableData(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Sub

#End Region

    End Class
End Namespace
