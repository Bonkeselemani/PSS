'Option Explicit On 

'Imports PSS.Data.Production
'Imports System.Data.OleDb
'Imports System.IO
'Imports System.Text
'Imports Microsoft.VisualBasic
'Imports System.Drawing.Printing

'Public Class DbrPartRecovery

'    Private objMisc As Production.Misc
'    Private dt, dtTemp As DataTable
'    Private r As DataRow
'    Private arrData(0, 2) As String
'    Private strSQL As String = ""
'    Private x, _
'    iTrans, _
'    iProd As Integer
'    Private blnInsert As Boolean

'    '***************************************************
'    Private Shared iDevice As Long
'    Public Shared Property _DeviceID()
'        Get
'            Return iDevice
'        End Get
'        Set(ByVal Value)
'            iDevice = Value
'        End Set
'    End Property

'    Private Shared iBillCode As Integer
'    Public Shared Property _BillCode()
'        Get
'            Return iBillCode
'        End Get
'        Set(ByVal Value)
'            iBillCode = Value
'        End Set
'    End Property

'    Private Shared iEmployee As Long
'    Public Shared Property _Employee()
'        Get
'            Return iEmployee
'        End Get
'        Set(ByVal Value)
'            iEmployee = Value
'        End Set
'    End Property

'    Private Shared sMachine As String
'    Public Shared Property _Machine()
'        Get
'            Return sMachine
'        End Get
'        Set(ByVal Value)
'            sMachine = Value
'        End Set
'    End Property

'    Private Shared iUser As String
'    Public Shared Property _User()
'        Get
'            Return iUser
'        End Get
'        Set(ByVal Value)
'            iUser = Value
'        End Set
'    End Property

'    Private Shared iShift As String
'    Public Shared Property _Shift()
'        Get
'            Return iShift
'        End Get
'        Set(ByVal Value)
'            iShift = Value
'        End Set
'    End Property
'    '***************************************************

'    Public Sub New(ByVal Device As Long, ByVal Employee As Integer, ByVal Machine As String, ByVal User As Integer, ByVal Shift As Integer)

'        '//Get these data elements and verify their values
'        _DeviceID = Device
'        _Employee = Employee
'        _Machine = Machine
'        _User = User
'        _Shift = Shift

'    End Sub

'    Public Function makeDBR() As Integer
'        Dim blnBuildArray As Boolean
'        Dim blnWriteAudit As Boolean
'        Dim blnWriteRecovery As Boolean
'        Dim blnWritePartTransaction As Boolean

'        If _DeviceID > 0 Then
'            '//DATA VALIDATION HERE
'            iProd = getProdID()

'            '//DATA VALIDATION HERE

'            blnBuildArray = BuildArray()
'            If blnBuildArray = True Then

'                Dim trans As OleDb.OleDbTransaction
'                trans.Begin(IsolationLevel.ReadCommitted)
'                '//WRITE RECORDS TO AUDIT TABLE
'                Try
'                    blnWriteAudit = writeAuditEntry(arrData)
'                Catch ex As Exception
'                    Return -5
'                End Try
'                '//WRITE RECORDS TO DBR PARTS RECOVERY TABLE
'                Try
'                    blnWriteRecovery = writeRecoveryEntry(arrData)
'                Catch ex As Exception
'                    Return -4
'                End Try
'                '//WRITE RECORDS TO TPARTTRANSACTION TABLE
'                Try
'                    blnWritePartTransaction = writePartTransaction(arrData)
'                Catch ex As Exception
'                    Return -3
'                End Try
'                '//UNBILL DEVICE
'                '//BILL DEVICE DBR
'                trans.Commit()
'            End If
'        End If
'    End Function

'    Public Function BuildArray() As Boolean
'        BuildArray = False
'        If _DeviceID > 0 Then    'CONTINUE
'            dt = getBillCodes()

'            ReDim arrData(dt.Rows.Count - 1, 3)

'            For x = 0 To dt.Rows.Count - 1
'                r = dt.Rows(x)
'                If r("Billcode_ID") > 0 Then
'                    _BillCode = r("Billcode_ID")
'                    iTrans = getTransactionCount()
'                    '//Add to array
'                    arrData(x, 0) = _DeviceID
'                    arrData(x, 1) = _BillCode
'                    arrData(x, 2) = iTrans

'                    If iTrans < 0 Then
'                        arrData(x, 3) = -1 '//DO NOT PROCESS
'                    ElseIf iTrans = 0 Then
'                        arrData(x, 3) = -1 '//DO NOT PROCESS
'                    Else
'                        arrData(x, 3) = iTrans * -1
'                    End If
'                End If
'            Next
'            Return True
'        Else
'            Return False
'        End If
'    End Function

'    Private Function getBillCodes() As DataTable
'        '//GET AN ARRAY OF BILLCODES
'        strSQL = "SELECT Billcode_ID FROM tdevicebill WHERE Device_ID = " & _DeviceID & ";"
'        objMisc._SQL = strSQL
'        dtTemp = objMisc.GetDataTable
'        Return dtTemp
'    End Function

'    Private Function getProdID() As Integer
'        Dim i As Integer
'        strSQL = "SELECT prod_id FROM tdevice INNER JOIN tmodel " & Environment.NewLine
'        strSQL &= "ON tdevice.model_id = tmodel.model_id WHERE " & Environment.NewLine
'        strSQL &= "tdevice.device_id = " & _DeviceID & ";"
'        objMisc._SQL = strSQL
'        dt = objMisc.GetDataTable
'        If dt.Rows.Count > 0 Then
'            r = dt.Rows(0)
'            Return r("prod_id")
'        Else
'            Return 0
'        End If
'    End Function

'    Private Function getTransactionCount() As Integer
'        Dim iTransCount As Integer
'        If validateParameters() = -1 Then Return -1
'        strSQL = "SELECT sum(trans_amount) as iInv FROM tparttransaction WHERE Device_ID = " & _DeviceID & " AND BillCode_ID = " & _BillCode & "GROUP BY billcode_id;"
'        objMisc._SQL = strSQL
'        dt = objMisc.GetDataTable
'        If dt.Rows.Count <> 1 Then
'            Return -2
'        Else
'            Return dt.Rows(0)(0)
'        End If
'    End Function

'    Private Function writeAuditEntry(ByVal arrData As Array) As Boolean
'        Dim i As Integer = 0
'        For x = 0 To UBound(arrData)
'            If arrData(x, 3) = 1 Then
'                '//PROCESS RECORD
'                strSQL = "INSERT INTO tdbr_audit " & Environment.NewLine
'                strSQL &= "(transaction_value, date_rec, device_id, billcode_id) " & Environment.NewLine
'                strSQL &= "VALUES " & Environment.NewLine
'                strSQL &= "(" & arrData(x, 2) & ", " & Environment.NewLine
'                strSQL &= Format(Now, "yyyy-MM-dd") & ", " & Environment.NewLine
'                strSQL &= arrData(x, 0) & ", " & Environment.NewLine
'                strSQL &= arrData(x, 2) & ");"
'                objMisc._SQL = strSQL
'                i = objMisc.ExecuteNonQuery
'            End If
'            i = 0
'        Next
'    End Function

'    Private Function writeRecoveryEntry(ByVal arrData As Array) As Boolean
'        Dim i As Integer = 0
'        For x = 0 To UBound(arrData)
'            If arrData(x, 3) = 1 Then
'                '//PROCESS RECORD
'                strSQL = "INSERT INTO tdbr_recovery " & Environment.NewLine
'                strSQL &= "(device_id, billcode_id, prod_id, user_id, employee_no, trans_amount, " & Environment.NewLine
'                strSQL &= "trans_shift_id, trans_workdate, trans_machine) " & Environment.NewLine
'                strSQL &= "VALUES " & Environment.NewLine
'                strSQL &= "(" & arrData(x, 0) & ", " & Environment.NewLine
'                strSQL &= arrData(x, 1) & ", " & Environment.NewLine
'                strSQL &= iProd & ", " & Environment.NewLine
'                strSQL &= _User & ", " & Environment.NewLine
'                strSQL &= _Employee & ", " & Environment.NewLine
'                strSQL &= (arrData(x, 2) * -1) & ", " & Environment.NewLine
'                strSQL &= _Shift & ", " & Environment.NewLine
'                strSQL &= "(" & Format(Now, "yyyy-MM-dd") & ", " & Environment.NewLine
'                strSQL &= _Machine & ");"
'                objMisc._SQL = strSQL
'                i = objMisc.ExecuteNonQuery
'            End If
'            i = 0
'        Next
'        Return True
'    End Function

'    'Public Function writePartTransaction(ByVal arrData As Array) As Boolean
'    '    '//This method should be used only to nullify consumed data 
'    '    '//in the tparttransaction table.
'    '    'Dim i As Integer
'    '    'For x = 0 To UBound(arrData)
'    '    'If arrData(x, 3) = 1 Then
'    '    '    '//PROCESS RECORD
'    '    '    strSQL = "INSERT INTO tparttransaction " & Environment.NewLine
'    '    '    strSQL &= "(device_id, billcode_id, prod_id, user_id, date_rec, employee_no, trans_amount, " & Environment.NewLine
'    '    '    strSQL &= "shift_id_trans, workdate, machinename) " & Environment.NewLine
'    '    '    strSQL &= "VALUES " & Environment.NewLine
'    '    '    strSQL &= "(" & arrData(x, 0) & ", " & Environment.NewLine
'    '    '    strSQL &= arrData(x, 1) & ", " & Environment.NewLine
'    '    '    strSQL &= iProd & ", " & Environment.NewLine
'    '    '    strSQL &= _User & ", " & Environment.NewLine
'    '    '    strSQL &= "(" & Format(Now, "yyyy-MM-dd") & ", " & Environment.NewLine
'    '    '    strSQL &= _Employee & ", " & Environment.NewLine
'    '    '    strSQL &= arrData(x, 2) & ", " & Environment.NewLine
'    '    '    strSQL &= _Shift & ", " & Environment.NewLine
'    '    '    strSQL &= "(" & Format(Now, "yyyy-MM-dd") & ", " & Environment.NewLine
'    '    '    strSQL &= _Machine & ");"
'    '    '    objMisc._SQL = strSQL
'    '    '    i = objMisc.ExecuteNonQuery
'    '    'End If
'    '    'i = 0
'    '    'Next
'    '    Return True
'    'End Function

'    Private Function validateParameters() As Integer
'        Dim strErr As String = ""
'        If IsDBNull(_DeviceID) Then strErr = "Undetermined Device Identifier"
'        If IsDBNull(_DeviceID) < 1 Then strErr = "Invalid Device Identifier"
'        If IsDBNull(_BillCode) Then strErr = "Undetermined BillCode"
'        If IsDBNull(_BillCode) < 1 Then strErr = "Invalid BillCode"
'        If Len(Trim(strErr)) > 0 Then
'            MsgBox("The Device ID and Billcode ID values are not acceptable. Function aborted.", MsgBoxStyle.Critical, "ERROR")
'            Return -1
'        Else
'            Return 0
'        End If
'    End Function

'    Protected Overrides Sub Finalize()
'        dt = Nothing
'        dtTemp = Nothing
'        objMisc = Nothing
'        MyBase.Finalize()
'    End Sub

'End Class
