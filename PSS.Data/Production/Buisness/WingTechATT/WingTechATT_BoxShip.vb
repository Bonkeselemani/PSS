Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WingTechATT
    Public Class WingTechATT_BoxShip
        Private _objDataProc As DBQuery.DataProc

        Private Declare Function IDAutomation_Universal_C128 _
                 Lib "IDAutomationNativeFontEncoder.dll" _
                (ByVal D2E As String, ByRef tilde As Long, _
                 ByVal out As String, _
                 ByRef iSize As Long) As Long

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
        Public Function GetWingTechATTShipBoxTypes(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim drNewRow As DataRow

            Try
                strSql = "SELECT 0 as 'ShipTypeID', 'REF' as 'ShipTypeSDesc', 'REFURBISHED' as 'ShipTypeLDesc' " & Environment.NewLine
                strSql &= "UNION ALL SELECT 1 as 'ShipTypeID', 'BER' as 'ShipTypeSDesc', 'BER' as 'ShipTypeLDesc'"
                strSql &= "UNION ALL SELECT 2 as 'ShipTypeID', 'RUR' as 'ShipTypeSDesc', 'RUR' as 'ShipTypeLDesc'"
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
        Public Function GetSwappedStatus(ByVal strImei As String, ByVal iCust_Id As Integer) As Integer
            Dim dtrow As DataRow
            Dim strSql As String = ""
            Dim orderType As Integer
            Dim dt As DataTable
            Try
                strSql = "SELECT A.swapped_device_id " & Environment.NewLine
                strSql &= "FROM extendedwarranty A" & Environment.NewLine
                strSql &= "INNER JOIN tdevice B ON A.device_id=B.Device_id" & Environment.NewLine
                strSql &= " where A.SerialNo = '" & strImei & "' AND A.cust_id= " & iCust_Id & "" & Environment.NewLine
                strSql &= " and B.Device_DateShip is null " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)("swapped_device_id")
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetPO(ByVal iDevice_id As Integer, ByVal iAccount As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT ClaimNo  FROM extendedwarranty " & Environment.NewLine
                If iAccount = 1 Then
                    strSql &= "where  swapped_Device_id =" & iDevice_id & "   " & Environment.NewLine
                ElseIf iAccount = 0 Then
                    strSql &= "where  device_id=" & iDevice_id & "  " & Environment.NewLine
                End If
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetAccount(ByVal strImei As String, ByVal iCust_Id As Integer) As Integer
            Dim dtrow As DataRow
            Dim strSql As String = ""
            Dim orderType As Integer
            Dim dt As DataTable
            Try
                strSql = "SELECT Account " & Environment.NewLine
                strSql &= "FROM extendedwarranty A,tdevice  B" & Environment.NewLine
                strSql &= " where SerialNo = '" & strImei & "' AND cust_id= " & iCust_Id & " AND A.device_id=B.Device_id and Device_DateShip is null and account in ('ATT','Cricket')" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetWingTechATTLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
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
        Public Function GettDeviceBill(ByVal Imei As String) As DataTable

            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql &= "SELECT  BillCode_id,tdevice.device_id " & Environment.NewLine
                strSql &= " FROM tdevice,tDeviceBill  " & Environment.NewLine
                strSql &= " where tdevice.device_SN = '" & Imei & "' and tdevice.device_id = tDeviceBill.device_id AND device_dateship  IS NULL;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function GetWingTechATTLocationsbyID(ByVal iCust_ID As Integer, ByVal strIMEI As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Loc_ID,ClaimNo from extendedwarranty WHere serialNo='" & strIMEI & "' and cust_id=" & iCust_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateWingTechATTPalletLocation(ByVal iLoc_ID As Integer, ByVal iPallett_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = " UPDATE tpallett SET loc_id=" & iLoc_ID & " WHERE pallett_id=" & iPallett_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWingTechATTModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Distinct A.Model_ID,C.Model_Desc" & Environment.NewLine
                strSql &= " From  production.tdevice A" & Environment.NewLine
                strSql &= " Inner Join production.tlocation B ON A.Loc_ID=B.Loc_ID AND B.Cust_ID=" & iCust_ID & Environment.NewLine
                strSql &= " Inner Join production.tmodel C  ON A.Model_ID=C.Model_ID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateBoxID(ByVal iModelID As Integer, _
                                    ByVal iBoxType As Integer, _
                                    ByVal strPalletPrefix As String, _
                                    ByVal iCust_ID As Integer, _
                                    ByVal iLoc_ID As String, _
                                    ByVal strSW_Version As String) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim iMaxNum As Integer = 0
            Dim dt As DataTable
            Dim strTempLoc_id As String
            Try
                If iLoc_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                    '******************************
                    'construct pallet name
                    '******************************
                    strDate = Generic.GetMySqlDateTime("%y%m%d")

                    strPalletPrefix = iLoc_ID.ToString & strPalletPrefix & strDate & "N"

                    strPalletName = Me.DefinePalletName(strPalletPrefix, iMaxNum, iCust_ID)

                    'check max number palletts
                    If iMaxNum <= 0 Then Throw New Exception("Max box N### must be >0." & Environment.NewLine)
                    If iMaxNum > 999 Then Throw New Exception("Max pallets (per location per day) hit the 999 limit." & Environment.NewLine)
                    If strPalletName.Trim.Length = 0 Then Throw New Exception("Pallet name is nothing." & Environment.NewLine)

                    '******************************
                    'check for duplicate pallet
                    '******************************
                    strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID IN ( " & iLoc_ID & ") and Cust_ID=" & iCust_ID
                    If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                Else
                    Dim strPalletnameprefix As String = String.Empty

                    Dim strPalletPostFix As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_Box_Postfix
                    Dim strDatePallet As String = Generic.GetMySqlDateTime("%d%m%Y")
                    strPalletnameprefix = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_Box_Prefix & strPalletPrefix & strDatePallet & "W"
                    Dim iPalletNameLen As Integer = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_BoxName_Len
                    Dim iFixLen As Integer = strPalletPrefix.Length + strPalletPostFix.Length
                    Dim iDefault As Integer = 1
                    Dim iMaxExistNum As Int32 = 0


                    strSql = "SELECT MAX(REPLACE(REPLACE(A.Pallett_Name,'" & strPalletnameprefix & "',''),'" & strPalletPostFix & "' ,'')) AS 'MaxNum'" & Environment.NewLine
                    strSql &= " FROM tPallett A WHERE A.Pallett_Name like '" & strPalletnameprefix & "%' and Loc_id IN (" & iLoc_ID & ") AND A.Cust_ID=" & iCust_ID & " ;" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count = 0 Or dt.Rows(0).IsNull("MaxNum") Then

                        strPalletName = strPalletnameprefix & iDefault.ToString().PadLeft(2, "0") & strPalletPostFix
                    Else
                        If Not dt.Rows(0).IsNull("MaxNum") AndAlso IsNumeric(dt.Rows(0).Item("MaxNum")) Then
                            iMaxExistNum = Convert.ToInt32(dt.Rows(0).Item("MaxNum")) + 1
                            strPalletName = strPalletnameprefix & iMaxExistNum.ToString().PadLeft(2, "0") & strPalletPostFix
                        End If
                    End If
                    If Not strPalletName.Trim.Length = iPalletNameLen Then Throw New Exception("Pallet name doesn't contain 20 characters total.")
                    strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "'   and Loc_id IN (" & iLoc_ID & ") and Cust_ID=" & iCust_ID
                    If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                End If

                If Not iLoc_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                    strTempLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID
                Else
                    strTempLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                End If
                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Pallett_Name " & Environment.NewLine
                strSql &= ", SW_Version " & Environment.NewLine
                strSql &= ", Pallet_ShipType " & Environment.NewLine
                strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", '" & strSW_Version & "' " & Environment.NewLine
                strSql &= ", " & iBoxType & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iCust_ID & " " & Environment.NewLine
                strSql &= ", " & strTempLoc_id & ");" & Environment.NewLine
                iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then 'try get it again
                    strSql = "Select Pallett_ID From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID in ( " & iLoc_ID & " ) and Cust_ID=" & iCust_ID
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

        Public Function GetWingTechATTOpenPallets(ByVal iCust_ID As Integer, ByVal iLoc_ID As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, tpallett.Loc_ID, Pallet_ShipType, if(Pallett_QTY is null,0,Pallett_QTY) as Pallett_QTY,Pallett_Name as 'Box Name',IF (tpallett.Loc_ID=4493,tlocation.Loc_Name,'ATT ') as Location, Model_Desc as Model" & Environment.NewLine
                strSql &= " FROM tpallett" & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation ON tpallett.Loc_ID=tlocation.Loc_ID AND tpallett.Cust_ID=tlocation.Cust_ID" & Environment.NewLine
                strSql &= " WHERE tpallett.cust_ID = " & iCust_ID & Environment.NewLine
                strSql &= " AND Pallett_ReadyToShipFlg = 0" & Environment.NewLine
                strSql &= " AND tpallett.Loc_ID in (  " & iLoc_ID & " ) " & Environment.NewLine
                strSql &= " AND Pallet_Invalid = 0" & Environment.NewLine
                strSql &= " Order by Pallett_id Desc" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
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

        Public Function GetDeviceInfoInWIP(ByVal strSN As String, ByVal strLoc_ID As String) As DataTable
            Dim strSql As String = ""
            Try
                strSN = strSN.Replace("'", "''")

                strSql = "SELECT tdevice.*,tlocation.Loc_Name  " & Environment.NewLine
                strSql &= " , if(WorkStation is null, '', WorkStation) as WorkStation" & Environment.NewLine
                strSql &= " FROM tdevice" & Environment.NewLine
                strSql &= " INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= " WHERE Device_SN = '" & strSN & "'" & Environment.NewLine
                strSql &= " AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip  = '')" & Environment.NewLine
                strSql &= " AND tdevice.Loc_ID in ( " & strLoc_ID & ")" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceId(ByVal strImei As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow
            Dim Device_ID As Integer
            Try
                strSql = "SELECT device_id FROM tdevice " & Environment.NewLine
                strSql &= "where  device_SN='" & strImei & "' and Device_DateShip is null " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each dtrow In dt.Rows
                    Device_ID = dtrow("device_id")
                Next
                Return Device_ID

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
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
                strSql = "SELECT A.* FROM tdevice_test A " & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.device_SN=B.device_SN " & Environment.NewLine
                strSql &= "WHERE TestType='RF Test' AND B.Device_SN='" & strDevice_SN & "' and isManual=1 and Device_DateShip is null  ORDER BY TestDateTime DESC, mSecond DESC;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

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
                'strSql &= ", Device_DateShip='" & strDatetime & "'" & Environment.NewLine
                strSql &= "WHERE device_ID = " & iDeviceID.ToString
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Function GetDeviceSIMcard(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM production.tworkorder A " & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WO_ID =B.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items C ON B.WR_ID=C.WR_ID" & Environment.NewLine
                strSql &= " WHERE B.Cust_ID=2631 AND B.LOC_ID=4496 and Device_ID =" & iDevice_ID & " ;" & Environment.NewLine
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
                strSql = "SELECT tdevice_test.* FROM tdevice_test   " & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON tdevice_test.device_SN=B.device_SN " & Environment.NewLine
                strSql &= "WHERE TestType='Flash' AND B.Device_SN='" & strDevice_SN & "' and isManual=0 and Device_DateShip is null  ORDER BY TestDateTime DESC, mSecond DESC;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceFlashManual(ByVal strDevice_SN As String) As DataTable
            Dim strSql As String = ""
            Try

                strDevice_SN = strDevice_SN.Replace("'", "''")
                'Flash Test  Pass: TestTResult ='Pass'
                strSql = "SELECT tdevice_test.* FROM tdevice_test  " & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON tdevice_test.device_SN=B.device_SN " & Environment.NewLine
                strSql &= "WHERE TestType='Flash' AND B.Device_SN='" & strDevice_SN & "' and isManual=1 and Device_DateShip is null  ORDER BY TestDateTime DESC, mSecond DESC;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CloseWingTechATTPallet(ByVal iCust_ID As Integer, _
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

                'STEP 1:: 
                'Select Case iCust_ID
                '    Case 2019  'ATCLE-AWS
                '        CreateExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2113   'Brightpoint
                '        CreateCellstarExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2219   'Gamestop
                '        CreateGamestopExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2238   'Trimble Mobile Solutions
                '        CreateTrimbleExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2245   'Liquidity Services/Dyscern
                '        CreateDyscernExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2242, 2259, 2278  'Sonitrol, 'PSS Exchange
                '        CreateSonitrolExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2249   'Demo customer
                '        CreateExcelFile(iCust_ID, iPallet_ID, strpalletName, "P:\Dept\Demo\Pallet packing list\")
                '    Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, _
                '         SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID, _
                '         SkyTel.CookPager_CUSTOMER_ID, SkyTel.AMS_CUSTOMER_ID, _
                '         AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID, _
                '         SkyTel.ContactWireless_CUSTOMER_ID, _
                '         SkyTel.A1WirelessComm_CUSTOMER_ID, _
                '         SkyTel.CriticalAlert_CUSTOMER_ID, _
                '         SkyTel.Anna_CUSTOMER_ID, _
                '         SkyTel.Lahey_CUSTOMER_ID, _
                '         SkyTel.Masco_CUSTOMER_ID, _
                '         SkyTel.Franciscan_CUSTOMER_ID, _
                '         SkyTel.Maine_CUSTOMER_ID, _
                '         SkyTel.SMHC_CUSTOMER_ID, _
                '         SkyTel.ATS_CUSTOMER_ID

                '        SkyTel.CreateShipManifestReport(iPallet_ID, strpalletName, strRptFilePath, strManifestRptTitle, booPrtPalletManifest, iPalletShipType)
                '    Case 2254    'Plexus Corp.
                '        CreatePlexusExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '        'Case 2258    'TracFone
                '        'CreateTracFoneExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case 2254    'Plexus Corp.
                '        CreatePlexusExcelFile(iCust_ID, iPallet_ID, strpalletName)
                '    Case Else
                '        '''
                'End Select

                'STEP 2::
                'If iPrtLicensePlateQty > 0 Then
                '    PrintPalletDeviceCountRpt(iPallet_ID, iCust_ID, iPrtLicensePlateQty)
                'End If

                'STEP 3:: 
                'Set the pallet ready to ship
                strSql = "update tpallett set Pallett_ReadyToShipFlg = 1, Pallett_QTY = " & iPalletQty & ", AQL_QCResult_ID = 0 where pallett_id = " & iPallet_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetWingTechATTPallettData(ByVal strPallettName As String, ByVal iCust_ID As Integer) As DataTable
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
        Public Function RemoveSNfromPallet(ByVal iPallett_ID As Integer, ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update tdevice set Pallett_ID = NULL,device_DateShip=NULL, WO_ID_Out = NULL where pallett_id = " & iPallett_ID.ToString & " and device_id = " & iDevice_ID.ToString
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CloseWingTechATT_SP_Pallet(ByVal iPalletID As Integer) As Integer

            Dim strReportName As String = "WingTechATT_SP_Box_Label.rpt"
            Dim strSql As String
            Dim dt, dtLabel, dtDevices As DataTable
            Dim i As Integer = 0, j As Integer = 0, iRet As Integer = 0

            Dim rowNew As DataRow
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0
            Dim strPalletName As String = ""
            Dim iModelID As Integer = 0
            Dim strCustPO As String = ""
            Dim iPalletQty As Integer = 0

            Dim strModelDesc As String = ""
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                'Get device qty as PalletQty
                strSql = "SELECT * FROM production.tdevice WHERE Pallett_ID =" & iPalletID.ToString & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                iPalletQty = dt.Rows.Count

                'close pallet
                strSql = "update production.tpallett set Pallett_ReadyToShipFlg = 1, Pallett_QTY = " & iPalletQty & ", AQL_QCResult_ID = 0 where pallett_id = " & iPalletID.ToString
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

                'get pallett data
                strSql = "SELECT * FROM production.tpallett WHERE pallett_id = " & iPalletID.ToString & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If Not dt.Rows(0).IsNull("Cust_PO") AndAlso Convert.ToString(dt.Rows(0).Item("Cust_PO")).Trim.Length > 0 Then strCustPO = Convert.ToString(dt.Rows(0).Item("Cust_PO")).Trim
                strPalletName = Convert.ToString(dt.Rows(0).Item("Pallett_Name")).Trim
                iModelID = dt.Rows(0).Item("Model_ID")

                'get correct model desc
                strSql = "SELECT * FROM production.tModel WHERE Model_ID=" & iModelID.ToString & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If Not dt.Rows(0).IsNull("ShippedModel_Desc") AndAlso Convert.ToString(dt.Rows(0).Item("ShippedModel_Desc")).Trim.Length > 0 Then
                    strModelDesc = Convert.ToString(dt.Rows(0).Item("ShippedModel_Desc")).Trim
                Else
                    strModelDesc = Convert.ToString(dt.Rows(0).Item("Model_Desc")).Trim
                End If

                'get devices 
                strSql = "SELECT device_ID,Device_SN FROM production.tdevice WHERE Pallett_ID =" & iPalletID.ToString & ";"
                dtDevices = Me._objDataProc.GetDataTable(strSql)

                'Label definition datatable
                strSql = "SELECT" & Environment.NewLine
                strSql &= " '' as Pallet,'' as PalletCode,'' as Model,'' as ModelCode,'' as PO,'' as POCode,0 as Qty,'' as QtyCode,'' as SN1,'' as SN1Code,'' as SN2,'' as SN2Code,'' as SN3,'' as SN3Code,'' as SN4,'' as SN4Code,'' as SN5" & Environment.NewLine
                strSql &= " ,'' as SN5Code,'' as SN6,'' as SN6Code,'' as SN7,'' as SN7Code,'' as SN8,'' as SN8Code,'' as SN9,'' as SN9Code,'' as SN10,'' as SN10Code,'' as SN11,'' as SN11Code,'' as SN12,'' as SN12Code" & Environment.NewLine
                strSql &= " ,'' as SN13,'' as SN13Code,'' as SN14,'' as SN14Code,'' as SN15,'' as SN15Code,'' as SN16,'' as SN16Code,'' as SN17,'' as SN17Code,'' as SN18,'' as SN18Code,'' as SN19,'' as SN19Code" & Environment.NewLine
                strSql &= " ,'' as SN20,'' as SN20Code,'' as SN21,'' as SN21Code,'' as SN22,'' as SN22Code,'' as Other1,'' as Other1Code,0 as Qty1,'' as Qty1Code,'' as Other2,'' as Other2Code,0 as Qty2,'' as Qty2Code" & Environment.NewLine
                strSql &= " ,'' as Other3,'' as Other3Code,0 as Qty3,'' as Qty3Code,'' as Other4,'' as Other4Code,0 as Qty4,'' as Qty4Code,'' as Other5,'' as Other5Code,0 as Qty5,'' as Qty5Code Limit 0;" & Environment.NewLine

                dtLabel = Me._objDataProc.GetDataTable(strSql)

                For i = 0 To dtDevices.Rows.Count - 1
                    If i = 0 Then
                        rowNew = dtLabel.NewRow
                        strS = strPalletName
                        rowNew("Pallet") = strS.Trim
                        If strS.Trim.Length > 0 Then strS = FontEncoder.Code128b(strS.Trim)
                        rowNew("PalletCode") = strS

                        strS = strModelDesc
                        rowNew("Model") = strS.Trim
                        If strS.Trim.Length > 0 Then strS = FontEncoder.Code128b(strS.Trim)
                        rowNew("ModelCode") = strS

                        iVal = iPalletQty
                        rowNew("Qty") = iVal
                        strS = iVal.ToString
                        strS = FontEncoder.Code128a(strS.Trim)
                        rowNew("QtyCode") = strS

                        strS = strCustPO
                        rowNew("PO") = strS.Trim
                        If strS.Trim.Length > 0 Then strS = FontEncoder.Code128b(strS.Trim)
                        rowNew("POCode") = strS
                    End If

                    j += 1
                    strCol = "SN" & (j).ToString : strCol_Code = "SN" & (j).ToString & "Code"
                    strS = dtDevices.Rows(i).Item("Device_SN")
                    rowNew(strCol) = strS.Trim
                    If strS.Trim.Length > 0 Then strS = FontEncoder.Code128b(strS.Trim)
                    rowNew(strCol_Code) = strS

                    'Finally add label data row
                    If i = dtDevices.Rows.Count - 1 Then
                        dtLabel.Rows.Add(rowNew)
                        dtLabel.AcceptChanges()
                    End If
                Next

                'Print
                If dtLabel.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, 1)
                    Return dtLabel.Rows.Count
                Else
                    Return dtLabel.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return iRet

        End Function

        Public Function PrintBoxLabel(ByVal iPalletID As Integer) As Integer
            Dim strReportName As String = "WingTechATT_Pallet_Cricket_Label_20.rpt" ' "WiingTechATT_Pallet_Label_" '"WingTechATT_Pallet_Label_20.rpt"
            Dim strSql As String
            Dim dt, dtLabel As DataTable
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 10
            Dim rowNew As DataRow
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0
            Dim _iWB_ID As Integer = 0
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                strSql = "SELECT A.Pallett_Name as Pallet,C.Model_Desc as Model,A.Pallett_Qty as Qty,B.Device_SN as SN,B.Device_ID" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID =" & iPalletID & Environment.NewLine
                strSql &= " ORDER BY B.Device_SN;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                'strReportName &= dt.Rows.Count.ToString & ".rpt"
                'strReportName = "WinnngTechATT_Pallet_Label BonkeTest2020.rpt"

                strSql = "SELECT" & Environment.NewLine
                strSql &= " '' as Pallet,'' as PalletCode,'' as Model,'' as ModelCode,0 as Qty,'' as QtyCode,'' as SN1,'' as SN1Code,'' as SN2,'' as SN2Code,'' as SN3,'' as SN3Code,'' as SN4,'' as SN4Code,'' as SN5" & Environment.NewLine
                strSql &= " ,'' as SN5Code,'' as SN6,'' as SN6Code,'' as SN7,'' as SN7Code,'' as SN8,'' as SN8Code,'' as SN9,'' as SN9Code,'' as SN10,'' as SN10Code,'' as SN11,'' as SN11Code,'' as SN12,'' as SN12Code" & Environment.NewLine
                strSql &= " ,'' as SN13,'' as SN13Code,'' as SN14,'' as SN14Code,'' as SN15,'' as SN15Code,'' as SN16,'' as SN16Code,'' as SN17,'' as SN17Code,'' as SN18,'' as SN18Code,'' as SN19,'' as SN19Code" & Environment.NewLine
                strSql &= " ,'' as SN20,'' as SN20Code,'' as SN21,'' as SN21Code,'' as SN22,'' as SN22Code,'' as Other1,'' as Other1Code,0 as Qty1,'' as Qty1Code,'' as Other2,'' as Other2Code,0 as Qty2,'' as Qty2Code" & Environment.NewLine
                strSql &= " ,'' as Other3,'' as Other3Code,0 as Qty3,'' as Qty3Code,'' as Other4,'' as Other4Code,0 as Qty4,'' as Qty4Code,'' as Other5,'' as Other5Code,0 as Qty5,'' as Qty5Code Limit 0;" & Environment.NewLine

                dtLabel = Me._objDataProc.GetDataTable(strSql)

                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        rowNew = dtLabel.NewRow
                        strS = dt.Rows(i).Item("Pallet")
                        rowNew("Pallet") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("PalletCode") = strS

                        strS = dt.Rows(0).Item("Model")
                        rowNew("Model") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("ModelCode") = strS

                        iVal = Convert.ToInt32(dt.Rows(i).Item("Qty"))
                        rowNew("Qty") = iVal
                        strS = iVal.ToString
                        strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("QtyCode") = strS
                    End If

                    Select Case i
                        Case 0, 2, 4, 6, 8, 10, 12, 14, 16, 18
                            j += 1
                            'strS = "SN" & (j).ToString
                            strCol = "SN" & (j).ToString : strCol_Code = "SN" & (j).ToString & "Code"
                        Case Else
                            k += 1
                            'strS = "SN" & (k).ToString
                            strCol = "SN" & (k).ToString : strCol_Code = "SN" & (k).ToString & "Code"
                    End Select
                    '  rowNew(strS) = dt.Rows(i).Item("SN")
                    strS = dt.Rows(i).Item("SN")
                    rowNew(strCol) = ReplaceChar(strS.Trim)
                    If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                    rowNew(strCol_Code) = strS

                    'Finally add label data row
                    If i = dt.Rows.Count - 1 Then
                        dtLabel.Rows.Add(rowNew)
                        dtLabel.AcceptChanges()
                    End If
                Next

                'Print
                If dtLabel.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, 1)
                    Return dtLabel.Rows.Count
                Else
                    Return dtLabel.Rows.Count
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

        Public Function Print_AttCTDI_BoxLabel(ByVal iPalletID As Integer) As Integer
            Dim strReportName As String = "WingTechATT_Pallet_AttCTDI_Label_20.rpt"
            Dim strSql As String
            Dim dt, dtOrder, dtLabel As DataTable
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 10
            Dim rowNew As DataRow
            Dim row As DataRow
            Dim strDevice_IDs As String = ""
            Dim strOrderNo As String = ""
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0

            ' Dim strSW_Version As String = "" '"U304AAV02.87.11_9.0"
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                strSql = "SELECT A.Pallett_Name as Pallet,C.Model_Desc as Model,A.Pallett_Qty as Qty,B.Device_SN as SN" & Environment.NewLine
                strSql &= " ,A.SW_Version,ClaimNo as 'OrderNo',if(A.Pallet_ShipType=0, Concat('REFURBISHED ',C.Model_Desc), Concat('RUR ',C.Model_Desc)) as 'PalletType'" & Environment.NewLine
                strSql &= " , A.Pallet_ShipType,B.Device_ID" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER join extendedwarranty  E ON B.device_id=E.Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID =" & iPalletID & Environment.NewLine
                strSql &= "AND E.SourceFile NOT LIKE '%seed%'" & Environment.NewLine
                strSql &= " UNION " & Environment.NewLine
                strSql &= "SELECT A.Pallett_Name as Pallet,C.Model_Desc as Model,A.Pallett_Qty as Qty,B.Device_SN as SN" & Environment.NewLine
                strSql &= " ,A.SW_Version,ClaimNo as 'OrderNo',if(A.Pallet_ShipType=0, Concat('REFURBISHED ',C.Model_Desc), Concat('RUR ',C.Model_Desc)) as 'PalletType'" & Environment.NewLine
                strSql &= " , A.Pallet_ShipType,B.Device_ID" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER join extendedwarranty  E ON B.device_id=E.Swapped_Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID =" & iPalletID & Environment.NewLine
                'strSql &= "AND bulkorderType_id=0  ;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'Get OrderNo
                'If dt.Rows.Count > 0 Then
                '    For Each row In dt.Rows
                '        If strDevice_IDs.Trim.Length = 0 Then
                '            strDevice_IDs = row("Device_ID")
                '        Else
                '            strDevice_IDs &= "," & row("Device_ID")
                '        End If
                '    Next
                '    If strDevice_IDs.Trim.Length > 0 Then
                '        strSql = "SELECT * FROM Extendedwarranty WHERE Device_ID in (" & strDevice_IDs & ");"
                '        dtOrder = Me._objDataProc.GetDataTable(strSql)
                '        If dtOrder.Rows.Count > 0 AndAlso Not dtOrder.Rows(0).IsNull("ClaimNo") Then
                '            strOrderNo = dtOrder.Rows(0).Item("ClaimNo")
                '        End If
                '    End If
                'End If


                ' strReportName &= dt.Rows.Count.ToString & ".rpt"
                'strReportName = "WingTechATT_Pallet_Label BonkeTest2020.rpt"

                'Label columns
                strSql = "SELECT" & Environment.NewLine
                strSql &= " '' as Pallet,'' as PalletCode,'' as 'Desc','' as DescCode,'' as Model,'' as ModelCode,'' as OrderNo,'' as OrderNoCode,'' as Version,'' as VersionCode" & Environment.NewLine
                strSql &= " ,0 as Qty,'' as QtyCode,'' as SN1,'' as SN1Code,'' as SN2,'' as SN2Code,'' as SN3,'' as SN3Code,'' as SN4,'' as SN4Code,'' as SN5" & Environment.NewLine
                strSql &= " ,'' as SN5Code,'' as SN6,'' as SN6Code,'' as SN7,'' as SN7Code,'' as SN8,'' as SN8Code,'' as SN9,'' as SN9Code,'' as SN10,'' as SN10Code,'' as SN11,'' as SN11Code,'' as SN12,'' as SN12Code" & Environment.NewLine
                strSql &= " ,'' as SN13,'' as SN13Code,'' as SN14,'' as SN14Code,'' as SN15,'' as SN15Code,'' as SN16,'' as SN16Code,'' as SN17,'' as SN17Code,'' as SN18,'' as SN18Code,'' as SN19,'' as SN19Code" & Environment.NewLine
                strSql &= " ,'' as SN20,'' as SN20Code,'' as SN21,'' as SN21Code,'' as SN22,'' as SN22Code,'' as Other1,'' as Other1Code,0 as Qty1,'' as Qty1Code,'' as Other2,'' as Other2Code,0 as Qty2,'' as Qty2Code" & Environment.NewLine
                strSql &= " ,'' as Other3,'' as Other3Code,0 as Qty3,'' as Qty3Code,'' as Other4,'' as Other4Code,0 as Qty4,'' as Qty4Code,'' as Other5,'' as Other5Code,0 as Qty5,'' as Qty5Code Limit 0;" & Environment.NewLine

                dtLabel = Me._objDataProc.GetDataTable(strSql)

                'Fill data
                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        rowNew = dtLabel.NewRow

                        strS = dt.Rows(i).Item("Pallet")
                        rowNew("Pallet") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("PalletCode") = strS

                        strS = dt.Rows(0).Item("PalletType")
                        rowNew("Desc") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("DescCode") = strS

                        strS = dt.Rows(0).Item("Model")
                        rowNew("Model") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("ModelCode") = strS

                        strS = dt.Rows(0).Item("OrderNo")
                        rowNew("OrderNo") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("OrderNoCode") = strS

                        strS = dt.Rows(0).Item("SW_Version")
                        rowNew("Version") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("VersionCode") = strS

                        iVal = Convert.ToInt32(dt.Rows(i).Item("Qty"))
                        rowNew("Qty") = iVal
                        strS = iVal.ToString
                        strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("QtyCode") = strS
                    End If

                    j += 1
                    strCol = "SN" & (j).ToString : strCol_Code = "SN" & (j).ToString & "Code"
                    strS = dt.Rows(i).Item("SN")
                    rowNew(strCol) = ReplaceChar(strS.Trim)
                    If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                    rowNew(strCol_Code) = strS

                    'Finally add the label data row
                    If i = dt.Rows.Count - 1 Then
                        dtLabel.Rows.Add(rowNew)
                        dtLabel.AcceptChanges()
                    End If
                Next

                'Print 
                If dtLabel.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, 1)
                    Return dtLabel.Rows.Count
                Else
                    Return dtLabel.Rows.Count
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ReopenWingTechATTBoxByResetting(ByVal iPalletID As Integer, ByVal strStation As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tpallett, tcellopt "
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= ", tcellopt.WorkStation = '" & strStation & "', tcellopt.WorkStationEntryDt = now() " & Environment.NewLine
                strSql += "WHERE tdevice.Device_ID = tcellopt.Device_ID AND tpallett.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                strSql += "AND tdevice.Device_DateShip is NULL  " & Environment.NewLine
                strSql += "AND Pallett_ReadyToShipFlg = 1;"

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetLastSoftwareVersion(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try

                strSql = "Select SW_Version,Pallett_ID,Pallett_Name from tpallett Where Cust_ID=" & iCust_ID & " And Loc_ID=" & iLoc_ID & " ORDER BY Pallett_ID DESC Limit 1;"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("SW_Version") Then
                    strRet = dt.Rows(0).Item("SW_Version")
                    strRet = strRet.Trim
                End If
                Return strRet


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


    End Class
End Namespace
