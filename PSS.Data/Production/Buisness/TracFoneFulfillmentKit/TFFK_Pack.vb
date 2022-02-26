Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data

Namespace Buisness.TracFoneFulfillmentKit
    Public Class TFFK_Pack
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

        Public Function getPackOrder(ByVal orderNo As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.PickRunNo As 'PickRunNo', A.PoNumber AS 'OrderNo', C.PSSI_Boxlabel_Name as 'BoxLabel', A.CustomerFirstName as 'Customer'" & Environment.NewLine
                strSql &= ",CONVERT(A.Cust_ID,char) As 'CustomerNo', B.ItemCode as 'Part Number'" & Environment.NewLine
                strSql &= ",A.OrderQty as 'Order Qty',0 as 'Pack Qty', A.SoheaderID as 'SoheaderID', B.Model_ID as 'ModelID'" & Environment.NewLine
                strSql &= ", B.SoDetailsID as 'SoDetailsID', A.ShipCarrier_ID As 'ShipCarrierID', A.ShipPackageWeight, D.TrackingNo" & Environment.NewLine
                strSql &= ", CustomerAdditionalName1, CustomerAddress1, CustomerAddress2, CustomerCity, CustomerState, CustomerPostalCode " & Environment.NewLine
                strSql &= "FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoHeaderID" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                strSql &= "LEFT JOIN saleorders.shiptrackno D ON C.PSSI_Boxlabel_Name = D.PSSI_Boxlabel_Name" & Environment.NewLine
                strSql &= "WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                strSql &= "AND A.PoNumber = '" & orderNo & "' AND A.Workstation = 'In-Pack'" & Environment.NewLine
                strSql &= "Order BY SoDetailsID;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Public Function getPackBox(ByVal boxLabel As String) As DataTable
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSql = "SELECT A.SOHeaderID as 'SOHeaderID', A.PickRunNo As 'PickRunNo', A.PoNumber as 'OrderNo',A.PackLocked as 'PackLocked',A.PackLockedPC as 'PackLockedPC', C.PSSI_Boxlabel_Name as 'BoxLabel', A.CustomerFirstName as 'Customer'" & Environment.NewLine
        '        strSql &= ",CONVERT(A.Cust_ID,char) As 'CustomerNo', B.ItemCode as 'Part Number'" & Environment.NewLine
        '        strSql &= ",A.OrderQty as 'Order Qty',0 as 'Pack Qty', A.SoheaderID as 'SoheaderID', B.Model_ID as 'ModelID'" & Environment.NewLine
        '        strSql &= ", B.SoDetailsID as 'SoDetailsID', A.ShipCarrier_ID As 'ShipCarrierID', A.ShipPackageWeight, D.TrackingNo" & Environment.NewLine
        '        strSql &= ", CustomerAdditionalName1, CustomerAddress1, CustomerAddress2, CustomerCity, CustomerState, CustomerPostalCode " & Environment.NewLine
        '        strSql &= "FROM saleorders.SoHeader A" & Environment.NewLine
        '        strSql &= "INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoHeaderID" & Environment.NewLine
        '        strSql &= "INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
        '        strSql &= "LEFT JOIN saleorders.shiptrackno D ON C.PSSI_Boxlabel_Name = D.PSSI_Boxlabel_Name" & Environment.NewLine
        '        strSql &= "WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
        '        strSql &= "AND C.PSSI_Boxlabel_Name = '" & boxLabel & "' AND A.Workstation = 'In-Pack'" & Environment.NewLine
        '        strSql &= "Order BY SoDetailsID;" & Environment.NewLine

        '        dt = Me._objDataProc.GetDataTable(strSql)

        '        Return dt
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function getOrderNumber(ByVal boxLabel As String, ByRef iOrderTypeID As Integer, _
                                       ByRef bIsOrderClosed As Boolean, ByRef bOrderLocked As Boolean, _
                                       ByRef LockedByPC As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try
                iOrderTypeID = 0 : LockedByPC = ""

                strSql = "select A.PoNumber,A.OrderType_ID,A.ShipDate,A.PackLocked,A.PackLockedPC from saleorders.SoHeader A" & Environment.NewLine
                strSql &= " Inner join  saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                strSql &= " WHERE  C.PSSI_Boxlabel_Name = '" & boxLabel & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strRet = dt.Rows(0).Item("PoNumber") : iOrderTypeID = dt.Rows(0).Item("OrderType_ID")

                    If dt.Rows(0).IsNull("ShipDate") OrElse Str(dt.Rows(0).Item("ShipDate")).Length = 0 Then
                        bIsOrderClosed = False
                    Else
                        bIsOrderClosed = True
                    End If

                    If dt.Rows(0).IsNull("PackLocked") OrElse Convert.ToInt32(dt.Rows(0).Item("PackLocked")) <> 1 Then
                        bOrderLocked = False
                    Else
                        LockedByPC = Convert.ToString(dt.Rows(0).Item("PackLockedPC"))
                        bOrderLocked = True
                    End If
                End If

                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOpenOrderData(ByVal strOrderNo As String, ByVal iOrderTypeID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As New DataTable()

            Try
                Select Case iOrderTypeID
                    Case 1 'non bulk
                        strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                        strSql &= " (SELECT C.PSSI_Boxlabel_Name as 'BoxLabel',B.ItemCode as 'ItemName',C.BoxQty as 'Qty',0 as 'ShipQty'" & Environment.NewLine
                        strSql &= " ,D.TrackingNo,B.Quantity as 'ItemQty',A.OrderQty,LineItemNumber as 'LineNo'" & Environment.NewLine
                        strSql &= " ,A.PickRunNo, A.PoNumber as 'OrderNo',A.ClientCustomerOrder,B.UPC,0 as 'GTN14_Qty',MD.Model_LDesc as 'ItemDesc',A.PackLocked ,A.PackLockedPC,A.CustomerFirstName as 'Customer'" & Environment.NewLine
                        strSql &= " ,CONVERT(A.Cust_ID,char) As 'CustomerNo'" & Environment.NewLine
                        strSql &= " ,A.WorkorderID as 'WO_ID', A.SoheaderID as 'SoheaderID', B.Model_ID" & Environment.NewLine
                        strSql &= " , B.SoDetailsID as 'SoDetailsID', A.ShipCarrier_ID As 'ShipCarrierID', A.ShipPackageWeight" & Environment.NewLine
                        strSql &= " , CustomerAdditionalName1, CustomerAddress1, CustomerAddress2, CustomerCity, CustomerState, CustomerPostalCode" & Environment.NewLine
                        strSql &= ",IF(trim(B.ItemCode)=trim(MD.Model_Desc) AND B.Model_ID=MD.Model_ID, 'Yes','No') as 'IsModelMatch'" & Environment.NewLine
                        strSql &= ",IF(D.Trackingno is NULL,0,Length(Trim(D.Trackingno))) as 'TrackNoLength'" & Environment.NewLine
                        strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                        strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoHeaderID" & Environment.NewLine
                        strSql &= " INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID AND B.SoDetailsID=C.SoDetailsID" & Environment.NewLine
                        strSql &= " LEFT JOIN production.tModel_Items MD ON B.Model_ID=MD.Model_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN saleorders.shiptrackno D ON C.PSSI_Boxlabel_Name = D.PSSI_Boxlabel_Name" & Environment.NewLine
                        strSql &= " WHERE A.iDataSet_ID = 1 And A.ShipDate Is Null AND A.Workstation = 'In-Pack' AND A.OrderType_ID=1" & Environment.NewLine
                        strSql &= " AND A.PoNumber = '" & strOrderNo & "'" & Environment.NewLine
                        strSql &= " Order BY BoxLabel,SoDetailsID) m," & Environment.NewLine
                        strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                        dt = Me._objDataProc.GetDataTable(strSql)
                    Case 2 'bulk
                        strSql = "SELECT @row_number:=@row_number+1 AS 'Row',m.* FROM" & Environment.NewLine
                        strSql &= " (SELECT C.PSSI_Boxlabel_Name as 'BoxLabel',B.ItemCode as 'ItemName',B.Quantity as 'Qty',0 as 'ShipQty'" & Environment.NewLine
                        strSql &= " ,D.TrackingNo,B.Quantity as 'ItemQty',B.UPC,CEILING((B.Quantity/3)) as 'GTN14_Qty',MD.Model_LDesc as 'ItemDesc',A.OrderQty,LineItemNumber as 'LineNo'" & Environment.NewLine
                        strSql &= " ,A.PickRunNo, A.PoNumber as 'OrderNo',A.ClientCustomerOrder,A.PackLocked ,A.PackLockedPC,A.CustomerFirstName as 'Customer'" & Environment.NewLine
                        strSql &= " ,CONVERT(A.Cust_ID,char) As 'CustomerNo'" & Environment.NewLine
                        strSql &= " ,A.WorkorderID as 'WO_ID', A.SoheaderID as 'SoheaderID', B.Model_ID" & Environment.NewLine
                        strSql &= " , B.SoDetailsID as 'SoDetailsID', A.ShipCarrier_ID As 'ShipCarrierID', A.ShipPackageWeight" & Environment.NewLine
                        strSql &= " , CustomerAdditionalName1, CustomerAddress1, CustomerAddress2, CustomerCity, CustomerState, CustomerPostalCode" & Environment.NewLine
                        strSql &= ",IF(trim(B.ItemCode)=trim(MD.Model_Desc) AND B.Model_ID=MD.Model_ID, 'Yes','No') as 'IsModelMatch'" & Environment.NewLine
                        strSql &= ",IF(D.Trackingno is NULL,0,Length(Trim(D.Trackingno))) as 'TrackNoLength'" & Environment.NewLine
                        strSql &= " FROM saleorders.SoHeader A" & Environment.NewLine
                        strSql &= " INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoHeaderID" & Environment.NewLine
                        strSql &= " INNER JOIN saleorders.tpickboxshiplabel C ON A.SoHeaderID=C.SoHeaderID" & Environment.NewLine
                        strSql &= " LEFT JOIN production.tModel_Items MD ON B.Model_ID=MD.Model_ID" & Environment.NewLine
                        strSql &= " LEFT JOIN saleorders.shiptrackno D ON C.PSSI_Boxlabel_Name = D.PSSI_Boxlabel_Name" & Environment.NewLine
                        strSql &= " WHERE A.iDataSet_ID = 1 And A.ShipDate Is Null AND A.Workstation = 'In-Pack' AND A.OrderType_ID=2" & Environment.NewLine
                        strSql &= " AND A.PoNumber = '" & strOrderNo & "'" & Environment.NewLine
                        strSql &= " Order BY BoxLabel,SoDetailsID) m," & Environment.NewLine
                        strSql &= " (SELECT @row_number:=0) AS t;" & Environment.NewLine

                        dt = Me._objDataProc.GetDataTable(strSql)
                End Select

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InsertUpdateTrackingNumber(ByVal strBox As String, _
                                                   ByVal strTrackNo As String, _
                                                   ByVal strType As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                strBox = strBox.Replace("'", "''") : strTrackNo = strTrackNo.Replace("'", "''")
                'ShipTrack_ID, PSSI_Boxlabel_Name, TrackingNo, TrackingType, TrackingNo_DateTime, Updated_DateTime
                strSql = "SELECT * FROM saleorders.shiptrackno where PSSI_Boxlabel_Name='" & strBox & "';"
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    strSql = "UPDATE saleorders.shiptrackno SET TrackingNo='" & strTrackNo & "'" & _
                             ",TrackingType='" & strType & "',TrackingNo_DateTime='" & strDTime & "'" & _
                             ",Updated_DateTime='" & strDTime & "' WHERE PSSI_Boxlabel_Name='" & strBox & "';"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO saleorders.shiptrackno (PSSI_Boxlabel_Name, TrackingNo, TrackingType, TrackingNo_DateTime, Updated_DateTime)" & _
                             " VALUES ('" & strBox & "','" & strTrackNo & "','" & strType & "'" & _
                             ",'" & strDTime & "','" & strDTime & " ');"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getScanSNsDataTableDef() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT '' AS 'SN','' as 'Item', 0 as 'Model_ID',0 as 'SoDetailsID','' as 'PSSI_Boxlabel_Name', 0 as 'Device_ID' , 0 as 'WI_ID',0 as 'Row' Limit 0;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getInPickSNsData(ByVal strModel_IDs As String, _
                                         Optional ByVal strModelItems As String = "", _
                                         Optional ByVal strSN As String = "") As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim i As Integer = 0

            Try

                If strModel_IDs.Trim.Length > 0 Then
                    strSql = "SELECT DISTINCT A.`Serial` AS 'SN', C.Model_Desc AS 'Item', A.Model_ID,SoDetailsID,'' as  'PSSI_Boxlabel_Name', A.Device_ID , A.WI_ID,0 as 'Row'" & Environment.NewLine
                    strSql &= " FROM warehouse.warehouse_items A" & Environment.NewLine
                    strSql &= " INNER JOIN edi.twarehousebox B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel_items C ON B.Model_ID = C.Model_ID" & Environment.NewLine
                    strSql &= " WHERE WorkStation = 'In-Pick' AND A.SoDetailsID=0" & Environment.NewLine
                    strSql &= " AND picklocation Is Not Null" & Environment.NewLine
                    If strSN.Trim.Length > 0 Then
                        strSql &= " AND A.Serial='" & strSN & "'" & Environment.NewLine
                    End If
                    strSql &= " AND C.Model_ID IN (" & strModel_IDs & ");" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                ElseIf strModelItems.Trim.Length > 0 Then
                    strSql = "SELECT DISTINCT A.`Serial` AS 'SN', C.Model_Desc AS 'Item', A.Model_ID,SoDetailsID,'' as  'PSSI_Boxlabel_Name', A.Device_ID , A.WI_ID,0 as 'Row'" & Environment.NewLine
                    strSql &= " FROM warehouse.warehouse_items A" & Environment.NewLine
                    strSql &= " INNER JOIN edi.twarehousebox B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                    strSql &= " INNER JOIN production.tmodel_items C ON B.Model_ID = C.Model_ID" & Environment.NewLine
                    strSql &= " WHERE WorkStation = 'In-Pick' AND A.SoDetailsID=0" & Environment.NewLine
                    strSql &= " AND picklocation Is Not Null" & Environment.NewLine
                    If strSN.Trim.Length > 0 Then
                        strSql &= " AND A.Serial='" & strSN & "'" & Environment.NewLine
                    End If
                    strSql &= " AND C.Model_Desc IN (" & strModelItems & ");" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getOrderModelItemsQty(ByVal dtPackOrder As DataTable) As DataTable
            Dim row As DataRow
            Dim rowNew As DataRow
            Dim strSql As String = "SELECT '' as 'ItemName',0 as 'Model_ID',0 as 'Qty' limit 0;"
            Dim dt As DataTable
            Dim arrModelIDs As New ArrayList()
            Dim i As Integer = 0
            Dim iSum As Integer = 0
            Dim strItem As String = ""

            Try

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dtPackOrder.Rows
                    If Not arrModelIDs.Contains(row("Model_ID")) Then arrModelIDs.Add(row("Model_ID"))
                Next
                For i = 0 To arrModelIDs.Count - 1
                    iSum = Convert.ToInt32(dtPackOrder.Compute("Sum(qty)", "Model_ID = " & arrModelIDs(i).ToString))
                    strItem = Convert.ToString(dtPackOrder.Select("Model_ID = " & arrModelIDs(i).ToString)(0)("ItemName"))
                    rowNew = dt.NewRow
                    rowNew("ItemName") = strItem
                    rowNew("Model_ID") = arrModelIDs(i)
                    rowNew("Qty") = iSum
                    dt.Rows.Add(rowNew)
                Next

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getItemData(ByVal PartNum As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT WI_ID, `Serial` AS 'SN'" & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A" & Environment.NewLine
                strSql &= "INNER JOIN edi.twarehousebox B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel_items C ON B.Model_ID = C.Model_ID" & Environment.NewLine
                strSql &= "WHERE WorkStation = 'In-Pick'" & Environment.NewLine
                strSql &= "AND Model_Desc = '" & PartNum & "'" & Environment.NewLine
                strSql &= "AND picklocation Is Not Null;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function UpdateSoHeader_Lock(ByVal strPackLockedPC As String, ByVal iSoHeaderId As Integer) As Integer

            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "UPDATE saleorders.SoHeader SET PackLocked = 1," & "PackLockedPC = '" & strPackLockedPC & "' where soheaderId= " & iSoHeaderId.ToString
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function UpdateSoHeader_removeLock(ByVal soheaderId As String) As Integer

            Dim strSql As String = ""
            Dim dt As DataTable
            Dim packlocked As Integer = 0
            Dim packlockedpc As String = String.Empty

            Try
                strSql = "UPDATE saleorders.SoHeader SET PackLocked = " & packlocked & ", PackLockedPC = '" & packlockedpc & "' where soheaderId= " & soheaderId
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try


        End Function

        Public Function UpdateItemsDevicesWorkOrder(ByVal iWO_ID As Integer, _
                                                    ByVal strWorkstation As String, _
                                                    ByVal dtFilledSNs As DataTable, _
                                                    ByRef strMsg As String) As Integer
            Dim strSql As String = ""
            Dim strSetOne As String = ""
            Dim strSetTwo As String = ""
            Dim strWhereCondition As String = ""
            Dim row As DataRow
            Dim i As Integer = 0, j As Integer = 0
            Dim strDate As String = Format(Now, "yyyy-MM-dd")

            Try
                ' dtFilledSNs: SN, Item, Model_ID, SoDetailsID, PSSI_Boxlabel_Name, Device_ID, WI_ID, Row

                strMsg = ""
                'Wareouse_items--------------------------------------------------------------------------------
                strSql = "UPDATE warehouse.warehouse_items"
                For Each row In dtFilledSNs.Rows
                    i += 1
                    If strSetOne.Trim.Length = 0 Then strSetOne = " SET SoDetailsID = CASE WI_ID"
                    strSetOne &= "  WHEN " & Convert.ToString(row("WI_ID")) & " THEN  " & Convert.ToString(row("SoDetailsID"))
                    If i = dtFilledSNs.Rows.Count Then strSetOne &= " END,"

                    If strSetTwo.Trim.Length = 0 Then strSetTwo = "PSSI_Boxlabel_Name = CASE WI_ID"
                    strSetTwo &= "  WHEN " & Convert.ToString(row("WI_ID")) & " THEN  '" & Convert.ToString(row("PSSI_Boxlabel_Name")) & "'"
                    If i = dtFilledSNs.Rows.Count Then strSetTwo &= " END"

                    If strWhereCondition.Trim.Length = 0 Then
                        strWhereCondition = " WHERE WI_ID IN (" & Convert.ToString(row("WI_ID"))
                    Else
                        strWhereCondition &= "," & Convert.ToString(row("WI_ID"))
                    End If
                    If i = dtFilledSNs.Rows.Count Then strWhereCondition &= ");"
                Next
                If strSetOne.Trim.Length > 0 AndAlso strSetTwo.Trim.Length > 0 AndAlso strWhereCondition.Trim.Length > 0 Then
                    strSql &= strSetOne & strSetTwo & strWhereCondition
                    j = Me._objDataProc.ExecuteNonQuery(strSql)
                    If j = 0 Then strMsg &= "Failed to update Warehouse_items."
                Else
                    strMsg &= "Failed to update Warehouse_items. Invalid SQL string."
                End If

                'tWorkorder--------------------------------------------------------------------------------
                strSql = "UPDATE production.tWorkorder SET WO_Closed=1,WO_Shipped =" & dtFilledSNs.Rows.Count.ToString & "," & _
                         "WO_DateShip='" & strDate & "' WHERE WO_ID=" & iWO_ID.ToString & ";"
                j = Me._objDataProc.ExecuteNonQuery(strSql)
                If j = 0 Then strMsg &= "Failed to update production.tWorkOrder."

                'tDevice,tcellopt --------------------------------------------------------------------------------
                strSetOne = "" : strSetTwo = "" : strWhereCondition = "" : i = 0
                strSql = "UPDATE production.tDevice  SET Device_DateShip = '" & strDate & "'"
                For Each row In dtFilledSNs.Rows
                    i += 1
                    If strWhereCondition.Trim.Length = 0 Then
                        strWhereCondition = " WHERE Device_ID IN (" & Convert.ToString(row("Device_ID"))
                    Else
                        strWhereCondition &= "," & Convert.ToString(row("Device_ID"))
                    End If
                    If i = dtFilledSNs.Rows.Count Then strWhereCondition &= ");"
                Next
                If strWhereCondition.Trim.Length > 0 Then
                    strSql &= strWhereCondition
                    j = Me._objDataProc.ExecuteNonQuery(strSql)
                    If j = 0 Then strMsg &= "Failed to update production.tWorkOrder."

                    strSql = "UPDATE production.tCellopt SET Workstation='" & strWorkstation & "'" & strWhereCondition
                    j = Me._objDataProc.ExecuteNonQuery(strSql)
                    If j = 0 Then strMsg &= "Failed to update production.tCellopt."
                Else
                    strMsg &= "Failed to update Warehouse_items. Invalid SQL string."
                End If

                Return j
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Function UpdateWarehouse_SODetailsID(ByVal SNs As DataTable) As Integer
            Dim row As DataRow
            Dim item As DataRow
            Dim dt As DataTable
            Dim strSql As String = "UPDATE warehouse.warehouse_items SET SODetailsID = CASE WI_ID"
            Dim whenCondition As String = ""
            Dim whereCondition As String = ""
            Dim rowNum As Integer = 0

            Try
                For Each row In SNs.Rows
                    strSql = "SELECT `Serial` AS 'SN', SODetailsID from warehouse.warehouse_items WHERE WI_ID = " & row.Item("WI_ID") & " AND SODetailsID = 0;" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    'If dt.Rows.Count <= 300 Then

                    '    For Each item In dt.Rows
                    '        whenCondition &= "  WHEN '" & row("WI_ID").ToString() & "' THEN  " & row("SODetailsID")
                    '        whereCondition &= row("WI_ID").ToString() & ","
                    '    Next
                    '    strSql &= whenCondition & "WHERE WI_ID in (" & whereCondition & ") AND SODetailsID = 0 "
                    '    Me._objDataProc.ExecuteNonQuery(strSql)
                    'Else

                    '    For Each item In dt.Rows
                    '        rowNum += 1
                    '        If (rowNum Mod 300 = 0) Then
                    '            whereCondition.Remove(whereCondition.Length - 1, 1)
                    '            strSql &= whenCondition & "END WHERE WI_ID in (" & whereCondition & ") AND SODetailsID = 0 "
                    '            Me._objDataProc.ExecuteNonQuery(strSql)
                    '            strSql = "UPDATE warehouse.warehouse_items SET SODetailsID = CASE WI_ID "
                    '            whenCondition = String.Empty
                    '            whereCondition = String.Empty

                    '            whenCondition &= "  WHEN '" & row("WI_ID").ToString() & "' THEN  " & row("SODetailsID")
                    '            whereCondition &= row("WI_ID").ToString() & ","

                    '        Else
                    '            whenCondition &= "  WHEN '" & row("WI_ID").ToString() & "' THEN  " & row("SODetailsID")
                    '            whereCondition &= row("WI_ID").ToString() & ","
                    '        End If

                    '    Next


                    'End If

                    For Each item In dt.Rows
                        If item.Item("SODetailsID").ToString() = "0" Then
                            strSql = "UPDATE warehouse.warehouse_items SET SODetailsID = " & row("SODetailsID") & " WHERE WI_ID = " & row("WI_ID").ToString() & " ;" & Environment.NewLine
                            Me._objDataProc.ExecuteNonQuery(strSql)
                        Else
                            Return 0
                        End If
                    Next
                Next

                Return 1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdatetCelloptWorkstation(ByVal IDs As DataTable, ByVal strWorkStation As String, ByVal strDatetime As String) As Integer
            Dim row As DataRow
            Dim strSql As String = ""
            Dim strSql1 As String = "UPDATE production.tcellopt SET WorkStation =  CASE Device_ID" & Environment.NewLine
            Dim strSql2 As String = "WorkStationEntryDt  = CASE Device_ID" & Environment.NewLine
            Dim whenCondition As String = ""
            Dim whereCondition As String = " WHERE Device_ID ="
            Dim iRet As Integer = 0

            Try
                'If IDs.Rows.Count > 300 Then


                'Else
                '    For Each row In IDs.Rows
                '        strSql1 &= "  WHEN '" & row.Item("Device_ID") & "' THEN  " & row("SODetailsID")
                '        strSql2 &= "  WHEN '" & row.Item("Device_ID") & "' THEN  " & strDatetime
                '        whereCondition &= row.Item("Device_ID") & ","
                '    Next


                '    'strSql &= strSql1& strSql2 & " END," & strSql_Three & strSql_Four & " END"
                '    'strSql &= " WHERE SoHeaderID IN (" & strSoHeaderIDs & ");" & Environment.NewLine

                '    strSql &= strSql1 & strSql2 & whenCondition & "WHERE WI_ID in (" & whereCondition & ") AND SODetailsID = 0 "
                '    Me._objDataProc.ExecuteNonQuery(strSql)

                'End If
                For Each row In IDs.Rows
                    strSql = "UPDATE production.tcellopt SET WorkStation = '" & strWorkStation & "', WorkStationEntryDt = '" & strDatetime & "' WHERE Device_ID = " & row.Item("Device_ID") & " ;" & Environment.NewLine
                    iRet = Me._objDataProc.ExecuteNonQuery(strSql)
                Next



            Catch ex As Exception
                Throw ex
            End Try

            Return iRet
        End Function

        Public Function UpdatetWorkorder(ByVal poNumber As String)

            Dim strSql As String = ""
            Dim iRet As Integer = 0

            Try
                strSql = "UPDATE production.tworkorder SET WO_Closed = 1 WHERE WO_CustWO ='" & poNumber & "';" & Environment.NewLine
                iRet = Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try

            Return iRet
        End Function

        Public Function PrintPackingLabel(ByVal dtPackingData As DataTable, ByVal iCopyNumber As Integer) As Integer
            Const strReportName As String = "TF_FK_Packing.rpt"
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

        Public Function getPackingSlipData(ByVal PickRun As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT IF(Cust_Name2 is null, Cust_Name1, CONCAT(Cust_Name1, ' ', Cust_Name2)) AS 'CustomerName'" & Environment.NewLine
                strSql &= ", A.CustomerAddress1 AS 'Address1', A.CustomerAddress2 AS 'Address2', A.CustomerCity AS 'City', A.CustomerState AS 'State'" & Environment.NewLine
                strSql &= ", A.CustomerPostalCode As 'ZipCode', A.CustomerCountry AS 'Country', A.PODate AS 'OrderDate', A.PONumber AS 'OrderNo'" & Environment.NewLine
                strSql &= ", A.PickRunNo AS 'Job', B.ItemCode AS 'Item', B.ProductName AS 'ItemDesc', B.Quantity AS 'ItemQty','' AS 'Other1'" & Environment.NewLine
                strSql &= ", '' AS 'Other2', 0 AS 'OtherNo1', 0 AS 'OtherNo2', 0 AS 'OtherNo3', 0 AS 'OtherNo4'" & Environment.NewLine
                strSql &= "FROM saleorders.SoHeader A" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.SoDetails B ON A.SoHeaderID=B.SoheaderID" & Environment.NewLine
                strSql &= "INNER JOIN production.tcustomer C ON A.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= "WHERE(A.iDataSet_ID = 1 And A.ShipDate Is Null)" & Environment.NewLine
                strSql &= "AND A.PickRunNo = '" & PickRun & "'" & Environment.NewLine
                strSql &= "Order BY SoDetailsID;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function getSSCC18Part(Optional ByRef iSSCC_Part As Integer = 0) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""
            Dim iSeed As Integer = 0
            Dim iPKey As Integer = 0
            Dim iLen As Integer = 9
            Dim pad As Char = "0"c

            Try
                'SSCC_Part, SSCC_Full, Seed
                strSql = "SELECT * from saleorders.SSCC18BarCodes ORDER BY Seed Desc;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    iSeed = Convert.ToInt32(dt.Rows(0).Item("Seed")) + 1
                Else
                    iSeed = 1
                End If

                strSql = "INSERT INTO saleorders.SSCC18BarCodes (SEED) VALUES (" & iSeed & ");"
                iPKey = Me._objDataProc.GetLastInsertedPrimaryKey(strSql, "saleorders.SSCC18BarCodes")

                iSSCC_Part = iPKey

                If iPKey.ToString.Length >= iLen Then
                    strRet = Microsoft.VisualBasic.Right(iPKey.ToString, iLen)
                Else
                    strRet = iPKey.ToString.PadLeft(iLen, pad)
                End If

                Return strRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UpdateSSCC18Full(ByVal iSSCC_Part As Integer, ByVal strSSCC18 As String) As Integer
            Dim strSql As String = ""

            Try
                'SSCC_Part, SSCC_Full, Seed
                strSql = "UPDATE saleorders.SSCC18BarCodes SET SSCC_Full = '" & strSSCC18 & "' WHERE SSCC_Part=" & iSSCC_Part.ToString & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                ' Throw ex
            End Try
        End Function
    End Class
End Namespace
