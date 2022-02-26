Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_BuildBox
        Private _objDataProc As DBQuery.DataProc

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
        Public Function GetVivintLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Loc_ID,Loc_Name from production.tlocation WHere Cust_ID=" & iCust_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDevicePretest(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM  tpretest_data A " & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.device_id=B.device_id " & Environment.NewLine
                strSql &= " WHERE A.Device_ID =" & iDevice_ID & " and device_DateShip is null;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable


            Try
                strSql = "Select * from tmodel where prodGrp_ID=204 and prod_ID=75  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintShipBoxTypes(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim drNewRow As DataRow

            Try
                strSql = "SELECT 0 as 'ShipTypeID', 'REF' as 'ShipTypeSDesc', 'REFURBISHED' as 'ShipTypeLDesc' " & Environment.NewLine
                strSql &= "UNION ALL SELECT 1 as 'ShipTypeID', 'BER' as 'ShipTypeSDesc', 'BER' as 'ShipTypeLDesc'"
                strSql &= "UNION ALL SELECT 2 as 'ShipTypeID', 'RTV' as 'ShipTypeSDesc', 'RTV' as 'ShipTypeLDesc'"
                strSql &= "UNION ALL SELECT 3 as 'ShipTypeID', 'SCR' as 'ShipTypeSDesc', 'SCRAP' as 'ShipTypeLDesc'"

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {9999, "--Select--", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                drNewRow = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetVivintpenPallets(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, tpallett.Loc_ID, Pallet_ShipType, if(Pallett_QTY is null,0,Pallett_QTY) as Pallett_QTY,Pallett_Name as 'Box Name', tlocation.Loc_Name as Location, Model_Desc as Model" & Environment.NewLine
                strSql &= " FROM tpallett" & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation ON tpallett.Loc_ID=tlocation.Loc_ID AND tpallett.Cust_ID=tlocation.Cust_ID" & Environment.NewLine
                strSql &= " WHERE tpallett.cust_ID = " & iCust_ID & Environment.NewLine
                strSql &= " AND Pallett_ReadyToShipFlg = 0" & Environment.NewLine
                strSql &= " AND tpallett.Loc_ID =  " & iLoc_ID & Environment.NewLine
                strSql &= " AND Pallet_Invalid = 0" & Environment.NewLine
                strSql &= " Order by Pallett_id Desc" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetVivintPallettData(ByVal strPallettName As String, ByVal iCust_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim row As DataRow
            Dim strSql As String = ""
            Try
                strPallettName = strPallettName.Replace("'", "''")
                strSql = "SELECT *  FROM tpallett WHERE cust_ID =" & iCust_ID & " AND Pallett_Name = '" & strPallettName & "'"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ReopenVivintBoxByResetting(ByVal iPalletID As Integer, ByVal strStation As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tpallett, tcellopt "
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= ", tcellopt.WorkStation = '" & strStation & "', tcellopt.WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tcellopt.Device_ID AND tpallett.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is   NULL  " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 1;"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateBoxID(ByVal iModelID As Integer, _
                                           ByVal iBoxType As Integer, _
                                           ByVal strPalletPrefix As String, _
                                           ByVal iCust_ID As Integer, _
                                           ByVal iLoc_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim iMaxNum As Integer = 0
            Dim dt As DataTable
            Try
                If iLoc_ID = PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID Or iLoc_ID = PSS.Data.Buisness.VV.Vivint.Vivint_VBP1_Loc_ID Then
                    '******************************
                    'construct pallet name
                    '******************************
                    strDate = Generic.GetMySqlDateTime("%y%m%d")

                    strPalletPrefix = iLoc_ID.ToString("D5") & strPalletPrefix & strDate & "N"

                    strPalletName = Me.DefinePalletName(strPalletPrefix, iMaxNum, iCust_ID)

                    'check max number palletts
                    If iMaxNum <= 0 Then Throw New Exception("Max box N### must be >0." & Environment.NewLine)
                    If iMaxNum > 999 Then Throw New Exception("Max pallets (per location per day) hit the 999 limit." & Environment.NewLine)
                    If strPalletName.Trim.Length = 0 Then Throw New Exception("Pallet name is nothing." & Environment.NewLine)

                    '******************************
                    'check for duplicate pallet
                    '******************************
                    strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLoc_ID & " and Cust_ID=" & iCust_ID
                    If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                End If
                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Pallett_Name " & Environment.NewLine
                'strSql &= ", SW_Version " & Environment.NewLine
                strSql &= ", Pallet_ShipType " & Environment.NewLine
                strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", " & iBoxType & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iCust_ID & " " & Environment.NewLine
                strSql &= ", " & iLoc_ID & ");" & Environment.NewLine
                iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")
                If iPalletID = 0 Then 'try get it again
                    strSql = "Select Pallett_ID From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLoc_ID & " and Cust_ID=" & iCust_ID
                    iPalletID = Me._objDataProc.GetIntValue(strSql)
                End If
                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Function DefinePalletName(ByVal strPalletPrefix As String, ByRef iMaxNum As Integer, ByVal iCust_ID As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix
            Try
                'up to 999
                strSQL = "SELECT  if(max(right(Trim(Pallett_Name), 3) ) is null,1,max(right(Trim(Pallett_Name),3) ) + 1) as  Pallett_Num" & Environment.NewLine
                strSQL &= " , if(max(right(Trim(Pallett_Name), 3) ) is null,CONCAT('" & strPalletPrefix & "', lPad(1,3,'0')) ,CONCAT( '" & strPalletPrefix & "', lPad(max(right(Trim(Pallett_Name),3) ) + 1, 3,'0'))) as  Pallett_Name" & Environment.NewLine
                strSQL &= " FROM production.tpallett" & Environment.NewLine
                strSQL &= " WHERE Pallett_Name like '" & strPalletPrefix & "%'  AND Cust_ID=" & iCust_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                iMaxNum = 0
                If dt.Rows.Count > 0 Then
                    iMaxNum = dt.Rows(0)("Pallett_Num") : strPallett_Name = dt.Rows(0)("Pallett_Name")
                End If
                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function


        Public Function GetAllSNsForPallet(ByVal iPalletID As Integer, _
                                      Optional ByVal strDevice_SN As String = "" _
                                      ) As DataTable
            Dim strSql As String
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
        Public Function RemoveSNfromPallet(ByVal iPallett_ID As Integer, ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update tdevice set Pallett_ID = NULL,device_DateShip=NULL, WO_ID_Out = NULL where pallett_id = " & iPallett_ID.ToString & " and device_id = " & iDevice_ID.ToString
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceInfoInWIP(ByVal strSN As String, ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSN = strSN.Replace("'", "''")

                strSql = "SELECT tdevice.*,tlocation.Loc_Name" & Environment.NewLine
                strSql &= " , if(WorkStation is null, '', WorkStation) as WorkStation" & Environment.NewLine
                strSql &= " FROM tdevice" & Environment.NewLine
                strSql &= " INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= " WHERE Device_SN = '" & strSN & "'" & Environment.NewLine
                strSql &= " AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip  = '')" & Environment.NewLine
                strSql &= " AND tdevice.Loc_ID = " & iLoc_ID

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CheckKitting(ByVal strSN As String, ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try


                strSql = "SELECT A.device_id from tdevice_kittingbill  A   " & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.device_id=B.device_id" & Environment.NewLine
                strSql &= "WHERE device_SN='" & strSN & "' AND B.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOEMCustomerClass(ByVal iDevice_ID As Integer, ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""
            Try
                strSql = "Select ShipTo_Name from production.extendedwarranty Where Cust_ID=" & iCust_ID & " And Loc_ID=" & iLoc_ID & " And Device_ID =" & iDevice_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("ShipTo_Name") Then
                    strRet = dt.Rows(0).Item("ShipTo_Name")
                    strRet = strRet.Trim
                End If
                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivintScrapBillCode() As DataTable
            Dim strSql As String = ""
            Dim iProduct_id As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_Product_ID
            Try
                strSql = "SELECT Billcode_id FROM lbillcodes A" & Environment.NewLine
                strSql &= "INNER  JOIN lbillrule B ON A.BillCode_Rule = B.BillRule_ID " & Environment.NewLine
                strSql &= "where device_id=" & iProduct_id & " AND BillRule_ID=1 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVivint_RTV_BILLCODEID(ByVal BillCode_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As New DataTable()
            Try

                strSql = "SELECT BillCodeIDs FROM production.exceptioncriteria  WHERE Description='VIVINT_RTV_BILLCODEID_LIST'" & Environment.NewLine
                strSql &= " AND BillCodeIDs=" & BillCode_ID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Return True
                Else : Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceBillData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try

                strSql = "SELECT A.*, B.BillCode_Desc" & Environment.NewLine
                strSql &= " , B.BillCode_Rule" & Environment.NewLine
                strSql &= " FROM tdevicebill A" & Environment.NewLine
                strSql &= " INNER JOIN lBillCodes B ON A.BillCode_ID=B.BillCode_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_ID =" & iDevice_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceFqaData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                'FQA:   QCType_ID=2, Pass: QCResult_ID=1
                strSql = "SELECT * FROM tqc WHERE QCType_ID =2 AND Device_ID=" & iDevice_ID & " ORDER BY QC_Date DESC;"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceRfTestData(ByVal strDevice_SN As String) As DataTable
            Dim strSql As String = ""
            Try

                strDevice_SN = strDevice_SN.Replace("'", "''")
                'RF Test  Pass: TestTResult ='Pass'
                strSql = "SELECT * FROM tdevice_test WHERE TestType='RF Test' AND Device_SN='" & strDevice_SN & "' ORDER BY TestDateTime DESC, mSecond DESC;"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceFlashTestData(ByVal strDevice_SN As String) As DataTable
            Dim strSql As String = ""
            Try

                strDevice_SN = strDevice_SN.Replace("'", "''")
                'Flash Test  Pass: TestTResult ='Pass'
                strSql = "SELECT * FROM tdevice_test WHERE TestType='Flash' AND Device_SN='" & strDevice_SN & "' ORDER BY TestDateTime DESC, mSecond DESC;"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CloseVivintPallet(ByVal iCust_ID As Integer, _
                                                      ByVal iPallet_ID As Integer, _
                                                      ByVal strpalletName As String, _
                                                      ByVal iPalletQty As Integer, _
                                                      ByVal iPalletShipType As Integer, _
                                                      Optional ByVal iPrtLicensePlateQty As Integer = 0, _
                                                      Optional ByVal strManifestRptTitle As String = "") As Integer

            Dim strRptFilePath As String = String.Empty
            Dim booPrtPalletManifest As Boolean = False
            Dim strSql As String = ""

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

                strSql = "update tpallett set   Pallett_QTY = " & iPalletQty & " ,tpallett.Pallett_ReadyToShipFlg = 1, AQL_QCResult_ID = 0 where pallett_id = " & iPallet_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PrintBoxLabel(ByVal iPalletID As Integer) As Integer
            Dim strReportName As String = "Vivivnt_BuildBox.rpt"
            Dim strSql As String
            Dim dt As DataTable
            Dim dtLabel As New DataTable()
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 10
            Dim rowNew As DataRow
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0

            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                strSql = "SELECT ShippedModel as partNumber,pallett_name as pallettname,pallett_name as pallettnameCode, ShippedModel as partNumberCode ,ShippedModel_Desc as description,A.Pallett_Qty as qty,(A.Pallett_Qty) AS qtyCode , DATE_FORMAT(CAST(pallet_timestamp as DATE),'%m/%d/%Y') as dateMFG" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON B.Model_ID=A.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID =" & iPalletID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dtLabel.Columns.Add("partNumber", GetType(String))
                dtLabel.Columns.Add("partNumberCode", GetType(String))
                dtLabel.Columns.Add("pallettname", GetType(String))
                dtLabel.Columns.Add("pallettnameCode", GetType(String))
                dtLabel.Columns.Add("description", GetType(String))
                dtLabel.Columns.Add("qty", GetType(String))
                dtLabel.Columns.Add("qtyCode", GetType(String))
                dtLabel.Columns.Add("dateMFG", GetType(String))
                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        rowNew = dtLabel.NewRow()
                        strS = dt.Rows(0).Item("pallettnameCode")
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("pallettnameCode") = strS
                        strS = dt.Rows(0).Item("qtyCode")
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("qtyCode") = strS
                        strS = dt.Rows(0).Item("partNumberCode")
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("partNumberCode") = strS
                        rowNew("partNumber") = ReplaceChar(dt.Rows(0).Item("partNumber"))
                        rowNew("qty") = ReplaceChar(dt.Rows(0).Item("qty"))
                        rowNew("description") = ReplaceChar(dt.Rows(0).Item("description"))
                        rowNew("dateMFG") = ReplaceChar(dt.Rows(0).Item("dateMFG"))
                        rowNew("pallettname") = ReplaceChar(dt.Rows(0).Item("pallettname"))
                        dtLabel.Rows.Add(rowNew)
                        dtLabel.AcceptChanges()
                    End If
                Next
                'Print

                If dt.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, 1)
                    Return dt.Rows.Count
                Else
                    Return dt.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CheckOpenPallet(ByVal Pallett_name As String) As DataTable
            Dim strSql As String
            Dim iRowNumber As Integer
            Try
                strSql = "SELECT * from tpallett Where Pallett_ReadyToShipFlg = 1 and Pallett_Name='" & Pallett_name & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ReplaceChar(ByVal strS As String) As String
            Try
                strS.Trim()
                strS.Replace("'", "''").Replace("\", "\\")

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AssignDeviceToPallet(ByVal iDeviceID As Integer, _
                                                   ByVal iPalletID As Integer, _
                                                   ByVal strDatetime As String) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "UPDATE tdevice " & Environment.NewLine
                strSql &= "SET pallett_id = " & iPalletID.ToString & Environment.NewLine
                strSql &= "WHERE device_ID = " & iDeviceID.ToString
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function
    End Class
End Namespace