Imports Microsoft.Data.Odbc
Namespace Buisness
    'Public Class clsBiz
    '    '***********************************************************************
    '    'Declare variables here
    '    '***********************************************************************
    '    Private objData As Production.Misc
    '    Private objLib As MyLib.Utility
    '    Private strStartDt As String = Format(Now, "yyyy-MM-dd 00:00:00")
    '    Private strEndDt As String = Format(Now, "yyyy-MM-dd 23:59:59")
    '    Private Shared strPostingDt1 As String = Format(Now, "MM-dd-yyyy hh-mm-ss")
    '    Private Shared strPostingDt As String = Format(Now, "MM-dd-yyyy")

    '    Private strFileDir As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\Exceptions\"
    '    Private _strFileDir As String = strFileDir
    '    Private strDispDecrementFilePath_AR As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\AR_DispDecrement.txt"
    '    Private strDispDecrementFilePath_RL As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\RL_DispDecrement.txt"
    '    Private strDispIncrementFilePath_AR As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\AR_DispIncrement.txt"
    '    Private strDispIncrementFilePath_RL As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\RL_DispIncrement.txt"
    '    Private strPartsDecrementFilePath As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\PartsDecrement.txt"
    '    'Private strPartsIncrementFilePath As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\PartsIncrement.txt"

    '    'Exception file paths
    '    Private strInsufficientBinQtyFilePath As String = strFileDir & "InsufficientBinQty.txt"
    '    Private strBinAndItemNotInNavisionFilePath As String = strFileDir & "BinAndItemNotInNavision.txt"
    '    Private strItemNotInNavisionFilePath As String = strFileDir & "ItemNotInNavision.txt"
    '    Private strBinNotInNavisionFilePath As String = strFileDir & "BinNotInNavision.txt"
    '    'Private strInsufficientBinQtyFilePath As String = "R:\Asset Recovery Adjustments\" & strPostingDt & "\Exceptions\InsufficientBinQty.txt"
    '    'Private strBinAndItemNotInNavisionFilePath As String = "R:\Asset Recovery Adjustments\" & strPostingDt & "\Exceptions\BinAndItemNotInNavision.txt"
    '    'Private strItemNotInNavisionFilePath As String = "R:\Asset Recovery Adjustments\" & strPostingDt & "\Exceptions\ItemNotInNavision.txt"
    '    'Private strBinNotInNavisionFilePath As String = "R:\Asset Recovery Adjustments\" & strPostingDt & "\Exceptions\BinNotInNavision.txt"
    '    Private strLogFilePath As String = "R:\Asset Recovery Adjustments\Log.txt"

    '    'For IT Backup
    '    Private strFileRootDir As String = "R:\Asset Recovery Adjustments\" & strPostingDt1 & "\"
    '    Private strFileBackupRootDir As String = "R:\Backup Asset Recovery Adjustments\" & strPostingDt1 & "\"
    '    Private strFileBackupDir As String = "R:\Backup Asset Recovery Adjustments\" & strPostingDt1 & "\Exceptions\"

    '    'Private iBinNotInNavision As Integer = 0
    '    'Private iInsufficientBinQty As Integer = 0
    '    'Private iBinAndItemNotInNavision As Integer = 0
    '    'Private iItemNotInNavision As Integer = 0

    '    Private strBinCode As String = ""
    '    Private strItemNo As String = ""
    '    Private iQuantity As Integer = 0
    '    Private strEntryType As String = ""

    '    Private iDept As Integer = 1000
    '    Private strPostingGrp As String = ""
    '    Private dtNavisionItem As DataTable = Nothing
    '    Private dtNavisionBinContent As DataTable = Nothing

    '    Private Shared iCust_ID As Integer
    '    Public Shared Property CustID() As Integer
    '        Get
    '            Return iCust_ID
    '        End Get
    '        Set(ByVal Value As Integer)
    '            iCust_ID = Value
    '        End Set
    '    End Property

    '    Private Shared iEx As Integer = 0
    '    Public Shared Property Ex() As Integer
    '        Get
    '            Return iEx
    '        End Get
    '        Set(ByVal Value As Integer)
    '            iEx = Value
    '        End Set
    '    End Property

    '    '***********************************************************************
    '    'Backs up files
    '    '***********************************************************************
    '    Public Function BackupFiles() As Integer
    '        Dim i As Integer = 0
    '        i = objLib.Create_Directory(strFileBackupDir)
    '        i = objLib.Create_Directory(strFileBackupRootDir)
    '        i = objLib.CopyAllFilesFromOneDirToAnother(_strFileDir, strFileBackupDir)
    '        i = objLib.CopyAllFilesFromOneDirToAnother(strFileRootDir, strFileBackupRootDir)
    '        Return i
    '    End Function
    '    '***********************************************************************
    '    'Locks/Unlocks the set of finished goods (being moved to Navision) with a distinct flag
    '    '9 - Lock;  1 - Unlock
    '    '***********************************************************************
    '    Public Function LockUnlockFinishedGoods(ByVal iLockUnlock As Integer) _
    '                                            As Integer
    '        Dim strsql As String = ""
    '        Dim iLockStatus As Integer = 100        'Magic number :)

    '        If iLockUnlock = 9 Then     'When locking
    '            iLockStatus = 1
    '        ElseIf iLockUnlock = 1 Then 'When unlocking
    '            iLockStatus = 9
    '        End If

    '        Try
    '            strsql = "Update tdevice " & Environment.NewLine
    '            strsql += "inner join tdisposition on tdevice.device_id = tdisposition.device_id " & Environment.NewLine
    '            strsql += "set tdevice.device_finishedgoods = " & iLockUnlock & " " & Environment.NewLine
    '            strsql += "where " & Environment.NewLine
    '            strsql += "tdevice.device_finishedgoods = " & iLockStatus & Environment.NewLine
    '            If iLockUnlock = 9 Then
    '                strsql += " and tdisposition.disp_NavDt is NULL;"
    '            End If

    '            objData._SQL = strsql
    '            Return objData.ExecuteNonQuery

    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.LockUnlockFinishedGoods(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            objData._SQL = ""
    '        End Try
    '    End Function

    '    '***********************************************************************
    '    'Updates Navision transferred devices
    '    '***********************************************************************
    '    Public Function UpdateNavisionTransferredDevices() As Integer
    '        Dim strsql As String = ""
    '        Dim strDt As String = ""

    '        Try
    '            strDt = Format(Now(), "yyyy-MM-dd HH:mm:ss")

    '            strsql = "Update tdisposition " & Environment.NewLine
    '            strsql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            strsql += "set tdisposition.Disp_NavDt = '" & strDt & "' " & Environment.NewLine
    '            strsql += "where " & Environment.NewLine
    '            strsql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            strsql += "tdisposition.disp_NavDt is NULL;"

    '            objData._SQL = strsql
    '            Return objData.ExecuteNonQuery

    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.UpdateNavisionTransferredDevices(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            objData._SQL = ""
    '        End Try
    '    End Function

    '    '***********************************************************************
    '    'Write to log file
    '    '***********************************************************************
    '    Public Function WriteToLogFile(ByVal strMsg As String)
    '        objLib.WriteToLogFile(strMsg, strLogFilePath)
    '    End Function
    '    '***********************************************************************
    '    'Send Mail  
    '    '***********************************************************************
    '    Public Function SendMail()
    '        Const _smtpServer As String = "svr_pssimail"
    '        Const _MailFrom As String = "itnotifications@productsupportservices.com"
    '        Const _MailTo As String = "mmclaughlin@productsupportservices.com"
    '        'Const _MailTo As String = "amohammad@productsupportservices.com"

    '        'If iBinNotInNavision > 0 Or iInsufficientBinQty > 0 Or iBinAndItemNotInNavision > 0 Or iItemNotInNavision > 0 Then
    '        Dim ObjLib As New MyLib.VBNETMAIL()
    '        Try
    '            With ObjLib

    '                .SMTPServer = _smtpServer
    '                .MailFrom = _MailFrom
    '                .MailTo = _MailTo
    '                .Subject = "Inventory Exceptions"
    '                .Body = "Please see the ""Exception Files"" in the directory... " & _strFileDir

    '                'If iBinNotInNavision > 0 Then
    '                '    .FileAttachment = strBinNotInNavisionFilePath
    '                'End If
    '                'If iInsufficientBinQty > 0 Then
    '                '    .FileAttachment = strInsufficientBinQtyFilePath
    '                'End If
    '                'If iBinAndItemNotInNavision > 0 Then
    '                '    .FileAttachment = strBinAndItemNotInNavisionFilePath
    '                'End If
    '                'If iItemNotInNavision > 0 Then
    '                '    .FileAttachment = strItemNotInNavisionFilePath
    '                'End If

    '                Return .SendMail
    '            End With
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.SendMail(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            ObjLib = Nothing
    '        End Try
    '        'End If
    '    End Function
    '    '***********************************************************************
    '    'This creates file for decrimented SKUs/Items
    '    '***********************************************************************
    '    Public Function DecrementedSKUs_ReverseLogistics() As Integer
    '        Dim dt As New DataTable()
    '        Dim R1 As DataRow
    '        Dim iFlag As Integer = 0
    '        Dim strsql As String = ""
    '        Dim strFileLine As String = ""

    '        strBinCode = "AR-PRODUCTION"
    '        strEntryType = "Negative"
    '        strPostingGrp = "RL"

    '        Try
    '            strsql = "Select disp_old, tsku.sku_number, Count(*) as Moved " & Environment.NewLine
    '            strsql += "from tdisposition " & Environment.NewLine
    '            strsql += "inner join tsku on tdisposition.disp_old = tsku.sku_id " & Environment.NewLine
    '            strsql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            strsql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
    '            strsql += "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine

    '            'strsql += "where tcustomer.BizType_ID = 2 and tdisposition.disp_date > '" & strStartDt & "' and tdisposition.disp_date < '" & strEndDt & "' group by disp_old;"
    '            strsql += "where tcustomer.BizType_ID = 2 and " & Environment.NewLine             'group by disp_old;"
    '            strsql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            strsql += "tdisposition.disp_NavDt is NULL " & Environment.NewLine

    '            strsql += "group by disp_old;"


    '            objData._SQL = strsql
    '            dt = objData.GetDataTable

    '            'Open the file
    '            FileOpen(1, strDispDecrementFilePath_RL, OpenMode.Append)
    '            FileOpen(2, strInsufficientBinQtyFilePath, OpenMode.Append)
    '            FileOpen(3, strBinAndItemNotInNavisionFilePath, OpenMode.Append)

    '            For Each R1 In dt.Rows
    '                'Build the string and write to the file
    '                strItemNo = Trim(R1("sku_number"))
    '                iQuantity = R1("Moved")
    '                '**********************
    '                iFlag = IsBinAndItemInNavision()

    '                strFileLine = ""
    '                strFileLine = Trim(strBinCode) & "," & Trim(strItemNo) & "," & iQuantity & "," & Trim(strEntryType) & "," & Trim(strPostingDt) & "," & iDept & "," & Trim(strPostingGrp)

    '                If iFlag = 0 Then           'good
    '                    PrintLine(1, strFileLine)
    '                ElseIf iFlag = 1 Then       'Exception: insufficient quantity in inventory
    '                    iEx = 1
    '                    'iInsufficientBinQty = 1
    '                    PrintLine(2, strFileLine)
    '                ElseIf iFlag = 2 Then       'Exception: Combination of Bin and Item doesn't exist
    '                    iEx = 1
    '                    'iBinAndItemNotInNavision = 1
    '                    PrintLine(3, strFileLine)
    '                End If

    '            Next R1

    '            Return 1
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.DecrementedSKUs_ReverseLogistics(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            Reset()
    '            R1 = Nothing
    '            DisposeDT(dt)
    '        End Try
    '    End Function

    '    '***********************************************************************
    '    'This creates file for decrimented SKUs/Items
    '    '***********************************************************************
    '    Public Function DecrementedSKUs_AssetRecovery() As Integer
    '        Dim dt As New DataTable()
    '        Dim R1 As DataRow
    '        Dim iFlag As Integer = 0
    '        Dim strsql As String = ""
    '        Dim strFileLine As String = ""

    '        strBinCode = "AR-PRODUCTION"
    '        strEntryType = "Negative"
    '        strPostingGrp = "ASSET"

    '        Try
    '            strsql = "Select disp_old, tsku.sku_number, Count(*) as Moved " & Environment.NewLine
    '            strsql += "from tdisposition " & Environment.NewLine
    '            strsql += "inner join tsku on tdisposition.disp_old = tsku.sku_id " & Environment.NewLine
    '            strsql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            strsql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
    '            strsql += "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
    '            'strsql += "where tcustomer.BizType_ID = 1 and tdisposition.disp_date > '" & strStartDt & "' and tdisposition.disp_date < '" & strEndDt & "' group by disp_old;"
    '            'strsql += "where tdevice.pallett_id <> 100771 and tcustomer.BizType_ID = 1 group by disp_old;"
    '            strsql += "where tcustomer.BizType_ID = 1 and " & Environment.NewLine             'group by disp_old;"
    '            strsql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            strsql += "tdisposition.disp_NavDt is NULL " & Environment.NewLine
    '            strsql += "group by disp_old;"


    '            objData._SQL = strsql
    '            dt = objData.GetDataTable

    '            'Open the file
    '            FileOpen(1, strDispDecrementFilePath_AR, OpenMode.Append)
    '            FileOpen(2, strInsufficientBinQtyFilePath, OpenMode.Append)
    '            FileOpen(3, strBinAndItemNotInNavisionFilePath, OpenMode.Append)

    '            For Each R1 In dt.Rows
    '                'Build the string and write to the file
    '                strItemNo = Trim(R1("sku_number"))
    '                iQuantity = R1("Moved")
    '                '**********************
    '                iFlag = IsBinAndItemInNavision()

    '                strFileLine = ""
    '                strFileLine = Trim(strBinCode) & "," & Trim(strItemNo) & "," & iQuantity & "," & Trim(strEntryType) & "," & Trim(strPostingDt) & "," & iDept & "," & Trim(strPostingGrp)

    '                If iFlag = 0 Then           'Good
    '                    PrintLine(1, strFileLine)
    '                ElseIf iFlag = 1 Then       'Exception: Part found in Navison but its qty is less than that we are trying to consume.
    '                    iEx = 1
    '                    'iInsufficientBinQty = 1
    '                    PrintLine(2, strFileLine)
    '                ElseIf iFlag = 2 Then       'Exception: (Combination of Bin and Item doesn't exist)
    '                    iEx = 1
    '                    'iBinAndItemNotInNavision = 1
    '                    PrintLine(3, strFileLine)
    '                End If

    '            Next R1

    '            Return 1
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.DecrementedSKUs_AssetRecovery(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            Reset()
    '            R1 = Nothing
    '            DisposeDT(dt)
    '        End Try
    '    End Function
    '    ''***********************************************************************
    '    'This creates file for Incremmented SKUs/Items
    '    '***********************************************************************
    '    Public Function IncremmentedSKUs_ReverseLogistics() As Integer
    '        Dim dt As New DataTable()
    '        Dim dtSKUDeviceInfo As New DataTable()
    '        Dim R1, R2, R3 As DataRow
    '        Dim iFlag As Integer = 0
    '        Dim iDispNew As Integer = 0
    '        Dim strSql As String = ""
    '        Dim strFileLine As String = ""

    '        strBinCode = "HOLD"
    '        strEntryType = "Positive"
    '        strPostingGrp = "RL"

    '        Try
    '            strSql = "Select disp_New, tsku.sku_number, Count(*) as Moved from tdisposition inner join tsku on tdisposition.disp_New = tsku.sku_id " & Environment.NewLine
    '            strSql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            strSql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
    '            strSql += "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
    '            'strSql += "where disp_date > '" & strStartDt & "' and disp_date < '" & strEndDt & "' and " & Environment.NewLine
    '            'strSql += "tcustomer.BizType_ID = 2 " & Environment.NewLine     ' 1 for Asset Recovery (lookup table "tbiztype")
    '            strSql += "where tcustomer.BizType_ID = 2 and " & Environment.NewLine             'group by disp_old;"
    '            strSql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            strSql += "tdisposition.disp_NavDt is NULL " & Environment.NewLine

    '            strSql += "group by disp_New;"

    '            objData._SQL = strSql
    '            dt = objData.GetDataTable

    '            'Open the file
    '            FileOpen(1, strDispIncrementFilePath_RL, OpenMode.Append)
    '            FileOpen(2, strItemNotInNavisionFilePath, OpenMode.Append)
    '            FileOpen(3, strBinNotInNavisionFilePath, OpenMode.Append)

    '            For Each R1 In dt.Rows

    '                iDispNew = R1("Disp_New")
    '                strItemNo = Trim(R1("sku_number"))
    '                iQuantity = R1("Moved")

    '                'Check if Item exists in Navision
    '                iFlag = IsItemInNavision()

    '                strFileLine = ""
    '                strFileLine = Trim(strBinCode) & "," & Trim(strItemNo) & "," & iQuantity & "," & Trim(strEntryType) & "," & Trim(strPostingDt) & "," & iDept & "," & Trim(strPostingGrp)

    '                If iFlag = 1 Then   'good
    '                    iFlag = 0
    '                    'Check if Bin exists in Navision
    '                    iFlag = IsBinInNavision()

    '                    If iFlag = 1 Then   'Bin exists
    '                        PrintLine(1, strFileLine)
    '                    Else                                'Bin doesn't exist
    '                        iEx = 1
    '                        'iBinNotInNavision = 1
    '                        PrintLine(3, strFileLine)
    '                    End If
    '                ElseIf iFlag = 0 Then                   'Item doesn't exist
    '                    iEx = 1
    '                    'iItemNotInNavision = 1
    '                    PrintLine(2, strFileLine)
    '                End If

    '            Next R1

    '            Return 1
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.IncremmentedSKUs(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            Reset()
    '            R2 = Nothing
    '            DisposeDT(dtSKUDeviceInfo)
    '            R1 = Nothing
    '            DisposeDT(dt)
    '        End Try
    '    End Function
    '    '***********************************************************************
    '    'This creates file for Incremmented SKUs/Items
    '    '***********************************************************************
    '    Public Function IncremmentedSKUs_AssetRecovery() As Integer
    '        Dim dt As New DataTable()
    '        'Dim dt4 As New DataTable()
    '        Dim dtSKUDeviceInfo As New DataTable()
    '        Dim R1, R2, R3 As DataRow
    '        'Dim R4 As DataRow
    '        Dim iFlag As Integer = 0
    '        Dim DecSumPartsCost As Decimal = 0
    '        Dim DecSumLaborCost As Decimal = 0
    '        Dim DecPSSIAvgCost As Decimal = 0
    '        Dim DecNavDispUnitCost As Decimal = 0
    '        Dim DecNewUnitCost As Decimal = 0

    '        Dim strSourceDisp As String = ""
    '        Dim iDispNew As Integer = 0
    '        Dim strSql As String = ""
    '        Dim strFileLine As String = ""

    '        strBinCode = "HOLD"
    '        strEntryType = "Positive"
    '        strPostingGrp = "ASSET"

    '        Try
    '            strSql = "Select disp_New, tsku.sku_number, Count(*) as Moved from tdisposition inner join tsku on tdisposition.disp_New = tsku.sku_id " & Environment.NewLine
    '            strSql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            strSql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
    '            strSql += "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
    '            'strSql += "where disp_date > '" & strStartDt & "' and disp_date < '" & strEndDt & "' and " & Environment.NewLine
    '            'strSql += "tcustomer.BizType_ID = 1 " & Environment.NewLine     ' 1 for Asset Recovery (lookup table "tbiztype")
    '            'strSql += "where tdevice.pallett_id <> 100771 and tcustomer.BizType_ID = 1 " & Environment.NewLine     ' 1 for Asset Recovery (lookup table "tbiztype")
    '            strSql += "where tcustomer.BizType_ID = 1 and " & Environment.NewLine             'group by disp_old;"
    '            strSql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            strSql += "tdisposition.disp_NavDt is NULL " & Environment.NewLine

    '            strSql += "group by disp_New;"

    '            objData._SQL = strSql           '"Select disp_New, tsku.sku_number, Count(*) as Moved from tdisposition inner join tsku on tdisposition.disp_New = tsku.sku_id where disp_date > '" & strStartDt & "' and disp_date < '" & strEndDt & "' group by disp_New;"
    '            dt = objData.GetDataTable

    '            'Open the file
    '            FileOpen(1, strDispIncrementFilePath_AR, OpenMode.Append)
    '            FileOpen(2, strItemNotInNavisionFilePath, OpenMode.Append)
    '            FileOpen(3, strBinNotInNavisionFilePath, OpenMode.Append)

    '            For Each R1 In dt.Rows

    '                iDispNew = R1("Disp_New")
    '                strItemNo = Trim(R1("sku_number"))
    '                iQuantity = R1("Moved")
    '                DecSumPartsCost = 0
    '                DecSumLaborCost = 0

    '                'Check if Item exists in Navision
    '                iFlag = IsItemInNavision()

    '                strFileLine = ""
    '                strFileLine = Trim(strBinCode) & "," & Trim(strItemNo) & "," & iQuantity & "," & Trim(strEntryType) & "," & Trim(strPostingDt) & "," & iDept & "," & Trim(strPostingGrp)

    '                If iFlag = 1 Then   'item exists.
    '                    iFlag = 0
    '                    'Check if Bin exists in Navision
    '                    iFlag = IsBinInNavision()

    '                    If iFlag = 1 Then   'Bin exists

    '                        'objData._SQL = "Select tdevice.device_sn, lpsprice.PSPrice_Number from tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id inner join tdisposition on tdevice.device_id = tdisposition.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id where lbillcodes.billtype_id = 2 and disp_new = " & R1("disp_New") & ";"
    '                        'objData._SQL = "Select lpsprice.PSPrice_Number from tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id inner join tdisposition on tdevice.device_id = tdisposition.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id where lbillcodes.billtype_id = 2 and disp_new = " & R1("disp_New") & ";"
    '                        'objData._SQL = "Select tdevice.device_sn, lpsprice.PSPrice_Number from tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id inner join tdisposition on tdevice.device_id = tdisposition.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id where lbillcodes.billtype_id = 2 and disp_new = " & R1("disp_New") & " and tdevice.pallett_id <> 100771;"
    '                        objData._SQL = "Select tdevice.device_sn, lpsprice.PSPrice_Number from tdevicebill inner join tdevice on tdevicebill.device_id = tdevice.device_id inner join tdisposition on tdevice.device_id = tdisposition.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id where lbillcodes.billtype_id = 2 and disp_new = " & R1("disp_New") & " and tdevice.device_finishedgoods = 9 and tdisposition.disp_NavDt is NULL;"

    '                        dtSKUDeviceInfo = objData.GetDataTable

    '                        For Each R2 In dtSKUDeviceInfo.Rows

    '                            'If R2("Device_sn") = "3592A94F" Then
    '                            '    MsgBox("stop")
    '                            'End If


    '                            For Each R3 In dtNavisionItem.Rows  'This run is to get the unit costs of the parts
    '                                If Trim(UCase(R2("PSPrice_Number"))) = Trim(UCase(R3("No_"))) Then
    '                                    DecSumPartsCost += R3("Unit Cost")
    '                                    Exit For
    '                                End If
    '                            Next R3
    '                        Next R2

    '                        R2 = Nothing
    '                        R3 = Nothing
    '                        DisposeDT(dtSKUDeviceInfo)

    '                        '*****************Get Total Labor Cost
    '                        'objData._SQL = "Select Sum(tdevice.device_laborcharge) as LaborCost from tdisposition inner join tdevice on tdisposition.device_id = tdevice.device_id where tdevice.device_finishedgoods = 9 and tdisposition.disp_NavDt is NULL and tdisposition.disp_new = " & iDispNew & ";"
    '                        'dt4 = objData.GetDataTable
    '                        'R4 = dt4.Rows(0)
    '                        'DecSumLaborCost = R4("LaborCost")
    '                        DecSumLaborCost = GetLaborCost(R1("disp_New"))
    '                        'R4 = Nothing
    '                        'DisposeDT(dt4)
    '                        '*****************Calculate Avg. Cost for Parts+Labor
    '                        If iQuantity = 0 Then
    '                            Throw New Exception("clsBiz.IncremmentedSKUs(): iQuntity is zero and can not divide anything with a zero.")
    '                        End If
    '                        DecPSSIAvgCost = (DecSumPartsCost + DecSumLaborCost) / iQuantity

    '                        '*****************Find the Source Disposition
    '                        strSourceDisp = Me.GetOldDisposition(iDispNew)

    '                        '*****************Find out the Unit cost from Navision
    '                        For Each R2 In dtNavisionItem.Rows  'This run is to get the unit cost of the Disposition
    '                            If Trim(UCase(R2("No_"))) = Trim(UCase(strSourceDisp)) Then
    '                                DecNavDispUnitCost = R2("Unit Cost")
    '                                Exit For
    '                            End If
    '                        Next R2

    '                        R2 = Nothing
    '                        '******************Calculate Latest UNIT COST to update NAVISION
    '                        DecNewUnitCost = DecNavDispUnitCost + DecPSSIAvgCost
    '                        '******************Write to file**************************
    '                        strFileLine &= "," & DecNewUnitCost
    '                        PrintLine(1, strFileLine)
    '                        '",", Math.Round(DecNewUnitCost, 2))

    '                    Else                                'Bin doesn't exist
    '                        iEx = 1
    '                        'iBinNotInNavision = 1
    '                        PrintLine(3, strFileLine)
    '                    End If

    '                ElseIf iFlag = 0 Then                   'Item doesn't exist
    '                    iEx = 1
    '                    'iItemNotInNavision = 1
    '                    PrintLine(2, strFileLine)
    '                End If

    '            Next R1

    '            Return 1
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.IncremmentedSKUs(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            Reset()
    '            R2 = Nothing
    '            DisposeDT(dtSKUDeviceInfo)
    '            R1 = Nothing
    '            DisposeDT(dt)
    '            'R4 = Nothing
    '            'DisposeDT(dt4)
    '        End Try
    '    End Function
    '    '***********************************************************************
    '    'Asset Recovery Parts Consumption
    '    '***********************************************************************
    '    Public Function PartsConsumption() As Integer

    '        Dim dt As New DataTable()
    '        Dim R1 As DataRow
    '        Dim strsql As String = ""
    '        Dim iFlag As Integer = 0
    '        Dim strFileLine As String = ""

    '        strBinCode = ""
    '        strEntryType = "Negative"
    '        strPostingGrp = "ASSETPARTS"

    '        Try

    '            '*******************************************************
    '            'Get Consumed parts
    '            strsql = "select lwclocation.wc_location, lpsprice.psprice_number, count(tparttransaction.trans_Amount) as NumberOfParts " & Environment.NewLine
    '            strsql += "from tdisposition " & Environment.NewLine
    '            strsql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            strsql += "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
    '            strsql += "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
    '            strsql += "inner join tparttransaction on tdevicebill.dbill_ID = tparttransaction.DBill_ID " & Environment.NewLine
    '            strsql += "inner join lwclocation on tparttransaction.BinLoc = lwclocation.wclocation_id " & Environment.NewLine
    '            strsql += "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & Environment.NewLine
    '            strsql += "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine

    '            strsql += "where " & Environment.NewLine
    '            strsql += "lbillcodes.billtype_id = 2 and " & Environment.NewLine
    '            strsql += "lpsprice.PSPrice_inventoryPart = 1 and " & Environment.NewLine
    '            strsql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            strsql += "tdisposition.disp_NavDt is NULL " & Environment.NewLine

    '            strsql += "group by lwclocation.wc_location, lpsprice.psprice_number " & Environment.NewLine
    '            strsql += "order by lwclocation.wc_location, lpsprice.psprice_number;"

    '            objData._SQL = strsql
    '            dt = objData.GetDataTable

    '            'Open the file
    '            FileOpen(1, strPartsDecrementFilePath, OpenMode.Append)
    '            FileOpen(2, strInsufficientBinQtyFilePath, OpenMode.Append)
    '            FileOpen(3, strBinAndItemNotInNavisionFilePath, OpenMode.Append)

    '            For Each R1 In dt.Rows
    '                strBinCode = Trim(R1("wc_location"))
    '                strItemNo = Trim(R1("psprice_number"))
    '                iQuantity = R1("NumberOfParts")

    '                iFlag = IsBinAndItemInNavision()

    '                strFileLine = ""
    '                strFileLine = Trim(strBinCode) & "," & Trim(strItemNo) & "," & iQuantity & "," & Trim(strEntryType) & "," & Trim(strPostingDt) & "," & iDept & "," & Trim(strPostingGrp)

    '                If iFlag = 0 Then           'Good
    '                    PrintLine(1, strFileLine)
    '                ElseIf iFlag = 1 Then       'Part found in Navison but its qty is less than that we are trying to consume.
    '                    iEx = 1
    '                    'iInsufficientBinQty = 1
    '                    PrintLine(2, strFileLine)
    '                ElseIf iFlag = 2 Then       'Part not found in Navision (Combination of Bin and Item doesn't exist)
    '                    iEx = 1
    '                    'iBinAndItemNotInNavision = 1
    '                    PrintLine(3, strFileLine)
    '                End If

    '            Next R1

    '            'Reset()

    '            '*******************************************************
    '            'Get reclaimed parts
    '            'strEntryType = "Positive"
    '            'strBinCode = ""
    '            'strItemNo = ""
    '            'iQuantity = 0
    '            'iFlag = 0
    '            'strFileLine = ""

    '            'strsql = "select lwclocation.wc_location, lpsprice.psprice_number, tparttransaction.billcode_id, sum(tparttransaction.trans_Amount) as NumberOfParts " & Environment.NewLine
    '            'strsql += "from tdisposition " & Environment.NewLine
    '            'strsql += "inner join tdevice on tdisposition.device_id = tdevice.device_id " & Environment.NewLine
    '            'strsql += "inner join tparttransaction on tdevice.device_id = tparttransaction.device_id " & Environment.NewLine
    '            'strsql += "inner join lwclocation on tparttransaction.BinLoc = lwclocation.wclocation_id " & Environment.NewLine
    '            'strsql += "inner join tpsmap on tparttransaction.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & Environment.NewLine
    '            'strsql += "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
    '            'strsql += "inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & Environment.NewLine

    '            'strsql += "where " & Environment.NewLine
    '            'strsql += "lbillcodes.billtype_id = 2 and " & Environment.NewLine
    '            'strsql += "lpsprice.PSPrice_inventoryPart = 1 and " & Environment.NewLine
    '            'strsql += "tparttransaction.trans_amount = -1 and " & Environment.NewLine

    '            ''''Uncomment next two lines
    '            ''strsql += "tdisposition.disp_date > '" & strStartDt & "' and tdisposition.disp_date < '" & strEndDt & "' and " & Environment.NewLine
    '            ''Comment this line
    '            ''strsql += "tdevice.pallett_id <> 100771 " & Environment.NewLine
    '            'strsql += "tdevice.device_finishedgoods = 9 and " & Environment.NewLine
    '            'strsql += "tdisposition.disp_NavDt is NULL " & Environment.NewLine

    '            'strsql += "group by lwclocation.wc_location, lpsprice.psprice_number order by lwclocation.wc_location, lpsprice.psprice_number;"


    '            'objData._SQL = strsql
    '            'dt = objData.GetDataTable

    '            ''Open the file
    '            'FileOpen(1, strPartsIncrementFilePath, OpenMode.Append)
    '            'FileOpen(2, strItemNotInNavisionFilePath, OpenMode.Append)
    '            'FileOpen(3, strBinNotInNavisionFilePath, OpenMode.Append)

    '            'For Each R1 In dt.Rows
    '            '    strBinCode = Trim(R1("wc_location"))
    '            '    strItemNo = Trim(R1("psprice_number"))
    '            '    iQuantity = (-1) * (R1("NumberOfParts"))        'Convert it to a positive number.

    '            '    iFlag = IsItemInNavision()

    '            '    strFileLine = ""
    '            '    strFileLine = Trim(strBinCode) & "," & Trim(strItemNo) & "," & iQuantity & "," & Trim(strEntryType) & "," & Trim(strPostingDt) & "," & iDept & "," & Trim(strPostingGrp)

    '            '    If iFlag = 1 Then   'item exists.
    '            '        iFlag = 0
    '            '        'Check if Bin exists in Navision
    '            '        iFlag = IsBinInNavision()
    '            '        If iFlag = 1 Then   'Bin exists
    '            '            PrintLine(1, strFileLine)
    '            '        Else        'Bin doesn't exist
    '            '            iBinNotInNavision = 1
    '            '            PrintLine(3, strFileLine)
    '            '        End If
    '            '    ElseIf iFlag = 0 Then                   'Item doesn't exist
    '            '        iItemNotInNavision = 1
    '            '        PrintLine(2, strFileLine)
    '            '    End If
    '            'Next R1

    '            '*******************************************************
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.PartsConsumption(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            Reset()
    '            R1 = Nothing
    '            DisposeDT(dt)
    '        End Try
    '    End Function
    '    '***************************************************
    '    'Check if the Item Exsits in NAVISION
    '    '***************************************************
    '    Private Function IsBinAndItemInNavision() As Integer
    '        Dim R1 As DataRow = Nothing
    '        Dim iFlag As Integer = 0

    '        For Each R1 In dtNavisionBinContent.Rows
    '            If (Trim(UCase(strBinCode)) = Trim(UCase(R1("Bin Code")))) And Trim(UCase(strItemNo)) = Trim(UCase(R1("Item No_"))) Then
    '                If R1("Quantity") < iQuantity Then      'Navision Bin Qty is less tha the qty we are trying to consume
    '                    iFlag = 1
    '                Else                    'Everything is fine. There is enough stock in the bin to consume.
    '                    iFlag = 0
    '                End If
    '                Exit For
    '            Else                        'Combo of Bin and Item doesn't exist in Navision
    '                iFlag = 2
    '            End If
    '        Next R1

    '        Return iFlag
    '    End Function

    '    '***************************************************
    '    'Check if the Item Exsits in NAVISION
    '    '***************************************************
    '    Private Function IsItemInNavision() As Integer
    '        Dim R1 As DataRow = Nothing
    '        Dim iFlg As Integer = 0

    '        For Each R1 In dtNavisionItem.Rows
    '            If Trim(UCase(strItemNo)) = Trim(UCase(R1("No_"))) Then
    '                iFlg = 1
    '                Exit For
    '            End If
    '        Next R1

    '        Return iFlg
    '    End Function

    '    '***************************************************
    '    'Check if the Item Exsits in NAVISION
    '    '***************************************************
    '    Private Function IsBinInNavision() As Integer
    '        Dim R1 As DataRow = Nothing
    '        Dim iFlg As Integer = 0

    '        For Each R1 In dtNavisionBinContent.Rows
    '            If Trim(UCase(strBinCode)) = Trim(UCase(R1("Bin Code"))) Then
    '                iFlg = 1
    '                Exit For
    '            End If
    '        Next R1

    '        Return iFlg
    '    End Function
    '    '***************************************************
    '    'Check if the unit cost in NAVISION is greater than zero
    '    '***************************************************
    '    Private Function GetOldDisposition(ByVal iDispNew As Integer) As String

    '        Dim dt As DataTable = Nothing
    '        Dim strSql As String = ""
    '        Dim R1 As DataRow
    '        Dim strOldDisp As String = ""

    '        Try

    '            strSql = "Select distinct tsku.sku_number from tdisposition inner join tsku on tdisposition.disp_old = tsku.sku_id " & Environment.NewLine
    '            'strSql += "where tdisposition.disp_date > '" & strStartDt & "' and tdisposition.disp_date < '" & strEndDt & "' and disp_new = " & iDispNew & ";" & Environment.NewLine
    '            strSql += "where disp_new = " & iDispNew & ";" & Environment.NewLine

    '            objData._SQL = strSql
    '            dt = objData.GetDataTable
    '            For Each R1 In dt.Rows
    '                strOldDisp = Trim(R1("sku_number"))
    '                Exit For
    '            Next R1

    '            Return strOldDisp
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.GetSourceDisposition(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            R1 = Nothing
    '            DisposeDT(dt)
    '        End Try

    '    End Function
    '    '***************************************************
    '    Private Function GetLaborCost(ByVal iDispNew As Integer) As Decimal
    '        Dim dt As DataTable = Nothing
    '        Dim R1 As DataRow

    '        Try
    '            objData._SQL = "Select Sum(tdevice.device_laborcharge) as LaborCost from tdisposition inner join tdevice on tdisposition.device_id = tdevice.device_id where tdevice.device_finishedgoods = 9 and tdisposition.disp_NavDt is NULL and tdisposition.disp_new = " & iDispNew & ";"

    '            dt = objData.GetDataTable
    '            R1 = dt.Rows(0)
    '            Return CDec(R1("LaborCost"))

    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.GetLaborCost(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally
    '            R1 = Nothing
    '            DisposeDT(dt)
    '        End Try
    '    End Function
    '    '***************************************************
    '    'Get Unit Costs from NAVISON for Asset Recovery Dept.
    '    '***************************************************
    '    Private Sub GetNavisionTables()

    '        Dim _Conn As OdbcConnection
    '        Dim strSql As String
    '        Dim MyCmd As OdbcCommand
    '        Dim MyDA As OdbcDataAdapter

    '        Try
    '            '_Conn = New OdbcConnection("DSN=Navision Test Database")
    '            _Conn = New OdbcConnection("DSN=Navision Database")
    '            _Conn.Open()
    '            MyDA = New OdbcDataAdapter()
    '            '**************************************
    '            'Get the Item table Info from Navision
    '            '**************************************
    '            strSql = "Select * from Item"
    '            MyCmd = New OdbcCommand(strSql, _Conn)
    '            MyDA.SelectCommand = MyCmd
    '            MyDA.Fill(dtNavisionItem)

    '            MyCmd.Dispose()
    '            MyCmd = Nothing
    '            '**************************************
    '            'Get the Bin Content table info from Navision
    '            '**************************************
    '            strSql = "Select * from ""Bin Content"""
    '            MyCmd = New OdbcCommand(strSql, _Conn)
    '            MyDA.SelectCommand = MyCmd
    '            MyDA.Fill(dtNavisionBinContent)
    '            '**************************************
    '        Catch ex As Exception
    '            Throw New Exception("clsBiz.GetNavisionTables(): " & Environment.NewLine & ex.Message.ToString)
    '        Finally

    '            If Not IsNothing(_Conn) Then
    '                If _Conn.State = ConnectionState.Open Then
    '                    _Conn.Close()
    '                End If
    '                _Conn.Dispose()
    '                _Conn = Nothing
    '            End If
    '            If Not IsNothing(MyCmd) Then
    '                MyCmd.Dispose()
    '                MyCmd = Nothing
    '            End If
    '            If Not IsNothing(MyDA) Then
    '                MyDA.Dispose()
    '                MyDA = Nothing
    '            End If
    '        End Try
    '    End Sub

    '    '***************************************************
    '    Public Function DisposeDT(ByRef dt As DataTable)
    '        If Not IsNothing(dt) Then
    '            dt.Dispose()
    '            dt = Nothing
    '        End If
    '    End Function
    '    '***************************************************
    '    Public Sub New()

    '        objLib = New MyLib.Utility()
    '        objData = New Production.Misc()
    '        dtNavisionItem = New DataTable()
    '        dtNavisionBinContent = New DataTable()
    '        strFileDir = objLib.Create_Directory(strFileDir)
    '        GetNavisionTables()
    '    End Sub
    '    '***************************************************
    '    Protected Overrides Sub Finalize()
    '        DisposeDT(dtNavisionItem)
    '        DisposeDT(dtNavisionBinContent)
    '        objLib = Nothing
    '        objData = Nothing
    '        MyBase.Finalize()
    '    End Sub
    '    '***************************************************
    'End Class
End Namespace

