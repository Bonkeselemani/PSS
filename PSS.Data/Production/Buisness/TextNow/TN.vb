Option Explicit On 
Imports System.ComponentModel
Namespace Buisness

    Public Class TN
        Public Const CUSTOMERID As Integer = 2596
        Public Const LOCID As Integer = 3400
        Public Const GROUPID As Integer = 118
        Public Const PRODID As Integer = 73
        Public Const Billcode_ID1 As Integer = 3991
        Public Const Billcode_ID2 As Integer = 3992
        Public Const iNewSku_ID As Integer = 16

        Private _objDataProc As DBQuery.DataProc

        Private Const _iSnLen As Integer = 19
        Private Const _iPrefixLen As Integer = 13
        Private Const _iIncrPos As Integer = 13
        Private Const _iIncrLen As Integer = 5
        Private Const _iSuffixPos As Integer = 18
        Private Const _iSuffixLen As Integer = 1
        Private Const _IChksumPos As Integer = 17

        'Dim _snLen As Integer = 20
        'Dim _prefixLen As Integer = 13
        'Dim _incrPos As Integer = 13
        'Dim _incrLen As Integer = 5
        'Dim _suffixPos As Integer = 19
        ''Dim _suffixLen As Integer = 1
        'Dim _chksumPos As Integer = 18

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

#Region "Order Fulfillment"
        '*************************************************************************************
        Public Function GetTNOpenOrder(ByVal iCust_ID As Integer, Optional ByVal iUserID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt, dtTmp As DataTable
            Dim row, row2 As DataRow
            Dim strSku As String = ""
            Dim iSoHeaderID As Integer = 0
            Dim iTotalQty As Integer = 0

            Try
                'strSql = "Select SOH.PONumber As 'Order No',SOD.Sku, '' As 'sku_part_nr','' As 'Sku Type','' As 'Insert PN',SOH.CustomerFirstName As 'Name'" & Environment.NewLine
                'strSql &= " ,SOH.CustomerAddress1 As 'Address 1',SOH.CustomerAddress2 As 'Address 2'" & Environment.NewLine
                'strSql &= " ,SOH.CustomerCity As 'City',SOH.CustomerState As 'State'" & Environment.NewLine
                'strSql &= " ,SOH.CustomerPostalCode As 'Zip Code',SOH.CustomerCountry As 'Country'" & Environment.NewLine
                'strSql &= " ,ZON.Zone,SOD.ProductName As 'Product',SOD.Quantity As 'Qty',SOH.PODate As 'Order Date',WO.WO_CustWO As 'PSSI WO'" & Environment.NewLine
                'strSql &= " ,SOH.OutboundTrackingNumber,SOH.TransactionDatetime,SOH.TransactionID" & Environment.NewLine
                'strSql &= " ,SOH.SOHeaderID,SOD.SODetailsID,WO.WO_ID,OD.Co_ID,ODI.coi_id" & Environment.NewLine
                'strSql &= " ,0 As 'Sku_ID', 0 As 'sku_type_decode_id', 0 As 'sku_insert_decode_id'" & Environment.NewLine
                'strSql &= " From saleOrders.soheader SOH" & Environment.NewLine
                'strSql &= " Inner Join saleOrders.sodetails SOD On SOH.SoHeaderID=SOD.SoHeaderID" & Environment.NewLine
                'strSql &= " Inner Join production.tworkorder WO On SOH.WorkOrderID=WO.WO_ID" & Environment.NewLine
                'strSql &= " Inner Join edi.tcust_order OD On SOH.WorkOrderID=OD.WO_ID" & Environment.NewLine
                'strSql &= " Inner Join edi.tcust_order_item ODI On OD.Co_ID=ODI.Co_ID" & Environment.NewLine
                'strSql &= " Inner Join production.tcustomer CST On OD.Cust_ID=CST.Cust_ID" & Environment.NewLine
                'strSql &= " Left Join  production.lShipUSPSZone ZON On OD.country_id=ZON.country_id" & Environment.NewLine
                'strSql &= " And (Left(OD.postal_cd,3)=ZON.ZipCode Or OD.postal_cd=ZON.ZipCode)" & Environment.NewLine
                'strSql &= " Where SOH.Cust_ID = " & iCust_ID & " And SOH.ShipDate is Null And SOH.InvalidOrder=0 And SOH.OrderStatusID=1" & Environment.NewLine
                'strSql &= " And Order_Cancel1_Ack2=0 " & Environment.NewLine
                'strSql &= " Order By ZON.Zone Desc;"

                'dt = Me._objDataProc.GetDataTable(strSql)

                'For Each row In dt.Rows
                '    strSku = row("Sku")
                '    strSql = "Select SK.Sku,SK.sku_part_nr,LCD1.Dcode_Sdesc As 'Sku Type',LCD2.Dcode_Sdesc As 'Insert PN'" & Environment.NewLine
                '    strSql &= " ,SK.Sku_ID,SK.sku_type_decode_id,SK.sku_insert_decode_id" & Environment.NewLine
                '    strSql &= " From production.tcust_Sku SK" & Environment.NewLine
                '    strSql &= " Inner Join production.lcodesdetail LCD1 On SK.sku_type_decode_id=LCD1.Dcode_ID" & Environment.NewLine
                '    strSql &= " Inner Join production.lcodesdetail LCD2 On SK.sku_insert_decode_id=LCD2.Dcode_ID" & Environment.NewLine
                '    strSql &= " Inner Join production.lcodesmaster LCM On LCM.Mcode_ID=LCD2.Mcode_ID" & Environment.NewLine
                '    strSql &= " Where SK.Cust_ID = " & iCust_ID & " And Sku ='" & strSku & "';" & Environment.NewLine
                '    dtTmp = Me._objDataProc.GetDataTable(strSql)
                '    If dtTmp.Rows.Count > 0 Then
                '        row.BeginEdit()
                '        row("Sku Type") = dtTmp.Rows(0).Item("Sku Type")
                '        row("Insert PN") = dtTmp.Rows(0).Item("Insert PN")
                '        row("Sku_ID") = dtTmp.Rows(0).Item("Sku_ID")
                '        row("sku_part_nr") = dtTmp.Rows(0).Item("sku_part_nr")
                '        row("sku_type_decode_id") = dtTmp.Rows(0).Item("sku_type_decode_id")
                '        row("sku_insert_decode_id") = dtTmp.Rows(0).Item("sku_insert_decode_id")
                '        row.AcceptChanges()
                '    End If
                'Next

                'strSql = "Select SOH.PONumber As 'Order No',0 As 'Qty','' As 'Sku', '' As 'sku_part_nr',SOH.CustomerFirstName As 'Name'" & Environment.NewLine
                'strSql &= " ,SOH.CustomerAddress1 As 'Address 1',SOH.CustomerAddress2 As 'Address 2'" & Environment.NewLine
                'strSql &= " ,SOH.CustomerCity As 'City',SOH.CustomerState As 'State'" & Environment.NewLine
                'strSql &= " ,SOH.CustomerPostalCode As 'Zip Code',SOH.CustomerCountry As 'Country'" & Environment.NewLine
                'strSql &= " ,ZON.Zone,SOH.PODate As 'Order Date',WO.WO_CustWO As 'PSSI WO','' As 'Sku Type','' As 'Insert PN'" & Environment.NewLine
                'strSql &= " ,SOH.OutboundTrackingNumber,SOH.TransactionDatetime,SOH.TransactionID" & Environment.NewLine
                'strSql &= " ,SOH.SOHeaderID,WO.WO_ID,OD.Co_ID" & Environment.NewLine
                'strSql &= " ,'' As 'Sku_ID', ''  As 'sku_type_decode_id', ''  As 'sku_insert_decode_id'" & Environment.NewLine
                'strSql &= " From saleOrders.soheader SOH" & Environment.NewLine
                'strSql &= " Inner Join production.tworkorder WO On SOH.WorkOrderID=WO.WO_ID" & Environment.NewLine
                'strSql &= " Inner Join production.tcustomer CST On SOH.Cust_ID=CST.Cust_ID" & Environment.NewLine
                'strSql &= " Inner Join edi.tcust_order OD On SOH.WorkOrderID=OD.WO_ID" & Environment.NewLine
                'strSql &= " Left Join  production.lShipUSPSZone ZON On OD.country_id=ZON.country_id" & Environment.NewLine
                'strSql &= " And (Left(SOH.CustomerPostalCode,3)=ZON.ZipCode Or SOH.CustomerPostalCode=ZON.ZipCode)" & Environment.NewLine
                'strSql &= " Where SOH.Cust_ID = " & iCust_ID & " And SOH.ShipDate is Null And SOH.InvalidOrder=0 And SOH.OrderStatusID=1" & Environment.NewLine
                'strSql &= " And Order_Cancel1_Ack2=0" & Environment.NewLine
                'strSql &= " Order By ZON.Zone Desc;" & Environment.NewLine

                If iUserID > 0 Then
                    strSql = "Select SOH.PONumber As 'Order No',0 As 'Qty','' As 'Sku',IF(SOH.OrderLocked=1, 'Yes','No') As 'Locked','' As 'sku_part_nr',SOH.CustomerFirstName As 'Name'" & Environment.NewLine
                    strSql &= " ,SOH.CustomerAddress1 As 'Address 1',SOH.CustomerAddress2 As 'Address 2'" & Environment.NewLine
                    strSql &= " ,SOH.CustomerCity As 'City',SOH.CustomerState As 'State'" & Environment.NewLine
                    strSql &= " ,SOH.CustomerPostalCode As 'Zip Code',SOH.CustomerCountry As 'Country',U.User_FullName As 'Locked By'" & Environment.NewLine
                    strSql &= " ,ZON.Zone,SOH.PODate As 'Order Date',WO.WO_CustWO As 'PSSI WO','' As 'Sku Type','' As 'Insert PN'" & Environment.NewLine
                    strSql &= " ,SOH.OutboundTrackingNumber,SOH.TransactionDatetime,SOH.TransactionID" & Environment.NewLine
                    strSql &= " ,SOH.SOHeaderID,WO.WO_ID,OD.Co_ID" & Environment.NewLine
                    strSql &= " ,'' As 'Sku_ID', ''  As 'sku_type_decode_id', ''  As 'sku_insert_decode_id'" & Environment.NewLine
                Else
                    strSql = "Select ZON.Zone, IF(SOH.OrderLocked=1, 'Yes','No') As 'Locked',U.User_FullName As 'Locked By'" & Environment.NewLine
                    strSql &= " ,SOH.PONumber As 'Order No',0 As 'Qty','' As 'Sku','' As 'sku_part_nr',SOH.CustomerFirstName As 'Name'" & Environment.NewLine
                    strSql &= " ,SOH.CustomerAddress1 As 'Address 1',SOH.CustomerAddress2 As 'Address 2'" & Environment.NewLine
                    strSql &= " ,SOH.CustomerCity As 'City',SOH.CustomerState As 'State'" & Environment.NewLine
                    strSql &= " ,SOH.CustomerPostalCode As 'Zip Code',SOH.CustomerCountry As 'Country'" & Environment.NewLine
                    strSql &= " ,SOH.PODate As 'Order Date',WO.WO_CustWO As 'PSSI WO','' As 'Sku Type','' As 'Insert PN'" & Environment.NewLine
                    strSql &= " ,SOH.OutboundTrackingNumber,SOH.TransactionDatetime,SOH.TransactionID" & Environment.NewLine
                    strSql &= " ,SOH.SOHeaderID,WO.WO_ID,OD.Co_ID" & Environment.NewLine
                    strSql &= " ,'' As 'Sku_ID', ''  As 'sku_type_decode_id', ''  As 'sku_insert_decode_id'" & Environment.NewLine
                End If
                strSql &= " From saleOrders.soheader SOH" & Environment.NewLine
                strSql &= " Inner Join production.tworkorder WO On SOH.WorkOrderID=WO.WO_ID" & Environment.NewLine
                strSql &= " Inner Join production.tcustomer CST On SOH.Cust_ID=CST.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join edi.tcust_order OD On SOH.WorkOrderID=OD.WO_ID" & Environment.NewLine
                strSql &= " Left Join  production.lShipUSPSZone ZON On OD.country_id=ZON.country_id" & Environment.NewLine
                strSql &= " And (Left(SOH.CustomerPostalCode,3)=ZON.ZipCode Or SOH.CustomerPostalCode=ZON.ZipCode)" & Environment.NewLine
                strSql &= " Left Join security.tusers U On SOH.OrderLocked_UserID=U.User_ID" & Environment.NewLine
                strSql &= " Where SOH.Cust_ID = " & iCust_ID & " And SOH.ShipDate is Null And SOH.InvalidOrder=0 And SOH.OrderStatusID=1" & Environment.NewLine
                strSql &= " And Order_Cancel1_Ack2=0" & Environment.NewLine

                If iUserID > 0 Then strSql &= " And SOH.OrderLocked=1 And SOH.OrderLocked_UserID= " & iUserID

                strSql &= " Order By ZON.Zone Desc,SOH.OrderLocked;" & Environment.NewLine


                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    iSoHeaderID = row("SOHeaderID")
                    dtTmp = Me.GetProductDetailData(iCust_ID, iSoHeaderID)
                    Try
                        iTotalQty = dtTmp.Compute("Sum([Order Qty])", String.Empty)
                    Catch ex As Exception
                    End Try

                    row.BeginEdit()
                    row("Qty") = iTotalQty
                    row("Sku") = Me.GetUniqueItems(dtTmp, "Sku")
                    row("Sku Type") = Me.GetUniqueItems(dtTmp, "Sku Type")
                    row("Insert PN") = Me.GetUniqueItems(dtTmp, "Insert PN")
                    row("Sku_ID") = Me.GetUniqueItems(dtTmp, "Sku_ID")
                    row("sku_part_nr") = Me.GetUniqueItems(dtTmp, "sku_part_nr")
                    row("sku_type_decode_id") = Me.GetUniqueItems(dtTmp, "sku_type_decode_id")
                    row("sku_insert_decode_id") = Me.GetUniqueItems(dtTmp, "sku_insert_decode_id")
                    row.AcceptChanges()
                Next

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing : dtTmp = Nothing
            End Try
        End Function

        Public Function UpdatelockOrder(ByVal iSoheaderID As Integer, ByVal iUserID As Integer, ByVal strDatetime As String) As Integer
            Dim strSql As String

            'Locak order
            Try

                strSql = "UPDATE saleOrders.soheader SET OrderLocked=1,OrderLocked_UserID= " & iUserID & ",OrderLocked_DateTime='" & strDatetime & "'"
                strSql &= " WHERE SoHeaderID=" & iSoheaderID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateUnlockOrder(ByVal iSoheaderID As Integer) As Integer
            Dim strSql As String
            'Unlock order

            Try

                strSql = "UPDATE saleOrders.soheader SET OrderLocked=0,OrderLocked_UserID=0,OrderLocked_DateTime=NULL"
                strSql &= " WHERE SoHeaderID=" & iSoheaderID & ";"

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function IsOrderLocked(ByVal iSoheaderID As Integer) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim bLocked As Boolean = False

            'Is an order locked?
            Try

                strSql = "SELECT OrderLocked FROM  saleOrders.soheader WHERE SoHeaderID=" & iSoheaderID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then 'should be 1 record
                    If dt.Rows(0).Item("OrderLocked") = 1 Then
                        bLocked = True
                    Else
                        bLocked = False
                    End If
                End If

                Return bLocked

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetProductDetailData(ByVal iCust_ID As Integer, ByVal iSoheaderID As Integer) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "Select SOD.Sku,SK.sku_part_nr,SOD.Quantity As 'Order Qty',0 as 'Ship Qty'" & Environment.NewLine
                strSql &= " ,LCD1.Dcode_Sdesc As 'Sku Type',LCD2.Dcode_Sdesc As 'Insert PN',SOD.ProductName" & Environment.NewLine
                strSql &= " ,SOD.SoDetailsID,SOD.LineItemNumber" & Environment.NewLine
                strSql &= " ,SK.Sku_ID,SK.sku_type_decode_id,SK.sku_insert_decode_id" & Environment.NewLine
                strSql &= " From saleorders.Sodetails SOD" & Environment.NewLine
                strSql &= " Left Join production.tcust_Sku SK On SOD.sku=SK.sku" & Environment.NewLine
                strSql &= " Left Join production.lcodesdetail LCD1 On SK.sku_type_decode_id=LCD1.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join production.lcodesdetail LCD2 On SK.sku_insert_decode_id=LCD2.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join production.lcodesmaster LCM On LCM.Mcode_ID=LCD2.Mcode_ID" & Environment.NewLine
                strSql &= " Where SK.Cust_ID = " & iCust_ID & " and SOD.SoHeaderID=" & iSoheaderID & Environment.NewLine
                strSql &= " Order By SK.sku_part_nr,SOD.LineItemNumber;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then 'try multiple Insert 
                    strSql = "Select SOD.Sku,SK.sku_part_nr,SOD.Quantity As 'Order Qty',0 as 'Ship Qty'" & Environment.NewLine
                    strSql &= " ,LCD1.Dcode_Sdesc As 'Sku Type',LCD2.Dcode_Sdesc As 'Insert PN',SOD.ProductName" & Environment.NewLine
                    strSql &= " ,SOD.SoDetailsID,SOD.LineItemNumber" & Environment.NewLine
                    strSql &= " ,SK.Sku_ID,SK.sku_type_decode_id,SK.sku_insert_decode_id" & Environment.NewLine
                    strSql &= " From saleorders.Sodetails SOD" & Environment.NewLine
                    strSql &= " Left Join production.tcust_Sku_plus SK On SOD.sku=SK.sku" & Environment.NewLine
                    strSql &= " Left Join production.lcodesdetail LCD1 On SK.sku_type_decode_id=LCD1.Dcode_ID" & Environment.NewLine
                    strSql &= " Left Join production.lcodesdetail LCD2 On SK.sku_insert_decode_id=LCD2.Dcode_ID" & Environment.NewLine
                    strSql &= " Left Join production.lcodesmaster LCM On LCM.Mcode_ID=LCD2.Mcode_ID" & Environment.NewLine
                    strSql &= " Where SK.Cust_ID = " & iCust_ID & " and SOD.SoHeaderID=" & iSoheaderID & Environment.NewLine
                    strSql &= " Order By SK.sku_part_nr,SOD.LineItemNumber;" & Environment.NewLine

                    dt = Me._objDataProc.GetDataTable(strSql)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetUniqueItems(ByVal dt As DataTable, ByVal strColName As String, _
                                       Optional ByRef ArrLst As ArrayList = Nothing) As String
            Dim strS As String = ""
            Dim row As DataRow
            Dim L_ArrLst As New ArrayList()
            Try
                For Each row In dt.Rows
                    If Not L_ArrLst.Contains(row(strColName)) AndAlso Trim(row(strColName)).Length > 0 Then
                        L_ArrLst.Add(row(strColName))
                        If strS.Trim.Length = 0 Then
                            strS = row(strColName)
                        Else
                            strS &= ", " & row(strColName)
                        End If
                    End If
                Next
                ArrLst = L_ArrLst

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOrderDetailSkuItems(ByVal dt As DataTable) As String
            Dim strS As String = ""
            Dim row As DataRow
            Dim iTotalQty As Integer = 0

            Try
                Try
                    iTotalQty = dt.Compute("Sum([Order Qty])", String.Empty)
                Catch ex As Exception
                End Try

                For Each row In dt.Rows
                    If Trim(row("Sku")).Length > 0 Then
                        If strS.Trim.Length = 0 Then
                            If iTotalQty > 1 Then
                                strS = row("Sku") & " (" & row("Order Qty") & ")"
                            Else
                                strS = row("Sku")
                            End If
                        Else
                            If iTotalQty > 1 Then
                                strS &= ", " & row("Sku") & " (" & row("Order Qty") & ")"
                            Else
                                strS &= ", " & row("Sku")
                            End If
                        End If
                    End If
                Next

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOrderFilledCardSNs(ByVal strSoDetailsIDs As String) As String
            Dim strS As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim strSql As String = ""

            Try
                strSql = "Select SK.sku_part_nr,SK.Sku,WH.Serial,WH.wi_ID,WH.Device_ID,WH.Sku_ID,WH.SoDetailsID" & Environment.NewLine
                strSql &= " From warehouse.warehouse_items WH" & Environment.NewLine
                strSql &= " Left Join production.tcust_Sku SK on WH.Sku_ID=SK.Sku_ID" & Environment.NewLine
                strSql &= " Where WH.SoDetailsID in (" & strSoDetailsIDs & ");" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    If strS.Trim.Length = 0 Then
                        strS = row("serial") & " (" & row("sku_part_nr") & ")"
                    Else
                        strS &= ", " & row("serial") & " (" & row("sku_part_nr") & ")"
                    End If
                Next

                Return strS
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWHDeviceData(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, _
                                        ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable, dtMoreInserts As DataTable, dtPN As DataTable
            Dim row As DataRow
            Dim strSku As String = ""
            Dim iSku_Insert_Decode_ID As Integer = 0
            Dim iKit_Insert_Decode_ID As Integer = 0
            Dim iSku_ID As Integer = 0
            ' Dim strInsertPN As String = ""

            Try
                strSql = "Select WH.Serial As 'SN',LCD2.Dcode_Sdesc As 'Insert PN',If(Trim(WH.Serial) =trim(DV.Device_SN),1,0) As 'Same SN',SK.Sku,SK.sku_part_nr" & Environment.NewLine
                strSql &= " ,LCD1.Dcode_Sdesc As 'Sku Type',DV.Device_DateShip,SOH.ShipDate As 'SO_ShipDate'" & Environment.NewLine
                strSql &= " ,WH.InsertPN_UserID,WH.InsertPN_Date,WH.Sku_ID,WH.Insert_decode_ID,SK.sku_type_decode_id,SK.sku_insert_decode_id,WH.Insert_Decode_ID As 'Kit_Insert_Decode_ID'" & Environment.NewLine
                'strSql &= " ,WH.SODetailsID,DV.Device_ID,WH.WI_ID,IF(SOH.OrderReturned=1,SOH.OrderReturned,0) as 'OrderReturned',SOH.OrderReturned_Datetime" & Environment.NewLine
                strSql &= " ,WH.SODetailsID,DV.Device_ID,WH.WI_ID,IF(SOH.OrderReturned=1,SOH.OrderReturned,0) as 'OrderReturned',SOH.OrderReturned_Datetime,0 as 'IsMultipleInserts_1Yes0No'" & Environment.NewLine
                strSql &= " From production.tdevice DV" & Environment.NewLine
                strSql &= " Inner Join warehouse.warehouse_items WH On DV.Device_ID=WH.Device_ID" & Environment.NewLine
                strSql &= " Left Join production.tcust_Sku SK On WH.Sku_ID = SK.Sku_ID And SK.Cust_ID=" & iCust_ID & Environment.NewLine
                strSql &= " Left Join production.lcodesdetail LCD1 On SK.sku_type_decode_id=LCD1.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join production.lcodesdetail LCD2 On SK.sku_insert_decode_id=LCD2.Dcode_ID" & Environment.NewLine
                strSql &= " Left Join saleOrders.sodetails SOD On WH.SODetailsID=SOD.SODetailsID" & Environment.NewLine
                strSql &= " Left Join saleOrders.soheader SOH On SOD.SOheaderID=SOH.SOheaderID" & Environment.NewLine
                strSql &= " Where DV.LOC_ID=" & iLoc_ID & " And WH.Serial ='" & strSN.Replace("'", "''") & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'dt: SN, Insert PN, Same SN, Sku, sku_part_nr, Sku Type, Device_DateShip, SO_ShipDate
                ', InsertPN_UserID, InsertPN_Date, Sku_ID, Insert_decode_ID, sku_type_decode_id
                ', sku_insert_decode_id, Kit_Insert_Decode_ID, SODetailsID, Device_ID, WI_ID, OrderReturned, OrderReturned_Datetime
                ', IsMultipleInserts_1Yes0No
                For Each row In dt.Rows 'should be 1 row if any
                    iSku_ID = row("Sku_ID")
                    iSku_Insert_Decode_ID = row("sku_insert_decode_id")
                    iKit_Insert_Decode_ID = row("Kit_Insert_Decode_ID")

                    dtMoreInserts = GetAddtionalInserts(iSku_ID)
                    If dtMoreInserts.Rows.Count > 0 Then row.BeginEdit() : row("IsMultipleInserts_1Yes0No") = 1 : row.AcceptChanges()

                    If iKit_Insert_Decode_ID > 0 AndAlso Not iKit_Insert_Decode_ID = iSku_Insert_Decode_ID Then 'kitted
                        'strSql = "select * from lcodesdetail where dcode_ID =" & iKit_Insert_Decode_ID & ";"
                        'dtPN = Me._objDataProc.GetDataTable(strSql)
                        'dtPN: sku_insert_decode_id, Insert PN, Sku, sku_part_nr, Sku Type
                        dtPN = GetAddtionalInserts(iSku_ID, iKit_Insert_Decode_ID)
                        Try
                            'strInsertPN = dtPN.Rows(0).Item("Dcode_Sdesc")
                            row.BeginEdit() : row("sku_insert_decode_id") = iKit_Insert_Decode_ID
                            row("Insert PN") = dtPN.Rows(0).Item("Insert PN")
                            row("Sku") = dtPN.Rows(0).Item("Sku")
                            row("sku_part_nr") = dtPN.Rows(0).Item("sku_part_nr")
                            row("Sku Type") = dtPN.Rows(0).Item("Sku Type")
                            row.AcceptChanges()
                        Catch ex2 As Exception
                            Throw ex2
                        End Try
                        '  row.BeginEdit() : row("sku_insert_decode_id") = iKit_Insert_Decode_ID : row("Insert PN") = strInsertPN : row.AcceptChanges()
                    End If
                Next

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetAddtionalInserts(ByVal iSku_ID As Integer, Optional ByVal iSku_Insert_Decode_ID As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim strSku As String = ""

            Try
                strSql = "Select A.sku_insert_decode_id,B.Dcode_Sdesc As 'Insert PN',Sku,sku_part_nr,C.Dcode_Sdesc As 'Sku Type' " & Environment.NewLine
                strSql &= " From production.tcust_sku_plus A" & Environment.NewLine
                strSql &= " Inner Join production.lcodesdetail B ON A.sku_insert_decode_id=B.Dcode_ID" & Environment.NewLine
                strSql &= " Inner Join production.lcodesdetail C ON A.sku_type_decode_id=C.Dcode_ID" & Environment.NewLine
                strSql &= " Where A.Sku_ID=" & iSku_ID & Environment.NewLine
                If iSku_Insert_Decode_ID > 0 Then strSql &= "  And A.Sku_Insert_Decode_ID=" & iSku_Insert_Decode_ID & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetTackingNumber(ByVal iSoHeaderID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRes As String = ""

            Try
                strSql = "Select SOHeaderID,ShipCarrier,OutboundTrackingNumber,PONumber As 'Order No',CustomerFirstName As 'Name'" & Environment.NewLine
                strSql &= " ,CustomerAddress1 As 'Address 1',CustomerAddress2 As 'Address 2'" & Environment.NewLine
                strSql &= " ,CustomerCity As 'City',CustomerState As 'State'" & Environment.NewLine
                strSql &= " ,CustomerPostalCode As 'Zip Code',CustomerCountry As 'Country'" & Environment.NewLine
                strSql &= " From saleOrders.soheader" & Environment.NewLine
                strSql &= " Where SoHeaderID = " & iSoHeaderID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strRes = dt.Rows(0).Item("OutboundTrackingNumber")
                End If

                Return strRes

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetFlatChargeBillCodeID(ByVal iCust_ID As Integer, _
                                                ByVal iBillCode_ID1 As Integer, _
                                                ByVal iBillCode_ID2 As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRes As Integer = 0

            Try
                strSql = "Select A.BillCode_ID,B.BillCode_desc,A.tcab_Amount As 'ChargeRate'" & Environment.NewLine
                strSql &= " ,A.ShippedCountStop,A.ShippedCountCurrent,A.tcab_id" & Environment.NewLine
                strSql &= " From production.tcustaggregatebilling A" & Environment.NewLine
                strSql &= " Inner Join production.lbillcodes B On A.Billcode_ID=B.Billcode_ID" & Environment.NewLine
                strSql &= " Where A.Cust_ID=" & iCust_ID & " And A.BillCode_ID=" & iBillCode_ID1 & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 1 Then
                    If Convert.ToInt16(dt.Rows(0).Item("ShippedCountStop")) >= Convert.ToInt16(dt.Rows(0).Item("ShippedCountCurrent")) Then
                        iRes = iBillCode_ID1
                    Else
                        iRes = iBillCode_ID2
                    End If
                End If

                Return iRes

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetFlatCharge(ByVal iCust_ID As Integer, _
                                      ByVal iBillCode_ID As Integer) As Single
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim vRes As Single = 0.0

            Try
                strSql = "Select A.BillCode_ID,B.BillCode_desc,A.tcab_Amount As 'ChargeRate'" & Environment.NewLine
                strSql &= " ,A.ShippedCountStop,A.ShippedCountCurrent,A.tcab_id" & Environment.NewLine
                strSql &= " From production.tcustaggregatebilling A" & Environment.NewLine
                strSql &= " Inner Join production.lbillcodes B On A.Billcode_ID=B.Billcode_ID" & Environment.NewLine
                strSql &= " Where A.Cust_ID=" & iCust_ID & " and A.BillCode_ID=" & iBillCode_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    vRes = dt.Rows(0).Item("ChargeRate")
                End If

                Return vRes

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetPrekitData(ByVal iSoHeaderID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRes As String = ""

            Try
                strSql = "Select SOHeaderID,OutboundTrackingNumber,PONumber As 'Order No',CustomerFirstName As 'Name'" & Environment.NewLine
                strSql &= " ,CustomerAddress1 As 'Address 1',CustomerAddress2 As 'Address 2'" & Environment.NewLine
                strSql &= " ,CustomerCity As 'City',CustomerState As 'State'" & Environment.NewLine
                strSql &= " ,CustomerPostalCode As 'Zip Code',CustomerCountry As 'Country'" & Environment.NewLine
                strSql &= " ,SOHeaderID" & Environment.NewLine
                strSql &= " From saleOrders.soheader" & Environment.NewLine
                strSql &= " Where SoHeaderID = " & iSoHeaderID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strRes = dt.Rows(0).Item("OutboundTrackingNumber")
                End If

                Return strRes

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function UpdatePrekitData(ByVal iWI_ID As Integer, _
                                         ByVal iInsertPartNo_DcodeID As Integer, _
                                         ByVal iUser_ID As Integer, _
                                         ByVal strDateTime As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update warehouse.warehouse_items Set insert_decode_id = " & iInsertPartNo_DcodeID
                strSql &= ",InsertPN_UserID = " & iUser_ID & ",InsertPN_Date='" & strDateTime & "'"
                strSql &= " Where WI_ID=" & iWI_ID

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function UpdateTNShipCloseOrder(ByVal iIsPrekitFilled As Integer, _
                                               ByVal iEDI_WO_ID As Integer, _
                                               ByVal iSoHeaderID As Integer, _
                                               ByVal iBillcode_ID As Integer, _
                                               ByVal iException_Type_ID As Integer, _
                                               ByVal vFlatLaborCharge As Single, _
                                               ByVal iUser_ID As Integer, _
                                               ByVal strDateTime As String, _
                                               ByVal strShipCarrier As String, _
                                               ByVal strShipTrackingNo As String, _
                                               ByVal dtFilledCardSN As DataTable) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0, j As Integer = 0, k As Integer = 0
            Dim iSoDetailsID As Integer = 0
            'Dim iInsertPartNo_DcodeID As Integer = 0
            Dim iWI_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim iShipQty As Integer = 0
            Dim row As DataRow
            Dim foundRows() As DataRow
            Dim UniqueSoDetailsIDs As New ArrayList()

            Try
                'warehouse.warehouse_items (all cards are prekitted, so no need update this insert_decode_id 
                For Each row In dtFilledCardSN.Rows
                    iSoDetailsID = row("SoDetailsID") : iWI_ID = row("WI_ID")
                    If Not UniqueSoDetailsIDs.Contains(iSoDetailsID.ToString) Then
                        UniqueSoDetailsIDs.Add(iSoDetailsID.ToString)
                    End If
                    strSql = "Update warehouse.warehouse_items Set SODetailsID=" & iSoDetailsID & " Where WI_ID=" & iWI_ID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                    j = 1
                Next

                'saleorders.SoHeader
                strSql = "Update saleorders.SoHeader Set ShipDate ='" & strDateTime & "', ShipUserID=" & iUser_ID & "," & Environment.NewLine
                strSql &= "ShipCarrier='" & strShipCarrier & "',OutboundTrackingNumber='" & strShipTrackingNo & "'," & Environment.NewLine
                strSql &= "IsPreKit=" & iIsPrekitFilled & ",Exception_Type_ID = " & iException_Type_ID
                strSql &= " Where SoHeaderID=" & iSoHeaderID
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                j = 2

                'saleorders.SoDetails
                For k = 0 To UniqueSoDetailsIDs.Count - 1
                    iSoDetailsID = UniqueSoDetailsIDs(k)
                    foundRows = dtFilledCardSN.Select("SoDetailsID = " & iSoDetailsID)
                    iShipQty = foundRows.Length
                    strSql = "Update saleorders.SoDetails Set ShipQuantity = " & iShipQty & " Where SODetailsID= " & iSoDetailsID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                    j = 3
                Next

                'tdevice and tdevicebill
                For Each row In dtFilledCardSN.Rows
                    iDevice_ID = row("Device_ID")

                    strSql = "Update tdevice Set Device_DateShip='" & strDateTime & "',Device_ShipWorkDate='" & strDateTime & "'," & Environment.NewLine
                    strSql &= "Device_FinishedGoods=1,WO_ID=" & iEDI_WO_ID & ",Device_LaborLevel=0,Device_LaborCharge=" & vFlatLaborCharge & Environment.NewLine
                    strSql &= " Where Device_ID = " & iDevice_ID
                    i += Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "Insert Into tdevicebill (DBill_InvoiceAmt,Device_ID,BillCode_ID,User_ID,Date_Rec)" & Environment.NewLine
                    strSql &= " Values (" & vFlatLaborCharge & "," & iDevice_ID & "," & iBillcode_ID & "," & Environment.NewLine
                    strSql &= iUser_ID & ",'" & strDateTime & "');"
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                    j = 5
                Next


                'tWorkorder
                strSql = "Update tworkorder Set WO_Closed =1,WO_Shipped=1,WO_DateShip='" & strDateTime & "'" & Environment.NewLine
                strSql &= " Where WO_ID = " & iEDI_WO_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)
                j = 6

                Return j

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function UpdateTNShipCloseOrder_OldWay(ByVal iIsPrekitFilled As Integer, _
                                               ByVal iWI_ID As Integer, _
                                               ByVal iDevice_ID As Integer, _
                                               ByVal iEDI_WO_ID As Integer, _
                                               ByVal iSoHeaderID As Integer, _
                                               ByVal iSoDetailsID As Integer, _
                                               ByVal iInsertPartNo_DcodeID As Integer, _
                                               ByVal iBillcode_ID As Integer, _
                                               ByVal vFlatLaborCharge As Single, _
                                               ByVal iShipQty As Integer, _
                                               ByVal iUser_ID As Integer, _
                                               ByVal strDateTime As String, _
                                               ByVal strShipCarrier As String, _
                                               ByVal strShipTrackingNo As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                'warehouse.warehouse_items
                strSql = "Update warehouse.warehouse_items Set insert_decode_id = " & iInsertPartNo_DcodeID
                strSql &= ", SODetailsID=" & iSoDetailsID
                strSql &= ",InsertPN_UserID = " & iUser_ID & ",InsertPN_Date='" & strDateTime & "'"
                strSql &= " Where WI_ID=" & iWI_ID
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                'saleorders.SoHeader
                strSql = "Update saleorders.SoHeader Set ShipDate ='" & strDateTime & "', ShipUserID=" & iUser_ID & "," & Environment.NewLine
                strSql &= "ShipCarrier='" & strShipCarrier & "',OutboundTrackingNumber='" & strShipTrackingNo & "'," & Environment.NewLine
                strSql &= "IsPreKit=" & iIsPrekitFilled
                strSql &= " Where SoHeaderID=" & iSoHeaderID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'saleorders.SoDetails
                strSql = "Update saleorders.SoDetails Set ShipQuantity = " & iShipQty & " Where SODetailsID= " & iSoDetailsID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'tdevice
                strSql = "Update tdevice Set Device_DateShip='" & strDateTime & "',Device_ShipWorkDate='" & strDateTime & "'," & Environment.NewLine
                strSql &= "Device_FinishedGoods=1,WO_ID=" & iEDI_WO_ID & ",Device_LaborLevel=0,Device_LaborCharge=" & vFlatLaborCharge & Environment.NewLine
                strSql &= " Where Device_ID = " & iDevice_ID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'tdevicebill
                strSql = "Insert Into tdevicebill (DBill_InvoiceAmt,Device_ID,BillCode_ID,User_ID,Date_Rec)" & Environment.NewLine
                strSql &= " Values (" & vFlatLaborCharge & "," & iDevice_ID & "," & iBillcode_ID & "," & Environment.NewLine
                strSql &= iUser_ID & ",'" & strDateTime & "');"
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                'tWorkorder
                strSql = "Update tworkorder Set WO_Closed =1,WO_Shipped=1,WO_DateShip='" & strDateTime & "'" & Environment.NewLine
                strSql &= " Where WO_ID = " & iEDI_WO_ID & ";"
                i += Me._objDataProc.ExecuteNonQuery(strSql)


                Return i

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function UpdateRejectInvalidOrder(ByVal iSoHeaderID As Integer, _
                                                 ByVal strRejectReason As String, _
                                                 ByVal iUser_ID As Integer, _
                                                 ByVal strDateTime As String) As Integer
            Dim strSql As String = ""

            Try
                strRejectReason = strRejectReason.Replace("'", "''")

                strSql = "Update saleorders.soheader  Set InvalidOrder = 1 "
                strSql &= ",InvalidOrder_UserID = " & iUser_ID & ",InvalidOrder_DateTime='" & strDateTime & "'"
                strSql &= ",ReasonOrderInvalid ='" & strRejectReason & "'"
                strSql &= " Where SOHeaderID=" & iSoHeaderID

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function UpdateOrderReturnedData(ByVal iSoHeaderID As Integer, _
                                                ByVal strInput As String, _
                                                ByVal iUser_ID As Integer, _
                                                ByVal strDateTime As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update saleorders.soheader Set OrderReturned=1 "
                strSql &= ",OrderReturned_UserID = " & iUser_ID & ",OrderReturned_Datetime='" & strDateTime & "'"
                strSql &= ",OrderReturned_Input='" & strInput.Replace("'", "''") & "'"
                strSql &= " Where SoHeaderID=" & iSoHeaderID

                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex

            End Try
        End Function

        Public Function GetSaleOrderData(ByVal iCust_ID As Integer, ByVal strTrackingNo As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT A.*,B.SODetailsID,B.ProductName,B.Quantity,B.ShipQuantity,B.SKU" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoHeaderID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND OutboundTrackingNumber ='" & strTrackingNo.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function


        Public Function GetSaleOrderHeaderData(ByVal iCust_ID As Integer, ByVal strTrackingNo As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT A.*,B.SODetailsID,B.ProductName,B.Quantity,B.ShipQuantity,B.SKU" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoHeaderID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND OutboundTrackingNumber ='" & strTrackingNo.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetShippedBulkOrderHeaderData(ByVal iCust_ID As Integer, ByVal strTrackingNo As String, Optional ByVal strOrderNo As String = "") As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strTrackingNo = strTrackingNo.Replace("'", "''")
                strOrderNo = strOrderNo.Replace("'", "''")

                strSql = "SELECT PONumber as 'Order No', CustomerFirstName as 'Name',CustomerAddress1 as 'Address 1',CustomerAddress2 as 'Address 2'" & Environment.NewLine
                strSql &= " ,CustomerCity as 'City',CustomerState as 'State',CustomerPostalCode as 'Zip Code' ,CustomerCountry as 'Country'" & Environment.NewLine
                strSql &= " ,CustomerOrderDate as 'Order Date',ShipDate as 'Ship Date',Security.tusers.user_Fullname as 'Operator'" & Environment.NewLine
                strSql &= " ,OutboundTrackingNumber as 'Tracking No',ShipCarrier,OrderReturned,InvalidOrder,WorkOrderID,OrderStatusID,SoHeaderID" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader" & Environment.NewLine
                strSql &= " left join Security.tusers on saleorders.SoHeader.ShipUserID=Security.tusers.user_ID" & Environment.NewLine
                strSql &= " WHERE Cust_ID= " & iCust_ID & " AND ShipDate IS NOT NULL"
                If strOrderNo.Trim.Length > 0 Then
                    strSql &= " AND PONumber ='" & strOrderNo & "';" & Environment.NewLine
                Else
                    strSql &= " AND OutboundTrackingNumber ='" & strTrackingNo & "';" & Environment.NewLine
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetSaleOrderNumberBySN(ByVal iCust_ID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSN = strSN.Replace("'", "''")

                strSql = "SELECT A.*,B.SoDetailsID,C.Serial" & Environment.NewLine
                strSql &= " FROM saleorders.soheader A" & Environment.NewLine
                strSql &= " INNER JOIN  saleorders.sodetails B ON A.SoHeaderID=B.SOheaderID" & Environment.NewLine
                strSql &= " INNER JOIN Warehouse.warehouse_items C ON B.SoDetailsID=C.SoDetailsID" & Environment.NewLine
                strSql &= " WHERE A.Cust_ID= " & iCust_ID & " And A.ShipDate IS NOT NULL And C.Serial ='" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetShippedBulkOrderProductDetailsData(ByVal iSoHeaderID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT WH.Serial As 'Shipped SN',SK.sku_part_nr as 'Shipped Card Type',SK.Sku as 'Shipped SKU',LCD2.Dcode_SDesc as 'Shipped Insert'" & Environment.NewLine
                strSql &= " ,SOD.SKU as 'Ordered SKU',WH.Sku_ID,SOD.SoDetailsID,SOD.SoHeaderID,WH.Device_ID,WH.WI_ID,WH.insert_decode_id" & Environment.NewLine
                strSql &= " FROM saleOrders.sodetails SOD" & Environment.NewLine
                strSql &= " LEFT JOIN warehouse.warehouse_items WH On WH.SODetailsID=SOD.SODetailsID" & Environment.NewLine
                strSql &= " LEFT JOIN production.tcust_Sku SK On WH.sku_ID=SK.sku_ID and Cust_ID= 2596" & Environment.NewLine
                strSql &= " LEFT JOIN production.lcodesdetail LCD1 On SK.sku_type_decode_id=LCD1.Dcode_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.lcodesdetail LCD2 On SK.sku_insert_decode_id=LCD2.Dcode_ID" & Environment.NewLine
                strSql &= " WHERE SOD.SoHeaderID=" & iSoHeaderID & Environment.NewLine
                strSql &= " ORDER BY SK.sku_part_nr;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function GetBulkOrderTotalQty(ByVal iSoHeaderID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0
            Try
                strSql = "SELECT SUM(Quantity) as 'Order Qty'" & Environment.NewLine
                strSql &= " FROM saleOrders.sodetails WHERE SoHeaderID=" & iSoHeaderID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then iRet = dt.Rows(0).Item("Order Qty")

                Return iRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetSaleOrderSN(ByVal iSoDetailsID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                strSql = "SELECT * FROM Warehouse.warehouse_items where SoDetailsID=" & iSoDetailsID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function IsOrderCancelledByTextNow(ByVal iSoheaderID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRes As Boolean = False
            Try
                strSql = "select * from saleOrders.soheader  where SoheaderID = " & iSoheaderID & " and  Order_Cancel1_Ack2>0;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then bRes = True
                Return bRes
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function FoundSku(ByVal strSku As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRes As Boolean = False
            Try
                strSql = "select * from tcust_sku where Upper(trim(Sku))='" & strSku.Trim.ToUpper & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strSql = "select * from tcust_sku_plus where Upper(trim(Sku))='" & strSku.Trim.ToUpper & "';" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                If dt.Rows.Count > 0 Then bRes = True
                Return bRes
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function UpdateAddressInfo(ByVal iSoHeaderID As Integer, ByVal iCust_ID As Integer, ByVal strCustomerFirstName As String, _
                                          ByVal strCustomerLastName As String, ByVal strCustomerAddress1 As String, ByVal strCustomerAddress2 As String, _
                                          ByVal strCustomerAddress3 As String, ByVal strCustomerCity As String, ByVal strCustomerState As String, _
                                          ByVal strCustomerPostalCode As String, ByVal strCustomerCountry As String, ByVal iUserID As Integer, _
                                          ByVal strUpdatedDateTime As String, ByVal strNote As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strCustomerFirstName = strCustomerFirstName.Replace("'", "''").Replace("\", "\\")
                strCustomerLastName = strCustomerLastName.Replace("'", "''").Replace("\", "\\")
                strCustomerAddress1 = strCustomerAddress1.Replace("'", "''").Replace("\", "\\")
                strCustomerAddress2 = strCustomerAddress2.Replace("'", "''").Replace("\", "\\")
                strCustomerAddress3 = strCustomerAddress3.Replace("'", "''").Replace("\", "\\")
                strCustomerCity = strCustomerCity.Replace("'", "''").Replace("\", "\\")
                strCustomerState = strCustomerState.Replace("'", "''").Replace("\", "\\")
                strCustomerPostalCode = strCustomerPostalCode.Replace("'", "''").Replace("\", "\\")
                strCustomerCountry = strCustomerCountry.Replace("'", "''").Replace("\", "\\")
                strUpdatedDateTime = strUpdatedDateTime.Replace("'", "''").Replace("\", "\\")
                strNote = strNote.Replace("'", "''").Replace("\", "\\")

                'Save Old to history table
                strSql = "INSERT INTO saleorders.soheaderhistory (SoHeaderID,Cust_ID,CustomerFirstName,CustomerLastName,CustomerAddress1," & _
                                                                  "CustomerAddress2,CustomerAddress3,CustomerCity,CustomerState,CustomerPostalCode," & _
                                                                  "CustomerCountry,UserID,UpdatedDateTime,Note)"
                strSql &= "SELECT " & _
                          iSoHeaderID & " AS SoHeaderID," & _
                          iCust_ID & " AS Cust_ID," & _
                          "'" & strCustomerFirstName & "' AS CustomerFirstName," & _
                          "'" & strCustomerLastName & "' AS CustomerLastName," & _
                          "'" & strCustomerAddress1 & "' AS CustomerAddress1," & _
                          "'" & strCustomerAddress2 & "' AS CustomerAddress2," & _
                          "'" & strCustomerAddress3 & "' AS CustomerAddress3," & _
                          "'" & strCustomerCity & "' AS CustomerCity," & _
                          "'" & strCustomerState & "' AS CustomerState," & _
                          "'" & strCustomerPostalCode & "' AS CustomerPostalCode," & _
                          "'" & strCustomerCountry & "' AS CustomerCountry," & _
                          iUserID & " AS UserID," & _
                          "'" & strUpdatedDateTime & "' AS UpdatedDateTime," & _
                          "'" & strNote & "' AS Note;"
                Me._objDataProc.ExecuteNonQuery(strSql)


                'Update new
                strSql = "UPDATE saleorders.soheader SET " & _
                                     "CustomerFirstName='" & strCustomerFirstName & "'," & _
                                     "CustomerLastName='" & strCustomerLastName & "'," & _
                                     "CustomerAddress1='" & strCustomerAddress1 & "'," & _
                                     "CustomerAddress2='" & strCustomerAddress2 & "'," & _
                                     "CustomerAddress3='" & strCustomerAddress3 & "'," & _
                                     "CustomerCity='" & strCustomerCity & "'," & _
                                     "CustomerState='" & strCustomerState & "'," & _
                                     "CustomerPostalCode='" & strCustomerPostalCode & "'," & _
                                     "CustomerCountry='" & strCustomerCountry & "' WHERE SoHeaderID=" & iSoHeaderID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)


                'strSql = "INSERT INTO saleorders.soheaderhistory (SoHeaderID,Cust_ID,CustomerFirstName,CustomerLastName,CustomerAddress1," & _
                '                                                  "CustomerAddress2,CustomerAddress3,CustomerCity,CustomerState,CustomerPostalCode," & _
                '                                                  "CustomerCountry,UserID,UpdatedDateTime,Note)" & _
                '          "VALUES (" & iSoHeaderID & "," & _
                '                   iCust_ID & "," & _
                '                   "'" & strCustomerFirstName & "'," & _
                '                   "'" & strCustomerLastName & "'," & _
                '                   "'" & strCustomerAddress1 & "'," & _
                '                   "'" & strCustomerAddress2 & "'," & _
                '                   "'" & strCustomerAddress3 & "'," & _
                '                   "'" & strCustomerCity & "'," & _
                '                   "'" & strCustomerState & "'," & _
                '                   "'" & strCustomerPostalCode & "'," & _
                '                   "'" & strCustomerCountry & "'," & _
                '                   iUserID & "," & _
                '                   "'" & strUpdatedDateTime & "'," & _
                '                   "'" & strNote & "');"
                'Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetLabelPrinterSettingrData(ByVal strPC_Name As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strPC_Name = strPC_Name.Replace("'", "''")
                strSql = "SELECT * FROM saleorders.labelprinters WHERE WorkStation='" & strPC_Name & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function InsertUpdateLabelPrinterSettingrData(ByVal strPC_Name As String, ByVal strPrinterName As String, _
                                                             ByVal iUser_ID As Integer, ByVal strDateTime As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                'PRT_ID, WorkStation, Printer_Name, UserID, UpdatedDateTime
                strPC_Name = strPC_Name.Replace("'", "''")
                strPrinterName = strPrinterName.Replace("'", "''").Replace("\", "\\")
                strSql = "SELECT * FROM saleorders.labelprinters WHERE WorkStation='" & strPC_Name & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    strSql = "INSERT INTO saleorders.labelprinters (WorkStation, Printer_Name, UserID, UpdatedDateTime) " & _
                             " VALUES ('" & strPC_Name & "','" & strPrinterName & "'," & iUser_ID & ",'" & strDateTime & "');"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "UPDATE  saleorders.labelprinters  SET Printer_Name = '" & strPrinterName & " ', UserID=" & iUser_ID & ", UpdatedDateTime= '" & strDateTime & "'" & _
                             " WHERE WorkStation ='" & strPC_Name & "';"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function PrintTextNowShipmentLabel(ByVal strFromAddressInfo As String, _
                                                  ByVal strToAddressInfo As String, _
                                                  ByVal strOrderNo As String, _
                                                  ByVal strPrinterName As String, _
                                                  ByVal iCopyNumber As Integer) As Integer

            Const strReportName As String = "TextNow_Shipment_Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            ' Dim strDate As String = Format(Now, "MM/dd/yyyy")
            Try
                strFromAddressInfo = strFromAddressInfo.Replace("'", "''")
                strToAddressInfo = strToAddressInfo.Replace("'", "''")
                strOrderNo = strOrderNo.Replace("'", "''")

                strSql = "Select '" & strFromAddressInfo & "' as FromInfo" & Environment.NewLine
                strSql &= ",'" & strToAddressInfo & "' as ToAllInfo" & Environment.NewLine
                strSql &= ",'" & strOrderNo & "' as ToOther1" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, strPrinterName)
                Catch ex As Exception
                    'try default printer again
                    objTFMisc.PrintCrystalReportLabel(dt, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
#End Region

#Region "Handle New SIM Card"

        Public Function getNewSKU_ID(ByVal strSKU As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iSku_ID As Integer = 0

            'TRI-CUT SIM HOM
            Try
                strSKU = strSKU.Trim.Replace("'", "''")
                strSql = "SELECT *  FROM tcust_sku WHERE sku='" & strSKU & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then iSku_ID = dt.Rows(0).Item("sku_id")

                Return iSku_ID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Sub getCorrectSN(ByVal strSN As String, ByRef strSNPart1 As String, ByRef strSNPart2 As String, ByRef strChkSum As String, ByRef strErrMsg As String)
            Dim strSN_NoChkSum As String = ""

            Try
                If Not strSN.Trim.Length = Me._iSnLen Then strErrMsg = "Invalid IMEI (length of IMEI must be " & Me._iSnLen : Exit Sub
                strSN = strSN.Trim

                strSN_NoChkSum = strSN.Substring(0, _iSuffixPos)
                If Not IsPostiveInteger(strSN_NoChkSum) Then strErrMsg = "Invalid IMEI (not numeric digits (Excluded last check sum)." : Exit Sub
                strSNPart1 = strSN.Substring(0, Me._iPrefixLen)
                strChkSum = strSN.Substring(Me._iSuffixPos, Me._iSuffixLen)
                strSNPart2 = strSN.Substring(Me._iIncrPos, Me._iIncrLen)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Function IsPostiveInteger(ByVal S As String) As Boolean
            Try
                If Convert.ToInt64(S) Then
                    If Convert.ToInt64(S) > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    If S = 0 Then
                        Return True
                    End If
                End If
            Catch
                Return False
            End Try
        End Function

        Public Function ValidateAndGenerate(ByVal strSNPart1_Start As String, ByVal strSNPart1_End As String, _
                                            ByVal strSNPart2_Start As String, ByVal strSNPart2_End As String, _
                                            ByRef strErrMsg As String) As DataTable
            Dim strSql As String = ""
            Dim iBeginV As Int32 = 0
            Dim iEndV As Int32 = 0
            Dim i As Int32 = 0, k As Integer = 0
            Dim dt As DataTable
            Dim RowNew As DataRow
            Dim strS As String = ""
            Dim iLength As Integer = 0
            Dim iTotalSN_Length As Integer = 0
            Dim strCorrectedSNPart2 As String = ""

            Try
                If Not strSNPart1_Start.Trim = strSNPart1_End.Trim Then strErrMsg = "Start prefix and end prefix are not the same!" : Exit Function
                If Not (IsNumeric(strSNPart2_Start) AndAlso IsNumeric(strSNPart2_End) AndAlso strSNPart2_Start.Trim.Length = strSNPart2_End.Trim.Length) Then strErrMsg = "Incremental number issue!" : Exit Function
                iBeginV = Convert.ToInt32(strSNPart2_Start) : iEndV = Convert.ToInt32(strSNPart2_End) : iLength = strSNPart2_Start.Trim.Length
                If Not iBeginV < iEndV Then strErrMsg = "Invalid incremental value." : Exit Function

                strSql = "Select 0 as  RecID,'' as IncrementalValue,'' as SN_NoChkSum, '' as ChkSum,'' as SN, 0 as SN_Length Limit 0;"
                dt = Me._objDataProc.GetDataTable(strSql)

                For i = iBeginV To iEndV
                    k += 1
                    RowNew = dt.NewRow
                    RowNew("RecID") = k : RowNew("IncrementalValue") = i.ToString
                    strCorrectedSNPart2 = i.ToString.Trim
                    If strCorrectedSNPart2.Length < iLength Then strCorrectedSNPart2 = strCorrectedSNPart2.PadLeft(iLength, "0")
                    RowNew("SN_NoChkSum") = strSNPart1_Start.Trim & strCorrectedSNPart2
                    strS = GetCheckDigit(strSNPart1_Start.Trim & strCorrectedSNPart2) 'Checksum_Calculated(i.ToString)  '(strSNPart1_Start.Trim & i.ToString)
                    RowNew("ChkSum") = strS
                    RowNew("SN") = strSNPart1_Start.Trim & strCorrectedSNPart2 & strS
                    iTotalSN_Length = (strSNPart1_Start.Trim & strCorrectedSNPart2 & strS).Length
                    RowNew("SN_Length") = iTotalSN_Length
                    dt.Rows.Add(RowNew)
                Next

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AreSNsAlreadyExit(ByVal strSNs As String, ByVal iSku_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim bRet As Boolean = False
            Dim dt As DataTable

            Try

                strSql = "select * from warehouse.warehouse_items  where Sku_ID = " & iSku_ID & " AND serial in (" & strSNs & ");"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    bRet = True
                End If

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function ReceiveSNsIntoSystem(ByVal dtSNs As DataTable, ByVal iSku_ID As Integer, ByVal iCust_ID As Integer, _
                                             ByVal iLoc_ID As Integer, ByVal iUserID As Integer) As Boolean
            Dim strSql As String = ""
            'Dim bRet As Boolean = False
            Dim dt As DataTable
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strDate As String = Format(Now, "yyyy-MM-dd")
            Dim strWO As String = Format(Now, "yyyyMMddHHmmss") '14 digits
            Dim random As New random()
            Dim iWO_ID As Integer = 0
            Dim iWR_ID As Integer = 0
            Dim strSNs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0, j As Integer

            Try

                strWO &= "_" & PSS.Data.Buisness.Generic.RandomString(5, True) & Convert.ToString(random.Next(10000, 99999)).Trim

                If Not dtSNs.Rows.Count > 0 Then Throw New Exception("No SN data. Can't receive.")


                'Create WO
                strSql = "INSERT INTO production.tworkorder (WO_CustWO, WO_Date, WO_Quantity, WO_RAQnty, OrderType_ID)" & Environment.NewLine
                strSql &= " SELECT '" & strWO & "' AS WO_CustWO,'" & strDTime & "' AS WO_Date, " & dtSNs.Rows.Count & " AS  WO_Quantity,0 AS WO_RAQnty,1 AS OrderType_ID" & Environment.NewLine
                iWO_ID = Me._objDataProc.ExecuteScalarForInsert(strSql, "production.tworkorder")

                If Not iWO_ID > 0 Then Throw New Exception("Invalid WO ID! Failed to receive.")

                'Create WO Receipt
                strSql = "INSERT INTO warehouse.warehouse_receipt (WR_Name, RF_ID, SC_ID, Receipt_Date, Receipt_QTY, Closed, User_ID, Cust_ID, Loc_ID, WO_ID)" & Environment.NewLine
                strSql &= " SELECT  '" & strWO & "' AS WR_Name, 0 AS  RF_ID, 0 AS SC_ID, '" & strDTime & "' AS  Receipt_Date, " & dtSNs.Rows.Count & " AS Receipt_QTY" & Environment.NewLine
                strSql &= " , 1 AS Closed, " & iUserID & " AS User_ID, " & iCust_ID & " AS Cust_ID," & iLoc_ID & " AS Loc_ID," & iWO_ID & " AS WO_ID;" & Environment.NewLine
                iWR_ID = Me._objDataProc.ExecuteScalarForInsert(strSql, "warehouse.warehouse_receipt")

                If Not iWR_ID > 0 Then Throw New Exception("Invalid WR ID! Failed to receive.")

                'Get all SNs, strSQL 
                i = 0
                For Each row In dtSNs.Rows
                    i += 1
                    If i = 1 Then
                        strSNs = "'" & row("SN") & "'"
                        strSql = "insert into tdevice (Device_SN,Device_DateRec,device_RecWorkDate,Device_Qty,Device_Cnt,Loc_ID)" & Environment.NewLine
                        strSql &= " values" & Environment.NewLine

                        If i = dtSNs.Rows.Count Then
                            strSql &= "('" & row("SN") & "','" & strDTime & "','" & strDate & "',1,1," & iLoc_ID & ");" : Exit For
                        Else
                            strSql &= "('" & row("SN") & "','" & strDTime & "','" & strDate & "',1,1," & iLoc_ID & "),"
                        End If
                    Else
                        strSNs &= ",'" & row("SN") & "'"
                        If i >= dtSNs.Rows.Count Then
                            strSql &= "('" & row("SN") & "','" & strDTime & "','" & strDate & "',1,1," & iLoc_ID & ");" : Exit For
                        Else
                            strSql &= "('" & row("SN") & "','" & strDTime & "','" & strDate & "',1,1," & iLoc_ID & "),"
                        End If
                    End If
                Next

                'Receive Into tdevice
                j = Me._objDataProc.ExecuteNonQuery(strSql)

                'Check
                'strSql = "select * from production.tdevice where device_SN in (" & strSNs & ");" & Environment.NewLine
                'dt = Me._objDataProc.GetDataTable(strSql)

                If Not j > 0 Then Throw New Exception("Failed to receive SNs into tdevice.")

                'Receive into  warehouse.warehouse_items 
                strSql = "insert into warehouse.warehouse_items (device_ID,serial,Sku_ID,Date_received,WR_ID)" & Environment.NewLine
                strSql &= " select device_ID,device_SN as 'Serial'," & iSku_ID & " as 'Sku_ID','" & strDate & "' as 'Date_received', " & iWR_ID & "  as 'WR_ID' from production.tdevice where device_SN in (" & Environment.NewLine
                strSql &= strSNs & ") AND Device_DateRec ='" & strDTime & "' AND device_RecWorkDate ='" & strDate & "' AND Loc_ID=" & iLoc_ID & ";"

                j = Me._objDataProc.ExecuteNonQuery(strSql)

                If Not j > 0 Then Throw New Exception("Failed to receive SNs into warehouse_items.")


                Return True

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Private Function GetCheckDigit(ByVal idWithoutCheckDigit As String) As Integer
            Dim ucIdWithoutCheckdigit As String
            Dim digit As Int32 = 0
            Dim i As Integer = 0

            ucIdWithoutCheckdigit = UCase(idWithoutCheckDigit)
            Dim total As Int32 = 0
            For i = Len(ucIdWithoutCheckdigit) To 1 Step -2
                digit = Asc(Mid(ucIdWithoutCheckdigit, i, 1)) - 48
                total = total + (2 * digit) - Int(digit / 5) * 9
                If (i > 1) Then
                    digit = Asc(Mid(ucIdWithoutCheckdigit, i - 1, 1)) - 48
                    total = total + digit
                End If
            Next i
            total = Math.Abs(total) + 10

            Return (10 - (total Mod 10)) Mod 10


        End Function

        Private Function getCreaditCradChkSum(ByVal num As String)
            Dim d As Integer, sum As Integer = 0
            ' Dim num As String = "7992739871"
            Dim a As Integer = 0
            Dim i As Integer = 0

            For i = num.Length - 2 To 0
                d = Convert.ToInt32(num.Substring(i, 1))
                If a Mod 2 = 0 Then d = d * 2
                If d > 9 Then d -= 9
                sum += d
                a += 1
            Next

            'If (10 - (sum Mod 10) = Convert.ToInt32(num.Substring(num.Length - 1))) Then Console.WriteLine("valid")
            'Console.WriteLine("sum of digits of the number" & sum)
            Return sum

        End Function

        Function luhnCheckSum(ByVal InVal As String)
            luhnCheckSum = luhnSum(InVal) Mod 10
        End Function

        Private Function luhnSum(ByVal InVal As String) As Integer
            Dim evenSum As Integer
            Dim oddSum As Integer

            evenSum = 0
            oddSum = 0

            Dim strLen As Integer
            strLen = Len(InVal)

            Dim i As Integer
            For i = strLen To 1 Step -1
                Dim digit As Integer
                digit = CInt(Mid(InVal, i, 1))

                If ((i Mod 2) <> 0) Then ' NOT CORRECT!((i Mod 2) = 0)
                    oddSum = oddSum + digit
                Else
                    digit = digit * 2

                    If (digit > 9) Then
                        digit = digit - 9
                    End If

                    evenSum = evenSum + digit
                End If
            Next i

            luhnSum = (oddSum + evenSum)


        End Function

        Public ReadOnly Property Checksum_Calculated(ByVal strSn As String) As String
            Get
                ' GETS THE VALID CHECKSUM FOR A SERIAL NUMBER STRING.
                Dim odd As Boolean = True
                Dim i As Integer = 0
                Dim idWithoutCheckdigit As String = strSn.Substring(0, strSn.Length - 2)
                ' this will be a running total
                Dim sum As Integer = 0
                ' allowable characters within identifier
                Const validChars As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVYWXZ_"
                ' remove leading or trailing whitespace, convert to uppercase
                idWithoutCheckdigit = idWithoutCheckdigit.Trim().ToUpper()
                ' loop through digits from right to left
                For i = 0 To idWithoutCheckdigit.Length - 1
                    'set ch to "current" character to be processed
                    Dim ch As Char = idWithoutCheckdigit.Chars(idWithoutCheckdigit.Length - i - 1)
                    ' throw exception for invalid characters
                    If validChars.IndexOf(ch) = -1 Then
                        Throw New Exception(ch & " is an invalid character")
                    End If
                    ' our "digit" is calculated using ASCII value - 48
                    Dim digit As Integer = AscW(ch) - 48
                    ' weight will be the current digit's contribution to
                    ' the running total
                    Dim weight As Integer
                    If i Mod 2 = 0 Then
                        ' for alternating digits starting with the rightmost, we
                        ' use our formula this is the same as multiplying x 2 and
                        ' adding digits together for values 0 to 9.  Using the
                        ' following formula allows us to gracefully calculate a
                        ' weight for non-numeric "digits" as well (from their
                        ' ASCII value - 48).
                        weight = (2 * digit) - CInt(digit \ 5) * 9
                    Else
                        ' even-positioned digits just contribute their ascii
                        ' value minus 48
                        weight = digit
                    End If

                    ' keep a running total of weights
                    sum += weight
                Next i
                ' avoid sum less than 10 (if characters below "0" allowed,
                ' this could happen)
                sum = Math.Abs(sum) + 10
                ' check digit is amount needed to reach next number
                ' divisible by ten
                Return (10 - (sum Mod 10)) Mod 10
            End Get
        End Property


#End Region

#Region "Reports"
        '**********************************************************************************
        Public Function CreateInventoryReport(ByVal iCust_ID As Integer, _
                                              ByVal strRptName As String, _
                                              ByVal bSummaryDetails As Boolean) As Integer
            Dim strSql As String
            Dim dtSummary As DataTable
            Dim dtDetails As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports

            Try

                'summary
                strSql = "SELECT sku.sku_part_nr,sku.Sku,SUM(if(whi.insert_decode_id > 0,1,0)) as 'Kitted',SUM(if(whi.insert_decode_id > 0,0,1)) as 'Non-Kitted', COUNT(whi.wi_id) AS 'Total'" & Environment.NewLine
                strSql &= " FROM production.tcust_sku sku" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items whi ON sku.sku_id = whi.sku_id" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_receipt whr ON whi.wr_id = whr.wr_id" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice d ON whi.device_id = d.device_id" & Environment.NewLine
                strSql &= " WHERE whi.SoDetailsID=0 AND whr.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= " GROUP BY sku.sku_part_nr,sku.Sku" & Environment.NewLine
                strSql &= " ORDER BY sku.sku_part_nr;" & Environment.NewLine
                dtSummary = Me._objDataProc.GetDataTable(strSql)
                dtSummary.TableName = "Summary"
                ds.Tables.Add(dtSummary)

                If bSummaryDetails Then
                    'details
                    strSql = "SELECT whi.Serial as 'SIM Card ICCID (SN)', sku.sku_part_nr,sku.Sku,if(whi.insert_decode_id > 0,'Kitted','Non-Kitted') as 'Status'" & Environment.NewLine
                    strSql &= " FROM production.tcust_sku sku" & Environment.NewLine
                    strSql &= " INNER JOIN warehouse.warehouse_items whi ON sku.sku_id = whi.sku_id" & Environment.NewLine
                    strSql &= " INNER JOIN warehouse.warehouse_receipt whr ON whi.wr_id = whr.wr_id" & Environment.NewLine
                    strSql &= " INNER JOIN production.tdevice d ON whi.device_id = d.device_id" & Environment.NewLine
                    strSql &= " WHERE whi.SoDetailsID=0 AND whr.cust_id = " & iCust_ID & Environment.NewLine
                    strSql &= " ORDER BY sku.sku_part_nr;" & Environment.NewLine
                    dtDetails = Me._objDataProc.GetDataTable(strSql)
                    dtDetails.TableName = "Details"
                    ds.Tables.Add(dtDetails)
                End If

                objExcelRpt = New ExcelReports(False)

                If bSummaryDetails Then
                    objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName, New String() {"A", "B", "C", "D"})
                    ' objExcelRpt.RunNIInvoiceReport(ds, strRptName, strHeaderDates, bSummaryDetails, New String() {"A", "B", "C", "D", "E"}, New String() {"F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"})
                Else
                    objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName, New String() {"A", "B"})
                End If

                Return dtSummary.Rows.Count

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Function CreateTNSIMCardOrderReport(ByVal iReportType As Integer, _
                                                   ByVal iCust_ID As Integer, _
                                                   ByVal strRptName As String, _
                                                   ByVal strBegDTime As String, _
                                                   ByVal strEndDtime As String) As Integer
            Dim dt, dtDetails As DataTable
            Dim strSql As String
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim row, row2 As DataRow
            Dim iSoHeaderID As Integer = 0
            Dim strSoDetailsIDs As String = ""
            Dim iTotalQty As Integer = 0
            Dim strFilledICCIDs As String = ""
            Dim strOrderNo As String = ""
            Dim strDeliveryStatus As String = ""
            Dim strDeliveredDate As String = ""
            Dim strDeliveryNote As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "Select SOH.PONumber As 'Order No'" & Environment.NewLine
                strSql &= " ,IF((SOH.InvalidOrder=0) And (SOH.OrderReturned=0) And (NOT ISNULL(SOH.ShipDate) or Length(TRIM(SOH.ShipDate)))>0,'Shipped',IF(SOH.InvalidOrder=1,'Rejected'" & Environment.NewLine
                strSql &= " ,IF(SOH.OrderReturned=1,'Returned',IF(Order_Cancel1_Ack2>0,'TN Requested to Cancel','Open')))) as 'Status'" & Environment.NewLine
                strSql &= " ,Date_Format(SOH.PODate, '%Y-%m-%d') As 'Received Date',SOH.ShipDate,Date_Format(SOH.InvalidOrder_DateTime, '%Y-%m-%d') as 'Rejected Date'" & Environment.NewLine
                strSql &= " ,Date_Format(SOH.OrderReturned_DateTime, '%Y-%m-%d') as 'Returned Date',0 As 'Qty','' As 'Sku', '' As 'sku_part_nr', '' As 'Filled ICCID'" & Environment.NewLine
                strSql &= " ,SOH.DeliveryStatus,SOH.Delivered_Or_Expected_Date_Note As 'DeliveredDate',SOH.DeliveryStatusNote as 'DeliveryNote'" & Environment.NewLine
                strSql &= " ,SOH.CustomerFirstName As 'Name'" & Environment.NewLine
                strSql &= " ,SOH.CustomerAddress1 As 'Address 1',SOH.CustomerAddress2 As 'Address 2'" & Environment.NewLine
                strSql &= " ,SOH.CustomerCity As 'City',SOH.CustomerState As 'State'" & Environment.NewLine
                strSql &= " ,SOH.CustomerPostalCode As 'Zip Code',SOH.CustomerCountry As 'Country'" & Environment.NewLine
                strSql &= " ,ZON.Zone,WO.WO_CustWO As 'PSSI WO','' As 'Sku Type','' As 'Insert PN'" & Environment.NewLine
                strSql &= " ,LCD.Dcode_Ldesc As 'Endicia notification',SOH.OutboundTrackingNumber,SOH.TransactionDatetime,SOH.TransactionID" & Environment.NewLine
                strSql &= " ,SOH.SOHeaderID,WO.WO_ID,OD.Co_ID,SOH.InvalidOrder,SOH.OrderReturned,Order_Cancel1_Ack2,SOH.Exception_Type_ID" & Environment.NewLine
                strSql &= " ,'' As 'Sku_ID', '' As 'sku_type_decode_id', '' As 'sku_insert_decode_id'" & Environment.NewLine
                strSql &= " From saleOrders.soheader SOH" & Environment.NewLine
                strSql &= " Inner Join production.tworkorder WO On SOH.WorkOrderID=WO.WO_ID" & Environment.NewLine
                strSql &= " Inner Join production.tcustomer CST On SOH.Cust_ID=CST.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join edi.tcust_order OD On SOH.WorkOrderID=OD.WO_ID" & Environment.NewLine
                strSql &= " Left Join  production.lShipUSPSZone ZON On OD.country_id=ZON.country_id" & Environment.NewLine
                strSql &= " And (Left(SOH.CustomerPostalCode,3)=ZON.ZipCode Or SOH.CustomerPostalCode=ZON.ZipCode)" & Environment.NewLine
                strSql &= " Left Join lcodesdetail LCD On SOH.Exception_Type_ID=LCD.Dcode_id" & Environment.NewLine
                strSql &= " Where SOH.Cust_ID = " & iCust_ID & Environment.NewLine

                'iReportType must be 2,3,4,5,6
                Select Case iReportType
                    Case 2 'Received orders
                        strSql &= " And SOH.PODate Between '" & strBegDTime & "' And '" & strEndDtime & "'" & Environment.NewLine
                    Case 3 'Open orders
                        strSql &= " And SOH.ShipDate is Null And SOH.InvalidOrder=0 And SOH.OrderStatusID=1 And Order_Cancel1_Ack2=0" & Environment.NewLine
                    Case 4 'Rejected orders
                        strSql &= " And SOH.InvalidOrder=1" & Environment.NewLine
                        strSql &= " And SOH.InvalidOrder_DateTime Between '" & strBegDTime & "' And '" & strEndDtime & "'" & Environment.NewLine
                    Case 5 'Returned orders
                        strSql &= " And SOH.OrderReturned=1" & Environment.NewLine
                        strSql &= " And SOH.OrderReturned_DateTime Between '" & strBegDTime & "' And '" & strEndDtime & "'" & Environment.NewLine
                    Case 6 'Filled (shipped) orders
                        strSql &= " And SOH.InvalidOrder=0 And SOH.OrderReturned=0 And (NOT ISNULL(SOH.ShipDate) or Length(TRIM(SOH.ShipDate)))>0" & Environment.NewLine
                        strSql &= " And SOH.ShipDate Between '" & strBegDTime & "' And '" & strEndDtime & "'" & Environment.NewLine
                    Case Else
                        Return 0
                End Select

                strSql &= " Order By SOH.PODate,SOH.PONumber;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If iReportType = 4 Then  'Rejected orders
                    For Each row In dt.Rows
                        row.BeginEdit() : row("ShipDate") = DBNull.Value : row.AcceptChanges()
                    Next
                End If

                For Each row In dt.Rows
                    iSoHeaderID = row("SOHeaderID")
                    strOrderNo = row("Order No")
                    dtDetails = Me.GetProductDetailData(iCust_ID, iSoHeaderID)

                    Try
                        iTotalQty = dtDetails.Compute("Sum([Order Qty])", String.Empty)
                    Catch ex As Exception
                    End Try

                    'Get filled ICCIDs (SNs)
                    strFilledICCIDs = ""
                    If Trim(row("Status")).ToString.ToUpper = "Shipped".ToUpper Then
                        strSoDetailsIDs = ""
                        For Each row2 In dtDetails.Rows
                            If strSoDetailsIDs.Trim.Length = 0 Then
                                strSoDetailsIDs = row2("SoDetailsID")
                            Else
                                strSoDetailsIDs &= "," & row2("SoDetailsID")
                            End If
                        Next
                        If strSoDetailsIDs.Trim.Length > 0 Then strFilledICCIDs = Me.GetOrderFilledCardSNs(strSoDetailsIDs)
                    End If

                    'Get delivery data
                    iRet = 0
                    strDeliveryStatus = "" : strDeliveredDate = "" : strDeliveryNote = ""
                    iRet = Me.getOrderDeliveryData(strOrderNo, strDeliveryStatus, strDeliveredDate, strDeliveryNote)

                    'Update
                    row.BeginEdit()
                    row("Qty") = iTotalQty
                    row("Sku") = Me.GetOrderDetailSkuItems(dtDetails) ' Me.GetUniqueItems(dtDetails, "Sku")
                    row("Sku Type") = Me.GetUniqueItems(dtDetails, "Sku Type")
                    row("Insert PN") = Me.GetUniqueItems(dtDetails, "Insert PN")
                    row("Sku_ID") = Me.GetUniqueItems(dtDetails, "Sku_ID")
                    row("sku_part_nr") = Me.GetUniqueItems(dtDetails, "sku_part_nr")
                    row("sku_type_decode_id") = Me.GetUniqueItems(dtDetails, "sku_type_decode_id")
                    row("sku_insert_decode_id") = Me.GetUniqueItems(dtDetails, "sku_insert_decode_id")
                    If Trim(row("Status")).ToString.ToUpper = "Shipped".ToUpper AndAlso strFilledICCIDs.Trim.Length > 0 Then row("Filled ICCID") = strFilledICCIDs
                    If iRet > 0 Then
                        row("DeliveryStatus") = strDeliveryStatus : row("DeliveredDate") = strDeliveredDate : row("DeliveryNote") = strDeliveryNote
                    End If
                    row.AcceptChanges()
                Next

                dt.TableName = "Report Data"
                ds.Tables.Add(dt)

                'file name 
                Try
                    If iReportType = 3 Then 'Open orders
                        strRptName &= "_" & Format(Now, "yyyyMMddHHmmss")
                    Else
                        strRptName &= "(" & strBegDTime.Replace(" 00:00:00", "").Replace("-", "") & "_" & strEndDtime.Replace(" 23:59:59", "").Replace("-", "") & ")_" & Format(Now, "yyyyMMddHHmmss")
                    End If
                Catch ex As Exception
                End Try

                'do excel report
                objExcelRpt = New ExcelReports(False)
                objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName, _
                            New String() {"A", "B", "C", "D", "E", "F", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AJ", "AK", "AL"}, , False)

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************
        Public Function getOrderDeliveryData(ByVal strOrderNo As String, _
                                             ByRef strDeliveryStatus As String, _
                                             ByRef strDeliveredDate As String, _
                                             ByRef strDeliveryNote As String) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim iRes As Integer = 0

            Try
                strSql = "SELECT * FROM saleorders.deliverystatusdetails where referenceID='" & strOrderNo & "' order by DSD_ID desc;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                ' ,SOH.DeliveryStatus,SOH.Delivered_Or_Expected_Date_Note As 'DeliveredDate',SOH.DeliveryStatusNote as 'DeliveryNote'
                'SatusCode DeliveryDate StatusDescription
                If dt.Rows.Count > 0 Then
                    If Not dt.Rows(0).IsNull("StatusCode") AndAlso Trim(dt.Rows(0).Item("StatusCode")).Length > 0 Then strDeliveryStatus = dt.Rows(0).Item("StatusCode")
                    If Not dt.Rows(0).IsNull("DeliveryDate") AndAlso Trim(dt.Rows(0).Item("DeliveryDate")).Length > 0 Then strDeliveredDate = dt.Rows(0).Item("DeliveryDate")
                    If Not dt.Rows(0).IsNull("StatusDescription") AndAlso Trim(dt.Rows(0).Item("StatusDescription")).Length > 0 Then strDeliveryNote = dt.Rows(0).Item("StatusDescription")
                    iRes = 1
                End If

                Return iRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSIMCardInventorySummary(ByVal iCust_ID As Integer, ByRef dtDetails As DataTable) As DataTable
            Dim strSql As String = ""
            Dim dtSummary As DataTable

            Try
                'summary count
                strSql = "SELECT sku.sku_part_nr as 'Sku',SUM(if(whi.insert_decode_id > 0,1,0)) as 'Pre-Kitted'," & Environment.NewLine
                strSql &= "SUM(if(whi.insert_decode_id > 0,0,1)) as 'Non-Kitted',COUNT(whi.wi_id) AS 'Total',sku.Sku_ID" & Environment.NewLine
                strSql &= " FROM production.tcust_sku sku" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_items whi ON sku.sku_id = whi.sku_id" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_receipt whr ON whi.wr_id = whr.wr_id" & Environment.NewLine
                strSql &= " INNER JOIN production.tdevice d ON whi.device_id = d.device_id" & Environment.NewLine
                strSql &= " WHERE whi.SoDetailsID=0 AND whr.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= " GROUP BY sku.sku_part_nr,sku.Sku" & Environment.NewLine
                strSql &= " ORDER BY sku.sku_part_nr,sku.Sku_ID;" & Environment.NewLine
                dtSummary = Me._objDataProc.GetDataTable(strSql)

                'details
                strSql = " SELECT whi.Serial as 'SIM Card ICCID (SN)', sku.sku_part_nr,sku.Sku,if(whi.insert_decode_id > 0,'Pre-Kitted','Non-Kitted') as 'Status'" & Environment.NewLine
                strSql &= "  ,Date_Format( whr.Receipt_Date, '%Y-%m-%d') as 'Received Date',sku.Sku_ID" & Environment.NewLine
                strSql &= "  FROM production.tcust_sku sku" & Environment.NewLine
                strSql &= "  INNER JOIN warehouse.warehouse_items whi ON sku.sku_id = whi.sku_id" & Environment.NewLine
                strSql &= "  INNER JOIN warehouse.warehouse_receipt whr ON whi.wr_id = whr.wr_id" & Environment.NewLine
                strSql &= "  INNER JOIN production.tdevice d ON whi.device_id = d.device_id" & Environment.NewLine
                strSql &= "  WHERE whi.SoDetailsID=0 AND whr.cust_id = " & iCust_ID & Environment.NewLine
                strSql &= "  ORDER BY sku.sku_part_nr;" & Environment.NewLine
                dtDetails = Me._objDataProc.GetDataTable(strSql)

                Return dtSummary

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSIMCardAllFilledOpenData(ByVal iCust_ID As Integer, ByVal strBegDate As String, ByVal strEndDate As String, _
                                                    ByRef iOrderCountAll As Integer, ByRef iOrderCountFilled As Integer, ByRef iOrderCountOpen As Integer) As DataSet
            'Filled Orders:  Shipped and(exclude those shipped but have no SN - exceptuonal cases),Returned (exclude those which have no SN
            'Open Orders
            'Total = Filled + Open

            Dim strSql As String = ""
            Dim dtAllDetails
            Dim dtAll As New DataTable(), dtFilled As New DataTable(), dtOpen As New DataTable()
            Dim ds As New DataSet()
            Dim arrlstUniqueSkuAll As New ArrayList()
            Dim arrlstUniqueSkuFilled As New ArrayList()
            Dim arrlstUniqueSkuOpen As New ArrayList()
            Dim arrlstUniqueOrderAll As New ArrayList()
            Dim arrlstUniqueOrderFilled As New ArrayList()
            Dim arrlstUniqueOrderOpen As New ArrayList()
            Dim iCardQty As Integer = 0, iQtyOpen As Integer = 0
            Dim row, rowNew As DataRow
            Dim filledRows() As DataRow
            Dim i As Integer = 0

            Try
                strSql = "Select SOH.PONumber As 'Order No', WHI.Serial As 'Filled ICCID (SN)',SOD.Sku, SKU.sku_part_nr" & Environment.NewLine
                strSql &= " ,IF(NOT ISNULL(SOH.ShipDate) or Length(TRIM(SOH.ShipDate))>0, 1,SOD.Quantity)  as 'Qty',SOH.CustomerFirstName As 'Name'" & Environment.NewLine
                strSql &= " ,SOH.CustomerAddress1 As 'Address 1',SOH.CustomerAddress2 As 'Address 2'" & Environment.NewLine
                strSql &= " ,SOH.CustomerCity As 'City',SOH.CustomerState As 'State'" & Environment.NewLine
                strSql &= " ,SOH.CustomerPostalCode As 'Zip Code',SOH.CustomerCountry As 'Country'" & Environment.NewLine
                strSql &= " ,Date_Format(SOH.PODate, '%Y-%m-%d') As 'Received Date'" & Environment.NewLine
                strSql &= " ,Date_Format(SOH.OrderReturned_DateTime, '%Y-%m-%d') as 'Returned Date',SOH.ShipDate,SOH.OutboundTrackingNumber" & Environment.NewLine
                strSql &= " ,IF((SOH.InvalidOrder=0) And (SOH.OrderReturned=0) And (NOT ISNULL(SOH.ShipDate) or Length(TRIM(SOH.ShipDate)))>0,'Shipped',IF(SOH.InvalidOrder=1,'Rejected'" & Environment.NewLine
                strSql &= " ,IF(SOH.OrderReturned=1,'Returned',IF(Order_Cancel1_Ack2>0,'TN Requested to Cancel','Open')))) as 'Status'" & Environment.NewLine
                strSql &= " , LCD2.DCode_SDesc  As 'Sku Type',LCD1.DCode_SDesc As 'Insert PN'" & Environment.NewLine
                strSql &= " ,LCD.Dcode_Ldesc As 'Endicia notification',ZON.Zone,WO.WO_CustWO As 'PSSI WO'" & Environment.NewLine
                strSql &= " ,SOH.SOHeaderID,WO.WO_ID,SKU.Sku_ID,WHI.WI_ID,WHI.Device_ID,SOD.SoDetailsID,OD.Co_ID,SOH.OrderReturned" & Environment.NewLine
                strSql &= " From saleOrders.soheader SOH" & Environment.NewLine
                strSql &= " Inner Join saleOrders.sodetails SOD On SOH.SoHeaderID=SOD.SoHeaderID" & Environment.NewLine
                strSql &= " Inner Join production.tCust_Sku SKU On SOD.Sku =SKU.sku And SKU.Cust_ID=" & iCust_ID & Environment.NewLine
                strSql &= " Inner Join lcodesdetail LCD1 On SKU.Sku_Insert_Decode_ID=LCD1.DCode_ID" & Environment.NewLine
                strSql &= " Inner Join lcodesdetail LCD2 On SKU.Sku_type_Decode_ID=LCD2.DCode_ID" & Environment.NewLine
                strSql &= " Inner Join production.tworkorder WO On SOH.WorkOrderID=WO.WO_ID" & Environment.NewLine
                strSql &= " Inner Join production.tcustomer CST On SOH.Cust_ID=CST.Cust_ID" & Environment.NewLine
                strSql &= " Inner Join edi.tcust_order OD On SOH.WorkOrderID=OD.WO_ID" & Environment.NewLine
                strSql &= " Left Join  production.lShipUSPSZone ZON On OD.country_id=ZON.country_id" & Environment.NewLine
                strSql &= " And (Left(SOH.CustomerPostalCode,3)=ZON.ZipCode Or SOH.CustomerPostalCode=ZON.ZipCode)" & Environment.NewLine
                strSql &= " Left Join lcodesdetail LCD On SOH.Exception_Type_ID=LCD.Dcode_id" & Environment.NewLine
                strSql &= " Left Join warehouse.warehouse_Items WHI On SOD.SoDetailsID =WHI.SoDetailsID" & Environment.NewLine
                strSql &= " Where SOH.Cust_ID = " & iCust_ID & Environment.NewLine
                strSql &= " And SOH.PODate Between '" & strBegDate & " 00:00:00' And '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= " And ((IF((SOH.InvalidOrder=0) And (SOH.OrderReturned=0) And (NOT ISNULL(SOH.ShipDate) or Length(TRIM(SOH.ShipDate)))>0,'Shipped',IF(SOH.InvalidOrder=1,'Rejected'" & Environment.NewLine
                strSql &= " ,IF(SOH.OrderReturned=1,'Returned',IF(Order_Cancel1_Ack2>0,'TN Requested to Cancel','Open')))) in ('Shipped','Returned') AND NOT ISNULL(WHI.Serial))" & Environment.NewLine
                strSql &= " Or IF((SOH.InvalidOrder=0) And (SOH.OrderReturned=0) And (NOT ISNULL(SOH.ShipDate) or Length(TRIM(SOH.ShipDate)))>0,'Shipped',IF(SOH.InvalidOrder=1,'Rejected'" & Environment.NewLine
                strSql &= " ,IF(SOH.OrderReturned=1,'Returned',IF(Order_Cancel1_Ack2>0,'TN Requested to Cancel','Open')))) in ('Open'))" & Environment.NewLine
                strSql &= " Order By SKU.sku_part_nr,SOH.PODate,SOH.PONumber;" & Environment.NewLine

                dtAllDetails = Me._objDataProc.GetDataTable(strSql)
                dtAllDetails.TableName = "AllDetails"
                ds.Tables.Add(dtAllDetails)

                dtAll.Columns.Add("Sku", GetType(String)) : dtAll.Columns.Add("Card Count", GetType(Integer))
                dtFilled = dtAll.Clone
                dtOpen = dtAll.Clone

                For Each row In dtAllDetails.Rows
                    If Not arrlstUniqueSkuAll.Contains(row("sku_part_nr")) Then
                        arrlstUniqueSkuAll.Add(row("sku_part_nr"))
                    End If
                    If Trim(row("Status")).Trim.ToUpper = "Open".ToUpper AndAlso Not arrlstUniqueSkuOpen.Contains(row("sku_part_nr")) Then
                        arrlstUniqueSkuOpen.Add(row("sku_part_nr"))
                    End If
                    If Not Trim(row("Status")).Trim.ToUpper = "Open".ToUpper AndAlso Not arrlstUniqueSkuFilled.Contains(row("sku_part_nr")) Then
                        arrlstUniqueSkuFilled.Add(row("sku_part_nr"))
                    End If

                    If Not arrlstUniqueOrderAll.Contains(row("Order No")) Then
                        arrlstUniqueOrderAll.Add(row("Order No"))
                    End If
                    If Trim(row("Status")).Trim.ToUpper = "Open".ToUpper AndAlso Not arrlstUniqueOrderOpen.Contains(row("Order No")) Then
                        arrlstUniqueOrderOpen.Add(row("Order No"))
                    End If
                    If Not Trim(row("Status")).Trim.ToUpper = "Open".ToUpper AndAlso Not arrlstUniqueOrderFilled.Contains(row("Order No")) Then
                        arrlstUniqueOrderFilled.Add(row("Order No"))
                    End If
                Next

                iOrderCountAll = arrlstUniqueOrderAll.Count : iOrderCountFilled = arrlstUniqueOrderFilled.Count : iOrderCountOpen = arrlstUniqueOrderOpen.Count

                For i = 0 To arrlstUniqueSkuAll.Count - 1
                    iCardQty = 0
                    filledRows = dtAllDetails.Select("sku_part_nr ='" & arrlstUniqueSkuAll(i) & "'")
                    For Each row In filledRows
                        iCardQty += row("Qty")
                    Next
                    If filledRows.Length > 0 Then
                        rowNew = dtAll.NewRow
                        rowNew("Sku") = arrlstUniqueSkuAll(i)
                        rowNew("Card Count") = iCardQty
                        dtAll.Rows.Add(rowNew)
                    End If
                Next

                For i = 0 To arrlstUniqueSkuOpen.Count - 1
                    iCardQty = 0
                    filledRows = dtAllDetails.Select("sku_part_nr ='" & arrlstUniqueSkuOpen(i) & "' And Status ='Open'")
                    For Each row In filledRows
                        iCardQty += row("Qty")
                    Next
                    If filledRows.Length > 0 Then
                        rowNew = dtOpen.NewRow
                        rowNew("Sku") = arrlstUniqueSkuOpen(i)
                        rowNew("Card Count") = iCardQty
                        dtOpen.Rows.Add(rowNew)
                    End If
                Next

                For i = 0 To arrlstUniqueSkuFilled.Count - 1
                    iCardQty = 0
                    filledRows = dtAllDetails.Select("sku_part_nr ='" & arrlstUniqueSkuFilled(i) & "' And not Status ='Open'")
                    For Each row In filledRows
                        iCardQty += row("Qty")
                    Next
                    If filledRows.Length > 0 Then
                        rowNew = dtFilled.NewRow
                        rowNew("Sku") = arrlstUniqueSkuFilled(i)
                        rowNew("Card Count") = iCardQty
                        dtFilled.Rows.Add(rowNew)
                    End If
                Next

                dtAll.TableName = "All" : dtOpen.TableName = "Open" : dtFilled.TableName = "Filled"
                ds.Tables.Add(dtAll) : ds.Tables.Add(dtOpen) : ds.Tables.Add(dtFilled)

                Return ds

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

    End Class

End Namespace
