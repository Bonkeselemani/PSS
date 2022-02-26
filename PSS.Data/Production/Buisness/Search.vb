Imports PSS.Data.Production
Imports eInfoDesigns.dbProvider.MySqlClient

Namespace Buisness

    Public Class Search

        Private Shared _conn As MySqlConnection = Nothing
        Private Shared _objDataProc As DBQuery.DataProc

        Public Shared Function GetMainData(ByVal searchString As String) As DataTable
            Return InternalGetMainData(searchString)
        End Function
        Public Shared Function GetPretestData(ByVal searchString As String) As DataTable
            Return PretestData(searchString)
        End Function
        Public Shared Function GetQCData(ByVal searchString As String) As DataTable
            Return QCData(searchString)
        End Function
        Public Shared Function GetMainData(ByVal searchString As String, ByVal startDate As String, ByVal endDate As String) As DataTable
            Return InternalGetMainData(searchString & " AND Device_DateRec > " & startDate & " AND Device_DateRec < " & endDate)
        End Function

        '*************************************************************************************
        Private Shared Function InternalGetMainData(ByVal searchString As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iCnt As Integer = 0

            Try
				strSql = "SELECT 0 as Count, tdevice.Device_ID, " & _
				 "tdevice.Device_SN AS 'Serial', " & _
				 "tdevice.Device_OldSN AS 'Old Serial', " & _
				 "tmodel.Model_Desc AS 'Model', " & _
				 "tdevice.Device_DateRec AS 'Date Received',  " & _
				 "DATE_FORMAT(tdevice.Device_RecWorkDate , '%m/%d/%Y') AS 'Work Date Recieved', " & _
				 "tdevice.Device_DateBill AS 'Date Billed', " & _
				 "tdevice.Device_DateShip AS 'Date Produce', " & _
				 "DATE_FORMAT(tdevice.Device_ShipWorkDate , '%m/%d/%Y') AS 'Work Date Produced', " & _
				 "DATE_FORMAT(tpallett.pallett_ShipDate , '%m/%d/%Y') AS 'Pallet Closed Date', " & _
				 "tworkorder.WO_CustWO AS 'Customer WO', " & _
				 "tworkorder.WO_ID AS 'WO ID in', " & _
				 "tdevice.wo_id_Out as 'WO ID Out', " & _
				 "tdevice.Tray_ID AS 'Tray', " & _
				 "tdevice.Ship_ID AS 'Ship ID', " & _
				 "tdevice.Sku_ID, " & _
				 "tsku.SKU_Number AS 'SKU Number', " & _
				 "tcustomer.Cust_Name1 as 'Customer', " & _
				 "tlocation.Cust_ID, " & _
				 "tdevice.Loc_ID, " & _
				 "tlocation.Loc_Name as 'Location', " & _
				 "if(tdevice.Device_Invoice=0,'NO','YES') AS 'Invoiced', " & _
				 "if(tdevice.Device_SendClaim=0,'NO','YES') AS 'M-Claimed?', " & _
				 "tdevice.device_laborlevel AS 'Labor Level', " & _
				 "tdevice.device_laborcharge AS 'Labor Charge', " & _
				 "tdevice.device_partcharge AS 'Part Charge', " & _
				 "tdevice.pallett_id as 'Pallet ID', " & _
				 "tpallett.pallett_name as 'Pallet Name', " & _
				 "tcellopt.CellOpt_MSN as 'MSN in', " & _
				 "tcellopt.CellOpt_OutMSN as 'MSN out', " & _
				 "tcellopt.CellOpt_IMEI as 'IMEI in', " & _
				 "tcellopt.CellOpt_OutIMEI as 'IMEI out', " & _
				 "tcellopt.CellOpt_CSN as 'CSN in', " & _
				 "tcellopt.CellOpt_OutCSN as 'CSN out', " & _
				 "tcellopt.CellOpt_CSN_Dec as 'Decimal SN', " & _
				 "tcellopt.CellOpt_Transceiver as 'Transceiver Code', " & _
				 "tcellopt.CellOpt_SoftVerIN as 'Software in', " & _
				 "tcellopt.CellOpt_SoftVerOUT as 'Software out', " & _
				 "tcellopt.WorkStation as 'Workstation', " & _
				 "if ( tmessdata.wipowner_id in (201,202), woset2.wipowner_desc, if ( lwipowner.wipowner_desc is not null, lwipowner.wipowner_desc, MessWip.wipowner_desc))  as 'WIP Owner', " & _
				 "wosl.wipownersubloc_desc as 'Workstation Sub-Loc.', " & _
				 "if(MessWip.wipowner_desc not in('In-Cell','Ready to QC','Ready to AQL'),'', if(tcostcenter.cc_desc is not null, tcostcenter.cc_desc, '')) as 'Cost Center', " & _
				 "if(tdevice.Device_ManufWrty = 0, 'No', 'Yes') AS ManufWrty, " & _
				 "if(tdevice.Device_PSSWrty = 0, 'No', 'Yes') AS PSSWrty " & _
				 ", if(tdyscerndata.dd_UnlockCode is null, '', tdyscerndata.dd_UnlockCode) as 'Unlock Code' " & _
				 ", if(tdyscerndata.dd_CustDeviceID is null, '', tdyscerndata.dd_CustDeviceID) as 'DID' " & _
				 ", if(tsonitroldata.sd_CustSN is not null, tsonitroldata.sd_CustSN, if(tasndata.SN2 is not null, tasndata.SN2, '') ) as 'Cust SN' " & _
				 ", if(tshipto.ShipTo_Name is null, '', tshipto.ShipTo_Name) as 'Ship To Name' " & _
				 ", if(tshipto.ShipTo_Address1 is null, '', tshipto.ShipTo_Address1) as 'Ship To Address1' " & _
				 ", if(tshipto.ShipTo_Address2 is null, '', tshipto.ShipTo_Address2) as 'Ship To Address2' " & _
				 ", if(tshipto.ShipTo_City is null, '', tshipto.ShipTo_City) as 'Ship To City' " & _
				 ", if(tshipto.ShipTo_Zip is null, '', tshipto.ShipTo_Zip) as 'Ship To Zip' " & _
				 ", if(lstate.State_Short is null, '', lstate.State_Short) as 'Ship To State' " & _
				 ", if(tshipto.Tel is null, '', tshipto.Tel) as 'Ship To Tel' " & _
				 ", if(tshipto.Email is null, '', tshipto.Email) as 'Ship To Email' " & _
				 ", if(tpallett.pkslip_ID is null, '', tpallett.pkslip_ID) as 'Packing Slip #' " & _
				 ", if(tpackingslip.pkslip_TrackNo is not null, tpackingslip.pkslip_TrackNo, '') as 'Tracking#' " & _
				 ", if(tpackingslip.pkslip_DockShipDate is not null, DATE_FORMAT(tpackingslip.pkslip_DockShipDate, '%m/%d/%Y'), pkslip_createDt ) as 'Dock Ship Date' " & _
				 ", if(lshipcarrier.SC_Desc is not null, lshipcarrier.SC_Desc, '') as 'Carrier' " & _
				 "FROM tdevice " & _
				 "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & _
				 "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & _
				 "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & _
				 "LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & _
				 "LEFT OUTER JOIN tpallett ON tdevice.pallett_ID = tpallett.pallett_ID " & _
				 "LEFT OUTER JOIN lwipowner ON tcellopt.Cellopt_WIPOwner = lwipowner.wipowner_id " & _
				 "LEFT OUTER JOIN tsku ON tdevice.sku_ID = tsku.sku_ID " & _
				 "LEFT OUTER JOIN tcustomer ON tcustomer.Cust_ID = tlocation.Cust_ID " & _
				 "LEFT OUTER JOIN tdyscerndata ON tdevice.Device_ID = tdyscerndata.Device_ID " & _
				 "LEFT OUTER JOIN tsonitroldata on tdevice.Device_ID = tsonitroldata.Device_ID " & _
				 "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & _
				 "LEFT OUTER JOIN tpackingslip on tpallett.pkslip_ID = tpackingslip.pkslip_ID " & _
				 "LEFT OUTER JOIN lshipcarrier on tpackingslip.SC_ID = lshipcarrier.SC_ID " & _
				 "LEFT OUTER JOIN tasndata on tdevice.Device_ID = tasndata.Device_ID " & _
				 "LEFT OUTER JOIN tmessdata on tdevice.Device_ID = tmessdata.Device_ID " & _
				 "LEFT OUTER JOIN lwipowner MessWip ON tmessdata.wipowner_id = MessWip.wipowner_id " & _
				 "LEFT OUTER JOIN lwipownersubloc wosl ON tmessdata.wipownersubloc_id = wosl.wipownersubloc_id " & _
				 "LEFT OUTER JOIN lwipowner_set2 woset2 ON tmessdata.wipowner_id = woset2.wipowner_id " & _
				 "LEFT OUTER JOIN tshipto ON tworkorder.shipto_id = tshipto.shipto_id " & _
				 "LEFT OUTER JOIN lstate ON tshipto.State_Id = lstate.State_ID " & _
				 "WHERE " & searchString
                dt = GetDataTable(strSql)
                For Each R1 In dt.Rows
                    iCnt += 1
                    R1.BeginEdit()
                    R1("Count") = iCnt
                    R1.EndEdit()
                Next R1
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Search")
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Private Shared Function PretestData(ByVal searchString As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iCnt As Integer = 0

            Try
                strSql = "Select 0 as Count, d.Device_DateRec as 'Received Date', " & _
                    "d.Device_DateShip as 'Shipped Date', " & _
                    "a.pretest_wkDt as 'Pretest Date', " & _
                    "c.qcresult as 'Pretest Result', " & _
                    "IF (a.QCResult_ID = 1, '',b.Dcode_lDesc) as 'Code Desc', " & _
                    "e.user_fullname as 'Tester', d.device_id as 'Device_ID' " & _
                    "FROM tpretest_data a " & _
                    "INNER JOIN lcodesdetail b on a.PTtf = b.dcode_id " & _
                    "INNER JOIN lqcresult c on a.QCResult_ID = c.QCResult_ID " & _
                    "INNER JOIN tdevice d on d.device_id = a.device_id " & _
                    "INNER JOIN Security.tusers e on a.tech_id = e.tech_id " & _
                    "WHERE d.device_sn = " & searchString
                strSql &= " ORDER BY a.tpretest_id, a.pretest_wkDt; "

                dt = GetDataTable(strSql)
                For Each R1 In dt.Rows
                    iCnt += 1
                    R1.BeginEdit()
                    R1("Count") = iCnt
                    R1.EndEdit()
                Next R1
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Search")
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Private Shared Function QCData(ByVal searchString As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iCnt As Integer = 0

            Try
                strSql = "Select 0 as Count, e.Device_DateRec as 'Received Date', " & Environment.NewLine
                strSql &= "e.Device_DateShip as 'Shipped Date', " & Environment.NewLine
                strSql &= "a.QC_Date as 'QC Date', " & Environment.NewLine
                strSql &= "b.QCType as 'QC Type', " & Environment.NewLine
                strSql &= "c.qcresult as 'QC Result', " & Environment.NewLine
                strSql &= "IF(a.QCResult_ID = 1, '', d.Dcode_lDesc) as 'Failure Reason', " & Environment.NewLine
                strSql &= "f.user_fullname as 'QC Inspector', " & Environment.NewLine
                strSql &= "i.user_fullname as 'Technician Name', " & Environment.NewLine
                strSql &= "h.cust_name1 As 'Customer Name', e.device_id as 'Device_ID'  " & Environment.NewLine
                strSql &= "from tqc a " & Environment.NewLine
                strSql &= "inner join lqctype b on a.QCType_ID = b.QCType_ID " & Environment.NewLine
                strSql &= "inner join lqcresult c on a.QCResult_ID = c.QCResult_ID " & Environment.NewLine
                strSql &= "inner join lcodesdetail d on a.dcode_id = d.dcode_id " & Environment.NewLine
                strSql &= "inner join tdevice e on a.device_id = e.device_id " & Environment.NewLine
                strSql &= "INNER JOIN Security.tusers f on a.inspector_id = f.user_id " & Environment.NewLine
                strSql &= "INNER JOIN Security.tusers i on a.tech_id = i.user_id " & Environment.NewLine
                strSql &= "INNER JOIN tlocation g on e.loc_id = g.loc_id " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer h on g.cust_id = h.cust_id " & Environment.NewLine
                strSql &= "where device_sn = " & searchString & Environment.NewLine
                strSql &= " order by a.QC_ID;" & Environment.NewLine
                dt = GetDataTable(strSql)
                For Each R1 In dt.Rows
                    iCnt += 1
                    R1.BeginEdit()
                    R1("Count") = iCnt
                    R1.EndEdit()
                Next R1
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Search")
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetDataInTestTable(ByVal strSN As String, _
                                                  ByVal strTestTypeIDs As String) As DataTable
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "Select TD_Sequence as Iteration, d.Device_DateRec as 'Received Date', " & Environment.NewLine
                strSql &= "d.Device_DateShip as 'Shipped Date', " & Environment.NewLine
                strSql &= "a.TD_TestDt as 'Transaction Date', " & Environment.NewLine
                strSql &= "b.Test_Desc as 'Transaction Type', " & Environment.NewLine
                strSql &= "g.user_fullname as 'Transaction User', " & Environment.NewLine
                strSql &= "f.cust_name1 As 'Customer Name', d.device_id as 'Device_ID'  " & Environment.NewLine
                strSql &= "from ttestdata a " & Environment.NewLine
                strSql &= "inner join ltesttype b on a.Test_ID = b.Test_ID " & Environment.NewLine
                strSql &= "inner join tdevice d on a.device_id = d.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tlocation e on d.loc_id = e.loc_id " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer f on e.cust_id = f.cust_id " & Environment.NewLine
                strSql &= "INNER JOIN Security.tusers g on a.TD_UsrID = g.user_id " & Environment.NewLine
                strSql &= "where device_sn = " & strSN & Environment.NewLine
                strSql &= "AND a.Test_ID IN ( " & strTestTypeIDs & " ) " & Environment.NewLine
                strSql &= " order by a.Device_ID, td_id ;" & Environment.NewLine

                dt = objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetPartData(ByVal ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tdevicebill.BillCode_ID AS 'Code', " & Environment.NewLine
                strSql &= "lbillcodes.BillCode_Desc AS 'Desc', " & Environment.NewLine
                strSql &= "tdevicebill.DBill_AvgCost AS 'Avg Cost', " & Environment.NewLine
                strSql &= "tdevicebill.DBill_StdCost AS 'Std Cost' , " & Environment.NewLine
                strSql &= "security.tusers.user_fullname as Biller," & Environment.NewLine
                strSql &= "tdevicebill.Date_Rec as 'DateBill' " & Environment.NewLine
                strSql &= ", if(Fail_LDesc is null, '', Fail_LDesc) as 'Fail'" & Environment.NewLine
                strSql &= ", if(Repair_LDesc is null, '', Repair_LDesc) as 'Repair'" & Environment.NewLine
                strSql &= ", ReplPartSN as 'Part S/N' " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN security.tusers ON tdevicebill.User_ID = security.tusers.user_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lfailcodes ON tdevicebill.Fail_ID = lfailcodes.Fail_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lrepaircodes ON tdevicebill.Repair_ID = lrepaircodes.Repair_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & ID & Environment.NewLine
                strSql &= "ORDER BY tdevicebill.DBill_ID ASC;"
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetDeviceData(ByVal id As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tworkorder.WO_Memo AS 'WO Memo', " & Environment.NewLine
                strSql &= "tdevice.Device_SN AS 'Serial', tdevice.Device_OldSN AS 'Old Serial', " & Environment.NewLine
                strSql &= "tdevice.Device_LaborLevel AS 'Labor Level', tdevice.Device_LaborCharge AS 'Labor Charge', tdevice.Device_PartCharge as 'Part Charge', " & Environment.NewLine
                strSql &= "tcustomer.Cust_Name1 AS 'Name 1', tcustomer.Cust_Name2 AS 'Name 2', tlocation.Loc_Name as Location, " & Environment.NewLine
                strSql &= "ttray.Tray_RecUser as RecClerk, ttray.Tray_BillUser as BillClerk, tship.Ship_User as ShipClerk, lwipowner.wipowner_desc as 'WIP Owner', tcellopt.WorkStation as 'Work Station', tworkorder.PO_ID as 'PO ID', " & Environment.NewLine
                strSql &= "Fedex_ID AS 'Tracking No.' FROM tcustomer  " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON ttray.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN ttray ON tdevice.Tray_ID = ttray.Tray_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tship ON tdevice.Ship_ID = tship.Ship_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tlocation.Loc_ID = tdevice.Loc_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lwipowner ON tcellopt.Cellopt_WIPOwner = lwipowner.wipowner_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tshipbill ON tship.Ship_ID = tshipbill.Ship_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & id & ";"
                '//Data does not exists in tcellopt table when the device is messaging
                '//Modified to LEFT OUTER JOIN
                '"INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & _
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception()
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetDeviceCodesData(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Device_ID, Device_SN as SN, Dcode_Sdesc as 'Code', Dcode_Ldesc as 'Code Description' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicecodes ON tdevice.Device_ID = tdevicecodes.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tdevicecodes.Dcode_ID = lcodesdetail.Dcode_id " & Environment.NewLine
                strSql &= "WHERE device_sn = " & strSN & Environment.NewLine
                strSql &= "ORDER BY tdevicecodes.devicecode_id;" & Environment.NewLine
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetMessagingData(ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Device_ID as 'Device_ID', Device_DateRec as 'Receipt Date' " & Environment.NewLine
                strSql &= ", lfrequency.freq_Number as 'Frequency #', tmessdata.capcode as 'Capcode', lbaud.baud_Number as 'Baud Rate' " & Environment.NewLine
                strSql &= ", lwipowner.wipowner_desc as 'Wip Owner', cc_desc as 'Cost Center' " & Environment.NewLine
                strSql &= ", if(wipownersubloc_desc is null, '', wipownersubloc_desc) as 'Wip Sub-Location'" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lwipowner on tmessdata.wipowner_id = lwipowner.wipowner_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lfrequency on tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lbaud on tmessdata.baud_id= lbaud.baud_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lwipownersubloc on tmessdata.wipowner_id = lwipownersubloc.wipowner_id AND tmessdata.wipownersubloc_id = lwipownersubloc.wipownersubloc_id " & Environment.NewLine
                strSql &= "WHERE device_sn = " & strSN & Environment.NewLine

                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetSyxMfgSerialData(ByVal strMfgSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT a.Manuf_SN as 'Mfg Serial',a.PSS_SerialNumber as 'PSS Serial',c.Prod_Desc as Product" & Environment.NewLine
                strSql &= ",d.Manuf_Desc as 'Mfg',a.Model_Desc as Model" & Environment.NewLine
                strSql &= ",b.Device_DateRec as 'Received Date',a.ReceivingPalletName as 'Received Pallet'" & Environment.NewLine
                strSql &= ",g.WO_CustWO as WorkOrder,b.Device_ShipWorkDate as 'Ship Date',e.Pallett_Name as 'Ship Pallet'" & Environment.NewLine
                strSql &= ",f.Loc_Name as Location,if( a.HasBox = 1, 'Yes', 'No') as 'Has Box?',a.Cost" & Environment.NewLine
                strSql &= ",b.device_laborcharge AS 'Labor Charge',if(h.cc_desc is not null, h.cc_desc, '') as 'Cost Center'" & Environment.NewLine
                strSql &= ",if(j.SC_Desc is not null, j.SC_Desc, '') as 'Carrier'" & Environment.NewLine
                strSql &= ",if(i.pkslip_TrackNo is not null, i.pkslip_TrackNo, '') as 'Tracking#'" & Environment.NewLine
                strSql &= ",if(k.ShipTo_Name is null, '', k.ShipTo_Name) as 'Ship To'" & Environment.NewLine
                strSql &= ",a.Status" & Environment.NewLine
                strSql &= "FROM syxdata a" & Environment.NewLine
                strSql &= "left join tdevice b on b.device_id=a.device_id" & Environment.NewLine
                strSql &= "left join lproduct c on c.Prod_id=a.NewModelProdID" & Environment.NewLine
                strSql &= "left join lmanuf d on d.Manuf_ID=a.Manuf_ID" & Environment.NewLine
                strSql &= "left join tpallett e on e.Pallett_ID=b.Pallett_ID" & Environment.NewLine
                strSql &= "left join tlocation f on f.Loc_ID=b.Loc_ID" & Environment.NewLine
                strSql &= "left join tWorkOrder g on g.WO_ID=b.WO_ID" & Environment.NewLine
                strSql &= "left join tcostcenter h on h.cc_id = b.cc_id" & Environment.NewLine
                strSql &= "left join tpackingslip i on i.pkslip_ID = e.pkslip_ID" & Environment.NewLine
                strSql &= "left join lshipcarrier j on j.SC_ID = i.SC_ID" & Environment.NewLine
                strSql &= "left join tshipto k ON k.shipto_id = g.shipto_id" & Environment.NewLine
                strSql &= "Where a.Manuf_SN=" & strMfgSN & Environment.NewLine

                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Shared Function GetWorkOrderID(ByVal strWOCustWO As String) As DataTable
            Dim strSql As String = ""

            Try
                strWOCustWO = strWOCustWO.Replace("'", "''")

                strSql = "SELECT * FROM tWorkOrder " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & strWOCustWO & "'" & Environment.NewLine

                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Private Shared Function GetDataTable(ByVal [string] As String) As DataTable
            '//This has been changed to use replicated database instead of production
            '//October 14, 2003
            '//Craig Haney
            '//BEGIN
            '_conn = Connection.GetConnection
            '_conn = GetConnectionRep()     'Commented by Asif on 04/27/2005 as part of a solution to the replication failures
            '//END

            'added by Asif on 04/27/2005 as part of a solution to the replication failures
            _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            Return _objDataProc.GetDataTable([string])

            '_conn = Connection.GetConnection(, 1)   'Pass 1 as serverID to use a replicated database

            'Dim _cmd As New MySqlCommand([string], _conn)
            'Dim _da As New MySqlDataAdapter()
            '_da.SelectCommand = _cmd
            'Dim _dt As New DataTable()
            '_da.Fill(_dt)
            '_da.Dispose()
            '_cmd.Dispose()
            '_da = Nothing
            'Return _dt
            ''//New Craig Haney
            '_conn.Close()
            '_conn.Dispose()
            ''//End New Craig Haney
        End Function

        Private Shared Sub SetData(ByVal [string] As String)
            _objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

            _objDataProc.ExecuteNonQuery([string])
            '_conn = Connection.GetConnection
            'Dim _cmd As New MySqlCommand([string], _conn)
            ''_conn.Open()
            '_cmd.ExecuteNonQuery()
            '_cmd.Dispose()
            ''//Craig Haney
            '_conn.Close()
            '_conn.Dispose()
            ''//Craig Haney
        End Sub

    End Class

End Namespace
