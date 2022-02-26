
Option Explicit On 

Imports System.IO

Namespace Buisness
    Public Class SkyTel
        Inherits CreateRMA

        Private _objDataProc As DBQuery.DataProc

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

#Region "Properties"
#Region "-AMS"
        Public Shared ReadOnly Property AMS_CUSTOMER_ID() As Integer
            Get
                Return 14
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property AMS_LOC_ID() As Integer
            Get
                Return 19
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property AMS_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\AMS\Pallet Packing List\"
                'Return "C:\Public\Dept\AMS\Pallet Packing List\" 'for debug
            End Get
        End Property
#End Region
#Region "-SkyTel"
        '******************************************************************
        Public Shared ReadOnly Property SKYTEL_CUSTOMER_ID() As Integer
            Get
                Return 1545
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property SKYTEL_LOC_ID() As Integer
            Get
                Return 2062
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property SKYTEL_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\Skytel\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property SKYTEL_GROUPID() As Integer
            Get
                Return 83
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property SKYTEL_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "-Morris Communication"
        '******************************************************************
        Public Shared ReadOnly Property MorrisCom_CUSTOMER_ID() As Integer
            Get
                Return 2507
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property MorrisCom_LOC_ID() As Integer
            Get
                Return 3307
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property MorrisCom_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\Morris Communication\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property MorrisCom_GROUPID() As Integer
            Get
                Return 100
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property MorrisCom_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "-Propage"
        '******************************************************************
        Public Shared ReadOnly Property Propage_CUSTOMER_ID() As Integer
            Get
                Return 2508
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Propage_LOC_ID() As Integer
            Get
                Return 3308
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Propage_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\Propage\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Propage_GROUPID() As Integer
            Get
                Return 101
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Propage_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "-Aquis"
        '******************************************************************
        Public Shared ReadOnly Property Aquis_CUSTOMER_ID() As Integer
            Get
                Return 444
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Aquis_LOC_ID() As Integer
            Get
                Return 442
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Aquis_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\Aquis\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Aquis_GROUPID() As Integer
            Get
                Return 96
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Aquis_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "-Cook Pager"
        '******************************************************************
        Public Shared ReadOnly Property CookPager_CUSTOMER_ID() As Integer
            Get
                Return 2563
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CookPager_LOC_ID() As Integer
            Get
                Return 3365
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CookPager_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\CookPager\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CookPager_GROUPID() As Integer
            Get
                Return 115
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CookPager_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "-Contact Wireless"
        '******************************************************************
        Public Shared ReadOnly Property ContactWireless_CUSTOMER_ID() As Integer
            Get
                Return 2574
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ContactWireless_LOC_ID() As Integer
            Get
                Return 3377
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ContactWireless_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\ContactWireless\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ContactWireless_GROUPID() As Integer
            Get
                Return 116
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ContactWireless_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "- A-1Wireless Communications"
        '******************************************************************
        Public Shared ReadOnly Property A1WirelessComm_CUSTOMER_ID() As Integer
            Get
                Return 2593
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property A1WirelessComm_LOC_ID() As Integer
            Get
                Return 3397
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property A1WirelessComm_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\A1WirelessComm\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property A1WirelessComm_GROUPID() As Integer
            Get
                Return 117
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property A1WirelessComm_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "- ATS"
        '******************************************************************
        Public Shared ReadOnly Property ATS_CUSTOMER_ID() As Integer
            Get
                Return 2607
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ATS_LOC_ID() As Integer
            Get
                Return 3414
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ATS_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\ATS\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ATS_GROUPID() As Integer
            Get
                Return 129
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property ATS_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "- Critical Alert"
        '******************************************************************
        Public Shared ReadOnly Property CriticalAlert_CUSTOMER_ID() As Integer
            Get
                Return 2599
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CriticalAlertNorth_LOC_ID() As Integer
            Get
                Return 3404
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CriticalAlertSouth_LOC_ID() As Integer
            Get
                Return 3405
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CriticalAlert_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\CriticalAlert\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CriticalAlert_GROUPID() As Integer
            Get
                Return 121
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property CriticalAlert_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#Region "- Other messaging Customers"
        '******************************************************************
        Public Shared ReadOnly Property Anna_CUSTOMER_ID() As Integer
            Get
                Return 2601
            End Get
        End Property
        Public Shared ReadOnly Property Lahey_CUSTOMER_ID() As Integer
            Get
                Return 2602
            End Get
        End Property
        Public Shared ReadOnly Property Masco_CUSTOMER_ID() As Integer
            Get
                Return 2603
            End Get
        End Property
        Public Shared ReadOnly Property Franciscan_CUSTOMER_ID() As Integer
            Get
                Return 2604
            End Get
        End Property
        Public Shared ReadOnly Property Maine_CUSTOMER_ID() As Integer
            Get
                Return 2605
            End Get
        End Property
        Public Shared ReadOnly Property SMHC_CUSTOMER_ID() As Integer
            Get
                Return 2606
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property Anna_LOC_ID() As Integer
            Get
                Return 3408
            End Get
        End Property
        Public Shared ReadOnly Property Lahey_LOC_ID() As Integer
            Get
                Return 3409
            End Get
        End Property
        Public Shared ReadOnly Property Masco_LOC_ID() As Integer
            Get
                Return 3410
            End Get
        End Property
        Public Shared ReadOnly Property Franciscan_LOC_ID() As Integer
            Get
                Return 3411
            End Get
        End Property
        Public Shared ReadOnly Property Maine_LOC_ID() As Integer
            Get
                Return 3412
            End Get
        End Property
        Public Shared ReadOnly Property SMHC_LOC_ID() As Integer
            Get
                Return 3413
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property Anna_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\OtherMessageCustomers\Anna\Pallet Packing List\"
            End Get
        End Property
        Public Shared ReadOnly Property Lahey_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\OtherMessageCustomers\Lahey\Pallet Packing List\"
            End Get
        End Property
        Public Shared ReadOnly Property Masco_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\OtherMessageCustomers\Masco\Pallet Packing List\"
            End Get
        End Property
        Public Shared ReadOnly Property Franciscan_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\OtherMessageCustomers\Franciscan\Pallet Packing List\"
            End Get
        End Property
        Public Shared ReadOnly Property Maine_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\OtherMessageCustomers\Maine\Pallet Packing List\"
            End Get
        End Property
        Public Shared ReadOnly Property SMHC_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\OtherMessageCustomers\SMHC\Pallet Packing List\"
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property Anna_GROUPID() As Integer
            Get
                Return 123
            End Get
        End Property
        Public Shared ReadOnly Property Lahey_GROUPID() As Integer
            Get
                Return 124
            End Get
        End Property
        Public Shared ReadOnly Property Masco_GROUPID() As Integer
            Get
                Return 125
            End Get
        End Property
        Public Shared ReadOnly Property Franciscan_GROUPID() As Integer
            Get
                Return 126
            End Get
        End Property
        Public Shared ReadOnly Property Maine_GROUPID() As Integer
            Get
                Return 127
            End Get
        End Property
        Public Shared ReadOnly Property SMHC_GROUPID() As Integer
            Get
                Return 128
            End Get
        End Property

        '******************************************************************
        Public Shared ReadOnly Property Anna_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property Lahey_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property Masco_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property Franciscan_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property Maine_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        Public Shared ReadOnly Property SMHC_PRODID() As Integer
            Get
                Return 1
            End Get
        End Property
        '******************************************************************
#End Region
#End Region

#Region "Create RMA/WO"
        '******************************************************************
        Public Function GetSkyTelRMA(ByVal iMenuCustID As Integer, ByVal strCustWO As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql &= "SELECT WO_ID, tworkorder.Loc_ID, Cust_Name1, Loc_Name, WO_Quantity, WO_RAQnty, Prod_ID, PO_ID, WO_CameWithFile, WO_Closed " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & strCustWO & "' " & Environment.NewLine
                strSql &= "AND tlocation.Cust_ID = " & iMenuCustID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("WO ID is missing please contact your supervisor for advices.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("WO ID existed twice in the system please contact IT.")
                ElseIf dt.Rows(0)("WO_Closed") = 1 Then
                    Throw New Exception("This RMA/WO is already closed.")
                Else
                    Return dt
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function
#End Region

#Region "Receiving"
        '******************************************************************
        Public Function ReceiveDevice(ByVal iLocID As Integer, _
                                      ByVal strWOName As String, _
                                      ByVal iWOID As Integer, _
                                      ByVal iTrayID As Integer, _
                                      ByVal iModelID As Integer, _
                                      ByVal strFreqNum As String, _
                                      ByVal iFreqID As Integer, _
                                      ByVal strBaudDesc As String, _
                                      ByVal iBaudID As Integer, _
                                      ByVal strCap As String, _
                                      ByVal strSN As String, _
                                      ByVal iCameWithFile As Integer, _
                                      ByVal iShiftID As Integer, _
                                      ByVal iUsrID As Integer, _
                                      ByVal iSDID As Integer) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim strWrkDate As String = ""
            Dim iCnt As Integer = 0
            Dim iDeviceID As Integer = 0
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim strSku As String = ""

            Try
                'define sku length
                Select Case iBaudID
                    Case 1  'POCSAG 512
                        strSku = "XXFXXXXXXX"
                    Case 2  'POCSAG 1200
                        strSku = "XXTXXXXXXX"
                    Case 3  'POCSAG 2400
                        strSku = "XX4XXXXXXX"
                    Case 4  'FLEX
                        strSku = "XXXXXXFLXX"
                    Case Else
                        Throw New Exception("System can not define sku length for the unit.")
                End Select

                strWrkDate = PSS.Data.Buisness.Generic.GetWorkDate(iShiftID)
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                'Writer device to tdevice table
                objRec = New PSS.Data.Production.Receiving()
                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iCnt, iTrayID, iLocID, iWOID, iModelID, iShiftID, , , , )
                If iDeviceID = 0 Then
                    Throw New Exception("System has failed to create Device ID.")
                End If

                'write device to tmessdata table
                strSql = "INSERT INTO tmessdata " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "capcode, " & Environment.NewLine
                strSql &= "SKU, " & Environment.NewLine
                strSql &= "baud_id, " & Environment.NewLine
                strSql &= "freq_id, " & Environment.NewLine
                strSql &= "CameWithFileFlag, " & Environment.NewLine
                strSql &= "wo_id, " & Environment.NewLine
                strSql &= "device_id, " & Environment.NewLine
                strSql &= "wipowner_id, " & Environment.NewLine
                strSql &= "wipowner_EntryDt " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "'" & strCap & "', " & Environment.NewLine
                strSql &= "'" & strSku & "', " & Environment.NewLine
                strSql &= iBaudID & ", " & Environment.NewLine
                strSql &= iFreqID & ", " & Environment.NewLine
                strSql &= iCameWithFile & ", " & Environment.NewLine
                strSql &= iWOID & ", " & Environment.NewLine
                strSql &= iDeviceID & Environment.NewLine
                strSql &= ", 1 " & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ");"

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to write data into messaging table.")

                If iSDID > 0 Then
                    strSql = "UPDATE t1545data SET Device_ID = " & iDeviceID & ", RecDate = now(), RecUserID = " & iUsrID & " WHERE sd_id = " & iSDID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to write Device ID into Skytel table.")
                Else
                    strSql = "INSERT INTO t1545data ( " & Environment.NewLine
                    strSql &= "sd_ShipNo " & Environment.NewLine
                    strSql &= ", sd_FreqNo " & Environment.NewLine
                    strSql &= ", sd_CapCode " & Environment.NewLine
                    strSql &= ", sd_SN " & Environment.NewLine
                    strSql &= ", sd_BaudDesc " & Environment.NewLine
                    strSql &= ", freq_id " & Environment.NewLine
                    strSql &= ", baud_id " & Environment.NewLine
                    strSql &= ", LoadDataUserID " & Environment.NewLine
                    strSql &= ", LoadDataDate " & Environment.NewLine
                    strSql &= ", LoadTime " & Environment.NewLine
                    strSql &= ", Device_ID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "  '" & strWOName & "'" & Environment.NewLine
                    strSql &= ", '" & strFreqNum & "' " & Environment.NewLine
                    strSql &= ", '" & strCap & "' " & Environment.NewLine
                    strSql &= ", '" & strSN & "'" & Environment.NewLine
                    strSql &= ", '" & strBaudDesc & "' " & Environment.NewLine
                    strSql &= ", " & iFreqID & Environment.NewLine
                    strSql &= ", " & iBaudID & Environment.NewLine
                    strSql &= ", " & iUsrID & Environment.NewLine
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", Now() " & Environment.NewLine
                    strSql &= ", " & iDeviceID & Environment.NewLine
                    strSql &= ")" & Environment.NewLine

                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to write new record into Skytel table.")
                End If

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function IsAmericanMessagingSN_InWIP_AllCustomers(ByVal strDeviceSN As String, Optional ByRef stCustomerOfDupSN As String = "") As Boolean
            'No duplicates of SN for customers, AMS, Aquis, Moriiss Comm., Propage, Cook Pager, for prod_id=1, in WIP (not shipped yet)
            Dim strSql As String
            Dim dt As DataTable, row As DataRow
            Dim strCustomerIDs As String
            Dim i As Integer = 0

            Try

                strCustomerIDs = Me.AMS_CUSTOMER_ID & "," : strCustomerIDs &= Me.Aquis_CUSTOMER_ID & ","
                strCustomerIDs &= Me.MorrisCom_CUSTOMER_ID & "," : strCustomerIDs &= Me.Propage_CUSTOMER_ID & ","
                strCustomerIDs &= Me.CookPager_CUSTOMER_ID & "," : strCustomerIDs &= Me.CriticalAlert_CUSTOMER_ID

                strDeviceSN = strDeviceSN.Replace("'", "''")

                strSql = "select device_ID,device_SN,tcustomer.Cust_ID,tcustomer.Cust_Name1,tlocation.Loc_Name" & Environment.NewLine
                strSql &= ",if(tcustomer.Cust_ID=" & Me.CriticalAlert_CUSTOMER_ID & ",  CONCAT(tcustomer.Cust_Name1, ' - ', tlocation.Loc_Name), tcustomer.Cust_Name1) as 'Customer'" & Environment.NewLine
                strSql &= ",tdevice.model_id,tmodel.model_desc,prod_id,WO_ID" & Environment.NewLine
                strSql &= " from tdevice" & Environment.NewLine
                strSql &= " inner join tmodel on tdevice.model_ID=tmodel.model_id" & Environment.NewLine
                strSql &= " inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                strSql &= " inner join tcustomer on  tlocation.Cust_ID= tcustomer.Cust_ID" & Environment.NewLine
                strSql &= " where device_sn = '" & strDeviceSN & "'" & Environment.NewLine
                strSql &= " and tcustomer.cust_id in (" & strCustomerIDs & ")" & Environment.NewLine
                strSql &= " and prod_id=1" & Environment.NewLine
                strSql &= " and (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '');" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then 'found duplicates
                    For Each row In dt.Rows
                        If i = 0 Then
                            stCustomerOfDupSN = row("Customer")
                        Else
                            stCustomerOfDupSN &= ", " & row("Customer")
                        End If
                        i += 1
                    Next
                    Return True
                Else 'no duplicates
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCustomerLocName(ByVal iLoc_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try
                strSql = "SELECT * FROM tlocation WHERE Loc_ID = " & iLoc_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strRet = dt.Rows(0).Item("Loc_Name")
                End If

                Return strRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Build Ship Box & Ship Box"
        '******************************************************************
        Public Function GetMessModelsWithMotoSku() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tmodel WHERE Prod_ID = 1 AND Model_MotoSku is not null ORDER BY Model_Desc " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "Select A.Loc_ID,CONCAT_WS(' - ',B.Cust_Name1, A.Loc_Name)  as  'Cust_Loc',B.Cust_Name1,A.Loc_Name from tlocation A" & Environment.NewLine
                strSql &= " inner join tcustomer B on A.Cust_ID=B.Cust_ID where B.cust_ID=" & iCust_ID & " Order By Loc_Name;"
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--", "0"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetLocationNameByLocID(ByVal iLoc_ID As Integer) As String
            Dim strSql As String, strRet As String = ""
            Dim dt As DataTable
            Try
                strSql = "Select Loc_Name from tlocation" & Environment.NewLine
                strSql &= "where Loc_ID=" & iLoc_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then strRet = dt.Rows(0).Item("Loc_Name")
                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetSkyTelShipBoxTypes() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            'Dim drNewRow As DataRow

            Try
                strSql = "SELECT 0 as 'ShipTypeID', 'REFURBISHED' as 'ShipTypeDesc' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                'drNewRow = dt.NewRow
                'drNewRow("ShipTypeID") = 1
                'drNewRow("ShipTypeDesc") = "DBR"
                'dt.Rows.Add(drNewRow)

                'drNewRow = Nothing
                'drNewRow = dt.NewRow
                'drNewRow("ShipTypeID") = 2
                'drNewRow("ShipTypeDesc") = "NER"
                'dt.Rows.Add(drNewRow)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                'drNewRow = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenPallets_OtherCustomer(ByVal strPalletStartName As String, _
                                                     ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim dt, dt2 As DataTable
            Dim row As DataRow
            Dim iPallett_ID As Integer = 0

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, Model_Desc, Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as 'Box Name' " & Environment.NewLine
                strSql &= ",'' as 'Baud',0 as 'Baud_ID'" & Environment.NewLine
                strSql &= ", if(freq_id is null, 0, freq_id) as freq_id " & Environment.NewLine
                strSql &= ", if(freq_Number is null,'', freq_Number) as freq_Number " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lfrequency ON tpallett.Pallet_SkuLen = lfrequency.freq_id " & Environment.NewLine
                strSql &= "WHERE tpallett.cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND pallett_name like '" & strPalletStartName & "%' " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "Order by Pallett_id Desc"

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenPallets(ByVal iModelID As Integer, _
                                       ByVal strPalletStartName As String, _
                                       ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Dim dt, dt2 As DataTable
            Dim row As DataRow
            Dim iPallett_ID As Integer = 0

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, Model_Desc, Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as 'Box Name' " & Environment.NewLine
                strSql &= ",'' as 'Baud',0 as 'Baud_ID'" & Environment.NewLine
                strSql &= ", if(freq_id is null, 0, freq_id) as freq_id " & Environment.NewLine
                strSql &= ", if(freq_Number is null,'', freq_Number) as freq_Number " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lfrequency ON tpallett.Pallet_SkuLen = lfrequency.freq_id " & Environment.NewLine
                strSql &= "WHERE tpallett.cust_ID = " & iCustID & Environment.NewLine '& Me.SKYTEL_CUSTOMER_ID.ToString & Environment.NewLine
                strSql &= "AND pallett_name like '" & strPalletStartName & "%' " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "AND tpallett.Model_ID = " & iModelID.ToString & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "Order by Pallett_id Desc"

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    iPallett_ID = row("Pallett_ID")
                    strSql = "SELECT Distinct B.Baud_Number,B.Baud_ID,A.Pallett_ID FROM tamsforecastedship_special A" & Environment.NewLine
                    strSql &= " INNER JOIN lBaud B on A.Baud_ID=B.Baud_ID" & Environment.NewLine
                    strSql &= " WHERE Pallett_ID=" & iPallett_ID & ";" & Environment.NewLine
                    dt2 = Me._objDataProc.GetDataTable(strSql)

                    If dt2.Rows.Count = 1 Then  'should be 1 row
                        row.BeginEdit()
                        row("Baud") = dt2.Rows(0).Item("Baud_Number")
                        row("Baud_ID") = dt2.Rows(0).Item("Baud_ID")
                        row.AcceptChanges()
                    ElseIf dt2.Rows.Count > 1 Then
                        Throw New Exception("Multiple bauds for pallet ID " & iPallett_ID.ToString & " in the table 'tamsforecastedship_special'")
                    End If
                Next

                Return dt

                ' Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateBoxID(ByVal iModelID As Integer, _
                                    ByVal iBoxType As Integer, _
                                    ByVal iFreqID As String, _
                                    ByVal strPalletPrefix As String, _
                                    ByVal iCustID As Integer, _
                                    Optional ByVal iLocID As Integer = 0) As Integer

            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim iPalletID As Integer = 0
            Dim iLocationID As Integer = 0

            Try
                'iLocationID = Generic.GetLocID(iCustID)
                'Me.GetCustomerLocationID(iCustID)
                If iCustID = Me.CriticalAlert_CUSTOMER_ID Then
                    iLocationID = Generic.GetLocID(iCustID, iLocID)
                Else
                    iLocationID = Generic.GetLocID(iCustID)
                End If

                If iLocationID = 0 Then Throw New Exception("Location for this customer is missing.")

                strDate = strDate.Replace(" ", "")
                '******************************
                'construct pallet name
                '******************************
                strDate = Generic.GetMySqlDateTime("%y%m%d")

                If iCustID = Me.CriticalAlert_CUSTOMER_ID AndAlso iLocID = Me.CriticalAlertNorth_LOC_ID Then
                    strPalletPrefix = strPalletPrefix + strDate & "NN"
                    strPalletName = Me.DefinePalletName(strPalletPrefix, iCustID, iLocationID)
                ElseIf iCustID = Me.CriticalAlert_CUSTOMER_ID AndAlso iLocID = Me.CriticalAlertSouth_LOC_ID Then
                    strPalletPrefix = strPalletPrefix + strDate & "SN"
                    strPalletName = Me.DefinePalletName(strPalletPrefix, iCustID, iLocationID)
                Else
                    strPalletPrefix = strPalletPrefix + strDate & "N"
                    strPalletName = Me.DefinePalletName(strPalletPrefix, iCustID)
                End If

                '******************************
                'check for duplicate pallet
                '******************************
                strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLocationID ' Me.SKYTEL_LOC_ID
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Pallett_Name " & Environment.NewLine
                strSql &= ", Pallet_SkuLen " & Environment.NewLine
                strSql &= ", Pallet_ShipType " & Environment.NewLine
                strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", '" & iFreqID & "' " & Environment.NewLine
                strSql &= ", " & iBoxType & Environment.NewLine
                strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iCustID & " " & Environment.NewLine ' Me.SKYTEL_CUSTOMER_ID & " " & Environment.NewLine
                strSql &= ", " & iLocationID & ");" & Environment.NewLine ' Me.SKYTEL_LOC_ID & ");" & Environment.NewLine
                iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then iPalletID = Me.GetSkyTelPalletID(strPalletName, iCustID, iLocationID)

                '******************************

                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function DefinePalletName(ByVal strPalletPrefix As String, ByVal iCustID As Integer, Optional ByVal iLocID As Integer = 0) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix
            Dim iLocation As Integer

            Try
                If iCustID = Me.CriticalAlert_CUSTOMER_ID Then
                    iLocation = Generic.GetLocID(iCustID, iLocID)
                Else
                    iLocation = Generic.GetLocID(iCustID)
                End If

                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine '& Me.SKYTEL_CUSTOMER_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocation & Environment.NewLine  'Me.SKYTEL_LOC_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        If dt.Rows(0)("Pallett_Num") > 999 Then Throw New Exception("Pallet sequence number hits the limit 999!")
                        strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "000")
                    Else
                        strPallett_Name &= "001"
                    End If
                Else
                    strPallett_Name &= "001"
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetSkyTelPalletID(ByVal strPalletName As String, ByVal iCustID As Integer, ByVal iLocID As Integer) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                strSQL = "SELECT Pallett_ID " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID 'Me.SKYTEL_CUSTOMER_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID 'Me.SKYTEL_LOC_ID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate Box """ & strPalletName & """. Please contact IT.")
                ElseIf dt.Rows.Count = 0 Then
                    Throw New Exception("Box ID is missing for box  """ & strPalletName & """. Please contact IT.")
                Else
                    iPalletID = dt.Rows(0)("Pallett_ID")
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsOpenBoxExisted(ByVal iModelID As Integer, _
                                         ByVal iBoxType As Integer, _
                                         ByVal iMchCCGrpID As Integer, _
                                         ByVal iCustID As Integer) As Boolean
            Dim strSQL As String
            Dim dt As DataTable
            Dim iLocationID As Integer

            Try
                iLocationID = Generic.GetLocID(iCustID)

                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & iCustID & Environment.NewLine '& Me.SKYTEL_CUSTOMER_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocationID & Environment.NewLine  'Me.SKYTEL_LOC_ID & Environment.NewLine
                strSQL &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSQL &= "AND Pallett_Name like '" & iMchCCGrpID & "%' " & Environment.NewLine
                strSQL &= "AND Pallet_ShipType  = " & iBoxType & Environment.NewLine
                strSQL &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsOpenBoxExisted_MessagingOtherCustomer(ByVal iBoxType As Integer, _
                                                                ByVal PreFixPallettName As String, _
                                                                ByVal iCustID As Integer, _
                                                                ByVal iLocID As Integer) As Boolean
            Dim strSQL As String
            Dim dt, dt2 As DataTable
            Dim iPalletID As Integer = 0
            Dim arrLst_Regular As New ArrayList()
            Dim arrLst_Special As New ArrayList()
            Dim arrLst_Special_Baud As New ArrayList()
            Dim row As DataRow
            Dim i As Integer = 0

            Try

                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                strSQL &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSQL &= "AND Pallett_Name like '" & PreFixPallettName & "%' " & Environment.NewLine
                strSQL &= "AND Pallet_ShipType  = " & iBoxType & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsOpenBoxExisted_Messaging(ByVal iModelID As Integer, _
                                         ByVal iBoxType As Integer, _
                                         ByVal PreFixPallettName As String, _
                                         ByVal iCustID As Integer, _
                                         ByVal iBaudID As Integer, _
                                         ByVal bBoxForSpecialRequestedQty As Boolean, _
                                         Optional ByVal iLocID As Integer = 0) As Boolean
            Dim strSQL As String
            Dim dt, dt2 As DataTable
            Dim iLocationID As Integer
            Dim iPalletID As Integer = 0
            Dim arrLst_Regular As New ArrayList()
            Dim arrLst_Special As New ArrayList()
            Dim arrLst_Special_Baud As New ArrayList()
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                If iCustID = Me.CriticalAlert_CUSTOMER_ID Then
                    iLocationID = Generic.GetLocID(iCustID, iLocID)
                Else
                    iLocationID = Generic.GetLocID(iCustID)
                End If

                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocationID & Environment.NewLine
                strSQL &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSQL &= "AND Pallett_Name like '" & PreFixPallettName & "%' " & Environment.NewLine
                strSQL &= "AND Pallet_ShipType  = " & iBoxType & Environment.NewLine
                strSQL &= "AND Model_ID = " & iModelID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                If iBoxType > 0 Then 'DBR, NER
                    If dt.Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Else 'Refurbished
                    For Each row In dt.Rows
                        iPalletID = row("Pallett_ID")
                        strSQL = "SELECT * FROM tamsforecastedship_special WHERE Pallett_ID=" & iPalletID
                        dt2 = Me._objDataProc.GetDataTable(strSQL)
                        If dt2.Rows.Count > 0 Then
                            arrLst_Special.Add(iPalletID) : arrLst_Special_Baud.Add(dt2.Rows(0).Item("Baud_ID"))
                        Else
                            arrLst_Regular.Add(iPalletID)
                        End If
                    Next

                    If bBoxForSpecialRequestedQty Then
                        If arrLst_Special.Count > 0 Then
                            For i = 0 To arrLst_Special.Count - 1
                                If arrLst_Special_Baud(i) = iBaudID Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Next
                        Else
                            Return False
                        End If
                    Else
                        If arrLst_Regular.Count > 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If



                'If dt.Rows.Count > 0 Then
                '    Return True
                'Else
                '    Return False
                'End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceInfoInWIP(ByVal strSN As String, _
                                           ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim booPalletClosed As Boolean = False

            Try
                strSql = "SELECT tdevice.* " & Environment.NewLine
                strSql &= ", if(freq_id is null, '', freq_id) as freq_id " & Environment.NewLine
                strSql &= ", if(baud_id is null, '', baud_id) as baud_id " & Environment.NewLine
                strSql &= ", if(capcode is null, '', capcode) as capcode " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND (Device_DateShip is null OR Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip  = '') " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & iLocID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Public Function CheckDeviceShipType(ByVal iPallet_ShipType As Integer, ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                CheckDeviceShipType = False

                strSql = "SELECT DISTINCT BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY lbillcodes.BillCode_Rule " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    Throw New Exception("System could not define Billcode rule. Please verify device's billing.")
                Else
                    If iPallet_ShipType = 0 Then    'REFURBISHED
                        If dt.Select("BillCode_Rule = 1").Length > 0 Then
                            Throw New Exception("This is an DBR unit can't put on Refurbished box.")
                        ElseIf dt.Select("BillCode_Rule = 2").Length > 0 Then
                            Throw New Exception("This is an NER unit can't put on Refurbished box.")
                        End If
                    ElseIf iPallet_ShipType = 1 Then    'DBR
                        If dt.Select("BillCode_Rule = 0 OR BillCode_Rule = 4 or BillCode_Rule = 6 or BillCode_Rule = 7").Length > 0 Then
                            Throw New Exception("This is an Refurbished unit can't put on DBR box.")
                        ElseIf dt.Select("BillCode_Rule = 2").Length > 0 Then
                            Throw New Exception("This is an NER unit can't put on DBR box.")
                        ElseIf Generic.GetDevicePartsCount(iDeviceID) > 0 Then
                            Throw New Exception("This unit has parts. You must remove all before add to DBR box.")
                        End If
                    ElseIf iPallet_ShipType = 2 Then    'NER
                        If dt.Select("BillCode_Rule = 0 OR BillCode_Rule = 4 or BillCode_Rule = 6 or BillCode_Rule = 7").Length > 0 Then
                            Throw New Exception("This is an Refurbished unit can't put on NER box.")
                        ElseIf dt.Select("BillCode_Rule = 1").Length > 0 Then
                            Throw New Exception("This is an DBR unit can't put on NER box.")
                        ElseIf Generic.GetDevicePartsCount(iDeviceID) > 0 Then
                            Throw New Exception("This unit has parts. You must remove all before add to NER box.")
                        End If
                    Else
                        Throw New Exception("Can't define box type.")
                    End If
                End If

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Shared Function CreateShipManifestReport(ByVal iPalletID As Integer, ByVal strFileName As String, _
                                                        ByVal strRptFilePath As String, ByVal strManifestRptTitle As String, _
                                                        ByVal booPrintRpt As Boolean, ByVal iPalletShipType As Integer) As Integer
            Dim objDataProc As DBQuery.DataProc
            Dim strSql, strCurDate As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strCurDate = Format(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)), "MM/dd/yyyy")

                strSql = "SELECT DISTINCT D.Model_Desc as Model, A.Device_SN AS SN, CONCAT('*', A.Device_SN, '*') AS 'SN Barcode', IFNULL(C.DCode_LDesc, 'None Specified') AS 'DBR Reason', Date_Format(A.Device_DateShip, '%m/%d/%Y') AS 'Ship Date' " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tmodel D ON A.Model_ID = D.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicecodes B ON B.Device_ID = A.Device_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail C ON C.DCode_ID = B.DCode_ID" & Environment.NewLine
                strSql &= "WHERE A.Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= "ORDER BY D.Model_Desc, A.Device_SN, A.Device_DateShip DESC"
                dt = objDataProc.GetDataTable(strSql)

                If iPalletShipType = 0 Then
                    dt.Columns.Remove("DBR Reason") : dt.AcceptChanges()
                End If

                objExcelRpt = New Data.ExcelReports()

                objExcelRpt.RunAMManifestReport(dt, strFileName, strRptFilePath, strManifestRptTitle, True, booPrintRpt)

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing : objExcelRpt = Nothing
                Generic.DisposeDT(dt)

                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Function

        '******************************************************************
        Private Shared Sub CreateTabDelimitedFile(ByVal dt As DataTable, ByVal strRptFilePath As String, ByVal strFileName As String)
            Dim strTabDelimitedData, strHeadder As String
            Dim i, j As Integer

            Try
                strTabDelimitedData = "" : strHeadder = ""
                If Not Directory.Exists(strRptFilePath) Then Directory.CreateDirectory(strRptFilePath)

                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        If i = 0 Then
                            If strHeadder.Trim.Length > 0 Then strHeadder &= vbTab
                            strHeadder &= dt.Columns(j).Caption
                        End If

                        'Data
                        If j > 0 Then strTabDelimitedData &= vbTab
                        strTabDelimitedData &= dt.Rows(i)(j).ToString
                    Next j
                    strTabDelimitedData &= vbCrLf
                Next i

                If File.Exists(strRptFilePath & strFileName & ".txt") Then Kill(strRptFilePath & strFileName & ".txt")
                FileOpen(1, strRptFilePath & strFileName & ".txt", OpenMode.Append)   'Open TXT file
                PrintLine(1, strHeadder & vbCrLf & strTabDelimitedData)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Reset()
            End Try
        End Sub

        '******************************************************************
        Private Shared Sub NAR(ByRef o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch ex As Exception
                Throw ex
            Finally
                o = Nothing
            End Try
        End Sub

        '******************************************************************
        Public Function GetFreq(ByRef dtExcelSNs As DataTable, _
                                ByVal iFreqID As Integer, _
                                ByVal strColName As String, _
                                ByVal iLocID As Integer) As Integer
            Try
                Dim strsql As String = ""
                Dim dt1 As DataTable
                Dim R1 As DataRow
                Dim i As Integer = 0

                Try
                    For Each R1 In dtExcelSNs.Rows
                        '***************************
                        strsql = ""
                        strsql = "SELECT Device_SN, Device_daterec, freq_Number, tmessdata.freq_id " & Environment.NewLine
                        strsql &= "FROM tdevice " & Environment.NewLine
                        strsql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                        strsql &= "INNER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                        strsql &= "WHERE device_sn = '" & Trim(R1(strColName)) & "' " & Environment.NewLine
                        strsql += " AND tdevice.loc_id = " & iLocID & Environment.NewLine
                        strsql += " AND device_dateship is null AND Device_Datebill is not null AND Device_datebill <> '0000-00-00 00:00:00' AND device_invoice = 0 " & Environment.NewLine
                        strsql += " Order by Device_daterec Desc;"

                        dt1 = Me._objDataProc.GetDataTable(strsql)
                        If dt1.Rows.Count = 0 Then
                            Throw New Exception("No devices found for the criterion(Validate Frequency).")
                        ElseIf dt1.Rows.Count > 1 Then
                            Throw New Exception("Device listed more than one without ship date(Validate Frequency).")
                        Else
                            If iFreqID.ToString.Trim <> dt1.Rows(0)("freq_id") Then
                                R1("SKU_Number") = dt1.Rows(0)("freq_Number")
                            End If
                            R1.AcceptChanges()
                            dtExcelSNs.AcceptChanges()
                            i += 1
                        End If

                        '***************************
                        If Not IsNothing(dt1) Then
                            dt1.Dispose()
                            dt1 = Nothing
                        End If
                        '***************************
                    Next R1

                    Return i
                Catch ex As Exception
                    Throw New Exception("GetFreq(): " & Environment.NewLine & ex.Message.ToString)
                Finally
                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                End Try
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        '******************************************************************
        Public Function GetSkyTelPallet(ByVal strPallet As String, ByVal iCustID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * FROM tpallett " & Environment.NewLine
                strSql &= "WHERE pallett_name = '" & strPallet & "' " & Environment.NewLine
                strSql &= "AND cust_id = " & iCustID & Environment.NewLine ' & SkyTel.SKYTEL_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDevicesByPalletID(ByVal iCustID As Integer, ByVal iPalletID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tpallett B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
                strSql &= " WHERE B.pallett_ID =" & iPalletID & " AND C.Cust_ID=" & iCustID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDevRcvdByWO(ByVal iWOID As Integer, _
                                       ByVal strWOName As String, _
                                       ByVal iCameWithFile As Integer) As DataTable
            Dim strSql As String

            Try
                If iCameWithFile = 0 Then
                    strSql = "SELECT Device_SN as 'SN', Device_RecWorkDate as 'Rcvg Date' " & Environment.NewLine
                    strSql &= ", if(freq_Number is null, '', freq_Number) as 'Frequency' " & Environment.NewLine
                    strSql &= ", if(capcode is null, '', capcode) as 'Capcode' " & Environment.NewLine
                    strSql &= ", if(baud_Number is null, '', baud_Number) as 'Baud Rate' " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lbaud ON tmessdata.baud_id = lbaud.baud_id " & Environment.NewLine
                    strSql &= "WHERE tdevice.WO_ID = " & iWOID & " " & Environment.NewLine
                    strSql &= "ORDER BY tdevice.Device_ID "
                Else
                    strSql = "SELECT sd_SN as 'SN' " & Environment.NewLine
                    strSql &= ", if(Device_RecWorkDate is null, '', Device_RecWorkDate) as 'Rcv Date' " & Environment.NewLine
                    strSql &= ", sd_FreqNo as 'Frequency' " & Environment.NewLine
                    strSql &= ", sd_CapCode as 'Capcode' " & Environment.NewLine
                    strSql &= ", if(baud_Number is null, '', baud_Number) as 'Baud Rate' " & Environment.NewLine
                    strSql &= ", if(sd_BlankSN = 0, 'NO', 'YES' ) as 'No SN' " & Environment.NewLine
                    strSql &= ", if(sd_DuplSN = 0, 'NO', 'YES' ) as 'Dupl SN' " & Environment.NewLine
                    strSql &= ", if(sd_NoBaud = 0, 'NO', 'YES' ) as 'No Baud' " & Environment.NewLine
                    strSql &= ", if(sd_NoCapcode = 0, 'NO', 'YES' ) as 'No Cap' " & Environment.NewLine
                    strSql &= ", if(sd_NoFreq = 0, 'NO', 'YES' ) as 'No Freq' " & Environment.NewLine
                    strSql &= "FROM t1545data " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tdevice ON t1545data.Device_ID = tdevice.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lbaud ON t1545data.baud_id = lbaud.baud_id " & Environment.NewLine
                    strSql &= "WHERE t1545data.sd_ShipNo = '" & strWOName & "' " & Environment.NewLine
                    strSql &= "ORDER BY t1545data.sd_id "
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetFileData(ByVal strRMA As String, ByVal strSN As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM t1545data " & Environment.NewLine
                strSql &= "WHERE sd_sn = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND sd_ShipNo = '" & strRMA & "' " & Environment.NewLine
                strSql &= "AND sd_DuplSN = 0 " & Environment.NewLine
                strSql &= "ORDER BY sd_id "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDiscrepancyUnits(ByVal strRMA As String) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT sd_id, sd_SN as 'SN' " & Environment.NewLine
                strSql &= ", if(RecDate  is null, '', RecDate ) as 'Rcv Date' " & Environment.NewLine
                strSql &= ", sd_FreqNo as 'Frequency' " & Environment.NewLine
                strSql &= ", sd_CapCode as 'Capcode' " & Environment.NewLine
                strSql &= ", if(baud_Number is null, '', baud_Number) as 'Baud' " & Environment.NewLine
                strSql &= ", if(sd_BlankSN = 0, 'NO', 'YES' ) as 'No SN' " & Environment.NewLine
                strSql &= ", if(sd_DuplSN = 0, 'NO', 'YES' ) as 'Dupl SN' " & Environment.NewLine
                strSql &= ", if(sd_NoBaud = 0, 'NO', 'YES' ) as 'No Baud' " & Environment.NewLine
                strSql &= ", if(sd_NoCapcode = 0, 'NO', 'YES' ) as 'No Cap' " & Environment.NewLine
                strSql &= ", if(sd_NoFreq = 0, 'NO', 'YES' ) as 'No Freq' " & Environment.NewLine
                strSql &= "FROM t1545data " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lbaud ON t1545data.baud_id = lbaud.baud_id " & Environment.NewLine
                strSql &= "WHERE t1545data.sd_ShipNo = '" & strRMA & "' " & Environment.NewLine
                strSql &= "AND (sd_NoFreq > 0  OR sd_NoCapcode > 0 OR sd_NoBaud > 0 OR sd_DuplSN > 0  OR sd_BlankSN > 0 ) " & Environment.NewLine
                strSql &= "ORDER BY t1545data.sd_id "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetPalletNamePrefixStr(ByVal iCustomerID As Integer) As String
            'strPrefix must be an unique: first 2 strings of column 'Pallet_Name' in the table tPallett
            Dim strPrefix As String = String.Empty
            Try
                strPrefix = iCustomerID.ToString.PadLeft(5, "0")
                'Select Case iCustomerID
                '    Case Me.SKYTEL_CUSTOMER_ID
                '        strPrefix = "SK"
                '    Case Me.MorrisCom_CUSTOMER_ID
                '        strPrefix = "MR"
                '    Case Me.Propage_CUSTOMER_ID
                '        strPrefix = "PR"
                '    Case Me.Aquis_CUSTOMER_ID
                '        strPrefix = "AQ"
                '    Case Me.CookPager_CUSTOMER_ID
                '        strPrefix = "CP"
                '    Case Me.AMS_CUSTOMER_ID
                '        strPrefix = "AM"
                'End Select
                Return strPrefix
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetManifestDir4Report(ByVal iCustomerID As Integer) As String
            Dim strPath As String = String.Empty
            Try
                Select Case iCustomerID
                    Case Me.SKYTEL_CUSTOMER_ID
                        strPath = Me.SKYTEL_MANIFEST_DIR
                    Case Me.MorrisCom_CUSTOMER_ID
                        strPath = Me.MorrisCom_MANIFEST_DIR
                    Case Me.Propage_CUSTOMER_ID
                        strPath = Me.Propage_MANIFEST_DIR
                    Case Me.Aquis_CUSTOMER_ID
                        strPath = Me.Aquis_MANIFEST_DIR
                    Case Me.CookPager_CUSTOMER_ID
                        strPath = Me.CookPager_MANIFEST_DIR
                    Case Me.CriticalAlert_CUSTOMER_ID
                        strPath = Me.CriticalAlert_MANIFEST_DIR
                End Select
                Return strPath
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSpecialRequestedQty(ByVal iCust_ID As Integer, _
                                               ByVal iModel_ID As Integer, _
                                               ByVal iFreq_ID As Integer, _
                                               Optional ByVal iLoc_ID As Integer = 0) As DataTable ', _
            'ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine
                strSql &= " ,sum(SpecialRequestedQty) AS 'SpecialRequestedQty',sum(SpecialShippedQty) AS 'SpecialShippedQty'" & Environment.NewLine
                strSql &= " ,sum(SpecialRequestedQty)-sum(SpecialShippedQty) as 'AvailableQty',SpecialQtyCompleted" & Environment.NewLine
                strSql &= " ,count(*) As 'RecCount',min(AFSPQTY_ID) as 'AFSPQTY_ID'" & Environment.NewLine
                strSql &= " FROM tamsforecastedneed_special" & Environment.NewLine
                strSql &= " WHERE SpecialQtyCompleted=0 And Cust_ID =" & iCust_ID & " and PSSI_Model_ID=" & iModel_ID & " and PSSI_Freq_ID=" & iFreq_ID & Environment.NewLine
                If iLoc_ID > 0 Then strSql &= " AND Loc_ID = " & iLoc_ID & Environment.NewLine

                strSql &= " GROUP BY Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,Loc_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine

                'strSql = "SELECT Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine
                'strSql &= " ,sum(SpecialRequestedQty) AS 'SpecialRequestedQty',sum(SpecialShippedQty) AS 'SpecialShippedQty'" & Environment.NewLine
                'strSql &= " ,sum(SpecialRequestedQty)-sum(SpecialShippedQty) as 'AvailableQty',SpecialQtyCompleted" & Environment.NewLine
                'strSql &= " ,count(*) As 'RecCount',min(AFSPQTY_ID) as 'AFSPQTY_ID'" & Environment.NewLine
                'strSql &= " FROM tamsforecastedneed_special" & Environment.NewLine
                'strSql &= " WHERE SpecialQtyCompleted=0 And Cust_ID =" & iCust_ID & " and PSSI_Model_ID=" & iModel_ID & " and PSSI_Freq_ID=" & iFreq_ID & Environment.NewLine
                'strSql &= " GROUP BY Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine

                'If booAddSelectRow Then
                '    strSql &= "UNION ALL SELECT '' as 'Ams_Model','' as 'AMS_Freq','--SELECT--' as 'AMS_Baud'" & Environment.NewLine
                '    strSql &= " , " & iCust_ID & " as 'Cust_ID'," & iModel_ID & " as 'PSSI_Model_ID'," & iFreq_ID & " as 'PSSI_Freq_ID', 0 as 'PSSI_Baud_ID'" & Environment.NewLine
                '    strSql &= " ,0 AS 'SpecialRequestedQty',0 AS 'SpecialShippedQty'" & Environment.NewLine
                '    strSql &= " ,0 as 'AvailableQty',0 as 'SpecialQtyCompleted'" & Environment.NewLine
                '    strSql &= " ,1 As 'RecCount',0 as 'AFSPQTY_ID'" & Environment.NewLine
                'End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetSpecialRequestedQty_Data(ByVal iCust_ID As Integer, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal iFreq_ID As Integer, _
                                                    ByVal iBaud_ID As Integer, _
                                                    ByVal bSummry As Boolean, _
                                                    Optional ByVal iLoc_ID As Integer = 0) As DataTable
            Dim strSql As String
            Try
                If bSummry Then
                    strSql = "SELECT Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine
                    strSql &= " ,sum(SpecialRequestedQty) AS 'SpecialRequestedQty',sum(SpecialShippedQty) AS 'SpecialShippedQty'" & Environment.NewLine
                    strSql &= " ,sum(SpecialRequestedQty)-sum(SpecialShippedQty) as 'AvailableQty',SpecialQtyCompleted" & Environment.NewLine
                    strSql &= " ,count(*) As 'RecCount'" & Environment.NewLine
                    strSql &= " FROM tamsforecastedneed_special" & Environment.NewLine
                    strSql &= " WHERE SpecialQtyCompleted=0 And Cust_ID =" & iCust_ID & " and PSSI_Model_ID=" & iModel_ID & " and PSSI_Freq_ID=" & iFreq_ID & " and PSSI_Baud_ID=" & iBaud_ID & Environment.NewLine
                    If iLoc_ID > 0 Then strSql &= " AND Loc_ID = " & iLoc_ID & Environment.NewLine
                    strSql &= " GROUP BY Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine
                Else
                    strSql = "SELECT AFSPQTY_ID,SpecialRequestedQty,SpecialShippedQty,SpecialRequestedQty-SpecialShippedQty as 'AvailableQty',Ams_Model,AMS_Freq,AMS_Baud,Cust_ID,PSSI_Model_ID,PSSI_Freq_ID,PSSI_Baud_ID" & Environment.NewLine
                    strSql &= " ,SpecialQtyCompleted" & Environment.NewLine
                    strSql &= " ,1 As 'RecCount'" & Environment.NewLine
                    strSql &= " FROM tamsforecastedneed_special" & Environment.NewLine
                    strSql &= " WHERE SpecialQtyCompleted=0 And Cust_ID =" & iCust_ID & " and PSSI_Model_ID=" & iModel_ID & " and PSSI_Freq_ID=" & iFreq_ID & " and PSSI_Baud_ID=" & iBaud_ID & Environment.NewLine
                    If iLoc_ID > 0 Then strSql &= " AND Loc_ID = " & iLoc_ID & Environment.NewLine
                    strSql &= " ORDER BY AFSPQTY_ID;" & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function SaveSpecialQtyPalletAndBaudInfoForCreatedBox(ByVal iPallettID As Integer, _
                                                                     ByVal iBaudID As Integer) As Integer
            'Public Function SaveSpecialQtyPalletAndBaudInfoForCreatedBox(ByVal iPallettID As Integer, _
            '                                                             ByVal iBaudID As Integer, _
            '                                                             ByVal iAFSPQtyID As String) As Integer
            Dim strSql As String
            Try
                'strSql = "INSERT INTO tamsforecastedship_special (AFSPQty_ID,Pallett_ID,Baud_ID)" & _
                '         " VALUES (" & iAFSPQtyID & "," & iPallettID & "," & iBaudID & ")"

                strSql = "INSERT INTO tamsforecastedship_special (AFSPQty_ID,Pallett_ID,Baud_ID)" & _
                        " VALUES (0," & iPallettID & "," & iBaudID & ")"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function UpdateSpecialForecastedData(ByVal iAFSPQtyID As Integer, _
                                                    ByVal iPalletID As Integer, _
                                                    ByVal iBaudID As Integer, _
                                                    ByVal iDeviceID As Integer) As Integer

            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt, dt2 As DataTable
            Dim row As DataRow

            Try

                'Update tamsforecastedneed_special (Add 1 to SpecialShippedQty ), and tMessData
                strSql = "UPDATE tamsforecastedneed_special, tmessdata " & Environment.NewLine
                strSql &= " SET tamsforecastedneed_special.SpecialShippedQty = tamsforecastedneed_special.SpecialShippedQty + 1" & Environment.NewLine
                strSql &= " ,tmessdata.AFSPQty_ID=" & iAFSPQtyID
                strSql &= " WHERE tmessdata.device_ID = " & iDeviceID & " and tamsforecastedneed_special.AFSPQty_ID=" & iAFSPQtyID & ";" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i > 0 Then
                    'Check qty and update if SpecialShippedQty = SpecialRequestedQty
                    strSql = "SELECT * From  tamsforecastedneed_special WHERE AFSPQty_ID = " & iAFSPQtyID.ToString
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count = 1 Then ' it must be 1 row
                        For Each row In dt.Rows
                            If row("SpecialShippedQty") = row("SpecialRequestedQty") Then 'need to update
                                strSql = "UPDATE  tamsforecastedneed_special" & Environment.NewLine
                                strSql &= " SET SpecialQtyCompleted=1" & Environment.NewLine
                                strSql &= " WHERE AFSPQty_ID = " & iAFSPQtyID.ToString
                                i = Me._objDataProc.ExecuteNonQuery(strSql)
                                If i = 0 Then Throw New Exception("Failed to update SpecialQtyCompleted in table 'tamsforecastedneed_special'.")
                            ElseIf row("SpecialShippedQty") > row("SpecialRequestedQty") Then
                                Throw New Exception("SpecialShippedQty is more than SpecialRequestedQty! in table 'tamsforecastedneed_special'.")
                            End If
                        Next
                    Else
                        Throw New Exception("Failed to find data in table 'tamsforecastedneed_special'.")
                    End If
                    dt = Nothing

                    'Add if need, in tamsforecastedship_special
                    strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & " And AFSPQTY_ID =0;"
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count = 1 Then 'first device, AFSPQTY_ID=0, so just update it 
                        strSql = "UPDATE tamsforecastedship_special SET AFSPQTY_ID= " & iAFSPQtyID & " WHERE Pallett_ID = " & iPalletID & " And AFSPQTY_ID =0;"
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        If i = 0 Then Throw New Exception("Failed to update table tamsforecastedship_special.")
                    ElseIf dt.Rows.Count = 0 Then 'need to add
                        strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & " And AFSPQTY_ID =" & iAFSPQtyID
                        dt2 = Me._objDataProc.GetDataTable(strSql)
                        If dt2.Rows.Count = 0 Then
                            strSql = "INSERT INTO tamsforecastedship_special (AFSPQTY_ID,Pallett_ID,Baud_ID) " & _
                                   " VALUES (" & iAFSPQtyID & "," & iPalletID & "," & iBaudID & ");"
                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                            If i = 0 Then Throw New Exception("Failed to add to table tamsforecastedship_special.")
                        End If
                    Else
                        Throw New Exception("Failed to update amsforecastedship_special.")
                    End If
                Else
                    Throw New Exception("Failed to update SpecialShippedQty in tables 'tamsforecastedneed_special' and 'tmessdata'.")
                End If

                dt = Nothing : dt2 = Nothing

                Return 1

                'OLD
                'Update tamsforecastedneed_special (Add 1 to SpecialShippedQty )
                'strSql = "UPDATE  tamsforecastedneed_special" & Environment.NewLine
                'strSql &= " SET SpecialShippedQty = SpecialShippedQty + 1" & Environment.NewLine
                'strSql &= " WHERE AFSPQty_ID = " & iAFSPQtyID.ToString

                'strSql = "SELECT * From tamsforecastedship_special Where device_ID=0 AND Pallett_ID = " & iPalletID & " And AFSPQTY_ID = " & iAFSPQtyID

                'strSql = "INSERT INTO tamsforecastedship_special (AFSPQTY_ID,Pallett_ID,Baud_ID,Device_ID) " & _
                '         " VALUES (" & iAFSPQtyID & "," & iPalletID & "," & iBaudID & "," & iDeviceID & ");"

                'ElseIf dt.Rows.Count = 1 AndAlso dt.Rows(0).Item("Device_ID") = 0 Then
                '    strSql = "UPDATE tamsforecastedship_special " & _
                '             " SET Device_ID=" & iDeviceID & " WHERE AFSPQty_ID = " & iAFSPQtyID & " AND Pallett_ID=" & iPalletID & ";"
                '    i = Me._objDataProc.ExecuteNonQuery(strSql)
                '    If i = 0 Then Throw New Exception("Failed to update device_ID in table tamsforecastedship_special.")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function ChangeSpecialBox2RegularBox(ByVal iPalletID As Integer) As Integer
            Dim strsql As String
            Dim dt As DataTable
            Dim row As DataRow
            Dim filteredRows() As DataRow
            Dim strDeviceIDs As String = ""
            Dim arrlstUniqueAFSPQTY_IDs As New ArrayList()
            Dim i As Integer = 0, iQty As Integer = 0
            Dim j As Integer = 0

            Try
                strsql = "SELECT A.Pallett_Name,B.Device_ID,B.Device_SN,C.AFSPQTY_ID,A.Pallett_ID,C.MD_ID " & Environment.NewLine
                strsql &= " FROM tpallett A" & Environment.NewLine
                strsql &= " INNER JOIN tdevice B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strsql &= " INNER JOIN tmessdata C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strsql &= " WHERE A.Pallett_ID=" & iPalletID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                If dt.Rows.Count = 0 Then 'Box is empty, so just delete it from tamsforecastedship_special
                    strsql = "DELETE FROM tamsforecastedship_special WHERE Pallett_ID=" & iPalletID
                    Return Me._objDataProc.ExecuteNonQuery(strsql)
                Else
                    For Each row In dt.Rows
                        If Not row("AFSPQTY_ID") > 0 Then
                            Throw New Exception("Invalid AFSPQTY_ID in tMessData.")
                        End If
                        If Not arrlstUniqueAFSPQTY_IDs.Contains(row("AFSPQTY_ID")) Then
                            arrlstUniqueAFSPQTY_IDs.Add(row("AFSPQTY_ID"))
                        End If
                        If strDeviceIDs.Trim.Length = 0 Then
                            strDeviceIDs = row("Device_ID")
                        Else
                            strDeviceIDs &= "," & row("Device_ID")
                        End If
                    Next

                    'Ready to process---------------------------------------------------------------------
                    '1. Update  tamsforecastedneed_special
                    For i = 0 To arrlstUniqueAFSPQTY_IDs.Count - 1
                        filteredRows = dt.Select("AFSPQTY_ID=" & arrlstUniqueAFSPQTY_IDs(i))
                        iQty = filteredRows.Length
                        strsql = "UPDATE tamsforecastedneed_special" & Environment.NewLine
                        strsql &= " SET SpecialShippedQty = if(SpecialShippedQty - " & iQty & " > 0,SpecialShippedQty - " & iQty & ",0), SpecialQtyCompleted=0" & Environment.NewLine
                        strsql &= " WHERE AFSPQTY_ID = " & arrlstUniqueAFSPQTY_IDs(i) & ";" & Environment.NewLine
                        j = Me._objDataProc.ExecuteNonQuery(strsql)
                    Next
                    '2. Update   tmessdata
                    strsql = "UPDATE tmessdata" & Environment.NewLine
                    strsql &= " SET AFSPQTY_ID=0" & Environment.NewLine
                    strsql &= " WHERE Device_ID IN (" & strDeviceIDs & ");" & Environment.NewLine
                    j = Me._objDataProc.ExecuteNonQuery(strsql)
                    '3.  Delete from tamsforecastedship_special
                    strsql = "DELETE FROM tamsforecastedship_special WHERE Pallett_ID=" & iPalletID
                    Return Me._objDataProc.ExecuteNonQuery(strsql)
                End If
                dt = Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function zfTest() As Integer
            Dim strsql As String
            strsql = "UPDATE tamsforecastedneed_special, tmessdata "
            strsql &= " SET tamsforecastedneed_special.SpecialShippedQty = tamsforecastedneed_special.SpecialShippedQty + 1"
            strsql &= " ,tmessdata.AFSPQty_ID=116"
            strsql &= " WHERE tmessdata.device_ID = 555513554824 and tamsforecastedneed_special.AFSPQty_ID=116;"
            Return Me._objDataProc.ExecuteNonQuery(strsql)

        End Function
        '**************************************************************
        Public Function DeleteteSN_UpdateSpecialForecastedData(ByVal iPalletID As Integer, _
                                                               ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt, dt2, dt3 As DataTable
            Dim row As DataRow
            Dim iAFSPQtyID As Integer = 0

            Try

                strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    Throw New Exception("Failed to find tamsforecastedship_special.Pallett_ID: " & iPalletID)
                Else
                    strSql = "SELECT A.AFSPQty_ID,B.device_ID,A.AFSP_PLT_ID" & Environment.NewLine
                    strSql &= " FROM tamsforecastedship_special A" & Environment.NewLine
                    strSql &= " INNER JOIN tmessdata B ON A.AFSPQty_ID=B.AFSPQty_ID" & Environment.NewLine
                    strSql &= " WHERE Pallett_ID=" & iPalletID & " AND B.device_ID=" & iDeviceID & ";" & Environment.NewLine

                    dt2 = Me._objDataProc.GetDataTable(strSql)
                    If dt2.Rows.Count = 0 Then
                        Throw New Exception("Failed to find data.")
                    Else 'should be 1 row
                        iAFSPQtyID = dt2.Rows(0).Item("AFSPQty_ID")

                        'update tamsforecastedship_special
                        strSql = "SELECT  AFSPQty_ID,count(*) as RecCount" & Environment.NewLine
                        strSql &= " FROM tdevice A INNER JOIN tmessdata B ON A.device_ID=B.device_ID" & Environment.NewLine
                        strSql &= " WHERE A.pallett_ID=" & iPalletID & Environment.NewLine
                        strSql &= " GROUP BY AFSPQty_ID;" & Environment.NewLine
                        dt3 = Me._objDataProc.GetDataTable(strSql)
                        If dt3.Rows.Count = 1 AndAlso dt3.Rows(0).Item("RecCount") = 1 Then 'last device removed
                            strSql = "UPDATE tamsforecastedship_special SET AFSPQty_ID=0 WHERE Pallett_ID = " & iPalletID & ";"
                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        ElseIf dt3.Rows.Count > 1 Then
                            For Each row In dt3.Rows
                                If row("AFSPQty_ID") = iAFSPQtyID AndAlso row("RecCount") > 1 Then
                                    strSql = "DELETE FROM tamsforecastedship_special  WHERE Pallett_ID = " & iPalletID & " AND AFSPQty_ID=" & iAFSPQtyID
                                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                                End If
                            Next
                        End If
                        'For Each row In dt3.Rows
                        '    If row("AFSPQty_ID") = iAFSPQtyID Then
                        '        If row("RecCount") = 1 Then
                        '            strSql = "UPDATE tamsforecastedship_special SET AFSPQty_ID=0 WHERE Pallett_ID = " & iPalletID & ";"
                        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        '        ElseIf row("RecCount") > 1 Then
                        '            strSql = "DELETE FROM tamsforecastedship_special  WHERE Pallett_ID = " & iPalletID & " AND AFSPQty_ID=" & iAFSPQtyID
                        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        '        End If
                        '    End If
                        'Next

                        'update  tamsforecastedneed_special, tmessdata
                        strSql = "UPDATE tamsforecastedneed_special, tmessdata" & Environment.NewLine
                        strSql &= " SET tamsforecastedneed_special.SpecialShippedQty = if(tamsforecastedneed_special.SpecialShippedQty>1,tamsforecastedneed_special.SpecialShippedQty-1,0), tamsforecastedneed_special.SpecialQtyCompleted=0" & Environment.NewLine
                        strSql &= " ,tmessdata.AFSPQty_ID=0" & Environment.NewLine
                        strSql &= " WHERE tmessdata.device_ID = " & iDeviceID & " and tamsforecastedneed_special.AFSPQty_ID=" & iAFSPQtyID & ";" & Environment.NewLine
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        If i = 0 Then Throw New Exception("Failed to update")

                        'strSql = "SELECT  AFSPQty_ID,count(*) as RecCount" & Environment.NewLine
                        'strSql &= " FROM tdevice A INNER JOIN tmessdata B ON A.device_ID=B.device_ID" & Environment.NewLine
                        'strSql &= " WHERE AFSPQty_ID>0 AND A.pallett_ID=" & iPalletID & Environment.NewLine
                        'strSql &= " GROUP BY AFSPQty_ID;" & Environment.NewLine

                        'dt3 = Me._objDataProc.GetDataTable(strSql)
                        'For Each row In dt3.Rows
                        '    If row("AFSPQty_ID") = iAFSPQtyID Then
                        '        If row("RecCount") = 0 Then
                        '            strSql = "UPDATE tamsforecastedship_special SET AFSPQty_ID=0 WHERE Pallett_ID = " & iPalletID & ";"
                        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        '        Else
                        '            strSql = "DELETE FROM tamsforecastedship_special  WHERE Pallett_ID = " & iPalletID & " AND AFSPQty_ID=" & iAFSPQtyID
                        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        '        End If
                        '    End If
                        'Next
                        'If dt3.Rows.Count = 1 AndAlso dt3.Rows(0).Item("RecCount") = 0 Then 'last device removed
                        '    strSql = "UPDATE tamsforecastedship_special SET AFSPQty_ID=0 WHERE Pallett_ID = " & iPalletID & ";"
                        '    i = Me._objDataProc.ExecuteNonQuery(strSql)
                        'ElseIf dt3.Rows.Count > 1 Then
                        '    For Each row In dt3.Rows
                        '        If row("AFSPQty_ID") = iAFSPQtyID AndAlso row("RecCount") = 0 Then
                        '            strSql = "DELETE FROM tamsforecastedship_special  WHERE Pallett_ID = " & iPalletID & " AND AFSPQty_ID=" & iAFSPQtyID
                        '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        '        End If
                        '    Next
                        'End If
                    End If
                End If

                'OLD
                'strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & ";"
                'dt = Me._objDataProc.GetDataTable(strSql)

                'If dt.Rows.Count = 0 Then
                '    Throw New Exception("Failed to update tamsforecastedship_special. Pallett_ID: " & iPalletID)
                'ElseIf dt.Rows.Count = 1 Then
                '    iAFSPQtyID = dt.Rows(0).Item("AFSPQty_ID")
                '    strSql = "UPDATE tamsforecastedship_special SET device_ID=0 Where Pallett_ID = " & iPalletID & ";"
                '    i = Me._objDataProc.ExecuteNonQuery(strSql)
                '    If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special. Pallett_ID: " & iPalletID)
                'Else
                '    strSql = "SELECT * From tamsforecastedship_special Where device_ID=" & iDeviceID & " AND Pallett_ID = " & iPalletID & ";"
                '    dt2 = Me._objDataProc.GetDataTable(strSql)
                '    If dt2.Rows.Count > 0 Then 'should be 1 row
                '        iAFSPQtyID = dt.Rows(0).Item("AFSPQty_ID")
                '        strSql = "DELETE FROM tamsforecastedship_special  Where device_ID=" & iDeviceID & " AND Pallett_ID = " & iPalletID & ";"
                '        i = Me._objDataProc.ExecuteNonQuery(strSql)
                '    End If
                'End If

                'strSql = "UPDATE tamsforecastedneed_special SET SpecialShippedQty= if(SpecialShippedQty>1,SpecialShippedQty-1,0), SpecialQtyCompleted=0  WHERE AFSPQty_ID = " & iAFSPQtyID
                'i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function DeleteteAllSNs_UpdateSpecialForecastedData(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim dt, dt2 As DataTable
            Dim iAFSPQtyID As Integer = 0
            Dim iPrimKey As Integer = 0
            Dim row As DataRow

            Try

                strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & " ORDER BY AFSP_PLT_ID;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 1 Then
                    strSql = "UPDATE tamsforecastedship_special SET AFSPQty_ID=0 Where Pallett_ID = " & iPalletID & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special.")
                ElseIf dt.Rows.Count > 1 Then
                    For j = 0 To dt.Rows.Count - 1
                        iPrimKey = dt.Rows(j).Item("AFSP_PLT_ID")
                        If j = 0 Then
                            strSql = "UPDATE tamsforecastedship_special SET AFSPQty_ID=0 Where AFSP_PLT_ID = " & iPrimKey & ";"
                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                            If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special.")
                        Else
                            strSql = "DELETE FROM tamsforecastedship_special Where AFSP_PLT_ID = " & iPrimKey & ";"
                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                            If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special.")
                        End If
                    Next
                End If
                dt = Nothing

                strSql = "SELECT  B.AFSPQty_ID,B.device_ID,B.MD_ID" & Environment.NewLine
                strSql &= " FROM tdevice A INNER JOIN tmessdata B ON A.device_ID=B.device_ID" & Environment.NewLine
                strSql &= " WHERE A.pallett_ID= " & iPalletID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows
                    strSql = "UPDATE tmessdata SET AFSPQty_ID=0 WHERE MD_ID=" & row("MD_ID") 'MD_ID is prim key
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    iAFSPQtyID = row("AFSPQty_ID")
                    strSql = "UPDATE tamsforecastedneed_special SET SpecialShippedQty= if(SpecialShippedQty>1,SpecialShippedQty-1,0), SpecialQtyCompleted=0  WHERE AFSPQty_ID = " & iAFSPQtyID
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Next

                'OLD
                'strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & " ORDER BY AFSP_PLT_ID;"
                'dt = Me._objDataProc.GetDataTable(strSql)

                'If dt.Rows.Count = 1 Then
                '    iAFSPQtyID = dt.Rows(0).Item("AFSPQty_ID")
                '    strSql = "UPDATE tamsforecastedship_special SET device_ID=0 Where Pallett_ID = " & iPalletID & ";"
                '    i = Me._objDataProc.ExecuteNonQuery(strSql)
                '    If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special.")

                '    strSql = "UPDATE tamsforecastedneed_special SET SpecialShippedQty= if(SpecialShippedQty>1,SpecialShippedQty-1,0), SpecialQtyCompleted=0  WHERE AFSPQty_ID = " & iAFSPQtyID
                '    i = Me._objDataProc.ExecuteNonQuery(strSql)
                'ElseIf dt.Rows.Count > 1 Then
                '    For j = 0 To dt.Rows.Count - 1
                '        iAFSPQtyID = dt.Rows(j).Item("AFSPQty_ID")
                '        iPrimKey = dt.Rows(j).Item("AFSP_PLT_ID")
                '        If j = 0 Then
                '            strSql = "UPDATE tamsforecastedship_special SET device_ID=0 Where AFSP_PLT_ID = " & iPrimKey & ";"
                '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                '            If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special.")
                '        Else
                '            strSql = "DELETE FROM tamsforecastedship_special Where AFSP_PLT_ID = " & iPrimKey & ";"
                '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                '            If i = 0 Then Throw New Exception("Failed to update tamsforecastedship_special.")
                '        End If

                '        strSql = "UPDATE tamsforecastedneed_special SET SpecialShippedQty= if(SpecialShippedQty>1,SpecialShippedQty-1,0), SpecialQtyCompleted=0  WHERE AFSPQty_ID = " & iAFSPQtyID
                '        i = Me._objDataProc.ExecuteNonQuery(strSql)
                '    Next
                'End If

                'dt = Nothing : dt2 = Nothing

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function DeleteteEmptyPallet_UpdateSpecialForecastedData(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            'Dim j As Integer = 0
            'Dim dt As DataTable
            'Dim row As DataRow
            'Dim iAFSPQtyID As Integer = 0
            'Dim iPrimKey As Integer = 0

            Try

                'strSql = "SELECT * From tamsforecastedship_special Where Pallett_ID = " & iPalletID & ";"
                'dt = Me._objDataProc.GetDataTable(strSql)

                'If dt.Rows.Count > 0 Then
                '    For Each row In dt.Rows
                '        If row("Device_ID") > 0 Then
                '            iAFSPQtyID = row("AFSPQty_ID")
                '            iPrimKey = row("AFSP_PLT_ID")

                '            strSql = "UPDATE tamsforecastedneed_special SET SpecialShippedQty= if(SpecialShippedQty>1,SpecialShippedQty-1,0), SpecialQtyCompleted=0  WHERE AFSPQty_ID = " & iAFSPQtyID
                '            i = Me._objDataProc.ExecuteNonQuery(strSql)
                '        End If
                '    Next

                strSql = "DELETE FROM tamsforecastedship_special Where Pallett_ID = " & iPalletID & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                'End If
                'dt = Nothing

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Load ASN File"

        '******************************************************************
        Public Function GetCustPSSBaudMap() As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT lbaudmap.baud_id as 'BaudID',  bm_BaudRateCode as 'BaudCode' " & Environment.NewLine
                strSql &= "FROM lbaudmap " & Environment.NewLine
                strSql &= "INNER JOIN lbaud ON lbaudmap.baud_id = lbaud.baud_id " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function LoadASNData(ByVal dtData As DataTable, _
                                    ByVal dtWO As DataTable, _
                                    ByVal strUsrName As String, _
                                    ByVal iUsrID As Integer)
            Dim strSql As String
            Dim R1 As DataRow
            Dim dt As DataTable
            Dim iWOID As Integer = 0
            Dim iWOQty As Integer = 0
            Dim i As Integer = 0

            Try
                For Each R1 In dtWO.Rows
                    dt = MyBase.GetRMA(R1("WO"), SkyTel.SKYTEL_LOC_ID)
                    iWOQty = dtData.Select("[SHIP NUMBER] = '" & R1("WO") & "'").Length

                    If dt.Rows.Count > 0 Then
                        Throw New Exception("This RMA/WO (" & R1("WO") & " is already listed in the system. Please remove it from the file.")
                    Else
                        iWOID = MyBase.CreateNewRMA(SkyTel.SKYTEL_LOC_ID, R1("WO"), 0, 1, SkyTel.SKYTEL_PRODID, SkyTel.SKYTEL_GROUPID, strUsrName, iUsrID, iWOQty)
                        R1.BeginEdit()
                        R1("WO_ID") = iWOID
                        R1.EndEdit()
                        R1.AcceptChanges()
                    End If

                    iWOID = 0
                    iWOQty = 0
                    Generic.DisposeDT(dt)
                Next R1

                For Each R1 In dtData.Rows
                    strSql = "INSERT INTO t1545data ( " & Environment.NewLine
                    strSql &= "sd_ShipNo " & Environment.NewLine
                    strSql &= ", sd_FreqNo " & Environment.NewLine
                    strSql &= ", sd_CapCode " & Environment.NewLine
                    strSql &= ", sd_SN " & Environment.NewLine
                    strSql &= ", sd_BaudRateCode " & Environment.NewLine
                    strSql &= ", sd_BaudDesc " & Environment.NewLine
                    strSql &= ", sd_ManufCode " & Environment.NewLine
                    strSql &= ", sd_ModCode " & Environment.NewLine
                    strSql &= ", sd_ModelDesc " & Environment.NewLine
                    strSql &= ", sd_ServiceType " & Environment.NewLine
                    strSql &= ", sd_SkyTelEquipNo " & Environment.NewLine
                    strSql &= ", sd_BlankSN " & Environment.NewLine
                    strSql &= ", sd_DuplSN " & Environment.NewLine
                    strSql &= ", sd_NoBaud " & Environment.NewLine
                    strSql &= ", sd_NoCapcode " & Environment.NewLine
                    strSql &= ", sd_NoFreq " & Environment.NewLine
                    strSql &= ", freq_id " & Environment.NewLine
                    strSql &= ", baud_id " & Environment.NewLine
                    strSql &= ", LoadDataUserID " & Environment.NewLine
                    strSql &= ", LoadDataDate " & Environment.NewLine
                    strSql &= ", LoadTime " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "  '" & R1("SHIP NUMBER") & "'" & Environment.NewLine
                    strSql &= ", '" & R1("FREQUENCY") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("CAP CODE") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("SERIAL NO.") & "'" & Environment.NewLine
                    strSql &= ", '" & R1("BAUD RATE") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("BAUD DESCR") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("MANUFACTURER") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("MODEL CODE") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("MODEL DESCRIPTION") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("SERVICE TYPE") & "' " & Environment.NewLine
                    strSql &= ", '" & R1("SKYTEL EQUIPMENT#") & "' " & Environment.NewLine
                    strSql &= ", " & R1("No SN") & Environment.NewLine
                    strSql &= ", " & R1("Duplicate SN") & Environment.NewLine
                    strSql &= ", " & R1("No Baud") & Environment.NewLine
                    strSql &= ", " & R1("No Cap") & Environment.NewLine
                    strSql &= ", " & R1("No Freq") & Environment.NewLine
                    strSql &= ", " & R1("freq_id") & Environment.NewLine
                    strSql &= ", " & R1("baud_id") & Environment.NewLine
                    strSql &= ", " & iUsrID & Environment.NewLine
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", Now() " & Environment.NewLine
                    strSql &= ")" & Environment.NewLine

                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtData)
                Generic.DisposeDT(dtWO)
            End Try
        End Function

        '******************************************************************

#End Region

    End Class
End Namespace