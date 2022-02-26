
Option Explicit On 

Imports system.IO
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class HTC

        Public Enum TEST_TYPE_ID
            RF = 2
            FINAL = 3
            OOBA = 4
            DIAGNOSTIC = 5
            PIA = 6
            REPAIR = 7
            RECLAIM_PARTS = 8
            BILLING_AUDITOR = 9
        End Enum

        Private _objDataProc As DBQuery.DataProc
        Private _dtRURInfo As DataTable = Nothing

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Me._dtRURInfo = Me.GetHTC_RURType()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Public Function GetHTC_RURType() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Dcode_id, Dcode_L2desc " & Environment.NewLine
                strSql &= ", lfailcodes.Fail_ID, lrepaircodes.Repair_ID, thtcmcfcrcpnmap.MC_ID "
                strSql &= ", lhtcpartsno.PSPrice_ID, lhtcpartsno.Part_Number " & Environment.NewLine
                strSql &= "FROM lcodesdetail " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes ON lcodesdetail.Dcode_Sdesc = lfailcodes.Fail_SDesc " & Environment.NewLine
                strSql &= "INNER JOIN lrepaircodes ON lcodesdetail.Dcode_Ldesc =lrepaircodes.Repair_SDesc " & Environment.NewLine
                strSql &= "INNER JOIN thtcmcfcrcpnmap ON lfailcodes.Fail_ID = thtcmcfcrcpnmap.Fail_ID " & Environment.NewLine
                strSql &= "INNER JOIN lhtcpartsno ON thtcmcfcrcpnmap.Part_ID = lhtcpartsno.Part_ID " & Environment.NewLine
                strSql &= "AND lrepaircodes.Repair_ID = thtcmcfcrcpnmap.Repair_ID  " & Environment.NewLine
                strSql &= "WHERE mcode_id = 35  " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsRMAModelMatchSelectedModel(ByVal strRMA As String, ByVal strModelDes As String) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim R1 As DataRow

            Try
                strSql = "SELECT if(thtcdata.hd_CustModel like '%att 8925%', 'YES', 'NO') as 'Model Match' " & Environment.NewLine
                strSql &= "FROM thtcdata " & Environment.NewLine
                strSql &= "WHERE hd_RMA = '" & strRMA & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    If R1("Model Match").ToString.Trim.ToUpper = "NO" Then
                        booResult = False
                        Exit For
                    Else
                        booResult = True
                    End If
                Next R1

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************


#Region "Properties"
        '******************************************************************
        Public Shared ReadOnly Property HTC_CUSTOMER_ID() As Integer
            Get
                Return 2251
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_LOCATION_ID() As Integer
            Get
                Return 2775
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_RUR_BILLCODEID() As Integer
            Get
                Return 256
            End Get
        End Property

        '******************************************************************
        Public ReadOnly Property HTC_RUR_TYPE_INFO() As DataTable
            Get
                Return Me._dtRURInfo
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_COSMETIC_FAILID() As Integer
            Get
                Return 156
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_COSMETIC_REPAIRID() As Integer
            Get
                Return 65
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_COSMETIC_MAINCATEGORYID() As Integer
            Get
                Return 6
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_PackingListFileLocation() As String
            Get
                Return "P:\Dept\HTC\Pallet packing list\"
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property HTC_ATT_GroupID() As Integer
            Get
                Return 79
            End Get
        End Property

        '******************************************************************


#End Region

#Region "Administration"

        '******************************************************************
        Public Function LoadHTCDetailFile(ByVal strFileLoc As String) As Integer
            Const strLogFilePath As String = "P:\Dept\HTC\ASN\Log\LoadASN.txt"
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objReader As StreamReader
            Dim strLine As String = ""
            Dim strArr As String()
            Dim iCnt As Integer = 0
            Dim strLogData As String = ""
            Dim strIMEI As String = ""
            Dim strRMA As String = ""
            Dim strSku As String = ""

            Try
                '****************
                'Open log file
                '****************
                FileOpen(1, strLogFilePath, OpenMode.Append)   'Open TXT file

                objReader = New StreamReader(strFileLoc)

                'Loop through File
                While objReader.Peek <> -1

                    iCnt += 1

                    '**********************************
                    'Read a line from Data file
                    '**********************************
                    strLine = Trim(objReader.ReadLine())

                    If strLine.Trim.Length > 0 Then
                        strArr = strLine.Split("|")
                        If strArr.Length > 0 Then
                            '***********************
                            'Get record information
                            '***********************
                            strRMA = strArr(0).Trim.ToUpper
                            strSku = strArr(2).Trim.ToUpper
                            strIMEI = strArr(3).Trim.ToUpper

                            '**********************************
                            'validate IMEI and Document ID
                            '**********************************
                            If strIMEI = "" Then
                                strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank IMEI" & vbCrLf
                            ElseIf strRMA = "" Then
                                strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank RMA" & vbCrLf
                            ElseIf strSku = "" Then
                                strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank Sku" & vbCrLf
                            Else
                                '*******************************
                                'Check for duplicate
                                '*******************************
                                dt1 = Me.GetIMEI_InRMA(strIMEI, strRMA)
                                If dt1.Rows.Count > 0 Then
                                    '*******************************
                                    'insert into htcdata
                                    '*******************************
                                    strSql = "UPDATE thtcdata SET " & Environment.NewLine
                                    strSql &= " hd_CustModel = '" & strArr(1).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_Sku = '" & strArr(2).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_FileDate = '" & strArr(4).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_FileWty = '" & strArr(5).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_Symptom = '" & strArr(6).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_Category = '" & strArr(7).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_Remark = '" & strArr(8).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_CategoryCode = '" & strArr(9).Trim.ToUpper & "' " & Environment.NewLine
                                    strSql &= ", hd_DateLoad = now() " & Environment.NewLine
                                    strSql &= "WHERE hd_ID = " & dt1.Rows(0)("hd_ID")

                                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                                End If
                            End If   'Validate Blank IMEI,Blank Document ID(Repair Order) and Blank UPCPart#
                        End If  'Check for empty array

                        'reset loop variable
                        strArr = Nothing
                        strRMA = ""
                        strIMEI = ""
                        strSku = ""
                        PSS.Data.Buisness.Generic.DisposeDT(dt1)
                    End If  'check for blank line
                End While

                '**************************
                'Write to log file
                '**************************
                strLogData &= Now() & " FileName:" & strFileLoc & " " & i & " record(s) have been loaded " & vbCrLf
                PrintLine(1, strLogData)
                '**************************

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Reset()
                objReader.Close()
                If Not IsNothing(objReader) Then
                    objReader = Nothing
                End If
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function LoadHTCASNFile(ByVal strFileLoc As String) As Integer
            Const strLogFilePath As String = "P:\Dept\HTC\ASN\Log\LoadASN.txt"
            Dim objRec As Production.Receiving
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objReader As StreamReader
            Dim strLine As String = ""
            Dim strArr As String()
            Dim iCnt As Integer = 0
            Dim strLogData As String = ""
            Dim strIMEI As String = ""
            Dim strRMA As String = ""
            Dim strSku As String = ""
            Dim iDisCrepUnit As Integer = 0
            Dim iDuplicate As Integer = 0

            Try
                objRec = New Production.Receiving()

                '****************
                'Open log file
                '****************
                FileOpen(1, strLogFilePath, OpenMode.Append)   'Open TXT file

                objReader = New StreamReader(strFileLoc)

                'Loop through File
                While objReader.Peek <> -1

                    iCnt += 1

                    '**********************************
                    'Read a line from Data file
                    '**********************************
                    strLine = Trim(objReader.ReadLine())

                    If strLine.Trim.Length > 0 Then
                        strArr = strLine.Split("|")
                        If strArr.Length > 0 Then
                            '***********************
                            'Get record information
                            '***********************
                            strRMA = strArr(0).Trim.ToUpper
                            strSku = strArr(2).Trim.ToUpper
                            strIMEI = strArr(3).Trim.ToUpper

                            '**********************************
                            'validate IMEI and Document ID
                            '**********************************
                            If strIMEI = "" Then
                                strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank IMEI" & vbCrLf
                            ElseIf strRMA = "" Then
                                strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank RMA" & vbCrLf
                            ElseIf strSku = "" Then
                                strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank Sku" & vbCrLf
                            Else
                                '*******************************
                                'Check for duplicate
                                '*******************************
                                dt1 = Me.GetIMEI_InRMA(strIMEI, strRMA)
                                If dt1.Rows.Count > 0 Then
                                    iDisCrepUnit = 1
                                    iDuplicate = 1
                                    '*********************************
                                    'write existed IMEI into log file
                                    '*********************************
                                    strLogData &= Now() & " FileName:" & strFileLoc & " Line#" & iCnt & " Existed IMEI:" & strIMEI & vbCrLf
                                End If

                                '*******************************
                                'insert into htcdata
                                '*******************************
                                strSql = "INSERT INTO thtcdata ( " & Environment.NewLine
                                strSql &= "hd_RMA " & Environment.NewLine
                                strSql &= ", hd_CustModel " & Environment.NewLine
                                strSql &= ", hd_Sku " & Environment.NewLine
                                strSql &= ", hd_IMEI " & Environment.NewLine
                                strSql &= ", hd_FileDate " & Environment.NewLine
                                strSql &= ", hd_FileWty " & Environment.NewLine
                                strSql &= ", hd_Symptom " & Environment.NewLine
                                strSql &= ", hd_Category " & Environment.NewLine
                                strSql &= ", hd_Remark " & Environment.NewLine
                                strSql &= ", hd_CategoryCode " & Environment.NewLine
                                strSql &= ", hd_DateLoad " & Environment.NewLine
                                strSql &= ", DiscUnit " & Environment.NewLine
                                strSql &= ", Duplicate " & Environment.NewLine
                                strSql &= ", Label_IMEI " & Environment.NewLine
                                strSql &= ") VALUES ( " & Environment.NewLine
                                strSql &= "'" & strArr(0).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(1).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(2).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(3).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(4).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(5).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(6).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(7).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(8).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", '" & strArr(9).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= ", now() " & Environment.NewLine
                                strSql &= ", " & iDisCrepUnit & Environment.NewLine
                                strSql &= ", " & iDuplicate & Environment.NewLine
                                strSql &= ", '" & strArr(3).Trim.ToUpper & "' " & Environment.NewLine
                                strSql &= "); " & Environment.NewLine

                                i += Me._objDataProc.ExecuteNonQuery(strSql)
                            End If   'Validate Blank IMEI,Blank Document ID(Repair Order) and Blank UPCPart#
                        End If  'Check for empty array

                        'reset loop variable
                        strArr = Nothing
                        strRMA = ""
                        strIMEI = ""
                        strSku = ""
                        iDisCrepUnit = 0
                        iDuplicate = 0
                        PSS.Data.Buisness.Generic.DisposeDT(dt1)
                    End If  'check for blank line
                End While

                '**************************
                'Write to log file
                '**************************
                strLogData &= Now() & " FileName:" & strFileLoc & " " & i & " record(s) have been loaded " & vbCrLf
                PrintLine(1, strLogData)
                '**************************

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                Reset()
                objReader.Close()
                If Not IsNothing(objReader) Then
                    objReader = Nothing
                End If
                objRec = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function GetIMEI_InRMA(ByVal strIMEI As String, _
                                    ByVal strRMA As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * FROM thtcdata " & Environment.NewLine
                strSql &= "WHERE hd_IMEI = '" & strIMEI & "'" & Environment.NewLine
                strSql &= "AND hd_RMA = '" & strRMA & "'" & Environment.NewLine
                strSql &= "ORDER BY hd_ID asc"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFailCodeMainCategoriesID(ByVal strMainCategoryDesc As String, _
                                                    ByVal iActive As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * from lfailcodesmaincategories " & Environment.NewLine
                strSql &= "WHERE MC_Desc = '" & strMainCategoryDesc & "'" & Environment.NewLine
                If iActive > 0 Then
                    strSql &= "AND MC_Inactive = 0;"
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate fail code category """ & strMainCategoryDesc & """, please contact IT immediately.")
                ElseIf dt.Rows.Count = 1 Then
                    Return dt.Rows(0)("MC_ID")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetFailID(ByVal strFailCodeShortDesc As String, _
                                  ByVal iModel_ID As Integer, _
                                  ByVal iActive As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Fail_ID FROM lfailcodes  " & Environment.NewLine
                strSql &= "WHERE Fail_SDesc = '" & strFailCodeShortDesc & "'  " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & Environment.NewLine
                If iActive > 0 Then
                    strSql &= "AND Fail_Inactive = 0;"
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate fail code """ & strFailCodeShortDesc & """, please contact IT immediately.")
                ElseIf dt.Rows.Count = 1 Then
                    Return dt.Rows(0)("Fail_ID")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetRepairID(ByVal strRepairCodeShortDesc As String, _
                                    ByVal iModel_ID As Integer, _
                                    ByVal iActive As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Repair_ID FROM lrepaircodes  " & Environment.NewLine
                strSql &= "WHERE Repair_SDesc = '" & strRepairCodeShortDesc & "' " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & Environment.NewLine
                If iActive > 0 Then
                    strSql &= "AND Repair_Inactive = 0;" & Environment.NewLine
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate repair code """ & strRepairCodeShortDesc & """, please contact IT immediately.")
                ElseIf dt.Rows.Count = 1 Then
                    Return dt.Rows(0)("Repair_ID")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetHTCPartID(ByVal strPartNumber As String, _
                                     ByVal iModel_ID As Integer, _
                                     ByVal iActive As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Part_ID FROM lhtcpartsno " & Environment.NewLine
                strSql &= "WHERE Part_Number  = '" & strPartNumber & "' " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & Environment.NewLine
                If iActive > 0 Then
                    strSql &= "AND Part_Inactive = 0;"
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate part number """ & strPartNumber & """, please contact IT immediately.")
                ElseIf dt.Rows.Count = 1 Then
                    Return dt.Rows(0)("Part_ID")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetMainCategory_FailCode_RepairCode_PartNum_Matrix(ByVal iMC_ID As Integer, _
                                                        ByVal iFail_ID As Integer, _
                                                        ByVal iRep_ID As Integer, _
                                                        ByVal iPart_ID As Integer, _
                                                        ByVal iActive As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM thtcmcfcrcpnmap  " & Environment.NewLine
                strSql &= "WHERE MC_ID = " & iMC_ID & Environment.NewLine
                strSql &= "AND Fail_ID = " & iFail_ID & Environment.NewLine
                strSql &= "AND Repair_ID = " & iRep_ID & Environment.NewLine
                strSql &= "AND Part_ID = " & iPart_ID & Environment.NewLine
                If iActive > 0 Then
                    strSql &= " AND FCRCmap_Inactive = 0 " & Environment.NewLine
                End If
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetBillCodeIDByRepairCode(ByVal iRepair_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lbillcodes " & Environment.NewLine
                strSql &= "WHERE iRepair_ID  = " & iRepair_ID & Environment.NewLine
                Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetBillCodeIDByPartNumber(ByVal strPartNumber As String, _
                                                  ByVal iModelID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT BillCode_ID FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID" & Environment.NewLine
                strSql &= "WHERE MODEL_ID = " & iModelID & Environment.NewLine
                strSql &= "AND lpsprice.PSPrice_Number = '" & strPartNumber & "'"
                Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertNewMainCategoryFailCode(ByVal strMainCategory As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO lfailcodesmaincategories (MC_Desc " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= " '" & strMainCategory & "'" & Environment.NewLine
                strSql &= ");"
                Return Me._objDataProc.idTransaction(strSql, "lfailcodes")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateMainCategoryFailCode(ByVal strMainCategory As String, _
                                                   ByVal iMainCategoryID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE lfailcodesmaincategories SET MC_Desc = '" & strMainCategory & "'" & Environment.NewLine
                strSql &= "WHERE MC_ID = " & iMainCategoryID & ";"
                Return Me._objDataProc.idTransaction(strSql, "lfailcodes")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertNewFailCode(ByVal strFailCode As String, _
                                          ByVal strFailDesc As String, _
                                          ByVal iModel_ID As Integer, _
                                          ByVal iManufID As Integer, _
                                          ByVal iProdID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO lfailcodes (Fail_SDesc, Fail_LDesc, Model_ID, Manuf_ID, Prod_Id " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= " '" & strFailCode & "'" & Environment.NewLine
                strSql &= ", '" & strFailDesc & "'" & Environment.NewLine
                strSql &= ", " & iModel_ID & " " & Environment.NewLine
                strSql &= ", " & iManufID & " " & Environment.NewLine
                strSql &= ", " & iProdID & " " & Environment.NewLine
                strSql &= ");"
                Return Me._objDataProc.idTransaction(strSql, "lfailcodes")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateFailCodeDescription(ByVal strFailCode As String, _
                                                  ByVal strFailDesc As String, _
                                                  ByVal iModel_ID As Integer, _
                                                  Optional ByVal iFailID As Integer = 0) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE lfailcodes SET Fail_LDesc = '" & strFailDesc & "'" & Environment.NewLine
                strSql &= ", Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "WHERE Fail_SDesc = '" & strFailCode & "'" & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & " " & Environment.NewLine
                If iFailID > 0 Then
                    strSql &= "AND Fail_ID = " & iFailID & " " & Environment.NewLine
                End If
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function InsertNewRepairCode(ByVal strRepairCode As String, _
                                            ByVal strRepairDesc As String, _
                                            ByVal iRepairLevel As Integer, _
                                            ByVal strRepairType As String, _
                                            ByVal iModel_ID As Integer, _
                                            ByVal iManufID As Integer, _
                                            ByVal iProdID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO lrepaircodes (Repair_SDesc, Repair_LDesc,Repair_Level, Repair_Type, Model_ID, Manuf_ID, Prod_Id " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= " '" & strRepairCode & "'" & Environment.NewLine
                strSql &= ", '" & strRepairDesc & "'" & Environment.NewLine
                strSql &= ", " & iRepairLevel & " " & Environment.NewLine
                strSql &= ", '" & strRepairType & "'" & Environment.NewLine
                strSql &= ", " & iModel_ID & " " & Environment.NewLine
                strSql &= ", " & iManufID & " " & Environment.NewLine
                strSql &= ", " & iProdID & " " & Environment.NewLine
                strSql &= ");"
                Return Me._objDataProc.idTransaction(strSql, "lfailcodes")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateRepairCode(ByVal strRepairCode As String, _
                                         ByVal iRepairLevel As Integer, _
                                         ByVal strRepairType As String, _
                                         ByVal iModel_ID As Integer, _
                                         Optional ByVal iRepairID As Integer = 0) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE lrepaircodes " & Environment.NewLine
                strSql &= "SET Repair_LDesc = '" & strRepairCode & "'" & Environment.NewLine
                strSql &= ", Repair_Level = " & iRepairLevel & "" & Environment.NewLine
                strSql &= ", Repair_Type = '" & strRepairType & "', Repair_Inactive = 0 " & Environment.NewLine
                strSql &= "WHERE Repair_SDesc = '" & strRepairCode & "'" & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & " " & Environment.NewLine
                If iRepairID > 0 Then
                    strSql &= "AND Repair_ID = " & iRepairID & Environment.NewLine
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertNewHTCPartNumber(ByVal strPartNumber As String, _
                                            ByVal strPartDescDesc As String, _
                                            ByVal iModel_ID As Integer, _
                                            ByVal iPSPriceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO lhtcpartsno (Part_Number, Part_Desc, Model_ID, PSPrice_ID " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= " '" & strPartNumber & "'" & Environment.NewLine
                strSql &= ", '" & strPartDescDesc & "'" & Environment.NewLine
                strSql &= ", " & iModel_ID & " " & Environment.NewLine
                strSql &= ", " & iPSPriceID & " " & Environment.NewLine
                strSql &= ");"
                Return Me._objDataProc.idTransaction(strSql, "lfailcodes")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateHTCPartDescPSPriceID(ByVal strPartNumber As String, _
                                               ByVal strPartDesc As String, _
                                               ByVal iPsPriceID As Integer, _
                                               ByVal iModel_ID As Integer, _
                                               Optional ByVal iPartID As Integer = 0) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE lhtcpartsno " & Environment.NewLine
                strSql &= "SET Part_Desc = '" & strPartDesc & "'" & Environment.NewLine
                strSql &= ", PSPrice_ID = " & iPsPriceID & ", Part_Inactive = 0 " & Environment.NewLine
                strSql &= "WHERE Part_Number = '" & strPartNumber & "'" & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & " " & Environment.NewLine
                If iPartID > 0 Then strSql &= "AND Part_ID = " & iPartID & " " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function MapMainCategory_FailCode_RepairCode_PartNum(ByVal iMC_ID As Integer, _
                                                                    ByVal iFailID As Integer, _
                                                                    ByVal iRepID As Integer, _
                                                                    ByVal iPartID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO thtcmcfcrcpnmap ( MC_ID, Fail_ID, Repair_ID, Part_ID ) VALUES " & Environment.NewLine
                strSql &= "(" & iMC_ID & ", " & iFailID & ", " & iRepID & ", " & iPartID & ")" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function SetMapMainCategory_FailCode_RepairCode_PartNum_ToActiveInactive(ByVal iFCRCmap_ID As Integer, _
                                                                                        ByVal iInactive As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update thtcmcfcrcpnmap SET FCRCmap_Inactive = " & iInactive & Environment.NewLine
                strSql &= "WHERE FCRCmap_ID = " & iFCRCmap_ID & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetPsPriceIDByPartNumber(ByVal strPartNumber As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT PSPrice_ID FROM lpsprice WHERE PSPrice_Number = '" & strPartNumber.Trim.ToUpper & "' " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "RMA Processing"

        '******************************************************************
        Public Function GetHTCSku(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Sku_ID, Sku_Desc, Sku_Number, tmodel.Model_ID, tmodel.Model_Desc " & Environment.NewLine
                strSql &= "FROM tsku " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tsku.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & HTC.HTC_CUSTOMER_ID & " " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "-- SELECT --", "", "0", ""}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsCustomerRMAExisted(ByVal strRMA As String) As Boolean
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as Cnt FROM thtcdata WHERE hd_rma = '" & strRMA & "';"
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsPSSRMAExisted(ByVal strRMA As String) As Boolean
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as Cnt FROM thtcdata WHERE hd_PSSRMA = '" & strRMA & "';"
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ProcessRMA(ByVal dtData As DataTable) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iDisCrepUnit As Integer = 0
            Dim iDuplicate As Integer = 0

            Try
                '***************************************
                '1: check for duplicate workorder
                '***************************************
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tworkorder  " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & dtData.Rows(0)("Customer RMA") & "'" & Environment.NewLine
                strSql &= "AND loc_ID = " & Me.HTC_LOCATION_ID & " " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Throw New Exception("This RMA is existed in the system. Please verify with you supervisor.")
                End If

                '***************************************
                '2: Create workorder
                '***************************************
                objRec = New PSS.Data.Production.Receiving()

                iWO_ID = objRec.InsertIntoTworkorder(dtData.Rows(0)("Customer RMA"), dtData.Rows(0)("Customer RMA"), Me.HTC_LOCATION_ID, 2, dtData.Rows(0)("GroupID"), dtData.Rows(0)("PSS RMA"), dtData.Rows(0)("ShipTo_ID"), , dtData.Rows(0)("Sku_ID"), dtData.Rows.Count, 1)
                If iWO_ID = 0 Then
                    Throw New Exception("System has failed to create workorder for this RMA.")
                End If

                '***************************************
                '3: Create Tray
                '***************************************
                strSql = "INSERT INTO ttray (" & Environment.NewLine
                strSql &= "Tray_RecUser, Tray_RecUserID, WO_ID, Tray_Memo " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "'" & dtData.Rows(0)("Name") & "', " & dtData.Rows(0)("UsrID") & ", " & iWO_ID & ", NULL );"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If iWO_ID = 0 Then
                    Throw New Exception("System has failed to create tray ID for this RMA.")
                End If

                For Each R1 In dtData.Rows
                    '*******************************
                    'Check for duplicate
                    '*******************************
                    dt = Me.GetIMEI_InRMA(R1("IMEI"), R1("Customer RMA"))
                    If dt.Rows.Count > 0 Then
                        iDisCrepUnit = 1
                        iDuplicate = 1
                    End If

                    '*******************************
                    'insert into htcdata
                    '*******************************
                    strSql = "INSERT INTO thtcdata ( " & Environment.NewLine
                    strSql &= "hd_RMAProcessDT " & Environment.NewLine
                    strSql &= ", hd_RMAProcessUsrID " & Environment.NewLine
                    strSql &= ", WO_ID " & Environment.NewLine
                    strSql &= ", hd_PSSRMA " & Environment.NewLine
                    strSql &= ", hd_RMA " & Environment.NewLine
                    strSql &= ", hd_IMEI " & Environment.NewLine
                    strSql &= ", DiscUnit " & Environment.NewLine
                    strSql &= ", Duplicate " & Environment.NewLine
                    strSql &= ", Label_IMEI " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= " now() " & Environment.NewLine
                    strSql &= ", " & R1("UsrID") & " " & Environment.NewLine
                    strSql &= ", " & iWO_ID & " " & Environment.NewLine
                    strSql &= ", '" & R1("PSS RMA") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("Customer RMA") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("IMEI") & "' " & Environment.NewLine
                    strSql &= ", " & iDisCrepUnit & Environment.NewLine
                    strSql &= ", " & iDuplicate & Environment.NewLine
                    strSql &= ", '" & R1("IMEI") & "' " & Environment.NewLine
                    strSql &= "); " & Environment.NewLine

                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    iDisCrepUnit = 0
                    iDuplicate = 0
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
                Generic.DisposeDT(dtData)
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Dock Receiving"
        '******************************************************************
        Public Function GetDockReceiveOpenRMA() As DataTable
            Dim strSql As String

            Try
                'strSql = "SELECT Distinct WO_ID, hd_RMA as RMA, hd_Sku as Sku, DATE_FORMAT(hd_RMAProcessDT, '%m/%d/%Y' ) as 'RMA Date', Count(*) as 'File Qty' " & Environment.NewLine
                'strSql &= "FROM thtcdata " & Environment.NewLine
                'strSql &= "WHERE hd_DockRecDt is null and hd_DockRecDt is null " & Environment.NewLine
                'strSql &= "Group By hd_RMA"

                strSql = "SELECT Distinct WO_ID, wo_custwo as RMA, Sku_Desc as Sku, DATE_FORMAT(WO_Date , '%m/%d/%Y' ) as 'RMA Date', WO_Quantity as 'RMA Qty' " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tsku ON tworkorder.Sku_ID = tsku.Sku_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & HTC.HTC_LOCATION_ID & Environment.NewLine
                strSql &= "AND WO_DateDock is null and WO_Closed = 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function HTCDockRec(ByVal strRMA As String, _
                                  ByVal iFileQty As Integer, _
                                  ByVal iUsrID As Integer, _
                                  ByVal strUserName As String) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                '***************************************
                '3: Set workstation for all units in RMA
                '***************************************
                strSql = "UPDATE thtcdata, tworkorder " & Environment.NewLine
                strSql &= "SET hd_Station = 'RECEIVE' " & Environment.NewLine
                strSql &= ", hd_StationEnterDt = now()" & Environment.NewLine
                strSql &= ", hd_DockRecDt = now() " & Environment.NewLine
                strSql &= ", hd_DockRecUsrID = " & iUsrID & Environment.NewLine
                strSql &= ", tworkorder.WO_DateDock = now() " & Environment.NewLine
                strSql &= "WHERE thtcdata.WO_ID = tworkorder.WO_ID AND hd_RMA = '" & strRMA & "'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                '***************************************

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Production Receiving"

        '******************************************************************
        Public Function GetProdRecOpenRMA() As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql &= "SELECT tworkorder.*, Sku_Desc " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tsku On tworkorder.Sku_ID = tsku.Sku_ID " & Environment.NewLine
                strSql &= "WHERE Prod_ID = 2 AND WO_Closed = 0 AND Loc_ID = " & Me.HTC_LOCATION_ID & Environment.NewLine
                strSql &= "AND WO_DateDock is not null "
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "-- select --"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRMAInfo(ByVal strRMA As String) As DataTable
            Dim strSql As String

            Try
                strSql &= "SELECT * FROM thtcdata WHERE hd_RMA = '" & strRMA & "' AND hd_Station is not null;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetHTCWOID(ByVal strCustWO As String) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql &= "SELECT * FROM tworkorder WHERE WO_CustWO = '" & strCustWO & "' AND Loc_ID = " & Me.HTC_LOCATION_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("WO ID is missing please contact your supervisor for advice.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("WO ID existed twice in the system please contact IT.")
                ElseIf dt.Rows(0)("WO_Closed") = 1 Then
                    Throw New Exception("This RMA is already closed.")
                Else
                    Return dt.Rows(0)("WO_ID")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetHTCSkuInfo(ByVal strSku As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tsku.*, Model_Desc FROM tsku " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tsku.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & Me.HTC_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Sku_Number = '" & strSku & "';"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function HTC_PreviousRepInfo(ByVal strIMEI As String) As DataRow
            Dim strSql As String
            Dim R1 As DataRow = Nothing
            Dim R2 As DataRow = Nothing
            Dim dt1, dt2 As DataTable

            Try
                strSql = "SELECT tdevice.* FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strIMEI & "'" & Environment.NewLine
                strSql &= "AND Loc_ID = " & Me.HTC_LOCATION_ID & Environment.NewLine
                strSql &= "Order by device_ID desc;"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    strSql = "SELECT DiscUnit FROM thtcdata "
                    strSql &= "WHERE thtcdata.Device_ID = " & R1("Device_ID") & Environment.NewLine
                    'strSql &= "AND DiscUnit = 0 " & Environment.NewLine
                    PSS.Data.Buisness.Generic.DisposeDT(dt2)
                    dt2 = Me._objDataProc.GetDataTable(strSql)
                    If dt1.Rows.Count = 0 Then
                        R2 = R1
                        Exit For
                    ElseIf dt1.Rows(0)("DiscUnit") = 0 Then
                        R2 = R1
                        Exit For
                    End If
                Next R1

                Return R2
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                PSS.Data.Buisness.Generic.DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************
        Public Function GetRecAndDiscrUnits(ByVal strRMA As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT " & Environment.NewLine
                strSql &= " hd_RMA as RMA " & Environment.NewLine
                strSql &= ", if(Sku_Number is null, '', Sku_Number)  as 'Sku' " & Environment.NewLine
                strSql &= ", hd_SN as SN " & Environment.NewLine
                strSql &= ", hd_IMEI as IMEI " & Environment.NewLine
                strSql &= ", hd_PartNo as 'P/N' " & Environment.NewLine
                strSql &= ", hd_FileWty as 'ASN Wrty' " & Environment.NewLine
                strSql &= ", if(DeviceWty = 1, 'IW','OOW') as 'Unit Wrty' " & Environment.NewLine
                strSql &= ", if(Model_Desc is null, '', Model_Desc) as 'Model' " & Environment.NewLine
                strSql &= ", if(PreviousRep_DeviceID is not null, 'Y', 'N') as 'Repeat Rep' " & Environment.NewLine
                strSql &= ", hd_Station as 'Station' " & Environment.NewLine
                strSql &= ", if(ExtraUnit = 1, 'X', '') as 'Extra Unit' " & Environment.NewLine
                strSql &= ", if(MissingUnit = 1, 'X', '') as 'Missing Unit' " & Environment.NewLine
                strSql &= ", if(WrongSku = 1, 'X', '') as 'Wrong Sku' " & Environment.NewLine
                strSql &= ", if(Duplicate = 1, 'X', '') as 'Duplicate' " & Environment.NewLine
                strSql &= "FROM  thtcdata " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice ON thtcdata.Device_ID = tdevice.Device_ID  " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tsku ON tdevice.Sku_ID = tsku.Sku_ID " & Environment.NewLine
                strSql &= "WHERE hd_RMA  = '" & strRMA & "' " & Environment.NewLine
                strSql &= "AND (thtcdata.Device_ID is not null OR DiscUnit = 1 )" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetCurrentWeek() As Integer
            Dim strSql As String = ""

            Try
                strSql = "select WEEK(now()) " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetCurrentYear() As Integer
            Dim strSql As String = ""

            Try
                strSql = "select YEAR(now(), 3) " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function GetWeek(ByVal strDate As String) As Integer
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "select WEEK('" & strDate & "', 3 ) " & Environment.NewLine
        '        Return Me._objDataProc.GetIntValue(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************
        Public Function GetYear(ByVal strDate As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "select YEAR('" & strDate & "', 3) " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ProdReceive(ByVal strRMA As String, _
                                    ByVal iWOID As Integer, _
                                    ByVal iTrayID As Integer, _
                                    ByVal iModel_ID As Integer, _
                                    ByVal iSkuID As Integer, _
                                    ByVal strPartNo As String, _
                                    ByVal strIMEI As String, _
                                    ByVal strSN As String, _
                                    ByVal ihdID As Integer, _
                                    ByVal iHTCWrty As Integer, _
                                    ByVal iShiftID As Integer, _
                                    ByVal iPrevRepDeviceID As Integer, _
                                    ByVal iUsrID As Integer, _
                                    ByVal strUsrName As String, _
                                    ByVal iEmpNo As Integer, _
                                    ByVal iWrongSku As Integer, _
                                    ByVal iExtraItem As Integer, _
                                    ByVal iLessThan30Days As Integer) As Integer
            Const iWipID As Integer = 1 'Receive
            Const iRUR_DcodeID As Integer = 2942
            Dim dtRUR_Type As DataTable
            Dim strSql As String = ""
            Dim i As Integer
            Dim iCnt As Integer = 0
            Dim iDeviceID As Integer = 0
            Dim strWrkDate As String = ""
            Dim objRec As PSS.Data.Production.Receiving
            'Dim objGenBilling As PSS.Data.Buisness.GenerateBilling
            Dim iDiscrepancyUnit As Integer = 0
            Dim strWrkStation As String = ""
            Dim booBilling As Boolean = False

            Try
                If iWrongSku > 0 Or iExtraItem > 0 Or iLessThan30Days > 0 Then
                    strWrkStation = "RECEIVE"
                    iDiscrepancyUnit = 1
                ElseIf iHTCWrty = 0 Then
                    strWrkStation = "PACKAGING"

                    '***************************************
                    'get RUR type and validate map of rur billcode
                    '***************************************
                    If Generic.IsBillcodeMapped(iModel_ID, Me.HTC_RUR_BILLCODEID) = 0 Then
                        Throw New Exception("RUR bill-code is missing for this model. Please contact IT.")
                    ElseIf IsNothing(Me._dtRURInfo) Then
                        dtRUR_Type = Me.GetHTC_RURType()
                    ElseIf Me._dtRURInfo.Rows.Count = 0 Then
                        dtRUR_Type = Me.GetHTC_RURType()
                    Else
                        dtRUR_Type = Me._dtRURInfo
                        If dtRUR_Type.Rows.Count = 0 Or dtRUR_Type.Select("Dcode_id = " & iRUR_DcodeID).Length = 0 Then Throw New Exception("Can't define RUR criteria for out of warranty. Please contact IT.")
                    End If
                    '***************************************
                Else
                    strWrkStation = "DIAGNOSTIC"
                End If

                objRec = New PSS.Data.Production.Receiving()
                strWrkDate = PSS.Data.Buisness.Generic.GetWorkDate(iShiftID)
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iCnt, iTrayID, Me.HTC_LOCATION_ID, iWOID, iModel_ID, iShiftID, , , iSkuID, )
                If iDeviceID = 0 Then
                    Throw New Exception("System has failed to create Device ID.")
                End If

                i = objRec.InsertIntoTCellopt(iDeviceID, strSN, strIMEI, , , , , , , , , , , , )

                If iWrongSku > 0 Or iExtraItem > 0 Or iLessThan30Days > 0 Then iDiscrepancyUnit = 1

                If iExtraItem > 0 And ihdID = 0 Then
                    strSql = "INSERT INTO thtcdata ( " & Environment.NewLine
                    strSql &= " hd_RMA " & Environment.NewLine
                    strSql &= ", hd_IMEI " & Environment.NewLine
                    strSql &= ", hd_DateLoad " & Environment.NewLine
                    strSql &= ", hd_ProdRecUsrID " & Environment.NewLine
                    strSql &= ", hd_ProdRecDt " & Environment.NewLine
                    strSql &= ", hd_SN " & Environment.NewLine
                    strSql &= ", hd_PartNo " & Environment.NewLine
                    strSql &= ", hd_StationEnterDt " & Environment.NewLine
                    strSql &= ", hd_Station " & Environment.NewLine
                    strSql &= ", DeviceWty " & Environment.NewLine
                    strSql &= ", Device_ID " & Environment.NewLine
                    strSql &= ", DiscUnit " & Environment.NewLine
                    strSql &= ", ExtraUnit_IMEI " & Environment.NewLine
                    strSql &= ", ExtraUnit " & Environment.NewLine
                    strSql &= ", WrongSku " & Environment.NewLine
                    strSql &= ", LessThan30days " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= " '" & strRMA & "'" & Environment.NewLine
                    strSql &= ", '" & strIMEI & "'" & Environment.NewLine
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", " & iUsrID & "" & Environment.NewLine
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", '" & strSN & "'" & Environment.NewLine
                    strSql &= ", '" & strPartNo & "'" & Environment.NewLine
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", '" & strWrkStation & "'" & Environment.NewLine
                    strSql &= ", " & iHTCWrty & "" & Environment.NewLine
                    strSql &= ", " & iDeviceID & "" & Environment.NewLine
                    strSql &= ", 1 " & Environment.NewLine
                    strSql &= ", '" & strIMEI & "'" & Environment.NewLine
                    strSql &= ", " & iExtraItem & Environment.NewLine
                    strSql &= ", " & iWrongSku & Environment.NewLine
                    strSql &= ", " & iLessThan30Days & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE thtcdata " & Environment.NewLine
                    strSql &= "SET hd_Station = '" & strWrkStation & "' " & Environment.NewLine
                    strSql &= ", hd_StationEnterDt = now()" & Environment.NewLine
                    strSql &= ", hd_ProdRecDt = now() " & Environment.NewLine
                    strSql &= ", hd_ProdRecUsrID = " & iUsrID & Environment.NewLine
                    strSql &= ", hd_SN = '" & strSN & "'" & Environment.NewLine
                    strSql &= ", hd_PartNo = '" & strPartNo & "'" & Environment.NewLine
                    If iPrevRepDeviceID > 0 Then strSql &= ", PeviousRep_DeviceID = " & iPrevRepDeviceID & " " & Environment.NewLine
                    strSql &= ", DeviceWty = " & iHTCWrty & Environment.NewLine
                    strSql &= ", Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= ", WrongSku = " & iWrongSku & Environment.NewLine
                    strSql &= ", LessThan30days = " & iLessThan30Days & Environment.NewLine
                    strSql &= ", DiscUnit = " & iDiscrepancyUnit & Environment.NewLine
                    strSql &= "WHERE hd_ID = " & ihdID & " " & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                If i = 0 Then
                    Throw New Exception("System has failed to update HTC data.")
                End If

                If iHTCWrty = 0 And iDiscrepancyUnit = 0 Then
                    '''***************************
                    '''1: Bill RUR
                    '''***************************
                    ''objGenBilling = New PSS.Data.Buisness.GenerateBilling()
                    ''booBilling = objGenBilling.ab_ADD(iDeviceID, Me.HTC_RUR_BILLCODEID, 2, iUsrID, strUsrName, iEmpNo, iShiftID, strWrkDate)
                    ''If booBilling = False Then
                    ''    Throw New Exception("System failed to bill ""billcode ID:" & Me.HTC_RUR_BILLCODEID & """ on ""device ID " & iDeviceID & """")
                    ''End If
                    '*****************************************************
                    '2: write faicode and repair code to thtcrepair table
                    '*****************************************************
                    i = Me.InsertFailCodeRepCode_ToRepairTable(0, iDeviceID, _
                            dtRUR_Type.Select("Dcode_id = " & iRUR_DcodeID)(0)("MC_ID"), _
                            dtRUR_Type.Select("Dcode_id = " & iRUR_DcodeID)(0)("Fail_ID"), _
                            dtRUR_Type.Select("Dcode_id = " & iRUR_DcodeID)(0)("Repair_ID"), _
                            iUsrID, strWrkStation, 1, 0, Me.HTC_RUR_BILLCODEID, _
                            dtRUR_Type.Select("Dcode_id = " & iRUR_DcodeID)(0)("PSPrice_ID"), _
                            dtRUR_Type.Select("Dcode_id = " & iRUR_DcodeID)(0)("Part_Number"), , )

                    If i = 0 Then Throw New Exception("System failed to record Failcode and Repaircode. Please contact your supervisor.")
                    '***********************************
                    '1: write rur reason to tdevicecode
                    '***********************************
                    i = Me.InsertRURFailCodeToTdevicecodes(iDeviceID, iRUR_DcodeID)
                    If i = 0 Then Throw New Exception("System failed to record RUR reason. Please contact your supervisor.")
                End If

                '******************************
                '4: push utit to packaging
                '******************************
                i = Me.PushUnitToNextWorkingStation(iDeviceID, strWrkStation)
                If i > 0 Then
                    'MessageBox.Show("Device has moved to " & strWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Throw New Exception("System failed to push the device to " & strWrkStation & ".")
                End If
                '******************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
                ''objGenBilling = Nothing
                Generic.DisposeDT(dtRUR_Type)
            End Try
        End Function

        '******************************************************************
        Public Function UpdateWOQuantity(ByVal iWO_ID As Integer, ByVal iQty As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tworkorder SET WO_RAQnty = " & iQty & " WHERE WO_ID = " & iWO_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CloseWO(ByVal iWO_ID As Integer, _
                                ByVal iQty As Integer, _
                                ByVal strRMA As String, _
                                ByVal iUsrID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim j As Integer = 0

            Try
                strSql = "UPDATE tworkorder SET WO_RAQnty = " & iQty & ", WO_Closed = 1 WHERE WO_ID = " & iWO_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE thtcdata SET MissingUnit = 1, DiscUnit = 1, hd_ProdRecDt = now(), hd_ProdRecUsrID = " & iUsrID & " WHERE hd_RMA = '" & strRMA & "' and Device_ID is null;" & Environment.NewLine
                j = Me._objDataProc.ExecuteNonQuery(strSql)

                Return 1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Relabel"

        '******************************************************************
        Public Function GetNewIMEI(ByVal DeviceID As Integer) As String
            Dim strSql As String
            Try
                strSql = "SELECT IF(thtcrepair.RI_MB_IMEI is null, '', thtcrepair.RI_MB_IMEI) as NewIMEI " & Environment.NewLine
                strSql &= "FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & DeviceID & " " & Environment.NewLine
                strSql &= "AND thtcrepair.RI_MB_IMEI is not null"
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ChangeSN(ByVal iDeviceID As Integer, ByVal strNewIMEI As String) As Integer
            Dim strSql As String
            Try
                strSql = "UPDATE tdevice SET Device_OldSN = Device_SN, Device_SN = '" & strNewIMEI & "', device_sn_change_date = now() WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub PrintIMEILabel(ByVal strPartNumber As String, _
                                    ByVal strIMEI As String, _
                                    ByVal strSN As String, _
                                    Optional ByVal iPrintoutNumber As Integer = 1, _
                                    Optional ByVal strRptName As String = "")
            Dim objRpt As ReportDocument
            Dim dt1 As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT '" & strSN & "' AS DeviceSN, '" & strIMEI & "' as IMEI, '" & strPartNumber & "' as PartNum "
                dt1 = Me._objDataProc.GetDataTable(strSql)

                'Print label
                If Not IsNothing(dt1) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        If strRptName.Trim.Length > 0 Then
                            .Load(ConfigFile.GetBaseReportPath & strRptName)
                        Else
                            .Load(ConfigFile.GetBaseReportPath & "HTC SN.rpt")
                        End If
                        .SetDataSource(dt1)
                        .PrintToPrinter(iPrintoutNumber, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '******************************************************************
        Public Function ChangeLastCharOfPartNumber(ByVal strStation As String, _
                                             ByVal iDeviceID As Integer, _
                                             ByVal iUsrID As Integer, _
                                             ByVal strUsrName As String, _
                                             ByVal strNewPartNumber As String, _
                                             ByVal strOldPartNumber As String) As Integer
            Dim strSql As String
            Try
                'Keep history
                strSql = "INSERT INTO thtcpnchangehistory ( PNC_Station, PNC_datetime, PNC_Old_PN, PNC_New_PN, user_fullname, user_id, Device_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " '" & strStation & "' " & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ", '" & strOldPartNumber & "' " & Environment.NewLine
                strSql &= ", '" & strNewPartNumber & "' " & Environment.NewLine
                strSql &= ", '" & strUsrName & "' " & Environment.NewLine
                strSql &= ", " & iUsrID & Environment.NewLine
                strSql &= ", " & iDeviceID & Environment.NewLine
                strSql &= " ) " & Environment.NewLine
                Me._objDataProc.ExecuteNonQuery(strSql)

                'Update Part Number
                strSql = "UPDATE thtcdata SET hd_PartNo = '" & strNewPartNumber & "' WHERE Device_ID = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetMainBoardIMEI(ByVal strIMEI As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT * FROM thtcsnimeimap " & Environment.NewLine
                strSql &= "WHERE IMEI = '" & strIMEI & "' ORDER BY SI_ID DESC " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "RF/Final Test/Repair"

        '******************************************************************
        Public Function GetHTC_thtcdataInfo_InWIP(ByVal strSN As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Sku_PartNo, Sku_Number, tdevice.Model_ID, tmodel.Model_Desc, tdevice.Pallett_ID " & Environment.NewLine
                strSql &= ", if(thtcdata.DiscUnit = 0, '', (case " & Environment.NewLine
                strSql &= "when thtcdata.ExtraUnit = 1 then 'Extra Unit' " & Environment.NewLine
                strSql &= "when thtcdata.MissingUnit = 1 then 'Missing Unit' " & Environment.NewLine
                strSql &= "when thtcdata.WrongSku = 1 then 'Wrong Sku' " & Environment.NewLine
                strSql &= "when thtcdata.Duplicate = 1 then 'Duplicate IMEI' " & Environment.NewLine
                strSql &= "when thtcdata.LessThan30days then 'Less than 30 unit' " & Environment.NewLine
                strSql &= "else '' " & Environment.NewLine
                strSql &= "end ) ) as 'Discrepancy Reason' " & Environment.NewLine
                strSql &= ", IF(security.tusers.user_fullname is null, '', security.tusers.user_fullname) as 'LastCompletedUser' " & Environment.NewLine
                strSql &= ", thtcdata.* " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tsku ON tdevice.Sku_ID = tsku.Sku_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers ON thtcdata.LastCompleted_TechUsrID = security.tusers.user_id " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_SN = '" & strSN.Trim.ToUpper & "' " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & Me.HTC_LOCATION_ID & Environment.NewLine
                strSql &= "AND (tdevice.Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '') " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceRepairDisplayList(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT G.MC_Desc as 'Main Category', B.Fail_LDesc as 'Fail Code', A.Fail_RecStation as 'Fail At'" & Environment.NewLine
                strSql &= ", C.user_fullname AS 'Failed Inspector'  " & Environment.NewLine
                strSql &= ", IF(D.Repair_LDesc is null, '',  D.Repair_LDesc) as 'Repair Code' " & Environment.NewLine
                strSql &= ", IF(F.Billcode_Desc is null, '', F.Billcode_Desc) as 'Part' " & Environment.NewLine
                strSql &= ", IF(A.RI_SN is null, '', A.RI_SN ) as 'Part SN' " & Environment.NewLine
                strSql &= ", IF(A.RI_MB_IMEI is null, '', A.RI_MB_IMEI ) as 'Part IMEI' " & Environment.NewLine
                strSql &= ", A.PartNumber " & Environment.NewLine
                strSql &= ", IF(E.user_fullname is null, '',  E.user_fullname) as 'Tech' " & Environment.NewLine
                'strSql &= ", IF(A.RI_Completed = 1, 'YES', 'NO') as 'Completed' " & Environment.NewLine
                strSql &= ", IF(A.RI_CompletedDt is null, '', A.RI_CompletedDt ) as 'Completed Date'" & Environment.NewLine
                strSql &= ", A.Fail_ID, A.Repair_ID, A.Device_ID, A.RI_ID, A.BillCode_ID, A.PSPrice_ID, A.MC_ID " & Environment.NewLine
                strSql &= "FROM thtcrepair A " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodesmaincategories G ON A.MC_ID = G.MC_ID " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes B ON A.Fail_ID = B.Fail_ID " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers C ON A.Fail_RecUsrID = C.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lrepaircodes D ON A.Repair_ID = D.Repair_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers E ON A.Repair_RecUsrID = E.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lbillcodes F ON A.BillCode_ID = F.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY A.RI_ID Desc " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFailcodesMainCategories(ByVal booExcludeCosmetic As Boolean)
            Dim strSql As String
            Try
                strSql = "select * from lfailcodesmaincategories WHERE MC_Inactive = 0 and MC_ID not in (14,  16 ) "
                If booExcludeCosmetic = True Then
                    strSql &= "AND MC_ID <> 6 "
                End If
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFailCodes(ByVal iProdID As Integer, _
                                     Optional ByVal iModelID As Integer = 0, _
                                     Optional ByVal iRepair_ID As Integer = 0, _
                                     Optional ByVal iFailcodeMainCategory As Integer = 0) As DataTable
            Dim strSql As String

            Try
                If iRepair_ID > 0 Then
                    strSql = "SELECT DISTINCT lfailcodes.* " & Environment.NewLine
                    strSql &= "FROM lfailcodes " & Environment.NewLine
                    strSql &= "INNER JOIN thtcmcfcrcpnmap ON lfailcodes.Fail_ID = thtcmcfcrcpnmap.Fail_ID " & Environment.NewLine
                    strSql &= "WHERE thtcmcfcrcpnmap.Repair_ID = " & iRepair_ID & " " & Environment.NewLine
                    strSql &= "AND Fail_Inactive = 0 AND FCRCmap_Inactive  = 0 " & Environment.NewLine
                    'exclude RUR
                    strSql &= "AND lfailcodes.Fail_ID not in (140, 136, 126, 135 ) " & Environment.NewLine
                    If iModelID > 0 Then
                        strSql &= "AND lfailcodes.Model_ID = " & iModelID & Environment.NewLine
                    End If
                    strSql &= "ORDER BY Fail_LDesc" & Environment.NewLine
                ElseIf iFailcodeMainCategory > 0 Then
                    strSql = "SELECT DISTINCT lfailcodes.* " & Environment.NewLine
                    strSql &= "FROM lfailcodes " & Environment.NewLine
                    strSql &= "INNER JOIN thtcmcfcrcpnmap ON lfailcodes.Fail_ID = thtcmcfcrcpnmap.Fail_ID " & Environment.NewLine
                    strSql &= "WHERE lfailcodes.Prod_ID = " & iProdID & Environment.NewLine
                    strSql &= "AND Fail_Inactive = 0 AND thtcmcfcrcpnmap.FCRCmap_Inactive = 0 " & Environment.NewLine
                    strSql &= "AND thtcmcfcrcpnmap.MC_ID = " & iFailcodeMainCategory & " " & Environment.NewLine
                    'exclude RUR
                    strSql &= "AND lfailcodes.Fail_ID not in (140, 136, 126, 135 ) " & Environment.NewLine
                    If iModelID > 0 Then
                        strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                    End If
                    strSql &= "ORDER BY Fail_LDesc" & Environment.NewLine
                Else
                    strSql = "SELECT * FROM lfailcodes " & Environment.NewLine
                    strSql &= "WHERE Prod_ID = " & iProdID & Environment.NewLine
                    strSql &= "AND Fail_Inactive = 0 " & Environment.NewLine
                    'exclude RUR
                    strSql &= "AND Fail_ID not in (140, 136, 126, 135 ) " & Environment.NewLine
                    If iModelID > 0 Then
                        strSql &= "AND Model_ID = " & iModelID & Environment.NewLine
                    End If
                    strSql &= "ORDER BY Fail_LDesc" & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRepairCodes(ByVal iProdID As Integer, _
                                       ByVal iModelID As Integer, _
                                       ByVal iBillcodeID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT lrepaircodes.* " & Environment.NewLine
                strSql &= "FROM lrepaircodes " & Environment.NewLine
                strSql &= "INNER JOIN thtcmcfcrcpnmap ON lrepaircodes.Repair_ID = thtcmcfcrcpnmap.Repair_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON thtcmcfcrcpnmap.PSPrice_ID = tpsmap.PSPrice_ID and lrepaircodes.Model_ID = tpsmap.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.BillCode_ID = " & iBillcodeID & " " & Environment.NewLine
                strSql &= "AND tpsmap.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND lrepaircodes.Prod_ID = " & iProdID & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0 " & Environment.NewLine
                strSql &= "AND thtcmcfcrcpnmap.FCRCmap_Inactive = 0 " & Environment.NewLine
                strSql &= "AND lrepaircodes.Repair_Inactive = 0 ;"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFunctionalFailCodesByBillCodeID(ByVal iProdID As Integer, _
                                       ByVal iModelID As Integer, _
                                       ByVal iBillcodeID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql &= "SELECT lfailcodes.*, thtcmcfcrcpnmap.Repair_ID, tpsmap.PSPrice_ID, lpsprice.PSPrice_Number " & Environment.NewLine
                strSql &= "FROM lfailcodes " & Environment.NewLine
                strSql &= "INNER JOIN thtcmcfcrcpnmap ON lfailcodes.Fail_ID= thtcmcfcrcpnmap.Fail_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON thtcmcfcrcpnmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON thtcmcfcrcpnmap.PSPrice_ID = tpsmap.PSPrice_ID and lfailcodes.Model_ID = tpsmap.Model_ID  " & Environment.NewLine
                strSql &= "WHERE tpsmap.BillCode_ID = " & iBillcodeID & "  " & Environment.NewLine
                strSql &= "AND tpsmap.Model_ID = " & iModelID & " " & Environment.NewLine
                strSql &= "AND lfailcodes.Prod_ID = " & iProdID & Environment.NewLine
                'strSql &= "AND lfailcodes.Fail_ID <> " & HTC.HTC_COSMETIC_FAILID & Environment.NewLine
                strSql &= "AND thtcmcfcrcpnmap.Repair_ID <> " & HTC.HTC_COSMETIC_REPAIRID & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0  " & Environment.NewLine
                strSql &= "AND thtcmcfcrcpnmap.FCRCmap_Inactive = 0  " & Environment.NewLine
                strSql &= "AND lfailcodes.Fail_Inactive = 0 " & Environment.NewLine
                strSql &= "ORDER BY Fail_LDesc asc "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertFailCodeToRepairTable(ByVal iDeviceID As Integer, _
                                                    ByVal iMC_ID As Integer, _
                                                    ByVal iFailID As Integer, _
                                                    ByVal iIDuser As Integer, _
                                                    ByVal strStation As String) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT count(*) FROM thtcrepair WHERE Device_ID = " & iDeviceID & " AND Fail_ID = " & iFailID & " AND MC_ID = " & iMC_ID

                If Me._objDataProc.GetIntValue(strSql) = 0 Then
                    strSql = "INSERT INTO thtcrepair " & Environment.NewLine
                    strSql &= "( MC_ID,  Fail_ID, Fail_RecUsrID, Fail_RecDt, Fail_RecStation, Device_ID ) " & Environment.NewLine
                    strSql &= "VALUES " & Environment.NewLine
                    strSql &= "( " & iMC_ID & ", " & iFailID & ", " & iIDuser & ", now(), '" & strStation & "', " & iDeviceID & " )"
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    MessageBox.Show("Main Category ID: " & iMC_ID & " and Fail code ID: " & iFailID & " is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function PushUnitToNextWorkingStation(ByVal iDeviceID As Integer, _
                                                     ByVal strNextStation As String, _
                                                     Optional ByVal iCompletedTechUsrID As Integer = 0, _
                                                     Optional ByVal strLabelIMEI As String = "") As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE thtcdata SET hd_StationEnterDt = now(), hd_Station = '" & strNextStation & "'" & Environment.NewLine
                If iCompletedTechUsrID > 0 Then strSql &= ", LastCompleted_TechUsrID = " & iCompletedTechUsrID & Environment.NewLine
                If strLabelIMEI.Trim.Length > 0 Then strSql &= ", Label_IMEI = '" & strLabelIMEI & "'" & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function RemoveFailCodeFrRepairTable(ByVal iRI_ID As Integer, _
                                                    ByVal iUsrID As Integer, _
                                                    ByVal strStation As String) As Integer
            Dim strSql As String
            Dim i As Integer = 0
            Try
                'Keep deleting record in history table
                i = Me.RecordDeletedFCRC(iUsrID, strStation, iRI_ID, )

                'delete record
                strSql = "DELETE FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE RI_ID = " & iRI_ID & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function RecordDeletedFCRC(ByVal iUsrID As Integer, _
                                          ByVal strStation As String, _
                                          Optional ByVal iRI_ID As Integer = 0, _
                                          Optional ByVal iDeviceID As Integer = 0, _
                                          Optional ByVal iBillcodeID As Integer = 0) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strField As String = ""
            Dim strData As String = ""
            Dim i As Integer = 0

            Try
                'Keep deleting record in history table
                If iRI_ID > 0 Then
                    strSql = "SELECT * FROM thtcrepair WHERE RI_ID = " & iRI_ID & ";"
                ElseIf iDeviceID > 0 And iBillcodeID > 0 Then
                    strSql = "SELECT * FROM thtcrepair WHERE Device_ID = " & iDeviceID & " AND Billcode_ID = " & iBillcodeID & ";"
                ElseIf iDeviceID > 0 Then
                    strSql = "SELECT * FROM thtcrepair WHERE Device_ID = " & iDeviceID & ";"
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    'save delete record
                    strField = "RD_DeleteDate, RD_DeleleteUsrID, RD_DeleteFrStation , MC_ID "
                    strData = "now(), " & iUsrID.ToString & ", '" & strStation & "', " & R1("MC_ID").ToString
                    If Not IsDBNull(R1("Fail_ID")) Then
                        strField &= ", Fail_ID"
                        strData &= ", " & R1("Fail_ID").ToString
                    End If
                    If Not IsDBNull(R1("Fail_RecUsrID")) Then
                        strField &= ", Fail_RecUsrID"
                        strData &= ", " & R1("Fail_RecUsrID").ToString
                    End If
                    If Not IsDBNull(R1("Fail_RecDt")) Then
                        strField &= ", Fail_RecDt"
                        strData &= ", '" & Format(CDate(R1("Fail_RecDt")), "yyyy-MM-dd hh:mm:ss") & "' "
                    End If
                    If Not IsDBNull(R1("Fail_RecStation")) Then
                        strField &= ", Fail_RecStation"
                        strData &= ", '" & R1("Fail_RecStation").ToString & "'"
                    End If
                    If Not IsDBNull(R1("Repair_ID")) Then
                        strField &= ", Repair_ID"
                        strData &= ", " & R1("Repair_ID").ToString
                    End If
                    If Not IsDBNull(R1("Repair_RecUsrID")) Then
                        strField &= ", Repair_RecUsrID"
                        strData &= ", " & R1("Repair_RecUsrID").ToString
                    End If
                    If Not IsDBNull(R1("Repair_RecDt")) Then
                        strField &= ", Repair_RecDt"
                        strData &= ", '" & Format(CDate(R1("Repair_RecDt")), "yyyy-MM-dd hh:mm:ss") & "' "
                    End If

                    If Not IsDBNull(R1("PartNumber")) Then
                        strField &= ", PartNumber"
                        strData &= ", '" & R1("PartNumber").ToString & "'"
                    End If
                    strField &= ", IsRefurbishment"
                    strData &= ", " & R1("IsRefurbishment").ToString

                    If Not IsDBNull(R1("PSPrice_ID")) Then
                        strField &= ", PSPrice_ID"
                        strData &= ", " & R1("PSPrice_ID").ToString
                    End If
                    If Not IsDBNull(R1("BillCode_ID")) Then
                        strField &= ", BillCode_ID"
                        strData &= ", " & R1("BillCode_ID").ToString
                    End If
                    If Not IsDBNull(R1("Device_ID")) Then
                        strField &= ", Device_ID"
                        strData &= ", " & R1("Device_ID").ToString
                    End If
                    If Not IsDBNull(R1("RI_SN")) Then
                        strField &= ", RI_SN"
                        strData &= ", '" & R1("RI_SN").ToString & "'"
                    End If
                    If Not IsDBNull(R1("RI_MB_IMEI")) Then
                        strField &= ", RI_MB_IMEI"
                        strData &= ", '" & R1("RI_MB_IMEI").ToString & "'"
                    End If
                    If Not IsDBNull(R1("RI_CompletedUsrID")) Then
                        strField &= ", RI_CompletedUsrID"
                        strData &= ", " & R1("RI_CompletedUsrID") & " "
                    End If
                    If Not IsDBNull(R1("RI_CompletedDt")) Then
                        strField &= ", RI_CompletedDt"
                        strData &= ", '" & Format(CDate(R1("RI_CompletedDt")), "yyyy-MM-dd hh:mm:ss") & "' "
                    End If
                    If Not IsDBNull(R1("RI_Completed")) Then
                        strField &= ", RI_Completed"
                        strData &= ", " & R1("RI_Completed").ToString
                    End If
                    strSql = "INSERT INTO thtcrepairdeleteitem " & Environment.NewLine
                    strSql &= "( " & strField & ") " & Environment.NewLine
                    strSql &= "VALUES " & Environment.NewLine
                    strSql &= "( " & strData & " )"

                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function RemoveAllFailCodeFrRepairTable(ByVal iDeviceID As Integer, _
                                                       ByVal iUsrID As Integer, _
                                                       ByVal strStation As String) As Integer
            Dim strSql As String
            Dim i As Integer

            Try
                'Keep deleting record in history table
                i = Me.RecordDeletedFCRC(iUsrID, strStation, , iDeviceID, )

                'delete record
                strSql = "DELETE FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CheckDeviceRepairStatus(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT lbillcoderules.BillCode_Rule, lbillcoderules.BillCodeRule_Desc, lbillcodes.BillType_ID, thtcrepair.Billcode_ID " & Environment.NewLine
                strSql &= "FROM thtcrepair " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON thtcrepair.BillCode_ID = lbillcodes.BillCode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcoderules ON lbillcodes.BillCode_Rule = lbillcoderules.BillCode_Rule " & Environment.NewLine
                strSql &= "WHERE thtcrepair.Device_ID = " & iDevice_ID & Environment.NewLine
                strSql &= "ORDER BY BillCode_Rule DESC, BillType_ID DESC"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function RemoveFailCodesFrRepairTableByMainCategory(ByVal iDeviceID As Integer, _
                                                                   ByVal iMC_ID As Integer, _
                                                                   ByVal iUsrID As Integer, _
                                                                   ByVal strStation As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim j As Integer = 0

            Try
                strSql = "SELECT DISTINCT RI_ID FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE thtcrepair.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND thtcrepair.MC_ID = " & iMC_ID & Environment.NewLine
                strSql &= "AND thtcrepair.Repair_ID is null  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    'Keep deleting record in history table
                    j += Me.RecordDeletedFCRC(iUsrID, strStation, , iDeviceID, )

                    strSql = "DELETE FROM thtcrepair " & Environment.NewLine
                    strSql &= "WHERE thtcrepair.RI_ID = " & R1("RI_ID") & Environment.NewLine

                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTestTypeID(ByVal strTestDesription As String) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT Test_ID FROM ltesttype WHERE Test_Desc = '" & strTestDesription & "';"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTestStationHistory(ByVal iDeviceID As Integer, _
                                        Optional ByVal iTestTypeID As Integer = 0) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try

                strSql = "SELECT A.Device_ID, A.TD_ID, A.Test_ID, D.QCResult_ID, A.TD_UsrID, 0 as 'Seq' " & Environment.NewLine
                strSql &= ", C.Test_Desc as 'Station' " & Environment.NewLine
                strSql &= ", D.QCResult as 'Result' " & Environment.NewLine
                strSql &= ", A.TD_FailDetails AS FailDetails " & Environment.NewLine
                strSql &= ", B.user_fullname as 'Inspector' " & Environment.NewLine
                strSql &= ", IF(F.user_fullname is null, '', F.user_fullname ) as 'Tech'" & Environment.NewLine
                strSql &= ", IF(G.user_fullname is null, '', G.user_fullname )as 'FinalTester'" & Environment.NewLine
                strSql &= ", TD_TestDt as 'Date' " & Environment.NewLine
                strSql &= ", E.Reject " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers B ON A.TD_UsrID = B.user_id " & Environment.NewLine
                strSql &= "INNER JOIN ltesttype C ON A.Test_ID = C.Test_ID " & Environment.NewLine
                strSql &= "INNER JOIN lqcresult D ON A.QCResult_ID = D.QCResult_ID " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata E ON A.Device_ID = E.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers F ON A.CompletedTechUsrID = F.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers G ON A.FinalTestInspectorUsrID = G.user_id " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & " " & Environment.NewLine
                If iTestTypeID > 0 Then strSql &= "AND A.Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "ORDER BY A.TD_ID DESC " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                i = dt.Rows.Count

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Seq") = i
                    i = i - 1
                    R1.EndEdit()
                    dt.AcceptChanges()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsCompletedByTechnician(ByVal iDeviceID As Integer, _
                                                ByRef strTechName As String) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim booReturnVal As Boolean = False

            Try
                strSql = "SELECT B.user_fullname as 'Tech', A.RI_Completed  " & Environment.NewLine
                strSql &= "FROM thtcrepair A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers B ON A.Repair_RecUsrID = B.user_id " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & " " & Environment.NewLine
                strSql &= "AND BillCode_ID is not null " & Environment.NewLine
                'strSql &= "AND A.RI_Completed  = 0 " & Environment.NewLine
                strSql &= "ORDER BY RI_ID desc " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Select("RI_Completed = 0").Length > 0 Then
                    booReturnVal = False
                Else
                    For Each R1 In dt.Rows
                        If R1("RI_Completed") = 0 Then
                            If Not IsDBNull(R1("Tech")) Then
                                strTechName = R1("Tech")
                                Exit For
                            End If
                        End If
                    Next R1

                    booReturnVal = True
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function WriteTestResultFailData(ByVal iDeviceID As Integer, _
                                                ByVal iFailMainCategoryID As Integer, _
                                                ByVal iFailID As Integer, _
                                                ByVal iTestTypeID As Integer, _
                                                ByVal iTestResultID As Integer, _
                                                ByVal iUsrID As Integer, _
                                                ByVal iTechUsrID As Integer, _
                                                ByVal strStation As String, _
                                                ByVal dtFailDetails As DataTable, _
                                                Optional ByVal iPalletID As Integer = 0, _
                                                Optional ByVal strPalletNumber As String = "", _
                                                Optional ByVal iPalletQty As Integer = 0, _
                                                Optional ByVal strFailDetails As String = "", _
                                                Optional ByVal iFinalTestUsrID As Integer = 0) As Integer
            Dim strSql As String
            Dim iNextNum As Integer = 0
            Dim i As Integer = 0
            Dim iTestID As Integer = 0
            Dim R1 As DataRow

            Try
                '***************************
                'Buil Fail details string
                '***************************
                For Each R1 In dtFailDetails.Rows
                    If strFailDetails.Trim.Length > 0 Then strFailDetails &= ";"
                    strFailDetails &= R1("Desc")
                Next R1

                '*********************
                'write fail codes
                '*********************
                strSql = "INSERT INTO thtcrepair " & Environment.NewLine
                strSql &= "( MC_ID,  Fail_ID, Fail_RecUsrID, Fail_RecDt, Fail_RecStation, Device_ID, Fail_Details ) " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & iFailMainCategoryID & ", " & iFailID & ", " & iUsrID & ", now(), '" & strStation & "', " & iDeviceID & ", '" & strFailDetails & "' )"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then
                    Throw New Exception("System fail to record the fail code.")
                End If

                '*********************
                'write test result
                '*********************
                i = Me.WriteTestResult(iDeviceID, iTestTypeID, iUsrID, iTechUsrID, iTestResultID, iPalletID, strPalletNumber, iPalletQty, strFailDetails, iFailID, iFinalTestUsrID)
                If i = 0 Then
                    Throw New Exception("System fail write test result.")
                End If

                '*********************
                'write Fail Details
                '*********************
                If dtFailDetails.Rows.Count > 0 Then
                    iTestID = Me.GetTestDataID(iDeviceID, iTestTypeID, iUsrID, iTechUsrID, iTestResultID)
                    If iTestID = 0 Then
                        Throw New Exception("System failed to get test id.")
                    End If

                    For Each R1 In dtFailDetails.Rows
                        Me.WriteTestFailDetails(iTestID, R1("DCode_ID"), iDeviceID)
                    Next R1
                End If

                '*******************************************
                'send all unit in pallet back to Final test
                ' and remove all unit out of box and delete box ID
                '*******************************************
                If iPalletID > 0 Then
                    'un-assign pallet to all unit in the box
                    strSql = "UPDATE tdevice, thtcdata " & Environment.NewLine
                    strSql &= "SET hd_StationEnterDt = now(), thtcdata.hd_Station = 'FINAL', thtcdata.Reject = 1, tdevice.Pallett_ID = null, tdevice.WO_ID_Out = null " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                    strSql &= "AND tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then
                        Throw New Exception("System fail to move all units in this box to FINAL Test workstation.")
                    End If

                    'Disable Box
                    strSql = "UPDATE tpallett SET Pallet_Invalid = 1 " & Environment.NewLine
                    strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then
                        Throw New Exception("System failed to disable box ID.")
                    End If

                    'Remove daily production number
                    strSql = "DELETE FROM tdailyproduct " & Environment.NewLine
                    strSql &= "WHERE Pallett_ID = " & iPalletID & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then
                        Throw New Exception("System failed to remove daily production.")
                    End If

                    'Archieve Excel Report
                    If File.Exists(HTC_PackingListFileLocation & strPalletNumber & ".xls") = True Then
                        If Directory.Exists(HTC_PackingListFileLocation & "OOBA_REJECT\") = False Then
                            Directory.CreateDirectory(HTC_PackingListFileLocation & "OOBA_REJECT\")
                        End If
                        Try
                            File.Move(HTC_PackingListFileLocation & strPalletNumber & ".xls", HTC_PackingListFileLocation & "OOBA_REJECT\" & strPalletNumber & ".xls")
                        Catch
                            'Do nothing if problem occur when moving file.
                            'there is another schedule task to take care of this.
                        End Try
                    End If
                End If

                '*******************************************
                'Push fail unit back to Repair workstation
                '*******************************************
                i = Me.PushUnitToNextWorkingStation(iDeviceID, "REPAIR")
                If i = 0 Then
                    Throw New Exception("System fail to move the failed unit to REPAIR workstation.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dtFailDetails)
            End Try
        End Function

        '******************************************************************
        Public Function GetTestDataID(ByVal iDeviceID As Integer, _
                                      ByVal iTestTypeID As Integer, _
                                      ByVal iUsrID As Integer, _
                                      ByVal iTechUsrID As Integer, _
                                      ByVal iTestResultID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT TD_ID FROM ttestdata " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND TD_UsrID = " & iUsrID & Environment.NewLine
                strSql &= "AND CompletedTechUsrID = " & iTechUsrID & Environment.NewLine
                strSql &= "AND QCResult_ID = " & iTestResultID & Environment.NewLine
                strSql &= "ORDER BY TD_ID DESC;"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function WriteTestFailDetails(ByVal iTestDataID As Integer, _
                                             ByVal iDcodeID As Integer, _
                                             ByVal iDeviceID As Integer) As Integer
            Dim strSql As String

            Try

                strSql = "INSERT INTO ttestdatafaildetails ( TDD_RecDate, TD_ID, DCode_ID, Device_ID " & Environment.NewLine
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "  now() " & Environment.NewLine
                strSql &= ", " & iTestDataID & " " & Environment.NewLine
                strSql &= ", " & iDcodeID & " " & Environment.NewLine
                strSql &= ", " & iDeviceID & " " & Environment.NewLine
                strSql &= " ); "
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function WriteTestResult(ByVal iDeviceID As Integer, _
                                        ByVal iTestTypeID As Integer, _
                                        ByVal iUsrID As Integer, _
                                        ByVal iTechUsrID As Integer, _
                                        ByVal iTestResult As Integer, _
                                        Optional ByVal iPalletID As Integer = 0, _
                                        Optional ByVal strPalletNumber As String = "", _
                                        Optional ByVal iPalletQty As Integer = 0, _
                                        Optional ByVal strFailDetails As String = "", _
                                        Optional ByVal iFailID As Integer = 0, _
                                        Optional ByVal iFinalTestUsrID As Integer = 0) As Integer
            Dim strSql As String
            Dim iNextNum As Integer = 0
            Dim iReject As Integer = 0

            Try
                'check if test type is repair station and record is already existed then exit function
                If iTestTypeID = 7 And Me.IsTestAlreadyExisted(iDeviceID, iTestTypeID, iTestResult) = True Then Return 1

                'only set reject on RF, FINAL and OOBA
                If iTestResult = 2 And (iTestTypeID = 2 Or iTestTypeID = 3 Or iTestTypeID = 4) Then iReject = 1

                'reset flag indicate it belongs to a fail lot
                strSql = "UPDATE thtcdata SET Reject = " & iReject & " WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Me._objDataProc.ExecuteNonQuery(strSql)

                'write test result
                strSql = "SELECT IF(MAX(TD_Sequence) is null, 0, TD_Sequence) as MaxSeq " & Environment.NewLine
                strSql &= "FROM ttestdata  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                iNextNum = Me._objDataProc.GetIntValue(strSql) + 1

                strSql = "INSERT INTO ttestdata (TD_TestDt, TD_UsrID, TD_Sequence, Device_ID, Test_ID, QCResult_ID, TD_FailDetails "
                If iTechUsrID > 0 Then strSql &= ", CompletedTechUsrID "
                If iPalletID > 0 Then strSql &= ", Pallett_ID, Pallet_Name, Pallet_Qty "
                If iFailID > 0 Then strSql &= ", Fail_ID "
                If iFinalTestUsrID > 0 Then strSql &= ", FinalTestInspectorUsrID "

                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "  now() " & Environment.NewLine
                strSql &= ", " & iUsrID & " " & Environment.NewLine
                strSql &= ", " & iNextNum & " " & Environment.NewLine
                strSql &= ", " & iDeviceID & " " & Environment.NewLine
                strSql &= ", " & iTestTypeID & " " & Environment.NewLine
                strSql &= ", " & iTestResult & " " & Environment.NewLine
                strSql &= ", '" & strFailDetails & "' " & Environment.NewLine
                If iTechUsrID > 0 Then strSql &= ", " & iTechUsrID & " " & Environment.NewLine
                If iPalletID > 0 Then strSql &= ", " & iPalletID & ", '" & strPalletNumber & "', " & iPalletQty & Environment.NewLine
                If iFailID > 0 Then strSql &= ", " & iFailID & Environment.NewLine
                If iFinalTestUsrID > 0 Then strSql &= ", " & iFinalTestUsrID & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsTestAlreadyExisted(ByVal iDeviceID As Integer, _
                                             ByVal iTestID As Integer, _
                                             ByVal iTestResult As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Try
                strSql = "select * from ttestdata " & Environment.NewLine
                strSql &= "where device_id = " & iDeviceID & " order by td_id desc "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("test_id") = iTestID And dt.Rows(0)("QCResult_ID") = iTestResult Then booResult = True
                End If
                Return booResult
            Catch ex As Exception
                Throw ex
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function RemoveBillcodeFromTdevicebill(ByVal iDeviceID As Integer, _
                                                      ByVal strBillcodeIDs As String) As Integer
            Dim strSql As String
            Try
                strSql = "DELETE FROM tdevicebill " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= " AND Billcode_ID IN ( " & strBillcodeIDs & " );"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletByName(ByVal strPalletName As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT * FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strPalletName & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetTestFailCodes() As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT lcodesdetail.Dcode_id, concat(Dcode_Sdesc, '-',Dcode_Ldesc) as 'Desc' " & Environment.NewLine
                strSql &= "FROM lcodesdetail " & Environment.NewLine
                strSql &= "WHERE Mcode_Id = 36 and Dcode_Inactive = 0" & Environment.NewLine
                strSql &= "ORDER BY Dcode_Sdesc ASC"
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {0, "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************


#End Region

#Region "Packaging & Shipping"

        '******************************************************************
        Public Function GetHTCModel(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT Model_ID, Model_Desc " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Manuf_ID = 47;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow = True Then
                    dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetHTCOpenShipRMA() As DataTable
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iFilledQty As Integer = 0

            Try
                strSql = "SELECT Distinct tworkorder.WO_ID " & Environment.NewLine
                strSql &= ", Concat(WO_CustWO, '-', Model_Desc) as 'Open RMA'" & Environment.NewLine
                strSql &= ", WO_CustWO as 'RMA', WO_Quantity as 'RMA QTY' " & Environment.NewLine
                strSql &= ", Model_Desc as 'Model', tdevice.Model_ID , tmodel.Model_MotoSku" & Environment.NewLine
                strSql &= ", DATE_FORMAT(now(), '%Y-%m-%d') as Today, DATE_FORMAT(WO_Date, '%Y-%m-%d') as 'ReceiptDate' " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tworkorder.Loc_ID = " & Me.HTC_LOCATION_ID & " " & Environment.NewLine
                'strSql &= "AND tdevice.WO_ID_Out is null " & Environment.NewLine
                strSql &= "AND DiscUnit = 0 " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is null " & Environment.NewLine
                strSql &= "ORDER BY tdevice.WO_ID asc" & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    strSql = "SELECT count(*) as cnt " & Environment.NewLine
                    strSql &= "FROM tdevice  " & Environment.NewLine
                    strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.WO_ID_Out = " & R1("WO_ID") & " " & Environment.NewLine
                    strSql &= "AND Pallett_ReadyToShipFlg = 1 " & Environment.NewLine
                    iFilledQty = Me._objDataProc.GetIntValue(strSql)
                    If R1("RMA QTY") = iFilledQty Then R1.Delete()
                Next R1

                dt1.AcceptChanges()

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetTotalUnitsHasGivenShipRMA(ByVal strShipRMA As String) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & Me.HTC_LOCATION_ID & " " & Environment.NewLine
                strSql &= "AND Pallet_SkuLen = '" & strShipRMA & "'" & Environment.NewLine

                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenPallets(ByVal strGroupChar As String, _
                                       ByVal strShortModelName As String, _
                                       ByVal iModel_ID As Integer, _
                                       ByVal strRMA As String, _
                                       ByVal iShipType As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Pallett_id, tpallett.Model_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as 'Box Name', tsku.Sku_PartNo " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tsku ON tpallett.Model_ID = tsku.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.cust_ID = " & Me.HTC_CUSTOMER_ID.ToString & Environment.NewLine
                strSql &= "AND pallett_name like '" & strGroupChar & strShortModelName & "%' " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "AND tpallett.Model_ID = " & iModel_ID.ToString & Environment.NewLine
                strSql &= "AND Pallet_SkuLen = '" & strRMA.Trim.ToUpper & "'" & Environment.NewLine
                strSql &= "AND Pallet_ShipType = " & iShipType.ToString & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "Order by Pallett_id Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetHTC_TdeviceInfo_InWIP(ByVal strIMEI As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT tdevice.*, hd_RMA, hd_Station " & Environment.NewLine
                strSql &= ", if(thtcdata.DiscUnit = 0, '', (case " & Environment.NewLine
                strSql &= "when thtcdata.ExtraUnit = 1 then 'Extra Unit' " & Environment.NewLine
                strSql &= "when thtcdata.MissingUnit = 1 then 'Missing Unit' " & Environment.NewLine
                strSql &= "when thtcdata.WrongSku = 1 then 'Wrong Sku' " & Environment.NewLine
                strSql &= "when thtcdata.Duplicate = 1 then 'Duplicate IMEI' " & Environment.NewLine
                strSql &= "when thtcdata.LessThan30days then 'Less than 30 unit' " & Environment.NewLine
                strSql &= "else '' " & Environment.NewLine
                strSql &= "end ) ) as 'Discrepancy Reason' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & Me.HTC_LOCATION_ID.ToString & Environment.NewLine
                strSql &= "AND Device_SN = '" & strIMEI & "' " & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or '') " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateDeviceWithPallet(ByVal iDeviceID As Integer, _
                                            ByVal iPallett_ID As Integer, _
                                            ByVal iShiftID As Integer, _
                                            ByVal iUserID As Integer, _
                                            ByVal iWCLocation_ID As Integer, _
                                            ByVal iLine_ID As Integer, _
                                            ByVal iGroup_ID As Integer, _
                                            ByVal iWO_ID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0
            Dim R1 As DataRow
            Dim strWorkDate As String

            Try
                strWorkDate = Generic.GetWorkDate(iShiftID)
                '*******************************************
                'Check if DeviceID and PallettID exists together in daily production
                strSql = "Select Count(*) as cnt from tdailyproduction where device_id = " & iDeviceID.ToString & " and Pallett_ID = " & iPallett_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSql)

                If R1("cnt") = 0 Then
                    'STEP 2: Update tdailyproduction table
                    strSql = "insert into tdailyproduction " & Environment.NewLine
                    strSql += "(DP_Date, User_ID, WCLocation_ID, Line_ID, Group_ID, Device_ID, Pallett_ID) " & Environment.NewLine
                    strSql += "values " & Environment.NewLine
                    strSql += "('" & strWorkDate & "', " & iUserID.ToString.ToCharArray & ", " & iWCLocation_ID.ToString & ", " & iLine_ID.ToString & ", " & iGroup_ID.ToString & ", " & iDeviceID.ToString & ", " & iPallett_ID.ToString & ")"

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then
                        MsgBox("Device could not be added to daily production.")
                    End If
                End If

                'STEP 3:    Update tdevice table
                strSql = "Update tdevice set pallett_id = " & iPallett_ID.ToString & ", WO_ID_Out = " & iWO_ID & " where device_ID = " & iDeviceID.ToString

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function CheckDeviceShipType(ByVal iShipType As Integer, _
                                            ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booMatch As Boolean = False

            Try
                strSql = "SELECT distinct BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDevice_ID & Environment.NewLine
                strSql &= "ORDER BY BillCode_Rule desc " & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("BillCode_Rule") <> iShipType Then
                        Select Case dt.Rows(0)("BillCode_Rule")
                            Case 0
                                MessageBox.Show("This is a REFURBISHED device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Case 1
                                MessageBox.Show("This is a RUR device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        End Select
                    Else
                        booMatch = True
                    End If
                Else
                    MessageBox.Show("This device has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

                Return booMatch
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsRF_FinalTestPassed(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim booRFTest As Boolean = False
            Dim booFinalTest As Boolean = False

            Try
                strSql = "SELECT Test_ID " & Environment.NewLine
                strSql &= "FROM tpretest_data " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    If R1("Test_ID") = 2 Then
                        booRFTest = True
                    ElseIf R1("Test_ID") = 3 Then
                        booFinalTest = True
                    End If
                Next R1

                If booRFTest = True And booFinalTest = True Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function RemoveSNfromPallet(ByVal iPallettID As Integer, _
                                           Optional ByVal iDeviceID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                If iDeviceID > 0 Then
                    'STEP 2: Update tdailyproduction
                    strSql = "Delete from tdailyproduction where device_id = " & iDeviceID.ToString

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then
                        MsgBox("Device was not removed from daily production numbers.")
                    End If

                    'STEP 3: Update tdveice table
                    strSql = "Update tdevice set Pallett_ID = NULL, WO_ID_Out = NULL where pallett_id = " & iPallettID.ToString & " and device_id = " & iDeviceID.ToString & " and device_dateship is null"

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                Else
                    'STEP 1: Get all devices for the pallet
                    strSql = "Select Device_ID from tdevice where pallett_id = " & iPallettID.ToString

                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("No devices found on this pallet or box.")
                    End If

                    'STEP 2: Update tdevice table
                    For Each R1 In dt1.Rows
                        strSql = "Delete from tdailyproduction where device_id = " & R1("Device_ID")

                        i = Me._objDataProc.ExecuteNonQuery(strSql)

                        If i = 0 Then
                            MsgBox("Device (Device_id = " & iDeviceID.ToString & ") was not removed from daily production numbers.")
                        End If
                    Next R1

                    'STEP 3: Update tdevice table
                    strSql = "Update tdevice set Pallett_ID = NULL, WO_ID_Out = NULL where pallett_id = " & iPallettID.ToString

                    i = Me._objDataProc.ExecuteNonQuery(strSql)
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
        Public Function PrintHTCBoxLabel(ByVal iPalletID As Integer, _
                                         Optional ByVal iNumberOfCopies As Integer = 1) As Integer
            Dim strSql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim objRpt As ReportDocument

            Try
                strSql = "SELECT '' as DeviceSNCol1, '' as DeviceSNCol2, '' as DeviceSNCol3, '' as DeviceSNCol4 " & Environment.NewLine
                strSql &= ", Pallett_QTY as Quantity, Model_Desc, tsku.Sku_Desc as 'Sku' " & Environment.NewLine
                strSql &= ", RIGHT(trim(tpallett.Pallet_SkuLen), length(tpallett.Pallet_SkuLen)-3) as RMA " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Carton_ID', tsku.Sku_PartNo as Sku_Part_Num, Pallett_ID " & Environment.NewLine
                strSql &= "FROM tpallett  " & Environment.NewLine
                strSql &= "INNER JOIN tsku on tpallett.Model_ID = tsku.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE pallett_ID = " & iPalletID & " " & Environment.NewLine

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    strSql = "Select Label_IMEI " & Environment.NewLine
                    strSql &= "FROM tdevice  " & Environment.NewLine
                    strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                    strSql &= "WHERE pallett_ID = " & dt1.Rows(0)("Pallett_ID") & " " & Environment.NewLine
                    dt2 = Me._objDataProc.GetDataTable(strSql)

                    If dt2.Rows.Count > 0 Then
                        While i <= (dt2.Rows.Count - 1)
                            R1 = dt1.NewRow
                            If i < dt2.Rows.Count Then R1("DeviceSNCol1") = dt2.Rows(i)("Label_IMEI")
                            i += 1
                            If i < dt2.Rows.Count Then R1("DeviceSNCol2") = dt2.Rows(i)("Label_IMEI")
                            i += 1
                            If i < dt2.Rows.Count Then R1("DeviceSNCol3") = dt2.Rows(i)("Label_IMEI")
                            i += 1
                            If i < dt2.Rows.Count Then R1("DeviceSNCol4") = dt2.Rows(i)("Label_IMEI")
                            i += 1
                            R1("Quantity") = dt1.Rows(0)("Quantity")
                            R1("Model_Desc") = dt1.Rows(0)("Model_Desc")
                            R1("Sku") = dt1.Rows(0)("Sku")
                            R1("RMA") = dt1.Rows(0)("RMA")
                            R1("Carton_ID") = dt1.Rows(0)("Carton_ID")
                            R1("Sku_Part_Num") = dt1.Rows(0)("Sku_Part_Num")
                            R1("Pallett_ID") = dt1.Rows(0)("Pallett_ID")
                            dt1.Rows.Add(R1)
                        End While

                        R1 = dt1.Rows(0)
                        R1.Delete()
                        dt1.AcceptChanges()

                        If Not IsNothing(dt1) Then
                            objRpt = New ReportDocument()

                            With objRpt
                                .Load(ConfigFile.GetBaseReportPath & "HTC Carton Box Label.rpt")
                                .SetDataSource(dt1)
                                .PrintToPrinter(iNumberOfCopies, True, 0, 0)
                            End With
                        End If
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************
        Public Shared Sub CreateShipASNExcelFile(ByVal iCust_ID As Integer, _
                                          ByVal iPallet_ID As Integer, _
                                          ByVal strpalletName As String)
            'Excel Related variables
            Dim objDataProc As DBQuery.DataProc
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = HTC.HTC_PackingListFileLocation
            Dim strFileName As String = ""
            Dim strRptPath As String = ""
            Dim strSql As String = ""
            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strFileName = strpalletName & ".xls"
                strRptPath = strRptDir & strFileName
                '******************************************************************
                'Get the Serial Numbers
                strSql = "SELECT Device_SN, Pallet_ShipType, Label_IMEI " & Environment.NewLine
                strSql += "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                strSql += "WHERE tpallett.pallett_id = " & iPallet_ID.ToString & Environment.NewLine
                strSql &= "ORDER BY Device_sn"

                dt1 = objDataProc.GetDataTable(strSql)
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 1      ' 1 = Portrait ; 2 = landscape

                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Box ID"
                objExcel.Application.Cells(i, 2).Value = "SN"
                objExcel.Application.Cells(i, 3).Value = "IMEI"
                objExcel.Application.Cells(i, 4).Value = "IMEI Barcode"
                objExcel.Application.Cells(i, 5).Value = "Result"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 27
                objSheet.Columns("B:B").ColumnWidth = 21        'Need to change this
                objSheet.Columns("C:C").ColumnWidth = 21        'Need to change this
                objSheet.Columns("D:D").ColumnWidth = 28
                objSheet.Columns("E:E").ColumnWidth = 16        'Need to change this
                '*****************************************
                'Set alignments
                '*****************************************
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
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
                '*****************************************
                'format header
                '*****************************************
                objSheet.Range("A1:E1").Select()
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
                For Each R1 In dt1.Rows
                    objExcel.Application.Cells(i, 1).Value = strpalletName
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("Device_sn"))
                    objExcel.Application.Cells(i, 3).Value = Trim(R1("Label_IMEI"))
                    objExcel.Application.Cells(i, 4).Value = "*" & Trim(R1("Label_IMEI")) & "*"

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                objExcel.Application.Cells(i, 5).Value = "Pass"
                            Case 1  'RUR
                                objExcel.Application.Cells(i, 5).Value = "Fail"
                        End Select
                    End If

                    i += 1
                Next R1

                '*****************************************
                'Write Total Line   
                '*****************************************
                i += 1
                objExcel.Application.Cells(i, 1).Value = "Total Count = " & dt1.Rows.Count
                'objSheet.Range("A1:B1").Select()
                objSheet.Range("A" & i & ":B" & i).Select()
                With objExcel.Selection
                    '.WrapText = True
                    '.HorizontalAlignment = Excel.Constants.xlCenter
                    '.VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                    .Font.Size = 12
                End With

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A1:E" & (dt1.Rows.Count + 1)).Select()
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
                objSheet.Range("D2:D" & (dt1.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With

                '*************************************************
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
                    .Orientation = Excel.XlPageOrientation.xlLandscape
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
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
            Catch ex As Exception
                Throw New Exception("CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                objDataProc = Nothing
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Public Function MovePalletBackToPackagingStation(ByVal strPalletName As String) As Integer
            Dim strSql As String
            Try
                strSql = "UPDATE thtcdata " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON thtcdata.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "SET thtcdata.hd_StationEnterDt = now(), thtcdata.hd_Station = 'PACKAGING' " & Environment.NewLine
                strSql &= "where tpallett.Pallett_Name = '" & strPalletName & "' and tdevice.Device_DateShip is NULL " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsStationTestPassed(ByVal iDeviceID As Integer, _
                                            ByVal iTestTypeID As Integer) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim booResult As Boolean = False

            Try
                strSql = "SELECT Test_Desc2, ttestdata.* " & Environment.NewLine
                strSql &= "FROM ltesttype " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ttestdata ON ltesttype.Test_ID = ttestdata.Test_ID AND Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "WHERE ltesttype.Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "ORDER BY td_id desc; "
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Invalid test type ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsDBNull(dt.Rows(0)("td_id")) Then
                    MessageBox.Show("Device have not been to " & dt.Rows(0)("Test_Desc2") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows(0)("QCResult_ID") = 2 Then
                    MessageBox.Show("Device was failed at " & dt.Rows(0)("Test_Desc2") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintLicensePlate(ByVal strPalletName As String, _
                                          ByVal iModelID As Integer, _
                                          ByVal strPalletType As String, _
                                          ByVal iPalletQty As Integer) As Integer
            Const strReportName As String = "Ship Pallet Label Push.rpt"
            Const iCopies As Integer = 2
            Dim strSql As String
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim objDBRManifest As DBRManifest
            Dim iQty As Integer = 0
            Dim i As Integer = 0
            Dim strModel As String = ""

            Try
                objDBRManifest = New DBRManifest()
                strModel = Generic.GetModelDesc(iModelID)
                '*****************************
                '1: Print License Plate
                '*****************************
                dt = objDBRManifest.GetShipPalletData(strPalletName, iPalletQty, strModel, strPalletType, New String() {"Leader Verification:", "", "Shipper Verification:"})

                If Not IsNothing(dt) Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                        .SetDataSource(dt)
                        .PrintToPrinter(iCopies, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "RUR Reason"

        '******************************************************************
        Public Function GetRURResonOption() As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Dcode_ID, Fail_ID, Repair_ID, Dcode_L2desc  " & Environment.NewLine
                strSql &= "FROM lcodesdetail " & Environment.NewLine
                strSql &= "INNER JOIN lfailcodes ON lcodesdetail.Dcode_Sdesc = lfailcodes.Fail_SDesc " & Environment.NewLine
                strSql &= "INNER JOIN lrepaircodes ON lcodesdetail.Dcode_Ldesc = lrepaircodes.Repair_SDesc " & Environment.NewLine
                strSql &= "WHERE Mcode_ID = 35 AND Dcode_ID <> 2942 " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertRURFailCodeToTdevicecodes(ByVal iDeviceID As Integer, _
                                                        ByVal iDcodeID As Integer) As Integer
            Dim strSql As String

            Try
                'remove existing codes if any. this will prevent from duplicate code
                strSql = "DELETE FROM tdevicecodes WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Me._objDataProc.ExecuteNonQuery(strSql)

                'insert new code
                strSql = "INSERT INTO tdevicecodes (Device_ID, Dcode_ID ) " & Environment.NewLine
                strSql &= "VALUES ( " & iDeviceID & ", " & iDcodeID & ")" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertFailCodeRepCode_ToRepairTable(ByVal iRI_ID As Integer, _
                                                            ByVal iDeviceID As Integer, _
                                                            ByVal iMC_ID As Integer, _
                                                            ByVal iFailID As Integer, _
                                                            ByVal iRepID As Integer, _
                                                            ByVal iIDuser As Integer, _
                                                            ByVal strStation As String, _
                                                            Optional ByVal iIsCompleted As Integer = 0, _
                                                            Optional ByVal iIsRef As Integer = 0, _
                                                            Optional ByVal iBillcodeID As Integer = 0, _
                                                            Optional ByVal iPSPriceID As Integer = 0, _
                                                            Optional ByVal strPartNum As String = "", _
                                                            Optional ByVal strSN As String = "", _
                                                            Optional ByVal strIMEI As String = "") As Integer
            Dim strSql As String
            Dim strFields As String = ""
            Dim strVals As String = ""

            Try
                If iRI_ID = 0 Then
                    strFields = "MC_ID, Fail_ID, Fail_RecUsrID, Fail_RecDt, Fail_RecStation, Device_ID, Repair_ID, Repair_RecUsrID, Repair_RecDt, IsRefurbishment "
                    strVals = iMC_ID & ", " & iFailID & ", " & iIDuser & ", now(), '" & strStation & "', " & iDeviceID & ", " & iRepID & ", " & iIDuser & ", now(), " & iIsRef
                    If iIsCompleted > 0 Then
                        strFields &= ", RI_Completed "
                        strVals &= ", " & iIsCompleted
                        strFields &= ", RI_CompletedDt "
                        strVals &= ", now()"
                        strFields &= ", RI_CompletedUsrID "
                        strVals &= ", " & iIDuser
                    End If
                    If iBillcodeID > 0 Then
                        strFields &= ", BillCode_ID"
                        strVals &= ", " & iBillcodeID
                    End If
                    If iPSPriceID > 0 Then
                        strFields &= ", PSPrice_ID"
                        strVals &= ", " & iPSPriceID
                    End If
                    If strPartNum.Trim.Length > 0 Then
                        strFields &= ", PartNumber"
                        strVals &= ", '" & strPartNum.Trim & "'"
                    End If
                    If strSN.Trim.Length > 0 Then
                        strFields &= ", RI_SN"
                        strVals &= ", '" & strSN.Trim & "'"
                    End If
                    If strIMEI.Trim.Length > 0 Then
                        strFields &= ", RI_MB_IMEI"
                        strVals &= ", '" & strIMEI.Trim & "'"
                    End If
                    strSql = "INSERT INTO thtcrepair ( " & Environment.NewLine
                    strSql &= strFields & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= strVals & Environment.NewLine
                    strSql &= ");"
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE thtcrepair SET Repair_ID = " & iRepID & Environment.NewLine
                    strSql &= ", Repair_RecUsrID = " & iIDuser & Environment.NewLine
                    strSql &= ", Repair_RecDt = now()" & Environment.NewLine
                    If iIsCompleted > 0 Then
                        strSql &= ", RI_CompletedDt = now(), RI_Completed = 1, RI_CompletedUsrID = " & iIDuser & Environment.NewLine
                    End If
                    If iIsRef > 0 Then
                        strSql &= ", IsRefurbishment = 1"
                    End If
                    strSql &= ", BillCode_ID = " & iBillcodeID & Environment.NewLine
                    strSql &= ", PSPrice_ID = " & iPSPriceID & Environment.NewLine
                    strSql &= ", PartNumber = '" & strPartNum.Trim & "'" & Environment.NewLine
                    If strSN.Trim.Length > 0 Then
                        strSql &= ", RI_SN = '" & strSN.Trim & "'"
                    End If
                    If strIMEI.Trim.Length > 0 Then
                        strSql &= ", RI_MB_IMEI ='" & strIMEI.Trim & "'"
                    End If
                    strSql &= "WHERE Device_ID = " & iDeviceID & " AND RI_ID = " & iRI_ID.ToString
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Collect Billcode, Repaircode and Failcode"
        '******************************************************************
        Public Function IsBillcodeExistInHTCRepairTable(ByVal iDeviceID As Integer, _
                                                        ByVal iBillcodeID As Integer, _
                                                        Optional ByVal iFailID As Integer = 0, _
                                                        Optional ByVal iRepID As Integer = 0) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND BillCode_ID  = " & iBillcodeID & Environment.NewLine
                If iFailID > 0 Then
                    strSql &= "AND Fail_ID = " & iFailID & Environment.NewLine
                End If
                If iFailID > 0 Then
                    strSql &= "AND Repair_ID = " & iRepID & Environment.NewLine
                End If

                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function RemoveRepairRecordByUnbill(ByVal iDeviceID As Integer, _
                                                   ByVal iBillcodeID As Integer, _
                                                   ByVal iUsrID As Integer, _
                                                   ByVal strStation As String, _
                                                   Optional ByVal iRI_ID As Integer = 0, _
                                                   Optional ByVal strSN As String = "", _
                                                   Optional ByVal iDOAFlag As Integer = 0) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                i = Me.RecordDeletedFCRC(iUsrID, strStation, , iDeviceID, iBillcodeID)

                If strSN.Trim.Length > 0 Then
                    If iDOAFlag > 0 Then
                        strSql = "UPDATE thtcsnimeimap SET DOA = 1, UnbillUsrID = " & iUsrID & ", UnBillDt = now() " & Environment.NewLine
                        strSql &= "WHERE ConsumeDevice_ID = " & iDeviceID & Environment.NewLine
                        strSql &= "AND SN = '" & strSN & "'" & Environment.NewLine
                        strSql &= "AND UnbillUsrID is null"
                    Else
                        'set part free for next use
                        strSql = "UPDATE thtcsnimeimap SET DOA = 0, UnbillUsrID = NULL, UnBillDt = NULL " & Environment.NewLine
                        strSql &= ", ComsumeDt = NULL, ConsumeTechUsrID = NULL, ConsumeDevice_ID = NULL " & Environment.NewLine
                        strSql &= "WHERE ConsumeDevice_ID = " & iDeviceID & Environment.NewLine
                        strSql &= "AND SN = '" & strSN & "'" & Environment.NewLine
                        strSql &= "AND UnbillUsrID is null"
                    End If
                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                strSql = "DELETE FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND BillCode_ID  = " & iBillcodeID & Environment.NewLine
                If iRI_ID > 0 Then
                    strSql &= "AND RI_ID  = " & iRI_ID & Environment.NewLine
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPSPriceIDPartNumByBillcodeID(ByVal iBillcodeID As Integer, _
                                                        ByVal iModelID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT PSPrice_Number, tpsmap.PSPrice_ID FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND tpsmap.BillCode_ID  = " & iBillcodeID & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetNewSNAndIMEI(ByVal strSN As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * FROM thtcsnimeimap " & Environment.NewLine
                strSql &= "WHERE SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND (ConsumeDevice_ID is null OR ConsumeDevice_ID = 0 or ConsumeDevice_ID = '') " & Environment.NewLine
                strSql &= "AND DOA = 0 " & Environment.NewLine
                strSql &= "ORDER BY SI_ID asc" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetRepairInfoOfBillcodeID(ByVal iDeviceID As Integer, _
                                                  ByVal iBillcodeID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Billcode_ID = " & iBillcodeID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFailMainCategoryIDFromFCRC(ByVal iFailID As Integer, _
                                                      ByVal iRepairID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT DISTINCT MC_ID FROM thtcmcfcrcpnmap  " & Environment.NewLine
                strSql &= "WHERE Fail_ID = " & iFailID & Environment.NewLine
                strSql &= "AND Repair_ID = " & iRepairID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function InsertCosmesticMCFCRCPN_ToThtcrepairTable(ByVal strStation As String, _
                                                               ByVal iMC_ID As Integer, _
                                                               ByVal iFailID As Integer, _
                                                               ByVal iRepID As Integer, _
                                                               ByVal iBillcodeID As Integer, _
                                                               ByVal iModelID As Integer, _
                                                               ByVal iDeviceID As Integer, _
                                                               ByVal iUserID As Integer) As Boolean
            Const LCD_PART_NUMBER As String = "80H00673-01"
            Const MAINBOARD_PART_NUMBER As String = "99HCY090-02"
            Dim strSql As String
            Dim booResult As Boolean = False
            Dim strPartSN As String = ""
            Dim strPartIMEI As String = ""
            Dim dtNewIMEI As DataTable
            Dim dtSelectedFCRC As DataTable
            Dim dtPartNumber As DataTable
            Dim iPSPrice_ID As Integer = 0
            Dim strPSPrice_Number As String = ""
            Dim iIsRef As Integer = 0
            Dim i As Integer = 0

            Try
                If iDeviceID = 0 Or iBillcodeID = 0 Or iModelID = 0 Or iDeviceID = 0 Then
                    Throw New Exception("Can not define Device ID, Billcode ID and Model ID.")
                End If

                If Me.IsBillcodeExistInHTCRepairTable(iDeviceID, iBillcodeID, iFailID, iRepID) > 0 Then
                    Return True
                End If

                '*******************************
                'Get Part Number and part ID
                '*******************************
                dtPartNumber = Me.GetPSPriceIDPartNumByBillcodeID(iBillcodeID, iModelID)
                If dtPartNumber.Rows.Count = 0 Then
                    Throw New Exception("Can't define part ID for selected part. Please contact IT.")
                Else
                    iPSPrice_ID = dtPartNumber.Rows(0)("PSPrice_ID")
                    strPSPrice_Number = dtPartNumber.Rows(0)("PSPrice_Number").ToString.Trim.ToUpper
                End If

                'If Part Number is LCD or Mainboard then collect newSN and newIMEI
                If strPSPrice_Number = LCD_PART_NUMBER Or strPSPrice_Number = MAINBOARD_PART_NUMBER Then
                    strPartSN = InputBox("Scan part serial number:").Trim.ToUpper
                    If strPartSN.Length = 0 Then
                        Throw New Exception("You must enter the SN for this part.")
                    Else
                        dtNewIMEI = Me.GetNewSNAndIMEI(strPartSN.Trim.ToUpper)

                        If dtNewIMEI.Rows.Count = 0 Then
                            Throw New Exception("This SN has not yet input into the system. Please give it back to the part cage.")
                        ElseIf strPSPrice_Number = MAINBOARD_PART_NUMBER AndAlso IsDBNull(dtNewIMEI.Rows(0)("IMEI")) Then
                            Throw New Exception("This SN has does not have IMEI associate with it. Please give it back to the part cage.")
                        ElseIf strPSPrice_Number = MAINBOARD_PART_NUMBER AndAlso dtNewIMEI.Rows(0)("IMEI").ToString.Trim.Length = 0 Then
                            Throw New Exception("This SN has does not have IMEI associate with it. Please give it back to the part cage.")
                        End If

                        strPartSN = dtNewIMEI.Rows(0)("SN")
                        If Not IsDBNull(dtNewIMEI.Rows(0)("IMEI")) Then strPartIMEI = dtNewIMEI.Rows(0)("IMEI")
                        i = Me.SetConsumeInfoToThtcsnIMEImap(iDeviceID, iUserID, dtNewIMEI.Rows(0)("SI_ID"))
                    End If
                End If

                dtSelectedFCRC = Me.GetDeviceRepairDisplayList(iDeviceID)
                If dtSelectedFCRC.Select("BillCode_ID = " & iBillcodeID.ToString).Length > 0 Then
                    'Billcode already exist
                    Return True
                End If

                If iRepID = PSS.Data.Buisness.HTC.HTC_COSMETIC_REPAIRID Then iIsRef = 1

                dtSelectedFCRC = Me.GetDeviceRepairDisplayList(iDeviceID)
                If dtSelectedFCRC.Select("BillCode_ID = " & iBillcodeID.ToString).Length > 0 Then
                    'Billcode already exist
                    Return True
                ElseIf dtSelectedFCRC.Select("MC_ID = " & iMC_ID & " AND Fail_ID = " & iFailID.ToString & " AND Repair_ID is null").Length > 0 Then
                    i = Me.InsertFailCodeRepCode_ToRepairTable(dtSelectedFCRC.Select("MC_ID = " & iMC_ID & " AND Fail_ID = " & iFailID.ToString & " AND Repair_ID is null")(0)("RI_ID"), iDeviceID, iMC_ID, iFailID, iRepID, iUserID, strStation, , iIsRef, iBillcodeID, iPSPrice_ID, strPSPrice_Number, strPartSN, strPartIMEI)
                    booResult = True
                Else
                    'NO Fail select
                    i = Me.InsertFailCodeRepCode_ToRepairTable(0, iDeviceID, iMC_ID, iFailID, iRepID, iUserID, strStation, , iIsRef, iBillcodeID, iPSPrice_ID, strPSPrice_Number, strPartSN, strPartIMEI)
                    booResult = True
                End If
                '*******************************

                Return booResult
            Catch ex As Exception
                InsertCosmesticMCFCRCPN_ToThtcrepairTable = False
                Throw ex
            Finally
                Generic.DisposeDT(dtNewIMEI)
                Generic.DisposeDT(dtSelectedFCRC)
                Generic.DisposeDT(dtPartNumber)
            End Try
        End Function

        '******************************************************************
        Public Function PushPalletToNextWorkingStation(ByVal iPalletID As Integer, _
                                                       ByVal strNextStation As String) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE thtcdata, tdevice SET hd_StationEnterDt = now(), hd_Station = '" & strNextStation & "'" & Environment.NewLine
                strSql &= "WHERE thtcdata.Device_ID = tdevice.Device_ID AND  tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************


#End Region

#Region "Tech Repair"

        '******************************************************************
        Public Function SetCompletedRepair(ByVal iDeviceID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                'strSql = "SELECT *  " & Environment.NewLine
                'strSql &= "FROM thtcrepair " & Environment.NewLine
                'strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                'strSql &= "AND (Repair_ID is null or Repair_ID = 0 or Repair_ID = '') " & Environment.NewLine
                'dt = Me._objDataProc.GetDataTable(strSql)

                'If dt.Rows.Count > 0 Then
                '    Throw New Exception("Please remove all fail code(s) that do not need to repair.")
                'Else
                    strSql = "UPDATE thtcrepair SET RI_Completed = 1, RI_CompletedDt = now(), RI_CompletedUsrID = " & iUserID & " WHERE Repair_ID is not null AND RI_Completed = 0 and Device_ID = " & iDeviceID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                'End If
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCosmeticParts(ByVal iModelID As Integer, _
                                         ByVal iRefRep_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT thtccosmeticparts.BillCode_ID, lbillcodes.BillCode_Desc " & Environment.NewLine
                strSql &= ", thtcrepair.RI_ID, thtcrepair.Fail_ID, thtcrepair.Repair_ID " & Environment.NewLine
                strSql &= "FROM thtccosmeticparts " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON thtccosmeticparts.Billcode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN thtcrepair ON thtccosmeticparts.Billcode_ID = thtcrepair.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE Model_ID  = " & iModelID & Environment.NewLine
                strSql &= "AND CP_Inactive = 0 " & Environment.NewLine
                strSql &= "AND (thtcrepair.Repair_ID is null OR thtcrepair.Repair_ID = " & iRefRep_ID & " ) " & Environment.NewLine
                strSql &= "ORDER BY BillCode_Desc"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function SetConsumeInfoToThtcsnIMEImap(ByVal iDeviceID As Integer, _
                                                      ByVal iIDuser As Integer, _
                                                      ByVal iSI_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE thtcsnimeimap " & Environment.NewLine
                strSql &= "SET ComsumeDt = now(), ConsumeTechUsrID = " & iIDuser & ", ConsumeDevice_ID = " & iDeviceID & Environment.NewLine
                strSql &= "WHERE SI_ID = " & iSI_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsFailCodesExistWithoutRepCode(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Repair_ID is null " & Environment.NewLine
                If Me._objDataProc.ExecuteNonQuery(strSql) > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ReplacePartSN(ByVal iRI_ID As Integer, _
                                      ByVal strNewSN As String, _
                                      ByVal strNewIMEI As String, _
                                      ByVal iDeviceID As Integer, _
                                      ByVal strOldSN As String, _
                                      ByVal iUsrID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                'exchange new SN
                strSql = "UPDATE thtcrepair SET RI_SN = '" & strNewSN & "'" & Environment.NewLine
                If strNewIMEI.Trim.Length > 0 Then
                    strSql &= ", RI_MB_IMEI = '" & strNewIMEI & "'" & Environment.NewLine
                End If
                strSql &= "WHERE RI_ID = " & iRI_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'Set old part as DOA
                strSql = "UPDATE thtcsnimeimap SET DOA = 1, UnbillUsrID = " & iUsrID & ", UnBillDt = now() " & Environment.NewLine
                strSql &= "WHERE ConsumeDevice_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND SN = '" & strOldSN & "'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'Set new part to consumed
                strSql = "UPDATE thtcsnimeimap SET ConsumeDevice_ID = " & iDeviceID & Environment.NewLine
                strSql &= ", ConsumeTechUsrID = " & iUsrID & ", ComsumeDt = now() " & Environment.NewLine
                strSql &= "WHERE ConsumeDevice_ID is null " & Environment.NewLine
                strSql &= "AND SN = '" & strNewSN & "'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Packing List"

        '******************************************************************
        Public Function GetShipToLocation() As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT ShipTo_ID, ShipTo_Name FROM tshipto WHERE ShipTo_ID IN ( 207 ) ORDER BY ShipTo_ID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetWaitingToShipBox(ByVal iShipTo_ID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT Model_Desc as Model, Pallett_Name BoxName,  " & Environment.NewLine
                strSql &= "Pallett_ShipDate as CompletionDate, " & Environment.NewLine
                strSql &= "Pallett_QTY as QTY, " & Environment.NewLine
                strSql &= "(CASE WHEN Pallet_ShipType = 0 THEN 'Refurbished' WHEN Pallet_ShipType = 1 THEN 'RUR' ELSE '' END) AS PalletShipType " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = " & Me.HTC_CUSTOMER_ID & " " & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is not null " & Environment.NewLine
                strSql &= "AND pkslip_ID is null " & Environment.NewLine
                strSql &= "AND tworkorder.ShipTo_ID = " & iShipTo_ID & Environment.NewLine
                strSql &= "ORDER BY tpallett.Pallett_ID " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPalletShipToLocByName(ByVal strPalletName As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tpallett.*, tworkorder.ShipTo_ID FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = '" & strPalletName & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub PrintPackingList(ByVal iPkslip_ID As Integer, ByVal iCopyNumber As Integer)
            Dim dt2 As DataTable
            Dim objRpt As ReportDocument
            Dim strRptName As String = ""
            Dim strReportLoc As String = PSS.Data.ConfigFile.GetBaseReportPath()

            Try
                strRptName = strReportLoc & "HTC Ship Packing Slip Push.rpt"

                dt2 = Me.GetPackingListReportData(Format(iPkslip_ID, "000000").ToString)
                If dt2.Rows.Count > 0 Then
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(strRptName)
                        .SetDataSource(dt2)
                        .PrintToPrinter(iCopyNumber, True, 0, 0)
                    End With
                Else
                    MessageBox.Show("Packing list is empty.", "Repritn Packing List", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt2)
            End Try
        End Sub

        '******************************************************************
        Private Function GetPackingListReportData(ByVal strPkslipID As String) As DataTable
            Dim dr As DataRow
            Dim strSQL As String
            Dim dtPalletInfo As DataTable
            Dim iPalletQty As Integer = 0
            Dim i As Integer = 1

            Try
                strSQL = "SELECT C.ShipTo_Name AS CustName " & Environment.NewLine
                strSQL &= ", C.ShipTo_Address1 AS Address1 " & Environment.NewLine
                strSQL &= ", C.ShipTo_Address2 AS Address2 " & Environment.NewLine
                strSQL &= ", C.ShipTo_City AS City, D.State_Long AS State, C.ShipTo_Zip AS ZIP " & Environment.NewLine
                strSQL &= ", '" & strPkslipID & "' AS SlipNumber " & Environment.NewLine
                strSQL &= ", 0 as Counter " & Environment.NewLine
                strSQL &= ", A.Pallet_SkuLen as RTVNumber " & Environment.NewLine
                strSQL &= ", If (E.Model_Desc is null, '', E.Model_Desc ) AS Model " & Environment.NewLine
                strSQL &= ", If (F.Sku_PartNo is null, '', F.Sku_PartNo ) AS PartNumber " & Environment.NewLine
                strSQL &= ", IF( A.Pallett_QTY is null, 0, A.Pallett_QTY) AS Qty " & Environment.NewLine
                strSQL &= ", (CASE WHEN A.Pallet_ShipType = 0 THEN 'REF' ELSE 'RUR' END) as BoxType " & Environment.NewLine
                strSQL &= ", A.Pallett_Name as PalletName " & Environment.NewLine
                strSQL &= ", A.Pallet_ShipType as PalletShipType " & Environment.NewLine
                strSQL &= ", A.Pallet_SkuLen AS PalletSkuLen " & Environment.NewLine
                strSQL &= ", A.Cust_ID AS CustID " & Environment.NewLine
                strSQL &= ",'AUDITED BY' AS CustomField1 " & Environment.NewLine
                strSQL &= "FROM tpallett A " & Environment.NewLine
                strSQL &= "INNER JOIN tpackingslip B ON A.pkslip_ID = B.pkslip_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tshipto C ON B.ShipTo_ID = C.ShipTo_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lstate D ON C.State_ID = D.State_Id " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tmodel E ON A.Model_ID = E.Model_ID " & Environment.NewLine
                strSQL &= "LEFT OUTER JOIN tsku F ON E.Model_ID = F.Model_ID AND A.Cust_ID = F.Cust_ID " & Environment.NewLine
                strSQL &= "WHERE A.pkslip_ID = " & Convert.ToInt64(strPkslipID) & Environment.NewLine

                dtPalletInfo = Me._objDataProc.GetDataTable(strSQL)

                For Each dr In dtPalletInfo.Rows
                    dr.BeginEdit()
                    If dr("Qty") = 0 Then
                        strSQL = "SELECT count(*) FROM tdevice WHERE Pallett_ID = " & dr("PalletID") & ";"
                        iPalletQty = Me._objDataProc.GetIntValue(strSQL)
                        dr("Qty") = iPalletQty
                    End If
                    dr("Counter") = i
                    dr.EndEdit()
                    dtPalletInfo.AcceptChanges()
                    i += 1
                Next dr

                Return dtPalletInfo
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPalletInfo)
            End Try
        End Function

        '******************************************************************


#End Region

#Region "LCD & Main Board receiving"

        '******************************************************************
        Public Function InsertLCD_MainBoard(ByVal iUsrID As Integer, _
                                            ByVal strSN As String, _
                                            Optional ByVal strIMEI As String = "") As Integer
            Dim strSql As String

            Try
                strSql = "INSERT INTO thtcsnimeimap ( SN " & Environment.NewLine
                If strIMEI.Trim.Length > 0 Then
                    strSql &= ", IMEI " & Environment.NewLine
                End If
                strSql &= ", PartInput_UsrID, PartInputDt ) " & Environment.NewLine
                strSql &= " VALUES " & Environment.NewLine
                strSql &= " ( '" & strSN & "' " & Environment.NewLine
                If strIMEI.Trim.Length > 0 Then
                    strSql &= ", '" & strIMEI & "' " & Environment.NewLine
                End If
                strSql &= ", " & iUsrID & ", now() )" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Report"

#Region "Claim Report"
        '******************************************************************
        Public Function CreateInvoiceReport(ByVal dateBeginWeek As Date, ByVal dateEndWeek As Date) As Integer
            Dim objExcel As Excel.Application ' Excel application
            Dim objBook As Excel.Workbook ' Excel workbook
            Dim objSheet As Excel.Worksheet ' Excel Worksheet
            Dim objDataObject As New DataObject()     'Clipboard related

            Dim dtDevice, dt1, dt3 As DataTable
            Dim R1, R2, R3 As DataRow
            Dim iMaxTotalPartsPerUnit As Integer = 0
            Dim arrRefurbishedParts() As DataRow
            Dim arrFunctionalParts() As DataRow
            Dim arrExpPart() As String = {"76H02223-00M", "77H00527-00M", "77H00203-00M", "77H00470-00M"}
            Dim arrRptHeader() As String = {"Service_Centre", "RMA_No", "Work_Order", "RMA_Source", "Claim_Date", "Receive_Date", "Confirm_Date", "ReStock_ShipDate", "TAT", "Service_Model", _
                                            "Refurbishment", "Warranty", "Part_No", "Product", "Device_SN", "Device_IMEI", "OS_Rev", "Repeat_Return", "Reported_Code", "Reported_Symptom", _
                                            "Failure_code", "Failure_Description", "Repair_Code", "Repair_Description", "Repair_Level", "SN_for_Replacement", "IMEI_for_Replacement"}
            Dim arrRefFailcodeAndRepCode() As String = {"NFF", "NO FAILURE / FAULT FOUND", "C003", "REFURBISHMENT"}
            Dim strHeader As String = ""
            Dim strDeviceData As String = ""
            Dim strPartsData As String = ""
            Dim strData As String = ""
            Dim arrData(,) As String
            Dim iRow As Integer = 1
            Dim i, j, k, iNonCosmeticPartsCnt, iRefIndex, iExpIndex As Integer
            Dim iDcodeID As Integer = 0
            Dim iWeekNo As Integer = 0
            Dim dbPartAmt As Double = 0.0
            Dim iRefQty As Integer = 0
            Dim iRURQty As Integer = 0

            Try
                iWeekNo = Me.GetWeekNum(Format(dateEndWeek, "yyyy-MM-dd"))
                dtDevice = Me.GetInvoiceDeviceInfo(dateBeginWeek, dateEndWeek)
                If dtDevice.Rows.Count = 0 Then Exit Function

                '*************************
                'Create excel workbook
                '*************************
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Add
                objSheet = objBook.Worksheets(1)
                objExcel.Application.Visible = True

                '*************************
                'Create header string
                '*************************
                For i = 0 To arrRptHeader.Length - 1
                    strHeader &= arrRptHeader(i) & vbTab
                Next i
                For i = 1 To 14
                    strHeader &= "Material Used_" & i & vbTab & "Warranty" & i & vbTab & "Material" & i & "_SN" & vbTab
                Next i
                strHeader &= "Engineer_Badge_No" & vbTab & "POP Date" & vbTab

                'HEADER: Copy data to clipboard
                objDataObject.SetData(DataFormats.Text, "")
                objDataObject.SetData(DataFormats.Text, strHeader)
                Clipboard.SetDataObject(objDataObject)
                objSheet.Range("A" & iRow).Select()
                objSheet.Paste()
                '*************************

                For Each R1 In dtDevice.Rows
                    i = 0
                    j = 0
                    iRefIndex = 0
                    iExpIndex = 0
                    iNonCosmeticPartsCnt = 0
                    iDcodeID = 0
                    arrData = Nothing
                    arrRefurbishedParts = Nothing
                    arrFunctionalParts = Nothing
                    ReDim arrData(1, 208)  'max 222

                    dt1 = Me.GetDeviceBilllingInfo(R1("Device_ID"), R1("Pallet_ShipType"))
                    If dt1.Rows.Count = 0 Then
                        MessageBox.Show("This device ID has nothing bill to it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If

                    arrRefurbishedParts = dt1.Select("IsRefurbishment = 1")

                    If Not IsDBNull(dt1.Rows(0)("Dcode_id")) Then iDcodeID = dt1.Rows(0)("Dcode_id")
                    Me.ConstrDeviceDataArray(arrData, R1, iDcodeID)

                    '****************************
                    'construct string of main data
                    '****************************
                    If R1("Pallet_ShipType") = 0 Then
                        iRefQty += 1
                        dt3 = GetDistinctFunctionalFailCodes(R1("Device_ID"))
                        If dt3.Rows.Count = 0 Then
                            'Refurbish only
                            If arrRefurbishedParts.Length > 0 Then
                                arrData(0, 20) = arrRefurbishedParts(0)("Fail_SDesc")
                                arrData(0, 21) = arrRefurbishedParts(0)("Fail_LDesc")
                                arrData(0, 22) = arrRefurbishedParts(0)("Repair_SDesc")
                                arrData(0, 23) = arrRefurbishedParts(0)("Repair_LDesc")
                            Else
                                arrData(0, 20) = arrRefFailcodeAndRepCode(0) '("Fail_SDesc")
                                arrData(0, 21) = arrRefFailcodeAndRepCode(1) '("Fail_LDesc")
                                arrData(0, 22) = arrRefFailcodeAndRepCode(2) '("Repair_SDesc")
                                arrData(0, 23) = arrRefFailcodeAndRepCode(3) '("Repair_LDesc")
                            End If
                            arrData(0, 24) = R1("Repair_Level")
                            arrData(0, 26) = R1("IMEI_for_Replacement")

                            '************************************
                            'add cosmetic parts to 1st line 
                            '************************************
                            For j = 0 To arrRefurbishedParts.Length - 1
                                arrData(0, (27 + (i * 3)) + (j * 3) + 0) = arrRefurbishedParts(j)("PartNumber")
                                arrData(0, (27 + (i * 3)) + (j * 3) + 1) = "Y"
                                If Not IsDBNull(arrRefurbishedParts(j)("RI_SN")) Then arrData(0, (27 + (i * 3)) + (j * 3) + 2) = arrRefurbishedParts(j)("RI_SN")

                                dbPartAmt += arrRefurbishedParts(j)("PSPrice_StndCost") 'MONEY
                            Next j

                            '************************************
                            'expense parts
                            '************************************
                            For k = 0 To arrExpPart.Length - 1
                                arrData(0, (27 + ((i + j) * 3)) + (k * 3) + 0) = arrExpPart(k)
                                arrData(0, (27 + ((i + j) * 3)) + (k * 3) + 1) = "Y"
                            Next k
                            '************************************
                            arrData(0, 69) = R1("Engineer_Badge_No")

                            iRow += 1
                            PopulateDataToExel(objSheet, arrData, iRow)
                        Else
                            For Each R3 In dt3.Rows 'distinct fail codes
                                iNonCosmeticPartsCnt = 0
                                arrFunctionalParts = dt1.Select("IsRefurbishment = 0 AND Fail_ID = " & R3("Fail_ID"))
                                arrData(0, 20) = arrFunctionalParts(0)("Fail_SDesc")
                                arrData(0, 21) = arrFunctionalParts(0)("Fail_LDesc")
                                arrData(0, 22) = arrFunctionalParts(0)("Repair_SDesc")
                                arrData(0, 23) = arrFunctionalParts(0)("Repair_LDesc")
                                arrData(0, 24) = R1("Repair_Level")
                                arrData(0, 26) = R1("IMEI_for_Replacement")
                                For i = 0 To arrFunctionalParts.Length - 1
                                    If arrFunctionalParts(i)("PartNumber").ToString.Trim.Length > 4 Then
                                        arrData(0, 27 + (i * 3) + 0) = arrFunctionalParts(i)("PartNumber")
                                        arrData(0, 27 + (i * 3) + 1) = "Y"
                                        If Not IsDBNull(arrFunctionalParts(i)("RI_SN")) Then arrData(0, 27 + (i * 3) + 2) = arrFunctionalParts(i)("RI_SN")
                                        iNonCosmeticPartsCnt += 1

                                        dbPartAmt += arrFunctionalParts(i)("PSPrice_StndCost") 'MONEY
                                    End If
                                Next i

                                i = iNonCosmeticPartsCnt

                                '************************************
                                'add cosmetic parts 
                                '************************************
                                For j = 0 To arrRefurbishedParts.Length - 1
                                    If iRefIndex = arrRefurbishedParts.Length Then Exit For
                                    If i + j = 14 Then Exit For 'over limit
                                    arrData(0, (27 + (i * 3)) + (j * 3) + 0) = arrRefurbishedParts(iRefIndex)("PartNumber")
                                    arrData(0, (27 + (i * 3)) + (j * 3) + 1) = "Y"
                                    If Not IsDBNull(arrRefurbishedParts(iRefIndex)("RI_SN")) Then arrData(0, (27 + (i * 3)) + (j * 3) + 2) = arrRefurbishedParts(iRefIndex)("RI_SN")

                                    dbPartAmt += arrRefurbishedParts(iRefIndex)("PSPrice_StndCost") 'MONEY
                                    iRefIndex += 1
                                Next j

                                '************************************
                                'expense parts
                                '************************************
                                For k = 0 To arrExpPart.Length - 1
                                    If iExpIndex = arrExpPart.Length Then Exit For
                                    If i + j + k = 14 Then Exit For 'over limit
                                    arrData(0, (27 + ((i + j) * 3)) + (k * 3) + 0) = arrExpPart(iExpIndex)
                                    arrData(0, (27 + ((i + j) * 3)) + (k * 3) + 1) = "Y"
                                    iExpIndex += 1
                                Next k
                                '************************************
                                'End If
                                arrData(0, 69) = R1("Engineer_Badge_No")

                                iRow += 1
                                PopulateDataToExel(objSheet, arrData, iRow)

                                Me.ClearPartSectionOfArray(arrData)
                            Next R3

                            '************************************
                            'Cosmetic parts only
                            '************************************
                            i = 0
                            If (arrRefurbishedParts.Length > 0 And iRefIndex < arrRefurbishedParts.Length) Or iExpIndex < arrExpPart.Length Then
                                If arrRefurbishedParts.Length > 0 Then
                                    arrData(0, 20) = arrRefurbishedParts(0)("Fail_SDesc")
                                    arrData(0, 21) = arrRefurbishedParts(0)("Fail_LDesc")
                                    arrData(0, 22) = arrRefurbishedParts(0)("Repair_SDesc")
                                    arrData(0, 23) = arrRefurbishedParts(0)("Repair_LDesc")
                                Else
                                    arrData(0, 20) = arrRefFailcodeAndRepCode(0) '("Fail_SDesc")
                                    arrData(0, 21) = arrRefFailcodeAndRepCode(1) '("Fail_LDesc")
                                    arrData(0, 22) = arrRefFailcodeAndRepCode(2) '("Repair_SDesc")
                                    arrData(0, 23) = arrRefFailcodeAndRepCode(3) '("Repair_LDesc")
                                End If
                                arrData(0, 24) = R1("Repair_Level")
                                arrData(0, 26) = R1("IMEI_for_Replacement")

                                For j = 0 To arrRefurbishedParts.Length - 1
                                    If iRefIndex = arrRefurbishedParts.Length Then Exit For
                                    If i + j + k = 14 Then Exit For 'over limit
                                    arrData(0, (27 + (i * 3)) + (j * 3) + 0) = arrRefurbishedParts(iRefIndex)("PartNumber")
                                    arrData(0, (27 + (i * 3)) + (j * 3) + 1) = "Y"
                                    If Not IsDBNull(arrRefurbishedParts(iRefIndex)("RI_SN")) Then arrData(0, (27 + (i * 3)) + (j * 3) + 2) = arrRefurbishedParts(iRefIndex)("RI_SN")

                                    dbPartAmt += arrRefurbishedParts(iRefIndex)("PSPrice_StndCost") 'MONEY
                                    iRefIndex += 1
                                Next j

                                '************************************
                                'expense parts
                                '************************************
                                For k = 0 To arrExpPart.Length - 1
                                    If iExpIndex = arrExpPart.Length Then Exit For
                                    If i + j = 14 Then Exit For 'over limit
                                    arrData(0, (27 + ((i + j) * 3)) + (k * 3) + 0) = arrExpPart(iExpIndex)
                                    arrData(0, (27 + ((i + j) * 3)) + (k * 3) + 1) = "Y"
                                    iExpIndex += 1
                                Next k
                                '************************************

                                arrData(0, 69) = R1("Engineer_Badge_No")

                                iRow += 1
                                PopulateDataToExel(objSheet, arrData, iRow)
                                Me.ClearPartSectionOfArray(arrData)
                                j = 0
                            End If
                            '************************************
                        End If
                    Else
                        iRURQty += 1
                        R2 = dt1.Rows(0)
                        arrData(0, 20) = R2("Fail_SDesc")
                        arrData(0, 21) = R2("Fail_LDesc")
                        arrData(0, 22) = R2("Repair_SDesc")
                        arrData(0, 23) = R2("Repair_LDesc")
                        arrData(0, 24) = R1("Repair_Level")
                        arrData(0, 69) = R1("Engineer_Badge_No")

                        iRow += 1
                        PopulateDataToExel(objSheet, arrData, iRow)
                    End If

                    '****************************
                    'reset loop variable
                    '****************************
                    arrRefurbishedParts = Nothing
                    arrFunctionalParts = Nothing
                    Generic.DisposeDT(dt1)
                    Generic.DisposeDT(dt3)
                    R2 = Nothing
                    R3 = Nothing
                    iDcodeID = 0
                    i = 0
                    j = 0
                    k = 0
                    iRefIndex = 0
                    iExpIndex = 0
                    iNonCosmeticPartsCnt = 0
                    '****************************
                Next R1

                'objSheet.name = Format(dbPartAmt, "#,##0.00")
                '********************************************
                'Save excel report
                '********************************************
                objBook.SaveAs("C:\HTC_Invoice_Rpt\" & Format(dateBeginWeek, "yyyyMMdd") & "_" & Format(dateEndWeek, "yyyyMMdd") & "_W" & iWeekNo & "RE" & iRefQty & "RU" & iRURQty & "_" & Format(dbPartAmt, "###0.00").ToString.Replace(".", "_") & ".xls")
                '********************************************

            Catch ex As Exception
                Throw ex
            Finally
                arrRefurbishedParts = Nothing
                arrFunctionalParts = Nothing
                arrRefFailcodeAndRepCode = Nothing
                arrData = Nothing
                arrExpPart = Nothing
                arrRptHeader = Nothing
                R1 = Nothing
                R2 = Nothing
                R3 = Nothing
                Generic.DisposeDT(dtDevice)
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt3)
                '**************************
                'Excel related clean up
                '**************************
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                'Invoke Garbage Collector
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                '**********************************
            End Try
        End Function

        '******************************************************************
        Public Function GetWeekNum(ByVal strDate As String) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT WEEK('" & strDate & "', 6) "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub ClearPartSectionOfArray(ByRef arrData(,) As String)
            Dim i As Integer = 20
            Try
                For i = 20 To 71 - 1
                    arrData(0, i) = Nothing
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Private Function ConstrDeviceDataArray(ByRef arrData(,) As String, _
                                               ByVal R1 As DataRow, _
                                               Optional ByVal iDcodeID As Integer = 0) As String
            Dim strDeviceData As String = ""
            Try
                'Return strDeviceData
                arrData(0, 0) = R1("Service Centre")
                arrData(0, 1) = R1("RMA_No")
                arrData(0, 2) = R1("Work_Order")
                arrData(0, 3) = R1("RMA_Source")
                arrData(0, 4) = R1("Claim Date")
                arrData(0, 5) = R1("Receive_Date")
                arrData(0, 6) = R1("Confirm_Date")
                arrData(0, 7) = R1("ReStock_ShipDate")
                arrData(0, 8) = CalTAT(R1("Receive_Date"), R1("ReStock_ShipDate"))
                arrData(0, 9) = R1("Service_Model")
                arrData(0, 10) = R1("Refurbishment")
                If R1("Pallet_ShipType") = 0 Then
                    arrData(0, 11) = "0"
                Else    'RUR
                    arrData(0, 11) = Me.GetDeviceWrtyType(iDcodeID).ToString
                End If
                arrData(0, 12) = R1("Part_No")
                arrData(0, 13) = R1("Product")
                arrData(0, 14) = R1("Device_SN")
                arrData(0, 15) = R1("Device_IMEI")
                arrData(0, 16) = R1("OS_Rev")
                arrData(0, 17) = R1("Repeat_Return")
                arrData(0, 18) = R1("Reported_code")
                arrData(0, 19) = R1("Reported_Symptom")

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Private Function CalTAT(ByVal dateStart As Date, ByVal dateEnd As Date) As Integer
            Dim iTotalDays As Integer = 0
            Dim iTAT As Integer = -1
            Dim dateCal As Date
            Try
                iTotalDays = DateDiff(DateInterval.Day, dateStart, dateEnd)
                dateCal = dateStart
                While dateCal <= dateEnd
                    If Weekday(dateCal, FirstDayOfWeek.Monday) < 6 Then
                        iTAT += 1
                    End If
                    dateCal = DateAdd(DateInterval.Day, 1, dateCal)
                End While
                Return iTAT
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Sub PopulateDataToExel(ByRef objSheet As Object, _
                                       ByVal arrData(,) As String, _
                                       ByVal iRow As Integer)
            Try
                '****************************
                'Populate data to excel report
                '****************************
                objSheet.Range("A" & iRow.ToString & ":HA" & iRow.ToString).Value = arrData
            Catch ex As Exception
                Throw ex
            Finally
                arrData = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Function GetDeviceWrtyType(ByVal iDCode_ID As Integer) As Integer
            Try
                Select Case iDCode_ID
                    Case 2937, 2938, 2939, 2940
                        Return 2
                    Case 2941
                        Return 3
                    Case 2942
                        Return 1
                End Select
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetInvoiceDeviceInfo(ByVal dateBeginWeek As Date, _
                                             ByVal dateEndWeek As Date) As DataTable
            Dim dt1 As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT 'PSSI' AS 'Service Centre' " & Environment.NewLine
                strSql &= ", thtcdata.hd_RMA AS RMA_No " & Environment.NewLine
                strSql &= ", '' AS Work_Order " & Environment.NewLine
                strSql &= ", '' AS RMA_Source " & Environment.NewLine
                strSql &= ", '' AS 'Claim Date' " & Environment.NewLine
                strSql &= ", DATE_FORMAT(thtcdata.hd_DockRecDt, '%m/%d/%y') AS 'Receive_Date' " & Environment.NewLine
                strSql &= ", '' AS 'Confirm_Date' " & Environment.NewLine
                strSql &= ", DATE_FORMAT(tpackingslip.pkslip_createDt, '%m/%d/%y') AS 'ReStock_ShipDate' " & Environment.NewLine
                strSql &= ", 'Exchange' AS 'Service_Model' " & Environment.NewLine
                strSql &= ", IF(tpallett.Pallet_ShipType = 0, 'Y', 'N') AS 'Refurbishment' " & Environment.NewLine
                strSql &= ", thtcdata.hd_PartNo AS 'Part_No' " & Environment.NewLine
                strSql &= ", lmodeldetailsinfo.MI_CustModelDesc AS 'Product' " & Environment.NewLine
                strSql &= ", tdevice.Device_SN as 'Device_SN' " & Environment.NewLine
                strSql &= ", thtcdata.Label_IMEI AS 'Device_IMEI' " & Environment.NewLine
                strSql &= ", '' AS 'OS_Rev' " & Environment.NewLine
                strSql &= ", IF(thtcdata.PreviousRep_DeviceID IS NOT NULL, 'Y', 'N') AS 'Repeat_Return' " & Environment.NewLine
                strSql &= ", IF(trim(thtcdata.hd_CategoryCode) = '', 'NA', trim(thtcdata.hd_CategoryCode) ) AS 'Reported_Code' " & Environment.NewLine
                strSql &= ", IF(trim(thtcdata.hd_Symptom) = '','NA', trim(thtcdata.hd_Symptom)) AS 'Reported_Symptom' " & Environment.NewLine
                strSql &= ", IF(tpallett.Pallet_ShipType = 0, '2', '1') AS 'Repair_Level' " & Environment.NewLine
                strSql &= ", '' as 'SN_for_Replacement' " & Environment.NewLine
                strSql &= ", IF(thtcdata.hd_IMEI = thtcdata.Label_IMEI, '', thtcdata.hd_IMEI)  AS 'IMEI_for_Replacement' " & Environment.NewLine
                strSql &= ", IF(U1.user_id is null, U2.user_id, U1.user_id) as 'Engineer_Badge_No' " & Environment.NewLine
                strSql &= ", tdevice.Device_ID, tpallett.Pallet_ShipType " & Environment.NewLine
                strSql &= "FROM tpackingslip " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tpackingslip.pkslip_ID = tpallett.pkslip_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lmodeldetailsinfo ON tdevice.Model_ID = lmodeldetailsinfo.Model_ID " & Environment.NewLine
                'strSql &= "INNER JOIN security.tusers ON thtcdata.LastCompleted_TechUsrID = security.tusers.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers U1 ON thtcdata.LastCompleted_TechUsrID = U1.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers U2 ON thtcdata.hd_ProdRecUsrID = U2.user_id " & Environment.NewLine
                strSql &= "WHERE tpackingslip.Cust_ID = " & Me.HTC_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND DATE_FORMAT(tpackingslip.pkslip_createDt, '%Y-%m-%d') BETWEEN '" & Format(dateBeginWeek, "yyyy-MM-dd") & "' AND '" & Format(dateEndWeek, "yyyy-MM-dd") & "'" & Environment.NewLine
                strSql &= "ORDER BY tpallett.Pallet_ShipType ASC "
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceBilllingInfo(ByVal iDeviceID As Integer, ByVal iShipType As Integer) As DataTable
            Dim strSql As String
            Try
                If iShipType = 0 Then   'Refurbished Units
                    strSql = "SELECT lfailcodes.Fail_SDesc, lfailcodes.Fail_LDesc " & Environment.NewLine
                    strSql &= ", lrepaircodes.Repair_SDesc, lrepaircodes.Repair_LDesc " & Environment.NewLine
                    strSql &= ", thtcrepair.* " & Environment.NewLine
                    strSql &= ", 0 as Dcode_id " & Environment.NewLine
                    strSql &= ", PSPrice_StndCost " & Environment.NewLine
                    strSql &= "FROM thtcrepair " & Environment.NewLine
                    strSql &= "INNER JOIN lfailcodes ON thtcrepair.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lrepaircodes ON thtcrepair.Repair_ID = lrepaircodes.Repair_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lpsprice ON thtcrepair.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "ORDER BY thtcrepair.Fail_ID, PSPrice_StndCost DESC " & Environment.NewLine
                Else    'RUR Units
                    strSql = "SELECT lfailcodes.Fail_SDesc, lfailcodes.Fail_LDesc " & Environment.NewLine
                    strSql &= ", lrepaircodes.Repair_SDesc, lrepaircodes.Repair_LDesc " & Environment.NewLine
                    strSql &= ", thtcrepair.* " & Environment.NewLine
                    strSql &= ", lcodesdetail.Dcode_id, lcodesdetail.Dcode_Sdesc, lcodesdetail.Dcode_Ldesc, lcodesdetail.Dcode_L2desc " & Environment.NewLine
                    strSql &= "FROM thtcrepair " & Environment.NewLine
                    strSql &= "INNER JOIN lfailcodes ON thtcrepair.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lrepaircodes ON thtcrepair.Repair_ID = lrepaircodes.Repair_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicecodes ON thtcrepair.Device_ID = tdevicecodes.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lcodesdetail ON tdevicecodes.Dcode_ID = lcodesdetail.Dcode_id" & Environment.NewLine
                    strSql &= "WHERE thtcrepair.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "ORDER BY thtcrepair.Fail_ID " & Environment.NewLine
                End If
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetDistinctFunctionalFailCodes(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT DISTINCT thtcrepair.Fail_ID " & Environment.NewLine
                strSql &= "FROM thtcrepair " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND IsRefurbishment = 0 " & Environment.NewLine
                strSql &= "ORDER BY thtcrepair.Fail_ID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************

#End Region

#Region "UPH Cals"
        '******************************************************************
        Public Sub CreateRef_Incentive_Rpt(ByVal dateStart As Date, _
                                        ByVal dateEnd As Date, _
                                        ByVal iGroupID As Integer, _
                                        ByVal iTestID As Integer, _
                                        ByVal decGoalUPH As Decimal, _
                                        Optional ByVal iUserID As Integer = 0)
            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iRow As Integer = 1
            Dim strDataDesc() As String = {"Ref Units", "Rework Unit", "RF Failed", "PIA Failed", "Final Failed", "OOBA Failed", _
             "Total Hours", "Net UPH", "Goal UPH", "Variance to Goal", "RF Fail %", "PIA Fail %", "Final Fail %", "OOBA Fail %"}
            Dim arrData(,) As Object
            Dim R1 As DataRow
            Dim dt1, dt2 As DataTable
            'Dim dateStart, dateEnd As Date
            Dim iDay As Integer = 0
            Dim iRFTotal As Integer = 0
            Dim iPIATotal As Integer = 0
            Dim iFinalTotal As Integer = 0
            Dim iOOBATotal As Integer = 0
            Dim dateCal As Date = dateStart

            Try
                'dateEnd = DateAdd(DateInterval.Day, -1, Now())
                'dateStart = DateAdd(DateInterval.Day, (Weekday(dateEnd, FirstDayOfWeek.Monday) - 1) * -1, dateEnd)
                'dateEnd = Now()
                'dateStart = Now()

                dt1 = Me.GetEEInfoByWorkDate(iGroupID, iTestID, dateStart, dateEnd, iUserID)

                If dt1.Rows.Count > 0 Then

                    'Prepare report
                    objExcel = New Excel.Application()
                    objExcel.Application.DisplayAlerts = False
                    objWorkbook = objExcel.Workbooks.Add
                    objSheet = objWorkbook.sheets("Sheet1")
                    objExcel.Visible = True

                    objSheet.Name = "Incentive Data"

                    '***********************************
                    'Daily section
                    '***********************************
                    For Each R1 In dt1.Rows
                        iRFTotal = 0
                        iPIATotal = 0
                        iFinalTotal = 0
                        iOOBATotal = 0
                        iRow = 4
                        iDay = 0
                        dateCal = dateStart
                        'set all cell to be auto-fit 
                        objSheet.Cells.Select()
                        objSheet.Cells.Clear()
                        objSheet.Cells.EntireRow.AutoFit()

                        '*******************************
                        objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = R1("Name") & " " & Format(dateStart, "MM/dd") & " - " & Format(dateEnd, "MM/dd")
                        iRow += 3

                        'Headder
                        For i = 0 To strDataDesc.Length - 1
                            objSheet.Range("A" & (iRow + i).ToString & ":A" & (iRow + i).ToString).Value = strDataDesc(i)
                        Next i

                        While dateCal <= dateEnd
                            'For iDay = 0 To iNumOfDayInRpt - 1
                            'redefine array
                            ReDim arrData(strDataDesc.Length + 1, 1)
                            i = 0
                            j = 0

                            If Weekday(dateCal, FirstDayOfWeek.Monday) <> 6 And Weekday(dateCal, FirstDayOfWeek.Monday) <> 7 Then
                                dt2 = Me.GetEE_UPH(R1("TD_UsrID"), R1("EmployeeNo"), dateCal, iTestID, decGoalUPH)

                                arrData(0, 0) = WeekdayName(Weekday(dateCal, FirstDayOfWeek.Sunday), True) & " " & Format(dateCal, "MM/dd")
                                arrData(1, 0) = dt2.Rows(0)("Ref")
                                arrData(2, 0) = dt2.Rows(0)("Rework")
                                arrData(3, 0) = dt2.Rows(0)("RF Fail") * -1
                                arrData(4, 0) = dt2.Rows(0)("PIA Fail") * -1
                                arrData(5, 0) = dt2.Rows(0)("Final Fail") * -1
                                arrData(6, 0) = dt2.Rows(0)("OOBA Fail") * -1
                                'arrData(6, 0) = "=SUM(R[-5]C:R[-1]C)"    'dt2.Rows(0)("Produced")
                                arrData(7, 0) = dt2.Rows(0)("Total Hours")
                                arrData(8, 0) = dt2.Rows(0)("UPH")
                                arrData(9, 0) = dt2.Rows(0)("Goal UPH")
                                arrData(10, 0) = dt2.Rows(0)("Variance to Goal")
                                arrData(11, 0) = dt2.Rows(0)("RF %")
                                arrData(12, 0) = dt2.Rows(0)("PIA %")
                                arrData(13, 0) = dt2.Rows(0)("Final %")
                                arrData(14, 0) = dt2.Rows(0)("OOBA %")
                                iRFTotal += dt2.Rows(0)("RF")
                                iPIATotal += dt2.Rows(0)("PIA")
                                iFinalTotal += dt2.Rows(0)("Final")
                                iOOBATotal += dt2.Rows(0)("OOBA")

                                '*******************************
                                'post data to excel in daily section
                                objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).Value = arrData
                                '*******************************

                                '*******************************
                                'Center horizontal and vertical for data
                                objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                                objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
                                '*******************************
                                'Header
                                With objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString, Chr((65 + 1 + iDay)) & (iRow - 1).ToString).Font
                                    .Name = "Arial"
                                    .FontStyle = "Bold"
                                    .Size = 8
                                    .Underline = True
                                    .ColorIndex = 25
                                End With
                                '*******************************
                                'Data
                                With objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).Font
                                    .Name = "Arial"
                                    .Size = 8
                                End With

                                '*******************************
                                'format
                                '*******************************
                                objSheet.Range(Chr((65 + 1 + iDay)) & (iRow).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + 6 - 1).ToString).NumberFormat = "#,##0"
                                objSheet.Range(Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 4).ToString).NumberFormat = "#,##0.0"
                                objSheet.Range(Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 4 + 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 4 + 4).ToString).NumberFormat = "#,##0.0%"

                                'Draw a heavier border on the left side
                                objExcel.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).Select()
                                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlThick
                                    .ColorIndex = 25
                                End With
                                'Next iDay

                                iDay += 1
                            End If

                            dateCal = DateAdd(DateInterval.Day, 1, dateCal)
                        End While

                        'Total
                        If iDay > 0 Then
                            'redefine array
                            ReDim arrData(strDataDesc.Length + 1, 1)

                            arrData(0, 0) = "Total"
                            arrData(1, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(2, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(3, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(4, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(5, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(6, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(7, 0) = "=SUM(RC[-" & iDay & "]:RC[-1]"
                            arrData(8, 0) = "=R[-7]C/R[-1]C"
                            arrData(9, 0) = decGoalUPH
                            arrData(10, 0) = "=R[-2]C-R[-1]C"
                            If iRFTotal > 0 Then arrData(11, 0) = "=R[-8]C/" & (iRFTotal * -1)
                            If iPIATotal > 0 Then arrData(12, 0) = "=R[-8]C/" & (iPIATotal * -1)
                            If iFinalTotal > 0 Then arrData(13, 0) = "=R[-8]C/" & (iFinalTotal * -1)
                            If iOOBATotal > 0 Then arrData(14, 0) = "=R[-8]C/" & (iOOBATotal * -1)

                            '*******************************
                            'post data to excel in daily section
                            objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).Value = arrData
                            '*******************************

                            '*******************************
                            'Center horizontal and vertical for data
                            objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                            objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
                            '*******************************
                            'Header
                            With objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString, Chr((65 + 1 + iDay)) & (iRow - 1).ToString).Font
                                .Name = "Arial"
                                .FontStyle = "Bold"
                                .Size = 8
                                .Underline = True
                                .ColorIndex = 25
                            End With
                            '*******************************
                            'Data
                            With objSheet.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).Font
                                .Name = "Arial"
                                .Size = 8
                            End With

                            '*******************************
                            'format
                            '*******************************
                            objSheet.Range(Chr((65 + 1 + iDay)) & (iRow).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + 6 - 1).ToString).NumberFormat = "#,##0"
                            objSheet.Range(Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 4).ToString).NumberFormat = "#,##0.0"
                            objSheet.Range(Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 4 + 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + 6 - 1 + 4 + 4).ToString).NumberFormat = "#,##0.0%"

                            'Draw a heavier border on the left side
                            objExcel.Range(Chr((65 + 1 + iDay)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay)) & (iRow + strDataDesc.Length - 1).ToString).Select()
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With

                            ''Draw a heavier border on the left side
                            'objExcel.Range(Chr((65 + 1 + iDay + 1)) & (iRow - 1).ToString & ":" & Chr((65 + 1 + iDay + 1)) & (iRow + strDataDesc.Length - 1).ToString).Select()
                            'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            '    .LineStyle = Excel.XlLineStyle.xlContinuous
                            '    .Weight = Excel.XlBorderWeight.xlThick
                            '    .ColorIndex = 25
                            'End With
                            'Draw a heavier border on the left side of column A
                            objExcel.Range("A" & (iRow - 1).ToString & ":A" & (iRow + strDataDesc.Length - 1).ToString).Select()
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With
                            'Draw a heavier border on the top & bottom edge  
                            objExcel.Range("A" & (iRow - 1).ToString & ":" & Chr(65 + iDay + 1) & (iRow - 1).ToString).Select()
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With
                            'Draw a heavier border on the top & bottom edge 
                            objExcel.Range("A" & (iRow + strDataDesc.Length - 1).ToString & ":" & Chr(65 + iDay + 1) & (iRow + strDataDesc.Length - 1).ToString).Select()
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With

                            'bold variance to goal row
                            With objSheet.Range("A" & (iRow + 9).ToString & ":" & Chr(65 + iDay + 1) & (iRow + 9).ToString).Font
                                .Name = "Arial"
                                .FontStyle = "Bold"
                                .Size = 10
                            End With
                        End If

                        '***********************************
                        'Adjust column widths
                        '***********************************
                        For j = 0 To iDay - 1
                            If j = 0 Then
                                objSheet.Columns(Chr(65 + j) & ":" & Chr(65 + j)).ColumnWidth = 15
                            Else
                                objSheet.Columns(Chr(65 + j) & ":" & Chr(65 + j)).ColumnWidth = 8.29
                            End If
                        Next j

                        '***********************************
                        'Format Title
                        '***********************************
                        If iDay < 4 Then iDay = 4
                        objSheet.Range("A" & (iRow - 3).ToString, Chr(65 + iDay + 1) & (iRow - 3).ToString).Merge()
                        objSheet.Range("A" & (iRow - 3).ToString, Chr(65 + iDay + 1) & (iRow - 3).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                        With objSheet.Range("A" & (iRow - 3).ToString, "A" & (iRow - 3).ToString).Font
                            .Name = "Arial"
                            .FontStyle = "Bold"
                            .Size = 16
                            .Underline = True
                            .ColorIndex = 25
                        End With
                        '***********************************

                        ''set border
                        'objExcel.Range("A" & (iRow).ToString & ":N" & (iRow + i + 1).ToString).Select()
                        'objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                        'objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                        'For j = 0 To xlBI.Length - 1
                        '    With objExcel.Selection.Borders(xlBI(j))
                        '        .LineStyle = Excel.XlLineStyle.xlContinuous
                        '        .Weight = Excel.XlBorderWeight.xlThin
                        '        .ColorIndex = Excel.Constants.xlAutomatic
                        '    End With
                        'Next j

                        '***********************************
                        'Move selection outside the data region 
                        '***********************************
                        objExcel.Range("C1:C1").Select()
                        '***********************************
                        'Set page orientation
                        '***********************************
                        With objSheet.PageSetup
                            .Orientation = Excel.XlPageOrientation.xlLandscape
                            .LeftHeader = "&D&' @'&T"
                            .LeftFooter = "** PSS Confidential **"
                            .TopMargin = -25
                            .RightMargin = -25
                            .LeftMargin = -25
                            .FitToPagesWide = 1
                            .FitToPagesTall = 1
                        End With
                        '***********************************
                        'Set zoom
                        '***********************************
                        objExcel.ActiveWindow.Zoom = 90
                        ''***********************************
                        ''Save Report
                        ''***********************************
                        'If Len(Dir("C:\IncentiveRpt.xls")) > 0 Then
                        '    Kill("C:\IncentiveRpt.xls")
                        'End If
                        'objWorkbook.SaveAs("C:\IncentiveRpt.xls")
                        '***********************************
                        'print Report
                        '***********************************
                        objExcel.ActiveWindow.SelectedSheets.PrintOut(from:=1, To:=1, Copies:=1, Collate:=True)
                        '***********************************
                    Next R1
                End If
            Catch ex As Exception
                Throw ex
            Finally
                xlBI = Nothing
                strDataDesc = Nothing
                arrData = Nothing
                R1 = Nothing

                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objWorkbook) Then
                    objWorkbook.Close(False)
                    Generic.NAR(objWorkbook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    Generic.NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Private Function GetEEInfoByWorkDate(ByVal iGroupID As Integer, _
                                             ByVal iTestID As Integer, _
                                             ByVal dateStart As Date, _
                                             ByVal dateEnd As Date, _
                                             Optional ByVal iUserID As Integer = 0) As DataTable
            Dim strSql As String

            Try
                'EE Information
                strSql = "SELECT DISTINCT A.TD_UsrID, B.user_fullname as 'Name', B.EmployeeNo, E.Group_Desc " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers B ON A.TD_UsrID = B.User_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder D ON C.WO_ID = D.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN lgroups E ON D.group_id = E.group_id " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') between '" & Format(dateStart, "yyyy-MM-dd") & "' AND '" & Format(dateEnd, "yyyy-MM-dd") & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestID & Environment.NewLine
                strSql &= "AND D.group_id = " & iGroupID & Environment.NewLine
                If iUserID > 0 Then strSql &= "AND A.TD_UsrID = " & iUserID & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function GetEE_UPH(ByVal iUsrID As Integer, _
                                   ByVal iEENo As Integer, _
                                   ByVal datePerform As Date, _
                                   ByVal iTestID As Integer, _
                                   Optional ByVal decGoalUPH As Decimal = 0.0) As DataTable
            Dim objLegiant As Legiant
            Dim strSql As String
            Dim dt1, dt2, dt3 As DataTable
            Dim R1, R2 As DataRow
            Dim decHrs As Decimal = 0
            Dim strDate As String = ""
            Try
                objLegiant = New Legiant()

                'Template
                strSql = "SELECT 0 as 'Ref', 0 as Rework, 0 as 'RF Fail', 0 as 'PIA Fail', 0 as 'Final Fail', 0 as 'OOBA Fail' " & Environment.NewLine
                strSql &= ", 0 as 'Produced', 0.0 as 'Total Hours', 0.0 as 'UPH' " & Environment.NewLine
                strSql &= "," & decGoalUPH.ToString & " as 'Goal UPH', 0.0 as 'Variance to Goal' " & Environment.NewLine
                strSql &= ", '0.0' as 'RF %', '0.0' as 'PIA %', '0.0' as 'Final %', '0.0' as 'OOBA %' " & Environment.NewLine
                strSql &= ", 0 as 'RF', 0 as 'PIA', 0 as 'Final', 0 as 'OOBA' " & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                'Ref data
                strSql = "SELECT TD_ID, QCResult_ID " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & Format(datePerform, "yyyy-MM-dd") & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestID & Environment.NewLine
                strSql &= "AND A.TD_UsrID = " & iUsrID & Environment.NewLine
                strSql &= "ORDER BY QCResult_ID " & Environment.NewLine
                dt2 = Me._objDataProc.GetDataTable(strSql)

                'Test data
                strSql = "SELECT TD_ID, Test_ID, QCResult_ID " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & Format(datePerform, "yyyy-MM-dd") & "' " & Environment.NewLine
                strSql &= "AND A.CompletedTechUsrID = " & iUsrID & Environment.NewLine
                strSql &= "ORDER BY A.Test_ID " & Environment.NewLine
                dt3 = Me._objDataProc.GetDataTable(strSql)

                '**************************************
                R1 = dt1.Rows(0)
                R1.BeginEdit()

                decHrs = 0.0
                R1("Ref") = dt2.Select("QCResult_ID = 1").Length
                R1("Rework") = dt2.Select("QCResult_ID = 3").Length

                decHrs = objLegiant.GetLegiantLoginHrs(iEENo, Format(datePerform, "yyyy-MM-dd"))
                If (R1("Ref") + R1("Rework")) > 0 And decHrs < 0.1 Then decHrs = 8.0 'Miss punch
                If decHrs > 4 Then decHrs = decHrs - 0.5 'take out lunch
                R1("Total Hours") = decHrs

                R1("RF Fail") = dt3.Select("Test_ID = 2 AND QCResult_ID = 2").Length
                R1("PIA Fail") = dt3.Select("Test_ID = 6 AND QCResult_ID = 2").Length
                R1("Final Fail") = dt3.Select("Test_ID = 3 AND QCResult_ID = 2").Length
                R1("OOBA Fail") = dt3.Select("Test_ID = 4 AND QCResult_ID = 2").Length
                R1("Produced") = R1("Ref") '- (R1("RF Fail") + R1("PIA Fail") + R1("Final Fail") + R1("OOBA Fail"))
                If R1("Total Hours") > 0 Then R1("UPH") = R1("Produced") / R1("Total Hours")
                R1("Variance to Goal") = R1("UPH") - R1("Goal UPH")
                If dt3.Select("Test_ID = 2").Length > 0 Then R1("RF %") = "=" & CDec(R1("RF Fail")) & "/" & dt3.Select("Test_ID = 2").Length
                If dt3.Select("Test_ID = 6").Length > 0 Then R1("PIA %") = "=" & CDec(R1("PIA Fail")) & "/" & dt3.Select("Test_ID = 6").Length
                If dt3.Select("Test_ID = 3").Length > 0 Then R1("Final %") = "=" & CDec(R1("Final Fail")) & "/" & dt3.Select("Test_ID = 3").Length
                If dt3.Select("Test_ID = 4").Length > 0 Then R1("OOBA %") = "=" & CDec(R1("OOBA Fail")) & "/" & dt3.Select("Test_ID = 4").Length
                R1("RF") = dt3.Select("Test_ID = 2").Length
                R1("PIA") = dt3.Select("Test_ID = 6").Length
                R1("Final") = dt3.Select("Test_ID = 3").Length
                R1("OOBA") = dt3.Select("Test_ID = 4").Length

                R1.EndEdit()
                dt1.AcceptChanges()

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                objLegiant = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt2)
                Generic.DisposeDT(dt3)
            End Try
        End Function

        '******************************************************************
#End Region

#Region "Scrap"

        '******************************************************************
        Public Function CreateScrapCntByEE_Rpt(ByVal StartDate As Date, _
                                               ByVal EndDate As Date, _
                                               ByVal iGroupsID As Integer) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strSql, strData As String
            Dim dtQty, dtEEs, dtParts As DataTable
            Dim R1, R2 As DataRow
            Dim arrObj As Object(,)
            Dim arrParts() As DataRow
            Dim iIndex, iRow, iPartTotal As Integer

            Try
                strSql = ""
                strData = ""
                iIndex = 0
                iRow = 0
                iPartTotal = 0

                strSql = "SELECT user_fullname as 'Name', psprice_number, sum(tscrap_qty) as Qty " & Environment.NewLine
                strSql &= "FROM tscrap " & Environment.NewLine
                strSql &= "INNER JOIN tdevice on tscrap.device_id = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers ON tscrap.empnum = security.tusers.EmployeeNo " & Environment.NewLine
                strSql &= "WHERE tscrap.prod_id = 2 AND tworkorder.Group_ID = " & iGroupsID & " " & Environment.NewLine
                strSql &= "AND date_format(entryDate, '%Y-%m-%d') BETWEEN '" & Format(StartDate, "yyyy-MM-dd") & "' AND '" & Format(EndDate, "yyyy-MM-dd") & "' " & Environment.NewLine
                strSql &= "GROUP BY empnum, psprice_number " & Environment.NewLine
                strSql &= "ORDER BY empnum, psprice_number " & Environment.NewLine
                dtQty = Me._objDataProc.GetDataTable(strSql)

                If dtQty.Rows.Count > 0 Then

                    strSql = "SELECT DISTINCT 0 as 'Index', user_fullname as 'Name' " & Environment.NewLine
                    strSql &= "FROM tscrap " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice on tscrap.device_id = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN security.tusers ON tscrap.empnum = security.tusers.EmployeeNo " & Environment.NewLine
                    strSql &= "WHERE tscrap.prod_id = 2 AND tworkorder.Group_ID = " & iGroupsID & " " & Environment.NewLine
                    strSql &= "AND date_format(entryDate, '%Y-%m-%d') BETWEEN '" & Format(StartDate, "yyyy-MM-dd") & "' AND '" & Format(EndDate, "yyyy-MM-dd") & "' " & Environment.NewLine
                    strSql &= "ORDER BY user_fullname "
                    dtEEs = Me._objDataProc.GetDataTable(strSql)

                    strSql = "SELECT DISTINCT tscrap.psprice_number, PSPrice_Desc " & Environment.NewLine
                    strSql &= "FROM tscrap " & Environment.NewLine
                    strSql &= "INNER JOIN tpsmap ON tscrap.psmap_id = tpsmap.psmap_id " & Environment.NewLine
                    strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                    strSql &= "INNER JOIN tdevice on tscrap.device_id = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN security.tusers ON tscrap.empnum = security.tusers.EmployeeNo " & Environment.NewLine
                    strSql &= "WHERE tscrap.prod_id = 2 AND tworkorder.Group_ID = " & iGroupsID & " " & Environment.NewLine
                    strSql &= "AND date_format(entryDate, '%Y-%m-%d') BETWEEN '" & Format(StartDate, "yyyy-MM-dd") & "' AND '" & Format(EndDate, "yyyy-MM-dd") & "' " & Environment.NewLine
                    strSql &= "ORDER BY tscrap.psprice_number " & Environment.NewLine
                    dtParts = Me._objDataProc.GetDataTable(strSql)

                    ReDim arrObj(dtParts.Rows.Count, dtEEs.Rows.Count + 3)
                    iIndex = 3
                    For Each R1 In dtEEs.Rows
                        R1.BeginEdit()
                        R1("Index") = iIndex
                        R1.EndEdit()
                        arrObj(iRow, iIndex) = R1("Name")
                        iIndex += 1
                        dtEEs.AcceptChanges()
                    Next R1
                    arrObj(iRow, 0) = "Part#"
                    arrObj(iRow, 1) = "Description"
                    arrObj(iRow, 2) = "Part Total"

                    iRow += 1

                    For Each R1 In dtParts.Rows
                        arrParts = dtQty.Select("psprice_number = '" & R1("psprice_number") & "'")

                        For iIndex = 0 To arrParts.Length - 1
                            arrObj(iRow, dtEEs.Select("Name = '" & arrParts(iIndex)("Name") & "'")(0)("Index")) = arrParts(iIndex)("Qty")
                            iPartTotal += arrParts(iIndex)("Qty")
                        Next iIndex
                        arrObj(iRow, 0) = R1("psprice_number")
                        arrObj(iRow, 1) = R1("PSPrice_Desc")
                        arrObj(iRow, 2) = iPartTotal

                        iRow += 1
                        arrParts = Nothing
                        iPartTotal = 0
                    Next R1

                    '*************************
                    'Create excel workbook
                    '*************************
                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Add
                    objSheet = objBook.Worksheets(1)
                    objExcel.Application.Visible = True

                    objSheet.Range("A1" & ":" & Chr((65 + dtEEs.Rows.Count - 1 + 3)) & iRow.ToString).Value = arrObj

                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                Generic.DisposeDT(dtQty)
                Generic.DisposeDT(dtEEs)
                Generic.DisposeDT(dtParts)
                arrObj = Nothing
                arrParts = Nothing
                ''*************************************
                ''Excel clean up
                'If Not IsNothing(objSheet) Then
                '    Generic.NAR(objSheet)
                'End If
                'If Not IsNothing(objBook) Then
                '    objBook.Close(False)
                '    Generic.NAR(objBook)
                'End If
                'If Not IsNothing(objExcel) Then
                '    objExcel.Quit()
                '    Generic.NAR(objExcel)
                'End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Wip detail Rpt"

        '******************************************************************
        Public Function CopyWipReportDataToClipboard() As Integer
            Dim objDataObject As DataObject
            Dim strSql As String
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim strData As String = "RMA" & vbTab & "SN" & vbTab & "IMEI In" & vbTab & "IMEI Out" & vbTab & "Station" & vbTab & "Dock Receipt" & vbTab & "Production Receipt" & vbTab & "RUR" & vbCrLf
            Dim strIsRUR As String = ""
            Try
                strSql = "Select thtcdata.Device_ID, hd_RMA as 'RMA', hd_sn as SN, hd_imei as 'IMEI In', label_IMEI as 'IMEI Out'  " & Environment.NewLine
                strSql &= ", hd_Station as Station, hd_DockRecDt as 'Dock Receipt', hd_DockRecDt as 'Production Receipt'" & Environment.NewLine
                strSql &= ", '' as RUR" & Environment.NewLine
                strSql &= "from thtcdata " & Environment.NewLine
                strSql &= "inner join tdevice on thtcdata.device_id = tdevice.device_id " & Environment.NewLine
                strSql &= "left outer join tpallett on tdevice.pallett_id = tpallett.pallett_id " & Environment.NewLine
                strSql &= "where tpallett.pkslip_ID is null " & Environment.NewLine
                strSql &= "order by hd_DockRecDt "
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    R1.BeginEdit()
                    strData &= R1("RMA") & vbTab & R1("SN") & vbTab & R1("IMEI In") & vbTab & R1("IMEI Out") & vbTab & R1("Station") & vbTab & R1("Dock Receipt") & vbTab & R1("Production Receipt") & vbTab
                    strSql = "select if(max(BillCode_Rule ) is null, 'N', if(max(BillCode_Rule ) = 0, 'N', 'Y') ) as BillType " & Environment.NewLine
                    strSql &= "from tdevicebill  " & Environment.NewLine
                    strSql &= "inner join lbillcodes on tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                    strSql &= "where tdevicebill.Device_ID = " & R1("Device_ID") & " " & Environment.NewLine
                    strIsRUR = Me._objDataProc.GetDataTable(strSql).Rows(0)(0)
                    strData &= strIsRUR & vbCrLf
                    R1("RUR") = strIsRUR
                    R1.BeginEdit()
                    dt1.AcceptChanges()
                Next R1

                'HEADER: Copy data to clipboard
                objDataObject = New DataObject()
                objDataObject.SetData(DataFormats.Text, "")
                objDataObject.SetData(DataFormats.Text, strData)
                Clipboard.SetDataObject(objDataObject)

                MsgBox("Data are now available for you to paste into excel.", MsgBoxStyle.Information, "Information")
            Catch ex As Exception
                Throw ex
            Finally
                objDataObject = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************

#End Region

#Region " Ship detail by IMEI weekending Rpt"

        '******************************************************************
        Public Function CreateInTransitShipRpt(ByVal dateFr As Date, _
                                               ByVal dateTo As Date) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim arrObj As Object(,)
            Dim strHeaders() As String = {"SN", "IMEI", "PSSI Manifest #", "Repair Type", "Ship Date", "RTS #", "PSSI Packing List #", "Dest."}
            Dim iRow, i As Integer

            Try
                strSql = "SELECT hd_sn as SN, Label_IMEI as IMEI " & Environment.NewLine
                strSql &= ", tpallett.Pallett_Name as 'PSSI Manifest #' " & Environment.NewLine
                strSql &= ", tpallett.Pallett_QTY as 'Qty. Shipped' " & Environment.NewLine
                strSql &= ", if(tpallett.Pallet_ShipType = 0, 'REF', 'RUR') as 'Repair Type' " & Environment.NewLine
                strSql &= ", date_format(tpackingslip.pkslip_createDt, '%m/%d/%Y') as 'Ship Date' " & Environment.NewLine
                strSql &= ", hd_RMA as 'RTS #', tpackingslip.pkslip_ID as 'PSSI Packing List #', '' as 'Tracking Info.' " & Environment.NewLine
                strSql &= ", tshipto.ShipTo_Name as 'Dest.' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN thtcdata ON tdevice.Device_ID = thtcdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tpackingslip.ShipTo_ID = tshipto.ShipTo_ID " & Environment.NewLine
                strSql &= "WHERE DATE_FORMAT(tpackingslip.pkslip_createDt, '%Y-%m-%d') BETWEEN '" & Format(dateFr, "yyyy-MM-dd") & "' AND '" & Format(dateTo, "yyyy-MM-dd") & "' " & Environment.NewLine
                strSql &= "AND tpackingslip.cust_ID = " & HTC.HTC_CUSTOMER_ID & Environment.NewLine
                strSql &= "ORDER BY pkslip_createDt "
                dt1 = Me._objDataProc.GetDataTable(strSql)

                'Generic.CreateExelReport(dt1)

                If dt1.Rows.Count > 0 Then
                    '*************************
                    'Create excel workbook
                    '*************************
                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Add
                    objSheet = objBook.Worksheets(1)
                    'objSheet.name = "RTS Summary Report"
                    objExcel.Application.Visible = True
                    objSheet.Columns(2).Select()
                    objExcel.Selection.NumberFormat = "@"

                    iRow = 1
                    i = 0
                    ReDim arrObj(dt1.Rows.Count + 1, strHeaders.Length)

                    For i = 0 To strHeaders.Length - 1
                        arrObj(0, i) = strHeaders(i)
                    Next i

                    i = 1
                    For Each R1 In dt1.Rows
                        arrObj(i, 0) = R1("SN")
                        arrObj(i, 1) = R1("IMEI")
                        arrObj(i, 2) = R1("PSSI Manifest #")
                        arrObj(i, 3) = R1("Repair Type")
                        arrObj(i, 4) = R1("Ship Date")
                        arrObj(i, 5) = R1("RTS #")
                        arrObj(i, 6) = R1("PSSI Packing List #")
                        arrObj(i, 7) = R1("Dest.")

                        i += 1
                    Next R1

                    objSheet.Range("A1:" & Chr(65 + strHeaders.Length) & i.ToString).Value = arrObj
                    'Center horizontal and vertical 
                    objSheet.Range("A1", Chr(65 + strHeaders.Length) & i.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A1", Chr(65 + strHeaders.Length) & i.ToString).VerticalAlignment = Excel.Constants.xlBottom
                    With objSheet.Range("A1", Chr(65 + strHeaders.Length) & 1.ToString).Font
                        '.Name = "Arial"
                        .FontStyle = "Bold"
                        .ColorIndex = 25
                    End With
                    '************************************************
                    'set all cell to be auto-fit 
                    objSheet.Cells.Select()
                    objSheet.Cells.EntireColumn.AutoFit()
                    'objSheet.Cells.EntireRow.AutoFit()
                    ''*************************************************

                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Receving & Shipping By RMA Rpt"

        '******************************************************************
        Public Function RecevingAndShippingByRMARpt() As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strHeaders() As String = {"RTS #", "Qty. Received", "Qty. Shipped", "Qty. Wip", "Repair Type", "Date", "PSSI Manifest #", "PSSI Packing List #", "Tracking #", "Dest.", "TAT"}
            Dim strSql, strRecQtyTotal, strShipQtyTotal, strWipQtyTotal As String
            Dim dtRMA, dtShipBox As DataTable
            Dim R1 As DataRow
            Dim arrObj As Object(,)
            Dim arrShipBox() As DataRow
            Dim iRow, i As Integer

            Try
                strSql = ""
                strRecQtyTotal = ""
                strShipQtyTotal = ""
                strWipQtyTotal = ""
                iRow = 1
                i = 0
                strRecQtyTotal = "="
                strShipQtyTotal = "="
                strWipQtyTotal = "="

                strSql = "SELECT WO_ID, WO_CustWo as 'RTS #', WO_Quantity as 'Qty. Received' " & Environment.NewLine
                strSql &= ", DATE_FORMAT(WO_DateDock, '%m/%d/%Y') as 'Date' " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE tworkorder.Loc_ID = " & HTC.HTC_LOCATION_ID & " " & Environment.NewLine
                strSql &= "AND WO_DateDock is not null " & Environment.NewLine
                strSql &= "ORDER BY WO_DateDock ASC"
                dtRMA = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT WO_ID_Out " & Environment.NewLine
                strSql &= ", if(tpallett.Pallet_ShipType is null, '', if(tpallett.Pallet_ShipType = 0, 'REF', 'RUR')) as 'Repair Type' " & Environment.NewLine
                strSql &= ", if(tpackingslip.pkslip_createDt is null, '', tpackingslip.pkslip_createDt ) as 'Date' " & Environment.NewLine
                strSql &= ", if(tpallett.Pallett_Name is null, '', tpallett.Pallett_Name ) as 'PSSI Manifest #'" & Environment.NewLine
                strSql &= ", if(tpackingslip.pkslip_ID is null, '', tpackingslip.pkslip_ID ) as 'PSSI Packing List #'" & Environment.NewLine
                strSql &= ", if(tshipto.ShipTo_Name is null, '', tshipto.ShipTo_Name) as 'Dest.' " & Environment.NewLine
                strSql &= ", 'PSSI TRUCK' as 'Tracking #' " & Environment.NewLine
                strSql &= ", count(*) as 'Qty. Shipped' " & Environment.NewLine
                strSql &= ", tpallett.Pallett_QTY " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tshipto ON tpackingslip.Shipto_ID = tshipto.Shipto_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & HTC.HTC_LOCATION_ID & " " & Environment.NewLine
                strSql &= "AND tdevice.WO_ID_Out is not null " & Environment.NewLine
                strSql &= "AND tdevice.Pallett_ID is not null " & Environment.NewLine
                strSql &= "AND tpallett.pkslip_ID is not null " & Environment.NewLine
                strSql &= "Group By tpallett.pallett_ID "

                dtShipBox = Me._objDataProc.GetDataTable(strSql)

                If dtRMA.Rows.Count > 0 Then
                    '*************************
                    'Create excel workbook
                    '*************************
                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Add
                    objSheet = objBook.Worksheets(2)
                    Me.CreatePssHolildaysSheet(objSheet)
                    objSheet = objBook.Worksheets(1)
                    objSheet.name = "RTS Summary Report"
                    objExcel.Application.Visible = True


                    '*******************************
                    'Title
                    '*******************************
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = DashBoardRpt.GetDateTimeStamp
                    iRow += 1
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "PSSI Inventory and RTS Detail Report"
                    'Center horizontal and vertical 
                    objSheet.Range("A" & (iRow - 1).ToString, Chr(65 + strHeaders.Length) & iRow.ToString).HorizontalAlignment = Excel.Constants.xlLeft
                    objSheet.Range("A" & (iRow - 1).ToString, Chr(65 + strHeaders.Length) & iRow.ToString).VerticalAlignment = Excel.Constants.xlBottom
                    objSheet.Range("A" & (iRow).ToString, Chr(65 + strHeaders.Length) & iRow.ToString).Merge()
                    iRow += 3

                    '*******************************
                    'Header
                    '*******************************
                    ReDim arrObj(1, strHeaders.Length)
                    For i = 0 To strHeaders.Length - 1
                        arrObj(0, i) = strHeaders(i)
                    Next i
                    objSheet.Range("A" & iRow.ToString & ":" & Chr(65 + strHeaders.Length) & iRow.ToString).Value = arrObj
                    'Center horizontal and vertical 
                    objSheet.Range("A" & (iRow).ToString, Chr(65 + strHeaders.Length) & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A" & (iRow).ToString, Chr(65 + strHeaders.Length) & iRow.ToString).VerticalAlignment = Excel.Constants.xlBottom
                    'Set wrap text
                    objSheet.Range("A" & (iRow).ToString, Chr((65 + strHeaders.Length)) & iRow.ToString).WrapText = True
                    With objSheet.Range("A" & iRow.ToString, Chr(65 + strHeaders.Length) & iRow.ToString).Font
                        '.Name = "Arial"
                        .FontStyle = "Bold"
                        '.ColorIndex = 9
                    End With
                    iRow += 1
                    '*******************************

                    For Each R1 In dtRMA.Rows
                        arrShipBox = dtShipBox.Select("WO_ID_Out = " & R1("WO_ID") & " AND [PSSI Packing List #] <> ''")
                        i = 0
                        ReDim arrObj(arrShipBox.Length + 4, strHeaders.Length)

                        arrObj(i, 0) = R1("RTS #")
                        arrObj(i, 1) = R1("Qty. Received")
                        arrObj(i, 5) = R1("Date")

                        For i = 0 To arrShipBox.Length - 1
                            arrObj(i + 1, 0) = R1("RTS #")
                            arrObj(i + 1, 2) = arrShipBox(i)("Qty. Shipped")
                            arrObj(i + 1, 4) = arrShipBox(i)("Repair Type")
                            arrObj(i + 1, 5) = arrShipBox(i)("Date")
                            arrObj(i + 1, 6) = arrShipBox(i)("PSSI Manifest #")
                            arrObj(i + 1, 7) = arrShipBox(i)("PSSI Packing List #")
                            arrObj(i + 1, 8) = arrShipBox(i)("Tracking #")
                            arrObj(i + 1, 9) = arrShipBox(i)("Dest.")
                            arrObj(i + 1, 10) = Me.NetWorkDay(R1("Date"), arrShipBox(i)("Date"))
                        Next i

                        arrObj(i + 2, 0) = "Total"
                        arrObj(i + 2, 1) = "=SUM(R[-" & i + 2 & "]C:R[-1]C)"
                        arrObj(i + 2, 2) = "=SUM(R[-" & i + 2 & "]C:R[-1]C)"
                        arrObj(i + 2, 3) = "=RC[-2]-RC[-1]"

                        objSheet.Range("A" & iRow.ToString & ":" & Chr(65 + strHeaders.Length) & (iRow + i + 2).ToString).Value = arrObj

                        'Center horizontal and vertical 
                        objSheet.Range("A" & (iRow).ToString, Chr(65 + strHeaders.Length) & (iRow + i + 2).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                        objSheet.Range("A" & (iRow).ToString, Chr(65 + strHeaders.Length) & (iRow + i + 2).ToString).VerticalAlignment = Excel.Constants.xlBottom
                        objSheet.Range("G" & (iRow).ToString, "G" & (iRow + i + 2).ToString).HorizontalAlignment = Excel.Constants.xlLeft

                        'bold total
                        With objSheet.Range("A" & (iRow + i + 2).ToString, Chr(65 + strHeaders.Length) & (iRow + i + 2).ToString).Font
                            '.Name = "Arial"
                            .FontStyle = "Bold"
                            '.ColorIndex = 9
                        End With

                        'Draw a heavier border on the right side for cost center line
                        objExcel.Range("A" & (iRow).ToString & ":" & Chr((65 + strHeaders.Length - 1)) & (iRow + i + 3).ToString).Select()
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With

                        'Draw a heavier border on Total
                        objExcel.Range("B" & (iRow + i + 2).ToString & ":D" & (iRow + i + 2).ToString).Select()
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With

                        'Draw a heavier to slit report
                        objExcel.Range("F" & iRow.ToString & ":F" & (iRow + i + 3).ToString).Select()
                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With

                        strRecQtyTotal &= "+B" & iRow + i + 2
                        strShipQtyTotal &= "+C" & iRow + i + 2
                        strWipQtyTotal &= "+D" & iRow + i + 2

                        iRow += i + 2 + 2
                    Next R1

                    'Draw a heavier border on the right side for cost center line
                    objExcel.Range("A" & (iRow).ToString & ":" & Chr((65 + strHeaders.Length - 1)) & (iRow).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    objSheet.Range("A" & iRow.ToString & ":A" & (iRow).ToString).Value = "Total"
                    objSheet.Range("B" & iRow.ToString & ":B" & (iRow).ToString).Value = strRecQtyTotal
                    objSheet.Range("C" & iRow.ToString & ":C" & (iRow).ToString).Value = strShipQtyTotal
                    objSheet.Range("D" & iRow.ToString & ":D" & (iRow).ToString).Value = strWipQtyTotal

                    'bold grand total
                    With objSheet.Range("A" & iRow.ToString, Chr(65 + strHeaders.Length) & iRow.ToString).Font
                        '.Name = "Arial"
                        .FontStyle = "Bold"
                        '.ColorIndex = 9
                    End With
                    'Center horizontal and vertical of grand total
                    objSheet.Range("A" & iRow.ToString, Chr(65 + strHeaders.Length) & iRow.ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A" & iRow.ToString, Chr(65 + strHeaders.Length) & iRow.ToString).VerticalAlignment = Excel.Constants.xlBottom

                    '************************************************
                    'set all cell to be auto-fit 
                    objSheet.Cells.Select()
                    objSheet.Cells.EntireColumn.AutoFit()
                    'objSheet.Cells.EntireRow.AutoFit()
                    ''*************************************************
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dtRMA)
                Generic.DisposeDT(dtShipBox)
                arrObj = Nothing
                strHeaders = Nothing
                arrShipBox = Nothing
                ''*************************************
                ''Excel clean up
                'If Not IsNothing(objSheet) Then
                '    Generic.NAR(objSheet)
                'End If
                'If Not IsNothing(objBook) Then
                '    objBook.Close(False)
                '    Generic.NAR(objBook)
                'End If
                'If Not IsNothing(objExcel) Then
                '    objExcel.Quit()
                '    Generic.NAR(objExcel)
                'End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Private Sub CreatePssHolildaysSheet(ByRef objSheet As Object)
            Dim strSql As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim arrObj As Object(,)
            Dim iYear As Integer = 0
            Dim i As Integer = 0

            Try
                strSql = "select * from lpssholidays where Holiday_Year in ( year(now()), year(now()) - 1 ) order by Holiday_Date asc"
                dt = Me._objDataProc.GetDataTable(strSql)

                ReDim arrObj(dt.Rows.Count + 4, 3)

                arrObj(0, 0) = "Holidays to be deducted from TAT"
                arrObj(1, 2) = "Holidays"

                For Each R1 In dt.Rows
                    If i <> 0 And iYear <> R1("Holiday_Year") Then i += 1

                    If iYear <> R1("Holiday_Year") Then arrObj(i + 3, 0) = R1("Holiday_Year")
                    arrObj(i + 3, 1) = R1("Holiday_Desc")
                    arrObj(i + 3, 2) = R1("Holiday_Date")

                    i += 1
                    iYear = R1("Holiday_Year")
                Next R1

                objSheet.name = "Holidays"
                objSheet.Range("A1:C" & (dt.Rows.Count + 4).ToString).Value = arrObj
                objSheet.Range("A1:C1").Merge()
                With objSheet.Range("A2:C2").Font
                    .FontStyle = "Bold"
                End With
                With objSheet.Range("A1:A" & (dt.Rows.Count + 4).ToString).Font
                    .FontStyle = "Bold"
                End With

            Catch ex As Exception
                Throw ex
            Finally
                arrObj = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Function NetWorkDay(ByVal dateStart As Date, ByVal dateEnd As Date) As Integer
            Dim dateCal As Date
            Dim iTotalDay As Integer = 0

            Try
                dateCal = dateStart

                While dateCal <= dateEnd

                    If Weekday(dateCal, FirstDayOfWeek.Monday) < 6 AndAlso Me.IsPSSHoliday(dateCal) = False Then
                        iTotalDay += 1
                    End If

                    dateCal = DateAdd(DateInterval.Day, 1, dateCal)
                End While

                Return iTotalDay
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function IsPSSHoliday(ByVal strDate As Date) As Boolean
            Dim strSql As String

            Try
                strSql = "select count(*) as cnt from lpssholidays where Holiday_Date  = '" & Format(strDate, "yyyy-MM-dd") & "'"
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region


#End Region

#Region "Search"

            '******************************************************************
        Public Function GetSearchData(ByVal strSearchBy As String, ByVal strSearchCriteria As String) As DataSet
            Dim strSql As String
            Dim ds As DataSet
            Dim dt, dt1 As DataTable
            Dim R1 As DataRow
            Dim iCounter As Integer = 1
            Dim objNewTech As NewTech

            Try
                objNewTech = New NewTech()
                ds = New DataSet()

                strSql = "SELECT A.Device_ID, 0 as 'Counter', A.hd_SN as SN, A.hd_IMEI as 'IMEI In', A.Label_IMEI as 'IMEI Out' " & Environment.NewLine
                strSql &= ", A.hd_PartNo as 'P/N' " & Environment.NewLine
                strSql &= ", C.Model_Desc as 'Model' " & Environment.NewLine
                strSql &= ", A.hd_Station  as 'Station' " & Environment.NewLine
                strSql &= ", E.WO_CustWo as 'Workorder In' " & Environment.NewLine
                strSql &= ", IF(F.WO_CustWO is null, '', F.WO_CustWO) as 'Workorder Out'  " & Environment.NewLine
                strSql &= ", IF(G.Pallett_Name is null, '', G.Pallett_Name ) as 'Box Name' " & Environment.NewLine
                strSql &= ", IF(H.pkslip_ID is null, '', H.pkslip_ID ) as 'Packing List ID' " & Environment.NewLine
                strSql &= ", A.hd_Symptom AS 'Symtom' " & Environment.NewLine
                strSql &= ", A.hd_DockRecDt as 'Dock Receipt Date' " & Environment.NewLine
                strSql &= ", IF(I.User_Fullname is null, '', I.User_Fullname ) as 'Dock Receiver' " & Environment.NewLine
                strSql &= ", IF(A.hd_ProdRecDt is null, '', A.hd_ProdRecDt ) as 'Production Receipt Date' " & Environment.NewLine
                strSql &= ", IF(J.User_Fullname is null, '', J.User_Fullname ) as 'Production Receiver' " & Environment.NewLine
                strSql &= ", IF(G.Pallett_ShipDate is null, '', G.Pallett_ShipDate ) as 'Production Completed Date' " & Environment.NewLine
                strSql &= ", IF(H.pkslip_createDt is null, '', H.pkslip_createDt ) as 'Packing Date'"
                strSql &= ", IF(A.DiscUnit = 1, 'YES', 'NO' ) as 'Discrepancy'"
                strSql &= ", IF(A.ExtraUnit  = 1, 'Extra Unit', IF(A.MissingUnit  = 1,  'Missing Unit', IF(A.WrongSku = 1,  'Wrong Sku', IF(A.Duplicate = 1, 'Duplicate', IF(A.LessThan30days = 1, 'Less Than 30 days', ''))))) as 'Discrepancy Reason' " & Environment.NewLine
                strSql &= "FROM thtcdata A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel C ON B.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcellopt D ON A.Device_ID = D.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tworkorder E ON B.WO_ID =  E.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tworkorder F ON B.WO_ID_Out = F.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett G ON B.Pallett_ID = G.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpackingslip H ON G.pkslip_ID = H.pkslip_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers I ON A.hd_DockRecUsrID  = I.User_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers J ON A.hd_ProdRecUsrID = J.User_ID " & Environment.NewLine
                If strSearchBy = "Serial Number" Then
                    strSql &= "WHERE A.hd_sn like '" & strSearchCriteria & "' " & Environment.NewLine
                ElseIf strSearchBy = "Work Order" Then
                    strSql &= "WHERE A.hd_RMA like '" & strSearchCriteria & "' " & Environment.NewLine
                End If

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Counter") = iCounter
                    iCounter += 1
                    R1.EndEdit()

                    If dt.Rows.Count <= 5 Then
                        dt1 = Me.GetTestStationHistory(R1("Device_ID"), )
                        dt1.TableName = R1("Device_ID")
                        dt1.AcceptChanges()
                        ds.Tables.Add(dt1)
                        ds.AcceptChanges()
                        'Generic.DisposeDT(dt1)
                        'dt1 = Nothing

                        dt1 = objNewTech.GetBillingSelectionInformation(R1("Device_ID"), Me.HTC_CUSTOMER_ID)
                        dt1.TableName = "Billing_" & R1("Device_ID").ToString
                        dt1.AcceptChanges()
                        ds.Tables.Add(dt1)
                        ds.AcceptChanges()
                    End If
                Next R1

                dt.TableName = "SearchData"
                dt.AcceptChanges()

                ds.Tables.Add(dt)
                ds.AcceptChanges()
                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(ds) Then
                    ds.Dispose()
                    ds = Nothing
                End If
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt1)
                R1 = Nothing
                objNewTech = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetPartSearchData(ByVal strSearchCriteria As String, _
                                          ByVal iSearchBy As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.SN as 'Part SN' " & Environment.NewLine
                strSql &= ", IF(A.IMEI is null, '', A.IMEI) as 'Part IMEI' " & Environment.NewLine
                strSql &= ", Date_Format(PartInputDt, '%m/%d/%y %h:%i %p' ) as 'Receipt Date' " & Environment.NewLine
                strSql &= ", C.User_fullname as 'Receiver' " & Environment.NewLine
                strSql &= ", IF(A.ComsumeDt is null, '', Date_Format(A.ComsumeDt, '%m/%d/%y %h:%i %p' ) ) as 'Bill Date' " & Environment.NewLine
                strSql &= ", IF(D.User_Fullname is null, '', D.User_Fullname) as 'Biller' " & Environment.NewLine
                strSql &= ", IF(B.hd_sn is null, '', B.hd_sn) as 'Device SN' " & Environment.NewLine
                strSql &= ", IF(B.hd_IMEI is null, '', B.hd_IMEI ) as 'Device IMEI In' " & Environment.NewLine
                strSql &= ", IF(B.Label_IMEI is null, '', B.Label_IMEI ) as 'Device IMEI Out' " & Environment.NewLine
                strSql &= ", IF(A.DOA = 0, 'No', 'Yes') as 'DOA' " & Environment.NewLine
                strSql &= ", IF(A.UnBillDt is null, '', Date_Format(A.UnBillDt, '%m/%d/%y %h:%i %p' ) ) as 'DOA Date' " & Environment.NewLine
                strSql &= ", IF(E.User_Fullname is null, '', E.User_Fullname ) as 'DOA By' " & Environment.NewLine
                strSql &= "FROM thtcsnimeimap A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN thtcdata B ON A.ConsumeDevice_ID = B.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers C ON A.PartInput_UsrID = C.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers D ON A.ConsumeTechUsrID = D.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers E ON A.UnbillUsrID = E.user_id " & Environment.NewLine
                If iSearchBy = 0 Then   'SN
                    strSql &= "WHERE A.SN like '" & strSearchCriteria & "' " & Environment.NewLine
                ElseIf iSearchBy = 1 Then   'IMEI
                    strSql &= "WHERE A.IMEI like '" & strSearchCriteria & "' " & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Productiviy Tracking"

        '******************************************************************
        Public Function GetHTCGroups(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT Group_ID, Group_Desc FROM lgroups WHERE Group_ID in ( 79 ) "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {0, "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetProdStation(Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT Test_ID, Test_Desc2 FROM ltesttype WHERE Test_Inactive = 0 "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {0, "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetProdTrackingRefurbishedData(ByVal strWorkDate As String, _
                                                       ByVal iGroupID As Integer, _
                                                       ByVal iTestTypeID As Integer, _
                                                       ByVal iGroupTarget As Integer) As DataTable
            Dim strSql As String
            Dim dt, dt1 As DataTable
            Dim R1 As DataRow

            Try
                'Refurbish Information
                strSql = "SELECT DISTINCT A.TD_UsrID, B.user_fullname as 'Tech', date_format(A.TD_TestDt, '%m/%d/%Y') as 'Completed Date' " & Environment.NewLine
                strSql &= ", 0 as 'Refurb Complete', 0 as 'Refurb Rework', 0 as 'PIA Pass', 0 as 'PIA Fail' " & Environment.NewLine
                strSql &= ", 0 as 'RF Pass', 0 as 'RF Fail',  0 as 'Final Pass', 0 as 'Final Fail', 0 as 'OOBA Pass',  0 as 'OOBA Fail' " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers B ON A.TD_UsrID = B.User_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder D ON C.WO_ID = D.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND D.group_id = " & iGroupID & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'Refubish completed qty
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON B.WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND C.group_id = " & iGroupID & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Refurb Complete") = dt1.Select("TD_UsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 1").Length
                    R1("Refurb Rework") = dt1.Select("TD_UsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 3").Length
                    R1.EndEdit()
                    dt.AcceptChanges()
                Next R1

                Generic.DisposeDT(dt1)

                'Testdata of refurbish
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON B.WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID IN (6, 2, 3, 4 ) " & Environment.NewLine  'PIA, RF, Final and OOBA Test
                strSql &= "AND C.group_id = " & iGroupID & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    'PIA
                    R1("PIA Pass") = dt1.Select("Test_ID = 6 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 1").Length
                    R1("PIA Fail") = dt1.Select("Test_ID = 6 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 2").Length

                    'RF
                    R1("RF Pass") = dt1.Select("Test_ID = 2 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 1").Length
                    R1("RF Fail") = dt1.Select("Test_ID = 2 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 2").Length
                    'Final
                    R1("Final Pass") = dt1.Select("Test_ID = 3 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 1").Length
                    R1("Final Fail") = dt1.Select("Test_ID = 3 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 2").Length
                    'OOBA
                    R1("OOBA Pass") = dt1.Select("Test_ID = 4 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 1").Length
                    R1("OOBA Fail") = dt1.Select("Test_ID = 4 AND CompletedTechUsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 2").Length
                    R1.EndEdit()
                    dt.AcceptChanges()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************
        Public Function GetProdTrackingTestData(ByVal strWorkDate As String, _
                                                ByVal iGroupID As Integer, _
                                                ByVal iTestTypeID As Integer, _
                                                ByVal iGroupTarget As Integer) As DataTable
            Dim strSql As String
            Dim dt, dt1 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT DISTINCT A.TD_UsrID, B.user_fullname as 'Inspector' " & Environment.NewLine
                strSql &= ", date_format(A.TD_TestDt, '%m/%d/%Y') as 'Date' " & Environment.NewLine
                strSql &= ", 0 as 'Pass', 0 as 'Fail' " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers B ON A.TD_UsrID = B.User_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder D ON C.WO_ID = D.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND D.group_id = " & iGroupID & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'qty
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= "FROM ttestdata A " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON B.WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "WHERE date_format(A.TD_TestDt, '%Y-%m-%d') = '" & strWorkDate & "' " & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestTypeID & Environment.NewLine
                strSql &= "AND C.group_id = " & iGroupID & Environment.NewLine
                strSql &= "ORDER BY A.TD_TestDt, A.TD_UsrID " & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Pass") = dt1.Select("TD_UsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 1").Length
                    R1("Fail") = dt1.Select("TD_UsrID = " & R1("TD_UsrID") & " AND QCResult_ID = 2").Length
                    R1.EndEdit()
                    dt.AcceptChanges()
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '******************************************************************

#End Region

#Region "Admin Edit"

        '******************************************************************
        Public Function GetUnbillRURDeviceInfo(ByVal strSN As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT hd_Station as Station, lcodesdetail.Dcode_L2desc as 'RUR Reason'  " & Environment.NewLine
                strSql &= ", if(thtcdata.DeviceWty = 1, 'IW', 'OOW' ) as 'Warranty'  " & Environment.NewLine
                strSql &= ", if(tdevice.Pallett_ID is null, '', tdevice.Pallett_ID) as 'Box ID'  " & Environment.NewLine
                strSql &= ", if(Device_DateShip is null, '', date_format(Device_DateShip, '%m/%d/%Y')) as 'Line Completion Date'  " & Environment.NewLine
                strSql &= ", tdevicebill.DBill_ID, tdevicebill.BillCode_ID as Devicebill_BillcodeID, lcodesdetail.Dcode_id  " & Environment.NewLine
                strSql &= ", thtcrepair.Billcode_ID, PartNumber, thtcrepair.Repair_ID " & Environment.NewLine
                strSql &= ", ttestdata.*  "
                strSql &= "FROM thtcdata  " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON thtcdata.Device_ID = tdevice.Device_ID  " & Environment.NewLine
                strSql &= "INNER JOIN tdevicecodes ON thtcdata.Device_ID = tdevicecodes.Device_ID  " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tdevicecodes.Dcode_ID = lcodesdetail.Dcode_id  " & Environment.NewLine
                strSql &= "INNER JOIN thtcrepair ON thtcdata.Device_ID = thtcrepair.Device_ID  " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON thtcdata.Device_ID = tdevicebill.Device_ID  " & Environment.NewLine
                strSql &= "INNER JOIN ttestdata ON thtcdata.Device_ID = ttestdata.Device_ID  " & Environment.NewLine
                strSql &= "WHERE hd_sn = '" & strSN.Trim & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UnbillRUR(ByVal dt As DataTable, _
                                  byval iUsrID as Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                '2) Remove record in tdevicecodes
                strSql = "Delete from tdevicecodes where device_id = " & dt.Rows(0)("Device_ID")
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to remove RUR code.")

                '3) Remove record in thtcrepair
                strSql = "Delete from thtcrepair where device_id = " & dt.Rows(0)("Device_ID")
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to remove RUR fail code and repair code.")

                '4) Remove Record in ttestdata
                strSql = "Delete from ttestdata where device_id = " & dt.Rows(0)("Device_ID")
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to remove test record.")

                '5) Record delete history in thtcedithistory
                strSql = "INSERT INTO thtcedithistory ( "
                strSql &= " Fail_ID " & Environment.NewLine
                strSql &= ", Repair_ID " & Environment.NewLine
                strSql &= ", BillCode_ID " & Environment.NewLine
                strSql &= ", PartNumber " & Environment.NewLine
                strSql &= ", TD_ID " & Environment.NewLine
                strSql &= ", TD_UsrID " & Environment.NewLine
                strSql &= ", TD_TestDt " & Environment.NewLine
                strSql &= ", FailDetail " & Environment.NewLine
                strSql &= ", Test_ID " & Environment.NewLine
                strSql &= ", QCResult_ID " & Environment.NewLine
                strSql &= ", Device_ID " & Environment.NewLine
                strSql &= ", RUR_Reason " & Environment.NewLine
                strSql &= ", EH_Desc " & Environment.NewLine
                strSql &= ", EH_UsrID " & Environment.NewLine
                strSql &= ", EH_DeleteDt " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " " & dt.Rows(0)("Fail_ID") & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("Repair_ID") & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("BillCode_ID") & Environment.NewLine
                strSql &= ", '" & dt.Rows(0)("PartNumber") & "' " & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("TD_ID") & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("TD_UsrID") & Environment.NewLine
                strSql &= ", '" & Format(CDate(dt.Rows(0)("TD_TestDt")), "yyyy-MM-dd hh:mm:ss") & "'" & Environment.NewLine
                strSql &= ", '" & dt.Rows(0)("TD_FailDetails") & "' " & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("Test_ID") & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("QCResult_ID") & Environment.NewLine
                strSql &= ", " & dt.Rows(0)("Device_ID") & Environment.NewLine
                strSql &= ", '" & dt.Rows(0)("RUR Reason") & "' " & Environment.NewLine
                strSql &= ", 'Unbill RUR'" & Environment.NewLine
                strSql &= ", " & iUsrID & Environment.NewLine
                strSql &= ", now()" & Environment.NewLine
                strSql &= ")"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed save delete data.")

                '6) Push unit back to Diagnostic
                i = Me.PushUnitToNextWorkingStation(dt.Rows(0)("Device_ID"), "DIAGNOSTIC", , )
                If i = 0 Then Throw New Exception("System has failed to move unit back to DIAGNOSTIC.")

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************

#End Region


    End Class
End Namespace

