Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class MobilioRec
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

#End Region


        '***********************************************************************************************************************************
        Public Function GetHoldItems(ByVal strPCName As String, ByVal booAll As Boolean) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_DeviceID as 'Device ID', A.item_esn_imei as 'ESN/IMEI', B.DCode_LDesc as 'Status', N.DCode_LDesc as 'New Status' " & Environment.NewLine
                strSql &= ", if(O.ReportFieldName is null, '', O.ReportFieldName) as 'Hold Reason' " & Environment.NewLine
                strSql &= ", user_fullname as 'Receiver', A.ReceivedPCName as 'Received Work Station' " & Environment.NewLine
                strSql &= ", C.DCode_LDesc as 'OEM', D.DCode_LDesc as 'Model' " & Environment.NewLine
                strSql &= ", E.DCode_LDesc as 'Carrier' " & Environment.NewLine
                strSql &= ", F.DCode_LDesc as 'FindMyiPhone', G.DCode_LDesc as 'Carrier Lock' " & Environment.NewLine
                strSql &= ", H.DCode_LDesc as 'Condition', I.DCode_LDesc as 'Memory'" & Environment.NewLine
                strSql &= ", J.DCode_LDesc as 'Color', K.DCode_LDesc as 'ESN/IMEI Checked'" & Environment.NewLine
                strSql &= ", L.DCode_LDesc as 'Batt. Door Present' " & Environment.NewLine
                strSql &= ", M.DCode_LDesc as 'Batt. Present' " & Environment.NewLine
                strSql &= ", tmb_deviceasn.item_discrepant_template_id as 'Descrepancy Template', A.item_sku as 'Sku' " & Environment.NewLine
                strSql &= "FROM tmb_device A " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers On A.ReceivedUserID = security.tusers.User_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmb_deviceasn On A.mb_DeviceID = tmb_deviceasn.mb_DeviceID " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail B ON A.action_id = B.DCode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail C ON A.item_oem_id = C.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON A.item_model_id = D.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail E ON A.item_carrier_id = E.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail F ON A.item_findmyiphone_id = F.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail G ON A.item_carrier_lock_id = G.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail H ON A.item_condition_id = H.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail I ON A.item_memory_id = I.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail J ON A.item_color_id = J.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail K ON A.item_esn_imei_check_id = K.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail L ON A.item_batterydoor_present_id = L.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail M ON A.item_battery_present_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail N ON A.response_action_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmb_devicediscrepancy O ON A.mb_DeviceID = O.mb_DeviceID " & Environment.NewLine
                strSql &= "WHERE B.DCode_LDesc = 'HOLD' " & Environment.NewLine
                If booAll = False Then strSql &= "AND A.ReceivedPCName = '" & strPCName & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function AddItemToTote(ByVal iDeviceID As Integer, ByVal iToteID As Integer, ByVal iInitialActionID As Integer, ByVal booUpdStatusToNewStatus As Boolean _
                                      , ByVal strSku As String) As Integer
            Dim strSql As String = ""
            Dim iToteItemSeqID As Integer

            Try
                iToteItemSeqID = Me.GetToteItemReceiving_SquenceNumber(iToteID)

                strSql = "UPDATE tmb_device SET mb_tote_id = " & iToteID & ", Tote_Item_SeqNo = " & iToteItemSeqID & Environment.NewLine
                If iInitialActionID > 0 Then strSql &= ", initial_action_id = " & iInitialActionID & Environment.NewLine
                If booUpdStatusToNewStatus Then strSql &= ", action_id = response_action_id " & Environment.NewLine
                If strSku.Trim.Length > 0 Then strSql &= ", item_sku = '" & strSku & "' " & Environment.NewLine
                strSql &= "WHERE mb_DeviceID = " & iDeviceID & Environment.NewLine
                If booUpdStatusToNewStatus Then strSql &= " AND response_action_id > 0 " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function SetOrderToBeReadyForReturn(ByVal iOrderID As Integer) As Integer
            Dim strSql As String = ""
            Dim booHasReturn As Boolean = False, booHasHoldItem As Boolean = False

            Try
                booHasReturn = Me.HasReturnItems(iOrderID)
                booHasHoldItem = Me.HasHoldItems(iOrderID)

                If booHasReturn AndAlso booHasHoldItem = False Then
                    strSql = "UPDATE tmb_order SET HasReturn = 1, ReadyToShip = 1 " & Environment.NewLine
                    strSql &= "WHERE mb_OrderID = " & iOrderID & Environment.NewLine
                    Return Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    Return 1
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetOpenOrderInbound(ByVal iCustID As Integer, Optional ByVal iOrderID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT mb_OrderID, po_number as 'PO', number_of_items as 'Qty', shipment_transaction_ID as 'Shipment Trans ID'" & Environment.NewLine
                strSql &= ", carrier as 'Ship Carrier', tracking_number AS 'Tracking No'" & Environment.NewLine
                strSql &= ", ship_from_name as 'Name', ship_from_address as 'Address', ship_from_city as 'City'" & Environment.NewLine
                strSql &= ", ship_from_state as 'State', ship_from_zipcode as 'Zip' " & Environment.NewLine
                strSql &= "FROM tmb_order " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND OrderType = 1 AND CompletedItemRecDate is null AND closed = 0 " & Environment.NewLine
                If iOrderID > 0 Then strSql &= "AND mb_OrderID = " & iOrderID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function ReceiveOrder(ByVal iOrderID As Integer, ByVal iOrderQty As Integer, ByVal iActualQty As Integer, _
                                      ByVal iDamageOnArrival As Integer, ByVal iUserID As Integer, ByVal strRA As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer, iExtra As Integer, iRemoveCnt As Integer = 0, j As Integer = 0, iAddDeviceCnt As Integer, iDiscrepantOrder As Integer = 0
            Dim dtExistingDev As DataTable, dt As DataTable

            Try
                '*****************************************************
                '1: Remove all extra device. should NEVER HAPPEN
                '*****************************************************
                dtExistingDev = GetDevicesByInboundOrder(iOrderID)
                dtExistingDev.DefaultView.Sort = "mb_DeviceID DESC"
                If dtExistingDev.Rows.Count > iActualQty Then
                    iExtra = Math.Abs(iActualQty - dtExistingDev.Rows.Count)
                    i = dtExistingDev.Rows.Count - 1
                    While i >= 0
                        strSql = "SELECT * FROM tmb_deviceasn WHERE mb_OrderID = " & iOrderID & " AND mb_DeviceID = " & dtExistingDev.Rows(i)("mb_DeviceID") & Environment.NewLine
                        dt = Me._objDataProc.GetDataTable(strSql)
                        If dt.Rows.Count = 0 Then
                            iRemoveCnt += 1
                            strSql = "DELETE FROM tmb_device WHERE mb_DeviceID = " & dtExistingDev.Rows(i)("mb_DeviceID") & Environment.NewLine
                            j = Me._objDataProc.ExecuteNonQuery(strSql)
                            If j = 0 Then Throw New Exception("System has failed to remove extra device.")
                        End If

                        i += 1

                        If iRemoveCnt = iExtra Then Exit While
                    End While
                End If

                '*****************************************************
                '2: Verify extra device again. should NEVER HAPPEN
                '*****************************************************
                dtExistingDev = GetDevicesByInboundOrder(iOrderID)
                If dtExistingDev.Rows.Count > iActualQty Then Throw New Exception("There are extra device that can't remove. Please contact IT.")

                '*****************************************************
                '3: Create Device
                '*****************************************************
                iAddDeviceCnt = iActualQty - dtExistingDev.Rows.Count
                For i = 1 To iAddDeviceCnt
                    j = CreateDevice(iOrderID, iUserID)
                    If j = 0 Then Throw New Exception("System has failed to create device.")
                Next i

                '*****************************************************
                '4: Close Order
                '*****************************************************
                If (iOrderQty - iActualQty) <> 0 OrElse iDamageOnArrival = 1 Then iDiscrepantOrder = 1
                j = CloseOrder(iOrderID, iActualQty, iDamageOnArrival, iDiscrepantOrder, iUserID)
                '*****************************************************
                '5: Print Label
                '*****************************************************
                dt = Me.GetDevicesByInboundOrder(iOrderID)
                For i = 0 To dt.Rows.Count - 1
                    PrintOrderRecDeviceLabel(dt.Rows(i)("mb_DeviceID"), i + 1, dt.Rows.Count, strRA) ' dt.Rows(i)("shipment_transaction_id"))
                Next i

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtExistingDev) : Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetDevicesByInboundOrder(ByVal iInboundOrder As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tmb_device WHERE mb_OrderID_Inbound = " & iInboundOrder & " ORDER BY mb_DeviceID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function CreateDevice(ByVal iInboundOrderID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO tmb_device ( mb_OrderID_Inbound, Device_CreatedDate, Device_CreatedUserID ) VALUES ( " & Environment.NewLine
                strSql &= iInboundOrderID & ", now() " & ", " & iUserID & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function CloseOrder(ByVal iOrderID As Integer, ByVal iActualQty As Integer, ByVal iDamagedOnArrival As Integer, _
                                   ByVal iDiscrepantOrder As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "Update tmb_order " & Environment.NewLine
                strSql &= "SET discrepancyflag = " & iDiscrepantOrder & ", closed = 1, OrderRecQty = " & iActualQty & Environment.NewLine
                strSql &= ", OrderRecDate = now(), OrderRecUserID = " & iUserID & ", DamagedOnArrival = " & iDamagedOnArrival & Environment.NewLine
                If iActualQty = 0 Then strSql &= ", CompletedItemRecDate = now(), CompletedItemRecUserID = " & iUserID & Environment.NewLine
                strSql &= "WHERE mb_OrderID = " & iOrderID & " AND closed = 0 AND OrderRecDate is null " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function PrintOrderRecDeviceLabel(ByVal iDeviceID As Integer, ByVal iItemNo As Integer, _
                                                 ByVal iTotalNo As Integer, ByVal strRA As String) As Integer
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim strSQL As String

            Try
                strSQL = "Select if (length(" & iDeviceID.ToString & ") >9, " & iDeviceID.ToString & ", lpad(" & iDeviceID.ToString & ",9,'0')) as UnitID" & Environment.NewLine
                strSQL &= "," & iItemNo.ToString & " as itemNum," & iTotalNo.ToString & " as itemTotal,'" & strRA & "' as RAnum" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Mobilio_Order_Recv.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(1, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***********************************************************************************************************************************
        Public Function PrintToteItemRecDeviceLabel(ByVal iDeviceID As Integer) As Integer ' ByVal iToteID As Integer, _
            'ByVal iToteItemSeqNo As Integer, ByVal strSku As String, _
            'ByVal strSN As String, ByVal strIMEI As String, _
            'ByVal strOEM As String, ByVal strModel As String, _
            'ByVal strCarrierLock As String, ByVal strCondition As String, _
            'ByVal strMemory As String, ByVal strColor As String, _
            'ByVal strRA As String, ByVal strRecDate As String) As Integer
            Dim dt As DataTable
            Dim objRpt As ReportDocument
            Dim strSQL As String

            Try
                strSQL = "select if(length(A.mb_deviceID)>9, cast(A.mb_deviceID as char), lpad(A.mb_deviceID,9,'0')) as 'DeviceID'" & Environment.NewLine
                strSQL &= ", if(length(A.Mb_Tote_ID)>9, cast(A.Mb_Tote_ID as char), lpad(A.Mb_Tote_ID,9,'0')) as 'BoxID', cast(A.Tote_Item_SeqNo as char) as 'BoxRecNum'" & Environment.NewLine
                strSQL &= ", A.item_sku as 'SKUNo', A.item_esn_imei as 'EsnImei', E.Dcode_Ldesc as 'OEM'" & Environment.NewLine
                strSQL &= ", F.Dcode_Ldesc as 'Model', G.Dcode_Ldesc as 'LockStatus', H.Dcode_Ldesc as 'Condition'" & Environment.NewLine
                strSQL &= ", K.DCode_LDesc as 'Status', L.Dcode_Ldesc as 'Technology', M.Dcode_Ldesc as 'Carrier'  " & Environment.NewLine
                strSQL &= ", I.Dcode_Ldesc as 'Memory',J.Dcode_Ldesc as 'Color',B.Po_number as 'RANo',date_format(A.ReceivedDate, '%m-%d-%Y') as 'RecDate' " & Environment.NewLine
                strSQL &= " from tmb_device A" & Environment.NewLine
                strSQL &= " inner join tmb_order B on A.mb_orderid_inbound=B.mb_orderID" & Environment.NewLine
                strSQL &= "  LEFT OUTER join lcodesdetail E on A.item_oem_id=E.Dcode_ID" & Environment.NewLine
                strSQL &= "  LEFT OUTER join lcodesdetail F on A.item_model_id=F.Dcode_ID" & Environment.NewLine
                strSQL &= "  LEFT OUTER join lcodesdetail G on A.item_carrier_lock_id=G.Dcode_ID" & Environment.NewLine
                strSQL &= "  LEFT OUTER join lcodesdetail H on A.item_condition_id=H.Dcode_ID" & Environment.NewLine
                strSQL &= "  LEFT OUTER join lcodesdetail I on A.item_memory_id=I.Dcode_ID" & Environment.NewLine
                strSQL &= "  LEFT OUTER join lcodesdetail J on A.item_color_id=J.Dcode_ID" & Environment.NewLine
                strSQL &= " inner join lcodesdetail K on A.action_id = K.Dcode_ID" & Environment.NewLine
                strSQL &= " LEFT OUTER join lcodesdetail L on A.item_technology_id = L.Dcode_ID" & Environment.NewLine
                strSQL &= " LEFT OUTER join lcodesdetail M on A.item_carrier_id = M.Dcode_ID" & Environment.NewLine
                strSQL &= "  where mb_deviceID=" & iDeviceID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not dt.Rows.Count > 0 Then
                    Throw New Exception("No data for this device '" & iDeviceID.ToString & "'.")
                Else
                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Data.ConfigFile.GetBaseReportPath & "Mobilio Item Rec.rpt")
                        If Not IsNothing(dt) Then .SetDataSource(dt)
                        .Refresh()
                        .PrintToPrinter(1, True, 0, 0)
                    End With
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetOpenItemReceiveOrders(ByVal iCustID As Integer) As DataTable
            Try
                Dim strSql As String = ""

                Try
                    strSql = "SELECT A.mb_OrderID as 'Order ID', A.po_number as 'PO', A.number_of_items as 'PO Qty', A.OrderRecQty as 'Shipment Qty', count(ReceivedDate) as 'Item Rec Qty' " & Environment.NewLine
                    strSql &= ", A.OrderRecDate, A.mb_OrderID " & Environment.NewLine
                    'strSql &= ", shipment_transaction_ID as 'Shipment Trans ID'" & Environment.NewLine
                    strSql &= "FROM tmb_order A" & Environment.NewLine
                    strSql &= "INNER JOIN tmb_device B ON A.mb_OrderID = B.mb_OrderID_Inbound " & Environment.NewLine
                    strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.OrderType = 1 AND A.OrderRecDate is not null AND A.closed = 1 " & Environment.NewLine
                    strSql &= "AND A.CompletedItemRecDate is null " & Environment.NewLine
                    strSql &= "GROUP BY B.mb_OrderID_Inbound "
                    Return Me._objDataProc.GetDataTable(strSql)
                Catch ex As Exception
                    Throw ex
                End Try
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetOpenTotes(Optional ByVal strPCName As String = "") As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_Tote_ID as 'Tote ID', Tote_Name as 'Tote Name', A.PC_Name as 'Created @ Work Station'" & Environment.NewLine
                strSql &= ", A.CreatedDate as 'Created Date', B.User_FullName as 'Created By', count(C.mb_DeviceID) as Qty" & Environment.NewLine
                strSql &= "FROM tmb_tote A INNER JOIN security.tusers B ON A.CreatedUserID = B.User_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmb_device C ON A.mb_Tote_ID = C.mb_Tote_ID "
                strSql &= "WHERE A.Closed = 0 " & Environment.NewLine
                If strPCName.Trim.Length > 0 Then strSql &= " AND PC_Name = '" & strPCName.Trim & "'" & Environment.NewLine
                strSql &= "GROUP BY A.mb_Tote_ID"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetDeviceData(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_DeviceID as DeviceID, A.mb_OrderID_Inbound, A.ReceivedDate, A.ShippedDate, A.mb_Tote_ID, A.ReceivedPCName, A.mb_MP_ID" & Environment.NewLine
                strSql &= ", A.PutAway_Location, A.initial_action_id, A.action_id, D.DCode_LDesc as 'Status', A.response_action_id, E.DCode_LDesc as 'NewStatus' " & Environment.NewLine
                strSql &= ", B.po_number, B.closed, B.number_of_items as 'OrderQty', B.OrderRecQty as 'ShipmentQty', B.CompletedItemRecDate, B.DamagedOnArrival, C.*" & Environment.NewLine
                strSql &= ", A.item_oem_id as RecOemID, A.item_model_id as RecModelID, A.item_carrier_id as RecCarrierID, A.item_color_id as RecColorID " & Environment.NewLine
                strSql &= ", A.item_memory_id as RecMemID, A.item_condition_id as RecConditionID, A.item_findmyiphone_id as RecFindMyIphone, A.item_sku as 'RecSku' " & Environment.NewLine
                strSql &= ", A.item_carrier_lock_id as RecCarrierLockID, A.mb_Pallet_ID "
                strSql &= "FROM tmb_device A" & Environment.NewLine
                strSql &= "INNER JOIN tmb_order B ON A.mb_OrderID_Inbound = B.mb_OrderID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmb_deviceasn C ON A.mb_DeviceID = C.mb_DeviceID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON A.action_id = D.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail E ON A.response_action_id = E.DCode_ID" & Environment.NewLine
                strSql &= "WHERE A.mb_DeviceID = " & iDeviceID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetItemRecQty(ByVal iOrderID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Count(*) as Qty FROM tmb_device " & Environment.NewLine
                strSql &= "WHERE mb_OrderID_Inbound = " & iOrderID & " AND ReceivedDate is not null "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetOrderDetails(ByVal iOrderID As Integer) As DataTable
            Dim strSql As String = "" '

            Try
                strSql = "SELECT mb_AsnID as 'Record ID', item_esn_imei as 'ESN/IMEI' " & Environment.NewLine
                strSql &= ", item_oem_id, B.DCode_LDesc as 'OEM', item_model_id, C.DCode_LDesc as 'Model' " & Environment.NewLine
                strSql &= ", item_carrier_id, D.DCode_LDesc as 'Carrier' " & Environment.NewLine
                strSql &= ", item_findmyiphone_id, IF(E.DCode_LDesc IS NULL, '', E.DCode_LDesc IS NULL) as 'FindMyiPhone'" & Environment.NewLine
                strSql &= ", item_carrier_lock_id, F.DCode_LDesc as 'Carrier Lock' " & Environment.NewLine
                strSql &= ", item_condition_id, G.DCode_LDesc as 'Condition', item_memory_id, H.DCode_LDesc as 'Memory'" & Environment.NewLine
                strSql &= ", item_color_id, I.DCode_LDesc as 'Color', item_esn_imei_check_id, J.DCode_LDesc as 'ESN/IMEI Checked'" & Environment.NewLine
                strSql &= ", item_batterydoor_present_id, K.DCode_LDesc as 'Batt. Door Present' " & Environment.NewLine
                strSql &= ", item_battery_present_id, L.DCode_LDesc as 'Batt. Present' " & Environment.NewLine
                strSql &= ", item_discrepant_template_id as 'Descrepancy Template', mb_DeviceID as 'Device ID'" & Environment.NewLine
                strSql &= ", mb_OrderID, item_transaction_id, item_transaction_type, item_id  " & Environment.NewLine
                strSql &= "FROM tmb_deviceasn A " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail B ON A.item_oem_id = B.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail C ON A.item_model_id = C.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail D ON A.item_carrier_id = D.Dcode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail E ON A.item_findmyiphone_id = E.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_OrderID = " & iOrderID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetASNItem(ByVal iOrderID As Integer, Optional ByVal strEsnImei As String = "") As DataTable
            Dim strSql As String = "", strCondVal As String = ""

            Try
                strSql = "SELECT A.* , B.OrderRecDate , B.CompletedItemRecDate " & Environment.NewLine
                'strSql &= ", C.DCode_LDesc as 'OEM', D.DCode_LDesc as 'Model' E.DCode_LDesc as 'Carrier', D.DCode_LDesc as 'Model'" & Environment.NewLine
                strSql &= "FROM tmb_deviceasn A " & Environment.NewLine
                strSql &= "INNER JOIN tmb_order B ON A.mb_OrderID = B.mb_OrderID " & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail C ON A.item_oem_id = C.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail D ON A.item_model_id = D.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail E ON A.item_carrier_id = E.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail F ON A.item_findmyiphone_id = F.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail G ON A.item_carrier_lock_id = G.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail H ON A.item_condition_id = H.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail I ON A.item_memory_id = I.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail J ON A.item_color_id = J.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail K ON A.item_esn_imei_check_id = K.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail L ON A.item_batterydoor_present_id = L.Dcode_ID" & Environment.NewLine
                'strSql &= "INNER JOIN lcodesdetail M ON A.item_battery_present_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_OrderID = " & iOrderID & Environment.NewLine
                If strEsnImei.Trim.Length > 0 Then strSql &= " AND item_esn_imei = '" & strEsnImei & "'"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetDiscrepancyTemplate(ByVal strDiscrepancyTemplated As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.discrepant_template_id, B.*, C.DCode_LDesc as 'Action_Desc', D.Dcode_LDesc as 'TemplateVal'" & Environment.NewLine
                strSql &= "FROM tmb_discrepanttemplate A INNER JOIN tmb_discrepanttemplatedetails B ON A.DCP_ID = B.DCP_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail C ON B.Action_ID = C.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON B.Desc_ID = D.Dcode_ID" & Environment.NewLine
                strSql &= "WHERE A.discrepant_template_id = '" & strDiscrepancyTemplated & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function CreateToteID(ByVal iUserID As Integer, ByVal strPCName As String) As Integer
            Dim iToteID As Integer = 0, iNumberLength As Integer = 4
            Dim strSql As String = "", strToteName As String = "", strToday As String = ""
            Dim dt As DataTable

            Try
                dt = Me.GetOpenTotes(strPCName)
                If dt.Rows.Count = 0 Then
                    strToday = CDate(Generic.MySQLServerDateTime(1)).ToString("yyyyMMdd")

                    '***************************************
                    'Create Tote Name
                    '***************************************
                    strToteName = strToday & strPCName.Trim.ToUpper & "N"

                    strSql = "SELECT max(right(Tote_Name, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
                    strSql &= "FROM tmb_tote " & Environment.NewLine
                    strSql &= "WHERE Tote_Name like '" & strToteName & "%' " & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
                            strToteName &= dt.Rows(0)("NextSequenceNumber").ToString.Trim.PadLeft(iNumberLength, "0")
                        Else
                            strToteName &= "1".PadLeft(iNumberLength, "0")
                        End If
                    Else
                        strToteName &= "1".PadLeft(iNumberLength, "0")
                    End If
                    '***************************************

                    strSql = "INSERT INTO tmb_tote ( Tote_Name, PC_Name, CreatedDate, CreatedUserID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strToteName & "', '" & strPCName & "', " & "now(), " & iUserID & Environment.NewLine
                    strSql &= ") "

                    iToteID = Me._objDataProc.idTransaction(strSql, "tmb_tote")

                    If iToteID = 0 Then Throw New Exception("System has failed to create Tote ID.")
                ElseIf dt.Rows.Count = 1 Then
                    iToteID = dt.Rows(0)("Tote ID")
                Else
                    Throw New Exception("There are more than one open Totes. Please contact IT.")
                End If

                Return iToteID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetSKU(ByVal iOEMID As Integer, ByVal iModelID As Integer, ByVal iCarrierID As Integer, ByVal iColorID As Integer _
                               , ByVal iMemoryID As Integer, ByVal iConditionID As Integer, ByVal iFindiPhoneID As Integer, ByVal iCarrierLockID As Integer) As String
            Dim strSql As String
            Try
                strSql = "SELECT mb_Sku FROM tmb_sku WHERE OEM_ID = " & iOEMID & " AND Model_ID = " & iModelID & " AND Carrier_ID = " & iCarrierID & Environment.NewLine
                strSql &= " AND Color_ID = " & iColorID & " AND Memory_ID = " & iMemoryID & " AND Condition_ID = " & iConditionID & " AND Find_iPhone_ID = " & iFindiPhoneID & Environment.NewLine
                strSql &= " AND Carrier_Lock_ID = " & iCarrierLockID & Environment.NewLine
                strSql &= " AND Active = 1"
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function SaveItemReceiveData(ByVal strPCName As String, ByVal iUserID As Integer, ByVal iOrderID As Integer, ByVal iShipmentQty As Integer, ByVal iToteID As Integer _
                                            , ByVal iDeviceID As Integer, ByVal iDiscpFlag As Integer, ByVal iAsnID As Integer, ByVal strInEsnImei As String, ByVal strExEsnImei As String _
                                            , ByVal iEsnImeiTampered As Integer, ByVal iOemID As Integer, ByVal iModelID As Integer, ByVal iTechnID As Integer, ByVal iCarrierID As Integer _
                                            , ByVal iFindMyIphoneID As Integer, ByVal iCarrierLockUnLocID As Integer, ByVal iCondID As Integer, ByVal iMemmoryID As Integer _
                                            , ByVal iColorID As Integer, ByVal iEsnImeiCheckedID As Integer, ByVal iBattDoorPresentID As Integer, ByVal iBattPresentID As Integer _
                                            , ByVal iDispositionID As Integer, ByVal iDataWipe As Integer, ByVal strSKU As String, ByVal strDiscpRptFieldName As String _
                                            , ByVal iDiscpRptDispositionID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer, iItemRecQty As Integer = 0
            Dim iToteItemSeqID As Integer = 0

            Try
                If iToteID > 0 Then iToteItemSeqID = Me.GetToteItemReceiving_SquenceNumber(iToteID)

                'capture received data
                strSql = "UPDATE tmb_device SET "
                strSql &= "item_oem_id = " & iOemID & ", item_model_id = " & iModelID & ", item_technology_id = " & iTechnID & Environment.NewLine
                strSql &= ", item_carrier_id = " & iCarrierID & ", item_findmyiphone_id = " & iFindMyIphoneID & ", item_esn_imei = '" & strInEsnImei & "'" & Environment.NewLine
                strSql &= ", item_esn_imei_External = '" & strExEsnImei & "', item_esn_imei_tampered = " & iEsnImeiTampered & Environment.NewLine
                strSql &= ", item_carrier_lock_id = " & iCarrierLockUnLocID & ", item_condition_id = " & iCondID & ", item_memory_id = " & iMemmoryID & Environment.NewLine
                strSql &= ", item_color_id = " & iColorID & ", item_esn_imei_check_id = " & iEsnImeiCheckedID & Environment.NewLine
                strSql &= ", item_batterydoor_present_id = " & iBattDoorPresentID & ", item_battery_present_id = " & iBattPresentID & Environment.NewLine
                strSql &= ", item_data_wipe = " & iDataWipe & Environment.NewLine
                strSql &= ", action_id = " & iDispositionID & ", discrepancyflag = " & iDiscpFlag & ", ReceivedDate = now()" & Environment.NewLine
                strSql &= ", ReceivedUserID = " & iUserID & ", ReceivedPCName = '" & strPCName & "', mb_Tote_ID = " & iToteID & ", item_Sku = '" & strSKU & "', tote_item_SeqNo= " & iToteItemSeqID & Environment.NewLine
                strSql &= "WHERE mb_DeviceID = " & iDeviceID & " AND ReceivedDate is null " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("SaveItemReceiveData() : System has failed to save data for device id " & iDeviceID & ".")

                'tie receive data with asn data
                If iAsnID > 0 Then
                    strSql = "UPDATE tmb_deviceasn SET mb_DeviceID = " & iDeviceID & ", item_Sku = '" & strSKU & "' " & Environment.NewLine
                    strSql &= "WHERE mb_AsnID = " & iAsnID & " AND mb_DeviceID = 0" & Environment.NewLine
                Else
                    strSql = "INSERT INTO tmb_deviceasn ( mb_OrderID, item_sku, mb_DeviceID ) VALUES ( "
                    strSql &= iOrderID & ", '" & strSKU & "', " & iDeviceID & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                End If

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("SaveItemReceiveData() : System has failed to save device id to asn table.")

                'Close other if all item had received
                iItemRecQty = GetItemRecQty(iOrderID)

                If iItemRecQty = iShipmentQty Then
                    i = CloseItemReceiveOrder(iOrderID, iUserID)
                End If

                'write discrepancy data
                If iDiscpFlag = 1 Then
                    strSql = "INSERT INTO tmb_devicediscrepancy ( mb_DeviceID, ReportFieldName, action_id, CreatedDate, CreatedUserID " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iDeviceID & ", '" & strDiscpRptFieldName & "', " & iDiscpRptDispositionID & ", now(), " & iUserID & Environment.NewLine
                    strSql &= ") "
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("SaveItemReceiveData() : System has failed to save device discrepancy data.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function CloseItemReceiveOrder(ByVal iOrderID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim iItemRecQty, iShipmentQty, i, iDiscrepancyFlag, iMissingItem, iHasReturn As Integer
            Dim dt As DataTable
            Dim booHasHoldItem As Boolean = False

            Try
                strSql = "SELECT * FROM tmb_order WHERE mb_OrderID = " & iOrderID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Order ID " & iOrderID & " does not exist.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Order ID " & iOrderID & " existed more than one.")
                ElseIf IsDBNull(dt.Rows(0)("OrderRecDate")) Then
                    Throw New Exception("Order ID " & iOrderID & " has not yet received.")
                ElseIf Not IsDBNull(dt.Rows(0)("CompletedItemRecDate")) Then
                    Throw New Exception("Order ID " & iOrderID & " has been completed item receive.")
                Else
                    booHasHoldItem = Me.HasHoldItems(iOrderID)
                    If Me.HasReturnItems(iOrderID) Then iHasReturn = 1 Else iHasReturn = 0
                    iShipmentQty = CInt(dt.Rows(0)("OrderRecQty"))
                    iItemRecQty = GetItemRecQty(iOrderID)
                    iDiscrepancyFlag = dt.Rows(0)("discrepancyflag")
                    If iDiscrepancyFlag = 0 AndAlso Me.HasDiscrepancyItems(iOrderID) = True Then iDiscrepancyFlag = 1

                    If iItemRecQty > iShipmentQty Then
                        Throw New Exception("Receipt quantity has exceeded shipment quantity. Please verify with your suppervisor.")
                    ElseIf iItemRecQty < iShipmentQty Then
                        Throw New Exception("Can't close partial order.")
                    ElseIf iItemRecQty = iShipmentQty Then
                        If iDiscrepancyFlag = 0 Then
                            strSql = "SELECT count(*) FROM tmb_deviceasn WHERE mb_OrderID = " & iOrderID & " AND mb_DeviceID = 0 " & Environment.NewLine
                            iMissingItem = Me._objDataProc.GetIntValue(strSql)
                            If iMissingItem > 0 Then iDiscrepancyFlag = 1
                        End If

                        'Close order
                        strSql = "UPDATE tmb_order SET CompletedItemRecDate = now(), CompletedItemRecUserID = " & iUserID & ", discrepancyflag = " & iDiscrepancyFlag & Environment.NewLine
                        strSql &= ", HasReturn = " & iHasReturn & Environment.NewLine
                        If booHasHoldItem = False AndAlso iHasReturn > 0 Then strSql &= ", ReadyToShip = 1 " & Environment.NewLine 'Ready to ship return item
                        strSql &= "WHERE mb_OrderID = " & iOrderID & " AND CompletedItemRecDate is null " & Environment.NewLine
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                        If i = 0 Then Throw New Exception("System has failed to save data.")
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("CloseItemReceiveOrder() : " & ex.Message)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function HasDiscrepancyItems(ByVal iOrderID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Max(A.discrepancyflag) as OrderDiscpFlag, Max(B.discrepancyflag) as ItemDiscpFlag " & Environment.NewLine
                strSql &= "FROM tmb_order A " & Environment.NewLine
                strSql &= "INNER JOIN tmb_device B ON A.mb_OrderID = B.mb_OrderID_Inbound " & Environment.NewLine
                strSql &= "WHERE A.mb_OrderID = " & iOrderID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return False
                ElseIf CInt(dt.Rows(0)("OrderDiscpFlag")) > 0 OrElse CInt(dt.Rows(0)("ItemDiscpFlag")) > 0 Then
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function HasReturnItems(ByVal iOrderID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT Count(*) as Cnt " & Environment.NewLine
                strSql &= "FROM tmb_order A INNER JOIN tmb_device B ON A.mb_OrderID = B.mb_OrderID_Inbound " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail C ON B.action_id = C.DCode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_OrderID = " & iOrderID & " AND C.DCode_LDesc = 'RETURN' " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function HasHoldItems(ByVal iOrderID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT Count(*) as Cnt " & Environment.NewLine
                strSql &= "FROM tmb_order A INNER JOIN tmb_device B ON A.mb_OrderID = B.mb_OrderID_Inbound " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail C ON B.action_id = C.DCode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_OrderID = " & iOrderID & " AND C.DCode_LDesc = 'HOLD' " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function CloseTote(ByVal iToteID As Integer, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim iToteQty, i As Integer
            Dim dt As DataTable

            Try
                dt = Me.GetToteInfo(iToteID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Tote ID " & iToteID & " does not exist.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Tote ID " & iToteID & " existed more than one.")
                ElseIf dt.Rows(0)("Closed").ToString.Trim = "1" Then
                    Throw New Exception("Tote ID " & iToteID & " is closed. Please refresh your screen.")
                ElseIf Not IsDBNull(dt.Rows(0)("ClosedDate")) Then
                    Throw New Exception("Tote ID " & iToteID & " is closed. Please refresh your screen.")
                Else
                    strSql = "SELECT count(*) FROM tmb_device WHERE mb_Tote_ID = " & iToteID
                    iToteQty = Me._objDataProc.GetIntValue(strSql)
                    If iToteQty = 0 Then Throw New Exception("Tote is empty.")

                    'Close tote
                    strSql = "UPDATE tmb_tote SET Closed = 1, ClosedDate = now(), ClosedUserID = " & iUserID & ", Tote_Quantity = " & iToteQty & Environment.NewLine
                    strSql &= "WHERE mb_Tote_ID = " & iToteID & " AND ClosedDate is null " & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to save data.")
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("CloseTote() : " & ex.Message)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetToteInfo(ByVal iToteID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT * FROM tmb_tote WHERE mb_Tote_ID = " & iToteID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetWIPDeviceOrderRecID_RANum(ByVal iDeviceID As Integer, ByRef strRA As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow
            Dim iRet As Integer = 0

            Try
                strSql = " select A.mb_OrderID_inbound,B.shipment_transaction_id,B.po_number " & Environment.NewLine
                strSql &= " from tmb_device A" & Environment.NewLine
                strSql &= " inner join tmb_order B on A.mb_OrderID_inbound=B.mb_orderID" & Environment.NewLine
                strSql &= " where A.ShippedDate is null and mb_deviceID=" & iDeviceID & " order by A.mb_OrderID_inbound;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows 'should be one if any
                    iRet = row("mb_OrderID_inbound")
                    strRA = row("po_number") '("shipment_transaction_id")
                    Exit For
                Next

                Return iRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***********************************************************************************************************************************
        Public Function GetToteItemReceiving_SquenceNumber(ByVal iToteID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim row As DataRow

            Try
                strSql = "select max(tote_item_SeqNo) from tmb_device where mb_tote_ID=" & iToteID & ";" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows(0).IsNull(0) Then 'if no data, it gives 1 row max(tote_item_SeqNo) =null
                    Return 1
                Else
                    Return dt.Rows(0).Item(0) + 1
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************


    End Class
End Namespace