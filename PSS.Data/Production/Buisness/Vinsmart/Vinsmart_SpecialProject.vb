Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.Vinsmart

    Public Class Vinsmart_SpecialProject
        Private _objDataProc As DBQuery.DataProc

#Region "Properties"
        Public WriteOnly Property CustID() As Integer
            Set(ByVal Value As Integer)
                _CustID = Value
            End Set
        End Property
        Private _CustID As Integer

        Public WriteOnly Property LocID() As Integer
            Set(ByVal Value As Integer)
                _LocID = Value
            End Set
        End Property
        Private _LocID As Integer

        Public WriteOnly Property ProjectName() As String
            Set(ByVal Value As String)
                _ProjectName = Value
            End Set
        End Property
        Private _ProjectName As String

        Public ReadOnly Property KitValidationRequired() As Boolean
            Get
                Return _KitValidationRequired
            End Get
        End Property
        Private _KitValidationRequired As Boolean

        Public WriteOnly Property iPalletID() As Integer
            Set(ByVal Value As Integer)
                _iPalletID = Value
            End Set
        End Property
        Private _iPalletID As Integer

        Public WriteOnly Property iShiftID() As Integer
            Set(ByVal Value As Integer)
                _iShiftID = Value
            End Set
        End Property
        Private _iShiftID As Integer
#End Region

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
        '4492
        Public Function getVinsmartRecvTableDef() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT 0 AS 'RecID','' AS 'SN','' AS 'ASN_SKU','' AS 'PSS_Model','' AS 'Manuf_Date','' AS 'PO','' AS 'Loc'" & Environment.NewLine
                strSql &= " ,0 AS 'Model_ID',0 AS 'Loc_ID',0 AS 'EW_ID',0 AS 'Device_ID',0 AS 'wb_ID'" & Environment.NewLine
                strSql &= " LIMIT 0;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetDeviceFQAData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                'FQA:   QCType_ID=2, Pass: QCResult_ID=1
                strSql = "SELECT * FROM tqc WHERE QCType_ID =2 AND Device_ID=" & iDevice_ID & " ORDER BY QC_Date DESC;"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetVinsmartShipBoxTypes(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim drNewRow As DataRow

            Try
                strSql = "SELECT 0 as 'ShipTypeID', 'REF' as 'ShipTypeSDesc', 'REFURBISHED' as 'ShipTypeLDesc' " & Environment.NewLine
                strSql &= "UNION ALL SELECT 1 as 'ShipTypeID', 'RUR' as 'ShipTypeSDesc', 'RUR' as 'ShipTypeLDesc'"
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


        Public Function GetVinsmartLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select Loc_ID,Loc_Name from production.tlocation WHere Cust_ID=" & iCust_ID & " and Loc_id  NOT IN (4492,4498,4599);"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateVinsmartPalletLocation(ByVal iLoc_ID As Integer, ByVal iPallett_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = " UPDATE tpallett SET loc_id=" & iLoc_ID & " WHERE pallett_id=" & iPallett_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVinsmartModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'strSql = "Select Distinct A.Model_ID,C.Model_Desc" & Environment.NewLine
                'strSql &= " From  production.tdevice A" & Environment.NewLine
                'strSql &= " Inner Join production.tlocation B ON A.Loc_ID=B.Loc_ID AND B.Cust_ID=" & iCust_ID & Environment.NewLine
                'strSql &= " Inner Join production.tmodel C  ON A.Model_ID=C.Model_ID;" & Environment.NewLine

                strSql = "SELECT model_ID, model_Desc,Model_MotoSku,ASN_IN_SKU,ASN_IN_SKU_Desc,Model_LDesc,ShippedModel, " & vbCrLf
                strSql &= "ShippedModel_Desc, Cust_IDs, Model_Tier, Model_Flat, Manuf_ID, Prod_ID, ProdGrp_ID, ASCPrice_ID, RptGrp_ID  " & vbCrLf
                strSql &= "FROM Production.tmodel " & vbCrLf
                strSql &= "WHERE Cust_IDs LIKE '%" & iCust_ID & "%' " & vbCrLf
                strSql &= "ORDER BY Model_Desc; "

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateBoxID(ByVal iModelID As Integer, _
                                          ByVal iBoxType As Integer, _
                                          ByVal sCust_PO As String, _
                                          ByVal strPalletPrefix As String, _
                                          ByVal iCust_ID As Integer, _
                                          ByVal iLoc_ID As Integer, _
                                          ByVal strAccount As String) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim iMaxNum As Integer = 0
            Dim dt As DataTable
            Try
                If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID Then
                    '******************************
                    'construct pallet name
                    '******************************
                    strDate = Generic.GetMySqlDateTime("%y%m%d")

                    If iModelID = 5266 Then   ' For SP1 Project no need to add POnumber in BoxName
                        strPalletPrefix = "CS01F01057"
                    ElseIf iModelID = 5265 Then
                        strPalletPrefix = "CS01F01109"
                    End If
                    strPalletPrefix = strPalletPrefix & strDate
                    strPalletName = Me.DefinePalletName(strPalletPrefix, iMaxNum, iCust_ID)

                    'check max number palletts
                    If iMaxNum <= 0 Then Throw New Exception("Max box N### must be >0." & Environment.NewLine)
                    If iMaxNum > 999 Then Throw New Exception("Max pallets (per location per day) hit the 999 limit." & Environment.NewLine)
                    If strPalletName.Trim.Length = 0 Then Throw New Exception("Pallet name is nothing." & Environment.NewLine)

                    '******************************
                    'check for duplicate pallet
                    '******************************
                    strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLoc_ID & " and Cust_ID=" & iCust_ID & " and Cust_PO= " & sCust_PO & ""
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
                strSql &= ", Cust_PO  " & Environment.NewLine
                strSql &= ", Account " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", " & iBoxType & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iCust_ID & " " & Environment.NewLine
                strSql &= ", " & iLoc_ID & " " & Environment.NewLine
                strSql &= ", " & sCust_PO & " " & Environment.NewLine
                strSql &= ", '" & strAccount & "' ); " & Environment.NewLine
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

        Public Function GetVinsmartOpenPallets(ByVal iCust_ID As Integer, ByVal iLoc_ID As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, tpallett.Loc_ID, Pallet_ShipType, " & Environment.NewLine
                strSql &= " if(Pallett_QTY is null,0,Pallett_QTY) as Pallett_QTY,Pallett_Name as 'Box Name', " & Environment.NewLine
                strSql &= " tlocation.Loc_Name as Location, Model_Desc as Model, if(Cust_PO is null,0,Cust_PO) as Cust_PO, " & Environment.NewLine
                strSql &= " Account as Project,IF(pallet_shiptype=0,'REF','RUR') AS 'Box Type' " & Environment.NewLine
                strSql &= " FROM tpallett " & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
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

        Public Function GetVinsmartPallettData(ByVal strPallettName As String, ByVal iCust_ID As Integer) As DataTable
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
        Public Function GetDeviceSIMcard(ByVal iDevice_ID As Integer, ByVal strAccount As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT A.SerialNo AS 'IMEI',E.Serial AS 'ICCID', B.Device_ID,  E.Device_ID AS 'ICCID_Device_ID',A.Cust_ID,A.Loc_ID,A.EW_ID, B.Model_ID,C.wb_id,C.BoxID,A.WI_ID, D.Model_Desc,A.Item_Sku,A.Account,Insert_Decode_ID  " & Environment.NewLine
                strSql &= "FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= "INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN edi.twarehouseBox C ON A.wb_ID=C.wb_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tModel D ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items E ON A.WI_ID=E.WI_ID" & Environment.NewLine
                strSql &= " WHERE  A.Cust_ID=2630 AND A.Loc_ID=4492 AND A.Account = '" & strAccount & "' and B.device_id=" & iDevice_ID & " ;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDevicePretest(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                'Bonke, this SQL needs to change
                strSql = "SELECT * FROM  tpretest_data,tdevice " & Environment.NewLine
                strSql &= " WHERE tpretest_data.Device_ID =" & iDevice_ID & " and tpretest_data.device_id=tdevice.device_id and device_DateShip is null;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Use this one
        Public Function IsPretestPassed(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim bRet As Boolean = False
            Dim dt As DataTable

            Try
                strSql = "SELECT A.*" & Environment.NewLine
                strSql &= " FROM production.tpretest_data A" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_ID = " & iDevice_ID & " AND B.device_DateShip is null" & Environment.NewLine
                strSql &= " ORDER BY pretest_iteration Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Convert.ToInt32(dt.Rows(0).Item("Pttf")) = 2515 Then 'pass
                    bRet = True
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceAccount(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT account FROM  extendedwarranty A INNER JOIN tdevice B ON A.Device_ID=B.device_id WHERE B.Device_ID =" & iDevice_ID & "  and device_DateShip is null;" & Environment.NewLine
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



        Public Function CloseVinsmartPallet(ByVal iCust_ID As Integer, _
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

                strSql = "update tpallett set Pallett_ReadyToShipFlg = 1, Pallett_QTY = " & iPalletQty & ", AQL_QCResult_ID = 0 where pallett_id = " & iPallet_ID.ToString

                Return Me._objDataProc.ExecuteNonQuery(strSql)

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
        Public Function getLabelTemplate() As DataTable
            Dim strSql As String = ""
            Dim dtLabel As New DataTable()
            Try
                strSql = "SELECT" & Environment.NewLine
                strSql &= " '' as PO,'' as POCode,'' as Partnumber,'' as PartnumberCode,'' as Pallet,'' as PalletCode,'' as Model,'' as ModelCode,0 as Qty,'' as QtyCode,'' as SN1,'' as SN1Code,'' as SN2,'' as SN2Code,'' as SN3,'' as SN3Code,'' as SN4,'' as SN4Code,'' as SN5" & Environment.NewLine
                strSql &= " ,'' as SN5Code,'' as SN6,'' as SN6Code,'' as SN7,'' as SN7Code,'' as SN8,'' as SN8Code,'' as SN9,'' as SN9Code,'' as SN10,'' as SN10Code,'' as SN11,'' as SN11Code,'' as SN12,'' as SN12Code" & Environment.NewLine
                strSql &= " ,'' as SN13,'' as SN13Code,'' as SN14,'' as SN14Code,'' as SN15,'' as SN15Code,'' as SN16,'' as SN16Code,'' as SN17,'' as SN17Code,'' as SN18,'' as SN18Code,'' as SN19,'' as SN19Code" & Environment.NewLine
                strSql &= " ,'' as SN20,'' as SN20Code,'' as SN21,'' as SN21Code,'' as SN22,'' as SN22Code,'' as SN23,'' as SN23Code,'' as SN24,'' as SN24Code,'' as SN25,'' as SN25Code,'' as SN26,'' as SN26Code" & Environment.NewLine
                strSql &= " ,'' as SN27,'' as SN27Code,'' as SN28,'' as SN28Code,'' as SN29,'' as SN29Code,'' as SN30,'' as SN30Code,'' as SN31,'' as SN31Code,'' as SN32,'' as SN32Code,'' as SN33,'' as SN33Code" & Environment.NewLine
                strSql &= " ,'' as SN34,'' as SN34Code,'' as SN35,'' as SN35Code,'' as SN36,'' as SN36Code,'' as SN37,'' as SN37Code,'' as SN38,'' as SN38Code,'' as SN39,'' as SN39Code,'' as SN40,'' as SN40Code" & Environment.NewLine
                strSql &= " ,'' as SN41,'' as SN41Code,'' as SN42,'' as SN42Code,'' as SN43,'' as SN43Code,'' as SN44,'' as SN44Code,'' as SN45,'' as SN45Code,'' as SN46,'' as SN46Code,'' as SN47,'' as SN47Code" & Environment.NewLine
                strSql &= " ,'' as SN48,'' as SN48Code,'' as SN49,'' as SN49Code,'' as SN50,'' as SN50Code" & Environment.NewLine
                strSql &= " ,'' as Other1,'' as Other1Code,0 as Qty1,'' as Qty1Code,'' as Other2,'' as Other2Code,0 as Qty2,'' as Qty2Code" & Environment.NewLine
                strSql &= " ,'' as Other3,'' as Other3Code,0 as Qty3,'' as Qty3Code,'' as Other4,'' as Other4Code, '' as Other5,'' as Other5Code,0 as Qty4,'' as Qty4Code,'' as CountryOfOrigine,'' as CountryOfOrigineCode,0 as Qty5,'' as Qty5Code Limit 0;" & Environment.NewLine
                dtLabel = Me._objDataProc.GetDataTable(strSql)
                Return dtLabel
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function GetPallet_SN(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "SELECT Cust_Po as PO,OEM_RA as Partnumber,cntry_name,Model_desc as Item_Desc,A.Pallett_Name as Pallet,C.Model_MotoSku as Model,A.Pallett_Qty as Qty,B.Device_SN as SN,B.Device_ID" & Environment.NewLine
                strSql &= " FROM tpallett A" & Environment.NewLine
                strSql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN extendedwarranty D ON D.Device_id=B.Device_id" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Pallett_ID =" & iPalletID & Environment.NewLine
                strSql &= " ORDER BY B.Device_SN;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                'Print
                Return dt
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


        Public Function PrintBoxLabel(ByVal dtLabel As DataTable, ByVal strReportName As String) As Integer
            'Print Vinsmart_Pallet_Cricket_Label_20

            Try
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

        Public Function ReopenVinsmartBoxByResetting(ByVal iPalletID As Integer, ByVal strStation As String) As Integer
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


        Public Function ReplaceChar(ByVal strS As String) As String
            Try

                strS.Trim()
                strS = strS.Replace("'", "''")
                strS = strS.Replace("\", "\\")

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getVinsmartPalletDataForSPTeller(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "select C.Account,B.Pallett_Name,C.Cntry_Name,C.OEM_RA,B.Cust_PO,A.Model_ID,A.loc_ID,B.Pallett_ID,B.Pallett_Qty,Count(*) as Qty, if(B.Pallett_Qty=count(*),0,1) AS QtyOk_Yes0No1" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " Inner join tpallett B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " inner join extendedwarranty C ON A.Device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " WHERE B.Pallett_ID=" & iPalletID & Environment.NewLine
                strSql &= " GROUP BY C.Account,B.Pallett_Name,C.Cntry_Name,B.Cust_PO,A.Model_ID,A.loc_ID,B.Pallett_ID;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getVinsmartSP_PalletQty(ByVal strPallett_IDs As String, ByRef iDevQtyPerBox As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iQty As Integer = 0

            Try
                strSql = "SELECT SUM(Pallett_Qty) as Qty,AVG(Pallett_qty) as avgQty " & Environment.NewLine
                strSql &= " FROM  production.tpallett" & Environment.NewLine
                strSql &= " WHERE Pallett_ID In (" & strPallett_IDs & ")" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then iQty = dt.Rows(0).Item("Qty") : iDevQtyPerBox = dt.Rows(0).Item("avgQty") 'should be 1 record

                Return iQty

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getVinsmartSP_DeviceQty(ByVal strPallett_IDs As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iQty As Integer = 0

            Try
                strSql = "SELECT Count(*) as Qty " & Environment.NewLine
                strSql &= " FROM  production.tdevice" & Environment.NewLine
                strSql &= " WHERE Pallett_ID In (" & strPallett_IDs & ")" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then iQty = dt.Rows(0).Item(0)

                Return iQty

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetMasterPalletNextSeqNo(ByVal strBoxNamePreFix As String, ByVal iBoxSegDigitCnt As Integer, ByVal strColName As String) As Integer
            Dim strSql As String = ""
            Dim _sb As New StringBuilder()
            Dim iNextSeqNo As Integer
            Dim iNextSeqNo2 As Integer
            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim _retVal As Integer
            Try
                ' GET THE MAX FROM THE TWAREHOUSEBOX TABLE.
                'MPallet_ID, MPallet_Name, MLoadNo, PO, Desc1, Desc2, Desc3, Qty1, Qty2, Qty3, pkslip_ID, Cust_ID, Loc_ID
                strSql = "SELECT max(right(" & strColName & ", " & iBoxSegDigitCnt & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                strSql &= "FROM production.tpackingslippallet " & Environment.NewLine
                strSql &= "WHERE " & strColName & " like '" & strBoxNamePreFix & "%' AND Length(Trim(" & strColName & ")) = " & (strBoxNamePreFix.Length + iBoxSegDigitCnt) & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                    iNextSeqNo = CInt(dt.Rows(0)("NextSequenceNumber"))
                Else
                    iNextSeqNo = 1
                End If

                ' RETURN THE MAX NUMBER OF THE TWO TABLES.
                _retVal = IIf(iNextSeqNo > iNextSeqNo2, iNextSeqNo, iNextSeqNo2)
                Return _retVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function SaveMasterPallet(ByVal strMPallet_Name As String, ByVal strMLoadNo As String, ByVal strPO As String, ByVal strMftPart As String, ByVal strCustPart As String, _
                                         ByVal strCountry As String, ByVal iDevQtyPerBox As Integer, ByVal iBoxQtyMasterPallet As Integer, ByVal iToalDevQty As Integer, _
                                         ByVal iPkSlip_ID As Integer, ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As Integer

            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO  production.tpackingslippallet (MPallet_Name, MLoadNo, PO, Desc1, Desc2, Desc3, Qty1, Qty2, Qty3, pkslip_ID, Cust_ID, Loc_ID)"
                strSql &= "VALUES ('" & strMPallet_Name & "','" & strMLoadNo & "','" & strPO & "','" & strMftPart & "','" & strCustPart & "','" & _
                                   strCountry & "'," & iDevQtyPerBox & "," & iBoxQtyMasterPallet & "," & iToalDevQty & "," & iPkSlip_ID & "," & iCust_ID & "," & iLoc_ID & ");"
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getVinsmart_SpTellerManifest_MostRecent_pkSlipID() As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "Select Max(A.pkSlip_ID) as pkSlip_ID,B.pkslip_createDt" & Environment.NewLine
                strSql &= " FROM production.tpackingslippallet A" & Environment.NewLine
                strSql &= " INNER JOIN production.tpackingslip B ON A.pkSlip_ID=B.pkSlip_ID" & Environment.NewLine
                strSql &= " Group By B.pkslip_createDt" & Environment.NewLine
                strSql &= " ORDER BY B.pkslip_createDt Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then iRet = dt.Rows(0).Item("pkSLip_ID")

                Return iRet

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function getVinsmart_SpTellerManifestMasterPalletData(ByVal ipkSlip_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select A.*,B.pkslip_createDt FROM production.tpackingslippallet A" & Environment.NewLine
                strSql &= " INNER JOIN production.tpackingslip B ON A.pkSlip_ID=B.pkSlip_ID" & Environment.NewLine
                strSql &= " WHERE A.pkSLip_ID=" & ipkSlip_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PrintManifestMasterPalletLabel(ByVal strMasterPalletName As String, ByVal strPO As String, ByVal strLoadNo As String, _
                                                       ByVal strMftPart As String, ByVal strCustPart As String, _
                                                       ByVal iDevQtyPerBox As Integer, ByVal iBoxQtyPerMasterPallet As Integer, ByVal iToatlDevQty As Integer, _
                                                       ByVal iLabelCopyNum As Integer) As Integer

            Dim strReportName As String = "Vinsmart_Pallet_SP_Master_Pallet_Label.rpt" 'for all Vinsmart Special Project Teller Data Manifest Master Pallet label
            Dim strSql As String
            Dim dtLabel As DataTable
            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Dim strMasterPalletName_Code As String = ""
            Dim strPO_Code As String = ""
            Dim strLoadNo_Code As String = ""
            Dim strMftPart_Code As String = ""
            Dim strCustPart_Code As String = ""
            Dim strDevQtyPerBox_Code As String = ""
            Dim strBoxQtyPerMasterPallet_Code As String = ""
            Dim strToatlDevQty_Code As String = ""
            Dim strS As String = ""

            Try
                strS = strMasterPalletName.Trim : strMasterPalletName = ReplaceChar(strS) : strMasterPalletName_Code = ReplaceChar(FontEncoder.Code128a(strS))
                strS = strPO.Trim : strPO = ReplaceChar(strS) : strPO_Code = ReplaceChar(FontEncoder.Code128a(strS))
                strS = strLoadNo.Trim : strLoadNo = ReplaceChar(strS) : strLoadNo_Code = ReplaceChar(FontEncoder.Code128a(strS))
                strS = strMftPart.Trim : strMftPart = ReplaceChar(strS) : strMftPart_Code = ReplaceChar(FontEncoder.Code128a(strS))
                strS = strCustPart.Trim : strCustPart = ReplaceChar(strS) : strCustPart_Code = ReplaceChar(FontEncoder.Code128a(strS))

                strS = iDevQtyPerBox.ToString : strDevQtyPerBox_Code = ReplaceChar(FontEncoder.Code128a(strS))
                strS = iBoxQtyPerMasterPallet.ToString : strBoxQtyPerMasterPallet_Code = ReplaceChar(FontEncoder.Code128a(strS))
                strS = iToatlDevQty.ToString : strToatlDevQty_Code = ReplaceChar(FontEncoder.Code128a(strS))


                strSql = "SELECT '" & strMasterPalletName & "' AS 'Pallet','" & strMasterPalletName_Code & "' AS 'PalletCode'" & Environment.NewLine
                strSql &= ", '" & strPO & "' AS 'PO','" & strPO_Code & "' AS 'PoCode','" & strLoadNo & "' AS 'PartNumber','" & strLoadNo_Code & "' AS 'PartNumberCode'" & Environment.NewLine
                strSql &= ",'" & strMftPart & "' AS 'SN1','" & strMftPart_Code & "' AS 'SN1Code','" & strCustPart & "' AS 'SN2','" & strCustPart_Code & "' AS 'SN2Code'" & Environment.NewLine
                strSql &= "," & iDevQtyPerBox & " AS 'Qty1','" & strDevQtyPerBox_Code & "' AS 'Qty1Code'" & Environment.NewLine
                strSql &= "," & iBoxQtyPerMasterPallet & " AS 'Qty2','" & strBoxQtyPerMasterPallet_Code & "' AS 'Qty2Code'" & Environment.NewLine
                strSql &= "," & iToatlDevQty & " AS 'Qty','" & strToatlDevQty_Code & "' AS 'QtyCode';" & Environment.NewLine

                dtLabel = Me._objDataProc.GetDataTable(strSql)

                'Print
                If dtLabel.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName, iLabelCopyNum)
                    Return dtLabel.Rows.Count
                Else
                    Return dtLabel.Rows.Count
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Old one
        'Public Function getVinsmart_SpTellerManifestMasterPalletDetailedData(ByVal strMPalletNames As String, ByVal iCartonWeight As Integer) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT A.Mpallet_Name AS 'PALLET_NO',B.pallett_name AS 'CARTON_NO','" & iCartonWeight.ToString & " lbs' AS ' CARTON_WEIGHT', C.Device_SN AS 'IMEI_MAIN'" & Environment.NewLine
        '        strSql &= " FROM production.tpackingslippallet A" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tpallett B ON A.pkslip_id=B.pkslip_id" & Environment.NewLine
        '        strSql &= " INNER JOIN production.tdevice C ON B.pallett_id=C.pallett_id" & Environment.NewLine
        '        strSql &= " WHERE A.Mpallet_Name IN (" & strMPalletNames & ");" & Environment.NewLine

        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getVinsmart_SpTellerManifestMasterPalletAccount(ByVal strMPalletNames As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRes As String = ""

            Try
                strMPalletNames = strMPalletNames.Replace("'", "''")

                strSql = "SELECT D.Account" & Environment.NewLine
                strSql &= " FROM production.tpackingslippallet A" & Environment.NewLine
                strSql &= " INNER JOIN production.tpallett B ON A.pkslip_id=B.pkslip_id" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice C ON B.pallett_id=C.pallett_id" & Environment.NewLine
                strSql &= " INNER JOIN production.extendedwarranty D ON C.Device_ID=D.Device_ID" & Environment.NewLine
                strSql &= " LEFT JOIN warehouse.warehouse_items E ON D.wi_ID=E.wi_id" & Environment.NewLine
                strSql &= " WHERE A.Mpallet_Name IN ('" & strMPalletNames & "');" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then strRes = Convert.ToString(dt.Rows(0).Item(0))

                Return strRes
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getVinsmart_SpTellerManifestMasterPalletDetailedData(ByVal strMPalletNames As String, ByVal iCartonWeight As Integer, ByVal strAccount As String) As DataTable
            Dim strSql As String = ""

            Try

                strAccount = strAccount.Replace("'", "''")

                If strAccount.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type2.Trim.ToUpper Then
                    strSql = "SELECT A.Mpallet_Name AS 'PALLET_NO',B.pallett_name AS 'CARTON_NO','" & iCartonWeight.ToString & " lbs' AS ' CARTON_WEIGHT', C.Device_SN AS 'IMEI_MAIN'" & Environment.NewLine
                    strSql &= " FROM production.tpackingslippallet A" & Environment.NewLine
                    strSql &= " INNER JOIN production.tpallett B ON A.pkslip_id=B.pkslip_id" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdevice C ON B.pallett_id=C.pallett_id" & Environment.NewLine
                    strSql &= " INNER JOIN production.extendedwarranty D ON C.Device_ID=D.Device_ID" & Environment.NewLine
                    strSql &= " LEFT JOIN warehouse.warehouse_items E ON D.wi_ID=E.wi_id" & Environment.NewLine
                    strSql &= " WHERE D.Account = '" & strAccount & "' AND A.Mpallet_Name IN (" & strMPalletNames & ");" & Environment.NewLine
                ElseIf strAccount.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SpecialProj_Type3.Trim.ToUpper Then
                    strSql = "SELECT A.Mpallet_Name AS 'PALLET_NO',B.pallett_name AS 'CARTON_NO','" & iCartonWeight.ToString & " lbs' AS ' CARTON_WEIGHT', C.Device_SN AS 'IMEI_MAIN',E.Serial as 'ICCID'" & Environment.NewLine
                    strSql &= " FROM production.tpackingslippallet A" & Environment.NewLine
                    strSql &= " INNER JOIN production.tpallett B ON A.pkslip_id=B.pkslip_id" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdevice C ON B.pallett_id=C.pallett_id" & Environment.NewLine
                    strSql &= " INNER JOIN production.extendedwarranty D ON C.Device_ID=D.Device_ID" & Environment.NewLine
                    strSql &= " LEFT JOIN warehouse.warehouse_items E ON D.wi_ID=E.wi_id" & Environment.NewLine
                    strSql &= " WHERE D.Account = '" & strAccount & "' AND A.Mpallet_Name IN (" & strMPalletNames & ");" & Environment.NewLine
                Else
                    strSql = "SELECT 0 as Val limit 0;"
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ' ************* Added by Amazech-Neethi (06-May-2021) *************
        Public Function GetCountryAndAccount(ByVal strSN As String, ByVal iCust_ID As Integer, ByVal strLoc_ID As String) As DataTable
            Dim strSql As String = ""
            Try
                strSN = strSN.Replace("'", "''")
                strSql = "select serialNo as Device_SN,cntry_name,loc_ID,Account from extendedwarranty  where serialNo='" & strSN & "' AND Cust_ID = " & iCust_ID & " AND Loc_ID= '" & strLoc_ID & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        ' added by Bonke
        Public Function GetSourceFile(ByVal strSN As String, ByVal iCust_ID As Integer, Optional ByVal strLoc_ID As Integer = 4500) As DataTable
            Dim strSql As String = ""
            Try
                strSN = strSN.Replace("'", "''")
                strSql = "select SourceFile from extendedwarranty A "
                strSql &= "INNER JOIN Tdevice B ON A.device_id=B.device_id " & Environment.NewLine
                strSql &= "where A.serialNo='" & strSN & "' AND A.Cust_ID = " & iCust_ID & " AND A.Loc_ID= " & strLoc_ID & " AND B.device_dateship is NULL " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ' ************* Added by Amazech-Neethi (07-May-2021) *************
        Public Function GetVinsmartProjectTypes(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try

                strSql = "SELECT A.Account AS PrjType_Desc, A.Account AS PrjType_Name " & Environment.NewLine
                strSql &= "FROM production.extendedwarranty A " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCust_ID & " AND A.Loc_ID IN (" & iLoc_ID & ")	 " & Environment.NewLine
                strSql &= "GROUP BY A.Account ORDER BY A.Account "

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function CheckDevicesInBoxAreKitted(ByVal iPalletID As Integer) As String
            'Checks each device in the box for a SIM card
            'If true, returns an empty string
            'If false, returns an error message
            Dim dt As DataTable
            Dim dtRow As DataRow
            Dim Device_ID As Integer
            Dim Device_SN As String = ""
            Dim projName As String = ""
            Dim isKitted As Boolean
            Dim strReturn As String = ""

            Try
                dt = GetDevicesInBox(iPalletID)
                If dt.Rows.Count = 0 Then
                    Return "No devices were found for this box"
                    Exit Function
                End If

                Dim dr As DataRow = dt.Rows(0)   'position on the first row
                projName = dr("Account").ToString
                If projName.ToUpper <> _ProjectName.ToUpper Then
                    'This will exit the routine if kitting does not apply to the project
                    _KitValidationRequired = False
                    Return ""
                    Exit Function
                Else
                    _KitValidationRequired = True
                End If

                For Each dtRow In dt.Rows
                    Device_ID = Convert.ToInt32(dtRow("device_ID"))
                    Device_SN = dtRow("Device_SN").ToString
                    projName = dtRow("Account").ToString

                    If IsDeviceKitted(Device_ID) = False Then
                        strReturn = String.Concat("Device Number ", Device_SN, " is not kitted.")
                        Exit For
                    Else
                        strReturn = ""
                    End If
                Next

                Return strReturn

            Catch ex As Exception
                Dim errmsg As String = ex.ToString
                Throw ex
            End Try
        End Function

        Public Function GetDevicesInBox(ByVal iPalletID As Integer) As DataTable
            'populates a datatable with the IMEI devices in a box
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try
                strSql = "SELECT A.Device_ID, A.Device_SN, B.Account, " & Environment.NewLine
                strSql = strSql & "A.Device_FinishedGoods, A.Ship_ID, A.Shift_ID_Ship, A.Device_ShipWorkDate " & Environment.NewLine
                strSql = strSql & "FROM production.tdevice A " & Environment.NewLine
                strSql = strSql & "INNER JOIN production.extendedwarranty B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql = strSql & "WHERE A.Pallett_ID = " & iPalletID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsDeviceKitted(ByVal iDeviceID As Integer) As Boolean
            'Checks to see if the device has been kitted with a SIM card
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try
                strSql = "SELECT B.Device_ID, E.Device_ID AS 'ICCID_Device_ID', E.Insert_Decode_ID " & Environment.NewLine
                strSql = strSql & " FROM production.extendedwarranty A " & Environment.NewLine
                strSql = strSql & " INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID " & Environment.NewLine
                strSql = strSql & " INNER JOIN edi.twarehouseBox C ON A.wb_ID=C.wb_ID " & Environment.NewLine
                strSql = strSql & " INNER JOIN production.tModel D ON B.Model_ID=D.Model_ID " & Environment.NewLine
                strSql = strSql & " INNER JOIN warehouse.warehouse_items E ON A.WI_ID=E.WI_ID " & Environment.NewLine
                strSql = strSql & " WHERE  A.Cust_ID= " & _CustID & " AND A.Loc_ID= " & _LocID & " AND A.Account = '" & _ProjectName & "' " & Environment.NewLine
                strSql = strSql & " AND E.Insert_Decode_ID = 1 AND B.device_id= " & iDeviceID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function UpdateSimCard(ByVal iPalletID As Integer) As Integer

            'Dim strShipDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim strShipDate As String = ""
            Dim i As Integer = 0
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dr As DataRow
            Dim deviceID As Integer
            Dim imei_deviceID As Integer
            Dim shipID As Integer
            Dim shiftIdShip As Integer
            Dim deviceShipWorkDate As String
            Dim imeiShipDate As String

            Dim deviceFinishedGoods As Integer
            Dim testValue As Integer

            Try
                'Get the devices in the box
                dt = GetDevicesAndSimCardsInBox(iPalletID)
                If dt.Rows.Count = 0 Then
                    Return 0
                End If

                For Each dr In dt.Rows
                    deviceID = Convert.ToInt32(dr("ICCID_Device_ID"))  'Get the ICCID device ID to update that record in table tdevice
                    imei_deviceID = Convert.ToInt32(dr("IMEI_Device_ID"))
                    shipID = Convert.ToInt32(dr("Ship_ID"))
                    shiftIdShip = Convert.ToInt32(dr("Shift_ID_Ship"))
                    deviceFinishedGoods = Convert.ToInt32(dr("Device_FinishedGoods"))
                    imeiShipDate = Format(dr("IMEI_ShipDate"), "yyyy-MM-dd HH:mm:ss")
                    deviceShipWorkDate = Format(dr("Device_ShipWorkDate"), "yyyy-MM-dd")

                    'Update tdevice table, SIM card record
                    strSql = "Update tdevice " & Environment.NewLine
                    strSql += " set Ship_ID = " & shipID & ", " & Environment.NewLine
                    strSql += " Shift_ID_Ship = " & shiftIdShip & ", " & Environment.NewLine
                    strSql += " Device_SendClaim = 0, " & Environment.NewLine
                    strSql += " Device_DateShip = '" & imeiShipDate & "', " & Environment.NewLine
                    strSql += " Device_ShipWorkDate = '" & deviceShipWorkDate & "', " & Environment.NewLine
                    strSql += " Device_FinishedGoods = " & deviceFinishedGoods & Environment.NewLine
                    strSql += " where device_id = " & deviceID & ";"

                    testValue = _objDataProc.ExecuteNonQuery(strSql)
                    i += testValue
                Next
                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDevicesAndSimCardsInBox(ByVal iPalletID As Integer) As DataTable
            'populates a datatable with the IMEI devices in a box
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try
                strSql = "SELECT C.Device_ID AS ICCID_Device_ID, E.Device_ID AS IMEI_Device_ID, F.Device_DateShip AS IMEI_ShipDate, " & Environment.NewLine
                strSql = strSql & "F.Device_FinishedGoods, F.Ship_ID, F.Shift_ID_Ship, F.Device_ShipWorkDate " & Environment.NewLine
                strSql = strSql & "FROM production.tworkorder A " & Environment.NewLine
                strSql = strSql & "INNER JOIN warehouse.warehouse_receipt B ON A.WO_ID =B.WO_ID " & Environment.NewLine
                strSql = strSql & "INNER JOIN warehouse.warehouse_items C ON B.WR_ID=C.WR_ID " & Environment.NewLine
                strSql = strSql & "INNER JOIN production.tDevice D ON C.Device_ID=D.Device_ID " & Environment.NewLine
                strSql = strSql & "INNER JOIN production.extendedwarranty  E ON E.Wi_ID=C.WI_ID " & Environment.NewLine
                strSql = strSql & "INNER JOIN production.tdevice F ON E.Device_ID = F.Device_ID " & Environment.NewLine
                strSql = strSql & "WHERE B.Cust_ID= " & _CustID & " AND B.LOC_ID= " & _LocID & " AND F.Pallett_ID = " & iPalletID & ";"


                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetVinsmartAccounts(ByVal iCustID As Integer, ByVal iLocID As Integer) As DataTable
            'Get the accounts (projects) used for Vinsmart
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try
                strSql = "SELECT DISTINCT A.Account FROM production.extendedwarranty A " & Environment.NewLine
                strSql += "WHERE A.Cust_ID = " & iCustID & " AND A.Loc_ID = " & iLocID & " " & Environment.NewLine
                strSql += "ORDER BY A.Account ; "

                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ValidateImeiNumber(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strAccount As String, ByVal strImeiNbr As String) As Boolean
            'Validate the scanned IMEI number
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try
                strSql = "SELECT A.Cust_ID, A.Loc_ID FROM production.extendedwarranty A " & Environment.NewLine
                strSql += "INNER JOIN production.tdevice B ON A.Device_ID=B.Device_ID " & Environment.NewLine
                strSql += "WHERE A.Cust_ID = " & iCustID & " AND A.Loc_ID = " & iLocID & " AND A.Account ='" & strAccount & "' AND A.SerialNo='" & strImeiNbr & "'; "

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace