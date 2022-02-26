Option Explicit On 

Namespace Buisness
    Public Class SaleOrderData

        '*************************************************************************
        Public Function GetOrderDetail(ByVal strCustOrderNo As String) As DataTable
            Dim objOFFM As OrderFulfilment
            Dim strSql As String = ""
            Dim dt, dtModels As DataTable
            Dim strModelDesc As String = ""
            Dim R1 As DataRow

            Try
                objOFFM = New OrderFulfilment()

                strSql = "SELECT a.SOHeaderID, itemcode as 'Item#', productname as 'Item Desc', c.ShipVia, sum(Quantity) as Qty " & Environment.NewLine
                strSql &= ", Concat(ShipFirstName, ' ', ShipLastName) as Name, ShipAddress1 as Address1, ShipAddress2 as Address2 " & Environment.NewLine
                strSql &= ", ShipCity as City, shipState as State, ShipPostalcode as ZipCode " & Environment.NewLine
                strSql &= ", ShipPhone " & Environment.NewLine
                strSql &= "FROM salesorders.soheader a " & Environment.NewLine
                strSql &= "INNER JOIN salesorders.sodetails b ON a.SOHeaderID = b.SOHeaderID" & Environment.NewLine
                strSql &= "INNER JOIN salesorders.shipment c ON a.SOHeaderID = c.SOHeaderID" & Environment.NewLine
                strSql &= "WHERE CustomerOrderNumber = '" & strCustOrderNo & "'" & Environment.NewLine
                strSql &= "GROUP BY itemcode; "

                dt = Connection5.GetDataTable(strSql)

                dt.Columns.Add(New DataColumn("Filled Qty", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("Model_ID", System.Type.GetType("System.Int32")))
                dt.Columns.Add(New DataColumn("Accessory?", System.Type.GetType("System.Int32")))

                For Each R1 In dt.Rows
                    If strModelDesc.Trim.Length > 0 Then strModelDesc &= ", "
                    strModelDesc &= "'" & R1("Item#") & "'"
                Next R1

                If strModelDesc.Trim.Length > 0 Then dtModels = objOFFM.GetModels(strModelDesc)

                For Each R1 In dt.Rows
                    R1.BeginEdit()
                    R1("Filled Qty") = 0
                    If Not IsNothing(dtModels) AndAlso dtModels.Select("Model_Desc = '" & R1("Item#") & "'").Length > 0 Then
                        R1("Model_ID") = dtModels.Select("Model_Desc = '" & R1("Item#") & "'")(0)("Model_ID")
                        R1("Accessory?") = dtModels.Select("Model_Desc = '" & R1("Item#") & "'")(0)("Accessory")
                    End If
                    R1.EndEdit()
                Next R1

                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                objOFFM = Nothing
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtModels)
            End Try
        End Function

        '*************************************************************************
        Public Function UpdateSaleOrderShipDate(ByVal strCustOrderNo As String, _
                                                ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE salesorders.soheader SET ShipDate = now(), WorkOrderID = " & iWOID & Environment.NewLine
                strSql &= "WHERE CustomerOrderNumber = '" & strCustOrderNo & "'" & Environment.NewLine
                Return Connection5.ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetCompanyNameAndShipVia(ByVal strCustOrderNo As String) As DataRow
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT b.CompanyName, c.ShipVia " & Environment.NewLine
                strSql &= "FROM salesorders.soheader a " & Environment.NewLine
                strSql &= "INNER JOIN salesorders.company b ON a.CompanyID = b.CompanyID" & Environment.NewLine
                strSql &= "INNER JOIN salesorders.shipment c ON a.SOHeaderID = c.SOHeaderID" & Environment.NewLine
                strSql &= "WHERE CustomerOrderNumber = '" & strCustOrderNo & "'" & Environment.NewLine
                dt = Connection5.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then Return dt.Rows(0) Else  : Return Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function GetPackingSlipReportData(ByVal iWOID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = " SELECT Concat(CustomerFirstName, ' ', CustomerLastName ) as BillingName " & Environment.NewLine
                strSql &= " , CustomerAddress1 as BillingAddress1 " & Environment.NewLine
                strSql &= " , Concat(CustomerCity, ', ', CustomerState, ' ' , CustomerPostalCode) as BillingAddress1CityState " & Environment.NewLine
                strSql &= " , CustomerAddress2 as BillingAddress2 " & Environment.NewLine
                strSql &= " , Concat(ShipFirstName, ' ', ShipLastName) as ShippingName " & Environment.NewLine
                strSql &= " , ShipAddress1 as ShippingAddress1 " & Environment.NewLine
                strSql &= " , concat(ShipCity, ', ', ShipState, ' ' , ShipPostalCode) as ShippingAddress1CityState " & Environment.NewLine
                strSql &= " , ShipAddress2 as ShippingAddress2 " & Environment.NewLine
                strSql &= " , '' as ShipmentNumber " & Environment.NewLine
                strSql &= " , '' as TrackingNumber " & Environment.NewLine
                strSql &= " , '' as BoxNumber " & Environment.NewLine
                strSql &= " , 0 as Quantity " & Environment.NewLine
                strSql &= " , c.ItemCode as Item " & Environment.NewLine
                strSql &= " , c.ProductName as Description " & Environment.NewLine
                strSql &= " , a.CustomerOrderNumber as OrderNumber " & Environment.NewLine
                strSql &= " , a.PONumber as PONumber " & Environment.NewLine
                strSql &= " , a.WorkOrderID as WOID " & Environment.NewLine
                strSql &= " , '' as UPCCode " & Environment.NewLine
                strSql &= " FROM salesorders.soheader a " & Environment.NewLine
                strSql &= " INNER JOIN salesorders.shipment b on a.SOHeaderID = b.SOHeaderID " & Environment.NewLine
                strSql &= " INNER JOIN salesorders.sodetails C on a.SOHeaderID = C.SOHeaderID " & Environment.NewLine
                strSql &= " WHERE WorkOrderID = " & iWOID & "; " & Environment.NewLine
                Return Connection5.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************
        Public Function UpdateFedexReturnTrackingNumber(ByVal strItemNumber As String, _
                                                        ByVal strTracKingNumber As String, _
                                                        ByVal iSOHeaderID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE salesorders.sodetails " & Environment.NewLine
                strSql &= "SET ReturnFedExTrackingNumber = '" & strTracKingNumber & "' " & Environment.NewLine
                strSql &= "WHERE ItemCode = '" & strItemNumber & "'" & Environment.NewLine
                strSql &= "AND SOHeaderID = " & iSOHeaderID & Environment.NewLine
                Return Connection5.ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************


    End Class
End Namespace