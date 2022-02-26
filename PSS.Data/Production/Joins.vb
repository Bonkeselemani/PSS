Imports System
Imports System.Data
Imports eInfoDesigns.dbProvider.MySqlClient


Namespace Production
    Public Class Joins

        Public Shared Function GetBillCodeInfo(ByVal BillCode As Integer) As DataRow
            Dim strSql As String = "SELECT BillCode_LCD, BillType_ID, Fail_ID, Repair_ID, BillExcptType_ID, PrcGroup_ID FROM lbillcodes " & _
                                              "LEFT OUTER JOIN tbillexcpt ON lbillcodes.BillCode_ID = tbillexcpt.BillCode_ID WHERE lbillcodes.BillCode_ID = " & BillCode & ";"
            Dim dt As New DataTable()
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        Public Shared Function GetDeviceInfo(ByVal Device As Integer) As DataRow
            Dim strSql As String = "SELECT Device_DateBill, " & _
                                 "Device_Invoice, " & _
                                 "Device_ManufWrty, " & _
                                 "Device_PSSWrty, " & _
                                 "Device_LaborLevel, " & _
                                 "Device_LaborCharge, " & _
                                 "Model_ID, " & _
                                 "PlusParts, " & _
                                 "Cust_RepairNonWrty, " & _
                                 "Cust_ReplaceLCD, " & _
                                 "Cust_CollSalesTax " & _
                                 "PSSWrtyParts_ID, " & _
                                 "PSSWrtyLabor_ID " & _
                                 "PO_ID, " & _
                                 "tworkorder.WebInfo_ID " & _
                                 "Markup_RUR, " & _
                                 "Markup_NER, " & _
                                 "Markup_Cust " & _
                      "FROM ((((tdevice " & _
                      "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID) " & _
                      "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID) " & _
                      "INNER JOIN tcustwrty ON tcustomer.Cust_ID = tcustwrty.Cust_ID) " & _
                      "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID) " & _
                      "INNER JOIN tcustmarkup ON tcustomer.Cust_ID = tcustmarkup.Cust_ID " & _
                      "WHERE device_id = " & Device & " AND tcustmarkup.Prod_ID = tcustwrty.Prod_ID;"


            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function


        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:		No
        '// Parameters:	    Model ID
        '// Return Value:	DataTable
        '// Purpose:		    Returns all pricing for a specific customer by model for parts.
        '//------------------------------------------------------------------------------------------------------------
        Public Shared Function PartsPricing(ByVal Model As Int32, ByVal BillCode As Int32) As DataRow
            Dim strSql As String = "SELECT BillCode_ID, LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost FROM tpsmap INNER JOIN lpsprice " & _
                     "ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID WHERE Model_ID = " & Model & " AND BillCode_ID = " & BillCode & ";"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then Return dt.Rows(0) Else Return Nothing
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:		No
        '// Parameters:	    Customer ID, Product Group ID
        '// Return Value:	DataTable
        '// Purpose:		    Returns all pricing for a specific customer by model for labor.
        '//------------------------------------------------------------------------------------------------------------
        Public Shared Function LaborPricing(ByVal Customer As Int32, ByVal FlatProductGroup As Int32, ByVal TierProductGroup As Int32) As DataTable
            Dim strSql As String = "SELECT LaborLvl_ID, LaborPrc_RegPrc, LaborPrc_WrtyPrc FROM tcusttoprice INNER JOIN " & _
                                 "tlaborprc ON tcusttoprice.PrcGroup_ID = tlaborprc.PrcGroup_ID WHERE " & _
                                 "Cust_ID = " & Customer & " AND (ProdGrp_ID = " & FlatProductGroup & " OR ProdGrp_ID = " & TierProductGroup & ");"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:		No
        '// Parameters:	    Tray ID
        '// Return Value:	DataTable
        '// Purpose:		
        '//------------------------------------------------------------------------------------------------------------

        Public Shared Function GetDeviceTrayByID(ByVal TrayID As Int32) As DataTable
            Dim strSql As String = "SELECT * FROM tdevice WHERE Tray_ID = " & TrayID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSpecialCode(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_cust=" & vCode
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSpecialCodeTF(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 20 ORDER BY lcodesdetail.dcode_ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        Public Shared Function GetSpecialCodeTFfunc(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 20 and lcodesdetail.dcode_id in (2517) ORDER BY lcodesdetail.dcode_ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSpecialCodeTFRF(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 20 and lcodesdetail.dcode_id in (2516) ORDER BY lcodesdetail.dcode_ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSpecialCodeTFld(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 20 and lcodesdetail.dcode_id in (2519) ORDER BY lcodesdetail.dcode_ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSpecialCodeTFpd(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 20 and lcodesdetail.dcode_id in (2520) ORDER BY lcodesdetail.dcode_ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSpecialCodeTFflash(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 20 and lcodesdetail.dcode_id in (2518) ORDER BY lcodesdetail.dcode_ldesc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        Public Shared Function GetSpecialCodeATCreturn(ByVal vCode As Integer) As DataTable
            Dim strSql As String = "select * from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) WHERE lcodesmaster.mcode_id= 19"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSLIdata(ByVal mDeviceID As Int32) As DataTable
            Dim strSql As String = "SELECT tdevicecodes.dcode_id, lcodesmaster.mcode_id, " & _
                         "lcodesmaster.mcode_desc,tcellopt.* FROM " & _
                         "((((tdevice INNER JOIN tcellopt ON tdevice.device_id = tcellopt.device_id) " & _
                         "INNER JOIN tdevicecodes ON tcellopt.device_id = tdevicecodes.device_id) " & _
                         "INNER JOIN lcodesdetail ON tdevicecodes.dcode_id = lcodesdetail.dcode_id) " & _
                         "INNER JOIN lcodesmaster ON lcodesdetail.mcode_id = lcodesmaster.mcode_id) " & _
                         "WHERE(tdevice.device_id = " & mDeviceID & " )"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetSLIdataBILL(ByVal mDeviceID As Int32) As DataTable
            Dim strSql As String = "SELECT lcodesdetail.mcode_id, tpartscodes.* FROM ((tdevicebill INNER JOIN tpartscodes ON tdevicebill.dbill_id = tpartscodes.dbill_id) INNER JOIN lcodesdetail ON tpartscodes.dcode_id = lcodesdetail.dcode_id) WHERE tdevicebill.device_id = " & mDeviceID
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function Ship_CheckDupDevice(ByVal DeviceSN As String, ByVal LocID As Int32) As DataTable
            Dim strSql As String = "SELECT tdevice.*, tmodel.model_desc, lmanuf.manuf_desc FROM ((tdevice INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.manuf_id) WHERE tdevice.device_SN = '" & DeviceSN & "' and tdevice.Loc_ID = " & LocID & " and tdevice.device_datebill is not null and tdevice.device_dateship is null;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CheckDupDeviceBeforeDelete(ByVal DeviceSN As String) As DataTable
            Dim strSql As String = "SELECT tdevice.*, tmodel.model_desc, lmanuf.manuf_desc FROM ((tdevice INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.manuf_id) WHERE tdevice.device_SN = '" & DeviceSN & "'"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function Shipping_CustomerList() As DataTable
            Dim strSql As String = "SELECT tcustomer.*, tlocation.loc_name, tlocation.loc_id, tlocation.loc_ManifestDetail, lparentco.PCo_Name FROM ((lparentco INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID) INNER JOIN tlocation ON tcustomer.cust_id = tlocation.cust_id) WHERE tlocation.loc_name is not null " & _
                     "ORDER BY tlocation.Loc_Name asc;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function SecurityUserList() As DataTable
            Dim _conn As New MySqlConnection()
            Dim strSql As String = "SELECT security.tusers.user_fullname, security.tgroup.group_desc, security.tscreen.screen_desc " & _
                                    "FROM((((tusers " & _
                                    "INNER JOIN security.rusertogroup ON security.tusers.user_id = security.rusertogroup.user_id) " & _
                                    "INNER JOIN security.tgroup ON security.rusertogroup.group_id = security.tgroup.group_id) " & _
                                    "INNER JOIN security.tpermissions ON security.rusertogroup.group_id = security.tpermissions.group_id) " & _
                                    "INNER JOIN security.tscreen ON security.tpermissions.screen_id = security.tscreen.screen_id) " & _
                                    "ORDER BY security.tusers.user_fullname, security.tgroup.group_desc, security.tscreen.screen_desc "
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function Shipping_CustomerListEndUser() As DataTable
            Dim strSql As String = "SELECT tcustomer.*, tlocation.loc_name, tlocation.loc_id, tlocation.loc_ManifestDetail, lparentco.PCo_Name FROM ((lparentco INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID) INNER JOIN tlocation ON tcustomer.Cust_id = tlocation.cust_id) " & _
                                             "ORDER BY tlocation.Loc_ID desc;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:		No
        '// Parameters:	    Tray
        '// Return Value:	DataRow
        '// Purpose:	    Returns specific customer for a defined tray.
        '//------------------------------------------------------------------------------------------------------------
        Public Shared Function GetCurrentCustomerByTray(ByVal Tray As Int32) As DataRow
            Dim strSql As String = "SELECT tcustomer.Cust_ID, tcustomer.Cust_Name1, tcustomer.Cust_Name2, " & _
                                  "tcustomer.PlusParts, tcustomer.Cust_RepairNonWrty, tcustomer.Cust_ReplaceLCD, " & _
                                  "tcustomer.Cust_CollSalesTax, tworkorder.WebInfo_ID, tworkorder.Prod_ID, " & _
                                  "tworkorder.PO_ID, tworkorder.WebInfo_ID, ttray.Tray_ID FROM ((tcustomer " & _
                                  "INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) " & _
                                  "INNER JOIN tworkorder ON tlocation.Loc_ID = tworkorder.Loc_ID)" & _
                                  "INNER JOIN ttray ON tworkorder.WO_ID = ttray.WO_ID " & _
                                 "WHERE Tray_ID = " & Tray & ";"
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If (dt.Rows.Count > 0) Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:		No
        '// Parameters:	    sSQL
        '// Return Value:	DataTable
        '// Purpose:		Returns DataTables which are based off UIDs.
        '//------------------------------------------------------------------------------------------------------------
        Public Shared Function OrderEntrySelect(ByVal sSQL As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(sSQL)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GenericSelect(ByVal sSQL As String) As DataTable
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(sSQL)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:	    No
        '// Parameters:	    valDeviceType (Product Type 1=Pagers 2=Cellular)
        '// Return Value:	DataTable
        '// Purpose:		Returns all Manufacturers for a particular Product ID.
        '//------------------------------------------------------------------------------------------------------------
        Public Shared Function ManufListByDeviceType(ByVal valDeviceType As Integer) As DataTable
            Dim strSql As String = "Select Distinct lmanuf.manuf_id, lmanuf.manuf_desc from lmanuf," & _
                        "tmodel, tpsmap where tpsmap.model_id = tmodel.Model_ID and tmodel.Manuf_ID = " & _
                        "lmanuf.Manuf_ID and tpsmap.Prod_ID = " & valDeviceType & " order by lmanuf.manuf_desc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function chkSameSNsameDay(ByVal valDeviceSN As String, ByVal valPSSdate As String) As DataTable
            Dim strSql As String = "select * from tdevice where device_daterec > '" & _
                                    valPSSdate & " 00:00:00' and device_daterec < '" & _
                                    valPSSdate & " 23:59:59' and device_sn = '" & _
                                    valDeviceSN & "'"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function chkPSSwrty(ByVal valDeviceSN As String, ByVal valLocID As Int32, ByVal valPSSdate As String) As DataTable
            Dim strSql As String = "SELECT If(Count(tdevice.device_id) > 0, tdevice.device_id, 'false') As Repeat " & _
                                    "FROM (tdevice INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID) " & _
                                    "WHERE(tdevice.loc_id = " & valLocID & ") " & _
                                    "and tdevice.device_dateship > '" & valPSSdate & _
                                    "' and tdevice.device_sn = '" & valDeviceSN & "'" & _
                                    " and tworkorder.PO_ID is null;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function chkPSSwrtyMotorola(ByVal valDeviceSN As String, ByVal valPSSdate As String) As DataTable
            Dim strSql As String = "SELECT If(Count(tdevice.device_id) > 0, tdevice.device_id, 'false') As Repeat " & _
                                     "FROM (tdevice INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID) " & _
                                     "WHERE tdevice.device_dateship > '" & valPSSdate & _
                                     "' and tdevice.device_sn = '" & valDeviceSN & "'" & _
                                     " and tworkorder.PO_ID is null;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function chkPSSwrtyEndUser(ByVal valDeviceSN As String, ByVal valPSSdate As String) As DataTable
            Dim _conn As New MySqlConnection()
            Dim strSql As String = "SELECT If(Count(tdevice.device_id) > 0, tdevice.device_id, 'false') As Repeat " & _
                    "FROM (tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID) " & _
                    "WHERE tlocation.Loc_Name is null " & _
                    "and tdevice.device_dateship > '" & valPSSdate & _
                    "' and tdevice.device_sn = '" & valDeviceSN & "';"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function verifyInvoice(ByVal vWorkOrder As Int32) As DataTable
            Dim strSql As String = "SELECT If(Count(tdevice.device_id) > 0, tdevice.device_id, 'false') As Invoiced " & _
                                    "FROM tdevice " & _
                                    "WHERE(tdevice.WO_ID = " & vWorkOrder & ") " & _
                                    "and tdevice.Device_Invoice = 1;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function chkPSSwrtyBILL(ByVal valDeviceID As Int32) As DataTable
            Dim strSql As String = "select tdevicebill.*, lbillcodes.BillCode_Rule from tdevicebill INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID WHERE tdevicebill.device_ID = " & valDeviceID & " and lbillcodes.BillCode_Rule = '1'"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function


        '//------------------------------------------------------------------------------------------------------------
        '// Public Shared Method
        '// Overloaded:		No
        '// Parameters:	    valDeviceType, valManufID
        '// Return Value:	DataTable
        '// Purpose:		Returns all models for a particular Manufacturer and Product ID.
        '//------------------------------------------------------------------------------------------------------------
        Public Shared Function ModelListByManufAndDeviceType(ByVal valDeviceType As Integer, ByVal valManufID As Integer) As DataTable
            Dim strSql As String = "Select Distinct tmodel.model_id, tmodel.model_desc from tmodel, tpsmap, " & _
                                   "lmanuf where tmodel.model_id = tpsmap.model_id and tmodel.manuf_id = lmanuf.manuf_id " & _
                                   "and tpsmap.prod_id = " & valDeviceType & " and lmanuf.manuf_id= " & valManufID & " Order By tmodel.model_desc"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function OrderEntryUpdateDelete(ByVal sSQL As String) As Boolean
            Dim objDataProc As DBQuery.DataProc
            Dim i As Integer = 0

            Try
                OrderEntryUpdateDelete = False

                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                i = objDataProc.ExecuteNonQuery(sSQL)

                OrderEntryUpdateDelete = True
                Return True
            Catch ex As Exception
                OrderEntryUpdateDelete = False
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CheckDeviceDBR(ByVal vDeviceID As Int32) As DataTable
            Dim strSql As String = "SELECT lbillcodes.billcode_rule FROM ((tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id) INNER JOIN lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id) WHERE tdevice.device_id=" & vDeviceID & " AND (lbillcodes.billcode_rule= 1 OR lbillcodes.billcode_rule=2)"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        'Public Shared Function MaxLaborLevel(ByVal vDeviceID As Int32) As DataTable
        '    Dim strSql As String = ""
        '    Dim objDataProc As DBQuery.DataProc

        '    Try
        '        strSql = "select MAX(tpsmap.Laborlevel) AS LaborLevel " & Environment.NewLine
        '        strSql &= "from tdevice  " & Environment.NewLine
        '        strSql &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
        '        strSql &= "INNER JOIN tpartscodes ON tdevicebill.dbill_id = tpartscodes.dbill_id " & Environment.NewLine
        '        strSql &= "INNER JOIN lcodesdetail ON tpartscodes.dcode_id = lcodesdetail.dcode_id " & Environment.NewLine
        '        strSql &= "INNER JOIN tpsmap ON tdevicebill.billcode_id = tpsmap.billcode_id AND lcodesdetail.prod_id = tpsmap.prod_id " & Environment.NewLine
        '        strSql &= "WHERE tdevicebill.device_id= " & vDeviceID & " " & Environment.NewLine
        '        strSql &= "AND lcodesdetail.dcode_chrgcust = 1 " & Environment.NewLine
        '        strSql &= "GROUP BY tpsmap.Laborlevel"
        '        objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        '        Return objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        objDataProc = Nothing
        '    End Try
        'End Function

        Public Shared Function WOIDListByCustID(ByVal valCustomer As Integer, ByVal valWO As String) As DataTable
            Dim strSql As String = "Select tworkorder.* from (tlocation INNER JOIN tworkorder ON tlocation.loc_id = tworkorder.loc_id) WHERE tlocation.Cust_ID = " & valCustomer & " and tworkorder.wo_custwo = '" & valWO & "';"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function RepairCodeDisplay(ByVal MCode As Int32) As DataTable
            Dim strSql As String = "Select lcodesdetail.DCode_LDesc, lmanuf.manuf_Desc, lproduct.prod_Desc from ((lcodesdetail INNER JOIN lmanuf ON lcodesdetail.manuf_ID = lmanuf.manuf_ID) INNER JOIN lproduct ON lcodesdetail.Prod_ID = lproduct.Prod_ID) WHERE lcodesdetail.mcode_id= " & MCode
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function ASCPriceDisplay() As DataTable
            Dim strSql As String = "Select lascprice.*, lmanuf.manuf_Desc, lproduct.prod_Desc from ((lascprice INNER JOIN lmanuf ON lascprice.manuf_ID = lmanuf.manuf_ID) INNER JOIN lproduct ON lascprice.Prod_ID = lproduct.Prod_ID) ORDER BY lascprice.ASCPrice_Desc, lascprice.ASCPrice_Code"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function FailCodeDisplay(ByVal MCode As Int32) As DataTable
            Dim strSql As String = "Select lcodesdetail.DCode_LDesc, lmanuf.manuf_Desc, lproduct.prod_Desc from ((lcodesdetail INNER JOIN lmanuf ON lcodesdetail.manuf_ID = lmanuf.manuf_ID) INNER JOIN lproduct ON lcodesdetail.Prod_ID = lproduct.Prod_ID) WHERE lcodesdetail.mcode_id= " & MCode
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function TechScreenManufModelInfoByModel(ByVal valModel As Integer, ByVal valProdID As Integer) As DataTable
            Dim strSql As String = "Select tmodel.*,lprodgrp.prod_id from tmodel, lprodgrp where tmodel.prodgrp_id = lprodgrp.prodgrp_id and tmodel.Model_ID = " & valModel & " and lprodgrp.prod_id= " & valProdID
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CustomerListPagerFirm(ByVal deviceT As String) As DataTable
            Dim strSql As String = "Select tcustomer.* from ((lpricinggroup INNER JOIN tcusttoprice ON lpricinggroup.prcgroup_id = tcusttoprice.prcgroup_id) INNER JOIN tcustomer ON tcusttoprice.cust_id = tcustomer.cust_id) Where lpricinggroup.prctype_id=1 and tcustomer.cust_inactive = 0 and tcusttoprice.Prod_ID = " & deviceT & " order by tcustomer.cust_name1"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CustomerListPagerCOAM(ByVal deviceT As String) As DataTable
            Dim strSql As String = "Select tcustomer.* from ((lpricinggroup INNER JOIN tcusttoprice ON lpricinggroup.prcgroup_id = tcusttoprice.prcgroup_id) INNER JOIN  tcustomer ON tcusttoprice.cust_id = tcustomer.cust_id) WHERE tcustomer.cust_inactive = 0 and lpricinggroup.prctype_id=2 and tcustomer.cust_name2 is null AND tcusttoprice.prod_id= " & deviceT & " order by tcustomer.cust_Name1"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CustomerListPagerEndUser() As DataTable
            Dim strSql As String = "Select lparentco.* from lparentco where lparentco.PCo_EndUser = 1"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CustomerListPagerPO() As DataTable
            Dim strSql As String = "Select tcustomer.* from tcustomer WHERE  tcustomer.cust_inactive = 0 order by tcustomer.cust_name1"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function CompanyDeleteDeviceSelection(ByVal companyID As String) As DataTable
            Dim strSql As String = "SELECT tdevice.Device_ID FROM ((lparentco INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID) INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) INNER JOIN tdevice ON tlocation.Loc_ID = tdevice.Loc_ID WHERE lparentco.PCo_ID = " & companyID & ";"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetTableByPrcGroup(ByVal valPGID As String) As DataTable
            Dim strSql As String = "Select tlaborprc.*, lprodgrp.ProdGrp_LDesc from (tlaborprc INNER JOIN lprodgrp ON tlaborprc.prodgrp_id = lprodgrp.prodgrp_id) where PrcGroup_ID = '" & valPGID & "' Order By lprodgrp.prodgrp_id;"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetPSPriceRow(ByVal vBillCode As Integer, ByVal vModel As Integer) As DataRow
            Dim strSql As String = "SELECT * FROM tpsmap WHERE BillCode_ID = " & vBillCode & " AND Model_ID = " & vModel
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function GetCustomerFromDeviceID(ByVal vDeviceID As Int32) As DataRow
            Dim strSql As String = "select tcustomer.cust_id, tcustomer.cust_specialcodes, tcustomer.cust_CrBilling from ((tdevice INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id) INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_id) WHERE tdevice.device_id = " & vDeviceID
            Dim objDataProc As DBQuery.DataProc
            Dim dt As New DataTable()

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
                objDataProc = Nothing
            End Try
        End Function

        Public Shared Function ModelListCELLByManufName(ByVal vManufName As String) As DataTable
            Dim strSql As String = "select tmodel.* from (lmanuf INNER JOIN tmodel ON lmanuf.manuf_id = tmodel.manuf_id) WHERE lmanuf.manuf_desc = '" & vManufName & "' AND tmodel.prod_id = 2"
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Return objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                objDataProc = Nothing
            End Try
        End Function

        Public Sub New()

        End Sub
    End Class

End Namespace