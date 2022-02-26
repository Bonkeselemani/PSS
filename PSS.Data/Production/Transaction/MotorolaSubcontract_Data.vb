'Imports System
'Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient
'Imports PSS.Data

Namespace Production
    Public Class MotorolaSubcontract_Data

        'Private _objDataProc As DBQuery.DataProc
        Private strSql As String

        ''******************************************************************
        'Public Sub New()
        '    Try
        '        Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub

        ''******************************************************************
        'Protected Overrides Sub Finalize()
        '    Me._objDataProc = Nothing
        '    MyBase.Finalize()
        'End Sub

        '******************************************
        Public Function CreatePalletReport(ByVal iPalletID As Integer) As DataTable

            Try
                strSql = "Select * from tdevice where Pallett_ID = " & iPalletID & ";"
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.CreatePalletReport: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '****************************************************************************
        'Get DeviceInfo by Device_ID
        '****************************************************************************
        Public Function GetDeviceInfo(ByVal iDevice_ID As Integer) As DataTable
            strSql = "Select * from tdevice where Device_ID = " & iDevice_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Checks if the device is being RTMd
        '****************************************************************************
        Public Function IsDeviceRTM(ByVal iDevice_ID As Integer) As DataTable
            strSql = "Select Count(*) as iCount from tdevicebill where billcode_id = 466 and Device_ID = " & iDevice_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '************************************************************************************************************
        'Get highest level probelm found and repair action
        '************************************************************************************************************
        Public Function HighestLevel_ProbFound_RepAction(ByVal iDevice_id As Integer) As DataTable
            strSql = "select " & Environment.NewLine
            strSql += "tpsmap.billcode_id, " & Environment.NewLine
            strSql += "tpsmap.laborlvl_id, " & Environment.NewLine
            strSql += "twrtymap.wmap_problemfound, " & Environment.NewLine
            strSql += "twrtymap.wmap_repairaction " & Environment.NewLine

            strSql += "from tdevice " & Environment.NewLine
            strSql += "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
            strSql += "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id " & Environment.NewLine
            strSql += "left outer join twrtymap on tdevice.model_id = twrtymap.model_id and tpsmap.billcode_id = twrtymap.billcode_id " & Environment.NewLine

            strSql += "where tdevice.device_id = " & iDevice_id & " " & Environment.NewLine

            strSql += "order by laborlvl_id desc;"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '************************************************************************************************************
        'Gets DCode_Dsesc for a Dcode_ID from lcodesdetail table
        '************************************************************************************************************
        Public Function GetCodeDescription(ByVal iDCode_ID As Integer) As DataTable
            strSql = "select * from lcodesdetail where dcode_id = " & iDCode_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'This gets the current Reconciliation status of a claim
        '****************************************************************************
        Public Function GetReconciliationStatus(ByVal iClaimNo As Integer) As DataTable
            strSql = "Select Cellopt_ReconStatus from tcellopt where Device_id = " & iClaimNo & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Load Reconciliation Parts data
        '****************************************************************************
        Public Function LoadClaimReconciliationPartData(ByVal iBatchNumber As Integer, _
                                                        ByVal iQnty As Integer, _
                                                        ByVal strPrtNum As String) As Integer

            strSql = "Insert into tmotoreconparts " & Environment.NewLine
            strSql += "(MotoRecPart_Batch, MotoRecPart_Qty, MotoRecPart_Number) " & Environment.NewLine
            strSql += "Values (" & iBatchNumber & ", " & iQnty & ", '" & strPrtNum & "');"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateReconciliationStatus: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Checks if the batch already exists for parts
        '****************************************************************************
        Public Function CheckifBatchExistsForParts(ByVal iBatchNumber As Integer) As DataTable

            strSql = "Select Count(*) as BatchExists from tmotoreconparts where MotoRecPart_Batch = " & iBatchNumber & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Update Reconciliation Ststus in tcellopt table
        '****************************************************************************
        Public Function UpdateReconciliationStatus(ByVal iClaimNo As Integer, _
                                                    ByVal iAccptedRejectedClaims As Integer) As Integer

            strSql = "Update tcellopt Set cellopt_ReconStatus = " & iAccptedRejectedClaims & " Where Device_ID = " & iClaimNo & ";"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateReconciliationStatus: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Loads the Claim Reconciliation Data
        '****************************************************************************
        Public Function LoadClaimReconciliationData(ByVal strBatchDate As String, _
                                                    ByVal iBatchNumber As Integer, _
                                                    ByVal iAccptedRejectedClaims As Integer, _
                                                    ByVal strWrty As String, _
                                                    ByVal decFixedRate As Decimal, _
                                                    ByVal decPartPrice As Decimal, _
                                                    ByVal decClaimDiscAmt As Decimal, _
                                                    ByVal decConsDiscAmt As Decimal, _
                                                    ByVal decTotalPaid As Decimal, _
                                                    ByVal strRejectMsg As String, _
                                                    ByVal iClaimNo As Integer) As Integer

            strSql = "Insert into tmotorolarecon " & Environment.NewLine
            strSql += "(MotoRec_DateClaim, MotoRec_BatchNo, MotoRec_Rejected, MotoRec_Wrty, MotoRec_Labor, MotoRec_Parts, MotoRec_Claim_Disc, MotoRec_Cons_Disc, MotoRec_TotalPaid, MotoRec_Reject_Memo, Device_ID) " & Environment.NewLine
            strSql += "Values ('" & strBatchDate & "', " & iBatchNumber & ", " & iAccptedRejectedClaims & ", '" & strWrty & "', " & decFixedRate & ", " & decPartPrice & ", " & decClaimDiscAmt & ", " & decConsDiscAmt & ", " & decTotalPaid & ", '" & strRejectMsg & "', " & iClaimNo & ");"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.LoadClaimReconciliationData: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Checks if the batch already exists
        '****************************************************************************
        Public Function CheckifBatchExists(ByVal iBatchNumber As Integer) As DataTable

            strSql = "Select Count(*) as BatchExists from tmotorolarecon where MotoRec_BatchNo = " & iBatchNumber & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'GEts the Number of devices received under a given RMA or work order
        '****************************************************************************
        Public Function GetNumOfDevicesReceivedForWO(ByVal iWO_ID As Integer) As DataTable
            strSql = "select Count(*) as DevicesReceived from tdevice where WO_ID = " & iWO_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Gets Printer Name
        '****************************************************************************
        Public Function GetPrinterName(ByVal iPrinter_ID As Integer) As DataTable

            strSql = "select * from tprinter where Printer_ID = " & iPrinter_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Retrieves Label info for a given location of a customer.
        '****************************************************************************
        Public Function GetLabelInfo(ByVal iLoc_ID As Integer, _
                                    ByVal iProcessType As Integer) As DataTable

            strSql = "select tlocmap.*, " & Environment.NewLine
            strSql += "'' as CoffinLabelPrinter, " & Environment.NewLine
            strSql += "'' as MasterLabelPrinter, " & Environment.NewLine
            strSql += "'' as OverpackLabelPrinter, " & Environment.NewLine
            strSql += "'' as PallettLabelPrinter " & Environment.NewLine
            strSql += "from tlocmap " & Environment.NewLine
            strSql += "where LocMap_ProcType = " & iProcessType & Environment.NewLine
            strSql += " and Loc_ID = " & iLoc_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Get Device_SN by cellopt_OutIMEI
        '****************************************************************************
        Public Function GetDeviceSNByIMEINo(ByVal strIMEIOut As String) As DataTable
            strSql = "select tdevice.* from tcellopt inner join tdevice on tcellopt.device_id = tdevice.device_id where tdevice.ship_id is null and tcellopt.cellopt_OutIMEI = '" & strIMEIOut & "';"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'Get Locations For Customer
        '****************************************************************************
        Public Function GetLocationsForCustomer(ByVal iCust_ID As Integer) As DataTable
            strSql = "select tcustomer.Cust_Name1, tlocation.*, lstate.state_short from tlocation inner join lstate on tlocation.state_id = lstate.state_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id where tlocation.cust_id = " & iCust_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '************************************************************************************************************
        'Gets RMA Number for WO_ID_Out
        '************************************************************************************************************
        Public Function GetOutgoingRMANumber(ByVal iWO_ID_Out As Integer) As DataTable

            strSql = "select WO_ID, left(WO_CustWO, 20) as WO_CustWO " + vbCrLf
            strSql = strSql + "from tworkorder " + vbCrLf
            strSql = strSql + "where WO_ID = " & iWO_ID_Out & "; "

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try
        End Function

        '************************************************************************************************************
        'Update Device table
        '************************************************************************************************************
        Public Function SetDeviceSendClaimFlag(ByVal strDeviceIDs As String) As Integer

            strSql = "Update tdevice " + vbCrLf
            strSql = strSql + "set Device_SendClaim = 1 " + vbCrLf
            strSql = strSql + "where Device_ID in " & strDeviceIDs & ";"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.SetDeviceSendClaimFlag: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '****************************************************************************
        'Gets the second part of the motorol warranty claim info
        '****************************************************************************
        Public Function GetMotorolaWIPInfo2(ByVal strDeviceIDs As String) As DataTable

            '******************************************************************
            'Construct the SQL Query string here
            '******************************************************************
            strSql = "SELECT DISTINCT" + vbCrLf
            strSql &= "tdevicecodes.Device_ID, " + vbCrLf
            strSql &= "tdevicecodes.Dcode_ID, " + vbCrLf
            strSql &= "lcodesdetail.Dcode_Sdesc, " + vbCrLf
            strSql &= "lcodesmaster.Mcode_Desc " + vbCrLf

            strSql &= "FROM " + vbCrLf
            strSql &= "tdevice " + vbCrLf
            strSql &= "LEFT OUTER JOIN tdevicecodes on tdevice.Device_ID = tdevicecodes.Device_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lcodesdetail on tdevicecodes.Dcode_ID = lcodesdetail.Dcode_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lcodesmaster on lcodesdetail.Mcode_ID = lcodesmaster.Mcode_ID " + vbCrLf

            strSql &= "WHERE " + vbCrLf
            strSql &= "tdevice.device_id in " & strDeviceIDs + vbCrLf

            strSql &= " ORDER BY tdevicecodes.Device_ID, lcodesdetail.Dcode_Sdesc; "

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try

        End Function


        '************************************************************************************************************
        Public Function GetMotorolaWIPInfo1(ByVal strDeviceIDs As String) As DataTable

            '******************************************************************
            'Construct the SQL Query string here
            '******************************************************************
            strSql = "SELECT Distinct" + vbCrLf
            strSql &= "'CLM' AS CLM, " + vbCrLf
            strSql &= "IF(tcustomer.Cust_Name2 IS NULL, TRIM(LEFT(tcustomer.Cust_Name1, 40)), TRIM(LEFT(tcustomer.Cust_Name2, 40))) AS ConsumerSurname, " + vbCrLf
            strSql &= "IF(lcountry.Cntry_Name IS NULL, '', UCASE(TRIM(LEFT(lcountry.Cntry_Name, 3)))) AS CountryCode, " + vbCrLf
            strSql &= "'Motorola' AS CourierTrackingIn, " + vbCrLf
            strSql &= "'Motorola' AS CourierTrackingOut, " + vbCrLf
            strSql &= "tdevice.Device_ID AS WarrantyClaim, " + vbCrLf
            strSql &= "'' AS AirtimeCarCode, " + vbCrLf
            strSql &= "'' AS TransactionCode, " + vbCrLf
            strSql &= "'' AS Product_APCcode, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_Transceiver IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_Transceiver, 15))) AS TansceiverCode, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_MSN IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_MSN, 14))) AS IncomingMSN, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_OutMSN IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_OutMSN, 14))) AS OutgoingMSN, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_IMEI IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_IMEI, 18))) AS IncomingIMEI, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_OutIMEI IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_OutIMEI, 18))) AS OutgoingIMEI, " + vbCrLf
            strSql &= "'' AS RepairStatus, " + vbCrLf
            strSql &= "IF(tdevice.Device_DateRec IS NULL, '', DATE_FORMAT(tdevice.Device_DateRec, '%M %d %Y %r')) AS DateReceived, " + vbCrLf
            strSql &= "IF(tpallett.Pallett_ShipDate IS NULL, '', DATE_FORMAT(tpallett.Pallett_ShipDate, '%M %d %Y %r')) AS DateShipped, " + vbCrLf
            strSql &= "'' AS TimeShipped, " + vbCrLf
            strSql &= "IF(tdevice.Device_DateBill IS NULL, '', DATE_FORMAT(tdevice.Device_DateBill, '%M %d %Y %r')) AS ReapairDate, " + vbCrLf
            strSql &= "'' AS RepairTime, " + vbCrLf
            strSql &= "'' AS RepairCycleTime, " + vbCrLf
            strSql &= "'' AS POPWarrantyClaim, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_POP IS NULL, '', DATE_FORMAT(tcellopt.CellOpt_POP, '%M %d %Y %r')) AS DateofPurchase, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_CSN IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_CSN, 11))) AS IncomingESNorCSN, " + vbCrLf
            strSql &= "IF(tdevice.Device_SN IS NULL, '', TRIM(LEFT(tdevice.Device_SN, 11))) AS DeviceSerialNumber, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_OutCSN IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_OutCSN, 11))) AS OutgoingESNorCSN, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_SoftVerIN IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_SoftVerIN, 10))) AS SoftwareVersionIn, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_SoftVerOUT IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_SoftVerOUT, 10))) AS SoftwareVersionOut, " + vbCrLf
            strSql &= "'' AS CustomerComplaint, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_TechID IS NULL, '', TRIM(LEFT(tcellopt.CellOpt_TechID, 9))) AS TechnicianID, " + vbCrLf
            strSql &= "'' AS PrimaryProbFoundCode, " + vbCrLf
            strSql &= "'' AS PrimaryRepairAction, " + vbCrLf
            strSql &= "IF(tcellopt.CellOpt_Airtime IS NULL, '0', TRIM(LEFT(tcellopt.CellOpt_Airtime, 20))) AS Airtime, " + vbCrLf
            strSql &= "IF(tdevice.WO_ID_Out IS NULL, 0, tdevice.WO_ID_Out) AS WO_ID_Out, " + vbCrLf
            strSql &= "'' AS CustRefNum " + vbCrLf

            strSql &= "FROM " + vbCrLf
            strSql &= "tdevice " + vbCrLf
            strSql &= "inner join tlocation on tdevice.loc_ID = tlocation.Loc_ID " + vbCrLf
            strSql &= "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " + vbCrLf
            strSql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " + vbCrLf
            strSql &= "inner join lcountry on tlocation.Cntry_ID = lcountry.Cntry_ID " + vbCrLf
            strSql &= "left outer join tpallett on tdevice.pallett_id = tpallett.pallett_id " + vbCrLf

            strSql &= " WHERE " + vbCrLf
            strSql &= "tdevice.device_id in " & strDeviceIDs + vbCrLf

            strSql &= " ORDER BY WarrantyClaim; "

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try

        End Function

        '****************************************************************************
        'Gets the second part of the motorol warranty claim info
        '****************************************************************************
        Public Function GetMotorolaWIPDetail2(ByVal strDeviceIDs As String) As DataTable

            ''******************************************************************
            ''Construct the SQL Query string here
            ''******************************************************************
            strSql = "SELECT " + vbCrLf
            strSql &= "tdevicebill.Device_ID, " + vbCrLf
            strSql &= "IF (lpsprice.PSPrice_Number IS NULL, '', TRIM(lpsprice.PSPrice_Number)) AS MotoPartNumber, " + vbCrLf
            strSql &= "tpartscodes.Dcode_ID, " + vbCrLf
            strSql &= "if (lcodesdetail.Dcode_Sdesc is null, '', lcodesdetail.Dcode_Sdesc) as Dcode_Sdesc, " + vbCrLf
            strSql &= "if (lcodesmaster.Mcode_Desc is null, '', lcodesmaster.Mcode_Desc) as Mcode_Desc " + vbCrLf

            strSql &= "FROM " + vbCrLf
            strSql &= "tdevice " + vbCrLf
            strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN tpsmap ON tdevicebill.BillCode_ID = tpsmap.BillCode_ID AND tdevice.Model_ID = tpsmap.Model_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN tpartscodes ON tdevicebill.DBill_ID = tpartscodes.DBill_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lcodesdetail ON tpartscodes.Dcode_ID = lcodesdetail.Dcode_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " + vbCrLf

            strSql &= "WHERE " + vbCrLf
            strSql &= "tdevice.device_id in " & strDeviceIDs + vbCrLf
            strSql &= " and lbillcodes.BillType_ID = 2 " + vbCrLf        'Parts only, no services

            strSql &= " ORDER BY tdevicebill.Device_ID, lcodesdetail.Dcode_Sdesc; "

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try

        End Function

        '****************************************************************************
        'Get the Component detail info 1
        '****************************************************************************
        Public Function GetMotorolaWIPDetail1(ByVal strDeviceIDs As String, _
                                                ByVal strMascCode As String) As DataTable
            strSql = "SELECT " + vbCrLf
            strSql &= "'CMP' AS CMP, " + vbCrLf


            'If iClaimType = 0 Then
            '    strSql &= "'US021553' AS MASCCode, " + vbCrLf
            'ElseIf iClaimType = 1 Then
            '    strSql &= "'US021939' AS MASCCode, " + vbCrLf
            'End If

            strSql &= "'" & strMascCode & "' AS MASCCode, " + vbCrLf

            strSql &= "tdevice.Device_ID AS WarrantyClaim, " + vbCrLf
            strSql &= "IF (lpsprice.PSPrice_Number IS NULL, '', TRIM(lpsprice.PSPrice_Number)) AS MotoPartNumber, " + vbCrLf
            strSql &= "'1' AS QttyReplaced, " + vbCrLf
            strSql &= "'0' AS QttyExchanged, " + vbCrLf
            strSql &= "'R' AS RepairOrRefurbish, " + vbCrLf
            strSql &= "'' AS RefDesignator, " + vbCrLf
            strSql &= "IF (tbillcell.BCell_RefDSNum IS NULL, '', TRIM(tbillcell.BCell_RefDSNum)) AS RefDesigNum, " + vbCrLf
            strSql &= "'' AS PartFailureCode, " + vbCrLf
            strSql &= "'RPC' AS ResolderOrReplace " + vbCrLf

            strSql &= "FROM " + vbCrLf
            strSql &= "tdevice " + vbCrLf
            strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN tbillcell ON tdevicebill.DBill_ID = tbillcell.DBill_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN tpsmap ON tdevicebill.BillCode_ID = tpsmap.BillCode_ID AND tdevice.Model_ID = tpsmap.Model_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " + vbCrLf
            strSql &= "LEFT OUTER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " + vbCrLf

            strSql &= "WHERE " + vbCrLf
            strSql &= "tdevice.device_id in " & strDeviceIDs & vbCrLf               'Motorola
            strSql &= " and lbillcodes.BillType_ID = 2 " + vbCrLf        'Parts only ,no services

            strSql &= "ORDER BY WarrantyClaim; "

            Try
                Return GetDataTable(strSql)
            Catch Ex As Exception
                Throw Ex
            Finally
                strSql = ""
            End Try

        End Function


        '****************************************************************************
        'This gets the model info by Device_ID
        '****************************************************************************
        Public Function GetModelInfo(ByVal iModel_ID As Integer) As DataTable
            strSql = "select * from tmodel where model_id = " & iModel_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetModelInfo: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '****************************************************************************
        'This checks if the Claim belongs to the Customer they have chosen in the menu
        '****************************************************************************
        Public Function DeviceBlongsToClaimType(ByVal iDevice_ID As Integer, _
                                        ByVal iCustID As Integer) As DataTable

            If iCustID = 0 Then     'ASC Work
                strSql = "select count(*) as ClaimBelongs " & Environment.NewLine
                strSql &= "from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "where tdevice.device_id = " & iDevice_ID & " and " & Environment.NewLine
                strSql &= "tlocation.cust_id <> 1403 and tlocation.cust_id <> 1844;"
            Else                    'NSC and RL work  (Subcontract)
                strSql = "select count(*) as ClaimBelongs " & Environment.NewLine
                strSql &= "from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strSql &= "where tdevice.device_id = " & iDevice_ID & " and " & Environment.NewLine
                strSql &= "tlocation.cust_id = " & iCustID & ";"
            End If

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.DeviceBlongsToClaimType: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the parts codes
        '***************************************************
        Public Function GetPartsCodesByDeviceID(ByVal iDevice_ID As Integer, _
                                                ByVal iClaimType As Integer) As DataTable

            strSql = "SELECT distinct " & Environment.NewLine
            strSql &= "IF (lpsprice.PSPrice_Number IS NULL, '', UCASE(TRIM(lpsprice.PSPrice_Number))) AS Part_Number, " & Environment.NewLine
            strSql &= "IF (lpsprice.PSPrice_Desc IS NULL, '', TRIM(lpsprice.PSPrice_Desc)) AS Part_Description, " & Environment.NewLine
            strSql &= "if (lcodesmaster.Mcode_Desc is null, '', lcodesmaster.Mcode_Desc) as Code_Type, " & Environment.NewLine
            strSql &= "if (lcodesdetail.Dcode_Sdesc is null, '', lcodesdetail.Dcode_Sdesc) as Code, " & Environment.NewLine
            strSql &= "if (lcodesdetail.Dcode_Ldesc is null, '', lcodesdetail.Dcode_Ldesc) as Code_Description, " & Environment.NewLine
            strSql &= "if (tbillcell.bcell_refdsnum is null, '', tbillcell.bcell_refdsnum) as RefDesigNum, " & Environment.NewLine
            strSql &= "tpartscodes.tpartscode_id, " & Environment.NewLine
            strSql &= "tdevice.Device_ID, " & Environment.NewLine
            strSql &= "tpartscodes.Dcode_ID, " & Environment.NewLine
            strSql &= "lcodesdetail.mcode_id, " & Environment.NewLine
            strSql &= "tdevicebill.BillCode_id, " & Environment.NewLine
            strSql &= "lbillcodes.BillType_id, " & Environment.NewLine
            strSql &= "tbillcell.dbill_id " & Environment.NewLine

            strSql &= "FROM tdevice " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN tbillcell ON tdevicebill.DBill_ID = tbillcell.DBill_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN tpsmap ON tdevicebill.BillCode_ID = tpsmap.BillCode_ID AND tdevice.Model_ID = tpsmap.Model_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN tpartscodes ON tdevicebill.DBill_ID = tpartscodes.DBill_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN lcodesdetail ON tpartscodes.Dcode_ID = lcodesdetail.Dcode_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID " & Environment.NewLine
            strSql &= "LEFT OUTER JOIN lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine

            strSql &= "where " & Environment.NewLine
            strSql &= "tdevice.device_id = " & iDevice_ID & Environment.NewLine
            strSql &= " and lbillcodes.BillType_ID = 2;"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetPartsCodesByDeviceID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Get codes by Device_ID
        '***************************************************
        Public Function GetCodesByDeviceID(ByVal iDevice_ID As Integer) As DataTable

            strSql = "select tdevicecodes.dcode_id, lcodesdetail.dcode_sdesc, lcodesdetail.dcode_ldesc, lcodesdetail.Mcode_ID " & Environment.NewLine
            strSql &= "from tdevicecodes inner join lcodesdetail on tdevicecodes.dcode_id = lcodesdetail.dcode_id " & Environment.NewLine
            strSql &= "where tdevicecodes.device_id = " & iDevice_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetCodesByDeviceID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the Codes for a Manuf, Prod and Mcode_ID
        '***************************************************
        Public Function GetCodes(ByVal iManuf_ID As Integer, _
                                        ByVal iProd_ID As Integer, _
                                        ByVal iMcode_ID As Integer) As DataTable
            strSql = "select Dcode_ID, trim(dcode_sdesc) as dcode_sdesc, dcode_ldesc " & Environment.NewLine
            strSql &= "from lcodesdetail " & Environment.NewLine
            strSql &= "where manuf_id = " & iManuf_ID & " and " & Environment.NewLine
            strSql &= "Prod_ID = " & iProd_ID & " and " & Environment.NewLine
            strSql &= "dcode_inactive = 0 and " & Environment.NewLine
            strSql &= "Mcode_ID = " & iMcode_ID & " " & Environment.NewLine

            If iMcode_ID = 6 Then
                strSql &= "Order by dcode_sdesc;"
            Else
                strSql &= "Order by dcode_ldesc;"
            End If

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetCodes: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the Device info from tcellopt table
        '***************************************************
        Public Function GetDeviceInfoFromCellOptByDeviceID(ByVal iDevice_ID As Integer) As DataTable


            strSql = "select if (cellopt_csn is NULL, '', cellopt_csn) as cellopt_csn, " & Environment.NewLine
            strSql &= "if (cellopt_outcsn is NULL, '', cellopt_outcsn) as cellopt_outcsn, " & Environment.NewLine
            strSql &= "if (cellopt_msn is NULL, '', cellopt_msn) as cellopt_msn, " & Environment.NewLine
            strSql &= "if (cellopt_outmsn is NULL, '', cellopt_outmsn) as cellopt_outmsn, " & Environment.NewLine
            strSql &= "if (cellopt_imei is NULL, '', cellopt_imei) as cellopt_imei, " & Environment.NewLine
            strSql &= "if (cellopt_outimei is NULL, '', cellopt_outimei) as cellopt_outimei, " & Environment.NewLine
            strSql &= "if (cellopt_transceiver is NULL, '', cellopt_transceiver) as cellopt_transceiver, " & Environment.NewLine
            strSql &= "if (cellopt_pop is NULL, '', cellopt_pop) as cellopt_pop, " & Environment.NewLine
            strSql &= "if (cellopt_techid is NULL, '', cellopt_techid) as cellopt_techid, " & Environment.NewLine
            strSql &= "if (cellopt_softverin is NULL, '', cellopt_softverin) as cellopt_softverin, " & Environment.NewLine
            strSql &= "if (cellopt_softverout is NULL, '', cellopt_softverout) as cellopt_softverout, " & Environment.NewLine
            strSql &= "if (cellopt_Airtime is NULL, '', cellopt_Airtime) as cellopt_Airtime " & Environment.NewLine

            strSql &= "from tcellopt " & Environment.NewLine
            strSql &= "where device_id = " & iDevice_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetDeviceInfoFromCellOptByDeviceID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Gets Num Of Devices In Pallett
        '***************************************************
        Public Function GetWOInfoByDeviceID(ByVal iDevice_ID As Integer, _
                                            ByVal iClaimType As Integer) As DataTable

            If iClaimType = 0 Then      'ASC Claims
                strSql = "select tdevice.device_id, tdevice.Model_ID, if (tdevice.device_sn is NULL, '', tdevice.device_sn) as Device_SN, if (tdevice.device_daterec is NULL, '', tdevice.device_daterec) as device_daterec, if (tdevice.device_datebill is NULL, '', tdevice.device_datebill) as device_datebill, if (tdevice.device_dateship is NULL, '', tdevice.device_dateship) as device_dateship, tdevice.wo_id, if (tworkorder.WO_CustWO is NULL, '', tworkorder.WO_CustWO) as WO_CustWO " & Environment.NewLine
                strSql &= "from tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "where tdevice.device_id = " & iDevice_ID & ";"
            Else                        'SUB Claims (NSC, RL)
                strSql = "select tdevice.device_id, tdevice.Model_ID, if (tdevice.device_sn is NULL, '', tdevice.device_sn) as Device_SN, if (tdevice.device_daterec is NULL, '', tdevice.device_daterec) as device_daterec, if (tdevice.device_datebill is NULL, '', tdevice.device_datebill) as device_datebill, if (tdevice.device_dateship is NULL, '', tdevice.device_dateship) as device_dateship, tdevice.wo_id, if (tworkorder.WO_CustWO is NULL, '', tworkorder.WO_CustWO) as WO_CustWO, if (tpallett.Pallett_ShipDate is NULL, '', tpallett.Pallett_ShipDate) as Pallett_ShipDate, tdevice.device_sendclaim " & Environment.NewLine
                strSql &= "from tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strSql &= "Left outer join tpallett on tdevice.pallett_id = tpallett.pallett_id " & Environment.NewLine
                strSql &= "where tdevice.device_id = " & iDevice_ID & ";"
            End If

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetWOInfoByDeviceID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'Delete billing summary
        '***************************************************
        Public Function DeleteBillingSummary(ByVal strDevice_IDs As String) As Integer
            Dim i As Integer = 0

            strSql = "Delete from sumbill where Device_ID in " & strDevice_IDs

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.DeleteBillingSummary: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function
        '***************************************************
        'This method gets all the device_sns that are yet to be shipped
        '***************************************************
        'Public Function GetDeviceSNsToBeShippedForWO(ByVal iCust_ID As Integer, ByVal iWO_ID As Integer) As DataTable

        '    strSql = "Select Device_ID, Device_SN " + Environment.NewLine
        '    strSql = strSql + "from tdevice inner join  tlocation on tdevice.loc_id = tlocation.loc_id " + Environment.NewLine
        '    strSql = strSql + "where " + Environment.NewLine
        '    strSql = strSql + "tlocation.cust_id = " & iCust_ID & " and " + Environment.NewLine
        '    strSql = strSql + "tdevice.wo_id = " & iWO_ID & " and " + Environment.NewLine
        '    strSql = strSql + "(tdevice.Device_Dateship is null or tdevice.Device_Dateship = '') and " + Environment.NewLine
        '    strSql = strSql + "(tdevice.device_datebill is not null or tdevice.device_datebill <> '') " + Environment.NewLine
        '    strSql = strSql + "Order By Device_SN;" + Environment.NewLine

        '    Try
        '        Return GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Data.GetSeviceSNsToBeShippedForWO: " & ex.Message.ToString)
        '    Finally
        '        strSql = ""
        '    End Try
        'End Function

        '***************************************************
        'Gets Num Of Devices In Pallett
        '***************************************************
        Public Function UpdateBillingSummary(ByVal idevice_id As Integer, _
                                            ByVal decAvgCost As Decimal, _
                                            ByVal decStdCost As Decimal, _
                                            ByVal decInvoiceAmt As Decimal, _
                                            ByVal iRUR As Integer, _
                                            ByVal iBER As Integer) As Integer

            strSql = "Replace into sumbill (Device_id, AvgCost, StdCost, InvoiceAmt, RUR, NER) " + Environment.NewLine
            strSql = strSql + "values (" & idevice_id & ", " & decAvgCost & ", " & decStdCost & ", " & decInvoiceAmt & ", " & iRUR & ", " & iBER & ");"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateBillingSummary: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'Gets Num Of Devices In Pallett
        '***************************************************
        Public Function GetBillingSummaryPerDevice(ByVal strDeviceIDs As String) As DataTable

            strSql = "select tdevicebill.device_id, " + Environment.NewLine
            strSql = strSql + "sum(dbill_avgcost) as AvgCost, " + Environment.NewLine
            strSql = strSql + "sum(dbill_stdcost) as StdCost, " + Environment.NewLine
            strSql = strSql + "sum(dbill_invoiceamt) as InvoiceAmt, " + Environment.NewLine
            strSql = strSql + "lbillcodes.billcode_rule " + Environment.NewLine

            strSql = strSql + "from tdevicebill inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " + Environment.NewLine

            strSql = strSql + "where tdevicebill.device_id in (" & strDeviceIDs & ") " + Environment.NewLine

            strSql = strSql + "group by tdevicebill.device_id; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetBillingSummaryPerDevice: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Gets Num Of Devices In Pallett
        '***************************************************
        '''Public Function GetNumOfDevicesInPallett(ByVal iPallett_ID As Integer) As DataTable

        '''    strSql = "select count(*) as DevicesInPallett " + vbCrLf
        '''    strSql = strSql + "from tdevice " + vbCrLf
        '''    strSql = strSql + "where pallett_id = " & iPallett_ID & ";"

        '''    'strSql = "select count(*) as DevicesInPallett " + vbCrLf
        '''    'strSql = strSql + "from tdevice inner join tpallett on tdevice.wo_id_out = tpallett.wo_id " + vbCrLf
        '''    'strSql = strSql + "where tpallett.pallett_id = " & iPallett_ID & " and " + vbCrLf
        '''    'strSql = strSql + "(tdevice.device_dateship is not NULL or tdevice.device_dateship <> ''); " + vbCrLf

        '''    Try
        '''        Return GetDataTable(strSql)
        '''    Catch ex As Exception
        '''        Throw New Exception("MotorolaSubcontract_Data.GetNumOfDevicesInPallett: " & ex.Message.ToString)
        '''    Finally
        '''        strSql = ""
        '''    End Try

        '''End Function

        '***************************************************
        'Get Device_IDs for a string of Ship_IDs
        '***************************************************
        Public Function GetAllDeviceIDsForShipIDs(ByVal strShipIDs As [String]) As DataTable

            strSql = "Select tdevice.device_id " + vbCrLf
            strSql = strSql + "from tdevice " + vbCrLf
            strSql = strSql + "where ship_id in " & strShipIDs & ";"
            'strShipIDs = (1,2,3,4) example
            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetAllDeviceIDsForShipIDs: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'This retrieves all devices_ids for a given Pallett
        '***************************************************
        Public Function GetAllShipIDsForPallett(ByVal iPallett_ID As Integer) As DataTable


            strSql = "Select tship.ship_id " + vbCrLf
            strSql = strSql + "from toverpack inner join tship on toverpack.overpack_id = tship.overpack_id " + vbCrLf
            strSql = strSql + "where toverpack.Pallett_ID = " & iPallett_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetAllShipIDsForPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'Gets the Device info.
        '***************************************************
        Public Function IsDeviceBilled(ByVal iDevice_ID As Integer) As DataTable


            strSql = "Select * from tdevice where device_id = " & iDevice_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.IsDeviceBilled: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'Delete a device
        '***************************************************
        Public Function DeleteDevice(ByVal iDevice_ID As String) As Integer

            Dim i As Integer = 0

            Try
                'Step1  (Delete from tdevicecodes
                strSql = "Delete from tdevicecodes " + vbCrLf
                strSql = strSql + "where Device_ID = " & iDevice_ID & ";"
                i = ExecuteNonQueries(strSql)

                'Step2
                i = 0
                strSql = ""
                strSql = "Delete from tcellopt " + vbCrLf
                strSql = strSql + "where Device_ID = " & iDevice_ID & ";"
                i = ExecuteNonQueries(strSql)

                'Step3
                i = 0
                strSql = ""
                strSql = "Delete from tdevice " + vbCrLf
                strSql = strSql + "where Device_ID = " & iDevice_ID & ";"
                i = ExecuteNonQueries(strSql)

                Return i

            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.DeleteDevice: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Retrieves the WO info
        '***************************************************
        Public Function GetWOInfo(ByVal iWO_ID As Integer) As DataTable

            strSql = "Select tworkorder.*, tlocation.cust_id " + vbCrLf
            strSql = strSql + "from tworkorder inner join tlocation on tworkorder.loc_id = tlocation.loc_id " + vbCrLf
            strSql = strSql + "where WO_ID = " & iWO_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetWOInfo: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'Set WO_Shipped field to 1 in tworkorder table
        '***************************************************
        Public Function ResetWOShipStatus(ByVal iWO_ID As Integer) As Integer

            strSql = "Update tworkorder " + vbCrLf
            strSql = strSql + "set WO_Shipped = 0, WO_DateShip = NULL " + vbCrLf
            strSql = strSql + "where WO_ID = " & iWO_ID & ";"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.ResetWOShipStatus: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'Retrieves the overpack info
        '***************************************************
        Public Function GetOverpackInfo(ByVal iOverpack_ID As Integer) As DataTable

            strSql = "Select toverpack.*, tpallett.Pallett_Shipdate " + vbCrLf
            strSql = strSql + "from toverpack inner join tpallett on toverpack.Pallett_ID = tpallett.Pallett_ID " + vbCrLf
            strSql = strSql + "where toverpack.overpack_id = " & iOverpack_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetOverpackInfo: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'This assigns a pallett when shipping partial palletts
        '***************************************************
        Public Function AssignPallett(ByVal iPallett_ID As Integer, _
                                        ByVal strOverpackIDs As String) As Integer

            strSql = "Update toverpack " + vbCrLf
            strSql = strSql + "set Pallett_ID = " & iPallett_ID & " " + vbCrLf
            strSql = strSql + "where Overpack_ID in (" & strOverpackIDs & "); "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.AssignPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'This unassigns a pallett when shipping partial palletts
        '***************************************************
        Public Function UnassignPallett(ByVal strOverpackIDs As String) As Integer
            strSql = "Update toverpack " + vbCrLf
            strSql = strSql + "set Pallett_ID = NULL " + vbCrLf
            strSql = strSql + "where Overpack_ID in (" & strOverpackIDs & "); "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UnassignPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'Get Device_ID for a Device_SN amd WO_ID
        '***************************************************
        Public Function GetDeviceInfoForMasterpack(ByVal iShip_ID As Integer) As DataTable

            strSql = "Select * " + vbCrLf
            strSql = strSql + "from tdevice " + vbCrLf
            strSql = strSql + "where Ship_id = " & iShip_ID

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetDeviceInfoForMasterpack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'Get Device_ID for a Device_SN amd WO_ID
        '***************************************************
        Public Function GetPallettIDforOverPack(ByVal iOverpack_ID As Integer) As DataTable

            strSql = "Select Pallett_ID " + vbCrLf
            strSql = strSql + "from toverpack " + vbCrLf
            strSql = strSql + "where overpack_id = " & iOverpack_ID

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetPallettIDforOverPack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This updates the tdevice tDEVICE TABE in the process of unshipping
        '***************************************************
        Public Function UnassignPallettShipDate(ByVal iPallett_ID As Integer) As Integer

            strSql = "Update tpallett " + vbCrLf
            strSql = strSql + "set pallett_shipdate = NULL " + vbCrLf
            strSql = strSql + "where Pallett_ID = " & iPallett_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UnassignPallettShipDate: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'This updates the tdevice tDEVICE TABE in the process of unshipping
        '***************************************************
        Public Function DeleteShipId(ByVal iShip_ID As Integer) As Integer

            strSql = "delete from tship " + vbCrLf
            strSql = strSql + "where Ship_ID = " & iShip_ID

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.DeleteShipId: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'This updates the tdevice tDEVICE TABE in the process of unshipping
        '***************************************************
        Public Function UnassignOverpackShipDate(ByVal iOverpack_ID As Integer) As Integer

            strSql = "Update toverpack " + vbCrLf
            strSql = strSql + "set OverPack_shipdate = NULL " + vbCrLf
            strSql = strSql + "where Overpack_ID = " & iOverpack_ID

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UnassignOverpackShipDate: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try


        End Function

        '***************************************************
        'Get Device_ID for a Device_SN amd WO_ID
        '***************************************************
        Public Function GetOverPackIDForShipID(ByVal iShip_ID As Integer) As DataTable

            strSql = "Select Overpack_ID " + vbCrLf
            strSql = strSql + "from tship " + vbCrLf
            strSql = strSql + "where Ship_ID = " & iShip_ID

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetOverPackIDForShipID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This updates the tdevice tDEVICE TABE in the process of unshipping
        '***************************************************
        Public Function ResetDeviceTable(ByVal iWO_ID As Integer, _
                                         ByVal iShip_ID As Integer) As Integer

            strSql = "Update tdevice " + vbCrLf
            strSql = strSql + "set device_dateship = NULL, " + vbCrLf
            strSql = strSql + "Wo_id_out = wo_id, " + vbCrLf        'Set the workoder out to its original workorder
            strSql = strSql + "Pallett_ID = NULL, " + vbCrLf
            strSql = strSql + "Device_ShipWorkDate = NULL, " + vbCrLf
            strSql = strSql + "Shift_ID_Ship = NULL, " + vbCrLf
            strSql = strSql + "Device_FinishedGoods = 0, " + vbCrLf
            strSql = strSql + "Ship_ID = NULL " + vbCrLf
            strSql = strSql + "where Ship_ID = " & iShip_ID & ";"

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateDeviceTable: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try


        End Function


        '***************************************************
        'Get Device_ID for a Device_SN amd WO_ID
        '***************************************************
        Public Function Get_DeviceID_For_Device_SN_and_Ship_ID(ByVal iShip_ID As Integer, _
                                                            ByVal strDeviceSN As String) As DataTable

            strSql = "Select Device_ID " + vbCrLf
            strSql = strSql + "from tdevice " + vbCrLf
            strSql = strSql + "where Device_SN = '" & strDeviceSN & "' and " + vbCrLf
            strSql = strSql + "Ship_ID = " & iShip_ID & "; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.Get_DeviceID_For_Device_SN_and_Ship_ID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Get all devices for a Workorder
        '***************************************************
        Public Function GetAllDeviceIDsForShipID(ByVal iShip_ID As Integer) As DataTable

            strSql = "Select Device_ID " + vbCrLf
            strSql = strSql + "from tdevice " + vbCrLf
            strSql = strSql + "where ship_id = " & iShip_ID & " Order by Device_ID; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetAllDeviceIDsForShipID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Get all devices for a Workorder
        '***************************************************
        'Public Function GetAllDevicesForWO(ByVal iWO_ID As Integer) As DataTable
        '    'select Device_id, WO_ID, wo_id_out from tdevice where wo_id = 60496 and wo_id_out = 60496
        '    strSql = "Select Device_ID " + vbCrLf
        '    strSql = strSql + "from tdevice " + vbCrLf
        '    strSql = strSql + "where wo_id = " & iWO_ID & " and " + vbCrLf
        '    strSql = strSql + "wo_id_out = " & iWO_ID & "; "

        '    Try
        '        Return GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Data.GetAllDevicesForWO: " & ex.Message.ToString)
        '    Finally
        '        strSql = ""
        '    End Try
        'End Function

        '***************************************************
        'This updates the repair status
        '***************************************************
        Public Function UpdateRepairStatus(ByVal iDevice_ID As Integer, ByVal iDeviceCode_ID As Integer, _
                                                ByVal iDcode_ID As String) As Integer
            Dim i As Integer

            Try
                '*************************************************
                'Update tdevicecodes
                '*************************************************
                If iDeviceCode_ID = 0 Then
                    strSql = "Insert into tdevicecodes " + vbCrLf
                    strSql = strSql + "(Device_ID, DCode_ID) " + vbCrLf
                    strSql = strSql + "values (" & iDevice_ID & ", " & iDcode_ID & "); "
                Else
                    strSql = "Update tdevicecodes " + vbCrLf
                    strSql = strSql + "SET DCode_ID = " & iDcode_ID & " " + vbCrLf
                    strSql = strSql + "where DeviceCode_ID = " & iDeviceCode_ID & "; "
                End If

                i = ExecuteNonQueries(strSql)
                '*************************************************
                'Update tdevice 
                '*************************************************
                strSql = ""
                strSql = "Update tdevice set device_sendclaim = 0 where device_id = " & iDevice_ID & ";"

                Return ExecuteNonQueries(strSql)
                '*************************************************
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateRepairStatus: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Get the devicecode_ID for RepairStaus Code
        '***************************************************
        Public Function GetDeviceCodeID(ByVal iDevice_ID As Integer) As DataTable

            strSql = "Select tdevicecodes.* " + vbCrLf
            strSql = strSql + "from ((tdevicecodes " + vbCrLf
            strSql = strSql + "inner join lcodesdetail on tdevicecodes.dcode_id = lcodesdetail.dcode_id) " + vbCrLf
            strSql = strSql + "inner join lcodesmaster on lcodesdetail.mcode_id = lcodesmaster.mcode_id) " + vbCrLf

            strSql = strSql + "where tdevicecodes.device_id = " & iDevice_ID & " and " + vbCrLf
            strSql = strSql + "lcodesmaster.mcode_id = 10; "        '10 for Repair Status Code

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetDeviceCodeID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function


        '***************************************************
        'This assigns the pallett a ship date
        '***************************************************
        Public Function AssignShipDateToPallett(ByVal iPallett_ID As Integer, _
                                                ByVal strShipDate As String) As Integer
            strSql = "Update tpallett " + vbCrLf
            strSql = strSql + "set pallett_shipdate = '" & strShipDate & "' " + vbCrLf
            strSql = strSql + "where Pallett_ID = " & iPallett_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.AssignShipDateToPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try


        End Function

        '***************************************************
        'Flags the work order ready to be shipped
        '***************************************************
        Public Function SetWOReadyToBeShipped(ByVal iWO_ID As Integer, ByVal strShipDt As String) As Integer
            strSql = "Update tworkorder " + vbCrLf
            strSql = strSql + "set WO_Shipped = 1, WO_DateShip = '" + strShipDt + "' " + vbCrLf
            strSql = strSql + "where WO_ID = " & iWO_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.SetWOReadyToBeShipped: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Get Num Of Devices Shipped For WO          (R("WO_ID"))
        '***************************************************
        Public Function GetNumOfDevicesShippedForWO(ByVal iWO_ID As Integer) As DataTable
            strSql = "select Count(*) as DevicesShipped " + vbCrLf
            strSql = strSql + "from tdevice " + vbCrLf
            strSql = strSql + "where WO_ID_Out = " & iWO_ID & " and " + vbCrLf
            strSql = strSql + "Ship_ID is not NULL;"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetNumOfDevicesShippedForWO: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the Number of devices to be shipped in a work order
        '***************************************************
        '''Public Function GetNumOfDevicesToBeShippedForWO(ByVal iWO_ID As Integer) As DataTable
        '''    strSql = "select Count(*) as NumOfDevicestoBeShipped " + vbCrLf
        '''    strSql = strSql + "from tdevice " + vbCrLf
        '''    strSql = strSql + "where WO_ID = " & iWO_ID & " and " + vbCrLf
        '''    strSql = strSql + "Ship_ID is NULL; "
        '''    'strSql = strSql + "WO_ID_Out is NULL and device_dateship is NULL; "

        '''    Try
        '''        Return GetDataTable(strSql)
        '''    Catch ex As Exception
        '''        Throw New Exception("MotorolaSubcontract_Data.GetNumOfDevicesToBeShippedForWO: " & ex.Message.ToString)
        '''    Finally
        '''        strSql = ""
        '''    End Try
        '''End Function

        '***************************************************
        'This assigns the overpack a ship date
        '***************************************************
        Public Function DeletePallett(ByVal iPallett_ID As Integer) As Integer

            strSql = "Delete from tpallett where Pallett_ID = " & iPallett_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.DeletePallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This assigns the overpack a ship date
        '***************************************************
        Public Function DeleteOverpack(ByVal iOverPack_ID As Integer) As Integer

            strSql = "Delete from toverpack where OverPack_ID = " & iOverPack_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.DeleteOverpack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This assigns the overpack a ship date
        '***************************************************
        Public Function AssignShipDateToOverPack(ByVal iOverPack_ID As Integer, _
                                                ByVal strShipDate As String) As Integer
            strSql = "Update toverpack " + vbCrLf
            strSql = strSql + "set overpack_shipdate = '" & strShipDate & "' " + vbCrLf
            strSql = strSql + "where OverPack_ID = " & iOverPack_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.AssignShipDateToOverPack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'This gets the no of Masterpacks for an Overpack
        '***************************************************
        Public Function GetNumOfOverPacksForPallett(ByVal iPallett_ID As Integer) As DataTable
            strSql = "select Count(*) as NumOfOverPacks " + vbCrLf
            strSql = strSql + "from toverpack " + vbCrLf
            strSql = strSql + "where Pallett_ID = " & iPallett_ID & "; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetNumOfOverPacksForPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the no of Masterpacks for an Overpack
        '***************************************************
        Public Function GetNumOfDevicesForPallett(ByVal iPallett_ID As Integer) As DataTable
            strSql = "select Count(*) as NumOfDevices " + vbCrLf
            strSql = strSql + "from tdevice " + vbCrLf
            strSql = strSql + "where Pallett_ID = " & iPallett_ID & "; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetNumOfDevicesForPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the no of Masterpacks for an Overpack
        '***************************************************
        Public Function GetNumOfMasterPacksForOverPack(ByVal iOverPack_ID As Integer) As DataTable
            strSql = "select Count(*) as NumOfMasterPacks " + vbCrLf
            strSql = strSql + "from tship " + vbCrLf
            strSql = strSql + "where OverPack_ID = " & iOverPack_ID & "; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetNumOfMasterPacksForOverPack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'Update Device table
        '***************************************************
        'Change the Default for iFinishedGoodsFlg to 0 when this has to be 
        'Done in a process else where. - Asif 04-13-2006
        Public Function UpdateDeviceTable(ByVal iDevice_ID As Integer, _
                                            ByVal iWO_ID As Integer, _
                                            ByVal iShip_ID As Integer, _
                                            ByVal strShipDate As String, _
                                            ByVal iPallett_ID As Integer, _
                                            ByVal iShiftID As Integer, _
                                            ByVal strWorkDate As String, _
                                            Optional ByVal iFinishedGoodsFlg As Integer = 1) As Integer
            strSql = "Update tdevice " + vbCrLf
            strSql = strSql + "set Ship_ID = " & iShip_ID & ", " + vbCrLf
            strSql = strSql + "Pallett_ID = " & iPallett_ID & ", " + vbCrLf
            strSql = strSql + "Shift_ID_Ship = " & iShiftID & ", " + vbCrLf
            strSql = strSql + "Device_SendClaim = 0, " + vbCrLf
            strSql = strSql + "Device_DateShip = '" & strShipDate & "', " + vbCrLf
            strSql = strSql + "Device_ShipWorkDate = '" & strWorkDate & "', " + vbCrLf
            strSql = strSql + "WO_ID_Out = " & iWO_ID & ", " + vbCrLf
            strSql = strSql + "Device_FinishedGoods = " & iFinishedGoodsFlg & " " + vbCrLf
            strSql = strSql + "where device_id = " & iDevice_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateDeviceTable: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try


        End Function

        'Public Function UpdateDeviceTable(ByVal strDevice_SN As String, _
        '                                    ByVal iWO_ID As Integer, _
        '                                    ByVal iSKU_ID As Integer, _
        '                                    ByVal iShip_ID As Integer, _
        '                                    ByVal strShipDate As String, _
        '                                    ByVal iPallett_ID As Integer) As Integer
        'Public Function UpdateDeviceTable(ByVal iDevice_ID As Integer, _
        '                                    ByVal iWO_ID As Integer, _
        '                                    ByVal iSKU_ID As Integer, _
        '                                    ByVal iShip_ID As Integer, _
        '                                    ByVal strShipDate As String, _
        '                                    ByVal iPallett_ID As Integer, _
        '                                    ByVal iShiftID As Integer, _
        '                                    ByVal strWorkDate As String) As Integer
        '    strSql = "Update tdevice " + vbCrLf

        '    strSql = strSql + "set Ship_ID = " & iShip_ID & ", " + vbCrLf
        '    strSql = strSql + "Pallett_ID = " & iPallett_ID & ", " + vbCrLf
        '    strSql = strSql + "Shift_ID_Ship = " & iShiftID & ", " + vbCrLf
        '    strSql = strSql + "Device_SendClaim = 0, " + vbCrLf
        '    strSql = strSql + "Device_DateShip = '" & strShipDate & "', " + vbCrLf
        '    strSql = strSql + "Device_ShipWorkDate = '" & strWorkDate & "', " + vbCrLf
        '    strSql = strSql + "WO_ID_Out = " & iWO_ID & " " + vbCrLf

        '    strSql = strSql + "where device_id = " & iDevice_ID & "; "

        '    'strSql = strSql + "where Device_SN = '" & strDevice_SN & "' and " + vbCrLf
        '    'strSql = strSql + "SKU_ID = " & iSKU_ID & "; "

        '    Try
        '        Return ExecuteNonQueries(strSql)
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Data.UpdateDeviceTable: " & ex.Message.ToString)
        '    Finally
        '        strSql = ""
        '    End Try


        'End Function

        '***************************************************
        'Update the Ship_Date in tship table
        '***************************************************
        Public Function UpdateShipDate(ByVal iShip_ID As Integer, ByVal strShipDate As String) As Integer
            strSql = "Update tship " + vbCrLf
            strSql = strSql + "set Ship_Date = '" & strShipDate & "' " + vbCrLf
            strSql = strSql + "where Ship_ID = " & iShip_ID & "; "

            Try
                Return ExecuteNonQueries(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.UpdateShipDate: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the OverPack_ID
        '***************************************************
        Public Function GetMasterPackID(ByVal iOverPack_ID As Integer) As DataTable
            strSql = "select Ship_ID " + vbCrLf
            strSql = strSql + "from tship " + vbCrLf
            strSql = strSql + "where OverPack_ID = " & iOverPack_ID & " and " + vbCrLf
            strSql = strSql + "(ship_date is NULL or ship_date = ''); "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetMasterPackID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'This create a new MasterPack
        '***************************************************
        'Public Function CreateNewMasterPack(ByVal iOverPack_ID As Integer) As Integer
        Public Function CreateNewMasterPack(ByVal strUser As String, _
                                            ByVal iProd_ID As Integer, _
                                            ByVal iOverPack_ID As Integer, _
                                            ByVal iShipTo_ID As Integer) As Integer
            strSql = "insert into tship " + vbCrLf
            strSql = strSql + "(ship_user, Prod_ID, OverPack_ID, ShipTo_ID) " + vbCrLf
            strSql = strSql + "values ('" & strUser & "', " & iProd_ID & ", " & iOverPack_ID & ", " & iShipTo_ID & "); "

            Try
                'Return ExecuteNonQueries(strSql)
                Return idTransaction(strSql, "tship")
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.CreateNewMasterPack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the OverPack_ID
        '***************************************************
        Public Function GetOverPackID(ByVal iPallett_ID As Integer, ByVal iOverpack_Process As Integer) As DataTable
            strSql = "select OverPack_ID, '' as MasterPacks " + vbCrLf
            strSql = strSql + "from toverpack " + vbCrLf
            strSql = strSql + "where Pallett_ID = " & iPallett_ID & " and " + vbCrLf
            strSql = strSql + "Overpack_Process = " & iOverpack_Process & " and " + vbCrLf
            strSql = strSql + "(OverPack_shipdate is NULL or OverPack_shipdate = ''); "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetOverPackID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'This create a new Overpack
        '***************************************************
        Public Function CreateNewOverPack(ByVal iPallett_ID As Integer, ByVal iOverpack_Process As Integer) As Integer
            strSql = "insert into toverpack " + vbCrLf
            strSql = strSql + "(Pallett_ID, Overpack_Process) " + vbCrLf
            strSql = strSql + "values (" & iPallett_ID & ", " & iOverpack_Process & "); "

            Try
                'Return ExecuteNonQueries(strSql)
                Return idTransaction(strSql, "toverpack")
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.CreateNewOverPack: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '***************************************************
        'This gets the Pallett_ID
        '***************************************************
        Public Function GetPallettID(ByVal iWO_ID As Integer) As DataTable
            strSql = "select Pallett_ID " + vbCrLf
            'strSql = "select IF (tpallett.Pallett_ID IS NULL, 0, tpallett.Pallett_ID) as Pallett_ID " + vbCrLf
            strSql = strSql + "from tpallett " + vbCrLf
            strSql = strSql + "where WO_ID = " & iWO_ID & " and " + vbCrLf
            strSql = strSql + "(pallett_shipdate is NULL or pallett_shipdate = ''); "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetPallettID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This create a new Pallett
        '***************************************************
        Public Function CreateNewPallett(ByVal iWO_ID As Integer, _
                                        ByVal iLOC_ID As Integer) As Int32
            strSql = "insert into tpallett " + vbCrLf
            strSql = strSql + "(WO_ID, LOC_ID) " + vbCrLf
            strSql = strSql + "values (" & iWO_ID & ", " & iLOC_ID & "); "

            Try
                'Return ExecuteNonQueries(strSql)
                Return idTransaction(strSql, "tpallett")
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.CreateNewPallett: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the LOC_ID
        '***************************************************
        Public Function GetLOCID(ByVal iWO_ID As Integer) As DataTable
            strSql = "select Loc_ID, WO_Quantity, ShipTo_ID " + vbCrLf
            strSql = strSql + "from tworkorder " + vbCrLf
            strSql = strSql + "where WO_ID = " & iWO_ID & "; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetLOCID: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This retrives some Shipping info
        '***************************************************
        'Public Function GetShipingInfo(ByVal iWO_ID As Integer) As DataTable

        '    strSql = "select IF (tpallett.Pallett_ID IS NULL, 0, tpallett.Pallett_ID) as Pallett_ID, " + vbCrLf
        '    strSql = strSql + "IF (toverpack.overpack_id IS NULL, 0, toverpack.overpack_id) as OverPack_ID, " + vbCrLf
        '    strSql = strSql + "IF (tworkorder.LOC_ID IS NULL, 0, tworkorder.LOC_ID) as LOC_ID " + vbCrLf

        '    strSql = strSql + "from ((tworkorder " + vbCrLf
        '    strSql = strSql + "left outer join tpallett on tworkorder.WO_ID = tpallett.WO_ID) " + vbCrLf
        '    strSql = strSql + "left outer join toverpack on tpallett.Pallett_ID = toverpack.Pallett_ID) " + vbCrLf

        '    strSql = strSql + "where tworkorder.WO_ID = " & iWO_ID & " and " + vbCrLf
        '    strSql = strSql + "(tpallett.Pallett_shipdate is NULL or tpallett.pallett_shipdate = '') and " + vbCrLf
        '    strSql = strSql + "(toverpack.overpack_shipdate is NULL or toverpack.overpack_shipdate = ''); "

        '    Try
        '        Return GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        strSql = ""
        '    End Try
        'End Function

        '***************************************************
        'GetDeviceSNsForWO
        '***************************************************
        'Commented out by Asif on 01/19/2006
        'Public Function GetDeviceSNsForWO(ByVal iWO_ID As Integer) As DataTable
        '    strSql = "SELECT DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule " + vbCrLf
        '    strSql = strSql + "FROM tdevice " + vbCrLf
        '    strSql = strSql + "inner join tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " + vbCrLf
        '    strSql = strSql + "inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " + vbCrLf
        '    strSql = strSql + "where tdevice.wo_ID = " & iWO_ID & " and " + vbCrLf
        '    strSql = strSql + "(tdevice.device_datebill is not NULL or tdevice.device_datebill <> '') " + vbCrLf
        '    strSql = strSql + "Order By tdevice.Device_ID; "

        '    Try
        '        Return GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Data.GetDeviceSNsForSKU: " & ex.Message.ToString)
        '    Finally
        '        strSql = ""
        '    End Try
        'End Function

        Public Function GetSNsForWOBasedShipping(ByVal iWO_ID As Integer, _
                                                ByVal iGroup_ID As Integer) As DataTable


            strSql = "Select DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule, tdevice.wo_id, '' as HEX, tdevice.model_id " + vbCrLf
            strSql = strSql + "FROM tdevice " + vbCrLf
            strSql = strSql + "inner join tworkorder ON tdevice.wo_ID = tworkorder.wo_ID " + vbCrLf
            strSql = strSql + "inner join tlocation on tdevice.loc_id = tlocation.loc_id " + vbCrLf
            strSql = strSql + "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " + vbCrLf
            strSql = strSql + "inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " + vbCrLf
            strSql = strSql + "where tdevice.WO_ID = " & iWO_ID & " and " + vbCrLf
            strSql = strSql + "tworkorder.Group_ID = " & iGroup_ID & " and " + vbCrLf
            strSql = strSql + "(tdevice.device_datebill is not NULL and tdevice.device_datebill <> '' and tdevice.device_datebill <> '0000-00-00 00:00:00') and " + vbCrLf
            strSql = strSql + "(tdevice.device_dateship is NULL or tdevice.device_dateship = '') " + vbCrLf
            strSql = strSql + "Order By tdevice.Device_ID, lbillcodes.billcode_rule desc; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetSNsForWOBasedShipping: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        '***************************************************
        'Get Model_ID by wo_id
        '***************************************************
        Public Function GetModelIDbyWO(ByVal iWO_ID As Integer) As DataTable

            strSql = "Select DISTINCT Model_ID from tdevice where wo_id = " & iWO_ID & ";" & vbCrLf

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetModelIDbyWO: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try


        End Function
        '***************************************************
        'Get Device SNs For ATCLE Shipping
        '***************************************************
        '''Public Function GetDeviceSNsForATCLEShipping(ByVal iCust_ID As Integer, _
        '''                                            ByVal iModel_id As Integer) As DataTable


        '''    strSql = "Select DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule, tdevice.wo_id, '' as HEX, tdevice.model_id " + vbCrLf
        '''    strSql = strSql + "FROM tdevice " + vbCrLf
        '''    strSql = strSql + "inner join tlocation on tdevice.loc_id = tlocation.loc_id " + vbCrLf
        '''    strSql = strSql + "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " + vbCrLf
        '''    strSql = strSql + "inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " + vbCrLf
        '''    strSql = strSql + "where tlocation.cust_ID = " & iCust_ID & " and " + vbCrLf    'ATCLE-AWS cust location
        '''    strSql = strSql + "tdevice.model_id = " & iModel_id & " and " + vbCrLf    'ATCLE-AWS cust location; 789 for testing
        '''    strSql = strSql + "(tdevice.device_datebill is not NULL and tdevice.device_datebill <> '' and tdevice.device_datebill <> '0000-00-00 00:00:00') and " + vbCrLf
        '''    strSql = strSql + "(tdevice.device_dateship is NULL or tdevice.device_dateship = '') " + vbCrLf
        '''    strSql = strSql + "Order By tdevice.Device_ID; "

        '''    Try
        '''        Return GetDataTable(strSql)
        '''    Catch ex As Exception
        '''        Throw New Exception("MotorolaSubcontract_Data.GetDeviceSNsForATCLEShipping: " & ex.Message.ToString)
        '''    Finally
        '''        strSql = ""
        '''    End Try

        '''End Function

        Public Function GetSNsForModelBasedShipping(ByVal iLoc_ID As Integer, _
                                                    ByVal iModel_id As Integer, _
                                                    ByVal iGroup_ID As Integer, _
                                                    Optional ByVal strShortLongFlg As String = "") _
                                                    As DataTable

            strSql = "Select DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule, tdevice.wo_id, '' as HEX, tdevice.model_id " + vbCrLf
            strSql = strSql + "FROM tdevice " + vbCrLf
            strSql = strSql + "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " + vbCrLf
            strSql = strSql + "inner join tsku on tdevice.sku_id = tsku.sku_id " + vbCrLf
            strSql = strSql + "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " + vbCrLf
            strSql = strSql + "inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " + vbCrLf
            strSql = strSql + "where tdevice.loc_id = " & iLoc_ID & " and " + vbCrLf
            strSql = strSql + "tdevice.model_id = " & iModel_id & " and " + vbCrLf
            strSql = strSql + "tworkorder.group_id = " & iGroup_ID & " and " + vbCrLf
            If Len(strShortLongFlg) > 0 Then
                'strSql += "INSTR(trim(wo_custwo), '{') > 0 and " & Environment.NewLine
                'strSql += "SUBSTRING(trim(wo_custwo),(INSTR(trim(wo_custwo), '{') + 1),1) = '" & strShortLongFlg & "' and " & Environment.NewLine
                If UCase(Trim(strShortLongFlg)) = "S" Then
                    strSql += "length(tsku.Sku_Number) >= 1 and length(tsku.Sku_Number) <= 5 and " & Environment.NewLine        'Short SKU definition
                ElseIf UCase(Trim(strShortLongFlg)) = "L" Then
                    strSql += "length(tsku.Sku_Number) >= 6 and length(tsku.Sku_Number) <= 15 and " & Environment.NewLine       'Long SKU definition
                End If
            End If
            strSql = strSql + "(tdevice.device_datebill is not NULL and tdevice.device_datebill <> '' and tdevice.device_datebill <> '0000-00-00 00:00:00') and " + vbCrLf
            strSql = strSql + "(tdevice.device_dateship is NULL or tdevice.device_dateship = '') " + vbCrLf
            strSql = strSql + "Order By tdevice.Device_ID, lbillcodes.billcode_rule desc; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetSNsForModelBasedShipping: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function
        '***************************************************




        '***************************************************
        'Get DeviceSNs For SKU
        '***************************************************
        '''Public Function GetDeviceSNsForSKU(ByVal iSKU_ID As Integer) As DataTable

        '''    strSql = "SELECT DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule, '' as HEX, tdevice.model_id " + vbCrLf
        '''    strSql = strSql + "FROM tdevice " + vbCrLf
        '''    strSql = strSql + "inner join tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " + vbCrLf
        '''    strSql = strSql + "inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " + vbCrLf
        '''    strSql = strSql + "where tdevice.sku_ID = " & iSKU_ID & " and " + vbCrLf
        '''    strSql = strSql + "(tdevice.device_datebill is not NULL and tdevice.device_datebill <> '') and " + vbCrLf
        '''    strSql = strSql + "(tdevice.device_dateship is NULL or tdevice.device_dateship = '') " + vbCrLf
        '''    strSql = strSql + "Order By tdevice.Device_ID; "

        '''    Try
        '''        Return GetDataTable(strSql)
        '''    Catch ex As Exception
        '''        Throw New Exception("MotorolaSubcontract_Data.GetDeviceSNsForSKU: " & ex.Message.ToString)
        '''    Finally
        '''        strSql = ""
        '''    End Try
        '''End Function

        Public Function GetSNsForSKUBasedShipping(ByVal iSKU_ID As Integer, _
                                                    ByVal iGroup_ID As Integer) As DataTable

            strSql = "SELECT DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule, '' as HEX, tdevice.model_id " + vbCrLf
            strSql = strSql + "FROM tdevice " + vbCrLf
            strSql = strSql + "inner join tworkorder ON tdevice.wo_ID = tworkorder.wo_ID " + vbCrLf
            strSql = strSql + "inner join tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " + vbCrLf
            strSql = strSql + "inner join lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " + vbCrLf
            strSql = strSql + "where tdevice.sku_ID = " & iSKU_ID & " and " + vbCrLf
            strSql = strSql + "tworkorder.Group_ID = " & iGroup_ID & " and " + vbCrLf
            strSql = strSql + "(tdevice.device_datebill is not NULL and tdevice.device_datebill <> '') and " + vbCrLf
            strSql = strSql + "(tdevice.device_dateship is NULL or tdevice.device_dateship = '') " + vbCrLf
            strSql = strSql + "Order By tdevice.Device_ID, lbillcodes.billcode_rule desc; "

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetSNsForSKUBasedShipping: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the device serial numbers for a WO
        '***************************************************
        'Public Function GetDeviceSNsForWO(ByVal iWO_ID As Integer) As DataTable

        '    strSql = "SELECT DISTINCT tdevice.Device_ID, tdevice.Device_SN, lbillcodes.billcode_rule " + vbCrLf
        '    strSql = strSql + "FROM ((tdevice " + vbCrLf
        '    strSql = strSql + "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID) " + vbCrLf
        '    strSql = strSql + "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) " + vbCrLf
        '    strSql = strSql + "where tdevice.WO_ID = " & iWO_ID & " and " + vbCrLf
        '    strSql = strSql + "tdevice.WO_ID_Out is NULL and tdevice.device_datebill is not NULL Order By tdevice.Device_ID; "

        '    Try
        '        Return GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Data.GetDeviceSNsForWO: " & ex.Message.ToString)
        '    Finally
        '        strSql = ""
        '    End Try


        'End Function

        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        Public Function GetAllCustomers() As DataTable
            strSql = "select Cust_ID, cust_name1 " + vbCrLf
            strSql = strSql + "from tcustomer Order by Cust_Name1; "
            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetAllCustomers: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        Public Function GetAllLocations() As DataTable
            strSql = "select Loc_ID, Loc_Name " + vbCrLf
            strSql = strSql + "from tlocation; "
            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetAllLocations: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This gets the customer info for a given customer
        '***************************************************
        Public Function GetCustInfo(ByVal iCust_ID As Integer) As DataTable
            strSql = "select tcustomer.cust_id, tcustomer.cust_name1, tlocation.Loc_Address1, " + vbCrLf
            strSql = strSql + "tlocation.Loc_Address2, tlocation.Loc_City, lstate.state_short, tlocation.Loc_Zip " + vbCrLf
            strSql = strSql + "from tcustomer " + vbCrLf
            strSql = strSql + "inner join tlocation on tcustomer.cust_id = tlocation.cust_id " + vbCrLf
            strSql = strSql + "inner join lstate on tlocation.state_id = lstate.state_id " + vbCrLf
            strSql = strSql + "where tcustomer.cust_id = " & iCust_ID & ";"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetCustInfo: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        Public Function GetGroups() As DataTable

            strSql = "Select * from lgroups;"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetGroups: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function

        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        'Public Function GetCustomers(Optional ByVal iCust_ID As Integer = 0) As DataTable
        Public Function GetCustomers() As DataTable

            strSql = "select distinct tcustomer.cust_id, cust_name1 " & Environment.NewLine
            strSql += "from tdevice " & Environment.NewLine
            strSql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
            strSql += "inner join tlocation on tworkorder.loc_id = tlocation.loc_id " & Environment.NewLine
            strSql += "inner join tcustomer on tlocation.cust_id = tcustomer.Cust_ID " & Environment.NewLine
            'strSql += "where device_dateship is NULL and tworkorder.prod_id = 2 and " & Environment.NewLine
            strSql += "where tworkorder.prod_id = 2 and " & Environment.NewLine
            strSql += "tcustomer.cust_name2 is null and tcustomer.Cust_Inactive = 0 " & Environment.NewLine
            strSql += "Order by Cust_Name1 " & Environment.NewLine
            strSql += ";"

            'If iCust_ID = 0 Then
            'strSql = "select tcustomer.cust_id, tcustomer.cust_name1 " + vbCrLf
            'strSql = strSql + "from tcustomer " + vbCrLf
            'strSql = strSql + "where tcustomer.cust_id in (1403, 2019, 2058, 2069, 2127, 2106); "
            'Else
            'strSql = "select tcustomer.cust_id, tcustomer.cust_name1, tlocation.Loc_Address1, " + vbCrLf
            'strSql = strSql + "tlocation.Loc_Address2, tlocation.Loc_City, lstate.state_short, tlocation.Loc_Zip " + vbCrLf
            'strSql = strSql + "from tcustomer " + vbCrLf
            'strSql = strSql + "inner join tlocation on tcustomer.cust_id = tlocation.cust_id " + vbCrLf
            'strSql = strSql + "inner join lstate on tlocation.state_id = lstate.state_id " + vbCrLf
            'strSql = strSql + "where tcustomer.cust_id = 1844; "    'Motorola-RL
            'End If

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetCustomers: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try
        End Function
        '****************************************************************************
        'This gets the RMA grid data from the database
        '****************************************************************************
        'Commented by Asif on 01/19/2006
        ''''Public Function GetRMAGridData_ATCLE(ByVal iCust_ID As Integer, _
        ''''                                Optional ByVal iLoc_ID As Integer = 0) As DataTable

        ''''    'strSql = "select * from lcodesmaster; "

        ''''    strSql = "select distinct" + vbCrLf
        ''''    strSql = strSql + "tworkorder.WO_CustWO as RMANumber, " + vbCrLf
        ''''    strSql = strSql + "tmodel.model_desc as Model, " + vbCrLf
        ''''    strSql = strSql + "'' as SKUNumber, " + vbCrLf
        ''''    strSql = strSql + "tworkorder.WO_Quantity, " + vbCrLf
        ''''    strSql = strSql + "tworkorder.WO_RAQnty as RMA_Quantity, " + vbCrLf
        ''''    strSql = strSql + "'' as DevicesReceived, " + vbCrLf
        ''''    strSql = strSql + "'' as DevicesToBeShipped, " + vbCrLf
        ''''    strSql = strSql + "tpreloadwodata.plwodata_DockDate as DockDate, " + vbCrLf
        ''''    strSql = strSql + "tworkorder.WO_IP as IP, " + vbCrLf
        ''''    strSql = strSql + "tworkorder.WO_PRL as PRL, " + vbCrLf
        ''''    strSql = strSql + "tworkorder.WO_ID, " + vbCrLf
        ''''    strSql = strSql + "0 as SKU_ID " + vbCrLf

        ''''    strSql = strSql + "from " + vbCrLf
        ''''    strSql = strSql + "tworkorder " + vbCrLf
        ''''    strSql = strSql + "inner join tdevice on tworkorder.WO_ID = tdevice.WO_ID " + vbCrLf
        ''''    strSql = strSql + "inner join tmodel on tdevice.model_id = tmodel.model_id " + vbCrLf
        ''''    'strSql = strSql + "inner join tsku on tdevice.SKU_ID = tsku.SKU_ID " + vbCrLf
        ''''    strSql = strSql + "inner join tlocation on tdevice.LOC_ID = tlocation.LOC_ID " + vbCrLf
        ''''    strSql = strSql + "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " + vbCrLf
        ''''    strSql = strSql + "left outer join tpreloadwodata on tworkorder.WO_ID = tpreloadwodata.WO_ID " + vbCrLf

        ''''    strSql = strSql + "where " + vbCrLf
        ''''    strSql = strSql + "tcustomer.Cust_ID = " & iCust_ID & " and " & vbCrLf

        ''''    If iLoc_ID <> 0 Then
        ''''        strSql = strSql + "tlocation.Loc_ID = " & iLoc_ID & " and " & vbCrLf
        ''''    End If

        ''''    strSql = strSql + "tworkorder.WO_Shipped = 0 " & vbCrLf
        ''''    strSql = strSql + "Order BY tworkorder.WO_Date Asc;"

        ''''    Try
        ''''        Return GetDataTable(strSql)
        ''''    Catch ex As Exception
        ''''        Throw New Exception("MotorolaSubcontract_Data.GetRMAGridData_ATCLE: " & ex.Message.ToString)
        ''''    Finally
        ''''        strSql = ""
        ''''    End Try

        ''''End Function

        '****************************************************************************
        'This gets the RMA grid data from the database
        '****************************************************************************
        'Commented by Asif on 01/19/2006
        '''''Public Function GetRMAGridData_MotorolaNSC(ByVal iCust_ID As Integer, _
        '''''                                Optional ByVal iLoc_ID As Integer = 0) As DataTable

        '''''    'strSql = "select * from lcodesmaster; "

        '''''    strSql = "select distinct" + vbCrLf
        '''''    strSql = strSql + "tworkorder.WO_CustWO as RMANumber, " + vbCrLf
        '''''    strSql = strSql + "tmodel.model_desc as Model, " + vbCrLf
        '''''    strSql = strSql + "tsku.SKU_Number as SKUNumber, " + vbCrLf
        '''''    strSql = strSql + "tworkorder.WO_Quantity, " + vbCrLf
        '''''    strSql = strSql + "tworkorder.WO_RAQnty as RMA_Quantity, " + vbCrLf
        '''''    strSql = strSql + "'' as DevicesReceived, " + vbCrLf
        '''''    strSql = strSql + "'' as DevicesToBeShipped, " + vbCrLf
        '''''    strSql = strSql + "tpreloadwodata.plwodata_DockDate as DockDate, " + vbCrLf
        '''''    strSql = strSql + "tworkorder.WO_IP as IP, " + vbCrLf
        '''''    strSql = strSql + "tworkorder.WO_PRL as PRL, " + vbCrLf
        '''''    strSql = strSql + "tworkorder.WO_ID, " + vbCrLf
        '''''    strSql = strSql + "tsku.SKU_ID as SKU_ID " + vbCrLf
        '''''    'strSql = strSql + "tworkorder.WO_Date " + vbCrLf

        '''''    strSql = strSql + "from " + vbCrLf
        '''''    strSql = strSql + "tworkorder " + vbCrLf
        '''''    strSql = strSql + "inner join tdevice on tworkorder.WO_ID = tdevice.WO_ID " + vbCrLf
        '''''    strSql = strSql + "inner join tmodel on tdevice.model_id = tmodel.model_id " + vbCrLf
        '''''    strSql = strSql + "inner join tsku on tdevice.SKU_ID = tsku.SKU_ID " + vbCrLf
        '''''    strSql = strSql + "inner join tlocation on tdevice.LOC_ID = tlocation.LOC_ID " + vbCrLf
        '''''    strSql = strSql + "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " + vbCrLf
        '''''    strSql = strSql + "left outer join tpreloadwodata on tworkorder.WO_ID = tpreloadwodata.WO_ID " + vbCrLf

        '''''    strSql = strSql + "where " + vbCrLf
        '''''    strSql = strSql + "tcustomer.Cust_ID = " & iCust_ID & " and " & vbCrLf

        '''''    If iLoc_ID <> 0 Then
        '''''        strSql = strSql + "tlocation.Loc_ID = " & iLoc_ID & " and " & vbCrLf
        '''''    End If

        '''''    strSql = strSql + "tworkorder.WO_Shipped = 0 " & vbCrLf
        '''''    strSql = strSql + "Order BY tworkorder.WO_Date Asc;"

        '''''    Try
        '''''        Return GetDataTable(strSql)
        '''''    Catch ex As Exception
        '''''        Throw New Exception("MotorolaSubcontract_Data.GetRMAGridData_Motorola: " & ex.Message.ToString)
        '''''    Finally
        '''''        strSql = ""
        '''''    End Try

        '''''End Function

        '****************************************************************************
        'This gets the RMA grid data from the database
        '****************************************************************************
        Public Function GetRMAGridData(ByVal iCust_ID As Integer, _
                                        Optional ByVal iLoc_ID As Integer = 0, _
                                        Optional ByVal iGroupID As Integer = 0) As DataTable

            'strSql = "select * from lcodesmaster; "

            strSql = "select distinct" + vbCrLf
            strSql = strSql + "tworkorder.WO_CustWO as RMANumber, " + vbCrLf
            strSql = strSql + "tmodel.model_desc as Model, " + vbCrLf
            strSql = strSql + "tworkorder.WO_Quantity, " + vbCrLf
            strSql = strSql + "tworkorder.WO_RAQnty as RMA_Quantity, " + vbCrLf
            strSql = strSql + "'' as DevicesReceived, " + vbCrLf
            strSql = strSql + "'' as DevicesToBeShipped, " + vbCrLf
            'strSql = strSql + "tpreloadwodata.plwodata_DockDate as DockDate, " + vbCrLf
            strSql = strSql + "tworkorder.WO_IP as IP, " + vbCrLf
            strSql = strSql + "tworkorder.WO_PRL as PRL, " + vbCrLf
            strSql = strSql + "tmodel.model_id, " + vbCrLf
            strSql = strSql + "tworkorder.WO_ID " + vbCrLf

            strSql = strSql + "from " + vbCrLf
            strSql = strSql + "tworkorder " + vbCrLf
            strSql = strSql + "inner join tdevice on tworkorder.WO_ID = tdevice.WO_ID " + vbCrLf
            strSql = strSql + "inner join tmodel on tdevice.model_id = tmodel.model_id " + vbCrLf
            'strSql = strSql + "inner join tlocation on tdevice.LOC_ID = tlocation.LOC_ID " + vbCrLf
            'strSql = strSql + "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " + vbCrLf
            'strSql = strSql + "left outer join tpreloadwodata on tworkorder.WO_ID = tpreloadwodata.WO_ID " + vbCrLf

            strSql = strSql + "where " + vbCrLf
            'strSql = strSql + "tcustomer.Cust_ID = " & iCust_ID & " and " & vbCrLf
            strSql = strSql + "tworkorder.Group_ID = " & iGroupID & " and " & vbCrLf
            If iLoc_ID <> 0 Then
                strSql = strSql + "tdevice.Loc_ID = " & iLoc_ID & " and " & vbCrLf
            End If

            strSql = strSql + "tworkorder.WO_Shipped = 0 " & vbCrLf
            strSql = strSql + "Order BY tworkorder.WO_Date Asc;"

            Try
                Return GetDataTable(strSql)
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Data.GetRMAGridData_Motorola: " & ex.Message.ToString)
            Finally
                strSql = ""
            End Try

        End Function

        'Public Function GetRMAGridData(ByVal iCust_ID As Integer, _
        '                                Optional ByVal iLoc_ID As Integer = 0, _
        '                                Optional ByVal iGroupID As Integer = 0) As DataTable

        '    'strSql = "select * from lcodesmaster; "

        '    strSql = "select distinct" + vbCrLf
        '    strSql = strSql + "tworkorder.WO_CustWO as RMANumber, " + vbCrLf
        '    strSql = strSql + "tmodel.model_desc as Model, " + vbCrLf
        '    strSql = strSql + "tsku.SKU_Number as SKUNumber, " + vbCrLf
        '    strSql = strSql + "tworkorder.WO_Quantity, " + vbCrLf
        '    strSql = strSql + "tworkorder.WO_RAQnty as RMA_Quantity, " + vbCrLf
        '    strSql = strSql + "'' as DevicesReceived, " + vbCrLf
        '    strSql = strSql + "'' as DevicesToBeShipped, " + vbCrLf
        '    strSql = strSql + "tpreloadwodata.plwodata_DockDate as DockDate, " + vbCrLf
        '    strSql = strSql + "tworkorder.WO_IP as IP, " + vbCrLf
        '    strSql = strSql + "tworkorder.WO_PRL as PRL, " + vbCrLf
        '    strSql = strSql + "tmodel.model_id, " + vbCrLf
        '    strSql = strSql + "tworkorder.WO_ID, " + vbCrLf
        '    strSql = strSql + "tsku.SKU_ID as SKU_ID " + vbCrLf
        '    'strSql = strSql + "tworkorder.WO_Date " + vbCrLf

        '    strSql = strSql + "from " + vbCrLf
        '    strSql = strSql + "tworkorder " + vbCrLf
        '    strSql = strSql + "inner join tdevice on tworkorder.WO_ID = tdevice.WO_ID " + vbCrLf
        '    strSql = strSql + "inner join tmodel on tdevice.model_id = tmodel.model_id " + vbCrLf
        '    strSql = strSql + "inner join tsku on tdevice.SKU_ID = tsku.SKU_ID " + vbCrLf
        '    strSql = strSql + "inner join tlocation on tdevice.LOC_ID = tlocation.LOC_ID " + vbCrLf
        '    strSql = strSql + "inner join tcustomer on tlocation.Cust_ID = tcustomer.Cust_ID " + vbCrLf
        '    strSql = strSql + "left outer join tpreloadwodata on tworkorder.WO_ID = tpreloadwodata.WO_ID " + vbCrLf

        '    strSql = strSql + "where " + vbCrLf
        '    strSql = strSql + "tcustomer.Cust_ID = " & iCust_ID & " and " & vbCrLf
        '    strSql = strSql + "tworkorder.Group_ID = " & iGroupID & " and " & vbCrLf
        '    If iLoc_ID <> 0 Then
        '        strSql = strSql + "tlocation.Loc_ID = " & iLoc_ID & " and " & vbCrLf
        '    End If

        '    strSql = strSql + "tworkorder.WO_Shipped = 0 " & vbCrLf
        '    strSql = strSql + "Order BY tworkorder.WO_Date Asc;"

        '    Try
        '        Return GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Data.GetRMAGridData_Motorola: " & ex.Message.ToString)
        '    Finally
        '        strSql = ""
        '    End Try

        'End Function

        '***************************************************************************
        'This method connects to the database, executes the SQL string and returns 
        'the data in datatable form.
        '***************************************************************************
        Public Shared Function GetDataTable(ByVal [string] As String) As DataTable
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

        '***************************************************************************
        'This executes the execute queries
        '***************************************************************************
        Public Shared Function ExecuteNonQueries(ByVal sSQL As String) As Integer
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.ExecuteNonQuery(sSQL)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function
        '****************************************************************************
        'Handles Insert SQL statements and returns the IDs
        '****************************************************************************
        Public Function idTransaction(ByVal SQL As String, ByVal strTable As String) As Int32
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.idTransaction(SQL, strTable)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        '****************************************************************************
    End Class
End Namespace
