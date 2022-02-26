Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class NIRec

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
        Public Function GetOpenRecWorkOrder(ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt, dtMap As DataTable
            Dim row, row2 As DataRow
            Dim filteredRows() As DataRow
            Dim strProd As String = ""
            Dim strModels As String = ""
            Dim strModelIDs As String = ""

            Try
                strSql = "SELECT tworkorder.WO_ID, WO_CustWO as 'Work Order', Cust2PSSI_TrackNo as TrackNo " & Environment.NewLine
                strSql &= ", ShipTo_name as 'Name', Address1, City, State_ShortName as 'State', ZipCode, Tel, Email" & Environment.NewLine
                strSql &= ", WO_Quantity as 'WO Qty'" & Environment.NewLine
                strSql &= ", if( extendedwarranty.NI_DataSwitch = 1, 'End User', if(extendedwarranty.NI_DataSwitch = 2, 'Bulk', 'Undefine')) as 'WO Type' " & Environment.NewLine
                strSql &= ", IF( extendedwarranty.SerialNo is null, '', extendedwarranty.SerialNo) as 'EDI S/N' , RepairType" & Environment.NewLine
                strSql &= ",'' AS 'NI_Product','' AS 'PSSI_Model',extendedwarranty.Prod_Code AS 'NI_prod_ID','' AS 'Model_ID'" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty On tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= "WHERE tworkorder.Loc_ID = " & iLocID & " AND WO_Closed = 0 and InvalidOrder = 0 AND tworkorder.WO_Shipped = 0 " & Environment.NewLine
                strSql &= "Order by tworkorder.WO_CustWO "
                dt = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT C.Model_Desc AS 'PSSI_Model',B.NI_Prod_Desc AS 'NI_Product'" & Environment.NewLine
                strSql &= " ,B.Prod_DescRpt,A.Model_ID,B.NI_prod_ID" & Environment.NewLine
                strSql &= " FROM ni_product_pssi_model_map A" & Environment.NewLine
                strSql &= " INNER JOIN ni_products B ON A.NI_Prod_ID = B.NI_Prod_ID" & Environment.NewLine
                strSql &= " INNER JOIN tmodel C ON A.Model_ID = C.Model_ID;" & Environment.NewLine
                dtMap = Me._objDataProc.GetDataTable(strSql)

                For Each row In dt.Rows
                    If Not row.IsNull("NI_prod_ID") Then
                        filteredRows = dtMap.Select("NI_prod_ID = " & row("NI_prod_ID"))
                        strProd = "" : strModels = "" : strModelIDs = ""
                        For Each row2 In filteredRows
                            If strProd.Trim.Length = 0 Then strProd = row2("NI_Product") Else strProd &= " or " & row2("NI_Product")
                            If strModels.Trim.Length = 0 Then strModels = row2("PSSI_Model") Else strModels &= " or " & row2("PSSI_Model")
                            If strModelIDs.Trim.Length = 0 Then strModelIDs = row2("Model_ID") Else strModelIDs &= "," & row2("Model_ID")
                        Next
                        row.BeginEdit() : row("NI_Product") = strProd : row("PSSI_Model") = strModels : row("Model_ID") = strModelIDs
                        row.AcceptChanges()
                    End If
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function PrintReceiveBoxLabel(ByVal strSN As String, ByVal strModel As String, ByVal strToLoc As String, _
                                             ByVal strOrderNo As String, ByVal strDeviceCondition As String, ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try
                strsql = "SELECT '" & strSN & "' as Serial, '" & strModel & "' AS Model" & Environment.NewLine
                strsql &= ", '" & strOrderNo & "' AS OrderNo " & Environment.NewLine
                strsql &= ", '" & strToLoc & "' as 'To Location'" & Environment.NewLine
                strsql &= ", '" & strDeviceCondition & "' as 'Condition'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strsql)
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "NI_Receive_Box_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*************************************************************************************
        Public Function IsDeviceOpenInWH(ByVal strSN As String) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "SELECT Count(*) as cnt FROM warehouse.warehouse_items " & Environment.NewLine
                strSql &= "WHERE Serial = '" & strSN & "' AND Device_ID = 0 AND SODetailsID = 0 " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) = 0 Then Return False Else Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function ReceiveDeviceIntoWIP(ByVal iWOID As Integer, ByVal iTrayID As Integer, ByVal iModelID As Integer, _
                                             ByVal strSN As String, ByVal iShiftID As Integer, ByVal iUserID As Integer, _
                                             ByVal strUserName As String, ByVal iCCID As Integer, ByVal strWorkStation As String, _
                                             ByVal dteReceiptDate As DateTime, ByVal bPrintLabel As Boolean, _
                                             ByVal strSoftKeyCode As String) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim iDeviceID, iCnt, i, iWipOwner, iManufWrty, iWHReceiptID, iPSSWrty As Integer
            Dim strWrkDate As String
            Dim objCreatePSSISNs As New CreatePSSISNs()

            Try
                iDeviceID = 0 : iCnt = 0 : i = 0 : iWipOwner = 1 : iManufWrty = 0 : iWHReceiptID = 0

                iPSSWrty = Me.CalPSSIWarranty(strSN, dteReceiptDate)

                strWrkDate = dteReceiptDate.ToString("yyyy-MM-dd")

                objRec = New PSS.Data.Production.Receiving()

                'Create device
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iCnt, iTrayID, NI.LOCID, iWOID, iModelID, iShiftID, iPSSWrty, iManufWrty, , iCCID, , , dteReceiptDate.ToString("yyyy-MM-dd HH:mm:ss"))
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert into tdevice table.")

                'Create cellopt 
                i = objRec.InsertIntoTCellopt(iDeviceID, , , , , , , , , , , , , , , , strWorkStation, , iWipOwner, strSN, strSoftKeyCode)
                If i = 0 Then Throw New Exception("System has failed to insert into tcellopt.")

                'Create NI_device
                i = objRec.InsertIntoNI_Device(iDeviceID, "")
                If i = 0 Then Throw New Exception("System has failed to insert into NI_Device.")

                'Create Received Box Label
                If bPrintLabel Then Label_ReceiveBoxLabel_NI_EndUSer(iDeviceID, 2) '2)

                Return iDeviceID

            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '*************************************************************************************
        Public Function ReceiveDeviceIntoWH(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iWOID As Integer, ByVal strWorkOrder As String, _
                                            ByVal strSN As String, ByVal iDeviceConditionID As Integer, ByVal iCosmGradeID As Integer, _
                                            ByVal iModelID As Integer, ByVal dbLaborCharge As Double, ByVal iBillCode_ID As Integer, ByVal iUserID As Integer, _
                                            ByVal bCreatReceiveLabel As Boolean, ByVal strSoftKeyCode As String, ByVal strDateReceived As String, _
                                            Optional ByVal iYes1No0 As Integer = 0) As Integer
            Dim i, iWHReceiptID As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM warehouse.warehouse_receipt WHERE Loc_ID = " & iLocID & " AND RMA = '" & strWorkOrder & "' "
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate warehouse receipt occurs. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    iWHReceiptID = dt.Rows(0)("WR_ID")
                Else
                    strSql = "INSERT INTO warehouse.warehouse_receipt ( " & Environment.NewLine
                    strSql &= "WR_Name, Receipt_Date, User_ID, Cust_ID, Loc_ID, RMA, WO_ID" & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= "'" & strWorkOrder & "', now(), " & iUserID & ", " & iCustID & ", " & iLocID & ", '" & strWorkOrder & "', " & iWOID & Environment.NewLine
                    strSql &= " ) "
                    iWHReceiptID = Me._objDataProc.idTransaction(strSql, "warehouse.warehouse_receipt")
                End If

                If iWHReceiptID = 0 Then Throw New Exception("System has failed to create warehouse receipt.")

                'Device_ID, Serial, Date_Received, WR_ID, Labor_Charge, Model_ID
                ', Management_Type_ID, Recpt_UsrID, DevConditionID
                strSql = "INSERT INTO warehouse.warehouse_items ( " & Environment.NewLine
                strSql &= " Serial, Date_Received, WR_ID, Labor_Charge,BillCode_ID, Model_ID " & Environment.NewLine
                strSql &= ", Management_Type_ID, Recpt_UsrID, DevConditionID, CosmGradeID, SoftKeyCode,DOA " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " '" & strSN & "', '" & strDateReceived & "', " & iWHReceiptID & ", " & dbLaborCharge & ", " & iBillCode_ID & ", " & iModelID & Environment.NewLine
                strSql &= ", " & iDeviceConditionID & ", " & iUserID & ", " & iDeviceConditionID & ", " & iCosmGradeID & Environment.NewLine
                If strSoftKeyCode.Trim.Length > 0 Then
                    strSql &= ", '" & Buisness.Generic.AddMySqlEscapeChar(strSoftKeyCode) & "'" & Environment.NewLine
                Else
                    strSql &= ", null " & Environment.NewLine
                End If
                strSql &= "," & iYes1No0 & Environment.NewLine 'DOA

                'If iDevice_ID > 0 Then strSql &= ", " & iDevice_ID & Environment.NewLine Else strSql &= ", 0 " & Environment.NewLine
                strSql &= " ) "
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to insert into warehouse.warehouse_items.")

                'Create Received Box Label------------------------------------------
                If bCreatReceiveLabel Then
                    strDateReceived = Format(CDate(strDateReceived), "MM/dd/yy")
                    Label_ReceiveBoxLabel_NI_BulkWarehouse(strSN, strDateReceived, iModelID, 2)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function GetRecQtyWH(ByVal iLocID As Integer, ByVal strRMA As String) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_receipt A INNER JOIN warehouse.warehouse_items B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & " AND RMA = '" & strRMA & "';"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function WriteOutBoundOrder(ByVal iWOID As Integer, ByVal iCosmGradeID As Integer, _
                                           ByVal strDevConditionID As Integer, ByVal iModelID As Integer, _
                                           ByVal iUsrID As Integer, ByRef strMsg As String) As Integer
            Const strUnitOfMeasure As String = "UNIT"
            Dim strSql, strModelDesc As String
            Dim dt, dtSOHeader As DataTable
            Dim objSO As Buisness.Fullfillment.WriteOrders
            Dim iSOHeaderID, i As Integer
            Dim R1 As DataRow

            Try
                strModelDesc = Generic.GetModelDesc(iModelID)
                strSql = "SELECT A.WO_ID, A.Cust_ID, A.ClaimNo as 'Work Order', A.Date as OrderDate" & Environment.NewLine
                strSql &= ", A.Cust2PSSI_TrackNo as InboundTrackingNumber, A.ShipTo_Name " & Environment.NewLine
                strSql &= ", A.Address1, if (A.Address2 is null, '', A.Address2 ) as Address2 " & Environment.NewLine
                strSql &= ", A.City, State_Shortname as 'State' " & Environment.NewLine
                strSql &= ", if(A.Tel is null, '', A.Tel) as Tel" & Environment.NewLine
                strSql &= ", if(Email is null, '', Email) as Email, ZipCode, Cntry_Name, C.WO_Quantity as Qty " & Environment.NewLine
                strSql &= ", IF(NI_Prod_Desc is null, '', NI_Prod_Desc) as 'ProductName' " & Environment.NewLine
                strSql &= "FROM extendedwarranty A" & Environment.NewLine
                strSql &= "INNER JOIN tworkorder C ON A.WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN ni_products D ON A.Prod_Code = D.NI_Prod_ID " & Environment.NewLine
                strSql &= "WHERE A.WO_ID = " & iWOID
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    Throw New Exception("System can't find order information for this device.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate order. Please contact IT.")
                Else
                    objSO = New Buisness.Fullfillment.WriteOrders()
                    R1 = dt.Rows(0)
                    Dim decOrderSubTotal As Decimal = 0

                    dtSOHeader = objSO.GetSOHeader(NI.CUSTOMERID, R1("Work Order").ToString)
                    If dtSOHeader.Rows.Count > 1 Then
                        Throw New Exception("Duplicate sale order header. Please contact IT.")
                    ElseIf dtSOHeader.Rows.Count = 1 Then
                        strMsg = "Fulfillment order has already existed."
                    Else
                        iSOHeaderID = objSO.AddSaleOrderHeader(Convert.ToInt32(R1("Cust_ID")), R1("ShipTo_Name").ToString, "", R1("Address1").ToString, _
                                                             R1("Address2").ToString, "", R1("City").ToString, R1("State").ToString, _
                                                             R1("ZipCode").ToString, R1("Cntry_Name").ToString, R1("Tel").ToString, _
                                                             R1("Email").ToString, R1("Work Order").ToString, R1("Work Order").ToString, _
                                                             Convert.ToInt32(R1("WO_ID")), R1("OrderDate").ToString, decOrderSubTotal, 0, 0, 0, 0, R1("InboundTrackingNumber").ToString, iUsrID)

                        i = objSO.AddSaleOrderDetails(iSOHeaderID, strModelDesc, R1("ProductName").ToString, Convert.ToInt32(R1("Qty")), _
                                                      strUnitOfMeasure, 0.0, 0.0, 0.0, 0.0, "", 0.0, strModelDesc, iModelID, strDevConditionID, iCosmGradeID)
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function SetInboundCosmeticGrade(ByVal iDeviceID As Integer, ByVal iCosmGradeID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE tcellopt SET InBoundCosmGrade = " & iCosmGradeID & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function UpdateSelfInflicted(ByVal iDeviceID As Integer, ByVal iDcodeID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE warehouse.warehouse_Items SET SelfInflicted = " & iDcodeID & Environment.NewLine
                strSql &= " WHERE Device_ID = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function Label_ReceiveBoxLabel_NI_EndUSer(ByVal DeviceID As Integer, _
                                              ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "select Device_SN as Serial, model_desc as Model, DATE_FORMAT(Device_dateRec,'%m/%d/%y') as RecPalletName from tdevice" & Environment.NewLine
                strsql &= " inner join tmodel on tdevice.model_ID=tmodel.model_ID" & Environment.NewLine
                strsql &= "WHERE tdevice.Device_ID = " & DeviceID

                dt = Me._objDataProc.GetDataTable(strsql)
                objRpt = New ReportDocument()

                With objRpt
                    '.Load(PSS.Data.ConfigFile.GetBaseReportPath & "Syx_Receive_Box_Label.rpt")
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "NI_Receive_Box_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function Label_ReceiveBoxLabel_NI_BulkWarehouse(ByVal strSN As String, _
                                                               ByVal strDate As String, _
                                                               ByVal iModelID As String, _
                                                               ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "select '" & strSN & "' as Serial, model_desc as Model, '" & strDate & "' as RecPalletName" & Environment.NewLine
                strsql &= " from tmodel" & Environment.NewLine
                strsql &= "WHERE model_ID = " & iModelID

                dt = Me._objDataProc.GetDataTable(strsql)
                objRpt = New ReportDocument()

                With objRpt
                    '.Load(PSS.Data.ConfigFile.GetBaseReportPath & "Syx_Receive_Box_Label.rpt")
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "NI_Receive_Box_Label.rpt")
                    dt = Me._objDataProc.GetDataTable(strsql)
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function
        '********************************************************************************
        Public Function GetNI_DeviceInfoInWIP(ByVal strSN As String, _
                                                 ByVal iCustID As Integer, _
                                                 ByVal iLocID As Integer) As DataTable
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Dim dt As DataTable

            Try

                strsql = "select Device_SN as Serial, model_desc as Model, DATE_FORMAT(Device_dateRec,'%m/%d/%y') as RecPalletName from tdevice" & Environment.NewLine
                strsql &= " inner join tmodel on tdevice.model_ID=tmodel.model_ID" & Environment.NewLine
                strsql &= " where Device_DateShip is null and loc_ID=" & iLocID & " and Device_SN ='" & strSN & "'" & Environment.NewLine
                strsql &= " union all" & Environment.NewLine
                strsql &= " SELECT a.Serial,c.model_desc model,DATE_FORMAT(b.Receipt_Date,'%m/%d/%y') as RecPalletName  FROM warehouse.warehouse_items a" & Environment.NewLine
                strsql &= "inner join  warehouse.warehouse_receipt b on a.wr_id = b.wr_id" & Environment.NewLine
                strsql &= " inner join production.tmodel c on c.model_id=a.model_id" & Environment.NewLine
                strsql &= " where b.cust_id = " & iCustID & " and (a.SODetailsID=0 or Device_ID =0) and a.Serial='" & strSN & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strsql)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '********************************************************************************
        Public Function Label_ReceiveBoxLabel_Reprint(ByVal dt As DataTable, _
                                                      ByVal iCopies As Integer) As Integer
            Dim strsql As String = ""
            Dim objRpt As ReportDocument
            Try
                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "NI_Receive_Box_Label.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*************************************************************************************
        Public Function GetOpenWHSNItem(ByVal iLocID As Integer, ByVal strSN As String) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT A.*, B.WO_ID" & Environment.NewLine
                strsql &= "FROM warehouse.warehouse_items A" & Environment.NewLine
                strsql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID = B.WR_ID" & Environment.NewLine
                strsql &= "WHERE B.Cust_ID = " & iLocID & " AND A.Serial = '" & strSN & "'" & Environment.NewLine
                strsql &= "AND A.Device_ID = 0 AND A.SODetailsID = 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strsql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function CalPSSIWarranty(ByVal strSerial As String, ByVal dteRecDate As DateTime) As Integer
            Dim strsql As String = ""
            Dim dt As DataTable
            Dim iPSSWrty As Integer = 0
            Dim dteLastDateInWrty As DateTime

            Try
                dteRecDate = Convert.ToDateTime(dteRecDate.ToString("yyyy-MM-dd"))
                strsql = "SELECT ShipDate FROM warehouse.warehouse_items A" & Environment.NewLine
                strsql &= "INNER JOIN saleorders.SODetails B ON A.SODetailsID = B.SODetailsID" & Environment.NewLine
                strsql &= "INNER JOIN saleorders.SOHeader C ON B.SOHeaderID = C.SOHeaderID" & Environment.NewLine
                strsql &= "WHERE A.Serial = '" & strSerial & "'" & Environment.NewLine
                strsql &= "AND A.DevConditionID = 3857 AND C.Cust_ID = " & NI.CUSTOMERID & Environment.NewLine
                strsql &= "AND C.ShipDate is not null " & Environment.NewLine
                strsql &= "ORDER BY ShipDate DESC"
                dt = Me._objDataProc.GetDataTable(strsql)

                If dt.Rows.Count > 0 Then
                    dteLastDateInWrty = Convert.ToDateTime(Convert.ToDateTime(dt.Rows(0)("ShipDate")).ToString("yyyy-MM-dd"))
                    dteLastDateInWrty = DateAdd(DateInterval.Day, 90, dteLastDateInWrty)
                    If DateDiff(DateInterval.Day, dteRecDate, dteLastDateInWrty) >= 0 Then iPSSWrty = 1
                End If

                Return iPSSWrty
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
        Public Function GetNIInboundOrder(ByVal strClaimNo As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WO_Quantity " & Environment.NewLine
                strSql &= ", if( extendedwarranty.NI_DataSwitch = 1, 'End User', if(extendedwarranty.NI_DataSwitch = 2, 'Bulk', 'Undefine')) as 'WO Type' " & Environment.NewLine
                strSql &= ", extendedwarranty.*" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN extendedwarranty On tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= "WHERE tworkorder.Loc_ID = " & NI.LOCID & " AND InvalidOrder = 0 " & Environment.NewLine
                strSql &= "AND extendedwarranty.Cust_ID = " & NI.CUSTOMERID & Environment.NewLine
                strSql &= "AND extendedwarranty.ClaimNo = '" & strClaimNo & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*************************************************************************************
        Public Function GetNIAggregateCharge(ByVal iCust_ID As Integer, ByVal iBillCode_ID As Integer) As DataTable
            Dim strSql As String = ""

            'cust_ID=2531 (NI), BillCode_ID=3019 (Receive and Reconcile RMA (SC 200))
            Try
                strSql = "SELECT A.BillCode_ID,B.BillCode_Desc,A.tCab_Amount,A.Tcab_ID" & Environment.NewLine
                strSql &= " FROM tcustaggregatebilling A" & Environment.NewLine
                strSql &= " inner join lbillcodes B on A.Billcode_ID=B.BillCode_ID" & Environment.NewLine
                strSql &= " where cust_ID=" & iCust_ID & " and A.BillCode_ID=" & iBillCode_ID & ";" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetKeyboardSpecialProject_DeviceData(Optional ByVal iDevice_ID As Integer = 0, _
                                                             Optional ByVal strDevice_SN As String = "") As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.Device_ID,A.Device_SN,A.Model_ID,G.Model_Desc,A.Device_DateRec,A.Device_DateBill,A.Device_DateShip" & Environment.NewLine
                strSQL &= " ,B.BillCode_ID,C.BillCode_Desc,D.QCResult_ID,D.PTtf AS 'TestResultCode'" & Environment.NewLine
                strSQL &= " ,E.Dcode_Ldesc AS 'TestResult',A.Device_LaborCharge,F.tcab_Amount" & Environment.NewLine
                strSQL &= " FROM tDevice A" & Environment.NewLine
                strSQL &= " INNER JOIN tDeviceBill B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lBillcodes C ON B.Billcode_ID=C.Billcode_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tPretest_Data D ON A.Device_ID=D.Device_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lCodesDetail E ON D.PTtf=E.DCode_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tCustAggregateBilling F ON B.Billcode_ID=F.Billcode_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tModel G ON A.Model_ID=G.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Billcode_ID IN (2933,2934,2935,2936,2937,2938)" & Environment.NewLine
                If iDevice_ID > 0 Then strSQL &= " AND A.Device_ID=" & iDevice_ID & Environment.NewLine
                If strDevice_SN.Trim.Length > 0 Then strSQL &= " AND A.Device_SN='" & strDevice_SN.Replace("'", "''") & "'" & Environment.NewLine
                strSQL &= " order by A.Device_DateBill;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************
    End Class
End Namespace