Imports System.Windows.Forms
Namespace Buisness
    Public Class CellstarMisc
        Private objMisc As Production.Misc

        Private Const strRemoteHost As String = "xdata.XYZ.com"
        Private Const strFTPUser As String = "ftprsc"
        Private Const strFTPPWD As String = "$Ftp3n216!"
        Private Const strChangeFTPDir As String = "Inbound"

        Private strFilePath As String = ""
        Public Property Path() As String
            Get
                Return strFilePath
            End Get
            Set(ByVal Value As String)
                strFilePath = Value
            End Set
        End Property

        '******************************************************************
        Public Sub LoadProductTypes(ByRef cmbProd As ComboBox)
            Dim dtProd As DataTable
            Dim strsql As String = ""

            Try

                strsql = "select * from lproduct;"

                objMisc._SQL = strsql
                dtProd = objMisc.GetDataTable
                dtProd.LoadDataRow(New Object() {"0", "-- Select --"}, False)

                With cmbProd
                    .DataSource = dtProd.DefaultView
                    .DisplayMember = dtProd.Columns("Prod_Desc").ToString
                    .ValueMember = dtProd.Columns("Prod_ID").ToString
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtProd) Then
                    dtProd.Dispose()
                    dtProd = Nothing
                End If
            End Try
        End Sub

        Public Sub GenerateTATWIPRptByCustProd(ByVal iCust_ID As Integer, _
                                               ByVal iProd_ID As Integer)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strFilePath As String = "C:\Opt2 WIP Report 07-31-2007.xls"
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim D1 As Date = Date.Now
            Dim iTotalDeltaDt As Integer = 0
            Dim i As Integer = 0

            Try
                '*************************
                'Get all device in WIP
                '*************************
                strSql = "select Model_Desc as Model, device_sn as SN,  DATE_FORMAT(Device_DateRec, '%m/%d/%Y')  as 'Received Date', " & Environment.NewLine
                strSql &= "DATE_FORMAT(now(), '%m/%d/%Y')  as 'Today', " & Environment.NewLine
                strSql &= "'' as 'Delta Days' " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.model_id  " & Environment.NewLine
                strSql &= "where  Device_DateShip is null " & Environment.NewLine
                If iProd_ID > 0 Then
                    strSql &= "and prod_id = " & iProd_ID & Environment.NewLine
                End If
                strSql &= "and Cust_ID = " & iCust_ID & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then

                    '*************************
                    'Calculate delta date
                    '*************************
                    For Each R1 In dt1.Rows
                        R1.BeginEdit()
                        If Not IsDBNull(R1("Received Date")) Then
                            If Trim(R1("Received Date")) <> "" Then
                                R1("Delta Days") = DateDiff(DateInterval.Day, R1("Received Date"), D1)
                                iTotalDeltaDt += CInt(R1("Delta Days"))
                            End If
                        End If

                        R1.EndEdit()
                        R1.AcceptChanges()
                    Next R1
                    dt1.AcceptChanges()

                    '*************************
                    'Write report header
                    '*************************
                    Dim arrRptData(dt1.Rows.Count + 5, dt1.Columns.Count)
                    arrRptData(i, 0) = "Model"
                    arrRptData(i, 1) = "SN"
                    arrRptData(i, 2) = "Received Date"
                    arrRptData(i, 3) = "Today's Date"
                    arrRptData(i, 4) = "Delta Days"

                    '*************************
                    'Assign data to an array
                    '*************************
                    For Each R1 In dt1.Rows
                        i += 1

                        arrRptData(i, 0) = R1("Model")
                        arrRptData(i, 1) = R1("SN")
                        arrRptData(i, 2) = R1("Received Date")
                        arrRptData(i, 3) = R1("Today")
                        arrRptData(i, 4) = R1("Delta Days")
                    Next R1

                    '*************************
                    'Calculate total
                    '*************************
                    i += 2
                    arrRptData(i, 0) = "Totals"
                    arrRptData(i, 1) = dt1.Rows.Count
                    arrRptData(i, 4) = iTotalDeltaDt
                    i += 2

                    arrRptData(i, 3) = "TAT:"
                    arrRptData(i, 4) = CStr(Format((iTotalDeltaDt / dt1.Rows.Count), "00.00"))

                    '*****************************************
                    'Create excel
                    objExcel = New Excel.Application()
                    'Add a Workbook
                    objBook = objExcel.Workbooks.Add
                    objSheet = objBook.Worksheets.Item(1)
                    'Make excel visible to user
                    objExcel.Application.Visible = True

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
                    '*****************************************
                    'Select whole sheet 
                    objSheet.Cells.Select()
                    'Format sheet to text format
                    objExcel.Selection.NumberFormat = "@"
                    'Populate array data to excel
                    objSheet.Range("A1", "E" & dt1.Rows.Count + 5).Value = arrRptData
                    'Format row and column to fit display data
                    objSheet.Cells.EntireColumn.AutoFit()
                    objSheet.Cells.EntireRow.AutoFit()
                    '*****************************************
                    'Format footer
                    '*****************************************
                    objSheet.Rows(dt1.Rows.Count + 3 & ":" & dt1.Rows.Count + 5).Select()
                    With objExcel.Selection
                        .WrapText = False
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                    End With
                    ''*****************************************
                    ''Save the excel file
                    'If Len(Dir(strFilePath)) > 0 Then
                    '    Kill(strFilePath)
                    'End If
                    'objBook.SaveAs(strFilePath)
                    ''*****************************************
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                ''*************************************
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub
        '******************************************************************
        Public Function GenerateTrimbleShipRpt(ByVal strFromShipDate As String, _
                                                ByVal strToShipDate As String) As Integer
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Dim strSql As String = ""
            Dim dt1 As DataTable

            Try
                strSql = "Select tdevice.Device_SN as 'Serial Number', " & Environment.NewLine
                strSql &= "device_daterec as 'Date Receive', " & Environment.NewLine
                strSql &= "Device_dateship as 'Date Ship', " & Environment.NewLine
                strSql &= "lpsprice.PSPrice_Number as 'Part Number', " & Environment.NewLine
                strSql &= "lpsprice.PSPrice_Desc as 'Part Description' " & Environment.NewLine
                strSql &= "from tdevice  " & Environment.NewLine
                strSql &= "inner join tdevicebill on tdevicebill.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "inner join tpsmap on tdevicebill.BillCode_ID = tpsmap.BillCode_ID and tdevice.Model_ID = tpsmap.Model_ID " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID  " & Environment.NewLine
                strSql &= "inner join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID  " & Environment.NewLine
                strSql &= "where tdevice.Device_ShipWorkDate >= '" & strFromShipDate & "' and tdevice.Device_ShipWorkDate <= '" & strToShipDate & "' and " & Environment.NewLine
                strSql &= "tdevice.model_id in (982, 983, 984) and " & Environment.NewLine
                strSql &= "tlocation.Cust_ID = 2113 and " & Environment.NewLine
                strSql &= "tpsmap.Inactive = 0;" & Environment.NewLine
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("No record found for this report.")
                Else
                    objGeneric.CreateExelReport(dt1)
                End If
                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objGeneric = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Function


        '******************************************************************
        Public Function CheckIfAllBillocdesMappedForModel(ByVal strDevice_SN As String) As Boolean
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim strsql As String = ""
            Dim iModel_ID As Integer = 0
            Dim iCust_ID As Integer = 0
            Dim ibooVar As Boolean = False

            Try
                '********************************
                'Get Device info
                strsql = "Select tdevice.model_id, tlocation.cust_id " & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "where device_sn = '" & strDevice_SN & "' and " & Environment.NewLine
                strsql &= "device_dateship is null " & Environment.NewLine
                strsql &= "order by device_id desc;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iModel_ID = R1("Model_ID")
                    iCust_ID = R1("Cust_ID")
                Else
                    Throw New Exception("Device does not exist.")
                End If

                If iCust_ID <> 2113 Then
                    Return True
                End If
                '********************************
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                '********************************
                'Get billocdes from tpsmap table for the model
                strsql = "Select tpsmap.* " & Environment.NewLine
                strsql &= "from tpsmap " & Environment.NewLine
                strsql &= "inner join lbillcodes on tpsmap.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strsql &= "where model_id = " & iModel_ID & ";"
                'strsql &= "lbillcodes.BillType_ID = 2;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Return True
                End If

                For Each R1 In dt1.Rows
                    strsql = "Select * from tbillmap " & Environment.NewLine
                    strsql &= "where cust_id = " & iCust_ID & " and " & Environment.NewLine
                    strsql &= "model_id = " & iModel_ID & " and " & Environment.NewLine
                    strsql &= "billcode_id = " & R1("billcode_id") & " and " & Environment.NewLine
                    strsql &= "BMap_Inactive = 0;"

                    objMisc._SQL = strsql
                    dt2 = objMisc.GetDataTable

                    If dt2.Rows.Count > 0 Then
                        R2 = dt2.Rows(0)
                        '*******************************
                        'Check for Individual codes
                        If IsDBNull(R2("BMap_ProblemFound")) Then
                            Throw New Exception("Problem Found Code is not mapped for this model and Billcode_ID " & R1("billcode_id"))
                        ElseIf IsDBNull(R2("BMap_RepairAction")) Then
                            Throw New Exception("Reapir Action Code is not mapped for this model and Billcode_ID " & R1("billcode_id"))
                        ElseIf IsDBNull(R2("BMap_RefDes")) Then
                            Throw New Exception("Reference Designator Code is not mapped for this model and Billcode_ID " & R1("billcode_id"))
                        ElseIf IsDBNull(R2("BMap_Failure")) Then
                            Throw New Exception("Failure Code is not mapped for this model and Billcode_ID " & R1("billcode_id"))
                        ElseIf IsDBNull(R2("BMap_Transaction")) Then
                            Throw New Exception("Transaction Code is not mapped for this model and Billcode_ID " & R1("billcode_id"))
                        End If
                    Else
                        Throw New Exception("Billcode_ID " & R1("billcode_id") & " is not mapped to all codes for this model.")
                    End If

                    R2 = Nothing
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                Next R1

                ibooVar = True

                Return ibooVar
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

        '******************************************************************
        Public Function CreateAndSendXML(ByVal lstSN As ListBox) As Integer
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strDeviceIDs As String = ""
            Dim objCellstar As New PSS.Data.Buisness.CellStar()

            Try
                'STEP 1:
                'Build Device_ID string
                For i = 0 To lstSN.Items.Count - 1
                    strsql = "Select Device_ID from tdevice where loc_id = 2636 and device_sn = '" & lstSN.Items(i) & "' order by device_id desc;"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable

                    If dt1.Rows.Count > 0 Then
                        R1 = dt1.Rows(0)
                        If i = 0 Then
                            strDeviceIDs &= R1("Device_ID")
                        Else
                            strDeviceIDs &= ", " & R1("Device_ID")
                        End If
                    Else
                        Throw New Exception(lstSN.Items(i) & " device did not meet the criteria.")
                    End If

                    'Clean up
                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                Next i


                'MsgBox(strDeviceIDs)

                'STEP 2:
                'Build the XML
                objCellstar.createCloseReport("", "", strDeviceIDs)
                strFilePath = objCellstar.MyFilePath

                '''Copy the file to FTP site
                ''i = UploadFiles()


            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objCellstar = Nothing
            End Try

        End Function

        '******************************************************************
        Public Function CheckIfDevShipped(ByVal strSN As String) As Integer
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iResult As Integer = 0

            Try
                strsql = "Select * from tdevice where loc_id = 2636 and device_sn = '" & strSN & "' order by device_id desc;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If IsDBNull(R1("Device_DateShip")) Then
                        iResult = 0
                    Else
                        iResult = 1
                    End If
                End If

                Return iResult
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

        '******************************************************************
        'This uploads files
        '******************************************************************
        Public Function UploadFiles() As Integer
            Dim i As Integer = 0
            Dim ObjUtility As New MyLib.Utility()

            Try
                ObjUtility = New MyLib.Utility()
                i = ObjUtility.UploadFiles(strRemoteHost, strFTPUser, strFTPPWD, , strFilePath, strChangeFTPDir)
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                ObjUtility = Nothing
            End Try
        End Function
        '******************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

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
    End Class


End Namespace
