Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports DBQuery.DataProc


Namespace Buisness

    Public Class MessLabel

        Private GobjMisc As Production.Misc
        Private GiDevice_ID As Integer = 0
        Private GstrDevice_SN As String = ""
        Private GstrOldDevice_SN As String = ""
        Private GstrFreq As String = ""
        Private GiBaudID As Integer = 0
        Private GstrCapCode As String = ""
        Private GiFreqID As Integer = 0
        Private GbooEligibleForRefreq As Boolean = False
        Private GbooRefreqUnit As Boolean = False
        Private GstrReservedCapCodeSelected As String = ""
        Private GstrReservedCapCodeReset As String = ""

        'Private GiSNChangeFlg As Integer = 0
        Private GstrOldCapCode As String = ""
        Private GiOldBaudID As Integer = 0
        Private GiOldFreqID As Integer = 0
        Private GiModelID As Integer = 0
        Private GiCustID As Integer = 0
        Private GiOldNewFlg As Integer = 0
        'Private strRptPath As String = "C:\Label_New\"
        Private strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
        Private GiLoc_ID As Integer = 0
        Private GiWO_ID As Integer = 0

        Private _strModelTypeLetter As String = ""
        Private _strModelType As String = ""
        Private _strSkyTellLetter As String = ""

        '***************************************************
        'Properties
        '***************************************************
        Public Property CustID() As Integer
            Get
                Return GiCustID
            End Get
            Set(ByVal Value As Integer)
                GiCustID = Value
            End Set
        End Property

        Public Property ModelID() As Integer
            Get
                Return GiModelID
            End Get
            Set(ByVal Value As Integer)
                GiModelID = Value
            End Set
        End Property

        Public Property DeviceID() As Integer
            Get
                Return GiDevice_ID
            End Get
            Set(ByVal Value As Integer)
                GiDevice_ID = Value
            End Set
        End Property
        '**************
        Public Property DeviceSN() As String
            Get
                Return GstrDevice_SN
            End Get
            Set(ByVal Value As String)
                GstrDevice_SN = Value
            End Set
        End Property
        '**************
        Public Property DeviceOldSN() As String
            Get
                Return GstrOldDevice_SN
            End Get
            Set(ByVal Value As String)
                GstrOldDevice_SN = Value
            End Set
        End Property
        '**************
        Public Property OldCapCode() As String
            Get
                Return GstrOldCapCode
            End Get
            Set(ByVal Value As String)
                GstrOldCapCode = Value
            End Set
        End Property

        '**************
        Public Property OldBaudID() As Integer
            Get
                Return GiOldBaudID
            End Get
            Set(ByVal Value As Integer)
                GiOldBaudID = Value
            End Set
        End Property
        '**************
        Public Property OldFreqID() As Integer
            Get
                Return GiOldFreqID
            End Get
            Set(ByVal Value As Integer)
                GiOldFreqID = Value
            End Set
        End Property
        '****************


        '**************
        Public Property Frequency() As String
            Get
                Return GstrFreq
            End Get
            Set(ByVal Value As String)
                GstrFreq = Value
            End Set
        End Property
        '**************
        Public Property FreqID() As Integer
            Get
                Return GiFreqID
            End Get
            Set(ByVal Value As Integer)
                GiFreqID = Value
            End Set
        End Property
        '**************
        Public Property BaudID() As Integer
            Get
                Return GiBaudID
            End Get
            Set(ByVal Value As Integer)
                GiBaudID = Value
            End Set
        End Property

        Public Property ModelTypeLetter() As String
            Get
                Return Me._strModelTypeLetter
            End Get
            Set(ByVal Value As String)
                Me._strModelTypeLetter = Value
            End Set
        End Property

        Public Property SkyTellLetter() As String
            Get
                Return Me._strSkyTellLetter
            End Get
            Set(ByVal Value As String)
                Me._strSkyTellLetter = Value
            End Set
        End Property

        Public Property ModelType() As String
            Get
                Return Me._strModelType
            End Get
            Set(ByVal Value As String)
                Me._strModelType = Value.ToUpper
            End Set
        End Property
        '**************
        Public Property CapCode() As String
            Get
                Return GstrCapCode
            End Get
            Set(ByVal Value As String)
                GstrCapCode = Value
            End Set
        End Property

        Public ReadOnly Property ElegibleForRefreq() As Boolean
            Get
                Return Me.GbooEligibleForRefreq
            End Get
        End Property

        Public ReadOnly Property IsRefreqUnit() As Boolean
            Get
                Return Me.GbooRefreqUnit
            End Get
        End Property
        Public ReadOnly Property WorkOrderID() As Integer
            Get
                Return Me.GiWO_ID
            End Get
        End Property

        Public Property ReservedCapCode_Selected() As String
            Get
                Return GstrReservedCapCodeSelected
            End Get
            Set(ByVal Value As String)
                GstrReservedCapCodeSelected = Value
            End Set
        End Property

        Public Property ReservedCapCode_Reset() As String
            Get
                Return GstrReservedCapCodeReset
            End Get
            Set(ByVal Value As String)
                GstrReservedCapCodeReset = Value
            End Set
        End Property

        '*********************************************************
        Public Function GetDailyWeeklyLabelProdByModelFreq(ByVal iLoc_ID As Integer) As DataTable
            Dim strsql As String = ""
            Dim dtData, dtWeekly As DataTable
            Dim R1, R2 As DataRow
            Dim strToday As String

            Try
                strToday = Generic.MySQLServerDateTime(1)

                strsql = "SELECT tmodel.Model_ID, Model_Desc as Model, " & Environment.NewLine
                strsql &= "if(lfrequency.freq_Number is null, '', lfrequency.freq_Number) as Frequency, " & Environment.NewLine
                strsql &= "count(*) as 'Daily', 0 as 'Weekly'  " & Environment.NewLine
                strsql &= "FROM tdevice " & Environment.NewLine
                strsql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strsql &= "WHERE loc_id = " & iLoc_ID & " " & Environment.NewLine
                strsql &= "AND (Ship_ID is null or ship_id <> 9999919 ) " & Environment.NewLine
                strsql &= "AND tmessdata.label_workdate = DATE_FORMAT(now(), '%y-%m-%d') " & Environment.NewLine
                strsql &= "GROUP BY Model_Desc, freq_Number " & Environment.NewLine
                strsql &= "ORDER BY Model_Desc, freq_Number;"

                GobjMisc._SQL = strsql
                dtData = GobjMisc.GetDataTable

                strsql = "SELECT tmodel.Model_ID, Model_Desc as Model, " & Environment.NewLine
                strsql &= "if(lfrequency.freq_Number is null, '', lfrequency.freq_Number) as Frequency, " & Environment.NewLine
                strsql &= "count(*) as  'Weekly' , 0 as 'Daily' " & Environment.NewLine
                strsql &= "FROM tdevice " & Environment.NewLine
                strsql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strsql &= "WHERE loc_id = " & iLoc_ID & "  " & Environment.NewLine
                strsql &= "AND (Ship_ID is null or ship_id <> 9999919 )  " & Environment.NewLine
                strsql &= "AND tmessdata.label_workdate <= DATE_FORMAT(now(), '%y-%m-%d') " & Environment.NewLine
                strsql &= "AND tmessdata.label_workdate >= '" & Format(DateAdd(DateInterval.Day, -1 * (Weekday(CDate(strToday), FirstDayOfWeek.Monday) - 1), CDate(strToday)), "yyyy-MM-dd") & "' " & Environment.NewLine
                strsql &= "GROUP BY Model_Desc, freq_Number " & Environment.NewLine
                strsql &= "ORDER BY Model_Desc, freq_Number;"
                GobjMisc._SQL = strsql
                dtWeekly = GobjMisc.GetDataTable

                For Each R1 In dtWeekly.Rows
                    For Each R2 In dtData.Rows
                        If R1("Model_ID") = R2("Model_ID") And R1("Frequency") = R2("Frequency") Then
                            R1.BeginEdit()
                            R1("Daily") = R2("Daily")
                            R1.EndEdit()
                        End If
                    Next R2

                    R2 = Nothing
                Next R1

                dtWeekly.AcceptChanges()

                Return dtWeekly

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dtData) Then
                    dtData.Dispose()
                    dtData = Nothing
                End If
            End Try
        End Function

        '*********************************************************
        Public Function GetLabelProductionNumbersByCC(ByVal strWorkDate As String, _
                                       ByVal iDailyWeekly As Integer) _
                                        As Integer

            Dim strWeekStartDate As String = strWorkDate
            Dim strWeekEndDate As String = strWorkDate
            Dim strsql As String = ""
            Dim ObjLib As New MyLib.Utility()
            Dim dt1 As DataTable

            Try
                If iDailyWeekly = 1 Then            'Weekly
                    strWeekStartDate = Format(DateAdd(DateInterval.Day, +1, ObjLib.GetLastSunday), "yyyy-MM-dd")    'Monday
                    strWeekEndDate = Format(DateAdd(DateInterval.Day, +7, ObjLib.GetLastSunday), "yyyy-MM-dd")      'Sunday
                End If

                'strsql = "Select count(*) as cnt from tmessdata " & Environment.NewLine
                'strsql &= "where tmessdata.label_userid = " & iUser_ID & " and " & Environment.NewLine
                'strsql &= "tmessdata.label_workdate >= '" & strWeekStartDate & "' and " & Environment.NewLine
                'strsql &= "tmessdata.label_workdate <= '" & strWeekEndDate & "';"
                strsql = "Select count(*) as cnt from tdevice " & Environment.NewLine
                strsql &= "inner join tmessdata On tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                strsql &= "where tdevice.cc_ID = " & Generic.GetMachineCostCenterID() & " and " & Environment.NewLine
                strsql &= "tmessdata.label_workdate >= '" & strWeekStartDate & "' and " & Environment.NewLine
                strsql &= "tmessdata.label_workdate <= '" & strWeekEndDate & "';"

                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable

                Return dt1.Rows(0)("cnt")

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                ObjLib = Nothing
            End Try

        End Function

        '*********************************************************
        Public Function PrintLabel(ByVal strSN As String, _
                                    ByVal strCapCode As String, _
                                    ByVal strFreq As String, _
                                    ByVal iBaud_ID As Integer, _
                                    ByVal strND As String, _
                                    ByVal strPlus As String, _
                                    ByVal iUserID As Integer, _
                                    ByVal strWorkDate As String, _
                                    ByVal _iReserveCapcodeID As Integer, _
                                    Optional ByVal strModelNumber As String = "", _
                                    Optional ByVal booPrintNoLabel As Boolean = False, _
                                    Optional ByVal booLabelBackgroudBlack As Boolean = False) As Integer

            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strNow As String = objGen.MySQLServerDateTime(1) 'Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Dim strOldSN As String = ""
            Dim iSNChanged As Integer = 0
            Dim iCapcodeChanged As Integer = 0
            Dim iFreqChanged As Integer = 0
            Dim iBaudRateChanged As Integer = 0
            Dim strOldCap As String = ""
            Dim iOldFreqID As Integer = 0
            Dim iOldBaudID As Integer = 0

            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim strSetValue As String = ""

            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iBandwidth As Integer = 0
            Dim strFCC As String = ""
            Dim strLblModNum As String = ""
            Dim strRptName As String = ""
            Dim objMessRec As New PSS.Data.Buisness.MessReceive()
            Dim iFreq_id As Integer = 0
            Dim strSKU As String = ""
            Dim booSNInWIP As Boolean = False
            Dim objRpt As ReportDocument
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim strS As String = "", strPart As String = "", strSingle As String = ""
            Dim bAllNumericDigitals As Boolean

            Dim bIsModelNumberOnly As Boolean = False
            Dim tmpArray() As String

            Try
                'tmessdata
                '**************************************************
                'Required field Validations
                If GiDevice_ID = 0 Then
                    Throw New Exception("Device ID is missing.")
                End If
                If Trim(strSN) = "" Then
                    Throw New Exception("Serial Number is missing.")
                End If

                If Trim(strCapCode) = "" Then
                    Throw New Exception("Cap Code is missing.")
                End If

                If Trim(strFreq) = "" Then
                    Throw New Exception("Frequency is missing.")
                End If
                If Len(Trim(strFreq)) <> 8 Then
                    Throw New Exception("Frequency is of incorrect length.")
                End If
                If InStr(strFreq, ".") = 0 Then
                    Throw New Exception("Frequency is of incorrect format.")
                End If

                If iBaud_ID = 0 Then
                    Throw New Exception("Baud Rate is missing.")
                End If

                '**************************************************
                'Comparison with old data to see if data changed
                '**************************************************
                'SN Compare
                If UCase(Trim(strSN)) = UCase(Trim(GstrDevice_SN)) Then
                    strOldSN = ""
                    iSNChanged = 0
                Else
                    'DON'T ALLOW USER TO CHANGE SN
                    'strOldSN = GstrDevice_SN
                    'iSNChanged = 1

                    ''******************************************
                    ''Validate new SN if user want to change SN
                    ''******************************************
                    'booSNInWIP = objGen.IsSNInWIP(Me.GiCustID, strSN)
                    'If booSNInWIP = True Then
                    '    MsgBox("New SN is already existed in WIP. Can not change SN.", MsgBoxStyle.Information, "Validate New SN")
                    '    Exit Function
                    'End If

                    strSN = UCase(Trim(GstrDevice_SN))
                End If

                'Create DataProc object
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                '********************
                'Cap Code Compare
                If UCase(Trim(strCapCode)) = UCase(Trim(GstrCapCode)) Then
                    strOldCap = ""
                Else
                    strOldCap = GstrCapCode
                    iCapcodeChanged = 1
                End If
                '********************
                'Frequency Compare
                If UCase(Trim(strFreq)) = UCase(Trim(GstrFreq)) Then
                    iOldFreqID = 0
                Else
                    iOldFreqID = GiFreqID
                    iFreqChanged = 1
                End If
                '********************
                'Baud Rate Compare
                If iBaud_ID = GiBaudID Then
                    iOldBaudID = 0
                Else
                    iOldBaudID = GiBaudID
                    iBaudRateChanged = 1
                End If
                '********************

                '***************************************** lan added on 04/26/07
                'When Change happen in tmessdata, it must happen in tdevicemetro
                '******************************************
                'Get Freq info
                R1 = objMessRec.GetFreqInfo(strFreq)

                If Not IsNothing(R1) Then
                    iFreq_id = R1("freq_id")
                End If

                '******************************************
                'Get SKU
                strSKU = Me.GetSKUFromBaudID(iBaud_ID)

                R1 = Nothing : objMessRec = Nothing

                '--------------------------------  New critieria ------------------------------------------------------------
                'get noletter model ids
                strS = ModManuf.GetExceptionCriteria("AMS_CAPCODE_NOLETTER", "ModelIDs").Trim
                tmpArray = Split(strS, ",")
                If tmpArray.Length > 0 Then
                    For i = 0 To tmpArray.Length - 1
                        If tmpArray(i) = GiModelID Then bIsModelNumberOnly = True : Exit For
                    Next
                End If
                strS = "" : i = 0
                If GiModelID = 7 Then
                    strS = strCapCode.Substring(0, 1)
                    If Not strS.ToUpper = "A" Then
                        Throw New Exception("Invalid capcode. It must start with letter 'A' for model '" & strModelNumber & "'.")
                    End If
                ElseIf bIsModelNumberOnly Then 'no letter,only number
                    strS = strCapCode.Substring(0, 1)
                    If [Char].IsLetter(strS) Then
                        Throw New Exception("Invalid capcode. It must be no letter in the capcode '" & strND & "'.")
                    End If
                ElseIf iBaud_ID = 4 Then 'Flex
                    strS = strCapCode.Substring(0, 1)
                    If Not strS.ToUpper = "E" Then
                        Throw New Exception("Invalid capcode. It must start with letter 'E'for baud rate '" & strND & "'.")
                    End If
                ElseIf strND.Length >= 6 AndAlso strND.Substring(0, 6).ToUpper = "POCSAG" Then 'POCSAG
                    strPart = strCapCode : bAllNumericDigitals = False
                    If strPart.Length > 0 Then
                        For i = 0 To strPart.Length - 1
                            strSingle = strPart.Substring(i, 1)
                            If Not IsNumeric(strSingle) Then
                                bAllNumericDigitals = False : Exit For
                            End If
                        Next
                        bAllNumericDigitals = True
                    Else
                        bAllNumericDigitals = False
                    End If
                    If Not bAllNumericDigitals Then
                        Throw New Exception("Invalid capcode. It must have numeric digits if baud rate starts with 'POCSAG'.")
                    End If
                End If
                '-------------------------------------------------------------------------------------------------------------

                'Update tdevice table
                If iSNChanged = 1 Then
                    strsql = "update tdevice set " & Environment.NewLine
                    If Trim(GstrOldDevice_SN) = "" Then
                        strsql &= "device_oldsn = device_sn, " & Environment.NewLine
                    End If
                    strsql &= "device_sn = '" & strSN & "' " & Environment.NewLine
                    strsql &= "where device_id = " & GiDevice_ID & ";"

                    Me.GobjMisc._SQL = strsql
                    i = Me.GobjMisc.ExecuteNonQuery()
                End If

                '********************
                'Update tmessdata table
                strSetValue = ""
                strSetValue &= "tmessdata.label_userid = " & iUserID & " " & Environment.NewLine
                strSetValue &= ", " & "tmessdata.label_workdate = '" & strWorkDate & "' " & Environment.NewLine

                If iSNChanged = 1 Then
                    strSetValue &= ", " & "tmessdata.sn_changed = " & iSNChanged & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.sn_change_userid = " & iUserID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.sn_change_date = '" & strNow & "'" & Environment.NewLine
                End If

                'GstrOldCapCode
                If iCapcodeChanged = 1 Then
                    strSetValue &= ", " & "tmessdata.capcode = '" & Trim(strCapCode) & "'" & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.capcode_old = '" & strOldCap & "'" & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.capcode_change_userid = " & iUserID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.capcode_change_date = '" & strNow & "'" & Environment.NewLine
                End If

                If iFreqChanged = 1 Then
                    strSetValue &= ", " & "tmessdata.freq_id = " & iFreq_id & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.freq_id_old = " & iOldFreqID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.freq_id_change_userid = " & iUserID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.freq_id_change_date = '" & strNow & "'" & Environment.NewLine
                End If

                If iBaudRateChanged > 0 Then
                    strSetValue &= ", " & "tmessdata.baud_id = " & iBaud_ID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.baud_id_old = " & iOldBaudID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.baud_id_change_userid = " & iUserID & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.baud_id_change_date = '" & strNow & "'" & Environment.NewLine
                    strSetValue &= ", " & "tmessdata.SKU = '" & strSKU & "'" & Environment.NewLine
                End If

                strsql = "Update tmessdata set " & Environment.NewLine
                strsql &= strSetValue
                If _iReserveCapcodeID > 0 Then strsql &= ", FCP_ID = " & _iReserveCapcodeID & Environment.NewLine
                strsql &= "where device_id = " & Me.GiDevice_ID & ";"

                Me.GobjMisc._SQL = strsql
                i = Me.GobjMisc.ExecuteNonQuery()
                'End If

                If _iReserveCapcodeID > 0 Then
                    strsql = "UPDATE tmessfreqcapcodepool SET Device_ID = " & Me.GiDevice_ID & ", Available = 0 WHERE FCP_ID = " & _iReserveCapcodeID
                    i = Me.GobjMisc.ExecuteNonQuery(strsql)

                    If Not Me.GstrReservedCapCodeSelected.Trim.ToUpper = Me.GstrReservedCapCodeReset.Trim.ToUpper Then
                        strsql = "UPDATE tmessfreqcapcodepool SET CapCode = '" & strCapCode & "' WHERE FCP_ID = " & _iReserveCapcodeID
                        i = Me.GobjMisc.ExecuteNonQuery(strsql)
                    End If
                End If

                If booPrintNoLabel = False Then
                    '*****************************************
                    'Find Bandwidth
                    If Trim(strFreq) <> "" Then
                        iBandwidth = CInt(Left(Trim(strFreq), 1))
                    Else
                        iBandwidth = 0
                    End If

                    If iBandwidth <> 9 And iBandwidth <> 4 And iBandwidth <> 1 Then
                        Throw New Exception("Bandwidth could not be derived from Frequency. Frequency may be invalid.")
                    End If
                    '*****************************************
                    'Get FCC ID
                    strsql = "Select * " & Environment.NewLine
                    strsql &= "from llabel " & Environment.NewLine
                    strsql &= "where model_id = " & GiModelID & " and " & Environment.NewLine
                    strsql &= "baud_id = " & iBaud_ID & " and " & Environment.NewLine
                    strsql &= "label_bandwidth = " & iBandwidth & ";"
                    GobjMisc._SQL = strsql
                    dt1 = GobjMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Combination of Model_ID, Baud_ID and Label_Bandwidth was not setup in llabel table.")
                    Else
                        R1 = dt1.Rows(0)

                        '*************************
                        If GiModelID <> 1965 Then 'when GS-Coaster, skip FCC ID check
                            If Not IsDBNull(R1("label_fcc")) Then
                                strFCC = Trim(R1("label_fcc"))
                            Else
                                strFCC = ""
                            End If
                            If strFCC = "" Then
                                strFCC = InputBox("'FCC ID' is not in database. Please enter 'FCC ID'.")
                            End If
                        End If

                        '*************************
                        If Not IsDBNull(R1("label_model_numb")) Then
                            strLblModNum = Trim(R1("label_model_numb"))
                        Else
                            strLblModNum = ""
                        End If
                        If strLblModNum = "" Then
                            strLblModNum = InputBox("'Model Number' is not in database. Please enter 'Model Number'.")
                        End If
                        '*************************
                        If GiModelID = 76 Then
                            strLblModNum = strModelNumber
                        End If
                    End If
                    '*****************************************
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    '*****************************************
                    'Get Report name from llabel
                    GobjMisc._SQL = "Select * from lcustmodlbl where model_id = " & GiModelID & " and cust_id = " & Me.GiCustID & ";"
                    dt1 = GobjMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Report Name could not be determined. Label for this Model and Customer may not be setup.")
                    End If

                    For Each R1 In dt1.Rows      'Take the first row and move on
                        strRptName = Trim(R1("Label_Name"))
                        Exit For
                    Next R1

                    '*****************************************
                    'Strip the extension
                    If strRptName.Trim.IndexOf(".") > -1 Then strRptName = strRptName.Trim.Substring(0, strRptName.Trim.IndexOf("."))

                    'strRptName &= " Push.rpt"
                    If booLabelBackgroudBlack Then
                        strRptName &= " Push BGBlack.rpt"
                    Else
                        strRptName &= " Push.rpt"
                    End If

                    'SQL for report data
                    strsql = "SELECT E.Model_Desc AS ModelDesc, A.Device_SN AS DeviceSN, D.freq_Number AS Freq, B.capcode AS CapCode, C.baud_Number AS BaudNumber, '" & strFCC & "' AS FCC, '" & strND & "' AS ND, '" & strPlus & "' AS Plus, '" & strLblModNum & "' AS LabelModelNumber, " & Environment.NewLine
                    strsql &= "'" & Me.ModelTypeLetter & "' AS ModelTypeLetter, '" & Me.ModelType & "' AS ModelType, '" & Me._strSkyTellLetter & "' as SkyTell " & Environment.NewLine
                    strsql &= "FROM tdevice A " & Environment.NewLine
                    strsql &= "INNER JOIN tmessdata B ON B.device_id = A.device_id " & Environment.NewLine
                    strsql &= "INNER JOIN lbaud C ON C.baud_id = B.baud_id " & Environment.NewLine
                    strsql &= "INNER JOIN lfrequency D ON D.freq_id = B.freq_id " & Environment.NewLine
                    strsql &= "INNER JOIN tmodel E ON E.model_id = A.model_id " & Environment.NewLine
                    strsql &= "WHERE A.device_id = " & Me.GiDevice_ID.ToString

                    'Print Label
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(strRptPath & strRptName)

                        dt = objDataProc.GetDataTable(strsql)

                        If Not IsNothing(dt) Then .SetDataSource(dt)

                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If

                ClearGlobalVar()
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objMessRec = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*********************************************************
        Public Function GetSKUFromBaudID(ByVal iBaud_ID As Integer) As String
            Dim strSKU As String = ""

            Try
                Select Case iBaud_ID
                    Case 1
                        strSKU = "XXFXXXXXXX"
                    Case 2
                        strSKU = "XXTXXXXXXX"
                    Case 3
                        strSKU = "XX4XXXXXXX"
                    Case 4
                        strSKU = "XXXXXXFLXX"
                End Select

                Return strSKU
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************
        'GetMessDeviceInfoForLabel()
        '***************************************************
        Public Function GetMessDeviceInfoForLabel(ByVal strSN As String, _
                                                  ByVal iCustID As Integer) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '*******************************************************
                'Get Device_ID from tdevice table
                '*******************************************************
                strsql = "Select device_id, device_sn, Device_OldSN, tray_id, tdevice.WO_ID, model_id, tdevice.loc_id " & Environment.NewLine
                strsql &= "from tdevice  " & Environment.NewLine
                strsql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strsql &= "where device_sn = '" & strSN & "' " & Environment.NewLine
                strsql &= "AND Device_DateShip is null  " & Environment.NewLine
                strsql &= "AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "order by device_id desc;"
                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If dt1.Rows.Count > 1 Then
                        Throw New Exception("Serial Number exist more than one for this customer. Please contact IT.")
                    Else
                        R1 = dt1.Rows(0)
                        If Not IsDBNull(R1("Device_ID")) Then
                            GiDevice_ID = R1("Device_ID")
                            GiModelID = R1("model_id")
                            GiLoc_ID = R1("loc_id")
                            GstrDevice_SN = Trim(R1("Device_SN"))
                            Me.GiWO_ID = R1("WO_ID")
                            If Not IsDBNull(R1("Device_OldSN")) Then
                                GstrOldDevice_SN = Trim(R1("Device_OldSN"))
                            Else
                                GstrOldDevice_SN = ""
                            End If
                        End If
                    End If
                Else
                    Throw New Exception("Serial Number does not exist in WIP.")
                End If

                If GiDevice_ID = 0 Then
                    Throw New Exception("Can't define device ID.")
                End If

                '******************************************************************
                'Check if unit eligible for refreq or if the unit is a refreq unit
                '******************************************************************
                Me.GetRefreqCriterion()

                '*******************************************************
                strsql = ""
                '*******************************************************
                'Get data from tmessdata
                strsql = "Select tmessdata.*,  " & Environment.NewLine
                strsql &= "lfrequency.freq_Number, lbaud.baud_Number,  " & Environment.NewLine
                strsql &= "tmodel.model_id, tmodel.model_desc,  " & Environment.NewLine
                strsql &= "tcustomer.cust_id, tcustomer.cust_name1, tlocation.Loc_Name, tlocation.Loc_ID" & Environment.NewLine
                strsql &= "from tmessdata " & Environment.NewLine
                strsql &= "inner join tdevice on tmessdata.device_id = tdevice.device_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strsql &= "left outer join lfrequency on tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strsql &= "left outer join lbaud on tmessdata.baud_id = lbaud.baud_id " & Environment.NewLine
                strsql &= "where tmessdata.device_id = " & GiDevice_ID & " " & Environment.NewLine
                strsql &= "order by tmessdata.MD_ID desc;"

                GobjMisc._SQL = strsql
                Return GobjMisc.GetDataTable

                '*******************************************************
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

        '***************************************************
        Public Sub GetRefreqCriterion()
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '******************************
                'Check if device billed refreq
                '******************************
                strsql = "Select * " & Environment.NewLine
                strsql &= "from tdevicebill  " & Environment.NewLine
                strsql &= "where device_id = " & Me.GiDevice_ID & " " & Environment.NewLine
                strsql &= "AND billcode_id = 58 " & Environment.NewLine
                strsql &= "order by device_id desc;"
                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Me.GbooRefreqUnit = True
                    Exit Sub
                End If

                '******************************
                strsql = ""
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                '******************************
                'Verify map
                '******************************
                strsql = "Select * " & Environment.NewLine
                strsql &= "from tpsmap " & Environment.NewLine
                strsql &= "where billcode_id = 58 and Model_ID = " & Me.GiModelID & " " & Environment.NewLine
                strsql &= "and Inactive = 0;"

                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    Me.GbooEligibleForRefreq = True
                End If
                '******************************

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
            End Try
        End Sub

        '***************************************************
        Public Function ReplaceRecord_Tdevicemetro(ByVal strSN As String, _
                                                   ByVal strDeviceMetro_SKU As String, _
                                                   ByVal strDeviceMetro_CapCode As String, _
                                                   ByVal iDeviceMetro_FreqCode As Integer, _
                                                   ByVal iFreq_ID As Integer, _
                                                   ByVal iModel_id As Integer, _
                                                   ByVal iTray_ID As Integer, _
                                                   ByVal iWO_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0

            Try
                strsql = "Replace into tdevicemetro " & Environment.NewLine
                strsql &= "( " & Environment.NewLine
                strsql &= "deviceMetro_SN, " & Environment.NewLine
                If strDeviceMetro_SKU <> "" Then
                    strsql &= "deviceMetro_SKU, " & Environment.NewLine
                End If
                If strDeviceMetro_CapCode <> "" Then
                    strsql &= "deviceMetro_CapCode, " & Environment.NewLine
                End If
                If iDeviceMetro_FreqCode <> 0 Then
                    strsql &= "deviceMetro_FreqCode, " & Environment.NewLine
                End If
                strsql &= "freq_ID, " & Environment.NewLine
                strsql &= "Model_id, " & Environment.NewLine
                strsql &= "Tray_ID, " & Environment.NewLine
                strsql &= "WO_ID " & Environment.NewLine
                strsql &= ") " & Environment.NewLine
                strsql &= "VALUES" & Environment.NewLine
                strsql &= "( " & Environment.NewLine
                strsql &= "'" & strSN & "'," & Environment.NewLine
                If strDeviceMetro_SKU <> "" Then
                    strsql &= "'" & strDeviceMetro_SKU & "'," & Environment.NewLine
                End If
                If strDeviceMetro_CapCode <> "" Then
                    strsql &= "'" & strDeviceMetro_CapCode & "'," & Environment.NewLine
                End If
                If iDeviceMetro_FreqCode <> 0 Then
                    strsql &= iDeviceMetro_FreqCode & "," & Environment.NewLine
                End If
                strsql &= iFreq_ID & "," & Environment.NewLine
                strsql &= iModel_id & "," & Environment.NewLine
                strsql &= iTray_ID & "," & Environment.NewLine
                strsql &= iWO_ID & Environment.NewLine
                strsql &= ");"
                GobjMisc._SQL = strsql
                i = GobjMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************
        Public Function GetMessDeviceInfoForLabel_TdeviceMetro(ByVal strSN As String) As DataTable
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objMessRec As New PSS.Data.Buisness.MessReceive()
            Dim strBaudRate As String = ""
            Dim iBaud_id As Integer = 0

            Try
                strsql = "select " & Environment.NewLine
                strsql &= "deviceMetro_CapCode as capcode, " & Environment.NewLine
                strsql &= "lfrequency.freq_Number as freq_Number, " & Environment.NewLine
                strsql &= "lfrequency.Freq_ID as Freq_id, " & Environment.NewLine
                strsql &= "0 as baud_id, " & Environment.NewLine
                strsql &= "'' as capcode_old, " & Environment.NewLine
                strsql &= "0 as baud_id_old, " & Environment.NewLine
                strsql &= "0 as freq_id_old, " & Environment.NewLine
                strsql &= "tmodel.model_desc as model_desc, " & Environment.NewLine
                strsql &= "tdevicemetro.Model_id as model_id, " & Environment.NewLine
                strsql &= "tcustomer.Cust_Name1 as cust_name1, " & Environment.NewLine
                strsql &= "tcustomer.Cust_ID as cust_id, " & Environment.NewLine
                strsql &= "deviceMetro_SKU, " & Environment.NewLine
                strsql &= "tdevice.WO_ID" & Environment.NewLine
                strsql &= "from tdevicemetro " & Environment.NewLine
                strsql &= "inner join lfrequency on  tdevicemetro.Freq_ID = lfrequency.freq_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevicemetro.Model_id = tmodel.Model_ID " & Environment.NewLine
                strsql &= "inner join tdevice on tdevice.Device_SN = tdevicemetro.deviceMetro_SN " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "inner join tcustomer on tlocation.cust_id = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where deviceMetro_SN = '" & strSN & "';"

                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        R1 = dt1.Rows(0)
                        GiWO_ID = R1("WO_ID")
                        If Not IsDBNull(R1("deviceMetro_SKU")) Then
                            If Trim(R1("deviceMetro_SKU")) <> "" Then
                                strBaudRate = objMessRec.CreateBaudRateFromSKU(Trim(R1("deviceMetro_SKU")))
                                If strBaudRate <> "" Then
                                    iBaud_id = objMessRec.GetBaudID(strBaudRate)
                                    R1.BeginEdit()
                                    R1("baud_id") = iBaud_id
                                    R1.EndEdit()
                                    dt1.AcceptChanges()
                                End If
                            End If
                        End If
                        Exit For
                    Next R1
                End If

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                objMessRec = Nothing
            End Try
        End Function

        '*********************************************************
        'Get Baud Rates
        Public Function GetBaudRates() As DataTable
            Dim dt1 As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select * from lbaud;"
                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable
                InsertEmptyRow(dt1, , "Baud_ID", "Baud_Number", , , "-- Select --")
                Return dt1
            Catch ex As Exception
                DisposeDT(dt1)
                Throw ex
            End Try
        End Function


        '*********************************************************
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
                Throw New Exception("InsertEmptyRow(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Sub ClearGlobalVar()
            Try
                GiDevice_ID = 0
                GstrDevice_SN = ""
                GstrOldDevice_SN = ""
                GstrFreq = ""
                GiBaudID = 0
                GstrCapCode = ""
                GiFreqID = 0
                Me.GbooEligibleForRefreq = False
                Me.GbooRefreqUnit = False

                GstrOldCapCode = ""
                GiOldBaudID = 0
                GiOldFreqID = 0
                GiModelID = 0
                GiCustID = 0
                GiOldNewFlg = 0
                GiLoc_ID = 0
                GiWO_ID = 0

                _strModelTypeLetter = ""
                _strModelType = ""
                _strSkyTellLetter = ""
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************
        'Dispose dt
        '*********************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function
        '*********************************************************
        Public Sub New()
            GobjMisc = New Production.Misc()
        End Sub
        '*********************************************************
        Protected Overrides Sub Finalize()
            GobjMisc = Nothing
            MyBase.Finalize()
        End Sub
        '*********************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '*********************************************************
        Public Function RePrintLabel(ByVal strSN As String, _
                                    ByVal strCapCode As String, _
                                    ByVal strFreq As String, _
                                    ByVal iBaud_ID As Integer, _
                                    ByVal strBaudDesc As String, _
                                    ByVal strND As String, _
                                    ByVal strPlus As String, _
                                    ByVal iCustID As Integer, _
                                    ByVal iModelID As Integer, _
                                    ByVal strModelDesc As String, _
                                    Optional ByVal strModelNumber As String = "", _
                                    Optional ByVal booLabelBackgroudBlack As Boolean = False) As Integer

            Dim strNow As String = Generic.MySQLServerDateTime(1) 'Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim strSetValue As String = ""

            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iBandwidth As Integer = 0
            Dim strFCC As String = ""
            Dim strLblModNum As String = ""
            Dim strRptName As String = ""
            Dim objRpt As ReportDocument
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                '*****************************
                'Required field Validations
                '*****************************
                If Trim(strSN) = "" Then
                    Throw New Exception("Serial Number is missing.")
                End If
                If Trim(strCapCode) = "" Then
                    Throw New Exception("Cap Code is missing.")
                End If
                If Trim(strFreq) = "" Then
                    Throw New Exception("Frequency is missing.")
                End If
                If Len(Trim(strFreq)) <> 8 Then
                    Throw New Exception("Frequency is of incorrect length.")
                End If
                If InStr(strFreq, ".") = 0 Then
                    Throw New Exception("Frequency is of incorrect format.")
                End If

                If iBaud_ID = 0 Then
                    Throw New Exception("Baud Rate is missing.")
                End If

                'Create DataProc object
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                '*****************************************
                'Find Bandwidth
                If Trim(strFreq) <> "" Then
                    iBandwidth = CInt(Left(Trim(strFreq), 1))
                Else
                    iBandwidth = 0
                End If

                If iBandwidth <> 9 And iBandwidth <> 4 And iBandwidth <> 1 Then
                    Throw New Exception("Bandwidth could not be derived from Frequency. Frequency may be invalid.")
                End If
                '*****************************************
                'Get FCC ID
                strsql = "Select * " & Environment.NewLine
                strsql &= "from llabel " & Environment.NewLine
                strsql &= "where model_id = " & iModelID & " and " & Environment.NewLine
                strsql &= "baud_id = " & iBaud_ID & " and " & Environment.NewLine
                strsql &= "label_bandwidth = " & iBandwidth & ";"
                GobjMisc._SQL = strsql
                dt1 = GobjMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Combination of Model_ID, Baud_ID and Label_Bandwidth was not setup in llabel table.")
                Else
                    R1 = dt1.Rows(0)

                    '*************************
                    If Not IsDBNull(R1("label_fcc")) Then
                        strFCC = Trim(R1("label_fcc"))
                    Else
                        strFCC = ""
                    End If
                    If strFCC = "" Then
                        strFCC = InputBox("'FCC ID' is not in database. Please enter 'FCC ID'.")
                    End If
                    '*************************
                    If Not IsDBNull(R1("label_model_numb")) Then
                        strLblModNum = Trim(R1("label_model_numb"))
                    Else
                        strLblModNum = ""
                    End If
                    If strLblModNum = "" Then
                        strLblModNum = InputBox("'Model Number' is not in database. Please enter 'Model Number'.")
                    End If
                    '*************************
                    If iModelID = 76 Then
                        strLblModNum = strModelNumber
                    End If
                End If
                '*****************************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                '*****************************************
                'Get Report name from llabel
                GobjMisc._SQL = "Select * from lcustmodlbl where model_id = " & iModelID & " and cust_id = " & iCustID & ";"
                dt1 = GobjMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Report Name could not be determined. Label for this Model and Customer may not be setup.")
                End If

                For Each R1 In dt1.Rows      'Take the first row and move on
                    strRptName = Trim(R1("Label_Name"))
                    Exit For
                Next R1

                '*****************************************
                'Strip the extension
                If strRptName.Trim.IndexOf(".") > -1 Then strRptName = strRptName.Trim.Substring(0, strRptName.Trim.IndexOf("."))

                'strRptName &= " Push.rpt"
                If booLabelBackgroudBlack Then
                    strRptName &= " Push BGBlack.rpt"
                Else
                    strRptName &= " Push.rpt"
                End If

                'SQL for report data
                strsql = "SELECT '" & strModelDesc & "' AS ModelDesc " & Environment.NewLine
                strsql &= ", '" & strSN & "' AS DeviceSN " & Environment.NewLine
                strsql &= ", '" & strFreq & "' AS Freq " & Environment.NewLine
                strsql &= ", '" & strCapCode & "' AS CapCode " & Environment.NewLine
                strsql &= ", '" & strBaudDesc & "' AS BaudNumber " & Environment.NewLine
                strsql &= ", '" & strFCC & "' AS FCC " & Environment.NewLine
                strsql &= ", '" & strND & "' AS ND " & Environment.NewLine
                strsql &= ", '" & strPlus & "' AS Plus " & Environment.NewLine
                strsql &= ", '" & strLblModNum & "' AS LabelModelNumber " & Environment.NewLine
                strsql &= ", '" & Me.ModelTypeLetter & "' AS ModelTypeLetter " & Environment.NewLine
                strsql &= ", '" & Me.ModelType & "' AS ModelType " & Environment.NewLine
                strsql &= ", '" & Me._strSkyTellLetter & "' as SkyTell " & Environment.NewLine

                'Print Label
                objRpt = New ReportDocument()

                With objRpt
                    .Load(strRptPath & strRptName)

                    dt = objDataProc.GetDataTable(strsql)

                    If Not IsNothing(dt) Then .SetDataSource(dt)

                    .PrintToPrinter(1, True, 0, 0)
                End With

                ClearGlobalVar()
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*********************************************************
        'Validate Freq
        '*********************************************************
        Public Function IsFreqExisted(ByVal strFreq As String) As Boolean
            Dim dt As DataTable
            Dim strsql As String = ""

            Try
                strsql = "select * from lfrequency where freq_number='" & strFreq & "';"
                GobjMisc._SQL = strsql
                dt = GobjMisc.GetDataTable
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                DisposeDT(dt) : Throw ex
            End Try
        End Function
        '*********************************************************
        'Insert Freq
        '*********************************************************
        Public Function InsertFreq(ByVal strFreq As String, ByVal iMotoCode As Integer) As Integer
            Dim strsql As String = ""

            Try
                strsql = "Insert Into lfrequency (freq_Number,freq_MotoCode) Values ( '" & strFreq & "'," & iMotoCode & ");"
                GobjMisc._SQL = strsql
                Return GobjMisc.ExecuteNonQuery(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function GetShareableInventoryCustList(ByVal iCustID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strsql As String = "", strCustIDs As String
            Dim dt As DataTable
            Dim booInShareableList As Boolean = False
            Dim i As Integer

            Try
                '1: Get Shareable customer list
                strsql = "SELECT CustIDs FROM exceptioncriteria WHERE Description = 'AMS_SHAREABLE_INVENTORY_CUSTOMERS'"
                strCustIDs = GobjMisc.GetSingletonString(strsql)

                If Not IsDBNull(strCustIDs) AndAlso strCustIDs.ToString.Length > 0 Then
                    booInShareableList = IsAMSShareableInventoryCustomer(iCustID)

                    If booInShareableList = True Then
                        strsql = "SELECT DISTINCT A.Cust_ID, A.Cust_Name1 FROM tcustomer A " & Environment.NewLine
                        strsql &= "WHERE A.Cust_ID in ( " & strCustIDs & " ) AND A.Cust_ID <> " & iCustID & Environment.NewLine
                        dt = GobjMisc.GetDataTable(strsql)
                    End If
                End If

                'create column if no data
                If IsNothing(dt) OrElse dt.Columns.Count = 0 Then
                    dt = New DataTable()
                    dt.Columns.Add("Cust_ID", System.Type.GetType("System.Int32"))
                    dt.Columns.Add("Cust_Name1", System.Type.GetType("System.String"))
                End If

                'add select row
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                dt.TableName = "Customer"

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Shared Function IsAMSShareableInventoryCustomer(ByVal iCustID As Integer) As Boolean
            Dim dt As DataTable
            Dim strCustIDsArray As String()
            Dim i As Integer
            Dim booReturnVal As Boolean = False

            Try
                IsAMSShareableInventoryCustomer = False
                dt = ModManuf.GetExceptionCriteria("AMS_SHAREABLE_INVENTORY_CUSTOMERS")
                If dt.Rows.Count = 0 Then
                    booReturnVal = False
                Else
                    strCustIDsArray = dt.Rows(0)("CustIDs").Split(",")
                    For i = 0 To strCustIDsArray.Length - 1
                        If strCustIDsArray(i).Trim.Length > 0 Then
                            If strCustIDsArray(i).Trim = iCustID.ToString Then
                                booReturnVal = True : Exit For
                            End If
                        End If
                    Next i
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************
        Public Function GetAvailableCapcodeByCustFreq(ByVal iCustID As Integer, ByVal strFreq As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.FCP_ID, A.Freq_ID, A.CapCode" & Environment.NewLine
                strSql &= "FROM tmessfreqcapcodepool A" & Environment.NewLine
                strSql &= "INNER JOIN lfrequency B ON A.Freq_ID = B.Freq_ID" & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & " AND B.freq_Number = '" & strFreq & "' AND Device_ID = 0 AND Reserve = 0 "
                Return GobjMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function GetCapcode(ByVal iFCP_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.*, B.Freq_Number" & Environment.NewLine
                strSql &= "FROM tmessfreqcapcodepool A" & Environment.NewLine
                strSql &= "INNER JOIN lfrequency B ON A.Freq_ID = B.Freq_ID" & Environment.NewLine
                strSql &= "WHERE A.FCP_ID = " & iFCP_ID
                Return GobjMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function GetAvailableCapcodeByCapcode(ByVal strCapcode As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.*, B.Freq_Number, C.Cust_Name1" & Environment.NewLine
                strSql &= "FROM tmessfreqcapcodepool A" & Environment.NewLine
                strSql &= "INNER JOIN lfrequency B ON A.Freq_ID = B.Freq_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcustomer C ON A.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= "WHERE A.Capcode = '" & strCapcode.Trim & "' AND Device_ID = 0 AND Available = 1 "
                Return GobjMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function ReserveCapCode(ByVal iFCP_ID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tmessfreqcapcodepool SET Reserve = 1, Reserve_Date = now(), Reserve_UserID = " & iUserID & Environment.NewLine
                strSql &= "WHERE FCP_ID = " & iFCP_ID & " AND Device_ID = 0 AND Available = 1"
                Return GobjMisc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function ResetReserveCapcode(ByVal iFCP_ID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tmessfreqcapcodepool SET Reserve = 0, Reserve_Date = null, Reserve_UserID = 0 " & Environment.NewLine
                strSql &= "WHERE FCP_ID = " & iFCP_ID & " AND Device_ID = 0 AND Available = 1"
                Return GobjMisc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function ResetReserveCapcodeWithOldDate() As Integer
            Dim strSql As String = "", strToday As String = ""

            Try
                strToday = Generic.MySQLServerDateTime(1)

                strSql = "UPDATE tmessfreqcapcodepool SET Reserve = 0, Reserve_Date = null " & Environment.NewLine
                strSql &= "WHERE Reserve_Date < '" & CDate(strToday).ToString("yyyy-MM-dd") & " 00:00:00'" & " AND Device_ID = 0 AND Available = 1"
                Return GobjMisc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function GetLastCreateOpenWorkorderWithoutPO(ByVal iLocID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT WO_ID FROM tworkorder WHERE Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND InvalidOrder = 0 AND WO_Closed = 0 AND (PO_ID is null OR PO_ID = 0) AND WO_Shipped = 0 " & Environment.NewLine
                strSql &= "ORDER BY WO_ID DESC LIMIT 1" & Environment.NewLine
                Return GobjMisc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function IsWorkorderHasPO(ByVal iWOID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booHasPO As Boolean = True

            Try
                IsWorkorderHasPO = False

                strSql = "SELECT PO_ID FROM tworkorder WHERE WO_ID = " & iWOID & Environment.NewLine
                dt = GobjMisc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    Throw New Exception("Work order does not exist.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate work order.")
                ElseIf IsDBNull(dt.Rows(0)("PO_ID")) OrElse CInt(dt.Rows(0)("PO_ID")) = 0 Then
                    booHasPO = False
                End If

                Return booHasPO
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************
        Public Function ChangeCustomer(ByVal iCurrentCustID As Integer, ByVal iDeviceID As Integer, _
                                       ByVal iNewLocID As Integer, ByVal booUpdRecCustID As Boolean, _
                                       ByVal iWOID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tdevice, tmessdata SET tdevice.Loc_ID = " & iNewLocID & ", tdevice.WO_ID = " & iWOID & ", tdevice.WO_ID_Out = 0 " & Environment.NewLine
                strSql &= ", tmessdata.PrevCustID = " & iCurrentCustID & " , tmessdata.UpdCust_UserID = " & iUserID & ", tmessdata.UpdCust_DT = now() " & Environment.NewLine
                strSql &= ", tmessdata.wo_id = " & iWOID & Environment.NewLine
                If booUpdRecCustID Then strSql &= ", Rec_Cust_ID = " & iCurrentCustID & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tmessdata.Device_ID AND tdevice.Device_ID = " & iDeviceID
                i = Me.GobjMisc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to update new location.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function ReleaseCapcode(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "UPDATE tmessfreqcapcodepool SET Device_ID = 0, Available = 1, Reserve = 0, Reserve_Date = null, Reserve_UserID = 0 WHERE Device_ID = " & iDeviceID
                i = Me.GobjMisc.ExecuteNonQuery(strSql)

                strSql = "UPDATE tmessdata SET tmessdata.FCP_ID = 0 WHERE Device_ID = " & iDeviceID
                i = Me.GobjMisc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************************************************************
        'Public Function ResetCorrectCapCode(ByVal strCapCode As String, ByVal iModelID As Integer, ByVal strBaudRate As String) As String
        '    Dim strResult As String = ""
        '    Dim strS As String = ""
        '    Dim i As Integer

        '    Try
        '        strCapCode = strCapCode.Trim
        '        If Not strCapCode.Length > 0 Then Return ""

        '        If iModelID = 7 Then 'BF-Bravo FLX
        '            strS = strCapCode.Substring(0, 1)
        '            If [Char].IsLetter(strS) Then
        '                If strS.ToUpper = "A" Then
        '                    Return strCapCode
        '                Else
        '                    Return "A" & strCapCode.Substring(1, strCapCode.Length)
        '                End If
        '            Else

        '            End If
        '        End If

        '        Return strResult
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '*****************************************************************************************************************
        Public Function IsValidCapCode(ByVal strCapCode As String) As Boolean
            'Character at first position must be a letter A-Z,a-z, or no letter, rest must 0-9.
            'When character at first position is  no letter, each character of capcode must be 0-9.

            Dim strS As String = ""
            Dim strPart As String = ""
            Dim strSingle As String = ""

            Dim i, j, k As Integer

            Try
                strCapCode = strCapCode.Trim
                If Not strCapCode.Length > 0 Then Return False

                strS = strCapCode.Substring(0, 1) 'first position
                If [Char].IsLetter(strS) Then 'first one is letter
                    strPart = strCapCode.Substring(1, strCapCode.Length - 1)
                    If strPart.Length > 0 Then
                        For i = 0 To strPart.Length - 1
                            strSingle = strPart.Substring(i, 1)
                            If Not IsNumeric(strSingle) Then
                                Return False
                            End If
                        Next
                        Return True
                    Else
                        Return False
                    End If
                Else 'first one is not letter
                    strPart = strCapCode
                    If strPart.Length > 0 Then
                        For i = 0 To strPart.Length - 1
                            strSingle = strPart.Substring(i, 1)
                            If Not IsNumeric(strSingle) Then
                                Return False
                            End If
                        Next
                        Return True
                    Else
                        Return False
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function ResetCorrectCapCode(ByVal strCapCode As String, ByVal iModelID As Integer, _
                                            ByVal iBaudRate As Integer, ByVal strBaudRate As String) As String
            '1)If model is BF-Bravo FLX ( model_id = 7 ) then capcode must start with A
            '2)Else if baud rate is Flex then capcode must start with E
            '3)Else if baud rate is POCSAG … ( 240..512 ) then capcode must have no letter.

            Dim strResult As String = ""
            Dim strS As String = ""
            Dim i As Integer
            Dim bIsModelNumberOnly As Boolean = False
            Dim tmpArray() As String

            Try
                strCapCode = strCapCode.Trim : strBaudRate = strBaudRate.Trim

                If Not strCapCode.Length > 0 Then Return ""

                'get noletter model ids
                strS = ModManuf.GetExceptionCriteria("AMS_CAPCODE_NOLETTER", "ModelIDs").Trim
                tmpArray = Split(strS, ",")
                If tmpArray.Length > 0 Then
                    For i = 0 To tmpArray.Length - 1
                        If tmpArray(i) = iModelID Then bIsModelNumberOnly = True : Exit For
                    Next
                End If
                strS = ""

                'ready to go
                If iModelID = 7 Then 'BF-Bravo FLX
                    strS = strCapCode.Substring(0, 1)
                    If [Char].IsLetter(strS) Then
                        If strS.ToUpper = "A" Then
                            Return strCapCode
                        Else
                            Return "A" & strCapCode.Substring(1, strCapCode.Length - 1)
                        End If
                    Else
                        Return "A" & strCapCode
                    End If
                ElseIf bIsModelNumberOnly Then 'no letter,only number
                    strS = strCapCode.Substring(0, 1)
                    If [Char].IsLetter(strS) Then
                        Return strCapCode.Substring(1, strCapCode.Length - 1)
                    Else
                        Return strCapCode
                    End If
                ElseIf iBaudRate = 4 Then 'FLEX
                    strS = strCapCode.Substring(0, 1)
                    If [Char].IsLetter(strS) Then
                        If strS.ToUpper = "E" Then
                            Return strCapCode
                        Else
                            Return "E" & strCapCode.Substring(1, strCapCode.Length - 1)
                        End If
                    Else
                        Return "E" & strCapCode
                    End If
                ElseIf strBaudRate.Length >= 6 AndAlso strBaudRate.Substring(0, 6).ToUpper = "POCSAG" Then  'POCSAG
                    strS = strCapCode.Substring(0, 1)
                    If [Char].IsLetter(strS) Then
                        Return strCapCode.Substring(1, strCapCode.Length - 1)
                    Else
                        Return strCapCode
                    End If
                Else
                    Return strCapCode
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************************************************************
        Public Function GetDeviceInWip(ByVal strSN As String, Optional ByVal iCustID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT C.Model_Desc, E.freq_Number, F.baud_Number " & Environment.NewLine
                strSql &= " , B.* " & Environment.NewLine
                strSql &= " , A.* " & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tmessdata B on A.device_id = B.device_id" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C on A.model_ID = C.model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation D on A.Loc_ID = D.Loc_ID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN lfrequency E on B.Freq_ID = E.Freq_ID " & Environment.NewLine
                strSql &= " LEFT OUTER JOIN lbaud F on B.Baud_ID = F.Baud_ID " & Environment.NewLine
                strSql &= " WHERE A.device_SN ='" & strSN & "' AND A.device_DateShip is null " & Environment.NewLine
                If iCustID > 0 Then strSql &= " AND D.Cust_ID = " & iCustID & Environment.NewLine

                Return GobjMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function UpdateFreqBaudCap(ByVal iDeviceID As Integer, ByVal iFreqID As Integer, ByVal iBaudID As Integer, ByVal strCapCode As String, _
                                          ByVal iOldFreqID As Integer, ByVal iOldBaudID As Integer, ByVal strOldCapCode As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = "", strUpdVal As String = ""

            Try
                If iFreqID > 0 Then
                    strUpdVal = " Freq_ID =  " & iFreqID
                    If iOldFreqID > 0 Then strUpdVal &= ", freq_id_old = " & iOldFreqID & ", freq_id_change_userid = " & iUserID & ", freq_id_change_date = now() " & Environment.NewLine
                End If

                If strCapCode.Trim.Length > 0 Then
                    If strUpdVal.Trim.Length > 0 Then strUpdVal &= ", "
                    strUpdVal &= " capcode = '" & strCapCode & "'" & Environment.NewLine
                    If strOldCapCode.Trim.Length > 0 Then strUpdVal &= ", capcode_old = " & strOldCapCode & ", capcode_change_userid = " & iUserID & ", capcode_change_date = now() " & Environment.NewLine
                End If

                If iBaudID Then
                    If strUpdVal.Trim.Length > 0 Then strUpdVal &= ", "
                    strUpdVal &= " Baud_ID = " & iBaudID
                    If iOldBaudID > 0 Then strUpdVal &= ", baud_id_old = " & iOldBaudID & ", baud_id_change_userid = " & iUserID & ", baud_id_change_date = now() " & Environment.NewLine
                End If

                If strUpdVal.Trim.Length > 0 Then
                    strSql = "UPDATE tmessdata SET " & strUpdVal
                    strSql &= " WHERE Device_ID = " & iDeviceID & Environment.NewLine
                    Return GobjMisc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************

    End Class
End Namespace

