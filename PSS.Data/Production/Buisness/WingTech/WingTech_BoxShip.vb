Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WingTech
    Public Class WingTech_BoxShip
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

        Public Function GetOrderType(ByVal strImei As String, ByVal iCust_Id As Integer) As Integer
            Dim dtrow As DataRow
            Dim strSql As String = ""
            Dim orderType As Integer
            Dim dt As DataTable
            Try
                strSql = "SELECT BulkOrderType_ID " & Environment.NewLine
                strSql &= "FROM extendedwarranty,tdevice" & Environment.NewLine
                strSql &= " where SerialNo = '" & strImei & "'  AND cust_id= " & iCust_Id & " and device_dateship is null and tdevice.device_id=extendedwarranty.device_id" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each dtrow In dt.Rows
                    orderType = dtrow("BulkOrderType_ID")
                Next
                Return orderType
            Catch ex As Exception
                Throw ex
            Finally
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
        Public Function GettDeviceBill(ByVal Imei As String) As DataTable

            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql &= "SELECT  BillCode_id,tdevice.device_id " & Environment.NewLine
                strSql &= " FROM tdevice,tDeviceBill  " & Environment.NewLine
                strSql &= " where tdevice.device_SN = '" & Imei & "' and tdevice.device_id = tDeviceBill.device_id and device_dateship is null " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetPoNumberInfo(ByVal Imei As String) As DataTable

            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT ClaimNo,Model_id,Item_SKU FROM extendedwarranty,tdevice where serialNo ='" & Imei & "' and device_SN=serialNo and device_dateship is null"
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function CheckFlashTest(ByVal deviceSN As Long) As Boolean

            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM tdevice_test WHERE TestType='Flash' AND Device_SN IN ('" & deviceSN & "') and device_dateship is null " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetPOSeedStock(ByVal Imei As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * FROM extendedwarranty " & Environment.NewLine
                strSql &= "where   SerialNo='" & Imei & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function
        Public Function GetPalletId(ByVal strPalletName As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow
            Dim Pallett_id As Integer
            Try
                strSql = "SELECT Pallett_id FROM tpallett " & Environment.NewLine
                strSql &= "where  pallett_Name='" & strPalletName & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each dtrow In dt.Rows
                    Pallett_id = dtrow("Pallett_id")
                Next
                Return Pallett_id

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetDeviceId(ByVal strImei As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow
            Dim Device_ID As Integer
            Try
                strSql = "SELECT device_id FROM tdevice " & Environment.NewLine
                strSql &= "where  device_SN='" & strImei & "' and device_dateship is null " & Environment.NewLine
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

        Public Function GetModelSeedStock(ByVal iDevice_id As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT Model_id FROM extendedwarranty A  INNER JOIN tdevice B ON A.Device_ID=B.Device_ID  " & Environment.NewLine
                strSql &= "where  swapped_device_id=" & iDevice_id & "  " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        'Public Function GetSeedStockREFDevices(ByVal iDevice_id) As DataTable
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Try
        '        strSql = "SELECT *  FROM extendedwarranty " & Environment.NewLine
        '        strSql &= "where  SourceFile like '%CP_SeedStock_REF_devices%' and Device_id =" & iDevice_id & "  " & Environment.NewLine
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

        Public Function GetPoNumberByDeviceId(ByVal iDevice_id As Integer, ByVal iOrderType As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtREFSeedStock As DataTable
            Try
                'dtREFSeedStock = GetSeedStockREFDevices(iDevice_id)
                'If dtREFSeedStock.Rows.Count > 0 Then
                '    strSql = "SELECT ClaimNo  FROM extendedwarranty WHERE serialNo=  '" & dtREFSeedStock.Rows(0)("SerialNo") & "'and claimNo>0  " & Environment.NewLine
                'Else
                strSql = "SELECT ClaimNo  FROM extendedwarranty " & Environment.NewLine
                If iOrderType = 1 Then
                    strSql &= "where  Device_id =" & iDevice_id & "   " & Environment.NewLine
                ElseIf iOrderType = 0 Then
                    strSql &= "where  swapped_device_id=" & iDevice_id & "  " & Environment.NewLine
                End If
                'End If
                dt = Me._objDataProc.GetDataTable(strSql)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        Public Function GetWingTechShipBoxTypes(ByVal booAddSelectRow As Boolean) As DataTable
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

        Public Function GetWingTechLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
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

        Public Function GetWingTechModels(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT (Model_ID), item_Sku ,Model_Desc" & Environment.NewLine
                strSql &= " FROM extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON A.item_Sku=B.ASN_IN_SKU AND A.Cust_ID=" & iCust_ID & Environment.NewLine
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
                                           ByVal iLoc_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim iMaxNum As Integer = 0
            Dim dt As DataTable
            Try
                If iLoc_ID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CP1_Loc_ID Then
                    '******************************
                    'construct pallet name
                    '******************************
                    '*** Charles Hummer - 2-Aug-2021 **  Added "%y" to include the 2-digit year in the name
                    strDate = Generic.GetMySqlDateTime("%m%d%y")
                    If strPalletPrefix = "BER" Then
                        strPalletPrefix = "B"
                    ElseIf strPalletPrefix = "REF" Then
                        strPalletPrefix = "R"
                    ElseIf strPalletPrefix = "RUR" Then
                        strPalletPrefix = "U"
                    End If

                    '*** Charles Hummer = 2-Aug-2021 ** Changed 24CP to 95W and removed the "N" from the string
                    strPalletPrefix = "95W" & strPalletPrefix & strDate '& "N"

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

        Public Function GetWingTechOpenPallets(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
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

        Public Function GetCoopadPallettData(ByVal strPallettName As String, ByVal iCust_ID As Integer) As DataTable
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
        Public Function ReopenWingTechBoxByResetting(ByVal iPalletID As Integer, ByVal strStation As String) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tpallett, tcellopt "
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "Set tpallett.Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= ", tcellopt.WorkStation = '" & strStation & "', tcellopt.WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tcellopt.Device_ID AND tpallett.Pallett_ID = " & iPalletID & " " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is  NULL  " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 1;"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
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
        Public Function GetOEMCustomerClass(ByVal iDevice_ID As Integer, ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iOrderType As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""
            Try
                strSql = "Select ShipTo_Name from production.extendedwarranty Where Cust_ID=" & iCust_ID & " And Loc_ID=" & iLoc_ID & " " & Environment.NewLine
                If iOrderType = 1 Then
                    strSql &= "and  Device_id =" & iDevice_ID & "   " & Environment.NewLine
                Else
                    strSql &= "and  swapped_device_id=" & iDevice_ID & "  " & Environment.NewLine
                End If
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

        Public Function GetSoftVersion(ByVal iModel_id As Integer, ByVal Cust_id As Integer) As DataTable
            Dim strSql As String = ""
            Try
                'Flash Test  Pass: TestTResult ='Pass'

                strSql &= "SELECT SoftwareVersion,FILEDATE  FROM warehouse.tsoftwarematrix A " & Environment.NewLine
                strSql &= "INNER JOIN tmodel B ON A.ASN_SKU=B.Model_Desc" & Environment.NewLine
                strSql &= " WHERE B.Model_ID = " & iModel_id & " ORDER BY FileDate DESC" & Environment.NewLine
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
                strSql &= "WHERE TestType='Flash' AND B.Device_SN='" & strDevice_SN & "' and isManual=0 and Device_DateShip is null  " & Environment.NewLine
                strSql &= " ORDER BY TestDateTime DESC, mSecond DESC;" & Environment.NewLine
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
        Public Function RemoveSNfromPallet(ByVal iPallett_ID As Integer, ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update tdevice set Pallett_ID = NULL,device_DateShip=NULL, WO_ID_Out = NULL where pallett_id = " & iPallett_ID.ToString & " and device_id = " & iDevice_ID.ToString
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function CloseWingTechPallet(ByVal iCust_ID As Integer, _
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
        Public Function PrintBoxLabel(ByVal iPalletID As Integer) As Integer
            Dim strReportName As String = "WingTech_master.rpt"
            Dim strReportNameComplete As String = "WingTechINW.rpt"
            Dim strSql As String
            Dim dt, dtLabel As DataTable
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 10
            Dim rowNew As DataRow
            Dim strS As String = ""
            Dim strCol As String = "", strCol_Code As String = ""
            Dim iVal As Integer = 0

            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try

                strSql &= "SELECT retailer2, Warranty_Desc, C.Pallett_id as Pallet , pallett_Name as version ,ClaimNo as OrderNo,item_SKU as Model,C.Pallett_Qty as Qty,D.Device_SN as SN,D.Device_ID" & Environment.NewLine
                strSql &= "FROM extendedwarranty A" & Environment.NewLine
                strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql &= " inner join tdevice D ON D.device_id=A.Swapped_Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel B ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= " WHERE C.Pallett_ID =" & iPalletID & " " & Environment.NewLine
                strSql &= " UNION " & Environment.NewLine
                strSql &= " SELECT retailer2,Warranty_Desc, C.Pallett_id as Pallet , pallett_Name as version ,ClaimNo as OrderNo,item_SKU as Model,C.Pallett_Qty as Qty,D.Device_SN as SN,D.Device_ID" & Environment.NewLine
                strSql &= " FROM extendedwarranty A" & Environment.NewLine
                strSql &= " Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                strSql &= " inner join tdevice D ON D.device_id=A. Device_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON B.Model_ID=D.Model_ID" & Environment.NewLine
                strSql &= "  WHERE C.Pallett_ID =" & iPalletID & " AND   bulkordertype_id=1  ORDER BY  SN" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                'strReportName &= dt.Rows.Count.ToString & ".rpt"
                'strReportName = "WiKo_Pallet_Label BonkeTest2020.rpt"

                strSql = "SELECT" & Environment.NewLine
                strSql &= " '' as retailer2, '' as Warranty_Desc,'' as version,'' as versionCode,'' as Pallet,'' as PalletCode,'' as Model,'' as ModelCode,'' as OrderNo,'' as OrderNoCode,0 as Qty,'' as QtyCode,'' as SN1,'' as SN1Code,'' as SN2,'' as SN2Code,'' as SN3,'' as SN3Code,'' as SN4,'' as SN4Code,'' as SN5" & Environment.NewLine
                strSql &= " ,'' as SN5Code,'' as SN6,'' as SN6Code,'' as SN7,'' as SN7Code,'' as SN8,'' as SN8Code,'' as SN9,'' as SN9Code,'' as SN10,'' as SN10Code,'' as SN11,'' as SN11Code,'' as SN12,'' as SN12Code" & Environment.NewLine
                strSql &= " ,'' as SN13,'' as SN13Code,'' as SN14,'' as SN14Code,'' as SN15,'' as SN15Code,'' as SN16,'' as SN16Code,'' as SN17,'' as SN17Code,'' as SN18,'' as SN18Code,'' as SN19,'' as SN19Code" & Environment.NewLine
                strSql &= " ,'' as SN20,'' as SN20Code,'' as SN21,'' as SN21Code,'' as SN22,'' as SN22Code,'' as SN23,'' as SN23Code,'' as SN24,'' as SN24Code,'' as SN25,'' as SN25Code,'' as Other1,'' as Other1Code,0 as Qty1,'' as Qty1Code,'' as Other2,'' as Other2Code,0 as Qty2,'' as Qty2Code" & Environment.NewLine
                strSql &= " ,'' as Other3,'' as Other3Code,0 as Qty3,'' as Qty3Code,'' as Other4,'' as Other4Code,0 as Qty4,'' as Qty4Code,'' as Other5,'' as Other5Code,0 as Qty5,'' as Qty5Code Limit 0;" & Environment.NewLine

                dtLabel = Me._objDataProc.GetDataTable(strSql)

                For i = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        rowNew = dtLabel.NewRow

                        strS = dt.Rows(i).Item("retailer2")
                        rowNew("retailer2") = ReplaceChar(strS.Trim)

                        strS = dt.Rows(i).Item("Warranty_Desc")
                        rowNew("Warranty_Desc") = ReplaceChar(strS.Trim)

                        strS = dt.Rows(i).Item("Pallet")
                        rowNew("Pallet") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("PalletCode") = strS

                        strS = dt.Rows(0).Item("version")
                        rowNew("version") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("versionCode") = strS

                        strS = dt.Rows(0).Item("OrderNo")
                        rowNew("OrderNo") = ReplaceChar(strS.Trim)
                        If strS.Trim.Length > 0 Then strS = ReplaceChar(FontEncoder.Code128a(strS.Trim))
                        rowNew("OrderNoCode") = strS


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
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportNameComplete, 1)
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
                strSql = "SELECT pallett_id from tpallett Where Pallett_ReadyToShipFlg = 1 and Pallett_Name='" & Pallett_name & "'"
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

    End Class
End Namespace