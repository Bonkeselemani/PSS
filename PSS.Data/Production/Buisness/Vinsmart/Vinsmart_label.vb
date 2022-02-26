Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports DBQuery.DataProc

Namespace Buisness.Vinsmart
    Public Class Vinsmart_label
        Private _objDataProc As DBQuery.DataProc

        'Private strRptPath As String = "C:\Cellular_Labels\"
        Private strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
        Private strRptName As String = ""

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
#End Region

        '******************************************************************
        Public Function GetSug(ByVal booAddSelectRow As Boolean, _
                                ByVal iModelID As Integer) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM llenssugdefault WHERE Model_ID = " & iModelID & " ORDER BY LensSUG_Text;"
                dt = _objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetManufCountry(ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lmanufcountry where mc_active = 1 ORDER BY mc_id;"
                dt = _objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetVinsmartDeviceInfoForLabel(ByVal strIMEI As String, _
                                                ByVal iCustID As Integer) As DataTable

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '*******************************************************
                'Get Device_ID from tdevice table
                '*******************************************************
                strsql = "select a.device_id, a.model_id, b.Manuf_ID, label_model_numb, label_model_numb2, label_fcc " & Environment.NewLine
                strsql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                strsql &= ", cellopt_msn, cellopt_CSN, cellopt_sugin, cellopt_softverin,CellOpt_SSID" & Environment.NewLine
                strsql &= ", BT_Addr, Prod_Code, P_No, HW_REV1, HW_REV2, Manuf_Date, mc_id, ManufProdSN, ManufSEQ, Label_Location,label_Bluetooth,Label_WebUIPassword " & Environment.NewLine
                strsql &= "from tdevice a  " & Environment.NewLine
                strsql &= "inner join tmodel b on a.model_id = b.model_id " & Environment.NewLine
                strsql &= "left outer join llabel c on c.model_id = b.model_id " & Environment.NewLine
                strsql &= "inner join tlocation d on a.loc_id = d.loc_id " & Environment.NewLine
                strsql &= "left outer join tcellopt e ON a.Device_ID = e.Device_ID " & Environment.NewLine
                strsql &= "inner join edi.titem f ON f.device_id = a.device_id " & Environment.NewLine
                strsql &= "where device_sn = '" & strIMEI & "' " & Environment.NewLine
                strsql &= "AND Device_DateShip is null  " & Environment.NewLine
                strsql &= "AND d.Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "order by device_id desc;"

                dt1 = _objDataProc.GetDataTable(strsql)

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetWiKoDeviceInfoForLabel(ByVal strIMEI As String, _
                                                  ByVal iCustID As Integer) As DataTable

            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                '*******************************************************
                'Get Device_ID from tdevice table
                '*******************************************************
                strIMEI = strIMEI.Replace("'", "''")
                strsql = "select a.device_id, a.model_id, b.Manuf_ID, label_model_numb, label_model_numb2, label_fcc" & Environment.NewLine
                strsql &= " , if(WorkStation is null, '', WorkStation) as WorkStation" & Environment.NewLine
                strsql &= " , cellopt_msn, cellopt_CSN, cellopt_sugin, cellopt_softverin,CellOpt_SSID" & Environment.NewLine
                strsql &= ", '' AS 'BT_Addr', '' AS 'Prod_Code', '' AS 'P_No', e.CellOpt_Member AS 'HW_REV1', e.CellOpt_APC AS 'HW_REV2', e.CellOpt_DateCode AS 'Manuf_Date'" & Environment.NewLine
                strsql &= " , e.SC_ID AS 'mc_id','' AS 'ManufProdSN', '' AS 'ManufSEQ', '' AS 'Label_Location','' AS 'label_Bluetooth','' AS 'Label_WebUIPassword'" & Environment.NewLine
                strsql &= " from tdevice a" & Environment.NewLine
                strsql &= " inner join tmodel b on a.model_id = b.model_id" & Environment.NewLine
                strsql &= " left outer join llabel c on c.model_id = b.model_id" & Environment.NewLine
                strsql &= " inner join tlocation d on a.loc_id = d.loc_id" & Environment.NewLine
                strsql &= " left outer join tcellopt e ON a.Device_ID = e.Device_ID" & Environment.NewLine
                strsql &= " where device_sn = '" & strIMEI & "'" & Environment.NewLine
                strsql &= " AND Device_DateShip is null" & Environment.NewLine
                strsql &= " AND d.Cust_ID = " & iCustID & Environment.NewLine
                strsql &= " order by device_id desc;" & Environment.NewLine

                dt1 = _objDataProc.GetDataTable(strsql)

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetVinsmartDeviceMadeInCountryIDForLabel(ByVal iModelID As Integer) As Integer

            Dim strsql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try

                strsql = "select a.device_ID,a.device_SN,b.Orderno,b.mc_ID" & Environment.NewLine
                strsql &= " from tdevice a" & Environment.NewLine
                strsql &= " inner join edi.titem b on a.device_ID=b.device_ID" & Environment.NewLine
                strsql &= " where a.model_ID=" & iModelID & " and b.mc_ID>0" & Environment.NewLine
                strsql &= " order by a.device_ID Desc" & Environment.NewLine
                strsql &= " limit 1;" & Environment.NewLine
                dt = _objDataProc.GetDataTable(strsql)

                If dt.Rows.Count > 0 Then
                    iRet = dt.Rows(0).Item("mc_ID")
                End If

                Return iRet

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function PrintLabel(ByVal strModel As String, _
                                   ByVal strIMEI As String, _
                                   ByVal strFCC As String, _
                                   ByVal strSNMSN As String, _
                                   ByVal strESN As String, _
                                   ByVal strMadein As String, _
                                   Optional ByVal strProdCode As String = "", _
                                   Optional ByVal strSjug As String = "", _
                                   Optional ByVal strPno As String = "", _
                                   Optional ByVal strTFModel As String = "", _
                                   Optional ByVal strSW As String = "", _
                                   Optional ByVal strbtAddr As String = "", _
                                   Optional ByVal strHW As String = "", _
                                   Optional ByVal strN As String = "", _
                                   Optional ByVal strDate As String = "", _
                                   Optional ByVal strManufProdSN As String = "", _
                                   Optional ByVal strSeq As String = "", _
                                   Optional ByVal strIMEI_HEX As String = "", _
                                   Optional ByVal strSSID As String = "", _
                                   Optional ByVal strLabelLoc As String = "", _
                                   Optional ByVal strMEIDHEX As String = "", _
                                   Optional ByVal strMEIDDEC As String = "", _
                                   Optional ByVal strIMEI_Alt As String = "", _
                                   Optional ByVal strBluetooth As String = "", _
                                   Optional ByVal strWebUIPassword As String = "") As Integer

            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable
            Dim dt1 As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim R1 As DataRow


            Try

                strsql = "Select Label_Name from lcustmodlbl a " & Environment.NewLine
                strsql &= "Inner Join tdevice b on b.model_id = a.model_id " & Environment.NewLine
                strsql &= "where device_sn = '" & strIMEI & "'; "

                dt1 = _objDataProc.GetDataTable(strsql)
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

                strRptName &= " Push.rpt"

                'strsql = "Select '" & strModel & "' AS Model_No, '" & strIMEI & "' AS IMEI, '" & strFCC & "' AS FCCID, " & Environment.NewLine
                'strsql &= " '" & strSNMSN & "' AS SNMSN, '" & strESN & "' as ESN, '" & strMadein & "' AS Country_Manuf, '" & strProdCode & "' AS Prod_Code, '" & strSjug & "' AS SugNumber, " & Environment.NewLine
                'strsql &= " '" & strIMEI & "' AS IMEIBar, '" & strSNMSN & "' AS SNMSNBar, '" & strPno & "' AS P_NoBar, " & Environment.NewLine
                'strsql &= " '" & strPno & "' AS P_No, '" & strTFModel & "' AS TFModel_No, '" & strSW & "' AS SW_No, " & Environment.NewLine
                'strsql &= " '" & strbtAddr & "' As BtAddr, '" & strDate & "' as Date, '" & strHW & "' As HW_REV, '" & strN & "' As N_No " & Environment.NewLine
                'strsql &= ", '" & strManufProdSN & "' as 'ManufProdSN' " & Environment.NewLine
                'strsql &= ", '" & strSeq & "' as 'SEQ', '" & strIMEI_HEX & "' as 'IMEI_HEX', '" & strSSID & "' as 'SSID',  '" & strLabelLoc & "' as 'lblLoc' " & Environment.NewLine
                'strsql &= ", '" & strMEIDHEX & "' as 'MEIDHEX', '" & strMEIDDEC & "' as 'MEIDDEC', '" & strIMEI_Alt & "' as 'IMEI_Alt', '" & strBluetooth & "' as 'lblBluetoothID','" & strWebUIPassword & "' as 'lblWebUIPassword'" & Environment.NewLine
                'strsql &= "from tdevice limit 1;"

                strsql = "Select '" & strModel & "' AS Model_No, '" & strIMEI & "' AS IMEI, '" & strFCC & "' AS FCCID, " & Environment.NewLine
                strsql &= " '" & strSNMSN & "' AS SNMSN, '" & strESN & "' as ESN, '" & strMadein & "' AS Country_Manuf, '" & strProdCode & "' AS Prod_Code, '" & strSjug & "' AS SugNumber, " & Environment.NewLine
                strsql &= " '" & strIMEI & "' AS IMEIBar, '" & strSNMSN & "' AS SNMSNBar, '" & strPno & "' AS P_NoBar, " & Environment.NewLine
                strsql &= " '" & strPno & "' AS P_No, '" & strTFModel & "' AS TFModel_No, '" & strSW & "' AS SW_No, " & Environment.NewLine
                strsql &= " '" & strbtAddr & "' As BtAddr, '" & strDate & "' as Date, '" & strHW & "' As HW_REV, '" & strN & "' As N_No " & Environment.NewLine
                strsql &= ", '" & strManufProdSN & "' as 'ManufProdSN' " & Environment.NewLine
                strsql &= ", '" & strSeq & "' as 'SEQ', '" & strIMEI_HEX & "' as 'IMEI_HEX', '" & strSSID & "' as 'SSID',  '" & strLabelLoc & "' as 'lblLoc' " & Environment.NewLine
                strsql &= ", '" & strMEIDHEX & "' as 'MEIDHEX', '" & strMEIDDEC & "' as 'MEIDDEC', '" & strIMEI_Alt & "' as 'IMEI_Alt', '" & strBluetooth & "' as 'lblBluetoothID','" & strWebUIPassword & "' as 'lblWebUIPassword'" & Environment.NewLine

                strsql &= ",'" & Decode128BarCode(strModel) & "' AS Model_No_BarCode, '" & Decode128BarCode(strIMEI) & "' AS IMEI_BarCode, '" & Decode128BarCode(strFCC) & "' AS FCCID_BarCode, " & Environment.NewLine
                strsql &= " '" & Decode128BarCode(strSNMSN) & "' AS SNMSN_BarCode, '" & Decode128BarCode(strESN) & "' as ESN_BarCode, '" & Decode128BarCode(strMadein) & "' AS Country_Manuf_BarCode, '" & Decode128BarCode(strProdCode) & "' AS Prod_Code_BarCode, '" & Decode128BarCode(strSjug) & "' AS SugNumber_BarCode, " & Environment.NewLine
                strsql &= " '" & Decode128BarCode(strIMEI) & "' AS IMEIBar_BarCode, '" & Decode128BarCode(strSNMSN) & "' AS SNMSNBar_BarCode, '" & Decode128BarCode(strPno) & "' AS P_NoBar_BarCode, " & Environment.NewLine
                strsql &= " '" & Decode128BarCode(strPno) & "' AS P_No_BarCode, '" & Decode128BarCode(strTFModel) & "' AS TFModel_No_BarCode, '" & Decode128BarCode(strSW) & "' AS SW_No_BarCode, " & Environment.NewLine
                strsql &= " '" & Decode128BarCode(strbtAddr) & "' As BtAddr_BarCode, '" & Decode128BarCode(strDate) & "' as Date_BarCode, '" & Decode128BarCode(strHW) & "' As HW_REV_BarCode, '" & Decode128BarCode(strN) & "' As N_No_BarCode " & Environment.NewLine
                strsql &= ", '" & Decode128BarCode(strManufProdSN) & "' as 'ManufProdSN_BarCode' " & Environment.NewLine
                strsql &= ", '" & Decode128BarCode(strSeq) & "' as 'SEQ_BarCode', '" & Decode128BarCode(strIMEI_HEX) & "' as 'IMEI_HEX_BarCode', '" & Decode128BarCode(strSSID) & "' as 'SSID_BarCode',  '" & Decode128BarCode(strLabelLoc) & "' as 'lblLoc_BarCode' " & Environment.NewLine
                strsql &= ", '" & Decode128BarCode(strMEIDHEX) & "' as 'MEIDHEX_BarCode', '" & Decode128BarCode(strMEIDDEC) & "' as 'MEIDDEC_BarCode', '" & Decode128BarCode(strIMEI_Alt) & "' as 'IMEI_Alt_BarCode', '" & Decode128BarCode(strBluetooth) & "' as 'lblBluetoothID_BarCode','" & Decode128BarCode(strWebUIPassword) & "' as 'lblWebUIPassword_BarCode'" & Environment.NewLine

                strsql &= "from tdevice limit 1;"

                objRpt = New ReportDocument()

                With objRpt
                    .Load(strRptPath & strRptName)
                    dt = _objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                        .SetDataSource(dt)
                        .PrintToPrinter(1, True, 0, 0)
                    Else
                        Throw New Exception("No label data! Printed nothing.")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Private Function Decode128BarCode(ByVal strS As String) As String
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
            Dim strRet As String = ""
            Try
                If strS.Trim.Length > 0 Then
                    strS = FontEncoder.Code128a(strS.Trim) 'encode
                    strRet = strS.Replace("'", "''").Replace("\", "\\") 'handle SQl reserved characters
                End If

                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateLabelTcell(ByVal iDeviceID As Integer, _
                                         ByVal strSNMSN As String, _
                                         ByVal iMadein As Integer, _
                                         Optional ByVal strProdCode As String = "", _
                                         Optional ByVal strSjug As String = "", _
                                         Optional ByVal strPno As String = "", _
                                         Optional ByVal strSW As String = "", _
                                         Optional ByVal strbtAddr As String = "", _
                                         Optional ByVal strHW As String = "", _
                                         Optional ByVal strN As String = "", _
                                         Optional ByVal strCSN As String = "", _
                                         Optional ByVal strManufProdSN As String = "", _
                                         Optional ByVal strManufSEQ As String = "", _
                                         Optional ByVal strSSID As String = "", _
                                         Optional ByVal strLabelLoc As String = "", _
                                         Optional ByVal strBluetooth As String = "", _
                                         Optional ByVal strWebUIPassword As String = "")

            Dim strSql As String = ""

            Try
                strSql = "UPDATE tcellopt, edi.titem " & Environment.NewLine
                strSql &= "SET mc_id = " & iMadein & Environment.NewLine
                If strSjug.Trim.Length > 0 Then strSql &= ", cellopt_sugin = '" & strSjug.ToUpper & "' " & Environment.NewLine
                If strSW.Trim.Length > 0 Then strSql &= ", cellopt_softverin = '" & strSW.ToUpper & "' " & Environment.NewLine
                If strSNMSN.Trim.Length > 0 Then strSql &= ", cellopt_msn = '" & strSNMSN.ToUpper & "' " & Environment.NewLine
                If strCSN.Trim.Length > 0 Then strSql &= ", CellOpt_CSN = '" & strCSN.ToUpper & "' " & Environment.NewLine
                If strProdCode.Trim.Length > 0 Then strSql &= ", Prod_Code = '" & strProdCode.ToUpper & "' " & Environment.NewLine
                If strPno.Trim.Length > 0 Then strSql &= ", P_No = '" & strPno.ToUpper & "' " & Environment.NewLine
                If strbtAddr.Trim.Length > 0 Then strSql &= ", BT_Addr = '" & strbtAddr.ToUpper & "' " & Environment.NewLine
                If strHW.Trim.Length > 0 Then strSql &= ", HW_REV1 = '" & strHW.ToUpper & "' " & Environment.NewLine
                If strN.Trim.Length > 0 Then strSql &= ", HW_REV2 = '" & strN.ToUpper & "' " & Environment.NewLine
                If strManufProdSN.Trim.Length > 0 Then strSql &= ", ManufProdSN = '" & strManufProdSN.ToUpper & "' " & Environment.NewLine
                If strManufSEQ.Trim.Length > 0 Then strSql &= ", ManufSEQ = '" & strManufSEQ.ToUpper & "' " & Environment.NewLine
                If strSSID.Trim.Length > 0 Then strSql &= ", CellOpt_SSID = '" & strSSID.ToUpper & "' " & Environment.NewLine
                If strLabelLoc.Trim.Length > 0 Then strSql &= ", Label_Location = '" & strLabelLoc.ToUpper & "' " & Environment.NewLine
                If strBluetooth.Trim.Length > 0 Then strSql &= ", label_Bluetooth= '" & strBluetooth.ToUpper & "' " & Environment.NewLine
                If strWebUIPassword.Trim.Length > 0 Then strSql &= ", Label_WebUIPassword= '" & strWebUIPassword.ToUpper & "' " & Environment.NewLine

                strSql &= "WHERE tcellopt.device_id = edi.titem.device_id " & Environment.NewLine
                strSql &= "AND tcellopt.device_id = " & iDeviceID & ";"
                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function UpdateVinsmartLabelTCellOpt(ByVal iDeviceID As Integer, _
                                                ByVal strManufDateCode As String, _
                                                ByVal iMadeIn As Integer, _
                                                ByVal strHW_REV1 As String, _
                                                ByVal strHW_REV2 As String)

            Dim strSql As String = ""

            'CellOpt_POP AS 'HW_REV1', e.CellOpt_APC  SC_ID

            Try
                strManufDateCode = strManufDateCode.Trim.Replace("'", "''")
                strHW_REV1 = strHW_REV1.Trim.Replace("'", "''")
                strHW_REV2 = strHW_REV2.Trim.Replace("'", "''")

                strSql = "UPDATE tcellopt" & Environment.NewLine
                strSql &= " SET CellOpt_DateCode ='" & strManufDateCode & "'" & Environment.NewLine
                strSql &= ", CellOpt_Member ='" & strHW_REV1 & "'" & Environment.NewLine
                strSql &= ", CellOpt_APC  ='" & strHW_REV2 & "'" & Environment.NewLine
                strSql &= ",SC_ID=" & iMadeIn & Environment.NewLine
                strSql &= "WHERE device_id = " & iDeviceID & ";"

                Return _objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetLabelPanel(ByVal iModelID As Integer) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM llabelsetuptracfone WHERE model_id = " & iModelID & ";"
                dt = _objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetIMEI_HEX(ByVal strIMEI As String) As String
            Dim strResult As String = ""
            Dim strSql As String = ""
            Dim dt As DataTable, row As DataRow
            Dim strS1, strS2 As String

            Try
                strSql &= "select '" & strIMEI & "' as IMEI" & Environment.NewLine
                strSql &= ",cast(substring('" & strIMEI & "',1,10) as signed) as Part1_N" & Environment.NewLine
                strSql &= ",cast(substring('" & strIMEI & "',11,8) as signed) as Part2_N" & Environment.NewLine
                strSql &= ",if(length(trim('" & strIMEI & "'))=18,HEX(cast(substring('" & strIMEI & "',1,10) as signed)),'') as SN_Hex1" & Environment.NewLine
                strSql &= ",if(length(trim('" & strIMEI & "'))=18,HEX(cast(substring('" & strIMEI & "',11,8) as signed)),'') as SN_Hex2" & Environment.NewLine
                strSql &= ",if(length(trim('" & strIMEI & "'))=18,concat(HEX(cast(substring('" & strIMEI & "',1,10) as signed))," & Environment.NewLine
                strSql &= "                                      LPAD(HEX(cast(substring('" & strIMEI & "',11,8) as signed)),6,'0')" & Environment.NewLine
                strSql &= "                                     ),'') as SN_Hex_Final;" & Environment.NewLine

                dt = _objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows 'it should 1 row
                        If row.IsNull("SN_Hex1") Or row.IsNull("SN_Hex1") Then
                            strResult = ""
                        Else
                            strS1 = row("SN_Hex1") : strS2 = row("SN_Hex2")
                            If strS1.Trim.Length > 0 AndAlso strS2.Trim.Length > 0 Then
                                strResult = row("SN_Hex_Final")
                            Else
                                strResult = ""
                            End If
                        End If
                        Exit For
                    Next
                End If

                Return strResult

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetMEIDHEXDEC_IMEIAlt(ByVal strIMEI As String, _
                                                     Optional ByRef strMEIDHEX As String = "", _
                                                     Optional ByRef strMEIDDEC As String = "", _
                                                     Optional ByRef strIMEI_Alt As String = "") As Boolean
            Dim bResult As Boolean = False
            Dim strSql As String = ""
            Dim dt As DataTable, row As DataRow
            Dim strS1, strS2, strS3 As String

            Try
                strSql = "SELECT '" & strIMEI & "' AS 'IMEI'" & Environment.NewLine
                strSql &= " ,IF (Length(Trim('" & strIMEI & "'))=15" & Environment.NewLine
                strSql &= " ,CONCAT_WS('-',substring(trim('" & strIMEI & "'),1,6),substring(trim('" & strIMEI & "'),7,2)" & Environment.NewLine
                strSql &= " ,substring(trim('" & strIMEI & "'),9,6),substring(trim('" & strIMEI & "'),15,1)),'') AS 'IMEI_Alt'" & Environment.NewLine
                strSql &= " ,IF (Length(Trim('" & strIMEI & "'))=15,substring(trim('" & strIMEI & "'),1,14),'') AS 'MEID HEX'" & Environment.NewLine
                strSql &= " ,IF(length(trim('" & strIMEI & "'))=15" & Environment.NewLine
                strSql &= " ,IF(Length(CONV(substring(trim('" & strIMEI & "'),1,8),16,10))<10" & Environment.NewLine
                strSql &= " ,LPAD(CONV(substring(trim('" & strIMEI & "'),1,8),16,10),10,'0')" & Environment.NewLine
                strSql &= " ,CONV(substring(trim('" & strIMEI & "'),1,8),16,10))" & Environment.NewLine
                strSql &= " ,'') AS 'FirstPart'" & Environment.NewLine
                strSql &= " ,IF(length(trim('" & strIMEI & "'))=15" & Environment.NewLine
                strSql &= " ,IF(Length(CONV(substring(trim('" & strIMEI & "'),9,6),16,10))<8" & Environment.NewLine
                strSql &= " ,LPAD(CONV(substring(trim('" & strIMEI & "'),9,6),16,10),8,'0')" & Environment.NewLine
                strSql &= " ,CONV(substring(trim('" & strIMEI & "'),9,6),16,10))" & Environment.NewLine
                strSql &= " ,'') AS 'SecoondPart'" & Environment.NewLine
                strSql &= " ,CONCAT(IF(length(trim('" & strIMEI & "'))=15" & Environment.NewLine
                strSql &= " ,IF(Length(CONV(substring(trim('" & strIMEI & "'),1,8),16,10))<10" & Environment.NewLine
                strSql &= " ,LPAD(CONV(substring(trim('" & strIMEI & "'),1,8),16,10),10,'0')" & Environment.NewLine
                strSql &= " ,CONV(substring(trim('" & strIMEI & "'),1,8),16,10))" & Environment.NewLine
                strSql &= " ,'')" & Environment.NewLine
                strSql &= " ,IF(length(trim('" & strIMEI & "'))=15" & Environment.NewLine
                strSql &= " ,IF(Length(CONV(substring(trim('" & strIMEI & "'),9,6),16,10))<8" & Environment.NewLine
                strSql &= " ,LPAD(CONV(substring(trim('" & strIMEI & "'),9,6),16,10),8,'0')" & Environment.NewLine
                strSql &= " ,CONV(substring(trim('" & strIMEI & "'),9,6),16,10))" & Environment.NewLine
                strSql &= " ,''))AS 'MEID DEC';" & Environment.NewLine

                dt = _objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows 'it should 1 row
                        If row.IsNull("IMEI_Alt") Or row.IsNull("MEID HEX") Or row.IsNull("MEID DEC") Then
                            bResult = False
                            strMEIDHEX = "" : strMEIDDEC = "" : strIMEI_Alt = ""
                        Else
                            strS1 = row("MEID HEX") : strS2 = row("MEID DEC") : strS3 = row("IMEI_Alt")
                            If strS1.Trim.Length > 0 AndAlso strS2.Trim.Length > 0 AndAlso strS3.Trim.Length > 0 Then
                                bResult = True
                                strMEIDHEX = strS1.Trim : strMEIDDEC = strS2.Trim : strIMEI_Alt = strS3.Trim
                            Else
                                bResult = False
                                strMEIDHEX = "" : strMEIDDEC = "" : strIMEI_Alt = ""
                            End If
                        End If
                        Exit For
                    Next
                End If

                Return bResult

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function getUnshippedDeviceData(ByVal strIMEI As String) As DataTable
            Dim strSql As String = ""

            Try
                strIMEI = strIMEI.Replace("'", "''")
                strSql = "select * from production.tdevice where Device_DateShip is null And device_SN ='" & strIMEI & "';" & Environment.NewLine

                Return _objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function RemoveLabelInfo(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "Update edi.titem set Manuf_Date='',label_Location =null, Label_Bluetooth =null, Label_WebUIPassword=null where device_ID = " & iDevice_ID & ";"
                i = _objDataProc.ExecuteNonQuery(strSql)

                strSql = "Update production.tcellopt set Cellopt_MSN=null, cellopt_DateCode ='' where device_ID= " & iDevice_ID & ";"
                i += _objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace