Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports System.IO
Imports system.Windows.Forms

Namespace Buisness
    Public Class MessReports

        Private _objDataProc As DBQuery.DataProc
        Private _strRptPath As String = "R:\PSSInet_Reports_Prod\"

        Structure FontAttributes
            Public strFontName, strFontStyle As String
            Public iFontSize, iFontColorIndex As Integer

            Public Sub New(ByVal strName As String, ByVal strStyle As String, ByVal iSize As Integer, Optional ByVal iColorIndex As Integer = 1)
                Me.strFontName = strName
                Me.strFontStyle = strStyle
                Me.iFontSize = iSize
                Me.iFontColorIndex = iColorIndex
            End Sub
        End Structure

        '***************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
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
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '***************************************************

        ''*******************************************************************
        'Public Function CreateAmericanMessPackingSlip(ByVal lstItems As Windows.Forms.ListBox, _
        '                                                     ByVal iItemType As Integer, _
        '                                                     ByVal strRptName As String) As Integer

        '    '**************************************************************
        '    '//(0 to 99 is 100 items; 0 to 2 is 3 items. 
        '    '//This depends on how many parameters and 
        '    '//max number of multiple values for each parameter
        '    Dim Matrix(99, 2) As String
        '    '**************************************************************
        '    Dim i As Integer = 0
        '    Dim strRptFilePath As String = ""

        '    Try
        '        '***********************************************************
        '        '//Construct the File path
        '        '***********************************************************
        '        strRptFilePath = Me._strRptPath & strRptName

        '        If Not strRptFilePath.ToUpper.EndsWith(".RPT") Then strRptFilePath &= ".rpt"
        '        '***********************************************************
        '        '//Add Parameter "Ship ID"
        '        '//(Multiple values allowed for this parameter)
        '        '//There could be up to a max of 100 Ship IDs for this report.
        '        '***********************************************************
        '        For i = 0 To lstItems.Items.Count - 1
        '            Matrix(i, 0) = "Ship ID"
        '            Matrix(i, 1) = lstItems.Items.Item(i)
        '            Matrix(i, 2) = "Int"
        '        Next i
        '        '***********************************************************
        '        '//Helpful tip
        '        '//Example Parameter
        '        '//If there is another parameter with a single discrete value for 
        '        '//this report you could add it as shown below. One by one.

        '        '//i += 1
        '        '//Matrix(i, 0) = "Pallet ID"
        '        '//Matrix(i, 1) = "123456"

        '        '//i += 1
        '        '//Matrix(i, 0) = "Group ID"
        '        '//Matrix(i, 1) = "1"

        '        '    "
        '        '    "
        '        '    "
        '        '    "
        '        '   So on and so forth
        '        '***********************************************************
        '        PrintCrystalReport(strRptFilePath, , Matrix, , False, 1)

        '        Return 1
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        ReDim Matrix(-1, -1)
        '        Matrix = Nothing
        '    End Try
        'End Function

        ''*******************************************************************
        'Public Sub PrintCrystalReport(ByVal strRptPath As String, _
        '                            Optional ByVal strFormula As String = "", _
        '                            Optional ByVal Matrix(,) As String = Nothing, _
        '                            Optional ByVal strPrinterName As String = "", _
        '                            Optional ByVal iOrientationLandscape As Boolean = False, _
        '                            Optional ByVal iNumCopies As Integer = 1)

        '    '//*******************************************************
        '    '// AUTHOR: Asif Mohammad
        '    '// Date  : 04/30/2007
        '    '// This sub routine takes report parameters in a two dimensional 
        '    '// along with other properties and prints out a Crystal Report.
        '    '//*******************************************************
        '    'Dim ps As New PrinterSettings()
        '    'Dim rptApp As New CRAXDRT.Application()
        '    'Dim rpt As CRAXDRT.Report
        '    Dim i As Integer = 0
        '    Dim j As Integer = 0
        '    Dim strParamName As String = ""
        '    Dim strParamVal As String = ""
        '    Dim strParamType As String = ""
        '    Dim objRpt As ReportDocument

        '    Try
        '        '*****************************************************
        '        'Open the report
        '        '*****************************************************
        '        objRpt = New ReportDocument()

        '        objRpt.Load(strRptPath)
        '        'rpt = rptApp.OpenReport(strRptPath)
        '        '*****************************************************
        '        'Set the Formula for the report
        '        '*****************************************************
        '        If Len(Trim(strFormula)) > 0 Then
        '            objRpt.RecordSelectionFormula = strFormula
        '            'rpt.RecordSelectionFormula = strFormula
        '        End If

        '        '*****************************************************
        '        'Set the parametrs to the report
        '        '*****************************************************
        '        If Not IsNothing(Matrix) Then
        '            For i = 0 To Matrix.GetUpperBound(0)
        '                For j = 0 To Matrix.GetUpperBound(1)
        '                    If j = 0 Then
        '                        strParamName = Matrix(i, j)
        '                    ElseIf j = 1 Then
        '                        strParamVal = Matrix(i, j)
        '                    Else
        '                        strParamType = Matrix(i, j)
        '                    End If
        '                    '*************************
        '                    If IsNothing(strParamName) Then
        '                        Exit For
        '                    End If
        '                    '*************************
        '                Next j
        '                '*************************
        '                If IsNothing(strParamName) Then
        '                    Exit For
        '                End If
        '                '*****************************************************
        '                'Pass the Parameter and Parameter value to the report
        '                If strParamType = "Int" Then
        '                    objRpt.SetParameterValue(strParamName, CInt(strParamVal))
        '                Else
        '                    objRpt.SetParameterValue(strParamName, strParamVal)
        '                End If

        '                'With rpt.ParameterFields
        '                '    If strParamType = "Int" Then
        '                '        .GetItemByName(strParamName).AddCurrentValue(CInt(strParamVal))
        '                '    Else
        '                '        .GetItemByName(strParamName).AddCurrentValue(strParamVal)
        '                '    End If
        '                'End With
        '                '*****************************************************
        '            Next i
        '        End If

        '        '*****************************************************
        '        'Landscape or Portrait
        '        '*****************************************************
        '        'ps.DefaultPageSettings.Landscape = iOrientationLandscape
        '        '*****************************************************
        '        ''Print the Crystal Report
        '        '*****************************************************
        '        'objRpt.PrintOptions.PaperOrientation = [Shared].PaperOrientation.Landscape
        '        objRpt.PrintToPrinter(iNumCopies, True, 0, 0)
        '        'For i = 1 To iNumCopies
        '        '    rpt.PrintOut(False, 1)
        '        'Next i
        '        '*****************************************************
        '        System.Windows.Forms.Application.DoEvents()

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        'ps = Nothing
        '        'rpt = Nothing
        '        'rptApp = Nothing
        '        'If Not IsNothing(ps) Then
        '        '    ps = Nothing
        '        'End If
        '        'If Not IsNothing(rpt) Then
        '        '    rpt = Nothing
        '        'End If
        '        'If Not IsNothing(rptApp) Then
        '        '    rptApp = Nothing
        '        'End If

        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '        GC.Collect()
        '        GC.WaitForPendingFinalizers()
        '    End Try
        'End Sub

        '*******************************************************************

        '*******************************************************************
        Public Function GetMessReportTypes() As DataTable
            Dim strSQL As String = ""

            Try
                strSQL = "SELECT MessReport_ID, MessReport_Name " & Environment.NewLine
                strSQL &= "FROM tmessreports " & Environment.NewLine
                strSQL &= "WHERE MessReport_Active = 1 " & Environment.NewLine
                strSQL &= "ORDER BY MessReport_Name"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function CreateShipPallet(ByVal lstItems As ListBox,
                                                     ByVal iUsrID As Integer,
                                                     ByVal strWk_Dt As String,
                                                     ByVal iDevQty As Integer,
                                                     ByRef strPalletName As String) As Integer
            Const iCUST_ID As Integer = 14
            Const iLOC_ID As Integer = 19
            Dim objMessRec As New PSS.Data.Buisness.MessReceive()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim objManifest As New PSS.Data.Buisness.DBRManifest()
            Dim strSql As String = ""
            Dim strItems As String = ""
            Dim dt1 As DataTable
            Dim dtOutput As DataTable
            Dim drNewRow As DataRow
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strBaudRate As String = ""
            Dim strFilePath As String = "P:\Dept\Messaging\American Messaging\Ship Reports\"
            Dim iPallett_ID As Integer = 0

            Try
                strPalletName = "AMREP" & Format(CDate(strWk_Dt), "yyyyMMdd") & "N"
                '**************************************************
                'Build string of input items
                '**************************************************
                strItems = ""
                For i = 0 To lstItems.Items.Count - 1
                    If i = 0 Then
                        strItems &= lstItems.Items.Item(i)
                    Else
                        strItems &= ", " & lstItems.Items.Item(i)
                    End If
                Next i

                '**************************************************
                'Stop if input ship ID is already had pallet
                '**************************************************
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Ship_ID IN ( " & strItems & ") " & Environment.NewLine
                strSql &= "AND Pallett_ID is not null;"
                dt1 = Me._objDataProc.GetDataTable(strSql)
                If dt1.Rows(0)("cnt") > 0 Then
                    Throw New Exception("There are " & dt1.Rows(0)("cnt") & " devices have been assigned to a pallet. Please remove them from the list.")
                End If

                '*************************************
                'Create Ship Pallet and Packing slip
                '*************************************
                strPalletName = objManifest.DefinePalletName(strPalletName, iCUST_ID, iLOC_ID)
                iPallett_ID = objManifest.CreateShipPalletID(strPalletName, iCUST_ID, iLOC_ID, strWk_Dt, 0, iDevQty)

                If iPallett_ID = 0 Then
                    Throw New Exception("System has failed to create Pallet ID.")
                End If

                '**************************************************
                'Assign pallet ID to devices
                ''**************************************************
                strSql = "UPDATE tdevice, tmessdata, tship " & Environment.NewLine
                strSql &= "SET tdevice.Pallett_ID = " & iPallett_ID & " " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id = 7 " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_EntryDt = now() " & Environment.NewLine
                'Set Report Create Date in tship table
                strSql &= ", tship.Ship_RptCreationDT = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "AND tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= "AND tdevice.Ship_ID IN ( " & strItems & ")"
                i = Me._objDataProc.ExecuteNonQuery(strSql)


                '**************************************************
                'Get data for American Messaging Ship Report
                '**************************************************
                strSql = "select tdevice.Device_SN, " & Environment.NewLine
                strSql &= "tdevicemetro.deviceMetro_CapCode, " & Environment.NewLine
                strSql &= "lfrequency.freq_Number, " & Environment.NewLine
                strSql &= "tdevicemetro.deviceMetro_SKU, " & Environment.NewLine
                strSql &= "tdevice.Ship_ID, " & Environment.NewLine
                strSql &= "(CASE WHEN tmodel.model_id IN (87, 808) THEN am_format_2way ELSE am_format END) AS 'Format' " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.deviceMetro_SN " & Environment.NewLine
                strSql &= "left outer join lfrequency on tdevicemetro.Freq_ID = lfrequency.freq_id " & Environment.NewLine
                strSql &= "inner join tmodel on tmodel.model_id = tdevice.model_id " & Environment.NewLine
                strSql &= "inner join tmessdata on tdevice.device_id = tmessdata.device_id " & Environment.NewLine
                strSql &= "left join lbaud on tmessdata.baud_id = lbaud.baud_id " & Environment.NewLine
                strSql &= "where tdevice.Ship_ID in (" & strItems & ") and " & Environment.NewLine
                strSql &= "tdevice.Device_DateShip is not null"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                '*************************************
                'Build a new table for output data of rpt
                dtOutput = New DataTable()

                '**************************************************
                'Add Columns to the brand new table
                i = 0

                i = Generic.AddNewColumnToDataTable(dtOutput, "Ship Manifest No", "System.Int32")
                If i = 0 Then
                    Throw New Exception("'Add New Column 'Ship Manifest No' to the datatable failed.")
                End If
                i = Generic.AddNewColumnToDataTable(dtOutput, "Serial No", "System.String")
                If i = 0 Then
                    Throw New Exception("'Add New Column 'Serial No' to the datatable failed.")
                End If
                i = Generic.AddNewColumnToDataTable(dtOutput, "Capcode", "System.String")
                If i = 0 Then
                    Throw New Exception("'Add New Column 'Capcode' to the datatable failed.")
                End If
                i = Generic.AddNewColumnToDataTable(dtOutput, "Frequency", "System.String")
                If i = 0 Then
                    Throw New Exception("'Add New Column 'Frequency' to the datatable failed.")
                End If
                i = Generic.AddNewColumnToDataTable(dtOutput, "Baud Rate", "System.String")
                If i = 0 Then
                    Throw New Exception("'Add New Column 'Baud Rate' to the datatable failed.")
                End If
                i = Generic.AddNewColumnToDataTable(dtOutput, "Format", "System.String")
                If i = 0 Then
                    Throw New Exception("'Add New Column 'Format' to the datatable failed.")
                End If
                '**************************************************
                For Each R1 In dt1.Rows

                    drNewRow = dtOutput.NewRow()
                    If Not IsDBNull(R1("Ship_ID")) Then
                        drNewRow("Ship Manifest No") = R1("Ship_ID")
                    Else
                        drNewRow("Ship Manifest No") = ""
                    End If
                    If Not IsDBNull(R1("Device_SN")) Then
                        drNewRow("Serial No") = Trim(R1("Device_SN"))
                    Else
                        drNewRow("Serial No") = ""
                    End If
                    If Not IsDBNull(R1("deviceMetro_CapCode")) Then
                        drNewRow("Capcode") = Trim(R1("deviceMetro_CapCode"))
                    Else
                        drNewRow("Capcode") = ""
                    End If
                    If Not IsDBNull(R1("freq_Number")) Then
                        drNewRow("Frequency") = Trim(R1("freq_Number"))
                    Else
                        drNewRow("Frequency") = ""
                    End If
                    If Not IsDBNull(R1("Format")) Then
                        drNewRow("Format") = Trim(R1("Format"))
                    Else
                        drNewRow("Format") = ""
                    End If

                    strBaudRate = ""
                    If Not IsDBNull(R1("deviceMetro_SKU")) Then
                        If Trim(R1("deviceMetro_SKU")) <> "" Then
                            strBaudRate = objMessRec.CreateBaudRateFromSKU(Trim(R1("deviceMetro_SKU")))
                        End If
                    End If
                    drNewRow("Baud Rate") = strBaudRate

                    dtOutput.Rows.Add(drNewRow)
                    dtOutput.AcceptChanges()
                    drNewRow = Nothing

                Next R1

                If dtOutput.Rows.Count > 0 Then
                    objGen.CreateExelReport(dtOutput, 1, strFilePath & strPalletName & ".xls", 0, , , 1, )
                End If

                Return iPallett_ID
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objMessRec = Nothing
                objManifest = Nothing
                R1 = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dtOutput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*******************************************************************
        Public Function GetDeviceNoInShipManifest(ByVal iShip_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim drArr() As DataRow
            Dim iQty As Integer = 0

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Ship_ID = " & iShip_ID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                drArr = dt1.Select("Pallett_ID is not null")
                If drArr.Length > 0 Then Throw New Exception("Item contains devices have already assgined to a pallet.")

                iQty = dt1.Rows.Count

                Return iQty
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
            End Try
        End Function

        '*******************************************************************
        Public Function GetTotalDevInList(ByVal strItemsType As String, _
                                          ByVal lstItems As System.Windows.Forms.ListBox) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strItemsList As String = ""
            Dim i As Integer = 0
            Dim iTotalDev As Integer = 0

            Try
                If strItemsType <> "Device_SN" Then
                    For i = 0 To lstItems.Items.Count - 1
                        If strItemsList = "" Then
                            strItemsList = lstItems.Items.Item(i)
                        Else
                            strItemsList &= ", " & lstItems.Items.Item(i)
                        End If
                    Next i
                End If

                Select Case strItemsType
                    Case "Device_SN"
                        iTotalDev = lstItems.Items.Count
                    Case "Tray_ID"
                        strSql = "SELECT count(*) as cnt FROM tdevice WHERE Tray_ID IN (" & strItemsList & ");"
                    Case "Ship_ID"
                        strSql = "SELECT count(*) as cnt FROM tdevice WHERE Ship_ID IN (" & strItemsList & ");"
                    Case "WO_ID"
                        strSql = "SELECT count(*) as cnt FROM tdevice WHERE WO_ID IN (" & strItemsList & ");"
                End Select

                If strSql <> "" Then
                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    If dt1.Rows.Count > 0 Then
                        iTotalDev = dt1.Rows(0)("cnt")
                    End If
                End If

                Return iTotalDev
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
            End Try
        End Function

        '*******************************************************************
        Public Function GetMessWIPDetailData(ByVal dtWIPCutoffDate As Date, _
                                             ByVal iCustID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT E.WO_CustWO AS 'Work Order' " & Environment.NewLine
                strSQL += ", CONCAT(I.wipowner_desc, IF( I.wipowner_id = 3 , CONCAT(' ', K.cc_desc) , '' ) )  AS 'Location'" & Environment.NewLine
                strSQL &= ", IF(J.freq_number is null, '', J.freq_number) AS Frequency " & Environment.NewLine
                strSQL &= ", CAST(A.Tray_ID AS CHAR) AS 'Tray ID', C.Model_Desc AS 'Model Desc' " & Environment.NewLine
                strSQL += ", A.Device_SN AS 'Device SN', CONCAT('*', A.Device_SN, '*') AS 'Device SN Barcode' " & Environment.NewLine
                strSQL &= ", IFNULL(A.Device_OldSN, '') AS 'Old Device SN' " & Environment.NewLine
                strSQL += ", IF( A.Device_DateRec IS NULL , '' , DATE_FORMAT(A.Device_DateRec, '%Y-%m-%d') ) AS 'Receive Date' " & Environment.NewLine
                strSQL += ", IF( A.Device_DateBill IS NULL , '', DATE_FORMAT(A.Device_DateBill, '%Y-%m-%d') ) AS 'Bill Date' " & Environment.NewLine
                strSQL += ", IF( A.Device_DateShip IS NULL , '', DATE_FORMAT(A.Device_DateShip, '%Y-%m-%d') ) AS 'Ship Date' " & Environment.NewLine
                strSQL &= ", TO_DAYS('" & Format(dtWIPCutoffDate, "yyyy-MM-dd") & "') - TO_DAYS(A.Device_DateRec) AS 'Days In WIP' " & Environment.NewLine
                strSQL &= ", TO_DAYS('" & Format(dtWIPCutoffDate, "yyyy-MM-dd") & "') - TO_DAYS(H.WIPOwner_EntryDt) AS 'Days In WIP For Location'" & Environment.NewLine
                'If (iCustID = 14) Then strSQL &= ", IF(Ship_ID = 9999919 , 'Yes', 'No') as 'DBR/NER'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN production.tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                'strSQL &= "INNER JOIN production.lproduct D ON D.Prod_ID = C.Prod_ID " & Environment.NewLine
                strSQL &= "INNER JOIN production.tworkorder E ON E.WO_ID = A.WO_ID " & Environment.NewLine
                'strSQL &= "INNER JOIN production.tcustomer F ON F.Cust_ID = B.Cust_ID " & Environment.NewLine
                'strSQL &= "INNER JOIN production.lparentco G ON G.PCo_ID = F.PCo_ID " & Environment.NewLine
                strSQL &= "INNER JOIN production.tmessdata H ON A.Device_ID = H.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN production.lwipowner I ON H.wipowner_id = I.wipowner_id " & Environment.NewLine
                strSQL &= "LEFT JOIN production.lfrequency J ON J.freq_id = H.freq_id " & Environment.NewLine
                strSQL &= "LEFT JOIN production.tcostcenter K ON K.cc_id = A.cc_id" & Environment.NewLine
                strSQL &= "WHERE ((A.Device_DateShip IS NULL OR A.Device_DateShip > '" & Format(dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "') " & Environment.NewLine
                strSQL &= "AND A.Device_DateRec <= '" & Format(dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "' " & Environment.NewLine
                If iCustID > 0 Then strSQL &= "AND B.Cust_ID  = " & iCustID & Environment.NewLine
                strSQL &= "AND C.Prod_ID = 1 ) " & Environment.NewLine
                'If (iCustID = 14) Then strSQL &= "OR H.wipowner_id <> 7 " & Environment.NewLine
                strSQL &= "ORDER BY 'Days In WIP' DESC, 'Work Order'"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function CreateAM_UnicationDashboardReport(ByVal dProcessDate As Date) As Integer
            Dim strSql As String = ""
            Dim iPSSShipment As Integer = 0
            Dim iPSSWIP As Integer = 0
            Dim iProcessedReturns As Integer = 0
            Dim iDBRUnits As Integer = 0
            Dim iYeild As Integer = 0
            Dim dtOutput As New DataTable()
            Dim drNewRow As DataRow
            Dim i As Integer = 0
            Dim strUnicationModelList As String = "786, 807"
            Dim strFileDir As String = "P:\Dept\Messaging\American Messaging\Unication Dashboard\"
            Dim strFileName As String = "Unication Dashboard " & Format(dProcessDate, "MM-dd-yyyy HHmmss") & ".xls"

            Try
                '**************************************************
                'Add Columns to the brand new table
                '**************************************************
                i = 0
                i = Generic.AddNewColumnToDataTable(dtOutput, "Description", "System.String")
                If i = 0 Then
                    Throw New Exception("Failed to add new column 'Description' to the datatable.")
                End If
                i = Generic.AddNewColumnToDataTable(dtOutput, "Value", "System.String")
                If i = 0 Then
                    Throw New Exception("Failed to add new column 'Value' to the datatable.")
                End If

                '**************************************************
                'Get PSS Shipment
                '**************************************************
                strSql = "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE loc_ID = 19 " & Environment.NewLine
                strSql &= "AND Model_ID IN (" & strUnicationModelList & ") " & Environment.NewLine
                strSql &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                strSql &= "AND Device_ShipWorkDate = '" & Format(dProcessDate, "yyyy-MM-dd") & "';"

                iPSSShipment = Me._objDataProc.GetIntValue(strSql)

                '**************************************************
                'Get PSS WIP
                '**************************************************
                strSql = "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE loc_ID = 19 " & Environment.NewLine
                strSql &= "AND Model_ID IN (" & strUnicationModelList & ") " & Environment.NewLine
                strSql &= "AND (Device_DateShip is null OR Device_ShipWorkDate > '" & Format(dProcessDate, "yyyy-MM-dd") & "');"

                iPSSWIP = Me._objDataProc.GetIntValue(strSql)

                '**************************************************
                'Get Processed Returns
                '**************************************************
                strSql = "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                strSql &= "FROM tverdata " & Environment.NewLine
                strSql &= "WHERE Device_Model IN ( 'EU', 'G5', 'E2') " & Environment.NewLine
                strSql &= "AND Loc_Chg_Date = '" & Format(dProcessDate, "yyyy-MM-dd") & "';"
                iProcessedReturns = Me._objDataProc.GetIntValue(strSql)

                '**************************************************
                'Get DBR Units
                '**************************************************
                strSql = "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE loc_ID = 19 " & Environment.NewLine
                strSql &= "AND Model_ID IN (" & strUnicationModelList & ") " & Environment.NewLine
                strSql &= "AND Ship_ID = 9999919 " & Environment.NewLine
                strSql &= "AND Device_ShipWorkDate = '" & Format(dProcessDate, "yyyy-MM-dd") & "';"
                iDBRUnits = Me._objDataProc.GetIntValue(strSql)
                '**************************************************
                'Calculate Yeild = Process Returns - DBR
                '**************************************************
                iYeild = iProcessedReturns - iDBRUnits

                '**************************************************
                drNewRow = dtOutput.NewRow
                drNewRow("Description") = "Unication Product"
                drNewRow("Value") = Format(dProcessDate, "yyyy-MM-dd")
                dtOutput.Rows.Add(drNewRow)
                dtOutput.AcceptChanges()

                drNewRow = Nothing
                drNewRow = dtOutput.NewRow
                drNewRow("Description") = "PSS Shipment"
                drNewRow("Value") = iPSSShipment.ToString
                dtOutput.Rows.Add(drNewRow)
                dtOutput.AcceptChanges()

                drNewRow = Nothing
                drNewRow = dtOutput.NewRow
                drNewRow("Description") = "PSS WIP"
                drNewRow("Value") = iPSSWIP.ToString
                dtOutput.Rows.Add(drNewRow)
                dtOutput.AcceptChanges()

                drNewRow = Nothing
                drNewRow = dtOutput.NewRow
                drNewRow("Description") = "Processed Returns"
                drNewRow("Value") = iProcessedReturns.ToString
                dtOutput.Rows.Add(drNewRow)
                dtOutput.AcceptChanges()

                drNewRow = Nothing
                drNewRow = dtOutput.NewRow
                drNewRow("Description") = "Yield"
                drNewRow("Value") = iYeild.ToString
                dtOutput.Rows.Add(drNewRow)
                dtOutput.AcceptChanges()

                If dtOutput.Rows.Count > 0 Then
                    If Not Directory.Exists(strFileDir) Then Directory.CreateDirectory(strFileDir)

                    Generic.CreateExelReportWithTitle(dtOutput, New String() {"Unication Dashboard"}, 1, 2, 0, 1, 0, 0, 0, strFileDir & strFileName)
                End If

                Return dtOutput.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                drNewRow = Nothing
                Me.DisposeDT(dtOutput)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*******************************************************************
        Public Sub CreateMsgWIPReport()
            Dim strSql As String = ""
            Dim dtBucket As DataTable

            Try
                '**************************************************
                'Get PSS Shipment
                '**************************************************
                strSql = "select wipowner_desc as Bucket, count(*) as Qty " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "inner join lwipowner on tmessdata.wipowner_id = lwipowner.wipowner_id " & Environment.NewLine
                strSql &= "where loc_id = 19 and (Ship_ID is null or ship_id <> 9999919) and tmessdata.wipowner_id not in (0, 3, 7) " & Environment.NewLine
                strSql &= "group by wipowner_desc " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "select concat( wipowner_desc, ' ', tcostcenter.cc_desc) as Bucket, count(*) as Qty " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "inner join lwipowner on tmessdata.wipowner_id = lwipowner.wipowner_id " & Environment.NewLine
                strSql &= "left outer join tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "where loc_id = 19 and tmessdata.wipowner_id = 3 " & Environment.NewLine
                strSql &= "group by wipowner_desc, tdevice.cc_id " & Environment.NewLine
                strSql &= "order by Bucket;"
                dtBucket = Me._objDataProc.GetDataTable(strSql)

                If dtBucket.Rows.Count > 0 Then
                    Generic.CreateExelReport(dtBucket, 1, , 1, , , , "B")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dtBucket)

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*********************************************************************
        Public Function CreateReceiptByWeekRpt(ByVal iLoc_ID As Integer) As Integer
            Const sngFontSize As Single = 9

            Dim strSQL As String
            Dim dt As DataTable
            Dim ds As DataSet
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet   ' Excel Worksheet
            Dim objOutput(,) As Object
            Dim iHeaderRow As Integer = 4
            Dim strHeaders1() As String = {"Model", "Previous" & vbLf & "8 Week" & vbLf & "Average", "Previous" & vbLf & "4 Week" & vbLf & "Average", "Previous" & vbLf & "2 Week" & vbLf & "Average", "LW - 7", "LW - 6", "LW - 5", "LW - 4", "LW - 3", "LW - 2", "LW - 1", "Last Week"}
            Dim strHeaders2() As String = {"Model", "Weighted" & vbLf & "8 Week" & vbLf & "Average", "Weighted" & vbLf & "4 Week" & vbLf & "Average", "Weighted" & vbLf & "2 Week" & vbLf & "Average", "Yield", "Weighted Estimate" & vbLf & "Total Weekly" & vbLf & "Inbound", "Weighted Estimate" & vbLf & "Total Weekly" & vbLf & "Inbound -" & vbLf & "Good Yield", "Customer" & vbLf & "Need" & vbLf & "Good", "Variances", "On Hold", "AWP"}
            Dim strHeader As String
            Dim i, j, iRowCount, iHold, iAWB, iSA, iTotalWIP, iGoal, k As Integer
            Dim dr As DataRow
            Dim drProduction(), drForecast(), drHold(), drAWB(), drSA(), drTotalWIP(), drYield() As DataRow
            Dim dblWeights() As Double = {0.1, 0.2, 0.7}
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
            Dim dblYield As Double
            Dim strDateTimeStamp As String = ""
            Dim iWeek As Integer

            Try
                ds = New DataSet("Receipts by Week")

                'THIS QUERY TAKE TO LONG -- Modify on 02/03/2009
                'strSQL = "SELECT DISTINCT A.model_id, B.model_desc" & Environment.NewLine
                'strSQL &= "FROM production.tdevice A" & Environment.NewLine
                'strSQL &= "INNER JOIN production.tmodel B ON B.model_id = A.model_id" & Environment.NewLine
                'strSQL &= "WHERE B.prod_id = 1" & Environment.NewLine
                'strSQL &= "AND A.loc_id = " & iLoc_ID.ToString & Environment.NewLine
                'strSQL &= "AND A.model_id <> 289" & Environment.NewLine
                'strSQL &= "ORDER BY B.model_desc"

                strSQL = "SELECT DISTINCT model_id, model_desc" & Environment.NewLine
                strSQL &= "FROM production.tmodel " & Environment.NewLine
                strSQL &= "WHERE prod_id = 1" & Environment.NewLine
                strSQL &= "AND model_id <> 289" & Environment.NewLine
                strSQL &= "ORDER BY model_desc"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Model Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT DISTINCT WEEK(Device_RecWorkDate, 3)" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= "WHERE WEEK(Device_RecWorkDate) BETWEEN WEEK(DATE_SUB(NOW(), INTERVAL 7 DAY), 5) AND WEEK(DATE_SUB(NOW(), INTERVAL 7 * 8 DAY), 5) " & Environment.NewLine
                strSQL &= "AND TO_DAYS(NOW()) - TO_DAYS(Device_RecWorkDate) < 100" & Environment.NewLine
                strSQL &= "AND loc_id = " & iLoc_ID.ToString & Environment.NewLine
                strSQL &= "GROUP BY WEEK(Device_RecWorkDate, 3)" & Environment.NewLine
                strSQL &= "ORDER BY YEAR(Device_RecWorkDate), WEEK(Device_RecWorkDate, 3)"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Weeks Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT WEEK(A.Device_RecWorkDate, 3) AS week, B.model_id, COUNT(A.device_id) AS Qty" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel B ON B.model_id = A.model_id" & Environment.NewLine
                strSQL &= "WHERE WEEK(A.Device_RecWorkDate) BETWEEN WEEK(DATE_SUB(NOW(), INTERVAL 7 DAY)) AND WEEK(DATE_SUB(NOW(), INTERVAL 7 * 8 DAY)) " & Environment.NewLine
                strSQL &= "AND TO_DAYS(NOW()) - TO_DAYS(A.Device_RecWorkDate) < 100" & Environment.NewLine
                strSQL &= "AND A.loc_id = " & iLoc_ID.ToString & Environment.NewLine
                strSQL &= "GROUP BY WEEK(A.Device_RecWorkDate, 3), A.model_id" & Environment.NewLine
                strSQL &= "ORDER BY YEAR(Device_RecWorkDate), WEEK(A.Device_RecWorkDate, 3)"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Production Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT model_id, forecast" & Environment.NewLine
                strSQL &= "FROM cogs.tmessaging_forecast" & Environment.NewLine
                strSQL &= "WHERE year = YEAR(NOW())" & Environment.NewLine
                strSQL &= "AND yearweek = WEEK(NOW(), 3)" & Environment.NewLine
                strSQL &= "AND facility_id = 1"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "COGS Data"
                    ds.Tables.Add(dt)
                End If

                dt = Me.GetMsgHoldAndAWAP(iLoc_ID)

                If Not IsNothing(dt) Then
                    dt.TableName = "Hold Data"
                    ds.Tables.Add(dt)
                End If

                dt = Me.GetDistinctModelAndYieldPercent(iLoc_ID)

                dt.TableName = "Yield Data"
                ds.Tables.Add(dt)

                GetPartsData(ds)
                GetForecastAWBURData(ds)
                GetSAData(ds)
                GetTotalWIPData(ds)
                GetAwaitingBillingData(ds)

                strDateTimeStamp = GetDateTimeStamp()

                'Prepare report
                objExcel = New Excel.Application()
                objExcel.Application.DisplayAlerts = False
                objWorkbook = objExcel.Workbooks.Add
                objSheet = objWorkbook.Sheets("Sheet1")
                objExcel.Visible = True
                'objSheet.Activate()
                objSheet.Name = "Receipts by Week"

                With objSheet.Range("A1:A1").Font
                    .Name = "Arial"
                    .FontStyle = "Bold"
                    .Size = 14
                    .Underline = True
                    .ColorIndex = 25
                End With

                objSheet.Range("A1", "K1").Merge()
                objSheet.Range("A1", "K1").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Range("A1:A1").Value = "Receipts by Week"

                With objSheet.Range("A2:A2").Font
                    .Name = "Arial"
                    .FontStyle = "Regular"
                    .Size = 9
                End With

                objSheet.Range("A2", "A2").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Range("A2:A2").Value = strDateTimeStamp

                i = 0

                For Each strHeader In strHeaders1
                    i += 1

                    If i >= 5 Then strHeader += vbLf & "(" + ds.Tables("Weeks Data").Rows(i - 5)(0).ToString + ")"

                    objSheet.Range(Chr(65 + i - 1) & iHeaderRow.ToString & ":" & Chr(65 + i - 1) & iHeaderRow.ToString).Value = strHeader
                    objSheet.Range(Chr(65 + i - 1) & iHeaderRow.ToString & ":" & Chr(65 + i - 1) & iHeaderRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

                    With objSheet.Range(Chr(65 + i - 1) & iHeaderRow.ToString & ":" & Chr(65 + i - 1) & iHeaderRow.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = sngFontSize
                    End With
                Next strHeader

                objSheet.Range("A" & (iHeaderRow + 1).ToString & ":A" & (iHeaderRow + 1 + ds.Tables("Model Data").Rows.Count).ToString).NumberFormat = "@"
                objSheet.Range("B" & (iHeaderRow + 1).ToString & ":L" & (iHeaderRow + 1 + ds.Tables("Model Data").Rows.Count).ToString).NumberFormat = "#,##0;[Red](#,##0)"

                ReDim objOutput(ds.Tables("Model Data").Rows.Count - 1, 11)
                i = -1

                For Each dr In ds.Tables("Model Data").Rows
                    drProduction = ds.Tables("Production Data").Select("model_id = " & dr("model_id"))

                    If drProduction.Length > 0 And ds.Tables("COGS Data").Select("model_id = " & dr("model_id")).Length > 0 Then
                        i += 1
                        objOutput(i, 0) = dr("model_desc")

                        'Initialize
                        For j = 0 To 7
                            objOutput(i, j + 4) = 0
                        Next j

                        For j = 0 To 7
                            If j <= ds.Tables("Weeks Data").Rows.Count - 1 Then
                                iWeek = ds.Tables("Weeks Data").Rows(j)(0)

                                For k = 0 To drProduction.Length - 1
                                    If drProduction(k)("week") = iWeek Then
                                        objOutput(i, j + 4) = CInt(drProduction(k)("Qty"))

                                        Exit For
                                    End If
                                Next k
                            End If
                        Next j

                        'For j = drProduction.Length - 1 To 0 Step -1
                        '    'objOutput(i, 4 + (drProduction.Length - 1) - j) = drProduction(j)("Qty")
                        '    objOutput(i, 4 + j) = drProduction(j)("Qty")
                        'Next j

                        'If drProduction.Length < 8 Then 'Place zeroes for missing data
                        '    For j = drProduction.Length To 7
                        '        objOutput(i, j + 4) = 0
                        '    Next j
                        'End If

                        objOutput(i, 1) = "=AVERAGE(E" & (iHeaderRow + i + 1).ToString & ":L" & (iHeaderRow + i + 1).ToString & ")"
                        objOutput(i, 2) = "=AVERAGE(I" & (iHeaderRow + i + 1).ToString & ":L" & (iHeaderRow + i + 1).ToString & ")"
                        objOutput(i, 3) = "=AVERAGE(K" & (iHeaderRow + i + 1).ToString & ":L" & (iHeaderRow + i + 1).ToString & ")"
                    End If
                Next dr

                iRowCount = i + 1

                If iRowCount > 0 Then
                    objSheet.Range("A" & (iHeaderRow + 1).ToString & ":L" & (iHeaderRow + iRowCount).ToString).Value = objOutput

                    With objSheet.Range("A" & (iHeaderRow + 1).ToString & ":L" & (iHeaderRow + iRowCount).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Regular"
                        .Size = sngFontSize
                    End With

                    objExcel.Range("A" & (iHeaderRow + iRowCount + 1).ToString & ":A" & (iHeaderRow + iRowCount + 1).ToString).Value = "Total"
                    objExcel.Range("B" & (iHeaderRow + iRowCount + 1).ToString & ":L" & (iHeaderRow + iRowCount + 1).ToString).Value = "=SUM(R[-" & iRowCount.ToString & "]C:R[-1]C)"

                    With objSheet.Range("A" & (iHeaderRow + iRowCount + 1).ToString & ":L" & (iHeaderRow + iRowCount + 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = sngFontSize
                    End With

                    objExcel.Range("A" & iHeaderRow.ToString & ":L" & (iHeaderRow + iRowCount + 1).ToString).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For i = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(i))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next i
                End If

                'Draw a heavier border at the bottom of header row
                objExcel.Range("A" & iHeaderRow.ToString & ":L" & iHeaderRow.ToString).Select()

                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                'Draw a heavier border at the top of totals row
                objExcel.Range("A" & (iHeaderRow + iRowCount + 1).ToString & ":L" & (iHeaderRow + iRowCount + 1).ToString).Select()

                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                'Now display second set of data
                iHeaderRow += iRowCount + 3
                i = 0

                For Each strHeader In strHeaders2
                    i += 1

                    objSheet.Range(Chr(65 + i - 1) & iHeaderRow.ToString & ":" & Chr(65 + i - 1) & iHeaderRow.ToString).Value = strHeader
                    objSheet.Range(Chr(65 + i - 1) & iHeaderRow.ToString & ":" & Chr(65 + i - 1) & iHeaderRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

                    With objSheet.Range(Chr(65 + i - 1) & iHeaderRow.ToString & ":" & Chr(65 + i - 1) & iHeaderRow.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = sngFontSize
                    End With
                Next strHeader

                objSheet.Range("A" & (iHeaderRow + 1).ToString & ":A" & (iHeaderRow + 1 + ds.Tables("Model Data").Rows.Count).ToString).NumberFormat = "@"
                objSheet.Range("B" & (iHeaderRow + 1).ToString & ":D" & (iHeaderRow + 1 + ds.Tables("Model Data").Rows.Count).ToString).NumberFormat = "#,##0;[Red](#,##0)"
                objSheet.Range("E" & (iHeaderRow + 1).ToString & ":E" & (iHeaderRow + 1 + ds.Tables("Model Data").Rows.Count).ToString).NumberFormat = "#,##0%;[Red](#,##0)%"
                objSheet.Range("F" & (iHeaderRow + 1).ToString & ":K" & (iHeaderRow + 1 + ds.Tables("Model Data").Rows.Count).ToString).NumberFormat = "#,##0;[Red](#,##0)"

                ReDim objOutput(ds.Tables("Model Data").Rows.Count - 1, 10)
                i = -1

                For Each dr In ds.Tables("Model Data").Rows
                    drForecast = ds.Tables("Weekly Forecast Data").Select("model_id = " & dr("model_id"))

                    If drForecast.Length > 0 And ds.Tables("Production Data").Select("model_id = " & dr("model_id")).Length > 0 Then 'Make sure model has been received within the 8-week period
                        i += 1

                        objOutput(i, 0) = dr("model_desc")
                        objOutput(i, 1) = "=B" & (iHeaderRow + 1 + i - iRowCount - 3).ToString & " * " & String.Format("{0:F1}", dblWeights(0))
                        objOutput(i, 2) = "=C" & (iHeaderRow + 1 + i - iRowCount - 3).ToString & " * " & String.Format("{0:F1}", dblWeights(1))
                        objOutput(i, 3) = "=D" & (iHeaderRow + 1 + i - iRowCount - 3).ToString & " * " & String.Format("{0:F1}", dblWeights(2))

                        dblYield = 0

                        drYield = ds.Tables("Yield Data").Select("[Model_ID] = " & dr("Model_ID").ToString())

                        If drYield.Length > 0 Then dblYield = drYield(0)("Yield")

                        objOutput(i, 4) = dblYield
                        objOutput(i, 5) = "=SUM(B" & (iHeaderRow + 1 + i).ToString & ":D" & (iHeaderRow + 1 + i).ToString & ")"
                        objOutput(i, 6) = "=F" & (iHeaderRow + 1 + i).ToString & " * E" & (iHeaderRow + 1 + i).ToString

                        iGoal = Convert.ToInt32(drForecast(0)("forecast"))
                        objOutput(i, 7) = "=INT(" & iGoal.ToString & " * E" & (iHeaderRow + 1 + i).ToString & ")"
                        objOutput(i, 8) = "=G" & (iHeaderRow + 1 + i).ToString & " - H" & (iHeaderRow + 1 + i).ToString

                        iHold = 0
                        drHold = ds.Tables("Hold Data").Select("model_id = " & dr("model_id"))

                        If drHold.Length > 0 Then iHold = CInt(drHold(0)("Qty"))

                        objOutput(i, 9) = iHold

                        iAWB = 0
                        iSA = 0

                        drAWB = ds.Tables("Awaiting Billing Data").Select("[Model ID] = " & dr("model_id"))

                        If drAWB.Length > 0 Then iAWB = drAWB(0)("AWB")

                        drSA = ds.Tables("SA Data").Select("[Model ID] = " & dr("model_id"))

                        If drSA.Length > 0 Then iSA = drSA(0)("SA")

                        iTotalWIP = 0
                        drTotalWIP = ds.Tables("Total WIP Data").Select("[Model ID] = " + dr("Model_ID").ToString())

                        If drTotalWIP.Length > 0 Then iTotalWIP = drTotalWIP(0)("WIP Count")

                        objOutput(i, 10) = Math.Max(0, iAWB - iSA - iHold)
                        'objOutput(i, 10) = Math.Max(0, iTotalWIP - (iHold + iGoal))
                    End If
                Next dr

                If iRowCount > 0 Then
                    objSheet.Range("A" & (iHeaderRow + 1).ToString & ":K" & (iHeaderRow + iRowCount).ToString).Value = objOutput

                    With objSheet.Range("A" & (iHeaderRow + 1).ToString & ":K" & (iHeaderRow + iRowCount).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Regular"
                        .Size = sngFontSize
                    End With

                    objExcel.Range("A" & (iHeaderRow + iRowCount + 1).ToString & ":A" & (iHeaderRow + iRowCount + 1).ToString).Value = "Total"
                    objExcel.Range("B" & (iHeaderRow + iRowCount + 1).ToString & ":D" & (iHeaderRow + iRowCount + 1).ToString).Value = "=SUM(R[-" & iRowCount.ToString & "]C:R[-1]C)"
                    objExcel.Range("F" & (iHeaderRow + iRowCount + 1).ToString & ":K" & (iHeaderRow + iRowCount + 1).ToString).Value = "=SUM(R[-" & iRowCount.ToString & "]C:R[-1]C)"

                    With objSheet.Range("A" & (iHeaderRow + iRowCount + 1).ToString & ":K" & (iHeaderRow + iRowCount + 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = sngFontSize
                    End With

                    objExcel.Range("A" & iHeaderRow.ToString & ":K" & (iHeaderRow + iRowCount + 1).ToString).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For i = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(i))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next i
                End If

                'Draw a heavier border at the bottom of header row
                objExcel.Range("A" & iHeaderRow.ToString & ":K" & iHeaderRow.ToString).Select()

                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                'Draw a heavier border at the top of totals row
                objExcel.Range("A" & (iHeaderRow + iRowCount + 1).ToString & ":K" & (iHeaderRow + iRowCount + 1).ToString).Select()

                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                'Adjust column widths
                For i = 0 To 11 : objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = IIf(i = 0, 17, 10) : Next i

                'Set page orientation
                objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                objSheet.PageSetup.RightMargin = 8
                objSheet.PageSetup.LeftMargin = 8
                objSheet.PageSetup.BottomMargin = 5

                'Set zoom
                objExcel.ActiveWindow.Zoom = 85

                'Move selection to the upper left 
                objExcel.Range("B2:B2").Select()

                'Delete unused worksheets
                If objWorkbook.Sheets.Count > 1 Then
                    For i = objWorkbook.Sheets.Count To 2 Step -1
                        objWorkbook.Sheets("Sheet" & i.ToString).Delete()
                    Next i
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************
        Private Function GetMsgGoal() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Model_ID, forecast " & Environment.NewLine
                strSql &= "FROM cogs.tmessaging_forecast  " & Environment.NewLine
                strSql &= "WHERE year = YEAR(now()) and yearweek = WEEK(now()) and facility_id = 1 " & Environment.NewLine
                strSql &= "ORDER BY Model_ID;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Private Function GetMsgHoldAndAWAP(ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String

            Try
                'Bucket Hold & AWAP
                strSql = "SELECT Model_ID, wipowner_id, count(*) as Qty FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "WHERE loc_id = " & iLoc_ID & " AND tmessdata.wipowner_id IN ( 6, 8) " & Environment.NewLine
                strSql &= "GROUP BY Model_ID, wipowner_id " & Environment.NewLine
                strSql &= "ORDER BY Model_ID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function CreateDailyWeeklyMonthlyGoal(ByVal iLoc_ID As Integer) As Integer
            Const sngFontSize As Single = 9

            Dim strSql As String
            Dim dtData, dtGoal, dtHoldAndAWAP, dtShipDaily, dtShipWeekly, dtShipMonthly, dtModels As DataTable
            Dim R1, R2, drAWB(), drSA(), drForecast(), drTotalWIP() As DataRow
            Dim iRow As Integer = 1
            Dim i As Integer = 0
            Dim strStartDate As String = ""
            Dim strEndDate As String = ""
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim objOutput(,) As Object
            Dim strHeaders() As String = {"Model", "Goal", "Yield", "Receiving", "Pre-Cell", "In-Cell", "Passed QC", "Ready to" & vbLf & "Ship", "Total" & vbLf & "Estimated" & vbLf & "Based on" & vbLf & "Yield", "{0}" & vbLf & "Shipped", "Variance", "Hold", "AWP"}
            Dim strHeader As String
            Dim strTitle() As String = {"Daily", "Weekly", "4-Week"}
            Dim iIndex, j, iAWB, iSA, iForecast, iHold, iTotalWIP As Integer
            Dim drModels, drData() As DataRow
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
            'Dim dblYield As Double = 0.92
            Dim ds As DataSet
            Dim strDateTimeStamp As String = ""

            Try
                ds = New DataSet("Other Data")

                strStartDate = Format(CDate(Generic.MySQLServerDateTime(1)), "yyyy-MM-dd")
                strEndDate = strStartDate

                dtGoal = Me.GetMsgGoal
                dtHoldAndAWAP = Me.GetMsgHoldAndAWAP(iLoc_ID)
                dtShipDaily = Me.GetMsgShipQty(iLoc_ID, strStartDate, strEndDate)

                strStartDate = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strStartDate), FirstDayOfWeek.Monday) - 1) * -1, CDate(strStartDate)), "yyyy-MM-dd")
                dtShipWeekly = Me.GetMsgShipQty(iLoc_ID, strStartDate, strEndDate)
                'strStartDate = Format(CDate(Year(CDate(strEndDate)) & "-" & Month(CDate(strEndDate)) & "-" & "-01"), "yyyy-MM-dd")
                strStartDate = Format(DateAdd(DateInterval.Day, -21, CDate(strStartDate)), "yyyy-MM-dd")
                dtShipMonthly = Me.GetMsgShipQty(iLoc_ID, strStartDate, strEndDate)
                'dblYield = Me.GetYieldPercent(iLoc_ID, Format(DateAdd(DateInterval.Day, -28, CDate(strEndDate)), "yyyy-MM-dd"), strEndDate)

                dtModels = Me.GetDistinctModelAndYieldPercent(iLoc_ID)

                dtModels.TableName = "Model Data"
                ds.Tables.Add(dtModels)

                strSql = "SELECT tdevice.Model_ID, tmodel.Model_Desc as Model, tmessdata.wipowner_id as Bucket, count(*) as Qty , 0 as Goal, 0 as Daily, 0 as Weekly, 0 as Monthly, 0 AS Hold " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & " and tmessdata.wipowner_id in (1, 2, 3, 4, 6, 8) " & Environment.NewLine
                strSql &= "AND tdevice.model_id <> 289" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID,tmessdata.wipowner_id " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT tdevice.Model_ID, tmodel.Model_Desc as Model, tmessdata.wipowner_id as Bucket, count(*) as Qty , 0 as Goal, 0 as Daily, 0 as Weekly, 0 as Monthly, 0 AS Hold " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID  " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & " and tmessdata.wipowner_id in (5) " & Environment.NewLine
                strSql &= "AND Ship_id <> 9999919 " & Environment.NewLine
                strSql &= "AND tdevice.model_id <> 289" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID,tmessdata.wipowner_id " & Environment.NewLine
                strSql &= "ORDER BY Model;"

                dtData = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtData.Rows
                    If dtGoal.Rows.Count > 0 Then
                        If dtGoal.Select("Model_ID = " & R1("Model_ID")).Length > 0 Then
                            R1("Goal") = dtGoal.Select("Model_ID = " & R1("Model_ID"))(0)("forecast")
                        End If
                    End If

                    If dtHoldAndAWAP.Rows.Count > 0 Then
                        If dtHoldAndAWAP.Select("Model_ID = " & R1("Model_ID") & " AND wipowner_id = 6").Length > 0 Then
                            R1("Hold") = dtHoldAndAWAP.Select("Model_ID = " & R1("Model_ID") & " AND wipowner_id = 6")(0)("Qty")
                        End If
                        'If dtHoldAndAWAP.Select("Model_ID = " & R1("Model_ID") & " AND wipowner_id = 8").Length > 0 Then
                        '    R1("Hold") = dtHoldAndAWAP.Select("Model_ID = " & R1("Model_ID") & " AND wipowner_id = 8")(0)("Qty")
                        'End If
                    End If

                    If dtShipDaily.Rows.Count > 0 Then
                        If dtShipDaily.Select("Model_ID = " & R1("Model_ID")).Length > 0 Then
                            R1("Daily") = dtShipDaily.Select("Model_ID = " & R1("Model_ID"))(0)("Qty")
                        End If
                    End If

                    If dtShipWeekly.Rows.Count > 0 Then
                        If dtShipWeekly.Select("Model_ID = " & R1("Model_ID")).Length > 0 Then
                            R1("Weekly") = dtShipWeekly.Select("Model_ID = " & R1("Model_ID"))(0)("Qty")
                        End If
                    End If

                    If dtShipMonthly.Rows.Count > 0 Then
                        If dtShipMonthly.Select("Model_ID = " & R1("Model_ID")).Length > 0 Then
                            R1("Monthly") = dtShipMonthly.Select("Model_ID = " & R1("Model_ID"))(0)("Qty")
                        End If
                    End If
                Next R1

                GetPartsData(ds)
                'GeForecastData(ds)
                GetForecastAWBURData(ds)
                GetSAData(ds)
                GetTotalWIPData(ds)
                GetAwaitingBillingData(ds)

                strDateTimeStamp = GetDateTimeStamp()

                'Model
                'Bucket 1:Receive, 2: Pre-Cell, 3:In-Cell, 4:PassQC, 5:Ready To ship

                'Prepare report
                objExcel = New Excel.Application()
                objExcel.Application.DisplayAlerts = False
                objWorkbook = objExcel.Workbooks.Add
                objSheet = objWorkbook.Sheets("Sheet1")
                objExcel.Visible = True
                'objSheet.Activate()
                objSheet.Name = "Goals"

                objSheet.Range("A1:A200").NumberFormat = "@"
                objSheet.Range("B1:B200", "D1:L200").NumberFormat = "#,##0;[Red](#,##0)"
                objSheet.Range("C1:C200").NumberFormat = "#,##0%;[Red](#,##0%)"

                For iIndex = 0 To 2
                    'Print title

                    If iIndex = 0 Then
                        objSheet.Range("A" & iRow.ToString, "M" & iRow.ToString).Merge()
                        objSheet.Range("A" & iRow.ToString, "M" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    Else
                        objSheet.Range("A" & iRow.ToString, "K" & iRow.ToString).Merge()
                        objSheet.Range("A" & iRow.ToString, "K" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    End If

                    With objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 14
                        .Underline = True
                        .ColorIndex = 25
                    End With

                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = String.Format("{0} Goals", strTitle(iIndex))

                    iRow += 1

                    objSheet.Range("A" & iRow.ToString, "A" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlLeft

                    With objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Regular"
                        .Size = 9
                    End With

                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strDateTimeStamp

                    iRow += 2
                    i = 0

                    'Print headers
                    For Each strHeader In strHeaders
                        i += 1

                        If i <= 11 Then
                            If i = 10 Then strHeader = String.Format(strHeader, strTitle(iIndex))

                            objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).Value = strHeader
                        ElseIf iIndex = 0 Then
                            objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).Value = strHeader
                        End If

                        objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

                        With objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).Font
                            .Name = "Arial"
                            .FontStyle = "Bold"
                            .Size = sngFontSize
                        End With
                    Next strHeader

                    'Draw a heavier border at the top 
                    'objExcel.Range("A1:K1".ToString).Select()

                    'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    '    .LineStyle = Excel.XlLineStyle.xlContinuous
                    '    .Weight = Excel.XlBorderWeight.xlThick
                    '    .ColorIndex = 25
                    'End With

                    iRow += 1
                    i = -1
                    ReDim objOutput(dtData.Rows.Count - 1, 12)

                    For Each drModels In dtModels.Rows
                        i += 1
                        objOutput(i, 0) = drModels("Model")
                        objOutput(i, 2) = drModels("Yield")

                        For j = 1 To 5
                            drData = dtData.Select("Model_ID = " & drModels("Model_ID") & " AND Bucket = " & j.ToString)
                            iForecast = 0

                            If drData.Length > 0 Then
                                If iIndex <= 1 Then
                                    drForecast = ds.Tables("Weekly Forecast Data").Select("Model_Id = " & drModels("Model_ID"))
                                Else
                                    drForecast = ds.Tables("4-Week Forecast Data").Select("Model_Id = " & drModels("Model_ID"))
                                End If

                                If drForecast.Length > 0 Then iForecast = drForecast(0)("Forecast")

                                If j = 1 Then
                                    If iIndex = 0 Then
                                        objOutput(i, 1) = "=INT((" & CInt(iForecast / 4).ToString & ") * C" & (iRow + i).ToString & ")"
                                        'objOutput(i, 9) = "=INT((" & iForecast.ToString & " / 4) * C" & (iRow + i).ToString & ")"
                                        objOutput(i, 9) = drData(0)("Daily")
                                    ElseIf iIndex = 1 Then
                                        objOutput(i, 1) = "=INT(" & iForecast.ToString & " * C" & (iRow + i).ToString & ")"
                                        'objOutput(i, 9) = "=INT(" & iForecast.ToString & " * C" & (iRow + i).ToString & ")"
                                        objOutput(i, 9) = drData(0)("Weekly")
                                    Else
                                        objOutput(i, 1) = "=INT(" & iForecast.ToString & " * C" & (iRow + i).ToString & ")"
                                        'objOutput(i, 9) = "=INT((" & iForecast.ToString & " * 4) * C" & (iRow + i).ToString & ")"
                                        objOutput(i, 9) = drData(0)("Monthly")
                                    End If
                                End If

                                objOutput(i, j + 2) = CInt(drData(0)("Qty"))
                            Else
                                If ds.Tables("Forecast Data").Select("Model_ID = " & drModels("Model_ID")).Length > 0 Then iForecast = ds.Tables("Forecast Data").Select("Model_ID = " & drModels("Model_ID"))(0)("Forecast")

                                If j = 1 Then
                                    If iIndex = 0 Then
                                        objOutput(i, 1) = "=INT((" & CInt(iForecast / 4).ToString & ") * C" & (iRow + i).ToString & ")"
                                        'objOutput(i, 9) = "=INT((" & iForecast.ToString & " / 4) * C" & (iRow + i).ToString & ")"
                                        objOutput(i, 9) = drData(0)("Daily")
                                    ElseIf iIndex = 1 Then
                                        objOutput(i, 1) = "=INT(" & iForecast.ToString & " * C" & (iRow + i).ToString & ")"
                                        'objOutput(i, 9) = "=INT(" & iForecast.ToString & " * C" & (iRow + i).ToString & ")"
                                        objOutput(i, 9) = drData(0)("Weekly")
                                    Else
                                        objOutput(i, 1) = "=INT(" & iForecast.ToString & " * C" & (iRow + i).ToString & ")"
                                        'objOutput(i, 9) = "=INT((" & iForecast.ToString & " * 4) * C" & (iRow + i).ToString & ")"
                                        objOutput(i, 9) = drData(0)("Monthly")
                                    End If
                                End If

                                objOutput(i, j + 2) = 0
                            End If
                        Next j

                        objOutput(i, 8) = "=(D" & (iRow + i).ToString & " * C" & (iRow + i).ToString & ") + (E" & (iRow + i).ToString & " * C" & (iRow + i).ToString & ") + (F" & (iRow + i).ToString & " * 0.95) + G" & (iRow + i).ToString & " + H" & (iRow + i).ToString
                        objOutput(i, 10) = "=J" & (iRow + i).ToString & " - B" & (iRow + i).ToString

                        'Hold
                        If iIndex = 0 Then
                            iHold = dtData.Select("Model_ID = " & drModels("Model_ID"))(0)("Hold")
                            objOutput(i, 11) = CInt(iHold)

                            iAWB = 0
                            iSA = 0

                            drAWB = ds.Tables("Awaiting Billing Data").Select("[Model ID] = " & drModels("Model_ID"))

                            If drAWB.Length > 0 Then iAWB = drAWB(0)("AWB")

                            drSA = ds.Tables("SA Data").Select("[Model ID] = " & drModels("Model_ID"))

                            If drSA.Length > 0 Then iSA = drSA(0)("SA")

                            iTotalWIP = 0
                            drTotalWIP = ds.Tables("Total WIP Data").Select("[Model ID] = " + drModels("Model_ID").ToString())

                            If drTotalWIP.Length > 0 Then iTotalWIP = drTotalWIP(0)("WIP Count")

                            objOutput(i, 12) = Math.Max(0, iAWB - iHold - iSA)
                            'objOutput(i, 12) = Math.Max(0, iAWB - iSA)
                        End If
                    Next drModels

                    objSheet.Range("A" & iRow.ToString & ":M" & (iRow + i).ToString).Value = objOutput

                    With objSheet.Range("A" & iRow.ToString & ":M" & (iRow + i).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Regular"
                        .Size = sngFontSize
                    End With

                    objSheet.Range("A" & (iRow + i + 1).ToString & ":A" & (iRow + i + 1).ToString).Value = "Total"
                    objSheet.Range("B" & (iRow + i + 1).ToString & ":B" & (iRow + i + 1).ToString).Value = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
                    objSheet.Range("D" & (iRow + i + 1).ToString & ":K" & (iRow + i + 1).ToString).Value = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"

                    If iIndex = 0 Then
                        objSheet.Range("L" & (iRow + i + 1).ToString & ":M" & (iRow + i + 1).ToString).Value = "=SUM(R[-" & (i + 1).ToString & "]C:R[-1]C)"
                    End If

                    With objSheet.Range("A" & (iRow + i + 1).ToString & ":M" & (iRow + i + 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = sngFontSize
                    End With

                    If iIndex = 0 Then
                        objExcel.Range("A" & (iRow - 1).ToString & ":M" & (iRow + i + 1).ToString).Select()
                    Else
                        objExcel.Range("A" & (iRow - 1).ToString & ":K" & (iRow + i + 1).ToString).Select()
                    End If

                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For j = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(j))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next j

                    'Draw a heavier border at the bottom of header row and last row of data (before totals)
                    If iIndex = 0 Then
                        objExcel.Range("A" & (iRow - 1).ToString & ":M" & (iRow - 1).ToString).Select()
                    Else
                        objExcel.Range("A" & (iRow - 1).ToString & ":K" & (iRow - 1).ToString).Select()
                    End If

                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlMedium
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With

                    If iIndex = 0 Then
                        objExcel.Range("A" & (iRow + i).ToString & ":M" & (iRow + i).ToString).Select()
                    Else
                        objExcel.Range("A" & (iRow + i).ToString & ":K" & (iRow + i).ToString).Select()
                    End If

                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlMedium
                        .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With

                    'Draw a heavier border at the bottom of the data 
                    'objExcel.Range("A" & (iRow + i + 1).ToString & ":K" & (iRow + i + 1).ToString).Select()

                    'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    '    .LineStyle = Excel.XlLineStyle.xlContinuous
                    '    .Weight = Excel.XlBorderWeight.xlThick
                    '    .ColorIndex = 25
                    'End With

                    'Insert page breaks after the first and second reports so all the reports will print on separate pages.
                    If iIndex < 2 Then objSheet.Range("A" & (iRow + i + 2).ToString & ":A" & (iRow + i + 2).ToString).PageBreak = 1

                    iRow += i + 2
                    i = -1
                Next iIndex

                'Draw a heavier border on the right side
                'objExcel.Range("K1:K" & (iRow - 1).ToString).Select()

                'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                '    .LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Weight = Excel.XlBorderWeight.xlThick
                '    .ColorIndex = 25
                'End With

                'Adjust column widths
                For i = 0 To 10
                    If i = 0 Then
                        objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 20
                        'ElseIf i = 2 Then
                        '    objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 3
                    Else
                        objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 9
                    End If
                Next i

                'Set page orientation
                objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                objSheet.PageSetup.RightMargin = 4
                objSheet.PageSetup.LeftMargin = 4

                'Set zoom
                objExcel.ActiveWindow.Zoom = 90

                'Move selection outside the data region 
                objExcel.Range("M2:M2").Select()

                'Delete unused worksheets
                If objWorkbook.Sheets.Count > 1 Then
                    For i = objWorkbook.Sheets.Count To 2 Step -1
                        objWorkbook.Sheets("Sheet" & i.ToString).Delete()
                    Next i
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dtData)
                Me.DisposeDT(dtGoal)
                Me.DisposeDT(dtHoldAndAWAP)
                Me.DisposeDT(dtShipDaily)
                Me.DisposeDT(dtShipWeekly)
                Me.DisposeDT(dtShipMonthly)
                Me.DisposeDT(dtModels)

                System.Windows.Forms.Application.DoEvents()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*******************************************************************
        Private Function GetMsgShipQty(ByVal iLoc_ID As Integer, _
                                       ByVal strStartDate As String, _
                                       ByVal strEndDate As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Model_ID, count(*) as Qty FROM tdevice  " & Environment.NewLine
                strSql &= "WHERE loc_id = " & iLoc_ID & " AND Ship_id <> 9999919 " & Environment.NewLine
                strSql &= "AND Device_ShipWorkDate  >= '" & strStartDate & "' AND Device_ShipWorkDate  <= '" & strEndDate & "' " & Environment.NewLine
                strSql &= "GROUP BY Model_ID " & Environment.NewLine
                strSql &= "ORDER BY Model_ID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Private Function GetDistinctModelAndYieldPercent(ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String
            Dim dtShip As DataTable
            Dim dbReturnVal As Double = 0.0
            Dim dtModel As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT DISTINCT tdevice.Model_ID, tmodel.Model_Desc as Model, 0.0 as Yield" & Environment.NewLine
                strSql &= "FROM tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & " and tmessdata.wipowner_id in (1, 2, 3, 4, 6, 8) " & Environment.NewLine
                strSql &= "AND tdevice.model_id <> 289" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID,tmessdata.wipowner_id " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT DISTINCT tdevice.Model_ID, tmodel.Model_Desc as Model, 0.0 as Yield" & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID  " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & " and tmessdata.wipowner_id in (5) " & Environment.NewLine
                strSql &= "AND Ship_id <> 9999919 " & Environment.NewLine
                strSql &= "AND tdevice.model_id <> 289" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID,tmessdata.wipowner_id " & Environment.NewLine
                strSql &= "ORDER BY Model"
                dtModel = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtModel.Rows
                    strSql = "SELECT * FROM tdevice  " & Environment.NewLine
                    strSql &= "WHERE loc_id = " & iLoc_ID & " AND Model_ID = " & R1("Model_ID") & Environment.NewLine '& " AND Ship_id <> 9999919 " & Environment.NewLine
                    strSql &= " AND Device_ShipWorkDate BETWEEN DATE_SUB(NOW(), INTERVAL 28 DAY) AND NOW()" & Environment.NewLine
                    dtShip = Me._objDataProc.GetDataTable(strSql)

                    If dtShip.Rows.Count > 0 Then
                        dbReturnVal = Format((dtShip.Rows.Count - dtShip.Select("Ship_id = 9999919").Length) / dtShip.Rows.Count, "###.00")
                    End If

                    R1.BeginEdit()
                    If (dbReturnVal * 100) > 100 Then
                        R1("Yield") = 1
                    Else
                        R1("Yield") = dbReturnVal
                    End If
                    R1.EndEdit()

                    dbReturnVal = 0.0
                Next R1

                dtModel.AcceptChanges()

                Return dtModel
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dtShip)
            End Try
        End Function

        '*******************************************************************
        Public Function CreateWeeklyShipmentDetail(ByVal iLoc_ID As Integer) As Integer
            Const sngFontSize As Single = 9

            Dim strSql As String
            Dim dtData, dtGoal, dtYield As DataTable
            Dim drData, drAWB(), drSA(), drHold(), drYield(), drTotalWIP() As DataRow
            Dim iRow As Integer = 1
            Dim i As Integer = 0
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strHeaders() As String = {"Model", "AMS Total" & ControlChars.Lf & "Weekly" & ControlChars.Lf & "Need", "Yield", "AMS" & ControlChars.Lf & "Weekly" & ControlChars.Lf & "Good" & ControlChars.Lf & "Need", "Hold", "Current On-" & ControlChars.Lf & "Hand", "AWP", "Net Current" & ControlChars.Lf & "On-Hand" & ControlChars.Lf & "Minus" & ControlChars.Lf & "Fallout", "DOH" & ControlChars.Lf & "Workable", "Weekly" & ControlChars.Lf & "Goal" & ControlChars.Lf & "Prob.", "Est'd." & ControlChars.Lf & "Weekly" & ControlChars.Lf & "Actual" & ControlChars.Lf & "Total", "Est'd." & ControlChars.Lf & "Weekly" & ControlChars.Lf & "Actual" & ControlChars.Lf & "Good", "Variance" & ControlChars.Lf & "to Good" & ControlChars.Lf & "Goal"}
            Dim strHeader As String
            Dim iIndex, j, iHold, iAWB, iSA, iTotalWIP, iGoal As Integer
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}
            Dim ds As DataSet
            Dim dblYield As Double
            Dim strDateTimeStamp As String = ""

            Try
                ds = New DataSet("Other Data")

                'Messaging Goal
                dtGoal = Me.GetMsgGoal

                'Data
                strSql = "SELECT tdevice.Model_ID, tmodel.Model_Desc as Model, count(*) as Qty, 0 as Goal" & Environment.NewLine
                strSql &= "FROM production.tdevice" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & " and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '') " & Environment.NewLine
                strSql &= "AND tdevice.model_id <> 289" & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID" & Environment.NewLine
                strSql &= "ORDER BY Model"

                dtData = Me._objDataProc.GetDataTable(strSql)

                For Each drData In dtData.Rows
                    If dtGoal.Rows.Count > 0 Then
                        If dtGoal.Select("Model_ID = " & drData("Model_ID")).Length > 0 Then
                            drData("Goal") = dtGoal.Select("Model_ID = " & drData("Model_ID"))(0)("forecast")
                        End If
                    End If
                Next drData

                dtData.TableName = "Model Data"
                ds.Tables.Add(dtData)

                dtYield = Me.GetDistinctModelAndYieldPercent(iLoc_ID)

                dtYield.TableName = "Yield Data"
                ds.Tables.Add(dtYield)

                GetPartsData(ds)
                'GeForecastData(ds)
                GetForecastAWBURData(ds)
                GetSAData(ds)
                GetHoldData(ds)
                GetTotalWIPData(ds)
                GetAwaitingBillingData(ds)

                strDateTimeStamp = GetDateTimeStamp()

                'Model
                'Qty
                'Goal

                'Generic.CreateExelReport(dtData, 1, , 1, , , , "B")

                'Prepare report
                objExcel = New Excel.Application()
                objExcel.Application.DisplayAlerts = False
                objWorkbook = objExcel.Workbooks.Add
                objSheet = objWorkbook.Sheets("Sheet1")
                objExcel.Visible = True
                'objSheet.Activate()
                objSheet.Name = "AMS Est. Weekly Shipment Detail"

                objSheet.Range("A1:A" & (dtData.Rows.Count + 5).ToString).NumberFormat = "@"
                objSheet.Range("B1:B" & (dtData.Rows.Count + 5)).NumberFormat = "#,##0;[Red](#,##0)"
                objSheet.Range("C1:C" & (dtData.Rows.Count + 5)).NumberFormat = "#,##0%;[Red](#,##0%)"
                objSheet.Range("D1:H" & (dtData.Rows.Count + 5)).NumberFormat = "#,##0;[Red](#,##0)"
                objSheet.Range("I1:I" & (dtData.Rows.Count + 5)).NumberFormat = "#,##0.0;[Red](#,##0.0)"
                objSheet.Range("J1:J" & (dtData.Rows.Count + 5)).NumberFormat = "#,##0%;[Red](#,##0%)"
                objSheet.Range("K1:M" & (dtData.Rows.Count + 5)).NumberFormat = "#,##0;[Red](#,##0)"

                objSheet.Range("A1", "M1").Merge()
                objSheet.Range("A1:A1").Value = "Snap-Shot AMS Estimated Weekly Shipment Detail"
                objSheet.Range("A1:A1").HorizontalAlignment = Excel.Constants.xlCenter

                With objSheet.Range("A1:A1").Font
                    .Name = "Arial"
                    .FontStyle = "Bold"
                    .Size = 12
                    .Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
                    .ColorIndex = 25
                End With

                objSheet.Range("A2:A2").Value = strDateTimeStamp
                objSheet.Range("A2:A2").HorizontalAlignment = Excel.Constants.xlLeft

                With objSheet.Range("A2:A2").Font
                    .Name = "Arial"
                    .FontStyle = "Regular"
                    .Size = 9
                End With

                i = 0
                iRow = 4

                'Print headers
                For Each strHeader In strHeaders
                    i += 1

                    objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).Value = strHeader
                    objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

                    With objSheet.Range(Chr(65 + i - 1) & iRow.ToString & ":" & Chr(65 + i - 1) & iRow.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = sngFontSize
                    End With
                Next strHeader

                For Each drData In dtData.Rows
                    iRow += 1

                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = drData("Model")

                    iGoal = 0

                    If ds.Tables("Weekly Forecast Data").Select("Model_ID = " & drData("Model_ID").ToString()).Length > 0 Then iGoal = ds.Tables("Weekly Forecast Data").Select("Model_ID = " + drData("Model_ID").ToString())(0)("forecast")

                    objSheet.Range("B" + iRow.ToString(), "B" + iRow.ToString()).Value = iGoal

                    dblYield = 0

                    drYield = ds.Tables("Yield Data").Select("[Model_ID] = " & drData("Model_ID").ToString())

                    If drYield.Length > 0 Then dblYield = drYield(0)("Yield")

                    objSheet.Range("C" & iRow.ToString(), "C" & iRow.ToString()).Value = dblYield

                    objSheet.Range("D" & iRow.ToString(), "D" & iRow.ToString()).Value = "=B" + iRow.ToString() + " * C" & iRow.ToString()

                    iHold = 0

                    drHold = ds.Tables("Hold Data").Select("[Model ID] = " & drData("Model_ID").ToString())

                    If drHold.Length > 0 Then iHold = CInt(drHold(0)("Qty"))

                    objSheet.Range("E" & iRow.ToString(), "E" & iRow.ToString()).Value = CInt(iHold)
                    objSheet.Range("F" & iRow.ToString(), "F" & iRow.ToString()).Value = CInt(drData("Qty") - iHold)
                    'objSheet.Range("G" & iRow.ToString(), "G" & iRow.ToString()).Value = "=F" & iRow.ToString() & " - E" & iRow.ToString()

                    iAWB = 0
                    iSA = 0

                    'drAWB = ds.Tables("Forecast AWB Data").Select("[Model ID] = " & drData("Model_ID").ToString())
                    drAWB = ds.Tables("Awaiting Billing Data").Select("[Model ID] = " & drData("Model_ID").ToString())

                    If drAWB.Length > 0 Then iAWB = drAWB(0)("AWB")

                    drSA = ds.Tables("SA Data").Select("[Model ID] = " & drData("Model_ID").ToString())

                    If drSA.Length > 0 Then iSA = drSA(0)("SA")

                    iTotalWIP = 0
                    drTotalWIP = ds.Tables("Total WIP Data").Select("[Model ID] = " + drData("Model_ID").ToString())

                    If drTotalWIP.Length > 0 Then iTotalWIP = drTotalWIP(0)("WIP Count")

                    'objSheet.Range("G" + iRow.ToString(), "G" + iRow.ToString()).Value = Math.Max(0, iTotalWIP - (iHold + iGoal))
                    'objSheet.Range("H" & iRow.ToString(), "H" & iRow.ToString()).Value = Math.Max(0, Math.Max(0, iAWB - iSA) - iHold)
                    objSheet.Range("G" & iRow.ToString(), "G" & iRow.ToString()).Value = Math.Max(0, iAWB - iHold - iSA) 'iAWB - iHold = Actual AWB
                    'objSheet.Range("I" & iRow.ToString(), "I" & iRow.ToString()).Value = "=(E" & iRow.ToString() & " - F" & iRow.ToString() & " - G" & iRow.ToString() & ") * C" & iRow.ToString()
                    objSheet.Range("H" & iRow.ToString(), "H" & iRow.ToString()).Value = "=MAX(0, F" & iRow.ToString() & " - G" & iRow.ToString() & ") * C" & iRow.ToString()
                    objSheet.Range("I" & iRow.ToString(), "I" & iRow.ToString()).Value = "=IF(D" & iRow.ToString() & " = 0, 0, H" & iRow.ToString() & " / (D" & iRow.ToString() & " / 4))"
                    objSheet.Range("J" & iRow.ToString(), "J" & iRow.ToString()).Value = "=I" & iRow.ToString() & " / 3"
                    objSheet.Range("K" & iRow.ToString(), "K" & iRow.ToString()).Value = "=MIN(J" & iRow.ToString() & ", 1) * B" & iRow.ToString()
                    objSheet.Range("L" & iRow.ToString(), "L" & iRow.ToString()).Value = "=MIN(J" & iRow.ToString() & ", 1) * D" & iRow.ToString()
                    objSheet.Range("M" & iRow.ToString(), "M" & iRow.ToString()).Value = "=L" & iRow.ToString() & " - D" & iRow.ToString()

                    With objSheet.Range("A" & iRow.ToString & ":N" & iRow.ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Regular"
                        .Size = sngFontSize
                    End With
                Next drData

                iRow += 1

                objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).Value = "=SUM(R[-" & (dtData.Rows.Count).ToString & "]C:R[-1]C)"
                objSheet.Range("B" & iRow.ToString & ":B" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlRight
                objSheet.Range("D" & iRow.ToString & ":H" & iRow.ToString).Value = "=SUM(R[-" & (dtData.Rows.Count).ToString & "]C:R[-1]C)"
                objSheet.Range("D" & iRow.ToString & ":I" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlRight
                objSheet.Range("I" & iRow.ToString(), "I" & iRow.ToString()).Value = "=IF(D" & iRow.ToString() & " = 0, 0, H" & iRow.ToString() & " / (D" & iRow.ToString() & " / 4))"
                objSheet.Range("K" & iRow.ToString & ":K" & iRow.ToString).Value = "=SUM(R[-" & (dtData.Rows.Count).ToString & "]C:R[-1]C)"
                objSheet.Range("M" & iRow.ToString & ":M" & iRow.ToString).Value = "=SUM(R[-" & (dtData.Rows.Count).ToString & "]C:R[-1]C)"
                objSheet.Range("J" & iRow.ToString & ":M" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlRight

                iRow += 1

                objSheet.Range("A" & iRow.ToString, "K" & iRow.ToString).Merge()
                objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Estimated Ship Quantity For The Week (Subject to Receipts, Yield and Parts Availability)"
                objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Range("L" & iRow.ToString & ":L" & iRow.ToString).Value = "=SUM(R[-" & (dtData.Rows.Count + 1).ToString & "]C:R[-2]C)"
                objSheet.Range("L" & iRow.ToString & ":L" & iRow.ToString).HorizontalAlignment = Excel.Constants.xlRight

                With objSheet.Range("A" & (iRow - 1).ToString & ":M" & iRow.ToString).Font
                    .Name = "Arial"
                    .FontStyle = "Regular"
                    .Size = sngFontSize
                    .ColorIndex = 25
                End With

                'Adjust column widths
                For i = 0 To strHeaders.Length
                    If i = 0 Then
                        objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 18
                    Else
                        objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 8
                    End If
                Next i

                'Print grid lines
                objExcel.Range("A4:M" & iRow.ToString).Select()
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                For j = 0 To xlBI.Length - 1
                    With objExcel.Selection.Borders(xlBI(j))
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThin
                        .ColorIndex = Excel.Constants.xlAutomatic
                    End With
                Next j

                'Draw a heavier border at the bottom of header row and last row of data (before totals)
                objExcel.Range("A4:M4").Select()

                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                objExcel.Range("A" & (iRow - 2).ToString & ":M" & (iRow - 2).ToString).Select()

                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlMedium
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With

                'Set page orientation
                objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                objSheet.PageSetup.RightMargin = 2
                objSheet.PageSetup.LeftMargin = 2

                'Move selection outside the data region 
                objExcel.Range("A2:A2").Select()

                'Delete unused worksheets
                If objWorkbook.Sheets.Count > 1 Then
                    For i = objWorkbook.Sheets.Count To 2 Step -1
                        objWorkbook.Sheets("Sheet" & i.ToString).Delete()
                    Next i
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dtData)

                System.Windows.Forms.Application.DoEvents()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*******************************************************************
        Private Sub GetForecastAWBURData(ByRef ds As DataSet)
            Dim strSQL As String
            Dim iMaxForecastWeeks, iStartYearWeek, iFinalYearWeek As Integer
            Dim iStartWeek As Integer = 1
            Dim iStartYear As Integer = DateTime.Now.Year
            Dim dr As DataRow
            Dim dt As DataTable

            Try
                strSQL = "SELECT MaxForecastWeeks" & Environment.NewLine
                strSQL &= "FROM cogs.tmaxforecastweeks" & Environment.NewLine
                strSQL &= "WHERE Cust_ID = 14" & Environment.NewLine
                strSQL &= "AND Facility_ID = 1"

                iMaxForecastWeeks = Me._objDataProc.GetIntValue(strSQL)

                strSQL = "SELECT StartWeek, StartYear" & Environment.NewLine
                strSQL &= "FROM cogs.tforecaststart"

                dr = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(dr) Then
                    iStartWeek = Convert.ToInt32(dr(0))
                    iStartYear = Convert.ToInt32(dr(1))
                End If

                iStartYearWeek = (iStartYear * 100) + iStartWeek

                'DATE_ADD('" + iStartYear.ToString() + "-01-04', INTERVAL ((" + iStartWeek.ToString() + " - 1) * 7 + ( 1 - DATE_FORMAT('" + iStartYear.ToString() + "-01-04','%w'))) DAY) 
                'returns the date of the Monday (MySQL day 1, see "(1 - DATE_FORMAT(" in the query) of the start week and year.  Add 7 * iMaxForecastWeeks to get the Monday of the week 
                'of the final forecast week.  From that, the week/year combination of the final week can be obtained.
                'Use 4-January of this year as a base because that date is ALWAYS in week 1 of the year, whereas 1-January might not be.
                strSQL = "SELECT YEARWEEK(DATE_ADD(DATE_ADD('" + iStartYear.ToString() + "-01-04', INTERVAL ((" + iStartWeek.ToString() + " - 1) * 7 + ( 1 - DATE_FORMAT('" + iStartYear.ToString() + "-01-04','%w'))) DAY), INTERVAL (" + iMaxForecastWeeks.ToString() + " * 7) DAY))" & Environment.NewLine

                iFinalYearWeek = Me._objDataProc.GetIntValue(strSQL)

                strSQL = "SELECT Model_ID, AVG(forecast) AS forecast" + Environment.NewLine
                strSQL &= "FROM cogs.tmessaging_forecast" & Environment.NewLine
                strSQL &= "WHERE (Year * 100) + yearweek BETWEEN " & iStartYearWeek.ToString() & " AND " & iFinalYearWeek.ToString() & Environment.NewLine
                strSQL &= "AND forecast > 0" & Environment.NewLine
                strSQL &= "AND facility_id = 1" & Environment.NewLine
                strSQL &= "GROUP BY model_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Forecast Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT model_id AS 'Model ID', SUM(forecast) AS Forecast, SUM(awaitbill) AS AWB" & Environment.NewLine
                strSQL &= "FROM cogs.tmessaging_forecast" & Environment.NewLine
                strSQL &= "WHERE (Year * 100) + yearweek BETWEEN " & iStartYearWeek.ToString() & " AND " & iFinalYearWeek.ToString() & Environment.NewLine
                strSQL &= "AND facility_id = 1" & Environment.NewLine
                strSQL &= "GROUP BY model_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Forecast AWB Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT Model_ID, forecast AS forecast" + Environment.NewLine
                strSQL &= "FROM cogs.tmessaging_forecast" & Environment.NewLine
                strSQL &= "WHERE (Year * 100) + yearweek = (YEAR(NOW()) * 100) + WEEK(NOW(), 3)" & Environment.NewLine
                strSQL &= "AND facility_id = 1"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Weekly Forecast Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT Model_ID, SUM(forecast) AS forecast" + Environment.NewLine
                strSQL &= "FROM cogs.tmessaging_forecast" & Environment.NewLine
                strSQL &= "WHERE (Year * 100) + yearweek BETWEEN (YEAR(DATE_SUB(NOW(), INTERVAL 21 DAY)) * 100) + WEEK(DATE_SUB(NOW(), INTERVAL 21 DAY), 3) AND (YEAR(NOW()) * 100) + WEEK(NOW(), 3)" & Environment.NewLine
                strSQL &= "AND facility_id = 1" & Environment.NewLine
                strSQL &= "GROUP BY model_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "4-Week Forecast Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT model_id AS 'Model ID', SUM(IF(use_initial_ur = 1, initial_ur, calc_ur)) AS 'DBR UR'" & Environment.NewLine
                strSQL &= "FROM cogs.tmain_cmpur" & Environment.NewLine
                strSQL &= "WHERE part_number IN ('S25', 'S26', 'S27')" & Environment.NewLine
                strSQL &= "AND facility_id = 1" & Environment.NewLine
                strSQL &= "AND cust_id  = 14" & Environment.NewLine
                strSQL += "GROUP BY model_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "DBR UR Data"
                    ds.Tables.Add(dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Sub GetPartsData(ByRef ds As DataSet)
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT model_id AS 'Model ID', part_number AS 'Part Number', IF(use_initial_ur = 1, initial_ur, calc_ur) AS UR" & Environment.NewLine
                strSQL &= "FROM cogs.tmain_cmpur" & Environment.NewLine
                strSQL &= "WHERE make_inactive = 0" & Environment.NewLine
                strSQL &= "AND flg_emergency = 0" & Environment.NewLine
                strSQL &= "AND LENGTH(part_number) > 4" & Environment.NewLine
                strSQL &= "AND cust_id = 14" & Environment.NewLine
                strSQL &= "AND facility_id = 1" & Environment.NewLine
                strSQL &= "ORDER BY model_id, part_number"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Parts Data"
                    ds.Tables.Add(dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Function CreateSATable() As DataTable
            Dim dt As DataTable

            Try
                dt = New DataTable("SA Data")

                dt.Columns.Add(New DataColumn("Model ID", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("SA", System.Type.GetType("System.Int32")))

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        Private Sub GetSAData(ByVal ds As DataSet)
            Dim strSQL, strPartNumber As String
            Dim iModelID, iSA As Integer
            Dim dblUR, dblBinCount, dblCageCount, dblRVCount As Double
            Dim dtParts, dtSA As DataTable
            Dim drNew, drUR(), drData, dr, drParts As DataRow

            Try
                dtSA = CreateSATable()

                For Each drData In ds.Tables("Model Data").Rows
                    iModelID = Convert.ToInt32(drData("Model_ID"))

                    strSQL = "SELECT part_number AS 'Part Number'" & Environment.NewLine
                    strSQL &= "FROM cogs.tmain_cmpur" & Environment.NewLine
                    strSQL &= "WHERE make_inactive = 0" & Environment.NewLine
                    strSQL &= "AND flg_emergency = 0" & Environment.NewLine
                    strSQL &= "AND LENGTH(part_number) > 4" & Environment.NewLine
                    strSQL &= "AND model_id = " & iModelID.ToString() & Environment.NewLine
                    strSQL &= "AND facility_id = 1" & Environment.NewLine
                    strSQL &= "ORDER BY part_number"

                    dtParts = Me._objDataProc.GetDataTable(strSQL)

                    If Not IsNothing(dtParts) Then
                        drNew = dtSA.NewRow()

                        drNew("Model ID") = iModelID
                        iSA = 99999

                        For Each drParts In dtParts.Rows
                            strPartNumber = drParts("Part Number").ToString.ToUpper
                            dblUR = 0
                            dblBinCount = 0
                            dblCageCount = 0
                            dblRVCount = 0

                            drUR = ds.Tables("Parts Data").Select("[Model ID] = " + iModelID.ToString() + " AND [Part Number] = '" + strPartNumber + "'")

                            If drUR.Length > 0 Then
                                If Not IsDBNull(drUR(0)("UR")) Then dblUR = Convert.ToDouble(drUR(0)("UR"))
                            End If

                            strSQL = "SELECT SUM(Quantity)" & Environment.NewLine
                            strSQL &= "FROM cogs.tcogs_bincontent" & Environment.NewLine
                            strSQL &= "WHERE Bin_Location LIKE 'SFM%'" & Environment.NewLine
                            strSQL &= "AND Item_Number = '" & strPartNumber & "'"

                            dr = Me._objDataProc.GetDataRow(strSQL)

                            If Not (IsNothing(dr)) Then
                                If Not IsDBNull(dr(0)) Then dblBinCount = Convert.ToDouble(dr(0))
                            End If

                            strSQL = "SELECT SUM(Quantity)" & Environment.NewLine
                            strSQL &= "FROM cogs.tcogs_bincontent" & Environment.NewLine
                            strSQL &= "WHERE Bin_Location like 'C-%'" & Environment.NewLine
                            strSQL &= "AND bin_location NOT LIKE 'C-SCRAP%'" & Environment.NewLine
                            strSQL &= "AND Item_Number = '" & strPartNumber & "'"

                            dr = Me._objDataProc.GetDataRow(strSQL)

                            If Not (IsNothing(dr)) Then
                                If Not IsDBNull(dr(0)) Then dblCageCount = Convert.ToDouble(dr(0))
                            End If

                            strSQL = "SELECT SUM(Quantity)" & Environment.NewLine
                            strSQL &= "FROM cogs.tcogs_bincontent" & Environment.NewLine
                            strSQL &= "WHERE Item_Number = '" & strPartNumber & "_RV'"

                            dr = Me._objDataProc.GetDataRow(strSQL)

                            If Not (IsNothing(dr)) Then
                                If Not IsDBNull(dr(0)) Then dblRVCount = Convert.ToDouble(dr(0))
                            End If

                            GetSharedPartsData(ds, iModelID, strPartNumber, dblBinCount, dblCageCount, dblRVCount)

                            If dblUR <> 0 Then iSA = Math.Min(iSA, Convert.ToInt32((dblBinCount + dblCageCount + dblRVCount) / dblUR))
                        Next drParts

                        drNew("SA") = iSA

                        dtSA.Rows.Add(drNew)
                    End If
                Next drData

                ds.Tables.Add(dtSA)

            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing

                If Not IsNothing(dtParts) Then
                    dtParts.Dispose()
                    dtParts = Nothing
                End If

                If Not IsNothing(dtSA) Then
                    dtSA.Dispose()
                    dtSA = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Sub GetSharedPartsData(ByVal ds As DataSet, ByVal iModelID As Integer, ByVal strPartNumber As String, ByRef dblBinCount As Double, ByRef dblCageCount As Double, ByRef dblRVCount As Double)
            Dim drModels(), drForecast(), drDBRUR() As DataRow
            Dim strModelIDsIn As String = ""
            Dim i, j As Integer
            Dim dblModelForecast, dblTotalForecast, dblForecastRatio, dblDBRUR As Double

            Try
                drModels = ds.Tables("Parts Data").Select("[Part Number] = '" + strPartNumber + "'")

                If drModels.Length > 1 Then 'Shared part
                    For i = 0 To drModels.Length - 1
                        If strModelIDsIn.Length > 0 Then strModelIDsIn &= ", "

                        strModelIDsIn &= drModels(i)("Model ID").ToString
                    Next i

                    If strModelIDsIn.Length > 0 Then
                        dblModelForecast = 0
                        dblTotalForecast = 0
                        dblForecastRatio = 1
                        drForecast = ds.Tables("Forecast AWB Data").Select("[Model ID] IN (" + strModelIDsIn + ")")
                        drDBRUR = ds.Tables("DBR UR Data").Select("[Model ID]  IN (" + strModelIDsIn + ")")

                        If drForecast.Length > 0 Then
                            For i = 0 To drForecast.Length - 1
                                dblDBRUR = 0

                                If drDBRUR.Length > 0 Then
                                    For j = 0 To drDBRUR.Length - 1
                                        If drDBRUR(j)("Model ID") = drForecast(i)("Model ID") Then
                                            dblDBRUR = drDBRUR(j)("DBR UR")

                                            Exit For
                                        End If
                                    Next j
                                End If

                                dblTotalForecast += (1 - dblDBRUR) * Convert.ToDouble(drForecast(i)("forecast"))

                                If drForecast(i)("Model ID") = iModelID Then dblModelForecast = (1 - dblDBRUR) * Convert.ToDouble(drForecast(i)("forecast"))
                            Next i
                        End If

                        If dblTotalForecast <> 0 Then dblForecastRatio = dblModelForecast / dblTotalForecast

                        dblBinCount *= dblForecastRatio
                        dblCageCount *= dblForecastRatio
                        dblRVCount *= dblForecastRatio
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************
        Private Sub GetHoldData(ByRef ds As DataSet)
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.Model_ID AS 'Model ID', COUNT(*) AS Qty" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmessdata B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSQL &= "WHERE A.loc_id = 19 AND B.wipowner_id = 6 " & Environment.NewLine
                strSQL &= "GROUP BY A.Model_ID" & Environment.NewLine
                strSQL &= "ORDER BY A.Model_ID"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Hold Data"
                    ds.Tables.Add(dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Sub GeForecastData(ByRef ds As DataSet)
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT Model_ID, forecast" & Environment.NewLine
                strSQL &= "FROM cogs.tmessaging_forecast" & Environment.NewLine
                strSQL &= "WHERE year = YEAR(NOW())" & Environment.NewLine
                strSQL &= "AND yearweek = WEEK(NOW(), 3)" & Environment.NewLine
                strSQL &= "AND facility_id = 1" & Environment.NewLine
                strSQL &= "ORDER BY Model_ID"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Forecast Data"
                    ds.Tables.Add(dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Sub GetTotalWIPData(ByRef ds As DataSet)
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT model_id AS 'Model ID', COUNT(device_id) AS 'WIP Count'" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= "WHERE loc_id = 19" & Environment.NewLine
                strSQL &= "AND (Device_DateShip IS NULL OR Device_DateShip = '0000-00-00 00:00:00' OR TRIM(Device_DateShip) = '')" & Environment.NewLine
                strSQL &= "GROUP BY model_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Total WIP Data"
                    ds.Tables.Add(dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Public Sub CreateSNCCFreqBaudChangesReport(ByVal iLocID As Integer)
            Const sngFontSize As Single = 10

            Dim strSQL As String
            Dim dt As DataTable
            Dim ds As DataSet
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim i, iRow, iIndex, j As Integer
            Dim objOutput(,) As Object
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Try
                ds = New DataSet("Report Data")

                strSQL = "SELECT A.device_id AS 'Device ID', A.device_oldsn AS 'Old SN', A.device_sn AS 'Current SN'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmessdata B ON B.device_id = A.device_id" & Environment.NewLine
                strSQL &= "WHERE DATE_FORMAT(B.sn_change_date, '%Y-%m-%d') = DATE_FORMAT(NOW(), '%Y-%m-%d')" & Environment.NewLine
                strSQL &= "AND A.loc_id = " & iLocID.ToString & Environment.NewLine
                strSQL &= "ORDER BY A.device_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "SN Data"
                    ds.Tables.Add(dt)
                End If

                strSQL = "SELECT A.device_id AS 'Device ID', IFNULL(A.capcode_old, '') AS 'Old Capcode', IFNULL(A.capcode, '') AS 'Current Capcode', IFNULL(B.freq_number, '') AS 'Old Frequency', IFNULL(C.freq_number, '') AS 'Current Frequency', IFNULL(D.baud_number, '') AS 'Old Baud', IFNULL(E.baud_number, '') AS 'Current Baud'" & Environment.NewLine
                strSQL &= "FROM production.tmessdata A" & Environment.NewLine
                strSQL &= "LEFT JOIN production.lfrequency B ON B.freq_id = A.freq_id_old" & Environment.NewLine
                strSQL &= "LEFT JOIN production.lfrequency C ON C.freq_id = A.freq_id" & Environment.NewLine
                strSQL &= "LEFT JOIN production.lbaud D ON D.baud_id = A.baud_id_old" & Environment.NewLine
                strSQL &= "LEFT JOIN production.lbaud E ON E.baud_id = A.baud_id" & Environment.NewLine
                'strSQL &= "WHERE DATE_FORMAT(A.capcode_change_date, '%Y-%m-%d') = '2008-05-20'" & Environment.NewLine
                'strSQL &= "OR DATE_FORMAT(A.freq_id_change_date, '%Y-%m-%d') = '2008-05-20'" & Environment.NewLine
                'strSQL &= "OR DATE_FORMAT(A.baud_id_change_date, '%Y-%m-%d') = '2008-05-20'" & Environment.NewLine
                strSQL &= "WHERE DATE_FORMAT(A.capcode_change_date, '%Y-%m-%d') = DATE_FORMAT(NOW(), '%Y-%m-%d')" & Environment.NewLine
                strSQL &= "OR DATE_FORMAT(A.freq_id_change_date, '%Y-%m-%d') = DATE_FORMAT(NOW(), '%Y-%m-%d')" & Environment.NewLine
                strSQL &= "OR DATE_FORMAT(A.baud_id_change_date, '%Y-%m-%d') = DATE_FORMAT(NOW(), '%Y-%m-%d')" & Environment.NewLine
                strSQL &= "ORDER BY A.device_id"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "CC, Freq, Baud Data"
                    ds.Tables.Add(dt)
                End If

                'Prepare report
                objExcel = New Excel.Application()
                objExcel.Application.DisplayAlerts = False
                objWorkbook = objExcel.Workbooks.Add
                objExcel.Visible = True

                For iIndex = 0 To ds.Tables.Count - 1
                    objSheet = objWorkbook.Sheets("Sheet" & (iIndex + 1).ToString)
                    'objSheet.Activate()
                    objSheet.Name = ds.Tables(iIndex).TableName

                    If ds.Tables(iIndex).Rows.Count > 0 Then
                        objSheet.Range("A1:" & Chr(65 + ds.Tables(iIndex).Columns.Count) & ds.Tables(iIndex).Rows.Count.ToString).NumberFormat = "@"

                        objSheet.Range("A1", Chr(65 + ds.Tables(iIndex).Columns.Count) & "1").Merge()
                        objSheet.Range("A1:A1").Value = ds.Tables(iIndex).TableName
                        objSheet.Range("A1:A1").HorizontalAlignment = Excel.Constants.xlCenter

                        With objSheet.Range("A1:A1").Font
                            .Name = "Arial"
                            .FontStyle = "Bold"
                            .Size = 14
                            .Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
                            .ColorIndex = 25
                        End With

                        iRow = 3

                        'Print headers
                        For i = 0 To ds.Tables(iIndex).Columns.Count - 1
                            objSheet.Range(Chr(65 + i) & iRow.ToString & ":" & Chr(65 + i) & iRow.ToString).Value = ds.Tables(iIndex).Columns(i).ColumnName
                            objSheet.Range(Chr(65 + i) & iRow.ToString & ":" & Chr(65 + i) & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter

                            With objSheet.Range(Chr(65 + i) & iRow.ToString & ":" & Chr(65 + i) & iRow.ToString).Font
                                .Name = "Arial"
                                .FontStyle = "Bold"
                                .Size = sngFontSize
                            End With
                        Next i

                        ReDim objOutput(ds.Tables(iIndex).Rows.Count - 1, ds.Tables(iIndex).Columns.Count - 1)

                        For i = 0 To objOutput.GetUpperBound(0)
                            For j = 0 To objOutput.GetUpperBound(1)
                                objOutput(i, j) = ds.Tables(iIndex).Rows(i)(j)
                            Next j
                        Next i

                        iRow += 1

                        objSheet.Range("A" & iRow.ToString & ":" & Chr(65 + ds.Tables(iIndex).Columns.Count - 1) & (iRow + ds.Tables(iIndex).Rows.Count - 1).ToString).Value = objOutput

                        With objSheet.Range("A" & iRow.ToString & ":" & Chr(65 + ds.Tables(iIndex).Columns.Count - 1) & (iRow + ds.Tables(iIndex).Rows.Count - 1).ToString).Font
                            .Name = "Arial"
                            .FontStyle = "Regular"
                            .Size = sngFontSize
                        End With

                        'Adjust column widths
                        For i = 0 To ds.Tables(iIndex).Columns.Count - 1
                            If i = 0 Then
                                objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 10
                            Else
                                objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 14
                            End If
                        Next i

                        'Print grid lines
                        objExcel.Range("A3:" & Chr(65 + ds.Tables(iIndex).Columns.Count - 1) & (iRow + ds.Tables(iIndex).Rows.Count - 1).ToString).Select()
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                        objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                        For j = 0 To xlBI.Length - 1
                            With objExcel.Selection.Borders(xlBI(j))
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThin
                                .ColorIndex = Excel.Constants.xlAutomatic
                            End With
                        Next j

                        'Draw a heavier border at the bottom of header row and last row of data (before totals)
                        objExcel.Range("A3:" & Chr(65 + ds.Tables(iIndex).Columns.Count - 1) & "3").Select()

                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With

                        objExcel.Range("A" & (iRow + ds.Tables(iIndex).Rows.Count - 1).ToString & ":" & Chr(65 + ds.Tables(iIndex).Columns.Count - 1) & (iRow + ds.Tables(iIndex).Rows.Count - 1).ToString).Select()

                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlMedium
                            .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                        End With
                    End If

                    'Set page orientation
                    objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait
                    objSheet.PageSetup.RightMargin = 4
                    objSheet.PageSetup.LeftMargin = 4

                    'Move selection outside the data region 
                    objExcel.Range("A2:A2").Select()
                Next iIndex

                'Delete unused worksheets
                If objWorkbook.Sheets.Count > 1 Then
                    For i = objWorkbook.Sheets.Count To 3 Step -1
                        objWorkbook.Sheets("Sheet" & i.ToString).Delete()
                    Next i
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Sub GetAwaitingBillingData(ByRef ds As DataSet)
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT B.Model_ID AS 'Model ID', COUNT(A.Device_ID) AS AWB" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSQL &= "WHERE B.Prod_ID = 1" & Environment.NewLine
                strSQL &= "AND (A.Device_DateBill IS NULL OR A.Device_DateBill = '0000-00-00' OR LENGTH(TRIM(A.Device_DateBill)) = 0)" & Environment.NewLine
                strSQL &= "AND (A.Device_DateShip IS NULL OR A.Device_DateShip = '0000-00-00' OR LENGTH(TRIM(A.Device_DateShip)) = 0)" & Environment.NewLine
                strSQL &= "GROUP BY A.Model_ID"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    dt.TableName = "Awaiting Billing Data"
                    ds.Tables.Add(dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************
        Private Function GetDateTimeStamp() As String
            Dim strSQL As String

            Try
                strSQL = "SELECT DATE_FORMAT(NOW(), '%b %e, %Y@%l:%i %p')"

                Return Me._objDataProc.GetSingletonString(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function CreateChangedSNCCFreqRpt(ByVal iLoc_ID As Integer, _
                                                 ByVal strFromDate As String, _
                                                 ByVal strToDate As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSQL = "SELECT tdevice.Device_ID, DATE_FORMAT(tdevice.Device_DateShip, '%T')  as 'Ship Time'" & Environment.NewLine
                strSQL &= ", Device_SN AS 'SN' " & Environment.NewLine
                strSQL &= ", IF( Device_OldSN IS NULL, '', Device_OldSN) AS 'Old SN' " & Environment.NewLine
                strSQL &= ", tmessdata.capcode as 'Capcode' " & Environment.NewLine
                strSQL &= ", IF (tmessdata.capcode_old IS NULL, '',  tmessdata.capcode_old) AS 'Old Capcode' " & Environment.NewLine
                strSQL &= ", A.freq_Number AS 'Freq' " & Environment.NewLine
                strSQL &= ", '' as Refreq " & Environment.NewLine
                strSQL &= ", IF(B.freq_Number IS NULL, '', B.freq_Number) AS 'Old Freq' " & Environment.NewLine
                strSQL &= ", IF(C.user_fullname IS NULL, '', C.user_fullname) AS 'SN User' " & Environment.NewLine
                strSQL &= ", IF(D.user_fullname IS NULL, '', D.user_fullname) AS 'Capcode User' " & Environment.NewLine
                strSQL &= ", IF(E.user_fullname IS NULL, '', E.user_fullname) AS 'Freq User' " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lfrequency A ON tmessdata.freq_id = A.freq_id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN lfrequency B ON tmessdata.freq_id_old = B.freq_id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN security.tusers C ON tmessdata.sn_change_userid = C.user_id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN security.tusers D ON tmessdata.capcode_change_userid = D.user_id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN security.tusers E ON tmessdata.freq_id_change_userid = E.user_id " & Environment.NewLine
                strSQL &= "WHERE loc_id = " & iLoc_ID & Environment.NewLine
                strSQL &= "AND Device_ShipWorkDate BETWEEN '" & strFromDate & "' " & Environment.NewLine
                strSQL &= "AND '" & strToDate & "' " & Environment.NewLine
                strSQL &= "AND (Device_OldSN IS NOT NULL OR tmessdata.capcode_old IS NOT NULL OR tmessdata.freq_id_old IS NOT NULL) " & Environment.NewLine
                strSQL &= "ORDER BY tdevice.Device_DateShip ASC"
                dt = Me._objDataProc.GetDataTable(strSQL)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    If Me.IsRefreqUnit(R1("Device_ID")) = True Then R1("Refreq") = "Yes"
                    R1.EndEdit()
                Next R1

                dt.Columns.Remove("Device_ID")
                dt.AcceptChanges()

                If dt.Rows.Count > 0 Then
                    Generic.CreateExelReport(dt, 1, , 1, , , , "K")
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*******************************************************************
        Public Function IsRefreqUnit(ByVal iDeviceID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevicebill " & Environment.NewLine
                strSQL &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSQL &= "AND Billcode_ID = 58" & Environment.NewLine

                If Me._objDataProc.GetIntValue(strSQL) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function GetAMSMessCustIDs() As String
            Dim dt As DataTable
            Dim strCustIDsArray As String()
            Dim i As Integer
            Dim strCustIDs As String = ""

            Try
                dt = ModManuf.GetExceptionCriteria("AMS_SHAREABLE_INVENTORY_CUSTOMERS")
                If dt.Rows.Count > 0 Then
                    strCustIDsArray = dt.Rows(0)("CustIDs").Split(",")
                    For i = 0 To strCustIDsArray.Length - 1
                        If strCustIDsArray(i).Trim.Length > 0 Then
                            If strCustIDs.Trim.Length > 0 Then strCustIDs &= ", "
                            strCustIDs &= strCustIDsArray(i).Trim
                        End If
                    Next i
                End If

                Return strCustIDs
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function RunMessMatrixReport(ByVal iCustIDs As String) As Integer
            Dim strSQL, strDateFr, strDateEnd, strToday As String
            Dim iNoOfWeeks As Integer = 6
            Dim i As Integer
            Dim ds As DataSet
            Dim dt, dt1 As DataTable


            Try
                '************************************
                'Define this week date range
                '************************************
                strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")
                strDateFr = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                strDateEnd = Format(DateAdd(DateInterval.Day, (6 * iNoOfWeeks), CDate(strDateFr)), "yyyy-MM-dd")
                '************************************


                MsgBox(strDateFr & Environment.NewLine & strDateEnd)
                Exit Function

                'strSQL = "SELECT  " & Environment.NewLine
                'strSQL &= "FROM tdevicebill " & Environment.NewLine
                'strSQL &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                'strSQL &= "AND Billcode_ID = 58" & Environment.NewLine

                'If Me._objDataProc.GetIntValue(strSQL) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function RunMessForcastVersusDockShip(ByVal booNoRpt As Boolean, ByVal booInclProduceWip As Boolean, ByVal booInclMonthData As Boolean) As DataTable
            Dim strSql, strToday, strCustIDs, strRptName As String
            Dim dtWkFC, dtMonFC, dtWkAct, dtMonAct, dtProduceWip As DataTable
            Dim dtWkSpecialShip, dtMonSpecialShip, dtTmp As DataTable
            Dim objMessMisc As New MessMisc()
            Dim drActMon, drActWk, drWkFc, drMonFc, drProdWip, drMissing(), filteredRows(), row, row2 As DataRow
            Dim col As DataColumn
            Dim i, j As Integer
            Dim arrReOrder() As Integer

            Try
                '************************************
                'Define this week date range
                '************************************
                strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")
                '************************************
                'Get Customer List
                '************************************
                strCustIDs = GetAMSMessCustIDs()
                '************************************
                'Get Forecast
                '************************************
                dtWkFC = GetAMSWkForecast(strCustIDs, strToday, False, False, , , , )
                Me.ApplyNewMethodWKFC(strCustIDs, strToday, 2, dtWkFC)

                If booInclMonthData = True Then
                    dtMonFC = objMessMisc.GetMonthlyForecasted(strCustIDs, CDate(strToday), , , , )
                    dtMonFC.Columns.Add(New DataColumn("Found", System.Type.GetType("System.Int16")))
                    dtMonFC.AcceptChanges()
                End If
                'InsertMonthFC(CDate(strToday).Year, CDate(strToday).Month, dtMonFC)
                '************************************
                'Get Actual
                '************************************
                dtWkAct = GetMessDShipCntByDateRange(strCustIDs, strToday, True, False, booNoRpt, , , , , )
                If booInclMonthData = True Then dtMonAct = GetMessDShipCntByDateRange(strCustIDs, strToday, False, False, booNoRpt, , , , , )
                If booInclProduceWip = True Then dtProduceWip = GetMessProduceWipCnt(strCustIDs, False, True, , , , )

                dtWkSpecialShip = GetMessDockShipSpecialCntByDateRange(strCustIDs, strToday, True)
                If booInclMonthData = True Then dtMonSpecialShip = GetMessDockShipSpecialCntByDateRange(strCustIDs, strToday, False)

                '************************************
                'Combine data
                '************************************
                For Each drActWk In dtWkAct.Rows
                    drActWk.BeginEdit()

                    If booInclMonthData = True Then
                        If dtMonFC.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                            drMonFc = dtMonFC.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                            drMonFc.BeginEdit() : drMonFc("Found") = 1 : drMonFc.EndEdit()
                            drActWk("mon Forecast") = CInt(drActWk("mon Forecast")) + CInt(drMonFc("mnForecast"))
                            drActWk("mon Special Qty") = CInt(drActWk("mon Special Qty")) + CInt(drMonFc("mnSpecialQty"))
                        End If
                    End If

                    If dtWkFC.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                        drWkFc = dtWkFC.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                        drWkFc.BeginEdit() : drWkFc("Found") = 1 : drWkFc.EndEdit()
                        drActWk("wk Forecast") = CInt(drActWk("wk Forecast")) + CInt(drWkFc("wk Forecast"))
                        drActWk("wk Special Qty") = CInt(drActWk("wk Special Qty")) + CInt(drWkFc("wk Special Qty"))
                    End If

                    If booInclMonthData = True Then
                        If dtMonAct.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                            drActMon = dtMonAct.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                            drActMon.BeginEdit() : drActMon("Found") = 1 : drActMon.EndEdit()
                            drActWk("mon Ship") = CInt(drActWk("mon Ship")) + CInt(drActMon("mon Ship"))
                        End If
                    End If

                    If booNoRpt = True Then
                        drActWk("wk Variance") = CInt(drActWk("wk Ship")) - (CInt(drActWk("wk Forecast")) + CInt(drActWk("wk Special Qty")))
                        drActWk("mon Variance") = CInt(drActWk("mon Ship")) - (CInt(drActWk("mon Forecast")) + CInt(drActWk("mon Special Qty")))
                    Else
                        drActWk("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActWk("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    If booInclProduceWip = True Then
                        If dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                            drProdWip = dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                            drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                            drActWk("Produce Wip") = CInt(drActWk("Produce Wip")) + CInt(drProdWip("Produce Wip"))
                        Else
                            drActWk("Produce Wip") = 0
                        End If
                    End If

                    drActWk.EndEdit()
                Next drActWk

                '************************************
                'Missing data
                '************************************
                'Missing Monthly Forecast
                If booInclMonthData = True Then
                    drMissing = dtMonFC.Select("Found is null")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                        drActWk = dtWkAct.NewRow
                        'Monthly forecast
                        drActWk("Customer") = drMissing(i)("Cust_Name1")
                        drActWk("Location") = drMissing(i)("Loc_Name")
                        drActWk("Model") = drMissing(i)("Model_Desc")
                        drActWk("Frequency") = drMissing(i)("freq_Number")
                        drActWk("Baud Rate") = drMissing(i)("baud_Number")
                        drActWk("mon Forecast") = drMissing(i)("mnForecast")
                        drActWk("mon Special Qty") = drMissing(i)("mnSpecialQty")
                        drActWk("wk Ship") = 0
                        drActWk("UniqueID") = drMissing(i)("UniqueID")

                        'Weekly forecast
                        If dtWkFC.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                            drWkFc = dtWkFC.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                            drWkFc.BeginEdit() : drWkFc("Found") = 1 : drWkFc.EndEdit()
                            drActWk("wk Forecast") = drWkFc("wk Forecast") : drActWk("wk Special Qty") = drWkFc("wk Special Qty")
                        Else
                            drActWk("wk Forecast") = 0 : drActWk("wk Special Qty") = 0
                        End If

                        'Monthly actual
                        If booInclMonthData = True Then
                            If dtMonAct.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                                drActMon = dtMonAct.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                                drActMon.BeginEdit() : drActMon("Found") = 1 : drActMon.EndEdit()
                                drActWk("mon Ship") = drActMon("mon Ship")
                            Else
                                drActWk("mon Ship") = 0
                            End If
                        Else
                            drActWk("mon Ship") = 0
                        End If

                        If booNoRpt = True Then
                            drActWk("wk Variance") = CInt(drActWk("wk Ship")) - (CInt(drActWk("wk Forecast")) + CInt(drActWk("wk Special Qty")))
                            drActWk("mon Variance") = CInt(drActWk("mon Ship")) - (CInt(drActWk("mon Forecast")) + CInt(drActWk("mon Special Qty")))
                        Else
                            drActWk("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                            drActWk("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        End If

                        'Produce Wip
                        If booInclProduceWip = True Then
                            If dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                                drProdWip = dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                                drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                                drActWk("Produce Wip") = drProdWip("Produce Wip")
                            Else
                                drActWk("Produce Wip") = 0
                            End If
                        Else
                            drActWk("Produce Wip") = 0
                        End If

                        dtWkAct.Rows.Add(drActWk)
                    Next i
                    dtWkAct.AcceptChanges()
                End If

                'Missing Weekly Forecast
                drMissing = dtWkFC.Select("Found = 0")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActWk = dtWkAct.NewRow
                    'wk forecast
                    drActWk("Customer") = drMissing(i)("Customer")
                    drActWk("Location") = drMissing(i)("Location")
                    drActWk("Model") = drMissing(i)("Model")
                    drActWk("Frequency") = drMissing(i)("Frequency")
                    drActWk("Baud Rate") = drMissing(i)("Baud Rate")
                    drActWk("wk Forecast") = drMissing(i)("wk Forecast")
                    drActWk("wk Special Qty") = drMissing(i)("wk Special Qty")
                    drActWk("mon Forecast") = 0
                    drActWk("mon Special Qty") = 0
                    drActWk("wk Ship") = 0
                    drActWk("UniqueID") = drMissing(i)("UniqueID")

                    'Month actual
                    If booInclMonthData = True Then
                        If dtMonAct.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                            drActMon = dtMonAct.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                            drActMon.BeginEdit() : drActMon("Found") = 1 : drActMon.EndEdit()
                            drActWk("mon Ship") = drActMon("mon Ship")
                        Else
                            drActWk("mon Ship") = 0
                        End If
                    Else
                        drActWk("mon Ship") = 0
                    End If

                    If booNoRpt = True Then
                        drActWk("wk Variance") = CInt(drActWk("wk Ship")) - (CInt(drActWk("wk Forecast")) + CInt(drActWk("wk Special Qty")))
                        drActWk("mon Variance") = CInt(drActWk("mon Ship")) - (CInt(drActWk("mon Forecast")) + CInt(drActWk("mon Special Qty")))
                    Else
                        drActWk("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActWk("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    'Produce Wip
                    If booInclProduceWip = True Then
                        If dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                            drProdWip = dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                            drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                            drActWk("Produce Wip") = drProdWip("Produce Wip")
                        Else
                            drActWk("Produce Wip") = 0
                        End If
                    Else
                        drActWk("Produce Wip") = 0
                    End If

                    dtWkAct.Rows.Add(drActWk)
                Next i
                dtWkAct.AcceptChanges()

                'Missing month Actual
                If booInclMonthData = True Then
                    drMissing = dtMonAct.Select("Found = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                        drActWk = dtWkAct.NewRow
                        'wk forecast
                        drActWk("Customer") = drMissing(i)("Customer")
                        drActWk("Location") = drMissing(i)("Location")
                        drActWk("Model") = drMissing(i)("Model")
                        drActWk("Frequency") = drMissing(i)("Frequency")
                        drActWk("Baud Rate") = drMissing(i)("Baud Rate")
                        drActWk("mon Ship") = drMissing(i)("mon Ship")
                        drActWk("mon Forecast") = 0
                        drActWk("mon Special Qty") = 0
                        drActWk("wk Forecast") = 0
                        drActWk("wk Special Qty") = 0
                        drActWk("wk Ship") = 0
                        drActWk("UniqueID") = drMissing(i)("UniqueID")

                        If booNoRpt = True Then
                            drActWk("wk Variance") = CInt(drActWk("wk Ship")) - (CInt(drActWk("wk Forecast")) + CInt(drActWk("wk Special Qty")))
                            drActWk("mon Variance") = CInt(drActWk("mon Ship")) - (CInt(drActWk("mon Forecast")) + CInt(drActWk("mon Special Qty")))
                        Else
                            drActWk("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                            drActWk("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        End If

                        'Produce Wip
                        If booInclProduceWip = True Then
                            If dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'").Length > 0 Then
                                drProdWip = dtProduceWip.Select(" UniqueID = '" & drActWk("UniqueID") & "'")(0)

                                drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                                drActWk("Produce Wip") = drProdWip("Produce Wip")
                            Else
                                drActWk("Produce Wip") = 0
                            End If
                        Else
                            drActWk("Produce Wip") = 0
                        End If

                        dtWkAct.Rows.Add(drActWk)
                    Next i
                End If
                dtWkAct.AcceptChanges()

                'Missing Produce Wip
                If booInclProduceWip = True Then
                    drMissing = dtProduceWip.Select("Found = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                        drActWk = dtWkAct.NewRow
                        'wk forecast
                        drActWk("Customer") = drMissing(i)("Customer")
                        drActWk("Location") = drMissing(i)("Location")
                        drActWk("Model") = drMissing(i)("Model")
                        drActWk("Frequency") = drMissing(i)("Frequency")
                        drActWk("Baud Rate") = drMissing(i)("Baud Rate")
                        drActWk("Produce Wip") = drMissing(i)("Produce Wip")
                        drActWk("wk Ship") = 0
                        drActWk("mon Ship") = 0
                        drActWk("mon Forecast") = 0
                        drActWk("mon Special Qty") = 0
                        drActWk("wk Forecast") = 0
                        drActWk("wk Special Qty") = 0
                        drActWk("UniqueID") = drMissing(i)("UniqueID")

                        If booNoRpt = True Then
                            drActWk("wk Variance") = CInt(drActWk("wk Ship")) - (CInt(drActWk("wk Forecast")) + CInt(drActWk("wk Special Qty")))
                            drActWk("mon Variance") = CInt(drActWk("mon Ship")) - (CInt(drActWk("mon Forecast")) + CInt(drActWk("mon Special Qty")))
                        Else
                            drActWk("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                            drActWk("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        End If

                        dtWkAct.Rows.Add(drActWk)
                    Next i
                End If

                'NEW WAY: WEEKLY DATA-----------------------------------------------------------------------
                'Rename columns
                dtWkAct.Columns("wk Special Qty").ColumnName = "Sp Open" 'sp = Special, Rg = Regular
                dtWkAct.Columns("wk Ship").ColumnName = "wk Rg Ship" 'it is (Rg Ship + Sp Ship), take away sp ship when recalculating
                dtWkAct.Columns("wk Forecast").ColumnName = "wk Rg FC"
                dtWkAct.Columns("mon Forecast").ColumnName = "mon Rg FC"
                dtWkAct.Columns("mon Ship").ColumnName = "Mon Rg Ship" 'it is (Rg Ship + Sp Ship), take away sp ship when recalculating

                'Split ship to regular ship and special ship
                'Dim dcRec As DataColumn = New DataColumn("wk Sp Ship", GetType(System.Int16))
                'dcRec.DefaultValue = 0
                'dtWkAct.Columns.Add(dcRec)
                dtWkAct.Columns.Add(New DataColumn("wk Sp Ship", GetType(System.Int16)))
                For Each row In dtWkAct.Rows
                    row("wk Sp Ship") = 0
                Next

                'Reorder: Column 'wk Sp Ship' is last position now, so change its position after 'wk Rg Ship'
                ReDim arrReOrder(dtWkAct.Columns.Count - 1)
                i = 0 : j = 0
                For Each col In dtWkAct.Columns
                    If col.ColumnName.ToUpper = "wk Sp Ship".ToUpper Then Exit For

                    If col.ColumnName.ToUpper = "wk Rg Ship".ToUpper AndAlso j = 0 Then
                        arrReOrder(i) = i : arrReOrder(i + 1) = dtWkAct.Columns.Count - 1 : j = 1
                    ElseIf j = 1 Then
                        arrReOrder(i + 1) = i
                    Else
                        arrReOrder(i) = i
                    End If
                    i += 1
                Next
                'For i = 0 To arrReOrder.Length - 1
                '    MessageBox.Show(arrReOrder(i))
                'Next
                Dim objMisc As New PSS.Data.Buisness.Misc()
                dtWkAct = objMisc.ReOrderTable(dtWkAct, arrReOrder)

                'Recalculation after new method
                For Each row In dtWkAct.Rows ' dtWkSpecialShip.Rows
                    If dtWkSpecialShip.Rows.Count > 0 Then
                        row.BeginEdit()
                        filteredRows = dtWkSpecialShip.Select("UniqueID='" & row("UniqueID") & "'")
                        For Each row2 In filteredRows
                            row("wk Sp Ship") = row2("Sp Ship")
                            row("wk Rg Ship") = row("wk Rg Ship") - row2("Sp Ship")
                        Next
                    End If
                    row("wk Variance") = row("wk Rg Ship") - (row("wk Rg FC") + row("Sp Open"))
                    row.AcceptChanges()
                Next


                'NEW WAY: MONTHLY DATA-----------------------------------------------------------------------
                'add new col for mon Sp Ship
                dtWkAct.Columns.Add(New DataColumn("mon Sp Ship", GetType(System.Int16)))
                For Each row In dtWkAct.Rows
                    row("mon Sp Ship") = 0
                Next
                'Reorder: Column 'mon Sp Ship' is last position now, so change its position after 'mon Rg Ship'
                ReDim arrReOrder(dtWkAct.Columns.Count - 1)
                i = 0 : j = 0
                For Each col In dtWkAct.Columns
                    If col.ColumnName.ToUpper = "mon Sp Ship".ToUpper Then Exit For

                    If col.ColumnName.ToUpper = "mon Rg Ship".ToUpper AndAlso j = 0 Then
                        arrReOrder(i) = i : arrReOrder(i + 1) = dtWkAct.Columns.Count - 1 : j = 1
                    ElseIf j = 1 Then
                        arrReOrder(i + 1) = i
                    Else
                        arrReOrder(i) = i
                    End If
                    i += 1
                Next
                dtWkAct = objMisc.ReOrderTable(dtWkAct, arrReOrder)

                If booInclMonthData Then
                    'Recalculation after new method
                    For Each row In dtWkAct.Rows ' dtWkSpecialShip.Rows
                        If dtMonSpecialShip.Rows.Count > 0 Then
                            filteredRows = dtMonSpecialShip.Select("UniqueID='" & row("UniqueID") & "'")
                            For Each row2 In filteredRows
                                row("mon Sp Ship") = row2("Sp Ship")
                                row("mon Rg Ship") = row("Mon Rg Ship") - row2("Sp Ship")
                            Next
                        End If
                        row("mon Variance") = row("mon Rg Ship") - (row("mon Rg FC") + row("Sp Open"))
                    Next
                End If



                'Remove unwanted column
                dtWkAct.Columns.Remove("Found")
                dtWkAct.Columns.Remove("mon Special Qty")
                If booNoRpt = False Then dtWkAct.Columns.Remove("UniqueID")
                dtWkAct.AcceptChanges()


                If booNoRpt = False Then
                    Dim objExcelRpt As New PSS.Data.ExcelReports()
                    strRptName = "AMS Forecasted vs LQP " & CDate(strToday).ToString("yyyyMMdd") & ".xls"
                    objExcelRpt.RunSimpleExcelFormat(dtWkAct, strRptName, New String() {"A", "B", "C", "D", "E"}, )
                End If

                'Save data for debug 
                'objMisc.DataTable2CSV(dtWkAct, "R:\dtWkAct01.csv", vbTab)
                objMisc = Nothing

                Return dtWkAct

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtWkFC) : Generic.DisposeDT(dtMonFC) : Generic.DisposeDT(dtWkAct) : Generic.DisposeDT(dtMonAct) : Generic.DisposeDT(dtProduceWip)
                objMessMisc = Nothing
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function GetMessDShipCntByDateRange(ByVal strAMSCustIDs As String, ByVal strToday As String, _
                                                  ByVal booWeekly As Boolean, ByVal booQtyOnly As Boolean, ByVal booNoRpt As Boolean, _
                                                  Optional ByVal iModelID As Integer = 0, _
                                                  Optional ByVal iFreqID As Integer = 0, _
                                                  Optional ByVal iBaudID As Integer = 0, _
                                                  Optional ByVal booRegularOnly As Boolean = False, _
                                                  Optional ByVal iLocID As Integer = 0) As DataTable
            'wk ship : Regular dock shipped and Speical dock shipped
            Dim strSql, strDateStart, strDateEnd As String
            Dim dtTmp As DataTable

            Try
                'define date range for either weekly or daily
                If booWeekly Then
                    strDateStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                    strDateEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateStart)), "yyyy-MM-dd")
                Else
                    'strDateStart = CDate(strToday).Year & "-" & CDate(strToday).Month.ToString.PadLeft(2, "0") & "-01"
                    ' strDateEnd = CDate(strToday).Year & "-" & CDate(strToday).Month.ToString.PadLeft(2, "0") & "-" & DateTime.DaysInMonth(CDate(strToday).Year, CDate(strToday).Month)
                    strSql = "select distinct MonthWeekStartDate,MonthWeekEnddate from tamsforecastedneed_month"
                    strSql &= " where MonthWeekStartDate <='" & strToday & "' and  MonthWeekEnddate >='" & strToday & "';"
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    If dtTmp.Rows.Count > 0 Then
                        strDateStart = Format(dtTmp.Rows(0).Item("MonthWeekStartDate"), "yyyy-MM-dd")
                        strDateEnd = Format(dtTmp.Rows(0).Item("MonthWeekEnddate"), "yyyy-MM-dd")
                    Else
                        Throw New Exception("Can't find the fiscal month dates.")
                    End If
                End If

                '***********************************************************
                'Dock Ship
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then strSql &= ", COUNT(*) as 'wk Ship' " & Environment.NewLine Else strSql &= ", 0 as 'wk Ship' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If
                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "
                    If booWeekly Then strSql &= ", 0 as 'mon Ship' " & Environment.NewLine Else strSql &= ", COUNT(*) as 'mon Ship' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If

                    strSql &= ", 0 as 'Produce Wip' " & Environment.NewLine

                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If
                strSql &= " INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tpackingslip I ON H.pkslip_ID = I.pkslip_ID" & Environment.NewLine

                strSql &= " WHERE I.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND I.pkslip_createDt BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' " & Environment.NewLine
                strSql &= " AND H.Pallet_ShipType = 0 " & Environment.NewLine

                If booRegularOnly Then strSql &= " AND D.AFSPQTY_ID = 0 " & Environment.NewLine

                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Function GetMessDockShipSpecialCntByDateRange(ByVal strAMSCustIDs As String, ByVal strToday As String, ByVal booWeekly As Boolean)
            'Special Dock Ship 
            Dim strSql, strDateStart, strDateEnd As String
            Dim dtTmp As DataTable

            Try
                'define date range for either weekly or daily
                If booWeekly Then 'weekly
                    strDateStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                    strDateEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateStart)), "yyyy-MM-dd")
                Else 'monthly
                    strSql = "select distinct MonthWeekStartDate,MonthWeekEnddate from tamsforecastedneed_month"
                    strSql &= " where MonthWeekStartDate <='" & strToday & "' and  MonthWeekEnddate >='" & strToday & "';"
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    If dtTmp.Rows.Count > 0 Then
                        strDateStart = Format(dtTmp.Rows(0).Item("MonthWeekStartDate"), "yyyy-MM-dd")
                        strDateEnd = Format(dtTmp.Rows(0).Item("MonthWeekEnddate"), "yyyy-MM-dd")
                    Else
                        Throw New Exception("Can't find the fiscal month dates.")
                    End If
                End If

                strSql = "SELECT" & Environment.NewLine
                strSql &= "  C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model'" & Environment.NewLine
                strSql &= " , F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate'" & Environment.NewLine
                strSql &= " , 0 AS 'wk Forecast', 0 as 'wk Special Qty', COUNT(*) as 'Sp Ship'" & Environment.NewLine
                strSql &= " , 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                strSql &= " , 0 AS 'mon Forecast', 0 as 'mon Special Qty' , 0 as 'mon Ship' " & Environment.NewLine
                strSql &= " , 0 as 'mon Variance', '' as 'm'" & Environment.NewLine
                strSql &= " , 0 as 'Produce Wip'" & Environment.NewLine
                strSql &= " , Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found " & Environment.NewLine
                strSql &= "  FROM tdevice A" & Environment.NewLine
                strSql &= "  INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                strSql &= "  INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                strSql &= "  INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tpackingslip I ON H.pkslip_ID = I.pkslip_ID" & Environment.NewLine
                strSql &= "  WHERE I.CUST_ID IN (" & strAMSCustIDs & ")" & Environment.NewLine
                strSql &= "  AND I.pkslip_createDt BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= "  AND H.Pallet_ShipType = 0  AND D.AFSPQTY_ID >0" & Environment.NewLine
                strSql &= "  GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID ;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Function GetMessProduceWipCnt(ByVal strAMSCustIDs As String, ByVal booQtyOnly As Boolean, ByVal booNoRpt As Boolean, _
                                                  Optional ByVal iModelID As Integer = 0, _
                                                  Optional ByVal iFreqID As Integer = 0, _
                                                  Optional ByVal iBaudID As Integer = 0, _
                                                  Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql, strToday As String

            Try
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", count(*) as 'Produce Wip' " & Environment.NewLine

                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If
                strSql &= " INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine

                strSql &= " WHERE H.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND A.Device_dateShip > '2000-01-01 00:00:00' AND pkslip_ID is null " & Environment.NewLine
                strSql &= " AND H.Pallet_ShipType = 0 " & Environment.NewLine
                strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function GetAMSWkForecast(ByVal strCustIDs As String, ByVal strToday As String, ByVal booDataOnly As Boolean, ByVal booQtyOnly As Boolean, _
                                          Optional ByVal iModelID As Integer = 0, Optional ByVal iFreqID As Integer = 0, _
                                          Optional ByVal iBaudID As Integer = 0, Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql, strDateWeekStart, strDateWeekEnd As String
            Dim dt, dttmp As DataTable
            Dim row, rowNew As DataRow
            Dim iQty As Integer = 0

            Try
                strDateWeekStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                strDateWeekEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateWeekStart)), "yyyy-MM-dd")

                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " B.Cust_Name1 as 'Customer', G.Loc_Name as 'Location', F.Model_Desc as 'Model'" & Environment.NewLine
                    strSql &= " , D.freq_Number as 'Frequency', E.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= " , A.Qty as 'wk Forecast', A.SpecialRequestedQty as 'wk Special Qty', 0 as 'wk Actual'" & Environment.NewLine
                    If booDataOnly Then strSql &= ", 0 as 'wk Variance' " & Environment.NewLine Else strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'wk Variance' " & Environment.NewLine
                    strSql &= " , Concat_WS('_',A.Cust_ID, A.Loc_ID, A.PSSI_Model_ID,D.Freq_ID,E.baud_ID) as 'UniqueID', 0 as Found " & Environment.NewLine
                Else
                    strSql &= " (A.Qty + A.SpecialRequestedQty) as 'Forecast' " & Environment.NewLine
                End If
                strSql &= "  FROM tamsForecastedNeed A" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= "  INNER JOIN tmodel F ON A.PSSI_Model_ID=F.Model_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN tcustomer B ON A.Cust_ID = B.Cust_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN tlocation G ON A.Loc_ID = G.Loc_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN lfrequency D ON A.PSSI_freq_ID = D.freq_ID" & Environment.NewLine
                    strSql &= "  INNER JOIN lbaud E on A.PSSI_baud_ID = E.baud_ID" & Environment.NewLine
                End If
                strSql &= "  WHERE  A.Cust_ID in (" & strCustIDs & ") " & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.PSSI_Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND A.PSSI_freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND A.PSSI_baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND YearWeekStartDate BETWEEN '" & strDateWeekStart & " 00:00:00' and '" & strDateWeekEnd & " 00:00:00' " & Environment.NewLine
                If booQtyOnly = False Then strSql &= " ORDER BY B.Cust_Name1, G.Loc_Name, F.Model_Desc , D.freq_Number, E.baud_Number "

                dt = Me._objDataProc.GetDataTable(strSql)
                If booQtyOnly Then 'need to improve
                    strSql = "SELECT A.Qty as 'Forecast' FROM tamsForecastedNeed A WHERE A.Cust_ID in (" & strCustIDs & ") " & Environment.NewLine
                    strSql &= " AND A.PSSI_Model_ID = " & iModelID & " AND A.PSSI_freq_ID = " & iFreqID & Environment.NewLine
                    strSql &= " AND A.Loc_ID = " & iLocID & " AND A.PSSI_baud_ID = " & iBaudID & Environment.NewLine
                    strSql &= " UNION ALL " & Environment.NewLine
                    strSql &= "SELECT A.SpecialRequestedQty as 'Forecast' FROM tamsForecastedNeed_special A WHERE  A.Cust_ID in (" & strCustIDs & ") " & Environment.NewLine
                    If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                    If iModelID > 0 Then strSql &= " AND A.PSSI_Model_ID = " & iModelID & Environment.NewLine
                    If iFreqID > 0 Then strSql &= " AND A.PSSI_freq_ID = " & iFreqID & Environment.NewLine
                    If iBaudID > 0 Then strSql &= " AND A.PSSI_baud_ID = " & iBaudID & Environment.NewLine
                    'strSql &= " AND A.Loc_ID = " & iLocID & " AND A.PSSI_Model_ID = " & iModelID & " AND A.PSSI_freq_ID = " & iFreqID & Environment.NewLine
                    'strSql &= " AND A.PSSI_baud_ID = " & iBaudID & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    dttmp = dt.Clone : iQty = 0

                    If dt.Rows.Count > 0 Then
                        For Each row In dt.Rows
                            If Not row.IsNull("Forecast") Then
                                iQty += CInt(row("Forecast"))
                            End If
                        Next
                    End If
                    rowNew = dttmp.NewRow
                    rowNew("Forecast") = iQty
                    dttmp.Rows.Add(rowNew)

                    dt = dttmp
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function RunMessWkMonthlyFCVersusLQP_Sum(ByVal booNoRpt As Boolean) As DataTable
            Dim strSql, strToday, strCustIDs, strRptName As String
            Dim dtWkFC, dtMonFC, dtWkAct, dtMonAct As DataTable
            Dim dtWkSpecialProduced, dtMonSpecialProduced As DataTable
            Dim objMessMisc As New MessMisc()
            Dim drActMon, drActWk, drWkFc, drMonFc, drMissing(), filteredRows(), row, row2 As DataRow
            Dim col As DataColumn
            Dim i, j As Integer
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Dim arrReOrder() As Integer

            Try
                '************************************
                'Define this week date range
                '************************************
                strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")
                '************************************
                'Get Customer List
                '************************************
                strCustIDs = GetAMSMessCustIDs()
                '************************************
                'Get Forecast
                '************************************
                'Weekly
                dtWkFC = GetAMSWkForecast(strCustIDs, strToday, False, False, , , , )
                'New method
                Me.ApplyNewMethodWKFC(strCustIDs, strToday, 1, dtWkFC)

                'Monthly
                dtMonFC = objMessMisc.GetMonthlyForecasted(strCustIDs, CDate(strToday), , , , )
                dtMonFC.Columns.Add(New DataColumn("Found", System.Type.GetType("System.Int16")))
                dtMonFC.AcceptChanges()
                'InsertMonthFC(CDate(strToday).Year, CDate(strToday).Month, dtMonFC)


                '************************************
                'Get Actual
                '************************************
                dtWkAct = GetMessLQPCntByDateRange_Sum(strCustIDs, strToday, True, False, booNoRpt, , , , )
                dtMonAct = GetMessLQPCntByDateRange_Sum(strCustIDs, strToday, False, False, booNoRpt, , , , )

                dtWkSpecialProduced = Me.GetMessSpecialProducedCntByDateRange(strCustIDs, strToday, True)
                dtMonSpecialProduced = Me.GetMessSpecialProducedCntByDateRange(strCustIDs, strToday, False)

                '************************************
                'Combine data
                '************************************
                For Each drActMon In dtMonAct.Rows
                    drActMon.BeginEdit()

                    If dtMonFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drMonFc = dtMonFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drMonFc.BeginEdit() : drMonFc("Found") = 1 : drMonFc.EndEdit()
                        drActMon("mon Forecast") = CInt(drActMon("mon Forecast")) + CInt(drMonFc("mnForecast"))
                        drActMon("mon Special Qty") = CInt(drActMon("mon Special Qty")) + CInt(drMonFc("mnSpecialQty"))
                    End If

                    If dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drWkFc = dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drWkFc.BeginEdit() : drWkFc("Found") = 1 : drWkFc.EndEdit()
                        drActMon("wk Forecast") = CInt(drActMon("wk Forecast")) + CInt(drWkFc("wk Forecast"))
                        drActMon("wk Special Qty") = CInt(drActMon("wk Special Qty")) + CInt(drWkFc("wk Special Qty"))
                    End If

                    If dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drActWk = dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drActWk.BeginEdit() : drActWk("Found") = 1 : drActWk.EndEdit()
                        drActMon("wk LQP") = CInt(drActMon("wk LQP")) + CInt(drActWk("wk LQP"))
                    End If

                    If booNoRpt = True Then
                        drActMon("wk Variance") = CInt(drActMon("wk LQP")) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    drActMon.EndEdit()
                Next drActMon

                '************************************
                'Missing data
                '************************************
                'Missing Monthly Forecast
                drMissing = dtMonFC.Select("Found is null")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActMon = dtMonAct.NewRow
                    'Monthly forecast
                    drActMon("Customer") = drMissing(i)("Cust_Name1")
                    drActMon("Location") = drMissing(i)("Loc_Name")
                    drActMon("Model") = drMissing(i)("Model_Desc")
                    drActMon("Frequency") = drMissing(i)("freq_Number")
                    drActMon("Baud Rate") = drMissing(i)("baud_Number")
                    drActMon("mon Forecast") = drMissing(i)("mnForecast")
                    drActMon("mon Special Qty") = drMissing(i)("mnSpecialQty")
                    drActMon("mon LQP") = 0
                    drActMon("UniqueID") = drMissing(i)("UniqueID")

                    'Weekly forecast
                    If dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drWkFc = dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drWkFc.BeginEdit() : drWkFc("Found") = 1 : drWkFc.EndEdit()
                        drActMon("wk Forecast") = drWkFc("wk Forecast") : drActMon("wk Special Qty") = drWkFc("wk Special Qty")
                    Else
                        drActMon("wk Forecast") = 0 : drActMon("wk Special Qty") = 0
                    End If

                    'Weekly actual
                    If dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drActWk = dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drActWk.BeginEdit() : drActWk("Found") = 1 : drActWk.EndEdit()
                        drActMon("wk LQP") = drActWk("wk LQP")
                    Else
                        drActMon("wk LQP") = 0
                    End If

                    If booNoRpt = True Then
                        drActMon("wk Variance") = CInt(drActMon("wk LQP")) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If
                    dtMonAct.Rows.Add(drActMon)
                Next i
                dtMonAct.AcceptChanges()

                'Missing Weekly Forecast
                drMissing = dtWkFC.Select("Found = 0")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActMon = dtMonAct.NewRow
                    'wk forecast
                    drActMon("Customer") = drMissing(i)("Customer")
                    drActMon("Location") = drMissing(i)("Location")
                    drActMon("Model") = drMissing(i)("Model")
                    drActMon("Frequency") = drMissing(i)("Frequency")
                    drActMon("Baud Rate") = drMissing(i)("Baud Rate")
                    drActMon("wk Forecast") = drMissing(i)("wk Forecast")
                    drActMon("wk Special Qty") = drMissing(i)("wk Special Qty")
                    drActMon("mon Forecast") = 0
                    drActMon("mon Special Qty") = 0
                    drActMon("mon LQP") = 0
                    drActMon("UniqueID") = drMissing(i)("UniqueID")

                    'Weekly actual
                    If dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drActWk = dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drActWk.BeginEdit() : drActWk("Found") = 1 : drActWk.EndEdit()
                        drActMon("wk LQP") = drActWk("wk LQP")
                    Else
                        drActMon("wk LQP") = 0
                    End If

                    If booNoRpt = True Then
                        drActMon("wk Variance") = CInt(drActMon("wk LQP")) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If
                    dtMonAct.Rows.Add(drActMon)
                Next i
                dtMonAct.AcceptChanges()

                'Missing Weekly Actual
                drMissing = dtWkAct.Select("Found = 0")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActMon = dtMonAct.NewRow
                    'wk forecast
                    drActMon("Customer") = drMissing(i)("Customer")
                    drActMon("Location") = drMissing(i)("Location")
                    drActMon("Model") = drMissing(i)("Model")
                    drActMon("Frequency") = drMissing(i)("Frequency")
                    drActMon("Baud Rate") = drMissing(i)("Baud Rate")
                    drActMon("wk LQP") = drMissing(i)("wk LQP")
                    drActMon("mon LQP") = 0
                    drActMon("mon Forecast") = 0
                    drActMon("mon Special Qty") = 0
                    drActMon("wk Forecast") = 0
                    drActMon("wk Special Qty") = 0
                    drActMon("UniqueID") = drMissing(i)("UniqueID")

                    If booNoRpt = True Then
                        drActMon("wk Variance") = CInt(drActMon("wk LQP")) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If
                    dtMonAct.Rows.Add(drActMon)
                Next i


                'NEW WAY: WEEKLY DATA-----------------------------------------------------------------------
                'Rename columns
                dtMonAct.Columns("wk Special Qty").ColumnName = "Sp Open" 'sp = Special, Rg = Regular
                dtMonAct.Columns("wk Forecast").ColumnName = "wk Rg FC"
                dtMonAct.Columns("mon Forecast").ColumnName = "mon Rg FC"

                'Split Wk LQP to Wk LQP-Wk Special Produced and Wk Special Produced
                dtMonAct.Columns.Add(New DataColumn("wk Sp Produced", GetType(System.Int16)))
                For Each row In dtMonAct.Rows
                    row("wk Sp Produced") = 0
                Next

                'Reorder: Column 'wk Sp Produced' is last position now, so change its position after 'wk LQP'
                ReDim arrReOrder(dtMonAct.Columns.Count - 1)
                i = 0 : j = 0
                For Each col In dtMonAct.Columns
                    If col.ColumnName.ToUpper = "wk Sp Produced".ToUpper Then Exit For

                    If col.ColumnName.ToUpper = "wk LQP".ToUpper AndAlso j = 0 Then
                        arrReOrder(i) = i : arrReOrder(i + 1) = dtMonAct.Columns.Count - 1 : j = 1
                    ElseIf j = 1 Then
                        arrReOrder(i + 1) = i
                    Else
                        arrReOrder(i) = i
                    End If
                    i += 1
                Next
                dtMonAct = objMisc.ReOrderTable(dtMonAct, arrReOrder)

                'Recalculation after new method
                For Each row In dtMonAct.Rows
                    row.BeginEdit()
                    If dtWkSpecialProduced.Rows.Count > 0 Then
                        filteredRows = dtWkSpecialProduced.Select("UniqueID='" & row("UniqueID") & "'")
                        For Each row2 In filteredRows
                            row("wk Sp Produced") = row2("Sp Produced")
                            row("wk LQP") = row("wk LQP") - row2("Sp Produced")
                        Next
                    End If
                    row("wk Variance") = row("wk LQP") - (row("wk Rg FC") + row("Sp Open"))
                    row.AcceptChanges()
                Next

                'NEW WAY: MONTHLY DATA-----------------------------------------------------------------------
                'Split Mon LQP to (Mon LQP - Mon Special Produced) and Mon Special Produced
                dtMonAct.Columns.Add(New DataColumn("mon Sp Produced", GetType(System.Int16)))
                For Each row In dtMonAct.Rows
                    row("mon Sp Produced") = 0
                Next

                'Reorder: Column 'mon Sp Produced' is last position now, so change its position after 'mon LQP'
                ReDim arrReOrder(dtMonAct.Columns.Count - 1)
                i = 0 : j = 0
                For Each col In dtMonAct.Columns
                    If col.ColumnName.ToUpper = "mon Sp Produced".ToUpper Then Exit For

                    If col.ColumnName.ToUpper = "mon LQP".ToUpper AndAlso j = 0 Then
                        arrReOrder(i) = i : arrReOrder(i + 1) = dtMonAct.Columns.Count - 1 : j = 1
                    ElseIf j = 1 Then
                        arrReOrder(i + 1) = i
                    Else
                        arrReOrder(i) = i
                    End If
                    i += 1
                Next
                dtMonAct = objMisc.ReOrderTable(dtMonAct, arrReOrder)

                'Recalculation after new method
                For Each row In dtMonAct.Rows
                    row.BeginEdit()
                    If dtMonSpecialProduced.Rows.Count > 0 Then
                        filteredRows = dtMonSpecialProduced.Select("UniqueID='" & row("UniqueID") & "'")
                        For Each row2 In filteredRows
                            row("mon Sp Produced") = row2("Sp Produced")
                            row("mon LQP") = row("mon LQP") - row2("Sp Produced")
                        Next
                    End If
                    row("mon Variance") = row("mon LQP") - (row("mon Rg FC") + row("Sp Open"))
                    row.AcceptChanges()
                Next

                'Save data for debug
                'objMisc.DataTable2CSV(dtMonAct, "R:\FC vs LQP " & Format(Now, "yyyyMMddHHmmss") & ".csv", vbTab)

                'remove unwanted columns
                dtMonAct.Columns.Remove("mon Special Qty")
                dtMonAct.Columns.Remove("Found")
                If booNoRpt = False Then dtMonAct.Columns.Remove("UniqueID")
                dtMonAct.AcceptChanges()

                If booNoRpt = False Then
                    Dim objExcelRpt As New PSS.Data.ExcelReports()
                    strRptName = "AMS Forecasted vs LQP " & CDate(strToday).ToString("yyyyMMdd") & ".xls"
                    objExcelRpt.RunSimpleExcelFormat(dtMonAct, strRptName, New String() {"A", "B", "C", "D", "E"}, )
                End If

                Return dtMonAct
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtWkFC) : Generic.DisposeDT(dtMonFC) : Generic.DisposeDT(dtWkAct) : Generic.DisposeDT(dtMonAct)
                objMessMisc = Nothing : objMisc = Nothing
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Function GetMessLQPCntByDateRange_Sum(ByVal strAMSCustIDs As String, ByVal strToday As String, _
                                                  ByVal booWeekly As Boolean, ByVal booQtyOnly As Boolean, ByVal booNoRpt As Boolean, _
                                                  Optional ByVal iModelID As Integer = 0, _
                                                  Optional ByVal iFreqID As Integer = 0, _
                                                  Optional ByVal iBaudID As Integer = 0, _
                                                  Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql, strDateStart, strDateEnd As String
            Dim dtLabel, dtQC, dtProduce, dtTmp As DataTable
            Dim drLabel, drQC, drProduce, drMissing() As DataRow
            Dim i, j As Integer

            Try
                'define date range for either weekly or daily
                If booWeekly Then
                    strDateStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                    strDateEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateStart)), "yyyy-MM-dd")
                Else
                    'strDateStart = CDate(strToday).Year & "-" & CDate(strToday).Month.ToString.PadLeft(2, "0") & "-01"
                    'strDateEnd = CDate(strToday).Year & "-" & CDate(strToday).Month.ToString.PadLeft(2, "0") & "-" & DateTime.DaysInMonth(CDate(strToday).Year, CDate(strToday).Month)
                    'strDateStart = "2015-01-26"
                    'strDateEnd = "2015-02-21"
                    strSql = "select distinct MonthWeekStartDate,MonthWeekEnddate from tamsforecastedneed_month"
                    strSql &= " where MonthWeekStartDate <='" & strToday & "' and  MonthWeekEnddate >='" & strToday & "';"
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    If dtTmp.Rows.Count > 0 Then
                        strDateStart = Format(dtTmp.Rows(0).Item("MonthWeekStartDate"), "yyyy-MM-dd")
                        strDateEnd = Format(dtTmp.Rows(0).Item("MonthWeekEnddate"), "yyyy-MM-dd")
                    Else
                        Throw New Exception("Can't find the fiscal month dates.")
                    End If
                End If

                '***********************************************************
                'LABEL
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then strSql &= ", COUNT(*) as 'wk LQP' " & Environment.NewLine Else strSql &= ", 0 as 'wk LQP' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w'" & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If
                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "
                    If booWeekly Then strSql &= ", 0 as 'mon LQP' " & Environment.NewLine Else strSql &= ", COUNT(*) as 'mon LQP' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If

                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If

                strSql &= " WHERE C.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND ( ( label_workdate between '" & strDateStart & "' AND '" & strDateEnd & "' AND qcwork_date is null AND Device_dateship is null )" & Environment.NewLine
                'strSql &= "    OR (  qcwork_date between '" & strDateStart & "' AND '" & strDateEnd & "' AND qcresult_id = 1 AND Device_dateship is null )" & Environment.NewLine
                'strSql &= "    OR ( Device_dateship between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' )" & Environment.NewLine
                strSql &= " ) " & Environment.NewLine
                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                dtLabel = Me._objDataProc.GetDataTable(strSql)

                '***********************************************************
                'QC
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then strSql &= ", COUNT(*) as 'wk LQP' " & Environment.NewLine Else strSql &= ", 0 as 'wk LQP' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If

                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "
                    If booWeekly Then strSql &= ", 0 as 'mon LQP' " & Environment.NewLine Else strSql &= ", COUNT(*) as 'mon LQP' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If
                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If

                strSql &= " WHERE C.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND ( qcwork_date between '" & strDateStart & "' AND '" & strDateEnd & "' AND qcresult_id = 1 AND Device_dateship is null )" & Environment.NewLine
                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                dtQC = Me._objDataProc.GetDataTable(strSql)

                '***********************************************************
                'PRODUCE
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then strSql &= ", COUNT(*) as 'wk LQP' " & Environment.NewLine Else strSql &= ", 0 as 'wk LQP' " & Environment.NewLine

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If

                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "
                    If booWeekly Then strSql &= ", 0 as 'mon LQP' " & Environment.NewLine Else strSql &= ", COUNT(*) as 'mon LQP' " & Environment.NewLine
                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If
                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If
                strSql &= " INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine

                strSql &= " WHERE H.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND ( A.Device_dateship between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' )  " & Environment.NewLine
                strSql &= " AND H.Pallet_ShipType = 0 " & Environment.NewLine
                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                dtProduce = Me._objDataProc.GetDataTable(strSql)

                '***********************************************************
                'COMBINE DATA
                '***********************************************************
                If booQtyOnly = True Then
                    dtLabel.Rows(0).BeginEdit()
                    dtLabel.Rows(0)("cnt") = CInt(dtLabel.Rows(0)("cnt")) + CInt(dtQC.Rows(0)("cnt")) + CInt(dtProduce.Rows(0)("cnt"))
                    dtLabel.Rows(0).EndEdit()
                Else
                    For Each drLabel In dtLabel.Rows
                        drLabel.BeginEdit()

                        If dtQC.Select("UniqueID = '" & drLabel("UniqueID") & "'").Length > 0 Then
                            drQC = dtQC.Select("UniqueID = '" & drLabel("UniqueID") & "'")(0)
                            drQC.BeginEdit() : drQC("Found2") = 1 : drQC.EndEdit()

                            If booWeekly Then drLabel("wk LQP") = CInt(drLabel("wk LQP")) + CInt(drQC("wk LQP")) Else drLabel("mon LQP") = CInt(drLabel("mon LQP")) + CInt(drQC("mon LQP"))
                        End If

                        If dtProduce.Select("UniqueID = '" & drLabel("UniqueID") & "'").Length > 0 Then
                            drProduce = dtProduce.Select("UniqueID = '" & drLabel("UniqueID") & "'")(0)
                            drProduce.BeginEdit() : drProduce("Found2") = 1 : drProduce.EndEdit()

                            If booWeekly Then drLabel("wk LQP") = CInt(drLabel("wk LQP")) + CInt(drProduce("wk LQP")) Else drLabel("mon LQP") = CInt(drLabel("mon LQP")) + CInt(drProduce("mon LQP"))
                        End If

                        drLabel.EndEdit()
                    Next drLabel

                    drMissing = dtQC.Select("Found2 = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found2") = 1 : drMissing(i).EndEdit()

                        drLabel = dtLabel.NewRow
                        For j = 0 To dtLabel.Columns.Count - 1
                            drLabel(j) = drMissing(i)(j)
                        Next j

                        If dtProduce.Select("UniqueID = '" & drMissing(i)("UniqueID") & "'").Length > 0 Then
                            drProduce = dtProduce.Select("UniqueID = '" & drMissing(i)("UniqueID") & "'")(0)
                            drProduce.BeginEdit() : drProduce("Found2") = 1 : drProduce.EndEdit()

                            If booWeekly Then drLabel("wk LQP") = CInt(drLabel("wk LQP")) + CInt(drProduce("wk LQP")) Else drLabel("mon LQP") = CInt(drLabel("mon LQP")) + CInt(drProduce("mon LQP"))
                        End If

                        dtLabel.Rows.Add(drLabel)
                    Next i
                    dtLabel.AcceptChanges()

                    drMissing = dtProduce.Select("Found2 = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found2") = 1 : drMissing(i).EndEdit()
                        dtLabel.ImportRow(drMissing(i))
                    Next i
                    dtLabel.AcceptChanges()

                    '***********************************************************

                    dtLabel.Columns.Remove("Found2") : dtLabel.AcceptChanges()
                End If

                Return dtLabel
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtLabel) : Generic.DisposeDT(dtQC) : Generic.DisposeDT(dtProduce)
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Function GetMessSpecialProducedCntByDateRange(ByVal strAMSCustIDs As String, ByVal strToday As String, _
                                                           ByVal booWeekly As Boolean) As DataTable
            Dim strSql, strDateStart, strDateEnd As String
            Dim dtTmp As DataTable


            Try
                'define date range for either weekly or daily
                If booWeekly Then
                    strDateStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                    strDateEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateStart)), "yyyy-MM-dd")
                Else
                    strSql = "select distinct MonthWeekStartDate,MonthWeekEnddate from tamsforecastedneed_month"
                    strSql &= " where MonthWeekStartDate <='" & strToday & "' and  MonthWeekEnddate >='" & strToday & "';"
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    If dtTmp.Rows.Count > 0 Then
                        strDateStart = Format(dtTmp.Rows(0).Item("MonthWeekStartDate"), "yyyy-MM-dd")
                        strDateEnd = Format(dtTmp.Rows(0).Item("MonthWeekEnddate"), "yyyy-MM-dd")
                    Else
                        Throw New Exception("Can't find the fiscal month dates.")
                    End If
                End If

                strSql = "SELECT" & Environment.NewLine
                strSql &= "  C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model'" & Environment.NewLine
                strSql &= " , F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate'" & Environment.NewLine
                strSql &= " , 0 AS 'wk Forecast', 0 as 'wk Special Qty', COUNT(*) as 'Sp Produced' " & Environment.NewLine
                strSql &= " , 0 as 'wk Variance', '' as 'w'" & Environment.NewLine
                strSql &= " , 0 AS 'mon Forecast', 0 as 'mon Special Qty' , 0 as 'mon LQP'" & Environment.NewLine
                strSql &= " , 0 as 'mon Variance', '' as 'm'" & Environment.NewLine
                strSql &= " , Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                strSql &= "  FROM tdevice A" & Environment.NewLine
                strSql &= "  INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                strSql &= "  INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                strSql &= "  INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                strSql &= "  INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine
                strSql &= "  WHERE H.CUST_ID IN (" & strAMSCustIDs & ")" & Environment.NewLine
                strSql &= "  AND ( A.Device_dateship between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' )  " & Environment.NewLine
                strSql &= "  AND H.Pallet_ShipType = 0 AND D.AFSPQTY_ID >0" & Environment.NewLine
                strSql &= "  GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID ;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtTmp)
            End Try
        End Function


        '******************************************************************************************************************************************
        Public Function RunMessWkMonthlyFCVersusLQP(ByVal booNoRpt As Boolean, ByVal booInclProduceWip As Boolean) As DataTable
            Dim strSql, strToday, strCustIDs, strRptName As String
            Dim dtWkFC, dtMonFC, dtWkAct, dtMonAct, dtProduceWip As DataTable
            Dim dtWkSpecialProduced, dtMonSpecialProduced As DataTable
            Dim objMessMisc As New MessMisc()
            Dim row, row2, drActMon, drActWk, drWkFc, drMonFc, drProdWip, drMissing(), filteredRows() As DataRow
            Dim col As DataColumn
            Dim i, j As Integer
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Dim arrReOrder() As Integer

            Try
                '************************************
                'Define this week date range
                '************************************
                strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")
                '************************************
                'Get Customer List
                '************************************
                strCustIDs = GetAMSMessCustIDs()
                '************************************
                'Get Forecast
                '************************************
                'WEEK FC
                dtWkFC = GetAMSWkForecast(strCustIDs, strToday, False, False, , , , )

                'Apply new method: reset old wkspecialQty=0,and update it with new data
                ApplyNewMethodWKFC(strCustIDs, strToday, 1, dtWkFC)

                'MONTH FC
                dtMonFC = objMessMisc.GetMonthlyForecasted(strCustIDs, CDate(strToday), , , , )
                dtMonFC.Columns.Add(New DataColumn("Found", System.Type.GetType("System.Int16")))
                dtMonFC.AcceptChanges()
                'InsertMonthFC(CDate(strToday).Year, CDate(strToday).Month, dtMonFC)
                'myObj.DataTable2CSV(dtMonFC, "R:\dtMonFC.csv", vbTab)  '";")

                '************************************
                'Get Actual
                '************************************
                dtWkAct = GetMessLQPCntByDateRange(strCustIDs, strToday, True, False, booNoRpt, , , , )
                dtMonAct = GetMessLQPCntByDateRange(strCustIDs, strToday, False, False, booNoRpt, , , , )
                If booInclProduceWip = True Then dtProduceWip = GetMessProduceWipCnt(strCustIDs, False, True, , , , )

                dtWkSpecialProduced = Me.GetMessSpecialProducedCntByDateRange(strCustIDs, strToday, True)
                dtMonSpecialProduced = Me.GetMessSpecialProducedCntByDateRange(strCustIDs, strToday, False)

                '************************************
                'Combine data
                '************************************
                For Each drActMon In dtMonAct.Rows
                    drActMon.BeginEdit()

                    If dtMonFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drMonFc = dtMonFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drMonFc.BeginEdit() : drMonFc("Found") = 1 : drMonFc.EndEdit()
                        drActMon("mon Forecast") = CInt(drActMon("mon Forecast")) + CInt(drMonFc("mnForecast"))
                        drActMon("mon Special Qty") = CInt(drActMon("mon Special Qty")) + CInt(drMonFc("mnSpecialQty"))
                    End If

                    If dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drWkFc = dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drWkFc.BeginEdit() : drWkFc("Found") = 1 : drWkFc.EndEdit()
                        drActMon("wk Forecast") = CInt(drActMon("wk Forecast")) + CInt(drWkFc("wk Forecast"))
                        drActMon("wk Special Qty") = CInt(drActMon("wk Special Qty")) + CInt(drWkFc("wk Special Qty"))
                    End If

                    If dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drActWk = dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drActWk.BeginEdit() : drActWk("Found") = 1 : drActWk.EndEdit()
                        drActMon("wk Label") = drActWk("wk Label")
                        drActMon("wk QC") = drActWk("wk QC")
                        drActMon("wk Produce") = drActWk("wk Produce")
                    End If

                    If booNoRpt = True Then
                        drActMon("wk Variance") = (CInt(drActMon("wk Label")) + CInt(drActMon("wk QC")) + CInt(drActMon("wk Produce"))) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    If booInclProduceWip = True Then
                        If dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                            drProdWip = dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                            drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                            drActMon("Produce Wip") = CInt(drActMon("Produce Wip")) + CInt(drProdWip("Produce Wip"))
                        End If
                    End If
                    drActMon.EndEdit()
                Next drActMon

                '************************************
                'Missing data
                '************************************
                'Missing Monthly Forecast
                drMissing = dtMonFC.Select("Found is null")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActMon = dtMonAct.NewRow
                    'Monthly forecast
                    drActMon("Customer") = drMissing(i)("Cust_Name1")
                    drActMon("Location") = drMissing(i)("Loc_Name")
                    drActMon("Model") = drMissing(i)("Model_Desc")
                    drActMon("Frequency") = drMissing(i)("freq_Number")
                    drActMon("Baud Rate") = drMissing(i)("baud_Number")
                    drActMon("mon Forecast") = drMissing(i)("mnForecast")
                    drActMon("mon Special Qty") = drMissing(i)("mnSpecialQty")
                    drActMon("mon LQP") = 0
                    drActMon("UniqueID") = drMissing(i)("UniqueID")

                    'Weekly forecast
                    If dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drWkFc = dtWkFC.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drWkFc.BeginEdit() : drWkFc("Found") = 1 : drWkFc.EndEdit()
                        drActMon("wk Forecast") = drWkFc("wk Forecast") : drActMon("wk Special Qty") = drWkFc("wk Special Qty")
                    Else
                        drActMon("wk Forecast") = 0 : drActMon("wk Special Qty") = 0
                    End If

                    'Weekly actual
                    If dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drActWk = dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drActWk.BeginEdit() : drActWk("Found") = 1 : drActWk.EndEdit()
                        drActMon("wk Label") = drActWk("wk Label")
                        drActMon("wk QC") = drActWk("wk QC")
                        drActMon("wk Produce") = drActWk("wk Produce")
                    Else
                        drActMon("wk Label") = 0
                        drActMon("wk QC") = 0
                        drActMon("wk Produce") = 0
                    End If

                    If booNoRpt = True Then
                        drActMon("wk Variance") = (CInt(drActMon("wk Label")) + CInt(drActMon("wk QC")) + CInt(drActMon("wk Produce"))) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    'Produce Wip
                    If booInclProduceWip = True Then
                        If dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                            drProdWip = dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                            drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                            drActMon("Produce Wip") = drProdWip("Produce Wip")
                        End If
                    End If
                    dtMonAct.Rows.Add(drActMon)
                Next i
                dtMonAct.AcceptChanges()

                'Missing Weekly Forecast
                drMissing = dtWkFC.Select("Found = 0")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActMon = dtMonAct.NewRow
                    'wk forecast
                    drActMon("Customer") = drMissing(i)("Customer")
                    drActMon("Location") = drMissing(i)("Location")
                    drActMon("Model") = drMissing(i)("Model")
                    drActMon("Frequency") = drMissing(i)("Frequency")
                    drActMon("Baud Rate") = drMissing(i)("Baud Rate")
                    drActMon("wk Forecast") = drMissing(i)("wk Forecast")
                    drActMon("wk Special Qty") = drMissing(i)("wk Special Qty")
                    drActMon("mon Forecast") = 0
                    drActMon("mon Special Qty") = 0
                    drActMon("mon LQP") = 0
                    drActMon("UniqueID") = drMissing(i)("UniqueID")

                    'Weekly actual
                    If dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                        drActWk = dtWkAct.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                        drActWk.BeginEdit() : drActWk("Found") = 1 : drActWk.EndEdit()
                        drActMon("wk Label") = drActWk("wk Label")
                        drActMon("wk QC") = drActWk("wk QC")
                        drActMon("wk Produce") = drActWk("wk Produce")
                    Else
                        drActMon("wk Label") = 0
                        drActMon("wk QC") = 0
                        drActMon("wk Produce") = 0
                    End If

                    If booNoRpt = True Then
                        drActMon("wk Variance") = (CInt(drActMon("wk Label")) + CInt(drActMon("wk QC")) + CInt(drActMon("wk Produce"))) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    'Produce Wip
                    If booInclProduceWip = True Then
                        If dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                            drProdWip = dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                            drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                            drActMon("Produce Wip") = drProdWip("Produce Wip")
                        End If
                    End If

                    dtMonAct.Rows.Add(drActMon)
                Next i
                dtMonAct.AcceptChanges()

                'Missing Weekly Actual
                drMissing = dtWkAct.Select("Found = 0")
                For i = 0 To drMissing.Length - 1
                    drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                    drActMon = dtMonAct.NewRow
                    'wk forecast
                    drActMon("Customer") = drMissing(i)("Customer")
                    drActMon("Location") = drMissing(i)("Location")
                    drActMon("Model") = drMissing(i)("Model")
                    drActMon("Frequency") = drMissing(i)("Frequency")
                    drActMon("Baud Rate") = drMissing(i)("Baud Rate")
                    drActMon("wk Label") = drMissing(i)("wk Label")
                    drActMon("wk QC") = drMissing(i)("wk QC")
                    drActMon("wk Produce") = drMissing(i)("wk Produce")
                    drActMon("mon LQP") = 0
                    drActMon("mon Forecast") = 0
                    drActMon("mon Special Qty") = 0
                    drActMon("wk Forecast") = 0
                    drActMon("wk Special Qty") = 0
                    drActMon("UniqueID") = drMissing(i)("UniqueID")

                    If booNoRpt = True Then
                        drActMon("wk Variance") = (CInt(drActMon("wk Label")) + CInt(drActMon("wk QC")) + CInt(drActMon("wk Produce"))) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                        drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                    Else
                        drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                    End If

                    'Produce Wip
                    If booInclProduceWip = True Then
                        If dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'").Length > 0 Then
                            drProdWip = dtProduceWip.Select(" UniqueID = '" & drActMon("UniqueID") & "'")(0)

                            drProdWip.BeginEdit() : drProdWip("Found") = 1 : drProdWip.EndEdit()
                            drActMon("Produce Wip") = drProdWip("Produce Wip")
                        End If
                    End If

                    dtMonAct.Rows.Add(drActMon)
                Next i
                dtMonAct.AcceptChanges()

                'Missing Produce Wip
                If booInclProduceWip = True Then
                    drMissing = dtProduceWip.Select("Found = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found") = 1 : drMissing(i).EndEdit()

                        drActMon = dtMonAct.NewRow
                        'wk forecast
                        drActMon("Customer") = drMissing(i)("Customer")
                        drActMon("Location") = drMissing(i)("Location")
                        drActMon("Model") = drMissing(i)("Model")
                        drActMon("Frequency") = drMissing(i)("Frequency")
                        drActMon("Baud Rate") = drMissing(i)("Baud Rate")
                        drActMon("Produce Wip") = drMissing(i)("Produce Wip")
                        drActMon("wk Label") = 0
                        drActMon("wk QC") = 0
                        drActMon("wk Produce") = 0
                        drActMon("mon LQP") = 0
                        drActMon("mon Forecast") = 0
                        drActMon("mon Special Qty") = 0
                        drActMon("wk Forecast") = 0
                        drActMon("wk Special Qty") = 0
                        drActMon("UniqueID") = drMissing(i)("UniqueID")

                        If booNoRpt = True Then
                            drActMon("wk Variance") = (CInt(drActMon("wk Label")) + CInt(drActMon("wk QC")) + CInt(drActMon("wk Produce"))) - (CInt(drActMon("wk Forecast")) + CInt(drActMon("wk Special Qty")))
                            drActMon("mon Variance") = CInt(drActMon("mon LQP")) - (CInt(drActMon("mon Forecast")) + CInt(drActMon("mon Special Qty")))
                        Else
                            drActMon("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                            drActMon("mon Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        End If

                        dtMonAct.Rows.Add(drActMon)
                    Next i
                End If


                'NEW WAY: WEEKLY DATA-----------------------------------------------------------------------
                'Rename columns
                dtMonAct.Columns("wk Special Qty").ColumnName = "Sp Open" 'sp = Special, Rg = Regular
                dtMonAct.Columns("wk Forecast").ColumnName = "wk Rg FC"
                dtMonAct.Columns("mon Forecast").ColumnName = "mon Rg FC"
                dtMonAct.Columns("wk Produce").ColumnName = "wk Rg Produced"

                'Split Wk Produce to Wk LQP-Wk Special Produced and Wk Special Produced
                dtMonAct.Columns.Add(New DataColumn("wk Sp Produced", GetType(System.Int16)))
                For Each row In dtMonAct.Rows
                    row("wk Sp Produced") = 0
                Next

                'Reorder: Column 'wk Sp Produced' is last position now, so change its position after 'wk LQP'
                ReDim arrReOrder(dtMonAct.Columns.Count - 1)
                i = 0 : j = 0
                For Each col In dtMonAct.Columns
                    If col.ColumnName.ToUpper = "wk Sp Produced".ToUpper Then Exit For

                    If col.ColumnName.ToUpper = "wk Rg Produced".ToUpper AndAlso j = 0 Then
                        arrReOrder(i) = i : arrReOrder(i + 1) = dtMonAct.Columns.Count - 1 : j = 1
                    ElseIf j = 1 Then
                        arrReOrder(i + 1) = i
                    Else
                        arrReOrder(i) = i
                    End If
                    i += 1
                Next
                dtMonAct = objMisc.ReOrderTable(dtMonAct, arrReOrder)

                'Recalculation after new method
                For Each row In dtMonAct.Rows
                    row.BeginEdit()
                    If dtWkSpecialProduced.Rows.Count > 0 Then
                        filteredRows = dtWkSpecialProduced.Select("UniqueID='" & row("UniqueID") & "'")
                        For Each row2 In filteredRows
                            row("wk Sp Produced") = row2("Sp Produced")
                            row("wk Rg Produced") = row("wk Rg Produced") - row2("Sp Produced")
                        Next
                    End If
                    row("wk Variance") = (row("wk Rg Produced") + row("wk Label") + row("wk QC")) - (row("wk Rg FC") + row("Sp Open"))
                    ' row("wk Variance") = row("wk Rg Produced") - row("wk Rg FC") + row("Sp Open")
                    row.AcceptChanges()
                Next

                'NEW WAY: MONTHLY DATA-----------------------------------------------------------------------
                'Split Mon LQP to (Mon LQP - Mon Special Produced) and Mon Special Produced
                dtMonAct.Columns.Add(New DataColumn("mon Sp Produced", GetType(System.Int16)))
                For Each row In dtMonAct.Rows
                    row("mon Sp Produced") = 0
                Next

                'Reorder: Column 'mon Sp Produced' is last position now, so change its position after 'mon LQP'
                ReDim arrReOrder(dtMonAct.Columns.Count - 1)
                i = 0 : j = 0
                For Each col In dtMonAct.Columns
                    If col.ColumnName.ToUpper = "mon Sp Produced".ToUpper Then Exit For

                    If col.ColumnName.ToUpper = "mon LQP".ToUpper AndAlso j = 0 Then
                        arrReOrder(i) = i : arrReOrder(i + 1) = dtMonAct.Columns.Count - 1 : j = 1
                    ElseIf j = 1 Then
                        arrReOrder(i + 1) = i
                    Else
                        arrReOrder(i) = i
                    End If
                    i += 1
                Next
                dtMonAct = objMisc.ReOrderTable(dtMonAct, arrReOrder)

                'Recalculation after new method
                For Each row In dtMonAct.Rows
                    row.BeginEdit()
                    If dtMonSpecialProduced.Rows.Count > 0 Then
                        filteredRows = dtMonSpecialProduced.Select("UniqueID='" & row("UniqueID") & "'")
                        For Each row2 In filteredRows
                            row("mon Sp Produced") = row2("Sp Produced")
                            row("mon LQP") = row("mon LQP") - row2("Sp Produced")
                        Next
                    End If
                    ' row("mon Variance") = (row("mon Rg Produced") + row("mon Label") + row("mon QC")) - row("mon Rg FC") + row("Sp Open")
                    row("mon Variance") = row("mon LQP") - (row("mon Rg FC") + row("Sp Open"))
                    row.AcceptChanges()
                Next

                'for debug 
                'objMisc.DataTable2CSV(dtMonAct, "R:\FC vs Label QC Prodiced " & Format(Now, "yyyyMMddHHmmss") & ".csv", vbTab)

                'remove unwanted columns
                dtMonAct.Columns.Remove("mon Special Qty")
                dtMonAct.Columns.Remove("Found")
                If booNoRpt = False Then dtMonAct.Columns.Remove("UniqueID")
                dtMonAct.AcceptChanges()

                If booNoRpt = False Then
                    Dim objExcelRpt As New PSS.Data.ExcelReports()
                    strRptName = "AMS Forecasted vs LQP " & CDate(strToday).ToString("yyyyMMdd") & ".xls"
                    objExcelRpt.RunSimpleExcelFormat(dtMonAct, strRptName, New String() {"A", "B", "C", "D", "E"}, )
                End If
                Return dtMonAct
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtWkFC) : Generic.DisposeDT(dtMonFC) : Generic.DisposeDT(dtWkAct) : Generic.DisposeDT(dtMonAct)
                objMessMisc = Nothing
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Sub ApplyNewMethodWKFC(ByVal strCustIDs As String, ByVal strToday As String, ByVal iOpenStage As Integer, ByRef dtWKFC As DataTable)
            'Apply new method: reset old wkspecialQty=0,and update it with new data
            Dim dtSpecialOpen As DataTable
            Dim row, rowNew As DataRow
            Dim filteredRows() As DataRow

            Try
                'dtWkSpecial = Me.getCurrentWeekSpeicalFC(strCustIDs, strToday)
                dtSpecialOpen = Me.getCurrentSpecialOpen(strCustIDs, iOpenStage)
                Dim myObj As New PSS.Data.Buisness.Misc()
                ' myObj.DataTable2CSV(dtWkSpecial, "R:\WKSP_QTY.csv", vbTab) '";")
                For Each row In dtWKFC.Rows
                    row("wk Special Qty") = 0
                Next
                For Each row In dtSpecialOpen.Rows
                    filteredRows = dtWKFC.Select("UniqueID='" & row("UniqueID") & "'")
                    If filteredRows.Length > 0 Then 'Update
                        filteredRows(0)("wk Special Qty") = row("wkSpecialQty")
                    Else 'Add new
                        rowNew = dtWKFC.NewRow
                        rowNew("Customer") = row("Cust_Name1")
                        rowNew("Location") = row("Loc_Name")
                        rowNew("Model") = row("Model_Desc")
                        rowNew("Frequency") = row("Freq_Number")
                        rowNew("Baud Rate") = row("Baud_Number")
                        rowNew("wk Forecast") = 0
                        rowNew("wk Special Qty") = row("wkSpecialQty")
                        rowNew("wk Actual") = 0
                        rowNew("wk Variance") = "=RC[-1]-(RC[-3]+RC[-2])"
                        rowNew("UniqueID") = row("UniqueID")
                        rowNew("Found") = 0
                        dtWKFC.Rows.Add(rowNew)
                    End If
                Next
                ' myObj.DataTable2CSV(dtWkFC, "R:\WKSP_QTY2.csv", vbTab) '";")
                myObj = Nothing

                'Sort
                Dim dv As New DataView(dtWKFC)
                Dim dvRow As DataRowView
                Dim dtSorted As DataTable = dv.Table.Clone
                dv.Sort = "Customer, Location, Model, Frequency, Baud Rate"
                For Each dvRow In dv
                    dtSorted.ImportRow(dvRow.Row)
                Next

                dtWKFC = dtSorted

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtSpecialOpen)
            End Try
        End Sub

        '******************************************************************************************************************************************
        Private Function GetMessLQPCntByDateRange(ByVal strAMSCustIDs As String, ByVal strToday As String, _
                                                  ByVal booWeekly As Boolean, ByVal booQtyOnly As Boolean, ByVal booNoRpt As Boolean, _
                                                  Optional ByVal iModelID As Integer = 0, _
                                                  Optional ByVal iFreqID As Integer = 0, _
                                                  Optional ByVal iBaudID As Integer = 0, _
                                                  Optional ByVal iLocID As Integer = 0) As DataTable
            Dim strSql, strDateStart, strDateEnd As String
            Dim dtLabel, dtQC, dtProduce, dtTmp As DataTable
            Dim drLabel, drQC, drProduce, drMissing() As DataRow
            Dim i, j As Integer

            Try
                'define date range for either weekly or daily
                If booWeekly Then
                    strDateStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                    strDateEnd = Format(DateAdd(DateInterval.Day, (6), CDate(strDateStart)), "yyyy-MM-dd")
                Else
                    ' strDateStart = CDate(strToday).Year & "-" & CDate(strToday).Month.ToString.PadLeft(2, "0") & "-01"
                    ' strDateEnd = CDate(strToday).Year & "-" & CDate(strToday).Month.ToString.PadLeft(2, "0") & "-" & DateTime.DaysInMonth(CDate(strToday).Year, CDate(strToday).Month)
                    strSql = "select distinct MonthWeekStartDate,MonthWeekEnddate from tamsforecastedneed_month"
                    strSql &= " where MonthWeekStartDate <='" & strToday & "' and  MonthWeekEnddate >='" & strToday & "';"
                    dtTmp = Me._objDataProc.GetDataTable(strSql)
                    If dtTmp.Rows.Count > 0 Then
                        strDateStart = Format(dtTmp.Rows(0).Item("MonthWeekStartDate"), "yyyy-MM-dd")
                        strDateEnd = Format(dtTmp.Rows(0).Item("MonthWeekEnddate"), "yyyy-MM-dd")
                    Else
                        Throw New Exception("Can't find the fiscal month dates.")
                    End If
                End If

                '***********************************************************
                'LABEL
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then
                        strSql &= ", COUNT(*) as 'wk Label', 0 as 'wk QC', 0 as 'wk Produce' " & Environment.NewLine
                    Else
                        strSql &= ", 0 as 'wk Label', 0 as 'wk QC', 0 as 'wk Produce' " & Environment.NewLine
                    End If

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                    Else
                        strSql &= ", '=(RC[-1] + RC[-2] + RC[-3] )-(RC[-4]+RC[-5])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If
                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "

                    If booWeekly Then
                        strSql &= ", 0 as 'mon LQP' " & Environment.NewLine
                    Else
                        strSql &= ", COUNT(*) as 'mon LQP' " & Environment.NewLine
                    End If

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If

                    strSql &= ", 0 as 'Produce Wip' " & Environment.NewLine

                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If

                strSql &= " WHERE C.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND ( ( label_workdate between '" & strDateStart & "' AND '" & strDateEnd & "' AND qcwork_date is null AND Device_dateship is null )" & Environment.NewLine
                'strSql &= "    OR (  qcwork_date between '" & strDateStart & "' AND '" & strDateEnd & "' AND qcresult_id = 1 AND Device_dateship is null )" & Environment.NewLine
                'strSql &= "    OR ( Device_dateship between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' )" & Environment.NewLine
                strSql &= " ) " & Environment.NewLine
                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                dtLabel = Me._objDataProc.GetDataTable(strSql)

                '***********************************************************
                'QC
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then
                        strSql &= ", 0 as 'wk Label', COUNT(*) as 'wk QC', 0 as 'wk Produce' " & Environment.NewLine
                    Else
                        strSql &= ", 0 as 'wk Label', 0 as 'wk QC', 0 as 'wk Produce' " & Environment.NewLine
                    End If

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                    Else
                        strSql &= ", '=(RC[-1] + RC[-2] + RC[-3] )-(RC[-4]+RC[-5])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If

                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "
                    If booWeekly Then
                        strSql &= ", 0 as 'mon LQP' " & Environment.NewLine
                    Else
                        strSql &= ", COUNT(*) as 'mon LQP' " & Environment.NewLine
                    End If

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If

                    strSql &= ", 0 as 'Produce Wip' " & Environment.NewLine

                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If

                strSql &= " WHERE C.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND ( qcwork_date between '" & strDateStart & "' AND '" & strDateEnd & "' AND qcresult_id = 1 AND Device_dateship is null )" & Environment.NewLine
                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                dtQC = Me._objDataProc.GetDataTable(strSql)

                '***********************************************************
                'PRODUCE
                '***********************************************************
                strSql = "SELECT " & Environment.NewLine
                If booQtyOnly = False Then 'total qty only
                    strSql &= " C.Cust_Name1 as 'Customer', B.Loc_Name as 'Location', E.Model_Desc as 'Model' " & Environment.NewLine
                    strSql &= ", F.freq_Number as 'Frequency', G.baud_Number as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", 0 AS 'wk Forecast', 0 as 'wk Special Qty'"
                    If booWeekly Then
                        strSql &= ", 0 as 'wk Label', 0 as 'wk QC', COUNT(*) as 'wk Produce' " & Environment.NewLine
                    Else
                        strSql &= ", 0 as 'wk Label', 0 as 'wk QC', 0 as 'wk Produce' " & Environment.NewLine
                    End If

                    If booNoRpt = True Then
                        strSql &= ", 0 as 'wk Variance', '' as 'w' " & Environment.NewLine
                    Else
                        strSql &= ", '=(RC[-1] + RC[-2] + RC[-3] )-(RC[-4]+RC[-5])' as 'wk Variance', '' as 'Space1' " & Environment.NewLine
                    End If

                    strSql &= ", 0 AS 'mon Forecast', 0 as 'mon Special Qty' "
                    If booWeekly Then strSql &= ", 0 as 'mon LQP' " & Environment.NewLine Else strSql &= ", COUNT(*) as 'mon LQP' " & Environment.NewLine
                    If booNoRpt = True Then
                        strSql &= ", 0 as 'mon Variance', '' as 'm' " & Environment.NewLine
                    Else
                        strSql &= ", '=RC[-1]-(RC[-3]+RC[-2])' as 'mon Variance' " & Environment.NewLine
                    End If

                    strSql &= ", 0 as 'Produce Wip' " & Environment.NewLine

                    strSql &= ", Concat_WS('_', C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.baud_ID) as 'UniqueID', 0 as Found, 0 as Found2 " & Environment.NewLine
                Else
                    strSql &= " Count(*) cnt " & Environment.NewLine
                End If
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer C ON B.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata D ON A.Device_ID = D.Device_ID" & Environment.NewLine
                If booQtyOnly = False Then
                    strSql &= " INNER JOIN tmodel E ON A.Model_ID = E.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lfrequency F ON D.freq_ID = F.freq_ID" & Environment.NewLine
                    strSql &= " INNER JOIN lbaud G on D.baud_ID= G.baud_ID" & Environment.NewLine
                End If
                strSql &= " INNER JOIN tpallett H ON A.Pallett_ID = H.Pallett_ID" & Environment.NewLine

                strSql &= " WHERE H.CUST_ID IN ( " & strAMSCustIDs & " )" & Environment.NewLine
                If iLocID > 0 Then strSql &= " AND A.Loc_ID = " & iLocID & Environment.NewLine
                If iModelID > 0 Then strSql &= " AND A.Model_ID = " & iModelID & Environment.NewLine
                If iFreqID > 0 Then strSql &= " AND D.freq_ID = " & iFreqID & Environment.NewLine
                If iBaudID > 0 Then strSql &= " AND D.baud_ID = " & iBaudID & Environment.NewLine
                strSql &= " AND ( A.Device_dateship between '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59' )  " & Environment.NewLine
                strSql &= " AND H.Pallet_ShipType = 0 " & Environment.NewLine

                If booQtyOnly = False Then strSql &= " GROUP BY C.Cust_ID, B.Loc_ID, A.Model_ID, D.Freq_ID, D.Baud_ID "
                dtProduce = Me._objDataProc.GetDataTable(strSql)

                '***********************************************************
                'COMBINE DATA
                '***********************************************************
                If booQtyOnly = True Then
                    dtLabel.Rows(0).BeginEdit()
                    dtLabel.Rows(0)("cnt") = CInt(dtLabel.Rows(0)("cnt")) + CInt(dtQC.Rows(0)("cnt")) + CInt(dtProduce.Rows(0)("cnt"))
                    dtLabel.Rows(0).EndEdit()
                Else
                    For Each drLabel In dtLabel.Rows
                        drLabel.BeginEdit()

                        If dtQC.Select("UniqueID = '" & drLabel("UniqueID") & "'").Length > 0 Then
                            drQC = dtQC.Select("UniqueID = '" & drLabel("UniqueID") & "'")(0)
                            drQC.BeginEdit() : drQC("Found2") = 1 : drQC.EndEdit()

                            If booWeekly Then drLabel("wk QC") = drQC("wk QC") Else drLabel("mon LQP") = CInt(drLabel("mon LQP")) + CInt(drQC("mon LQP"))
                        End If

                        If dtProduce.Select("UniqueID = '" & drLabel("UniqueID") & "'").Length > 0 Then
                            drProduce = dtProduce.Select("UniqueID = '" & drLabel("UniqueID") & "'")(0)
                            drProduce.BeginEdit() : drProduce("Found2") = 1 : drProduce.EndEdit()

                            If booWeekly Then drLabel("wk Produce") = drProduce("wk Produce") Else drLabel("mon LQP") = CInt(drLabel("mon LQP")) + CInt(drProduce("mon LQP"))
                        End If

                        drLabel.EndEdit()
                    Next drLabel

                    drMissing = dtQC.Select("Found2 = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found2") = 1 : drMissing(i).EndEdit()

                        drLabel = dtLabel.NewRow
                        For j = 0 To dtLabel.Columns.Count - 1
                            drLabel(j) = drMissing(i)(j)
                        Next j

                        If dtProduce.Select("UniqueID = '" & drMissing(i)("UniqueID") & "'").Length > 0 Then
                            drProduce = dtProduce.Select("UniqueID = '" & drMissing(i)("UniqueID") & "'")(0)
                            drProduce.BeginEdit() : drProduce("Found2") = 1 : drProduce.EndEdit()

                            If booWeekly Then drLabel("wk Produce") = drProduce("wk Produce") Else drLabel("mon LQP") = CInt(drLabel("mon LQP")) + CInt(drProduce("mon LQP"))
                        End If

                        dtLabel.Rows.Add(drLabel)
                    Next i
                    dtLabel.AcceptChanges()

                    drMissing = dtProduce.Select("Found2 = 0")
                    For i = 0 To drMissing.Length - 1
                        drMissing(i).BeginEdit() : drMissing(i)("Found2") = 1 : drMissing(i).EndEdit()
                        dtLabel.ImportRow(drMissing(i))
                    Next i
                    dtLabel.AcceptChanges()

                    '***********************************************************

                    dtLabel.Columns.Remove("Found2") : dtLabel.AcceptChanges()
                End If

                Return dtLabel
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtLabel) : Generic.DisposeDT(dtQC) : Generic.DisposeDT(dtProduce)
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Function InsertMonthFC(ByVal iYear As Integer, ByVal iMonth As Integer, ByVal dt As DataTable) As Integer
            Dim strSql As String = ""
            Dim R1 As DataRow
            Dim i As Integer

            Try
                For Each R1 In dt.Rows
                    strSql = "INSERT INTO tamsforecastedneed_Month ( " & Environment.NewLine
                    strSql &= " FC_Year, FC_Month, Cust_ID, Loc_ID, Model_ID, Freq_ID, Baud_ID, mnForecast, mnSpecialQty, NewUniqueID, UpdateDate, UpdateUserID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iYear & ", " & iMonth.ToString.PadLeft(2, "0") & ", " & R1("Cust_ID") & ", " & R1("Loc_ID") & ", " & R1("Model_ID") & ", " & R1("Freq_ID") & ", " & R1("baud_ID") & Environment.NewLine
                    strSql &= ", " & R1("mnForecast") & ", " & R1("mnSpecialQty") & ", '" & R1("UniqueID") & "', now(), 241 " & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function CheckFCDemand(ByVal strSN As String, ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strFreqNo As String, ByVal iBaudID As Integer) As Boolean
            Dim booReturnVal As Boolean = False, booWeeklyReprint As Boolean = False, booMonthlyReprint As Boolean = False
            Dim dt, dtMonthlyFC, dtWklyFC, dtMonthlyLQP, dtWklyLQP As DataTable
            Dim dteLabelWrkDate, dtetoday, dteWeekStart, dteWeekEnd As Date
            Dim iMonthlyLQP, iWklyLQP, iMonthlyFC, iWklyFC, iFreqID, iModelID As Integer
            Dim objMessMisc As New MessMisc()
            Dim objMessLabel As New Data.Buisness.MessLabel()
            Dim strRespToExceedWkFCMagicNo, strRespToExceedMonFCMagicNo As String

            Try
                dt = objMessLabel.GetMessDeviceInfoForLabel(strSN, iCustID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Device does not existed in WIP.")
                Else
                    dtetoday = CDate(CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd"))

                    iModelID = CInt(dt.Rows(0)("Model_ID"))
                    iFreqID = objMessMisc.GetFreqIDByFreqNo(strFreqNo)

                    If Not IsDBNull(dt.Rows(0)("label_workdate")) Then 'determine if reprint or not
                        'Define this week date range
                        dteWeekStart = Format(DateAdd(DateInterval.Day, (Weekday(CDate(dtetoday), FirstDayOfWeek.Monday) - 1) * -1, CDate(dtetoday)), "yyyy-MM-dd")
                        dteWeekEnd = Format(DateAdd(DateInterval.Day, (6), CDate(dteWeekStart)), "yyyy-MM-dd")
                        dteLabelWrkDate = CDate(dt.Rows(0)("label_workdate"))

                        'Weekly Reprint
                        If Year(dteLabelWrkDate) = Year(dtetoday) AndAlso Month(dteLabelWrkDate) = Month(dtetoday) AndAlso (dteLabelWrkDate >= dteWeekStart AndAlso dteLabelWrkDate <= dteWeekEnd) Then
                            booWeeklyReprint = True
                        End If

                        'Monthly Reprint
                        If Year(dteLabelWrkDate) = Year(dtetoday) AndAlso Month(dteLabelWrkDate) = Month(dtetoday) Then
                            booMonthlyReprint = True
                        End If
                    End If

                    '************************************
                    If booWeeklyReprint AndAlso booMonthlyReprint Then 'when RELABEL/REPRINT
                        booReturnVal = True
                    Else 'LABEL/NEW PRINT
                        '*************************************************************
                        'MAGIC # DEFINE HOW TO RESPONSE IF WEEKLY OR MONTH EXCEED FC + 5%
                        '0: Do nothing   1: Stop    2: Warning
                        '*************************************************************
                        strRespToExceedWkFCMagicNo = ModManuf.GetExceptionCriteria("AMS_WKLY_AQP_CHECKPOINT", "Generic").Trim
                        strRespToExceedMonFCMagicNo = ModManuf.GetExceptionCriteria("AMS_MONTHLY_AQP_CHECKPOINT", "Generic").Trim
                        '*************************************************************

                        'Stop if monthly LQP > ( FC + 5%)
                        If booMonthlyReprint = False Then
                            'Monthly FC
                            dtMonthlyFC = objMessMisc.GetMonthlyForecasted(iCustID, dtetoday, iModelID, iFreqID, iBaudID, iLocID)
                            If dtMonthlyFC.Rows.Count > 0 Then iMonthlyFC = CInt(dtMonthlyFC.Rows(0)("mnForecast")) + CInt(dtMonthlyFC.Rows(0)("mnSpecialQty"))
                            If iMonthlyFC = 0 Then Throw New Exception("There is no monthly forecast for selected model, frequency and baud rate.")

                            dtMonthlyLQP = Me.GetMessLQPCntByDateRange_Sum(iCustID, dtetoday.ToString("yyyy-MM-dd"), False, True, True, iModelID, iFreqID, iBaudID, iLocID)
                            If dtMonthlyLQP.Rows.Count > 0 Then iMonthlyLQP = CInt(dtMonthlyLQP.Rows(0)("cnt"))
                            If iMonthlyLQP > (iMonthlyFC * 1.05) Then
                                If strRespToExceedMonFCMagicNo.Length = 0 OrElse strRespToExceedMonFCMagicNo = "0" Then
                                    'Do nothing
                                ElseIf strRespToExceedMonFCMagicNo = "1" Then
                                    Throw New Exception("Monthly LQP has exceeded the forecast + 5%. Please contact your supervisor.")
                                ElseIf strRespToExceedMonFCMagicNo = "2" Then
                                    MessageBox.Show("Monthly LQP has exceeded the forecast + 5%. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    Throw New Exception("Can't define what to do when LQP has exceeded monthly FC + 5%.")
                                End If
                            End If
                        End If

                        'Stop if weekly LQP > ( FC + 5%)
                        If booWeeklyReprint = False Then
                            'Weekly FC
                            dtWklyFC = Me.GetAMSWkForecast(iCustID, dtetoday.ToString("yyyy-MM-dd"), True, True, iModelID, iFreqID, iBaudID, iLocID)
                            If dtWklyFC.Rows.Count > 0 Then iWklyFC = CInt(dtWklyFC.Rows(0)("Forecast"))
                            'If iWklyFC = 0 AndAlso MessageBox.Show("No weekly forecast for selected model, frequency and baud rate. Are you sure you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Return False
                            If iWklyFC = 0 Then Throw New Exception("No weekly forecast for selected model, frequency and baud rate.")

                            dtWklyLQP = Me.GetMessLQPCntByDateRange_Sum(iCustID, dtetoday.ToString("yyyy-MM-dd"), True, True, True, iModelID, iFreqID, iBaudID, iLocID)
                            If dtWklyLQP.Rows.Count > 0 Then iWklyLQP = CInt(dtWklyLQP.Rows(0)("cnt"))
                            If iWklyLQP > (iWklyFC * 1.05) Then
                                If strRespToExceedWkFCMagicNo.Length = 0 OrElse strRespToExceedWkFCMagicNo = "0" Then
                                    'Do nothing
                                ElseIf strRespToExceedWkFCMagicNo = "1" Then
                                    Throw New Exception("Weekly LQP has exceeded the forecast + 5%. Please contact with your supervisor.")
                                ElseIf strRespToExceedWkFCMagicNo = "2" Then
                                    MessageBox.Show("Weekly LQP has exceeded the forecast + 5%. Please check with your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else
                                    Throw New Exception("Can't define what to do when LQP has exceeded weekly FC + 5%.")
                                End If
                            End If
                        End If

                        booReturnVal = True
                    End If

                    '************************************
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtMonthlyFC) : Generic.DisposeDT(dtWklyFC) : Generic.DisposeDT(dtMonthlyLQP) : Generic.DisposeDT(dtWklyLQP)
                objMessMisc = Nothing : objMessLabel = Nothing
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function getCurrentSpecialOpen(ByVal strCustIDs As String, ByVal iOpenStage As Integer) As DataTable

            'Get current special open qty.
            'iOpenStage: 0 = Special FC Available
            'iOpenStage: 1 = Special FC Available + Special FC in boxes (open or closed)
            'iOpenStage: 2 = Special FC Available + Special FC in boxes (open or closed) + Special FC Produced, but not dock shipped yet
            'iOpenStage: Else throw exception

            Dim strSql As String, strS As String = ""
            ' Dim strToday As String = ""
            Dim dtTmp As DataTable
            Dim dtSpecialFC_Available As DataTable
            Dim dtSpecialFC_Inbox As DataTable
            Dim dtSpecialFC_Shipped As DataTable
            Dim dtOutput As DataTable
            Dim filteredRows() As DataRow
            Dim ds As New DataSet()
            Dim row, row2 As DataRow, col As DataColumn
            Dim rowNew As DataRow
            Dim strWeekBeginDate As String = "", strWeekEndDate As String = ""
            Dim arrlstUniqueIDs As New ArrayList()
            Dim iRowCount As Integer = 0, i As Integer = 0
            Dim iCustID As Integer = 0, iFCQty As Integer = 0
            Dim strArr()
            Dim bHasIt As Boolean

            Try

                'Exception
                If iOpenStage < 0 OrElse iOpenStage > 2 Then
                    Throw New Exception("Function getCurrentSpeicalOpen: Invalid OpenStage")
                End If

                'Output table definition
                strSql = "SELECT '' AS UniqueID,  0 AS wkSpecialQty,0 AS Cust_ID,0 AS Loc_ID,0 AS Model_ID,0 AS Freq_ID,0 AS Baud_ID" & Environment.NewLine
                strSql &= " ,'' AS Cust_Name1,'' AS Loc_Name,'' AS Model_Desc,'' AS Freq_Number,'' AS Baud_Number" & Environment.NewLine
                dtTmp = Me._objDataProc.GetDataTable(strSql)
                dtOutput = dtTmp.Clone : dtTmp = Nothing


                'Special FC Available, GROUP BY
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID) AS UniqueID" & Environment.NewLine
                'strSql &= " ,0 as mnForecast,SUM(A.SpecialRequestedQty) as SpecialRequestedQty,SUM(A.SpecialShippedQty) as SpecialShippedQty" & Environment.NewLine
                strSql &= " ,SUM(A.SpecialRequestedQty-A.SpecialShippedQty) as wkSpecialQty" & Environment.NewLine
                strSql &= " ,A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID as Model_ID,A.PSSI_Freq_ID as Freq_ID,A.PSSI_Baud_ID as baud_ID,B.Cust_Name1,C.Loc_Name,A.AMS_Model as Model_Desc" & Environment.NewLine
                strSql &= " ,A.AMS_Freq as freq_Number,AMS_Baud as baud_Number" & Environment.NewLine ',COUNT(*) as RecCount" & Environment.NewLine
                strSql &= " FROM tamsforecastedneed_Special A" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer B on A.Cust_ID = B.Cust_ID INNER JOIN tlocation C on A.Loc_ID = C.Loc_ID" & Environment.NewLine
                strSql &= " WHERE (A.SpecialRequestedQty-A.SpecialShippedQty)>0" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID" & Environment.NewLine
                strSql &= " ORDER BY A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID;" & Environment.NewLine

                dtSpecialFC_Available = Me._objDataProc.GetDataTable(strSql)
                If dtSpecialFC_Available.Rows.Count > 0 Then
                    dtOutput = dtSpecialFC_Available.Copy
                End If
                If iOpenStage = 0 Then Return dtOutput


                'Special FC in boxes (open or closed) (not produced), GROUP BY
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,Count(*) as wkSpecialQty,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
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
                strSql &= " AND C.AFSPQTY_ID > 0" & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " ORDER BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID;"

                dtSpecialFC_Inbox = Me._objDataProc.GetDataTable(strSql)
                If dtOutput.Rows.Count = 0 Then
                    dtOutput = dtSpecialFC_Inbox.Copy
                Else
                    For Each row In dtSpecialFC_Inbox.Rows
                        filteredRows = dtOutput.Select("UniqueID='" & row("UniqueID") & "'")
                        If filteredRows.Length = 0 Then
                            dtOutput.ImportRow(row)
                        Else
                            For Each row2 In filteredRows
                                row2.BeginEdit()
                                row2("wkSpecialQty") = row2("wkSpecialQty") + row("wkSpecialQty")
                                row2.AcceptChanges()
                            Next
                            'For Each row2 In dtOutput.Rows
                            '    If row("UniqueID") = row2("UniqueID") Then 'update
                            '        row2.BeginEdit() : row2("wkSpecialQty") = row2("wkSpecialQty") + row("wkSpecialQty")
                            '        row2.AcceptChanges() : Exit For
                            '    End If
                            'Next
                        End If
                    Next
                End If
                If iOpenStage = 1 Then Return dtOutput


                'Special FC Produced, but not dock shipped yet, GROUP BY
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,Count(*) as wkSpecialQty,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSql &= " FROM  tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer E ON A.Cust_ID =E.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation H ON A.Loc_ID =H.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency F ON C.Freq_ID=F.Freq_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbaud G ON C.Baud_ID=G.Baud_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallet_ShipType=0 AND A.Pallet_Invalid = 0" & Environment.NewLine
                strSql &= " AND A.pkslip_ID is null AND B.device_dateship is not null" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                strSql &= " AND C.AFSPQTY_ID >0" & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " ORDER BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID;"

                dtSpecialFC_Shipped = Me._objDataProc.GetDataTable(strSql)
                If dtOutput.Rows.Count = 0 Then
                    dtOutput = dtSpecialFC_Shipped.Copy
                Else
                    For Each row In dtSpecialFC_Shipped.Rows
                        filteredRows = dtOutput.Select("UniqueID='" & row("UniqueID") & "'")
                        If filteredRows.Length = 0 Then
                            dtOutput.ImportRow(row)
                        Else
                            For Each row2 In filteredRows
                                row2.BeginEdit()
                                row2("wkSpecialQty") = row2("wkSpecialQty") + row("wkSpecialQty")
                                row2.AcceptChanges()
                            Next
                            'For Each row2 In dtOutput.Rows
                            '    If row("UniqueID") = row2("UniqueID") Then 'update
                            '        row2.BeginEdit() : row2("wkSpecialQty") = row2("wkSpecialQty") + row("wkSpecialQty")
                            '        row2.AcceptChanges() : Exit For
                            '    End If
                            'Next
                        End If
                    Next
                End If

                If iOpenStage = 2 Then Return dtOutput

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtTmp) : Generic.DisposeDT(dtSpecialFC_Available) : Generic.DisposeDT(dtSpecialFC_Inbox)
                Generic.DisposeDT(dtSpecialFC_Shipped)
            End Try
        End Function


        '******************************************************************************************************************************************
        Public Function getCurrentWeekSpeicalFC(ByVal strCustIDs As String, ByVal strToday As String) As DataTable
            Dim strSql As String, strS As String = ""
            ' Dim strToday As String = ""
            Dim dtTmp As DataTable
            Dim dtSpecialFC_Available As DataTable
            Dim dtSpecialFC_Inbox As DataTable
            Dim dtSpecialFC_Shipped As DataTable
            Dim dtOutput As DataTable
            Dim filteredRows() As DataRow
            Dim ds As New DataSet()
            Dim row, row2 As DataRow, col As DataColumn
            Dim rowNew As DataRow
            Dim strWeekBeginDate As String = "", strWeekEndDate As String = ""
            Dim arrlstUniqueIDs As New ArrayList()
            Dim iRowCount As Integer = 0, i As Integer = 0
            Dim iCustID As Integer = 0, iFCQty As Integer = 0
            Dim strArr()
            Dim bHasIt As Boolean

            Try

                'strToday = Format(dteToday, "yyyy-MM-dd")

                'Output table definition
                strSql = "SELECT '' AS UniqueID,  0 AS wkSpecialQty,0 AS Cust_ID,0 AS Loc_ID,0 AS Model_ID,0 AS Freq_ID,0 AS Baud_ID" & Environment.NewLine
                strSql &= " ,'' AS Cust_Name1,'' AS Loc_Name,'' AS Model_Desc,'' AS Freq_Number,'' AS Baud_Number" & Environment.NewLine
                dtTmp = Me._objDataProc.GetDataTable(strSql)
                dtOutput = dtTmp.Clone : dtTmp = Nothing

                'Week begin and End date
                strWeekBeginDate = Format(DateAdd(DateInterval.Day, (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1) * -1, CDate(strToday)), "yyyy-MM-dd")
                strWeekEndDate = Format(DateAdd(DateInterval.Day, (6), CDate(strWeekBeginDate)), "yyyy-MM-dd")


                'Special FC Available, GROUP BY
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID) AS UniqueID" & Environment.NewLine
                'strSql &= " ,0 as mnForecast,SUM(A.SpecialRequestedQty) as SpecialRequestedQty,SUM(A.SpecialShippedQty) as SpecialShippedQty" & Environment.NewLine
                strSql &= " ,SUM(A.SpecialRequestedQty-A.SpecialShippedQty) as wkSpecialQty" & Environment.NewLine
                strSql &= " ,A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID as Model_ID,A.PSSI_Freq_ID as Freq_ID,A.PSSI_Baud_ID as baud_ID,B.Cust_Name1,C.Loc_Name,A.AMS_Model as Model_Desc" & Environment.NewLine
                strSql &= " ,A.AMS_Freq as freq_Number,AMS_Baud as baud_Number" & Environment.NewLine ',COUNT(*) as RecCount" & Environment.NewLine
                strSql &= " FROM tamsforecastedneed_Special A" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer B on A.Cust_ID = B.Cust_ID INNER JOIN tlocaiton C on A.Loc_ID = C.Loc_ID" & Environment.NewLine
                strSql &= " WHERE (A.SpecialRequestedQty-A.SpecialShippedQty)>0" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,A.PSSI_Model_ID,A.PSSI_Freq_ID,A.PSSI_baud_ID;" & Environment.NewLine

                dtSpecialFC_Available = Me._objDataProc.GetDataTable(strSql)

                'Special FC in boxes (open or closed), GROUP BY
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,Count(*) as wkSpecialQty,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
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
                strSql &= " AND C.AFSPQTY_ID > 0" & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID;"

                dtSpecialFC_Inbox = Me._objDataProc.GetDataTable(strSql)

                'Special FC shipped, GROUP BY
                strSql = "SELECT Concat_WS('_',A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID) AS UniqueID" & Environment.NewLine
                strSql &= " ,Count(*) as wkSpecialQty,A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID" & Environment.NewLine
                strSql &= " ,E.Cust_Name1,H.Loc_Name,D.Model_Desc,F.Freq_Number,G.Baud_Number" & Environment.NewLine
                strSql &= " FROM  tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer E ON A.Cust_ID =E.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation H ON A.Loc_ID =H.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency F ON C.Freq_ID=F.Freq_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbaud G ON C.Baud_ID=G.Baud_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallet_ShipType=0 AND A.Pallet_Invalid = 0" & Environment.NewLine
                strSql &= " AND B.device_dateship BETWEEN '" & strWeekBeginDate & " 00:00:00' AND '" & strWeekEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= " AND A.Cust_ID IN ( " & strCustIDs & ") " & Environment.NewLine
                strSql &= " AND C.AFSPQTY_ID >0" & Environment.NewLine
                strSql &= " GROUP BY A.Cust_ID,A.Loc_ID,D.Model_ID,F.Freq_ID,G.Baud_ID;"

                dtSpecialFC_Shipped = Me._objDataProc.GetDataTable(strSql)


                'Calculations---------------------------------------------------------------------------------
                'Available
                If dtSpecialFC_Available.Rows.Count > 0 Then
                    dtOutput = dtSpecialFC_Available.Copy
                End If

                'In Boxes
                If dtOutput.Rows.Count = 0 Then
                    dtOutput = dtSpecialFC_Inbox.Copy
                Else
                    For Each row In dtSpecialFC_Inbox.Rows
                        filteredRows = dtOutput.Select("UniqueID='" & row("UniqueID") & "'")
                        If filteredRows.Length = 0 Then
                            dtOutput.ImportRow(row)
                        Else
                            For Each row2 In dtOutput.Rows
                                If row("UniqueID") = row2("UniqueID") Then 'update
                                    row2.BeginEdit() : row2("wkSpecialQty") = row2("wkSpecialQty") + row("wkSpecialQty")
                                    row2.AcceptChanges() : Exit For
                                End If
                            Next
                        End If
                    Next
                End If

                'Shipped in the week
                If dtOutput.Rows.Count = 0 Then
                    dtOutput = dtSpecialFC_Shipped.Copy
                Else
                    For Each row In dtSpecialFC_Shipped.Rows
                        filteredRows = dtOutput.Select("UniqueID='" & row("UniqueID") & "'")
                        If filteredRows.Length = 0 Then
                            dtOutput.ImportRow(row)
                        Else
                            For Each row2 In dtOutput.Rows
                                If row("UniqueID") = row2("UniqueID") Then 'update
                                    row2.BeginEdit() : row2("wkSpecialQty") = row2("wkSpecialQty") + row("wkSpecialQty")
                                    row2.AcceptChanges() : Exit For
                                End If
                            Next
                        End If
                    Next
                End If

                Return dtOutput

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtTmp) : Generic.DisposeDT(dtSpecialFC_Available) : Generic.DisposeDT(dtSpecialFC_Inbox)
                Generic.DisposeDT(dtSpecialFC_Shipped)
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Sub CreateMessagingWIPReport(ByVal strCustIDs As String, ByVal bInclAllColumns As Boolean,
                                            ByVal bSummaryOnly As Boolean, ByVal bIncludeWIPHoldInSummaryReport As Boolean,
                                            ByRef dtResult As DataTable)

            Dim strSQL, strRptName, strS As String
            Dim dt1, dt2, dt3, dtFinal, dtCustomers, dtWIPWorkStations, dtSummary, dtSummaryFinal As DataTable
            Dim dtDetails_1, dtDetails_2 As DataTable
            Dim dtTmp As DataTable
            Dim row, row2 As DataRow
            Dim rowNew As DataRow
            Dim i, j, k As Integer
            Dim arrListNewKeys As New ArrayList()
            Dim arrListWorkStationIDs As New ArrayList()
            Dim dtFilteredRows() As DataRow

            Try

                'WIP: Not produced 
                'strSQL = "select I.Cust_name1 as 'Customer', A.device_SN as 'Serial Number',D.Model_desc as 'Model Desc',F.Freq_Number as 'Frequency'" & Environment.NewLine
                strSQL = "select IF(A.Loc_ID=3404 OR A.Loc_ID=3405, CONCAT_WS(' - ', I.Cust_name1, H.Loc_Name), I.Cust_name1) as 'Customer', A.device_SN as 'Serial Number',D.Model_desc as 'Model Desc',F.Freq_Number as 'Frequency'" & Environment.NewLine
                strSQL &= " ,G.Baud_number as 'Baud Rate',B.CapCode"
                strSQL &= " ,CASE WHEN B.wipowner_id < 201 THEN C.wipowner_desc ELSE wip2.wipowner_desc END AS 'WIP Location'"
                strSQL &= " ,if(B.wipowner_id=3,J.cc_desc,K.wipownersubloc_desc) as 'Sublocation'"
                strSQL &= " ,W.WO_CustWO as 'Work Order',date_format(A.device_daterec,'%Y-%m-%d') as 'Received Date'" & Environment.NewLine
                strSQL &= " ,date_format(A.device_dateship,'%Y-%m-%d') as 'Produced Date'" & Environment.NewLine
                strSQL &= " ,date_format(B.wipowner_EntryDt,'%Y-%m-%d') as 'Workstation Entry Date'" & Environment.NewLine
                strSQL &= " ,E.Pallett_Name as 'Box',B.wipowner_id,C.Ams_WIPFlow,A.Device_ID,D.model_ID,F.freq_ID,G.baud_ID,A.WO_ID,A.pallett_id,I.cust_id " & Environment.NewLine
                strSQL &= " ,Concat_WS('_','k',A.Model_ID,F.Freq_ID,G.baud_ID) as 'NewKey',Concat_WS('_','k',C.wipowner_id) as 'NewWSID'" & Environment.NewLine
                strSQL &= " from tdevice A" & Environment.NewLine
                strSQL &= " inner join tmessdata B on A.device_id=B.device_id" & Environment.NewLine
                strSQL &= " inner join tmodel D on A.model_ID=D.model_ID" & Environment.NewLine
                strSQL &= " inner join tlocation H on A.Loc_ID=H.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tcustomer I on H.Cust_ID=I.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tworkorder W on A.WO_ID=W.WO_ID" & Environment.NewLine
                strSQL &= " LEFT join lwipowner C on B.wipowner_id=C.wipowner_id" & Environment.NewLine
                strSQL &= " LEFT join lwipowner_SET2 wip2 on B.wipowner_id = wip2.wipowner_id" & Environment.NewLine
                strSQL &= " left join lfrequency F on B.freq_ID=F.freq_ID" & Environment.NewLine
                strSQL &= " left join lbaud G on B.baud_ID=G.baud_ID" & Environment.NewLine
                strSQL &= " left join tpallett E on A.pallett_id=E.pallett_id" & Environment.NewLine
                strSQL &= " left join tcostcenter J on A.cc_ID=J.cc_ID" & Environment.NewLine
                strSQL &= " left join lwipownersubloc K on B.wipownersubloc_id=K.wipownersubloc_id" & Environment.NewLine
                strSQL &= " where  "
                strSQL &= " I.cust_id in (" & strCustIDs & ") and "
                strSQL &= " A.device_DateShip is null and "
                strSQL &= " B.wipowner_id <> 7 and "    ' Exclude In-Transit
                strSQL &= " B.wipowner_id <> 201 and "    ' Exclude WH
                strSQL &= " B.wipowner_id is not null;" & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSQL)
                'dtResult = dt1
                'MessageBox.Show("dt1.Rows.Count=" & dt1.Rows.Count)

                'WIP: Produced but not dock shipped
                'strSQL = "select G.Cust_Name1 as 'Customer',B.Device_SN as 'Serial Number', D.Model_Desc as 'Model Desc',H.Freq_number as 'Frequency'" & Environment.NewLine
                strSQL = "select IF(B.Loc_ID=3404 OR B.Loc_ID=3405, CONCAT_WS(' - ', G.Cust_name1, F.Loc_Name), G.Cust_name1) as 'Customer',B.Device_SN as 'Serial Number', D.Model_Desc as 'Model Desc',H.Freq_number as 'Frequency'" & Environment.NewLine
                strSQL &= " ,I.Baud_Number as'Baud Rate',C.CapCode,E.wipowner_desc as 'WIP Location',if(C.wipowner_id=3,J.cc_desc,K.wipownersubloc_desc) as 'Sublocation',W.WO_CustWO as 'Work Order',date_format(B.device_daterec,'%Y-%m-%d') as 'Received Date'" & Environment.NewLine
                strSQL &= " ,date_format(B.device_dateship,'%Y-%m-%d') as 'Produced Date'" & Environment.NewLine
                strSQL &= " ,date_format(C.wipowner_EntryDt,'%Y-%m-%d') as 'Workstation Entry Date'" & Environment.NewLine
                strSQL &= " ,A.Pallett_Name as 'Box',C.wipowner_id,E.Ams_WIPFlow,B.Device_ID,D.model_ID,H.freq_ID,I.baud_ID,B.WO_ID,A.pallett_id,A.cust_id" & Environment.NewLine
                strSQL &= " ,Concat_WS('_','k',D.Model_ID,H.Freq_ID,I.baud_ID) as 'NewKey',Concat_WS('_','k',C.wipowner_id) as 'NewWSID'" & Environment.NewLine
                strSQL &= " from tpallett A" & Environment.NewLine
                strSQL &= " inner join tdevice B on A.pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSQL &= " inner join tmessdata C on B.device_ID=C.device_ID" & Environment.NewLine
                strSQL &= " left join lwipowner E on C.wipowner_id=E.wipowner_id" & Environment.NewLine
                strSQL &= " inner join tmodel D on B.model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " inner join tlocation F on B.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tcustomer G on F.Cust_ID=G.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tworkorder W on B.WO_ID=W.WO_ID" & Environment.NewLine
                strSQL &= " left join lfrequency H on C.freq_ID=H.freq_ID" & Environment.NewLine
                strSQL &= " left join lbaud I on C.baud_ID=I.baud_ID" & Environment.NewLine
                strSQL &= " left join tcostcenter J on B.cc_ID=J.cc_ID" & Environment.NewLine
                strSQL &= " left join lwipownersubloc K on C.wipownersubloc_id=K.wipownersubloc_id" & Environment.NewLine
                strSQL &= " where A.pkslip_ID is null and  A.cust_id in (" & strCustIDs & ");" & Environment.NewLine
                'strSQL &= " where A.pkslip_ID is null and  "
                'strSQL &= " A.pallett_ReadyToShipFlg = 1 and "
                'strSQL &= " A.cust_id in (" & strCustIDs & ");"
                dt2 = Me._objDataProc.GetDataTable(strSQL)
                'dtResult = dt2
                'MessageBox.Show("dt2.Rows.Count=" & dt2.Rows.Count)

                'WIP: American Messaging DBR Auto Shipped
                'strSQL = "select  G.Cust_Name1 as 'Customer',B.Device_SN as 'Serial Number', D.Model_Desc as 'Model Desc',H.Freq_number as 'Frequency'" & Environment.NewLine
                strSQL = "select IF(B.Loc_ID=3404 OR B.Loc_ID=3405, CONCAT_WS(' - ', G.Cust_name1, F.Loc_Name), G.Cust_name1) as 'Customer',B.Device_SN as 'Serial Number', D.Model_Desc as 'Model Desc',H.Freq_number as 'Frequency'" & Environment.NewLine
                strSQL &= " ,I.Baud_Number as'Baud Rate',C.CapCode,E.wipowner_desc as 'WIP Location',if(C.wipowner_id=3,J.cc_desc,K.wipownersubloc_desc) as 'Sublocation',W.WO_CustWO as 'Work Order',date_format(B.device_daterec,'%Y-%m-%d') as 'Received Date'" & Environment.NewLine
                strSQL &= " ,date_format(B.device_dateship,'%Y-%m-%d') as 'Produced Date'" & Environment.NewLine
                strSQL &= " ,date_format(C.wipowner_EntryDt,'%Y-%m-%d') as 'Workstation Entry Date'" & Environment.NewLine
                strSQL &= " ,'' as 'Box',C.wipowner_id,E.Ams_WIPFlow,B.Device_ID,D.model_ID,H.freq_ID,I.baud_ID,B.WO_ID,null as pallett_id,G.cust_id" & Environment.NewLine
                strSQL &= " ,Concat_WS('_','k',D.Model_ID,H.Freq_ID,I.baud_ID) as 'NewKey',Concat_WS('_','k',C.wipowner_id) as 'NewWSID'" & Environment.NewLine
                strSQL &= " from tdevice B" & Environment.NewLine
                strSQL &= " inner join tmessdata C on B.device_ID=C.device_ID" & Environment.NewLine
                strSQL &= " left join lwipowner E on C.wipowner_id=E.wipowner_id" & Environment.NewLine
                strSQL &= " inner join tmodel D on B.model_ID=D.Model_ID" & Environment.NewLine
                strSQL &= " inner join tlocation F on B.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSQL &= " inner join tcustomer G on F.Cust_ID=G.Cust_ID" & Environment.NewLine
                strSQL &= " inner join tworkorder W on B.WO_ID=W.WO_ID" & Environment.NewLine
                strSQL &= " left join lfrequency H on C.freq_ID=H.freq_ID" & Environment.NewLine
                strSQL &= " left join lbaud I on C.baud_ID=I.baud_ID" & Environment.NewLine
                strSQL &= " left join tcostcenter J on B.cc_ID=J.cc_ID" & Environment.NewLine
                strSQL &= " left join lwipownersubloc K on C.wipownersubloc_id=K.wipownersubloc_id" & Environment.NewLine
                strSQL &= " where B.loc_ID=19 and B.Ship_ID ='9999919' and "
                strSQL &= " B.Pallett_ID is null "    'Too slow if add "and B.device_dateship is not null"
                'strSQL &= " AND E.wipowner_id <> 7 "				' Exclude In-Transit
                dt3 = Me._objDataProc.GetDataTable(strSQL)
                'dtResult = dt3
                'MessageBox.Show("dt3.Rows.Count=" & dt3.Rows.Count)

                'Union dt1 and dt2
                For Each row In dt2.Rows
                    dt1.ImportRow(row)
                Next
                For Each row In dt3.Rows
                    If Not row.IsNull("Produced Date") Then dt1.ImportRow(row)
                Next
                'dtResult = dt1

                'No data
                If dt1.Rows.Count = 0 Then
                    MessageBox.Show("No data for your request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If


                'Get customer names
                strSQL = "select cust_ID,Cust_Name1 as 'Customer',0 as 'CountVal' from tcustomer where cust_id in (" & strCustIDs & ");"
                dtCustomers = Me._objDataProc.GetDataTable(strSQL)

                'define datatable
                dtWIPWorkStations = WIPWorkStationTableDef()

                'Re-sort it
                Dim dView As DataView = dt1.DefaultView    'New DataView(dtDockShipped)
                Dim rowView
                dView.Sort = "Customer,[Serial Number],[Model Desc],Frequency,[Baud Rate]"    ',Column3 Asc" 'Desc
                dtFinal = dt1.Clone : dtDetails_1 = dt1.Clone : dtDetails_2 = dt1.Clone
                For Each rowView In dView
                    row = rowView.Row
                    dtFinal.ImportRow(row)

                    'Split into "Hold" and "Other" (based on WIP Owner) 
                    If Not bSummaryOnly Then
                        If row("wipowner_id") = 6 Then       'Hold
                            dtDetails_1.ImportRow(row)
                        Else
                            dtDetails_2.ImportRow(row)
                        End If
                    End If

                    'get uniques keys
                    If Not arrListNewKeys.Contains(row("NewKey")) Then
                        arrListNewKeys.Add(row("NewKey"))
                    End If
                    If Not arrListWorkStationIDs.Contains(row("NewWSID")) Then
                        arrListWorkStationIDs.Add(row("NewWSID"))
                        rowNew = dtWIPWorkStations.NewRow
                        rowNew("NewWSID") = row("NewWSID")
                        rowNew("WIP Location") = row("WIP Location")
                        rowNew("Ams_WIPFlow") = row("Ams_WIPFlow")
                        dtWIPWorkStations.Rows.Add(rowNew)
                    End If
                Next
                'dtResult = dtWIPWorkStations ' dtFinal
                dt1 = Nothing : dt2 = Nothing : dt3 = Nothing : dView = Nothing

                'Re-sort dtWIPWorkStations
                Dim dView2 As DataView = dtWIPWorkStations.DefaultView
                dView2.Sort = "Ams_WIPFlow"    ' "NewWSID"

                'Creat summary data
                dtSummary = WIPSummaryTableDef()
                For Each rowView In dView2    'add columns
                    Dim newColumn1 As New DataColumn(rowView.Row("WIP Location"), GetType(System.Int32)) : dtSummary.Columns.Add(newColumn1)
                Next
                Dim newColumn2 As New DataColumn("WIP Location Total", GetType(System.Int32)) : dtSummary.Columns.Add(newColumn2)
                Dim newColumn3 As New DataColumn("Split", GetType(System.String)) : dtSummary.Columns.Add(newColumn3)
                For Each row In dtCustomers.Rows
                    Dim newColumn1 As New DataColumn(row("Customer"), GetType(System.Int32)) : dtSummary.Columns.Add(newColumn1)
                Next
                Dim newColumn4 As New DataColumn("Customer Total", GetType(System.Int32)) : dtSummary.Columns.Add(newColumn4)
                Dim newColumn5 As New DataColumn("NewKey", GetType(String)) : dtSummary.Columns.Add(newColumn5)
                'dtResult = dtSummary
                dtTmp = dtFinal.Clone : j = 0
                For i = 0 To arrListNewKeys.Count - 1
                    strS = arrListNewKeys(i)
                    dtFilteredRows = dtFinal.Select("[NewKey]='" & strS & "'")
                    If dtFilteredRows.Length > 0 Then    'it should be > 0
                        k = 0 : dtTmp.Clear()
                        For Each row In dtFilteredRows
                            dtTmp.ImportRow(row)
                            If k = 0 Then
                                rowNew = dtSummary.NewRow
                                rowNew("Model Desc") = row("Model Desc")
                                rowNew("Frequency") = row("Frequency")
                                rowNew("Baud Rate") = row("Baud Rate")
                                rowNew("NewKey") = strS
                                dtSummary.Rows.Add(rowNew)
                            End If
                            k += 1
                        Next

                        'Update count for customers
                        If bIncludeWIPHoldInSummaryReport Then
                            For Each row In dtCustomers.Rows
                                Dim objVal As Object = dtTmp.Compute("Count(Cust_ID)", "Cust_ID=" & row("Cust_ID"))
                                If Not (objVal Is DBNull.Value) AndAlso objVal > 0 Then
                                    UpdateSummaryCountVal(dtSummary, j, row("Customer"), objVal)
                                End If
                            Next
                        Else
                            For Each row In dtCustomers.Rows
                                Dim objVal As Object = dtTmp.Compute("Count(Cust_ID)", "Cust_ID=" & row("Cust_ID") & " and wipowner_id<>6")
                                If Not (objVal Is DBNull.Value) AndAlso objVal > 0 Then
                                    UpdateSummaryCountVal(dtSummary, j, row("Customer"), objVal)
                                End If
                            Next
                        End If


                        'Updatecount for workstations
                        For Each rowView In dView2
                            strS = rowView("NewWSID")
                            Dim objVal As Object = dtTmp.Compute("Count(NewWSID)", "NewWSID='" & strS & "'")
                            If Not (objVal Is DBNull.Value) AndAlso objVal > 0 Then
                                UpdateSummaryCountVal(dtSummary, j, rowView("WIP Location"), objVal)
                            End If
                        Next

                        j += 1
                        'dtResult = dtSummary
                        'If j = 100 Then Exit Sub
                    Else
                        MessageBox.Show("Can't found summary data for NewKey '" & strS & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Next
                'dtResult = dtSummary
                'Exit Sub

                'Re-sort  dtSummary
                dView = dtSummary.DefaultView
                dView.Sort = "[Model Desc],Frequency,[Baud Rate]"
                dtSummaryFinal = dtSummary.Clone
                If bIncludeWIPHoldInSummaryReport Then
                    For Each rowView In dView
                        row = rowView.Row
                        dtSummaryFinal.ImportRow(row)
                    Next
                Else
                    For Each rowView In dView
                        Dim iValSum As Integer = 0
                        row = rowView.Row
                        For Each row2 In dtWIPWorkStations.Rows
                            If Not Trim(row2("WIP Location")).ToString.ToUpper = "HOLD" Then
                                If Not row.IsNull(row2("WIP Location")) Then
                                    iValSum += row(row2("WIP Location"))
                                End If
                            End If
                        Next
                        If iValSum > 0 Then
                            dtSummaryFinal.ImportRow(row)
                        End If
                    Next
                End If
                dtSummary = Nothing

                'Remove unwanted columns if need
                If Not bInclAllColumns Then
                    dtFinal.Columns.Remove("wipowner_id") : dtFinal.Columns.Remove("Device_ID") : dtFinal.Columns.Remove("model_ID")
                    dtFinal.Columns.Remove("freq_ID") : dtFinal.Columns.Remove("baud_ID") : dtFinal.Columns.Remove("WO_ID")
                    dtFinal.Columns.Remove("pallett_id") : dtFinal.Columns.Remove("cust_id") : dtFinal.Columns.Remove("NewKey")
                    dtFinal.Columns.Remove("Ams_WIPFlow") : dtFinal.Columns.Remove("NewWSID") : dtSummaryFinal.Columns.Remove("NewKey")

                    dtDetails_1.Columns.Remove("wipowner_id") : dtDetails_1.Columns.Remove("Device_ID") : dtDetails_1.Columns.Remove("model_ID")
                    dtDetails_1.Columns.Remove("freq_ID") : dtDetails_1.Columns.Remove("baud_ID") : dtDetails_1.Columns.Remove("WO_ID")
                    dtDetails_1.Columns.Remove("pallett_id") : dtDetails_1.Columns.Remove("cust_id") : dtDetails_1.Columns.Remove("NewKey")
                    dtDetails_1.Columns.Remove("Ams_WIPFlow") : dtDetails_1.Columns.Remove("NewWSID")

                    dtDetails_2.Columns.Remove("wipowner_id") : dtDetails_2.Columns.Remove("Device_ID") : dtDetails_2.Columns.Remove("model_ID")
                    dtDetails_2.Columns.Remove("freq_ID") : dtDetails_2.Columns.Remove("baud_ID") : dtDetails_2.Columns.Remove("WO_ID")
                    dtDetails_2.Columns.Remove("pallett_id") : dtDetails_2.Columns.Remove("cust_id") : dtDetails_2.Columns.Remove("NewKey")
                    dtDetails_2.Columns.Remove("Ams_WIPFlow") : dtDetails_2.Columns.Remove("NewWSID")
                End If
                If Not bIncludeWIPHoldInSummaryReport Then
                    dtSummaryFinal.Columns.Remove("Hold")
                End If
                dtFinal = Nothing

                'Summary only
                If bSummaryOnly Then
                    'dtFinal.Clear()
                    dtDetails_1.Clear() : dtDetails_2.Clear()
                End If

                'Do Excel report
                Dim objExcelRpt As New PSS.Data.ExcelReports()
                strRptName = "Messaging WIP Report " & Format(Now, "yyyyMMdd_HHmmss")
                'objExcelRpt.RunDetailSummaryExcelFormat_MultipleSheets(dtFinal, dtSummaryFinal, strRptName, "WIP", New String() {"A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M"}, )
                objExcelRpt.RunDetailSummaryExcelFormat_MultipleSheets(dtDetails_1, dtDetails_2, dtSummaryFinal, strRptName, "Hold", "Other", New String() {"A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M"}, )

                dView = Nothing : dView2 = Nothing

            Catch ex As Exception
                Throw ex
            Finally
                dt1 = Nothing : dt2 = Nothing : dt3 = Nothing : dtFinal = Nothing : dtCustomers = Nothing : dtWIPWorkStations = Nothing
                dtTmp = Nothing : dtSummary = Nothing : dtSummaryFinal = Nothing : dtDetails_1 = Nothing : dtDetails_2 = Nothing
            End Try
        End Sub


        '**********************************************************************************
        Public Function CreateMessagingReceivingReport(ByVal strLocIDs As String, ByVal strRptName As String, _
                                                       ByVal strDateStart As String, ByVal strDateEnd As String, _
                                                       ByVal bIncludingAllColumns As Boolean) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try

                strSql = "SELECT IF(F.Loc_ID=3404 OR F.Loc_ID=3405, CONCAT_WS(' - ', G.Cust_name1, F.Loc_Name), G.Cust_name1) AS 'Customer'" & Environment.NewLine
                strSql &= " ,C.Model_Desc as 'Model',D.Freq_number as 'Freq'" & Environment.NewLine
                strSql &= " ,E.Baud_Number as 'Baud',D.AMS_Freq_Family as 'Family',A.Device_SN as 'Serial #'" & Environment.NewLine
                strSql &= " ,B.CapCode,date_format(A.Device_DateRec,'%Y-%m-%d') as 'Date Rec'" & Environment.NewLine
                strSql &= " ,W.WO_CustWO AS 'Work Order',IF(W.WO_CameWithFile=1,'No','Yes') AS 'Manual WO'" & Environment.NewLine
                strSql &= " ,A.Device_ID,C.Model_ID,D.Freq_ID,E.Baud_ID,A.Loc_ID,G.Cust_ID,A.WO_ID" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN lfrequency D ON B.Freq_ID=D.Freq_ID" & Environment.NewLine
                strSql &= " INNER JOIN lbaud E ON B.Baud_ID=E.Baud_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation F ON A.Loc_ID=F.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tCustomer G ON F.Cust_ID=G.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN tWorkOrder W ON A.WO_ID=W.WO_ID" & Environment.NewLine
                strSql &= " WHERE A.Loc_ID in (" & strLocIDs & ")" & Environment.NewLine
                strSql &= " AND A.Device_DateRec BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                strSql &= " ORDER BY A.Device_DateRec desc,C.Model_desc,D.AMS_Freq_Family;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If Not bIncludingAllColumns Then
                    dt.Columns.Remove("Device_ID")
                    dt.Columns.Remove("Model_ID") : dt.Columns.Remove("Freq_ID")
                    dt.Columns.Remove("Baud_ID") : dt.Columns.Remove("Loc_ID")
                    dt.Columns.Remove("Cust_ID") : dt.Columns.Remove("WO_ID")
                End If

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    'objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"C", "G", Generic.CalExcelColLetter(dt.Columns.Count)}, )
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "C", "D", "F", "G", "H", "I", "J"}, )
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Function CreateMessagingEvalProcessChargeReport(ByVal strRptName As String, _
                                                               ByVal strDateStart As String, ByVal strDateEnd As String, _
                                                               ByVal bIncludingAllColumns As Boolean) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try

                strSql = "SELECT IF(A.Loc_ID=3404 OR A.Loc_ID=3405, CONCAT_WS(' - ', T.Cust_Name1,L.Loc_Name),T.Cust_Name1) AS 'Customer',A.Device_SN AS 'SN',B.EvalCharges,B.EvalDatetime,C.User_FullName AS 'Update User'" & Environment.NewLine
                strSql &= " ,B.EvalUserID,A.Loc_ID,A.Device_ID" & Environment.NewLine
                strSql &= " FROM tDevice A" & Environment.NewLine
                strSql &= " INNER JOIN tMessData B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation L ON A.Loc_ID=L.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tcustomer T ON L.Cust_ID=T.Cust_ID" & Environment.NewLine
                strSql &= " LEFT JOIN Security.tUsers C ON B.EvalUserID=C.User_ID" & Environment.NewLine
                strSql &= " WHERE B.EvalBillCode_ID=3056 AND EvalFlag=1" & Environment.NewLine
                strSql &= " AND B.EvalDateTime BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If Not bIncludingAllColumns Then
                    dt.Columns.Remove("EvalUserID") : dt.Columns.Remove("Loc_ID") : dt.Columns.Remove("Device_ID")
                End If

                If dt.Rows.Count > 0 Then
                    objExcelRpt = New ExcelReports(False)
                    ' objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "C", Generic.CalExcelColLetter(dt.Columns.Count)}, )
                    objExcelRpt.RunSimpleExcelFormat(dt, strRptName, New String() {"A", "B", "D", "E"}, New String() {"C"})
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************************************
        Private Sub UpdateSummaryCountVal(ByRef dtOutput As DataTable, ByVal iRowIdx As Integer, ByVal strCustomer As String, ByVal iCountVal As Integer)
            Dim col As DataColumn
            Try
                For Each col In dtOutput.Columns
                    If strCustomer.Trim.ToUpper = col.ColumnName.Trim.ToUpper Then
                        dtOutput.Rows(iRowIdx).Item(col.ColumnName) = iCountVal
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************************************************************************************
        Private Function WIPSummaryTableDef() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("Model Desc", GetType(String))
            dTB.Columns.Add("Frequency", GetType(String))
            dTB.Columns.Add("Baud Rate", GetType(String))

            Return dTB
        End Function

        '******************************************************************************************************************************************
        Private Function WIPWorkStationTableDef() As DataTable
            Dim dTB As New DataTable()

            dTB.Columns.Add("NewWSID", GetType(String))
            dTB.Columns.Add("WIP Location", GetType(String))
            dTB.Columns.Add("Ams_WIPFlow", GetType(Integer))

            Return dTB
        End Function


        '******************************************************************************************************************************************


    End Class
End Namespace
