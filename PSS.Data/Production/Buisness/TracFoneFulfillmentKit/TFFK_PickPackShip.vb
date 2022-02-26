Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_PickPackShip
        Private _objDataProc As mySQL5

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New mySQL5()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

#End Region

        Public Function getOpenOrderAndWeightData() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.SoheaderID,A.OrderQty,A.OrderQty*F.Weight as 'OrderWeight'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcustomer D ON A.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " LEFT JOIN saleorders.ShipCarriers E ON A.ShipCarrier_ID=E.ShipCarrier_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel_items F ON B.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                strSql &= " GROUP BY A.SoheaderID;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateOrderTotalWeight(ByVal dt As DataTable) As Integer
            Dim row As DataRow
            Dim strSql As String = ""
            Dim strPart1 As String = ""
            Dim strPart2 As String = ""
            Dim iWeight As Single = 0.0
            Dim iSoheaderID As Integer = 0
            Dim i As Integer = 0

            Try
                strSql = "UPDATE  saleorders.Soheader" & Environment.NewLine
                strSql &= " SET ShipPackageWeight  = CASE SoHeaderID" & Environment.NewLine
                For Each row In dt.Rows
                    iSoheaderID = Convert.ToInt32(row("SoheaderID"))
                    iWeight = Convert.ToSingle(row("OrderWeight"))
                    strPart1 &= " WHEN '" & iSoheaderID.ToString & "' THEN " & iWeight.ToString
                    If i = 0 Then
                        strPart2 = iSoheaderID.ToString
                    Else
                        strPart2 &= "," & iSoheaderID.ToString
                    End If
                    i += 1
                Next
                strSql &= strPart1 & " END" & Environment.NewLine
                strSql &= " WHERE SoHeaderID IN (" & strPart2 & ");" & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ComputeShipMethodAndGetPickData() As Integer
            Dim strSql As String = ""
            Dim strSql_One As String = "", strSql_Two As String = ""
            Dim strSql_Three As String = "", strSql_Four As String = ""

            Dim dt As DataTable
            Dim iCust_ID As Integer = 0
            Dim row As DataRow
            'Dim objTFFK As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK
            Dim iShipCarrier_ID As Integer = 0
            Dim iOrderWeight As Single = 0.0
            Dim iOrderQty As Integer = 0
            Dim iSoheaderID As Integer = 0
            Dim iOrderType_ID As Integer = 0
            Dim strSoHeaderIDs As String = ""
            Dim iUpdated As Integer = 0

            Try
                strSql = "SELECT A.SoheaderID,A.OrderQty,A.ShipPackageWeight as 'OrderWeight',A.ShipCarrier_ID,A.PriorityExpedite,A.Cust_ID,D.Cust_Name1 as 'Customer'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcustomer D ON A.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " LEFT JOIN saleorders.ShipCarriers E ON A.ShipCarrier_ID=E.ShipCarrier_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel_items F ON B.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.PriorityExpedite=0  AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                strSql &= " GROUP BY A.SoheaderID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    'objTFFK = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
                    strSql = "UPDATE  saleorders.Soheader" & Environment.NewLine
                    strSql_One = " SET ShipCarrier_ID  = CASE SoHeaderID" & Environment.NewLine
                    strSql_Three = " OrderType_ID  = CASE SoHeaderID" & Environment.NewLine

                    For Each row In dt.Rows
                        iCust_ID = Convert.ToInt32(row("Cust_ID"))
                        iOrderWeight = Convert.ToSingle(row("OrderWeight"))
                        iOrderQty = Convert.ToInt32(row("OrderQty"))
                        iSoheaderID = Convert.ToInt32(row("SoheaderID"))
                        iShipCarrier_ID = Convert.ToInt32(row("ShipCarrier_ID"))

                        Select Case iCust_ID
                            Case PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID
                                If iOrderWeight > PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeiJerOrderWeightLimit Then
                                    iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeijerBulkCarrierShipMethodID
                                    iOrderType_ID = 2
                                Else
                                    If iOrderQty / PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeijerQtyPerBox > PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeiJerOrderBoxQtyLimit Then
                                        iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeijerBulkCarrierShipMethodID
                                        iOrderType_ID = 2
                                    Else
                                        iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iMeijerRegularCarrierShipMethodID
                                        iOrderType_ID = 1
                                    End If
                                End If
                            Case PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Freds_CUSTOMER_ID
                                If iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iSaiaCarrierLTLShipMethodID Then 'Saia Freight
                                    'do nothing, just use Saia carrier
                                Else
                                    iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iFredsBulkCarrierShipMethodID ' Fedex Freight
                                End If
                                iOrderType_ID = 2
                            Case PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Frys_CUSTOMER_ID
                                iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iFrysRegularCarrierShipMethodID
                                iOrderType_ID = 1
                            Case Else
                                iShipCarrier_ID = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iOtherCustomerCarrierShipMethodID
                                iOrderType_ID = 1
                        End Select

                        If strSoHeaderIDs.Trim.Length = 0 Then
                            strSoHeaderIDs = iSoheaderID.ToString
                        Else
                            strSoHeaderIDs &= "," & iSoheaderID.ToString
                        End If

                        strSql_Two &= " WHEN '" & iSoheaderID.ToString & "' THEN " & iShipCarrier_ID.ToString
                        strSql_Four &= " WHEN '" & iSoheaderID.ToString & "' THEN " & iOrderType_ID.ToString
                    Next
                    strSql &= strSql_One & strSql_Two & " END," & strSql_Three & strSql_Four & " END"
                    strSql &= " WHERE SoHeaderID IN (" & strSoHeaderIDs & ");" & Environment.NewLine

                    'objTFFK = Nothing
                End If

                'Updated ShipMethod and OrderType
                iUpdated = Me._objDataProc.ExecuteNonQuery(strSql)

                'If iUpdated > 0 Then
                '    dt = Me._objDataProc.GetDataTable(strSql)
                'End If

                Return iUpdated

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPickData() As DataTable
            Dim strSql As String = "", strSql_Two As String = "", strSql_Three As String = ""
            Dim dt, dt_Two As DataTable
            Dim row, row2 As DataRow
            Dim i As Integer = 0
            Dim strSoHeaderIDs As String = ""
            Dim iCurrentNumberOfOrdersPerGroup As Integer = 0
            Dim iGroupOrderNoLimit As Integer = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerGroupOrderNumberLimit
            Dim iHowManyGroups As Integer = 0
            Dim bNeedSplitGroup As Boolean = False

            Try
                'strSql = "SELECT 'CL70079220-101' as 'PickID','DOLLAR GENERAL #00107' as 'Customer','UPSGR' as 'Ship Method'" & Environment.NewLine
                'strSql &= " ,'3/05/2018' as 'Req. Ship', '70079220' as 'OrderNo', 2 as 'No. Item',10 as 'Total'" & Environment.NewLine
                'strSql &= " ,1614 as 'Cust_ID',3597 as 'Loc_ID', 0 as 'RecID'" & Environment.NewLine
                'strSql &= " UNION" & Environment.NewLine
                'strSql &= " SELECT 'CL70078888-200' as 'PickID','FAMILY DOLLAR' as 'Customer','FEDGR' as 'Ship Method'" & Environment.NewLine
                'strSql &= " ,'3/06/2018' as 'Req. Ship', '70078888' as 'OrderNo', 3 as 'No. Item',12 as 'Total'" & Environment.NewLine
                'strSql &= " , 2611 as 'Cust_ID',3476 as 'Loc_ID', 0 as 'RecID'" & Environment.NewLine
                'strSql &= " UNION" & Environment.NewLine
                'strSql &= " SELECT 'CL71239997-333' as 'PickID','Amazon 1018' as 'Customer','FEDGR' as 'Ship Method'" & Environment.NewLine
                'strSql &= " ,'3/06/2018' as 'Req. Ship', '71239997' as 'OrderNo', 1 as 'No. Item',5 as 'Total'" & Environment.NewLine
                'strSql &= " ,2609 as 'Cust_ID',3476 as 'Loc_ID', 0 as 'RecID';" & Environment.NewLine

                'strSql = "SELECT A.PickRunNo as 'PickID', A.CustomerFirstName as 'Customer',A.ShipCarrier as 'Ship Method', A.ExpectedDeliveryDate as 'Req. Ship'" & Environment.NewLine
                'strSql &= " ,A.PoNumber as 'OrderNo'  ,Count(*) as 'No. Item',SUM(B.Quantity) as 'Total', A.Cust_ID,C.Loc_ID,A.SoheaderID" & Environment.NewLine
                'strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                'strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                'strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                'strSql &= " GROUP BY OrderNo,Customer;" & Environment.NewLine

                'New
                'strSql = "SELECT '' as 'PickID', D.Cust_Name1 as 'Customer',E.ShipMethod_Sdesc as 'Ship Method', A.ExpectedDeliveryDate as 'Req. Ship'" & Environment.NewLine
                'strSql &= " ,COUNT(DISTINCT(A.PoNumber)) as 'No. Order',SUM(B.Quantity) as 'No. Item',0 as 'PickIDKey'" & Environment.NewLine
                'strSql &= " ,GROUP_CONCAT(DISTINCT(CONVERT(A.PoNumber, char)) SEPARATOR ',') as 'OrderNumbers'" & Environment.NewLine
                'strSql &= " ,GROUP_CONCAT(DISTINCT(CONVERT(A.SoHeaderID, char)) SEPARATOR ',') as 'SoHeaderIDs'" & Environment.NewLine
                'strSql &= " ,GROUP_CONCAT(CONVERT(B.SoDetailsID, char) SEPARATOR ',') as 'SoDetailsIDs'" & Environment.NewLine
                'strSql &= " ,IF(A.PriorityExpedite=1, 'Yes','No') as 'IsPriorityExpedite', A.PriorityExpedite" & Environment.NewLine
                'strSql &= " ,A.OrderQty,B.Quantity" & Environment.NewLine
                'strSql &= " ,B.ItemCode,F.Model_Desc,F.Weight" & Environment.NewLine
                'strSql &= " ,A.ShipCarrier_ID,A.Cust_ID" & Environment.NewLine
                'strSql &= " ,CONCAT_WS('_',A.PriorityExpedite,A.Cust_ID,A.ShipCarrier_ID,DATE_FORMAT('2017-06-15 00:00:00', '%Y-%m-%d')) as 'NewKey'" & Environment.NewLine
                'strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                'strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                'strSql &= " INNER JOIN production.tcustomer D ON A.Cust_ID=D.Cust_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN saleorders.ShipCarriers E ON A.ShipCarrier_ID=E.ShipCarrier_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN production.tmodel_items F ON B.Model_ID=F.Model_ID" & Environment.NewLine
                'strSql &= " LEFT JOIN saleorders.Shiptype G ON A.OrderType_ID=G.OrderType_ID" & Environment.NewLine
                'strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                'strSql &= " GROUP BY A.PriorityExpedite,D.Cust_Name1,E.ShipMethod_Sdesc, A.ExpectedDeliveryDate" & Environment.NewLine
                'strSql &= " ORDER BY A.PriorityExpedite DESC,A.ExpectedDeliveryDate ASC;" & Environment.NewLine

                strSql = "SELECT '' as 'PickID', D.Cust_Name1 as 'Customer',E.ShipMethod_Sdesc as 'Ship Method', DATE_FORMAT(A.ExpectedDeliveryDate, '%Y-%m-%d') as 'Req. Ship'" & Environment.NewLine
                strSql &= " ,COUNT(DISTINCT(A.PoNumber)) as 'No. Order',SUM(B.Quantity) as 'No. Item',A.OrderGroupClass,0 as 'PickIDKey'" & Environment.NewLine
                strSql &= " ,GROUP_CONCAT(DISTINCT(CONVERT(A.PoNumber, char)) SEPARATOR ',') as 'OrderNumbers'" & Environment.NewLine
                strSql &= " ,GROUP_CONCAT(DISTINCT(CONVERT(A.SoHeaderID, char)) SEPARATOR ',') as 'SoHeaderIDs'" & Environment.NewLine
                strSql &= " ,GROUP_CONCAT(CONVERT(B.SoDetailsID, char) SEPARATOR ',') as 'SoDetailsIDs'" & Environment.NewLine
                strSql &= " ,IF(A.PriorityExpedite=1, 'Yes','No') as 'IsPriorityExpedite', A.PriorityExpedite" & Environment.NewLine
                strSql &= " ,A.ShipCarrier_ID,A.Cust_ID" & Environment.NewLine
                strSql &= " ,CONCAT_WS('_',A.OrderGroupClass,A.PriorityExpedite,A.Cust_ID,A.ShipCarrier_ID,DATE_FORMAT(A.ExpectedDeliveryDate, '%Y-%m-%d')) as 'NewKey'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tworkorder C ON A.WorkOrderID=C.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcustomer D ON A.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " LEFT JOIN saleorders.ShipCarriers E ON A.ShipCarrier_ID=E.ShipCarrier_ID" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel_items F ON B.Model_ID=F.Model_ID" & Environment.NewLine
                strSql &= " LEFT JOIN saleorders.Shiptype G ON A.OrderType_ID=G.OrderType_ID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                strSql &= " GROUP BY A.PriorityExpedite,D.Cust_Name1,E.ShipMethod_Sdesc, A.ExpectedDeliveryDate,A.OrderGroupClass ASC" & Environment.NewLine
                strSql &= " ORDER BY A.PriorityExpedite DESC,A.ExpectedDeliveryDate ASC,A.OrderGroupClass ASC;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each row In dt.Rows
                        iCurrentNumberOfOrdersPerGroup = Convert.ToInt32(row("No. Order"))
                        strSoHeaderIDs = Trim(row("SoHeaderIDs")).ToString

                        If iCurrentNumberOfOrdersPerGroup > iGroupOrderNoLimit Then 'need to split group
                            iHowManyGroups = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.ComputeGroups(iCurrentNumberOfOrdersPerGroup, iGroupOrderNoLimit)
                            If iHowManyGroups > 1 Then 'Need regroup it
                                Dim strTmpSoHeadIDs As String = ""
                                Dim iOrderGroupClass As Integer = 0
                                Dim k As Integer = 0
                                strSql_Two = "SELECT SoHeaderID,PoNumber,OrderGroupClass FROM saleorders.SoHeader WHERE SoHeaderID in (" & strSoHeaderIDs & ");"
                                dt_Two = Me._objDataProc.GetDataTable(strSql_Two)
                                i = 0

                                For Each row2 In dt_Two.Rows
                                    If strTmpSoHeadIDs.Trim.Length = 0 Then
                                        strTmpSoHeadIDs = Convert.ToInt32(row2("SoHeaderID")).ToString
                                    Else
                                        strTmpSoHeadIDs &= "," & Convert.ToInt32(row2("SoHeaderID")).ToString
                                    End If
                                    i += 1 : k += 1
                                    If i >= iGroupOrderNoLimit Then
                                        iOrderGroupClass += 1
                                        strSql_Three = "UPDATE saleorders.SoHeader  SET OrderGroupClass=" & iOrderGroupClass & " WHERE SoHeaderID in (" & strTmpSoHeadIDs & ");"
                                        Me._objDataProc.ExecuteNonQuery(strSql_Three)
                                        strTmpSoHeadIDs = "" : i = 0
                                    ElseIf k >= dt_Two.Rows.Count Then
                                        iOrderGroupClass += 1
                                        strSql_Three = "UPDATE saleorders.SoHeader  SET OrderGroupClass=" & iOrderGroupClass & " WHERE SoHeaderID in (" & strTmpSoHeadIDs & ");"
                                        Me._objDataProc.ExecuteNonQuery(strSql_Three)
                                        Exit For
                                    End If
                                Next
                                bNeedSplitGroup = True
                            End If
                        End If
                    Next
                End If

                If bNeedSplitGroup Then dt = Me._objDataProc.GetDataTable(strSql) 'Rerun after regrouped

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPickIDs(ByVal iHowManyPickIDs As Integer, ByVal iUser_ID As Integer, ByVal strDatetime As String) As DataTable
            Dim dt As New DataTable()
            Dim i As Integer
            Dim strSql As String = ""
            Dim iPickRunID As Integer = 0
            Dim strPickIDs As String = ""

            Try

                If iHowManyPickIDs > 0 Then
                    For i = 0 To iHowManyPickIDs - 1
                        strSql = "INSERT INTO  saleorders.tpickruns (User_ID, Updated_Datetime)"
                        strSql &= "VALUES (" & iUser_ID & ",'" & strDatetime & "');"

                        iPickRunID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "saleorders.tpickruns")

                        If strPickIDs.Trim.Length = 0 Then
                            strPickIDs = iPickRunID.ToString
                        Else
                            strPickIDs &= "," & iPickRunID.ToString
                        End If
                        ' strPickID = "PK" & iPickRunID.ToString.PadLeft(10, "0")
                        'number.ToString().PadLeft(2, '0')
                    Next
                    strSql = "SELECT PickRun_ID, PickRun_Name FROM saleorders.tpickruns WHERE PickRun_ID in (" & strPickIDs & ");"
                    dt = Me._objDataProc.GetDataTable(strSql)

                End If


                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getPickTicketData(ByVal iSoHeaderID As Integer) As DataTable '(ByVal RecID As Integer) As DataTable
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim i As Integer = 0

        '    Try
        '        'Select Case RecID
        '        '    Case 1
        '        '        strSql = "SELECT 'CL70079220-101' as 'PickNo','70079220' as 'OrderNo', 'DOLLAR GENERAL #00107' as 'Customer',CONVERT(1614,char) as 'CustomerNo'" & Environment.NewLine
        '        '        strSql &= " ,'TFZEZ797CPAPNKEV' as 'Item', 'A-05' as 'Location',5 as 'Qty'" & Environment.NewLine
        '        '        strSql &= " UNION" & Environment.NewLine
        '        '        strSql &= " SELECT 'CL70079220-101' as 'PickNo','70079220' as 'OrderNo', 'DOLLAR GENERAL #00107' as 'Customer',CONVERT(1614,char) as 'CustomerNo'" & Environment.NewLine
        '        '        strSql &= " ,'SMZEZ232TGGYDG' as 'Item', 'B-03' as 'Location',5 as 'Qty';" & Environment.NewLine

        '        '    Case 2
        '        '        strSql = "SELECT 'CL70078888-200' as 'PickNo','70078888' as 'OrderNo', 'FAMILY DOLLAR' as 'Customer',CONVERT(2611,char) as 'CustomerNo'" & Environment.NewLine
        '        '        strSql &= " ,'TFZEZ797CPAPNKEV' as 'Item', 'A-01' as 'Location',5 as 'Qty'" & Environment.NewLine
        '        '        strSql &= " UNION" & Environment.NewLine
        '        '        strSql &= " SELECT 'CL70078888-200' as 'PickNo','70078888' as ' OrderNo', 'FAMILY DOLLAR' as 'Customer',CONVERT(2611,char) as 'CustomerNo'" & Environment.NewLine
        '        '        strSql &= " ,'SMZEZ232TGGYDG' as 'Item', 'A-02' as 'Location',4 as 'Qty'" & Environment.NewLine
        '        '        strSql &= " UNION" & Environment.NewLine
        '        '        strSql &= " SELECT 'CL70078888-200' as 'PickNo','70078888' as 'OrderNo', 'FAMILY DOLLAR' as 'Customer',CONVERT(2611,char) as 'CustomerNo'" & Environment.NewLine
        '        '        strSql &= " ,'TFZEZ797CPAPONB' as 'Item', 'A-03' as 'Location',3 as 'Qty';" & Environment.NewLine

        '        '    Case 3
        '        '        strSql = "SELECT 'CL71239997-333' as 'PickNo','71239997' as 'OrderNo', 'Amazon 1018' as 'Customer',CONVERT(2690,char) as 'CustomerNo'" & Environment.NewLine
        '        '        strSql &= " ,'TFZEZ797CPAPONB' as 'Item', 'C-03' as 'Location',5 as 'Qty';" & Environment.NewLine

        '        'End Select
        '        strSql = "SELECT A.PickRunNo as 'PickNo',A.PoNumber as 'OrderNo',A.CustomerFirstName as 'Customer',CAST(A.Cust_ID as CHAR) as 'CustomerNo',B.ItemCode as 'Item'" & Environment.NewLine
        '        strSql &= " ,CONCAT(C.LocRow,IF(length(C.LocCol)<2,LPAD(C.LocCol,2,'0'),C.LocCol)) as 'Location',B.Quantity as 'Qty', A.SoheaderID,B.Model_ID,B.SoDetailsID" & Environment.NewLine
        '        strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
        '        strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
        '        strSql &= " LEFT JOIN saleorders.tpicklocationmatrix C ON B.Model_ID=C.Model_ID" & Environment.NewLine
        '        strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting' AND A.SoHeaderID=" & iSoHeaderID
        '        strSql &= " Order BY SoDetailsID;" & Environment.NewLine

        '        dt = Me._objDataProc.GetDataTable(strSql)

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getPickTicketData(ByVal iNoOfOrders As Integer, ByVal iSoHeaderIDs As String, ByVal strPickID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                'strSql = "SELECT A.PickRunNo as 'PickNo',A.PoNumber as 'OrderNo',A.CustomerFirstName as 'Customer',CAST(A.Cust_ID as CHAR) as 'CustomerNo',B.ItemCode as 'Item'" & Environment.NewLine
                'strSql &= " ,CONCAT(C.LocRow,IF(length(C.LocCol)<2,LPAD(C.LocCol,2,'0'),C.LocCol)) as 'Location',B.Quantity as 'Qty', A.SoheaderID,B.Model_ID,B.SoDetailsID" & Environment.NewLine
                'strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                'strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                'strSql &= " LEFT JOIN saleorders.tpicklocationmatrix C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                'strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting' AND A.SoHeaderID=" & iSoHeaderID
                'strSql &= " Order BY SoDetailsID;" & Environment.NewLine

                strSql = "SELECT '" & strPickID & "' as 'PickNo'"
                If iNoOfOrders = 1 Then
                    strSql &= ",A.PoNumber as 'OrderNo'"
                Else
                    strSql &= ",'' as 'OrderNo'"
                End If
                strSql &= ",D.Cust_Name1 as 'Customer',CAST(A.Cust_ID as CHAR) as 'CustomerNo',B.ItemCode as 'Item'" & Environment.NewLine
                strSql &= " ,CONCAT(C.LocRow,IF(length(C.LocCol)<2,LPAD(C.LocCol,2,'0'),C.LocCol)) as 'Location',Sum(B.Quantity) as 'Qty'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tcustomer D ON A.Cust_ID=D.Cust_ID" & Environment.NewLine
                strSql &= " LEFT JOIN saleorders.tpicklocationmatrix C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting' AND A.SoHeaderID in (" & iSoHeaderIDs & ")" & Environment.NewLine
                strSql &= " GROUP BY OrderNo,D.Cust_Name1,B.ItemCode,Location" & Environment.NewLine
                strSql &= " Order BY SoDetailsID;" & Environment.NewLine


                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOrderForShipData(ByVal iSoHeaderIDs As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strCustomerName As String = ""
            Dim strAddress2 As String = ""

            Try
                'CustomerName, Address2, SOHeaderID, Cust_ID, CustomerFirstName, CustomerLastName, CustomerAdditionalName1, 
                'CustomerAdditionalName2, CustomerAddress1, CustomerAddress2, CustomerAddress3, CustomerCity, 
                'CustomerState, CustomerPostalCode, CustomerCountry, CustomerPhone, OrderQty, PONumber, PODate, ExpectedDeliveryDate, 
                'CustomerOrderNumber, OrderGroupClass, PriorityExpedite, ShipCarrier_ID, WorkOrderID, ClientCustomerOrder, CustomerEmail, 
                'CustomerOrderDate, PickRunNo, OrderSubtotal, OrderDiscount, OrderTax1, OrderTax2, OrderTax3, BillCode_ID, OrderShipmentCharge, Workstation, 
                'Workstation_PickUserID, Workstation_PickDatetime, Workstation_PackUserID, Workstation_PackDatetime, ShipDate, ShipUserID, Exception_Type_ID, 
                'TransmitDate, ReceiptTimestamp, InvalidOrder, InvalidOrder_UserID, ReasonOrderInvalid, InvalidOrder_DateTime, OrderReturned, OrderReturned_Input, 
                'OrderReturned_DateTime, OrderReturned_UserID, OrderStatusID, InputErrormessage, InputErrorMessageSent, OutputErrorMessage, OutputErrorMessageSent, 
                'InboundTrackingNumber, OutboundTrackingNumber, TransactionDatetime, TransactionID, ShipPackageWeight, DeliveryStatus, Delivered_Or_Expected_Date_Note, 
                'DeliveryStatusNote, DeliveryStatusUpdateDateTime, DeliveryStatusUpdateSessionTime, OutboundXMLFile, BillTo_Name, BillTo_Address1, BillTo_Address2, 
                'BillTo_Address3, BillTo_City, BillTo_State, BillTo_PostalCode, BillTo_Country, BillTo_Phone, Message, FreightPaymentMethodCode, CarrierSCACCode, 
                'EDI_FileName, ShipCarrier, FishBowlOrderID, FishBowlCustomerName, LaborCharge, OrderCreatedByUsrID, OrderCreatedDate, EDI_REF_ZZ, EDI_ISA_CtrlNo, 
                'OrderType, OrderType_ID, IsPreKit, cust_created_at, cust_updated_at, cust_status, cust_type, data_method, Order_Recv1_Ack2, Order_Cancel1_Ack2, 
                'Order_Cancellation_DateTime, Order_RejectAck1, Order_InTransitAck1, Order_InTransit10DayAck1, Order_DeliveredAck1, Order_ReturnedAck1, iDataSet_ID)

                strSql = "SELECT '' as 'CustomerName','' as Address2,A.*   from saleorders.SoHeader A WHERE A.SoHeaderID in (" & iSoHeaderIDs & ");"

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    If Not row.IsNull("CustomerFirstName") AndAlso Trim(row("CustomerFirstName")).Length > 0 Then
                        strCustomerName = Trim(row("CustomerFirstName"))
                    End If

                    If Not row.IsNull("CustomerLastName") AndAlso Trim(row("CustomerLastName")).Length > 0 Then
                        If strCustomerName.Trim.Length = 0 Then
                            strCustomerName = Trim(row("CustomerLastName"))
                        Else
                            strCustomerName &= " " & Trim(row("CustomerLastName"))
                        End If
                    End If

                    If Not row.IsNull("CustomerAdditionalName1") AndAlso Trim(row("CustomerAdditionalName1")).Length > 0 Then
                        If strCustomerName.Trim.Length = 0 Then
                            strCustomerName = Trim(row("CustomerAdditionalName1"))
                        Else
                            strCustomerName &= " " & Trim(row("CustomerAdditionalName1"))
                        End If
                    End If

                    If Not row.IsNull("CustomerAdditionalName2") AndAlso Trim(row("CustomerAdditionalName2")).Length > 0 Then
                        If strCustomerName.Trim.Length = 0 Then
                            strCustomerName = Trim(row("CustomerAdditionalName2"))
                        Else
                            strCustomerName &= " " & Trim(row("CustomerAdditionalName2"))
                        End If
                    End If

                    row.BeginEdit() : row("CustomerName") = strCustomerName : row.AcceptChanges()

                    If Not row.IsNull("CustomerAddress2") AndAlso Trim(row("CustomerAddress2")).Length > 0 Then
                        If strCustomerName.Trim.Length = 0 Then
                            strAddress2 = Trim(row("CustomerAddress2"))
                        Else
                            strAddress2 &= ", " & Trim(row("CustomerAddress2"))
                        End If
                    End If
                    If Not row.IsNull("CustomerAddress3") AndAlso Trim(row("CustomerAddress3")).Length > 0 Then
                        If strCustomerName.Trim.Length = 0 Then
                            strAddress2 = Trim(row("CustomerAddress3"))
                        Else
                            strAddress2 &= ", " & Trim(row("CustomerAddress3"))
                        End If
                    End If

                    row.BeginEdit() : row("Address2") = strAddress2 : row.AcceptChanges()
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOrderDetailsData(ByVal iSoHeaderIDs As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strCustomerName As String = ""

            Try
                strSql = "SELECT * from saleorders.SoDetails A WHERE SoHeaderID in (" & iSoHeaderIDs & ");"
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOrderItemTotalCount(ByVal iSoHeaderID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim iRet As Integer = 0


            Try
                strSql = "SELECT SUM(quantity) as 'qty' from saleorders.SoDetails A WHERE SoHeaderID =" & iSoHeaderID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRet = dt.Rows(0).Item("qty")
                End If
                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function AreMeijerNonBulkOrderDataValid(ByVal iSoHeaderID As Integer, _
                                                       ByVal iPerBoxItemNumber As Integer, _
                                                       ByRef iOrderTotalQty As Integer, _
                                                       ByRef strMsg As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim bRet As Boolean = False
            Dim iQty As Integer = 0
            Dim strS As String = ""


            Try
                strMsg = "" : iOrderTotalQty = 0
                strSql = "SELECT SUM(quantity) as 'qty' from saleorders.SoDetails A WHERE SoHeaderID =" & iSoHeaderID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iOrderTotalQty = dt.Rows(0).Item("qty")
                    If iOrderTotalQty > 0 Then
                        strSql = "select IF(A.Quantity>0 AND MOD(A.Quantity," & iPerBoxItemNumber & ")=0,'Yes','No') as 'IsValid',A.Quantity/" & iPerBoxItemNumber & " as 'BoxNumber',A.*" & Environment.NewLine
                        strSql &= " from saleorders.Sodetails A where SoHeaderID =" & iSoHeaderID & Environment.NewLine
                        strSql &= " Order by LineItemNumber;" & Environment.NewLine

                        dt = Me._objDataProc.GetDataTable(strSql)
                        If dt.Rows.Count > 0 Then
                            For Each row In dt.Rows
                                strS = row("IsValid")
                                If strS.Trim.ToUpper = "No".ToUpper Then
                                    bRet = False
                                    strMsg = "No detail data for this order (SoHeaderID=" & iSoHeaderID & ")."
                                    Exit For
                                Else
                                    bRet = True
                                End If
                            Next
                        Else
                            bRet = False
                            strMsg = "No detail data for this order (SoHeaderID=" & iSoHeaderID & ")."
                        End If
                    Else
                        bRet = False
                        strMsg = "total qty of the order can't be zero (SoHeaderID=" & iSoHeaderID & ")."
                    End If
                Else
                        bRet = False
                        strMsg = "No qty for this order (SoHeaderID=" & iSoHeaderID & ")."
                End If

                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getCustomterName(ByVal iCust_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try
                'Cust_ID, Cust_Name1, Cust_Name2, Cust_Name3, Cust_Inactive, Cust_InvoiceDetail, PlusParts, Cust_FlatRateParts, Cust_AutoShip, Cust_Stage, Cust_Pallett, Cust_RejectDays, Cust_RejectTimes, Cust_RepairNonWrty, Cust_ReplaceLCD, Cust_HSTech, Cust_SpecialCodes, Cust_CrApproveRec, Cust_CrApproveShip, Cust_CollSalesTax, Cust_Memo, Cust_ConsignedParts, BizType_ID, Pay_ID, PCo_ID, SlsP_ID, Cust_lvlShipCust, Cust_RecRcncl, Cust_PalletShip, Cust_AggBilling, Cust_AutoBill, Cust_CrBilling, InvDateType_ID, PredeterminePartNeed, DepartmentID, ReqAQLCheckOnAllUnit, LastUpdateDT, LastUpdateUserID, TAT, TechFailureCode, ReqOutboundTracking
                strSql = "SELECT * FROM tcustomer WHERE Cust_ID=" & iCust_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strRet = dt.Rows(0).Item("Cust_Name1")
                End If
                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getBoxLabelNames_MeijerNonBulk(ByVal iHowManyBoxes As Integer, ByVal iSoheaderID As Integer, _
                                                       ByVal iUserID As Integer, ByVal strDateTime As String, _
                                                       ByRef bBoxCreated As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As New DataTable()
            Dim dt1 As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim iKey As Integer = 0
            Dim strKeys As String = ""
            Dim iBoxQty As Integer = 0, iOrderQty As Integer = 0
            Dim vBoxWeight As Single = 0.0
            Dim vPhoneWeight As Single = 0.0
            Dim iSumBoxQty As Integer = 0
            Dim iPreviousQty As Integer = 0
            Dim iBoxWeightRoundUp As Integer = 0
            Dim iHowManyBoxesPerItem As Integer = 0
            Dim iSoDetailsID As Integer = 0

            'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, IsCompleted, User_ID, UpdateDateTime
            Try
                'Merjer has one model alway. Not true. It has multiple models with 0 reminder of qty/3 for each model
                strSql = "SELECT B.Weight,FLOOR(A.Quantity/" & PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber & ") as 'ItemBoxNumber',A.*  from saleorders.SoDetails A" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel_items B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE SoHeaderID = " & iSoheaderID & Environment.NewLine
                strSql &= " Order by LineItemNumber;" & Environment.NewLine

                dt1 = Me._objDataProc.GetDataTable(strSql)

                'check total box qty matches
                For Each row In dt1.Rows
                    iSumBoxQty += Convert.ToInt32(row("ItemBoxNumber"))
                Next
                If Not iSumBoxQty = iHowManyBoxes Then
                    bBoxCreated = False
                    Return dt
                End If

                'Creat box
                For Each row In dt1.Rows 'for each item of the order
                    iOrderQty = Convert.ToInt32(row("Quantity"))
                    vPhoneWeight = Convert.ToSingle(row("Weight"))
                    iSoDetailsID = Convert.ToSingle(row("SoDetailsID"))

                    iHowManyBoxesPerItem = Convert.ToInt32(row("ItemBoxNumber"))
                    For i = 1 To iHowManyBoxesPerItem 'for each box
                        iBoxQty = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber
                        vBoxWeight = iBoxQty * vPhoneWeight
                        iBoxWeightRoundUp = Math.Ceiling(vBoxWeight)

                        strSql = "INSERT INTO saleorders.tpickboxshiplabel (BoxQty,BoxWeightRoundUp,BoxWeight,SoHeaderID,SoDetailsID,User_ID,UpdateDateTime)"
                        strSql &= " Values (" & iBoxQty & "," & iBoxWeightRoundUp & "," & vBoxWeight & "," & iSoheaderID & "," & iSoDetailsID & "," & iUserID & ",'" & strDateTime & "');"
                        iKey = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "saleorders.tpickboxshiplabel")
                        If strKeys.Trim.Length = 0 Then
                            strKeys = iKey.ToString
                        Else
                            strKeys &= "," & iKey.ToString
                        End If
                    Next
                Next

                If strKeys.Trim.Length > 0 Then
                    strSql = "SELECT * from saleorders.tpickboxshiplabel where PSSI_label_ID in (" & strKeys & ");"
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                If dt.Rows.Count > 0 AndAlso dt.Rows.Count = iHowManyBoxes Then
                    bBoxCreated = True
                Else
                    bBoxCreated = False
                End If

                Return dt

                'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, SoDetailsID, IsCompleted, User_ID, UpdateDateTime

                'iOrderQty = Convert.ToInt32(dt1.Rows(0).Item("Quantity"))
                'vPhoneWeight = Convert.ToSingle(dt1.Rows(0).Item("Weight"))

                'strSql = "Select * from saleorders.SoHeader where SOheaderID= " & iSoheaderID & ";"
                'dt1 = Me._objDataProc.GetDataTable(strSql)

                'For i = 1 To iHowManyBoxes
                '    If iHowManyBoxes = 1 Then
                '        iBoxQty = iOrderQty
                '        vBoxWeight = iBoxQty * vPhoneWeight
                '    Else
                '        iBoxQty = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber
                '        vBoxWeight = iBoxQty * vPhoneWeight
                '        iSumBoxQty += iBoxQty
                '        If iSumBoxQty > iOrderQty Then
                '            iBoxQty = iOrderQty - iPreviousQty
                '            vBoxWeight = iBoxQty * vPhoneWeight
                '        End If
                '        iPreviousQty += iBoxQty
                '    End If

                '    iBoxWeightRoundUp = Math.Ceiling(vBoxWeight)

                '    strSql = "INSERT INTO saleorders.tpickboxshiplabel (BoxQty,BoxWeightRoundUp,BoxWeight,SoHeaderID,User_ID,UpdateDateTime)"
                '    strSql &= " Values (" & iBoxQty & "," & iBoxWeightRoundUp & "," & vBoxWeight & "," & iSoheaderID & "," & iUserID & ",'" & strDateTime & "');"
                '    iKey = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "saleorders.tpickboxshiplabel")
                '    If strKeys.Trim.Length = 0 Then
                '        strKeys = iKey.ToString
                '    Else
                '        strKeys &= "," & iKey.ToString
                '    End If
                'Next
                'If strKeys.Trim.Length > 0 Then
                '    strSql = "SELECT * from saleorders.tpickboxshiplabel where PSSI_label_ID in (" & strKeys & ");"
                '    dt = Me._objDataProc.GetDataTable(strSql)
                'End If
                'Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getBoxLabelNames(ByVal iHowManyBoxes As Integer, ByVal iSoheaderID As Integer, _
                                         ByVal iUserID As Integer, ByVal strDateTime As String) As DataTable
            Dim strSql As String = ""
            Dim dt As New DataTable()
            Dim dt1 As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim iKey As Integer = 0
            Dim strKeys As String = ""
            Dim iBoxQty As Integer = 0, iOrderQty As Integer = 0
            Dim vBoxWeight As Single = 0.0
            Dim vPhoneWeight As Single = 0.0
            Dim iSumBoxQty As Integer = 0
            Dim iPreviousQty As Integer = 0
            Dim iBoxWeightRoundUp As Integer = 0

            'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, IsCompleted, User_ID, UpdateDateTime
            Try
                'order has one model alway
                strSql = "SELECT B.Weight,A.*  from saleorders.SoDetails A" & Environment.NewLine
                strSql &= " LEFT JOIN production.tmodel_items B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE SoHeaderID =" & iSoheaderID & ";" & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)
                iOrderQty = Convert.ToInt32(dt1.Rows(0).Item("Quantity"))
                vPhoneWeight = Convert.ToSingle(dt1.Rows(0).Item("Weight"))

                strSql = "Select * from saleorders.SoHeader where SOheaderID= " & iSoheaderID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For i = 1 To iHowManyBoxes
                    If iHowManyBoxes = 1 Then
                        iBoxQty = iOrderQty
                        vBoxWeight = iBoxQty * vPhoneWeight
                    Else
                        iBoxQty = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iPerBoxItemNumber
                        vBoxWeight = iBoxQty * vPhoneWeight
                        iSumBoxQty += iBoxQty
                        If iSumBoxQty > iOrderQty Then
                            iBoxQty = iOrderQty - iPreviousQty
                            vBoxWeight = iBoxQty * vPhoneWeight
                        End If
                        iPreviousQty += iBoxQty
                    End If

                    iBoxWeightRoundUp = Math.Ceiling(vBoxWeight)

                    strSql = "INSERT INTO saleorders.tpickboxshiplabel (BoxQty,BoxWeightRoundUp,BoxWeight,SoHeaderID,User_ID,UpdateDateTime)"
                    strSql &= " Values (" & iBoxQty & "," & iBoxWeightRoundUp & "," & vBoxWeight & "," & iSoheaderID & "," & iUserID & ",'" & strDateTime & "');"
                    iKey = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "saleorders.tpickboxshiplabel")
                    If strKeys.Trim.Length = 0 Then
                        strKeys = iKey.ToString
                    Else
                        strKeys &= "," & iKey.ToString
                    End If
                Next
                If strKeys.Trim.Length > 0 Then
                    strSql = "SELECT * from saleorders.tpickboxshiplabel where PSSI_label_ID in (" & strKeys & ");"
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getBoxLabelNames_Bulk(ByVal iHowManyBoxes As Integer, ByVal iSoheaderID As Integer, _
        '                                      ByVal iUserID As Integer, ByVal strDateTime As String) As DataTable
        '    'Merjer,Fred's bulk
        '    Dim strSql As String = ""
        '    Dim dt As New DataTable()
        '    Dim dt1 As DataTable
        '    Dim row As DataRow
        '    Dim i As Integer = 0
        '    Dim iKey As Integer = 0
        '    Dim strKeys As String = ""
        '    Dim iBoxQty As Integer = 0, iOrderQty As Integer = 0
        '    Dim vBoxWeight As Single = 0.0
        '    Dim vPhoneWeight As Single = 0.0
        '    Dim iSumBoxQty As Integer = 0
        '    Dim iPreviousQty As Integer = 0
        '    Dim iBoxWeightRoundUp As Integer = 0

        '    'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, IsCompleted, User_ID, UpdateDateTime
        '    Try

        '        strSql = "INSERT INTO saleorders.tpickboxshiplabel (BoxQty,BoxWeightRoundUp,BoxWeight,SoHeaderID,User_ID,UpdateDateTime)"
        '        strSql &= " Values (" & iBoxQty & "," & iBoxWeightRoundUp & "," & vBoxWeight & "," & iSoheaderID & "," & iUserID & ",'" & strDateTime & "');"
        '        iKey = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "saleorders.tpickboxshiplabel")
        '        If strKeys.Trim.Length = 0 Then
        '            strKeys = iKey.ToString
        '        Else
        '            strKeys &= "," & iKey.ToString
        '        End If

        '        If strKeys.Trim.Length > 0 Then
        '            strSql = "SELECT * from saleorders.tpickboxshiplabel where PSSI_label_ID in (" & strKeys & ");"
        '            dt = Me._objDataProc.GetDataTable(strSql)
        '        End If
        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getBoxLabelNames_Bulk(ByVal iHowManyBoxes As Integer, ByVal iSoheaderID As Integer, _
                                              ByVal iUserID As Integer, ByVal strDateTime As String) As DataTable
            'Fry's Bulk, may be Multiple items 
            Dim strSql As String = "", strSql_Two As String = ""
            Dim dt As New DataTable()
            Dim dt1 As DataTable
            Dim row As DataRow
            Dim i As Integer = 0
            Dim iKey As Integer = 0
            'Dim strKeys As String = ""
            'Dim iBoxQty As Integer = 0, iOrderQty As Integer = 0
            'Dim vBoxWeight As Single = 0.0
            'Dim vPhoneWeight As Single = 0.0
            'Dim iSumBoxQty As Integer = 0
            'Dim iPreviousQty As Integer = 0
            'Dim iBoxWeightRoundUp As Integer = 0

            'PSSI_label_ID, PSSI_Boxlabel_Name, BoxQty, BoxWeightRoundUp, BoxWeight, SoHeaderID, IsCompleted, User_ID, UpdateDateTime
            Try

                strSql = "SELECT SUM(A.Quantity) as 'BoxQty', CEILING(SUM(A.Quantity*B.Weight)) as 'BoxWeightRoundUp',SUM(A.Quantity*B.Weight) as 'BoxWeight'" & Environment.NewLine
                strSql &= "," & iSoheaderID.ToString & " as 'SoHeaderID'," & iUserID.ToString & " as 'User_ID','" & strDateTime & "' as 'UpdateDateTime'"
                strSql &= " FROM saleorders.SoDetails A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_Items B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE SoheaderID =" & iSoheaderID
                ' dt = Me._objDataProc.GetDataTable(strSql)


                strSql_Two = "INSERT INTO saleorders.tpickboxshiplabel (BoxQty,BoxWeightRoundUp,BoxWeight,SoHeaderID,User_ID,UpdateDateTime)"
                strSql_Two &= strSql

                'strSql &= " Values (" & iBoxQty & "," & iBoxWeightRoundUp & "," & vBoxWeight & "," & iSoheaderID & "," & iUserID & ",'" & strDateTime & "');"
                iKey = Me._objDataProc.GetLastInsertedPrimaryKey(strSql_Two, "saleorders.tpickboxshiplabel")

                'If strKeys.Trim.Length = 0 Then
                '    strKeys = iKey.ToString
                'Else
                '    strKeys &= "," & iKey.ToString
                'End If

                If iKey > 0 Then 'strKeys.Trim.Length > 0 Then
                    strSql = "SELECT * from saleorders.tpickboxshiplabel where PSSI_label_ID in (" & iKey.ToString & ");"
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function PrintPickTicket(ByVal dtPickTicketData As DataTable, ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_Pick.rpt"
            'Dim strSql As String = ""
            'Dim dt As DataTable
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Try
                'strSql = "Select '" & strBoxName & "' as BoxName " & Environment.NewLine
                'strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                'strSql &= ", " & iBoxQty & " as Qty " & Environment.NewLine
                'strSql &= ", '" & strTFPoNo & "' as TFPoNo" & Environment.NewLine
                'strSql &= ", '" & strMfgPoNo & "' as MfgPoNo" & Environment.NewLine
                'strSql &= ", '" & strReceiptDate & "' as ReceiptDate" & Environment.NewLine
                'strSql &= ", '" & strReceiptNo & "' as ReceiptNo" & Environment.NewLine
                'dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    objTFMisc.PrintCrystalReportLabel(dtPickTicketData, strReportName, iCopyNumber, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    objTFMisc.PrintCrystalReportLabel(dtPickTicketData, strReportName, iCopyNumber, )
                End Try
                '**********************

                Return dtPickTicketData.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPickTicketData)
            End Try
        End Function

        Public Function PrintPackingLabel(ByVal dtPackingData As DataTable, ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_Packing2008.rpt"
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc

            Try
                objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                objTFMisc.PrintCrystalReportLabel(dtPackingData, strReportName, iCopyNumber, "2DBoxLabel")
            Catch ex As Exception
                '2DBoxLabel is not available then try default printer
                objTFMisc.PrintCrystalReportLabel(dtPackingData, strReportName, iCopyNumber, )

                Return dtPackingData.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPackingData)
            End Try
        End Function

        Public Function getPackingSlipDataByBox_MeijerNonBulk(ByVal strPickBoxLabelName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT A.CustomerFirstName AS 'ShipName'" & Environment.NewLine
                strSql &= " , A.CustomerAddress1 AS 'Address1', A.CustomerAddress2 AS 'Address2', A.CustomerCity AS 'City', A.CustomerState AS 'State'" & Environment.NewLine
                strSql &= " , A.CustomerPostalCode As 'ZipCode', A.CustomerCountry AS 'Country', date_Format(A.PODate, '%m/%d/%Y')AS 'OrderDate', A.ClientCustomerOrder AS 'OrderNo'" & Environment.NewLine
                strSql &= " , A.PickRunNo AS 'Job', B.ItemCode AS 'Item', B.ProductName AS 'ItemDesc', C.BoxQty AS 'ItemQty', '" & strPickBoxLabelName & "' AS 'Other1'" & Environment.NewLine
                strSql &= " , A.PoNumber AS 'Other2', B.Upc AS 'OtherNo1',T.Model_LDesc AS 'OtherNo2', 0 AS 'OtherNo3', 0 AS 'OtherNo4'" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items T ON T.Model_Id = B.Model_Id" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.tpickboxshiplabel C ON B.SoHeaderID=C.SoHeaderID AND B.SoDetailsID=C.SoDetailsID" & Environment.NewLine
                strSql &= " WHERE (A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                strSql &= " AND C.PSSI_Boxlabel_Name = '" & strPickBoxLabelName & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getPackingSlipDataByBox(ByVal strPickBoxLabelName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'Customer, Address1, Address2, City, State, ZipCode, Country, OrderDate, OrderNo, Job, Item, ItemDesc, ItemQty, Other1, Other2, OtherNo1, OtherNo2, OtherNo3, OtherNo4
                'strSql = "SELECT IF(A.CustomerLastName = '', A.CustomerFirstName, CONCAT(A.CustomerFirstName, ' ', A.CustomerLastName)) AS 'Customer'" & Environment.NewLine
                'strSql &= "  , A.CustomerAddress1 AS 'Address1', A.CustomerAddress2 AS 'Address2', A.CustomerCity AS 'City', A.CustomerState AS 'State'" & Environment.NewLine
                'strSql &= "  , A.CustomerPostalCode As 'ZipCode', A.CustomerCountry AS 'Country', A.PODate AS 'OrderDate', A.PONumber AS 'OrderNo'" & Environment.NewLine
                'strSql &= "  , A.PickRunNo AS 'Job', B.ItemCode AS 'Item', B.ProductName AS 'ItemDesc', C.BoxQty AS 'ItemQty', '' AS 'Other1'" & Environment.NewLine
                'strSql &= "  , '' AS 'Other2', 0 AS 'OtherNo1', 0 AS 'OtherNo2', 0 AS 'OtherNo3', 0 AS 'OtherNo4'" & Environment.NewLine
                'strSql &= "  FROM saleorders.SoHeader A" & Environment.NewLine
                'strSql &= "  INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                'strSql &= "  INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                'strSql &= "  WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                'strSql &= "  AND C.PSSI_Boxlabel_Name = '" & strPickBoxLabelName & "';" & Environment.NewLine

                strSql = "SELECT A.CustomerFirstName AS 'ShipName'" & Environment.NewLine
                strSql &= "  , A.CustomerAddress1 AS 'Address1', A.CustomerAddress2 AS 'Address2', A.CustomerCity AS 'City', A.CustomerState AS 'State'" & Environment.NewLine
                strSql &= "  , A.CustomerPostalCode As 'ZipCode', A.CustomerCountry AS 'Country', date_Format(A.PODate, '%m/%d/%Y')AS 'OrderDate', A.ClientCustomerOrder AS 'OrderNo'" & Environment.NewLine
                strSql &= "  , A.PickRunNo AS 'Job', B.ItemCode AS 'Item', B.ProductName AS 'ItemDesc', C.BoxQty AS 'ItemQty', '" & strPickBoxLabelName & "' AS 'Other1'" & Environment.NewLine
                strSql &= "  , A.PoNumber AS 'Other2', B.Upc AS 'OtherNo1',T.Model_LDesc AS 'OtherNo2', 0 AS 'OtherNo3', 0 AS 'OtherNo4'" & Environment.NewLine
                strSql &= "  FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= "  INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= "  INNER JOIN production.tmodel_items T ON T.Model_Id = B.Model_Id" & Environment.NewLine
                strSql &= "  INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                strSql &= "  WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                strSql &= "  AND C.PSSI_Boxlabel_Name = '" & strPickBoxLabelName & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function getPackingSlipDataByBox_Bulk(ByVal strPickBoxLabelName As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                'Customer, Address1, Address2, City, State, ZipCode, Country, OrderDate, OrderNo, Job, Item, ItemDesc, ItemQty, Other1, Other2, OtherNo1, OtherNo2, OtherNo3, OtherNo4
                'strSql = "SELECT IF(A.CustomerLastName = '', A.CustomerFirstName, CONCAT(A.CustomerFirstName, ' ', A.CustomerLastName)) AS 'Customer'" & Environment.NewLine
                'strSql &= " , A.CustomerAddress1 AS 'Address1', A.CustomerAddress2 AS 'Address2', A.CustomerCity AS 'City', A.CustomerState AS 'State'" & Environment.NewLine
                'strSql &= " , A.CustomerPostalCode As 'ZipCode', A.CustomerCountry AS 'Country', A.PODate AS 'OrderDate', A.PONumber AS 'OrderNo'" & Environment.NewLine
                'strSql &= " , A.PickRunNo AS 'Job', B.ItemCode AS 'Item', B.ProductName AS 'ItemDesc', B.Quantity AS 'ItemQty', '' AS 'Other1'" & Environment.NewLine
                'strSql &= " , '' AS 'Other2', 0 AS 'OtherNo1', 0 AS 'OtherNo2', 0 AS 'OtherNo3', 0 AS 'OtherNo4'" & Environment.NewLine
                'strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                'strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                'strSql &= " WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                'strSql &= " AND A.SoHeaderID = " & iSoHeaderID & ";" & Environment.NewLine

                strSql = "SELECT A.CustomerFirstName AS 'ShipName'" & Environment.NewLine
                strSql &= "  , A.CustomerAddress1 AS 'Address1', A.CustomerAddress2 AS 'Address2', A.CustomerCity AS 'City', A.CustomerState AS 'State'" & Environment.NewLine
                strSql &= "  , A.CustomerPostalCode As 'ZipCode', A.CustomerCountry AS 'Country', date_Format(A.PODate, '%m/%d/%Y')AS 'OrderDate', A.ClientCustomerOrder AS 'OrderNo'" & Environment.NewLine
                strSql &= "  , A.PickRunNo AS 'Job', B.ItemCode AS 'Item', B.ProductName AS 'ItemDesc', B.Quantity AS 'ItemQty', '" & strPickBoxLabelName & "' AS 'Other1'" & Environment.NewLine
                strSql &= "  , A.PoNumber AS 'Other2', B.Upc AS 'OtherNo1',T.Model_LDesc AS 'OtherNo2', 0 AS 'OtherNo3', 0 AS 'OtherNo4'" & Environment.NewLine
                strSql &= "  FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= "  INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= "  INNER JOIN production.tmodel_items T ON T.Model_Id = B.Model_Id" & Environment.NewLine
                strSql &= "  INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                strSql &= "  WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                strSql &= "  AND C.PSSI_Boxlabel_Name = '" & strPickBoxLabelName & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ' Relabel ... ----------------------------------------------------------------------------------
        Public Function getOpenOrdersForPickData() As DataSet
            Dim strSql As String = ""
            Dim ds As New DataSet()
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                'Order Header
                strSql = "SELECT A.PoNumber as 'OrderNo', A.CustomerFirstName as 'Customer',Count(*) as 'Number of Item'" & Environment.NewLine
                strSql &= " ,SUM(B.Quantity) as 'Order Qty'" & Environment.NewLine
                strSql &= " ,CONVERT(GROUP_CONCAT(B.ItemCode SEPARATOR ', ') ,char) as 'Items'" & Environment.NewLine
                strSql &= " ,Max(A.OrderQty) as 'Master Order Qty'" & Environment.NewLine
                strSql &= " ,IF(SUM(B.Quantity)=Max(A.OrderQty),'Yes','No') as 'QtyMatched'" & Environment.NewLine
                strSql &= " ,IF(Trim(B.ItemCode)=Trim(ProductName) AND Trim(B.ItemCode)=Trim(SKU), 'Yes','No') as 'ItemMatched'" & Environment.NewLine
                strSql &= " ,A.SoheaderID" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null" & Environment.NewLine
                strSql &= " GROUP BY OrderNo,Customer;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "OrderHeader"
                ds.Tables.Add(dt)

                'Order details
                strSql = "SELECT B.ItemCode as 'Items'" & Environment.NewLine
                strSql &= " ,B.Quantity as 'Order Qty',0 as 'Pick Loc Qty','' as 'WH Inv',B.LineItemNumber,A.PoNumber as 'OrderNo', A.CustomerFirstName as 'Customer'" & Environment.NewLine
                strSql &= " ,A.SoheaderID,B.Model_ID,B.SoDetailsID" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null" & Environment.NewLine
                strSql &= " Order BY SoDetailsID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "OrderDetails"
                ds.Tables.Add(dt)

                Return ds
            Catch ex As Exception
                Throw ex
            End Try


        End Function

        Public Function getWHInventoryBoxesData(ByVal iModel_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                strSql = "SELECT A.boxID, C.Model_Desc as 'Item',COUNT(*) as 'Total Qty',Max(A.Qty) as 'Item Qty'" & Environment.NewLine
                strSql &= " ,A.wb_ID,B.Model_ID,A.WR_ID" & Environment.NewLine
                strSql &= " FROM edi.twarehousebox A" & Environment.NewLine
                strSql &= " INNER JOIN warehouse.warehouse_Items B ON A.WR_ID=B.WR_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items C ON B.Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.BoxStage='FK Received' AND A.Closed=1 AND Workstation='WH-WIP'" & Environment.NewLine
                strSql &= " AND Length(Trim(WHLocation))>0 AND Length(Trim(PickLocation))=0" & Environment.NewLine
                strSql &= " AND A.WR_ID>100006" & Environment.NewLine
                strSql &= " AND C.Model_ID=" & iModel_ID
                strSql &= " GROUP BY A.wb_ID,A.boxID,A.wb_ID,B.Model_ID,A.WR_ID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getTFFK_OrderNo(ByVal iOrder_ID As Integer) As String
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim strRet As String = ""

        '    Try
        '        strSql = "SELECT * FROM edi.tOrder WHERE Order_ID=" & iOrder_ID
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        If dt.Rows.Count > 0 Then
        '            strRet = Convert.ToString(dt.Rows(0).Item("OrderNo"))
        '        End If
        '        Return strRet
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        'Public Function getTFFK_WarehouseReceiptDate(ByVal iWR_ID As Integer) As String
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim row As DataRow
        '    Dim strRet As String = ""

        '    Try
        '        strSql = "SELECT * FROM warehouse.warehouse_Receipt where WR_ID=" & iWR_ID
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        If dt.Rows.Count > 0 Then
        '            strRet = Convert.ToString(dt.Rows(0).Item("Receipt_Date "))
        '            If IsDate(strRet) Then strRet = Format(CDate(strRet), "MM/dd/yyyy")
        '        End If
        '        Return strRet
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getPickLocation(ByVal iModel_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try
                'strSql = "SELECT CONCAT_WS('-', A.LocRow,A.LocCol) as 'PickLocation',B.Model_Desc,B.Model_ID,A.pm_ID" & Environment.NewLine
                'strSql &= " FROM  saleorders.tPickLocationMatrix A" & Environment.NewLine
                'strSql &= " INNER JOIN production.tmodel_items B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                'strSql &= " WHERE A.Model_ID=" & iModel_ID
                strSql = "SELECT  CONCAT(A.LocRow,IF(length(A.LocCol)<2,LPAD(A.LocCol,2,'0'),A.LocCol))  as 'PickLocation',B.Model_Desc,B.Model_ID,A.pm_ID" & Environment.NewLine
                strSql &= " FROM  saleorders.tPickLocationMatrix A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel_items B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " WHERE A.Model_ID=" & iModel_ID

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strRet = Trim(dt.Rows(0).Item("PickLocation")).ToString
                End If

                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getNewBoxName(ByVal strOldName As String) As String
            Dim objTFFK As New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
            Dim iRight As Integer = objTFFK._iWHBoxSegDigitCnt '   4
            'Dim i As Integer
            Dim iAsc As Integer
            Dim strS As String = ""
            Dim strPartOne As String = ""
            Dim strPartTwo As String = ""
            Dim strNewBoxName As String = ""
            Dim strSql As String = ""
            Dim dt As DataTable

            Try

                If strOldName.Trim.Length = 15 Then
                    strS = strOldName.Trim.Substring(strOldName.Trim.Length - (iRight + 1), 1)
                    strPartOne = strOldName.Trim.Substring(0, strOldName.Trim.Length - (iRight + 1))
                    strPartTwo = strOldName.Trim.Substring(strOldName.Trim.Length - (iRight), iRight)

                    strSql = "select max(BoxID) as 'BoxID' from edi.twarehousebox where length(trim(BoxID))=15 and boxID like '" & strPartOne & "%_%" & strPartTwo & "';" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then 'should be 0, or 1 row
                        strS = Trim(dt.Rows(0).Item("BoxID")).ToString
                        strS = strS.Replace(strPartOne, "").Replace(strPartTwo, "")
                    End If

                    If strS = "-" Then
                        strNewBoxName = strPartOne & "A" & strPartTwo
                    Else
                        iAsc = Asc(strS.ToUpper)
                        If iAsc >= 65 AndAlso iAsc < 90 Then
                            strS = Chr(iAsc + 1)
                            strNewBoxName = strPartOne & strS.ToUpper & strPartTwo
                        End If
                    End If
                End If

                Return strNewBoxName 'strPartOne  ' strS
                'Dim s As String
                'For i = 65 To 90
                '    s &= Chr(i)
                'Next
                'MessageBox.Show(s)
                'MessageBox.Show(Asc("A"))
            Catch ex As Exception
                Throw ex
            Finally
                objTFFK = Nothing
            End Try
        End Function

        Public Function CreateNewSplitBox(ByVal iwb_ID As Integer, ByVal strNewBoxName As String) As Integer
            Dim strSql As String = ""
            Dim strS As String = ""
            Dim strS2 As String = ""
            Dim dt As DataTable
            Dim col As DataColumn
            Dim iRet As Integer = 0
            Dim iNewWb_ID As Integer = 0

            Try
                strSql = "SELECT * FROM edi.twarehousebox WHERE wb_ID=" & iwb_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 1 Then
                    For Each col In dt.Columns
                        If Not col.ColumnName.ToUpper = "wb_ID".ToUpper Then
                            If strS.Trim.Length = 0 Then
                                If col.ColumnName.ToUpper = "BoxID".ToUpper Then
                                    strS = "'" & strNewBoxName & "' as " & col.ColumnName
                                Else
                                    strS = col.ColumnName
                                End If
                                strS2 = col.ColumnName
                            Else
                                If col.ColumnName.ToUpper = "BoxID".ToUpper Then
                                    strS &= ",'" & strNewBoxName & "' as " & col.ColumnName
                                Else
                                    strS &= "," & col.ColumnName
                                End If
                                strS2 &= "," & col.ColumnName
                            End If
                        End If
                    Next
                    strSql = "INSERT INTO edi.twarehousebox (" & strS2 & " ) SELECT " & strS & " FROM edi.twarehousebox WHERE  wb_ID=" & iwb_ID & ";"
                    iNewWb_ID = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "edi.twarehousebox")

                    strSql = "SELECT * FROM edi.twarehousebox WHERE wb_ID=" & iNewWb_ID & ";"
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count = 1 Then
                        If Trim(dt.Rows(0).Item("BoxID")).ToString.ToUpper = strNewBoxName.Trim.ToUpper Then
                            iRet = iNewWb_ID
                        Else
                            iRet = 0
                        End If
                    Else
                        iRet = 0
                    End If
                Else
                    iRet = 0
                End If

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdatePickLocationBoxForSplitBoxes(ByVal iwb_ID_Old As Integer, ByVal iQty_Old As Integer, _
                                                           ByVal iwb_ID_New As Integer, ByVal iQty_New As Integer, _
                                                           ByVal strWorkStation As String, ByVal strPickLocation As String) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox SET Qty=" & iQty_New & ",QtyBeforeSplit=0,WorkStation='" & strWorkStation & "',PickLocation='" & strPickLocation & "' WHERE wb_ID=" & iwb_ID_New & ";"
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE edi.twarehousebox SET Qty=" & iQty_Old - iQty_New & ", QtyBeforeSplit=" & iQty_Old & " WHERE wb_ID=" & iwb_ID_Old & ";"
                iRet &= Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateSourceBoxAfterQuarantine(ByVal iwb_ID As Integer, ByVal iQty_Quarantine As Integer) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox SET QtyBeforeSplit=Qty,Qty=Qty-" & iQty_Quarantine & " WHERE wb_ID=" & iwb_ID & ";"
                iRet &= Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CloseWarehouseBox(ByVal iwb_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox SET Closed=1 WHERE wb_ID=" & iwb_ID & ";"
                iRet &= Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateQuarantineSNs(ByVal iSoDetailsID As Integer, ByVal strWI_IDs As String) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE warehouse.warehouse_Items SET SoDetailsID = " & iSoDetailsID & " WHERE WI_ID IN (" & strWI_IDs & ");"
                iRet &= Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InsertSplitBoxLogData(ByVal iwb_ID_Old As Integer, ByVal strBoxName_Old As String, ByVal iQty_Old As Integer, _
                                              ByVal iwb_ID_New As Integer, ByVal strBoxName_New As String, ByVal iQty_New As Integer, _
                                              ByVal iUser_ID As Integer, ByVal strDatetime As String, Optional ByVal strNote As String = "") As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0
            'split_id, From_wb_id, From_BoxID, From_Qty, To_wb_id, To_BoxID, To_Qty, User_ID, DTime, Notes
            Try
                strSql = "INSERT INTO edi.twarehousebox_split (From_wb_id, From_BoxID, From_Qty, To_wb_id, To_BoxID, To_Qty, User_ID, DTime, Notes)"
                strSql &= " VALUES (" & iwb_ID_Old & ",'" & strBoxName_Old & "'," & iQty_Old & ","
                strSql &= iwb_ID_New & ",'" & strBoxName_New & "'," & iQty_New & "," & iUser_ID & ",'" & strDatetime & "','" & strNote & "');"
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdatePickLocationBoxForFullBox(ByVal iwb_ID As Integer, _
                                                        ByVal strWorkStation As String, _
                                                        ByVal strPickLocation As String) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox SET WorkStation='" & strWorkStation & "',PickLocation='" & strPickLocation & "' WHERE wb_ID=" & iwb_ID & ";"
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateFulfillmentOrderWorkstation(ByVal iSoHeaderID As Integer, _
                                                          ByVal strWorkStation As String, _
                                                          ByVal iUserID As Integer, _
                                                          ByVal strDatetime As String, _
                                                          ByVal iPick1_Pack2_Ship3 As Integer, _
                                                          Optional ByVal iShipType_ID As Integer = 0, _
                                                          Optional ByVal strPickRunName As String = "") As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                Select Case iPick1_Pack2_Ship3
                    Case 1
                        strSql = "UPDATE saleorders.SoHeader SET WorkStation='" & strWorkStation & "'" & _
                                 ",PickRunNo='" & strPickRunName & "',OrderType_ID=" & iShipType_ID & _
                                 ",Workstation_PickUserID=" & iUserID & ",Workstation_PickDatetime='" & strDatetime & "' WHERE SoHeaderID=" & iSoHeaderID & ";"
                        iRet = Me._objDataProc.ExecuteNonQuery(strSql)
                    Case 2
                        strSql = "UPDATE saleorders.SoHeader SET WorkStation='" & strWorkStation & "'" & _
                                  ",Workstation_PackUserID=" & iUserID & ",Workstation_PackDatetime='" & strDatetime & "' WHERE SoHeaderID=" & iSoHeaderID & ";"
                        iRet = Me._objDataProc.ExecuteNonQuery(strSql)
                    Case 3
                        strSql = "UPDATE saleorders.SoHeader SET WorkStation='" & strWorkStation & "'" & _
                                 ",ShipUserID=" & iUserID & ",ShipDate='" & strDatetime & "' WHERE SoHeaderID=" & iSoHeaderID & ";"
                        iRet = Me._objDataProc.ExecuteNonQuery(strSql)
                End Select


                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdatePickRunData(ByVal strSoHeaderIDs As String, _
                                          ByVal strWorkStation As String, _
                                          ByVal iUserID As Integer, _
                                          ByVal strDatetime As String, _
                                          ByVal iShipType_ID As Integer, _
                                          ByVal strPickRunName As String) As Integer
            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE saleorders.SoHeader SET WorkStation='" & strWorkStation & "'" & _
                         ",PickRunNo='" & strPickRunName & "',OrderType_ID=" & iShipType_ID & _
                         ",Workstation_PickUserID=" & iUserID & ",Workstation_PickDatetime='" & strDatetime & "' WHERE SoHeaderID in (" & strSoHeaderIDs & ");"
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getItemsNeedForOpenOrders() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT B.ItemCode as 'Items',SUM(B.Quantity) as 'Item Qty',B.Model_ID" & Environment.NewLine
                strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= " WHERE A.iDataSet_ID=1 AND A.ShipDate is Null AND Workstation='Waiting'" & Environment.NewLine
                strSql &= " GROUP BY B.ItemCode,B.Model_ID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function Build_BOL_Text(ByVal iWeight As Integer, ByVal noPallets As Integer, ByVal noPieces As Integer, _
                                ByVal orderNumber As String, ByVal recipientCompanyName As String, _
                                ByVal recipientContactName As String, ByVal receipientAddress As String, _
                                ByVal recipientCity As String, ByVal recipientState As String, ByVal recipientPostalCode As String, _
                                ByVal totalOrderQty As Integer, ByVal packageWeight As Integer, _
                                Optional ByVal recipientPhoneNumber As String = "0000000000", Optional ByVal recipientPOBOX As String = "0000000000") As String

            Dim strRet As String = ""

            Try
                strRet = "0,""060""1,""" & orderNumber & """4,""TracFone Wireless""5,""511 S ROYAL LANE""7,""COPPELL""8,""TX""9,""75019""11,""" & recipientCompanyName & """12,"
                strRet &= """" & recipientContactName & """13,""" & receipientAddress & """15,""" & recipientCity & """16,""" & recipientState & """17,""" & recipientPostalCode & """18,"
                strRet &= """" & recipientPhoneNumber & """25,""" & recipientPOBOX & """32,""Bill Venderbilt""50,""US""68,""USD""79,""Cell Phones""80,""US""82,""" & totalOrderQty & """117,"
                strRet &= """US""187,""288""414,""IN""537,""\\PHQ-NAVSQL\Zebra_Bulk""538,""\\PHQ-NAVSQL\BOL_Printer""1145,""FXFR""1274,""112""1331,""N""1670,""" & iWeight & """2404,""NNNNN"" "
                strRet &= "2931,""" & packageWeight & """6105,""100.0""6107,""1""6110,""NNNNNNNNNNNNNNYNNNN""6116,""1""6117,""4""6128,""US""6129,""PSS INC""6130,""511 S ROYAL LN""6132,""COPPELL""6133,""TX""6134,""75019""6135,""800-122-2220"" "
                strRet &= "6139,""207618080""6142,""" & noPallets & """6166,""01""6167,""1""6246,""Cell Phones""99,"""""

                Return strRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function SaveBolTrackingNumber(ByVal strPSSIBox As String, ByVal strBolTrackNo As String) As Integer

            Dim strSql As String = ""
            Dim strType As String = "BOL"
            Dim dt As DataTable
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim i As Integer
            Try
                strBolTrackNo = strBolTrackNo.Replace("'", "''")

                'ShipTrack_ID, PSSI_Boxlabel_Name, TrackingNo, TrackingType
                ', TrackingNo_DateTime, Updated_DateTime
                strSql = "SELECT * FROM saleorders.shiptrackno WHERE PSSI_Boxlabel_Name = '" & strPSSIBox & "'" & _
                         " AND TrackingType='" & strType & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "UPDATE saleorders.shiptrackno SET TrackingNo = '" & strBolTrackNo & "'" & _
                             ",TrackingNo_DateTime='" & strDTime & "',Updated_DateTime='" & strDTime & "'" & _
                             " WHERE PSSI_Boxlabel_Name = '" & strPSSIBox & "'" & _
                             " AND TrackingType='" & strType & "';"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO saleorders.shiptrackno " & _
                             "(PSSI_Boxlabel_Name, TrackingNo, TrackingType, TrackingNo_DateTime, Updated_DateTime)" & _
                             "VALUES ('" & strPSSIBox & "'," & _
                             "'" & strBolTrackNo & "'," & _
                             "'" & strType & "'," & _
                             "'" & strDTime & "'," & _
                             "'" & strDTime & "');"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function IsFedExForNonBulk(ByVal iShipCarrier_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False
            Try
                strSql = "SELECT * FROM saleorders.shipcarriers WHERE Carrier ='FedEx' AND ShipCarrier_ID<>10 AND ShipCarrier_ID=" & iShipCarrier_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    bRet = True
                End If

                Return bRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Function getFedExServiceType(ByVal iShipCarrier_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""
            Try
                'ShipCarrier_ID, Carrier, ShipMethod_SDesc, ShipMethod_LDesc, ServiceType, Notes
                strSql = "SELECT * FROM  saleorders.shipcarriers WHERE Carrier ='FedEx' AND ShipCarrier_ID<>10 AND ShipCarrier_ID=" & iShipCarrier_ID & ";"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then  'must be one if found
                    If Not dt.Rows(0).IsNull("ServiceType") AndAlso Convert.ToString(dt.Rows(0).Item("ServiceType")).Length > 0 Then
                        strRet = Convert.ToString(dt.Rows(0).Item("ServiceType"))
                    End If
                End If

                Return strRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace