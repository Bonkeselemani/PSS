Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data


Namespace Buisness.WIKO
    Public Class WIKO_Receiving
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

        Public Function getWiKoRecvTableDef() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT 0 AS 'RecID','' AS 'SN','' AS 'ASN_SKU','' AS 'ASN_SKU_Desc','' AS 'PSS_Model','' AS 'Manuf_Date','' AS 'Return_Type','' AS 'Vendor','' AS 'PO','' AS 'Loc'" & Environment.NewLine
                strSql &= " ,'' AS 'Vendor_ID',0 AS 'Model_ID',0 AS 'Loc_ID',0 AS 'EW_ID',0 AS 'Device_ID',0 AS 'wb_ID'" & Environment.NewLine
                strSql &= " LIMIT 0;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWiKoLocations_SeedStock(ByVal iCust_ID As Integer, _
                                        ByVal booAddSelectRow As Boolean, _
                                        ByVal iLocID_Exclude As Int32) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Loc_ID,Loc_Name from production.tlocation WHERE Cust_ID=" & iCust_ID & " AND LOC_ID <> " & iLocID_Exclude & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getWiKoSeedStockRecvTableDef() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT 0 AS 'RecID','' AS 'SN','' AS 'ASN_SKU','' AS 'PSS_Model','' AS 'Manuf_Date','' AS 'PO','' AS 'CustLoc'" & Environment.NewLine
                strSql &= " ,0 AS 'Model_ID',0 AS 'Loc_ID',0 AS 'EW_ID',0 AS 'Device_ID',0 AS 'wb_ID'" & Environment.NewLine
                strSql &= " LIMIT 0;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getCustomerLocation(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try
                strSql = "select A.Cust_ID,A.Cust_Name1 AS 'Cust_Name',B.Loc_ID,B.Loc_Name from tcustomer A" & Environment.NewLine
                strSql &= " Inner join tlocation B ON A.Cust_ID=B.Cust_ID where A.cust_ID=" & iCust_ID & " AND B.Loc_ID=" & iLoc_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then strRet = dt.Rows(0).Item("Cust_Name") & " " & dt.Rows(0).Item("Loc_Name")
                Return strRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getReceivedUnshipped(ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "select * from production.tdevice where Loc_ID=" & iLoc_ID & " AND Device_DateShip IS NULL AND Device_SN ='" & strSN & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getModelData(ByVal iProd_ID As Integer, ByVal strModel_Desc As String) As DataTable
            Dim strSql As String = ""

            Try
                strModel_Desc = strModel_Desc.Replace("'", "''")
                strSql = "SELECT * FROM production.tModel WHERE Prod_ID = " & iProd_ID & " AND  Model_Desc = '" & strModel_Desc & "';"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getReceivingData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSN = strSN.Replace("'", "''")

                strSql = "SELECT EW_ID,CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer',SerialNo AS 'SN',ClaimNo AS 'RA_Number',Item_SKU" & Environment.NewLine
                strSql &= " , IF(DATE IS NULL,'', IF(DATE_FORMAT(DATE,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(DATE,'%Y-%m-%d'))) AS 'RA_Date', A.Account AS 'OEM_Account'" & Environment.NewLine
                strSql &= " ,ShipTo_Name AS 'Customer_Name',IF(Carrier_Dock_Date  IS NULL,'', IF(DATE_FORMAT(Carrier_Dock_Date ,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Carrier_Dock_Date ,'%Y-%m-%d'))) AS 'Carrier_Date'" & Environment.NewLine
                strSql &= " ,IF(IMM_Dock_Date  IS NULL,'', IF(DATE_FORMAT(IMM_Dock_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Dock_Date ,'%Y-%m-%d')))  AS 'IMM Date',Customer_Work_Number AS 'Cust_WO'" & Environment.NewLine
                strSql &= " ,Return_Type,Return_Reason,Item_Desc" & Environment.NewLine
                strSql &= " ,IF(Original_To_RA_Date  IS NULL,'', IF(DATE_FORMAT(Original_To_RA_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(Original_To_RA_Date ,'%Y-%m-%d'))) AS 'To_RA_Date'" & Environment.NewLine
                strSql &= " ,Pass_Cos,Pass_Fun,Pass_Flash,Pass_RF,Failure_Reason,MCE_Failure_Reason,Kit_Complete" & Environment.NewLine
                strSql &= " ,IF(POP_Date IS NULL,'', IF(DATE_FORMAT(POP_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POP_Date,'%Y-%m-%d'))) AS 'POP_Date'" & Environment.NewLine
                strSql &= " ,IF(POR_Date IS NULL,'', IF(DATE_FORMAT(POR_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(POR_Date,'%Y-%m-%d'))) AS 'POR_Date',Activation_Date,OEM_RA,IMM_Order,IMM_Shipped_SKU" & Environment.NewLine
                strSql &= " ,IF(IMM_Shipped_Date IS NULL,'', IF(DATE_FORMAT(IMM_Shipped_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(IMM_Shipped_Date,'%Y-%m-%d'))) AS 'IMM_Shipped_Date',Cust2PSSI_TrackNo,In_Pallet_ID,In_Carton_ID" & Environment.NewLine
                strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',ShipTo_Name AS 'DOA_Account', A.Account AS 'DOA_Account_Code',  SourceFile,A.WO_ID,A.Cust_ID,A.Loc_ID,B.WO_Closed" & Environment.NewLine
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND A.Loc_ID= " & iLoc_ID & " AND A.Device_ID=0 AND B.WO_Closed=0 AND SerialNo = '" & strSN & "';"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function getSeedStockReceivingData(ByVal iCust_ID As Integer, ByVal strSN As String, ByVal strSeedSourceType As String) As DataTable
            Dim strSql As String = ""

            Try
                strSN = strSN.Replace("'", "''") : strSeedSourceType = strSeedSourceType.Replace("'", "''")

                strSql = "SELECT EW_ID,C.Cust_Name1 AS 'Customer',SerialNo AS 'SN',In_Carton_ID,ClaimNo AS 'RMA_No',ClaimNo AS 'PO',Item_SKU,A.Account AS  'SeedStock_Type'" & Environment.NewLine
                strSql &= "  , IF(LoadedDateTime IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(LoadedDateTime,'%Y-%m-%d'))) AS 'RMA_Date'" & Environment.NewLine
                strSql &= "  ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation', A.Account AS 'DOA_Account_Code',  SourceFile,A.WO_ID,A.Cust_ID,A.Loc_ID,B.WO_Closed" & Environment.NewLine
                strSql &= "  FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= "  INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= "  INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= "  WHERE A.Cust_ID= " & iCust_ID & " AND A.Loc_ID= 0 AND A.BulkOrderType_ID=0 AND A.Device_ID=0 AND B.WO_Closed=0 AND A.ACCOUNT='" & strSeedSourceType & "' AND SerialNo = '" & strSN & "';"


                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function


        Public Function ReceiveDataIntoSystem(ByVal iLoc_ID As Integer, ByVal iWO_ID As Integer, ByVal iModel_ID As Integer, ByVal strSN As String, _
                                              ByVal strManufDateCode As String, ByVal strDateTime As String, ByVal strWorkDate As String, _
                                              ByVal iEW_ID As Integer, ByVal iShift_ID As Integer, ByVal iTray_ID As Integer, _
                                              ByRef iDevice_ID As Integer, ByVal iWb_ID As Integer, ByVal iWrty As Integer, ByVal bIsSeedStock As Boolean, Optional ByVal strInPallet As String = "WIKOSP000") As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False
            Dim strReceivedWorkStation = PSS.Data.Buisness.WIKO.WIKO.WIKO_Received_WorkStation
            Dim i As Integer = 0

            Try
                strSN = strSN.Replace("'", "''") : strManufDateCode = strManufDateCode.Replace("'", "''") : iDevice_ID = 0

                strSql = "INSERT INTO production.tDevice (Device_SN,Device_DateRec,Device_Qty,Device_Cnt,Device_RecWorkDate,Loc_ID,WO_ID,Model_ID,Shift_ID_Rec,Tray_ID,Device_ManufWrty)" & _
                         " VALUES ('" & strSN & "','" & strDateTime & "',1,1,'" & strWorkDate & "'," & iLoc_ID & "," & iWO_ID & "," & iModel_ID & "," & iShift_ID & "," & iTray_ID & "," & iWrty & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "SELECT LAST_INSERT_ID();" 'get primary key after Insert
                iDevice_ID = Me._objDataProc.GetIntValue(strSql)
                'strSql = "SELECT Device_ID FROM production.tdevice  WHERE Loc_ID = " & iLoc_ID & " AND Device_DateShip IS NULL AND  Device_SN='" & strSN & _
                '         "' AND Device_DateRec='" & strDateTime & "';"
                'dt = Me._objDataProc.GetDataTable(strSql)
                'If dt.Rows.Count > 0 Then iDevice_ID = Convert.ToInt32(dt.Rows(0).Item("Device_ID"))

                If i > 0 AndAlso iDevice_ID > 0 Then
                    strSql = "INSERT INTO production.tCellOpt (Device_ID,CellOpt_DateCode, WorkStation, WorkStationEntryDt,CellOpt_IMEI)" & _
                             " VALUES (" & iDevice_ID & ",'" & strManufDateCode & "','" & strReceivedWorkStation & "','" & strDateTime & "','" & strSN & "');"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE production.tWorkOrder SET WO_Closed =1, WO_RAQnty =1, Group_ID = " & PSS.Data.Buisness.WIKO.WIKO.WIKO_Group_ID & " WHERE WO_ID = " & iWO_ID & ";"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    If bIsSeedStock Then 'need to update loc_ID
                        strSql = "UPDATE production.extendedwarranty SET Device_ID=" & iDevice_ID & ",wb_id=" & iWb_ID & ",Loc_ID=" & iLoc_ID & " WHERE EW_ID=" & iEW_ID & ";"
                        i += Me._objDataProc.ExecuteNonQuery(strSql)
                    ElseIf iLoc_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID Then

                        strSql = "UPDATE production.extendedwarranty SET Device_ID=" & iDevice_ID & ",wb_id=" & iWb_ID & ",in_pallet_id='" & strInPallet & "' WHERE EW_ID=" & iEW_ID & ";"
                        i += Me._objDataProc.ExecuteNonQuery(strSql)
                    Else
                        strSql = "UPDATE production.extendedwarranty SET Device_ID=" & iDevice_ID & ",wb_id=" & iWb_ID & " WHERE EW_ID=" & iEW_ID & ";"
                        i += Me._objDataProc.ExecuteNonQuery(strSql)
                    End If


                    bRet = True
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getTCellOptWorkstation(ByVal iDevice_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try

                strSql = "SELECT * FROM production.tCellOpt WHERE Device_ID = " & iDevice_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strRet = Convert.ToString(dt.Rows(0).Item("Workstation")).Trim.ToUpper
                End If

                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getTayID(ByVal iUser_ID As Integer, ByVal strUser As String, ByVal iWO_ID As Integer, ByVal strMemo As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strUser = strUser.Replace("'", "''") : strMemo = strMemo.Replace("'", "''")

                strSql = "INSERT INTO production.tTray (Tray_RecUserID, Tray_RecUser, WO_ID, Tray_Memo) VALUES (" & iUser_ID & ",'" & strUser & "'," & iWO_ID & ",'" & strMemo & "');"

                iRet = Me._objDataProc.ExecuteScalarForInsert(strSql, "production.tTray")

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWiKoModels(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Distinct A.Model_ID,A.Model_Desc FROM production.tmodel A" & Environment.NewLine
                strSql &= " INNER JOIN production.Extendedwarranty B ON A.Model_DESC=B.Item_SKU" & Environment.NewLine
                strSql &= " WHERE B.Cust_ID=2624 ORDER BY A.Model_Desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWiKoCriketDOA(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'strSql = "SELECT 1 AS 'DOA_ID','Emblem Solutions DOA' AS 'AccountDOA', '569969' AS 'AccountDOA_Code'" & Environment.NewLine
                'strSql &= " UNION ALL SELECT 2 AS 'DOA_ID','Emblem Solutions' AS 'AccountDOA', '569955' AS 'AccountDOA_Code';" & Environment.NewLine

                strSql = "SELECT 1 AS 'DOA_ID','" & PSS.Data.Buisness.WIKO.WIKO.WIKO_Cricket_OEMCustomer_DOA & "' AS 'AccountDOA', '" & PSS.Data.Buisness.WIKO.WIKO.WIKO_Cricket_OEMCustomer_DOA_AccountCode & "' AS 'AccountDOA_Code'" & Environment.NewLine
                strSql &= " UNION ALL SELECT 2 AS 'DOA_ID','" & PSS.Data.Buisness.WIKO.WIKO.WIKO_Cricket_OEMCustomer_EMS & "' AS 'AccountDOA', '" & PSS.Data.Buisness.WIKO.WIKO.WIKO_Cricket_OEMCustomer_EMS_AccountCode & "' AS 'AccountDOA_Code';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {0, "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SaveWiKoSeedStockData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strSN As String, _
                                              ByVal strManufDateCode As String, ByVal strModel As String, ByVal iModel_ID As Integer, _
                                              ByVal strAccountDOA As String, ByVal strAccountDOA_Code As String, ByVal strDateTime As String, _
                                              ByVal strWorkDate As String, ByVal iUser_ID As Integer, ByVal strUser As String, _
                                              ByVal iShift_ID As Integer, ByVal strTrayMemo As String) As String
            Dim strSQL As String
            Dim dt As New DataTable()
            Dim iWO_ID As Integer = 0
            Dim iEW_ID As Integer = 0
            Dim iTray_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim i As Integer = 0

            Dim strErrMsg As String = ""
            Dim strErrMsg2 As String = ""
            Dim strWO_Name As String = "WiKo_C" & iCust_ID.ToString & "L" & iLoc_ID.ToString
            Dim strClaimNo As String = PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStock & strDateTime.Replace("-", "").Replace(":", "").Replace("/", "").Replace(" ", "")
            Dim strReceivedWorkStation = PSS.Data.Buisness.WIKO.WIKO.WIKO_Received_WorkStation

            Try
                'Check if SN exit but not received
                strSN = strSN.Replace("'", "''") : strManufDateCode = strManufDateCode.Replace("'", "''")
                'strSQL = "SELECT * FROM production.extendedwarranty WHERE Invalid =0 AND WO_ID >0 and Device_ID >0 AND SerialNo ='" & strSN & "'; "
                'dt = Me._objDataProc.GetDataTable(strSQL)

                strSQL = "SELECT A.* FROM production.extendedwarranty A" & Environment.NewLine
                strSQL &= " INNER JOIN production.tdevice B ON A.Device_ID =B.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN production.tCellopt C ON B.Device_ID=C.Device_ID" & Environment.NewLine
                strSQL &= " WHERE A.Cust_ID=" & iCust_ID & " And A.Invalid =0 AND A.WO_ID >0 and A.Device_ID >0" & Environment.NewLine
                strSQL &= " AND NOT C.Workstation= '" & PSS.Data.Buisness.WIKO.WIKO.WIKO_BuildProduce_WorkStation & "' AND A.SerialNo ='" & strSN & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    strErrMsg = "SN '" & strSN & "' is open and failed to save." & Environment.NewLine
                Else
                    'Save data to extendedwarranty
                    If iLoc_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID Then
                        strSQL = "INSERT INTO production.extendedwarranty (Cust_ID,Loc_ID,ClaimNo,Date,ShipTo_Name,Account,SerialNo,LoadedDateTime,Item_Sku,SourceFile)"
                        strSQL &= " VALUES (" & iCust_ID & "," & iLoc_ID & ",'" & strClaimNo & "','" & strDateTime & "','" & strAccountDOA & "','" & strAccountDOA_Code
                        strSQL &= "','" & strSN & "','" & strDateTime & "','" & strModel & "','" & PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStock & "');"
                    Else
                        strSQL = "INSERT INTO production.extendedwarranty (Cust_ID,Loc_ID,ClaimNo,Date,SerialNo,LoadedDateTime,Item_Sku,SourceFile)"
                        strSQL &= " VALUES (" & iCust_ID & "," & iLoc_ID & ",'" & strClaimNo & "','" & strDateTime
                        strSQL &= "','" & strSN & "','" & strDateTime & "','" & strModel & "','" & PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStock & "');"
                    End If

                    'iEW_ID = Me._objDataProc.idTransaction(strSQL, "extendedwarranty")
                    iEW_ID = Me._objDataProc.ExecuteScalarForInsert(strSQL, "production.extendedwarranty")

                    'Save tWorkOrder and update extendedwarranty.wo_ID
                    If iEW_ID > 0 Then
                        strWO_Name &= "EW" & iEW_ID.ToString

                        strSQL = "INSERT INTO production.tWorkOrder (WO_CustWO,WO_Date,WO_Quantity,Loc_ID,WO_Closed,Prod_ID) VALUES (" & _
                                 "'" & strWO_Name & "','" & strDateTime & "',1," & iLoc_ID & ",0,2);"
                        'iWO_ID = Me._objDataProc.idTransaction(strSQL, "tWorkOrder")
                        iWO_ID = Me._objDataProc.ExecuteScalarForInsert(strSQL, "production.tWorkOrder")
                        If iWO_ID > 0 Then
                            strSQL = "UPDATE production.extendedwarranty SET WO_ID = " & iWO_ID & " WHERE EW_ID=" & iEW_ID
                            Me._objDataProc.ExecuteNonQuery(strSQL)
                        Else
                            strErrMsg &= "Invalid WO_ID. " & Environment.NewLine
                        End If
                    Else
                        strErrMsg &= "Invalid EW_ID. " & Environment.NewLine
                    End If

                    'Receiving
                    strSQL = "INSERT INTO production.tTray (Tray_RecUserID, Tray_RecUser, WO_ID, Tray_Memo) VALUES (" & iUser_ID & ",'" & strUser & "'," & iWO_ID & ",'" & strTrayMemo & "');"
                    iTray_ID = Me._objDataProc.ExecuteScalarForInsert(strSQL, "production.tTray")
                    If iTray_ID > 0 Then
                        strSQL = "INSERT INTO production.tDevice (Device_SN,Device_DateRec,Device_Qty,Device_Cnt,Device_RecWorkDate,Loc_ID,WO_ID,Model_ID,Shift_ID_Rec,Tray_ID)" & _
                                               " VALUES ('" & strSN & "','" & strDateTime & "',1,1,'" & strWorkDate & "'," & iLoc_ID & "," & iWO_ID & "," & iModel_ID & "," & iShift_ID & "," & iTray_ID & ");"
                        iDevice_ID = Me._objDataProc.ExecuteScalarForInsert(strSQL, "production.tdevice")
                        If iDevice_ID > 0 Then
                            strSQL = "INSERT INTO production.tCellOpt (Device_ID,CellOpt_DateCode, WorkStation, WorkStationEntryDt,CellOpt_IMEI)" & _
                                     " VALUES (" & iDevice_ID & ",'" & strManufDateCode & "','" & strReceivedWorkStation & "','" & strDateTime & "','" & strSN & "');"
                            i += Me._objDataProc.ExecuteNonQuery(strSQL)

                            strSQL = "UPDATE production.tWorkOrder SET WO_Closed =1, WO_RAQnty =1, Group_ID = " & PSS.Data.Buisness.WIKO.WIKO.WIKO_Group_ID & " WHERE WO_ID = " & iWO_ID & ";"
                            i += Me._objDataProc.ExecuteNonQuery(strSQL)

                            strSQL = "UPDATE production.extendedwarranty SET Device_ID=" & iDevice_ID & " WHERE EW_ID=" & iEW_ID & ";"
                            i += Me._objDataProc.ExecuteNonQuery(strSQL)
                        Else
                            strErrMsg &= "Invalid Device_ID. " & Environment.NewLine
                        End If
                    Else
                        strErrMsg &= "Invalid Tray_ID. " & Environment.NewLine
                    End If

                End If

                Return strErrMsg

            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
            End Try

        End Function

        Public Function ColseWarehouseBox(ByVal iwb_id As Integer, ByVal iBoxRevcQty As Integer, ByVal strBoxStage As String) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strBoxStage = strBoxStage.Trim.Replace("'", "''")

                strSql = "UPDATE edi.twarehousebox SET Closed=1,Recv_Qty= " & iBoxRevcQty & ",BoxStage='" & strBoxStage & "' WHERE wb_id=" & iwb_id & ";"
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PrintReceivedBoxLabel(ByVal strBoxName As String, ByVal iQty As Integer, ByVal strSku As String, ByVal strSku_Desc As String, _
                                             ByVal strPSSModel_Desc As String, ByVal strPlantID As String, ByVal strReturnType As String, _
                                             ByVal strPoNumber As String, ByVal strWHLocation As String, _
                                             ByVal strCustomer As String, ByVal strLocation As String) As Integer

            Dim strReportName As String = "WiKo Warehouse Receiving Box Label.rpt" 'for all Wiko: Cricket, ATT CTDI, ATT Fedex
            Dim strSql As String
            Dim dtLabel As DataTable
            'Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try

                strBoxName = ReplaceChar(strBoxName) : strSku = ReplaceChar(strSku) : strPSSModel_Desc = ReplaceChar(strPSSModel_Desc)
                strPlantID = ReplaceChar(strPlantID) : strReturnType = ReplaceChar(strReturnType) : strPoNumber = ReplaceChar(strPoNumber)
                If strWHLocation.Trim.Length > 0 Then strWHLocation = "WH Location: " & ReplaceChar(strWHLocation)
                strSku_Desc = ReplaceChar(strSku_Desc) : strCustomer = ReplaceChar(strCustomer) : strLocation = ReplaceChar(strLocation)

                'BoxName, Qty, Sku, ModelDesc, PLantID, Type, PoNumber, WHLocation, Other1, Customer, ASN_Type
                strSql = "SELECT '" & strBoxName & "' AS 'BoxName'," & iQty & " AS 'Qty','" & strSku & "' AS 'Sku', '" & strPSSModel_Desc & "' AS 'ModelDesc'" & Environment.NewLine
                strSql &= ", '" & strPlantID & "' AS 'PLantID','" & strReturnType & "' AS 'Type','" & strPoNumber & "' AS 'PoNumber','" & strWHLocation & "' AS 'WHLocation'" & Environment.NewLine
                strSql &= ",'" & strLocation & "' AS 'Other1','" & strCustomer & "' AS 'Customer','" & strSku_Desc & "' AS 'Other2';"

                dtLabel = Me._objDataProc.GetDataTable(strSql)

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

        Public Function PrintReceivedSeedstockBoxLabel(ByVal strBoxName As String, ByVal iQty As Integer, ByVal strSku As String, ByVal strSku_Desc As String, _
                                                       ByVal strPSSModel_Desc As String, ByVal strPlantID As String, ByVal strSeedSourceType As String, _
                                                       ByVal strPoNumber As String, ByVal strWHLocation As String, _
                                                       ByVal strCustomer As String, ByVal strOther1 As String) As Integer

            Dim strReportName As String = "WiKo Warehouse Seedstock Receiving Box Label.rpt" 'for all Wiko SeedStock: Cricket, ATT CTDI, ATT Fedex
            Dim strSql As String
            Dim dtLabel As DataTable
            'Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try

                strBoxName = ReplaceChar(strBoxName) : strSku = ReplaceChar(strSku) : strPSSModel_Desc = ReplaceChar(strPSSModel_Desc)
                strPlantID = ReplaceChar(strPlantID) : strSeedSourceType = ReplaceChar(strSeedSourceType) : strPoNumber = ReplaceChar(strPoNumber)
                If strWHLocation.Trim.Length > 0 Then strWHLocation = "WH Location: " & ReplaceChar(strWHLocation)
                strSku_Desc = ReplaceChar(strSku_Desc) : strCustomer = ReplaceChar(strCustomer) : strOther1 = ReplaceChar(strOther1)

                'BoxName, Qty, Sku, ModelDesc, PLantID, Type, PoNumber, WHLocation, Other1, Customer, ASN_Type
                strSql = "SELECT '" & strBoxName & "' AS 'BoxName'," & iQty & " AS 'Qty','" & strSku & "' AS 'Sku', '" & strPSSModel_Desc & "' AS 'ModelDesc'" & Environment.NewLine
                strSql &= ", '" & strPlantID & "' AS 'PLantID','" & strSeedSourceType & "' AS 'Type','" & strPoNumber & "' AS 'PoNumber','" & strWHLocation & "' AS 'WHLocation'" & Environment.NewLine
                strSql &= ",'" & strOther1 & "' AS 'Other1','" & strCustomer & "' AS 'Customer','" & strSku_Desc & "' AS 'Other2';"

                dtLabel = Me._objDataProc.GetDataTable(strSql)

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


        Public Function GetWiKoReceivedData(ByVal iCust_ID As Integer, ByVal strInput As String, ByVal iBox1SN2PO3 As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iLoc_IDs As String = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID & "," & PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID & _
                                     "," & PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID

            Try
                strInput = ReplaceChar(strInput)
                strSql = "Select EW_ID,CONCAT_WS(' ',D.Cust_Name1,E.Loc_Name) AS 'Customer',A.wb_ID,A.BoxID AS 'BoxName',A.Closed,A.Model_ID,A.WarrantyFlag,IF(B.Loc_ID=4484,B.ShipTo_Name, if(B.Loc_ID=4483,'WEX',B.Account)) AS 'Return_Type',B.Account AS 'ReturnType_Code'" & Environment.NewLine
                strSql &= " , A.Recv_Qty,C.Model_Desc AS 'PSS_Model',B.item_Sku AS 'ASN_SKU',B.Item_Desc AS 'ASN_SKU_Desc',B.ClaimNo AS 'PO'" & Environment.NewLine
                strSql &= " ,B.SerialNo AS 'SN',B.Device_ID,A.WHLocation,B.Cust_ID,B.Loc_ID,F.Device_DateRec" & Environment.NewLine
                strSql &= " From edi.twarehousebox A" & Environment.NewLine
                strSql &= " Inner Join production.extendedwarranty  B ON A.wb_ID=B.wb_ID" & Environment.NewLine
                strSql &= " Inner Join production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " Inner Join production.tCustomer D ON B.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join production.tLocation E ON B.Loc_ID=E.Loc_ID" & Environment.NewLine
                strSql &= " Inner Join production.tDevice F ON B.Device_ID=F.Device_ID" & Environment.NewLine
                strSql &= " Where B.Cust_ID= " & iCust_ID & " And B.Loc_ID IN (" & iLoc_IDs & ") And A.Closed=1"

                Select Case iBox1SN2PO3
                    Case 1
                        strSql &= " And  A.BoxID ='" & strInput & "'; " & Environment.NewLine
                    Case 2
                        strSql &= " And  B.SerialNo='" & strInput & "'; " & Environment.NewLine
                    Case 3
                        strSql &= " And  B.ClaimNo ='" & strInput & "'; " & Environment.NewLine
                    Case Else
                        strSql = "Select * From edi.twarehousebox Limit 0;" ' not correct, so return 0 row datatable
                End Select

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWiKoReceivedSeedstockData(ByVal iCust_ID As Integer, ByVal strInput As String, ByVal iBox1SN2PO3 As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iLoc_IDs As String = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCricket_LOC_ID & "," & PSS.Data.Buisness.WIKO.WIKO.WIKO_AttCTDI_LOC_ID & _
                                     "," & PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
            Dim strSeedSourceTypes As String = "'" & PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStockSourceType_ATT & "','" & PSS.Data.Buisness.WIKO.WIKO.WIKO_SeedStockSourceType_Cricket & "'"

            Try
                strInput = ReplaceChar(strInput)
                strSql = "Select EW_ID,CONCAT_WS(' ',D.Cust_Name1,E.Loc_Name) AS 'Customer',A.wb_ID,A.BoxID AS 'BoxName',A.Closed,A.Model_ID,A.WarrantyFlag" & Environment.NewLine
                strSql &= " ,B.Account AS 'SeedSourceType', A.Recv_Qty,C.Model_Desc AS 'PSS_Model',B.item_Sku AS 'ASN_SKU',B.ClaimNo AS 'PO'" & Environment.NewLine
                strSql &= "  ,B.SerialNo AS 'SN',B.Device_ID,A.WHLocation,B.Cust_ID,F.Loc_ID,F.Device_DateRec" & Environment.NewLine
                strSql &= " From edi.twarehousebox A" & Environment.NewLine
                strSql &= " Inner Join production.extendedwarranty  B ON A.wb_ID=B.wb_ID" & Environment.NewLine
                strSql &= " Inner Join production.tDevice F ON B.Device_ID=F.Device_ID" & Environment.NewLine
                strSql &= " Inner Join production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " Inner Join production.tCustomer D ON B.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join production.tLocation E ON F.Loc_ID=E.Loc_ID" & Environment.NewLine
                strSql &= " Where B.Cust_ID= " & iCust_ID & " And F.Loc_ID IN (" & iLoc_IDs & ") And A.Closed=1" & Environment.NewLine
                strSql &= " And B.Loc_ID= 0 AND B.BulkOrderType_ID=0 AND B.ACCOUNT IN (" & strSeedSourceTypes & ")" & Environment.NewLine

                Select Case iBox1SN2PO3
                    Case 1
                        strSql &= " And  A.BoxID ='" & strInput & "'; " & Environment.NewLine
                    Case 2
                        strSql &= " And  B.SerialNo='" & strInput & "'; " & Environment.NewLine
                    Case 3
                        strSql &= " And  B.ClaimNo ='" & strInput & "'; " & Environment.NewLine
                    Case Else
                        strSql = "Select * From edi.twarehousebox Limit 0;" ' not correct, so return 0 row datatable
                End Select

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub FindUpdateAttFexExSkuPos()
            'ATT FedEx ASN only have Item Desc for the SKU, so need to find and update based on Table tmodel
            Dim objWiKo As New PSS.Data.Buisness.WIKO.WIKO()
            Dim iCust_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID
            Dim iLoc_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_AttFedEx_LOC_ID
            Dim strItemDescAccount As String = PSS.Data.Buisness.WIKO.WIKO.WIKO_FexEx_PosCode
            Dim iEW_ID As Integer = 0, i As Integer = 0
            Dim strItemDesc As String = ""
            Dim strSku As String = ""
            Dim dtModel, dtASN As DataTable
            Dim row As DataRow
            Dim foundRow() As DataRow

            Dim strSql As String = ""

            Try
                'model_ID, model_Desc, Model_MotoSku, ASN_IN_SKU, ASN_IN_SKU_Desc, Model_LDesc, ShippedModel, ShippedModel_Desc, Cust_IDs, 
                'Model_Tier, Model_Flat, Manuf_ID, Prod_ID, ProdGrp_ID, ASCPrice_ID, RptGrp_ID
                dtModel = objWiKo.getWIKOModels(WIKO.WIKO_CUSTOMER_ID, False)

                strSql = "SELECT EW_ID,Item_Sku,Item_Desc, extendedwarranty.Account,SerialNo,cust_ID,Loc_ID,Device_ID FROM production.extendedwarranty WHERE Device_ID=0 AND Cust_ID=" & iCust_ID & " AND Loc_ID=" & iLoc_ID & " AND extendedwarranty.Account='" & strItemDescAccount.Trim & "';"
                dtASN = Me._objDataProc.GetDataTable(strSql)

                For Each row In dtASN.Rows
                    If (row.IsNull("Item_Sku") OrElse Convert.ToString(row("Item_Sku")).Trim.Length = 0) _
                        AndAlso Not row.IsNull("Item_Desc") AndAlso Convert.ToString(row("Item_Desc")).Trim.Length > 0 Then
                        strItemDesc = Convert.ToString(row("Item_Desc")).Trim
                        iEW_ID = Convert.ToInt32(row("EW_ID"))
                        foundRow = dtModel.Select("ASN_IN_SKU_Desc='" & strItemDesc & "'")
                        If foundRow.Length > 0 Then 'it should be if found
                            strSku = Convert.ToString(foundRow(0).Item("model_Desc")).Trim
                            strSql = "UPDATE production.extendedwarranty SET Item_SKU='" & strSku & "' WHERE EW_ID=" & iEW_ID
                            i = Me._objDataProc.ExecuteNonQuery(strSql)
                        End If
                    End If
                Next

            Catch ex As Exception

            End Try

        End Sub

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
