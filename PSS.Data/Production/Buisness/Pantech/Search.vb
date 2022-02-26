Option Explicit On 

Imports DBQuery.DataProc

Namespace Buisness
    Public Class PantechSearch

        Private _objDataProc As New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

#Region "Constructor/Destructor"
        '*******************************************************************************************************************
        Public Sub New()
            Try
                'Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
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

        '*******************************************************************************************************************

        Public Function GetSearchData() As DataSet
            Dim strSQL As String
            Dim ds As DataSet = Nothing
            Dim dt As DataTable = Nothing

            Try
                Dim iLocID As Integer = Pantech.Pantech_LOC_ID()

                ds = New DataSet("Pantech Returns Data")

                strSQL = "SELECT DISTINCT E.shipto_id, D.wo_custwo AS 'RMA', CASE WHEN G.ApprovedToRepairDate IS NULL THEN 'N/A' ELSE IF(G.ApprovedToRepair = 0, 'No', 'Yes') END AS 'Approved?', E.shipto_name AS 'Customer', CONCAT(E.shipto_address1, '\r\n', IF(E.shipto_address2 IS NULL OR LENGTH(TRIM(E.shipto_address2)) = 0, '', CONCAT(E.shipto_address2 , '\r\n')), E.shipto_city, ', ', F.state_short, ' ', E.shipto_zip) AS 'Address', E.tel AS 'Telephone', E.fax AS 'FAX', E.email AS 'Email'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel B ON A.model_id = B.model_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.lstate F ON E.state_id = F.state_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.pantechasn G ON A.Device_ID = G.Device_ID" & Environment.NewLine
                strSQL &= String.Format("WHERE A.loc_id = {0}", iLocID) & Environment.NewLine
                strSQL &= "GROUP BY D.wo_custwo" & Environment.NewLine
                strSQL &= "ORDER BY 'RMA', 'Customer', 'Address'"

                dt = Me._objDataProc.GetDataTable(strSQL)
                dt.TableName = "Customer Info"
                ds.Tables.Add(dt)

                Dim dr As DataRow
                Dim strShipToIDsIn As String = String.Empty

                For Each dr In dt.Rows : strShipToIDsIn &= IIf(strShipToIDsIn.Length > 0, ", ", String.Empty) & dr("shipto_id").ToString : Next dr

                strSQL = "SELECT D.wo_custwo AS 'RMA', A.device_id, IFNULL(H.cellopt_msn, 'N/A') AS 'SN', A.device_sn AS 'IMEI', I.wipowner_desc AS 'WIP Status', B.model_desc AS 'Model', IF(A.Device_ManufWrty = 1, 'In', 'Out') AS 'Warranty Status', IFNULL(A.Device_Laborcharge, 0) AS 'Labor Charge', G.ApprovedPartPrice AS 'Parts Charge', G.TaxOnParts AS 'Tax On Parts', DATE_FORMAT(A.device_recworkdate, '%M %e, %Y') AS 'Receive Date', IF(A.device_shipworkdate IS NULL, '', DATE_FORMAT(A.device_shipworkdate, '%M %e, %Y')) AS 'Ship Date', IF(A.device_shipworkdate IS NULL, 0, 1) AS 'Device Shipped Temp', IFNULL(J.TrackingNo, 'N/A') AS 'Tracking Number Temp'" & Environment.NewLine
                strSQL &= "FROM production.tdevice A" & Environment.NewLine
                strSQL &= "INNER JOIN production.tmodel B ON A.model_id = B.model_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tworkorder D ON A.wo_id = D.wo_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.tshipto E ON D.shipto_id = E.shipto_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.lstate F ON E.state_id = F.state_id" & Environment.NewLine
                strSQL &= "INNER JOIN production.pantechasn G ON A.Device_ID = G.Device_ID" & Environment.NewLine
                strSQL &= "INNER JOIN production.tcellopt H ON A.Device_ID = H.Device_ID" & Environment.NewLine
                strSQL &= "INNER JOIN production.lwipowner I ON H.cellopt_wipowner = I.wipowner_id" & Environment.NewLine
                strSQL &= "LEFT JOIN production.tship J ON A.ship_id = J.ship_id" & Environment.NewLine
                strSQL &= String.Format("WHERE A.loc_id = {0} AND D.shipto_id IN ({1})", iLocID, strShipToIDsIn) & Environment.NewLine
                strSQL &= "GROUP BY A.device_id" & Environment.NewLine
                strSQL &= "ORDER BY E.shipto_id, 'SN/IMEI'"

                dt = Me._objDataProc.GetDataTable(strSQL)
                dt.TableName = "Device Info"
                dt.Columns.Add(New DataColumn("Device Shipped", System.Type.GetType("System.Boolean")))
                dt.Columns.Add(New DataColumn("Tracking Number", System.Type.GetType("System.String"))) 'So it will appear after 'Device Shipped'

                For Each dr In dt.Rows
                    dr.BeginEdit()

                    If dr("Ship Date").ToString().Length = 0 Then
                        dr("Ship Date") = GetBusinessShipDate(dr("Receive Date"))
                        dr("Device Shipped") = Convert.ToBoolean(dr("Device Shipped Temp"))
                    End If

                    dr("Tracking Number") = dr("Tracking Number Temp")

                    dr.EndEdit()
                    dr.AcceptChanges()
                Next dr

                dt.Columns.Remove("Device Shipped Temp")
                dt.Columns.Remove("Tracking Number Temp")

                ds.Tables.Add(dt)
                ds.Relations.Add(New DataRelation("Customer to Device", ds.Tables("Customer Info").Columns("RMA"), ds.Tables("Device Info").Columns("RMA")))

                Dim strDeviceIDsIn As String = String.Empty

                For Each dr In dt.Rows : strDeviceIDsIn &= IIf(strDeviceIDsIn.Length > 0, ", ", String.Empty) & dr("device_id").ToString : Next dr

                strSQL = "SELECT A.device_id, A.billcode_id, A.part_number AS 'Part', B.billcode_desc AS 'Bill Code', A.DBill_InvoiceAmt AS 'Part Charge'" & Environment.NewLine
                strSQL &= "FROM production.tdevicebill A" & Environment.NewLine
                strSQL &= "INNER JOIN production.lbillcodes B ON A.billcode_id = B.billcode_id" & Environment.NewLine
                strSQL &= String.Format("WHERE A.device_id IN ({0})", strDeviceIDsIn) & Environment.NewLine
                strSQL &= "ORDER BY A.device_id, 'Bill Code'"

                dt = Me._objDataProc.GetDataTable(strSQL)
                dt.TableName = "Prebill Info"

                ds.Tables.Add(dt)
                ds.Relations.Add(New DataRelation("Device to Prebill", ds.Tables("Device Info").Columns("device_id"), ds.Tables("Prebill Info").Columns("device_id")))

                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDS(ds)
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

    End Class
End Namespace