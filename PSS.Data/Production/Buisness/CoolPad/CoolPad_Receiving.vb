Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.CP
    Public Class CoolPad_Receiving
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

        Public Function GetRecvTableDef() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT  0 AS 'RecID','' AS 'SN','' AS 'SKU','' AS 'PSS_Model','' AS 'PlantID','' AS 'RepairProgramType','FaultCodeDefinition','' AS 'PO_Number' , '' AS 'Customer','' AS 'Loc',0 AS 'wb_id'"
                strSql &= "Limit 0;"

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetSeedStockRecvTableDef() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT  0 AS 'RecID','' AS 'SN','' AS 'SKU','' AS 'PSS_Model','' AS 'Customer','' AS 'Loc',0 AS 'wb_id'"
                strSql &= "Limit 0;"

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetEndUserRecvTableDef() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT  0 AS 'RecID','' AS 'SN','' AS 'SKU','' AS 'PSS_Model','' AS 'End_User','' as 'Address','' AS 'Customer','' AS 'Loc','' AS 'Wrty',0 AS 'WrtyFlag',0 AS 'Model_ID',0 AS 'wb_id'"
                strSql &= "Limit 0;"

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function GetCoolPadLocations(ByVal iCust_ID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
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

        Public Function getModelData(ByVal iProd_ID As Integer, ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable


            Try
                strSql = "SELECT Distinct A.Model_ID,A.ASN_IN_SKU,A.Model_Desc,A.Model_MotoSku" & Environment.NewLine
                strSql &= " FROM production.tmodel A" & Environment.NewLine
                strSql &= " INNER JOIN production.extendedwarranty B ON A.ASN_IN_SKU =B.Item_SKu" & Environment.NewLine
                strSql &= " WHERE  A.Prod_ID= " & iProd_ID & " AND B.Cust_ID= " & iCust_ID & " AND B.Loc_ID= " & iLoc_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {0, "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getReceivingData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iOrderType_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "SELECT A.EW_ID,C.Cust_Name1 AS 'Customer', D.Loc_Name AS 'Loc', A.Project_ID AS 'ASN_ID',A.Item_SKU,A.SerialNo AS 'SN',A.SerialNo2,A.Model AS 'ASN_Model',A.OEM_RA,A.Rep_ID AS 'Delivery'" & Environment.NewLine
                strSql &= " ,A.ClaimNo AS 'PoNumber',A.ClaimLineNo As 'PoLineNumber',IF(A.FirstUseDate  IS NULL,'', IF(DATE_FORMAT(A.FirstUseDate,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(A.FirstUseDate ,'%Y-%m-%d')))  AS 'FirstUseDate'" & Environment.NewLine
                strSql &= " ,IF(A.LastUseDate  IS NULL,'', IF(DATE_FORMAT(A.LastUseDate,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(A.LastUseDate ,'%Y-%m-%d')))  AS 'LastDate',A.Reason AS 'Customer Complaint'" & Environment.NewLine
                strSql &= " ,A.Item_Desc,A.Channel,A.In_Pallet_ID,A.In_Carton_ID,A.Account AS 'VendorID',A.Retailer AS 'PlantID',A.ShipTo_Name2 'ShipToID',A.Retailer2 AS 'ReturnPlantID'" & Environment.NewLine
                strSql &= " ,IF(A.IMM_Shipped_Date IS NULL,'',IF(DATE_FORMAT(A.IMM_Shipped_Date,'%Y-%m-%d') ='0000-00-00','',DATE_FORMAT(A.IMM_Shipped_Date ,'%Y-%m-%d')))  AS 'ShipDate'" & Environment.NewLine
                strSql &= " ,A.Cust2PSSI_Carrier,A.Cust2PSSI_TrackNo,A.Cust2PSSI_BillofLading,A.ShipTo_Name AS 'ShipToName',A.Address1 AS 'ShipToAddress1',A.Address2 AS 'ShipAddress2'" & Environment.NewLine
                strSql &= " ,A.City AS 'ShipCity',A.State_Name AS 'ShipState',A.ZipCode AS 'ShiPZip',A.ReturnToName,A.ReturnAddress1,A.ReturnAddress2,A.ReturnCity,A.ReturnState" & Environment.NewLine
                strSql &= " ,A.ReturnZip,A.ReturnPhone,A.ReturnPhoneExt,A.BillToName,A.BillToAttn,A.Warranty_Desc AS 'RepairProgramType',A.Failure_Code AS 'FaultCode',A.Failure_Reason AS 'FaultCodeDefinition'" & Environment.NewLine
                strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile,A.WO_ID,A.Cust_ID,A.Loc_ID,B.WO_Closed" & Environment.NewLine
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " and A.Loc_ID=" & iLoc_ID & " AND A.BulkOrderType_ID=" & iOrderType_ID & " AND B.WO_Closed=0 AND A.SerialNo='" & strSN & "';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function getSeedStockReceivingData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal iOrderType_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "SELECT A.EW_ID,C.Cust_Name1 AS 'Customer', D.Loc_Name AS 'Loc',A.Item_SKU,A.In_Carton_ID,A.SerialNo AS'SN',A.HD_SerialNo AS 'HD_SN',A.R_SerialNo AS 'RSN',A.MEID_HEX,A.MEID_DEC,A.ICC_ID,A.MSL,A.OTKSL,A.Model_MotoSku,A.Version" & Environment.NewLine
                strSql &= " ,A.LoadedDatetime,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile,A.WO_ID,A.Cust_ID,A.Loc_ID,B.WO_Closed" & Environment.NewLine
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " and A.Loc_ID=" & iLoc_ID & " AND A.BulkOrderType_ID=" & iOrderType_ID & " AND B.WO_Closed=0 AND A.SerialNo='" & strSN & "';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function getEndUserReceivingData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, _
                                                ByVal iOrderType_ID As Integer, ByVal strSN As String, _
                                                ByVal iIsSN1OrRMANo2 As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSN = strSN.Replace("'", "''")
                strSql = "SELECT A.EW_ID,C.Cust_Name1 AS 'Customer', D.Loc_Name AS 'Loc',A.Item_SKU,A.SerialNo AS 'SN',A.SerialNo2,A.Model AS 'ASN_Model',A.Account as 'Aging TAT',A.Warranty_Desc" & Environment.NewLine
                strSql &= " ,A.Date_Text AS  'Reported_Date_Text',A.Type AS  'Contact_Origin',A.ClaimNo AS 'RMA_Number',A.ClaimLineNo As 'RMA_LineNumber',A.MSL AS 'ASN_IN_Status',A.Cust2PSSI_Carrier,A.Version AS 'SW Version'" & Environment.NewLine
                strSql &= " ,A.POP_Date_Text AS 'POP_Date_Text',A.Return_Reason, A.Reason AS 'Sub-Reason',A.Note AS 'Detailed_Desc',A.returnToName AS 'Customer_Name',A.ReturnPhone AS 'Promary_Contact_Phone'" & Environment.NewLine
                strSql &= " ,A.ReturnPhoneExt AS 'Secondary_Contact_Phone',A.Email,A.ReturnAddress1 AS 'Full_Address',A.IMM_Shipped_Date_Text AS 'RMA_Ship_Date_Text',A.Channel AS 'FWD_Carrier'" & Environment.NewLine
                strSql &= " ,A.Cust2PSSI_TrackNo,A.Requester AS 'Return_Loc',A.POR_Date_Text AS  'POD_Date_Text',E.Model_ID,E.ASN_IN_SKU,E.Model_Desc,E.Model_MotoSku" & Environment.NewLine
                strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(B.WO_Closed>0,'CLOSED','RECEIVING') AS 'WorkStation',  SourceFile,A.WO_ID,A.Cust_ID,A.Loc_ID,B.WO_Closed" & Environment.NewLine
                strSql &= " FROM production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.tModel E ON A.Item_SKu =E.ASN_IN_SKU" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " and A.Loc_ID=" & iLoc_ID & " AND A.BulkORderType_ID=" & iOrderType_ID & " AND B.WO_Closed=0 AND A.Device_ID=0" & Environment.NewLine

                If iIsSN1OrRMANo2 = 1 Then
                    strSql &= " AND A.SerialNo='" & strSN & "';" & Environment.NewLine
                ElseIf iIsSN1OrRMANo2 = 2 Then
                    strSql &= " AND A.ClaimNo='" & strSN & "';" & Environment.NewLine
                Else
                    strSql = "Select * From production.extendedwarranty Limit 0;" ' not correct, so return 0 row datatable
                End If

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex

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

        Public Function ReceiveDataIntoSystem(ByVal iLoc_ID As Integer, ByVal iWO_ID As Integer, ByVal iModel_ID As Integer, ByVal strSN As String, _
                                              ByVal strManufDateCode As String, ByVal strDateTime As String, ByVal strWorkDate As String, _
                                              ByVal iEW_ID As Integer, ByVal iShift_ID As Integer, ByVal iTray_ID As Integer, ByVal iWB_ID As Integer, ByVal iWrtyFlag As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False
            Dim strReceivedWorkStation = PSS.Data.Buisness.CP.CoolPad.CoolPad_Received_WorkStation
            Dim iDevice_ID As Integer = 0
            Dim i As Integer = 0

            Try
                strSN = strSN.Replace("'", "''") : strManufDateCode = strManufDateCode.Replace("'", "''")

                strSql = "INSERT INTO production.tDevice (Device_SN,Device_DateRec,Device_Qty,Device_Cnt,Device_RecWorkDate,Loc_ID,WO_ID,Model_ID,Shift_ID_Rec,Tray_ID,Device_ManufWrty)" & _
                         " VALUES ('" & strSN & "','" & strDateTime & "',1,1,'" & strWorkDate & "'," & iLoc_ID & "," & iWO_ID & "," & iModel_ID & "," & iShift_ID & "," & iTray_ID & "," & iWrtyFlag & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                'strSql = "SELECT Device_ID FROM production.tdevice  WHERE Loc_ID = " & iLoc_ID & " AND Device_DateShip IS NULL AND  Device_SN='" & strSN & _
                '         "' AND Device_DateRec='" & strDateTime & "';"
                'dt = Me._objDataProc.GetDataTable(strSql)
                'If dt.Rows.Count > 0 Then iDevice_ID = Convert.ToInt32(dt.Rows(0).Item("Device_ID"))

                'Device_ID = Me._objDataProc.idTransaction(strSql, "tDevice") 'very slow, give up this way

                strSql = "SELECT LAST_INSERT_ID();" 'get primary key after Insert
                iDevice_ID = Me._objDataProc.GetIntValue(strSql)

                If iDevice_ID > 0 Then
                    strSql = "INSERT INTO production.tCellOpt (Device_ID,CellOpt_DateCode, WorkStation, WorkStationEntryDt,CellOpt_IMEI)" & _
                             " VALUES (" & iDevice_ID & ",'" & strManufDateCode & "','" & strReceivedWorkStation & "','" & strDateTime & "','" & strSN & "');"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE production.tWorkOrder SET WO_Closed =1, WO_RAQnty =1, Group_ID = " & PSS.Data.Buisness.CP.CoolPad.CoolPad_Group_ID & " WHERE WO_ID = " & iWO_ID & ";"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE production.extendedwarranty SET Device_ID=" & iDevice_ID & ",wb_id=" & iWB_ID & " WHERE EW_ID=" & iEW_ID & ";"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    bRet = True
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateWarehouseBoxName(ByVal iModelID As Integer, _
                                               ByVal iWrtyFlag As Integer, _
                                               ByRef iWB_ID As Integer, Optional ByVal strBoxNamePreFix As String = "") As String

            '(ByVal iOrderID As Integer, _
            'ByVal iFuncRep As Integer, _
            'ByVal iWrtyFlag As Integer, _
            'ByVal iModelID As Integer, _
            'ByVal iWrtyExpInLess31Days As Integer
            Dim strSql As String = ""
            Dim strDTime As String = ""
            Dim iNextSeqNo As Integer = 0
            Dim strBoxName As String = ""
            Dim iWHBoxID As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objMisc As New TracFone.clsMisc()

            Try
                strDTime = Format(Now(), "yyyyMMdd")
                If strBoxNamePreFix.Trim.Length > 0 Then
                    strBoxName = strBoxNamePreFix
                Else
                    strBoxName = "CP"
                End If

                strBoxName &= strDTime

                If iWrtyFlag = 1 Then
                    strBoxName &= "IW"
                ElseIf iWrtyFlag = 0 Then
                    strBoxName &= "OW"
                ElseIf iWrtyFlag = 2 Then
                    strBoxName &= "DOA" 'in fact DOA is IW. so it will never happens
                End If

                iNextSeqNo = objMisc.GetWHBoxNexSeqNo(strBoxName, objMisc._iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxName = strBoxName & iNextSeqNo.ToString.PadLeft(objMisc._iWHBoxSegDigitCnt, "0")

                iWHBoxID = objMisc.InsertEdiWarehouseBox(strBoxName, 0, iWrtyFlag, 0, iModelID, 0, 0)
                If Not iWHBoxID > 0 Then Throw New Exception("System has failed to create new box.")

                iWB_ID = iWHBoxID

                Return strBoxName

            Catch ex As Exception
                Throw ex
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

        Public Function PrintReceivedBoxLabel(ByVal iASN_OrderType_ID As Integer, ByVal strBoxName As String, ByVal iQty As Integer, ByVal strSku As String, _
                                              ByVal strPSSModel_Desc As String, ByVal strPlantID As String, ByVal strRepairProgramType As String, _
                                              ByVal strPoNumber As String, ByVal strWHLocation As String, ByVal strOSD As String, _
                                              ByVal strCustomer As String, ByVal strASN_Category As String) As Integer

            Dim strReportName As String = "CoolPad Warehouse Box Label.rpt" 'default
            Dim strSql As String
            Dim dtLabel As DataTable
            'Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                If iASN_OrderType_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_OrderTypeBulk_ID Then
                    strReportName = "CoolPad Warehouse Box Label.rpt"
                ElseIf iASN_OrderType_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_OrderTypeSeedStock_ID Then
                    strReportName = "CoolPad SeedStock Warehouse Box Label.rpt"
                ElseIf iASN_OrderType_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_OrderTypeEndUser_ID Then
                    strReportName = "CoolPad Warehouse EndUser Box Label.rpt"
                End If

                strBoxName = ReplaceChar(strBoxName) : strSku = ReplaceChar(strSku) : strPSSModel_Desc = ReplaceChar(strPSSModel_Desc)
                strPlantID = ReplaceChar(strPlantID) : strRepairProgramType = ReplaceChar(strRepairProgramType) : strPoNumber = ReplaceChar(strPoNumber)
                If strWHLocation.Trim.Length > 0 Then strWHLocation = "WH Location: " & ReplaceChar(strWHLocation)
                strOSD = ReplaceChar(strOSD) : strCustomer = ReplaceChar(strCustomer) : strASN_Category = ReplaceChar(strASN_Category)

                'BoxName, Qty, Sku, ModelDesc, PLantID, Type, PoNumber, WHLocation, Other1, Customer, ASN_Type
                strSql = "SELECT '" & strBoxName & "' AS 'BoxName'," & iQty & " AS 'Qty','" & strSku & "' AS 'Sku', '" & strPSSModel_Desc & "' AS 'ModelDesc'" & Environment.NewLine
                strSql &= ", '" & strPlantID & "' AS 'PLantID','" & strRepairProgramType & "' AS 'Type','" & strPoNumber & "' AS 'PoNumber','" & strWHLocation & "' AS 'WHLocation'" & Environment.NewLine
                strSql &= ",'" & strOSD & "' AS 'Other1','" & strCustomer & "' AS 'Customer','" & strASN_Category & "' AS 'Other2';"

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

        Public Function getReceivedBulkBoxData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strInput As String, ByVal iBox1SN2PO3 As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strInput = strInput.Trim.Replace("'", "''")

                strSql = "Select D.Cust_Name1 AS 'Customer', E.Loc_Name AS 'Loc',A.wb_ID,A.BoxID AS 'BoxName',A.Closed,A.Model_ID,A.WarrantyFlag,B.Warranty_Desc AS 'RepairProgramType',A.Recv_Qty,C.Model_Desc,B.item_Sku,B.ClaimNo AS 'PoNumber'" & Environment.NewLine
                strSql &= " ,B.SerialNo,B.Device_ID,B.Retailer AS 'PlantID',A.WHLocation,'Bulk' AS 'ASN_Category','' AS 'OSD',B.Cust_ID,B.Loc_ID,B.BulkOrderType_ID,F.Device_DateRec" & Environment.NewLine
                strSql &= " From edi.twarehousebox A" & Environment.NewLine
                strSql &= " Inner Join production.extendedwarranty  B ON A.wb_ID=B.wb_ID" & Environment.NewLine
                strSql &= " Inner Join production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " Inner Join production.tCustomer D ON B.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join production.tLocation E ON B.Loc_ID=E.Loc_ID" & Environment.NewLine
                strSql &= " Inner Join production.tDevice F ON B.Device_ID=F.Device_ID" & Environment.NewLine
                strSql &= " Where B.Cust_ID= " & iCust_ID & " and B.Loc_ID= " & iLoc_ID & " AND B.BulkOrderType_ID= 1 And A.Closed=1"
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

        Public Function getReceivedEndUserBoxData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strInput As String, ByVal iBox1SN2 As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strInput = strInput.Trim.Replace("'", "''")

                strSql = "Select D.Cust_Name1 AS 'Customer', E.Loc_Name AS 'Loc',A.wb_ID,A.BoxID AS 'BoxName',A.Closed,A.Model_ID,A.WarrantyFlag,'' AS 'RepairProgramType',A.Recv_Qty,C.Model_Desc,B.item_Sku,B.ClaimNo AS 'PoNumber'" & Environment.NewLine
                strSql &= " ,B.SerialNo,B.Device_ID,'' AS 'PlantID',A.WHLocation,'EndUser' AS 'ASN_Category','' AS 'OSD',B.Cust_ID,B.Loc_ID,B.BulkOrderType_ID,F.Device_DateRec" & Environment.NewLine
                strSql &= " From edi.twarehousebox A" & Environment.NewLine
                strSql &= " Inner Join production.extendedwarranty  B ON A.wb_ID=B.wb_ID" & Environment.NewLine
                strSql &= " Inner Join production.tmodel C ON A.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " Inner Join production.tCustomer D ON B.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join production.tLocation E ON B.Loc_ID=E.Loc_ID" & Environment.NewLine
                strSql &= " Inner Join production.tDevice F ON B.Device_ID=F.Device_ID" & Environment.NewLine
                strSql &= " Where B.Cust_ID= " & iCust_ID & " and B.Loc_ID= " & iLoc_ID & " AND B.BulkOrderType_ID= 2 And A.Closed=1"
                Select Case iBox1SN2
                    Case 1
                        strSql &= " And  A.BoxID ='" & strInput & "'; " & Environment.NewLine
                    Case 2
                        strSql &= " And  B.SerialNo='" & strInput & "'; " & Environment.NewLine
                    Case Else
                        strSql = "Select * From edi.twarehousebox Limit 0;" ' not correct, so return 0 row datatable
                End Select

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
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