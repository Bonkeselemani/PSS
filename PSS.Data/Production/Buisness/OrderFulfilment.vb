Option Explicit On 
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class OrderFulfilment
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

#Region "OrderFulfilment"

        '******************************************************************
        Public Function GetOpenOrders(ByVal booAddSelectRow As Boolean, _
                                      ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tworkorder WHERE Loc_ID = " & iLocID & " AND WO_Closed = 0 AND OrderType_ID = 2 AND InvalidOrder = 0 ORDER BY WO_CustWO"
                dt = Me._objDataProc.GetDataTable(strSql)

                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetBoxesDispDataInOrder(ByVal iLocID As Integer, ByVal iWOID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dtPallets, dtPalletDetail As DataTable
            Dim R1, drDevice() As DataRow
            Dim i As Integer

            Try
                strSql = "SELECT DISTINCT tpallett.Pallett_ID, tpallett.Loc_ID, tpallett.Cust_ID, tpallett.WO_ID " & Environment.NewLine
                strSql &= ", Pallett_Name as 'Box' " & Environment.NewLine
                strSql &= ", IF(Pallett_ReadyToShipFlg = 1, 'No','Yes') as 'Open?'  " & Environment.NewLine
                strSql &= ", 0 as 'Qty' " & Environment.NewLine
                strSql &= ", Pallett_MaxQty as 'Max Qty', tpallett.Pallet_ShipType  " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "AND tpallett.Pallet_Invalid = 0 " & Environment.NewLine
                dtPallets = Me._objDataProc.GetDataTable(strSql)

                strSql = "SELECT Device_ID, tpallett.Pallett_ID " & Environment.NewLine
                strSql &= ", IF(Accessory is null , 0, IF(Accessory = 0, 1, right( Device_SN, length(Device_SN) - INSTR(Device_SN, 'Q') ) ) ) as 'Qty' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & " AND tpallett.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "AND tpallett.Pallet_Invalid = 0 " & Environment.NewLine
                dtPalletDetail = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtPallets.Rows
                    drDevice = dtPalletDetail.Select("Pallett_ID = " & R1("Pallett_ID"))

                    If drDevice.Length > 0 Then
                        R1.BeginEdit()
                        For i = 0 To drDevice.Length - 1 : R1("Qty") += CInt(drDevice(i)("Qty")) : Next i
                        R1.EndEdit()
                    End If
                Next R1

                Return dtPallets
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetModels(ByVal strModelDescs As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_Desc, Model_ID, Accessory " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Model_Desc IN (" & strModelDescs & ")" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenBoxIDInOrder(ByVal iLocID As Integer, _
                                            ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Pallett_ID " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND WO_ID = " & iWOID & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateBox(ByVal iCustID As Integer, _
                                  ByVal iLocID As Integer, _
                                  ByVal iMaxQty As Integer, _
                                  ByVal iWOID As Integer) As Integer
            Dim strSql, strPalletPrefix, strDate, strPalletName As String
            Dim iPalletID As Integer = 0

            Try
                '******************************
                'construct pallet name
                '******************************
                strDate = Generic.GetMySqlDateTime("%y%m%d")

                strPalletPrefix = strDate & "L" & iLocID.ToString & "N"

                strPalletName = Me.DefinePalletName(strPalletPrefix, iLocID)

                '******************************
                'check for duplicate pallet
                '******************************
                strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLocID
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create box (" & strPalletName & ") which is already existed in system.")

                '******************************
                'Create pallet
                ''******************************
                strSql = "INSERT INTO tpallett ( " & Environment.NewLine
                strSql &= "Pallett_Name " & Environment.NewLine
                strSql &= ", Pallet_ShipType " & Environment.NewLine
                'strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", Cust_ID  " & Environment.NewLine
                strSql &= ", Loc_ID  " & Environment.NewLine
                strSql &= ", Pallett_MaxQty  " & Environment.NewLine
                strSql &= ", WO_ID  " & Environment.NewLine
                strSql &= ") VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", 0 " & Environment.NewLine
                'strSql &= ", " & iModelID & Environment.NewLine
                strSql &= ", " & iCustID & " " & Environment.NewLine
                strSql &= ", " & iLocID & Environment.NewLine
                strSql &= ", " & iMaxQty & Environment.NewLine
                strSql &= ", " & iWOID & Environment.NewLine
                strSql &= ");" & Environment.NewLine
                iPalletID = Me._objDataProc.idTransaction(strSql, "tpallett")

                If iPalletID = 0 Then iPalletID = Me.GetBoxID(strPalletName, iLocID)

                '******************************

                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function DefinePalletName(ByVal strPalletPrefix As String, _
                                          ByVal iLocID As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try
                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "000")
                    Else
                        strPallett_Name &= "001"
                    End If
                Else
                    strPallett_Name &= "001"
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetBoxID(ByVal strPalletName As String, _
                                 ByVal iLocID As Integer) As Integer
            Dim strSQL As String
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                strSQL = "SELECT Pallett_ID " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name = '" & strPalletName & "' " & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Duplicate Box """ & strPalletName & """. Please contact IT.")
                ElseIf dt.Rows.Count = 0 Then
                    Throw New Exception("Box ID """ & strPalletName & """ is missing. Please contact IT.")
                ElseIf dt.Rows(0)("Pallet_Invalid") > 0 Then
                    Throw New Exception("Box was deleted.")
                Else
                    iPalletID = dt.Rows(0)("Pallett_ID")
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetAllBoxesInOrder(ByVal iLocID As Integer, ByVal iWOID As Integer) As DataTable
            Dim strSQL As String

            Try
                strSQL = "SELECT * " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Loc_ID = " & iLocID & Environment.NewLine
                strSQL &= "AND WO_ID = " & iWOID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSQL)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CloseOrder(ByVal iCustID As Integer, _
                                   ByVal iWOID As Integer, _
                                   ByVal strCustWO As String, _
                                   ByVal iUsrID As Integer, _
                                   ByVal iShiftID As Integer, _
                                   ByVal strWorkDate As String, _
                                   ByVal iShipQty As Integer, _
                                   ByVal iShipCarrierID As Integer, _
                                   ByVal strTrackingNo As String, _
                                   ByVal iBoxCount As Integer, _
                                   ByVal decShippingCost As Decimal) As Integer
            Dim strSQL, strToday As String
            Dim iPkslipID, i As Integer
            Dim objPSlip As SendPalletPackingListFiles
            Dim objSOD As SaleOrderData

            Try
                strToday = Generic.GetMySqlDateTime("%Y-%m-%d %H:%m:%s")
                '***********************
                'Create manifest
                '***********************
                objPSlip = New SendPalletPackingListFiles()
                iPkslipID = objPSlip.CreatePackingSlip(iCustID, iUsrID, , strTrackingNo, strToday, iShipCarrierID, decShippingCost)
                If iPkslipID = 0 Then Throw New Exception("System has failed to create packing slip.")

                '***********************
                'Close Order
                '***********************
                strSQL = "UPDATE tpallett, tworkorder, tdevice " & Environment.NewLine
                strSQL &= "SET Pallett_ShipDate = now(), Pallett_BulkShipped = 1, pkslip_ID = " & iPkslipID & Environment.NewLine
                strSQL &= ", WO_Quantity = " & iShipQty & ", WO_Shipped = 1, WO_DateShip = now(), WO_Closed = 1 " & Environment.NewLine
                strSQL &= ", tdevice.WO_ID_OUT = " & iWOID & ", Shift_ID_Ship = " & iShiftID & ", Device_DateShip = now(), Device_ShipWorkDate = '" & strWorkDate & "'" & Environment.NewLine
                strSQL &= "WHERE tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSQL &= "AND tpallett.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSQL &= "AND tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND tpallett.WO_ID = " & iWOID & Environment.NewLine
                strSQL &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSQL)
                If i = 0 Then Throw New Exception("System has failed to update ship date in production database.")

                '***********************
                'Update Sale Orders
                '***********************
                objSOD = New SaleOrderData()
                i = objSOD.UpdateSaleOrderShipDate(strCustWO, iWOID)
                If i = 0 Then Throw New Exception("System has failed to update ship date in sale order database.")

                '***********************
                'Print Packing Slip
                '***********************
                Me.PrintPackingSlip(iPkslipID, iBoxCount + 1)

                Return iPkslipID

            Catch ex As Exception
                Throw ex
            Finally
                objPSlip = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetDevicesInOrder(ByVal iLocID As Integer, _
                                          ByVal iWOID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tpallett.Pallett_ID, tdevice.Model_ID, count(Device_ID) as Qty " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND tpallett.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "AND tmodel.Accessory = 0" & Environment.NewLine
                strSql &= "GROUP BY tpallett.Pallett_ID, tdevice.Model_ID " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT tpallett.Pallett_ID, tdevice.Model_ID, Sum(right( Device_SN, length(Device_SN) - INSTR(Device_SN, 'Q') ) ) as 'Qty' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "AND tpallett.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "AND tmodel.Accessory > 0" & Environment.NewLine
                strSql &= "GROUP BY tpallett.Pallett_ID, tdevice.Model_ID " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetBoxLabelData(ByVal strBoxName As String, _
                                        ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT tpallett.Pallett_ReadyToShipFlg, Pallett_Name as BoxName " & Environment.NewLine
                strSql &= ", Pallett_QTY as BoxQty , tpallett.Pallett_ID as BoxID, Date_Format(Pallett_ShipDate, '%Y-%m-%d') as ShipDate " & Environment.NewLine
                strSql &= ", WO_CustWO as OrderNo, WO_Memo as CustPO, '' as 'CustName', '' as 'ShipmentMethodCode' " & Environment.NewLine
                strSql &= ", tpallett.WO_ID as 'WOID'" & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON tpallett.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND tpallett.Pallett_Name = '" & strBoxName & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Sub PrintBoxLabel(ByVal dt As DataTable)
            Const strReportName As String = "Peek Box Label Push.rpt"
            Dim objSOD As SaleOrderData
            Dim drCompanyNameAndShipVia As DataRow

            Try
                objSOD = New SaleOrderData()
                drCompanyNameAndShipVia = objSOD.GetCompanyNameAndShipVia(dt.Rows(0)("OrderNo"))

                If IsNothing(drCompanyNameAndShipVia) Then
                    Throw New Exception("Customer and shipment method is missing.")
                Else
                    dt.Rows(0).BeginEdit()
                    dt.Rows(0)("CustName") = drCompanyNameAndShipVia("CompanyName")
                    dt.Rows(0)("ShipmentMethodCode") = drCompanyNameAndShipVia("ShipVia")
                    dt.Rows(0).EndEdit() : dt.AcceptChanges()

                    '**********************
                    'Print Box lablel
                    '**********************
                    Try
                        Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, "2DBoxLabel")
                    Catch ex As Exception
                        '2DBoxLabel is not available then try default printer
                        Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dt, strReportName, 1, )
                    End Try
                    '**********************
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objSOD = Nothing : drCompanyNameAndShipVia = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Public Sub PrintPackingSlip(ByVal iPkslipID As Integer, ByVal iCopies As Integer)
            Const strReportName As String = "Peek Packing Slip Push.rpt"
            Dim strSql As String
            Dim objSOD As SaleOrderData
            Dim dtBoxes, dtSO, dtRptData, dtQty As DataTable
            Dim drBoxes(), R1, drNewRow As DataRow
            Dim i, j As Integer

            Try
                dtRptData = New DataTable()

                strSql = "SELECT B.Pallett_ID, B.Loc_ID, A.pkSlip_ID as ShipmentNumber, A.pkslip_trackNo as TrackingNumber" & Environment.NewLine
                strSql &= ", B.Pallett_Name as BoxNumber " & Environment.NewLine
                strSql &= ", if(D.Accessory = 0, count(*), Sum(right( Device_SN, length(Device_SN) - INSTR(Device_SN, 'Q') ) ) ) as Quantity " & Environment.NewLine
                strSql &= ", Model_Desc as 'Item' " & Environment.NewLine
                strSql &= ", C.Model_ID, B.WO_ID, D.UPC_Code " & Environment.NewLine
                strSql &= "FROM tpackingslip A" & Environment.NewLine
                strSql &= "INNER JOIN tpallett B ON A.pkslip_ID = B.pkslip_ID" & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON B.Pallett_ID = C.Pallett_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel D On C.Model_ID = D.Model_ID" & Environment.NewLine
                strSql &= "WHERE A.pkslip_ID = " & iPkslipID & Environment.NewLine
                strSql &= "GROUP BY D.Model_ID, B.Pallett_ID; " & Environment.NewLine
                dtBoxes = Me._objDataProc.GetDataTable(strSql)

                If dtBoxes.Rows.Count > 0 Then
                    objSOD = New SaleOrderData()
                    dtSO = objSOD.GetPackingSlipReportData(dtBoxes.Rows(0)("WO_ID"))
                    dtRptData = dtSO.Clone()

                    If dtSO.Rows.Count = 0 Then
                        Throw New Exception("Sale order data is empty.")
                    Else
                        For Each R1 In dtSO.Rows
                            drBoxes = dtBoxes.Select("Item = '" & R1("Item") & "'")
                            If drBoxes.Length > 0 Then
                                For i = 0 To drBoxes.Length - 1
                                    drNewRow = dtRptData.NewRow
                                    For j = 0 To dtRptData.Columns.Count - 1
                                        drNewRow(j) = R1(j)
                                    Next j

                                    drNewRow("ShipmentNumber") = drBoxes(i)("ShipmentNumber")
                                    drNewRow("TrackingNumber") = drBoxes(i)("TrackingNumber")
                                    drNewRow("BoxNumber") = drBoxes(i)("BoxNumber")
                                    drNewRow("Quantity") = drBoxes(i)("Quantity")
                                    drNewRow("WOID") = drBoxes(i)("WO_ID")
                                    drNewRow("UPCCode") = drBoxes(i)("UPC_Code")
                                    dtRptData.Rows.Add(drNewRow) : dtRptData.AcceptChanges()
                                    drNewRow = Nothing
                                Next i
                            End If
                        Next R1
                    End If
                End If

                '**********************
                'Print Packing Slip
                '**********************
                Buisness.TracFone.clsMisc.PrintCrystalReportLabel(dtRptData, strReportName, iCopies, )
                '**********************

            Catch ex As Exception
                Throw ex
            Finally
                objSOD = Nothing : R1 = Nothing : drBoxes = Nothing : drNewRow = Nothing
                Generic.DisposeDT(dtBoxes)
                Generic.DisposeDT(dtSO)
                Generic.DisposeDT(dtRptData)
            End Try
        End Sub

        '******************************************************************
        Public Function GetBoxData(ByVal strBoxName As String, _
                                   ByVal iCustID As Integer) As DataTable
            Dim strSql As String
            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND tpallett.Pallett_Name = '" & strBoxName & "'" & Environment.NewLine
                strSql &= "AND tpallett.Pallet_Invalid = 0" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function FillAccessory(ByVal iLocID As Integer, _
                                      ByVal iModelID As Integer, _
                                      ByVal iWOID As Integer, _
                                      ByVal iPalletID As Integer, _
                                      ByVal iQty As Integer, _
                                      ByVal iShiftID As Integer, _
                                      ByVal iPOHeaderID As Integer, _
                                      ByVal strItemNo As String, _
                                      ByVal strFedexReturnTrackNo As String) As Integer
            Dim strSN As String
            Dim iDeviceID As Integer
            Dim objRec As New PSS.Data.Production.Receiving()
            Dim objSOD As SaleOrderData

            Try
                strSN = "W" & iWOID & "M" & iModelID & "Q" & iQty
                '1:Write to tdevice
                iDeviceID = objRec.InsertIntoTdevice(strSN, Generic.GetWorkDate(iShiftID), 0, 0, iLocID, iWOID, iModelID, iShiftID, , , , )
                If iDeviceID = 0 Then Throw New Exception("System has failed to insert a record into tdevice.")

                '2:Assigned to pallett
                PSS.Data.Production.Shipping.AssignDeviceToPallet(iDeviceID, iPalletID)

                '3:Add Fedex return tracking #
                If iModelID = 1344 Then
                    objSOD = New SaleOrderData()
                    objSOD.UpdateFedexReturnTrackingNumber(strItemNo, strFedexReturnTrackNo, iPOHeaderID)
                End If

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Public Function GetAllSNsForPallet(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Device_ID, Device_SN, Accessory " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID  " & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPalletID.ToString & " order by device_id"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function DeleteAccessorySN(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "DELETE FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
#End Region

#Region "Fill Order"

        '********************************************************************************
        Public Function GetOpenSaleOrdersHeader(ByVal iCustID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT A.SOHeaderID, A.PONumber, A.CustomerOrderNumber " & Environment.NewLine
                strSql &= ", concat(A.CustomerFirstName, ' ', A.CustomerLastName) as 'Ship to Name'" & Environment.NewLine
                strSql &= ", A.CustomerAddress1 as 'Address1', A.CustomerAddress2 as 'Address2', A.CustomerAddress3 as 'Address3'" & Environment.NewLine
                strSql &= ", A.CustomerCity as 'City', A.CustomerState as 'State', A.CustomerPostalCode as 'Postal Code'" & Environment.NewLine
                strSql &= ", A.CustomerCountry as 'Country', A.CustomerPhone as 'Phone', A.CustomerEmail as 'Email'" & Environment.NewLine
                strSql &= ", A.CustomerOrderDate as 'Order Date', A.InboundTrackingNumber as 'Inbound Track #'" & Environment.NewLine
                strSql &= ", sum(B.Quantity) as 'Quantiy', A.OrderType " & Environment.NewLine
                strSql &= "FROM saleorders.soheader A" & Environment.NewLine
                strSql &= "JOIN saleorders.sodetails B ON A.soheaderid = B.soheaderid" & Environment.NewLine
                strSql &= "WHERE A.CUST_ID = " & iCustID & " And A.ShipDate Is null And A.InvalidOrder = 0 AND OrderStatusID = 1 " & Environment.NewLine
                strSql &= "GROUP BY A.SOHeaderID" & Environment.NewLine
                strSql &= "ORDER BY A.PONumber "
                dt = Me._objDataProc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetOpenSaleOrdersDetails(ByVal iCustID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.SOHeaderID, A.PONumber as 'PO #', A.CustomerOrderNumber as 'Order #'" & Environment.NewLine
                strSql &= ", concat(A.CustomerFirstName, ' ', A.CustomerLastName) as 'Ship to Name'" & Environment.NewLine
                strSql &= ", A.CustomerAddress1 as 'Address1', A.CustomerAddress2 as 'Address2', A.CustomerAddress3 as 'Address3'" & Environment.NewLine
                strSql &= ", A.CustomerCity as 'City', A.CustomerState as 'State', A.CustomerPostalCode as 'Postal Code'" & Environment.NewLine
                strSql &= ", A.CustomerCountry as 'Country', A.CustomerPhone as 'Phone', A.CustomerEmail as 'Email'" & Environment.NewLine
                strSql &= ", A.CustomerOrderDate as 'Order Date', A.InboundTrackingNumber as 'Inbound Track #'" & Environment.NewLine
                strSql &= ", B.LineItemNumber as 'Line #', B.ItemCode as 'Item Code', B.Quantity as 'Quantiy'" & Environment.NewLine
                strSql &= ", B.UnitOfMeasure as 'Unit of Measure'" & Environment.NewLine
                strSql &= ", IF(C.Dcode_L2desc is null, '', C.Dcode_LDesc) as 'Device Condition'" & Environment.NewLine
                strSql &= ", IF(D.Dcode_Ldesc is null, '', D.Dcode_Ldesc) as 'Cosmetic Grade'" & Environment.NewLine
                strSql &= "FROM saleorders.soheader A" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.sodetails B ON A.soheaderid = B.soheaderid" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lcodesdetail C on B.devconditionID = C.dcode_id" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lcodesdetail D on B.cosmgradeid = D.dcode_ID" & Environment.NewLine
                strSql &= "WHERE A.CUST_ID = " & iCustID & " And A.ShipDate Is null And A.InvalidOrder = 0 AND OrderStatusID = 1 " & Environment.NewLine
                strSql &= "ORDER BY A.PONumber "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetOpenOrderDetails(ByVal iCustID As Integer, ByVal iSOHeader As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.SOHeaderID, B.SODetailsID " & Environment.NewLine
                strSql &= ", concat(A.CustomerFirstName, ' ', A.CustomerLastName) as 'Ship to Name'" & Environment.NewLine
                strSql &= ", B.LineItemNumber as 'Line #', B.ItemCode as 'Item Code', B.Quantity as 'Line Qty'" & Environment.NewLine
                strSql &= ", B.UnitOfMeasure as 'Unit of Measure'" & Environment.NewLine
                strSql &= ", IF(C.Dcode_L2desc is null, '', C.Dcode_L2Desc) as 'Device Condition'" & Environment.NewLine
                strSql &= ", IF(D.Dcode_Ldesc is null, '', D.Dcode_Ldesc) as 'Cosmetic Grade'" & Environment.NewLine
                strSql &= ", B.Model_ID, B.DevConditionID, B.CosmGradeID " & Environment.NewLine
                strSql &= "FROM saleorders.soheader A" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.sodetails B ON A.soheaderid = B.soheaderid" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lcodesdetail C on B.devconditionID = C.dcode_id" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lcodesdetail D on B.cosmgradeid = D.dcode_ID" & Environment.NewLine
                strSql &= "WHERE A.CUST_ID = " & iCustID & " And A.ShipDate Is null And A.InvalidOrder = 0 AND OrderStatusID = 1 " & Environment.NewLine
                strSql &= "AND A.SOHeaderID = " & iSOHeader
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetAllDevicesInSOLine(ByVal iSODetailsID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items " & Environment.NewLine
                strSql &= "WHERE SODetailsID = " & iSODetailsID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetOpenGoodWHItem(ByVal iCustID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID = B.WR_ID " & Environment.NewLine
                strSql &= "WHERE B.Cust_ID = " & iCustID & " AND A.Serial = '" & strSN & "'" & Environment.NewLine
                strSql &= "AND A.Device_ID = 0 AND SODetailsID = 0 AND DevConditionID <> 3855 "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function AssignItemToSaleOrder(ByVal iWarehouseItemID As Integer, ByVal iSODetailsID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE warehouse.warehouse_items " & Environment.NewLine
                strSql &= "SET SODetailsID = " & iSODetailsID & Environment.NewLine
                strSql &= "WHERE WI_ID = " & iWarehouseItemID & " AND SODetailsID = 0 " & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetSaleOrderBySOHeaderID(ByVal iCustID As Integer, ByVal iSOHeaderID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM saleorders.soheader " & Environment.NewLine
                strSql &= "WHERE CUST_ID = " & iCustID & " AND SOHeaderID = " & iSOHeaderID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function RemoveDevicesFromSODetails(ByVal iSODetailsID As Integer, _
                                                   Optional ByVal iWarehouseItemID As Integer = 0) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE warehouse.warehouse_items " & Environment.NewLine
                strSql &= "SET SODetailsID = 0 " & Environment.NewLine
                strSql &= "WHERE SODetailsID = " & iSODetailsID & Environment.NewLine
                If iWarehouseItemID > 0 Then strSql &= "AND WI_ID = " & iWarehouseItemID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetWarehouseItem(ByVal iMenuCustID As Integer, ByVal strSN As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.* FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_receipt B ON A.WR_ID = B.WR_ID " & Environment.NewLine
                strSql &= "WHERE B.Cust_ID = " & iMenuCustID & " AND A.Serial = '" & strSN & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetSOFilledQty(ByVal iSOHeaderID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT count(*) as Qty " & Environment.NewLine
                strSql &= "FROM saleorders.soheader A" & Environment.NewLine
                strSql &= "INNER JOIN saleorders.sodetails B ON A.soheaderid = B.soheaderid" & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items C ON B.SODetailsID = C.SODetailsID " & Environment.NewLine
                strSql &= "WHERE A.SOHeaderID = " & iSOHeaderID & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function CloseSO(ByVal iCustID As Integer, ByVal iSOHeaderID As Integer, _
                                ByVal iUserID As Integer, ByVal strShipCarrier As String, _
                                ByVal strTrackNo As String, ByVal decShippingCost As Decimal, _
                                Optional ByVal iBillCode_ID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                'Ship qty in detail
                'Not Correct: strSql = "SELECT A.SODetailsID, count(*) as FilledQty " & Environment.NewLine
                strSql = "SELECT A.SODetailsID, Quantity as FilledQty " & Environment.NewLine
                strSql &= "FROM saleorders.sodetails A " & Environment.NewLine
                strSql &= "INNER JOIN warehouse.warehouse_items B ON A.SODetailsID = B.SODetailsID " & Environment.NewLine
                strSql &= "WHERE A.SOHeaderID = " & iSOHeaderID & Environment.NewLine
                strSql &= "GROUP BY A.SODetailsID"
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    strSql = "UPDATE saleorders.sodetails " & Environment.NewLine
                    strSql &= "SET ShipQuantity = " & R1("FilledQty").ToString & Environment.NewLine
                    strSql &= "WHERE SODetailsID = " & R1("SODetailsID").ToString & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                strSql = "UPDATE saleorders.soheader " & Environment.NewLine
                strSql &= "SET ShipDate = now(), ShipUserID = " & iUserID & Environment.NewLine
                strSql &= ", ShipCarrier = '" & strShipCarrier & "', OutboundTrackingNumber = '" & strTrackNo & "', OrderShipmentCharge = " & decShippingCost & Environment.NewLine
                strSql &= ", BillCode_ID=" & iBillCode_ID & Environment.NewLine
                'strSql &= ", LaborCharge = " & dbLaborCharge & Environment.NewLine
                strSql &= "WHERE CUST_ID = " & iCustID & " And ShipDate Is null And InvalidOrder = 0 AND OrderStatusID = 1 " & Environment.NewLine
                strSql &= "AND SOHeaderID = " & iSOHeaderID
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to close the order.")

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************
        Public Function SetLineLaborCharge(ByVal iSODetailsID As Integer, ByVal dbLineLaborCharge As Double) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE saleorders.sodetails " & Environment.NewLine
                strSql &= "SET LineLaborCharge = " & dbLineLaborCharge.ToString & Environment.NewLine
                strSql &= "WHERE SODetailsID = " & iSODetailsID.ToString & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetTotalLineLaborCharge(ByVal iSOHeaderID As Integer) As Double
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dbTotal As Double = 0

            Try
                strSql = "SELECT SUM(LineLaborCharge) as 'TotalLineLaborCharge' " & Environment.NewLine
                strSql &= "FROM saleorders.soheader A " & Environment.NewLine
                strSql &= "INNER JOIN saleorders.sodetails B ON A.SOHeaderID = B.SOHeaderID " & Environment.NewLine
                strSql &= "WHERE A.SOHeaderID = " & iSOHeaderID.ToString & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If Not IsDBNull(dt.Rows(0)("TotalLineLaborCharge")) Then dbTotal = Convert.ToDouble(dt.Rows(0)("TotalLineLaborCharge"))

                Return dbTotal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************
        Public Function SetSOTotalLaborCharge(ByVal iSOHeaderID As Integer, ByVal dbTotalLineLaborCharge As Double) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE saleorders.soheader " & Environment.NewLine
                strSql &= "SET LaborCharge = " & dbTotalLineLaborCharge.ToString & Environment.NewLine
                strSql &= "WHERE SOHeaderID = " & iSOHeaderID.ToString & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetOrderDetails(ByVal iSOHeader As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM saleorders.sodetails WHERE SOHeaderID = " & iSOHeader
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetFilledDevicesInSO(ByVal iSOID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT A.* " & Environment.NewLine
                strSql &= "FROM warehouse.warehouse_items A " & Environment.NewLine
                strSql &= "INNER JOIN saleorders.sodetails B ON A.SODetailsID = B.SODetailsID" & Environment.NewLine
                strSql &= "WHERE B.SOHeaderID = " & iSOID
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function CancelOrder(ByVal iSOID As Integer, ByVal iUserID As Integer, ByVal strCancelReason As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE saleorders.soheader " & Environment.NewLine
                strSql &= " SET InvalidOrder = 1, InvalidOrder_UserID = " & iUserID & ", InvalidOrder_DateTime = now() " & Environment.NewLine
                strSql &= " , ReasonOrderInvalid = '" & strCancelReason & "'" & Environment.NewLine
                strSql &= "WHERE SOHeaderID = " & iSOID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Public Function GetNI_EDI_Data(ByVal iCustID As Integer, _
                                   Optional ByVal strClaimNo As String = "", _
                                   Optional ByVal strOrderOwner As String = "") As DataTable
            Dim strSql As String = ""
            Dim dt, dtMap As DataTable
            Dim row, row2 As DataRow
            Dim filteredRows() As DataRow
            Dim strProd As String = ""
            Dim strModels As String = ""
            Dim strModelIDs As String = ""

            Try
                'EDI data
                strSql = "SELECT tworkorder.WO_ID, ClaimNo, Cust2PSSI_TrackNo as TrackNo" & Environment.NewLine
                strSql &= " , ShipTo_name as 'Name', Address1, Address2, City, State_ShortName as 'State', ZipCode, Tel, Email" & Environment.NewLine
                strSql &= " , WO_Quantity as 'WO Qty'" & Environment.NewLine
                strSql &= " , if( extendedwarranty.NI_DataSwitch = 1, 'End User', if(extendedwarranty.NI_DataSwitch = 2, 'Bulk', 'Undefine')) as 'WO Type'" & Environment.NewLine
                strSql &= " , IF( extendedwarranty.SerialNo is null, '', extendedwarranty.SerialNo) as 'EDI S/N' , RepairType" & Environment.NewLine
                strSql &= " ,'' AS 'NI_Product','' AS 'PSSI_Model',extendedwarranty.Prod_Code AS 'NI_prod_ID','' AS 'Model_ID'" & Environment.NewLine
                strSql &= " FROM tworkorder" & Environment.NewLine
                strSql &= " INNER JOIN extendedwarranty On tworkorder.WO_ID = extendedwarranty.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN tlocation On tlocation.Loc_ID=tworkorder.Loc_ID" & Environment.NewLine
                strSql &= " INNER JOIN tCustomer On tCustomer.Cust_ID=tlocation.Cust_ID" & Environment.NewLine
                strSql &= " WHERE tCustomer.Cust_ID = " & iCustID & Environment.NewLine
                If strClaimNo.Trim.Length > 0 Then
                    strSql &= " AND ClaimNO='" & strClaimNo & "'" & Environment.NewLine
                ElseIf strOrderOwner.Trim.Length > 0 Then
                    strSql &= " AND UPPER(REPLACE(REPLACE(extendedwarranty.ShipTo_Name,' ',''),'''', ''))  =UPPER(REPLACE('" & strOrderOwner.Replace("'", "") & "',' ',''))"
                End If
                dt = Me._objDataProc.GetDataTable(strSql)

                'Product and model data
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

        '********************************************************************************

#End Region

    End Class
End Namespace