Imports eInfoDesigns.dbProvider.MySqlClient
Imports PSS.Data.Production

Namespace Buisness

    Public Class DeviceBilling

        Private _objDataProc As DBQuery.DataProc

        '*******************************************************************
        'Added by Lan on 11/21/2007. Using new connection object
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '*******************************************************************
        Public Function AddRecrystaledLaborChrgForAMCust(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String
            Dim dt1 As DataTable
            Dim drArr As DataRow()
            Dim dbLaborCharge As Double = 0.0
            Dim iRetVal As Integer = 0

            Try
                strSql = "SELECT DISTINCT Device_LaborCharge, Model_ID, Billcode_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDevice_ID & " " & Environment.NewLine
                strSql &= "AND Model_ID in (2, 7);" 'AG and BF

                dt1 = Me._objDataProc.GetDataTable(strSql)
                If dt1.Rows.Count > 0 Then  'Device has billcodes
                    If Not IsDBNull(dt1.Rows(0)("Device_LaborCharge")) Then 'Labor charge is not null
                        dbLaborCharge = dt1.Rows(0)("Device_LaborCharge")

                        drArr = dt1.Select("BillCode_ID = 20")  'Recrystaled

                        If drArr.Length > 0 Then    'Have recrystaled billcode
                            If dt1.Rows(0)("Model_ID") = 2 Then 'AG
                                If dbLaborCharge = 8.55 Then
                                    'Add $4.50 to any AG model if Recrystaled is billed
                                    strSql = "UPDATE tdevice " & Environment.NewLine
                                    strSql &= "SET Device_LaborCharge = " & dbLaborCharge + 4.5 & Environment.NewLine
                                    strSql &= "WHERE Device_ID = " & iDevice_ID & ";"
                                    iRetVal = Me._objDataProc.ExecuteNonQuery(strSql)
                                End If
                            ElseIf dt1.Rows(0)("Model_ID") = 7 Then
                                If dbLaborCharge = 7.0 Then
                                    'Add $4.50 to any BF model if Recrystaled is billed
                                    strSql = "UPDATE tdevice " & Environment.NewLine
                                    strSql &= "SET Device_LaborCharge = " & dbLaborCharge + 4.5 & Environment.NewLine
                                    strSql &= "WHERE Device_ID = " & iDevice_ID & ";"
                                    iRetVal = Me._objDataProc.ExecuteNonQuery(strSql)
                                End If
                            End If
                        Else    'does not have recrystaled billcode
                            If dt1.Rows(0)("Model_ID") = 2 Then 'AG
                                If dbLaborCharge > 8.55 Then
                                    'subtract $4.50 to any AG model if Recrystaled is not billed
                                    strSql = "UPDATE tdevice " & Environment.NewLine
                                    strSql &= "SET Device_LaborCharge = " & dbLaborCharge - 4.5 & Environment.NewLine
                                    strSql &= "WHERE Device_ID = " & iDevice_ID & ";"
                                    iRetVal = Me._objDataProc.ExecuteNonQuery(strSql)
                                End If
                            Else
                                If dbLaborCharge > 7.0 Then
                                    'subtract $4.50 to any AG model if Recrystaled is not billed
                                    strSql = "UPDATE tdevice " & Environment.NewLine
                                    strSql &= "SET Device_LaborCharge = " & dbLaborCharge - 4.5 & Environment.NewLine
                                    strSql &= "WHERE Device_ID = " & iDevice_ID & ";"
                                    iRetVal = Me._objDataProc.ExecuteNonQuery(strSql)
                                End If
                            End If 'Model type
                        End If  'Billcode
                    End If  'Labor charge is not null
                End If  'Device has billcodes

                Return iRetVal
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*******************************************************************
        Public Function UnShipMessDBR(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "Update tdevice " & Environment.NewLine
                strSql &= "SET Device_DateShip = null, " & Environment.NewLine
                strSql &= "Device_ShipWorkDate = null, " & Environment.NewLine
                strSql &= "ship_id = null, " & Environment.NewLine
                strSql &= "Shift_ID_Ship = null " & Environment.NewLine
                strSql &= "WHERE device_id = " & iDevice_ID & " " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Function DeleteDBRCode(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "delete from tdevicecodes " & Environment.NewLine
                strSql &= "WHERE device_id = " & iDevice_ID & " " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Public Shared Function GetPayID(ByVal iTray_ID As Integer) As DataTable
            Dim strSql As String
            Dim objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSql = "SELECT pay_id " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strSql &= "WHERE tdevice.tray_id = " & iTray_ID & ";"

                Return objDataProc.GetdataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*******************************************************************
        Public Shared Function GetDeviceTrayByID(ByVal TrayID As Int32) As DataTable
            Dim strSql As String
            Dim objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Try
                strSql = "SELECT device_id, device_cnt AS 'Cnt', device_sn, device_oldsn, device_datebill, Model_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Tray_ID = " & TrayID & " " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip IS NULL;"

                'Added by Lan on 11/21/2007. Start using new connection
                'Return GetDataTable(strSql)
                Return objDataProc.GetdataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*******************************************************************
        Public Shared Sub SetBiller(ByVal UserName As String, ByVal Tray As Integer)
            Dim strSql As String = ""

            Try
                strSql = "UPDATE ttray SET Tray_BillUser = '" & UserName & "' WHERE Tray_ID = " & Tray & ";"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDeviceData(ByVal Device As Integer) As DataRow
            Dim strSql As String = ""
            Dim R1 As DataRow = Nothing
            Dim dt As DataTable

            Try
                strSql = "SELECT " & Environment.NewLine
                strSql &= "tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & Environment.NewLine
                strSql &= "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & Environment.NewLine
                strSql &= "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & Environment.NewLine
                strSql &= "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & Environment.NewLine
                strSql &= "tdevice.Model_ID, " & Environment.NewLine
                strSql &= "If(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & Environment.NewLine
                strSql &= "If(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS PoductGroup, " & Environment.NewLine
                strSql &= " If(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & Environment.NewLine
                strSql &= "tmodel.Prod_ID, tmodel.Manuf_ID, tmodel.Model_Desc " & Environment.NewLine
                strSql &= ", lmanuf.Claimable, lmanuf.ClaimStartRepairLevel, lmanuf.Claimable_RURCharge " & Environment.NewLine
                strSql &= ", If(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & Environment.NewLine
                strSql &= "If(tworkorder.PO_ID > 0, POPricinggroup.PrcType_ID, lpricinggroup.PrcType_ID ) AS PrcType_ID, " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_RUR, " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_NER , " & Environment.NewLine
                strSql &= "tpurchaseorder.PO_RTM , " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1," & Environment.NewLine
                strSql &= "tcustomer.Cust_Name2," & Environment.NewLine
                strSql &= "tlocation.Loc_Name," & Environment.NewLine
                strSql &= "tcustomer.Pay_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_RejectDays, " & Environment.NewLine
                strSql &= "tcustomer.Cust_RepairNonWrty, " & Environment.NewLine
                strSql &= "tcustomer.Cust_ReplaceLCD, " & Environment.NewLine
                strSql &= "tcustomer.Cust_CollSalesTax, " & Environment.NewLine
                strSql &= "tcustomer.PCo_ID, " & Environment.NewLine
                strSql &= "tcustomer.Cust_AggBilling, tcustomer.PredeterminePartNeed, " & Environment.NewLine
                strSql &= "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Rur AS RUR_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Ner as NER_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_NTF AS NTF_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_RTM AS RTM_Price, " & Environment.NewLine
                strSql &= "tcustmarkup.Markup_Cust as Cust_Markup, " & Environment.NewLine
                strSql &= "tcustmarkup.markup_PlusRepl, " & Environment.NewLine
                strSql &= "tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip " & Environment.NewLine
                strSql &= ", tcustomer.Cust_ID " & Environment.NewLine
                strSql &= ", tdevice.Device_Qty,tmodel.Has_BC" & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpricinggroup POPricinggroup ON tpurchaseorder.PrcGroup_ID = POPricinggroup.PrcGroup_ID AND tmodel.Prod_ID = POPricinggroup.Prod_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & Device & Environment.NewLine
                strSql &= "AND tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
                strSql &= "AND tmodel.Prod_ID = tcusttoprice.Prod_ID " & Environment.NewLine
                strSql &= "AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & Environment.NewLine
                strSql &= "AND tcustwrty.Prod_ID = tmodel.Prod_ID;" & Environment.NewLine
                dt = GetDataTable(strSql)
                If dt.Rows.Count = 1 Then
                    R1 = dt.Rows(0)
                ElseIf dt.Rows.Count = 0 Then
                    Throw New Exception("Some data is missing in customer set up. Please contact customer services department.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate data existed. Please contact customer services department.")
                End If

                Return R1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try

            '''Dim strSql As String = "SELECT " & _
            '''    "tdevice.Device_SN, tdevice.Device_OldSN, tdevice.Device_DateBill, tdevice.Device_DateShip, " & _
            '''    "IF(tdevice.Device_Invoice IS Null, 0, tdevice.Device_Invoice) as Device_Invoice, " & _
            '''    "IF(tdevice.Device_ManufWrty IS Null, 0, tdevice.Device_ManufWrty) AS Device_ManufWrty, " & _
            '''    "IF(tdevice.Device_PSSWrty IS Null, 0, tdevice.Device_PSSWrty) AS Device_PSSWrty, " & _
            '''    "IF(tdevice.Device_Reject IS Null, 0, tdevice.Device_Reject) AS Device_Reject, " & _
            '''    "IF(tdevice.Device_LaborLevel IS Null, 0, tdevice.Device_LaborLevel) AS Device_LaborLevel, " & _
            '''    "IF(tdevice.Device_LaborCharge IS Null, 0.00, tdevice.Device_LaborCharge) AS Device_LaborCharge, " & _
            '''    "tdevice.Tray_ID, tdevice.Loc_ID, tdevice.WO_ID, " & _
            '''    "IF(tdevice.Ship_ID IS Null, 0, tdevice.Ship_ID) AS Ship_ID, " & _
            '''    "tdevice.Model_ID, " & _
            '''    "If(tdevice.WebInfo_ID IS Null, 0,tdevice.WebInfo_ID) AS WebInfo_ID, " & _
            '''    "If(lpricinggroup.PrcType_ID = 1, tmodel.Model_Tier, tmodel.Model_Flat) AS PoductGroup, " & _
            '''    " If(tworkorder.PO_ID > 0, tpurchaseorder.PrcGroup_ID, lpricinggroup.PrcGroup_ID) AS PricingGroup, " & _
            '''    "tmodel.Prod_ID, " & _
            '''    "If(tworkorder.PO_ID IS Null, 0, tworkorder.PO_ID) as PO_ID, " & _
            '''    "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_PlusParts,tcustmarkup.Markup_PlusParts) as PlusParts, " & _
            '''    "If(tworkorder.PO_ID > 0, tpurchaseorder.PO_ChgManufWrty, 0) AS PO_ChgWrty, " & _
            '''    "tcustomer.Cust_Name1," & _
            '''    "tcustomer.Cust_Name2," & _
            '''    "tlocation.Loc_Name," & _
            '''    "tcustomer.Pay_ID, " & _
            '''    "tcustomer.Cust_RejectDays, " & _
            '''    "tcustomer.Cust_RepairNonWrty, " & _
            '''    "tcustomer.Cust_ReplaceLCD, " & _
            '''    "tcustomer.Cust_CollSalesTax, " & _
            '''    "If(tcustomer.Cust_Name2 IS Null, 0, 1) AS EndUser, " & _
            '''    "tcustmarkup.Markup_Rur AS RUR_Price, " & _
            '''    "tcustmarkup.Markup_Ner as NER_Price, " & _
            '''    "tcustmarkup.Markup_Cust as Cust_Markup, " & _
            '''    "lpricinggroup.PrcType_ID,   tcustwrty.PSSWrtyParts_ID, tcustwrty.PSSWrtyLabor_ID, tcustomer.Cust_AutoShip " & _
            '''    ", tcustomer.Cust_ID " & _
            '''    ", tcustmarkup.Markup_NTF AS NTF_Price " & _
            '''    "FROM ((((((((tmodel " & _
            '''    "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID) " & _
            '''    "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID) " & _
            '''    "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID) " & _
            '''    "LEFT OUTER JOIN tpurchaseorder ON tworkorder.PO_ID = tpurchaseorder.PO_ID) " & _
            '''    "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID) " & _
            '''    "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID) " & _
            '''    "INNER JOIN lpricinggroup ON tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID) " & _
            '''    "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID) " & _
            '''    "INNER JOIN tdevice ON tmodel.Model_ID = tdevice.Model_ID " & _
            '''    "WHERE(tdevice.Device_ID = " & Device & " And tmodel.Prod_ID = tcustmarkup.Prod_ID) " & _
            '''    "AND tmodel.Prod_ID = lpricinggroup.Prod_ID " & _
            '''    "AND tcustwrty.Prod_ID = tmodel.Prod_ID;"
            '''  Return GetDataTable(strSql).Rows(0)
            'Craig Haney - added May 26, 2005 - NTF to select
        End Function

        Public Shared Function GetBilledData(ByVal Device As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt " & Environment.NewLine
                strSql &= ", tdevicebill.Device_ID, tdevicebill.BillCode_ID, tdevicebill.Fail_ID" & Environment.NewLine
                strSql &= ", tdevicebill.Repair_ID, tdevicebill.Comp_ID, tdevicebill.User_ID, tdevicebill.Part_Number " & Environment.NewLine
                strSql &= ", lbillcodes.BillType_ID, lbillcodes.BillCode_Rule, lbillcodes.Billcode_Desc, ReplPartSN  " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & Device & ";"

                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function GetLaborData(ByVal PriceGroup As Integer, ByVal ProductGroup As Integer) As DataTable
            Dim strSql = "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc, LaborLvl_ID " & _
                               "FROM tlaborprc WHERE PrcGroup_ID = " & PriceGroup & _
                               " AND ProdGrp_ID = " & ProductGroup & ";"
            Return GetDataTable(strSql)
        End Function

        Public Shared Function GetPartData(ByVal Model As Integer) As DataTable
            'Dim strSql As String = ""
            'strSql = "SELECT lbillcodes.BillCode_ID, LaborLvl_ID, PSPrice_AvgCost, " & Environment.NewLine
            'strSql &= "PSPrice_StndCost, BillCode_Rule, BillType_ID, Fail_ID, Repair_ID, " & Environment.NewLine
            'strSql &= "tmodel.ASCPrice_ID, lascprice.ASCPrice_Price, tmodel.Manuf_ID, tmodel.Prod_ID " & Environment.NewLine
            'strSql &= "FROM tpsmap,lbillcodes,lpsprice,lascprice,tmodel " & Environment.NewLine
            'strSql &= "where tpsmap.BillCode_ID =lbillcodes.BillCode_ID and " & Environment.NewLine
            'strSql &= "tpsmap.PSPrice_ID = lpsprice.PSPrice_ID and " & Environment.NewLine
            'strSql &= "tmodel.ASCPrice_ID = lascprice.ASCPrice_ID and " & Environment.NewLine
            'strSql &= "tpsmap.Model_ID = tmodel.Model_ID and " & Environment.NewLine
            'strSql &= "tpsmap.Inactive = 0 and " & Environment.NewLine
            'strSql &= "tpsmap.Model_ID = " & Model & ";"


            Dim strSql As String = ""
            Try
                strSql = "SELECT lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc, LaborLvl_ID, PSPrice_AvgCost, " & Environment.NewLine
                strSql &= "PSPrice_StndCost, BillCode_Rule, BillType_ID, If(Fail_ID is null, 0, Fail_ID) as Fail_ID , Repair_ID, " & Environment.NewLine
                strSql &= "tmodel.ASCPrice_ID, lascprice.ASCPrice_Price, tmodel.Manuf_ID " & Environment.NewLine
                strSql &= ", tmodel.Prod_ID, lpsprice.PSPrice_Number, lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= ", tpsmap.LaborLevel" & Environment.NewLine
                strSql &= ", lpsprice.RVFlag, lpsprice.PSPrice_ConsignedPart, lpsprice.MaxInventory " & Environment.NewLine
                strSql &= "FROM tpsmap  " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tpsmap.BillCode_ID =lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & Model & Environment.NewLine
                strSql &= "ORDER BY lbillcodes.BillCode_Desc " & Environment.NewLine

                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Shared Function GetPartData_NI(ByVal Model As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT lbillcodes.BillCode_ID, lbillcodes.BillCode_Desc, LaborLvl_ID, " & Environment.NewLine
                strSql &= "CASE lbillcodes.aggbill WHEN 1 then tcustaggregatebilling.tcab_amount ELSE PSPrice_AvgCost END AS PSPrice_AvgCost, " & Environment.NewLine
                strSql &= "CASE lbillcodes.aggbill WHEN 1 then tcustaggregatebilling.tcab_amount ELSE PSPrice_StndCost END AS PSPrice_StndCost, " & Environment.NewLine
                strSql &= "BillCode_Rule, " & Environment.NewLine
                strSql &= "BillType_ID, " & Environment.NewLine
                strSql &= "If(Fail_ID is null, 0, Fail_ID) as Fail_ID , " & Environment.NewLine
                strSql &= "Repair_ID, " & Environment.NewLine
                strSql &= "tmodel.ASCPrice_ID, " & Environment.NewLine
                strSql &= "CASE lbillcodes.aggbill WHEN 1 then tcustaggregatebilling.tcab_amount ELSE lascprice.ASCPrice_Price END AS ASCPrice_Price, " & Environment.NewLine
                strSql &= "tmodel.Manuf_ID, " & Environment.NewLine
                strSql &= "tmodel.Prod_ID, lpsprice.PSPrice_Number, lpsprice.PSPrice_ID, " & Environment.NewLine
                strSql &= "tpsmap.LaborLevel, " & Environment.NewLine
                strSql &= "lpsprice.RVFlag, lpsprice.PSPrice_ConsignedPart, lpsprice.MaxInventory " & Environment.NewLine
                strSql &= "FROM tpsmap  " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tpsmap.BillCode_ID =lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN lascprice ON tmodel.ASCPrice_ID = lascprice.ASCPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT JOIN tcustaggregatebilling ON lbillcodes.billcode_ID = tcustaggregatebilling.billcode_id " & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & Model & Environment.NewLine
                strSql &= "ORDER BY lbillcodes.BillCode_Desc " & Environment.NewLine
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************
        Public Shared Function GetExcepCode(ByVal BillCode As Integer, ByVal ProductGroup As Integer, ByVal PriceGroup As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT BillExcptType_ID FROM tbillexcpt " & Environment.NewLine
                strSql &= "WHERE BillCode_ID = " & BillCode & " AND ProdGrp_ID = " & ProductGroup & Environment.NewLine
                strSql &= "AND PrcGroup_ID = " & PriceGroup & ";"
                dt = GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return 0
                Else
                    Return Convert.ToInt16(dt.Rows(0)("BillExcptType_ID"))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*****************************************************************************************************************
        Public Shared Function GetPartBillExceptionItem(ByVal iCustID As Integer, ByVal iWOID As Integer, _
                                                        ByVal iModelID As Integer, ByVal iBillcodeID As Integer) As Decimal
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Price_Amount FROM texceptionbillitems " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " " & Environment.NewLine
                strSql &= "AND WO_ID = " & iWOID & " " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModelID & " AND Billcode_ID = " & iBillcodeID
                dt = GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return 0
                Else
                    Return Convert.ToDecimal(dt.Rows(0)("Price_Amount"))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************************************
        Public Shared Function DeletePart(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer, ByVal iShiftID As Integer, _
                                     ByVal iUserID As Integer, ByVal iEmpNo As Integer, ByVal iScreenID As Integer)
            Const iTransactionAmount As Integer = -1
            Dim strSql, strPartNumber As String
            Dim dt As DataTable
            Dim objDataProc As MySql4.DataProc
            Dim i As Integer

            Try
                strSql = "" : strPartNumber = ""
                objDataProc = New MySql4.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT * FROM tdevicebill WHERE Device_ID = " & iDeviceID & " AND BillCode_ID = " & iBillcodeID & ";"
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strPartNumber = dt.Rows(0)("Part_Number").ToString.Trim
                Else
                    strSql = "SELECT * FROM tparttransaction WHERE Device_ID = " & iDeviceID & " AND Billcode_ID = " & iBillcodeID & " AND Trans_Amount = 1 ORDER BY Trans_ID Desc"
                    dt = objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then strPartNumber = dt.Rows(0)("Part_Number").ToString.Trim
                End If

                strSql = "DELETE FROM tdevicebill WHERE Device_ID = " & iDeviceID & " AND " & _
                                   "BillCode_ID = " & iBillcodeID & ";"
                i = objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to remove part.")

                If strPartNumber.Trim.Length > 0 Then i = InsertPartTransaction(iDeviceID, iBillcodeID, iUserID, iEmpNo, iShiftID, strPartNumber, iTransactionAmount, iScreenID)
                If i = 0 Then MsgBox("The REMOVE transaction for this billcode could not be processed.", MsgBoxStyle.Critical, "ERROR")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************************************
        Public Shared Sub DeleteAllParts(ByVal Device As Integer)
            Dim strSql As String = ""
            Try
                strSql = "DELETE FROM tdevicebill WHERE Device_ID = " & Device & ";"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************************************
        Public Shared Sub UpdateParts(ByVal Device As Integer, ByVal BillItem As DataRow)
            Dim strSql As String = ""
            Try
                strSql = "INSERT INTO tdevicebill ( DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt " & Environment.NewLine
                strSql &= ", Device_ID, BillCode_ID, Fail_ID, Repair_ID, User_ID, Date_Rec, Part_Number " & Environment.NewLine
                If Convert.ToInt32(BillItem("Comp_ID")) > 0 Then strSql &= ", Comp_ID" & Environment.NewLine
                strSql &= ", ReplPartSN " & Environment.NewLine
                strSql &= " ) VALUES (" & Environment.NewLine
                strSql &= BillItem("DBill_RegPartPrice") & ", '" & BillItem("DBill_AvgCost") & "','" & BillItem("DBill_StdCost") & "' " & Environment.NewLine
                strSql &= ", '" & BillItem("DBill_InvoiceAmt") & "', '" & BillItem("Device_ID") & "' " & Environment.NewLine
                strSql &= ", '" & BillItem("BillCode_ID") & "','" & BillItem("Fail_ID") & "','" & BillItem("Repair_ID") & "'" & Environment.NewLine
                strSql &= ", '" & BillItem("User_ID") & "', DATE_FORMAT(now(), '%Y-%m-%d'), '" & BillItem("Part_Number") & "'" & Environment.NewLine
                If Convert.ToInt32(BillItem("Comp_ID")) > 0 Then strSql &= ", " & BillItem("Comp_ID") & Environment.NewLine
                strSql &= ", '" & BillItem("ReplPartSN").ToString & "'" & Environment.NewLine
                strSql &= " ) ;"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************************************
        Public Shared Sub SetLaborData(ByVal Device As Integer, _
                                        ByVal dbOWRepLabor As Double, _
                                        ByVal dbIWRepLabor As Double, _
                                        ByVal dbOWRepPartCharge As Double, ByVal dbIWRepPartCharge As Double, _
                                        ByVal iPSSWrty As Integer, _
                                        ByVal ManufWrty As Integer, _
                                        ByVal LaborLevel As Integer, _
                                        ByVal [Date] As String, _
                                        ByVal ship As Boolean, _
                                        ByVal location As Integer, _
                                        Optional ByVal iShift_ID As Integer = 0)
            Dim strWorkDate, strSql, strSqlTransferWIP As String
            Dim strDate As String = "Null"

            Try
                strWorkDate = "" : strSql = "" : strSqlTransferWIP = ""
                strWorkDate = Generic.GetWorkDate(iShift_ID)

                If [Date].ToString.Trim.ToLower <> "Null".ToString.Trim.ToLower Then
                    [Date] = "'" & [Date] & "'"
                    strDate = "now()"
                End If

                strSql = "UPDATE tdevice SET Device_DateBill = " & strDate & ", Device_ManufWrty = " & ManufWrty & Environment.NewLine
                strSql &= ", Device_PSSWrty = " & iPSSWrty & ", Device_LaborLevel = " & LaborLevel & Environment.NewLine
                strSql &= ", Device_LaborCharge = " & dbOWRepLabor & ", Device_ManufWrtyLaborCharge = " & dbIWRepLabor & Environment.NewLine
                strSql &= ", Device_PartCharge = " & dbOWRepPartCharge & ", Device_ManufWrtyPartCharge = " & dbIWRepPartCharge & Environment.NewLine

                If location = PSS.Data.Buisness.SkyTel.AMS_LOC_ID _
                   OrElse location = PSS.Data.Buisness.SkyTel.Aquis_LOC_ID _
                   OrElse location = PSS.Data.Buisness.SkyTel.MorrisCom_LOC_ID _
                   OrElse location = PSS.Data.Buisness.SkyTel.Propage_LOC_ID _
                   OrElse location = PSS.Data.Buisness.SkyTel.CookPager_LOC_ID Then
                    Dim iWipOwner As Integer = 0
                    If ship = True Then
                        iWipOwner = 5
                        strSql += ", Device_DateShip = now(), Ship_ID = 99999" & location & ", Shift_ID_Ship = " & iShift_ID
                        strSql += ", Device_ShipWorkDate = '" & strWorkDate & "' "
                    Else
                        strSql += ", Device_DateShip = null, Device_ShipWorkDate = null, Ship_ID = null , Shift_ID_Ship = null "
                    End If

                    If iWipOwner > 0 Then
                        strSqlTransferWIP = "UPDATE tmessdata SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                        strSqlTransferWIP &= ", tmessdata.wipowner_id = " & iWipOwner & Environment.NewLine
                        strSqlTransferWIP &= ", tmessdata.wipowner_EntryDt =  now(), wipownersubloc_id = 0 " & Environment.NewLine
                        strSqlTransferWIP &= "WHERE Device_ID = " & Device & ";"
                        SetData(strSqlTransferWIP)
                    End If
                End If

                strSql += " WHERE Device_ID = " & Device & ";"
                SetData(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************************************
        Public Shared Sub SaveNBCBilling(ByVal iDeviceID As Integer, ByVal vNBC_Amt As Double, ByVal iBillCodeID As Integer, _
                                         ByVal strPartNum As String, ByVal iUserID As Integer, ByVal strDTime As String)
            Dim strSql As String
            Dim dt As DataTable
            Try
                strSql = "Select * from tdevicebill_NBC where Device_ID=" & iDeviceID & ";"
                dt = GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strSql = "Update tdevicebill_NBC Set DBill_InvoiceAmt= " & vNBC_Amt & "," & Environment.NewLine
                    strSql &= "BillCode_ID=" & iBillCodeID & ",Part_Number='" & strPartNum & "'," & Environment.NewLine
                    strSql &= "Date_Rec='" & strDTime & "', User_ID=" & iUserID & Environment.NewLine
                    strSql &= " Where Device_id = " & iDeviceID & ";"
                    SetData(strSql)
                Else
                    strSql = "Insert into tdevicebill_NBC (Device_ID,DBill_InvoiceAmt,BillCode_ID,Part_Number,Date_Rec,User_ID)" & Environment.NewLine
                    strSql &= " Values (" & iDeviceID & "," & vNBC_Amt & "," & iBillCodeID & ",'" & strPartNum & "','" & Environment.NewLine
                    strSql &= strDTime & "'," & iUserID & ");"
                    SetData(strSql)
                End If
                dt = Nothing
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************************************
        Public Shared Function GetServiceCharge(ByVal iDevice_ID As Integer, _
                                              ByVal iCust_ID As Integer) As Decimal
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim drArray() As DataRow
            Dim decReturnVal As Decimal = 0.0
            Dim i As Integer = 0

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT tbillservicesamt.bs_ServiceAmt as ServiceCharge" & Environment.NewLine
                strSql += ", tbillservicesamt.Model_ID as 'ServiceModelID', tdevice.Model_ID as DeviceModelID " & Environment.NewLine
                strSql += "FROM tdevice" & Environment.NewLine
                strSql += "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID" & Environment.NewLine
                strSql += "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql += "INNER JOIN tbillservicesamt ON tlocation.Cust_ID = tbillservicesamt.Cust_ID " & Environment.NewLine
                strSql += "AND tdevicebill.BillCode_ID = tbillservicesamt.BillCode_ID AND tbillservicesamt.bs_inactive = 0" & Environment.NewLine
                strSql += "WHERE tdevice.Device_ID = " & iDevice_ID & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    drArray = dt.Select("ServiceModelID = " & dt.Rows(0)("DeviceModelID"))
                    If drArray.Length = 0 Then drArray = dt.Select("ServiceModelID = 0")

                    For i = 0 To drArray.Length - 1
                        decReturnVal += drArray(i)("ServiceCharge")
                    Next i
                End If

                Return decReturnVal
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Information")
                GetServiceCharge = 0.0
            Finally
                objDataProc = Nothing
                Generic.DisposeDT(dt)
                drArray = Nothing
            End Try
        End Function

        Public Shared Function GetBillCodes() As DataTable
            Dim strSql As String = "SELECT BillCode_ID, BillCode_Desc FROM lbillcodes;"
            Return GetDataTable(strSql)
        End Function

        'Public Shared Function InsertWarranty(ByVal Device As Integer, ByVal BillPrice As Double, ByVal PriceID As Integer, ByVal Product As Integer, ByVal Manuf As Integer)
        '    Dim strSql As String = "INSERT INTO tascbill (ASCBill_Price, ASCPrice_ID, Device_ID, Prod_ID, Manuf_ID) VALUES " & _
        '                                     "('" & BillPrice & "', '" & PriceID & "', '" & Device & "', '" & Product & "', '" & Manuf & "');"
        '    SetData(strSql)
        'End Function

        Public Shared Function ChangeSerial(ByVal Device As Integer, ByVal Serial As String, ByVal OldSerial As String)
            Dim strSql As String = "UPDATE tdevice SET Device_SN = '" & UCase(Serial) & "', Device_OldSN = '" & OldSerial & "' WHERE Device_ID = " & Device & ";"
            SetData(strSql)


            '//Craig Haney - START
            Dim devDecimal As String
            Try
                Dim tdr As New PSS.Data.Production.tcellopt()
                Dim dr As DataRow = tdr.GetRowByDeviceID(Device)
                If Len(dr("Device_ID")) > 0 Then
                    If Len(Trim(UCase(Serial))) > 10 Then
                        'Make hex code conversion here
                        Dim valHex As String = Mid$(Trim(UCase(Serial)), 1, 8)
                        Dim vals1 As String = Mid$(Trim(UCase(Serial)), 1, 2)
                        Dim vals2 As String = Mid$(Trim(UCase(Serial)), 3, 6)

                        Dim valDec1 As System.UInt32
                        valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
                        Dim valDec2 As System.UInt32
                        valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

                        Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
                        Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
                        devDecimal = v1 & v2
                    End If

                    Dim blnComplete As Boolean = tdr.UpdateDecimalData(Device, devDecimal)
                End If
            Catch ex As Exception
                '__device = Nothing
                'Me.txtDevice.Text = Trim(UCase(Me.txtChangeSerial.Text))
                'Me.txtChangeSerial.Text = ""
                'LoadDevice(Me, New KeyEventArgs(Keys.KeyCode.Enter))
            End Try
            '//Craig Haney - END
        End Function

        Private Shared Function GetDataTable(ByVal [string] As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable([string])

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Private Shared Sub SetData(ByVal [string] As String)
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                objDataProc.ExecuteNonQuery([string])

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Sub

        'Private Shared Function removePartTransaction(ByVal iDevice As Integer, ByVal iBillcode As Integer) As Boolean

        '    Dim ds As PSS.Data.Production.Joins
        '    Dim blnInsert As Boolean = False

        '    Dim sMachine As String = System.Net.Dns.GetHostName
        '    Dim objGen As New PSS.Data.Buisness.Generic()
        '    Dim dDateRec As String = objGen.MySQLServerDateTime(1)

        '    Dim strSQL As String

        '    '//COMMENTED OUT AUGUST 23, 2007
        '    'strSQL = "INSERT INTO tparttransaction " & Environment.NewLine
        '    'strSQL &= "(Device_ID, BillCode_ID, Date_Rec, Trans_Amount, MachineName, New) " & Environment.NewLine
        '    'strSQL &= "VALUES (" & iDevice & ", " & iBillcode & ", '" & dDateRec & "',  -1, '" & sMachine & "', 3)"
        '    'blnInsert = ds.OrderEntryUpdateDelete(strSQL)
        '    objGen = Nothing
        '    ds = Nothing

        '    Return blnInsert

        'End Function

        '*****************************************************************************
        Public Shared Function GetNonWrtyPartCostMarkUp(ByVal iDeviceID As Integer, _
                                                         ByVal iCustID As Integer, _
                                                         ByVal iModelID As Integer, _
                                                         ByVal iWrtyStatus As Integer, _
                                                         Optional ByVal dbTotalPartCost As Decimal = 0) As Decimal
            Dim strSql As String
            Dim dbMaxPartCostMarkUp As Double = 0.0
            Dim dbPartCostMarkUp As Double = 0.0
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * " & Environment.NewLine
                strSql += "FROM tcustpartcostmarkup " & Environment.NewLine
                strSql += "WHERE Cust_ID = " & iCustID & Environment.NewLine
                strSql += "ORDER BY low" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    dbMaxPartCostMarkUp = dt.Compute("Max(High)", "")

                    If dbTotalPartCost = 0 Then
                        strSql = "SELECT if(SUM(tdevicebill.DBill_InvoiceAmt) is null, 0.00, SUM(tdevicebill.DBill_InvoiceAmt)) as TotalPartCost" & Environment.NewLine
                        strSql += "FROM tdevicebill" & Environment.NewLine
                        strSql += "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                        strSql += "INNER JOIN tpsmap ON tdevicebill.Billcode_ID = tpsmap.Billcode_ID AND Model_ID = " & iModelID & Environment.NewLine
                        strSql += "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                        strSql += "AND lbillcodes.BillType_ID = 2" & Environment.NewLine
                        If iWrtyStatus > 0 Then strSql += "AND tdevicebill.Fail_ID IN ( 0, 311 ) " & Environment.NewLine
                        dbTotalPartCost = objDataProc.GetDoubleValue(strSql)
                    End If

                    If dbTotalPartCost >= dbMaxPartCostMarkUp Then
                        If dt.Select("High = " & dbMaxPartCostMarkUp).Length > 0 Then dbPartCostMarkUp = dt.Select("High = " & dbMaxPartCostMarkUp)(0)("MarkUpLabor")
                    Else
                        If Not IsDBNull(dt.Compute("Max(MarkUpLabor)", dbTotalPartCost & " >= [Low] AND " & dbTotalPartCost & " < [High]")) Then dbPartCostMarkUp = dt.Compute("Max(MarkUpLabor)", dbTotalPartCost & " >= [Low] AND " & dbTotalPartCost & " <= [High]")
                    End If
                End If

                Return dbPartCostMarkUp
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Information")
                GetNonWrtyPartCostMarkUp = 0.0
            Finally
                objDataProc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetPOInfo(ByVal iPOID As Integer) As DataTable
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT * FROM tpurchaseorder WHERE PO_ID = " & iPOID & Environment.NewLine

                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetLaborLevelDescription(ByVal iLevelID As Integer) As String
            Dim strSql As String
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT LaborLvl_Desc FROM llaborlvl WHERE LaborLvl_ID = " & iLevelID & Environment.NewLine
                Return objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function InsertPartTransaction(ByVal iDeviceID As Integer, ByVal iBillcodeID As Integer, _
                                                     ByVal iUserID As Integer, ByVal iEmpNo As Integer, _
                                                     ByVal iShiftID As Integer, ByVal strPartNumber As String, _
                                                     ByVal iTransactionAmount As Integer, _
                                                     ByVal iScreenID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim iCC_ID, iProdID, iLastBillCCID As Integer

            Try
                iCC_ID = 0 : iProdID = 0
                iProdID = Generic.GetProdIDOfUnit(iDeviceID)
                iCC_ID = Generic.GetMachineCostCenterID()

                If iCC_ID = 31 Or iCC_ID = 0 Then     'Special Cost Center use by supervisors and leaders
                    'Use device's cost center instead of machine's cost center
                    iCC_ID = Generic.GetCostCenterIDOfDevice(iDeviceID)
                End If

                '*******************************
                ''Added on 06/11/2009
                ''For unbill unit, use CC ID where the part get bill
                '*******************************
                If iTransactionAmount < 0 Then
                    iLastBillCCID = PSS.Data.Buisness.Generic.GetLastBillCCID(iDeviceID, iBillcodeID)
                    If iLastBillCCID > 0 Then iCC_ID = iLastBillCCID
                End If
                '*******************************

                strSql = "INSERT INTO tparttransaction " & Environment.NewLine
                strSql &= "(Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo" & Environment.NewLine
                strSql &= ", Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server, cc_id, Part_Number, Prod_ID " & Environment.NewLine
                strSql &= ", ScreenID " & Environment.NewLine
                strSql &= ") VALUES (" & iDeviceID & ", " & iBillcodeID & ", " & iUserID & ", now(), " & iEmpNo & Environment.NewLine
                strSql &= ", " & iTransactionAmount & ", " & iShiftID & ", '" & Generic.GetWorkDate(iShiftID) & "', '" & System.Net.Dns.GetHostName & "', 1, now(), " & iCC_ID & ", '" & strPartNumber & "', " & iProdID & Environment.NewLine
                strSql &= ", " & iScreenID & Environment.NewLine
                strSql &= ")"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetReplaceItemCharge(ByVal iDeviceID As Integer) As Double
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT tcustmarkup.markup_Replacement " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel On tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id) " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strSql &= "INNER JOIN tcustmarkup ON tcustomer.cust_id = tcustmarkup.cust_id And tmodel.Prod_ID = tcustmarkup.Prod_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.device_id= " & iDeviceID & Environment.NewLine
                strSql &= "AND tdevicebill.billcode_id= 394 " & Environment.NewLine
                strSql &= "AND tcustmarkup.markup_PlusRepl = 1"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetTotalPartsCharge(ByVal iDeviceID As Integer) As Double
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT Sum(DBill_InvoiceAmt) as 'PartsCharge' " & Environment.NewLine
                strSql &= "FROM tdevicebill WHERE Device_ID =  " & iDeviceID & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetOWRepPartsCharge(ByVal iDeviceID As Integer) As Double
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT Sum(DBill_InvoiceAmt) as 'PartsCharge' " & Environment.NewLine
                strSql &= "FROM tdevicebill WHERE Device_ID =  " & iDeviceID & Environment.NewLine
                strSql &= "AND Fail_ID IN ( 0, 311 ) " & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetIWRepPartsCharge(ByVal iDeviceID As Integer) As Double
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                strSql = "SELECT Sum(DBill_InvoiceAmt) as 'PartsCharge' " & Environment.NewLine
                strSql &= "FROM tdevicebill WHERE Device_ID =  " & iDeviceID & Environment.NewLine
                strSql &= "AND Fail_ID NOT IN ( 0, 311 ) " & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetWiKoRURLaborCharge() As Double
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim iWiKoRURLaborLvl As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_RUR_LaborLevel
            Dim iWiKoPrcGroup_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_PrcGroup_ID
            Dim iWiKoProdGrp_ID As Integer = PSS.Data.Buisness.WIKO.WIKO.WIKO_ProdGrp_ID
            Try
                strSql = "SELECT LaborPrc_RegPrc, LaborPrc_WrtyPrc, LaborLvl_ID FROM tlaborprc " & Environment.NewLine
                strSql &= "WHERE PrcGroup_ID = " & iWiKoPrcGroup_ID & " AND ProdGrp_ID = " & iWiKoProdGrp_ID & "  AND  LaborLvl_ID = " & iWiKoRURLaborLvl & " ;"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDoubleValue(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Function GetPartBillcodes(ByVal iCustID As Integer, _
                                         ByVal iModelID As Integer, _
                                         Optional ByVal iLessThanLaborLevel As Integer = 0, _
                                         Optional ByVal iGreaterThanLaborLevel As Integer = 0, _
                                         Optional ByVal iRVFlag As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT lbillcodes.*, lpsprice.psprice_number, ReflowTypeID, lpsprice.PSPrice_ConsignedPart " & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & Environment.NewLine
                strSql &= "AND tbilldisplayexceptions.cust_id = " & iCustID & " " & Environment.NewLine
                strSql &= "WHERE tpsmap.model_id = " & iModelID & " " & Environment.NewLine
                strSql &= "AND billtype_id = 2 " & Environment.NewLine
                'strSql &= "AND lpsprice.psprice_consignedpart = 0 " & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0 " & Environment.NewLine
                If iLessThanLaborLevel > 0 Then strSql &= "AND tpsmap.LaborLevel < " & iLessThanLaborLevel & Environment.NewLine
                If iGreaterThanLaborLevel > 0 Then strSql &= "AND tpsmap.LaborLevel > " & iGreaterThanLaborLevel & Environment.NewLine
                strSql &= "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & iCustID & ") " & Environment.NewLine
                strSql &= "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & Environment.NewLine
                If iRVFlag > 0 Then
                    strSql &= "AND ( lpsprice.RVFlag = " & iRVFlag & " OR lbillcodes.BillCode_Desc like 'RV_%' )" & Environment.NewLine
                Else
                    strSql &= "AND lpsprice.RVFlag = " & iRVFlag & " AND lbillcodes.BillCode_Desc NOT like 'RV_%'" & Environment.NewLine
                End If
                strSql &= "ORDER BY BillCode_Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************
        Public Function GetConsignedPartBillcodes(ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart" & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id and lbillcodes.Device_ID = tpsmap.Prod_ID" & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id" & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & iModelID & Environment.NewLine
                strSql &= "AND billtype_id = 2 AND lpsprice.psprice_consignedpart = 1" & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0" & Environment.NewLine
                strSql &= "ORDER BY BillCode_Desc "

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************
        Public Function GetScrapPartBillcodes(ByVal iModelID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart" & Environment.NewLine
                strSql &= "FROM lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id" & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id" & Environment.NewLine
                strSql &= "WHERE tpsmap.model_id = " & iModelID & Environment.NewLine
                strSql &= "AND billtype_id = 2 AND lpsprice.psprice_flgCountScrap = 1" & Environment.NewLine
                strSql &= "AND tpsmap.Inactive = 0" & Environment.NewLine
                strSql &= "ORDER BY lpsprice.psprice_ordergroup desc, BillCode_Desc asc"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function IsFlatRateModel(ByVal iCustID As Integer, ByVal iModelID As Integer, ByVal booThrowExcptForNoSetUp As Boolean, Optional ByVal strEnterprise As String = "") As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booFlatRate As Boolean = False

            Try
                strSql = "SELECT * FROM tmodeltarget WHERE mt_Cust_ID = " & iCustID & " AND MT_Model_ID = " & iModelID & " AND MT_Enterprise = '" & strEnterprise & "'" & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then Throw New Exception("Duplicate record on model target set up.")

                If booThrowExcptForNoSetUp AndAlso dt.Rows.Count = 0 Then Throw New Exception("No flat rate set up for this model.")

                If dt.Rows.Count = 1 Then If CInt(dt.Rows(0)("FlatRate")) = 1 Then booFlatRate = True

                Return booFlatRate
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function GetTFFlatRateLaborPartCharge(ByVal iCustID As Integer, ByVal strModelDesc As String, ByVal iInvYrMonth As Integer) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                If strModelDesc.ToUpper.EndsWith("_FUN") Then strModelDesc = strModelDesc.ToUpper.Replace("_FUN", "")

                strSql = "SELECT A.* FROM tflatratepricebymodel A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND B.Model_Desc = '" & strModelDesc & "'" & Environment.NewLine
                strSql &= "AND InvYearMonth <= " & iInvYrMonth & Environment.NewLine
                strSql &= "ORDER BY InvYearMonth DESC LIMIT 1"
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Function DeleteTFNoBatterCoverCharge(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable

            Try
                strSql = "Select A.Device_ID,A.Device_SN,A.Device_LaborCharge,A.Device_PartCharge,B.BillCode_ID,C.BillCode_Desc" & Environment.NewLine
                strSql &= " ,C.BillType_ID,D.BillType_Sdesc,D.BillType_Ldesc" & Environment.NewLine
                strSql &= " From tdevice A" & Environment.NewLine
                strSql &= " Inner Join tdevicebill B On A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= " Inner Join lbillcodes C On B.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                strSql &= " Inner Join lBillType D On C.BillType_ID=D.BillType_ID" & Environment.NewLine
                strSql &= " Where C.BillType_ID=2 And A.device_ID=" & iDeviceID & ";" & Environment.NewLine
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)
                If Not dt.Rows.Count > 0 Then
                    strSql = "Delete from tdevicebill_NBC Where device_ID=" & iDeviceID & ";" & Environment.NewLine
                    objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                    objDataProc.ExecuteNonQuery(strSql)
                End If

                Return 1

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '*****************************************************************************
        Public Shared Sub UpdateTFPartCharge_WhenModelHasNoBatterryCover(ByVal iModelID As Integer, _
                                                                         ByVal strModelDesc As String, _
                                                                         ByVal iUserID As Integer, _
                                                                         ByRef strErrMsg As String)
            Dim strSql As String = "", strModel4FaltRate As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt, dtDevices, dtDevices_HasBC, dtNBC As DataTable
            Dim filteredRows() As DataRow
            Dim row As DataRow
            Dim uniqueDeviceIDs As New ArrayList()
            Dim uniqueDeviceIDs_HasBC As New ArrayList()
            Dim vIW_Part As Double = 0.0, vOW_Part As Double = 0.0
            Dim vIW_NBC As Double = 0.0, vOW_NBC As Double = 0.0
            Dim iDeviceID As Integer = 0
            Dim iModelID4FaltRate As Integer = 0
            Dim i As Integer

            'Update part charge when Model changing from Has_Battery_Cover to Has_No_Battery_Cover
            'for all devices when Workstation in Production Completed for the model
            Try
                strErrMsg = ""
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                iModelID4FaltRate = iModelID
                If strModelDesc.Trim.Length > 4 AndAlso strModelDesc.Trim.Substring(strModelDesc.Trim.Length - 4, 4) = "_FUN" Then
                    strModel4FaltRate = strModelDesc.Trim.Substring(0, strModelDesc.Trim.Length - 4)
                    strSql = "select B.Model_desc, A.* from tflatratepricebymodel A" & Environment.NewLine
                    strSql &= "inner join tmodel B on A.Model_ID=B.model_ID" & Environment.NewLine
                    strSql &= " where B.model_desc ='" & strModel4FaltRate & "' ORDER BY Model_Desc ASC, InvYearMonth DESC;" & Environment.NewLine
                    dt = objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count > 0 Then
                        iModelID4FaltRate = dt.Rows(0).Item("Model_ID")
                    End If
                End If
                dt = Nothing

                strSql = "SELECT Cust_Name1 as 'Customer', Model_Desc as 'Model'" & Environment.NewLine
                strSql &= " , IW_LaborCharge as 'IW Labor', IW_PartCharge as 'IW Part', IW_BattCovCost as 'IW BC Cost',OW_LaborCharge as 'OW Labor', OW_PartCharge as 'OW Part', OW_BattCovCost as 'OW BC Cost', DeviceSaving as 'Device Saving'" & Environment.NewLine
                strSql &= " ,OnHold2_LaborCharge as 'OH2_LaborCharge',OnHold2_PartCharge as 'OH2_PartCharge'" & Environment.NewLine
                strSql &= " , Date_format(RequestedDate, '%m/%d/%Y') as 'Requested Date', Date_format(ApprovedDate, '%m/%d/%Y') as 'Approved Date'" & Environment.NewLine
                strSql &= " , InvoiceMonth as 'Invoice Effective Month', InvoiceYear as 'Invoice Effective Year'" & Environment.NewLine
                strSql &= " , LastUpdateDate as 'Updated Date', User_FullName as 'Update By'" & Environment.NewLine
                strSql &= " FROM tflatratepricebymodel A INNER JOIN tmodel B ON A.Model_ID = B.Model_ID INNER JOIN tcustomer C ON A.Cust_ID = C.Cust_ID" & Environment.NewLine
                strSql &= " LEFT OUTER JOIN security.tusers D ON A.User_ID = D.User_ID" & Environment.NewLine
                strSql &= " WHERE A.Model_ID=" & iModelID4FaltRate & Environment.NewLine
                strSql &= " ORDER BY Cust_Name1, Model_Desc ASC, InvYearMonth DESC;" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    strErrMsg = "Mo flat prices for this model is defined! See IT."
                Else
                    vIW_Part = (dt.Rows(0).Item("IW Part")) : vOW_Part = dt.Rows(0).Item("OW Part")
                    vIW_NBC = dt.Rows(0).Item("IW BC Cost") : vOW_NBC = dt.Rows(0).Item("OW BC Cost")

                    strSql = "Select A.Device_ID,A.Device_SN,E.WorkStation,A.Model_ID,F.Model_Desc,A.Device_LaborCharge" & Environment.NewLine
                    strSql &= " ,A.Device_ManufWrty,A.Device_PSSWrty,A.Device_PartCharge,B.BillCode_ID,C.BillCode_Desc" & Environment.NewLine
                    strSql &= " ,C.BillType_ID,D.BillType_Sdesc,D.BillType_Ldesc" & Environment.NewLine
                    strSql &= " From tdevice A" & Environment.NewLine
                    strSql &= " Inner Join tdevicebill B On A.Device_ID=B.Device_ID" & Environment.NewLine
                    strSql &= " Inner Join lbillcodes C On B.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                    strSql &= " Inner Join lBillType D On C.BillType_ID=D.BillType_ID" & Environment.NewLine
                    strSql &= " Inner Join tcellopt E On A.Device_ID=E.Device_ID" & Environment.NewLine
                    strSql &= " inner join tmodel F On A.Model_ID=F.Model_ID" & Environment.NewLine
                    strSql &= " Where A.Model_ID =" & iModelID & " And E.WorkStation='PRODUCTION COMPLETED'" & Environment.NewLine
                    dtDevices = objDataProc.GetDataTable(strSql)

                    strSql &= " and B.Billcode_ID in ( 154, 1869, 2510 )"
                    dtDevices_HasBC = objDataProc.GetDataTable(strSql)
                    If dtDevices_HasBC.Rows.Count > 0 Then 'normally, it should be nothing for Production Completed 
                        For Each row In dtDevices_HasBC.Rows
                            If Not uniqueDeviceIDs_HasBC.Contains(row("Device_ID")) Then
                                uniqueDeviceIDs_HasBC.Add(row("Device_ID"))
                            End If
                        Next
                        strErrMsg = "Abnormal: " & uniqueDeviceIDs.Count.ToString & " devices in Production Completed with batter cover. See IT."
                    End If

                    For Each row In dtDevices.Rows 'get all unique device ids (except for thoso with no BC assigned)
                        If Not uniqueDeviceIDs.Contains(row("Device_ID")) AndAlso Not uniqueDeviceIDs_HasBC.Contains(row("Device_ID")) Then
                            uniqueDeviceIDs.Add(row("Device_ID"))
                        End If
                    Next
                    For i = 0 To uniqueDeviceIDs.Count - 1
                        iDeviceID = uniqueDeviceIDs(i)
                        strSql = "select * from tdevicebill_NBC Where device_ID=" & iDeviceID & ";" & Environment.NewLine
                        dtNBC = objDataProc.GetDataTable(strSql)
                        If Not dtNBC.Rows.Count > 0 Then 'Not set NBC charges yet, so reset 
                            filteredRows = dtDevices.Select("Device_ID =" & iDeviceID)
                            If filteredRows.Length > 0 Then
                                For Each row In filteredRows
                                    If vIW_Part < (row("Device_PartCharge") + 0.00499) AndAlso vIW_Part > (row("Device_PartCharge") - 0.00499) Then
                                        strSql = "Update tdevice set Device_PartCharge=" & (vIW_Part - vIW_NBC) & " Where Device_ID=" & iDeviceID
                                        objDataProc.ExecuteNonQuery(strSql)

                                        SaveNBCBilling(iDeviceID, vIW_NBC, PSS.Data.Buisness.TracFone.TFBillingData.TF_NoBatteryCover_BillCodeID, _
                                                    "S0", iUserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                                        objDataProc.ExecuteNonQuery(strSql)

                                    ElseIf vOW_Part < (row("Device_PartCharge") + 0.00499) AndAlso vOW_Part > (row("Device_PartCharge") - 0.00499) Then
                                        strSql = "Update tdevice set Device_PartCharge=" & (vOW_Part - vOW_NBC) & " Where Device_ID=" & iDeviceID
                                        objDataProc.ExecuteNonQuery(strSql)

                                        SaveNBCBilling(iDeviceID, vOW_NBC, PSS.Data.Buisness.TracFone.TFBillingData.TF_NoBatteryCover_BillCodeID, _
                                                "S0", iUserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                                        objDataProc.ExecuteNonQuery(strSql)
                                    End If
                                    Exit For
                                Next
                            End If
                        End If
                    Next

                End If

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing : dtDevices = Nothing : dtDevices_HasBC = Nothing : dtNBC = Nothing
                objDataProc = Nothing
            End Try
        End Sub

        '*****************************************************************************

    End Class
End Namespace
