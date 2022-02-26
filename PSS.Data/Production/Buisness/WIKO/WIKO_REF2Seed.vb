Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.WIKO
    Public Class WIKO_REF2Seed

        Private _objDataProc As DBQuery.DataProc

        Private _strSeedType As String = "'" & PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStockSourceType_Cricket & "'," & _
                                        "'" & PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStockSourceType_ATT & "'"

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

        Public Function GetREF2SeedstockData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iModel_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable, dtBill As DataTable, dtTmp As DataTable, dtFinal As DataTable
            Dim strDevice_IDs As String = ""
            Dim arrLstDeviceIDs As New ArrayList()
            Dim arrLstDeviceIDs_BillServices As New ArrayList()
            Dim row As DataRow, row2 As DataRow
            Dim i As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strBillCode_IDs As String = ""
            Dim strBillCodes As String = ""
            Dim iCricket_Loc_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID
            Dim iAttCTDI_Loc_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID
            Dim iAttFedEx_Loc_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
           

            Try
                If iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    strSql = "SELECT 0 AS 'Rec_Num',D.Loc_Name As 'Location',A.Device_SN AS 'SN',C.Model_Desc AS 'Model',Date_Format(A.Device_DateBill,'%Y-%m-%d') AS 'Bill_Date'" & Environment.NewLine
                    strSql &= " ,Date_Format(A.Device_DateRec,'%Y-%m-%d') AS 'Recv_Date',E.BoxID AS 'Recv_Box',B.ClaimNo AS 'PO',B.In_Pallet_ID,'' AS 'BillCode_IDs','' AS 'BillCodes'" & Environment.NewLine
                    strSql &= " ,if(A.Loc_ID=" & iCricket_Loc_ID & ",B.ShipTo_Name,if((A.Loc_ID=" & iAttCTDI_Loc_ID & " OR A.Loc_ID=" & iAttFedEx_Loc_ID & "),B.Account,'')) as 'Type',F.Device_SN AS 'Swapped_SN',A.Loc_ID,B.Cust_ID,B.EW_ID,A.Device_ID,B.Swapped_Device_ID,A.Model_ID,B.wb_ID,B.BulkOrderType_ID" & Environment.NewLine
                    strSql &= " FROM production.tdevice A" & Environment.NewLine
                    strSql &= " INNER JOIN production.extendedwarranty B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tlocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdevice F ON F.Device_ID=B.Swapped_Device_ID" & Environment.NewLine
                    strSql &= " LEFT JOIN edi.twarehousebox E ON B.wb_ID=E.wb_ID" & Environment.NewLine
                    strSql &= " WHERE B.Cust_ID=" & iCust_ID & " AND A.Loc_ID = " & iLoc_ID & " AND A.Device_DateShip IS NULL AND C.model_ID= " & iModel_ID & " AND B.Account NOT IN (" & Me._strSeedType & ")  AND B.BulkOrderType_ID =1 AND B.Swapped_Device_ID > 0 AND A.Pallett_ID IS NULL;" & Environment.NewLine

                ElseIf iCust_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                    strSql = "SELECT 0 AS 'Rec_Num',D.Loc_Name As 'Location',A.Device_SN AS 'SN',C.Model_Desc AS 'Model',Date_Format(A.Device_DateBill,'%Y-%m-%d') AS 'Bill_Date'" & Environment.NewLine
                    strSql &= " ,Date_Format(A.Device_DateRec,'%Y-%m-%d') AS 'Recv_Date',E.BoxID AS 'Recv_Box',B.ClaimNo AS 'PO',B.In_Pallet_ID,'' AS 'BillCode_IDs','' AS 'BillCodes'" & Environment.NewLine
                    strSql &= " ,A.Loc_ID,B.Cust_ID,B.EW_ID,A.Device_ID,A.Model_ID,B.wb_ID,B.BulkOrderType_ID" & Environment.NewLine
                    strSql &= " FROM production.tdevice A" & Environment.NewLine
                    strSql &= " INNER JOIN production.extendedwarranty B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tlocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                    strSql &= " LEFT JOIN edi.twarehousebox E ON B.wb_ID=E.wb_ID" & Environment.NewLine
                    strSql &= " WHERE B.Cust_ID=" & iCust_ID & " AND A.Loc_ID = " & iLoc_ID & " AND A.Device_DateShip IS NULL AND C.model_ID= " & iModel_ID & " AND B.BulkOrderType_ID =1 AND B.Swapped_Device_ID > 0 AND A.Pallett_ID IS NULL;" & Environment.NewLine

                Else
                    strSql = "Select 'Undefined' as 'NoData' limit 0"
                End If

                dt = Me._objDataProc.GetDataTable(strSql)
                dtFinal = dt.Clone

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        If Not arrLstDeviceIDs.Contains(row("Device_ID")) Then
                            arrLstDeviceIDs.Add(row("Device_ID"))
                            If strDevice_IDs.Trim.Length = 0 Then
                                strDevice_IDs = row("Device_ID")
                            Else
                                strDevice_IDs &= "," & row("Device_ID")
                            End If
                        End If
                    Next

                    'Services devcies
                    strSql = "SELECT A.Device_ID,B.BillCode_ID" & Environment.NewLine
                    strSql &= " FROM production.tdevicebill A" & Environment.NewLine
                    strSql &= " INNER JOIN production.lbillcodes B ON A.BillCode_ID=B.BillCode_ID" & Environment.NewLine
                    strSql &= " WHERE A.Device_ID IN (" & strDevice_IDs & ") AND B.BillType_ID=1;" & Environment.NewLine
                    dtBill = Me._objDataProc.GetDataTable(strSql)

                    If dtBill.Rows.Count > 0 Then
                        For Each row In dtBill.Rows
                            If Not arrLstDeviceIDs_BillServices.Contains(row("Device_ID")) Then arrLstDeviceIDs_BillServices.Add(row("Device_ID"))
                        Next
                        'Filter out service devcies
                        For Each row In dt.Rows
                            If Not arrLstDeviceIDs_BillServices.Contains(row("Device_ID")) Then
                                iDevice_ID = row("Device_ID")
                                strSql = "SELECT A.Device_ID,B.BillCode_ID,B.BillCode_Desc" & Environment.NewLine
                                strSql &= " FROM production.tdevicebill A" & Environment.NewLine
                                strSql &= " INNER JOIN production.lbillcodes B ON A.BillCode_ID=B.BillCode_ID" & Environment.NewLine
                                strSql &= " WHERE A.Device_ID=" & iDevice_ID
                                dtTmp = Me._objDataProc.GetDataTable(strSql)
                                strBillCode_IDs = ""
                                If dtTmp.Rows.Count > 0 Then 'only those devices have billed info
                                    For Each row2 In dtTmp.Rows
                                        If strBillCode_IDs.Trim.Length = 0 Then
                                            strBillCode_IDs = row2("BillCode_ID") : strBillCodes = row2("BillCode_Desc")
                                        Else
                                            strBillCode_IDs &= "," & row2("BillCode_ID") : strBillCodes &= "," & row2("BillCode_Desc")
                                        End If
                                    Next
                                    row.BeginEdit() : row("BillCode_IDs") = strBillCode_IDs : row("BillCodes") = strBillCodes : row.AcceptChanges()
                                    dtFinal.ImportRow(row)
                                End If
                            End If
                        Next
                    Else
                        For Each row In dt.Rows
                            iDevice_ID = row("Device_ID")
                            strSql = "SELECT A.Device_ID,B.BillCode_ID,B.BillCode_Desc" & Environment.NewLine
                            strSql &= " FROM production.tdevicebill A" & Environment.NewLine
                            strSql &= " INNER JOIN production.lbillcodes B ON A.BillCode_ID=B.BillCode_ID" & Environment.NewLine
                            strSql &= " WHERE A.Device_ID=" & iDevice_ID
                            dtTmp = Me._objDataProc.GetDataTable(strSql)
                            If dtTmp.Rows.Count > 0 Then 'only those devices have billed info
                                For Each row2 In dtTmp.Rows
                                    If strBillCode_IDs.Trim.Length = 0 Then
                                        strBillCode_IDs = row2("BillCode_ID") : strBillCodes = row2("BillCode_Desc")
                                    Else
                                        strBillCode_IDs &= "," & row2("BillCode_ID") : strBillCodes &= "," & row2("BillCode_Desc")
                                    End If
                                Next
                                row.BeginEdit() : row("BillCode_IDs") = strBillCode_IDs : row("BillCodes") = strBillCodes : row.AcceptChanges()
                                dtFinal.ImportRow(row)
                            End If
                        Next
                    End If
                End If

                If dtFinal.Rows.Count > 0 Then
                    For Each row In dtFinal.Rows
                        i += 1
                        row.BeginEdit() : row("Rec_Num") = i : row.AcceptChanges()
                    Next
                End If
                Return dtFinal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsAlreadyUnusedSeedstockDevice(ByVal iCust_ID As Integer, ByVal strSN As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable, dt2 As DataTable
            Dim bRet As Boolean = False
            Dim iDevice_ID As Integer = 0

            Try
                strSql = "Select device_ID from production.extendedwarranty" & Environment.NewLine
                strSql &= " Where cust_ID=" & iCust_ID & " And extendedwarranty.Account in (" & Me._strSeedType & ") And SerialNo='" & strSN & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    iDevice_ID = dt.Rows(0).Item("Device_ID")

                    strSql = "Select * from production.extendedwarranty where swapped_device_ID=" & iDevice_ID & ";"
                    dt2 = Me._objDataProc.GetDataTable(strSql)
                    If Not dt2.Rows.Count > 0 Then bRet = True
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ProcessREF2Seedstock(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iWO_ID As Integer, _
                                             ByVal strDevice_IDs As String, ByVal strDevice_SNs As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable, dt2 As DataTable

            Dim iDevice_ID As Integer = 0
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strDate As String = Format(Now, "yyyy-MM-dd")
            Dim strSourceUnqID As String = "REF2Seed_" & Format(Now, "yyyyMMddHHmmss_ffffff")
            Dim iPallet_ID As Integer = 0
            Dim strPallet_Name As String = ""
            Dim strCarrier As String = ""
            Dim j As Integer = 0
            Dim iBulkORderType_ID As Integer = 0 'seedstock =0
            Dim random As New random()

            Try

                strSourceUnqID &= "_" & PSS.Data.Buisness.Generic.RandomString(6, True) & Convert.ToString(random.Next(100000, 999999)).Trim

                Select Case iLoc_ID
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID
                        iPallet_ID = 373884
                        strPallet_Name = "2624SDS20210301N001"
                        strCarrier = "Cricket"
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID
                        iPallet_ID = 373885
                        strPallet_Name = "2624SDS20210301N002"
                        strCarrier = "ATT"
                    Case PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
                        iPallet_ID = 373886
                        strPallet_Name = "2624SDS20210301N003"
                        strCarrier = "ATT"
                    Case PSS.Data.Buisness.CP.CoolPad.CoolPad_CP1_Loc_ID
                        iPallet_ID = 373887
                        strPallet_Name = "2627SDS20210301N001"
                    Case Else
                        Throw New Exception("location ID is not defined!")
                End Select

                'Close devices
                strSql = " Update tdevice" & Environment.NewLine
                strSql &= " set device_dateShip='" & strDTime & "',Device_ShipWorkDate='" & strDate & "',pallett_ID=" & iPallet_ID & Environment.NewLine
                strSql &= "  WHERE device_ID IN (" & strDevice_IDs & ");" & Environment.NewLine
                j = Me._objDataProc.ExecuteNonQuery(strSql)


                If iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    'REF2Seestock data- saved as ASN

                    strSql = "INSERT INTO production.extendedwarranty (Cust_ID, Loc_ID, WO_ID, BulkORderType_ID, LoadedDateTime, In_Carton_ID, Item_SKU, ClaimNo, SerialNo, Account, SourceFile)" & Environment.NewLine
                    strSql &= " SELECT " & iCust_ID & " Cust_ID," & iLoc_ID & " AS Loc_ID," & iWO_ID & " AS WO_ID," & iBulkORderType_ID & " AS BulkORderType_ID,'" & strDTime & "' AS LoadedDateTime,'" & strPallet_Name & "' AS In_Carton_ID,B.Item_SKU, " & iPallet_ID & " AS ClaimNo, A.device_SN as SerialNo, '" & strCarrier & "' as Account, '" & strSourceUnqID & "' AS SourceFile" & Environment.NewLine
                    strSql &= " FROM production.tdevice A" & Environment.NewLine
                    strSql &= " INNER JOIN production.extendedwarranty B ON A.device_ID=B.Device_ID" & Environment.NewLine
                    strSql &= " WHERE A.device_ID in (" & Environment.NewLine
                    strSql &= strDevice_IDs & Environment.NewLine
                    strSql &= ");" & Environment.NewLine

                    j += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "SELECT * FROM production.extendedwarranty WHERE SourceFile='" & strSourceUnqID & "'"
                    dt = Me._objDataProc.GetDataTable(strSql)

                ElseIf iCust_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                    strSql = "INSERT INTO production.extendedwarranty" & Environment.NewLine
                    strSql &= " (Cust_ID, Loc_ID, WO_ID, BulkORderType_ID, LoadedDateTime, Item_SKU, In_Carton_ID, SerialNo, HD_SerialNo, R_SerialNo, MEID_HEX, MEID_DEC, ICC_ID, MSL, OTKSL, Model_MotoSku, Version, SourceFile)" & Environment.NewLine
                    strSql &= " SELECT " & iCust_ID & " Cust_ID," & iLoc_ID & " AS Loc_ID," & iWO_ID & " AS WO_ID," & iBulkORderType_ID & " AS BulkORderType_ID,'" & strDTime & "' AS LoadedDateTime" & Environment.NewLine
                    strSql &= " ,B.Item_SKU, '" & strPallet_Name & "' as In_Carton_ID,A.device_SN as SerialNo, '' as HD_SerialNo, '' as R_SerialNo, '' AS MEID_HEX, '' as MEID_DEC" & Environment.NewLine
                    strSql &= " ,'' as ICC_ID,'' AS MSL,'' AS	OTKSL,C.Model_MotoSku,'' AS  Version,'" & strSourceUnqID & "' as  SourceFile" & Environment.NewLine
                    strSql &= " FROM production.tdevice A" & Environment.NewLine
                    strSql &= " INNER JOIN production.extendedwarranty B ON A.device_ID=B.Device_ID" & Environment.NewLine
                    strSql &= " INNER join production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                    strSql &= " WHERE A.device_id in (" & Environment.NewLine
                    strSql &= strDevice_IDs & Environment.NewLine
                    strSql &= ");" & Environment.NewLine

                    j += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "SELECT * FROM production.extendedwarranty WHERE SourceFile='" & strSourceUnqID & "'"
                    dt = Me._objDataProc.GetDataTable(strSql)

                Else
                    Throw New Exception("Customer is not defined!")
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWorkOrderID(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim strWO_Name As String = "WiKo_C" & iCust_ID.ToString & "REF2Seed"
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                If iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    strWO_Name = "WiKo_C" & iCust_ID.ToString & "REF2Seed"
                ElseIf iCust_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                    strWO_Name = "CP_C" & iCust_ID.ToString & "REF2Seed"
                Else
                    strWO_Name = "Invalid_C" & iCust_ID.ToString & "REF2Seed"
                End If

                strSql = "INSERT INTO production.tWorkOrder (WO_CustWO,WO_Date,WO_Quantity,Loc_ID,WO_Closed,Prod_ID) VALUES (" & _
                             "'" & strWO_Name & "','" & strDateTime & "',1," & iLoc_ID & ",0,2);"
                Return Me._objDataProc.idTransaction(strSql, "production.tWorkOrder")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetManufDate(ByVal strSN As String, ByVal strDevice_IDs As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strManufDate As String = ""
            Dim row As DataRow

            Try
                strSql = "select A.Device_ID,A.device_SN,C.CellOpt_DateCode as 'ManufDate'" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " Inner JOIN extendedwarranty B ON A.device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " Inner join tcellopt C ON A.device_ID=C.Device_ID" & Environment.NewLine
                strSql &= " where A.device_ID in (" & Environment.NewLine
                strSql &= strDevice_IDs
                strSql &= ") and A.Device_SN ='" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each row In dt.Rows 'if find, it should be 1 record
                    If Not row.IsNull("ManufDate") AndAlso Convert.ToString(row("ManufDate")).Trim.Length > 0 Then strManufDate = Convert.ToString(row("ManufDate")).Trim
                    Exit For
                Next
                Return strManufDate
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
