
Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class Syx
        Public Const CUSTOMERID As Integer = 2485
        Public Const LOCID As Integer = 3284
        Public Const ScreenID_Receiving As Integer = 3409
        Public Const ScreenID_Kitting As Integer = 3410
        Public Const ScreenID_Billing As Integer = 3414
        Public Const ScreenID_PreTest As Integer = 3764

        Private _objDataProc As DBQuery.DataProc
        Private _strRptPath As String = "P:\Dept\Labels\" & System.Net.Dns.GetHostName & "\"
        Private _strLabelKitting As String = "Syx_Kitting_Label.rpt"

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

#Region "General Function"

        '********************************************************************************************************

        Public Function GetDeviceInfo(ByVal Serial As String, ByVal booInWIP As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select tdevice.*,syxdata.SyxData_ID,lproduct.Prod_Desc,lmanuf.manuf_Desc,tmodel.Model_Desc,syxdata.Kitting_UserID,syxdata.Kitting_Date,syxdata.Status,syxdata.Cost,syxdata.PD_ID,syxdata.NewModelProdID" & Environment.NewLine
                strSql &= "From tdevice" & Environment.NewLine
                strSql &= "INNER JOIN syxdata ON tdevice.Device_ID = syxdata.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN security.tusers ON syxdata.Receiver_UserID = security.tusers.User_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lmanuf ON tmodel.manuf_ID = lmanuf.manuf_ID" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lproduct ON tmodel.prod_ID = lproduct.prod_ID" & Environment.NewLine
                strSql &= "WHERE tdevice.Device_SN = '" & Serial & "'" & Environment.NewLine
                If booInWIP Then strSql &= "AND (tdevice.Device_DateShip is null or tdevice.Device_DateShip = '' or tdevice.Device_DateShip = '0000-00-00 00:00:00') "
                strSql &= "ORDER BY tdevice.Device_ID DESC" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetAutoBillServiceBillcode(ByVal iProdID As Integer, ByVal iModelID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT lbillcodes.Billcode_ID, Billcode_Desc " & Environment.NewLine
                strSql &= "FROM tpsmap INNER JOIN lbillcodes ON tpsmap.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Model_ID = " & iModelID & " AND lbillcodes.Device_ID = " & iProdID & " AND BillType_ID = 1 " & Environment.NewLine
                strSql &= "AND Billcode_Desc IN ( 'Cosmetic - B' ) " & Environment.NewLine
                strSql &= "ORDER BY Billcode_Desc " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetComsumedServiceBillcode(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Billcode_Desc " & Environment.NewLine
                strSql &= "FROM tdevicebill INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & " AND BillType_ID = 1 " & Environment.NewLine
                strSql &= "ORDER BY Billcode_Desc " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************

#End Region

#Region "Kitting"

        '********************************************************************************************************

        Public Function UpdateKitting(ByVal Device_ID As Integer, ByVal User_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update syxdata" & Environment.NewLine
                strSql &= "Set Kitting_UserID=" & User_ID & Environment.NewLine
                strSql &= ",Kitting_Date=Now()" & Environment.NewLine
                strSql &= "WHERE Device_ID=" & Device_ID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function


        '****************************************************************************************************

#End Region

#Region "Accessories"

        '******************************************************************************************************************

        Public Function InsertRemoveAccessories(ByVal Device_ID As Integer, ByVal BillCode_ID As Integer, _
                                                ByVal Part_Number As String, ByVal Screen_ID As Integer, _
                                                ByVal UserID As Integer, ByVal AccessoryStatus_ID As Integer, _
                                                Optional ByVal Comment As String = "") As Integer

            Dim strSql As String = ""
            Dim dt As DataTable
            Try
                strSql = "SELECT * From tDeviceAccessories" & Environment.NewLine
                strSql &= " where Device_ID=" & Device_ID & Environment.NewLine
                strSql &= " And BillCode_ID=" & BillCode_ID & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    'Update for failed and missing accessories
                    strSql = "Update tDeviceAccessories" & Environment.NewLine
                    strSql &= "Set Status_ID=" & AccessoryStatus_ID & Environment.NewLine
                    strSql &= ",Screen_ID=" & Screen_ID & Environment.NewLine
                    strSql &= ",TransUserID=" & UserID & Environment.NewLine
                    strSql &= ",TransDate=Now()" & Environment.NewLine
                    strSql &= ",Status_Inspector=" & UserID & Environment.NewLine
                    strSql &= ",InspectDate=Now()" & Environment.NewLine
                    strSql &= ",Comment='" & Comment & "'" & Environment.NewLine
                    strSql &= "where Device_ID=" & Device_ID & Environment.NewLine
                    strSql &= "And BillCode_ID=" & BillCode_ID & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                Else
                    'Add new accessories
                    strSql = "Insert tDeviceAccessories (Device_ID,BillCode_ID,Part_Number,Screen_ID,TransUserID,TransDate,Status_ID) Values (" & Environment.NewLine
                    strSql &= Device_ID & "," & Environment.NewLine
                    strSql &= BillCode_ID & "," & Environment.NewLine
                    strSql &= "'" & Part_Number & "'," & Environment.NewLine
                    strSql &= Screen_ID & "," & Environment.NewLine
                    strSql &= UserID & "," & Environment.NewLine
                    strSql &= "now()," & Environment.NewLine
                    strSql &= AccessoryStatus_ID & Environment.NewLine
                    strSql &= ")" & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Syx Status"

        '********************************************************************************************************
        Public Function GetSyxStatusList(ByVal iStatusList As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                Select Case iStatusList
                    Case 1
                        strSql = "Select 0 as ID , '--Select Status--' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 1 as ID , 'Scrap' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 2 as ID , 'AWAP 1' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 3 as ID , 'Good' as Status" & Environment.NewLine
                    Case 2
                        strSql = "Select 0 as ID , '--Select Status--' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 1 as ID , 'AWAP 1' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 2 as ID , 'Good' as Status" & Environment.NewLine
                    Case 3
                        strSql = "Select 0 as ID , '--Select Status--' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 1 as ID , 'AWAP 1' as Status" & Environment.NewLine
                        strSql &= "union" & Environment.NewLine
                        strSql &= "Select 2 as ID , 'Scrap' as Status" & Environment.NewLine
                End Select

                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************************************
        Public Function UpdateSyxStatus(ByVal Device_ID As Integer, ByVal Status As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "Update SyxData Set Status='" & Status & "'" & Environment.NewLine
                strSql &= "Where Device_ID =" & Device_ID & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function SetAWAPFlag(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "Update SyxData Set InAWAP  = 1, InAWAP_Date = now() " & Environment.NewLine
                strSql &= "Where Device_ID = " & iDeviceID & " AND InAWAP_Date is null " & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************

#End Region

#Region "PreTest"
        '****************************************************************************************************
        Public Function InsertRemovetDeviceBill(ByVal iDeviceID As Integer, ByVal Dbill_RegPartPrice As Decimal, _
                                           ByVal DBill_AvgCost As Decimal, ByVal DBill_StdCost As Decimal, _
                                           ByVal DBill_InvoiceAmt As Decimal, ByVal BillCode_ID As Integer, ByVal Part_Number As String, _
                                           ByVal Fail_ID As Integer, ByVal Repair_ID As Integer, ByVal User_ID As Integer, ByVal Insert As Boolean) As Integer

            Dim strSql As String = ""
            Dim i As Integer
            Dim dt As DataTable

            Try
                If Insert = True Then

                    strSql = "SELECT * From tdevicebill" & Environment.NewLine
                    strSql &= " where Device_ID=" & iDeviceID & Environment.NewLine
                    strSql &= " And BillCode_ID=" & BillCode_ID & Environment.NewLine
                    dt = _objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count = 0 Then
                        strSql = "INSERT INTO tdevicebill (" & Environment.NewLine
                        strSql &= "Device_ID, Dbill_RegPartPrice, DBill_AvgCost,DBill_StdCost,DBill_InvoiceAmt,BillCode_ID,Part_Number, Fail_ID,Repair_ID,User_ID, Date_Rec" & Environment.NewLine
                        strSql &= ") VALUES ( " & Environment.NewLine
                        strSql &= iDeviceID & Environment.NewLine
                        strSql &= ", " & Dbill_RegPartPrice & Environment.NewLine
                        strSql &= ", " & DBill_AvgCost & Environment.NewLine
                        strSql &= ", " & DBill_StdCost & Environment.NewLine
                        strSql &= ", " & DBill_InvoiceAmt & Environment.NewLine
                        strSql &= ", " & BillCode_ID & Environment.NewLine
                        strSql &= ",'" & Part_Number & "'" & Environment.NewLine
                        strSql &= ", " & Fail_ID & Environment.NewLine
                        strSql &= ", " & Repair_ID & Environment.NewLine
                        strSql &= ", " & User_ID & Environment.NewLine
                        strSql &= ", Now()" & Environment.NewLine
                        strSql &= ") "
                    End If

                Else
                    strSql = "Delete From tdevicebill" & Environment.NewLine
                    strSql &= "Where Device_ID=" & iDeviceID & Environment.NewLine
                    strSql &= "And BillCode_ID=" & BillCode_ID & Environment.NewLine
                End If

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function gettdevicebill(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""
            Try

                strSql = "Select * From tdevicebill" & Environment.NewLine
                strSql &= "Where device_ID=" & iDeviceID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetServiceBillcodeID(ByVal iProdID As Integer, ByVal strBillcodeDesc As String) As Integer
            Dim strSql As String = ""
            Try

                strSql = "Select Billcode_ID From lbillcodes WHERE Device_ID = " & iProdID & Environment.NewLine
                strSql &= "AND BillType_ID = 1 AND Billcode_Desc = '" & strBillcodeDesc & "'" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetBilledServiceBillcodeIDs(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""
            Try

                strSql = "Select tdevicebill.Billcode_ID " & Environment.NewLine
                strSql &= "From tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.Billcode_ID" & Environment.NewLine
                strSql &= "WHERE tdevicebill.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND BillType_ID = 1" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetSyxManufSN(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Try

                strSql = "Select Manuf_SN " & Environment.NewLine
                strSql &= "From syxdata " & Environment.NewLine
                strSql &= "WHERE syxdata.Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function



        '****************************************************************************************************
#End Region

#Region "Label"

        '******************************************************************

        Public Function Label_KittingLabel(ByVal strMfg As String, _
                                           ByVal strModel As String, _
                                           ByVal strSerial As String, _
                                           ByVal strMissingAccessories As String _
                                           ) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "Select '" & strMfg & "' AS Mfg,'" & strModel & "' AS Model, '" & strSerial & "' AS Serial," & Environment.NewLine
                strsql &= "'" & strMissingAccessories & "' AS Miss_ASSY" & Environment.NewLine
                strsql &= "From Syxdata limit 1;"
                objRpt = New ReportDocument()

                With objRpt
                    .Load(Me._strRptPath & Me._strLabelKitting)
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(1, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function



#End Region

#Region "Re-Map Part"

        '****************************************************************************************************
        Public Function GetPSPriceID(ByVal strPsPriceNumber As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT PsPrice_ID FROM lpsprice WHERE psprice_number = '" & strPsPriceNumber & "'" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function AddPartIntoPsprice(ByVal strPartNumber As String, ByVal strPartDesc As String, _
                                           ByVal iUserID As Integer, ByVal iRVFlag As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iPsPriceID As Integer = 0

            Try
                'Regular part
                If Me.GetPSPriceID(strPartNumber) = 0 Then
                    strSql = "INSERT INTO lpsprice ( " & Environment.NewLine
                    strSql &= "PSPrice_Number, PSPrice_Desc, PSPrice_InventoryPart" & Environment.NewLine
                    strSql &= ", RVFlag, UpdateUserID, UpdateDate" & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strPartNumber & "'" & Environment.NewLine
                    strSql &= ", '" & strPartDesc & "'" & Environment.NewLine
                    strSql &= ", 1, 0, " & iUserID & ", now()" & Environment.NewLine
                    strSql &= "); "
                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                'RV part
                If Me.GetPSPriceID(strPartNumber & "_RV") = 0 Then
                    strSql = "INSERT INTO lpsprice ( " & Environment.NewLine
                    strSql &= "PSPrice_Number, PSPrice_Desc, PSPrice_InventoryPart" & Environment.NewLine
                    strSql &= ", RVFlag, UpdateUserID, UpdateDate" & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strPartNumber & "_RV" & "'" & Environment.NewLine
                    strSql &= ", '" & strPartDesc & " RV'" & Environment.NewLine
                    strSql &= ", 1, 1, " & iUserID & ", now()" & Environment.NewLine
                    strSql &= "); "
                    Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                If iRVFlag = 1 Then iPsPriceID = Me.GetPSPriceID(strPartNumber & "_RV") Else iPsPriceID = Me.GetPSPriceID(strPartNumber)

                Return iPsPriceID
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetCurrentMap(ByVal iModelID As Integer, ByVal iBillcodeID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tpsmap.*, PsPrice_Number" & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.Psprice_ID = lpsprice.Psprice_ID  " & Environment.NewLine
                strSql &= "WHERE tpsmap.model_id = " & iModelID & " AND tpsmap.Billcode_ID = " & iBillcodeID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function UpdatePartMapRegAndRV(ByVal iPsPriceID As Integer, ByVal iPsPriceIDRV As Integer, ByVal iBillcodeID As Integer, _
                                              ByVal iBillcodeIDRV As Integer, ByVal iModelID As Integer, ByVal dtTemplate As DataTable, _
                                              ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                '***************************************************
                'Regular bill code
                '***************************************************
                strSql = "SELECT * FROM tpsmap WHERE Billcode_ID = " & iBillcodeID & " AND Model_ID = " & iModelID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate mapping Model ID " & iModelID & " and billcode ID " & iBillcodeID & ".")
                ElseIf dt.Rows.Count = 1 Then
                    strSql = "UPdate tpsmap SET Psprice_ID = " & iPsPriceID & Environment.NewLine
                    strSql &= ", User_ID = " & iUserID & ", UpdateDate = now() " & Environment.NewLine
                    strSql &= "WHERE tpsmap.PSMap_ID = " & dt.Rows(0)("PSMap_ID") & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO tpsmap ( PSPrice_ID, BillCode_ID, Model_ID, Prod_ID, LaborLvl_ID, LaborLevel, CustFlg, Inactive " & Environment.NewLine
                    strSql &= ", CanReflow, ReflowTypeID, LOB_ID, User_ID, UpdateDate " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iPsPriceID & ", " & iBillcodeID & ", " & iModelID & ", " & dtTemplate.Rows(0)("Prod_ID") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("LaborLvl_ID") & ", " & dtTemplate.Rows(0)("LaborLevel") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("CustFlg") & ", " & dtTemplate.Rows(0)("Inactive") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("CanReflow") & ", " & dtTemplate.Rows(0)("ReflowTypeID") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("LOB_ID") & ", " & iUserID & ", now()" & Environment.NewLine
                    strSql &= ") "
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                '***************************************************
                'RV Billcode
                '***************************************************
                strSql = "SELECT * FROM tpsmap WHERE Billcode_ID = " & iBillcodeIDRV & " AND Model_ID = " & iModelID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate mapping Model ID " & iModelID & " and billcode ID " & iBillcodeIDRV & ".")
                ElseIf dt.Rows.Count = 1 Then
                    strSql = "UPdate tpsmap SET Psprice_ID = " & iPsPriceIDRV & Environment.NewLine
                    strSql &= "WHERE tpsmap.PSMap_ID = " & dt.Rows(0)("PSMap_ID") & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO tpsmap ( PSPrice_ID, BillCode_ID, Model_ID, Prod_ID, LaborLvl_ID, LaborLevel, CustFlg, Inactive " & Environment.NewLine
                    strSql &= ", CanReflow, ReflowTypeID, LOB_ID, User_ID, UpdateDate " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iPsPriceIDRV & ", " & iBillcodeIDRV & ", " & iModelID & ", " & dtTemplate.Rows(0)("Prod_ID") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("LaborLvl_ID") & ", " & dtTemplate.Rows(0)("LaborLevel") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("CustFlg") & ", " & dtTemplate.Rows(0)("Inactive") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("CanReflow") & ", " & dtTemplate.Rows(0)("ReflowTypeID") & Environment.NewLine
                    strSql &= ", " & dtTemplate.Rows(0)("LOB_ID") & ", " & iUserID & ", now()" & Environment.NewLine
                    strSql &= ") "
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetBillcodeID(ByVal strBillcodeDesc As String, ByVal iProdID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Billcode_ID FROM lbillcodes WHERE Billcode_Desc = '" & strBillcodeDesc & "' AND Device_ID = " & iProdID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************
        Public Function CloneBillCodes(ByVal strBillcodeDesc As String, ByVal iBillcodeID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable = Nothing
            Dim iNewBillcodeID As Integer = 0

            Try
                strSql = "SELECT * FROM lbillcodes WHERE Billcode_ID = " & iBillcodeID
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Billcode ID " & iBillcodeID & " is no longer available.")
                Else
                    iNewBillcodeID = GetBillcodeID(strBillcodeDesc, dt.Rows(0)("Device_ID"))
                    If iNewBillcodeID = 0 Then
                        iNewBillcodeID = BillCode.InsertBillCode(strBillcodeDesc, dt.Rows(0)("Device_ID"), dt.Rows(0)("BillCode_Rule"), dt.Rows(0)("BillType_ID"), dt.Rows(0)("Fail_ID"), dt.Rows(0)("Repair_ID"), dt.Rows(0)("AggBill"))
                    End If
                End If

                Return iNewBillcodeID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************

#End Region

#Region "Tools"

            '****************************************************************************************************
        Public Function GetPalletModelsList(ByVal Pallet As String, Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Try

                strSql = "SELECT *, concat(ItemNUmber, ' (', ItemDescription, ')') as Model" & Environment.NewLine
                strSql &= "FROM syxrecpalletdata" & Environment.NewLine
                strSql &= "Where PalletID='" & Pallet & "'" & Environment.NewLine
                strSql &= "order by itemnumber;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT MODEL--"}, False)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************
        Public Function GetPalletDefinedModelsList(ByVal Pallet As String, Optional ByVal booAddSelectRow As Boolean = False) As DataTable
            'This will return list of defined models only 
            Dim strSql As String = ""
            Dim dt As DataTable
            Try

                strSql = "SELECT a.*, concat(a.ItemNUmber, ' (', a.ItemDescription, ')') as Model" & Environment.NewLine
                strSql &= "FROM syxrecpalletdata a" & Environment.NewLine
                strSql &= "Inner Join tmodel b on b.model_desc=a.itemNumber" & Environment.NewLine
                strSql &= "Inner Join lproduct c on c.prod_id=b.prod_id" & Environment.NewLine
                strSql &= "Inner Join lmanuf d on d.manuf_id=b.manuf_id" & Environment.NewLine
                strSql &= "Where a.PalletID='" & Pallet & "'" & Environment.NewLine
                strSql &= "order by a.itemnumber;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT MODEL--"}, False)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        '********************************************************************************************************

        Public Function UpdateModel(ByVal Model_ID As Integer, ByVal Prod_ID As Integer, ByVal Manuf_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Try
                strSql = "Update tmodel Set Prod_ID=" & Prod_ID & Environment.NewLine
                strSql &= ",Manuf_ID=" & Manuf_ID & Environment.NewLine
                strSql &= "Where Model_ID =" & Model_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "Update syxdata Set NewModelProdID=" & Prod_ID & Environment.NewLine
                strSql &= ",Manuf_ID=" & Manuf_ID & Environment.NewLine
                strSql &= "Where Model_ID =" & Model_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        '********************************************************************************************************

        Public Function UpdateItemNumberQty(ByVal PD_ID As Integer, ByVal NewQty As Integer, ByVal OriginalQty As Integer, ByVal LastUpdateValue As Decimal, ByVal OriginalLastUpdateValue As Decimal, ByVal Discrepancy As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Try
                strSql = "Update syxrecpalletdata Set OnHandQty=" & NewQty & Environment.NewLine
                'strSql &= ",OriginalOnhandQty=" & OriginalQty & Environment.NewLine 'Lan said don't update this 12/19/2011
                strSql &= ",LastUpdateValue=" & LastUpdateValue & Environment.NewLine
                'strSql &= ",OriginalLastUpdateValue=" & OriginalLastUpdateValue & Environment.NewLine 'Lan said don't update this 12/19/2011
                strSql &= ",Discrepancy='" & Discrepancy & "'" & Environment.NewLine
                strSql &= ",DiscrepancySetDate=Now()" & Environment.NewLine
                strSql &= "Where PD_ID =" & PD_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function


        '********************************************************************************************************

        Public Function InsertSyxrecpalletdata(ByVal ItemNumber As String, ByVal ItemDescription As String, ByVal OnHandQty As Integer, ByVal LastUpdateValue As Decimal, ByVal UPCCode As String, ByVal PalletID As String, ByVal Discrepancy As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Try
                strSql = "Insert Syxrecpalletdata (ItemNumber,ItemDescription,OnHandQty,LastUpdateValue,UPCCode,PalletID,Discrepancy,DiscrepancySetDate,OriginalOnHandQty,OriginalLastUpdateValue) Values (" & Environment.NewLine
                strSql &= "'" & ItemNumber & "'" & Environment.NewLine
                strSql &= ",'" & ItemDescription & "'" & Environment.NewLine
                strSql &= "," & OnHandQty & Environment.NewLine
                strSql &= "," & LastUpdateValue & Environment.NewLine
                strSql &= ",'" & UPCCode & "'" & Environment.NewLine
                strSql &= ",'" & PalletID & "'" & Environment.NewLine
                strSql &= ",'" & Discrepancy & "'" & Environment.NewLine
                strSql &= ",Now()" & Environment.NewLine
                strSql &= "," & OnHandQty & Environment.NewLine
                strSql &= "," & LastUpdateValue & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function


        '*******************************************************************************************************************
        Public Function IsItemNumberExisted(ByVal strPalletID As String, ByVal strItemNumner As String) As Boolean
            Dim strSql As String = ""
            Dim i As Integer

            Try
                strSql = "SELECT count(ItemNumber) " & Environment.NewLine
                strSql &= "FROM syxrecpalletdata" & Environment.NewLine
                strSql &= "WHERE Palletid = '" & strPalletID & "'" & Environment.NewLine
                strSql &= "AND ItemNumber = '" & strItemNumner & "'" & Environment.NewLine
                i = Me._objDataProc.GetIntValue(strSql)
                If i = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

#End Region

#Region "Parts Receiving"
        '********************************************************************************************************

        Public Function InsertSyxParts(ByVal PO_Number As String, ByVal PO_Qty As Integer, ByVal Part_Name As String, ByVal Part_Qty As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Try
                strSql = "Insert SyxParts (PO_Number,PO_Qty,Part_Name,Part_Qty) Values (" & Environment.NewLine
                strSql &= "'" & PO_Number & "'" & Environment.NewLine
                strSql &= "," & PO_Qty & Environment.NewLine
                strSql &= ",'" & Part_Name & "'" & Environment.NewLine
                strSql &= "," & Part_Qty & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function
        '********************************************************************************************************

        Public Function InsertSyxPartsConsumption(ByVal Device_ID As Integer, ByVal Part_ID As Integer, ByVal Trans_Amount As Integer, ByVal User_ID As Integer, ByVal PC_Flag As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Try
                strSql = "Insert SyxPartsConsumption (Device_ID,Part_ID,Trans_Amount,User_ID,PC_Flag,Trans_Date) Values (" & Environment.NewLine
                strSql &= "" & Device_ID & Environment.NewLine
                strSql &= "," & Part_ID & Environment.NewLine
                strSql &= "," & Trans_Amount & Environment.NewLine
                strSql &= "," & User_ID & Environment.NewLine
                strSql &= "," & PC_Flag & Environment.NewLine
                strSql &= ",Now()" & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        '****************************************************************************************************
        Public Function GetPartsInfoByPO(ByVal PO_Number As String) As DataTable

            Dim strSql As String = ""

            Try

                strSql = "SELECT *" & Environment.NewLine
                strSql &= "FROM syxparts" & Environment.NewLine
                strSql &= "Where PO_Number = '" & PO_Number & "'" & Environment.NewLine
                strSql &= "Order By Part_ID;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)


            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************************************


        '*******************************************************************************************************************

#End Region

#Region "Parts Consumption"
        '****************************************************************************************************
        Public Function GetPartsInfo(ByVal Part_Name As String) As DataTable

            Dim strSql As String = ""

            Try

                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM syxparts" & Environment.NewLine
                strSql &= "Where Part_Name='" & Part_Name & "'" & Environment.NewLine
                strSql &= "And Part_Qty > 0;" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)


            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************
        Public Function GetPartsConsumptionInfo(ByVal Device_ID As Integer) As DataTable

            Dim strSql As String = ""

            Try

                strSql = "SELECT a.PC_ID,a.Part_ID,b.Part_Name" & Environment.NewLine
                strSql &= ",if(a.Trans_Amount = 1,'Add','Remove') as 'Transaction'" & Environment.NewLine
                strSql &= ",if(a.PC_Flag = 1,'AWAP','CONSUME') as 'Consumption'" & Environment.NewLine
                strSql &= "FROM syxpartsconsumption a" & Environment.NewLine
                strSql &= "Left join syxparts b on b.Part_ID=a.Part_ID" & Environment.NewLine
                strSql &= "Where a.Device_ID=" & Device_ID & Environment.NewLine
                'strSql &= "And Trans_Amount=1" & Environment.NewLine
                strSql &= "Order By Part_Name,PC_ID" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************************************************

#End Region

#Region "Validation"

        '****************************************************************************************************
        Public Function IsDeviceHasNeedPart(ByVal iDeviceID As Integer) As Boolean
            Dim dtAWAP, dtConsumption As DataTable
            Dim objTech As New Buisness.NewTech()
            Dim booHasNeedPart As Boolean
            Dim R1 As DataRow

            Try
                booHasNeedPart = False
                dtConsumption = Buisness.DeviceBilling.GetBilledData(iDeviceID)
                dtAWAP = objTech.GetSelectedAWAP(iDeviceID)
                Generic.AddNewColumnToDataTable(dtAWAP, "Consumed", "System.Int16", "0")

                If dtAWAP.Rows.Count > 0 Then

                    For Each R1 In dtAWAP.Rows
                        If dtConsumption.Select("Billcode_ID = " & R1("Billcode_ID")).Length > 0 Then
                            R1.BeginEdit() : R1("Consumed") = 1 : R1.EndEdit()
                        ElseIf dtConsumption.Select("Part_Number = '" & R1("Part_Number") & "_RV'").Length > 0 Then
                            R1.BeginEdit() : R1("Consumed") = 1 : R1.EndEdit()
                        End If
                    Next R1

                    If dtAWAP.Select("Consumed = 0").Length > 0 Then booHasNeedPart = True
                End If

                Return booHasNeedPart
            Catch ex As Exception
                Throw ex
            Finally
                objTech = Nothing : Generic.DisposeDT(dtAWAP) : Generic.DisposeDT(dtConsumption)
            End Try
        End Function

        '****************************************************************************************************

#End Region

#Region "Image Library"

        '******************************************************************************************************************
        Public Function GetModellistByProdTypes(ByVal strProdIDs As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Model_ID, Model_Desc, ManufModelNumber FROM tmodel WHERE Prod_ID IN ( " & strProdIDs & " ) ORDER BY Model_Desc "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************
        Public Function GetImageLibrary() As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT  imagelibrary.Model_ID, Model_Desc as Model" & Environment.NewLine
                strSql &= ", IF(ManufModelNumber is null, '', ManufModelNumber) as 'Manuf Model'" & Environment.NewLine
                strSql &= ", IF(HasImage = 1, 'Yes', 'No') as 'Has Image?'" & Environment.NewLine
                strSql &= ", LastUpdDate as 'Last Updated Date', User_Fullname as 'Updated By'" & Environment.NewLine
                strSql &= "FROM imagelibrary " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON imagelibrary.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN security.tusers ON imagelibrary.LastUpdUserID = security.tusers.User_ID " & Environment.NewLine
                strSql &= "WHERE HasImage = 1"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************

#End Region

#Region "Edit Model"

        '*********************************************************************************************************
        Public Function GetModelManufProd(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT DISTINCT tmodel.Model_ID, Model_Desc, lmanuf.Manuf_ID, lmanuf.Manuf_Desc" & Environment.NewLine
                strSql &= ", lproduct.Prod_ID, lproduct.Prod_Desc " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID" & Environment.NewLine
                strSql &= "INNER JOIN lproduct ON tmodel.Prod_ID = lproduct.Prod_ID" & Environment.NewLine
                strSql &= "ORDER BY Model_Desc " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--Select--", "0", "", "0", ""}, True)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************************
        Public Function GetDeviceInWipWithBillingInfo(ByVal iModelID As Integer) As DataTable
            Dim strSql As String
            Dim dt, dtNeed As DataTable
            Dim R1, R2 As DataRow

            Try
                strSql = "SELECT A.Device_ID, Device_SN as 'PSS Serial #', B.Workstation as 'Location' " & Environment.NewLine
                strSql &= ", IF(C.WIL_SDesc is null, '', C.WIL_SDesc) 'Sub-Location' " & Environment.NewLine
                strSql &= ", IF(C.WIL_LDesc is null, '', C.WIL_LDesc) 'Sub-Location Desc' " & Environment.NewLine
                strSql &= ", Count(dbill_ID) as 'Consumed Qty' " & Environment.NewLine
                strSql &= ", 0 as 'Need Qty' " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN wipsublocmap C ON B.WIL_ID = C.WIL_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill D ON A.Device_ID = D.Device_ID " & Environment.NewLine
                strSql &= "WHERE Device_Dateship is Null " & Environment.NewLine
                strSql &= "GROUP BY A.Device_ID " & Environment.NewLine
                strSql &= "ORDER BY Device_SN " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT A.Device_ID, Device_SN as 'PSS Serial #', B.Workstation as 'Location' " & Environment.NewLine
                strSql &= ", IF(C.WIL_SDesc is null, '', C.WIL_SDesc) 'Sub-Location' " & Environment.NewLine
                strSql &= ", IF(C.WIL_LDesc is null, '', C.WIL_LDesc) 'Sub-Location Desc' " & Environment.NewLine
                strSql &= ", 0 as 'Consumed Qty' " & Environment.NewLine
                strSql &= ", Sum(trans_Amount) as 'Need Qty' " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tcellopt B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN wipsublocmap C ON B.WIL_ID = C.WIL_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebillawap D ON A.Device_ID = D.Device_ID " & Environment.NewLine
                strSql &= "WHERE Device_Dateship is Null " & Environment.NewLine
                strSql &= "GROUP BY A.Device_ID " & Environment.NewLine
                strSql &= "ORDER BY Device_SN " & Environment.NewLine
                dtNeed = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtNeed.Rows
                    If dt.Select("Device_ID = " & R1("Device_ID")).Length > 0 Then
                        R2 = dt.Select("Device_ID = " & R1("Device_ID"))(0)
                        R2.BeginEdit() : R2("Need Qty") = R1("Need Qty") : R2.EndEdit()
                    Else
                        R2 = dt.NewRow
                        Dim i As Integer
                        For i = 0 To dtNeed.Columns.Count - 1
                            R2(i) = R1(i)
                        Next i
                        dt.Rows.Add(R2)
                    End If

                    R2 = Nothing
                Next R1

                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtNeed)
            End Try
        End Function

        '*********************************************************************************************************

#End Region


    End Class
End Namespace