
Namespace Buisness
    Public Class CustomerServices
        Private _objDataProc As DBQuery.DataProc
        Private Const _decPSSNETCustomerMarkup As Decimal = 0.1
        Private ReadOnly _decTotalCustomerMarkup As Decimal

#Region "Constructor/Destructor"

        '*******************************************************************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                Me._decTotalCustomerMarkup = Me._decPSSNETCustomerMarkup + Generic.GetCustomerMarkup(Pantech.Pantech_CUSTOMER_ID) 'Generic.GetCustomerMarkup will have 1.00 added, so no need to add it here
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************************************************************
#End Region

#Region "Customer Service"
        '*******************************************************************************************************************

        Public Sub UpdatePartsCost()
            Dim strSQL As String
            Dim dt As DataTable = Nothing

            Try
                'Set ApprovedPartPrice for approved devices
                strSQL = "SELECT PA_ID, device_id" & Environment.NewLine
                strSQL &= "FROM production.pantechasn" & Environment.NewLine
                strSQL &= "WHERE ApprovedToRepairDate IS NOT NULL AND ApprovedToRepair = 1"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow

                    For Each dr In dt.Rows
                        Dim iPAID As Integer = Convert.ToInt32(dr("PA_ID"))

                        strSQL = "SELECT SUM(DBill_InvoiceAmt)" & Environment.NewLine
                        strSQL &= "FROM production.tdevicebill" & Environment.NewLine
                        strSQL &= String.Format("WHERE device_id = {0}", dr("device_id"))

                        Dim dblPartCost As Double = Me._objDataProc.GetDoubleValue(strSQL)

                        If dblPartCost > 0 Then
                            strSQL = "UPDATE production.pantechasn" & Environment.NewLine
                            strSQL &= String.Format("SET ApprovedPartPrice = {0}", dblPartCost) & Environment.NewLine
                            strSQL &= String.Format("WHERE PA_ID = {0}", iPAID)

                            Me._objDataProc.ExecuteNonQuery(strSQL)
                        End If

                    Next dr
                End If

                'Now update tax on parts for ship to addresses in appropriate states
                Dim strDeviceIDsIN As String = String.Empty

                strSQL = "SELECT A.device_id, F.TaxRate * A.ApprovedPartPrice AS 'TaxOnParts'" & Environment.NewLine
                strSQL &= "FROM production.pantechasn A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tdevice B ON A.device_id = B.device_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tworkorder D ON B.wo_id = D.wo_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                strSQL &= "WHERE A.ApprovedToRepairDate IS NOT NULL"

                dt = Me._objDataProc.GetDataTable(strSQL)

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow

                    For Each dr In dt.Rows
                        strSQL = "UPDATE production.pantechasn" & Environment.NewLine
                        strSQL &= String.Format("SET TaxOnParts = {0}", Convert.ToDecimal(dr("TaxOnParts"))) & Environment.NewLine
                        strSQL &= String.Format("WHERE device_id = {0}", dr("device_id"))

                        Me._objDataProc.ExecuteNonQuery(strSQL)

                        strDeviceIDsIN &= IIf(strDeviceIDsIN.Length > 0, ", ", String.Empty) & Convert.ToString(dr("device_id"))
                    Next dr
                End If

                'Set TaxOnPart to zero for all other records
                strSQL = "UPDATE production.pantechasn" & Environment.NewLine
                strSQL &= "SET TaxOnParts = 0"

                If strDeviceIDsIN.Length > 0 Then strSQL &= Environment.NewLine & String.Format("WHERE device_id NOT IN ({0})", strDeviceIDsIN)

                Me._objDataProc.ExecuteNonQuery(strSQL)

                'Set ApprovedPartPrice = 0 for unapproved devices where the value of ApprovedPartPrice is not zero
                strSQL = "UPDATE production.pantechasn" & Environment.NewLine
                strSQL &= "SET ApprovedPartPrice = 0" & Environment.NewLine
                strSQL &= "WHERE ApprovedPartPrice <> 0 AND ApprovedToRepairDate IS NULL"

                Me._objDataProc.ExecuteNonQuery(strSQL)

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************************************************
        Public Function GetApprovedUnits(ByVal iLocID As Integer, ByVal strApprovedStartDate As String, ByVal strApprovedEndDate As String) As DataSet
            Dim strSql As String
            Dim ds As DataSet = Nothing
            Dim dt As DataTable = Nothing
            Dim dr As DataRow

            Try
                ds = New DataSet("Approved RMAs Data")

                strSql = "SELECT DISTINCT C.wo_id, C.WO_CustWO as RMA" & Environment.NewLine
                strSql &= ", SUM(A.Device_Laborcharge) as 'Total Labor Charge', SUM(F.ApprovedPartPrice) as 'Total Parts Charge', SUM(F.taxonparts) AS 'Total Tax on Parts' " & Environment.NewLine
                strSql &= ", ShipTo_Name as 'To Name', ShipTo_Address1 as 'To Address1', ShipTo_Address2 as 'To Address2' " & Environment.NewLine
                strSql &= ", ShipTo_City as 'To City', State_Short as 'To State', ShipTo_Zip as 'To ZIP', D.Tel AS 'Telephone', D.fax AS FAX, D.Email" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON A.WO_ID = C.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto D ON C.ShipTo_ID = D.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate E ON D.State_Id = E.State_Id" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn F ON A.Device_ID = F.Device_ID" & Environment.NewLine
                strSql &= String.Format("WHERE A.Loc_ID = {0} AND A.Device_ManufWrty = 0 ", iLocID) & Environment.NewLine
                strSql &= String.Format("AND F.ApprovedToRepairDate BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", strApprovedStartDate, strApprovedEndDate) & Environment.NewLine
                strSql &= "GROUP BY C.wo_id" & Environment.NewLine
                strSql &= "ORDER BY RMA"

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Approved RMAs"
                ds.Tables.Add(dt)

                Dim strWOIDsIn As String = String.Empty

                If dt.Rows.Count > 0 Then
                    For Each dr In dt.Rows : strWOIDsIn &= IIf(strWOIDsIn.Length > 0, ", ", String.Empty) & Convert.ToString(dr("wo_id")) : Next dr
                End If

                If strWOIDsIn.Length > 0 Then
                    strSql = "SELECT DISTINCT D.wo_id, A.device_id, IFNULL(A.ship_id, 0) AS ship_id, IFNULL(J.cellopt_msn, 'N/A') AS 'SN', A.device_sn AS IMEI, G.Model_Desc as Model" & Environment.NewLine
                    strSql &= ", A.Device_Laborcharge AS 'Labor Charge', H.ApprovedPartPrice AS 'Parts Charge', H.taxOnParts AS 'Tax on Parts', IF(A.Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty?' " & Environment.NewLine
                    strSql &= ", DATE_FORMAT(A.device_recworkdate, '%M %e, %Y') AS 'Receive Date', DATE_FORMAT(H.ApprovedToRepairDate, '%M %e, %Y') as 'Approved Date', I.User_FullName as 'Approved By', IF(A.Device_Invoice = 1, 'Yes', 'No') as 'Invoiced?', IF(A.device_shipworkdate IS NULL, '', DATE_FORMAT(A.device_shipworkdate, '%M %e, %Y')) AS 'Ship Date', IFNULL(K.ShipTypeID, 0) AS ShipTypeID, IF(K.ShipTypeID IS NULL OR K.ShipTypeID = 0, '** Unassigned **', L.ShipType) AS 'Ship Type', IF(A.device_shipworkdate IS NULL, 0, 1) AS 'Device Shipped Temp', IFNULL(K.TrackingNo, 'N/A') AS 'Original Tracking Number'" & Environment.NewLine
                    strSql &= "FROM production.tdevice A" & Environment.NewLine
                    strSql &= "INNER JOIN production.tdevicebill B ON A.device_id = B.device_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.lbillcodes C ON B.billcode_id = C.billcode_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tmodel G ON A.model_id = G.model_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.pantechasn H ON A.Device_ID = H.Device_ID" & Environment.NewLine
                    strSql &= "INNER JOIN security.tusers I ON H.ApprovedToRepairBy = I.user_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tcellopt J ON A.Device_ID = J.Device_ID" & Environment.NewLine
                    strSql &= "LEFT JOIN production.tship K ON A.ship_id = K.ship_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.ShipTypes L ON K.shiptypeid = L.shiptypeid" & Environment.NewLine
                    strSql &= String.Format("WHERE D.wo_id IN ({0})", strWOIDsIn) & Environment.NewLine
                    strSql &= "ORDER BY IMEI"

                    dt = Me._objDataProc.GetDataTable(strSql)
                    dt.TableName = "Approved RMA Devices"
                    dt.Columns.Add(New DataColumn("Device Shipped", System.Type.GetType("System.Boolean")))
                    dt.Columns.Add(New DataColumn("Tracking Number", System.Type.GetType("System.String"))) 'So it will appear after 'Device Shipped'

                    For Each dr In dt.Rows
                        dr.BeginEdit()

                        If dr("Ship Date").ToString().Length = 0 Then
                            dr("Ship Date") = GetBusinessShipDate(dr("Receive Date"))
                            dr("Device Shipped") = Convert.ToBoolean(dr("Device Shipped Temp"))
                        End If

                        dr("Tracking Number") = dr("Original Tracking Number")

                        dr.EndEdit()
                        dr.AcceptChanges()
                    Next dr

                    dt.Columns.Remove("Device Shipped Temp")
                    ds.Tables.Add(dt)

                    ds.Relations.Add(New DataRelation("Approved RMAs to Devices", ds.Tables("Approved RMAs").Columns("wo_id"), ds.Tables("Approved RMA Devices").Columns("wo_id")))

                    Dim strDeviceIDsIn As String = String.Empty

                    If dt.Rows.Count > 0 Then
                        For Each dr In dt.Rows : strDeviceIDsIn &= IIf(strDeviceIDsIn.Length > 0, ", ", String.Empty) & Convert.ToString(dr("device_id")) : Next dr
                    End If

                    If strDeviceIDsIn.Length > 0 Then
                        strSql = "SELECT A.device_id, B.billcode_id, B.part_number AS 'Part', C.billcode_desc AS 'Bill Code', B.DBill_InvoiceAmt AS 'Part Charge', IF(F.state_id IS NULL, 0, F.TaxRate) * B.DBill_InvoiceAmt AS 'Tax on Part'" & Environment.NewLine
                        strSql &= "FROM production.tdevice A" & Environment.NewLine
                        strSql &= "INNER JOIN production.tdevicebill B ON A.device_id = B.device_id" & Environment.NewLine
                        strSql &= "INNER JOIN production.lbillcodes C ON B.billcode_id = C.billcode_id" & Environment.NewLine
                        strSql &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                        strSql &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                        strSql &= "LEFT JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                        strSql &= "INNER JOIN production.tmodel G ON A.model_id = G.model_id" & Environment.NewLine
                        strSql &= String.Format("WHERE A.device_id IN ({0})", strDeviceIDsIn) & Environment.NewLine
                        strSql &= "ORDER BY Part"

                        dt = Me._objDataProc.GetDataTable(strSql)
                        dt.TableName = "Approved Device Parts"
                        ds.Tables.Add(dt)

                        ds.Relations.Add(New DataRelation("Approved Devices to Parts", ds.Tables("Approved RMA Devices").Columns("device_id"), ds.Tables("Approved Device Parts").Columns("device_id")))
                    End If
                End If

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDS(ds)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetHoldUnits(ByVal iLocID As Integer) As DataSet
            Dim strSql As String
            Dim ds As DataSet = Nothing
            Dim dt As DataTable = Nothing
            Dim dtTemp1 As DataTable = Nothing
            Dim dtTemp2 As DataTable = Nothing
            Dim dr As DataRow

            Try
                ds = New DataSet("Hold Data")

                strSql = "SELECT DISTINCT C.wo_id, C.WO_CustWO as RMA" & Environment.NewLine
                strSql &= ", IFNULL(SUM(A.Device_Laborcharge), 0) as 'Total Labor Charge'" & Environment.NewLine
                strSql &= ", ShipTo_Name as 'To Name', ShipTo_Address1 as 'To Address1', ShipTo_Address2 as 'To Address2' " & Environment.NewLine
                strSql &= ", ShipTo_City as 'To City', State_Short as 'To State', ShipTo_Zip as 'To ZIP', D.Tel AS 'Telephone', D.fax AS FAX, D.Email" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON A.WO_ID = C.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto D ON C.ShipTo_ID = D.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate E ON D.State_Id = E.State_Id" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn F ON A.Device_ID = F.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt G ON A.Device_ID = G.Device_ID" & Environment.NewLine
                strSql &= String.Format("WHERE A.Loc_ID = {0} AND A.Device_DateShip IS NULL AND A.Device_ManufWrty = 0 AND G.cellopt_wipowner = 6", iLocID) & Environment.NewLine
                strSql &= "AND F.ApprovedToRepairDate IS NULL " & Environment.NewLine
                strSql &= "GROUP BY C.wo_id" & Environment.NewLine
                strSql &= "ORDER BY RMA"

                dt = Me._objDataProc.GetDataTable(strSql)
                dt.TableName = "Hold Work Orders"
                ds.Tables.Add(dt)

                Dim strWOIDsIn As String = String.Empty

                For Each dr In dt.Rows : strWOIDsIn &= IIf(strWOIDsIn.Length > 0, ", ", String.Empty) & Convert.ToString(dr("wo_id")) : Next dr

                If strWOIDsIn.Length > 0 Then
                    'Get units with repairs
                    strSql = "SELECT DISTINCT D.wo_id, A.device_id, A.model_id, IFNULL(A.ship_id, 0) AS ship_id, IFNULL(I.cellopt_msn, 'N/A') AS 'SN', A.device_sn AS IMEI, G.Model_Desc as Model, DATE_FORMAT(A.device_recworkdate, '%M %e, %Y') AS 'Receive Date'" & Environment.NewLine
                    strSql &= ", A.Device_Laborcharge AS 'Labor Charge', IF(A.Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty?' " & Environment.NewLine
                    strSql &= ", IF(A.Device_Invoice = 1, 'Yes', 'No') as 'Invoiced?', 'Yes' AS 'Billed Parts?', IF(I.cellopt_refurbcompleteuserid > 0 OR I.cellopt_refurbcompletedt IS NOT NULL, 'Yes', 'No') AS 'Refurb Completed?', IF(A.device_shipworkdate IS NULL, '', DATE_FORMAT(A.device_shipworkdate, '%M %e, %Y')) AS 'Ship Date', IFNULL(K.ShipTypeID, 0) AS ShipTypeID, IF(K.ShipTypeID IS NULL OR K.ShipTypeID = 0, '** Unassigned **', L.ShipType) AS 'Ship Type', IF(A.device_shipworkdate IS NULL, 0, 1) AS 'Device Shipped Temp', IFNULL(K.TrackingNo, 'N/A') AS 'Original Tracking Number'" & Environment.NewLine
                    strSql &= "FROM production.tdevice A" & Environment.NewLine
                    strSql &= "INNER JOIN production.tdevicebill B ON A.device_id = B.device_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.lbillcodes C ON B.billcode_id = C.billcode_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tmodel G ON A.model_id = G.model_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.pantechasn H ON A.Device_ID = H.Device_ID" & Environment.NewLine
                    strSql &= "INNER JOIN production.tcellopt I ON A.device_id = I.device_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.tship K ON A.ship_id = K.ship_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.ShipTypes L ON K.shiptypeid = L.shiptypeid" & Environment.NewLine
                    strSql &= String.Format("WHERE D.wo_id IN ({0})", strWOIDsIn) & Environment.NewLine
                    strSql &= "AND H.ApprovedToRepairDate IS NULL " & Environment.NewLine
                    strSql &= "ORDER BY IMEI"

                    dtTemp1 = Me._objDataProc.GetDataTable(strSql)

                    'Get units with no repair work
                    Dim strDeviceIDsIn As String = String.Empty

                    For Each dr In dtTemp1.Rows : strDeviceIDsIn &= IIf(strDeviceIDsIn.Length > 0, ", ", String.Empty) & Convert.ToString(dr("device_id")) : Next dr

                    strSql = "SELECT DISTINCT D.wo_id, A.device_id, A.model_id, IFNULL(A.ship_id, 0) AS ship_id, IFNULL(I.cellopt_msn, 'N/A') AS 'SN', A.device_sn AS IMEI, G.Model_Desc as Model, DATE_FORMAT(A.device_recworkdate, '%M %e, %Y') AS 'Receive Date'" & Environment.NewLine
                    strSql &= ", IFNULL(A.Device_Laborcharge, 0) AS 'Labor Charge', IF(A.Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty?' " & Environment.NewLine
                    strSql &= ", IF(A.Device_Invoice = 1, 'Yes', 'No') as 'Invoiced?', 'No' AS 'Billed Parts?', 'No' AS 'Refurb Completed?', IF(A.device_shipworkdate IS NULL, '', DATE_FORMAT(A.device_shipworkdate, '%M %e, %Y')) AS 'Ship Date', IFNULL(K.ShipTypeID, 0) AS ShipTypeID, IF(K.ShipTypeID IS NULL OR K.ShipTypeID = 0, '** Unassigned **', L.ShipType) AS 'Ship Type', IF(A.device_shipworkdate IS NULL, 0, 1) AS 'Device Shipped Temp', IFNULL(K.TrackingNo, 'N/A') AS 'Original Tracking Number'" & Environment.NewLine
                    strSql &= "FROM production.tdevice A" & Environment.NewLine
                    strSql &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tmodel G ON A.model_id = G.model_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.pantechasn H ON A.Device_ID = H.Device_ID" & Environment.NewLine
                    strSql &= "INNER JOIN production.tcellopt I ON A.Device_ID = I.Device_ID" & Environment.NewLine
                    strSql &= "LEFT JOIN production.tship K ON A.ship_id = K.ship_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.ShipTypes L ON K.shiptypeid = L.shiptypeid" & Environment.NewLine
                    strSql &= String.Format("WHERE D.wo_id IN ({0})", strWOIDsIn) & Environment.NewLine
                    If strDeviceIDsIn.Length > 0 Then strSql &= String.Format(" AND A.device_id NOT IN ({0})", strDeviceIDsIn) & Environment.NewLine
                    strSql &= "ORDER BY IMEI"

                    dtTemp2 = Me._objDataProc.GetDataTable(strSql)

                    If dtTemp2.Rows.Count > 0 Then For Each dr In dtTemp2.Rows : dtTemp1.ImportRow(dr) : Next dr

                    Dim drSort() As DataRow = dtTemp1.Select(String.Empty, "wo_id, SN")

                    dt = dtTemp1.Clone

                    If drSort.Length > 0 Then For Each dr In drSort : dt.ImportRow(dr) : Next dr

                    dt.TableName = "Hold RMA Devices"
                    dt.Columns.Add(New DataColumn("Device Shipped", System.Type.GetType("System.Boolean")))
                    dt.Columns.Add(New DataColumn("Tracking Number", System.Type.GetType("System.String"))) 'So it will appear after 'Device Shipped'

                    For Each dr In dt.Rows
                        dr.BeginEdit()

                        If dr("Ship Date").ToString().Length = 0 Then
                            dr("Ship Date") = GetBusinessShipDate(dr("Receive Date"))
                            dr("Device Shipped") = Convert.ToBoolean(dr("Device Shipped Temp"))
                        End If

                        dr("Tracking Number") = dr("Original Tracking Number")

                        dr.EndEdit()
                        dr.AcceptChanges()
                    Next dr

                    dt.Columns.Remove("Device Shipped Temp")
                    ds.Tables.Add(dt)

                    ds.Relations.Add(New DataRelation("Hold RMAs to Devices", ds.Tables("Hold Work Orders").Columns("wo_id"), ds.Tables("Hold RMA Devices").Columns("wo_id")))

                    strDeviceIDsIn = String.Empty

                    For Each dr In dt.Rows : strDeviceIDsIn &= IIf(strDeviceIDsIn.Length > 0, ", ", String.Empty) & Convert.ToString(dr("device_id")) : Next dr

                    If strDeviceIDsIn.Length > 0 Then
                        strSql = String.Format("SELECT A.device_id, IFNULL(B.billcode_id, 0) AS billcode_id, IFNULL(B.part_number, 'No Parts') AS 'Part', IFNULL(C.billcode_desc, 'N/A') AS 'Bill Code', {0} * IFNULL(B.dbill_stdcost, 0) AS 'Part Charge', IF(F.state_id IS NULL, 0, F.TaxRate) * {0} * IFNULL(B.dbill_stdcost, 0) AS 'Tax on Part'", Me._decTotalCustomerMarkup) & Environment.NewLine
                        strSql &= "FROM production.tdevice A" & Environment.NewLine
                        strSql &= "LEFT JOIN production.tdevicebill B ON A.device_id = B.device_id" & Environment.NewLine
                        strSql &= "LEFT JOIN production.lbillcodes C ON B.billcode_id = C.billcode_id" & Environment.NewLine
                        strSql &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                        strSql &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                        strSql &= "LEFT JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                        strSql &= String.Format("WHERE A.device_id IN ({0})", strDeviceIDsIn) & Environment.NewLine
                        strSql &= "ORDER BY Part"

                        dt = Me._objDataProc.GetDataTable(strSql)
                        dt.TableName = "Hold Device Parts"
                        ds.Tables.Add(dt)

                        ds.Relations.Add(New DataRelation("Hold Devices to Parts", ds.Tables("Hold RMA Devices").Columns("device_id"), ds.Tables("Hold Device Parts").Columns("device_id")))
                    End If
                End If

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtTemp1)
                PSS.Data.Buisness.Generic.DisposeDT(dtTemp2)
                PSS.Data.Buisness.Generic.DisposeDS(ds)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOWApprovedData(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT ApprovedToRepairDate, ApprovedToRepairBy, ApprovedToRepair " & Environment.NewLine
                strSql &= ", tcellopt.CellOpt_RefurbCompleteDt, tcellopt.CellOpt_RefurbCompleteUserID, tcellopt.Cellopt_WIPOwner " & Environment.NewLine
                strSql &= "FROM pantechasn" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON pantechasn.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "WHERE pantechasn.Device_ID = " & iDeviceID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetRepairConfirmationData(ByVal iWOID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.Device_ID, A.Device_DateBill, ApprovedToRepairDate, ApprovedToRepairBy, ApprovedToRepair " & Environment.NewLine
                strSql &= ", CellOpt_RefurbCompleteDt " & Environment.NewLine
                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.pantechasn B ON A.Device_ID = B.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN production.tcellopt C ON A.Device_ID = C.Device_ID" & Environment.NewLine
                strSql &= String.Format("WHERE A.WO_ID = {0}", iWOID)

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function SetApproveToRepairData(ByVal iDeviceID As Integer, ByVal iUserID As Integer, ByVal iApprovedToRep As Integer, ByVal iOWRejectRepair As Integer) As Integer
            Dim strSql As String
            Dim iRetVal As Integer

            Try
                strSql = String.Format("UPDATE pantechasn, tdevice, tcellopt SET ApprovedToRepairDate = NOW(), ApprovedToRepairBy = {0}, ApprovedToRepair = {1}, Device_Invoice = 1, tcellopt.cellopt_wipowner = {2}", iUserID, iApprovedToRep, IIf(iApprovedToRep = 0, 3, 8)) & Environment.NewLine
                strSql &= String.Format("WHERE pantechasn.Device_ID = tdevice.Device_ID AND tcellopt.Device_ID = tdevice.Device_ID AND tdevice.Device_ID = {0} AND ApprovedToRepairDate IS NULL", iDeviceID)

                iRetVal = Me._objDataProc.ExecuteNonQuery(strSql)

                If iRetVal > 0 And iApprovedToRep = 1 Then
                    'Set DBill_InvoiceAmt field in tdevicebill by to DBill_StdCost * customer markup for accepted devices
                    'and update pantechasn.ApprovedPartPrice and pantechasn.TaxOnParts
                    strSql = "UPDATE production.tdevicebill" & Environment.NewLine
                    strSql &= String.Format("SET DBill_InvoiceAmt = {0} * DBill_StdCost", Me._decTotalCustomerMarkup) & Environment.NewLine
                    strSql &= String.Format("WHERE device_id = {0}", iDeviceID)

                    Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "SELECT SUM(DBill_InvoiceAmt)" & Environment.NewLine
                    strSql &= "FROM production.tdevicebill" & Environment.NewLine
                    strSql &= String.Format("WHERE device_id = {0}", iDeviceID)

                    Dim dblPartCost As Double = Me._objDataProc.GetDoubleValue(strSql)

                    strSql = "SELECT IFNULL(F.TaxRate, 0)" & Environment.NewLine
                    strSql &= "FROM production.tdevice B" & Environment.NewLine
                    strSql &= "INNER JOIN production.tworkorder D ON B.wo_id = D.wo_id" & Environment.NewLine
                    strSql &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                    strSql &= "LEFT JOIN production.statetax F ON E.state_id = F.state_id" & Environment.NewLine
                    strSql &= String.Format("WHERE B.device_id = {0}", iDeviceID)

                    Dim dblTax As Double = Me._objDataProc.GetDoubleValue(strSql)

                    strSql = "UPDATE production.pantechasn" & Environment.NewLine
                    strSql &= String.Format("SET ApprovedPartPrice = {0}, TaxOnParts = {0} * {1}", dblPartCost, dblTax) & Environment.NewLine
                    strSql &= String.Format("WHERE Device_ID = {0}", iDeviceID)

                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return iRetVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function PrintInvoiceReceiptData(ByVal iDeviceID As Integer) As Integer
            Const strReportName As String = "Pantech Invoice Receipt Push.rpt"
            Dim strSql As String
            Dim dt As DataTable = Nothing

            Try
                strSql = "SELECT 'Pantech OW Invoice Receipt' AS 'ReportName'" & Environment.NewLine
                strSql &= ", if (BillType_ID = 1, '', BillCode_Desc) as BillCode_Desc " & Environment.NewLine
                strSql &= ", tdevice.Device_ID, Device_SN, Device_OldSN" & Environment.NewLine
                strSql &= ", Device_ManufWrty, Device_PSSWrty, Device_LaborCharge, tdevice.Ship_ID, tworkorder.WO_ID, WO_CustWO" & Environment.NewLine
                strSql &= ", IF(F.state_id IS NULL, 1, 1 + F.TaxRate) * DBill_InvoiceAmt AS DBill_InvoiceAmt, tdevicebill.BillCode_ID, BillCode_Rule, Model_Desc, ApprovedToRepair, RUR_ReturnToCust" & Environment.NewLine
                strSql &= ", tworkorder.PO_ID AS 'BillingPOID', tworkorder.ShipTo_ID, shipTo_Name as 'ToName', ShipTo_Address1 as 'ToAddress1'" & Environment.NewLine
                strSql &= ", ShipTo_Address2 AS 'ToAddress2', ShipTo_City AS ToCity, lstate.State_Short AS ToState, ShipTo_Zip AS ToZIP " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tworkorder.WO_ID = tdevice.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN pantechasn ON tdevice.Device_ID = pantechasn.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.Shipto_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_ID = lstate.State_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "LEFT JOIN production.statetax F ON tshipto.state_id = F.state_id" & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDeviceID & Environment.NewLine
                'strSql &= "WHERE tworkorder.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "GROUP BY tdevice.Device_ID, BillCode_Desc" & Environment.NewLine
                strSql &= "ORDER BY Device_SN;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetPantechWOInfo(ByVal strWONo As String, ByVal iLocID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE tworkorder.WO_CustWO = '" & strWONo & "' AND Loc_ID = " & iLocID & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************

        Public Function GetWaitingToBeDockShipRMA(ByVal iLocID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT DISTINCT tworkorder.WO_CustWO as RMA , tdevice.Ship_ID, Count(*) as Qty  " & Environment.NewLine
                strSql &= ", tpallett.Pallett_Name AS 'Box Name', WO_DateShip as 'Produced Date' " & Environment.NewLine
                strSql &= ", ShipTo_Name as ToName, ShipTo_Address1 as ToAddress1, ShipTo_Address2 as ToAddress2" & Environment.NewLine
                strSql &= ", ShipTo_City as ToCity, State_Short as ToState, ShipTo_Zip as ToZIP" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID" & Environment.NewLine
                strSql &= "INNER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID" & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_Id" & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is not null AND tship.TrackingNo is null " & Environment.NewLine
                strSql &= "GROUP BY tworkorder.WO_CustWO, tdevice.Ship_ID, tdevice.Pallett_ID ;"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetOWRejectRepairBillCode() As Integer
            Dim strSQL As String

            Try
                strSQL = "SELECT billcode_id" & Environment.NewLine
                strSQL &= "FROM production.lbillcodes" & Environment.NewLine
                strSQL &= "WHERE LCASE(billcode_desc) = 'ow reject repair'"

                Return Me._objDataProc.GetIntValue(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function GetBusinessShipDate(ByVal objReceiveDate As Object) As String
            'Convert objReceiveDate to a date and add 15 business days to it
            Try
                Dim dteShipDate As DateTime = Convert.ToDateTime(objReceiveDate)
                Dim iDayCount As Integer = 0

                While (iDayCount < 15)
                    dteShipDate = dteShipDate.AddDays(1)

                    If Not (dteShipDate.DayOfWeek = DayOfWeek.Saturday Or dteShipDate.DayOfWeek = DayOfWeek.Sunday) Then iDayCount += 1
                End While

                Return dteShipDate.ToString("MMMM d, yyyy")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetShipTypes() As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT ShipTypeID, ShipType" & Environment.NewLine
                strSQL &= "FROM production.shiptypes" & Environment.NewLine
                strSQL &= "ORDER BY ShipType"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub UpdateShipType(ByVal iShipID As Integer, ByVal iShipTypeID As Integer)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tship" & Environment.NewLine
                strSQL &= String.Format("SET ShipTypeID = {0}", iShipTypeID) & Environment.NewLine
                strSQL &= String.Format("WHERE ship_id = {0}", iShipID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub UpdateTrackingNumber(ByVal iShipID As Integer, ByVal strTN As String)
            Dim strSQL As String

            Try
                strSQL = "UPDATE production.tship" & Environment.NewLine
                strSQL &= String.Format("SET TrackingNo = '{0}'", strTN) & Environment.NewLine
                strSQL &= String.Format("WHERE ship_id = {0}", iShipID)

                Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************************************************

#End Region

        '*******************************************************************************************************************

        Public Function DeviceIsPantech(ByVal strIMEI As String, ByVal iPantechLocID As Integer) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT COUNT(*)" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= String.Format("WHERE device_sn = '{0}' AND loc_id = {1}", strIMEI, iPantechLocID)

                Return IIf(Me._objDataProc.GetIntValue(strSQL) > 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function DeviceOutOfWarranty(ByVal strIMEI As String) As Boolean
            Dim strSQL As String

            Try
                strSQL = "SELECT device_manufwrty" & Environment.NewLine
                strSQL &= "FROM production.tdevice" & Environment.NewLine
                strSQL &= String.Format("WHERE device_sn = '{0}'", strIMEI) & Environment.NewLine
                strSQL &= "AND production.tdevice.Device_Dateship is NULL "

                Return IIf(Me._objDataProc.GetIntValue(strSQL) = 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetDeviceData(ByVal strIMEI As String) As DataRow
            Dim strSQL As String

            Try
                strSQL = "SELECT A.device_id, A.model_id, B.model_desc AS Model, IF(C.cellopt_refurbcompleteuserid > 0 OR C.cellopt_refurbcompletedt IS NOT NULL, 'Yes', 'No') AS 'Refurb Completed?'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel B ON A.model_id = B.model_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tcellopt C ON A.device_id = C.device_id" & Environment.NewLine
                strSQL &= String.Format("WHERE A.device_sn = '{0}'", strIMEI)
                strSQL &= "AND A.Device_Dateship is NULL "

                Return Me._objDataProc.GetDataRow(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetHoldDeviceParts(ByVal iDeviceID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT A.device_id, B.billcode_id AS billcode_id, B.part_number AS 'Part', C.billcode_desc AS 'Bill Code'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tdevicebill B ON A.device_id = B.device_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.lbillcodes C ON B.billcode_id = C.billcode_id" & Environment.NewLine
                strSQL &= String.Format("WHERE A.device_id = {0}", iDeviceID) & Environment.NewLine
                strSQL &= "ORDER BY Part"

                Return Me._objDataProc.GetDataTable(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace