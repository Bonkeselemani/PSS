Option Explicit On 

Namespace Buisness
    Public Class DBRManifest
        Private Const _iDBRShipID = 9999919

        Private _objDataProc As DBQuery.DataProc

        '****************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '****************************************************************
        Public Function CheckSN(ByVal iLocID As Integer, ByVal strSN As String, _
                                ByRef iDevice_ID As Integer, _
                                ByRef iModelID As Integer, _
                                Optional ByVal strCheckType As String = "") As String
            Dim strSNStatus As String = ""
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE Loc_ID = " & iLocID & " AND Device_SN = '" & strSN & "' " & Environment.NewLine
                strSQL &= "ORDER BY Device_ID DESC"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then

                        iDevice_ID = dt.Rows(0)("Device_ID")
                        iModelID = dt.Rows(0)("Model_ID")

                        If dt.Rows(0)("Loc_ID") <> 19 Then
                            strSNStatus = "Not an American Messaging device."
                        ElseIf strCheckType = "DBR" AndAlso IsDBNull(dt.Rows(0)("Device_DateShip")) Then
                            strSNStatus = "Device has no ship date."
                        ElseIf strCheckType = "DBR" AndAlso IsDBNull(dt.Rows(0)("Ship_ID")) Then
                            strSNStatus = "Device has no Ship ID."
                        ElseIf strCheckType = "DBR" AndAlso dt.Rows(0)("Ship_ID") <> Me._iDBRShipID Then
                            strSNStatus = "Device is not DBR/NER."
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) Then
                            strSNStatus = "Device has already assigned to a lot."
                        End If
                    Else
                        strSNStatus = "Invalid serial number."
                    End If
                Else
                    strSNStatus = "Datatable is NULL."
                End If

                Return strSNStatus
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function CheckMessDBRNERSerialNumber(ByVal strSN As String, _
                                                    ByVal iDBRBillCode_ID As Integer, _
                                                    ByVal iNERBillCode_ID As Integer, _
                                                    ByVal strCheckType As String, _
                                                    ByRef iDevice_ID As Integer, _
                                                    ByRef iPalletID As Integer, _
                                                    ByRef iCust_ID As Integer, _
                                                    ByRef iLoc_ID As Integer, _
                                                    ByRef strPalletName As String, _
                                                    ByRef strCustomer As String)
            Dim strSNStatus As String = ""
            Dim strSQL As String
            Dim dt, dtBill, dtPallet As DataTable
            Dim arrlstMessCustomerLocIDs As New ArrayList()
            Dim strLocIDs As String = ""
            Dim row As DataRow
            Dim arrlstBillCodeIDs As New ArrayList()
            Dim i As Integer = 0

            Try

                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.AMS_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Aquis_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.MorrisCom_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Propage_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.CookPager_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.CriticalAlertNorth_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.CriticalAlertSouth_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Anna_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Lahey_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Masco_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Franciscan_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.Maine_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.SMHC_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.ATS_LOC_ID)
                arrlstMessCustomerLocIDs.Add(PSS.Data.Buisness.SkyTel.A1WirelessComm_LOC_ID)

                For i = 0 To arrlstMessCustomerLocIDs.Count - 1
                    If strLocIDs.Trim.Length = 0 Then
                        strLocIDs = arrlstMessCustomerLocIDs(i)
                    Else
                        strLocIDs &= "," & arrlstMessCustomerLocIDs(i)
                    End If
                Next

                iPalletID = 0 : strPalletName = "" : strCustomer = ""
                iDevice_ID = 0 : iCust_ID = 0 : iLoc_ID = 0

                strSQL = "SELECT  C.Cust_Name1 AS 'Customer',C.Cust_ID,A.*" & Environment.NewLine
                strSQL &= " FROM tdevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tlocation B ON A.Loc_ID=B.Loc_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tcustomer C ON C.Cust_ID=B.Cust_ID" & Environment.NewLine
                strSQL &= " WHERE A.Device_SN = '" & strSN.Replace("'", "''") & "'" & Environment.NewLine
                strSQL &= " AND A.Pallett_ID IS NULL" & Environment.NewLine
                strSQL &= " ORDER BY Device_ID DESC;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 1 Then 'same sn, but diffrent customer. Then try ams only
                    strSQL = "SELECT  C.Cust_Name1 AS 'Customer',C.Cust_ID,A.*" & Environment.NewLine
                    strSQL &= " FROM tdevice A" & Environment.NewLine
                    strSQL &= " INNER JOIN tlocation B ON A.Loc_ID=B.Loc_ID" & Environment.NewLine
                    strSQL &= " INNER JOIN tcustomer C ON C.Cust_ID=B.Cust_ID" & Environment.NewLine
                    strSQL &= " WHERE A.Device_SN = '" & strSN.Replace("'", "''") & "'" & Environment.NewLine
                    strSQL &= " AND A.Pallett_ID IS NULL AND A.Loc_ID in (" & strLocIDs & ")" & Environment.NewLine
                    strSQL &= " ORDER BY Device_ID DESC;" & Environment.NewLine

                    dt = Me._objDataProc.GetDataTable(strSQL)
                End If

                If Not IsNothing(dt) Then 'Null db==========================================
                    If dt.Rows.Count = 1 Then ' has data-----------------------------------
                        iDevice_ID = dt.Rows(0)("Device_ID")
                        iLoc_ID = dt.Rows(0)("Loc_ID")
                        iCust_ID = dt.Rows(0)("Cust_ID")
                        strCustomer = dt.Rows(0)("Customer")
                        If Not arrlstMessCustomerLocIDs.Contains(dt.Rows(0)("Loc_ID")) Then ' <> PSS.Data.Buisness.SkyTel.AMS_LOC_ID Then
                            strSNStatus = "Not an American Messaging device."
                            'ElseIf Not dt.Rows(0).IsNull("Pallett_ID") Then
                            '    iPallettID = dt.Rows(0).Item("Pallett_ID")
                            '    strSNStatus = "Device has already assigned to a pallet."
                        Else 'it is message SN and no pallett_id
                            strSQL = "select * from tdevicebill where device_ID=" & iDevice_ID
                            dtBill = Me._objDataProc.GetDataTable(strSQL)
                            If Not dtBill.Rows.Count > 0 Then
                                strSNStatus = "Device has no billing information. It is in WIP or missed billing data."
                            ElseIf dtBill.Rows.Count > 1 Then
                                For Each row In dtBill.Rows
                                    arrlstBillCodeIDs.Add(row("Billcode_ID"))
                                Next
                                If arrlstBillCodeIDs.Contains(iDBRBillCode_ID) AndAlso strCheckType.Trim.ToUpper = "dbr".ToUpper Then
                                    strSNStatus = "Device is DBR, but invalid billing data ."
                                ElseIf arrlstBillCodeIDs.Contains(iNERBillCode_ID) AndAlso strCheckType.Trim.ToUpper = "ner".ToUpper Then
                                    strSNStatus = "Device is NER, but invalid billing data ."
                                ElseIf arrlstBillCodeIDs.Contains(iDBRBillCode_ID) AndAlso strCheckType.Trim.ToUpper = "ner".ToUpper Then
                                    strSNStatus = "Device is DBR with invalid billing data ."
                                ElseIf arrlstBillCodeIDs.Contains(iNERBillCode_ID) AndAlso strCheckType.Trim.ToUpper = "dbr".ToUpper Then
                                    strSNStatus = "Device is NER with invalid billing data ."
                                Else
                                    strSNStatus = "Device is neither DBR nor NER."
                                End If
                            Else ' 1 record
                                If dtBill.Rows(0).Item("BillCode_ID") = iNERBillCode_ID AndAlso strCheckType.Trim.ToUpper = "dbr".ToUpper Then
                                    strSNStatus = "Device is NER."
                                ElseIf dtBill.Rows(0).Item("BillCode_ID") = iDBRBillCode_ID AndAlso strCheckType.Trim.ToUpper = "ner".ToUpper Then
                                    strSNStatus = "Device is DBR."
                                ElseIf dtBill.Rows(0).Item("BillCode_ID") = iDBRBillCode_ID AndAlso strCheckType.Trim.ToUpper = "dbr".ToUpper Then
                                    strSNStatus = ""
                                ElseIf dtBill.Rows(0).Item("BillCode_ID") = iNERBillCode_ID AndAlso strCheckType.Trim.ToUpper = "ner".ToUpper Then
                                    strSNStatus = ""
                                Else
                                    strSNStatus = "Device is neither DBR nor NER."
                                End If
                            End If
                        End If 'it is message SN and no pallett_id
                    ElseIf dt.Rows.Count > 1 Then
                        strSNStatus = "Dupilcate open devices."
                    Else '=0
                        strSQL = "SELECT D.Cust_Name1 AS 'Customer',A.Loc_ID,C.Cust_ID,B.Pallett_Name,A.Device_SN,B.Pallett_ID,A.Device_ID" & Environment.NewLine
                        strSQL &= " ,B.pkslip_ID,B.Pallett_QTY,B.Pallet_ShipType,B.Pallett_ShipDate,A.Device_DateShip" & Environment.NewLine
                        strSQL &= " FROM tdevice A" & Environment.NewLine
                        strSQL &= " INNER JOIN tpallett B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tlocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
                        strSQL &= " INNER JOIN tcustomer D ON C.Cust_ID=D.Cust_ID" & Environment.NewLine
                        strSQL &= " WHERE device_sn='" & strSN.Replace("'", "''") & "'" & Environment.NewLine
                        strSQL &= " AND A.Pallett_ID IS NOT NULL" & Environment.NewLine
                        strSQL &= " ORDER BY B.Pallett_ShipDate DESC;" & Environment.NewLine
                        dtPallet = Me._objDataProc.GetDataTable(strSQL)
                        If dtPallet.Rows.Count > 0 Then
                            If Not arrlstMessCustomerLocIDs.Contains(dtPallet.Rows(0)("Loc_ID")) Then ' <> PSS.Data.Buisness.SkyTel.AMS_LOC_ID Then
                                strSNStatus = "Not an American Messaging device."
                            Else
                                iPalletID = dtPallet.Rows(0).Item("Pallett_ID")
                                iDevice_ID = dtPallet.Rows(0)("Device_ID")
                                iLoc_ID = dtPallet.Rows(0)("Loc_ID")
                                iCust_ID = dtPallet.Rows(0)("Cust_ID")
                                strCustomer = dtPallet.Rows(0)("Customer")
                                strPalletName = dtPallet.Rows(0).Item("Pallett_name")
                                strSNStatus = "This device '" & strSN.Replace("'", "''") & " is already in pallet '" & strPalletName & "'."
                            End If
                        Else
                            strSNStatus = "Invalid serial number. Can't find it from table tDevice."
                        End If
                    End If ' has data---------------------------------------------
                Else
                    strSNStatus = "Datatable is NULL."
                End If 'Null db====================================================

                Return strSNStatus

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function
        '****************************************************************
        Public Function GetDBRSNData(ByVal strDevice_IDsIn As String) As DataTable
            Dim strSQL, strCurDate As String

            Try
                strCurDate = Format(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)), "MM/dd/yyyy")

                strSQL = "SELECT DISTINCT D.Model_Desc as Model, A.Device_SN AS SN, CONCAT('*', A.Device_SN, '*') AS 'SN Barcode', E.capcode as 'Capcode', IFNULL(C.DCode_LDesc, 'None Specified') AS 'DBR Reason',  '" & strCurDate & "' AS 'Ship Date' " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel D ON A.Model_ID = D.Model_ID " & Environment.NewLine
                strSQL &= "LEFT JOIN tdevicecodes B ON B.Device_ID = A.Device_ID" & Environment.NewLine
                strSQL &= "INNER JOIN lcodesdetail C ON C.DCode_ID = B.DCode_ID" & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata E ON A.Device_ID = E.Device_ID " & Environment.NewLine
                strSQL &= "WHERE A.Device_ID IN (" & strDevice_IDsIn & ") " & Environment.NewLine
                strSQL &= "AND Ship_ID = " & Me._iDBRShipID.ToString & " " & Environment.NewLine
                strSQL &= "ORDER BY D.Model_Desc, A.Device_SN, A.Device_DateShip DESC"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetNER_SNData(ByVal strDevice_IDsIn As String) As DataTable
            Dim strSQL, strCurDate As String

            Try
                strCurDate = Format(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)), "MM/dd/yyyy")

                strSQL = "SELECT DISTINCT D.Model_Desc as Model, A.Device_SN AS SN, CONCAT('*', A.Device_SN, '*') AS 'SN Barcode', E.capcode as 'Capcode', IFNULL(C.DCode_LDesc, 'None Specified') AS 'NER Reason',  '" & strCurDate & "' AS 'Ship Date' " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel D ON A.Model_ID = D.Model_ID " & Environment.NewLine
                strSQL &= "LEFT JOIN tdevicecodes B ON B.Device_ID = A.Device_ID" & Environment.NewLine
                strSQL &= "INNER JOIN lcodesdetail C ON C.DCode_ID = B.DCode_ID" & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata E ON A.Device_ID = E.Device_ID " & Environment.NewLine
                strSQL &= "WHERE A.Device_ID IN (" & strDevice_IDsIn & ") " & Environment.NewLine
                strSQL &= "AND Ship_ID = " & Me._iDBRShipID.ToString & " " & Environment.NewLine
                strSQL &= "ORDER BY D.Model_Desc, A.Device_SN, A.Device_DateShip DESC"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetNERSNData(ByVal strDevice_IDsIn As String) As DataTable
            Dim strSQL, strCurDate As String

            Try
                strCurDate = Format(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)), "MM/dd/yyyy")

                strSQL = "SELECT DISTINCT B.Model_desc as Model, A.Device_SN AS SN, CONCAT('*', A.Device_SN, '*') AS 'SN Barcode', C.Capcode as 'Capcode', 'NER' AS 'Reason',  '" & strCurDate & "' AS 'Ship Date' " & Environment.NewLine
                strSQL &= "FROM tdevice A " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSQL &= "WHERE A.Device_ID IN (" & strDevice_IDsIn & ") " & Environment.NewLine
                strSQL &= "AND Ship_ID = " & Me._iDBRShipID.ToString & " " & Environment.NewLine
                strSQL &= "ORDER BY B.Model_desc, A.Device_SN, A.Device_DateShip DESC"

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function GetDevicesHasDBRPallet(ByVal strDevice_IDsIN As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT Device_SN " & Environment.NewLine
                strSQL &= "FROM tdevice  " & Environment.NewLine
                strSQL &= "WHERE Device_ID IN (" & strDevice_IDsIN & ") " & Environment.NewLine
                strSQL &= "AND Pallett_ID is not null " & Environment.NewLine
                strSQL &= "ORDER BY Device_SN DESC"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function GetDevicesHasPalletData(ByVal strDevice_IDs As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT D.Cust_Name1 AS 'Customer',A.Loc_ID,C.Cust_ID,B.Pallett_Name,A.Device_SN,B.Pallett_ID,A.Device_ID" & Environment.NewLine
                strSQL &= " ,B.pkslip_ID,B.Pallett_QTY,B.Pallet_ShipType,B.Pallett_ShipDate,A.Device_DateShip" & Environment.NewLine
                strSQL &= " FROM tdevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tpallett B ON A.Pallett_ID=B.Pallett_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tlocation C ON A.Loc_ID=C.Loc_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tcustomer D ON C.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSQL &= " WHERE device_ID in (" & strDevice_IDs & ")" & Environment.NewLine
                strSQL &= " AND A.Pallett_ID IS NOT NULL" & Environment.NewLine
                strSQL &= " ORDER BY B.Pallett_ShipDate DESC;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function DefinePalletName(ByVal strPalletPrefix As String, _
                                         ByVal iCust_ID As Integer, _
                                         ByVal iLoc_ID As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try
                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCust_ID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLoc_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        If dt.Rows(0)("Pallett_Num") > 999 Then Throw New System.Exception("Pallet sequence number hits the max limit 999.")
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
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*********************************************************************
        Public Function CreateShipPalletID(ByVal strPalletName As String, _
                                           ByVal iCust_ID As Integer, _
                                           ByVal iLoc_ID As Integer, _
                                           ByVal strWk_Dt As String, _
                                           ByVal iPallet_ShipType As Integer, _
                                           ByVal iPallett_Qty As Integer) As Integer
            Dim strSQL As String
            Dim iPallet_ID As Integer = 0

            Try
                strSQL = "INSERT INTO tpallett ( " & Environment.NewLine
                strSQL &= "Pallett_Name, " & Environment.NewLine
                strSQL &= "Pallett_ShipDate, " & Environment.NewLine
                strSQL &= "Pallett_BulkShipped, " & Environment.NewLine
                strSQL &= "Pallett_ReadyToShipFlg, " & Environment.NewLine
                strSQL &= "Pallet_ShipType, " & Environment.NewLine
                strSQL &= "Pallett_QTY, " & Environment.NewLine
                strSQL &= "Cust_ID,  " & Environment.NewLine
                strSQL &= "Loc_ID  " & Environment.NewLine
                strSQL &= ") VALUES (  " & Environment.NewLine
                strSQL &= "'" & strPalletName & "', " & Environment.NewLine
                strSQL &= "'" & strWk_Dt & "', " & Environment.NewLine
                strSQL &= "1, " & Environment.NewLine
                strSQL &= "1, " & Environment.NewLine
                strSQL &= iPallet_ShipType & ",  " & Environment.NewLine
                strSQL &= iPallett_Qty & ", " & Environment.NewLine
                strSQL &= iCust_ID & ", " & Environment.NewLine
                strSQL &= iLoc_ID & ");" & Environment.NewLine
                iPallet_ID = Me._objDataProc.idTransaction(strSQL, "tpallett")

                Return iPallet_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function PalletizeAMS_DBRNERPallet(ByVal iLoc_ID As Integer, _
                                                  ByVal iCust_ID As Integer, _
                                                  ByVal arrlstDeviceIDs As ArrayList, _
                                                  ByVal strWk_Dt As String, _
                                                  ByVal iPallett_Qty As Integer, _
                                                  ByVal strDBRNER As String, _
                                                  ByVal iShiftID As Integer) As String
            Const iPallet_ShipType As Integer = 1 'DBR, NER ==============================
            Const iPallet_ShipType_NER As Integer = 2 'NER ==============================
            Dim iShip_ID As Integer = 9999919
            Dim strSQL As String
            Dim iPallett_ID As Integer = 0
            Dim PalletNamePrefix As String
            Dim strAMDBRPallett_Name As String
            Dim strDevice_IDs As String = ""
            Dim i As Integer = 0
            Dim objSkytel As New PSS.Data.Buisness.SkyTel()
            Dim dtDevice As DataTable
            Dim row As DataRow
            Dim strDevice_IDs1 As String = "", strDevice_IDs2 As String = ""

            Try
                PalletNamePrefix = objSkytel.GetPalletNamePrefixStr(iCust_ID)
                If iCust_ID = objSkytel.CriticalAlert_CUSTOMER_ID AndAlso iLoc_ID = objSkytel.CriticalAlertNorth_LOC_ID Then
                    strAMDBRPallett_Name = PalletNamePrefix & strDBRNER & Format(CDate(strWk_Dt), "yyMMdd") & "NN"
                ElseIf iCust_ID = objSkytel.CriticalAlert_CUSTOMER_ID AndAlso iLoc_ID = objSkytel.CriticalAlertSouth_LOC_ID Then
                    strAMDBRPallett_Name = PalletNamePrefix & strDBRNER & Format(CDate(strWk_Dt), "yyMMdd") & "SN"
                Else
                    strAMDBRPallett_Name = PalletNamePrefix & strDBRNER & Format(CDate(strWk_Dt), "yyMMdd") & "N"
                End If

                For i = 0 To arrlstDeviceIDs.Count - 1
                    If strDevice_IDs.Trim.Length > 0 Then strDevice_IDs &= ", "
                    strDevice_IDs &= arrlstDeviceIDs(i)
                Next
                strAMDBRPallett_Name = Me.DefinePalletName(strAMDBRPallett_Name, iCust_ID, iLoc_ID)

                If strDBRNER.Trim.ToUpper = "DBR" Then
                    iPallett_ID = Me.CreateShipPalletID(strAMDBRPallett_Name, iCust_ID, iLoc_ID, strWk_Dt, iPallet_ShipType, iPallett_Qty)
                ElseIf strDBRNER.Trim.ToUpper = "NER" Then
                    iPallett_ID = Me.CreateShipPalletID(strAMDBRPallett_Name, iCust_ID, iLoc_ID, strWk_Dt, iPallet_ShipType_NER, iPallett_Qty)
                End If

                If iPallett_ID = 0 Then
                    MsgBox("Can not create DBR-Pallet.")
                    strAMDBRPallett_Name = ""
                Else
                    strSQL = "SELECT * FROM tdevice WHERE Device_ID in ( " & strDevice_IDs & " ); "
                    dtDevice = Me._objDataProc.GetDataTable(strSQL)
                    If dtDevice.Rows.Count <> iPallett_Qty Then
                        MsgBox("Pallet quantity doesn't match device count (" & iPallett_Qty & " vs " & dtDevice.Rows.Count)
                        strAMDBRPallett_Name = ""
                    Else
                        For Each row In dtDevice.Rows 'each device, find any device has no Device_ShipWorkDate or no Device_DateShip
                            If row.IsNull("Device_ShipWorkDate") Then
                                If strDevice_IDs1.Trim.Length > 0 Then strDevice_IDs1 &= ", "
                                strDevice_IDs1 &= row("device_ID")
                            ElseIf row.IsNull("Device_DateShip") Then
                                If strDevice_IDs2.Trim.Length > 0 Then strDevice_IDs2 &= ", "
                                strDevice_IDs2 &= row("device_ID")
                            End If
                        Next
                        'Update all devices
                        strSQL = "UPDATE tdevice  " & Environment.NewLine
                        strSQL &= "SET Pallett_ID = " & iPallett_ID & Environment.NewLine
                        strSQL &= ", Ship_ID = " & iShip_ID & ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                        strSQL &= "WHERE Device_ID in ( " & strDevice_IDs & " );"
                        Me._objDataProc.ExecuteNonQuery(strSQL)
                        Generic.SetTmessdataWipOwnerdataForDevices("", 5, 0, iPallett_ID) 'Set wipowner to 5:Ready to ship

                        'Update missed dates
                        If strDevice_IDs1.Trim.Length > 0 Then
                            strSQL = "UPDATE tdevice " & Environment.NewLine
                            strSQL &= " SET Device_ShipWorkDate = '" & strWk_Dt & "'" & Environment.NewLine
                            strSQL &= "WHERE Device_ID in ( " & strDevice_IDs1 & " ); "
                            Me._objDataProc.ExecuteNonQuery(strSQL)
                        End If
                        If strDevice_IDs2.Trim.Length > 0 Then
                            strSQL = "UPDATE tdevice " & Environment.NewLine
                            strSQL &= " SET Device_DateShip = now()" & Environment.NewLine
                            strSQL &= "WHERE Device_ID in ( " & strDevice_IDs2 & " ); "
                            Me._objDataProc.ExecuteNonQuery(strSQL)
                        End If
                    End If
                End If

                Return strAMDBRPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                objSkytel = Nothing
            End Try
        End Function

        '*********************************************************************
        Public Function PalletizeAM_DBRPallet(ByVal iLoc_ID As Integer, _
                                              ByVal iCust_ID As Integer, _
                                              ByVal strDevice_IDs As String, _
                                              ByVal strWk_Dt As String, _
                                              ByVal iPallett_Qty As Integer) As String
            Const iPallet_ShipType As Integer = 1 'DBR
            Dim strSQL As String
            'Dim strAMDBRPallett_Name As String = "DBR" & Format(CDate(strWk_Dt), "yyMMdd") & "N"
            Dim iPallett_ID As Integer = 0
            Dim PalletNamePrefix As String
            Dim strAMDBRPallett_Name As String
            Dim objSkytel As New PSS.Data.Buisness.SkyTel()


            PalletNamePrefix = objSkytel.GetPalletNamePrefixStr(iCust_ID)

            strAMDBRPallett_Name = PalletNamePrefix & "DBR" & Format(CDate(strWk_Dt), "yyMMdd") & "N"

            Try
                strAMDBRPallett_Name = Me.DefinePalletName(strAMDBRPallett_Name, iCust_ID, iLoc_ID)
                iPallett_ID = Me.CreateShipPalletID(strAMDBRPallett_Name, iCust_ID, iLoc_ID, strWk_Dt, iPallet_ShipType, iPallett_Qty)

                If iPallett_ID = 0 Then
                    MsgBox("Can not create DBR-Pallet.")
                    strAMDBRPallett_Name = ""
                Else
                    strSQL = "UPDATE tdevice  " & Environment.NewLine
                    strSQL &= "SET Pallett_ID = " & iPallett_ID & Environment.NewLine
                    strSQL &= "WHERE Device_ID in ( " & strDevice_IDs & " );"
                    Me._objDataProc.ExecuteNonQuery(strSQL)
                    Generic.SetTmessdataWipOwnerdataForDevices("", 5, 0, iPallett_ID) 'Set wipowner to 5:Ready to ship
                End If

                Return strAMDBRPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                objSkytel = Nothing
            End Try
        End Function

        '*********************************************************************
        Public Function PalletizeAM_NERPallet(ByVal iLoc_ID As Integer, _
                                              ByVal iCust_ID As Integer, _
                                              ByVal strDevice_IDs As String, _
                                              ByVal strWk_Dt As String, _
                                              ByVal iPallett_Qty As Integer, _
                                              ByVal iShiftID As Integer) As String
            Const iPallet_ShipType = 2  'NER
            Dim strSQL As String
            Dim strPallett_Name As String = "NER" & Format(CDate(strWk_Dt), "yyMMdd") & "N"
            Dim iPallett_ID As Integer = 0
            Dim dtDevice As DataTable
            Dim row As DataRow
            Dim strDevice_IDs1 As String = "" 'Old way: when tdevice.Device_DateShip,Ship_ID, Shift_ID_Ship are not updated in Billing NER
            Dim strDevice_IDs2 As String = "" 'New way: when tdevice.Device_DateShip,Ship_ID, Shift_ID_Ship are updated in Billing NER and preEval NER

            Try
                strPallett_Name = Me.DefinePalletName(strPallett_Name, iCust_ID, iLoc_ID)
                iPallett_ID = Me.CreateShipPalletID(strPallett_Name, iCust_ID, iLoc_ID, strWk_Dt, iPallet_ShipType, iPallett_Qty)

                If iPallett_ID = 0 Then
                    MsgBox("Can not create NER-Pallet.")
                    strPallett_Name = ""
                Else
                    strSQL = "SELECT * FROM tdevice WHERE Device_ID in ( " & strDevice_IDs & " ); "
                    dtDevice = Me._objDataProc.GetDataTable(strSQL)
                    For Each row In dtDevice.Rows 'each device
                        If row.IsNull("Device_ShipWorkDate") Then
                            If strDevice_IDs1.Trim.Length = 0 Then
                                strDevice_IDs1 = row("device_ID")
                            Else
                                strDevice_IDs1 &= "," & row("device_ID")
                            End If
                        Else
                            If strDevice_IDs2.Trim.Length = 0 Then
                                strDevice_IDs2 = row("device_ID")
                            Else
                                strDevice_IDs2 &= "," & row("device_ID")
                            End If
                        End If
                    Next
                    If strDevice_IDs1.Trim.Length > 0 Then
                        strSQL = "UPDATE tdevice, tmessdata " & Environment.NewLine
                        strSQL &= "SET Pallett_ID = " & iPallett_ID & Environment.NewLine
                        strSQL &= ", Device_DateShip = now(), Ship_ID = 99999" & iLoc_ID & ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                        strSQL &= ", Device_ShipWorkDate = now(), wipowner_id_old = wipowner_id , wipowner_EntryDt = now(), wipowner_id = 5 , wipownersubloc_id  = 0" & Environment.NewLine
                        strSQL &= "WHERE tdevice.device_ID = tmessdata.device_ID and tdevice.Device_ID in ( " & strDevice_IDs1 & " ); "
                        Me._objDataProc.ExecuteNonQuery(strSQL)
                    End If
                    If strDevice_IDs2.Trim.Length > 0 Then
                        strSQL = "UPDATE tdevice, tmessdata " & Environment.NewLine
                        strSQL &= "SET Pallett_ID = " & iPallett_ID & Environment.NewLine
                        strSQL &= ", wipowner_id_old = wipowner_id , wipowner_EntryDt = now(), wipowner_id = 5 , wipownersubloc_id  = 0" & Environment.NewLine
                        strSQL &= "WHERE tdevice.device_ID = tmessdata.device_ID and tdevice.Device_ID in ( " & strDevice_IDs2 & " ); "
                        Me._objDataProc.ExecuteNonQuery(strSQL)
                    End If

                    'strSQL = "UPDATE tdevice, tmessdata " & Environment.NewLine
                    'strSQL &= "SET Pallett_ID = " & iPallett_ID & Environment.NewLine
                    'strSQL &= ", Device_DateShip = now(), Ship_ID = 99999" & iLoc_ID & ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                    'strSQL &= ", Device_ShipWorkDate = now(), wipowner_id_old = wipowner_id , wipowner_EntryDt = now(), wipowner_id = 5 , wipownersubloc_id  = 0" & Environment.NewLine
                    'strSQL &= "WHERE tdevice.device_ID = tmessdata.device_ID and tdevice.Device_ID in ( " & strDevice_IDs & " ); "
                    'Me._objDataProc.ExecuteNonQuery(strSQL)
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetShipPalletData(ByVal strPalletName As String, _
                                          ByVal iCount As Integer, _
                                          ByVal strResult As String, _
                                          ByVal strShipType As String, _
                                          ByVal strFooter() As String, _
                                          Optional ByVal strBaud As String = "") As DataTable
            Dim strSQL As String

            Try
                'strSQL = "SELECT " & iCount.ToString & " AS DeviceCount, '" & strPalletName & "' AS PalletName, '" & strResult & "' AS Result, '" & strShipType & "' AS ShipType, '' AS Var, 'Lead:' AS AppLead"
                strSQL = "SELECT " & iCount.ToString & " AS DeviceCount, '" & strPalletName & "' AS PalletName, '" & strResult & "' AS Result, '" & strShipType & "' AS ShipType,'" & strBaud & "' AS Result2,'' AS Var, '" & strFooter(0) & "' AS Footer1, '" & strFooter(1) & "' AS Footer2, '" & strFooter(2) & "' AS Footer3"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetShipCustomerData(ByVal strCustomerName As String, _
                                            ByVal strPalletName As String, _
                                            ByVal iCount As Integer, _
                                            ByVal strModel As String, _
                                            ByVal strShipType As String, _
                                            ByVal strFooter() As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT " & iCount.ToString & " AS DeviceCount, '" & strCustomerName & "' as CustomerName, '" & strPalletName & "' AS PalletName, '" & strModel & "' AS Model, '" & strShipType & "' AS ShipType, '" & strFooter(0) & "' AS Footer1, '" & strFooter(1) & "' AS Footer2, '" & strFooter(2) & "' AS Footer3"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************
        Public Function GetDBRFailCode(ByVal iDevice_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT Dcode_ID " & Environment.NewLine
                strSQL &= "FROM tdevicecodes   " & Environment.NewLine
                strSQL &= "WHERE Device_ID = " & iDevice_ID & " " & Environment.NewLine
                strSQL &= "ORDER BY devicecode_id DESC"

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetDBRNERFailCodeData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT IF(length(trim(B.Dcode_Ldesc))>0,B.Dcode_LDesc,'Invalid Reason') AS 'Reason', A.DeviceCode_ID,A.Device_ID,A.Dcode_ID" & Environment.NewLine
                strSQL &= " FROM tdevicecodes A" & Environment.NewLine
                strSQL &= " LEFT JOIN lcodesdetail B ON A.Dcode_ID=B.Dcode_ID" & Environment.NewLine
                strSQL &= " WHERE A.Device_ID = " & iDevice_ID & ";" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function DeleteDBRNERFailCode(ByVal strDeviceCodeIDs As String) As Integer
            Dim strSQL As String

            Try
                strSQL = "DELETE FROM tdevicecodes " & Environment.NewLine
                strSQL &= " WHERE devicecode_id IN ( " & strDeviceCodeIDs & ");" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function CheckExistingOfSN(ByVal strSN As String) As String
            Dim strSNStatus As String = ""
            Dim strSQL As String
            Dim dt As DataTable
            Dim iNumDtFrLastScan As Integer = 0
            Dim strTodayDT As String = ""

            Try
                strTodayDT = Buisness.Generic.MySQLServerDateTime(1)

                strSQL = "SELECT SC_Desc, tam_outtorep_manifest.* " & Environment.NewLine
                strSQL &= "FROM tam_outtorep_manifest " & Environment.NewLine
                strSQL &= "INNER JOIN tsubcontractor ON tam_outtorep_manifest.SC_ID = tsubcontractor.SC_ID " & Environment.NewLine
                strSQL &= "WHERE Device_SN = '" & strSN & "'" & Environment.NewLine
                strSQL &= "ORDER BY AMOTR_ID DESC"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0)("AMOTR_ManifestDt")) Then
                            iNumDtFrLastScan = DateDiff(DateInterval.Day, dt.Rows(0)("AMOTR_ManifestDt"), CDate(strTodayDT))
                            If iNumDtFrLastScan <= 7 Then
                                strSNStatus = "Device has been palletized on " & dt.Rows(0)("AMOTR_ManifestDt") & " and sent to " & dt.Rows(0)("SC_Desc") & " within 7 days." & Environment.NewLine
                                strSNStatus &= "This SN could be a duplicate SN."
                            End If
                        End If
                    End If
                End If

                Return strSNStatus
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*********************************************************************
        Public Function PalletizeAM_OutToRepPallet(ByVal iLoc_ID As Integer, _
                                              ByVal iCust_ID As Integer, _
                                              ByVal lstDevice_SNs As System.Windows.Forms.ListBox, _
                                              ByVal strWk_Dt As String, _
                                              ByVal iSC_ID As Integer, _
                                              ByRef iPallett_ID As Integer) As String
            Dim strSQL As String
            Dim strAMOTRep_PallettName As String = "", strPrefixName As String = ""
            Dim iPallet_ShipType = 0  'out source to repair
            Dim strSC_ShortDesc As String = ""
            Dim i As Integer = 0
            Dim j As Integer = 0

            Try
                '*************************************
                'Get subcontractor short description
                '*************************************
                strSQL = "SELECT SC_SDesc FROM tsubcontractor WHERE SC_ID = " & iSC_ID & ";"
                strSC_ShortDesc = Me._objDataProc.GetSingletonString(strSQL)
                If strSC_ShortDesc = "" Then
                    Throw New Exception("Can't find short description of selected location.")
                End If

                Select Case iCust_ID
                    Case PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID
                        strPrefixName = "AM"
                    Case PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID
                        strPrefixName = "SK"
                    Case PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID
                        strPrefixName = "MR"
                    Case PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID
                        strPrefixName = "PR"
                    Case PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID
                        strPrefixName = "AQ"
                End Select

                strAMOTRep_PallettName = strPrefixName & strSC_ShortDesc & Format(CDate(strWk_Dt), "yyyyMMdd") & "N"
                strAMOTRep_PallettName = Me.DefinePalletName(strAMOTRep_PallettName, iCust_ID, iLoc_ID)
                iPallett_ID = Me.CreateShipPalletID(strAMOTRep_PallettName, iCust_ID, iLoc_ID, strWk_Dt, iPallet_ShipType, lstDevice_SNs.Items.Count)

                If iPallett_ID = 0 Then
                    MsgBox("Can not create Manifest-Pallet.")
                    strAMOTRep_PallettName = ""
                Else
                    For i = 0 To lstDevice_SNs.Items.Count - 1
                        strSQL = "INSERT INTO tam_outtorep_manifest ( " & Environment.NewLine
                        strSQL &= "Device_SN " & Environment.NewLine
                        strSQL &= ", Pallett_ID " & Environment.NewLine
                        strSQL &= ", SC_ID " & Environment.NewLine
                        strSQL &= ", AMOTR_ManifestDt " & Environment.NewLine
                        strSQL &= ") VALUES ( " & Environment.NewLine
                        strSQL &= "'" & lstDevice_SNs.Items.Item(i) & "' " & Environment.NewLine
                        strSQL &= ", " & iPallett_ID & " " & Environment.NewLine
                        strSQL &= ", " & iSC_ID & " " & Environment.NewLine
                        strSQL &= ", '" & strWk_Dt & "' " & Environment.NewLine
                        strSQL &= ");"
                        j = Me._objDataProc.ExecuteNonQuery(strSQL)
                    Next i
                End If

                Return strAMOTRep_PallettName
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetOTRep_SNData(ByVal iPallett_ID As Integer) As DataTable
            Dim strSQL, strCurDate As String
            Dim dtTemp, dt As DataTable
            Dim drTemp, dr As DataRow
            Dim strSNTemp As String = ""
            Dim i As Integer

            Try
                strCurDate = Format(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)), "MM/dd/yyyy")

                strSQL = "SELECT DISTINCT Device_SN AS SN, CONCAT('*',Device_SN, '*') AS 'SN Barcode', SC_Desc as 'Location', AMOTR_ManifestDt AS 'Ship Date' " & Environment.NewLine
                strSQL &= "FROM tam_outtorep_manifest " & Environment.NewLine
                strSQL &= "INNER JOIN tsubcontractor ON tam_outtorep_manifest.SC_ID = tsubcontractor.SC_ID " & Environment.NewLine
                strSQL &= "WHERE tam_outtorep_manifest.Pallett_ID = " & iPallett_ID & " " & Environment.NewLine
                strSQL &= "ORDER BY Device_SN DESC"

                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            Finally
                drTemp = Nothing
                dr = Nothing

                If Not IsNothing(dtTemp) Then
                    dtTemp.Dispose()
                    dtTemp = Nothing
                End If

                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '****************************************************************
        Public Function GetDevCountByPalletID(ByVal iPallett_ID As Integer) As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT count(*) as cnt " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE Pallett_ID = " & iPallett_ID & " " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetAMOutToRepLotInfo(ByVal strLotName As String) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT tpallett.Pallett_Name, tpallett.Pallett_QTY, tam_outtorep_manifest.*,  tsubcontractor.SC_SDesc,  tsubcontractor.SC_Desc " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "INNER JOIN tam_outtorep_manifest ON tpallett.Pallett_ID = tam_outtorep_manifest.Pallett_ID" & Environment.NewLine
                strSQL &= "INNER JOIN tsubcontractor ON tam_outtorep_manifest.SC_ID = tsubcontractor.SC_ID" & Environment.NewLine
                strSQL &= "WHERE tpallett.Pallett_Name = '" & strLotName & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetDeviceBillingInfo(ByVal iDevice_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT tdevicebill.BillCode_ID, lbillcodes.BillCode_Desc, lbillcodes.BillCode_Rule, lbillcodes.BillType_ID " & Environment.NewLine
                strSQL &= "FROM tdevicebill " & Environment.NewLine
                strSQL &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSQL &= "WHERE tdevicebill.Device_ID = " & iDevice_ID & " " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetDeviceData(ByVal iDevice_ID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "WHERE Device_ID = " & iDevice_ID & " " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function IsBillableBillcode(ByVal iBillcodeID As Integer, _
                                           ByVal iModelID As Integer) As Boolean
            Dim strSQL As String
            Dim booResult As Boolean = False
            Dim dt As DataTable

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpsmap " & Environment.NewLine
                strSQL &= "WHERE tpsmap.Billcode_ID = " & iBillcodeID & " " & Environment.NewLine
                strSQL &= "AND tpsmap.Model_ID = " & iModelID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count = 1 And dt.Rows(0)("Inactive") = 0 Then booResult = True

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function GetDBRSNDataByPalletName(ByVal strDBRPallett_name As String) As DataTable
            Dim strSQL As String

            Try
                If strDBRPallett_name.StartsWith("DBR") Then
                    strSQL = "SELECT DISTINCT D.Model_Desc As Model, B.Device_SN AS SN, CONCAT('*', B.Device_SN, '*') AS 'SN Barcode', F.Capcode, E.Dcode_Ldesc AS 'Reason', date_format(A.Pallett_ShipDate, '%m/%d/%Y') AS 'Ship Date' " & Environment.NewLine
                    strSQL &= "FROM tpallett A" & Environment.NewLine
                    strSQL &= "INNER JOIN tdevice B on A.pallett_id = B.pallett_id " & Environment.NewLine
                    strSQL &= "LEFT JOIN tdevicecodes  on tdevicecodes.Device_ID = B.Device_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel D on D.Model_ID = B.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN lcodesdetail E on E.Dcode_ID = tdevicecodes.Dcode_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmessdata F on B.Device_ID = F.Device_ID " & Environment.NewLine
                    strSQL &= "WHERE A.Pallett_name = '" & strDBRPallett_name & "' " & Environment.NewLine
                    strSQL &= "ORDER BY D.Model_Desc, B.Device_SN, B.Device_DateShip DESC"

                    Return Me._objDataProc.GetDataTable(strSQL)

                ElseIf strDBRPallett_name.StartsWith("NER") Then
                    strSQL = "SELECT DISTINCT D.Model_Desc As Model, B.Device_SN AS SN, CONCAT('*', B.Device_SN, '*') AS 'SN Barcode', E.Capcode, 'NER' AS 'Reason', date_format(A.Pallett_ShipDate, '%m/%d/%Y') AS 'Ship Date' " & Environment.NewLine
                    strSQL &= "FROM tpallett A" & Environment.NewLine
                    strSQL &= "INNER JOIN tdevice B on A.pallett_id = B.pallett_id " & Environment.NewLine
                    strSQL &= "LEFT JOIN tdevicecodes  on tdevicecodes.Device_ID = B.Device_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmodel D on D.Model_ID = B.Model_ID " & Environment.NewLine
                    strSQL &= "INNER JOIN tmessdata E on B.Device_ID = E.Device_ID " & Environment.NewLine
                    strSQL &= "WHERE A.Pallett_name = '" & strDBRPallett_name & "' " & Environment.NewLine
                    strSQL &= "ORDER BY D.Model_Desc, B.Device_SN, B.Device_DateShip DESC"
                    Return Me._objDataProc.GetDataTable(strSQL)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetDBRNERSNDataByPalletName(ByVal strPallett_name As String) As DataTable
            Dim strSQL As String

            Try

                strSQL = "SELECT DISTINCT D.Model_Desc As Model, B.Device_SN AS SN, CONCAT('*', B.Device_SN, '*') AS 'SN Barcode', F.Capcode, E.Dcode_Ldesc AS 'Reason', date_format(A.Pallett_ShipDate, '%m/%d/%Y') AS 'Ship Date'" & Environment.NewLine
                strSQL &= ",A.Cust_ID,B.Loc_ID,G.Cust_Name1 as 'Customer' " & Environment.NewLine
                strSQL &= "FROM tpallett A" & Environment.NewLine
                strSQL &= "INNER JOIN tdevice B on A.pallett_id = B.pallett_id " & Environment.NewLine
                strSQL &= "LEFT JOIN tdevicecodes  on tdevicecodes.Device_ID = B.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel D on D.Model_ID = B.Model_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lcodesdetail E on E.Dcode_ID = tdevicecodes.Dcode_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tmessdata F on B.Device_ID = F.Device_ID " & Environment.NewLine
                strSQL &= "INNER JOIN tcustomer G on A.Cust_ID=G.Cust_ID " & Environment.NewLine
                strSQL &= "WHERE A.Pallett_name = '" & strPallett_name & "' " & Environment.NewLine
                strSQL &= "ORDER BY D.Model_Desc, B.Device_SN, B.Device_DateShip DESC"

                Return Me._objDataProc.GetDataTable(strSQL)


            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        Public Function GetNERReasons(ByVal bAddSelectRow As Boolean, _
                                      Optional ByVal bEmptyRow As Boolean = False, _
                                      Optional ByVal bIsAMS As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                If bIsAMS Then
                    strSql = "SELECT Dcode_ID, Dcode_LDesc, Conv_ID, Concat(Conv_ID, ' - ', Dcode_LDesc) as DispalyDesc " & Environment.NewLine
                    strSql &= " FROM lcodesdetail where MCode_ID = 78 AND Dcode_Inactive = 0 order by Dcode_ID"
                Else
                    strSql = "SELECT Dcode_ID, Dcode_LDesc, Conv_ID, Concat(Conv_ID, ' - ', Dcode_LDesc) as DispalyDesc " & Environment.NewLine
                    strSql &= " FROM lcodesdetail where MCode_ID = 61 AND Dcode_Inactive = 0 order by Dcode_ID"
                End If

                dt = Me._objDataProc.GetDataTable(strSql)

                If bAddSelectRow Then
                    If bEmptyRow Then
                        dt.LoadDataRow(New Object() {"0", " ", 0, " "}, False)
                    Else
                        dt.LoadDataRow(New Object() {"0", "--SELECT--", 0, "--SELECT--"}, False)
                    End If
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function RemoveNERReason(ByVal iDeviceID As Integer, ByVal iDcodeID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "DELETE FROM tdevicecodes WHERE Device_ID = " & iDeviceID & " AND Dcode_ID = " & iDcodeID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************
        Public Function AddDeviceCode(ByVal iDeviceID As Integer, ByVal iDcodeID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO tdevicecodes ( Device_ID, Dcode_ID ) VALUES ( " & iDeviceID & ", " & iDcodeID & " ) " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try

            '****************************************************************

        End Function
    End Class
End Namespace