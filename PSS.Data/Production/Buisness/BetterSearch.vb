Namespace Buisness
    Public Class BetterSearch

        Private objMisc As production.Misc

        '**************************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '**************************************************************************
        Public Function GetAllUsersInfo() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "Select * from security.tusers order by User_ID;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function Search(ByVal strSearchBy As String, _
                               ByVal strSearchCriteria As String, _
                               ByVal dtUsers As DataTable, _
                               ByRef dtParts As DataTable, _
                               ByRef dtQC As DataTable) As DataTable

            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim strDevice_IDs As String = ""

            '*************************************************************
            'Build the dveice based search query string
            '***********
            'tdevice
            strsql = "Select " & Environment.NewLine
            strsql &= "tdevice.Device_ID, " & Environment.NewLine
            strsql &= "tdevice.Device_SN as 'SN', " & Environment.NewLine
            strsql &= "tdevice.Device_OldSN as 'Old SN',  " & Environment.NewLine
            strsql &= "tdevice.Device_DateRec as 'Date Rcvd', " & Environment.NewLine
            strsql &= "tdevice.Device_DateBill as 'Date Billed', " & Environment.NewLine
            'strsql &= "tdevice.Device_DateBill_AutoBilled as 'Date Auto-billed', " & Environment.NewLine
            strsql &= "tdevice.Device_DateShip as 'Date Shipped', " & Environment.NewLine
            'strsql &= "if(tdevice.Device_Invoice=1,'Invoiced','Not Invoiced') as 'Invoiced', " & Environment.NewLine
            strsql &= "tdevice.Device_LaborLevel as 'Max Labor Lvl', " & Environment.NewLine
            strsql &= "tdevice.Device_LaborCharge as 'Max Labor Chg', " & Environment.NewLine
            'strsql &= "tdevice.Device_LaborLevel_AutoBilled as 'Max Labor Lvl Auto-billed', " & Environment.NewLine
            'strsql &= "tdevice.Device_LaborCharge_AutoBilled as 'Max Labor Chg Auto-billed', " & Environment.NewLine
            strsql &= "tdevice.Device_RecWorkDate as 'Work Dt Rcvd', " & Environment.NewLine
            strsql &= "tdevice.Device_ShipWorkDate as 'Work Dt Shipped', " & Environment.NewLine
            strsql &= "tdevice.Tray_ID as 'Tray ID', " & Environment.NewLine
            strsql &= "tdevice.Ship_ID as 'Ship ID', " & Environment.NewLine
            strsql &= "tdevice.Shift_ID_Rec as 'Shift Rcvd', " & Environment.NewLine
            strsql &= "tdevice.Shift_ID_Ship as 'Shift Shipped', " & Environment.NewLine
            '***********
            'ttray
            strsql &= "ttray.Tray_RecUser, " & Environment.NewLine
            strsql &= "ttray.Tray_Memo, " & Environment.NewLine

            '***********
            'tship
            strsql &= "tship.Ship_User, " & Environment.NewLine
            strsql &= "if (tship.Ship_RptCreationDT is null, '', tship.Ship_RptCreationDT) as ShipRptCreationDate, " & Environment.NewLine

            '***********
            'tworkorder
            strsql &= "tworkorder.WO_ID as 'Work Order ID', " & Environment.NewLine
            strsql &= "tworkorder.WO_CustWO as 'Work Order', " & Environment.NewLine
            strsql &= "tworkorder.WO_Date as 'Wo Rcvd Dt', " & Environment.NewLine
            strsql &= "tworkorder.WO_Quantity as 'WO Qty', " & Environment.NewLine
            strsql &= "tworkorder.WO_Memo as 'WO Memo', " & Environment.NewLine
            strsql &= "tworkorder.PO_ID as 'PO ID', " & Environment.NewLine
            strsql &= "tworkorder.WO_RecPalletName as 'Rcvd Pallet', " & Environment.NewLine

            '***********
            'tworkorder to lgroups
            strsql &= "h.group_desc as 'Work Order Owner', " & Environment.NewLine

            '***********
            'tmodel
            strsql &= "tmodel.Model_ID, " & Environment.NewLine
            strsql &= "tmodel.Model_Desc as 'Model', " & Environment.NewLine
            strsql &= "tmodel.Model_Tier, " & Environment.NewLine
            strsql &= "tmodel.Model_Flat, " & Environment.NewLine
            strsql &= "tmodel.ProdGrp_ID, " & Environment.NewLine

            '***********
            'lmanuf
            strsql &= "lmanuf.Manuf_ID, " & Environment.NewLine
            strsql &= "lmanuf.Manuf_Desc as 'Manufacturer', " & Environment.NewLine

            '***********
            'tmodel to lproduct
            strsql &= "lproduct.Prod_Desc as 'Product', " & Environment.NewLine

            '***********
            'tcellopt
            strsql &= "tcellopt.CellOpt_OutMSN as 'MSN', " & Environment.NewLine
            strsql &= "tcellopt.CellOpt_Transceiver as 'Sug Number', " & Environment.NewLine
            strsql &= "tcellopt.CellOpt_IMEI as 'IMEI', " & Environment.NewLine
            strsql &= "tcellopt.CellOpt_OutCSN as 'ESN/CSN', " & Environment.NewLine
            strsql &= "tcellopt.CellOpt_CSN_Dec as 'Decimal SN', " & Environment.NewLine

            '***********
            'tcellopt to lgroups
            strsql &= "g.group_desc as 'WIP Bucket',  " & Environment.NewLine

            '***********
            'tcustomer
            strsql &= "tcustomer.Cust_ID, " & Environment.NewLine
            strsql &= "tcustomer.Cust_Name1 as 'Customer', " & Environment.NewLine

            '***********
            'tlocation
            strsql &= "tlocation.Loc_ID, " & Environment.NewLine
            strsql &= "tlocation.Loc_Name as 'Cust Location', " & Environment.NewLine

            '***********
            'tpallett
            strsql &= "tpallett.Pallett_ID, " & Environment.NewLine
            strsql &= "tpallett.Pallett_Name as 'Ship Pallet', " & Environment.NewLine
            strsql &= "tpallett.Pallett_ShipDate,  " & Environment.NewLine
            strsql &= "if(tpallett.Pallett_BulkShipped = 1,'Yes','No') as 'Bulk Shipped?', " & Environment.NewLine
            strsql &= "if(tpallett.Pallett_SendDt is null,'', tpallett.Pallett_SendDt ) as 'Pallet Sent Date?', " & Environment.NewLine

            '***********
            'tmessdata
            strsql &= "tmessdata.sn_change_date as 'SN Changed on', " & Environment.NewLine
            strsql &= "b.user_fullname as 'SN Changed by', " & Environment.NewLine

            strsql &= "tmessdata.capcode, " & Environment.NewLine
            strsql &= "tmessdata.capcode_old, " & Environment.NewLine
            strsql &= "c.user_fullname as 'Capcode Changed by', " & Environment.NewLine
            strsql &= "tmessdata.capcode_change_date as 'Capcode Changed on', " & Environment.NewLine

            strsql &= "lb1.baud_Number as 'Baud Rate', " & Environment.NewLine
            strsql &= "lb2.baud_Number as 'Baud Rate Old', " & Environment.NewLine
            strsql &= "d.user_fullname as 'Baud Rate Changed by', " & Environment.NewLine
            strsql &= "tmessdata.baud_id_change_date as 'Baud Rate Changed on', " & Environment.NewLine

            strsql &= "lf1.freq_Number as 'Frequency', " & Environment.NewLine
            strsql &= "lf2.freq_Number as 'Frequency Old', " & Environment.NewLine
            strsql &= "e.user_fullname as 'Frequency Changed by', " & Environment.NewLine
            strsql &= "tmessdata.freq_id_change_date as 'Frequency Changed on', " & Environment.NewLine

            strsql &= "f.user_fullname as 'Labeled by', " & Environment.NewLine
            strsql &= "tmessdata.label_workdate as 'Labeled on', " & Environment.NewLine
            strsql &= "tmessdata.SKU, " & Environment.NewLine
            strsql &= "if(tmessdata.CameWithFileFlag = 1,'Yes','No') as 'Rcvd. with Mess. Cust. Data File' " & Environment.NewLine

            '***********
            strsql &= "from  " & Environment.NewLine
            strsql &= "tdevice " & Environment.NewLine
            strsql &= "inner join tworkorder on tworkorder.WO_ID = tdevice.WO_ID " & Environment.NewLine
            strsql &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
            strsql &= "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
            strsql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
            strsql &= "inner join lmanuf on tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
            strsql &= "left outer join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
            strsql &= "left outer join lproduct on tmodel.Prod_ID = lproduct.Prod_ID " & Environment.NewLine

            strsql &= "left outer join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
            strsql &= "left outer join tship on tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
            strsql &= "left outer join ttray on tdevice.Tray_ID = ttray.Tray_ID " & Environment.NewLine
            strsql &= "left outer join tmessdata on tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
            strsql &= "left outer join security.tusers b on tmessdata.sn_change_userid = b.user_id " & Environment.NewLine
            strsql &= "left outer join security.tusers c on tmessdata.capcode_change_userid= c.user_id " & Environment.NewLine
            strsql &= "left outer join security.tusers d on tmessdata.baud_id_change_userid= d.user_id " & Environment.NewLine
            strsql &= "left outer join security.tusers e on tmessdata.freq_id_change_userid= e.user_id " & Environment.NewLine
            strsql &= "left outer join security.tusers f on tmessdata.label_userid= f.user_id " & Environment.NewLine

            strsql &= "left outer join lwipowner g on tcellopt.Cellopt_WIPOwner = g.wipowner_id " & Environment.NewLine
            strsql &= "left outer join lgroups h on tworkorder.Group_ID = h.Group_ID " & Environment.NewLine

            strsql &= "left outer join lbaud lb1 on tmessdata.baud_id = lb1.baud_id " & Environment.NewLine
            strsql &= "left outer join lbaud lb2 on tmessdata.baud_id_old = lb2.baud_id " & Environment.NewLine
            strsql &= "left outer join lfrequency lf1 on tmessdata.freq_id = lf1.freq_id " & Environment.NewLine
            strsql &= "left outer join lfrequency lf2 on tmessdata.freq_id_old = lf2.freq_id " & Environment.NewLine

            strsql &= "where  " & Environment.NewLine

            '*************************************************************
            Try
                Select Case strSearchBy
                    Case "Serial Number"
                        strsql &= "tdevice.device_sn like '" & strSearchCriteria & "%' " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Serial Number (Old)"
                        strsql &= "tdevice.device_oldsn like '" & strSearchCriteria & "%' " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Work Order"
                        strsql &= "tworkorder.wo_custwo like '" & strSearchCriteria & "%' " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Work Order ID"
                        strsql &= "tworkorder.wo_id = " & strSearchCriteria & " " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Tray ID"
                        strsql &= "tdevice.tray_id = " & strSearchCriteria & " " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Ship Manifest ID"
                        strsql &= "tdevice.ship_id = " & strSearchCriteria & " " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Received Pallet"
                        strsql &= "tworkorder.WO_RecPalletName like '" & strSearchCriteria & "%' " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Shipped Pallet"
                        strsql &= "tpallett.Pallett_Name like '" & strSearchCriteria & "%' " & Environment.NewLine
                        strsql &= "Order by Device_ID Desc;"
                    Case "Model"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine
                        strsql &= "tmodel.Model_ID, " & Environment.NewLine
                        strsql &= "tmodel.Model_Desc as Model, " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_ID as 'lbillcodes_BillCode_ID', " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_Desc as 'lbillcodes_BillCode_Desc', " & Environment.NewLine
                        strsql &= "lbillcoderules.BillCodeRule_Desc as 'lbillcoderules_BillCodeRule_Desc', " & Environment.NewLine
                        strsql &= "a.Prod_Desc as 'Product', " & Environment.NewLine
                        strsql &= "if(lbillcodes.BillType_ID=1,'Service','Part') as 'Part or Service', " & Environment.NewLine

                        strsql &= "tpsmap.BillCode_ID as 'tpsmap_BillCode_ID', " & Environment.NewLine
                        strsql &= "tpsmap.Model_ID as 'tpsmap_Model_ID', " & Environment.NewLine
                        strsql &= "tpsmap.LaborLvl_ID as 'tpsmap_LaborLvl_ID', " & Environment.NewLine
                        strsql &= "tpsmap.CustFlg as 'tpsmap_CustFlg', " & Environment.NewLine
                        strsql &= "tpsmap.Inactive as 'tpsmap_Inactive', " & Environment.NewLine

                        strsql &= "lpsprice.PSPrice_Number as 'lpsprice_PSPrice_Number', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Desc as 'lpsprice_PSPrice_Desc', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_AvgCost as 'lpsprice_PSPrice_AvgCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_StndCost as 'lpsprice_PSPrice_StndCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_ConsignedPart as 'lpsprice_PSPrice_ConsignedPart', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_InventoryPart as 'lpsprice_PSPrice_InventoryPart' " & Environment.NewLine

                        strsql &= "from lbillcodes " & Environment.NewLine
                        strsql &= "left outer join lproduct a on lbillcodes.Device_ID = a.prod_id " & Environment.NewLine
                        strsql &= "left outer join tpsmap on lbillcodes.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                        strsql &= "left outer join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql &= "left outer join lbillcoderules on lbillcodes.BillCode_Rule = lbillcoderules.BillCode_Rule " & Environment.NewLine
                        strsql &= "left outer join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine

                        strsql &= "where  " & Environment.NewLine
                        strsql &= "tmodel.model_desc like '" & strSearchCriteria & "%' " & Environment.NewLine

                    Case "Customer Name"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine
                        strsql &= "tcustomer.Cust_ID as 'tcustomer_Cust_Id', " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name1 as 'tcustomer_Customer Name 1', " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name2 as 'tcustomer_Customer Name 2', " & Environment.NewLine
                        strsql &= "lparentco.PCo_ID as 'lparentco_Parent Co Id', " & Environment.NewLine
                        strsql &= "lparentco.PCo_Name as 'lparentco_Parent Co', " & Environment.NewLine
                        strsql &= "lparentco.PrcGroup_ID as 'lparentco_PrcGroup_ID', " & Environment.NewLine
                        strsql &= "tcustmarkup.MarkUp_RUR as 'tcustmarkup_MarkUp_RUR', " & Environment.NewLine
                        strsql &= "tcustmarkup.MarkUp_NER as 'tcustmarkup_MarkUp_NER', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_Replacement as 'tcustmarkup_Markup_Replacement', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_PlusRepl as 'tcustmarkup_Markup_PlusRepl', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_PlusParts as 'tcustmarkup_Markup_PlusParts', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_NTF as 'tcustmarkup_Markup_NTF', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_RTM as 'tcustmarkup_Markup_RTM', " & Environment.NewLine
                        strsql &= "tcustmarkup.Prod_ID as 'tcustmarkup_Prod_ID', " & Environment.NewLine
                        strsql &= "tcusttoprice.PrcGroup_ID as 'tcusttoprice_PrcGroup_ID', " & Environment.NewLine
                        strsql &= "tcusttoprice.Prod_ID as 'tcusttoprice_Prod_ID', " & Environment.NewLine
                        strsql &= "lpricinggroup.PrcGroup_ID as 'lpricinggroup_PrcGroup_ID', " & Environment.NewLine
                        strsql &= "lpricinggroup.PrcGroup_SDesc as 'lpricinggroup_PrcGroup_SDesc', " & Environment.NewLine
                        strsql &= "lpricinggroup.Prod_ID as 'lpricinggroup_Prod_ID', " & Environment.NewLine
                        strsql &= "lpricinggroup.ProdGrp_ID as 'lpricinggroup_ProdGrp_ID', " & Environment.NewLine
                        strsql &= "tcustwrty.CustWrty_DaysinWrty as 'tcustwrty_CustWrty_DaysinWrty', " & Environment.NewLine
                        strsql &= "tcustwrty.PSSwrtyParts_ID as 'tcustwrty_PSSwrtyParts_ID', " & Environment.NewLine
                        strsql &= "tcustwrty.PSSWrtyLabor_ID as 'tcustwrty_PSSWrtyLabor_ID', " & Environment.NewLine
                        strsql &= "tcustwrty.Prod_ID as 'tcustwrty_Prod_ID' " & Environment.NewLine

                        strsql &= "from tcustomer  " & Environment.NewLine
                        strsql &= "left outer join lparentco on tcustomer.PCo_ID = lparentco.PCo_ID " & Environment.NewLine
                        strsql &= "left outer join tcusttoprice on tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                        strsql &= "left outer join tcustmarkup on tcustomer.Cust_ID = tcustmarkup.Cust_ID " & Environment.NewLine
                        strsql &= "left outer join lpricinggroup on tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
                        strsql &= "left outer join tcustwrty on tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine

                        strsql &= "where  " & Environment.NewLine
                        strsql &= "tcustomer.cust_name1 like '" & strSearchCriteria & "%' " & Environment.NewLine

                    Case "Customer ID"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine
                        strsql &= "tcustomer.Cust_ID as 'tcustomer_Cust_Id', " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name1 as 'tcustomer_Customer Name 1', " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name2 as 'tcustomer_Customer Name 2', " & Environment.NewLine
                        strsql &= "lparentco.PCo_ID as 'lparentco_Parent Co Id', " & Environment.NewLine
                        strsql &= "lparentco.PCo_Name as 'lparentco_Parent Co', " & Environment.NewLine
                        strsql &= "lparentco.PrcGroup_ID as 'lparentco_PrcGroup_ID', " & Environment.NewLine
                        strsql &= "tcustmarkup.MarkUp_RUR as 'tcustmarkup_MarkUp_RUR', " & Environment.NewLine
                        strsql &= "tcustmarkup.MarkUp_NER as 'tcustmarkup_MarkUp_NER', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_Replacement as 'tcustmarkup_Markup_Replacement', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_PlusRepl as 'tcustmarkup_Markup_PlusRepl', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_PlusParts as 'tcustmarkup_Markup_PlusParts', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_NTF as 'tcustmarkup_Markup_NTF', " & Environment.NewLine
                        strsql &= "tcustmarkup.Markup_RTM as 'tcustmarkup_Markup_RTM', " & Environment.NewLine
                        strsql &= "tcustmarkup.Prod_ID as 'tcustmarkup_Prod_ID', " & Environment.NewLine
                        strsql &= "tcusttoprice.PrcGroup_ID as 'tcusttoprice_PrcGroup_ID', " & Environment.NewLine
                        strsql &= "tcusttoprice.Prod_ID as 'tcusttoprice_Prod_ID', " & Environment.NewLine
                        strsql &= "lpricinggroup.PrcGroup_ID as 'lpricinggroup_PrcGroup_ID', " & Environment.NewLine
                        strsql &= "lpricinggroup.PrcGroup_SDesc as 'lpricinggroup_PrcGroup_SDesc', " & Environment.NewLine
                        strsql &= "lpricinggroup.Prod_ID as 'lpricinggroup_Prod_ID', " & Environment.NewLine
                        strsql &= "lpricinggroup.ProdGrp_ID as 'lpricinggroup_ProdGrp_ID', " & Environment.NewLine
                        strsql &= "tcustwrty.CustWrty_DaysinWrty as 'tcustwrty_CustWrty_DaysinWrty', " & Environment.NewLine
                        strsql &= "tcustwrty.PSSwrtyParts_ID as 'tcustwrty_PSSwrtyParts_ID', " & Environment.NewLine
                        strsql &= "tcustwrty.PSSWrtyLabor_ID as 'tcustwrty_PSSWrtyLabor_ID', " & Environment.NewLine
                        strsql &= "tcustwrty.Prod_ID as 'tcustwrty_Prod_ID' " & Environment.NewLine

                        strsql &= "from tcustomer  " & Environment.NewLine
                        strsql &= "left outer join lparentco on tcustomer.PCo_ID = lparentco.PCo_ID " & Environment.NewLine
                        strsql &= "left outer join tcusttoprice on tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                        strsql &= "left outer join tcustmarkup on tcustomer.Cust_ID = tcustmarkup.Cust_ID " & Environment.NewLine
                        strsql &= "left outer join lpricinggroup on tcusttoprice.PrcGroup_ID = lpricinggroup.PrcGroup_ID " & Environment.NewLine
                        strsql &= "left outer join tcustwrty on tcustomer.Cust_ID = tcustwrty.Cust_ID " & Environment.NewLine

                        strsql &= "where  " & Environment.NewLine
                        strsql &= "tcustomer.cust_id = " & strSearchCriteria & " " & Environment.NewLine

                    Case "Customer Location"
                        'Not Device based
                        strsql = "select " & Environment.NewLine
                        strsql &= "Loc_ID,  " & Environment.NewLine
                        strsql &= "Loc_Name as 'Customer Location', " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name1 as 'Customer Name 1',  " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name2 as 'Customer Name 2' " & Environment.NewLine
                        strsql &= "from tlocation " & Environment.NewLine
                        strsql &= "left outer join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine

                        strsql &= "where  " & Environment.NewLine
                        strsql &= "tlocation.Loc_Name like '" & strSearchCriteria & "%' " & Environment.NewLine

                    Case "Customer Location ID"
                        'Not Device based
                        strsql = "select " & Environment.NewLine
                        strsql &= "Loc_ID,  " & Environment.NewLine
                        strsql &= "Loc_Name as 'Customer Location', " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name1 as 'Customer Name 1',  " & Environment.NewLine
                        strsql &= "tcustomer.Cust_Name2 as 'Customer Name 2' " & Environment.NewLine
                        strsql &= "from tlocation " & Environment.NewLine
                        strsql &= "left outer join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine

                        strsql &= "where  " & Environment.NewLine
                        strsql &= "tlocation.Loc_ID = " & strSearchCriteria & " " & Environment.NewLine

                    Case "Bill Code ID"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine

                        strsql &= "tmodel.Model_ID, " & Environment.NewLine
                        strsql &= "tmodel.Model_Desc as Model, " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_ID as 'lbillcodes_BillCode_ID', " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_Desc as 'lbillcodes_BillCode_Desc', " & Environment.NewLine
                        strsql &= "lbillcoderules.BillCodeRule_Desc as 'lbillcoderules_BillCodeRule_Desc', " & Environment.NewLine
                        strsql &= "a.Prod_Desc as 'Product', " & Environment.NewLine
                        strsql &= "if(lbillcodes.BillType_ID=1,'Service','Part') as 'Part or Service', " & Environment.NewLine

                        strsql &= "tpsmap.BillCode_ID as 'tpsmap_BillCode_ID', " & Environment.NewLine
                        strsql &= "tpsmap.Model_ID as 'tpsmap_Model_ID', " & Environment.NewLine
                        strsql &= "tpsmap.LaborLvl_ID as 'tpsmap_LaborLvl_ID', " & Environment.NewLine
                        strsql &= "tpsmap.CustFlg as 'tpsmap_CustFlg', " & Environment.NewLine
                        strsql &= "tpsmap.Inactive as 'tpsmap_Inactive', " & Environment.NewLine

                        strsql &= "lpsprice.PSPrice_Number as 'lpsprice_PSPrice_Number', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Desc as 'lpsprice_PSPrice_Desc', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_AvgCost as 'lpsprice_PSPrice_AvgCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_StndCost as 'lpsprice_PSPrice_StndCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_ConsignedPart as 'lpsprice_PSPrice_ConsignedPart', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_InventoryPart as 'lpsprice_PSPrice_InventoryPart' " & Environment.NewLine

                        strsql &= "from lbillcodes " & Environment.NewLine
                        strsql &= "left outer join lproduct a on lbillcodes.Device_ID = a.prod_id " & Environment.NewLine
                        strsql &= "left outer join tpsmap on lbillcodes.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                        strsql &= "left outer join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql &= "left outer join lbillcoderules on lbillcodes.BillCode_Rule = lbillcoderules.BillCode_Rule " & Environment.NewLine
                        strsql &= "left outer join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine


                        strsql &= "where  " & Environment.NewLine
                        strsql &= "lbillcodes.Billcode_ID = " & strSearchCriteria & " " & Environment.NewLine

                    Case "Bill Code Desc"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine

                        strsql &= "tmodel.Model_ID, " & Environment.NewLine
                        strsql &= "tmodel.Model_Desc as Model, " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_ID as 'lbillcodes_BillCode_ID', " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_Desc as 'lbillcodes_BillCode_Desc', " & Environment.NewLine
                        strsql &= "lbillcoderules.BillCodeRule_Desc as 'lbillcoderules_BillCodeRule_Desc', " & Environment.NewLine
                        strsql &= "a.Prod_Desc as 'Product', " & Environment.NewLine
                        strsql &= "if(lbillcodes.BillType_ID=1,'Service','Part') as 'Part or Service', " & Environment.NewLine

                        strsql &= "tpsmap.BillCode_ID as 'tpsmap_BillCode_ID', " & Environment.NewLine
                        strsql &= "tpsmap.Model_ID as 'tpsmap_Model_ID', " & Environment.NewLine
                        strsql &= "tpsmap.LaborLvl_ID as 'tpsmap_LaborLvl_ID', " & Environment.NewLine
                        strsql &= "tpsmap.CustFlg as 'tpsmap_CustFlg', " & Environment.NewLine
                        strsql &= "tpsmap.Inactive as 'tpsmap_Inactive', " & Environment.NewLine

                        strsql &= "lpsprice.PSPrice_Number as 'lpsprice_PSPrice_Number', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Desc as 'lpsprice_PSPrice_Desc', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_AvgCost as 'lpsprice_PSPrice_AvgCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_StndCost as 'lpsprice_PSPrice_StndCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_ConsignedPart as 'lpsprice_PSPrice_ConsignedPart', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_InventoryPart as 'lpsprice_PSPrice_InventoryPart' " & Environment.NewLine

                        strsql &= "from lbillcodes " & Environment.NewLine
                        strsql &= "left outer join lproduct a on lbillcodes.Device_ID = a.prod_id " & Environment.NewLine
                        strsql &= "left outer join tpsmap on lbillcodes.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                        strsql &= "left outer join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql &= "left outer join lbillcoderules on lbillcodes.BillCode_Rule = lbillcoderules.BillCode_Rule " & Environment.NewLine
                        strsql &= "left outer join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine


                        strsql &= "where  " & Environment.NewLine
                        strsql &= "lbillcodes.Billcode_desc like '" & strSearchCriteria & "%' " & Environment.NewLine

                    Case "Part Number"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine

                        strsql &= "tmodel.Model_ID, " & Environment.NewLine
                        strsql &= "tmodel.Model_Desc as Model, " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_ID as 'lbillcodes_BillCode_ID', " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_Desc as 'lbillcodes_BillCode_Desc', " & Environment.NewLine
                        strsql &= "lbillcoderules.BillCodeRule_Desc as 'lbillcoderules_BillCodeRule_Desc', " & Environment.NewLine
                        strsql &= "a.Prod_Desc as 'Product', " & Environment.NewLine
                        strsql &= "if(lbillcodes.BillType_ID=1,'Service','Part') as 'Part or Service', " & Environment.NewLine

                        strsql &= "tpsmap.BillCode_ID as 'tpsmap_BillCode_ID', " & Environment.NewLine
                        strsql &= "tpsmap.Model_ID as 'tpsmap_Model_ID', " & Environment.NewLine
                        strsql &= "tpsmap.LaborLvl_ID as 'tpsmap_LaborLvl_ID', " & Environment.NewLine
                        strsql &= "tpsmap.CustFlg as 'tpsmap_CustFlg', " & Environment.NewLine
                        strsql &= "tpsmap.Inactive as 'tpsmap_Inactive', " & Environment.NewLine

                        strsql &= "lpsprice.PSPrice_Number as 'lpsprice_PSPrice_Number', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Desc as 'lpsprice_PSPrice_Desc', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_AvgCost as 'lpsprice_PSPrice_AvgCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_StndCost as 'lpsprice_PSPrice_StndCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_ConsignedPart as 'lpsprice_PSPrice_ConsignedPart', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_InventoryPart as 'lpsprice_PSPrice_InventoryPart' " & Environment.NewLine

                        strsql &= "from lbillcodes " & Environment.NewLine
                        strsql &= "left outer join lproduct a on lbillcodes.Device_ID = a.prod_id " & Environment.NewLine
                        strsql &= "left outer join tpsmap on lbillcodes.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                        strsql &= "left outer join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql &= "left outer join lbillcoderules on lbillcodes.BillCode_Rule = lbillcoderules.BillCode_Rule " & Environment.NewLine
                        strsql &= "left outer join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine


                        strsql &= "where  " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Number like '" & strSearchCriteria & "%' " & Environment.NewLine

                    Case "Part Description"
                        'Not Device based
                        strsql = "Select " & Environment.NewLine

                        strsql &= "tmodel.Model_ID, " & Environment.NewLine
                        strsql &= "tmodel.Model_Desc as Model, " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_ID as 'lbillcodes_BillCode_ID', " & Environment.NewLine
                        strsql &= "lbillcodes.BillCode_Desc as 'lbillcodes_BillCode_Desc', " & Environment.NewLine
                        strsql &= "lbillcoderules.BillCodeRule_Desc as 'lbillcoderules_BillCodeRule_Desc', " & Environment.NewLine
                        strsql &= "a.Prod_Desc as 'Product', " & Environment.NewLine
                        strsql &= "if(lbillcodes.BillType_ID=1,'Service','Part') as 'Part or Service', " & Environment.NewLine

                        strsql &= "tpsmap.BillCode_ID as 'tpsmap_BillCode_ID', " & Environment.NewLine
                        strsql &= "tpsmap.Model_ID as 'tpsmap_Model_ID', " & Environment.NewLine
                        strsql &= "tpsmap.LaborLvl_ID as 'tpsmap_LaborLvl_ID', " & Environment.NewLine
                        strsql &= "tpsmap.CustFlg as 'tpsmap_CustFlg', " & Environment.NewLine
                        strsql &= "tpsmap.Inactive as 'tpsmap_Inactive', " & Environment.NewLine

                        strsql &= "lpsprice.PSPrice_Number as 'lpsprice_PSPrice_Number', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Desc as 'lpsprice_PSPrice_Desc', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_AvgCost as 'lpsprice_PSPrice_AvgCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_StndCost as 'lpsprice_PSPrice_StndCost', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_ConsignedPart as 'lpsprice_PSPrice_ConsignedPart', " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_InventoryPart as 'lpsprice_PSPrice_InventoryPart' " & Environment.NewLine

                        strsql &= "from lbillcodes " & Environment.NewLine
                        strsql &= "left outer join lproduct a on lbillcodes.Device_ID = a.prod_id " & Environment.NewLine
                        strsql &= "left outer join tpsmap on lbillcodes.BillCode_ID = tpsmap.BillCode_ID " & Environment.NewLine
                        strsql &= "left outer join lpsprice on tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strsql &= "left outer join lbillcoderules on lbillcodes.BillCode_Rule = lbillcoderules.BillCode_Rule " & Environment.NewLine
                        strsql &= "left outer join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine


                        strsql &= "where  " & Environment.NewLine
                        strsql &= "lpsprice.PSPrice_Desc like '" & strSearchCriteria & "%' " & Environment.NewLine

                    Case "Machine Name"
                        'Not Device based
                        strsql = "Select  " & Environment.NewLine
                        strsql &= "lwclocation.WC_Machine as 'Machine', " & Environment.NewLine
                        strsql &= "lwclocation.WC_Location as 'Bin', " & Environment.NewLine
                        strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                        strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
                        strsql &= "llineside.LineSide_Desc as 'Side' " & Environment.NewLine
                        strsql &= "from lwclocation " & Environment.NewLine
                        strsql &= "left outer join tgrouplinemap on lwclocation.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                        strsql &= "left outer join lline on tgrouplinemap.Line_ID = lline.Line_ID " & Environment.NewLine
                        strsql &= "left outer join llineside on tgrouplinemap.LineSide_ID = llineside.LineSide_ID " & Environment.NewLine
                        strsql &= "left outer join lgroups on tgrouplinemap.Group_ID = lgroups.Group_ID " & Environment.NewLine

                        strsql &= "where " & Environment.NewLine
                        strsql &= "lwclocation.WC_Machine like '" & strSearchCriteria & "%' " & Environment.NewLine
                    Case Else
                        Exit Function
                End Select

                Me.objMisc._SQL = strsql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If strDevice_IDs = "" Then
                        strDevice_IDs &= R1("Device_ID")
                    Else
                        strDevice_IDs &= "," & R1("Device_ID")
                    End If
                Next R1

                'Get PartInfo and QCInfo
                If strDevice_IDs <> "" Then
                    dtParts = Me.GetPartsInfo(strDevice_IDs)
                    dtQC = Me.GetQCInfo(strDevice_IDs, dtUsers)
                End If

                Return dt1
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dtUsers) Then
                    dtUsers.Dispose()
                    dtUsers = Nothing
                End If
            End Try
        End Function

        '**************************************************************************
        Public Function GetPartsInfo(ByVal strDevice_IDs As String) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tdevicebill.Device_ID, tdevicebill.BillCode_ID, " & Environment.NewLine
                strSql &= "lbillcodes.BillCode_Desc AS 'Desc', " & Environment.NewLine
                strSql &= "tdevicebill.DBill_AvgCost AS 'Avg Cost', " & Environment.NewLine
                strSql &= "tdevicebill.DBill_StdCost AS 'Std Cost' " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID in (" & strDevice_IDs & ") " & Environment.NewLine
                strSql &= "ORDER BY tdevicebill.Device_ID;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Public Function GetQCInfo(ByVal strDevice_IDs As String, _
                                  ByVal dtUsers As DataTable) As DataTable
            Dim strSql As String
            Dim dt1 As DataTable
            Dim R1, R2 As DataRow

            Try
                strSql = "Select Device_ID, " & Environment.NewLine
                strSql &= "tqc.QC_Iteration as Iteration, " & Environment.NewLine
                strSql &= "tqc.QC_Date as 'QC Date', " & Environment.NewLine
                strSql &= "lqctype.QCType as 'QC Type', " & Environment.NewLine
                strSql &= "lqcresult.qcresult as 'QC Result', " & Environment.NewLine
                strSql &= "lcodesdetail.Dcode_SDesc as 'Failure Code', " & Environment.NewLine
                strSql &= "lcodesdetail.Dcode_lDesc as 'Failure Reason', " & Environment.NewLine
                strSql &= "'' as 'QC Inspector', " & Environment.NewLine
                strSql &= "'' as 'Tech', " & Environment.NewLine
                strSql &= "tqc.dcode_id, " & Environment.NewLine
                strSql &= "tqc.Inspector_id, " & Environment.NewLine
                strSql &= "tqc.tech_id, " & Environment.NewLine
                strSql &= "tqc.QC_ID " & Environment.NewLine

                strSql &= "from tqc " & Environment.NewLine
                strSql &= "inner join lqctype on tqc.QCType_ID = lqctype.QCType_ID " & Environment.NewLine
                strSql &= "inner join lqcresult on tqc.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strSql &= "inner join lcodesdetail on tqc.dcode_id = lcodesdetail.dcode_id " & Environment.NewLine
                strSql &= "where Device_ID in (" & strDevice_IDs & ")" & Environment.NewLine
                strSql &= "order by Device_ID, tqc.QC_Iteration, QC_Date;"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    'Inspector Name
                    For Each R2 In dtUsers.Rows
                        If R1("Inspector_id") = R2("User_ID") Then
                            R1("QC Inspector") = "PSS QC " & R2("QCStamp") & " - " & Trim(R2("User_FullName"))
                        End If
                    Next R2
                    R2 = Nothing
                    'Tech Name
                    For Each R2 In dtUsers.Rows
                        If R1("tech_id") = R2("User_ID") Then
                            R1("Tech") = R2("Tech_id") & " - " & Trim(R2("User_FullName"))
                        End If
                    Next R2
                    R2 = Nothing
                    dt1.AcceptChanges()
                Next R1

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dtUsers) Then
                    dtUsers.Dispose()
                    dtUsers = Nothing
                End If
            End Try
        End Function

        '**************************************************************************

    End Class
End Namespace
