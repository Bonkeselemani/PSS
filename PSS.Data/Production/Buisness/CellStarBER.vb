Option Explicit On 

Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Drawing.Printing
Imports System.Windows.Forms

Namespace Buisness

    Public Class CellStarBER
        Private objMisc As Production.Misc
        Private dt As DataTable
        Private strSql As String = ""

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
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '***************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        'Part Number Update Section
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '***************************************************
        'Get selected datatable
        '***************************************************
        Public Function GetSelectedDt(ByVal strMySql As String) As DataTable
            Try
                objMisc._SQL = strMySql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.GetSelectedDt(): " & ex.ToString)
            End Try
        End Function
        Public Function UpdtDelInsert(ByVal strMySql As String) As Integer
            Try
                objMisc._SQL = strMySql
                Return objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.UpdtDelInsert(): " & ex.ToString)
            End Try
        End Function

        '***************************************************
        'frmCellStarPartNumUpdate
        '***************************************************
        Public Function GetCmbDisplayData(ByVal strSelectSql As String, _
                                          ByVal strCmbName As String) As DataTable
            Try
                'strSql = "SELECT ent_id, ent_longdesc FROM cs_enterprise;"
                strSql = strSelectSql
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                If dt.Rows.Count > 0 Then
                    Return dt
                End If
            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.GetCmbDisplayData(): " & ex.ToString)
            Finally
                DisposeDT(dt)
                strSql = ""
            End Try
        End Function

        '***************************************************
        'get a row in cs_partmap table
        Public Function GetPartNumEntry(ByVal iPartNum As Int64) As DataTable
            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM cs_partmap " & Environment.NewLine
                strSql &= "WHERE part_number = " & iPartNum & ";"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                Return dt
            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.GetPartNumEntry(): " & ex.ToString)
            Finally
                DisposeDT(dt)
                strSql = ""
            End Try
        End Function

        '''''''***************************************************
        ''''''Public Function GetPartNumEntryDesc(ByVal iPartNum) As DataTable
        ''''''    Try
        ''''''        strSql = "SELECT cs_partmap.part_number AS 'Part Number', " & Environment.NewLine
        ''''''        strSql &= "cs_enterprise.ent_longdesc AS Enterprise, " & Environment.NewLine
        ''''''        strSql &= "cs_carrier.carrier_longdesc AS Carrier, " & Environment.NewLine
        ''''''        strSql &= "tmodel.Model_Desc AS Model " & Environment.NewLine
        ''''''        strSql &= "FROM cs_partmap " & Environment.NewLine
        ''''''        strSql &= "INNER JOIN tmodel ON cs_partmap.model_id = tmodel.model_id " & Environment.NewLine
        ''''''        strSql &= "INNER JOIN cs_enterprise ON cs_partmap.ent_id = cs_enterprise.ent_id " & Environment.NewLine
        ''''''        strSql &= "INNER JOIN cs_carrier ON cs_partmap.carrier_id = cs_carrier.carrier_id " & Environment.NewLine
        ''''''        strSql &= "WHERE part_number = " & iPartNum & ";"
        ''''''        objMisc._SQL = strSql
        ''''''        dt = objMisc.GetDataTable
        ''''''        Return dt
        ''''''    Catch ex As Exception
        ''''''        Throw New Exception("Business.CellStarBER.GetPartNumEntryDesc(): " & ex.ToString)
        ''''''    Finally
        ''''''        DisposeDT(dt)
        ''''''        strSql = ""
        ''''''    End Try
        ''''''End Function
        '***************************************************
        Public Function UpdtCSPartNum(ByVal iPart_ID As Integer, _
                                      ByVal strPartNum As String, _
                                      ByVal iEnterpriseID As Integer, _
                                      ByVal iCarrierID As Integer, _
                                      ByVal iModelID As Integer, _
                                      ByVal dLaborAmt As Double, _
                                      ByVal dBerRate As Double, _
                                      ByVal iInactiveFlg As Integer) As Integer
            Dim i As Integer = 0
            Try
                If iPart_ID > 0 Then
                    strSql = "UPDATE cs_partmap " & Environment.NewLine
                    strSql &= "SET ent_id = " & iEnterpriseID & ", carrier_id = " & iCarrierID & ", model_id = " & iModelID & ", laboramount = " & dLaborAmt & ", BERrate = " & dBerRate & ", inactive = " & iInactiveFlg & Environment.NewLine
                    strSql &= "WHERE part_number = '" & strPartNum & "' and part_id = " & iPart_ID & ";"
                Else
                    strSql = "INSERT INTO cs_partmap " & Environment.NewLine
                    strSql &= "(part_number, ent_id, carrier_id, model_id, laboramount,BERrate, inactive) " & Environment.NewLine
                    strSql &= "VALUES('" & strPartNum & "', " & iEnterpriseID & ", " & iCarrierID & ", " & iModelID & ", " & dLaborAmt & ", " & dBerRate & ", " & iInactiveFlg & ");"
                End If
                objMisc._SQL = strSql
                i = objMisc.ExecuteNonQuery
                Return i
            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.GetPartNumEntry(): " & ex.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        Public Function UpdtABStock_UPC_CrossRef(ByVal strFilePath As String) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook       ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim j As Integer = 0
            Dim i As Integer = 0
            Dim iUpdateRecord As Integer = 0
            Dim strSql As String = ""
            Dim strAStockUPC As String = ""
            Dim strBStockUPC As String = ""

            Try
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePath)
                objSheet = objExcel.Worksheets(1)

                System.Windows.Forms.Application.DoEvents()

                i = 1

                If Len(Trim(objSheet.range("A" & i).value)) > 0 Then
                    If UCase(Trim(objSheet.range("A" & i).value)) Like "A-STOCK*" And _
                       UCase(Trim(objSheet.range("B" & i).value)) Like "B-STOCK*" Then
                        '//Correct header
                    Else
                        MessageBox.Show("Excel does not contain the correct header in the first line. Please verify it.", "Incorrect Excel Header", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        iUpdateRecord = -1
                        Exit Function
                    End If
                End If

                While j < 10
                    i += 1
                    '******************************
                    'To avoid excessive looping
                    '******************************
                    If Len(Trim(objSheet.range("A" & i).value)) > 0 Then
                        j = 0
                    Else
                        j += 1
                    End If

                    strAStockUPC = UCase(Trim(objSheet.range("A" & i).value))
                    strBStockUPC = UCase(Trim(objSheet.range("B" & i).value))

                    '******************************************                    
                    'check if line is not a blank line
                    '******************************************
                    If Len(strAStockUPC) > 0 And Len(strBStockUPC) > 0 Then
                        strSql = "REPLACE INTO " & Environment.NewLine
                        strSql &= "cs_dob_atob_upc_crossref " & Environment.NewLine
                        strSql &= "( AStockUPC, BStockUPC ) VALUES ('" & strAStockUPC & "', '" & strBStockUPC & "');"

                        Me.objMisc._SQL = strSql
                        iUpdateRecord = Me.objMisc.ExecuteNonQuery
                    End If

                    strAStockUPC = ""
                    strBStockUPC = ""
                End While

                Return iUpdateRecord

            Catch ex As Exception
                Throw ex
            Finally
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
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function


        '***************************************************
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        'transfer devices to subcontractor wipowner
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


        ''***************************************************
        Public Function CheckDeviceNotWP(ByVal strESN As String) As DataTable
            Try
                strSql = "select tdevice.device_id, tdevice.device_sn from tdevice, tworkorder,cstincomingdata " & Environment.NewLine
                strSql &= "where tdevice.device_sn = '" & strESN & "' and" & Environment.NewLine
                strSql &= "tdevice.pallett_id is null and" & Environment.NewLine
                strSql &= "tdevice.device_DateShip is null and" & Environment.NewLine
                strSql &= "tdevice.device_sn = cstincomingdata.csin_ESN and" & Environment.NewLine
                strSql &= "tdevice.WO_ID =tworkorder.wo_id and" & Environment.NewLine
                strSql &= "cstincomingdata.flgReceived = 1 and" & Environment.NewLine
                strSql &= "cstincomingdata.csin_ItemDesc not like '% WD %' and" & Environment.NewLine
                strSql &= "tworkorder.WO_CustWO = cstincomingdata.csin_RepairOrderNum;"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                Return dt

            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.GetPartNumEntry(): " & ex.ToString)
            Finally
                DisposeDT(dt)
                strSql = ""
            End Try
        End Function

        ''***************************************************
        'return device's wipowner
        ''***************************************************
        Public Function GetDevWipOwner(ByVal iDevice_id As Integer) As Integer
            Try
                strSql = "select Cellopt_WIPOwner from tcellopt where device_id = " & iDevice_id & ";"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)("cellopt_wipowner")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.GetPartNumEntry(): " & ex.ToString)
            Finally
                DisposeDT(dt)
                strSql = ""
            End Try
        End Function

        ''***************************************************
        'transfer devices to 
        ''***************************************************
        Public Function TransWipToSubcontractor(ByVal dtWipTransfESNs As DataTable, _
                                                ByVal iSubcon As Integer) As Integer
            Dim i As Integer = 0
            Dim R1 As DataRow
            Dim strCurrentDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Try
                '**********************************
                'Transfer devices
                For Each R1 In dtWipTransfESNs.Rows
                    strSql = "update tcellopt " & Environment.NewLine
                    strSql &= "set Cellopt_WIPOwnerOld = Cellopt_WIPOwner, Cellopt_WIPOwner = 15, SC_ID = " & iSubcon & ", Cellopt_WIPEntryDt = now() " & Environment.NewLine
                    strSql &= "where device_id = " & R1("device_id") & ";"

                    objMisc._SQL = strSql
                    i += objMisc.ExecuteNonQuery
                Next R1
                '**********************************
                'print packing list
                PrintWipTransESNLst(dtWipTransfESNs)
                '**********************************

                Return i
            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.TransWipToSubcontractor(): " & ex.ToString)
            Finally
                strSql = ""
                R1 = Nothing
            End Try
        End Function

        '*******************************************************************
        'print ESNs list of wip transfer
        'frmReadyToTransfer(transfer Wip section)
        '*******************************************************************
        Private Function PrintWipTransESNLst(ByVal dtESNs As DataTable) As Integer

            Dim strCurrentDate As String = Format(Now(), "yyyy-MM-dd HH-mm")

            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strMySql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow


            Try
                '***************************************
                'Create Excel Files
                '***************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                '****************************************
                'Create the header
                '****************************************
                objExcel.Application.Cells(1, 1).Value = "SERIAL NUMBER"
                objExcel.Application.Cells(1, 2).Value = "MODEL"
                objExcel.Application.Cells(1, 3).Value = "OUTSIDE SOURCE"
                objExcel.Application.Cells(1, 4).Value = "TRANSFER DATE"
                '****************************************
                'Set column widths
                '****************************************
                'Format Column A  (SN)
                objSheet.Columns("A:A").ColumnWidth = 20.29
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter

                'Format Column B  (MODEL)
                objSheet.Columns("B:B").ColumnWidth = 20.29
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                'Format Column C  (OUTSIDE SOURCE LOCATION)
                objSheet.Columns("C:C").ColumnWidth = 22.57
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter

                'Format Column D  (TRANSFERRING DATE)
                objSheet.Columns("D:D").ColumnWidth = 22.14
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlRight
                '*****************************************
                'Set alignments
                '*****************************************
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
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
                '*****************************************
                'format header
                '*****************************************
                objSheet.Range("A1:D1").Select()
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
                ''*****************************************

                Dim i As Integer = 2

                For Each R1 In dtESNs.Rows
                    '***************************************
                    'Get cellopt wipowner
                    '***************************************
                    strMySql = "select tcellopt.Cellopt_WIPEntryDt, tmodel.Model_Desc, tsubcontractor.SC_Desc" & Environment.NewLine
                    strMySql &= "from tdevice, tmodel, tcellopt, tsubcontractor " & Environment.NewLine
                    strMySql &= "where tdevice.Device_ID = " & R1("device_id") & " and " & Environment.NewLine
                    strMySql &= "tdevice.model_id = tmodel.Model_ID and " & Environment.NewLine
                    strMySql &= "tdevice.device_id = tcellopt.Device_ID and " & Environment.NewLine
                    strMySql &= "tcellopt.SC_ID = tsubcontractor.SC_ID;"

                    objMisc._SQL = strMySql
                    dt = objMisc.GetDataTable
                    '***************************************
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("device id (" & R1("device_id") & ") is missing in tcellopt.", "Print Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Else
                        objExcel.Application.Cells(i, 1).Value = R1("device_sn")
                        objExcel.Application.Cells(i, 2).Value = dt.Rows(0)("Model_Desc")
                        objExcel.Application.Cells(i, 3).Value = dt.Rows(0)("SC_Desc")
                        objExcel.Application.Cells(i, 4).Value = dt.Rows(0)("Cellopt_WIPEntryDt")
                        i += 1
                    End If
                Next R1

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A1:D" & i - 1).Select()
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

                '******************************************************
                'Save the excel file
                '******************************************************
                Dim strFileLoc As String = "P:\Dept\Cellstar\OutsideSourceManifest\" & strCurrentDate & ".xls"

                'Finish all form above it
                System.Windows.Forms.Application.DoEvents()

                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                objBook.SaveAs(strFileLoc)
                '******************************************************
                'print excel
                objExcel.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
                System.Windows.Forms.Application.DoEvents()
                '******************************************************

            Catch ex As Exception
                Throw New Exception("Business.CellStarBER.PrintWipTransESNLst:: " & ex.ToString)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                R1 = Nothing
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


    End Class

End Namespace