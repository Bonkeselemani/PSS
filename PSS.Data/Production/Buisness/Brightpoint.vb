Option Explicit On 

Imports system.IO
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class Brightpoint
        Private objMisc As Production.Misc
        Private _objDataProc As DBQuery.DataProc
        Private strBrightPointFTPAdd As String = ""
        Private strBrightPointFTPUsr As String = ""
        Private strBrightPointFTPPwd As String = ""
        Private strDir As String = "P:\Dept\Cellstar\"

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
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
        '***************************************************

        Public Function LoadASNFrDobson() As Integer
            Dim strLogFileLoc As String = strDir & "Dobson\" & "Log Files\dob_pssi_log.txt"
            Dim strFileName As String = ""
            Dim strFileLoc As String = ""
            Dim i As Integer = 0

            Try
                strFileName = Dir(strDir & "Dobson\IncomingDataFiles\" & "*.dcc")

                Do Until strFileName = Nothing
                    strFileLoc = strDir & "Dobson\IncomingDataFiles\" & strFileName

                    If New FileInfo(strFileLoc).Length <> 0 Then
                        '*********************************
                        'load data in CSV file into system
                        '*********************************
                        i += WriteDOBDataToCstincomingdata(strFileLoc, strLogFileLoc)

                        '*********************************
                        'move CSV file to archive folder
                        '*********************************
                        System.IO.File.Move(strFileLoc, strDir & "Dobson\IncomingDataFiles\" & "Archive\" & strFileName)
                    Else
                        '****************************************************
                        'move XML file to BadFile folder if file size is zero
                        '****************************************************
                        System.IO.File.Move(strFileLoc, strDir & "Dobson\IncomingDataFiles\" & "BadFiles\" & strFileName)
                    End If

                    strFileName = Dir()
                Loop

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Private Function WriteDOBDataToCstincomingdata(ByVal strFileLoc As String, _
                                                       ByVal strLogFileLoc As String) As Integer
            Dim objRec As Production.Receiving
            Dim strLoadDt As String = ""
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim iExistedCsin_ID As Integer = 0
            Dim objReader As StreamReader
            Dim strLine As String = ""
            Dim iCnt As Integer = 0
            Dim strArr As String()
            Dim strLogData As String = ""
            Dim strLogDt As String = ""
            Dim strStoreLoc As String
            Dim strDocID As String = ""
            Dim strVendorItem As String = ""
            Dim strUPCPartNum As String = ""
            Dim strIMEI As String = ""
            Dim strEnterpriseCode As String = "DOB"

            Try
                objRec = New Production.Receiving()
                strLoadDt = Generic.MySQLServerDateTime(1)
                strLogDt = Format(CDate(strLoadDt), "MM/dd/yyyy hh:mm:ss")

                '****************
                'Open log file
                '****************
                FileOpen(1, strLogFileLoc, OpenMode.Append)   'Open TXT file

                objReader = New StreamReader(strFileLoc)

                'Loop through File
                While objReader.Peek <> -1

                    iCnt += 1

                    '**********************************
                    'Read a line from Data file
                    '**********************************
                    strLine = Trim(objReader.ReadLine())

                    If Trim(strLine) <> "" Then
                        strArr = strLine.Split(",")
                        If strArr.Length > 0 Then
                            '***********************
                            'Get record information
                            '***********************
                            strStoreLoc = UCase(Trim(strArr(0).Replace("""", "")))
                            strDocID = UCase(Trim(strArr(1).Replace("""", "")))
                            strVendorItem = UCase(Trim(strArr(2).Replace("""", "")))
                            strUPCPartNum = UCase(Trim(strArr(3).Replace("""", "")))
                            strIMEI = UCase(Trim(strArr(4).Replace("""", "")))

                            'Set to default value
                            If strStoreLoc = "" Then
                                strStoreLoc = "NULL"
                            End If
                            If strVendorItem = "" Then
                                strVendorItem = "NULL"
                            End If
                            '**********************************
                            'validate IMEI and Document ID
                            '**********************************
                            If strIMEI = "" Then
                                strLogData &= strLogDt & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank IMEI" & vbCrLf
                            ElseIf strUPCPartNum = "" Then
                                strLogData &= strLogDt & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank Part#" & vbCrLf
                            ElseIf strDocID = "" Then
                                strLogData &= strLogDt & " FileName:" & strFileLoc & " Line#" & iCnt & " Blank Document ID" & vbCrLf
                            Else
                                '*******************************
                                'Check for duplicate
                                '*******************************
                                iExistedCsin_ID = objRec.GetCSIN_ID_InStaging(strIMEI)

                                If iExistedCsin_ID = 0 Then
                                    '*******************************
                                    'insert into cstincomingdata
                                    '*******************************
                                    i += objRec.InsertIntoCstincomingData(strDocID, _
                                                                          strLoadDt, _
                                                                          strUPCPartNum, _
                                                                          strIMEI, _
                                                                          strEnterpriseCode, _
                                                                          , , , , , strStoreLoc, strVendorItem, )
                                Else
                                    '*********************************
                                    'write existed IMEI into log file
                                    '*********************************
                                    strLogData &= strLogDt & " FileName:" & strFileLoc & " Line#" & iCnt & " Existed IMEI:" & strIMEI & vbCrLf

                                End If  'Check for duplicate
                            End If   'Validate Blank IMEI,Blank Document ID(Repair Order) and Blank UPCPart#
                        End If  'Check for empty array

                        'reset loop variable
                        strArr = Nothing
                        strDocID = ""
                        strIMEI = ""
                        strUPCPartNum = ""
                        strStoreLoc = ""
                        strVendorItem = ""
                        iExistedCsin_ID = 0
                    End If  'check for blank line
                End While

                '**************************
                'Write to log file
                '**************************
                strLogData &= strLogDt & " FileName:" & strFileLoc & " " & i & " record(s) have been loaded " & vbCrLf
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

        '********************************************************************************
        Public Function PSSIReceiptToDobson(ByVal iLoc_ID As Integer, _
                                            ByVal iSalvagePallet_ID As Integer, _
                                            ByVal iProd_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dtWIP, dtSalvage, dtSalvageSold, dtTodayShipment As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strFileName As String = ""
            Dim strFileDir As String = Me.strDir & "Dobson\OutGoingDataFiles\"
            Dim strLogFileLoc As String = strDir & "Dobson\" & "Log Files\pssi_dob_log.txt"
            Dim strOutputData As String = ""
            Dim strCsin_IDs As String = ""
            Dim strDevice_IDs As String = ""
            Dim strTodayDt As String = ""
            Dim strFileNameDt As String = ""
            Dim objWriter As StreamWriter
            Dim objCellstar As Buisness.CellStar
            Dim strRepIMEI As String = ""

            Try
                strTodayDt = Generic.MySQLServerDateTime(1)

                strFileNameDt = strTodayDt.Replace("-", "")
                strFileNameDt = strFileNameDt.Replace(" ", "_")
                strFileNameDt = strFileNameDt.Replace(":", "")
                strFileName = "pssi_dob_br_" & strFileNameDt & ".dcc"

                '*************************************
                '1::--Production Line
                '*************************************
                strSql = "SELECT Device_SN as SN, Device_oldSN, 1 as State, csin_RepairOrderNum as 'Document ID', CameWithFileFlg, NewLoadFlg " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE csin_EnterpriseCode in ('DOB', 'DBR') " & Environment.NewLine
                strSql &= "AND ClosedStatusSent = 0 " & Environment.NewLine
                strSql &= "AND flgReceived = 1 " & Environment.NewLine

                'strSql &= "AND NewLoadFlg = 1 " & Environment.NewLine

                strSql &= "AND isSalvageFlg = 0 " & Environment.NewLine
                strSql &= "AND salvageSold = 0 " & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= "AND tdevice.loc_id = " & iLoc_ID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & ";"
                Me.objMisc._SQL = strSql
                dtWIP = Me.objMisc.GetDataTable

                For Each R1 In dtWIP.Rows
                    If Not IsDBNull(R1("Device_oldSN")) Then
                        strRepIMEI = UCase(Trim(R1("Device_oldSN")))
                    End If

                    If R1("CameWithFileFlg") = 1 And R1("NewLoadFlg") = 1 Then    'Come from Dobson store
                        'Write IMEI, UPC, State, To Location, Document ID, ReplacedIMEI
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """" & R1("Document ID") & """," & """" & strRepIMEI & """" & vbCrLf
                    Else    'Come from customer
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """""," & """" & strRepIMEI & """" & vbCrLf
                    End If

                    strRepIMEI = ""
                Next R1

                strRepIMEI = ""
                R1 = Nothing

                '*************************************
                '2::--Salvage
                '*************************************
                strSql = "SELECT Device_SN as SN, Device_oldSN, 2 as State, csin_RepairOrderNum as 'Document ID', CameWithFileFlg, NewLoadFlg " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt on tdevice.device_id = tcellopt.device_id" & Environment.NewLine
                strSql &= "WHERE csin_EnterpriseCode in ('DOB', 'DBR') " & Environment.NewLine
                strSql &= "AND ClosedStatusSent = 0 " & Environment.NewLine
                strSql &= "AND flgReceived = 1 " & Environment.NewLine

                'strSql &= "AND NewLoadFlg = 1 " & Environment.NewLine

                strSql &= "AND isSalvageFlg = 1 " & Environment.NewLine
                strSql &= "AND salvageSold = 0 " & Environment.NewLine
                strSql &= "AND (Device_DateShip is not null AND Device_DateShip <> '0000-00-00 00:00:00' AND trim(Device_DateShip) <> '') " & Environment.NewLine
                strSql &= "AND loc_id = " & iLoc_ID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND pallett_id = " & iSalvagePallet_ID & Environment.NewLine
                strSql &= "AND Cellopt_WIPOwner = 74" & ";"

                Me.objMisc._SQL = strSql
                dtSalvage = Me.objMisc.GetDataTable

                For Each R1 In dtSalvage.Rows
                    If Not IsDBNull(R1("Device_oldSN")) Then
                        strRepIMEI = UCase(Trim(R1("Device_oldSN")))
                    End If

                    If R1("CameWithFileFlg") = 1 And R1("NewLoadFlg") = 1 Then   'Come from Dobson store
                        'Write IMEI, UPC, State, To Location, Document ID
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """" & R1("Document ID") & """," & """" & strRepIMEI & """" & vbCrLf
                    Else    'Come from customer
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """""," & """" & strRepIMEI & """" & vbCrLf
                    End If

                    strRepIMEI = ""
                Next R1

                R1 = Nothing
                strRepIMEI = ""

                '*****************************************************
                '3::--Salvage sold  UPDATE ALL CLOSE STATUS SEND = 1 
                '*****************************************************
                strSql = "SELECT csin_id, Device_SN as SN, Device_oldSN, 3 as State, csin_RepairOrderNum as 'Document ID', CameWithFileFlg, NewLoadFlg " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt on tdevice.device_id = tcellopt.device_id" & Environment.NewLine
                strSql &= "WHERE csin_EnterpriseCode in ('DOB', 'DBR') " & Environment.NewLine
                strSql &= "AND ClosedStatusSent = 0 " & Environment.NewLine
                strSql &= "AND flgReceived = 1 " & Environment.NewLine

                'strSql &= "AND NewLoadFlg = 1 " & Environment.NewLine

                strSql &= "AND isSalvageFlg = 1 " & Environment.NewLine
                strSql &= "AND salvageSold = 1 " & Environment.NewLine
                strSql &= "AND (Device_DateShip is not null AND Device_DateShip <> '0000-00-00 00:00:00' AND trim(Device_DateShip) <> '') " & Environment.NewLine
                strSql &= "AND loc_id = " & iLoc_ID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND pallett_id is not null " & Environment.NewLine
                strSql &= "AND Cellopt_WIPOwner = 7 " & ";"

                Me.objMisc._SQL = strSql
                dtSalvageSold = Me.objMisc.GetDataTable

                For Each R1 In dtSalvageSold.Rows
                    If Not IsDBNull(R1("Device_oldSN")) Then
                        strRepIMEI = UCase(Trim(R1("Device_oldSN")))
                    End If

                    If R1("CameWithFileFlg") = 1 And R1("NewLoadFlg") = 1 Then   'Come from Dobson store
                        'Write IMEI, UPC, State, To Location, Document ID
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """" & R1("Document ID") & """," & """" & strRepIMEI & """" & vbCrLf
                    Else    'Come from customer
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """""," & """" & strRepIMEI & """" & vbCrLf
                    End If

                    'Build csin_id to update closeStatusSend
                    If strCsin_IDs = "" Then
                        strCsin_IDs &= R1("csin_id")
                    Else
                        strCsin_IDs &= ", " & R1("csin_id")
                    End If

                    strRepIMEI = ""
                Next R1

                R1 = Nothing
                strRepIMEI = ""

                '-- SET CLOSE STATUS SEND = 1. This will drop the data
                If strCsin_IDs <> "" Then
                    strSql = "UPDATE cstincomingdata " & Environment.NewLine
                    strSql &= "SET ClosedStatusSent = 1 " & Environment.NewLine
                    strSql &= "WHERE csin_id in ( " & strCsin_IDs & " );"
                    Me.objMisc._SQL = strSql
                    i += Me.objMisc.ExecuteNonQuery
                End If

                '********************************************************
                '4::--Send to Brightpoint UPDATE ALL CLOSE STATUS SEND = 1
                '********************************************************
                strSql = "SELECT tdevice.Device_ID, Device_SN as SN, Device_oldSN, 4 as State, csin_RepairOrderNum as 'Document ID', CameWithFileFlg, NewLoadFlg " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt on tdevice.device_id = tcellopt.device_id" & Environment.NewLine
                strSql &= "WHERE csin_EnterpriseCode in ('DOB', 'DBR') " & Environment.NewLine
                strSql &= "AND ClosedStatusSent = 0 " & Environment.NewLine
                strSql &= "AND flgReceived = 1 " & Environment.NewLine

                'strSql &= "AND NewLoadFlg = 1 " & Environment.NewLine

                strSql &= "AND isSalvageFlg = 0 " & Environment.NewLine
                strSql &= "AND salvageSold = 0 " & Environment.NewLine
                strSql &= "AND (Device_DateShip is not null AND Device_DateShip <> '0000-00-00 00:00:00' AND trim(Device_DateShip) <> '') " & Environment.NewLine
                strSql &= "AND tdevice.loc_id = " & iLoc_ID & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND tdevice.pallett_id is not null " & Environment.NewLine
                strSql &= "AND Cellopt_WIPOwner = 7 " '& ";"

                strSql &= "AND tpallett.Pallet_ShipType = 0 AND tpallett.DOBFlg = 1; "


                Me.objMisc._SQL = strSql
                dtTodayShipment = Me.objMisc.GetDataTable

                For Each R1 In dtTodayShipment.Rows
                    If Not IsDBNull(R1("Device_oldSN")) Then
                        strRepIMEI = UCase(Trim(R1("Device_oldSN")))
                    End If

                    If R1("CameWithFileFlg") = 1 And R1("NewLoadFlg") = 1 Then   'Come from Dobson store
                        'Write IMEI, UPC, State, To Location, Document ID
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """" & R1("Document ID") & """," & """" & strRepIMEI & """" & vbCrLf
                    Else    'Come from customer
                        strOutputData &= """" & UCase(Trim(R1("SN"))) & """," & """""," & """" & R1("State") & """," & """""," & """""," & """" & strRepIMEI & """" & vbCrLf
                    End If

                    'Build csin_id to update closeStatusSend
                    If strDevice_IDs = "" Then
                        strDevice_IDs &= R1("Device_ID")
                    Else
                        strDevice_IDs &= ", " & R1("Device_ID")
                    End If

                    strRepIMEI = ""
                Next R1

                R1 = Nothing
                strRepIMEI = ""

                '******************************
                '6::--Write data to file
                '******************************
                If strOutputData <> "" Then
                    objWriter = New StreamWriter(strFileDir & strFileName)
                    objWriter.Write(strOutputData)
                End If

                '--UPDATE CLOSE STATUS SEND FLG = 1
                If strDevice_IDs <> "" Then
                    strSql = "UPDATE cstincomingdata " & Environment.NewLine
                    strSql &= "SET ClosedStatusSent = 1 " & Environment.NewLine
                    strSql &= "WHERE device_id in ( " & strDevice_IDs & " );"
                    Me.objMisc._SQL = strSql
                    i += Me.objMisc.ExecuteNonQuery
                End If

                '**************************
                'Write to log file
                '**************************
                FileOpen(1, strLogFileLoc, OpenMode.Append)   'Open TXT file
                PrintLine(1, Format(CDate(strTodayDt), "MM/dd/yyyy hh:mm:ss") & " FileName:" & strFileName & " WIP::" & dtWIP.Rows.Count & " SALVAGE::" & dtSalvage.Rows.Count & " SALVAGE SOLD::" & dtSalvageSold.Rows.Count & " SHIP TO BRIGHTPOINT::" & dtTodayShipment.Rows.Count)
                '**************************

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                Reset()
                objCellstar = Nothing
                objWriter.Close()
                If Not IsNothing(objWriter) Then
                    objWriter = Nothing
                End If

                R1 = Nothing
                If Not IsNothing(dtWIP) Then
                    dtWIP.Dispose()
                    dtWIP = Nothing
                End If
                If Not IsNothing(dtSalvage) Then
                    dtSalvage.Dispose()
                    dtSalvage = Nothing
                End If
                If Not IsNothing(dtSalvageSold) Then
                    dtSalvageSold.Dispose()
                    dtSalvageSold = Nothing
                End If
                If Not IsNothing(dtTodayShipment) Then
                    dtTodayShipment.Dispose()
                    dtTodayShipment = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function ASNToBrightPoint(ByVal iLoc_ID As Integer, _
                                         ByVal strShipFrDate As String, _
                                         ByVal strShipToDate As String) As Integer
            Dim strSql As String = ""
            Dim dtDOB As DataTable
            Dim dtNoneDOB As DataTable
            Dim strDOBFileNameExcel As String = ""
            Dim strNonDOBFileNameExcel As String = ""
            Dim strDOBFileNameCSV As String = ""
            Dim strNonDOBFileNameCSV As String = ""
            Dim strDeviceIDs As String = ""
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                ''***********************
                ''Create File Name
                ''***********************
                strDOBFileNameExcel = "DOB Ship From " & strShipFrDate & " To " & strShipToDate & ".xls"
                strNonDOBFileNameExcel = "N-DOB Ship From " & strShipFrDate & " To " & strShipToDate & ".xls"
                strDOBFileNameCSV = "DOB Ship From " & strShipFrDate & " To " & strShipToDate & ".DCC"
                strNonDOBFileNameCSV = "N-DOB Ship From " & strShipFrDate & " To " & strShipToDate & ".DCC"

                '***********************************
                'Get all devices belong to Dobson
                '***********************************
                strSql = "SELECT Device_SN, Pallett_name, Pallet_ShipType, DOBFlg, Sku_ID, NewLoadFlg, csin_ItemNum, BStockUPC, Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata ON tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cs_dob_atob_upc_crossref ON cstincomingdata.csin_ItemNum = cs_dob_atob_upc_crossref.AStockUPC " & Environment.NewLine
                strSql &= "WHERE tdevice.loc_id = " & iLoc_ID & " " & Environment.NewLine
                strSql &= "AND Device_ShipWorkDate >= '" & strShipFrDate & "' and Device_ShipWorkDate <= '" & strShipToDate & "' " & Environment.NewLine
                strSql &= "AND tpallett.DOBFlg = 1 " & Environment.NewLine
                strSql &= "AND Cellopt_WIPOwner = 7 " & Environment.NewLine
                strSql &= "AND csin_EnterpriseCode in ('DBR', 'DOB') " & Environment.NewLine
                strSql &= "AND isSalvageFlg = 0 " & Environment.NewLine

                strSql &= "ORDER BY Pallett_Name, Model_Desc;"

                Me.objMisc._SQL = strSql
                dtDOB = Me.objMisc.GetDataTable

                If dtDOB.Rows.Count > 0 Then
                    Me.CreateASNFileToBP_ExelFormat(dtDOB, strDOBFileNameExcel)
                    Me.CreateASNFileToBP_CSVFormat(dtDOB, strDOBFileNameCSV)
                End If

                '*****************************************
                'Get all devices do not belong to Dobson
                '*****************************************
                strSql = "SELECT tdevice.Device_ID, Device_SN, Pallett_name, Pallet_ShipType, DOBFlg, Sku_ID, NewLoadFlg, csin_ItemNum, BStockUPC, Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata ON tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cs_dob_atob_upc_crossref ON cstincomingdata.csin_ItemNum = cs_dob_atob_upc_crossref.AStockUPC " & Environment.NewLine
                strSql &= "WHERE tdevice.loc_id = " & iLoc_ID & " " & Environment.NewLine
                strSql &= "AND Device_ShipWorkDate >= '" & strShipFrDate & "' and Device_ShipWorkDate <= '" & strShipToDate & "' " & Environment.NewLine
                strSql &= "AND tpallett.DOBFlg = 0 AND tpallett.Pallett_Name <> 'SALVAGE' " & Environment.NewLine
                strSql &= "AND Cellopt_WIPOwner = 7 " & Environment.NewLine
                strSql &= "AND csin_EnterpriseCode not in ('DBR', 'DOB') " & Environment.NewLine
                strSql &= "ORDER BY Pallett_Name, Model_Desc;"

                Me.objMisc._SQL = strSql
                dtNoneDOB = Me.objMisc.GetDataTable

                If dtNoneDOB.Rows.Count > 0 Then
                    '******************
                    'Create ASN file
                    '******************
                    Me.CreateASNFileToBP_ExelFormat(dtNoneDOB, strNonDOBFileNameExcel)
                    Me.CreateASNFileToBP_CSVFormat(dtNoneDOB, strNonDOBFileNameCSV)

                    '*************************
                    'update closestatussend
                    '*************************
                    For Each R1 In dtNoneDOB.Rows
                        If strDeviceIDs = "" Then
                            strDeviceIDs = R1("Device_ID")
                        Else
                            strDeviceIDs &= "," & R1("Device_ID")
                        End If
                    Next R1

                    strSql = "Update cstincomingdata SET ClosedStatusSent  = 2 WHERE device_ID in ( " & strDeviceIDs & " ) and ClosedStatusSent = 0;"
                    Me.objMisc._SQL = strSql
                    i = Me.objMisc.ExecuteNonQuery()
                    '*************************
                End If

                Return dtDOB.Rows.Count + dtNoneDOB.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dtDOB) Then
                    dtDOB.Dispose()
                    dtDOB = Nothing
                End If
                If Not IsNothing(dtNoneDOB) Then
                    dtNoneDOB.Dispose()
                    dtNoneDOB = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Sub CreateASNFileToBP_ExelFormat(ByVal dtData As DataTable, _
                                                ByVal strFileName As String)
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptPath As String = Me.strDir & "Brightpoint\ASNFiles\Excel Format\" & strFileName

            Dim i As Integer = 1
            Dim R1 As DataRow

            Try
                '******************************************************************
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Pallet ID"
                objExcel.Application.Cells(i, 2).Value = "SN"
                objExcel.Application.Cells(i, 3).Value = "SN Barcode"
                objExcel.Application.Cells(i, 4).Value = "Triage Result"
                objExcel.Application.Cells(i, 5).Value = "SKU"
                objExcel.Application.Cells(i, 6).Value = "Model Desc"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 21
                objSheet.Columns("B:B").ColumnWidth = 21        'Need to change this
                objSheet.Columns("C:C").ColumnWidth = 28
                objSheet.Columns("D:D").ColumnWidth = 16        'Need to change this
                objSheet.Columns("E:E").ColumnWidth = 20        'Need to change this
                objSheet.Columns("F:F").ColumnWidth = 20        'Need to change this
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
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("Pallett_name"))
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("Device_sn"))
                    objExcel.Application.Cells(i, 3).Value = "*" & Trim(R1("Device_sn")) & "*"

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                objExcel.Application.Cells(i, 4).Value = "Refurbished"
                            Case 1  'RUR
                                objExcel.Application.Cells(i, 4).Value = "BER"
                            Case 9  'RTM
                                objExcel.Application.Cells(i, 4).Value = "BER"
                        End Select
                    End If

                    'UPC Part number
                    If R1("DOBFlg") = 1 Then
                        If Not IsDBNull(R1("csin_ItemNum")) Then
                            If Not IsDBNull(R1("BStockUPC")) Then
                                objExcel.Application.Cells(i, 5).Value = Trim(R1("BStockUPC"))
                            Else
                                objExcel.Application.Cells(i, 5).Value = Trim(R1("csin_ItemNum"))
                            End If
                        End If
                    Else
                        If Not IsDBNull(R1("csin_ItemNum")) Then
                            objExcel.Application.Cells(i, 5).Value = Trim(R1("csin_ItemNum"))
                        End If
                    End If

                    'Model Description
                    objExcel.Application.Cells(i, 6).Value = UCase(Trim(R1("Model_Desc")))

                    i += 1
                Next R1

                '*****************************************
                'Write Total Line   
                '*****************************************
                i += 1
                objExcel.Application.Cells(i, 1).Value = "Total Count = " & dtData.Rows.Count
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
                objSheet.Range("C2:C" & (dtData.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With
                '************************************************
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
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
            Catch ex As Exception
                Throw New Exception("Buisness.Brightpoint.CreateASNFileToBP_ExelFormat(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dtData) Then
                    dtData.Dispose()
                    dtData = Nothing
                End If
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
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '********************************************************************
        Public Sub CreateASNFileToBP_CSVFormat(ByVal dtData As DataTable, _
                                               ByVal strFileName As String)
            Dim strLogFileLoc As String = Me.strDir & "Brightpoint\Log Files\pssi_bp_ASN_log.txt"
            Dim objWriter As StreamWriter
            Dim strFileDir As String = Me.strDir & "Brightpoint\ASNFiles\CSV Format\"
            Dim R1 As DataRow
            Dim strOutputData As String = ""

            Try
                '********************
                'Collect data
                '********************
                For Each R1 In dtData.Rows

                    strOutputData &= """" & UCase(Trim(Trim(R1("Pallett_name")))) & """,""" & Trim(R1("Device_sn")) & """,""" & "*" & Trim(R1("Device_sn")) & "*" & ""","""

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                strOutputData &= "Refurbished" & ""","""
                            Case 1  'RUR
                                strOutputData &= "BER" & ""","""
                            Case 9  'RTM
                                strOutputData &= "BER" & ""","""
                        End Select
                    End If

                    'UPC Part number
                    If R1("DOBFlg") = 1 Then
                        If Not IsDBNull(R1("csin_ItemNum")) Then
                            If Not IsDBNull(R1("BStockUPC")) Then
                                strOutputData &= Trim(R1("BStockUPC")) & ""","""
                            Else
                                strOutputData &= Trim(R1("csin_ItemNum")) & ""","""
                            End If
                        End If
                    Else
                        If Not IsDBNull(R1("csin_ItemNum")) Then
                            strOutputData &= Trim(R1("csin_ItemNum")) & ""","""
                        End If
                    End If

                    'Model Description
                    strOutputData &= UCase(Trim(R1("Model_Desc"))) & """" & vbCrLf
                Next R1

                '******************************
                '6::--Write data to file
                '******************************
                If strOutputData <> "" Then
                    objWriter = New StreamWriter(strFileDir & strFileName)
                    objWriter.Write(strOutputData)
                End If

                '**************************
                'Write to log file
                '**************************
                FileOpen(1, strLogFileLoc, OpenMode.Append)   'Open TXT file
                PrintLine(1, Format(Now, "MM/dd/yyyy hh:mm:ss") & " FileName:" & strFileName & " QTY::" & dtData.Rows.Count)
                '**************************

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateASNFileToBP(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dtData) Then
                    dtData.Dispose()
                    dtData = Nothing
                End If
                Reset()
                objWriter.Close()

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub


        '********************************************************************
        Public Function GetRecDeviceInfo(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT cstincomingdata.*, cs_partmap.*, Model_Desc, Manuf_ID, Prod_ID, Model_GSM " & Environment.NewLine
                strSql &= "FROM cstincomingdata " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cs_partmap on cstincomingdata.csin_ItemNum = cs_partmap.part_number " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel on cs_partmap.model_id = tmodel.Model_ID" & Environment.NewLine
                strSql &= "WHERE csin_ESN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND flgReceived = 0 " & Environment.NewLine
                'strSql &= "AND NewLoadFlg = 1;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetBPRecUPCNumInfo(ByVal strUPCPartNum As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT cs_partmap.*, Model_Desc, Model_GSM, Prod_ID, Manuf_ID " & Environment.NewLine
                strSql &= "FROM cs_partmap " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel on cs_partmap.model_id = tmodel.Model_ID  " & Environment.NewLine
                strSql &= "WHERE part_number = '" & strUPCPartNum & "';"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetBPSalvagePallet_ID(ByVal iCust_ID As Integer, _
                                               ByVal iLoc_ID As Integer, _
                                               Optional ByVal strPalletName As String = "SALVAGE") As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iPallet_ID As Integer = 0

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & Environment.NewLine
                strSql &= "AND Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSql &= "AND Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND Pallet_ShipType = 1 " & Environment.NewLine
                strSql &= "AND Model_ID = 0;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iPallet_ID = (dt1.Rows(0)("pallett_ID"))
                End If

                Return iPallet_ID
            Catch ex As Exception
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function RecBPDevicesIntoPSSWIP(ByVal iDevsFrBP As Integer, _
                                            ByVal iCust_ID As Integer, _
                                            ByVal iLoc_ID As Integer, _
                                            ByVal strEnterprise As String, _
                                            ByVal strUserName As String, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String, _
                                            ByVal iMachineGroup_ID As Integer, _
                                            ByVal iWOGroup_ID As Integer, _
                                            ByVal strMachineGroupDesc As String, _
                                            ByVal iCell2SlvgGroup_ID As Integer, _
                                            ByVal iRURSalvageBillcode_ID As Integer, _
                                            ByVal dtDevices As DataTable) As Integer
            Dim objRec As Production.Receiving
            Dim objShip As Production.Shipping
            'Dim objGenBilling As GenerateBilling
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strRecDt As String = ""
            Dim iTray_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim i As Integer = 0
            Dim strCustRepOrder As String = ""
            Dim iCnt As Integer = 0
            Dim iSlvgPallet_ID As Integer = 0
            Dim iSlvgShip_ID As Integer = 0
            Dim strModel_IDs As String = ""
            Dim strSku_ID As String = ""

            Try
                objRec = New Production.Receiving()
                objShip = New Production.Shipping()
                'objGenBilling = New GenerateBilling()

                strRecDt = Generic.MySQLServerDateTime(1)

                '************************
                'Define PSS Wokorder Name
                '************************
                strCustRepOrder = "BP" & iUser_ID & "D" & Format(CDate(strRecDt), "MMddyy") & "T" & Format(CDate(strRecDt), "hhmmss")

                '***********************************
                'Get Salvage Pallet_ID
                '***********************************
                iSlvgPallet_ID = Me.GetBPSalvagePallet_ID(iCust_ID, iLoc_ID, )
                If iSlvgPallet_ID = 0 Then
                    Throw New Exception("Can not find 'Salvage' pallet.")
                End If

                '***********************************
                'Get Salvage Ship_ID
                '***********************************
                iSlvgShip_ID = Me.GetSalvageShip_ID(iSlvgPallet_ID)
                If iSlvgShip_ID = 0 Then
                    Throw New Exception("Can not find 'Salvage' ship ID.")
                End If

                '************************
                '1:: Create WO
                '************************
                iWO_ID = objRec.InsertIntoTworkorder(strCustRepOrder, _
                                                     strCustRepOrder, _
                                                     iLoc_ID, _
                                                     CStr(dtDevices.Rows(0)("Prod_ID")), _
                                                     iWOGroup_ID, _
                                                     , , , _
                                                     , CStr(dtDevices.Rows.Count), )


                If iWO_ID = 0 Then
                    Throw New Exception("System has failed to create 'Work Order'.")
                End If

                '***********************************
                '2:: Create Tray
                '***********************************
                iTray_ID = objRec.InsertIntoTtray(iUser_ID, strUserName, CStr(iWO_ID), )
                If iTray_ID = 0 Then
                    Throw New Exception("System has failed to create tray.")
                End If

                '***********************************
                'Loop through each device
                '***********************************
                For Each R1 In dtDevices.Rows
                    iCnt += 1

                    If IsDBNull(R1("Sku_ID")) Then
                        strSku_ID = ""
                    Else
                        strSku_ID = R1("Sku_ID")
                    End If

                    '************************
                    '3:: Insert into tdevice
                    '************************
                    iDevice_ID = objRec.InsertIntoTdevice(R1("Serial Number"), _
                                                         strWorkDate, _
                                                          iCnt, _
                                                          iTray_ID, _
                                                          iLoc_ID, _
                                                          iWO_ID, _
                                                          R1("Model_ID"), _
                                                          iShift_ID, _
                                                          , _
                                                          R1("ManufWrty"), _
                                                          strSku_ID)
                    If iDevice_ID = 0 Then
                        Throw New Exception("System has failed to insert into tdevice.")
                    End If

                    '************************
                    '4:: Insert into tcellopt
                    '************************
                    If R1("ManufWrty") = 1 Then
                        If R1("GSM") = 1 Then
                            i = objRec.InsertIntoTCellopt(iDevice_ID, _
                                                      R1("MSN"), _
                                                      R1("Serial Number"), _
                                                      , , R1("MSN"), _
                                                      R1("Serial Number"), _
                                                      , R1("APC"), _
                                                      , R1("SugIn"), _
                                                      R1("SugIn"), _
                                                      R1("SugIn"), _
                                                      R1("SoftVerIN"), _
                                                      R1("SoftVerIN"))

                        Else
                            i = objRec.InsertIntoTCellopt(iDevice_ID, _
                                                        , , R1("CSN"), _
                                                        R1("Serial Number"), _
                                                        , , R1("CSN"), _
                                                        , , R1("SugIn"), _
                                                        R1("SugIn"), _
                                                        R1("SugIn"), _
                                                        R1("SoftVerIN"), _
                                                        R1("SoftVerIN"))
                        End If
                    Else
                        i = objRec.InsertIntoTCellopt(iDevice_ID, , , , , , , , , , , , , , )
                    End If

                    If i = 0 Then
                        Throw New Exception("System has failed to insert into tcellopt.")
                    End If

                    '***************************
                    '5:: update cstincomingdata
                    '***************************
                    If Trim(R1("Csin_ID")) = 0 Then
                        '************************
                        'Device come from customer
                        '************************
                        'strCustRepOrder = Me.CreateCustReturnRepOrder(strRecDt)
                        i = objRec.InsertIntoCstincomingData(strCustRepOrder, _
                                    strRecDt, _
                                    Trim(R1("UPCPartNumber")), _
                                    Trim(R1("Serial Number")), _
                                    strEnterprise, iDevice_ID, 1, R1("IsSalvage"), 0, 1, , , iDevsFrBP) 'RcvdFlg, Salvage, cameWithFileFlg, Qty, store location, vendor item
                    Else
                        i = objRec.SetRcvdFlgInCstincomingdata(R1("Csin_ID"), iDevice_ID, R1("IsSalvage"), iDevsFrBP)
                    End If

                    If i = 0 Then
                        Throw New Exception("System has failed to update receive flag.")
                    End If

                    ''*********************************
                    ''5:: ship and bill salvage device
                    ''*********************************
                    'If R1("IsSalvage") = 1 Then
                    '    'Bill Salvage billcode
                    '    i = objGenBilling.ab_ADD(iDevice_ID, iRURSalvageBillcode_ID, R1("Prod_ID"), iUser_ID, strUserName, iEmpNo, iShift_ID, strWorkDate)

                    '    'Ship Salvage
                    '    i = objShip.UpdateShipInfo(iDevice_ID, strWorkDate, iShift_ID, iSlvgPallet_ID, iSlvgShip_ID)

                    '    If i = 0 Then
                    '        Throw New Exception("System has failed to ship salvage device.")
                    '    End If
                    'End If

                    '***************************
                    'Reset loop variable
                    '***************************
                    iDevice_ID = 0
                    '***************************
                Next R1

                Return iCnt
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
                objShip = Nothing
                ''objGenBilling = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtDevices) Then
                    dtDevices.Dispose()
                    dtDevices = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        'Private Function CreateCustReturnRepOrder(ByVal strDate As String) As String
        '    Dim strSql As String = ""
        '    Dim dt1 As DataTable
        '    Dim R1 As DataRow
        '    Dim strCustRepOrder As String = "C2D" & Format(CDate(strDate), "MMddyyyy") & "_"
        '    Dim strCnt As String = ""

        '    Try
        '        strSql = "SELECT csin_RepairOrderNum " & Environment.NewLine
        '        strSql &= "FROM cstincomingdata  " & Environment.NewLine
        '        strSql &= "WHERE csin_RepairOrderNum like '" & strCustRepOrder & "%';"
        '        Me.objMisc._SQL = strSql
        '        dt1 = Me.objMisc.GetDataTable

        '        If dt1.Rows.Count = 0 Then
        '            strCustRepOrder &= "001"
        '        Else
        '            If Not IsDBNull(dt1.Rows(0)("csin_RepairOrderNum")) Then
        '                strCnt = Microsoft.VisualBasic.Right(Trim(dt1.Rows(0)("csin_RepairOrderNum")), 3)
        '                If IsNumeric(strCnt) Then
        '                    strCustRepOrder &= Format(CInt(strCnt) + 1, "000")
        '                Else
        '                    strCustRepOrder &= "001"
        '                End If
        '            Else
        '                strCustRepOrder &= "001"
        '            End If
        '        End If

        '        Return strCustRepOrder
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        R1 = Nothing
        '        If Not IsNothing(dt1) Then
        '            dt1.Dispose()
        '            dt1 = Nothing
        '        End If
        '    End Try
        'End Function

        '********************************************************************
        Public Function GetSlvgQtyByModel(ByVal iCust_ID As Integer, _
                                          ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim iSlvgPallet_ID As Integer = 0

            Try
                iSlvgPallet_ID = Me.GetBPSalvagePallet_ID(iCust_ID, iLoc_ID)
                If iSlvgPallet_ID = 0 Then
                    Throw New Exception("Can not define ""Salvage Pallet"".")
                End If

                strSql = "SELECT Model_Desc as Model, count(*) as QTY " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE pallett_id = " & iSlvgPallet_ID & " " & Environment.NewLine
                strSql &= "GROUP BY tdevice.Model_ID ORDER BY Model_Desc;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetDeviceEnterpriseInWIP(ByVal strSN As String, _
                                                 ByVal iCust_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strEnterprise As String = ""

            Try
                strSql = "SELECT cstincomingdata.* FROM  tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cstincomingdata ON tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_SN = '" & strSN & "' and device_dateship is NULL and device_datebill is not NULL" & Environment.NewLine
                strSql &= "AND cust_ID = " & iCust_ID & Environment.NewLine
                strSql &= "ORDER BY tdevice.device_id desc;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("csin_EnterpriseCode")) Then
                        strEnterprise = dt1.Rows(0)("csin_EnterpriseCode")
                    End If
                End If

                Return strEnterprise
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function IsDOBPallet(ByVal iPallett_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim booResult As Boolean = False

            Try
                strSql = "SELECT * FROM tpallett where pallett_id = " & iPallett_ID & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows(0)("DOBFlg") = 1 Then
                        booResult = True
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function SetDOBFlag(ByVal iPallett_ID As Integer, _
                                   ByVal iDOBFlg As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tpallett set tpallett.DOBFlg = " & iDOBFlg & " where pallett_id = " & iPallett_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function Transf_RepDev_To_Slvg(ByVal iGroup_ID As Integer, _
                                              ByVal iUser_ID As Integer, _
                                              ByVal strUser_Name As String, _
                                              ByVal iEmpNo As Integer, _
                                              ByVal iShift_ID As Integer, _
                                              ByVal strWorkDate As String, _
                                              ByVal iWCLocation_ID As Integer, _
                                              ByVal iLine_ID As Integer, _
                                              ByVal iCust_ID As Integer, _
                                              ByVal iLoc_ID As Integer, _
                                              ByVal lstSNs As System.Windows.Forms.ListBox) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim iIndex As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strSN As String = ""
            Dim objGen As New Generic()
            Dim objShip As New PSS.Data.Production.Shipping()
            Dim strTranfDt As String = ""
            Dim iSlvgPallet_ID As Integer = 0
            Dim iCell2Slvg_GroupID As Integer = 74
            Dim iSlvgShip_ID As Integer = 0

            Try
                strTranfDt = objGen.MySQLServerDateTime(1)
                iSlvgPallet_ID = Me.GetBPSalvagePallet_ID(iCust_ID, iLoc_ID, )
                iSlvgShip_ID = Me.GetSalvageShip_ID(iSlvgPallet_ID)

                For iIndex = 0 To lstSNs.Items.Count - 1
                    strSN = UCase(Trim(lstSNs.Items.Item(iIndex)))

                    iDevice_ID = objGen.GetDevIDInWIPBySNCustID(strSN, iCust_ID)

                    'Ship Salvage
                    i = objShip.UpdateShipInfo(iDevice_ID, strWorkDate, iShift_ID, iSlvgPallet_ID, iSlvgShip_ID)

                    If i = 0 Then
                        Throw New Exception("System has failed to ship salvage device.")
                    End If

                    'Insert device into tdailyproduction table
                    i = objShip.InsertIntoTdailyproduction(strWorkDate, _
                                                            iUser_ID, _
                                                            iWCLocation_ID, _
                                                            iLine_ID, _
                                                            iGroup_ID, _
                                                            iDevice_ID, _
                                                            iSlvgPallet_ID)
                    'Update isSalvageFlg
                    strSql = "UPDATE cstincomingdata set isSalvageFlg = 1 WHERE device_id = " & iDevice_ID & ";"
                    Me.objMisc._SQL = strSql
                    i = Me.objMisc.ExecuteNonQuery

                    strSN = ""
                    iDevice_ID = 0
                Next iIndex

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objShip = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function GetSalvageShip_ID(ByVal iSlvgPallet_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iSalvageShip_ID As Integer = 0

            Try
                strSql = "SELECT Ship_ID FROM tship WHERE ShipPallett = " & iSlvgPallet_ID & ";"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iSalvageShip_ID = dt1.Rows(0)("Ship_ID")
                End If

                Return iSalvageShip_ID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function IsSalvageSN(ByVal iLoc_ID As Integer, _
                                     ByVal strSN As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iDevice_ID As Integer = 0

            Try
                strSql = "SELECT tdevice.Device_ID FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN cstincomingdata ON tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_Name = 'Salvage' " & Environment.NewLine
                strSql &= "AND tdevice.loc_id = " & iLoc_ID & " " & Environment.NewLine
                strSql &= "AND tdevice.Device_SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND tcellopt.Cellopt_WIPOwner = 74 " & Environment.NewLine
                strSql &= "AND cstincomingdata.isSalvageFlg = 1;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iDevice_ID = dt1.Rows(0)("Device_ID")
                End If

                Return iDevice_ID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function IsSNBeenHereAndShippedInLessThan30Days(ByVal iCust_ID As Integer, _
                                                               ByVal strDevSN As String) As Boolean
            Dim strSeverDt As String = ""
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim booResult As Boolean = False

            Try
                strSeverDt = Generic.MySQLServerDateTime(1)

                strSql = "SELECT * FROM tdevice " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_SN = '" & strDevSN & "' " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is not null " & Environment.NewLine
                strSql &= "ORDER BY Device_DateShip DESC;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Device_DateShip")) Then
                        If DateDiff(DateInterval.Day, CDate(R1("Device_DateShip")), CDate(strSeverDt)) < 30 Then
                            booResult = True
                        End If
                    End If
                Next R1

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function Transf_SlvgDev_To_Intransit(ByVal iGroup_ID As Integer, _
                                              ByVal iCust_ID As Integer, _
                                              ByVal iLoc_ID As Integer, _
                                              ByVal strWO_Memo As String, _
                                              ByVal iQty As Integer, _
                                              ByVal strDevice_IDs As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim objGen As New Generic()
            Dim objRec As New Production.Receiving()
            Dim strTranfDt As String = ""
            Dim iSlvgSoldPallet_ID As Integer = 0
            Dim iSlvgSoldShip_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim strWO_Name As String = ""
            Dim strFileNameDt As String = ""
            Dim strManifestFileLocName As String = Me.strDir & "Brightpoint\Salvage Sold\"

            Try
                strTranfDt = objGen.MySQLServerDateTime(1)

                strFileNameDt = strTranfDt.Replace("-", "")
                strFileNameDt = strFileNameDt.Replace(" ", "_")
                strFileNameDt = strFileNameDt.Replace(":", "")

                strWO_Name = "SLVG_SOLD_" & strFileNameDt
                strManifestFileLocName &= strWO_Name & ".xls"

                '*******************************************
                '1:: Get SalvageSold Pallet ID and Ship ID
                '*******************************************
                dt1 = Me.GetBPSalvageSold_PalletShip_ID(iCust_ID, iLoc_ID)
                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Pallett_ID")) Then
                        iSlvgSoldPallet_ID = dt1.Rows(0)("Pallett_ID")
                    End If

                    If Not IsDBNull(dt1.Rows(0)("Ship_ID")) Then
                        iSlvgSoldShip_ID = dt1.Rows(0)("Ship_ID")
                    End If
                End If

                If iSlvgSoldPallet_ID = 0 Or iSlvgSoldShip_ID = 0 Then
                    Throw New Exception("Can not find ""Salvage Sold Pallet/Ship ID.")
                End If

                '***********************
                '2:: Create WO
                '***********************
                iWO_ID = objRec.InsertIntoTworkorder(strWO_Name, _
                                                    strWO_Name, _
                                                    iLoc_ID, _
                                                    2, _
                                                    iGroup_ID, _
                                                    strWO_Memo, , , , iQty, )
                If iWO_ID = 0 Then
                    Throw New Exception("System failed to create 'Work Order'.")
                End If

                '*******************************
                '3:: Transfer to Intransit
                '*******************************
                strSql = "UPDATE tdevice, tcellopt, cstincomingdata " & Environment.NewLine
                strSql &= "SET tdevice.WO_ID_Out = " & iWO_ID & " " & Environment.NewLine
                strSql &= ", tdevice.Pallett_ID = " & iSlvgSoldPallet_ID & " " & Environment.NewLine
                strSql &= ", tdevice.Ship_ID = " & iSlvgSoldShip_ID & " " & Environment.NewLine
                strSql &= ", tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner  " & Environment.NewLine
                strSql &= ", tcellopt.Cellopt_WIPOwner = 7 " & Environment.NewLine
                strSql &= ", tcellopt.Cellopt_WIPEntryDt = '" & strTranfDt & "' " & Environment.NewLine
                strSql &= ", cstincomingdata.salvageSold = 1 " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tcellopt.Device_ID  " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = cstincomingdata.Device_ID  " & Environment.NewLine
                strSql &= "AND tdevice.device_id in (" & strDevice_IDs & ");"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                '******************************
                '4:: Create Manifest
                '******************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                strSql = "SELECT device_sn as 'Serial Number', Model_Desc as 'Model', " & Environment.NewLine
                strSql &= "'" & strWO_Name & "' as 'WO Out'" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID IN (" & strDevice_IDs & ")" & Environment.NewLine
                strSql &= "ORDER BY Model_desc;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                objGen.CreateExelReport(dt1, 1, strManifestFileLocName, 0, 1, 3, 1, "C")

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objRec = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************
        Private Function GetBPSalvageSold_PalletShip_ID(ByVal iCust_ID As Integer, _
                                                        ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT  tpallett.Pallett_ID, tship.Ship_ID  " & Environment.NewLine
                strSql &= "FROM tpallett  " & Environment.NewLine
                strSql &= "INNER JOIN tship ON tpallett.Pallett_ID = tship.ShipPallett " & Environment.NewLine
                strSql &= "WHERE Pallett_Name = 'SALVAGE_SOLD' " & Environment.NewLine
                strSql &= "AND tpallett.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND tpallett.Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************

    End Class
End Namespace

