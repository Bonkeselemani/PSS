
Option Explicit On 

Imports System.Data.OleDb
Imports System.IO

Namespace Buisness

    Public Class MessAdmin

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

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'LOAD VERIZON DATA SECTION
       '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        '***********************************************************
        'Added by Lan on 03/02/2007
        '***********************************************************
        Public Sub LoadVerizonData(ByVal strFilePatth As String, _
                                   ByVal iCust_id As Integer, _
                                   ByVal iUserID As Integer)
            Dim objExcel As New Excel.Application()  ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim j As Integer = 0
            Dim i As Integer = 0
            Dim iRegSpecialWoFlg As Integer = 0
            Dim strFileName As String = ""

            Try
                If strFilePatth = "" Then
                    Exit Sub
                End If

                i = InStrRev(strFilePatth, "\")

                If i > 0 Then
                    strFileName = Mid(strFilePatth, i + 1)
                End If

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)

                System.Windows.Forms.Application.DoEvents()

                i = 0

                While j < 10
                    i += 1
                    '******************************
                    'To avoid excessive looping
                    '******************************
                    If Len(Trim(objSheet.range("B" & i).value)) > 0 Then
                        j = 0
                    Else
                        j += 1
                    End If
                    '******************************************                    
                    'check if excel is regular WO or special WO
                    '******************************************
                    If Len(Trim(objSheet.range("A" & i).value)) > 0 Then
                        If UCase(Trim(objSheet.range("A" & i).value)) Like "RMA*" Then
                            iRegSpecialWoFlg = 1
                            Exit While
                        ElseIf UCase(Trim(objSheet.range("A" & i).value)) Like "CO*" And _
                               UCase(Trim(objSheet.range("B" & i).value)) Like "SERIAL*" And _
                               UCase(Trim(objSheet.range("C" & i).value)) Like "STAT*" And _
                               UCase(Trim(objSheet.range("D" & i).value)) Like "TYPE*" And _
                               UCase(Trim(objSheet.range("E" & i).value)) Like "CHNL*" And _
                               UCase(Trim(objSheet.range("F" & i).value)) Like "CAPCODE*" Then
                            iRegSpecialWoFlg = 2
                            Exit While
                        End If
                    End If
                End While

                '****************************
                'clean up excel object
                '****************************
                'DisposeExel(objExcel, objBook, objSheet)
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

                System.Windows.Forms.Application.DoEvents()
                '*********************************
                'load into system base on WO type
                '*********************************
                Select Case iRegSpecialWoFlg
                    Case 0
                        MsgBox("Data File has incorrect format.", MsgBoxStyle.Critical, "Validate Data File")
                    Case 1      'Reg
                        LoadVerizonData_RegWO(strFilePatth, _
                                              strFileName, _
                                              iCust_id, _
                                              iUserID)
                    Case 2      'Special
                        LoadVerizonData_SpecialWO(strFilePatth, _
                                                  strFileName, _
                                                  iCust_id, _
                                                  iUserID)
                End Select

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
        End Sub

        '***********************************************************************
        Public Sub LoadVerizonData_SpecialWO(ByVal strFilePatth As String, _
                                             ByVal strFileName As String, _
                                             ByVal iCust_id As Integer, _
                                             ByVal iUserID As Integer)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1 As DataRow

            Dim dt1 As DataTable
            Dim strWorkorder As String = "SpecialWO"
            Dim strSerialNumber As String = ""
            Dim strCapCode As String = ""
            Dim strModel As String = ""
            Dim strFreq As String = ""
            Dim strModelNumber As String = ""
            Dim strSKUNumber As String = ""
            Dim strCapcodeType As String = ""
            Dim i As Integer = 0

            Dim iWoInsertCnt As Integer = 0
            Dim j As Integer = 0
            Dim f As Integer = 0
            Dim strChannel As String = ""

            Dim strSQL As String
            Dim dtNewTable As DataTable
            Dim NewRow As DataRow

            Dim iCreateMessMiscWoData As Integer = 0
            Dim strCapLo As String = ""
            Dim strCapHigh As String = ""
            Dim iCapLen As Integer = 0
            Dim iStartReadData As Integer = 0
            Dim iSNExisted As Integer = 0

            Try
                If strFilePatth = "" Then
                    Exit Sub
                End If

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)

                System.Windows.Forms.Application.DoEvents()

                'exit loop if there are 10 empty cell in column B
                While j < 10
                    i += 1
                    If Not IsDBNull(objSheet.range("B" & i).value) Then

                        '******************************
                        'To avoid excessive looping
                        '******************************
                        If Len(Trim(objSheet.range("B" & i).value)) > 0 Then
                            j = 0
                        Else
                            j += 1
                        End If

                        '******************************
                        If UCase(Trim(objSheet.range("B" & i).value)) Like "SERIAL*" Then
                            iStartReadData = 1
                            '****************
                            'dispose table
                            '****************
                            Me.DisposeDT(dtNewTable)

                            '****************
                            'recreate table
                            '****************
                            dtNewTable = Me.CreateNewTable_VerizonWO()

                            '**************
                            'Reset wo count
                            '**************
                            iWoInsertCnt = 0
                        ElseIf iStartReadData = 1 Then
                            '****************************
                            'Get data from excel
                            '****************************
                            If Len(Trim(objSheet.range("B" & i).value)) > 0 Then
                                strSerialNumber = UCase(Trim(objSheet.range("B" & i).value))
                                '*******************************
                                'check if Sn exist w/out rcvd
                                '*******************************
                                Me.DisposeDT(dt1)
                                strSQL = "select count(*) as cnt from tverdata where device_sn = '" & strSerialNumber & "' and WO_Name = '" & strWorkorder & "' and NewLoadFlag = 1 and RcvdFlag = 0;"
                                Me.objMisc._SQL = strSQL
                                dt1 = Me.objMisc.GetDataTable
                                iSNExisted = dt1.Rows(0)("cnt")
                                '*******************************

                                If iSNExisted = 0 Then
                                    strModelNumber = "UNKNOWN"

                                    '************************************
                                    'Get Model
                                    If Not IsDBNull(objSheet.range("D" & i).value) And Len(Trim(objSheet.range("D" & i).value)) Then
                                        strModel = UCase(Trim(objSheet.range("D" & i).value))
                                    Else
                                        strModel = ""
                                    End If

                                    '************************************
                                    'validate frequency
                                    '************************************
                                    If Not IsDBNull(objSheet.range("E" & i).value) And Len(Trim(objSheet.range("E" & i).value)) > 0 Then
                                        strChannel = Trim(objSheet.range("E" & i).value)

                                        If Len(strChannel) < 3 Then
                                            If IsNumeric(strChannel) Then
                                                strChannel = String.Format("{0:D3}", CInt(strChannel))
                                            End If
                                        End If

                                        Me.DisposeDT(dt1)

                                        '************************************
                                        'Get Freq from channel
                                        strSQL = "select C2F_Frequency from lchannel2frequency where C2F_Channel = '" & strChannel & "';"
                                        Me.objMisc._SQL = strSQL
                                        dt1 = Me.objMisc.GetDataTable
                                        If dt1.Rows.Count > 0 Then
                                            strFreq = Trim(dt1.Rows(0)("C2F_Frequency"))
                                        Else
                                            strFreq = "000.0000"
                                        End If

                                        Me.DisposeDT(dt1)
                                        '************************************
                                        'insert freq into the system if freq does not exist
                                        If strFreq <> "000.0000" Or strFreq <> "" Then
                                            strSQL = "select * from lfrequency where freq_Number = '" & strFreq & "';"
                                            Me.objMisc._SQL = strSQL
                                            dt1 = Me.objMisc.GetDataTable

                                            If dt1.Rows.Count = 0 Then
                                                strSQL = "INSERT INTO lfrequency (freq_Number) VALUES ('" & strFreq & "');"
                                                Me.objMisc._SQL = strSQL
                                                f = Me.objMisc.ExecuteNonQuery
                                            End If
                                        End If
                                        '************************************
                                    Else
                                        strFreq = "000.0000"
                                    End If

                                    '************************************
                                    'Get Capcode
                                    If Not IsDBNull(objSheet.range("F" & i).value) And Len(Trim(objSheet.range("F" & i).value)) Then
                                        strCapCode = UCase(Trim(objSheet.range("F" & i).value))
                                    Else
                                        strCapCode = ""
                                    End If

                                    '************************************
                                    'Create SKU from Capcode. if capcode is blank then use Flex
                                    '************************************
                                    If Len(strCapCode) > 0 Then
                                        strCapcodeType = Mid$(strCapCode, 1, 1)

                                        Select Case strCapcodeType
                                            Case "A"
                                                strSKUNumber = "XXXXXXFLXX"
                                            Case "E"
                                                strSKUNumber = "XXXXXXFLXX"
                                            Case Else
                                                If InStr(strSerialNumber, "36") <> 0 Then
                                                    strSKUNumber = "XXXXXXFLXX"
                                                Else
                                                    strSKUNumber = "XX4XXXXXXX"
                                                End If
                                        End Select
                                    Else
                                        strSKUNumber = "XXXXXXFLXX"
                                    End If

                                    '***************************
                                    'Add new row
                                    '***************************
                                    Me.DisposeDT(dt1)

                                    '************************************
                                    'Get Freq from channel
                                    NewRow = dtNewTable.NewRow()

                                    NewRow("WO_Name") = strWorkorder
                                    NewRow("Device_SN") = strSerialNumber
                                    NewRow("Device_CapCode") = strCapCode
                                    NewRow("Device_Model") = strModel
                                    NewRow("Device_Freq") = strFreq
                                    NewRow("Model_Number") = strModelNumber
                                    NewRow("SKU_Number") = strSKUNumber

                                    dtNewTable.Rows.Add(NewRow)
                                    NewRow = Nothing
                                    dtNewTable.AcceptChanges()
                                    '***************************
                                End If  'if SN is existed then don't add

                            End If  'Check blank SN
                        End If  'header or record
                    End If 'check for dbnull of SN column
                End While

                If dtNewTable.Rows.Count > 0 Then
                    MsgBox("This workorder '" & strWorkorder & "' has " & dtNewTable.Rows.Count & " device(s).", MsgBoxStyle.Information, "Work Order Information")

                    '************************
                    'insert wo into database
                    '************************
                    For Each R1 In dtNewTable.Rows
                        '*********************************
                        'Save this value to use for create tmessmiscwodata
                        If strSKUNumber = "" And R1("SKU_Number") <> "" Then
                            strSKUNumber = R1("SKU_Number")
                        End If
                        If (strFreq = "" Or strFreq = "000.0000") And R1("Device_Freq") <> "" And R1("Device_Freq") <> "000.0000" Then
                            strFreq = R1("Device_Freq")
                        End If
                        '*********************************

                        strSQL = "INSERT INTO tverdata " & Environment.NewLine
                        strSQL &= "( WO_Name " & Environment.NewLine
                        strSQL &= ", Device_SN " & Environment.NewLine
                        strSQL &= ", Device_CapCode " & Environment.NewLine
                        strSQL &= ", Device_Model " & Environment.NewLine
                        strSQL &= ", Device_Freq " & Environment.NewLine
                        strSQL &= ", Model_Number " & Environment.NewLine
                        strSQL &= ", SKU_Number " & Environment.NewLine
                        strSQL &= ", NewLoadFlag " & Environment.NewLine
                        strSQL &= ", CameWithFileFlag " & Environment.NewLine
                        strSQL &= ", LoadFileName " & Environment.NewLine
                        strSQL &= ") VALUES " & Environment.NewLine
                        strSQL &= "( '" & R1("WO_Name") & "' " & Environment.NewLine
                        strSQL &= ", '" & R1("Device_SN") & "'" & Environment.NewLine
                        strSQL &= ", '" & R1("Device_CapCode") & "'" & Environment.NewLine
                        strSQL &= ", '" & R1("Device_Model") & "'" & Environment.NewLine
                        strSQL &= ", '" & R1("Device_Freq") & "'" & Environment.NewLine
                        strSQL &= ", '" & R1("Model_Number") & "'" & Environment.NewLine
                        strSQL &= ", '" & R1("SKU_Number") & "'" & Environment.NewLine
                        strSQL &= ", 1" & Environment.NewLine
                        strSQL &= ", 1" & Environment.NewLine
                        strSQL &= ", '" & strFileName & "'" & Environment.NewLine
                        strSQL &= ");"
                        objMisc._SQL = strSQL
                        iWoInsertCnt += objMisc.ExecuteNonQuery
                    Next R1

                    '***********************************
                    'Create Customer WO(tmessmiscwodata)
                    '***********************************
                    Me.DisposeDT(dt1)

                    'Dim iCameWithFile As Integer = 1
                    'iCreateMessMiscWoData = Me.CreateMiscWo(strWorkorder, _
                    '                                        iUserID, _
                    '                                        iWoInsertCnt, _
                    '                                        iCameWithFile, _
                    '                                        strCapLo, _
                    '                                        strCapHigh, _
                    '                                        iCapLen, _
                    '                                        strSKUNumber, _
                    '                                        strFreq, _
                    '                                        iCust_id)

                    '************************
                    'dispose table
                    '************************
                    Me.DisposeDT(dtNewTable)

                    MsgBox("Load is completed.", MsgBoxStyle.Information, "Load Work Order")
                End If


            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                NewRow = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dtNewTable)

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
        End Sub

        '***********************************************************
        'Added by Lan on 03/02/2007
        '***********************************************************
        Public Sub LoadVerizonData_RegWO(ByVal strFilePatth As String, _
                                         ByVal strFileName As String, _
                                         ByVal iCust_id As Integer, _
                                         ByVal iUserID As Integer)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet   ' Excel Worksheet
            Dim R1 As DataRow

            Dim dt1, dt2 As DataTable
            Dim strWorkorder As String = ""
            Dim strSerialNumber As String = ""
            Dim strCapCode As String = ""
            Dim strModel As String = ""
            Dim strFreq As String = ""
            Dim strModelNumber As String = ""
            Dim strSKUNumber As String = ""
            Dim strSKU As String = ""
            Dim i As Integer = 0
            Dim iIndex As Integer = 0
            Dim strFreqSec1 As String = ""
            Dim strFreqSec2 As String = ""
            Dim iWoQty As Integer = 0
            Dim iWoInsertCnt As Integer = 0
            Dim j As Integer = 0
            Dim f As Integer = 0
            Dim strSubString As String = ""

            Dim strSQL As String
            Dim iSkipWO As Integer = 0
            Dim dtNewTable As DataTable
            Dim NewRow As DataRow

            Dim iCreateMessMiscWoData As Integer = 0
            Dim strCapLo As String = ""
            Dim strCapHigh As String = ""
            Dim iCapLen As Integer = 0
            Dim iSNExisted As Integer = 0

            Try
                If strFilePatth = "" Then
                    Exit Sub
                End If

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)

                System.Windows.Forms.Application.DoEvents()

                'exit loop if there are 10 empty cell in column B
                While j < 10
                    i += 1
                    If Not IsDBNull(objSheet.range("B" & i).value) Then

                        '******************************
                        'To avoid excessive looping
                        '******************************
                        If Len(Trim(objSheet.range("B" & i).value)) > 0 Then
                            j = 0
                        Else
                            j += 1
                        End If
                        '******************************

                        If Not IsDBNull(objSheet.range("A" & i).value) And UCase(Trim(objSheet.range("A" & i).value)) Like "RMA*" Then
                            '**************
                            'Reset wo count
                            '**************
                            iWoInsertCnt = 0
                            iWoQty = 0

                            '**************
                            'dispose dt1
                            '**************
                            Me.DisposeDT(dt1)

                            '*********************************
                            'Determine if Workorder Exists
                            '*********************************
                            strSQL = "SELECT * FROM tverdata WHERE WO_Name = '" & Mid$(objSheet.range("B" & i).value, 4, 20) & "';"
                            Me.objMisc._SQL = strSQL
                            dt1 = Me.objMisc.GetDataTable
                            System.Windows.Forms.Application.DoEvents()

                            Me.DisposeDT(dt2)
                            strSQL = "select * from tmessmiscwodata where mmw_wo = '" & Mid$(objSheet.range("B" & i).value, 4, 20) & "';"
                            Me.objMisc._SQL = strSQL
                            dt2 = Me.objMisc.GetDataTable

                            If dt1.Rows.Count > 0 Or dt1.Rows.Count > 0 Then
                                MsgBox("This workorder '" & Mid$(objSheet.range("B" & i).value, 4, 20) & "' already existed in the database. Work order is skipped from loading.", MsgBoxStyle.Critical, "Validate Work Order")
                                'Exit Sub
                                iSkipWO = 1
                            Else
                                '****************
                                'Get WO Name
                                '****************
                                strWorkorder = Mid$(objSheet.range("B" & i).value, 4, 20)

                                '****************
                                'dispose table
                                '****************
                                Me.DisposeDT(dtNewTable)

                                '****************
                                'recreate table
                                '****************
                                dtNewTable = Me.CreateNewTable_VerizonWO()

                            End If 'check dbnull

                        ElseIf Not IsDBNull(objSheet.range("A" & i).value) And UCase(Trim(objSheet.range("A" & i).value)) Like "TOTAL NUMBER OF*" Then
                            If iSkipWO = 0 Then
                                '****************
                                'get wo quantity
                                '****************
                                iIndex = InStrRev(Trim(objSheet.range("B" & i).value), " ", -1, )
                                iWoQty = CInt(Mid(Trim(objSheet.range("B" & i).value), iIndex))

                                'Insert wo into tworkorder table
                                '***************ADD THIS LATER

                                If dtNewTable.Rows.Count > 0 Then
                                    '****************
                                    'Compare wo qty
                                    '****************
                                    If iWoQty <> dtNewTable.Rows.Count Then
                                        MsgBox("Excel line: " & i & ". The quantity of this workorder '" & strWorkorder & "'(" & iWoQty & ") is not the same with loading quantity (" & dtNewTable.Rows.Count & "). Please check excel file.", MsgBoxStyle.Critical, "Validate Work Order Quantity")
                                        Exit Try
                                    End If

                                    MsgBox("This workorder '" & strWorkorder & "' has " & dtNewTable.Rows.Count & " device(s).", MsgBoxStyle.Information, "Work Order Information")

                                    '************************
                                    'insert wo into database
                                    '************************
                                    For Each R1 In dtNewTable.Rows
                                        If strSKUNumber = "" And R1("SKU_Number") <> "" Then
                                            strSKUNumber = R1("SKU_Number")
                                        End If
                                        If strFreq = "" And R1("Device_Freq") <> "" Then
                                            strFreq = R1("Device_Freq")
                                        End If
                                        strSQL = "INSERT INTO tverdata (WO_Name, Device_SN, Device_CapCode, Device_Model, Device_Freq, Model_Number, SKU_Number, NewLoadFlag, CameWithFileFlag, LoadFileName) " & Environment.NewLine
                                        strSQL &= "VALUES " & Environment.NewLine
                                        strSQL &= "('" & R1("WO_Name") & "', '" & R1("Device_SN") & "', '" & R1("Device_CapCode") & "', '" & R1("Device_Model") & "', '" & R1("Device_Freq") & "', '" & R1("Model_Number") & "', '" & R1("SKU_Number") & "', 1, 1, '" & strFileName & "');"
                                        objMisc._SQL = strSQL
                                        iWoInsertCnt += objMisc.ExecuteNonQuery
                                    Next R1

                                    '***********************************
                                    'Create Customer WO(tmessmiscwodata)
                                    '***********************************
                                    Dim iCameWithFile As Integer = 1
                                    iCreateMessMiscWoData = Me.CreateMiscWo(strWorkorder, _
                                                                            iUserID, _
                                                                            iWoInsertCnt, _
                                                                            iCameWithFile, _
                                                                            strCapLo, _
                                                                            strCapHigh, _
                                                                            iCapLen, _
                                                                            strSKUNumber, _
                                                                            strFreq, _
                                                                            iCust_id)

                                    '************************
                                    'dispose table
                                    '************************
                                    Me.DisposeDT(dtNewTable)

                                End If 'check if table contain row
                            End If 'check skipwo = 0

                            iSkipWO = 0

                        Else
                            If iSkipWO = 0 Then
                                If Len(Trim(objSheet.range("B" & i).value)) > 0 Then
                                    '****************************
                                    'Get data from excel
                                    '****************************

                                    strSerialNumber = UCase(Trim(objSheet.range("B" & i).value))

                                    '*******************************
                                    'check if Sn exist w/out rcvd
                                    '*******************************
                                    Me.DisposeDT(dt1)
                                    strSQL = "select count(*) as cnt from tverdata where device_sn = '" & strSerialNumber & "' and WO_Name = '" & strWorkorder & "' and NewLoadFlag = 1 and RcvdFlag = 0;"
                                    Me.objMisc._SQL = strSQL
                                    dt1 = Me.objMisc.GetDataTable
                                    iSNExisted = dt1.Rows(0)("cnt")
                                    '*******************************

                                    If iSNExisted = 0 Then
                                        If Not IsDBNull(objSheet.range("A" & i).value) And Len(Trim(objSheet.range("A" & i).value)) Then
                                            strCapCode = UCase(Trim(objSheet.range("A" & i).value))
                                        Else
                                            strCapCode = ""
                                        End If

                                        If Not IsDBNull(objSheet.range("C" & i).value) And Len(Trim(objSheet.range("C" & i).value)) Then
                                            strModelNumber = UCase(Trim(objSheet.range("C" & i).value))
                                            If strModelNumber = "UNKNOWN" Then
                                                strModelNumber = ""
                                            End If
                                        Else
                                            strModelNumber = ""
                                        End If

                                        If Not IsDBNull(objSheet.range("D" & i).value) And Len(Trim(objSheet.range("D" & i).value)) Then
                                            strModel = UCase(Trim(objSheet.range("D" & i).value))
                                        Else
                                            strModel = ""
                                        End If

                                        '************************************
                                        'validate frequency
                                        '************************************
                                        If Not IsDBNull(objSheet.range("E" & i).value) And Len(Trim(objSheet.range("E" & i).value)) > 0 Then
                                            strFreqSec1 = ""
                                            strFreqSec2 = ""
                                            strFreq = Trim(objSheet.range("E" & i).value)

                                            iIndex = InStr(1, strFreq, ".")
                                            If iIndex > 0 Then
                                                strFreqSec1 = Mid(strFreq, 1, iIndex - 1)
                                                strFreqSec2 = Mid(strFreq, iIndex + 1)

                                                If Not IsNumeric(strFreqSec1) Then
                                                    strFreq = "000.0000"
                                                End If
                                                If Not IsNumeric(strFreqSec2) Then
                                                    strFreq = "000.0000"
                                                End If

                                                '************************************
                                                'pad '0' to front or back of freq
                                                If strFreq <> "000.0000" Then
                                                    If Len(strFreqSec1) <> 3 Then
                                                        strFreqSec1 = strFreqSec1.PadLeft(3, "0")
                                                    End If
                                                    If Len(strFreqSec2) <> 4 Then
                                                        strFreqSec2 = strFreqSec2.PadRight(4, "0")
                                                    End If
                                                    strFreq = strFreqSec1 & "." & strFreqSec2
                                                End If
                                                '************************************

                                                If Len(strFreq) <> 8 Then
                                                    strFreq = "000.0000"
                                                End If

                                                Me.DisposeDT(dt1)

                                                '************************************
                                                'insert freq into the system if freq does not exist
                                                If strFreq <> "" Then
                                                    strSQL = "select * from lfrequency where freq_Number = '" & strFreq & "';"
                                                    Me.objMisc._SQL = strSQL
                                                    dt1 = Me.objMisc.GetDataTable

                                                    If dt1.Rows.Count = 0 Then
                                                        strSQL = "INSERT INTO lfrequency (freq_Number) VALUES ('" & strFreq & "');"
                                                        Me.objMisc._SQL = strSQL
                                                        f = Me.objMisc.ExecuteNonQuery
                                                    End If
                                                End If
                                                '************************************
                                            Else
                                                strFreq = "000.0000"
                                            End If
                                        Else
                                            strFreq = ""
                                        End If

                                        '************************************
                                        'Create SKU Number from model number
                                        '************************************
                                        If Len(strModelNumber) > 0 Then
                                            strSKU = Mid$(strModelNumber, 8, 1)

                                            Select Case strSKU
                                                Case 8
                                                    strSKUNumber = "XXXXXXFLXX"
                                                Case 9
                                                    strSKUNumber = "XXFXXXXXXX"
                                                Case 3
                                                    strSKUNumber = "XXTXXXXXXX"
                                                Case 1
                                                    strSKUNumber = "XX4XXXXXXX"
                                                Case Else
                                                    strSKUNumber = ""
                                            End Select
                                        Else
                                            strSKUNumber = ""
                                        End If

                                        '***************************
                                        'Add new row
                                        '***************************
                                        NewRow = dtNewTable.NewRow()

                                        NewRow("WO_Name") = strWorkorder
                                        NewRow("Device_SN") = strSerialNumber
                                        NewRow("Device_CapCode") = strCapCode
                                        NewRow("Device_Model") = strModel
                                        NewRow("Device_Freq") = strFreq
                                        NewRow("Model_Number") = strModelNumber
                                        NewRow("SKU_Number") = strSKUNumber

                                        dtNewTable.Rows.Add(NewRow)
                                        NewRow = Nothing
                                        dtNewTable.AcceptChanges()
                                        '***************************
                                    End If 'Check if SN Existed

                                End If 'check if sn colum have value
                            End If  'check if skip wo
                        End If 'check begining or ending of wo
                    End If 'check for dbnull of SN column
                End While

                MsgBox("Load is completed.", MsgBoxStyle.Information, "Load Work Order")

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                NewRow = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dt2)
                Me.DisposeDT(dtNewTable)

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
        End Sub

        '***********************************************************
        'Added by Lan on 03/02/2007
        '***********************************************************
        Private Function CreateNewTable_VerizonWO() As DataTable
            Dim dtNewTable As DataTable
            Dim ColNew As DataColumn

            Try
                dtNewTable = New DataTable()    'Create new datatable

                ColNew = New DataColumn("WO_Name")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Device_SN")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Device_CapCode")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Device_Model")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Device_Freq")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Model_Number")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("SKU_Number")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                Return dtNewTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************
        'Added by Lan on 03/02/2007
        '***********************************************************
        Public Sub LoadUSAMobilityData(ByVal strFilePatth As String, _
                                       ByVal strUserName As String)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim R1 As DataRow
            Dim dt1, dt2 As DataTable

            Dim StrFieldList As String
            Dim strFieldData As String
            Dim strVendor As String = "PSS"
            Dim strReturnOfficeCode As String = "DDC"
            Dim strFromLocation As String = "ZDI"
            Dim strProcessedBy As String = strUserName
            Dim strWorkorderNumber As String = ""
            Dim strWorkorderQty As String = ""
            Dim strCreationDate As String = ""
            Dim strStartDate As String = ""
            Dim strDueDate As String = ""
            Dim strWorkorderSKU As String = ""

            Dim strShipToOfficeCode As String = ""
            Dim strFinishedGoodsSKU As String = ""
            Dim strInstructions As String = ""
            'Dim strCapCodeRange As String
            Dim strFreq As String = ""
            Dim strPad As String = ""
            Dim strStartCap As String = ""
            Dim strEndCap As String = ""

            Dim j As Integer = 0
            Dim strSQL As String = ""

            Dim i As Integer = 3
            Dim dtNewTable As DataTable
            Dim ColNew As DataColumn
            Dim NewRow As DataRow

            Try
                If strFilePatth = "" Then
                    Exit Sub
                End If

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)

                System.Windows.Forms.Application.DoEvents()

                '******************************
                'Create new datatable
                '******************************
                Me.DisposeDT(dtNewTable)

                dtNewTable = New DataTable()    'Create new datatable

                ColNew = New DataColumn("USA_WO")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_Qty")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_CreationDate")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_StartDate")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_DueDate")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_Channel")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_SKU")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_ShipTo")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_FinishedGoodsSKU")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_Instructions")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_CapLow")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_CapHigh")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_Freq")
                ColNew.DataType = System.Type.GetType("System.String")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("USA_Pad")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dtNewTable.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing
                '******************************

                j = 0
                While j < 10
                    i += 1
                    '******************************
                    'To avoid excessive looping
                    '******************************
                    If Len(Trim(objSheet.range("B" & i).value)) > 0 Then
                        j = 0
                    Else
                        j += 1
                    End If

                    '*************************
                    'dispose dt1
                    '*************************
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '**************************
                    'dispose dt2
                    '**************************
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If

                    If Len(Trim(objSheet.Range("B" & i).Value)) > 0 Then

                        '**************************
                        'Check if WO exist
                        '**************************
                        strWorkorderNumber = Trim(objSheet.Range("B" & i).Value)

                        strSQL = "select * from tusatest where USA_WO = '" & strWorkorderNumber & "';"
                        Me.objMisc._SQL = strSQL
                        dt2 = Me.objMisc.GetDataTable

                        If dt2.Rows.Count > 0 Then
                            MsgBox("Work Order '" & strWorkorderNumber & "' already existed in the system. This work order is skipped.")
                        Else
                            strShipToOfficeCode = Trim(objSheet.Range("A" & i).Value)
                            strWorkorderSKU = Trim(objSheet.Range("C" & i).Value)
                            strFinishedGoodsSKU = Trim(objSheet.Range("D" & i).Value)
                            strWorkorderQty = Trim(objSheet.Range("E" & i).Value)
                            strInstructions = Trim(objSheet.Range("F" & i).Value)
                            strPad = Len(Trim(objSheet.Range("G" & i).Value))
                            strStartCap = Trim(objSheet.Range("H" & i).Value)
                            strEndCap = Trim(objSheet.Range("J" & i).Value)

                            If Len(strShipToOfficeCode) = 0 Then
                                Throw New Exception("Ship to Location is missing for Work Order '" & strWorkorderNumber & "'. Please edit excel file (line " & i & ").")
                            End If
                            If Len(strWorkorderSKU) = 0 Then
                                Throw New Exception("Original Sku is missing for Work Order '" & strWorkorderNumber & "'. Please edit excel file(line " & i & ").")
                            End If
                            If Len(strFinishedGoodsSKU) = 0 Then
                                Throw New Exception("Finished Sku is missing for Work Order '" & strWorkorderNumber & "'. Please edit excel file(line " & i & ").")
                            End If
                            If Len(strInstructions) = 0 Then
                                Throw New Exception("Instruction Sku is missing for Work Order '" & strWorkorderNumber & "'. Please edit excel file(line " & i & ").")
                            End If
                            If IsNumeric(strWorkorderQty) = False Or Len(strWorkorderQty) = 0 Then
                                Throw New Exception("Work Order quantity of Work Order '" & strWorkorderNumber & "' is not in the right format. Please edit excel file(line " & i & ").")
                            End If
                            If CInt(strWorkorderQty) = 0 Then
                                Throw New Exception("Work Order '" & strWorkorderNumber & "' has quantity of zero. Please verify excel file(line " & i & ").")
                            End If


                            If Len(strStartCap) = 0 Then
                                strStartCap = "0"
                            End If
                            If Len(strEndCap) = 0 Then
                                strEndCap = "0"
                            End If

                            If CInt(strPad) = 8 Then
                                strPad = "9"
                            ElseIf CInt(strPad) = "6" Then
                                strPad = "7"
                            Else
                                strPad = "9"
                            End If

                            '******************
                            'validate capcode
                            '******************
                            If IsNumeric(strStartCap) = False Then
                                Throw New Exception("Start Capcode for this Work Order (" & strWorkorderNumber & ") is not in the correct format. Please edit excel file(line " & i & ").")
                            End If
                            If IsNumeric(strStartCap) = False Then
                                Throw New Exception("Start Capcode for this Work Order (" & strWorkorderNumber & ") is not in the correct format. Please edit the excel file(line " & i & ").")
                            End If

                            If Len(strStartCap) <> Len(strEndCap) Then
                                Throw New Exception("The Upper Cap Limit does not have the same number of characters as the Lower Cap Limit for this Work Order (" & strWorkorderNumber & "). Please edit the excel file(line " & i & ").")
                            End If

                            'check if end capcode is higher than the start capcode
                            If CInt(strEndCap) - CInt(strStartCap) < 0 Then
                                Throw New Exception("The Upper Cap Limit is Less Than the Lower Cap Limit for this Work Order (" & strWorkorderNumber & "). Please edit the excel file(line " & i & ").")
                            End If

                            '**********************
                            'Check for frequency
                            '**********************
                            Me.objMisc._SQL = ("SELECT * FROM lchannel2frequency WHERE C2F_Channel = '" & Mid(objSheet.Range("D" & i).Value, 9, 3) & "'")
                            dt1 = Me.objMisc.GetDataTable
                            If dt1.Rows.Count > 0 Then
                                strFreq = dt1.Rows(0)("C2F_Frequency")
                            Else
                                Throw New Exception("The frequency for this Work Order (" & strWorkorderNumber & ") does not exist in the system. Please edit the excel file or add this new Channel(" & Mid(objSheet.Range("D" & i).Value, 9, 3) & ") in to the system.")
                            End If

                            '**********************
                            'Add new row
                            '**********************
                            NewRow = dtNewTable.NewRow()

                            NewRow("USA_WO") = strWorkorderNumber
                            NewRow("USA_Qty") = CInt(strWorkorderQty)
                            NewRow("USA_CreationDate") = Format(Now, "mm/dd/yyyy")
                            NewRow("USA_StartDate") = DateAdd(DateInterval.Day, 2, Now)
                            NewRow("USA_DueDate") = Format(DateAdd(DateInterval.Day, 14, Now), "MM/dd/yyyy")
                            NewRow("USA_Channel") = Format(Mid(objSheet.Range("C" & i).Value, 1, 10), "MM/dd/yyyy")
                            NewRow("USA_SKU") = strWorkorderSKU
                            NewRow("USA_ShipTo") = strShipToOfficeCode
                            NewRow("USA_FinishedGoodsSKU") = strFinishedGoodsSKU
                            NewRow("USA_Instructions") = strInstructions
                            NewRow("USA_CapLow") = strStartCap
                            NewRow("USA_CapHigh") = strEndCap
                            NewRow("USA_Freq") = strFreq
                            NewRow("USA_Pad") = CInt(strPad)

                            dtNewTable.Rows.Add(NewRow)
                            NewRow = Nothing
                            dtNewTable.AcceptChanges()
                        End If
                    End If
                End While

                '*********************************
                'Insert data into tusatest
                '*********************************
                If dtNewTable.Rows.Count > 0 Then
                    For Each R1 In dtNewTable.Rows

                        StrFieldList = "(USA_WO, USA_Vendor, USA_ReturnOfficeCode, USA_Qty, USA_CreationDate, "
                        StrFieldList &= "USA_StartDate, USA_DueDate, USA_Channel, USA_SKU, USA_FromLocation, USA_ProcessedBy, "
                        StrFieldList &= "USA_ShipTo, USA_FinishedGoodsSKU, USA_Instructions, USA_CapLow, USA_CapHigh, USA_Freq, USA_Pad, NewLoadFlag, CameWithFileFlag)"

                        strFieldData = "('" & R1("USA_WO") & " ', '" & strVendor & "', '" & strReturnOfficeCode & "', " & R1("USA_Qty") & ", '" & R1("USA_CreationDate") & "', "
                        strFieldData &= "' " & R1("USA_StartDate") & "', '" & R1("USA_DueDate") & "', '" & R1("USA_Channel") & "', '" & R1("USA_SKU") & "', '" & strFromLocation & "', '" & strProcessedBy & "', "
                        strFieldData &= "' " & R1("USA_ShipTo") & "', '" & R1("USA_FinishedGoodsSKU") & "', '" & R1("USA_Instructions") & "', '" & R1("USA_CapLow") & "', '" & R1("USA_CapHigh") & "', '" & R1("USA_Freq") & "', " & R1("USA_Pad") & ", 1, 1);"

                        strSQL = "INSERT INTO tusatest " & StrFieldList & " VALUES " & strFieldData
                        Me.objMisc._SQL = strSQL
                        i += Me.objMisc.ExecuteNonQuery
                    Next R1
                End If

                MsgBox("Load is completed.", MsgBoxStyle.Information, MsgBoxStyle.Information)

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dt2)
                Me.DisposeDT(dtNewTable)

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

        '**********************************************************************
        'get frequency and channel from lchannel2frequency table
        '**********************************************************************
        Public Function GetChannels() As DataTable
            Dim strSql As String
            Try
                strSql = "Select CHF_ID, Concat(C2F_Channel, '   (', C2F_Frequency, ')') as 'Channel' from lchannel2frequency order by Channel;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        'Load all devices in abacus into tamericanmessdata table
        '***************************************************************
        Public Function LoadAMAbacusFullData(ByVal strFilePath As String, _
                                             ByVal booRefreshData As Boolean, _
                                             ByVal strLoc_Chng_Date As String) As Integer
            Dim objReader As StreamReader
            Dim strSql As String
            Dim strLine As String = ""
            Dim strArr As String()
            Dim booHeaderFound As Boolean = False
            Dim i As Integer = 0
            Dim dt1 As DataTable

            Try
                If booRefreshData = True Then
                    '******************************************
                    'Delete old data in tamericanmessdata table
                    '******************************************
                    strSql = "DELETE FROM tamericanmessdata;"
                    Me.objMisc._SQL = strSql
                    i = Me.objMisc.ExecuteNonQuery

                    strSql = "ALTER TABLE tamericanmessdata AUTO_INCREMENT = 1;"
                    Me.objMisc._SQL = strSql
                    i = Me.objMisc.ExecuteNonQuery
                End If


                '******************************************
                'Read data from input file
                '******************************************
                objReader = New StreamReader(strFilePath)

                'Loop through File
                While objReader.Peek <> -1
                    '****************************
                    'Read a line from Data file
                    '****************************
                    strLine = Trim(objReader.ReadLine())
                    strArr = strLine.Split("|")

                    If strArr.Length = 15 Then
                        If booHeaderFound = False Then
                            If Trim(strArr(0)) = "Co Cd" And _
                               Trim(strArr(1)) = "Serial Number" And _
                               Trim(strArr(2)) = "Own Cd" And _
                               Trim(strArr(3)) = "Stat Cd" And _
                               Trim(strArr(4)) = "Type" And _
                               Trim(strArr(5)) = "Chnl Cd" And _
                               Trim(strArr(6)) = "Color" And _
                               Trim(strArr(7)) = "Capcode 1" And _
                               Trim(strArr(8)) = "N-U" And _
                               Trim(strArr(9)) = "F-I" And _
                               Trim(strArr(10)) = "Loc Chg Date" And _
                               Trim(strArr(11)) = "Last Acct" And _
                               Trim(strArr(12)) = "Prev Acct" And _
                               Trim(strArr(13)) = "Equip Value" Then
                                booHeaderFound = True
                            End If
                        Else
                            If Trim(strArr(0)) <> "" And _
                               Trim(strArr(1)) <> "" And _
                               Trim(strArr(2)) <> "" And _
                               Trim(strArr(3)) <> "" And _
                               Trim(strArr(4)) <> "" And _
                               Trim(strArr(5)) <> "" And _
                               Trim(strArr(6)) <> "" And _
                               Trim(strArr(7)) <> "" And _
                               Trim(strArr(10)) <> "" Then
                                ' Trim(strArr(8)) <> "" And Trim(strArr(9)) <> "" And _

                                'Device in PSS location
                                'If Trim(strArr(3)) = "28" Then
                                Try
                                    If booRefreshData = True Then
                                        strSql = "INSERT INTO tamericanmessdata ( " & Environment.NewLine
                                        strSql &= "Co_Cd " & Environment.NewLine
                                        strSql &= ", Serial_Number " & Environment.NewLine
                                        strSql &= ", Own_Cd " & Environment.NewLine
                                        strSql &= ", Stat_Cd " & Environment.NewLine
                                        strSql &= ", Type " & Environment.NewLine
                                        strSql &= ", Chnl_Cd " & Environment.NewLine
                                        strSql &= ", Color " & Environment.NewLine
                                        strSql &= ", Capcode_1 " & Environment.NewLine
                                        strSql &= ", N_U " & Environment.NewLine
                                        strSql &= ", F_I " & Environment.NewLine
                                        strSql &= ", Loc_Chg_Date " & Environment.NewLine
                                        strSql &= ", Last_Acct " & Environment.NewLine
                                        strSql &= ", Prev_Acct " & Environment.NewLine
                                        strSql &= ", Equip_Value " & Environment.NewLine
                                        strSql &= ") VALUES ( " & Environment.NewLine
                                        strSql &= "'" & Trim(strArr(0)) & "'" & Environment.NewLine
                                        strSql &= ", '" & UCase(Trim(strArr(1))) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(2)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(3)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(4)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(5)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(6)) & "'" & Environment.NewLine
                                        strSql &= ", '" & UCase(Trim(strArr(7))) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(8)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(9)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Format(CDate(Trim(strArr(10))), "yyyy-MM-dd") & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(11)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(12)) & "'" & Environment.NewLine
                                        strSql &= ", '" & Trim(strArr(13)) & "'" & Environment.NewLine
                                        strSql &= ");"
                                        Me.objMisc._SQL = strSql
                                        i += Me.objMisc.ExecuteNonQuery
                                    Else
                                        strSql = "SELECT COUNT(*) AS Cnt FROM tamericanmessdata " & Environment.NewLine
                                        strSql &= "WHERE Loc_Chg_Date = '" & Format(CDate(Trim(strArr(10))), "yyyy-MM-dd") & "' " & Environment.NewLine
                                        strSql &= "AND Serial_Number = '" & UCase(Trim(strArr(1))) & "';"
                                        Me.objMisc._SQL = strSql
                                        dt1 = Me.objMisc.GetDataTable

                                        If dt1.Rows(0)("Cnt") = 0 Then
                                            strSql = "INSERT INTO tamericanmessdata ( " & Environment.NewLine
                                            strSql &= "Co_Cd " & Environment.NewLine
                                            strSql &= ", Serial_Number " & Environment.NewLine
                                            strSql &= ", Own_Cd " & Environment.NewLine
                                            strSql &= ", Stat_Cd " & Environment.NewLine
                                            strSql &= ", Type " & Environment.NewLine
                                            strSql &= ", Chnl_Cd " & Environment.NewLine
                                            strSql &= ", Color " & Environment.NewLine
                                            strSql &= ", Capcode_1 " & Environment.NewLine
                                            strSql &= ", N_U " & Environment.NewLine
                                            strSql &= ", F_I " & Environment.NewLine
                                            strSql &= ", Loc_Chg_Date " & Environment.NewLine
                                            strSql &= ", Last_Acct " & Environment.NewLine
                                            strSql &= ", Prev_Acct " & Environment.NewLine
                                            strSql &= ", Equip_Value " & Environment.NewLine
                                            strSql &= ") VALUES ( " & Environment.NewLine
                                            strSql &= "'" & Trim(strArr(0)) & "'" & Environment.NewLine
                                            strSql &= ", '" & UCase(Trim(strArr(1))) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(2)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(3)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(4)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(5)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(6)) & "'" & Environment.NewLine
                                            strSql &= ", '" & UCase(Trim(strArr(7))) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(8)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(9)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Format(CDate(Trim(strArr(10))), "yyyy-MM-dd") & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(11)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(12)) & "'" & Environment.NewLine
                                            strSql &= ", '" & Trim(strArr(13)) & "'" & Environment.NewLine
                                            strSql &= ");"
                                            Me.objMisc._SQL = strSql
                                            i += Me.objMisc.ExecuteNonQuery
                                        End If  'Check existed of SN
                                    End If  'Check if tamericanmessdata need to refresh
                                Catch ex1 As Exception
                                    '//Duplicate SN
                                End Try
                                'End If  'Location is PSS28
                            End If  'First 10 items were not empty
                        End If  'Check header
                    End If  'Current line in file contain 15 items

                    strLine = ""
                    strArr = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                End While  'loop through all record in a selected file

                If booHeaderFound = False Then
                    MsgBox("Can not find correct header in input file. No data has been loaded.", MsgBoxStyle.Information, "Load American Messaging Data")
                End If

                Return 1

            Catch ex As Exception
                Throw ex
            Finally
                strArr = Nothing
                objReader.Close()
                objReader = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '***************************************************************
        'Insert all devices in abacus where Loc_chg_date equal to
        '  user selected date into tverdata
        '***************************************************************
        Public Function LoadAMAbacusDataByLocChangeDtToTverdata(ByVal strLocChgDate As String) As Integer
            Dim strSql As String
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strFileName As String = "AM_" & strLocChgDate & ".xls"
            Dim strWorkorder As String = "SpecialWO"
            Dim strModelNumber As String = "UNKNOWN"
            Dim objGen As New Generic()
            Dim strRptFileName As String = "P:\Dept\2Way\Abacus Daily Reports\Loaded Rpt\" & strFileName

            Try
                '******************************************
                'Get data from tamericanmessdata table
                '******************************************
                strSql = "SELECT Serial_Number AS Device_SN, Capcode_1 as Device_CapCode, type as Device_Model, Loc_Chg_Date, Chnl_Cd, " & Environment.NewLine
                strSql &= "IF (C2F_Frequency is null, '000.0000', C2F_Frequency ) as Device_Freq, " & Environment.NewLine
                strSql &= " CASE " & Environment.NewLine
                strSql &= "   WHEN Capcode_1 like 'E%' THEN 'XXXXXXFLXX' " & Environment.NewLine
                strSql &= "   WHEN Capcode_1 like 'A%' THEN 'XXXXXXFLXX' " & Environment.NewLine
                strSql &= "   WHEN Serial_Number like '36%' THEN 'XXXXXXFLXX' " & Environment.NewLine
                strSql &= "   WHEN Serial_Number like 'UGB%' THEN 'XXXXXXFLXX' " & Environment.NewLine
                strSql &= "   WHEN (TRIM(Chnl_Cd) = 'P05' OR TRIM(Chnl_Cd) = 'P06' OR TRIM(Chnl_Cd) = 'P48' OR TRIM(Chnl_Cd) = 'P63' OR TRIM(Chnl_Cd) = 'T01' OR TRIM(Chnl_Cd) = 'C27' OR TRIM(Chnl_Cd) = 'C29' OR TRIM(Chnl_Cd) = 'C33' ) THEN 'XXTXXXXXXX' " & Environment.NewLine
                strSql &= "   WHEN (TRIM(Chnl_Cd) = 'P07' OR TRIM(Chnl_Cd) = 'P91' ) THEN 'XX4XXXXXXX' " & Environment.NewLine
                strSql &= "   WHEN (TRIM(Chnl_Cd) = 'T06' OR TRIM(Chnl_Cd) = '023' OR TRIM(Chnl_Cd) = '994' ) THEN 'XXFXXXXXXX' " & Environment.NewLine
                strSql &= "   Else 'XX4XXXXXXX' " & Environment.NewLine
                strSql &= " END AS SKU_Number " & Environment.NewLine
                strSql &= "FROM tamericanmessdata " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lchannel2frequency ON tamericanmessdata.Chnl_Cd = lchannel2frequency.C2F_Channel " & Environment.NewLine
                strSql &= "WHERE Stat_Cd = 28 " & Environment.NewLine
                strSql &= "AND Loc_Chg_Date = '" & strLocChgDate & "';"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                '******************************************
                'Loop through dt1
                '******************************************
                For Each R1 In dt1.Rows
                    '****************************
                    'Check for existing of SN
                    '****************************
                    strSql = "Select * FROM tverdata " & Environment.NewLine
                    strSql &= "WHERE NewLoadFlag = 1 " & Environment.NewLine
                    strSql &= "AND Loc_Chg_Date = '" & strLocChgDate & "'" & Environment.NewLine
                    strSql &= "AND LoadFileName = '" & strFileName & "'" & Environment.NewLine
                    strSql &= "AND Device_SN = '" & UCase(Trim(R1("Device_SN"))) & "';"
                    Me.objMisc._SQL = strSql
                    dt2 = Me.objMisc.GetDataTable

                    If dt2.Rows.Count = 0 Then
                        strSql = "INSERT INTO tverdata " & Environment.NewLine
                        strSql &= "( WO_Name " & Environment.NewLine
                        strSql &= ", Device_SN " & Environment.NewLine
                        strSql &= ", Device_CapCode " & Environment.NewLine
                        strSql &= ", Device_Model " & Environment.NewLine
                        strSql &= ", Device_Freq " & Environment.NewLine
                        strSql &= ", Device_Chnl_Cd " & Environment.NewLine
                        strSql &= ", Model_Number " & Environment.NewLine
                        strSql &= ", SKU_Number " & Environment.NewLine
                        strSql &= ", NewLoadFlag " & Environment.NewLine
                        strSql &= ", CameWithFileFlag " & Environment.NewLine
                        strSql &= ", LoadFileName " & Environment.NewLine
                        strSql &= ", Loc_Chg_Date " & Environment.NewLine
                        strSql &= ") VALUES " & Environment.NewLine
                        strSql &= "( '" & strWorkorder & "' " & Environment.NewLine
                        strSql &= ", '" & R1("Device_SN") & "'" & Environment.NewLine
                        strSql &= ", '" & R1("Device_CapCode") & "'" & Environment.NewLine
                        strSql &= ", '" & R1("Device_Model") & "'" & Environment.NewLine
                        strSql &= ", '" & R1("Device_Freq") & "'" & Environment.NewLine
                        strSql &= ", '" & R1("Chnl_Cd") & "'" & Environment.NewLine
                        strSql &= ", '" & strModelNumber & "'" & Environment.NewLine
                        strSql &= ", '" & R1("SKU_Number") & "'" & Environment.NewLine
                        strSql &= ", 1" & Environment.NewLine
                        strSql &= ", 1" & Environment.NewLine
                        strSql &= ", '" & strFileName & "'" & Environment.NewLine
                        strSql &= ", '" & strLocChgDate & "'" & Environment.NewLine
                        strSql &= ");"

                        Me.objMisc._SQL = strSql
                        i += Me.objMisc.ExecuteNonQuery
                    End If

                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                Next R1  'loop through all record in datatable

                objGen.CreateExelReport(dt1, 1, strRptFileName, 0)

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
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

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'CREATE WORK ORDER SECTION
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        '***************************************************
        Public Function GetUSAMobWOInfo(ByVal strWO As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select * from tusatest where usa_wo = '" & strWO & "';"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetMiscCustWOInfo(ByVal strWO As String, _
                                          ByVal iCust_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tmessmiscwodata where cust_id = " & iCust_id & " and mmw_wo = '" & strWO & "' order by mmw_id desc;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetParentMiscWO(ByVal iParentWO_ID As Integer, _
                                           ByVal iCust_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tmessmiscwodata " & Environment.NewLine
                strSql &= "where cust_id = " & iCust_id & Environment.NewLine
                strSql &= " and mmw_id = " & iParentWO_ID & Environment.NewLine
                strSql &= " order by mmw_id desc;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetAllChildWOs(ByVal iParentWO_ID As Integer, _
                                       ByVal iCust_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tmessmiscwodata " & Environment.NewLine
                strSql &= "where cust_id = " & iCust_id & Environment.NewLine
                strSql &= " and parent_mmw_id = " & iParentWO_ID & Environment.NewLine
                strSql &= " order by mmw_id desc;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetChildWOInfo(ByVal iParentWO_ID As Integer, _
                                       ByVal strChildWO As String, _
                                       ByVal iCust_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tmessmiscwodata where cust_id = " & iCust_id & " and parent_mmw_id = " & iParentWO_ID & " and mmw_wo = '" & strChildWO & "' order by mmw_id desc;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetPSSWOInfo(ByVal strWO_Name As String, _
                                     ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select * from tworkorder where WO_CustWO = '" & strWO_Name & "' and loc_id = " & iLoc_ID & ";"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function IsWorkOrderExist(ByVal strWO_Name As String, Optional ByVal iLoc_ID As Integer = 0) As Boolean
            Dim strSql As String = ""
            Dim bRet As Boolean = False
            Dim dt As DataTable

            Try
                strSql = "select * from tworkorder where WO_CustWO = '" & strWO_Name.Replace("'", "''") & "'"
                If iLoc_ID > 0 Then strSql &= " and loc_id = " & iLoc_ID & ";"
                objMisc._SQL = strSql
                dt = objMisc.GetDataTable
                If dt.Rows.Count > 0 Then bRet = True

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Function SaveWO(ByVal iPSSWo_id As Integer, _
                       ByVal iUSAWo_id As Integer, _
                       ByVal iParentMiscWO_ID As Integer, _
                       ByVal iChildMiscWO_ID As Integer, _
                       ByVal iChildWOFlg As Integer, _
                       ByVal iCust_id As Integer, _
                       ByVal strParentWOName As String, _
                       ByVal strChildWOName As String, _
                       ByVal iLoc_id As Integer, _
                       ByVal strWoMemo As String, _
                       ByVal iPO_id As Integer, _
                       ByVal iCameWithFile As Integer, _
                       ByVal strCapLow As String, _
                       ByVal strCapHigh As String, _
                       ByVal iCapLen As Integer, _
                       ByVal strFreq As String, _
                       ByVal strFinishedSku As String, _
                       ByVal strCustWoInstruction As String, _
                       ByVal strUserName As String, _
                       ByVal iUser_id As Integer, _
                       ByVal iSpecialProj As Integer) As Integer

            Dim i As Integer = 0
            Dim iDevRcvd As Integer = 0
            Dim objMessReceive As New PSS.Data.Buisness.MessReceive()
            Dim iNewUSAWo_id As Integer = 0
            Dim iNewMiscWo_id As Integer = 0
            Dim iCustWo_id As Integer = 0

            Try

                '*******************************
                'USA Mobility customer
                '*******************************
                If iCust_id = 1 Then

                    If iUSAWo_id = 0 Then
                        '***************************************
                        'Create USA Workorder and PSS Workorder
                        '***************************************
                        iNewUSAWo_id = Me.CreateUSAWo(strParentWOName, _
                                                      strFinishedSku, _
                                                      strUserName, _
                                                      strCustWoInstruction, _
                                                      strCapLow, _
                                                      strCapHigh, _
                                                      iCapLen, _
                                                      strFreq)

                        i += Me.CreatePSSWo(iCust_id, _
                                       iLoc_id, _
                                       iNewUSAWo_id, _
                                       strParentWOName, _
                                       strWoMemo, _
                                       iPO_id, _
                                       iCameWithFile, _
                                       iSpecialProj)

                    ElseIf iPSSWo_id = 0 Then
                        '***************************************
                        'Create PSS Workorder
                        '***************************************
                        i += Me.CreatePSSWo(iCust_id, _
                                            iLoc_id, _
                                            iNewMiscWo_id, _
                                            strParentWOName, _
                                            strWoMemo, _
                                            iPO_id, _
                                            iCameWithFile, _
                                            iSpecialProj)
                    Else
                        '***************************************
                        'Update USA Workorder and PSS Workorder
                        '***************************************
                        i += Me.UpdateUSAWo(iUSAWo_id, _
                                        strCapLow, _
                                        strCapHigh, _
                                        iCapLen, _
                                        strFreq, _
                                        strFinishedSku, _
                                        strUserName, _
                                        strCustWoInstruction)

                        i += Me.UpdatePSSWo(iPSSWo_id, _
                                  iLoc_id, _
                                  strWoMemo, _
                                  iPO_id, _
                                  iSpecialProj)

                    End If
                Else
                    '*******************************
                    'Not USA Mobility customer
                    '*******************************
                    'No Child pallet
                    If iChildWOFlg = 0 Then
                        If iParentMiscWO_ID = 0 Then
                            '************************************************
                            'Create Misc Customer Workorder and PSS Workorder
                            '************************************************
                            iNewMiscWo_id = Me.CreateMiscWo(strParentWOName, _
                                                            0, _
                                                            iUser_id, _
                                                            iCameWithFile, _
                                                            strCapLow, _
                                                            strCapHigh, _
                                                            iCapLen, _
                                                            strFinishedSku, _
                                                            strFreq, _
                                                            iCust_id)
                            i += Me.CreatePSSWo(iCust_id, _
                                                iLoc_id, _
                                                iNewMiscWo_id, _
                                                strParentWOName, _
                                                strWoMemo, _
                                                iPO_id, _
                                                iCameWithFile, _
                                                iSpecialProj)


                        ElseIf iPSSWo_id = 0 Then
                            '**********************
                            'Create PSS Workorder
                            '**********************                            
                            i += Me.CreatePSSWo(iCust_id, _
                                      iLoc_id, _
                                      iCustWo_id, _
                                      strParentWOName, _
                                      strWoMemo, _
                                      iPO_id, _
                                      iCameWithFile, _
                                      iSpecialProj)
                        Else
                            '***************************************
                            'Update Misc Customer Workorder and PSS Workorder
                            '***************************************
                            i += Me.UpdateMiscWo(iParentMiscWO_ID, _
                                                strCapLow, _
                                                strCapHigh, _
                                                iCapLen, _
                                                strFreq, _
                                                strFinishedSku, _
                                                iUser_id, _
                                                iCust_id)

                            i += Me.UpdatePSSWo(iPSSWo_id, _
                                       iLoc_id, _
                                       strWoMemo, _
                                       iPO_id, _
                                       iSpecialProj)


                        End If

                    ElseIf iChildWOFlg = 1 Then
                        '**********************
                        'Child pallet
                        '**********************
                        If iChildMiscWO_ID = 0 Then
                            '************************************************
                            'Create Child Misc Customer Workorder and PSS Workorder
                            '************************************************
                            iNewMiscWo_id = Me.CreateMiscWo(strChildWOName, _
                                                            iParentMiscWO_ID, _
                                                            iUser_id, _
                                                            iCameWithFile, _
                                                            strCapLow, _
                                                            strCapHigh, _
                                                            iCapLen, _
                                                            strFinishedSku, _
                                                            strFreq, _
                                                            iCust_id)
                            i += Me.CreatePSSWo(iCust_id, _
                                                iLoc_id, _
                                                iNewMiscWo_id, _
                                                strChildWOName, _
                                                strWoMemo, _
                                                iPO_id, _
                                                iCameWithFile, _
                                                iSpecialProj)


                        ElseIf iPSSWo_id = 0 Then
                            '**********************
                            'Create PSS Workorder
                            '**********************                            
                            i += Me.CreatePSSWo(iCust_id, _
                                      iLoc_id, _
                                      iCustWo_id, _
                                      strChildWOName, _
                                      strWoMemo, _
                                      iPO_id, _
                                      iCameWithFile, _
                                      iSpecialProj)
                        Else
                            '***************************************
                            'Update Child Misc Customer Workorder and PSS Workorder
                            '***************************************
                            i += Me.UpdateMiscWo(iChildMiscWO_ID, _
                                                strCapLow, _
                                                strCapHigh, _
                                                iCapLen, _
                                                strFreq, _
                                                strFinishedSku, _
                                                iUser_id, _
                                                iCust_id)

                            i += Me.UpdatePSSWo(iPSSWo_id, _
                                       iLoc_id, _
                                       strWoMemo, _
                                       iPO_id, _
                                       iSpecialProj)
                        End If
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objMessReceive = Nothing
            End Try
        End Function

        '*********************************************************************
        Public Function CreateMiscWo(ByVal strWO As String, _
                                     ByVal iParentMiscWO_ID As Integer, _
                                     ByVal iUserID As Integer, _
                                     ByVal iCameWithFile As Integer, _
                                     ByVal strCapLo As String, _
                                     ByVal strCapHigh As String, _
                                     ByVal iCapLen As Integer, _
                                     ByVal strSKU As String, _
                                     ByVal strFreq As String, _
                                     ByVal iCust_id As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim iWo_id As Integer = 0
            Dim dt1 As DataTable
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim R1 As DataRow
            Dim strServDate As String = ""

            Try
                strServDate = objGen.MySQLServerDateTime(1)

                strSql = "select mmw_id from tmessmiscwodata where mmw_wo = '" & strWO & "' and cust_id = " & iCust_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Throw New Exception("Workorder '" & strWO & "' was existed for the selected customer. Can not create it.")
                End If

                'insert
                strSql = "INSERT INTO tmessmiscwodata " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "user_id,  " & Environment.NewLine
                'strSql &= "mmw_WOQty, " & Environment.NewLine
                strSql &= "mmw_wo, " & Environment.NewLine
                strSql &= "mmw_CameWithFileFlag, " & Environment.NewLine
                If iCapLen > 0 Then
                    strSql &= "mmw_CapCodeLen, " & Environment.NewLine
                End If
                If strCapLo <> "" And strCapHigh <> "" Then
                    strSql &= "mmw_caplow, " & Environment.NewLine
                    strSql &= "mmw_caphigh, " & Environment.NewLine
                End If
                strSql &= "mmw_sku, " & Environment.NewLine
                strSql &= "mmw_freq, " & Environment.NewLine
                If iParentMiscWO_ID > 0 Then
                    strSql &= "parent_mmw_id, " & Environment.NewLine
                End If
                strSql &= "cust_id " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= iUserID & ", " & Environment.NewLine
                'strSql &= iCust_WO_Qty & ", " & Environment.NewLine
                strSql &= "'" & strWO & "', " & Environment.NewLine
                strSql &= iCameWithFile & ", " & Environment.NewLine
                If iCapLen > 0 Then
                    strSql &= iCapLen & ", " & Environment.NewLine
                End If
                If strCapLo <> "" And strCapHigh <> "" Then
                    strSql &= "'" & strCapLo & "', " & Environment.NewLine
                    strSql &= "'" & strCapHigh & "', " & Environment.NewLine
                End If

                If strSKU <> "" Then
                    strSql &= "'" & strSKU & "', " & Environment.NewLine
                Else
                    strSql &= "NULL, " & Environment.NewLine
                End If

                If strFreq <> "" Then
                    strSql &= "'" & strFreq & "', " & Environment.NewLine
                Else
                    strSql &= "NULL, " & Environment.NewLine
                End If
                If iParentMiscWO_ID > 0 Then
                    strSql &= iParentMiscWO_ID & "," & Environment.NewLine
                End If
                strSql &= iCust_id & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                strSql = "select mmw_id from tmessmiscwodata where mmw_wo = '" & strWO & "' and cust_id = " & iCust_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iWo_id = dt1.Rows(0)("mmw_id")
                Else
                    Throw New Exception("Customer Workorder_ID is not defined after created.")
                End If

                Return iWo_id

            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************************
        Private Function UpdateMiscWo(ByVal iMiscWo_id As Integer, _
                                ByVal strCapLo As String, _
                                ByVal strCapHigh As String, _
                                ByVal iCapLen As Integer, _
                                ByVal strFreq As String, _
                                ByVal strSKU As String, _
                                ByVal iUserID As String, _
                                ByVal iCust_id As Integer) As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strSetValues As String = ""

            Try
                '*************************
                'Get Misc Customer wo_info
                '*************************
                strSql = "select * from tmessmiscwodata where mmw_id = " & iMiscWo_id & " and cust_id = " & iCust_id & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Customer Workorder is not defined. Can not update.")
                End If

                '************************
                ' 'Update tmessmiscwodata
                '************************
                R1 = dt1.Rows(0)

                If Not IsDBNull(R1("mmw_caplow")) Then
                    If Trim(strCapLo) <> Trim(R1("mmw_caplow")) Then
                        strSetValues &= ", mmw_caplow = '" & Trim(strCapLo) & "'" & Environment.NewLine
                    End If
                End If
                If Not IsDBNull(R1("mmw_caphigh")) Then
                    If Trim(strCapHigh) <> Trim(R1("mmw_caphigh")) Then
                        strSetValues &= ", mmw_caphigh = '" & Trim(strCapHigh) & "'" & Environment.NewLine
                    End If
                End If
                If Not IsDBNull(R1("mmw_CapCodeLen")) Then
                    If Trim(iCapLen) <> Trim(R1("mmw_CapCodeLen")) Then
                        strSetValues &= ", mmw_CapCodeLen = " & Trim(iCapLen) & Environment.NewLine
                    End If
                End If
                'If Not IsDBNull(R1("mmw_WOQty")) Then
                '    If iCust_WO_Qty <> Trim(R1("mmw_WOQty")) Then
                '        strSetValues &= ", mmw_WOQty = " & Trim(iCust_WO_Qty) & Environment.NewLine
                '    End If
                'End If
                If Not IsDBNull(R1("mmw_sku")) Then
                    If UCase(Trim(strSKU)) <> UCase(Trim(R1("mmw_sku"))) Then
                        strSetValues &= ", mmw_sku = '" & UCase(Trim(strSKU)) & "'" & Environment.NewLine
                    End If
                End If
                If Not IsDBNull(R1("mmw_freq")) Then
                    If Trim(strFreq) <> Trim(R1("mmw_freq")) Then
                        strSetValues &= ", mmw_freq = '" & Trim(strFreq) & "'" & Environment.NewLine
                    End If
                End If

                If strSetValues <> "" Then
                    strSql = "update tmessmiscwodata set " & Environment.NewLine
                    strSql &= "user_id = " & iUserID & Environment.NewLine
                    strSql &= strSetValues
                    strSql &= "where mmw_id = " & iMiscWo_id & ";"
                    Me.objMisc._SQL = strSql
                    i = Me.objMisc.ExecuteNonQuery
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


        '******************************************************************
        Public Function CreateUSAWo(ByVal strWo As String, _
                                    ByVal strSKU As String, _
                                    ByVal strUserName As String, _
                                    ByVal strInstruction As String, _
                                    ByVal strCapLo As String, _
                                    ByVal strCapHigh As String, _
                                    ByVal iCapLen As String, _
                                    ByVal strFreq As String) As Integer

            Dim dt1 As DataTable
            Dim iWo_id As Integer = 0

            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()

            Dim strServDate As String = ""
            Dim strCreationDate As String = ""
            Dim strStartDate As String = ""
            Dim strDueDate As String = ""
            Dim strChannel As String = ""

            Try
                'Check if work order already existed
                strsql = "select USA_ID from tusatest where USA_WO = '" & strWo & "';"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Throw New Exception("USA Mobility Work Order '" & strWo & "' was existed. Can not create it.")
                End If

                strServDate = objGen.MySQLServerDateTime(1)
                strCreationDate = Format(Now, "mm/dd/yyyy")
                strStartDate = DateAdd(DateInterval.Day, 2, Now)
                strDueDate = Format(DateAdd(DateInterval.Day, 14, Now), "MM/dd/yyyy")
                strChannel = Format(Mid(strSKU, 1, 10), "MM/dd/yyyy")

                'insert
                strsql = "INSERT INTO tusatest " & Environment.NewLine
                strsql &= "( " & Environment.NewLine
                strsql &= "USA_WO, " & Environment.NewLine
                strsql &= "USA_Vendor, " & Environment.NewLine
                strsql &= "USA_ReturnOfficeCode, " & Environment.NewLine
                'strsql &= "USA_Qty, " & Environment.NewLine
                strsql &= "USA_CreationDate, " & Environment.NewLine
                strsql &= "USA_StartDate, " & Environment.NewLine
                strsql &= "USA_DueDate, " & Environment.NewLine
                strsql &= "USA_Channel, " & Environment.NewLine
                strsql &= "USA_FromLocation, " & Environment.NewLine
                strsql &= "USA_ProcessedBy, " & Environment.NewLine
                strsql &= "USA_FinishedGoodsSKU, " & Environment.NewLine
                strsql &= "USA_Instructions, " & Environment.NewLine
                strsql &= "USA_CapLow, " & Environment.NewLine
                strsql &= "USA_CapHigh, " & Environment.NewLine
                strsql &= "USA_Pad, " & Environment.NewLine
                strsql &= "USA_Freq, " & Environment.NewLine
                strsql &= "NewLoadFlag " & Environment.NewLine
                strsql &= ") " & Environment.NewLine
                strsql &= "VALUES " & Environment.NewLine
                strsql &= "( " & Environment.NewLine
                strsql &= "'" & strWo & "', " & Environment.NewLine
                strsql &= "'DDC', " & Environment.NewLine
                'strsql &= iCust_WO_Qty & ", " & Environment.NewLine
                strsql &= "'" & strCreationDate & "', " & Environment.NewLine
                strsql &= "'" & strStartDate & "', " & Environment.NewLine
                strsql &= "'" & strDueDate & "', " & Environment.NewLine
                strsql &= "'" & strChannel & "', " & Environment.NewLine
                strsql &= "'ZDI', " & Environment.NewLine
                strsql &= "'" & strUserName & "', " & Environment.NewLine

                If strSKU <> "" Then
                    strsql &= "'" & strSKU & "', " & Environment.NewLine
                Else
                    strsql &= "NULL, " & Environment.NewLine
                End If

                strsql &= "'" & strInstruction & "', " & Environment.NewLine
                strsql &= "'" & strCapLo & "', " & Environment.NewLine
                strsql &= "'" & strCapHigh & "', " & Environment.NewLine
                strsql &= "'" & iCapLen & "', " & Environment.NewLine

                If strFreq <> "" Then
                    strsql &= "'" & strFreq & "', " & Environment.NewLine
                Else
                    strsql &= "NULL, " & Environment.NewLine
                End If

                strsql &= 1 & " " & Environment.NewLine
                strsql &= ");"
                Me.objMisc._SQL = strsql
                i = Me.objMisc.ExecuteNonQuery

                'Get the insert wo_id
                strsql = "select USA_ID from tusatest where USA_WO = '" & strWo & "';"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iWo_id = dt1.Rows(0)("USA_ID")
                Else
                    Throw New Exception("USA Mobillity Workorder_ID is not defined after created.")
                End If

                Return iWo_id
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
            End Try
        End Function

        '**********************************************************************
        Private Function UpdateUSAWo(ByVal iUSA_id As Integer, _
                                ByVal strCapLo As String, _
                                ByVal strCapHigh As String, _
                                ByVal iCapLen As Integer, _
                                ByVal strFreq As String, _
                                ByVal strSKU As String, _
                                ByVal strUserName As String, _
                                ByVal strInstruction As String) As Integer

            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim strSetValues As String = ""
            Dim R1 As DataRow


            Try
                '***********************
                'Get USA wo_info
                '***********************
                strsql = "select * from tusatest where USA_ID = " & iUSA_id & ";"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("USA Mobility Workorder is not defined. Can not update.")
                End If

                '***********************
                'Update tusatest
                '***********************
                R1 = dt1.Rows(0)


                If Trim(strCapLo) <> Trim(R1("USA_CapLow")) Then
                    strSetValues &= ", USA_CapLow = '" & Trim(strCapLo) & "'" & Environment.NewLine
                    If IsDBNull(R1("USA_CapLow_Old")) Then
                        strSetValues &= ", USA_CapLow_Old = '" & Trim(R1("USA_CapLow")) & "'" & Environment.NewLine
                    End If
                End If
                If Trim(strCapHigh) <> Trim(R1("USA_CapHigh")) Then
                    strSetValues &= ", USA_CapHigh = '" & Trim(strCapHigh) & "'" & Environment.NewLine
                    If IsDBNull(R1("USA_CapHigh_Old")) Then
                        strSetValues &= ", USA_CapHigh_Old = '" & Trim(R1("USA_CapHigh")) & "'" & Environment.NewLine
                    End If
                End If
                If Trim(iCapLen) <> Trim(R1("USA_Pad")) Then
                    strSetValues &= ", USA_Pad = " & Trim(iCapLen) & Environment.NewLine
                    If IsDBNull(R1("USA_Pad_Old")) Then
                        strSetValues &= ", USA_Pad_Old = " & Trim(R1("USA_Pad")) & Environment.NewLine
                    End If
                End If
                If Trim(strFreq) <> Trim(R1("USA_Freq")) Then
                    strSetValues &= ", USA_Freq = '" & Trim(strFreq) & "'" & Environment.NewLine
                    If IsDBNull(R1("USA_Freq_Old")) Then
                        strSetValues &= ", USA_Freq_Old = '" & Trim(R1("USA_Freq")) & "'" & Environment.NewLine
                    End If
                End If
                If UCase(Trim(strSKU)) <> UCase(Trim(R1("USA_FinishedGoodsSKU"))) Then
                    strSetValues &= ", USA_FinishedGoodsSKU = '" & UCase(Trim(strSKU)) & "'" & Environment.NewLine
                    If IsDBNull(R1("USA_FinishedGoodsSKU_Old")) Then
                        strSetValues &= ", USA_FinishedGoodsSKU_Old = '" & UCase(Trim(R1("USA_FinishedGoodsSKU"))) & "'" & Environment.NewLine
                    End If
                End If
                'If Trim(iCust_WO_Qty) <> Trim(R1("USA_Qty")) Then
                '    strSetValues &= ", USA_Qty = " & Trim(iCust_WO_Qty) & Environment.NewLine
                '    If IsDBNull(R1("USA_Qty_Old")) Then
                '        strSetValues &= ", USA_Qty_Old = " & Trim(R1("USA_Qty")) & Environment.NewLine
                '    End If
                'End If

                If strSetValues <> "" Then
                    strsql = "update tusatest set " & Environment.NewLine
                    strsql &= "USA_ProcessedBy = '" & strUserName & "' " & Environment.NewLine
                    strsql &= strSetValues
                    strsql &= "where USA_ID = " & iUSA_id & ";"

                    Me.objMisc._SQL = strsql
                    i = Me.objMisc.ExecuteNonQuery
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


        '**************************************************************************
        Public Function CreatePSSWo(ByVal iCust_ID As Integer, _
                                    ByVal iLoc_ID As Integer, _
                                    ByVal iCustWo_id As Integer, _
                                    ByVal strWoName As String, _
                                    ByVal strWOMemo As String, _
                                    ByVal iPO_ID As Integer, _
                                    ByVal iHasDataFile As Integer, _
                                    ByVal iSpecialProj As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strServDate As String = ""
            Dim iWo_id As Integer = 0


            Try
                'Check if Work Order already existed
                strSql = "select wo_id from tworkorder " & Environment.NewLine
                strSql &= "where WO_CustWO = '" & strWoName & "' and " & Environment.NewLine
                strSql &= "Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Throw New Exception("Workorder '" & strWoName & "' was existed in our system. Can not create it.")
                End If


                strServDate = objGen.MySQLServerDateTime(1)

                'Add new PSS WO
                strSql = "INSERT INTO tworkorder " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "WO_CustWO, " & Environment.NewLine
                strSql &= "WO_Date, " & Environment.NewLine
                'strSql &= "WO_Quantity, " & Environment.NewLine
                strSql &= "WO_Memo, " & Environment.NewLine
                strSql &= "Loc_ID, " & Environment.NewLine
                strSql &= "Prod_ID, " & Environment.NewLine

                If iPO_ID <> 0 Then
                    strSql &= "PO_ID, " & Environment.NewLine
                End If

                strSql &= "Group_ID, " & Environment.NewLine
                strSql &= "WO_CameWithFile, " & Environment.NewLine
                strSql &= "WO_SpecialProj " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "'" & strWoName & "', " & Environment.NewLine
                strSql &= "'" & strServDate & "', " & Environment.NewLine
                'strSql &= iPSSWoQty & ", " & Environment.NewLine
                strSql &= "'" & strWOMemo & "', " & Environment.NewLine
                strSql &= iLoc_ID & ", " & Environment.NewLine
                strSql &= "1, " & Environment.NewLine

                If iPO_ID <> 0 Then
                    strSql &= iPO_ID & ", " & Environment.NewLine
                End If

                strSql &= "1, " & Environment.NewLine
                strSql &= iHasDataFile & ", " & Environment.NewLine
                strSql &= iSpecialProj & " " & Environment.NewLine
                strSql &= ");"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'get new wo_id
                strSql = "select wo_id from tworkorder " & Environment.NewLine
                strSql &= "where WO_CustWO = '" & strWoName & "' and " & Environment.NewLine
                strSql &= "Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iWo_id = dt1.Rows(0)("WO_ID")
                Else
                    Throw New Exception("PSS Workorder_ID is not defined after created.")
                End If

                'update
                If iCust_ID = 1 Then
                    strSql = "Update tusatest set PSS_WO_ID = " & iWo_id & " where USA_ID = " & iCustWo_id & ";"
                Else
                    strSql = "Update tmessmiscwodata set pss_wo_id = " & iWo_id & " where mmw_id = " & iCustWo_id & ";"
                End If

                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************************
        Public Function UpdatePSSWo(ByVal iPSSWo_id As Integer, _
                                  ByVal iLoc_ID As Integer, _
                                  ByVal strWOMemo As String, _
                                  ByVal iPO_ID As Integer, _
                                  ByVal iSpecialProj As Integer) As Integer

            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim strSetValues As String = ""
            Dim R1 As DataRow
            Dim iCnt As Integer = 0


            Try
                '*************************
                'Get Misc Customer wo_info
                '*************************
                strsql = "select * from tworkorder where wo_id = " & iPSSWo_id & ";"
                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("PSS Workorder is not defined. Can not update PSS Workorder.")
                End If


                '*************************
                'Update tworkorder
                '*************************
                R1 = dt1.Rows(0)


                If Not IsDBNull(R1("Loc_ID")) Then
                    If R1("Loc_ID") <> iLoc_ID Then
                        If iCnt <> 0 Then
                            strSetValues &= ", "
                        End If
                        iCnt += 1
                        strSetValues &= "Loc_ID = " & iLoc_ID & Environment.NewLine
                    End If
                End If

                If Not IsDBNull(R1("WO_Memo")) Then
                    If R1("WO_Memo") <> Trim(strWOMemo) Then
                        If iCnt <> 0 Then
                            strSetValues &= ", "
                        End If
                        iCnt += 1
                        strSetValues &= "WO_Memo = '" & Trim(strWOMemo) & "'" & Environment.NewLine
                    End If
                End If

                If Not IsDBNull(R1("PO_ID")) Then
                    If R1("PO_ID") <> iPO_ID Then
                        If iCnt <> 0 Then
                            strSetValues &= ", "
                        End If
                        iCnt += 1
                        If iPO_ID > 0 Then
                            strSetValues &= "PO_ID = " & iPO_ID & Environment.NewLine
                        Else
                            strSetValues &= "PO_ID = null " & Environment.NewLine
                        End If
                    End If
                End If

                If Not IsDBNull(R1("WO_SpecialProj")) Then
                    If R1("WO_SpecialProj") <> iSpecialProj Then
                        If iCnt <> 0 Then
                            strSetValues &= ", "
                        End If
                        iCnt += 1

                        strSetValues &= "WO_SpecialProj = " & iSpecialProj & Environment.NewLine
                    End If
                End If

                'If Not IsDBNull(R1("WO_Quantity")) Then
                '    If R1("WO_Quantity") <> iWO_Qty Then
                '        If iCnt <> 0 Then
                '            strSetValues &= ", "
                '        End If
                '        iCnt += 1
                '        strSetValues &= "WO_Quantity = " & iWO_Qty & Environment.NewLine
                '    End If
                'End If


                If strSetValues <> "" Then
                    strsql = "update tworkorder " & Environment.NewLine
                    strsql &= "SET " & strSetValues
                    strsql &= "where wo_id = " & iPSSWo_id & ";"

                    Me.objMisc._SQL = strsql
                    i = Me.objMisc.ExecuteNonQuery
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'MAP CUSTOMER MODEL TO PSS MODEL 
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        '*************************************CustModPssModMap
        Public Function GetCustModPssModMap(ByVal iCust_id As Integer, _
                                            ByVal strCustMod_Desc As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select * from tcustmodel_pssmodel_map " & Environment.NewLine
                strSql &= "where cust_id = " & iCust_id & " and cust_model_desc = '" & strCustMod_Desc & "';"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************CustModPssModMap
        Public Function SaveCustModPssModMap(ByVal iCust_id As Integer, _
                                             ByVal strCustMod_Desc As String, _
                                             ByVal iPssMod_id As Integer, _
                                             ByVal iInactiveFlg As Integer, _
                                             ByVal iCm_id As Integer) As Integer
            Dim strSql As String = ""
            Try
                If iCm_id > 0 Then
                    strSql = "UPDATE tcustmodel_pssmodel_map  " & Environment.NewLine
                    strSql &= "SET model_id = " & iPssMod_id & ", " & Environment.NewLine
                    strSql &= "cust_model_desc = '" & strCustMod_Desc & "', " & Environment.NewLine
                    strSql &= "cm_inactive = " & iInactiveFlg & Environment.NewLine
                    strSql &= "WHERE cm_id = " & iCm_id & ";"
                Else
                    strSql = "INSERT INTO  tcustmodel_pssmodel_map " & Environment.NewLine
                    strSql &= "( " & Environment.NewLine
                    strSql &= "cust_id, " & Environment.NewLine
                    strSql &= "model_id, " & Environment.NewLine
                    strSql &= "cust_model_desc, " & Environment.NewLine
                    strSql &= "cm_inactive " & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                    strSql &= "VALUES " & Environment.NewLine
                    strSql &= "( " & Environment.NewLine
                    strSql &= iCust_id & ", " & Environment.NewLine
                    strSql &= iPssMod_id & ", " & Environment.NewLine
                    strSql &= "'" & strCustMod_Desc & "', " & Environment.NewLine
                    strSql &= iInactiveFlg & ", " & Environment.NewLine
                    strSql &= ");"
                End If

                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'DATA MANIPULATION SECTION
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        '**************************************************MeessEditDevice
        Public Function GetMessDeviceInWIP(ByVal strDevice_sn As String, _
                                           ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select tdevice.* " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "where device_sn = '" & strDevice_sn & "' " & Environment.NewLine
                strSql &= " and prod_id = 1 " & Environment.NewLine
                strSql &= " and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= " AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        'Get Messaging Device Info
        Public Function GetMessDevice(ByVal strSN As String, _
                                      ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select tdevice.* " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "where device_sn = '" & strSN & "' " & Environment.NewLine
                strSql &= " and tworkorder.prod_id = 1 " & Environment.NewLine
                strSql &= " AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        'GetDeviceNoInInTray
        Public Function GetMessDevCntInTray(ByVal itray_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select ttray.tray_id, tdevice.WO_ID, count(*) as cnt " & Environment.NewLine
                strSql &= "from ttray " & Environment.NewLine
                strSql &= "inner join tdevice on ttray.tray_id = tdevice.tray_id " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "where ttray.tray_id = " & itray_id & Environment.NewLine
                strSql &= " and prod_id = 1 " & Environment.NewLine
                strSql &= "group by tdevice.tray_id;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        'GetDeviceNoInInWO
        Public Function GetMessDevCntWO(ByVal iWO_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select tworkorder.WO_ID, count(*) as cnt " & Environment.NewLine
                strSql &= "from tworkorder " & Environment.NewLine
                strSql &= "inner join tdevice on tworkorder.wo_id = tdevice.wo_id " & Environment.NewLine
                strSql &= "where tworkorder.wo_id = " & iWO_id & Environment.NewLine
                strSql &= " and prod_id = 1 " & Environment.NewLine
                strSql &= "group by tdevice.wo_id;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        'GetDeviceNoInInShipManifest
        Public Function GetMessDevCntInShipManifest(ByVal iShip_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select Ship_ID, tdevice.WO_ID count(*) as cnt  " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "where tdevice.Ship_ID = " & iShip_id & Environment.NewLine
                strSql &= " and prod_id = 1 " & Environment.NewLine
                strSql &= "group by tdevice.Ship_ID;"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function IsBilledDeviceExisted(ByVal strItemType As String, _
                                              ByVal iItem_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strSqlCondition As String = ""

            Try
                If strItemType = "SN" Then
                    strSqlCondition = " where Device_ID = " & iItem_ID & " "
                ElseIf strItemType = "TRAY ID" Then
                    strSqlCondition = " where Tray_ID = " & iItem_ID & " "
                ElseIf strItemType = "WO" Then
                    strSqlCondition = " where WO_ID = " & iItem_ID & " "
                End If

                strSql = "select count(*) as cnt from tdevice " & Environment.NewLine
                strSql &= strSqlCondition & " "
                strSql &= "and (Device_DateBill is not null and Device_DateBill <> '0000-00-00 00:00:00' and trim(Device_DateBill) <> '' );"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                Return dt1.Rows(0)("cnt")

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*********************************************************************
        Public Function IsShippedDeviceExisted(ByVal strItemType As String, _
                                               ByVal iItem_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strSqlCondition As String = ""

            Try
                If strItemType = "SN" Then
                    strSqlCondition = " where Device_ID = " & iItem_ID & " "
                ElseIf strItemType = "TRAY ID" Then
                    strSqlCondition = " where Tray_ID = " & iItem_ID & " "
                ElseIf strItemType = "WO" Then
                    strSqlCondition = " where WO_ID = " & iItem_ID & " "
                End If

                strSql = "select count(*) as cnt from tdevice " & Environment.NewLine
                strSql &= strSqlCondition & " "
                strSql &= "and (Device_DateShip is not null and Device_DateShip <> '0000-00-00 00:00:00' and trim(Device_DateShip) <> '' );"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                Return dt1.Rows(0)("cnt")

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '*********************************************************************
        Public Function IsInvoicedDeviceExisted(ByVal strItemType As String, _
                                                ByVal iItem_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strSqlCondition As String = ""

            Try
                If strItemType = "SN" Then
                    strSqlCondition = " where Device_ID = " & iItem_ID & " "
                ElseIf strItemType = "TRAY ID" Then
                    strSqlCondition = " where Tray_ID = " & iItem_ID & " "
                ElseIf strItemType = "WO" Then
                    strSqlCondition = " where WO_ID = " & iItem_ID & " "
                End If

                strSql = "select count(*) as cnt from tdevice " & Environment.NewLine
                strSql &= strSqlCondition & " "
                strSql &= "and Device_Invoice = 1;"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                Return dt1.Rows(0)("cnt")

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************************
        Public Function IsMessDBRDevices(ByVal strItemType As String, _
                                         ByVal iItem_ID As String, _
                                         ByRef iNoInvoicedDev As Integer) As Boolean


            Dim iMessDBR_BillcodeID As Integer = 25
            Dim iDBRShip_ID As Integer = 9999919
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim booResult As Boolean = True

            Try

                'Get Devices information
                strSql = "SELECT BillCode_ID, tdevice.* " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill on tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                If strItemType = "SN" Then
                    strSql &= "WHERE tdevice.Device_ID in ( " & iItem_ID & ");"
                ElseIf strItemType = "TRAY ID" Then
                    strSql &= "WHERE tdevice.Tray_ID in ( " & iItem_ID & ");"
                End If

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    'Check Ship_ID
                    If IsDBNull(R1("Ship_ID")) Then
                        booResult = False
                        Exit For
                    ElseIf R1("Ship_ID") = 0 Or R1("Ship_ID") <> iDBRShip_ID Then
                        booResult = False
                        Exit For
                    End If

                    ' DBR(billcode_id = 25) in tdevicebill
                    'Check Billcode_ID
                    If IsDBNull(R1("BillCode_ID")) Then
                        booResult = False
                        Exit For
                    ElseIf R1("BillCode_ID") = 0 Or R1("BillCode_ID") <> iMessDBR_BillcodeID Then
                        booResult = False
                        Exit For
                    End If

                    'Check for Invoice
                    If Not IsDBNull(R1("Device_Invoice")) AndAlso R1("Device_Invoice") = 1 Then
                        iNoInvoicedDev = 1
                        Exit For
                    End If

                Next R1

                Return booResult
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

        '**********************************************************************
        Public Function EditMessTrayMemo(ByVal strTray_ids As String, _
                                         ByVal strTray_memo As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                'update
                strSql = "update ttray " & Environment.NewLine
                strSql &= "set Tray_Memo = '" & strTray_memo & "' " & Environment.NewLine
                strSql &= "where " & Environment.NewLine
                strSql &= "tray_id in (" & strTray_ids & ");"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************************
        Public Function EditMessModel(ByVal strItemType As String, _
                                      ByVal strItem_IDs As String, _
                                      ByVal iModel_id As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim strSqlCondition As String = ""

            Try
                If strItemType = "TRAY ID" Then
                    strSqlCondition = " where Tray_ID in (" & strItem_IDs & ")"
                ElseIf strItemType = "WO" Then
                    strSqlCondition = " where WO_ID in (" & strItem_IDs & ")"
                End If

                'Update tdevice
                strSql = "update tdevice set Model_ID = " & iModel_id & " " & Environment.NewLine
                strSql &= strSqlCondition & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'update tdevicemetro
                strSql = "update tdevicemetro set Model_id = " & iModel_id & " " & Environment.NewLine
                strSql &= strSqlCondition & ";"
                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Function EditMessFreq(ByVal strItemType As String, _
                                     ByVal strItem_IDs As String, _
                                     ByVal iFreq_id As Integer, _
                                     ByVal iUser_id As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strServDate As String = ""

            Try
                strServDate = objGen.MySQLServerDateTime(1)

                'Get Freq information
                strSql = "Select * from lfrequency where freq_id = " & iFreq_id & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Invalid Frequency.")
                End If

                'Update tmessdata
                If strItemType = "SN" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "set freq_id_old = freq_id, " & Environment.NewLine
                    strSql &= "freq_id = " & iFreq_id & ", " & Environment.NewLine
                    strSql &= "freq_id_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "freq_id_change_date = '" & strServDate & "' " & Environment.NewLine
                    strSql &= " where Device_ID in (" & strItem_IDs & ");"
                ElseIf strItemType = "TRAY ID" Then
                    strSql = "UPDATE tdevice, tmessdata " & Environment.NewLine
                    strSql &= "set freq_id_old = freq_id, " & Environment.NewLine
                    strSql &= "freq_id = " & iFreq_id & ", " & Environment.NewLine
                    strSql &= "freq_id_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "freq_id_change_date = '" & strServDate & "' " & Environment.NewLine
                    strSql &= " where tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                    strSql &= " and tdevice.Tray_ID in (" & strItem_IDs & ");"
                ElseIf strItemType = "WO" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "set freq_id_old = freq_id, " & Environment.NewLine
                    strSql &= "freq_id = " & iFreq_id & ", " & Environment.NewLine
                    strSql &= "freq_id_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "freq_id_change_date = '" & strServDate & "' " & Environment.NewLine
                    strSql &= " where WO_ID in (" & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'update tdevicemetro
                If strItemType = "SN" Then
                    strSql = "update tdevice, tdevicemetro " & Environment.NewLine
                    strSql &= "SET  Freq_ID = " & iFreq_id & ", " & Environment.NewLine
                    strSql &= "deviceMetro_FreqCode = " & dt1.Rows(0)("freq_MotoCode") & Environment.NewLine
                    strSql &= "where tdevice.Device_ID in (" & strItem_IDs & ") " & Environment.NewLine
                    strSql &= "and tdevice.Tray_ID = tdevicemetro.Tray_ID  " & Environment.NewLine
                    strSql &= "and tdevice.Device_SN = tdevicemetro.deviceMetro_SN " & Environment.NewLine
                ElseIf strItemType = "TRAY ID" Then
                    strSql = "UPDATE tdevicemetro " & Environment.NewLine
                    strSql &= "SET  Freq_ID = " & iFreq_id & ", " & Environment.NewLine
                    strSql &= "deviceMetro_FreqCode = " & dt1.Rows(0)("freq_MotoCode") & Environment.NewLine
                    strSql &= "where Tray_ID in (" & strItem_IDs & ");"
                ElseIf strItemType = "WO" Then
                    strSql = "UPDATE tdevicemetro " & Environment.NewLine
                    strSql &= "SET  Freq_ID = " & iFreq_id & ", " & Environment.NewLine
                    strSql &= "deviceMetro_FreqCode = " & dt1.Rows(0)("freq_MotoCode") & Environment.NewLine
                    strSql &= "where WO_ID in (" & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**********************************************************************
        Public Function EditMessBaud(ByVal strItemType As String, _
                                     ByVal strItem_IDs As String, _
                                     ByVal iBaud_id As Integer, _
                                     ByVal iUser_id As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim objMessLabel As New PSS.Data.Buisness.MessLabel()
            Dim strServDate As String = ""
            Dim strSKU As String = ""

            Try
                strServDate = objGen.MySQLServerDateTime(1)

                'Get Freq information
                strSql = "Select * from lbaud where baud_id = " & iBaud_id & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Invalid Baud Rate.")
                End If

                'Determine the new SKU base on Baud Rate
                strSKU = objMessLabel.GetSKUFromBaudID(iBaud_id)

                'Update tmessdata
                If strItemType = "SN" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "set baud_id_old = baud_id, " & Environment.NewLine
                    strSql &= "baud_id = " & iBaud_id & ", " & Environment.NewLine
                    strSql &= "baud_id_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "baud_id_change_date = '" & strServDate & "', " & Environment.NewLine
                    strSql &= "SKU = '" & strSKU & "'" & Environment.NewLine
                    strSql &= " where Device_ID in (" & strItem_IDs & ");"
                ElseIf strItemType = "TRAY ID" Then
                    strSql = "UPDATE tdevice, tmessdata " & Environment.NewLine
                    strSql &= "set baud_id_old = baud_id, " & Environment.NewLine
                    strSql &= "baud_id = " & iBaud_id & ", " & Environment.NewLine
                    strSql &= "baud_id_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "baud_id_change_date = '" & strServDate & "', " & Environment.NewLine
                    strSql &= "SKU = '" & strSKU & "'" & Environment.NewLine
                    strSql &= " where tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                    strSql &= " and tdevice.Tray_ID in (" & strItem_IDs & ");"
                ElseIf strItemType = "WO" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "set baud_id_old = baud_id, " & Environment.NewLine
                    strSql &= "baud_id = " & iBaud_id & ", " & Environment.NewLine
                    strSql &= "baud_id_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "baud_id_change_date = '" & strServDate & "', " & Environment.NewLine
                    strSql &= "SKU = '" & strSKU & "'" & Environment.NewLine
                    strSql &= " where WO_ID in (" & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'update tdevicemetro
                If strItemType = "SN" Then
                    strSql = "update tdevice, tdevicemetro " & Environment.NewLine
                    strSql &= "SET  deviceMetro_OldSKU = deviceMetro_SKU, " & Environment.NewLine
                    strSql &= "deviceMetro_SKU = '" & strSKU & "'" & Environment.NewLine
                    strSql &= "where tdevice.Device_ID in (" & strItem_IDs & ") " & Environment.NewLine
                    strSql &= "and tdevice.Tray_ID = tdevicemetro.Tray_ID  " & Environment.NewLine
                    strSql &= "and tdevice.Device_SN = tdevicemetro.deviceMetro_SN " & Environment.NewLine
                ElseIf strItemType = "TRAY ID" Then
                    strSql = "UPDATE tdevicemetro " & Environment.NewLine
                    strSql &= "SET  deviceMetro_OldSKU = deviceMetro_SKU, " & Environment.NewLine
                    strSql &= "deviceMetro_SKU = '" & strSKU & "'" & Environment.NewLine
                    strSql &= "where Tray_ID in (" & strItem_IDs & ");"
                ElseIf strItemType = "WO" Then
                    strSql = "UPDATE tdevicemetro " & Environment.NewLine
                    strSql &= "SET  deviceMetro_OldSKU = deviceMetro_SKU, " & Environment.NewLine
                    strSql &= "deviceMetro_SKU = '" & strSKU & "'" & Environment.NewLine
                    strSql &= "where WO_ID in (" & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objMessLabel = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '**********************************************************************
        Public Function EditCapCode(ByVal strItemType As String, _
                                     ByVal strItem_IDs As String, _
                                     ByVal strCapCode As String, _
                                     ByVal iUser_id As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim objMessLabel As New PSS.Data.Buisness.MessLabel()
            Dim strServDate As String = ""
            Dim strSKU As String = ""

            Try
                strServDate = objGen.MySQLServerDateTime(1)

                'Update tmessdata
                If strItemType = "SN" Then
                    strSql = "UPDATE tmessdata " & Environment.NewLine
                    strSql &= "set capcode_old = capcode, " & Environment.NewLine
                    strSql &= "capcode = '" & strCapCode & "', " & Environment.NewLine
                    strSql &= "capcode_change_userid = " & iUser_id & ", " & Environment.NewLine
                    strSql &= "capcode_change_date = '" & strServDate & "' " & Environment.NewLine
                    strSql &= " where Device_ID in (" & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'update tdevicemetro
                If strItemType = "SN" Then
                    strSql = "update tdevice, tdevicemetro " & Environment.NewLine
                    strSql &= "SET  deviceMetro_CapCode = '" & strCapCode & "' " & Environment.NewLine
                    strSql &= "where tdevice.Device_ID in (" & strItem_IDs & ") " & Environment.NewLine
                    strSql &= "and tdevice.Tray_ID = tdevicemetro.Tray_ID  " & Environment.NewLine
                    strSql &= "and tdevice.Device_SN = tdevicemetro.deviceMetro_SN " & Environment.NewLine
                End If

                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objMessLabel = Nothing
            End Try
        End Function


        '**********************************************************************
        Public Function EditMessSN(ByVal strItemType As String, _
                                   ByVal iDevice_ID As Integer, _
                                   ByVal strNewSN As String, _
                                   ByVal iUser_id As Integer, _
                                   ByVal iCustID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim objMessLabel As New PSS.Data.Buisness.MessLabel()
            Dim strServDate As String = ""
            Dim strSKU As String = ""
            Dim strCapCode As String = ""
            Dim ideviceMetro_FreqCode As Integer = 0
            Dim iFreq_id As Integer = 0

            Try
                strServDate = objGen.MySQLServerDateTime(1)

                'Check new SN in WIP
                dt1 = Me.GetMessDeviceInWIP(strNewSN, iCustID)
                If dt1.Rows.Count > 0 Then
                    Throw New Exception("New Serial Number existed in the WIP. Can not Change SN")
                End If

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                'Get OldSN information
                strSql = "Select tdevice.*, deviceMetro_SKU, deviceMetro_CapCode, deviceMetro_FreqCode, Freq_ID" & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn" & Environment.NewLine
                strSql &= "where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("SN does not exist.")
                End If

                ''Update tdevice
                strSql = "update tdevice set " & Environment.NewLine
                If IsDBNull(dt1.Rows(0)("Device_OldSN")) = True Then
                    strSql &= "device_oldsn = device_sn, " & Environment.NewLine
                End If
                strSql &= "device_sn = '" & strNewSN & "' " & Environment.NewLine
                strSql &= "where device_id = " & iDevice_ID & ";"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery()

                ''Update tmessdata
                strSql = "UPDATE tmessdata " & Environment.NewLine
                strSql &= "set sn_changed = 1, " & Environment.NewLine
                strSql &= "sn_change_userid = " & iUser_id & ", " & Environment.NewLine
                strSql &= "sn_change_date = '" & strServDate & "' " & Environment.NewLine
                strSql &= " where Device_ID = " & iDevice_ID & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                'update tdevicemetro
                strSql = "DELETE FROM tdevicemetro " & Environment.NewLine
                strSql &= "where devicemetro_sn = '" & dt1.Rows(0)("Device_SN") & "';"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery()

                If Not IsDBNull(dt1.Rows(0)("deviceMetro_SKU")) Then
                    strSKU = dt1.Rows(0)("deviceMetro_SKU")
                End If
                If Not IsDBNull(dt1.Rows(0)("deviceMetro_CapCode")) Then
                    strCapCode = dt1.Rows(0)("deviceMetro_CapCode")
                End If
                If Not IsDBNull(dt1.Rows(0)("deviceMetro_FreqCode")) Then
                    ideviceMetro_FreqCode = dt1.Rows(0)("deviceMetro_FreqCode")
                End If
                If Not IsDBNull(dt1.Rows(0)("Freq_ID")) Then
                    iFreq_id = dt1.Rows(0)("Freq_ID")
                End If

                i = objMessLabel.ReplaceRecord_Tdevicemetro(strNewSN, _
                                                            strSKU, _
                                                            strCapCode, _
                                                            ideviceMetro_FreqCode, _
                                                            iFreq_id, _
                                                            dt1.Rows(0)("Model_ID"), _
                                                            dt1.Rows(0)("Tray_ID"), _
                                                            dt1.Rows(0)("WO_ID"))

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objMessLabel = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '**********************************************************************
        Public Function UnReceiveDeleteDevices(ByVal strItemType As String, _
                                               ByVal strItem_IDs As String, _
                                               ByVal iUnRecDelFlag As Integer, _
                                               ByVal strUserName As String, _
                                               ByVal dtItems As DataTable) As Integer
            Dim strSql As String = ""
            Dim strSqlCondition As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iParentWO_ID As Integer = 0
            Dim strParentWO_Name As String = ""
            Dim strSNs As String = ""
            Dim strDevice_IDs As String = ""
            Dim strTray_IDs As String = ""
            Dim strEditType As String = ""
            Dim i As Integer = 0
            Dim iTotalRcvdDevice As Integer = 0
            Dim objMessReceive As MessReceive

            Try
                '********************************
                'iUnRecDelFlag = 1 : Un-Receive
                'iUnRecDelFlag = 2 : Delete
                '********************************
                If iUnRecDelFlag = 1 Then
                    strEditType = "Un-Receive"
                Else
                    strEditType = "Delete"
                End If
                '********************************

                If strItemType = "SN" Then
                    strSqlCondition = " where device_ID in (" & strItem_IDs & ")"
                ElseIf strItemType = "TRAY ID" Then
                    strSqlCondition = " where Tray_ID in (" & strItem_IDs & ")"
                End If

                R1 = dtItems.Rows(0)
                '*********************************
                'Get Work Order information
                '*********************************
                strSql = "select * from tmessmiscwodata where pss_wo_id = " & R1("WO_ID") & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("'Customer Work Order' was not defined for scanned item(s).")
                End If

                '****************************
                'Get Parent WO Name
                '****************************
                If iUnRecDelFlag = 1 Then
                    If Not IsDBNull(dt1.Rows(0)("parent_mmw_id")) Then
                        iParentWO_ID = dt1.Rows(0)("parent_mmw_id")
                        If Not IsNothing(dt1) Then
                            dt1.Dispose()
                            dt1 = Nothing
                        End If

                        strSql = "select * from tmessmiscwodata where mmw_id = " & iParentWO_ID & ";"
                        Me.objMisc._SQL = strSql
                        dt1 = Me.objMisc.GetDataTable

                        If dt1.Rows.Count = 0 Then
                            Throw New Exception("'Parent Work Order' was not defined for scanned item(s).")
                        Else
                            strParentWO_Name = Trim(dt1.Rows(0)("mmw_wo"))
                        End If
                    End If
                End If

                '*********************************
                'Get devices information
                '*********************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                strSql = "select * from tdevice " & Environment.NewLine
                strSql &= strSqlCondition & " " & Environment.NewLine
                strSql &= "order by tray_id;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                R1 = Nothing
                i = 0

                For Each R1 In dt1.Rows
                    '**************************************************
                    'Build string SNs to delete devices in tdevicemetro
                    '**************************************************
                    If strSNs = "" Then
                        strSNs &= "'" & R1("device_sn") & "'"
                    Else
                        strSNs &= ",'" & R1("device_sn") & "'"
                    End If

                    '**********************************************************
                    'If scanned items are tray_id then we need device_id list 
                    ' to delete it from tmessdata and reset RcvdFlag in tverdata.
                    'If scanned items are SN then we need tray_id list to remove
                    ' device out from tdevicemetro table.
                    '**********************************************************
                    If strItemType = "TRAY ID" Then
                        If strDevice_IDs = "" Then
                            strDevice_IDs &= R1("Device_ID")
                        Else
                            strDevice_IDs &= "," & R1("Device_ID")
                        End If
                    ElseIf strItemType = "SN" Then
                        If i <> R1("Tray_ID") Then
                            If strTray_IDs = "" Then
                                strTray_IDs &= R1("Tray_ID")
                            Else
                                strTray_IDs &= "," & R1("Tray_ID")
                            End If
                        End If

                        i = R1("Tray_ID")
                    End If
                Next R1

                i = 0
                '*********************************
                '1: Delete devices in tdevice
                '*********************************
                strSql = "delete from tdevice " & Environment.NewLine
                strSql &= strSqlCondition & ";"
                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                '*********************************
                '2: Delete devices in tmessdata
                '*********************************
                If strItemType = "TRAY ID" Then
                    strSql = "delete from tmessdata " & Environment.NewLine
                    strSql &= "where device_id in (" & strDevice_IDs & ");"
                    Me.objMisc._SQL = strSql
                    i += Me.objMisc.ExecuteNonQuery
                Else
                    strSql = "delete from tmessdata " & Environment.NewLine
                    strSql &= strSqlCondition & ";"
                    Me.objMisc._SQL = strSql
                    i += Me.objMisc.ExecuteNonQuery
                End If

                '*******************************************
                '3: Update RcvdFlag, Device_ID in tverdata and 
                '    move devices back to parent Work Order 
                '    if devices belong to child Work Order
                '********************************************
                strSql = "Update tverdata " & Environment.NewLine
                If iUnRecDelFlag = 1 Then
                    If iParentWO_ID > 0 Then
                        strSql &= "set WO_Name = '" & strParentWO_Name & "', RcvdFlag = 0, Device_ID = NULL " & Environment.NewLine
                    Else
                        strSql &= "set RcvdFlag = 0, Device_ID = NULL " & Environment.NewLine
                    End If
                Else
                    strSql &= "set RcvdFlag = 9 " & Environment.NewLine
                End If

                If strItemType = "TRAY ID" Then
                    strSql &= "where Device_ID in (" & strDevice_IDs & "); "
                Else
                    strSql &= strSqlCondition & "; "
                End If
                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                '********************************************************
                '4: keep user name and edit type in ttray.tray_AuditMemo
                '********************************************************
                strSql = "update ttray set Tray_AuditMemo = '" & strEditType & " by " & strUserName & "' " & Environment.NewLine
                If strItemType = "TRAY ID" Then
                    strSql &= strSqlCondition & ";"
                Else
                    strSql &= " where tray_id in (" & strTray_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                '*********************************
                '5: Delete devices in tdevicemetro
                '*********************************
                If strItemType = "TRAY ID" Then
                    strSql = "delete from tdevicemetro " & Environment.NewLine
                    strSql &= strSqlCondition & ";"
                    Me.objMisc._SQL = strSql
                    i += Me.objMisc.ExecuteNonQuery
                Else
                    strSql = "delete from tdevicemetro " & Environment.NewLine
                    strSql &= "where devicemetro_SN in (" & strSNs & ")" & Environment.NewLine
                    strSql &= " and WO_ID = " & dtItems.Rows(0)("WO_ID") & ";"
                    Me.objMisc._SQL = strSql
                    i += Me.objMisc.ExecuteNonQuery
                End If

                objMessReceive = New MessReceive()
                '****************************************
                'Get total received device for workorder
                '****************************************
                iTotalRcvdDevice = objMessReceive.GetWORcvdQty(dtItems.Rows(0)("WO_ID"))
                '****************************************
                '6: Update WO_Qty
                '****************************************
                i += objMessReceive.UpdatePSSWOQty(dtItems.Rows(0)("WO_ID"), iTotalRcvdDevice)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtItems) Then
                    dtItems.Dispose()
                    dtItems = Nothing
                End If
                objMessReceive = Nothing
            End Try
        End Function

        Public Function GetEditDeviceInfo(ByVal strInputType As String, ByVal strItem_IDs As String) As DataTable
            Dim strSql As String = ""

            Try
                'Get Devices information
                strSql = "SELECT Device_ID, Prod_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                If strInputType = "SN" Then
                    strSql &= "WHERE Device_ID in ( " & strItem_IDs & ");"
                ElseIf strInputType = "TRAY ID" Then
                    strSql &= "WHERE Tray_ID in ( " & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function DeleteDeviceCode(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                'Delete DBR Code
                strSql = "DELETE FROM tdevicecodes " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ResetShipInfo(ByVal strInputType As String, ByVal strItem_IDs As String) As Integer
            Dim strSql As String = ""

            Try
                'Reset ship information in tdevice
                strSql = "UPDATE tdevice, tmessdata " & Environment.NewLine
                strSql &= "SET Device_DateShip = null, Device_ShipWorkDate = NULL, ship_id = null, Shift_ID_Ship = 0 " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id = 3 " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_EntryDt = now() " & Environment.NewLine
                If strInputType = "SN" Then
                    strSql &= "WHERE tdevice.device_id = tmessdata.device_id and  tdevice.Device_ID in ( " & strItem_IDs & ");"
                ElseIf strInputType = "TRAY ID" Then
                    strSql &= "WHERE tdevice.device_id = tmessdata.device_id and Tray_ID in ( " & strItem_IDs & ");"
                End If

                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************
        Public Function GetDBRPallett(ByVal strInputType As String, _
                                      ByVal iItem_ID As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iDBR_Pallett As Integer = 0

            Try
                strSql = "SELECT DISTINCT Pallett_ID" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine

                If strInputType = "SN" Then
                    strSql &= "WHERE Device_ID = " & iItem_ID & ";"
                ElseIf strInputType = "TRAY ID" Then
                    strSql &= "WHERE Tray_ID = " & iItem_ID & ";"
                End If

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Pallett_ID")) Then
                        iDBR_Pallett = dt1.Rows(0)("Pallett_ID")
                    End If
                End If

                Return iDBR_Pallett

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function


        '**********************************************************************
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        'CREATE CAPCODE SHEET
        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        Public Function CreateCapcodeSheet(ByVal strPrefix As String, _
                                            ByVal iCapcodeLen As Integer, _
                                            ByVal iCapcodeRange As Integer, _
                                            ByVal iCapcodeStartNum As Integer) As Integer

            'strChannel = String.Format("{0:D3}", CInt(strChannel))

            Dim strArr(CInt(Math.Round((iCapcodeRange / 4) + 0.5)), 4) As String
            Dim iCount As Long = 0
            Dim i As Integer = 0
            Dim j As Integer = 0

            '*************************************
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                For i = 0 To CInt(Math.Round((iCapcodeRange / 4) + 0.5)) - 1
                    For j = 0 To 3
                        strArr(i, j) = strPrefix & String.Format("{0:D" & iCapcodeLen & "}", iCapcodeStartNum + iCount)
                        iCount += 1

                        If iCount = iCapcodeRange Then
                            Exit For
                        End If
                    Next j
                    If iCount = iCapcodeRange Then
                        Exit For
                    End If
                Next i

                '**************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True             'Make excel visible to user
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape

                objSheet = objExcel.Sheets("Sheet1")
                objSheet.Range("A1", "D" & CInt(Math.Round((iCapcodeRange / 4) + 0.5))).Value = strArr

                objSheet.Cells.Select()
                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()
            Catch ex As Exception
                Throw ex
            Finally
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '**********************************************************************
        Public Function VerifyDataFrSN(ByVal strFilePath As String) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim dt1, dt2, dtData As DataTable
            Dim R1, R2, drNewRow As DataRow
            Dim i As Integer = 0
            Dim strSql As String = ""
            Dim strSN As String = ""
            Dim strModel_Code As String = ""
            Dim strFailReason As String = ""
            Dim iRow As Integer = 1
            Dim iDataIndex As Integer = 0


            Try
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePath)
                objExcel.Application.DisplayAlerts = False
                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = True

                dtData = New DataTable()
                Generic.AddNewColumnToDataTable(dtData, "SN", "System.String", "")
                Generic.AddNewColumnToDataTable(dtData, "ModelCode", "System.String", "")
                Generic.AddNewColumnToDataTable(dtData, "FailReason", "System.String", "")

                While i < 25
                    strSN = UCase(Trim(objSheet.Range("A" & iRow).Value))
                    strModel_Code = UCase(Trim(objSheet.Range("B" & iRow).Value))
                    strFailReason = UCase(Trim(objSheet.Range("C" & iRow).Value))

                    If strSN <> "" Then

                        drNewRow = dtData.NewRow
                        drNewRow("SN") = strSN
                        drNewRow("ModelCode") = strModel_Code
                        drNewRow("FailReason") = strFailReason
                        dtData.Rows.Add(drNewRow)
                        dtData.AcceptChanges()
                        drNewRow = Nothing

                        strSN = ""
                        strModel_Code = ""
                        strFailReason = ""
                        i = 0
                    Else
                        i += 1
                    End If

                    iRow += 1
                End While

                iRow = 1

                If dtData.Rows.Count > 0 Then
                    objSheet = objExcel.Worksheets(2)
                    objSheet.Range("A" & iRow).FormulaR1C1 = "SN"
                    objSheet.Range("B" & iRow).FormulaR1C1 = "Model Code"
                    objSheet.Range("C" & iRow).FormulaR1C1 = "Failure Reason"
                    objSheet.Range("D" & iRow).FormulaR1C1 = "In"
                    objSheet.Range("E" & iRow).FormulaR1C1 = "Out"
                    iRow += 1

                    For iDataIndex = 0 To dtData.Rows.Count - 1
                        strSN = dtData.Rows(iDataIndex)("SN")
                        strModel_Code = dtData.Rows(iDataIndex)("ModelCode")
                        strFailReason = dtData.Rows(iDataIndex)("FailReason")

                        '***********************
                        'Get SN Info
                        '***********************
                        strSql = "SELECT Device_ID, Device_DateRec, Device_DateShip " & Environment.NewLine
                        strSql &= "FROM tdevice " & Environment.NewLine
                        strSql &= "Where Loc_ID = 19 and Device_SN = '" & strSN & "' " & Environment.NewLine
                        strSql &= "Order by Device_ID desc;"
                        dt1 = Me.objMisc.GetDataTable(strSql)

                        If dt1.Rows.Count > 0 Then
                            R1 = dt1.Rows(0)
                            'For Each R1 In dt1.Rows
                            objSheet.Range("A" & iRow).FormulaR1C1 = strSN
                            objSheet.Range("B" & iRow).FormulaR1C1 = strModel_Code
                            objSheet.Range("C" & iRow).FormulaR1C1 = strFailReason

                            If Not IsDBNull(R1("Device_DateRec")) Then
                                objSheet.Range("D" & iRow).FormulaR1C1 = R1("Device_DateRec")
                            End If
                            If Not IsDBNull(R1("Device_DateShip")) Then
                                objSheet.Range("E" & iRow).FormulaR1C1 = R1("Device_DateShip")
                            Else
                                objSheet.Range("A" & iRow & ":C" & iRow).Select()
                                With objExcel.Selection.Interior
                                    .ColorIndex = 37
                                End With
                            End If

                            'Get Part Info
                            strSql = "SELECT BillCode_Desc FROM tdevicebill " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                            strSql &= "WHERE tdevicebill.Device_ID = " & R1("Device_ID") & " " & Environment.NewLine
                            strSql &= "Order by billtype_id, BillCode_Desc;"
                            dt2 = Me.objMisc.GetDataTable(strSql)

                            For i = 0 To dt2.Rows.Count - 1
                                R2 = dt2.Rows(i)
                                objSheet.Range(Chr(70 + i).ToString.ToUpper & iRow).FormulaR1C1 = R2("BillCode_Desc").ToString
                            Next i

                            R2 = Nothing
                            If Not IsNothing(dt2) Then
                                dt2.Dispose()
                                dt2 = Nothing
                            End If

                            iRow += 1
                            'Next R1
                        Else
                            objSheet.Range("A" & iRow).FormulaR1C1 = strSN
                            objSheet.Range("B" & iRow).FormulaR1C1 = strModel_Code
                            objSheet.Range("C" & iRow).FormulaR1C1 = strFailReason
                            'objSheet.Range("A" & iRow & ":C" & iRow).Select()
                            'With objExcel.Selection.Interior
                            '    .ColorIndex = 37
                            'End With
                            iRow += 1
                        End If

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
                        strSql = ""
                        strSN = ""
                        strModel_Code = ""
                        strFailReason = ""
                    Next iDataIndex
                End If

                objBook.SaveAs(strFilePath)

                Return dtData.Rows.Count
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

        '**********************************************************************
        'Start AMSLevel3Mapping

        Public Function GetMapCodes() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT 0 AS AMSLevel3MapCodesID, '** Unassigned **' AS Description" & Environment.NewLine
                strSQL &= "UNION" & Environment.NewLine
                strSQL &= "SELECT AMSLevel3MapCodesID, Description" & Environment.NewLine
                strSQL &= "FROM production.AMSLevel3MapCodes" & Environment.NewLine
                strSQL &= "ORDER BY Description"

                Return Me.objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetBillCodes() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT DISTINCT A.billcode_id, IFNULL(D.AMSLevel3MapCodesID, 0) AS AMSLevel3MapCodesID, A.billcode_desc AS 'Bill Code', IFNULL(E.Description, '** Unassigned **') AS 'Level 3 Assigned Code'" & Environment.NewLine
                strSQL &= "FROM production.lbillcodes A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tpsmap B ON A.billcode_id = B.billcode_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.llaborlvl C ON B.laborlvl_id = C.laborlvl_id" & Environment.NewLine
                strSQL &= "LEFT JOIN production.AMSLevel3Mappings D ON B.BillCode_ID = D.BillCode_ID" & Environment.NewLine
                strSQL &= "LEFT JOIN production.AMSLevel3MapCodes E ON D.AMSLevel3MapCodesID = E.AMSLevel3MapCodesID" & Environment.NewLine
                strSQL &= "WHERE C.Active = 1 AND C.laborlevel >= 3 AND B.prod_id = 1" & Environment.NewLine
                strSQL &= "ORDER BY 'Bill Code'"

                Return Me.objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub DropBillCode(ByVal iBillCodeID As Integer)
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM production.AMSLevel3Mappings" & Environment.NewLine
                strSQL &= String.Format("WHERE BillCode_ID = {0}", iBillCodeID)

                Me.objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub UpdateBillCodeMapping(ByVal iBillCodeID As Integer, ByVal iAMSLevel3MapCodesID As Integer)
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.AMSLevel3Mappings" & Environment.NewLine
                strSQL &= String.Format("WHERE BillCode_ID = {0}", iBillCodeID)

                If Me.objMisc.GetIntValue(strSQL) = 0 Then
                    strSQL = "INSERT INTO production.AMSLevel3Mappings (BillCode_ID, AMSLevel3MapCodesID)" & Environment.NewLine
                    strSQL &= String.Format("VALUES ({0}, {1})", iBillCodeID, iAMSLevel3MapCodesID)
                Else
                    strSQL = "UPDATE production.AMSLevel3Mappings" & Environment.NewLine
                    strSQL &= String.Format("SET AMSLevel3MapCodesID = {0}", iAMSLevel3MapCodesID) & Environment.NewLine
                    strSQL &= String.Format("WHERE BillCode_ID = {0}", iBillCodeID)
                End If

                Me.objMisc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'End AMSLevel3Mapping


        Public Function GetABACUSDownloadedData(ByVal strBeginDTime As String, _
                                                ByVal strEndDTime As String, _
                                                ByVal bDownloaded1NotReceived2Received3 As Integer) As DataTable
            Dim strSQL As String

            Try
                Select Case bDownloaded1NotReceived2Received3
                    Case 1 'all downloaded data for date time of a period
                        strSQL = "SELECT * FROM tverdata WHERE ver_timestamp BETWEEN '" & strBeginDTime & "' AND  '" & strEndDTime & "';"
                    Case 2 'downloaded but not received yet for date time of a period
                        strSQL = "SELECT * FROM tverdata WHERE (device_ID IS NULL OR LENGTH(TRIM(device_ID))=0) AND ver_timestamp BETWEEN '" & strBeginDTime & "' AND  '" & strEndDTime & "';"
                    Case 3 'downloaded and received for date time of a period
                        strSQL = "SELECT * FROM tverdata WHERE device_ID >0 AND ver_timestamp BETWEEN '" & strBeginDTime & "' AND  '" & strEndDTime & "';"
                End Select

                Return Me.objMisc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

