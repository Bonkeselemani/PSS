Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.Text

Namespace Buisness.TracFone

    Public Class Receive
        Private _objDataProc As DBQuery.DataProc
        Private _DeKitDeTrash_BillOcde_ID As Single = 4333
        Private _DeKitDeTrash_PartNum As String = "S0"

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

#Region "Warehouse Receiving"

        '******************************************************************
        Public Function LoadOpenOrders() As DataTable
            Dim strSql As String
            Dim dt, dtOrderCustomer As DataTable
            Dim row As DataRow

            Try
                strSql = "SELECT DISTINCT C.*, A.Order_ID, A.RequestDate, A.IL_No, B.VN_ItemNo as 'Customer Item #', B.Model_ID, D.cust_MaterialCategory, E.Manuf_ID, E.Model_GSM " & Environment.NewLine
                strSql &= ",'' AS 'InboundOrderCustomer'" & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.torderdetail B on A.Order_ID = B.Order_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tworkorder C ON A.PSS_WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcustmodel_pssmodel_map D ON B.Model_ID = D.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel E ON D.Model_ID = E.Model_ID " & Environment.NewLine
                strSql &= "WHERE A.Order_Type = 'IN' AND C.WO_Closed = 0 "
                'AND D.cust_MaterialCategory = 'PHONE'; " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                'update InboundOrderCustomer
                For Each row In dt.Rows
                    strSql = "select * from edi.taddress where orderNo ='" & row("WO_CustWO") & "' and EntityIdentifierCode ='SF';"
                    dtOrderCustomer = Me._objDataProc.GetDataTable(strSql)
                    If dtOrderCustomer.Rows.Count > 0 Then
                        row.BeginEdit() : row("InboundOrderCustomer") = dtOrderCustomer.Rows(0).Item("Name") : row.AcceptChanges()
                    End If
                Next
                dt.LoadDataRow(New Object() {"0", "--Select--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function getNTF_XModelData(ByVal strInboundOrderItem As String) As DataTable
            Dim strSql As String
            Dim dt As DataTable
            Dim strArrList As New ArrayList()
            Dim strS As String = "", s As String = ""

            Try
                strSql = "select * from tmodel where model_desc ='" & strInboundOrderItem.Trim.Replace("'", "''") & "';"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateNTF_InboundOrderXModel(ByVal iOrderID As Integer, ByVal iModel_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "update edi.torderdetail set Model_ID = " & iModel_ID & " where order_ID =" & iOrderID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function getNTF_InboundOrderCustomers(Optional ByVal strInboundOrderCustomers As String = "") As ArrayList
            Dim strSql As String
            Dim dt As DataTable
            Dim strArrList As New ArrayList()
            Dim strS As String = "", s As String = ""

            Try
                strSql = "SELECT * FROM exceptioncriteria WHERE Description ='TF_NTF_INBOUND_ORDER_CUSTOMERS';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strS = dt.Rows(0).Item("Names")
                    Dim arrS As String() = strS.Split(New Char() {";"c})
                    For Each s In arrS
                        strArrList.Add(s.Trim.ToUpper)
                        If s.Trim.Length > 0 Then
                            If strInboundOrderCustomers.Trim.Length = 0 Then
                                strInboundOrderCustomers = "'" & s.Trim.Replace("'", "''").ToUpper & "'"
                            Else
                                strInboundOrderCustomers = ",'" & s.Trim.Replace("'", "''").ToUpper & "'"
                            End If
                        End If
                    Next
                End If
                Return strArrList
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetTFDeviceASNData(ByVal iOrder_ID As Integer, _
                                            ByVal boolRecordWithoutDeviceID As Boolean, _
                                            Optional ByVal strSN As String = "") As DataTable
            Dim strSql As String
            Try
                strSql &= "SELECT * FROM edi.titem  " & Environment.NewLine
                strSql &= "WHERE Order_ID = " & iOrder_ID & " " & Environment.NewLine
                If strSN.Trim.Length > 0 Then strSql &= "AND SN = '" & strSN & "' " & Environment.NewLine
                If boolRecordWithoutDeviceID = True Then strSql &= "AND Device_ID is null " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ReceiveDeviceIntoWIP(ByRef dtWHBox As DataTable, _
                                             ByVal iItemID As Integer, _
                                             ByVal iWOID As Integer, _
                                             ByVal iTrayID As Integer, _
                                             ByVal strIMEI As String, _
                                             ByVal iModelID As Integer, _
                                             ByVal iManufWrty As Integer, _
                                             ByVal iShiftID As Integer, _
                                             ByVal iUserID As Integer, _
                                             ByVal strMSN As String, _
                                             ByVal strManufDateCode As String, _
                                             ByVal strLastDateInWrty As String, _
                                             ByVal strAPC As String, _
                                             ByVal iManufID As Integer, _
                                             ByVal iMaxBoxQty As Integer, _
                                             ByVal iManufacturingCountryID As Integer, _
                                             ByVal strWorkstation As String, _
                                             Optional ByVal bIsWFM_To_TF As Boolean = False, _
                                             Optional ByVal bIsXModel As Boolean = False) As Integer
            Dim strSql As String
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim iDeviceID, iSeqNo, i As Integer
            Dim strCelloptIMEI, strCellOpt_DateCode, strCellOpt_CSN_Dec, strCellOpt_CSN, strCellopt_ProdCode As String
            Dim booSetWrtyReceiptDate As Boolean = False

            Try
                If strMSN.Trim.Length = 0 Then strMSN = "NULL"
                If strAPC.Trim.Length = 0 Then strAPC = "NULL"
                strCelloptIMEI = "NULL" : strCellOpt_DateCode = "NULL"
                strCellOpt_CSN_Dec = "NULL" : strCellOpt_CSN = "NULL" : strCellopt_ProdCode = "NULL"
                If strLastDateInWrty.Trim.Length > 0 Then booSetWrtyReceiptDate = True

                If strIMEI.Trim.Length >= 15 AndAlso strIMEI.Trim.Length < 17 Then
                    strCelloptIMEI = strIMEI
                ElseIf strIMEI.Trim.Length > 17 Then
                    strCellOpt_CSN_Dec = strIMEI
                    If iManufID = 21 Then
                        strCellOpt_CSN = Me.ConvertDecIMEIToHexFormat(strIMEI.Trim)
                        If strCellOpt_CSN.Trim.Length = 0 Then strCellOpt_CSN = "NULL"
                    End If
                End If
                strCellOpt_DateCode = strManufDateCode

                If iManufID = 24 AndAlso strMSN.Trim.Length > 7 Then strCellopt_ProdCode = strMSN.Substring(0, 7)

                If iManufWrty = -1 Then iManufWrty = 0
                iDeviceID = 0 : iSeqNo = 0 : i = 0

                iSeqNo = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                '1:Write to tdevice
                iDeviceID = objRec.InsertIntoTdevice(strIMEI, PSS.Data.Buisness.Generic.GetWorkDate(iShiftID), iSeqNo, iTrayID, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID, iWOID, iModelID, iShiftID, , iManufWrty, , )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert a record into tdevice.")

                '2:Write to tcellopt
                i = objRec.InsertIntoTCellopt(iDeviceID, strMSN, strCelloptIMEI, strCellOpt_CSN, strCellOpt_CSN_Dec, , , , strAPC, strCellOpt_DateCode, , , , , , , strWorkstation, strCellopt_ProdCode)

                If i = 0 Then Throw New Exception("System has failed to insert a record into tcellopt.")

                '3:Update titem
                i = UpdateDeviceIDToItemTable(iDeviceID, iItemID, dtWHBox.Rows(0)("BoxID"), dtWHBox.Rows(0)("wb_id"), iUserID, dtWHBox.Rows(0)("FuncRep"), strManufDateCode, strLastDateInWrty, iManufacturingCountryID, booSetWrtyReceiptDate)
                If i = 0 Then Throw New Exception("System has failed to write device ID into titem table.")

                dtWHBox.Rows(0).BeginEdit()
                dtWHBox.Rows(0)("Qty") = dtWHBox.Rows(0)("Qty") + 1
                dtWHBox.Rows(0).EndEdit()
                dtWHBox.AcceptChanges()

                If Not bIsWFM_To_TF AndAlso dtWHBox.Rows(0)("Qty") >= iMaxBoxQty Then
                    'Close Box & print Warehouse box
                    i = Me.CloseAndPrintWarehouseBox(dtWHBox.Rows(0))
                    MessageBox.Show("Devices have been pushed to " & strWorkstation & " work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                'add labor charge for XModel receiving=========================================================
                If bIsXModel Then
                    Dim objTFBilling As New PSS.Data.Buisness.TracFone.TFBillingData()
                    Dim vReceivingLaborCharge As Single = objTFBilling.getAdditionalLaborCharge(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Me._DeKitDeTrash_BillOcde_ID)
                    i = objTFBilling.InsertUpdateAddionalCharges(iDeviceID, Me._DeKitDeTrash_BillOcde_ID, vReceivingLaborCharge, _
                                                                 Me._DeKitDeTrash_PartNum, Format(Now, "yyyy-MM-dd HH:mm:ss"), iUserID)
                End If
                '===============================================================================================

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        Public Function ReceiveWFM2TF_DeviceIntoWIP(ByRef dtWHBox As DataTable, _
                                      ByVal iItemID As Integer, _
                                      ByVal iWOID As Integer, _
                                      ByVal iTrayID As Integer, _
                                      ByVal strIMEI As String, _
                                      ByVal iModelID As Integer, _
                                      ByVal iManufWrty As Integer, _
                                      ByVal iShiftID As Integer, _
                                      ByVal iUserID As Integer, _
                                      ByVal strMSN As String, _
                                      ByVal strManufDateCode As String, _
                                      ByVal strLastDateInWrty As String, _
                                      ByVal strAPC As String, _
                                      ByVal iManufID As Integer, _
                                      ByVal iMaxBoxQty As Integer, _
                                      ByVal iManufacturingCountryID As Integer, _
                                      ByVal strWorkstation As String, _
                                      Optional ByVal bIsWFM_To_TF As Boolean = False) As Integer
            Dim strSql As String
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim iDeviceID, iSeqNo, i As Integer
            Dim strCelloptIMEI, strCellOpt_DateCode, strCellOpt_CSN_Dec, strCellOpt_CSN, strCellopt_ProdCode As String
            Dim booSetWrtyReceiptDate As Boolean = False

            Try
                If strMSN.Trim.Length = 0 Then strMSN = "NULL"
                If strAPC.Trim.Length = 0 Then strAPC = "NULL"
                strCelloptIMEI = "NULL" : strCellOpt_DateCode = "NULL"
                strCellOpt_CSN_Dec = "NULL" : strCellOpt_CSN = "NULL" : strCellopt_ProdCode = "NULL"
                If strLastDateInWrty.Trim.Length > 0 Then booSetWrtyReceiptDate = True

                If strIMEI.Trim.Length >= 15 AndAlso strIMEI.Trim.Length < 17 Then
                    strCelloptIMEI = strIMEI
                ElseIf strIMEI.Trim.Length > 17 Then
                    strCellOpt_CSN_Dec = strIMEI
                    If iManufID = 21 Then
                        strCellOpt_CSN = Me.ConvertDecIMEIToHexFormat(strIMEI.Trim)
                        If strCellOpt_CSN.Trim.Length = 0 Then strCellOpt_CSN = "NULL"
                    End If
                End If
                strCellOpt_DateCode = strManufDateCode

                If iManufID = 24 AndAlso strMSN.Trim.Length > 7 Then strCellopt_ProdCode = strMSN.Substring(0, 7)

                If iManufWrty = -1 Then iManufWrty = 0
                iDeviceID = 0 : iSeqNo = 0 : i = 0

                iSeqNo = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                '1:Write to tdevice
                iDeviceID = objRec.InsertIntoTdevice(strIMEI, PSS.Data.Buisness.Generic.GetWorkDate(iShiftID), iSeqNo, iTrayID, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID, iWOID, iModelID, iShiftID, , iManufWrty, , )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert a record into tdevice.")

                '2:Write to tcellopt
                i = objRec.InsertIntoTCellopt(iDeviceID, strMSN, strCelloptIMEI, strCellOpt_CSN, strCellOpt_CSN_Dec, , , , strAPC, strCellOpt_DateCode, , , , , , , strWorkstation, strCellopt_ProdCode)

                If i = 0 Then Throw New Exception("System has failed to insert a record into tcellopt.")

                '3:Update titem
                i = UpdateDeviceIDToItemTable(iDeviceID, iItemID, dtWHBox.Rows(0)("BoxID"), dtWHBox.Rows(0)("wb_id"), iUserID, dtWHBox.Rows(0)("FuncRep"), strManufDateCode, strLastDateInWrty, iManufacturingCountryID, booSetWrtyReceiptDate)
                If i = 0 Then Throw New Exception("System has failed to write device ID into titem table.")

                'dtWHBox.Rows(0).BeginEdit()
                'dtWHBox.Rows(0)("Qty") = dtWHBox.Rows(0)("Qty") + 1
                'dtWHBox.Rows(0).EndEdit()
                'dtWHBox.AcceptChanges()

                'If Not bIsWFM_To_TF AndAlso dtWHBox.Rows(0)("Qty") >= iMaxBoxQty Then
                '    'Close Box & print Warehouse box
                '    i = Me.CloseAndPrintWarehouseBox(dtWHBox.Rows(0))
                '    MessageBox.Show("Devices have been pushed to " & strWorkstation & " work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function ConvertDecIMEIToHexFormat(ByVal strDecIMEI As String) As String
            Dim str1Set, str2Set, str1SetHex, str2SetHex As String
            Dim i As Integer = 0

            Try
                str1Set = "" : str2Set = "" : str1SetHex = "" : str2SetHex = ""

                If strDecIMEI.Trim.Length <> 18 Then Return ""

                For i = 0 To strDecIMEI.Trim.Length - 1
                    If Char.IsDigit(strDecIMEI.Substring(i, 1)) = False Then Return ""
                Next i

                str1Set = Microsoft.VisualBasic.Left(strDecIMEI.Trim, 10)
                str2Set = Microsoft.VisualBasic.Right(strDecIMEI.Trim, 8)

                str1SetHex = (Convert.ToInt64(str1Set)).ToString("X")
                str2SetHex = (Convert.ToInt64(str2Set)).ToString("X")

                Return str1SetHex & str2SetHex.PadLeft(6, "0")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function UpdateDeviceIDToItemTable(ByVal iDeviceID As Integer, _
                                                   ByVal iItemID As Integer, _
                                                   ByVal strBox As String, _
                                                   ByVal iWHBoxID As Integer, _
                                                   ByVal iUsrID As Integer, _
                                                   ByVal iFuncRep As Integer, _
                                                   ByVal strManufDateCode As String, _
                                                   ByVal strLastDateInWrty As String, _
                                                   ByVal iManufacturingCountryID As Integer, _
                                                   ByVal booSetWrtyReceiptDate As Boolean) As Integer
            Dim strSql As String
            Try
                strSql &= "UPDATE edi.titem  " & Environment.NewLine
                strSql &= "SET Device_ID = " & iDeviceID & " " & Environment.NewLine
                strSql &= ", Recvd_UsrID = " & iUsrID & " " & Environment.NewLine
                strSql &= ", BoxID = '" & strBox & "' " & Environment.NewLine
                strSql &= ", wb_id = " & iWHBoxID & " " & Environment.NewLine
                strSql &= ", FuncRep = " & iFuncRep & " " & Environment.NewLine
                strSql &= ", Manuf_Date = '" & strManufDateCode.Trim & "'" & Environment.NewLine
                If Not IsNothing(strLastDateInWrty) AndAlso strLastDateInWrty.Trim.Length > 0 Then strSql &= ", LastDateInWrty = '" & strLastDateInWrty & "'" & Environment.NewLine
                strSql &= ", mc_id = " & iManufacturingCountryID & Environment.NewLine
                If booSetWrtyReceiptDate = True Then strSql &= ", WrtyClaimReceiptDt = now() " & Environment.NewLine
                strSql &= "WHERE Item_ID = " & iItemID & ";" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateWFMCocFunProductionCompleted(ByVal strDeviceIDs As String, ByVal iWHB_ID As Integer, ByVal iWFM2TF_WB_ID As Integer) As Integer
            Dim strSql As String
            Dim strDTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim i As Integer = 0

            Try
                strSql &= "UPDATE production.tdevice  " & Environment.NewLine
                strSql &= "SET Device_DateShip = '" & strDTime & "' " & Environment.NewLine
                strSql &= ",Device_ShipWorkDate = '" & strDTime & "' " & Environment.NewLine
                strSql &= "WHERE Device_ID in ( " & strDeviceIDs & ");" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE warehouse.wh_box SET WFM2TF_wb_ID = " & iWFM2TF_WB_ID & " WHERE whb_id = " & iWHB_ID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function CloseWO(ByVal iWO_ID As Integer, _
                                ByVal iQty As Integer, _
                                ByVal iUsrID As Integer, _
                                ByVal strDockDate As String, _
                                ByVal booDiscrepancy As Boolean, _
                                ByVal strDeviceType As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE production.tworkorder, edi.torder " & Environment.NewLine
                strSql &= "SET WO_RAQnty = " & iQty & ", WO_Closed = 1, edi.torder.Order_RcvdDate = now(), edi.torder.WO_ClosedDate = now(), WO_ClosedUsrID = " & iUsrID & Environment.NewLine
                strSql &= ", WO_DateDock = '" & strDockDate & "'" & Environment.NewLine
                strSql &= "WHERE production.tworkorder.WO_ID = edi.torder.PSS_WO_ID " & Environment.NewLine
                strSql &= "AND production.tworkorder.WO_ID = " & iWO_ID & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If strDeviceType = "PHONE" AndAlso booDiscrepancy = True Then
                    strSql = "UPDATE edi.titem A " & Environment.NewLine
                    strSql &= "INNER JOIN edi.torder B ON A.Order_ID = B.Order_ID " & Environment.NewLine
                    strSql &= "SET DiscrepancyReason = 'Missing Item' " & Environment.NewLine
                    strSql &= "WHERE B.PSS_WO_ID = " & iWO_ID & Environment.NewLine
                    strSql &= "AND A.Device_ID is null " & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDiscrepancyDevices(ByVal iOrderID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) FROM edi.titem " & Environment.NewLine
                strSql &= "WHERE Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND (DiscrepancyReason is not null or DiscrepancyReason <> '' ) " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetReceivedDevices(ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Device_Cnt as Cnt, Device_SN as SN, C.BoxID, Model_Desc as Model, Device_DateRec as 'Receipt Date', A.Device_ID " & Environment.NewLine
                strSql &= ", if( Manuf_Date is null, '', Manuf_Date) as 'Manuf Date' " & Environment.NewLine
                strSql &= ", if( C.FuncRep = 0, 'No', 'Yes') as 'FUN Rep?' " & Environment.NewLine
                strSql &= ", if( Device_ManufWrty = 0, 'No', 'Yes') as 'In Warranty?' " & Environment.NewLine
                strSql &= ", if( DiscrepancyReason is not null, DiscrepancyReason, '') as 'Discp Reason' " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.titem C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "WHERE A.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "Order By Cnt Desc " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetToBeReceivedDevices(ByVal iOrderID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT SN, VN_ItemNo as 'Item#'  " & Environment.NewLine
                strSql &= ", IF(DiscrepancyReason is null, '', DiscrepancyReason) as DiscrepancyReason " & Environment.NewLine
                strSql &= ", IF(Device_ID is null, 0, Device_ID) as Device_ID " & Environment.NewLine
                strSql &= "FROM edi.titem A " & Environment.NewLine
                strSql &= "WHERE A.Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND ( Device_ID is null or Device_ID = 0 ) " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetWHBox(ByVal iOrderID As Integer, _
                                 ByVal iFuncRep As Integer, _
                                 ByVal iWrtyFlag As Integer, _
                                 ByVal iWrtyExpInLess31Days As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.*, B.Model_Desc, C.OrderNo, count(D.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.torder C ON A.Order_ID = C.Order_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem D ON A.wb_id = D.wb_id " & Environment.NewLine
                strSql &= "WHERE A.Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND A.FuncRep = " & iFuncRep & Environment.NewLine
                strSql &= "AND WarrantyFlag = " & iWrtyFlag & Environment.NewLine
                strSql &= "AND Closed = 0 " & Environment.NewLine
                strSql &= "AND WrtyExpedite = " & iWrtyExpInLess31Days & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine
                strSql &= "ORDER BY A.wb_id " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetWFM_WHBox(ByVal strBoxName As String, ByRef bIsNTFBox As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                'SOF, FUN, COS (boxname starts with "S","C","F")
                strSql = "select C.Model_Desc as 'WFM_Model','' as 'TF Model',B.Device_SN,A.BoxID as 'BoxName',E.Disp_cd as 'Disp'" & Environment.NewLine
                strSql &= " ,D.quantity,A.whb_id,B.Device_ID,D.disp_id,D.cust_id,B.Loc_ID,B.Model_ID as 'WFM_Model_ID'" & Environment.NewLine
                strSql &= " from edi.titem A" & Environment.NewLine
                strSql &= " inner join tdevice B on A.device_id = B.device_id" & Environment.NewLine
                strSql &= " inner join tmodel C on B.model_id=C.model_ID" & Environment.NewLine
                strSql &= " inner join warehouse.wh_box D on A.whb_id=D.whb_id" & Environment.NewLine
                strSql &= " inner join production.tdispositions E on D.disp_id=E.disp_id" & Environment.NewLine
                strSql &= " where not D.WFM2TF_wb_ID >0 and D.disp_id in (2,3,4) and A.BoxId ='" & strBoxName.Replace("'", "''") & "';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If Not dt.Rows.Count > 0 Then
                    'REC (Boxname starts with "R")
                    strSql = " select C.Model_Desc as 'WFM_Model','' as 'TF Model',B.Device_SN,D.Box_Na as 'BoxName',E.Disp_cd as 'Disp'" & Environment.NewLine
                    strSql &= "  ,D.quantity,A.whb_id,B.Device_ID,D.disp_id,D.cust_id,B.Loc_ID,B.Model_ID as 'WFM_Model_ID'" & Environment.NewLine
                    strSql &= "  from edi.titem A" & Environment.NewLine
                    strSql &= "  inner join tdevice B on A.device_id = B.device_id" & Environment.NewLine
                    strSql &= "  inner join tmodel C on B.model_id=C.model_ID" & Environment.NewLine
                    strSql &= "  inner join warehouse.wh_box D on A.whb_id=D.whb_id" & Environment.NewLine
                    strSql &= "  inner join production.tdispositions E on D.disp_id=E.disp_id" & Environment.NewLine
                    strSql &= "  where not D.WFM2TF_wb_ID >0 and D.disp_id in (0) and D.Box_Na ='" & strBoxName.Replace("'", "''") & "';" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                'NTF  (Pallett_Name as boxname starts with "N")
                If Not dt.Rows.Count > 0 Then
                    strSql = " select C.Model_Desc as 'WFM_Model','' as 'TF Model',B.Device_SN,D.Pallett_Name as 'BoxName',E.Disp_cd as 'Disp'" & Environment.NewLine
                    strSql &= "  ,D.Pallett_Qty as 'quantity',A.whb_id,B.Device_ID,D.disp_id,D.cust_id,B.Loc_ID,B.Model_ID as 'WFM_Model_ID'" & Environment.NewLine
                    strSql &= "  from edi.titem A" & Environment.NewLine
                    strSql &= "  inner join tdevice B on A.device_id = B.device_id" & Environment.NewLine
                    strSql &= "  inner join tmodel C on B.model_id=C.model_ID" & Environment.NewLine
                    strSql &= "  inner join tpallett D on B.pallett_id=D.pallett_id" & Environment.NewLine
                    strSql &= "  inner join production.tdispositions E on D.disp_id=E.disp_id" & Environment.NewLine
                    strSql &= " inner join tcellopt F on B.device_id = F.device_id" & Environment.NewLine
                    strSql &= "  where D.disp_id =5 and B.loc_ID=3402 and F.WorkStation ='WH-FLOOR' and D.Pallett_Name ='" & strBoxName.Replace("'", "''") & "';" & Environment.NewLine

                    bIsNTFBox = True
                    dt = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetCustIDBySN(ByVal strSN As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "select A.Device_ID,A.Device_SN,A.Loc_ID,B.Cust_ID from tdevice A"
                strSql &= " inner join tlocation B on A.Loc_ID=B.Loc_ID where A.Device_dateShip is null and device_SN ='" & strSN & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRet = dt.Rows(0).Item("Cust_ID")
                End If
                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function IsSN_WFM2TFAlreadyReceived(ByVal strSN As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim bRet As Boolean = False

            Try
                strSql = "select B.IsWFM,A.Model_ID,A.device_ID,A.Device_SN,B.Order_ID,B.WHRNO_ID ,B.BOXID,B.wb_ID,B.whb_ID" & Environment.NewLine
                strSql &= " from tdevice A" & Environment.NewLine
                strSql &= " inner join edi.titem B on A.Device_ID=B.Device_ID" & Environment.NewLine
                strSql &= "  where device_SN = '" & strSN.Replace("'", "''") & "'" & Environment.NewLine
                strSql &= "  and IsWFM=1 and loc_ID=" & PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    bRet = True
                End If
                Return bRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetWFM_DeviceID(ByVal strSN As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "select C.Model_Desc as 'WFM_Model',B.Device_SN,A.BoxID as 'BoxName',E.Disp_cd as 'Disp',D.quantity,A.whb_id,B.Device_ID,D.disp_id,D.cust_id,B.Loc_ID" & Environment.NewLine
                strSql &= " from edi.titem A" & Environment.NewLine
                strSql &= " inner join tdevice B on A.device_id = B.device_id" & Environment.NewLine
                strSql &= " inner join tmodel C on B.model_id=C.model_ID" & Environment.NewLine
                strSql &= " inner join warehouse.wh_box D on A.whb_id=D.whb_id" & Environment.NewLine
                strSql &= " inner join production.tdispositions E on D.disp_id=E.disp_id" & Environment.NewLine
                strSql &= " where B.Device_SN ='" & strSN.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRet = dt.Rows(0).Item("Device_ID")
                End If
                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function GetTF_ModelID(ByVal iWFM_Model_ID As Integer, ByVal iWFM_Disp_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "SELECT A.*,D.Disp_CD,B.Model_Desc as 'WFM Model_Desc',C.Model_desc as 'TF Model_desc'" & Environment.NewLine
                strSql &= " FROM edi.twfm_tf_model_map A" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel B ON A.WFM_Model_ID=B.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tmodel C ON A.TF_Model_ID=C.Model_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tdispositions D ON A.WFM_Disp_ID=D.Disp_ID" & Environment.NewLine
                strSql &= " WHERE A.WFM_Model_ID = " & iWFM_Model_ID & " AND A.WFM_Disp_ID=" & iWFM_Disp_ID & ";" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRet = dt.Rows(0).Item("TF_Model_ID")
                End If
                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetWFM_WHB_ID(ByVal strSN As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iRet As Integer = 0

            Try
                strSql = "select C.Model_Desc as 'WFM_Model',B.Device_SN,A.BoxID as 'BoxName',E.Disp_cd as 'Disp',D.quantity,A.whb_id,B.Device_ID,D.disp_id,D.cust_id,B.Loc_ID" & Environment.NewLine
                strSql &= " from edi.titem A" & Environment.NewLine
                strSql &= " inner join tdevice B on A.device_id = B.device_id" & Environment.NewLine
                strSql &= " inner join tmodel C on B.model_id=C.model_ID" & Environment.NewLine
                strSql &= " inner join warehouse.wh_box D on A.whb_id=D.whb_id" & Environment.NewLine
                strSql &= " inner join production.tdispositions E on D.disp_id=E.disp_id" & Environment.NewLine
                strSql &= " where B.Device_SN ='" & strSN.Replace("'", "''") & "';" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iRet = dt.Rows(0).Item("whb_ID")
                End If
                Return iRet
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function GetDockRecDate(ByVal iWOID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strDockRecDate As String = ""

            Try
                strSql = "SELECT WO_DateDock " & Environment.NewLine
                strSql &= "FROM production.tworkorder " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iWOID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 1 Then
                    Throw New Exception("This work order exist more than one in the system.")
                ElseIf dt.Rows.Count = 1 Then
                    If Not IsDBNull(dt.Rows(0)("WO_DateDock")) AndAlso Format(dt.Rows(0)("WO_DateDock"), "yyyy-MM-dd hh:mm:ss") <> "0000-00-00 00:00:00" Then strDockRecDate = Format(dt.Rows(0)("WO_DateDock"), "yyyy-MM-dd hh:mm:ss")
                End If

                Return strDockRecDate
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceID() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "select * from tdevice where loc_id = 2946 AND Device_DateBill is not null and Device_DateShip is null " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetPredefinedBoxType() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select 0 as ID, 'COS' as 'Desc'" & Environment.NewLine
                strSql &= " UNION" & Environment.NewLine
                strSql &= " Select 1 as ID, 'FUN' as 'Desc'" & Environment.NewLine
                strSql &= " UNION" & Environment.NewLine
                strSql &= " Select 2 as ID, 'XMD' as 'Desc';" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetBoxTypeFlag() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select 0 as ID, 'COS' as 'Desc'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                dt.LoadDataRow(New Object() {"1", "FUN"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function CreateWarehouseBoxID(ByVal iOrderID As Integer, _
                                             ByVal iFuncRep As Integer, _
                                             ByVal iWrtyFlag As Integer, _
                                             ByVal iModelID As Integer, _
                                             ByVal iWrtyExpInLess31Days As Integer) As DataTable
            Dim strSql As String = ""
            Dim strSvrDTime As String = ""
            Dim iNextSeqNo As Integer = 0
            Dim strBoxID As String = ""
            Dim iWHBoxID As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objMisc As New TracFone.clsMisc()

            Try
                strSvrDTime = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
                If strSvrDTime.Trim.Length = 0 Then strSvrDTime = Format(Now(), "yyyyMMdd")

                '************************************
                'Construct Box ID
                '************************************
                If iFuncRep = 1 Then
                    strBoxID = "F"
                ElseIf iFuncRep = 2 Then
                    strBoxID = "X"
                Else
                    strBoxID = "C"
                End If

                strBoxID &= strSvrDTime
                If iWrtyFlag = 1 Then strBoxID &= "IW" Else strBoxID &= "OW"

                iNextSeqNo = objMisc.GetWHBoxNexSeqNo(strBoxID, objMisc._iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxID = strBoxID & iNextSeqNo.ToString.PadLeft(objMisc._iWHBoxSegDigitCnt, "0")

                iWHBoxID = objMisc.InsertEdiWarehouseBox(strBoxID, iFuncRep, iWrtyFlag, iOrderID, iModelID, iWrtyExpInLess31Days, 0)
                If iWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

                '************************************
                Return Me.GetWHBox(iOrderID, iFuncRep, iWrtyFlag, iWrtyExpInLess31Days)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function CreateTriagedBoxID(ByVal iModelID As Integer, _
        '                                     ByVal iDispID As Integer) As DataTable
        '    Dim strSql As String = ""
        '    Dim strSvrDTime As String = ""
        '    Dim iNextSeqNo As Integer = 0
        '    Dim strBoxID As String = ""
        '    Dim strOrderID As String = ""
        '    Dim iWHBoxID As Integer = 0
        '    Dim iFuncRep As Integer = 0
        '    Dim iOrderID As Integer = 0
        '    Dim iWrtyFlag As Integer = 0
        '    Dim iWrtyExpInLess31Days As Integer = 0
        '    Dim dt As DataTable
        '    Dim R1 As DataRow
        '    Dim objMisc As New TracFone.clsMisc()

        '    Try
        '        strOrderID = InputBox("Enter Order ID:").Trim

        '        If strOrderID.Length > 0 Then iOrderID = CInt(strOrderID)
        '        If strOrderID.Length = 0 Then Exit Function

        '        strSvrDTime = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
        '        If strSvrDTime.Trim.Length = 0 Then strSvrDTime = Format(Now(), "yyyyMMdd")

        '        Select Case iDispID
        '            Case 2
        '                iFuncRep = 1
        '            Case 3
        '                iFuncRep = 1
        '            Case 4
        '                iFuncRep = 0
        '            Case 5
        '                iFuncRep = 3
        '        End Select

        '        '************************************
        '        'Construct Box ID
        '        '************************************
        '        If iFuncRep = 1 Then
        '            strBoxID = "F"
        '        ElseIf iFuncRep = 3 Then
        '            strBoxID = "X"
        '        Else
        '            strBoxID = "C"
        '        End If

        '        strBoxID &= strSvrDTime
        '        'If iWrtyFlag = 1 Then strBoxID &= "IW" Else strBoxID &= "OW"
        '        strBoxID &= "OW"

        '        iNextSeqNo = objMisc.GetWHBoxNexSeqNo(strBoxID, objMisc._iWHBoxSegDigitCnt)
        '        If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
        '        strBoxID = strBoxID & iNextSeqNo.ToString.PadLeft(objMisc._iWHBoxSegDigitCnt, "0")

        '        iWHBoxID = objMisc.InsertEdiWarehouseBox(strBoxID, iFuncRep, iWrtyFlag, iOrderID, iModelID, iWrtyExpInLess31Days, 0)
        '        If iWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

        '        '************************************
        '        Return Me.GetWHBox(iOrderID, iFuncRep, iWrtyFlag, iWrtyExpInLess31Days)

        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************
        Public Function CreateWFM2TF_WarehouseBoxID(ByVal iOrderID As Integer, _
                                                    ByVal iFuncRep As Integer, _
                                                    ByVal iWrtyFlag As Integer, _
                                              ByVal iModelID As Integer, _
                                             ByVal iWrtyExpInLess31Days As Integer) As DataTable
            Dim strSql As String = ""
            Dim strSvrDTime As String = ""
            Dim iNextSeqNo As Integer = 0
            Dim strBoxID As String = ""
            Dim iWHBoxID As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objMisc As New TracFone.clsMisc()

            Try
                strSvrDTime = Format(CDate(Generic.MySQLServerDateTime()), "yyyyMMdd")
                If strSvrDTime.Trim.Length = 0 Then strSvrDTime = Format(Now(), "yyyyMMdd")

                '************************************
                'Construct Box ID
                '************************************
                If iFuncRep = 1 Then strBoxID = "F" Else strBoxID = "C"
                strBoxID &= strSvrDTime
                If iWrtyFlag = 1 Then strBoxID &= "IW" Else strBoxID &= "OW"

                iNextSeqNo = objMisc.GetWHBoxNexSeqNo(strBoxID, objMisc._iWHBoxSegDigitCnt)
                If iNextSeqNo = 0 Then Throw New Exception("System has failed to get next box number.")
                strBoxID = strBoxID & iNextSeqNo.ToString.PadLeft(objMisc._iWHBoxSegDigitCnt, "0")

                iWHBoxID = objMisc.InsertEdiWarehouseBox(strBoxID, iFuncRep, iWrtyFlag, iOrderID, iModelID, iWrtyExpInLess31Days, 0)
                If iWHBoxID = 0 Then Throw New Exception("System has failed to create new box.")

                strSql = "select * from edi.twarehousebox where wb_ID=" & iWHBoxID

                '************************************
                ' Return Me.GetWHBox(iOrderID, iFuncRep, iWrtyFlag, iWrtyExpInLess31Days)
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '******************************************************************
        Public Function CloseAndPrintWarehouseBox(ByVal drWHBox As DataRow) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox " & Environment.NewLine
                strSql &= "SET Closed = 1 " & Environment.NewLine
                strSql &= "WHERE wb_id = " & drWHBox("wb_id") & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Me.PrintWarehouseBoxID(drWHBox("BoxID"), drWHBox("Model_Desc"), drWHBox("Qty"), drWHBox("OrderNo"), drWHBox("FuncRep"), drWHBox("WarrantyFlag"), drWHBox("WrtyExpedite"))

            Catch ex As Exception
                Throw ex
            Finally
                drWHBox = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function ReopenWarehouseBox(ByVal drWHBox As DataRow)
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE edi.twarehousebox " & Environment.NewLine
                strSql &= "SET Closed = 0 " & Environment.NewLine
                strSql &= "WHERE wb_id = " & drWHBox("wb_id") & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                drWHBox = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function PrintWarehouseBoxID(ByVal strBoxID As String, _
                                            ByVal strModel As String, _
                                            ByVal iBoxQty As Integer, _
                                            ByVal strOrderNo As String, _
                                            ByVal iBoxType As Integer, _
                                            ByVal iWrtyStatus As Integer, _
                                            ByVal iWrtyExpedite As Integer) As Integer
            Const strReportName As String = "TF Warehouse Box Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select '" & strBoxID & "' as BoxID " & Environment.NewLine
                strSql &= ", Concat('*', '" & strBoxID & "', '*') as BoxID_Barcode " & Environment.NewLine
                strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as BoxQty " & Environment.NewLine
                strSql &= ", '" & strOrderNo & "' as OrderNo" & Environment.NewLine
                strSql &= ", " & iBoxType & " as BoxType" & Environment.NewLine
                strSql &= ", " & iWrtyStatus & " as WarrantyStatus" & Environment.NewLine
                strSql &= ", " & iWrtyExpedite & " as WrtyExpedite " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintWarehouseBuildTriageBoxID(ByVal strBoxName As String, _
                                            ByVal strModel As String, _
                                            ByVal iBoxQty As Integer, _
                                            ByVal strBoxType As String, _
                                            ByVal strWrtyStatus As String) As Integer
            Const strReportName As String = "TF Warehouse Triage Box Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select '" & strBoxName & "' as BoxName " & Environment.NewLine
                strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as BoxQty " & Environment.NewLine
                strSql &= ", '" & strBoxType & "' as BoxType" & Environment.NewLine
                strSql &= ", '" & strWrtyStatus & "' as WarrantyStatus" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Public Function PrintSwHoldWarehouseBoxID(ByVal strBoxID As String, _
           ByVal strModel As String, _
           ByVal iBoxQty As Integer, _
           ByVal strOrderNo As String, _
           ByVal iBoxType As Integer, _
           ByVal iWrtyStatus As Integer, _
           ByVal iWrtyExpedite As Integer) As Integer
            ' THIS FUNCTION WILL PRINT A WAREHOUSE BOX LABEL FOR SW PROCESS DEVICES THAT PASS.
            Const strReportName As String = "TF Warehouse Box Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select '" & strBoxID & "' as BoxID " & Environment.NewLine
                strSql &= ", Concat('*', '" & strBoxID & "', '*') as BoxID_Barcode " & Environment.NewLine
                strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as BoxQty " & Environment.NewLine
                strSql &= ", '" & strOrderNo & "' as OrderNo" & Environment.NewLine
                strSql &= ", " & iBoxType & " as BoxType" & Environment.NewLine
                strSql &= ", 2 as WarrantyStatus" & Environment.NewLine
                strSql &= ", " & iWrtyExpedite & " as WrtyExpedite " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function


        '******************************************************************
        Public Function CloseAllOpenWHBox(ByVal iOrderID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT A.*, B.Model_Desc, C.OrderNo, count(D.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.torder C ON A.Order_ID = C.Order_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem D ON A.wb_id = D.wb_id " & Environment.NewLine
                strSql &= "WHERE A.Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND Closed = 0 " & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt.Rows
                    Me.CloseAndPrintWarehouseBox(R1)
                Next R1

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function ReprintWHBox(ByVal strBoxID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim drWHBox As DataRow

            Try
                strSql = "SELECT A.*, B.Model_Desc, IF(C.OrderNo is null, '', C.OrderNo ) OrderNo, count(D.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.torder C ON A.Order_ID = C.Order_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem D ON A.wb_id = D.wb_id " & Environment.NewLine
                strSql &= "WHERE A.BoxID = '" & strBoxID & "'" & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    For Each drWHBox In dt.Rows
                        Me.PrintWarehouseBoxID(drWHBox("BoxID"), drWHBox("Model_Desc"), drWHBox("Qty"), drWHBox("OrderNo"), drWHBox("FuncRep"), drWHBox("WarrantyFlag"), drWHBox("WrtyExpedite"))
                    Next drWHBox
                Else
                    Throw New Exception("No box found.")
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function ReprintSwHoldWHBox(ByVal strBoxID As String) As DataTable
            ' THIS FUNCTION WILL REPRINT A BOX LABEL FOR SW PROCESS DEVICES THAT PASS.
            Dim _sb As New StringBuilder()
            Dim dt As DataTable
            Dim drWHBox As DataRow
            _sb.Append("SELECT ")
            _sb.Append("A.wb_id, ")
            _sb.Append("A.boxid, ")
            _sb.Append("A.funcrep, ")
            _sb.Append("A.wrtyexpedite, ")
            _sb.Append("2 AS warrantyflag, ")
            _sb.Append("A.model_id, ")
            _sb.Append("A.order_id, ")
            _sb.Append("A.closed, ")
            _sb.Append("A.whlocation, ")
            _sb.Append("B.Model_Desc, ")
            _sb.Append("IF(C.OrderNo is null, '', C.OrderNo ) OrderNo, ")
            _sb.Append("count(D.SN) as Qty ")
            _sb.Append("FROM edi.twarehousebox A ")
            _sb.Append("INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID ")
            _sb.Append("LEFT OUTER JOIN edi.torder C ON A.Order_ID = C.Order_ID ")
            _sb.Append("LEFT OUTER JOIN edi.titem D ON A.wb_id = D.wb_id  ")
            _sb.Append("WHERE A.BoxID = '" & strBoxID & "'")
            _sb.Append("Group by A.BoxID; ")
            Try
                dt = Me._objDataProc.GetDataTable(_sb.ToString())

                If dt.Rows.Count > 0 Then
                    For Each drWHBox In dt.Rows
                        Me.PrintWarehouseBoxID(drWHBox("BoxID"), drWHBox("Model_Desc"), drWHBox("Qty"), drWHBox("OrderNo"), drWHBox("FuncRep"), drWHBox("WarrantyFlag"), drWHBox("WrtyExpedite"))
                    Next drWHBox
                Else
                    Throw New Exception("No box found.")
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetModelID(ByVal strModelDesc As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_ID " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Model_Desc = '" & strModelDesc & "'" & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        Public Function UpdateWarrantyData(ByVal iDeviceID As Integer, _
          ByVal iManufWrty As Integer, _
          ByVal strLastDateInWrty As String, _
          ByVal strDateCode As String, _
          ByVal strMSN As String, _
          ByVal strAPC As String, _
          ByVal strIMEI As String, _
          Optional ByVal strWrtyReceiptDateTime As String = "") As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tdevice, edi.titem, tcellopt  " & Environment.NewLine
                strSql &= "SET Device_ManufWrty = " & iManufWrty & Environment.NewLine
                strSql &= ", edi.titem.Manuf_Date = '" & strDateCode & "'" & Environment.NewLine
                strSql &= ", LastDateInWrty = '" & strLastDateInWrty & "'" & Environment.NewLine
                strSql &= ", CellOpt_DateCode = '" & strDateCode & "'" & Environment.NewLine
                If strAPC.Trim.Length > 0 Then strSql &= ", CellOpt_APC = '" & strAPC & "'" & Environment.NewLine
                If strIMEI.Trim.Length > 0 Then strSql &= ", CellOpt_IMEI = '" & strIMEI & "'" & Environment.NewLine
                If strMSN.Trim.Length > 0 Then strSql &= ", CellOpt_MSN = '" & strMSN & "'" & Environment.NewLine
                If strWrtyReceiptDateTime.Trim.Length > 0 Then strSql &= ", edi.titem.WrtyClaimReceiptDt = '" & strWrtyReceiptDateTime & "'" & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************
        Public Function AddExtraUnit(ByVal strItemNo As String, _
          ByVal strItemDesc As String, _
          ByVal iOrderID As Integer, _
          ByVal strOrderNo As String, _
          ByVal strIMEI As String, _
          ByVal strDiscrepancyReason As String, _
          ByVal boolReturnRecordHasNoDeviceID As Boolean, _
          ByVal iWHRNO_ID As Integer) As DataTable
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                strSql = "INSERT INTO edi.titem ( " & Environment.NewLine
                strSql &= "SN, VN_ItemNo, CB_ItemNo, OrderNo, Order_ID, DiscrepancyReason " & Environment.NewLine
                If iWHRNO_ID > 0 Then strSql &= ", WHRNO_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strIMEI & "'" & Environment.NewLine
                strSql &= ", '" & strItemNo & "'" & Environment.NewLine
                strSql &= ", '" & strItemDesc & "'" & Environment.NewLine
                strSql &= ", '" & strOrderNo & "'" & Environment.NewLine
                strSql &= ", " & iOrderID & Environment.NewLine
                strSql &= ", '" & strDiscrepancyReason & "'" & Environment.NewLine
                If iWHRNO_ID > 0 Then strSql &= ", " & iWHRNO_ID & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                dt = Me.GetTFDeviceASNData(iOrderID, boolReturnRecordHasNoDeviceID, strIMEI)
                If i = 0 Or dt.Rows.Count = 0 Then Throw New Exception("System has failed to add this device """ & strIMEI & """.")

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************
        Public Function AddWFM2TF_SN_To_tItem(ByVal strItemNo As String, _
                                     ByVal strItemDesc As String, _
                                     ByVal iOrderID As Integer, _
                                     ByVal strOrderNo As String, _
                                     ByVal strIMEI As String, _
                                     ByVal iWHRNO_ID As Integer, _
                                     Optional ByVal iIsWFM As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim boolReturnRecordHasNoDeviceID As Boolean = True

            Try
                strSql = "INSERT INTO edi.titem ( " & Environment.NewLine
                strSql &= "SN, VN_ItemNo, CB_ItemNo, OrderNo, Order_ID " & Environment.NewLine
                If iWHRNO_ID > 0 Then strSql &= ", WHRNO_ID " & Environment.NewLine
                If iIsWFM > 0 Then strSql &= ", IsWFM " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strIMEI & "'" & Environment.NewLine
                strSql &= ", '" & strItemNo & "'" & Environment.NewLine
                strSql &= ", '" & strItemDesc & "'" & Environment.NewLine
                strSql &= ", '" & strOrderNo & "'" & Environment.NewLine
                strSql &= ", " & iOrderID & Environment.NewLine
                If iWHRNO_ID > 0 Then strSql &= ", " & iWHRNO_ID & Environment.NewLine
                If iIsWFM > 0 Then strSql &= ", " & iIsWFM & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                dt = Me.GetTFDeviceASNData(iOrderID, boolReturnRecordHasNoDeviceID, strIMEI)
                If i = 0 Or dt.Rows.Count = 0 Then Throw New Exception("System has failed to add this device """ & strIMEI & """.")

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetCB_ItemNo(ByVal iOrderID As Integer) As String
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct CB_ItemNo" & Environment.NewLine
                strSql &= "FROM edi.titem WHERE Order_ID = " & iOrderID & Environment.NewLine
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ValidateExtraSn(ByVal drArray() As DataRow, ByVal iOrderID As Integer, ByVal iLocID As Integer) As Boolean
            Dim dt As DataTable
            Dim strSql, strSNs, strTmp As String
            Dim i As Integer
            Dim booResult As Boolean = False

            Try
                strSql = "" : strSNs = "" : strTmp = ""

                For i = 0 To drArray.Length - 1
                    If i > 0 Then strSNs &= Environment.NewLine & ", "
                    strSNs &= "'" & drArray(i)("SN") & "'"
                Next i

                strSql = "SELECT B.SN " & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN edi.titem B ON A.Order_ID = B.Order_ID " & Environment.NewLine
                strSql &= "WHERE A.WO_ClosedDate is null AND A.Order_ID <> " & iOrderID & Environment.NewLine
                strSql &= "AND B.Device_ID is null AND B.SN in ( " & strSNs & " )" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Columns.Count = 0 Then
                    Return False       'happen when syntax error
                ElseIf dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        If strTmp.Trim.Length > 0 Then strTmp &= ", "
                        strTmp &= dt.Rows(0)("SN") & Environment.NewLine
                    Next
                    MessageBox.Show("The following SN(s) belong to different open PO(s). " & Environment.NewLine & strTmp & Environment.NewLine & "Please verify if the box belongs to selected order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strTmp = ""
                    strSql = "SELECT Device_SN as SN as SN" & Environment.NewLine
                    strSql &= "FROM tdevice WHERE Loc_ID = " & iLocID & Environment.NewLine
                    strSql &= "AND Device_DateShip is null AND Device_SN in ( " & strSNs & " )" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Columns.Count = 0 Then
                        Return False       'happen when syntax error
                    ElseIf dt.Rows.Count > 0 Then
                        For i = 0 To dt.Rows.Count - 1
                            If strTmp.Trim.Length > 0 Then strTmp &= ", "
                            strTmp &= dt.Rows(0)("SN") & Environment.NewLine
                        Next
                        MessageBox.Show("The following SN(s) are in open wip. " & Environment.NewLine & strTmp & Environment.NewLine & "Can't add.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        booResult = True
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTracfoneModels(ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT tmodel.Model_ID, Model_Desc, Manuf_ID, cust_model_number, cust_model_desc" & Environment.NewLine
                strSql &= ", tcustmodel_pssmodel_map.cust_IncomingSku, tcustmodel_pssmodel_map.cust_IncomingDesc " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "INNER JOIN tcustmodel_pssmodel_map ON tmodel.Model_ID = tcustmodel_pssmodel_map.model_id " & Environment.NewLine
                strSql &= "WHERE tcustmodel_pssmodel_map.cust_id = " & BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                strSql &= "AND cust_MaterialCategory = 'PHONE' " & Environment.NewLine
                strSql &= "ORDER BY Model_Desc;"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetTracfoneDispostions(ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Disp_ID,Disp_Cd as 'Disposition', Disp_NA as 'Disposition_Full' " & Environment.NewLine
                strSql &= ", IF(Disp_ID=3,1,IF(Disp_ID=4,0, 3)) as 'FuncRep' " & Environment.NewLine
                strSql &= ", IF(Disp_ID=3,'F',IF(Disp_ID=4,'C', 'N')) as 'BoxPreFix' " & Environment.NewLine
                strSql &= "FROM production.tdispositions " & Environment.NewLine
                strSql &= "WHERE Disp_ID in (3,4,5); " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDiscrepancyRMA(ByVal booAddSelectRow As Boolean) As DataTable
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT DISTINCT C.*, A.Order_ID, A.RequestDate, A.IL_No, Tray_ID " & Environment.NewLine
                strSql &= "FROM edi.torder A " & Environment.NewLine
                strSql &= "INNER JOIN production.tworkorder C ON A.PSS_WO_ID = C.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.ttray D ON A.PSS_WO_ID = D.WO_ID " & Environment.NewLine
                strSql &= "WHERE A.Order_Type = 'IN' AND A.OrderNo = '10138035' "
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetWarehouseOpenBox(ByVal iOrderID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.*, B.Model_Desc, count(C.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem C ON A.wb_id = C.wb_id " & Environment.NewLine
                strSql &= "WHERE A.Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND Closed = 0 " & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************
        'Public Function validateSN(ByVal sn As String, ByVal modl As String, ByVal disp As String) As Boolean
        '    Dim strSql As String = ""
        '    Dim dt As DataTable
        '    Dim booReturnVal As Boolean = False

        '    Try
        '        strSql = "SELECT DV.Device_ID,DV.Device_SN,MD1.Model_Desc as 'Triaged_Model',MD2.Model_Desc as 'Device_Model' " & Environment.NewLine
        '        strSql &= ",DP.Disp_cd as 'Triaged_Disposition',DP.Disp_na as 'Triaged_Disposition_Full' " & Environment.NewLine
        '        strSql &= ",IF(TD.Disp_ID=2 or TD.Disp_ID=3,'FUN',IF(TD.Disp_ID=4,'COS', IF(TD.Disp_ID=5, 'NTF',''))) as 'BoxType' " & Environment.NewLine
        '        strSql &= ",CO.Workstation,IF(TD.Triaged_Model_ID=DV.Model_ID,'Yes','No') as 'IsModelMatched' " & Environment.NewLine
        '        strSql &= ",IF(CO.Workstation ='Triage Box','Yes','No') as 'IsValidWorkstation' " & Environment.NewLine
        '        strSql &= ",TD.Triaged_Model_ID,DV.Model_ID,TD.Disp_ID,IF(TD.Disp_ID=2 or TD.Disp_ID=3,1 " & Environment.NewLine
        '        strSql &= ",IF(TD.Disp_ID=4,0, IF(TD.Disp_ID=5, 3, -1))) as 'FuncRep',TD.Triage_Completed " & Environment.NewLine
        '        strSql &= "FROM production.tdevice_triaged_data TD " & Environment.NewLine
        '        strSql &= "INNER JOIN production.tdevice DV ON TD.Device_ID=DV.Device_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN production.tcellopt CO ON TD.Device_ID=CO.Device_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN production.tmodel MD1 ON TD.Triaged_Model_ID=MD1.Model_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN production.tmodel MD2 ON DV.Model_ID=MD2.Model_ID " & Environment.NewLine
        '        strSql &= "INNER JOIN production.tdispositions DP ON TD.Disp_ID=DP.Disp_ID " & Environment.NewLine
        '        strSql &= "WHERE Triage_Completed=1 AND DV.Device_SN = '" & sn & "'; " & Environment.NewLine
        '        dt = Me._objDataProc.GetDataTable(strSql)

        '        If dt.Rows.Count = 0 Then
        '            Throw New Exception("Serial Number is not able to be added to the box.")
        '        ElseIf dt.Rows.Count > 1 Then
        '            Throw New Exception("Serial Number existed more than once. Please contact IT.")
        '        ElseIf dt.Rows(0)("Device_SN").ToString.Trim = sn _
        '        And dt.Rows(0)("Triaged_Model").ToString.Trim = modl _
        '        And dt.Rows(0)("Triaged_Disposition").ToString.Trim = disp _
        '        And dt.Rows(0)("IsModelMatched").ToString.Trim.ToUpper = "YES" _
        '        And dt.Rows(0)("IsValidWorkstation").ToString.Trim.ToUpper = "YES" Then
        '            booReturnVal = True
        '        End If

        '        Return booReturnVal
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

        '******************************************************************
        Public Function GetWHBoxByBoxNameAndOrderID(ByVal strBoxName As String, ByVal iOrderID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox " & Environment.NewLine
                strSql &= "WHERE Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND BoxID = '" & strBoxName & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function GetWFM2TF_WHBoxByBoxNameAndOrderID(ByVal strBoxName As String, ByVal iOrderID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox " & Environment.NewLine
                strSql &= "WHERE Closed=0 AND  Order_ID = " & iOrderID & Environment.NewLine
                strSql &= "AND BoxID = '" & strBoxName & "'" & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CloseWareHouseBox(ByVal iWHBoxID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.*, B.Model_Desc, C.OrderNo, count(D.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.torder C ON A.Order_ID = C.Order_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem D ON A.wb_id = D.wb_id " & Environment.NewLine
                strSql &= "WHERE A.wb_id = " & iWHBoxID & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return Me.CloseAndPrintWarehouseBox(dt.Rows(0))

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function CloseTriagedBox(ByVal strBoxID As String, ByVal iFuncRep As Integer, ByVal strModel As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.*, B.Model_Desc, C.OrderNo, count(D.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN edi.torder C ON A.Order_ID = C.Order_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem D ON A.wb_id = D.wb_id " & Environment.NewLine
                strSql &= "WHERE A.BoxID = '" & strBoxID & "'" & Environment.NewLine
                strSql &= "AND A.FuncRep = " & iFuncRep & Environment.NewLine
                strSql &= "AND B.Model_Desc = '" & strModel & "'" & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Return Me.CloseAndPrintWarehouseBox(dt.Rows(0))

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function ReopenTriagedBox(ByVal strBoxID As String) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.*, B.Model_Desc, count(C.SN) as Qty " & Environment.NewLine
                strSql &= "FROM edi.twarehousebox A " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel B ON A.Model_ID = B.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN edi.titem C ON A.wb_id = C.wb_id " & Environment.NewLine
                strSql &= "WHERE A.BoxID = '" & strBoxID & "'" & Environment.NewLine
                strSql &= "AND Closed = 1 " & Environment.NewLine
                strSql &= "Group by A.BoxID " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                Me.ReopenWarehouseBox(dt.Rows(0))

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetBillcodeIDsForAutoConsumeParts(ByVal iModelID As Integer) As DataTable
            Const strDesc As String = "TF_AUTO_CONSUME_AT_RECEIVING"
            Dim strSql, strPartNos As String
            Dim dt, dt2 As DataTable

            Try
                dt = ModManuf.GetExceptionCriteria(strDesc)
                If dt.Rows.Count > 0 Then
                    strSql = "SELECT A.Billcode_ID, LaborLevel, Manuf_ID " & Environment.NewLine
                    strSql &= "FROM tpsmap A " & Environment.NewLine
                    strSql &= "INNER JOIN lpsprice B ON A.PSprice_ID = B.Psprice_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                    strSql &= "WHERE A.Model_ID = " & iModelID & Environment.NewLine
                    strSql &= "AND B.PSPrice_Number IN ( " & dt.Rows(0)("PartNumbers") & ")" & Environment.NewLine
                    dt2 = Me._objDataProc.GetDataTable(strSql)
                Else
                    dt2 = New DataTable()
                End If

                Return dt2

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
            End Try
        End Function

        '******************************************************************
        Public Function IsManufWarrantyClaimable(ByVal iManufID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booReturnVal As Boolean = False

            Try
                strSql = "SELECT claimable FROM lmanuf WHERE Manuf_ID = " & iManufID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Manufacture does not exist.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Manufacture existed more than one. Please contact IT.")
                ElseIf dt.Rows(0)("claimable").ToString.Trim = "1" Then
                    booReturnVal = True
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function IsByPassManufDateCode(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strModelsArr() As String
            Dim i As Integer

            Try
                strSql = "SELECT * FROM exceptioncriteria " & Environment.NewLine
                strSql &= "WHERE Description = 'TF_NO_DATECODE_COLLECTION' " & Environment.NewLine
                strSql &= "AND Active = 1 AND CustIDs IN ( '" & BuildShipPallet.TracFone_CUSTOMER_ID & "' ) " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strModelsArr = dt.Rows(0)("ModelIDs").ToString.Split(",")

                    For i = 0 To strModelsArr.Length - 1
                        If strModelsArr(i).Trim.Equals(iModelID.ToString) Then
                            booResult = True : Exit For
                        End If
                    Next i
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function PrintWarehouseBoxReceivedLabel(ByVal strBoxID As String, _
                                                       ByVal strModel As String, _
                                                       ByVal iBoxQty As Integer, _
                                                       ByVal strOrderNo As String, _
                                                       ByVal strBoxType As String) As Integer
            Const strReportName As String = "TF WFM Warehouse Box Label.rpt"
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select '" & strBoxID & "' as BoxID " & Environment.NewLine
                strSql &= ", Concat('*', '" & strBoxID & "', '*') as BoxID_Barcode " & Environment.NewLine
                strSql &= ", '" & strModel & "' as Model_Desc " & Environment.NewLine
                strSql &= ", " & iBoxQty & " as BoxQty " & Environment.NewLine
                strSql &= ", '" & strOrderNo & "' as OrderNo" & Environment.NewLine
                strSql &= ", '" & strBoxType & "' as BoxType" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)

                '**********************
                'Print Box lablel
                '**********************
                Try
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, "2DBoxLabel")
                Catch ex As Exception
                    '2DBoxLabel is not available then try default printer
                    clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                End Try
                '**********************

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function
        '******************************************************************


#End Region

#Region "Cost Center Receving"

        '******************************************************************
        Public Function GetDeviceCostCenterInfo(ByVal strSN As String) As DataTable
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim strDeviceWorkStation As String = ""

            Try
                strSql = "SELECT tworkorder.Group_ID, tdevice.Device_ID, tdevice.cc_id, " & Environment.NewLine
                strSql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as cc_desc, " & Environment.NewLine
                strSql &= "if(Group_Desc is null, '', Group_Desc ) as Group_Desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lgroups on tcostcenter.group_id = lgroups.group_id " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND ( Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '' ) " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & TracFone.BuildShipPallet.TracFone_LOC_ID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ReceiveDeviceIntoCostCenter(ByVal iCC_ID As Integer, _
                                                    ByVal iDeviceID As Integer, _
                                                    ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""

            Try

                strSql = "UPDATE tdevice, tcellopt " & Environment.NewLine
                strSql &= "SET cc_id = " & iCC_ID & Environment.NewLine
                strSql &= ", cc_entrydate = now() " & Environment.NewLine
                strSql &= ", CellOpt_TechAssigned = " & iUserID & ", CellOpt_TechAssignDate = now() " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = tcellopt.Device_ID AND tdevice.Device_ID = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region

#Region "SPECIAL USE BY LAN ONLY"

        '******************************************************************
        Public Function GetSpecialDeviceIDs(ByVal strSql As String) As DataTable

            Try
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function Execute(ByVal strSql As String) As Integer

            Try
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************

#End Region


    End Class
End Namespace