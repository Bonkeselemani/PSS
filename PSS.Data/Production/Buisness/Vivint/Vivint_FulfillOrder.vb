Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports System.IO

Namespace Buisness.VV
    Public Class Vivint_FulfillOrder
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


        Public Function getNewOrders(ByVal iCust_ID As Integer, ByVal iEDI_TracnsSet As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT *" & Environment.NewLine
                strSql &= " FROM edi.tmessage_extend" & Environment.NewLine
                strSql &= " WHERE Cust_ID=" & iCust_ID & " AND Order_Type='Out' AND TransSetCode = " & iEDI_TracnsSet & " AND SoHeaderID=0 AND PO IS NOT NULL AND LENGTH(Trim(PO))>0;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getPOItemData(ByVal iExt_Msg_ID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM edi.tmessage_extend_items WHERE ext_Msg_ID = " & iExt_Msg_ID & ";" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function CreateAndGetWO_ID(ByVal strWO_Name As String, ByVal iLoc_ID As Integer, _
                                          ByVal iOrderQty As Integer, ByVal iProd_ID As Integer, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim iWO_ID As Integer = 0

            Try
                strWO_Name = strWO_Name.Replace("'", "''")
                strSql = "INSERT INTO production.tWorkOrder (WO_CustWO,WO_Date,WO_Quantity,Loc_ID,WO_Closed,Prod_ID) VALUES (" & _
                         "'" & strWO_Name & "','" & strDateTime & "'," & iOrderQty & "," & iLoc_ID & ",0," & iProd_ID & ");"

                iWO_ID = Me._objDataProc.ExecuteScalarForInsert(strSql, "production.tWorkOrder")

                Return iWO_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreateAndGetSoHeader_ID(ByVal iExt_Msg_ID As Integer, ByVal iWO_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim iSoHeader_ID As Integer = 0
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO saleorders.soheader (Cust_ID, PONumber, CustomerOrderNumber, WorkOrderID, PODate, CustomerFirstName, CustomerAddress1, CustomerCity, CustomerState, CustomerPostalCode" & Environment.NewLine
                strSql &= " , CustomerCountry, CustomerPhone, BillTo_Name, BillTo_Address1, BillTo_City, BillTo_State, BillTo_PostalCode, BillTo_Country, BillTo_Phone)" & Environment.NewLine
                strSql &= " SELECT Cust_ID,PO AS 'PONumber', PO AS 'CustomerOrderNumber', " & iWO_ID & " as 'WorkOrderID', PO_Date AS 'PODate'" & Environment.NewLine
                strSql &= " ,Ship_Name AS 'CustomerFirstName',Ship_Address AS 'CustomerAddress1',Ship_City AS 'CustomerCity',Ship_State AS 'CustomerState'" & Environment.NewLine
                strSql &= " ,Ship_Zip AS 'CustomerPostalCode',Ship_Country AS 'CustomerCountry', PER2_Tel AS 'CustomerPhone'" & Environment.NewLine
                strSql &= " ,Bill_Name AS 'BillTo_Name',Bill_Address AS 'BillTo_Address1',Bill_City AS 'BillTo_City', Bill_State AS 'BillTo_State'" & Environment.NewLine
                strSql &= " ,Bill_Zip AS 'BillTo_PostalCode',Bill_Country AS 'BillTo_Country',PER1_Tel AS 'BillTo_Phone'" & Environment.NewLine
                strSql &= " FROM edi.tmessage_extend" & Environment.NewLine
                strSql &= " WHERE edi.tmessage_extend.ext_Msg_ID = " & iExt_Msg_ID & ";" & Environment.NewLine

                iSoHeader_ID = Me._objDataProc.ExecuteScalarForInsert(strSql, "saleorders.soheader")

                'i = Me._objDataProc.ExecuteNonQuery(strSql)
                'strSql = "SELECT LAST_INSERT_ID();" 'get primary key after Insert
                'iSoHeader_ID = Me._objDataProc.GetIntValue(strSql)

                'Update edi.tmessage_extend
                strSql = "UPDATE edi.tmessage_extend SET SoHeaderID= " & iSoHeader_ID & " WHERE ext_Msg_ID = " & iExt_Msg_ID & ";" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return iSoHeader_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function SaveItemData(ByVal iExt_Msg_ID As Integer, ByVal iSoHeaderID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim row As DataRow

            Try
                strSql = "INSERT INTO saleorders.sodetails (SOHeaderID, LineItemNumber, ItemCode, ProductName, SKU, Quantity, UnitOfMeasure, BasePrice, RequestedDeliveryDate)" & Environment.NewLine
                strSql &= " SELECT " & iSoHeaderID & " AS 'SOHeaderID', Item_LineNo AS 'LineItemNumber', PO_BuyerItem AS 'ItemCode',PID_ItemDesc AS 'ProductName',  PO_BuyerItem AS 'SKU', PO_Qty AS 'Quantity'" & Environment.NewLine
                strSql &= " ,PO_UnitCode AS 'UnitOfMeasure',PO_UnitPrice AS 'BasePrice',DTM_DeliveryRequestedDate AS 'RequestedDeliveryDate'" & Environment.NewLine
                strSql &= " FROM edi.tmessage_extend_items" & Environment.NewLine
                strSql &= " WHERE ext_Msg_ID = " & iExt_Msg_ID & ";" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'Try to update Model_ID
                strSql = "UPDATE saleorders.sodetails A" & Environment.NewLine
                strSql &= " INNER JOIN tModel B ON Trim(B.ShippedModel)=TRIM(A.ItemCode)" & Environment.NewLine
                strSql &= " SET A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE SoHeaderID=" & iSoHeaderID & ";" & Environment.NewLine
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getEDI810NotSentOrders(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.SoHeaderID,A.PONumber,A.WorkorderID" & Environment.NewLine
                strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder B ON A.WorkOrderID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN edi.tmessage_extend C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND (C.EDI810_SentDateTime IS NULL OR C.EDI810_SentDateTime ='0000-00-00 00:00:00')" & Environment.NewLine
                strSql &= " ORDER BY A.SoHeaderID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--SELECT--", 0}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOpenOrders(ByVal iCust_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT SoHeaderID,PONumber,WorkorderID" & Environment.NewLine
                strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder B ON A.WorkOrderID=B.WO_ID" & Environment.NewLine
                strSql &= " WHERE Cust_ID=" & iCust_ID & " AND B.WO_Closed=0" & Environment.NewLine
                strSql &= " ORDER BY SoHeaderID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"0", "--SELECT--", 0}, True)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSelectedOrderData(ByVal iSoHeaderID As Integer, Optional ByVal iCust_ID As Integer = 0, Optional ByVal strPoNumber As String = "") As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'strSql = "SELECT SoHeaderID,Cust_ID, PONumber, CustomerOrderNumber, WorkOrderID, DATE_FORMAT(PODate,'%Y-%m-%d') AS  'PODate', CustomerFirstName, CustomerAddress1" & Environment.NewLine
                'strSql &= " , CustomerCity, CustomerState, CustomerPostalCode, CustomerCountry, CustomerPhone,ShipDate,B.*" & Environment.NewLine
                'strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                'strSql &= " INNER JOIN production.tworkorder B ON A.WorkOrderID=B.WO_ID" & Environment.NewLine
                strSql = "SELECT SoHeaderID,Cust_ID, PONumber, CustomerOrderNumber, WorkOrderID, DATE_FORMAT(PODate,'%Y-%m-%d') AS  'PODate', CustomerFirstName, CustomerAddress1" & Environment.NewLine
                strSql &= " , CustomerCity, CustomerState, CustomerPostalCode, CustomerCountry, CustomerPhone,ShipDate,BillTo_Name,BillTo_Address1,BillTo_City,BillTo_State,BillTo_PostalCode,BillTo_Country,BillTo_Phone" & Environment.NewLine
                strSql &= " ,B.WO_ID,B.WO_CustWO,B.WO_Date,B.WO_Quantity,B.WO_RAQnty,B.Loc_ID,B.WO_Closed" & Environment.NewLine
                strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder B ON A.WorkOrderID=B.WO_ID" & Environment.NewLine
                If iCust_ID > 0 AndAlso strPoNumber.Trim.Length > 0 Then
                    strPoNumber = strPoNumber.Replace("'", "''")
                    strSql &= " WHERE A.Cust_ID = " & iCust_ID & " AND B.WO_Closed=1 AND A.PONumber='" & strPoNumber & "';"
                Else
                    strSql &= " WHERE SoHeaderID=" & iSoHeaderID & ";" & Environment.NewLine
                End If


                ' 

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSelectedOrderDetailData(ByVal iSoHeaderID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT A.LineItemNumber AS 'Line',A.ItemCode AS 'Shipped_Model',A.Quantity AS 'Order_Qty',A.ShipQuantity AS 'Shipped_Qty',DATE_FORMAT(A.RequestedDeliveryDate,'%Y-%m-%d')  AS 'DeliveryDate'" & Environment.NewLine
                strSql &= " ,A.ProductName,B.Model_Desc AS 'PSS_Model',A.SoHeaderID,A.Model_ID,A.SoDetailsID" & Environment.NewLine
                strSql &= " FROM saleorders.sodetails A" & Environment.NewLine
                strSql &= " LEFT JOIN production.tModel B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.SoHeaderID=" & iSoHeaderID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSelectedOrder_ASN_Msg(ByVal iSoHeaderID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iExt_Msg_ID As Integer = 0
            Dim row As DataRow
            Dim strRet As String = ""

            Try
                strSql = "SELECT Ext_Msg_ID FROM edi.tmessage_extend WHERE SoHeaderID = " & iSoHeaderID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows  'one row only
                    iExt_Msg_ID = Convert.ToInt32(row("Ext_Msg_ID"))
                    Exit For
                Next

                'Med_ID, Ext_Msg_ID, MsgSequenceNo, Msg, Other1, Note
                strSql = "SELECT *" & Environment.NewLine
                strSql &= " FROM  edi.tmessage_extend_details" & Environment.NewLine
                strSql &= " WHERE Ext_Msg_ID =5" & Environment.NewLine
                strSql &= " Order by MsgSequenceNo;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    strRet &= row("Msg") & Environment.NewLine
                Next

                Return strRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getAvailableManifestData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, _
                                                 Optional ByVal strManifestNo As String = "", _
                                                 Optional ByVal iSoHeaderID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT '' AS 'Manifest_No',DATE_FORMAT(A.pkslip_CreateDt,'%Y-%m-%d') AS 'pkslip_Date'" & Environment.NewLine
                strSql &= " ,B.Pallett_Name,B.Pallett_ShipDate,C.Model_Desc AS 'PSS_Model',C.ShippedModel,C.ShippedModel_Desc,SUM(B.Pallett_Qty) AS Pallett_Qty" & Environment.NewLine
                strSql &= " ,B.Pallett_ReadyToShipFlg,B.Pallet_ShipType,B.Model_ID,A.PkSlip_ID,A.Cust_ID,B.Loc_ID,B.Pallett_ID,A.pkslip_ID" & Environment.NewLine
                strSql &= " FROM  production.tpackingslip A" & Environment.NewLine
                strSql &= " INNER JOIN production.tpallett B ON A.Pkslip_ID=B.pkslip_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tModel C ON B.Model_ID=C.Model_ID" & Environment.NewLine

                If iSoHeaderID > 0 Then 'shipped manifest
                    strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND B.Loc_ID = " & iLoc_ID & " AND A.SoHeaderID=" & iSoHeaderID & " AND B.Pallet_ShipType=0 " & Environment.NewLine
                ElseIf strManifestNo.Trim.Length > 0 Then 'specific manifest available for filling order 
                    strManifestNo = strManifestNo.Replace("'", "''")
                    strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND B.Loc_ID = " & iLoc_ID & " AND A.SoHeaderID=0 AND B.Pallet_ShipType=0 AND LPAD(A.pkslip_ID,9,'0') ='" & strManifestNo & "' " & Environment.NewLine
                Else 'all available manifest data
                    strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND B.Loc_ID = " & iLoc_ID & " AND A.SoHeaderID=0 AND B.Pallet_ShipType=0 " & Environment.NewLine
                End If
                strSql &= " GROUP BY A.SoHeaderID" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getDeviceData(ByVal iPallett_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT *" & Environment.NewLine
                strSql &= " FROM production.tdevice" & Environment.NewLine
                strSql &= " WHERE pallett_ID = " & iPallett_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CompletePO_Fulfillment(ByVal iWO_ID As Integer, ByVal iSoHeaderID As Integer, ByVal strDate As String, _
                                              ByVal iUserID As Integer, ByVal dtDetails As DataTable, ByVal strPackSlip_IDs As String, _
                                              ByVal strTrackingNo As String, ByVal strCarrier As String, ByVal iWeight As Integer, ByVal strBOL As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim row As DataRow

            Try
                strTrackingNo = strTrackingNo.Replace("'", "''")
                strCarrier = strCarrier.Replace("'", "''")
                strBOL = strBOL.Replace("'", "''")

                strSql = "UPDATE production.tworkorder SET WO_Closed=1 WHERE Wo_ID=" & iWO_ID & " ;" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = " UPDATE saleorders.soheader SET ShipDate='" & strDate & "', ShipUserID=" & iUserID & ", OutboundTrackingNumber = '" & strTrackingNo & "' , ShipCarrier= '" & strCarrier & "', ShipWeight = " & iWeight & ", BillOfLading = '" & strBOL & "' WHERE SoHeaderID=" & iSoHeaderID & ";" & Environment.NewLine
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                For Each row In dtDetails.Rows
                    strSql = " UPDATE saleorders.sodetails SET ShipQuantity =" & row("Shipped_Qty") & " WHERE SoDetailsID=" & row("SoDetailsID") & ";" & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Next

                strSql = "UPDATE  production.tpackingslip SET SoHeaderID=" & iSoHeaderID & " WHERE pkslip_ID IN (" & strPackSlip_IDs & ");" & Environment.NewLine

                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PrintShipLabelAndPackSlip(ByVal strShipDate As String, ByVal dtShipOrder As DataTable, ByVal dtManifest As DataTable, _
                                                  ByVal bPrintLabel As Boolean, ByVal bPrintPackSlip As Boolean) As Integer
            Dim strReportName_Label As String = "Vivint_Shipping_Mark_Label.rpt"
            Dim strReportName_PackSlip As String = "Vivint_PO_Ship_Packing_Slip.rpt"

            Dim strSql As String = "", strSql_PkSlip As String = ""
            Dim iRet As Integer = 0
            Dim row As DataRow, row2 As DataRow
            Dim dtFilteredRows() As DataRow
            Dim arrlstManifest_PKslip_IDs As New ArrayList()
            Dim iPkSlip_ID As Integer = 0
            Dim i As Integer = 0, j As Integer = 0

            Dim strCityStateCountry As String = ""
            Dim strLongAddress As String = ""
            Dim strPO As String = ""
            Dim strPO_BarCode As String = ""
            Dim strPoDate1 As String = "", strPoDate2 As String = ""
            Dim strItemModel As String = ""
            Dim strPssModel As String = ""
            Dim strItemModel_BarCode As String = ""
            Dim strPssModel_BarCode As String = ""
            Dim iManifest_SeqNo As Integer = 0
            Dim strItemDesc As String = ""
            Dim iQty As Integer = 0
            Dim strQty_BarCode As String = ""
            Dim strVendorName As String = "Premier"
            Dim strManifestNo As String = ""
            Dim strManifestNo_BarCode As String = ""
            Dim strCartonNo As String = ""

            Dim strShipDate1 As String = "", strShipDate2 As String = ""
            Dim strShipName1 As String = "", strShipName2 As String = ""
            Dim strShipAddress As String = ""
            Dim strShipCityStateZIP As String = ""
            Dim strShipPhone As String = ""
            Dim strBillName1 As String, strBillName2 As String = ""
            Dim strBillAddress As String = ""
            Dim strBillCityStateZIP As String = ""
            Dim strBillPhone As String = ""

            Dim dtLabel As DataTable, dtPackslip As DataTable, dtTmp As DataTable

            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                'Manifest 
                'Manifest_No, pkslip_Date, Pallett_Name, Pallett_ShipDate, PSS_Model, ShippedModel,ShippedModel_Desc, Pallett_Qty
                ', Pallett_ReadyToShipFlg, Pallet_ShipType, Model_ID, PkSlip_ID, Cust_ID, Loc_ID, Pallett_ID,pkslip_ID

                'Ship Order
                'SoHeaderID, Cust_ID, PONumber, CustomerOrderNumber, WorkOrderID, PODate, CustomerFirstName, CustomerAddress1
                ', CustomerCity, CustomerState, CustomerPostalCode, CustomerCountry, CustomerPhone, ShipDate, BillTo_Name, BillTo_Address1
                ', BillTo_City, BillTo_State, BillTo_PostalCode, BillTo_Country, BillTo_Phone, WO_ID, WO_CustWO, WO_Date, WO_Quantity, WO_RAQnty, Loc_ID, WO_Closed

                strShipDate1 = strShipDate
                strShipDate2 = Format(CDate(strShipDate), "MM/dd/yyyy")

                'get PO info
                For Each row In dtShipOrder.Rows ' it is one row
                    strCityStateCountry = row("CustomerCity") & ", " & row("CustomerState") & ", " & row("CustomerCountry")
                    strCityStateCountry = ReplaceChar(strCityStateCountry)
                    strLongAddress = row("CustomerAddress1") & ", " & row("CustomerCity") & ", " & row("CustomerState") & ", " & row("CustomerPostalCode") & ", " & row("CustomerCountry")
                    strLongAddress = ReplaceChar(strLongAddress)
                    strPO = row("PONumber")
                    If strPO.Trim.Length > 0 Then strPO_BarCode = ReplaceChar(FontEncoder.Code128a(strPO))
                    strPO = ReplaceChar(strPO)
                    strPoDate1 = row("PODate")
                    strPoDate2 = Format(CDate(strPoDate1), "MM/dd/yyyy")

                    strShipName1 = ""
                    strShipName2 = ReplaceChar(row("CustomerFirstName"))
                    strShipAddress = ReplaceChar(row("CustomerAddress1"))
                    strShipCityStateZIP = ReplaceChar(row("CustomerCity") & ", " & row("CustomerState") & " " & row("CustomerPostalCode"))
                    strShipPhone = ReplaceChar(row("CustomerPhone"))

                    strBillName1 = ""
                    strBillName2 = ReplaceChar(row("BillTo_Name"))
                    strBillAddress = ReplaceChar(row("BillTo_Address1"))
                    strBillCityStateZIP = ReplaceChar(row("BillTo_City") & ", " & row("BillTo_State") & " " & row("BillTo_PostalCode"))
                    strBillPhone = ReplaceChar(row("BillTo_Phone"))

                    Exit For
                Next

                'get unique pkslip_IDs
                For Each row In dtManifest.Rows
                    If Not arrlstManifest_PKslip_IDs.Contains(row("pkslip_ID")) Then
                        arrlstManifest_PKslip_IDs.Add(row("pkslip_ID"))
                    End If
                Next

                'for each manifest pkslip_id
                iManifest_SeqNo = 0
                For i = 0 To arrlstManifest_PKslip_IDs.Count - 1 ' each manifest pkslip_id
                    iPkSlip_ID = arrlstManifest_PKslip_IDs(i)
                    dtFilteredRows = dtManifest.Select("[pkslip_ID]=" & iPkSlip_ID)
                    If dtFilteredRows.Length > 0 Then    'it should be > 0
                        If dtFilteredRows.Length = 1 Then
                            strCartonNo = "C1"
                        Else
                            strCartonNo = "C1 - " & "C" & dtFilteredRows.Length.ToString
                        End If
                        iManifest_SeqNo += 1 : j = 0 : iQty = 0
                        For Each row In dtFilteredRows 'boxes in the manifest have the same thing except for pallet_name, Pallet_ID, Pallett_Qty
                            If j = 0 Then
                                strItemModel = row("ShippedModel")
                                If strItemModel.Trim.Length > 0 Then strItemModel_BarCode = ReplaceChar(FontEncoder.Code128a(strItemModel))
                                strItemModel = ReplaceChar(strItemModel)
                                strPssModel = row("PSS_Model")
                                If strPssModel.Trim.Length > 0 Then strPssModel_BarCode = ReplaceChar(FontEncoder.Code128a(strPssModel))
                                strPssModel = ReplaceChar(strPssModel)
                                strItemDesc = row("ShippedModel_Desc")
                                strManifestNo = row("Manifest_No")
                                If strManifestNo.Trim.Length > 0 Then strManifestNo_BarCode = ReplaceChar(FontEncoder.Code128a(strManifestNo))
                            End If
                            iQty += Convert.ToInt32(row("Pallett_Qty"))
                            j += 1
                        Next
                        strQty_BarCode = ReplaceChar(FontEncoder.Code128a(iQty))
                    Else
                        Throw New Exception("Manifest data has invalid data for manifest PkSlip_ID " & iPkSlip_ID.ToString & ". See IT.")
                    End If
                    strSql = "SELECT" & Environment.NewLine
                    strSql &= "'" & strCityStateCountry & "' AS 'AddressShort','" & strLongAddress & "' AS 'AddressLong','" & strPO & "' AS 'PO','" & strPO_BarCode & "' AS 'PO_BarCode','" & strItemModel & "' AS 'ItemModel','" & strPssModel & "' AS 'PssModel','" & strItemModel_BarCode & "' AS 'ItemModel_BarCode'" & Environment.NewLine
                    strSql &= " ,'" & strPssModel_BarCode & "' AS 'PssModel_BarCode','" & strItemDesc & "' AS 'ItemDesc'," & iQty & " AS 'Qty','" & strQty_BarCode & "' AS 'Qty_BarCode','" & strVendorName & "' AS 'VendorName'," & iManifest_SeqNo & " AS 'PalletSeqNo','#" & iManifest_SeqNo.ToString & "' AS 'PalletSeqNo_Str'" & Environment.NewLine
                    strSql &= " ,'" & strManifestNo & "' AS 'ManifestID','" & strManifestNo_BarCode & "' AS 'ManifestID_BarCode','" & strCartonNo & "' AS 'CartonNo','' AS 'Other1','' AS 'Other2',0 AS 'Qty2',0.0 AS 'Qty3','' AS 'OrigCountry'" & Environment.NewLine
                    strSql &= " ;" & Environment.NewLine

                    dtLabel = Me._objDataProc.GetDataTable(strSql)
                    iRet += dtLabel.Rows.Count

                    'PkSlip data
                    strSql_PkSlip = "SELECT" & Environment.NewLine
                    strSql_PkSlip &= iManifest_SeqNo & " AS 'RecNo','" & strShipDate1 & "' AS 'ShipDate','" & strShipDate2 & "' AS 'ShipDate2','" & strShipName1 & "' AS 'ShipName','" & strShipName2 & "' AS 'ShipName2','" & strShipAddress & "' AS 'ShipAddress'" & Environment.NewLine
                    strSql_PkSlip &= " ,'" & strShipCityStateZIP & "' AS 'ShipCityStateZip','" & strShipPhone & "' AS 'ShipPhone','" & strBillName1 & "' AS 'BillName','" & strBillName2 & " ' AS 'BillName2','" & strBillAddress & "' AS 'BillAddress'" & Environment.NewLine
                    strSql_PkSlip &= " ,'" & strBillCityStateZIP & "' AS 'BillCityStateZip','' AS 'ShipAddressAll','' AS 'BillAddressAll','' AS 'ShipCountry','' AS 'BillCountry'" & Environment.NewLine
                    strSql_PkSlip &= " ,'" & strPoDate1 & "' AS 'PoDate','" & strPoDate1 & "' AS 'PoDate2','" & strPO & "' AS 'PO','" & strPO_BarCode & "' AS 'PO_BarCode','" & strManifestNo & "' AS 'ManifestPallet','" & strItemModel & "' AS 'ItemModel'" & Environment.NewLine
                    strSql_PkSlip &= " ,'" & strPssModel & "' AS 'PSSModel','" & strItemDesc & "' AS 'ItemDesc'," & iManifest_SeqNo & " AS 'ManifestPalletSeqNo'," & iQty & " AS 'ShipItemQty','' AS 'Other1'" & Environment.NewLine
                    strSql_PkSlip &= " ,'' AS 'Other2','' AS 'Other3',0 AS 'Qty1',0 AS 'Qty2',0.0 AS 'QtyNum'" & Environment.NewLine

                    dtTmp = Me._objDataProc.GetDataTable(strSql_PkSlip)
                    If i = 0 Then dtPackslip = dtTmp.Clone
                    For Each row2 In dtTmp.Rows
                        dtPackslip.ImportRow(row2)
                    Next

                    'Print label for each manifest
                    If bPrintLabel AndAlso dtLabel.Rows.Count > 0 Then
                        Try 'Print specific label printer
                            PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName_Label, 1, "LabelPrinter")
                        Catch ex As Exception 'print it to default printer
                            PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtLabel, strReportName_Label, 1, )
                        End Try
                    End If
                Next ' each manifest pkslip_id

                'Print Manifest packing slip report
                iRet += dtPackslip.Rows.Count
                If bPrintPackSlip AndAlso dtPackslip.Rows.Count > 0 Then
                    PSS.Data.Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtPackslip, strReportName_PackSlip, 1, )
                End If

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getInvoiceNumber(ByVal iSoHeader_ID As Integer) As String
            Dim strSql As String = ""
            Dim strInvoiceNo As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT SoHeaderID,PoNumber,InvoiceNo FROM saleorders.SoHeader WHERE SoHeaderID = " & iSoHeader_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("InvoiceNo") Then
                    strInvoiceNo = dt.Rows(0).Item("InvoiceNo")
                End If
                Return strInvoiceNo
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AddInvoiceNumber(ByVal iSoHeader_ID As Integer, ByVal strInvoiceNo As String) As Integer
            Dim strSql As String = ""
            Try
                strInvoiceNo = strInvoiceNo.Replace("'", "''")
                strSql = "UPDATE saleorders.SoHeader SET InvoiceNo= '" & strInvoiceNo & "' WHERE SoHeaderID =" & iSoHeader_ID & ";"
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
                'strS.Replace("'", "''").Replace("\", "\\")

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function


    End Class
End Namespace