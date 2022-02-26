Option Explicit On 

Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Drawing.Printing

Namespace Buisness
    Public Class Misc
        Private ObjLib As MyLib.Utility
        Private Const strFolderPath As String = "C:\Documents and Settings\All Users\Application Data\"
        Private Const strFolder As String = "PssNetWC"
        Private Const strFilePath As String = "C:\Documents and Settings\All Users\Application Data\PssNetWC\"
        Private Const strSummaryFilePathForFloor As String = "C:\WC Reports\WCSummary_"
        Private Const strFile As String = "WC.INI"
        Private strSql As String = ""
        Private strGroupBy As String = ""
        Public strRptDir As String = "R:\USA Mobility WO Reports\USAMobilityWORpt_" & Now.Month & Now.Day & Now.Year & Now.Hour & Now.Minute & Now.Second & ".xls"

        Private strCellStarQCRepDir As String = "R:\CELLSTAR\Cellstar QC Reports\"
        Private strFileName As String = ""
        Private _objDataProc As DBQuery.DataProc


        '***************************************************
        Private Shared strUser As String = ""
        Public Shared Property _CurUser() As String
            Get
                Return strUser
            End Get
            Set(ByVal Value As String)
                strUser = Value
            End Set
        End Property

        Private Shared strDisposition As String = ""
        Public Shared Property _Disposition() As String
            Get
                Return strDisposition
            End Get
            Set(ByVal Value As String)
                strDisposition = Value
            End Set
        End Property

        Private Shared strWorkDt As String = ""
        Public Shared Property WorkDt() As String
            Get
                Return strWorkDt
            End Get
            Set(ByVal Value As String)
                strWorkDt = Value
            End Set
        End Property

        'WYZE Security Devices
        Public Shared ReadOnly Property WYZE_Cust_ID() As Integer
            Get
                Return 2623
            End Get
        End Property

        Public Shared ReadOnly Property WYZE_Loc_ID() As Integer
            Get
                Return 4482
            End Get
        End Property

        Public Shared ReadOnly Property WYZE_MCode_ID() As Integer
            Get
                Return 89
            End Get
        End Property

        Public Function CheckSNPalletized(ByVal iCust_id As Integer, _
                                          ByVal strSN As String) As Boolean
            Dim dr As DataRow
            Dim booResult As Boolean = False

            Try
                strSql = "select count(*) as cnt from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join tworkorder on tworkorder.wo_id = tdevice.wo_id " & Environment.NewLine
                strSql &= "where device_sn = '" & strSN & "' " & Environment.NewLine
                strSql &= "and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= "and pallett_id is not null " & Environment.NewLine
                strSql &= "and cust_id = " & iCust_id.ToString

                dr = Me._objDataProc.GetDataRow(strSql)

                'True = palletized; False = not palletized 
                If Not IsNothing(dr) Then
                    If dr("cnt") > 0 Then booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        '***************************************************
        Public Function CheckOpenSN(ByVal iCust_id As Integer, _
                                     ByVal strSN As String) As Boolean
            Dim dr As DataRow
            Dim booResult As Boolean = False

            Try
                strSql = "select count(*) as cnt from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join tworkorder on tworkorder.wo_id = tdevice.wo_id " & Environment.NewLine
                strSql &= "where device_sn = '" & strSN & "' " & Environment.NewLine
                strSql &= "and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= "and cust_id = " & iCust_id.ToString

                dr = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(dr) Then
                    If dr("cnt") > 0 Then booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function


        '***************************************************
        Public Function ChangeSN(ByVal iCust_ID As Integer, _
                                ByVal iDevice_ID As Integer, _
                                ByVal strNewSN As String, _
                                ByVal strSNType As String, _
                                ByVal strDevice_OldSN As String) As Integer

            Dim strsql As String = ""
            Dim i As Integer = 0

            Try
                If iCust_ID = 2113 Then     'Brightpoint Customer
                    strsql = "Update cstincomingdata " & Environment.NewLine
                    strsql &= "set cstincomingdata.csin_RepESN = '" & strNewSN & "' " & Environment.NewLine
                    strsql &= "where cstincomingdata.Device_ID = " & iDevice_ID.ToString

                    i = Me._objDataProc.ExecuteNonQuery(strsql)
                End If

                strsql = "Update tdevice, tcellopt " & Environment.NewLine

                strsql &= "set " & Environment.NewLine
                If Trim(strDevice_OldSN) = "" Then
                    strsql &= "tdevice.Device_OldSN = Device_SN, " & Environment.NewLine
                End If
                strsql &= "tdevice.Device_SN = '" & strNewSN & "' " & Environment.NewLine

                If strSNType <> "Non-Cellular SN" Then
                    If strSNType = "IMEI" Then
                        strsql &= ", tcellopt.CellOpt_OutIMEI = '" & strNewSN & "' " & Environment.NewLine
                    End If
                    If strSNType = "MSN" Then
                        strsql &= ", tcellopt.CellOpt_OutMSN = '" & strNewSN & "' " & Environment.NewLine
                    End If
                    If strSNType = "Decimal" Then
                        strsql &= ", tcellopt.CellOpt_CSN_Dec = '" & strNewSN & "' " & Environment.NewLine
                    End If
                    If strSNType = "ESN" Then
                        strsql &= ", tcellopt.CellOpt_OutCSN = '" & strNewSN & "' " & Environment.NewLine
                    End If
                End If

                strsql &= "where " & Environment.NewLine
                strsql &= "tdevice.device_id = tcellopt.device_id and " & Environment.NewLine
                strsql &= "tdevice.Device_ID = " & iDevice_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function DeletePallet(ByVal iPallet_ID As Integer)
            Dim R1 As DataRow
            Dim strsql As String = ""

            Try
                strsql = "Select Count(*) as cnt from tdevice where pallett_id = " & iPallet_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strsql)

                If R1("cnt") = 0 Then
                    'delete pallett
                    strsql = "Delete from tpallett where pallett_id = " & iPallet_ID.ToString & " and Pallett_ShipDate is NULL"

                    Return Me._objDataProc.ExecuteNonQuery(strsql)
                Else
                    Throw New Exception("This pallet still has devices assigned. Can not delete it until all devices are removed.")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        Public Function IsQCCheckNeeded(ByVal strSN As String) As Integer
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                strSql = "Select tworkorder.WO_ID, tworkorder.WO_NoQC " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "where device_sn = '" & strSN & "' and " & Environment.NewLine
                strSql &= "device_dateship is null " & Environment.NewLine
                strSql &= "Order by tworkorder.WO_ID desc"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then i = R1("Wo_NoQC")

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        Public Sub CheckDeviceQC(ByVal strDeviceSN As String)
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim strQCType As String = ""

            Try
                For i = 1 To 3
                    Select Case i
                        Case 1
                            strQCType = "Functional"
                        Case 2
                            strQCType = "FQA"
                        Case 3
                            strQCType = "Cosmetic"
                    End Select

                    strSql = "Select tqc.device_id from tqc " & Environment.NewLine
                    strSql &= "inner join tdevice on tqc.device_id = tdevice.device_id " & Environment.NewLine
                    strSql &= "where device_sn = '" & strDeviceSN & "' and " & Environment.NewLine
                    strSql &= "device_dateship is null and " & Environment.NewLine
                    strSql &= "QCResult_ID = 1 and " & Environment.NewLine
                    strSql &= "qctype_id = " & i.ToString

                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Device has not been QC PASSED in " & strQCType & " Test.")
                    End If

                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '***************************************************
        Public Function IsQCPassedByQCType(ByVal strDeviceSN As String, _
                                           ByVal iQCType As Integer) As Boolean
            Dim dt1 As DataTable

            Try
                strSql = "Select tqc.device_id from tqc " & Environment.NewLine
                strSql &= "inner join tdevice on tqc.device_id = tdevice.device_id " & Environment.NewLine
                strSql &= "where device_sn = '" & strDeviceSN & "' and " & Environment.NewLine
                strSql &= "device_dateship is null and " & Environment.NewLine
                strSql &= "QCResult_ID = 1 and " & Environment.NewLine
                strSql &= "qctype_id = " & iQCType.ToString

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
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

        '***************************************************
        Public Function LoadWIPTransferSummary(Optional ByVal strDailyDt As String = "") As String
            Dim R1 As DataRow
            Dim dt1 As DataTable
            Dim strSummary As String = ""
            Dim strWeeklyDate As String = Format(DateAdd(DateInterval.Day, -7, Now), "yyyy-MM-dd")
            Dim strPrevGroup As String = ""
            Dim iTotal As Integer = 0

            Try
                strSql = "Select lgroups.Group_Desc, tmodel.Model_Desc, count(*) as cnt " & Environment.NewLine
                strSql &= "from twarehousereceive  " & Environment.NewLine
                strSql &= "inner join twarehousepallet on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strSql &= "inner join tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "inner join lgroups on twarehousereceive.WHR_WIPOwner = lgroups.Group_ID " & Environment.NewLine

                If strDailyDt = "" Then      'Weekly
                    strSql &= "where twarehousereceive.WHR_TransferDt > '" & strWeeklyDate & "' and " & Environment.NewLine
                Else                            'Daily
                    strSql &= "where twarehousereceive.WHR_TransferDt = '" & strDailyDt & "' and " & Environment.NewLine
                End If

                strSql &= "twarehousereceive.WHR_WIPOwner is not null " & Environment.NewLine
                strSql &= "group by lgroups.Group_Desc, tmodel.Model_Desc " & Environment.NewLine
                strSql &= "order by lgroups.Group_Desc, tmodel.Model_Desc"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    If Trim(UCase(strPrevGroup)) <> Trim(UCase(R1("Group_Desc"))) Then
                        'Write Group name
                        If strPrevGroup = "" Then
                            If strDailyDt <> "" Then
                                strSummary &= "DAILY:" & Environment.NewLine
                                strSummary &= Environment.NewLine
                            Else
                                strSummary &= "WEEKLY:" & Environment.NewLine
                                strSummary &= Environment.NewLine
                            End If
                        End If
                        strSummary &= Environment.NewLine
                        strSummary &= Trim(R1("Group_Desc")) & Environment.NewLine
                        strSummary &= "----------------------" & Environment.NewLine
                    End If

                    'Write Model Name and Quantity
                    strSummary &= Trim(R1("Model_Desc")) & vbTab & vbTab & " = " & vbTab & CStr(R1("cnt")) & Environment.NewLine
                    strPrevGroup = R1("Group_Desc")

                    iTotal += R1("cnt")
                Next R1

                'Total
                strSummary &= "__________________________" & Environment.NewLine
                strSummary &= Environment.NewLine
                strSummary &= "TOTAL = " & iTotal.ToString

                Return strSummary
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

        '***************************************************
        Public Function CheckPalletAlreadyAssigned(ByVal strSN As String) As Integer
            Dim R1 As DataRow
            Dim dt1 As DataTable

            Try
                strSql = "Select Device_ID, Device_datebill, Device_Dateship, Pallett_ID from tdevice where device_sn = '" & strSN & "' and device_dateship is null order by Device_ID Desc"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If IsNothing(R1) Then
                    Throw New Exception("IMEI does not exist in the database.")
                End If

                If IsDBNull(R1("Device_datebill")) Then
                    Throw New Exception("Device not billed.")
                Else
                    If Trim(R1("Device_datebill")) = "0000-00-00 00:00:00" Or Len(Trim(R1("Device_datebill"))) = 0 Then
                        Throw New Exception("Device not billed.")
                    End If
                End If

                If Not IsDBNull(R1("Device_Dateship")) Then
                    If Len(Trim(R1("Device_Dateship"))) <> 0 Then
                        Throw New Exception("Device already shipped.")
                    End If
                End If

                If IsDBNull(R1("Pallett_ID")) Then
                    Return 1        'Pallet not assigned yet
                Else
                    Return 0        'Pallet already assigned
                End If
            Catch ex As Exception
                Throw New Exception("CheckPalletAlreadyAssigned: " & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try

        End Function
        '***************************************************
        Public Function LoadCellProductionNumbersByModel(ByVal strWorkDate As String, _
                                        ByVal iLine_ID As Integer, _
                                        ByVal iDailyWeekly As Integer, _
                                        Optional ByVal iGroup_ID As Integer = 0) As DataTable
            Dim strWeekStartDate As String = ""
            Dim strWeekEndDate As String = ""

            Try
                If iDailyWeekly = 1 Then
                    strWeekStartDate = Format(DateAdd(DateInterval.Day, +1, ObjLib.GetLastSunday), "yyyy-MM-dd")    'Monday
                    strWeekEndDate = Format(DateAdd(DateInterval.Day, +7, ObjLib.GetLastSunday), "yyyy-MM-dd")      'Sunday
                End If
                strSql = "Select tmodel.Model_ID, tmodel.model_desc as Model, Count(*) as 'Count' " & Environment.NewLine
                strSql += "from tdailyproduction " & Environment.NewLine
                '**********************************************************
                'added by lan on 07/19/2007 to display only the good units
                '**********************************************************
                If iGroup_ID = 14 Then
                    strSql += "inner join tpallett on tdailyproduction.pallett_id = tpallett.pallett_id " & Environment.NewLine
                End If
                '**********************************************************
                strSql += "inner join tdevice on tdevice.device_id = tdailyproduction.Device_ID " & Environment.NewLine
                strSql += "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine

                'strSql += "where DP_Date = '" & strWorkDate & "' and " & Environment.NewLine
                If iDailyWeekly = 0 Then          'Daily
                    strSql += "where DP_Date = '" & strWorkDate & "' and " & Environment.NewLine
                ElseIf iDailyWeekly = 1 Then        'Weekly
                    strSql += "where DP_Date >= '" & strWeekStartDate & "' and DP_Date <= '" & strWeekEndDate & "' and " & Environment.NewLine
                End If

                '**********************************************************
                'added by lan on 07/19/2007 to display only the good units
                '**********************************************************
                If iGroup_ID = 14 Then
                    strSql += "tpallett.Pallet_ShipType = 0 and " & Environment.NewLine
                End If
                '**********************************************************

                strSql += "Line_ID = " & iLine_ID & " " & Environment.NewLine
                strSql += "group by Model_Desc " & Environment.NewLine
                strSql += "Order by Model_Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try

        End Function
        '***************************************************
        Public Function LoadCellProductionNumbers(ByVal strWorkDate As String, _
                                                ByVal iGroup_ID As Integer, _
                                                ByVal iDailyWeekly As Integer) As DataTable
            Dim strWeekStartDate As String = ""
            Dim strWeekEndDate As String = ""

            Try
                If iDailyWeekly = 1 Then
                    strWeekStartDate = Format(DateAdd(DateInterval.Day, +1, ObjLib.GetLastSunday), "yyyy-MM-dd")    'Monday
                    strWeekEndDate = Format(DateAdd(DateInterval.Day, +7, ObjLib.GetLastSunday), "yyyy-MM-dd")      'Sunday
                End If

                strSql = "Select tdailyproduction.*, security.tusers.Shift_ID " & Environment.NewLine
                strSql += "from tdailyproduction " & Environment.NewLine

                '**********************************************************
                'added by lan on 07/19/2007 to display only the good units
                '**********************************************************
                If iGroup_ID = 14 Then
                    strSql += "inner join tpallett on tdailyproduction.pallett_id = tpallett.pallett_id " & Environment.NewLine
                End If
                '**********************************************************

                strSql += "inner join security.tusers on tdailyproduction.User_ID = security.tusers.user_id " & Environment.NewLine
                If iDailyWeekly = 0 Then          'Daily
                    strSql += "where DP_Date = '" & strWorkDate & "' and " & Environment.NewLine
                ElseIf iDailyWeekly = 1 Then        'Weekly
                    strSql += "where DP_Date >= '" & strWeekStartDate & "' and DP_Date <= '" & strWeekEndDate & "' and " & Environment.NewLine
                End If

                '**********************************************************
                'added by lan on 07/19/2007 to display only the good units
                '**********************************************************
                If iGroup_ID = 14 Then
                    strSql += "tpallett.Pallet_ShipType = 0 and " & Environment.NewLine
                End If
                '**********************************************************

                strSql += "tdailyproduction.Group_ID = " & iGroup_ID.ToString & " " & Environment.NewLine
                strSql += "order by Line_ID, User_ID, Device_ID"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function DeviceHasPallet(ByVal strSN As String)
            Dim strSql As String
            Dim R1 As DataRow

            Try
                strSql = "Select Count(*) as cnt from tdevice where device_sn = '" & strSN & "' and device_dateship is null and Pallett_ID is not null"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    Return R1("cnt")
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        Public Function ReopenPallet(ByVal strPalletName As String) As Integer
            Try
                strSql = "update tpallett inner join tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql += "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql += "where tpallett.Pallett_Name = '" & strPalletName & "' and tdevice.Device_DateShip is NULL and Pallett_ReadyToShipFlg = 1"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function ReopenPallet(ByVal iPallettID As Integer) As Integer
            Try
                strSql = "update tpallett inner join tdevice on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql += "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql += "where tpallett.Pallett_ID = " & iPallettID & " and tdevice.Device_DateShip is NULL and Pallett_ReadyToShipFlg = 1"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function RemoveSNfromPallet(ByVal iPallettID As Integer, _
                                            Optional ByVal strSN As String = "") As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iDevice_ID As Integer = 0
            Dim i As Integer = 0

            Try
                If strSN.Trim.Length > 0 Then
                    'STEP 1: Get Device_ID
                    strSql = "Select Device_ID from tdevice where device_sn = '" & strSN & "' and Device_Dateship is null and Pallett_ID = " & iPallettID.ToString & " order by Device_ID Desc"

                    R1 = Me._objDataProc.GetDataRow(strSql)

                    If Not IsNothing(R1) Then
                        iDevice_ID = R1("Device_ID")
                    Else
                        Throw New Exception("IMEI does not exist on the selected pallet or box!")
                    End If

                    'STEP 2: Update tdailyproduction
                    strSql = "Delete from tdailyproduction where device_id = " & iDevice_ID.ToString

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then
                        MsgBox("Device was not removed from daily production numbers.")
                    End If

                    'STEP 3: Update tdveice table
                    strSql = "Update tdevice set Pallett_ID = NULL where pallett_id = " & iPallettID.ToString & " and device_id = " & iDevice_ID.ToString & " and device_dateship is null"

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
                            MsgBox("Device (Device_id = " & iDevice_ID.ToString & ") was not removed from daily production numbers.")
                        End If
                    Next R1

                    'STEP 3: Update tdevice table
                    strSql = "Update tdevice set Pallett_ID = NULL where pallett_id = " & iPallettID.ToString

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

        Public Sub PrintPalletDeviceCountRpt(ByVal iPallett_ID As Integer, _
                                            ByVal iCust_id As Integer, _
                                            Optional ByVal iNumCopies As Integer = 1)
            Dim objShipPalRpt As ShipPalletReport

            Try
                objShipPalRpt = New ShipPalletReport(iCust_id, iPallett_ID, iNumCopies)

                objShipPalRpt.GetCrystalReportOutput()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function ClosePallet(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String, _
                                    ByVal iPalletQty As Integer, _
                                    ByVal iPalletShipType As Integer, _
                                    Optional ByVal iPrtLicensePlateQty As Integer = 0, _
                                    Optional ByVal strManifestRptTitle As String = "") As Integer

            Dim strRptFilePath As String = String.Empty
            Dim booPrtPalletManifest As Boolean = False

            Try
                'STEP Prepare FilePath for SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, SkyTel.Propage_CUSTOMER_ID
                Select Case iCust_ID
                    Case SkyTel.SKYTEL_CUSTOMER_ID
                        strRptFilePath = SkyTel.SKYTEL_MANIFEST_DIR
                    Case SkyTel.MorrisCom_CUSTOMER_ID
                        strRptFilePath = SkyTel.MorrisCom_MANIFEST_DIR
                    Case SkyTel.Propage_CUSTOMER_ID
                        strRptFilePath = SkyTel.Propage_MANIFEST_DIR
                    Case SkyTel.Aquis_CUSTOMER_ID
                        strRptFilePath = SkyTel.Aquis_MANIFEST_DIR
                    Case SkyTel.CookPager_CUSTOMER_ID
                        strRptFilePath = SkyTel.CookPager_MANIFEST_DIR
                    Case AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID
                        strRptFilePath = AMSInfraStructure.AMSInfraStructure_MANIFEST_DIR
                        booPrtPalletManifest = True
                    Case SkyTel.ContactWireless_CUSTOMER_ID
                        strRptFilePath = SkyTel.ContactWireless_MANIFEST_DIR
                        booPrtPalletManifest = True
                    Case SkyTel.AMS_CUSTOMER_ID
                        strRptFilePath = SkyTel.AMS_MANIFEST_DIR
                    Case SkyTel.A1WirelessComm_CUSTOMER_ID
                        strRptFilePath = SkyTel.A1WirelessComm_MANIFEST_DIR
                    Case SkyTel.CriticalAlert_CUSTOMER_ID
                        strRptFilePath = SkyTel.CriticalAlert_MANIFEST_DIR
                    Case SkyTel.Anna_CUSTOMER_ID
                        strRptFilePath = SkyTel.Anna_MANIFEST_DIR
                    Case SkyTel.Lahey_CUSTOMER_ID
                        strRptFilePath = SkyTel.Lahey_MANIFEST_DIR
                    Case SkyTel.Masco_CUSTOMER_ID
                        strRptFilePath = SkyTel.Masco_MANIFEST_DIR
                    Case SkyTel.Franciscan_CUSTOMER_ID
                        strRptFilePath = SkyTel.Franciscan_MANIFEST_DIR
                    Case SkyTel.Maine_CUSTOMER_ID
                        strRptFilePath = SkyTel.Maine_MANIFEST_DIR
                    Case SkyTel.SMHC_CUSTOMER_ID
                        strRptFilePath = SkyTel.SMHC_MANIFEST_DIR
                    Case SkyTel.ATS_CUSTOMER_ID
                        strRptFilePath = SkyTel.ATS_MANIFEST_DIR
                End Select

                'STEP 1:: 
                Select Case iCust_ID
                    Case 2019  'ATCLE-AWS
                        CreateExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2113   'Brightpoint
                        CreateCellstarExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2219   'Gamestop
                        CreateGamestopExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2238   'Trimble Mobile Solutions
                        CreateTrimbleExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2245   'Liquidity Services/Dyscern
                        CreateDyscernExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2242, 2259, 2278  'Sonitrol, 'PSS Exchange
                        CreateSonitrolExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2249   'Demo customer
                        CreateExcelFile(iCust_ID, iPallet_ID, strpalletName, "P:\Dept\Demo\Pallet packing list\")
                    Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, _
                         SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID, _
                         SkyTel.CookPager_CUSTOMER_ID, SkyTel.AMS_CUSTOMER_ID, _
                         AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID, _
                         SkyTel.ContactWireless_CUSTOMER_ID, _
                         SkyTel.A1WirelessComm_CUSTOMER_ID, _
                         SkyTel.CriticalAlert_CUSTOMER_ID, _
                         SkyTel.Anna_CUSTOMER_ID, _
                         SkyTel.Lahey_CUSTOMER_ID, _
                         SkyTel.Masco_CUSTOMER_ID, _
                         SkyTel.Franciscan_CUSTOMER_ID, _
                         SkyTel.Maine_CUSTOMER_ID, _
                         SkyTel.SMHC_CUSTOMER_ID, _
                         SkyTel.ATS_CUSTOMER_ID

                        SkyTel.CreateShipManifestReport(iPallet_ID, strpalletName, strRptFilePath, strManifestRptTitle, booPrtPalletManifest, iPalletShipType)
                    Case 2254    'Plexus Corp.
                        CreatePlexusExcelFile(iCust_ID, iPallet_ID, strpalletName)
                        'Case 2258    'TracFone
                        'CreateTracFoneExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case 2254    'Plexus Corp.
                        CreatePlexusExcelFile(iCust_ID, iPallet_ID, strpalletName)
                    Case Else
                        '''
                End Select

                'STEP 2::
                If iPrtLicensePlateQty > 0 Then
                    PrintPalletDeviceCountRpt(iPallet_ID, iCust_ID, iPrtLicensePlateQty)
                End If

                'STEP 3:: 
                'Set the pallet ready to ship
                strSql = "update tpallett set Pallett_ReadyToShipFlg = 1, Pallett_QTY = " & iPalletQty & ", AQL_QCResult_ID = 0 where pallett_id = " & iPallet_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************
        Public Function IsPalletClosed(ByVal iPallet_ID As Integer) As Integer
            Dim dt1 As DataTable
            Dim Pallett_ReadyToShipFlg As Integer = 0

            Try
                strSql = "SELECT Pallett_ReadyToShipFlg FROM tpallett WHERE  Pallett_ID = " & iPallet_ID.ToString

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    Pallett_ReadyToShipFlg = dt1.Rows(0)("Pallett_ReadyToShipFlg")
                Else
                    Pallett_ReadyToShipFlg = -1
                End If

                Return Pallett_ReadyToShipFlg
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '****************************************************
        Public Sub CreateSonitrolExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String)
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = "P:\Dept\Sonitrol\Pallet packing list\"
            Dim strFileName As String = strpalletName & ".xls"
            Dim strRptPath As String = strRptDir & strFileName

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim R1 As DataRow
            Dim strRURType As String

            Try
                If iCust_ID = 2259 Then
                    strRptPath = "P:\Dept\PSS Exchange\Pallet packing list\" & strFileName
                ElseIf iCust_ID = 2278 Then
                    strRptPath = "P:\Dept\Advantor Systems\Pallet packing list\" & strFileName
                End If
                '******************************************************************
                'Get the Serial Numbers
                strSql = "SELECT tdevice.Device_ID, WO_CustWO, Device_SN, Pallett_Name, Pallet_ShipType, sd_CustSN, sd_RMA, Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tsonitroldata on tdevice.device_id = tsonitroldata.device_id " & Environment.NewLine
                strSql &= "WHERE tpallett.pallett_id = " & iPallet_ID & " order by Device_sn;"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                objExcel.Application.Cells(i, 2).Value = "PO"
                objExcel.Application.Cells(i, 3).Value = "Model"
                objExcel.Application.Cells(i, 4).Value = "RMA"
                objExcel.Application.Cells(i, 5).Value = "Board SN"
                objExcel.Application.Cells(i, 6).Value = "SN"
                objExcel.Application.Cells(i, 7).Value = "Result"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 23
                objSheet.Columns("B:B").ColumnWidth = 12
                objSheet.Columns("C:C").ColumnWidth = 12        'Need to change this
                objSheet.Columns("D:D").ColumnWidth = 20
                objSheet.Columns("E:E").ColumnWidth = 15
                objSheet.Columns("F:F").ColumnWidth = 15        'Need to change this
                objSheet.Columns("G:G").ColumnWidth = 20        'Need to change this
                '*****************************************
                'Set alignments
                '*****************************************
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft
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
                objSheet.Columns("G:G").Select()
                objExcel.Selection.NumberFormat = "@"
                '*****************************************
                'format header
                '*****************************************
                objSheet.Range("A1:G1").Select()
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
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("Pallett_Name"))
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("WO_CustWO"))
                    objExcel.Application.Cells(i, 3).Value = Trim(R1("Model_Desc"))
                    objExcel.Application.Cells(i, 4).Value = Trim(R1("sd_RMA"))
                    objExcel.Application.Cells(i, 5).Value = Trim(R1("sd_CustSN"))
                    objExcel.Application.Cells(i, 6).Value = Trim(R1("Device_sn"))

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                objExcel.Application.Cells(i, 7).Value = "Refurbished"
                            Case 1  'RUR
                                'objExcel.Application.Cells(i, 6).Value = "RUR"
                                strRURType = Me.GetRURBillCodeDesc(R1("Device_ID"))
                                If strRURType.Trim = "" Then
                                    objExcel.Application.Cells(i, 7).Value = "RUR"
                                Else
                                    objExcel.Application.Cells(i, 7).Value = strRURType.Trim
                                End If
                        End Select
                    End If

                    strRURType = ""
                    i += 1
                Next R1

                '*****************************************
                'Write Total Line   
                '*****************************************
                i += 1
                objExcel.Application.Cells(i, 1).Value = "Total Count = " & dt1.Rows.Count
                'objSheet.Range("A1:B1").Select()
                objSheet.Range("A" & i & ":G" & i).Select()
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
                objSheet.Range("A1:G" & (dt1.Rows.Count + 1)).Select()
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
                ''************************************************
                ''Set the Barcode Font
                'objSheet.Range("B2:B" & (dt1.Rows.Count + 1)).Select()
                'With objExcel.Selection
                '    .Font.Name = "C39P12DhTt"
                'End With
                ''************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
                    '.BlackAndWhite = False
                    .Zoom = 100
                    .FitToPagesWide = 1
                    .FitToPagesTall = 1
                End With

                '*************************************************
                objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
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

        '****************************************************
        Public Sub CreatePlexusExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String)
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = "P:\Dept\Plexus\Pallet packing list\"
            Dim strFileName As String = strpalletName & ".xls"
            Dim strRptPath As String = strRptDir & strFileName

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim R1 As DataRow
            Dim strRURType As String

            Try
                '******************************************************************
                'Get the Serial Numbers
                strSql = "SELECT tdevice.Device_ID, WO_CustWO, Device_SN, Pallett_Name, Pallet_ShipType, sd_CustSN, sd_RMA, Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tsonitroldata on tdevice.device_id = tsonitroldata.device_id " & Environment.NewLine
                strSql &= "WHERE tpallett.pallett_id = " & iPallet_ID & " order by Device_sn;"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                objExcel.Application.Cells(i, 2).Value = "PO"
                objExcel.Application.Cells(i, 3).Value = "Model"
                objExcel.Application.Cells(i, 4).Value = "RMA"
                objExcel.Application.Cells(i, 5).Value = "Board SN"
                objExcel.Application.Cells(i, 6).Value = "SN"
                objExcel.Application.Cells(i, 7).Value = "Result"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 23
                objSheet.Columns("B:B").ColumnWidth = 12
                objSheet.Columns("C:C").ColumnWidth = 12        'Need to change this
                objSheet.Columns("D:D").ColumnWidth = 20
                objSheet.Columns("E:E").ColumnWidth = 15
                objSheet.Columns("F:F").ColumnWidth = 15        'Need to change this
                objSheet.Columns("G:G").ColumnWidth = 20        'Need to change this
                '*****************************************
                'Set alignments
                '*****************************************
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft
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
                objSheet.Columns("G:G").Select()
                objExcel.Selection.NumberFormat = "@"
                '*****************************************
                'format header
                '*****************************************
                objSheet.Range("A1:G1").Select()
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
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("Pallett_Name"))
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("WO_CustWO"))
                    objExcel.Application.Cells(i, 3).Value = Trim(R1("Model_Desc"))
                    objExcel.Application.Cells(i, 4).Value = Trim(R1("sd_RMA"))
                    objExcel.Application.Cells(i, 5).Value = Trim(R1("sd_CustSN"))
                    objExcel.Application.Cells(i, 6).Value = Trim(R1("Device_sn"))

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'PASSED
                                objExcel.Application.Cells(i, 7).Value = "PASSED"
                            Case 1  'FAILED
                                'objExcel.Application.Cells(i, 6).Value = "RUR"
                                strRURType = Me.GetRURBillCodeDesc(R1("Device_ID"))
                                If strRURType.Trim = "" Then
                                    objExcel.Application.Cells(i, 7).Value = "FAILED"
                                Else
                                    objExcel.Application.Cells(i, 7).Value = strRURType.Trim
                                End If
                        End Select
                    End If

                    strRURType = ""
                    i += 1
                Next R1

                '*****************************************
                'Write Total Line   
                '*****************************************
                i += 1
                objExcel.Application.Cells(i, 1).Value = "Total Count = " & dt1.Rows.Count
                'objSheet.Range("A1:B1").Select()
                objSheet.Range("A" & i & ":G" & i).Select()
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
                objSheet.Range("A1:G" & (dt1.Rows.Count + 1)).Select()
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
                ''************************************************
                ''Set the Barcode Font
                'objSheet.Range("B2:B" & (dt1.Rows.Count + 1)).Select()
                'With objExcel.Selection
                '    .Font.Name = "C39P12DhTt"
                'End With
                ''************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
                    '.BlackAndWhite = False
                    .Zoom = 100
                    .FitToPagesWide = 1
                    .FitToPagesTall = 1
                End With

                '*************************************************
                objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
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

        '****************************************************
        Public Sub CreateDriveCamExcelFile(ByVal iPallet_ID As Integer, _
                                           ByVal strpalletName As String, _
                                           ByVal strReportPath As String)
            'Excel Related variables
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strFileName As String = strpalletName & ".xls" '".xlsx" '".xls"

            Dim i As Integer = 1
            Dim dt1, dtLoc As DataTable
            Dim R1 As DataRow
            Dim strRURType As String
            Dim iBillRule As Integer = 0

            Try
                strReportPath &= strFileName
                '******************************************************************
                'Get Location Address
                strSql = "SELECT Distinct Loc_Address1, if(Loc_Address2 is null, '', Loc_Address2) as Loc_Address2 " & Environment.NewLine
                strSql &= ", Loc_City, lstate.State_Short,  Loc_Zip " & Environment.NewLine
                strSql &= ", IF(Loc_Phone is null, '', Loc_Phone) as Loc_Phone " & Environment.NewLine
                strSql &= ", IF( Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2) ) as 'CustomerName' " & Environment.NewLine
                strSql &= ", IF(tlocation.Loc_Email is null, '', tlocation.Loc_Email) as Loc_Email " & Environment.NewLine
                strSql &= "FROM tpallett  " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tpallett.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tlocation.State_ID = lstate.State_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPallet_ID & Environment.NewLine
                dtLoc = Me._objDataProc.GetDataTable(strSql)

                '******************************************************************
                'Get the Serial Numbers
                strSql = "SELECT Distinct tdevice.Device_ID, Device_SN, Pallett_Name, Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.pallett_id = " & iPallet_ID & " order by Device_sn;"

                dt1 = Me._objDataProc.GetDataTable(strSql)
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = True                 'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape

                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Box ID"
                objExcel.Application.Cells(i, 2).Value = "Model"
                objExcel.Application.Cells(i, 3).Value = "SN"
                objExcel.Application.Cells(i, 4).Value = "Result"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 23
                objSheet.Columns("B:B").ColumnWidth = 12
                objSheet.Columns("C:C").ColumnWidth = 12        'Need to change this
                objSheet.Columns("D:D").ColumnWidth = 20
                '*****************************************
                'Set alignments
                '*****************************************
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft
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
                objSheet.Range("A" & i & ":D" & i).Select()
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
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("Pallett_Name"))
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("Model_Desc"))
                    objExcel.Application.Cells(i, 3).Value = Trim(R1("Device_sn"))

                    iBillRule = Generic.GetMaxBillRule(R1("Device_ID"))
                    If iBillRule < 0 Then
                        Throw New Exception("Bill Rule is missing.")
                    ElseIf iBillRule = 0 Then
                        objExcel.Application.Cells(i, 4).Value = "Repair"
                    Else
                        'objExcel.Application.Cells(i, 6).Value = "RUR"
                        strRURType = Me.GetRURCode(R1("Device_ID"), DriveCam.RUR_MASTER_CODEID)
                        If strRURType.Trim = "" Then
                            objExcel.Application.Cells(i, 4).Value = "RUR"
                        Else
                            objExcel.Application.Cells(i, 4).Value = "RUR-" & strRURType.Trim
                        End If
                    End If

                    strRURType = ""
                    i += 1
                Next R1

                '*****************************************
                'Write Total Line   
                '*****************************************
                i += 1
                objExcel.Application.Cells(i, 1).Value = "Total Count = " & dt1.Rows.Count
                'objSheet.Range("A1:B1").Select()
                objSheet.Range("A" & i & ":D" & i).Select()
                With objExcel.Selection
                    '.WrapText = True
                    '.HorizontalAlignment = Excel.Constants.xlCenter
                    '.VerticalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                    .Font.Size = 12
                End With

                '*****************************************
                'Add Location address
                '*****************************************
                If dtLoc.Rows.Count > 0 Then
                    i += 1 : objExcel.Application.Cells(i, 1).Value = Trim(dtLoc.Rows(0)("CustomerName"))
                    objSheet.Range("A" & i.ToString & ":D" & i.ToString).Select() : objExcel.Selection.MergeCells = True
                    i += 1 : objExcel.Application.Cells(i, 1).Value = Trim(dtLoc.Rows(0)("Loc_Address1"))
                    objSheet.Range("A" & i & ":D" & i.ToString).Select() : objExcel.Selection.MergeCells = True

                    If dtLoc.Rows(0)("Loc_Address2").ToString.Trim.Length > 0 Then
                        i += 1 : objExcel.Application.Cells(i, 1).Value = dtLoc.Rows(0)("Loc_Address2").ToString.Trim
                        objSheet.Range("A" & i & ":D" & i.ToString).Select() : objExcel.Selection.MergeCells = True
                    End If
                    i += 1 : objExcel.Application.Cells(i, 1).Value = dtLoc.Rows(0)("Loc_City").ToString & ", " & dtLoc.Rows(0)("State_Short").ToString & " " & dtLoc.Rows(0)("Loc_Zip").ToString
                    objSheet.Range("A" & i & ":D" & i.ToString).Select() : objExcel.Selection.MergeCells = True

                    If dtLoc.Rows(0)("Loc_Phone").ToString.Trim.Length > 0 Then
                        i += 1 : objExcel.Application.Cells(i, 1).Value = dtLoc.Rows(0)("Loc_Phone").ToString.Trim
                        objSheet.Range("A" & i & ":D" & i).Select() : objExcel.Selection.MergeCells = True
                    End If
                    If dtLoc.Rows(0)("Loc_Email").ToString.Trim.Length > 0 Then
                        i += 1 : objExcel.Application.Cells(i, 1).Value = dtLoc.Rows(0)("Loc_Email").ToString.Trim
                        objSheet.Range("A" & i & ":D" & i).Select() : objExcel.Selection.MergeCells = True
                    End If
                End If

                '*****************************************
                'ADD NOTICE
                '*****************************************
                i += 2 : objExcel.Application.Cells(i, 1).Value = "Notice:"
                objExcel.Application.Cells(i + 1, 1).Value = "The wireless parameters of this device have been reset to manufacturer default settings.  For the device to function properly, load the wireless network settings specific to your organization or business prior to use."
                objSheet.Range("A" & (i + 1).ToString() & ":D" & (i + 4).ToString()).Select() : objExcel.Selection.MergeCells = True : objExcel.Selection.Wraptext = True

                objSheet.Range("A" & i & ":A" & i).Select()
                objExcel.Selection.font.bold = True

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A1:D" & (dt1.Rows.Count + 1).ToString).Select()
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
                ''************************************************
                ''Set the Barcode Font
                'objSheet.Range("B2:B" & (dt1.Rows.Count + 1)).Select()
                'With objExcel.Selection
                '    .Font.Name = "C39P12DhTt"
                'End With
                ''************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
                '*************************************************
                'Fit to page
                With objExcel.ActiveSheet.PageSetup
                    .PrintTitleRows = ""
                    .PrintTitleColumns = ""
                End With
                objExcel.ActiveSheet.PageSetup.PrintArea = ""
                Try 'just try it. Some excel does not always have this feature
                    With objExcel.ActiveSheet.PageSetup
                        .LeftHeader = "&""Arial,Bold""&14Box Manifest" & Chr(10) & "Total: " & dt1.Rows.Count.ToString
                        'If dtLoc.Rows.Count > 0 Then
                        '    .CenterHeader = "&""Arial,Bold""&12" & dtLoc.Rows(0)("Loc_Address1")
                        '    If dtLoc.Rows(0)("Loc_Address2").ToString.Trim.Length > 0 Then .CenterHeader &= Chr(10) & dtLoc.Rows(0)("Loc_Address2").ToString.Trim
                        '    .CenterHeader &= Chr(10) & dtLoc.Rows(0)("Loc_City").ToString & ", " & dtLoc.Rows(0)("State_Short").ToString & " " & dtLoc.Rows(0)("Loc_Zip").ToString
                        '    If dtLoc.Rows(0)("Loc_Phone").ToString.Trim.Length > 0 Then .CenterHeader &= Chr(10) & dtLoc.Rows(0)("Loc_Phone").ToString.Trim
                        'End If

                        .RightHeader = ""
                        .LeftFooter = ""
                        .CenterFooter = ""
                        .RightFooter = ""
                        '.LeftFooter = "** PSS Confidential **"
                        .CenterFooter = "&P of &N"
                        .RightFooter = "&D&' @'&T"
                        .HeaderMargin = -25
                        .TopMargin = 70
                        .RightMargin = -25
                        .LeftMargin = -25
                        '.PrintQuality = 600
                        .CenterHorizontally = True
                        .CenterVertically = False
                        .Orientation = Excel.XlPageOrientation.xlPortrait
                        .Draft = False
                        .PaperSize = Excel.XlPaperSize.xlPaperLetter
                        '.BlackAndWhite = False
                        .Zoom = 100
                        .FitToPagesWide = 1
                        '.FitToPagesTall = 1
                    End With
                Catch ex As Exception

                End Try

                objSheet.Cells.EntireColumn.AutoFit()
                objSheet.Cells.EntireRow.AutoFit()
                '*************************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Save the excel file
                If Len(Dir(strReportPath)) > 0 Then
                    Kill(strReportPath)
                End If

                ' objBook.SaveAs(strReportPath)

                ' objBook.Version = Excel..ExcelVersion.Excel97to2003 'Excel.XlFileFormat.xlExcel9795
                objBook.SaveAs(strReportPath, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                                   Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                'objBook.Close(SaveChanges:=False)

                '*************************************************
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
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

        '****************************************************
        Public Function GetRURBillCodeDesc(ByVal iDevice_ID As Integer) As String
            Dim strSql As String

            Try
                strSql = "SELECT BillCode_Desc " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                strSql &= "AND BillCode_Rule = 1 "
                Return Me._objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************
        Public Sub CreateDyscernExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String)
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = "P:\Dept\Dyscern\Pallet packing list\"
            Dim strFileName As String = strpalletName & ".xls"
            Dim strRptPath As String = strRptDir & strFileName

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim R1 As DataRow

            Try
                '******************************************************************
                'Get the Serial Numbers
                strSql = "SELECT Device_SN, Pallet_ShipType, dd_CustDeviceID, if(dd_UnlockCode is null, '', dd_UnlockCode) as dd_UnlockCode " & Environment.NewLine
                strSql &= "FROM tdevice inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdyscerndata on tdevice.device_id = tdyscerndata.device_id " & Environment.NewLine
                strSql &= "where tpallett.pallett_id = " & iPallet_ID & " order by Device_sn;"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                objExcel.Application.Cells(i, 1).Value = "IMEI"
                objExcel.Application.Cells(i, 2).Value = "Device ID"
                objExcel.Application.Cells(i, 3).Value = "Unlock Code"
                objExcel.Application.Cells(i, 4).Value = "Result"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 21
                objSheet.Columns("B:B").ColumnWidth = 21        'Need to change this
                objSheet.Columns("C:C").ColumnWidth = 21
                objSheet.Columns("D:D").ColumnWidth = 16        'Need to change this
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

                i += 1

                'Write data to excel file
                For Each R1 In dt1.Rows
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("Device_sn"))
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("dd_CustDeviceID"))

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                objExcel.Application.Cells(i, 3).Value = Trim(R1("dd_UnlockCode"))
                                objExcel.Application.Cells(i, 4).Value = "Refurbished"
                            Case 1  'RUR
                                objExcel.Application.Cells(i, 4).Value = "RUR"
                        End Select
                    End If

                    i += 1
                Next R1

                '*****************************************
                'Write Total Line   
                '*****************************************
                i += 1
                objExcel.Application.Cells(i, 2).Value = "Total Count = " & dt1.Rows.Count
                'objSheet.Range("A1:B1").Select()
                objSheet.Range("A" & i & ":D" & i).Select()
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
                objSheet.Range("A1:D" & (dt1.Rows.Count + 1)).Select()
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
                ''************************************************
                ''Set the Barcode Font
                'objSheet.Range("B2:B" & (dt1.Rows.Count + 1)).Select()
                'With objExcel.Selection
                '    .Font.Name = "C39P12DhTt"
                'End With
                ''************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
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

        '****************************************************
        Public Sub CreateTrimbleExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String)
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet   ' Excel Worksheet

            Dim strRptDir As String = "P:\Dept\Trimble\Pallet packing list\"
            Dim strFileName As String = strpalletName & ".xls"
            Dim strRptPath As String = strRptDir & strFileName

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim R1 As DataRow

            Try
                '******************************************************************
                'Get the Serial Numbers
                strSql = "Select Device_SN, Pallet_ShipType " & Environment.NewLine
                strSql &= "from tdevice inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "where tpallett.pallett_id = " & iPallet_ID & " order by Device_sn;"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 21
                objSheet.Columns("B:B").ColumnWidth = 21        'Need to change this
                objSheet.Columns("C:C").ColumnWidth = 28
                objSheet.Columns("D:D").ColumnWidth = 16        'Need to change this
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

                i += 1

                'Write data to excel file
                For Each R1 In dt1.Rows
                    objExcel.Application.Cells(i, 1).Value = strpalletName
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
                objSheet.Range("A1:D" & (dt1.Rows.Count + 1)).Select()
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
                objSheet.Range("C2:C" & (dt1.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With
                '************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
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

        '****************************************************
        Public Sub CreateGamestopExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String)
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = "P:\Dept\Game stop\Pallet packing list\"
            Dim strFileName As String = strpalletName & ".xls"
            Dim strRptPath As String = strRptDir & strFileName

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim R1, R2 As DataRow

            Try
                '******************************************************************
                'Get the Serial Numbers
                strSql = "Select Device_SN, Pallet_ShipType, WO_RecPalletName, tdevice.Model_ID  " & Environment.NewLine
                strSql += "from tdevice inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql += "inner join tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql += "where tpallett.pallett_id = " & iPallet_ID.ToString & " order by Device_sn"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                objExcel.Application.Cells(i, 1).Value = "Serial Barcode"
                objExcel.Application.Cells(i, 2).Value = "Serial"
                objExcel.Application.Cells(i, 3).Value = "Lot"
                objExcel.Application.Cells(i, 4).Value = "Skid"
                objExcel.Application.Cells(i, 5).Value = "SKU"
                objExcel.Application.Cells(i, 6).Value = "Return Code"

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 27
                objSheet.Columns("B:B").ColumnWidth = 22
                objSheet.Columns("C:C").ColumnWidth = 14.43
                objSheet.Columns("D:D").ColumnWidth = 13.71
                objSheet.Columns("E:E").ColumnWidth = 12.71
                objSheet.Columns("F:F").ColumnWidth = 20.43
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
                For Each R1 In dt1.Rows
                    strSql = "Select WHP_Lot, WHP_Skid, WHP_SKU, tdevice.Model_ID " & Environment.NewLine
                    strSql &= "from tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                    strSql &= "inner join twarehousepallet on tworkorder.WO_RecPalletName = twarehousepallet.WHPallet_Number " & Environment.NewLine
                    strSql &= "where device_sn = '" & Trim(R1("Device_sn")) & "'"

                    R2 = Me._objDataProc.GetDataRow(strSql)

                    objExcel.Application.Cells(i, 1).Value = "*" & Trim(R1("Device_sn")) & "*"
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("Device_sn"))

                    If Not IsDBNull(R2("WHP_Lot")) Then
                        objExcel.Application.Cells(i, 3).Value = Trim(R2("WHP_Lot"))
                    Else
                        Throw New Exception("Lot missing for this Pallet.")
                    End If

                    If Not IsDBNull(R2("WHP_Skid")) Then
                        objExcel.Application.Cells(i, 4).Value = Trim(R2("WHP_Skid"))
                    Else
                        Throw New Exception("SKID missing for this Pallet.")
                    End If

                    If Not IsDBNull(R2("WHP_SKU")) Then
                        objExcel.Application.Cells(i, 5).Value = Trim(R2("WHP_SKU"))
                    Else
                        Throw New Exception("SKU missing for this Pallet.")
                    End If

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                If R1("Model_ID") <> 1175 Then objExcel.Application.Cells(i, 6).Value = "Repaired" Else objExcel.Application.Cells(i, 6).Value = "Passed"
                            Case 1  'RUR
                                If R1("Model_ID") <> 1175 Then objExcel.Application.Cells(i, 6).Value = "Returned Defective" Else objExcel.Application.Cells(i, 6).Value = "Failed"
                            Case 8  'Scrap
                                objExcel.Application.Cells(i, 6).Value = "Salvaged for parts"
                            Case 9  'Incomplete   added by Lan 12/04/2006
                                objExcel.Application.Cells(i, 6).Value = "Incomplete Unit"
                        End Select
                    End If

                    i += 1
                    '*******************
                    R2 = Nothing
                    '*******************
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
                objSheet.Range("A1:F" & (dt1.Rows.Count + 1)).Select()
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
                objSheet.Range("A2:A" & (dt1.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With
                '************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
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
        End Sub

        '****************************************************
        Public Sub CreateCellstarExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String)
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strRptDir As String = "P:\Dept\Cellstar\Pallet packing list\"
            Dim strFileName As String = strpalletName & ".xls"
            Dim strRptPath As String = strRptDir & strFileName

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim R1 As DataRow

            Try
                '******************************************************************
                'Get the Serial Numbers
                'strSql = "Select Device_SN, Pallet_ShipType " & Environment.NewLine
                'strSql &= "from tdevice inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                'strSql &= "where tpallett.pallett_id = " & iPallet_ID & " order by Device_sn;"

                strSql = "SELECT Device_SN, Pallet_ShipType, DOBFlg, Sku_ID, NewLoadFlg, csin_ItemNum, BStockUPC, Model_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN  tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cs_dob_atob_upc_crossref ON cstincomingdata.csin_ItemNum = cs_dob_atob_upc_crossref.AStockUPC " & Environment.NewLine
                strSql &= "WHERE tpallett.pallett_id = " & iPallet_ID.ToString & " order by Device_sn"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                For Each R1 In dt1.Rows
                    objExcel.Application.Cells(i, 1).Value = strpalletName
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
                    End If

                    'Model Description
                    objExcel.Application.Cells(i, 6).Value = UCase(Trim(R1("Model_Desc")))

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
                objSheet.Range("A1:F" & (dt1.Rows.Count + 1)).Select()
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
                objSheet.Range("C2:C" & (dt1.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With
                '************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
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

        '****************************************************
        Public Sub CreateExcelFile(ByVal iCust_ID As Integer, _
                                    ByVal iPallet_ID As Integer, _
                                    ByVal strpalletName As String, _
                                    Optional ByVal strFileDir As String = "")
            'Excel Related variables
            'Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            'Dim strRptDir As String = "P:\Dept\ATCLE\Pallet packing list\"
            Dim strRptDir As String = "P:\Dept\TracFone\Pallet packing list\"
            Dim strFileName As String = ""
            Dim strRptPath As String = ""

            Dim i As Integer = 1
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                If strFileDir <> "" Then
                    strRptDir = strFileDir
                End If

                strFileName = strpalletName & ".xls"
                strRptPath = strRptDir & strFileName
                '******************************************************************
                'Get the Serial Numbers
                strSql = "Select Device_SN, Pallet_ShipType " & Environment.NewLine
                strSql += "from tdevice inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql += "where tpallett.pallett_id = " & iPallet_ID.ToString & " order by Device_sn"

                dt1 = Me._objDataProc.GetDataTable(strSql)
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
                objExcel.Application.Cells(i, 1).Value = "Pallet ID"
                objExcel.Application.Cells(i, 2).Value = "IMEI"
                objExcel.Application.Cells(i, 3).Value = "IMEI Barcode"
                objExcel.Application.Cells(i, 4).Value = "Triage Result"
                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 27
                objSheet.Columns("B:B").ColumnWidth = 21        'Need to change this
                objSheet.Columns("C:C").ColumnWidth = 28
                objSheet.Columns("D:D").ColumnWidth = 16        'Need to change this
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

                i += 1

                'Write data to excel file
                For Each R1 In dt1.Rows
                    objExcel.Application.Cells(i, 1).Value = strpalletName
                    objExcel.Application.Cells(i, 2).Value = Trim(R1("Device_sn"))
                    objExcel.Application.Cells(i, 3).Value = "*" & Trim(R1("Device_sn")) & "*"

                    If Not IsDBNull(R1("Pallet_ShipType")) Then
                        Select Case R1("Pallet_ShipType")
                            Case 0  'Refurbished
                                objExcel.Application.Cells(i, 4).Value = "Passed"
                            Case 1  'RUR
                                objExcel.Application.Cells(i, 4).Value = "Failed"
                            Case 9  'RTM
                                objExcel.Application.Cells(i, 4).Value = "Failed"
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
                objSheet.Range("A1:D" & (dt1.Rows.Count + 1)).Select()
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
                objSheet.Range("C2:C" & (dt1.Rows.Count + 1)).Select()
                With objExcel.Selection
                    .Font.Name = "C39P12DhTt"
                End With
                '************************************************
                'Add report header
                'objSheet.Range("A1:C1").Select()
                'With objExcel.Selection
                '    .MergeCells = True
                '    .HorizontalAlignment = Excel.Constants.xlLeft
                '    '.font.bold = True
                '    .Font.Size = 16
                '    .Font.Name = "Verdana"
                '    .Font.ColorIndex = 3        'Red
                'End With
                'objExcel.Application.Cells(1, 1).Value = "QC Raw Data Report"
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
                'OPen Excel File
                'objXL = New Excel.Application()
                'objXL.Workbooks.Open(strRptPath)
                'objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
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
        End Sub

        '***************************************************
        'UpdateDeviceWithPallet(strSN, iPallet_ID, strWorkDate, iUserID, iWCLocation_ID, iLine_ID, iGroup_ID)
        Public Function UpdateDeviceWithPallet(ByVal strSN As String, _
                                            ByVal iPallett_ID As Integer, _
                                            ByVal strWorkDate As String, _
                                            ByVal iUserID As Integer, _
                                            ByVal iWCLocation_ID As Integer, _
                                            ByVal iLine_ID As Integer, _
                                            ByVal iGroup_ID As Integer _
                                            ) As Integer
            Dim i As Integer = 0
            Dim R1 As DataRow
            Dim iDevice_ID As Integer = 0

            Try
                'STEP 1: Get Device_ID
                strSql = "Select Device_ID from tdevice where device_sn = '" & strSN & "' and Device_Dateship is null order by Device_ID Desc"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    iDevice_ID = R1("Device_ID")
                Else
                    Throw New Exception("IMEI does not exist in the database!")
                End If
                '*****************
                R1 = Nothing
                '*****************
                'Check if DeviceID and PallettID exists together in daily production
                strSql = "Select Count(*) as cnt from tdailyproduction where device_id = " & iDevice_ID.ToString & " and Pallett_ID = " & iPallett_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSql)

                If R1("cnt") = 0 Then
                    'STEP 2: Update tdailyproduction table
                    strSql = "insert into tdailyproduction " & Environment.NewLine
                    strSql += "(DP_Date, User_ID, WCLocation_ID, Line_ID, Group_ID, Device_ID, Pallett_ID) " & Environment.NewLine
                    strSql += "values " & Environment.NewLine
                    strSql += "('" & strWorkDate & "', " & iUserID.ToString.ToCharArray & ", " & iWCLocation_ID.ToString & ", " & iLine_ID.ToString & ", " & iGroup_ID.ToString & ", " & iDevice_ID.ToString & ", " & iPallett_ID.ToString & ")"

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    If i = 0 Then
                        MsgBox("Device could not be added to daily production.")
                    End If
                End If

                'STEP 3:    Update tdevice table
                strSql = "Update tdevice set pallett_id = " & iPallett_ID.ToString & " where device_ID = " & iDevice_ID.ToString

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function
        '***************************************************
        Public Function CheckDevice_REF_RUR_RTM(ByVal strSN As String, _
                                            ByVal strShipTypeChars As String, _
                                            ByVal iCust_ID As Integer) _
                                            As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iFlgNoParts As Integer = 0
            Dim iFlgNTF As Integer = 0
            Dim iPartsBilled As Integer = 0
            Dim iTest As Integer = 0
            Dim iPolBuff As Integer = 0
            Dim iProg As Integer = 0
            Dim strMsg As String = ""
            Dim objPreTest As PSS.Data.Buisness.PreTest
            Dim dtPreTestData As DataTable

            Try
                strSql = "Select tdevice.Device_ID, billcode_rule, BillType_ID, lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "inner join tdevicebill on tdevice.device_id = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "where tdevice.device_sn = '" & strSN & "' and device_dateship is NULL and device_datebill is not NULL " & Environment.NewLine
                strSql &= " and cust_id = " & iCust_ID.ToString & " " & Environment.NewLine
                strSql &= " order by BillCode_Rule desc"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Serial Number '" & strSN & "' does not exist in WIP or it belongs to a difference customer.")
                End If

                'ATCLE = 2019
                'GameStop = 2219
                'Brightpoint = 2113

                Select Case iCust_ID
                    Case 2019   'ATCLE-AWS
                        'Make sure Device is of right Ship Type
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars
                                Case "REF"
                                    If R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a RUR device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'RTM
                                        Throw New Exception("This is a RTM device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "RUR"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a REFURBISHED device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'RTM
                                        Throw New Exception("This is a RTM device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "RTM"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a REFURBISHED device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 1 Then     'RUR
                                        Throw New Exception("This is a RUR device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                            End Select
                        Next R1

                        'No Parts Check
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars    'Make sure RUR devices don't have any parts billed to them.
                                Case "RUR"
                                    If R1("BillType_ID") = 2 Then
                                        Throw New Exception("This is a RUR device but still has parts billed. Can't put it on this pallet.")
                                    End If
                                Case "RTM"
                                    'Make sure RTM devices don't have any parts billed to them.
                                    If R1("BillType_ID") = 2 Then
                                        Throw New Exception("This is a RTM device but still has parts billed. Can't put it on this pallet.")
                                    End If
                            End Select
                        Next R1

                        '***************************************************
                        'Added by Lan on 10/31/2007 
                        'Make sure the REF devices have  service billcodes
                        ' ( Program, Testing and Polish/Buff) billed to it.
                        '***************************************************
                        If strShipTypeChars = "REF" Then    'ATCLE-AWS Refurb Unit
                            For Each R1 In dt1.Rows
                                Select Case R1("Billcode_ID")
                                    Case 448 'Testing
                                        iTest += 1
                                    Case 447 'Polish/Buff
                                        iPolBuff += 1
                                    Case 442 'Programming
                                        iProg += 1
                                End Select
                            Next R1

                            If iTest = 0 Then
                                strMsg &= "TESTING" & Environment.NewLine
                            End If
                            If iPolBuff = 0 Then
                                strMsg &= "POLISH/BUFF" & Environment.NewLine
                            End If
                            If iProg = 0 Then
                                strMsg &= "PROGRAMMING" & Environment.NewLine
                            End If

                            If strMsg <> "" Then
                                Throw New Exception(Environment.NewLine & Environment.NewLine & "This device is missing the following service codes:" & Environment.NewLine & strMsg & "Please bill them before add into the pallet." & Environment.NewLine)
                            End If
                        End If

                        '***************************************************
                        'Added by Lan on 11/14/2007. Prestest codes validation
                        'Pretest code 2515:   'Pass
                        'Pretest code 2516:   'Fail - RF Test
                        'Pretest code 2517:   'Fail - User Interface
                        'Pretest code 2518:   'Fail - Flash
                        'Pretest code 2519:   'RUR (Liquid Intrusion)
                        'Pretest code 2520:   'RUR (Physical Damage)
                        '***************************************************
                        objPreTest = New PSS.Data.Buisness.PreTest()
                        dtPreTestData = objPreTest.GetPretestStatus_ByDeviceID(dt1.Rows(0)("Device_ID"))
                        If dtPreTestData.Rows.Count = 0 Then
                            Throw New Exception("Can not find the pretest code for device.")
                        Else
                            If Not IsDBNull(dtPreTestData.Rows(0)("Dcode_ID")) Then
                                Select Case strShipTypeChars
                                    Case "REF"
                                        If dtPreTestData.Rows(0)("Dcode_ID") <> 2515 Then
                                            Throw New Exception("This device failed at pretest. Can not put on pass pallet.")
                                        End If
                                    Case "RTM"
                                        If dtPreTestData.Rows(0)("Dcode_ID") = 2515 _
                                           Or dtPreTestData.Rows(0)("Dcode_ID") = 2519 _
                                           Or dtPreTestData.Rows(0)("Dcode_ID") = 2520 Then
                                            Throw New Exception("Device contains either Pass or RUR code. Please change it to RTM fail code before adding to " & strShipTypeChars & " pallet.")
                                        End If
                                    Case "RUR"
                                        If dtPreTestData.Rows(0)("Dcode_ID") = 2515 _
                                        Or dtPreTestData.Rows(0)("Dcode_ID") = 2516 _
                                        Or dtPreTestData.Rows(0)("Dcode_ID") = 2517 _
                                        Or dtPreTestData.Rows(0)("Dcode_ID") = 2518 Then
                                            Throw New Exception("Device contains either Pass or RTM code. Please change it to RUR fail code before adding to " & strShipTypeChars & " pallet.")
                                        End If
                                End Select
                            End If
                        End If
                        '***************************************************

                    Case 2113   'Brightpoint
                        If strShipTypeChars = "RUR" Then
                            strShipTypeChars = "BER"
                        End If
                        'Make sure Device is of right Ship Type
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars
                                Case "REF"
                                    If R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a BER (RUR) device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'RTM
                                        Throw New Exception("This is a BER (RTM) device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 10 Then      'Customer Cancelled
                                        Throw New Exception("This is a 'Customer Cancelled' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "BER"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a REFURBISHED device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 10 Then      'Customer Cancelled
                                        Throw New Exception("This is a 'Customer Cancelled' device. Can't put it on this pallet.")
                                    End If
                                Case "CAN"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a REFURBISHED device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a BER (RUR) device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'RTM
                                        Throw New Exception("This is a BER (RTM) device. Can't put it on this pallet.")
                                    End If
                            End Select
                        Next R1

                        'No Parts Check
                        For Each R1 In dt1.Rows
                            'Based on the billcode_rule
                            Select Case strShipTypeChars    'Make sure RUR devices don't have any parts billed to them.
                                Case "BER"
                                    If R1("BillType_ID") = 2 Then
                                        Throw New Exception("This is a BER device but still has parts billed. Can't put it on this pallet.")
                                    End If
                                Case "CAN"
                                    If R1("BillType_ID") = 2 Then
                                        Throw New Exception("This is a 'Customer Canceled' device but still has parts billed. Can't put it on this pallet.")
                                    End If
                            End Select

                            '*********************************************
                            'Based on Billcode_ID that should not have parts
                            Select Case R1("Billcode_ID")
                                Case 255        'No Parts
                                    iFlgNoParts = 1
                                Case 541        'NTF
                                    iFlgNTF = 1
                            End Select
                            '*********************************************
                            'Check if there are any parts billed
                            If R1("BillType_ID") = 2 Then
                                iPartsBilled = 1
                            End If
                            '*********************************************
                        Next R1

                        If iFlgNoParts = 1 And iPartsBilled = 1 Then
                            Throw New Exception("This is a 'No Parts' device and there are parts billed on it. Can't put it on this pallet.")
                        ElseIf iFlgNTF = 1 And iPartsBilled = 1 Then
                            Throw New Exception("This is a 'NTF' device and there are parts billed on it. Can't put it on this pallet.")
                        End If

                        iFlgNTF = 0
                        iFlgNoParts = 0
                        iPartsBilled = 0
                    Case 2219   'Gamestop
                        'Make sure Device is of right Ship Type
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars
                                Case "REF"
                                    If R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a 'RUR' device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 8 Then     'Scrap
                                        Throw New Exception("This is a 'Scrap' device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'Incomplete
                                        Throw New Exception("This is an 'Incomplete' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "RUR"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a 'REFURBISHED' device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 8 Then     'Scrap
                                        Throw New Exception("This is a 'Scrap' device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'Incomplete
                                        Throw New Exception("This is an 'Incomplete' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "SCR"  'SCRAP
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a 'REFURBISHED' device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 1 Then     'Scrap
                                        Throw New Exception("This is a 'RUR' device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'Incomplete
                                        Throw New Exception("This is an 'Incomplete' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "INC"  'INCOMPLETE     Added by Lan 12/04/2006
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a REFURBISHED device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 1 Then     'RUR
                                        Throw New Exception("This is a RUR device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 8 Then     'Scrap
                                        Throw New Exception("This is a 'Scrap' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                            End Select
                        Next R1
                    Case 2245   'Dyscern
                        'Make sure Device is of right Ship Type
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars
                                Case "REF"
                                    If R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a 'RUR' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "RUR"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a 'REFURBISHED' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                            End Select
                        Next R1
                    Case 2242   'Sonitrol
                        'Make sure Device is of right Ship Type
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars
                                Case "REF"
                                    If R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a 'RUR' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "RUR"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a 'REFURBISHED' device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                            End Select
                        Next R1
                    Case 2249   'HTC
                        'Make sure Device is of right Ship Type
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars
                                Case "REF"
                                    If R1("Billcode_Rule") = 1 Then         'RUR
                                        Throw New Exception("This is a RUR device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'RTM
                                        Throw New Exception("This is a RTM device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                                Case "RUR"
                                    If R1("Billcode_Rule") = 0 Then         'RFURBISHED
                                        Throw New Exception("This is a REFURBISHED device. Can't put it on this pallet.")
                                    ElseIf R1("Billcode_Rule") = 9 Then     'RTM
                                        Throw New Exception("This is a RTM device. Can't put it on this pallet.")
                                    End If
                                    Exit For
                            End Select
                        Next R1

                        'No Parts Check
                        For Each R1 In dt1.Rows
                            Select Case strShipTypeChars    'Make sure RUR devices don't have any parts billed to them.
                                Case "RUR"
                                    If R1("BillType_ID") = 2 Then
                                        Throw New Exception("This is a RUR device but still has parts billed. Can't put it on this pallet.")
                                    End If
                            End Select
                        Next R1
                End Select

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                objPreTest = Nothing
                If Not IsNothing(dtPreTestData) Then
                    dtPreTestData.Dispose()
                    dtPreTestData = Nothing
                End If
            End Try
        End Function


        '***************************************************
        'Added by Lan on 08/27/2007 
        'Check Dobson device verse RUR, RTM pallett
        Public Function CheckDOBSalvageDevice(ByVal strSN As String, ByVal iCust_ID As String) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "Select tdevice.*, csin_EnterpriseCode, Prod_ID " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "left outer join cstincomingdata on tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "where tdevice.device_sn = '" & strSN & "' and device_dateship is NULL and device_datebill is not NULL " & Environment.NewLine
                strSql &= " and cust_id = " & iCust_ID & " " & Environment.NewLine
                strSql &= " order by tdevice.Device_ID desc"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Serial Number '" & strSN & "' does not exist in WIP or it belongs to a difference customer.")
                ElseIf dt1.Rows.Count > 1 Then
                    Throw New Exception("Serial Number '" & strSN & "' exist twice in the system. Please verify it with your manager.")
                End If

                R1 = dt1.Rows(0)

                If R1("Prod_ID") = 2 Then
                    If (UCase(Trim(R1("csin_EnterpriseCode"))) = "DOB" Or UCase(Trim(R1("csin_EnterpriseCode"))) = "DBR") Then
                        Throw New Exception("This is 'Dobson' device. If you want to RUR this device please transfers it to salvage.")
                    End If
                End If

                Return 1
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

        '***************************************************
        Public Function CheckDeviceSKULength(ByVal strSN As String, _
                                            ByVal strSkuChar As String) _
                                            As Integer
            Dim R1 As DataRow
            Dim strDevSKUChar As String = ""

            Try
                strSql = "Select tsku.sku_ID, tsku.Sku_Number, Length(Sku_Number) as SkuLen " & Environment.NewLine
                strSql += "from tdevice inner join tsku on tdevice.sku_id = tsku.sku_ID " & Environment.NewLine
                strSql += "where device_sn = '" & strSN & "' and device_dateship is NULL and device_datebill is not NULL"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If R1("SkuLen") >= 1 And R1("SkuLen") <= 5 Then
                        strDevSKUChar = "S"
                    ElseIf R1("SkuLen") >= 6 And R1("SkuLen") <= 15 Then
                        strDevSKUChar = "L"
                    End If

                    If UCase(Trim(strSkuChar)) = UCase(Trim(strDevSKUChar)) Then
                        Return 1
                    Else
                        Return 0
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try

        End Function

        '***************************************************
        Public Function CheckDeviceModel(ByVal strSN As String, _
                                       ByVal strShortModelName As String, _
                                       Optional ByVal iCustID As Integer = 0) _
                                       As Integer
            Dim R1 As DataRow

            Try
                strSql = "Select tmodel.Model_ID, tmodel.Model_MotoSku " & Environment.NewLine
                strSql += "from tdevice inner join tmodel on tdevice.model_id = tmodel.Model_ID " & Environment.NewLine
                If iCustID > 0 Then strSql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql += "where device_sn = '" & strSN & "' and " & Environment.NewLine
                strSql += "device_dateship is NULL and device_datebill <> '0000-00-00 00:00:00' and device_datebill is not NULL" & Environment.NewLine
                If iCustID > 0 Then strSql += " AND tlocation.Cust_ID = " & iCustID
                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If UCase(Trim(strShortModelName)) = UCase(Trim(R1("Model_MotoSku"))) Then
                        Return 1
                    Else
                        Return 0
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        Public Function GetDeviceModel(ByVal strSN As String) As Integer
            Dim R1 As DataRow

            Try
                strSql = "Select Model_ID " & Environment.NewLine
                strSql += "from tdevice " & Environment.NewLine
                strSql += "where device_sn = '" & strSN & "' and device_dateship is NULL and device_datebill <> '0000-00-00 00:00:00' and device_datebill is not NULL"

                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        Public Function CheckDeviceGroup(ByVal strSN As String, _
                                        ByVal iGroup_ID As Integer) _
                                        As Integer
            Dim R1 As DataRow

            Try
                strSql = "Select Count(*) as cnt " & Environment.NewLine
                strSql += "from tdevice inner join tworkorder on tdevice.wo_id = tworkorder.WO_ID " & Environment.NewLine
                strSql += "where device_sn = '" & strSN & "' and device_dateship is NULL and device_datebill is not NULL and tworkorder.Group_ID = " & iGroup_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSql)

                If R1("cnt") = 0 Then
                    Throw New Exception("This device may have been already shipped or it belongs to a different group. Can't put it on this pallet.")
                End If

                R1 = Nothing

                '***************************************************
                'Make sure Cell1 or Cell2 is the WIP owner of this device
                strSql = "Select count(*) as cnt " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "where device_sn = '" & strSN & "' and  " & Environment.NewLine
                strSql &= "Cellopt_WIPOwner = " & iGroup_ID & " and " & Environment.NewLine
                strSql &= "device_dateship is NULL and device_datebill is not NULL;"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If R1("cnt") = 0 Then
                    Throw New Exception("This group does not have WIP ownership of this device. Please take WIP ownership first.")
                End If
                '***************************************************

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function
        '***************************************************
        Public Function GetAllSNsForPallet(ByVal iPalletID As Integer, _
                                            Optional ByVal strDevice_SN As String = "" _
                                            ) As DataTable
            Try
                If strDevice_SN <> "" Then
                    strSql = "Select Device_ID, Device_SN, Loc_ID from tdevice where pallett_id = " & iPalletID.ToString & " and device_sn = '" & strDevice_SN & "'"
                Else
                    strSql = "Select Device_ID, Device_SN, Loc_ID from tdevice where pallett_id = " & iPalletID.ToString & " order by device_id"
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetOpenPalletsForModel(ByVal strGroupChar As String, _
                                            ByVal strShortModelName As String, _
                                            ByVal iModel_ID As Integer, _
                                            ByVal iCust_ID As Integer) _
                                            As DataTable
            Try
                strSql = "Select Pallett_id, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as Pallet, Model_ID from tpallett where cust_ID = " & iCust_ID.ToString & " and pallett_name like '" & strGroupChar & strShortModelName & "%' and Pallett_ReadyToShipFlg = 0 and Model_ID = " & iModel_ID.ToString & " Order by Pallett_id Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function CreatePallet(ByVal strPalletName As String, _
                                    ByVal strShipType As String, _
                                    ByVal strPalletNameInitials As String, _
                                    ByVal iModel_ID As Integer, _
                                    ByVal iCust_ID As Integer, _
                                    Optional ByVal strSkuLength As String = "", _
                                    Optional ByVal iWO_ID As Integer = 0) As Integer
            Dim i As Integer = 0

            Try
                If iCust_ID = 2254 Or (iCust_ID = 2219 And iModel_ID = 1175) Then
                    Select Case strShipType
                        Case "PASSED"
                            i = 0
                        Case "FAILED"
                            i = 1
                    End Select
                Else
                    Select Case strShipType
                        Case "REFURBISHED"
                            i = 0
                        Case "RUR"
                            i = 1
                        Case "RTM"
                            i = 9
                        Case "BER"
                            i = 1
                        Case "SCRAP"
                            i = 8
                        Case "INCOMPLETE"       'added by Lan 12/04/2004
                            i = 9
                        Case "CANCELLED"
                            i = 10
                    End Select
                End If

                If Trim(strSkuLength) = "" Then
                    strSql = "Insert into tpallett (Pallett_Name, Pallet_ShipType, Model_ID, Cust_ID, WO_ID ) values ('" & strPalletName & "', " & i.ToString & ", " & iModel_ID.ToString & ", " & iCust_ID.ToString & ", " & iWO_ID.ToString & ")"
                Else
                    strSql = "Insert into tpallett (Pallett_Name, Pallet_ShipType, Pallet_SkuLen, Model_ID, Cust_ID, WO_ID ) values ('" & strPalletName & "', " & i.ToString & ", '" & strSkuLength & "', " & iModel_ID.ToString & ", " & iCust_ID.ToString & ", " & iWO_ID.ToString & ")"
                End If

                Return TransactionID(strSql, "tpallett")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetPalletInfo(ByVal strpalletString As String, _
                                      ByVal iCust_ID As Integer) As DataTable
            Try
                'strSql = "Select * from tpallett where pallett_name like '" & strpalletString & "%' and Pallett_ReadyToShipFlg = 0"
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND  pallett_name like '" & strpalletString & "%' " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        Public Function GetLastCharFromPalletName(ByVal strGroupChar As String, _
                                                ByVal strdt As String) As String
            Dim R1 As DataRow
            Dim ascVal As Integer = 0
            Dim strLastTwoAlpha As String = ""
            Dim i As Integer = Len(strGroupChar)
            Dim iIndex As Integer = 0

            Try

                strSql = "Select Pallett_Name from tpallett where left(Pallett_Name, " & i.ToString & ") = '" & strGroupChar & "' and left(right(trim(pallett_Name), 8), 6) = '" & strdt & "' order by Pallett_ID desc"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    strLastTwoAlpha = Right(Trim(R1("Pallett_Name")), 2)
                    iIndex = Left(strLastTwoAlpha, 1)
                    ascVal = Asc(Right(strLastTwoAlpha, 1))

                    If ascVal = 90 Then     'ASCII(Z) = 90;
                        ascVal = 65         'ASCII(A) = 65;     reset it to A
                        iIndex += 1
                        strLastTwoAlpha = iIndex & UCase(Chr(ascVal))
                    Else
                        strLastTwoAlpha = iIndex & UCase(Chr(ascVal + 1))
                    End If
                Else
                    strLastTwoAlpha = "0A"
                End If

                Return strLastTwoAlpha
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function
        '***************************************************
        Public Function SaveShortModelName(ByVal iModel_ID As Integer, _
                                        ByVal strShortModelName As String) As Integer
            Try
                strSql = "Update tmodel set Model_MotoSku = '" & strShortModelName & "' where model_id = " & iModel_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************
        Public Function GetShortModelName(ByVal iModel_ID As Integer) As String
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "Select Model_MotoSku from tmodel where model_id = " & iModel_ID.ToString

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Model does not exist in the database.")
                Else
                    R1 = dt1.Rows(0)
                End If

                If Not IsDBNull(R1("Model_MotoSku")) Then
                    Return R1("Model_MotoSku")
                Else
                    Return ""
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
        '***************************************************

        Public Function CheckIfMachineTiedToLine(ByVal StrMachine As String) As DataTable

            Try
                strSql = "Select lwclocation.WC_Machine, " & Environment.NewLine
                strSql += "lwclocation.WC_Location, " & Environment.NewLine
                strSql += "lwclocation.WCLocation_ID, " & Environment.NewLine
                strSql += "tgrouplinemap.GrpLineMap_ID, " & Environment.NewLine
                strSql += "tgrouplinemap.Group_ID, " & Environment.NewLine
                strSql += "tgrouplinemap.Line_ID, " & Environment.NewLine
                strSql += "tgrouplinemap.LineSide_ID, " & Environment.NewLine
                strSql += "lgroups.Group_Desc, " & Environment.NewLine
                strSql += "lline.Line_Number, " & Environment.NewLine
                strSql += "llineside.LineSide_Desc, tcostcenter.wa_id " & Environment.NewLine
                strSql += ", if (cc_desc is null, '', cc_desc) as CostCenter " & Environment.NewLine
                strSql += ", if (tcostcenter.cc_id is null, 0, tcostcenter.cc_id ) as cc_id " & Environment.NewLine
                strSql += ", if (tcostcenter.group_id is null, 0, tcostcenter.group_id ) as CC_Group_ID " & Environment.NewLine
                strSql += ", if (lgroup_cc.group_desc is null, '', lgroup_cc.group_desc) as CC_Group_Desc " & Environment.NewLine
                strSql += ", lgroup_cc.Cust_ID as CCG_CustID " & Environment.NewLine
                strSql += "FROM lwclocation" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tgrouplinemap ON lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups ON tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lline ON tgrouplinemap.Line_ID = lline.Line_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN llineside ON tgrouplinemap.LineSide_ID = llineside.LineSide_ID  " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcentermapping ON lwclocation.WCLocation_ID =  tcostcentermapping.WCLocation_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcenter ON tcostcentermapping.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups lgroup_cc ON tcostcenter.group_id = lgroup_cc.group_id " & Environment.NewLine
                strSql += "WHERE WC_ActiveFlag = 1 " & Environment.NewLine
                strSql += "AND wc_machine = '" & StrMachine & "'"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'RUR/RTM Check
        Public Function RURRTMCheck(ByVal strFilePath As String) As Integer
            Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim R1, R2 As DataRow
            Dim strsql As String = ""
            Dim i As Integer = 1
            Dim sb As New StringBuilder()
            Dim strMessage As String = ""

            Dim iDuplicateSNs As Integer = 0
            Dim strRTMs As String = ""
            Dim strRURs As String = ""

            Try
                objConn.ConnectionString = sConnectionstring
                objConn.Open()
                objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$] order by [Piece Identifier]")
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dt1)

                '************************************************************
                'Step 1
                strsql = "Select Distinct Device_SN from tdevice where loc_id = 2540 and Device_sn in "
                sb = sb.Append("(")

                For Each R1 In dt1.Rows
                    If i < dt1.Rows.Count Then
                        sb = sb.Append("'" & Trim(R1("Piece Identifier")) & "', ")
                        i += 1
                    Else
                        sb = sb.Append("'" & Trim(R1("Piece Identifier")) & "')")
                    End If
                Next R1

                dt2 = Me._objDataProc.GetDataTable(strsql & sb.ToString)

                If dt1.Rows.Count <> dt2.Rows.Count Then
                    iDuplicateSNs = dt1.Rows.Count - dt2.Rows.Count
                End If

                R2 = Nothing

                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                '************************************************************
                'Step 2     RTM Check
                strsql = "Select Device_SN from tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id where tdevice.loc_id = 2540 and tdevicebill.billcode_id = 466 and Device_sn in "

                dt2 = Me._objDataProc.GetDataTable(strsql & sb.ToString)

                For Each R2 In dt2.Rows
                    strRTMs += Trim(R2("device_sn")) & Environment.NewLine
                Next R2

                R2 = Nothing

                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                '*************************************************************
                'Step 2     RUR Check
                strsql = "Select Device_SN from tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id where tdevice.loc_id = 2540 and billcode_rule = 1 and Device_sn in "

                dt2 = Me._objDataProc.GetDataTable(strsql & sb.ToString)

                For Each R2 In dt2.Rows
                    strRURs += Trim(R2("device_sn")) & Environment.NewLine
                Next R2

                R2 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                '*************************************************************
                strMessage = "Duplicate Serial Numbers: " & Environment.NewLine & iDuplicateSNs & Environment.NewLine & Environment.NewLine & _
                            "RUR's : " & Environment.NewLine & strRURs & Environment.NewLine & _
                            "RTM's : " & Environment.NewLine & strRTMs

                MsgBox(strMessage, MsgBoxStyle.Information, "RUR/RTM Check Result")
            Catch ex As Exception
                Throw ex
            Finally
                sb = Nothing
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
            End Try

        End Function

        '***************************************************
        'Check if device has been through QC
        '***************************************************
        Public Function IsDeviceThroughQC(ByVal iDevId As Integer) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "Select * from tqc where device_id = " & iDevId.ToString

                dt1 = Me._objDataProc.GetDataTable(strSql)

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                DisposeDT(dt1)
            End Try
        End Function
        '***************************************************
        Public Function CreateQCReport(ByVal iPallett_ID As Integer) As Integer
            Dim dt1 As New DataTable()
            Dim R1, R2 As DataRow
            'Dim i As Integer = 1
            Dim iSheet As Integer = 0
            Dim iCursor1 As Integer = 1
            Dim iCursor2 As Integer = 1
            Dim iPassCnt As Integer = 0
            Dim iFailCnt As Integer = 0

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strFile As String = ""

            Try
                strSql = "Select tdevice.Device_sn, tdevice.device_id, tworkorder.wo_custwo, tmodel.Model_Desc, lmanuf.Manuf_Desc, tpallett.Pallett_ShipDate, tqc.QCResult_ID, lcodesdetail.Dcode_Ldesc " & Environment.NewLine
                strSql += "from tdevice " & Environment.NewLine
                strSql += "inner join tqc on tdevice.device_id = tqc.device_id " & Environment.NewLine
                strSql += "inner join tpallett on tdevice.pallett_id = tpallett.pallett_id " & Environment.NewLine
                strSql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id  " & Environment.NewLine
                strSql += "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql += "inner join lmanuf on tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
                strSql += "inner join lcodesdetail on tqc.DCode_ID = lcodesdetail.Dcode_id " & Environment.NewLine
                strSql += "where tpallett.Pallett_ID = " & iPallett_ID.ToString & Environment.NewLine
                strSql += " order by QCResult_ID"

                R1 = Me._objDataProc.GetDataRow(strSql)

                '***************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False

                '***************************************
                For iSheet = 1 To 2
                    If iSheet = 1 Then  'passed
                        objExcel.Sheets("Sheet1").Select()                          'Select a sheet
                        objExcel.Sheets("Sheet1").Name = "Passed"                   'Rename a sheet
                        objSheet = objBook.Worksheets.Item(iSheet)                  'Set active sheet
                    ElseIf iSheet = 2 Then  'Failed
                        objExcel.Sheets("Sheet2").Select()                          'Select a sheet
                        objExcel.Sheets("Sheet2").Name = "Failed"                   'Rename a sheet
                        objSheet = objBook.Worksheets.Item(iSheet)                  'Set active sheet
                    End If

                    objSheet.Columns("A:A").Select()
                    With objExcel.Selection
                        .NumberFormat = "@"
                        .ColumnWidth = 20
                        .Font.Name = "Microsoft Sans Serif"
                        .HorizontalAlignment = Excel.Constants.xlLeft
                    End With

                    objSheet.Columns("B:B").Select()
                    With objExcel.Selection
                        .NumberFormat = "@"
                        .ColumnWidth = 50
                        .Font.Name = "Microsoft Sans Serif"
                        .HorizontalAlignment = Excel.Constants.xlLeft
                    End With
                    '**********
                    objSheet.Range("A1:B5").Select()
                    With objExcel.Selection
                        .font.bold = True
                    End With
                    '**********

                    If iSheet = 1 Then      'passed
                        ''Write Data to Sheets
                        objExcel.Application.Cells(iCursor1, 1).Value = "DATE:"
                        objExcel.Application.Cells(iCursor1, 2).Value = Trim(R1("pallett_shipdate"))

                        iCursor1 += 1
                        objExcel.Application.Cells(iCursor1, 1).Value = "P.O #"
                        objExcel.Application.Cells(iCursor1, 2).Value = Trim(R1("wo_custwo"))

                        iCursor1 += 1
                        objExcel.Application.Cells(iCursor1, 1).Value = "MAKE & MODEL:"
                        objExcel.Application.Cells(iCursor1, 2).Value = Trim(R1("manuf_desc")) & " - " & Trim(R1("model_desc"))

                        iCursor1 += 1
                        objExcel.Application.Cells(iCursor1, 1).Value = "TOTAL COUNT"

                        iCursor1 += 1
                        objExcel.Application.Cells(iCursor1, 1).Value = "ESN"


                        iCursor1 += 1
                        For Each R2 In dt1.Rows
                            If R2("QCResult_ID") = 1 Then      'Pass
                                iPassCnt += 1
                                objExcel.Application.Cells(iCursor1, 1).Value = Trim(R2("Device_sn"))
                                iCursor1 += 1
                            End If
                        Next R2

                        '**************************
                        '''Set borders
                        objSheet.Range("A1:" & "B" & (iCursor1 - 1)).Select()

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
                        '**************************
                        R2 = Nothing
                        iCursor1 = 4
                        objExcel.Application.Cells(iCursor1, 2).Value = iPassCnt

                        iCursor1 = 5
                        objSheet.Range("A" & iCursor1 & ":B" & iCursor1).Select()
                        With objExcel.Selection
                            .Interior.ColorIndex = 37
                            .HorizontalAlignment = Excel.Constants.xlCenter
                        End With

                    ElseIf iSheet = 2 Then  'Failed
                        objExcel.Application.Cells(iCursor2, 1).Value = "DATE:"
                        objExcel.Application.Cells(iCursor2, 2).Value = Trim(R1("pallett_shipdate"))

                        iCursor2 += 1
                        objExcel.Application.Cells(iCursor2, 1).Value = "P.O #"
                        objExcel.Application.Cells(iCursor2, 2).Value = Trim(R1("wo_custwo"))

                        iCursor2 += 1
                        objExcel.Application.Cells(iCursor2, 1).Value = "MAKE & MODEL:"
                        objExcel.Application.Cells(iCursor2, 2).Value = Trim(R1("manuf_desc")) & " - " & Trim(R1("model_desc"))

                        iCursor2 += 1
                        objExcel.Application.Cells(iCursor2, 1).Value = "TOTAL COUNT"

                        iCursor2 += 1
                        objExcel.Application.Cells(iCursor2, 1).Value = "ESN"
                        objExcel.Application.Cells(iCursor2, 2).Value = "Failure Reason"
                        objSheet.Range("A" & iCursor1 & ":B" & iCursor2).Select()
                        With objExcel.Selection
                            .Interior.ColorIndex = 37
                            .HorizontalAlignment = Excel.Constants.xlCenter
                        End With

                        iCursor2 += 1
                        For Each R2 In dt1.Rows
                            If R2("QCResult_ID") = 2 Then      'Fail
                                iFailCnt += 1
                                objExcel.Application.Cells(iCursor2, 1).Value = Trim(R2("Device_sn"))
                                objExcel.Application.Cells(iCursor2, 2).Value = Trim(R2("Dcode_Ldesc"))
                                iCursor2 += 1
                            End If
                        Next R2

                        '**************************
                        '''Set borders
                        objSheet.Range("A1:" & "B" & (iCursor2 - 1)).Select()

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
                        '**************************
                        R2 = Nothing
                        iCursor2 = 4
                        objExcel.Application.Cells(iCursor2, 2).Value = iFailCnt

                    End If
                    '******************************
                Next iSheet

                objExcel.Sheets("Sheet3").Delete()
                strFileName = Trim(R1("wo_custwo")) & ".xls"

                strFile = strCellStarQCRepDir & strFileName

                'Save the excel file
                If Dir(strFile) <> "" Then
                    Kill(strFile)
                End If

                objBook.SaveAs(strFile)

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                strSql = ""
                R1 = Nothing
                DisposeDT(dt1)

                'Excel clean up
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

        '***************************************************
        'Create USA Mobility WO Report
        '***************************************************
        Public Function CreateUSAMobilityWORpt() As Integer
            Dim dtWO As New DataTable()
            Dim dt As New DataTable()
            Dim dt1 As New DataTable()

            Dim R1, R2, R3 As DataRow
            Dim i As Integer = 0
            Dim iDaysByTray As Integer = 0
            Dim iAvgDaysByTray As Integer = 0
            Dim iDaysByWO As Integer = 0
            Dim iAvgDaysByWO As Integer = 0
            Dim iNumOfWOs As Integer = 0

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application   ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            'Loop variables
            Dim iRcvdQty As Integer = 0
            Dim iShippedGoodQty As Integer = 0
            Dim iShippedDbrNerQty As Integer = 0
            Dim iWIP As Integer = 0
            Dim iWIP_AWP As Integer = 0

            Dim strDueDt As String = ""

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      'Set to landscape
                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(3, 1).Value = "Work Order"
                objExcel.Application.Cells(3, 2).Value = "Due Date"
                objExcel.Application.Cells(3, 3).Value = "SKU"
                objExcel.Application.Cells(3, 4).Value = "Received Qty."
                objExcel.Application.Cells(3, 5).Value = "Shipped Good"
                objExcel.Application.Cells(3, 6).Value = "Shipped DBR/NER"
                objExcel.Application.Cells(3, 7).Value = "WIP"
                objExcel.Application.Cells(3, 8).Value = "WIP Awaiting Parts"
                objExcel.Application.Cells(3, 9).Value = "Avg. WIP Days for AWP Units"
                objExcel.Application.Cells(3, 10).Value = "Special Notes"

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 18.14
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 10
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("C:C").ColumnWidth = 17.86
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 10.14
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlRight

                objSheet.Columns("E:E").ColumnWidth = 9.14
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlRight

                objSheet.Columns("F:F").ColumnWidth = 10.86
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlRight

                objSheet.Columns("G:G").ColumnWidth = 5.86
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlRight

                objSheet.Columns("H:H").ColumnWidth = 11.14
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlRight

                objSheet.Columns("I:I").ColumnWidth = 12.71
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlRight

                objSheet.Columns("J:J").ColumnWidth = 30
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft
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
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("E:E").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("F:F").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("G:G").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("H:H").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("I:I").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"

                objSheet.Columns("J:J").Select()
                objExcel.Selection.NumberFormat = "@"

                '*****************************************
                'Set horizontal alignment for the header
                '*****************************************
                objSheet.Range("A3:J3").Select()
                With objExcel.Selection
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .VerticalAlignment = Excel.Constants.xlCenter
                    .WrapText = True
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With
                objSheet.Rows("3:3").RowHeight = 37
                ''*****************************************
                'Step 1: Get all open WOs
                '******************************************
                strSql = "Select  distinct tdevice.wo_id, tworkorder.wo_custwo, tusatest.USA_FinishedGoodsSKU " & Environment.NewLine
                strSql += "from tdevice " & Environment.NewLine
                strSql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql += "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strSql += "left outer join tusatest on tworkorder.wo_custwo = tusatest.usa_wo " & Environment.NewLine
                strSql += "where tcustomer.cust_id = 1 and tdevice.device_dateship is null " & Environment.NewLine
                strSql += "order by wo_id"

                dtWO = Me._objDataProc.GetDataTable(strSql)
                i = 4

                iNumOfWOs = dtWO.Rows.Count

                For Each R1 In dtWO.Rows
                    'If R1("WO_ID") = 76280 Then
                    '    MsgBox("stop")
                    'End If
                    '******************************************
                    'Step 2 : Get total number of devices received
                    '******************************************
                    strSql = "Select count(*) as DevicesReceived from tdevice where wo_id = " & R1("WO_ID")

                    R2 = Me._objDataProc.GetDataRow(strSql)

                    iRcvdQty = R2("DevicesReceived")

                    'Clean up in interations
                    R2 = Nothing
                    '******************************************
                    'Step 3 : Get Shipped Good Qty
                    '******************************************
                    strSql = "Select distinct tdevice.device_id " & Environment.NewLine
                    strSql += "from tdevice " & Environment.NewLine
                    strSql += "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                    strSql += "where tdevice.wo_id = " & R1("WO_ID") & " and " & Environment.NewLine
                    strSql += "tdevice.device_dateship is not null and " & Environment.NewLine
                    strSql += "tdevicebill.billcode_id not in (25, 89)"

                    dt = Me._objDataProc.GetDataTable(strSql)

                    iShippedGoodQty = dt.Rows.Count

                    'Clean up in interations
                    DisposeDT(dt)
                    '******************************************
                    'Step 4 : Get Shipped DBR/NER Qty
                    '******************************************
                    strSql = "Select distinct tdevice.device_id " & Environment.NewLine
                    strSql += "from tdevice " & Environment.NewLine
                    strSql += "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                    strSql += "where tdevice.wo_id = " & R1("WO_ID") & " and " & Environment.NewLine
                    strSql += "tdevice.device_dateship is not null and " & Environment.NewLine
                    strSql += "tdevicebill.billcode_id in (25, 89)"

                    dt = Me._objDataProc.GetDataTable(strSql)

                    iShippedDbrNerQty = dt.Rows.Count

                    'Clean up in interations
                    DisposeDT(dt)

                    '******************************************
                    'Step 5 : Get WIP Awaiting parts
                    '******************************************
                    strSql = "Select distinct Device_ID " & Environment.NewLine
                    strSql += "from tdevice inner join tawaitingparts on tdevice.tray_id = tawaitingparts.tray_id " & Environment.NewLine
                    strSql += "where device_dateship is null and " & Environment.NewLine
                    strSql += "tdevice.wo_id = " & R1("WO_ID")

                    dt = Me._objDataProc.GetDataTable(strSql)
                    iWIP_AWP = dt.Rows.Count

                    'Clean up in interations
                    DisposeDT(dt)
                    '******************************************
                    'Step 6 : Get WIP
                    '******************************************
                    strSql = "Select count(*) as cnt " & Environment.NewLine
                    strSql += "from tdevice " & Environment.NewLine
                    strSql += "where device_dateship is null and " & Environment.NewLine
                    strSql += "tdevice.wo_id = " & R1("WO_ID")

                    R2 = Me._objDataProc.GetDataRow(strSql)

                    iWIP = R2("cnt")
                    iWIP = iWIP - iWIP_AWP

                    'Clean up in interations
                    R2 = Nothing
                    '******************************************
                    ''Step 7 : Get the Avg number of days in 
                    ''Awaiting parts for every work order
                    '******************************************
                    'If R1("WO_ID") = 76817 Then
                    '    MsgBox("Stop")
                    'End If
                    '***********
                    strSql = "Select tawaitingparts.Tray_ID " & Environment.NewLine
                    strSql += "from tdevice inner join tawaitingparts on tdevice.Tray_ID = tawaitingparts.Tray_ID " & Environment.NewLine
                    strSql += "where tdevice.WO_ID = " & R1("WO_ID") & Environment.NewLine
                    strSql += " group by tawaitingparts.Tray_ID"

                    dt = Me._objDataProc.GetDataTable(strSql)

                    For Each R2 In dt.Rows
                        strSql = "Select * from tawaitingparts where tray_id = " & R2("Tray_ID")

                        dt1 = Me._objDataProc.GetDataTable(strSql)

                        For Each R3 In dt1.Rows
                            iDaysByTray += DateDiff(DateInterval.Day, R3("AP_EntryDate"), Now)
                        Next R3

                        If dt1.Rows.Count <> 0 Then
                            iAvgDaysByTray = iDaysByTray / dt1.Rows.Count
                        End If
                        iDaysByWO += iAvgDaysByTray

                        iDaysByTray = 0
                        iAvgDaysByTray = 0
                    Next R2

                    If dt.Rows.Count > 0 Then
                        iAvgDaysByWO = iDaysByWO / dt.Rows.Count
                        If iAvgDaysByWO = 0 Then    'This means it is less than a day since it went in to AWP status
                            iAvgDaysByWO = 1        'So show 1 Day 
                        End If
                    Else
                        iAvgDaysByWO = 0
                    End If

                    'Clean up in iterations
                    R2 = Nothing
                    DisposeDT(dt)
                    '******************************************
                    'Calculate Due Date
                    '******************************************
                    strSql = ""
                    strSql = "Select DATE_FORMAT(DATE_ADD(MAX(tdevice.Device_Daterec),  INTERVAL 14 DAY), '%m/%d/%Y') as 'Due Date' from tdevice where wo_id = " & R1("WO_ID")

                    R2 = Me._objDataProc.GetDataRow(strSql)

                    strDueDt = R2("Due Date")

                    'Clean up in interations
                    R2 = Nothing
                    '******************************************
                    'Write data to excel
                    objExcel.Application.Cells(i, 1).Value = Trim(R1("wo_custwo"))
                    objExcel.Application.Cells(i, 2).Value = strDueDt
                    '//New November 16, 2005 Craig D Haney - to add SKU
                    If IsDBNull(R1("USA_FinishedGoodsSKU")) = False Then
                        objExcel.Application.Cells(i, 3).Value = Trim(R1("USA_FinishedGoodsSKU"))
                    End If
                    objExcel.Application.Cells(i, 4).Value = iRcvdQty
                    objExcel.Application.Cells(i, 5).Value = iShippedGoodQty
                    objExcel.Application.Cells(i, 6).Value = iShippedDbrNerQty
                    objExcel.Application.Cells(i, 7).Value = iWIP
                    objExcel.Application.Cells(i, 8).Value = iWIP_AWP
                    objExcel.Application.Cells(i, 9).Value = iAvgDaysByWO

                    '******************************************
                    'Reinitialize loop variables
                    i += 1
                    iRcvdQty = 0
                    iShippedGoodQty = 0
                    iShippedDbrNerQty = 0
                    iWIP = 0
                    iWIP_AWP = 0
                    iAvgDaysByWO = 0
                    iDaysByWO = 0
                    '******************************************

                Next R1

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:J" & iNumOfWOs + 3).Select()

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
                '************************************************
                'Add report header
                objSheet.Range("A1:C1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    .font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Microsoft Sans Serif"
                    .Font.ColorIndex = 11
                End With
                objExcel.Application.Cells(1, 1).Value = "USA MObility WO Report"

                'Save the excel file
                objBook.SaveAs(strRptDir)
                '************************************************
                Return 1

            Catch ex As Exception
                Throw New Exception("Buisness.Misc.CreateUSAMobilityWORpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                strSql = ""
                R1 = Nothing
                R2 = Nothing
                R3 = Nothing
                DisposeDT(dt)
                DisposeDT(dt1)
                DisposeDT(dtWO)

                '*************************************
                'Excel clean up
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
        '***************************************************
        'Update Device
        '***************************************************
        Public Function UpdateDevice(ByVal iFlg As Integer, _
                                    ByVal strItem As String, _
                                    Optional ByVal iUNDO As Integer = 0) As Integer
            Dim iBizTypeID As Integer = 0

            If iUNDO = 0 Then
                Select Case iFlg
                    Case 1      'SN
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice set Device_FinishedGoods = 1 where Device_FinishedGoods = 0 and Device_SN = '" & strItem & "';"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                    Case 2      'Ship_ID
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then        '1 - Asset Recovery; 2 - Reverse Logistics
                            strSql = "Update tdevice set Device_FinishedGoods = 1 where Device_FinishedGoods = 0 and Ship_ID = " & strItem & ";"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                    Case 3      'OverPack_ID
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice inner join tship on tdevice.ship_id = tship.ship_id set tdevice.Device_FinishedGoods = 1 where tdevice.Device_FinishedGoods = 0 and tship.Overpack_ID = " & strItem & ";"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                    Case 4      'Pallett_ID
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice set Device_FinishedGoods = 1 where Device_FinishedGoods = 0 and Pallett_ID = " & strItem & ";"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                End Select
            Else

                Select Case iFlg
                    Case 1      'SN
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice inner join tdisposition on tdevice.device_id = tdisposition.device_id set tdevice.Device_FinishedGoods = 0 where Device_FinishedGoods = 1 and Device_SN = '" & strItem & "' and tdisposition.Disp_NavDt is null;"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                    Case 2      'Ship_ID
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice inner join tdisposition on tdevice.device_id = tdisposition.device_id set Device_FinishedGoods = 0 where Device_FinishedGoods = 1 and Ship_ID = " & strItem & " and tdisposition.Disp_NavDt is null;"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                    Case 3      'OverPack_ID
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice inner join tdisposition on tdevice.device_id = tdisposition.device_id inner join tship on tdevice.ship_id = tship.ship_id set tdevice.Device_FinishedGoods = 0 where tdevice.Device_FinishedGoods = 1 and tship.Overpack_ID = " & strItem & " and tdisposition.Disp_NavDt is null;"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If

                    Case 4      'Pallett_ID
                        iBizTypeID = GetCustomerBizType(iFlg, strItem)

                        If iBizTypeID = 1 Or iBizTypeID = 2 Then
                            strSql = "Update tdevice inner join tdisposition on tdevice.device_id = tdisposition.device_id set Device_FinishedGoods = 0 where Device_FinishedGoods = 1 and Pallett_ID = " & strItem & " and tdisposition.Disp_NavDt is null;"
                        Else
                            Throw New Exception("Business.Misc.UpdateDevice: " & Environment.NewLine & "Transfer to finished goods is not required for this customer.")
                        End If
                End Select

            End If

            Return Me._objDataProc.ExecuteNonQuery(strSql)
        End Function
        '***************************************************
        Public Function GetCustomerBizType(ByVal iFlg As Integer, ByVal strItem As String) As Integer
            Dim R1 As DataRow
            Dim iBizTypeID As Integer = 0

            Try
                Select Case iFlg
                    Case 1      'SN
                        strSql = "Select BizType_ID from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id where tdevice.device_sn = '" & strItem & "';"
                    Case 2      'Ship_ID
                        strSql = "Select BizType_ID from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id where tdevice.Ship_ID = " & strItem & ";"
                    Case 3      'OverPack_ID
                        strSql = "Select BizType_ID from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id inner join tship on tdevice.ship_id = tship.ship_id where tship.overpack_ID = " & strItem & ";"
                    Case 4      'Pallett_ID
                        strSql = "Select BizType_ID from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id where tdevice.pallett_ID = " & strItem & ";"
                End Select

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("BizType_ID")) Then iBizTypeID = R1("BizType_ID")
                End If

                Return iBizTypeID
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function
        '***************************************************
        'Private strDetailFilePath As String = "R:\WC Reports\" & _CurUser & "_" & "WCDetail_"
        'Private strSummaryFilePath As String = "R:\WC Reports\" & _CurUser & "_" & "WCSummary_"
        '***************************************************
        'Get the WC Detail Report Info
        '***************************************************
        Public Function GenerateWCDetailReport(ByVal strFromBillDate As String, _
                                                ByVal strToBillDate As String, _
                                                ByVal iPSSIIndex As Integer, _
                                                Optional ByVal iWCLocation_ID As Integer = 0, _
                                                Optional ByVal iCust_ID As Integer = 0, _
                                                Optional ByVal iModel_id As Integer = 0) As Integer

            '*************************************
            Dim strDetailFilePath As String = "R:\WC Reports\" & _CurUser & "_" & "WCDetail_"
            Dim strSummaryFilePath As String = "R:\WC Reports\" & _CurUser & "_" & "WCSummary_"

            '*************************************
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            'Datarow, datacolumn, datatable variables
            Dim R1, R2 As DataRow
            Dim ColNew As DataColumn = Nothing
            Dim dtSum As DataTable = Nothing
            Dim dtWCLocs As DataTable = Nothing
            Dim dt, dt1 As DataTable

            'string variables
            Dim strBilldate As String = ""
            Dim strWCLocation As String = ""
            Dim strCustomer As String = ""
            Dim strModel As String = ""

            'Integer variables
            Dim iTotalBilled As Integer = 0
            Dim iDBR As Integer = 0
            Dim iNER As Integer = 0
            Dim iTotalRepaired As Integer = 0
            Dim iPrevModel_ID As Integer = 0
            Dim iPrevWCLocation_ID As Integer = 0
            Dim iPrevCust_ID As Integer = 0
            Dim iPrevDevice_ID As Integer = 0
            Dim i As Integer = 2
            Dim iGrandTotalBilled As Integer = 0
            Dim iGrandDBR As Integer = 0
            Dim iGrandNER As Integer = 0
            Dim iGrandTotalRepaired As Decimal = 0

            'decimal variables
            Dim decTotalLaborRevenue As Decimal = 0
            Dim decTotalLaborAUP As Decimal = 0
            Dim decTotalPartsRevenue As Decimal = 0
            Dim decTotalPartsAUP As Decimal = 0
            Dim decGrandTotalLaborRevenue As Decimal = 0
            Dim decGrandTotalLaborAUP As Decimal = 0
            Dim decGrandTotalPartsRevenue As Decimal = 0
            Dim decGrandTotalPartsAUP As Decimal = 0

            'Boolean Variables
            Dim booBilldate As Boolean = False
            Dim booWCLocation As Boolean = False
            Dim booCustomer As Boolean = False
            Dim booModel As Boolean = False

            Try
                '*******************************************************************************************
                'Create Output table
                '*******************************************************************************************
                dt = New DataTable("WCDetail")

                ColNew = New DataColumn("Bill Date")
                ColNew.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("WCLocation_ID")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("WC Location")
                ColNew.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Customer")
                ColNew.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Model")
                ColNew.DataType = System.Type.GetType("System.String")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Total Billed")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("DBR")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("NER")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Total Repaired")
                ColNew.DataType = System.Type.GetType("System.Int32")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Total Labor Revenue")
                ColNew.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Total Labor AUP")
                ColNew.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Total Parts Revenue")
                ColNew.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                ColNew = New DataColumn("Total Parts AUP")
                ColNew.DataType = System.Type.GetType("System.Decimal")
                dt.Columns.Add(ColNew)
                ColNew.Dispose()
                ColNew = Nothing

                '*******************************************************************************************
                'Get Raw data
                '*******************************************************************************************
                strSql = "Select " & Environment.NewLine
                strSql += "DATE_FORMAT(tdevice.device_datebill, '%m/%d/%Y') as 'Bill Date', " & Environment.NewLine
                strSql += "twcdetail.wclocation_id, lwclocation.wc_location as 'WC Location', " & Environment.NewLine
                strSql += "tlocation.cust_id, tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strSql += "tdevice.model_id, tmodel.model_desc as 'Model', " & Environment.NewLine
                strSql += "tdevice.tray_id as 'Tray Id', " & Environment.NewLine
                strSql += "tdevice.device_id, " & Environment.NewLine
                strSql += "tdevice.loc_id, " & Environment.NewLine
                strSql += "tdevicebill.billcode_id, " & Environment.NewLine
                strSql += "lbillcodes.billcode_rule, " & Environment.NewLine
                strSql += "tdevice.device_laborcharge, " & Environment.NewLine
                strSql += "tdevicebill.DBill_InvoiceAmt, " & Environment.NewLine

                strSql += "0 as 'Total Billed', " & Environment.NewLine
                strSql += "0 as 'DBR', " & Environment.NewLine
                strSql += "0 as 'NER', " & Environment.NewLine
                strSql += "0 as 'Total Repaired', " & Environment.NewLine
                strSql += "0 as 'Total Labor Revenue', " & Environment.NewLine
                strSql += "0 as 'Total Labor AUP', " & Environment.NewLine
                strSql += "0 as 'Total Parts Revenue', " & Environment.NewLine
                strSql += "0 as 'Total Parts AUP' " & Environment.NewLine

                strSql += "from tdevice " & Environment.NewLine
                strSql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql += "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql += "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql += "inner join twcdetail on tdevice.tray_id = twcdetail.tray_id " & Environment.NewLine
                strSql += "inner join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & Environment.NewLine
                strSql += "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql += "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql += "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strSql += "where " & Environment.NewLine
                strSql += "tworkorder.prod_id = 1 and " & Environment.NewLine

                If strFromBillDate = strToBillDate Then
                    strSql += "tdevice.device_datebill like '" & strFromBillDate & "%'" & Environment.NewLine
                Else
                    strSql += "tdevice.device_datebill > '" & CStr(Format(DateAdd(DateInterval.Day, 0, CDate(strFromBillDate)), "yyyy-MM-dd")) & _
                            "' and tdevice.device_datebill < '" & CStr(Format(DateAdd(DateInterval.Day, 1, CDate(strToBillDate)), "yyyy-MM-dd")) & "' " & Environment.NewLine
                End If

                If iWCLocation_ID <> 0 Then
                    strSql += " and twcdetail.wclocation_id = " & iWCLocation_ID & Environment.NewLine
                End If
                If iCust_ID <> 0 Then
                    strSql += " and tlocation.cust_id = " & iCust_ID & Environment.NewLine
                End If
                If iModel_id <> 0 Then
                    strSql += " and tdevice.model_id = " & iModel_id & Environment.NewLine
                End If

                strSql += " Order by "
                strSql += " 'Bill Date', "
                strSql += " wclocation_id, "
                strSql += " cust_id, "
                strSql += " model_id, "
                strSql += " 'Tray Id', "
                strSql += " device_id; "

                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows

                    '*****************
                    'Re-initialise the loop variables
                    If strBilldate = R1("Bill Date") And iPrevWCLocation_ID = R1("wclocation_id") And iPrevCust_ID = R1("Cust_ID") And iPrevModel_ID = R1("Model_ID") Then
                        'do nothing
                    Else
                        '***************************
                        If iPrevModel_ID <> 0 Then
                            'Calculate decTotalLaborAUP
                            decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)

                            'Calculate decTotalPartsAUP
                            decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                            'Add row to the dt table
                            R2 = dt.NewRow
                            R2("Bill Date") = strBilldate
                            R2("WCLocation_ID") = iPrevWCLocation_ID
                            R2("WC Location") = strWCLocation
                            R2("Customer") = strCustomer
                            R2("Model") = strModel
                            R2("Total Billed") = iTotalBilled
                            R2("DBR") = iDBR
                            R2("NER") = iNER
                            R2("Total Repaired") = iTotalRepaired
                            R2("Total Labor Revenue") = decTotalLaborRevenue
                            R2("Total Labor AUP") = decTotalLaborAUP
                            R2("Total Parts Revenue") = decTotalPartsRevenue
                            R2("Total Parts AUP") = decTotalPartsAUP
                            dt.Rows.Add(R2)
                            R2 = Nothing
                        End If
                        '***************************
                        booBilldate = False
                        booWCLocation = False
                        booCustomer = False
                        booModel = False
                        strBilldate = ""
                        strWCLocation = ""
                        strCustomer = ""
                        strModel = ""
                        iTotalBilled = 0
                        iPrevWCLocation_ID = 0
                        iPrevCust_ID = 0
                        iPrevModel_ID = 0
                        iDBR = 0
                        iNER = 0
                        iTotalRepaired = 0
                        decTotalLaborRevenue = 0
                        decTotalLaborAUP = 0
                        decTotalPartsRevenue = 0
                        decTotalPartsAUP = 0
                    End If
                    '*****************
                    'Get the Row Info
                    '*****************
                    If booBilldate = False Then
                        strBilldate = R1("Bill Date")
                        booBilldate = True
                    End If
                    '******************
                    If booWCLocation = False Then
                        iPrevWCLocation_ID = R1("WCLocation_ID")
                        strWCLocation = R1("WC Location")
                        booWCLocation = True
                    End If
                    '******************
                    If booCustomer = False Then
                        iPrevCust_ID = R1("Cust_ID")
                        strCustomer = R1("Customer")
                        booCustomer = True
                    End If
                    '******************
                    If booModel = False Then
                        iPrevModel_ID = R1("Model_ID")
                        strModel = R1("Model")
                        booModel = True
                    End If
                    '******************
                    'Get iDBR   for the criterion
                    If R1("BillCode_ID") = 25 Then      'DBR
                        iDBR += 1
                    End If
                    '******************
                    'Get iNER   for the criterion
                    If R1("billcode_rule") = 2 Then
                        iNER += 1
                    End If
                    '******************
                    'Get iTotalRepaired for the criterion
                    If R1("BillCode_ID") <> 25 And R1("billcode_rule") <> 2 Then      'neither DBR not NER
                        If iPrevDevice_ID <> R1("Device_ID") Then
                            iTotalRepaired += 1
                        End If
                    End If
                    '******************
                    'Get decTotalLaborRevenue and
                    'Get Total billed for the criterion
                    If iPrevDevice_ID <> R1("Device_ID") Then
                        decTotalLaborRevenue += R1("device_laborcharge")
                        iTotalBilled += 1
                    End If

                    '******************
                    'Get decTotalPartsRevenue
                    decTotalPartsRevenue += R1("DBill_InvoiceAmt")

                    '*****************
                    'Save Current loop values to compare in the next iteration
                    iPrevDevice_ID = R1("Device_ID")
                Next R1

                '***************************************
                'Add the last row in the above loop
                'Calculate decTotalLaborAUP
                decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)

                'Calculate decTotalPartsAUP
                decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                'Add row to the dt table
                R2 = dt.NewRow
                R2("Bill Date") = strBilldate
                R2("WCLocation_ID") = iPrevWCLocation_ID
                R2("WC Location") = strWCLocation
                R2("Customer") = strCustomer
                R2("Model") = strModel
                R2("Total Billed") = iTotalBilled
                R2("DBR") = iDBR
                R2("NER") = iNER
                R2("Total Repaired") = iTotalRepaired
                R2("Total Labor Revenue") = decTotalLaborRevenue
                R2("Total Labor AUP") = decTotalLaborAUP
                R2("Total Parts Revenue") = decTotalPartsRevenue
                R2("Total Parts AUP") = decTotalPartsAUP
                dt.Rows.Add(R2)
                R2 = Nothing

                '*******************************************************************************************
                'Create Excel Files
                '*******************************************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                R1 = Nothing
                R2 = Nothing
                '*************************************************************
                ''%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                If iPSSIIndex = 0 Then      'Summary

                    '************************************************
                    'Get WC Locations
                    strSql = ""
                    strSql += "Select Distinct WCLocation_ID from tdevice inner join twcdetail on tdevice.tray_id = twcdetail.tray_id " & Environment.NewLine
                    strSql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                    strSql += " where tworkorder.prod_id = 1 and " & Environment.NewLine

                    If strFromBillDate = strToBillDate Then
                        strSql += "tdevice.device_datebill like '" & strFromBillDate & "%'" & Environment.NewLine
                    Else
                        strSql += "tdevice.device_datebill > '" & CStr(Format(DateAdd(DateInterval.Day, 0, CDate(strFromBillDate)), "yyyy-MM-dd")) & _
                                "' and tdevice.device_datebill < '" & CStr(Format(DateAdd(DateInterval.Day, 1, CDate(strToBillDate)), "yyyy-MM-dd")) & "' " & Environment.NewLine
                    End If

                    strSql += "Order by WCLocation_ID"

                    dtWCLocs = Me._objDataProc.GetDataTable(strSql)

                    '*********************************************************
                    'Create Summary Output table
                    '*********************************************************
                    'Clean up
                    'reset the variables
                    booBilldate = False
                    booWCLocation = False
                    strBilldate = ""
                    iPrevWCLocation_ID = 0
                    iPrevCust_ID = 0
                    iPrevModel_ID = 0
                    strWCLocation = ""
                    iTotalBilled = 0
                    iDBR = 0
                    iNER = 0
                    iTotalRepaired = 0
                    decTotalLaborRevenue = 0
                    decTotalLaborAUP = 0
                    decTotalPartsRevenue = 0
                    decTotalPartsAUP = 0
                    '*******************
                    dtSum = New DataTable("WCSummary")

                    ColNew = New DataColumn("Bill Date")
                    ColNew.DataType = System.Type.GetType("System.String")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("WCLocation_ID")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("WC Location")
                    ColNew.DataType = System.Type.GetType("System.String")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Billed")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("DBR")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("NER")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Repaired")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Labor Revenue")
                    ColNew.DataType = System.Type.GetType("System.Decimal")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Labor AUP")
                    ColNew.DataType = System.Type.GetType("System.Decimal")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Parts Revenue")
                    ColNew.DataType = System.Type.GetType("System.Decimal")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Parts AUP")
                    ColNew.DataType = System.Type.GetType("System.Decimal")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing
                    '******************************************************************
                    'Loop through  dt and insert into the summary table
                    For Each R1 In dt.Rows
                        If iPrevWCLocation_ID = R1("wclocation_id") And strBilldate = R1("Bill Date") Then
                            'do nothing
                        Else
                            'Write to the table
                            'Add row to the dt table
                            If iPrevWCLocation_ID <> 0 Then

                                'Calculate decTotalLaborAUP
                                decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)

                                'Calculate decTotalPartsAUP
                                decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                                R2 = dtSum.NewRow
                                R2("Bill Date") = strBilldate
                                R2("WCLocation_ID") = iPrevWCLocation_ID
                                R2("WC Location") = strWCLocation
                                R2("Total Billed") = iTotalBilled
                                R2("DBR") = iDBR
                                R2("NER") = iNER
                                R2("Total Repaired") = iTotalRepaired
                                R2("Total Labor Revenue") = decTotalLaborRevenue
                                R2("Total Labor AUP") = decTotalLaborAUP
                                R2("Total Parts Revenue") = decTotalPartsRevenue
                                R2("Total Parts AUP") = decTotalPartsAUP
                                dtSum.Rows.Add(R2)
                                R2 = Nothing
                            End If

                            'reset the loop variables
                            booBilldate = False
                            booWCLocation = False
                            strBilldate = ""
                            iPrevWCLocation_ID = 0
                            strWCLocation = ""
                            iTotalBilled = 0
                            iDBR = 0
                            iNER = 0
                            iTotalRepaired = 0
                            decTotalLaborRevenue = 0
                            decTotalLaborAUP = 0
                            decTotalPartsRevenue = 0
                            decTotalPartsAUP = 0
                        End If

                        '*****************
                        'Get the Row Info
                        '*****************
                        If booBilldate = False Then
                            strBilldate = R1("Bill Date")
                            booBilldate = True
                        End If
                        '******************
                        If booWCLocation = False Then
                            iPrevWCLocation_ID = R1("WCLocation_ID")
                            strWCLocation = R1("WC Location")
                            booWCLocation = True
                        End If
                        '******************
                        iTotalBilled += R1("Total Billed")
                        iDBR += R1("DBR")
                        iNER += R1("NER")
                        iTotalRepaired += R1("Total Repaired")
                        decTotalLaborRevenue += R1("Total Labor Revenue")
                        decTotalPartsRevenue += R1("Total Parts Revenue")
                        '******************
                    Next R1

                    'Add row to the summary table
                    'Calculate decTotalLaborAUP
                    decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)
                    'Calculate decTotalPartsAUP
                    decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                    R2 = dtSum.NewRow
                    R2("Bill Date") = strBilldate
                    R2("WCLocation_ID") = iPrevWCLocation_ID        'intWCLocation_ID
                    R2("WC Location") = strWCLocation
                    R2("Total Billed") = iTotalBilled
                    R2("DBR") = iDBR
                    R2("NER") = iNER
                    R2("Total Repaired") = iTotalRepaired
                    R2("Total Labor Revenue") = decTotalLaborRevenue
                    R2("Total Labor AUP") = decTotalLaborAUP
                    R2("Total Parts Revenue") = decTotalPartsRevenue
                    R2("Total Parts AUP") = decTotalPartsAUP
                    dtSum.Rows.Add(R2)
                    R1 = Nothing
                    R2 = Nothing

                    '******************************************************************
                    'Create the header
                    objExcel.Application.Cells(1, 1).Value = "Bill Date"
                    objExcel.Application.Cells(1, 2).Value = "WC Location"
                    objExcel.Application.Cells(1, 3).Value = "Total Billed"
                    objExcel.Application.Cells(1, 4).Value = "DBR"
                    objExcel.Application.Cells(1, 5).Value = "NER"
                    objExcel.Application.Cells(1, 6).Value = "Total Repaired"
                    objExcel.Application.Cells(1, 7).Value = "Total Labor Revenue"
                    objExcel.Application.Cells(1, 8).Value = "Total Labor AUP"
                    objExcel.Application.Cells(1, 9).Value = "Total Parts Revenue"
                    objExcel.Application.Cells(1, 10).Value = "Total Parts AUP"

                    ''******************************************************************
                    ''Write to excel file

                    strBilldate = ""
                    iTotalBilled = 0
                    iDBR = 0
                    iNER = 0
                    iTotalRepaired = 0
                    decTotalLaborRevenue = 0
                    decTotalLaborAUP = 0
                    decTotalPartsRevenue = 0
                    decTotalPartsAUP = 0
                    i = 3

                    For Each R1 In dtSum.Rows
                        If strBilldate <> "" Then
                            If strBilldate <> R1("Bill Date") Then

                                'Calculate decTotalLaborAUP
                                decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)
                                'Calculate decTotalPartsAUP
                                decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                                'write day totals row to excel
                                objExcel.Application.Cells(i, 2).Value = "Total by Day"
                                objExcel.Application.Cells(i, 3).Value = iTotalBilled
                                objExcel.Application.Cells(i, 4).Value = iDBR
                                objExcel.Application.Cells(i, 5).Value = iNER
                                objExcel.Application.Cells(i, 6).Value = iTotalRepaired
                                objExcel.Application.Cells(i, 7).Value = decTotalLaborRevenue
                                objExcel.Application.Cells(i, 8).Value = decTotalLaborAUP
                                objExcel.Application.Cells(i, 9).Value = decTotalPartsRevenue
                                objExcel.Application.Cells(i, 10).Value = decTotalPartsAUP

                                'Format the Total line
                                objSheet.Range("B" & i).Select()
                                With objExcel.Selection
                                    .HorizontalAlignment = Excel.Constants.xlLeft
                                    .font.bold = True
                                    .Font.ColorIndex = 3
                                End With

                                'Format the Total line
                                objSheet.Range("C" & i & ":J" & i).Select()
                                With objExcel.Selection
                                    .HorizontalAlignment = Excel.Constants.xlRight
                                    .font.bold = True
                                    .Font.ColorIndex = 5
                                End With

                                'Set the Day total variables to 0
                                strBilldate = ""
                                iTotalBilled = 0
                                iDBR = 0
                                iNER = 0
                                iTotalRepaired = 0
                                decTotalLaborRevenue = 0
                                decTotalLaborAUP = 0
                                decTotalPartsRevenue = 0
                                decTotalPartsAUP = 0

                                i += 2  'Empty row after each line total

                                '************************************
                                'Paste the header after each 'Total by Day'
                                'Commented because it is a luxury
                                '''objSheet.Range("A1:J1").Select()
                                '''objExcel.Selection.Copy()
                                '''objSheet.Range("A" & i & ":J" & i).Select()
                                '''objExcel.ActiveSheet.Paste()
                                '''i += 1

                                '************************************
                            End If
                        End If

                        objExcel.Application.Cells(i, 1).Value = R1("Bill Date")
                        objExcel.Application.Cells(i, 2).Value = R1("WC Location")
                        objExcel.Application.Cells(i, 3).Value = R1("Total Billed")
                        objExcel.Application.Cells(i, 4).Value = R1("DBR")
                        objExcel.Application.Cells(i, 5).Value = R1("NER")
                        objExcel.Application.Cells(i, 6).Value = R1("Total Repaired")
                        objExcel.Application.Cells(i, 7).Value = R1("Total Labor Revenue")
                        objExcel.Application.Cells(i, 8).Value = R1("Total Labor AUP")
                        objExcel.Application.Cells(i, 9).Value = R1("Total Parts Revenue")
                        objExcel.Application.Cells(i, 10).Value = R1("Total Parts AUP")
                        i += 1      'Row increment for excel sheet to write next line

                        'Summary Totals based on Bill Date grouping
                        iTotalBilled += R1("Total Billed")
                        iDBR += R1("DBR")
                        iNER += R1("NER")
                        iTotalRepaired += R1("Total Repaired")
                        decTotalLaborRevenue += R1("Total Labor Revenue")
                        decTotalPartsRevenue += R1("Total Parts Revenue")

                        strBilldate = R1("Bill Date")
                    Next R1

                    'Calculate decTotalLaborAUP
                    decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)
                    'Calculate decTotalPartsAUP
                    decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                    'Add the last Day Summary Totals
                    'write day totals row to excel
                    objExcel.Application.Cells(i, 2).Value = "Total by Day"
                    objExcel.Application.Cells(i, 3).Value = iTotalBilled
                    objExcel.Application.Cells(i, 4).Value = iDBR
                    objExcel.Application.Cells(i, 5).Value = iNER
                    objExcel.Application.Cells(i, 6).Value = iTotalRepaired
                    objExcel.Application.Cells(i, 7).Value = decTotalLaborRevenue
                    objExcel.Application.Cells(i, 8).Value = decTotalLaborAUP
                    objExcel.Application.Cells(i, 9).Value = decTotalPartsRevenue
                    objExcel.Application.Cells(i, 10).Value = decTotalPartsAUP

                    'Format the Total line
                    objSheet.Range("B" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .font.bold = True
                        .Font.ColorIndex = 3
                    End With
                    objSheet.Range("C" & i & ":J" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlRight
                        .font.bold = True
                        .Font.ColorIndex = 5
                    End With

                    'Set the Day total variables to 0
                    strBilldate = ""
                    strWCLocation = ""
                    iTotalBilled = 0
                    iDBR = 0
                    iNER = 0
                    iTotalRepaired = 0
                    decTotalLaborRevenue = 0
                    decTotalLaborAUP = 0
                    decTotalPartsRevenue = 0
                    decTotalPartsAUP = 0
                    i += 2  'Empty row after each line total
                    '********************************************
                    R1 = Nothing
                    R2 = Nothing
                    '********************************************
                    objExcel.Application.Cells(i, 2).Value = "Totals by Location"
                    objSheet.Range("B" & i).Select()
                    With objExcel.Selection
                        .font.bold = True
                        .Font.ColorIndex = 3
                    End With
                    i += 1
                    '********************************************
                    'Write Totals by Line to excel
                    '********************************************
                    For Each R1 In dtWCLocs.Rows
                        For Each R2 In dtSum.Rows

                            If R1("WCLocation_ID") = R2("WCLocation_ID") Then
                                strWCLocation = R2("WC Location")
                                iTotalBilled += R2("Total Billed")
                                iDBR += R2("DBR")
                                iNER += R2("NER")
                                iTotalRepaired += R2("Total Repaired")
                                decTotalLaborRevenue += R2("Total Labor Revenue")
                                decTotalPartsRevenue += R2("Total Parts Revenue")
                            End If
                        Next R2

                        'Calculate decTotalLaborAUP
                        decTotalLaborAUP = Math.Round(decTotalLaborRevenue / iTotalBilled, 2)
                        'Calculate decTotalPartsAUP
                        decTotalPartsAUP = Math.Round(decTotalPartsRevenue / iTotalBilled, 2)

                        'write Line totals to excel
                        objExcel.Application.Cells(i, 2).Value = strWCLocation
                        objExcel.Application.Cells(i, 3).Value = iTotalBilled
                        objExcel.Application.Cells(i, 4).Value = iDBR
                        objExcel.Application.Cells(i, 5).Value = iNER
                        objExcel.Application.Cells(i, 6).Value = iTotalRepaired
                        objExcel.Application.Cells(i, 7).Value = decTotalLaborRevenue
                        objExcel.Application.Cells(i, 8).Value = decTotalLaborAUP
                        objExcel.Application.Cells(i, 9).Value = decTotalPartsRevenue
                        objExcel.Application.Cells(i, 10).Value = decTotalPartsAUP

                        'Grand totals
                        iGrandTotalBilled += iTotalBilled
                        iGrandDBR += iDBR
                        iGrandNER += iNER
                        iGrandTotalRepaired += iTotalRepaired
                        decGrandTotalLaborRevenue += decTotalLaborRevenue
                        decGrandTotalPartsRevenue += decTotalPartsRevenue

                        'Format the Total line
                        objSheet.Range("C" & i & ":J" & i).Select()
                        With objExcel.Selection
                            .HorizontalAlignment = Excel.Constants.xlRight
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        'Reset the loop variables
                        strBilldate = ""
                        strWCLocation = ""
                        iTotalBilled = 0
                        iDBR = 0
                        iNER = 0
                        iTotalRepaired = 0
                        decTotalLaborRevenue = 0
                        decTotalLaborAUP = 0
                        decTotalPartsRevenue = 0
                        decTotalPartsAUP = 0
                        i += 1
                    Next R1

                    'Calculate decTotalLaborAUP
                    decGrandTotalLaborAUP = Math.Round(decGrandTotalLaborRevenue / iGrandTotalBilled, 2)
                    'Calculate decTotalPartsAUP
                    decGrandTotalPartsAUP = Math.Round(decGrandTotalPartsRevenue / iGrandTotalBilled, 2)


                    i += 1
                    objExcel.Application.Cells(i, 2).Value = "Grand Total"
                    objExcel.Application.Cells(i, 3).Value = iGrandTotalBilled
                    objExcel.Application.Cells(i, 4).Value = iGrandDBR
                    objExcel.Application.Cells(i, 5).Value = iGrandNER
                    objExcel.Application.Cells(i, 6).Value = iGrandTotalRepaired
                    objExcel.Application.Cells(i, 7).Value = decGrandTotalLaborRevenue
                    objExcel.Application.Cells(i, 8).Value = decGrandTotalLaborAUP
                    objExcel.Application.Cells(i, 9).Value = decGrandTotalPartsRevenue
                    objExcel.Application.Cells(i, 10).Value = decGrandTotalPartsAUP

                    'Format the Total line
                    objSheet.Range("B" & i & ":J" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlRight
                        .font.bold = True
                        .Font.ColorIndex = 3
                    End With

                    '********************************************
                    'Format the excel sheet
                    '********************************************
                    'Format Column A  (Bill date)
                    objSheet.Columns("A:A").ColumnWidth = 16
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column B  (WC Location)
                    objSheet.Columns("B:B").ColumnWidth = 28
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column C  (Total Billed)
                    objSheet.Columns("C:C").ColumnWidth = 11.85
                    objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("C:C").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column D  (DBR)
                    objSheet.Columns("D:D").ColumnWidth = 4.6
                    objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("D:D").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column E  (NER)
                    objSheet.Columns("E:E").ColumnWidth = 4.6
                    objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("E:E").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column F  (Total Repaired)
                    objSheet.Columns("F:F").ColumnWidth = 14.15
                    objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("F:F").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column G  (Total Labor Revenue)
                    objSheet.Columns("G:G").ColumnWidth = 19.6
                    objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("G:G").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'Format Column H  (Total Labor AUP)
                    objSheet.Columns("H:H").ColumnWidth = 15.3
                    objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("H:H").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'Format Column I  (Total Parts Revenue)
                    objSheet.Columns("I:I").ColumnWidth = 19
                    objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("I:I").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'Format Column J  (Total Parts AUP)
                    objSheet.Columns("J:J").ColumnWidth = 13.9
                    objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("J:J").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'header::: Align and set the header 
                    objSheet.Range("A1:J1").Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Interior.ColorIndex = 36
                        .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    End With
                    'Set the border for each cell in header
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
                    'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    '    .LineStyle = Excel.XlLineStyle.xlContinuous
                    '    .Weight = Excel.XlBorderWeight.xlThin
                    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    'End With

                    '************************************************
                    'Save the excel file
                    objBook.SaveAs(strSummaryFilePath & strFromBillDate & "_" & strToBillDate & ".xls")

                    '*************************************
                    'Excel clean up
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
                    '*************************************
                    'OPen Excel File
                    objXL = New Excel.Application()
                    objXL.Workbooks.Open(strSummaryFilePath & strFromBillDate & "_" & strToBillDate & ".xls")
                    objXL.Visible = True

                    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                ElseIf iPSSIIndex = 999 Then  'Summary Report for the floor
                    '************************************************
                    'Get WC Locations
                    strSql = ""
                    strSql += "Select Distinct WCLocation_ID from tdevice inner join twcdetail on tdevice.tray_id = twcdetail.tray_id " & Environment.NewLine
                    strSql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                    strSql += " where tworkorder.prod_id = 1 and " & Environment.NewLine

                    If strFromBillDate = strToBillDate Then
                        strSql += "tdevice.device_datebill like '" & strFromBillDate & "%'" & Environment.NewLine
                    Else
                        strSql += "tdevice.device_datebill > '" & CStr(Format(DateAdd(DateInterval.Day, 0, CDate(strFromBillDate)), "yyyy-MM-dd")) & _
                                "' and tdevice.device_datebill < '" & CStr(Format(DateAdd(DateInterval.Day, 1, CDate(strToBillDate)), "yyyy-MM-dd")) & "' " & Environment.NewLine
                    End If

                    strSql += "Order by WCLocation_ID"

                    dtWCLocs = Me._objDataProc.GetDataTable(strSql)

                    '*********************************************************
                    'Create Summary Output table
                    '*********************************************************
                    'Clean up
                    'reset the variables
                    booBilldate = False
                    booWCLocation = False
                    strBilldate = ""
                    iPrevWCLocation_ID = 0
                    iPrevCust_ID = 0
                    iPrevModel_ID = 0
                    strWCLocation = ""
                    iTotalBilled = 0
                    iDBR = 0
                    iNER = 0
                    iTotalRepaired = 0

                    '*******************
                    dtSum = New DataTable("WCSummary")

                    ColNew = New DataColumn("Bill Date")
                    ColNew.DataType = System.Type.GetType("System.String")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("WCLocation_ID")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("WC Location")
                    ColNew.DataType = System.Type.GetType("System.String")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Billed")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("DBR")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("NER")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Total Repaired")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    dtSum.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    '******************************************************************
                    'Loop through  dt and insert into the summary table
                    For Each R1 In dt.Rows
                        If iPrevWCLocation_ID = R1("wclocation_id") And strBilldate = R1("Bill Date") Then
                            'do nothing
                        Else
                            'Write to the table
                            'Add row to the dt table
                            If iPrevWCLocation_ID <> 0 Then

                                R2 = dtSum.NewRow
                                R2("Bill Date") = strBilldate
                                R2("WCLocation_ID") = iPrevWCLocation_ID
                                R2("WC Location") = strWCLocation
                                R2("Total Billed") = iTotalBilled
                                R2("DBR") = iDBR
                                R2("NER") = iNER
                                R2("Total Repaired") = iTotalRepaired

                                dtSum.Rows.Add(R2)
                                R2 = Nothing
                            End If

                            'reset the loop variables
                            booBilldate = False
                            booWCLocation = False
                            strBilldate = ""
                            iPrevWCLocation_ID = 0
                            strWCLocation = ""
                            iTotalBilled = 0
                            iDBR = 0
                            iNER = 0
                            iTotalRepaired = 0

                        End If

                        '*****************
                        'Get the Row Info
                        '*****************
                        If booBilldate = False Then
                            strBilldate = R1("Bill Date")
                            booBilldate = True
                        End If
                        '******************
                        If booWCLocation = False Then
                            iPrevWCLocation_ID = R1("WCLocation_ID")
                            strWCLocation = R1("WC Location")
                            booWCLocation = True
                        End If
                        '******************
                        iTotalBilled += R1("Total Billed")
                        iDBR += R1("DBR")
                        iNER += R1("NER")
                        iTotalRepaired += R1("Total Repaired")
                        '******************
                    Next R1

                    'Add row to the summary table

                    R2 = dtSum.NewRow
                    R2("Bill Date") = strBilldate
                    R2("WCLocation_ID") = iPrevWCLocation_ID        'intWCLocation_ID
                    R2("WC Location") = strWCLocation
                    R2("Total Billed") = iTotalBilled
                    R2("DBR") = iDBR
                    R2("NER") = iNER
                    R2("Total Repaired") = iTotalRepaired

                    dtSum.Rows.Add(R2)
                    R1 = Nothing
                    R2 = Nothing

                    '******************************************************************
                    'Create the header
                    objExcel.Application.Cells(1, 1).Value = "Bill Date"
                    objExcel.Application.Cells(1, 2).Value = "WC Location"
                    objExcel.Application.Cells(1, 3).Value = "Total Billed"
                    objExcel.Application.Cells(1, 4).Value = "DBR"
                    objExcel.Application.Cells(1, 5).Value = "NER"
                    objExcel.Application.Cells(1, 6).Value = "Total Repaired"

                    ''******************************************************************
                    ''Write to excel file

                    strBilldate = ""
                    iTotalBilled = 0
                    iDBR = 0
                    iNER = 0
                    iTotalRepaired = 0

                    i = 3

                    For Each R1 In dtSum.Rows
                        If strBilldate <> "" Then
                            If strBilldate <> R1("Bill Date") Then

                                'write day totals row to excel
                                objExcel.Application.Cells(i, 2).Value = "Total by Day"
                                objExcel.Application.Cells(i, 3).Value = iTotalBilled
                                objExcel.Application.Cells(i, 4).Value = iDBR
                                objExcel.Application.Cells(i, 5).Value = iNER
                                objExcel.Application.Cells(i, 6).Value = iTotalRepaired

                                'Format the Total line
                                objSheet.Range("B" & i).Select()
                                With objExcel.Selection
                                    .HorizontalAlignment = Excel.Constants.xlLeft
                                    .font.bold = True
                                    .Font.ColorIndex = 3
                                End With

                                'Format the Total line
                                objSheet.Range("C" & i & ":F" & i).Select()
                                With objExcel.Selection
                                    .HorizontalAlignment = Excel.Constants.xlRight
                                    .font.bold = True
                                    .Font.ColorIndex = 5
                                End With

                                'Set the Day total variables to 0
                                strBilldate = ""
                                iTotalBilled = 0
                                iDBR = 0
                                iNER = 0
                                iTotalRepaired = 0

                                i += 2  'Empty row after each line total
                            End If
                        End If

                        objExcel.Application.Cells(i, 1).Value = R1("Bill Date")
                        objExcel.Application.Cells(i, 2).Value = R1("WC Location")
                        objExcel.Application.Cells(i, 3).Value = R1("Total Billed")
                        objExcel.Application.Cells(i, 4).Value = R1("DBR")
                        objExcel.Application.Cells(i, 5).Value = R1("NER")
                        objExcel.Application.Cells(i, 6).Value = R1("Total Repaired")

                        i += 1      'Row increment for excel sheet to write next line

                        'Summary Totals based on Bill Date grouping
                        iTotalBilled += R1("Total Billed")
                        iDBR += R1("DBR")
                        iNER += R1("NER")
                        iTotalRepaired += R1("Total Repaired")

                        strBilldate = R1("Bill Date")
                    Next R1

                    'Add the last Day Summary Totals
                    'write day totals row to excel
                    objExcel.Application.Cells(i, 2).Value = "Total by Day"
                    objExcel.Application.Cells(i, 3).Value = iTotalBilled
                    objExcel.Application.Cells(i, 4).Value = iDBR
                    objExcel.Application.Cells(i, 5).Value = iNER
                    objExcel.Application.Cells(i, 6).Value = iTotalRepaired

                    'Format the Total line
                    objSheet.Range("B" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        .font.bold = True
                        .Font.ColorIndex = 3
                    End With
                    objSheet.Range("C" & i & ":F" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlRight
                        .font.bold = True
                        .Font.ColorIndex = 5
                    End With

                    'Set the Day total variables to 0
                    strBilldate = ""
                    strWCLocation = ""
                    iTotalBilled = 0
                    iDBR = 0
                    iNER = 0
                    iTotalRepaired = 0

                    i += 2  'Empty row after each line total
                    '********************************************
                    R1 = Nothing
                    R2 = Nothing
                    '********************************************
                    objExcel.Application.Cells(i, 2).Value = "Totals by Location"
                    objSheet.Range("B" & i).Select()
                    With objExcel.Selection
                        .font.bold = True
                        .Font.ColorIndex = 3
                    End With
                    i += 1
                    '********************************************
                    'Write Totals by Line to excel
                    '********************************************
                    For Each R1 In dtWCLocs.Rows
                        For Each R2 In dtSum.Rows

                            If R1("WCLocation_ID") = R2("WCLocation_ID") Then
                                strWCLocation = R2("WC Location")
                                iTotalBilled += R2("Total Billed")
                                iDBR += R2("DBR")
                                iNER += R2("NER")
                                iTotalRepaired += R2("Total Repaired")

                            End If
                        Next R2

                        'write Line totals to excel
                        objExcel.Application.Cells(i, 2).Value = strWCLocation
                        objExcel.Application.Cells(i, 3).Value = iTotalBilled
                        objExcel.Application.Cells(i, 4).Value = iDBR
                        objExcel.Application.Cells(i, 5).Value = iNER
                        objExcel.Application.Cells(i, 6).Value = iTotalRepaired

                        'Grand totals
                        iGrandTotalBilled += iTotalBilled
                        iGrandDBR += iDBR
                        iGrandNER += iNER
                        iGrandTotalRepaired += iTotalRepaired

                        'Format the Total line
                        objSheet.Range("C" & i & ":F" & i).Select()
                        With objExcel.Selection
                            .HorizontalAlignment = Excel.Constants.xlRight
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        'Reset the loop variables
                        strBilldate = ""
                        strWCLocation = ""
                        iTotalBilled = 0
                        iDBR = 0
                        iNER = 0
                        iTotalRepaired = 0

                        i += 1
                    Next R1

                    i += 1
                    objExcel.Application.Cells(i, 2).Value = "Grand Total"
                    objExcel.Application.Cells(i, 3).Value = iGrandTotalBilled
                    objExcel.Application.Cells(i, 4).Value = iGrandDBR
                    objExcel.Application.Cells(i, 5).Value = iGrandNER
                    objExcel.Application.Cells(i, 6).Value = iGrandTotalRepaired

                    'Format the Total line
                    objSheet.Range("B" & i & ":F" & i).Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlRight
                        .font.bold = True
                        .Font.ColorIndex = 3
                    End With

                    '********************************************
                    'Format the excel sheet
                    '********************************************
                    'Format Column A  (Bill date)
                    objSheet.Columns("A:A").ColumnWidth = 16
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column B  (WC Location)
                    objSheet.Columns("B:B").ColumnWidth = 28
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column C  (Total Billed)
                    objSheet.Columns("C:C").ColumnWidth = 11.85
                    objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("C:C").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column D  (DBR)
                    objSheet.Columns("D:D").ColumnWidth = 4.6
                    objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("D:D").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column E  (NER)
                    objSheet.Columns("E:E").ColumnWidth = 4.6
                    objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("E:E").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column F  (Total Repaired)
                    objSheet.Columns("F:F").ColumnWidth = 14.15
                    objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("F:F").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'header::: Align and set the header 
                    objSheet.Range("A1:F1").Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Interior.ColorIndex = 36
                        .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    End With
                    'Set the border for each cell in header
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
                    'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    '    .LineStyle = Excel.XlLineStyle.xlContinuous
                    '    .Weight = Excel.XlBorderWeight.xlThin
                    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    'End With

                    '************************************************
                    'Save the excel file
                    objBook.SaveAs(strSummaryFilePathForFloor & strFromBillDate & "_" & strToBillDate & ".xls")

                    '*************************************
                    'Excel clean up
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
                    '*************************************
                    'Open Excel File
                    objXL = New Excel.Application()
                    objXL.Workbooks.Open(strSummaryFilePathForFloor & strFromBillDate & "_" & strToBillDate & ".xls")
                    objXL.Visible = True

                    ''%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                ElseIf iPSSIIndex = 1 Then  'detail
                    'Create the header
                    objExcel.Application.Cells(1, 1).Value = "Bill Date"
                    objExcel.Application.Cells(1, 2).Value = "WC Location"
                    objExcel.Application.Cells(1, 3).Value = "Customer"
                    objExcel.Application.Cells(1, 4).Value = "Model"
                    objExcel.Application.Cells(1, 5).Value = "Total Billed"
                    objExcel.Application.Cells(1, 6).Value = "DBR"
                    objExcel.Application.Cells(1, 7).Value = "NER"
                    objExcel.Application.Cells(1, 8).Value = "Total Repaired"
                    objExcel.Application.Cells(1, 9).Value = "Total Labor Revenue"
                    objExcel.Application.Cells(1, 10).Value = "Total Labor AUP"
                    objExcel.Application.Cells(1, 11).Value = "Total Parts Revenue"
                    objExcel.Application.Cells(1, 12).Value = "Total Parts AUP"

                    'Loop through the respective table to create the body
                    For Each R1 In dt.Rows
                        If i = 29 Then
                            MsgBox("stop")
                        End If
                        objExcel.Application.Cells(i, 1).Value = R1("Bill Date")
                        objExcel.Application.Cells(i, 2).Value = R1("WC Location")
                        objExcel.Application.Cells(i, 3).Value = R1("Customer")
                        objExcel.Application.Cells(i, 4).Value = R1("Model")
                        objExcel.Application.Cells(i, 5).Value = R1("Total Billed")
                        objExcel.Application.Cells(i, 6).Value = R1("DBR")
                        objExcel.Application.Cells(i, 7).Value = R1("NER")
                        objExcel.Application.Cells(i, 8).Value = R1("Total Repaired")
                        objExcel.Application.Cells(i, 9).Value = R1("Total Labor Revenue")
                        objExcel.Application.Cells(i, 10).Value = R1("Total Labor AUP")
                        objExcel.Application.Cells(i, 11).Value = R1("Total Parts Revenue")
                        objExcel.Application.Cells(i, 12).Value = R1("Total Parts AUP")
                        i += 1
                    Next R1

                    '********************************************
                    'Format the excel sheet
                    '********************************************
                    'Format Column A  (Bill date)
                    objSheet.Columns("A:A").ColumnWidth = 10
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column B  (WC Location)
                    objSheet.Columns("B:B").ColumnWidth = 20.5
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column C  (Customer)
                    objSheet.Columns("C:C").ColumnWidth = 33.3
                    objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column D  (Model)
                    objSheet.Columns("D:D").ColumnWidth = 22
                    objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                    'Format Column E  (Total Billed)
                    objSheet.Columns("E:E").ColumnWidth = 11.85
                    objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("E:E").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column F  (DBR)
                    objSheet.Columns("F:F").ColumnWidth = 4.6
                    objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("F:F").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column G  (NER)
                    objSheet.Columns("G:G").ColumnWidth = 4.6
                    objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("G:G").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column H  (Total Repaired)
                    objSheet.Columns("H:H").ColumnWidth = 14.15
                    objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("H:H").Select()
                    objExcel.Selection.NumberFormat = "0;[Red]0"    '1234 format 

                    'Format Column I  (Total Labor Revenue)
                    objSheet.Columns("I:I").ColumnWidth = 19.6
                    objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("I:I").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'Format Column J  (Total Labor AUP)
                    objSheet.Columns("J:J").ColumnWidth = 15.3
                    objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("J:J").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'Format Column K  (Total Parts Revenue)
                    objSheet.Columns("K:K").ColumnWidth = 19
                    objSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("K:K").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'Format Column L  (Total Parts AUP)
                    objSheet.Columns("L:L").ColumnWidth = 13.9
                    objSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlRight
                    objSheet.Columns("L:L").Select()
                    objExcel.Selection.NumberFormat = "$#,##0.00;[Red]$#,##0.00"    '$9999.99 format 

                    'header::: Align and set the header 
                    objSheet.Range("A1:L1").Select()
                    With objExcel.Selection
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Interior.ColorIndex = 36
                        .Interior.Pattern = Excel.XlPattern.xlPatternSolid
                    End With
                    'Set the border for each cell in header
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
                    'With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    '    .LineStyle = Excel.XlLineStyle.xlContinuous
                    '    .Weight = Excel.XlBorderWeight.xlThin
                    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    'End With
                    '************************************************
                    'Save the excel file
                    objBook.SaveAs(strDetailFilePath & strFromBillDate & "_" & strToBillDate & ".xls")

                    '*************************************
                    'Excel clean up
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
                    '*************************************
                    'Open Excel File
                    objXL = New Excel.Application()
                    objXL.Workbooks.Open(strDetailFilePath & strFromBillDate & "_" & strToBillDate & ".xls")
                    objXL.Visible = True
                End If
                ''%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                Return 1
            Catch ex As Exception
                'MsgBox("Stop")
                Throw New Exception("Buisness.Misc.GenerateWCDetailReport(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                strSql = ""
                If Not IsNothing(ColNew) Then
                    ColNew.Dispose()
                    ColNew = Nothing
                End If

                R1 = Nothing
                R2 = Nothing
                DisposeDT(dt1)
                DisposeDT(dtSum)
                DisposeDT(dt)
                DisposeDT(dtWCLocs)

            End Try

        End Function


        '****************************************************************************
        'Get DeviceInfo by Device_ID
        '****************************************************************************
        Public Function GetDeviceInfo(ByVal strDeviceSN As String) As DataTable
            Try
                'objMisc._SQL = "Select tdevice.*, tmodel.model_desc from tdevice inner join tmodel on tdevice.model_id = tmodel.model_id where Device_sn = '" & Trim(strDeviceSN) & "' order by device_daterec desc;"
                strSql = "Select " & Environment.NewLine
                strSql &= "tdevice.*, tmodel.model_desc, tmodel.prod_id, tcustomer.cust_id, tcustomer.cust_name1 " & Environment.NewLine
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "where tmodel.prod_id <> 1 and Device_sn = '" & Trim(strDeviceSN) & "' " & Environment.NewLine
                strSql &= "and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= "and pallett_id is null " & Environment.NewLine
                strSql &= "order by device_daterec desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch Ex As Exception
                Throw New Exception("Buisness.Misc.GetDeviceInfo(): " & Environment.NewLine & Ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Get Parts for a device
        '****************************************************************************
        Public Function GetPartsForDevice(ByVal strDeviceSN As String) As DataTable
            Dim R1 As DataRow

            Try
                strSql = "Select Device_ID from tdevice where Device_sn = '" & Trim(strDeviceSN) & "' order by device_daterec desc;"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    strSql = "Select lpsprice.psprice_Desc from tdevice " & Environment.NewLine
                    strSql += "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                    strSql += "inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                    strSql += "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                    strSql += "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                    strSql += "where lbillcodes.billtype_id = 2 and tdevice.device_id = " & R1("Device_ID") & Environment.NewLine
                    strSql += " order by psprice_Desc"

                    Return Me._objDataProc.GetDataTable(strSql)
                End If
            Catch Ex As Exception
                Throw New Exception("Buisness.Misc.GetPartsForDevice(): " & Environment.NewLine & Ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        'GetModels based on Prod_ID (Messaging or cellular)
        '***************************************************
        Public Function GetModels(Optional ByVal iProd_ID As Integer = 0, _
                                    Optional ByVal iFilterFlg As Integer = 0, _
                                    Optional ByVal iManufID As Integer = 0)
            Dim dt As DataTable

            Try
                strSql = "Select distinct Model_id, model_desc "
                strSql &= "from tmodel "

                If iProd_ID > 0 Or iFilterFlg > 0 Or iManufID > 0 Then
                    strSql &= " where "
                End If

                If iProd_ID > 0 Then strSql &= " prod_id = " & iProd_ID & " "

                If iFilterFlg > 0 Then
                    If strSql.Trim.EndsWith("where") = False Then strSql &= " and "
                    strSql += " Model_MotoSku is not null "
                End If

                If iManufID > 0 Then
                    If strSql.Trim.EndsWith("where") = False Then strSql &= " and "
                    strSql += " Manuf_ID = " & iManufID
                End If

                strSql += " order by Model_Desc;"

                dt = Me._objDataProc.GetDataTable(strSql)
                InsertEmptyRow(dt, , "Model_id", "model_desc", , , "--Select--")

                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetModels(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Get Sku
        '***************************************************
        Public Function GetSku(ByVal iCust_id As Integer, _
                               ByVal iModel_id As Integer, _
                               Optional ByVal booAddSlectRow As Boolean = False) As DataTable
            Dim strsql As String = ""
            Dim dt As DataTable

            Try
                strsql = "select * from tsku where cust_id = " & iCust_id.ToString & " and model_id = " & iModel_id.ToString & " order by Sku_Number"

                dt = Me._objDataProc.GetDataTable(strsql)

                If booAddSlectRow = True Then dt.LoadDataRow(New String() {"0", "--Select--"}, False)

                Return dt
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.GetSku(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************
        'Get customer with Cust_ID
        '***************************************************
        Public Function GetCustomerInfo(ByVal iCust_ID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select tcustomer.cust_id, tcustomer.cust_name1 from tcustomer where cust_id = " & iCust_ID & ";"

                Return Me._objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.GetCustomerInfo(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '***************************************************
        'Getcustomers based on Prod_ID
        '***************************************************
        Public Function GetCustomers(Optional ByVal iProd_ID As Integer = 0, _
                                     Optional ByVal strCustList As String = "") As DataTable
            Dim dt As DataTable

            Try
                strSql = "Select distinct tcustomer.cust_id,tcustomer.cust_name1 "
                strSql += "from tcustomer inner join tcusttoprice on tcustomer.cust_id = tcusttoprice.cust_id "
                strSql += " where Cust_Inactive = 0 AND tcustomer.cust_name2 is null "

                If iProd_ID <> 0 Then strSql += " and tcusttoprice.prod_id = " & iProd_ID.ToString
                If strCustList <> "" Then strSql += " and tcustomer.Cust_id in ( " & strCustList & " ) "

                strSql += " order by cust_name1"

                dt = Me._objDataProc.GetDataTable(strSql)
                InsertEmptyRow(dt, , "cust_id", "cust_name1", , , "-- Select --")

                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetCustomers(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '****************************************************************************
        'Get Locations For Customer
        '****************************************************************************
        Public Function GetLocations(Optional ByVal iCust_ID As Integer = 0) As DataTable
            Dim dt As DataTable
            Dim myDataRow As DataRow

            Try
                If iCust_ID > 0 Then
                    strSql = "select distinct loc_id, loc_name from tlocation where cust_id = " & iCust_ID.ToString
                Else
                    strSql = "select distinct loc_id, loc_name from tlocation"
                End If

                dt = Me._objDataProc.GetDataTable(strSql)

                'Insert an empty row into the datatable
                myDataRow = dt.NewRow
                myDataRow("Loc_ID") = 0
                myDataRow("Loc_Name") = "-- Select --"
                dt.Rows.Add(myDataRow)
                myDataRow = Nothing

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("Buisness.Misc.GetLocations: " & ex.Message.ToString)
            End Try
        End Function

        '****************************************************************************
        'Get Location From Loc_Name
        '****************************************************************************
        Public Function GetLocation(ByVal sLoc_Name As String) As DataTable
            Dim dt As DataTable
            Dim myDataRow As DataRow

            Try
                strSql = "select distinct loc_id, loc_name from tlocation where loc_name = '" & sLoc_Name.ToString & "';"


                dt = Me._objDataProc.GetDataTable(strSql)

                'Insert an empty row into the datatable
                myDataRow = dt.NewRow
                myDataRow("Loc_ID") = 0
                myDataRow("Loc_Name") = "-- Select --"
                dt.Rows.Add(myDataRow)
                myDataRow = Nothing

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("Buisness.Misc.GetLocations: " & ex.Message.ToString)
            End Try
        End Function

        '***************************************************
        'Set the WC Location Info
        '***************************************************
        Public Function SetupWCFile() As String
            Return ObjLib.SetupWCFile(strFolderPath, strFolder, strFilePath, strFile)
        End Function
        '***************************************************
        'Updates the WC info
        '***************************************************
        Public Function UpdateWCInfo(ByVal iWCLocation_ID As Integer) As Integer
            Return ObjLib.UpdateWCInfo(strFilePath & strFile, iWCLocation_ID)
        End Function
        '***************************************************
        'Check if Tray is already scanned in
        '***************************************************
        Public Function CheckTray(ByVal iTray_ID As Integer) As Integer
            Dim strSql As String
            Dim dr As DataRow
            Dim iTrayExists As Integer = 0

            Try
                strSql = "SELECT COUNT(*) AS TrayCount " & Environment.NewLine
                strSql &= "FROM twcdetail " & Environment.NewLine
                strSql &= "WHERE Tray_ID = " & iTray_ID.ToString.Trim

                dr = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(dr) Then
                    If Not IsDBNull(dr) Then iTrayExists = dr("TrayCount")
                End If

                Return iTrayExists
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        '***************************************************
        'Get DeviceCount in a Tray
        '***************************************************
        Public Function DeviceCountInTray(ByVal iTray_ID As Integer) As Integer
            Dim strSQL As String
            Dim R1 As DataRow
            Dim iPagerCount As Integer = 0

            Try
                strSQL = "Select Count(*) as PagerCount from tdevice where tray_id = " & iTray_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(R1) Then iPagerCount = R1("PagerCount")

                Return iPagerCount
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        'Input Tray
        '***************************************************
        Public Function InputTray(ByVal iTray_ID As Integer, _
                                    ByVal iWCLoaction_ID As Integer) As Integer
            Dim i As Integer = 0
            Dim strSQL As String

            Try
                '******************************
                'Check if the Tray is already scanned in
                i = Me.CheckTray(iTray_ID)

                If i > 0 Then
                    Throw New Exception("Production.Misc.InputTray:: This tray is already scanned in. To delete and rescan it contact your supervisor.")
                End If
                '******************************
                'Get the number of devices in the tray
                i = 0
                i = Me.DeviceCountInTray(iTray_ID)

                If i > 0 Then
                    'Insert the Tray data in to database
                    strSQL = "insert into twcdetail (Tray_ID, WCDetail_TimeIn, WCDetail_DeviceCnt, WCLocation_ID) values (" & iTray_ID.ToString & ", Now(), " & i & ", " & iWCLoaction_ID.ToString & ")"

                    Return Me._objDataProc.ExecuteNonQuery(strSQL)
                Else
                    Throw New Exception("Production.Misc.InputTray:: Tray doesn't exist.")
                End If
                '******************************
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***************************************************
        'Get cust_id by tray_id
        '***************************************************
        Public Function GetCustIDByTrayID(ByVal iTray_ID As Integer) As Integer
            Dim strSQL As String
            Dim R1 As DataRow

            Try
                strSQL = "Select distinct tlocation.cust_id from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tray_id = " & iTray_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSQL)

                Return R1("Cust_ID")
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.GetCustIDByTrayID(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try

        End Function

        '***************************************************
        'Get Tray Line Info
        '***************************************************
        Public Function GetTrayLineInfo(ByVal iWCLocation_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                'If iWCLocation_ID = 16 Then     'Line 2 Shift 1 = 16 ;     Line 2 Shift 1 (SBC) = 43
                '    objMisc._SQL = "SELECT Tray_ID as 'Tray ID', WCDetail_TimeIn as 'Time in', WCDetail_DeviceCnt as 'Pager Count' FROM twcdetail where WCLocation_id in (16, 43) order by wcdetail_timein desc limit 20;"
                'Else
                '    objMisc._SQL = "SELECT Tray_ID as 'Tray ID', WCDetail_TimeIn as 'Time in', WCDetail_DeviceCnt as 'Pager Count' FROM twcdetail where WCLocation_id = " & iWCLocation_ID & " order by wcdetail_timein desc limit 20;"
                'End If

                If iWCLocation_ID = 16 Then     'Line 2 Shift 1 = 16 ;     Line 2 Shift 1 (SBC) = 43
                    strSQL = "SELECT Tray_ID as 'Tray ID', DATE_FORMAT(WCDetail_TimeIn, '%m/%d/%Y %r') AS 'Time in', WCDetail_DeviceCnt as 'Pager Count' FROM twcdetail where WCLocation_id in (16, 43) order by wcdetail_timein desc limit 20"
                Else
                    strSQL = "SELECT Tray_ID as 'Tray ID', DATE_FORMAT(WCDetail_TimeIn, '%m/%d/%Y %r') AS 'Time in', WCDetail_DeviceCnt as 'Pager Count' FROM twcdetail where WCLocation_id = " & iWCLocation_ID.ToString & " order by wcdetail_timein desc limit 20"
                End If

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetTrayLineInfo(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function
        '***************************************************
        'Move tray from one line to another
        '***************************************************
        Public Function MoveTrayToNewLine(ByVal iTray_ID As Integer, _
                                        ByVal iPrevWCLocationID As Integer, _
                                        ByVal iNewWCLocation_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "Update twcdetail set WCLocation_ID = " & iNewWCLocation_ID.ToString & " where Tray_ID = " & iTray_ID.ToString & " and WCLocation_ID = " & iPrevWCLocationID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.MoveTrayToNewLine(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function
        '***************************************************
        'Get Line by Tray
        '***************************************************
        Public Function GetLineTrayAssignedTo(ByVal iTray_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "Select twcdetail.WCLocation_ID, lwclocation.WC_Location from twcdetail inner join lwclocation on twcdetail.WCLocation_ID = lwclocation.WCLocation_ID where tray_id = " & iTray_ID.ToString

                dt = Me._objDataProc.GetDataTable(strSQL)
                InsertEmptyRow(dt, , "WCLocation_ID", "WC_Location", , , "-- Select --")

                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetLineTrayAssignedTo(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function
        '***************************************************
        'Get WC Locations
        '***************************************************
        Public Function GetWCLocations() As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "Select * from lwclocation where WC_LogicalLOC = 0 order by wc_location"

                dt = Me._objDataProc.GetDataTable(strSQL)
                InsertEmptyRow(dt, , "WCLocation_ID", "WC_Location", , , "-- ALL --")

                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetWCLocations(): " & Environment.NewLine & ex.Message.ToString)
            End Try

        End Function

        '***************************************************
        'GetPrevDBR
        '***************************************************
        Public Function GetPrevDBR(ByVal iDevice_ID As Integer) As Integer
            Dim strSQL As String
            Dim R1 As DataRow

            Try
                strSQL = "Select tdevicecodes.* " & _
                        "from tdevicecodes inner join lcodesdetail on tdevicecodes.dcode_id = lcodesdetail.dcode_id " & _
                        "where lcodesdetail.mcode_id = 21 and tdevicecodes.device_id = " & iDevice_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(R1) Then
                    Return R1("Dcode_ID")
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        'Deletes the DBR Code
        '***************************************************
        Public Function DeleteDBRCode(ByVal iDevice_ID As Integer, _
                                      ByVal iDCode_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "Delete from tdevicecodes " & Environment.NewLine
                strSQL &= "where Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                strSQL &= "AND Dcode_ID = " & iDCode_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***************************************************
        'Updates the database with the new DBR code
        '***************************************************
        Public Function UPD(ByVal idevice_id As Integer, ByVal iDcode_id As Integer) As Integer
            Dim strSQL As String
            Dim R1 As DataRow

            Try
                'Check if the Code already exists
                strSQL = "Select Count(*) as iCount " & _
                        "from tdevicecodes inner join lcodesdetail on tdevicecodes.dcode_id = lcodesdetail.dcode_id " & _
                        "where lcodesdetail.mcode_id = 21 and tdevicecodes.device_id = " & idevice_id.ToString

                R1 = Me._objDataProc.GetDataRow(strSQL)

                If R1("iCount") = 0 Then
                    strSQL = "Insert into tdevicecodes (Device_ID, Dcode_ID) " & _
                            "Values (" & idevice_id.ToString & ", " & iDcode_id.ToString & ")"
                Else
                    strSQL = "update tdevicecodes Set Dcode_ID = " & iDcode_id.ToString & _
                            " where Device_ID = " & idevice_id.ToString
                End If

                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '***************************************************
        'Get DBR Codes
        '***************************************************
        Public Function GetDBRCodes(Optional ByVal bIsAMS As Boolean = False) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                If bIsAMS Then
                    strSQL = "Select Dcode_ID, Dcode_LDesc, Conv_ID, Concat(Conv_ID, ' - ', Dcode_LDesc) as DispalyDesc from lcodesdetail where MCode_ID = 21 and Dcode_ID not in (3854,1386) and Dcode_Inactive = 0 order by Dcode_ID"
                Else
                    strSQL = "Select Dcode_ID, Dcode_LDesc, Conv_ID, Concat(Conv_ID, ' - ', Dcode_LDesc) as DispalyDesc from lcodesdetail where MCode_ID = 21 and Dcode_Inactive = 0 order by Dcode_ID"
                End If
                ' strSQL = "Select Dcode_ID, Dcode_LDesc, Conv_ID, Concat(Conv_ID, ' - ', Dcode_LDesc) as DispalyDesc from lcodesdetail where MCode_ID = 21 and Dcode_Inactive = 0 order by Dcode_ID"
                dt = Me._objDataProc.GetDataTable(strSQL)
                InsertEmptyRow(dt, , "Dcode_ID", "Dcode_LDesc")

                Return dt
            Catch ex As Exception
                DisposeDT(dt)
                Throw New Exception("Buisness.Misc.GetDBRCodes(): " & Environment.NewLine & ex.Message.ToString)
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

                dt.Rows.Add(R1)
            Catch ex As Exception
                Throw New Exception("Buisness.Misc.InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function
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
            ObjLib = New MyLib.Utility()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub
        '***************************************************
        Protected Overrides Sub Finalize()
            ObjLib = Nothing
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
        Public Function renderDisposition(ByVal lDeviceID As Long, ByVal iType As Integer) As String
            Dim lWO, lSKU, lOrigSKU As Long
            Dim strSKU, strSQL As String
            Dim drCount, drNumber, drWO, drSKU, drSKUID As DataRow

            '//See if record exists in tdisposition
            strSQL = "SELECT * FROM tdisposition WHERE Device_ID = " & lDeviceID.ToString

            drCount = Me._objDataProc.GetDataRow(strSQL)

            If Not IsNothing(drCount) Then
                '//Get SKU Number
                strSQL = "SELECT * FROM tsku WHERE Sku_ID = " & drCount("Disp_New")
                drNumber = Me._objDataProc.GetDataRow(strSQL)
                If Not IsNothing(drNumber) Then _Disposition = drNumber("Sku_Number")

                Return ""
            End If

            If iType = 1 Then Return "" ' This is for DBR/RUR Devices

            '//Get WO_ID
            Try
                strSQL = "SELECT * FROM tdevice WHERE Device_ID = " & lDeviceID.ToString
                drWO = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(drWO) Then
                    lOrigSKU = drWO("Sku_ID")
                    lWO = drWO("WO_ID")
                End If

                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
            End Try

            '//Get default SKU value from tpreloadwodata
            Try
                strSQL = "SELECT * FROM tpreloadwodata WHERE WO_ID = " & lWO.ToString
                drSKU = Me._objDataProc.GetDataRow(strSQL)
                If Not IsNothing(drSKU) Then strSKU = drSKU("plwodata_DefaultSKU")
            Catch ex As Exception
                MsgBox("No SKU has been defined for this device and no default can be determined. Please use the disposition screen to assign the correct sku to this device.", MsgBoxStyle.Critical, "ERROR")
                _Disposition = ""

                Return ""
            End Try

            System.Windows.Forms.Application.DoEvents()

            '//Determine the correct SKU_ID for this default SKU
            Try
                strSQL = "SELECT * FROM tsku WHERE Sku_Number = '" & strSKU & "'"
                drSKUID = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(drSKUID) Then lSKU = drSKUID("Sku_ID")
            Catch ex As Exception
                MsgBox(ex.tostring)
                MsgBox("No SKU ID can be determined. Please use the disposition screen to assign the correct sku to this device.", MsgBoxStyle.Critical, "ERROR")
                _Disposition = ""

                Return ""
            End Try

            System.Windows.Forms.Application.DoEvents()

            If lSKU > 0 And lDeviceID > 0 Then
                '//Update record in tdevice and insert record into tdisposition
                strSQL = "INSERT INTO tdisposition (Disp_Date, Disp_Old, Disp_New, Device_ID) VALUES ('" & FormatDate(Now) & "', " & lOrigSKU.ToString & ", " & lSKU.ToString & ", " & lDeviceID.ToString & ")"
                Me._objDataProc.ExecuteNonQuery(strSQL)
                System.Windows.Forms.Application.DoEvents()
                strSQL = "UPDATE tdevice SET Sku_ID = " & lSKU.ToString & " WHERE Device_ID = " & lDeviceID.ToString
                Me._objDataProc.ExecuteNonQuery(strSQL)
                System.Windows.Forms.Application.DoEvents()
                _Disposition = ""

                Return lSKU
            End If

        End Function

        Public Function FormatDate(ByVal datStart As Date) As String
            Dim strMonth, strDay, strYear, strHour, strMinute, strSecond As String

            strYear = DatePart(DateInterval.Year, datStart).ToString
            strMonth = String.Format("{0:D2}", DatePart(DateInterval.Month, datStart))
            strDay = String.Format("{0:D2}", DatePart(DateInterval.Day, datStart))
            strHour = DatePart(DateInterval.Hour, datStart).ToString
            strMinute = DatePart(DateInterval.Minute, datStart).ToString
            strSecond = DatePart(DateInterval.Second, datStart).ToString

            Return strYear & "-" & strMonth & "-" & strDay & " " & strHour & ":" & strMinute & ":" & strSecond
        End Function

        '******************************* LAN **********************************
        'get total device in shipping pallet
        'using in: frmRemoveDevicesFromPallet
        '**********************************************************************
        Public Function GetPalletCount(ByVal ipalletID As Integer) As Integer
            Dim dr As DataRow
            Dim strMyQuery As String = ""

            Try
                strMyQuery = "select count(*) " & Environment.NewLine
                strMyQuery &= "from tdevice " & Environment.NewLine
                strMyQuery &= "where tdevice.Pallett_ID = " & ipalletID.ToString & Environment.NewLine

                dr = Me._objDataProc.GetDataRow(strMyQuery)

                If Not IsNothing(dr) Then
                    Return dr(0)
                Else
                    Throw New Exception("Pallet is empty.")
                End If

            Catch ex As Exception
                Throw New Exception("Business.Misc.GetDevicesCount" & ex.ToString)
            End Try
        End Function

        '******************************* LAN **********************************
        'get shipping pallet ID
        'using in: frmRemoveDevicesFromPallet
        '**********************************************************************
        Public Function GetPalletID(ByVal strPalletName As String, _
                                    Optional ByVal iCondition As Integer = 0) As Integer
            Dim R1 As DataRow
            Dim strSql As String = ""

            Try
                If iCondition = 1 Then
                    strSql = "select Pallett_ID from tpallett where Pallett_Name = '" & strPalletName & "'"
                Else
                    strSql = "select Pallett_ID from tpallett where Pallett_Name = '" _
                               & strPalletName & "' and Pallett_ReadyToShipFlg = 1 " _
                               & "and Pallett_ShipDate is null order by pallett_ID desc"
                End If

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    Return R1("Pallett_ID")
                Else
                    Return 0  'check frmRemoveFromPallet
                    'Throw New Exception("Pallet name is not determined. Pallet was never closed or Pallet has been shipped")
                End If

            Catch ex As Exception
                Throw New Exception("Product.Business.GetPalletID. " & ex.ToString)
            End Try
        End Function

        '***************************** LAN *********************************
        Public Function GetWIPOwner(ByVal iPalletID As Integer, _
                                    ByVal strWO_IDs As String, _
                                    ByVal iPallet_IDFlag As Integer, _
                                    ByVal iTakeOwnershipfor As Integer, _
                                    ByVal strDeviceSN As String) As Integer
            Dim str1 As String = ""
            Dim dt1 As DataTable

            If iPallet_IDFlag = 1 Then      'tpallet
                str1 = "select distinct Cellopt_WIPOwner from tcellopt inner join tdevice on " & _
                                      "tcellopt.Device_ID = tdevice.Device_ID " & _
                                      " where tdevice.Pallett_ID = " & iPalletID.ToString
            Else                            'tworkorder
                str1 = "select distinct Cellopt_WIPOwner from tcellopt inner join tdevice on " & _
                            "tcellopt.Device_ID = tdevice.Device_ID " & _
                            " where tdevice.WO_ID in " & strWO_IDs
            End If

            If iTakeOwnershipfor = 2 Then
                str1 &= " and tdevice.Device_SN in " & strDeviceSN
            End If

            str1 &= ";"

            Try
                dt1 = Me._objDataProc.GetDataTable(str1)

                If dt1.Rows.Count = 1 Then
                    Return dt1.Rows(0)("Cellopt_WIPOwner")
                ElseIf dt1.Rows.Count > 1 Then
                    Return -1
                ElseIf dt1.Rows.Count = 0 Then
                    Return 0
                End If
            Catch ex As Exception
                Throw New Exception("Business.Misc.GetWIPOwner." & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '************************** LAN ***************************************
        'using in: frmTakeWIPOwnership (new), frmRemoveFromPallet
        '**********************************************************************
        Public Function GetGroupDesc(ByVal iGroup_ID As Integer) As String
            Dim strSQL As String
            Dim dr As DataRow

            Try
                strSQL = "select lgroups.Group_Desc " & _
                                "from lgroups " & _
                                "where lgroups.Group_ID = " & iGroup_ID.ToString
                dr = Me._objDataProc.GetDataRow(strSQL)

                If Not IsNothing(dr) Then
                    Return Trim(dr("Group_Desc"))
                Else
                    Throw New Exception("Group ID does not exist.")
                End If
            Catch ex As Exception
                Throw New Exception("Product.Business.Misc.GetGroupDesc." & ex.ToString)
            Finally
                dr = Nothing
            End Try
        End Function

        '************************** LAN ***************************************
        'using in: frmReadyToTransfer, frmTakeOwnership
        '**********************************************************************
        Public Sub GetWHPalletIDNameCount(ByVal strIMEI As String, _
                                          ByRef iWHPalletID As Integer, _
                                          ByRef strPalletName As String, _
                                          ByRef iReady As Integer, _
                                          ByRef iHold As Integer)
            Dim R1, R2 As DataRow
            Dim strQuery As String = ""

            Try
                strQuery = "select twarehousepallet.WHPallet_ID, twarehousepallet.WHPallet_Number " & Environment.NewLine
                strQuery &= "from twarehousepallet, twarehousereceive " & Environment.NewLine
                strQuery &= "where twarehousepallet.WHPallet_ID = twarehousereceive.WHPallet_ID " & Environment.NewLine
                strQuery &= "and twarehousereceive.WHR_Box_SN = '" & strIMEI & "' " & Environment.NewLine
                strQuery &= "and twarehousereceive.WHR_Result = 0 " & Environment.NewLine
                strQuery &= "order by twarehousereceive.WHR_ID desc"

                R1 = Me._objDataProc.GetDataRow(strQuery)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("WHPallet_ID")) Then
                        iWHPalletID = R1("WHPallet_ID")

                        'Get total (ready to transer) device in pallet
                        '--------------------------
                        strQuery = "select count(*) AS Cnt " & Environment.NewLine
                        strQuery &= "from twarehousereceive " & Environment.NewLine
                        strQuery &= "where twarehousereceive.WHR_Result = 0 and " & Environment.NewLine
                        strQuery &= "(twarehousereceive.WHR_ReadyForTransfer = 1 or twarehousereceive.WHR_ReadyForTransfer = 2) " & Environment.NewLine
                        strQuery &= "and twarehousereceive.WHPallet_ID = " & iWHPalletID.ToString

                        R2 = Me._objDataProc.GetDataRow(strQuery)

                        If Not IsNothing(R2) Then
                            If Not IsDBNull(R2("Cnt")) Then iReady = R2("Cnt")
                        End If
                        '---------------------------

                        'Get total (on hold) device in pallet
                        '--------------------------
                        strQuery = ""
                        strQuery = "select count(*) AS Cnt " & Environment.NewLine
                        strQuery &= "from twarehousereceive " & Environment.NewLine
                        strQuery &= "where twarehousereceive.WHR_Result = 0 and " & Environment.NewLine
                        strQuery &= "twarehousereceive.WHR_ReadyForTransfer = 0 " & Environment.NewLine
                        strQuery &= "and twarehousereceive.WHPallet_ID = " & iWHPalletID

                        R2 = Me._objDataProc.GetDataRow(strQuery)

                        If Not IsNothing(R2) Then
                            If Not IsDBNull(R2("Cnt")) Then iHold = R2("Cnt")
                        End If
                        '---------------------------

                    End If

                    If Not IsDBNull(R1("WHPallet_Number")) Then strPalletName = R1("WHPallet_Number")
                Else
                    Throw New Exception("Device does not exist; already transferred.")
                End If

            Catch ex As Exception
                Throw New Exception("Product.Business.Misc.GetWHPalletIDNameCount: " & ex.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
            End Try
        End Sub
        '************************** LAN ***************************************
        'Checks if IMEI belongs to a warehouse pallet
        'frmReadyToTransfer(PUT DEVICE ON-HOLD), frmTakeOwnership
        '**********************************************************************
        Public Function CheckIMEIBelongsToPallet(ByVal iWHPalletID As Integer, _
                                                ByVal strIMEI As String) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '?????????????? check for WHR_Result
                strSql = "Select Count(*) as cnt " & Environment.NewLine
                strSql &= "from twarehousereceive " & Environment.NewLine
                strSql &= "where whpallet_id = " & iWHPalletID.ToString & " " & Environment.NewLine
                strSql &= "and WHR_Result = 0 " & Environment.NewLine
                strSql &= "and WHR_ReadyForTransfer = 1 " & Environment.NewLine
                strSql &= "and WHR_Box_SN = '" & strIMEI

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If R1("cnt") = 0 Then
                        Throw New Exception("IMEI does not belong to Pallet or device is a discrepency or device status is not 'REALDY TO TRANSFER'.")
                    Else
                        Return R1("cnt")
                    End If
                Else
                    Throw New Exception("Product.Business.Misc.CheckIMEIBelongsToPallet: Error obtaining SQL result.")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '************************** LAN ***************************************
        'using in: frmTakeWIPOwnership
        '**********************************************************************
        Public Function GetRcvdPalletCount(ByVal strRcvdPalletName As String) As Integer
            Dim R1 As DataRow

            Try
                strSql = "Select Count(*) as cnt " & Environment.NewLine
                strSql &= "from twarehousepallet " & Environment.NewLine
                strSql &= "inner join twarehousereceive " & Environment.NewLine
                strSql &= "on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strSql &= "where twarehousepallet.WHPallet_Number = '" & strRcvdPalletName & "' " & Environment.NewLine
                strSql &= "and twarehousereceive.WHR_Result = 0"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If R1("cnt") = 0 Then
                        R1 = Nothing

                        strSql = "Select Count(*) as cnt " & Environment.NewLine
                        strSql &= "from tdevice " & Environment.NewLine
                        strSql &= "inner join tpallett " & Environment.NewLine
                        strSql &= "on tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                        strSql &= "where tpallett.Pallett_Name = '" & strRcvdPalletName

                        R1 = Me._objDataProc.GetDataRow(strSql)

                        If Not IsNothing(R1) Then
                            If R1("cnt") = 0 Then
                                Throw New Exception("Pallet Name does not exist.")
                            Else
                                Return R1("cnt")
                            End If
                        Else
                            Throw New Exception("Misc.GetRcvdPalletCount(): Error obtaining data row (2).")
                        End If
                    Else
                        Return R1("cnt")
                    End If
                Else
                    Throw New Exception("Misc.GetRcvdPalletCount(): Error obtaining data row (1).")
                End If
            Catch ex As Exception
                Throw New Exception("Misc.GetRcvdPalletCount():" & ex.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function

        '**********************************************************************
        Public Function GetPalletInfo_ByPallettName(ByVal str_pallettName As String, Optional ByVal iCust_ID As Integer = 0) As DataTable
            Dim dt, dt2 As DataTable
            Dim row As DataRow

            Try
                str_pallettName = str_pallettName.Replace("'", "''")
                strSql = "SELECT A.*,'' AS Baud,0 AS Baud_ID " & Environment.NewLine
                strSql &= " FROM tpallett A " & Environment.NewLine
                strSql &= " WHERE Pallett_Name = '" & str_pallettName & "'"
                If iCust_ID > 0 Then
                    strSql &= " AND cust_ID =" & iCust_ID
                End If
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows 'should be 1 row if any
                    strSql = "SELECT A.Baud_ID,B.Baud_Number as 'Baud' FROM tamsforecastedship_special A" & Environment.NewLine
                    strSql &= " Inner Join lbaud B ON A.Baud_ID=B.Baud_ID" & Environment.NewLine
                    strSql &= " where pallett_ID=" & row("Pallett_ID") & ";" & Environment.NewLine
                    dt2 = Me._objDataProc.GetDataTable(strSql)
                    If dt2.Rows.Count > 0 Then
                        row.BeginEdit() : row("Baud_ID") = dt2.Rows(0).Item("Baud_ID") : row("Baud") = dt2.Rows(0).Item("Baud") : row.AcceptChanges()
                    End If
                Next
                Return dt
            Catch ex As Exception
                Throw New Exception("Misc.GetPalletInfo_ByPallettName():" & ex.ToString)
            End Try
        End Function

        '************************** LAN ***************************************
        'using in: frmAssignWIPOwnership
        '**********************************************************************
        Public Function GetPalletInfoBySN(ByVal strIMEISN As String, _
                                        ByVal iNewGroupID As Integer, _
                                        ByVal strNewOwner As String, _
                                        ByRef iPallet_ID As Integer, _
                                        ByRef strShipPalletName As String, _
                                        ByRef iShipPalletCount As Integer, _
                                        ByRef iWO_ID As Integer, _
                                        ByRef iCurrentOwner As Integer, _
                                        ByRef strCurrentOwner As String, _
                                        ByRef iAssignedGroup_ID As Integer, _
                                        ByRef strAssignedOwner As String, _
                                        ByRef iWHPalletID As Integer, _
                                        ByRef strRcvdPalletName As String, _
                                        ByRef iRcvdPalletCount As Integer, _
                                        ByRef itransferredCount As Integer, _
                                        ByRef iReadyToTransferCount As Integer, _
                                        ByRef iHoldCount As Integer, _
                                        ByRef iDeviceStatus As Integer) As Boolean
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iDeviceID As Integer = 0

            Try
                '--------------------------------------------------
                'step 1:Get Device_ID, WO_ID, PalletID from tdevice
                '--------------------------------------------------
                strSql = "select tdevice.Device_ID, tdevice.Pallett_ID, tdevice.WO_ID "
                strSql &= "from tdevice " & Environment.NewLine
                strSql &= "where tdevice.Device_SN = '" & strIMEISN & "' " & Environment.NewLine
                strSql &= "and tdevice.Device_DateShip is null " & Environment.NewLine
                strSql &= "order by tdevice.Device_ID desc"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("Device_ID")) Then iDeviceID = R1("Device_ID")
                    If Not IsDBNull(R1("Pallett_ID")) Then iPallet_ID = R1("Pallett_ID")
                    If Not IsDBNull(R1("WO_ID")) Then iWO_ID = R1("WO_ID")
                Else
                    MsgBox("Device does not exist in WIP.", MsgBoxStyle.OKOnly, "WIP Ownership")

                    Return False
                End If

                R1 = Nothing

                '--------------------------------------------------
                'step 2:Get CurrentWipOwner and currentWipOwnerDes
                '--------------------------------------------------
                strSql = "select tcellopt.Cellopt_WIPOwner, lgroups.Group_Desc " & Environment.NewLine
                strSql &= "from tcellopt " & Environment.NewLine
                strSql &= "inner join lgroups on tcellopt.Cellopt_WIPOwner = lgroups.Group_ID " & Environment.NewLine
                strSql &= "where tcellopt.Device_ID = " & iDeviceID.ToString

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("Cellopt_WIPOwner")) Then iCurrentOwner = R1("Cellopt_WIPOwner")
                    If Not IsDBNull(R1("Group_Desc")) Then strCurrentOwner = R1("Group_Desc")

                    'current owner same with new owner
                    If iCurrentOwner = iNewGroupID Then
                        MsgBox("Pallet already belongs to " & strNewOwner & ".", MsgBoxStyle.OKOnly, "WIP Ownership")

                        Return False
                    End If
                End If

                R1 = Nothing

                '------------------------------------------------------------
                'step 3: Get RcvdPallet Name, original group_ID and group_Desc
                '------------------------------------------------------------
                strSql = "select tworkorder.WO_RecPalletName, tworkorder.Group_ID, lgroups.Group_Desc " & Environment.NewLine
                strSql &= "from tworkorder " & Environment.NewLine
                strSql &= "inner join lgroups on tworkorder.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strSql &= "where tworkorder.WO_ID = " & iWO_ID.ToString

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("WO_RecPalletName")) Then
                        strRcvdPalletName = R1("WO_RecPalletName")
                    Else
                        Throw New Exception("WO_RecPalletName is missing.")
                    End If

                    If Not IsDBNull(R1("Group_ID")) Then iAssignedGroup_ID = R1("Group_ID")
                    If Not IsDBNull(R1("Group_Desc")) Then strAssignedOwner = R1("Group_Desc")
                End If

                R1 = Nothing

                '------------------------------
                'step 4:Get Shipping palletName
                '------------------------------
                If iPallet_ID > 0 Then
                    strSql = "select tpallett.Pallett_Name  " & Environment.NewLine
                    strSql &= "from tpallett " & Environment.NewLine
                    strSql &= "where tpallett.Pallett_ID = " & iPallet_ID & " " & Environment.NewLine
                    strSql &= "and tpallett.Pallett_ReadyToShipFlg = 1 " & Environment.NewLine
                    strSql &= "and tpallett.Pallett_ShipDate is null"

                    R1 = Me._objDataProc.GetDataRow(strSql)

                    If Not IsNothing(R1) Then
                        If Not IsDBNull(R1("Pallett_Name")) Then strShipPalletName = R1("Pallett_Name")
                    End If

                    R1 = Nothing

                    '------------------------------------------
                    'step 4.1:Get ShipPalletCount from tdevice
                    '------------------------------------------
                    strSql = "select count(*) as cnt " & Environment.NewLine
                    strSql &= "from tdevice" & Environment.NewLine
                    strSql &= "where tdevice.Pallett_ID = " & iPallet_ID

                    R1 = Me._objDataProc.GetDataRow(strSql)

                    If Not IsNothing(R1) Then
                        If Not IsDBNull(R1("cnt")) Then iShipPalletCount = R1("cnt")
                    End If
                End If

                R1 = Nothing

                '--------------------------------------------
                'step 5:Get WHPallet_ID, WHR_ReadyForTransfer
                '--------------------------------------------
                strSql = "select twarehousepallet.WHPallet_ID, twarehousereceive.WHR_ReadyForTransfer " & Environment.NewLine
                strSql &= "from twarehousepallet " & Environment.NewLine
                strSql &= "inner join twarehousereceive  " & Environment.NewLine
                strSql &= "on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strSql &= "where twarehousepallet.WHPallet_Number = '" & strRcvdPalletName & "' " & Environment.NewLine
                strSql &= "and twarehousereceive.WHR_Box_SN = '" & strIMEISN & "'"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("WHPallet_ID")) Then iWHPalletID = R1("WHPallet_ID")
                    If Not IsDBNull(R1("WHR_ReadyForTransfer")) Then iDeviceStatus = R1("WHR_ReadyForTransfer")
                End If

                R1 = Nothing

                '************************************
                'Get Devices from twarehousereceive for whpallet_id
                strSql = "Select WHR_ReadyForTransfer, Count(*) as cnt " & Environment.NewLine
                strSql &= "from twarehousereceive " & Environment.NewLine
                strSql &= "where WHR_Result = 0 " & Environment.NewLine
                strSql &= "and whpallet_id = " & iWHPalletID.ToString & " " & Environment.NewLine
                strSql &= "group by WHR_ReadyForTransfer"

                dt = Me._objDataProc.GetDataTable(strSql)
                iRcvdPalletCount = 0

                For Each R1 In dt.Rows
                    If R1("WHR_ReadyForTransfer") = 0 Then      'on hold
                        iHoldCount = R1("cnt")
                        iRcvdPalletCount += R1("cnt")
                    ElseIf R1("WHR_ReadyForTransfer") = 1 Then  'ready to transfer
                        iReadyToTransferCount = R1("cnt")
                        iRcvdPalletCount += R1("cnt")
                    ElseIf R1("WHR_ReadyForTransfer") = 2 Then  'Transferred
                        itransferredCount = R1("cnt")
                        iRcvdPalletCount += R1("cnt")
                    End If
                Next R1

                Return True

            Catch ex As Exception
                Throw New Exception("Production.Business.Misc.GetPalletInfoBySN:" & ex.ToString)

                Return False
            Finally
                R1 = Nothing

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try

        End Function

        '************************** LAN ***************************************
        'Check device belongs to pallet
        'call from: frmAssignWIPOwnership
        '**********************************************************************
        Public Function CheckDeviceBelongToPallet(ByVal strIMEI As String, _
                                                ByVal iWHPallet_ID As Integer) As Integer
            Dim iCount As Integer = 0
            Dim R1 As DataRow

            Try
                strSql = "Select count(*) as Cnt " & Environment.NewLine
                strSql &= "from twarehousereceive " & Environment.NewLine
                strSql &= "where WHR_ReadyForTransfer = 0 " & Environment.NewLine
                strSql &= "and WHR_Result = 0 " & Environment.NewLine
                strSql &= "and whpallet_id = " & iWHPallet_ID.ToString & " " & Environment.NewLine
                strSql &= "and WHR_Box_SN = '" & strIMEI & "'"

                R1 = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(R1) Then
                    If Not IsDBNull(R1("Cnt")) Then iCount = R1("Cnt")
                End If

                Return iCount
            Catch ex As Exception
                Throw New Exception("Production.Business.Misc.CheckDeviceBelongToPallet: " & ex.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function

        '************************** LAN ***************************************
        'Assign ownership of full pallet
        'call from: frmAssignOwnership
        '**********************************************************************
        Public Function AssignOwnershipOfFull(ByVal iWO_or_PalletID_Flag As Integer, _
                                              ByVal iCurrentOwner As Integer, _
                                              ByVal iNewGroup_ID As Integer, _
                                              ByVal iPallet_ID As Integer, _
                                              ByVal iWHPalletID As Integer, _
                                              ByVal strRecPalletName As String) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strWO_IDs As String = ""
            Dim j As Integer
            Dim i As Integer = 0
            Dim strCurrentDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Try

                'Step 1: Update ready to transfer flag and WIPOwner in twarehousereceive
                If (iCurrentOwner = 5 Or iCurrentOwner = 2 Or iCurrentOwner = 3) And iWO_or_PalletID_Flag = 1 Then       '5 - Triage
                    If iCurrentOwner = 2 Or iCurrentOwner = 3 Then
                        strSql = "Update twarehousereceive set WHR_ReadyForTransfer = 2, twarehousereceive.WHR_WIPOwner = " & iNewGroup_ID.ToString & ", twarehousereceive.WHR_TransferDt = '" & Me.WorkDt & "' where WHR_ReadyForTransfer = 2 and WHR_Result = 0 and WHPallet_ID = " & iWHPalletID.ToString
                    Else
                        strSql = "Update twarehousereceive set WHR_ReadyForTransfer = 2, twarehousereceive.WHR_WIPOwner = " & iNewGroup_ID.ToString & ", twarehousereceive.WHR_TransferDt = '" & Me.WorkDt & "' where WHR_ReadyForTransfer = 1 and WHR_Result = 0 and WHPallet_ID = " & iWHPalletID.ToString
                    End If

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "update tworkorder set group_id = " & iNewGroup_ID.ToString & " where WO_RecPalletName = '" & Trim(strRecPalletName) & "'"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                'Step 2:update Tcellopt_WIPOwner
                '--------------------------
                'get WO_ID
                strSql = "select tworkorder.WO_ID " & Environment.NewLine
                strSql &= "from tworkorder " & Environment.NewLine
                strSql &= "where tworkorder.WO_RecPalletName = '" & strRecPalletName & "'"

                dt1 = Me._objDataProc.GetDataTable(strSql)

                If Not IsNothing(dt1) Then
                    If dt1.Rows.Count > 0 Then
                        strWO_IDs = "("

                        For j = 0 To dt1.Rows.Count - 1
                            If j <> dt1.Rows.Count - 1 Then
                                strWO_IDs &= dt1.Rows(j)("WO_ID") & ", "
                            Else
                                strWO_IDs &= dt1.Rows(j)("WO_ID") & ")"
                            End If
                        Next j
                    End If
                End If

                'reset dt1
                R1 = Nothing

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                'get a set of Device ID
                If iWO_or_PalletID_Flag = 1 Then
                    strSql = "select tdevice.Device_ID " & Environment.NewLine
                    strSql &= "from tdevice, twarehousereceive " & Environment.NewLine
                    strSql &= "where tdevice.WO_ID in " & strWO_IDs & " " & Environment.NewLine
                    strSql &= "and tdevice.Device_SN = twarehousereceive.WHR_Box_SN " & Environment.NewLine
                    strSql &= "and twarehousereceive.WHPallet_ID = " & iWHPalletID.ToString & " " & Environment.NewLine
                    strSql &= "and twarehousereceive.WHR_ReadyForTransfer = 2"

                ElseIf iWO_or_PalletID_Flag = 2 Then
                    strSql = "select tdevice.Device_ID " & Environment.NewLine
                    strSql &= "from tdevice " & Environment.NewLine
                    strSql &= "where tdevice.Pallett_ID = " & iPallet_ID.ToString
                End If

                dt1 = Me._objDataProc.GetDataTable(strSql)

                'update tcellopt_WIPOwner
                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        strSql = "update tcellopt " & Environment.NewLine
                        strSql &= "set " & Environment.NewLine
                        strSql &= "tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner, " & Environment.NewLine
                        strSql &= "tcellopt.Cellopt_WIPEntryDt = now(), " & Environment.NewLine
                        strSql &= "tcellopt.Cellopt_WIPOwner = " & iNewGroup_ID.ToString & " " & Environment.NewLine
                        strSql &= "where tcellopt.Device_ID = " & R1("Device_ID")

                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                    Next R1
                End If
                '--------------------------

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                strSql = ""
                R1 = Nothing

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Function

        '************************** LAN ***************************************
        'Assign ownership of on-hold Device
        'call from: frmAssignOwnership
        'Triage ----> Production only
        '**********************************************************************
        Public Function AssignOwnershipOf_OnHoldDev(ByVal iWO_or_PalletID_Flag As Integer, _
                                                    ByVal lstIMEIs As System.Windows.Forms.ListBox, _
                                                    ByVal iCurrentOwner As Integer, _
                                                    ByVal strCurOwner As String, _
                                                    ByVal iNewGroup_ID As Integer, _
                                                    ByVal strNewOwner As String, _
                                                    ByVal iWHPalletID As Integer, _
                                                    ByVal strRecPalletName As String) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strWO_IDs As String = ""
            Dim i, j As Integer
            Dim strCurrentDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim strIMEIs As String = "('"

            Try
                'Step1: build IMEIs string 
                If iCurrentOwner = 5 And (iNewGroup_ID = 2 Or iNewGroup_ID = 3) Then
                    For i = 0 To lstIMEIs.Items.Count - 1
                        If i < lstIMEIs.Items.Count - 1 Then
                            strIMEIs &= lstIMEIs.Items.Item(i) & "', '"
                        Else
                            strIMEIs &= lstIMEIs.Items.Item(i)
                        End If

                    Next i
                    strIMEIs &= "')"

                    'Step 2: Update ready to transfer flag in twarehousereceive
                    strSql = "Update twarehousereceive " & Environment.NewLine
                    strSql &= "set WHR_ReadyForTransfer = 2, " & Environment.NewLine
                    strSql &= "twarehousereceive.WHR_WIPOwner = " & iNewGroup_ID.ToString & ", " & Environment.NewLine
                    strSql &= "twarehousereceive.WHR_TransferDt = '" & Me.WorkDt & "' " & Environment.NewLine
                    strSql &= "where WHR_ReadyForTransfer = 0 " & Environment.NewLine
                    strSql &= "and WHR_Result = 0 " & Environment.NewLine
                    strSql &= "and WHPallet_ID = " & iWHPalletID.ToString & " " & Environment.NewLine
                    strSql &= "and WHR_Dev_SN in " & strIMEIs

                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    'Step 3:get WO_ID
                    strSql = "select tworkorder.WO_ID " & Environment.NewLine
                    strSql &= "from tworkorder " & Environment.NewLine
                    strSql &= "where tworkorder.WO_RecPalletName = '" & strRecPalletName & "'"

                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    If dt1.Rows.Count > 0 Then
                        strWO_IDs = "("

                        For j = 0 To dt1.Rows.Count - 1
                            If j <> dt1.Rows.Count - 1 Then
                                strWO_IDs &= dt1.Rows(j)("WO_ID") & ", "
                            Else
                                strWO_IDs &= dt1.Rows(j)("WO_ID") & ")"
                            End If
                        Next j
                    End If

                    'reset dt1
                    R1 = Nothing

                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    'Step4: get a set of Device ID
                    strSql = "select tdevice.Device_ID " & Environment.NewLine
                    strSql &= "from tdevice " & Environment.NewLine
                    strSql &= "where tdevice.Device_SN in " & strIMEIs & " " & Environment.NewLine
                    strSql &= "and tdevice.WO_ID in " & strWO_IDs

                    dt1 = Me._objDataProc.GetDataTable(strSql)

                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            'update wip owner flag in tcellopt
                            strSql = "update tcellopt " & Environment.NewLine
                            strSql &= "set " & Environment.NewLine
                            strSql &= "tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner, " & Environment.NewLine
                            strSql &= "tcellopt.Cellopt_WIPEntryDt = now(), " & Environment.NewLine
                            strSql &= "tcellopt.Cellopt_WIPOwner = " & iNewGroup_ID & " " & Environment.NewLine
                            strSql &= "where tcellopt.Device_ID = " & R1("Device_ID")

                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        Next R1
                    End If

                    Return 1
                Else
                    Throw New Exception(strCurOwner & " can not transfer partial pallets to " & strNewOwner & ".")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************** LAN ***************************************
        '11/09/2006
        Public Function UpdtWipOwner(ByVal iDevice_id As Integer, _
                                    Optional ByVal iNewOwner As Integer = 0) As Integer
            Dim i As Integer = 0
            Dim strSql As String = ""

            Try
                strSql = "update tcellopt " & Environment.NewLine
                strSql &= "inner join tdevice on tcellopt.device_id = tdevice.device_id " & Environment.NewLine
                strSql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine

                If iNewOwner = 0 Then
                    strSql &= "set tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner, tcellopt.Cellopt_WIPOwner = tworkorder.Group_ID, tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                Else
                    strSql &= "set tcellopt.Cellopt_WIPOwnerOld = tcellopt.Cellopt_WIPOwner, tcellopt.Cellopt_WIPOwner = " & iNewOwner.ToString & ", tcellopt.Cellopt_WIPEntryDt = now() " & Environment.NewLine
                End If

                strSql &= "where tcellopt.device_id = " & iDevice_id.ToString

                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************** LAN ***************************************
        '11/09/2006 Waiting for part
        Public Function DevNoTechAssign(ByVal iDev_id As Integer) As Boolean
            Dim dr As DataRow
            Dim strSql As String = ""
            Dim iRet As Boolean = False

            Try
                strSql = "select count(*) as cnt " & Environment.NewLine
                strSql &= "from tdevicebill, tcellopt " & Environment.NewLine
                strSql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "where tdevicebill.Device_ID = " & iDev_id & " " & Environment.NewLine
                strSql &= "and tdevicebill.device_id = tcellopt.device_id " & Environment.NewLine
                strSql &= "and tcellopt.CellOpt_TechAssigned is not null " & Environment.NewLine
                strSql &= "and lbillcodes.BillType_ID = 2"

                dr = Me._objDataProc.GetDataRow(strSql)

                If Not IsNothing(dr) Then
                    If dr("cnt") = 0 Then iRet = True
                End If

                Return iRet
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing
            End Try
        End Function

        '**********************************************************************
        'Get Lot number of SN; add by Lan 11/14/2006; only use for GS customer
        '**********************************************************************
        Public Function GetDevLotNo(ByVal strSN As String) As String
            Dim strsql As String = ""
            Dim R1, R2 As DataRow
            Dim strLot As String = ""

            Try
                'Step1: Get Received pallet
                strsql = "select tdevice.device_sn, tworkorder.WO_RecPalletName, cust_id " & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id" & Environment.NewLine
                strsql &= "where device_sn = '" & Trim(strSN) & "' " & Environment.NewLine
                strsql &= " and (device_dateship is null or device_dateship = '0000:00:00 00:00' or device_dateship = '');"

                R1 = Me._objDataProc.GetDataRow(strsql)

                If Not IsNothing(R1) Then
                    'Step2: Get device lot number
                    strsql = "select twarehousepallet.WHP_Lot, twarehousepallet.Model_ID " & Environment.NewLine
                    strsql &= "from twarehousereceive " & Environment.NewLine
                    strsql &= "inner join twarehousepallet on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                    strsql &= "where twarehousereceive.WHR_Dev_SN ='" & Trim(strSN) & "' and " & Environment.NewLine
                    strsql &= "twarehousepallet.WHPallet_Number = '" & R1("WO_RecPalletName") & "' and Cust_ID = " & R1("cust_id")

                    R2 = Me._objDataProc.GetDataRow(strsql)

                    If Not IsNothing(R2) Then
                        If Not IsDBNull(R2("WHP_Lot")) Then strLot = UCase(Trim(R2("WHP_Lot")))
                    Else
                        Throw New Exception("Device's SN does not exist in twarehousereceive or device was not received to the line.")
                    End If
                Else
                    Throw New Exception("Device's SN does not exist in tdevice or device already been ship.")
                End If

                Return strLot
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
            End Try
        End Function

        '*********************************************************************
        'Set DOBFlg to make pallet contain only DOB devices
        '*********************************************************************
        Public Function ValidatePalletAndDevice_Enterprise(ByVal iPallet_ID As Integer, _
                                                         ByVal strSN As String, _
                                                         ByVal iPalletQty As Integer, _
                                                         ByVal iCust_ID As Integer) As Integer
            Dim i As Integer = 0
            Dim strDevEnterprise As String = ""
            Dim booDOBFlg As Boolean = False
            Dim objBP As Brightpoint

            Try
                objBP = New Brightpoint()

                If iPalletQty = 0 Then
                    'Get device enterprise
                    strDevEnterprise = objBP.GetDeviceEnterpriseInWIP(strSN, iCust_ID)

                    'Set DOBFlg in tpallett to store DOB device only
                    If UCase(Trim(strDevEnterprise)) <> "DOB" And UCase(Trim(strDevEnterprise)) <> "DBR" Then
                        i = objBP.SetDOBFlag(iPallet_ID, 0)
                    ElseIf UCase(Trim(strDevEnterprise)) = "DOB" Or UCase(Trim(strDevEnterprise)) = "DBR" Then
                        i = objBP.SetDOBFlag(iPallet_ID, 1)
                    End If
                Else
                    'Get device enterprise
                    strDevEnterprise = objBP.GetDeviceEnterpriseInWIP(strSN, iCust_ID)

                    booDOBFlg = objBP.IsDOBPallet(iPallet_ID)

                    If (UCase(Trim(strDevEnterprise)) = "DOB" Or UCase(Trim(strDevEnterprise)) = "DBR") And booDOBFlg = False Then
                        Throw New Exception("Device's SN belongs to 'Dobson' but pallet ID does not belong to 'Dobson'. Cannot put this device on pallet.")
                    End If

                    If (UCase(Trim(strDevEnterprise)) <> "DOB" And UCase(Trim(strDevEnterprise)) <> "DBR") And booDOBFlg = True Then
                        Throw New Exception("Device's SN does not belong to 'Dobson' but pallet ID belongs to 'Dobson'. Cannot put this device on pallet.")
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objBP = Nothing
            End Try
        End Function

        Public Function TransactionID(ByVal SQL As String, ByVal strTable As String) As Int32
            Dim iTranID As Int32 = 0
            Dim dr As DataRow

            Try
                Me._objDataProc.ExecuteNonQuery(strSql)
                dr = Me._objDataProc.GetDataRow("SELECT LAST_INSERT_ID() AS TranID FROM " & strTable)

                If Not IsNothing(dr) Then
                    If Not IsDBNull(dr("TranID")) Then iTranID = dr("TranID")
                End If
            Catch exp As Exception
                'MsgBox(exp.ToString)
                Me._objDataProc.DisplayMessage(exp.Message)
            Finally
                dr = Nothing
            End Try

            Return iTranID
        End Function

        '*********************************************************************
        Public Function GetModelsByCustID(ByVal iCustID As Integer) As DataTable
            Dim dt As DataTable
            Try
                Me.strSql = "SELECT DISTINCT Model_ID, Model_Desc " & Environment.NewLine
                Me.strSql &= "FROM tmodel " & Environment.NewLine
                Me.strSql &= "INNER JOIN tcusttoprice on tmodel.Prod_ID = tcusttoprice.Prod_ID " & Environment.NewLine
                Me.strSql &= "WHERE cust_id = " & iCustID & Environment.NewLine
                Me.strSql &= "order by Model_Desc;"

                dt = Me._objDataProc.GetDataTable(strSql)
                InsertEmptyRow(dt, , "Model_id", "model_desc", , , "-- Select --")

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************
        Public Function GetDeviceIDs(ByVal iCustID As Integer, _
                                     ByVal iModelID As Integer, _
                                     ByVal booInWipDevice As Boolean, _
                                     ByVal strProdShipStartDate As String, _
                                     ByVal strProdShipEndDate As String) As DataTable
            Try
                Me.strSql = "SELECT DISTINCT Device_ID " & Environment.NewLine
                Me.strSql &= "FROM tdevice " & Environment.NewLine
                Me.strSql &= "INNER JOIN tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                Me.strSql &= "INNER JOIN tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                Me.strSql &= "WHERE Device_DateBill is not null " & Environment.NewLine
                If strProdShipStartDate.Trim.Length > 0 AndAlso strProdShipEndDate.Trim.Length > 0 Then
                    'AMERICAN MESSAGING Then exclude DBR and NER becuse system will auto ship
                    If iCustID = 14 Then Me.strSql &= "AND Ship_ID <> 9999919 " & Environment.NewLine
                    Me.strSql &= "AND Device_ShipWorkDate BETWEEN '" & strProdShipStartDate & "' AND '" & strProdShipEndDate & "'" & Environment.NewLine
                ElseIf booInWipDevice = True Then
                    Me.strSql &= "AND Device_DateShip is null " & Environment.NewLine
                Else
                    Return Nothing
                End If
                If iModelID > 0 Then Me.strSql &= "AND tdevice.Model_ID = " & iModelID & Environment.NewLine
                Me.strSql &= "AND tcustomer.Cust_ID = " & iCustID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Me.strSql = ""
            End Try
        End Function

        '*********************************************************************
        Public Function GetRURCode(ByVal iDeviceID As String, _
                           Optional ByVal iMcodeID As Integer = 0) As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT Dcode_Ldesc " & Environment.NewLine
                strSql &= "FROM tdevicecodes " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tdevicecodes.Dcode_ID = lcodesdetail.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicecodes.Device_ID = " & iDeviceID & " " & Environment.NewLine
                If iMcodeID > 0 Then strSql &= "AND lcodesdetail.Mcode_ID = " & iMcodeID & Environment.NewLine
                strSql &= "ORDER BY devicecode_id Desc "
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************************
        Public Sub DataTable2CSV(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)
            Dim writer As System.IO.StreamWriter
            Dim col As DataColumn, row As DataRow
            Try
                writer = New System.IO.StreamWriter(filename)

                ' first write a line with the columns name
                Dim sep As String = ""
                Dim builder As New System.Text.StringBuilder()
                For Each col In table.Columns
                    builder.Append(sep).Append(col.ColumnName)
                    sep = sepChar
                Next
                writer.WriteLine(builder.ToString())

                ' then write all the rows
                For Each row In table.Rows
                    sep = ""
                    builder = New System.Text.StringBuilder()

                    For Each col In table.Columns
                        builder.Append(sep).Append(row(col.ColumnName))
                        sep = sepChar
                    Next
                    writer.WriteLine(builder.ToString())
                Next
            Finally
                If Not writer Is Nothing Then writer.Close()
            End Try
        End Sub

        '*********************************************************************
        Public Function ReOrderTable(ByVal dt_in As DataTable, ByVal ColumnOrder() As Integer) As DataTable
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim c, c_in, key() As DataColumn
            Dim i As Integer
            Try
                dt.TableName = dt_in.TableName
                ' copy the schema of each columns
                For i = 0 To UBound(ColumnOrder)
                    c_in = dt_in.Columns(ColumnOrder(i))
                    c = New DataColumn(c_in.ColumnName)
                    c.DataType = c_in.DataType
                    c.AllowDBNull = c_in.AllowDBNull
                    c.MaxLength = c_in.MaxLength
                    c.AutoIncrement = c_in.AutoIncrement
                    c.AutoIncrementSeed = c_in.AutoIncrementSeed
                    c.AutoIncrementStep = c_in.AutoIncrementStep
                    dt.Columns.Add(c)
                Next
                ' copy the primary keys
                ReDim key(UBound(dt_in.PrimaryKey))
                For i = 0 To UBound(dt_in.PrimaryKey)
                    key(i) = dt.Columns(dt_in.PrimaryKey(i).ColumnName)
                Next
                dt.PrimaryKey = key
                ' copy the data
                For Each dr In dt_in.Rows()
                    dt.ImportRow(dr)
                Next
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                dt_in = Nothing
            End Try
        End Function

        '*********************************************************************
    End Class
End Namespace