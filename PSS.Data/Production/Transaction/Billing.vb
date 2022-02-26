Option Explicit On 

Namespace Production
    Public Class Billing
        Private objMisc As Production.Misc

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************
        '********************************************************************
        Public Function GetDevice_BillInfo(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '//*****************************************************************
                '//Get Device related info
                '//*****************************************************************
                strSql = "SELECT " & Environment.NewLine
                strSql &= "tdevice.Device_ID, " & Environment.NewLine
                strSql &= "tdevice.Device_SN, " & Environment.NewLine
                strSql &= "tdevice.Device_OldSN, " & Environment.NewLine
                strSql &= "tdevice.Device_DateBill, " & Environment.NewLine
                strSql &= "tdevice.Device_DateShip, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
                strSql &= "tdevice.Tray_ID, " & Environment.NewLine
                strSql &= "tdevice.Loc_ID, " & Environment.NewLine
                strSql &= "tdevice.WO_ID, " & Environment.NewLine
                strSql &= "tdevice.Model_ID, " & Environment.NewLine
                strSql &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
                strSql &= "IF(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
                strSql &= "lpricinggroup.PrcType_ID, " & Environment.NewLine
                strSql &= "IF(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
                strSql &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
                strSql &= "tmodel.Prod_ID, " & Environment.NewLine
                strSql &= "tmodel.Manuf_ID, " & Environment.NewLine
                strSql &= "tmodel.ASCPrice_ID, " & Environment.NewLine
                strSql &= "lascprice.ASCPrice_Price, " & Environment.NewLine
                strSql &= "IF(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
                strSql &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
                strSql &= "IF(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1," & Environment.NewLine
                strSql &= "tcustomer.Cust_Name2," & Environment.NewLine
                strSql &= "tlocation.Loc_Name," & Environment.NewLine
                strSql &= "tcustomer.Pay_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
                strSql &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
                strSql &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
                strSql &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
                strSql &= "tcustomer.Cust_AggBilling, " & Environment.NewLine
                strSql &= "IF(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_RTM AS RTM_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Ner AS NER_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_NTF AS NTF_Price " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
                strSql &= "tcustwrty.PSSWrtyParts_ID, " & Environment.NewLine
                strSql &= "tcustwrty.PSSWrtyLabor_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_AutoShip , " & Environment.NewLine
                strSql &= "tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN lascprice on tmodel.ASCPrice_ID = lascprice.ASCPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID and tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID and tmodel.Prod_ID = tcusttoprice.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID and tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID and tmodel.Prod_ID = tcustwrty.Prod_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
                strSql &= "WHERE " & Environment.NewLine
                strSql &= "tdevice.Device_ID = " & iDevice_ID & ";"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetPartPriceInfo(ByVal iModel_ID As Integer, _
                                         ByVal iBillcode_id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '***********************************************************
                'Get Avg Cost and Std Cost and inv price from lpsprice table
                '***********************************************************
                strSql = "SELECT lpsprice.*, lbillcodes.BillType_ID, lbillcodes.BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                strSql &= "tpsmap.BillCode_ID = " & iBillcode_id & ";"
                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetMax_ConsumedLaborLvl_OfDev(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iMaxLaborLevel As Integer = 0

            Try
                '**********************************
                'Get Maximum Labor Level
                '**********************************
                strSql = "SELECT max(tpsmap.LaborLevel) as MaxLaborLevel " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDevice_ID & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("MaxLaborLevel")) Then
                        iMaxLaborLevel = dt1.Rows(0)("MaxLaborLevel")
                    End If
                End If

                Return iMaxLaborLevel
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetPOInfo(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                '**********************************
                'Get PO Information
                '**********************************
                'Get PO information
                strSql = "SELECT lpricinggroup.PrcType_ID, " & Environment.NewLine
                strSql &= "IF(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS ProductGroup, " & Environment.NewLine
                strSql &= "tpurchaseorder.PrcGroup_ID as PricingGroup, " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_ID, " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_Aggregate " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "INNER JOIN tpurchaseorder on tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpricinggroup ON tpurchaseorder.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDevice_ID & ";"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function GetAgg_BillInfo(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow

            Try
                '**********************************
                'Get Aggregate Information
                '**********************************
                strSql = "SELECT tcustaggregatebilling.billcode_id AS BillCode_ID, tcustaggregatebilling.tcab_Amount AS LaborChrg " & Environment.NewLine
                strSql &= "FROM tcustaggregatebilling " & Environment.NewLine
                strSql &= "WHERE cust_id = " & iCust_ID & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                strSql = "SELECT tcustaggregatebilling.billcode_id AS BillCode_ID, tcustaggregatebilling.labor_charge AS LaborChrg " & Environment.NewLine
                strSql &= "FROM tcust_model_aggbilling_default " & Environment.NewLine
                strSql &= "WHERE cust_id = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & ";"
                objMisc._SQL = strSql
                dt2 = objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    For Each R2 In dt2.Rows
                        If R1("BillCode_ID") = R2("Billcode_ID") Then
                            R1("LaborChrg") = R2("LaborChrg")
                        End If
                    Next R2
                Next R1

                dt1.AcceptChanges()

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '********************************************************************

    End Class
End Namespace