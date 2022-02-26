Option Explicit On 

Namespace Buisness
    Public Class Mobilio_Reports
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
        Public Function GetWIPData(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                'strSql = "select B.po_number as 'RA No', B.OrderRecDate as 'Date Received', A.mb_Tote_ID as 'Work Center'" & Environment.NewLine
                'strSql &= ", A.item_esn_imei as 'ESN/IMEI', A.mb_deviceID as 'PSSI ID'" & Environment.NewLine
                'strSql &= " from tmb_device A" & Environment.NewLine
                'strSql &= " inner join tmb_order B on A.mb_OrderID_inbound = B.mb_orderID" & Environment.NewLine
                ''strSql &= " left join tmb_tote C on A.mb_Tote_id=C.mb_Tote_id" & Environment.NewLine
                strSql = "select B.po_number as 'RA No', B.OrderRecDate as 'Order Rec Date', Y.user_fullname as 'Order Rec User'" & Environment.NewLine
                strSql &= ", A.ReceivedDate as 'Item Rec Date', X.user_fullname as 'Item Rec User', B.CompletedItemRecDate as 'Item Completed Rec Date'" & Environment.NewLine
                strSql &= ", Z.user_fullname as 'ItemRec Completed User'" & Environment.NewLine
                strSql &= ", A.mb_Tote_ID as 'Tote ID', A.ReceivedPCName as 'Item Rec PC Name', A.Item_Sku as 'SKU' " & Environment.NewLine
                strSql &= ", A.item_esn_imei as 'ESN/IMEI', A.mb_deviceID as 'Device ID'" & Environment.NewLine
                strSql &= ", I.Dcode_LDesc as 'Status', Q.ReportFieldName as 'Discp Field', item_discrepant_template_id as 'Discp Template' " & Environment.NewLine
                strSql &= ", O.Dcode_LDesc as 'OEM'" & Environment.NewLine
                strSql &= ", C.Dcode_LDesc as 'Model' " & Environment.NewLine
                strSql &= ", D.Dcode_LDesc as 'Carrier'" & Environment.NewLine
                strSql &= ", E.Dcode_LDesc as 'Color'" & Environment.NewLine
                strSql &= ", F.Dcode_LDesc as 'Memory'" & Environment.NewLine
                strSql &= ", G.Dcode_LDesc as 'Condition'" & Environment.NewLine
                strSql &= ", H.Dcode_LDesc as 'Carrier Lock'" & Environment.NewLine
                strSql &= ", J.Dcode_LDesc as 'Find myiPhone'" & Environment.NewLine
                strSql &= ", K.Dcode_LDesc as 'Technology'" & Environment.NewLine
                strSql &= ", L.Dcode_LDesc as 'ESN/IMEI Check'" & Environment.NewLine
                strSql &= ", M.Dcode_LDesc as 'Battery Door Present'" & Environment.NewLine
                strSql &= ", N.Dcode_LDesc as 'Battery Present'" & Environment.NewLine
                strSql &= ", P.Dcode_LDesc as 'Data Wipe'" & Environment.NewLine
                strSql &= ", B.ship_from_name as 'Ship From Name', B.ship_from_address as 'Ship From Address', B.ship_from_city as 'Ship From City'" & Environment.NewLine
                strSql &= ", B.ship_from_state as 'Ship From State', B.ship_from_zipcode as 'Ship From Zip'  " & Environment.NewLine
                strSql &= " from tmb_device A" & Environment.NewLine
                strSql &= " inner join tmb_order B on A.mb_OrderID_inbound = B.mb_orderID" & Environment.NewLine
                strSql &= " inner join tmb_deviceasn on A.mb_DeviceID = tmb_deviceasn.mb_DeviceID" & Environment.NewLine
                strSql &= " left join lcodesdetail C on A.item_model_id = C.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail D on A.item_carrier_id = D.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail E on A.item_color_id = E.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail F on A.item_memory_id = F.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail G on A.item_condition_id = G.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail H on A.item_carrier_lock_id = H.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail I on A.action_id = I.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail J on A.item_findmyiphone_id = J.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail K on A.item_technology_id = K.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail L on A.item_esn_imei_check_id = L.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail M on A.item_batterydoor_present_id = M.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail N on A.item_battery_present_id = N.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail O on A.item_OEM_id = O.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail P on A.item_data_wipe = P.dcode_id" & Environment.NewLine
                strSql &= " left join security.tusers X on A.ReceivedUserID=X.user_id" & Environment.NewLine
                strSql &= " left join security.tusers Y on B.OrderRecUserID=Y.user_id" & Environment.NewLine
                strSql &= " left join security.tusers Z on B.CompletedItemRecUserID= Z.user_id" & Environment.NewLine
                strSql &= " left join tmb_devicediscrepancy Q on A.mb_DeviceID = Q.mb_DeviceID" & Environment.NewLine

                strSql &= " where A.ShippedDate is null and B.Cust_ID =" & iCustID & ";" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetFinishedGoodsData(ByVal iCustID As Integer, ByVal strBegDTime As String, ByVal strEndDTime As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select A.item_esn_imei as 'ESN/IMEI', A.item_sku as 'Sku ID',A.mb_deviceID as 'PSSI ID'" & Environment.NewLine
                strSql &= ",C.Dcode_LDesc as 'Model',D.Dcode_LDesc as 'Carrier',E.Dcode_LDesc as 'Color',F.Dcode_LDesc as 'Memory'" & Environment.NewLine
                strSql &= ",G.Dcode_LDesc as 'Condition',H.Dcode_LDesc as 'Carrier Lock',date_format(Z.CreatedDate,'%Y-%m-%d') as 'Date Processed',A.mb_mp_id as 'Master Pack ID'" & Environment.NewLine
                strSql &= " from tmb_device A" & Environment.NewLine
                strSql &= " inner join tmb_order B on A.mb_OrderID_inbound=B.mb_orderID" & Environment.NewLine
                strSql &= " inner join tmb_masterpack Z on A.mb_mp_id=Z.mb_mp_id" & Environment.NewLine
                strSql &= " left join lcodesdetail C on A.item_model_id = C.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail D on A.item_carrier_id = D.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail E on A.item_color_id = E.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail F on A.item_memory_id = F.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail G on A.item_condition_id = G.dcode_id" & Environment.NewLine
                strSql &= " left join lcodesdetail H on A.item_carrier_lock_id = H.dcode_id" & Environment.NewLine
                strSql &= " where A.mb_MP_ID >0  and B.Cust_ID=" & iCustID & " and Z.CreatedDate between '" & strBegDTime & "' and '" & strEndDTime & "';" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetOpenOrderData(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT if(length(mb_OrderID )>9, cast(mb_OrderID  as char),lpad(mb_OrderID ,9,'0')) as 'Order ID', po_number as 'PO', number_of_items as 'Qty', shipment_transaction_ID as 'Shipment Trans ID'" & Environment.NewLine
                strSql &= " , carrier as 'Ship Carrier', tracking_number AS 'Tracking No'" & Environment.NewLine
                strSql &= " , ship_from_name as 'Name', ship_from_address as 'Address', ship_from_city as 'City'" & Environment.NewLine
                strSql &= " , ship_from_state as 'State', ship_from_zipcode as 'Zip','Inbound' as 'Order Type',Date_format(Loaded_DateTime,'%m/%d/%Y') as 'Received Date'" & Environment.NewLine
                strSql &= " FROM tmb_order" & Environment.NewLine
                strSql &= " WHERE Cust_ID = " & iCustID & " AND OrderType = 1 AND CompletedItemRecDate is null AND closed = 0" & Environment.NewLine
                strSql &= " Union All" & Environment.NewLine
                strSql &= " SELECT if(length(mb_OrderID )>9, cast(mb_OrderID  as char),lpad(mb_OrderID ,9,'0')) as 'Order ID', po_number as 'PO', number_of_items as 'Qty', shipment_transaction_ID as 'Shipment Trans ID'" & Environment.NewLine
                strSql &= " , carrier as 'Ship Carrier', tracking_number AS 'Tracking No'" & Environment.NewLine
                strSql &= " , ship_from_name as 'Name', ship_from_address as 'Address', ship_from_city as 'City'" & Environment.NewLine
                strSql &= " , ship_from_state as 'State', ship_from_zipcode as 'Zip','Outbound' as 'Order Type',Date_format(Loaded_DateTime,'%m/%d/%Y') as 'Received Date'" & Environment.NewLine
                strSql &= " FROM tmb_order" & Environment.NewLine
                strSql &= " WHERE Cust_ID = " & iCustID & " AND OrderType = 0 AND OrderShipDate is null AND closed = 0" & Environment.NewLine
                strSql &= " ORDER BY  'Order Type' Desc,'Order ID';" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function GetShippingData(ByVal iCustID As Integer, ByVal strBegDTime As String, ByVal strEndDTime As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.PO_number,if(length(B.mb_deviceID)>9, cast(B.mb_deviceID as char),lpad(B.mb_deviceID,9,'0')) as 'DeviceID'" & Environment.NewLine
                strSql &= " ,A.shipment_transaction_ID,C.item_transaction_id,F.Dcode_Ldesc as 'Status',B.item_sku as 'Sku'" & Environment.NewLine
                strSql &= " ,B.item_esn_imei as 'EsnImei',Date_format(B.shippeddate,'%m/%d/%Y') as 'ShipDate',D.User_Fullname as 'Shipped User',A.OutBoundTrackingNo" & Environment.NewLine
                'strSql &= " ,A.ship_to_name,A.ship_to_address,A.ship_to_city,A.ship_to_state,A.ship_to_zipcode" & Environment.NewLine
                strSql &= " ,if(F.Dcode_ID=4015,A.ship_from_name,A.ship_to_name) as 'ship_to_name'" & Environment.NewLine
                strSql &= " ,if(F.Dcode_ID=4015,A.ship_from_address,A.ship_to_address) as 'ship_to_address'" & Environment.NewLine
                strSql &= " ,if(F.Dcode_ID=4015,A.ship_from_city,A.ship_to_city) as 'ship_to_city'" & Environment.NewLine
                strSql &= " ,if(F.Dcode_ID=4015,A.ship_from_state,A.ship_to_state) as 'ship_to_state'" & Environment.NewLine
                strSql &= " ,if(F.Dcode_ID=4015,A.ship_from_zipcode,ship_to_zipcode) as 'ship_to_zipcode'" & Environment.NewLine
                strSql &= " ,if(length(A.mb_orderID)>9, cast(A.mb_orderID as char),lpad(A.mb_orderID,9,'0')) as 'OrderID_Inbound'" & Environment.NewLine
                strSql &= " ,if(length(B.mb_OrderID_Outbound)>9, cast(B.mb_OrderID_Outbound as char),lpad(B.mb_OrderID_Outbound,9,'0')) as 'OrderID_Outbound'" & Environment.NewLine
                strSql &= " ,if(A.OrderType=1,'Inbound',if(A.OrderType=0,'Outbound','Undefined')) as 'Order Type'" & Environment.NewLine
                strSql &= " from tmb_order A" & Environment.NewLine
                strSql &= " inner join tmb_device B on A.mb_orderid = B.mb_orderid_inbound" & Environment.NewLine
                strSql &= " inner join tmb_deviceasn C on A.mb_OrderID=C.mb_OrderID and B.mb_deviceID=C.mb_deviceid" & Environment.NewLine
                strSql &= " left Join security.tusers D on B.ShippedUserID=D.user_ID" & Environment.NewLine
                strSql &= " left join lcodesdetail F on B.action_id=F.dcode_id" & Environment.NewLine
                strSql &= " where A.Cust_ID= " & iCustID & " and B.shippeddate is not null" & Environment.NewLine
                strSql &= " and B.shippeddate between '" & strBegDTime & "' and '" & strEndDTime & "'" & Environment.NewLine
                strSql &= " order by A.OrderType,B.shippeddate, B.mb_deviceID;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function Create_ExcelRpt(ByVal dt As DataTable, ByVal strReportName As String) As Integer
            Dim strSql As String
            Dim objExcelRpt As ExcelReports
            Dim strCols() As String, i As Integer = 0

            Try
                If dt.Rows.Count > 0 Then
                    ReDim strCols(dt.Columns.Count - 1)
                    For i = 0 To dt.Columns.Count - 1
                        strCols(i) = Generic.CalExcelColLetter(i + 1)
                    Next i

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols)
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        ' Search queries
        '***********************************************************************************************************************************

        Public Function Get_Master_Pack(ByVal strSearchMP_ID As String) As DataTable
            Dim strSql As String = ""

            Try

                strSql = "SELECT A.mb_MP_ID as 'Master Pack ID', B.mb_deviceID as 'Device ID', B.mb_tote_ID as 'Tote ID'," & Environment.NewLine
                strSql &= "B.item_esn_imei as 'ESN/IMEI', B.item_Sku as 'Sku', cast(cast(A.MP_Quantity as UNSIGNED) as char) as 'Quantity'," & Environment.NewLine
                strSql &= "B.ReceivedDate, B.ShippedDate, B.ReceivedPCName, " & Environment.NewLine
                strSql &= "B.PutAway_Location, " & Environment.NewLine
                strSql &= "M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', " & Environment.NewLine
                strSql &= "O.DCode_LDesc as 'Carrier', P.DCode_LDesc as 'FindMyiPhone', Q.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present', " & Environment.NewLine
                strSql &= "F.Dcode_LDesc as 'data wipe', S.Dcode_LDesc as 'Initial Action', E.Dcode_LDesc as 'Status', D.Dcode_LDesc as 'New Status'" & Environment.NewLine
                'strSql &= "F.Dcode_LDesc as 'Model',G.Dcode_LDesc as 'Memory',H.Dcode_LDesc as 'Color'," & Environment.NewLine
                'strSql &= "I.Dcode_LDesc as 'CarrierLock',J.Dcode_LDesc as 'Carrier',K.Dcode_LDesc as 'Condition'," & Environment.NewLine

                strSql &= "from tmb_masterpack A LEFT join tmb_device B on A.mb_MP_ID=B.MB_MP_ID " & Environment.NewLine
                strSql &= "Inner join tmb_tote C on B.mb_Tote_ID=C.MB_Tote_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail S ON B.initial_action_id = S.DCode_ID" & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail E ON B.action_id = E.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON B.response_action_id = D.DCode_ID" & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail F ON B.item_data_wipe = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail M ON B.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail N ON B.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON B.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail O ON B.item_carrier_id = O.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON B.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail Q ON B.item_carrier_lock_id = Q.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON B.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON B.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON B.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON B.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON B.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON B.item_battery_present_id = L.Dcode_ID " & Environment.NewLine

                'strSql &= "Left join lcodesdetail G on B.item_memory_ID=G.Dcode_ID left join lcodesdetail H on B.item_color_ID=H.Dcode_ID " & Environment.NewLine
                'strSql &= "left join lcodesdetail I on B.item_carrier_Lock_ID=I.Dcode_ID " & Environment.NewLine
                'strSql &= "left join lcodesdetail J on B.item_carrier_ID=J.Dcode_ID left join lcodesdetail K on B.item_condition_ID=K.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_MP_ID = '" & strSearchMP_ID & "'" & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function Get_Master_Pack_ASN(ByVal strSearchDevice_ID As String) As DataTable
            Dim strSql As String = ""

            Try

                strSql = "SELECT A.mb_MP_ID as 'Master Pack ID', L.mb_DeviceID as 'Device ID', L.item_esn_imei as 'ESN/IMEI', L.item_discrepant_template_id as 'Descrepancy Template',  " & Environment.NewLine
                strSql &= "L.item_Sku as 'Sku', cast(cast(A.MP_Quantity as UNSIGNED) as char) as 'Quantity', " & Environment.NewLine
                strSql &= "P.Dcode_LDesc as 'OEM', F.Dcode_LDesc as 'Model', R.Dcode_LDesc as 'Technology', G.Dcode_LDesc as 'Memory',H.Dcode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "I.Dcode_LDesc as 'CarrierLock',J.Dcode_LDesc as 'Carrier', E.Dcode_LDesc as 'FindMyiPhone', K.Dcode_LDesc as 'Condition'," & Environment.NewLine
                strSql &= "M.DCode_LDesc as 'ESN/IMEI Checked', N.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "O.DCode_LDesc as 'Batt. Present' " & Environment.NewLine
                strSql &= "from tmb_masterpack A Left join tmb_device B on A.mb_MP_ID=B.MB_MP_ID " & Environment.NewLine
                strSql &= "LEFT join tmb_deviceasn L on B.mb_DeviceID = L.mb_DeviceID " & Environment.NewLine
                strSql &= "Inner join tmb_tote C on B.mb_Tote_ID=C.MB_Tote_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON L.item_oem_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "Left join lcodesdetail F on L.item_model_ID=F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON L.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail E ON L.item_findmyiphone_id = E.Dcode_ID " & Environment.NewLine

                strSql &= "Left join lcodesdetail G on L.item_memory_ID=G.Dcode_ID left join lcodesdetail H on L.item_color_ID=H.Dcode_ID " & Environment.NewLine
                strSql &= "left join lcodesdetail I on L.item_carrier_Lock_ID=I.Dcode_ID " & Environment.NewLine
                strSql &= "left join lcodesdetail J on L.item_carrier_ID=J.Dcode_ID left join lcodesdetail K on L.item_condition_ID=K.Dcode_ID " & Environment.NewLine
                strSql &= "left JOIN lcodesdetail M ON L.item_esn_imei_check_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "left JOIN lcodesdetail N ON L.item_batterydoor_present_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "left JOIN lcodesdetail O ON L.item_battery_present_id = O.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE L.mb_DeviceID = '" & strSearchDevice_ID & "'" & Environment.NewLine
                'strSql &= "B.item_esn_imei = '" & strSearchESN_IMEI & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''***********************************************************************************************************************************
        'Public Function Get_ESN(ByVal strSearchName As String) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT item_esn_imei as 'ESN/IMEI'," & Environment.NewLine
        '        strSql &= "B.DCode_LDesc as 'OEM', C.DCode_LDesc as 'Model', D.DCode_LDesc as 'Carrier'," & Environment.NewLine
        '        strSql &= "E.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
        '        strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
        '        strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
        '        strSql &= "L.DCode_LDesc as 'Batt. Present', " & Environment.NewLine
        '        strSql &= "mb_DeviceID as 'Device ID' FROM tmb_device A " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail B ON A.item_oem_id = B.Dcode_ID INNER JOIN lcodesdetail C ON A.item_model_id = C.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail D ON A.item_carrier_id = D.Dcode_ID" & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail E ON A.item_findmyiphone_id = E.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
        '        strSql &= "WHERE A.item_esn = '" & strSearchName & "'" & Environment.NewLine



        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        ''***********************************************************************************************************************************
        'Public Function Get_ESN_ASN(ByVal strSearchName1 As String) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT item_esn_imei as 'ESN/IMEI'," & Environment.NewLine
        '        strSql &= "B.DCode_LDesc as 'OEM', C.DCode_LDesc as 'Model', D.DCode_LDesc as 'Carrier'," & Environment.NewLine
        '        strSql &= "E.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
        '        strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
        '        strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
        '        strSql &= "L.DCode_LDesc as 'Batt. Present', item_discrepant_template_id as 'Descrepancy Template'," & Environment.NewLine
        '        strSql &= "mb_DeviceID as 'Device ID', A.* FROM tmb_deviceasn A " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail B ON A.item_oem_id = B.Dcode_ID INNER JOIN lcodesdetail C ON A.item_model_id = C.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail D ON A.item_carrier_id = D.Dcode_ID" & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail E ON A.item_findmyiphone_id = E.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
        '        strSql &= "WHERE A.item_esn_imei = '" & strSearchName1 & "'" & Environment.NewLine

        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '***********************************************************************************************************************************
        Public Function Get_EsnImei(ByVal strSearchESN_IMEI As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.item_esn_imei as 'ESN/IMEI', " & Environment.NewLine
                strSql &= "A.mb_DeviceID as 'Device ID' , A.mb_Tote_ID, A.mb_MP_ID, A.item_Sku as 'Sku', A.ReceivedDate, A.ShippedDate, A.ReceivedPCName, " & Environment.NewLine
                strSql &= "A.PutAway_Location, " & Environment.NewLine
                strSql &= "M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', " & Environment.NewLine
                strSql &= "O.DCode_LDesc as 'Carrier', P.DCode_LDesc as 'FindMyiPhone', Q.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present', F.DCode_LDesc as 'data wipe', S.DCode_LDesc as 'Initial Action', C.DCode_LDesc as 'Status', D.DCode_LDesc as 'New Status'" & Environment.NewLine
                strSql &= "FROM tmb_device A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail S ON A.initial_action_id = S.DCode_ID" & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail C ON A.action_id = C.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON A.response_action_id = D.DCode_ID" & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail F ON A.item_data_wipe = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail M ON A.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail N ON A.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON A.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail O ON A.item_carrier_id = O.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON A.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail Q ON A.item_carrier_lock_id = Q.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE A.item_esn_imei = '" & strSearchESN_IMEI & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************

        Public Function Get_EsnImei_ASN(ByVal strSearchDevice_ID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.item_esn_imei as 'ESN/IMEI', A.mb_DeviceID as 'Device ID', A.item_discrepant_template_id, A.item_sku, " & Environment.NewLine
                strSql &= "B.DCode_LDesc as 'OEM', C.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', D.DCode_LDesc as 'Carrier'," & Environment.NewLine
                strSql &= "E.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present' " & Environment.NewLine
                strSql &= "FROM tmb_deviceasn A " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail B ON A.item_oem_id = B.Dcode_ID Left JOIN lcodesdetail C ON A.item_model_id = C.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON A.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail D ON A.item_carrier_id = D.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail E ON A.item_findmyiphone_id = E.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE A.mb_DeviceID = '" & strSearchDevice_ID & "' " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************

        Public Function Get_Device_ID(ByVal strSearchDevice_ID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_DeviceID as 'Device ID', A.item_esn_imei, A.mb_MP_ID, B.po_number, A.mb_Tote_ID, E.item_discrepant_template_id, A.item_Sku as 'Sku', A.ReceivedDate, A.ShippedDate, A.ReceivedPCName, " & Environment.NewLine
                strSql &= "A.PutAway_Location, " & Environment.NewLine
                strSql &= "M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', " & Environment.NewLine
                strSql &= "O.DCode_LDesc as 'Carrier', P.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present', Q.DCode_LDesc as 'data wipe', S.DCode_LDesc as 'Initial Action', C.DCode_LDesc as 'Status',  D.DCode_LDesc as 'New Status'," & Environment.NewLine
                strSql &= "B.closed, B.number_of_items as 'OrderQty', B.OrderRecQty as 'ShipmentQty', B.CompletedItemRecDate, B.DamagedOnArrival " & Environment.NewLine
                strSql &= "FROM tmb_device A INNER JOIN tmb_order B ON A.mb_OrderID_Inbound = B.mb_OrderID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail S ON A.initial_action_id = S.DCode_ID" & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail C ON A.action_id = C.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON A.response_action_id = D.DCode_ID" & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail Q ON A.item_data_wipe = Q.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail M ON A.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail N ON A.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON A.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail O ON A.item_carrier_id = O.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON A.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN tmb_deviceasn E on A.mb_DeviceID = E.mb_DeviceID" & Environment.NewLine
                strSql &= "WHERE A.mb_DeviceID = '" & strSearchDevice_ID & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************

        Public Function Get_Device_ASNID(ByVal strSearchDevice_ID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_DeviceID as 'Device ID', A.item_esn_imei, A.item_discrepant_template_id, A.item_Sku as 'Sku', M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', " & Environment.NewLine
                strSql &= "R.DCode_LDesc as 'Technology', O.DCode_LDesc as 'Carrier', P.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present' " & Environment.NewLine


                strSql &= "FROM tmb_deviceasn A " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail M ON A.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail N ON A.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON A.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail O ON A.item_carrier_id = O.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON A.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_DeviceID = '" & strSearchDevice_ID & "'  " & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************

        Public Function Get_OrderPO(ByVal strSearchOrderPO As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Try
                strSql = "SELECT A.po_number as 'PO Number', B.mb_DeviceID as 'Device ID', B.item_esn_imei, B.mb_MP_ID, B.mb_Tote_ID,B.item_Sku as 'Sku', A.shipment_status, A.tracking_number, A.ship_from_name," & Environment.NewLine
                strSql &= "A.ship_from_address, A.ship_from_city, A.ship_from_state, A.ship_from_zipcode, A.ship_to_name," & Environment.NewLine
                strSql &= "A.ship_to_address, A.ship_to_city, A.ship_to_state,ship_to_zipcode, A.ship_to_country, A.ship_date," & Environment.NewLine
                strSql &= "A.OrderRecQty, A.OrderRecDate, A.OrderShipDate, " & Environment.NewLine
                strSql &= "B.ReceivedDate, B.ShippedDate, B.ReceivedPCName, " & Environment.NewLine
                strSql &= "B.PutAway_Location, " & Environment.NewLine
                strSql &= "M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', " & Environment.NewLine
                strSql &= "O.DCode_LDesc as 'Carrier', P.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present', " & Environment.NewLine
                strSql &= "Q.DCode_LDesc as 'data wipe', S.Dcode_LDesc as 'Initial Action', C.Dcode_LDesc as 'Status', D.DCode_LDesc as 'New Status'" & Environment.NewLine

                strSql &= "From tmb_order A" & Environment.NewLine
                strSql &= "LEFT Join tmb_device B on A.mb_OrderID = B.mb_OrderID_Inbound" & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail M ON B.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail N ON B.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON B.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail O ON B.item_carrier_id = O.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON B.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail F ON B.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON B.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON B.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON B.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON B.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON B.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON B.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail S ON B.initial_action_id = S.DCode_ID" & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail C ON B.action_id = C.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON B.response_action_id = D.DCode_ID" & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail Q ON B.item_data_wipe = Q.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE A.po_number = '" & strSearchOrderPO & "'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows

                    If IsDBNull(R1("Device ID")) Then R1("Device ID") = 0

                Next R1


                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function Get_OrderPO_ASN(ByVal strSearchPO As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT N.po_number as 'PO Number', A.mb_DeviceID as 'Device ID', A.item_esn_imei as 'ESN/IMEI', A.item_discrepant_template_id as 'Descrepancy Template', A.item_sku, " & Environment.NewLine
                strSql &= "B.DCode_LDesc as 'OEM', C.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', D.DCode_LDesc as 'Carrier'," & Environment.NewLine
                strSql &= "E.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present'" & Environment.NewLine
                strSql &= "FROM tmb_order N left join tmb_deviceasn A on A.mb_OrderID = N.mb_OrderID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail B ON A.item_oem_id = B.Dcode_ID LEFT JOIN lcodesdetail C ON A.item_model_id = C.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON A.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail D ON A.item_carrier_id = D.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail E ON A.item_findmyiphone_id = E.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
                
                strSql &= "WHERE N.po_number  = '" & strSearchPO & "' " & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function Get_OrderPO_Device_ASN(ByVal strSearchDeviceID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT N.po_number as 'PO Number', A.mb_DeviceID as 'Device ID', A.item_esn_imei as 'ESN/IMEI', A.item_discrepant_template_id as 'Descrepancy Template', A.item_sku, " & Environment.NewLine
                strSql &= "B.DCode_LDesc as 'OEM', C.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', D.DCode_LDesc as 'Carrier'," & Environment.NewLine
                strSql &= "E.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present'" & Environment.NewLine
                strSql &= "FROM tmb_order N left join tmb_deviceasn A on A.mb_OrderID = N.mb_OrderID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail B ON A.item_oem_id = B.Dcode_ID LEFT JOIN lcodesdetail C ON A.item_model_id = C.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON A.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail D ON A.item_carrier_id = D.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail E ON A.item_findmyiphone_id = E.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail F ON A.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON A.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON A.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON A.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON A.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON A.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON A.item_battery_present_id = L.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE A.mb_DeviceID  = '" & strSearchDeviceID & "' " & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Public Function Get_Tote_ID(ByVal strSearchTote_ID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT A.mb_Tote_ID as 'Tote ID', B.mb_DeviceID as 'Device ID', " & Environment.NewLine
                strSql &= "B.item_esn_imei as 'ESN/IMEI', Tote_Item_SeqNo as 'Seq', item_sku," & Environment.NewLine
                strSql &= "B.ReceivedDate, B.ShippedDate, B.ReceivedPCName, " & Environment.NewLine
                strSql &= "B.PutAway_Location, " & Environment.NewLine
                strSql &= "M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', " & Environment.NewLine
                strSql &= "T.DCode_LDesc as 'Carrier', P.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color'," & Environment.NewLine
                strSql &= "J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Batt. Present', " & Environment.NewLine
                strSql &= "Q.DCode_LDesc as 'data wipe', S.DCode_LDesc as 'Initial Action', C.DCode_LDesc as 'Status', D.DCode_LDesc as 'New Status'," & Environment.NewLine

                'strSql &= "C.DCode_LDesc as 'OEM', D.DCode_LDesc as 'Model', N.DCode_LDesc as 'Technology'," & Environment.NewLine
                'strSql &= "E.DCode_LDesc as 'Carrier', F.DCode_LDesc as 'Find My iPhone', G.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                'strSql &= "I.DCode_LDesc as 'Memory', J.DCode_LDesc as 'Color', K.DCode_LDesc as 'ESN/IMEI Checked'," & Environment.NewLine
                'strSql &= "L.DCode_LDesc as 'Battery Door Present', M.DCode_LDesc as 'Battery Present'," & Environment.NewLine
                strSql &= "A.Tote_Name as 'Tote Name', A.ClosedDate as 'Close Date', O.User_FullName as 'Closed By'" & Environment.NewLine
                strSql &= "FROM tmb_tote A INNER JOIN security.tusers O ON A.ClosedUserID = O.User_ID" & Environment.NewLine
                strSql &= "LEFT JOIN tmb_device B ON A.mb_Tote_ID = B.mb_Tote_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail M ON B.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail N ON B.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON B.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail T ON B.item_carrier_id = T.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail P ON B.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT JOIN lcodesdetail F ON B.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail G ON B.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail H ON B.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail I ON B.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail J ON B.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail K ON B.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail L ON B.item_battery_present_id = L.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail S ON B.initial_action_id = S.DCode_ID" & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail C ON B.action_id = C.DCode_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON B.response_action_id = D.DCode_ID" & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail Q ON B.item_data_wipe = Q.Dcode_ID " & Environment.NewLine

                'strSql &= "LEFT OUTER JOIN lcodesdetail C ON B.item_oem_id = C.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail D ON B.item_model_id = D.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail E ON B.item_carrier_id = E.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail F ON B.item_findmyiphone_id = F.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail G ON B.item_carrier_lock_id = G.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail H ON B.item_condition_id = H.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail I ON B.item_memory_id = I.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail J ON B.item_color_id = J.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail K ON B.item_esn_imei_check_id = K.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail L ON B.item_batterydoor_present_id = L.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail M ON B.item_battery_present_id = M.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT OUTER JOIN lcodesdetail N ON B.item_technology_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.mb_Tote_ID = '" & strSearchTote_ID & "'" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows

                    If IsDBNull(R1("Device ID")) Then R1("Device ID") = 0

                Next R1


                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************

        Public Function Get_Tote_Device_ASNID(ByVal strSearchDevice_ID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_Tote_ID as 'Tote ID', O.mb_DeviceID as 'Device ID',  O.item_esn_imei as 'ESN/IMEI', O.item_discrepant_template_id, Tote_Item_SeqNo as 'Seq', O.item_Sku as 'Sku',  " & Environment.NewLine
                strSql &= "C.DCode_LDesc as 'OEM', D.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology'," & Environment.NewLine
                strSql &= "E.DCode_LDesc as 'Carrier', F.DCode_LDesc as 'FindMyiPhone', G.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "H.DCode_LDesc as 'Condition', I.DCode_LDesc as 'Memory', J.DCode_LDesc as 'Color', K.DCode_LDesc as 'ESN/IMEI Checked'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Battery Door Present', M.DCode_LDesc as 'Battery Present'," & Environment.NewLine
                strSql &= "A.Tote_Name as 'Tote Name', A.ClosedDate as 'Close Date', P.User_FullName as 'Closed By' " & Environment.NewLine
                strSql &= "FROM tmb_tote A INNER JOIN security.tusers P ON A.ClosedUserID = P.User_ID " & Environment.NewLine
                strSql &= "LEFT JOIN tmb_device B ON A.mb_Tote_ID = B.mb_Tote_ID LEFT JOIN tmb_deviceasn O ON B.mb_DeviceID = O.mb_DeviceID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail C ON O.item_oem_id = C.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON O.item_model_id = D.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON O.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail E ON O.item_carrier_id = E.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail F ON O.item_findmyiphone_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail G ON O.item_carrier_lock_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail H ON O.item_condition_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail I ON O.item_memory_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail J ON O.item_color_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail K ON O.item_esn_imei_check_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail L ON O.item_batterydoor_present_id = L.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail M ON O.item_battery_present_id = M.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE " & Environment.NewLine
                strSql &= "O.mb_DeviceID = '" & strSearchDevice_ID & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function Get_Tote_ASNID(ByVal strSearchDevice_ID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.mb_Tote_ID as 'Tote ID', O.mb_DeviceID as 'Device ID',  O.item_esn_imei as 'ESN/IMEI', O.item_discrepant_template_id, Tote_Item_SeqNo as 'Seq',O.item_Sku as 'Sku',  " & Environment.NewLine
                strSql &= "C.DCode_LDesc as 'OEM', D.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology'," & Environment.NewLine
                strSql &= "E.DCode_LDesc as 'Carrier', F.DCode_LDesc as 'FindMyiPhone', G.DCode_LDesc as 'Carrier Lock'," & Environment.NewLine
                strSql &= "H.DCode_LDesc as 'Condition', I.DCode_LDesc as 'Memory', J.DCode_LDesc as 'Color', K.DCode_LDesc as 'ESN/IMEI Checked'," & Environment.NewLine
                strSql &= "L.DCode_LDesc as 'Battery Door Present', M.DCode_LDesc as 'Battery Present'," & Environment.NewLine
                strSql &= "A.Tote_Name as 'Tote Name', A.ClosedDate as 'Close Date', P.User_FullName as 'Closed By' " & Environment.NewLine
                strSql &= "FROM tmb_tote A INNER JOIN security.tusers P ON A.ClosedUserID = P.User_ID " & Environment.NewLine
                strSql &= "LEFT JOIN tmb_device B ON A.mb_Tote_ID = B.mb_Tote_ID LEFT JOIN tmb_deviceasn O ON B.mb_DeviceID = O.mb_DeviceID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail C ON O.item_oem_id = C.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail D ON O.item_model_id = D.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail R ON O.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "LEFT OUTER JOIN lcodesdetail E ON O.item_carrier_id = E.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail F ON O.item_findmyiphone_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail G ON O.item_carrier_lock_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail H ON O.item_condition_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail I ON O.item_memory_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail J ON O.item_color_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail K ON O.item_esn_imei_check_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail L ON O.item_batterydoor_present_id = L.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lcodesdetail M ON O.item_battery_present_id = M.Dcode_ID " & Environment.NewLine

                strSql &= "WHERE " & Environment.NewLine
                strSql &= "A.mb_Tote_ID = '" & strSearchDevice_ID & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***********************************************************************************************************************************

        Public Function Get_Discrepant_Template_ID(ByVal strSearchTemplate_ID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim index As Integer = 0
            Try

                strSql = "SELECT distinct 0 as 'index', A.discrepant_template_id, B.*, C.DCode_LDesc as 'Action_Desc', D.Dcode_LDesc as 'TemplateVal' " & Environment.NewLine
                strSql &= "FROM tmb_discrepanttemplate A LEFT JOIN tmb_discrepanttemplatedetails B ON A.DCP_ID = B.DCP_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail C ON B.Action_ID = C.DCode_ID LEFT OUTER JOIN lcodesdetail D ON B.Desc_ID = D.Dcode_ID " & Environment.NewLine
                'strSql &= "LEFT Join tmb_deviceasn E on A.discrepant_template_ID = E.item_discrepant_template_ID " & Environment.NewLine
                strSql &= "WHERE A.discrepant_template_id = '" & strSearchTemplate_ID & "'" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows

                    R1("index") = index + 1
                    index = index + 1
                Next R1

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '***********************************************************************************************************************************

        Public Function Get_Discrepant_Template_ASNID(ByVal strSearchDCP_Detail_ID As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct A.discrepant_template_id, E.mb_DeviceID as 'Device ID', B.*,E.item_Sku as 'Sku', C.DCode_LDesc as 'Action_Desc', D.Dcode_LDesc as 'TemplateVal', M.DCode_LDesc as 'OEM', N.DCode_LDesc as 'Model', R.DCode_LDesc as 'Technology', O.DCode_LDesc as 'Carrier',P.DCode_LDesc as 'FindMyiPhone', F.DCode_LDesc as 'Carrier Lock', G.DCode_LDesc as 'Condition',  H.DCode_LDesc as 'Memory', I.DCode_LDesc as 'Color', J.DCode_LDesc as 'ESN/IMEI Checked', K.DCode_LDesc as 'Batt. Door Present',L.DCode_LDesc as 'Batt. Present' " & Environment.NewLine

                strSql &= "FROM tmb_discrepanttemplate A LEFT JOIN tmb_discrepanttemplatedetails B ON A.DCP_ID = B.DCP_ID " & Environment.NewLine
                strSql &= "Left Join tmb_deviceasn E on A.discrepant_template_ID = E.item_discrepant_template_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail C ON B.Action_ID = C.DCode_ID LEFT OUTER JOIN lcodesdetail D ON B.Desc_ID = D.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail M ON E.item_oem_id = M.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail N ON E.item_model_id = N.Dcode_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail R ON E.item_technology_id = R.Dcode_ID " & Environment.NewLine

                strSql &= "Left JOIN lcodesdetail O ON E.item_carrier_id = O.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail P ON E.item_findmyiphone_id = P.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail F ON E.item_carrier_lock_id = F.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail G ON E.item_condition_id = G.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail H ON E.item_memory_id = H.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail I ON E.item_color_id = I.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail J ON E.item_esn_imei_check_id = J.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail K ON E.item_batterydoor_present_id = K.Dcode_ID " & Environment.NewLine
                strSql &= "Left JOIN lcodesdetail L ON E.item_battery_present_id = L.Dcode_ID " & Environment.NewLine

                'strSql &= "WHERE E.mb_DeviceID = '" & strSearchDeviceID & "' AND " & Environment.NewLine
                strSql &= "where B.DCP_Detail_ID = '" & strSearchDCP_Detail_ID & "' " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '***********************************************************************************************************************************

    End Class
End Namespace