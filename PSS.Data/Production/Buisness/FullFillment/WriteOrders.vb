Option Explicit On 

Namespace Buisness.Fullfillment
    Public Class WriteOrders

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

        '*************************************************************************************
        Public Function GetSOHeader(ByVal iCustID As Integer, ByVal strOderNo As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.*, B.User_FullName FROM saleorders.soheader A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers B On A.OrderCreatedByUsrID = B.User_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.CustomerOrderNumber = '" & strOderNo & "'"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function AddSaleOrderHeader(ByVal iCustID As Integer, ByVal strFirstName As String, _
                                           ByVal strLastName As String, ByVal strAddr1 As String, _
                                           ByVal strAddr2 As String, ByVal strAddr3 As String, _
                                           ByVal strCity As String, ByVal strState As String, _
                                           ByVal strZip As String, ByVal strCountry As String, _
                                           ByVal strPhone As String, ByVal strEmail As String, _
                                           ByVal strPO As String, ByVal strOderNo As String, _
                                           ByVal iPSS_WOID As Integer, ByVal strOrderDate As String, _
                                           ByVal decOrderSubtotal As Decimal, ByVal decOrderdiscount As Decimal, _
                                           ByVal decTax1 As Decimal, ByVal decTax2 As Decimal, _
                                           ByVal decTax3 As Decimal, ByVal strInboundTrackingNumber As String, _
                                           ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim iSOHeaderID As Integer = 0
            Dim dt As DataTable

            Try
                strSql = "INSERT INTO saleorders.soheader (" & Environment.NewLine
                strSql &= " Cust_ID, CustomerFirstName, CustomerLastName, CustomerAddress1" & Environment.NewLine
                strSql &= ", CustomerAddress2, CustomerAddress3, CustomerCity, CustomerState" & Environment.NewLine
                strSql &= ", CustomerPostalCode, CustomerCountry, CustomerPhone, PONumber" & Environment.NewLine
                strSql &= ", CustomerOrderNumber, WorkOrderID, CustomerEmail, CustomerOrderDate" & Environment.NewLine
                strSql &= ", OrderSubtotal, OrderDiscount, OrderTax1, OrderTax2, OrderTax3" & Environment.NewLine
                strSql &= ", ReceiptTimestamp, InvalidOrder, OrderStatusID, InboundTrackingNumber" & Environment.NewLine
                strSql &= ", OrderCreatedByUsrID, OrderCreatedDate" & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iCustID & ", '" & strFirstName.Replace("'", "") & "', '" & strLastName.Replace("'", " ") & "', '" & strAddr1.Replace("'", "") & "' " & Environment.NewLine
                strSql &= ", '" & strAddr2.Replace("'", " ") & "', '" & strAddr3.Replace("'", " ") & "', '" & strCity.Replace("'", " ") & "', '" & strState & "' " & Environment.NewLine
                strSql &= ", '" & strZip.Replace("'", " ") & "', '" & strCountry & "', '" & strPhone.Replace("'", " ") & "', '" & strPO.Replace("'", " ") & "' " & Environment.NewLine
                strSql &= ", '" & strOderNo.Replace("'", " ") & "', " & iPSS_WOID & ", '" & strEmail & "', '" & Convert.ToDateTime(strOrderDate).ToString("yyyy-MM-dd hh:mm:ss") & "' " & Environment.NewLine
                strSql &= ", " & decOrderSubtotal & ", " & decOrderdiscount & ", " & decTax1 & ", " & decTax2 & ", " & decTax3 & Environment.NewLine
                strSql &= ", now(), 0, 1, '" & strInboundTrackingNumber.Replace("'", " ") & "' " & Environment.NewLine
                strSql &= ", " & iUserID & ", now() " & Environment.NewLine
                strSql &= " ) "
                iSOHeaderID = Me._objDataProc.idTransaction(strSql, "saleorders.soheader")

                If iSOHeaderID = 0 Then Throw New Exception("System has failed to create salse order header.")

                Return iSOHeaderID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Function AddSaleOrderDetails(ByVal iSOHeaderID As Integer, ByVal strItemCode As String, _
                                           ByVal strProductName As String, ByVal iQty As Integer, _
                                           ByVal strUnitOfMeasure As String, ByVal decBasePrice As Decimal, _
                                           ByVal decTax1 As Decimal, ByVal decTax2 As Decimal, _
                                           ByVal decTax3 As Decimal, ByVal strUPC As String, _
                                           ByVal decLineDiscount As Decimal, ByVal strSKU As String, _
                                           ByVal iModelID As Integer, ByVal iDevConditionID As Integer, _
                                           ByVal iCosmGradeID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iReturnVal, iLineItemNo As Integer

            Try
                strSql = "SELECT * FROM saleorders.sodetails " & Environment.NewLine
                strSql &= "WHERE SOHeaderID = " & iSOHeaderID & Environment.NewLine
                strSql &= "AND ItemCode = '" & strItemCode & "' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate sale order line item.")
                ElseIf dt.Rows.Count = 1 Then
                    iReturnVal = Convert.ToInt32(dt.Rows(0)("SODetailsID"))
                Else
                    iLineItemNo = GetMaxLineItemNo(iSOHeaderID) + 1
                    strSql = "INSERT INTO saleorders.sodetails ( " & Environment.NewLine
                    strSql &= " SOHeaderID, LineItemNumber, ItemCode, ProductName" & Environment.NewLine
                    strSql &= ", Quantity, UnitOfMeasure, BasePrice, LineTax1, LineTax2, LineTax3" & Environment.NewLine
                    strSql &= ", UPC, LineDiscount, SKU, Model_ID, DevConditionID, CosmGradeID" & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iSOHeaderID & ", " & iLineItemNo & ", '" & strItemCode & "', '" & strProductName & "'" & Environment.NewLine
                    strSql &= ", " & iQty & ", '" & strUnitOfMeasure & "', " & decBasePrice & ", " & decTax1 & ", " & decTax2 & ", " & decTax3 & Environment.NewLine
                    strSql &= ", '" & strUPC & "', " & decLineDiscount & ", '" & strSKU & "', " & iModelID & ", " & iDevConditionID & ", " & iCosmGradeID
                    strSql &= ") "
                    iReturnVal = Me._objDataProc.ExecuteNonQuery(strSql)
                End If
                If iReturnVal = 0 Then Throw New Exception("System has failed to create sale order detail.")

                Return iReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Private Function GetMaxLineItemNo(ByVal iSOHeaderID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT if(Max(LineItemNumber) is null, 0 , Max(LineItemNumber)) as LineItemNumber" & Environment.NewLine
                strSql &= "FROM saleorders.sodetails " & Environment.NewLine
                strSql &= "WHERE SOHeaderID = " & iSOHeaderID
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************


    End Class
End Namespace